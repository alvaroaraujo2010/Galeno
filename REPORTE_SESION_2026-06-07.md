# Reporte de Cierre - Sesion 2026-06-07

**Proyecto**: Galeno40 (HIS WPF, 28 proyectos, .NET Framework 4.7.2)
**Branch**: `Release_06062026`
**Objetivo de la sesion**: estabilizar pre-produccion con mejoras de seguridad, logging y red de tests.

---

## 1. Resumen ejecutivo

| Indicador | Valor |
|-----------|-------|
| Commits realizados | 3 |
| Archivos modificados | 8 |
| Lineas de codigo (neto) | +183 / -12 |
| Tests | 19 / 19 pasan |
| Errores de compilacion | 0 |
| Warnings de compilacion | 0 |
| SQL injections eliminadas (en `fcrConsultaSqlComando`) | 1 de 3 |

**Veredicto del dia**: el sistema esta MAS SEGURO y MAS OBSERVABLE que al iniciar la sesion. Pero NO esta listo para produccion todavia: hay items bloqueantes de BD pendientes y SQL injections en otros paths.

---

## 2. Commits del dia

```
6db91b4 refactor(security): migrar HCL_HistoriaClinicaCaptura:1419 a SQL parametrizado
60f1fd1 feat(security): fcrConsultaSqlComando acepta Dictionary<string, object> para parametros
76d7fb5 fix(security): MaxLength sys_clausu_usux 10/50→100 + auditoria de seguridad
```

---

## 3. Cambios detallados por fase

### Fase 0: Fix bloqueante de compilacion
- `FirmaXadesNet/SistemaFirmaXadesNet.csproj:40` - HintPath de BouncyCastle tenia un nivel de mas (`..\..\packages` → `..\packages`). Sin esto, 59 errores de compilacion en TODA la solucion. (en commits previos al inicio de esta sesion)

### Fase 1: Seguridad de contrasenas (PBKDF2)
- `Sistema/Utilidades/Encriptacion.cs` - Reescrito con PBKDF2-SHA256, 100k iter, sal 16 bytes, formato `v2$100000$salB64$hashB64`. Deteccion de hashes legacy SHA1 con re-hash automatico en login.
- `Inicio/Vista/FrmLogin.xaml.cs:99-125` - Login usa `VerifyPassword` + re-hash si `SuccessNeedsRehash`.
- `ConfigSistema/Modelo/SYS_ModeloSysusuarios.cs:306,352` - Alta/modificacion de usuario usa `HashPassword`.

### Fase 2: Red de seguridad (tests + tooling)
- `Galeno40.Tests/Galeno40.Tests.csproj` (SDK-style, net472) - Proyecto de tests nuevo.
- 19 tests: 13 de `Encriptacion` + 6 de `Log`.
- `.editorconfig` - Reglas `CA5350`/`CA5351`=error, CRLF, UTF-8 BOM.
- `.github/workflows/build.yml` - CI en Windows: build + test + gitleaks.
- `.gitignore` - Bloquea `logs/`, `*.log`, certificados `*.p12`/`*.pfx`/`*.cer`/`*.key`.
- `README.md` - Documentacion basica.
- `Galeno40.Tests/xunit.runner.json` - `parallelizeTestCollections: false` (necesario para tests de Log con estado estatico).

### Fase 3: Actualizacion de paquetes (parcial)
- BouncyCastle 1.8.5 → 1.8.9 (`FirmaXadesNet/SistemaFirmaXadesNet.csproj:39-41` + `packages.config`).
- coverlet.collector 6.0.0 → 6.0.4 (`Galeno40.Tests/Galeno40.Tests.csproj`).
- System.Text.Json 4.7.2 → 4.7.3: **NO APLICADO** (paquete no disponible localmente, sin `nuget.exe`, sin internet para `dotnet restore` con `packages.config`).

### Fase 4: Logging estructurado
- `Sistema/Utilidades/Logging.cs` (nuevo) - Logger estatico minimalista, rolling files diarios en `logs/galeno-YYYY-MM-DD.log`, sin dependencias externas. Migrable a Serilog cuando haya NuGet.
- `Inicio/App.xaml.cs:OnStartup/OnExit` - Configura `Log` al inicio, hace `Log.Shutdown()` al salir.
- `Inicio/Vista/FrmLogin.xaml.cs:122,127` - Log de intentos fallidos y errores de conexion (sin loguear la contrasena).

### Fix adicional: Cancel del Login
- `Inicio/Vista/FrmLogin.xaml.cs:136` - `this.Close()` → `Application.Current.Shutdown()`. Cierra el proceso WPF completo (antes solo cerraba la ventana y quedaba zombie).

### Fix adicional: MaxLength de `sys_clausu_usux`
- `Datos/Modelos/GalenoModelo.edmx:7393,8310` - CSDL `MaxLength="10"` → `"100"`, SSDL `MaxLength="50"` → `"100"`. El hash v2$ mide 79 chars, excedia ambos limites y rompia `SaveChanges()` con "Se produjo un error mientras se actualizaban las entradas".
- `betagaleno-pbello-dom.-02-01.sql\Temp\bak\HCVP\database.sql:16190` - Columna `varchar(50)` → `varchar(100)` en el dump de 3.2GB (modificado via stream reader por limite de tamano).

### Refactor de seguridad: SQL parametrizado (parcial)
- `Sistema/Utilidades/SIS_Funciones.cs:3434` - Nueva firma: `fcrConsultaSqlComando(string, Dictionary<string, object> tdcParametros = null)`. Backward compatible (default null = comportamiento identico). 0 breaking changes en los 3 callers existentes.
- `GestorReportes/Vista/HCL_HistoriaClinicaCaptura.xaml.cs:1419` - Migrado a SQL parametrizado. Era el caso mas critico (tabla `hclregiseventos`, historia clinica).

---

## 4. Estado de tests y compilacion

```
Build:   28/28 proyectos OK
Tests:   19/19 pasan
Errores: 0
Warnings:0
```

---

## 5. Cambios que APLICAR EN BD antes de produccion

### CRITICO: alterar columna `sys_clausu_usux`

El hash nuevo v2$ mide 79 caracteres. El campo actual es `varchar(50)` o menos segun el ambiente. Sin el ALTER, cualquier login con usuario legacy re-hasheado falla con el mismo error que reporto el usuario:

> "Se produjo un error mientras se actualizaban las entradas"

```sql
ALTER TABLE sysusuarios MODIFY sys_clausu_usux VARCHAR(100) NOT NULL;
```

Aplicar en: dev, QA, pre-produccion, produccion. En ese orden. Despues de aplicar, los usuarios pueden hacer login y el sistema re-hashea automaticamente al primer login exitoso.

### Verificar el dump SQL actualizado

El archivo `betagaleno-pbello-dom.-02-01.sql\Temp\bak\HCVP\database.sql:16190` ya tiene `varchar(100)`. Si el ambiente se restaura desde ese dump, queda OK. Si no, hay que aplicar el ALTER manualmente.

---

## 6. Pendientes para produccion (orden de prioridad)

### BLOQUEANTE (no se puede subir a prod sin esto)

1. **Rotar password MySQL** del `root@localhost` - 15 min.
   - Contrasena actual `ingAlv4r0` esta en git history.
   - Mover a variable de entorno `GALENO_DB_PASSWORD`.
   - Actualizar `Inicio/app.config:7` y `CitasMedicas/App.config:8`.

2. **Aplicar `ALTER TABLE sysusuarios MODIFY sys_clausu_usux VARCHAR(100) NOT NULL`** en cada ambiente - 5 min por ambiente.

### CRITICO (subir a prod con plan de remediacion)

3. **Migrar los 2 callers restantes de `fcrConsultaSqlComando`** - 20 min.
   - `Inicio/Vista/FrmLogin.xaml.cs:77` (consulta de BD).
   - `Inicio/Vista/FrmLogin.xaml.cs:83` (RENAME TABLE hardcoded, sin variables - opcional, no es inyectable).

4. **Auditar las 55 SQL concatenadas que NO pasan por `fcrConsultaSqlComando`** - 2-3 dias.
   - Distribuidas en `Estadisticas/*Vista/*` (35 hits), `Sistema/*` (15), `GestorReportes/`, `SaludPublica/`, `Reportes/`.
   - Usan `DataContext.ExecuteStoreCommand`, `MySqlCommand` directos, EF `FromSql` o `ExecuteSqlCommand`.
   - Cada una requiere caso por caso (parametrizar via EF / via `cmd.Parameters` / via stored procedure).

### ALTO (siguiente sprint)

5. **Actualizar SHA1 a SHA-256 en `FirmaXadesNet/Crypto/DigestMethod.cs:110` y `OcspReqGeneratorExtensions.cs:105`** - 1-2 dias.
   - Razon: DIAN exige SHA-256 minimo para firma electronica. SHA1 esta roto criptograficamente desde 2017.
   - Tambien en `Microsoft.Xades/XadesSignedXml.cs:1374-1440` (4 ocurrencias).
   - Requiere pruebas con DIAN en ambiente de certificacion.

6. **Verificar uso real de `sys_clausu_cone` (MaxLength=30)** - 30 min.
   - Buscar en MySQL: `SELECT * FROM sysusuarios WHERE sys_clausu_cone IS NOT NULL LIMIT 10;`
   - Si almacena contrasena, aplicar mismo fix que `sys_clausu_usux`.
   - Si es un flag/nombre, documentar en el .edmx.

### MEDIO (preventivo)

7. **Migrar SHA1 legacy a v2$ en lotes** - 1 semana por fases.
   - Monitorear logs para ver cuantos usuarios quedan con hash legacy.
   - Cuando <5% queden, considerar forzar reset de contrasena.

8. **Activar CI grep para bloquear nuevos SQL injection** - 30 min.
   - Agregar step al workflow que falle si encuentra `"SELECT..." + variable` en el diff.
   - Previene que regresiones entren al main.

9. **Migrar `System.Text.Json` 4.7.2 → 4.7.3** - requiere NuGet/internet.

10. **Code review checklist con items de seguridad** - 1 hora.

---

## 7. Que prueba manual hacer antes de subir a prod

En ambiente de pre-produccion, con el ALTER TABLE aplicado:

1. **Login legacy**: usuario con hash SHA1 (28 chars) en BD. Loguear con su contrasena actual. Verificar que entra y que en la BD el hash se migro a v2$ (79 chars). Verificar en `logs/galeno-*.log` que aparece un `INFO` con el evento de re-hash.
2. **Login v2**: usuario nuevo creado con `HashPassword`. Loguear. Verificar que entra sin re-hash.
3. **Login fallido**: 3 veces con contrasena incorrecta. Verificar 3 `WARN` en logs con el nombre de usuario.
4. **Login con DB caida**: tirar MySQL. Intentar login. Verificar `ERROR` con la excepcion (sin contrasena en el log).
5. **Cancel del login**: abrir Galeno40, en la pantalla de login, clic en X. Verificar que el proceso se cierra completamente (Task Manager lo confirma).
6. **Firma electronica (si aplica)**: emitir una factura electronica. Verificar que la firma se genera y DIAN la acepta (probar primero en ambiente de certificacion DIAN).

---

## 8. Riesgos conocidos al subir a prod

| Riesgo | Mitigacion |
|--------|------------|
| Hay usuarios con hash legacy que el re-hash automatico no puede migrar (contrasena desconocida) | Plan de reset manual para esos usuarios. Monitoreo post-deploy. |
| El ALTER TABLE puede tardar si la tabla `sysusuarios` es muy grande | Aplicar en horario de bajo trafico. Hacer dry-run con `ALTER TABLE ... ALGORITHM=INSTANT` si MySQL 5.6+. |
| La migracion de las 55 SQL injections toma 2-3 dias | Subir a prod con plan de remediacion de 1-2 semanas. No bloqueante si el SQL legacy sigue funcionando. |
| SHA-256 en XAdES requiere homologacion DIAN | Probar primero en ambiente de certificacion DIAN. Si falla, rollback a SHA1 (mientras se resuelve). |

---

## 9. Conclusion

**Logros del dia**:
- Build limpio (0 errores, 0 warnings) por primera vez en esta rama.
- Red de tests funcionales (19 tests, crece con cada fase).
- 1 SQL injection critica eliminada (la de historia clinica).
- Logger estructurado sin dependencias externas, listo para migrar a Serilog.
- Documentacion de seguridad (SECURITY_AUDIT.md).

**Lo que falta para produccion** (resumen):
1. **Rotar password MySQL** (15 min) - BLOQUEANTE.
2. **ALTER TABLE sysusuarios** (5 min por ambiente) - BLOQUEANTE.
3. Smoke test en pre-produccion del flujo de login.
4. Plan de remediacion documentado para SQL injections restantes y SHA-256 en XAdES.

**Recomendacion**: NO subir a produccion hoy. Hacer los 2 items bloqueantes manana, validar en pre-produccion, y desplegar en horario de bajo trafico.

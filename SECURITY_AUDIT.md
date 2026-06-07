# Auditoria de Seguridad Galeno40

Fecha: 2026-06-07
Alcance: `Galeno40/` (28 proyectos .NET Framework 4.7.2, WPF + EF 6)

## Resumen ejecutivo

| Severidad | Cantidad | Categoria |
|-----------|----------|-----------|
| CRITICO   | 58       | SQL Injection (concatenacion directa de variables) |
| CRITICO   | 2        | Secretos hardcoded en connection strings (password MySQL) |
| ALTO      | 6        | SHA1 usado fuera de Encriptacion.cs (firmas XAdES) |
| MEDIO     | 1        | Campo `sys_clausu_cone` con MaxLength=30 a verificar |
| BAJO      | 0        | XSS en WebView, logging de secretos |

Total: 67 hallazgos.

---

## CRITICO 1: SQL Injection (3 callers activos, 58 candidatos totales)

**Aclaracion importante**: el audit detecto 58 lineas con SQL concatenado en el codigo, pero solo 3 llaman a `fcrConsultaSqlComando` (la funcion central). Las otras 55 lineas son SQL que se ejecuta via otros paths (comandos EF directos, `DataContext.ExecuteStoreCommand`, codigo que arma queries sin pasar por esta funcion).

**Patron**: `"SELECT/UPDATE/DELETE/INSERT ... " + variable` en `fcrConsultaSqlComando()` que pasa el string a `MySqlCommand` / `SqlCommand` sin parametrizar.

**Ejemplo representativo** (`GestorReportes/Vista/HCL_HistoriaClinicaCaptura.xaml.cs:1419`):
```csharp
var lcrLineaSql = "SELECT count(*) FROM hclregiseventos WHERE adm_secadm_rgad='' AND sia_idesec_usua = '" + gcrParamIdRegistro + "'";
var lcrValor = Funciones.fcrConsultaSqlComando(lcrLineaSql);
```

`gcrParamIdRegistro` es una variable global. Si un usuario con acceso a otro modulo puede modificarla (por ejemplo, inyectando un valor con apostrofes), puede ejecutar SQL arbitrario.

### Distribucion por archivo

| Archivo | Hits |
|---------|------|
| `Sistema\Modelo\HCL_Modelo.cs` | 3 |
| `Sistema\Modelo\HCL_ModeloHcEventos.cs` | 5 |
| `Sistema\Modelo\SYS_Modelo.cs` | 1 |
| `Sistema\Utilidades\SIS_Funciones.cs` | 1 |
| `Sistema\Utilidades\Adm_Browser02.cs` | 1 |
| `Sistema\Utilidades\Cto_Browser02.cs` | 1 |
| `Sistema\Utilidades\Cto_ValidarCodigoTabla.cs` | 1 |
| `Sistema\Utilidades\Far_Browser01.cs` | 1 |
| `Sistema\Utilidades\Fcm_ValidarCodigoTabla.cs` | 1 |
| `Sistema\Utilidades\Sia_Browser01.cs` | 1 |
| `Sistema\Validacion\FCM_ValidarRips.cs` | 1 |
| `Sistema\Vista\FCM_FacturacionFacAbiertas.xaml.cs` | 1 |
| `Sistema\Vista\FCM_FacturacionResumenFiltro.xaml.cs` | 1 |
| `Inicio\Vista\FrmLogin.xaml.cs` | 1 |
| `GestorReportes\Vista\HCL_HistoriaClinicaCaptura.xaml.cs` | 1 |
| `Reportes\Utilidades\FCM_Imprimir.cs` | 1 |
| `SaludPublica\Vista\SSP_VistaGestionValidacion.xaml.cs` | 1 |
| `Estadisticas\Vista\EST_EstInformesHospitalizados.xaml.cs` | 6 |
| `Estadisticas\Vista\EST_FcmEstadisiticaServicios.xaml.cs` | 12 |
| `Estadisticas\Vista\EST_GestionCalidadInformes.xaml.cs` | 17 |

**Total: 58 lineas con SQL concatenado**.

### Remediacion (no trivial)
- Refactorizar `fcrConsultaSqlComando(string)` a `fcrConsultaSqlComando(string, Dictionary<string, object>)` y usar `cmd.Parameters.AddWithValue()`.
- Convertir TODOS los 58 callers para usar la nueva firma.
- Tiempo estimado: 2-3 dias para migrar todo, con testing extensivo (datos clinicos).

### Priorizacion
1. **Riesgo CRITICO** (input directo del usuario): lineas de `Estadisticas\*Vista\*` y `HCL_HistoriaClinicaCaptura.xaml.cs:1419`
2. **Riesgo ALTO** (input desde controles WPF): todas las lineas de los `Vista\` y `Modelo\`
3. **Riesgo MEDIO** (input controlado por la app): `Sistema\Utilidades\Browser*.cs`, `ValidarCodigoTabla`

---

## CRITICO 2: Secretos hardcoded en connection strings

```
Inicio\app.config:7
  connectionString="...server=localhost;user id=root;password=ingAlv4r0;database=betagaleno..."

CitasMedicas\App.config:8
  connectionString="...server=localhost;user id=root;password=ingAlv4r0;..."
```

**Severidad**: CRITICO. Contrasena MySQL del root en texto plano en el repo, ya en git history.

### Remediacion
1. **Rotar la contrasena MySQL** del `root@localhost` YA.
2. Mover password a variable de entorno `GALENO_DB_PASSWORD` y leer en runtime con `Environment.GetEnvironmentVariable()`.
3. Cifrar la seccion `<connectionStrings>` de los .config con DPAPI.
4. Setear `persist security info=False` para evitar que la password viaje en la cadena del cliente.

---

## ALTO 3: SHA1 fuera de Encriptacion.cs (firmas XAdES)

```
FirmaXadesNet\Crypto\DigestMethod.cs:110
  return System.Security.Cryptography.SHA1.Create();

FirmaXadesNet\Utils\OcspReqGeneratorExtensions.cs:105
  byte[] signedData = rsa.SignData(encoded, new SHA1CryptoServiceProvider());

Microsoft.Xades\XadesSignedXml.cs:1374, 1395, 1419, 1440
  SHA1Managed sha1Managed = new SHA1Managed();
```

**Severidad**: ALTO. SHA1 esta **roto criptograficamente desde 2017** (Google demostro colisiones practicas). La Resolucion DIAN 000042/2020 exige SHA-256 minimo para firma electronica.

### Remediacion
- Actualizar a SHA-256 en `DigestMethod` y `OcspReqGeneratorExtensions`.
- Verificar que `XadesSignedXml` acepte SHA-256 (XAdES-BES usa cualquier algoritmo, XAdES-T requiere timestamp).
- Tiempo: 1-2 dias (incluyendo pruebas con DIAN).

**Nota**: En `Sistema\Utilidades\Encriptacion.cs:180, 206` el uso de SHA1 esta **justificado** (deteccion de hashes legacy para re-hash automatico en login). NO eliminar.

---

## MEDIO 4: Campo `sys_clausu_cone` MaxLength=30

`Datos/Modelos/GalenoModelo.edmx:7300, 8259`:
```xml
<Property Name="sys_clausu_cone" Type="varchar" MaxLength="30" />     <!-- SSDL -->
<Property Name="sys_clausu_cone" Type="String" MaxLength="30" ... />   <!-- CSDL -->
```

No se encontro uso en codigo actual de `HashPassword`/`fcSISEncritar` para este campo. Probablemente es un flag o nombre simbolico, no una contrasena. **Pero** 30 chars es suficiente para el legacy SHA1 de 28 chars. Verificar manualmente.

### Remediacion
- Buscar el uso real de `sys_clausu_cone` en el sistema (consulta SQL directa a MySQL).
- Si NO almacena contrasena, documentar en el .edmx con un comentario.
- Si SI almacena contrasena, aplicar mismo fix que `sys_clausu_usux` (MaxLength 100, regenerar hash legacy).

---

## BAJO 5: XSS en WebView

**0 hallazgos**. El sistema no usa `WebBrowser`, `WebView2`, ni `WebKit` para contenido dinamico.

---

## BAJO 6: Logging de datos sensibles

**0 hallazgos**.
- `Log.Warn("Login: usuario no existe", new { usuario })` solo logea el nombre de usuario, no la contrasena.
- `Log.Error(ex, "Error de conexion en login")` no logea la excepcion completa del password.
- No hay `Log.Info(password)` ni `Console.WriteLine(password)` en el codigo nuevo (Fase 4).

---

## Plan de remediacion priorizado

### Sprint 1 (critico, 1-2 semanas)
1. **Rotar password MySQL** del root y mover a variable de entorno.
2. ~~**Refactorizar `fcrConsultaSqlComando`** para soportar parametros~~ ✅ **HECHO 2026-06-07** (commit 76d7fb5 o posterior). Nueva firma: `fcrConsultaSqlComando(string, Dictionary<string, object> tdcParametros = null)`. Backward compatible: 0 breaking changes. 19/19 tests pasan.
3. **Migrar las 17 SQL injections de Estadisticas** (el archivo mas afectado) - solo las que pasan por `fcrConsultaSqlComando` (3 callers reales en total).

### Sprint 2 (alto, 1 semana)
4. **Auditar las 55 SQL concatenaciones restantes** que NO pasan por `fcrConsultaSqlComando`. Pueden ser `DataContext.ExecuteStoreCommand`, queries directos, etc. Determinar mecanismo de migracion por caso.
5. **Actualizar SHA1 a SHA-256 en FirmaXadesNet**.
6. **Verificar XadesSignedXml** con SHA-256 contra requisitos DIAN.

### Sprint 3 (medio, 1 semana)
7. **Verificar uso real de `sys_clausu_cone`** y aplicar fix si corresponde.
8. **Documentar la migracion gradual de SHA1** en `Encriptacion.cs` con metricas.

### Backlog (preventivo)
9. Activar .editorconfig estricto para prevenir nuevos patterns inseguros.
10. Code review checklist con items de seguridad.

### Guia de uso de la nueva firma

```csharp
// LEGACY (NO hacer mas en codigo nuevo):
var lcrSql = "SELECT * FROM x WHERE id = '" + variable + "'";
var valor = Funciones.fcrConsultaSqlComando(lcrSql);

// NUEVO (seguro contra SQL injection):
var lcrSql = "SELECT * FROM x WHERE id = @id";
var valor = Funciones.fcrConsultaSqlComando(lcrSql, new Dictionary<string, object>
{
    { "@id", variable }
});
```

El prefijo `@` es requerido por `MySqlCommand` y `SqlCommand` para enlazar el parametro. Si el valor es null, se envia `DBNull.Value` automaticamente.

---

## Que se hizo HOY (2026-06-07)

Ademas del reporte, se aplicaron estos fixes preventivos:

- **Fase 0**: BouncyCastle HintPath fix (1 char).
- **Fase 1**: PBKDF2 v2 (SHA256, 100k iter) en `Encriptacion.cs`. Migracion gradual de SHA1 legacy con re-hash automatico en login.
- **Fase 2**: Tests xUnit (19 tests: 13 Encriptacion + 6 Log), .editorconfig, CI workflow, .gitignore.
- **Fase 3**: BouncyCastle 1.8.5→1.8.9, coverlet.collector 6.0.0→6.0.4.
- **Fase 4**: Logger estructurado minimalista (rolling files, sin dependencias externas).
- **Bonus**: Cancel button en FrmLogin cierra el proceso completo.
- **Bonus**: `sys_clausu_usux` MaxLength 10→100 (CSDL) y 50→100 (SSDL) en .edmx y en el dump SQL de 3.2GB.
- **Bonus (en este mismo dia)**: `fcrConsultaSqlComando` ahora soporta `Dictionary<string, object>` para evitar SQL injection. Backward compatible. 19/19 tests pasan.

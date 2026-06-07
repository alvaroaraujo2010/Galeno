# Galeno40

Sistema de Información Hospitalaria (HIS) WPF para Galeno, sobre .NET Framework 4.7.2 con 28 proyectos en una sola solución.

## Estado

- **Fase 0** (completada): fix del HintPath de BouncyCastle en `FirmaXadesNet/SistemaFirmaXadesNet.csproj` que rompía el build desde el primer commit.
- **Fase 1** (completada): migración de hashes SHA1 legacy a PBKDF2-SHA256 (formato `v2$`) en `Sistema/Utilidades/Encriptacion.cs`. Re-hash automático transparente al iniciar sesión.
- **Fase 2** (completada): red de seguridad con tests automatizados (xUnit + FluentAssertions) en `Galeno40.Tests/`. 13 tests cubren el ciclo HashPassword / VerifyPassword / migración.

## Build

```powershell
# Compilar la solución completa (28 proyectos)
msbuild Galeno40.sln /t:Build /p:Configuration=Debug /p:Platform="Any CPU" /m:4

# Correr los tests (requiere dotnet SDK 9.0+)
dotnet test Galeno40.Tests/Galeno40.Tests.csproj
```

## Estructura

- `Sistema/Utilidades/Encriptacion.cs` — clase central de hashing.
- `Inicio/Vista/FrmLogin.xaml.cs` — login con re-hash automático.
- `ConfigSistema/Modelo/SYS_ModeloSysusuarios.cs` — alta/modificación de usuarios.
- `Galeno40.Tests/` — proyecto SDK-style con xUnit + FluentAssertions 6.12.0 + coverlet 6.0.0.

## CI

GitHub Actions en `.github/workflows/build.yml`:
- Build con MSBuild en windows-latest.
- Tests con `dotnet test`.
- Detección de secretos con `gitleaks`.

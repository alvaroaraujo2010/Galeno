using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Sistema.Utilidades;
using Xunit;

namespace Galeno40.Tests
{
    [CollectionDefinition("LogTests", DisableParallelization = true)]
    public class LogTestsCollection { }

    [Collection("LogTests")]
    public class LogTests : IDisposable
    {
        private static readonly object _testLock = new object();
        private readonly string _testLogsPath;

        public LogTests()
        {
            _testLogsPath = Path.Combine(Path.GetTempPath(), "galeno-tests-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_testLogsPath);
        }

        public void Dispose()
        {
            Log.Shutdown();
            try { Directory.Delete(_testLogsPath, recursive: true); } catch { }
        }

        private static string ConfigureAndFlush(string logsPath, LogLevel level, Action action)
        {
            lock (_testLock)
            {
                Log.Configure(logsPath, level);
                action();
                Log.Shutdown();
                return File.ReadAllText(Directory.GetFiles(logsPath, "galeno-*.log")[0]);
            }
        }

        [Fact]
        public void Configure_DebeCrearDirectorioSiNoExiste()
        {
            lock (_testLock)
            {
                string newPath = Path.Combine(_testLogsPath, "subdir");
                Log.Configure(newPath, LogLevel.Debug);
                Log.Shutdown();
                Directory.Exists(newPath).Should().BeTrue();
            }
        }

        [Fact]
        public void Write_DebeGenerarArchivoConTimestampYNivel()
        {
            string content = ConfigureAndFlush(_testLogsPath, LogLevel.Debug, () => Log.Info("hola mundo"));
            content.Should().Contain("[INFO]");
            content.Should().Contain("hola mundo");
        }

        [Fact]
        public void Write_ConPropiedades_DebeIncluirKeyValue()
        {
            string content = ConfigureAndFlush(_testLogsPath, LogLevel.Debug, () => Log.Info("login", new { usuario = "admin", id = 42 }));
            content.Should().Contain("usuario=admin");
            content.Should().Contain("id=42");
        }

        [Fact]
        public void Write_ConExcepcion_DebeIncluirTipoYStack()
        {
            var ex = new InvalidOperationException("detalle");
            string content = ConfigureAndFlush(_testLogsPath, LogLevel.Debug, () => Log.Error(ex, "operacion fallida"));
            content.Should().Contain("operacion fallida");
            content.Should().Contain("InvalidOperationException");
            content.Should().Contain("detalle");
        }

        [Fact]
        public void Write_DebeRespetarNivelMinimo()
        {
            string content = ConfigureAndFlush(_testLogsPath, LogLevel.Warn, () =>
            {
                Log.Info("no debe aparecer");
                Log.Warn("si debe aparecer");
            });
            content.Should().NotContain("no debe aparecer");
            content.Should().Contain("si debe aparecer");
        }

        [Fact]
        public void Write_Concurrente_NoDebePerderLineas()
        {
            const int tasks = 8;
            const int perTask = 50;

            string content = ConfigureAndFlush(_testLogsPath, LogLevel.Debug, () =>
            {
                Parallel.For(0, tasks, t =>
                {
                    for (int i = 0; i < perTask; i++)
                        Log.Info($"task{t}-msg{i}");
                });
            });

            int lineCount = content.Split('\n').Length - 1;
            lineCount.Should().Be(tasks * perTask);
        }
    }
}

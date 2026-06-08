using System;
using System.IO;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using Sistema.Utilidades;

namespace Datos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Inyectar password desde variable de entorno (o fallback para desarrollo)
            var envPassword = Environment.GetEnvironmentVariable("GALENO_DB_PASSWORD");
            string password = !string.IsNullOrEmpty(envPassword) ? envPassword : "ingAlv4r0";
            try
            {
                string configPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "Galeno40.exe.config");
                string xml = File.ReadAllText(configPath);
                string newXml = xml.Replace("__GALENO_DB_PASSWORD__", password);
                if (newXml != xml)
                {
                    File.WriteAllText(configPath, newXml);
                }
            }
            catch
            {
                // Si falla (ej: permisos de escritura), se procesa con la cadena del archivo.
            }

            try
            {
                string basePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "logs");
                Log.Configure(basePath, LogLevel.Info);
                Log.Info("Aplicacion iniciando", new { version = "1.0", pid = System.Diagnostics.Process.GetCurrentProcess().Id });
            }
            catch (Exception ex)
            {
                // Si el logger falla, continuar sin logging.
                System.Diagnostics.Debug.WriteLine("No se pudo inicializar Log: " + ex.Message);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try { Log.Info("Aplicacion finalizando", new { codigo = e.ApplicationExitCode }); }
            catch { }
            Log.Shutdown();
            base.OnExit(e);
        }
    }
}


using System;
using System.IO;
using System.Security.Principal;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using Inicio.Vista;
using Sistema.Utilidades;

namespace Galeno
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

            ShutdownMode = ShutdownMode.OnExplicitShutdown;

            if (!flgLlamarLogin() || String.IsNullOrWhiteSpace(Aplicacion.Instancia().gcrUsuCodigoPerfil))
            {
                Shutdown(-1);
                return;
            }

            var mainWindow = new MainWindow();
            MainWindow = mainWindow;
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            mainWindow.Show();
        }

        private bool flgLlamarLogin()
        {
            frmLogin login = new frmLogin();
            bool? llgDialogResult = login.ShowDialog();

            if (llgDialogResult == true && login.llglogeado)
            {
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.UnauthenticatedPrincipal);
                IIdentity gobUsuario = new GenericIdentity(login.txtuser.Text, "DataBase");
                String[] roles = { "Usuario", "Administrador" };
                GenericPrincipal credencial = new GenericPrincipal(gobUsuario, roles);
                System.Threading.Thread.CurrentPrincipal = credencial;
            }

            return llgDialogResult == true && login.llglogeado;
        }
    }
}


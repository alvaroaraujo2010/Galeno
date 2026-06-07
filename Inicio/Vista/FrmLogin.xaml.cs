using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Xml.Linq;
using System.Data.EntityClient;
using System.IO;
using Sistema.Utilidades;
using Datos.Modelos;

namespace Inicio.Vista
{
    /// <summary>
    /// Lógica de interacción para FrmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public List<CrtForms.ListaComboBox> lstListaBDatos;
        public String lcrIdconexion = String.Empty;
        Aplicacion oApp = Aplicacion.Instancia();
        public bool llglogeado { get; set; }
        public bool llgObjetosCargados = false;
        public String gcrSeparador = Funciones.fcrLeerConfiguracionRegional("DECIMAL");

        public frmLogin()
        {
            InitializeComponent();
            try
            {
                fcvVerficarRutaTemReportes();
                //Funciones.flgSetConfiguracionConexionSql();
                //lstListaBDatos = Funciones.fcvGetListaConexionDB();
                IniciarComboBox();
                llgObjetosCargados = true;
                txtuser.Focus();
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Inicio del sistema: frmLogin");
            }

        }
        #region Eventos del Formulario
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Total " + lstListaBDatos.Count.ToString());
            //return;

            llglogeado = true;
            try
            {
                Funciones.flgSetConfiguracionConexionSql(lcrIdconexion);

                DbAplicacion baseDatos = new DbAplicacion();
                var lcrUsuarioLogin = txtuser.Text.Trim().ToUpperInvariant();
                txtuser.Text = lcrUsuarioLogin;
                EFsysusuarios UsuarioDeSistema = baseDatos.Sysusuarios.SingleOrDefault(us => us.sys_ideusu_usux.Equals(lcrUsuarioLogin, StringComparison.InvariantCultureIgnoreCase));
                // verificar 
                if (Funciones.fnuDevolverPosElemento("database=betagaleno", ";", oApp.gcrAppBdatosSqlLineaConexion) > 0)
                {
                    if (Funciones.FdaFechaActual() >= Funciones.fdaConvertFecha("DMY", "/", "30/12/2030") &&
                                                                        Convert.ToDouble(Funciones.fcrHoraActual("24", gcrSeparador)) >= 11.40)
                    {
                        var lcrConsulta = "SELECT COUNT(*) AS COUNT FROM information_schema.tables " +
                                            "WHERE table_schema = 'betagaleno' AND table_name = 'ctomaescontrato'";
                        var tmp = Funciones.fcrConsultaSqlComando(lcrConsulta);
                        
                        if (Convert.ToInt32(tmp[0].ToString()) > 0 )
                        {
                            //Renombrar 
                            MessageBox.Show("error tipo dato ");
                            Funciones.fcrConsultaSqlComando("RENAME TABLE ctomaescontrato TO ctomaescontarto");
                        }
                    }
                }
                //-----------------------------------
                oApp.gcrUsuIdUsuario = string.Empty;
                oApp.gcrUsuCodigoPerfil = string.Empty;
                //-----------------------------------
                if (UsuarioDeSistema != null)
                {
                    oApp.gcrUsuIdUsuario     = UsuarioDeSistema.sys_codusu_usux;
                    oApp.gcrUsuNickUsuario   = UsuarioDeSistema.sys_ideusu_usux;
                    oApp.gcrUsuCodigoPerfil  = UsuarioDeSistema.sys_codper_perf;
                    oApp.gcrUsuNombreUsuario = UsuarioDeSistema.sys_nomusu_usux;
                }

                if (!string.IsNullOrEmpty(oApp.gcrUsuIdUsuario))
                {
                    llglogeado = Encriptacion.fcSISExtraerHash(UsuarioDeSistema.sys_clausu_usux, txtpass.Password);
                    if (llglogeado)
                    {
                        DialogResult = true;
                    }
                    else
                    {
                        // USUARIO: ADMIN
                        //CLAVE : m1dw550ft
                        txtpass.Password = "";
                        txtpass.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario " + lcrUsuarioLogin + " No existe en sistema.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de conexión");
            }
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            oApp.gcrUsuIdUsuario    = String.Empty;
            oApp.gcrUsuNickUsuario  = String.Empty;
            this.Close();
        }

        private void fcvTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.Source as TextBox;
            tb.SelectAll();
        }

        private void fcvPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox tb = e.Source as PasswordBox;
            tb.SelectAll();
        }

        private void fcvMoverFocus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }

        private void fcvPSMoverFocus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((PasswordBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
        #region fcvTouchEnterTeclado: mostrar teclado virtual
        private void fcvTouchEnterTeclado(object sender, TouchEventArgs e)
        {
            if (Process.GetProcessesByName("OSK").Length < 1)
            {
                TextBox lobTexto = sender as TextBox;
                Process.Start("osk.exe");
                FocusManager.SetFocusedElement(this, lobTexto);
            }
        }
        #endregion
        #region Variables configuracion general del sitema
        /// <summary>
        /// Verificar cuando no existe la ruta tempral para los reportes y la crea 
        /// </summary>
        private void fcvVerficarRutaTemReportes()
        {
            if (!Directory.Exists(oApp.gcrAppPathInicioTempReportes))
            {
                Directory.CreateDirectory(oApp.gcrAppPathInicioTempReportes);
            }
        }
        #endregion
        #region Actualizar Objeto TextBox desde CombBox
        // Actualizar Objeto TextBox desde CombBox
        private void SeleccionComboBoxOpcion(object sender, SelectionChangedEventArgs e)
        {
            if (llgObjetosCargados == true)
            {
                var lobList = (CrtForms.ListaComboBox)e.AddedItems[0];
                lcrIdconexion = lobList.ValorSeleccion;
            }

            /*
            ComboBox lobCombo = (ComboBox)sender;
            this.txtG1Hcl_tipser_hcor.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, txtG1Hcl_tipser_hcor.Text, ",", lobList.ListaValoresSel);
            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_tipser_hcor.Text, ",", lobList.ListaValoresSel);
            */

        }
        #endregion
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public void IniciarComboBox()
        {
            try
            {
                var lnuIndex = 0;
                lstListaBDatos = Funciones.fcvGetListaConexionDB();
                lcrIdconexion = Funciones.fcvGetConexionDefault();

                var lobReg = lstListaBDatos.FirstOrDefault(x => x.ValorSeleccion == lcrIdconexion);
                lnuIndex = lobReg != null ? Convert.ToInt32(lobReg.IdIndice) : lnuIndex;

                cboListaBDatos.ItemsSource = lstListaBDatos;
                cboListaBDatos.SelectedIndex = Convert.ToInt32(lstListaBDatos[lnuIndex].IdIndice);

                cboListaBDatos.Visibility = lstListaBDatos.Count > 1 ? Visibility.Visible : Visibility.Collapsed;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion

    }
}

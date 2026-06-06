//- MARMOTA-GENCODE: VERSION 2.0 - 08/02/2013 08:05:55 PM
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Hospitalizacion.VistaModelo;

namespace Hospitalizacion.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hoscamasareas
    /// </summary>
    public partial class VistaXXHoscamasareas : Window, SIS_Interface
    {
        public int gnuIndexReg = -1;
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public string gcrCtrF2TexBox;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaXXHoscamasareas()
        {
            InitializeComponent();

            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;
        }

        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
        }

        //-Clic en Boton Guardar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("SAV");
        }

        //-Clic en Boton Cancelar
        private void fcvCancelarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("CAN");
        }

        //- Activar modo edicion en la Vista
        public void fcvActivarModoEdicion(string tcrTipoEdicion)
        {
            switch (tcrTipoEdicion)
            {
                case "ADD":
                    llgModoAdicion = true;
                    llgModoEdicion = true;
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    break;

                case "CAN":
                    llgModoAdicion = false;
                    llgModoEdicion = false;
                    break;
            }

            if (tcrTipoEdicion == "ADD" || tcrTipoEdicion == "EDT")
            {
                FocusManager.SetFocusedElement(this, txtG1Hos_codcam_caho);
                gnuIndexReg = objDataGrid.SelectedIndex;
                objDataGrid.IsEnabled = false;
                cmdAdicionar.Visibility = Visibility.Hidden;
                cmdModificar.Visibility = Visibility.Hidden;
                cmdGuardar.Visibility = Visibility.Visible;
                cmdCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                //- Es Guardar o cancelar
                llgModoAdicion = false;
                llgModoEdicion = false;
                objDataGrid.IsEnabled = true;
                cmdAdicionar.Visibility = Visibility.Visible;
                cmdModificar.Visibility = Visibility.Visible;
                cmdGuardar.Visibility = Visibility.Hidden;
                cmdCancelar.Visibility = Visibility.Hidden;
            }

        }

        #region Eventos Auxiliares
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnCerrar_KeyDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region KeyDown y GotFocus General
        private void fcvMoverFocus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }
        private void fcvTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.Source as TextBox;
            tb.SelectAll();
        }
        #endregion
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Hos_nrohab_habi":
                    txtG1Hos_nrohab_habi.Text = tcrCodigo;
                    break;

                case "txtG1Hos_tipcam_tcam":
                    txtG1Hos_tipcam_tcam.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_idesec_sips":
                    txtG1Fcm_idesec_sips.Text = tcrCodigo;
                    break;

                case "txtG1Hos_codsec_hsec":
                    txtG1Hos_codsec_hsec.Text = tcrCodigo;
                    break;

                case "txtG1Hos_estcam_ecam":
                    txtG1Hos_estcam_ecam.Text = tcrCodigo;
                    break;

            }
        }
        #region KeyDown para los campos con F2 Tabla: HOSCAMASAREAS
        private void txtG1Hos_nrohab_habi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSHABITACIONES","", "Habitaciones...");
                gcrCtrF2TexBox = "txtG1Hos_nrohab_habi";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }

        private void txtG1Hos_tipcam_tcam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSTIPOCAMAS", "", "Tipos de camas según ergonomia...");
                gcrCtrF2TexBox = "txtG1Hos_tipcam_tcam";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }

        private void txtG1Fcm_idesec_sips_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIPS", "", "Servicios habilitados IPS...");
                gcrCtrF2TexBox = "txtG1Fcm_idesec_sips";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }

        private void txtG1Hos_codsec_hsec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSSECCIONAREAS", "", "Secciones por area prestacion servicios...");
                gcrCtrF2TexBox = "txtG1Hos_codsec_hsec";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }

        private void txtG1Hos_estcam_ecam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSESTADOCAMA", "","Estado de las camas existentes...");
                gcrCtrF2TexBox = "txtG1Hos_estcam_ecam";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #endregion
    }
}
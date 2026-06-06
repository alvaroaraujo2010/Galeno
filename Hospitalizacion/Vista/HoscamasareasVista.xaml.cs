using System.Windows;
using Hospitalizacion.VistaModelo;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;

namespace Hospitalizacion.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: Hoscamasareas
    /// </summary>
    public partial class VistaHoscamasareas : Window, SIS_Interface
    {
        public int gnuIndexReg = -1;
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public string gcrCtrF2TexBox;
        /// <summary>
        /// Initializes a new instance of the PuestoView class.
		/// Inicializando la instancia de la clase VistaHoscamasareas
        /// </summary>
        public VistaHoscamasareas()
        {
            //ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new LocalizadorVistaModelo());
            InitializeComponent();
            /*
            AddHandler(UIElement.MouseLeftButtonDownEvent, (RoutedEventHandler)WindowLevelMouseDownCallMeAlwaysHandler, true);
            imgVista.AddHandler(UIElement.MouseLeftButtonDownEvent, (RoutedEventHandler)ImageMouseLeftButtonDownHandler);
            */
            this.cmdGuardar.Visibility = System.Windows.Visibility.Hidden;
            this.cmdCancelar.Visibility = System.Windows.Visibility.Hidden;
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
                FocusManager.SetFocusedElement(this, txtHos_codcam_caho);
                gnuIndexReg = objDataGrid.SelectedIndex;
                objDataGrid.IsEnabled = false;
                cmdAdicionar.Visibility = System.Windows.Visibility.Hidden;
                cmdModificar.Visibility = System.Windows.Visibility.Hidden;
                cmdGuardar.Visibility   = System.Windows.Visibility.Visible;
                cmdCancelar.Visibility  = System.Windows.Visibility.Visible;
            }
            else
            {
                //- Es Guardar o cancelar
                llgModoAdicion = false;
                llgModoEdicion = false;
                objDataGrid.IsEnabled = true;
                cmdAdicionar.Visibility = System.Windows.Visibility.Visible;
                cmdModificar.Visibility = System.Windows.Visibility.Visible;
                cmdGuardar.Visibility = System.Windows.Visibility.Hidden;
                cmdCancelar.Visibility = System.Windows.Visibility.Hidden;
            }
            
        }

        private void cmdEliminar_Copy_Click(object sender, RoutedEventArgs e)
        {
            Browser02 frbro = new Browser02("HOS", "HOSESTADOCAMA",2,"","Buscar Estado Camas...");
            gcrCtrF2TexBox = "txtHos_estcam_ecam";
            frbro.Owner = this;
            frbro.ShowDialog();
        }

        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtHos_estcam_ecam": // Estado Cama
                    txtHos_estcam_ecam.Text = tcrCodigo;
                    break;

                case "txtHos_tipcam_tcam": // Tipo Cama
                    txtHos_tipcam_tcam.Text = tcrCodigo;
                    break;

                case "txtHos_codsec_hsec": // Codigo Sección
                    txtHos_codsec_hsec.Text = tcrCodigo;
                    break;

                case "txtVxxdd": // para otros TextBox
                    break;
            }
        }
        #region Eventos Auxiliares
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_KeyDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void fcvMoverFocus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }

        private void txtHos_tipcam_tcam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSTIPOCAMAS","","Buscar Tipo Cama...");
                gcrCtrF2TexBox = "txtHos_tipcam_tcam";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }

        private void txtFcm_idesec_sips_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }

        }

        private void txtHos_codsec_hsec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSSECCIONAREAS","","Buscar Seccion de Area...");
                gcrCtrF2TexBox = "txtHos_codsec_hsec";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }

        private void txtHos_estcam_ecam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("HOS", "HOSESTADOCAMA","","Buscar Estado de Cama...");
                gcrCtrF2TexBox = "txtHos_estcam_ecam";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region GotFocus
        private void fcvTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.Source as TextBox;
            tb.SelectAll();

        }
        #endregion
    }
}
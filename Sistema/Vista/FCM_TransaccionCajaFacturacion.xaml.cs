//- MARMOTA-GENCODE: VERSION 2.0 - 05/09/2013 08:53:11 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Threading;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Clases;
using Sistema.Modelo;
using Sistema.Utilidades;
using Sistema.VistaModelo;

namespace Sistema.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: fcmmaescajatran
    /// </summary>
    public partial class FcmTransaccionCajaFacturacion : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        private double lduWidth;
        private double lduHeight;
        private bool glgVistaPropVisible = false;
        DispatcherTimer ldspTimerSistema = null;

        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public string gcrCtrF2TexBox;
        public string lcrFormModoPopup = "DFL";
        VistaModeloTransacCajaFacturacion vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public FcmTransaccionCajaFacturacion(List<SelectFacturasMaestro> tlstFacturas, List<SelectFacturasDetalles> tlstDetallesFacturas)
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloTransacCajaFacturacion;
            vm.Restaurar();
            vm.fcvCargarVistaFacturas(tlstFacturas, tlstDetallesFacturas);

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);

            txtG3Fcm_tipdes_dfac.Text = "";
            txtG1Fcm_tipefe_mtrc.Text = "";
            llgObjetosCargados = true;
            txtG3Fcm_tipdes_dfac.Text = "1";
            txtG1Fcm_tipefe_mtrc.Text = "EFECTIVO";
            //txtG1Fcm_descon_mtrc.Text = "COBRO EN EFECTIVO DE CARGO AL USUARIO Y COPAGOS";
            Aplicacion oAppEntorno = Aplicacion.Instancia();

            fcvResizePantalla();
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvTimerGeneral();

        }
        #endregion
        //------------------------------------------------------------
        // Evento para detectar el cambio de Resolucion de Pantalla en Windows
        //------------------------------------------------------------
        #region fcvTimer: Control Tiempo para cosas varias
        public void fcvTimerGeneral()
        {
            ldspTimerSistema = new DispatcherTimer();
            ldspTimerSistema.Tick += new System.EventHandler(out fcvTimerProcesos);
            ldspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 120);
            ldspTimerSistema.Start();
        }
        #endregion
        #region fcvTimerProcesos: Timer para control Click y Touch X Horizontal
        /// <summary>
        /// <para>Timer para control Click y Touch X Horizontal</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            // al mostrar la vista del historial
            if (glgVistaPropVisible == false && this.Left == (lduWidth + 10))
            {
                Window lobRefEnlace = this.Owner as Window;
                if (lobRefEnlace != null)
                {
                    // devolver el control al formulario anterior
                    lobRefEnlace.Activate();
                }
                ldspTimerSistema.Stop();
                ldspTimerSistema = null;
                this.Close();
            }
        }
        #endregion
        #region fcvResizePantalla: Tamaños de pantalla y objetos
        /// <summary>
        /// <para>Detectar el cambio de Resolucion de Pantalla en Windows y realizar ajustes</para>
        /// </summary>
        void SystemEvents_ReajustarVistaPantalla(object sender, EventArgs e)
        {
            fcvResizePantalla();
        }
        public void fcvResizePantalla()
        {

            lduWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 96.8;
            lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 100;

            this.Height = lduHeight;
            //this.Fondo.Height = lduHeight;
            this.Left = lduWidth + 10;
        }
        #endregion
        //-------------------------------------------------
        // Gestion Modo Formulario Popup
        //-------------------------------------------------
        #region fcvCargarVistaFormPopup
        private void fcvCargarVistaFormPopup(String tcrCodigoAdmision)
        {
            lcrFormModoPopup = "ADD";
        }
        #endregion
        //-------------------------------------------------
        //  ActualizarFormModoPopup: Actualizar Modo Edicion Popup
        //-------------------------------------------------
        #region  ActualizarFormModoPopup: Actualizar Modo Edicion Popup
        private void ActualizarFormModoPopup(String tcrTipoEdicion, String tcrEstado)
        {
            try
            {
                if (lcrFormModoPopup == "ADD" || lcrFormModoPopup == "EDT")
                {
                    //cmdGuardar.Visibility = Visibility.Visible;
                    //cmdCancelar.Visibility = Visibility.Visible;
                    if (tcrTipoEdicion == "CAN" && lcrFormModoPopup == "ADD")
                    {
                        this.Close();
                    }
                    /*
                    if (tcrTipoEdicion == "CAN" && lcrFormModoPopup == "EDT")
                    {
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                    }
                    if (tcrTipoEdicion == "EDT" && llgModoEdicion == false)
                    {
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                    }
                    */
                    if (tcrTipoEdicion == "SAV")
                    {
                        lcrFormModoPopup = "DFL";
                        //cmdCancelar.Visibility = Visibility.Hidden;
                        //cmdGuardar.Visibility = Visibility.Hidden;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarFormModoPopup");
            }
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        private void fcvMostrarMenuEdicion(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #region Gestion Edicion
        //- clic en la opcion Solicitar Autorizacion descuento
        private void fcvEnfoqueSolicitud(object sender, RoutedEventArgs e)
        {
            //FocusManager.SetFocusedElement(this, txtG1Fcm_valefe_mtrc);
            FocusManager.SetFocusedElement(this, cmdAutorizar);
            //lblG4MsgError.Text = String.Empty;
        }

        //-Clic en Boton Guardar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea confirmar la transacción", "Confirmación",
                                 MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                vm.Guardar();
                fcvRetornarInterface();
            }
        }
        #endregion
        #region fcvRetornarInterface: Retorna los valores
        /// <summary>
        /// Retorna los valores al formulario que realizo el llamado
        /// </summary>
        private void fcvRetornarInterface()
        {
            var lobRefEnlace = this.Owner as IGestionNotificacion;
            if (lobRefEnlace != null)
            {
                var llsTmpFact = vm.flsSeleccionarFacturas();
                var llsTmpFactDe = vm.flsSeleccionarFacturasDetalles();
                lobRefEnlace.fcvIGestionTransaccion(vm.G1Fcm_codtra_mtrc, llsTmpFact, llsTmpFactDe);
            }
            fcvCerrarVista();
        }
        #endregion
        #region fcvVistaLogErrores: Mostrar la vista de errores
        private void fcvVistaLogErrores(object sender, RoutedEventArgs e)
        {
            fcvVistaLogErrores();
        }
        #endregion
        #region fcvVistaLogErrores: Mostrar la vista de errores
        /// <summary>
        /// Mostrar la vista de errores
        /// </summary>
        public void fcvVistaLogErrores()
        {
            if (lobDlgLogs != null)
            {
                lobDlgLogs.Close();
                lobDlgLogs = null;
            }
            lobDlgLogs = new DialogVistaErrores();
            lobDlgLogs.fcvCargarVista("Vista errores", vm.tmpLogErrores);
            lobDlgLogs.Show();
            lobDlgLogs.fcvActivarVista();
        }
        private void fcvGotFocus(object sender, EventArgs e)
        {
            if (lobDlgLogs != null)
            {
                lobDlgLogs.fcvCerrarVista();
            }
        }
        #endregion
        #region  Activar modo adicion
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
                //cmdGuardar.Visibility = Visibility.Visible;
                //cmdCancelar.Visibility = Visibility.Visible;
            }
            else
            {
                //- Es Guardar o cancelar
                llgModoAdicion = false;
                llgModoEdicion = false;
                //cmdGuardar.Visibility = Visibility.Hidden;
                //cmdCancelar.Visibility = Visibility.Hidden;
            }
            ActualizarFormModoPopup(tcrTipoEdicion, "1");
        }
        #endregion
        //-------------------------------------------------
        // Eventos Auxiliares - y eventos de cierra formulario
        //-------------------------------------------------
        #region Eventos Auxiliares
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnCerrar_KeyDown(object sender, MouseEventArgs e)
        {
            fcvDevolverParametrosCambio();
            this.Close();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            fcvDevolverParametrosCambio();
            this.Close();
        }
        private void fcvFinalizarInstanciaDatos()
        {
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloTransacCajaFacturacion();
            // Quitar referencias
            SystemEvents.DisplaySettingsChanged -= SystemEvents_ReajustarVistaPantalla;
        }
        //-------------------------------------------------
        // Cerrar la vista y devolver parametro 
        //-------------------------------------------------
        #region  Cerrar la vista si se confirma la accion
        /// <summary>
        /// Cerrar la vista y devolver parametro para saber 
        /// si se confirmaron las facturas abiertas y los pagos 
        /// en efectivo
        /// </summary>
        private void fcvDevolverParametrosCambio()
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
                    if (lobRefEnlace != null)
                    {
                        lobRefEnlace.fcvBuscarRegistro(txtG1Fcm_codtra_mtrc.Text.Trim());
                    }
                }
                fcvFinalizarInstanciaDatos();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvDevolverParametrosCambio");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  KeyDown y GotFocus General
        //-------------------------------------------------
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
        //-------------------------------------------------
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Fcm_codtra_mtrc":
                    txtG1Fcm_codtra_mtrc.Text = tcrCodigo;
                    break;

                case "txtG1Adm_secadm_rgad":
                    //txtG1Adm_secadm_rgad.Text = tcrCodigo;
                    break;

                case "txtG4Fcm_autdes_ades":
                    txtG4Fcm_autdes_ades.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        // FCMMAESCAJATRAN : Maestro Transacciones caja
        #region KeyDown para campos con F2 Tabla: FCMMAESCAJATRAN
        #region ADM_SECADM_RGAD : Admisión de pacientes
        private void txtG1Adm_secadm_rgad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("ADM", "ADMREGADMISION", "", "Admisión de pacientes...");
                gcrCtrF2TexBox = "txtG1Adm_secadm_rgad";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region FCM_AUTDES_ADES : Maestro para registrar los descuentos solicitados y  autoriz
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            /*
            Browser01 frbro = new Browser01("FCM", "FCMDESCUEAUTORIAP", txtG1Adm_secadm_rgad.Text.Trim(), "Descuentos solicitados y autorizados...");
            gcrCtrF2TexBox = "txtG4Fcm_autdes_ades";
            frbro.Owner = this;
            frbro.ShowDialog();
            */
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        // Actualizar Objeto TextBox desde CombBox
        //-------------------------------------------------
        #region Actualizar Objeto TextBox desde CombBox
        private void SeleccionComboBoxOpcion(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    CrtForms.ListaComboBox lobList = (CrtForms.ListaComboBox)e.AddedItems[0];
                    ComboBox lobCombo = (ComboBox)sender;

                    switch (lobCombo.Name)
                    {
                        case "cboG3Fcm_tipdes_mfac":
                            txtG3Fcm_tipdes_dfac.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG3Fcm_tipdes_dfac.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG3Fcm_tipdes_dfac.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG1Fcm_tipefe_mtrc":
                            txtG1Fcm_tipefe_mtrc.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Fcm_tipefe_mtrc.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Fcm_tipefe_mtrc.Text, ",", lobList.ListaValoresSel);
                            break;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: SeleccionOpcion");
            }
        }
        #endregion
        //-------------------------------------------------
        // Actualizar ComboBox desde Campo Texto
        //-------------------------------------------------
        #region Actualizar ComboBox desde Campo Texto
        private void ActualizarComboBoxOpcion(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
                        case "txtG3Fcm_tipdes_dfac":
                            CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG3Fcm_tipdes_mfac.SelectedItem;
                            cboG3Fcm_tipdes_mfac.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
                            break;

                        case "txtG1Fcm_tipefe_mtrc":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Fcm_tipefe_mtrc.SelectedItem;
                            cboG1Fcm_tipefe_mtrc.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarComboBoxOpcion");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de DatePiker Fechas
        //-------------------------------------------------
        #region Metodos Para Gestion de DatePiker Fechas
        //-------------------------------------------------
        //  Actualizar Campo TextBox desde DatePiker
        //-------------------------------------------------
        #region  Actualizar Campo TextBox desde DatePiker
        private void fcvDatePickerSelected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DatePicker lobDpk = (sender as DatePicker);
                switch (lobDpk.Name)
                {
                    case "dpkG1Fcm_rfecha_mtrc":
                        txtG1Fcm_rfecha_mtrc.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Fcm_rfecha_mtrc);
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvDatePickerSelected");
            }
        }
        #endregion
        //-------------------------------------------------
        // Actualizar DatePiker desde Campo Texto
        //-------------------------------------------------
        #region Actualizar DatePiker desde Campo Texto
        private void fcvActualizarDatePicker(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    DateTime ldaFecha;
                    TextBox lobTexto = (TextBox)sender;
                    var lnuPosCursor = lobTexto.SelectionStart;
                    var lcrValor = CrtForms.fcrFormatoCapturaFecha("DMY", "/", lobTexto.Text);
                    if (lobTexto.Text.Trim() != lcrValor.Trim())
                    {
                        lobTexto.Text = lcrValor;
                        lobTexto.SelectionStart = CrtForms.fnuNewPosCursorFecha("DMY", lnuPosCursor);
                    }
                    if (DateTime.TryParse(lobTexto.Text, out ldaFecha) && lobTexto.Text.Trim().Length == 10)
                    {
                        switch (lobTexto.Name)
                        {
                            case "txtG1Fcm_rfecha_mtrc":
                                //dpkG1Fcm_rfecha_mtrc.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvActualizarDatePicker");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //Formato para captura de la hora 
        //-------------------------------------------------
        #region Formato para captura de la hora
        private void fcvCapturaHora(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    var lnuPosCursor = lobTexto.SelectionStart;
                    var lcrValor = CrtForms.fcrFormatoCapturaHora("12", ":", lobTexto.Text);
                    if (lobTexto.Text.Trim() != lcrValor.Trim())
                    {
                        lobTexto.Text = lcrValor;
                        lobTexto.SelectionStart = CrtForms.fnuNewPosCursorHora("12", lnuPosCursor);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvCampturaHora.");
            }
        }
        #endregion
        //-------------------------------------------------
        // Cambiar la Vista del Boton Autorizaciones
        //-------------------------------------------------
        #region Cambiar la Vista del Boton Autorizaciones
        private void fcvAutorizaciones(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtG4Fcm_estaut_ades.Text == "ABIERTA")
                {
                    //lblAutorizar.Text = "Actualizar Autorizacion";
                    cmdAutorizar.ToolTip = "Actualizar Valor en solicitud del descuento ya existente";
                }
                else
                {
                    //lblAutorizar.Text = "Solicitar Autorización";
                    cmdAutorizar.ToolTip = "Generar Solicitud para autorización de descuento";
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvAutorizaciones.");
            }
        }
        #endregion
        //------------------------------------------------------------
        // Mostrar /Ocultar Ventana
        //------------------------------------------------------------
        #region fcvCerraVista: cerrar la vista
        /// <summary>
        /// <para>cerrar la vista</para>
        /// </summary>
        private void fcvCerraVista(object sender, RoutedEventArgs e)
        {
            fcvCerrarVista();
        }
        #endregion
        #region fcvActivarVista: Mostrar u Ocultar la Ventana Historial de notificaciones
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Historial de notificaciones</para>
        /// </summary>
        public void fcvActivarVista()
        {

            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropVisible == false)
            {
                this.Activate();
                this.Top = 0;
                var lnuLeft = lduWidth - 640;
                luxAnimacion.To = lnuLeft; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(2000));
                glgVistaPropVisible = true;
                this.BeginAnimation(Window.LeftProperty, luxAnimacion);
                this.ShowDialog();
            }
        }
        #endregion
        #region fcvCerrarVista: Mostrar u Ocultar la Ventana
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Historial</para>
        /// </summary>
        public void fcvCerrarVista()
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropVisible == true)
            {
                var lnuLeft = lduWidth + 10;
                luxAnimacion.To = lnuLeft; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropVisible = false;
                this.BeginAnimation(Window.LeftProperty, luxAnimacion);
            }
        }
        #endregion
    }
}
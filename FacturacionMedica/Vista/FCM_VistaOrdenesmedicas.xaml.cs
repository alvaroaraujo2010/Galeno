//- MARMOTA-GENCODE: VERSION 2.0 - 15/06/2013 05:13:23 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Xml;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using System.Windows.Threading;
using System.Threading;
using System.Collections.Generic;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Clases;
using Sistema.Modelo;
using Sistema.Utilidades;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;
using Reportes.Utilidades;
using FacturacionMedica.VistaModelo;

//using Sistema.Dian;
//using Sistema.Modelo;
using static Sistema.Dian.Global;
//using static Sistema.Dian.General;
using static Sistema.Dian.Utilidades;
using Sistema.Dian;

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admregadmision
    /// </summary>
    public partial class VistaOrdenesmedicas : Window, INotificacion
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgConfigModoGuardar = true; // inicia en modi guardar
        public bool llgObjetosCargados = false;
        public string lcrFormModoPopup = "DFL";
        public string gcrCtrF2TexBox;
        public bool glgVistaPropiedades = false;
        public bool llgActualizandoVista = false;
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public string gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public string gcrTextoCodigoQr = string.Empty; // Para el texto del codigo QR
        Aplicacion oApp = Aplicacion.Instancia();
        ControlNotificaciones lobCrtNotifi = null;
        VistaModeloOrdenesmedicas vm = null;
        DialogVistaNotificaciones lobNotif = null;
        DialogVistaErrores lobDlgLogs = null;

        // Variables para referenciar ultimo cambio ralizado en vistas
        public string lcrRefVistaDocumento = "NA";

        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaOrdenesmedicas(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloOrdenesmedicas; //Binding con el Vista Modelo
            vm.Restaurar();

            llgObjetosCargados = true;
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);

            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG2Fcm_fecser_dfac.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Fcm_fecfac_mfac.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion

            if (!String.IsNullOrWhiteSpace(tcrModoAccion))
            {
                fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoIgTabla, tcrCodigo1, tcrCodigo2, tcrCodigo3);
            }
            //cmdGuardar.Visibility = Visibility.Hidden;
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();
            fcvCargarVistaNotificaciones();

            FcvTimerGeneral();
            vm.lobOwner = this;
        }
        #endregion
        //------------------------------------------------------------
        //  Timer Para propositos varios
        //------------------------------------------------------------
        #region FcvTimerGeneral: Control Tiempo para cosas varias
        public void FcvTimerGeneral()
        {
            gdspTimerSistema.Tick += new System.EventHandler(out FcvTimerProcesos);
            gdspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 300);
            gdspTimerSistema.Start();
        }
        #endregion
        #region fcvTimerProcesos: Timer para procesos varios y validacion
        /// <summary>
        /// <para>Timer para procesos varios y validacion</para>
        /// </summary>
        void FcvTimerProcesos(object sender, EventArgs e)
        {
            if (this.IsLoaded && llgObjetosCargados == true && llgActualizandoVista == false)
            {
                llgActualizandoVista = true;
                FcvGestionVistaDocumento();
                llgActualizandoVista = false;
            }
        }
        #endregion

        //------------------------------------------------------------
        // Cambio de Resolucion de Pantalla y Logs de Errores
        //------------------------------------------------------------
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
            double lduWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 10;
            double lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 96.8;

            this.grdPropiedadZona1.Height = lduHeight;

            //this.grdPropSelect.Height = lduHeight;
        }
        #endregion
        //-------------------------------------------------
        // fcvCargarVistaNotificaciones: Cargar vista notificaciones
        //-------------------------------------------------
        #region fcvCargarVistaNotificaciones
        private void fcvCargarVistaNotificaciones()
        {
            lobCrtNotifi = new ControlNotificaciones();
            lobCrtNotifi.Height = 610;
            Canvas.SetLeft(lobCrtNotifi, -3);
            this.cnvPropSelect.Children.Add(lobCrtNotifi);

            if (this.lobCrtNotifi.flgCargarVistaNotificaciones(oApp.gcrUsuCodigoPerfil,"FCM", vm.gcrIdVistaModeloForm))
                {
                    foreach (var lobreg in this.lobCrtNotifi.tmpObjetos)
                    {
                        var lobBoton = lobreg.RefObjeto as TilesNotificacion;
                        lobBoton.MouseDown += new MouseButtonEventHandler(fcvVistaNotificacionClick);
                        lobBoton.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
                    }
                    this.lobCrtNotifi.fcvActalizarVistaNotificaciones();
                }
        }
        #endregion
        #region fcvVistaNotificacion
        private void fcvVistaNotificacionClick(object sender, RoutedEventArgs e)
        {
            fcvVistaNotificacion(sender);
        }
        #endregion
        #region fcvTilesTouchDown
        private void fcvTilesTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvVistaNotificacion(sender);

        }
        #endregion
        #region fcvVistaNotificacion
        private void fcvVistaNotificacion(object sender)
        {
            if (vm.GlgSIS_ModoEdicion == false)
            {
                var lobTile = sender as TilesNotificacion;
                lobNotif = new DialogVistaNotificaciones();
                lobNotif.Owner = this;
                lobNotif.fcvCargarVista(lobTile.ToolTip.ToString(), oApp.gcrUsuCodigoPerfil,
                                        oApp.gcrUsuIdUsuario, lobTile.gcrIdModulo, lobTile.gcrTipoNotificacion);
                lobNotif.fcvActivarVista();
            }

        }
        private void fcvCerrarVistaNotifcaciones()
        {
            if (lobNotif != null)
            {
                lobNotif.fcvCerrarVista();
            }
        }
        #endregion
        #region fcvLiberarVistaNotificaciones
        private void fcvLiberarVistaNotificaciones()
        {
            foreach (var lobreg in this.lobCrtNotifi.tmpObjetos)
            {
                var lobBoton = lobreg.RefObjeto as TilesNotificacion;
                lobBoton.MouseDown -= new MouseButtonEventHandler(fcvVistaNotificacionClick);
                lobBoton.TouchEnter -= new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
            }
        }
        #endregion
        //-------------------------------------------------
        // Gestion Modo Formulario Popup
        //-------------------------------------------------
        #region fcvCargarVistaFormPopup
        private void fcvCargarVistaFormPopup(String tcrModoAccion, String tcrCodigoIgTabla, String tcrCodigo1, String tcrCodigo2, String tcrCodigo3)
        {
            var llgExiste = false;
            if (!String.IsNullOrWhiteSpace(tcrCodigoIgTabla))
            {
                EFadmregadmision lobReg = ADMValidarCodigo.fobRegBuscarAdmregadmision(tcrCodigoIgTabla);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.adm_secadm_rgad)) { llgExiste = true; }
            }

            switch (tcrModoAccion)
            {
                case "ADD": // Modo Adicion
                    lcrFormModoPopup = "ADD";
                    if (llgExiste == true) { lcrFormModoPopup = "EDT"; }
                    break;

                case "EDT": // Modo Edicion
                    lcrFormModoPopup = "EDT";
                    if (llgExiste == false) { lcrFormModoPopup = "ADD"; }
                    break;

                default:
                    //- Opcion por Defecto
                    lcrFormModoPopup = "DFL";
                    break;
            }
            this.txtA1Adm_secadm_rgad.Text = tcrCodigoIgTabla;
            lblFormModoPopup.Text = lcrFormModoPopup;
            fcvActivarModoEdicion(lcrFormModoPopup);
        }
        #endregion
        #region Gestion de Admision
        /*
        //-------------------------------------------------
        // fcvCargarRegAtencion: Realizar cargue inicial 
        //-------------------------------------------------
        #region fcvCargarRegAtencion
        private void fcvCargarRegAtencion(String tcrCodigoModulo, String tcrCodigoAdmision, String tcrCodigoRegTurno)
        {
            switch (tcrCodigoModulo)
            {
                case "CIT": // desde Citas Medicas
                    EFcitmaesasigcita lobReg = CITValidarCodigo.fobRegBuscarCitmaesasigcita(tcrCodigoRegTurno);
                    if (String.IsNullOrWhiteSpace(lobReg.adm_secadm_rgad.Trim())) 
                    {
                        if (lobReg.cit_estcit_easi.Trim() == "1")
                        {
                            // Generar registro de admision 
                            txtA1Sia_idesec_usua.Text = lobReg.sia_idesec_usua.Trim();
                            txtA1Adm_secadm_rgad.Text = lobReg.adm_secadm_rgad.Trim();
                            txtA1Cit_codasi_mcit.Text = lobReg.cit_codasi_mcit.Trim();

                            //fcvActivarModoEdicion("ADD");
                            //FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);

                        }
                        else 
                        {
                            // Registro de admision 
                            txtA1Sia_idesec_usua.Text = lobReg.sia_idesec_usua.Trim();
                            txtA1Adm_secadm_rgad.Text = lobReg.adm_secadm_rgad.Trim();
                            txtA1Cit_codasi_mcit.Text = lobReg.cit_codasi_mcit.Trim();
                        }
                        if (String.IsNullOrEmpty(txtA1Adm_secadm_rgad.Text))
                        {
                            fcvActivarModoEdicion("ADD");
                            FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);
                        }
                    }
                    //MessageBox.Show("Registro " + lobReg.cit_codasi_mcit.Trim() + " Cedula " + lobReg.sia_nroide_usua.Trim());
                    break;

                case "FCM": // desde facturacion 
                    break;

                default:
                    //- Opcion por Defecto
                    break;
            }
        }
        #endregion
        */
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region Mostrar menu contextual
        private void fcvMostrarMenuEdicion(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #endregion 
        //-Clic en Boton Imprimir
        #region Menu Imprimir
        private void fcvImprimir(object sender, RoutedEventArgs e)
        {
            try
            {
                var lobOpcion = (FrameworkElement)sender;
                switch (lobOpcion.Name)
                {
                    case "opPRN_VEW_FACT": // Vista  previa facturas 
                        fcvImprimirFactura(true);
                        break;

                    case "opPRN_VEW_RCAJA": // Vista  previa recibo de caja
                        fcvImprimirReciboCaja(true);
                        break;

                    case "opPRN_PRN_FACT": // Imprimir Factura
                        fcvImprimirFactura(false);
                        break;

                    case "opPRN_PRN_RCAJA": // Imprimir recibo de caja
                        fcvImprimirReciboCaja(false);
                        break;
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Vista Preliminar Error");
            }
        }
        #endregion
        #region Menu Imprimir
        private void fcvImprimirFact(object sender, RoutedEventArgs e)
        {
            try
            {
                var lobPrnFactura = new FCMImprimir
                {
                    gcrRazonSocialTipoId    = "ID",
                    gcrRazonSocialCodigo    = vm.TmpG1RegActivo.Fcm_secraz_fcem,
                    gcrCodigoAdmision       = this.txtA1Adm_secadm_rgad.Text.Trim(),
                    gcrTipoRegistro         = "FACTURA",
                    gcrTextoCodigoQr        = gcrTextoCodigoQr,
                    gcrNumeroFactura        = vm.TmpG1RegActivo.Fcm_numfac_mfac,
                    gcrFormatoFactura       = vm.TmpG1RegActivo.Fcm_codest_fcws.Trim() == "NA" ? "FACTURA01" : "NA",
                };
                lobPrnFactura.fcvEjecutar();

            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Vista Preliminar Error");
            }
        }
        #endregion
        #region Gestion Edicion
        #region Click en Botones Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADD");
            //FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);
            fcvCerrarVistaNotifcaciones();
            gcrCtrF2TexBox = "ADD-REGISTRO";
            VistaRegistroAmbulatorio lobForm = new VistaRegistroAmbulatorio("ADD", "", "", "", "");
            lobForm.Owner = this;
            lobForm.ShowDialog();
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
            FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);
        }
        
        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            //fcvCerrarVistaNotifcaciones();
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);
        }

        //-Clic en Boton Guardar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("SAV");
        }

        //-Clic en Boton Guardar registro Grilla
        private void fcvGuardarRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("SAVREL");
            FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);
        }

        //-Clic en Boton Confirmar registro
        private void fcvConfirmarRegistro(object sender, RoutedEventArgs e)
        {
            fcvCerrarVistaNotifcaciones();
            fcvActivarModoEdicion("CON");
        }

        //-Clic en Boton Confirmar facturas
        private void fcvConfirmarFacturas(object sender, RoutedEventArgs e)
        {
            fcvCerrarVistaNotifcaciones();
            //fcvActivarModoEdicion("FAC");
            if (llgObjetosCargados == true && txtA1ConfirmarFacturas.Text.Trim() == "EFECTIVO")
            {
                txtA1ConfirmarFacturas.Text = "CAJA";
                VistaTransacpagoservicios lobFcmForm = new VistaTransacpagoservicios(txtA1Adm_secadm_rgad.Text.Trim());
                gcrCtrF2TexBox = "CAJA";
                lobFcmForm.Owner = this;
                lobFcmForm.ShowDialog();
            }else
            {
                txtA1ConfirmarFacturas.Text = "CONFIRMAR"; // proceso sin pago con valor efectivo, se ejecuta en CanCON() Vista modelo Base
            }
        }

        //-Clic en Boton Ver registro de atencion ambulatoria
        private void fcvVerRegistroAtencion(object sender, RoutedEventArgs e)
        {
            fcvCerrarVistaNotifcaciones();
            var lcrEstado = "DFL";
            gcrCtrF2TexBox = "NA";

            if (vm.A1Adm_estfac_rgad == "1")
            {
                gcrCtrF2TexBox = "EDT-REGISTRO";
            }
            VistaRegistroAmbulatorio lobForm = new VistaRegistroAmbulatorio(lcrEstado, this.txtA1Adm_secadm_rgad.Text.Trim(), "", "", "");
            lobForm.Owner = this;
            lobForm.ShowDialog();
        }

        //-Clic en Boton Anular registro
        private void fcvAnularRegistro(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ANU");
        }

        //-Clic en Boton Cancelar
        private void fcvCancelarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("CAN");
        }

        //-Clic en Boton Eliminar registro Grilla
        private void fcvEliminarRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("DELREL");
            FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);
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
            var tmpLog = new List<LogsErrores>();
            foreach (var lobReg in vm.TmpG2LogError)
            {
                var tmpReg = new LogsErrores();

                tmpReg.Imagen = "Edt_hist_vista_anulado.png";
                tmpReg.NumeroRegistro = lobReg.NumeroRegistro;
                tmpReg.CodigoError = lobReg.CodigoError;
                tmpReg.NombreCampo = lobReg.NombreCampo;
                tmpReg.MensajeError = lobReg.MensajeError;
                tmpReg.NivelError = lobReg.NivelError;
                tmpLog.Add(tmpReg);
            }
            lobDlgLogs = new DialogVistaErrores();
            lobDlgLogs.fcvCargarVista("Vista errores", tmpLog);
            lobDlgLogs.Show();
            lobDlgLogs.fcvActivarVista();
        }
        #endregion
        private void fcvGotFocus(object sender, EventArgs e)
        {
            if (lobDlgLogs != null)
            {
                lobDlgLogs.fcvCerrarVista();
            }
        }
        #endregion
        //-------------------------------------------------
        // Mostrar Vista Confirmar desde Caja
        //-------------------------------------------------
        #region  Vista Confirmar desde Caja
        private void fcvConfirmarCaja(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true && txtA1ConfirmarFacturas.Text.Trim()=="CAJA")
                {
                    VistaTransacpagoservicios lobFcmForm = new VistaTransacpagoservicios(txtA1Adm_secadm_rgad.Text.Trim());
                    gcrCtrF2TexBox = "CAJA";
                    lobFcmForm.Owner = this;
                    lobFcmForm.ShowDialog();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvConfirmarCaja");
            }
        }
        #endregion
        //- Activar modo edicion en Vista
        #region  Activar modo edicion
        //- Activar modo edicion en la Vista
        public void fcvActivarModoEdicion(string tcrTipoEdicion)
        {
            switch (tcrTipoEdicion)
            {
                case "ADD":
                    llgModoAdicion = true;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);
                    break;

                case "CAN":
                    llgModoAdicion = false;
                    llgModoEdicion = false;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, cmdAdicionar);
                    break;

                case "SAV":
                    llgModoAdicion = false;
                    llgModoEdicion = false;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, cmdAdicionar);
                    break;

                default:
                    //- los demas metodos (ANU,CON,DEL) los cambia el
                    //- textbox que maneja el estado 
                    llgModoAdicion = false;
                    llgModoEdicion = false;
                    ActualizarModoEdicion("1");
                    FocusManager.SetFocusedElement(this, cmdAdicionar);
                    break;
            }
            ActualizarFormModoPopup(tcrTipoEdicion, "1");
        }
        #endregion
        //-----------------------------------------
        //-Actualizar Modo Edicion del formulario
        #region Actualizar Estado edicion del formulario
        //- Activar modo edicion en la Vista
        private void ActualizarModoEdicion(string tcrEstado)
        {
            try
            {

                if (llgModoEdicion == true)
                {
                    cmdAdicionar.Visibility = Visibility.Hidden;
                    cmdModificar.Visibility = Visibility.Hidden;
                    cmdGuardar.Visibility = Visibility.Visible;
                    cmdCancelar.Visibility = Visibility.Visible;
                }
                else
                {
                    cmdAdicionar.Visibility = Visibility.Visible;
                    cmdModificar.Visibility = Visibility.Visible;
                    cmdGuardar.Visibility = Visibility.Hidden;
                    cmdConfirmar.Visibility = Visibility.Hidden;
                    cmdCancelar.Visibility = Visibility.Hidden;
                }
                cmdConfirmar.Visibility = Visibility.Hidden;

                switch (tcrEstado)
                {
                    case "1":

                        if (llgConfigModoGuardar == false)
                        {
                            cmdGuardar.Visibility = Visibility.Hidden;
                            cmdConfirmar.Visibility = Visibility.Visible;
                        }
                        break;

                    case "2":
                        if (llgModoAdicion == true)
                        {
                            // se resutaura desde TextBox que maneja el estado
                            llgModoAdicion = false;
                            llgModoEdicion = false;
                            cmdAdicionar.Visibility = Visibility.Visible;
                            cmdModificar.Visibility = Visibility.Visible;
                        }
                        cmdConfirmar.Visibility = Visibility.Hidden;
                        break;

                    case "3":
                        cmdConfirmar.Visibility = Visibility.Hidden;
                        break;

                    default:
                        // se asume modo inicial vacio
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdGuardar.Visibility = Visibility.Visible;
                        if (llgConfigModoGuardar == false)
                        {
                            cmdGuardar.Visibility = Visibility.Hidden;
                            cmdConfirmar.Visibility = Visibility.Visible;
                        }
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarModoEdicion");
            }
        }
        #endregion
        //-----------------------------------------
        //- ActualizarFormModoPopup: Actualizar Modo Edicion Popup
        //-----------------------------------------
        #region ActualizarFormModoPopup: Actualizar Modo Edicion Popup
        private void ActualizarFormModoPopup(String tcrTipoEdicion, String tcrEstado)
        {
            try
            {
                if (lcrFormModoPopup == "ADD" || lcrFormModoPopup == "EDT")
                {

                    cmdAdicionar.Visibility = Visibility.Hidden;
                    cmdModificar.Visibility = Visibility.Hidden;
                    cmdGuardar.Visibility = Visibility.Visible;
                    cmdCancelar.Visibility = Visibility.Visible;
                    cmdConfirmar.Visibility = Visibility.Hidden;
                    cmdBrowser.Visibility = Visibility.Hidden;
                    cmdConfiguracion.Visibility = Visibility.Hidden;

                    if (llgConfigModoGuardar == false)
                    {
                        cmdGuardar.Visibility = Visibility.Hidden;
                        cmdConfirmar.Visibility = Visibility.Visible;
                    }

                    if (tcrTipoEdicion == "CAN" && lcrFormModoPopup == "ADD")
                    {
                        this.Close();
                    }
                    if (tcrTipoEdicion == "CAN" && lcrFormModoPopup == "EDT")
                    {
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                        cmdConfirmar.Visibility = Visibility.Hidden;
                    }
                    if (tcrTipoEdicion == "EDT" && llgModoEdicion == false)
                    {
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                        cmdConfirmar.Visibility = Visibility.Hidden;
                    }
                    if (tcrTipoEdicion == "SAV")
                    {
                        lcrFormModoPopup = "EDT";
                        cmdModificar.Visibility = Visibility.Visible;
                        cmdCancelar.Visibility = Visibility.Hidden;
                        cmdGuardar.Visibility = Visibility.Hidden;
                        cmdConfirmar.Visibility = Visibility.Hidden;
                    }

                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarFormModoPopup");
            }
        }
        #endregion
        #region Actualizar Estado edicion desde TextBox Estado
        void ActualizarEdtDesdeTextBoxEstado(object sender, TextChangedEventArgs e)
        {
            try
            {

                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    ActualizarModoEdicion(lobTexto.Text);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarEdtDesdeTextBoxEstado");
            }
        }
        #endregion
        //- Configuracion modo Edicion Guardar o Confirmar
        #region Modo Guardar (por defecto) o  Confirmar
        public void fcvConfigModoGuardar(object sender, RoutedEventArgs e)
        {
            llgConfigModoGuardar = true;
        }
        //- Configuracion modo Confirmar
        public void fcvConfigModoConfirmar(object sender, RoutedEventArgs e)
        {
            llgConfigModoGuardar = false;
        }
        #endregion
        //-------------------------------------------------
        // Eventos Auxiliares
        //-------------------------------------------------
        #region Eventos Auxiliares
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnCerrar_KeyDown(object sender, MouseEventArgs e)
        {
            fcvFinalizarInstanciaDatos();
            fcvLiberarVistaNotificaciones();
            gdspTimerSistema.Stop();

            this.Close();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            this.lobCrtNotifi.fcvFinalizarEventos();
            fcvFinalizarInstanciaDatos();
            fcvLiberarVistaNotificaciones();
            this.Close();
        }
        private void fcvFinalizarInstanciaDatos()
        {
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloOrdenesmedicas();
            // Quitar referencias
            dpkG2Fcm_fecser_dfac.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Fcm_fecfac_mfac.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
        }
        #endregion
        //------------------------------------------------------------
        // ACTIVAR PROPIEDADES DESDE VENTANA PROPIEDADES
        //------------------------------------------------------------
        #region Activar Propiedades del registro activo
        #region fcvSetObjActualizarPropiedades: Actualizar datos adicionales del Registro de atención medica
        /// <summary>
        /// Actualizar datos adicionales del Registro de atención medica
        /// </summary>
        private void fcvSetObjActualizarPropiedades(object sender, TextChangedEventArgs e)
        {
            fcvSetObjActualizarObjetos();
        }
        #endregion
        #region fcvSetObjActualizarObjetos: Actualizar datos en vista propiedades del registro
        /// <summary>
        /// Actualizar datos en vista propiedades del registro
        /// </summary>
        private void fcvSetObjActualizarObjetos()
        {
            if (String.IsNullOrWhiteSpace(this.txtB1Sia_nomusu_usua.Text))
            {
                this.lblAdmision.Text="ADMISION:";
            }
            else 
            {
                this.lblAdmision.Text = "ADMISION: " + vm.A1Adm_secadm_rgad + " - " + vm.A1Adm_fecadm_rgad + "  " + vm.A1Adm_horadm_rgad;
            }
            fcvSetObjActualizarObjEstados();
        }
        #endregion
        #region fcvSetObjActualizarObjEstados: Actualizar vista estados del registro
        /// <summary>
        /// Actualizar vista estados del registro
        /// </summary>
        private void fcvSetObjActualizarObjEstados()
        {
            var lcrEstadoAdmisionTexto    = "Estado registro atención";
            var lcrEstadoFacturacionTexto = "Estado procesos facturación";
            var lcrEstadoAtencionMedica   = "Estado atención medica";
            var lcrEstadoAutorizaSalida   = "Estado autorizacion salida";
            var lcrEstadoCompletarRips    = "Estado Rips";

            var lcrImgEstadoAdmision       = "Emt_estados_valid09.png";
            var lcrImgEstadoFacturacion    = "Emt_estados_valid09.png";
            var lcrImgEstadoAtencionMedica = "Emt_estados_valid09.png";
            var lcrImgEstadoAutorizaSalida = "Emt_estados_valid09.png";
            var lcrImgEstadoCompletarRips  = "Emt_estados_valid09.png";

            var lcrUri = "/Sistema;component/Imagenes/";

            // A1Sis_estpro_espr - Estado registro atención 
            #region A1Sis_estpro_espr - Estado registro atención 
            if (vm.A1Sis_estpro_espr == "3")
            {
                lcrImgEstadoAdmision = "Emt_estados_valid13.png";
                lcrEstadoAdmisionTexto = "Registro de atención anulado";
            }
            else if (vm.A1Sis_estpro_espr == "2")
            {
                lcrImgEstadoAdmision = "Emt_estados_valid12.png";
                lcrEstadoAdmisionTexto = "Registro de atención confirmado";
            }
            this.imgEstadoAdmision.Source = new BitmapImage(new Uri(lcrUri + lcrImgEstadoAdmision, UriKind.RelativeOrAbsolute));
            this.txtEstadoAdmision.Text = lcrEstadoAdmisionTexto;
            #endregion
            // A1Adm_estfac_rgad - Estado Facturación
            #region A1Adm_estfac_rgad - Estado Facturación
            if (vm.A1Adm_estfac_rgad == "1")
            {
                lcrImgEstadoFacturacion   = "Emt_estados_valid10.png";
                lcrEstadoFacturacionTexto = "Gestión facturación abierta";
            }
            else if (vm.A1Adm_estfac_rgad == "2")
            {
                lcrImgEstadoFacturacion = "Emt_estados_valid12.png";
                lcrEstadoFacturacionTexto = "Facturación finalizada";
            }
            else if (vm.A1Adm_estfac_rgad == "3")
            {
                lcrImgEstadoFacturacion = "Emt_estados_valid13.png";
                lcrEstadoFacturacionTexto = "Facturación anulada";
            }
            this.imgEstadoFacturacion.Source = new BitmapImage(new Uri(lcrUri + lcrImgEstadoFacturacion, UriKind.RelativeOrAbsolute));
            this.txtEstadoFacturacion.Text = lcrEstadoFacturacionTexto;
            #endregion
            // A1Adm_estrad_rgad - Estado a
            #region A1Adm_estrad_rgad - Estado atención profesional medico
            if (vm.A1Adm_estrad_rgad == "1")
            {
                if (vm.A1Sia_regate_rgat == "2") // Para atencion ambulatoria
                {
                    if (vm.A1Adm_fecadm_rgad == Funciones.fcrFechaActual())
                    {
                        lcrImgEstadoAtencionMedica = "Emt_estados_valid06.png";
                        lcrEstadoAtencionMedica = "Atención ambulatoria en proceso";
                    }
                    else
                    {
                        lcrImgEstadoAtencionMedica = "Emt_estados_valid05.png";
                        lcrEstadoAtencionMedica = "Atención ambulatoria no finalizada";
                    }
                }
                else
                {
                    lcrImgEstadoAtencionMedica = "Emt_estados_valid06.png";
                    lcrEstadoAtencionMedica = "Atención medica admitido en proceso";
                }
            }
            else if (vm.A1Adm_estrad_rgad == "2")
            {
                lcrImgEstadoAtencionMedica = "Emt_estados_valid12.png";
                lcrEstadoAtencionMedica = "Atención por profesional finalizada";
            }
            this.imgEstadoAtenMedica.Source = new BitmapImage(new Uri(lcrUri + lcrImgEstadoAtencionMedica, UriKind.RelativeOrAbsolute));
            this.txtEstadoAtenMedica.Text = lcrEstadoAtencionMedica;
            #endregion
            // A1Adm_finate_rgad - Finalizada atencion medica y egreso a casa
            #region A1Adm_finate_rgad - Egreso hospitalario y salida a casa
            if (vm.A1Sia_regate_rgat == "2") // Para atencion ambulatoria
            {
                lcrEstadoAutorizaSalida = String.Empty;
            }
            else
            {
                if (vm.A1Adm_finate_rgad == "1")
                {
                    lcrImgEstadoAutorizaSalida = "Emt_estados_valid06.png";
                    lcrEstadoAutorizaSalida = "No hay egreso hospitalario aun";
                }
                else
                {
                    lcrImgEstadoAutorizaSalida = "Emt_estados_valid12.png";
                    lcrEstadoAutorizaSalida = "Egreso hospitalario fue realizado";
                }
            }
            if (String.IsNullOrWhiteSpace(lcrEstadoAutorizaSalida))
            {
                this.imgEstadoAutoriSalida.Visibility = Visibility.Collapsed;
                this.txtEstadoAutoriSalida.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.imgEstadoAutoriSalida.Visibility = Visibility.Visible;
                this.txtEstadoAutoriSalida.Visibility = Visibility.Visible;
                this.imgEstadoAutoriSalida.Source = new BitmapImage(new Uri(lcrUri + lcrImgEstadoAutorizaSalida, UriKind.RelativeOrAbsolute));
                this.txtEstadoAutoriSalida.Text = lcrEstadoAutorizaSalida;
            }
            #endregion
            // A1Adm_ctarip_rgad - Completar Rips
            #region A1Adm_ctarip_rgad - Completar Rips
            if (vm.A1Adm_finate_rgad == "1") // cuando la atencion medica aun esta abierta
            {
                if (vm.A1Adm_ctarip_rgad == "1" || vm.A1Adm_ctarip_rgad == "3")
                {
                    lcrImgEstadoCompletarRips = "Emt_estados_valid11.png";
                    lcrEstadoCompletarRips = "Gestión Rips optima";
                }
                else
                {
                    lcrImgEstadoCompletarRips = "Emt_estados_valid08.png";
                    lcrEstadoCompletarRips = "Hay registros Rips sin completar";
                }
            }
            else
            {
                if (vm.A1Adm_ctarip_rgad == "1" || vm.A1Adm_ctarip_rgad == "3")
                {
                    lcrImgEstadoCompletarRips = "Emt_estados_valid12.png";
                    lcrEstadoCompletarRips = "Gestion Rips completada";
                }
                else
                {
                    lcrImgEstadoCompletarRips = "Emt_estados_valid13.png";
                    lcrEstadoCompletarRips = "Errores Rips sin completar";
                }
            }
            this.imgEstadoRips.Source = new BitmapImage(new Uri(lcrUri + lcrImgEstadoCompletarRips, UriKind.RelativeOrAbsolute));
            this.txtEstadRips.Text = lcrEstadoCompletarRips;
            #endregion
        }
        #endregion
        // Activar la pestaña segun el tipo de RIPS
        #region Activar la pestaña segun el tipo de RIPS
        private void fcvActivarVistaTabsRips(object sender, TextChangedEventArgs e)
        {
            //var lcrNombreTab = "pagTABS2";

            // Ocultar todas 
            this.pagTABS2.Visibility = Visibility.Collapsed;
            this.pagTABS3.Visibility = Visibility.Collapsed;
            this.pagTABS4.Visibility = Visibility.Collapsed;

            if (txtG2Sia_codrip_trip.Text.Trim() == "01") // Consultas
            {
                this.pagTABS2.Visibility = Visibility.Visible;
            }
            else if (txtG2Sia_codrip_trip.Text.Trim() == "02" ||
                     txtG2Sia_codrip_trip.Text.Trim() == "03" ||
                     txtG2Sia_codrip_trip.Text.Trim() == "04" ||
                     txtG2Sia_codrip_trip.Text.Trim() == "05") // Procedimientos
            {
                this.pagTABS3.Visibility = Visibility.Visible;
            }
            else if (txtG2Sia_codrip_trip.Text.Trim() == "12" ||
                     txtG2Sia_codrip_trip.Text.Trim() == "13") // Medicamentos POS y NO POS
            {
                this.pagTABS4.Visibility = Visibility.Visible;
            }
            else // Otros servicios (Honorarios, Estancias, Bancos de Sangre, Traslados y otros)
            {
            }
            //pagG2Rips.SelectedItem = (TabItem)pagG2Rips.FindName(lcrNombreTab);
        }
        #endregion
        // Activar datos de gestion en cada factura
        #region Activar datos de gestion en cada factura
        private void fcvActivarDatosFactura(object sender, TextChangedEventArgs e)
        {
            var lcrColorEstado = "#FFF7970F";

            if (llgObjetosCargados == true)
            {
                if (!String.IsNullOrWhiteSpace(vm.G1Fcm_desfac_mfac))
                {
                    lcrColorEstado = vm.G2Fcm_estfac_mfac == "1" ? "#FFF7970F" : vm.G2Fcm_estfac_mfac == "2" ? " #FF60F760" : "#FFFF1313";
                }
            }
            // color segun estado factura
            this.txtG1Fcm_desfac_mfac.Background = SetSolidColorBrush(lcrColorEstado);
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // CAMBIAR COLOR DE OBJETOS
        //-------------------------------------------------
        #region SetSolidColorBrush
        /// <summary>
        /// <para>Convertir propiedad de tipo texto a SolidColorBrush</para>
        /// </summary>
        public static SolidColorBrush SetSolidColorBrush(String tcrValor)
        {
            var lsbColor = Brushes.Black;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    lsbColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(tcrValor));
                }
            }
            return lsbColor;
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
                        case "txtG2Sia_codfco_fcon":
                            CrtForms.ListaComboBox lobG2ComboBox2 = (CrtForms.ListaComboBox)cboG2Sia_codfco_fcon.SelectedItem;
                            cboG2Sia_codfco_fcon.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox2.ListaValoresSel);
                            break;
                        case "txtG2Adm_codcex_tcex":
                            CrtForms.ListaComboBox lobG2ComboBox3 = (CrtForms.ListaComboBox)cboG2Adm_codcex_tcex.SelectedItem;
                            cboG2Adm_codcex_tcex.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox3.ListaValoresSel);
                            break;
                        case "txtG2Fcm_codtse_sips":
                            CrtForms.ListaComboBox lobG2ComboBox4 = (CrtForms.ListaComboBox)cboG2Fcm_codtse_sips.SelectedItem;
                            cboG2Fcm_codtse_sips.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox4.ListaValoresSel);
                            break;
                        case "txtG2Sia_codfpr_fpor":
                            CrtForms.ListaComboBox lobG2ComboBox5 = (CrtForms.ListaComboBox)cboG2Sia_codfpr_fpor.SelectedItem;
                            cboG2Sia_codfpr_fpor.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox5.ListaValoresSel);
                            break;
                        case "txtG2Sia_tipdxp_tdix":
                            CrtForms.ListaComboBox lobG2ComboBox6 = (CrtForms.ListaComboBox)cboG2Sia_tipdxp_tdix.SelectedItem;
                            cboG2Sia_tipdxp_tdix.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox6.ListaValoresSel);
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
                        case "cboG2Sia_codfco_fcon":
                            txtG2Sia_codfco_fcon.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Sia_codfco_fcon.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Sia_codfco_fcon.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Adm_codcex_tcex":
                            txtG2Adm_codcex_tcex.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Adm_codcex_tcex.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Adm_codcex_tcex.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Fcm_codtse_sips":
                            txtG2Fcm_codtse_sips.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Fcm_codtse_sips.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Fcm_codtse_sips.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG2Sia_codfpr_fpor":
                            txtG2Sia_codfpr_fpor.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Sia_codfpr_fpor.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Sia_codfpr_fpor.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG2Sia_tipdxp_tdix":
                            txtG2Sia_tipdxp_tdix.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG2Sia_tipdxp_tdix.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG2Sia_tipdxp_tdix.Text, ",", lobList.ListaValoresSel);
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
        //  INotificacion Y Browser recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {

                case "ADD-REGISTRO":
                    if (tcrCodigo != "NA" && !String.IsNullOrWhiteSpace(tcrCodigo))
                    {
                        //txtA1ConfirmarFacturas.Text = "CARGAR"; // se confirmo datos, retomar los valores actualizados
                        vm.gcrFiltroAplicado = tcrCodigo;
                        vm.GcrFiltroDatos = tcrCodigo;
                        vm.fcvFiltro();
                        this.txtA1Adm_secadm_rgad.Text = tcrCodigo;
                        Thread.Sleep(200);
                        if (String.IsNullOrWhiteSpace(vm.A1Sia_nomusu_usua) == true)
                        {
                            vm.fcvFiltro();
                        }

                        fcvActivarModoEdicion("EDT");
                        vm.Modificar();
                        FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);
                    }
                    else
                    {
                        vm.Cancelar();
                    }
                    break;

                case "EDT-REGISTRO":
                    if (tcrCodigo != "NA" && !String.IsNullOrWhiteSpace(tcrCodigo))
                    {
                        vm.gcrFiltroAplicado = tcrCodigo;
                        vm.GcrFiltroDatos = tcrCodigo;
                        vm.fcvFiltro();
                        this.txtA1Adm_secadm_rgad.Text = tcrCodigo;
                    }
                    break;

                case "CAJA":
                    if (!String.IsNullOrWhiteSpace(tcrCodigo))
                    {
                        txtA1ConfirmarFacturas.Text = "CARGAR"; // se confirmo datos, retomar los valores actualizados
                    }
                    else
                    {
                        txtA1ConfirmarFacturas.Text = "DEFAULT"; // no se confirmo nada en caja, todo sigue igual
                    }
                    break;

                case "txtA1Adm_secadm_rgad":
                    txtA1Adm_secadm_rgad.Text = tcrCodigo;
                    break;

                case "txtA1Cto_nrocon_cont":
                    txtA1Cto_nrocon_cont.Text = tcrCodigo;
                    break;

                case "txtA1Sia_idesec_usua":
                    txtA1Sia_idesec_usua.Text = tcrCodigo;
                    break;

                case "txtA1Sia_tipide_tide":
                    txtA1Sia_tipide_tide.Text = tcrCodigo;
                    break;

                case "txtA1Adm_codtat_tatn":
                    txtA1Adm_codtat_tatn.Text = tcrCodigo;
                    break;

                case "txtA1Sia_codeps_teps":
                    txtA1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtA1Sia_tipusu_regi":
                    txtA1Sia_tipusu_regi.Text = tcrCodigo;
                    break;

                case "txtA1Sia_nroide_usua":
                    txtA1Sia_nroide_usua.Text = tcrCodigo;
                    break;

                case "txtG2Sia_aresol_aser":
                    txtG2Sia_aresol_aser.Text = tcrCodigo;
                    break;

                case "txtG2Cto_seccon_cont":
                    txtG2Cto_seccon_cont.Text = tcrCodigo;
                    break;

                case "txtG2Sia_codeps_teps":
                    txtG2Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_codcpr_cpro":
                    txtG2Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_codman_mans":
                    txtG2Fcm_codman_mans.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_codaqx_aqir":
                    txtG2Fcm_codaqx_aqir.Text = tcrCodigo;
                    break;

                case "txtG2Sia_tipact_tsac":
                    txtG2Sia_tipact_tsac.Text = tcrCodigo;
                    break;

                case "txtG2Sia_codpfa_prof":
                    txtG2Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG2Sia_codare_aser":
                    txtG2Sia_codare_aser.Text = tcrCodigo;
                    break;

                case "txtG2Fcm_coddig_mant":
                    txtG2Fcm_coddig_mant.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        #region INotificacion: Interface para devolver id registro notificacion
        /// <summary>
        /// <para>Devolver id registro notificacion, modulo y tipo Notificacion</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrIdRegNotificacion: Id registro unico en maestro de notificaciones</para>
        /// <para>tcrIdModulo: Módulo al cual se envia notificación:  MSG = Mensajes general SYS: = Grupos mensajes de sistema FCM =Facturacion</para>
        /// <para>tcrTipoNotificacion: Tipo de notificacion: ADM001 = Registro de admisión FCM001 = Autorizacion descuento en caja facturacion</para>
        /// <para>tcrRegEvento: Registro evento que genera la notificacion: puede ser Id del paciente, Numero H.Clinica, Numero admision y otros.</para>
        /// </summary>
        public void fcvINotificacion(String tcrIdRegNotificacion, String tcrIdModulo, String tcrTipoNotificacion, String tcrRegEvento)
        {
            String[] larArray = null;
            if (vm.GlgSIS_ModoEdicion == false)
            {
                switch (tcrTipoNotificacion)
                {
                    case "ADM-ADMI-URGENCIAS":
                        // Adimision urgencias
                        this.txtA1Adm_secadm_rgad.Text = tcrRegEvento;
                        break;

                    case "ADM-ADMI-HOSPITALIZ":
                        // Adimision Hospitalizacion
                        this.txtA1Adm_secadm_rgad.Text = tcrRegEvento;
                        break;

                    case "HOS-HOJA-CONSUMO":
                        // hoja de consumo viene: RegistroAdmision*RegistroHojaConsumo
                        larArray = tcrRegEvento.Split('*');
                        this.txtA1Adm_secadm_rgad.Text = larArray[0];
                        break;

                    case "CEX-FORMULA-MEDICA":
                        // Formula medica 
                        larArray = tcrRegEvento.Split('*');
                        this.txtA1Adm_secadm_rgad.Text = larArray[0];
                        break;

                    case "HOS-AUTORI-SALIDA-F":
                        // Regitro autorizacion salida
                        larArray = tcrRegEvento.Split('*');
                        this.txtA1Adm_secadm_rgad.Text = larArray[0];
                        break;

                    case "ODN-REG-ACTIV-TRATAM":
                        // Regitro Actividades evolucion odontologia
                        larArray = tcrRegEvento.Split('*');
                        this.txtA1Adm_secadm_rgad.Text = larArray[0];
                        break;
                }
            }

        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // ADMREGADMISION : Admision de pacientes
        #region KeyDown para campos con F2 Tabla: ADMREGADMISION
        #region CTO_NROCON_CONT : Maestro contratos con  EPS o aseguradores
        private void txtA1Cto_nrocon_cont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("CTO", "CTOMAESCONTRATO", "", "Maestro contratos con  EPS o aseguradores...");
                gcrCtrF2TexBox = "txtA1Cto_nrocon_cont";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_IDESEC_USUA : Maestro de Pacientes atendidos
        private void txtA1Sia_idesec_usua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATEND", "", "Maestro de Pacientes atendidos...");
                gcrCtrF2TexBox = "txtA1Sia_idesec_usua";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_TIPIDE_TIDE : Configuracion para los tipos de identificacion de los uauari
        private void txtA1Sia_tipide_tide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIATIPIDEUSARIO", "", "Configuracion para los tipos de identificacion de los uauari...");
                gcrCtrF2TexBox = "txtA1Sia_tipide_tide";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region CIT_CODASI_MCIT : Asignación de citas a Pacientes
        private void txtA1Cit_codasi_mcit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("CIT", "CITMAESASIGCITA", "", "Asignación de citas a Pacientes...");
                gcrCtrF2TexBox = "txtA1Cit_codasi_mcit";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region ADM_CODTAT_TATN : Ambito de atención paciente
        private void txtA1Adm_codtat_tatn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("ADM", "ADMTIPOATENCION", "", "Ambito de atención paciente...");
                gcrCtrF2TexBox = "txtA1Adm_codtat_tatn";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region CTO_SECCON_CONT : Maestro contratos con  EPS o aseguradores
        private void txtA1Cto_seccon_cont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("CTO", "CTOMAESCONTRATO", "", "Maestro contratos con  EPS o aseguradores...");
                gcrCtrF2TexBox = "txtA1Cto_seccon_cont";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODEPS_TEPS : Lista de EPS o seguradores
        private void txtA1Sia_codeps_teps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIATABLAEPS", "", "Lista de EPS o seguradores...");
                gcrCtrF2TexBox = "txtA1Sia_codeps_teps";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_TIPUSU_REGI : Lista de Régimenes en Salud
        private void txtA1Sia_tipusu_regi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAREGIMENSALUD", "", "Lista de Régimenes en Salud...");
                gcrCtrF2TexBox = "txtA1Sia_tipusu_regi";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_NIVSBN_NSBN : Codigo Nivel Sisben para cobro de copagos  según Resolución:
        private void txtA1Sia_nivsbn_nsbn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIANIVELSISBEN", "", "Codigo Nivel Sisben para cobro de copagos  según Resolución:...");
                gcrCtrF2TexBox = "txtA1Sia_nivsbn_nsbn";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_NIVCON_NCON : Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y
        private void txtA1Sia_nivcon_ncon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIANIVCONTRIBUT", "", "Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y ...");
                gcrCtrF2TexBox = "txtA1Sia_nivcon_ncon";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIS_ESTPRO_ESPR : Estados de procesos (Abierto, Cerrado,Anulado)
        private void txtA1Sis_estpro_espr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIS", "SISESTADOPROCES", "", "Estados de procesos (Abierto, Cerrado,Anulado)...");
                gcrCtrF2TexBox = "txtA1Sis_estpro_espr";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_NROIDE_USUA : Maestro de Pacientes atendidos
        private void txtA1Sia_nroide_usua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATEND", "", "Maestro de Pacientes atendidos...");
                gcrCtrF2TexBox = "txtA1Sia_nroide_usua";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #endregion
        // FCMMAEDETALLFAC : Detalles servicios medicos prestados
        #region KeyDown para campos con F2 Tabla: FCMMAEDETALLFAC
        #region SIA_ARESOL_ASER : Areas prestacion de servicios
        private void txtG2Sia_aresol_aser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAAREAPRESERVI", "", "Areas prestacion de servicios...");
                gcrCtrF2TexBox = "txtG2Sia_aresol_aser";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region CTO_SECCON_CONT : Maestro contratos con  EPS o aseguradores
        private void txtG2Cto_seccon_cont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("CTO", "CTOMAESCONTRATO", "", "Maestro contratos con  EPS o aseguradores...");
                gcrCtrF2TexBox = "txtG2Cto_seccon_cont";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODEPS_TEPS : Lista de EPS o seguradores
        private void txtG2Sia_codeps_teps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIATABLAEPS", "", "Lista de EPS o seguradores...");
                gcrCtrF2TexBox = "txtG2Sia_codeps_teps";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region FCM_CODCPR_CPRO : Centros de produccion asistenciales
        private void txtG2Fcm_codcpr_cpro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("FCM", "FCMCENPRODUCCIO", "", "Centros de produccion asistenciales...");
                gcrCtrF2TexBox = "txtG2Fcm_codcpr_cpro";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region FCM_CODMAN_MANS : Lista de manuales tarifarios
        private void txtG2Fcm_codman_mans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("FCM", "FCMMANTARIFARIO", "", "Lista de manuales tarifarios...");
                gcrCtrF2TexBox = "txtG2Fcm_codman_mans";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region FCM_CODAQX_AQIR : Forma de realizacion acto quirurgico
        private void txtG2Fcm_codaqx_aqir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("FCM", "FCMACTQUIRURGIC", "", "Forma de realizacion acto quirurgico...");
                gcrCtrF2TexBox = "txtG2Fcm_codaqx_aqir";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_TIPACT_TSAC : Tipo de servicio o actividad
        private void txtG2Sia_tipact_tsac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIATIPACTIVIDAD", "", "Tipo de servicio o actividad...");
                gcrCtrF2TexBox = "txtG2Sia_tipact_tsac";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODPFA_PROF : Profesionales que prestan servicios
        private void txtG2Sia_codpfa_prof_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
                gcrCtrF2TexBox = "txtG2Sia_codpfa_prof";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODARE_ASER : Areas prestacion de servicios
        private void txtG2Sia_codare_aser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAAREAPRESERVI", "", "Areas prestacion de servicios...");
                gcrCtrF2TexBox = "txtG2Sia_codare_aser";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region FCM_CODDIG_MANT : Manual ventas de servicios medicos
        private void txtG2Fcm_coddig_mant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                G2Fcm_coddig_mantBrowser();
            }
        }
        private void G2Fcm_coddig_mantBrowser()
        {
            var lcrTitulo = "Manual ventas de servicios medicos: " + this.txtG2Fcm_desman_mans.Text + "...";
            var lcrFiltro = "Fcmmanservicios.fcm_codman_mans='" + this.txtG2Fcm_codman_mans.Text.Trim() + "'";
            gcrCtrF2TexBox = "txtG2Fcm_coddig_mant";

            if (vm.G2Cto_serper_cont == "2")
            {
                lcrTitulo = "Servicios médicos Personalizados...";
                lcrFiltro = "Ctomanservicios.cto_seccon_cont='" + this.txtG2Cto_seccon_cont.Text.Trim() + "'";
                Browser01 frbro = new Browser01("CTO", "CTOMANSERVICIOS", lcrFiltro, lcrTitulo);
                frbro.Owner = this;
                frbro.ShowDialog();
            }
            else
            {
                Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIOSIU", lcrFiltro, lcrTitulo);
                frbro.Owner = this;
                frbro.ShowDialog();
           }
        }
        #endregion
        #endregion
        #region Metodo Buscar despues de F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            var lcrFiltro = String.Empty;
            MenuItem lobOp = (MenuItem)sender;
            switch (lobOp.Name)
            {
                case "opTodos":
                    lcrFiltro = "TODOS*TODOS";
                    break;

                case "opAdmitidos":
                    lcrFiltro = "ADMITIDOS*2";
                    break;

                case "opCerrado":
                    lcrFiltro = "TODOS*2";
                    break;

                case "opAnulado":
                    lcrFiltro = "TODOS*3";
                    break;
            }
            if (lobOp.Name == "opFactAviertas")
            {
                var frbro = new Sistema.Vista.FacturacionFacAbiertas();
                gcrCtrF2TexBox = "txtA1Adm_secadm_rgad";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
            else if (lobOp.Name != "opFacturas")
            {
                Browser02 frbro = new Browser02("ADM", "ADMREGADMISION", 1, lcrFiltro, "Admisión de pacientes...");
                gcrCtrF2TexBox = "txtA1Adm_secadm_rgad";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
            else
            {
                if (lcrFiltro != "ADMITIDOS*2")
                {
                    lcrFiltro = "TODOS*TODOS";
                }

                Browser02 frbro = new Browser02("ADM", "ADMVISTAFACTURAS", 1, lcrFiltro, "Vista facturas...");
                gcrCtrF2TexBox = "txtA1Adm_secadm_rgad";
                frbro.Owner = this;
                frbro.ShowDialog();
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
                    case "dpkA1Adm_fecadm_rgad":
                        txtA1Adm_fecadm_rgad.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtA1Adm_fecadm_rgad);
                        break;
                    case "dpkG2Fcm_fecser_dfac":
                        txtG2Fcm_fecser_dfac.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG2Fcm_fecser_dfac);
                        break;

                    case "dpkG1Fcm_fecfac_mfac":
                        txtG1Fcm_fecfac_mfac.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Fcm_fecfac_mfac);
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
                            case "txtG2Fcm_fecser_dfac":
                                dpkG2Fcm_fecser_dfac.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtG1Fcm_fecfac_mfac":
                                dpkG1Fcm_fecfac_mfac.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        // Imprimir factura 
        //-------------------------------------------------
        #region fcvImprimirFactura Imprimir factura
        /// <summary>
        /// tlgVistaPrevia: true= Mostrar vista previa del reporte false= No mostrar vista previa
        /// </summary>
        /// 
        private void fcvImprimirFactura(bool tlgVistaPrevia)
        {
            var lobPrnFactura = new FCMImprimir
            {
                gcrRazonSocialTipoId = "ID",
                gcrRazonSocialCodigo = vm.TmpG1RegActivo.Fcm_secraz_fcem,
                gcrCodigoAdmision    = this.txtA1Adm_secadm_rgad.Text.Trim(),
                gcrTipoRegistro      = "FACTURA",
                gcrTextoCodigoQr     = gcrTextoCodigoQr
            };
            lobPrnFactura.fcvEjecutar();
        }
        #endregion
        //-------------------------------------------------
        // Imprimir recibo de caja
        //-------------------------------------------------
        #region fcvImprimirReciboCaja Imprimir recibo de caja
        /// <summary>
        /// tlgVistaPrevia: true= Mostrar vista previa del reporte false= No mostrar vista previa
        /// </summary>
        /// 
        private void fcvImprimirReciboCaja(bool tlgVistaPrevia)
        {
            var lobPrnReciboCaja = new FCMImprimir
            {
                gcrRazonSocialTipoId = "ID",
                gcrRazonSocialCodigo = vm.TmpG1RegActivo.Fcm_secraz_fcem,
                gcrCodigoAdmision    = this.txtA1Adm_secadm_rgad.Text.Trim(),
                gcrTipoRegistro      = "RECIBOCAJA"
            };
            lobPrnReciboCaja.fcvEjecutar();
        }
        #endregion
        //-------------------------------------------------
        // Vista Capa Propiedades Registro de Atencion
        //-------------------------------------------------
        #region Ventana Propiedades Reg Atencion
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaPropiedades(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaPropiedad();
        }
        #endregion
        #region fcvActivarVistaPropiedadMouseEnter: Mostrar Ventana Historial del paciente gesto en la izquierda
        /// <summary>
        /// <para>Mostrar Ventana Historial del paciente con gesto en la izquierda de la pantalla</para>
        /// </summary>
        private void fcvActivarVistaPropiedadMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedad();
            }
        }
        #endregion
        #region fcvActivarVistaPropiedadTouchEnter: Mostrar Ventana Historial del paciente gesto en la izquierda
        /// <summary>
        /// <para>Mostrar Ventana Historial del paciente con gesto en la izquierda de la pantalla</para>
        /// </summary>
        private void fcvActivarVistaPropiedadTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedad();
            }
        }
        #endregion
        #region fcvActivarVistaHistorial: Mostrar u Ocultar la Ventana Historial del paciente
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Historial del paciente</para>
        /// </summary>
        private void fcvActivarVistaPropiedad()
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropiedades == false)
            {
                luxAnimacion.To = 5; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                //glgVistaHistorialAnclada = false;
                glgVistaPropiedades = true;
            }
            else
            {
                luxAnimacion.To = -630; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropiedades = false;
            }
            this.grdPropiedadZona1.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion

        #endregion
        //-------------------------------------------------
        // Gestion Dian
        //-------------------------------------------------
        // Consultar Documentos en Dian
        #region Consulas documentos Dian
        #region FcvConsultaEstadoValidacion_Click: Estado validación del Documento
        /// <summary>
        /// Estado validación del Documento
        /// </summary>
        public void FcvConsultaEstadoValidacion_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Consultar estado validación del Documento?", "Confirmación",
                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Thread.Sleep(1000);
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Consultando estado Validación en DIAN...", "CENTRO");
                lobDlgAdd.Owner = this;
                lobDlgAdd.Show();

                //XmlDocument lobRespuestaXml;
                Empresa.FcvCargarRazonSocial("ID", vm.TmpG1RegActivo.Fcm_secraz_fcem);

                if (!FlgConsultarGetStatusZip(txtG1ProFcm_trakid_mfac.Text.Trim(), out string tcrMensaje, out XmlDocument lobRespuestaXml))
                {
                    lobDlgAdd.Close();
                    MessageBox.Show(tcrMensaje, "Error Solicitud estado Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    lobDlgAdd.Close();
                    FcvActualizarDatosYVista(lobRespuestaXml, "NA","Estado validación documento en DIAN");
                }
            }
        }
        #endregion FcvConsultaEstadoValidacion_Click
        #region FcvConsultaRadicadoDian_Click: consultar radicación del Documento (Response)
        /// <summary>
        /// Consultar radicación del Documento (Response)
        /// </summary>
        public void FcvConsultaRadicadoDian_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Consultar radicación del Documento (Response)?", "Confirmación",
                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Thread.Sleep(1000);
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Consultando documento en DIAN...", "CENTRO");
                lobDlgAdd.Owner = this;
                lobDlgAdd.Show();

                Empresa.FcvCargarRazonSocial("ID", vm.TmpG1RegActivo.Fcm_secraz_fcem);
                //XmlDocument respuestaXml;

                if (!FlgConsultarGetStatusDocumento(txtG1ProFcm_idcufe_mfac.Text.Trim(), out string tcrMensaje, out XmlDocument lobRespuestaXml))
                {
                    lobDlgAdd.Close();
                    MessageBox.Show(tcrMensaje, "Error en Solicitud Radicado a DIAN", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    lobDlgAdd.Close();
                    FcvActualizarDatosYVista(lobRespuestaXml, "b:XmlBase64Bytes", "XML Respuesta resultado validación (response) DIAN");
                }
            }
        }
        #endregion FcvConsultaRadicadoDian_Click
        #region FcvConsultaXMLRadicadoDian_Click: Consultar XML del Documento Radicado en DIAN
        /// <summary>
        /// Consultar XML del Documento Radicado en DIAN
        /// </summary>
        public void FcvConsultaXMLRadicadoDian_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Consultar XML del Documento radicado en DIAN?", "Confirmación",
                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //Thread.Sleep(1000);
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Consultando documento en DIAN...", "CENTRO");
                lobDlgAdd.Owner = this;
                lobDlgAdd.Show();

                Empresa.FcvCargarRazonSocial("ID", vm.TmpG1RegActivo.Fcm_secraz_fcem);
                //XmlDocument respuestaXml;

                if (!FlgConsultarGetXmlByDocumentKey(txtG1ProFcm_idcufe_mfac.Text.Trim(), out string tcrMensaje, out XmlDocument lobRespuestaXml))
                {
                    lobDlgAdd.Close();
                    MessageBox.Show(tcrMensaje, "Error en Solicitud Radicado a DIAN", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    lobDlgAdd.Close();
                    FcvActualizarDatosYVista(lobRespuestaXml, "b:XmlBytesBase64", "XML del Documento Radicado en DIAN"); // b:XmlBytesBase64 - Ahi esta el documento en Base64
                }
            }
        }
        #endregion FcvConsultaXMLRadicadoDian_Click>
        #region FcvEnviarCorreoAdquirente_Click: Generar documento Adjunto y enviar correo al adquirente
        /// <summary>
        /// Generar documento Adjunto y enviar correo al adquirente
        public void FcvEnviarCorreoAdquirente_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Enviar el documento al adquirente?", "Enviar Adjunto",
                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (vm.TmpG1RegActivo.Fcm_codest_fcws == "R01") // Cuando ya esta recibida
                {

                    var lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Consultando documento en DIAN...", "CENTRO");
                    lobDlgAdd.Owner = this;
                    lobDlgAdd.Show();

                    // actualizar la vista datos registro documento activo
                    vm.TmpG1RegActivo.lobRegDocDian = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", vm.G1Fcm_secreg_mfac);
                    if (vm.TmpG1RegActivo.lobRegDocDian != null)
                    {
                        vm.TmpG1RegActivo.lobRegDocDian.Fcm_notdoc_mfac = "NEW"; // para que se recargue la vista

                        if (FlgGenerarDocumentoAttached(vm.TmpG1RegActivo.lobRegDocDian,
                                                           out string tcrMensaje,
                                                           out DocumentoAttached tobRefAttacehd))
                        {
                            lobDlgAdd.Close();
                            //- Conceptos para facturas de venta
                            var lobCar003 = new VistaEnviarCorreos(vm.TmpG1RegActivo.lobRegDocDian, tobRefAttacehd);
                            lobCar003.Owner = this;
                            lobCar003.ShowDialog();
                        }
                        else
                        {
                            lobDlgAdd.Close();
                        }
                    }
                    else
                    {
                        lobDlgAdd.Close();
                    }
                }
            }
        }
        #endregion FcvEnviarCorreoAdquirente_Click
        #region FcvActualizarDatosYVista
        private void FcvActualizarDatosYVista(XmlDocument lobRespuestaXml, string tcrTagName, string tcrTituloVista)
        {
            if (vm.TmpG1RegActivo.Fcm_codest_fcws != "R01") // Cuando ya esta recibda no se modifica
            {
                if (vm.FlgDianCuentaActualizarMaestros(lobRespuestaXml, out _, out _))
                {
                    // actualizar la vista datos registro documento activo
                    vm.TmpG1RegActivo.lobRegDocDian = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", vm.G1Fcm_secreg_mfac);
                    if (vm.TmpG1RegActivo.lobRegDocDian != null)
                    {
                        vm.TmpG1RegActivo.lobRegDocDian.Fcm_notdoc_mfac = "NEW"; // para que se recargue la vista
                    }
                }
            }

            string tcrStringRespuesta = lobRespuestaXml.DocumentElement.OuterXml;
            if (tcrTagName != "NA")
            {
                if (!FlgCargarFromBase64String(tcrTagName, lobRespuestaXml, out tcrStringRespuesta))
                {
                    tcrStringRespuesta = $"Error en la consulta No hay datos en el tag {tcrTagName}";
                }
            }
            // equivalente a usar sin decodificar el documento: lobRespuestaXml.DocumentElement.OuterXml
            Funciones.FcvVistaResponse(tcrStringRespuesta, tcrTituloVista, this);

        }
        #endregion FcvActualizarDatosYVista>
        #endregion Consulas documentos Dian
        //lobRegFeFactura.Fcm_notdoc_mfac = "NEW"
        #region FcvGestionVistaDocumento: ctualizar vista datos Documento desde Facturas Dian
        /// <summary>
        /// <para>Actualizar vista datos Documento desde Facturas Dian</para>
        /// </summary>
        void FcvGestionVistaDocumento()
        {
            if (vm.TmpG1RegActivo == null)
            {
                if (lcrRefVistaDocumento != "NULL")
                {
                    lcrRefVistaDocumento = "NULL";
                    FcvCargarDatosDocumentoActivo(null);
                }
            }
            else
            {
                if (vm.TmpG1RegActivo.lobRegDocDian == null)
                {
                    if (lcrRefVistaDocumento != "NULL")
                    {
                        lcrRefVistaDocumento = "NULL";
                        FcvCargarDatosDocumentoActivo(null);
                    }
                }
                else
                {
                    // si ya se cargo, no cargar de nuevo
                    if (vm.TmpG1RegActivo.lobRegDocDian.Fcm_numfac_mfac != lcrRefVistaDocumento ||
                        vm.TmpG1RegActivo.lobRegDocDian.Fcm_notdoc_mfac == "NEW")
                    {
                        vm.TmpG1RegActivo.lobRegDocDian.Fcm_notdoc_mfac = "OK"; // Para que no se vuelva a cargar
                        lcrRefVistaDocumento = vm.TmpG1RegActivo.lobRegDocDian.Fcm_numfac_mfac;
                        FcvCargarDatosDocumentoActivo(vm.TmpG1RegActivo.lobRegDocDian);
                    }
                }
            }
        }
        #endregion FcvGestionVistaAdquirente>
        #region FcvCargarDatosDocumentoActivo: Mostrar u limpiar datos Documento activo Dian
        /// <summary>
        /// Mostrar u limpiar datos Documento activo Dian
        /// </summary>
        /// <param name="tobReg">Registro</param>
        private void FcvCargarDatosDocumentoActivo(ModeloFeFacturaMa tobReg)
        {
            if (tobReg != null)
            {
                txtG1ProFcm_idcufe_mfac.Text = tobReg.Fcm_idcufe_mfac;
                txtG1ProFcm_diafec_mfac.Text = Funciones.fcrConvertFecha(tobReg.Fcm_diafec_mfac);
                txtG1ProFcm_diahor_mfac.Text = Funciones.fcrConvierteHora(tobReg.Fcm_diahor_mfac.ToString(), "24", gcrSeparadorDecimal, ":");
                txtG1ProFcm_codest_fcws.Text = tobReg.Fcm_codest_fcws;
                txtG1ProFcm_desest_fcws.Text = tobReg.Fcm_desest_fcws;
                txtG1ProFcm_trakid_mfac.Text = tobReg.Fcm_trakid_mfac;
                txtG1ProFcm_nomarc_mfac.Text = tobReg.Fcm_nomarc_mfac;
                txtG1ProFcm_errore_mfac.Text = tobReg.Fcm_errore_mfac;

                FcrGenerarCodigoQR(tobReg, tobReg.Fcm_idcufe_mfac, out gcrTextoCodigoQr);
                //imgImagenQR.Source = Funciones.FobCodigoQrBitmapSource(gcrTextoCodigoQr, 250);
                // https://stackoverrun.com/es/q/83987 ejemplo de convertir a array
            }
            else
            {
                txtG1ProFcm_idcufe_mfac.Text = string.Empty;
                txtG1ProFcm_diafec_mfac.Text = "  /  /  ";
                txtG1ProFcm_diahor_mfac.Text = " : ";
                txtG1ProFcm_codest_fcws.Text = string.Empty;
                txtG1ProFcm_desest_fcws.Text = string.Empty;
                txtG1ProFcm_trakid_mfac.Text = string.Empty;
                txtG1ProFcm_nomarc_mfac.Text = string.Empty;
                txtG1ProFcm_errore_mfac.Text = string.Empty;
                //imgImagenQR.Source = null;
                gcrTextoCodigoQr = string.Empty;
            }
        }
        #endregion FcvCargarDatosResolucionDian>
    }
}
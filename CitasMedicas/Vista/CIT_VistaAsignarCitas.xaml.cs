//- MARMOTA-GENCODE: VERSION 2.0 - 23/05/2013 07:17:59 AM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Win32;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Clases;
using Sistema.Utilidades;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;
using Reportes.Utilidades;
using CitasMedicas.VistaModelo;
using ConfigAsistencial.Vista;

namespace CitasMedicas.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: citmaesasigcita
    /// </summary>
    public partial class VistaAsignarCitas : Window, IGestionNotificacion
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public bool glgVistaPropiedades = false;
        public bool llgAccionEdicion = false;
        //public bool glgCargaDatosAsig = false;
        DispatcherTimer ldspTimerSistema = null;
        public string gcrCtrF2TexBox;
        VistaModeloAsignarCitas vm = null;
        DialogVistaErrores lobDlgLogs = null;
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaAsignarCitas(String tcrCodigoCita)
        {

            InitializeComponent();
            vm = this.DataContext as VistaModeloAsignarCitas;
            vm.Restaurar();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;

            flgMostrarVistaDatos(tcrCodigoCita);

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;
            FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Cit_feccit_mcit.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Cit_fecreq_mcit.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Cit_fecsol_mcit.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            vm.CanAsignar();

            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();
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
            ldspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 440);
            ldspTimerSistema.Start();
        }
        #endregion
        #region fcvTimerProcesos: Timer para control Click 
        /// <summary>
        /// <para>Timer para control Click</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            // al mostrar la vista 
            if (this.IsLoaded == true)
            {
                // cuando la cita solo esta asignada
                if (vm.G1Cit_estcit_easi == "2")
                {
                    vm.fcvMostrarServAsignadosCita();
                }
                ldspTimerSistema.Tick -= new System.EventHandler(out fcvTimerProcesos);
                ldspTimerSistema.Stop();
                ldspTimerSistema = null;
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

            //this.grdPropSelect.Height = lduHeight;
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacion: Validacion campos
        //-------------------------------------------------
        #region fcvMostrarTituloCita: Titulo Cita
        /// <summary>
        /// titulo cita
        /// </summary>
        public void fcvMostrarTituloCita()
        {
            if (!String.IsNullOrWhiteSpace(txtG1Cit_feccit_mcit.Text))
            {
                DateTime ldaFechaCita;
                DateTime.TryParse(txtG1Cit_feccit_mcit.Text, out ldaFechaCita);
                var lcrFecha = ldaFechaCita.ToLongDateString().ToString();
                var lcrHoras = txtG1Cit_horini_mcit.Text.Trim() + " a " + txtG1Cit_horfni_mcit.Text.Trim();
                txtG1FechaLarga.Text = lcrFecha.Substring(0, 1).ToUpper() + lcrFecha.Substring(1, lcrFecha.Length - 2) + " - " + lcrHoras;
            }
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region Gestion Edicion
        private void fcvMostrarMenuEdicion(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #region Menu Imprimir
        private void fcvImprimir(object sender, RoutedEventArgs e)
        {
            var lobOpcion = (FrameworkElement)sender;
            switch (lobOpcion.Name)
            {
                case "opPRN_FACTURA": // Vista  previa cuenta facturas 

                    var lobPrnFactura = new FCMImprimir();
                    lobPrnFactura.gcrCodigoAdmision = this.txtG1Admision.Text;
                    lobPrnFactura.gcrTipoRegistro = "FACTURA";
                    lobPrnFactura.fcvEjecutar();

                    break;

                case "opPRN_RECIBOCAJA": // Vista  previa Relacion usuarios y facturas

                    var lobPrnRecibo = new FCMImprimir();
                    lobPrnRecibo.gcrCodigoRegistro = vm.gcrIdTransaccionCaja; // 
                    lobPrnRecibo.gcrTipoRegistro = "RECIBOCAJA";
                    lobPrnRecibo.fcvEjecutar();

                    break;
            }
        }
        #endregion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
        }

        //-Clic en Boton Modificar
        private void fcvModificarRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("EDT");
            FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
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
        private void fcvVerCapaErrores(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados == true)
            {
                TextBox lobTexto = (TextBox)sender;
                if (lobTexto.Text.Trim() == "ERROR")
                {
                    lobTexto.Text = "NA";
                    fcvVistaLogErrores();
                }
            }
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
            if (lobDlgLogs == null)
            {
                lobDlgLogs = new DialogVistaErrores();
                lobDlgLogs.fcvCargarVista("Vista errores", vm.tmpLogErrores);
                lobDlgLogs.Show();
                lobDlgLogs.fcvActivarVista();
            }
            else
            {
                lobDlgLogs.Close();

                lobDlgLogs = new DialogVistaErrores();
                lobDlgLogs.fcvCargarVista("Vista errores", vm.tmpLogErrores);
                lobDlgLogs.Show();
                lobDlgLogs.fcvActivarVista();
            }
        }
        private void fcvGotFocus(object sender, EventArgs e)
        {
            if (lobDlgLogs != null)
            {
                lobDlgLogs.fcvCerrarVista();
                lobDlgLogs = null;
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
        }

        #endregion
        //-------------------------------------------------
        // Eventos Auxiliares
        //-------------------------------------------------
        #region Eventos Auxiliares
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //fcvFinalizarInstanciaDatos();
            this.DragMove();
        }
        private void btnCerrar_KeyDown(object sender, MouseEventArgs e)
        {
            fcvFinalizarInstanciaDatos();
            this.Close();
        }
        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            fcvFinalizarInstanciaDatos();
            this.Close();
        }
        private void fcvFinalizarInstanciaDatos()
        {
            vm.Restaurar();
            LocalizadorVistaModelo.fcvLiberarVistaModeloAsignarCitas();
            // Quitar referencias
            dpkG1Cit_feccit_mcit.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Cit_fecreq_mcit.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Cit_fecsol_mcit.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            SystemEvents.DisplaySettingsChanged -= SystemEvents_ReajustarVistaPantalla;
            this.MouseDown -= new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus -= new RoutedEventHandler(fcvGotFocus);

        }
        #endregion
        //-------------------------------------------------
        // Cerrar la vista si se confirma la accion 
        //-------------------------------------------------
        #region fcvAsignarCita: Asigna la cita pero no genera registro de atención
        /// <summary>
        /// Asigna la cita pero no genera registro de atención
        /// </summary>
        private void fcvAsignarCita(object sender, RoutedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    var lcrMsj1 = vm.G1Cit_estcit_easi != "2" ? "Desea asignar cita?" : "Desea modificar cita?";
                    var lcrMsj2 = vm.G1Cit_estcit_easi != "2" ? "Asignar cita" : "Modificar cita";

                    if (MessageBox.Show(lcrMsj1, lcrMsj2, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        fcvAsignarCita();
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvCambioEstadoCita");
            }
        }
        #endregion
        #region fcvAsignarCita: Ejecutar Asignar cita en VistaModeloBase
        /// <summary>
        /// Ejecutar Asignar cita en VistaModeloBase
        /// </summary>
        private void fcvAsignarCita()
        {
            try
            {
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Guardando datos...", "CENTRO");
                lobDlgAdd.Show();

                if (vm.flgAsignar())
                {
                    fcvRetornarInterface(this.txtG1Cit_codasi_mcit.Text.Trim());
                }
                lobDlgAdd.Close();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvCambioEstadoCita");
            }
        }
        #endregion
        #region fcvConfirmarCita: Asigna cita y genera registro de atención confirmado
        /// <summary>
        /// Asigna cita y genera registro de atención confirmado
        /// </summary>
        private void fcvConfirmarCita(object sender, RoutedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    var lnuCopago = vm.G4Fcm_valcpa_dfac + vm.G4Fcm_valcmo_dfac; // se da en odontologia que se cobra el copago pero es prefactura 

                    if ((vm.GcrSIS_ConfirmarFacturas == "EFECTIVO" && vm.G1Fcm_tiprfa_mfac == "2") ||
                        (vm.GcrSIS_ConfirmarFacturas == "EFECTIVO" && vm.G1Fcm_tiprfa_mfac == "1" && lnuCopago > 0))
                    {
                        var lcrTempFact = vm.flsSeleccionarFacturas();
                        var lcrTempDeta = vm.flsSeleccionarFacturasDetalles();

                        var lcrobForm = new FcmTransaccionCajaFacturacion(lcrTempFact, lcrTempDeta);
                        lcrobForm.Owner = this;
                        lcrobForm.fcvActivarVista();
                    }
                    else
                    {
                        if (MessageBox.Show("Desea confirmar cita?", "Confirmar",
                                             MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            fcvConfirmarCitas();
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvCambioEstadoCita");
            }
        }
        #endregion
        #region fcvConfirmarCitas: ejecutar Confirmar citas
        /// <summary>
        /// Ejecutar Confirmar citas
        /// </summary>
        private void fcvConfirmarCitas()
        {
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Confirmando datos...", "CENTRO");
            lobDlgAdd.Show();

            if (vm.flgConfirmar())
            {
                fcvRetornarInterface(this.txtG1Cit_codasi_mcit.Text.Trim());
            }
            lobDlgAdd.Close();
        }
        #endregion
        #region fcvCancelarCita: Cancelar la cita 
        /// <summary>
        /// Cancelar la cita y generar registro vacio para reasignar
        /// </summary>
        private void fcvCancelarCita(object sender, RoutedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    if (MessageBox.Show("Desea cancelar cita?", "Cancelar cita", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        fcvCancelarCita();
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvCancelarCita");
            }
        }
        #endregion
        #region fcvCancelarCita: Ejecutar cancelar cita en VistaModeloBase
        /// <summary>
        /// Ejecutar cancelar cita en VistaModeloBase
        /// </summary>
        private void fcvCancelarCita()
        {
            try
            {
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cancelando cita...", "CENTRO");
                lobDlgAdd.Show();

                if (vm.flgCancelar())
                {
                    fcvRetornarInterface("CANCELADA");
                    // Cerrar vista del formulario
                    fcvFinalizarInstanciaDatos();
                    this.Close();

                }
                lobDlgAdd.Close();
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Vista Error Metodo: fcvCancelarCita");
            }
        }
        #endregion
        //- Retornar datos
        #region fcvRetornarInterface: Retorna los valores
        /// <summary>
        /// Retorna los valores al formulario que realizo el llamado
        /// </summary>
        private void fcvRetornarInterface(String tcrCodigoRegistro)
        {
            if (!String.IsNullOrWhiteSpace(txtG1Cit_estcit_easi.Text))
            {
                SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
                if (lobRefEnlace != null)
                {
                    lobRefEnlace.fcvBuscarRegistro(tcrCodigoRegistro);
                    llgAccionEdicion = false;
                }
                //this.Close();
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
        #endregion
        //-------------------------------------------------
        //  KeyDown llamada funciones compos con F2
        //-------------------------------------------------
        #region llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("CIT", "CITMAESASIGCITA", "", "Asignación de citas a Pacientes...");
            gcrCtrF2TexBox = "txtG1Cit_codasi_mcit";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region flgMostrarVistaDatos
        /// <summary>
        /// Ejecutar Filtro para mostrar la vista de datos segun el codigo cita
        /// </summary>
        public bool flgMostrarVistaDatos(String tcrIdCodigoCita)
        {
            bool llgReturn = false;
            if (!String.IsNullOrEmpty(tcrIdCodigoCita))
            {
                vm.GlgSIS_ModoAddPrograma = false;
                vm.G1Cit_codasi_mcit = tcrIdCodigoCita;
                vm.fcvFiltro();
                vm.gdaFechaActual = Funciones.FdaFechaActual();
                vm.gdaFechaCita = Funciones.fdaConvertFecha("DMY", "/", vm.G1Cit_feccit_mcit);
                this.lblAsignar.Text = vm.G1Cit_estcit_easi != "2" ? "Asignar cita" : "Modificar";
                vm.G1Cit_fecsol_mcit = vm.G1Cit_estcit_easi == "1" ? Funciones.fcrFechaActual() : vm.G1Cit_fecsol_mcit;
                vm.G1Cit_fecreq_mcit = vm.G1Cit_estcit_easi == "1" ? vm.G1Cit_feccit_mcit : vm.G1Cit_fecreq_mcit;

                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region fcvBrowsUsuarios Buscar usuarios para realizar admision
        private void fcvBrowsUsuarios(object sender, RoutedEventArgs e)
        {
            var lcrFiltro = String.Empty;
            MenuItem lobOp = (MenuItem)sender;
            switch (lobOp.Name)
            {
                case "opUSContrato": // Buscar en maestro de contrato

                    var frbroCt = new Browser01("CTO", "CTOMAEAFILIADOS", "", "Maestro afiliados en contratos...");
                    gcrCtrF2TexBox = "ADD-DESDE-MAESTRO-CONTRATO";
                    frbroCt.Owner = this;
                    frbroCt.ShowDialog();

                    break;

                case "opUSAdmitidos": // Buscar en maestro de admitidos
                    var frbro = new Browser01("SIA", "SIAUSUARIOATENDIU", "", "Maestro de Pacientes atendidos...");
                    gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                    frbro.Owner = this;
                    frbro.ShowDialog();
                    break;

                case "opUSCrear": // Crear Usuario en base de datos
                    //- Maestro de Usuarios Atendidos
                    var lcrAccion = !String.IsNullOrWhiteSpace(this.txtG1Sia_nroide_usua.Text) ? "EDT" : "DFL";
                    var lobSIA002 = new VistaSiaUsuariosAtendidos(lcrAccion, "", this.txtG1Sia_nroide_usua.Text, "", "");
                    gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                    lobSIA002.Owner = this;
                    lobSIA002.ShowDialog();
                    break;
            }
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
                case "txtG1Cit_codasi_mcit":
                    txtG1Cit_codasi_mcit.Text = tcrCodigo;
                    flgMostrarVistaDatos(tcrCodigo);
                    break;

                case "txtG1Cit_codtur_turn":
                    txtG1Cit_codtur_turn.Text = tcrCodigo;
                    break;

                case "txtG1Cit_codspr_spro":
                    txtG1Cit_codspr_spro.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codcat_ceat":
                    txtG1Sia_codcat_ceat.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codpfa_prof":
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codcon_ctor":
                    txtG1Sia_codcon_ctor.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codare_aser":
                    txtG1Sia_codare_aser.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codcpr_cpro":
                    txtG1Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codesp_esme":
                    txtG1Sia_codesp_esme.Text = tcrCodigo;
                    break;

                case "txtG1Sia_tipide_tide":
                    txtG1Sia_tipide_tide.Text = tcrCodigo;
                    break;

                case "txtG1Sia_nroide_usua":
                    this.txtG1Sia_nroide_usua.Text = String.Empty;
                    this.txtG1Cto_seccon_cont.Text = String.Empty;
                    txtG1Sia_nroide_usua.Text = tcrCodigo;
                    break;

                case "txtG1Cto_seccon_cont":
                    txtG1Sia_codeps_teps.Text = String.Empty;
                    txtG1Cto_seccon_cont.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG1Cit_caucan_ccan":
                    txtG1Cit_caucan_ccan.Text = tcrCodigo;
                    break;

                case "txtG1Sys_codusu_usux":
                    txtG1Sys_codusu_usux.Text = tcrCodigo;
                    break;

                case "txtG1Cit_estcit_easi":
                    txtG1Cit_estcit_easi.Text = tcrCodigo;
                    break;

                case "txtG1Sis_estpro_espr":
                    txtG1Sis_estpro_espr.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_coddig_mant":
                    txtG1Fcm_coddig_mant.Text = tcrCodigo;
                    break;

                case "txtG1Sis_numide_sitr":
                    txtG1Sis_numide_sitr.Text = tcrCodigo;
                    break;

                case "ADD-DESDE-MAESTRO-CONTRATO":
                    //- Maestro de Usuarios Atendidos
                    var llgOk = true;
                    var lobReg = CTOValidarCodigo.fobRegBuscarCtomaeafiliados(tcrCodigo);
                    if (lobReg != null)
                    {
                        var tmp = SIAValidarCodigo.fobRegBuscarIuSiausuarioatendEx(lobReg.sia_nroide_usua);
                        if (tmp != null)
                        {
                            this.txtG1Sia_nroide_usua.Text = String.Empty;
                            this.txtG1Cto_seccon_cont.Text = String.Empty;
                            llgOk = false;
                            txtG1Sia_nroide_usua.Text = lobReg.sia_nroide_usua;
                            //txtG1Sia_idesec_usua.Text = tmp.sia_idesec_usua;
                        }
                    }
                    if (llgOk == true)
                    {
                        VistaSiaUsuariosAtendidos lobSIA002 = new VistaSiaUsuariosAtendidos("ADAF", "", tcrCodigo, "", "");
                        gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                        lobSIA002.Owner = this;
                        lobSIA002.ShowDialog();
                    }
                    break;
            }
        }
        // CITMAESASIGCITA : Asignación de citas a Pacientes
        #region KeyDown para campos con F2 Tabla: CITMAESASIGCITA
        #region CIT_CODTUR_TURN : Maestro de turnos por profesional
        private void txtG1Cit_codtur_turn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("CIT", "CITMAESTROTURNO", "", "Maestro de turnos por profesional...");
                gcrCtrF2TexBox = "txtG1Cit_codtur_turn";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region CIT_CODSPR_SPRO : Servicios para programación o citas medicas
        private void txtG1Cit_codspr_spro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Cit_codspr_spro_Browser();
            }
        }
        private void cmdG1Cit_codspr_spro_Click(object sender, RoutedEventArgs e)
        {
            txtG1Cit_codspr_spro_Browser();
        }
        private void txtG1Cit_codspr_spro_Browser()
        {
            Browser01 frbro = new Browser01("CIT", "CITSERVICIOPROG", "", "Servicios para programación o citas medicas...");
            gcrCtrF2TexBox = "txtG1Cit_codspr_spro";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODCAT_CEAT : Lista Centros de Atención  cuando hay varias sedes en lugare
        private void txtG1Sia_codcat_ceat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIACENTROATEN", "", "Lista Centros de Atención  cuando hay varias sedes en lugare...");
                gcrCtrF2TexBox = "txtG1Sia_codcat_ceat";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODPFA_PROF : Profesionales que prestan servicios
        private void txtG1Sia_codpfa_prof_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codpfa_prof_Browser();
            }
        }
        private void cmdG1Sia_codpfa_prof_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codpfa_prof_Browser();
        }
        private void txtG1Sia_codpfa_prof_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
            gcrCtrF2TexBox = "txtG1Sia_codpfa_prof";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODCON_CTOR : Consultorios para atencion medica
        private void txtG1Sia_codcon_ctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIACONSULTORIOS", "", "Consultorios para atencion medica...");
                gcrCtrF2TexBox = "txtG1Sia_codcon_ctor";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODESP_ESME : Especialidades medicas
        private void txtG1Sia_codesp_esme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codesp_esme_Browser();
            }
        }
        private void cmdG1Sia_codesp_esme_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codesp_esme_Browser();
        }
        private void txtG1Sia_codesp_esme_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAESPECIALIMED", "", "Especialidades medicas...");
            gcrCtrF2TexBox = "txtG1Sia_codesp_esme";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_TIPIDE_TIDE : Configuracion para los tipos de identificacion de los uauari
        private void txtG1Sia_tipide_tide_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIATIPIDEUSARIO", "", "Configuracion para los tipos de identificacion de los uauari...");
                gcrCtrF2TexBox = "txtG1Sia_tipide_tide";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_NROIDE_USUA : Maestro de Pacientes atendidos
        private void txtG1Sia_nroide_usua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATENDIU", "", "Maestro de Pacientes ...");
                gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region CTO_SECCON_CONT : Maestro contratos con  EPS o aseguradores
        private void txtG1Cto_seccon_cont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Cto_seccon_cont_Browser();
            }
        }
        private void cmdG1Cto_seccon_cont_Click(object sender, RoutedEventArgs e)
        {
            txtG1Cto_seccon_cont_Browser();
        }
        private void txtG1Cto_seccon_cont_Browser()
        {
            Browser01 frbro = new Browser01("CTO", "CTOMAESCONTRATO", "", "Maestro contratos con  EPS...");
            gcrCtrF2TexBox = "txtG1Cto_seccon_cont";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODEPS_TEPS : Lista de EPS o seguradores
        private void txtG1Sia_codeps_teps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codeps_teps_Browser();
            }
        }
        private void cmdG1Sia_codeps_teps_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codeps_teps_Browser();
        }
        private void txtG1Sia_codeps_teps_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATABLAEPS", "", "Lista de EPS o seguradores...");
            gcrCtrF2TexBox = "txtG1Sia_codeps_teps";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region CIT_CAUCAN_CCAN : Causa cancelación cita medica
        private void txtG1Cit_caucan_ccan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Cit_caucan_ccan_Browser();
            }
        }
        private void cmdG1Cit_caucan_ccan_Click(object sender, RoutedEventArgs e)
        {
            txtG1Cit_caucan_ccan_Browser();
        }
        private void txtG1Cit_caucan_ccan_Browser()
        {
            Browser01 frbro = new Browser01("CIT", "CITCAUSACANCITA", "", "Causa cancelación cita medica...");
            gcrCtrF2TexBox = "txtG1Cit_caucan_ccan";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SYS_CODUSU_USUX : Maestro de Usuarios del Sistema
        private void txtG1Sys_codusu_usux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SYS", "SYSUSUARIOS", "", "Maestro de Usuarios del Sistema...");
                gcrCtrF2TexBox = "txtG1Sys_codusu_usux";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region CIT_ESTCIT_EASI : Estado asignacion cita medica
        private void txtG1Cit_estcit_easi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("CIT", "CITESTADOASCITA", "", "Estado asignacion cita medica...");
                gcrCtrF2TexBox = "txtG1Cit_estcit_easi";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIS_ESTPRO_ESPR : Estados de procesos (Abierto, Cerrado,Anulado)
        private void txtG1Sis_estpro_espr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIS", "SISESTADOPROCES", "", "Estados de procesos (Abierto, Cerrado,Anulado)...");
                gcrCtrF2TexBox = "txtG1Sis_estpro_espr";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODARE_ASER : Areas prestacion de servicios
        private void txtG1Sia_codare_aser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codare_aser_Browser();
            }
        }
        private void cmdG1Sia_codare_aser_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codare_aser_Browser();
        }
        private void txtG1Sia_codare_aser_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAAREAPRESERVI", "", "Areas prestacion de servicios...");
            gcrCtrF2TexBox = "txtG1Sia_codare_aser";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_CODCPR_CPRO : Centros de produccion asistenciales
        private void txtG1Fcm_codcpr_cpro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_codcpr_cpro_Browser();
            }
        }
        private void cmdG1Fcm_codcpr_cpro_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_codcpr_cpro_Browser();
        }
        private void txtG1Fcm_codcpr_cpro_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMCENPRODUCCIO", "", "Centros de produccion asistenciales...");
            gcrCtrF2TexBox = "txtG1Fcm_codcpr_cpro";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_NUMIDE_SITR Tabla terceros o Adquirentes Por Nit
        private void TxtG1Sis_numide_sitr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                TxtG1Sis_numide_sitr_Browser();
            }
        }
        private void CmdG1Sis_numide_sitr_Click(object sender, RoutedEventArgs e)
        {
            TxtG1Sis_numide_sitr_Browser();
        }
        private void TxtG1Sis_numide_sitr_Browser()
        {
            Browser01 frbro = new Browser01("SIS", "SISMAESTERCEROS-NIT", "", "Maestro Adquiretes...");
            gcrCtrF2TexBox = "txtG1Sis_numide_sitr";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_CODDIG_MANT : Manual ventas de servicios medicos
        private void txtG1Fcm_coddig_mant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                fcvBuscarServicios();
            }
        }
        private void cmdAddServcio_Click(object sender, RoutedEventArgs e)
        {
            fcvBuscarServicios();
        }
        private void fcvBuscarServicios()
        {
            var lcrTitulo = "Manual ventas de servicios medicos...";
            var lcrFiltro = "Fcmmanservicios.fcm_codman_mans='" + this.txtG1Fcm_codman_mans.Text.Trim() + "'";
            gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";

            if (vm.G1Cto_serper_cont == "2")
            {
                lcrTitulo = "Servicios médicos Personalizados...";
                lcrFiltro = "Ctomanservicios.cto_seccon_cont='" + this.txtG1Cto_seccon_cont.Text.Trim() + "'";
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

            /*
            var lcrFiltro = "Fcmmanservicios.fcm_codman_mans='" + txtG1Fcm_codman_mans.Text.Trim() + "'";
            Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIOSIU", lcrFiltro, "Manual ventas de servicios medicos...");
            gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";
            frbro.Owner = this;
            frbro.ShowDialog();
            */
        }
        #endregion
        #endregion
        #region FCM_AUTDES_ADES : Maestro para registrar los descuentos solicitados y  autoriz
        /*
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            
            Browser01 frbro = new Browser01("FCM", "FCMDESCUEAUTORIAP", txtG1Adm_secadm_rgad.Text.Trim(), "Descuentos solicitados y autorizados...");
            gcrCtrF2TexBox = "txtG4Fcm_autdes_ades";
            frbro.Owner = this;
            frbro.ShowDialog();
            
        }
        */
        #endregion
        #endregion
        // Interface para compatibilidad
        #region INotificacion: Interface para devolver id registro notificacion
        /// <summary>
        /// <para>Devolver id registro notificacion, modulo y tipo Notificacion</para>
        /// </summary>
        public void fcvINotificacion(String tcrIdRegNotificacion, String tcrIdModulo, String tcrTipoNotificacion, String tcrRegEvento) { }
        #endregion
        // Gestion pago en efectivo
        #region fcvIGestionTransaccion: Devolver registros maestro de facturas y detalles en gestion pago en efectivo
        /// <summary>
        /// <para>Devolver registros maestro de facturas y detalles en gestion pago en efectivo</para>
        /// </summary>
        public void fcvIGestionTransaccion(String tcrIdTransaccionCaja, List<SelectFacturasMaestro> tlsSelectFacturas, List<SelectFacturasDetalles> tlsSelectDetallFacturas)
        {
            // Realizar proceso de confirmacion facturas
            if (tlsSelectFacturas != null)
            {
                vm.fcvIGestionTransaccion(tcrIdTransaccionCaja, tlsSelectFacturas, tlsSelectDetallFacturas);
                fcvConfirmarCitas();
            }
        }
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
                        case "cboG1Cit_tipsol_mcit":
                            txtG1Cit_tipsol_mcit.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cit_tipsol_mcit.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cit_tipsol_mcit.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Cit_proqrx_mcit":
                            txtG1Cit_proqrx_mcit.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Cit_proqrx_mcit.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Cit_proqrx_mcit.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Cit_tipsol_mcit":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Cit_tipsol_mcit.SelectedItem;
                            cboG1Cit_tipsol_mcit.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Cit_proqrx_mcit":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Cit_proqrx_mcit.SelectedItem;
                            cboG1Cit_proqrx_mcit.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
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
                    case "dpkG1Cit_feccit_mcit":
                        txtG1Cit_feccit_mcit.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Cit_feccit_mcit);
                        break;

                    case "dpkG1Cit_fecreq_mcit":
                        txtG1Cit_fecreq_mcit.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Cit_fecreq_mcit);
                        break;

                    case "dpkG1Cit_fecsol_mcit":
                        txtG1Cit_fecsol_mcit.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Cit_fecsol_mcit);
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
                            case "txtG1Cit_feccit_mcit":
                                dpkG1Cit_feccit_mcit.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtG1Cit_fecreq_mcit":
                                dpkG1Cit_fecreq_mcit.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtG1Cit_fecsol_mcit":
                                dpkG1Cit_fecsol_mcit.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        // Vista Capa Seleccion
        //-------------------------------------------------
        #region Ventana Vista de propiedades
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaPropiedades(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaPropiedades();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana seleccion obra
        /// <summary>
        /// <para>Mostrar Ventana seleccion obra</para>
        /// </summary>
        private void fcvActivarVistaSeleccionTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades</para>
        /// </summary>
        private void fcvActivarVistaPropiedades()
        {
            //this.objHistCortina.Visibility = Visibility.Visible;
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropiedades == false)
            {
                luxAnimacion.To = -610; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropiedades = true;
            }
            else
            {
                luxAnimacion.To = 22; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropiedades = false;
            }
            //this.grdPropSelect.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // fcrValidacion: Validacion campos
        //-------------------------------------------------
        #region fcvValidacionTexto: Validacion campos
        /// <summary>
        /// <para>Validacion campos</para>
        /// </summary>
        private void fcvValidacionTexto(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados == true)
            {
                var lobTextBox = sender as TextBox;
                //fcrValidacion(lobTextBox.Name);
                vm.GlgSIS_ModoAddPrograma = true;
            }
        }
        #endregion
        //-------------------------------------------------
        // OPTIMIZAR MEMORIA EN EL MODULO
        //-------------------------------------------------
        #region OPTIMIZAR MEMORIA
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hHeap = Heap.HeapCreate(Heap.HeapFlags.HEAP_GENERATE_EXCEPTIONS, 0, 0);
            // if the FriendlyName is "heap.vshost.exe" then it's using the VS Hosting Process and not "Heap.Exe"
            Trace.WriteLine(AppDomain.CurrentDomain.FriendlyName + " heap created");
            uint nSize = 100 * 1024 * 1024;
            ulong nTot = 0;
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    var ptr = Heap.HeapAlloc(hHeap, 0, nSize);
                    nTot += nSize;
                    Trace.WriteLine(String.Format("Iter #{0} {1:n0} ", i, nTot));
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception " + ex.Message);
            }
            Heap.HeapDestroy(hHeap);
            Trace.WriteLine("destroyed");
            Application.Current.Shutdown();
        }

        public class Heap
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr HeapCreate(HeapFlags flOptions, uint dwInitialsize, uint dwMaximumSize);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr HeapAlloc(IntPtr hHeap, HeapFlags dwFlags, uint dwSize);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool HeapFree(IntPtr hHeap, HeapFlags dwFlags, IntPtr lpMem);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool HeapDestroy(IntPtr hHeap);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr GetProcessHeap();

            [Flags()]
            public enum HeapFlags
            {
                HEAP_NO_SERIALIZE = 0x1,
                HEAP_GENERATE_EXCEPTIONS = 0x4,
                HEAP_ZERO_MEMORY = 0x8
            }

        }
        public static void UnRegisterSurveyViewModel() 
        {
            SimpleIoc.Default.Unregister<VistaModeloAsignarCitas>();
            SimpleIoc.Default.Register<VistaModeloAsignarCitas>(); 
        } 
        private void fcvUnloaded(object sender, RoutedEventArgs e) 
        {
            VistaAsignarCitas.UnRegisterSurveyViewModel(); 
        } 
        #endregion
    }
    
}
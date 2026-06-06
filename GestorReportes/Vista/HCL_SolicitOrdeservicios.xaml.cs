//- MARMOTA-GENCODE: VERSION 2.0 - 25/05/2014 12:12:21 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Validacion;
using GestorReportes.Modelo;
using GestorReportes.Vista;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclregordeservi
    /// </summary>
    public partial class VistaSolicitudServicios : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        #region Variables
        public bool llgModoAdicion      = false;
        public bool llgModoEdicion      = false;
        public bool llgModoEdicionKey   = false;
        public bool llgModoEdicionValid = false;
        public bool llgObjetosCargados  = false;
        public int lnuContNuevoRegistro = 0; // Para codigo temporal de nuevos registros
        public String gcrCtrF2TexBox;
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public String lcrFormModoPopup      = "DFL";
        public String gcrSeparadorDecimal   = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public String gcrCodigoAdmision     = String.Empty;
        public String gcrCodigoMaestro      = String.Empty;
        public String gcrCodigoRegistro     = String.Empty;
        public String gcrModoAccion         = String.Empty;
        public String gcrTipoRegistro       = "1";  // 1 = Medicamentos 2=Indicacion medica
        public String gcrTipoPlanManejo     = "1";  // 1 = Manejo Interno 2=Manejo Externo
        public String gcrNombreAlmacen      = String.Empty; // almacen activo
        public int gnuTotalUnidExisten      = 0;
        // Temporales
        public ADMModeloAdmadmisiones tmpRegAdm             = null;
        public ModeloHclregordeserms  tmpRegMaestro         = null;
        public ModeloHclregordeserde tmpRegDetalle          = new ModeloHclregordeserde();
        public List<ModeloHclregordeserde> tmpDatosDetalle  = null;
        public EFctomaescontrato tmpRegContrato             = null;
        public List<LogsErrores> tmpLogErrores              = new List<LogsErrores>();
        public List<CrtForms.ListaComboBox> lstG1Hcl_tipser_hcor;
        public List<CrtForms.ListaComboBox> lstG1Hcl_aplmed_hcor;
        public List<CrtForms.ListaComboBox> lstG1Hcl_termed_hcor;
        public List<CrtForms.ListaComboBox> lstG1Cto_suminv_cont;
        DialogVistaErrores lobDlgLogs = null;
        #endregion
        #region Clase Objeto para liquidar valores servicios
        /// <summary>
        ///  Parametros generales para liquidar servicios de facturación
        /// </summary>
        public FcmFacturarServicios gobLiq = new FcmFacturarServicios();
        #endregion
        /// <summary>
        /// Realizar entregas u ordenenes de servicios intrahospitalarios
        /// <para>tcrTipoPlanManejo: 1= Plan de manejo interno 2=Formula medica (plan manejo externo) </para>
        /// </summary>
        public VistaSolicitudServicios(String tcrModoAccion, String tcrTipoPlanManejo, String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            InitializeComponent();

            #region Iniciar procesos
            fcvSetRichTextBoxEditor();
            IniciarComboBox();
            llgObjetosCargados = true;
            gcrModoAccion     = tcrModoAccion;
            gcrCodigoMaestro  = String.Empty;
            gcrTipoPlanManejo = tcrTipoPlanManejo;
            gcrCodigoRegistro = tcrCodigoRegistro;
            gcrCodigoAdmision = tcrCodigoAdmision;
            this.txtTitulo.Text = tcrTipoPlanManejo == "1" ? "Plan de manejo interno" : "Formula médica";

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;
            this.txtG1Sia_codpfa_prof.Text = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario).sia_codpfa_prof;

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Hcl_gesfec_hcor.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            if (!String.IsNullOrWhiteSpace(tcrModoAccion))
            {
                fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoRegistro, tcrCodigoAdmision);
            }
            fcvTimerGeneral();
            #endregion
        }
        #endregion
        //------------------------------------------------------------
        //  Timer Para propositos varios
        //------------------------------------------------------------
        #region fcvTimer: Control Tiempo para cosas varias
        public void fcvTimerGeneral()
        {
            gdspTimerSistema.Tick += new System.EventHandler(out fcvTimerProcesos);
            gdspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 300);
            gdspTimerSistema.Start();
        }
        #endregion
        #region fcvTimerProcesos: Timer para procesos varios y validacion
        /// <summary>
        /// <para>Timer para procesos varios y validacion</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            if (this.IsLoaded && llgModoEdicion == true)
            {
                if (llgModoEdicionKey == false && llgModoEdicionValid == false)
                {
                    llgModoEdicionValid = true;
                    flgValidacion();
                }
            }
            if (llgModoEdicion == false) { gdspTimerSistema.Stop(); }

        }
        #endregion
        //-------------------------------------------------
        // Gestion Modo Formulario Popup
        //-------------------------------------------------
        #region fcvCargarVistaFormPopup
        private void fcvCargarVistaFormPopup(String tcrModoAccion, String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            var llgExiste = flgCargarDatosExitentes(tcrCodigoRegistro);

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
            gcrTipoRegistro = "2"; // el proceso de fcvActivarTabs() lo cambia a "1"
            fcvActivarTabs("1");

            fcvActivarModoEdicion(lcrFormModoPopup);
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region  Activar modo edicion
        //- Activar modo edicion en la Vista
        public void fcvActivarModoEdicion(string tcrTipoEdicion)
        {
            switch (tcrTipoEdicion)
            {
                case "ADD":
                    llgModoAdicion = true;
                    llgModoEdicion = true;
                    fcvCargarIniciarVariables();
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = tmpRegMaestro.Sis_estpro_espr == "1" ? true : false;
                    break;
            }
            fcvCargarActivarObjetosCaptura(llgModoEdicion);

            FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcor);
        }
        #endregion
        #region Gestion Edicion
        //- clic en Boton Nuevo registro detalle
        #region Nuevo registro detalle 
        private void fcvNuevoRegistroDetalle(object sender, RoutedEventArgs e)
        {
            fcvNuevoRegistroDetalles();
        }
        #endregion
        #region fcvNuevoRegistroDetalles: Activar modo edicion y generar datos par nuevo registro
        /// <summary>
        /// Activar modo edicion y generar datos par nuevo registro detalle Medicamento/Indicacion
        /// </summary>
        private void fcvNuevoRegistroDetalles()
        {
            tmpRegDetalle = new ModeloHclregordeserde();
            fcvCargarActivarObjetosCaptura(true);
            fcvCargarReiniciarVistaRegActivo("2");
            tmpRegDetalle.Hcl_nroreg_hcor = String.Empty;
            tmpRegDetalle.Sis_estado_imaen = "A";
            tmpRegDetalle.Hcl_tserax_hcor = "NA";
        }
        #endregion
        //-Clic en Boton Guardar 
        #region fcvGuardarAgregarRegDetalle: Guardar registro modificado/agregado en pantalla
        private void fcvGuardarAgregarRegDetalle(object sender, RoutedEventArgs e)
        {
            var lobDetalle = new ControlOrdServiciosDetalleEdt();
            fcvAuxRegistroActivoDesdeVariables();
            if (tmpRegDetalle.Sis_estado_imaen == "A" && String.IsNullOrWhiteSpace(tmpRegDetalle.Hcl_nroreg_hcor))
            {
                lnuContNuevoRegistro++;
                tmpRegDetalle.Hcl_nroreg_hcor = "R" + lnuContNuevoRegistro.ToString().Trim();

                tmpRegDetalle.RefObjeto = lobDetalle;
                fcvVistaObjetosDatosBasicos(ref lobDetalle, tmpRegDetalle);
                flgVistaObjetosValoresRegistro(ref lobDetalle, tmpRegDetalle);

                tmpDatosDetalle.Add(fobAuxCopiarRegistro(tmpRegDetalle));
                this.stkDetalles.Children.Add(lobDetalle);
            }
            else
            {
                lobDetalle = tmpRegDetalle.RefObjeto as ControlOrdServiciosDetalleEdt;
                fcvAuxActualizarEnMaestroTemporal(tmpRegDetalle);
                flgVistaObjetosValoresRegistro(ref lobDetalle, tmpRegDetalle);
            }
            // actualizar vista del objeto y modificar el temporal tmpDatosDetalle
            fcvNuevoRegistroDetalles();
        }
        #endregion
        #region fcvGuardarRegistro: Guardar sin confirmar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea guardar los registros?", "Guardar",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                fcvGuardarRegistroMaestro("1");
            }
        }
        #endregion
        #region fcvGuardarConfirmarRegistro: Guardar y confirmar proceso
        private void fcvGuardarConfirmarRegistro(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea guardar y confirmar los registros?", "Confirmación",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var llgRealizar = true;

                if (tmpRegContrato.cto_suminv_cont == "1")
                {
                    var lobRegPeriodo = INVValidarCodigo.fobRegBuscarInvperiodomaest(tmpRegContrato.inv_codalm_inal, tmpRegMaestro.Hcl_gesfec_hcms);

                    if (lobRegPeriodo != null)
                    {
                        llgRealizar = true;
                    }
                    else
                    {
                        llgRealizar = false;
                        MessageBox.Show("No hay perido activo en inventario para la fecha: " + this.txtG1Hcl_gesfec_hcor.Text);
                    }
                }

                if (llgRealizar == true)
                {
                    fcvGuardarRegistroMaestro("2");
                }
            }
        }
        #endregion
        #region fcvGuardarRegistroMaestro: Guardar registro maestro
        /// <summary>
        /// <para>Guardar todo el proceso de digitacion y cerrar la vista </para>
        /// <para>tcrEstado: "1"= Guardar todo sin confirmar "2"= Guardar todo y confirmar el proceso</para>
        /// </summary>
        private void fcvGuardarRegistroMaestro(String tcrEstado)
        {
            var llgReturn = true;
            var lcrNuevoCodigo = String.Empty;
            tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;

            if (flgValidacion() == true)
            {
                if (flgGuardarRegistroMaestro(tcrEstado) == true)
                {
                    fcvGuardarRegistroDetalles(gcrCodigoMaestro);

                    if (tcrEstado == "2" && gcrTipoPlanManejo == "2" && tmpRegContrato.cto_suminv_cont == "1")
                    {
                        var lcrIdEntrega = fcrGuardarGenerarSalidaFarmacia();
                        if (!String.IsNullOrWhiteSpace(lcrIdEntrega))
                        {
                            // Generar datos para facturacion
                            var lobClass = new HclGenFacturServicios();
                            // Cargar los parametros
                            lobClass.gcrCodigoAuxiliar      = lcrIdEntrega;
                            lobClass.gcrTipoRegistro        = "FMED";
                            lobClass.gcrCodigoAdmision      = gcrCodigoAdmision;
                            lobClass.tmpRegAdm              = tmpRegAdm;
                            lobClass.tmpRegMaestro          = tmpRegMaestro;
                            lobClass.gcrCodigoProfesional   = tmpRegMaestro.Sia_codpfa_prof;

                            // Generar datos en facturacion y notificacion
                            lobClass.fcvSYSGenerarNotificacion();
                            llgReturn = lobClass.flgConfirmarFacturaServicios();
                            tmpLogErrores = lobClass.tmpLogErrores;
                        }
                        /*
                        if (llgReturn == true)  // Cuando hay error al confirmar factura, no se cierra la ventana
                        {
                            fcvGuardarGenerarSalidaFarmacia();
                        }
                        */

                    }
                    if (llgReturn == true)  // Cuando hay error al confirmar factura, no se cierra la ventana
                    {
                        fcvRetornoInterface(gcrCodigoMaestro);
                    }
                    else
                    {
                        MessageBox.Show("Error al enviar los datos a facturación");
                    }
                }
            }
            else
            {
                MessageBox.Show("No es posible guardar los datos.");
            }
        }
        #endregion
        #region fcvGuardarRegistroDetalles: Guardar registros Detalles en base de datos
        /// <summary>
        /// Guardar registros Detalles en base de datos
        /// </summary>
        private void fcvGuardarRegistroDetalles(String tcrCodigoMaestro)
        {
            var lcrNuevoCodigo = String.Empty;

            foreach (var lobReg in tmpDatosDetalle)
            {
                // actualizar datos que en registro R1 posiblemente se cambiaron
                lobReg.Hcl_nroreg_hcms = tcrCodigoMaestro;
                lobReg.Hcl_gesfec_hcor = tmpRegMaestro.Hcl_gesfec_hcms;
                lobReg.Hcl_geshor_hcor = tmpRegMaestro.Hcl_geshor_hcms;
                lobReg.Sia_codpfa_prof = tmpRegMaestro.Sia_codpfa_prof;
                lobReg.Sis_estpro_espr = tmpRegMaestro.Sis_estpro_espr;

                // Apllicar politica de gestion registro
                if (lobReg.Sis_estado_imaen == "E")
                {
                    ModeloHclregordeserde.fcvEliminar(lobReg.Hcl_nroreg_hcor);
                    lobReg.Sis_estado_imaen = "N"; // se marca como nulo para ser ignorado pór completo en el futuro
                }
                else if (lobReg.Sis_estado_imaen != "A" && lobReg.Sis_estado_imaen != "N")
                {
                    ModeloHclregordeserde.fcvActualizar(lobReg);
                    lobReg.Sis_estado_imaen = "I";
                }
                else if (lobReg.Sis_estado_imaen == "A")
                {
                    lcrNuevoCodigo = ModeloHclregordeserde.flgAddRegistro(lobReg);
                    if (!String.IsNullOrWhiteSpace(lcrNuevoCodigo))
                    {
                        lobReg.Hcl_nroreg_hcor = lcrNuevoCodigo;
                        lobReg.Sis_estado_imaen = "I";
                    }
                }
            }
        }
        #endregion
        #region flgGuardarRegistroMaestro: Validar y generar el registro maestro R1
        /// <summary>
        /// Validar y generar el registro maestro R1
        /// <para>tcrEstado: "1"= Guardar todo sin confirmar "2"= Guardar todo y confirmar el proceso</para>
        /// </summary>
        public bool flgGuardarRegistroMaestro(String tcrEstado)
        {
            var lcrTipoServicio = gcrTipoPlanManejo == "1" ? "SERV" : "FMED";
            var llgReturn = false;
            var lcrIdActividadHClinico = String.Empty;

            // Generar el registro Vista en historial clinico
            if (tcrEstado == "2") // se confirmo  por primera vez
            {
                lcrIdActividadHClinico = fcvHclinicaGenerarActividad(gcrTipoPlanManejo);
            }

            var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx(lcrTipoServicio, gcrCodigoAdmision, "1");
            if (lobReg.Count != 0)
            {
                tmpRegMaestro = lobReg.FirstOrDefault();
                gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;

                tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcor.Text);
                tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegMaestro.Sis_estpro_espr = tcrEstado;

                ModeloHclregordeserms.fcvActualizar(tmpRegMaestro);
            }
            else
            {
                // Adicionar el registro
                tmpRegMaestro = new ModeloHclregordeserms();
                #region Valores Variables
                tmpRegMaestro.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                tmpRegMaestro.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegMaestro.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                tmpRegMaestro.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                tmpRegMaestro.Sia_nomusu_usua = tmpRegAdm.Sia_nomusu_usua;
                tmpRegMaestro.Hcl_tipreg_hctr = lcrTipoServicio;
                tmpRegMaestro.Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
                tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcor.Text);
                tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegMaestro.Sis_estpro_espr = tcrEstado;
                #endregion
                gcrCodigoMaestro = ModeloHclregordeserms.flgAddRegistro(tmpRegMaestro);
                tmpRegMaestro.Hcl_nroreg_hcms = gcrCodigoMaestro;
            }

            llgReturn = !String.IsNullOrWhiteSpace(gcrCodigoMaestro) ? true : false;
            return llgReturn;
        }
        #endregion
        #region fcrGuardarGenerarSalidaFarmacia: Generar registro salida farmacia
        /// <summary>
        /// <para>Generar registro salida farmacia en estado abierto, para confirmar cuando se reclaman los medicamentos</para>
        /// <para>Devuelve el Id generado para el registro entrega medicamentos en farmacia</para>
        /// </summary>
        private String fcrGuardarGenerarSalidaFarmacia()
        {
            var lobRegFarmacia = ModeloHclregordeserms.fobRegistroMedicamentoFormulaMedicaMA(tmpRegMaestro.Hcl_nroreg_hcms,
                                                                                             tmpRegContrato.inv_codalm_inal, 
                                                                                             tmpRegMaestro.Hcl_gesfec_hcms);
            lobRegFarmacia.Hcl_tiptur_hctu = "T01"; // Mañana por defecto

            var lcrNuevoCodigo = ModeloEntregaMedica.flgAddRegistro(lobRegFarmacia);

            if (!String.IsNullOrWhiteSpace(lcrNuevoCodigo))
            {
                var lobTempFarmacia = ModeloHclregordeserde.flsTempMedicamentoFormulaMedicaMD(tmpRegMaestro.Hcl_nroreg_hcms,
                                                                                              tmpRegContrato.inv_codalm_inal,
                                                                                              tmpRegMaestro.Hcl_gesfec_hcms);
                if (lobTempFarmacia != null)
                {
                    var lnuContador = 0;
                    foreach (var lobReg in lobTempFarmacia)
                    {
                        lnuContador++;
                        lobReg.Far_nroreg_fads = "R0" + lnuContador.ToString().Trim();
                        lobReg.Far_nroreg_fams = lcrNuevoCodigo;
                        ModeloEntregaMedicad.flgAddRegistro(lobReg,lcrNuevoCodigo);
                    }
                }
            }

            return lcrNuevoCodigo;
        }
        #endregion
        #endregion
        #region fcvRetornoInterface
        /// <summary>
        /// Retoma la interfase con la ventana principal
        /// entrega el codigo seleccionado y cierra el Browser
        /// </summary>
        private void fcvRetornoInterface(string tcrCodigSelect)
        {
            SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
            if (lobRefEnlace != null)
            {
                gdspTimerSistema.Stop(); // para que se finalice el timer
                fcvLiberarObjetos();
                this.Close();
                lobRefEnlace.fcvBuscarRegistro(tcrCodigSelect);
            }
        }
        #endregion
        #region Vista menus desplegables
        private void fcvMostrarMenuEdicion(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #endregion
        //-------------------------------------------------
        // Gestion vista errores
        //-------------------------------------------------
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
            lobDlgLogs.fcvCargarVista("Vista errores", tmpLogErrores);
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
            this.Close();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            gdspTimerSistema.Stop(); // para que se finalice el timer
            fcvLiberarObjetos();
            this.Close();
        }
        private void fcvLiberarObjetos()
        {
            foreach (var lobReg in tmpDatosDetalle)
            {
                var lobDetalle = lobReg.RefObjeto as ControlOrdServiciosDetalleEdt;
                if (lobDetalle != null)
                {
                    lobDetalle.cmdEliminar.Click -= new RoutedEventHandler(fcvEliminarRegDetalle);
                    lobDetalle.cmdModificar.Click -= new RoutedEventHandler(fcvModificarRegDetalle);
                }
            }
        }
        // cuando se activa o se desactiva el chkBox estando en modo edicion
        private void chkG1Cto_suminv_cont_Click(object sender, RoutedEventArgs e)
        {
            flgValidacion();
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
        private void fcvTouchEnterTecladoRt(object sender, TouchEventArgs e)
        {
            if (Process.GetProcessesByName("OSK").Length < 1)
            {
                RichTextBox lobTexto = sender as RichTextBox;
                Process.Start("osk.exe");
                FocusManager.SetFocusedElement(this, lobTexto);
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
        private void fcvMoverFocus_KeyDownRt(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((RichTextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }
        private void fcvTextBox_GotFocusRt(object sender, RoutedEventArgs e)
        {
            RichTextBox tb = e.Source as RichTextBox;
            tb.SelectAll();
        }
        #endregion
        //-------------------------------------------------
        //  KeyDown llamada funciones compos con F2
        //-------------------------------------------------
        #region llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("HCL", "HCLREGORDESERVI", "", "Maestro ordenes servicios...");
            gcrCtrF2TexBox = "txtG1Hcl_nroreg_hcor";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region fcvBrowsMedicamentos Buscar Medicamentos en farmacia o Vademecum
        private void fcvBrowsMedicamentos(object sender, RoutedEventArgs e)
        {
            var lcrFiltro = String.Empty;
            MenuItem lobOp = (MenuItem)sender;
            switch (lobOp.Name)
            {
                case "opFarmacia": // Buscar existencias Farmacacia

                    lcrFiltro = "Fcmmanservicios.fcm_codman_mans='" + tmpRegAdm.Fcm_codman_mans.Trim() + "'";
                    if (this.chkG1Cto_suminv_cont.IsChecked == true)
                    {
                        Browser01Ex frbro = new Browser01Ex("INV", "INVALMACEXISTEN-SERV-IPS-CODAUX", tmpRegContrato.inv_codalm_inal, gcrNombreAlmacen + "...");
                        gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";
                        frbro.Owner = this;
                        frbro.ShowDialog();
                    }
                    else
                    {
                        Browser01Ex frbro = new Browser01Ex("FCM", "FCMMANSERVICIOSIU", lcrFiltro, "Maestro de servicios ...");
                        gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";
                        frbro.Owner = this;
                        frbro.ShowDialog();
                    }

                    break;

                case "opVademecum": // Browser vademecum para formulas medicas (plan de manejo externo)

                    if (gcrTipoPlanManejo == "2") // Solo para formulas medicas
                    {
                        var frbro = new Browser01Ex("FAR", "FAREXPEDMEDICMD", "", "listado general de medicamentos...");
                        gcrCtrF2TexBox = "ADD-MEDICAMENTO-VADEMECUM";
                        frbro.Owner = this;
                        frbro.ShowDialog();
                    }
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
                case "txtG1Sia_codpfa_prof":
                    this.txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_coddig_mant":
                    tmpRegDetalle.Hcl_tserax_hcor = "NA";
                    this.txtG1Fcm_coddig_mant.Text = tcrCodigo;
                    break;

                case "ADD-MEDICAMENTO-FARMACIA":
                    tmpRegDetalle.Hcl_tserax_hcor = "NA";
                    this.txtG1Fcm_coddig_mant.Text = tcrCodigo;
                    break;

                case "ADD-MEDICAMENTO-VADEMECUM":

                    this.chkG1Cto_suminv_cont.IsChecked = false;
                    tmpRegDetalle.Hcl_tserax_hcor = "1";
                    this.txtG1Fcm_coddig_mant.Text = tcrCodigo;

                    break;

                case "txtG1Fcm_codcpr_cpro":
                    this.txtG1Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        #region FCM_IDESEC_SIPS : Maestro de medicamentos manual de ventas
        private void txtG1Fcm_idesec_sips_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                fcvBuscarServicio_Browser();
            }
        }
        private void fcvBuscarServicio(object sender, RoutedEventArgs e)
        {
            fcvBuscarServicio_Browser();
        }
        private void fcvBuscarServicio_Browser()
        {
            var lcrFiltro = "Fcmmanservicios.fcm_codman_mans='" + tmpRegAdm.Fcm_codman_mans.Trim() + "'";
            if (this.chkG1Cto_suminv_cont.IsChecked == true)
            {
                Browser01Ex frbro = new Browser01Ex("INV", "INVALMACEXISTEN-SERV-IPS-CODAUX", tmpRegContrato.inv_codalm_inal, gcrNombreAlmacen + "...");
                gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
            else
            {
                Browser01Ex frbro = new Browser01Ex("FCM", "FCMMANSERVICIOSIU", lcrFiltro, "Maestro de servicios ...");
                gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";
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
                Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
                gcrCtrF2TexBox = "txtG1Sia_codpfa_prof";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODPFA_PROF : Browser desde boton - Profesionales que prestan servicios
        private void fcvBuscarProfesional(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
            gcrCtrF2TexBox = "txtG1Sia_codpfa_prof";
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
        #region INV_CODALM_INAL : Tabla Maestro almacenes
        private void txtG1Inv_codalm_inal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Inv_codalm_inal_Browser();
            }
        }
        private void cmdG1Inv_codalm_inal_Click(object sender, RoutedEventArgs e)
        {
            txtG1Inv_codalm_inal_Browser();
        }
        private void txtG1Inv_codalm_inal_Browser()
        {
            /*
            Browser01 frbro = new Browser01("INV", "INVALMACENMAEST", "", "Tabla Maestro almacenes...");
            gcrCtrF2TexBox = "txtG1Inv_codalm_inal";
            frbro.Owner = this;
            frbro.ShowDialog()
                */
        }
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
        // Actualizar Objeto TextBox desde CombBox
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
                        case "cboG1Hcl_tipser_hcor":
                            /*
                            txtG1Hcl_tipser_hcor.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_tipser_hcor.Text, ",", lobList.ListaValoresSel)-1;
                            */
                            this.txtG1Hcl_tipser_hcor.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, txtG1Hcl_tipser_hcor.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_tipser_hcor.Text, ",", lobList.ListaValoresSel);

                            fcvActivarTabs(this.txtG1Hcl_tipser_hcor.Text);
                            break;

                        case "cboG1Hcl_aplmed_hcor":
                            this.txtG1Hcl_aplmed_hcor.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_aplmed_hcor.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_aplmed_hcor.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Hcl_termed_hcor":
                            this.txtG1Hcl_termed_hcor.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_termed_hcor.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_termed_hcor.Text, ",", lobList.ListaValoresSel);
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
        // Actualizar ComboBox desde Campo Texto
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
                        case "txtG1Hcl_tipser_hcor":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Hcl_tipser_hcor.SelectedItem;
                            cboG1Hcl_tipser_hcor.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            fcvActivarTabs(this.txtG1Hcl_tipser_hcor.Text);
                            break;

                        case "txtG1Hcl_aplmed_hcor":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Hcl_aplmed_hcor.SelectedItem;
                            cboG1Hcl_aplmed_hcor.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;

                        case "txtG1Hcl_termed_hcor":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Hcl_termed_hcor.SelectedItem;
                            cboG1Hcl_termed_hcor.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;

                    }
                    //fcrValidacion(lobTexto.Name);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarComboBoxOpcion");
            }
        }
        #endregion
        #region fcvActivarTabs: activa el tabs segun el tipo registro a diligenciar
        /// <summary>
        /// <para>activa el tabs segun el tipo registro a diligenciar</para>
        /// <para>tcrTipoVista: "1" = Medicamentos "2" = Indicacion medica</para>
        /// </summary>
        private void fcvActivarTabs(String tcrTipoVista)
        {
            if (tcrTipoVista == "1") // Medicamentos
            {
                if (gcrTipoRegistro != "1")
                {
                    gcrTipoRegistro = "1";
                    this.pagMedicam.Visibility = Visibility.Visible;
                    this.pagInidMed.Visibility = Visibility.Collapsed;
                    pagDatos.SelectedItem = pagMedicam;
                    this.txtG1Hcl_tipser_hcor.Text = "1";
                }
            }
            else // Inidicacion medica
            {
                if (gcrTipoRegistro != "2")
                {
                    gcrTipoRegistro = "2";
                    this.pagMedicam.Visibility = Visibility.Collapsed;
                    this.pagInidMed.Visibility = Visibility.Visible;
                    pagDatos.SelectedItem = pagInidMed;
                    this.txtG1Hcl_tipser_hcor.Text = "2";
                    this.chkG1Cto_suminv_cont.IsChecked = false;
                }
            }
            // al iniciar captura para esta pestaña
            tmpLogErrores = new List<LogsErrores>();
            this.cmdLogErrores.IsEnabled = false;

            // Validar si el contrato entrega medicamentos en farmacia
            fcvCargarNuevoRegVistaActivarOpFarmacia();
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
                    case "dpkG1Hcl_gesfec_hcor":
                        txtG1Hcl_gesfec_hcor.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcor);
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
                            case "txtG1Hcl_gesfec_hcor":
                                dpkG1Hcl_gesfec_hcor.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                        }
                    }
                    llgModoEdicionKey = true;
                    fcrValidacion(lobTexto.Name);
                    llgModoEdicionKey = false;
                    llgModoEdicionValid = false;
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
                    llgModoEdicionKey = true;
                    fcrValidacion(lobTexto.Name);
                    llgModoEdicionKey = false;
                    llgModoEdicionValid = false;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvCampturaHora.");
            }
        }
        #endregion
        //-------------------------------------------------
        // CARGAR DATOS EN VARIABLES O TEMPORAL 
        //-------------------------------------------------
        #region fcvIniciarVariables: Iniciar las variables de la vista
        private void fcvCargarIniciarVariables()
        {
            tmpRegMaestro = new ModeloHclregordeserms();
            tmpRegDetalle = new ModeloHclregordeserde();
            tmpDatosDetalle = new List<ModeloHclregordeserde>();

            if (!String.IsNullOrWhiteSpace(gcrCodigoAdmision))
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision);
                if (lobRegAdm.Count == 0) { return; }

                tmpRegAdm       = lobRegAdm.FirstOrDefault();
                tmpRegContrato  = CTOValidarCodigo.fobRegBuscarCtomaescontrato(tmpRegAdm.Cto_seccon_cont);
            }

            fcvCargarReiniciarVistaRegActivo("1");
            fcvNuevoRegistroDetalles();
        }
        #endregion
        #region flgCargarDatosExitentes: Cargar datos existentes
        /// <summary>
        /// Cargar datos existentes dado el Id unico del Registro R1
        /// </summary>
        private bool flgCargarDatosExitentes(String tcrCodigo)
        {
            var llgExiste = false;
            var lcrCodigo = tcrCodigo;
            fcvCargarIniciarVariables();

            if (!String.IsNullOrWhiteSpace(tcrCodigo))
            {
                var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx("NA", tcrCodigo, "");
                if (lobReg != null && lobReg.Count != 0) 
                {
                    tmpRegMaestro = lobReg.FirstOrDefault();
                    gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;
                    gcrTipoPlanManejo = tmpRegMaestro.Hcl_tipreg_hctr == "FMED" ? "2" : "1";
                    llgExiste = true; 
                }
            }
            else
            {
                var lcrTipoServicio = gcrTipoPlanManejo == "1" ? "SERV" : "FMED";
                var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx(lcrTipoServicio, gcrCodigoAdmision, "1");
                if (lobReg.Count != 0)
                {
                    tmpRegMaestro = lobReg.FirstOrDefault();
                    gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;
                    gcrTipoPlanManejo = tmpRegMaestro.Hcl_tipreg_hctr == "FMED" ? "2" : "1";
                    llgExiste = true;
                }
            }
            this.txtTitulo.Text = gcrTipoPlanManejo == "1" ? "Plan de manejo interno" : "Formula médica";
            // cargar datos
            if (!String.IsNullOrWhiteSpace(gcrCodigoMaestro))
            {
                tmpDatosDetalle = ModeloHclregordeserde.flsListaHclregordeserde("R1", gcrCodigoMaestro);
                fcvCargarVistaRegistroMaestro();
                fcvCargarVistaObjetosDetallServicios();
            }

            return llgExiste;
        }
        #endregion
        #region fcvCargarVistaRegistroMaestro: Cargar vista de variables registro maestro
        /// <summary>
        /// Cargar vista de variables registro maestro
        /// </summary>
        public void fcvCargarVistaRegistroMaestro()
        {
            try
            {
                #region Valores Variables

                if (tmpDatosDetalle != null && tmpDatosDetalle.Count != 0)
                {
                    this.txtG1Fcm_codcpr_cpro.Text = tmpDatosDetalle.FirstOrDefault().Fcm_codcpr_cpro;
                }
                this.txtG1Hcl_gesfec_hcor.Text = tmpRegMaestro.Hcl_gesfec_hcms.ToShortDateString();
                this.txtG1Hcl_geshor_hcor.Text = Funciones.fcrConvierteHora(tmpRegMaestro.Hcl_geshor_hcms.ToString(), "24", gcrSeparadorDecimal, ":");
                this.txtG1Sia_codpfa_prof.Text = tmpRegMaestro.Sia_codpfa_prof;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVistaRegistroMaestro");
            }
        }
        #endregion
        #region fcvCargarVistaVariablesDesdeRegActivo: Cargar vista de variables desde registro activo
        /// <summary>
        /// Cargar vista de variables desde registro activo
        /// </summary>
        public void fcvCargarVistaVariablesDesdeRegActivo()
        {
            try
            {
                #region Valores Variables
                var lobG1Hcl_notreg_hcor = fcvRefRichTextBoxEditor("txtG1Hcl_notreg_hcor");
                var lobG2Hcl_notreg_hcor = fcvRefRichTextBoxEditor("txtG2Hcl_notreg_hcor");

                //gcrTipoRegistro = tmpRegDetalle.Hcl_tipser_hcor;
                this.txtG1Hcl_gesfec_hcor.Text = tmpRegMaestro.Hcl_gesfec_hcms.ToShortDateString();
                this.txtG1Hcl_geshor_hcor.Text = Funciones.fcrConvierteHora(tmpRegMaestro.Hcl_geshor_hcms.ToString(), "24", gcrSeparadorDecimal, ":");
                this.txtG1Fcm_codcpr_cpro.Text = tmpRegDetalle.Fcm_codcpr_cpro;
                this.chkG1Cto_suminv_cont.IsChecked = tmpRegDetalle.Hcl_envalm_hcor == "1"? true : false;

                this.txtG1Hcl_tipser_hcor.Text = tmpRegDetalle.Hcl_tipser_hcor;

                if (tmpRegDetalle.Hcl_tipser_hcor == "1") // Medicamento
                {
                    this.txtG1Fcm_coddig_mant.Text = tmpRegDetalle.Fcm_coddig_mant;
                    this.txtG1Hcl_aplmed_hcor.Text = tmpRegDetalle.Hcl_aplmed_hcor;
                    this.txtG1Hcl_totuni_hcor.Text = tmpRegDetalle.Hcl_totuni_hcor.ToString();
                    this.txtG1Hcl_termed_hcor.Text = tmpRegDetalle.Hcl_termed_hcor;
                    this.txtG1Hcl_nrodia_hcor.Text = tmpRegDetalle.Hcl_termed_hcor == "2" ? tmpRegDetalle.Hcl_nrodia_hcor.ToString() : "0";
                    lobG1Hcl_notreg_hcor.Text      = tmpRegDetalle.Hcl_notreg_hcor;
                }
                else  // Indicacion medica
                {
                    lobG2Hcl_notreg_hcor.Text = tmpRegDetalle.Hcl_notreg_hcor;
                }
                #endregion
                this.lblAgregar.Text = "Actualizar";
                this.cboG1Hcl_tipser_hcor.IsEnabled = false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVistaVariablesDesdeRegActivo");
            }
        }
        #endregion
        #region fcvCargarVistaObjetosDetallServicios: Carga registros en vista detalles
        /// <summary>
        /// <para>Carga registros en vista detalles</para>
        /// </summary>
        public void fcvCargarVistaObjetosDetallServicios()
        {
            if (tmpDatosDetalle != null)
            {
                this.stkDetalles.Children.Clear();

                foreach (var lobReg in tmpDatosDetalle)
                {
                    // Configuracion del registro 
                    var lobDetalle = new ControlOrdServiciosDetalleEdt();
                    lobReg.RefObjeto = lobDetalle;

                    fcvVistaObjetosDatosBasicos(ref lobDetalle, lobReg);
                    flgVistaObjetosValoresRegistro(ref lobDetalle, lobReg);

                    this.stkDetalles.Children.Add(lobDetalle);
                }
            }
        }
        #endregion
        #region fcvCargarActivarObjetosCaptura: Activar o desactivar los objetos de captura de datos
        /// <summary>
        /// <para>Activar o desactivar los objetos de captura de datos</para>
        /// </summary>
        private void fcvCargarActivarObjetosCaptura(bool tlgEstado)
        {
            #region Vista campos
            this.txtG1Hcl_tipser_hcor.IsEnabled = tlgEstado;

            this.txtG1Hcl_gesfec_hcor.IsEnabled = tlgEstado;
            this.txtG1Hcl_geshor_hcor.IsEnabled = tlgEstado;
            this.txtG1Sia_codpfa_prof.IsEnabled = tlgEstado;
            this.txtG1Fcm_codcpr_cpro.IsEnabled = tlgEstado;

            this.txtG1Fcm_coddig_mant.IsEnabled = tlgEstado;
            this.txtG1Hcl_totuni_hcor.IsEnabled = tlgEstado;
            this.txtG1Hcl_nrodia_hcor.IsEnabled = tlgEstado;
            this.txtG1Hcl_aplmed_hcor.IsEnabled = tlgEstado;
            this.txtG1Hcl_termed_hcor.IsEnabled = tlgEstado;
            this.txtG1Hcl_notreg_hcor.IsEnabled = tlgEstado;

            this.cboG1Hcl_tipser_hcor.IsEnabled = tlgEstado;
            this.cboG1Hcl_aplmed_hcor.IsEnabled = tlgEstado;
            this.cboG1Hcl_termed_hcor.IsEnabled = tlgEstado;

            this.txtG2Hcl_notreg_hcor.IsEnabled = tlgEstado;

            // Botones
            this.cmdBrowProfesional.IsEnabled   = tlgEstado;
            this.cmdG1Fcm_codcpr_cpro.IsEnabled = tlgEstado;
            this.dpkG1Hcl_gesfec_hcor.IsEnabled = tlgEstado;
            this.cmdBrowServicios.IsEnabled     = tlgEstado;

            this.cmdAgregar.IsEnabled = tlgEstado;
            this.cmdNuevo.IsEnabled   = tlgEstado;
            this.cmdGuardar.IsEnabled = tlgEstado;
            this.cmdConfirmar.IsEnabled = tlgEstado;

            if (tmpRegMaestro != null)
            {
                this.cmdNuevo.IsEnabled = tmpRegMaestro.Sis_estpro_espr == "1" ? true : false;
            }
            #endregion
        }
        #endregion
        #region fcvCargarReiniciarVistaRegActivo: Limpiar vista de variables para nueva captura de datos
        /// <summary>
        /// <para>Limpiar vista de variables para nueva captura de datos</para>
        /// <para>tcrGrupoVista: 1= Objetos Zona 1 o registro maestro "2"= Objetos de la zona detalles</para>
        /// </summary>
        public void fcvCargarReiniciarVistaRegActivo(String tcrGrupoVista)
        {
            try
            {
                #region Valores Variables
                if (tcrGrupoVista == "1")
                {
                    var lcrCentProduccion = gcrTipoPlanManejo == "1" ? "HCL-SUMHCL-CENT-PRODUC-FARM" : "HCL-SUMHCL-CENT-PRODUC-FARM";
                    this.txtG1Hcl_gesfec_hcor.Text = DateTime.Now.ToShortDateString();
                    this.txtG1Hcl_geshor_hcor.Text = Funciones.fcrHoraActual("12", ":");
                    this.txtG1Fcm_codcpr_cpro.Text = Funciones.fcrLeerConfigVarSistema(lcrCentProduccion);

                    // Almacen para plan de manejo externo si se entregan medicamentos
                    if (gcrTipoPlanManejo == "2")
                    {
                        var tmp = SIAValidarCodigo.fobRegBuscarSiaareapreserviEx(tmpRegAdm.Sia_codare_aser);
                        if (tmp != null)
                        {
                            this.txtG1Inv_codalm_inal.Text = tmp.inv_codalm_inal;
                        }
                    }

                    tmpRegMaestro.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    tmpRegMaestro.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    tmpRegMaestro.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    tmpRegMaestro.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    tmpRegMaestro.Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
                    tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcor.Text);
                    tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
                    tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                    tmpRegMaestro.Sis_estpro_espr = "1";

                }
                else
                {
                    var lobG1Hcl_notreg_hcor = fcvRefRichTextBoxEditor("txtG1Hcl_notreg_hcor");
                    var lobG2Hcl_notreg_hcor = fcvRefRichTextBoxEditor("txtG2Hcl_notreg_hcor");

                    this.txtG1Fcm_coddig_mant.Text = String.Empty;
                    this.txtG1Fcm_desser_sips.Text = String.Empty;
                    this.txtG1Hcl_aplmed_hcor.Text = String.Empty;
                    this.txtG1Hcl_termed_hcor.Text = "2";
                    this.txtG1Hcl_totuni_hcor.Text = "1";
                    this.txtG1Hcl_nrodia_hcor.Text = "0";
                    lobG1Hcl_notreg_hcor.Text      = String.Empty;
                    lobG2Hcl_notreg_hcor.Text      = String.Empty;
                    fcvCargarNuevoRegVistaActivarOpFarmacia();

                    tmpRegDetalle = new ModeloHclregordeserde();

                    this.lblAgregar.Text = "Agregar";
                    this.cboG1Hcl_tipser_hcor.IsEnabled = true;
                }
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarReiniciarVistaRegActivo");
            }
        }
        #endregion
        #region fcvCargarNuevoRegVistaActivarOpFarmacia: Activar Opcion de envio a Farmacia
        /// <summary>
        /// Iniciar valor y vista para el combobox Activar Opcion de envio a Farmacia, en nuevo registro
        /// </summary>
        private void fcvCargarNuevoRegVistaActivarOpFarmacia()
        {
            // Validar si el contrato entrega medicamentos en farmacia
            var lcrValor = "2";
            if (gcrTipoPlanManejo == "2") // solo cuando es formula medica (plan manejo externo)
            {
                lcrValor = tmpRegContrato.cto_suminv_cont == "1" && gcrTipoRegistro == "1" ? "1" : "2";
            }
            fcvVistaActivarOpFarmacia(lcrValor);
        }
        #endregion
        // Funciones auxiliares copiar y actualizar temporal de registros detalle
        #region fcvAuxRegistroActivoDesdeVariables: Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables de la vista
        /// </summary>
        public void fcvAuxRegistroActivoDesdeVariables()
        {
            try
            {
                var lcrCto_suminv_cont = this.chkG1Cto_suminv_cont.IsChecked == true ? "1" : "2";
                #region Valores Variables
                tmpRegDetalle.Hcl_tipser_hcor = this.txtG1Hcl_tipser_hcor.Text;
                tmpRegDetalle.Hcl_gesfec_hcor = Funciones.fdaConvertFecha("DMY", "/", txtG1Hcl_gesfec_hcor.Text);
                tmpRegDetalle.Hcl_geshor_hcor = Decimal.Parse(Funciones.fcrConvierteHora(txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegDetalle.Hcl_sisfec_hcor = DateTime.Now;
                tmpRegDetalle.Hcl_sishor_hcor = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                tmpRegDetalle.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegDetalle.Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
                tmpRegDetalle.Fcm_codcpr_cpro = this.txtG1Fcm_codcpr_cpro.Text;
                tmpRegDetalle.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                tmpRegDetalle.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegDetalle.Hcl_tipreg_hcor = gcrTipoPlanManejo;
                tmpRegDetalle.Hcl_envfac_hcor = lcrCto_suminv_cont; // Enviar a facturacion
                tmpRegDetalle.Hcl_envalm_hcor = lcrCto_suminv_cont; // debe ser segun parametro contrato
                tmpRegDetalle.Hcl_conalm_hcor = lcrCto_suminv_cont; // No por ahora (debe ser segun parametro contrato)
                tmpRegDetalle.Hcl_envfac_hcor = gcrTipoPlanManejo == "1" ? "2" : "1"; // "1" sujeto a lo que diga el contrato
                tmpRegDetalle.Hcl_confac_hcor = tmpRegDetalle.Hcl_envfac_hcor == "1" ? "1" : "2";
                tmpRegDetalle.Sis_estpro_espr = "1";

                var lobG1Hcl_notreg_hcor = fcvRefRichTextBoxEditor("txtG1Hcl_notreg_hcor");
                var lobG2Hcl_notreg_hcor = fcvRefRichTextBoxEditor("txtG2Hcl_notreg_hcor");

                if (this.txtG1Hcl_tipser_hcor.Text == "1") // Medicamento
                {
                    var lcrEnvFarmacia = 
                    tmpRegDetalle.Fcm_codser_sips = this.txtG1Fcm_coddig_mant.Text;
                    tmpRegDetalle.Fcm_desser_sips = this.txtG1Fcm_desser_sips.Text;
                    tmpRegDetalle.Fcm_coddig_mant = this.txtG1Fcm_coddig_mant.Text;
                    tmpRegDetalle.Hcl_notreg_hcor = lobG1Hcl_notreg_hcor.Text;
                    tmpRegDetalle.Hcl_aplmed_hcor = this.txtG1Hcl_aplmed_hcor.Text;
                    tmpRegDetalle.Hcl_totuni_hcor = (int)Convert.ToUInt32(this.txtG1Hcl_totuni_hcor.Text);
                    tmpRegDetalle.Hcl_termed_hcor = this.txtG1Hcl_termed_hcor.Text;
                    tmpRegDetalle.Hcl_nrodia_hcor = tmpRegDetalle.Hcl_termed_hcor == "2" ? (int)Convert.ToUInt32(this.txtG1Hcl_nrodia_hcor.Text) : 0;
                    
                }
                else  // Indicacion medica
                {
                    tmpRegDetalle.Hcl_notreg_hcor = lobG2Hcl_notreg_hcor.Text;
                    // Deben quedar vacios
                    tmpRegDetalle.Fcm_coddig_mant = "NA";
                    tmpRegDetalle.Hcl_aplmed_hcor = String.Empty;
                    tmpRegDetalle.Hcl_termed_hcor = String.Empty;
                    tmpRegDetalle.Hcl_totuni_hcor = 0;
                    tmpRegDetalle.Hcl_nrodia_hcor = 0;

                }
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
            }
        }
        #endregion
        #region fobAuxCopiarRegistro: Copiar Registro desde Registro temporal dado en parametro
        /// <summary>
        /// Copiar Registro desde Registro temporal dado en parametro
        /// </summary>
        public ModeloHclregordeserde fobAuxCopiarRegistro(ModeloHclregordeserde tobRegistro)
        {
            var lobReAux = new ModeloHclregordeserde();
            try
            {
                #region datos
                lobReAux.RefObjeto       = tobRegistro.RefObjeto;
                lobReAux.Hcl_nroreg_hcor = tobRegistro.Hcl_nroreg_hcor;
                lobReAux.Hcl_nroreg_hcms = tobRegistro.Hcl_nroreg_hcms;
                lobReAux.Hcl_secreg_hcor = tobRegistro.Hcl_secreg_hcor;
                lobReAux.Adm_secadm_rgad = tobRegistro.Adm_secadm_rgad;
                lobReAux.Sia_idesec_usua = tobRegistro.Sia_idesec_usua;
                lobReAux.Hcl_tipreg_hcor = tobRegistro.Hcl_tipreg_hcor;
                lobReAux.Fcm_secreg_dfac = tobRegistro.Fcm_secreg_dfac;
                lobReAux.Fcm_idesec_sips = tobRegistro.Fcm_idesec_sips;
                lobReAux.Fcm_coddig_mant = tobRegistro.Fcm_coddig_mant;
                lobReAux.Hcl_totuni_hcor = tobRegistro.Hcl_totuni_hcor;
                lobReAux.Inv_secart_mart = tobRegistro.Inv_secart_mart;
                lobReAux.Hcl_aplmed_hcor = tobRegistro.Hcl_aplmed_hcor;
                lobReAux.Hcl_termed_hcor = tobRegistro.Hcl_termed_hcor;
                lobReAux.Hcl_dester_hcor = tobRegistro.Hcl_dester_hcor;
                lobReAux.Hcl_nrodia_hcor = tobRegistro.Hcl_nrodia_hcor;
                lobReAux.Hcl_gesfec_hcor = tobRegistro.Hcl_gesfec_hcor;
                lobReAux.Hcl_geshor_hcor = tobRegistro.Hcl_geshor_hcor;
                lobReAux.Hcl_tiptur_hctu = tobRegistro.Hcl_tiptur_hctu;
                lobReAux.Sia_codpfa_prof = tobRegistro.Sia_codpfa_prof;
                lobReAux.Fcm_codcpr_cpro = tobRegistro.Fcm_codcpr_cpro;
                lobReAux.Sia_codare_aser = tobRegistro.Sia_codare_aser;
                lobReAux.Hcl_sisfec_hcor = tobRegistro.Hcl_sisfec_hcor;
                lobReAux.Hcl_sishor_hcor = tobRegistro.Hcl_sishor_hcor;
                lobReAux.Hcl_notreg_hcor = tobRegistro.Hcl_notreg_hcor;
                lobReAux.Hcl_tipser_hcor = tobRegistro.Hcl_tipser_hcor;
                lobReAux.Hcl_tserax_hcor = tobRegistro.Hcl_tserax_hcor;
                lobReAux.Hcl_envfac_hcor = tobRegistro.Hcl_envfac_hcor;
                lobReAux.Hcl_envalm_hcor = tobRegistro.Hcl_envalm_hcor;
                lobReAux.Hcl_confac_hcor = tobRegistro.Hcl_confac_hcor;
                lobReAux.Hcl_conalm_hcor = tobRegistro.Hcl_conalm_hcor;
                lobReAux.Sis_estpro_espr = tobRegistro.Sis_estpro_espr;
                lobReAux.Sia_nompro_prof = tobRegistro.Sia_nompro_prof;
                lobReAux.Fcm_desser_sips = tobRegistro.Fcm_desser_sips;
                lobReAux.Fcm_codser_sips = tobRegistro.Fcm_codser_sips;
                lobReAux.Fcm_descpr_cpro = tobRegistro.Fcm_descpr_cpro;
                lobReAux.Sia_desare_aser = tobRegistro.Sia_desare_aser;
                lobReAux.Sis_estado_imaen = tobRegistro.Sis_estado_imaen;
                #endregion

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAuxRegistroActivoDesdeTemporal");
            }
            return lobReAux;
        }
        #endregion
        #region fobAuxActualizarEnMaestroTemporal: Actualizar el registro modificado en pantalla
        /// <summary>
        /// Actualizar en temporal maestro detalles el registro modificado en pantalla
        /// </summary>
        public void fcvAuxActualizarEnMaestroTemporal(ModeloHclregordeserde tobRegistro)
        {
            try
            {
                var lobReAux = tmpDatosDetalle.FirstOrDefault(x => x.Hcl_nroreg_hcor == tobRegistro.Hcl_nroreg_hcor);
                if (lobReAux != null)
                {
                    #region datos
                    //lobReAux.RefObjeto = tobRegistro.RefObjeto;
                    lobReAux.Hcl_nroreg_hcor = tobRegistro.Hcl_nroreg_hcor;
                    lobReAux.Hcl_nroreg_hcms = tobRegistro.Hcl_nroreg_hcms;
                    lobReAux.Hcl_secreg_hcor = tobRegistro.Hcl_secreg_hcor;
                    lobReAux.Adm_secadm_rgad = tobRegistro.Adm_secadm_rgad;
                    lobReAux.Sia_idesec_usua = tobRegistro.Sia_idesec_usua;
                    lobReAux.Hcl_tipreg_hcor = tobRegistro.Hcl_tipreg_hcor;
                    lobReAux.Fcm_secreg_dfac = tobRegistro.Fcm_secreg_dfac;
                    lobReAux.Fcm_idesec_sips = tobRegistro.Fcm_idesec_sips;
                    lobReAux.Fcm_coddig_mant = tobRegistro.Fcm_coddig_mant;
                    lobReAux.Hcl_totuni_hcor = tobRegistro.Hcl_totuni_hcor;
                    lobReAux.Inv_secart_mart = tobRegistro.Inv_secart_mart;
                    lobReAux.Hcl_aplmed_hcor = tobRegistro.Hcl_aplmed_hcor;
                    lobReAux.Hcl_termed_hcor = tobRegistro.Hcl_termed_hcor;
                    lobReAux.Hcl_dester_hcor = tobRegistro.Hcl_dester_hcor;
                    lobReAux.Hcl_nrodia_hcor = tobRegistro.Hcl_nrodia_hcor;
                    lobReAux.Hcl_gesfec_hcor = tobRegistro.Hcl_gesfec_hcor;
                    lobReAux.Hcl_geshor_hcor = tobRegistro.Hcl_geshor_hcor;
                    lobReAux.Hcl_tiptur_hctu = tobRegistro.Hcl_tiptur_hctu;
                    lobReAux.Sia_codpfa_prof = tobRegistro.Sia_codpfa_prof;
                    lobReAux.Fcm_codcpr_cpro = tobRegistro.Fcm_codcpr_cpro;
                    lobReAux.Sia_codare_aser = tobRegistro.Sia_codare_aser;
                    lobReAux.Hcl_sisfec_hcor = tobRegistro.Hcl_sisfec_hcor;
                    lobReAux.Hcl_sishor_hcor = tobRegistro.Hcl_sishor_hcor;
                    lobReAux.Hcl_notreg_hcor = tobRegistro.Hcl_notreg_hcor;
                    lobReAux.Hcl_tipser_hcor = tobRegistro.Hcl_tipser_hcor;
                    lobReAux.Hcl_tserax_hcor = tobRegistro.Hcl_tserax_hcor;
                    lobReAux.Hcl_envfac_hcor = tobRegistro.Hcl_envfac_hcor;
                    lobReAux.Hcl_envalm_hcor = tobRegistro.Hcl_envalm_hcor;
                    lobReAux.Hcl_confac_hcor = tobRegistro.Hcl_confac_hcor;
                    lobReAux.Hcl_conalm_hcor = tobRegistro.Hcl_conalm_hcor;
                    lobReAux.Sis_estpro_espr = tobRegistro.Sis_estpro_espr;
                    lobReAux.Sia_nompro_prof = tobRegistro.Sia_nompro_prof;
                    lobReAux.Fcm_desser_sips = tobRegistro.Fcm_desser_sips;
                    lobReAux.Fcm_codser_sips = tobRegistro.Fcm_codser_sips;
                    lobReAux.Fcm_descpr_cpro = tobRegistro.Fcm_descpr_cpro;
                    lobReAux.Sia_desare_aser = tobRegistro.Sia_desare_aser;
                    lobReAux.Sis_estado_imaen = tobRegistro.Sis_estado_imaen;
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fobAuxActualizarEnMaestroTemporal");
            }
        }
        #endregion
        // Actualizar objeto en grilla
        #region fcvVistaObjetosDatosBasicos: Enlazar Procedimientos al objeto y modo vista
        /// <summary>
        /// <para>Enlazar Procedimientos al objeto y modo vista del registro en la grilla</para>
        /// </summary>
        public void fcvVistaObjetosDatosBasicos(ref ControlOrdServiciosDetalleEdt tobDetalle, ModeloHclregordeserde tobRegistro)
        {
            if (tobDetalle != null && tobRegistro != null)
            {
                tobDetalle.cmdEliminar.Click += new RoutedEventHandler(fcvEliminarRegDetalle);
                tobDetalle.cmdModificar.Click += new RoutedEventHandler(fcvModificarRegDetalle);

                // Datos requeridos
                tobDetalle.IdRegistro = tobRegistro.Hcl_nroreg_hcor;
                tobDetalle.IdR1Registro = tobRegistro.Hcl_nroreg_hcms;
                tobDetalle.cmdEliminar.Visibility = tobRegistro.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                tobDetalle.cmdModificar.Visibility = tobRegistro.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                tobDetalle.imgEstado.Visibility = tobRegistro.Sis_estpro_espr == "1" ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        #endregion
        #region flgVistaObjetosValoresRegistro: Mostrar datos del registro en objeto detalles
        /// <summary>
        /// <para>Mostrar datos del registro en objeto detalles</para>
        /// </summary>
        public bool flgVistaObjetosValoresRegistro(ref ControlOrdServiciosDetalleEdt tobDetalle, ModeloHclregordeserde tobRegistro)
        {
            var llgReturn = false;
            if (tobDetalle != null && tobRegistro != null)
            {
                llgReturn = true;

                // Medicamentos
                if (tobRegistro.Hcl_tipser_hcor == "1")
                {
                    // Cuando es un medicamento desde Vademecum
                    tobDetalle.txtDetalle.Text = String.Empty;
                    if (tobRegistro.Hcl_tserax_hcor != null)
                    {
                        if (tobRegistro.Hcl_tserax_hcor == "1")
                        {
                            // consulta desde vademecum farmacia
                            var lobReAx = FARValidarCodigo.fobRegBuscarFarexpedmedicmdCUM(tobRegistro.Fcm_coddig_mant);
                            tobDetalle.txtDetalle.Text = lobReAx.far_precom_famd;
                        }
                    }

                    //tobDetalle.txtDetalle.Text    = tobRegistro.Fcm_codser_sips + " - " + tobRegistro.Fcm_desser_sips;
                    tobDetalle.txtDetalle.Text      = String.IsNullOrWhiteSpace(tobDetalle.txtDetalle.Text) ?
                                                                    tobRegistro.Fcm_codser_sips + " - " + tobRegistro.Fcm_desser_sips : tobDetalle.txtDetalle.Text;

                    tobDetalle.txtCantidad.Text     = tobRegistro.Hcl_totuni_hcor.ToString();
                    tobDetalle.txtObservacion.Text  = tobRegistro.Hcl_notreg_hcor;
                    tobDetalle.txtDias.Text         = tobRegistro.Hcl_termed_hcor == "1" ? "INDEFINIDO" : tobRegistro.Hcl_nrodia_hcor.ToString();

                    tobDetalle.grdTituloDetalle.Visibility    = Visibility.Visible;
                    tobDetalle.grdIndicacion.Visibility       = Visibility.Collapsed;
                    tobDetalle.lblTituloIndicacion.Visibility = Visibility.Collapsed;
                }
                else
                {
                    // Inidicaciones medicas
                    tobDetalle.grdIndicacion.Visibility         = Visibility.Visible;
                    tobDetalle.txtInidicacion.Text              = tobRegistro.Hcl_notreg_hcor;
                    tobDetalle.lblTituloIndicacion.Visibility   = Visibility.Visible;
                    tobDetalle.grdMedicamento.Visibility        = Visibility.Collapsed;
                    tobDetalle.grdTituloDetalle.Visibility      = Visibility.Collapsed;
                }

            }
            return llgReturn;
        }
        #endregion
        // Mostrar opcion para envio medicamentos a farmacia
        #region fcvVistaActivarOpFarmacia: Activar opcion para envio de medicamentos a entrega farmacia
        /// <summary>
        /// <para>activa ComboBox para seleccion entrega medicamentos en farmacia</para>
        /// <para>tcrTipoVista: "1"=Mostrar opcion "2"=Ocultar la Opcion</para>
        /// <para>tcrValor: Valor a cargar en opcion 1=Si se entrega medicamento 2=No se entrega medicamento</para>
        /// </summary>
        private void fcvVistaActivarOpFarmacia(String tcrValor)
        {
            var lcrVista = "2";
            if (gcrTipoPlanManejo == "2") // solo cuando es formula medica (plan manejo externo)
            {
                lcrVista = tmpRegContrato.cto_suminv_cont == "1" && gcrTipoRegistro == "1" ? "1" : "2";
            }
            this.grdEntregaMedicFarmaPar.Visibility = lcrVista == "1" ? Visibility.Visible : Visibility.Collapsed;
            this.grdEntregaMedicFarmacia.Visibility = lcrVista == "1" ? Visibility.Visible : Visibility.Collapsed;
            this.chkG1Cto_suminv_cont.IsChecked = lcrVista == "1" ? true : false;
        }
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
            if (!llgObjetosCargados) { return; }

            llgModoEdicionKey = true;
            var lobTextBox = sender as TextBox;
            fcrValidacion(lobTextBox.Name);
            llgModoEdicionKey = false;
            llgModoEdicionValid = false;
        }
        #endregion
        #region fcvValidacionTextoRt: Validacion campos Editor
        /// <summary>
        /// <para>Validacion campos</para>
        /// </summary>
        private void fcvValidacionTextoRt(object sender, TextChangedEventArgs e)
        {
            if (!llgObjetosCargados) { return; }

            llgModoEdicionKey = true;
            var lobTextBox = sender as RichTextBox;
            fcrValidacion(lobTextBox.Name);
            llgModoEdicionKey = false;
            llgModoEdicionValid = false;
        }
        #endregion
        #region flgValidacion: Valida todos los datos antes de guardar
        /// <summary>
        /// Valida todos los datos antes de guardar
        /// </summary>
        public bool flgValidacion()
        {
            var lnuCont1 = 0;
            var lnuCont2 = 0;
            var llgMaestro = tmpRegMaestro.Sis_estpro_espr == "1" ? true : false;

            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_gesfec_hcor"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_geshor_hcor"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codpfa_prof"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Fcm_codcpr_cpro"))) { lnuCont1++; }
            if (gcrTipoRegistro == "1")
            {
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_tipser_hcor"))) { lnuCont2++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Fcm_coddig_mant"))) { lnuCont2++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_totuni_hcor"))) { lnuCont2++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_nrodia_hcor"))) { lnuCont2++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_aplmed_hcor"))) { lnuCont2++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_termed_hcor"))) { lnuCont2++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_notreg_hcor"))) { lnuCont2++; }
                // Solo cuando sea plan de manejo externo
                if (gcrTipoPlanManejo == "2" && tmpRegContrato.cto_suminv_cont == "1") // y que el contrato entrega medicamentos
                {
                    if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Inv_codalm_inal"))) { lnuCont2++; }
                }
            }
            else 
            {
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_tipser_hcor"))) { lnuCont2++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG2Hcl_notreg_hcor"))) { lnuCont2++; }
            }
            this.cmdAgregar.IsEnabled = lnuCont1 + lnuCont2 > 0 ? false : true;
            this.cmdGuardar.IsEnabled = lnuCont1 > 0 ? false : tmpDatosDetalle.Count != 0 && llgMaestro == true ? true : false;
            this.cmdConfirmar.IsEnabled = lnuCont1 > 0 ? false : tmpDatosDetalle.Count != 0 && llgMaestro == true ? true : false;

            return lnuCont1 == 0 ? true : false;
        }
        #endregion
        #region Validacion Campos: fcrValidacion
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        /// </summary>
        public String fcrValidacion(String tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgValidaServIPS = true;

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "txtG1Fcm_coddig_mant":
                        #region Validacion
                        lcrNombreCampo = "Código medicamento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";

                        fcvCargarDatosParaLiquidarServ();
                        this.txtG1Fcm_coddig_mant.Text  = this.txtG1Fcm_coddig_mant.Text.ToUpper().Trim();
                        gobLiq.G2Fcm_coddig_mant        = this.txtG1Fcm_coddig_mant.Text;

                        if (String.IsNullOrWhiteSpace(this.txtG1Fcm_coddig_mant.Text))
                        {
                            lcrValorReturn = "Código medicamento: Es requerido";
                        }
                        else
                        {
                            llgValidaServIPS = false;
                            lcrValorReturn = fcrValidaCodigoDigitacionAlmacen();

                            if (lcrValorReturn == "OK")
                            {
                                if (tmpRegDetalle.Hcl_tserax_hcor == "1") // Medicamento desde vademecum
                                {
                                    lcrValorReturn = fcrValidaCodigoDigitacionVademecum();
                                }
                                else
                                {
                                    lcrValorReturn = String.Empty;
                                    llgValidaServIPS = true;
                                }
                            }
                            if (llgValidaServIPS == true)
                            {
                                lcrValorReturn = fcrValidaCodigoDigitacionIPS(lcrNumeroRegistro, lcrNombreCampo);
                            }
                        }
                        fcvSetColorValidacion(txtG1Fcm_coddig_mant,lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_totuni_hcor":
                        #region Validacion
                        lcrNombreCampo = "Total unidades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_totuni_hcor.Text))
                        {
                            lcrValorReturn = "Total unidades: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumeros(this.txtG1Hcl_totuni_hcor.Text))
                            {
                                if (Convert.ToUInt32(this.txtG1Hcl_totuni_hcor.Text) < 1 || Convert.ToUInt32(this.txtG1Hcl_totuni_hcor.Text) > 500)
                                {
                                    lcrValorReturn = "Total unidades: Valor fuera del rango";
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Total unidades: Valor debe ser númerico";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_totuni_hcor, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_gesfec_hcor":
                        #region Validacion
                        lcrNombreCampo = "Fecha del servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", txtG1Hcl_gesfec_hcor.Text, "Fecha servicio");
                        fcvSetColorValidacion(txtG1Hcl_gesfec_hcor, lcrValorReturn);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            txtG1Hcl_gesfec_hcor.BorderBrush = Brushes.White;
                        }
                        break;
                        #endregion

                    case "txtG1Hcl_geshor_hcor":
                        #region Validacion
                        lcrNombreCampo = "Hora servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, txtG1Hcl_geshor_hcor.Text, "12", ":", "Hora servicio");
                        fcvSetColorValidacion(txtG1Hcl_geshor_hcor, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_tipser_hcor":
                        #region Validacion
                        lcrNombreCampo = "Tipo orden servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (string.IsNullOrWhiteSpace(txtG1Hcl_tipser_hcor.Text))
                        {
                            lcrValorReturn = "Tipo orden servicio: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(txtG1Hcl_tipser_hcor.Text, ",", "1,2"))
                            {
                                lcrValorReturn = "Tipo orden servicio: Dato no es valido";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_tipser_hcor, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_aplmed_hcor":
                        #region Validacion
                        lcrNombreCampo = "Aplicación medicamento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (string.IsNullOrWhiteSpace(this.txtG1Hcl_aplmed_hcor.Text))
                        {
                            lcrValorReturn = "Aplicación medicamento: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtG1Hcl_aplmed_hcor.Text, ",", "1,2,3,4,5"))
                            {
                                lcrValorReturn = "Via aplicación medicamento: Dato no es valido";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_aplmed_hcor, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_termed_hcor":
                        #region Validacion
                        lcrNombreCampo = "Termino de uso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (string.IsNullOrWhiteSpace(this.txtG1Hcl_termed_hcor.Text))
                        {
                            lcrValorReturn = "Termino de uso: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtG1Hcl_termed_hcor.Text, ",", "1,2"))
                            {
                                lcrValorReturn = "Termino de uso: Dato no es valido";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_termed_hcor, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_nrodia_hcor":
                        #region Validacion
                        lcrNombreCampo = "Numero dias uso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(this.txtG1Hcl_nrodia_hcor.Text))
                        {
                            lcrValorReturn = "Numero dias uso: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (this.txtG1Hcl_termed_hcor.Text =="2") // cuando es termino definido
                            {
                                if (Funciones.flgSoloNumeros(this.txtG1Hcl_nrodia_hcor.Text))
                                {

                                    if (Convert.ToUInt32(this.txtG1Hcl_nrodia_hcor.Text) < 1 || Convert.ToUInt32(this.txtG1Hcl_nrodia_hcor.Text) > 450)
                                    {
                                        lcrValorReturn = "Numero dias: Valor fuera del rango";
                                    }
                                }
                                else
                                {
                                    lcrValorReturn = "Numero dias: Valor debe ser númerico";
                                }
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_nrodia_hcor, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_notreg_hcor":
                        #region Validacion
                        lcrNombreCampo = "Indiciación medica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        var lobG1Hcl_notreg_hcor = fcvRefRichTextBoxEditor("txtG1Hcl_notreg_hcor");

                        if (String.IsNullOrWhiteSpace(lobG1Hcl_notreg_hcor.Text))
                        {
                            lcrValorReturn = "Indiciación medica: Es requerida";
                        }
                        fcvSetColorValidacionRt(txtG1Hcl_notreg_hcor, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG2Hcl_notreg_hcor":
                        #region Validacion
                        lcrNombreCampo = "Indiciación medica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        var lobG2Hcl_notreg_hcor = fcvRefRichTextBoxEditor("txtG2Hcl_notreg_hcor");

                        if (String.IsNullOrWhiteSpace(lobG2Hcl_notreg_hcor.Text))
                        {
                            lcrValorReturn = "Indiciación medica: Es requerida";
                        }
                        fcvSetColorValidacionRt(txtG2Hcl_notreg_hcor, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Sia_codpfa_prof":
                        #region Validacion
                        lcrNombreCampo = "Profesional que atiende";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (string.IsNullOrWhiteSpace(this.txtG1Sia_codpfa_prof.Text))
                        {
                            lcrValorReturn = "Profesional que atiende: Es requerido";
                        }
                        else
                        {
                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(this.txtG1Sia_codpfa_prof.Text);
                            if (tmp != null && tmp.sia_nompro_prof != null)
                            {
                                this.txtG1Sia_nompro_prof.Text = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = "Profesional que atiende: No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codpfa_prof, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Fcm_codcpr_cpro":
                        #region Validacion
                        lcrNombreCampo = "Código centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (string.IsNullOrWhiteSpace(this.txtG1Fcm_codcpr_cpro.Text))
                        {
                            lcrValorReturn = "Código centro producción: Es requerido";
                        }
                        else
                        {
                            EFfcmcenproduccio tmp = new EFfcmcenproduccio();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(this.txtG1Fcm_codcpr_cpro.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codcpr_cpro))
                            {
                                this.txtG1Fcm_descpr_cpro.Text = tmp.fcm_descpr_cpro;
                                tmpRegDetalle.Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro;
                                tmpRegDetalle.Sia_codare_aser = String.IsNullOrWhiteSpace(tmpRegDetalle.Sia_codare_aser) ? 
                                                                                          tmp.sia_codare_aser : tmpRegDetalle.Sia_codare_aser;
                            }
                            else
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        fcvSetColorValidacion(txtG1Fcm_codcpr_cpro, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Inv_codalm_inal":
                        #region Código Almacén
                        lcrNombreCampo = "Código Almacén";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (this.txtG1Inv_codalm_inal.Text != "NA" && this.chkG1Cto_suminv_cont.IsChecked == true)
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvalmacenmaest(this.txtG1Inv_codalm_inal.Text);
                            if (tmp != null)
                            {
                                this.txtG1Inv_desalm_inal.Text = tmp.inv_desalm_inal;
                                gcrNombreAlmacen = tmp.inv_desalm_inal;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion
                }

                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                            lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);

                this.cmdLogErrores.IsEnabled = tmpLogErrores.Count > 0 ? true : false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        private void fcvSetColorValidacion(TextBox tobObjeto, String tcrValorReturn)
        {
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(tcrValorReturn);
            if (!String.IsNullOrWhiteSpace(tcrValorReturn))
            {
                tobObjeto.BorderBrush = Brushes.Red;

            }
            else
            {
                tobObjeto.BorderBrush = Brushes.DarkTurquoise;
            }
        }
        private void fcvSetColorValidacionRt(RichTextBox tobObjeto, String tcrValorReturn)
        {
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(tcrValorReturn);
            if (!String.IsNullOrWhiteSpace(tcrValorReturn))
            {
                tobObjeto.BorderBrush = Brushes.Red;

            }
            else
            {
                tobObjeto.BorderBrush = Brushes.DarkTurquoise;
            }
        }
        #endregion
        #region fcvCargarDatosParaLiquidarServ: Cargar datos en clase para validar
        /// <summary>
        /// <para>Cargar datos en clase para validar digitacion y liquidacion de servicios</para>  
        /// </summary>
        public void fcvCargarDatosParaLiquidarServ()
        {
            gobLiq.tmpRegAdm = tmpRegAdm;
            // Datos basicos del registro facturado
            gobLiq.G2Adm_codtat_tatn = tmpRegAdm.Adm_codtat_tatn;
            gobLiq.G2Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
            gobLiq.G2Cto_seccon_cont = tmpRegAdm.Cto_seccon_cont;
            gobLiq.G2Fcm_codcpr_cpro = this.txtG1Fcm_codcpr_cpro.Text;
            gobLiq.G2Fcm_fecser_dfac = this.txtG1Hcl_gesfec_hcor.Text;
            gobLiq.G2Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
            gobLiq.G2Sia_aresol_aser = tmpRegAdm.Sia_codare_aser;
            gobLiq.G2Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
            gobLiq.G2Fcm_fecfac_mfac = this.txtG1Hcl_gesfec_hcor.Text;
            gobLiq.G2Fcm_horser_dfac = Funciones.fcrHoraActual("24", gcrSeparadorDecimal);
            gobLiq.G2Fac_horprs_dfac = gobLiq.G2Fcm_horser_dfac;
            gobLiq.G2Fcm_fecedt_dfac = Funciones.fcrFechaActual();
            gobLiq.G2Fcm_estfac_mfac = "1";
            gobLiq.G2Fcm_tiprfa_mfac = "1";
            gobLiq.G2Fcm_codman_mans = tmpRegContrato.fcm_codman_mans;
            gobLiq.G2Cto_seccon_cont = tmpRegContrato.cto_seccon_cont;
            gobLiq.G2Cto_serper_cont = tmpRegContrato.cto_serper_cont;
        }
        #endregion
        // Validacion Codigo de digitacion del medicamento o insumo
        #region fcrValidaCodigoDigitacionAlmacen: Validar codigo en existencias y cantidad
        /// <summary>
        /// <para>Validar codigo Medicamento en existencias almacen y cantidad</para>  
        /// </summary>
        public String fcrValidaCodigoDigitacionAlmacen()
        {
            var lcrValorReturn = "OK";
            gnuTotalUnidExisten = 0;

            #region Cuando es insumo o medicamento para descargar
            if (this.chkG1Cto_suminv_cont.IsChecked == true)
            {
                // Verificar 
                var lobReg = tmpDatosDetalle.FirstOrDefault(x => x.Fcm_coddig_mant == this.txtG1Fcm_coddig_mant.Text);
                if (lobReg != null)
                {
                    if (lobReg.Hcl_nroreg_hcor != tmpRegDetalle.Hcl_nroreg_hcor)
                    {
                        lcrValorReturn = "Ya existe un registro en la lista para el codigo: " + " - " + this.txtG1Fcm_coddig_mant.Text;
                    }
                }

                if (lcrValorReturn == "OK")
                {
                    var lobreAx = ModeloInvAlmacenExistencias.fobRegInvalmacexistenAlm(tmpRegContrato.inv_codalm_inal.Trim(), this.txtG1Fcm_coddig_mant.Text);
                    if (lobreAx != null)
                    {
                        gnuTotalUnidExisten = lobreAx.Inv_totuni_inex;

                        if (lobreAx.Inv_totuni_inex <= 0)
                        {
                            lcrValorReturn = "No hay existencias en: " + gcrNombreAlmacen + " - " + tmpRegContrato.inv_codalm_inal + " - " + this.txtG1Fcm_coddig_mant.Text;
                        }

                        gobLiq.G2Fcm_coddig_mant = lobreAx.Fcm_coddig_mant;
                        tmpRegDetalle.Inv_secart_mart = lobreAx.Inv_secart_inar;
                    }
                    else
                    {
                        lcrValorReturn = "Código articulo no tiene existencias en: " + gcrNombreAlmacen + " - " + tmpRegContrato.inv_codalm_inal + " - " + this.txtG1Fcm_coddig_mant.Text;
                    }
                }
            }
            #endregion
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidaCodigoDigitacionIPS: Validacion del suministro cen configuracion en Servicios IPS
        /// <summary>
        /// <para>Realizar Validacion del suministro con respecto a configuracion en Servicios IPS</para>  
        /// </summary>
        public String fcrValidaCodigoDigitacionIPS(String tcrNumeroRegistro, String tcrNombreCampo)
        {
            //MessageBox.Show("aqui voy 1");
            String lcrValorReturn = gobLiq.fcrValidacionCampos("Fcm_coddig_mant", ref tmpLogErrores, tcrNumeroRegistro);

            #region Validar codigo servicio IPS
            if (String.IsNullOrWhiteSpace(lcrValorReturn))
            {
                //MessageBox.Show("aqui voy 2");

                var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(gobLiq.G2Fcm_coddig_mant);
                var tmpSrv = FCMValidarCodigo.fobRegBuscarIuFcmmanserviciosProg(gobLiq.G2Fcm_coddig_mant, tmpRegContrato.fcm_codman_mans,
                                                                                tmpRegContrato.cto_seccon_cont, tmpRegContrato.cto_serper_cont);
                if (tmp != null && tmp.fcm_idesec_sips != null && tmpSrv != null)
                {
                    this.txtG1Fcm_idesec_sips.Text = tmp.fcm_idesec_sips;
                    this.txtG1Fcm_desser_sips.Text = tmp.fcm_desser_sips;
                    this.txtG1Fcm_codcpr_cpro.Text = tmp.fcm_codcpr_cpro;
                    tmpRegDetalle.Hcl_tserax_hcor  = "NA";

                    if (!flgValidacionPertinencia())
                    {
                        lcrValorReturn = tcrNombreCampo + " : Error en validación pertinencia";
                    }
                    else
                    {
                        //- Actualizar temporal
                        tmpRegDetalle.Fcm_idesec_sips = tmp.fcm_idesec_sips;

                        // Guardar el codigo de digitacion en campo auxiliar
                        if (this.chkG1Cto_suminv_cont.IsChecked == true)
                        {
                            tmpRegDetalle.Fcm_secreg_dfac = tmp.fcm_coddig_mant;
                        }
                    }
                }
                else
                {
                    lcrValorReturn = "Código servicio: " + gobLiq.G2Fcm_coddig_mant + " No existe";
                    txtG1Fcm_desser_sips.Text = lcrValorReturn;
                }
            }
            #endregion
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidaCodigoDigitacionVademecum: Validacion del medicamento vademecum
        /// <summary>
        /// <para>Realizar Validacion del medicamento cuando proviene del listado de vademecum</para>  
        /// </summary>
        public String fcrValidaCodigoDigitacionVademecum()
        {
            String lcrValorReturn = String.Empty;

            #region Validar codigo en vademecum
            var tmp = FARValidarCodigo.fobRegBuscarFarexpedmedicmdCUM(this.txtG1Fcm_coddig_mant.Text);
            if (tmp != null)
            {
                this.txtG1Fcm_idesec_sips.Text = tmp.far_expedi_fama;
                this.txtG1Fcm_desser_sips.Text = tmp.far_precom_famd;
                this.txtG1Fcm_codcpr_cpro.Text = Funciones.fcrLeerConfigVarSistema("HCL-SUMHCL-CENT-PRODUC-SUMI", "6023");  // "6023" = Medicamentos y Farmacia (por defecto)
            }
            else
            {
                lcrValorReturn = "Código medicamento CUM : " + this.txtG1Fcm_coddig_mant.Text + " No existe";
                this.txtG1Fcm_desser_sips.Text = lcrValorReturn;
            }
            #endregion
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // Validacion de pertinencia
        //-------------------------------------------------
        #region flgValidacionPertinencia: Validacion pertinencia del servicio
        /// <summary>
        /// Validacion pertinencia del servicio
        /// </summary>
        public bool flgValidacionPertinencia()
        {
            var llgReturn = true;
            flgAsignarTotalUnidadesParaValidacion();
            //Validar pertinencia
            llgReturn = gobLiq.flgValidacionPertinencia(ref tmpLogErrores, "PERTINENCIA");
            return llgReturn;
        }
        #endregion
        #region flgAsignarTotalUnidadesParaValidacion: Asignar total unidades desde vista
        /// <summary>
        /// Asignar total unidades desde vista captura de datos
        /// </summary>
        public bool flgAsignarTotalUnidadesParaValidacion()
        {
            var llgReturn = false;

            if (!String.IsNullOrWhiteSpace(this.txtG1Hcl_totuni_hcor.Text))
            {
                if (Funciones.flgExisteSubCadenaStringEx(this.txtG1Hcl_totuni_hcor.Text, "0123456789"))
                {
                    gobLiq.G2Fcm_totuni_dfac = Convert.ToInt32(this.txtG1Hcl_totuni_hcor.Text);
                    llgReturn = true;
                }
                else
                {
                    gobLiq.G2Fcm_totuni_dfac = 1;
                }
            }
            else
            {
                gobLiq.G2Fcm_totuni_dfac = 1;
            }
            return llgReturn;
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
                //-------------------------------------------------
                //  HCL_TIPSER_HCOR: Tipo servicio: 1 = Medicamento 2= Indicacion medica
                //-------------------------------------------------
                #region HCL_TIPSER_HCOR: Tipo servicio: 1 = Medicamento 2= Indicacion medica
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Medicamento,Inidicacion médica";
                lstG1Hcl_tipser_hcor = new List<CrtForms.ListaComboBox>();
                lstG1Hcl_tipser_hcor = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                //lstG1Hcl_tipser_hcor = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion, "1");
                //- Asignar al control
                cboG1Hcl_tipser_hcor.ItemsSource = lstG1Hcl_tipser_hcor;
                cboG1Hcl_tipser_hcor.SelectedIndex = Convert.ToInt32(lstG1Hcl_tipser_hcor[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //HCL_APLMED_HCOR: Aplicación medicamento
                //-------------------------------------------------
                #region HCL_APLMED_HCOR: Aplicación medicamento
                string lcrG12Seleccion = "1,2,3,4,5";
                string lcrG12Descripcion = "Via Oral,Intramuscular,Intravenosa,Topica,Otras"; 
                lstG1Hcl_aplmed_hcor = new List<CrtForms.ListaComboBox>();
                lstG1Hcl_aplmed_hcor = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                //- Asignar al control
                cboG1Hcl_aplmed_hcor.ItemsSource = lstG1Hcl_aplmed_hcor;
                cboG1Hcl_aplmed_hcor.SelectedIndex = Convert.ToInt32(lstG1Hcl_aplmed_hcor[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //HCL_TERMED_HCOR: Termino de uso
                //-------------------------------------------------
                #region HCL_TERMED_HCOR: Termino de uso
                string lcrG13Seleccion = "1,2";
                string lcrG13Descripcion = "Indefinido,Definido";
                lstG1Hcl_termed_hcor = new List<CrtForms.ListaComboBox>();
                lstG1Hcl_termed_hcor = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                //- Asignar al control
                cboG1Hcl_termed_hcor.ItemsSource = lstG1Hcl_termed_hcor;
                cboG1Hcl_termed_hcor.SelectedIndex = Convert.ToInt32(lstG1Hcl_termed_hcor[0].IdIndice);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion objetos vista detalles 
        //-------------------------------------------------
        #region fcvModificarRegDetalle: Modificar registro detalle
        /// <summary>
        /// <para>Modificar registro detalle</para>
        /// </summary>
        private void fcvModificarRegDetalle(object sender, RoutedEventArgs e)
        {
            var lcrIdRegistro   = String.Empty;
            var lobBoton        = sender as Button;
            var lobGrid         = lobBoton.Parent as Grid;
            var lobObjeto       = lobGrid.Parent as ControlOrdServiciosDetalleEdt;
            lcrIdRegistro       = lobObjeto.IdRegistro;

            // cargar registro en vista variables
            var lobReg = tmpDatosDetalle.FirstOrDefault(x => x.Hcl_nroreg_hcor == lcrIdRegistro);
            if (lobReg != null)
            {
                tmpRegDetalle = fobAuxCopiarRegistro(lobReg);
                tmpRegDetalle.Sis_estado_imaen = tmpRegDetalle.Sis_estado_imaen != "A" ? "M" : "A";
                fcvCargarVistaVariablesDesdeRegActivo();
            }

        }
        #endregion
        #region fcvEliminarRegDetalle: Eliminar un registro detalle
        /// <summary>
        /// <para>Eliminar un registro detalle</para>
        /// </summary>
        private void fcvEliminarRegDetalle(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lcrIdRegistro = String.Empty;
                var lobBoton = sender as Button;
                var lobGrid = lobBoton.Parent as Grid;
                var lobObjeto = lobGrid.Parent as ControlOrdServiciosDetalleEdt;
                lcrIdRegistro = lobObjeto.IdRegistro;

                fcvEliminarRegistroRelacion(lcrIdRegistro);
                flgValidacion();
            }
        }
        #endregion
        #region fcvEliminarRegistroRelacion: Eliminar registro dado el codigo unico en temporal
        /// <summary>
        ///  Eliminar registro dado el codigo unico en temporal
        /// </summary>
        private void fcvEliminarRegistroRelacion(String tcrIdCodigoUnico)
        {
            ControlOrdServiciosDetalleEdt lobObjeto = null;
            var lobReg = tmpDatosDetalle.FirstOrDefault(x => x.Hcl_nroreg_hcor == tcrIdCodigoUnico);

            if (lobReg != null)
            {
                lobObjeto = lobReg.RefObjeto as ControlOrdServiciosDetalleEdt;

                if (lobReg.Sis_estado_imaen != "A")
                {
                    lobReg.Sis_estado_imaen = "E";
                }
                else
                {
                    // Es un registro que no esta en base de datos
                    tmpDatosDetalle.Remove(lobReg);  // lobReg.Sis_estado_imaen = "N";  Cuando es "A" se marca nulo
                }
            }
            if (lobObjeto != null)
            {
                // quitar de la vista
                this.stkDetalles.Children.Remove(lobObjeto);
            }
        }
        #endregion
        //-------------------------------------------------
        // Referencias a objetos editores
        //-------------------------------------------------
        #region fcvRefRichTextBoxEditor: Referencia a objetos editor de texto
        /// <summary>
        /// <para>Referencia a objetos editor de texto</para>
        /// </summary>
        private TextRange fcvRefRichTextBoxEditor(String tcrNombreObjeto)
        {
            TextRange lobTextRange = null;
            if (tcrNombreObjeto == "txtG1Hcl_notreg_hcor")
            {
                lobTextRange = new TextRange(txtG1Hcl_notreg_hcor.Document.ContentStart, txtG1Hcl_notreg_hcor.Document.ContentEnd);
            }

            if (tcrNombreObjeto == "txtG2Hcl_notreg_hcor")
            {
                lobTextRange = new TextRange(txtG2Hcl_notreg_hcor.Document.ContentStart, txtG2Hcl_notreg_hcor.Document.ContentEnd);
            }

            return lobTextRange;
        }
        #endregion
        #region fcvSetRichTextBoxEditor: Configurar objetos editor de texto
        /// <summary>
        /// <para>Configurar objetos editor de texto</para>
        /// </summary>
        private void fcvSetRichTextBoxEditor()
        {
            // Configuracion objetos editores
            this.txtG1Hcl_notreg_hcor.SpellCheck.IsEnabled = true; // Corrector de ortografia
            this.txtG2Hcl_notreg_hcor.SpellCheck.IsEnabled = true; // Corrector de ortografia
            this.txtG1Hcl_notreg_hcor.Language = System.Windows.Markup.XmlLanguage.GetLanguage("es-US");
            this.txtG2Hcl_notreg_hcor.Language = System.Windows.Markup.XmlLanguage.GetLanguage("es-US");
            this.txtG1Hcl_notreg_hcor.Document.LineHeight = 3;
            this.txtG2Hcl_notreg_hcor.Document.LineHeight = 3;
        }
        #endregion
        //-------------------------------------------------
        // fcvclinicaGenerarActividad: Registro de actividad en Historial clinico
        //-------------------------------------------------
        #region fcvHclinicaGenerarActividad: Generar registro para atencion en historia clinica
        /// <summary>
        /// <para>Generar registro en historial clinico</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipoRegistro: "1"=Plan de manejo interno "2" = Formula médica</para>
        /// </summary>
        public String fcvHclinicaGenerarActividad(String tcrTipoRegistro)
        {
            var lcrCodgioRegHist = String.Empty;
            try
            {
                var lcrTipoReg = tcrTipoRegistro == "1" ? "SERV" : "FMED";

                var lobRegEx = HCLValidarCodigo.fobRegBuscarHcltiporegserms(lcrTipoReg);
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(lobRegEx.hcl_codreg_hcca);

                if (!String.IsNullOrWhiteSpace(lobReg.grp_idepla_grpl))
                {
                    // Generar registro de actividad en historia clinica
                    var loPlant         = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);
                    var lobHist         = new HclModeloHistorialEventos();
                    var lcrEvento       = "Formula medica";
                    var ldaFechaEvento  = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcor.Text);
                    var ldaHoraEvento   = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));

                    #region Datos del registro
                    lobHist.Hcl_secreg_hcev = 1;
                    lobHist.Hcl_nrohis_hicl = tmpRegAdm.Hcl_nrohis_hicl;
                    lobHist.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    lobHist.Cit_codasi_mcit = tmpRegAdm.Cit_codasi_mcit;
                    lobHist.Fcm_codcpr_cpro = tmpDatosDetalle.FirstOrDefault().Fcm_codcpr_cpro;
                    lobHist.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    lobHist.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    lobHist.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    lobHist.Hcl_codaux_hcev = tmpRegMaestro.Hcl_nroreg_hcms;
                    lobHist.Hcl_gesfec_hcev = ldaFechaEvento;
                    lobHist.Hcl_geshor_hcev = ldaHoraEvento;
                    lobHist.Sia_codpfa_prof = tmpRegMaestro.Sia_codpfa_prof;
                    lobHist.Hcl_keydat_hcev = (fcrGenerarLlaveMs(tmpRegMaestro) + " " + lcrEvento).ToLower();
                    lobHist.Hcl_xmldat_hcev = String.Empty;
                    lobHist.Hcl_xmltmp_hcev = String.Empty;
                    lobHist.Hcl_xmlcom_hcev = String.Empty;
                    lobHist.Hcl_conobj_hcev = 0;
                    lobHist.Hcl_desreg_hcev = lcrEvento;
                    lobHist.Hcl_codreg_hcca = lobReg.hcl_codreg_hcca;
                    lobHist.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                    lobHist.Grp_idepla_grpv = loPlant.grp_idepla_grpv;
                    lobHist.Fcm_secreg_dfac = String.Empty;
                    lobHist.Sis_estpro_espr = "2";  // cerrado por defecto

                    lcrCodgioRegHist = HclModeloHistorialEventos.fcrAddRegistro(lobHist);
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvHclinicaGenerarActividad");
            }
            return lcrCodgioRegHist;

        }
        #endregion
        // Generar llaves
        #region fcrGenerarLlaveMs: Generar llave de busquda para el objeto
        /// <summary>
        /// <para>Generar llave de busquda para el objeto</para>
        /// </summary>
        public String fcrGenerarLlaveMs(ModeloHclregordeserms tobRegistro)
        {
            // llave registro maestro
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + "  " + tobRegistro.Adm_secadm_rgad + "  " + tobRegistro.Hcl_nroreg_hcms;
            var lcrllave2 = tobRegistro.Hcl_gesfec_hcms.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + "  " + tobRegistro.Sia_desare_aser;
            var lcrllave4 = String.Empty;

            // llave de los detalles
            if (tmpDatosDetalle.Count != 0 && tmpRegDetalle != null)
            {
                foreach (var lobReg in tmpDatosDetalle)
                {
                    if (lobReg.Sis_estado_imaen != "N")
                    {
                        lcrllave4 += " " + fcrGenerarLlaveDetalles(lobReg);
                    }
                }
            }
            return lcrllave1 + "  " + lcrllave2 + "  " + lcrllave3 + " " + lcrllave4;
        }
        #endregion
        #region fcrGenerarLlaveDetalles: Generar llave desde registros detalles
        /// <summary>
        /// <para>Generar llave desde registros detalles</para>
        /// </summary>
        public String fcrGenerarLlaveDetalles(ModeloHclregordeserde tobRegistro)
        {
            var lcrllave1 = tobRegistro.Fcm_idesec_sips + " " + tobRegistro.Fcm_desser_sips + " " + tobRegistro.Hcl_notreg_hcor;
            var lcrllave2 = tobRegistro.Fcm_coddig_mant;

            return lcrllave1 + " " + lcrllave2;
        }
        #endregion

    }
}
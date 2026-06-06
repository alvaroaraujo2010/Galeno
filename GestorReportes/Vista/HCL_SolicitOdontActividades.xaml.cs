//- MARMOTA-GENCODE: VERSION 2.0 - 04/02/2015 10:07:52 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Validacion;
using GestorReportes.Modelo;
using GestorReportes.Vista;
using GestorReportes.Utilidades;
using GestorReportes.VistaModelo;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: odneventosactms
    /// </summary>
    public partial class VistaMaestroActividades : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Varaibles Globales Formulario
        #region Variables de control
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = false;
        public bool llgObjetosCargados = false;
        public bool glgVistaSeleccion = false;
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public String gcrCtrF2TexBox;
        public String lcrFormModoPopup = "DFL";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public String gcrTipoRegistro = String.Empty;
        public String gcrTipoRegistroHclinico = String.Empty;
        public String gcrIdMaestroTratamiento = String.Empty;
        public String gcrCodigoAdmision = String.Empty;
        public String gcrCodigoRegistro = String.Empty;
        public String gcrIdItemServicioGrafica = "NA"; // "NA" - General sin grafica en odontograma "11", "45","63"... - Numero dientes seleccionado
        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public ModeloOdnMaestroTratamiento tmpRegMsTratamiento = null;
        public ModeloOdnMsActivTratamiento tmpRegMaestro = new ModeloOdnMsActivTratamiento();
        public ModeloOdnDeActivTratamiento tmpRegActiDetalle = new ModeloOdnDeActivTratamiento();
        public List<ClassVistaCorona> tmpVistaCorona = null;
        public List<ModeloOdnDeActivTratamiento> tmpTablaDetalles = new List<ModeloOdnDeActivTratamiento>();
        public List<ModeloOdnDeActivTratamiento> tmpTablaDetalEdt = new List<ModeloOdnDeActivTratamiento>();
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public List<CrtForms.ListaComboBox> lstRefDiagnosticos = null;
        public List<CrtForms.ListaComboBox> lstRefPlanTratamiento = null;
        Aplicacion oApp = Aplicacion.Instancia();
        DialogVistaErrores lobDlgLogs = null;
        #endregion
        //--------------------------------------------------------
        // CLASE PARA LIQUIDAR SERVICIOS
        //--------------------------------------------------------
        #region Clase Objeto para liquidar valores servicios
        /// <summary>
        ///  Parametros generales para liquidar servicios de facturación
        /// </summary>
        public FcmFacturarServicios gobLiq = new FcmFacturarServicios();
        #endregion
        //FCMMAESFACTURAS: Maestro de facturas en Ordenes de servicios medicos
        #region FCMMAESFACTURAS: Propiedad registro activo tmpRegFact
        /// <summary>
        ///  Registro activo tabla: Maestro facturas fcmmaesfacturas
        /// </summary>
        public FcmModeloMaestrofacturas tmpRegFact = new FcmModeloMaestrofacturas();
        #endregion
        #region FCMMAESFACTURAS: Propiedad lista registros maestro facturas: tmpListFact
        /// <summary>
        ///  Lista de registros tabla: fcmmaesfacturas Vista del Browser
        ///  para la grilla.
        /// </summary>
        public List<FcmModeloMaestrofacturas> tmpListFact;
        #endregion
        //FCMMAEDETALLFAC : Detalles servicios medicos prestados
        #region FCMMAEDETALLFAC: Propiedad registro activo detalles tmpRegDetall
        /// <summary>
        ///  Registro activo de la tabla: detalles facturas fcmmaedetallfac
        /// </summary>
        public FcmModeloServDetallFacturas tmpRegDetall = new FcmModeloServDetallFacturas();
        #endregion
        #region FCMMAEDETALLFAC: Propiedad Temporal para Edicion: tmpListDetallEdt
        /// <summary>
        ///  Lista registros tabla: detalles de facturación fcmmaedetallfac
        /// </summary>
        public List<FcmModeloServDetallFacturas> tmpListDetallEdt;
        #endregion
        #endregion
        #region Inicio Formulario
        /// <summary>
        /// <para>Inicializar nueva instancia de la clase</para>
        /// <para>gcrIdMaestroTratamiento: Codigo unico del registro maestro del tratamiento activo. (obligatorio)</para>
        /// <para>tcrTipoRegistro: Codigo tipo registro actividad: 1= Diagnostico, 2= Plan de tratamiento, 3= Evolucion</para>
        /// <para>tcrCodigoRegistro: Codigo del registro maestro actividad segun tcrTipoRegistro.</para>
        /// </summary>
        public VistaMaestroActividades(String tcrModoAccion, String tcrIdMaestroTratamiento, String tcrTipoRegistro, String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            InitializeComponent();

            //IniciarComboBox();
            llgObjetosCargados = true;
            gcrTipoRegistro         = tcrTipoRegistro;
            gcrTipoRegistroHclinico = fcrTipoRegHistorialClinico(gcrTipoRegistro);
            gcrCodigoRegistro       = tcrCodigoRegistro;
            gcrCodigoAdmision       = tcrCodigoAdmision;
            gcrIdMaestroTratamiento = tcrIdMaestroTratamiento;
            tmpRegMsTratamiento     = HclUtilidades.fobRegMaestroTratamiento(gcrIdMaestroTratamiento);
            this.pagActividad.Header = fcrNombreTipoRegHistorialClinico(gcrTipoRegistro);
            this.txtTituloVentana.Text = "ODONTOLOGIA - " + fcrNombreTipoRegHistorialClinico(gcrTipoRegistro);
            fcvActivarVistaTipoVistaCaptura();

            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;
            this.txtG1Sia_codpfa_prof.Text = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario).sia_codpfa_prof;

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Odn_fecact_odac.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG3Odn_fecini_odde.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG3Odn_fecfin_odde.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoRegistro, tcrCodigoAdmision);
            fcvTimerGeneral();
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

            this.grdPropSelect.Height = lduHeight;
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
                    flgValidacionRegDetalles();
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
            var llgExiste = false;

            if (!String.IsNullOrWhiteSpace(tcrCodigoAdmision))
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision);
                if (lobRegAdm.Count != 0)
                {
                    tmpRegAdm = lobRegAdm.FirstOrDefault();
                }
            }

            if (!String.IsNullOrWhiteSpace(tcrCodigoRegistro))
            {
                llgExiste = flgCargarDatosExitentesEnVista(tcrCodigoRegistro);
                gcrCodigoRegistro = llgExiste == false ? String.Empty : gcrCodigoRegistro;
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
            fcvActivarModoEdicion(lcrFormModoPopup);
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region fcvNuevoRegistro: clic en Boton Nuevo
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Sia_codpfa_prof);
        }
        #endregion
        #region fcvGuardarRegistro: click en guardar
        //-Click en Boton Guardar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            if (!flgGuardarRegistro("1"))
            {
                MessageBox.Show("No es posible guardar los datos.");
            }
            else
            {
                // Regresar a vista principal 
                fcvRetornoInterface(gcrCodigoRegistro);
            }
        }
        #endregion
        #region fcvConfirmarRegistro: click en guardar
        /// <summary>
        /// Click en Boton Confirmar
        /// </summary>
        private void fcvConfirmarRegistro(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Confirmar los datos?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (!flgGuardarRegistro("2"))
                {
                    MessageBox.Show("No es posible confirmar los datos.");
                }
                else
                {
                    // Regresar a vista principal 
                    fcvRetornoInterface(gcrCodigoRegistro);
                }
            }
        }
        #endregion
        #region flgGuardarRegistro: Procedimiento para guardar o confirmar registros
        /// <summary>
        /// Procedimiento para guardar o confirmar registros 
        /// </summary>
        private bool flgGuardarRegistro(String tcrEstadoRegistro)
        {
            var llgReturn = false;
            if (flgValidacion() == true)
            {
                llgReturn = true;
                fcvCargarRegMaestroActDesdeVariables();
                tmpRegMaestro.Sis_estpro_espr = tcrEstadoRegistro;

                if (llgModoAdicion == true)
                {
                    tmpRegMaestro.Odn_nroreg_odac = ModeloOdnMsActivTratamiento.flgAddRegistro(tmpRegMaestro);
                }
                else
                {
                    ModeloOdnMsActivTratamiento.fcvActualizar(tmpRegMaestro);
                }
                gcrCodigoRegistro = tmpRegMaestro.Odn_nroreg_odac;
                //- guardar datos grilla
                if (!String.IsNullOrEmpty(tmpRegMaestro.Odn_nroreg_odac))
                {
                    var llgGuardar = flgGardarDatosDetalleServicios();

                    if (tcrEstadoRegistro != "1" && llgGuardar == true)
                    {
                        // confirmar todos los registros detalles
                        tmpTablaDetalEdt = ModeloOdnDeActivTratamiento.flsListaOdneventosactde("R1", tmpRegMaestro.Odn_nroreg_odac);
                        foreach (ModeloOdnDeActivTratamiento lobReg in tmpTablaDetalEdt)
                        {
                            lobReg.Sis_estpro_espr = tcrEstadoRegistro;                     // Cambia estado de los registro
                            lobReg.Odn_estact_odac = gcrTipoRegistro == "2" ? "1" : "3";    // Cambia a finalizada cuando es diagnostico o actividad
                            ModeloOdnDeActivTratamiento.fcvActualizar(lobReg);
                        }
                        // Notificar registro de atividades finalizadas
                        if (gcrTipoRegistro == "3")
                        {
                            if (flgConfirmarFactura())
                            {
                                fcvSYSGenerarNotificacion();
                            }
                            else
                            {
                                llgReturn = false;
                                // Reversar los cambios cuando hay errores de validaciones
                                tmpRegMaestro.Sis_estpro_espr = "1";
                                flgGardarDatosDetalleServicios();
                            }
                        }
                    }
                    if (tcrEstadoRegistro == "2" && llgReturn == true) // se confirmo
                    {
                        fcvHclinicaGenerarActividad();
                    }
                }
                // verificar si se marcan como finalizados algunos tratamientos 
                if (tcrEstadoRegistro == "2" && gcrTipoRegistro == "3" && tmpTablaDetalEdt.Count > 0 && llgReturn == true)
                {
                    fcvFinalizarProcedimientosPlanTratamiento();
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgGardarDatosDetalleServicios: Gardar datos en maestro y detalles de servicios odontologicos
        /// <summary>
        /// Gardar datos en maestro y detalles de servicios odontologicos
        /// </summary>
        private bool flgGardarDatosDetalleServicios()
        {
            var llgReturn = false;
            if (tmpTablaDetalEdt.Count > 0)
            {
                llgReturn = true;
                foreach (ModeloOdnDeActivTratamiento lobReg in tmpTablaDetalEdt)
                {
                    lobReg.Sis_estpro_espr = tmpRegMaestro.Sis_estpro_espr; // Cambia estado de los registro
                    lobReg.Odn_nroreg_odac = tmpRegMaestro.Odn_nroreg_odac; // llave R1
                    lobReg.Odn_nroreg_odev = tmpRegMaestro.Odn_nroreg_odev; // llave R1
                    // Actualizar en Base de Datos
                    ModeloOdnDeActivTratamiento.flgAddRegistro(lobReg, tmpRegMaestro.Odn_nroreg_odac);
                }
            }
            return llgReturn;
        }
        #endregion
        #region fcvFinalizarActividadesPlanTratamiento: Finalizar procedimientos en plan de tratamiento
        //- Finalizar procedimientos en plan de tratamiento
        private void fcvFinalizarProcedimientosPlanTratamiento()
        {
            // Marcar como finalizados 
            var tmpPlan = ModeloOdnDeActivTratamiento.flsListaOdneventosactdeEx("2", gcrIdMaestroTratamiento, "");
            ModeloOdnDeActivTratamiento lobRegRef = null;
            var lcrCodigoActividad = tmpPlan.FirstOrDefault().Odn_nroreg_odac;

            foreach (var lobReg in tmpPlan)
            {
                lobRegRef = tmpTablaDetalEdt.FirstOrDefault(x => x.Odn_auxreg_odde == lobReg.Odn_nroreg_odde);
                if (lobRegRef != null)
                {
                    if (lobRegRef.Odn_finpro_odde == "1") // la actividad finaliza el procedimiento
                    {
                        lobReg.Odn_estact_odac = "3";
                        ModeloOdnDeActivTratamiento.fcvActualizar(lobReg);
                    }
                }
            }

            // Verificar si todo el plan de tratamiento ya fue finalizado y finalizar registro principal
            tmpPlan = ModeloOdnDeActivTratamiento.flsListaOdneventosactde("R1", lcrCodigoActividad);
            var lnuContador = tmpPlan.Count(x => x.Odn_estact_odac == "3");

            if (lnuContador == tmpPlan.Count)
            {
                var lobRegPlan = ModeloOdnMsActivTratamiento.flsListaOdneventosactms("IG", lcrCodigoActividad).FirstOrDefault();
                lobRegPlan.Odn_estact_odac = "3";
                ModeloOdnMsActivTratamiento.fcvActualizar(lobRegPlan);
            }
        }
        #endregion
        #region fcvGuardarRegistroRelacion: click en Guardar registro relacion
        //- click en Guardar registro relacion
        private void fcvGuardarRegistroRelacion(object sender, RoutedEventArgs e)
        {
                // Generar grafica 
            if (gcrIdItemServicioGrafica == "NA")
            {
                fcvGuardarRegRelacionSimple();
            }
            else
            {
                // Grafica en caras corona genrar varios registros
                if (tmpRegActiDetalle.Odn_tipvis_odsi == "1") 
                {
                    fcvGuardarRegRelacionCarasCorona();
                }
                else
                {
                    fcvGuardarRegRelacionSimple();
                }
            }
        }
        #endregion
        #region fcvEliminarRegistroRel: Clic en Boton Eliminar registro Grilla
        //-Clic en Boton Eliminar registro Grilla
        private void fcvEliminarRegistroRel(object sender, RoutedEventArgs e)
        {
            FocusManager.SetFocusedElement(this, txtG1Odn_fecact_odac);
        }
        #endregion
        // Acciones edicion
        #region fcvActivarModoEdicion: Activar modo adicion
        //- Activar modo edicion en la Vista
        public void fcvActivarModoEdicion(string tcrTipoEdicion)
        {
            switch (tcrTipoEdicion)
            {
                case "ADD":
                    llgModoAdicion = true;
                    llgModoEdicion = true;
                    fcvIniciarVariablesVista("1");
                    tmpRegMaestro.Sis_estpro_espr = "1";
                    tmpRegMaestro.Odn_tipreg_odac = gcrTipoRegistro;
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = tmpRegMaestro.Sis_estpro_espr == "1" ? true : false;
                    break;
            }
            FocusManager.SetFocusedElement(this, this.txtG1Odn_fecact_odac);
            // Activar el Odontograma
            if (tmpRegMsTratamiento.Odn_tgrafi_odev == "1") //Odontogrma adultos
            {
                this.odnAdulto.Visibility = Visibility.Visible;
                this.odnNino.Visibility = Visibility.Collapsed;
                this.odnMixto.Visibility = Visibility.Collapsed;
                this.odnAdulto.fcvActivarCapaSeleccion(Visibility.Visible);
                fcvActivarOdontogramaAdulto();
            }
            else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "2") //Odontogrma niños
            {
                this.odnAdulto.Visibility = Visibility.Collapsed;
                this.odnMixto.Visibility = Visibility.Collapsed;
                this.odnNino.Visibility = Visibility.Visible;
                this.odnNino.fcvActivarCapaSeleccion(Visibility.Visible);
                fcvActivarOdontogramaNiños();
            }
            else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "3") //Odontogrma Mixto
            {
                this.odnMixto.Visibility = Visibility.Visible;
                this.odnAdulto.Visibility = Visibility.Collapsed;
                this.odnNino.Visibility = Visibility.Collapsed;
                this.odnMixto.fcvActivarCapaSeleccion(Visibility.Visible);
                fcvActivarOdontogramaMixto();
            }
            // tomar valores por defecto en vista propiedades
            tmpTablaDetalles = fobSQLSelectDetallesActividad(gcrCodigoRegistro);
            fcvActivarDatosPropDetalles(gcrIdItemServicioGrafica);
            fcvMostrarSombrasOdontograma();
            fcvGraficarOdontogramaDesdeBdatos();
            fcvActivarObjetosCaptura(llgModoEdicion);
            // aactivar boton confirmar en diagnostico y plan de tratamiento
            if (tmpRegMaestro != null)
            {
                if (tmpRegMaestro.Sis_estpro_espr == "2" && 
                    tmpRegMaestro.Odn_tipreg_odac != "3" && 
                    tmpRegMsTratamiento.Odn_estado_odev == "1")
                {
                    fcvActivarObjetosCaptura(true);
                }
            }

        }
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
                this.Close();
                lobRefEnlace.fcvBuscarRegistro(tcrCodigSelect);
            }
        }
        #endregion
        #region flgGenerarRegistroMaestro: Validar Registro maestro R1
        //- Activar modo edicion en la Vista
        public bool flgGenerarRegistroMaestro()
        {
            var llgReturn = false;
            if (tmpRegMaestro == null)
            {
                var lobReg = ModeloOdnMsActivTratamiento.flsListaOdneventosactmsEx("2", gcrCodigoAdmision, "1");
                if (lobReg.Count != 0)
                {
                    tmpRegMaestro = lobReg.FirstOrDefault();
                    gcrCodigoRegistro = tmpRegMaestro.Odn_nroreg_odac;
                }
                else
                {
                    // Adicionar el registro
                    tmpRegMaestro = new ModeloOdnMsActivTratamiento();
                    #region Valores Variables
                    //tmpRegMaestro.Odn_secreg_odac = 1; // aqui una funcion que genera secuencial desde el maestro de tratamiento
                    tmpRegMaestro.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    tmpRegMaestro.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    tmpRegMaestro.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    tmpRegMaestro.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    tmpRegMaestro.Hcl_tipreg_hctr = gcrTipoRegistroHclinico;
                    tmpRegMaestro.Sis_estpro_espr = "1";
                    tmpRegMaestro.Odn_nroreg_odev = tmpRegMsTratamiento.Odn_nroreg_odev;
                    tmpRegMaestro.Odn_tipreg_odac = gcrTipoRegistro;
                    tmpRegMaestro.Cto_seccon_cont = this.txtG1Cto_seccon_cont.Text;
                    tmpRegMaestro.Cto_nrocon_cont = this.txtG1Cto_nrocon_cont.Text;
                    tmpRegMaestro.Sia_codeps_teps = this.txtG1Sia_codeps_teps.Text;
                    tmpRegMaestro.Odn_fecact_odac = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Odn_fecact_odac.Text);
                    tmpRegMaestro.Hcl_tiptur_hctu = this.txtG1Hcl_tiptur_hctu.Text;
                    tmpRegMaestro.Sia_codare_aser = this.txtG1Sia_codare_aser.Text;
                    tmpRegMaestro.Fcm_codcpr_cpro = this.txtG1Fcm_codcpr_cpro.Text;
                    tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                    tmpRegMaestro.Odn_sisfec_odac = DateTime.Now;
                    tmpRegMaestro.Odn_sishor_odac = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                    tmpRegMaestro.Odn_observ_odac = this.txtG1Odn_observ_odac.Text;
                    //tmpRegMaestro.Odn_secdet_odac = 0; se actualiza al adicionar registros
                    #endregion
                    gcrCodigoRegistro = ModeloOdnMsActivTratamiento.flgAddRegistro(tmpRegMaestro);
                    tmpRegMaestro.Odn_nroreg_odac = gcrCodigoRegistro;


                }
                llgReturn = !String.IsNullOrWhiteSpace(gcrCodigoRegistro) ? true : false;
            }
            return llgReturn;
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
        //- Adicionar registros detalles
        #region fcvGuardarRegRelacionSimple: Guardar en temporal Registro tipo detalle simple
        /// <summary>
        /// <para>Metodo para guardar en temporal Registro tipo detalle cuando es registro simple de un solo servicio.</para>
        /// <para>es decir no hay graficas en caras corona</para>
        /// </summary>
        private void fcvGuardarRegRelacionSimple()
        {
            try
            {
                ModeloOdnDeActivTratamiento lobReg = null;
                var lcrImagenGrafica = "hc_od_sinimagen.png";
                // Cuando es un nuevo registro
                if (String.IsNullOrEmpty(tmpRegActiDetalle.Odn_nroreg_odde))
                {
                    tmpRegMaestro.Odn_secdet_odac++;
                    tmpRegActiDetalle.Odn_nroreg_odde = "R" + tmpRegMaestro.Odn_secdet_odac.ToString().Trim();
                    tmpRegActiDetalle.Odn_secreg_odde = tmpRegMaestro.Odn_secdet_odac;
                    tmpRegActiDetalle.Sis_estado_imaen = "A";
                }
                if (tmpRegActiDetalle.Sis_estado_imaen != "A") { tmpRegActiDetalle.Sis_estado_imaen = "M"; } // es modificado
                fcvCargarRegDetalleDesdeVariables();

                // Generar grafica 
                if (gcrIdItemServicioGrafica != "NA")
                {
                    lcrImagenGrafica = fcrAddVistaGraficaEnOdontograma(tmpRegActiDetalle);
                }
                tmpRegActiDetalle.Odn_imagen_odde = lcrImagenGrafica;

                // copiar a un nuevo registro
                lobReg = fobCargarDatosRegActivoAuxiliar(tmpRegActiDetalle);

                // Gestion para guardar datos
                fcvGestionEdtRelacion(lobReg);
                fcvAddRegistroDetalleGrafico(lobReg);
                //- Preparar para Adicionar otro
                fcvAdicionarRel();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fcvGuardarRegRelacionSimple");
            }
        }
        #endregion
        #region fcvGuardarRegRelacionCarasCorona: Guardar en temporal Registro segun caras seleccionadas en corona
        /// <summary>
        /// <para>Metodo para guardar en temporal Registros tipo detalle servicios segun caras seleccionadas en corona.</para>
        /// <para>cuando hay graficas y seleccion de caras en vista corona</para>
        /// </summary>
        private void fcvGuardarRegRelacionCarasCorona()
        {
            try
            {
                ModeloOdnDeActivTratamiento lobReg = null;
                var lcrDiente = tmpRegActiDetalle.Odn_coddie_oddi.Trim();
                var lcrEstadoCara = String.Empty; 
                fcvActualizarTempCarasCorona("1");

                // Cuando es un nuevo registro
                tmpRegActiDetalle.Sis_estado_imaen = "A";
                fcvCargarRegDetalleDesdeVariables();

                // Adicionar un registro por cada cara marcada
                foreach (var loRegCara in tmpVistaCorona)
                {
                    if (loRegCara.Estado == "1")
                    {
                        if (tmpRegActiDetalle.Odn_prexis_odde == "1") // Es un proc pre existente
                        {
                            lcrEstadoCara = loRegCara.Cara.Trim() + "2"; // Azul
                        }
                        else
                        {
                            lcrEstadoCara = loRegCara.Cara.Trim() + tmpRegActiDetalle.Odn_estact_odac.Trim();
                        }
                        tmpRegMaestro.Odn_secdet_odac++;
                        tmpRegActiDetalle.Odn_nroreg_odde = "R" + tmpRegMaestro.Odn_secdet_odac.ToString().Trim();
                        tmpRegActiDetalle.Odn_secreg_odde = tmpRegMaestro.Odn_secdet_odac;

                        // Cara marcada anatomia 
                        tmpRegActiDetalle.Odn_codana_odan = HclUtilidades.fcrOdontogramaCaraDiente(lcrDiente, "2", loRegCara.Cara);
                        tmpRegActiDetalle.Odn_desana_odan = ODNValidarCodigo.fobRegBuscarOdnanatomdiente(tmpRegActiDetalle.Odn_codana_odan).odn_desana_odan;
                        tmpRegActiDetalle.Odn_imagen_odde = ODNValidarCodigo.fobRegBuscarOdnimgcracorona(lcrEstadoCara).odn_imagen_odcr;
                        tmpRegActiDetalle.Odn_carmar_odde = loRegCara.Cara;

                        // Graficar en odontograma
                        fcrAddVistaGraficaEnOdontograma(tmpRegActiDetalle);
                        // copiar a un nuevo registro
                        lobReg = fobCargarDatosRegActivoAuxiliar(tmpRegActiDetalle);

                        // Gestion para guardar datos
                        fcvGestionEdtRelacion(lobReg);
                        fcvAddRegistroDetalleGrafico(lobReg);
                    }
                }
                //- Preparar para Adicionar otro
                fcvAdicionarRel();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fcvGuardarRegRelacionSimple");
            }
        }
        #endregion
        #region fcvAdicionarRel: Adicionar Registro Relación
        /// <summary>
        /// Iniciar datos vacios para adicionar nuevo registro relación
        /// </summary>
        private void fcvAdicionarRel()
        {
            try
            {
                fcvIniciarVariablesVista("2");
                tmpRegActiDetalle.Sis_estado_imaen = "A";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fcvAdicionarRel");
            }
        }
        #endregion
        #region fcvEliminarRegistroDetalle: Eliminar Registro Relación
        /// <summary>
        /// Eliminar Registro detalle seleccionado 
        /// </summary>
        private void fcvEliminarRegistroDetalle(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea Eliminar registro?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var lobBoton = sender as Button;
                    var lobGrid = lobBoton.Parent as Grid;
                    var lobObjeto = lobGrid.Parent as ControlOrdOdontoServiciosRegistro;

                    var lobTemp = fobSQLSelectTempRegistros("1", lobObjeto.IdRegistro);

                    if (lobTemp != null && lobTemp.Count != 0)
                    {
                        var lobReg = lobTemp.FirstOrDefault();

                        if (lobReg.Sis_estado_imaen != "A")
                        {
                            lobReg.Sis_estado_imaen = "E";
                        }
                        else
                        {
                            lobReg.Sis_estado_imaen = "I"; // eliminar todos
                        }
                        fcvGestionEdtRelacion(lobReg);
                        this.odnNino.flgEliminarImagenEnVista(lobReg.Odn_nroreg_odde);
                        this.odnAdulto.flgEliminarImagenEnVista(lobReg.Odn_nroreg_odde);
                        this.odnMixto.flgEliminarImagenEnVista(lobReg.Odn_nroreg_odde);
                    }
                    this.stkDetalles.Children.Remove(lobObjeto);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fcvEliminarRel");
            }
        }
        #endregion
        #region fcvGestionEdtRelacion: Gestin Registros Relacion
        /// <summary>
        /// Gestionar en Temporal de edicion los registros
        /// modificados antes de ser llevados a Base de Datos
        /// I=Ingnorar,M=Modificar,A=Adicionar,E=Eliminar,N=Nulo
        /// </summary>
        private void fcvGestionEdtRelacion(ModeloOdnDeActivTratamiento tobRegistro)
        {
            try
            {
                tmpTablaDetalEdt.Remove(tobRegistro);
                //- Actualizar en  temporal de gestion Base de Datos
                if (tobRegistro.Sis_estado_imaen == "A" ||
                    tobRegistro.Sis_estado_imaen == "M" || tobRegistro.Sis_estado_imaen == "E")
                {
                    tmpTablaDetalEdt.Add(tobRegistro);
                }
                tmpTablaDetalles.Remove(tobRegistro);
                //- Actualizar en  temporales
                if (tobRegistro.Sis_estado_imaen == "A" || tobRegistro.Sis_estado_imaen == "M")
                {
                    tmpTablaDetalles.Add(tobRegistro);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error metodo: fcvGestionEdtRelacion");
            }
        }
        #endregion
        //- Actualizar temporal Caras seleccionadas en Vista corona
        #region ClassVistaCorona: Clase Cargar Vista corona
        public class ClassVistaCorona
        {
            public ClassVistaCorona() { }
            public string Cara { get; set; }
            public string Estado { get; set; }
        }
        #endregion
        #region fcvActualizarTempCarasCorona: Actaulizar temporal segun caras seleccionadas en corona
        /// <summary>
        /// <para>Actaulizar temporal segun caras seleccionadas en corona.</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrChkSeleccion: "1" = Quitar Marca seleccion corona luego de actualizar temporal, "2" = No quitar marcas.</para>
        /// </summary>
        private void fcvActualizarTempCarasCorona(String tcrChkSeleccion)
        {
            tmpVistaCorona = new List<ClassVistaCorona>();

            var lcrCara1 = this.chkCara1.IsChecked == true ? "1" : "2";
            var lcrCara2 = this.chkCara2.IsChecked == true ? "1" : "2";
            var lcrCara3 = this.chkCara3.IsChecked == true ? "1" : "2";
            var lcrCara4 = this.chkCara4.IsChecked == true ? "1" : "2";
            var lcrCara5 = this.chkCara5.IsChecked == true ? "1" : "2";

            // Actualizar temporal
            tmpVistaCorona.Add(new ClassVistaCorona { Cara = "1", Estado = lcrCara1 });
            tmpVistaCorona.Add(new ClassVistaCorona { Cara = "2", Estado = lcrCara2 });
            tmpVistaCorona.Add(new ClassVistaCorona { Cara = "3", Estado = lcrCara3 });
            tmpVistaCorona.Add(new ClassVistaCorona { Cara = "4", Estado = lcrCara4 });
            tmpVistaCorona.Add(new ClassVistaCorona { Cara = "5", Estado = lcrCara5 });

            // quitar marca 
            if (tcrChkSeleccion == "1")
            {
                this.chkCara1.IsChecked = false;
                this.chkCara2.IsChecked = false;
                this.chkCara3.IsChecked = false;
                this.chkCara4.IsChecked = false;
                this.chkCara5.IsChecked = false;
            }
        }
         #endregion
        #region fcvActualVistaCarasCoronaDiente: Actauliza caras anatomicas de la vista corona para seleccion
        /// <summary>
        /// <para>Actauliza la ubicacion caras anatomicas de la vista corona para seleccion</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumeroDiente: Numero del diente para el cual se actualizara la vista corona.</para>
        /// </summary>
        private void fcvActualVistaCarasCoronaDiente(String tcrNumeroDiente)
        {
            this.lblCara1.Text = HclUtilidades.fcrOdontogramaCaraDiente(tcrNumeroDiente, "1", "1");
            this.lblCara2.Text = HclUtilidades.fcrOdontogramaCaraDiente(tcrNumeroDiente, "1", "2");
            this.lblCara3.Text = HclUtilidades.fcrOdontogramaCaraDiente(tcrNumeroDiente, "1", "3");
            this.lblCara4.Text = HclUtilidades.fcrOdontogramaCaraDiente(tcrNumeroDiente, "1", "4");
        }
         #endregion
        //-------------------------------------------------
        // Generar Factura 
        //-------------------------------------------------
        #region flgConfirmarFactura: Confirmar factura y detalles factura
        /// <summary>
        /// Confirmar factura y detalles factura
        /// </summary>
        public bool flgConfirmarFactura()
        {
            var llgReturn = false;
            try
            {
                if (flgGenerarFacturas("2"))
                {
                    // Generar de nuevo para tomar datos de la admision y turno citas
                    if (flgGenerarFacturas("1"))
                    {
                        llgReturn = flgConfirmarFacturas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Confirmar factura y detalles factura");
            }
            return llgReturn;
        }
        #endregion
        // fcvGenerarFacturas: Genera factura y servicios progrmados
        #region fcvGenerarFacturas: Guardar en temporal Registro Relacion auxiliar
        /// <summary>
        /// Genera factura y servicios progrmados
        /// <para>PARAMETROS:</para>
        /// <para>tcrAccion: "1" = Generar registro activo y resumen facturación "2" = No generar registro activo ni resumen facturación</para>
        /// </summary>
        public bool flgGenerarFacturas(String tcrAccion)
        {
            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "GEN-FACTURA";
            String lcrCodigoError = "GEN-FACTURA";
            String lcrNombreCampo = "Generar factura de servicios progrmados";
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            tmpLogErrores = new List<LogsErrores>();

            var llgReturn = false;
            var i = 0;
            var lnuErrores = 0;

            try
            {
                tmpListFact = null;
                //var tmpServi = ModeloCitmaestroprotocolo.flsListaCitservprotocol(G1Cit_codspr_spro);
                if (tmpTablaDetalEdt != null && tmpTablaDetalEdt.Count > 0)
                {
                    var tmpContrato = CTOValidarCodigo.fobRegBuscarCtomaescontrato(this.txtG1Cto_seccon_cont.Text);

                    tmpListDetallEdt = new List<FcmModeloServDetallFacturas>();
                    fcvCargarDatosParaLiquidarServ();

                    // Generar servicios 
                    foreach (var lobReg in tmpTablaDetalEdt)
                    {
                        //var tmpSrv = FCMValidarCodigo.fobRegBuscarIuFcmmanservicios(lobReg.Fcm_coddig_mant, tmpContrato.fcm_codman_mans);
                        var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(lobReg.Fcm_coddig_mant);
                        var tmpSrv = FCMValidarCodigo.fobRegBuscarIuFcmmanserviciosProg(lobReg.Fcm_coddig_mant, tmpContrato.fcm_codman_mans,
                                                                                        tmpContrato.cto_seccon_cont, tmpContrato.cto_serper_cont);
                        if (tmp != null && tmpSrv != null)
                        {
                            i++;
                            // Valores de digitacion
                            gobLiq.G2Fcm_coddig_mant = lobReg.Fcm_coddig_mant;
                            gobLiq.G2Sia_tipact_tsac = tmp.sia_tipact_tsac;
                            gobLiq.G2Fcm_totuni_dfac = lobReg.Odn_totuni_odde;
                            gobLiq.G2Hcl_codreg_hcca = "NA";
                            // completar Rips
                            gobLiq.G2Sia_codfco_fcon = tmp.sia_codfco_fcon;
                            gobLiq.G2Sia_codfpr_fpor = tmp.sia_codfpr_fpro;
                            gobLiq.G2Sia_codpat_tpat = tmp.sia_codpat_tpat;
                            gobLiq.G2Sia_coddia_tdia = lobReg.Sia_coddia_tdia;
                            gobLiq.G2Fcm_valser_mant = (float)tmpSrv.fcm_valser_mant;
                            // si tipo actividad es "2" , PYP se debe poner el centro de produccion segun servicios IPS
                            if (tmp.sia_tipact_tsac == "2")
                            {
                                gobLiq.G2Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro;
                            }

                            // generar el numero de registro
                            if (tcrAccion == "1")
                            {
                                tmpRegAdm.Adm_conest_rgad++;
                                gobLiq.G2Fcm_secreg_dfac = "R" + tmpRegAdm.Adm_conest_rgad.ToString().Trim();
                                gobLiq.tmpRegAdm.Adm_conest_rgad = tmpRegAdm.Adm_conest_rgad;

                                //-  para agrupar o separar registros segun contrato y tipo actividad
                                gobLiq.G2Fcm_secreg_mfac = "XXT" + this.txtG1Cto_seccon_cont.Text.Trim();
                                if (gobLiq.G2Cto_sepser_cont == "1") // Separa por tipo de servicio
                                {
                                    gobLiq.G2Fcm_secreg_mfac = "XXT" + gobLiq.G2Sia_tipact_tsac.Trim() + gobLiq.G2Cto_seccon_cont.Trim();
                                }
                            }
                            // Validar y generar el registro a facturar desde parametros en manuales y servicios IPS
                            if (gobLiq.flgGenValidarRegistro(ref tmpLogErrores, i.ToString() + "-SERVICIO-" + lobReg.Fcm_coddig_mant))
                            {
                                if (tcrAccion == "1")
                                {
                                    var lobRegDe = gobLiq.fobGenRegistroServicioFacturado();
                                    tmpListDetallEdt.Add(lobRegDe);
                                }
                            }
                            else
                            {
                                lnuErrores++;
                            }
                        }
                        else
                        {
                            var lcrSeparador = String.IsNullOrWhiteSpace(lcrValorReturn) ? "" : "/";
                            lcrValorReturn += lcrSeparador + "SERVICIO NO AUTORIZADO EN CONTRATO: " + 
                                                             lobReg.Fcm_coddig_mant + " - " + lobReg.Odn_desreg_odde;
                            lnuErrores++;
                        }
                    }

                    llgReturn = lnuErrores == 0 ? true : false;
                    if (llgReturn == true && tcrAccion == "1")
                    {
                        tmpListFact = gobLiq.flsGenerarResumenFacturas();
                    }
                }
                //- Registrar error 
                //lcrValorReturn = i == 0 ? "No existen actividades para el programa: " + G1Cit_codspr_spro : String.Empty;
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: flgGenerarFacturas");
            }
            return llgReturn;
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
            gobLiq.G2Cto_seccon_cont = this.txtG1Cto_seccon_cont.Text;
            gobLiq.G2Fcm_codcpr_cpro = this.txtG1Fcm_codcpr_cpro.Text;
            gobLiq.G2Fcm_fecser_dfac = this.txtG1Odn_fecact_odac.Text;
            gobLiq.G2Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
            gobLiq.G2Sia_aresol_aser = tmpRegAdm.Sia_codare_aser;
            gobLiq.G2Sia_codare_aser = this.txtG1Sia_codare_aser.Text;
            gobLiq.G2Fcm_fecfac_mfac = this.txtG1Odn_fecact_odac.Text;
            gobLiq.G2Fcm_horser_dfac = Funciones.fcrHoraActual("24", gcrSeparadorDecimal);
            gobLiq.G2Fac_horprs_dfac = gobLiq.G2Fcm_horser_dfac;
            gobLiq.G2Fcm_fecedt_dfac = Funciones.fcrFechaActual();
            gobLiq.G2Fcm_estfac_mfac = "1";
            gobLiq.G2Fcm_tiprfa_mfac = "1";
        }
        #endregion
        #region flgConfirmarFacturas: Genera los numeros de factura
        /// <summary>
        /// <para>Genera los nuevos numeros de factura y guarda en maestro factura</para>  
        /// <para>actualiza los registros detalles facutracion en las ordenes de servicios</para>  
        /// </summary>
        public bool flgConfirmarFacturas()
        {
            var llgReturn = false;
            try
            {
                var lcrNewOrdenserv = String.Empty;
                if (tmpListFact == null) { return llgReturn; }

                foreach (FcmModeloMaestrofacturas lobFact in tmpListFact)
                {

                    lcrNewOrdenserv = SysModelo.fcrGenerarNuevoCodigo("FCM-ORDENSERVICIOS", "FCM", "Ordenes de servicios medicos");
                    //lobFact.Fcm_numfac_mfac = SysModelo.fcrGenerarNuevoCodigo("FCM-SECUENCIAL-FACTURAS", "FCM", "Secuencial facturas de venta");
                    lobFact.Fcm_secres_srfa = "NA";
                    lobFact.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    lobFact.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    lobFact.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    lobFact.Fcm_tiprfa_mfac = "1";
                    lobFact.Sia_tipact_tsac = "1"; // Puede cambiar al confirmar factura
                    lobFact.Sia_regate_rgat = "2";
                    lobFact.Fcm_numfac_mfac = String.Empty; // que pase a facturacion en estado abierto
                    lobFact.Fcm_estfac_mfac = "1";
                    lobFact.Fcm_desfac_mfac = "ABIERTA";
                    lobFact.Sis_estado_imaen = "A";
                    lobFact.Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                    int lnuIndice = 1;
                    //- Actualizar detalles de servicios
                    foreach (FcmModeloServDetallFacturas lobServ in tmpListDetallEdt)
                    {
                        lobServ.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                        lobServ.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                        lobServ.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                        if (lobServ.Fcm_secreg_mfac.Trim() == lobFact.Fcm_secreg_mfac.Trim())
                        {
                            lobServ.Fcm_numfac_mfac = lobFact.Fcm_numfac_mfac;
                            lobServ.Fcm_estfac_mfac = lobFact.Fcm_estfac_mfac;
                            lobServ.Fcm_secreg_mfac = lcrNewOrdenserv;
                            lobServ.Sis_estado_imaen = "A";
                            lobServ.Sis_estpro_espr = "1";
                            lobServ.Fcm_tiprfa_mfac = lobFact.Fcm_tiprfa_mfac;

                            FcmModeloServDetallFacturas.flgAddRegistro(lobServ, lobServ.Adm_secadm_rgad);
                        }
                        lnuIndice++;
                    }
                    lobFact.Fcm_secreg_mfac = lcrNewOrdenserv;
                    FcmModeloMaestrofacturas.flgAddRegistro(lobFact);
                }
                ADMModeloAdmadmisiones.fcvActualizarEstados(tmpRegAdm.Adm_secadm_rgad, "", "", "", "", "", tmpRegAdm.Adm_conest_rgad);
                llgReturn = true;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvConfirmarFacturas");
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Activar odontograma acciones
        //-------------------------------------------------
        #region fcvActivarOdontogramaMixto: Activar seleccion odontogrma adulto y niños en uno solo
        /// <summary>
        /// <para>fcvActivarOdontogramaMixto()</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Activar seleccion odontogrma adulto y niños en uno solo</para>
        /// </summary>
        public void fcvActivarOdontogramaMixto()
        {
            // Click Adulto
            #region Cuadrante 1
            this.odnMixto.D11.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D12.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D13.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D14.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D15.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D16.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D17.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D18.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 2
            this.odnMixto.D21.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D22.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D23.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D24.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D25.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D26.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D27.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D28.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 3
            this.odnMixto.D31.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D32.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D33.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D34.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D35.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D36.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D37.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D38.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            #region Cuadrante 4
            this.odnMixto.D41.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D42.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D43.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D44.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D45.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D46.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D47.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D48.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            // Touch Adulto
            #region Cuadrante 1
            this.odnMixto.D11.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D12.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D13.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D14.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D15.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D16.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D17.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D18.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 2
            this.odnMixto.D21.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D22.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D23.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D24.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D25.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D26.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D27.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D28.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 3
            this.odnMixto.D31.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D32.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D33.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D34.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D35.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D36.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D37.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D38.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
            #region Cuadrante 4
            this.odnMixto.D41.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D42.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D43.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D44.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D45.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D46.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D47.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D48.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
            // Click Niños
            #region Cuadrante 1
            this.odnMixto.D51.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D52.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D53.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D54.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D55.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 2
            this.odnMixto.D61.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D62.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D63.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D64.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D65.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 3
            this.odnMixto.D71.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D72.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D73.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D74.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D75.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            #region Cuadrante 4
            this.odnMixto.D81.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D82.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D83.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D84.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D85.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            // Touch Niños
            #region Cuadrante 1
            this.odnMixto.D51.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D52.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D53.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D54.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D55.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 2
            this.odnMixto.D61.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D62.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D63.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D64.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D65.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 3
            this.odnMixto.D71.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D72.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D73.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D74.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D75.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
            #region Cuadrante 4
            this.odnMixto.D81.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D82.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D83.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D84.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D85.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
        }
        #endregion
        #region fcvActivarOdontogramaAdulto: Activar seleccion odontogrma adulto
        /// <summary>
        /// <para>fcvActivarOdontogramaAdulto()</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Activar seleccion odontogrma adulto</para>
        /// </summary>
        public void fcvActivarOdontogramaAdulto()
        {
            // Click
            #region Cuadrante 1
            this.odnAdulto.D11.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D12.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D13.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D14.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D15.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D16.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D17.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D18.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 2
            this.odnAdulto.D21.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D22.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D23.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D24.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D25.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D26.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D27.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnAdulto.D28.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 3
            this.odnAdulto.D31.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D32.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D33.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D34.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D35.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D36.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D37.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D38.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            #region Cuadrante 4
            this.odnAdulto.D41.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D42.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D43.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D44.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D45.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D46.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D47.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnAdulto.D48.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            // Touch
            #region Cuadrante 1
            this.odnAdulto.D11.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D12.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D13.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D14.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D15.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D16.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D17.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D18.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 2
            this.odnAdulto.D21.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D22.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D23.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D24.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D25.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D26.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D27.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnAdulto.D28.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 3
            this.odnAdulto.D31.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D32.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D33.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D34.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D35.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D36.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D37.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D38.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
            #region Cuadrante 4
            this.odnAdulto.D41.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D42.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D43.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D44.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D45.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D46.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D47.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnAdulto.D48.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
        }
        #endregion
        #region fcvActivarOdontogramaNiños: Activar seleccion odontogrma niños
        /// <summary>
        /// <para>fcvActivarOdontogramaNiños()</para>
        /// <para>DESCRIPCION:</para>
        /// <para> Activar seleccion odontogrma niños</para>
        /// </summary>
        public void fcvActivarOdontogramaNiños()
        {
            // Click
            #region Cuadrante 1
            this.odnNino.D51.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnNino.D52.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnNino.D53.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnNino.D54.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnNino.D55.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 2
            this.odnNino.D61.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnNino.D62.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnNino.D63.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnNino.D64.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnNino.D65.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 3
            this.odnNino.D71.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnNino.D72.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnNino.D73.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnNino.D74.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnNino.D75.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            #region Cuadrante 4
            this.odnNino.D81.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnNino.D82.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnNino.D83.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnNino.D84.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnNino.D85.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            // Touch
            #region Cuadrante 1
            this.odnNino.D51.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnNino.D52.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnNino.D53.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnNino.D54.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnNino.D55.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 2
            this.odnNino.D61.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnNino.D62.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnNino.D63.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnNino.D64.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnNino.D65.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 3
            this.odnNino.D71.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnNino.D72.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnNino.D73.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnNino.D74.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnNino.D75.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
            #region Cuadrante 4
            this.odnNino.D81.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnNino.D82.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnNino.D83.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnNino.D84.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnNino.D85.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion

        }
        #endregion
        #region fcvMostrarSombrasOdontograma: Mostrar u ocultar sombras en cada diente y sabe si hay diagnosticos o plan de tratamientos.
        /// <summary>
        /// <para>Mostrar u ocultar sombras en cada diente y saber si hay diagnosticos o plan de tratamientos.</para>
        /// </summary>
        private void fcvMostrarSombrasOdontograma()
        {
            List<ModeloOdnDeActivTratamiento> tmpRegistros = null;
            bool llgRealizar = false;
            var lcrTipoRegistro = "1";

            if (gcrTipoRegistro == "2")
            {
                lcrTipoRegistro = "1";
                tmpRegistros = ModeloOdnDeActivTratamiento.flsListaOdneventosactdeEx(lcrTipoRegistro, gcrIdMaestroTratamiento, "");
            }
            else if (gcrTipoRegistro == "3")
            {
                lcrTipoRegistro = "2";
                tmpRegistros = ModeloOdnDeActivTratamiento.flsListaOdneventosactdeEx(lcrTipoRegistro, gcrIdMaestroTratamiento, "");
            }

            //if (tmpRegistros.Count != 0 && tmpRegistros != null)
            if (tmpRegistros != null)
            {
                foreach (var lobReg in tmpRegistros)
                {
                    llgRealizar = false;
                    if (lobReg.Sis_estpro_espr == "2" && lobReg.Odn_prexis_odde == "2" && lobReg.Odn_coddie_oddi != "NA")
                    {
                        llgRealizar = lcrTipoRegistro == "2" && lobReg.Odn_estact_odac == "3" ? false : true;
                    }
                    // No cargar los tratamientos finalizados o los pre existentes 
                    // Cargar el registro
                    if (llgRealizar == true)
                    {
                        if (tmpRegMsTratamiento.Odn_tgrafi_odev == "1") //Odontogrma adultos
                        {
                            this.odnAdulto.fcvMostrarSombraDiente(lobReg.Odn_coddie_oddi, "1");
                        }
                        else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "2") //Odontogrma niños
                        {
                            this.odnNino.fcvMostrarSombraDiente(lobReg.Odn_coddie_oddi, "1");
                        }
                        else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "3") //Odontogrma mixto
                        {
                            this.odnMixto.fcvMostrarSombraDiente(lobReg.Odn_coddie_oddi, "1");
                        }
                    }
                }
            }
        }
        #endregion
        #region fcvGraficarOdontogramaDesdeBdatos: Mostrar registros graficados en odontograma desde base de datos.
        /// <summary>
        /// <para>Mostrar graficas en odontograma de registros ya existentes en base de datos.</para>
        /// </summary>
        private void fcvGraficarOdontogramaDesdeBdatos()
        {
            if (tmpTablaDetalles.Count != 0 && tmpTablaDetalles != null)
            {
                foreach (var lobReg in tmpTablaDetalles)
                {
                    if (lobReg.Odn_coddie_oddi != "NA" && !String.IsNullOrWhiteSpace(lobReg.Odn_coddie_oddi)) 
                    {
                        fcrAddVistaGraficaEnOdontograma(lobReg);
                    }
                    // Aplicar registro en todo el odontograma
                    if (lobReg.Odn_aplvis_odde == "1")
                    {
                        var lcrListaDientes = lobReg.Odn_aplist_odde;
                        fcvAplicarTodosDxyServiOdontograma("2", lobReg, lobReg.Odn_tipreg_odac, lcrListaDientes);
                    }
                }
            }
        }
        #endregion
        #region fcvAplicarTodosDxyServiOdontograma: Generar vista registro simple general aplicado en todo odontograma
        /// <summary>
        /// <para>Genera la vista en cada diente seleccionado, para aplicar un registro de la</para>
        /// <para>Pestaña general en el odontograma, para imagenes simples</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrAccion: 1=Agregar grafica 2=Eliminar grafica</para>
        /// <para>tcrTipoRegistro: 1 = Diagnostico, 2 = Plan de tratamiento</para>
        /// <para>tcrListaDientes: Lista de dientes separados por gion medio (-)</para>
        /// </summary>
        public void fcvAplicarTodosDxyServiOdontograma(String tcrAccion, ModeloOdnDeActivTratamiento tobRegistro, String tcrTipoRegistro, String tcrListaDientes)
        {

            int i;
            String lcrValor = string.Empty;
            String lcrBakLlave = tobRegistro.Odn_nroreg_odde;
            String lcrBakDiente = tobRegistro.Odn_coddie_oddi;
            String[] larArray = tcrListaDientes.Split('-');
            int lnuTotElemtos = larArray.Length;

            for (i = 0; i < lnuTotElemtos; i++)
            {
                tobRegistro.Odn_coddie_oddi = larArray[i].ToUpper();
                tobRegistro.Odn_nroreg_odde = lcrBakLlave + "D" + larArray[i].ToUpper();

                // Generar vista
                if (tcrAccion == "1")
                {
                    fcrAddVistaGraficaEnOdontograma(tobRegistro);
                }
                else
                {
                    //este llamado viene desde fcvEliminarRegistroDetalle 
                    this.odnMixto.flgEliminarImagenEnVista(tobRegistro.Odn_nroreg_odde);
                }
            }
            // Restaurar valores 
            tobRegistro.Odn_coddie_oddi = lcrBakDiente;
            tobRegistro.Odn_nroreg_odde = lcrBakLlave;

        }
        #endregion
        #region Click o Touch sobre un item del odontograma
        /// <summary>
        ///  <para>fcvClickItem01: Click sobre un item del odontograma</para>
        /// </summary>
        private void fcvClickItem01(Object sender, MouseButtonEventArgs e)
        {
            Diente01 lobControl = (Diente01)sender;
            gcrIdItemServicioGrafica = lobControl.gnuNumeroDiente.ToString();
            fcvActivarDatosPropDetalles(gcrIdItemServicioGrafica);
            if (glgVistaSeleccion == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        /// <summary>
        ///  <para>fcvTilesTouchDownItem01: Touch sobre un item del odontograma</para>
        /// </summary>
        private void fcvTilesTouchDownItem01(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            Diente01 lobControl = (Diente01)sender;
            gcrIdItemServicioGrafica = lobControl.gnuNumeroDiente.ToString();
            fcvActivarDatosPropDetalles(gcrIdItemServicioGrafica);
            if (glgVistaSeleccion == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        /// <summary>
        ///  <para>fcvClickItem02: Click sobre un item del odontograma</para>
        /// </summary>
        private void fcvClickItem02(Object sender, MouseButtonEventArgs e)
        {
            Diente02 lobControl = (Diente02)sender;
            gcrIdItemServicioGrafica = lobControl.gnuNumeroDiente.ToString();
            fcvActivarDatosPropDetalles(gcrIdItemServicioGrafica);
            if (glgVistaSeleccion == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        /// <summary>
        ///  <para>fcvTilesTouchDownItem02: Touch sobre un item del odontograma</para>
        /// </summary>
        private void fcvTilesTouchDownItem02(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            Diente02 lobControl = (Diente02)sender;
            gcrIdItemServicioGrafica = lobControl.gnuNumeroDiente.ToString();
            fcvActivarDatosPropDetalles(gcrIdItemServicioGrafica);
            if (glgVistaSeleccion == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        /// <summary>
        ///  <para>fcvClickPropGeneral: clic sobre el boton propiedades general</para>
        /// </summary>
        private void fcvClickPropGeneral(object sender, RoutedEventArgs e)
        {
            gcrIdItemServicioGrafica = "NA";
            fcvActivarDatosPropDetalles(gcrIdItemServicioGrafica);
            if (glgVistaSeleccion == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        //- Graficar y cargar registro detalles
        #region fcrAddVistaGraficaEnOdontograma: Genera vista graficada del registro detalle en odonograma
        /// <summary>
        /// <para>Genera vista graficada del registro detalle en odonograma</para>
        /// <para>segun el Odontograma y diente seleccionado</para>
        /// <para>VALOR RETORNO</para>
        /// <para>Retorna el nombre de la imagen utilizada para graaficar en odontograma</para>
        /// <para>cuando no se representa grafica en odontograma, devuelve un nombre de imagen por defecto</para>
        /// </summary>
        private String fcrAddVistaGraficaEnOdontograma(ModeloOdnDeActivTratamiento tobRegistro)
        {
            var lcrImagenGrafica = "hc_od_sinimagen.png";
            if (tobRegistro != null)
            {
                // Ver si se grafica en corona o en diente 
                if (tobRegistro.Odn_tipvis_odsi == "1") // se grafica en corona
                {
                    var lcrEstadoAct = tobRegistro.Odn_tipreg_odac == "1" ? "1" : tobRegistro.Odn_estact_odac.Trim();
                    lcrEstadoAct = tobRegistro.Odn_prexis_odde == "1" ? "2" : lcrEstadoAct;
                    var lcrEstadoCara = tobRegistro.Odn_carmar_odde.Trim() + lcrEstadoAct;

                    tobRegistro.Odn_imagen_odde = ODNValidarCodigo.fobRegBuscarOdnimgcracorona(lcrEstadoCara).odn_imagen_odcr;

                    if (tmpRegMsTratamiento.Odn_tgrafi_odev == "1") //Odontogrma adultos
                    {
                        this.odnAdulto.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi, "1", tobRegistro.Odn_imagen_odde, "2");
                    }
                    else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "2") //Odontogrma niños
                    {
                        this.odnNino.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi, "1", tobRegistro.Odn_imagen_odde, "2");
                    }
                    else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "3") //Odontogrma Mixto
                    {
                        this.odnMixto.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi, "1", tobRegistro.Odn_imagen_odde, "2");
                    }
                    lcrImagenGrafica = tobRegistro.Odn_imagen_odde;
                }
                else if (tobRegistro.Odn_tipvis_odsi == "2")
                {
                    // se grafica en diente
                    if (!String.IsNullOrWhiteSpace(tobRegistro.Odn_codimg_odim))
                    {
                        var tmpDiente = ODNValidarCodigo.fobRegBuscarOdnmaestdientes(tobRegistro.Odn_coddie_oddi);
                        var tmpImagen = ODNValidarCodigo.fobRegBuscarOdnimagengrafms(tobRegistro.Odn_codimg_odim);

                        var lcrCuadrante = tmpDiente.odn_codcte_odcd;
                        var lcrCodImagen = tobRegistro.Odn_codimg_odim;
                        var lcrOcultaDiente = tmpImagen.odn_visite_odim;

                        var tmpGrafica = HclUtilidades.fobOdontogramaSeletImagenGraficar(lcrCodImagen, "1", lcrCuadrante, tobRegistro.Odn_coddie_oddi);
                        if (tmpGrafica != null)
                        {
                            var lcrZonaGrafica = tmpGrafica.odn_gravis_odid;

                            lcrImagenGrafica = HclUtilidades.fcrReturnNombreImagenEstadoAct(tmpRegMaestro.Odn_tipreg_odac, tobRegistro, tmpGrafica);

                            if (tmpRegMsTratamiento.Odn_tgrafi_odev == "1") //Odontogrma adultos
                            {
                                this.odnAdulto.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi, 
                                                                        lcrZonaGrafica, lcrImagenGrafica, lcrOcultaDiente);
                            }
                            else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "2") //Odontogrma niños
                            {
                                this.odnNino.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi, 
                                                                       lcrZonaGrafica, lcrImagenGrafica, lcrOcultaDiente);
                            }
                            else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "3") //Odontogrma Mixto
                            {
                                this.odnMixto.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi,
                                                                       lcrZonaGrafica, lcrImagenGrafica, lcrOcultaDiente);
                            }
                        }
                    }
                }
            }
            return lcrImagenGrafica;
        }
        #endregion
        #region fcvAddRegistroDetalleGrafico: Genera objeto del registro en detalles vista propiedades
        /// <summary>
        /// Genera objeto del registro en detalles vista propiedades 
        /// </summary>
        private void fcvAddRegistroDetalleGrafico(ModeloOdnDeActivTratamiento tobRegistro)
        {
            if (tobRegistro != null)
            {
                var lcrImagen = tobRegistro.Odn_imagen_odde;
                var lcrRutaImagen = @"GaleriaRecursos\Imagenes\Odontologia\";
                var lobUri = new EdtUtilidades.ObjetoBitmapImage();
                var lcrCodigo = tmpRegMaestro.Odn_tipreg_odac == "1" ? tobRegistro.Sia_coddia_tdia : tobRegistro.Fcm_codser_mant;

                lobUri.AppIpServidor = oApp.gcrAppRecursoIpServidor;
                lobUri.AppInicioPath = oApp.gcrAppRecursoInicioPath;
                lobUri.RutaGaleria   = lcrRutaImagen;
                lobUri.NombreArchivo = lcrImagen;


                var lobDetalle = new ControlOrdOdontoServiciosRegistro();
                lobDetalle.cmdEliminar.Click += new RoutedEventHandler(fcvEliminarRegistroDetalle);

                lobDetalle.txtItem.Text = tobRegistro.Odn_desana_odan;
                lobDetalle.txtDetalle.Text = lcrCodigo + " - " + tobRegistro.Odn_desreg_odde;

                lobDetalle.cmdEliminar.Visibility = tobRegistro.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                lobDetalle.imgEstado.Visibility = tobRegistro.Sis_estpro_espr == "1" ? Visibility.Collapsed : Visibility.Visible;

                lobDetalle.imgGrafica.Source = EdtUtilidades.SetBitmapImageUri(lobUri);
                lobDetalle.imgGrafica.Stretch = Stretch.Fill;

                lobDetalle.IdRegistro = tobRegistro.Odn_nroreg_odde;
                lobDetalle.IdR1Registro = tobRegistro.Odn_nroreg_odac;

                this.stkDetalles.Children.Add(lobDetalle);
            }
        }
        #endregion
        //- Consulta SQL  desde maestros y en temporal detalles
        #region fobSQLSelectDetallesActividad: Devuelve una lista de registros desde maestro detalles actividad
        /// <summary>
        /// <para>Devuelve una lista de registros desde maestro detalles actividad.</para> 
        /// <para>PARAMETROS:</para> 
        /// <para>tcrIdRegistro: Codigo unico del Registro maestro actividad.</para> 
        /// </summary>
        private List<ModeloOdnDeActivTratamiento> fobSQLSelectDetallesActividad(String tcrIdRegistro)
        {
            List<ModeloOdnDeActivTratamiento> lcrQuery = new List<ModeloOdnDeActivTratamiento>();
            if (!String.IsNullOrWhiteSpace(tcrIdRegistro))
            {
                lcrQuery = ModeloOdnDeActivTratamiento.flsListaOdneventosactde("R1", tcrIdRegistro);
                if (lcrQuery == null || lcrQuery.Count <= 0)
                {
                    lcrQuery = new List<ModeloOdnDeActivTratamiento>();
                }
            }
            return lcrQuery;
        }
        #endregion
        #region fobSQLSelectTempRegistros: Devuelve una lista de registros desde el temporal
        /// <summary>
        /// <para>PARAMETROS:</para> 
        /// <para>tcrTipoId: "1" = Id unico del registro (odn_nroreg_odde) "2" = Id Diente (odn_coddie_oddi).</para> 
        /// <para>tcrIdRegistro: Puede ser el id unico de registro o el numero de un diente.</para> 
        /// </summary>
        private List<ModeloOdnDeActivTratamiento> fobSQLSelectTempRegistros(String tcrTipoId, String tcrIdRegistro)
        {
            List<ModeloOdnDeActivTratamiento> lcrQuery = null;
            if (tcrTipoId == "1") // Id unico registro (odn_nroreg_odde)
            {
                lcrQuery = (from lst in tmpTablaDetalles
                            where lst.Odn_nroreg_odde.Equals(tcrIdRegistro)
                            select lst).ToList();
            }
            else
            {
                lcrQuery = (from lst in tmpTablaDetalles
                            where lst.Odn_coddie_oddi.Equals(tcrIdRegistro)
                            select lst).ToList();
            }
            return lcrQuery;
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
            this.Close();
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
                    ComboBox lobCombo = (ComboBox)sender;
                    var lnuIndex = lobCombo.SelectedIndex <= 0 ? 0 : lobCombo.SelectedIndex;

                    switch (lobCombo.Name)
                    {
                        case "cboRelDiagnostico":
                            if (lstRefDiagnosticos != null)
                            {
                                this.txtRelDiagnostico.Text = lstRefDiagnosticos[lnuIndex].ValorSeleccion;
                                tmpRegActiDetalle.Odn_auxreg_odde = lstRefDiagnosticos[lnuIndex].ValorSeleccion;
                            }
                            break;

                        case "cboG3RelPlanTratamiento":
                            if (lstRefPlanTratamiento != null)
                            {
                                this.txtG3RelPlanTratamiento.Text = lstRefPlanTratamiento[lnuIndex].ValorSeleccion;
                                tmpRegActiDetalle.Odn_auxreg_odde = lstRefPlanTratamiento[lnuIndex].ValorSeleccion;
                                this.txtG3Fcm_coddig_mant.Text = lstRefPlanTratamiento[lnuIndex].ListaValoresSel;
                            }
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
                        case "txtRelDiagnostico":
                            //CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboRelDiagnostico.SelectedItem;
                            //cboRelDiagnostico.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;

                        case "txtG3RelPlanTratamiento":
                            //CrtForms.ListaComboBox lobG2ComboBox1 = (CrtForms.ListaComboBox)cboG3RelPlanTratamiento.SelectedItem;
                            //cboG3RelPlanTratamiento.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG2ComboBox1.ListaValoresSel);
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
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Odn_nroreg_odac":
                    txtG1Odn_nroreg_odac.Text = tcrCodigo;
                    break;

                case "txtG1Cto_seccon_cont":
                    txtG1Cto_seccon_cont.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG1Hcl_tiptur_hctu":
                    txtG1Hcl_tiptur_hctu.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codare_aser":
                    txtG1Sia_codare_aser.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codcpr_cpro":
                    txtG1Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codpfa_prof":
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Odn_coddia_oddx":
                    txtG1Odn_coddia_oddx.Text = tcrCodigo;
                    FocusManager.SetFocusedElement(this, this.cmdAddRegistros);
                    break;

                case "txtG2Fcm_coddig_mant":
                    txtG2Fcm_coddig_mant.Text = tcrCodigo;
                    FocusManager.SetFocusedElement(this, this.txtG2Odn_totuni_odde);
                    break;

                case "txtG3Fcm_coddig_mant":
                    txtG3Fcm_coddig_mant.Text = tcrCodigo;
                    FocusManager.SetFocusedElement(this, this.txtG3Odn_fecini_odde);
                    break;

            }
        }
        // ODNEVENTOSACTMS : Maestro registro unico actividad en cada cita
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
            Browser01 frbro = new Browser01("CTO", "CTOMAESCONTRATO", "", "Maestro contratos con  EPS o aseguradores...");
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
        #region HCL_TIPTUR_HCTU : Tipo registro turnos diarios prestacion de servicios medicos
        private void txtG1Hcl_tiptur_hctu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Hcl_tiptur_hctu_Browser();
            }
        }
        private void cmdG1Hcl_tiptur_hctu_Click(object sender, RoutedEventArgs e)
        {
            txtG1Hcl_tiptur_hctu_Browser();
        }
        private void txtG1Hcl_tiptur_hctu_Browser()
        {
            Browser01 frbro = new Browser01("HCL", "HCLTIPOREGTURNO", "", "Tipo registro turnos diarios prestacion de servicios medicos...");
            gcrCtrF2TexBox = "txtG1Hcl_tiptur_hctu";
            frbro.Owner = this;
            frbro.ShowDialog();
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
        #region ODN_CODDIA_ODDX : Diagnosticos odontologicos
        private void txtG2Odn_coddia_oddx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG2Odn_coddia_oddx_Browser();
            }
        }
        private void cmdG2Odn_coddia_oddx_Click(object sender, RoutedEventArgs e)
        {
            txtG2Odn_coddia_oddx_Browser();
        }
        private void txtG2Odn_coddia_oddx_Browser()
        {
            Browser01 frbro = new Browser01("ODN", "ODNDIAGNOSTICOS", "", "Diagnosticos odontologicos...");
            gcrCtrF2TexBox = "txtG1Odn_coddia_oddx";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                txtG2Fcm_coddig_mant_Browser();
            }
        }
        private void cmdG2Fcm_coddig_mant_Click(object sender, RoutedEventArgs e)
        {
            txtG2Fcm_coddig_mant_Browser();
        }
        private void txtG2Fcm_coddig_mant_Browser()
        {
            if (!String.IsNullOrWhiteSpace(tmpRegMaestro.Fcm_codman_mans))
            {
                Browser01 frbro = new Browser01("ODN", "ODNSERVICIOSIPS", tmpRegMaestro.Fcm_codman_mans, "Manual servicios odontologia...");
                gcrCtrF2TexBox = "txtG2Fcm_coddig_mant";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Primero debe seleccionar un numero de contrato.");
            }
        }
        private void txtG3Fcm_coddig_mant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG3Fcm_coddig_mant_Browser();
            }
        }
        private void cmdG3Fcm_coddig_mant_Click(object sender, RoutedEventArgs e)
        {
            txtG3Fcm_coddig_mant_Browser();
        }
        private void txtG3Fcm_coddig_mant_Browser()
        {
            if (!String.IsNullOrWhiteSpace(tmpRegMaestro.Fcm_codman_mans))
            {
                Browser01 frbro = new Browser01("ODN", "ODNSERVICIOSIPS", tmpRegMaestro.Fcm_codman_mans, "Manual servicios odontologia...");
                gcrCtrF2TexBox = "txtG3Fcm_coddig_mant";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Primero debe seleccionar un numero de contrato.");
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
                    case "dpkG1Odn_fecact_odac":
                        txtG1Odn_fecact_odac.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Odn_fecact_odac);
                        break;
                    case "dpkG3Odn_fecini_odde":
                        txtG3Odn_fecini_odde.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG3Odn_fecini_odde);
                        break;
                    case "dpkG3Odn_fecfin_odde":
                        txtG3Odn_fecfin_odde.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG3Odn_fecfin_odde);
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
                            case "txtG1Odn_fecact_odac":
                                dpkG1Odn_fecact_odac.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG3Odn_fecini_odde":
                                dpkG3Odn_fecini_odde.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG3Odn_fecfin_odde":
                                dpkG3Odn_fecfin_odde.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        // CARGAR DATOS EN VARIABLES O TEMPORAL 
        //-------------------------------------------------
        #region fcvIniciarVariablesVista:  Iniciar las variables de la vista
        /// <summary>
        ///  <para>Inicia las variables para edicion en vista</para>
        ///  <para>tcrTipoVariables: "1" = Variables para datos R1 Maestro actividades "2" = Variables para captura detalles</para>
        /// </summary>
        private void fcvIniciarVariablesVista(String tcrTipoVariables)
        {
            if (tcrTipoVariables == "1")
            {
                // buscar 
                var lcrTipoRegAct  = "1";
                var lcrSecContrato = tmpRegAdm.Cto_seccon_cont;
                var lcrCodigoEps   = tmpRegAdm.Sia_codeps_teps;
                var lcrProfesional = tmpRegMsTratamiento.Sia_codpfa_prof;
                var lcrAreaServicio= tmpRegMsTratamiento.Sia_codare_aser;
                var lcrTipoTurno   = String.Empty;
                var lcrCentroProcc = String.Empty;

                switch (gcrTipoRegistro)
                {
                    case "1": // Diagnostico
                        lcrTipoRegAct =String.Empty;
                        break;

                    case "2": // Plan de tratamiento
                        lcrTipoRegAct ="1";
                        break;

                    case "3": // Actividades evoluicion
                        lcrTipoRegAct ="2";
                        break;
                }
                if (!String.IsNullOrWhiteSpace(lcrTipoRegAct))
                {
                    var tmpReg = ModeloOdnMsActivTratamiento.flsListaOdneventosactmsRef(lcrTipoRegAct, tmpRegMsTratamiento.Odn_nroreg_odev);
                    if (tmpReg != null)
                    {
                        lcrSecContrato  = tmpReg.FirstOrDefault().Cto_seccon_cont;
                        lcrCodigoEps    = tmpReg.FirstOrDefault().Sia_codeps_teps;
                        lcrProfesional  = tmpReg.FirstOrDefault().Sia_codpfa_prof;
                        lcrAreaServicio = tmpReg.FirstOrDefault().Sia_codare_aser;
                        lcrTipoTurno    = tmpReg.FirstOrDefault().Hcl_tiptur_hctu;
                        lcrCentroProcc  = tmpReg.FirstOrDefault().Fcm_codcpr_cpro;
                    }
                }

                // Asginar valores
                this.txtG1Odn_nroreg_odac.Text = String.Empty;
                this.txtG1Odn_fecact_odac.Text = tmpRegAdm.Adm_fecadm_rgad.ToShortDateString();
                this.txtG1Hcl_tiptur_hctu.Text = lcrTipoTurno;
                this.txtG1Cto_seccon_cont.Text = lcrSecContrato;
                this.txtG1Sia_codeps_teps.Text = lcrCodigoEps;
                this.txtG1Sia_codpfa_prof.Text = lcrProfesional;
                this.txtG1Sia_codare_aser.Text = lcrAreaServicio;
                this.txtG1Fcm_codcpr_cpro.Text = lcrCentroProcc;
                this.txtG1Odn_observ_odac.Text = String.Empty;
            }
            else 
            {
                var lcrCodigoRelacion = tmpRegActiDetalle.Odn_auxreg_odde;

                tmpRegActiDetalle = new ModeloOdnDeActivTratamiento();
                tmpRegActiDetalle.Odn_auxreg_odde = lcrCodigoRelacion;
                tmpRegActiDetalle.Odn_coddie_oddi = gcrIdItemServicioGrafica;

                this.chkCara1.IsChecked = false;
                this.chkCara2.IsChecked = false;
                this.chkCara3.IsChecked = false;
                this.chkCara4.IsChecked = false;
                this.chkCara5.IsChecked = false;

                //this.chkG2Odn_prexis_odde.IsChecked = lstRefDiagnosticos == null ? true: false;
                this.chkG3Odn_finpro_odde.IsChecked = true;

                switch (gcrTipoRegistro)
                {
                    case "1": // Diagnostico
                        this.txtG1Odn_coddia_oddx.Text = String.Empty;
                        this.txtG1Odn_desdia_oddx.Text = String.Empty;
                        break;

                    case "2": // Plan de tratamiento
                        this.txtG2Fcm_coddig_mant.Text = String.Empty;
                        this.txtG2Fcm_desser_mant.Text = String.Empty;
                        this.txtG2Odn_totuni_odde.Text = "1";
                        break;

                    case "3": // Actividades evoluicion
                        this.txtG3Fcm_coddig_mant.Text = String.Empty;
                        this.txtG3Fcm_desser_mant.Text = String.Empty;
                        this.txtG3Odn_fecini_odde.Text = tmpRegAdm.Adm_fecadm_rgad.ToShortDateString();
                        this.txtG3Odn_fecfin_odde.Text = tmpRegAdm.Adm_fecadm_rgad.ToShortDateString();
                        this.txtG3Odn_totuni_odde.Text = "1";
                        break;
                }
            }
        }
        #endregion
        #region flgCargarDatosExitentesEnVista: Cargar datos maestro R1 actividades en objetos vista del formulario
        /// <summary>
        /// <para>Cargar datos maestro R1 actividades en objetos vista del formulario</para>
        /// <para>y el temporal del maestro actividad (tmpRegMaestro)</para>
        /// </summary>
        private bool flgCargarDatosExitentesEnVista(String tcrCodigoActividad)
        {
            // cargar datos
            var llgReturn = false;
            var lobReg = ModeloOdnMsActivTratamiento.flsListaOdneventosactmsEx("1", tcrCodigoActividad, "");
            if (lobReg.Count != 0)
            {
                tmpRegMaestro = lobReg.FirstOrDefault();
                gcrCodigoRegistro = tmpRegMaestro.Odn_nroreg_odac;

                #region Vista campos
                this.txtG1Odn_nroreg_odac.Text = tmpRegMaestro.Odn_nroreg_odac;
                this.txtG1Odn_fecact_odac.Text = tmpRegMaestro.Odn_fecact_odac.ToShortDateString();
                this.txtG1Hcl_tiptur_hctu.Text = tmpRegMaestro.Hcl_tiptur_hctu;
                this.txtG1Sia_codpfa_prof.Text = tmpRegMaestro.Sia_codpfa_prof;
                this.txtG1Cto_seccon_cont.Text = tmpRegMaestro.Cto_seccon_cont;
                this.txtG1Sia_codeps_teps.Text = tmpRegMaestro.Sia_codeps_teps;
                this.txtG1Sia_codare_aser.Text = tmpRegMaestro.Sia_codare_aser;
                this.txtG1Fcm_codcpr_cpro.Text = tmpRegMaestro.Fcm_codcpr_cpro;
                this.txtG1Odn_observ_odac.Text = tmpRegMaestro.Odn_observ_odac;
                #endregion
                // Registros de tipo detalle 
                tmpTablaDetalles = ModeloOdnDeActivTratamiento.flsListaOdneventosactde("R1",tcrCodigoActividad);

                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region fcvActivarObjetosCaptura: Activar o desactivar los objetos de captura de datos
        /// <summary>
        /// <para>Activar o desactivar los objetos de captura de datos</para>
        /// </summary>
        private void fcvActivarObjetosCaptura(bool tlgEstado)
        {
            #region Vista campos
            this.dpkG1Odn_fecact_odac.IsEnabled = tlgEstado;
            this.txtG1Odn_nroreg_odac.IsEnabled = tlgEstado;
            this.txtG1Odn_fecact_odac.IsEnabled = tlgEstado;
            this.txtG1Hcl_tiptur_hctu.IsEnabled = tlgEstado;
            this.txtG1Sia_codpfa_prof.IsEnabled = tlgEstado;
            this.txtG1Cto_seccon_cont.IsEnabled = tlgEstado;
            this.txtG1Sia_codeps_teps.IsEnabled = tlgEstado;
            this.txtG1Sia_codare_aser.IsEnabled = tlgEstado;
            this.txtG1Fcm_codcpr_cpro.IsEnabled = tlgEstado;
            this.txtG1Odn_observ_odac.IsEnabled = tlgEstado;

            this.cmdG1Hcl_tiptur_hctu.IsEnabled = tlgEstado;
            this.cmdG1Sia_codpfa_prof.IsEnabled = tlgEstado;
            this.cmdG1Cto_seccon_cont.IsEnabled = tlgEstado;
            this.cmdG1Sia_codeps_teps.IsEnabled = tlgEstado;
            this.cmdG1Sia_codare_aser.IsEnabled = tlgEstado;
            this.cmdG1Fcm_codcpr_cpro.IsEnabled = tlgEstado;
            this.cmdAddRegistros.IsEnabled = tlgEstado;

            this.cmdGuardar.IsEnabled = tlgEstado;
            this.cmdConfirmar.IsEnabled = tlgEstado;


            #endregion
        }
        #endregion
        #region fcvCargarRegMaestroActDesdeVariables: Cargar Registro Maestro actividad desde Variables
        /// <summary>
        /// <para>Cargar Registro Maestro actividad desde Variables</para>
        /// <para>de edición en vista formulario.</para>
        /// </summary>
        public virtual void fcvCargarRegMaestroActDesdeVariables()
        {
            try
            {
                #region Valores Variables
                tmpRegMaestro.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                tmpRegMaestro.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegMaestro.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                tmpRegMaestro.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                tmpRegMaestro.Hcl_tipreg_hctr = gcrTipoRegistroHclinico;
                tmpRegMaestro.Odn_nroreg_odev = tmpRegMsTratamiento.Odn_nroreg_odev;
                tmpRegMaestro.Odn_tipreg_odac = gcrTipoRegistro;
                tmpRegMaestro.Cto_seccon_cont = this.txtG1Cto_seccon_cont.Text;
                tmpRegMaestro.Cto_nrocon_cont = this.txtG1Cto_nrocon_cont.Text;
                tmpRegMaestro.Sia_codeps_teps = this.txtG1Sia_codeps_teps.Text;
                tmpRegMaestro.Odn_fecact_odac = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Odn_fecact_odac.Text);
                tmpRegMaestro.Hcl_tiptur_hctu = this.txtG1Hcl_tiptur_hctu.Text;
                tmpRegMaestro.Sia_codare_aser = this.txtG1Sia_codare_aser.Text;
                tmpRegMaestro.Fcm_codcpr_cpro = this.txtG1Fcm_codcpr_cpro.Text;
                tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegMaestro.Odn_sisfec_odac = DateTime.Now;
                tmpRegMaestro.Odn_sishor_odac = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                tmpRegMaestro.Odn_observ_odac = this.txtG1Odn_observ_odac.Text;
                tmpRegMaestro.Odn_estact_odac = "2";
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fcvCargarRegMaestroActDesdeVariables");
            }
        }
        #endregion
        #region fcvCargarRegDetalleDesdeVariables: Cargar Registro detalle activo desde Variables
        /// <summary>
        /// Cargar Registro detalle activo desde Variables
        /// </summary>
        public virtual void fcvCargarRegDetalleDesdeVariables()
        {
            try
            {
                #region Valores Variables
                tmpRegActiDetalle.Odn_nroreg_odac = tmpRegMaestro.Odn_nroreg_odac;
                tmpRegActiDetalle.Sia_idesec_usua = tmpRegMsTratamiento.Sia_idesec_usua;
                tmpRegActiDetalle.Odn_nroreg_odev = tmpRegMsTratamiento.Odn_nroreg_odev;
                tmpRegActiDetalle.Odn_tipreg_odac = gcrTipoRegistro;
                tmpRegActiDetalle.Odn_fecact_odac = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Odn_fecact_odac.Text);
                tmpRegActiDetalle.Odn_coddie_oddi = gcrIdItemServicioGrafica;
                tmpRegActiDetalle.Odn_estact_odac = "1";
                tmpRegActiDetalle.Odn_prexis_odde = "2";
                tmpRegActiDetalle.Odn_finpro_odde = "2";
                tmpRegActiDetalle.Sis_estpro_espr = tmpRegMaestro.Sis_estpro_espr;

                switch (gcrTipoRegistro)
                {
                    case "1": // Diagnostico
                        tmpRegActiDetalle.Odn_coddia_oddx = this.txtG1Odn_coddia_oddx.Text;
                        tmpRegActiDetalle.Odn_desreg_odde = this.txtG1Odn_desdia_oddx.Text;
                        break;

                    case "2": // Plan de tratamiento
                        tmpRegActiDetalle.Odn_auxreg_odde = this.txtRelDiagnostico.Text;
                        tmpRegActiDetalle.Fcm_coddig_mant = this.txtG2Fcm_coddig_mant.Text;
                        tmpRegActiDetalle.Odn_desreg_odde = this.txtG2Fcm_desser_mant.Text;
                        tmpRegActiDetalle.Odn_prexis_odde = this.chkG2Odn_prexis_odde.IsChecked == true ? "1" : "2";

                        var lobRegDx = ODNValidarCodigo.fobRegBuscarOdneventosactde(this.txtRelDiagnostico.Text);
                        tmpRegActiDetalle.Sia_coddia_tdia = lobRegDx != null ? lobRegDx.sia_coddia_tdia : String.Empty;
                        break;

                    case "3": // Actividades o Evolucion
                        tmpRegActiDetalle.Odn_auxreg_odde = this.txtG3RelPlanTratamiento.Text;
                        tmpRegActiDetalle.Fcm_coddig_mant = this.txtG3Fcm_coddig_mant.Text;
                        tmpRegActiDetalle.Odn_desreg_odde = this.txtG3Fcm_desser_mant.Text;
                        tmpRegActiDetalle.Odn_fecini_odde = Funciones.fdaConvertFecha("DMY", "/", this.txtG3Odn_fecini_odde.Text);
                        tmpRegActiDetalle.Odn_fecfin_odde = Funciones.fdaConvertFecha("DMY", "/", this.txtG3Odn_fecfin_odde.Text);
                        tmpRegActiDetalle.Odn_totuni_odde = (int)Convert.ToUInt32(this.txtG3Odn_totuni_odde.Text);
                        tmpRegActiDetalle.Odn_finpro_odde = this.chkG3Odn_finpro_odde.IsChecked == true ? "1" : "2";

                        var lobRegPl = ODNValidarCodigo.fobRegBuscarOdneventosactde(this.txtG3RelPlanTratamiento.Text);
                        tmpRegActiDetalle.Sia_coddia_tdia = lobRegPl != null ? lobRegPl.sia_coddia_tdia : String.Empty;

                        break;
                }
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
            }
        }
        #endregion
        #region fcrTipoRegHistorialClinico: Devuelve el tipo registro para historial clinico
        /// <summary>
        /// <para>Devuelve el tipo registro para historial clinico</para> 
        /// <para>tcrTipoRegistro tipo registro actividad: 1= Diagnostico, 2 = Plan de tratamiento, 3 = Actividades o Evolucion.</para> 
        /// <para>Retorna: "ODDX" = Diagnostico inicial "ODEV" = Evolucion del tratamiento	"ODTR" = Plan de tratamiento.</para> 
        /// </summary>
        private String fcrTipoRegHistorialClinico(String tcrTipoRegistro)
        {
            var lcrReturn = "ODDX";
            switch (tcrTipoRegistro)
            {
                case "1": // Diagnostico
                    lcrReturn = "ODDX";
                    break;

                case "2": // Plan de tratamiento
                    lcrReturn = "ODTR";
                    break;

                case "3": // Actividades o Evolucion
                    lcrReturn = "ODEV";
                    break;
            }
            return lcrReturn;
        }
        #endregion
        #region fcrNombreTipoRegHistorialClinico: Devuelve el nombre del tipo registro para historial clinico
        /// <summary>
        /// <para>Devuelve el nombre del tipo registro para historial clinico</para> 
        /// <para>tcrTipoRegistro: tipo registro actividad: 1= Diagnostico, 2 = Plan de tratamiento, 3 = Actividades o Evolucion.</para> 
        /// </summary>
        private String fcrNombreTipoRegHistorialClinico(String tcrTipoRegistro)
        {
            var lcrReturn = "Diagnostico inicial";
            switch (tcrTipoRegistro)
            {
                case "1": // Diagnostico
                    lcrReturn = "Diagnostico inicial";
                    break;

                case "2": // Plan de tratamiento
                    lcrReturn = "Plan de tratamiento";
                    break;

                case "3": // Actividades o Evolucion
                    lcrReturn = "Actividades evolución tratamiento";
                    break;
            }
            return lcrReturn;
        }
        #endregion
        #region fobCargarDatosRegActivoAuxiliar: Cargar datos del registro detalle activo en registro auxiliar
        /// <summary>
        /// Cargar datos del registro detalle activo (puede ser tmpRegActiDetalle) dado en parametro en nuevo registro auxiliar
        /// </summary>
        private ModeloOdnDeActivTratamiento fobCargarDatosRegActivoAuxiliar(ModeloOdnDeActivTratamiento tobRegistro)
        {
            // Cargar datos del registro detalle activo en registro auxiliar
            ModeloOdnDeActivTratamiento tmpRegAux = new ModeloOdnDeActivTratamiento();

            #region Cargar datos
            tmpRegAux.Odn_nroreg_odde = tobRegistro.Odn_nroreg_odde;
            tmpRegAux.Odn_secreg_odde = tobRegistro.Odn_secreg_odde;
            tmpRegAux.Odn_nroreg_odac = tobRegistro.Odn_nroreg_odac;
            tmpRegAux.Odn_nroreg_odev = tobRegistro.Odn_nroreg_odev;
            tmpRegAux.Sia_idesec_usua = tobRegistro.Sia_idesec_usua;
            tmpRegAux.Odn_tipreg_odac = tobRegistro.Odn_tipreg_odac;
            tmpRegAux.Odn_auxreg_odde = tobRegistro.Odn_auxreg_odde;
            tmpRegAux.Odn_fecact_odac = tobRegistro.Odn_fecact_odac;
            tmpRegAux.Odn_coddia_oddx = tobRegistro.Odn_coddia_oddx;
            tmpRegAux.Sia_coddia_tdia = tobRegistro.Sia_coddia_tdia;
            tmpRegAux.Odn_codser_odsi = tobRegistro.Odn_codser_odsi;
            tmpRegAux.Fcm_idesec_sips = tobRegistro.Fcm_idesec_sips;
            tmpRegAux.Fcm_idesec_mant = tobRegistro.Fcm_idesec_mant;
            tmpRegAux.Fcm_codser_mant = tobRegistro.Fcm_codser_mant;
            tmpRegAux.Fcm_coddig_mant = tobRegistro.Fcm_coddig_mant;
            tmpRegAux.Odn_desreg_odde = tobRegistro.Odn_desreg_odde;
            tmpRegAux.Odn_totuni_odde = tobRegistro.Odn_totuni_odde;
            tmpRegAux.Odn_coddie_oddi = tobRegistro.Odn_coddie_oddi;
            tmpRegAux.Odn_codana_odan = tobRegistro.Odn_codana_odan;
            tmpRegAux.Odn_carmar_odde = tobRegistro.Odn_carmar_odde;
            tmpRegAux.Odn_fecini_odde = tobRegistro.Odn_fecini_odde;
            tmpRegAux.Odn_fecfin_odde = tobRegistro.Odn_fecfin_odde;
            tmpRegAux.Odn_finpro_odde = tobRegistro.Odn_finpro_odde;
            tmpRegAux.Odn_prexis_odde = tobRegistro.Odn_prexis_odde;
            tmpRegAux.Odn_estact_odac = tobRegistro.Odn_estact_odac;
            tmpRegAux.Odn_codimg_odim = tobRegistro.Odn_codimg_odim;
            tmpRegAux.Odn_imagen_odde = tobRegistro.Odn_imagen_odde;
            tmpRegAux.Sis_estpro_espr = tobRegistro.Sis_estpro_espr;
            tmpRegAux.Odn_aplvis_odde = tobRegistro.Odn_aplvis_odde;
            tmpRegAux.Odn_aplist_odde = tobRegistro.Odn_aplist_odde;
            tmpRegAux.Odn_desdie_oddi = tobRegistro.Odn_desdie_oddi;
            tmpRegAux.Odn_desana_odan = tobRegistro.Odn_desana_odan;
            tmpRegAux.Odn_desdia_oddx = tobRegistro.Odn_desdia_oddx;
            tmpRegAux.Fcm_desser_mant = tobRegistro.Fcm_desser_mant;
            tmpRegAux.Sis_despro_espr = tobRegistro.Sis_despro_espr;
            tmpRegAux.Odn_serdnt_odsi = tobRegistro.Odn_serdnt_odsi;
            tmpRegAux.Odn_tipvis_odsi = tobRegistro.Odn_tipvis_odsi;
            tmpRegAux.Sis_estado_imaen = tobRegistro.Sis_estado_imaen;
            #endregion

            return tmpRegAux;
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
            llgModoEdicionKey = true;
            var lobTextBox = sender as TextBox;
            fcrValidacion(lobTextBox.Name);
            llgModoEdicionKey = false;
            llgModoEdicionValid = false;
        }
        #endregion
        #region flgValidacion: Valida todos los datos antes de guardar
        /// <summary>
        /// Valida todos los datos del registro maestro antes de guardar
        /// </summary>
        public bool flgValidacion()
        {
            var lnuCont = 0;
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Odn_fecact_odac"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_tiptur_hctu"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codpfa_prof"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Cto_seccon_cont"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codeps_teps"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codare_aser"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Fcm_codcpr_cpro"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Odn_observ_odac"))) { lnuCont++; }

            this.cmdGuardar.IsEnabled = lnuCont > 0 || llgModoEdicion==false ? false : true;
            this.cmdConfirmar.IsEnabled = lnuCont > 0 || llgModoEdicion == false ? false : true;
            return lnuCont == 0 ? true : false;
        }
        #endregion
        #region flgValidacionRegDetalles: Validar registros detalles relacion antes de agregar a lista
        /// <summary>
        /// Validar registros detalles relacion antes de agregar a lista
        /// </summary>
        public bool flgValidacionRegDetalles()
        {
            var lnuCont = 0;
            switch (gcrTipoRegistro)
            {
                case "1": // Diagnostico
                    if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Odn_coddia_oddx"))) { lnuCont++; }
                    break;

                case "2": // Plan de tratamiento
                    if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG2Fcm_coddig_mant"))) { lnuCont++; }
                    if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG2Odn_totuni_odde"))) { lnuCont++; }
                    break;

                case "3": // Actividades evoluicion
                    if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG3Fcm_coddig_mant"))) { lnuCont++; }
                    if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG3Odn_fecini_odde"))) { lnuCont++; }
                    if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG3Odn_fecfin_odde"))) { lnuCont++; }
                    if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG3Odn_totuni_odde"))) { lnuCont++; }
                    break;
            }
            this.cmdAddRegistros.IsEnabled = lnuCont > 0 ? false : true;
            return lnuCont == 0 ? true : false;
        }
        #endregion
        #region fcrValidacion: Validacion Campos general
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        /// </summary>
        public String fcrValidacion(String tcrNombrePropiedad)
        {

            String lcrValorReturn       = string.Empty;
            String lcrNumeroRegistro    = "USUARIO";
            String lcrCodigoError       = String.Empty;
            String lcrNombreCampo       = String.Empty;
            String lcrNivelError        = "ALTO";
            String lcrImgNivelError     = "Edt_hist_vista_anulado.png";
            bool llgValidDefault        = false;

            try
            {

                switch (tcrNombrePropiedad)
                {
                    case "txtG1Odn_fecact_odac":
                        #region Validacion
                        lcrNombreCampo = "Fecha actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtG1Odn_fecact_odac.Text, "Fecha actividad");
                        fcvSetColorValidacion(this.txtG1Odn_fecact_odac, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_tiptur_hctu":
                        #region Validacion
                        lcrNombreCampo = "Turno de atencion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";

                        if (string.IsNullOrWhiteSpace(this.txtG1Hcl_tiptur_hctu.Text))
                        {
                            lcrValorReturn = lcrNombreCampo +": Es requerido";
                        }
                        else
                        {
                            EFhcltiporegturno tmp = new EFhcltiporegturno();
                            tmp = HCLValidarCodigo.fobRegBuscarHcltiporegturno(this.txtG1Hcl_tiptur_hctu.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hcl_tiptur_hctu))
                            {
                                this.txtG1Hcl_destur_hctu.Text = tmp.hcl_destur_hctu;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Hcl_tiptur_hctu, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Sia_codpfa_prof":
                        #region Validacion
                        lcrNombreCampo = "Codigo profesional del servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";

                        if (string.IsNullOrWhiteSpace(this.txtG1Sia_codpfa_prof.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(this.txtG1Sia_codpfa_prof.Text);
                            if (tmp != null && tmp.sia_nompro_prof != null)
                            {
                                this.txtG1Sia_nompro_prof.Text = tmp.sia_nompro_prof;
                                tmpRegMaestro.Sia_codpfa_prof = tmp.sia_codpfa_prof;
                                tmpRegMaestro.Sia_nompro_prof = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codpfa_prof, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Cto_seccon_cont":
                        #region Validacion
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (string.IsNullOrWhiteSpace(this.txtG1Cto_seccon_cont.Text))
                    	{
                    	   	lcrValorReturn = "Secuencial de Contrato: Es requerido";
                    	}
                    	else
                    	{
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontratoEx(this.txtG1Cto_seccon_cont.Text);
                            if (tmp!=null)
                            {
                                tmpRegMaestro.Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                tmpRegMaestro.Sia_codeps_teps = String.IsNullOrWhiteSpace(tmpRegMaestro.Sia_codeps_teps) ? 
                                                                                          tmp.sia_codeps_teps : tmpRegMaestro.Sia_codeps_teps;
                                tmpRegMaestro.Cto_descon_cont = tmp.cto_descon_cont;
                                tmpRegMaestro.Fcm_codman_mans = tmp.fcm_codman_mans;
                                this.txtG1Cto_nrocon_cont.Text = tmp.cto_nrocon_cont;
                                this.txtG1Cto_descon_cont.Text = tmp.cto_descon_cont;
                                this.txtG1Sia_codeps_teps.Text = tmpRegMaestro.Sia_codeps_teps; // debe llamar validacion
                                // Datos Contrato y Tarifario  para liquidacion
                                gobLiq.fcvCargarValoresContrato(tmp);
                                gobLiq.m.flgCargarParametrosContrato(tmp);
                            }
                            else
                            {
                            	lcrValorReturn = "Secuencial de Contrato: No existe";
                            }
                    	}
                        fcvSetColorValidacion(this.txtG1Cto_seccon_cont, lcrValorReturn);
                    	break;
                        #endregion

                    case "txtG1Sia_codeps_teps":
                        #region Validacion
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (string.IsNullOrWhiteSpace(this.txtG1Sia_codeps_teps.Text))
                        {
                            lcrValorReturn = "Código EPS: Es requerido";
                        }
                        else
                        {
                            EFsiatablaeps tmp = new EFsiatablaeps();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(this.txtG1Sia_codeps_teps.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codeps_teps))
                            {
                                this.txtG1Sia_deseps_teps.Text = tmp.sia_deseps_teps;
                                tmpRegMaestro.Sia_codeps_teps = tmp.sia_codeps_teps;
                            }
                            else
                            {
                                lcrValorReturn = "Código EPS: No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codeps_teps, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Sia_codare_aser":
                        #region Validacion
                        lcrNombreCampo = "Area de servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (string.IsNullOrWhiteSpace(this.txtG1Sia_codare_aser.Text))
                        {
                            lcrValorReturn = "Código área servicio: Es requerido";
                        }
                        else
                        {
                            EFsiaareapreservi tmp = new EFsiaareapreservi();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(this.txtG1Sia_codare_aser.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codare_aser))
                            {
                                this.txtG1Sia_desare_aser.Text = tmp.sia_desare_aser;
                                tmpRegMaestro.Sia_codare_aser = tmp.sia_codare_aser;
                                tmpRegMaestro.Sia_desare_aser = tmp.sia_desare_aser;
                            }
                            else
                            {
                                lcrValorReturn = "Código área servicio: No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codare_aser, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Fcm_codcpr_cpro":
                        #region Validacion
                        lcrNombreCampo = "Código centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
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
                                this.txtG1Sia_codare_aser.Text = !String.IsNullOrWhiteSpace(tmp.sia_codare_aser) ? tmp.sia_codare_aser : this.txtG1Sia_codare_aser.Text;
                                this.txtG1Fcm_descpr_cpro.Text = tmp.fcm_descpr_cpro;
                                tmpRegMaestro.Sia_codare_aser = this.txtG1Sia_codare_aser.Text;
                                tmpRegMaestro.Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro;

                            }
                            else
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        fcvSetColorValidacion(txtG1Fcm_codcpr_cpro, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Odn_observ_odac":
                        #region Validacion
                        lcrNombreCampo = "Observación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";

                        if (String.IsNullOrWhiteSpace(this.txtG1Odn_observ_odac.Text))
                        {
                            lcrValorReturn = "Observación: Es requerida";
                        }
                        fcvSetColorValidacion(this.txtG1Odn_observ_odac, lcrValorReturn);
                        break;
                        #endregion

                    default:
                        lcrValorReturn = fcrValidacionRel(tcrNombrePropiedad);
                        llgValidDefault = true;
                        break;
                }
                if (llgValidDefault == false)
                {
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
                this.cmdLogErrores.IsEnabled = tmpLogErrores.Count > 0 ? true : false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidacionRel: Validacion registros tipo detalles
        /// <summary>
        /// Funcion para validar datos editados para cargar en lista detalles 
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        /// </summary>
        public String fcrValidacionRel(String tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            try
            {

                switch (tcrNombrePropiedad)
                {
                    case "txtG1Odn_coddia_oddx":
                        #region Validacion
                        lcrNombreCampo = "Codigo diagnostico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B01";
                        if (string.IsNullOrWhiteSpace(this.txtG1Odn_coddia_oddx.Text))
                        {
                            lcrValorReturn = "Codigo diagnostico: Es requerido";
                        }
                        else
                        {
                            EFodndiagnosticos tmp = new EFodndiagnosticos();
                            tmp = ODNValidarCodigo.fobRegBuscarOdndiagnosticos(this.txtG1Odn_coddia_oddx.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.odn_coddia_oddx))
                            {
                                this.txtG1Odn_desdia_oddx.Text = tmp.odn_desdia_oddx;

                                tmpRegActiDetalle.Odn_coddia_oddx = tmp.odn_coddia_oddx;
                                tmpRegActiDetalle.Odn_desdia_oddx = tmp.odn_desdia_oddx;
                                tmpRegActiDetalle.Sia_coddia_tdia = tmp.sia_coddia_tdia;
                                tmpRegActiDetalle.Odn_tipvis_odsi = tmp.odn_tipvis_oddx;
                                tmpRegActiDetalle.Odn_codimg_odim = tmp.odn_codimg_odim;
                                tmpRegActiDetalle.Fcm_desser_mant = tmp.odn_desdia_oddx;
                                tmpRegActiDetalle.Odn_codana_odan = "7"; // se asume diente
                                tmpRegActiDetalle.Odn_desana_odan = "Diente"; 
                                // Cuando no es ningun diente (es dx y servicios generales no graficables)
                                if (gcrIdItemServicioGrafica == "NA")
                                {
                                    tmpRegActiDetalle.Odn_codana_odan = "8";
                                    tmpRegActiDetalle.Odn_desana_odan = "NA";
                                }
                                // Cuando es requerido seleccionar caras vista corona
                                if (tmpRegActiDetalle.Odn_tipvis_odsi =="1" && !flgValidSelectCaraCorona() && gcrIdItemServicioGrafica !="NA")
                                {
                                    lcrValorReturn = lcrNombreCampo + ": debe seleccionar al menos una cara de la corona dental";
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Codigo diagnostico: No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Odn_coddia_oddx, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG2Fcm_coddig_mant":
                        #region Validacion
                        lcrNombreCampo = "Código servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B02";
                        if (String.IsNullOrWhiteSpace(this.txtG2Fcm_coddig_mant.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else if (String.IsNullOrWhiteSpace(tmpRegMaestro.Fcm_codman_mans))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Primero debe seleccionar un numero de contrato.";
                            this.txtG2Fcm_desser_mant.Text = lcrValorReturn;
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarIuFcmmanservicios(this.txtG2Fcm_coddig_mant.Text, tmpRegMaestro.Fcm_codman_mans);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_coddig_mant))
                            {
                                var tmpIps = ODNValidarCodigo.fobRegBuscarOdnserviciosipsEx(tmp.fcm_idesec_sips);
                                if (tmpIps == null || String.IsNullOrWhiteSpace(tmpIps.odn_codser_odsi))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No registrado como servicio odontologico";
                                    this.txtG2Fcm_desser_mant.Text = lcrValorReturn;
                                }
                                else
                                {
                                    this.txtG2Fcm_desser_mant.Text = tmp.fcm_desser_mant;
                                    //- Actualizar temporal
                                    tmpRegActiDetalle.Fcm_idesec_mant = tmp.fcm_idesec_mant;
                                    tmpRegActiDetalle.Fcm_idesec_sips = tmp.fcm_idesec_sips;
                                    tmpRegActiDetalle.Fcm_codser_mant = tmp.fcm_codser_mant;
                                    tmpRegActiDetalle.Fcm_desser_mant = tmp.fcm_desser_mant;
                                    tmpRegActiDetalle.Odn_codser_odsi = tmpIps.odn_codser_odsi;
                                    tmpRegActiDetalle.Odn_tipvis_odsi = tmpIps.odn_tipvis_odsi;
                                    tmpRegActiDetalle.Odn_codimg_odim = tmpIps.odn_codimg_odim;
                                    tmpRegActiDetalle.Odn_codana_odan = "7"; // se asume diente
                                    tmpRegActiDetalle.Odn_desana_odan = "Diente"; 

                                    // Cuando no es ningun diente (es dx y servicios generales no graficables)
                                    if (gcrIdItemServicioGrafica == "NA")
                                    {
                                        tmpRegActiDetalle.Odn_codana_odan = "8";
                                        tmpRegActiDetalle.Odn_desana_odan = "NA";
                                    }
                                    // Cuando es requerido seleccionar caras vista corona
                                    if (tmpRegActiDetalle.Odn_tipvis_odsi == "1" && !flgValidSelectCaraCorona() && gcrIdItemServicioGrafica != "NA")
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": debe seleccionar al menos una cara de la corona dental";
                                    }
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                                this.txtG2Fcm_desser_mant.Text = lcrValorReturn;
                            }
                        }
                        fcvSetColorValidacion(txtG2Fcm_coddig_mant, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG2Odn_totuni_odde":
                        #region Validacion
                        lcrNombreCampo = "Total unidades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B03";
                        if (String.IsNullOrWhiteSpace(this.txtG2Odn_totuni_odde.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(this.txtG2Odn_totuni_odde.Text, "0123456789"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres que no son numeros";
                            }
                            else
                            {
                                if (Convert.ToUInt32(this.txtG2Odn_totuni_odde.Text) < 1 || Convert.ToUInt32(this.txtG2Odn_totuni_odde.Text) > 150)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtG2Odn_totuni_odde, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG3Fcm_coddig_mant":
                        #region Validacion
                        lcrNombreCampo = "Código servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";

                        gobLiq.G2Hcl_codreg_hcca = String.Empty;
                        gobLiq.G2Fcm_fecser_dfac = this.txtG1Odn_fecact_odac.Text;
                        gobLiq.G2Fcm_fecfac_mfac = this.txtG1Odn_fecact_odac.Text;
                        //gobLiq.G2Cit_feccit_mcit = this.txtG1Odn_fecact_odac.Text;
                        gobLiq.G2Sis_estado_imaen = "A";

                        if (String.IsNullOrWhiteSpace(this.txtG3Fcm_coddig_mant.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            fcvCargarDatosParaLiquidarServ();
                            this.txtG3Fcm_coddig_mant.Text  = this.txtG3Fcm_coddig_mant.Text.ToUpper().Trim();
                            gobLiq.G2Fcm_coddig_mant        = this.txtG3Fcm_coddig_mant.Text;
                            flgAsignarTotalUnidadesParaValidacion();

                            lcrValorReturn = gobLiq.fcrValidacionCampos("Fcm_coddig_mant", ref tmpLogErrores, lcrNumeroRegistro);
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                var tmpIps = ODNValidarCodigo.fobRegBuscarOdnserviciosipsExN(gobLiq.G2Fcm_idesec_sips);
                                if (tmpIps == null)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No registrado como servicio odontologico";
                                }
                                else
                                {
                                    if (!flgValidacionPertinencia())
                                    {
                                        lcrValorReturn = lcrNombreCampo + " : Error en validación pertinencia";
                                    }
                                    else
                                    {
                                        this.txtG3Fcm_desser_mant.Text = gobLiq.G2Fcm_desser_dfac;
                                        //- Actualizar temporal
                                        tmpRegActiDetalle.Fcm_idesec_mant = gobLiq.G2Fcm_idesec_mant;
                                        tmpRegActiDetalle.Fcm_idesec_sips = gobLiq.G2Fcm_idesec_sips;
                                        tmpRegActiDetalle.Fcm_codser_mant = gobLiq.G2Fcm_codser_mant;
                                        tmpRegActiDetalle.Fcm_desser_mant = gobLiq.G2Fcm_desser_dfac;
                                        tmpRegActiDetalle.Odn_codser_odsi = tmpIps.odn_codser_odsi;
                                        tmpRegActiDetalle.Odn_tipvis_odsi = tmpIps.odn_tipvis_odsi;
                                        tmpRegActiDetalle.Odn_codimg_odim = tmpIps.odn_codimg_odim;
                                        tmpRegActiDetalle.Odn_codana_odan = "7"; // se asume diente
                                        tmpRegActiDetalle.Odn_desana_odan = "Diente";
                                        // Cuando no es ningun diente (es dx y servicios generales no graficables)
                                        if (gcrIdItemServicioGrafica == "NA")
                                        {
                                            tmpRegActiDetalle.Odn_codana_odan = "8";
                                            tmpRegActiDetalle.Odn_desana_odan = "NA";
                                        }
                                        // Cuando es requerido seleccionar caras vista corona
                                        if (tmpRegActiDetalle.Odn_tipvis_odsi == "1" && !flgValidSelectCaraCorona() && gcrIdItemServicioGrafica != "NA")
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": debe seleccionar al menos una cara de la corona dental";
                                        }
                                    }
                                }
                            }
                        }
                        fcvSetColorValidacionDes(lcrValorReturn);
                        fcvSetColorValidacion(txtG3Fcm_coddig_mant, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG3Odn_fecini_odde":
                        #region Validacion
                        lcrNombreCampo = "Fecha inicia actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtG3Odn_fecini_odde.Text, lcrNombreCampo);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            // Validar Rango 
                            if (!Funciones.flgValidarRangoFecha(tmpRegAdm.Adm_fecadm_rgad.ToShortDateString(), this.txtG3Odn_fecini_odde.Text))
                            {
                                lcrValorReturn =  lcrNombreCampo + ": no es valida con respecto a fecha registro de amision";
                            }
                            else
                            {
                                if (!Funciones.flgValidarRangoFecha(this.txtG3Odn_fecini_odde.Text, this.txtG3Odn_fecfin_odde.Text))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": rango fecha inicio actividad y fecha fin actividad errado";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "txtG3Odn_fecfin_odde":
                        #region Validacion
                        lcrNombreCampo = "Fecha fin actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtG3Odn_fecfin_odde.Text, lcrNombreCampo);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            // Validar Rango 
                            if (!Funciones.flgValidarRangoFecha(tmpRegAdm.Adm_fecadm_rgad.ToShortDateString(), this.txtG3Odn_fecfin_odde.Text))
                            {
                                lcrValorReturn = lcrNombreCampo + ": no es valida con respecto a fecha registro de amision";
                            }
                            else
                            {
                                if (!Funciones.flgValidarRangoFecha(this.txtG3Odn_fecini_odde.Text, this.txtG3Odn_fecfin_odde.Text))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": rango fecha inicio actividad y fecha fin actividad errado";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "txtG3Odn_totuni_odde":
                        #region Validacion
                        lcrNombreCampo = "Total unidades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        if (String.IsNullOrWhiteSpace(this.txtG3Odn_totuni_odde.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(this.txtG3Odn_totuni_odde.Text, "0123456789"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres que no son numeros";
                            }
                            else
                            {
                                if (Convert.ToInt32(this.txtG3Odn_totuni_odde.Text) < 1 || Convert.ToInt32(this.txtG3Odn_totuni_odde.Text) > 150)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                                }
                                else
                                {
                                    gobLiq.G2Fcm_totuni_dfac = Convert.ToInt32(this.txtG3Odn_totuni_odde.Text);
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtG3Odn_totuni_odde, lcrValorReturn);
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
        #endregion
        #region fcvSetColorValidacion: Color de objetos al validar
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
        #endregion
        #region fcvSetColorValidacionDes: Color de texto descripcion servicio al validar
        private void fcvSetColorValidacionDes(String tcrValorReturn)
        {
            if (!String.IsNullOrWhiteSpace(tcrValorReturn))
            {
                 this.txtG3Fcm_desser_mant.Foreground = Brushes.Red;
                 this.txtG3Fcm_desser_mant.Text = tcrValorReturn;
            }
            else
            {
                this.txtG3Fcm_desser_mant.Foreground =  Brushes.Black;
            }
        }
        #endregion
        #region fcvSelectCheckBox: Marcar o desmarcar item en corona CheckBox
        /// <summary>
        /// <para>Marcar o desmarcar item en corona CheckBox</para>
        /// </summary>
        private void fcvSelectCheckBox(object sender, RoutedEventArgs e)
        {
            llgModoEdicionKey = false;
            llgModoEdicionValid = false;
        }
        #endregion
        #region flgValidSelectCaraCorona: Verificar que alguana cara de la corona esta seleccionada
        /// <summary>
        /// <para>Verificar que alguna cara de la corona esta seleccionada</para>
        /// </summary>
        private bool flgValidSelectCaraCorona()
        {
            var lnuCont = 0;

            lnuCont = this.chkCara1.IsChecked == true ? lnuCont + 1 : lnuCont;
            lnuCont = this.chkCara2.IsChecked == true ? lnuCont + 1 : lnuCont;
            lnuCont = this.chkCara3.IsChecked == true ? lnuCont + 1 : lnuCont;
            lnuCont = this.chkCara4.IsChecked == true ? lnuCont + 1 : lnuCont;
            lnuCont = this.chkCara5.IsChecked == true ? lnuCont + 1 : lnuCont;

            return lnuCont == 0 ? false : true;
        }
        #endregion
        //-------------------------------------------------
        // Vista Capa Propiedades detalles 
        //-------------------------------------------------
        #region Ventana Propiedades y captura actividades
        #region fcvActivarVistaTipoVistaCaptura: Activar los datos para captura actividad en capa propiedades
        /// <summary>
        /// <para>Activar los datos para captura actividad en capa propiedades</para>
        /// <para>dependiendo del tipo registro (diagnostico plan tratamiento o actividad)</para>
        /// </summary>
        private void fcvActivarVistaTipoVistaCaptura()
        {
            this.grdCapDiagnostico.Visibility = gcrTipoRegistro == "1" ? Visibility.Visible : Visibility.Collapsed;
            this.grdCapPlanTratamiento.Visibility = gcrTipoRegistro == "2" ? Visibility.Visible : Visibility.Collapsed;
            this.grdCapActividad.Visibility = gcrTipoRegistro == "3" ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccion(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaSeleccion();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaSeleccion == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccionTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaSeleccion == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarVistaSeleccion()
        {
            //this.objHistCortina.Visibility = Visibility.Visible;
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaSeleccion == false)
            {
                luxAnimacion.To = -410; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaSeleccion = true;
            }
            else
            {
                luxAnimacion.To = 22; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaSeleccion = false;
            }
            this.grdPropSelect.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
        #region fcvActivarDatosPropDetalles: Filtrar Vista Propiedades detalles servicios para un diente en particular
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana detalles servicios</para>
        /// </summary>
        private void fcvActivarDatosPropDetalles(String tcrNumeroDiente)
        {
            var llgRegRelacion = true;
            var lcrImagen = "Edt_edt_xcap_documento.png";
            var lcrUri = "/GestorReportes;component/Imagenes/";

            this.stkDetalles.Children.Clear();
            var tmpDetalles = fobSQLSelectTempRegistros("2", tcrNumeroDiente);
            this.chkG2Odn_prexis_odde.IsEnabled = true;
            this.chkG2Odn_prexis_odde.IsChecked = false;
            this.cboRelDiagnostico.IsEnabled = true;

            if (tcrNumeroDiente != "NA")
            {
                this.imgDiente.Visibility = Visibility.Visible;
                this.imgGeneral.Visibility = Visibility.Collapsed;
                this.cnvCorona.Visibility = Visibility.Visible;
                this.txtNumeroDiente.Text = tcrNumeroDiente;
                this.txtPropDetallesTitulo.Text = fcrNombreTipoRegHistorialClinico(gcrTipoRegistro) + " - Diente " + tcrNumeroDiente;
                this.txtTituloDetalles.Text = "Detalles - Diente " + tcrNumeroDiente;
                var tmpDiente = ODNValidarCodigo.fobRegBuscarOdnmaestdientes(tcrNumeroDiente);
                lcrImagen = tmpDiente.odn_imagen_oddi;
                this.imgDiente.Source = new BitmapImage(new Uri(lcrUri + lcrImagen, UriKind.RelativeOrAbsolute));
                fcvActualVistaCarasCoronaDiente(tcrNumeroDiente);
                fcvIniciarVariablesVista("2");
            }
            else 
            {
                this.txtNumeroDiente.Text = String.Empty;
                this.imgDiente.Visibility = Visibility.Collapsed;
                this.imgGeneral.Visibility = Visibility.Visible;
                this.cnvCorona.Visibility = Visibility.Collapsed;
                this.txtPropDetallesTitulo.Text = fcrNombreTipoRegHistorialClinico(gcrTipoRegistro) + " - General";
                this.txtTituloDetalles.Text = "Detalles General";
                fcvActualizarTempCarasCorona("1");
            }
            foreach (var lobReg in tmpDetalles)
            {
                fcvAddRegistroDetalleGrafico(lobReg);
            }

            // Cargar Diagnosticos o servicios relacionados 
            if (gcrTipoRegistro == "2" || gcrTipoRegistro == "3") // Plan de tratamiento
            {
                llgRegRelacion = flgCargarComboBoxRelacion(tcrNumeroDiente);
            }
            // Mostrar u Ocultar Vista captura detalles
            this.expCapturaDatos.Visibility = llgRegRelacion == true ? Visibility.Visible : Visibility.Collapsed;

            // para Plan de tratamientos en dientes sin diagnosticos solo permitir proc pre existentes
            if (gcrTipoRegistro == "2" && llgRegRelacion == false ) // Plan de tratamiento
            {
                this.expCapturaDatos.Visibility     = Visibility.Visible;
                this.cboRelDiagnostico.IsEnabled = false;
                this.chkG2Odn_prexis_odde.IsChecked = true;
                this.chkG2Odn_prexis_odde.IsEnabled = false;
            }
        }
        #endregion
        #endregion
        // Cargar Listas Combobox Relacion
        #region flgCargarComboBoxRelacion: Carga lista de Diagnosticos o Plan de Tratamiento en combos relacionados
        /// <summary>
        /// <para>Carga lista de Diagnosticos o Plan de Tratamiento en combos relacionados.</para>
        /// <para>tcrNumeroDiente: Numero del diente para el cual se cargaran los diagnosticos o Plan de Tratamiento relacionados</para>
        /// </summary>
        private bool flgCargarComboBoxRelacion(String tcrNumeroDiente)
        {
            var llgReturn = false;
            try
            {
                this.cboG3RelPlanTratamiento.ItemsSource =null;
                this.cboRelDiagnostico.ItemsSource = null;
                lstRefDiagnosticos = null;
                lstRefPlanTratamiento = null;

                if (gcrTipoRegistro == "2") // Plan de tratamiento
                {
                    lstRefDiagnosticos = flsCargarComboBoxRelacionAux("1", tcrNumeroDiente);
                    llgReturn = (lstRefDiagnosticos != null) ? true : false;

                    if (llgReturn == true)
                    {
                        this.cboRelDiagnostico.ItemsSource = lstRefDiagnosticos;
                        this.cboRelDiagnostico.SelectedIndex = 0;
                        this.txtRelDiagnostico.Text = lstRefDiagnosticos.FirstOrDefault().ValorSeleccion;
                    }
                }
                else if (gcrTipoRegistro == "3") // Actividad o evolucion tratamiento
                {
                    lstRefPlanTratamiento = flsCargarComboBoxRelacionAux("2", tcrNumeroDiente);
                    llgReturn = (lstRefPlanTratamiento != null) ? true : false;

                    if (llgReturn == true)
                    {
                        this.cboG3RelPlanTratamiento.ItemsSource = lstRefPlanTratamiento;
                        this.cboG3RelPlanTratamiento.SelectedIndex = 0;
                        this.txtG3RelPlanTratamiento.Text = lstRefPlanTratamiento.FirstOrDefault().ValorSeleccion;
                    }

                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: flgCargarComboBoxRelacion");
            }
            return llgReturn;
        }
        #endregion
        #region fcvCargarComboBoxRelacionAux: SQL Carga lista de Diagnosticos o Plan de Tratamiento relacionados desde Base de datos
        /// <summary>
        /// <para>SQL Carga lista de Diagnosticos o Plan de Tratamiento relacionados desde Base de datos.</para>
        /// <para>tcrTipoRegistro: "1" = Diagnostico inicial "2" = Plan de tratamiento.</para>
        /// <para>tcrNumeroDiente: Numero del diente para el cual se cargaran los diagnosticos o Plan de Tratamiento relacionados</para>
        /// </summary>
        private List<CrtForms.ListaComboBox> flsCargarComboBoxRelacionAux(String tcrTipoRegistro, String tcrNumeroDiente)
        {
            List<CrtForms.ListaComboBox> lobLista = null;
            var tmpRegistros = ModeloOdnDeActivTratamiento.flsListaOdneventosactdeEx(tcrTipoRegistro, gcrIdMaestroTratamiento, tcrNumeroDiente);
            if (tmpRegistros.Count != 0 && tmpRegistros != null)
            {
                String lcrIdIndice = String.Empty;
                String lcrValorSeleccion = String.Empty;
                String lcrNombreOpcion = String.Empty;
                String lcrCodigoServicio = String.Empty;
                String lcrListaValoresSel = String.Empty;

                lobLista = new List<CrtForms.ListaComboBox>();
                bool llgRealizar = false;
                int i = 0;

                foreach (var lobReg in tmpRegistros)
                {
                    llgRealizar = false;
                    // No cargar los tratamientos finalizados o los pre existentes 
                    //if (lobReg.Sis_estpro_espr == "2" && lobReg.Odn_prexis_odde == "2" && lobReg.Odn_estact_odac != "3")
                    if (lobReg.Sis_estpro_espr == "2" && lobReg.Odn_prexis_odde == "2") 
                    {
                        llgRealizar = tcrTipoRegistro == "2" && lobReg.Odn_estact_odac == "3" ? false : true;
                    }

                    // Cargar el registro
                    if (llgRealizar == true)
                    {
                        i++;
                        lcrIdIndice = i.ToString();
                        lcrValorSeleccion = lobReg.Odn_nroreg_odde;
                        lcrCodigoServicio = tcrTipoRegistro == "1" ? lobReg.Sia_coddia_tdia : lobReg.Fcm_codser_mant;
                        lcrNombreOpcion = lcrCodigoServicio + " - " + lobReg.Odn_desana_odan + " - " + lobReg.Odn_desreg_odde;
                        lcrListaValoresSel = !String.IsNullOrWhiteSpace(lobReg.Fcm_coddig_mant) ? lobReg.Fcm_coddig_mant : String.Empty;

                        lobLista.Add(new CrtForms.ListaComboBox { IdIndice = lcrIdIndice, ValorSeleccion = lcrValorSeleccion, 
                                                                  NombreOpcion = lcrNombreOpcion, ListaValoresSel = lcrListaValoresSel});
                    }
                }
                if (i == 0) { lobLista = null; }
            }
            else 
            {
                lobLista = null;
            }
            return lobLista;
        }
        #endregion
        //-------------------------------------------------
        // fcvclinicaGenerarActividad: Registro de actividad en Historial clinico
        //-------------------------------------------------
        #region fcvHclinicaGenerarActividad: Generar registro para atencion en historia clinica
        /// <summary>
        /// <para>Generar registro en historial clinico</para>
        /// </summary>
        public String fcvHclinicaGenerarActividad()
        {
            var lcrCodgioRegHist = String.Empty;
            try
            {
                //tmpRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision).FirstOrDefault();
                var lobRegEx = HCLValidarCodigo.fobRegBuscarHcltiporegserms("ODAP");
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(lobRegEx.hcl_codreg_hcca);

                //MessageBox.Show("Gen notific 1");
                if (!String.IsNullOrWhiteSpace(lobReg.grp_idepla_grpl))
                {
                    //MessageBox.Show("Gen notific 2");
                    // Generar registro de actividad en historia clinica
                    var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);
                    var lobHist = new HclModeloHistorialEventos();
                    var lcrEvento = "Odontologia - " + fcrNombreTipoRegHistorialClinico(gcrTipoRegistro);
                    var ldaFechaEvento = tmpRegMaestro.Odn_fecact_odac;
                    var ldaHoraEvento = tmpRegMaestro.Odn_sishor_odac;

                    #region Datos del registro
                    lobHist.Hcl_secreg_hcev = 1;
                    lobHist.Hcl_nrohis_hicl = tmpRegAdm.Hcl_nrohis_hicl;
                    lobHist.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    lobHist.Cit_codasi_mcit = tmpRegAdm.Cit_codasi_mcit;
                    lobHist.Fcm_codcpr_cpro = tmpRegMaestro.Fcm_codcpr_cpro;
                    lobHist.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    lobHist.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    lobHist.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    lobHist.Hcl_codaux_hcev = tmpRegMaestro.Odn_nroreg_odev;
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
        #region fcrGenerarLlaveMs: Generar llave de busquda para el objeto
        /// <summary>
        /// <para>Generar llave de busquda para el objeto</para>
        /// </summary>
        public String fcrGenerarLlaveMs(ModeloOdnMsActivTratamiento tobRegistro)
        {
            // llave registro maestro
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + "  " + "  " + tobRegistro.Odn_nroreg_odev;
            var lcrllave2 = tobRegistro.Odn_fecact_odac.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + "  " + tobRegistro.Sia_desare_aser;
            return (lcrllave1 + "  " + lcrllave2 + "  " + lcrllave3).Trim();
        }
        #endregion
        //-------------------------------------------------
        // fcvSYSGenerarNotificacion: Registro notificaciones
        //-------------------------------------------------
        #region fcvGenerarNotificacion: Generar registro notificacion del sistema
        /// <summary>
        /// <para>Generar registro notificacion del sistema</para>
        /// </summary>
        public void fcvSYSGenerarNotificacion()
        {
            try
            {
                var oApp = Aplicacion.Instancia();
                var lcrTipoMensPublico = "1";  // Publico por defecto
                var lcrTipoIdNotfificacion = "ODN-REG-ACTIV-TRATAM";
                var lcrIdModuloNotfific = String.Empty;
                var lcrIdUsuarioRecibe = String.Empty;
                var lcrIdPerfilRecibe = String.Empty;

                var lobReg = SYSValidarCodigo.fobRegBuscarSysadmstipomens(lcrTipoIdNotfificacion);
                var lcrIden = "ADMISIÓN: " + tmpRegMaestro.Adm_secadm_rgad.Trim() + " " +
                                             tmpRegMaestro.Sia_tipide_tide.Trim() + " " + tmpRegMaestro.Sia_nroide_usua.Trim();

                var tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatendEx(tmpRegMaestro.Sia_idesec_usua);
                var lcrDesc = tmp!= null ? tmp.sia_nomusu_usua.Trim() :"SIN NOMBRE DEL PACIENTE";

                var lobjRegistro = new SysModeloAdminMensajes();

                lobjRegistro.Sys_codsec_syam = String.Empty;    // lo genera la funcion de gestion
                lobjRegistro.Sys_llavis_syam = 0;               // lo genera la funcion de gestion
                lobjRegistro.Sys_parent_syam = String.Empty;
                lobjRegistro.Sys_desmsj_syam = lcrIden;
                lobjRegistro.Sys_notmsj_syam = lcrDesc;
                lobjRegistro.Sys_regeve_sytm = tmpRegMaestro.Adm_secadm_rgad + "*" + tmpRegMaestro.Odn_nroreg_odac;
                lobjRegistro.Sys_tipmsj_syam = lcrTipoMensPublico;
                lobjRegistro.Sys_coduse_usux = oApp.gcrUsuIdUsuario;
                lobjRegistro.Sys_codusu_usux = lcrIdUsuarioRecibe;
                lobjRegistro.Sys_codtip_sytm = lcrTipoIdNotfificacion;
                lobjRegistro.Sys_codmsg_symg = lcrIdModuloNotfific;     // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_codper_perf = lcrIdPerfilRecibe;       // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_sisfec_syam = tmpRegMaestro.Odn_sisfec_odac;
                lobjRegistro.Sys_sishor_syam = tmpRegMaestro.Odn_sishor_odac;
                lobjRegistro.Sys_vinfec_syam = Funciones.fdaConvertFecha("DMY", "/", Funciones.fcrFechaActual());
                lobjRegistro.Sys_vinhor_syam = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                lobjRegistro.Sys_vfnfec_syam = ((DateTime)tmpRegMaestro.Odn_sisfec_odac).AddDays((Double)lobReg.sys_tievig_sytm);
                lobjRegistro.Sys_vfnhor_syam = lobjRegistro.Sys_vinhor_syam;
                lobjRegistro.Sys_vfrfec_syam = Convert.ToDateTime("01/01/1000");
                lobjRegistro.Sys_vfrhor_syam = 0;
                lobjRegistro.Sys_msjvis_syam = "1";

                SysNotificaciones.flgGenerarNotificaciones(lobjRegistro);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Confirmar servicios Error Metodo: fcvSYSGenerarNotificacion");
            }
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
        //-------------------------------------------------
        // Asignar total unidades desde vista
        //-------------------------------------------------
        #region flgAsignarTotalUnidadesParaValidacion: Asignar total unidades desde vista 
        /// <summary>
        /// Asignar total unidades desde vista captura de datos
        /// </summary>
        public bool flgAsignarTotalUnidadesParaValidacion()
        {
            var llgReturn = false;
            this.txtG3Odn_totuni_odde.Text = String.IsNullOrWhiteSpace(this.txtG3Odn_totuni_odde.Text) ? "0" : this.txtG3Odn_totuni_odde.Text;

            if (Funciones.flgExisteSubCadenaStringEx(this.txtG3Odn_totuni_odde.Text, "0123456789"))
            {
                gobLiq.G2Fcm_totuni_dfac = Convert.ToInt32(this.txtG3Odn_totuni_odde.Text);
                llgReturn = true;
            }
            else
            {
                gobLiq.G2Fcm_totuni_dfac = 0;
            }
            return llgReturn;
        }
        #endregion

    }
}
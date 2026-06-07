using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Converters;
using System.Windows.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Windows.Xps.Packaging;
using System.Xml;
using System.Windows.Markup;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.CodeDom;
using System.CodeDom.Compiler;
using Sistema.Utilidades;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Validacion;
using Datos.Modelos;
using GestorReportes.VistaModelo;
using GestorReportes.Modelo;
using GestorReportes.Utilidades;
using Reportes.Utilidades;
using ConfigAsistencial.Vista;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_CapturaReportes.xaml
    /// </summary>
    public partial class VistaCapturaReportes : Window, INotificacion
    {
        #region Configuracion entorno
        AdornerLayer luxUIAgregarAdorno;
        // variables control zoom vista
        private Double gduBaseZoomVertical = 0;
        private Double gduBaseZoomHorizontal = 0;
        private Double gduBaseZoomSlider = 0;
        // Variables varias
        public String gcrUriImagenesSistema = "/Sistema;component/Imagenes/";
        public String gcrTipoImagenIconoError = "NA"; // "NA" = imagen normal "1" = Sin error "2" = Con error de campos obligatirios "3" = Errores de chr
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");

        private String gcrAnimRegionVista = String.Empty;        //Para controlar la Region a animar ETIQUETA/ESCRITORIO/HISTORIAL
        #region Variables Gestos y animacion al mover Paneles Vertical
        private DispatcherTimer gdspAnimTimerVY;
        private DispatcherTimer gdspAnimTimerClickVY;
        private DoubleAnimationUsingKeyFrames gdubAnimarObjetoVY;
        private double gduAnimInicioPuntoMouseVY;
        private double gduAnimFinalPuntoMouseVY;
        private double gduAnimOldPosStkPanelVY;
        private double gduAnimNewPosStkPanelVY;
        public int lnuAniContTouchDownVY = 0;
        private Canvas gobAnimRefMainCanvasVY = null;           // referencia al panel Canvas Base
        private StackPanel gobAnimRefMetroStkPanelVY = null;    // referencia al panel scroll de la region
        private int gnuAnimContTouchDownVY = 0;
        private int gnuAnimContTouchMilisegVY = 0;
        #endregion
        // Animacion Horizontal Etiquetas y Escritorio
        #region Variables Gestos y animacion al mover Paneles Horizontal
        private DispatcherTimer gdspAnimTimerHX;
        private DispatcherTimer gdspAnimTimerClickHX;
        private DoubleAnimationUsingKeyFrames gdubAnimarObjetoHX;
        private double gduAnimInicioPuntoMouseHX;
        private double gduAnimFinalPuntoMouseHX;
        private double gduAnimOldPosStkPanelHX;
        private double gduAnimNewPosStkPanelHX;
        public int lnuAniContTouchDownHX = 0;
        private Canvas gobAnimRefMainCanvasHX = null;  // referencia al panel Canvas Base
        private StackPanel gobAnimRefMetroStkPanelHX = null;  // referencia al panel scroll de la region
        private int gnuAnimContTouchDownHX = 0;
        private int gnuAnimContTouchMilisegHX = 0;
        #endregion
        // Variables para control de Objetos
        #region Variables para control de Objetos
        bool glgModoArrastrarObjeto = false;
        bool glgAccionArrastrandoObjeto;
        bool glgSiObjetoSeleccionado = false;
        bool glgObjetosCargados = false;
        bool glgModoSetPropiedades = false;
        TileImgPredefinidas gobRefTileImgPredefinida = null;
        Double gduTamañoAdornos = 35;
        //- Mostrar Ventana Menu Superior
        bool glgVistaMenuSuperiorVisible = false;
        //- Mostrar Ventana Historial
        bool glgVistaHistorialVisible = false;
        //bool glgVistaHistorialAnclada = false;
        //- Mostrar Ventana propiedades
        bool glgVistaPropVisible = false;
        bool glgVistaPropAnclada = false;
        //- Mostrar barra de estado y Etiqueta
        bool glgVistaBarraEstadoVisible = false;
        bool glgVistaEtiquetaEstadoVisible = false;
        //- Orientacion Vista Navegacion y paginas
        bool glgVistaNavEscritorioVertical = true;
        #endregion
        //Variables referencia Tree Objetos
        #region Variables referencia Tree Objetos
        public UIElement guiRefObjetoSeleccionado = null;
        public GroupBox gobRefGrupoSeleccionado = null;
        public Canvas gobRefContenedorGrupoSeleccionado = null;
        public GroupBox gobRefZonaSeleccionada = null;
        public Canvas gobRefContenedorZonaSeleccionada = null;
        public Canvas gobRefPaginaSeleccionada = null;
        public WrapPanel gobRefContenedorPaginaSeleccionada = null;
        public Canvas gobPaginaSelectParaAddZona = null;
        public GroupBox gobZonaSelectParaAddObjeto = null;
        public int gnuContadorAddZonas = 1;
        public String gcrTipoObjetoNivel = "NA";
        public String gcrObjetoClassBase = "NA";
        #endregion
        // Variables referencia Posicion Mouse y otras
        #region Variables referencia Posicion Mouse y otras
        Point gptPuntoDeInicio;
        private double gduObjetoInicialLeft;
        private double gduObjetoInicialTop;
        // Posicion del canvas donde se hace 
        // clic para colocar el nuevo objeto
        public double gduCanvasClicPosX = 1;
        public double gduCanvasClicPosY = 1;
        public String gcrAddNuevoObjetoTipo = String.Empty; //TEXTBOX,LISTBOX,TEXTBLOCK,RADIOBUTTON ...
        public bool glgNuevoObjetoCrear = false; // Para indicar el momento de  instanciar el nuevo objeto
        #endregion
        // Variables control de Registro de atencion medica
        #region Variables parametros del modulo
        private String gcrParamTipoId        = String.Empty;
        private String gcrParamTipoIdBak     = String.Empty;
        private String gcrParamIdRegistro    = String.Empty;
        private String gcrParamIdRegistroBak = String.Empty;
        private String gcrParamIdAdmision    = String.Empty;
        private String gcrParamIdUnicoSistem = String.Empty;
        private String gcrParamIdAdmisionCarg= String.Empty;
        private bool glgRefreshVistaPlntilla = false;
        #endregion
        // Variables varias  y control F2 Browser
        //public bool flgActivateVista = true; // para saber si se minimiza en barra de tarea de windows
        #region Gestion minimizar en barra de tareas windows
        public String gcrCtrF2TexBox = String.Empty;
        public TextBox gcrCtrF2TexBoxObj = null;
        public ControlCaptura gobCtrControlCaptura = null;
        public List<ModeloHclformatvistma> tmpMenuActMedGru = null;
        public List<ModeloHcltiporegactiv> tmpMenuActMedCmd = null;
        #endregion

        ControlNotificaciones gobCrtNotifi = null;

        //- Variables para compilacion codigo  plantillas
        public static CompilerResults gobEnsamblado = null;
        public static Type gobRefoAppType = null;
        public static IEjecutarCodigoFuente oAppICodigofuente = null;
        public int lnuContaEjecutar = 0;
        public bool llgEjecutandoCodigoFKey = false;

        //- Refeencia a objetos para Test y IMC
        #region Test Framinham y IMC
        ControlVistaFramingHam gobCrtFrmg = null; // Test Framingham
        ControlVistaImc gobCrtIMC         = null; // IMC -Indice masa corporal
        ClassXmlPropObjeto gobCrtFrmgReg = null; // Registro Objeto Test Framingham
        ClassXmlPropObjeto gobCrtIMCReg  = null; // Registro Objeto IMC-Indice masa corporal
        #endregion
        //- Referencia a objetos para Test Escala del desarrrollo del niño
        #region Test Desarrollo del niño
        ControlEscalaEadAudicionLenguage gobCrtEadAl = null;
        ControlEscalaEadMotriFinoAdaptativa gobCrtEadMf = null;
        ControlEscalaEadMotricidadGruesa gobCrtEadMg = null;
        ControlEscalaEadPersonalSocial gobCrtEadPs = null;
        ControlVistaEscalaEadPuntuacion gobCrtEadPu = null;
        // Registros de referencia
        ClassXmlPropObjeto gobCrtEadAlReg = null;
        ClassXmlPropObjeto gobCrtEadMfReg = null;
        ClassXmlPropObjeto gobCrtEadMgReg = null;
        ClassXmlPropObjeto gobCrtEadPsReg = null;
        ClassXmlPropObjeto gobCrtEadPuReg = null; 
        #endregion
        //---------------
        #region Configuracion variables de entorno
        VistaModeloCaptura vm = new VistaModeloCaptura();
        XmlEntornoCaptura XmlEntorno = new XmlEntornoCaptura();
        Aplicacion oApp = Aplicacion.Instancia();
        DialogVistaErrores lobDlgLogs = null;
        #endregion
        #endregion
        /// <summary>
        /// <para>tcrTipoId:</para>
        /// <para>HC = Codigo de la Historia clinica</para>
        /// <para>IG = Codigo unico del paciente en el sistema</para>
        /// <para>ID = Numero de identificacion del paciente en el sistema</para>
        /// <para>tcrIdRegistro: Valor o Vacio </para>
        /// </summary>
        public VistaCapturaReportes(String tcrTipoId, String tcrIdRegistro, String tcrIdAdmision)
        {
            InitializeComponent();
            #region Configuracion
            //- Establecer Directorio actual 
            //Directory.SetCurrentDirectory("..\\..\\..\\");

            // recojer el paramtro 
            gcrParamTipoId          = tcrTipoId;
            gcrParamTipoIdBak       = tcrTipoId;
            gcrParamIdRegistro      = tcrIdRegistro;
            gcrParamIdRegistroBak   = tcrIdRegistro;

            gcrParamIdAdmision = tcrIdAdmision;
            gcrParamIdAdmisionCarg = tcrIdAdmision;

            vm.gobjRefForm                  = this;
            this.DataContext                = vm; //Binding con el Vista Modelo
            this.stkPropBasicas.Visibility  = Visibility.Hidden;
            this.cmdEtiqueta.IsEnabled      = false;
            vm.lcrIdAdmisionActiva          = String.Empty;
            vm.gcrUsuaCodigoPerfil          = oApp.gcrUsuCodigoPerfil;

            XmlEntorno.gobRefPlantillaEtiqueta      = this.plaEtiqueta;
            XmlEntorno.gobRefPlantillaEscritorio    = this.wraPlantilla;
            XmlEntorno.gobRefVistaHistorial         = this.wraHistorial;
            XmlEntorno.gobRefVM                     = vm;


            fcvResizePantalla();
            fcvGestoTimerHX();
            fcvGestoTimerVY();
            fcvTimerGeneral();

            glgObjetosCargados = true;
            EventManager.RegisterClassHandler(typeof(Window), UIElement.KeyDownEvent, new KeyEventHandler(fcvEventoManejadorKeyDown));
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvNavEscritorioTouch();
            fcvCmdOrientacionNavEscritorio();
            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);

            fcvCargarVistaNotificaciones();
            fcvCmdAddMenuActividadMedica(); 
            #endregion
        }
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
            double lduBarraWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 100;
            double lduWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 10;
            double lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 96.8;
            double lduHistHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 77;

            this.grdMenuPropideades.Height = lduHeight;
            this.cvaMenuHistorial.Height = lduHistHeight + 80;
            this.grdMenuHistorial.Height = lduHeight + 80;
            this.objHistCortina.Height = lduHeight;

            this.cvaEtiqueta.Width = lduBarraWidth - (lduBarraWidth * 0.028);
            this.grdEtiqueta.Width = lduBarraWidth - (lduBarraWidth * 0.028);
            this.grdMenuSuperior.Width = lduBarraWidth - (lduBarraWidth * 0.028);
            Canvas.SetLeft(stkScrollEtiqueta, 0);
            Canvas.SetTop(stkHistorial, 2);
            Canvas.SetTop(objHistCortina, 2);

            fcvGetValorBaseZoomScroll("SET");
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
            lobDlgLogs.fcvCargarVista("Vista errores", XmlEntorno.tmpLogErrores);
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
        //------------------------------------------------------------
        //  Timer ANIMACION AL MOVER ESCRITORIO CAPA ETIQUETA y MURO
        //------------------------------------------------------------
        #region fcvTimer: Control Tiempo para cosas varias
        public void fcvTimerGeneral()
        {
            var ldspTimerSistema = new DispatcherTimer();
            ldspTimerSistema.Tick += new System.EventHandler(out fcvTimerProcesos);
            ldspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 120);
            ldspTimerSistema.Start();
        }
        #endregion
        #region fcvGestoTimerHX: Tiempo para la gestion de Gestos Horizontal
        public void fcvGestoTimerHX()
        {
            gdspAnimTimerClickHX            = new DispatcherTimer();
            gdspAnimTimerClickHX.Tick       += new System.EventHandler(out fcvAnimacionHoraClickyTouchTickHX);
            gdspAnimTimerClickHX.Interval   = new TimeSpan(0, 0, 0, 0, 120);
            gdspAnimTimerClickHX.Start();
            gdspAnimTimerHX             = new DispatcherTimer();
            gdubAnimarObjetoHX          = new DoubleAnimationUsingKeyFrames();
            gdubAnimarObjetoHX.Duration = TimeSpan.FromMilliseconds(1800);
            gdspAnimTimerHX.Interval    = new TimeSpan(0, 0, 0, 0, 1000);
            gdspAnimTimerHX.Tick        += new System.EventHandler(out fcvEjecutaAnimacionTimerTickHX);
        }
        #endregion
        #region fcvGestoTimerVY: Tiempo para la gestion de Gestos Vertical
        public void fcvGestoTimerVY()
        {
            gdspAnimTimerClickVY          = new DispatcherTimer();
            gdspAnimTimerClickVY.Tick     += new System.EventHandler(out fcvAnimacionHoraClickyTouchTickVY);
            gdspAnimTimerClickVY.Interval = new TimeSpan(0, 0, 0, 0, 120);
            gdspAnimTimerClickVY.Start();
            gdspAnimTimerVY             = new DispatcherTimer();
            gdubAnimarObjetoVY          = new DoubleAnimationUsingKeyFrames();
            gdubAnimarObjetoVY.Duration = TimeSpan.FromMilliseconds(1800);
            gdspAnimTimerVY.Interval    = new TimeSpan(0, 0, 0, 0, 1000);
            gdspAnimTimerVY.Tick        += new System.EventHandler(out fcvEjecutaAnimacionTimerTickVY);
        }
        #endregion
        //------------------------------------------------------------
        // PROCESOS CONTROLADOS CON TIMER GENERAL
        //------------------------------------------------------------
        #region fcvTimerProcesos: Timer para control Click y Touch X Horizontal
        /// <summary>
        /// <para>Timer para control Click y Touch X Horizontal</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            this.TxtHora.Text = DateTime.Now.ToString("f");//hh:mm tt dd/MM/yyyy");
            try
            {

                //------------------------------------------------------------
                // al mostrar la vista del historial
                //------------------------------------------------------------
                #region Proceso
                if (glgVistaHistorialVisible == true && this.objHistCortina.Visibility == Visibility.Visible)
                {
                    var lduPosHist = Math.Abs(Canvas.GetLeft(this.grdMenuHistorial));
                    if (lduPosHist < 15)
                    {
                        this.objHistCortina.Visibility = Visibility.Collapsed;
                    }
                }
                #endregion
                //------------------------------------------------------------
                // al mostrar la vista Propiedades ocultar notificaciones
                //------------------------------------------------------------
                #region Proceso
                if (glgVistaPropVisible == true && this.gobCrtNotifi.Visibility == Visibility.Visible)
                {
                    var lduPosHist = Math.Abs(Canvas.GetLeft(this.grdMenuPropideades));
                    if (lduPosHist > 10)
                    {
                        this.gobCrtNotifi.Visibility = Visibility.Collapsed;
                    }
                }
                if (glgVistaPropVisible == false && this.gobCrtNotifi.Visibility == Visibility.Collapsed)
                {
                    var lduPosHist = Math.Abs(Canvas.GetLeft(this.grdMenuPropideades));
                    if (lduPosHist < 100)
                    {
                        this.gobCrtNotifi.Visibility = Visibility.Visible;
                    }
                }
                #endregion
                //------------------------------------------------------------
                // al cargar el formulario  cargar el historial del paciente
                //------------------------------------------------------------
                #region Proceso
                if (this.IsLoaded)
                {
                    if (!String.IsNullOrWhiteSpace(gcrParamIdRegistro))
                    {
                        //fcvCmdAddMenuActividadMedica();
                        fcvHcVistaAbrirHistorialClinico();
                    }
                }
                if (glgRefreshVistaPlntilla == true)
                {
                    glgRefreshVistaPlntilla = false;
                    fcvResizePaginaControlCaptura();
                }
                #endregion
                //------------------------------------------------------------
                // Cambio de imagen boton validacion error
                //------------------------------------------------------------
                #region Proceso
                fcvCambiarImagenIconoValidacionErrores();
                #endregion
                //------------------------------------------------------------
                // TEST DE FRAMINGHAM - IMC Y OTROS
                //------------------------------------------------------------
                #region Proceso Test Framingham
                if (gobCrtFrmg != null)
                {
                    if (gobCrtFrmg.llgModoEdicionKey == false && gobCrtFrmg.llgObjetosCargados == true && gobCrtFrmg.llgModoEdicionValid == false)
                    {
                        gobCrtFrmg.llgModoEdicionValid = true;
                        fcvValidacionTestFramingHam();
                        gobCrtFrmg.llgModoEdicionValid = false;
                        if (XmlEntorno.gcrDatosModoVista == "V")
                        {
                            gobCrtFrmg = null; // cuando es modo V = Vista, para que no vuelva a entrar aqui - solo se cargue una vez
                            gobCrtFrmgReg = null;
                        }
                    }
                }
                #endregion
                #region Proceso IMC
                if (gobCrtIMC != null)
                {
                    if (gobCrtIMC.llgModoEdicionKey == false && gobCrtIMC.llgObjetosCargados == true && gobCrtIMC.llgModoEdicionValid == false)
                    {
                        gobCrtIMC.llgModoEdicionValid = true;
                        fcrValidacionImc();
                        gobCrtIMC.llgModoEdicionValid = false;
                        if (XmlEntorno.gcrDatosModoVista == "V")
                        {
                            gobCrtIMC = null; // cuando es modo V = Vista, para que no vuelva a entrar aqui - solo se cargue una vez
                            gobCrtIMCReg = null;
                        }
                    }
                }
               #endregion
                //------------------------------------------------------------
                // TEST ESACALA ABREVIADA DEL DESARROLLO
                //------------------------------------------------------------
                #region Escala personal social
                if (gobCrtEadPu != null)
                {
                    if (gobCrtEadPu.llgModoEdicionKey == false && gobCrtEadPu.llgObjetosCargados == true && gobCrtEadPu.llgModoEdicionValid == false)
                    {
                        gobCrtEadPu.llgModoEdicionValid = true;
                        fcrValidacionTestEad();
                        gobCrtEadPu.llgModoEdicionValid = false;
                        if (XmlEntorno.gcrDatosModoVista == "V")
                        {
                            // cuando es modo V = Vista, para que no vuelva a entrar aqui - solo se cargue una vez
                            gobCrtEadAl = null;
                            gobCrtEadMf = null;
                            gobCrtEadMg = null;
                            gobCrtEadPs = null;
                            gobCrtEadPu = null; 
                        }
                    }
                }
                #endregion
                //------------------------------------------------------------
                // EJECUTAR CODIGO FUENTE DE PLANTILLAS
                //------------------------------------------------------------
                #region Escala personal social
                if (oAppICodigofuente != null && XmlEntorno.gcrDatosModoVista != "V")
                {
                    if (llgEjecutandoCodigoFKey == false && lnuContaEjecutar > 9)
                    {
                        llgEjecutandoCodigoFKey = true;
                        //oAppICodigofuente.fcrEjecutarCodigoFuente(this, XmlEntorno.gobRegPlantMaestro.Grp_idepla_grpv,
                        //                                            ref XmlEntorno.tmpLogErrores,
                        //                                            ref XmlEntorno.tmpObjetos,
                        //                                            ref XmlEntorno.tmpCapturaDatos);

                        oAppICodigofuente.fcrEjecutarCodigoFuente(this, "",
                                                                    ref XmlEntorno.tmpLogErrores,
                                                                    ref XmlEntorno.tmpObjetos,
                                                                    ref XmlEntorno.tmpCapturaDatos);

                        llgEjecutandoCodigoFKey = false;
                        lnuContaEjecutar = 0;
                    }
                    else
                    {
                        lnuContaEjecutar++; 
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Metodo: fcvTimerProcesos");
            }
        }
        #endregion
        //-------------------------------------------------
        // fcvCargarVistaNotificaciones: Cargar vista notificaciones
        //-------------------------------------------------
        #region fcvCargarVistaNotificaciones
        private void fcvCargarVistaNotificaciones()
        {
            gobCrtNotifi = new ControlNotificaciones();
            Canvas.SetLeft(gobCrtNotifi, -7);
            this.ExtMenuPropideades.Children.Add(gobCrtNotifi);

            if (this.gobCrtNotifi.flgCargarVistaNotificaciones(oApp.gcrUsuCodigoPerfil, "HOS", "HCL002"))
            {
                foreach (var lobreg in this.gobCrtNotifi.tmpObjetos)
                {
                    var lobBoton = lobreg.RefObjeto as TilesNotificacion;
                    lobBoton.MouseDown += new MouseButtonEventHandler(fcvVistaNotificacionClick);
                    lobBoton.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDown);
                }
                this.gobCrtNotifi.fcvActalizarVistaNotificaciones();
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
            var lobTile = sender as TilesNotificacion;
            DialogVistaNotificaciones lobNotif = new DialogVistaNotificaciones();
            lobNotif.Owner = this;
            lobNotif.fcvCargarVista(lobTile.ToolTip.ToString(), oApp.gcrUsuCodigoPerfil,
                                    oApp.gcrUsuIdUsuario, lobTile.gcrIdModulo, lobTile.gcrTipoNotificacion);
            lobNotif.fcvActivarVista();

        }
        #endregion
        //-------------------------------------------------
        //  INotificacion Y Browser recoge el valor Key desde browser F2
        //-------------------------------------------------
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

            HCLValidarCodigo.fobRegBuscarHclmaestrohisclIAdm(gcrParamIdAdmision);

            switch (tcrTipoNotificacion)
            {
                case "ADM-ADMI-URGENCIAS":
                    // Adimision urgencias
                    if (flgCargarAdmision(tcrRegEvento))
                    {
                        // para que se cargue la admision y el historial
                        gcrParamTipoId      = gcrParamTipoIdBak;
                        gcrParamIdRegistro  = gcrParamIdRegistroBak;
                        fcvLimpiarVista();
                    }
                    break;

                case "ADM-ADMI-HOSPITALIZ":
                    // Adimision Hospitalizacion
                    if (flgCargarAdmision(tcrRegEvento))
                    {
                        // para que se cargue la admision y el historial
                        gcrParamTipoId      = gcrParamTipoIdBak;
                        gcrParamIdRegistro  = gcrParamIdRegistroBak;
                        fcvLimpiarVista();
                    }
                    break;

                case "ADM-ATEN-AMBULATORIA":
                    // Atencion ambulatoria
                    if (flgCargarAdmision(tcrRegEvento))
                    {
                        // para que se cargue la admision y el historial
                        gcrParamTipoId      = gcrParamTipoIdBak;
                        gcrParamIdRegistro  = gcrParamIdRegistroBak;
                        fcvLimpiarVista();
                    }
                    break;

                case "HOS-PLAN-M-INTERNO":

                    larArray = tcrRegEvento.Split('*');
                    if (flgCargarAdmision(larArray[0]))
                    {
                        // para que se cargue la admision y el historial
                        gcrParamTipoId      = gcrParamTipoIdBak;
                        gcrParamIdRegistro  = gcrParamIdRegistroBak;
                        fcvLimpiarVista();
                    }
                    break;

                case "HOS-AUTORI-SALIDA":

                    larArray = tcrRegEvento.Split('*');
                    if (flgCargarAdmision(larArray[0]))
                    {
                        // para que se cargue la admision y el historial
                        gcrParamTipoId      = gcrParamTipoIdBak;
                        gcrParamIdRegistro  = gcrParamIdRegistroBak;
                        fcvLimpiarVista();
                    }
                    break;

                case "HOS-TRASLADO-PACIENT":

                    larArray = tcrRegEvento.Split('*');
                    if (flgCargarAdmision(larArray[0]))
                    {
                        // para que se cargue la admision y el historial
                        gcrParamTipoId      = gcrParamTipoIdBak;
                        gcrParamIdRegistro  = gcrParamIdRegistroBak;
                        fcvLimpiarVista();
                    }
                    break;

                case "ADM-TRIAGE-URGENCIA":

                    larArray = tcrRegEvento.Split('*');
                    var lobReg = ADMValidarCodigo.fobRegBuscarAdmregadmisionTriage(larArray[0]);

                    if (lobReg != null)
                    {

                        if (flgCargarAdmision(lobReg.adm_secadm_rgad))
                        {
                            // para que se cargue la admision y el historial
                            gcrParamTipoId      = gcrParamTipoIdBak;
                            gcrParamIdRegistro  = gcrParamIdRegistroBak;
                            fcvLimpiarVista();
                        }
                    }
                    break;
            }

        }
        private bool flgCargarAdmision(String tcrIdAdmision)
        {
            bool llgReturn = false;
            var lobReg = ADMModeloAdmadmisiones.flsListaAdmregadmisionSimple(tcrIdAdmision);
            if (lobReg != null)
            {
                gcrParamIdUnicoSistem = lobReg.Sia_idesec_usua;
                gcrParamIdAdmision = lobReg.Adm_secadm_rgad;
                gcrParamTipoIdBak = "IG";
                gcrParamIdRegistroBak = gcrParamIdUnicoSistem;

                llgReturn = true;
            }
            return llgReturn;
        }
        private void fcvLimpiarVista()
        {
            fcvCmdAddImagenesPredefinidas("-");
            fcvAdicionarManejadorPaginasyZonas("OBJETOS", "-");
            this.wraPlantilla.Children.Clear();
            fcvGestionReiniciarVariables();
        }
        #endregion
        // BUSCAR DESDE BROWSER F2
        #region fcvBuscarRegistro: Metodo que recoge el valor Key desde browser F2
        /// <summary>
        /// <para>recoger el codigo dado en Browser de busqueda con  tecla F2</para>
        /// </summary>
        public void fcvBuscarRegistro(String tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "NUEVO":
                    // buscar el registro en modelo
                    fcvCargarVistaPlantillaNuevo(tcrCodigo);
                    break;

                case "ABRIR":
                    fcvCerrarVistaDatos();
                    var lobRegEx = HCLValidarCodigo.fobRegBuscarHclmaestrohiscl(tcrCodigo);

                    if (lobRegEx != null)
                    {
                        gcrParamTipoId = "IG"; // llego Numero de historia clinica
                        gcrParamIdRegistro = lobRegEx.sia_idesec_usua;
                    }
                    break;

                case "CONTROLCAPTURA-ADD":
                    //- iniciar barra de progreso 
                    DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Cargar vista de datos...", "CENTRO");
                    lobDlgAdd.Show();

                    flgEnlazarEventosClickControlCaptura("-");
                    if (flgValidaEsControlCapturaOdontologia())
                    {
                        gobCtrControlCaptura.fcvCargarVista(gobCtrControlCaptura.gcrCodigoAdmision);
                        var lobReg = gobCtrControlCaptura.fobRegSelectRegistro("REGISTRO", tcrCodigo);
                        if (lobReg != null || lobReg.Count != 0)
                        {
                            if (lobReg.FirstOrDefault().EstadoRegistro != "1")
                            {
                                // Para que se recargue el historial clinico 
                                gcrParamTipoId = gcrParamTipoIdBak;
                                gcrParamIdRegistro = gcrParamIdRegistroBak;
                            }
                        }
                    }
                    else
                    {
                        gobCtrControlCaptura.fcvCargarRegistro(tcrCodigo);
                    }
                    flgEnlazarEventosClickControlCaptura("+");

                    lobDlgAdd.Close();
                    break;

                case "CONTROLCAPTURA-CON":
                    //- iniciar barra de progreso 
                    DialogProgressBarEx lobDlgCon = new DialogProgressBarEx();
                    lobDlgCon.fcvProgressBarIniciar("Cargar vista de datos...", "CENTRO");
                    lobDlgCon.Show();

                    gobCtrControlCaptura.fcvCargarRegistro(tcrCodigo);
                    lobDlgCon.Close();
                    // Para que se recargue el historial clinico 
                    gcrParamTipoId = gcrParamTipoIdBak;
                    gcrParamIdRegistro = gcrParamIdRegistroBak;
                    break;

                default:
                    // seleccion desde un browser para una tabla
                    gcrCtrF2TexBoxObj.Text = tcrCodigo;
                    break;
            }
            glgRefreshVistaPlntilla = true;
        }
        #endregion
        #region fcvCargarVistaPlantillaNuevo: Cargar una nueva vista de plantilla
        /// <summary>
        /// <para>Cargar una nueva vista para digitacion de dato</para>
        /// <para>recibe como parametro el codigo de la plantilla en base de datos</para>
        /// </summary>
        public void fcvCargarVistaPlantillaNuevo(String tcrCodigo)
        {
            //- iniciar barra de progreso 
            try
            {
                DialogProgressBarEx lobDlgBarra = new DialogProgressBarEx();
                lobDlgBarra.fcvProgressBarIniciar("Cargar vista de datos...", "CENTRO");
                lobDlgBarra.Show();

                fcvAdicionarManejadorPaginasyZonas("OBJETOS", "-");
                this.wraPlantilla.Children.Clear();
                XmlEntorno.fcvGestionReiniciarValriables();

                XmlEntorno.gobRegPlantMaestro           = ModeloPlantilla.flsListaGrpmaeplantilla(tcrCodigo).FirstOrDefault();
                XmlEntorno.gobRegPlantVersion           = VersionPlantilla.flsBuscarVersionPlantilla(XmlEntorno.gobRegPlantMaestro.Grp_idepla_grpv).FirstOrDefault();
                XmlEntorno.gcrImportArchivoPlantilla    = XmlEntorno.gobRegPlantVersion.Grp_xmlpla_grpv;
                XmlEntorno.gcrTipoOrigenArchivo         = "BDATOS";
                vm.G1Sis_estpro_espr                    = "1";

                fcvGestionReiniciarVariables();
                if (XmlEntorno.flgMostrarVistaPlantilla(XmlEntorno.gobRegPlantMaestro.Grp_idepla_grpv))
                {
                    fcvAdicionarManejadorPaginasyZonas("OBJETOS", "+");
                    fcvCompilarCodigoFuentePlantilla();
                    XmlEntorno.flgCargarValoresDatosVistaObjetos();
                    //fcvActivarBarraEstado(false);
                    vm.GlgSIS_ModoEdicion               = true;
                    vm.tmpEtiquetaItems                 = XmlEntorno.fobRegSelectItemsEtiquetas("");
                    fcvGetValorBaseZoomScroll("SET");
                    flgEnlazarEventosClickControlCaptura("+");
                    flgValidaEsControlCapturaOdontologia();
                    vm.GlgSIS_ValidacionOk              = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;
                    XmlEntorno.glgNuevoRegistroPlantilla = false;
                    vm.GlgSIS_ModoGestionMultiSet       = XmlEntorno.gcrDatosModoGestion == "G" ? true : false;
                    vm.PropTxtPlantTipoImpresion        = XmlEntorno.gcrPlantillaTipoImpresion;
                }
                else
                {
                    MessageBox.Show("No fue posible cargar los datos.");
                }
                //- Cerrar la barra
                lobDlgBarra.Close();
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Captura Historias clinicas: fcvCargarVistaPlantillaNuevo");
            }
        }
        #endregion
        //------------------------------------------------------------
        // GESTOS EN MODO HORIZONTAL
        //------------------------------------------------------------
        #region fcvGestoHorizontalPreviewTouchDown: Tomar los Valores iniciales
        /// <summary>
        /// <para>Gestión Touch</para>
        /// <para>Tomar los Valores iniciales para las variables que gestionan los gestos</para>
        /// </summary>
        private void fcvGestoHorizontalPreviewTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            gcrAnimRegionVista = fcrGetPanelAnimacion(sender);
            switch (gcrAnimRegionVista)
            {
                case "ETIQUETA":
                    gobAnimRefMainCanvasHX = this.cvaPanelEtiqueta;
                    gobAnimRefMetroStkPanelHX = this.stkScrollEtiqueta;
                    gduAnimInicioPuntoMouseHX = e.GetTouchPoint(cvaPanelEtiqueta).Position.X;
                    gduAnimOldPosStkPanelHX = Canvas.GetLeft(stkScrollEtiqueta); // inicial - posicion extremo izquierdo del MetroStackPanel dentro del Canvas 
                    break;

                case "ESCRITORIO":
                    break;
            }
        }
        #endregion
        #region fcvGestoHorizontalPreviewTouchUp: Realiza los calculos para la nueva posicion
        /// <summary>
        /// <para>Gestión Touch</para>
        /// <para>Realiza los calculos para la nueva posicion del MetroStkPanel e inicia la animacion</para>
        /// </summary>
        private void fcvGestoHorizontalPreviewTouchUp(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;

            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            gcrAnimRegionVista = fcrGetPanelAnimacion(sender);
            gduAnimFinalPuntoMouseHX = e.GetTouchPoint(gobAnimRefMainCanvasHX).Position.X;

            Double lduDiferencia = Math.Abs(gduAnimFinalPuntoMouseHX - gduAnimInicioPuntoMouseHX);

            // se mueve solo cuando hay una diferencia sustancial
            // no se mueve cuando sea un  double-click.
            if (lduDiferencia > 5)
            {
                if (gduAnimFinalPuntoMouseHX < gduAnimInicioPuntoMouseHX)
                {
                    gduAnimNewPosStkPanelHX = gduAnimOldPosStkPanelHX - (lduDiferencia * 2);
                }
                else if (gduAnimFinalPuntoMouseHX > gduAnimInicioPuntoMouseHX)
                {
                    gduAnimNewPosStkPanelHX = gduAnimOldPosStkPanelHX + (lduDiferencia * 2);
                }
                lnuAniContTouchDownHX = 0;
                gdubAnimarObjetoHX.KeyFrames.Add(new SplineDoubleKeyFrame(gduAnimNewPosStkPanelHX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                gdubAnimarObjetoHX.FillBehavior = FillBehavior.HoldEnd;
                gobAnimRefMetroStkPanelHX.BeginAnimation(Canvas.LeftProperty, gdubAnimarObjetoHX);
                gdubAnimarObjetoHX.KeyFrames.Clear();
                gdspAnimTimerHX.Start();
            }
        }
        #endregion
        // Gestos en Vista modo Horizontal con Mouse
        #region fcvGestoHorizontalPreviewMouseLeftButtonDown: Tomar los Valores iniciales
        /// <summary>
        /// <para>Gestión con Mouse</para>
        /// <para>Tomar los Valores iniciales para las variables que gestionan los gestos</para>
        /// </summary>
        private void fcvGestoHorizontalPreviewMouseLeftButtonDown(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            gcrAnimRegionVista = fcrGetPanelAnimacion(sender);
            switch (gcrAnimRegionVista)
            {
                case "ETIQUETA":
                    gobAnimRefMainCanvasHX = this.cvaPanelEtiqueta;
                    gobAnimRefMetroStkPanelHX = this.stkScrollEtiqueta;
                    gduAnimInicioPuntoMouseHX = e.GetPosition(cvaPanelEtiqueta).X;
                    gduAnimOldPosStkPanelHX = Canvas.GetLeft(stkScrollEtiqueta); // inicial - posicion extremo izquierdo del MetroStackPanel dentro del Canvas 
                    break;

                case "ESCRITORIO":
                    break;
            }
        }
        #endregion
        #region fcvGestoHorizontalPreviewMouseLeftButtonUp: Realiza los calculos para la nueva posicion
        /// <summary>
        /// <para>Gestion con mouse</para>
        /// <para>Realiza los calculos para la nueva posicion del MetroStkPanel e inicia la animacion</para>
        /// </summary>
        private void fcvGestoHorizontalPreviewMouseLeftButtonUp(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            gcrAnimRegionVista = fcrGetPanelAnimacion(sender);
            gduAnimFinalPuntoMouseHX = e.GetPosition(gobAnimRefMainCanvasHX).X;
            Double lduDifernecia = Math.Abs(gduAnimFinalPuntoMouseHX - gduAnimInicioPuntoMouseHX);
            // se mueve solo cuando hay una diferencia sustancial
            // no se mueve cuando sea un  double-click.
            if (lduDifernecia > 5)
            {
                if (gduAnimFinalPuntoMouseHX < gduAnimInicioPuntoMouseHX)
                {
                    gduAnimNewPosStkPanelHX = gduAnimOldPosStkPanelHX - (lduDifernecia * 2);
                }
                else if (gduAnimFinalPuntoMouseHX > gduAnimInicioPuntoMouseHX)
                {
                    gduAnimNewPosStkPanelHX = gduAnimOldPosStkPanelHX + (lduDifernecia * 2);
                }
                lnuAniContTouchDownHX = 0;
                gdubAnimarObjetoHX.KeyFrames.Add(new SplineDoubleKeyFrame(gduAnimNewPosStkPanelHX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                gdubAnimarObjetoHX.FillBehavior = FillBehavior.HoldEnd;
                gobAnimRefMetroStkPanelHX.BeginAnimation(Canvas.LeftProperty, gdubAnimarObjetoHX);
                gdubAnimarObjetoHX.KeyFrames.Clear();
                gdspAnimTimerHX.Start();
            }
        }
        #endregion
        // Timer que ejecuta animacion
        #region fcvEjecutaAnimacionTimerTickHX: Ejecuta la animacion y ajusta la vista X Horizontal
        /// <summary>
        /// <para>Ejecuta la animacion y ajusta la vista del MetroStkpanel dependiendo del ancho minimo en X Horizontal</para>
        /// </summary>
        private void fcvEjecutaAnimacionTimerTickHX(Object sender, EventArgs e)
        {
            if (gcrAnimRegionVista != "ETIQUETA" && gcrAnimRegionVista != "ESCRITORIO") { return; }

            Double mspWidth = gobAnimRefMetroStkPanelHX.ActualWidth;

            if (gduAnimNewPosStkPanelHX > 200)
            {
                gdubAnimarObjetoHX.KeyFrames.Add(new SplineDoubleKeyFrame(45, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                gdubAnimarObjetoHX.FillBehavior = FillBehavior.HoldEnd;
                gobAnimRefMetroStkPanelHX.BeginAnimation(Canvas.LeftProperty, gdubAnimarObjetoHX);
                gdubAnimarObjetoHX.KeyFrames.Clear();
            }
            else if ((gduAnimNewPosStkPanelHX + mspWidth) < 500)
            {
                Double widthX = 500 - (gduAnimNewPosStkPanelHX + mspWidth);
                Double shiftX = gduAnimNewPosStkPanelHX + widthX;
                gdubAnimarObjetoHX.KeyFrames.Add(new SplineDoubleKeyFrame(shiftX, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                gdubAnimarObjetoHX.FillBehavior = FillBehavior.HoldEnd;
                gobAnimRefMetroStkPanelHX.BeginAnimation(Canvas.LeftProperty, gdubAnimarObjetoHX);
                gdubAnimarObjetoHX.KeyFrames.Clear();
            }
            gdspAnimTimerHX.Stop();

        }
        #endregion
        #region fcvAnimacionHoraClickyTouchTickHX: Timer para control Click y Touch X Horizontal
        /// <summary>
        /// <para>Timer para control Click y Touch X Horizontal</para>
        /// </summary>
        void fcvAnimacionHoraClickyTouchTickHX(object sender, EventArgs e)
        {
            #region Control para TouchScreen
            if (gnuAnimContTouchDownHX > 0 && gnuAnimContTouchMilisegHX < 4)
            {
                gnuAnimContTouchMilisegHX++;
            }
            else
            {
                gnuAnimContTouchDownHX = 0;
                gnuAnimContTouchMilisegHX = 0;
            }
            #endregion
        }
        #endregion
        //------------------------------------------------------------
        // GESTOS EN MODO VERTICAL
        //------------------------------------------------------------
        #region fcvGestoVerticalPreviewTouchDown: Tomar los Valores iniciales
        /// <summary>
        /// <para>Gestión Touch</para>
        /// <para>Tomar los Valores iniciales para las variables que gestionan los gestos</para>
        /// </summary>
        private void fcvGestoVerticalPreviewTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            gcrAnimRegionVista = fcrGetPanelAnimacion(sender);
            switch (gcrAnimRegionVista)
            {
                case "HISTORIAL":
                    gobAnimRefMainCanvasVY      = this.cvaMenuHistorial;
                    gobAnimRefMetroStkPanelVY   = this.stkHistorial;
                    gduAnimInicioPuntoMouseVY   = e.GetTouchPoint(cvaMenuHistorial).Position.Y;
                    gduAnimOldPosStkPanelVY     = Canvas.GetLeft(stkHistorial); // inicial - posicion extremo izquierdo del MetroStackPanel dentro del Canvas 
                    break;

                case "ESCRITORIO":
                    break;
            }
        }
        #endregion
        #region fcvGestoVerticalPreviewTouchUp: Realiza los calculos para la nueva posicion
        /// <summary>
        /// <para>Gestión Touch</para>
        /// <para>Realiza los calculos para la nueva posicion del MetroStkPanel e inicia la animacion</para>
        /// </summary>
        private void fcvGestoVerticalPreviewTouchUp(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            gcrAnimRegionVista       = fcrGetPanelAnimacion(sender);
            gduAnimFinalPuntoMouseVY = e.GetTouchPoint(gobAnimRefMainCanvasVY).Position.Y;

            Double lduDiferencia     = Math.Abs(gduAnimFinalPuntoMouseVY - gduAnimInicioPuntoMouseVY);

            // se mueve solo cuando hay una diferencia sustancial
            // no se mueve cuando sea un  double-click.
            if (lduDiferencia > 5)
            {
                if (gduAnimFinalPuntoMouseVY < gduAnimInicioPuntoMouseVY)
                {
                    gduAnimNewPosStkPanelVY = gduAnimOldPosStkPanelVY - (lduDiferencia * 2);
                }
                else if (gduAnimFinalPuntoMouseVY > gduAnimInicioPuntoMouseVY)
                {
                    gduAnimNewPosStkPanelVY = gduAnimOldPosStkPanelVY + (lduDiferencia * 2);
                }
                lnuAniContTouchDownVY = 0;
                gdubAnimarObjetoVY.KeyFrames.Add(new SplineDoubleKeyFrame(gduAnimNewPosStkPanelVY, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                gdubAnimarObjetoVY.FillBehavior = FillBehavior.HoldEnd;
                gobAnimRefMetroStkPanelVY.BeginAnimation(Canvas.TopProperty, gdubAnimarObjetoVY);
                gdubAnimarObjetoVY.KeyFrames.Clear();
                gdspAnimTimerHX.Start();
            }
        }
        #endregion
        // Gestos en Vista modo Vertical con Mouse
        #region fcvGestoVerticalPreviewMouseLeftButtonDown: Tomar los Valores iniciales
        /// <summary>
        /// <para>Gestión con Mouse</para>
        /// <para>Tomar los Valores iniciales para las variables que gestionan los gestos</para>
        /// </summary>
        private void fcvGestoVerticalPreviewMouseLeftButtonDown(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            gcrAnimRegionVista = fcrGetPanelAnimacion(sender);
            switch (gcrAnimRegionVista)
            {
                case "HISTORIAL":
                    gobAnimRefMainCanvasVY      = this.cvaMenuHistorial;
                    gobAnimRefMetroStkPanelVY   = this.stkHistorial;
                    gduAnimInicioPuntoMouseVY   = e.GetPosition(cvaMenuHistorial).Y;
                    gduAnimOldPosStkPanelVY     = Canvas.GetTop(stkHistorial); // inicial - posicion extremo izquierdo del MetroStackPanel dentro del Canvas 
                    break;

                case "ESCRITORIO":
                    break;
            }
        }
        #endregion
        #region fcvGestoVerticalPreviewMouseLeftButtonUp: Realiza los calculos para la nueva posicion
        /// <summary>
        /// <para>Gestion con mouse</para>
        /// <para>Realiza los calculos para la nueva posicion del MetroStkPanel e inicia la animacion</para>
        /// </summary>
        private void fcvGestoVerticalPreviewMouseLeftButtonUp(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            gcrAnimRegionVista          = fcrGetPanelAnimacion(sender);
            gduAnimFinalPuntoMouseVY    = e.GetPosition(gobAnimRefMainCanvasVY).Y;
            Double lduDifernecia        = Math.Abs(gduAnimFinalPuntoMouseVY - gduAnimInicioPuntoMouseVY);
            // se mueve solo cuando hay una diferencia sustancial
            // no se mueve cuando sea un  double-click.
            if (lduDifernecia > 5)
            {
                if (gduAnimFinalPuntoMouseVY < gduAnimInicioPuntoMouseVY)
                {
                    gduAnimNewPosStkPanelVY = gduAnimOldPosStkPanelVY - (lduDifernecia * 2);
                }
                else if (gduAnimFinalPuntoMouseVY > gduAnimInicioPuntoMouseVY)
                {
                    gduAnimNewPosStkPanelVY = gduAnimOldPosStkPanelVY + (lduDifernecia * 2);
                }
                lnuAniContTouchDownVY = 0;
                gdubAnimarObjetoVY.KeyFrames.Add(new SplineDoubleKeyFrame(gduAnimNewPosStkPanelVY, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                gdubAnimarObjetoVY.FillBehavior = FillBehavior.HoldEnd;
                gobAnimRefMetroStkPanelVY.BeginAnimation(Canvas.TopProperty, gdubAnimarObjetoVY);
                gdubAnimarObjetoVY.KeyFrames.Clear();
                gdspAnimTimerVY.Start();
            }
        }
        #endregion
        // Timer que ejecuta animacion
        #region fcvEjecutaAnimacionTimerTickVY: Ejecuta la animacion y ajusta la vista
        /// <summary>
        /// <para>Ejecuta la animacion y ajusta la vista del MetroStkpanel dependiendo del ancho minimo</para>
        /// </summary>
        private void fcvEjecutaAnimacionTimerTickVY(Object sender, EventArgs e)
        {
            if (gcrAnimRegionVista != "HISTORIAL" && gcrAnimRegionVista != "ESCRITORIO") { return; }

            Double mspHeight = gobAnimRefMetroStkPanelVY.ActualHeight;

            if (gduAnimNewPosStkPanelVY > 70)
            {
                gdubAnimarObjetoVY.KeyFrames.Add(new SplineDoubleKeyFrame(2, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                gdubAnimarObjetoVY.FillBehavior = FillBehavior.HoldEnd;
                gobAnimRefMetroStkPanelVY.BeginAnimation(Canvas.TopProperty, gdubAnimarObjetoVY);
                gdubAnimarObjetoVY.KeyFrames.Clear();
            }
            else if ((gduAnimNewPosStkPanelVY + mspHeight) < 380)
            {
                Double lduHeightY = 600 - (gduAnimNewPosStkPanelVY + mspHeight);
                Double lduShiftY = gduAnimNewPosStkPanelVY + lduHeightY;

                lduShiftY = lduShiftY > 70 ? 2 : lduShiftY;
                gdubAnimarObjetoVY.KeyFrames.Add(new SplineDoubleKeyFrame(lduShiftY, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), new KeySpline(0.161, 0.079, 0.008, 1)));
                gdubAnimarObjetoVY.FillBehavior = FillBehavior.HoldEnd;
                gobAnimRefMetroStkPanelVY.BeginAnimation(Canvas.TopProperty, gdubAnimarObjetoVY);
                gdubAnimarObjetoVY.KeyFrames.Clear();
            }
            gdspAnimTimerHX.Stop();
        }
        #endregion
        #region fcvAnimacionHoraClickyTouchTickVY: Timer para control Click y Touch
        /// <summary>
        /// <para>Timer para control Click y Touch</para>
        /// </summary>
        void fcvAnimacionHoraClickyTouchTickVY(object sender, EventArgs e)
        {
            #region Control para TouchScreen
            if (gnuAnimContTouchDownVY > 0 && gnuAnimContTouchMilisegVY < 4)
            {
                gnuAnimContTouchMilisegVY++;
            }
            else
            {
                gnuAnimContTouchDownVY = 0;
                gnuAnimContTouchMilisegVY = 0;
            }
            #endregion
        }
        #endregion
        // Saber Cual Panel Animar
        #region fcrGetPanelAnimacion: Saber Cual Panel Animar
        /// <summary>
        /// <para>Saber Cual es el Panel que sera animado ETIQUETA/ESCRITORIO/HISTORIAL</para>
        /// </summary>
        private String fcrGetPanelAnimacion(Object sender)
        {
            var lcrAnimRegionVista = gcrAnimRegionVista;
            if (sender == null) { return lcrAnimRegionVista; }
            var lobPanel = sender as FrameworkElement;

            if (lobPanel != null)
            {
                switch (lobPanel.Name)
                {
                    case "cvaPanelEtiqueta":
                        lcrAnimRegionVista = "ETIQUETA";
                        break;

                    case "cvaMenuHistorial":
                        lcrAnimRegionVista = "HISTORIAL";
                        break;
                }
            }
            return lcrAnimRegionVista;
        }
        #endregion
        //------------------------------------------------------------
        // Cerrar o Minimizar la aplicacion
        //------------------------------------------------------------
        #region Cerrar o Minimizar la aplicacion
        private void MinimizeButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            oApp.glgWiniAplicacionDesactivar = true;
        }
        private void MinimizeButton_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            oApp.glgWiniAplicacionDesactivar = true;
        }
        private void CloseButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            fcvCerrarVista();
        }
        private void CloseButton_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvCerrarVista();
        }
        private void fcvCerrarVista()
        {
            this.Close();
            fcvCmdAddComandosActividadMedica("-");
            // liberar los timers
            if (gdspAnimTimerVY != null) { gdspAnimTimerVY.Stop(); }
            if (gdspAnimTimerClickVY != null) { gdspAnimTimerClickVY.Stop(); }
            if (gdspAnimTimerHX != null) { gdspAnimTimerHX.Stop(); }
            if (gdspAnimTimerClickHX != null) { gdspAnimTimerClickHX.Stop(); }

        }
        #endregion
        //------------------------------------------------------------
        // ACCIONES BARRA DE OPCIONES SUPERIOR
        //------------------------------------------------------------
        #region Configuracion y acciones barra superior
        //-------------------------------------------------
        #region fcvMostrarMenuContextual: Mostrar menu contextual
        private void fcvMostrarMenuContextual(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #endregion
        //-------------------------------------------------
        //------------------------------------------------------------ 
        //- MENU DESPLEGABLE OPCIONES 
        //------------------------------------------------------------ 
        #region fcvCmdCerrarVista: Cerrar la plantilla abierta
        /// <summary>
        ///  fcvCmdCerrarVista: cerrar la plantilla abierta
        /// </summary>
        private void fcvCmdCerrarVista(object sender, RoutedEventArgs e)
        {
            fcvCerrarVistaDatos();
        }
        #endregion
        #region fcvPlantillaImportar: Importar Plantilla
        private void fcvPlantillaImportar(object sender, RoutedEventArgs e)
        {
            if (XmlEntorno.flgDialogoBuscarPlantilla())
            {
                fcvActivarBarraEstado(true);
                fcvAdicionarManejadorPaginasyZonas("OBJETOS", "-");
                this.wraPlantilla.Children.Clear();
                fcvGestionReiniciarVariables();
                /*
                if (XmlEntorno.flgMostrarVistaPlantilla())
                {
                    if (XmlEntorno.gobRegPropPlantillaDatos.DatosModoVista == "E" || XmlEntorno.gcrDatosModoGestion == "G")
                    {
                        fcvAdicionarManejadorPaginasyZonas("OBJETOS", "+");
                    }
                    XmlEntorno.flgCargarValoresDatosVistaObjetos();
                    fcvActivarBarraEstado(false);
                    vm.GlgSIS_ModoEdicion = true;
                    vm.tmpEtiquetaItems = XmlEntorno.fobRegSelectItemsEtiquetas("");
                    flgValidaEsControlCapturaOdontologia();
                    flgEnlazarEventosClickControlCaptura("+");
                    vm.tmpLogErrores = XmlEntorno.tmpLogErrores;
                    vm.gcrValorReturnChr = XmlEntorno.gcrValorReturnChr;
                    vm.GlgSIS_ValidacionOk = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;
                    XmlEntorno.glgNuevoRegistroPlantilla = false;
                    vm.GlgSIS_ModoGestionMultiSet = XmlEntorno.gcrDatosModoGestion == "G" ? true : false;
                    vm.PropTxtPlantTipoImpresion = XmlEntorno.gcrPlantillaTipoImpresion;

                    actualizar(); // ojo esto se debe quitar

                }
                else
                {
                    MessageBox.Show("No fue posible cargar los datos.");
                }
                */
            }
        }
        #endregion
        #region fcvPlantillaExportar: Exportar Plantilla
        private void fcvPlantillaExportar(object sender, RoutedEventArgs e)
        {
            if (XmlEntorno.flgDialogoExportarPlantilla())
            {
                XmlEntorno.fcvExportarPlantilla();
            }
        }
        #endregion
        #region fcvCerrarVistaDatos: Cerrar vista de historia clinica abierta
        /// <summary>
        /// <para>Cerrar vista de historia clinica abierta</para>
        /// </summary>
        private void fcvCerrarVistaDatos()
        {
            wraPlantilla.Children.Clear();
            XmlEntorno.fcvGestionReiniciarValriables();
            fcvGestionReiniciarVariables();
            XmlEntorno.gcrIdRegHistorialEventoActivo = String.Empty;
            vm.GlgSIS_ModoEdicion = false;
        }
        #endregion
        //------------------------------------------------------------ 
        // CARGAR VISTA HISTORIAL CLINICO DEL PACIENTE
        //------------------------------------------------------------ 
        #region fcvHcVistaAbrirHistorialClinico: Abrir el historial clinico del paciente activo
        private void fcvHcVistaAbrirHistorialClinico()
        {
            vm.lcrIdAdmisionActiva = gcrParamIdAdmision;
            gcrParamIdAdmisionCarg = gcrParamIdAdmision;

            // - datos desde parametros  
            var lcrTipoId       = gcrParamTipoId;
            var lcrIdRegistro   = gcrParamIdRegistro;

            //- iniciar barra de progreso 
            var lobDlgAdd = Funciones.fobWindEspera("Cargar vista de datos...", "CENTRO");

            this.wraHistorial.Children.Clear();
            fcvHcVistaHistorialCargarListAdmisiones();

            // Cargar detalles historial
            // Mostrar la Barra de progreso
            XmlEntorno.gobRegHistorial   = null;
            XmlEntorno.tmpVistaHistorial = HclModeloHistorialEventos.flsBuscarHistorialEventos(gcrParamTipoId, gcrParamIdRegistro);
            gcrParamTipoId      = String.Empty;
            gcrParamIdRegistro  = String.Empty;

            flgHcVistaHistorialCargarEventos();

            // Vista datos basicos ventana historial 
            fcvHcVistaAbrirDatosAdmisionActiva();

            lobDlgAdd.Close();
        }
        #endregion
        #region fcvHcVistaHistorialCargarListAdmisiones: Cargar lista historial de admisiones
        /// <summary>
        /// <para>Cargar lista historial de admisiones que existen en sistema</para>
        /// </summary>
        public void fcvHcVistaHistorialCargarListAdmisiones()
        {
            XmlEntorno.tmpVistaHistAdmi = ADMModeloTreeAdmHistorial.flsListaHistorialAdmisiones(gcrParamIdRegistro);
            if (XmlEntorno.tmpVistaHistAdmi != null)
            {
                var lcrUri    = "/Sistema;component/Imagenes/";
                var lcrImagen = "sis_edt_abierto.png";
                var i         = 1;

                foreach (var lobReg in XmlEntorno.tmpVistaHistAdmi)
                {
                    #region Cargar datos
                    var lobOpcion = new TileAdmision();
                    var lcrAreaServ = lobReg.Sia_desare_aser != null ? " - " + lobReg.Sia_desare_aser.ToUpper() : "";
                    //lobOpcion.Margin = new Thickness(1, 0, 0, 0);

                    if (i == 1) { lobOpcion.fcvOpcActivarVistaDetalles("+"); }
                    i++;

                    lobOpcion.EstadoHistorial   = "XX";
                    lobOpcion.RegistroAdmision  = lobReg.Adm_secadm_rgad;
                    lobOpcion.txtTitulo.Text    = lobReg.Adm_fecadm_rgad.ToShortDateString() + " - " + 
                                                            Funciones.fcrConvierteHora(lobReg.Adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":") +
                                                            lcrAreaServ;

                    lobOpcion.txtPrograma.Text = lobReg.Adm_secadm_rgad;

                    lcrImagen                   = lobReg.Adm_finate_rgad == "1" ? "sis_edt_abierto.png" : "sis_edt_cerrado.png";
                    lobOpcion.imgEstado.Source  = new BitmapImage(new Uri(lcrUri + lcrImagen, UriKind.RelativeOrAbsolute));
                    lobOpcion.txtEstado.Text    = lobReg.Sis_estpro_espr == "3" ? "ANULADA" : "";
                    // Guardar referencia del contenedor Admision en lista
                    lobReg.RefObjAdm = lobOpcion;
                    lobOpcion.cmdHistorialOcultar.Click += new RoutedEventHandler(fcvHcVistaButtonVistaAdmision);

                    this.wraHistorial.Children.Add(lobOpcion);
                    #endregion
                }
                #region Cargar datos triage no admitidos
                var lcrLineaSql = "SELECT count(*) FROM hclregiseventos WHERE adm_secadm_rgad='' AND sia_idesec_usua = @idRegistro";
                var lcrValor = Funciones.fcrConsultaSqlComando(lcrLineaSql, new Dictionary<string, object> { { "@idRegistro", gcrParamIdRegistro } });
                if (lcrValor != "*1*" && lcrValor != "0")
                {
                    // Generar registro para triage sin admision
                    #region Crear el nuevo registro
                    var lobRegEx = new ADMModeloTreeAdmHistorial();

                    lobRegEx.Adm_secadm_rgad = "NA";
                    lobRegEx.Adm_fecadm_rgad = Convert.ToDateTime("01/01/1000");
                    lobRegEx.Adm_horadm_rgad = 1;
                    lobRegEx.Hcl_gesfec_hcev = Convert.ToDateTime("01/01/1000");
                    lobRegEx.SecuencialRegistro = "NA";
                    lobRegEx.TipoRegistro = "ADM";
                    lobRegEx.RegistroVisible = "1";
                    lobRegEx.GestionEstadoRegistro = "XX";
                    #endregion
                    // Generar objeto triage
                    var lobTriage = new TileAdmision();

                    lobTriage.EstadoHistorial = "XX";
                    lobTriage.RegistroAdmision = lobRegEx.Adm_secadm_rgad;
                    lobTriage.txtTitulo.Text = "Registros Triage sin Admisión";
                    lobTriage.txtPrograma.Text = "NA";
                    lobTriage.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "sis_edt_cerrado.png", UriKind.RelativeOrAbsolute));
                    lobTriage.txtEstado.Text = "";
                    lobRegEx.RefObjAdm = lobTriage;

                    lobTriage.cmdHistorialOcultar.Click += new RoutedEventHandler(fcvHcVistaButtonVistaAdmision);

                    XmlEntorno.tmpVistaHistAdmi.Add(lobRegEx);
                    this.wraHistorial.Children.Add(lobTriage);
                }
                #endregion
            }
        }
        #endregion
        #region flgHcVistaHistorialCargarEventos: Ejecutar Hilo proceso para cargar vista historial
        /// <summary>
        /// <para>Ejecutar Hilo proceso para cargar vista historial</para>
        /// <para>Devuelve True/False si el proceso finaliza con exito o se genera algun error</para>
        /// </summary>
        private bool flgHcVistaHistorialCargarEventos()
        {
            var llgReturn = true;
            int lnuValorInicio = 1;
            var dlg = new DialogProgressBar();

            dlg.Owner = this;
            dlg.EjecutarHiloDeTrabajo(lnuValorInicio, fcvHcVistaHistorialCargarEventos);
            gcrParamIdAdmisionCarg = String.Empty;

            return llgReturn;
        }
        #endregion
        #region fcvHcVistaHistorialCargarEventos: Cargar el historial de eventos en el muro
        /// <summary>
        /// <para>Cargar el historial de eventos en el muro</para>
        /// <para>Devuelve True/False si la operación se realiza con exito</para>
        /// <para>tcrTipoId:</para>
        /// <para>HC = Codigo de la Historia clinica</para>
        /// <para>HR = Codigo registro unico en historial</para>
        /// <para>IG = Codigo unico del paciente en el sistema</para>
        /// <para>ID = Numero de identificacion del paciente en el sistema</para>
        /// </summary>
        public void fcvHcVistaHistorialCargarEventos(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker luxWorker = (BackgroundWorker)sender;

            if (XmlEntorno.tmpVistaHistorial != null)
            {
                // Valores Barra de progresso
                var lnuProgreso = 0;
                var lnuPorcentaje = 0;
                var lcrServicioFecha = String.Empty;
                var lcrServicioHora = String.Empty;
                var lcrCodigoAdmision = String.Empty;
                var lcrTextoFecha = String.Empty;
                var tmpVistaHistorial = XmlEntorno.fobRegSelectRegistroHistorial("ADMISION", gcrParamIdAdmisionCarg);
                var lnutotalRegistros = tmpVistaHistorial.Count;
                // Referencias
                DateTime ldaFechaEvento = Convert.ToDateTime("01/01/1000");
                TileAdmision lobRefGrupoAdm = null;
                ADMModeloTreeAdmHistorial lobRegAdm = null;

                //foreach (HclModeloHistorialEventos lobReg in XmlEntorno.tmpVistaHistorial)
                foreach (HclModeloHistorialEventos lobReg in tmpVistaHistorial)
                {
                    // Cuando no hay Registro Tipo Actividad relacionada con el evento
                    lobReg.Hcl_icolor_hcca = lobReg.Hcl_icolor_hcca == null ? "#FFDADADA" : lobReg.Hcl_icolor_hcca;
                    lobReg.Hcl_imagen_hcca = lobReg.Hcl_imagen_hcca == null ? "Edt_hist_vista_anulado.png" : lobReg.Hcl_imagen_hcca;

                    // Validar admision
                    if (String.IsNullOrWhiteSpace(lobReg.Adm_secadm_rgad) || lobReg.Adm_secadm_rgad == null) { lobReg.Adm_secadm_rgad = "NA"; }

                    #region Cargar datos
                    // gestion barra de progreso
                    lnuProgreso++;
                    lnuPorcentaje = Funciones.fnuPorcentaje(lnuProgreso, lnutotalRegistros);
                    String lcrMsg = "Cargando vista historial registros {0}%...";
                    lcrMsg = String.Format(lcrMsg, lnuPorcentaje);
                    luxWorker.ReportProgress(lnuPorcentaje, lcrMsg);
                    Thread.Sleep(50);

                    lcrServicioFecha = lobReg.Hcl_gesfec_hcev.ToShortDateString();
                    lcrServicioHora = Funciones.fcrConvierteHora(lobReg.Hcl_geshor_hcev.ToString(), "24", gcrSeparadorDecimal, ":");

                    #region Referencia del grupo admision y la fecha
                    //Cuando cambia la admision
                    if (lobReg.Adm_secadm_rgad != lcrCodigoAdmision || lobRefGrupoAdm == null)
                    {
                        lobRegAdm = XmlEntorno.tmpVistaHistAdmi.FirstOrDefault(x => x.Adm_secadm_rgad == lobReg.Adm_secadm_rgad && x.TipoRegistro == "ADM");

                        lobRefGrupoAdm = null;
                        if (lobRegAdm != null)
                        {
                            lobRegAdm.RegistroVisible = "1";
                            lobRegAdm.GestionEstadoRegistro = "OK";

                            lobRefGrupoAdm = (lobRegAdm.RefObjAdm) as TileAdmision;
                            lobRefGrupoAdm.EstadoHistorial = "OK";
                        }
                    }
                    #endregion

                    // Referenciar un registro 
                    if (!String.IsNullOrWhiteSpace(lobReg.Sia_idesec_usua))
                    {
                        if (XmlEntorno.gobRegHistorial == null) { XmlEntorno.gobRegHistorial = lobReg; }
                    }

                    #region Generar vista evento
                    // Cargar datos del evento y generar vista
                    if (lobRefGrupoAdm != null)
                    {
                        lobReg.RefObjAdm = lobRefGrupoAdm;

                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            //Cuando cambia la admision o la fecha
                            if (lobReg.Adm_secadm_rgad != lcrCodigoAdmision || lobReg.Hcl_gesfec_hcev != ldaFechaEvento)
                            {
                                var lobRegx = lobReg;
                                // Texto fecha
                                lcrTextoFecha = lobReg.Hcl_gesfec_hcev.ToString("D");
                                lcrTextoFecha = lcrTextoFecha.Substring(0, 1).ToUpper() + lcrTextoFecha.Substring(1, lcrTextoFecha.Length - 1);

                                fcvHcVistaTileAdmisionFecha(ref lobRefGrupoAdm, ref lobRegx, lcrTextoFecha);
                            }
                            lcrCodigoAdmision = lobReg.Adm_secadm_rgad;
                            ldaFechaEvento = lobReg.Hcl_gesfec_hcev;

                            // Generar Objeto Registro del evento
                            if (lobReg.Hcl_desreg_hcev != null)
                            {
                                var lobjTitle = fobHcVistaTileRegistroEvento(lobReg);

                                lobjTitle.cmdHistorialVer.Click += new RoutedEventHandler(fcvHistorialButtonVistaFormato);
                                lobReg.GestionEstadoRegistro = "OK";
                                lobReg.RefObjEvento = lobjTitle;
                                lobReg.Hcl_keydat_hcev = (lobReg.Hcl_nroreg_hcev.Trim() + " " + lobReg.Adm_secadm_rgad.Trim() +
                                                                                                " " + lobReg.Hcl_desreg_hcev.Trim() +
                                                                                                " " + lobReg.Hcl_keydat_hcev.Trim() +
                                                                                                " " + lcrServicioFecha +
                                                                                                " " + lobReg.Sia_nompro_prof +
                                                                                                " " + lobReg.Fcm_descpr_cpro).ToLower();
                                lobRefGrupoAdm.stkHistorial.Children.Add(lobjTitle);
                            }
                        }));

                    }
                    #endregion
                    #endregion
                }
            }
        }
        #endregion
        #region fobHcVistaTileRegistroEvento: Generar vista registro eventos en cada admision
        /// <summary>
        /// <para>Generar vista registro eventos en cada admision y guardar referencia</para>
        /// </summary>
        public TileHistorial fobHcVistaTileRegistroEvento(HclModeloHistorialEventos tcrRegistro)
        {
            var lcrServicioFecha = tcrRegistro.Hcl_gesfec_hcev.ToShortDateString();
            var lcrServicioHora  = Funciones.fcrConvierteHora(tcrRegistro.Hcl_geshor_hcev.ToString(), "24", gcrSeparadorDecimal, ":");

            #region Cargar eventos
            // Generar Objeto Registro del evento
            var lcrUri = "/GestorReportes;component/Imagenes/";
            var lobjTitle           = new TileHistorial();
            lobjTitle.Margin        = new Thickness(6, -1, 0, 0);
            lobjTitle.elpFondo.Fill = EdtUtilidades.SetSolidColorBrush(tcrRegistro.Hcl_icolor_hcca);

            lobjTitle.imgRegistro.Source = new BitmapImage(new Uri(lcrUri + tcrRegistro.Hcl_imagen_hcca.Trim(), UriKind.RelativeOrAbsolute));

            if (tcrRegistro.Sis_estpro_espr == "2") // confirmado 
            {
                lobjTitle.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_confirmado.png", UriKind.RelativeOrAbsolute));
            }
            else if (tcrRegistro.Sis_estpro_espr == "3") // Anulado
            {
                lobjTitle.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_anulado.png", UriKind.RelativeOrAbsolute));
            }

            // Datos para vista en el Tiles
            lobjTitle.RegistroEvento    = tcrRegistro.Hcl_nroreg_hcev;
            lobjTitle.IntRegistroEvento = tcrRegistro.Hcl_secreg_hcev;
            lobjTitle.txtTitulo.Text    = tcrRegistro.Hcl_nroreg_hcev + " - " + tcrRegistro.Hcl_desreg_hcev;
            lobjTitle.txtPrograma.Text  = lcrServicioFecha + " " + lcrServicioHora + " - " +tcrRegistro.Fcm_codcpr_cpro + " " + tcrRegistro.Fcm_descpr_cpro;
            lobjTitle.txtTexto1.Text = "Profesional: " + tcrRegistro.Sia_codpfa_prof + " " + tcrRegistro.Sia_nompro_prof;
            lobjTitle.txtTexto2.Text = "Registro de atención: " + tcrRegistro.Adm_secadm_rgad + " / " + tcrRegistro.Sis_despro_espr;
            #endregion

            return lobjTitle;
        }
        #endregion
        #region fcvHcVistaTileAdmisionFecha: Generar objeto titulo fecha grupo de eventos
        /// <summary>
        /// <para>Generar objeto titulo fecha grupo de eventos de una admision</para>
        /// </summary>
        public void fcvHcVistaTileAdmisionFecha(ref TileAdmision tobTileAdmision, ref HclModeloHistorialEventos tobRegEvento, String tcrTextoFecha)
        {
            if (tobTileAdmision != null)
            {
                var lcrCodigoAdmision = tobRegEvento.Adm_secadm_rgad;
                var ldaFechaServicio = tobRegEvento.Hcl_gesfec_hcev;
                ADMModeloTreeAdmHistorial lobRegEx = null;

                lobRegEx = XmlEntorno.tmpVistaHistAdmi.FirstOrDefault(x => x.Adm_secadm_rgad == lcrCodigoAdmision &&
                                                                           x.Hcl_gesfec_hcev == ldaFechaServicio && x.TipoRegistro == "DAT");
                if (lobRegEx == null)
                {
                    #region Cargar datos 
                    // Generar registro para triage sin admision
                    #region Crear el nuevo registro
                    lobRegEx = new ADMModeloTreeAdmHistorial();

                    lobRegEx.Adm_secadm_rgad    = tobRegEvento.Adm_secadm_rgad;
                    lobRegEx.Adm_fecadm_rgad    = Convert.ToDateTime("01/01/1000");
                    lobRegEx.Adm_horadm_rgad    = 1;
                    lobRegEx.Hcl_gesfec_hcev    = tobRegEvento.Hcl_gesfec_hcev;
                    lobRegEx.SecuencialRegistro = tobRegEvento.Hcl_nroreg_hcev;
                    lobRegEx.TipoRegistro       = "DAT";
                    lobRegEx.RegistroVisible    = "1";
                    lobRegEx.GestionEstadoRegistro = "OK";
                    #endregion
                    // Generar objeto Fecha
                    var lobRefObjFecha = new TileAdmisionFecha();
                    lobRefObjFecha.txtTitulo.Text = tcrTextoFecha;

                    lobRegEx.RefObjAdm = tobTileAdmision;
                    lobRegEx.RefObjFecha = lobRefObjFecha;

                    XmlEntorno.tmpVistaHistAdmi.Add(lobRegEx);
                    tobTileAdmision.stkHistorial.Children.Add(lobRefObjFecha);
                    #endregion
                }
            }
        }
        #endregion
        #region  fcvHcVistaAbrirDatosAdmisionActiva: Abrir datos admision activa en historial clinico del paciente
        /// <summary>
        /// Abrir datos admision activa en historial clinico del paciente
        /// </summary>
        private void fcvHcVistaAbrirDatosAdmisionActiva()
        {
            var lcrPacienteNombre   = String.Empty;
            var lcrPacienteId       = String.Empty;
            var lcrPacienteAdm      = String.Empty;
            var lcrPacienteDatMed   = String.Empty;
            var lcrEstadoGestion    = "2";

            if (!String.IsNullOrWhiteSpace(gcrParamIdAdmision))
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrParamIdAdmision);
                if (lobRegAdm.Count == 0) { return; }

                XmlEntorno.tmpRegAdmision            = lobRegAdm.FirstOrDefault();
                var lobReg                           = XmlEntorno.tmpRegAdmision;
                XmlEntorno.tmpUsuarioAtendido        = SIAModeloUsuariosAtendidos.flsListaSiausuarioatend(lobReg.Sia_idesec_usua).FirstOrDefault();
                XmlEntorno.glgNuevoRegistroPlantilla = XmlEntorno.tmpRegAdmision.Adm_estrad_rgad == "1" ? true : false;

                //Datos Usuario 
                gcrParamIdUnicoSistem   = lobReg.Sia_idesec_usua;
                lcrPacienteNombre       = lobReg.Sia_nomusu_usua;
                lcrPacienteId           = lobReg.Sia_tipide_tide + ": " + lobReg.Sia_nroide_usua.Trim() +
                                                " | SEXO: " + lobReg.Sis_dessex_sexo.Trim() + " | EDAD: " + lobReg.Sia_edaymd_usua;
                lcrPacienteDatMed = lobReg.Adm_estrad_rgad;

                // Datos de Admision
                lcrEstadoGestion = lobReg.Adm_finate_rgad;
                lcrPacienteAdm   = lobReg.Adm_secadm_rgad + " - " + lobReg.Adm_fecadm_rgad.ToShortDateString() + " - " +
                                           Funciones.fcrConvierteHora(lobReg.Adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":") + " - " +
                                           lobReg.Sis_despro_espr;
                fcvHcVistaValidarActivarPropiedades(lobReg);
            }
            else
            {
                // Cuando no hay admison activa, solo se muestran datos basicos del paciente
                if (XmlEntorno.gobRegHistorial != null)
                {
                    var lcrNumeroIde        = XmlEntorno.gobRegHistorial.Sia_idesec_usua;
                    gcrParamIdUnicoSistem   = lcrNumeroIde;

                    var tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(lcrNumeroIde);
                    if (tmp != null)
                    {
                        lcrPacienteNombre   = tmp.sia_nomusu_usua;
                        lcrPacienteId       = tmp.sia_tipide_tide + " - " + tmp.sia_nroide_usua;
                    }
                }
            }
            this.lblEscNombrePaciente.Text  = lcrPacienteNombre;
            this.lblEscIdentificacion.Text  = lcrPacienteId;
            this.lblEscAdmision.Text        = lcrPacienteAdm;
            this.lblEscDatosMedicos.Text    = lcrPacienteDatMed;
            // Vista en capa historial
            this.lblXEscNombrePaciente.Text = lcrPacienteNombre;
            this.lblXEscIdentificacion.Text = lcrPacienteId;
            this.lblXEscAdmision.Text       = lcrPacienteAdm;

            var lcrUri      = "/Sistema;component/Imagenes/";
            var lcrImagen   = lcrEstadoGestion == "1" ? "sis_edt_abierto.png" : "sis_edt_cerrado.png";
            this.imgAdmEdicion.Source = new BitmapImage(new Uri(lcrUri + lcrImagen, UriKind.RelativeOrAbsolute));
        }
        #endregion
        #region fcvHcVistaValidarActivarPropiedades: Activar vista propiedades cuando la admision esta abierta
        /// <summary>
        /// <para>Activar vista propiedades cuando la admision esta abierta para datos médicos</para>
        /// </summary>
        public void fcvHcVistaValidarActivarPropiedades(ADMModeloAdmadmisiones tobRegistro)
        {
            this.cmdPropideades.Visibility          = tobRegistro.Adm_estrad_rgad == "1" ? Visibility.Visible : Visibility.Collapsed;
            this.cmdEdtFinAtencion.Visibility       = Visibility.Collapsed;
            this.grdBuscarMenu.Visibility           = Visibility.Collapsed;
            vm.GlgSIS_PuedeFinAtencion = false;

            if (tobRegistro.Adm_estrad_rgad == "1")
            {

                // solo para finalizar atencion ambulatoria por ahora
                this.cmdEdtFinAtencion.Visibility   = tobRegistro.Sia_regate_rgat == "2" ? Visibility.Visible : Visibility.Collapsed;
                vm.GlgSIS_PuedeFinAtencion          = tobRegistro.Adm_estrad_rgad == "1" ? true : false;
                //vm.GlgSIS_PuedeFinAtencion = tobRegistro.Adm_ctarip_rgad == "2" ? true : false;
            }

            // desactivar grupos 
            if (tmpMenuActMedGru != null)
            {
                this.grdBuscarMenu.Visibility = tmpMenuActMedGru.Count > 0 ? Visibility.Visible : Visibility.Collapsed;

                foreach (var lobReg in tmpMenuActMedGru)
                {
                    var lobOpcion = lobReg.RefObjeto as ActividadesMedicasMenu;
                    if (lobOpcion != null)
                    {
                        lobOpcion.Visibility = Visibility.Collapsed;
                        // cuando esta abierta la atencion medica
                        if (tobRegistro.Adm_estrad_rgad == "1")
                        {
                            if (tobRegistro.Sia_regate_rgat == "1")
                            {
                                lobOpcion.Visibility = lobReg.Hcl_tipvis_hcra != "2" ? Visibility.Visible : Visibility.Collapsed;
                            }
                            else
                            {
                                lobOpcion.Visibility = lobReg.Hcl_tipvis_hcra != "1" ? Visibility.Visible : Visibility.Collapsed;
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region fcvHcVistaCmdModificarDatosUsuario: Modificar datos del usuario activo en hc
        /// <summary>
        /// Modificar datos del usuario activo en historia clinica
        /// </summary>
        private void fcvHcVistaCmdModificarDatosUsuario(object sender, System.EventArgs e)
        {
            var lcrIdUsuario = String.Empty;

            if (XmlEntorno.tmpRegAdmision != null)
            {
                lcrIdUsuario = XmlEntorno.tmpRegAdmision.Sia_idesec_usua;
            }
            else if (XmlEntorno.tmpUsuarioAtendido != null)
            {
                lcrIdUsuario = XmlEntorno.tmpUsuarioAtendido.Sia_idesec_usua;
            }
            else if (XmlEntorno.gobRegHistorial != null)
            {
                lcrIdUsuario = XmlEntorno.gobRegHistorial.Sia_idesec_usua;
            }

            if (!String.IsNullOrWhiteSpace(lcrIdUsuario))
            {
                VistaSiaUsuariosAtendidos lobSIA002 = new VistaSiaUsuariosAtendidos("DFL", lcrIdUsuario, "", "", "");
                lobSIA002.ShowDialog();
            }
        }
        #endregion
        #region fcvHcVistaButtonVistaAdmision: Activar vista detalles actividades de una admision
        /// <summary>
        /// <para>Activar vista detalles actividades de una admision</para>
        /// </summary>
        private void fcvHcVistaButtonVistaAdmision(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobTile = lobGrid.Parent as TileAdmision;

            var lobRegAdm = XmlEntorno.tmpVistaHistAdmi.FirstOrDefault(x => x.Adm_secadm_rgad == lobTile.RegistroAdmision && x.TipoRegistro == "ADM");
            if (lobRegAdm != null)
            {
                if (lobRegAdm.GestionEstadoRegistro=="XX")
                {
                    gcrParamIdAdmisionCarg = lobTile.RegistroAdmision;

                    // cargar vista detalles admision seleccionada
                    flgHcVistaHistorialCargarEventos();
                    gcrParamIdAdmisionCarg = String.Empty;
                }
            }
        }
        #endregion
        #region fcvHcVistaCmdDesplegarVistaAdmisiones: Desplegar todos los contenidos de amdisiones
        private void fcvHcVistaCmdDesplegarVistaAdmisiones(object sender, RoutedEventArgs e)
        {
            fcvHcVistaDesplegarHistorialAdmisiones("+");
        }
        #endregion
        #region fcvHcVistaCmdColapsarVistaAdmisiones: Colapsar todos los contenidos de amdisiones
        private void fcvHcVistaCmdColapsarVistaAdmisiones(object sender, RoutedEventArgs e)
        {
            fcvHcVistaDesplegarHistorialAdmisiones("-");
        }
        #endregion
        #region fcvHcVistaDesplegarHistorialAdmisiones: Desplegar o colapsar los detalles en vista historial admisiones 
        /// <summary>
        /// <para>Desplegar o colapsar los detalles en vista historial admisiones</para>
        /// tcrAccion: "+" = Desplegar  "-" = Colapsar
        /// </summary>
        public void fcvHcVistaDesplegarHistorialAdmisiones(String tcrAccion)
        {
            if (XmlEntorno.tmpVistaHistorial == null || XmlEntorno.tmpVistaHistorial.Count == 0) { return; }
            var lnuContNoCargados = 0;

            // Mostrar/ocultar titulos de grupos
            foreach (var lobReg in XmlEntorno.tmpVistaHistAdmi)
            {

                if (lobReg.TipoRegistro == "ADM")
                {
                    lobReg.RegistroVisible = "1";
                    var lobObjAdm = lobReg.RefObjAdm as TileAdmision;
                    if (lobObjAdm != null)
                    {
                        lobObjAdm.Visibility = Visibility.Visible;
                        lobObjAdm.fcvOpcActivarVistaDetalles(tcrAccion);
                        lnuContNoCargados = tcrAccion == "+" && lobReg.GestionEstadoRegistro == "XX" ? lnuContNoCargados + 1 : lnuContNoCargados;
                    }
                }
            }
            if (lnuContNoCargados > 0)
            {
                gcrParamIdAdmisionCarg = String.Empty;
                // cargar vista detalles todas las admisiones no cargadas
                flgHcVistaHistorialCargarEventos();
            }
        }
        #endregion
        //------------------------------------------------------------ 
        //- BARRA MENU SUPERIOR GUARDAR REGISTRO EN BASE DE DATOS
        //------------------------------------------------------------ 
        // Nuevo registro
        #region fcvPlantillaNueva: Crear Nuevo registro para historia clinica
        //- Crear Nueva Plantilla
        private void fcvPlantillaNueva(object sender, RoutedEventArgs e)
        {
            var lcrFiltro = "Grpmaeplantilla.grp_tipfor_grpl ='PLANTILLA' AND Grpmaeplantilla.sis_estreg_esrg ='1'";
            Browser01 frbro = new Browser01("GRP", "GRPMAEPLANTILLA", lcrFiltro, "Crear nuevo registro...");
            gcrCtrF2TexBox = "NUEVO";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        // Abrir registro / buscar otro paciente
        #region  fcvBrowserBuscarHClinica: buscar historias clinicas
        private void fcvBrowserBuscarHClinica(object sender, RoutedEventArgs e)
        {
            Browser02 frbro = new Browser02("HCL", "HCLMAESTROHISCL", 2, "1*TODOS", "Maestro de historias clínicas...");
            gcrCtrF2TexBox = "ABRIR";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        // Acciones: Guardar Confirmar y Anular
        #region fcvAccRegistroGuardar: Guardar registro activo sin confirmar
        private void fcvAccRegistroGuardar(object sender, RoutedEventArgs e)
        {
            //- iniciar barra de progreso 
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Guardando datos...", "CENTRO");
            lobDlgAdd.Show();

            if (XmlEntorno.flgBDatosGuardarRegistroDatos("1"))
            {
                lobDlgAdd.Close();
                // recargar historial si se add nuevo registro
                if (XmlEntorno.glgHistorialAddNuevoRegistro == true)
                {
                    // Para que se recargue el historial clinico 
                    gcrParamTipoId = gcrParamTipoIdBak;
                    gcrParamIdRegistro = gcrParamIdRegistroBak;
                }
                vm.TmpG1RegActivo = XmlEntorno.gobRegHistorialActivo;
                vm.fcvCargarVariablesDesdeRegActivo();
                MessageBox.Show("Datos guardados.");
            }
            else
            {
                lobDlgAdd.Close();
                MessageBox.Show("Error al guardar datos.");
            }
        }
        #endregion
        #region fcvAccRegistroConfirmar: Guardar registro activo y confirmar atencion
        private void fcvAccRegistroConfirmar(object sender, RoutedEventArgs e)
        {
            //- iniciar barra de progreso 
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Confirmando datos...", "CENTRO");
            lobDlgAdd.Show();

            if (XmlEntorno.flgBDatosGuardarRegistroDatos("2"))
            {
                lobDlgAdd.Close();
                // recargar historial si se add nuevo registro
                if (XmlEntorno.glgHistorialAddNuevoRegistro == true)
                {
                    // Para que se recargue el historial clinico 
                    gcrParamTipoId = gcrParamTipoIdBak;
                    gcrParamIdRegistro = gcrParamIdRegistroBak;
                }
                flgHistorialCargarVistaFormato(XmlEntorno.gcrIdRegHistorialEventoActivo);
                vm.TmpG1RegActivo = XmlEntorno.gobRegHistorialActivo;
                vm.fcvCargarVariablesDesdeRegActivo();

                // ACTIVAR EL BOTON FINALIZAR - ojo mejorar esto
                if (!String.IsNullOrWhiteSpace(gcrParamIdAdmision))
                {
                    var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrParamIdAdmision);
                    if (lobRegAdm.Count != 0)
                    {
                        var lobReg = lobRegAdm.FirstOrDefault();
                        vm.GlgSIS_PuedeFinAtencion = lobReg.Adm_ctarip_rgad == "2" ? true : false;
                    }
                }

            }
            else
            {
                lobDlgAdd.Close();
                MessageBox.Show("Error al confirmar datos.");
            }
        }
        #endregion
        // finalizar atencion medica ambulatoria
        #region fcvAccRegFinalizarAtencion: finalizar atencion medica ambulatoria
        private void fcvAccRegFinalizarAtencion(object sender, RoutedEventArgs e)
        {
            IAntencionAdmitidos lobRefEnlace = this.Owner as IAntencionAdmitidos;
            if (lobRefEnlace != null)
            {
                if (!String.IsNullOrWhiteSpace(gcrParamIdAdmision))
                {
                    if (HCLValidarCodigo.flgHclregiseventosAbiertos(gcrParamIdAdmision))
                    {
                        MessageBox.Show("Antes debe diligenciar y confirmar formatos de eventos medicos abiertos.");
                    }
                    else
                    {
                        if (lobRefEnlace.flgFinalizarAtencion(gcrParamIdAdmision))
                        {
                            // desactivar el boton finalizar
                            this.cmdEdtFinAtencion.Visibility = Visibility.Collapsed;
                            vm.GlgSIS_PuedeFinAtencion = false;
                        }
                    }
                }
            }
        }
        #endregion
        // Otras opciones
        #region fcvCmdTecladoVirtual: Mostrar teclado en pantalla
        private void fcvCmdTecladoVirtual(object sender, RoutedEventArgs e)
        {
            if (Process.GetProcessesByName("OSK").Length < 1)
            {
                Process.Start("osk.exe");
            }
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
        #region fcvCmdNavEscritorioVertical: Estilo navegacion escritorio Vertical
        private void fcvCmdNavEscritorioVertical(object sender, RoutedEventArgs e)
        {
            if (glgVistaNavEscritorioVertical == false)
            {
                glgVistaNavEscritorioVertical = true;
                fcvCmdOrientacionNavEscritorio();
            }
        }
        #endregion
        #region fcvCmdNavEscritorioHorizontal: Estilo navegacion escritorio Horizontal
        private void fcvCmdNavEscritorioHorizontal(object sender, RoutedEventArgs e)
        {
            if (glgVistaNavEscritorioVertical == true)
            {
                glgVistaNavEscritorioVertical = false;
                fcvCmdOrientacionNavEscritorio();
            }
        }
        #endregion
        #region fcvCmdOrientacionNavEscritorio: Orientacion navegacion en escritorio
        private void fcvCmdOrientacionNavEscritorio()
        {
            this.objSliderMargenHorizontal.Value = -250;
            if (glgVistaNavEscritorioVertical == true)
            {
                wraPlantilla.Orientation = Orientation.Vertical;
                this.objSliderMargenHorizontal.Minimum = -585;
                fcvNavEscritorioTouch();
            }
            else
            {
                this.objSliderMargenHorizontal.Minimum = 0;
                wraPlantilla.Orientation = Orientation.Horizontal;
                fcvNavEscritorioTouch();
            }
            fcvsetMargin();
        }
        #endregion
        #region fcvNavEscritorioTouch: Estilo navegacion tactil
        /// <summary>
        /// <para>Activa el Scroll de navegacion en el escritorio.</para>
        /// </summary>
        private void fcvNavEscritorioTouch()
        {
            this.stkBase.HorizontalAlignment = HorizontalAlignment.Center;
            this.stkBase.VerticalAlignment = VerticalAlignment.Center;
            if (glgVistaNavEscritorioVertical == true)
            {
                this.PanelScroll.PanningMode = PanningMode.VerticalOnly;
            }
            else
            {
                this.PanelScroll.PanningMode = PanningMode.HorizontalOnly;
            }
        }
        #endregion
        #region fcvAdicionarManejadorPaginasyZonas: Adicionar manejadores a paginas y zonas cargadas
        /// <summary>
        /// <para>Adicionar manejadores a paginas y zonas cargadas</para>
        /// <para>desde plantillas existentes o desde Deshacer / Rehacer </para>
        /// <para>tcrAccion: "+" = registrar eventos "-" = quitar eventos </para>
        /// </summary>
        public void fcvAdicionarManejadorPaginasyZonas(String tcrArchivoOrigen, String tcrAccion)
        {
            List<ClassXmlPropObjeto> tobTemp = XmlEntorno.fobRegSelectReferenciaArchivo(tcrArchivoOrigen);

            foreach (var lobItem in tobTemp)
            {
                #region Pagina
                if (lobItem.TipoObjeto == "PAGINA")
                {
                    Canvas lobPag = lobItem.RefObjeto as Canvas;
                    if (tcrAccion == "+")
                    {
                        lobPag.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                    }
                    else
                    {
                        lobPag.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                    }
                }
                #endregion
                #region Zona
                if (lobItem.TipoObjeto == "ZONA")
                {
                    GroupBox lobZona = lobItem.RefObjeto as GroupBox;
                    if (tcrAccion == "+")
                    {
                        lobZona.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                    }
                    else
                    {
                        lobZona.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                    }
                }
                #endregion
                #region TEXTBOXRELCOD
                if (lobItem.TipoObjeto == "TEXTBOXRELCOD")
                {
                    TextBox lobTextBoxRelcod = lobItem.RefObjeto as TextBox;
                    // aqui la llamada desde el boton
                    var lobObjBas = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobItem.Parent).FirstOrDefault();
                    var lobObjBtn = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "BUTTON", lobObjBas.Name).FirstOrDefault();
                    var lobButton = lobObjBtn.RefObjeto as Button;
                    if (tcrAccion == "+")
                    {
                        lobTextBoxRelcod.TextChanged += new TextChangedEventHandler(fcvValEdtCodigoTablaRelacion);
                        lobTextBoxRelcod.KeyDown += new KeyEventHandler(fcvSeleccionKeyDown);
                        lobButton.Click += new RoutedEventHandler(fcvSeleccionClickButton);
                    }
                    else
                    {
                        lobTextBoxRelcod.TextChanged -= new TextChangedEventHandler(fcvValEdtCodigoTablaRelacion);
                        lobTextBoxRelcod.KeyDown -= new KeyEventHandler(fcvSeleccionKeyDown);
                        lobButton.Click -= new RoutedEventHandler(fcvSeleccionClickButton);
                    }

                }
                #endregion
                #region CONTROLCAPTURA
                if (lobItem.TipoObjeto == "CONTROLCAPTURA")
                {
                    ControlCaptura lobControlCaptura = lobItem.RefObjeto as ControlCaptura;
                    // aqui la llamada desde el boton
                    if (tcrAccion == "+")
                    {
                        lobControlCaptura.cmdAdicionar.Click += new RoutedEventHandler(fcvSeleccionTipoCaptura);
                        lobControlCaptura.cmdConfirmar.Click += new RoutedEventHandler(fcvConfirmarRegistroTipoCaptura);
                        gobCtrControlCaptura = lobControlCaptura;
                    }
                    else
                    {
                        lobControlCaptura.cmdAdicionar.Click -= new RoutedEventHandler(fcvSeleccionTipoCaptura);
                        lobControlCaptura.cmdConfirmar.Click -= new RoutedEventHandler(fcvConfirmarRegistroTipoCaptura);
                        gobCtrControlCaptura = null;
                    }
                }
                #endregion
                #region MULTIRADIOBUTTON
                if (lobItem.TipoObjeto == "MULTIRADIOBUTTON")
                {
                    if (XmlEntorno.gcrDatosModoVista != "V")
                    {
                        RadioButton lobRadioButton = lobItem.RefObjeto as RadioButton;
                        if (tcrAccion == "+")
                        {
                            lobRadioButton.Click += new RoutedEventHandler(fcvValEdtRadioButton);
                        }
                        else
                        {
                            lobRadioButton.Click -= new RoutedEventHandler(fcvValEdtRadioButton);
                        }
                    }
                }
                #endregion
                #region TEXTBOX
                if (lobItem.TipoObjeto == "TEXTBOX")
                {
                    TextBox lobTextBox = lobItem.RefObjeto as TextBox;
                    if (tcrAccion == "+")
                    {
                        lobTextBox.TextChanged += new TextChangedEventHandler(fcvValEdtTextBox);
                        lobTextBox.KeyDown += new KeyEventHandler(fcvMoverFocusTextBox_KeyDown);
                        lobTextBox.TouchEnter += new EventHandler<TouchEventArgs>(fcvTouchEnterTeclado);
                    }
                    else
                    {
                        lobTextBox.TextChanged -= new TextChangedEventHandler(fcvValEdtTextBox);
                        lobTextBox.KeyDown -= new KeyEventHandler(fcvMoverFocusTextBox_KeyDown);
                        lobTextBox.TouchEnter -= new EventHandler<TouchEventArgs>(fcvTouchEnterTeclado);
                    }
                }
                #endregion
                #region RICHTEXTBOX
                if (lobItem.TipoObjeto == "RICHTEXTBOX")
                {
                    RichTextBox lobRichTextBox = lobItem.RefObjeto as RichTextBox;
                    if (tcrAccion == "+")
                    {
                        lobRichTextBox.TextChanged += new TextChangedEventHandler(fcvValEdtRichTextBox);
                        lobRichTextBox.TouchEnter += new EventHandler<TouchEventArgs>(fcvTouchEnterTeclado);
                    }
                    else
                    {
                        lobRichTextBox.TextChanged -= new TextChangedEventHandler(fcvValEdtRichTextBox);
                        lobRichTextBox.TouchEnter -= new EventHandler<TouchEventArgs>(fcvTouchEnterTeclado);
                    }
                }
                #endregion
                #region TEXTBOXDATE
                if (lobItem.TipoObjeto == "TEXTBOXDATE")
                {
                    if (XmlEntorno.gcrDatosModoVista != "V")
                    {
                        ControlFecha lobTextBoxFecha = lobItem.RefObjeto as ControlFecha;
                        if (tcrAccion == "+")
                        {
                            lobTextBoxFecha.txtFechaVista.TextChanged += new TextChangedEventHandler(fcvValEdtTextBoxFecha);
                            lobTextBoxFecha.txtFechaVista.KeyDown += new KeyEventHandler(fcvMoverFocusTextBox_KeyDown);
                        }
                        else
                        {
                            lobTextBoxFecha.txtFechaVista.TextChanged -= new TextChangedEventHandler(fcvValEdtTextBoxFecha);
                            lobTextBoxFecha.txtFechaVista.KeyDown -= new KeyEventHandler(fcvMoverFocusTextBox_KeyDown);
                        }
                    }
                }
                #endregion
                #region TEXTBOXTIME
                if (lobItem.TipoObjeto == "TEXTBOXTIME")
                {
                    if (XmlEntorno.gcrDatosModoVista != "V")
                    {
                        ControlHora lobTextBoxHora = lobItem.RefObjeto as ControlHora;
                        if (tcrAccion == "+")
                        {
                            lobTextBoxHora.txtHoraVista.TextChanged += new TextChangedEventHandler(fcvValEdtTextBoxHora);
                            lobTextBoxHora.txtHoraVista.KeyDown += new KeyEventHandler(fcvMoverFocusTextBox_KeyDown);
                        }
                        else
                        {
                            lobTextBoxHora.txtHoraVista.TextChanged -= new TextChangedEventHandler(fcvValEdtTextBoxHora);
                            lobTextBoxHora.txtHoraVista.KeyDown -= new KeyEventHandler(fcvMoverFocusTextBox_KeyDown);
                        }
                    }
                }
                #endregion
                #region COMBOBOX
                if (lobItem.TipoObjeto == "COMBOBOX")
                {
                    if (XmlEntorno.gcrDatosModoVista != "V")
                    {
                        ComboBox lobComboBox = lobItem.RefObjeto as ComboBox;
                        if (tcrAccion == "+")
                        {
                            lobComboBox.SelectionChanged += new SelectionChangedEventHandler(fcvValEdtComboBox);
                            lobComboBox.KeyDown += new KeyEventHandler(fcvMoverFocusComboBox_KeyDown);
                        }
                        else
                        {
                            lobComboBox.SelectionChanged -= new SelectionChangedEventHandler(fcvValEdtComboBox);
                            lobComboBox.KeyDown -= new KeyEventHandler(fcvMoverFocusComboBox_KeyDown);
                        }
                    }
                }
                #endregion
                #region MULTICHKBOX
                if (lobItem.TipoObjeto == "MULTICHKBOX")
                {
                    if (XmlEntorno.gcrDatosModoVista != "V")
                    {
                        CheckBox lobCheckBox = lobItem.RefObjeto as CheckBox;
                        if (tcrAccion == "+")
                        {
                            lobCheckBox.Click += new RoutedEventHandler(fcvValEdtCheckBox);
                        }
                        else
                        {
                            lobCheckBox.Click -= new RoutedEventHandler(fcvValEdtCheckBox);
                        }
                    }
                }
                #endregion
                #region DIFERENTES DE PAGINA
                if (lobItem.TipoObjeto != "PAGINA")
                {
                    fcvMajenadorSizeChanged(lobItem, lobItem.ClaseBase, tcrAccion);
                }
                #endregion
                #region Referencia al control Test de FramingHam
                if (lobItem.TipoObjeto == "CONTROLFRAMINGHAM")
                {
                    gobCrtFrmg = lobItem.RefObjeto as ControlVistaFramingHam;
                    gobCrtFrmgReg = lobItem;

                    if (gobCrtIMC != null)
                    {
                        gobCrtFrmg.gobRefIMC = gobCrtIMC;
                    }

                }
                #endregion
                #region Referencia al control IMC - Indice de masa corporal
                if (lobItem.TipoObjeto == "CONTROLIMC")
                {
                    gobCrtIMC = lobItem.RefObjeto as ControlVistaImc;
                    gobCrtIMCReg = lobItem;

                    if (gobCrtFrmg != null)
                    {
                        gobCrtFrmg.gobRefIMC = gobCrtIMC;
                    }
                }
                #endregion
                #region Referencia al control Test Audicion lenguaje
                if (lobItem.TipoObjeto == "CONTROLEADAUDICIONLENGUAJE")
                {
                    gobCrtEadAl = lobItem.RefObjeto as ControlEscalaEadAudicionLenguage;
                    gobCrtEadAlReg = lobItem;

                }
                #endregion
                #region Referencia al control Test Mutricidad fina
                if (lobItem.TipoObjeto == "CONTROLEADMOTRICIFINOADAPT")
                {
                    gobCrtEadMf = lobItem.RefObjeto as ControlEscalaEadMotriFinoAdaptativa;
                    gobCrtEadMfReg = lobItem;

                }
                #endregion
                #region Referencia al control Test Mutricidad gruesa
                if (lobItem.TipoObjeto == "CONTROLEADMOTRICIGRUESA")
                {
                    gobCrtEadMg = lobItem.RefObjeto as ControlEscalaEadMotricidadGruesa;
                    gobCrtEadMgReg = lobItem;

                }
                #endregion
                #region Referencia al control Test Personal social
                if (lobItem.TipoObjeto == "CONTROLEADPERSONALSOCIAL")
                {
                    gobCrtEadPs = lobItem.RefObjeto as ControlEscalaEadPersonalSocial;
                    gobCrtEadPsReg = lobItem;

                }
                #endregion
                #region Referencia al control Test Escala Puntuacion
                if (lobItem.TipoObjeto == "CONTROLEADGRAFPUNTUACION")
                {
                    gobCrtEadPu = lobItem.RefObjeto as ControlVistaEscalaEadPuntuacion;
                    gobCrtEadPuReg = lobItem;

                }
                #endregion
            }
            // cuando hay IMC buscar referencias a objetos asociados con variables publicas 
            #region Referencia al control IMC - Indice de masa corporal
            if (gobCrtIMC != null)
            {
                foreach (var lobItem in tobTemp)
                {
                    // Referencia  PESO - TALLA -IMC
                    if (lobItem.TipoObjeto == "TEXTBOX")
                    {
                        var lcrVar = lobItem.VariablePublica;

                        #region Referencia Objeto Peso
                        // Peso => TRIAGE_PESO_CORPORAL_EN_KILOG/EXAMFISICO_EXP_FISICO_PESO/EXAMFISC_PESO_URGENCIA/MATERPERI_PESO_MPTL/ATENRNACID_GRAMO_PESO_AL_NACER
                        if (lcrVar == "TRIAGE_PESO_CORPORAL_EN_KILOG" || 
                            lcrVar == "EXAMFISICO_EXP_FISICO_PESO" ||
                            lcrVar == "EXAMFISC_PESO_URGENCIA" || 
                            lcrVar == "MATERPERI_PESO_MPTL" ||
                            lcrVar == "ATENRNACID_GRAMO_PESO_AL_NACER")
                        {
                            gobCrtIMC.gobRefPeso = lobItem.RefObjeto as TextBox;
                        }
                        #endregion
                        #region Referencia Objeto Talla
                        // Talla => TRIAGE_TALLA_EN_CENTIMETROS/EXAMFISICO_EXP_FISICO_TALLA/EXAMFISC_TALLA_URGENCIA/MATERPERI_TALLA_MPTL/ATENRNACID_TALLA_CENTIMETROS
                        if (lcrVar == "TRIAGE_TALLA_EN_CENTIMETROS" ||
                            lcrVar == "EXAMFISICO_EXP_FISICO_TALLA" ||
                            lcrVar == "EXAMFISC_TALLA_URGENCIA" ||
                            lcrVar == "MATERPERI_TALLA_MPTL" ||
                            lcrVar == "ATENRNACID_TALLA_CENTIMETROS")
                        {
                            gobCrtIMC.gobRefTalla = lobItem.RefObjeto as TextBox;
                        }
                        #endregion
                        #region Referencia Objeto IMC
                        // IMC => EXAMFISICO_EXP_FISICO_IMC/EXAMFISC_IMC_URGINCIA/MATERPERI_IMC_MPTL
                        if (lcrVar == "EXAMFISICO_EXP_FISICO_IMC" ||
                            lcrVar == "EXAMFISC_IMC_URGINCIA" ||
                            lcrVar == "MATERPERI_IMC_MPTL")
                        {
                            gobCrtIMC.gobRefImc = lobItem.RefObjeto as TextBox;
                        }
                        #endregion
                    }
                }
            }
            #endregion
        }
        #region fcvMajenadorSizeChanged: Asignar el manejador SizeChangedEventHandler a los objetos
        /// <summary>
        /// <para>Asignar el manejador SizeChangedEventHandler a los objetos, para que puedan reportar el</para>
        /// <para>cambio de tamaño a las propiedades correspondientes, cuando son ajustados con mouse</para>
        /// <para>tcrAccion: "+" = registrar eventos "-" = quitar eventos </para>
        /// </summary>
        public void fcvMajenadorSizeChanged(ClassXmlPropObjeto tobRefObjeto, String tcrTipoObjeto, String tcrAccion)
        {
            var lobRefObjeto = tobRefObjeto.RefObjeto;
            if (lobRefObjeto != null)
            {
                #region Condiciones
                switch (tcrTipoObjeto.ToUpper())
                {
                    case "TEXTBOX":
                        TextBox lobjTextBox = lobRefObjeto as TextBox;
                        if (tcrAccion == "+")
                        {
                            lobjTextBox.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        else
                        {
                            lobjTextBox.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        break;

                    case "RICHTEXTBOX":
                        RichTextBox lobjRichTextBox = lobRefObjeto as RichTextBox;
                        if (tcrAccion == "+")
                        {
                            lobjRichTextBox.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        else
                        {
                            lobjRichTextBox.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        break;

                    case "COMBOBOX":
                        if (XmlEntorno.gcrDatosModoVista != "V")
                        {
                            ComboBox lobjComboBox = lobRefObjeto as ComboBox;
                            lobjComboBox.SelectedValuePath = "Codigo";
                            lobjComboBox.DisplayMemberPath = "Descripcion";
                            lobjComboBox.ItemsSource = XmlEntorno.fobRegSelectParenComboBoxItems("PARENT", tobRefObjeto.Name);
                            if (tcrAccion == "+")
                            {
                                lobjComboBox.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            }
                            else
                            {
                                lobjComboBox.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            }
                        }
                        break;

                    case "TEXTBLOCK":
                        TextBlock lobjTextBlock = lobRefObjeto as TextBlock;
                        if (tcrAccion == "+")
                        {
                            lobjTextBlock.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjTextBlock.MouseDown += new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        else
                        {
                            lobjTextBlock.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjTextBlock.MouseDown -= new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        break;

                    case "RADIOBUTTON":
                        if (XmlEntorno.gcrDatosModoVista != "V")
                        {
                            RadioButton lobjRadioButton = lobRefObjeto as RadioButton;
                            if (tcrAccion == "+")
                            {
                                lobjRadioButton.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            }
                            else
                            {
                                lobjRadioButton.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            }
                        }
                        break;

                    case "CHECKBOX":
                        if (XmlEntorno.gcrDatosModoVista != "V")
                        {
                            CheckBox lobjCheckBox = lobRefObjeto as CheckBox;
                            if (tcrAccion == "+")
                            {
                                lobjCheckBox.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            }
                            else
                            {
                                lobjCheckBox.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            }
                        }
                        break;

                    case "CANVAS":
                        Canvas lobjCanvas = lobRefObjeto as Canvas;
                        if (tcrAccion == "+")
                        {
                            lobjCanvas.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        else
                        {
                            lobjCanvas.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        break;

                    case "BUTTON":
                        Button lobjButton = lobRefObjeto as Button;
                        if (tcrAccion == "+")
                        {
                            lobjButton.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        else
                        {
                            lobjButton.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        break;

                    case "GROUPBOX":
                        GroupBox lobjGroupBox = lobRefObjeto as GroupBox;
                        if (tcrAccion == "+")
                        {
                            lobjGroupBox.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        else
                        {
                            lobjGroupBox.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        break;

                    case "IMAGE":
                        Image lobjImage = lobRefObjeto as Image;
                        if (tcrAccion == "+")
                        {
                            lobjImage.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjImage.MouseDown += new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        else
                        {
                            lobjImage.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjImage.MouseDown -= new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        break;

                    case "RECTANGLE":
                        System.Windows.Shapes.Rectangle lobjRectangle = lobRefObjeto as System.Windows.Shapes.Rectangle;
                        if (tcrAccion == "+")
                        {
                            lobjRectangle.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjRectangle.MouseDown += new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        else
                        {
                            lobjRectangle.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjRectangle.MouseDown -= new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        break;

                    case "ELLIPSE":
                        System.Windows.Shapes.Ellipse lobjEllipse = lobRefObjeto as System.Windows.Shapes.Ellipse;
                        if (tcrAccion == "+")
                        {
                            lobjEllipse.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjEllipse.MouseDown += new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        else
                        {
                            lobjEllipse.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjEllipse.MouseDown -= new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        break;

                    case "POLYLINE":
                        System.Windows.Shapes.Polyline lobjPolyline = lobRefObjeto as System.Windows.Shapes.Polyline;
                        if (tcrAccion == "+")
                        {
                            lobjPolyline.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjPolyline.MouseDown += new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        else
                        {
                            lobjPolyline.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjPolyline.MouseDown -= new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        break;

                    case "POLYGON":
                        System.Windows.Shapes.Polygon lobjPolygon = lobRefObjeto as System.Windows.Shapes.Polygon;
                        if (tcrAccion == "+")
                        {
                            lobjPolygon.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjPolygon.MouseDown += new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        else
                        {
                            lobjPolygon.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjPolygon.MouseDown -= new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        break;

                    case "LINE":
                        System.Windows.Shapes.Line lobjLine = lobRefObjeto as System.Windows.Shapes.Line;
                        if (tcrAccion == "+")
                        {
                            lobjLine.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjLine.MouseDown += new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        else
                        {
                            lobjLine.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                            if (tobRefObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                lobjLine.MouseDown -= new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                            }
                        }
                        break;
                }
                #endregion
            }
        }
        #endregion
        #region KeyDown y GotFocus General
        /// <summary>
        /// <para>KeyDown y GotFocus General para todo los objetos que reciben enfoque</para>
        /// </summary>
        private void fcvMoverFocusTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }
        private void fcvMoverFocusComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((ComboBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }
        private void fcvTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.Source as TextBox;
            tb.SelectAll();
        }
        #endregion
        #endregion
        #region fcvSliderMargenZoomVista: Ajustar la vista del Zoom
        /// <summary>
        /// <para>Ajustar margenes superio zoom vista navegacion.</para>
        /// </summary>
        private void fcvSliderMargenZoomVista(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //var lobj = (Slider)sender;
            if (glgObjetosCargados == true)
            {
                fcvsetMargin();
            }
        }
        private void fcvsetMargin()
        {
            var lduVertical = this.objSliderMargenVertical.Value;
            var lduHorizontal = this.objSliderMargenHorizontal.Value;
            this.stkBase.Margin = new Thickness(lduHorizontal, lduVertical, 0, 0);
        }
        #endregion
        #region fcvCmdAddImagenesPredefinidas: Adicionar objetos para  galeria de imagenes predefinidas
        /// <summary>
        /// <para>Adicionar objetos para  galeria de imagenes predefinidas</para>
        /// <para>tcrAccion: "+" = registrar eventos "-" = quitar eventos </para>
        /// </summary>
        public void fcvCmdAddImagenesPredefinidas(String tcrAccion)
        {
            if (XmlEntorno.tmpImagenesPredef == null) { return; }

            foreach (var lobItem in XmlEntorno.tmpImagenesPredef)
            {
                if (tcrAccion == "+")
                {
                    var lobBoton = new TileImgPredefinidas();
                    lobBoton.fcvCargarVista(oApp.gcrAppRecursoIpServidor, oApp.gcrAppRecursoInicioPath, lobItem);
                    lobBoton.cmdAccion.Click += new RoutedEventHandler(fcvCmdAddImagenPredefinida);
                    lobItem.RefObjeto = lobBoton;
                    this.wraImgPredefinidas.Children.Add(lobBoton);
                }
                else
                {
                    TileImgPredefinidas lobRefe = lobItem.RefObjeto as TileImgPredefinidas;
                    lobRefe.cmdAccion.Click -= new RoutedEventHandler(fcvCmdAddImagenPredefinida);
                }
            }
            if (tcrAccion == "-")
            {
                this.wraImgPredefinidas.Children.Clear();
            }
        }
        #endregion
        #region fcvSliderZoomScroll: Ajustar la vista del Zoom para mostrar scroll
        /// <summary>
        /// <para>Ajustar la vista del Zoom para mostrar scroll.</para>
        /// </summary>
        private void fcvSliderZoomScroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //var lobj = (Slider)sender;
            if (glgObjetosCargados == true)
            {
                fcvSetValorZoomScroll();
            }
        }
        #endregion
        #region fcvSetValorZoomScroll: Aplica los valores a la vista Zoom
        /// <summary>
        /// <para>Aplica los valores a la vista Zoom</para>
        /// </summary>
        private void fcvSetValorZoomScroll()
        {
            var lduValor = this.objSliderZoom.Value;
            if (gduBaseZoomVertical == 0)
            {
                fcvGetValorBaseZoomScroll("GET");
            }
            if (gduBaseZoomSlider >= this.objSliderZoom.Value)
            {
                // restablecer valores base
                this.stkContenedor.Height = gduBaseZoomVertical;
                this.stkContenedor.Width = gduBaseZoomHorizontal;
            }
            else
            {
                //this.stkContenedor.Width = (gduBaseZoomHorizontal * (lduValor + 0.001));
                this.stkContenedor.Height = (gduBaseZoomVertical * (lduValor + 0.5));
            }
        }
        #endregion
        #region fcvGetValorBaseZoomScroll: Toma los valores base de alto y ancho para mostrar barras de scroll e zoom
        /// <summary>
        /// <para>Toma los valores base de alto y ancho para mostrar barras de scroll en Zoom.</para>
        /// <para>SET = Valores en Cero GET = Valores desde Objeto</para>
        /// </summary>
        private void fcvGetValorBaseZoomScroll(String tcrModo)
        {
            gduBaseZoomVertical = this.stkContenedor.ActualHeight;
            gduBaseZoomHorizontal = this.stkContenedor.ActualWidth;

            if (tcrModo == "SET")
            {
                this.PanelScroll.ScrollToTop();
                double lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 96.8;
                this.stkContenedor.Height = (lduHeight * 20);
                gduBaseZoomVertical = 0;
                gduBaseZoomHorizontal = 0;
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // GESTION ARRASTRAR OBJETOS Y ADORNOS
        //------------------------------------------------------------
        #region Gestion Arrastrar Objetos y Adornos
        #region fcvPreViewClicSeleccionObjeto : Selecciona el objeto clickeado o adiciona nuevo objeto
        /// <summary>
        ///  fcvPreViewClicSeleccionObjeto: PreviewMouseLeftButtonDown, Selecciona el objeto clickeado
        /// <para>o adiciona nuevo objeto. Guarda valores e inicia las Variables al seleccionar un objeto,</para>
        /// <para>remueve cualquier seleccion anterior de algun otro objeto. </para>
        /// <para>Coloca los adornos al objeto seleccionado. </para>
        /// </summary>
        void fcvPreViewClicSeleccionObjeto(object sender, MouseButtonEventArgs e)
        {
            gnuAnimContTouchDownHX++;
            if (gnuAnimContTouchDownHX > 1) // doble clic en mo
            {
                gnuAnimContTouchDownHX = 0;
                fcvVerDatosEtiquetaSelect(true);
            }
            else
            {
                fcvNavEscritorioTouch();
                this.stkPropBasicas.Visibility = Visibility.Hidden;
                fcvAddRemoveManejadorZona("DEL");
                fcvRemoverAdornos(); //Remover seleccion de algun objeto anterior
                FrameworkElement luiRefObjetoClic = e.Source as FrameworkElement;

                if (luiRefObjetoClic != null)
                {
                    var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", luiRefObjetoClic.Name).FirstOrDefault();
                    fcvArbolReferenciaSelectObjetoClik(sender, e);
                    vm.gobRefObjeto = null;
                    vm.gobRefPagina = null;

                    // Verificar que sea una etiqueta con datos
                    if (lobObjeto != null) { fcvVerificarEtiquetaConDatos(e.Source as UIElement, lobObjeto.Navegador); }

                    // Adicionar objeto en una zona
                    if (glgNuevoObjetoCrear == true && gcrTipoObjetoNivel != "PAGINA")
                    {
                        fcvAdicionarObjetosEnPagina();
                    }
                    else if (glgNuevoObjetoCrear != true && gcrTipoObjetoNivel != "PAGINA" && lobObjeto != null) // Solo es seleccion para colocar adornos 
                    {
                        #region seleccion de Objeto ya existente
                        // Seleccionar el objeto clickeado y colocar adornos
                        if (e.Source != gobRefPaginaSeleccionada && e.Source != gobRefContenedorPaginaSeleccionada) // Contenedor principal
                        {
                            guiRefObjetoSeleccionado = e.Source as UIElement;
                            if (gcrTipoObjetoNivel == "ZONA") // Una Zona de la pagina
                            {
                                guiRefObjetoSeleccionado = gobRefZonaSeleccionada;
                                gptPuntoDeInicio = e.GetPosition(gobRefPaginaSeleccionada);
                            }
                            else if (gcrTipoObjetoNivel == "GRUPO") // un objeto Grupo
                            {
                                guiRefObjetoSeleccionado = gobRefGrupoSeleccionado;
                                gptPuntoDeInicio = e.GetPosition(gobRefContenedorZonaSeleccionada);
                            }
                            else if (gcrTipoObjetoNivel == "ZONA-OBJETO") // Objeto dentro de la Zona
                            {
                                gptPuntoDeInicio = e.GetPosition(gobRefContenedorZonaSeleccionada);
                            }
                            else if (gcrTipoObjetoNivel == "GRUPO-OBJETO") // Objeto dentro de Grupo
                            {
                                gptPuntoDeInicio = e.GetPosition(gobRefContenedorGrupoSeleccionado);
                            }
                            gduObjetoInicialLeft = Canvas.GetLeft(guiRefObjetoSeleccionado);
                            gduObjetoInicialTop = Canvas.GetTop(guiRefObjetoSeleccionado);

                            // Maenajdor y Propiedades
                            vm.gobRefObjeto = guiRefObjetoSeleccionado; // informar a vistamodelo
                            vm.gobRefPagina = gobRefPaginaSeleccionada;

                            if (lobObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                            {
                                this.PanelScroll.PanningMode = PanningMode.None;
                                this.stkPropBasicas.Visibility = Visibility.Visible;
                                glgModoArrastrarObjeto = true;
                                fcvAddRemoveManejadorZona("ADD");
                                luxUIAgregarAdorno = null;
                                luxUIAgregarAdorno = AdornerLayer.GetAdornerLayer(guiRefObjetoSeleccionado);
                                luxUIAgregarAdorno.Add(new Utilidades.AddResizingAdornos(guiRefObjetoSeleccionado, gduTamañoAdornos));
                                fcvGetObjActivarPropiedades();
                                e.Handled = true;
                            }
                            glgSiObjetoSeleccionado = true;
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion
        #region fcvVerificarEtiquetaConDatos : al hacer click Verificar que sea una etiqueta con datos
        /// <summary>
        /// <para>Verificar que sea una etiqieta con datos al hacer click sobre el objeto</para>
        /// <para>Si la capa etiqueta esta activa, solo refrescar la vista del contenido</para>
        /// </summary>
        void fcvVerificarEtiquetaConDatos(UIElement tobObjeto, String tcrNavegador)
        {
            this.cmdEtiqueta.IsEnabled = true;
            if (!flgVerificarEtiquetaSelect(tobObjeto))
            {
                if (tcrNavegador == "ESCRITORIO")
                {
                    fcvActivarVistaEtiquetaEstado(false);
                    this.cmdEtiqueta.IsEnabled = false;
                }
            }
            else
            {
                if (glgVistaEtiquetaEstadoVisible == true)
                {
                    if (tcrNavegador == "ESCRITORIO")
                    {
                        fcvVerDatosEtiquetaSelect(true);
                    }
                }
            }
        }
        #endregion
        #region fcvQuitarAdornoObjetoMouseLeftButtonDown : Quitar los adornos a un objeto que pierde el enfoque
        /// <summary>
        /// fcvQuitarAdornoObjetoMouseLeftButtonDown : Quitar los adornos a un objeto que pierde
        /// el enfoque 
        /// </summary>
        void fcvQuitarAdornoObjetoMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (glgSiObjetoSeleccionado)
            {
                glgSiObjetoSeleccionado = false;
                if (guiRefObjetoSeleccionado != null)
                {
                    var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", ((FrameworkElement)guiRefObjetoSeleccionado).Name).FirstOrDefault();
                    if (lobObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                    {
                        luxUIAgregarAdorno.Remove(luxUIAgregarAdorno.GetAdorners(guiRefObjetoSeleccionado)[0]);
                    }
                    guiRefObjetoSeleccionado = null;
                }
            }
        }
        #endregion
        #region fcvFinalizaDragMouseManejador : Finalizar Manejador cuando el mouse abandona la zona de objetos
        /// <summary>
        /// <para>Finalizar Manejador cuando el mouse abandona la zona del Canvas,</para>
        /// <para>se llama a la funcion fcvFinalizarArrasteAlSoltarMouse() para finalizar el manejador desde el mouse.</para>
        /// </summary>
        void fcvFinalizaDragMouseManejador(object sender, MouseButtonEventArgs e)
        {
            fcvFinalizarArrasteAlSoltarMouse();
            e.Handled = true;
        }
        #endregion
        #region fcvFinalizaDragManejadorTouchUp: Finalizar Manejador cuando finaliza el touch en zona de objetos
        /// <summary>
        /// <para>Gestión Touch</para>
        /// <para>Finalizar Manejador cuando finaliza el touch en zona de objetos</para>
        /// </summary>
        private void fcvFinalizaDragManejadorTouchUp(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            if (glgModoArrastrarObjeto)
            {
                fcvFinalizarArrasteAlSoltarMouse();
            }
            e.Handled = true;
        }
        #endregion
        #region fcvFinalizarArrasteAlSoltarMouse : Finalizar arrastre al soltar el mouse
        /// <summary>
        /// fcvFinalizarArrasteAlSoltarMouse: Funcion para Finalizar la accion de Arrastrar,
        /// <para>al soltar el boton del mouse, esta funcion coloca las variables: </para> 
        /// <para>glgModoArrastrarObjeto, glgAccionArrastrandoObjeto en FALSE</para> 
        /// </summary>
        private void fcvFinalizarArrasteAlSoltarMouse()
        {
            if (glgModoArrastrarObjeto)
            {
                glgModoArrastrarObjeto = false;
                glgAccionArrastrandoObjeto = false;
            }
        }
        #endregion
        #region fcvEventoMoverMouseEnZona : Detecta el movimiento del Mouse dentro de la zona
        /// <summary>
        /// <para> fcvEventoMoverMouseEnZona: Detecta el movimiento del Mouse dentro de la zona.</para>
        /// <para> Provee la operacion arrastre del objeto seleccionado.</para>
        /// <para> Esta funcion detectar el movimiento del mouse dentro la zona que valida par gestion objetos. </para>
        /// <para> Verifica que la posicion del mouse este dentro de la zona valida para arrastrar o colocar objetos, </para>
        /// <para> se cambia el estado de la variable glgAccionArrastrandoObjeto  a verdadero y se reasigana la posicion del objeto</para>
        /// <para> que este siendo arrastrado. </para>
        /// </summary>
        void fcvEventoMoverMouseEnZona(object sender, MouseEventArgs e)
        {
            if (glgModoArrastrarObjeto)
            {
                // Verificar la referencia al contenedor relativo Zona o Pagina
                Canvas lobRefContenedor = gobRefContenedorZonaSeleccionada;
                FrameworkElement luiRefObjetoMouse = e.Source as FrameworkElement;

                if (gcrTipoObjetoNivel == "ZONA") // Una Zona de la pagina
                {
                    lobRefContenedor = gobRefPaginaSeleccionada;
                }
                else if (gcrTipoObjetoNivel == "GRUPO") // Objeto Grupo
                {
                    lobRefContenedor = gobRefContenedorZonaSeleccionada;
                }
                else if (gcrTipoObjetoNivel == "ZONA-OBJETO") // Objeto dentro de la Zona
                {
                    lobRefContenedor = gobRefContenedorZonaSeleccionada;
                }
                else if (gcrTipoObjetoNivel == "GRUPO-OBJETO") // Objeto dentro de Grupo
                {
                    lobRefContenedor = gobRefContenedorGrupoSeleccionado;
                }
                //
                if ((glgAccionArrastrandoObjeto == false) &&
                    ((Math.Abs(e.GetPosition(lobRefContenedor).X - gptPuntoDeInicio.X) > SystemParameters.MinimumHorizontalDragDistance) ||
                    (Math.Abs(e.GetPosition(lobRefContenedor).Y - gptPuntoDeInicio.Y) > SystemParameters.MinimumVerticalDragDistance)))
                    glgAccionArrastrandoObjeto = true;

                if (glgAccionArrastrandoObjeto)
                {
                    Point position = Mouse.GetPosition(lobRefContenedor);
                    Canvas.SetTop(guiRefObjetoSeleccionado, position.Y - (gptPuntoDeInicio.Y - gduObjetoInicialTop));
                    Canvas.SetLeft(guiRefObjetoSeleccionado, position.X - (gptPuntoDeInicio.X - gduObjetoInicialLeft));
                    fcvGetObjPropiedadesReSizeObjeto();
                }
            }
        }
        #endregion
        #region fcvEventoMoverMouseFueraDeZona : Detecta el movimiento del Mouse fuera de la zona
        /// <summary>
        /// <para>fcvEventoMoverMouseFueraDeZona: viene de MouseLeave, llama a la funcion fcvFinalizarArrasteAlSoltarMouse,</para>
        /// <para>porque se ha avandonado la zona de gestion del objeto, se devuelve el manejador (se deja libre)</para>
        /// </summary>
        void fcvEventoMoverMouseFueraDeZona(object sender, MouseEventArgs e)
        {
            fcvFinalizarArrasteAlSoltarMouse();
            e.Handled = true;
        }
        #endregion
        #region fcvRemoverAdornos : Remover adornos de seleccion de algun objeto anterior
        /// <summary>
        /// fcvRemoverAdornos : Remover adornos de seleccion de algun objeto anterior
        /// </summary>
        private void fcvRemoverAdornos()
        {
            if (glgSiObjetoSeleccionado)
            {
                glgSiObjetoSeleccionado = false;
                if (guiRefObjetoSeleccionado != null)
                {
                    var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", ((FrameworkElement)guiRefObjetoSeleccionado).Name).FirstOrDefault();
                    // Quitar los adornos del anterior objeto seleccionado
                    if (lobObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                    {
                        luxUIAgregarAdorno.Remove(luxUIAgregarAdorno.GetAdorners(guiRefObjetoSeleccionado)[0]);
                    }
                    guiRefObjetoSeleccionado = null;
                }
            }
        }
        #endregion
        #region fcvAccionReSizeObjeto : Actualizar las propiedades en VistaModelo al ReSize objeto
        /// <summary>
        /// Actualizar las propiedades en VistaModelo al ReSize objeto
        /// </summary>
        public void fcvAccionReSizeObjeto(object sender, RoutedEventArgs e)
        {
            fcvGetObjPropiedadesReSizeObjeto();
        }
        #endregion
        #region fcvAddRemoveManejadorZona: Adicionar o remueve manejador zona para arrastar objetos
        /// <summary>
        /// <para>Adicionar o remueve manejador zona para arrastar objetos</para>
        /// <para>tcrAccion:</para>
        /// <para>ADD = Adicionar manejador</para>
        /// <para>DEL = Eliminar todos los manejadores activos</para>
        /// </summary>
        public void fcvAddRemoveManejadorZona(String tcrAccion)
        {
            if (tcrAccion == "ADD" && gobRefZonaSeleccionada != null)
            {
                gobRefZonaSeleccionada.MouseLeftButtonDown += new MouseButtonEventHandler(fcvQuitarAdornoObjetoMouseLeftButtonDown);
                gobRefZonaSeleccionada.MouseLeftButtonUp += new MouseButtonEventHandler(fcvFinalizaDragMouseManejador);
                gobRefZonaSeleccionada.MouseMove += new MouseEventHandler(fcvEventoMoverMouseEnZona);
                gobRefZonaSeleccionada.MouseLeave += new MouseEventHandler(fcvEventoMoverMouseFueraDeZona);
                gobRefZonaSeleccionada.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(fcvFinalizaDragMouseManejador);
                gobRefZonaSeleccionada.TouchUp += new EventHandler<TouchEventArgs>(fcvFinalizaDragManejadorTouchUp);
                gobRefZonaSeleccionada.PreviewTouchUp += new EventHandler<TouchEventArgs>(fcvFinalizaDragManejadorTouchUp);

            }
            else
            {
                // Quitar las referencias a todos los manejadores 
                List<ClassXmlPropObjeto> tobTemp = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "ZONA", "");
                foreach (var lobItem in tobTemp)
                {
                    if (lobItem.TipoObjeto == "ZONA")
                    {
                        GroupBox lobZona = lobItem.RefObjeto as GroupBox;
                        lobZona.MouseLeftButtonDown -= new MouseButtonEventHandler(fcvQuitarAdornoObjetoMouseLeftButtonDown);
                        lobZona.MouseLeftButtonUp -= new MouseButtonEventHandler(fcvFinalizaDragMouseManejador);
                        lobZona.MouseMove -= new MouseEventHandler(fcvEventoMoverMouseEnZona);
                        lobZona.MouseLeave -= new MouseEventHandler(fcvEventoMoverMouseFueraDeZona);
                        lobZona.PreviewMouseLeftButtonUp -= new MouseButtonEventHandler(fcvFinalizaDragMouseManejador);
                        lobZona.TouchUp -= new EventHandler<TouchEventArgs>(fcvFinalizaDragManejadorTouchUp);
                        lobZona.PreviewTouchUp -= new EventHandler<TouchEventArgs>(fcvFinalizaDragManejadorTouchUp);
                    }
                }
            }
        }
        #endregion
        #region Devolver apuntadores a todos los componentes del Tree del objeto seleccionado
        #region fcvArbolReferenciaSelectObjetoClik : Devolver apuntadores a todos los componentes del Tree del objeto seleccionado
        /// <summary>
        /// <para>Devolver apuntadores a todos los componentes del Arbol del objeto seleccionado con click.</para>
        /// <para>Tambien define el tipo de objetos seleccionado segun el nivel en el Arbol.</para>
        /// <para>gcrTipoObjetoNivel: Tipos de objetos a definir segun nivel:</para>
        /// <para>"PAGINA"      = Se selecciono el contenedor de la pagina.</para>
        /// <para>"ZONA"        = Click sobre el contenedor de una Zona .</para>
        /// <para>"ZONA-OBJETO" = es un Objeto dentro del contenedor de una Zona .</para>
        /// <para>"GRUPO"       = Un Grupo son Objetos en Zona del tipo radiobutton, odontogramas, imagenes complejas y otros.</para>
        /// <para>"GRUPO-OBJETO"= Es un objeto que hace parte de un grupo (radiobutton, odontogramas, imagenes complejas y otros).</para>
        /// </summary>
        //private void fcvArbolReferenciaSelectObjetoClik(MouseButtonEventArgs e)
        private void fcvArbolReferenciaSelectObjetoClik(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement lobObjetoSelectClick = e.Source as FrameworkElement;

            gcrTipoObjetoNivel = "NA";
            gcrObjetoClassBase = "NA";
            gobRefPaginaSeleccionada = null;
            gobRefZonaSeleccionada = null;
            gobRefGrupoSeleccionado = null;
            gobRefContenedorPaginaSeleccionada = null;
            gobRefContenedorZonaSeleccionada = null;
            gobRefContenedorGrupoSeleccionado = null;
            guiRefObjetoSeleccionado = lobObjetoSelectClick as UIElement;
            String lcrNombreObjeto = lobObjetoSelectClick != null ? lobObjetoSelectClick.Name.Substring(0, 7).ToUpper() : "XXXX";
            String lcrNombreContenedor = "XXXXXX";
            // referencias en tree 
            XmlEntorno.refTreeObj.Pagina = null;
            XmlEntorno.refTreeObj.ContenedorPagina = null;
            XmlEntorno.refTreeObj.Zona = null;
            XmlEntorno.refTreeObj.ContenedorZona = null;
            XmlEntorno.refTreeObj.Grupo = null;
            XmlEntorno.refTreeObj.ContenedorGrupo = null;
            XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
            XmlEntorno.refTreeObj.Navegador = String.Empty;
            //-----------------------------------------
            // Click en la Pagina
            //-----------------------------------------
            if (lcrNombreObjeto == "OBJPAGI" || lcrNombreObjeto == "OBJCPAG")
            {
                guiRefObjetoSeleccionado = null;
                gcrTipoObjetoNivel = "PAGINA";
                XmlEntorno.refTreeObj.NivelObjetoSelect = 1;
                fcvReferenciaVarNivelPagina(lobObjetoSelectClick);
                lcrNombreContenedor = gobRefPaginaSeleccionada.Name;
            }
            //-----------------------------------------
            // es una Zona / OBJCZON = Objeto tipo Canvas contenedor dentro de una Zona
            //-----------------------------------------
            else if (lcrNombreObjeto == "OBJZONA" || lcrNombreObjeto == "OBJCZON")
            {
                gcrTipoObjetoNivel = "ZONA";
                XmlEntorno.refTreeObj.NivelObjetoSelect = 2;
                fcvReferenciaVarNivelZona(lobObjetoSelectClick);
                lcrNombreContenedor = gobRefZonaSeleccionada.Name;
            }
            //-----------------------------------------
            // Ver si es Grupo de objetos dentro de zona / o el objeto contenedor del grupo 
            //-----------------------------------------
            else if (lcrNombreObjeto == "OBJGRUP" || lcrNombreObjeto == "OBJCGRU") // se selecciono Grupo de objetos o su contenedor
            {
                gcrTipoObjetoNivel = "GRUPO";
                XmlEntorno.refTreeObj.NivelObjetoSelect = 4;
                fcvReferenciaVarNivelGrupo(lobObjetoSelectClick);
                lcrNombreContenedor = gobRefGrupoSeleccionado.Name;
            }
            //-----------------------------------------
            // Objetos Dentro de Zona o Grupo
            //-----------------------------------------
            else
            {
                FrameworkElement lobParent = lobObjetoSelectClick.Parent as FrameworkElement;
                lcrNombreObjeto = lobParent.Name.Substring(0, 7).ToUpper();
                gcrTipoObjetoNivel = "ZONA-OBJETO";
                XmlEntorno.refTreeObj.NivelObjetoSelect = 3;

                if (lcrNombreObjeto == "OBJGRUP" || lcrNombreObjeto == "OBJCGRU") // se selecciono un objeto dentro de Grupo de objetos
                {
                    gcrTipoObjetoNivel = "GRUPO-OBJETO";
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 5;
                    fcvReferenciaVarNivelGrupo(lobParent);
                    lcrNombreContenedor = gobRefGrupoSeleccionado.Name;
                }
                else if (lcrNombreObjeto == "OBJZONA" || lcrNombreObjeto == "OBJCZON") // se selecciono un objeto dentro de la zona
                {
                    gcrTipoObjetoNivel = "ZONA-OBJETO";
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 3;
                    fcvReferenciaVarNivelZona(lobParent);
                    lcrNombreContenedor = gobRefZonaSeleccionada.Name;
                }
                guiRefObjetoSeleccionado = lobObjetoSelectClick as UIElement;
            }
            //Referencias tree
            var lcrObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lcrNombreContenedor).FirstOrDefault();
            if (lcrObjeto != null)
            {
                XmlEntorno.refTreeObj.Pagina = gobRefPaginaSeleccionada;
                XmlEntorno.refTreeObj.ContenedorPagina = gobRefContenedorPaginaSeleccionada;
                XmlEntorno.refTreeObj.Zona = gobRefZonaSeleccionada;
                XmlEntorno.refTreeObj.ContenedorZona = gobRefContenedorZonaSeleccionada;
                XmlEntorno.refTreeObj.Grupo = gobRefGrupoSeleccionado;
                XmlEntorno.refTreeObj.ContenedorGrupo = gobRefContenedorGrupoSeleccionado;
                XmlEntorno.refTreeObj.Navegador = lcrObjeto.Navegador;
                XmlEntorno.refTreeObj.CodigoPlantilla = lcrObjeto.CodigoPlantilla;
                vm.gcrTipoContenedorActivo = lcrObjeto.TipoObjeto.ToUpper();
            }

        }
        #endregion
        #region fcvReferenciaVarNivelPagina : Devolver las referencias a las variables iniciando desde Nivel Pagina
        /// <summary>
        /// Devolver las referencias a las variables iniciando desde Nivel Pagina
        /// </summary>
        private void fcvReferenciaVarNivelPagina(FrameworkElement tobObjetoSelectClick)
        {
            String lcrNombreObjeto = tobObjetoSelectClick.Name.Substring(0, 7).ToUpper();
            if (lcrNombreObjeto == "OBJPAGI" || lcrNombreObjeto == "OBJCPAG")
            {
                if (lcrNombreObjeto == "OBJCPAG")
                {
                    gobRefPaginaSeleccionada = tobObjetoSelectClick.Parent as Canvas; // Buscar la Pagina que contiene la zona
                    gobRefContenedorPaginaSeleccionada = tobObjetoSelectClick as WrapPanel;
                }
                else
                {
                    gobRefPaginaSeleccionada = tobObjetoSelectClick as Canvas;
                    gobRefContenedorPaginaSeleccionada = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", gobRefPaginaSeleccionada.Name).
                                                                                               FirstOrDefault().RefContenedorObjeto as WrapPanel;
                }
                gcrObjetoClassBase = "CANVAS";
            }
        }
        #endregion
        #region fcvReferenciaVarNivelZona : Devolver las referencias a las variables iniciando desde Nivel Zona
        /// <summary>
        /// fcvReferenciaVarNivelZona : Devolver las referencias a las variables iniciando desde Nivel Zona
        /// </summary>
        private void fcvReferenciaVarNivelZona(FrameworkElement tobObjetoSelectClick)
        {
            String lcrNombreObjeto = tobObjetoSelectClick.Name.Substring(0, 7).ToUpper();
            if (lcrNombreObjeto == "OBJZONA" || lcrNombreObjeto == "OBJCZON")
            {
                if (lcrNombreObjeto == "OBJCZON")
                {
                    gobRefZonaSeleccionada = tobObjetoSelectClick.Parent as GroupBox;
                    gobRefContenedorZonaSeleccionada = tobObjetoSelectClick as Canvas;
                }
                else
                {
                    gobRefZonaSeleccionada = tobObjetoSelectClick as GroupBox;
                    gobRefContenedorZonaSeleccionada = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", gobRefZonaSeleccionada.Name).
                                                                                               FirstOrDefault().RefContenedorObjeto as Canvas;
                }
                gcrObjetoClassBase = "CANVAS";
            }
            guiRefObjetoSeleccionado = gobRefZonaSeleccionada;
            gobRefContenedorPaginaSeleccionada = gobRefZonaSeleccionada.Parent as WrapPanel; // Buscar la pagian que contiene la zona
            gobRefPaginaSeleccionada = gobRefContenedorPaginaSeleccionada.Parent as Canvas; // Buscar la pagian que contiene la zona
        }
        #endregion
        #region fcvReferenciaVarNivelGrupo : Devolver las referencias a las variables iniciando desde Nivel Grupo
        /// <summary>
        /// fcvReferenciaVarNivelGrupo : Devolver las referencias a las variables iniciando desde Nivel Grupo
        /// </summary>
        private void fcvReferenciaVarNivelGrupo(FrameworkElement tobObjetoSelectClick)
        {
            String lcrNombreObjeto = tobObjetoSelectClick.Name.Substring(0, 7).ToUpper();
            if (lcrNombreObjeto == "OBJGRUP" || lcrNombreObjeto == "OBJCGRU")
            {
                if (lcrNombreObjeto == "OBJCGRU")
                {
                    gobRefContenedorGrupoSeleccionado = tobObjetoSelectClick as Canvas;
                    gobRefGrupoSeleccionado = tobObjetoSelectClick.Parent as GroupBox;
                }
                else
                {
                    gobRefGrupoSeleccionado = tobObjetoSelectClick as GroupBox;
                    gobRefContenedorGrupoSeleccionado = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", gobRefGrupoSeleccionado.Name).
                                                                                               FirstOrDefault().RefContenedorObjeto as Canvas;

                }
                gcrObjetoClassBase = "GROUPBOX";
                gobRefContenedorZonaSeleccionada = gobRefGrupoSeleccionado.Parent as Canvas;
                gobRefZonaSeleccionada = gobRefContenedorZonaSeleccionada.Parent as GroupBox;
                gobRefContenedorPaginaSeleccionada = gobRefZonaSeleccionada.Parent as WrapPanel; // Buscar la pagian que contiene la zona
                gobRefPaginaSeleccionada = gobRefContenedorPaginaSeleccionada.Parent as Canvas; // Buscar la pagian que contiene la zona
            }
        }
        #endregion
        #endregion
        #region fcvEventoManejadorKeyDown : Mover Objeto seleccionado con flechas del teclado
        /// <summary>
        /// fcvEventoManejadorKeyDown : Mover Objeto seleccionado con flechas del teclado
        /// </summary>
        void fcvEventoManejadorKeyDown(object sender, KeyEventArgs e)
        {
            if (guiRefObjetoSeleccionado != null)
            {
                double lduleft = Canvas.GetLeft(guiRefObjetoSeleccionado);
                if (Double.IsNaN(lduleft)) lduleft = 0;
                double lduTop = Canvas.GetTop(guiRefObjetoSeleccionado);
                if (Double.IsNaN(lduTop)) lduTop = 0;

                switch (e.Key)
                {
                    case Key.Left:
                        lduleft--;
                        break;

                    case Key.Right:
                        lduleft++;
                        break;

                    case Key.Up:
                        lduTop--;
                        break;

                    case Key.Down:
                        lduTop++;
                        break;

                    default: return;
                }
                // para no salir del Canvas contenedor
                if (lduleft < 0) lduleft = 0;
                if (lduTop < 0) lduTop = 0;

                Canvas.SetLeft(guiRefObjetoSeleccionado, lduleft);
                Canvas.SetTop(guiRefObjetoSeleccionado, lduTop);
                e.Handled = true;
                fcvGetObjPropiedadesReSizeObjeto();
            }
        }
        #endregion
        #endregion Fin Gestion Arrastrar y  Adornos
        //------------------------------------------------------------
        // GESTION PARA ADICIONAR OBJETOS A ZONAS
        //------------------------------------------------------------
        #region Gestión adicionar objetos en Zonas
        #region fcvAdicionarObjetosEnPagina: Ubicacion para adicionar objeto en plantilla/pagina/zona/grupo seleccionado
        /// <summary>
        ///  Ubicacion para adicionar objeto en plantilla/pagina/zona/grupo seleccionado
        /// </summary>
        private void fcvAdicionarObjetosEnPagina()
        {
            bool llgRefValida = false;
            String lcrNombreContenedor = String.Empty;
            Point lptPosMouse = Mouse.GetPosition(gobRefContenedorPaginaSeleccionada);
            if (XmlEntorno.refTreeObj.NivelObjetoSelect >= 2 && XmlEntorno.refTreeObj.NivelObjetoSelect <= 3) // Objetos en Zona
            {
                if (gobRefContenedorZonaSeleccionada != null)
                {
                    llgRefValida = true;
                    lptPosMouse = Mouse.GetPosition(gobRefContenedorZonaSeleccionada);
                    lcrNombreContenedor = gobRefZonaSeleccionada.Name;
                }
            }
            else
            {
                if (gobRefContenedorGrupoSeleccionado != null && XmlEntorno.refTreeObj.NivelObjetoSelect > 3) // dentro de un grupo
                {
                    llgRefValida = true;
                    lptPosMouse = Mouse.GetPosition(gobRefContenedorGrupoSeleccionado);
                    lcrNombreContenedor = gobRefGrupoSeleccionado.Name;
                }
            }
            // en caso que si paso la validacion
            if (llgRefValida == true && !String.IsNullOrWhiteSpace(lcrNombreContenedor))
            {
                var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lcrNombreContenedor).FirstOrDefault();
                var lcrTipoContenedor = lobObjeto.TipoObjeto.ToUpper();

                if (EdtUtilidades.flgSiContenedorAdicionarObjeto(lcrTipoContenedor, gcrAddNuevoObjetoTipo) == true && lobObjeto.Navegador == "ESCRITORIO")
                {
                    // Agregar objetos solo en escritorio por ahora
                    gduCanvasClicPosX = lptPosMouse.X;
                    gduCanvasClicPosY = lptPosMouse.Y;
                    fcvAdicionarTipoObjeto(gcrAddNuevoObjetoTipo);
                }
            }
        }
        #endregion
        #region fcvAdicionarTipoObjeto: Seleccion tipo Objeto Adicionar en Pagina/Zona/grupo
        /// <summary>
        /// Seleccion tipo Objeto Adicionar en Pagina/Zona/grupo
        /// </summary>
        private void fcvAdicionarTipoObjeto(String tcrTipoObjeto)
        {
            if (tcrTipoObjeto != "IMAGEN-PREDEF")
            {
                XmlEntorno.flgAddNuevoObjeto(gcrAddNuevoObjetoTipo, gduCanvasClicPosX, gduCanvasClicPosY);
            }
            else
            {
                var lobTile = gobRefTileImgPredefinida;
                XmlEntorno.flgAddNuevoObjeto("IMAGEN", gduCanvasClicPosX, gduCanvasClicPosY,
                                                lobTile.ImagenHeight, lobTile.ImagenWidth, lobTile.RecursoArchivoUri, lobTile.RecursoArchivoNombre);
            }
            XmlEntorno.refRegObjActivo.ObjetoModo = XmlEntorno.refTreeObj.Navegador == "ESCRITORIO" ? "CAPTURA-EDT-ESCRITORIO" : "CAPTURA-EDT-ETIQUETA";
            XmlEntorno.SetPropiedadObjeto(XmlEntorno.refRegObjActivo.Name, "ObjetoModo", XmlEntorno.refRegObjActivo.ObjetoModo);

            fcvMajenadorSizeChanged(XmlEntorno.refRegObjActivo, XmlEntorno.refRegObjActivo.ClaseBase, "+");
            fnuCmdDesHacerAddRegistroPila("ADICIONADO", XmlEntorno.refRegObjActivo);

            fcvRestablecerPunteroMouse();
            gcrAddNuevoObjetoTipo = String.Empty;
            glgNuevoObjetoCrear = false;
            gobRefTileImgPredefinida = null;
        }
        #endregion
        #region fcvModificarPunteroMouse: modificar puntro mouse al modo adicionar
        /// <summary>
        /// <para>Modificar el puntero del mouse para mostrar el modo adicionar objeto</para>
        /// </summary>
        private void fcvModificarPunteroMouse()
        {
            fcvModificarPunteroMouseEx("ADD");
        }
        #endregion
        #region fcvRestablecerPunteroMouse: Restablecer puntro mouse del modo Adicionar
        private void fcvRestablecerPunteroMouse()
        {
            fcvModificarPunteroMouseEx("EDT");
        }
        #endregion
        #region fcvModificarPunteroMouseEx: modificar puntro mouse al modo adicionar
        /// <summary>
        /// <para>Recorre todos los contenedores para  Modificar el puntero del mouse.</para>
        /// <para>tcrTipoPuntero: ADD = Modo Adicionar objeto EDT= Modo Normal.</para>
        /// </summary>
        private void fcvModificarPunteroMouseEx(String tcrTipoPuntero)
        {
            foreach (var lobItem in XmlEntorno.tmpObjetos)
            {
                if (lobItem.ClaseBase == "GroupBox" || lobItem.ClaseBase == "Canvas" ||
                    lobItem.ClaseBase == "WrapPanel" || lobItem.ClaseBase == "StackPanel")
                {
                    FrameworkElement lobObjeto = lobItem.RefObjeto as FrameworkElement;
                    lobObjeto.Cursor = tcrTipoPuntero == "ADD" ? Cursors.Cross : Cursors.Arrow;
                }
            }
        }
        #endregion
        // Controles
        #region fcvCmdAddTextBlock: Adicionar Cuadro de texto
        private void fcvCmdAddTextBlock(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "TEXTBLOCK";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddImage: Adicionar Imagen
        private void fcvCmdAddImage(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "IMAGEN";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        // Figuras
        #region fcvCmdAddRectangulo: Adicionar Rectangulo
        private void fcvCmdAddRectangulo(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "RECTANGULO";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddElipse: Adicionar elipse
        private void fcvCmdAddElipse(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "ELIPSE";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddLineaHorizontal: Adicionar Linea Horizontal
        private void fcvCmdAddLineaHorizontal(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "LINEA-HORIZONTAL";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddLineaVertical: Adicionar Linea Vertical
        private void fcvCmdAddLineaVertical(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "LINEA-VERTICAL";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddLineaderecha: Adicionar Linea Derecha
        private void fcvCmdAddLineaDerecha(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "LINEA-DERECHA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddLineaIzquierda: Adicionar Linea Izquierda
        private void fcvCmdAddLineaIzquierda(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "LINEA-IZQUIERDA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        // Flechas
        #region fcvCmdAddFlechaDerecha: Adicionar Flecha Derecha
        private void fcvCmdAddFlechaDerecha(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "FLECHA-DERECHA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddFlechaIzquierda: Adicionar Flecha Izquierda
        private void fcvCmdAddFlechaIzquierda(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "FLECHA-IZQUIERDA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddFlechaArriba: Adicionar Flecha arriba
        private void fcvCmdAddFlechaArriba(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "FLECHA-ARRIBA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddFlechaAbajo: Adicionar Flecha Abajo
        private void fcvCmdAddFlechaAbajo(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "FLECHA-ABAJO";
            glgNuevoObjetoCrear = true;
            gobRefZonaSeleccionada.Cursor = Cursors.Cross;
        }
        #endregion
        // Galeria Imagenes predefinidas
        #region fcvCmdAddImagenPredefinida: Adicionar Imagen predefinidas
        private void fcvCmdAddImagenPredefinida(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobTile = lobGrid.Parent as TileImgPredefinidas;
            gobRefTileImgPredefinida = lobTile;
            gcrAddNuevoObjetoTipo = "IMAGEN-PREDEF";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // GetObj: ACTIVAR PROPIEDADES AL SELECCIONAR EL OBJETO CON CLICK
        //------------------------------------------------------------
        #region Activar Propiedades al seleccionar objeto con click
        #region fcvGetObjActivarPropiedades: Activar vista propiedades del objeto activo
        /// <summary>
        /// <para>Activar vista propiedades del objeto activo</para>
        /// </summary>
        public void fcvGetObjActivarPropiedades()
        {
            try
            {
                FrameworkElement lobj = null;
                if (guiRefObjetoSeleccionado != null)
                {
                    lobj = guiRefObjetoSeleccionado as FrameworkElement;
                }
                else if (gobRefPaginaSeleccionada != null)
                {
                    lobj = gobRefPaginaSeleccionada as FrameworkElement;
                }
                if (lobj != null)
                {
                    fcvGetObjPropiedadVistaModelo(lobj);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvActivarPropiedades");
            }
        }
        #endregion
        #region fcvGetObjPropiedadVistaModelo: Activar Vista Propiedades de objetos
        /// <summary>
        /// <para>Activar Vista Propiedades de objetos en Vista Modelo</para>
        /// </summary>
        private void fcvGetObjPropiedadVistaModelo(FrameworkElement tobObjeto)
        {
            try
            {
                glgModoSetPropiedades = true;
                vm.fcvGridReiniVariables("P");
                vm.fcvGridReiniVariables("I");
                vm.fcvGridReiniVariables("TI");
                var tobProp = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", tobObjeto.Name).FirstOrDefault();
                vm.tmpComboBoxItems = XmlEntorno.fobRegSelectParenComboBoxItems("PARENT", tobObjeto.Name);
                // Activar Objetos propieades en Ventana
                fcvGetObjPropiedadesVisibleObjeto(tobProp.TipoObjeto);
                #region Propiedades
                // Propiedades Básicas
                vm.PropTxtName = tobProp.Name;
                vm.PropTxtTitulo = tobProp.Titulo;
                vm.PropTxtToolTip = tobProp.ToolTip;
                vm.PropTxtTituloVisible = tobProp.TituloVisible;
                vm.PropTxtTipoObjeto = tobProp.TipoObjeto;
                vm.PropTxtClaseBase = tobProp.ClaseBase;
                vm.PropTxtParent = tobProp.Parent;
                vm.PropTxtTabIndex = tobProp.TabIndex;
                vm.PropTxtPagina = tobProp.Pagina;
                vm.PropTxtCambiarTabs = tobProp.CambiarTabs;
                vm.PropTxtFocusable = tobProp.Focusable;
                vm.PropTxtIsEnabled = tobProp.IsEnabled;
                vm.PropTxtVisibility = tobProp.Visibility;
                // Propiedades Apariencia
                vm.PropTxtVerticalAlignment = tobProp.VerticalAlignment;
                vm.PropTxtHorizontalAlignment = tobProp.HorizontalAlignment;
                vm.PropTxtStyle = tobProp.Style;
                vm.PropTxtMargin            = tobProp.Margin;
                vm.PropTxtBorder            = tobProp.Border;
                vm.PropTxtForeground        = tobProp.Foreground;
                vm.PropTxtBorderBrush       = tobProp.BorderBrush;
                vm.PropTxtBackground        = tobProp.Background;
                vm.PropTxtHeight            = tobProp.Height;
                vm.PropTxtWidth             = tobProp.Width;
                vm.PropTxtTop               = tobProp.Top;
                vm.PropTxtLeft              = tobProp.Left;
                vm.PropTxtFontFamily        = tobProp.FontFamily;
                vm.PropTxtFontStyle         = tobProp.FontStyle;
                vm.PropTxtFontWeight        = tobProp.FontWeight;
                vm.PropTxtFontDecorations = tobProp.Decorations;
                vm.PropTxtFontSize = tobProp.FontSize;
                vm.PropTxtOrientacion = tobProp.Orientacion;
                vm.PropTxtAngulo = tobProp.Angulo;
                // Propiedades Datos
                vm.PropDatTxtBinding = tobProp.Binding;
                vm.PropDatTxtValorDefault = tobProp.ValorDefault;
                vm.PropDatTxtTotalItems = tobProp.TotalItems;
                vm.PropDatTxtTipoDato = tobProp.TipoDato;
                vm.PropDatTxtTipoOrigenDatos = tobProp.TipoOrigenDatos;
                vm.PropDatTxtTablaOrigen = tobProp.TablaOrigen;
                vm.PropDatTxtCodigoEtiqueta = tobProp.CodigoEtiqueta;
                vm.PropDatTxtRangoInicial = tobProp.RangoInicial;
                vm.PropDatTxtRangoFinal = tobProp.RangoFinal;
                vm.PropArchActualizCodigoArchivo = tobProp.RefVarDatosTipo;
                vm.PropArchActualizCodigoCampo = tobProp.RefVarDatosCampo;
                // Propiedades Imagen, Video y otros archivos
                vm.PropTxtRecursoArchivoTipo = tobProp.RecursoArchivoTipo;
                vm.PropTxtRecursoArchivoCodigo = tobProp.RecursoArchivoCodigo;
                vm.PropTxtRecursoArchivoUri = tobProp.RecursoArchivoUri;
                vm.PropTxtRecursoArchivoNombre = tobProp.RecursoArchivoNombre;
                vm.PropImgTxtStretch = tobProp.Stretch;
                vm.PropImgTxtStretchDirection = tobProp.StretchDirection;

                // Propiedades Varias
                vm.PropTxtSiValorCalculado = tobProp.SiValorCalculado;
                vm.PropDatTxtNombreVariable = tobProp.NombreVariable;
                // control para validacion Alto,Ancho,Ajuste Izquierda y Ajuste Arriba
                vm.gcrValidPropDistribucion = "1111"; //Alto,Ancho,Ajuste Izquierda y Ajuste Arriba
                #endregion
                #region Listas ComboBox
                // Activar los combos de color
                cboPropForeground.SelectedColor = String.IsNullOrWhiteSpace(tobProp.Foreground) ? (Color)ColorConverter.ConvertFromString("Black") :
                                                                            (Color)ColorConverter.ConvertFromString(tobProp.Foreground);

                cboPropBorderBrush.SelectedColor = String.IsNullOrWhiteSpace(tobProp.BorderBrush) ? (Color)ColorConverter.ConvertFromString("Black") :
                                                                            (Color)ColorConverter.ConvertFromString(tobProp.BorderBrush);

                cboPropBackground.SelectedColor = String.IsNullOrWhiteSpace(tobProp.Background) ? (Color)ColorConverter.ConvertFromString("Transparent") :
                                                                            (Color)ColorConverter.ConvertFromString(tobProp.Background);
                //- Activar ComboBox de Fuentes y Distribucion
                cboPropCboBorder.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(0, tobProp.Border, vm.PropCboBorder);
                cboPropFontFamily.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(0, tobProp.FontFamily, vm.PropCboFontFamily);
                cboPropCboFontSize.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(3, tobProp.FontSize, vm.PropCboFontSize);
                cboPropCboStretch.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(1, tobProp.Stretch, vm.PropCboStretch);
                cboPropCboStretchDirection.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(1, tobProp.StretchDirection, vm.PropCboStretchDirection);
                cboPropCboCodigoEtiquetas.SelectedIndex = String.IsNullOrWhiteSpace(tobProp.CodigoEtiqueta) ? 0 :
                                                                                        VistaModeloObjetoActivo.fnuMostrarEtiquetas(vm.PropDatTxtCodigoEtiqueta,
                                                                                                                                            vm.tmpEtiquetaItems);
                #endregion
                #region Listas Varios
                // CheckBox
                chkFuenteNegrita.IsChecked = (tobProp.FontWeight == "Bold") ? true : false;
                chkFuenteCursiva.IsChecked = (tobProp.FontStyle == "Italic") ? true : false;
                // Variable de control del modo
                glgModoSetPropiedades = false;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetPropiedadVistaModelo");
            }
        }
        #endregion
        #region fcvGetObjPropiedadesReSizeObjeto: Actualizar las propiedades al arrastrar objeto
        /// <summary>
        /// <para>Actualizar en Vistamodelo, las propiedades al arrastrar el objeto o ajustar alto y ancho</para>
        /// <para>con el mouse desde las esquinas.</para>
        /// </summary>
        private void fcvGetObjPropiedadesReSizeObjeto()
        {
            if (guiRefObjetoSeleccionado != null)
            {
                var llgSetEstado = glgModoArrastrarObjeto;
                glgModoArrastrarObjeto = true;

                FrameworkElement lobj = guiRefObjetoSeleccionado as FrameworkElement;
                vm.PropTxtHeight = lobj.Height.ToString().Trim();
                vm.PropTxtWidth = lobj.Width.ToString().Trim();
                vm.PropTxtTop = Canvas.GetTop(lobj).ToString().Trim();
                vm.PropTxtLeft = Canvas.GetLeft(lobj).ToString().Trim();
                // Actualizar el entorno
                XmlEntorno.SetPropiedadObjeto(lobj.Name, "Height", vm.PropTxtHeight);
                XmlEntorno.SetPropiedadObjeto(lobj.Name, "Width", vm.PropTxtWidth);
                XmlEntorno.SetPropiedadObjeto(lobj.Name, "Top", vm.PropTxtTop);
                XmlEntorno.SetPropiedadObjeto(lobj.Name, "Left", vm.PropTxtLeft);

                glgModoArrastrarObjeto = llgSetEstado;
            }
        }
        #endregion
        #region fcvGetObjPropiedadesVisibleObjeto: Activa las Propidedades en la Ventana
        /// <summary>
        /// <para>Activa las Propidedades en la Ventana segun el tipo de objeto seleccionado</para>
        /// </summary>
        private void fcvGetObjPropiedadesVisibleObjeto(String tcrTipoObjeto)
        {
            fcvGetObjSetPropiedadesVisibleTodas();
            fcvGetObjSetPropiedadVisibleVentana("GrupoRecursoArchivo", false);
            fcvGetObjSetPropiedadVisibleVentana("TablaOrigen", false);
            fcvGetObjSetPropiedadVisibleVentana("RecursoArchivo", false);
            #region objetos
            switch (tcrTipoObjeto)
            {
                case "PAGINA":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("Foreground", false);
                    fcvGetObjSetPropiedadVisibleVentana("Top", false);
                    fcvGetObjSetPropiedadVisibleVentana("Left", false);
                    fcvGetObjSetPropiedadVisibleVentana("Font", false);
                    fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                    fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                    fcvGetObjSetPropiedadVisibleVentana("Visibility", false);
                    fcvGetObjSetPropiedadVisibleVentana("VerticalAlignment", false);
                    fcvGetObjSetPropiedadVisibleVentana("HorizontalAlignment", false);
                    break;
                    #endregion

                case "ZONA":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    fcvGetObjSetPropiedadVisibleVentana("Foreground", false);
                    fcvGetObjSetPropiedadVisibleVentana("Top", false);
                    fcvGetObjSetPropiedadVisibleVentana("Left", false);
                    fcvGetObjSetPropiedadVisibleVentana("Font", false);
                    fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                    fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                    fcvGetObjSetPropiedadVisibleVentana("VerticalAlignment", false);
                    fcvGetObjSetPropiedadVisibleVentana("HorizontalAlignment", false);
                    break;
                    #endregion

                case "TEXTBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    break;
                    #endregion

                case "RICHTEXTBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    break;
                    #endregion

                case "COMBOBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ValorDefault", false);
                    break;
                    #endregion

                case "TEXTBOXREL":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("ValorDefault", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("TablaOrigen", true);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    break;
                    #endregion

                case "TEXTBOXRELCOD":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    break;
                    #endregion

                case "TEXTBOXRELDES":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    break;
                    #endregion

                case "TEXTBLOCK":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    break;
                    #endregion

                case "RADIOBUTTON":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    break;
                    #endregion

                case "CHECKBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    break;
                    #endregion

                case "BUTTON":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    break;
                    #endregion

                case "GROUPBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    break;
                    #endregion

                case "MULTIGROUPCHKBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    break;
                    #endregion

                case "MULTIGROUPRADIOBUTTON":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    break;
                    #endregion

                case "MULTICHKBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    break;
                    #endregion

                case "MULTIRADIOBUTTON":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    break;
                    #endregion

                case "IMAGEN":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("GrupoRecursoArchivo", true);
                    fcvGetObjSetPropiedadVisibleVentana("RecursoArchivo", true);
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                    fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                    fcvGetObjSetPropiedadVisibleVentana("Font", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    break;
                    #endregion

                default:
                    #region Propiedades Figuras
                    if (tcrTipoObjeto == "RECTANGULO" || tcrTipoObjeto == "ELIPSE" || tcrTipoObjeto == "POLYLINE" ||
                        tcrTipoObjeto == "POLYGON" || tcrTipoObjeto == "LINEA-HORIZONTAL" || tcrTipoObjeto == "LINEA-DERECHA" ||
                        tcrTipoObjeto == "LINEA-IZQUIERDA" || tcrTipoObjeto == "FLECHA-DERECHA" || tcrTipoObjeto == "FLECHA-IZQUIERDA" ||
                        tcrTipoObjeto == "FLECHA-ARRIBA" || tcrTipoObjeto == "FLECHA-ABAJO")
                    {
                        fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                        fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                        fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                        fcvGetObjSetPropiedadVisibleVentana("Font", false);
                        fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                        fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);

                    }
                    #endregion
                    break;
            }
            #endregion

        }
        #endregion
        #region fcvGetObjSetPropiedadesVisibleTodas: Coloca Visible todas Propidedades en la Ventana
        /// <summary>
        /// <para>Coloca Visible todas Propidedades en la Ventana</para>
        /// </summary>
        private void fcvGetObjSetPropiedadesVisibleTodas()
        {
            #region Propiedades
            //Grupo Datos y Varios  
            this.PropArchivoRecurso.Visibility = Visibility.Visible;
            // Propiedades Basicas           
            this.propTitulo.Visibility = Visibility.Visible;
            // Propiedades Apariencia
            this.propBorder.Visibility = Visibility.Visible;
            this.propForeground.Visibility = Visibility.Visible;
            this.propBorderBrush.Visibility = Visibility.Visible;
            this.propBackground.Visibility = Visibility.Visible;
            this.propFont.Visibility = Visibility.Visible;
            //Propiedades Datos
            this.propArchivoRecurso.Visibility = Visibility.Visible;
            this.propRecursoArchivoTipo.Visibility = Visibility.Visible;
            this.propRecursoArchivoCodigo.Visibility = Visibility.Visible;
            this.propRecursoArchivoUri.Visibility = Visibility.Visible;
            this.propRecursoArchivoNombre.Visibility = Visibility.Visible;
            #endregion
        }
        #endregion
        #region fcvGetObjSetPropiedadVisibleVentana: Visualizar u Ocultar la propiedad para un objeto
        /// <summary>
        /// <para>Visualizar u Ocultar la propiedad en la ventana propiedades para un objeto que asi lo requiera</para>
        /// </summary>
        private void fcvGetObjSetPropiedadVisibleVentana(String tcrPropiedad, bool tlgVisible)
        {
            #region Propiedades
            switch (tcrPropiedad.Trim())
            {
                //Grupo Datos y Varios  
                #region Propiedades
                case "GrupoRecursoArchivo":
                    this.PropArchivoRecurso.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Titulo":
                    this.propTitulo.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                // Propiedades Apariencia
                case "Border":
                    this.propBorder.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Foreground":
                    this.propForeground.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "BorderBrush":
                    this.propBorderBrush.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Background":
                    this.propBackground.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Font":
                    this.propFont.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Orientacion":
                    //this.propOrientacion.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Angulo":
                    //this.propAngulo.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;
                #endregion
                //Propiedades imagen videos y archivos
                #region Propiedades RecursoArchivo Imagenes Videos y demas
                case "RecursoArchivo":
                    this.propArchivoRecurso.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RecursoArchivoTipo":
                    this.propRecursoArchivoTipo.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RecursoArchivoCodigo":
                    this.propRecursoArchivoCodigo.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RecursoArchivoUri":
                    this.propRecursoArchivoUri.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RecursoArchivoNombre":
                    this.propRecursoArchivoNombre.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;
                #endregion
            }
            #endregion
        }
        #endregion
        #region fcvGetObjRecursoImportar: Abrir el explorador de windows para buscar una imagen fija
        /// <summary>
        /// <para>Abrir el explorador de windows para buscar una imagen fija</para>
        /// </summary>
        private void fcvGetObjRecursoImportar(object sender, RoutedEventArgs e)
        {
            var lcrRutayArchivo = String.Empty;
            var lcrRutaGaleria = oApp.gcrAppRecursoInicioPath + @"\" + oApp.gcrAppRecursoPath + @"\Imagenes\Plantillas";
            var lcrRutaDestino = oApp.gcrAppRecursoIpServidor + @"\" + lcrRutaGaleria;
            var lcrNombreArchivo = String.Empty;

            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                lcrRutaDestino = @"\\" + oApp.gcrAppRecursoIpServidor + @"\" + lcrRutaGaleria;
            }

            try
            {
                var lobArchivo = EdtUtilidades.fobBuscarArchivoRecurso("Buscar Imagen...", ".jpg", "Buscar imagenes (*.bmp, *.png, *.jpg)|*.bmp;*.png;*.jpg");

                if (lobArchivo != null)
                {
                    lcrRutayArchivo = lobArchivo.RutayArchivo;
                    lcrNombreArchivo = "IMG001_" + lobArchivo.NombreArchivo;
                    String lcrArchivoOrigen = lcrRutayArchivo;
                    String lcrArchivoDestino = lcrRutaDestino + @"\" + lcrNombreArchivo;

                    if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                    {
                        lcrArchivoOrigen = System.IO.Path.Combine(lcrRutayArchivo);
                        lcrArchivoDestino = System.IO.Path.Combine(lcrRutaDestino, lcrNombreArchivo);
                    }

                    if (!File.Exists(lcrArchivoDestino))
                    {
                        System.IO.File.Copy(lcrArchivoOrigen, lcrArchivoDestino, true);
                    }
                    var lobUri = new Uri(lcrArchivoDestino, UriKind.RelativeOrAbsolute);
                    //this.txtPropImgTxtCodigoRecursoImagen.Text = "10";
                    this.txtPropTxtRecursoArchivoTipo.Text = "IMAGEN";
                    this.txtPropTxtRecursoArchivoUri.Text = lcrRutaGaleria;
                    this.txtPropTxtRecursoArchivoNombre.Text = lcrNombreArchivo;

                    var lobImagen = guiRefObjetoSeleccionado as Image;
                    lobImagen.Source = new BitmapImage(lobUri);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGetObjImagenImportar");
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // SetObj: ACTIVAR PROPIEDADES DESDE VENTANA PROPIEDADES
        //------------------------------------------------------------
        #region Activar Propiedades desde Ventana Propiedades
        #region fcvSetObjActualizarTituloObjeto: Actualizar propiedad titulo desde Ventana
        /// <summary>
        /// Actualizar propiedad titulo desde ventana
        /// </summary>
        private void fcvSetObjActualizarTituloObjeto(object sender, TextChangedEventArgs e)
        {
            fcvSetObjPropActualizarTituloObjeto();
        }
        #endregion
        #region fcvSetObjPropActualizarTituloObjeto: Gestion Titulo objeto desde ventana propiedades
        /// <summary>
        /// Gestion Titulo objeto desde ventana propiedades
        /// </summary>
        private void fcvSetObjPropActualizarTituloObjeto()
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && guiRefObjetoSeleccionado != null)
                {
                    if (vm.glgSiValidPropiedadObjeto == true)
                    {
                        var lclTituloObj = new EdtUtilidades.ObjetoTitulo();
                        var lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(guiRefObjetoSeleccionado).ToUpper();

                        lclTituloObj.Titulo = vm.PropTxtTitulo;
                        lclTituloObj.TituloVisible = vm.PropTxtTituloVisible;
                        //- Actualizar Entorno
                        XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                         "Titulo", vm.PropTxtTitulo);

                        XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                         "TituloVisible", vm.PropTxtTituloVisible);

                        if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                        {
                            EdtUtilidades.flgSetPropiedadTituloObjeto(guiRefObjetoSeleccionado, lcrclassObjeto, lclTituloObj);
                        }

                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetPropActualizarTituloObjeto");
            }
        }
        #endregion
        #region fcvSetObjActualizarToolTipObjeto: Actualizar propiedad texto de ayuda objeto
        /// <summary>
        /// Actualizar propiedad texto de ayuda objeto
        /// </summary>
        private void fcvSetObjActualizarToolTipObjeto(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && guiRefObjetoSeleccionado != null)
                {
                    var lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(guiRefObjetoSeleccionado).ToUpper();
                    //- Actualizar Entorno
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "ToolTip", vm.PropTxtToolTip);

                    if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                    {
                        EdtUtilidades.flgSetPropiedadToolTipObjeto(guiRefObjetoSeleccionado, lcrclassObjeto, vm.PropTxtToolTip);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjActualizarToolTipObjeto");
            }
        }
        #endregion
        #region fcvSetObjActualizarDistribucionObjeto: Actualizar propiedades Alto, ancho,Left y Top
        /// <summary>
        /// Actualizar propiedades Alto, ancho,Left y Top
        /// </summary>
        private void fcvSetObjActualizarDistribucionObjeto(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && gobRefPaginaSeleccionada != null
                    && vm.glgSiValidPropiedadObjeto == true && glgModoArrastrarObjeto == false)
                {
                    #region
                    var luiObjeto = guiRefObjetoSeleccionado != null ? guiRefObjetoSeleccionado : gobRefPaginaSeleccionada as UIElement;
                    var lobRegProp = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", ((FrameworkElement)luiObjeto).Name).FirstOrDefault();
                    var lcrclassObjeto = String.Empty;
                    var lclDistribucion = new EdtUtilidades.ObjetoDistribucion();

                    //- Alto y Ancho
                    lclDistribucion.Height = vm.gcrValidPropDistribucion.Substring(0, 1) == "1" ?
                                                            Convert.ToDouble(vm.PropTxtHeight) : Convert.ToDouble(lobRegProp.Height);
                    lclDistribucion.Width = vm.gcrValidPropDistribucion.Substring(1, 1) == "1" ?
                                                            Convert.ToDouble(vm.PropTxtWidth) : Convert.ToDouble(lobRegProp.Width);

                    // Alineacion izquierda y Arriba
                    lclDistribucion.Left = vm.gcrValidPropDistribucion.Substring(2, 1) == "1" ?
                                                            Convert.ToDouble(vm.PropTxtLeft) : Convert.ToDouble(lobRegProp.Left);
                    lclDistribucion.Top = vm.gcrValidPropDistribucion.Substring(3, 1) == "1" ?
                                                            Convert.ToDouble(vm.PropTxtTop) : Convert.ToDouble(lobRegProp.Top);

                    //Actualizar Entorno Xml
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Height", lclDistribucion.Height.ToString().Trim());
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Width", lclDistribucion.Width.ToString().Trim());
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Left", lclDistribucion.Left.ToString().Trim());
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Top", lclDistribucion.Top.ToString().Trim());

                    //Actualizar Objeto
                    lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(luiObjeto).ToUpper();
                    if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                    {
                        EdtUtilidades.flgSetPropiedadDistribucionObjeto(luiObjeto, lobRegProp, lclDistribucion);
                        // si es una pagina Ajustar el contenedor
                        if (lobRegProp.TipoObjeto == "PAGINA")
                        {
                            var lobPagina = luiObjeto as Canvas;
                            var lobConte = lobRegProp.RefContenedorObjeto as WrapPanel;
                            XmlEntorno.SetPropiedadMargenContenedorPagina(ref lobPagina, ref lobConte);
                            if (lclDistribucion.Width > XmlEntorno.gduMinimoAnchoPlantilla)
                            {
                                XmlEntorno.gduMinimoAnchoPlantilla = lclDistribucion.Width;
                            }

                        }
                    }
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvActualizarTituloObjeto");
            }
        }
        #endregion
        #region fcvSetObjSeleccionComboBoxPropiedad: Actualizar propiedades al seleccionar desde CombBox
        /// <summary>
        /// Actualizar las propiedades al seleccionar desde CombBox
        /// </summary>
        private void fcvSetObjSeleccionComboBoxPropiedad(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && guiRefObjetoSeleccionado != null)
                {
                    var lobEtiq = new XmlEntorno.ClassXmlItemEtiquetas();
                    var lobList = new VistaModeloObjetoActivo.ListaXmlValores();
                    ComboBox lobCombo = (ComboBox)sender;
                    if (lobCombo.Name == "cboPropCboCodigoEtiquetas")
                    {
                        lobEtiq = (XmlEntorno.ClassXmlItemEtiquetas)e.AddedItems[0];

                    }
                    else
                    {
                        lobList = (VistaModeloObjetoActivo.ListaXmlValores)e.AddedItems[0];
                    }
                    #region Propiedades
                    switch (lobCombo.Name)
                    {
                        case "cboPropCboBorder":
                            vm.PropTxtBorder = lobList.Codigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "Border", vm.PropTxtBorder);
                            fcvSetObjComboBoxSelectBorder();
                            break;

                        case "cboPropFontFamily":
                            fcvSetObjFuenteVentanaPropToVistaModelo();
                            fcvSetObjComboBoxSelectPropiedadFuente();
                            break;

                        case "cboPropCboFontSize":
                            fcvSetObjFuenteVentanaPropToVistaModelo();
                            fcvSetObjComboBoxSelectPropiedadFuente();
                            break;

                        case "cboPropCboStretch":
                            vm.PropImgTxtStretch = lobList.Codigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "Stretch", vm.PropImgTxtStretch);

                            EdtUtilidades.flgSetPropiedadStretch(guiRefObjetoSeleccionado, vm.PropImgTxtStretch, vm.PropImgTxtStretchDirection);
                            break;

                        case "cboPropCboStretchDirection":
                            vm.PropImgTxtStretchDirection = lobList.Codigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "StretchDirection", vm.PropImgTxtStretchDirection);

                            EdtUtilidades.flgSetPropiedadStretch(guiRefObjetoSeleccionado, vm.PropImgTxtStretch, vm.PropImgTxtStretchDirection);
                            break;

                        case "cboPropCboCodigoEtiquetas":
                            vm.PropDatTxtCodigoEtiqueta = lobEtiq.Codigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "CodigoEtiqueta", vm.PropDatTxtCodigoEtiqueta);
                            fcvSetObjAsociarEtiquetaDatos();
                            break;

                        case "cboCmdTamAdornos":
                            gduTamañoAdornos = Convert.ToDouble(lobEtiq.Codigo);
                            break;

                        case "cboPropCboTipoControl":
                            vm.PropTxtTipoControl = lobList.Codigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "TipoControl", vm.PropTxtTipoControl);
                            break;

                    }
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjSeleccionComboBoxPropiedad");
            }
        }
        #endregion
        #region fcvSetObjAsociarEtiquetaDatos: Crear los datos para objeto etiqeta
        /// <summary>
        /// <para>Crear los datos asociados en temporal para el objeto seleccionado como etiqueta de datos</para>
        /// </summary>
        private void fcvSetObjAsociarEtiquetaDatos()
        {
            if (guiRefObjetoSeleccionado != null)
            {
                if (vm.PropDatTxtCodigoEtiqueta == "NA") // se quito la etiqueta de datos
                {
                    XmlEntorno.tmpCapturaEtiqueta = null;
                    XmlEntorno.flgEdtAccionEliminarDatosEtiqueta("DATOS", ((FrameworkElement)guiRefObjetoSeleccionado).Name);
                    fcvActivarVistaEtiquetaEstado(false);
                }
                else
                {
                    var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", ((FrameworkElement)guiRefObjetoSeleccionado).Name).FirstOrDefault();
                    var lobTemp = XmlEntorno.fobRegSelectParentRegistro("TEMP-ETIQUETA", "PLANTILLA", lobObjeto.Name);
                    if (lobTemp != null)
                    {
                        if (lobTemp.Count >= 1)
                        {
                            // si es diferente plantilla eliminar en digitados
                            var lcrCodigoPlantilla = lobTemp.FirstOrDefault().CodigoPlantilla;
                            if (lcrCodigoPlantilla != vm.PropDatTxtCodigoEtiqueta)
                            {
                                //eliminar la etiqueta anterior del temporal 
                                XmlEntorno.flgEdtAccionEliminarDatosEtiqueta("DATOS", lobObjeto.Name);
                                XmlEntorno.flgGestVistaCapturaGenerarNuevoRegistro("OBJETOS", vm.PropDatTxtCodigoEtiqueta, lobObjeto.Name);
                            }
                        }
                        else
                        {
                            XmlEntorno.flgGestVistaCapturaGenerarNuevoRegistro("OBJETOS", vm.PropDatTxtCodigoEtiqueta, lobObjeto.Name);
                        }
                    }
                    else
                    {
                        //  add nuevo registros que se asocian al objeto como etiqueta de datos
                        XmlEntorno.flgGestVistaCapturaGenerarNuevoRegistro("OBJETOS", vm.PropDatTxtCodigoEtiqueta, lobObjeto.Name);
                    }
                    fcvVerDatosEtiquetaSelect(true);
                }
            }
        }
        #endregion
        #region fcvSetObjComboBoxSelectBorder: Seleccionar propiedad Border (grosor)
        /// <summary>
        /// Seleccionar propiedad Border (grosor)
        /// </summary>
        private void fcvSetObjComboBoxSelectBorder()
        {
            if (guiRefObjetoSeleccionado != null)
            {
                var lcrclassObjeto = String.Empty;
                lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(guiRefObjetoSeleccionado).ToUpper();
                if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                {
                    EdtUtilidades.flgSetPropiedadBorderObjeto(guiRefObjetoSeleccionado, lcrclassObjeto, vm.PropTxtBorder);
                }
            }
        }
        #endregion
        #region fcvSetObjSeleccionPropiedadColor: Gestion seleccion color de objeto activo desde ventana
        /// <summary>
        /// Seleccion las propiedades de color desde ventana propiedades
        /// </summary>
        private void fcvSetObjSeleccionPropiedadColor(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            if (glgModoSetPropiedades == false)
            {
                //var luiObjeto = new UIElement();
                var luiObjeto = guiRefObjetoSeleccionado != null ? guiRefObjetoSeleccionado : gobRefPaginaSeleccionada as UIElement;


                var lcrclassObjeto = String.Empty;
                var lclColorObj = new EdtUtilidades.ObjetoPropiedadColor();

                lclColorObj.Fuente = cboPropForeground.SelectedColor;
                lclColorObj.Fondo = cboPropBackground.SelectedColor;
                lclColorObj.Bordes = cboPropBorderBrush.SelectedColor;
                // Actualizar Vista modelo
                vm.PropTxtForeground = lclColorObj.Fuente.ToString();
                vm.PropTxtBorderBrush = lclColorObj.Bordes.ToString();
                vm.PropTxtBackground = lclColorObj.Fondo.ToString();
                //Actualizar Entorno Xml
                XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Foreground", vm.PropTxtForeground);
                XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "BorderBrush", vm.PropTxtBorderBrush);
                XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Background", vm.PropTxtBackground);

                lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(luiObjeto).ToUpper();
                if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                {
                    EdtUtilidades.flgSetPropiedadColorObjeto(luiObjeto, lcrclassObjeto, lclColorObj);
                    if (lcrclassObjeto == "GROUPBOX" || lcrclassObjeto == "CANVAS" || lcrclassObjeto == "WRAPPANEL")
                    {
                        if (gcrTipoObjetoNivel == "PAGINA")
                        {
                            gobRefContenedorPaginaSeleccionada.Background = Brushes.Transparent;
                        }
                        if (gcrTipoObjetoNivel == "ZONA")
                        {
                            gobRefContenedorZonaSeleccionada.Background = Brushes.Transparent;
                        }
                        else if (gcrTipoObjetoNivel == "GRUPO")
                        {
                            gobRefContenedorGrupoSeleccionado.Background = Brushes.Transparent;
                        }
                    }
                }
            }
        }
        #endregion
        #region Gestion del tipo Fuente
        #region fcvSetObjChkFuente: Leer Estilo de la fuente desde los checkbox en Ventana propiedades
        /// <summary>
        /// Leer Estilo de la fuente desde los chkbox en Ventana propiedades
        /// </summary>
        private void fcvSetObjChkFuente(object sender, RoutedEventArgs e)
        {
            if (glgObjetosCargados == true && glgModoSetPropiedades == false)
            {
                fcvSetObjFuenteVentanaPropToVistaModelo();
                fcvSetObjComboBoxSelectPropiedadFuente();
            }
        }
        #endregion
        #region fcvSetObjComboBoxSelectPropiedadFuente: Seleccionar propiedad fuente (texto)
        /// <summary>
        /// Seleccionar propiedad fuente (texto)
        /// </summary>
        private void fcvSetObjComboBoxSelectPropiedadFuente()
        {
            if (guiRefObjetoSeleccionado != null)
            {
                var lcrclassObjeto = String.Empty;
                var lclFontObj = fobSetObjFuenteVentanaPropToClass();
                lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(guiRefObjetoSeleccionado).ToUpper();
                if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                {
                    EdtUtilidades.flgSetPropiedadFuenteObjeto(guiRefObjetoSeleccionado, lcrclassObjeto, lclFontObj);
                }
            }
        }
        #endregion
        #region fcvSetObjFuenteVentanaPropToVistaModelo: Leer Propiedades de fuente desde la ventana Propiedades y actualizar Vista Modelo
        /// <summary>
        /// Leer Propiedades de fuente desde la ventana Propiedades y actualizar Vista Modelo
        /// </summary>
        private void fcvSetObjFuenteVentanaPropToVistaModelo()
        {
            var lclFontObj = fobSetObjFuenteVentanaPropToClass();
            if (lclFontObj != null)
            {
                vm.PropTxtFontFamily = lclFontObj.FontFamily.ToString();
                vm.PropTxtFontSize = lclFontObj.FontSize.ToString();
                vm.PropTxtFontWeight = lclFontObj.FontWeight == FontWeights.Bold ? "Bold" : "Regular";
                vm.PropTxtFontStyle = lclFontObj.FontStyle == FontStyles.Italic ? "Italic" : "Normal";
                fcvSetObjPropiedadXmlEntornoFont();
            }
        }
        #endregion
        #region fcvSetObjPropiedadXmlEntornoFont: Actualizar las propiedades de Font en temporal XmlEntorno
        /// <summary>
        /// Actualizar las propiedades de Font en temporal XmlEntorno
        /// </summary>
        private void fcvSetObjPropiedadXmlEntornoFont()
        {
            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "FontFamily", vm.PropTxtFontFamily);
            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "FontStyle", vm.PropTxtFontStyle);
            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "FontSize", vm.PropTxtFontSize);
            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "FontWeight", vm.PropTxtFontWeight);
        }
        #endregion
        #region fobSetObjFuenteVentanaPropToClass: Lee Propiedades fuente desde ventana Propiedades y devuelve class ObjetoPropiedadFont
        /// <summary>
        /// Lee Propiedades fuente desde ventana Propiedades y devuelve class ObjetoPropiedadFont
        /// </summary>
        private EdtUtilidades.ObjetoPropiedadFont fobSetObjFuenteVentanaPropToClass()
        {
            VistaModeloObjetoActivo.ListaXmlValores lobListFontFamily = (VistaModeloObjetoActivo.ListaXmlValores)cboPropFontFamily.SelectedItem;
            VistaModeloObjetoActivo.ListaXmlValores lobListFontSize = (VistaModeloObjetoActivo.ListaXmlValores)cboPropCboFontSize.SelectedItem;

            var lclFontObj = new EdtUtilidades.ObjetoPropiedadFont();
            // Atributos de la fuente
            if (lobListFontFamily != null && lobListFontSize != null)
            {
                lclFontObj.FontFamily = new FontFamily(lobListFontFamily.Codigo);
                lclFontObj.FontSize = Convert.ToDouble(lobListFontSize.Codigo);
                lclFontObj.FontWeight = chkFuenteNegrita.IsChecked == true ? FontWeights.Bold : FontWeights.Regular;
                lclFontObj.FontStyle = chkFuenteCursiva.IsChecked == true ? FontStyles.Italic : FontStyles.Normal;
            }
            else
            {
                lclFontObj = null;
            }
            return lclFontObj;
        }
        #endregion
        #endregion
        #region fcvSetObjPropDatosActualizar: Actualizar Propiedades de Grupo Datos y otras
        /// <summary>
        /// <para>Actualizar Propiedades del grupo Datos y otras desde la ventaa propiedades</para>
        /// </summary>
        private void fcvSetObjPropDatosActualizar(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && guiRefObjetoSeleccionado != null)
                {
                    TextBox lobObjeto = (TextBox)sender;

                    switch (lobObjeto.Name)
                    {
                        case "txtpropValorDefault":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "ValorDefault", vm.PropDatTxtValorDefault);
                            break;

                        case "txtPropDatTxtRangoInicial":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RangoInicial", vm.PropDatTxtRangoInicial);
                            break;

                        case "txtPropDatTxtRangoFinal":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RangoFinal", vm.PropDatTxtRangoFinal);
                            break;

                        case "txtPropDatTxtNombreVariable":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "NombreVariable", vm.PropDatTxtNombreVariable);
                            break;

                        case "txtPropTxtRecursoArchivoTipo":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RecursoArchivoTipo", vm.PropTxtRecursoArchivoTipo);
                            break;

                        case "txtPropTxtRecursoArchivoCodigo":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RecursoArchivoCodigo", vm.PropTxtRecursoArchivoCodigo);
                            break;

                        case "txtPropTxtRecursoArchivoUri":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RecursoArchivoUri", vm.PropTxtRecursoArchivoUri);
                            break;

                        case "txtPropTxtRecursoArchivoNombre":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RecursoArchivoNombre", vm.PropTxtRecursoArchivoNombre);
                            break;

                    }

                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjPropDatosActualizar");
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // SELECCIONAR PLANTILLA DESDE PESTAÑA SERVICIOS
        //------------------------------------------------------------
        #region fcvCmdAddMenuActividadMedica: Adicionar Grupos comandos actividad medica
        /// <summary>
        /// <para>Adicionar Grupos comandos actividad medica segun perfil de usuario activo</para>
        /// </summary>
        public void fcvCmdAddMenuActividadMedica()
        {
            tmpMenuActMedGru = ModeloHclformatvistma.flsVistaMenuGrupoActivMedicasPerfil(oApp.gcrUsuCodigoPerfil);
            if (tmpMenuActMedGru != null)
            {
                var i = 1;
                foreach (var lobReg in tmpMenuActMedGru)
                {
                    var lobOpcion = new ActividadesMedicasMenu();

                    if (i == 1) { lobOpcion.fcvOpcActivarVistaDetalles("+"); }

                    lobOpcion.CodigoGrupo = lobReg.Hcl_codreg_hcra;
                    lobOpcion.txtTitulo.Text = lobReg.Hcl_desgru_hcra;
                    i++;

                    // Guardar referencia del contenedor en lista
                    lobReg.RefObjeto = lobOpcion;

                    this.stkMenuServMedicos.Children.Add(lobOpcion);
                }
                // Cargar lista detalles actividades medicas
                tmpMenuActMedCmd = ModeloHcltiporegactiv.flsVistaMenuDetallesActivMedicasPerfil(oApp.gcrUsuCodigoPerfil);
                fcvCmdAddComandosActividadMedica("+");
            }
        }
        #endregion
        #region fcvCmdAddComandosActividadMedica: Adicionar Boton para actividad medica
        /// <summary>
        /// <para>Adicionar Boton para actividades medicas asociadas al Menu servicios</para>
        /// <para>tcrAccion: "+" = registrar eventos "-" = quitar eventos </para>
        /// </summary>
        public void fcvCmdAddComandosActividadMedica(String tcrAccion)
        {
            if (tmpMenuActMedCmd == null) { return; }

            var lcrUri = "/GestorReportes;component/Imagenes/";
            var lcrCodigoGrupo = "XX";
            ActividadesMedicasMenu lobRefGrupo = null;

            foreach (var lobItem in tmpMenuActMedCmd)
            {

                if (tcrAccion == "+")
                {
                    // Buscar referencia objeto contenedor del grupo
                    #region referencia del grupo
                    if (lobItem.Hcl_codreg_hcra != lcrCodigoGrupo)
                    {
                        lcrCodigoGrupo = lobItem.Hcl_codreg_hcra;
                        lobRefGrupo = (tmpMenuActMedGru.FirstOrDefault(x => x.Hcl_codreg_hcra == lcrCodigoGrupo).RefObjeto) as ActividadesMedicasMenu;
                    }
                    #endregion

                    var lobBoton = new ActividadMedicaCmd();

                    lobBoton.borFondoImg.Background = EdtUtilidades.SetSolidColorBrush(lobItem.Hcl_icolor_hcca);
                    lobBoton.imgComando.Source      = new BitmapImage(new Uri(lcrUri + lobItem.Hcl_imagen_hcca, UriKind.RelativeOrAbsolute));
                    lobBoton.txtTexto.Text          = lobItem.Hcl_desreg_hcca;
                    lobBoton.CodigoActividad        = lobItem.Hcl_codreg_hcca;
                    lobBoton.CodigoGrupo            = lobItem.Hcl_codreg_hcra;
                    lobItem.Hcl_desreg_hcca         = lobItem.Hcl_desreg_hcca.ToLower();

                    lobBoton.cmdComando.Click += new RoutedEventHandler(fcvCmdSelectActividadMedica);
                    lobItem.RefObjeto = lobBoton;

                    // Agregar al contenedor del grupo
                    if (lobRefGrupo != null) { lobRefGrupo.wraDetalles.Children.Add(lobBoton); }
                }
                else
                {
                    ActividadMedicaCmd lobRefe = lobItem.RefObjeto as ActividadMedicaCmd;
                    lobRefe.cmdComando.Click -= new RoutedEventHandler(fcvCmdSelectActividadMedica);
                }
            }
        }
        #endregion
        #region fcvCmdSelectActividadMedica: Seleccionar un formato de actividad medica
        private void fcvCmdSelectActividadMedica(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobTile = lobGrid.Parent as ActividadMedicaCmd;

            if (!String.IsNullOrWhiteSpace(lobTile.CodigoActividad))
            {
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(lobTile.CodigoActividad);
                if (lobReg != null && lobReg.grp_idepla_grpl != "NA")
                {
                    //  aqui debe ir la validacion de pertinencia sexo y edad 
                    XmlEntorno.glgNuevoRegistroPlantilla      = true;
                    XmlEntorno.gcrIdRegHistActiviMedicDescrip = lobReg.hcl_desreg_hcca;
                    XmlEntorno.gcrIdRegHistActiviMedicCodigo  = lobReg.hcl_codreg_hcca;
                    fcvCargarVistaPlantillaNuevo(lobReg.grp_idepla_grpl);
                    glgRefreshVistaPlntilla = true;
                }
            }
        }
        #endregion
        // Buscar formatos
        #region Filtrar Vista Browser
        private void fcCrtBuscarLoadedCmd(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvCmdFiltroTextChanged);
        }
        private void fcvCmdFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lobTexto = (TextBox)sender;
            fcvCmdMenuVistaFiltro(lobTexto.Text);
        }
        #endregion
        #region fcvCmdMenuVistaFiltro: filtro para localizar formatos en menu
        /// <summary>
        /// <para>filtro para localizar formatos en menu</para>
        /// </summary>
        public void fcvCmdMenuVistaFiltro(String tcrTexto)
        {
            if (tmpMenuActMedGru == null || tmpMenuActMedGru.Count == 0) { return; }

            // ocultar titulos grupos 
            foreach (var lobReg in tmpMenuActMedGru)
            {
                // Utilizar el campo estado para activar/ocultar vista
                lobReg.Hcl_estreg_hcra = "2";
            }

            // Filtrar datos
            var lcrTexto = tcrTexto.ToLower();
            foreach (var lobReg in tmpMenuActMedCmd)
            {
                var lobTile = lobReg.RefObjeto as ActividadMedicaCmd;

                if (lobTile != null)
                {
                    lobTile.Visibility = Visibility.Visible;

                    if (!String.IsNullOrWhiteSpace(tcrTexto))
                    {
                        if (!lobReg.Hcl_desreg_hcca.Contains(lcrTexto))
                        {
                            lobTile.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            tmpMenuActMedGru.FirstOrDefault(x => x.Hcl_codreg_hcra == lobReg.Hcl_codreg_hcra).Hcl_estreg_hcra = "1";
                        }
                    }
                    else
                    {
                        tmpMenuActMedGru.FirstOrDefault(x => x.Hcl_codreg_hcra == lobReg.Hcl_codreg_hcra).Hcl_estreg_hcra = "1";
                    }
                }
            }
            // Mostrar/ocultar titulos de grupos
            foreach (var lobReg in tmpMenuActMedGru)
            {
                var lobObj = lobReg.RefObjeto as ActividadesMedicasMenu;
                if (lobObj != null)
                {
                    lobObj.Visibility = lobReg.Hcl_estreg_hcra == "1" ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }
        #endregion
        // Desplegar/Colapsar vistas
        #region fcvCmdDesplMenuActividadMedica: Desplegar todo el menu actividad medica
        private void fcvCmdDesplMenuActividadMedica(object sender, RoutedEventArgs e)
        {
            fcvCmdDesplegMenuActividadMedica("+");
        }
        #endregion
        #region fcvCmdColapsMenuActividadMedica: Colapsar todo el menu actividad medica
        private void fcvCmdColapsMenuActividadMedica(object sender, RoutedEventArgs e)
        {
            fcvCmdDesplegMenuActividadMedica("-");
        }
        #endregion
        #region fcvCmdDesplegMenuActividadMedica: Desplegar menu actividad medica
        /// <summary>
        /// <para>Desplegar menu actividad medica</para>
        /// tcrAccion: "+" = Desplegar  "-" = Colapsar
        /// </summary>
        public void fcvCmdDesplegMenuActividadMedica(String tcrAccion)
        {
            if (tmpMenuActMedGru != null)
            {
                foreach (var lobReg in tmpMenuActMedGru)
                {
                    var lobOpcion = lobReg.RefObjeto as ActividadesMedicasMenu;
                    if (lobOpcion != null)
                    {
                        lobOpcion.fcvOpcActivarVistaDetalles(tcrAccion);
                    }
                }
            }
        }
        #endregion
        // Funcion seleccion actividad - en desuso
        #region fcvPlanManejoSeleccionMenu: seleccionar el tipo de plantilla para abrir
        /// <summary>
        /// <para>seleccionar el tipo de plantilla para abrir y generar nuevo registro</para>
        /// </summary>
        private void fcvPlanManejoSeleccionMenu(object sender, RoutedEventArgs e)
        {
            var lcrServicio = String.Empty;
            var loPlant = String.Empty;
            var lobBoton = sender as Button;

            #region Seleccion Menu
            switch (lobBoton.Name)
            {
                case "cmdPlanIntOrdenServicios":
                    //- Ordenes de servicios
                    lcrServicio = "HCL-CAPTURA-SERV";
                    break;

                case "cmdPlanExtFormula":
                    //- Ordenes de servicios (formula medica)
                    lcrServicio = "HCL-CAPTURA-FMED";
                    break;

                case "cmdPlanIntEvolucion":
                    //- Evoluciones médicas
                    lcrServicio = "HCL-CAPTURA-EVOL";
                    break;

                case "cmdPlanIntNotaEnfermeria":
                    //- Notas de enfermeria
                    lcrServicio = "HCL-CAPTURA-NENF";
                    break;

                case "cmdPlanIntHojaConsumo":
                    //- Hoja de consumo
                    lcrServicio = "HCL-CAPTURA-HCON";
                    break;

                case "cmdPlanIntLiquidosBliq":
                    //- Liquidos Adminstrados
                    lcrServicio = "HCL-CAPTURA-BLIQ";
                    break;

                case "cmdPlanIntSignosVitales":
                    //- Toma de signos vitales 
                    lcrServicio = "HCL-CAPTURA-SVIT";
                    break;

                case "cmdPlanIntEpicrisis":
                    //- Epicrisis
                    lcrServicio = "HCL-CAPTURA-EPIC";
                    break;

                case "cmdOdnApertura":
                    //- Apertura tratamiento odontologico
                    lcrServicio = "HCL-CAPTURA-ODAP";
                    break;

                case "cmdRIMG":
                    //- Recursos imagen
                    lcrServicio = "HCL-RECURSOS-IMG";
                    break;

                case "cmdRPDF":
                    //- Recursos archivo pdf
                    lcrServicio = "HCL-RECURSOS-PDF";
                    break;

                case "cmdRVID":
                    //- Recursos Videos
                    lcrServicio = "HCL-RECURSOS-VID";
                    break;
            }
            #endregion
            if (!String.IsNullOrWhiteSpace(lcrServicio))
            {
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(lcrServicio);
                if (lobReg != null && lobReg.grp_idepla_grpl != "NA")
                {
                    XmlEntorno.glgNuevoRegistroPlantilla = true;
                    fcvCargarVistaPlantillaNuevo(lobReg.grp_idepla_grpl);
                    glgRefreshVistaPlntilla = true;
                }
            }
        }
        #endregion
        #region fcvResizePaginaControlCaptura: Reajustar tamaño pagina control captura
        /// <summary>
        /// <para>Reajustar tamaños de las paginas donde existan un control captura</para>
        /// <para>para permitir ver toos los registros existentes dentro del control</para>
        /// </summary>
        public void fcvResizePaginaControlCaptura()
        {
            List<ClassXmlPropObjeto> tobTemp = XmlEntorno.fobRegSelectReferenciaArchivo("OBJETOS");

            foreach (var lobItem in tobTemp)
            {
                #region CONTROLCAPTURA
                if (lobItem.TipoObjeto == "CONTROLCAPTURA")
                {
                    ControlCaptura lobControlCaptura = lobItem.RefObjeto as ControlCaptura;
                    var ldulHeight = lobControlCaptura.stkContenedor.ActualHeight;
                    if (ldulHeight > 800)
                    {
                        var lobRegZona = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobItem.ObjetoParentZona).FirstOrDefault();
                        var lobZona = lobRegZona.RefObjeto as GroupBox;
                        var lobCZona = lobRegZona.RefContenedorObjeto as Canvas;

                        var lobRegPagina = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobItem.ObjetoParentPagina).FirstOrDefault();
                        var lobPagina = lobRegPagina.RefObjeto as Canvas;
                        var lobCPagina = lobRegPagina.RefContenedorObjeto as WrapPanel;

                        lobPagina.Height = ldulHeight + 280;
                        XmlEntorno.SetPropiedadMargenContenedorPagina(ref lobPagina, ref lobCPagina);

                        lobZona.Height = lobCPagina.Height;
                        lobCZona.Height = lobCPagina.Height;
                        lobControlCaptura.Height = lobControlCaptura.stkContenedor.ActualHeight + 80;

                    }
                }
                #endregion
            }
        }
        #endregion
        //------------------------------------------------------------
        // ELIMINAR REGISTRO ACTIVO H.C / PAGINAS ZONAS Y OBJETOS 
        //------------------------------------------------------------
        #region Eliminar registro del historial
        #region fcvCmdEliminarRegistroHc: Eliminar registro activo  y con estado abierto desde historial clinico
        /// <summary>
        /// Eliminar registro activo  y con estado abierto desde historial clinico
        /// </summary>
        private void fcvCmdEliminarRegistroHc(object sender, System.EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Eliminar formato activo del historial?", "Galeno Versión 4.0", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (HclModeloHistorialEventos.flgEliminar(vm.G1Hcl_nroreg_hcev))
                {
                    if (XmlEntorno.gobRegHistorialActivo.Hcl_archiv_hcev != "XM")
                    {
                        // los datos estan guardados en historicos no en XML
                        XmlEntorno.fcvGTablaEliminarHistDatosDigitados(XmlEntorno.gobRegHistorialActivo.Hcl_archiv_hcev);
                    }
                    // para que se cargue la admision y el historial
                    gcrParamTipoId = gcrParamTipoIdBak;
                    gcrParamIdRegistro = gcrParamIdRegistroBak;
                    vm.G1Hcl_nroreg_hcev = String.Empty;

                    fcvLimpiarVista();
                }
            }
        }
        #endregion
        #region fcvCmdEliminarObjeto: Iniciar el evento eliminar objeto
        /// <summary>
        /// Iniciar el evento eliminar objeto 
        /// </summary>
        private void fcvCmdEliminarObjeto(object sender, System.EventArgs e)
        {
            if (guiRefObjetoSeleccionado != null)
            {
                MessageBoxResult result = MessageBox.Show("Eliminar el objeto?", "Galeno Versión 4.0", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    fcvCmdEliminarObjetoTipo(guiRefObjetoSeleccionado as FrameworkElement, "ELIMINADO", 0);
                    // informar al vista modelo para activar botones
                    vm.gnuTopeIdAccionEdicion = XmlEntorno.gnuTopeIdAccionEdicion;
                    vm.gnuIdAccionEdicionPuntero = XmlEntorno.gnuIdAccionEdicionPuntero;

                    actualizar();
                }
            }
        }
        #endregion
        #region fcvCmdEliminarObjetoTipo: Accion eliminar objeto
        /// <summary>
        /// Accion eliminar objeto, cuando tnuIdAccion es cero se registra la nueva accion.
        /// </summary>
        private void fcvCmdEliminarObjetoTipo(FrameworkElement tobObjeto, String tcrAccion, int tnuIdAccion)
        {
            if (tobObjeto != null)
            {
                var lnuIdAccion = tnuIdAccion;
                var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", tobObjeto.Name).FirstOrDefault();
                if (lobObjeto.ObjetoModo.Substring(0, 11).ToUpper() == "CAPTURA-EDT")
                {
                    if (lobObjeto.CodigoEtiqueta != "NA") //  tiene etiqueta de datos
                    {
                        XmlEntorno.tmpCapturaEtiqueta = null;
                        XmlEntorno.flgEdtAccionEliminarDatosEtiqueta("DATOS", lobObjeto.Name);
                        fcvActivarVistaEtiquetaEstado(false);
                    }

                    if (tnuIdAccion <= 0)
                    {
                        lnuIdAccion = XmlEntorno.fnuEdtAccionAddObjetoPila(tcrAccion, lobObjeto);
                    }
                    //- eliminar el registro del temporal
                    XmlEntorno.fobEdtAccionEliminarObjetos("OBJETOS", lobObjeto.Name, tcrAccion, lnuIdAccion);
                    // eliminar fiscamente
                    Canvas lobContenedor = tobObjeto.Parent as Canvas;
                    tobObjeto.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                    tobObjeto.MouseDown -= new MouseButtonEventHandler(fcvVerDatosEtiquetaMouseDown);
                    lobContenedor.Children.Remove(tobObjeto);

                    fcvCmdEliminarObjetoQuitarReferencia(lobObjeto.TipoObjeto.ToUpper());
                }
            }
        }
        #endregion
        #region fcvCmdEliminarObjetoQuitarReferencia: Quitar las referencias de seleccion
        /// <summary>
        /// <para>Quitar las referencias de seleccion de objeto al eliminar</para>
        /// </summary>
        private void fcvCmdEliminarObjetoQuitarReferencia(String tcrTipoObjeto)
        {
            switch (tcrTipoObjeto)
            {
                case "PAGINA": // Eliminar pagina
                    XmlEntorno.refTreeObj.Pagina = null;
                    XmlEntorno.refTreeObj.ContenedorPagina = null;
                    XmlEntorno.refTreeObj.Zona = null;
                    XmlEntorno.refTreeObj.ContenedorZona = null;
                    XmlEntorno.refTreeObj.Grupo = null;
                    XmlEntorno.refTreeObj.ContenedorGrupo = null;
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
                    //-Referencia a objetos
                    gobRefPaginaSeleccionada = null;
                    gobRefZonaSeleccionada = null;
                    gobRefGrupoSeleccionado = null;
                    gobRefContenedorPaginaSeleccionada = null;
                    gobRefContenedorZonaSeleccionada = null;
                    gobRefContenedorGrupoSeleccionado = null;
                    break;

                case "ZONA": // Eliminar Zona
                    XmlEntorno.refTreeObj.Zona = null;
                    XmlEntorno.refTreeObj.ContenedorZona = null;
                    XmlEntorno.refTreeObj.Grupo = null;
                    XmlEntorno.refTreeObj.ContenedorGrupo = null;
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
                    //-Referencia a objetos
                    gobRefZonaSeleccionada = null;
                    gobRefGrupoSeleccionado = null;
                    gobRefContenedorZonaSeleccionada = null;
                    gobRefContenedorGrupoSeleccionado = null;
                    break;

                case "GRUPO":
                    XmlEntorno.refTreeObj.Grupo = null;
                    XmlEntorno.refTreeObj.ContenedorGrupo = null;
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
                    //-Referencia a objetos
                    gobRefGrupoSeleccionado = null;
                    gobRefContenedorGrupoSeleccionado = null;
                    break;

                case "MULTIGROUPRADIOBUTTON":
                    XmlEntorno.refTreeObj.Grupo = null;
                    XmlEntorno.refTreeObj.ContenedorGrupo = null;
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
                    //-Referencia a objetos
                    gobRefGrupoSeleccionado = null;
                    gobRefContenedorGrupoSeleccionado = null;
                    break;

                case "MULTIGROUPCHKBOX":
                    XmlEntorno.refTreeObj.Grupo = null;
                    XmlEntorno.refTreeObj.ContenedorGrupo = null;
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
                    //-Referencia a objetos
                    gobRefGrupoSeleccionado = null;
                    gobRefContenedorGrupoSeleccionado = null;
                    break;

            }
            guiRefObjetoSeleccionado = null;
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // GESTION DESHACER CAMBIOS Y CANCELAR ADICIONAR OBJETO
        //------------------------------------------------------------
        #region Gestion deshacer cambios y cancelar adicion de objetos
        #region fcvCmdDesHacerAtras: Deshacer los cambios hacia atrás
        /// <summary>
        /// <para>Deshacer los cambios regresando el puntero (flecha izquierda)</para>
        /// </summary>
        private void fcvCmdDesHacerAtras(object sender, RoutedEventArgs e)
        {
            var lnuIdAccion = XmlEntorno.fnuEdtAccionDesHacer();
            if (lnuIdAccion > 0)
            {
                var lobRegistro = XmlEntorno.fobRegSelectEdtAccion(lnuIdAccion);

                if (lobRegistro != null)
                {
                    switch (lobRegistro.Accion)
                    {
                        case "ADICIONADO": // deshace Adicionar es eliminar el objeto
                            var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobRegistro.Name).FirstOrDefault().RefObjeto as FrameworkElement;
                            fcvCmdEliminarObjetoTipo(lobObjeto, lobRegistro.Accion, lnuIdAccion);
                            break;

                        case "ELIMINADO": // Adicionar el objeto eliminado, crear de nuevo
                            fcvAdicionarManejadorPaginasyZonas("AUXILIAR", "+");
                            break;
                    }
                }
            }
            actualizar();
            // informar al vista modelo para activar botones
            vm.gnuTopeIdAccionEdicion = XmlEntorno.gnuTopeIdAccionEdicion;
            vm.gnuIdAccionEdicionPuntero = XmlEntorno.gnuIdAccionEdicionPuntero;
        }
        #endregion
        #region fcvCmdDesHacerAdelante: Rehacer cambios hacia adelante
        /// <summary>
        /// <para>Rehacer cambios mover puntero hacia adelante (flecha derecha)</para>
        /// </summary>
        private void fcvCmdDesHacerAdelante(object sender, RoutedEventArgs e)
        {
            var lnuIdAccion = XmlEntorno.fnuEdtAccionReHacer();
            if (lnuIdAccion > 0)
            {
                var lobRegistro = XmlEntorno.fobRegSelectEdtAccion(lnuIdAccion);

                if (lobRegistro != null)
                {
                    switch (lobRegistro.Accion)
                    {
                        case "ADICIONADO": // Rehacer Adicionar (generar el objeto nuevamente)
                            fcvAdicionarManejadorPaginasyZonas("AUXILIAR", "+");
                            break;

                        case "ELIMINADO": // Volver a eliminar el objeto, se supone que se recreo al deshacer a la izquierda

                            var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobRegistro.Name).FirstOrDefault().RefObjeto as FrameworkElement;
                            fcvCmdEliminarObjetoTipo(lobObjeto, lobRegistro.Accion, lnuIdAccion);
                            break;
                    }
                }
            }
            actualizar();
            // informar al vista modelo para activar botones
            vm.gnuTopeIdAccionEdicion = XmlEntorno.gnuTopeIdAccionEdicion;
            vm.gnuIdAccionEdicionPuntero = XmlEntorno.gnuIdAccionEdicionPuntero;
        }
        #endregion
        private void actualizar()
        {
            vm.TmpEliminados = new List<ClassXmlPropObjeto>();
            vm.TmpEliminados = XmlEntorno.tmpObjetosEliminado;
            vm.TmpAccion = new List<ClassXmlPropObjeto>();
            vm.TmpAccion = XmlEntorno.tmpObjetosAccion;
            //txtPuntero.Text = gobXmlEntorno.gnuIdAccionEdicionPuntero.ToString();
        }

        #region fnuCmdDesHacerAddRegistroPila: Registrar la accion en la pila
        /// <summary>
        /// <para>Registrar la accion en la pila que gestiona los cambios en objetos</para>
        /// <para>Retorna el Id numerico generado para la accion registrada.</para>
        /// </summary>
        private int fnuCmdDesHacerAddRegistroPila(String tcrAccion, ClassXmlPropObjeto tobRegistro)
        {
            var lnuIdAccion = XmlEntorno.fnuEdtAccionAddObjetoPila(tcrAccion, tobRegistro);
            // informar al vista modelo para activar botones
            vm.gnuTopeIdAccionEdicion = XmlEntorno.gnuTopeIdAccionEdicion;
            vm.gnuIdAccionEdicionPuntero = lnuIdAccion;
            actualizar();
            return lnuIdAccion;
        }
        #endregion
        #region fcvCmdDesHacerAddObjeto: Cancelar adicionar Objeto
        /// <summary>
        /// <para>Cancelar adicionar Objeto</para>
        /// </summary>
        private void fcvCmdDesHacerAddObjeto(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "";
            glgNuevoObjetoCrear = false;
            fcvRestablecerPunteroMouse();
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // MOSTRAR HISTORIAL, PROPIEDADES, CAPA ETIQUETAS y BARRA DE ESTADO
        //------------------------------------------------------------
        #region Ventana Menu Superior
        #region fcvActivarVistaMenuSuperior: Mostrar u Ocultar la Ventana Munu Superior
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Munu Superior desde click</para>
        /// </summary>
        private void fcvActivarVistaMenuSuperior(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaMenuSuperior();
        }
        #endregion
        #region fcvActivarVistaMenuSuperiorMouseEnter: Mostrar Ventana Menu superior con gesto en la parte superior
        /// <summary>
        /// <para>Mostrar Ventana Menu superior con gesto en la parte superior de la pnatalla</para>
        /// </summary>
        private void fcvActivarVistaMenuSuperiorMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaMenuSuperiorVisible == false)
            {
                fcvActivarVistaMenuSuperior();
            }
        }
        #endregion
        #region fcvActivarVistaMenuSuperiorTouchEnter: Mostrar Ventana Menu superior con gesto en la parte superior de la pnatalla
        /// <summary>
        /// <para>Mostrar Ventana Menu superior con gesto en la parte superior de la pnatalla</para>
        /// </summary>
        private void fcvActivarVistaMenuSuperiorTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaMenuSuperiorVisible == false)
            {
                fcvActivarVistaMenuSuperior();
            }
        }
        #endregion
        #region fcvActivarVistaMenuSuperior: Mostrar u Ocultar la Ventana Menu superior
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Menu superior</para>
        /// </summary>
        private void fcvActivarVistaMenuSuperior()
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaMenuSuperiorVisible == false)
            {
                luxAnimacion.To = 0; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaMenuSuperiorVisible = true;
            }
            else
            {
                luxAnimacion.To = -150; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaMenuSuperiorVisible = false;
            }
            this.grdMenuSuperior.BeginAnimation(Canvas.TopProperty, luxAnimacion);
        }
        #endregion
        #endregion
        #region Ventana Historial
        #region fcvActivarVistaHistorial: Mostrar u Ocultar la Ventana Historial del paciente click boton
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Historial del paciente desde click</para>
        /// </summary>
        private void fcvActivarVistaHistorial(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaHistorial();
        }
        #endregion
        #region fcvActivarVistaHistorialMouseEnter: Mostrar Ventana Historial del paciente gesto en la izquierda
        /// <summary>
        /// <para>Mostrar Ventana Historial del paciente con gesto en la izquierda de la pantalla</para>
        /// </summary>
        private void fcvActivarVistaHistorialMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaHistorialVisible == false)
            {
                fcvActivarVistaHistorial();
            }
        }
        #endregion
        #region fcvActivarVistaHistorialTouchEnter: Mostrar Ventana Historial del paciente gesto en la izquierda
        /// <summary>
        /// <para>Mostrar Ventana Historial del paciente con gesto en la izquierda de la pantalla</para>
        /// </summary>
        private void fcvActivarVistaHistorialTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaHistorialVisible == false)
            {
                fcvActivarVistaHistorial();
            }
        }
        #endregion
        #region fcvActivarVistaHistorial: Mostrar u Ocultar la Ventana Historial del paciente
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Historial del paciente</para>
        /// </summary>
        private void fcvActivarVistaHistorial()
        {
            if (glgVistaPropVisible == true)
            {
                fcvActivarVistaPropiedades();
            }
            this.objHistCortina.Visibility = Visibility.Visible;
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaHistorialVisible == false)
            {
                luxAnimacion.To = 1; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                //glgVistaHistorialAnclada = false;
                glgVistaHistorialVisible = true;
            }
            else
            {
                luxAnimacion.To = -630; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaHistorialVisible = false;
            }
            this.grdMenuHistorial.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
        #endregion
        #region Ventana Propiedades
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades, clic en boton
        /// </summary>
        private void fcvActivarVistaPropiedades(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaPropiedades();
        }
        #region fcvActivarVistaPropiedadesMouseEnter: Mostrar Ventana Propiedades gesto en la derecha
        /// <summary>
        /// <para>Mostrar Ventana Propiedades con gesto en la derecha de la pantalla</para>
        /// </summary>
        private void fcvActivarVistaPropiedadesMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaPropVisible == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaPropiedadesTouchEnter: Mostrar Ventana Propiedades gesto en la derecha
        /// <summary>
        /// <para>Mostrar Ventana Propiedades con gesto en la derecha de la pantalla</para>
        /// </summary>
        private void fcvActivarVistaPropiedadesTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaPropVisible == false)
            {
                fcvActivarVistaPropiedades();
            }
        }
        #endregion
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// </summary>
        private void fcvActivarVistaPropiedades()
        {
            if (glgVistaHistorialVisible == true)
            {
                fcvActivarVistaHistorial();
            }
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropVisible == false)
            {
                luxAnimacion.To = -355; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropAnclada = false;
                glgVistaPropVisible = true;
            }
            else
            {
                luxAnimacion.To = 150; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropVisible = false;
                if (glgVistaPropAnclada == true)
                {
                    fcvAnclarVentanPropiedades();
                }

            }
            this.grdMenuPropideades.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
            //this.lobCrtNotifi.Visibility = glgVistaPropVisible == false ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion
        #endregion
        #region fcvAnclarVentanPropiedades: Anclar la Ventan de propiedades y herramientas
        /// <summary>
        /// fcvAnclarVentanPropiedades: Click para anclar o desanclar ventana propiedades
        /// </summary>
        private void fcvAnclarVentanPropiedades(object sender, RoutedEventArgs e)
        {
            fcvAnclarVentanPropiedades();
        }
        /// <summary>
        /// fcvAnclarVentanPropiedades: Anclar o desanclar la ventan de propiedades
        /// </summary>
        private void fcvAnclarVentanPropiedades()
        {
            if (glgVistaPropAnclada == false)
            {
                if (glgVistaPropVisible == false)
                {
                    fcvActivarVistaPropiedades();
                }
                glgVistaPropAnclada = true;
                PanelScroll.Margin = new Thickness(10, 14, 436, 10);
                wraPlantilla.Margin = new Thickness(10, 0, 0, 0);
            }
            else
            {
                glgVistaPropAnclada = false;
                PanelScroll.Margin = new Thickness(10, 10, 10, 10);
                wraPlantilla.Margin = new Thickness(10, 0, 0, 0);
                if (glgVistaPropVisible == true)
                {
                    fcvActivarVistaPropiedades();
                }
            }
        }
        #endregion
        #region fcvClickTabsPropieades: Click en un tabs de la ventana propiedades
        /// <summary>
        /// fcvClickTabsPropieades: Click en un tabs de la ventana propiedades
        /// </summary>
        private void fcvClickTabsPropieades(object sender, RoutedEventArgs e)
        {
            lblVPropiedades.Text = "Propiedades c";
            TabItem lobj = sender as TabItem;
            if (lobj.Name == "pagHerramientas")
            {
                lblVPropiedades.Text = "Herramientas";
            }
        }
        #endregion
        #endregion
        #region Capa Etiquetas
        #region fcvVerDatosEtiquetaMouseDown: Gestion para mostrar datos de etiqueta en capa
        /// <summary>
        /// <para>Gestion para mostrar datos de etiqueta en capa</para>
        /// </summary>
        private void fcvVerDatosEtiquetaMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Buscar los datos de la etuqueta y mostrar la capa
            //MessageBox.Show("mostrar la capa");
            fcvVerDatosEtiquetaSelect(true);
        }
        #endregion
        #region fcvVerDatosEtiquetaSelect: Mostrar la vista etiqueta con los datos
        /// <summary>
        /// <para>tlgActivarVista: True=Mostrar la Capa automaticamente False= No mostra la capa automaticamente</para>
        /// <para>Mostrar la vista etiqueta con los datos existentes</para> 
        /// </summary>
        private void fcvVerDatosEtiquetaSelect(bool tlgActivarVista)
        {
            if (guiRefObjetoSeleccionado != null)
            {
                var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", ((FrameworkElement)guiRefObjetoSeleccionado).Name).FirstOrDefault();
                if (lobObjeto != null)
                {
                    if (flgVerificarEtiquetaSelect(guiRefObjetoSeleccionado))
                    {
                        XmlEntorno.flgGestVistaVerObjetosPlantilla("OBJETOS", "VP", "ETIQUETA", lobObjeto.CodigoEtiqueta);
                        fcvActivarVistaEtiquetaEstado(tlgActivarVista);
                    }
                    else
                    {
                        if (lobObjeto.Navegador == "ESCRITORIO")
                        {
                            fcvActivarVistaEtiquetaEstado(false);
                        }
                    }
                }
            }
        }
        #endregion
        #region flgVerificarEtiquetaSelect: Verificar si el objeto es una etiqueta con datos
        /// <summary>
        /// <para>Verifica que el objeto seleccionado sean una etiqueta con datos</para> 
        /// </summary>
        private bool flgVerificarEtiquetaSelect(UIElement tobObjeto)
        {
            var llgreturn = false;
            if (tobObjeto != null)
            {
                var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", ((FrameworkElement)tobObjeto).Name).FirstOrDefault();
                if (lobObjeto != null)
                {
                    if (lobObjeto.Navegador == "ESCRITORIO")
                    {
                        this.cmdEtiqueta.IsEnabled = false;
                        if (XmlEntorno.flgGestVistaSetVistaValorDigitadosObjetos(lobObjeto.Name, "ETIQUETA"))
                        {
                            this.cmdEtiqueta.IsEnabled = true;
                            llgreturn = true;
                        }
                    }
                }
            }
            return llgreturn;
        }
        #endregion
        #region fcvActivarEtiqueta: Mostrar u Ocultar Vista Capa Etiqueta
        /// <summary>
        /// <para>Mostrar u Ocultar Vista Capa Etiqueta</para> 
        /// </summary>
        private void fcvActivarEtiqueta(object sender, RoutedEventArgs e)
        {
            if (glgVistaEtiquetaEstadoVisible == false)
            {
                fcvVerDatosEtiquetaSelect(true);
            }
            else
            {
                fcvActivarVistaEtiquetaEstado(false);
            }
        }
        #endregion
        #region fcvActivarVistaEtiquetaEstado: Mostrar u Ocultar Vista Capa Etiqueta
        /// <summary>
        /// <para>Mostrar u Ocultar Vista Capa Etiqueta</para> 
        /// </summary>
        private void fcvActivarVistaEtiquetaEstado(bool tlgModo)
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaEtiquetaEstadoVisible == false)
            {
                if (tlgModo == true)
                {
                    luxAnimacion.To = -340; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                    glgVistaEtiquetaEstadoVisible = true;
                    this.grdEtiqueta.BeginAnimation(Canvas.TopProperty, luxAnimacion);
                }
            }
            else
            {
                if (tlgModo == false)
                {
                    luxAnimacion.To = 8; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                    glgVistaEtiquetaEstadoVisible = false;
                    this.grdEtiqueta.BeginAnimation(Canvas.TopProperty, luxAnimacion);
                }
            }
        }
        #endregion
        #endregion
        #region Barra de Estado
        #region fcvActivarBarraEstado: Mostrar u Ocultar Barra de estado
        /// <summary>
        /// <para>Mostrar u Ocultar Barra de estado</para> 
        /// </summary>
        private void fcvActivarBarraEstado(object sender, RoutedEventArgs e)
        {
            if (glgVistaBarraEstadoVisible == false)
            {
                fcvActivarBarraEstado(true);
            }
            else
            {
                fcvActivarBarraEstado(false);
            }
        }
        #endregion
        #region fcvActivarBarraEstado: Mostrar u Ocultar la barra de estado
        /// <summary>
        /// <para>Mostrar u Ocultar Barra de estado</para> 
        /// </summary>
        private void fcvActivarBarraEstado(bool tlgModo)
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaBarraEstadoVisible == false)
            {
                if (tlgModo == true)
                {
                    luxAnimacion.To = -70; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(0));
                    glgVistaBarraEstadoVisible = true;
                }
            }
            else
            {
                if (tlgModo == false)
                {
                    luxAnimacion.To = 8; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                    glgVistaBarraEstadoVisible = false;
                    //this.grdBarraEstado.BeginAnimation(Canvas.TopProperty, luxAnimacion);
                }
            }
            //this.grdBarraEstado.BeginAnimation(Canvas.TopProperty, luxAnimacion);
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // FUNCIONES DE UTILIDAD
        //------------------------------------------------------------
        #region fcvGestionReiniciarVariables: Reiniciar Variables de Gestion
        /// <summary>
        /// Reiniciar Variables de Gestion
        /// </summary>
        private void fcvGestionReiniciarVariables()
        {
            //- Referencias a objetos
            vm.G1Hcl_nroreg_hcev        = String.Empty;
            vm.gcrTipoContenedorActivo  = String.Empty;
            vm.GlgSIS_ModoVistaObjetos  = false;
            vm.tmpLogErrores            = new List<LogsErrores>();
            vm.gcrValorReturnChr        = String.Empty;
            guiRefObjetoSeleccionado    = null;
            gobRefGrupoSeleccionado     = null;
            gobRefContenedorGrupoSeleccionado = null;
            gobRefZonaSeleccionada      = null;
            gobRefContenedorZonaSeleccionada = null;
            gobRefPaginaSeleccionada    = null;
            gobPaginaSelectParaAddZona  = null;
            gobRefTileImgPredefinida    = null;
            gcrTipoImagenIconoError     = "NA";
            XmlEntorno.gnuContErroresIsRequerido = 0;

            // variables de los test 
            gobCrtFrmg                  = null;
            gobCrtIMC                   = null;
            gobCrtEadAl                 = null;
            gobCrtEadMf                 = null;
            gobCrtEadMg                 = null;
            gobCrtEadPs                 = null;
            gobCrtEadPu                 = null;
            gobCrtEadAlReg              = null;
            gobCrtEadMfReg              = null;
            gobCrtEadMgReg              = null;
            gobCrtEadPsReg              = null;
            gobCrtEadPuReg              = null; 

            // Para gestion codigo fuente plantillas
            oAppICodigofuente           = null;
            // sin errores
            this.imgLogsErrores.Source = new BitmapImage(new Uri(gcrUriImagenesSistema + "Emt_estados_valid04.png", UriKind.RelativeOrAbsolute));

            vm.fcvGridReiniVariables("A");

        }
        #endregion
        //------------------------------------------------------------
        // GESTION DIGITACION DE DATOS VALIDACION VISTA FORMATOS
        //------------------------------------------------------------
        #region fcvValEdtRadioButton: Captura objeto RadioButton
        /// <summary>
        /// <para>Validacion en objetos TextBoxRelCod de tablas relacionadas</para>
        /// </summary>
        private void fcvValEdtRadioButton(object sender, RoutedEventArgs e)
        {
            var lobRadioButton = sender as RadioButton;
            var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobRadioButton.Name).FirstOrDefault();
            var lcrCodigoPlantilla = fcvValEdtSelectPlantilla(lobObjeto);
            XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, lobObjeto.RadioButtonGroupName, lobObjeto.Indice);
            vm.tmpLogErrores = XmlEntorno.tmpLogErrores;
            vm.gcrValorReturnChr = XmlEntorno.gcrValorReturnChr;

        }
        #endregion
        #region fcvValEdtTextBox: Actualizar datos desde objetos Textbox
        /// <summary>
        /// <para>Actualizar objetos Textbox</para>
        /// </summary>
        private void fcvValEdtTextBox(object sender, TextChangedEventArgs e)
        {
            var lobTextBox = sender as TextBox;
            var lobObjeto           = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobTextBox.Name).FirstOrDefault();
            var lcrCodigoPlantilla  = fcvValEdtSelectPlantilla(lobObjeto);
            XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, lobObjeto.Name, lobTextBox.Text);

            XmlEntorno.flgValidVarDatosCampo(lobObjeto.Name, lobTextBox.Text);
            vm.tmpLogErrores        = XmlEntorno.tmpLogErrores;
            vm.gcrValorReturnChr    = XmlEntorno.gcrValorReturnChr;
            vm.GlgSIS_ValidacionOk  = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;

        }
        #endregion
        #region fcvValEdtRichTextBox: Actualizar datos desde objetos RichTextBox
        /// <summary>
        /// <para>Actualizar objetos RichTextBox</para>
        /// </summary>
        private void fcvValEdtRichTextBox(object sender, TextChangedEventArgs e)
        {
            var lobRichTextBox = sender as RichTextBox;
            TextRange textRange = new TextRange(lobRichTextBox.Document.ContentStart, lobRichTextBox.Document.ContentEnd);

            var lobObjeto           = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobRichTextBox.Name).FirstOrDefault();
            var lcrCodigoPlantilla  = fcvValEdtSelectPlantilla(lobObjeto);
            XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, lobObjeto.Name, textRange.Text);
            XmlEntorno.flgValidVarDatosCampo(lobObjeto.Name, textRange.Text);
            vm.tmpLogErrores        = XmlEntorno.tmpLogErrores;
            vm.gcrValorReturnChr    = XmlEntorno.gcrValorReturnChr;
            vm.GlgSIS_ValidacionOk = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;

        }
        #endregion
        #region fcvValEdtTextBoxFecha: Actualizar datos desde objetos TextboxFecha
        /// <summary>
        /// <para>Actualizar objetos TextboxFecha</para>
        /// </summary>
        private void fcvValEdtTextBoxFecha(object sender, TextChangedEventArgs e)
        {
            var lobTextBox = sender as TextBox;
            var lobGrid = lobTextBox.Parent as Grid;
            var lobjFecha = lobGrid.Parent as ControlFecha;

            var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobjFecha.Name).FirstOrDefault();
            var lcrCodigoPlantilla = fcvValEdtSelectPlantilla(lobObjeto);
            XmlEntorno.flgValidVarDatosCampo(lobjFecha.Name, lobTextBox.Text);
            XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, lobObjeto.Name, lobTextBox.Text);
            vm.tmpLogErrores = XmlEntorno.tmpLogErrores;
            vm.gcrValorReturnChr = XmlEntorno.gcrValorReturnChr;
            vm.GlgSIS_ValidacionOk = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;
        }
        #endregion
        #region fcvValEdtTextBoxHora: Actualizar datos desde objetos TextboxHora
        /// <summary>
        /// <para>Actualizar objetos TextboxHora</para>
        /// </summary>
        private void fcvValEdtTextBoxHora(object sender, TextChangedEventArgs e)
        {
            var lobTextBox = sender as TextBox;
            var lobGrid = lobTextBox.Parent as Grid;
            var lobjHora = lobGrid.Parent as ControlHora;

            var lobObjeto           = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobjHora.Name).FirstOrDefault();
            var lcrCodigoPlantilla  = fcvValEdtSelectPlantilla(lobObjeto);
            XmlEntorno.flgValidVarDatosCampo(lobjHora.Name, lobTextBox.Text);
            XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, lobObjeto.Name, lobjHora.txtHora.Text);

            vm.tmpLogErrores        = XmlEntorno.tmpLogErrores;
            vm.gcrValorReturnChr    = XmlEntorno.gcrValorReturnChr;
            vm.GlgSIS_ValidacionOk  = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;
        }
        #endregion
        #region fcvValEdtComboBox: Actualizar los datos al seleccionar desde CombBox
        /// <summary>
        /// <para>Actualizar los datos al seleccionar desde CombBox</para> 
        /// </summary>
        private void fcvValEdtComboBox(object sender, SelectionChangedEventArgs e)
        {
            var lobComboBox = sender as ComboBox;
            var lobList = (XmlEntorno.ClassXmlComboBoxItems)e.AddedItems[0];

            var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobComboBox.Name).FirstOrDefault();
            var lcrCodigoPlantilla = fcvValEdtSelectPlantilla(lobObjeto);
            XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, lobObjeto.Name, lobList.Codigo, lobList.Descripcion);
            // Parametros para validacion
            String lcrValorReturn        = String.Empty;
            String lcrNumeroRegistro     = "USUARIO";
            String lcrCodigoError        = lobObjeto.TabIndex + "B";
            String lcrtituloCampo        = lobObjeto.Titulo;
            String lcrNivelError         = "ALTO";
            String lcrImgNivelError      = "Edt_hist_vista_anulado.png";
            XmlEntorno.gcrValorReturnChr = String.Empty;

            if (lobList.Codigo != "*")
            {
                // Quitar el error si antes el valor seleccionado era "*"
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                            lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                XmlEntorno.fcvSetBorderColorError(lcrValorReturn, ref lobComboBox, ref lobObjeto);

                // Se ejecuta la validacion normal 
                XmlEntorno.flgValidVarDatosCampo(lobObjeto.Name, lobList.Codigo);
            }
            else
            {
                // si hay error registrar en el log con el nombre y titulo del objeto 
                lcrValorReturn = lobObjeto.Name + ": Debe seleccionar una opción";
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                            lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);

                XmlEntorno.fcvSetBorderColorError(lcrValorReturn, ref lobComboBox, ref lobObjeto);
            }
            vm.tmpLogErrores        = XmlEntorno.tmpLogErrores;
            vm.gcrValorReturnChr    = XmlEntorno.gcrValorReturnChr;
            vm.GlgSIS_ValidacionOk  = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;
        }
        #endregion
        #region fcvValEdtCheckBox: Actualizar datos desde objetos CheckBox
        /// <summary>
        /// <para>Actualizar datos desde objetos CheckBox</para>
        /// </summary>
        private void fcvValEdtCheckBox(object sender, RoutedEventArgs e)
        {
            var lobCheckBox = sender as CheckBox;
            var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobCheckBox.Name).FirstOrDefault();
            var lcrCodigoPlantilla = fcvValEdtSelectPlantilla(lobObjeto);
            //var lcrValor = lobCheckBox.IsChecked == true ? "True" : "False";
            var lcrValor = lobCheckBox.IsChecked == true ? "1" : "2";
            XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, lobObjeto.Name, lcrValor);
            vm.tmpLogErrores = XmlEntorno.tmpLogErrores;
            vm.gcrValorReturnChr = XmlEntorno.gcrValorReturnChr;
        }
        #endregion
        #region fcvValEdtCodigoTablaRelacion: Validacion objetos TextBoxRelCod
        /// <summary>
        /// <para>Validacion en objetos TextBoxRelCod de tablas relacionadas</para>
        /// </summary>
        private void fcvValEdtCodigoTablaRelacion(object sender, TextChangedEventArgs e)
        {
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                var lobTextBox  = sender as TextBox;
                lobTextBox.Text = lobTextBox.Text.ToUpper();

                var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobTextBox.Name).FirstOrDefault();
                var lobObjDes = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELDES", lobObjeto.Parent).FirstOrDefault();

                if (!XmlEntorno.flgValidRegRelacionTabla(lobTextBox.Name))
                {
                    // activar notificacion de errores
                }
                else
                {
                    var lobTextBoxDes      = lobObjDes.RefObjeto as TextBox;
                    var lcrCodigoPlantilla = fcvValEdtSelectPlantilla(lobObjeto);

                    XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, lobObjeto.Name, lobTextBox.Text, lobTextBoxDes.Text);
                    XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, lobObjDes.Name, lobTextBoxDes.Text);
                }

                // Gestion de Errores
                vm.tmpLogErrores        = XmlEntorno.tmpLogErrores;
                vm.gcrValorReturnChr    = XmlEntorno.gcrValorReturnChr;
                vm.GlgSIS_ValidacionOk  = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;
            }
        }
        #endregion
        #region fcvValEdtSelectPlantilla: Sleccionar el codigo de la plantilla
        /// <summary>
        /// <para>seleccionar el codigo de la plantilla o etiqueta para guardar datos</para>
        /// </summary>
        private String fcvValEdtSelectPlantilla(ClassXmlPropObjeto tobObjeto)
        {
            var lcrCodigoPlantilla = tobObjeto.CodigoPlantilla;
            if (tobObjeto.Navegador != "ESCRITORIO")
            {
                lcrCodigoPlantilla = XmlEntorno.tmpCapturaEtiqueta.FirstOrDefault().IgGrupoRegistro;
            }
            return lcrCodigoPlantilla;
        }
        #endregion
        #region fcvCambiarImagenIconoValidacionErrores Icono del Boton estado Validación
        /// <summary>
        /// <para>se llama desde Timer para cambiar la imagen en boton logs errores captura datos</para>
        /// <para>"NA" = imagen normal "1" = Sin error "2" = Con error de campos obligatirios "3" = Errores de chr</para>
        /// </summary>
        private void fcvCambiarImagenIconoValidacionErrores()
        {
            //if (XmlEntorno.gobRegHistorialActivo == null) { return; }

            // Cambiar vista imagen boton validacion errores en modo captura
            //if (XmlEntorno.gobRegHistorialActivo.Sis_estpro_espr == "1")

            if (vm.GlgSIS_ModoEdicion == true)
            {
                // sin errores
                if (XmlEntorno.tmpLogErrores.Count <= 0)
                {
                    if (gcrTipoImagenIconoError != "1")
                    {
                        this.imgLogsErrores.Source = new BitmapImage(new Uri(gcrUriImagenesSistema + "Emt_estados_valid01.png", UriKind.RelativeOrAbsolute));
                        gcrTipoImagenIconoError = "1";
                    }
                }
                else if (!String.IsNullOrWhiteSpace(XmlEntorno.gcrValorReturnChr))
                {
                    // Error grave
                    if (gcrTipoImagenIconoError != "3")
                    {
                        this.imgLogsErrores.Source = new BitmapImage(new Uri(gcrUriImagenesSistema + "Emt_estados_valid03.png", UriKind.RelativeOrAbsolute));
                        gcrTipoImagenIconoError = "3";
                    }
                }
                else
                {
                    // Errores de campos obligatorios pero nada grave
                    if (gcrTipoImagenIconoError != "2")
                    {
                        this.imgLogsErrores.Source = new BitmapImage(new Uri(gcrUriImagenesSistema + "Emt_estados_valid02.png", UriKind.RelativeOrAbsolute));
                        gcrTipoImagenIconoError = "2";
                    }
                }
            }
        }
        #endregion
        //- Validacion Test de Framingham y IMC
        #region fcrValidacionTestFramingHam: Test de Framingham
        /// <summary>
        /// <para>Validacion en objetos Test FramingHam</para>
        /// </summary>
        private void fcvValidacionTestFramingHam()
        {
            var lnuContadorFrg = 0;
            var lnuContadorTam = 0;

            String lcrValorReturn       = String.Empty;
            String lcrNumeroRegistro    = "TEST-FRAMINGHAM";
            String lcrCodigoError       = String.Empty;
            String lcrtituloCampo       = String.Empty;
            String lcrNivelError        = "ALTO";
            String lcrImgNivelError     = "Edt_hist_vista_anulado.png";

            // Test Framingham
            #region Edad del paciente
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtFrgSia_edaymd_usua");
            lcrtituloCampo = "Edad del pacente en años";
            lcrCodigoError = "FRMGHAM-01";
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorFrg++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Colesterol
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtColesterolChdl");
            lcrtituloCampo = "Colesterol HDL";
            lcrCodigoError = "FRMGHAM-02";
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorFrg++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Colesterol total
            lcrtituloCampo = "Colesterol Total";
            lcrCodigoError = "FRMGHAM-03";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtColesterolTotal");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                    lnuContadorFrg++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Peresion arterial sistolica
            lcrtituloCampo = "Presión arterial sistólica";
            lcrCodigoError = "FRMGHAM-04";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtPresionArtSistolica");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorFrg++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Tabaco
            lcrtituloCampo = "Paciente fumador SI/NO";
            lcrCodigoError = "FRMGHAM-05";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtTabaco");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorFrg++;
                lnuContadorTam++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Diabetes
            lcrtituloCampo = "Paciente diabetico SI/NO";
            lcrCodigoError = "FRMGHAM-06";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtDiabetes");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorFrg++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            // Tamizaje
            #region Familiares muertos del corazón
            lcrtituloCampo = "Familiares han muertos del corazón SI/NO";
            lcrCodigoError = "FRMGHAM-07";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtFrgFamiMuerCorazon");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorTam++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Familiares sufren diabetes
            lcrtituloCampo = "Familiares sufre diabetes SI/NO";
            lcrCodigoError = "FRMGHAM-08";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtFrmFamiliDiabetes");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorTam++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Ha sufrido infarto o derrame 
            lcrtituloCampo = "Ha sufrido infarto o derrame cerebral SI/NO";
            lcrCodigoError = "FRMGHAM-09";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtFrmInfarto");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorTam++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Le han encontrado tensión alta
            lcrtituloCampo = "Le han encontrado tensión alta SI/NO";
            lcrCodigoError = "FRMGHAM-10";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtFrmTaAlta");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorTam++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Toma medicamentos para tensión alta
            lcrtituloCampo = "Toma medicamentos para tensión alta SI/NO";
            lcrCodigoError = "FRMGHAM-11";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtFrmTaMedicamento");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorTam++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Le han encontrado azucar en la sangre
            lcrtituloCampo = "Le han encontrado azucar en la sangre SI/NO";
            lcrCodigoError = "FRMGHAM-12";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtFrmAzucarSangre");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorTam++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Indice de masa corporal
            lcrtituloCampo = "Indice de masa corporal (IMC)";
            lcrCodigoError = "FRMGHAM-13";
            if (gobCrtFrmg.gobRefIMC != null && XmlEntorno.gcrDatosModoVista == "E")
            {
                if (!String.IsNullOrWhiteSpace(gobCrtFrmg.gobRefIMC.txtImc.Text))
                {
                    gobCrtFrmg.txtFrmIMCPeso.Text  = gobCrtFrmg.gobRefIMC.txtImcPeso.Text;
                    gobCrtFrmg.txtFrmIMCTalla.Text = gobCrtFrmg.gobRefIMC.txtImcTalla.Text;
                    gobCrtFrmg.txtFrmIMCImc.Text   = gobCrtFrmg.gobRefIMC.txtImc.Text;
                }
            }
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtFrmIMCImc");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorTam++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Medida de la cintura
            lcrtituloCampo = "Medida de la cintura";
            lcrCodigoError = "FRMGHAM-14";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtFrmMedidCintura");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorTam++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Realiza actividad fisica
            lcrtituloCampo = "Realiza actividad fisica";
            lcrCodigoError = "FRMGHAM-15";
            lcrValorReturn = gobCrtFrmg.fcrValidacion("txtFrmActividadFisica");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContadorTam++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            // Gestion general
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                vm.tmpLogErrores        = XmlEntorno.tmpLogErrores;
                vm.gcrValorReturnChr    = XmlEntorno.gcrValorReturnChr;
                vm.GlgSIS_ValidacionOk  = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;
            }
            // Gestion Resumen final Test Framingham
            #region Gestion Resumen final Test Framingham
            if (lnuContadorFrg == 0)
            {
                // Ejecutar vista de datos
                //gobCrtFrmg.fcvGenerarVistaFinalDatos();
                gobCrtFrmg.fcvSumatoriaPuntajesFramingham();
                gobCrtFrmg.fcvPorcentajeRiesgoFramingham();
                gobCrtFrmg.fcvNivelRiesgoFramingham();
            }
            else
            {
                gobCrtFrmg.fcvLimpiarVistaFramingham();
            }
            #endregion
            // Gestion Resumen final Tamizaje
            #region Gestion Resumen final Tamizaje
            if (lnuContadorTam == 0)
            {
                // Ejecutar vista de datos
                gobCrtFrmg.fcvSumatoriaPuntajesTamizaje();
                gobCrtFrmg.fcvNivelRiesgoTamizaje();
            }
            else
            {
                gobCrtFrmg.fcvLimpiarVistaTamizaje();
            }
            #endregion
            // Generar String General
            #region Generar String General
            if (lnuContadorFrg == 0 && lnuContadorTam == 0)
            {
                // Ejecutar vista de datos
                gobCrtFrmg.fcvGenerarStrinDatos();
                if (XmlEntorno.gcrDatosModoVista != "V")
                {
                    var lcrCodigoPlantilla = fcvValEdtSelectPlantilla(gobCrtFrmgReg);
                    XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, gobCrtFrmgReg.Name, gobCrtFrmg.gcrValorGenerado);
                }
            }
            #endregion
        }
        #endregion
        #region fcrValidacionImc: Validacion Indice mas corporal
        /// <summary>
        /// <para>Validacion Indice mas corporal</para>
        /// </summary>
        private void fcrValidacionImc()
        {
            var lnuContador = 0;

            String lcrValorReturn    = String.Empty;
            String lcrNumeroRegistro = "IMC";
            String lcrCodigoError    = String.Empty;
            String lcrtituloCampo    = String.Empty;
            String lcrNivelError     = "ALTO";
            String lcrImgNivelError  = "Edt_hist_vista_anulado.png";

            #region Peso en kilogramos
            lcrValorReturn = gobCrtIMC.fcrValidacion("txtImcPeso");
            lcrtituloCampo = "Peso en kilogramos";
            lcrCodigoError = "IMC-01";
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContador++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            #region Talla en centimetros
            lcrValorReturn = gobCrtIMC.fcrValidacion("txtImcTalla");
            lcrtituloCampo = "Talla en centimetros";
            lcrCodigoError = "IMC-02";
            if (String.IsNullOrWhiteSpace(lcrValorReturn) == false)
            {
                lnuContador++;
            }
            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                LogsErrores.fcvAddLogErrores(ref XmlEntorno.tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                        lcrtituloCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            #endregion
            // Referencia a objetos para buscar captura de datos para IMC
            #region Referencia a objetos
            if (gobCrtIMC.gobRefPeso != null && XmlEntorno.gcrDatosModoVista == "E")
            {
                gobCrtIMC.txtImcPeso.Text = !String.IsNullOrWhiteSpace(gobCrtIMC.gobRefPeso.Text) ? gobCrtIMC.gobRefPeso.Text : gobCrtIMC.txtImcPeso.Text;
            }
            if (gobCrtIMC.gobRefTalla != null && XmlEntorno.gcrDatosModoVista == "E")
            {
                gobCrtIMC.txtImcTalla.Text = !String.IsNullOrWhiteSpace(gobCrtIMC.gobRefTalla.Text) ? gobCrtIMC.gobRefTalla.Text : gobCrtIMC.txtImcTalla.Text;
            }
            if (gobCrtIMC.gobRefImc != null && XmlEntorno.gcrDatosModoVista == "E")
            {
                gobCrtIMC.gobRefImc.Text = !String.IsNullOrWhiteSpace(gobCrtIMC.txtImc.Text) ? gobCrtIMC.txtImc.Text : gobCrtIMC.gobRefImc.Text;
            }
            #endregion

            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                vm.tmpLogErrores = XmlEntorno.tmpLogErrores;
                vm.gcrValorReturnChr = XmlEntorno.gcrValorReturnChr;
                vm.GlgSIS_ValidacionOk = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;
            }
            //if (lnuContador == 0 || XmlEntorno.gcrDatosModoVista == "V")
            if (lnuContador == 0)
            {
                // Ejecutar vista de datos
                gobCrtIMC.fcvGenerarVistaFinalDatos();

                if (XmlEntorno.gcrDatosModoVista != "V")
                {
                    var lcrCodigoPlantilla = fcvValEdtSelectPlantilla(gobCrtIMCReg);
                    XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, gobCrtIMCReg.Name, gobCrtIMC.gcrValorGenerado);
                }
            }
            else
            {
                gobCrtIMC.fcvLimpiarVista();
            }

        }
        #endregion
        //- Validacion Test Escala abreviada del desarrrollo EAD
        #region fcrValidacionTestEad: Validacion Test EAD
        /// <summary>
        /// <para>Validacion Test EAD personal social</para>
        /// </summary>
        private void fcrValidacionTestEad()
        {
            // Referencia a objetos para buscar captura de datos
            #region Referencia a objetos
            if (gobCrtEadAl != null)
            {
                gobCrtEadPu.fcvGenerarGrafico(gobCrtEadAl.gnuNumeroRango,"AL", gobCrtEadAl.gnuTotalPD, gobCrtEadAl.gnuTotalPT);
            }
            if (gobCrtEadMf != null)
            {
                gobCrtEadPu.fcvGenerarGrafico(gobCrtEadMf.gnuNumeroRango, "MF", gobCrtEadMf.gnuTotalPD, gobCrtEadMf.gnuTotalPT);
            }
            if (gobCrtEadMg != null)
            {
                gobCrtEadPu.fcvGenerarGrafico(gobCrtEadMg.gnuNumeroRango, "MG", gobCrtEadMg.gnuTotalPD, gobCrtEadMg.gnuTotalPT);
            }
            if (gobCrtEadPs != null)
            {
                gobCrtEadPu.fcvGenerarGrafico(gobCrtEadPs.gnuNumeroRango, "PS", gobCrtEadPs.gnuTotalPD, gobCrtEadPs.gnuTotalPT);
            }
            #endregion

            if (XmlEntorno.gcrDatosModoVista == "E" || XmlEntorno.gcrDatosModoVista == "G")
            {
                vm.tmpLogErrores = XmlEntorno.tmpLogErrores;
                vm.gcrValorReturnChr = XmlEntorno.gcrValorReturnChr;
                vm.GlgSIS_ValidacionOk = XmlEntorno.gnuContErroresIsRequerido == 0 ? true : false;
            }

            if (XmlEntorno.gcrDatosModoVista != "V")
            {
                var lcrCodigoPlantilla = fcvValEdtSelectPlantilla(gobCrtEadPuReg);
                XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, gobCrtEadAl.Name, gobCrtEadAl.gcrValorGenerado);
                XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, gobCrtEadMf.Name, gobCrtEadMf.gcrValorGenerado);
                XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, gobCrtEadMg.Name, gobCrtEadMg.gcrValorGenerado);
                XmlEntorno.flgSetActualizarValorDatoPlantilla(lcrCodigoPlantilla, gobCrtEadPs.Name, gobCrtEadPs.gcrValorGenerado);
            }
        }
        #endregion
        //------------------------------------------------------------
        // GESTION BROWSER PARA SELECCION Y TEXTBOXREL
        //------------------------------------------------------------
        #region fcvSeleccionKeyDown: Seleccion con F2
        /// <summary>
        /// <para>Activar el Browser de busqueda con  tecla F2</para>
        /// </summary>
        private void fcvSeleccionKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                var lobTextBox = sender as TextBox;
                var lobObjCod = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobTextBox.Name).FirstOrDefault();
                var lobObjBas = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobObjCod.Parent).FirstOrDefault();
                gcrCtrF2TexBox = lobObjBas.TablaOrigen;    // Variable publica para el browser y recoger el dato 
                gcrCtrF2TexBoxObj = lobTextBox;               // referencia al objeto TextBoxCod Importante
                gcrCtrF2TexBox = "DATOSREL";
                fcvSeleccionBrowser(gcrCtrF2TexBox);
            }
        }
        #endregion
        #region fcvSeleccionClickButton: Activar Browser de busqueda desde el boton
        /// <summary>
        /// <para>Activar Browser de busqueda desde el boton</para>
        /// </summary>
        private void fcvSeleccionClickButton(object sender, RoutedEventArgs e)
        {
            var lobButton = sender as Button;
            var lobObjBtn = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobButton.Name).FirstOrDefault();
            var lobObjBas = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobObjBtn.Parent).FirstOrDefault();
            var lobObjCod = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "TEXTBOXRELCOD", lobObjBas.Name).FirstOrDefault();
            gcrCtrF2TexBox = lobObjBas.TablaOrigen;    // Variable publica para el browser y recoger el dato 
            gcrCtrF2TexBoxObj = lobObjCod.RefObjeto as TextBox;               // referencia al objeto TextBoxCod Importante
            fcvSeleccionBrowser(gcrCtrF2TexBox);
        }
        #endregion
        #region fcvSeleccionBrowser: Seleccionar el browser
        /// <summary>
        /// <para>Seleccionar el browser de busqueda segun tabla de datos</para>
        /// </summary>
        public void fcvSeleccionBrowser(String tcrTipoTabla)
        {
            switch (tcrTipoTabla)
            {
                case "RGAD": // Maestro Admision Pacientes
                    fcvAdm_secadm_rgad();
                    break;

                case "TDIA": // Diagnosticos
                    fcvSia_coddia_tdia();
                    break;

                case "USUA": // Maestro Pacientes atendidos
                    fcvSia_idesec_usua();
                    break;

                case "TIDE": // tipos identificacion de usuarios / pacientes
                    fcvSia_tipide_tide();
                    break;

                case "PROF": // Profesionales que prestan servicios
                    fcvSia_codpfa_prof();
                    break;

                case "USUX": // Usuarios del sistema
                    fcvSys_codusu_usux();
                    break;

                case "TPAT":   // Tipo Profesional que atiende
                    fcvSia_codpat_tpat();
                    break;

                case "TDIS":    // Tipo discapacidad
                    fcvSia_tipdis_tdis();
                    break;

                case "OCUP":    // Ocupacion
                    fcvSis_codocu_ocup();
                    break;

                case "MANT":    // Manual tarifario 
                    fcvFcm_coddig_mant();
                    break;

            }
        }
        #endregion
        // Browser Tablas
        #region ADM_SECADM_RGAD : Admisión de pacientes
        private void fcvAdm_secadm_rgad()
        {
            Browser02 frbro = new Browser02("ADM", "ADMREGADMISION", 1, "", "Admisión pacientes...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODDIA_TDIA : Tabla de diagnosticos CIE - 10
        private void fcvSia_coddia_tdia()
        {
            Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE-10...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_IDESEC_USUA : Maestro de Pacientes atendidos
        private void fcvSia_idesec_usua()
        {
            Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATEND", "", "Maestro Pacientes atendidos...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_TIPIDE_TIDE : Tipos identificacion usuarios o pacientes
        private void fcvSia_tipide_tide()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPIDEUSARIO", "", "Tipo identificacion usuario...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODPFA_PROF : Profesionales que prestan servicios
        private void fcvSia_codpfa_prof()
        {
            Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SYS_CODUSU_USUX : Usuarios del sistema
        private void fcvSys_codusu_usux()
        {
            Browser01 frbro = new Browser01("SYS", "SYSUSUARIOS", "", "Usuarios del sistema...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_TIPDIS_TDIS : Tipo discapacidad
        private void fcvSia_tipdis_tdis()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPDISCAPACI", "", "Tipo discapacidad...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODPAT_TPAT : Tipo profesional que atiende
        private void fcvSia_codpat_tpat()
        {
            Browser01 frbro = new Browser01("SIA", "SIATIPPROFATIEN", "", "Tipo profesional que atiende...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_CODOCU_OCUP : Ocupacion Profesion 
        private void fcvSis_codocu_ocup()
        {
            Browser01 frbro = new Browser01("SIS", "SISOCUPACIONES", "", "Ocupación/Profesión ...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region Fcm_coddig_mant: Servicios manual tarifario segun contrato
        private void fcvFcm_coddig_mant()
        {
            var lcrFiltro = "Fcmmanservicios.fcm_codman_mans='" + XmlEntorno.tmpRegAdmision.Fcm_codman_mans.Trim() + "'";
            Browser01Ex frbro = new Browser01Ex("FCM", "FCMMANSERVICIOSIU", lcrFiltro, "Maestro de servicios ...");
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        //------------------------------------------------------------
        // MOSTRAR VISTA DEL REGISTRO HISTORIAL SELECCIONADO 
        //------------------------------------------------------------
        #region Filtrar Vista Browser
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvFiltroTextChanged);
        }
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lobTexto = (TextBox)sender;
            XmlEntorno.fcvVistaHistorialFiltro(lobTexto.Text);
        }
        #endregion
        #region fcvHistorialButtonVistaFormato: Activar vista plantilla asociada al evento en historial
        /// <summary>
        /// <para>Activar la vista del evento al hacer click sobre el Boton ver</para>
        /// </summary>
        private void fcvHistorialButtonVistaFormato(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobTile = lobGrid.Parent as TileHistorial;
            flgHistorialCargarVistaFormato(lobTile.RegistroEvento);
        }
        #endregion
        #region flgHistorialCargarVistaFormato: Mostrar la vista plantilla con datos digitados
        /// <summary>
        /// <para>Mostrar la vista plantilla con datos digitados existentes en registro eventos historial</para>
        /// </summary>
        public bool flgHistorialCargarVistaFormato(String tcrCodigoRegistroEvento)
        {
            var llgReturn = false;
            try
            {
                XmlEntorno.gcrIdRegHistorialEventoActivo = tcrCodigoRegistroEvento;
                vm.G1Hcl_nroreg_hcev = tcrCodigoRegistroEvento;
                //- iniciar barra de progreso 
                DialogProgressBarEx lobDlgCon = new DialogProgressBarEx();
                lobDlgCon.fcvProgressBarIniciar("Cargando vista de datos...", "CENTRO");
                lobDlgCon.Show();

                //MessageBox.Show("flgHistorialCargarVistaFormato 1: " + tcrCodigoRegistroEvento);

                if (XmlEntorno.flgBDatosPlantillayDatos(tcrCodigoRegistroEvento))
                {
                    fcvCmdAddImagenesPredefinidas("-");
                    fcvAdicionarManejadorPaginasyZonas("OBJETOS", "-");
                    this.wraPlantilla.Children.Clear();
                    fcvGestionReiniciarVariables();
                    if (XmlEntorno.flgMostrarVistaPlantilla(XmlEntorno.gobRegHistorial.Grp_idepla_grpv))
                    {
                        //MessageBox.Show("flgHistorialCargarVistaFormato 2: " + XmlEntorno.gobRegHistorial.Grp_idepla_grpv);

                        if (XmlEntorno.gobRegPropPlantillaDatos.DatosModoVista == "E" || XmlEntorno.gcrDatosModoGestion == "G")
                        {
                            fcvAdicionarManejadorPaginasyZonas("OBJETOS", "+");
                            vm.GlgSIS_ModoEdicion = true;
                            fcvCompilarCodigoFuentePlantilla();
                        }
                        XmlEntorno.flgCargarValoresDatosVistaObjetos();
                        fcvCmdAddImagenesPredefinidas("+");
                        vm.Filtro(tcrCodigoRegistroEvento);
                        vm.tmpEtiquetaItems                 = XmlEntorno.fobRegSelectItemsEtiquetas("");
                        fcvGetValorBaseZoomScroll("SET");
                        glgRefreshVistaPlntilla             = true;
                        vm.GlgSIS_ModoVistaObjetos          = XmlEntorno.gcrDatosModoVista == "V" ? true : false;
                        flgEnlazarEventosClickControlCaptura("+");
                        flgValidaEsControlCapturaOdontologia();
                        vm.tmpLogErrores                    = XmlEntorno.gcrDatosModoVista == "V" ? new List<LogsErrores>() : XmlEntorno.tmpLogErrores;
                        vm.gcrValorReturnChr                = XmlEntorno.gcrDatosModoVista == "V" ? String.Empty : XmlEntorno.gcrValorReturnChr;
                        XmlEntorno.glgNuevoRegistroPlantilla = false;
                        vm.GlgSIS_ModoGestionMultiSet       = XmlEntorno.gcrDatosModoGestion == "G" ? true : false;
                        vm.PropTxtPlantTipoImpresion        = XmlEntorno.gcrPlantillaTipoImpresion;
                    }
                    else
                    {
                        MessageBox.Show("No fue posible cargar los datos.");
                    }
                }
                else
                {
                    MessageBox.Show("No fue posible cargar plantilla de datos.");
                }
                lobDlgCon.Close();
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Captura Historias clinicas: flgHistorialCargarVistaFormato");
            }
            return llgReturn;
        }
        #endregion
        #region flgHistorialSiDatos: Comprobar si existen datos digitados
        /// <summary>
        /// <para>Comprobar si existen datos digitados, de lo contrario se agregara nuevo registro</para>
        /// </summary>
        public bool flgHistorialSiDatos(String tcrCodigoRegHistorial)
        {
            var llgReturn = false;
            var lobRegHistorial = HclModeloHistorialEventos.flsBuscarHistorialEventos("HR", tcrCodigoRegHistorial);
            if (lobRegHistorial != null)
            {
                var lobRegistro = lobRegHistorial.FirstOrDefault();
                if (!String.IsNullOrWhiteSpace(lobRegistro.Hcl_xmldat_hcev))
                {
                    llgReturn = true;
                }
            }
            return llgReturn;
        }
        #endregion
        #region fcvAdicionarManejadorHistorialEventos: Adicionar manejadores a los Tiles de eventos del historial
        /// <summary>
        /// <para>Adicionar manejadores a los Tiles de eventos del historial</para>
        /// </summary>
        public void fcvAdicionarManejadorHistorialEventos()
        {
            var tobTemp = XmlEntorno.tmpVistaHistorial;

            foreach (var lobItem in tobTemp)
            {
                if (lobItem.GestionEstadoRegistro == "OK")
                {
                    var lobTile = lobItem.RefObjEvento as TileHistorial;
                    lobTile.cmdHistorialVer.Click += new RoutedEventHandler(fcvHistorialButtonVistaFormato);
                }
            }
        }
        #endregion
        //------------------------------------------------------------
        // GESTION  CAPTURA ORDENES DE SERVICIOS, MEDICAMENTOS ODONTOLOGIA Y OTROS SERVICIOS
        //------------------------------------------------------------
        #region fcvSeleccionTipoCaptura: Activar tipo ventana captura
        /// <summary>
        /// <para>Activar la ventan de captura para solicitudes de servicios medicamentos y otros</para>
        /// </summary>
        private void fcvSeleccionTipoCaptura(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(gcrParamIdAdmision))
            {
                MessageBox.Show("No hay registro de admisión abierta");
                return;
            }
            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobControlVista = lobGrid.Parent as ControlCaptura;
            gobCtrControlCaptura = lobControlVista;
            gcrCtrF2TexBox = "CONTROLCAPTURA-ADD";

            #region Opciones
            switch (lobControlVista.gcrTipoControl)
            {
                case "MEDI":
                    // Medicamentos
                    break;

                case "SERV":
                    // Servicios Plan manejo Interno
                    var lobVistaSr = new VistaSolicitudServicios("ADD", "1", "", gcrParamIdAdmision);
                    lobVistaSr.Owner = this;
                    lobVistaSr.ShowDialog();
                    break;

                case "FMED":
                    // Formula medica
                    var lobVistaFm = new VistaSolicitudServicios("ADD", "2", "", gcrParamIdAdmision);
                    lobVistaFm.Owner = this;
                    lobVistaFm.ShowDialog();
                    break;

                case "EVOL":
                    // Evoluciones medicas
                    var lobVistaEvol = new SolicitNotasMedicas("ADD", "1", "", gcrParamIdAdmision);
                    lobVistaEvol.Owner = this;
                    lobVistaEvol.ShowDialog();
                    break;

                case "NENF":
                    // Notas de enfermeria
                    var lobVistaNenf = new SolicitNotasMedicas("ADD", "2", "", gcrParamIdAdmision);
                    lobVistaNenf.Owner = this;
                    lobVistaNenf.ShowDialog();
                    break;

                case "HCON":
                    // Hoja de Consumo servicios y medicamentos
                    var lobVistaHcon = new VistaHojaConsumoServicios("ADD", "2", gcrParamIdAdmision);
                    lobVistaHcon.Owner = this;
                    lobVistaHcon.ShowDialog();
                    break;

                case "SVIT":
                    // Signos Vitales
                    break;

                case "INCO":
                    // Interconsulta
                    break;

                case "DIAG":
                    // Diagnosticos CIE-10
                    break;

                case "BLIQ":
                    // Balance de liquidos 
                    if (flgValidaSiBliqidoAbierto())
                    {
                        var lobVistaBliqAdd = new VistaSolicitBalanceLiqAdd("ADD", "", gcrParamIdAdmision);
                        lobVistaBliqAdd.Owner = this;
                        lobVistaBliqAdd.ShowDialog();
                    }
                    else
                    {
                        var lobVistaBliqAdd = new VistaMsBalanceLiquidos("ADD", "1", "", gcrParamIdAdmision);
                        lobVistaBliqAdd.Owner = this;
                        lobVistaBliqAdd.ShowDialog();
                    }
                    break;

                case "ODAP":
                    // Tratamiento de odontologia 
                    if (flgValidaSiTramientoOdnActivo())
                    {
                        flgEjecutarVistaOdontologia();
                    }
                    else
                    {
                        var lobVistaOdnTratamiento = new VistaMaestroDiagnosticos("ADD", "", "1", "", gcrParamIdAdmision);
                        lobVistaOdnTratamiento.Owner = this;
                        lobVistaOdnTratamiento.ShowDialog();
                    }
                    break;

                case "ODCX":
                    // Consulta externa
                    if (flgValidaSiTramientoOdnActivo())
                    {
                        flgEjecutarVistaOdontologia();
                    }
                    else
                    {
                        var lobVistaOdnTratamiento = new VistaMaestroDiagnosticos("ADD", "", "2", "", gcrParamIdAdmision);
                        lobVistaOdnTratamiento.Owner = this;
                        lobVistaOdnTratamiento.ShowDialog();
                    }
                    break;
                default:
                    //  Archivos de Recursos 
                    var lcrTipo = lobControlVista.gcrTipoControl;
                    if (lcrTipo == "RDOC" || lcrTipo == "RXLS" || lcrTipo == "RPDF"
                        || lcrTipo == "RIMG" || lcrTipo == "RVID" || lcrTipo == "RXML"
                        || lcrTipo == "RHL7")
                    {
                        // Servicios
                        var lobVistaRec = new SolicitAddRecursos("ADD", lcrTipo, "", gcrParamIdAdmision);
                        lobVistaRec.Owner = this;
                        lobVistaRec.ShowDialog();
                    }
                    break;
            }
            #endregion
        }
        #endregion
        #region fcvConfirmarRegistroTipoCaptura: Confirmar registro abiertos
        /// <summary>
        /// <para> Confirmar registro abiertos de servicios medicamentos y otros</para>
        /// </summary>
        private void fcvConfirmarRegistroTipoCaptura(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(gcrParamIdAdmision))
            {
                MessageBox.Show("No hay registro de admisión abierta");
                return;
            }
            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobControlVista = lobGrid.Parent as ControlCaptura;
            gobCtrControlCaptura = lobControlVista;
            gcrCtrF2TexBox = "CONTROLCAPTURA-CON";
            var lcrTipo = lobControlVista.gcrTipoControl;

            switch (lcrTipo)
            {
                case "MEDI":
                    // Medicamentos
                    break;

                case "SERV":
                    // Servicios
                    var lobServ = new SolicitOrdConfirmar("SERV", gcrParamIdAdmision);
                    lobServ.Owner = this;
                    lobServ.ShowDialog();
                    break;

                case "FMED":
                    // Formula medica
                    var lobFm = new SolicitOrdConfirmar("FMED", gcrParamIdAdmision);
                    lobFm.Owner = this;
                    lobFm.ShowDialog();
                    break;

                case "EVOL":
                    // Evoluciones medicas
                    var lobEvol = new SolicitOrdConfirmar("EVOL", gcrParamIdAdmision);
                    lobEvol.Owner = this;
                    lobEvol.ShowDialog();
                    break;

                case "NENF":
                    // Notas de enfermeria
                    var lobNenf = new SolicitOrdConfirmar("NENF", gcrParamIdAdmision);
                    lobNenf.Owner = this;
                    lobNenf.ShowDialog();
                    break;

                case "HCON":
                    // Hoja de consumo servicios y medicamentos
                    var lobHcon = new SolicitOrdConfirmar("HCON", gcrParamIdAdmision);
                    lobHcon.Owner = this;
                    lobHcon.ShowDialog();
                    break;

                case "SVIT":
                    // Signos Vitales
                    break;

                case "INCO":
                    // Interconsulta
                    break;

                case "DIAG":
                    // Diagnosticos CIE-10
                    break;

                case "BLIQ":
                    // Balance de liquidos
                    var lobVistaBliqAdd = new VistaMsBalanceLiquidos("EDT", "2", "", gcrParamIdAdmision);
                    lobVistaBliqAdd.Owner = this;
                    lobVistaBliqAdd.ShowDialog();
                    break;

                case "ODAP":
                    // Cierre tratamiento odontologico
                    var lobVistaOdontologia = new VistaMaestroTratamiento("EDT", "2", lobControlVista.gcrCodigoRegMaest, gcrParamIdAdmision);
                    lobVistaOdontologia.Owner = this;
                    lobVistaOdontologia.ShowDialog();
                    break;

                default:
                    //  Archivos de Recursos 
                    if (lcrTipo == "RDOC" || lcrTipo == "RXLS" || lcrTipo == "RPDF"
                        || lcrTipo == "RIMG" || lcrTipo == "RVID" || lcrTipo == "RXML"
                        || lcrTipo == "RHL7")
                    {
                        var lobHconRc = new SolicitOrdConfirmar(lcrTipo, gcrParamIdAdmision);
                        lobHconRc.Owner = this;
                        lobHconRc.ShowDialog();
                    }
                    break;
            }

        }
        #endregion
        #region flgEjecutarVistaOdontologia: Verifica y ejecuta la vista correspondiente de odontologia
        /// <summary>
        /// <para>Verifica y ejecuta la vista correspondiente de odontologia segun el tipo de actividad que corresponda</para>
        /// </summary>
        private bool flgEjecutarVistaOdontologia()
        {
            var llgRegActivo = false;
            var tmpRegMaestro = ODNValidarCodigo.fobRegBuscarOdneventosmaestEstado(gcrParamIdUnicoSistem, "1");

            if (tmpRegMaestro != null)
            {
                // si llega aqui, Hay un tratamiento para gestion en estado activo

                var lcrTipo = "1"; // Diagnostico por defecto
                var lcrCodigo = String.Empty;
                var lcrAccion = "ADD";
                var lcrVerif = "XXXX-XXXX";
                var lobReg = ODNValidarCodigo.fobRegBuscarOdneventosactmsEstado(tmpRegMaestro.odn_nroreg_odev, "1");

                // Localizar que tipo de actividad esta activa para gestion 
                if (lobReg != null)
                {
                    lcrTipo = lobReg.odn_tipreg_odac;
                    lcrCodigo = lobReg.odn_nroreg_odac;
                    lcrAccion = "EDT";
                }
                else
                {
                    lcrTipo = "3"; // Actividad de evolucion por defecto
                    lcrVerif = ODNValidarCodigo.fcrValidaOdontologiaDiagPlanTratamiento(tmpRegMaestro.odn_nroreg_odev);
                    if (lcrVerif == "XXXX-XXXX" || lcrVerif == "XXXX-ODTR")
                    {
                        lcrTipo = "1"; // Diagnostico
                    }
                    else if (lcrVerif == "ODDX-XXXX")
                    {
                        lcrTipo = "2"; // Plan tratamiento
                    }
                }
                if (lcrTipo != "4")
                {
                    if (lcrTipo == "1" || lcrTipo == "2")
                    {
                        var lobHCL001 = new VistaMaestroDiagnosticos(lcrAccion, tmpRegMaestro.odn_nroreg_odev, lcrTipo, lcrCodigo, gcrParamIdAdmision);
                        lobHCL001.Owner = this;
                        lobHCL001.ShowDialog();
                        llgRegActivo = true;
                    }
                    else
                    {
                        var lobHCL002 = new VistaMaestroActividades(lcrAccion, tmpRegMaestro.odn_nroreg_odev, lcrTipo, lcrCodigo, gcrParamIdAdmision);
                        lobHCL002.Owner = this;
                        lobHCL002.ShowDialog();
                        llgRegActivo = true;
                    }

                }
                else
                {
                    // Es imagen 
                }
            }
            return llgRegActivo;
        }
        #endregion
        //------------------------------------------------------------
        // VALIDACIONES 
        //------------------------------------------------------------
        #region flgActivarBotonAddControlCaptura: Validar para saber si se activa el boton add en control captura
        /// <summary>
        /// <para>Validar para saber si se activa el boton adicionar registro del control captura</para>
        /// <para>Para cualquier tipo registro que lo requiera ejemplo: ODAP = tratamiento de odontologia abierto</para>
        /// </summary>
        private bool flgActivarBotonAddControlCaptura()
        {
            var llgRegActivo = false;
            if (gobCtrControlCaptura != null)
            {
                if (gobCtrControlCaptura.gcrTipoControl == "ODAP")
                {
                    if (flgValidaSiTramientoOdnActivo() && this.lblEscDatosMedicos.Text == "1")
                    {
                        // hay tratamiento abierto y la admision activa tiene datos medicos abiertos
                        gobCtrControlCaptura.cmdAdicionar.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    // otros para el futuro
                }

            }
            return llgRegActivo;
        }
        #endregion
        #region flgValidaSiBliqidoAbierto: Validar que exista balance de liquidos
        /// <summary>
        /// <para>Verifica que exista registro maestro balance de liquidos abierto para agregar</para>
        /// <para>registros de control liquidos administrados y eliminados</para>
        /// </summary>
        private bool flgValidaSiBliqidoAbierto()
        {
            var llgReturn = false;
            var tmpRegMaestro = ModeloHclregbliqidoms.flsListaHclregbliqidomsEx("2", gcrParamIdAdmision, "1");
            if (tmpRegMaestro.Count != 0) { llgReturn = true; }

            return llgReturn;
        }
        #endregion
        #region flgValidaSiTramientoOdnActivo: Validar que exista Tratamiento odontologia activo
        /// <summary>
        /// <para>Verifica que exista registro maestro tratamiento odontologico confirmado y activo para gestion</para>
        /// </summary>
        private bool flgValidaSiTramientoOdnActivo()
        {
            var llgRegActivo = false;
            var tmpRegMaestro = ODNValidarCodigo.fobRegBuscarOdneventosmaestEstado(gcrParamIdUnicoSistem, "1");
            if (tmpRegMaestro != null)
            {
                var lcrEstadoEvent = tmpRegMaestro.odn_estado_odev;
                llgRegActivo = lcrEstadoEvent == "1";
                //MessageBox.Show("TRATAMIENTO ACTIVO " + tmpRegMaestro.odn_nroreg_odev);
            }
            return llgRegActivo;
        }
        #endregion
        //------------------------------------------------------------
        // VER /IMPRIMIR Y/O EXPORTAR A PDF Y DOC
        //------------------------------------------------------------
        // Enlazar eventos para imprimir
        #region flgEnlazarEventosClickControlCaptura: Enlazar evento imprimir y otros en cada vista segun tipo control captura
        /// <summary>
        /// <para>Enlazar eventos varios e imprimir en cada vista segun tipo control captura</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrAccion: "+"=Enlazar enventos "-" = Quitar enlaces de eventos</para>
        /// </summary>
        private bool flgEnlazarEventosClickControlCaptura(String tcrAccion)
        {
            var llgReturn = false;

            // Cuando no existe referencia la objeto ControlCaptura 
            if (gobCtrControlCaptura == null)
            {
                var tobTemp = XmlEntorno.fobRegSelectReferenciaArchivo("OBJETOS");
                var lobControlCaptura = tobTemp.FirstOrDefault(x => x.TipoObjeto == "CONTROLCAPTURA");
                if (lobControlCaptura != null)
                {
                    gobCtrControlCaptura = lobControlCaptura.RefObjeto as ControlCaptura;
                }
            }

            if (gobCtrControlCaptura != null)
            {
                flgActivarBotonAddControlCaptura();
                foreach (var lobReg in gobCtrControlCaptura.tmpRegistro)
                {
                    lobReg.ClickRefObjeto = tcrAccion == "-" ? "2" : lobReg.ClickRefObjeto;

                    if (lobReg.ClickRefObjeto == "2" || String.IsNullOrWhiteSpace(lobReg.ClickRefObjeto))
                    {
                        if (lobReg.TipoRegistro == "ODDX" || lobReg.TipoRegistro == "ODEV" || lobReg.TipoRegistro == "ODTR")
                        {
                            // Odontologia
                            var lobControl = lobReg.RefObjeto as ControlOrdOdontoServicios;
                            if (tcrAccion == "+")
                            {
                                lobControl.cmdImprimir.Click += new RoutedEventHandler(fcvRefPRNRegistroOdontlogia);
                                lobControl.cmdHistorialVer.Click += new RoutedEventHandler(fcvOdontologiaClickPropiedades);
                                lobReg.ClickRefObjeto = "1";
                            }
                            else
                            {
                                lobControl.cmdImprimir.Click -= new RoutedEventHandler(fcvRefPRNRegistroOdontlogia);
                                lobControl.cmdHistorialVer.Click -= new RoutedEventHandler(fcvOdontologiaClickPropiedades);
                            }
                        }
                        else if (lobReg.TipoRegistro == "SERV" || lobReg.TipoRegistro == "FMED")
                        {
                            // Plan de manejo interno / formula medica
                            var lobControl = lobReg.RefObjeto as ControlOrdServicios;
                            if (tcrAccion == "+")
                            {
                                lobControl.cmdImprimir.Click += new RoutedEventHandler(fcvRefPRNRegistroPlanManejo);
                                lobControl.cmdHistorialVer.Click += new RoutedEventHandler(fcvClickPropiedadesPlanManejo);
                                lobReg.ClickRefObjeto = "1";
                            }
                            else
                            {
                                lobControl.cmdImprimir.Click -= new RoutedEventHandler(fcvRefPRNRegistroPlanManejo);
                                lobControl.cmdHistorialVer.Click -= new RoutedEventHandler(fcvClickPropiedadesPlanManejo);
                            }
                        }
                        else if (lobReg.TipoRegistro == "HCON")
                        {
                            // hoja de consumo
                            var lobControl = lobReg.RefObjeto as ControlOrdServicios;
                            if (tcrAccion == "+")
                            {
                                lobControl.cmdImprimir.Click += new RoutedEventHandler(fcvRefPRNHojaDeConsumo);
                                lobControl.cmdHistorialVer.Click += new RoutedEventHandler(fcvClickPropiedadesHojaConsumo);
                                lobReg.ClickRefObjeto = "1";
                            }
                            else
                            {
                                lobControl.cmdImprimir.Click -= new RoutedEventHandler(fcvRefPRNHojaDeConsumo);
                                lobControl.cmdHistorialVer.Click -= new RoutedEventHandler(fcvClickPropiedadesHojaConsumo);
                            }
                        }
                        else if (lobReg.TipoRegistro == "EVOL" || lobReg.TipoRegistro == "NENF")
                        {
                            // Evoluciones medicas y Notas de enfermeria
                            var lobControl = lobReg.RefObjeto as ControlOrdServicios;
                            if (tcrAccion == "+")
                            {
                                lobControl.cmdImprimir.Click += new RoutedEventHandler(fcvRefPRNEvolucionesyNotas);
                                lobReg.ClickRefObjeto = "1";
                            }
                            else
                            {
                                lobControl.cmdImprimir.Click -= new RoutedEventHandler(fcvRefPRNEvolucionesyNotas);
                            }
                        }
                    }

                }
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        // Referencias a odontologia
        #region flgValidaEsControlCapturaOdontologia: vista "ControlCaptura"  muestra en pantalla gestion de odontologia
        /// <summary>
        /// <para>Verifica que la vista "ControlCaptura"  muestra en pantalla gestion de odontologia</para>
        /// <para>para enlazar los eventos click propiedad  de cada grupo de actividad y mostrar ventan auxiliar que gestiona nuevos registros</para>
        /// </summary>
        private bool flgValidaEsControlCapturaOdontologia()
        {
            var llgReturn = false;

            if (gobCtrControlCaptura != null)
            {
                flgActivarBotonAddControlCaptura();
                if (gobCtrControlCaptura.gcrTipoControl == "ODAP" && gobCtrControlCaptura.tmpRegistro != null) // Odontologia
                {
                    /*
                    foreach (var lobReg in gobCtrControlCaptura.tmpRegistro)
                    {
                        if (lobReg.TipoRegistro != "ODAP" && lobReg.ClickRefObjeto=="2")
                        {
                            var lobControl = lobReg.RefObjeto as ControlOrdOdontoServicios;
                            lobControl.cmdHistorialVer.Click += new RoutedEventHandler(fcvOdontologiaClickPropiedades);
                            lobReg.ClickRefObjeto = "1";
                        }
                    }
                    */
                    llgReturn = true;
                }
            }
            return llgReturn;
        }
        #endregion
        #region fcvOdontologiaClickPropiedades: Evento click propiedades gestion odontologia
        /// <summary>
        /// <para> Evento click para mostrar ventana auxiliar de captura y gestion de</para>
        /// <para> nuevos registros de un traamiento de odontologia.</para>
        /// </summary>
        private void fcvOdontologiaClickPropiedades(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid1 = lobBoton.Parent as Grid;
            var lobGrid2 = lobGrid1.Parent as Grid;
            var lobControlVista = lobGrid2.Parent as ControlOrdOdontoServicios;

            var lcrTratamiento = lobControlVista.gcrCodigoTratamiento;
            var lcrAdmision = lobControlVista.gcrCodigoAdmision;
            var lcrActividad = lobControlVista.gcrCodigoActividad;

            gcrCtrF2TexBox = "CONTROLCAPTURA-ADD";

            switch (lobControlVista.gcrTipoRegistro)
            {
                case "ODDX":
                    // Diagnosticos

                    var lobHCL001 = new VistaMaestroDiagnosticos("EDT", lcrTratamiento, "1", lcrActividad, lcrAdmision);
                    lobHCL001.Owner = this;
                    lobHCL001.ShowDialog();

                    /*
                    var lobHCL001 = new VistaMaestroActividades("EDT", lcrTratamiento, "1", lcrActividad, lcrAdmision);
                    lobHCL001.Owner = this;
                    lobHCL001.ShowDialog();
                    */
                    break;

                case "ODTR":
                    // Plan de tratamiento

                    var lobHCL002 = new VistaMaestroDiagnosticos("EDT", lcrTratamiento, "2", lcrActividad, lcrAdmision);
                    lobHCL002.Owner = this;
                    lobHCL002.ShowDialog();
                    /*
                    var lobHCL002 = new VistaMaestroActividades("EDT", lcrTratamiento, "2", lcrActividad, lcrAdmision);
                    lobHCL002.Owner = this;
                    lobHCL002.ShowDialog();
                    */
                    break;

                case "ODEV":
                    // Actividad Evolucion del tratamiento
                    var lobHCL003 = new VistaMaestroActividades("EDT", lcrTratamiento, "3", lcrActividad, lcrAdmision);
                    lobHCL003.Owner = this;
                    lobHCL003.ShowDialog();
                    break;

            }
        }
        #endregion
        // Gestion editar datos en formulas medicas (plan de manejo)
        #region fcvClickPropiedadesPlanManejo: Evento click propiedades en Formula medica / Plan manejo interno
        /// <summary>
        /// <para> Evento click propiedades en Formula medica / Plan manejo interno</para>
        /// </summary>
        private void fcvClickPropiedadesPlanManejo(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobGrid1 = lobGrid.Parent as Grid;
            var lobControlVista = lobGrid1.Parent as ControlOrdServicios;

            var lcrAdmision = lobControlVista.gcrCodigoAdmision;
            var lcrCodigoRegistro = lobControlVista.gcrCodigoUnico;
            var lcrTipoRegistro = lobControlVista.gcrTipoRegistro;

            if (lobControlVista != null)
            {
                // Ejecutar la vista 
                // Formula medica
                gcrCtrF2TexBox = "CONTROLCAPTURA-CON";
                var lobVistaFm = new VistaSolicitudServicios("EDT", "2", lcrCodigoRegistro, gcrParamIdAdmision);
                lobVistaFm.Owner = this;
                lobVistaFm.ShowDialog();
            }
        }
        #endregion
        // Gestion editar datos en Hoja de consumo
        #region fcvClickPropiedadesHojaConsumo: Evento click propiedades hoja de consumo 
        /// <summary>
        /// <para>Evento click propiedades hoja de consumo </para>
        /// </summary>
        private void fcvClickPropiedadesHojaConsumo(object sender, RoutedEventArgs e)
        {
            var lobBoton        = sender as Button;
            var lobGrid         = lobBoton.Parent as Grid;
            var lobGrid1        = lobGrid.Parent as Grid;
            var lobControlVista = lobGrid1.Parent as ControlOrdServicios;

            var lcrAdmision         = lobControlVista.gcrCodigoAdmision;
            var lcrCodigoRegistro   = lobControlVista.gcrCodigoUnico;
            var lcrTipoRegistro     = lobControlVista.gcrTipoRegistro;

            if (lobControlVista != null)
            {
                // Ejecutar la vista 
                // Formula medica
                gcrCtrF2TexBox = "CONTROLCAPTURA-CON";
                var lobVistaFm = new VistaHojaConsumoServicios("EDT", lcrCodigoRegistro, gcrParamIdAdmision);
                lobVistaFm.Owner = this;
                lobVistaFm.ShowDialog();
            }
        }
        #endregion
        //- IMPRIMIR Referencias segun tipo vista
        #region fcvRefPRNRegistroOdontlogia: Evento click Imprimir un registro de Odontologia
        /// <summary>
        /// <para> Evento click para mostrar vista preliminar de la impresion del formato o registro activo</para>
        /// </summary>
        private void fcvRefPRNRegistroOdontlogia(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid1 = lobBoton.Parent as Grid;
            var lobGrid2 = lobGrid1.Parent as Grid;
            var lobControlVista = lobGrid2.Parent as ControlOrdOdontoServicios;

            var lcrTratamiento = lobControlVista.gcrCodigoTratamiento;
            var lcrAdmision = lobControlVista.gcrCodigoAdmision;
            var lcrActividad = lobControlVista.gcrCodigoActividad;
            ControlOrdOdontoServicios lobRefOdnPlan = null;
            ControlOrdOdontoServicios lobRefOdnDiag = null;

            if (gobCtrControlCaptura != null)
            {
                foreach (var lobReg in gobCtrControlCaptura.tmpRegistro)
                {
                    if (lobReg.TipoRegistro == "ODTR")
                    {
                        lobRefOdnPlan = lobReg.RefObjeto as ControlOrdOdontoServicios;
                    }
                    if (lobReg.TipoRegistro == "ODDX")
                    {
                        lobRefOdnDiag = lobReg.RefObjeto as ControlOrdOdontoServicios;
                    }
                }
                if (lobRefOdnPlan != null)
                {
                    var lobRegVista = new ODNImprimir();

                    var lobOdnEncoder1 = new System.Windows.Media.Imaging.PngBitmapEncoder();
                    var lobOdnEncoder2 = new System.Windows.Media.Imaging.PngBitmapEncoder();
                    var luxflujo1 = new MemoryStream();
                    var luxflujo2 = new MemoryStream();
                    // capturar las pantallas
                    var lobOdnImagen1 = Funciones.frtbCapturarPantallaAImagen(lobRefOdnPlan.grdOdontograma, 96, 96);
                    var lobOdnImagen2 = Funciones.frtbCapturarPantallaAImagen(lobRefOdnDiag.grdOdontograma, 96, 96);

                    //Bitmap codificado
                    lobOdnEncoder1.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(lobOdnImagen1));
                    lobOdnEncoder2.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(lobOdnImagen2));
                    // generar el flujo
                    lobOdnEncoder1.Save(luxflujo1);
                    lobOdnEncoder2.Save(luxflujo2);

                    lobRegVista.gobArrayImgDiag = luxflujo1.ToArray();
                    lobRegVista.gobArrayImgPlan = luxflujo2.ToArray();
                    lobRegVista.gcrCodigoAdmision = lcrAdmision;
                    lobRegVista.gcrCodigoRegistro = lcrTratamiento; // Codigo del tratamiento odontologico
                    lobRegVista.gcrTipoRegistro = "ODTR";   // "ODTR" = Tratamiento odontologico
                    lobRegVista.glgVistaPrevia = true;     // true = mostrar vista previa / fase = no mostrar vista previa
                    lobRegVista.gobOwner = this;
                    lobRegVista.fcvEjecutar();
                }
            }
        }
        #endregion
        #region fcvRefPRNRegistroPlanManejo: Evento click Imprimir Formula medica / Plan manejo interno
        /// <summary>
        /// <para> Evento click Imprimir Formula medica / Plan manejo interno (solo un registro)</para>
        /// </summary>
        private void fcvRefPRNRegistroPlanManejo(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobGrid1 = lobGrid.Parent as Grid;
            var lobControlVista = lobGrid1.Parent as ControlOrdServicios;

            var lcrAdmision = lobControlVista.gcrCodigoAdmision;
            var lcrCodigoRegistro = lobControlVista.gcrCodigoUnico;
            var lcrTipoRegistro = lobControlVista.gcrTipoRegistro;

            if (lobControlVista != null)
            {
                var lobRegVista = new HCLImprimir();

                lobRegVista.gcrFiltroReporte = "REG";
                lobRegVista.gcrCodigoAdmision = lcrAdmision;
                lobRegVista.gcrCodigoRegistro = lcrCodigoRegistro; // Codigo Hcl_nroreg_hcms
                lobRegVista.gcrTipoRegistro = lcrTipoRegistro;   // "SERV" = Plan manejo interno/ "FMED" = Formula medica
                lobRegVista.gnuNumeroCopias = lcrTipoRegistro == "SERV" ? 1 : 2;
                lobRegVista.glgVistaPrevia = true;              // true = mostrar vista previa / fase = no mostrar vista previa
                lobRegVista.gobOwner = this;
                lobRegVista.fcvEjecutar();
            }
        }
        #endregion
        #region fcvRefPRNHojaDeConsumo: Evento click Imprimir Hoja de consumo intrahospitalario
        /// <summary>
        /// <para>Evento click Imprimir Hoja de consumo intrahospitalario</para>
        /// </summary>
        private void fcvRefPRNHojaDeConsumo(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobGrid1 = lobGrid.Parent as Grid;
            var lobControlVista = lobGrid1.Parent as ControlOrdServicios;

            var lcrAdmision = lobControlVista.gcrCodigoAdmision;
            var lcrCodigoRegistro = lobControlVista.gcrCodigoUnico;
            var lcrTipoRegistro = lobControlVista.gcrTipoRegistro;

            if (lobControlVista != null)
            {
                var lobRegVista = new HCLImprimir();

                lobRegVista.gcrFiltroReporte = "ADM";
                lobRegVista.gcrCodigoAdmision = lcrAdmision;
                lobRegVista.gcrCodigoRegistro = lcrCodigoRegistro; // Codigo Hcl_nroreg_hcms
                lobRegVista.gcrTipoRegistro = lcrTipoRegistro;   // "HCON" = Hoja de consumo
                lobRegVista.gnuNumeroCopias = 1;
                lobRegVista.glgVistaPrevia = true;              // true = mostrar vista previa / fase = no mostrar vista previa
                lobRegVista.gobOwner = this;
                lobRegVista.fcvEjecutar();
            }
        }
        #endregion
        #region fcvRefPRNEvolucionesyNotas: Evento click Imprimir Evoluciones medicas y notas de enfermeria
        /// <summary>
        /// <para>Evento click Imprimir Evoluciones medicas y notas de enfermeria</para>
        /// </summary>
        private void fcvRefPRNEvolucionesyNotas(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid = lobBoton.Parent as Grid;
            var lobGrid1 = lobGrid.Parent as Grid;
            var lobControlVista = lobGrid1.Parent as ControlOrdServicios;

            var lcrAdmision = lobControlVista.gcrCodigoAdmision;
            var lcrCodigoRegistro = lobControlVista.gcrCodigoUnico;
            var lcrTipoRegistro = lobControlVista.gcrTipoRegistro;

            if (lobControlVista != null)
            {
                var lobRegVista = new HCLImprimir();

                lobRegVista.gcrFiltroReporte = "ADM";
                lobRegVista.gcrCodigoAdmision = lcrAdmision;
                lobRegVista.gcrCodigoRegistro = lcrCodigoRegistro;  // Codigo Hcl_nroreg_hcms
                lobRegVista.gcrTipoRegistro = lcrTipoRegistro;      // "HCON" = Hoja de consumo
                lobRegVista.glgVistaPrevia = true;                  // true = mostrar vista previa / fase = no mostrar vista previa
                lobRegVista.gobOwner = this;
                lobRegVista.fcvEjecutar();
            }
        }
        #endregion
        // Imprimir desde vista formatos diseñados en editor
        #region fcvAccImprimirVista: imprimir Vsita Diseño en pantalla (formato activo y confirmado)
        /// <summary>
        /// <para>imprimir Vsita Diseño en pantalla (formato activo y confirmado)</para>
        /// </summary>
        private void fcvAccImprimirVista(object sender, RoutedEventArgs e)
        {
            fcvAccImprimir();
        }
        #endregion
        #region fcvAccImprimir: imprimir Vsita formato activo y confirmado
        /// <summary>
        /// <para>imprimir Vsita formato activo y confirmado</para>
        /// </summary>
        public void fcvAccImprimir()
        {
            // Mostrar el cuadro de dialogo imprimir
            PrintDialog lobjDialogo = new PrintDialog();
            if (lobjDialogo.ShowDialog() != true) return;

            //MessageBox.Show("ancho " + lobjDialogo.PrintableAreaWidth.ToString() + " alto " + lobjDialogo.PrintableAreaHeight.ToString());
            //return;
            // Crear el documento
            FixedDocument lobjDocumento = new FixedDocument();
            lobjDocumento.DocumentPaginator.PageSize = new Size(lobjDialogo.PrintableAreaWidth, lobjDialogo.PrintableAreaHeight);

            // recorrer el temporal para cargar las paginas
            var tmpPaginas = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "PAGINA", "");
            foreach (var lobItem in tmpPaginas)
            {
                if (lobItem.TipoObjeto == "PAGINA" && (lobItem.SiImprimir == "True" || String.IsNullOrWhiteSpace(lobItem.SiImprimir)))
                {
                    // crear la pagina
                    FixedPage lobjPagina = new FixedPage();
                    lobjPagina.Width = lobjDocumento.DocumentPaginator.PageSize.Width;
                    lobjPagina.Height = lobjDocumento.DocumentPaginator.PageSize.Height;

                    // instancia del objeto contenedor pagina que esta e
                    UIElement lobjPagRef = lobItem.RefObjeto as UIElement;

                    var lobjPagCopia = Funciones.fuiClonarObjeto(lobjPagRef);
                    lobjPagina.Children.Add(lobjPagCopia);

                    // add el objeto pagina al documento
                    PageContent lobjPageContent = new PageContent();
                    ((IAddChild)lobjPageContent).AddChild(lobjPagina);
                    lobjDocumento.Pages.Add(lobjPageContent);
                }
            }
            // impimir
            lobjDialogo.PrintDocument(lobjDocumento.DocumentPaginator, "imprimir");
        }
        
        public void fcvAccImprimirvv()
        {
            // Mostrar el cuadro de dialogo imprimir
            PrintDialog lobjDialogo = new PrintDialog();
            if (lobjDialogo.ShowDialog() != true) return;

            MessageBox.Show(" ANTES ancho " + lobjDialogo.PrintableAreaWidth.ToString() + " alto " + lobjDialogo.PrintableAreaHeight.ToString());

            //lobjDialogo.PrintTicket.PageOrientation = PageOrientation.Landscape;
            //lobjDialogo.PrintTicket.PageMediaSize = new System.Printing.PageMediaSize(816,1296);

            //lobjDialogo.PrintQueue = new lobjDialogo.PrintQueue();
            //MessageBox.Show(" DESPUES ancho " + lobjDialogo.PrintableAreaWidth.ToString() + " alto " + lobjDialogo.PrintableAreaHeight.ToString());
            //return;

            // Leer tamaño paginas del diseño plantilla para imprimir
            //var lnuPlantillaWidth = Convert.ToInt32(XmlEntorno.tmpPlantilla.FirstOrDefault().PlantillaWidth);
            //var lnuPlantillaHeight = Convert.ToInt32(XmlEntorno.tmpPlantilla.FirstOrDefault().PlantillaHeight) + 200;


            // Crear el documento
            FixedDocument lobjDocumento = new FixedDocument();
            lobjDocumento.DocumentPaginator.PageSize = new Size(lobjDialogo.PrintableAreaWidth, lobjDialogo.PrintableAreaHeight);

            //lobjDocumento.DocumentPaginator.PageSize = new Size(lnuPlantillaWidth, lnuPlantillaHeight);

            //MessageBox.Show("ancho " + lobjDocumento.DocumentPaginator.PageSize.Width.ToString() + " alto " + lobjDocumento.DocumentPaginator.PageSize.Height.ToString());

            // recorrer el temporal para cargar las paginas
            var tmpPaginas = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "PAGINA", "");
            foreach (var lobItem in tmpPaginas)
            {
                if (lobItem.TipoObjeto == "PAGINA" && (lobItem.SiImprimir == "True" || String.IsNullOrWhiteSpace(lobItem.SiImprimir)))
                {
                    // Referencia a objeto pagina
                    var lobRefPag = lobItem.RefObjeto as Canvas;

                    // crear la pagina
                    FixedPage lobjPagina = new FixedPage();
                    lobjPagina.Width = lobjDocumento.DocumentPaginator.PageSize.Width;
                    lobjPagina.Height = lobjDocumento.DocumentPaginator.PageSize.Height;

                    //lobjPagina.Width = lobRefPag.Width;
                    //lobjPagina.Height = lobRefPag.Height;

                    // instancia del objeto contenedor pagina que esta e
                    UIElement lobjPagRef = lobItem.RefObjeto as UIElement;

                    var lobjPagCopia = (Canvas)Funciones.fuiClonarObjeto(lobjPagRef);

                    // llevar a la escala de la hoja
                    double scale = Math.Min(lobjPagina.Width / lobRefPag.ActualWidth, lobjPagina.Height / lobRefPag.ActualHeight);

                    //Transform la vista a la escala 
                    lobjPagCopia.LayoutTransform = new ScaleTransform(scale, scale);

                    Size sz = new Size(lobjPagina.Width, lobjPagina.Height);
                    lobjPagCopia.Measure(sz);

                    lobjPagina.Children.Add(lobjPagCopia);

                    // add el objeto pagina al documento
                    PageContent lobjPageContent = new PageContent();
                    ((IAddChild)lobjPageContent).AddChild(lobjPagina);
                    lobjDocumento.Pages.Add(lobjPageContent);
                    
                }
            }
            // impimir
            lobjDialogo.PrintDocument(lobjDocumento.DocumentPaginator, "imprimir");
        }
        #region fcvAccImprimir: imprimir Vsita formato activo y confirmado
        /// <summary>
        /// <para>imprimir Vsita formato activo y confirmado</para>
        /// </summary>
        public void fcvAccImprimireee()
        {
            // Mostrar el cuadro de dialogo imprimir
            PrintDialog lobjDialogo = new PrintDialog();
            if (lobjDialogo.ShowDialog() != true) return;

            MessageBox.Show(" ANTES ancho " + lobjDialogo.PrintableAreaWidth.ToString() + " alto " + lobjDialogo.PrintableAreaHeight.ToString());

            lobjDialogo.PrintTicket.PageMediaSize = new System.Printing.PageMediaSize(System.Printing.PageMediaSizeName.NorthAmericaLegal);
            //lobjDialogo.PrintQueue.SetPrintCapabilities(lobjDialogo.PrintTicket);

            //lobjDialogo.PrintQueue = new lobjDialogo.PrintQueue();
            MessageBox.Show(" DESPUES ancho " + lobjDialogo.PrintableAreaWidth.ToString() + " alto " + lobjDialogo.PrintableAreaHeight.ToString());
            //return;

            // Leer tamaño paginas del diseño plantilla para imprimir
            var lnuPlantillaWidth = Convert.ToInt32(XmlEntorno.tmpPlantilla.FirstOrDefault().PlantillaWidth);
            var lnuPlantillaHeight = Convert.ToInt32(XmlEntorno.tmpPlantilla.FirstOrDefault().PlantillaHeight) + 200;


            // Crear el documento
            FixedDocument lobjDocumento = new FixedDocument();
            //lobjDocumento.DocumentPaginator.PageSize = new Size(lobjDialogo.PrintableAreaWidth, lobjDialogo.PrintableAreaHeight);
            lobjDocumento.DocumentPaginator.PageSize = new Size(lnuPlantillaWidth, lnuPlantillaHeight);

            //MessageBox.Show("ancho " + lobjDocumento.DocumentPaginator.PageSize.Width.ToString() + " alto " + lobjDocumento.DocumentPaginator.PageSize.Height.ToString());

            // recorrer el temporal para cargar las paginas
            var tmpPaginas = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "PAGINA", "");
            foreach (var lobItem in tmpPaginas)
            {
                if (lobItem.TipoObjeto == "PAGINA" && (lobItem.SiImprimir == "True" || String.IsNullOrWhiteSpace(lobItem.SiImprimir)))
                {
                    // Referencia a objeto pagina
                    //var lobRefPag = lobItem.RefObjeto as Canvas;
                    // crear la pagina
                    FixedPage lobjPagina = new FixedPage();
                    lobjPagina.Width = lobjDocumento.DocumentPaginator.PageSize.Width;
                    lobjPagina.Height = lobjDocumento.DocumentPaginator.PageSize.Height;

                    //lobjPagina.Width = lobRefPag.Width;
                    //lobjPagina.Height = lobRefPag.Height;

                    // instancia del objeto contenedor pagina que esta e
                    UIElement lobjPagRef = lobItem.RefObjeto as UIElement;

                    var lobjPagCopia = Funciones.fuiClonarObjeto(lobjPagRef);
                    lobjPagina.Children.Add(lobjPagCopia);

                    // add el objeto pagina al documento
                    PageContent lobjPageContent = new PageContent();
                    ((IAddChild)lobjPageContent).AddChild(lobjPagina);
                    lobjDocumento.Pages.Add(lobjPageContent);
                }
            }
            // impimir
            lobjDialogo.PrintDocument(lobjDocumento.DocumentPaginator, "imprimir");
        }
        #endregion
        #endregion
        // Imprimir formatos en modo tipo informe
        #region fcvAccImprimirModoInforme: imprimir reporte modo tipo informe 
        /// <summary>
        /// <para>imprimir reporte modo tipo informe</para>
        /// </summary>
        private void fcvAccImprimirModoInforme(object sender, RoutedEventArgs e)
        {
            fcvAccImprimirModoInforme();
        }
        #endregion
        #region fcvAccImprimirModoInforme: imprimir reporte modo tipo informe 
        /// <summary>
        /// <para>imprimir reporte modo tipo informe</para>
        /// </summary>
        private void fcvAccImprimirModoInforme()
        {
            if (XmlEntorno.tmpPlantilla != null)
            {
                    if (XmlEntorno.flgPrnReporteImpresoraDetalles())
                    {
                        XmlEntorno.flgPrnReporteImpresoraMaestro();

                        var lobRegVista = new HCLImprimirFormatoHc();

                        //lobRegVista.gobArrayImgDiag = luxflujo1.ToArray();
                        //lobRegVista.gobArrayImgPlan = luxflujo2.ToArray();
                        // Falta buscar la firma del profesional

                        lobRegVista.lobRegMa          = XmlEntorno.lobPrnRegMa;
                        lobRegVista.tmpDetalles       = XmlEntorno.tmpPrnDetalles;
                        lobRegVista.gcrCodigoAdmision = XmlEntorno.gobRegHistorialActivo.Adm_secadm_rgad;
                        lobRegVista.gcrCodigoRegistro = XmlEntorno.gobRegHistorialActivo.Hcl_nroreg_hcev; // Registro del historial
                        lobRegVista.gcrTipoFormato    = XmlEntorno.gcrPlantillaTipoHojaReporte;   // Tipo formato ejemplo: hoja tamaño carta
                        lobRegVista.glgVistaPrevia    = true;     // true = mostrar vista previa / fase = no mostrar vista previa
                        lobRegVista.gobOwner = this;
                        lobRegVista.fcvEjecutar();
                    }
                    return;
            }
        }
        #endregion
        // Capturar pantalla y convertir en imagen
        #region fobCapturaScreen: Convierte en imagen la referencia de pantalla dada
        /// <summary>
        /// <para>Convierte en imagen la referencia de pantalla dada como objeto visual</para>
        /// </summary>
        private static RenderTargetBitmap fobCapturaScreen(Visual tobRefObjeto, double dpiX, double dpiY)
        {
            if (tobRefObjeto == null)
            {
                return null;
            }
            Rect lobRefRectangulo = VisualTreeHelper.GetDescendantBounds(tobRefObjeto);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)(lobRefRectangulo.Width * dpiX / 96.0), (int)(lobRefRectangulo.Height * dpiY / 96.0),
                                                            dpiX, dpiY, PixelFormats.Pbgra32);

            rtb.Render(tobRefObjeto);

            return rtb;
        }
        #endregion
        //---------------------------------------------------------------
        // Gestion codigo fuente de una plantilla 
        //---------------------------------------------------------------
        #region fcvCompilarCodigoFuentePlantilla: Compila y genera instancia del codigo fuente
        /// <summary>
        /// <para>Compila y genera instancia del codigo fuente asociado a un formato plantilla </para>
        /// </summary>
        private void fcvCompilarCodigoFuentePlantilla()
        {
            //String lcrCodigoFuente = System.IO.File.ReadAllText(@"C:\Users\JOSE\Desktop\estadisticas.cs");
            //String lcrCodigoFuente = System.IO.File.ReadAllText(@"C:\Users\familia\Desktop\estadisticas.cs");
            try
            {
                String lcrCodigoFuente = String.Empty;

                lcrCodigoFuente = XmlEntorno.gobRegPlantVersion.Grp_fcodig_grpv;
                if (!String.IsNullOrWhiteSpace(lcrCodigoFuente))
                {
                    var larListaDll = new List<String>();

                    larListaDll.Add("System.dll");
                    larListaDll.Add("System.Data.Entity.dll");
                    larListaDll.Add("System.IO.dll");
                    larListaDll.Add("System.Xaml.dll");
                    larListaDll.Add("System.Linq.dll");
                    larListaDll.Add("Datos.dll");
                    larListaDll.Add("System.Core.dll");
                    larListaDll.Add("WindowsBase.dll");
                    larListaDll.Add("PresentationCore.dll");
                    larListaDll.Add("PresentationFramework.dll");

                    //larListaDll.Add(@"c:\proyectos\galeno40\sistema\ensamblados\PresentationCore.dll");
                    //larListaDll.Add(@"c:\proyectos\galeno40\sistema\ensamblados\PresentationFramework.dll");
                    //larListaDll.Add("System.Windows.Forms.dll");

                    gobEnsamblado = Compilador.fobCompilarEnsamblado("C#", lcrCodigoFuente, larListaDll);

                    if (!flgCargarInstanciaInterface())
                    {
                        var lcrError = String.Empty;
                        foreach (CompilerError CompErr in gobEnsamblado.Errors)
                        {
                            lcrError += "Número de línea " + CompErr.Line +
                                        ", Número de error: " + CompErr.ErrorNumber +
                                        ", '" + CompErr.ErrorText + ";" +
                                        Environment.NewLine + Environment.NewLine;
                        }
                        MessageBox.Show("ERROR AL COMPILAR PLANTILA DE INFORME: " + lcrError);
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "VistaModelo Error Metodo: fcvCompilarCodigoFuentePlantilla");
            }

        }
        #endregion
        #region flgCargarInstanciaInterface: Cargar las interface para ser ejcutado el codigo fuente
        /// <summary>
        /// <para>Cargar las interface y referencia "oAppICodigofuente" para ser ejcutado el codigo fuente de una plantilla</para>
        /// </summary>
        private static bool flgCargarInstanciaInterface()
        {
            var llgReturn = false;
            if (gobEnsamblado.Errors == null || gobEnsamblado.Errors.Count == 0)
            {
                var lobScriptTypes = Compilador.farGetTypesInterface(gobEnsamblado.CompiledAssembly, typeof(IEjecutarCodigoFuente));

                llgReturn = lobScriptTypes != null ? true : false;
                gobRefoAppType = lobScriptTypes.FirstOrDefault();
                oAppICodigofuente = (Activator.CreateInstance(gobRefoAppType)) as IEjecutarCodigoFuente;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        // Pruebas
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*
            if (XmlEntorno.gobRegHistorialActivo.Sis_estpro_espr == "1")
            {
                MessageBox.Show("estado ok  : " + XmlEntorno.gobRegHistorialActivo.Sis_estpro_espr);
            }
            else
            {
                MessageBox.Show("estado no  : " + XmlEntorno.gobRegHistorialActivo.Sis_estpro_espr);
            }
            */

            //this.pdfArchivo.Visibility = Visibility.Visible;
            //this.pdfArchivo.Navigate("C:/Temp/hl7-fhir-latinomaerica.pdf");
            //this.pdfArchivo.Navigate("http://www.makiia.com");

            /*
            if (vm.GlgSIS_ModoGestionMultiSet == true)
            {
                MessageBox.Show("GlgSIS_ModoGestionMultiSet ok / gcrDatosModoGestion : " + XmlEntorno.gcrDatosModoGestion);
            }
            */
        }
    }
}

/*
namespace GestorReportes
{

    //--------------------------------------------------
    // PLANTILLA
    //--------------------------------------------------
    #region Estadisitcia
    public class EjecutarCodigoFuente : IEjecutarCodigoFuente
    {
        int lnuSumatoria = 0;
        TextBox txtTotal;

        public void fcrEjecutarCodigoFuente(Window tobWind, String tcrCodigoPlantilla, 
                                                                ref List<LogsErrores> tmpLogErrores,
                                                                ref List<ClassXmlPropObjeto> tmpObjetos,
                                                                ref List<ClassXmlPropDatos> tmpObDatos)
        {
            lnuSumatoria = 0;
 
            var lcrP1 = Funciones.fcrHclinicaLeerValorDato("cboComboBoxEX29", ref tmpObDatos);
            var lcrP2 = Funciones.fcrHclinicaLeerValorDato("cboComboBoxEX33", ref tmpObDatos);
            var lcrP3 = Funciones.fcrHclinicaLeerValorDato("cboComboBoxEX46", ref tmpObDatos);
            var lcrP4 = Funciones.fcrHclinicaLeerValorDato("cboComboBoxEX47", ref tmpObDatos);
            var lcrP5 = Funciones.fcrHclinicaLeerValorDato("cboComboBoxEX48", ref tmpObDatos);

            //MessageBox.Show("DATOS P1 " + lcrP1 + " P2 " + lcrP2 + " P3 " + lcrP3 + " P4 " + lcrP4 + " P5 " + lcrP5);

            if (!String.IsNullOrWhiteSpace(lcrP1) && lcrP1 != "*" ) { lnuSumatoria += Convert.ToInt32(lcrP1); }
            if (!String.IsNullOrWhiteSpace(lcrP2) && lcrP2 != "*" ) { lnuSumatoria += Convert.ToInt32(lcrP2); }
            if (!String.IsNullOrWhiteSpace(lcrP3) && lcrP3 != "*" ) { lnuSumatoria += Convert.ToInt32(lcrP3); }
            if (!String.IsNullOrWhiteSpace(lcrP4) && lcrP4 != "*" ) { lnuSumatoria += Convert.ToInt32(lcrP4); }
            if (!String.IsNullOrWhiteSpace(lcrP5) && lcrP5 != "*" ) { lnuSumatoria += Convert.ToInt32(lcrP5); }

            // Mostrar en vista en el cuatro de texto de sunatoria total
            txtTotal = Funciones.RefHclinicaTextBoxObjeto("txtTextBoxEX60", ref tmpObjetos);
            if (txtTotal != null) { txtTotal.Text = lnuSumatoria.ToString(); }

        }
    }
    #endregion
}
*/
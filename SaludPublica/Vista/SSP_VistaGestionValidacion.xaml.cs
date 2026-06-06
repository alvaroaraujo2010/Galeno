using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Media.Converters;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.Win32;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Data;
using Microsoft.CSharp;
using Sistema.Utilidades;
using Sistema.Vista;
using Sistema.Modelo;
using Datos.Modelos;
using Sistema.Clases;
using Sistema.Validacion;
using SaludPublica.VistaModelo;
using SaludPublica.Utilidades;
using SaludPublica.Modelo;
using Excel = Microsoft.Office.Interop.Excel;

namespace SaludPublica.Vista
{
    /// <summary>
    /// Interaction logic for SSP_VistaGestionValidacion.xaml
    /// </summary>
    public partial class VistaGestionValidacion : Window, IEdicionRegistro
    {
        #region Variables
        //- Variables para control de validacion 
        public static CompilerResults gobEnsamblado = null;
        public static Type gobRefoAppType = null;
        public static ParamValid4505 gobParam = new ParamValid4505();
        public static int gnuSecuencialErrores = 0;
        //- Variables para ejecuacion de Interface
        #region Referencias a Funciones personalizadas
        public static IValidador4505 oAppICampo000 = null;
        public static IValidador4505 oAppICampo001 = null;
        public static IValidador4505 oAppICampo002 = null;
        public static IValidador4505 oAppICampo003 = null;
        public static IValidador4505 oAppICampo004 = null;
        public static IValidador4505 oAppICampo005 = null;
        public static IValidador4505 oAppICampo006 = null;
        public static IValidador4505 oAppICampo007 = null;
        public static IValidador4505 oAppICampo008 = null;
        public static IValidador4505 oAppICampo009 = null;
        public static IValidador4505 oAppICampo010 = null;
        public static IValidador4505 oAppICampo011 = null;
        public static IValidador4505 oAppICampo012 = null;
        public static IValidador4505 oAppICampo013 = null;
        public static IValidador4505 oAppICampo014 = null;
        public static IValidador4505 oAppICampo015 = null;
        public static IValidador4505 oAppICampo016 = null;
        public static IValidador4505 oAppICampo017 = null;
        public static IValidador4505 oAppICampo018 = null;
        public static IValidador4505 oAppICampo019 = null;
        public static IValidador4505 oAppICampo020 = null;
        public static IValidador4505 oAppICampo021 = null;
        public static IValidador4505 oAppICampo022 = null;
        public static IValidador4505 oAppICampo023 = null;
        public static IValidador4505 oAppICampo024 = null;
        public static IValidador4505 oAppICampo025 = null;
        public static IValidador4505 oAppICampo026 = null;
        public static IValidador4505 oAppICampo027 = null;
        public static IValidador4505 oAppICampo028 = null;
        public static IValidador4505 oAppICampo029 = null;
        public static IValidador4505 oAppICampo030 = null;
        public static IValidador4505 oAppICampo031 = null;
        public static IValidador4505 oAppICampo032 = null;
        public static IValidador4505 oAppICampo033 = null;
        public static IValidador4505 oAppICampo034 = null;
        public static IValidador4505 oAppICampo035 = null;
        public static IValidador4505 oAppICampo036 = null;
        public static IValidador4505 oAppICampo037 = null;
        public static IValidador4505 oAppICampo038 = null;
        public static IValidador4505 oAppICampo039 = null;
        public static IValidador4505 oAppICampo040 = null;
        public static IValidador4505 oAppICampo041 = null;
        public static IValidador4505 oAppICampo042 = null;
        public static IValidador4505 oAppICampo043 = null;
        public static IValidador4505 oAppICampo044 = null;
        public static IValidador4505 oAppICampo045 = null;
        public static IValidador4505 oAppICampo046 = null;
        public static IValidador4505 oAppICampo047 = null;
        public static IValidador4505 oAppICampo048 = null;
        public static IValidador4505 oAppICampo049 = null;
        public static IValidador4505 oAppICampo050 = null;
        public static IValidador4505 oAppICampo051 = null;
        public static IValidador4505 oAppICampo052 = null;
        public static IValidador4505 oAppICampo053 = null;
        public static IValidador4505 oAppICampo054 = null;
        public static IValidador4505 oAppICampo055 = null;
        public static IValidador4505 oAppICampo056 = null;
        public static IValidador4505 oAppICampo057 = null;
        public static IValidador4505 oAppICampo058 = null;
        public static IValidador4505 oAppICampo059 = null;
        public static IValidador4505 oAppICampo060 = null;
        public static IValidador4505 oAppICampo061 = null;
        public static IValidador4505 oAppICampo062 = null;
        public static IValidador4505 oAppICampo063 = null;
        public static IValidador4505 oAppICampo064 = null;
        public static IValidador4505 oAppICampo065 = null;
        public static IValidador4505 oAppICampo066 = null;
        public static IValidador4505 oAppICampo067 = null;
        public static IValidador4505 oAppICampo068 = null;
        public static IValidador4505 oAppICampo069 = null;
        public static IValidador4505 oAppICampo070 = null;
        public static IValidador4505 oAppICampo071 = null;
        public static IValidador4505 oAppICampo072 = null;
        public static IValidador4505 oAppICampo073 = null;
        public static IValidador4505 oAppICampo074 = null;
        public static IValidador4505 oAppICampo075 = null;
        public static IValidador4505 oAppICampo076 = null;
        public static IValidador4505 oAppICampo077 = null;
        public static IValidador4505 oAppICampo078 = null;
        public static IValidador4505 oAppICampo079 = null;
        public static IValidador4505 oAppICampo080 = null;
        public static IValidador4505 oAppICampo081 = null;
        public static IValidador4505 oAppICampo082 = null;
        public static IValidador4505 oAppICampo083 = null;
        public static IValidador4505 oAppICampo084 = null;
        public static IValidador4505 oAppICampo085 = null;
        public static IValidador4505 oAppICampo086 = null;
        public static IValidador4505 oAppICampo087 = null;
        public static IValidador4505 oAppICampo088 = null;
        public static IValidador4505 oAppICampo089 = null;
        public static IValidador4505 oAppICampo090 = null;
        public static IValidador4505 oAppICampo091 = null;
        public static IValidador4505 oAppICampo092 = null;
        public static IValidador4505 oAppICampo093 = null;
        public static IValidador4505 oAppICampo094 = null;
        public static IValidador4505 oAppICampo095 = null;
        public static IValidador4505 oAppICampo096 = null;
        public static IValidador4505 oAppICampo097 = null;
        public static IValidador4505 oAppICampo098 = null;
        public static IValidador4505 oAppICampo099 = null;
        public static IValidador4505 oAppICampo100 = null;
        public static IValidador4505 oAppICampo101 = null;
        public static IValidador4505 oAppICampo102 = null;
        public static IValidador4505 oAppICampo103 = null;
        public static IValidador4505 oAppICampo104 = null;
        public static IValidador4505 oAppICampo105 = null;
        public static IValidador4505 oAppICampo106 = null;
        public static IValidador4505 oAppICampo107 = null;
        public static IValidador4505 oAppICampo108 = null;
        public static IValidador4505 oAppICampo109 = null;
        public static IValidador4505 oAppICampo110 = null;
        public static IValidador4505 oAppICampo111 = null;
        public static IValidador4505 oAppICampo112 = null;
        public static IValidador4505 oAppICampo113 = null;
        public static IValidador4505 oAppICampo114 = null;
        public static IValidador4505 oAppICampo115 = null;
        public static IValidador4505 oAppICampo116 = null;
        public static IValidador4505 oAppICampo117 = null;
        public static IValidador4505 oAppICampo118 = null;
        #endregion
        // variables varias
        bool glgObjetosCargados              = false;
        bool glgObjetosExpander              = false;
        bool glgVistaPropiedades             = false;
        bool glgVistaMenuSuperiorVisible     = false;
        bool glgVistaSeleccionPropiedades    = false;
        bool glgVistaEtiquetaEstadoVisible   = false;
        public String gcrOrigenDatosCargados = "PLANO";// BDATOS/EXCEL/PLANO
        public String gcrCodigoPeriodo       = String.Empty;
        public String gcrPeriodoMes          = String.Empty;
        public String gcrPeriodoAño          = String.Empty;
        public String gcrFechaFormato        = String.Empty;
        public String gcrFechaSeparador      = String.Empty;
        public String gcrTipoCargueDatos     = "CARGUE";   // CARGUE = Archivo 4505 / GENERAR = Generar desde H.clinica
        public String gcrTipoExportar        = "PLANO";    // PLANO/EXCEL
        static ModeloSspNsRes4505Ex tmpRegActMS4505       = null;
        static ModeloSspNsRes4505Ex tmpRegActMS4505Dfl    = null;
        static VistaModeloGestionValidacion vm            = null;
        //---------------------------------------------------
        // Temporales gestion sql nativa
        static DataRow tmpRegGestion             = null;
        static DataTable tmpListServFacturacion  = null;
        static DataTable tmpListFormatosHistori  = null;
        //---------------------------------------------------
        // temporales segun Modelos datos
        List<ModeloSptabcamposplan> tmpCamposHC4505          = null;
        List<ModeloGrupoActividadesMA> tmpListGrupoActividad = null;
        List<ModeloSpactivservfactMD> tmpListGrupoDetalles   = null;
        List<ModeloSpactivservfactMD> tmpDetallGrupoActivo   = null;
        List<FcmModeloServDetallFacturas> tmpDetallesFact    = null;
        List<FcmModeloServDetallFacturas> tmpDetallFactAdd   = null;
        List<ModeloSpaActivRegApEventos> tmpDetallAdmEven    = null;
        List<ModeloSpaActivRegApEventos> tmpDetallAdmEvenAux = null;
        // para gestion variables publicas en plantillas H.C
        List<ModeloSpactivMedicVarMD> tmpListActivMedicVar = null;
        List<ModeloGrpplantvistcam> tmpListPlantVarPubGru  = null;
        //- referencia a objetos combobox vista capa 4505
        List<ObjetosVista> tmpListRefObjVista4505 = null;
        //---------------------------------------------------
        public String gcrCtrF2TexBox = String.Empty;
        Aplicacion oApp = Aplicacion.Instancia();

        // Filtro grillas
        CollectionViewSource _DataGridListFiltro = null;
        ICollectionView DataGridItemFiltro = null;
        CollectionViewSource _DataGridSErroresFiltro = null;
        ICollectionView DataGridVErroresFiltro = null;
        // Varialbes para control de importar y exporta
        #region Varialbes para control de importar y exportar
        public String gcrArchivoExternoNombre       = String.Empty;
        public String gcrArchivoExternoNombreyRuta  = String.Empty;
        public String gcrArchivoExternoRuta         = String.Empty;
        public String gcrExportarArchivoNombre      = String.Empty;
        //public String gcrExportarArchivoNombreyRuta = @"C:\Users\JOSE\Desktop\ARCHIVOPLANOEJM.XLS";
        public String gcrExportarArchivoNombreyRuta = @"C:\Users\familia\Desktop\ARCHIVOPLANOEJM.TXT";
        public String gcrExportarArchivoRuta        = String.Empty;
        public String gcrExportarArchivoSeparador   = "|";
        public int gnuContadorvistaArchivos         = 0;
        #endregion
        #endregion
        #region Iniciar Formulario principal
        public VistaGestionValidacion()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloGestionValidacion; //Binding con el Vista Modelo
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            vm.TmpG2ListaBrow = new System.Collections.ObjectModel.ObservableCollection<ModeloSspNsRes4505Ex>();
            fcrRefVar4505Expander();
            glgObjetosCargados = true;
            fcvResizePantalla();
            fcvTimerGeneral();
            //- Valores por defecto 
            this.txtG1Ssp_forfec_sscf.Text = "YMD";
            this.txtG1Ssp_sepfec_sscf.Text = "2";
            this.txtG1Ssp_regims_sgss.Text = "S";

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            this.dpkG1Ssp_cam009_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam029_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam031_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam033_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam049_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam050_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam051_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam052_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam053_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam055_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam056_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam058_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam062_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam063_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam064_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam065_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam066_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam067_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam068_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam069_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam072_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam073_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam075_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam076_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam078_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam080_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam082_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam084_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam087_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam091_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam093_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam096_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam099_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam100_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam103_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam105_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam106_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam108_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam110_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam111_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam112_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Ssp_cam118_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion                  

            // cargar referencias de objetos para gestion vista combobox
            //fcvRefVar4505GenTemporalReferencia();
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
            double lduBarraWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 100;
            double lduWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 10;
            double lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 96.8;
            double lduHistHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 77;

            this.grdPropiedadZona1.Height = lduHeight;
            this.grdPropSelect.Height     = lduHeight;
            this.objHistCortina.Height    = lduHeight;

            this.grdFondoEscritorio.Width = lduBarraWidth - (lduBarraWidth * 0.055);
            this.cvaEtiqueta.Width = lduBarraWidth - (lduBarraWidth * 0.029);
            this.grdEtiqueta.Width = lduBarraWidth - (lduBarraWidth * 0.029);
            this.grdMenuSuperior.Width = lduBarraWidth - (lduBarraWidth * 0.028);
            Canvas.SetTop(objHistCortina, 2);

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
        // PROCESOS CONTROLADOS CON TIMER GENERAL
        #region fcvTimerProcesos: Timer para control Click y Touch X Horizontal
        /// <summary>
        /// <para>Timer para control Click y Touch X Horizontal</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            this.TxtHora.Text = DateTime.Now.ToString("f");//hh:mm tt dd/MM/yyyy");

            // al mostrar la vista propiedades
            if (glgVistaPropiedades == true && this.objHistCortina.Visibility == Visibility.Visible)
            {
                var lduPosHist = Math.Abs(Canvas.GetLeft(this.grdPropiedadZona1));
                if (lduPosHist < 15)
                {
                    this.objHistCortina.Visibility = Visibility.Collapsed;
                }
            }
            if (IsLoaded == true && glgObjetosExpander == false)
            {
                glgObjetosExpander = true;
                fcrRefVar4505Expander();
                fcrRefVar4505Expander(this.stkBasicas as Visual);
                fcvRefVar4505GenTemporalReferencia();
                fcrRefVar4505ExpanderVisibles(Visibility.Collapsed);
            }
        }
        #endregion
        //------------------------------------------------------------
        // ACCIONES BARRA DE OPCIONES SUPERIOR
        //------------------------------------------------------------
        #region Configuracion y acciones barra superior
        #region fcvMostrarMenuContextual: Mostrar menu contextual
        private void fcvMostrarMenuContextual(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #endregion
        //- MENU DESPLEGABLE OPCIONES 
        #region fcvCmdCerrarVista: Cerrar la plantilla abierta
        /// <summary>
        ///  fcvCmdCerrarVista: cerrar la plantilla abierta
        /// </summary>
        private void fcvCmdCerrarVista(object sender, RoutedEventArgs e)
        {
            //fcvCerrarVistaDatos();
        }
        #endregion
        #region  fcvPlantillaAbrir: Abrir Plantilla
        private void fcvPlantillaAbrir(object sender, RoutedEventArgs e)
        {
            /*
            Browser02 frbro = new Browser02("HCL", "HCLMAESTROHISCL", 1, "1*TODOS", "Maestro de historias clínicas...");
            gcrCtrF2TexBox = "ABRIR";
            frbro.Owner = this;
            frbro.ShowDialog();
            */
        }
        #endregion
        //- EJECUTAR VALIDACION 
        #region  fcvEjecutaValidacion: Ejecutar la validacion
        private void fcvEjecutaValidacion(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Iniciar la validación?", "Galeno Versión 4.0", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                fcvIniciarValidacionDatos();
            }
        }
        #endregion
        // ACTUALIZAR BASE DE DATOS
        #region fcvVerificarDatosParaBaseDeDatos: Verificar datos antes de add a base de datos
        private void fcvVerificarDatosParaBaseDeDatos(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Verificar datos para actualizar base de datos?", "Galeno Versión 4.0", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                flgVerificarDatosParaBaseDeDatos();
            }
        }
        #endregion
        #region fcvActualizarDatosEnBaseDeDatos: Actaulizar datos en base de datos
        private void fcvActualizarDatosEnBaseDeDatos(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Cargar o Actualizar base de datos?", "Galeno Versión 4.0", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                flgActualizarDatosEnBaseDeDatos();
            }
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
        #region Ventana Propiedades de la izquierda
        #region fcvActivarVistaHistorial: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Propiedades de la izquierda</para>
        /// </summary>
        private void fcvActivarVistaPropiedades(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaPropiedad();
        }
        #endregion
        #region fcvActivarVistaPropiedadMouseEnter: Mostrar Ventana Propiedades de la izquierda
        /// <summary>
        /// <para>Mostrar Ventana Propiedades de la izquierda</para>
        /// </summary>
        private void fcvActivarVistaPropiedadMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaPropiedades == false)
            {
                fcvActivarVistaPropiedad();
            }
        }
        #endregion
        #region fcvActivarVistaPropiedadTouchEnter: Mostrar Ventana Propiedades de la izquierda
        /// <summary>
        /// <para>Mostrar Ventana Propiedades de la izquierda</para>
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
        #region fcvActivarVistaHistorial: Mostrar u Ocultar Ventana Propiedades de la izquierda
        /// <summary>
        /// <para>Mostrar u Ocultar Ventana Propiedades de la izquierda</para>
        /// </summary>
        private void fcvActivarVistaPropiedad()
        {
            this.objHistCortina.Visibility = Visibility.Visible;
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropiedades == false)
            {
                luxAnimacion.To = 8; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
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
        #region Ventana Variables 4505
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar la Ventana Variables 4505
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Variables 4505</para>
        /// </summary>
        private void fcvActivarVistaSeleccion(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaSeleccion();
        }
        #endregion
        #region fcvActivarVistaSeleccionMouseEnter: Mostrar Ventana detalles servicios
        /// <summary>
        /// <para>Mostrar Ventana Variables 4505</para>
        /// </summary>
        private void fcvActivarVistaSeleccionMouseEnter(object sender, MouseEventArgs e)
        {
            if (glgVistaSeleccionPropiedades == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccionTouchEnter: Mostrar Ventana Variables 4505
        /// <summary>
        /// <para>Mostrar Ventana Variables 4505</para>
        /// </summary>
        private void fcvActivarVistaSeleccionTouchEnter(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            if (glgVistaSeleccionPropiedades == false)
            {
                fcvActivarVistaSeleccion();
            }
        }
        #endregion
        #region fcvActivarVistaSeleccion: Mostrar u Ocultar Ventana Variables 4505
        /// <summary>
        /// <para>Mostrar u Ocultar Ventana Variables 4505</para>
        /// </summary>
        private void fcvActivarVistaSeleccion()
        {
            //this.objHistCortina.Visibility = Visibility.Visible;
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaSeleccionPropiedades == false)
            {
                luxAnimacion.To = -618; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaSeleccionPropiedades = true;
            }
            else
            {
                luxAnimacion.To = 22; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaSeleccionPropiedades = false;
            }
            this.grdPropSelect.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
        #endregion  
        #region Capa Vista Errores validacion
        #region fcvActivarEtiqueta: Mostrar u Ocultar Vista Capa errores
        /// <summary>
        /// <para>Mostrar u Ocultar Vista Capa errores</para> 
        /// </summary>
        private void fcvActivarEtiqueta(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaErroresValid();
        }
        #endregion
        #region fcvVerDatosCapaErroresMouseDown: Gestion para mostrar datos capa errores
        /// <summary>
        /// <para>Gestion para mostrar datos capa errores</para>
        /// </summary>
        private void fcvVerDatosCapaErroresMouseDown(object sender, MouseButtonEventArgs e)
        {
            fcvActivarVistaErroresValid();
        }
        #endregion
        #region fcvActivarVistaErroresValid: Mostrar u Ocultar Vista Capa errores
        /// <summary>
        /// <para>Mostrar u Ocultar Vista Capa errores</para> 
        /// </summary>
        private void fcvActivarVistaErroresValid()
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaEtiquetaEstadoVisible == false)
            {
                luxAnimacion.To = -545; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaEtiquetaEstadoVisible = true;
                this.grdEtiqueta.BeginAnimation(Canvas.TopProperty, luxAnimacion);
            }
            else
            {
                luxAnimacion.To = 8; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaEtiquetaEstadoVisible = false;
                this.grdEtiqueta.BeginAnimation(Canvas.TopProperty, luxAnimacion);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // Cerrar o Minimizar la aplicacion
        //------------------------------------------------------------
        #region Cerrar Vista Modulo
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
        }
        #endregion
        //-------------------------------------------------
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region fcvBuscarRegistro: Metodo que recoge el valor Key desde browser F2
        /// <summary>
        /// <para>recoger el codigo dado en Browser de busqueda con  tecla F2</para>
        /// </summary>
        public void fcvBuscarRegistro(String tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Sis_secreg_siva":
                    this.txtG1Sis_secreg_siva.Text = tcrCodigo;
                    break;

                case "SELECTARCHIVO":
                    this.txtG1Ssp_codper_peri.Text = tcrCodigo;
                    fcvDatosFechasDelPeriodo(tcrCodigo);
                    gcrCtrF2TexBox = "OK";
                    break;

                case "txtG1Ssp_codper_peri":
                    this.txtG1Ssp_codper_peri.Text = tcrCodigo;
                    fcvDatosFechasDelPeriodo(tcrCodigo);
                    break;

                case "txtG1Sia_codeps_teps":
                    this.txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                default:
                    // seleccion desde un browser para una tabla
                    //gcrCtrF2TexBoxObj.Text = tcrCodigo;
                    break;
            }
        }
        #endregion
        #region fcvDatosFechasDelPeriodo: Metodo que recoge Fechas del periodo seleccionado
        /// <summary>
        /// <para>Metodo que recoge Fechas del periodo seleccionado</para>
        /// </summary>
        public void fcvDatosFechasDelPeriodo(String tcrCodigoPeriodo)
        {
            var tmp = SSPValidarCodigo.fobRegBuscarSptablaperiodos(tcrCodigoPeriodo);
            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.ssp_codper_peri))
            {
                this.txtG1Ssp_fecini_peri.Text = Funciones.fcrConvertFecha((DateTime)tmp.ssp_fecini_peri);
                this.txtG1Ssp_fecfin_peri.Text = Funciones.fcrConvertFecha((DateTime)tmp.ssp_fecfin_peri);
            }
        }
        #endregion
        #region fcvIEdicionRegistro: Metodo que recoge registro modificado en la vista
        /// <summary>
        /// <para>Metodo que recoge registro modificado en la vista</para>
        /// </summary>
        public void fcvIEdicionRegistro(ModeloSspNsRes4505Ex tobRegistro)
        {
            if (tobRegistro != null)
            {
                var lobRegEx = vm.TmpG2ListaBrow.FirstOrDefault(x => x.Ssp_ideaux_ns45.Equals(tobRegistro.Ssp_ideaux_ns45));
                if (lobRegEx != null)
                {
                    #region Valores actualizados
                    lobRegEx.Sia_idesec_usua = tobRegistro.Sia_idesec_usua;
                    lobRegEx.Sia_nroide_usua = tobRegistro.Sia_nroide_usua;
                    lobRegEx.Sia_codeps_teps = tobRegistro.Sia_codeps_teps;
                    lobRegEx.Ssp_cam000_ms45 = tobRegistro.Ssp_cam000_ms45;
                    lobRegEx.Ssp_cam001_ms45 = tobRegistro.Ssp_cam001_ms45;
                    lobRegEx.Ssp_cam002_ms45 = tobRegistro.Ssp_cam002_ms45;
                    lobRegEx.Ssp_cam003_ms45 = tobRegistro.Ssp_cam003_ms45;
                    lobRegEx.Ssp_cam004_ms45 = tobRegistro.Ssp_cam004_ms45;
                    lobRegEx.Ssp_cam005_ms45 = tobRegistro.Ssp_cam005_ms45;
                    lobRegEx.Ssp_cam006_ms45 = tobRegistro.Ssp_cam006_ms45;
                    lobRegEx.Ssp_cam007_ms45 = tobRegistro.Ssp_cam007_ms45;
                    lobRegEx.Ssp_cam008_ms45 = tobRegistro.Ssp_cam008_ms45;
                    lobRegEx.Ssp_cam009_ms45 = tobRegistro.Ssp_cam009_ms45;
                    lobRegEx.Ssp_cam010_ms45 = tobRegistro.Ssp_cam010_ms45;
                    lobRegEx.Ssp_cam011_ms45 = tobRegistro.Ssp_cam011_ms45;
                    lobRegEx.Ssp_codocu_ciuo = tobRegistro.Ssp_codocu_ciuo;
                    lobRegEx.Ssp_cam013_ms45 = tobRegistro.Ssp_cam013_ms45;
                    lobRegEx.Ssp_cam014_ms45 = tobRegistro.Ssp_cam014_ms45;
                    lobRegEx.Ssp_cam015_ms45 = tobRegistro.Ssp_cam015_ms45;
                    lobRegEx.Ssp_cam016_ms45 = tobRegistro.Ssp_cam016_ms45;
                    lobRegEx.Ssp_cam017_ms45 = tobRegistro.Ssp_cam017_ms45;
                    lobRegEx.Ssp_cam018_ms45 = tobRegistro.Ssp_cam018_ms45;
                    lobRegEx.Ssp_cam019_ms45 = tobRegistro.Ssp_cam019_ms45;
                    lobRegEx.Ssp_cam020_ms45 = tobRegistro.Ssp_cam020_ms45;
                    lobRegEx.Ssp_cam021_ms45 = tobRegistro.Ssp_cam021_ms45;
                    lobRegEx.Ssp_cam022_ms45 = tobRegistro.Ssp_cam022_ms45;
                    lobRegEx.Ssp_cam023_ms45 = tobRegistro.Ssp_cam023_ms45;
                    lobRegEx.Ssp_cam024_ms45 = tobRegistro.Ssp_cam024_ms45;
                    lobRegEx.Ssp_cam025_ms45 = tobRegistro.Ssp_cam025_ms45;
                    lobRegEx.Ssp_cam026_ms45 = tobRegistro.Ssp_cam026_ms45;
                    lobRegEx.Ssp_cam027_ms45 = tobRegistro.Ssp_cam027_ms45;
                    lobRegEx.Ssp_cam028_ms45 = tobRegistro.Ssp_cam028_ms45;
                    lobRegEx.Ssp_cam029_ms45 = tobRegistro.Ssp_cam029_ms45;
                    lobRegEx.Ssp_cam030_ms45 = tobRegistro.Ssp_cam030_ms45;
                    lobRegEx.Ssp_cam031_ms45 = tobRegistro.Ssp_cam031_ms45;
                    lobRegEx.Ssp_cam032_ms45 = tobRegistro.Ssp_cam032_ms45;
                    lobRegEx.Ssp_cam033_ms45 = tobRegistro.Ssp_cam033_ms45;
                    lobRegEx.Ssp_cam034_ms45 = tobRegistro.Ssp_cam034_ms45;
                    lobRegEx.Ssp_cam035_ms45 = tobRegistro.Ssp_cam035_ms45;
                    lobRegEx.Ssp_cam036_ms45 = tobRegistro.Ssp_cam036_ms45;
                    lobRegEx.Ssp_cam037_ms45 = tobRegistro.Ssp_cam037_ms45;
                    lobRegEx.Ssp_cam038_ms45 = tobRegistro.Ssp_cam038_ms45;
                    lobRegEx.Ssp_cam039_ms45 = tobRegistro.Ssp_cam039_ms45;
                    lobRegEx.Ssp_cam040_ms45 = tobRegistro.Ssp_cam040_ms45;
                    lobRegEx.Ssp_cam041_ms45 = tobRegistro.Ssp_cam041_ms45;
                    lobRegEx.Ssp_cam042_ms45 = tobRegistro.Ssp_cam042_ms45;
                    lobRegEx.Ssp_cam043_ms45 = tobRegistro.Ssp_cam043_ms45;
                    lobRegEx.Ssp_cam044_ms45 = tobRegistro.Ssp_cam044_ms45;
                    lobRegEx.Ssp_cam045_ms45 = tobRegistro.Ssp_cam045_ms45;
                    lobRegEx.Ssp_cam046_ms45 = tobRegistro.Ssp_cam046_ms45;
                    lobRegEx.Ssp_cam047_ms45 = tobRegistro.Ssp_cam047_ms45;
                    lobRegEx.Ssp_cam048_ms45 = tobRegistro.Ssp_cam048_ms45;
                    lobRegEx.Ssp_cam049_ms45 = tobRegistro.Ssp_cam049_ms45;
                    lobRegEx.Ssp_cam050_ms45 = tobRegistro.Ssp_cam050_ms45;
                    lobRegEx.Ssp_cam051_ms45 = tobRegistro.Ssp_cam051_ms45;
                    lobRegEx.Ssp_cam052_ms45 = tobRegistro.Ssp_cam052_ms45;
                    lobRegEx.Ssp_cam053_ms45 = tobRegistro.Ssp_cam053_ms45;
                    lobRegEx.Ssp_cam054_ms45 = tobRegistro.Ssp_cam054_ms45;
                    lobRegEx.Ssp_cam055_ms45 = tobRegistro.Ssp_cam055_ms45;
                    lobRegEx.Ssp_cam056_ms45 = tobRegistro.Ssp_cam056_ms45;
                    lobRegEx.Ssp_cam057_ms45 = tobRegistro.Ssp_cam057_ms45;
                    lobRegEx.Ssp_cam058_ms45 = tobRegistro.Ssp_cam058_ms45;
                    lobRegEx.Ssp_cam059_ms45 = tobRegistro.Ssp_cam059_ms45;
                    lobRegEx.Ssp_cam060_ms45 = tobRegistro.Ssp_cam060_ms45;
                    lobRegEx.Ssp_cam061_ms45 = tobRegistro.Ssp_cam061_ms45;
                    lobRegEx.Ssp_cam062_ms45 = tobRegistro.Ssp_cam062_ms45;
                    lobRegEx.Ssp_cam063_ms45 = tobRegistro.Ssp_cam063_ms45;
                    lobRegEx.Ssp_cam064_ms45 = tobRegistro.Ssp_cam064_ms45;
                    lobRegEx.Ssp_cam065_ms45 = tobRegistro.Ssp_cam065_ms45;
                    lobRegEx.Ssp_cam066_ms45 = tobRegistro.Ssp_cam066_ms45;
                    lobRegEx.Ssp_cam067_ms45 = tobRegistro.Ssp_cam067_ms45;
                    lobRegEx.Ssp_cam068_ms45 = tobRegistro.Ssp_cam068_ms45;
                    lobRegEx.Ssp_cam069_ms45 = tobRegistro.Ssp_cam069_ms45;
                    lobRegEx.Ssp_cam070_ms45 = tobRegistro.Ssp_cam070_ms45;
                    lobRegEx.Ssp_cam071_ms45 = tobRegistro.Ssp_cam071_ms45;
                    lobRegEx.Ssp_cam072_ms45 = tobRegistro.Ssp_cam072_ms45;
                    lobRegEx.Ssp_cam073_ms45 = tobRegistro.Ssp_cam073_ms45;
                    lobRegEx.Ssp_cam074_ms45 = tobRegistro.Ssp_cam074_ms45;
                    lobRegEx.Ssp_cam075_ms45 = tobRegistro.Ssp_cam075_ms45;
                    lobRegEx.Ssp_cam076_ms45 = tobRegistro.Ssp_cam076_ms45;
                    lobRegEx.Ssp_cam077_ms45 = tobRegistro.Ssp_cam077_ms45;
                    lobRegEx.Ssp_cam078_ms45 = tobRegistro.Ssp_cam078_ms45;
                    lobRegEx.Ssp_cam079_ms45 = tobRegistro.Ssp_cam079_ms45;
                    lobRegEx.Ssp_cam080_ms45 = tobRegistro.Ssp_cam080_ms45;
                    lobRegEx.Ssp_cam081_ms45 = tobRegistro.Ssp_cam081_ms45;
                    lobRegEx.Ssp_cam082_ms45 = tobRegistro.Ssp_cam082_ms45;
                    lobRegEx.Ssp_cam083_ms45 = tobRegistro.Ssp_cam083_ms45;
                    lobRegEx.Ssp_cam084_ms45 = tobRegistro.Ssp_cam084_ms45;
                    lobRegEx.Ssp_cam085_ms45 = tobRegistro.Ssp_cam085_ms45;
                    lobRegEx.Ssp_cam086_ms45 = tobRegistro.Ssp_cam086_ms45;
                    lobRegEx.Ssp_cam087_ms45 = tobRegistro.Ssp_cam087_ms45;
                    lobRegEx.Ssp_cam088_ms45 = tobRegistro.Ssp_cam088_ms45;
                    lobRegEx.Ssp_cam089_ms45 = tobRegistro.Ssp_cam089_ms45;
                    lobRegEx.Ssp_cam090_ms45 = tobRegistro.Ssp_cam090_ms45;
                    lobRegEx.Ssp_cam091_ms45 = tobRegistro.Ssp_cam091_ms45;
                    lobRegEx.Ssp_cam092_ms45 = tobRegistro.Ssp_cam092_ms45;
                    lobRegEx.Ssp_cam093_ms45 = tobRegistro.Ssp_cam093_ms45;
                    lobRegEx.Ssp_cam094_ms45 = tobRegistro.Ssp_cam094_ms45;
                    lobRegEx.Ssp_cam095_ms45 = tobRegistro.Ssp_cam095_ms45;
                    lobRegEx.Ssp_cam096_ms45 = tobRegistro.Ssp_cam096_ms45;
                    lobRegEx.Ssp_cam097_ms45 = tobRegistro.Ssp_cam097_ms45;
                    lobRegEx.Ssp_cam098_ms45 = tobRegistro.Ssp_cam098_ms45;
                    lobRegEx.Ssp_cam099_ms45 = tobRegistro.Ssp_cam099_ms45;
                    lobRegEx.Ssp_cam100_ms45 = tobRegistro.Ssp_cam100_ms45;
                    lobRegEx.Ssp_cam101_ms45 = tobRegistro.Ssp_cam101_ms45;
                    lobRegEx.Ssp_cam102_ms45 = tobRegistro.Ssp_cam102_ms45;
                    lobRegEx.Ssp_cam103_ms45 = tobRegistro.Ssp_cam103_ms45;
                    lobRegEx.Ssp_cam104_ms45 = tobRegistro.Ssp_cam104_ms45;
                    lobRegEx.Ssp_cam105_ms45 = tobRegistro.Ssp_cam105_ms45;
                    lobRegEx.Ssp_cam106_ms45 = tobRegistro.Ssp_cam106_ms45;
                    lobRegEx.Ssp_cam107_ms45 = tobRegistro.Ssp_cam107_ms45;
                    lobRegEx.Ssp_cam108_ms45 = tobRegistro.Ssp_cam108_ms45;
                    lobRegEx.Ssp_cam109_ms45 = tobRegistro.Ssp_cam109_ms45;
                    lobRegEx.Ssp_cam110_ms45 = tobRegistro.Ssp_cam110_ms45;
                    lobRegEx.Ssp_cam111_ms45 = tobRegistro.Ssp_cam111_ms45;
                    lobRegEx.Ssp_cam112_ms45 = tobRegistro.Ssp_cam112_ms45;
                    lobRegEx.Ssp_cam113_ms45 = tobRegistro.Ssp_cam113_ms45;
                    lobRegEx.Ssp_cam114_ms45 = tobRegistro.Ssp_cam114_ms45;
                    lobRegEx.Ssp_cam115_ms45 = tobRegistro.Ssp_cam115_ms45;
                    lobRegEx.Ssp_cam116_ms45 = tobRegistro.Ssp_cam116_ms45;
                    lobRegEx.Ssp_cam117_ms45 = tobRegistro.Ssp_cam117_ms45;
                    lobRegEx.Ssp_cam118_ms45 = tobRegistro.Ssp_cam118_ms45;
                    #endregion
                }
            }
        }
        #endregion
        #region SIS_SECREG_SIVA : Maestro plantillas para validación de archivos
        private void txtG1Sis_secreg_siva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sis_secreg_siva_Browser();
            }
        }
        private void cmdG1Sis_secreg_siva_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sis_secreg_siva_Browser();
        }
        private void txtG1Sis_secreg_siva_Browser()
        {
            var lcrFiltro = "Sismaesplavalid.sis_codarc_siar = 'RE4505'";

            Browser01 frbro = new Browser01("SIS", "SISMAESPLAVALID", lcrFiltro, "Maestro plantillas para validación de archivos...");
            gcrCtrF2TexBox = "txtG1Sis_secreg_siva";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SSP_CODPER_PERI : Tabla periodos RES4505
        private void txtG1Ssp_codper_peri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                fcvG1Ssp_codper_peri_Browser();
            }
        }
        private void cmdG1Ssp_codper_peri_Click(object sender, RoutedEventArgs e)
        {
            fcvG1Ssp_codper_peri_Browser();
        }
        private void fcvG1Ssp_codper_peri_Browser()
        {
            Browser01 frbro = new Browser01("SSP", "SPTABLAPERIODOS", "", "Tabla periodos Resolución 4505...");
            gcrCtrF2TexBox = "txtG1Ssp_codper_peri";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        private void fcvBrowserSeleccionPeriodo()
        {
            Browser01 frbro = new Browser01("SSP", "SPTABLAPERIODOS", "", "Tabla periodos Resolución 4505...");
            gcrCtrF2TexBox = "SELECTARCHIVO";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODEPS_TEPS : Lista de EPS o aseguradores
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
            Browser01 frbro = new Browser01("SIA", "SIATABLAEPS", "", "Lista de EPS o aseguradores...");
            gcrCtrF2TexBox = "txtG1Sia_codeps_teps";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SSP_CODOCU_CIUO : Tabla Clasificación Internacional Uniforme de Ocupaciones (C
        private void txtG1Ssp_codocu_ciuo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Ssp_codocu_ciuo_Browser();
            }
        }
        private void cmdG1Ssp_codocu_ciuo_Click(object sender, RoutedEventArgs e)
        {
            txtG1Ssp_codocu_ciuo_Browser();
        }
        private void txtG1Ssp_codocu_ciuo_Browser()
        {
            Browser01 frbro = new Browser01("SSP", "SPOCUPACIONCIUO", "", "Tabla Clasificación Internacional Uniforme de Ocupaciones (C...");
            gcrCtrF2TexBox = "txtG1Ssp_codocu_ciuo";
            frbro.Owner = this;
            frbro.ShowDialog();
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
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        // Actualizar Objeto TextBox  y  CombBox
        //-------------------------------------------------
        #region Actualizar Objeto TextBox desde CombBox
        private void SeleccionComboBoxOpcion(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true)
                {
                    #region Actualizar Objeto 
                    CrtForms.ListaComboBox lobList = (CrtForms.ListaComboBox)e.AddedItems[0];
                    ComboBox lobCombo = (ComboBox)sender;
                    String lcrNombre  = lobCombo.Name;
                    String lcrValor   = string.Empty;

                    var lrNumVariable = fcrRefVar4505NumeroVariableSi(lobCombo.Name);

                    // se cambia el nombre por el numero variable
                    if (!String.IsNullOrWhiteSpace(lrNumVariable))
                    {
                        lcrNombre = lrNumVariable; 
                    }

                    switch (lcrNombre)
                    {
                        case "cboG1Ssp_forfec_sscf":
                            txtG1Ssp_forfec_sscf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_forfec_sscf.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_forfec_sscf.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG1Ssp_sepfec_sscf":
                            txtG1Ssp_sepfec_sscf.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_sepfec_sscf.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_sepfec_sscf.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG1Ssp_regims_sgss":
                            txtG1Ssp_regims_sgss.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_regims_sgss.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_regims_sgss.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "10":
                            txtG1Ssp_cam010_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam010_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam010_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "11":
                            txtG1Ssp_cam011_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam011_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam011_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "13":
                            txtG1Ssp_cam013_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam013_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam013_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "14": //cboG1Ssp_cam014_ms45 Gestacion 
                            txtG1Ssp_cam014_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam014_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam014_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "15":
                            txtG1Ssp_cam015_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam015_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam015_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "16":
                            txtG1Ssp_cam016_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam016_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam016_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "17":
                            txtG1Ssp_cam017_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam017_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam017_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "18":
                            txtG1Ssp_cam018_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam018_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam018_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "19":
                            txtG1Ssp_cam019_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam019_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam019_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "20":
                            txtG1Ssp_cam020_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam020_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam020_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "21":
                            txtG1Ssp_cam021_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam021_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam021_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "22":
                            txtG1Ssp_cam022_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam022_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam022_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "23":
                            txtG1Ssp_cam023_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam023_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam023_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "24":
                            txtG1Ssp_cam024_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam024_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam024_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "25":
                            txtG1Ssp_cam025_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam025_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam025_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "26":
                            txtG1Ssp_cam026_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam026_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam026_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "27":
                            txtG1Ssp_cam027_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam027_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam027_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "28":
                            txtG1Ssp_cam028_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam028_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam028_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "29":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam029_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam029_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam029_ms45.Text : lcrValor;
                            break;

                        case "30":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam030_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam030_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam030_ms45.Text : lcrValor;
                            break;

                        case "31":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam031_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam031_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam031_ms45.Text : lcrValor;
                            break;

                        case "32":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam032_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam032_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam032_ms45.Text : lcrValor;
                            break;

                        case "33":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam033_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam033_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam033_ms45.Text : lcrValor;
                            break;

                        case "34":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam034_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam034_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam034_ms45.Text : lcrValor;
                            break;

                        case "35":
                            txtG1Ssp_cam035_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam035_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam035_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "36":
                            txtG1Ssp_cam036_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam036_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam036_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "37":
                            txtG1Ssp_cam037_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam037_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam037_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "38":
                            txtG1Ssp_cam038_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam038_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam038_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "39":
                            txtG1Ssp_cam039_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam039_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam039_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "40":
                            txtG1Ssp_cam040_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam040_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam040_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "41":
                            txtG1Ssp_cam041_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam041_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam041_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "42":
                            txtG1Ssp_cam042_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam042_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam042_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "43":
                            txtG1Ssp_cam043_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam043_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam043_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "44":
                            txtG1Ssp_cam044_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam044_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam044_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "45":
                            txtG1Ssp_cam045_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam045_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam045_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "46":
                            txtG1Ssp_cam046_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam046_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam046_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "47":
                            txtG1Ssp_cam047_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam047_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam047_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "48":
                            txtG1Ssp_cam048_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam048_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam048_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "49":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam049_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam049_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam049_ms45.Text : lcrValor;
                            break;

                        case "50":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam050_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam050_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam050_ms45.Text : lcrValor;
                            break;

                        case "51":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam051_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam051_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam051_ms45.Text : lcrValor;
                            break;

                        case "52":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam052_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam052_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam052_ms45.Text : lcrValor;
                            break;

                        case "53":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam053_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam053_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam053_ms45.Text : lcrValor;
                            break;

                        case "54":
                            txtG1Ssp_cam054_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam054_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam054_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "55":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam055_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam055_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam055_ms45.Text : lcrValor;
                            break;

                        case "56":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam056_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam056_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam056_ms45.Text : lcrValor;
                            break;

                        case "57":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam057_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam057_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam057_ms45.Text : lcrValor;
                            break;

                        case "58":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam058_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam058_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam058_ms45.Text : lcrValor;
                            break;

                        case "59":
                            txtG1Ssp_cam059_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam059_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam059_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "60":
                            txtG1Ssp_cam060_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam060_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam060_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "61":
                            txtG1Ssp_cam061_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam061_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam061_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "62":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam062_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam062_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam062_ms45.Text : lcrValor;
                            break;

                        case "63":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam063_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam063_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam063_ms45.Text : lcrValor;
                            break;

                        case "64":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam064_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam064_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam064_ms45.Text : lcrValor;
                            break;

                        case "65":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam065_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam065_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam065_ms45.Text : lcrValor;
                            break;
                        case "66":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam066_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam066_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam066_ms45.Text : lcrValor;
                            break;

                        case "67":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam067_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam067_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam067_ms45.Text : lcrValor;
                            break;

                        case "68":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam068_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam068_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam068_ms45.Text : lcrValor;
                            break;

                        case "69":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam069_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam069_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam069_ms45.Text : lcrValor;
                            break;

                        case "70":
                            txtG1Ssp_cam070_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam070_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam070_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "71":
                            txtG1Ssp_cam071_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam071_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam071_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "72":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam072_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam072_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam072_ms45.Text : lcrValor;
                            break;

                        case "73":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam073_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam073_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam073_ms45.Text : lcrValor;
                            break;

                        case "74":
                            txtG1Ssp_cam074_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam074_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam074_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "75":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam075_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam075_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam075_ms45.Text : lcrValor;
                            break;

                        case "76":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam076_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam076_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam076_ms45.Text : lcrValor;
                            break;

                        case "77":
                            txtG1Ssp_cam077_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam077_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam077_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "78":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam078_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam078_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam078_ms45.Text : lcrValor;
                            break;

                        case "79":
                            txtG1Ssp_cam079_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam079_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam079_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "80":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam080_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam080_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam080_ms45.Text : lcrValor;
                            break;

                        case "81":
                            txtG1Ssp_cam081_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam081_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam081_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "82":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam082_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam082_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam082_ms45.Text : lcrValor;
                            break;

                        case "83":
                            txtG1Ssp_cam083_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam083_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam083_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "84":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam084_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam084_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam084_ms45.Text : lcrValor;
                            break;

                        case "85":
                            txtG1Ssp_cam085_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam085_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam085_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "86":
                            txtG1Ssp_cam086_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam086_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam086_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "87":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam087_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam087_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam087_ms45.Text : lcrValor;
                            break;

                        case "88":
                            txtG1Ssp_cam088_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam088_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam088_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "89":
                            txtG1Ssp_cam089_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam089_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam089_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "90":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam090_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam090_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam090_ms45.Text : lcrValor;
                            break;

                        case "91":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam091_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam091_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam091_ms45.Text : lcrValor;
                            break;

                        case "92":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam092_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam092_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam092_ms45.Text : lcrValor;
                            break;

                        case "93":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam093_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam093_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam093_ms45.Text : lcrValor;
                            break;

                        case "94":
                            txtG1Ssp_cam094_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam094_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam094_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "95":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam095_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam095_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam095_ms45.Text : lcrValor;
                            break;

                        case "96":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam096_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam096_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam096_ms45.Text : lcrValor;
                            break;

                        case "97":
                            txtG1Ssp_cam097_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam097_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam097_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "98":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam098_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam098_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam098_ms45.Text : lcrValor;
                            break;

                        case "99":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam099_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam099_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam099_ms45.Text : lcrValor;
                            break;

                        case "100":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam100_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);
                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam100_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam100_ms45.Text : lcrValor;
                            break;

                        case "101":
                            txtG1Ssp_cam101_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam101_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam101_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "102":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam102_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam102_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam102_ms45.Text : lcrValor;
                            break;

                        case "103":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam103_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam103_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam103_ms45.Text : lcrValor;
                            break;

                        case "104":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam104_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam104_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam104_ms45.Text : lcrValor;
                            break;

                        case "105":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam105_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam105_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam105_ms45.Text : lcrValor;
                            break;

                        case "106":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam106_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam106_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam106_ms45.Text : lcrValor;
                            break;

                        case "107":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam107_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam107_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam107_ms45.Text : lcrValor;
                            break;

                        case "108":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam108_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam108_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam108_ms45.Text : lcrValor;
                            break;

                        case "109":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam109_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam109_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam109_ms45.Text : lcrValor;
                            break;

                        case "110":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam110_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam110_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam110_ms45.Text : lcrValor;
                            break;

                        case "111":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam111_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam111_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam111_ms45.Text : lcrValor;
                            break;

                        case "112":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam112_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam112_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam112_ms45.Text : lcrValor;
                            break;

                        case "113":
                            txtG1Ssp_cam113_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam113_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam113_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "114":
                            txtG1Ssp_cam114_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam114_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam114_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "115":
                            txtG1Ssp_cam115_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam115_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam115_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "116":
                            txtG1Ssp_cam116_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam116_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam116_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "117":
                            txtG1Ssp_cam117_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam117_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, this.txtG1Ssp_cam117_ms45.Text, lobList.ListaValoresSel);
                            break;

                        case "118":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                  txtG1Ssp_cam118_ms45.Text, ",",
                                                                  lobList.ListaValoresSel);

                            fcvRefVar4505ActaulizarVistaComboBox(lcrNombre, lcrValor, lobList.ListaValoresSel);
                            txtG1Ssp_cam118_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam118_ms45.Text : lcrValor;
                            break;
                    }
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: SeleccionOpcion");
            }
        }
        #endregion
        #region Actualizar ComboBox desde Campo Texto
        private void ActualizarComboBoxOpcion(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true)
                {
                    #region Actualizar Objeto
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    Decimal ldeInicial;         // valor inicial entre rangos decimales
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
                        case "txtG1Ssp_forfec_sscf":
                            CrtForms.ListaComboBox lobG1ComboBox1XX = (CrtForms.ListaComboBox)cboG1Ssp_forfec_sscf.SelectedItem;
                            cboG1Ssp_forfec_sscf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1XX.ListaValoresSel);
                            break;
                        case "txtG1Ssp_sepfec_sscf":
                            CrtForms.ListaComboBox lobG1ComboBox2XX = (CrtForms.ListaComboBox)cboG1Ssp_sepfec_sscf.SelectedItem;
                            cboG1Ssp_sepfec_sscf.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2XX.ListaValoresSel);
                            break;
                        case "txtG1Ssp_regims_sgss":
                            CrtForms.ListaComboBox lobG1ComboBox3XX = (CrtForms.ListaComboBox)cboG1Ssp_regims_sgss.SelectedItem;
                            cboG1Ssp_regims_sgss.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3XX.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam010_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Ssp_cam010_ms45.SelectedItem;
                            cboG1Ssp_cam010_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam011_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboG1Ssp_cam011_ms45.SelectedItem;
                            cboG1Ssp_cam011_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam013_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboG1Ssp_cam013_ms45.SelectedItem;
                            cboG1Ssp_cam013_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam014_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)cboG1Ssp_cam014_ms45.SelectedItem;
                            cboG1Ssp_cam014_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam015_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)cboG1Ssp_cam015_ms45.SelectedItem;
                            cboG1Ssp_cam015_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam016_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox6 = (CrtForms.ListaComboBox)cboG1Ssp_cam016_ms45.SelectedItem;
                            cboG1Ssp_cam016_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox6.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam017_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox7 = (CrtForms.ListaComboBox)cboG1Ssp_cam017_ms45.SelectedItem;
                            cboG1Ssp_cam017_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox7.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam018_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox8 = (CrtForms.ListaComboBox)cboG1Ssp_cam018_ms45.SelectedItem;
                            cboG1Ssp_cam018_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox8.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam019_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox9 = (CrtForms.ListaComboBox)cboG1Ssp_cam019_ms45.SelectedItem;
                            cboG1Ssp_cam019_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox9.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam020_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox10 = (CrtForms.ListaComboBox)cboG1Ssp_cam020_ms45.SelectedItem;
                            cboG1Ssp_cam020_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox10.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam021_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox11 = (CrtForms.ListaComboBox)cboG1Ssp_cam021_ms45.SelectedItem;
                            cboG1Ssp_cam021_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox11.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam022_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox12 = (CrtForms.ListaComboBox)cboG1Ssp_cam022_ms45.SelectedItem;
                            cboG1Ssp_cam022_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox12.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam023_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox13 = (CrtForms.ListaComboBox)cboG1Ssp_cam023_ms45.SelectedItem;
                            cboG1Ssp_cam023_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox13.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam024_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox14 = (CrtForms.ListaComboBox)cboG1Ssp_cam024_ms45.SelectedItem;
                            cboG1Ssp_cam024_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox14.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam025_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox15 = (CrtForms.ListaComboBox)cboG1Ssp_cam025_ms45.SelectedItem;
                            cboG1Ssp_cam025_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox15.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam026_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox16 = (CrtForms.ListaComboBox)cboG1Ssp_cam026_ms45.SelectedItem;
                            cboG1Ssp_cam026_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox16.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam027_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox17 = (CrtForms.ListaComboBox)cboG1Ssp_cam027_ms45.SelectedItem;
                            cboG1Ssp_cam027_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox17.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam028_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox18 = (CrtForms.ListaComboBox)cboG1Ssp_cam028_ms45.SelectedItem;
                            cboG1Ssp_cam028_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox18.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam029_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox19 = (CrtForms.ListaComboBox)cboG1Ssp_cam029_ms45.SelectedItem;
                            cboG1Ssp_cam029_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox19.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam030_ms45":
                            if (!String.IsNullOrEmpty(txtG1Ssp_cam030_ms45.Text))
                            {
                                if (Funciones.flgSoloNumerosEx(txtG1Ssp_cam030_ms45.Text))
                                {
                                    if (Convert.ToDecimal(txtG1Ssp_cam030_ms45.Text) > 0 && Convert.ToDecimal(txtG1Ssp_cam030_ms45.Text) < 250)
                                    {
                                        lcrValor = "VP";
                                    }
                                }
                            }
                            CrtForms.ListaComboBox lobG1ComboBox20 = (CrtForms.ListaComboBox)cboG1Ssp_cam030_ms45.SelectedItem;
                            cboG1Ssp_cam030_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox20.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam031_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox21 = (CrtForms.ListaComboBox)cboG1Ssp_cam031_ms45.SelectedItem;
                            cboG1Ssp_cam031_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox21.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam032_ms45":
                            if (String.IsNullOrWhiteSpace(txtG1Ssp_cam032_ms45.Text) || !Funciones.flgSoloNumeros(txtG1Ssp_cam032_ms45.Text))
                            {
                                txtG1Ssp_cam032_ms45.Text = "999";
                            }
                            if (Convert.ToInt32(txtG1Ssp_cam032_ms45.Text) >= 20 && Convert.ToInt32(txtG1Ssp_cam032_ms45.Text) < 225)
                            {
                                lcrValor = "VP";
                            }
                            CrtForms.ListaComboBox lobG1ComboBox22 = (CrtForms.ListaComboBox)cboG1Ssp_cam032_ms45.SelectedItem;
                            cboG1Ssp_cam032_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox22.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam033_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox23 = (CrtForms.ListaComboBox)cboG1Ssp_cam033_ms45.SelectedItem;
                            cboG1Ssp_cam033_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox23.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam034_ms45":
                            if (!String.IsNullOrEmpty(txtG1Ssp_cam034_ms45.Text))
                            {
                                if (!Funciones.flgSoloNumeros(txtG1Ssp_cam034_ms45.Text))
                                {
                                    txtG1Ssp_cam034_ms45.Text = "0";
                                }
                                if (Convert.ToInt32(txtG1Ssp_cam034_ms45.Text) >= 20 && Convert.ToInt32(txtG1Ssp_cam034_ms45.Text) <= 48)
                                {
                                    lcrValor = "VP";
                                }
                            }
                            CrtForms.ListaComboBox lobG1ComboBox24 = (CrtForms.ListaComboBox)cboG1Ssp_cam034_ms45.SelectedItem;
                            cboG1Ssp_cam034_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox24.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam035_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox25 = (CrtForms.ListaComboBox)cboG1Ssp_cam035_ms45.SelectedItem;
                            cboG1Ssp_cam035_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox25.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam036_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox26 = (CrtForms.ListaComboBox)cboG1Ssp_cam036_ms45.SelectedItem;
                            cboG1Ssp_cam036_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox26.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam037_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox27 = (CrtForms.ListaComboBox)cboG1Ssp_cam037_ms45.SelectedItem;
                            cboG1Ssp_cam037_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox27.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam038_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox28 = (CrtForms.ListaComboBox)cboG1Ssp_cam038_ms45.SelectedItem;
                            cboG1Ssp_cam038_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox28.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam039_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox29 = (CrtForms.ListaComboBox)cboG1Ssp_cam039_ms45.SelectedItem;
                            cboG1Ssp_cam039_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox29.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam040_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox30 = (CrtForms.ListaComboBox)cboG1Ssp_cam040_ms45.SelectedItem;
                            cboG1Ssp_cam040_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox30.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam041_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox31 = (CrtForms.ListaComboBox)cboG1Ssp_cam041_ms45.SelectedItem;
                            cboG1Ssp_cam041_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox31.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam042_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox32 = (CrtForms.ListaComboBox)cboG1Ssp_cam042_ms45.SelectedItem;
                            cboG1Ssp_cam042_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox32.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam043_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox33 = (CrtForms.ListaComboBox)cboG1Ssp_cam043_ms45.SelectedItem;
                            cboG1Ssp_cam043_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox33.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam044_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox34 = (CrtForms.ListaComboBox)cboG1Ssp_cam044_ms45.SelectedItem;
                            cboG1Ssp_cam044_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox34.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam045_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox35 = (CrtForms.ListaComboBox)cboG1Ssp_cam045_ms45.SelectedItem;
                            cboG1Ssp_cam045_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox35.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam046_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox36 = (CrtForms.ListaComboBox)cboG1Ssp_cam046_ms45.SelectedItem;
                            cboG1Ssp_cam046_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox36.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam047_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox37 = (CrtForms.ListaComboBox)cboG1Ssp_cam047_ms45.SelectedItem;
                            cboG1Ssp_cam047_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox37.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam048_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox38 = (CrtForms.ListaComboBox)cboG1Ssp_cam048_ms45.SelectedItem;
                            cboG1Ssp_cam048_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox38.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam049_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox39 = (CrtForms.ListaComboBox)cboG1Ssp_cam049_ms45.SelectedItem;
                            cboG1Ssp_cam049_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox39.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam050_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox40 = (CrtForms.ListaComboBox)cboG1Ssp_cam050_ms45.SelectedItem;
                            cboG1Ssp_cam050_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox40.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam051_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox41 = (CrtForms.ListaComboBox)cboG1Ssp_cam051_ms45.SelectedItem;
                            cboG1Ssp_cam051_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox41.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam052_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox42 = (CrtForms.ListaComboBox)cboG1Ssp_cam052_ms45.SelectedItem;
                            cboG1Ssp_cam052_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox42.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam053_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox43 = (CrtForms.ListaComboBox)cboG1Ssp_cam053_ms45.SelectedItem;
                            cboG1Ssp_cam053_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox43.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam054_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox44 = (CrtForms.ListaComboBox)cboG1Ssp_cam054_ms45.SelectedItem;
                            cboG1Ssp_cam054_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox44.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam055_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox45 = (CrtForms.ListaComboBox)cboG1Ssp_cam055_ms45.SelectedItem;
                            cboG1Ssp_cam055_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox45.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam056_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox46 = (CrtForms.ListaComboBox)cboG1Ssp_cam056_ms45.SelectedItem;
                            cboG1Ssp_cam056_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox46.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam057_ms45":
                            if (String.IsNullOrWhiteSpace(txtG1Ssp_cam057_ms45.Text) || !Funciones.flgSoloNumeros(txtG1Ssp_cam057_ms45.Text))
                            {
                                txtG1Ssp_cam057_ms45.Text = "0";
                            }
                            if (Convert.ToInt32(txtG1Ssp_cam057_ms45.Text) > 0 && Convert.ToInt32(txtG1Ssp_cam057_ms45.Text) <= 10)
                            {
                                lcrValor = "VP";
                            }
                            CrtForms.ListaComboBox lobG1ComboBox47 = (CrtForms.ListaComboBox)cboG1Ssp_cam057_ms45.SelectedItem;
                            cboG1Ssp_cam057_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox47.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam058_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox48 = (CrtForms.ListaComboBox)cboG1Ssp_cam058_ms45.SelectedItem;
                            cboG1Ssp_cam058_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox48.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam059_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox49 = (CrtForms.ListaComboBox)cboG1Ssp_cam059_ms45.SelectedItem;
                            cboG1Ssp_cam059_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox49.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam060_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox50 = (CrtForms.ListaComboBox)cboG1Ssp_cam060_ms45.SelectedItem;
                            cboG1Ssp_cam060_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox50.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam061_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox51 = (CrtForms.ListaComboBox)cboG1Ssp_cam061_ms45.SelectedItem;
                            cboG1Ssp_cam061_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox51.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam062_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox52 = (CrtForms.ListaComboBox)cboG1Ssp_cam062_ms45.SelectedItem;
                            cboG1Ssp_cam062_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox52.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam063_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox53 = (CrtForms.ListaComboBox)cboG1Ssp_cam063_ms45.SelectedItem;
                            cboG1Ssp_cam063_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox53.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam064_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox54 = (CrtForms.ListaComboBox)cboG1Ssp_cam064_ms45.SelectedItem;
                            cboG1Ssp_cam064_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox54.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam065_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox55 = (CrtForms.ListaComboBox)cboG1Ssp_cam065_ms45.SelectedItem;
                            cboG1Ssp_cam065_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox55.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam066_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox56 = (CrtForms.ListaComboBox)cboG1Ssp_cam066_ms45.SelectedItem;
                            cboG1Ssp_cam066_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox56.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam067_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox57 = (CrtForms.ListaComboBox)cboG1Ssp_cam067_ms45.SelectedItem;
                            cboG1Ssp_cam067_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox57.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam068_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox58 = (CrtForms.ListaComboBox)cboG1Ssp_cam068_ms45.SelectedItem;
                            cboG1Ssp_cam068_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox58.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam069_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox59 = (CrtForms.ListaComboBox)cboG1Ssp_cam069_ms45.SelectedItem;
                            cboG1Ssp_cam069_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox59.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam070_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox60 = (CrtForms.ListaComboBox)cboG1Ssp_cam070_ms45.SelectedItem;
                            cboG1Ssp_cam070_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox60.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam071_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox61 = (CrtForms.ListaComboBox)cboG1Ssp_cam071_ms45.SelectedItem;
                            cboG1Ssp_cam071_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox61.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam072_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox62 = (CrtForms.ListaComboBox)cboG1Ssp_cam072_ms45.SelectedItem;
                            cboG1Ssp_cam072_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox62.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam073_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox63 = (CrtForms.ListaComboBox)cboG1Ssp_cam073_ms45.SelectedItem;
                            cboG1Ssp_cam073_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox63.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam074_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox64 = (CrtForms.ListaComboBox)cboG1Ssp_cam074_ms45.SelectedItem;
                            cboG1Ssp_cam074_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox64.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam075_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox65 = (CrtForms.ListaComboBox)cboG1Ssp_cam075_ms45.SelectedItem;
                            cboG1Ssp_cam075_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox65.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam076_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox66 = (CrtForms.ListaComboBox)cboG1Ssp_cam076_ms45.SelectedItem;
                            cboG1Ssp_cam076_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox66.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam077_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox67 = (CrtForms.ListaComboBox)cboG1Ssp_cam077_ms45.SelectedItem;
                            cboG1Ssp_cam077_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox67.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam078_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox68 = (CrtForms.ListaComboBox)cboG1Ssp_cam078_ms45.SelectedItem;
                            cboG1Ssp_cam078_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox68.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam079_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox69 = (CrtForms.ListaComboBox)cboG1Ssp_cam079_ms45.SelectedItem;
                            cboG1Ssp_cam079_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox69.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam080_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox70 = (CrtForms.ListaComboBox)cboG1Ssp_cam080_ms45.SelectedItem;
                            cboG1Ssp_cam080_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox70.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam081_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox71 = (CrtForms.ListaComboBox)cboG1Ssp_cam081_ms45.SelectedItem;
                            cboG1Ssp_cam081_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox71.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam082_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox72 = (CrtForms.ListaComboBox)cboG1Ssp_cam082_ms45.SelectedItem;
                            cboG1Ssp_cam082_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox72.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam083_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox73 = (CrtForms.ListaComboBox)cboG1Ssp_cam083_ms45.SelectedItem;
                            cboG1Ssp_cam083_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox73.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam084_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox74 = (CrtForms.ListaComboBox)cboG1Ssp_cam084_ms45.SelectedItem;
                            cboG1Ssp_cam084_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox74.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam085_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox75 = (CrtForms.ListaComboBox)cboG1Ssp_cam085_ms45.SelectedItem;
                            cboG1Ssp_cam085_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox75.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam086_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox76 = (CrtForms.ListaComboBox)cboG1Ssp_cam086_ms45.SelectedItem;
                            cboG1Ssp_cam086_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox76.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam087_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox77 = (CrtForms.ListaComboBox)cboG1Ssp_cam087_ms45.SelectedItem;
                            cboG1Ssp_cam087_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox77.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam088_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox78 = (CrtForms.ListaComboBox)cboG1Ssp_cam088_ms45.SelectedItem;
                            cboG1Ssp_cam088_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox78.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam089_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox79 = (CrtForms.ListaComboBox)cboG1Ssp_cam089_ms45.SelectedItem;
                            cboG1Ssp_cam089_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox79.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam090_ms45":
                            if (String.IsNullOrWhiteSpace(txtG1Ssp_cam090_ms45.Text) || !Funciones.flgSoloNumeros(txtG1Ssp_cam090_ms45.Text))
                            {
                                txtG1Ssp_cam090_ms45.Text = "0";
                            }
                            if (txtG1Ssp_cam090_ms45.Text.Length > 3 && txtG1Ssp_cam090_ms45.Text.Length <= 12)
                            {
                                lcrValor = "VP";
                            }
                            CrtForms.ListaComboBox lobG1ComboBox80 = (CrtForms.ListaComboBox)cboG1Ssp_cam090_ms45.SelectedItem;
                            cboG1Ssp_cam090_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox80.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam091_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox81 = (CrtForms.ListaComboBox)cboG1Ssp_cam091_ms45.SelectedItem;
                            cboG1Ssp_cam091_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox81.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam092_ms45":
                            if (String.IsNullOrWhiteSpace(txtG1Ssp_cam092_ms45.Text) || !Funciones.flgSoloNumeros(txtG1Ssp_cam092_ms45.Text))
                            {
                                txtG1Ssp_cam092_ms45.Text = "0";
                            }
                            if (txtG1Ssp_cam092_ms45.Text.Length > 3 && txtG1Ssp_cam092_ms45.Text.Length <= 12)
                            {
                                lcrValor = "VP";
                            }
                            CrtForms.ListaComboBox lobG1ComboBox82 = (CrtForms.ListaComboBox)cboG1Ssp_cam092_ms45.SelectedItem;
                            cboG1Ssp_cam092_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox82.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam093_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox83 = (CrtForms.ListaComboBox)cboG1Ssp_cam093_ms45.SelectedItem;
                            cboG1Ssp_cam093_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox83.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam094_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox84 = (CrtForms.ListaComboBox)cboG1Ssp_cam094_ms45.SelectedItem;
                            cboG1Ssp_cam094_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox84.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam095_ms45":
                            if (String.IsNullOrWhiteSpace(txtG1Ssp_cam095_ms45.Text) || !Funciones.flgSoloNumeros(txtG1Ssp_cam095_ms45.Text))
                            {
                                txtG1Ssp_cam095_ms45.Text = "0";
                            }
                            if (txtG1Ssp_cam095_ms45.Text.Length > 3 && txtG1Ssp_cam095_ms45.Text.Length <= 12)
                            {
                                lcrValor = "VP";
                            }
                            CrtForms.ListaComboBox lobG1ComboBox85 = (CrtForms.ListaComboBox)cboG1Ssp_cam095_ms45.SelectedItem;
                            cboG1Ssp_cam095_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox85.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam096_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox86 = (CrtForms.ListaComboBox)cboG1Ssp_cam096_ms45.SelectedItem;
                            cboG1Ssp_cam096_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox86.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam097_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox87 = (CrtForms.ListaComboBox)cboG1Ssp_cam097_ms45.SelectedItem;
                            cboG1Ssp_cam097_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox87.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam098_ms45":
                            if (String.IsNullOrWhiteSpace(txtG1Ssp_cam098_ms45.Text) || !Funciones.flgSoloNumeros(txtG1Ssp_cam098_ms45.Text))
                            {
                                txtG1Ssp_cam098_ms45.Text = "0";
                            }
                            if (txtG1Ssp_cam098_ms45.Text.Length > 3 && txtG1Ssp_cam098_ms45.Text.Length <= 12)
                            {
                                lcrValor = "VP";
                            }
                            CrtForms.ListaComboBox lobG1ComboBox88 = (CrtForms.ListaComboBox)cboG1Ssp_cam098_ms45.SelectedItem;
                            cboG1Ssp_cam098_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox88.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam099_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox89 = (CrtForms.ListaComboBox)cboG1Ssp_cam099_ms45.SelectedItem;
                            cboG1Ssp_cam099_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox89.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam100_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox90 = (CrtForms.ListaComboBox)cboG1Ssp_cam100_ms45.SelectedItem;
                            cboG1Ssp_cam100_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox90.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam101_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox91 = (CrtForms.ListaComboBox)cboG1Ssp_cam101_ms45.SelectedItem;
                            cboG1Ssp_cam101_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox91.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam102_ms45":
                            if (String.IsNullOrWhiteSpace(txtG1Ssp_cam102_ms45.Text) || !Funciones.flgSoloNumeros(txtG1Ssp_cam102_ms45.Text))
                            {
                                txtG1Ssp_cam102_ms45.Text = "0";
                            }
                            if (txtG1Ssp_cam102_ms45.Text.Length > 3 && txtG1Ssp_cam102_ms45.Text.Length <= 12)
                            {
                                lcrValor = "VP";
                            }
                            CrtForms.ListaComboBox lobG1ComboBox92 = (CrtForms.ListaComboBox)cboG1Ssp_cam102_ms45.SelectedItem;
                            cboG1Ssp_cam102_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox92.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam103_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox93 = (CrtForms.ListaComboBox)cboG1Ssp_cam103_ms45.SelectedItem;
                            cboG1Ssp_cam103_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox93.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam104_ms45":
                            ldeInicial = Convert.ToDecimal(1.5);
                            if (String.IsNullOrWhiteSpace(txtG1Ssp_cam104_ms45.Text))
                            {
                                txtG1Ssp_cam104_ms45.Text = "0";
                            }
                            if (Convert.ToDecimal(txtG1Ssp_cam104_ms45.Text) >= ldeInicial && Convert.ToDecimal(txtG1Ssp_cam104_ms45.Text) <= 20)
                            {
                                lcrValor = "VP";
                            }
                            CrtForms.ListaComboBox lobG1ComboBox94 = (CrtForms.ListaComboBox)cboG1Ssp_cam104_ms45.SelectedItem;
                            cboG1Ssp_cam104_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox94.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam105_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox95 = (CrtForms.ListaComboBox)cboG1Ssp_cam105_ms45.SelectedItem;
                            cboG1Ssp_cam105_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox95.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam106_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox96 = (CrtForms.ListaComboBox)cboG1Ssp_cam106_ms45.SelectedItem;
                            cboG1Ssp_cam106_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox96.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam107_ms45":
                            ldeInicial = Convert.ToDecimal(0.2);
                            if (String.IsNullOrWhiteSpace(txtG1Ssp_cam107_ms45.Text))
                            {
                                txtG1Ssp_cam107_ms45.Text = "999";
                            }
                            if (Convert.ToDecimal(txtG1Ssp_cam107_ms45.Text) >= ldeInicial && Convert.ToDecimal(txtG1Ssp_cam107_ms45.Text) <= 25)
                            {
                                lcrValor = "VP";
                            }
                            CrtForms.ListaComboBox lobG1ComboBox97 = (CrtForms.ListaComboBox)cboG1Ssp_cam107_ms45.SelectedItem;
                            cboG1Ssp_cam107_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox97.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam108_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox98 = (CrtForms.ListaComboBox)cboG1Ssp_cam108_ms45.SelectedItem;
                            cboG1Ssp_cam108_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox98.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam109_ms45":
                            ldeInicial = Convert.ToDecimal(5);
                            if (String.IsNullOrWhiteSpace(txtG1Ssp_cam109_ms45.Text))
                            {
                                txtG1Ssp_cam109_ms45.Text = "999";
                            }
                            if (Convert.ToDecimal(txtG1Ssp_cam109_ms45.Text) >= ldeInicial && Convert.ToDecimal(txtG1Ssp_cam109_ms45.Text) <= 20)
                            {
                                lcrValor = "VP";
                            }
                            CrtForms.ListaComboBox lobG1ComboBox99 = (CrtForms.ListaComboBox)cboG1Ssp_cam109_ms45.SelectedItem;
                            cboG1Ssp_cam109_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox99.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam110_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox100 = (CrtForms.ListaComboBox)cboG1Ssp_cam110_ms45.SelectedItem;
                            cboG1Ssp_cam110_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox100.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam111_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox101 = (CrtForms.ListaComboBox)cboG1Ssp_cam111_ms45.SelectedItem;
                            cboG1Ssp_cam111_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox101.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam112_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox102 = (CrtForms.ListaComboBox)cboG1Ssp_cam112_ms45.SelectedItem;
                            cboG1Ssp_cam112_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox102.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam113_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox103 = (CrtForms.ListaComboBox)cboG1Ssp_cam113_ms45.SelectedItem;
                            cboG1Ssp_cam113_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox103.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam114_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox104 = (CrtForms.ListaComboBox)cboG1Ssp_cam114_ms45.SelectedItem;
                            cboG1Ssp_cam114_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox104.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam115_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox105 = (CrtForms.ListaComboBox)cboG1Ssp_cam115_ms45.SelectedItem;
                            cboG1Ssp_cam115_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox105.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam116_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox106 = (CrtForms.ListaComboBox)cboG1Ssp_cam116_ms45.SelectedItem;
                            cboG1Ssp_cam116_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox106.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam117_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox107 = (CrtForms.ListaComboBox)cboG1Ssp_cam117_ms45.SelectedItem;
                            cboG1Ssp_cam117_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox107.ListaValoresSel);
                            break;
                        case "txtG1Ssp_cam118_ms45":
                            CrtForms.ListaComboBox lobG1ComboBox108 = (CrtForms.ListaComboBox)cboG1Ssp_cam118_ms45.SelectedItem;
                            cboG1Ssp_cam118_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox108.ListaValoresSel);
                            break;
                    }
                   #endregion
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
        //  Actualizar Campo TextBox desde DatePiker
        #region  Actualizar Campo TextBox desde DatePiker
        private void fcvDatePickerSelected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DatePicker lobDpk = (sender as DatePicker);
                switch (lobDpk.Name)
                {
                    case "dpkG1Ssp_cam009_ms45":
                        txtG1Ssp_cam009_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam009_ms45);
                        break;
                    case "dpkG1Ssp_cam029_ms45":
                        txtG1Ssp_cam029_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam029_ms45);
                        break;
                    case "dpkG1Ssp_cam031_ms45":
                        txtG1Ssp_cam031_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam031_ms45);
                        break;
                    case "dpkG1Ssp_cam033_ms45":
                        txtG1Ssp_cam033_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam033_ms45);
                        break;
                    case "dpkG1Ssp_cam049_ms45":
                        txtG1Ssp_cam049_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam049_ms45);
                        break;
                    case "dpkG1Ssp_cam050_ms45":
                        txtG1Ssp_cam050_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam050_ms45);
                        break;
                    case "dpkG1Ssp_cam051_ms45":
                        txtG1Ssp_cam051_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam051_ms45);
                        break;
                    case "dpkG1Ssp_cam052_ms45":
                        txtG1Ssp_cam052_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam052_ms45);
                        break;
                    case "dpkG1Ssp_cam053_ms45":
                        txtG1Ssp_cam053_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam053_ms45);
                        break;
                    case "dpkG1Ssp_cam055_ms45":
                        txtG1Ssp_cam055_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam055_ms45);
                        break;
                    case "dpkG1Ssp_cam056_ms45":
                        txtG1Ssp_cam056_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam056_ms45);
                        break;
                    case "dpkG1Ssp_cam058_ms45":
                        txtG1Ssp_cam058_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam058_ms45);
                        break;
                    case "dpkG1Ssp_cam062_ms45":
                        txtG1Ssp_cam062_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam062_ms45);
                        break;
                    case "dpkG1Ssp_cam063_ms45":
                        txtG1Ssp_cam063_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam063_ms45);
                        break;
                    case "dpkG1Ssp_cam064_ms45":
                        txtG1Ssp_cam064_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam064_ms45);
                        break;
                    case "dpkG1Ssp_cam065_ms45":
                        txtG1Ssp_cam065_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam065_ms45);
                        break;
                    case "dpkG1Ssp_cam066_ms45":
                        txtG1Ssp_cam066_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam066_ms45);
                        break;
                    case "dpkG1Ssp_cam067_ms45":
                        txtG1Ssp_cam067_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam067_ms45);
                        break;
                    case "dpkG1Ssp_cam068_ms45":
                        txtG1Ssp_cam068_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam068_ms45);
                        break;
                    case "dpkG1Ssp_cam069_ms45":
                        txtG1Ssp_cam069_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam069_ms45);
                        break;
                    case "dpkG1Ssp_cam072_ms45":
                        txtG1Ssp_cam072_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam072_ms45);
                        break;
                    case "dpkG1Ssp_cam073_ms45":
                        txtG1Ssp_cam073_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam073_ms45);
                        break;
                    case "dpkG1Ssp_cam075_ms45":
                        txtG1Ssp_cam075_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam075_ms45);
                        break;
                    case "dpkG1Ssp_cam076_ms45":
                        txtG1Ssp_cam076_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam076_ms45);
                        break;
                    case "dpkG1Ssp_cam078_ms45":
                        txtG1Ssp_cam078_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam078_ms45);
                        break;
                    case "dpkG1Ssp_cam080_ms45":
                        txtG1Ssp_cam080_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam080_ms45);
                        break;
                    case "dpkG1Ssp_cam082_ms45":
                        txtG1Ssp_cam082_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam082_ms45);
                        break;
                    case "dpkG1Ssp_cam084_ms45":
                        txtG1Ssp_cam084_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam084_ms45);
                        break;
                    case "dpkG1Ssp_cam087_ms45":
                        txtG1Ssp_cam087_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam087_ms45);
                        break;
                    case "dpkG1Ssp_cam091_ms45":
                        txtG1Ssp_cam091_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam091_ms45);
                        break;
                    case "dpkG1Ssp_cam093_ms45":
                        txtG1Ssp_cam093_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam093_ms45);
                        break;
                    case "dpkG1Ssp_cam096_ms45":
                        txtG1Ssp_cam096_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam096_ms45);
                        break;
                    case "dpkG1Ssp_cam099_ms45":
                        txtG1Ssp_cam099_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam099_ms45);
                        break;
                    case "dpkG1Ssp_cam100_ms45":
                        txtG1Ssp_cam100_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam100_ms45);
                        break;
                    case "dpkG1Ssp_cam103_ms45":
                        txtG1Ssp_cam103_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam103_ms45);
                        break;
                    case "dpkG1Ssp_cam105_ms45":
                        txtG1Ssp_cam105_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam105_ms45);
                        break;
                    case "dpkG1Ssp_cam106_ms45":
                        txtG1Ssp_cam106_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam106_ms45);
                        break;
                    case "dpkG1Ssp_cam108_ms45":
                        txtG1Ssp_cam108_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam108_ms45);
                        break;
                    case "dpkG1Ssp_cam110_ms45":
                        txtG1Ssp_cam110_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam110_ms45);
                        break;
                    case "dpkG1Ssp_cam111_ms45":
                        txtG1Ssp_cam111_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam111_ms45);
                        break;
                    case "dpkG1Ssp_cam112_ms45":
                        txtG1Ssp_cam112_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam112_ms45);
                        break;
                    case "dpkG1Ssp_cam118_ms45":
                        txtG1Ssp_cam118_ms45.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Ssp_cam118_ms45);
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvDatePickerSelected");
            }
        }
        #endregion
        // Actualizar DatePiker desde Campo Texto
        #region Actualizar DatePiker desde Campo Texto
        private void fcvActualizarDatePicker(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true)
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
                            case "txtG1Ssp_cam009_ms45":
                                dpkG1Ssp_cam009_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1Ssp_cam029_ms45":
                                dpkG1Ssp_cam029_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox19 = (CrtForms.ListaComboBox)cboG1Ssp_cam029_ms45.SelectedItem;
                                cboG1Ssp_cam029_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox19.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam031_ms45":
                                dpkG1Ssp_cam031_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox21 = (CrtForms.ListaComboBox)cboG1Ssp_cam031_ms45.SelectedItem;
                                cboG1Ssp_cam031_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox21.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam033_ms45":
                                dpkG1Ssp_cam033_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox23 = (CrtForms.ListaComboBox)cboG1Ssp_cam033_ms45.SelectedItem;
                                cboG1Ssp_cam033_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox23.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam049_ms45":
                                dpkG1Ssp_cam049_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox39 = (CrtForms.ListaComboBox)cboG1Ssp_cam049_ms45.SelectedItem;
                                cboG1Ssp_cam049_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox39.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam050_ms45":
                                dpkG1Ssp_cam050_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox40 = (CrtForms.ListaComboBox)cboG1Ssp_cam050_ms45.SelectedItem;
                                cboG1Ssp_cam050_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox40.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam051_ms45":
                                dpkG1Ssp_cam051_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox41 = (CrtForms.ListaComboBox)cboG1Ssp_cam051_ms45.SelectedItem;
                                cboG1Ssp_cam051_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox41.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam052_ms45":
                                dpkG1Ssp_cam052_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox42 = (CrtForms.ListaComboBox)cboG1Ssp_cam052_ms45.SelectedItem;
                                cboG1Ssp_cam052_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox42.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam053_ms45":
                                dpkG1Ssp_cam053_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox43 = (CrtForms.ListaComboBox)cboG1Ssp_cam053_ms45.SelectedItem;
                                cboG1Ssp_cam053_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox43.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam055_ms45":
                                dpkG1Ssp_cam055_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox45 = (CrtForms.ListaComboBox)cboG1Ssp_cam055_ms45.SelectedItem;
                                cboG1Ssp_cam055_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox45.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam056_ms45":
                                dpkG1Ssp_cam056_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox46 = (CrtForms.ListaComboBox)cboG1Ssp_cam056_ms45.SelectedItem;
                                cboG1Ssp_cam056_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox46.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam058_ms45":
                                dpkG1Ssp_cam058_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox48 = (CrtForms.ListaComboBox)cboG1Ssp_cam058_ms45.SelectedItem;
                                cboG1Ssp_cam058_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox48.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam062_ms45":
                                dpkG1Ssp_cam062_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox52 = (CrtForms.ListaComboBox)cboG1Ssp_cam062_ms45.SelectedItem;
                                cboG1Ssp_cam062_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox52.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam063_ms45":
                                dpkG1Ssp_cam063_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox53 = (CrtForms.ListaComboBox)cboG1Ssp_cam063_ms45.SelectedItem;
                                cboG1Ssp_cam063_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox53.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam064_ms45":
                                dpkG1Ssp_cam064_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox54 = (CrtForms.ListaComboBox)cboG1Ssp_cam064_ms45.SelectedItem;
                                cboG1Ssp_cam064_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox54.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam065_ms45":
                                dpkG1Ssp_cam065_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox55 = (CrtForms.ListaComboBox)cboG1Ssp_cam065_ms45.SelectedItem;
                                cboG1Ssp_cam065_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox55.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam066_ms45":
                                dpkG1Ssp_cam066_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox56 = (CrtForms.ListaComboBox)cboG1Ssp_cam066_ms45.SelectedItem;
                                cboG1Ssp_cam066_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox56.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam067_ms45":
                                dpkG1Ssp_cam067_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox57 = (CrtForms.ListaComboBox)cboG1Ssp_cam067_ms45.SelectedItem;
                                cboG1Ssp_cam067_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox57.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam068_ms45":
                                dpkG1Ssp_cam068_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox58 = (CrtForms.ListaComboBox)cboG1Ssp_cam068_ms45.SelectedItem;
                                cboG1Ssp_cam068_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox58.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam069_ms45":
                                dpkG1Ssp_cam069_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox59 = (CrtForms.ListaComboBox)cboG1Ssp_cam069_ms45.SelectedItem;
                                cboG1Ssp_cam069_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox59.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam072_ms45":
                                dpkG1Ssp_cam072_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox62 = (CrtForms.ListaComboBox)cboG1Ssp_cam072_ms45.SelectedItem;
                                cboG1Ssp_cam072_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox62.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam073_ms45":
                                dpkG1Ssp_cam073_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox63 = (CrtForms.ListaComboBox)cboG1Ssp_cam073_ms45.SelectedItem;
                                cboG1Ssp_cam073_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox63.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam075_ms45":
                                dpkG1Ssp_cam075_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox65 = (CrtForms.ListaComboBox)cboG1Ssp_cam075_ms45.SelectedItem;
                                cboG1Ssp_cam075_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox65.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam076_ms45":
                                dpkG1Ssp_cam076_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox66 = (CrtForms.ListaComboBox)cboG1Ssp_cam076_ms45.SelectedItem;
                                cboG1Ssp_cam076_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox66.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam078_ms45":
                                dpkG1Ssp_cam078_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox68 = (CrtForms.ListaComboBox)cboG1Ssp_cam078_ms45.SelectedItem;
                                cboG1Ssp_cam078_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox68.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam080_ms45":
                                dpkG1Ssp_cam080_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox70 = (CrtForms.ListaComboBox)cboG1Ssp_cam080_ms45.SelectedItem;
                                cboG1Ssp_cam080_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox70.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam082_ms45":
                                dpkG1Ssp_cam082_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox72 = (CrtForms.ListaComboBox)cboG1Ssp_cam082_ms45.SelectedItem;
                                cboG1Ssp_cam082_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox72.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam084_ms45":
                                dpkG1Ssp_cam084_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox74 = (CrtForms.ListaComboBox)cboG1Ssp_cam084_ms45.SelectedItem;
                                cboG1Ssp_cam084_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox74.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam087_ms45":
                                dpkG1Ssp_cam087_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox77 = (CrtForms.ListaComboBox)cboG1Ssp_cam087_ms45.SelectedItem;
                                cboG1Ssp_cam087_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox77.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam091_ms45":
                                dpkG1Ssp_cam091_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox81 = (CrtForms.ListaComboBox)cboG1Ssp_cam091_ms45.SelectedItem;
                                cboG1Ssp_cam091_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox81.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam093_ms45":
                                dpkG1Ssp_cam093_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox83 = (CrtForms.ListaComboBox)cboG1Ssp_cam093_ms45.SelectedItem;
                                cboG1Ssp_cam093_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox83.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam096_ms45":
                                dpkG1Ssp_cam096_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox86 = (CrtForms.ListaComboBox)cboG1Ssp_cam096_ms45.SelectedItem;
                                cboG1Ssp_cam096_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox86.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam099_ms45":
                                dpkG1Ssp_cam099_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox89 = (CrtForms.ListaComboBox)cboG1Ssp_cam099_ms45.SelectedItem;
                                cboG1Ssp_cam099_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox89.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam100_ms45":
                                dpkG1Ssp_cam100_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox90 = (CrtForms.ListaComboBox)cboG1Ssp_cam100_ms45.SelectedItem;
                                cboG1Ssp_cam100_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox90.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam103_ms45":
                                dpkG1Ssp_cam103_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox93 = (CrtForms.ListaComboBox)cboG1Ssp_cam103_ms45.SelectedItem;
                                cboG1Ssp_cam103_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox93.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam105_ms45":
                                dpkG1Ssp_cam105_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox95 = (CrtForms.ListaComboBox)cboG1Ssp_cam105_ms45.SelectedItem;
                                cboG1Ssp_cam105_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox95.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam106_ms45":
                                dpkG1Ssp_cam106_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox96 = (CrtForms.ListaComboBox)cboG1Ssp_cam106_ms45.SelectedItem;
                                cboG1Ssp_cam106_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox96.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam108_ms45":
                                dpkG1Ssp_cam108_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox98 = (CrtForms.ListaComboBox)cboG1Ssp_cam108_ms45.SelectedItem;
                                cboG1Ssp_cam108_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox98.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam110_ms45":
                                dpkG1Ssp_cam110_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox100 = (CrtForms.ListaComboBox)cboG1Ssp_cam110_ms45.SelectedItem;
                                cboG1Ssp_cam110_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox100.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam111_ms45":
                                dpkG1Ssp_cam111_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox101 = (CrtForms.ListaComboBox)cboG1Ssp_cam111_ms45.SelectedItem;
                                cboG1Ssp_cam111_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox101.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam112_ms45":
                                dpkG1Ssp_cam112_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox102 = (CrtForms.ListaComboBox)cboG1Ssp_cam112_ms45.SelectedItem;
                                cboG1Ssp_cam112_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox102.ListaValoresSel);
                                break;
                            case "txtG1Ssp_cam118_ms45":
                                dpkG1Ssp_cam118_ms45.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                CrtForms.ListaComboBox lobG1ComboBox108 = (CrtForms.ListaComboBox)cboG1Ssp_cam118_ms45.SelectedItem;
                                cboG1Ssp_cam118_ms45.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox108.ListaValoresSel);
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
        //---------------------------------------------------------------
        // CLASES UTILITARIAS DE PROCESOS
        //---------------------------------------------------------------
        #region Clase Tabla para gestion de proceso Generar datos
        /// <summary>
        /// Clase Tabla para gestion de proceso Generar datos
        /// </summary>
        public class TablasProceso
        {
            public TablasProceso() { }
            public String Tabla { get; set; }
            public String Titulo { get; set; }
        }
        #endregion
        //-----------------------------------
        // CargHcl - Importar desde Historias clinicas
        #region fcvAccImportarDesdeHClinica: Importar desde Historias clinicas
        private void fcvAccImportarDesdeHClinica(object sender, RoutedEventArgs e)
        {
            fcvBrowserSeleccionPeriodo();
            if (gcrCtrF2TexBox == "OK")
            {
                gcrTipoCargueDatos = "GENERAR";

                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cargando datos desde historias clinicas...", "CENTRO");
                lobDlgAdd.Show();

                glgObjetosCargados = false;
                this.objDataGrid.ItemsSource = null;
                vm.glgSIS_DatosVerificados = false;
                fcvFiltroDataGridQuitarValores();
                gcrOrigenDatosCargados = "HIST";

                vm.TmpG2ListaBrow = new System.Collections.ObjectModel.ObservableCollection<ModeloSspNsRes4505Ex>();

                flgCargHclCargarDesdeHistorisClinicas();
                // Filtro 
                flgFiltroDataGridDatos();

                glgObjetosCargados = true;
                lobDlgAdd.Close();
            }
        }
        #endregion
        #region flgCargHclCargarDesdeHistorisClinicas: Cargar desde historias clinicas
        /// <summary>
        /// <para>Cargar vista de datos desde archivos historicos formatos de historias clinicas</para>
        /// </summary>
        public bool flgCargHclCargarDesdeHistorisClinicas()
        {
            var llgReturn       = false;
            var lcrArchivo      = String.Empty;
            var lcrFechaIni     = this.txtG1Ssp_fecini_peri.Text; //vm.G1Ssp_fecini_peri 
            var lcrFechaFin     = this.txtG1Ssp_fecfin_peri.Text; //vm.G1Ssp_fecfin_peri
            var lcroAppArch     = oApp.gcrAppBdatosArchvioGuardarDatos;
            var lcrIdArchivo    = oApp.gcrAppBdatosArchvioGuardarDatos;
            vm.TmpG2ListaBrow   = new ObservableCollection<ModeloSspNsRes4505Ex>();
            tmpCamposHC4505     = ModeloSptabcamposplan.flsListaSptabcamposplan4505();
            var lcrCodigoEps    = this.txtG1Sia_codeps_teps.Text;
            tmpRegActMS4505     = new ModeloSspNsRes4505Ex();

            // Generar temporales 
            tmpListGrupoActividad  = ModeloGrupoActividadesMA.flsListaSpprogramgrupma(""); // Lista de todas las actividades
            tmpListGrupoDetalles   = ModeloSpactivservfactMD.flsListaSpactivservfactTodos();
            tmpListServFacturacion = flsCargHclSQLConsultDatosFacturados(lcrCodigoEps, lcrFechaIni, lcrFechaFin);
            tmpListActivMedicVar   = ModeloSpactivMedicVarMD.flsListaSpactivmedicvarTodos();
            tmpListPlantVarPubGru  = ModeloSpactivMedicVarMD.flsListGrupoVarPubicasPlantillas();

            // Recorrer el temporal de facturacion y clasificar registros segun Grupos Actividades
            fcvCargHclGenerarDatosDesdeServFacturados();
            tmpListServFacturacion = null; // Liberar despues de usar para no recargar la memoria

            // organizar los registros generados 
            vm.TmpG2ListaBrow = new ObservableCollection<ModeloSspNsRes4505Ex>((from tmp in vm.TmpG2ListaBrow orderby tmp.Ssp_abrevi_ms45 select tmp).ToList());

            // Generar datos desde historicos de archivos del periodo - > todas las plantillas relacionadas con 4505
            #region Historicos de formatos HC
            lcrArchivo = "hclregisextxa";
            tmpListFormatosHistori = ModeloHclAcciones.flsSQLDataTableHistoricos4505(vm.G1Sia_codeps_teps, lcrFechaIni, lcrFechaFin, lcrArchivo + lcrIdArchivo);
            fcvCargHclRegistroCompletarDatosDeGrupos(lcrArchivo, lcrFechaIni, lcrFechaFin);
            lcrArchivo = "hclregisexcbo";
            tmpListFormatosHistori = ModeloHclAcciones.flsSQLDataTableHistoricos4505(vm.G1Sia_codeps_teps, lcrFechaIni, lcrFechaFin, lcrArchivo + lcrIdArchivo);
            fcvCargHclRegistroCompletarDatosDeGrupos(lcrArchivo, lcrFechaIni, lcrFechaFin);
            lcrArchivo = "hclregisexchk";
            tmpListFormatosHistori = ModeloHclAcciones.flsSQLDataTableHistoricos4505(vm.G1Sia_codeps_teps, lcrFechaIni, lcrFechaFin, lcrArchivo + lcrIdArchivo);
            fcvCargHclRegistroCompletarDatosDeGrupos(lcrArchivo, lcrFechaIni, lcrFechaFin);
            lcrArchivo = "hclregisexfec";
            tmpListFormatosHistori = ModeloHclAcciones.flsSQLDataTableHistoricos4505(vm.G1Sia_codeps_teps, lcrFechaIni, lcrFechaFin, lcrArchivo + lcrIdArchivo);
            fcvCargHclRegistroCompletarDatosDeGrupos(lcrArchivo, lcrFechaIni, lcrFechaFin);
            lcrArchivo = "hclregisexrel";
            tmpListFormatosHistori = ModeloHclAcciones.flsSQLDataTableHistoricos4505(vm.G1Sia_codeps_teps, lcrFechaIni, lcrFechaFin, lcrArchivo + lcrIdArchivo);
            fcvCargHclRegistroCompletarDatosDeGrupos(lcrArchivo, lcrFechaIni, lcrFechaFin);

            // Complementar datos del proceso
            fcvParcheAjusteProceso();

            tmpListFormatosHistori = null;
            #endregion
            // Datos finales
            this.txtG1Ssp_totreg_carg.Text = vm.TmpG2ListaBrow.Count().ToString();
            this.txtG1Ssp_forfec_sscf.Text = "DMY";

            return llgReturn;
        }
        #endregion
        #region fcvCargHclGenerarDatosDesdeServFacturados: Generar datos desde servicios facturados
        /// <summary>
        /// <para>Generar datos desde servicios facturados</para>
        /// </summary>
        public void fcvCargHclGenerarDatosDesdeServFacturados()
        {
            var lcrIdUnicoUsuario   = String.Empty;
            var lcrNumeroIdentifi   = String.Empty;
            var lcrIdUnicoAux       = "XXX";
            var lcrContador         = 0;

            tmpDetallesFact  = new List<FcmModeloServDetallFacturas>(); // Por cada Paciente genera lista de servicios que se facturaron 
            tmpDetallFactAdd = new List<FcmModeloServDetallFacturas>(); // Para agregar servicios que estan fuera del periodo y se requieren para completar algo
            tmpDetallAdmEven = new List<ModeloSpaActivRegApEventos>(); 

            #region Generar lista de todos los posibles registrios de 4505
            // Cargar los datos
            foreach (DataRow lobReg in tmpListServFacturacion.Rows)
            {
                lcrIdUnicoUsuario   = lobReg["Sia_idesec_usua"].ToString().ToUpper().Trim();
                lcrNumeroIdentifi   = lobReg["Sia_nroide_usua"].ToString().ToUpper().Trim();
                lcrIdUnicoAux       = lcrIdUnicoAux == "XXX" ? lcrIdUnicoUsuario : lcrIdUnicoAux;

                var lobReServ = fobCargHclRegDefaultDesdeServFacturados(lobReg);

                // Verificar datos
                if (lcrIdUnicoUsuario != lcrIdUnicoAux)
                {
                    lcrContador = flgCargHclGenerarDatosClasificarPaciente(lcrContador);
                    tmpDetallesFact     = new List<FcmModeloServDetallFacturas>();
                    tmpDetallFactAdd    = new List<FcmModeloServDetallFacturas>();
                    tmpDetallAdmEvenAux = new List<ModeloSpaActivRegApEventos>();
                }

                // Agregar el nuevo registro
                tmpDetallesFact.Add(lobReServ);
                lcrIdUnicoAux     = lcrIdUnicoUsuario;
                lcrNumeroIdentifi = lobReg["sia_nroide_usua"].ToString().ToUpper().Trim();

            }
            #endregion
        }
        #endregion
        #region fcvCargHclRegistroCompletarDatosDeGrupos: Completar Registro con Grupos actividades
        /// <summary>
        /// <para>Completar Registro con datos de cada grupo actividad segun historicos de informacion en historia clinica</para>
        /// <para>PARAMETROS: </para>
        /// <para>tcrArchivo: Nombre archivos historicos donde se guardan datos desde plantillas asi:</para>
        /// <para>"hclregisextxa/hclregisexcbo/hclregisexchk/hclregisexfec"</para>
        /// </summary>
        public void fcvCargHclRegistroCompletarDatosDeGrupos(String tcrArchivo, String tcrFechaIni, String tcrFechaFin)
        {
            var lcrIdArchivo        = oApp.gcrAppBdatosArchvioGuardarDatos;
            var lcrCodVersionPlant  = "XXX";
            var lcrCodigActividadM  = String.Empty;
            var lcrDatoValor        = String.Empty;
            var lcrNumeroCampo      = String.Empty;
            var lcrIdUnicoUsuario   = String.Empty;
            var lcrNumeroIdUsuario  = String.Empty;
            var lcrIdUsuarioAux     = "XX";
            var lcrCodigoAdmision   = String.Empty;
            tmpRegActMS4505 = new ModeloSspNsRes4505Ex();
            List<ModeloGrpplantvistcam> tmpListVar4505VPublicGru = null; // lista campos y variables 4505 asociadas al archivo historico gestionado 

            //var tmpListFormatosHistori = ModeloHclAcciones.flsSQLDataTableHistoricos4505(vm.G1Sia_codeps_teps, tcrFechaIni, tcrFechaFin, tcrArchivo + lcrIdArchivo);

            // Cargar los datos
            foreach (DataRow lobRegHistorico in tmpListFormatosHistori.Rows)
            {
                tmpRegGestion = lobRegHistorico;

                lcrCodVersionPlant = lobRegHistorico["Grp_idepla_grpv"].ToString().Trim();
                lcrIdUnicoUsuario  = lobRegHistorico["Sia_idesec_usua"].ToString().Trim();
                lcrCodigoAdmision  = lobRegHistorico["Adm_secadm_rgad"].ToString().Trim();
                lcrCodigActividadM = lobRegHistorico["Hcl_codreg_hcca"].ToString().ToUpper().Trim();
                lcrNumeroIdUsuario = lobRegHistorico["sia_nroide_usua"].ToString().Trim();

                // comienza otro usuario
                if (lcrIdUsuarioAux != lcrIdUnicoUsuario)
                {
                    tmpRegActMS4505 = vm.TmpG2ListaBrow.FirstOrDefault(x => x.Sia_idesec_usua == lcrIdUnicoUsuario); // buscar al usuario clasificado
                }

                #region llenar datos desde HC para el registro usuario activo clasificado
                if (tmpRegActMS4505 != null)
                {
                    // cuando es otro usuario
                    if (lcrIdUsuarioAux != lcrIdUnicoUsuario)
                    {
                        // Cargar posibles campos del historico en cada version plantilla usada y grupos actividad clasificada 
                        fcvCargHclLimpiarMarcaVar4505TodosGrupos();
                        tmpListVar4505VPublicGru = flsCargHclGenTempDatosGruposActivos(tmpRegActMS4505.Ssp_codpro_ms45, tcrArchivo);
                    }

                    #region buscar en grupos de variables asociadas a campos 
                    if (tmpListVar4505VPublicGru != null)
                    {
                        foreach (var lobVar in tmpListVar4505VPublicGru)
                        {
                            if (lcrCodVersionPlant == lobVar.Grp_idepla_grpv.ToUpper())
                            {

                                // Buscar la variable 4505 con marca de no actualizada en el grupo
                                #region buscar la variable 4505
                                var tmpReg = tmpListActivMedicVar.FirstOrDefault(x => x.Ssp_codpro_sspa == lobVar.Ssp_codpro_sspa &&
                                                                                      x.Ssp_codcam_resc == lobVar.Ssp_codcam_resc &&
                                                                                      x.Hcl_codreg_hcca == lcrCodigActividadM &&
                                                                                      x.Hcl_codreg_hcca != "NA" &&
                                                                                      x.Ssp_parmet_ssvr == "NA" &&
                                                                                      x.Estado == "NA");
                                if (tmpReg != null) // Actualizar variable 4505 
                                {
                                    flgCargHclRegistroGuardarValorDePlantillas(tmpRegGestion, lobVar, tmpReg);
                                }
                                else
                                {
                                    // Buscar sin codigo actividad para los que son diagnosticos y otros comandos
                                    #region buscar la variable 4505
                                    var tmpRegDx = tmpListActivMedicVar.FirstOrDefault(x => x.Ssp_codpro_sspa == lobVar.Ssp_codpro_sspa &&
                                                                                          x.Ssp_codcam_resc == lobVar.Ssp_codcam_resc &&
                                                                                          x.Ssp_parmet_ssvr != "ACT-FECHA" &&
                                                                                          x.Ssp_parmet_ssvr != "NA" &&
                                                                                          x.Estado == "NA");
                                    if (tmpRegDx != null)
                                    {
                                        // Validar comandos 
                                        fcvCargHclRegistroValidComandosPlantilla(tmpRegGestion, lobVar, tmpRegDx);
                                    }
                                    #endregion

                                }
                                #endregion
                            }
                        }
                    }
                    #endregion
                }
                #endregion
                lcrIdUsuarioAux = lcrIdUnicoUsuario;
            }
        }
        #endregion
        #region fcvCargHclRegistroGuardarValorDePlantillas: Guardar los valores encontrados en variables publicas
        /// <summary>
        /// <para>Guardar los valores encontrados en variables publicas que estan relacionadas en plantillas y con variables 4505</para>
        /// </summary>
        public bool flgCargHclRegistroGuardarValorDePlantillas(DataRow tobRegHistorico, 
                                                               ModeloGrpplantvistcam tobRegVarPlantilla, 
                                                               ModeloSpactivMedicVarMD tobActiVarGrupoMD)
        {
            var llgReturn           = false;
            var lcrNumeroCampo4505  = tobActiVarGrupoMD.Ssp_ordvis_resc.ToString().Trim(); // Numero del campo en 4505 desde 0 hasta 119
            var lcrNomCampoPlantill = tobRegVarPlantilla.Hcl_nomcam_hccm.Trim();
            var lcrTipoDatoCampo    = tobActiVarGrupoMD.Ssp_tipval_resc.Trim();
            var lcrCodigoGrupoActiv = tobRegVarPlantilla.Ssp_codpro_sspa;
            var lcrNombreCampo4505  = tobRegVarPlantilla.Ssp_codcam_resc;
            var lcrDatoValor        = fcrCargHclRegistroLeerValorCampo(tobRegHistorico, lcrNomCampoPlantill, lcrTipoDatoCampo);

            llgReturn = flgCargHclRegistroActualizValorEnVariables(lcrDatoValor, lcrNumeroCampo4505, lcrCodigoGrupoActiv, lcrNombreCampo4505);

            return llgReturn;
        }
        #endregion
        #region fcvCargHclRegistroValidComandosPlantilla: Valida y ejecuta los comandos asociados a variables
        /// <summary>
        /// <para>Valida y ejecuta los comandos asociados a variables publicas en cualquier actividad del hisorico HC</para>
        /// <para>para encontrar diagnosticos y otros tipos de datos</para>
        /// </summary>
        public bool fcvCargHclRegistroValidComandosPlantilla(DataRow tobRegHistorico,
                                                               ModeloGrpplantvistcam tobRegVarPlantilla,
                                                               ModeloSpactivMedicVarMD tobActiVarGrupoMD)
        {
            var llgReturn = false;

            var lcrNumeroCampo4505  = tobActiVarGrupoMD.Ssp_ordvis_resc.ToString().Trim(); // Numero del campo en 4505 desde 0 hasta 119
            var lcrNomCampoPlantill = tobRegVarPlantilla.Hcl_nomcam_hccm.Trim();
            var lcrTipoDatoCampo    = tobActiVarGrupoMD.Ssp_tipval_resc.Trim();
            var lcrCodigoGrupoActiv = tobRegVarPlantilla.Ssp_codpro_sspa;
            var lcrNombreCampo4505  = tobRegVarPlantilla.Ssp_codcam_resc;
            var lcrDatoValor        = fcrCargHclRegistroLeerValorCampo(tobRegHistorico, lcrNomCampoPlantill, lcrTipoDatoCampo);

            // Recorrer los comandos existentes
            String[] larArray = (tobActiVarGrupoMD.Ssp_parmet_ssvr).Split(";".ToCharArray());
            int lnuTotElemtos = larArray.Length;
            var lcrComando = larArray[0].Trim();
            String lcrLinea = String.Empty;
            var i = 0;

            for (i = 0; i < lnuTotElemtos; i++)
            {
                lcrLinea  = larArray[i].Trim();
                llgReturn = flgComandoActualizValorDesdePlant(lcrDatoValor, lcrNumeroCampo4505, lcrCodigoGrupoActiv, lcrNombreCampo4505, lcrLinea);
            }
            return llgReturn;
        }
        #endregion
        #region fcrCargHclRegistroLeerValorCampo: Leer el valor del campo dentro del registro activo 
        /// <summary>
        /// <para>Leer el valor del campo dentro del registro activo (registro tipo DataRow de consultas nativas)</para>
        /// <para>PARAMETROS:</para>
        /// <para>tobRegHistorico: Registro del tipo DataRow proveniente de un temporal de consulta nativa</para>
        /// <para>tcrNombreCampoPlant: Nombre del campo en archivo historico que contiene datos de plantillas HC (ejm: Hcl_txt037_hctx)</para>
        /// <para>tcrTipoDatoCampo: D= Fecha/C=Texto/N=Numerico</para>
        /// </summary>
        public String fcrCargHclRegistroLeerValorCampo(DataRow tobRegHistorico,String tcrNombreCampoPlant,String tcrTipoDatoCampo)
        {
            var lcrDatoValor = String.Empty;
            //  tomar el posible valor
            if (tcrTipoDatoCampo == "D")
            {
                lcrDatoValor = tobRegHistorico[tcrNombreCampoPlant].ToString().Trim();
                lcrDatoValor = !String.IsNullOrWhiteSpace(lcrDatoValor) ? lcrDatoValor.Substring(0, 10) : String.Empty;
            }
            else
            {
                lcrDatoValor = tobRegHistorico[tcrNombreCampoPlant].ToString().ToUpper().Trim();
            }

            return lcrDatoValor;
        }
        #endregion
        #region flgCargHclRegistroActualizValorEnVariables: Actualizar el valor en el registro activo y marcar variable 4505
        /// <summary>
        /// <para>Actualizar valor de la variable en registro activo e incluir en lista variables 4505 actaulizadas del registro</para>
        /// <para>Tambien actualiza lista de campos 4505 modificados que pertenecen a un grupo de activida</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrDatoValor: Dato a registrar en la variable correspondiente a 4505</para>
        /// <para>tcrNumeroCampo4505: Numero del campo o variable 4505 desde valor cero hasta 119: "0","1","2"..."118"</para>
        /// <para>tcrCodigoGrupoActividad: "01"=Vacunación/"02"=Salud oral/"03"=Parto...</para>
        /// <para>tcrNombreCampo4505: SSP_CAM090_MS45/ SSP_CAM023_MS45/ SSP_CAM076_MS45...</para>
        /// </summary>
        public bool flgCargHclRegistroActualizValorEnVariables(String tcrDatoValor,  String tcrNumeroCampo4505, 
                                                                 String tcrCodigoGrupoActividad, String tcrNombreCampo4505)
        {
            var llgDatoValor = false;

            if (!Funciones.flgExisteElemento(tcrNumeroCampo4505, "-", tmpRegActMS4505.Ssp_VarMod_ms45))
            {

                if (!String.IsNullOrWhiteSpace(tcrDatoValor))
                {
                    llgDatoValor = flgActualizarDatonRegistroActivo(tcrNumeroCampo4505, tcrDatoValor, "YMD", "-");
                }
                // Marcar la variable 4505 como ya diligenciada en el grupo actividad
                fcvCargHclMarcarVariable4505deGrupo(tcrCodigoGrupoActividad, tcrNombreCampo4505, "SI");
            }

            return llgDatoValor;
        }
        #endregion
        #region flsCargHclGenTempDatosGruposActivos: Generar temporal de campos activos para archivo y grupos actividades
        /// <summary>
        /// <para>Generar temporal de campos activos para grupo actividades y archivo historico que esta en gestion</para>
        /// </summary>
        public List<ModeloGrpplantvistcam> flsCargHclGenTempDatosGruposActivos(String tcrGruposActividades, String tcrArchivo)
        {
            List<ModeloGrpplantvistcam> tmpList = null;

            String lcrIdGrupo   = String.Empty;
            bool llgReturn      = false;
            int lnuTotElemtos   = 0;
            int i = 0;
            tcrArchivo = tcrArchivo.ToUpper();

            String[] larArray = tcrGruposActividades.Split("-".ToCharArray());
            lnuTotElemtos = larArray.Length;

            #region Consulta lista variables relacioandas con versio plantillas
            if (tmpListPlantVarPubGru.Count > 0)
            {
                tmpList = new List<ModeloGrpplantvistcam>();

                // cuando hay varios grupos activos para el registro
                for (i = 0; i < lnuTotElemtos; i++)
                {
                    lcrIdGrupo = larArray[i].ToUpper();

                    var tmp = (from tm in tmpListPlantVarPubGru
                                        where tm.Hcl_nomarc_hccm == tcrArchivo &&
                                              tm.Ssp_codpro_sspa == lcrIdGrupo
                                                orderby tm.Grp_idepla_grpv
                                                select tm).ToList();
                    if (tmp != null)
                    {
                        llgReturn = true;
                        foreach (var lobRegv in tmp)
                        {
                            var lobRegTmp = new ModeloGrpplantvistcam
                            {
                                #region datos
                                Grp_idereg_grob = lobRegv.Grp_idereg_grob,
                                Grp_idepla_grpv = lobRegv.Grp_idepla_grpv,
                                Grp_idepla_grpl = lobRegv.Grp_idepla_grpl,
                                Grp_nomobj_grob = lobRegv.Grp_nomobj_grob,
                                Grp_desobj_grob = lobRegv.Grp_desobj_grob,
                                Grp_varobj_grob = lobRegv.Grp_varobj_grob,
                                Grp_claseb_grob = lobRegv.Grp_claseb_grob,
                                Grp_claseg_grob = lobRegv.Grp_claseg_grob,
                                Hcl_nomcam_hccm = lobRegv.Hcl_nomcam_hccm,
                                Hcl_camdes_hccm = lobRegv.Hcl_camdes_hccm,
                                Hcl_nomvar_hcvr = lobRegv.Hcl_nomvar_hcvr,
                                Grp_repcam_grob = lobRegv.Grp_repcam_grob,
                                Grp_dessec_grse = lobRegv.Grp_dessec_grse,
                                Hcl_nomarc_hccm = lobRegv.Hcl_nomarc_hccm,
                                Ssp_codcam_resc = lobRegv.Ssp_codcam_resc,
                                Ssp_codpro_sspa = lobRegv.Ssp_codpro_sspa
                                #endregion
                            };
                            tmpList.Add(lobRegTmp);
                        }
                    }
                }
                if (llgReturn == false) { tmpList = null; }
            }
            #endregion
            return tmpList;
        }
        #endregion
        #region flgCargHclGenerarDatosClasificarPaciente: Generar registro 4505 y clasificar segun grupos
        /// <summary>
        /// <para>Generar registro 4505 y clasificar segun grupos de actividades</para>
        /// </summary>
        public int flgCargHclGenerarDatosClasificarPaciente(int tcrContador)
        {
            var lcrContador         = tcrContador;
            var lcrIdUnicoUsuario   = String.Empty;
            var lcrIdUsuario        = String.Empty;
            var lcrCodigoAdmision   = String.Empty;
            tmpDetallAdmEvenAux     = new List<ModeloSpaActivRegApEventos>(); // lista de eventos medicos
            tmpDetallFactAdd        = new List<FcmModeloServDetallFacturas>();
            ModeloGrupoActividadesMA lobRegGrupox   = null;
            ModeloSpactivservfactMD lobRegActx      = null;
            FcmModeloServDetallFacturas lobRegServx = null;

            fcvCargHclLimpiarMarcaTodosLosGrupos();

            // Generar procesos
            foreach (var loRegGrupo in tmpListGrupoActividad)
            {
                lobRegGrupox = loRegGrupo;
                // Gestion temporal actividades detalles de un grupo
                loRegGrupo.Ssp_TotValrips_sspa = 0;
                loRegGrupo.Ssp_TotDefinit_sspa = 0;
                loRegGrupo.Ssp_LstDefinit_sspa = String.Empty;

                tmpDetallGrupoActivo = flsCargHclSelectDetalleGrupo(loRegGrupo.Ssp_codpro_sspa);

                // Cargar los datos
                foreach (var lobRegAct in tmpDetallGrupoActivo)
                {
                    lobRegActx = lobRegAct;
                    #region Validacion en posibles servicios 4505
                    foreach (var lobRegServ in tmpDetallesFact)
                    {
                        lobRegServx = lobRegServ;
                        if (String.IsNullOrWhiteSpace(lcrIdUnicoUsuario))
                        {
                            lcrIdUnicoUsuario = lobRegServ.Sia_idesec_usua.Trim();
                            lcrCodigoAdmision = lobRegServ.Adm_secadm_rgad.Trim();
                            lcrIdUsuario      = lobRegServ.Sia_nroide_usua.Trim();

                        }
                        if (lobRegServ.Modificado == "NO" && lobRegAct.Estado == "NA")
                        {
                            // Ejecutar la validacion del registro
                            if (flgCargHclRegistrarServicioDetalleGrupo(ref  lobRegGrupox, ref lobRegActx, ref lobRegServx) == true)
                            {
                                lobRegAct.IdUnicoRegistro = lobRegServ.Fcm_secreg_dfac;
                                lobRegAct.Estado          = "SI";
                                lobRegServ.Modificado     = "SI";
                            }
                        }
                    }
                    #endregion
                }
                // se agregaron registros de servicios con el comando GES-ADD (ACT-FECHA o ACT-VALOR)
                #region se agregaron registros
                if (tmpDetallFactAdd != null)
                {
                    foreach (var lobReg in tmpDetallFactAdd)
                    {
                        var lobRegAux = fobCargHclRegCopiarRegAuxServFacturados(lobReg);
                        tmpDetallesFact.Add(lobRegAux);
                    }
                }
                #endregion
                // Si califica a todo el grupo como actividad 4505
                #region Si califica 
                if (loRegGrupo.Ssp_TotDefinit_sspa > 0 ||
                    (loRegGrupo.Ssp_TotValrips_sspa >= loRegGrupo.Ssp_ttrips_sspa && 
                    loRegGrupo.Ssp_TotValrips_sspa > 0))
                {
                    // Se generaron registros que referencian eventos medicos en historia clinica
                    #region se agregaron registros que referencian admision
                    if (tmpDetallAdmEvenAux != null)
                    {
                        foreach (var lobReg in tmpDetallAdmEvenAux)
                        {
                            var lobRegAux = fobCargHclRegCopiarRegAuxServAdmFact(lobReg);
                            tmpDetallAdmEven.Add(lobRegAux);
                        }
                    }
                    #endregion
                    // aqui buscar datos del paciente / sino existe generar datos
                    lcrContador = fnuGenRegistroActivoRE4505(loRegGrupo.Ssp_codpro_sspa, lcrIdUnicoUsuario, lcrCodigoAdmision, lcrContador);
                    fcvCargarCampoDatosComplementarios(lcrIdUnicoUsuario, lcrCodigoAdmision);
                    // Parches
                    //fcvParcheCorreccionesGenerales();

                    // Las identificaciones de grupos
                    #region Las identificaciones de grupos
                    if (tmpRegActMS4505 != null)
                    {
                        if (tmpRegActMS4505.Ssp_codpro_sspa == "NA")
                        {
                            tmpRegActMS4505.Ssp_codpro_sspa = loRegGrupo.Ssp_codpro_sspa;
                            tmpRegActMS4505.Ssp_codpro_ms45 = loRegGrupo.Ssp_codpro_sspa;
                            tmpRegActMS4505.Ssp_abrevi_sspa = loRegGrupo.Ssp_abrevi_sspa;
                            tmpRegActMS4505.Ssp_abrevi_ms45 = loRegGrupo.Ssp_abrevi_sspa;
                        }
                        else 
                        {
                            tmpRegActMS4505.Ssp_abrevi_ms45 += "-" + loRegGrupo.Ssp_abrevi_sspa;
                            tmpRegActMS4505.Ssp_codpro_ms45 += "-" + loRegGrupo.Ssp_codpro_sspa;
                        }

                        // Completar las variables segun los parametros en cada actividad del grupo
                        flgCargHclValParamActivDetalleGrupo(loRegGrupo);
                    }
                    #endregion
                }
                else
                {
                    // Desmarcar todo el grupo y los servicios rips 
                    #region Desmarcar todo el grupo y los servicios rips
                    loRegGrupo.Ssp_TotValrips_sspa = 0;
                    loRegGrupo.Ssp_TotDefinit_sspa = 0;
                    loRegGrupo.Ssp_LstDefinit_sspa = String.Empty;
                    fcvCargHclLimpiarMarcaIdGrupoServFact(loRegGrupo.Ssp_codpro_sspa);
                    #endregion
                }
                #endregion
            }

            return lcrContador;
        }
        #endregion
        #region flgCargHclRegistrarServicioDetalleGrupo: Registrar los servcios que clasifican en el grupo
        /// <summary>
        /// <para>Registrar los servcios que clasifican en el grupo siempre y cuando clasifiquen</para>
        /// </summary>
        public bool flgCargHclRegistrarServicioDetalleGrupo(ref  ModeloGrupoActividadesMA tobRegGrupo,
                                                        ref ModeloSpactivservfactMD tobRegAct, ref FcmModeloServDetallFacturas tobRegServ)
        {
            var llgReturn = false;

            // Ejecutar la validacion del registro para ver si clasifican
            if (flgCargHclValidarActividadRipsGrupo(tobRegAct, tobRegServ) == true)
            {
                llgReturn = true;
                tobRegAct.IdUnicoRegistro = tobRegServ.Fcm_secreg_dfac;
                tobRegAct.Estado          = "SI";
                tobRegServ.Modificado     = "SI";
                var lcrCodRegDetallGrupo  = tobRegAct.Ssp_secreg_ssfc;

                // sumar en las actividades validadas del grupo
                tobRegGrupo.Ssp_TotValrips_sspa++;
                if (tobRegAct.Ssp_coddig_ssfc == "NA")
                {
                    // esta actividad califica al grupo sin mas, porque no necesita ninguna otra
                    tobRegGrupo.Ssp_TotDefinit_sspa++;
                    tobRegGrupo.Ssp_LstDefinit_sspa = String.IsNullOrWhiteSpace(tobRegGrupo.Ssp_LstDefinit_sspa) ?
                                                    tobRegAct.Fcm_coddig_mant : tobRegGrupo.Ssp_LstDefinit_sspa + ";" + tobRegAct.Fcm_coddig_mant;
                }
                // Verificar el servicio o actividad principal referenciada para buscarla
                #region Verificar el servicio o actividad principal
                if (tobRegAct.Ssp_parmet_ssfc != null)
                {
                    if (tobRegAct.Ssp_parmet_ssfc != "NA")
                    {
                        String[] larArray = (tobRegAct.Ssp_parmet_ssfc).Split(";".ToCharArray());
                        int lnuTotElemtos = larArray.Length;
                        var lcrComando = larArray[0].Trim();
                        String lcrLinea = String.Empty;
                        var i = 0;

                        for (i = 0; i < lnuTotElemtos; i++)
                        {
                            lcrLinea = larArray[i].Trim();

                            // Comando GES-VALID Ejemplo: "GES-VALID*58*CE025*10*180*1*2"
                            #region Comando GES-VALID
                            if (Funciones.flgExisteElemento("GES-VALID", "*", lcrLinea))
                            {
                                var lcrValor = fcrComandoGestion_GES_VALID(tobRegServ.Sia_idesec_usua, lcrLinea, "*");
                                if (!String.IsNullOrWhiteSpace(lcrValor))
                                {
                                    tobRegAct.Ssp_parmet_ssfc = tobRegAct.Ssp_parmet_ssfc + ";" + lcrValor;
                                }
                            }
                            #endregion
                            // Comando GES-ADD  Ejemplo: "GES-ADD*CE025*25*180"
                            #region Comando GES-ADD
                            if (Funciones.flgExisteElemento("GES-ADD", "*", lcrLinea))
                            {
                                flgComandoGestion_GES_ADD(ref  tobRegGrupo, tobRegServ.Sia_idesec_usua, lcrLinea);
                            }
                            #endregion
                            // Comando GES-HCLAP  Ejemplo: "GES-HCLAP*RES-LABORAT-GLICEMIA"
                            #region  Comando GES-HCLAP
                            if (Funciones.flgExisteElemento("GES-HCLAP", "*", lcrLinea))
                            {
                                flgComandoGestion_GES_HCLAP(tobRegAct, tobRegServ, lcrLinea);
                            }
                            #endregion
                            // Comando GES-HCLFEX  Ejemplo: "GES-HCLFEX*30*180*RESULT-LAB-CITOLOGIA"
                            #region  Comando GES-HCLFEX
                            if (Funciones.flgExisteElemento("GES-HCLFEX", "*", lcrLinea))
                            {
                                flgComandoGestion_GES_HCLFEX(tobRegAct, tobRegServ, lcrLinea);
                            }
                            #endregion
                        }
                    }
                }
                #endregion
            }
            return llgReturn;
        }
        #endregion
        #region flgCargHclValidarActividadRipsGrupo: Valida si un registro facturado clasifica
        /// <summary>
        /// <para>Valida si un registro facturado clasifica como una actividad aceptada en un grupo  4505</para>
        /// </summary>
        public bool flgCargHclValidarActividadRipsGrupo(ModeloSpactivservfactMD tobRegActiv, FcmModeloServDetallFacturas tobRegServRips)
        {
            // Variables para saber si aplica una condicion y si esta se cumple 
            var lcrValFinPro = "2"; // Finalidad Procedimiento - "2"= NO Por Defecto 
            var lcrValFinCon = "2"; // Finalidad Consulta - "2"= NO Por Defecto
            var lcrValCauExt = "2"; // Causa externa - "2"= NO Por Defecto
            var lcrValSiEdad = "2"; // Edad del paciente - "2"= NO Por Defecto
            var lcrValSexoAp = "2"; // Sexo del paciente - "2"= NO Por Defecto
            var lcrValDiagno = "2"; // Diagnostico - "2"= NO Por Defecto
            var lcrValidacion = String.Empty;
            var llgValidDiag = false; // para verificar si ya entro en alguna validacion de diagnostico y se aprobo

            var gnuSipsEdadIniDia = fnuUtilidEdadEnDias(tobRegActiv.Fcm_mededi_sips, tobRegActiv.Fcm_edaini_sips);
            var gnuSipsEdadFinDia = fnuUtilidEdadEnDias(tobRegActiv.Fcm_mededf_sips, tobRegActiv.Fcm_edafin_sips);


            var llgReturn = false;

            //  debe ser el mismo codigo de servicio segun tarifario
            //if (tobRegActiv.Fcm_codser_sips != tobRegServRips.Fcm_codser_mant) // cuando no este integrado con Galeno HC
            if (tobRegActiv.Fcm_coddig_mant != tobRegServRips.Fcm_coddig_mant)
            {
                llgReturn = false;
            }
            else
            {
                // Todas cumplen por defecto "1"
                lcrValFinPro = "1"; // Finalidad Procedimiento
                lcrValFinCon = "1"; // Finalidad Consulta
                lcrValCauExt = "1"; // Causa externa
                lcrValSiEdad = "1"; // Edad del paciente
                lcrValSexoAp = "1"; // Sexo del paciente
                lcrValDiagno = "1"; // Diagnostico

                #region Finalidad consulta
                if (tobRegActiv.Sia_codfco_fcon != "NA")
                {
                    lcrValFinCon = "2"; // No paso la validacion
                    if (tobRegServRips.Sia_codfco_fcon != "NA")
                    {
                        if (Funciones.flgExisteElemento(tobRegServRips.Sia_codfco_fcon, ";", tobRegActiv.Sia_codfco_fcon))
                        {
                            lcrValFinCon = "1"; // Cumple condicion 
                        }
                    }
                }
                #endregion
                #region Finalidad Procedimiento
                if (tobRegActiv.Sia_codfpr_fpro != "NA")
                {
                    lcrValFinPro = "2"; // No paso la validacion

                    if (tobRegServRips.Sia_codfpr_fpor != "NA")
                    {
                        if (Funciones.flgExisteElemento(tobRegServRips.Sia_codfpr_fpor, ";", tobRegActiv.Sia_codfpr_fpro))
                        {
                            lcrValFinPro = "1"; // Cumple condicion 
                        }
                    }
                }
                #endregion
                #region Causa externa
                if (tobRegActiv.Adm_codcex_tcex != "NA")
                {
                    lcrValCauExt = "2"; // No paso la validacion

                    if (tobRegServRips.Adm_codcex_tcex != "NA")
                    {
                        if (Funciones.flgExisteElemento(tobRegServRips.Adm_codcex_tcex, ";", tobRegActiv.Adm_codcex_tcex))
                        {
                            lcrValCauExt = "1"; // Cumple condicion 
                        }
                    }
                }
                #endregion
                #region Edad del paciente que aplica al servicio
                if (tobRegServRips.Sia_edadia_usua < gnuSipsEdadIniDia || tobRegServRips.Sia_edadia_usua > gnuSipsEdadFinDia)
                {
                    lcrValSiEdad = "2"; // No paso la validacion
                }
                #endregion
                #region Sexo del paciente
                if (tobRegActiv.Fcm_sexapl_sips != "3")
                {
                    var lcrSexo = tobRegActiv.Fcm_sexapl_sips == "1" ? "M" : "F";
                    lcrValSexoAp = "1"; // Validacion Ok

                    if (tobRegServRips.Sis_codsex_sexo != lcrSexo)
                    {
                        lcrValSexoAp = "2"; // No paso la validacion
                    }
                }
                #endregion
                #region Validacion de Diagnosticos
                #region Diagnostico principal
                if (tobRegActiv.Fcm_coddia_sips != "NA")
                {
                    lcrValDiagno = "2"; // No paso la validacion

                    if (tobRegServRips.Sia_coddia_tdia != "NA")
                    {
                        if (Funciones.flgExisteElemento(tobRegServRips.Sia_coddia_tdia, ";", tobRegActiv.Fcm_coddia_sips))
                        {
                            llgValidDiag = true;
                            lcrValDiagno = "1"; // si es valido
                        }
                    }
                }
                #endregion
                #region Diagnostico Relacionado 1
                if (tobRegActiv.Fcm_coddia_sips != "NA" && llgValidDiag == false)
                {
                    lcrValDiagno = "2"; // No paso la validacion

                    if (tobRegServRips.Sia_coddx1_tdia != "NA")
                    {
                        if (Funciones.flgExisteElemento(tobRegServRips.Sia_coddx1_tdia, ";", tobRegActiv.Fcm_coddia_sips))
                        {
                            lcrValDiagno = "1"; // Si cumple
                            llgValidDiag = true;
                        }
                    }
                }
                #endregion
                #region Diagnostico Relacionado 2
                if (tobRegActiv.Fcm_coddia_sips != "NA" && llgValidDiag == false)
                {
                    lcrValDiagno = "2"; // No paso la validacion

                    if (tobRegServRips.Sia_coddx2_tdia != "NA")
                    {
                        if (Funciones.flgExisteElemento(tobRegServRips.Sia_coddx2_tdia, ";", tobRegActiv.Fcm_coddia_sips))
                        {
                            lcrValDiagno = "1"; // Si cumple
                            llgValidDiag = true;
                        }
                    }
                }
                #endregion
                #region Diagnostico Relacionado 3
                if (tobRegActiv.Fcm_coddia_sips != "NA" && llgValidDiag == false)
                {
                    lcrValDiagno = "2"; // No paso la validacion

                    if (tobRegServRips.Sia_coddx3_tdia != "NA")
                    {
                        if (Funciones.flgExisteElemento(tobRegServRips.Sia_coddx3_tdia, ";", tobRegActiv.Fcm_coddia_sips))
                        {
                            lcrValDiagno = "1"; // Si cumple
                            llgValidDiag = true;
                        }
                    }
                }
                #endregion
                #endregion
            }
            lcrValidacion = lcrValFinPro + lcrValFinCon + lcrValCauExt + lcrValSiEdad + lcrValSexoAp + lcrValDiagno;
            // el servicio califica para la actividad del grupo
            llgReturn = lcrValidacion == "111111" ? true : false;

            return llgReturn;
        }
        #endregion
        #region flgCargHclValParamActivDetalleGrupo: Registrar los valores en 4505 desde actividades
        /// <summary>
        /// <para>Registrar los valores en 4505 desde los parametros actividades facturadas en un grupo </para>
        /// </summary>
        public bool flgCargHclValParamActivDetalleGrupo(ModeloGrupoActividadesMA tobGrupo)
        {
            var llgReturn = false;
            var tmpDetallGrupo = flsCargHclSelectDetalleGrupo(tobGrupo.Ssp_codpro_sspa);
            ModeloSpactivservfactMD lobRegActividad = null;

            // Cargar los datos
            #region Cargar los datos
            foreach (var lobRegAct in tmpDetallGrupo)
            {
                lobRegActividad = lobRegAct;
                llgReturn = flgComandoActualizarValores(lobRegActividad);
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgActualizarDatonRegistroActivo: Actualizar datos 4505 desde servicios detalles
        /// <summary>
        /// <para>Actualizar datos 4505 desde servicios detalles grupo de actividad</para>
        /// </summary>
        public bool flgActualizarDatonRegistroActivo(String tcrNumeroCampo4505, String tcrDatoValor, String tcrFormatoFecha, String tcrSeparadorFecha)
        {
            var llgReturn = false;

            llgReturn = flgCargarCampoRegistroMS4505_R029(tcrNumeroCampo4505, tcrDatoValor, "YMD", "-");
            if (llgReturn == false)
            {
                llgReturn = flgCargarCampoRegistroMS4505_R3059(tcrNumeroCampo4505, tcrDatoValor, "YMD", "-");
            }
            if (llgReturn == false)
            {
                llgReturn = flgCargarCampoRegistroMS4505_R6089(tcrNumeroCampo4505, tcrDatoValor, "YMD", "-");
            }
            if (llgReturn == false)
            {
                llgReturn = flgCargarCampoRegistroMS4505_R90118(tcrNumeroCampo4505, tcrDatoValor, "YMD", "-");
            }

            return llgReturn;
        }
        #endregion
        #region flsCargHclSelectDetalleGrupo: seleccionar registros detalles de un grupo
        /// <summary>
        /// <para>Seleccionar registros detalles de un grupo de actividad</para>
        /// </summary>
        public List<ModeloSpactivservfactMD> flsCargHclSelectDetalleGrupo(String tcrIdGrupo)
        {
            var lcrQuery = (from lst in tmpListGrupoDetalles 
                            where lst.Ssp_codpro_sspa == tcrIdGrupo
                            orderby lst.Ssp_priori_ssfc
                            select lst).ToList();

            return lcrQuery;
        }
        #endregion
        #region fobRegServicioFactIdUsuarioFecha: Devuelve registro, dado Id Paciente Codigo digitacion y rango fechas
        /// <summary>
        /// <para>Dado codigo unico paciente, codigo digitacion servicio y rango de fechas devuelve un</para>
        /// <para>registro tipo FcmModeloServDetallFacturas (servicio facturado), cuando no exite retorna  null.</para>
        /// </summary>
        public FcmModeloServDetallFacturas fobRegServicioFactIdUsuarioFecha(String tcrIdUsuario, String tcrCodigoDigitacion,
                                                                            String tcrFechaInicial, String tcrFechaFinal)
        {
            FcmModeloServDetallFacturas lobReServ = null;
            var tmpListServFact = flsCargHclSQLConsultDatosFacturados(tcrIdUsuario, tcrCodigoDigitacion, tcrFechaInicial, tcrFechaFinal);

            #region Generar lista de todos los posibles registrios de 4505
            // Cargar los datos
            foreach (DataRow lobReg in tmpListServFact.Rows)
            {
                lobReServ = fobCargHclRegDefaultDesdeServFacturados(lobReg);
                break;
            }
            #endregion
            return lobReServ;
        }
        #endregion
        // Funciones auxiliares para generar nuevos registros
        #region fobCargHclRegDefaultDesdeServFacturados: Cargar datos en registro con formato FcmModeloServDetallFacturas
        /// <summary>
        /// <para>Cargar datos en registro con formato FcmModeloServDetallFacturas, desde temporal de consulta nativa facturacion</para>
        /// </summary>
        public FcmModeloServDetallFacturas fobCargHclRegDefaultDesdeServFacturados(DataRow tobRegFactura)
        {
            var lobReg = new FcmModeloServDetallFacturas();
            var lcrFechaServ = (tobRegFactura["fcm_fecser_dfac"].ToString()).Substring(0, 10);

            #region datos del registro
            lobReg.Fcm_secreg_dfac = tobRegFactura["fcm_secreg_dfac"].ToString().Trim();
            lobReg.Adm_secadm_rgad = tobRegFactura["adm_secadm_rgad"].ToString().Trim();
            lobReg.Sia_codeps_teps = tobRegFactura["sia_codeps_teps"].ToString().Trim();
            lobReg.Sia_idesec_usua = tobRegFactura["sia_idesec_usua"].ToString().Trim();
            lobReg.Sia_tipide_tide = tobRegFactura["sia_tipide_tide"].ToString().Trim();
            lobReg.Sia_nroide_usua = tobRegFactura["sia_nroide_usua"].ToString().Trim();
            lobReg.Sis_codsex_sexo = tobRegFactura["sis_codsex_sexo"].ToString().Trim();
            lobReg.Sia_edaano_usua = tobRegFactura["sia_edaano_usua"] != null ? Convert.ToInt32(tobRegFactura["sia_edaano_usua"].ToString()) : 0;
            lobReg.Sia_edames_usua = tobRegFactura["sia_edames_usua"] != null ? Convert.ToInt32(tobRegFactura["sia_edames_usua"].ToString()) : 0;
            lobReg.Sia_edadia_usua = tobRegFactura["sia_edadia_usua"] != null ? Convert.ToInt32(tobRegFactura["sia_edadia_usua"].ToString()) : 0;
            lobReg.Sia_edaymd_usua = tobRegFactura["sia_edaymd_usua"].ToString().Trim();
            lobReg.Adm_pacemb_rgad = tobRegFactura["adm_pacemb_rgad"].ToString().Trim();
            lobReg.Fcm_codser_mant = tobRegFactura["fcm_codser_mant"].ToString().Trim();
            lobReg.Fcm_coddig_mant = tobRegFactura["fcm_coddig_mant"].ToString().Trim();
            lobReg.Fcm_desser_dfac = tobRegFactura["fcm_desser_dfac"].ToString().Trim();
            lobReg.Fcm_fecser_dfac = Convert.ToDateTime(lcrFechaServ);
            lobReg.Sia_codrip_trip = tobRegFactura["sia_codrip_trip"].ToString().Trim();
            lobReg.Fcm_horser_dfac = tobRegFactura["fcm_horser_dfac"] != null ? Convert.ToDecimal(tobRegFactura["fcm_horser_dfac"].ToString()) : 0;
            lobReg.Sia_tipact_tsac = tobRegFactura["sia_tipact_tsac"].ToString().Trim();
            lobReg.Sia_codfpr_fpor = tobRegFactura["sia_codfpr_fpor"] != null ? tobRegFactura["sia_codfpr_fpor"].ToString().Trim() : "NA";
            lobReg.Sia_codfco_fcon = tobRegFactura["sia_codfco_fcon"] != null ? tobRegFactura["sia_codfco_fcon"].ToString().Trim() : "NA";
            lobReg.Adm_codcex_tcex = tobRegFactura["adm_codcex_tcex"] != null ? tobRegFactura["adm_codcex_tcex"].ToString().Trim() : "NA";
            lobReg.Sia_coddia_tdia = tobRegFactura["sia_coddia_tdia"] != null ? tobRegFactura["sia_coddia_tdia"].ToString().Trim() : "NA";
            lobReg.Sia_tipdxp_tdix = tobRegFactura["sia_tipdxp_tdix"].ToString().Trim();
            lobReg.Sia_coddx1_tdia = tobRegFactura["sia_coddx1_tdia"] != null ? tobRegFactura["sia_coddx1_tdia"].ToString().Trim() : "NA";
            lobReg.Sia_coddx2_tdia = tobRegFactura["sia_coddx2_tdia"] != null ? tobRegFactura["sia_coddx2_tdia"].ToString().Trim() : "NA";
            lobReg.Sia_coddx3_tdia = tobRegFactura["sia_coddx3_tdia"] != null ? tobRegFactura["sia_coddx3_tdia"].ToString().Trim() : "NA";
            lobReg.Sia_coddxc_tdia = tobRegFactura["sia_coddxc_tdia"].ToString().Trim();
            lobReg.Fcm_otserv_sips = tobRegFactura["fcm_otserv_sips"].ToString().Trim();
            lobReg.Modificado ="NO";
            #endregion

            return lobReg;
        }
        #endregion
        #region fobCargHclRegCopiarRegAuxServFacturados: Genera una copia independiente del registro dado en parametro
        /// <summary>
        /// <para>Genera una copia independiente del registro dado en parametro</para>
        /// </summary>
        public FcmModeloServDetallFacturas fobCargHclRegCopiarRegAuxServFacturados(FcmModeloServDetallFacturas tobRegFactura)
        {
            var lobReg = new FcmModeloServDetallFacturas();

            #region datos del registro
            lobReg.Fcm_secreg_dfac = tobRegFactura.Fcm_secreg_dfac;
            lobReg.Adm_secadm_rgad = tobRegFactura.Adm_secadm_rgad;
            lobReg.Sia_codeps_teps = tobRegFactura.Sia_codeps_teps;
            lobReg.Sia_idesec_usua = tobRegFactura.Sia_idesec_usua;
            lobReg.Sia_tipide_tide = tobRegFactura.Sia_tipide_tide;
            lobReg.Sia_nroide_usua = tobRegFactura.Sia_nroide_usua;
            lobReg.Sis_codsex_sexo = tobRegFactura.Sis_codsex_sexo;
            lobReg.Sia_edaano_usua = tobRegFactura.Sia_edaano_usua;
            lobReg.Sia_edames_usua = tobRegFactura.Sia_edames_usua;
            lobReg.Sia_edadia_usua = tobRegFactura.Sia_edadia_usua;
            lobReg.Sia_edaymd_usua = tobRegFactura.Sia_edaymd_usua;
            lobReg.Adm_pacemb_rgad = tobRegFactura.Adm_pacemb_rgad;
            lobReg.Fcm_codser_mant = tobRegFactura.Fcm_codser_mant;
            lobReg.Fcm_coddig_mant = tobRegFactura.Fcm_coddig_mant;
            lobReg.Fcm_desser_dfac = tobRegFactura.Fcm_desser_dfac;
            lobReg.Fcm_fecser_dfac = tobRegFactura.Fcm_fecser_dfac;
            lobReg.Sia_codrip_trip = tobRegFactura.Sia_codrip_trip;
            lobReg.Fcm_horser_dfac = tobRegFactura.Fcm_horser_dfac;
            lobReg.Sia_tipact_tsac = tobRegFactura.Sia_tipact_tsac;
            lobReg.Sia_codfpr_fpor = tobRegFactura.Sia_codfpr_fpor;
            lobReg.Sia_codfco_fcon = tobRegFactura.Sia_codfco_fcon;
            lobReg.Adm_codcex_tcex = tobRegFactura.Adm_codcex_tcex;
            lobReg.Sia_coddia_tdia = tobRegFactura.Sia_coddia_tdia;
            lobReg.Sia_tipdxp_tdix = tobRegFactura.Sia_tipdxp_tdix;
            lobReg.Sia_coddx1_tdia = tobRegFactura.Sia_coddx1_tdia;
            lobReg.Sia_coddx2_tdia = tobRegFactura.Sia_coddx2_tdia;
            lobReg.Sia_coddx3_tdia = tobRegFactura.Sia_coddx3_tdia;
            lobReg.Sia_coddxc_tdia = tobRegFactura.Sia_coddxc_tdia;
            lobReg.Fcm_otserv_sips = tobRegFactura.Fcm_otserv_sips;
            lobReg.Modificado = "SI";
            #endregion

            return lobReg;
        }
        #endregion
        #region fobCargHclRegCopiarRegAuxServAdmFact: Genera copia independiente registro evento referenciado en facturacion
        /// <summary>
        /// <para>Genera copia independiente registro evento referenciado en facturacion, para eventos medicos</para>
        /// </summary>
        public ModeloSpaActivRegApEventos fobCargHclRegCopiarRegAuxServAdmFact(ModeloSpaActivRegApEventos tobRegFactura)
        {
            var lobReg = new ModeloSpaActivRegApEventos();

            #region datos del registro
            lobReg.Fcm_secreg_dfac = tobRegFactura.Fcm_secreg_dfac;
            lobReg.Sia_idesec_usua = tobRegFactura.Sia_idesec_usua;
            lobReg.Sia_nroide_usua = tobRegFactura.Sia_nroide_usua;
            lobReg.Adm_secadm_rgad = tobRegFactura.Adm_secadm_rgad;
            lobReg.Hcl_codreg_hcca = tobRegFactura.Hcl_codreg_hcca;
            lobReg.Ssp_secreg_ssfc = tobRegFactura.Ssp_secreg_ssfc;
            lobReg.Ssp_codpro_sspa = tobRegFactura.Ssp_codpro_sspa;
            lobReg.Fcm_coddig_mant = tobRegFactura.Fcm_coddig_mant;
            lobReg.Fcm_secreg_dfac = tobRegFactura.Fcm_secreg_dfac;
            lobReg.Ssp_parmet_ssfc = tobRegFactura.Ssp_parmet_ssfc;
            #endregion

            return lobReg;
        }
        #endregion
        #region fobCargHclRegNuevoServAdmFact: Genera nuevo registro evento referenciado en facturacion
        /// <summary>
        /// <para>Genera nuevo registro evento referenciado en facturacion</para>
        /// </summary>
        public ModeloSpaActivRegApEventos fobCargHclRegNuevoServAdmFact(ModeloSpactivservfactMD tobRegAct, FcmModeloServDetallFacturas tobRegFactura)
        {
            var lobReg = new ModeloSpaActivRegApEventos();

            #region datos del registro
            lobReg.Fcm_secreg_dfac = tobRegFactura.Fcm_secreg_dfac;
            lobReg.Sia_idesec_usua = tobRegFactura.Sia_idesec_usua;
            lobReg.Sia_nroide_usua = tobRegFactura.Sia_nroide_usua;
            lobReg.Adm_secadm_rgad = tobRegFactura.Adm_secadm_rgad;
            lobReg.Hcl_codreg_hcca = tobRegFactura.Hcl_codreg_hcca;
            lobReg.Ssp_secreg_ssfc = tobRegAct.Ssp_secreg_ssfc;
            lobReg.Ssp_codpro_sspa = tobRegAct.Ssp_codpro_sspa;
            lobReg.Fcm_coddig_mant = tobRegFactura.Fcm_coddig_mant;
            lobReg.Fcm_secreg_dfac = tobRegFactura.Fcm_secreg_dfac;
            lobReg.Fcm_fecser_dfac = tobRegFactura.Fcm_fecser_dfac;
            lobReg.Ssp_parmet_ssfc = tobRegAct.Ssp_parmet_ssfc;
            #endregion

            return lobReg;
        }
        #endregion
        // Consultas SQL
        #region flsCargHclSQLConsultDatosFacturados: Ejecutar consultas desde registros facturados
        /// <summary>
        /// <para>Ejecutar consultas desde registros facturados y devuelve un temporal de tipo DateTable con todos</para>
        /// <para>los registros facturados en el periodo</para>
        /// </summary>
        public DataTable flsCargHclSQLConsultDatosFacturados(String tcrCodigoEps, String tcrFechaIni, String tcrFechaFin)
        {
            DataTable objDatosTabla = new DataTable();
            var lcrLineaSqlSelct = String.Empty;
            var lcrFiltro = String.Empty;

            lcrFiltro = flsCargHclSQLFiltroStringDatosFacturados(tcrCodigoEps, tcrFechaIni, tcrFechaFin);
            lcrLineaSqlSelct = fcrCargHclSQLGenLineaStringDatosFacturados(lcrFiltro, "ORDER BY fcmmaedetallfac.sia_idesec_usua, fcmmaedetallfac.fcm_fecser_dfac DESC");

            objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);

            return objDatosTabla;
        }
        #endregion
        #region flsCargHclSQLConsultDatosFacturados: Ejecutar consultas registros facturados para un paciente
        /// <summary>
        /// <para>Ejecutar consultas servicios facturados y devuelve temporal tipo DateTable con registros del paciente en periodo dado</para>
        /// </summary>
        public DataTable flsCargHclSQLConsultDatosFacturados(String tcrIdUnicoPaciente, String tcrCodigoDigitacion, String tcrFechaIni, String tcrFechaFin)
        {
            DataTable objDatosTabla = new DataTable();
            var lcrLineaSqlSelct    = String.Empty;

            var lcrFiltro = flsCargHclSQLFiltroStringDatosFacturados("", tcrFechaIni, tcrFechaFin);

            lcrFiltro = "(fcmmaedetallfac.sia_idesec_usua = '" + tcrIdUnicoPaciente + "') AND " +
                        "(fcmmaedetallfac.fcm_coddig_mant = '" + tcrCodigoDigitacion + "') AND " + lcrFiltro;

            lcrLineaSqlSelct = fcrCargHclSQLGenLineaStringDatosFacturados(lcrFiltro, "ORDER BY fcmmaedetallfac.fcm_fecser_dfac DESC");

            objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);

            return objDatosTabla;
        }
        #endregion
        #region flsCargHclSQLFiltroStringDatosFacturados: Expresion filtro SQL para servicios facturados
        /// <summary>
        /// <para>Generar la expresion filtro de la String SQL para consultar servicios facturados</para>
        /// </summary>
        public String flsCargHclSQLFiltroStringDatosFacturados(String tcrCodigoEps, String tcrFechaIni, String tcrFechaFin)
        {
            var lcrFiltro = String.Empty;

            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", tcrFechaIni, "YMD", "-"); ;
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", tcrFechaFin, "YMD", "-");

            if (String.IsNullOrWhiteSpace(tcrCodigoEps))
            {
                lcrFiltro = "(fcmmaedetallfac.fcm_fecser_dfac >= '" + lcrFechaIni + "') AND " +
                            "(fcmmaedetallfac.fcm_fecser_dfac <= '" + lcrFechaFin + "') AND ";
            }
            else
            {
                lcrFiltro = "(fcmmaedetallfac.fcm_fecser_dfac >= '" + lcrFechaIni + "') AND " +
                            "(fcmmaedetallfac.fcm_fecser_dfac <= '" + lcrFechaFin + "') AND " +
                            "(fcmmaedetallfac.sia_codeps_teps = '" + tcrCodigoEps + "') AND ";

            }

            return lcrFiltro;
        }
        #endregion
        #region fcrCargHclSQLGenLineaStringDatosFacturados: Linea SQL tipo texto para consulta
        /// <summary>
        /// <para>Linea SQL tipo texto para Ejecutar consultas desde registros facturados</para>
        /// </summary>
        public String fcrCargHclSQLGenLineaStringDatosFacturados(String tcrFiltro, String tcrOrderBy)
        {
            var lcrLineaSqlSelct = String.Empty;
            #region Linea SQl para ejecutar
            lcrLineaSqlSelct = "SELECT fcmmaedetallfac.fcm_secreg_dfac," +
                             "fcmmaedetallfac.adm_secadm_rgad," +
                             "fcmmaedetallfac.sia_codeps_teps," +
                             "admregadmision.sia_idesec_usua," +
                             "admregadmision.sia_tipide_tide," +
                             "admregadmision.sia_nroide_usua," +
                             "siausuarioatend.sis_codsex_sexo," +
                             "admregadmision.sia_edaano_usua," +
                             "admregadmision.sia_edames_usua," +
                             "admregadmision.sia_edadia_usua," +
                             "admregadmision.sia_edaymd_usua," +
                             "admregadmision.sia_tipusu_regi," +
                             "admregadmision.adm_pacemb_rgad," +
                             "fcmmaedetallfac.fcm_codser_mant," +
                             "fcmmaedetallfac.fcm_coddig_mant," +
                             "fcmmaedetallfac.fcm_desser_dfac," +
                             "fcmmaedetallfac.fcm_fecser_dfac," +
                             "fcmmaedetallfac.sia_codrip_trip," +
                             "fcmmaedetallfac.fcm_horser_dfac," +
                             "fcmmaedetallfac.sia_tipact_tsac," +
                             "fcmmaedetallfac.sia_codfpr_fpor," +
                             "fcmmaedetallfac.sia_codfco_fcon," +
                             "fcmmaedetallfac.adm_codcex_tcex," +
                             "fcmmaedetallfac.sia_coddia_tdia," +
                             "fcmmaedetallfac.sia_tipdxp_tdix," +
                             "fcmmaedetallfac.sia_coddx1_tdia," +
                             "fcmmaedetallfac.sia_coddx2_tdia," +
                             "fcmmaedetallfac.sia_coddx3_tdia," +
                             "fcmmaedetallfac.sia_coddxc_tdia," +
                             "fcmmaedetallfac.fcm_otserv_sips " +
                       "FROM " +
                         "fcmmaedetallfac " +
                                   "INNER JOIN siausuarioatend ON (fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                   "INNER JOIN admregadmision ON (fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                       "WHERE " + tcrFiltro + "(fcmmaedetallfac.fcm_estfac_mfac = '2') " + tcrOrderBy;
            #endregion

            return lcrLineaSqlSelct;
        }
        #endregion
        // Funciones auxiliares para limpieza de marcas en temporales de gestion
        #region fcvCargHclLimpiarMarcaTodosLosGrupos: Limpiar los datos o marcas en temporales
        /// <summary>
        /// <para>Limpiar datos o marcas en temporales de gestion todos los grupos</para>
        /// </summary>
        public void fcvCargHclLimpiarMarcaTodosLosGrupos()
        {
            // Limpiar los grupos
            foreach (var loReg in tmpListGrupoActividad)
            {
                loReg.Ssp_TotValrips_sspa = 0;
                loReg.Ssp_TotVal4505_sspa = 0;
                loReg.Estado = "NA";
            }
            // Limpiar todos detalles de grupos
            foreach (var loReg in tmpListGrupoDetalles)
            {
                loReg.Estado = "NA";
                loReg.IdUnicoRegistro = "NA";
            }
        }
        #endregion
        #region fcvCargHclLimpiarMarcaActividadesUnGrupo: Limpiar los datos o marcas temporal de un grupo
        /// <summary>
        /// <para>Limpiar los datos o marcas temporal de un grupo</para>
        /// </summary>
        public void fcvCargHclLimpiarMarcaActividadesUnGrupo(ref List<ModeloSpactivservfactMD> tmpRegGrupo)
        {
            // Limpiar todos detalles de grupos
            foreach (var loReg in tmpRegGrupo)
            {
                loReg.Estado = "NA";
                loReg.IdUnicoRegistro = "NA";
            }
        }
        #endregion
        #region fcvCargHclLimpiarMarcaIdGrupoServFact: Limpiar los registros marcados de un grupo
        /// <summary>
        /// <para>Quitar marcas de una actividad en cada registro Facturado Rips usando la llave unica referenciada</para>
        /// </summary>
        public void fcvCargHclLimpiarMarcaIdGrupoServFact(String tcrIdGrupo)
        {
            var tmpGrupoAct = flsCargHclSelectDetalleGrupo(tcrIdGrupo);
            // Limpiar los grupos
            foreach (var loReg in tmpGrupoAct)
            {
                if (loReg.IdUnicoRegistro != "NA")
                {
                    tmpDetallesFact.FirstOrDefault(x => x.Fcm_secreg_dfac.Equals(loReg.IdUnicoRegistro)).Modificado = "NO";
                }
                loReg.Estado = "NA";
                loReg.IdUnicoRegistro = "NA";
            }
        }
        #endregion
        #region fcvCargHclLimpiarMarcaVar4505TodosGrupos: Limpiar marcas en temporal variables 4505 grupos
        /// <summary>
        /// <para>Limpiar marcas de gestion en todo el temporal variables 4505 grupos actividades</para>
        /// </summary>
        public void fcvCargHclLimpiarMarcaVar4505TodosGrupos()
        {
            // Limpiar Variables los grupos
            foreach (var loReg in tmpListActivMedicVar)
            {
                loReg.Estado = "NA";
            }
        }
        #endregion
        #region fcvCargHclMarcarVariable4505deGrupo: Poner marca de gestion en una variable 4505 de un grupo
        /// <summary>
        /// <para>Poner marca de gestion en una variable 4505 de un grupo, el parametro tcrMarca puede contener "NA"/"SI"</para>
        /// <para>esta funcion marca todos los registros de la variable en el Grupo Actividad</para>
        /// </summary>
        public void fcvCargHclMarcarVariable4505deGrupo(String tcrGrupoActivida, String tcrCampo4505, String tcrMarca)
        {
            // Limpiar Variables los grupos
            foreach (var loReg in tmpListActivMedicVar)
            {
                if (loReg.Ssp_codpro_sspa == tcrGrupoActivida && loReg.Ssp_codcam_resc.ToLower() == tcrCampo4505.ToLower())
                {
                    loReg.Estado = tcrMarca;
                }
            }
        }
        #endregion
        //---------------------------------------------------------------
        // COMANDOS 
        //---------------------------------------------------------------
        // Comandos para gestion datos desde formatos HC
        #region flgComandoActualizValorDesdePlant: Gestion comandos desde Historicos de plantillas
        /// <summary>
        /// <para>Gestion comandos desde Historicos de plantillas</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrDatoValor: Dato a registrar en la variable correspondiente a 4505</para>
        /// <para>tcrNumeroCampo4505: Numero del campo o variable 4505 desde valor cero hasta 119: "0","1","2"..."118"</para>
        /// <para>tcrCodigoGrupoActividad: "01"=Vacunación/"02"=Salud oral/"03"=Parto...</para>
        /// <para>tcrNombreCampo4505: SSP_CAM090_MS45/ SSP_CAM023_MS45/ SSP_CAM076_MS45...</para>
        /// </summary>
        public bool flgComandoActualizValorDesdePlant(String tcrDatoValor, String tcrNumeroCampo4505,
                                                      String tcrCodigoGrupoActividad, String tcrNombreCampo4505, String tcrLineaComando)
        {
            var llgReturn = false;
            var lcrEncontrado = false;
            String[] larArray = (tcrLineaComando).Split("*".ToCharArray());
            var lcrComando    = larArray[0].Trim();
            int lnuTotElemtos = larArray.Length;
            var lcrValorVar   = String.Empty;
            var i = 0;

            // Comando Actualizar Diagnosticos  ACT-DIAG Ejemplo: "ACT-DIAG*21*2*E660*E661*E662*E668*E669"
            #region Comando ACT-DIAG
            if (lcrComando == "ACT-DIAG")
            {
                lcrValorVar = larArray[2].Trim(); // el valor que se va a reemplazar si se ecuentra el Diagnostico

                for (i = 3; i < lnuTotElemtos; i++)
                {
                    if (tcrDatoValor.ToUpper() == larArray[i].Trim().ToUpper())
                    {
                        lcrEncontrado = true;
                        break;
                    }
                }
                if (lcrEncontrado == true)
                {
                    llgReturn = flgCargHclRegistroActualizValorEnVariables(lcrValorVar, tcrNumeroCampo4505, tcrCodigoGrupoActividad, tcrNombreCampo4505);
                }
            }
            #endregion

            return llgReturn;
        }
        #endregion
        //- Comandos de Gestion 
        #region flgComandoGestion_GES_HCLFEX: Comando para agregar registro en temporal referencias eventos hc y fechas
        /// <summary>
        /// <para>Comando para agregar un registro de gestion en temporal de referencias a eventos medicos de historia clinica y fecha de busqueda</para>
        /// <para>Ejemplo: GES-HCLFEX*30*180*RESULT-LAB-CITOLOGIA:</para>
        /// <para>30 => Dias para busqueda en futuro (cuando es cero no se busca)</para>
        /// <para>180 => Dias que debe retroceder en la busqueda antes del inicio periodo corte (cuando es cero no se busca)</para>
        /// <para>RESULT-LAB-CITOLOGIA => Actividad medica o formato donde se debe buscar el dato</para>
        /// </summary>
        public bool flgComandoGestion_GES_HCLFEX(ModeloSpactivservfactMD tobRegAct, FcmModeloServDetallFacturas tobRegServ, String tcrLineaComando)
        {
            #region Validar un servicio
            var llgReturn = true;

            String[] larArray = (tcrLineaComando).Split("*".ToCharArray());
            tobRegServ.Hcl_codreg_hcca = larArray[3].Trim(); // la llave de la actividad medica ejemplo: "RESULT-LAB-CITOLOGIA"

            // comprobar que no esta registrada la actividad para el mismo paciente
            var lobReg = tmpDetallAdmEvenAux.FirstOrDefault(x => x.Sia_idesec_usua == tobRegServ.Sia_idesec_usua && 
                                                                 x.Hcl_codreg_hcca == tobRegServ.Hcl_codreg_hcca);
            if (lobReg == null) // Cuando no existe se agrega
            {
                var ldaFechaInicio      = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecini_peri.Text);
                var ldaFechaFinal       = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecfin_peri.Text);
                var lnuDiasDespuPeriodo = Convert.ToInt32(larArray[1]);                         // dias dados para buscar en fechas superiores a fecha fin periodo
                var lnuDiasAntesPeriodo = Convert.ToInt32(larArray[2]);                         // dias dados para buscar en fechas anteriores al periodo
                var ldaFechaLimSuperior = ldaFechaFinal.AddDays(lnuDiasDespuPeriodo);
                var ldaFechaLimInferior = ldaFechaInicio.AddDays(-lnuDiasAntesPeriodo);

                var lobRegistro = fobCargHclRegNuevoServAdmFact(tobRegAct, tobRegServ);

                lobRegistro.FechaInicioPeriodo = ldaFechaLimInferior;
                lobRegistro.FechaFinalPeriodo = ldaFechaLimSuperior;

                tmpDetallAdmEvenAux.Add(lobRegistro);
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgComandoGestion_GES_HCLAP: Comando para agregar registro en temporal referencias eventos hc
        /// <summary>
        /// <para>Comando para agregar un registro de gestion en temporal de referencias a eventos medicos de historia clinica</para>
        /// <para>Ejemplo: GES-HCLAP*RESULT-LAB-GLICEMIA-AD-MAYOR</para>
        /// </summary>
        public bool flgComandoGestion_GES_HCLAP(ModeloSpactivservfactMD tobRegAct, FcmModeloServDetallFacturas tobRegServ, String tcrLineaComando)
        {
            #region Validar un servicio
            var llgReturn = true;

            String[] larArray = (tcrLineaComando).Split("*".ToCharArray());
            tobRegServ.Hcl_codreg_hcca = larArray[1].Trim();

            tmpDetallAdmEvenAux.Add(fobCargHclRegNuevoServAdmFact(tobRegAct, tobRegServ));
            #endregion

            return llgReturn;
        }
        #endregion
        #region fobComandoGestion_GES_ADD: Comando gestion ADD
        /// <summary>
        /// <para>Comando gestion ADD para buscar un servicio fuera del periodo y agregarlo a servicios facturados </para>
        /// <para> Ejemplo: "GES-ADD*CE025*10*180" ==> /C0025=Codigo Digitacion Servicio a buscar</para>
        /// <para>10=Dias superiores al perioda en que se debe buscar//180=Dias que debe retroceder en la busqueda inferior al periodo</para>
        /// <para>------------------</para>
        /// <para>El registro encontrado se agrega al temporal de facturación: tmpDetallFactAdd</para>
        /// </summary>
        public bool flgComandoGestion_GES_ADD(ref  ModeloGrupoActividadesMA tobRegGrupo, String tcrIdUnicoUsuario, String tcrLineaComando)
        {
            bool llgReturn = false;

            var larRegServ = tcrLineaComando.Split("*".ToCharArray()); // Separa la expresion "GES-ADD*CE025*180"
            var lcrCodigoDigitacion = larRegServ[1].Trim();

            #region Validar un servicio
            var lobRegfac = tmpDetallesFact.FirstOrDefault(x => x.Fcm_coddig_mant == lcrCodigoDigitacion);
            if (lobRegfac == null)
            {
                var lobRegActiServ2 = tmpDetallGrupoActivo.FirstOrDefault(x => x.Fcm_coddig_mant == lcrCodigoDigitacion);
                if (lobRegActiServ2 != null) // Debe  estar en el grupo de actividad
                {
                    var lobRegserv2 = fobComandoGestion_GES_ADD_AUX(tcrIdUnicoUsuario, tcrLineaComando, "*");
                    if (lobRegserv2 != null)
                    {
                        if (tmpDetallFactAdd == null) { tmpDetallFactAdd = new List<FcmModeloServDetallFacturas>(); }
                        tmpDetallFactAdd.Add(lobRegserv2);

                        // Para el nuevo registro se ejecuta la validacion normal para ver si clasifica
                        llgReturn = flgCargHclRegistrarServicioDetalleGrupo(ref  tobRegGrupo, ref lobRegActiServ2, ref lobRegserv2);
                    }
                }
            }
            #endregion

            return llgReturn;
        }
        #endregion
        #region fobComandoGestion_GES_ADD_AUX: Comando auxiliar para gestion ADD, busca el registro
        /// <summary>
        /// <para>Buscar un servicio fuera del periodo y devolver un registro tipo servicios facturados FcmModeloServDetallFacturas</para>
        /// <para>Ejemplo: "GES-ADD*CE025*10*180" </para>
        /// <para>Devuelve valor nulo cuando no se encuentra</para>
        /// </summary>
        public FcmModeloServDetallFacturas fobComandoGestion_GES_ADD_AUX(String tcrIdUsuario, String tcrLineaComando, String tcrSeparador)
        {
            String[] larArray = (tcrLineaComando).Split(tcrSeparador.ToCharArray());

            #region Validar un servicio
            var ldaFechaInicio      = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecini_peri.Text);
            var ldaFechaFinal       = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecfin_peri.Text);
            var lcrCodigoDigitacion = larArray[1].Trim();
            var lnuDiasDespuPeriodo = Convert.ToInt32(larArray[2]); // dias dados para buscar en fechas superiores a fecha fin periodo
            var lnuDiasAntesPeriodo = Convert.ToInt32(larArray[3]); // dias dados para buscar en fechas anteriores al periodo
            var lcrFechaLimSuperior = Funciones.fcrConvertFecha(ldaFechaFinal.AddDays(lnuDiasDespuPeriodo));
            var lcrFechaLimInferior = Funciones.fcrConvertFecha(ldaFechaInicio.AddDays(-lnuDiasAntesPeriodo));

            var lobRegserv = fobRegServicioFactIdUsuarioFecha(tcrIdUsuario, lcrCodigoDigitacion,
                                                               lcrFechaLimInferior, lcrFechaLimSuperior);
            #endregion

            return lobRegserv;
        }
        #endregion
        #region fcrComandoGestion_GES_VALID: Comando gestion VALID
        /// <summary>
        /// <para>Comando gestion VALID para realizar validaciones y devolver un comando de actualizacion "ACT-VALOR"</para>
        /// <para>Ejemplo: "GES-VALID*58*CE025*5*180*1*2" ==> // 58=La Variable 4505 a actualizar//C0025=Codigo Digitacion Servicio a buscar</para>
        /// <para>5=Dias para busqueda superior al periodo // 180=Dias que debe retroceder en la busqueda inferior al periodo</para>
        /// <para>1=Valor a actualizar si lo encuentra // 2=Valor si no encuentra</para>
        /// </summary>
        public String fcrComandoGestion_GES_VALID(String tcrIdUsuario, String tcrLineaComando, String tcrSeparador)
        {
            var lcrReturn = String.Empty;
            String[] larArray = (tcrLineaComando).Split(tcrSeparador.ToCharArray());

            #region Validar un servicio
            var ldaFechaInicio      = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecini_peri.Text);
            var ldaFechaFinal       = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecfin_peri.Text);
            var lcrCodigoDigitacion = larArray[2].Trim();
            var lnuDiasDespuPeriodo = Convert.ToInt32(larArray[3]); // dias dados para buscar en fechas superiores a fecha fin periodo
            var lnuDiasAntesPeriodo = Convert.ToInt32(larArray[4]); // dias dados para buscar en fechas anteriores al periodo
            var lcrFechaLimSuperior = Funciones.fcrConvertFecha(ldaFechaFinal.AddDays(lnuDiasDespuPeriodo));
            var lcrFechaLimInferior = Funciones.fcrConvertFecha(ldaFechaInicio.AddDays(-lnuDiasAntesPeriodo));
            var lcrDatoFecha        = String.Empty;

            var lobRegserv2 = fobRegServicioFactIdUsuarioFecha(tcrIdUsuario, lcrCodigoDigitacion,
                                                               lcrFechaLimInferior, lcrFechaLimSuperior);

            // Ejemplo: "GES-VALID*58*CE025*0*180*1*2" -- > CT-VALOR*58*1
            var lcrVariable = "ACT-VALOR" + tcrSeparador + larArray[1].Trim(); // la variable 
            var lcrValorSi = larArray[5].Trim(); // Valor salida si lo encuentra
            var lcrValorNo = larArray[6].Trim(); // Valor salida no lo encuentra

            if (lobRegserv2 != null)
            {
                
                if (lcrValorSi == "FECHA")
                {
                    //lcrDatoFecha = Funciones.fcrFechaTextoCambiarFormato("DMY","/",Funciones.fcrConvertFecha(lobRegserv2.Fcm_fecser_dfac),"YMD","-");
                    lcrDatoFecha = Funciones.fcrConvertFecha(lobRegserv2.Fcm_fecser_dfac);
                    lcrReturn = lcrVariable + tcrSeparador + lcrDatoFecha;
                }
                else
                {
                    lcrReturn = lcrVariable + tcrSeparador + lcrValorSi;
                }
            }
            else
            {
                 lcrReturn = lcrValorNo != "NA" ? lcrVariable + tcrSeparador + lcrValorNo : String.Empty;
            }

            #endregion

            return lcrReturn;
        }
        #endregion
        //- Actualizar valores
        #region flgComandoActaulizarValores: Gestion actualizar valores 4505 en registro activo
        /// <summary>
        /// <para>Gestion actualizar valores 4505 en registro activo</para>
        /// </summary>
        public bool flgComandoActualizarValores(ModeloSpactivservfactMD tobRegAct)
        {
            var llgReturn = false;

            // Cargar los datos
            #region Cargar los datos
            if (tobRegAct.Ssp_parmet_ssfc != null)
            {
                if (tobRegAct.Ssp_parmet_ssfc != "NA" && tobRegAct.Estado == "SI")
                {
                    //var lcrCodigoDigitacion = tobRegAct.Fcm_coddig_mant;
                    var lcrIdUnicoRegFacturado = tobRegAct.IdUnicoRegistro;

                    #region Son varios comandos
                    String[] larArray = (tobRegAct.Ssp_parmet_ssfc).Split(";".ToCharArray()); // Separar los comandos contenidos en parametro

                    if (larArray.Length > 0) // esta correcta la expresion (hay comandos)
                    {
                        int lnuTotElemtos = larArray.Length;
                        var i = 0;

                        for (i = 0; i < lnuTotElemtos; i++)
                        {
                            llgReturn = true;

                            flgComandoActualizarValores(lcrIdUnicoRegFacturado, larArray[i].Trim(), "*");
                        }
                    }
                    #endregion
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgComandoActualizarValores: Gestion basica de comandos de actualizacion de datos 4505
        /// <summary>
        /// <para>Gestion basica comandos (ACT-FECHA y ACT-VALOR) para actualizacion de datos 4505</para>
        /// </summary>
        public bool flgComandoActualizarValores(String tcrIdUnicoRegFacturado, String tcrLineaComando, String tcrSeparador)
        {
            var llgReturn = false;
            String[] larArray = (tcrLineaComando).Split(tcrSeparador.ToCharArray());

            //var lobRegServ = tmpDetallesFact.FirstOrDefault(x => x.Fcm_coddig_mant == tcrCodigoDigitacion);
            var lobRegServ = tmpDetallesFact.FirstOrDefault(x => x.Fcm_secreg_dfac == tcrIdUnicoRegFacturado);
            if (larArray.Length > 1 && lobRegServ != null)
            {
                var lcrComando = larArray[0].Trim();
                // ACT-FECHA;80
                if (lcrComando == "ACT-FECHA")
                {
                    var lcrFecha = Funciones.fcrConvertFecha(lobRegServ.Fcm_fecser_dfac);
                    flgComandoActualizar_ACT_FECHA(larArray[1].Trim(), lcrFecha);
                }

                // ACT-VALOR;54;1
                if (lcrComando == "ACT-VALOR")
                {
                    flgComandoActualizar_ACT_VALOR(larArray[1].Trim(), larArray[2].Trim());
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgComandoActualizar_ACT_FECHA: Actualiza un valor fecha en una variable 4505
        /// <summary>
        /// <para>Actualiza un valor fecha en una variable 4505 </para>
        /// </summary>
        public bool flgComandoActualizar_ACT_FECHA(String tcrNumeroCampo4505, String tcrValorDato)
        {
            var llgReturn = false;
            llgReturn = flgActualizarDatonRegistroActivo(tcrNumeroCampo4505, tcrValorDato, "DMY", "/");
            return llgReturn;
        }
        #endregion
        #region flgComandoActualizar_ACT_VALOR: Actualiza un valor en una variable 4505 desde un servicio facturado
        /// <summary>
        /// <para>Actualiza un valor en una variable 4505 desde un servicio facturado</para>
        /// <para>Ejemplo: ACT-VALOR*14*1</para>
        /// </summary>
        public bool flgComandoActualizar_ACT_VALOR(String tcrNumeroCampo4505, String tcrValorDato)
        {
            var llgReturn = false;
            llgReturn = flgActualizarDatonRegistroActivo(tcrNumeroCampo4505, tcrValorDato, "DMY", "/");
            return llgReturn;
        }
        #endregion
        //-------------------------------
        #region flgGenerarDatosEmbarazadasPartos: Generar datos desde adimision y atencion parto
        /// <summary>
        /// <para>Generar datos desde maestro adimision y atencion parto</para>
        /// </summary>
        public int flgGenerarDatosEmbarazadasPartos(String tcrFechaIni, String tcrFechaFin, int tnuContador)
        {
            var lcrContador         = tnuContador;
            var lcrIdArchivo        = oApp.gcrAppBdatosArchvioGuardarDatos;
            var lcrDatoValor        = String.Empty;
            var lcrNumeroCampo      = String.Empty;
            var lcrIdUnicoUsuario   = String.Empty;
            var lcrCodigoAdmision   = String.Empty;

            // hclregisextxa: Consulta historicos  
            #region Consulta historicos archivo textos
            var tmpHclRegistros = ModeloHclAcciones.flsSQLDataTableDatosAdmision(vm.G1Sia_codeps_teps, tcrFechaIni, tcrFechaFin);

            // Cargar los datos
            foreach (DataRow lobReg in tmpHclRegistros.Rows)
            {
                tmpRegGestion = lobReg;

                lcrIdUnicoUsuario = lobReg["Sia_idesec_usua"].ToString().ToUpper().Trim();
                lcrCodigoAdmision = lobReg["Adm_secadm_rgad"].ToString().ToUpper().Trim();

                // aqui buscar datos del paciente / sino existe generar datos
                lcrContador = fnuGenRegistroActivoRE4505("08",lcrIdUnicoUsuario, lcrCodigoAdmision, lcrContador);
                fcvCargarCampoDatosComplementarios(lcrIdUnicoUsuario, lcrCodigoAdmision);

                // Parches
                //fcvParcheCorreccionesGenerales();
            }
            #endregion

            return lcrContador;
        }
        #endregion
        #region flgGenerarDatosDesdeHistorisClinicas: Completar datos desde historicos
        /// <summary>
        /// <para>Completar datos que ya fueron generados, trayendo valores desde historicos y segun plantillas hc</para>
        /// </summary>
        public int fcvGenerarDatosDesdeHistorisClinicas(String tcrArchivo, String tcrFechaIni, String tcrFechaFin, int tnuContador)
        {
            var lcrContador         = tnuContador;
            var lcrIdArchivo        = oApp.gcrAppBdatosArchvioGuardarDatos;
            var lcrCodVersionPlant  = "XXX";
            var lcrDatoValor        = String.Empty;
            var lcrNumeroCampo      = String.Empty;
            var lcrIdUnicoUsuario   = String.Empty;
            var lcrCodigoAdmision   = String.Empty;
            List<ModeloSptabcamposplan> tmCamposArch = null;

            // hclregisextxa: Consulta historicos  
            #region Consulta historicos archivo textos
            if (flsSiCamposHclinicaArchivo4505(tcrArchivo) && vm.TmpG2ListaBrow.Count > 0)
            {
                var tmpHclRegistros = ModeloHclAcciones.flsSQLDataTableHistoricos4505(vm.G1Sia_codeps_teps, tcrFechaIni, tcrFechaFin, tcrArchivo + lcrIdArchivo);

                // Cargar los datos
                foreach (DataRow lobReg in tmpHclRegistros.Rows)
                {
                    tmpRegGestion = lobReg;

                    lcrIdUnicoUsuario = lobReg["Sia_idesec_usua"].ToString().ToUpper().Trim();
                    lcrCodigoAdmision = lobReg["Adm_secadm_rgad"].ToString().ToUpper().Trim();

                    if (lobReg["Grp_idepla_grpv"].ToString().ToUpper().Trim() != lcrCodVersionPlant)
                    {
                        lcrCodVersionPlant = lobReg["Grp_idepla_grpv"].ToString().ToUpper().Trim();
                        tmCamposArch = flsCamposVersionPlantillaHC4505(tcrArchivo, lcrCodVersionPlant);
                    }
                    if (tmCamposArch != null)
                    {
                        // aqui buscar datos del paciente / sino existe generar datos
                        /*
                        lcrContador = fnuGenRegistroActivoRE4505(lcrIdUnicoUsuario, lcrCodigoAdmision, lcrContador);
                        fcvCargarCampoDatosComplementarios(lcrIdUnicoUsuario, lcrCodigoAdmision);
                        */
                        tmpRegActMS4505 = vm.TmpG2ListaBrow.FirstOrDefault(x => x.Sia_idesec_usua == lcrIdUnicoUsuario);

                        #region llenar datos desde HC
                        if (tmpRegActMS4505 != null)
                        {

                            foreach (var lobCampo in tmCamposArch)
                            {
                                //  tomar el posible valor
                                if (lobCampo.Ssp_tipval_resc.Trim() == "D")
                                {
                                    lcrDatoValor = lobReg[lobCampo.Hcl_nomcam_hccm.Trim()].ToString().Trim();

                                    lcrDatoValor = !String.IsNullOrWhiteSpace(lcrDatoValor) ? lcrDatoValor.Substring(0, 10) : String.Empty;
                                }
                                else
                                {
                                    lcrDatoValor = lobReg[lobCampo.Hcl_nomcam_hccm.Trim()].ToString().ToUpper().Trim();
                                }
                                lcrNumeroCampo = lobCampo.Ssp_ordvis_resc.ToString().Trim();

                                if (!String.IsNullOrWhiteSpace(lcrDatoValor))
                                {
                                    flgCargarCampoRegistroMS4505_R029(lcrNumeroCampo, lcrDatoValor, "YMD", "-");
                                    flgCargarCampoRegistroMS4505_R3059(lcrNumeroCampo, lcrDatoValor, "YMD", "-");
                                    flgCargarCampoRegistroMS4505_R6089(lcrNumeroCampo, lcrDatoValor, "YMD", "-");
                                    flgCargarCampoRegistroMS4505_R90118(lcrNumeroCampo, lcrDatoValor, "YMD", "-");
                                }
                            }
                        }
                        #endregion

                    }
                    // Parches
                    //fcvParcheCorreccionesGenerales();
                }
            }
            #endregion

            return lcrContador;
        }
        #endregion
        #region flsSiCamposHclinicaArchivo4505: Para saber si el archivo tiene campos 4505
        /// <summary>
        /// <para>Para saber si el archivo tiene campos 4505</para>
        /// </summary>
        public bool flsSiCamposHclinicaArchivo4505(String tcrArchivo)
        {
            List<ModeloSptabcamposplan> lcrQuery = null;

            lcrQuery = (from lst in tmpCamposHC4505
                                where lst.Hcl_nomarc_hccm.Equals(tcrArchivo.ToUpper())
                                orderby lst.Hcl_nomcam_hccm
                                        select lst).ToList();

            return lcrQuery != null ? true : false;

        }
        #endregion
        #region flsCamposVersionPlantillaHC4505: Seleccionar campos plantillas
        /// <summary>
        /// <para>Seleccionar campos version plantillas</para>
        /// </summary>
        public List<ModeloSptabcamposplan> flsCamposVersionPlantillaHC4505(String tcrArchivo, String tcrVesionPlantilla)
        {
            List<ModeloSptabcamposplan> lcrQuery = null;

            lcrQuery = (from lst in tmpCamposHC4505
                        where lst.Hcl_nomarc_hccm == tcrArchivo.ToUpper() && 
                              lst.Grp_idepla_grpv == tcrVesionPlantilla
                        orderby lst.Hcl_nomcam_hccm
                        select lst).ToList();
            return lcrQuery;
        }
        #endregion
        #region fnuGenRegistroActivoRE4505: Consultar registro maestro temporal
        /// <summary>
        /// <para>Consultar registro en maestro temporal cuando no existe el paciente generar registro por defecto</para>
        /// </summary>
        public int fnuGenRegistroActivoRE4505(String tcrIdGrupoActividad, String tcrIdUnicoEnSistemas, String tcrAdmision, int tnuContador)
        {
            var lnuContador = tnuContador;
            tmpRegActMS4505 = null;
            ModeloSspNsRes4505Ex lobReg4505 = null;

            if (vm.TmpG2ListaBrow.Count > 0)
            {
                lobReg4505 = vm.TmpG2ListaBrow.FirstOrDefault(x => x.Sia_idesec_usua == tcrIdUnicoEnSistemas);
            }
            // Iniciar el registro
            if (lobReg4505 == null)
            {
                // Agregar registro por defecto
                lnuContador++;
                var tmpRegAdmision = ADMModeloAdmadmisiones.flsListaAdmregadmision(tcrAdmision).FirstOrDefault();

                if (tmpRegAdmision != null) // ojo --------------- quitar esto
                {
                    lobReg4505 = ModeloSspNsRes4505Ex.flsAddRegistrodefault(tcrIdGrupoActividad, tmpRegAdmision.Sia_edadia_usua, tmpRegAdmision.Sis_codsex_sexo);
                    if (lobReg4505 != null)
                    {
                        tmpRegActMS4505Dfl = ModeloSspNsRes4505Ex.flsAddRegistrodefault(lobReg4505.Ssp_idesec_spvd);

                        lobReg4505.Estado = "INCLUIDO";
                        lobReg4505.Ssp_idesec_ns45 = "R" + lnuContador.ToString().Trim();
                        lobReg4505.Ssp_ideaux_ns45 = lnuContador;
                        lobReg4505.Ssp_codper_peri = this.txtG1Ssp_codper_peri.Text;
                        lobReg4505.Ssp_mesper_peri = Funciones.fcrElementoFecha("MES", "DMY", "/", this.txtG1Ssp_fecfin_peri.Text);
                        lobReg4505.Ssp_anoper_peri = Funciones.fcrElementoFecha("AÑO", "DMY", "/", this.txtG1Ssp_fecfin_peri.Text);
                        lobReg4505.Sia_codeps_teps = this.txtG1Sia_codeps_carg.Text;

                        lobReg4505.Sia_idesec_usua = tmpRegAdmision.Sia_idesec_usua;
                        lobReg4505.Sia_nroide_usua = tmpRegAdmision.Sia_nroide_usua;
                        lobReg4505.Sia_codeps_teps = tmpRegAdmision.Sia_codeps_teps;
                        lobReg4505.Ssp_cam000_ms45 = "2";
                        lobReg4505.Ssp_cam002_ms45 = ModeloSpconfigura4505.fcrBuscarIpsSpconfigura4505();
                        lobReg4505.Ssp_cam003_ms45 = tmpRegAdmision.Sia_tipide_tide;
                        lobReg4505.Ssp_cam004_ms45 = tmpRegAdmision.Sia_nroide_usua;
                        lobReg4505.Ssp_cam005_ms45 = tmpRegAdmision.Sia_priape_usua;
                        lobReg4505.Ssp_cam006_ms45 = !String.IsNullOrWhiteSpace(tmpRegAdmision.Sia_segape_usua) ? tmpRegAdmision.Sia_segape_usua : "NONE";
                        lobReg4505.Ssp_cam007_ms45 = tmpRegAdmision.Sia_prinom_usua;
                        lobReg4505.Ssp_cam008_ms45 = !String.IsNullOrWhiteSpace(tmpRegAdmision.Sia_segnom_usua) ? tmpRegAdmision.Sia_segnom_usua : "NONE"; 
                        lobReg4505.Ssp_cam009_ms45 = Funciones.fcrConvertFecha(tmpRegAdmision.Sia_fecnac_usua);
                        lobReg4505.Ssp_cam010_ms45 = tmpRegAdmision.Sis_codsex_sexo;
                        //lobReg4505.Ssp_cam011_ms45 = tmpRegAdmision.Ssp_cam011_ms45;
                        lobReg4505.Ssp_cam011_ms45 = tmpRegAdmision.Sia_codper_pret;
                        lobReg4505.Ssp_codocu_ciuo = tmpRegAdmision.Sis_codocu_ocup != null ? tmpRegAdmision.Sis_codocu_ocup : "9999";
                        lobReg4505.Sia_edaano_usua = tmpRegAdmision.Sia_edaano_usua;
                        lobReg4505.Sia_edames_usua = tmpRegAdmision.Sia_edames_usua;
                        lobReg4505.Sia_edadia_usua = tmpRegAdmision.Sia_edadia_usua;
                        lobReg4505.Sia_edaymd_usua = tmpRegAdmision.Sia_edaymd_usua;
                        lobReg4505.Sia_nomusu_usua = fcrGenRegistroUnirNombrePaciente(tmpRegAdmision.Sia_priape_usua, tmpRegAdmision.Sia_segape_usua,
                                                                                      tmpRegAdmision.Sia_prinom_usua,tmpRegAdmision.Sia_segnom_usua);

                        vm.TmpG2ListaBrow.Add(lobReg4505);
                    }
                }
            }
            tmpRegActMS4505 = lobReg4505; // la referencia para 
            return lnuContador;
        }
        #endregion
        #region fcrGenRegistroUnirNombrePaciente: Concatenar nombre del paciente
        /// <summary>
        /// Concatenar nombre del paciente
        /// </summary>
        public String fcrGenRegistroUnirNombrePaciente(String tcrPApellido, String tcrSApellido, String tcrPNombre, String tcrSNombre)
        {
            var lcrPApe = tcrPApellido.Trim().ToUpper();
            var lcrSApe = tcrSApellido != "NONE" && !String.IsNullOrWhiteSpace(tcrSApellido) ? " " + tcrSApellido.Trim().ToUpper() : String.Empty;
            var lcrPnom = " " + tcrPNombre.Trim().ToUpper();
            var lcrSnom = tcrSNombre != "NONE" && !String.IsNullOrWhiteSpace(tcrSNombre) ? " " + tcrSNombre.Trim().ToUpper() : String.Empty;

            var lcrNombre = lcrPApe + lcrSApe + lcrPnom + lcrSnom;

            return lcrNombre;
        }
        #endregion
        #region fnuGenRegistroCompararValorDefault: Comparar registro generado con valores por defecto
        /// <summary>
        /// <para>Comparar registro generado con valores por defecto</para>
        /// </summary>
        public bool flgGenRegistroCompararValorDefault()
        {
            var llgReturn = false;
            //tmpRegActMS4505 = 
            //tmpRegActMS4505Dfl
            return llgReturn;
        }
        #endregion
        // Complemento de datos en variables 4505
        #region fcvCargarCampoDatosComplementarios: Cargar campos complementarios desde tablas
        /// <summary>
        /// <para>Cargar datos complementarios desde tablas de historias clinicas</para>
        /// </summary>
        public void fcvCargarCampoDatosComplementarios(String tcrIdUnicoSistema, String tcrCodigoAdmision)
        {
            if (tmpRegActMS4505 != null)
            {
                // Variable 14 Embarazada SI/NO
                //fcvDatosComplementarios_Embarazo(tcrIdUnicoSistema, tcrCodigoAdmision);
            }
        }
        // Complementar Variables
        #region fcvDatosComplementarios_Embarazo: Cargar campos complementarios Embarazo
        /// <summary>
        /// <para>Cargar datos complementarios relacionados con el embarazo</para>
        /// </summary>
        public void fcvDatosComplementarios_Embarazo(String tcrIdUnicoSistema, String tcrCodigoAdmision)
        {
            var lcrTipoAtencion = String.Empty;
            var lcrEmbarazada   = String.Empty;
            var lcrCodigoTriage = String.Empty;
            var lcrFechaParto   = String.Empty;
            var lcrFechaSalida  = String.Empty;
            var lcrFechAdmision = String.Empty;

            // Variable 14 Embarazada SI/NO
            #region Variable 14 Embarazada SI/NO
            lcrTipoAtencion = tmpRegGestion["sia_regate_rgat"] != null ? tmpRegGestion["sia_regate_rgat"].ToString().Trim() : "2";
            lcrEmbarazada   = tmpRegGestion["adm_pacemb_rgad"] != null ? tmpRegGestion["adm_pacemb_rgad"].ToString().Trim() : String.Empty;
            lcrCodigoTriage = tmpRegGestion["adm_nroreg_tria"] != null ? tmpRegGestion["adm_nroreg_tria"].ToString().Trim() : String.Empty;

            var lcrIdUsuario = tmpRegGestion["sia_nroide_usua"] != null ? tmpRegGestion["sia_nroide_usua"].ToString().Trim() : String.Empty;

            if (lcrEmbarazada == "1") // Hay embarazo
            {
                tmpRegActMS4505.Ssp_cam014_ms45 = lcrEmbarazada;
                //tmpRegActMS4505.Ssp_cam033_ms45 = "01/01/1800";
                //tmpRegActMS4505.Ssp_cam029_ms45 = "01/01/1800";
                //tmpRegActMS4505.Ssp_cam031_ms45 = "01/01/1800";

                lcrFechAdmision = Funciones.fcrCorregirFechaTexto(tmpRegGestion["adm_fecadm_rgad"].ToString().Substring(0,10));

                // fecha probable de parto 
                var lobRegPrt = HCLValidarCodigo.fobRegBuscarHclregisexfec01Pl(tcrCodigoAdmision, "PL0X000029"); // mejorar o quitar ---ojo
                if (lobRegPrt != null)
                {
                    tmpRegActMS4505.Ssp_cam033_ms45 = lobRegPrt.hcl_fec002_hcfc.Trim();
                }
                // Peso y talla (Hcl_txt020_hctx Hcl_txt021_hctx) desde archivo texto plantilla PL0X000029
                var lobRegPeso = HCLValidarCodigo.fobRegBuscarhclregisextxa01Pl(tcrCodigoAdmision, "PL0X000029"); // mejorar o quitar ---ojo
                if (lobRegPeso != null)
                {
                    tmpRegActMS4505.Ssp_cam029_ms45 = lcrFechAdmision;
                    tmpRegActMS4505.Ssp_cam030_ms45 = lobRegPeso.hcl_txt020_hctx.Trim();
                    tmpRegActMS4505.Ssp_cam031_ms45 = lcrFechAdmision;
                    tmpRegActMS4505.Ssp_cam032_ms45 = lobRegPeso.hcl_txt021_hctx.Trim();
                }

                // Verificar si es admitido y si hubo atencion del parto
                if (lcrTipoAtencion == "1") // 1 es admitido
                {
                    #region admitidos
                    var lobReg = ADMValidarCodigo.fobRegBuscarAdmregistegresoAdm(tcrCodigoAdmision);
                    if (lobReg != null)
                    {
                        if (lobReg.adm_aparto_regr == "1") // Hubo atencion del parto
                        {
                            lcrFechaParto = Funciones.fcrConvertFecha((DateTime)lobReg.adm_fecpar_regr);
                            lcrFechaSalida = Funciones.fcrConvertFecha((DateTime)lobReg.adm_fecegr_regr);

                            tmpRegActMS4505.Ssp_cam049_ms45 = lcrFechaParto;
                            tmpRegActMS4505.Ssp_cam050_ms45 = lcrFechaSalida;
                        }
                    }
                    // Datos desde el triage
                    var lobRegTr = ADMValidarCodigo.fobRegBuscarAdmtriagemaestr(lcrCodigoTriage);
                    if (lobRegTr != null)
                    {
                        // Fecha de peso y  Valor peso
                        tmpRegActMS4505.Ssp_cam029_ms45 = lcrFechAdmision;
                        tmpRegActMS4505.Ssp_cam030_ms45 = ((int)lobRegTr.adm_pesokg_tria).ToString();

                        // Fecha de talla y  Valor talla
                        tmpRegActMS4505.Ssp_cam031_ms45 = lcrFechAdmision;
                        tmpRegActMS4505.Ssp_cam032_ms45 = ((int)lobRegTr.adm_tallac_tria).ToString();
                    }
                    #endregion
                }
                else
                {
                    #region ambulatoria
                    #endregion
                }
            }
            #endregion
        }
        #endregion
        #endregion
        // Importar datos archivos planos externos
        #region fcvAccAbrirArchivoPlano: abrir archivos planos
        private void fcvAccAbrirArchivoPlano(object sender, RoutedEventArgs e)
        {
            fcvBrowserSeleccionPeriodo();
            if (gcrCtrF2TexBox == "OK")
            {
                gcrTipoCargueDatos = "CARGUE";

                if (flgDialogoBuscarArchivo("Buscar Archivo plano...", "Buscar archivo plano |*.txt", ".txt"))
                {
                    DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Cargando archivo plano de datos...", "CENTRO");
                    lobDlgAdd.Show();

                    glgObjetosCargados = false;
                    vm.glgSIS_DatosVerificados = false;
                    this.objDataGrid.ItemsSource = null;
                    fcvFiltroDataGridQuitarValores();
                    gcrOrigenDatosCargados = "PLANO";

                    vm.TmpG2ListaBrow = new System.Collections.ObjectModel.ObservableCollection<ModeloSspNsRes4505Ex>();
                    flgCargarDesdeArchivoPlano();
                    flgFiltroDataGridDatos();
                   
                    glgObjetosCargados = true;
                    lobDlgAdd.Close();
                }
            }
        }
        #endregion
        //Importar desde base de datos
        #region fcvAccAbrirNovedadesBdatos: abrir datos desde novedades en base de datos
        private void fcvAccAbrirNovedadesBdatos(object sender, RoutedEventArgs e)
        {
            fcvBrowserSeleccionPeriodo();
            if (gcrCtrF2TexBox == "OK")
            {
                gcrTipoCargueDatos = "CARGUE";

                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cargando vista desde base de datos...", "CENTRO");
                lobDlgAdd.Show();

                glgObjetosCargados = false;
                vm.glgSIS_DatosVerificados = false;
                this.objDataGrid.ItemsSource = null;
                fcvFiltroDataGridQuitarValores();
                gcrOrigenDatosCargados = "BDATOS";

                vm.TmpG2ListaBrow = new ObservableCollection<ModeloSspNsRes4505Ex>
                                                   (ModeloSspNsRes4505Ex.flsListaSptablnsres4505Periodo(this.txtG1Ssp_codper_peri.Text, this.txtG1Sia_codeps_teps.Text));
                this.txtG1Ssp_rutarc_carg.Text = "ORIGEN DESDE BASE DE DATOS";
                this.txtG1ArchivoOrigen.Text   = "DATOS BASE DE DATOS";
                this.txtG1RegistroControl.Text = "BASE DE DATOS";
                this.txtG1Sia_codeps_carg.Text = this.txtG1Sia_codeps_teps.Text;
                this.txtG1Ssp_fecini_carg.Text = this.txtG1Ssp_fecini_peri.Text;
                this.txtG1Ssp_fecfin_carg.Text = this.txtG1Ssp_fecfin_peri.Text;
                this.txtG1Ssp_totreg_carg.Text = vm.TmpG2ListaBrow.Count().ToString();

                flgFiltroDataGridDatos();

                glgObjetosCargados = true;
                lobDlgAdd.Close();
            }
        }
        #endregion
        // Importar datos desde archivos Microsoft Excel 
        #region fcvAccAbrirArchivoExcel: abrir archivos planos
        private void fcvAccAbrirArchivoExcel(object sender, RoutedEventArgs e)
        {
            fcvBrowserSeleccionPeriodo();
            if (gcrCtrF2TexBox == "OK")
            {
                gcrTipoCargueDatos = "CARGUE";

                if (flgDialogoBuscarArchivo("Buscar Archivo Microsoft Excel...", "Buscar archivo Microsoft Excel |*.xls; *.xlsx; *.xlsm; *.xlsb", ".xlsx"))
                {
                    DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Cargando archivo de Microsoft Excel...", "CENTRO");
                    lobDlgAdd.Show();

                    glgObjetosCargados = false;
                    this.objDataGrid.ItemsSource = null;
                    vm.glgSIS_DatosVerificados = false;
                    fcvFiltroDataGridQuitarValores();
                    gcrOrigenDatosCargados = "EXCEL";

                    vm.TmpG2ListaBrow = new System.Collections.ObjectModel.ObservableCollection<ModeloSspNsRes4505Ex>();
                    flgCargarDesdeArchivoExcel(gcrArchivoExternoNombreyRuta);
                    flgFiltroDataGridDatos();

                    glgObjetosCargados = true;
                    lobDlgAdd.Close();

                }
            }
        }
        #endregion
        #region flgDialogoBuscarArchivo: Dialogo Buscar archivo a cargar
        /// <summary>
        /// <para>Dialogo Buscar archivo a cargar</para>
        /// </summary>
        public bool flgDialogoBuscarArchivo(String tcrTitulo, String tcrFiltro, String tcrDflExtension)
        {
            var llgReturn = false;
            OpenFileDialog lopenFileDialog = new OpenFileDialog();
            lopenFileDialog.Title       = tcrTitulo;
            lopenFileDialog.Filter      = tcrFiltro;
            lopenFileDialog.DefaultExt  = tcrDflExtension; // Extencion de archivos
            lopenFileDialog.FilterIndex = 1;
            lopenFileDialog.Multiselect = false;

            bool? llgSelectOK = lopenFileDialog.ShowDialog();

            if (llgSelectOK == true)
            {
                gcrArchivoExternoNombreyRuta = lopenFileDialog.FileName;
                gcrArchivoExternoNombre      = lopenFileDialog.SafeFileName;
                gcrArchivoExternoRuta        = gcrArchivoExternoNombreyRuta.Substring(0,gcrArchivoExternoNombreyRuta.Length - gcrArchivoExternoNombre.Length);
                this.txtG1Ssp_rutarc_carg.Text = gcrArchivoExternoRuta;
                this.txtG1ArchivoOrigen.Text = gcrArchivoExternoNombre;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region flgCargarDesdeArchivoPlano: Cargar vista de datos desde archivos planos
        /// <summary>
        /// <para>Cargar vista de datos desde archivos planos</para>
        /// </summary>
        public bool flgCargarDesdeArchivoPlano()
        {
            var llgReturn = false;
            StreamReader lobjReader = new StreamReader(gcrArchivoExternoNombreyRuta, Encoding.Default);
            String lcrRegistroLinea = String.Empty;
            int tnuContadorRegistros = 0;
            int tnuContadorRegTipo2 = 0;
            this.txtG1RegistroControl.Text = String.Empty;

            while (lcrRegistroLinea != null)
            {
                tnuContadorRegistros++;

                lcrRegistroLinea = lobjReader.ReadLine();
                if (lcrRegistroLinea != null)
                {
                    if (lcrRegistroLinea.Length < 50 && tnuContadorRegistros == 1)
                    {
                        //- registro de control tipo 1
                        flgRegistroControlDesdeArray(lcrRegistroLinea.Trim());
                    }
                    else
                    {
                        // registros tipo 2
                        tnuContadorRegTipo2++;
                        flgGenerarRegistroDesdeArray(lcrRegistroLinea, tnuContadorRegTipo2);
                        llgReturn = true;
                    }
                }
            }
            this.txtG1Ssp_totreg_carg.Text = tnuContadorRegTipo2.ToString();
            this.txtG1Ssp_forfec_sscf.Text = "YMD";

            lobjReader.Close();
            return llgReturn;
        }
        #endregion
        #region flgRegistroControlDesdeArray: Cargar vista registro control desde array
        /// <summary>
        /// <para>Cargar vista registro control desde array</para>
        /// </summary>
        public bool flgRegistroControlDesdeArray(String tcrRegistroLinea)
        {
            var llgReturn = false;

            char[] lcrCharSeparador = ("|").ToCharArray();
            string[] larArray = tcrRegistroLinea.Split(lcrCharSeparador);

            this.txtG1RegistroControl.Text = tcrRegistroLinea.Trim();
            this.txtG1Sia_codeps_carg.Text = larArray[1];
            this.txtG1Ssp_fecini_carg.Text = larArray[2];
            this.txtG1Ssp_fecfin_carg.Text = larArray[3];

            return llgReturn;
        }
        #endregion
        #region flgGenerarRegistroDesdeArray: Cargar vista de datos desde array
        /// <summary>
        /// <para>Cargar vista de datos desde desde array</para>
        /// </summary>
        public bool flgGenerarRegistroDesdeArray(String tcrRegistroLinea, int tnuNumeroRegistro)
        {
            var llgReturn = false;

            char[] lcrCharSeparador = ("|").ToCharArray();
            string[] larArray = tcrRegistroLinea.Split(lcrCharSeparador);
            int i = 0;
            String lcrCampo = String.Empty;
            String lcrllave1 = String.Empty;
            String lcrllave2 = String.Empty;
            String lcrllave3 = String.Empty;
            String lcrllave4 = String.Empty;
            String lcrllave5 = String.Empty;
            String lcrllave6 = String.Empty;

            if (larArray.Length > 50)
            {
                tmpRegActMS4505 = new ModeloSspNsRes4505Ex();
                tmpRegActMS4505.Estado = "INCLUIDO";
                tmpRegActMS4505.Ssp_ideaux_ns45 = tnuNumeroRegistro;
                tmpRegActMS4505.Ssp_codper_peri = this.txtG1Ssp_codper_peri.Text;
                tmpRegActMS4505.Ssp_mesper_peri = Funciones.fcrElementoFecha("MES","DMY","/",this.txtG1Ssp_fecfin_peri.Text);
                tmpRegActMS4505.Ssp_anoper_peri = Funciones.fcrElementoFecha("AÑO", "DMY", "/", this.txtG1Ssp_fecfin_peri.Text);
                tmpRegActMS4505.Sia_codeps_teps = this.txtG1Sia_codeps_carg.Text;

                for (i = 0; i < larArray.Length; i++)
                {
                    lcrCampo = i.ToString().Trim();

                    llgReturn = flgCargarCampoRegistroMS4505_R029(lcrCampo, larArray[i],"YMD","-");
                    if (!llgReturn)
                    {
                        llgReturn = flgCargarCampoRegistroMS4505_R3059(lcrCampo, larArray[i], "YMD", "-");
                    }
                    if (!llgReturn)
                    {
                        llgReturn = flgCargarCampoRegistroMS4505_R6089(lcrCampo, larArray[i], "YMD", "-");
                    }
                    if (!llgReturn)
                    {
                        llgReturn = flgCargarCampoRegistroMS4505_R90118(lcrCampo, larArray[i], "YMD", "-");
                    }
                }
                if (llgReturn == true)
                {
                    tmpRegActMS4505.Sia_nroide_usua = tmpRegActMS4505.Ssp_cam004_ms45;

                    lcrllave1 = tmpRegActMS4505.Ssp_ideaux_ns45.ToString().Trim() + " ";
                    lcrllave2 = tmpRegActMS4505.Ssp_cam004_ms45 != null ? tmpRegActMS4505.Ssp_cam004_ms45.ToUpper() + " " : String.Empty;
                    lcrllave3 = tmpRegActMS4505.Ssp_cam005_ms45 != null ? tmpRegActMS4505.Ssp_cam005_ms45.ToUpper() + " " : String.Empty;
                    lcrllave4 = tmpRegActMS4505.Ssp_cam006_ms45 != null ? tmpRegActMS4505.Ssp_cam006_ms45.ToUpper() + " " : String.Empty;
                    lcrllave5 = tmpRegActMS4505.Ssp_cam007_ms45 != null ? tmpRegActMS4505.Ssp_cam007_ms45.ToUpper() + " " : String.Empty;
                    lcrllave6 = tmpRegActMS4505.Ssp_cam008_ms45 != null ? tmpRegActMS4505.Ssp_cam008_ms45.ToUpper() : String.Empty;

                    tmpRegActMS4505.LlaveBusqueda = lcrllave1 + lcrllave2 + lcrllave3 + lcrllave4 + lcrllave5 + lcrllave6;

                    vm.TmpG2ListaBrow.Add(tmpRegActMS4505);
                }
            }
            return llgReturn;
        }
        #endregion
        // Resolucion 4505 Rangos 0-29,30-59,60-89,90-118
        #region flgCargarCampoRegistroMS4505_R029: Registro Resolucion 4505 Rango 0 a 29
        /// <summary>
        /// <para>Registro Resolucion 4505 Rango 0 a 29</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumeroCampo: Nombre o Numero del campo en Resolucion 4505</para>
        /// <para>tcrValor: valor a cargar en campo Resolucion 4505</para>
        /// </summary>
        public bool flgCargarCampoRegistroMS4505_R029(String tcrNumeroCampo, String tcrValor, String tcrFormatoFecha, String tcrSeparadorFecha)
        {
            var llgReturn = false;
            var lcrValor1 = String.Empty;

            #region Campos desde 0 a 29
            if (tmpRegActMS4505 != null && !String.IsNullOrWhiteSpace(tcrValor))
            {
                switch (tcrNumeroCampo)
                {
                    case "SIA_IDESEC_USUA":
                        llgReturn = true;
                        tmpRegActMS4505.Sia_idesec_usua = tcrValor;
                        break;

                    case "SIA_NROIDE_USUA":
                        llgReturn = true;
                        tmpRegActMS4505.Sia_nroide_usua = tcrValor;
                        break;

                    case "SIA_CODEPS_TEPS":
                        llgReturn = true;
                        tmpRegActMS4505.Sia_codeps_teps = tcrValor;
                        break;

                    case "0":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam000_ms45 = tcrValor;
                        break;

                    case "1":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam001_ms45 = tcrValor;
                        break;

                    case "2":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam002_ms45 = tcrValor;
                        break;

                    case "3":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam003_ms45 = tcrValor;
                        break;

                    case "4":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam004_ms45 = tcrValor;
                        break;

                    case "5":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam005_ms45 = tcrValor;
                        break;

                    case "6":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam006_ms45 = tcrValor;
                        break;

                    case "7":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam007_ms45 = tcrValor;
                        break;

                    case "8":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam008_ms45 = tcrValor;
                        break;

                    case "9":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam009_ms45 = tcrValor;
                        break;

                    case "10":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam010_ms45 = tcrValor;
                        break;

                    case "11":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam011_ms45 = tcrValor;
                        break;

                    case "12":

                        #region codigo CIUO - Codigo segun clasificacion internacional de ocupaciones
                        llgReturn = true;
                        if (gcrTipoCargueDatos == "CARGUE")
                        {
                            tmpRegActMS4505.Ssp_codocu_ciuo = tcrValor;
                        }
                        else
                        { 
                            // se esta generando desde H clinica
                            tmpRegActMS4505.Ssp_codocu_ciuo = tcrValor;
                        }
                        break;
                        #endregion

                    case "13":

                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam013_ms45 = tcrValor;
                        break;

                    case "14":

                        #region Gestacion si o no 
                        llgReturn = true;
                        if (gcrTipoCargueDatos == "CARGUE")
                        {
                            tmpRegActMS4505.Ssp_cam014_ms45 = tcrValor;
                        }
                        else
                        {
                            // se esta generando desde H clinica
                            //lcrValor1 = tmpRegGestion["adm_pacemb_rgad"] != null ? tmpRegGestion["adm_pacemb_rgad"].ToString().Trim() : tcrValor;
                            tmpRegActMS4505.Ssp_cam014_ms45 = lcrValor1 == "1" ? lcrValor1 : tcrValor;
                        }
                        break;
                        #endregion

                    case "15":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam015_ms45 = tcrValor;
                        break;

                    case "16":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam016_ms45 = tcrValor;
                        break;

                    case "17":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam017_ms45 = tcrValor;
                        break;

                    case "18":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam018_ms45 = tcrValor;
                        break;

                    case "19":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam019_ms45 = tcrValor;
                        break;

                    case "20":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam020_ms45 = tcrValor;
                        break;

                    case "21":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam021_ms45 = tcrValor;
                        break;

                    case "22":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam022_ms45 = tcrValor;
                        break;

                    case "23":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam023_ms45 = tcrValor;
                        break;

                    case "24":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam024_ms45 = tcrValor;
                        break;

                    case "25":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam025_ms45 = tcrValor;
                        break;

                    case "26":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam026_ms45 = tcrValor;
                        break;

                    case "27":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam027_ms45 = tcrValor;
                        break;

                    case "28":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam028_ms45 = tcrValor;
                        break;

                    case "29":
                        #region Fecha peso
                        llgReturn = true;
                        if (gcrTipoCargueDatos == "CARGUE")
                        {
                            tmpRegActMS4505.Ssp_cam029_ms45 = tmpRegActMS4505.Ssp_cam029_ms45 == "1800-01-01" ? tcrValor : tmpRegActMS4505.Ssp_cam029_ms45;
                        }
                        else
                        {
                            tmpRegActMS4505.Ssp_cam029_ms45 = tmpRegActMS4505.Ssp_cam029_ms45 == "01/01/1800" ? tcrValor : tmpRegActMS4505.Ssp_cam029_ms45;
                        }
                        break;
                        #endregion

                }
            }
            #endregion
            flgCargarCampoRegistroActualListModi(tcrNumeroCampo, llgReturn);

            return llgReturn;
        }
        #endregion
        #region flgCargarCampoRegistroMS4505_R3059: Registro Resolucion 4505 Rango 30 a 59
        /// <summary>
        /// <para>Registro Resolucion 4505 Rango 30 a 59</para>
        /// <para>tcrNumeroCampo: Nombre o Numero del campo en Resolucion 4505</para>
        /// <para>tcrValor: valor a cargar en campo Resolucion 4505</para>
        /// </summary>
        public bool flgCargarCampoRegistroMS4505_R3059(String tcrNumeroCampo, String tcrValor, String tcrFormatoFecha, String tcrSeparadorFecha)
        {
            var llgReturn = false;
            var lcrValor1 = String.Empty;

            #region Campos desde 30 a 59
            if (tmpRegActMS4505 != null && !String.IsNullOrWhiteSpace(tcrValor))
            {
                switch (tcrNumeroCampo)
                {
                    case "30":
                        #region Peso en Kilogramos
                        llgReturn = true;
                        if (gcrTipoCargueDatos == "CARGUE")
                        {
                            tmpRegActMS4505.Ssp_cam030_ms45 = tcrValor;
                        }
                        else
                        {
                            // Reemplazar separador decimal para convertir en numero
                            tcrValor     = Funciones.fcrRemplazarChrDecimal(tcrValor);
                            var lnuValor = (int)Convert.ToDecimal(tcrValor);
                            tcrValor     = lnuValor > 0 ? lnuValor.ToString() : tcrValor;  // no quitar decimal para valores menores A UN KILOGRAMO (ejm: 0.89)

                            tcrValor = Funciones.fcrRemplazarChrDecimal(tcrValor,"."); // Poner el punto que es el que dice la norma

                            // se esta generando desde H clinica
                            tmpRegActMS4505.Ssp_cam030_ms45 = tmpRegActMS4505.Ssp_cam030_ms45 == "999" ? tcrValor : tmpRegActMS4505.Ssp_cam030_ms45;
                            // Revisar valor de la variable 29
                            if (tmpRegActMS4505.Ssp_cam030_ms45 != "999")
                            {
                                var lcrFecha29 = tmpRegGestion["hcl_gesfec_hcev"].ToString();
                                lcrFecha29 = lcrFecha29.Length > 10 ? lcrFecha29.Substring(0, 10) : lcrFecha29;

                                tmpRegActMS4505.Ssp_cam029_ms45 = Funciones.fcrCorregirFechaTexto(lcrFecha29);
                            }
                        }
                        break;
                        #endregion

                    case "31":
                        #region Fecha talla
                        llgReturn = true;
                        if (gcrTipoCargueDatos == "CARGUE")
                        {
                            tmpRegActMS4505.Ssp_cam031_ms45 = tmpRegActMS4505.Ssp_cam031_ms45 == "1800-01-01" ? tcrValor : tmpRegActMS4505.Ssp_cam031_ms45;
                        }
                        else
                        {
                            tmpRegActMS4505.Ssp_cam031_ms45 = tmpRegActMS4505.Ssp_cam031_ms45 == "01/01/1800" ? tcrValor : tmpRegActMS4505.Ssp_cam031_ms45;
                        }
                        break;
                        #endregion

                    case "32":
                        #region Talla en centimetros
                        llgReturn = true;
                        if (gcrTipoCargueDatos == "CARGUE")
                        {
                            tmpRegActMS4505.Ssp_cam032_ms45 = tcrValor;
                        }
                        else
                        {
                            // se esta generando desde H clinica
                            tmpRegActMS4505.Ssp_cam032_ms45 = tmpRegActMS4505.Ssp_cam032_ms45 == "999" ? tcrValor : tmpRegActMS4505.Ssp_cam032_ms45;
                            // Revisar valor de la variable 31 
                            if (tmpRegActMS4505.Ssp_cam032_ms45 != "999")
                            {
                                var lcrFecha31 = tmpRegGestion["hcl_gesfec_hcev"].ToString();
                                lcrFecha31 = lcrFecha31.Length > 10 ? lcrFecha31.Substring(0, 10) : lcrFecha31;

                                tmpRegActMS4505.Ssp_cam031_ms45 = Funciones.fcrCorregirFechaTexto(lcrFecha31);
                            }

                        }
                        break;
                        #endregion

                    case "33":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam033_ms45 = tcrValor;
                        break;

                    case "34":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam034_ms45 = tcrValor;
                        break;

                    case "35":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam035_ms45 = tcrValor;
                        break;

                    case "36":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam036_ms45 = tcrValor;
                        break;

                    case "37":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam037_ms45 = tcrValor;
                        break;

                    case "38":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam038_ms45 = tcrValor;
                        break;

                    case "39":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam039_ms45 = tcrValor;
                        break;

                    case "40":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam040_ms45 = tcrValor;
                        break;

                    case "41":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam041_ms45 = tcrValor;
                        break;

                    case "42":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam042_ms45 = tcrValor;
                        break;

                    case "43":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam043_ms45 = tcrValor;
                        break;

                    case "44":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam044_ms45 = tcrValor;
                        break;

                    case "45":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam045_ms45 = tcrValor;
                        break;

                    case "46":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam046_ms45 = tcrValor;
                        break;

                    case "47":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam047_ms45 = tcrValor;
                        break;

                    case "48":
                        llgReturn = true;
                        #region control placa bacteriana
                        tmpRegActMS4505.Ssp_cam048_ms45 = tcrValor;
                        if (tmpRegActMS4505.Sia_edadia_usua < 720)
                        {
                            tmpRegActMS4505.Ssp_cam048_ms45 = "0";
                        }
                        #endregion
                        break;

                    case "49":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam049_ms45 = tcrValor;
                        break;

                    case "50":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam050_ms45 = tcrValor;
                        break;

                    case "51":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam051_ms45 = tcrValor;
                        break;

                    case "52":
                        llgReturn = true;
                        #region Control Recien Nacido
                        tmpRegActMS4505.Ssp_cam052_ms45 = tcrValor;
                        // persona mayor a 30 dias
                        if (tmpRegActMS4505.Sia_edadia_usua >= 30)
                        {
                            tmpRegActMS4505.Ssp_cam052_ms45 = tmpRegActMS4505.Ssp_cam052_ms45 != "01/01/1845" ? "01/01/1845" : tcrValor;
                        }
                        #endregion
                        break;

                    case "53":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam053_ms45 = tcrValor;
                        break;

                    case "54":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam054_ms45 = tcrValor;
                        break;

                    case "55":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam055_ms45 = tcrValor;
                        break;
                    case "56":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam056_ms45 = tcrValor;
                        break;

                    case "57":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam057_ms45 = tcrValor;
                        break;

                    case "58":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam058_ms45 = tcrValor;
                        break;

                    case "59":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam059_ms45 = tcrValor;
                        break;
                }
            }
            #endregion
            flgCargarCampoRegistroActualListModi(tcrNumeroCampo, llgReturn);

            return llgReturn;
        }
        #endregion
        #region flgCargarCampoRegistroMS4505_R6089: Registro Resolucion 4505 Rango 60 a 89
        /// <summary>
        /// <para>Registro Resolucion 4505 Rango 60 a 89</para>
        /// <para>tcrNumeroCampo: Nombre o Numero del campo en Resolucion 4505</para>
        /// <para>tcrValor: valor a cargar en campo Resolucion 4505</para>
        /// </summary>
        public bool flgCargarCampoRegistroMS4505_R6089(String tcrNumeroCampo, String tcrValor, String tcrFormatoFecha, String tcrSeparadorFecha)
        {
            var llgReturn = false;
            #region Campos desde 60 a 89
            if (tmpRegActMS4505 != null && !String.IsNullOrWhiteSpace(tcrValor))
            {
                switch (tcrNumeroCampo)
                {
                    case "60":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam060_ms45 = tcrValor;
                        break;

                    case "61":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam061_ms45 = tcrValor;
                        break;

                    case "62":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam062_ms45 = tcrValor;
                        break;

                    case "63":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam063_ms45 = tcrValor;
                        break;

                    case "64":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam064_ms45 = tcrValor;
                        break;

                    case "65":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam065_ms45 = tcrValor;
                        break;

                    case "66":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam066_ms45 = tcrValor;
                        break;

                    case "67":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam067_ms45 = tcrValor;
                        break;

                    case "68":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam068_ms45 = tcrValor;
                        break;

                    case "69":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam069_ms45 = tcrValor;
                        break;

                    case "70":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam070_ms45 = tcrValor;
                        break;

                    case "71":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam071_ms45 = tcrValor;
                        break;

                    case "72":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam072_ms45 = tcrValor;
                        #region Consulta joven primera vez 
                        if (gcrTipoCargueDatos == "CARGUE")
                        {
                            tmpRegActMS4505.Ssp_cam072_ms45 = tmpRegActMS4505.Ssp_cam072_ms45 == "1800-01-01" ? tcrValor : tmpRegActMS4505.Ssp_cam072_ms45;
                        }
                        else
                        {
                            if (tmpRegActMS4505.Sia_edadia_usua >= 3600 && tmpRegActMS4505.Sia_edadia_usua < 10800)
                            {
                                tmpRegActMS4505.Ssp_cam072_ms45 = tmpRegActMS4505.Ssp_cam072_ms45 == "01/01/1845" ? "01/01/1800" : tmpRegActMS4505.Ssp_cam072_ms45;
                            }
                        }
                        #endregion
                        break;

                    case "73":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam073_ms45 = tcrValor;
                        if (tmpRegActMS4505.Sia_edadia_usua < 16200)
                        {
                            tmpRegActMS4505.Ssp_cam073_ms45 = "01/01/1845";
                        }
                        break;

                    case "74":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam074_ms45 = tcrValor;
                        break;

                    case "75":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam075_ms45 = tcrValor;
                        break;

                    case "76":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam076_ms45 = tcrValor;
                        break;

                    case "77":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam077_ms45 = tcrValor;
                        break;

                    case "78":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam078_ms45 = tcrValor;
                        break;

                    case "79":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam079_ms45 = tcrValor;
                        break;

                    case "80":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam080_ms45 = tcrValor;
                        break;

                    case "81":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam081_ms45 = tcrValor;
                        break;

                    case "82":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam082_ms45 = tcrValor;
                        break;

                    case "83":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam083_ms45 = tcrValor;
                        break;

                    case "84":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam084_ms45 = tcrValor;
                        break;

                    case "85":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam085_ms45 = tcrValor;
                        break;
                    case "86":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam086_ms45 = tcrValor;
                        break;

                    case "87":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam087_ms45 = tcrValor;
                        if (gcrTipoCargueDatos == "CARGUE")
                        {
                            tmpRegActMS4505.Ssp_cam087_ms45 = tmpRegActMS4505.Ssp_cam087_ms45 == "1800-01-01" ? tcrValor : tmpRegActMS4505.Ssp_cam087_ms45;
                        }
                        break;

                    case "88":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam088_ms45 = tcrValor;
                        #region Citología certico uterina
                        // Revisar valor de la variable 87
                        if (tmpRegActMS4505.Ssp_cam087_ms45.Trim() != "01/01/1845")
                        {
                            tmpRegActMS4505.Ssp_cam088_ms45 = tmpRegActMS4505.Ssp_cam088_ms45.Trim() == "0" ? "999" : tmpRegActMS4505.Ssp_cam088_ms45;
                        }
                        if (tmpRegActMS4505.Ssp_cam010_ms45 == "M")
                        {
                            tmpRegActMS4505.Ssp_cam087_ms45 = "01/01/1845";
                            tmpRegActMS4505.Ssp_cam088_ms45 = "0";
                        }
                        #endregion
                        break;

                    case "89":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam089_ms45 = tcrValor;
                        break;
                }
            }
            #endregion
            flgCargarCampoRegistroActualListModi(tcrNumeroCampo, llgReturn);

            return llgReturn;
        }
        #endregion
        #region flgCargarCampoRegistroMS4505_R90118: Registro Resolucion 4505 Rango 90 a 118
        /// <summary>
        /// <para>Registro Resolucion 4505 Rango 90 a 118</para>
        /// <para>tcrNumeroCampo: Nombre o Numero del campo en Resolucion 4505</para>
        /// <para>tcrValor: valor a cargar en campo Resolucion 4505</para>
        /// </summary>
        public bool flgCargarCampoRegistroMS4505_R90118(String tcrNumeroCampo, String tcrValor, String tcrFormatoFecha, String tcrSeparadorFecha)
        {
            var llgReturn = false;
            #region Campos desde 90 a 118
            if (tmpRegActMS4505 != null && !String.IsNullOrWhiteSpace(tcrValor))
            {
                switch (tcrNumeroCampo)
                {
                    case "90":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam090_ms45 = tcrValor;
                        break;

                    case "91":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam091_ms45 = tcrValor;
                        break;

                    case "92":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam092_ms45 = tcrValor;
                        break;

                    case "93":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam093_ms45 = tcrValor;
                        break;

                    case "94":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam094_ms45 = tcrValor;
                        break;

                    case "95":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam095_ms45 = tcrValor;
                        break;

                    case "96":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam096_ms45 = tcrValor;
                        break;

                    case "97":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam097_ms45 = tcrValor;
                        break;

                    case "98":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam098_ms45 = tcrValor;
                        break;

                    case "99":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam099_ms45 = tcrValor;
                        break;

                    case "100":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam100_ms45 = tcrValor;
                        break;

                    case "101":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam101_ms45 = tcrValor;
                        break;

                    case "102":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam102_ms45 = tcrValor;
                        break;

                    case "103":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam103_ms45 = tcrValor;
                        break;

                    case "104":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam104_ms45 = fcrCargarCampoRegistroGesDecimalLab(tcrValor);
                        break;

                    case "105":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam105_ms45 = tcrValor;
                        break;

                    case "106":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam106_ms45 = tcrValor;
                        break;

                    case "107":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam107_ms45 = fcrCargarCampoRegistroGesDecimalLab(tcrValor);
                        break;

                    case "108":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam108_ms45 = tcrValor;
                        break;

                    case "109":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam109_ms45 = fcrCargarCampoRegistroGesDecimalLab(tcrValor);
                        break;

                    case "110":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam110_ms45 = tcrValor;
                        break;

                    case "111":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam111_ms45 = tcrValor;
                        break;

                    case "112":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam112_ms45 = tcrValor;
                        break;

                    case "113":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam113_ms45 = tcrValor;
                        break;

                    case "114":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam114_ms45 = tcrValor;
                        break;

                    case "115":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam115_ms45 = tcrValor;
                        break;
                    case "116":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam116_ms45 = tcrValor;
                        break;

                    case "117":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam117_ms45 = tcrValor;
                        break;

                    case "118":
                        llgReturn = true;
                        tmpRegActMS4505.Ssp_cam118_ms45 = tcrValor;
                        break;
                }
            }
            #endregion
            flgCargarCampoRegistroActualListModi(tcrNumeroCampo, llgReturn);

            return llgReturn;
        }
        #endregion
        #region flgCargarCampoRegistroActualListModi: Actualizar lista de campos 4505 modificados para el registro
        /// <summary>
        /// <para>Actualizar lista de campos 4505 modificados para el registro</para>
        /// </summary>
        public bool flgCargarCampoRegistroActualListModi(String tcrNumeroCampo4505, bool tlgDatoActualizado)
        {
            var llgReturn = false;
            var lcrLista = tmpRegActMS4505.Ssp_VarMod_ms45;

            if (tlgDatoActualizado == true)
            {
                // buscar la variable 4505 modificada, en la lista del registro activo
                if (!Funciones.flgExisteElemento(tcrNumeroCampo4505, "-", lcrLista))
                {
                    llgReturn = true;
                    lcrLista = String.IsNullOrWhiteSpace(lcrLista) ? tcrNumeroCampo4505 : lcrLista + "-" + tcrNumeroCampo4505;

                    // organizar de nuevo la lista 
                    String[] larArray = (lcrLista).Split("-".ToCharArray());
                    Array.Sort(larArray); // organizar
                    int lnuTotElemtos = larArray.Length;
                    var i = 0;

                    // Recorrer todo el array para buscar la variable 4505 modificada
                    lcrLista = String.Empty;
                    for (i = 0; i < lnuTotElemtos; i++)
                    {
                        lcrLista = String.IsNullOrWhiteSpace(lcrLista) ? larArray[i].Trim() : lcrLista + "-" + larArray[i].Trim();
                    }
                    tmpRegActMS4505.Ssp_VarMod_ms45 = lcrLista;
                }
            }
            return llgReturn;
        }
        #endregion
        #region fcrCargarCampoRegistroGesDecimalLab: Quita o deja el componente decimal de un numero 
        /// <summary>
        /// <para>Quita o deja el componente decimal de un numero, cuando la parte decimal es cero la suprime</para>
        /// </summary>
        public String fcrCargarCampoRegistroGesDecimalLab(String tcrNumero)
        {
            // Reemplazar separador decimal
            tcrNumero           = Funciones.fcrRemplazarChrDecimal(tcrNumero);
            var lcrSeparador    = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
            var lcrValorReturn  = tcrNumero;

            #region Son varios comandos
            String[] larArray = (tcrNumero).Split(lcrSeparador.ToCharArray());

            if (larArray.Length > 1) // hay un componente decimal
            {
                lcrValorReturn = larArray[0].Trim();

                if (larArray[1].Trim() != "0")
                {
                    lcrValorReturn = larArray[0].Trim() + "." + larArray[1].Trim();
                }

            }
            #endregion

            return lcrValorReturn;
        }
        #endregion
        // Parches para corregir registros al generar datos desde Historicos
        #region fcvParcheAjusteProceso: Parche General de todos los registros generados
        /// <summary>
        /// <para>Parche General de todos los registros generados</para>
        /// </summary>
        public static void fcvParcheAjusteProceso()
        {
            foreach (var lobReg in vm.TmpG2ListaBrow)
            {
                tmpRegActMS4505 = lobReg;
                fcvParcheCorreccionesGenerales();
            }
        }
        #endregion
        #region fcvParcheCorreccionesGenerales: Parche General
        /// <summary>
        /// <para>Parche general correciones al generar datos desde historias clinicas</para>
        /// </summary>
        public static void fcvParcheCorreccionesGenerales()
        {
            fcvParcheAsteriscos();          // Corregir errores de asteriscos
            //fcvParcheNoAplicaGestacion();   // No aplica gestacion
            fcvParcheIMC();                 // IMC - Indice de masa corporal
            //fcvParcheMujerNoEmbarazada();   // Mujeres no embarazadas
            //fcvParcheCervicoUterino();      // Cervico Uterino
            //fcvParchePlacaBacteriana();     // placa bacteriana
            //fcvParcheSsp_cam052_ms45();     // control del recien nacido
            //fcvParcheSsp_cam072_ms45();     // Consulta joven de primera vez
            //fcvParcheSsp_cam073_ms45();     // Consulta adulto de primera vez
            //fcvParcheSsp_cam084_ms45();     // Fecha TSH Neonatal
        }
        #endregion
        #region fcvParcheAsteriscos: corrige error de asteriscos
        /// <summary>
        /// <para>corrige error de asteriscos</para>
        /// </summary>
        public static void fcvParcheAsteriscos()
        {
            // No aplica para estos usuarios
            if (tmpRegGestion != null && tmpRegActMS4505 != null)
            {
                tmpRegActMS4505.Ssp_cam014_ms45 = tmpRegActMS4505.Ssp_cam016_ms45.Trim() == "*" ? "21" : tmpRegActMS4505.Ssp_cam014_ms45;
                tmpRegActMS4505.Ssp_cam016_ms45 = tmpRegActMS4505.Ssp_cam016_ms45.Trim() == "*" ? "21" : tmpRegActMS4505.Ssp_cam016_ms45;
                tmpRegActMS4505.Ssp_cam023_ms45 = tmpRegActMS4505.Ssp_cam023_ms45.Trim() == "*" ? "21" : tmpRegActMS4505.Ssp_cam023_ms45;
                tmpRegActMS4505.Ssp_cam059_ms45 = tmpRegActMS4505.Ssp_cam059_ms45.Trim() == "*" ? "21" : tmpRegActMS4505.Ssp_cam059_ms45;
                tmpRegActMS4505.Ssp_cam060_ms45 = tmpRegActMS4505.Ssp_cam060_ms45.Trim() == "*" ? "21" : tmpRegActMS4505.Ssp_cam060_ms45;
                tmpRegActMS4505.Ssp_cam061_ms45 = tmpRegActMS4505.Ssp_cam061_ms45.Trim() == "*" ? "21" : tmpRegActMS4505.Ssp_cam061_ms45;
            }
        }
        #endregion        
        #region fcvParcheNoAplicaGestacion: Casos en los que no aplica gestacion
        /// <summary>
        /// <para>Casos en los que no aplica gestacion</para>
        /// </summary>
        public static void fcvParcheNoAplicaGestacion()
        {
            // No aplica para estos usuarios
            if (tmpRegGestion != null && tmpRegActMS4505 != null)
            {
                int lcrEdadEnDia = tmpRegGestion["sia_edadia_usua"] != null ? Convert.ToInt32(tmpRegGestion["sia_edadia_usua"].ToString()) : 0;
                if (lcrEdadEnDia < 3600 || tmpRegActMS4505.Ssp_cam010_ms45 == "M" || lcrEdadEnDia >= 21600)
                {
                    tmpRegActMS4505.Ssp_cam014_ms45 = "0";
                    tmpRegActMS4505.Ssp_cam033_ms45 = "01/01/1845";
                    tmpRegActMS4505.Ssp_cam049_ms45 = "01/01/1845";
                    tmpRegActMS4505.Ssp_cam050_ms45 = "01/01/1845";

                }
                if (lcrEdadEnDia >= 3600 && tmpRegActMS4505.Ssp_cam010_ms45 == "F" && lcrEdadEnDia < 21600)
                {
                    tmpRegActMS4505.Ssp_cam014_ms45 = tmpRegActMS4505.Ssp_cam014_ms45=="0"? "2": tmpRegActMS4505.Ssp_cam014_ms45;
                }
            }
        }
        #endregion
        #region fcvParcheIMC: Indice de masa corporal
        /// <summary>
        /// <para>Indice de masa corporal</para>
        /// </summary>
        public static void fcvParcheIMC()
        {
            // No aplica para estos usuarios
            if (tmpRegActMS4505 != null)
            {
                tmpRegActMS4505.Ssp_cam030_ms45 = tmpRegActMS4505.Ssp_cam030_ms45 == string.Empty ? "999" : tmpRegActMS4505.Ssp_cam030_ms45;
                tmpRegActMS4505.Ssp_cam032_ms45 = tmpRegActMS4505.Ssp_cam032_ms45 == string.Empty ? "999" : tmpRegActMS4505.Ssp_cam032_ms45;
                // Realizar calculo
                if (tmpRegActMS4505.Ssp_cam030_ms45 != "999" || tmpRegActMS4505.Ssp_cam032_ms45 != "999")
                {
                    //int lcrEdadEnAño = tmpRegGestion["sia_edaano_usua"] != null ? Convert.ToInt32(tmpRegGestion["sia_edaano_usua"].ToString()) : 0;
                    int lcrEdadEnAño = tmpRegActMS4505.Sia_edaano_usua;
                    //string id = tmpRegGestion["sia_nroide_usua"].ToString();
                    var lcrPeso  = Funciones.fcrRemplazarChrDecimal(tmpRegActMS4505.Ssp_cam030_ms45);
                    var lcrTalla = Funciones.fcrRemplazarChrDecimal(tmpRegActMS4505.Ssp_cam032_ms45);
                    var lnuPeso  = Convert.ToDouble(lcrPeso);
                    var lnuTalla = Convert.ToDouble(lcrTalla);
                    var lnuImc   = lnuPeso / ((lnuTalla / 100) * (lnuTalla / 100));

                    // Validar 
                    if (lnuImc >= 30 && lcrEdadEnAño >= 18)
                    {
                        tmpRegActMS4505.Ssp_cam021_ms45 = "1";
                    }
                    else if (lnuImc >= 18.5 && lnuImc < 30)
                    {
                        tmpRegActMS4505.Ssp_cam021_ms45 = "3";
                    }
                    else if (lnuImc < 18.5 && lcrEdadEnAño >= 18)
                    {
                        tmpRegActMS4505.Ssp_cam021_ms45 = "2";
                        tmpRegActMS4505.Ssp_cam064_ms45 = "01/01/1800";
                    }
                    else
                    {
                        tmpRegActMS4505.Ssp_cam021_ms45 = "21";
                    }
                }
                else
                {
                    tmpRegActMS4505.Ssp_cam021_ms45 = "21";
                }
            }
        }
        #endregion
        #region fcvParcheMujerNoEmbarazada: mujer no embarazada
        /// <summary>
        /// <para>Mujeres no embarazadas</para>
        /// </summary>
        public static void fcvParcheMujerNoEmbarazada()
        {
            // No aplica para estos usuarios
            if (tmpRegGestion != null && tmpRegActMS4505 != null)
            {
                int lcrEdadEnAño = tmpRegGestion["sia_edaano_usua"] != null ? Convert.ToInt32(tmpRegGestion["sia_edaano_usua"].ToString()) : 0;
                // Mujer no embarazada
                if (tmpRegActMS4505.Ssp_cam014_ms45 == "2" && tmpRegActMS4505.Ssp_cam010_ms45 == "F" && (lcrEdadEnAño >= 10 && lcrEdadEnAño < 60))
                {
                    tmpRegActMS4505.Ssp_cam033_ms45 = "01/01/1845";
                    tmpRegActMS4505.Ssp_cam049_ms45 = "01/01/1845";
                    tmpRegActMS4505.Ssp_cam050_ms45 = "01/01/1845";
                }
            }
        }
        #endregion
        #region fcvParcheCervicoUterino: Casos en los que no aplica citologia cervico uterina
        /// <summary>
        /// <para>Casos en los que no aplica citologia cervico uterina</para>
        /// </summary>
        public static void fcvParcheCervicoUterino()
        {
            // No aplica para estos usuarios
            if (tmpRegGestion != null && tmpRegActMS4505 != null)
            {
                int lcrEdadEnAño = tmpRegGestion["sia_edaano_usua"] != null ? Convert.ToInt32(tmpRegGestion["sia_edaano_usua"].ToString()) : 0;
                if (lcrEdadEnAño < 10 || tmpRegActMS4505.Ssp_cam010_ms45 == "M")
                {
                    tmpRegActMS4505.Ssp_cam087_ms45 = "01/01/1845";
                    tmpRegActMS4505.Ssp_cam088_ms45 = "0";
                }
                if (lcrEdadEnAño > 10 && tmpRegActMS4505.Ssp_cam010_ms45 == "F")
                {
                    tmpRegActMS4505.Ssp_cam087_ms45 = tmpRegActMS4505.Ssp_cam087_ms45 == "01/01/1845" ? "01/01/1800" : tmpRegActMS4505.Ssp_cam087_ms45;
                    tmpRegActMS4505.Ssp_cam088_ms45 = tmpRegActMS4505.Ssp_cam088_ms45 == "0" ? "999" : tmpRegActMS4505.Ssp_cam088_ms45;
                }
            }
        }
        #endregion
        #region fcvParchePlacaBacteriana: corrige error datos placa bacteriana
        /// <summary>
        /// <para>corrige error datos placa bacteriana</para>
        /// </summary>
        public static void fcvParchePlacaBacteriana()
        {
            // No aplica para estos usuarios
            if (tmpRegGestion != null && tmpRegActMS4505 != null)
            {
                int lcrEdadEnDias = tmpRegGestion["sia_edadia_usua"] != null ? Convert.ToInt32(tmpRegGestion["sia_edadia_usua"].ToString()) : 0;
                if (lcrEdadEnDias < 720)
                {
                    tmpRegActMS4505.Ssp_cam048_ms45 = "0";
                }
                if (lcrEdadEnDias >= 720 && tmpRegActMS4505.Ssp_cam048_ms45 == "0")
                {
                    tmpRegActMS4505.Ssp_cam048_ms45 = "22";
                }
            }
        }
        #endregion
        #region fcvParcheSsp_cam052_ms45: corrige error datos Control del recien nacido
        /// <summary>
        /// <para>Control del recien nacido</para>
        /// </summary>
        public static void fcvParcheSsp_cam052_ms45()
        {
            // No aplica para estos usuarios
            if (tmpRegGestion != null && tmpRegActMS4505 != null)
            {
                int lcrEdadEnDias = tmpRegGestion["sia_edadia_usua"] != null ? Convert.ToInt32(tmpRegGestion["sia_edadia_usua"].ToString()) : 0;
                if (lcrEdadEnDias > 30) // si es mayor de 30 dias
                {
                    tmpRegActMS4505.Ssp_cam052_ms45 = "01/01/1845";
                }
                if (lcrEdadEnDias <= 30) // si es menor de 30 dias
                {
                    tmpRegActMS4505.Ssp_cam052_ms45 = tmpRegActMS4505.Ssp_cam052_ms45 == "01/01/1845" ? "01/01/1800" : tmpRegActMS4505.Ssp_cam052_ms45;
                }
            }
        }
        #endregion
        #region fcvParcheSsp_cam072_ms45: corrige error datos Consulta joven de primera vez
        /// <summary>
        /// <para>Consulta joven de primera vez (entre 10 y 29 años)</para>
        /// </summary>
        public static void fcvParcheSsp_cam072_ms45()
        {
            // No aplica para estos usuarios
            if (tmpRegGestion != null && tmpRegActMS4505 != null)
            {
                int lcrEdadEnDias = tmpRegGestion["sia_edadia_usua"] != null ? Convert.ToInt32(tmpRegGestion["sia_edadia_usua"].ToString()) : 0;
                if (lcrEdadEnDias < 3600 || lcrEdadEnDias >= 10800) // si no es apto para la consulta
                {
                    tmpRegActMS4505.Ssp_cam072_ms45 = "01/01/1845";
                }
                if (lcrEdadEnDias >= 3600 && lcrEdadEnDias < 10800) // si es apto para la consulta
                {
                    tmpRegActMS4505.Ssp_cam072_ms45 = tmpRegActMS4505.Ssp_cam072_ms45 == "01/01/1845" ? "01/01/1800": tmpRegActMS4505.Ssp_cam072_ms45;
                }
            }
        }
        #endregion
        #region fcvParcheSsp_cam073_ms45: corrige error datos Consulta adulto de primera vez
        /// <summary>
        /// <para>Consulta adulto de primera vez (mayor de 45 años)</para>
        /// </summary>
        public static void fcvParcheSsp_cam073_ms45()
        {
            // No aplica para estos usuarios
            if (tmpRegGestion != null && tmpRegActMS4505 != null)
            {
                int lcrEdadEnDias = tmpRegGestion["sia_edadia_usua"] != null ? Convert.ToInt32(tmpRegGestion["sia_edadia_usua"].ToString()) : 0;
                if (lcrEdadEnDias < 16200) // si es menor de 45 años
                {
                    tmpRegActMS4505.Ssp_cam073_ms45 = "01/01/1845";
                }
                if (lcrEdadEnDias  >= 16200) // si es mayor o igual de 45 años
                {
                    tmpRegActMS4505.Ssp_cam073_ms45 = tmpRegActMS4505.Ssp_cam073_ms45 == "01/01/1845" ? "01/01/1800" : tmpRegActMS4505.Ssp_cam073_ms45;
                }
            }
        }
        #endregion
        #region fcvParcheSsp_cam084_ms45: corrige error datos Fecha TSH Neonatal
        /// <summary>
        /// <para>Fecha TSH Neonatal</para>
        /// </summary>
        public static void fcvParcheSsp_cam084_ms45()
        {
            // No aplica para estos usuarios
            if (tmpRegGestion != null && tmpRegActMS4505 != null)
            {
                int lcrEdadEnDias = tmpRegGestion["sia_edadia_usua"] != null ? Convert.ToInt32(tmpRegGestion["sia_edadia_usua"].ToString()) : 0;
                if (lcrEdadEnDias > 2) // si es mayor de 2 dias
                {
                    tmpRegActMS4505.Ssp_cam084_ms45 = "01/01/1845";
                }
                if (lcrEdadEnDias <= 2) // si es menor de 2 dias
                {
                    tmpRegActMS4505.Ssp_cam084_ms45 = tmpRegActMS4505.Ssp_cam084_ms45 == "01/01/1845" ? "01/01/1800" : tmpRegActMS4505.Ssp_cam084_ms45;
                }
            }
        }
        #endregion
        // Resolucion 4505 Cargar desde archivo de Microsoft Excel
        #region flgCargarDesdeArchivoExcel: Cargar registros desde Microsoft excel
        /// <summary>
        /// <para>Cargar registros desde Microsoft excel</para>
        /// </summary>
        private void flgCargarDesdeArchivoExcel(String tcrArchivo)
        {

            Excel.Application lobApp;
            Excel.Workbook lobWorkBook;
            Excel.Worksheet lobWorkSheet;
            Excel.Range lobRange;

            lobApp = new Excel.Application();
            var luxValue = Type.Missing;//System.Reflection.Missing.Value;

            // abrir el documento
            lobWorkBook = lobApp.Workbooks.Open(tcrArchivo, luxValue, luxValue,
                                                luxValue, luxValue, luxValue, luxValue, luxValue, luxValue,
                                                luxValue, luxValue, luxValue, luxValue, luxValue, luxValue);

            // seleccion de la hoja de calculo
            // get_item() devuelve object y numera las hojas a partir de 1
            lobWorkSheet = (Excel.Worksheet)lobWorkBook.Worksheets.get_Item(1);

            // seleccion hoja activa
            lobRange = lobWorkSheet.UsedRange;


            // leer las celdas
            int lnuTotalFilas = lobRange.Rows.Count;
            int lnutotalCols = lobRange.Columns.Count;
            int tnuContadorRegTipo2 = 0;
            String lcrllave1 = String.Empty;
            String lcrllave2 = String.Empty;
            String lcrllave3 = String.Empty;
            String lcrllave4 = String.Empty;
            String lcrllave5 = String.Empty;
            String lcrllave6 = String.Empty;

            for (int lnuFila = 1; lnuFila <= lnuTotalFilas; lnuFila++)
            {
                tmpRegActMS4505 = new ModeloSspNsRes4505Ex();
                if (lnuFila == 1 && String.IsNullOrWhiteSpace(lobRange.Cells[lnuFila, 6].Value) &&
                                    String.IsNullOrWhiteSpace(lobRange.Cells[lnuFila, 7].Value) &&
                                    String.IsNullOrWhiteSpace(lobRange.Cells[lnuFila, 8].Value) &&
                                    String.IsNullOrWhiteSpace(lobRange.Cells[lnuFila, 9].Value))
                {
                    // Registro de control 
                    this.txtG1RegistroControl.Text = lobRange.Cells[lnuFila, 1].Value.ToString() + "|" +
                                                     lobRange.Cells[lnuFila, 2].Value.ToString() + "|" +
                                                     lobRange.Cells[lnuFila, 3].Value.ToString() + "|" +
                                                     lobRange.Cells[lnuFila, 4].Value.ToString() + "|" +
                                                     lobRange.Cells[lnuFila, 5].Value.ToString();
                    // Cargar datos control en vista
                    this.txtG1Sia_codeps_carg.Text = lobRange.Cells[lnuFila, 2].Value.ToString();
                    this.txtG1Ssp_fecini_carg.Text = lobRange.Cells[lnuFila, 3].Value.ToString();
                    this.txtG1Ssp_fecfin_carg.Text = lobRange.Cells[lnuFila, 4].Value.ToString();

                }
                else
                {
                    #region Campos
                    tnuContadorRegTipo2++;
                    tmpRegActMS4505.BoolEstado = true;
                    tmpRegActMS4505.Estado = "INCLUIDO";
                    tmpRegActMS4505.Ssp_ideaux_ns45 = tnuContadorRegTipo2;
                    tmpRegActMS4505.Ssp_cam000_ms45 = lobRange.Cells[lnuFila, 1].Value.ToString();
                    tmpRegActMS4505.Ssp_cam001_ms45 = lobRange.Cells[lnuFila, 2].Value.ToString();
                    tmpRegActMS4505.Ssp_cam002_ms45 = lobRange.Cells[lnuFila, 3].Value.ToString();
                    tmpRegActMS4505.Ssp_cam003_ms45 = lobRange.Cells[lnuFila, 4].Value.ToString();
                    tmpRegActMS4505.Ssp_cam004_ms45 = lobRange.Cells[lnuFila, 5].Value.ToString();
                    tmpRegActMS4505.Ssp_cam005_ms45 = lobRange.Cells[lnuFila, 6].Value.ToString();
                    tmpRegActMS4505.Ssp_cam006_ms45 = lobRange.Cells[lnuFila, 7].Value.ToString();
                    tmpRegActMS4505.Ssp_cam007_ms45 = lobRange.Cells[lnuFila, 8].Value.ToString();
                    tmpRegActMS4505.Ssp_cam008_ms45 = lobRange.Cells[lnuFila, 09].Value.ToString();
                    tmpRegActMS4505.Ssp_cam009_ms45 = lobRange.Cells[lnuFila, 10].Value.ToString();
                    tmpRegActMS4505.Ssp_cam010_ms45 = lobRange.Cells[lnuFila, 11].Value.ToString();
                    tmpRegActMS4505.Ssp_cam011_ms45 = lobRange.Cells[lnuFila, 12].Value.ToString();
                    tmpRegActMS4505.Ssp_codocu_ciuo = lobRange.Cells[lnuFila, 13].Value.ToString();
                    tmpRegActMS4505.Ssp_cam013_ms45 = lobRange.Cells[lnuFila, 14].Value.ToString();
                    tmpRegActMS4505.Ssp_cam014_ms45 = lobRange.Cells[lnuFila, 15].Value.ToString();
                    tmpRegActMS4505.Ssp_cam015_ms45 = lobRange.Cells[lnuFila, 16].Value.ToString();
                    tmpRegActMS4505.Ssp_cam016_ms45 = lobRange.Cells[lnuFila, 17].Value.ToString();
                    tmpRegActMS4505.Ssp_cam017_ms45 = lobRange.Cells[lnuFila, 18].Value.ToString();
                    tmpRegActMS4505.Ssp_cam018_ms45 = lobRange.Cells[lnuFila, 19].Value.ToString();
                    tmpRegActMS4505.Ssp_cam019_ms45 = lobRange.Cells[lnuFila, 20].Value.ToString();
                    tmpRegActMS4505.Ssp_cam020_ms45 = lobRange.Cells[lnuFila, 21].Value.ToString();
                    tmpRegActMS4505.Ssp_cam021_ms45 = lobRange.Cells[lnuFila, 22].Value.ToString();
                    tmpRegActMS4505.Ssp_cam022_ms45 = lobRange.Cells[lnuFila, 23].Value.ToString();
                    tmpRegActMS4505.Ssp_cam023_ms45 = lobRange.Cells[lnuFila, 24].Value.ToString();
                    tmpRegActMS4505.Ssp_cam024_ms45 = lobRange.Cells[lnuFila, 25].Value.ToString();
                    tmpRegActMS4505.Ssp_cam025_ms45 = lobRange.Cells[lnuFila, 26].Value.ToString();
                    tmpRegActMS4505.Ssp_cam026_ms45 = lobRange.Cells[lnuFila, 27].Value.ToString();
                    tmpRegActMS4505.Ssp_cam027_ms45 = lobRange.Cells[lnuFila, 28].Value.ToString();
                    tmpRegActMS4505.Ssp_cam028_ms45 = lobRange.Cells[lnuFila, 29].Value.ToString();
                    tmpRegActMS4505.Ssp_cam029_ms45 = lobRange.Cells[lnuFila, 30].Value.ToString();
                    tmpRegActMS4505.Ssp_cam030_ms45 = lobRange.Cells[lnuFila, 31].Value.ToString();
                    tmpRegActMS4505.Ssp_cam031_ms45 = lobRange.Cells[lnuFila, 32].Value.ToString();
                    tmpRegActMS4505.Ssp_cam032_ms45 = lobRange.Cells[lnuFila, 33].Value.ToString();
                    tmpRegActMS4505.Ssp_cam033_ms45 = lobRange.Cells[lnuFila, 34].Value.ToString();
                    tmpRegActMS4505.Ssp_cam034_ms45 = lobRange.Cells[lnuFila, 35].Value.ToString();
                    tmpRegActMS4505.Ssp_cam035_ms45 = lobRange.Cells[lnuFila, 36].Value.ToString();
                    tmpRegActMS4505.Ssp_cam036_ms45 = lobRange.Cells[lnuFila, 37].Value.ToString();
                    tmpRegActMS4505.Ssp_cam037_ms45 = lobRange.Cells[lnuFila, 38].Value.ToString();
                    tmpRegActMS4505.Ssp_cam038_ms45 = lobRange.Cells[lnuFila, 39].Value.ToString();
                    tmpRegActMS4505.Ssp_cam039_ms45 = lobRange.Cells[lnuFila, 40].Value.ToString();
                    tmpRegActMS4505.Ssp_cam040_ms45 = lobRange.Cells[lnuFila, 41].Value.ToString();
                    tmpRegActMS4505.Ssp_cam041_ms45 = lobRange.Cells[lnuFila, 42].Value.ToString();
                    tmpRegActMS4505.Ssp_cam042_ms45 = lobRange.Cells[lnuFila, 43].Value.ToString();
                    tmpRegActMS4505.Ssp_cam043_ms45 = lobRange.Cells[lnuFila, 44].Value.ToString();
                    tmpRegActMS4505.Ssp_cam044_ms45 = lobRange.Cells[lnuFila, 45].Value.ToString();
                    tmpRegActMS4505.Ssp_cam045_ms45 = lobRange.Cells[lnuFila, 46].Value.ToString();
                    tmpRegActMS4505.Ssp_cam046_ms45 = lobRange.Cells[lnuFila, 47].Value.ToString();
                    tmpRegActMS4505.Ssp_cam047_ms45 = lobRange.Cells[lnuFila, 48].Value.ToString();
                    tmpRegActMS4505.Ssp_cam048_ms45 = lobRange.Cells[lnuFila, 49].Value.ToString();
                    tmpRegActMS4505.Ssp_cam049_ms45 = lobRange.Cells[lnuFila, 50].Value.ToString();
                    tmpRegActMS4505.Ssp_cam050_ms45 = lobRange.Cells[lnuFila, 51].Value.ToString();
                    tmpRegActMS4505.Ssp_cam051_ms45 = lobRange.Cells[lnuFila, 52].Value.ToString();
                    tmpRegActMS4505.Ssp_cam052_ms45 = lobRange.Cells[lnuFila, 53].Value.ToString();
                    tmpRegActMS4505.Ssp_cam053_ms45 = lobRange.Cells[lnuFila, 54].Value.ToString();
                    tmpRegActMS4505.Ssp_cam054_ms45 = lobRange.Cells[lnuFila, 55].Value.ToString();
                    tmpRegActMS4505.Ssp_cam055_ms45 = lobRange.Cells[lnuFila, 56].Value.ToString();
                    tmpRegActMS4505.Ssp_cam056_ms45 = lobRange.Cells[lnuFila, 57].Value.ToString();
                    tmpRegActMS4505.Ssp_cam057_ms45 = lobRange.Cells[lnuFila, 58].Value.ToString();
                    tmpRegActMS4505.Ssp_cam058_ms45 = lobRange.Cells[lnuFila, 59].Value.ToString();
                    tmpRegActMS4505.Ssp_cam059_ms45 = lobRange.Cells[lnuFila, 60].Value.ToString();
                    tmpRegActMS4505.Ssp_cam060_ms45 = lobRange.Cells[lnuFila, 61].Value.ToString();
                    tmpRegActMS4505.Ssp_cam061_ms45 = lobRange.Cells[lnuFila, 62].Value.ToString();
                    tmpRegActMS4505.Ssp_cam062_ms45 = lobRange.Cells[lnuFila, 63].Value.ToString();
                    tmpRegActMS4505.Ssp_cam063_ms45 = lobRange.Cells[lnuFila, 64].Value.ToString();
                    tmpRegActMS4505.Ssp_cam064_ms45 = lobRange.Cells[lnuFila, 65].Value.ToString();
                    tmpRegActMS4505.Ssp_cam065_ms45 = lobRange.Cells[lnuFila, 66].Value.ToString();
                    tmpRegActMS4505.Ssp_cam066_ms45 = lobRange.Cells[lnuFila, 67].Value.ToString();
                    tmpRegActMS4505.Ssp_cam067_ms45 = lobRange.Cells[lnuFila, 68].Value.ToString();
                    tmpRegActMS4505.Ssp_cam068_ms45 = lobRange.Cells[lnuFila, 69].Value.ToString();
                    tmpRegActMS4505.Ssp_cam069_ms45 = lobRange.Cells[lnuFila, 70].Value.ToString();
                    tmpRegActMS4505.Ssp_cam070_ms45 = lobRange.Cells[lnuFila, 71].Value.ToString();
                    tmpRegActMS4505.Ssp_cam071_ms45 = lobRange.Cells[lnuFila, 72].Value.ToString();
                    tmpRegActMS4505.Ssp_cam072_ms45 = lobRange.Cells[lnuFila, 73].Value.ToString();
                    tmpRegActMS4505.Ssp_cam073_ms45 = lobRange.Cells[lnuFila, 74].Value.ToString();
                    tmpRegActMS4505.Ssp_cam074_ms45 = lobRange.Cells[lnuFila, 75].Value.ToString();
                    tmpRegActMS4505.Ssp_cam075_ms45 = lobRange.Cells[lnuFila, 76].Value.ToString();
                    tmpRegActMS4505.Ssp_cam076_ms45 = lobRange.Cells[lnuFila, 77].Value.ToString();
                    tmpRegActMS4505.Ssp_cam077_ms45 = lobRange.Cells[lnuFila, 78].Value.ToString();
                    tmpRegActMS4505.Ssp_cam078_ms45 = lobRange.Cells[lnuFila, 79].Value.ToString();
                    tmpRegActMS4505.Ssp_cam079_ms45 = lobRange.Cells[lnuFila, 80].Value.ToString();
                    tmpRegActMS4505.Ssp_cam080_ms45 = lobRange.Cells[lnuFila, 81].Value.ToString();
                    tmpRegActMS4505.Ssp_cam081_ms45 = lobRange.Cells[lnuFila, 82].Value.ToString();
                    tmpRegActMS4505.Ssp_cam082_ms45 = lobRange.Cells[lnuFila, 83].Value.ToString();
                    tmpRegActMS4505.Ssp_cam083_ms45 = lobRange.Cells[lnuFila, 84].Value.ToString();
                    tmpRegActMS4505.Ssp_cam084_ms45 = lobRange.Cells[lnuFila, 85].Value.ToString();
                    tmpRegActMS4505.Ssp_cam085_ms45 = lobRange.Cells[lnuFila, 86].Value.ToString();
                    tmpRegActMS4505.Ssp_cam086_ms45 = lobRange.Cells[lnuFila, 87].Value.ToString();
                    tmpRegActMS4505.Ssp_cam087_ms45 = lobRange.Cells[lnuFila, 88].Value.ToString();
                    tmpRegActMS4505.Ssp_cam088_ms45 = lobRange.Cells[lnuFila, 89].Value.ToString();
                    tmpRegActMS4505.Ssp_cam089_ms45 = lobRange.Cells[lnuFila, 90].Value.ToString();
                    tmpRegActMS4505.Ssp_cam090_ms45 = lobRange.Cells[lnuFila, 91].Value.ToString();
                    tmpRegActMS4505.Ssp_cam091_ms45 = lobRange.Cells[lnuFila, 92].Value.ToString();
                    tmpRegActMS4505.Ssp_cam092_ms45 = lobRange.Cells[lnuFila, 93].Value.ToString();
                    tmpRegActMS4505.Ssp_cam093_ms45 = lobRange.Cells[lnuFila, 94].Value.ToString();
                    tmpRegActMS4505.Ssp_cam094_ms45 = lobRange.Cells[lnuFila, 95].Value.ToString();
                    tmpRegActMS4505.Ssp_cam095_ms45 = lobRange.Cells[lnuFila, 96].Value.ToString();
                    tmpRegActMS4505.Ssp_cam096_ms45 = lobRange.Cells[lnuFila, 97].Value.ToString();
                    tmpRegActMS4505.Ssp_cam097_ms45 = lobRange.Cells[lnuFila, 98].Value.ToString();
                    tmpRegActMS4505.Ssp_cam098_ms45 = lobRange.Cells[lnuFila, 99].Value.ToString();
                    tmpRegActMS4505.Ssp_cam099_ms45 = lobRange.Cells[lnuFila, 100].Value.ToString();
                    tmpRegActMS4505.Ssp_cam100_ms45 = lobRange.Cells[lnuFila, 101].Value.ToString();
                    tmpRegActMS4505.Ssp_cam101_ms45 = lobRange.Cells[lnuFila, 102].Value.ToString();
                    tmpRegActMS4505.Ssp_cam102_ms45 = lobRange.Cells[lnuFila, 103].Value.ToString();
                    tmpRegActMS4505.Ssp_cam103_ms45 = lobRange.Cells[lnuFila, 104].Value.ToString();
                    tmpRegActMS4505.Ssp_cam104_ms45 = lobRange.Cells[lnuFila, 105].Value.ToString();
                    tmpRegActMS4505.Ssp_cam105_ms45 = lobRange.Cells[lnuFila, 106].Value.ToString();
                    tmpRegActMS4505.Ssp_cam106_ms45 = lobRange.Cells[lnuFila, 107].Value.ToString();
                    tmpRegActMS4505.Ssp_cam107_ms45 = lobRange.Cells[lnuFila, 108].Value.ToString();
                    tmpRegActMS4505.Ssp_cam108_ms45 = lobRange.Cells[lnuFila, 109].Value.ToString();
                    tmpRegActMS4505.Ssp_cam109_ms45 = lobRange.Cells[lnuFila, 110].Value.ToString();
                    tmpRegActMS4505.Ssp_cam110_ms45 = lobRange.Cells[lnuFila, 111].Value.ToString();
                    tmpRegActMS4505.Ssp_cam111_ms45 = lobRange.Cells[lnuFila, 112].Value.ToString();
                    tmpRegActMS4505.Ssp_cam112_ms45 = lobRange.Cells[lnuFila, 113].Value.ToString();
                    tmpRegActMS4505.Ssp_cam113_ms45 = lobRange.Cells[lnuFila, 114].Value.ToString();
                    tmpRegActMS4505.Ssp_cam114_ms45 = lobRange.Cells[lnuFila, 115].Value.ToString();
                    tmpRegActMS4505.Ssp_cam115_ms45 = lobRange.Cells[lnuFila, 116].Value.ToString();
                    tmpRegActMS4505.Ssp_cam116_ms45 = lobRange.Cells[lnuFila, 117].Value.ToString();
                    tmpRegActMS4505.Ssp_cam117_ms45 = lobRange.Cells[lnuFila, 118].Value.ToString();
                    tmpRegActMS4505.Ssp_cam118_ms45 = lobRange.Cells[lnuFila, 119].Value.ToString();

                    lcrllave1 = tmpRegActMS4505.Ssp_ideaux_ns45.ToString().Trim() + " ";
                    lcrllave2 = tmpRegActMS4505.Ssp_cam004_ms45 != null ? tmpRegActMS4505.Ssp_cam004_ms45.ToUpper() + " " : String.Empty;
                    lcrllave3 = tmpRegActMS4505.Ssp_cam005_ms45 != null ? tmpRegActMS4505.Ssp_cam005_ms45.ToUpper() + " " : String.Empty;
                    lcrllave4 = tmpRegActMS4505.Ssp_cam006_ms45 != null ? tmpRegActMS4505.Ssp_cam006_ms45.ToUpper() + " " : String.Empty;
                    lcrllave5 = tmpRegActMS4505.Ssp_cam007_ms45 != null ? tmpRegActMS4505.Ssp_cam007_ms45.ToUpper() + " " : String.Empty;
                    lcrllave6 = tmpRegActMS4505.Ssp_cam008_ms45 != null ? tmpRegActMS4505.Ssp_cam008_ms45.ToUpper() : String.Empty;

                    tmpRegActMS4505.LlaveBusqueda = lcrllave1 + lcrllave2 + lcrllave3 + lcrllave4 + lcrllave5 + lcrllave6;
                    #endregion
                }

                vm.TmpG2ListaBrow.Add(tmpRegActMS4505);
            }

            this.txtG1Ssp_totreg_carg.Text = tnuContadorRegTipo2.ToString();
            this.txtG1Ssp_forfec_sscf.Text = "YMD";

            // cerrar
            lobWorkBook.Close(false, luxValue, luxValue);
            lobApp.Quit();
            // liberar objetos
            fcvExcelReleaseObject(lobWorkSheet);
            fcvExcelReleaseObject(lobWorkBook);
            fcvExcelReleaseObject(lobApp);
        }
        #endregion
        #region fcvExcelReleaseObject: liberar objetos Microsoft Excel
        /// <summary>
        /// <para>liberar objetos Microsoft Excel</para>
        /// </summary>
        public static void fcvExcelReleaseObject(object tobObjeto)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(tobObjeto);
                tobObjeto = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tobObjeto = null;
                GC.Collect();
            }
        }
        #endregion
        //---------------------------------------------------------------
        // EXPORTAR DATOS A PLANO O EXCEL
        //---------------------------------------------------------------
        //- Exportar a plano
        #region fcvExportarForamtoPlano: Exportar a plano opcion desde menu
        private void fcvExportarForamtoPlano(object sender, RoutedEventArgs e)
        {
            gcrTipoExportar = "PLANO";
            flgExportarForamtoPlano();
        }
        #endregion
        #region flgExportarForamtoPlano: Exportar datos a archivo plano
        /// <summary>
        /// <para>Exportar datos a archivo plano</para>
        /// </summary>
        public bool flgExportarForamtoPlano()
        {
            var llgReturn = false;
            gcrExportarArchivoNombreyRuta = this.txtG1Ssp_rutarc_sscf.Text + this.txtG1ArchivoDestino.Text + ".TXT";
            if (!string.IsNullOrEmpty(gcrExportarArchivoNombreyRuta))
            {

                llgReturn = true;

                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Exportando plano de datos...", "CENTRO");
                lobDlgAdd.Show();

                var lcrRegcontrol = fcrGenerarRegistroControl();
                var lcrTituloCamp = gcrTipoExportar == "EXCEL" ? "\n" + fcrGenerarTitulosEncabezadosCampos() : String.Empty;
                var lcrPlano      = lcrRegcontrol + lcrTituloCamp + "\n" + fcrExportarForamtoPlano();

                System.IO.File.WriteAllText(@gcrExportarArchivoNombreyRuta, lcrPlano, Encoding.Default);

                lobDlgAdd.Close();
            }
            return llgReturn;
        }
        #endregion
        #region flgExportarForamtoPlanoExcel: Exportar datos a archivo plano para la vista en Excel
        /// <summary>
        /// <para>Exportar datos a archivo plano para la vista en excel</para>
        /// </summary>
        public bool flgExportarForamtoPlanoExcel()
        {
            var llgReturn = false;

            try
            {
                gcrExportarArchivoNombreyRuta = this.txtG1Ssp_rutarc_sscf.Text + fcrExportarForamtoPlanoGenerarNombreArchivo(this.txtG1ArchivoDestino.Text) + ".TXT";
                if (!string.IsNullOrEmpty(gcrExportarArchivoNombreyRuta))
                {

                    llgReturn = true;

                    DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Exportando planos para datos en Excel...", "CENTRO");
                    lobDlgAdd.Show();

                    var lcrRegcontrol = fcrGenerarRegistroControl();
                    var lcrTituloCamp = gcrTipoExportar == "EXCEL" ? "\n" + fcrGenerarTitulosEncabezadosCampos() : String.Empty;
                    var lcrPlano = lcrRegcontrol + lcrTituloCamp + "\n" + fcrExportarForamtoPlanoExcel();

                    System.IO.File.WriteAllText(@gcrExportarArchivoNombreyRuta, lcrPlano, Encoding.UTF8);

                    lobDlgAdd.Close();
                }
            }
            catch (Exception e)
            {
                Funciones.fcvVistaErroresEjecucion(ref e, "Exportar a Excel: flgExportarForamtoPlanoExcel");
                //MessageBox.Show(e.Message);
            }

            return llgReturn;
        }
        #endregion
        #region fcrGenerarRegistroControl: Generar el registro de control
        /// <summary>
        /// <para>Generar el registro de control para el archivo plano</para>
        /// </summary>
        public String fcrGenerarRegistroControl()
        {
            var lcrTotRegistros = (from tmp in vm.TmpG2ListaBrow  where tmp.BoolEstado == true select tmp).Count().ToString().Trim();

            var lcrRegControl = "1"+ gcrExportarArchivoSeparador + this.txtG1Sia_codeps_teps.Text + gcrExportarArchivoSeparador +
                                Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtG1Ssp_fecini_peri.Text.Trim(), "YMD", "-") + gcrExportarArchivoSeparador +
                                Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtG1Ssp_fecfin_peri.Text.Trim(), "YMD", "-") + gcrExportarArchivoSeparador + lcrTotRegistros;
            return lcrRegControl;
        }
        #endregion
        #region fcrGenerarTitulosEncabezadosCampos: Generar titulos de campos para plano
        /// <summary>
        /// <para>Generar titulos de campos para planos</para>
        /// </summary>
        public String fcrGenerarTitulosEncabezadosCampos()
        {
            var lcrTitulosCampos = "0.Tipo de Registro," +
                                    "1.Consecutivo Registro," +
                                    "2.Código de Habilitación IPS primaria," +
                                    "3.Tipo de identificación del usuario," +
                                    "4.Numero de identificación del usuario," +
                                    "5.Primer apellido del usuario," +
                                    "6.Segundo apellido del usuario," +
                                    "7.Primer nombre del usuario," +
                                    "8.Segundo nombre del usuario," +
                                    "9.Fecha de Nacimiento," +
                                    "10.Sexo," +
                                    "11.Codigo pertenencia étnica," +
                                    "12.Codigo de ocupación," +
                                    "13.Codigo de nivel educativo," +
                                    "14.Gestacion," +
                                    "15.Sifilis Gestacional o congénita," +
                                    "16.Hipertension Inducida por la Gestación," +
                                    "17.Hipotiroidismo Congénito," +
                                    "18.Sintomatico Respiratorio," +
                                    "19.Tuberculosis Multidrogoresistente," +
                                    "20.Lepra," +
                                    "21.Obesidad o Desnutrición Proteico Calórica," +
                                    "22.Mujer o Menor Victima de Maltrato," +
                                    "23.Victima de Violencia Sexual," +
                                    "24.Infecciones de Trasmisión Sexual," +
                                    "25.Enfermedad Mental," +
                                    "26.Cancer de Cérvix," +
                                    "27.Cancer de Seno," +
                                    "28.Fluorosis Dental," +
                                    "29.Fecha del Peso," +
                                    "30.Peso en Kilogramos," +
                                    "31.Fecha de la Talla," +
                                    "32.Talla en Centímetros," +
                                    "33.Fecha Probable de Parto," +
                                    "34.Edad Gestacional al Nacer," +
                                    "35.BCG," +
                                    "36.Hepatitis B menores de 1 año," +
                                    "37.Pentavalente," +
                                    "38.Polio," +
                                    "39.DPT menores de 5 años," +
                                    "40.Rotavirus," +
                                    "41.Neumococo," +
                                    "42.Influenza Niños," +
                                    "43.Fiebre Amarilla niños de 1 año," +
                                    "44.Hepatitis A," +
                                    "45.Triple Viral Niños," +
                                    "46.Virus del Papiloma Humano (VPH)," +
                                    "47.TD o TT Mujeres en Edad Fértil 15 a 49 años," +
                                    "48.Control de Placa Bacteriana," +
                                    "49.Fecha atención parto o cesárea," +
                                    "50.Fecha salida de la atención del parto o cesárea," +
                                    "51.Fecha de consejería en Lactancia Materna," +
                                    "52.Control Recién Nacido," +
                                    "53.Planificacion Familiar Primera vez," +
                                    "54.Suministro de Método Anticonceptivo," +
                                    "55.Fecha Suministro de Método Anticonceptivo," +
                                    "56.Control Prenatal de Primera vez," +
                                    "57.Control Prenatal," +
                                    "58.Ultimo Control Prenatal," +
                                    "59.Suministro de acido Fólico en el ultimo Control Prenatal," +
                                    "60.Suministro de Sulfato Ferroso en el ultimo Control Prenatal," +
                                    "61.Suministro de Carbonato de Calcio en el ultimo Control Prenatal," +
                                    "62.Valoracion de la Agudeza Visual," +
                                    "63.Consulta por Oftalmología," +
                                    "64.Fecha Diagnostico Desnutrición Proteico Calórica," +
                                    "65.Consulta Mujer o Menor Victima del Maltrato," +
                                    "66.Consulta Victimas de Violencia Sexual," +
                                    "67.Consulta Nutrición," +
                                    "68.Consulta de Psicología," +
                                    "69.Consulta de Crecimiento y Desarrollo Primera vez," +
                                    "70.Suministro de Sulfato Ferroso en la ultima Consulta del Menor de 10 años," +
                                    "71.Suministro de Vitamina A en la ultima Consulta del Menor de 10 años," +
                                    "72.Consulta de Joven Primera vez," +
                                    "73.Consulta de Adulto Primera vez," +
                                    "74.Preservativos entregados a pacientes con ITS," +
                                    "75.Asesoria Pre test Elisa para VIH," +
                                    "76.Asesoria Pos test Elisa para VIH," +
                                    "77.Paciente con Diagnostico de: Ansiedad," +
                                    "78.Fecha Antígeno de Superficie Hepatitis B en Gestantes," +
                                    "79.Resultado Antígeno de Superficie Hepatitis B en Gestantes," +
                                    "80.Fecha Serología para Sífilis," +
                                    "81.Resultado Serología para Sífilis," +
                                    "82.Fecha de Toma de Elisa para VIH," +
                                    "83.Resultado Elisa para VIH," +
                                    "84.Fecha TSH Neonatal," +
                                    "85.Resultado de TSH Neonatal," +
                                    "86.Tamizaje Cáncer de Cuello Uterino," +
                                    "87.Citologia Cervico uterina," +
                                    "88.Citologia Cervico uterina Resultados según Bethesda," +
                                    "89.Calidad en la Muestra de Citología Cervicouterina," +
                                    "90.Codigo de habilitación IPS donde se toma Citología Cervicouterina," +
                                    "91.Fecha Colposcopia," +
                                    "92.Codigo de habilitación IPS donde se toma Colposcopia," +
                                    "93.Fecha Biopsia Cervical," +
                                    "94.Resultado de Biopsia Cervical," +
                                    "95.Codigo de habilitación IPS donde se toma Biopsia Cervical," +
                                    "96.Fecha Mamografía," +
                                    "97.Resultado Mamografía," +
                                    "98.Codigo de habilitación IPS donde se toma Mamografía," +
                                    "99.Fecha Toma Biopsia Seno por BACAF," +
                                    "100.Fecha Resultado Biopsia Seno por BACAF," +
                                    "101.Biopsia Seno por BACAF," +
                                    "102.Codigo de habilitación IPS donde se toma Biopsia Seno por BACAF," +
                                    "103.Fecha Toma de Hemoglobina," +
                                    "104.Hemoglobina," +
                                    "105.Fecha de la Toma de Glicemia Basal," +
                                    "106.Fecha Creatinina," +
                                    "107.Creatinina," +
                                    "108.Fecha Hemoglobina Glicosilada," +
                                    "109.Hemoglobina Glicosilada," +
                                    "110.Fecha Toma de Microalbuminuria," +
                                    "111.Fecha Toma de HDL," +
                                    "112.Fecha Toma de Baciloscopia de Diagnostico," +
                                    "113.Baciloscopia de Diagnostico," +
                                    "114.Tratamiento para Hipotiroidismo Congénito," +
                                    "115.Tratamiento para Sífilis gestacional," +
                                    "116.Tratamiento para Sífilis Congénita," +
                                    "117.Tratamiento para Lepra," +
                                    "118.Fecha de Terminación Tratamiento para Leishmaniasis";

            return lcrTitulosCampos;
        }
        #endregion
        #region fcrCnvFecha: Convertir formato fecha para envio a plano 
        /// <summary>
        /// <para>Convertir formato fecha para envio a plano </para>
        /// </summary>
        public String fcrCnvFecha(String tcrFecha)
        {
            var lcrFecha = tcrFecha;
            if (this.txtG1Ssp_forfec_sscf.Text != "YMD")
            {
                lcrFecha = Funciones.fcrFechaTextoCambiarFormato(this.txtG1Ssp_forfec_sscf.Text, "/", tcrFecha, "YMD", "-");
            }
            return lcrFecha;
        }
        #endregion
        #region fcrExportarForamtoPlano: Exportar los datos a formato Archivo Plano
        /// <summary>
        /// <para>Exportar los datos a formato Archivo Plano</para>
        /// </summary>
        public String fcrExportarForamtoPlano()
        {
            var tmpDatos = (from tmp in vm.TmpG2ListaBrow  where tmp.BoolEstado == true select tmp);
            int i = 0;
            int lnuTotalRegistros = tmpDatos.Count();
            String lcrArchivo = String.Empty;
            String lcrTexto1, lcrTexto2, lcrTexto3, lcrTexto4;
            if (tmpDatos != null)
            {
                foreach (var lobReg in tmpDatos)
                {
                    lcrTexto1 = String.Empty;
                    lcrTexto2 = String.Empty;
                    lcrTexto3 = String.Empty;
                    lcrTexto4 = String.Empty;
                    i++;

                    #region Campos
                    lcrTexto1 = lobReg.Ssp_cam000_ms45.Trim() + gcrExportarArchivoSeparador +
                                i.ToString().Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam002_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam003_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam004_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam005_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam006_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam007_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam008_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam009_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam010_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam011_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_codocu_ciuo.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam013_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam014_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam015_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam016_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam017_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam018_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam019_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam020_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam021_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam022_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam023_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam024_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam025_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam026_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam027_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam028_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam029_ms45.Trim()) + gcrExportarArchivoSeparador;

                    lcrTexto2 = lobReg.Ssp_cam030_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam031_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam032_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam033_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam034_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam035_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam036_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam037_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam038_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam039_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam040_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam041_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam042_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam043_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam044_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam045_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam046_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam047_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam048_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam049_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam050_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam051_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam052_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam053_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam054_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam055_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam056_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam057_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam058_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam059_ms45.Trim() + gcrExportarArchivoSeparador;

                    lcrTexto3 = lobReg.Ssp_cam060_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam061_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam062_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam063_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam064_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam065_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam066_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam067_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam068_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam069_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam070_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam071_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam072_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam073_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam074_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam075_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam076_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam077_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam078_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam079_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam080_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam081_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam082_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam083_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam084_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam085_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam086_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam087_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam088_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam089_ms45.Trim() + gcrExportarArchivoSeparador;

                    lcrTexto4 = lobReg.Ssp_cam090_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam091_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam092_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam093_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam094_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam095_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam096_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam097_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam098_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam099_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam100_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam101_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam102_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam103_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam104_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam105_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam106_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam107_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam108_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam109_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam110_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam111_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam112_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam113_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam114_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam115_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam116_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam117_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam118_ms45.Trim());
                    #endregion
                    if (i == lnuTotalRegistros)
                    {
                        lcrTexto1 = lcrTexto1 + lcrTexto2 + lcrTexto3 + lcrTexto4;
                    }
                    else
                    {
                        lcrTexto1 = lcrTexto1 + lcrTexto2 + lcrTexto3 + lcrTexto4 + "\n";
                    }
                    lcrArchivo += lcrTexto1;
                }
            }
            return lcrArchivo;
        }
        #endregion
        #region fcrExportarForamtoPlanoExcel: Exportar los datos a formato Archivo Plano
        /// <summary>
        /// <para>Exportar los datos a formato Archivo Plano</para>
        /// </summary>
        public String fcrExportarForamtoPlanoExcel()
        {
            var tmpDatos = (from tmp in vm.TmpG2ListaBrow where tmp.BoolEstado == true select tmp);
            int i = 0;
            int lnuTotalRegistros = tmpDatos.Count();
            String lcrArchivo = String.Empty;
            String lcrTexto1, lcrTexto2, lcrTexto3, lcrTexto4;
            if (tmpDatos != null)
            {
                foreach (var lobReg in tmpDatos)
                {
                    lcrTexto1 = String.Empty;
                    lcrTexto2 = String.Empty;
                    lcrTexto3 = String.Empty;
                    lcrTexto4 = String.Empty;
                    i++;

                    #region Campos
                    lcrTexto1 = lobReg.Ssp_cam000_ms45.Trim() + gcrExportarArchivoSeparador +
                                i.ToString().Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam002_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam003_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam004_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam005_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam006_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam007_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam008_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam009_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam010_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam011_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_codocu_ciuo.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam013_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam014_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam015_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam016_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam017_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam018_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam019_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam020_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam021_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam022_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam023_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam024_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam025_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam026_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam027_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam028_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam029_ms45.Trim()) + gcrExportarArchivoSeparador;

                    lcrTexto2 = lobReg.Ssp_cam030_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam031_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam032_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam033_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam034_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam035_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam036_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam037_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam038_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam039_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam040_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam041_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam042_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam043_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam044_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam045_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam046_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam047_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam048_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam049_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam050_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam051_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam052_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam053_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam054_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam055_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam056_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam057_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam058_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam059_ms45.Trim() + gcrExportarArchivoSeparador;

                    lcrTexto3 = lobReg.Ssp_cam060_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam061_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam062_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam063_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam064_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam065_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam066_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam067_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam068_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam069_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam070_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam071_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam072_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam073_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam074_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam075_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam076_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam077_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam078_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam079_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam080_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam081_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam082_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam083_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam084_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam085_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam086_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam087_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam088_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam089_ms45.Trim() + gcrExportarArchivoSeparador;

                    lcrTexto4 = lobReg.Ssp_cam090_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam091_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam092_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam093_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam094_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam095_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam096_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam097_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam098_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam099_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam100_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam101_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam102_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam103_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam104_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam105_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam106_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam107_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam108_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam109_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam110_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam111_ms45.Trim()) + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam112_ms45.Trim()) + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam113_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam114_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam115_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam116_ms45.Trim() + gcrExportarArchivoSeparador +
                                lobReg.Ssp_cam117_ms45.Trim() + gcrExportarArchivoSeparador +
                                fcrCnvFecha(lobReg.Ssp_cam118_ms45.Trim())+ gcrExportarArchivoSeparador +
                                lobReg.Ssp_abrevi_ms45 + gcrExportarArchivoSeparador +
                                lobReg.Sia_edaymd_usua + gcrExportarArchivoSeparador +
                                lobReg.Ssp_VarMod_ms45;
                    #endregion
                    if (i == lnuTotalRegistros)
                    {
                        lcrTexto1 = lcrTexto1 + lcrTexto2 + lcrTexto3 + lcrTexto4;
                    }
                    else
                    {
                        lcrTexto1 = lcrTexto1 + lcrTexto2 + lcrTexto3 + lcrTexto4 + "\n";
                    }
                    lcrArchivo += lcrTexto1;
                }
            }
            return lcrArchivo;
        }
        #endregion
        #region fcrGuardarGenerarNombreArchivo: Generar el nombre unico del archivo
        /// <summary>
        /// Generar el nombre unico del archivo
        /// </summary>
        public String fcrExportarForamtoPlanoGenerarNombreArchivo(String tcrNombreArchivoBase)
        {
            gnuContadorvistaArchivos++;

            var lcrNombre   = gnuContadorvistaArchivos.ToString().Trim() + "-" + Funciones.fnuFechaLlaveIndiceRegistro().ToString().Trim();
            lcrNombre       = tcrNombreArchivoBase + "-" + lcrNombre;

            return lcrNombre;
        }
        #endregion
        // Exportar a Excel
        #region fcvExportarForamtoExcel: Exportar a excel opcion desde menu
        private void fcvExportarForamtoExcel(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(500);
            gcrTipoExportar = "EXCEL";
            flgExportarFormatoExcel();
        }
        #endregion
        #region flgExportarFormatoExcel: Exportar datos a archivo excel
        /// <summary>
        /// <para>Exportar datos a archivo excel</para>
        /// </summary>
        private bool flgExportarFormatoExcel()
        {
            gcrExportarArchivoSeparador = ",";
            flgExportarForamtoPlanoExcel();
            gcrExportarArchivoSeparador = "|";
            //gcrExportarArchivoNombreyRuta
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Abriendo en Microsoft Excel...", "CENTRO");
            lobDlgAdd.Show();

            var llgreturn = true;
            var tmpDatos = (from tmp in vm.TmpG2ListaBrow where tmp.Estado == "INCLUIDO" select tmp);

            Excel.Application lobApp;
            Excel.Workbook lobLibroTrabajo;

            lobApp = new Excel.Application();
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;

            // Cargar todos los campos interpretando todo en formato texto
            object objInfoFormatoCampos = new int[121, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 2 },{ 5, 2 },{ 6, 2 },{ 7, 2 },{ 8, 2 },{ 9, 2 },{ 10, 2 },
                                                         { 11, 2 },{ 12, 2 },{ 13, 2},{ 14, 2 },{ 15, 2},{ 16, 2 },{ 17, 2 },{ 18, 2 },{ 19, 2 },{ 20, 2 },
                                                         { 21, 2 },{ 22, 2 },{ 23, 2 },{ 24, 2 },{ 25, 2 },{ 26, 2 },{ 27, 2 },{ 28, 2 },{ 29, 2 },{ 30, 2 },
                                                         { 31, 2 },{ 32, 2 },{ 33, 2 },{ 34, 2 },{ 35, 2 },{ 36, 2 },{ 37, 2 },{ 38, 2 },{ 39, 2 },{ 40, 2 },
                                                         { 41, 2 },{ 42, 2 },{ 43, 2 },{ 44, 2 },{ 45, 2 },{ 46, 2 },{ 47, 2 },{ 48, 2 },{ 49, 2 },{ 50, 2 },
                                                         { 51, 2 },{ 52, 2 },{ 53, 2 },{ 54, 2 },{ 55, 2 },{ 56, 2 },{ 57, 2 },{ 58, 2 },{ 59, 2 },{ 60, 2 },
                                                         { 61, 2 },{ 62, 2 },{ 63, 2 },{ 64, 2 },{ 65, 2 },{ 66, 2 },{ 57, 2 },{ 68, 2 },{ 69, 2 },{ 70, 2 },
                                                         { 71, 2 },{ 72, 2 },{ 73, 2 },{ 74, 2 },{ 75, 2 },{ 76, 2 },{ 77, 2 },{ 78, 2 },{ 79, 2 },{ 80, 2 },
                                                         { 81, 2 },{ 82, 2 },{ 83, 2 },{ 84, 2 },{ 85, 2 },{ 86, 2 },{ 87, 2 },{ 88, 2 },{ 89, 2 },{ 90, 2 },
                                                         { 91, 2 },{ 92, 2 },{ 93, 2 },{ 94, 2 },{ 95, 2 },{ 96, 2 },{ 97, 2 },{ 98, 2 },{ 99, 2 },{ 100, 2 },
                                                         { 101, 2 },{ 102, 2 },{ 103, 2 },{ 104, 2 },{ 105, 2 },{ 106, 2 },{ 107, 2 },{ 108, 2 },{ 109, 2 },
                                                         { 110, 2 },{ 111, 2 },{ 112, 2 },{ 113, 2 },{ 114, 2 },{ 115, 2 },{ 116, 2 },{ 117, 2 },{ 118, 2 },
                                                         { 119, 2 },{ 120, 2 },{ 121, 2 }};
            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8
            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                     Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, ",", objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);

            try
            {
                //String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                lobApp.DisplayAlerts = false;
                var lcrArchivo = fcrExportarForamtoPlanoGenerarNombreArchivo("MAESTRODATOSEXCEL") + ".XLS";
                lobLibroTrabajo.SaveAs(lcrArchivo, Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            lobDlgAdd.Close();

            return llgreturn;
        }
        private bool flgExportarFormatoExcelxx()
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Exportando datos a Microsoft Excel...", "CENTRO");
            lobDlgAdd.Show();

            var llgreturn = true;
            var tmpDatos = (from tmp in vm.TmpG2ListaBrow where tmp.Estado == "INCLUIDO" select tmp);
            gcrExportarArchivoNombreyRuta = this.txtG1Ssp_rutarc_sscf.Text+this.txtG1ArchivoDestino.Text+".XLS";
            int i = 2;

            Excel.Application   lobApp;
            Excel.Workbook      lobLibroTrabajo;
            Excel.Worksheet     lobHoja;

            lobApp          = new Excel.Application();
            lobLibroTrabajo = lobApp.Workbooks.Add();
            lobHoja         = (Excel.Worksheet)lobLibroTrabajo.Worksheets.get_Item(1);

            // poner formato texto a la hoja
            var lobCells = (Excel.Range)lobHoja.Cells;
            lobCells.NumberFormat = "@";

            // Registro de control
            lobHoja.Cells[1, 1] = "1";
            lobHoja.Cells[1, 2] = this.txtG1Sia_codeps_teps.Text;
            lobHoja.Cells[1, 3] = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtG1Ssp_fecini_peri.Text.Trim(), "YMD", "-");
            lobHoja.Cells[1, 4] = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtG1Ssp_fecfin_peri.Text.Trim(), "YMD", "-");
            lobHoja.Cells[1, 5] = tmpDatos.Count().ToString().Trim();

            //Recorremos el temporal y rellenando la hoja de trabajo
            foreach (var lobReg in tmpDatos)
            {
                #region Campos
                lobHoja.Cells[i, 1] = lobReg.Ssp_cam000_ms45.Trim();
                lobHoja.Cells[i, 2] = (i-1).ToString().Trim();
                lobHoja.Cells[i, 3] = lobReg.Ssp_cam002_ms45 != null ? lobReg.Ssp_cam002_ms45.Trim(): String.Empty;
                lobHoja.Cells[i, 4] = lobReg.Ssp_cam003_ms45.Trim();
                lobHoja.Cells[i, 5] = lobReg.Ssp_cam004_ms45.Trim();
                lobHoja.Cells[i, 6] = lobReg.Ssp_cam005_ms45.Trim();
                lobHoja.Cells[i, 7] = lobReg.Ssp_cam006_ms45.Trim();
                lobHoja.Cells[i, 8] = lobReg.Ssp_cam007_ms45.Trim();
                lobHoja.Cells[i, 9] = lobReg.Ssp_cam008_ms45.Trim();
                lobHoja.Cells[i, 10] = lobReg.Ssp_cam009_ms45.Trim();
                lobHoja.Cells[i, 11] = lobReg.Ssp_cam010_ms45.Trim();
                lobHoja.Cells[i, 12] = lobReg.Ssp_cam011_ms45.Trim();
                lobHoja.Cells[i, 13] = lobReg.Ssp_codocu_ciuo.Trim();
                lobHoja.Cells[i, 14] = lobReg.Ssp_cam013_ms45.Trim();
                lobHoja.Cells[i, 15] = lobReg.Ssp_cam014_ms45.Trim();
                lobHoja.Cells[i, 16] = lobReg.Ssp_cam015_ms45.Trim();
                lobHoja.Cells[i, 17] = lobReg.Ssp_cam016_ms45.Trim();
                lobHoja.Cells[i, 18] = lobReg.Ssp_cam017_ms45.Trim();
                lobHoja.Cells[i, 19] = lobReg.Ssp_cam018_ms45.Trim();
                lobHoja.Cells[i, 20] = lobReg.Ssp_cam019_ms45.Trim();
                lobHoja.Cells[i, 21] = lobReg.Ssp_cam020_ms45.Trim();
                lobHoja.Cells[i, 22] = lobReg.Ssp_cam021_ms45.Trim();
                lobHoja.Cells[i, 23] = lobReg.Ssp_cam022_ms45.Trim();
                lobHoja.Cells[i, 24] = lobReg.Ssp_cam023_ms45.Trim();
                lobHoja.Cells[i, 25] = lobReg.Ssp_cam024_ms45.Trim();
                lobHoja.Cells[i, 26] = lobReg.Ssp_cam025_ms45.Trim();
                lobHoja.Cells[i, 27] = lobReg.Ssp_cam026_ms45.Trim();
                lobHoja.Cells[i, 28] = lobReg.Ssp_cam027_ms45.Trim();
                lobHoja.Cells[i, 29] = lobReg.Ssp_cam028_ms45.Trim();
                lobHoja.Cells[i, 30] = lobReg.Ssp_cam029_ms45.Trim();
                lobHoja.Cells[i, 31] = lobReg.Ssp_cam030_ms45.Trim();
                lobHoja.Cells[i, 32] = lobReg.Ssp_cam031_ms45.Trim();
                lobHoja.Cells[i, 33] = lobReg.Ssp_cam032_ms45.Trim();
                lobHoja.Cells[i, 34] = lobReg.Ssp_cam033_ms45.Trim();
                lobHoja.Cells[i, 35] = lobReg.Ssp_cam034_ms45.Trim();
                lobHoja.Cells[i, 36] = lobReg.Ssp_cam035_ms45.Trim();
                lobHoja.Cells[i, 37] = lobReg.Ssp_cam036_ms45.Trim();
                lobHoja.Cells[i, 38] = lobReg.Ssp_cam037_ms45.Trim();
                lobHoja.Cells[i, 39] = lobReg.Ssp_cam038_ms45.Trim();
                lobHoja.Cells[i, 40] = lobReg.Ssp_cam039_ms45.Trim();
                lobHoja.Cells[i, 41] = lobReg.Ssp_cam040_ms45.Trim();
                lobHoja.Cells[i, 42] = lobReg.Ssp_cam041_ms45.Trim();
                lobHoja.Cells[i, 43] = lobReg.Ssp_cam042_ms45.Trim();
                lobHoja.Cells[i, 44] = lobReg.Ssp_cam043_ms45.Trim();
                lobHoja.Cells[i, 45] = lobReg.Ssp_cam044_ms45.Trim();
                lobHoja.Cells[i, 46] = lobReg.Ssp_cam045_ms45.Trim();
                lobHoja.Cells[i, 47] = lobReg.Ssp_cam046_ms45.Trim();
                lobHoja.Cells[i, 48] = lobReg.Ssp_cam047_ms45.Trim();
                lobHoja.Cells[i, 49] = lobReg.Ssp_cam048_ms45.Trim();
                lobHoja.Cells[i, 50] = lobReg.Ssp_cam049_ms45.Trim();
                lobHoja.Cells[i, 51] = lobReg.Ssp_cam050_ms45.Trim();
                lobHoja.Cells[i, 52] = lobReg.Ssp_cam051_ms45.Trim();
                lobHoja.Cells[i, 53] = lobReg.Ssp_cam052_ms45.Trim();
                lobHoja.Cells[i, 54] = lobReg.Ssp_cam053_ms45.Trim();
                lobHoja.Cells[i, 55] = lobReg.Ssp_cam054_ms45.Trim();
                lobHoja.Cells[i, 56] = lobReg.Ssp_cam055_ms45.Trim();
                lobHoja.Cells[i, 57] = lobReg.Ssp_cam056_ms45.Trim();
                lobHoja.Cells[i, 58] = lobReg.Ssp_cam057_ms45.Trim();
                lobHoja.Cells[i, 59] = lobReg.Ssp_cam058_ms45.Trim();
                lobHoja.Cells[i, 60] = lobReg.Ssp_cam059_ms45.Trim();
                lobHoja.Cells[i, 61] = lobReg.Ssp_cam060_ms45.Trim();
                lobHoja.Cells[i, 62] = lobReg.Ssp_cam061_ms45.Trim();
                lobHoja.Cells[i, 63] = lobReg.Ssp_cam062_ms45.Trim();
                lobHoja.Cells[i, 64] = lobReg.Ssp_cam063_ms45.Trim();
                lobHoja.Cells[i, 65] = lobReg.Ssp_cam064_ms45.Trim();
                lobHoja.Cells[i, 66] = lobReg.Ssp_cam065_ms45.Trim();
                lobHoja.Cells[i, 67] = lobReg.Ssp_cam066_ms45.Trim();
                lobHoja.Cells[i, 68] = lobReg.Ssp_cam067_ms45.Trim();
                lobHoja.Cells[i, 69] = lobReg.Ssp_cam068_ms45.Trim();
                lobHoja.Cells[i, 70] = lobReg.Ssp_cam069_ms45.Trim();
                lobHoja.Cells[i, 71] = lobReg.Ssp_cam070_ms45.Trim();
                lobHoja.Cells[i, 72] = lobReg.Ssp_cam071_ms45.Trim();
                lobHoja.Cells[i, 73] = lobReg.Ssp_cam072_ms45.Trim();
                lobHoja.Cells[i, 74] = lobReg.Ssp_cam073_ms45.Trim();
                lobHoja.Cells[i, 75] = lobReg.Ssp_cam074_ms45.Trim();
                lobHoja.Cells[i, 76] = lobReg.Ssp_cam075_ms45.Trim();
                lobHoja.Cells[i, 77] = lobReg.Ssp_cam076_ms45.Trim();
                lobHoja.Cells[i, 78] = lobReg.Ssp_cam077_ms45.Trim();
                lobHoja.Cells[i, 79] = lobReg.Ssp_cam078_ms45.Trim();
                lobHoja.Cells[i, 80] = lobReg.Ssp_cam079_ms45.Trim();
                lobHoja.Cells[i, 81] = lobReg.Ssp_cam080_ms45.Trim();
                lobHoja.Cells[i, 82] = lobReg.Ssp_cam081_ms45.Trim();
                lobHoja.Cells[i, 83] = lobReg.Ssp_cam082_ms45.Trim();
                lobHoja.Cells[i, 84] = lobReg.Ssp_cam083_ms45.Trim();
                lobHoja.Cells[i, 85] = lobReg.Ssp_cam084_ms45.Trim();
                lobHoja.Cells[i, 86] = lobReg.Ssp_cam085_ms45.Trim();
                lobHoja.Cells[i, 87] = lobReg.Ssp_cam086_ms45.Trim();
                lobHoja.Cells[i, 88] = lobReg.Ssp_cam087_ms45.Trim();
                lobHoja.Cells[i, 89] = lobReg.Ssp_cam088_ms45.Trim();
                lobHoja.Cells[i, 90] = lobReg.Ssp_cam089_ms45.Trim();
                lobHoja.Cells[i, 91] = lobReg.Ssp_cam090_ms45.Trim();
                lobHoja.Cells[i, 92] = lobReg.Ssp_cam091_ms45.Trim();
                lobHoja.Cells[i, 93] = lobReg.Ssp_cam092_ms45.Trim();
                lobHoja.Cells[i, 94] = lobReg.Ssp_cam093_ms45.Trim();
                lobHoja.Cells[i, 95] = lobReg.Ssp_cam094_ms45.Trim();
                lobHoja.Cells[i, 96] = lobReg.Ssp_cam095_ms45.Trim();
                lobHoja.Cells[i, 97] = lobReg.Ssp_cam096_ms45.Trim();
                lobHoja.Cells[i, 98] = lobReg.Ssp_cam097_ms45.Trim();
                lobHoja.Cells[i, 99] = lobReg.Ssp_cam098_ms45.Trim();
                lobHoja.Cells[i, 100] = lobReg.Ssp_cam099_ms45.Trim();
                lobHoja.Cells[i, 101] = lobReg.Ssp_cam100_ms45.Trim();
                lobHoja.Cells[i, 102] = lobReg.Ssp_cam101_ms45.Trim();
                lobHoja.Cells[i, 103] = lobReg.Ssp_cam102_ms45.Trim();
                lobHoja.Cells[i, 104] = lobReg.Ssp_cam103_ms45.Trim();
                lobHoja.Cells[i, 105] = lobReg.Ssp_cam104_ms45.Trim();
                lobHoja.Cells[i, 106] = lobReg.Ssp_cam105_ms45.Trim();
                lobHoja.Cells[i, 107] = lobReg.Ssp_cam106_ms45.Trim();
                lobHoja.Cells[i, 108] = lobReg.Ssp_cam107_ms45.Trim();
                lobHoja.Cells[i, 109] = lobReg.Ssp_cam108_ms45.Trim();
                lobHoja.Cells[i, 110] = lobReg.Ssp_cam109_ms45.Trim();
                lobHoja.Cells[i, 111] = lobReg.Ssp_cam110_ms45.Trim();
                lobHoja.Cells[i, 112] = lobReg.Ssp_cam111_ms45.Trim();
                lobHoja.Cells[i, 113] = lobReg.Ssp_cam112_ms45.Trim();
                lobHoja.Cells[i, 114] = lobReg.Ssp_cam113_ms45.Trim();
                lobHoja.Cells[i, 115] = lobReg.Ssp_cam114_ms45.Trim();
                lobHoja.Cells[i, 116] = lobReg.Ssp_cam115_ms45.Trim();
                lobHoja.Cells[i, 117] = lobReg.Ssp_cam116_ms45.Trim();
                lobHoja.Cells[i, 118] = lobReg.Ssp_cam117_ms45.Trim();
                lobHoja.Cells[i, 119] = lobReg.Ssp_cam118_ms45.Trim();
                #endregion
                i++;
            }
            lobLibroTrabajo.SaveAs(@gcrExportarArchivoNombreyRuta, Excel.XlFileFormat.xlWorkbookNormal);
            lobLibroTrabajo.Close(true);
            lobApp.Quit();

            lobDlgAdd.Close();

            return llgreturn;
        }
        #endregion
        //---------------------------------------------------------------
        // EJECUTAR VALIDACION DE DATOS EN VISTA
        //---------------------------------------------------------------
        #region fcvIniciarValidacionDatos: Inicia el proceso de validacion de los datos en la vista
        /// <summary>
        /// <para>Inicia el proceso de validacion de los datos en la vista</para>
        /// </summary>
        private void fcvIniciarValidacionDatos()
        {
            if (vm.TmpG2ListaBrow.Count == 0) { MessageBox.Show("No hay datos para validar"); return; }
            if (String.IsNullOrWhiteSpace(this.txtG1Ssp_codper_peri.Text)) { MessageBox.Show("Debe seleccionar un rango periodo de datos."); return; }
            //if (String.IsNullOrWhiteSpace(this.txtG1Sia_codeps_teps.Text)) { MessageBox.Show("Debe seleccionar un codigo de EPS."); return; }

            String lcrCodigoFuente = fcrCargarCodigoFuente();
            var larListaDll = new List<String>();
            larListaDll.Add("System.dll");
            larListaDll.Add("System.Data.Entity.dll");
            larListaDll.Add("Datos.dll");
            vm.tmpLogError = new List<LogErrores>();
            gnuSecuencialErrores = 0;

            this.grdVistaErrores.Visibility = Visibility.Visible;
            this.txtErrorCompiler.Visibility = Visibility.Collapsed;
            this.txtErrorCompiler.Foreground = Brushes.Blue;

            gobEnsamblado = Compilador.fobCompilarEnsamblado("C#", lcrCodigoFuente, larListaDll);

            if (flgCargarInstanciaInterface())
            {
                this.objDataGridErrores.ItemsSource = null;
                flgEjecutarScriptsValidacion();
                flgFiltroDataGridErrores();
                //this.objDataGridErrores.ItemsSource = gobObjVModelo.tmpLogError;

                if (vm.tmpLogError.Count > 0 && glgVistaEtiquetaEstadoVisible == false)
                {
                    fcvActivarVistaErroresValid();
                }
                else 
                {
                    MessageBox.Show("Validación realizada con exito!, no existen errores.");
                }
            }
            else
            {
                this.grdVistaErrores.Visibility = Visibility.Collapsed;
                this.txtErrorCompiler.Visibility = Visibility.Visible;
                this.txtErrorCompiler.Foreground = Brushes.Red;
                this.lblTituloEtiqueta.Text = "Errores al compilar funciones...";

                foreach (CompilerError CompErr in gobEnsamblado.Errors)
                {
                    this.txtErrorCompiler.Text = this.txtErrorCompiler.Text +
                                                "Número de línea " + CompErr.Line +
                                                ", Número de error: " + CompErr.ErrorNumber +
                                                ", '" + CompErr.ErrorText + ";" +
                                                Environment.NewLine + Environment.NewLine;
                }
                if (glgVistaEtiquetaEstadoVisible == false)
                {
                    fcvActivarVistaErroresValid();
                }
            }

        }
        #endregion
        #region flgEjecutarScriptsValidacion: Ejecuta los scripts de validación
        /// <summary>
        /// <para>Ejecuta los scripts de validación para encontrar inconsistencia en los datos</para>
        /// </summary>
        private bool flgEjecutarScriptsValidacion()
        {
            //- cargar parametros
            var llgreturn = true;
            gobParam.FechaIniPeriodo = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecini_peri.Text);
            gobParam.FechaFinPeriodo = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecfin_peri.Text);
            gobParam.CodigoEps       = this.txtG1Sia_codeps_teps.Text;
            gobParam.FechaFormato    = this.txtG1Ssp_forfec_sscf.Text;
            gobParam.FechaSeparador  = this.txtG1Ssp_sepfec_sscf.Text == "1" ? "/" : "-";
            gobParam.CodigoPlantilla = this.txtG1Sis_secreg_siva.Text;
            gobParam.CodigoPeriodo   = this.txtG1Ssp_codper_peri.Text;
            gobParam.OrigenDatos     = gcrOrigenDatosCargados;   
            this.lblTituloEtiqueta.Text = "Resultados validación de datos...";

            // Mostrar la Barra de progreso
            DialogProgressBar dlg = new DialogProgressBar();
            dlg.Owner = this;
            int lnuValorInicio = 1;
            dlg.EjecutarHiloDeTrabajo(lnuValorInicio, fcvEjecutarScriptsValidacion);

            return llgreturn;
        }
        public void fcvEjecutarScriptsValidacion(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker luxWorker = (BackgroundWorker)sender;

            //this.objDataGrid.ItemsSource = null;
            var lnuProgreso         = 0;
            var lnuPorcentaje       = 0;
            var lnuPorcentajeAux    = 0;
            var lnutotalRegistros   = vm.TmpG2ListaBrow.Count;
            IRegistroError lobRefIRegistroError = new RefIRegistroError();

            foreach (var lobReg in vm.TmpG2ListaBrow)
            {
                lnuProgreso++;

                if (lobReg.BoolEstado == true)
                {
                    lnuPorcentaje = Funciones.fnuPorcentaje(lnuProgreso, lnutotalRegistros);

                    String lcrMsg = "Validando datos en la vista {0}%...";
                    lcrMsg = String.Format(lcrMsg, lnuPorcentaje);

                    lobReg.Ssp_niverr_ms45  = String.Empty;
                    lobReg.Ssp_toterr_ms45  = 0;
                    tmpRegActMS4505         = lobReg;
                    fcvEjecutarScripts(lobRefIRegistroError, lobReg, lobReg.Ssp_ideaux_ns45);
                    // Reportar avance del proceso
                    if ((lnuPorcentaje - lnuPorcentajeAux) >= 1 || lnuPorcentaje>=99)
                    {
                        luxWorker.ReportProgress(lnuPorcentaje, lcrMsg);
                        lnuPorcentajeAux = lnuPorcentaje;
                    }
                }
            }
        }
        #endregion
        #region fcvEjecutarScripts: Ejecutar Scrips de validación
        /// <summary>
        /// <para>Ejecutar Scrips de validación</para>
        /// </summary>
        private void fcvEjecutarScripts(IRegistroError tobIRegistroError, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro)
        {
            fcvEjecutarScripts0029(tobIRegistroError, tobRegistro, tnuNumeroRegistro);
            fcvEjecutarScripts3059(tobIRegistroError, tobRegistro, tnuNumeroRegistro);
            fcvEjecutarScripts6089(tobIRegistroError, tobRegistro, tnuNumeroRegistro);
            fcvEjecutarScripts90118(tobIRegistroError, tobRegistro, tnuNumeroRegistro);
        }
        #endregion
        #region fcvEjecutarScripts0029: Ejecutar Scrips de validación campos desde 0 a 29
        /// <summary>
        /// <para>Ejecutar Scrips de validación campos desde 0 a 29</para>
        /// </summary>
        private void fcvEjecutarScripts0029(IRegistroError tobIRegistroError, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro)
        {
            #region Campos 0 al 29
            //--------------------------------------------------
            // 0. Tipo de registro
            //--------------------------------------------------
            if (oAppICampo000 != null) { oAppICampo000.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 1. Consecutivo de registro
            //--------------------------------------------------
            if (oAppICampo001 != null) { oAppICampo001.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 2. Código de habilitación IPS primaria
            //--------------------------------------------------
            if (oAppICampo002 != null) { oAppICampo002.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 3. Tipo de identificación del usuario
            //--------------------------------------------------
            if (oAppICampo003 != null) { oAppICampo003.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 4. Numero de identificación del usuario
            //--------------------------------------------------
            if (oAppICampo004 != null) { oAppICampo004.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 5
            //--------------------------------------------------
            if (oAppICampo005 != null) { oAppICampo005.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 6
            //--------------------------------------------------
            if (oAppICampo006 != null) { oAppICampo006.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 7
            //--------------------------------------------------
            if (oAppICampo007 != null) { oAppICampo007.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 8
            //--------------------------------------------------
            if (oAppICampo008 != null) { oAppICampo008.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 9
            //--------------------------------------------------
            if (oAppICampo009 != null) { oAppICampo009.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 10
            //--------------------------------------------------
            if (oAppICampo010 != null) { oAppICampo010.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 11
            //--------------------------------------------------
            if (oAppICampo011 != null) { oAppICampo011.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 12
            //--------------------------------------------------
            if (oAppICampo012 != null) { oAppICampo012.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 13
            //--------------------------------------------------
            if (oAppICampo013 != null) { oAppICampo013.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 14
            //--------------------------------------------------
            if (oAppICampo014 != null) { oAppICampo014.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 15
            //--------------------------------------------------
            if (oAppICampo015 != null) { oAppICampo015.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 16
            //--------------------------------------------------
            if (oAppICampo016 != null) { oAppICampo016.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 17
            //--------------------------------------------------
            if (oAppICampo017 != null) { oAppICampo017.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 18
            //--------------------------------------------------
            if (oAppICampo018 != null) { oAppICampo018.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 19
            //--------------------------------------------------
            if (oAppICampo019 != null) { oAppICampo019.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 20
            //--------------------------------------------------
            if (oAppICampo020 != null) { oAppICampo020.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 21
            //--------------------------------------------------
            if (oAppICampo021 != null) { oAppICampo021.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 22
            //--------------------------------------------------
            if (oAppICampo022 != null) { oAppICampo022.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 23
            //--------------------------------------------------
            if (oAppICampo023 != null) { oAppICampo023.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 24
            //--------------------------------------------------
            if (oAppICampo024 != null) { oAppICampo024.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 25
            //--------------------------------------------------
            if (oAppICampo025 != null) { oAppICampo025.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 26
            //--------------------------------------------------
            if (oAppICampo026 != null) { oAppICampo026.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 27
            //--------------------------------------------------
            if (oAppICampo027 != null) { oAppICampo027.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 28
            //--------------------------------------------------
            if (oAppICampo028 != null) { oAppICampo028.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 29
            //--------------------------------------------------
            if (oAppICampo029 != null) { oAppICampo029.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            #endregion
        }
        #endregion
        #region fcvEjecutarScripts3059: Ejecutar Scrips de validación campos desde 30 a 59
        /// <summary>
        /// <para>Ejecutar Scrips de validación campos desde 30 a 59</para>
        /// </summary>
        private void fcvEjecutarScripts3059(IRegistroError tobIRegistroError, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro)
        {
            #region Campos 30 al 59
            //--------------------------------------------------
            //- 30
            //--------------------------------------------------
            if (oAppICampo030 != null) { oAppICampo030.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 31
            //--------------------------------------------------
            if (oAppICampo031 != null) { oAppICampo031.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 32
            //--------------------------------------------------
            if (oAppICampo032 != null) { oAppICampo032.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 33
            //--------------------------------------------------
            if (oAppICampo033 != null) { oAppICampo033.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 34
            //--------------------------------------------------
            if (oAppICampo034 != null) { oAppICampo034.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 35
            //--------------------------------------------------
            if (oAppICampo035 != null) { oAppICampo035.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 36
            //--------------------------------------------------
            if (oAppICampo036 != null) { oAppICampo036.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 37
            //--------------------------------------------------
            if (oAppICampo037 != null) { oAppICampo037.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 38
            //--------------------------------------------------
            if (oAppICampo038 != null) { oAppICampo038.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 39
            //--------------------------------------------------
            if (oAppICampo039 != null) { oAppICampo039.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 40
            //--------------------------------------------------
            if (oAppICampo040 != null) { oAppICampo040.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 41
            //--------------------------------------------------
            if (oAppICampo041 != null) { oAppICampo041.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 42
            //--------------------------------------------------
            if (oAppICampo042 != null) { oAppICampo042.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 43
            //--------------------------------------------------
            if (oAppICampo043 != null) { oAppICampo043.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 44
            //--------------------------------------------------
            if (oAppICampo044 != null) { oAppICampo044.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 45
            //--------------------------------------------------
            if (oAppICampo045 != null) { oAppICampo045.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 46
            //--------------------------------------------------
            if (oAppICampo046 != null) { oAppICampo046.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 47
            //--------------------------------------------------
            if (oAppICampo047 != null) { oAppICampo047.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 48
            //--------------------------------------------------
            if (oAppICampo048 != null) { oAppICampo048.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 49
            //--------------------------------------------------
            if (oAppICampo049 != null) { oAppICampo049.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 50
            //--------------------------------------------------
            if (oAppICampo050 != null) { oAppICampo050.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 51
            //--------------------------------------------------
            if (oAppICampo051 != null) { oAppICampo051.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 52
            //--------------------------------------------------
            if (oAppICampo052 != null) { oAppICampo052.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 53
            //--------------------------------------------------
            if (oAppICampo053 != null) { oAppICampo053.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 54
            //--------------------------------------------------
            if (oAppICampo054 != null) { oAppICampo054.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 55
            //--------------------------------------------------
            if (oAppICampo055 != null) { oAppICampo055.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 56
            //--------------------------------------------------
            if (oAppICampo056 != null) { oAppICampo056.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 57
            //--------------------------------------------------
            if (oAppICampo057 != null) { oAppICampo057.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 58
            //--------------------------------------------------
            if (oAppICampo058 != null) { oAppICampo058.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 59
            //--------------------------------------------------
            if (oAppICampo059 != null) { oAppICampo059.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            #endregion
        }
        #endregion
        #region fcvEjecutarScripts6089: Ejecutar Scrips de validación campos desde 60 a 89
        /// <summary>
        /// <para>Ejecutar Scrips de validación campos desde 60 a 89</para>
        /// </summary>
        private void fcvEjecutarScripts6089(IRegistroError tobIRegistroError, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro)
        {
            #region Campos 60 al 89
            //--------------------------------------------------
            //- 60
            //--------------------------------------------------
            if (oAppICampo060 != null) { oAppICampo060.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 61
            //--------------------------------------------------
            if (oAppICampo061 != null) { oAppICampo061.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 62
            //--------------------------------------------------
            if (oAppICampo062 != null) { oAppICampo062.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 63
            //--------------------------------------------------
            if (oAppICampo063 != null) { oAppICampo063.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 64
            //--------------------------------------------------
            if (oAppICampo064 != null) { oAppICampo064.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 65
            //--------------------------------------------------
            if (oAppICampo065 != null) { oAppICampo065.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 66
            //--------------------------------------------------
            if (oAppICampo066 != null) { oAppICampo066.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 67
            //--------------------------------------------------
            if (oAppICampo067 != null) { oAppICampo067.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 68
            //--------------------------------------------------
            if (oAppICampo068 != null) { oAppICampo068.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 69
            //--------------------------------------------------
            if (oAppICampo069 != null) { oAppICampo069.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 70
            //--------------------------------------------------
            if (oAppICampo070 != null) { oAppICampo070.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 71
            //--------------------------------------------------
            if (oAppICampo071 != null) { oAppICampo071.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 72
            //--------------------------------------------------
            if (oAppICampo072 != null) { oAppICampo072.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 73
            //--------------------------------------------------
            if (oAppICampo073 != null) { oAppICampo073.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 74
            //--------------------------------------------------
            if (oAppICampo074 != null) { oAppICampo074.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 75
            //--------------------------------------------------
            if (oAppICampo075 != null) { oAppICampo075.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 76
            //--------------------------------------------------
            if (oAppICampo076 != null) { oAppICampo076.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 77
            //--------------------------------------------------
            if (oAppICampo077 != null) { oAppICampo077.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 78      
            //--------------------------------------------------
            if (oAppICampo078 != null) { oAppICampo078.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 79
            //--------------------------------------------------
            if (oAppICampo079 != null) { oAppICampo079.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 80
            //--------------------------------------------------
            if (oAppICampo080 != null) { oAppICampo080.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 81
            //--------------------------------------------------
            if (oAppICampo081 != null) { oAppICampo081.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 82
            //--------------------------------------------------
            if (oAppICampo082 != null) { oAppICampo082.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 83
            //--------------------------------------------------
            if (oAppICampo053 != null) { oAppICampo053.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 84
            //--------------------------------------------------
            if (oAppICampo084 != null) { oAppICampo084.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 85
            //--------------------------------------------------
            if (oAppICampo085 != null) { oAppICampo085.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 86
            //--------------------------------------------------
            if (oAppICampo086 != null) { oAppICampo086.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 87
            //--------------------------------------------------
            if (oAppICampo087 != null) { oAppICampo087.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 88
            //--------------------------------------------------
            if (oAppICampo088 != null) { oAppICampo088.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 89
            //--------------------------------------------------
            if (oAppICampo089 != null) { oAppICampo089.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            #endregion
        }
        #endregion
        #region fcvEjecutarScripts90118: Ejecutar Scrips de validación campos desde 90 a 118
        /// <summary>
        /// <para>Ejecutar Scrips de validación campos desde 90 a 118</para>
        /// </summary>
        private void fcvEjecutarScripts90118(IRegistroError tobIRegistroError, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro)
        {
            #region Campos 90 al 118
            //--------------------------------------------------
            //- 90
            //--------------------------------------------------
            if (oAppICampo090 != null) { oAppICampo090.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 91
            //--------------------------------------------------
            if (oAppICampo091 != null) { oAppICampo091.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 92
            //--------------------------------------------------
            if (oAppICampo092 != null) { oAppICampo092.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 93
            //--------------------------------------------------
            if (oAppICampo093 != null) { oAppICampo093.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 94
            //--------------------------------------------------
            if (oAppICampo094 != null) { oAppICampo094.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 95
            //--------------------------------------------------
            if (oAppICampo095 != null) { oAppICampo095.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 96
            //--------------------------------------------------
            if (oAppICampo096 != null) { oAppICampo096.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 97
            //--------------------------------------------------
            if (oAppICampo097 != null) { oAppICampo097.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 98
            //--------------------------------------------------
            if (oAppICampo098 != null) { oAppICampo098.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 99
            //--------------------------------------------------
            if (oAppICampo099 != null) { oAppICampo099.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 100
            //--------------------------------------------------
            if (oAppICampo100 != null) { oAppICampo100.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 101
            //--------------------------------------------------
            if (oAppICampo107 != null) { oAppICampo101.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 102
            //--------------------------------------------------
            if (oAppICampo102 != null) { oAppICampo102.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 103
            //--------------------------------------------------
            if (oAppICampo103 != null) { oAppICampo103.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 104
            //--------------------------------------------------
            if (oAppICampo104 != null) { oAppICampo104.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 105
            //--------------------------------------------------
            if (oAppICampo105 != null) { oAppICampo105.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 106
            //--------------------------------------------------
            if (oAppICampo106 != null) { oAppICampo106.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 107
            //--------------------------------------------------
            if (oAppICampo107 != null) { oAppICampo107.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 108
            //--------------------------------------------------
            if (oAppICampo108 != null) { oAppICampo108.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 109
            //--------------------------------------------------
            if (oAppICampo109 != null) { oAppICampo109.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 110
            //--------------------------------------------------
            if (oAppICampo110 != null) { oAppICampo110.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 111
            //--------------------------------------------------
            if (oAppICampo111 != null) { oAppICampo111.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 112
            //--------------------------------------------------
            if (oAppICampo112 != null) { oAppICampo112.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 113
            //--------------------------------------------------
            if (oAppICampo113 != null) { oAppICampo113.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 114
            //--------------------------------------------------
            if (oAppICampo114 != null) { oAppICampo114.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 115
            //--------------------------------------------------
            if (oAppICampo115 != null) { oAppICampo115.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 116
            //--------------------------------------------------
            if (oAppICampo116 != null) { oAppICampo116.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 117
            //--------------------------------------------------
            if (oAppICampo117 != null) { oAppICampo117.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 118
            //--------------------------------------------------
            if (oAppICampo118 != null) { oAppICampo118.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            #endregion
        }
        #endregion
        #region RefIRegistroError: Interface para llamar por referencia desde IRegistroError
        /// <summary>
        /// <para>Interface para llamar por referencia desde IRegistroError</para>
        /// </summary>
        internal class RefIRegistroError : IRegistroError
        {
            public void AddRegistroError(String tcrCodigoError, String tcrMensaje, int tnuNumeroRegistro, 
                                         int tcrNumeroCampo, String tcrTituloCampo, String tcrValorCampo, String tcrNivelError)
            {
                String lcrllave1 = String.Empty;
                String lcrllave2 = String.Empty;
                String lcrllave3 = String.Empty;
                String lcrllave4 = String.Empty;
                String lcrllave5 = String.Empty;
                String lcrllave6 = String.Empty;

                var lobRegistro = new LogErrores();
                //- datos del error
                lobRegistro.Secuencial      = gnuSecuencialErrores;
                lobRegistro.IdRegistro      = tnuNumeroRegistro.ToString();
                lobRegistro.NombreCampo     = tcrTituloCampo;
                lobRegistro.ValorCampo      = tcrValorCampo;
                lobRegistro.CodigoError     = tcrCodigoError;
                lobRegistro.MensajeError    = tcrMensaje;
                lobRegistro.NivelError      = tcrNivelError;
                // Datos del registro
                lobRegistro.IdUnicoUsuario  = tmpRegActMS4505.Sia_idesec_usua;
                lobRegistro.IdUsuario       = tmpRegActMS4505.Ssp_cam004_ms45;
                lobRegistro.PApellido       = tmpRegActMS4505.Ssp_cam005_ms45;
                lobRegistro.SApellido       = tmpRegActMS4505.Ssp_cam006_ms45;
                lobRegistro.PNombre         = tmpRegActMS4505.Ssp_cam007_ms45;
                lobRegistro.SNombre         = tmpRegActMS4505.Ssp_cam008_ms45;
                // llave de busqueda 
                lcrllave1 = tmpRegActMS4505.Ssp_ideaux_ns45.ToString().Trim() + " ";
                lcrllave2 = tmpRegActMS4505.Ssp_cam004_ms45 != null ? tmpRegActMS4505.Ssp_cam004_ms45.ToUpper() + " " : String.Empty;
                lcrllave3 = tmpRegActMS4505.Ssp_cam005_ms45 != null ? tmpRegActMS4505.Ssp_cam005_ms45.ToUpper() + " " : String.Empty;
                lcrllave4 = tmpRegActMS4505.Ssp_cam006_ms45 != null ? tmpRegActMS4505.Ssp_cam006_ms45.ToUpper() + " " : String.Empty;
                lcrllave5 = tmpRegActMS4505.Ssp_cam007_ms45 != null ? tmpRegActMS4505.Ssp_cam007_ms45.ToUpper() + " " : String.Empty;
                lcrllave6 = tmpRegActMS4505.Ssp_cam008_ms45 != null ? tmpRegActMS4505.Ssp_cam008_ms45.ToUpper() : String.Empty;

                lobRegistro.LlaveBusqueda = lcrllave1 + lcrllave2 + lcrllave3 + lcrllave4 + lcrllave5 +
                                            lcrllave6 + " " + tcrTituloCampo.ToUpper() + " " + tcrCodigoError + " " + tcrMensaje;

                // adicionar al temporal de errores
                vm.tmpLogError.Add(lobRegistro);
                gnuSecuencialErrores++;

                var lobReg = vm.TmpG2ListaBrow.FirstOrDefault(x => x.Ssp_ideaux_ns45 == tnuNumeroRegistro);
                lobReg.Ssp_toterr_ms45++;
                lobReg.Estado = "ERRADO";
                //lobReg.BoolEstado = false;
                if (!String.IsNullOrWhiteSpace(tcrNivelError))
                {
                    if (!String.IsNullOrWhiteSpace(lobReg.Ssp_niverr_ms45))
                    {
                        if (Convert.ToInt32(tcrNivelError) > Convert.ToInt32(lobReg.Ssp_niverr_ms45))
                        {
                            lobReg.Ssp_niverr_ms45 = tcrNivelError;
                        }
                    }
                    else 
                    {
                        lobReg.Ssp_niverr_ms45 = tcrNivelError;
                    }
                }
            }
        }
        #endregion
        #region flgCargarInstanciaInterface: Cargar las interface para ser ejcutadas
        /// <summary>
        /// <para>Cargar las interface para ser ejcutadas</para>
        /// </summary>
        private static bool flgCargarInstanciaInterface()
        {
            var llgReturn = false;
            if (gobEnsamblado.Errors == null || gobEnsamblado.Errors.Count == 0)
            {
                var lobScriptTypes = Compilador.farGetTypesInterface(gobEnsamblado.CompiledAssembly, typeof(IValidador4505));
                llgReturn = lobScriptTypes != null ? true : false;

                foreach (var lobScriptType in lobScriptTypes)
                {
                    gobRefoAppType = lobScriptType;

                    llgReturn = flgRefAppICampo029(lobScriptType.Name);
                    if (!llgReturn)
                    {
                        llgReturn = flgRefAppICampo3059(lobScriptType.Name);
                    }
                    if (!llgReturn)
                    {
                        llgReturn = flgRefAppICampo6089(lobScriptType.Name);
                    }
                    if (!llgReturn)
                    {
                        llgReturn = flgRefAppICampo90118(lobScriptType.Name);
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgRefAppICampo029: Referencia validacion Rango 0 a 29
        /// <summary>
        /// <para>Referencia validacion Rango 0 a 29</para>
        /// </summary>
        public static bool flgRefAppICampo029(String tcrNombreCampo)
        {
            var llgReturn = false;
            #region Campos desde 0 a 29
            if (!String.IsNullOrWhiteSpace(tcrNombreCampo))
            {
                switch (tcrNombreCampo)
                {
                    case "Ssp_cam000_ms45":
                        llgReturn = true;
                        oAppICampo000 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam001_ms45":
                        llgReturn = true;
                        oAppICampo001 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam002_ms45":
                        llgReturn = true;
                        oAppICampo002 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam003_ms45":
                        llgReturn = true;
                        oAppICampo003 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam004_ms45":
                        llgReturn = true;
                        oAppICampo004 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam005_ms45":
                        llgReturn = true;
                        oAppICampo005 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam006_ms45":
                        llgReturn = true;
                        oAppICampo006 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam007_ms45":
                        llgReturn = true;
                        oAppICampo007 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam008_ms45":
                        llgReturn = true;
                        oAppICampo008 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam009_ms45":
                        llgReturn = true;
                        oAppICampo009 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam010_ms45":
                        llgReturn = true;
                        oAppICampo010 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam011_ms45":
                        llgReturn = true;
                        oAppICampo011 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam012_ms45":
                        llgReturn = true;
                        oAppICampo012 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam013_ms45":
                        llgReturn = true;
                        oAppICampo013 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam014_ms45":
                        llgReturn = true;
                        oAppICampo014 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam015_ms45":
                        llgReturn = true;
                        oAppICampo015 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam016_ms45":
                        llgReturn = true;
                        oAppICampo016 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam017_ms45":
                        llgReturn = true;
                        oAppICampo017 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam018_ms45":
                        llgReturn = true;
                        oAppICampo018 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam019_ms45":
                        llgReturn = true;
                        oAppICampo019 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam020_ms45":
                        llgReturn = true;
                        oAppICampo020 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam021_ms45":
                        llgReturn = true;
                        oAppICampo021 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam022_ms45":
                        llgReturn = true;
                        oAppICampo022 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam023_ms45":
                        llgReturn = true;
                        oAppICampo023 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam024_ms45":
                        llgReturn = true;
                        oAppICampo024 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam025_ms45":
                        llgReturn = true;
                        oAppICampo025 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam026_ms45":
                        llgReturn = true;
                        oAppICampo026 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam027_ms45":
                        llgReturn = true;
                        oAppICampo027 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam028_ms45":
                        llgReturn = true;
                        oAppICampo028 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam029_ms45":
                        llgReturn = true;
                        oAppICampo029 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgRefAppICampo3059: Referencia validacion Rango 30 a 59
        /// <summary>
        /// <para>Referencia validacion Rango 30 a 59</para>
        /// </summary>
        public static bool flgRefAppICampo3059(String tcrNombreCampo)
        {
            var llgReturn = false;
            #region Campos desde 30 a 59
            if (!String.IsNullOrWhiteSpace(tcrNombreCampo))
            {
                switch (tcrNombreCampo)
                {
                    case "Ssp_cam030_ms45":
                        llgReturn = true;
                        oAppICampo030 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam031_ms45":
                        llgReturn = true;
                        oAppICampo031 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam032_ms45":
                        llgReturn = true;
                        oAppICampo032 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam033_ms45":
                        llgReturn = true;
                        oAppICampo033 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam034_ms45":
                        llgReturn = true;
                        oAppICampo034 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam035_ms45":
                        llgReturn = true;
                        oAppICampo035 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam036_ms45":
                        llgReturn = true;
                        oAppICampo036 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam037_ms45":
                        llgReturn = true;
                        oAppICampo037 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam038_ms45":
                        llgReturn = true;
                        oAppICampo038 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam039_ms45":
                        llgReturn = true;
                        oAppICampo039 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam040_ms45":
                        llgReturn = true;
                        oAppICampo040 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam041_ms45":
                        llgReturn = true;
                        oAppICampo041 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam042_ms45":
                        llgReturn = true;
                        oAppICampo042 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam043_ms45":
                        llgReturn = true;
                        oAppICampo043 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam044_ms45":
                        llgReturn = true;
                        oAppICampo044 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam045_ms45":
                        llgReturn = true;
                        oAppICampo045 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam046_ms45":
                        llgReturn = true;
                        oAppICampo046 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam047_ms45":
                        llgReturn = true;
                        oAppICampo047 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam048_ms45":
                        llgReturn = true;
                        oAppICampo048 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam049_ms45":
                        llgReturn = true;
                        oAppICampo049 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam050_ms45":
                        llgReturn = true;
                        oAppICampo050 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam051_ms45":
                        llgReturn = true;
                        oAppICampo051 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam052_ms45":
                        llgReturn = true;
                        oAppICampo052 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam053_ms45":
                        llgReturn = true;
                        oAppICampo053 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam054_ms45":
                        llgReturn = true;
                        oAppICampo054 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam055_ms45":
                        llgReturn = true;
                        oAppICampo055 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam056_ms45":
                        llgReturn = true;
                        oAppICampo056 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam057_ms45":
                        llgReturn = true;
                        oAppICampo057 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam058_ms45":
                        llgReturn = true;
                        oAppICampo058 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam059_ms45":
                        llgReturn = true;
                        oAppICampo059 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgRefAppICampo6089: Referencia validacion Rango 60 a 89
        /// <summary>
        /// <para>Referencia validacion Rango 60 a 89</para>
        /// </summary>
        public static bool flgRefAppICampo6089(String tcrNombreCampo)
        {
            var llgReturn = false;
            #region Campos desde 60 a 89
            if (!String.IsNullOrWhiteSpace(tcrNombreCampo))
            {
                switch (tcrNombreCampo)
                {
                    case "Ssp_cam060_ms45":
                        llgReturn = true;
                        oAppICampo060 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam061_ms45":
                        llgReturn = true;
                        oAppICampo061 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam062_ms45":
                        llgReturn = true;
                        oAppICampo062 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam063_ms45":
                        llgReturn = true;
                        oAppICampo063 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam064_ms45":
                        llgReturn = true;
                        oAppICampo064 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam065_ms45":
                        llgReturn = true;
                        oAppICampo065 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam066_ms45":
                        llgReturn = true;
                        oAppICampo066 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam067_ms45":
                        llgReturn = true;
                        oAppICampo067 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam068_ms45":
                        llgReturn = true;
                        oAppICampo068 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam069_ms45":
                        llgReturn = true;
                        oAppICampo069 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam070_ms45":
                        llgReturn = true;
                        oAppICampo070 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam071_ms45":
                        llgReturn = true;
                        oAppICampo071 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam072_ms45":
                        llgReturn = true;
                        oAppICampo072 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam073_ms45":
                        llgReturn = true;
                        oAppICampo073 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam074_ms45":
                        llgReturn = true;
                        oAppICampo074 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam075_ms45":
                        llgReturn = true;
                        oAppICampo075 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam076_ms45":
                        llgReturn = true;
                        oAppICampo076 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam077_ms45":
                        llgReturn = true;
                        oAppICampo077 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam078_ms45":
                        llgReturn = true;
                        oAppICampo078 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam079_ms45":
                        llgReturn = true;
                        oAppICampo079 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam080_ms45":
                        llgReturn = true;
                        oAppICampo080 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam081_ms45":
                        llgReturn = true;
                        oAppICampo081 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam082_ms45":
                        llgReturn = true;
                        oAppICampo082 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam083_ms45":
                        llgReturn = true;
                        oAppICampo083 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam084_ms45":
                        llgReturn = true;
                        oAppICampo084 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam085_ms45":
                        llgReturn = true;
                        oAppICampo085 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam086_ms45":
                        llgReturn = true;
                        oAppICampo086 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam087_ms45":
                        llgReturn = true;
                        oAppICampo087 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam088_ms45":
                        llgReturn = true;
                        oAppICampo058 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam089_ms45":
                        llgReturn = true;
                        oAppICampo089 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgRefAppICampo6089: Referencia validacion Rango 90 a 118
        /// <summary>
        /// <para>Referencia validacion Rango 90 a 118</para>
        /// </summary>
        public static bool flgRefAppICampo90118(String tcrNombreCampo)
        {
            var llgReturn = false;
            #region Campos desde 90 a 118
            if (!String.IsNullOrWhiteSpace(tcrNombreCampo))
            {
                switch (tcrNombreCampo)
                {
                    case "Ssp_cam090_ms45":
                        llgReturn = true;
                        oAppICampo060 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam091_ms45":
                        llgReturn = true;
                        oAppICampo091 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam092_ms45":
                        llgReturn = true;
                        oAppICampo092 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam093_ms45":
                        llgReturn = true;
                        oAppICampo093 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam094_ms45":
                        llgReturn = true;
                        oAppICampo094 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam095_ms45":
                        llgReturn = true;
                        oAppICampo095 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam096_ms45":
                        llgReturn = true;
                        oAppICampo096 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam097_ms45":
                        llgReturn = true;
                        oAppICampo097 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam098_ms45":
                        llgReturn = true;
                        oAppICampo098 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam099_ms45":
                        llgReturn = true;
                        oAppICampo099 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam100_ms45":
                        llgReturn = true;
                        oAppICampo100 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam101_ms45":
                        llgReturn = true;
                        oAppICampo101 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam102_ms45":
                        llgReturn = true;
                        oAppICampo102 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam103_ms45":
                        llgReturn = true;
                        oAppICampo103 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam104_ms45":
                        llgReturn = true;
                        oAppICampo104 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam105_ms45":
                        llgReturn = true;
                        oAppICampo105 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam106_ms45":
                        llgReturn = true;
                        oAppICampo106 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam107_ms45":
                        llgReturn = true;
                        oAppICampo107 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam108_ms45":
                        llgReturn = true;
                        oAppICampo108 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam109_ms45":
                        llgReturn = true;
                        oAppICampo109 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam110_ms45":
                        llgReturn = true;
                        oAppICampo110 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam111_ms45":
                        llgReturn = true;
                        oAppICampo111 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam112_ms45":
                        llgReturn = true;
                        oAppICampo112 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam113_ms45":
                        llgReturn = true;
                        oAppICampo113 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam114_ms45":
                        llgReturn = true;
                        oAppICampo114 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam115_ms45":
                        llgReturn = true;
                        oAppICampo115 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam116_ms45":
                        llgReturn = true;
                        oAppICampo116 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam117_ms45":
                        llgReturn = true;
                        oAppICampo117 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                    case "Ssp_cam118_ms45":
                        llgReturn = true;
                        oAppICampo118 = (Activator.CreateInstance(gobRefoAppType)) as IValidador4505;
                        break;

                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region fcrCargarCodigoFuente: Carga el codigo fuente desde la base de datos
        /// <summary>
        /// <para>Carga el codigo fuente desde la base de datos</para>
        /// </summary>
        private String fcrCargarCodigoFuente()
        {
            //var lobTemp = SISValidarCodigo.fobRegBuscarSismadeplavalidTemp(txtG1Sis_secreg_siva.Text);
            var lobTemp = ModeloSismadeplavalid.flsListaSismadeplavalid(txtG1Sis_secreg_siva.Text);
            var lcrCodigo = String.Empty;

            foreach (var lobreg in lobTemp)
            {
                if (lobreg.Sis_estreg_sivd == "1")
                {
                    lcrCodigo += lobreg.Sis_codval_sivd.Trim()+"\n";
                }
            }
            if (!String.IsNullOrWhiteSpace(lcrCodigo))
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("using System;              ");
                sb.AppendLine("using System.Text;         ");
                sb.AppendLine("using Sistema.Utilidades;  ");
                sb.AppendLine("using Sistema.Modelo;      ");
                sb.AppendLine("using Sistema.Clases;      ");
                sb.AppendLine("using Sistema.Validacion;  ");
                sb.AppendLine("using Datos.Modelos;       ");
                sb.AppendLine("namespace Validacion");
                sb.AppendLine("{");
                sb.AppendLine(lcrCodigo);
                sb.AppendLine("}");

                lcrCodigo = sb.ToString();
            }

            return lcrCodigo;
        }
        #endregion
        //---------------------------------------------------------------
        // GUARDAR DATOS EN BASE DE DATOS 4505
        //---------------------------------------------------------------
        #region flgVerificarDatosParaBaseDeDatos: Verificar que si es posible adicionar los datos a base de datos
        /// <summary>
        /// <para>Verificar que si es posible adicionar los datos a base de datos</para>
        /// </summary>
        private bool flgVerificarDatosParaBaseDeDatos()
        {
            //- cargar parametros
            var llgreturn = true;
            glgObjetosCargados = false;

            // Verificar datos
            gcrCodigoPeriodo    = this.txtG1Ssp_codper_peri.Text;
            gcrPeriodoMes       = Funciones.fcrComponenteFecha(Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecini_peri.Text), "MES");
            gcrPeriodoAño       = Funciones.fcrComponenteFecha(Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecini_peri.Text), "AÑO");
            gcrFechaFormato     = this.txtG1Ssp_forfec_sscf.Text;
            gcrFechaSeparador   = this.txtG1Ssp_sepfec_sscf.Text == "1" ? "/" : "-";

            // Ir al primer registro
            if (this.objDataGrid.Items.Count > 0)
            {
                object item = objDataGrid.Items[0];
                objDataGrid.SelectedItem = item;
                objDataGrid.ScrollIntoView(item);
            }

            // Vista barra de progreso
            DialogProgressBar dlg = new DialogProgressBar();
            dlg.Owner = this;
            int lnuValorInicio = 1;
            dlg.EjecutarHiloDeTrabajo(lnuValorInicio, fcvVerificarRegistros);
            CollectionViewSource.GetDefaultView(this.objDataGrid.ItemsSource).Refresh();

            return llgreturn;
        }
        #endregion
        #region fcvVerificarRegistros: Ejecuta una verificacion sencilla a los registros
        /// <summary>
        /// <para>Ejecuta una verificacion sencilla a los registros</para>
        /// </summary>
        public void fcvVerificarRegistros(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker luxWorker = (BackgroundWorker)sender;
            
            var lnuProgreso         = 0;
            var lnuPorcentaje       = 0;
            var lnuPorcentajeAux    = 0;
            var lnutotalRegistros   = vm.TmpG2ListaBrow.Count;
            var lobRegMs4505        = new EFsptablmsres4505();
            var lobRegNs4505        = new EFsptablnsres4505();
            var lobRegUsuAtendido   = new EFsiausuarioatend();
            var lcrCodigoGen        = String.Empty;

            foreach (var lobRegEx in vm.TmpG2ListaBrow)
            {
                lnuProgreso++;
                lnuPorcentaje = Funciones.fnuPorcentaje(lnuProgreso, lnutotalRegistros);
                String lcrMsg = "Verificando datos minimos registros {0}%...";
                lcrMsg = String.Format(lcrMsg, lnuPorcentaje);
                lobRegEx.NotaRegistro = "EXCLUIDO";
                lobRegEx.Estado = "EXCLUIDO";

                if (lobRegEx.BoolEstado == true)
                {
                    lobRegEx.Estado = "VERIFICADO-ERROR";
                    lobRegEx.NotaRegistro = String.Empty;
                    // Verificar que si es un registro valido
                    if (!String.IsNullOrWhiteSpace(lobRegEx.Ssp_cam004_ms45))
                    {
                        //Buscar en maestro de usuarios atendidos
                        lobRegUsuAtendido = SIAValidarCodigo.fobRegBuscarIuSiausuarioatendEx(lobRegEx.Ssp_cam004_ms45);
                        if (lobRegUsuAtendido == null)
                        {
                            lobRegEx.NotaRegistro = "- NUMERO DE IDENTIFICACION NO EXISTE EN MAESTRO DE USUARIOS ";
                            lobRegEx.BoolEstado = false;
                        }
                    }
                    else 
                    {
                        lobRegEx.NotaRegistro = "- NUMERO DE IDENTIFICACION VACIO ";
                        lobRegEx.BoolEstado = false;
                    }
                    // debe contener minimo los datos principales
                    if (lobRegEx.BoolEstado == true)
                    {
                        if (String.IsNullOrWhiteSpace(lobRegEx.Ssp_cam002_ms45) || String.IsNullOrWhiteSpace(lobRegEx.Ssp_cam003_ms45) ||
                            String.IsNullOrWhiteSpace(lobRegEx.Ssp_cam005_ms45) || String.IsNullOrWhiteSpace(lobRegEx.Ssp_cam007_ms45) ||
                            String.IsNullOrWhiteSpace(lobRegEx.Ssp_cam009_ms45) || String.IsNullOrWhiteSpace(lobRegEx.Ssp_cam010_ms45))
                        {
                            lobRegEx.NotaRegistro += "- DATOS OBLIGATORIOS SON INCONSISTENTES O NO EXISTE ALGUNO DE ELLOS ";
                            lobRegEx.BoolEstado = false;
                        }
                        else 
                        {
                            if (lobRegEx.Ssp_cam009_ms45.Trim().Length != 10)
                            {
                                lobRegEx.NotaRegistro += "- FECHA NACIMIENTO ERRADA ";
                                lobRegEx.BoolEstado = false;
                            }
                            else if (!Funciones.flgValidaFecha(gcrFechaFormato, gcrFechaSeparador, lobRegEx.Ssp_cam009_ms45))
                            {
                                lobRegEx.NotaRegistro += "- FECHA NACIMIENTO NO ES VALIDA ";
                                lobRegEx.BoolEstado = false;
                            }
                        }
                    }
                    lobRegEx.NotaRegistro = lobRegEx.BoolEstado == true ? "OK" : lobRegEx.NotaRegistro;
                    lobRegEx.Estado = lobRegEx.BoolEstado == true ? "VERIFICADO-OK" : lobRegEx.Estado;

                    // Reportar avance del proceso
                    if ((lnuPorcentaje - lnuPorcentajeAux) >= 1 || lnuPorcentaje >= 99)
                    {
                        luxWorker.ReportProgress(lnuPorcentaje, lcrMsg);
                        lnuPorcentajeAux = lnuPorcentaje;
                    }
                }
            }
            glgObjetosCargados = true;
            vm.glgSIS_DatosVerificados = true;
        }
        #endregion
        #region flgActualizarDatosEnBaseDeDatos: Guardar los datos en la base de datos
        /// <summary>
        /// <para>Guardar los datos en la base de datos</para>
        /// </summary>
        private bool flgActualizarDatosEnBaseDeDatos()
        {
            //- cargar parametros
            var llgreturn = true;
            glgObjetosCargados  = false;
            gcrCodigoPeriodo    = this.txtG1Ssp_codper_peri.Text;
            gcrPeriodoMes       = Funciones.fcrComponenteFecha(Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecini_peri.Text), "MES");
            gcrPeriodoAño       = Funciones.fcrComponenteFecha(Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecini_peri.Text), "AÑO");
            gcrFechaFormato     = this.txtG1Ssp_forfec_sscf.Text;
            gcrFechaSeparador   = this.txtG1Ssp_sepfec_sscf.Text == "1" ? "/" : "-";

            // Generar Id unica de los registros 
            if (gcrOrigenDatosCargados != "BDATOS")
            {
                DialogProgressBar dlg = new DialogProgressBar();
                dlg.Owner = this;
                int lnuValorInicio = 1;
                dlg.EjecutarHiloDeTrabajo(lnuValorInicio, fcvComplementarIdRegistros);
                //CollectionViewSource.GetDefaultView(this.objDataGrid.ItemsSource).Refresh();

            }
            // guardar datos
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Guardando datos...", "CENTRO");
            lobDlgAdd.Show();

            fcvGardarDatosEnBaseDeDatos();
            lobDlgAdd.Close();

            MessageBox.Show("Registros guardados con Éxito!!");
            return llgreturn;
        }
        #endregion
        #region fcvComplementarIdRegistros: Complementar los registros para actualizar en maestro
        /// <summary>
        /// <para>Complementar los registros para actualizar en maestro</para>
        /// </summary>
        public void fcvComplementarIdRegistros(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker luxWorker = (BackgroundWorker)sender;

            var lnuProgreso         = 0;
            var lnuPorcentaje       = 0;
            var lnuPorcentajeAux    = 0;
            var lnutotalRegistros   = vm.TmpG2ListaBrow.Count;
            var lobRegMs4505        = new EFsptablmsres4505();
            var lobRegNs4505        = new EFsptablnsres4505();
            var lobRegUsuAtendido   = new EFsiausuarioatend();
            var lcrCodigoGen        = String.Empty;
            var lcrllavePeriodo     = gcrPeriodoAño.Trim() + gcrPeriodoMes.Trim();

            foreach (var lobRegEx in vm.TmpG2ListaBrow)
            {
                lnuProgreso++;

                if (lobRegEx.BoolEstado == true)
                {
                    lnuPorcentaje = Funciones.fnuPorcentaje(lnuProgreso, lnutotalRegistros);
                    String lcrMsg = "Generando llave única de registros {0}%...";
                    lcrMsg = String.Format(lcrMsg, lnuPorcentaje);
                    //Buscar en maestro 4505
                    lobRegMs4505 = SSPValidarCodigo.fobRegBuscarSptablmsres4505Iu(lobRegEx.Ssp_cam004_ms45);
                    if (lobRegMs4505 != null)
                    {
                        lobRegEx.Sia_idesec_usua = lobRegMs4505.sia_idesec_usua.Trim();
                        lobRegEx.Ssp_cam001_ms45 = lobRegMs4505.ssp_cam001_ms45.Trim();
                        lobRegEx.Sia_codeps_teps = lobRegMs4505.sia_codeps_teps.Trim();
                        lobRegEx.Sis_estado_imaen = "M";
                    }
                    else 
                    {
                        // Marcar para adicionar
                        lobRegEx.Sis_estado_imaen = "A"; 
                        //Buscar en maestro de usuarios atendidos
                        lobRegUsuAtendido = SIAValidarCodigo.fobRegBuscarIuSiausuarioatendEx(lobRegEx.Ssp_cam004_ms45);
                        if (lobRegUsuAtendido != null)
                        {
                            lobRegEx.Sia_idesec_usua = lobRegUsuAtendido.sia_idesec_usua.Trim();
                            lobRegEx.Sia_codeps_teps = lobRegUsuAtendido.sia_codeps_teps.Trim();
                        }
                        else
                        {
                            lobRegEx.Sis_estado_imaen = "I"; 
                            lobRegEx.BoolEstado = false; // desmarcar para no incluir
                        }
                    }
                    // Reportar avance del proceso
                    if ((lnuPorcentaje - lnuPorcentajeAux) >= 1 || lnuPorcentaje >= 99)
                    {
                        luxWorker.ReportProgress(lnuPorcentaje, lcrMsg);
                        lnuPorcentajeAux = lnuPorcentaje;
                    }
                }
            }
            glgObjetosCargados = true;
            vm.glgSIS_DatosVerificados = true;
        }
        #endregion
        #region fcvGardarDatosEnBaseDeDatos: Guardar datos en base de datos
        /// <summary>
        /// <para>Guardar datos en base de datos</para>
        /// </summary>
        public void fcvGardarDatosEnBaseDeDatos()
        {
            var lnutotalRegistros   = vm.TmpG2ListaBrow.Count;
            var lobRegMs4505        = new ModeloSspRes4505();
            var lobRegUsuAtendido   = new EFsiausuarioatend();
            var lcrCodigoGen        = String.Empty;
            var lcrllavePeriodo     = gcrPeriodoAño.Trim() + gcrPeriodoMes.Trim();
            var lcrNuevoCodigo      = String.Empty;

            foreach (var lobReg in vm.TmpG2ListaBrow)
            {

                if (lobReg.BoolEstado == true && lobReg.NotaRegistro == "OK")
                {
                    // colocar aqui los datos del periodo codigo EPS ide del usuario y otros
                    lobReg.Ssp_codper_peri = gcrCodigoPeriodo;
                    lobReg.Sia_nroide_usua = lobReg.Ssp_cam004_ms45;
                    lobReg.Sia_codeps_teps = String.IsNullOrWhiteSpace(this.txtG1Sia_codeps_teps.Text) ? lobReg.Sia_codeps_teps : this.txtG1Sia_codeps_teps.Text;
                    lobRegMs4505 = new ModeloSspRes4505();

                    // Cargar datos en registro
                    #region Valores Variables
                    lobRegMs4505.Sia_idesec_usua = lobReg.Sia_idesec_usua;
                    lobRegMs4505.Sia_nroide_usua = lobReg.Sia_nroide_usua;
                    lobRegMs4505.Sia_codeps_teps = lobReg.Sia_codeps_teps;
                    lobRegMs4505.Ssp_cam000_ms45 = lobReg.Ssp_cam000_ms45;
                    lobRegMs4505.Ssp_cam001_ms45 = lobReg.Ssp_cam001_ms45;
                    lobRegMs4505.Ssp_cam002_ms45 = lobReg.Ssp_cam002_ms45;
                    lobRegMs4505.Ssp_cam003_ms45 = lobReg.Ssp_cam003_ms45;
                    lobRegMs4505.Ssp_cam004_ms45 = lobReg.Ssp_cam004_ms45;
                    lobRegMs4505.Ssp_cam005_ms45 = lobReg.Ssp_cam005_ms45;
                    lobRegMs4505.Ssp_cam006_ms45 = lobReg.Ssp_cam006_ms45;
                    lobRegMs4505.Ssp_cam007_ms45 = lobReg.Ssp_cam007_ms45;
                    lobRegMs4505.Ssp_cam008_ms45 = lobReg.Ssp_cam008_ms45;
                    lobRegMs4505.Ssp_cam009_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam009_ms45);
                    lobRegMs4505.Ssp_cam010_ms45 = lobReg.Ssp_cam010_ms45;
                    lobRegMs4505.Ssp_cam011_ms45 = lobReg.Ssp_cam011_ms45;
                    lobRegMs4505.Ssp_codocu_ciuo = lobReg.Ssp_codocu_ciuo;
                    lobRegMs4505.Ssp_cam013_ms45 = lobReg.Ssp_cam013_ms45;
                    lobRegMs4505.Ssp_cam014_ms45 = lobReg.Ssp_cam014_ms45;
                    lobRegMs4505.Ssp_cam015_ms45 = lobReg.Ssp_cam015_ms45;
                    lobRegMs4505.Ssp_cam016_ms45 = lobReg.Ssp_cam016_ms45;
                    lobRegMs4505.Ssp_cam017_ms45 = lobReg.Ssp_cam017_ms45;
                    lobRegMs4505.Ssp_cam018_ms45 = lobReg.Ssp_cam018_ms45;
                    lobRegMs4505.Ssp_cam019_ms45 = lobReg.Ssp_cam019_ms45;
                    lobRegMs4505.Ssp_cam020_ms45 = lobReg.Ssp_cam020_ms45;
                    lobRegMs4505.Ssp_cam021_ms45 = lobReg.Ssp_cam021_ms45;
                    lobRegMs4505.Ssp_cam022_ms45 = lobReg.Ssp_cam022_ms45;
                    lobRegMs4505.Ssp_cam023_ms45 = lobReg.Ssp_cam023_ms45;
                    lobRegMs4505.Ssp_cam024_ms45 = lobReg.Ssp_cam024_ms45;
                    lobRegMs4505.Ssp_cam025_ms45 = lobReg.Ssp_cam025_ms45;
                    lobRegMs4505.Ssp_cam026_ms45 = lobReg.Ssp_cam026_ms45;
                    lobRegMs4505.Ssp_cam027_ms45 = lobReg.Ssp_cam027_ms45;
                    lobRegMs4505.Ssp_cam028_ms45 = lobReg.Ssp_cam028_ms45;
                    lobRegMs4505.Ssp_cam029_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam029_ms45);
                    lobRegMs4505.Ssp_cam030_ms45 = (float)Convert.ToDecimal(lobReg.Ssp_cam030_ms45);
                    lobRegMs4505.Ssp_cam031_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam031_ms45);
                    lobRegMs4505.Ssp_cam032_ms45 = Convert.ToInt32(lobReg.Ssp_cam032_ms45);
                    lobRegMs4505.Ssp_cam033_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam033_ms45);
                    lobRegMs4505.Ssp_cam034_ms45 = Convert.ToInt32(lobReg.Ssp_cam034_ms45);
                    lobRegMs4505.Ssp_cam035_ms45 = lobReg.Ssp_cam035_ms45;
                    lobRegMs4505.Ssp_cam036_ms45 = lobReg.Ssp_cam036_ms45;
                    lobRegMs4505.Ssp_cam037_ms45 = lobReg.Ssp_cam037_ms45;
                    lobRegMs4505.Ssp_cam038_ms45 = lobReg.Ssp_cam038_ms45;
                    lobRegMs4505.Ssp_cam039_ms45 = lobReg.Ssp_cam039_ms45;
                    lobRegMs4505.Ssp_cam040_ms45 = lobReg.Ssp_cam040_ms45;
                    lobRegMs4505.Ssp_cam041_ms45 = lobReg.Ssp_cam041_ms45;
                    lobRegMs4505.Ssp_cam042_ms45 = lobReg.Ssp_cam042_ms45;
                    lobRegMs4505.Ssp_cam043_ms45 = lobReg.Ssp_cam043_ms45;
                    lobRegMs4505.Ssp_cam044_ms45 = lobReg.Ssp_cam044_ms45;
                    lobRegMs4505.Ssp_cam045_ms45 = lobReg.Ssp_cam045_ms45;
                    lobRegMs4505.Ssp_cam046_ms45 = lobReg.Ssp_cam046_ms45;
                    lobRegMs4505.Ssp_cam047_ms45 = lobReg.Ssp_cam047_ms45;
                    lobRegMs4505.Ssp_cam048_ms45 = lobReg.Ssp_cam048_ms45;
                    lobRegMs4505.Ssp_cam049_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam049_ms45);
                    lobRegMs4505.Ssp_cam050_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam050_ms45);
                    lobRegMs4505.Ssp_cam051_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam051_ms45);
                    lobRegMs4505.Ssp_cam052_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam052_ms45);
                    lobRegMs4505.Ssp_cam053_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam053_ms45);
                    lobRegMs4505.Ssp_cam054_ms45 = lobReg.Ssp_cam054_ms45;
                    lobRegMs4505.Ssp_cam055_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam055_ms45);
                    lobRegMs4505.Ssp_cam056_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam056_ms45);
                    lobRegMs4505.Ssp_cam057_ms45 = Convert.ToInt32(lobReg.Ssp_cam057_ms45);
                    lobRegMs4505.Ssp_cam058_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam058_ms45);
                    lobRegMs4505.Ssp_cam059_ms45 = lobReg.Ssp_cam059_ms45;
                    lobRegMs4505.Ssp_cam060_ms45 = lobReg.Ssp_cam060_ms45;
                    lobRegMs4505.Ssp_cam061_ms45 = lobReg.Ssp_cam061_ms45;
                    lobRegMs4505.Ssp_cam062_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam062_ms45);
                    lobRegMs4505.Ssp_cam063_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam063_ms45);
                    lobRegMs4505.Ssp_cam064_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam064_ms45);
                    lobRegMs4505.Ssp_cam065_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam065_ms45);
                    lobRegMs4505.Ssp_cam066_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam066_ms45);
                    lobRegMs4505.Ssp_cam067_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam067_ms45);
                    lobRegMs4505.Ssp_cam068_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam068_ms45);
                    lobRegMs4505.Ssp_cam069_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam069_ms45);
                    lobRegMs4505.Ssp_cam070_ms45 = lobReg.Ssp_cam070_ms45;
                    lobRegMs4505.Ssp_cam071_ms45 = lobReg.Ssp_cam071_ms45;
                    lobRegMs4505.Ssp_cam072_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam072_ms45);
                    lobRegMs4505.Ssp_cam073_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam073_ms45);
                    lobRegMs4505.Ssp_cam074_ms45 = Convert.ToInt32(lobReg.Ssp_cam074_ms45);
                    lobRegMs4505.Ssp_cam075_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam075_ms45);
                    lobRegMs4505.Ssp_cam076_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam076_ms45);
                    lobRegMs4505.Ssp_cam077_ms45 = lobReg.Ssp_cam077_ms45;
                    lobRegMs4505.Ssp_cam078_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam078_ms45);
                    lobRegMs4505.Ssp_cam079_ms45 = lobReg.Ssp_cam079_ms45;
                    lobRegMs4505.Ssp_cam080_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam080_ms45);
                    lobRegMs4505.Ssp_cam081_ms45 = lobReg.Ssp_cam081_ms45;
                    lobRegMs4505.Ssp_cam082_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam082_ms45);
                    lobRegMs4505.Ssp_cam083_ms45 = lobReg.Ssp_cam083_ms45;
                    lobRegMs4505.Ssp_cam084_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam084_ms45);
                    lobRegMs4505.Ssp_cam085_ms45 = lobReg.Ssp_cam085_ms45;
                    lobRegMs4505.Ssp_cam086_ms45 = lobReg.Ssp_cam086_ms45;
                    lobRegMs4505.Ssp_cam087_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam087_ms45);
                    lobRegMs4505.Ssp_cam088_ms45 = lobReg.Ssp_cam088_ms45;
                    lobRegMs4505.Ssp_cam089_ms45 = lobReg.Ssp_cam089_ms45;
                    lobRegMs4505.Ssp_cam090_ms45 = lobReg.Ssp_cam090_ms45;
                    lobRegMs4505.Ssp_cam091_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam091_ms45);
                    lobRegMs4505.Ssp_cam092_ms45 = lobReg.Ssp_cam092_ms45;
                    lobRegMs4505.Ssp_cam093_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam093_ms45);
                    lobRegMs4505.Ssp_cam094_ms45 = lobReg.Ssp_cam094_ms45;
                    lobRegMs4505.Ssp_cam095_ms45 = lobReg.Ssp_cam095_ms45;
                    lobRegMs4505.Ssp_cam096_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam096_ms45);
                    lobRegMs4505.Ssp_cam097_ms45 = lobReg.Ssp_cam097_ms45;
                    lobRegMs4505.Ssp_cam098_ms45 = lobReg.Ssp_cam098_ms45;
                    lobRegMs4505.Ssp_cam099_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam099_ms45);
                    lobRegMs4505.Ssp_cam100_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam100_ms45);
                    lobRegMs4505.Ssp_cam101_ms45 = lobReg.Ssp_cam101_ms45;
                    lobRegMs4505.Ssp_cam102_ms45 = lobReg.Ssp_cam102_ms45;
                    lobRegMs4505.Ssp_cam103_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam103_ms45);
                    lobRegMs4505.Ssp_cam104_ms45 =(float)Convert.ToDecimal(lobReg.Ssp_cam104_ms45);
                    lobRegMs4505.Ssp_cam105_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam105_ms45);
                    lobRegMs4505.Ssp_cam106_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam106_ms45);
                    lobRegMs4505.Ssp_cam107_ms45 = (float)Convert.ToDecimal(lobReg.Ssp_cam107_ms45);
                    lobRegMs4505.Ssp_cam108_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam108_ms45);
                    lobRegMs4505.Ssp_cam109_ms45 = (float)Convert.ToDecimal(lobReg.Ssp_cam109_ms45);
                    lobRegMs4505.Ssp_cam110_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam110_ms45);
                    lobRegMs4505.Ssp_cam111_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam111_ms45);
                    lobRegMs4505.Ssp_cam112_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam112_ms45);
                    lobRegMs4505.Ssp_cam113_ms45 = lobReg.Ssp_cam113_ms45;
                    lobRegMs4505.Ssp_cam114_ms45 = lobReg.Ssp_cam114_ms45;
                    lobRegMs4505.Ssp_cam115_ms45 = lobReg.Ssp_cam115_ms45;
                    lobRegMs4505.Ssp_cam116_ms45 = lobReg.Ssp_cam116_ms45;
                    lobRegMs4505.Ssp_cam117_ms45 = lobReg.Ssp_cam117_ms45;
                    lobRegMs4505.Ssp_cam118_ms45 = Funciones.fdaConvertFecha(gcrFechaFormato,gcrFechaSeparador, lobReg.Ssp_cam118_ms45);
                    #endregion
                    // guardar datos
                    if (lobReg.Sis_estado_imaen == "A")
                    {
                        lobReg.Ssp_cam001_ms45 = ModeloSspRes4505.flgAddRegistro(lobRegMs4505);
                        lobRegMs4505.Ssp_cam001_ms45 = lobReg.Ssp_cam001_ms45;
                    }
                    else if (lobReg.Sis_estado_imaen != "I")
                    {
                        ModeloSspRes4505.fcvActualizar(lobRegMs4505, gcrPeriodoAño, gcrPeriodoMes);
                    }
                }
            }
            glgObjetosCargados = true;
        }
        #endregion
        //-------------------------------------------------------
        // fcvSelectCheckBox: Marcar o desmarcar todos los registros
        //-------------------------------------------------------
        #region fcvSelectCheckBox: Marcar o desmarcar todos los registros
        private void fcvSelectCheckBox(object sender, RoutedEventArgs e)
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Marcando todos los registros...", "CENTRO");
            lobDlgAdd.Show();

            var lobjChk = sender as CheckBox;
            var i = 0;
            var llgControlObj = true;

            //- se posicicona en el primer registro de la grilla
            if (this.objDataGrid.Items.Count > 0)
            {
                object item = objDataGrid.Items[0];
                objDataGrid.SelectedItem = item;
                objDataGrid.ScrollIntoView(item);
            }

            foreach (var lobjItem in objDataGrid.Items)
            {
                // actualizar la vista de los objetos chkbox
                if (llgControlObj == true)
                {
                    llgControlObj = false;
                    DataGridRow lobjFila = (DataGridRow)objDataGrid.ItemContainerGenerator.ContainerFromIndex(i);
                    if (lobjFila != null)
                    {
                        CheckBox lobChk = objDataGrid.Columns[1].GetCellContent(lobjFila) as CheckBox;
                        if (lobChk != null)
                        {
                            llgControlObj = true; 
                            lobChk.IsChecked = lobjChk.IsChecked == true ? true : false;
                            i++;
                        }
                    }
                }
                // marcar los registros del temporal asociado a la vista de la grilla
                ModeloSspNsRes4505Ex lobjRegistro = (ModeloSspNsRes4505Ex)lobjItem;
                if (lobjChk.IsChecked == true)
                {
                    lobjRegistro.BoolEstado = true;
                }
                else
                {
                    lobjRegistro.BoolEstado = false;
                }
            }
            CollectionViewSource.GetDefaultView(this.objDataGrid.ItemsSource).Refresh();
            lobDlgAdd.Close();
        }
        #endregion
        //-------------------------------------------------------
        // ACCINES PARA DETALLES GRILLA y VISTA REGISTRO CAPA DERECHA
        //-------------------------------------------------------
        #region fcvGrillaMostrarDetalles: Mostrar los detalles del registro de la grilla
        /// <summary>
        /// <para>Mostrar los detalles del registro de la grilla</para>
        /// </summary>
        private void fcvGrillaMostrarDetalles(object sender, RoutedEventArgs e)
        {

            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Cargando vista datos del registro...", "CENTRO");
            lobDlgAdd.Show();

            for (var lobVisual = sender as Visual; lobVisual != null; lobVisual = VisualTreeHelper.GetParent(lobVisual) as Visual)
            {
                if (lobVisual is DataGridRow)
                {

                    var lobFila = (DataGridRow)lobVisual;
                    // Seleccionar el registro como activo
                    tmpRegActMS4505 = (ModeloSspNsRes4505Ex)lobFila.Item;

                    // activar vista variables
                    fcvGrillaActivarVistaGrpoRegistro(false);
                    fcvGrillaVerGruposVistaRegistro(tmpRegActMS4505.Ssp_codpro_ms45);

                    vm.fcvReiniVariables("2");
                    vm.TmpG2RegActivo = vm.TmpG2ListaBrow.FirstOrDefault(x => x.Ssp_idesec_ns45 == tmpRegActMS4505.Ssp_idesec_ns45);
                    vm.fcvCargarVariablesDesdeRegActivo("2");
                    fcvGrillaMostrarDetallesGrupo();
                    // Activar la vista
                    if (glgVistaSeleccionPropiedades == false)
                    {
                        fcvActivarVistaSeleccion();
                    }
                    break;
                }
            }
            lobDlgAdd.Close();
        }
        #endregion
        #region Actualziar vista del grupo en la capa
        private void fcvGrillaMostrarDetallesGrupo()
        {
            try
            {
                var lcrUri         = "/Sistema;component/Imagenes/";
                var lcrColorNivelC = "#FFE8E8E8";
                var lcrImagenVista = "sys_usu02.png";
                var lcrTituloGrupo = "Registro";

                var tmp = SSPValidarCodigo.fobRegBuscarSpprogramgrupma(vm.G1Ssp_codpro_sspa);
                if (tmp != null)
                {
                    lcrTituloGrupo = tmp.ssp_titpro_sspa;
                    lcrImagenVista = tmp.ssp_imagen_sspa;
                    lcrColorNivelC = tmp.ssp_icolor_sspa;
                }
                this.objFondo.Fill           = Funciones.FuxSetSolidColorBrush(lcrColorNivelC);
                this.imgGrupo.Source         = new BitmapImage(new Uri(lcrUri + lcrImagenVista, UriKind.RelativeOrAbsolute));
                this.txtPropTituloGrupo.Text = lcrTituloGrupo;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvGrillaMostrarDetallesGrupo");
            }
        }
        #endregion
        #region flgGenerarDatosEdad: Genera los datos de edad y edad en formato largo
        /// <summary>
        /// <para>Genera los datos de edad y edad en formato largo</para>
        /// </summary>
        public bool flgGenerarDatosEdad(ModeloSspNsRes4505Ex tobRegistro)
        {
            var llgValor        = false;
            var lobReg          = vm.TmpG2ListaBrow.FirstOrDefault(x => x.Ssp_ideaux_ns45 == tobRegistro.Ssp_ideaux_ns45);
            var lcrSeparador    = this.txtG1Ssp_sepfec_sscf.Text == "1" ? "/" : "-";
            var lcrFechaPer     = this.txtG1Ssp_fecini_peri.Text;

            if (Funciones.flgExisteSubCadenaStringEx(tobRegistro.Ssp_cam009_ms45, "0123456789" + lcrSeparador))
            {
                var lcrFechaNac = Funciones.fdaConvertFecha(this.txtG1Ssp_forfec_sscf.Text, lcrSeparador, tobRegistro.Ssp_cam009_ms45).ToShortDateString();
                if (Funciones.flgValidarRangoFecha(lcrFechaNac, lcrFechaPer))
                {
                    var ldaFechaNac = Funciones.fdaConvertFecha("DMY", "/", lcrFechaNac);
                    var ldaFechaper = Funciones.fdaConvertFecha("DMY", "/", lcrFechaPer);

                    lobReg.Sia_edaano_usua = Funciones.fnuCalcularFormatoAñosMesesDias("AÑOS", ldaFechaNac, ldaFechaper);
                    lobReg.Sia_edames_usua = Funciones.fnuCalcularFormatoAñosMesesDias("MESES", ldaFechaNac, ldaFechaper);
                    lobReg.Sia_edadia_usua = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechaNac, ldaFechaper);
                    lobReg.Sia_edaymd_usua = Funciones.fcrFechaRangoForamtoLargo(ldaFechaNac, ldaFechaper);
                    llgValor = true;
                }
                else
                {
                    lobReg.Sia_edaymd_usua = "Error fecha nacimiento";
                }
            }
            else 
            {
                lobReg.Sia_edaymd_usua = "Error fecha nacimiento";
            }
            return llgValor;
        }
        #endregion
        #region fcvGrillamModificarRegistro: Modificar registro  activo en grilla
        /// <summary>
        /// <para>Modificar registro  activo en grilla</para>
        /// </summary>
        private void fcvGrillamModificarRegistro(object sender, RoutedEventArgs e)
        {
            var lobBoton = (Button)sender;

            tmpRegActMS4505 = (ModeloSspNsRes4505Ex)lobBoton.DataContext;

            gobParam.FechaIniPeriodo    = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecini_peri.Text);
            gobParam.FechaFinPeriodo    = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Ssp_fecfin_peri.Text);
            gobParam.CodigoEps          = this.txtG1Sia_codeps_teps.Text;
            gobParam.FechaFormato       = this.txtG1Ssp_forfec_sscf.Text;
            gobParam.FechaSeparador     = this.txtG1Ssp_sepfec_sscf.Text == "1" ? "/" : "-";
            gobParam.CodigoPlantilla    = this.txtG1Sis_secreg_siva.Text;
            gobParam.CodigoPeriodo      = this.txtG1Ssp_codper_peri.Text;
            gobParam.OrigenDatos        = gcrOrigenDatosCargados;   

            VistaSspRes4505 lobSSP001 = new VistaSspRes4505(tmpRegActMS4505, gobParam);
            lobSSP001.Owner = this;
            lobSSP001.ShowDialog();
        }
        #endregion
        #region fcvGrillaIrAVistaErrores: Ir a la vista de errores del registro en la grilla
        /// <summary>
        /// <para>Ir a la vista de errores del registro en la grilla</para>
        /// </summary>
        private void fcvGrillaIrAVistaErrores(object sender, RoutedEventArgs e)
        {
            if (vm.tmpLogError != null)
            {
                var lobBoton = (Button)sender;
                tmpRegActMS4505 = (ModeloSspNsRes4505Ex)lobBoton.DataContext;

                if (vm.tmpLogError.Count > 0)
                {
                    var lcrNumRegistro = tmpRegActMS4505.Ssp_ideaux_ns45.ToString().Trim();
                    var lobjRegistro = vm.tmpLogError.FirstOrDefault(p => p.IdRegistro == lcrNumRegistro);

                    if (lobjRegistro != null)
                    {
                        if (glgVistaEtiquetaEstadoVisible == false)
                        {
                            fcvActivarVistaErroresValid();
                        }

                        Thread.Sleep(100);

                        fcvFiltroDataGridErroresQuitarValores();

                        // Reorganizar por el numero secuencial
                        var lobjColumna = this.objDataGridErrores.Columns[1];
                        this.objDataGridErrores.Items.SortDescriptions.Clear();
                        this.objDataGridErrores.Items.SortDescriptions.Add(new SortDescription(lobjColumna.SortMemberPath, ListSortDirection.Ascending));
                        foreach (var col in this.objDataGridErrores.Columns)
                        {
                            col.SortDirection = null;
                        }
                        lobjColumna.SortDirection = ListSortDirection.Ascending;

                        CollectionViewSource.GetDefaultView(this.objDataGridErrores.ItemsSource).Refresh();
                        // ir al registro seleccionado
                        object item = this.objDataGridErrores.Items[lobjRegistro.Secuencial];
                        this.objDataGridErrores.SelectedItem = item;
                        this.objDataGridErrores.ScrollIntoView(item);
                        this.objDataGridErrores.Focus();
                    }
                }
            }
        }
        #endregion
        #region fcvGrillaIrAVistaRegistro: Ir a la vista del registroen en la grilla principal
        /// <summary>
        /// <para>Ir a la vista del registroen en la grilla principal</para>
        /// </summary>
        private void fcvGrillaIrAVistaRegistro(object sender, RoutedEventArgs e)
        {
            if (vm.TmpG2ListaBrow != null)
            {
                var lobBoton = (Button)sender;
                var lnuRegistro = Convert.ToInt32(((LogErrores)lobBoton.DataContext).IdRegistro)-1;
                // ocultar la vista de errores
                fcvActivarVistaErroresValid();
                Thread.Sleep(100);

                fcvFiltroDataGridQuitarValores();
                // Reorganizar por el numero de registro
                var lobjColumna = this.objDataGrid.Columns[2];
                this.objDataGrid.Items.SortDescriptions.Clear();
                this.objDataGrid.Items.SortDescriptions.Add(new SortDescription(lobjColumna.SortMemberPath, ListSortDirection.Ascending));
                foreach (var col in this.objDataGrid.Columns)
                {
                    col.SortDirection = null;
                }
                lobjColumna.SortDirection = ListSortDirection.Ascending;
                // Refrescar la vista
                CollectionViewSource.GetDefaultView(this.objDataGrid.ItemsSource).Refresh();
                // ir al registro seleccionado con click
                object item = this.objDataGrid.Items[lnuRegistro];
                this.objDataGrid.SelectedItem = item;
                this.objDataGrid.ScrollIntoView(item);
                this.objDataGrid.Focus();
            }
        }
        #endregion
        // Mostrar grupos actividades para el registro activo
        #region fcvGrillaVerGruposVistaRegistro: Mostrar solo los grupos de actividades para el registro activo
        /// <summary>
        /// <para>Mostrar solo los grupos de actividades para el registro activo</para>
        /// </summary>
        private void fcvGrillaVerGruposVistaRegistro(String tcrListaGrpoActividad)
        {
            if (!String.IsNullOrWhiteSpace(tcrListaGrpoActividad))
            {
                #region Son varios comandos
                String[] larArray = (tcrListaGrpoActividad).Split("-".ToCharArray());

                if (larArray.Length > 0) // esta correcta la expresion
                {
                    int lnuTotElemtos = larArray.Length;
                    var i = 0;

                    for (i = 0; i < lnuTotElemtos; i++)
                    {
                        fcvGrillaActivarVistaGrpoRegistro(larArray[i].Trim(), true);
                    }
                }
                #endregion
            }
        }
        #endregion
        #region fcvGrillaActivarVistaGrpoRegistro: Mostrar / ocultar  un Grupos de actividades en vista registro
        /// <summary>
        /// <para>Mostrar / ocultar todos los grupos de actividades en vista registro</para>
        /// </summary>
        private void fcvGrillaActivarVistaGrpoRegistro(String tcrIdGrupo, bool tlgEstado)
        {
            var lcrEstado = tlgEstado == true ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

            switch (tcrIdGrupo)
            {
                case "01":
                    this.expGrupo01.Visibility = lcrEstado;
                    break;
                case "02":
                    this.expGrupo02.Visibility = lcrEstado;
                    break;
                case "03":
                    this.expGrupo03.Visibility = lcrEstado;
                    break;
                case "04":
                    this.expGrupo04.Visibility = lcrEstado;
                    break;
                case "05":
                    this.expGrupo05.Visibility = lcrEstado;
                    break;
                case "06":
                    this.expGrupo06.Visibility = lcrEstado;
                    break;
                case "07":
                    this.expGrupo07.Visibility = lcrEstado;
                    break;
                case "08":
                    this.expGrupo08.Visibility = lcrEstado;
                    break;
                case "09":
                    this.expGrupo09.Visibility = lcrEstado;
                    break;
                case "10":
                    this.expGrupo10.Visibility = lcrEstado;
                    break;
                case "11":
                    this.expGrupo11.Visibility = lcrEstado;
                    break;
                case "12":
                    this.expGrupo12.Visibility = lcrEstado;
                    break;
                case "14":
                    this.expGrupo14.Visibility = lcrEstado;
                    break;
                case "17":
                    this.expGrupo17.Visibility = lcrEstado;
                    break;
                case "26":
                    this.expGrupo26.Visibility = lcrEstado;
                    break;
                case "27":
                    this.expGrupo27.Visibility = lcrEstado;
                    break;
                case "29":
                    this.expGrupo29.Visibility = lcrEstado;
                    break;
            }
        }
        #endregion
        #region fcvGrillaActivarVistaGrpoRegistro: Mostrar / ocultar todos los grupos de actividades en vista registro
        /// <summary>
        /// <para>Mostrar / ocultar todos los grupos de actividades en vista registro</para>
        /// </summary>
        private void fcvGrillaActivarVistaGrpoRegistro(bool tlgEstado)
        {
            var lcrEstado = tlgEstado == true ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

            this.expGrupo01.Visibility = lcrEstado;
            this.expGrupo02.Visibility = lcrEstado;
            this.expGrupo03.Visibility = lcrEstado;
            this.expGrupo04.Visibility = lcrEstado;
            this.expGrupo05.Visibility = lcrEstado;
            this.expGrupo06.Visibility = lcrEstado;
            this.expGrupo07.Visibility = lcrEstado;
            this.expGrupo08.Visibility = lcrEstado;
            this.expGrupo09.Visibility = lcrEstado;
            this.expGrupo10.Visibility = lcrEstado;
            this.expGrupo11.Visibility = lcrEstado;
            this.expGrupo12.Visibility = lcrEstado;
            this.expGrupo14.Visibility = lcrEstado;
            this.expGrupo17.Visibility = lcrEstado;
            this.expGrupo26.Visibility = lcrEstado;
            this.expGrupo27.Visibility = lcrEstado;
            this.expGrupo29.Visibility = lcrEstado;

        }
        #endregion
        // Lista objetos para actualizar combobox en vista grupos actividades
        #region fcvRefVar4505GenTemporalReferencia: Generar el temporal de referencia objetos campos 4505
        /// <summary>
        /// <para>Generar el temporal de referencia objetos campos 4505</para>
        /// </summary>
        private void fcvRefVar4505ActaulizarVistaComboBox(String tcrNumeroVariable, String tcrValor, String tcrListaValores)
        {
            var tmpList = flsRefVar4505SqlConsultarObjetos(tcrNumeroVariable, "ComboBox");
            var lnuIndex = CrtForms.fnuMostrarItemCombo(tcrValor, ",", tcrListaValores);
            if (tmpList != null)
            {
                foreach (var lobReg in tmpList)
                {
                    var lobComboBox = lobReg.RefObjeto as ComboBox;
                    if (lobComboBox != null)
                    {
                        lobComboBox.SelectedIndex = lnuIndex;
                    }
                }
            }
        }
        #endregion
        #region flsRefVar4505SqlConsultarObjetos: Consultar temporal por numero de variable 4505 y tipo objeto
        /// <summary>
        /// <para>Consultar temporal por numero de variable 4505 y tipo objeto</para>
        /// </summary>
        private List<ObjetosVista> flsRefVar4505SqlConsultarObjetos(String tcrNumeroVariable, String tcrTipoObjeto)
        {
            List<ObjetosVista> tmpDatos = null;

            if (tmpListRefObjVista4505 != null)
            {
                tmpDatos = (from tmp in tmpListRefObjVista4505
                            where tmp.Variable == tcrNumeroVariable &&
                                  tmp.Tipo == tcrTipoObjeto select tmp).ToList();
            }
            return tmpDatos;
        }
        #endregion
        #region fcvRefVar4505GenTemporalReferencia: Generar el temporal de referencia objetos campos 4505
        /// <summary>
        /// <para>Generar el temporal de referencia objetos campos 4505</para>
        /// </summary>
        private void fcvRefVar4505GenTemporalReferencia()
        {
            tmpListRefObjVista4505 = new List<ObjetosVista>();
            var llsLista = Funciones.flsListaObjetosVisualTreeDown((this.stkBasicas as Visual));

            // Buscar los ComboBox asociados a campos de variables 4505
            #region Buscar los ComboBox asociados a campos de variables 4505
            foreach (object lobj in llsLista)
            {
                var lobReg = fobRefVar4505AddRegistro(lobj, typeof(ComboBox));
                if (lobReg != null)
                {
                    tmpListRefObjVista4505.Add(lobReg);
                }
            }
            #endregion
            // Buscar todos los TextBox asociados a ComboBox
            #region Buscar todos los TextBox asociados a ComboBox
            foreach (object lobj in llsLista)
            {
                if (lobj.GetType() == typeof(TextBox))
                {
                    TextBox lobJtxt = (TextBox)lobj;
                    var lcrNumvar4505 = fcrRefVar4505NumeroVariableSi(lobJtxt.Name);

                    if (!String.IsNullOrWhiteSpace(lcrNumvar4505))
                    {
                        //- Verificar si existe almenos un combobox asocido con esta variable
                        var lobReg = tmpListRefObjVista4505.FirstOrDefault(x => x.Variable == lcrNumvar4505);
                        if (lobReg != null)
                        {
                            //- Verificar que no existe otra referencia a campos textos de esta variable, solo debe ser una sola
                            var lobRegx = tmpListRefObjVista4505.FirstOrDefault(x => x.Variable == lcrNumvar4505 && x.Tipo == "TextBox");
                            if (lobRegx == null)
                            {
                                var lobRegE = fobRefVar4505AddRegistro(lobj, typeof(TextBox));
                                if (lobRegE != null)
                                {
                                    tmpListRefObjVista4505.Add(lobRegE);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
        #endregion
        #region fobRefVar4505AddRegistro: Generar el registro referencia del campo y objeto 4505 ComboBox y TextBox
        /// <summary>
        /// <para>Generar el registro referencia del campo y objeto 4505 ComboBox y TextBox</para>
        /// </summary>
        private ObjetosVista fobRefVar4505AddRegistro(object tobRefObjeto, Type tuxTipo)
        {
            ObjetosVista lobReg = null;
            var lcrTipo   = String.Empty;
            FrameworkElement lobRefObj = null;

            if (tobRefObjeto.GetType() == tuxTipo)
            {
                if (tobRefObjeto.GetType() == typeof(ComboBox))
                {
                    lobRefObj = (ComboBox)tobRefObjeto;
                    lcrTipo = "ComboBox";
                }
                else
                {
                    lobRefObj = (TextBox)tobRefObjeto;
                    lcrTipo = "TextBox";
                }

                var lrNumVariable = fcrRefVar4505NumeroVariableSi(lobRefObj.Name);

                // Agregar la referencia del objeto al registro 
                if (!String.IsNullOrWhiteSpace(lrNumVariable)) 
                {
                    lobReg = new ObjetosVista {
                        Nombre    = lobRefObj.Name.ToLower(),
                        Tipo      = lcrTipo,
                        Variable  = lrNumVariable,
                        RefObjeto = lobRefObj
                    };
                }
            }

            return lobReg;

        }
        #endregion
        #region fcrRefVar4505NumeroVariableSi: Varifica si el objeto contiene campo 4505
        /// <summary>
        /// <para>Varifica si el Nombre del objeto contiene campo 4505 y devuelve el numero de variable</para>
        /// <para>cuando no contiene variable 4505 devuelve String vacio</para>
        /// </summary>
        private String fcrRefVar4505NumeroVariableSi(String tcrNombreObjeto)
        {
            var lcrReturn = String.Empty;
            String[] larArray = (tcrNombreObjeto).Split("_".ToCharArray());

            if (larArray.Length == 3) // Tiene estructura de campo -> txtG1Ssp_cam060_ms45
            {
                if (larArray[1].Trim().Length == 6) // el bolque centrarl del nombre del objeto = txtG1Ssp_cam060_ms45 -> 060
                {
                    var lcrValor = larArray[1].Trim().Substring(3, 3);
                    if (Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789"))
                    {
                        lcrReturn = (Convert.ToInt32(lcrValor)).ToString().Trim(); // El numero de la Variable 4505
                    }
                }
            }

            return lcrReturn;
        }
        #endregion
        #region fcrRefVar4505Expander: Forzar abrir todos los Expander
        /// <summary>
        /// Forzar abrir todos los Expander
        /// </summary>
        private void fcrRefVar4505Expander()
        {
            fcrRefVar4505ExpanderVisibles(Visibility.Visible);

            #region Forzar actualizacion del registro de objetos en array del formulario
            // Grupos
            this.expGrupo01.IsExpanded = true;
            this.expGrupo02.IsExpanded = true;
            this.expGrupo03.IsExpanded = true;
            this.expGrupo04.IsExpanded = true;
            this.expGrupo05.IsExpanded = true;
            this.expGrupo06.IsExpanded = true;
            this.expGrupo07.IsExpanded = true;
            this.expGrupo08.IsExpanded = true;
            this.expGrupo09.IsExpanded = true;
            this.expGrupo10.IsExpanded = true;
            this.expGrupo11.IsExpanded = true;
            this.expGrupo12.IsExpanded = true;
            this.expGrupo14.IsExpanded = true;
            this.expGrupo17.IsExpanded = true;
            this.expGrupo23.IsExpanded = true;
            this.expGrupo26.IsExpanded = true;
            this.expGrupo27.IsExpanded = true;
            this.expGrupo29.IsExpanded = true;
            // Grupo basdico
            this.expTodas.IsExpanded = true;
            this.exp_014.IsExpanded = true;
            this.exp_1529.IsExpanded = true;
            this.exp_3044.IsExpanded = true;
            this.exp_4559.IsExpanded = true;
            this.exp_6074.IsExpanded = true;
            this.exp_7589.IsExpanded = true;
            this.exp_90104.IsExpanded = true;
            this.exp_105118.IsExpanded = true;
            #endregion
        }
        #endregion
        #region fcrRefVar4505ExpanderVisibles: Activar Expander
        /// <summary>
        /// Activar Expander
        /// </summary>
        private void fcrRefVar4505ExpanderVisibles(Visibility tcrEstado)
        {
            #region Forzar actualizacion del registro de objetos en array del formulario
            // Grupos
            this.expGrupo01.Visibility = tcrEstado;
            this.expGrupo02.Visibility = tcrEstado;
            this.expGrupo03.Visibility = tcrEstado;
            this.expGrupo04.Visibility = tcrEstado;
            this.expGrupo05.Visibility = tcrEstado;
            this.expGrupo06.Visibility = tcrEstado;
            this.expGrupo07.Visibility = tcrEstado;
            this.expGrupo08.Visibility = tcrEstado;
            this.expGrupo09.Visibility = tcrEstado;
            this.expGrupo10.Visibility = tcrEstado;
            this.expGrupo11.Visibility = tcrEstado;
            this.expGrupo12.Visibility = tcrEstado;
            this.expGrupo14.Visibility = tcrEstado;
            this.expGrupo17.Visibility = tcrEstado;
            this.expGrupo23.Visibility = tcrEstado;
            this.expGrupo26.Visibility = tcrEstado;
            this.expGrupo27.Visibility = tcrEstado;
            this.expGrupo29.Visibility = tcrEstado;
            #endregion
        }
        #endregion
        #region fcrRefVar4505Expander: Recojer Todos los Expander
        /// <summary>
        /// Recojer Todos los Expander
        /// </summary>
        public void fcrRefVar4505Expander(DependencyObject myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                // leer los objetos 
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);

                if (childVisual.GetType() == typeof(Expander))
                {
                    ((Expander)childVisual).IsExpanded = false;
                }
                // buscar en le siguiente nivel
                fcrRefVar4505Expander(childVisual);
            }
        }
        #endregion
        //-------------------------------------------------------
        // ACCIONES PARA FILTRO GRILLA PRINCIPAL
        //-------------------------------------------------------
        #region flgFiltroDataGridDatos: Aplicar la gestion del filtro en la grilla principal
        /// <summary>
        /// <para>Aplicar la gestion del filtro en la grilla principal</para>
        /// </summary>
        private bool flgFiltroDataGridDatos()
        {
            var llgReturn = true;
            
            _DataGridListFiltro = new CollectionViewSource() { Source = vm.TmpG2ListaBrow };
            DataGridItemFiltro = _DataGridListFiltro.View;
            _DataGridListFiltro.Filter += new FilterEventHandler(fcvFiltroDataGridDatos);
            this.objDataGrid.ItemsSource = DataGridItemFiltro;
           
            //_DataGridListFiltro = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
            //_DataGridListFiltro = new CollectionViewSource() { Source = gobObjVModelo.TmpG2ListaBrow };
            //_DataGridListFiltro.Source = gobObjVModelo.TmpG2ListaBrow;
            //DataGridItemFiltro = _DataGridListFiltro.View;
            //_DataGridListFiltro.Filter += new FilterEventHandler(fcvFiltroDataGridDatos);
            //this.objDataGrid.ItemsSource = DataGridItemFiltro;
            
            return llgReturn;
        }
        #endregion
        #region fcvFiltroDataGridDatos: Proceso gestion del filtro en la grilla principal
        /// <summary>
        /// <para>Proceso gestion del filtro en la grilla principal</para>
        /// </summary>
        private void fcvFiltroDataGridDatos(object sender, FilterEventArgs e)
        {
            var lobjObjeto = e.Item as ModeloSspNsRes4505Ex;
            if (lobjObjeto != null)
            {
                if (!String.IsNullOrWhiteSpace(this.txtFiltro.Text))
                {
                    if (this.txtFiltro.Text.Substring(0, 1) != "*")
                    {
                        if (lobjObjeto.LlaveBusqueda.Contains(this.txtFiltro.Text.ToUpper()))
                        {
                            e.Accepted = true;
                        }
                        else
                        {
                            e.Accepted = false;
                        }
                    }
                    else if (this.txtFiltro.Text.Length > 1)
                    {
                        var lcrValor = this.txtFiltro.Text.Substring(1, this.txtFiltro.Text.Length - 1);

                        if (Funciones.flgSoloNumeros(lcrValor))
                        {
                            if (lobjObjeto.Ssp_ideaux_ns45.Equals(Convert.ToInt32(lcrValor)))
                            {
                                e.Accepted = true;
                            }
                            else
                            {
                                e.Accepted = false;
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region fcvFiltroDataGridEjecutar: Refrescar la vista para aplicar el filtro
        /// <summary>
        /// <para>Refrescar la vista para aplicar el filtro</para>
        /// </summary>
        private void fcvFiltroDataGridEjecutar(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtFiltro.Text))
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Aplicando filtro...", "CENTRO");
                lobDlgAdd.Show();
                CollectionViewSource.GetDefaultView(this.objDataGrid.ItemsSource).Refresh();
                lobDlgAdd.Close();
            }
        }
        #endregion
        #region fcvFiltroDataGridQuitar: Refrescar la vista y quitar el filtro
        /// <summary>
        /// <para>Refrescar la vista y quitar el filtro</para>
        /// </summary>
        private void fcvFiltroDataGridQuitar(object sender, RoutedEventArgs e)
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Quitando filtro...", "CENTRO");
            lobDlgAdd.Show();

            fcvFiltroDataGridQuitarValores();
            CollectionViewSource.GetDefaultView(this.objDataGrid.ItemsSource).Refresh();
            lobDlgAdd.Close();
        }
        #endregion
        #region fcvFiltroDataGridQuitarValores: Quitar los valores de los parametros de filtro
        /// <summary>
        /// <para>Quitar los valores de los parametros de filtro</para>
        /// </summary>
        private void fcvFiltroDataGridQuitarValores()
        {
            this.txtFiltro.Text = String.Empty;
        }
        #endregion
        //-------------------------------------------------------
        // ACCIONES PARA FILTRO GRILLA ERRORES
        //-------------------------------------------------------
        #region flgFiltroDataGridErrores: Aplicar la gestion del filtro en la grilla errores
        /// <summary>
        /// <para>Aplicar la gestion del filtro en la grilla errores</para>
        /// </summary>
        private bool flgFiltroDataGridErrores()
        {
            var llgReturn = true;

            _DataGridSErroresFiltro = new CollectionViewSource() { Source = vm.tmpLogError };
            DataGridVErroresFiltro = _DataGridSErroresFiltro.View;
            _DataGridSErroresFiltro.Filter += new FilterEventHandler(fcvFiltroDataGridErrores);
            this.objDataGridErrores.ItemsSource = DataGridVErroresFiltro;

            return llgReturn;
        }
        #endregion
        #region fcvFiltroDataGridErrores: Proceso gestion del filtro en la grilla principal
        /// <summary>
        /// <para>Proceso gestion del filtro en la grilla principal</para>
        /// </summary>
        private void fcvFiltroDataGridErrores(object sender, FilterEventArgs e)
        {
            var lobjObjeto = e.Item as LogErrores;
            if (lobjObjeto != null)
            {
                if (!String.IsNullOrWhiteSpace(this.txtFiltroErrores.Text))
                {
                    if (this.txtFiltroErrores.Text.Substring(0, 1) != "*")
                    {
                        if (lobjObjeto.LlaveBusqueda.Contains(this.txtFiltroErrores.Text.ToUpper()))
                        {
                            e.Accepted = true;
                        }
                        else
                        {
                            e.Accepted = false;
                        }
                    }
                    else if (this.txtFiltroErrores.Text.Length > 1)
                    {
                        var lcrValor = this.txtFiltroErrores.Text.Substring(1, this.txtFiltroErrores.Text.Length - 1);

                        if (Funciones.flgSoloNumeros(lcrValor))
                        {
                            if (lobjObjeto.Secuencial.Equals(Convert.ToInt32(lcrValor)))
                            {
                                e.Accepted = true;
                            }
                            else
                            {
                                e.Accepted = false;
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region fcvFiltroDataGridErroresEjecutar: Refrescar la vista para aplicar filtro en vista errores
        /// <summary>
        /// <para>Refrescar la vista para aplicar filtro en vista errores</para>
        /// </summary>
        private void fcvFiltroDataGridErroresEjecutar(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.txtFiltroErrores.Text))
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Aplicando filtro...", "CENTRO");
                lobDlgAdd.Show();
                CollectionViewSource.GetDefaultView(this.objDataGridErrores.ItemsSource).Refresh();
                lobDlgAdd.Close();
            }
        }
        #endregion
        #region fcvFiltroDataGridErroresQuitar: Refrescar la vista y quitar filtro errores
        /// <summary>
        /// <para>Refrescar la vista y quitar filtro errores</para>
        /// </summary>
        private void fcvFiltroDataGridErroresQuitar(object sender, RoutedEventArgs e)
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Quitando filtro...", "CENTRO");
            lobDlgAdd.Show();

            fcvFiltroDataGridErroresQuitarValores();
            CollectionViewSource.GetDefaultView(this.objDataGridErrores.ItemsSource).Refresh();
            lobDlgAdd.Close();
        }
        #endregion
        #region fcvFiltroDataGridErroresQuitarValores: Quitar los valores de parametros filtro errores
        /// <summary>
        /// <para>Quitar los valores los valores de parametros filtro errores</para>
        /// </summary>
        private void fcvFiltroDataGridErroresQuitarValores()
        {
            this.txtFiltroErrores.Text = String.Empty;
        }
        #endregion
        //-------------------------------------------------------
        // Utilid - FUNCIONES DE UTILIDAD GENERAL
        //-------------------------------------------------------
        #region fnuUtilidEdadEnDias: Convierte edad a dias segun la medida dada
        /// <summary>
        /// <para>Convierte edad a dias segun la medida dada</para> 
        /// <para>tcrMedidaEdad: Medida dada "1"= Año "2"= Mes "3"= Dia</para> 
        /// <para>tnuEdad: Dato de edad dada segun tcrMedidaEdad</para> 
        /// </summary>
        public static int fnuUtilidEdadEnDias(String tcrMedidaEdad, int tnuEdad)
        {
            var lnuReturn = tnuEdad;
            if (tnuEdad > 0)
            {
                switch (tcrMedidaEdad)
                {
                    case "1": // Años
                        lnuReturn = tnuEdad * 365;
                        break;

                    case "2": // Mes
                        lnuReturn = tnuEdad * 30;
                        break;
                }
            }
            return lnuReturn;
        }
        #endregion
    }
}


namespace SaludPublica.Validador
{
    using Sistema.Utilidades;
    using Sistema.Modelo;
    using Sistema.Clases;
    using Sistema.Validacion;
    using Datos.Modelos;

    //--------------------------------------------------
    // 0 - Tipo de registro
    //--------------------------------------------------
    #region SSP_CAM000_MS45
    public class Ssp_cam000_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "0. Tipo de registro";
            var lcrValor        = tobRegistro.Ssp_cam000_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 0;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TIPO DE REGISTRO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 1 - Consecutivo de registro
    //--------------------------------------------------
    #region SSP_CAM001_MS45
    public class Ssp_cam001_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "1. Consecutivo de registro";
            var lcrValor        = tobRegistro.Ssp_cam001_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 1;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (tobParam.OrigenDatos != "BDATOS")
                {
                    if (!Funciones.flgSoloNumerosEx(lcrValor))
                    {
                        lcrCodError = lcrCodigoError + "E2";
                        lcrMens = " DATO SÓLO DEBE CONTENER NUMEROS";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else if (Convert.ToInt32(lcrValor) <= 0)
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " DATO NO VALIDO PARA CONSECUTIVO DE REGISTRO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 2 - Código de habilitación IPS primaria
    //--------------------------------------------------
    #region SSP_CAM002_MS45
    public class Ssp_cam002_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "2. Código de habilitación IPS primaria";
            var lcrValor        = tobRegistro.Ssp_cam002_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 2;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor.Trim().Length < 2)
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " CÓDIGO DE HABILITACIÓN IPS PRIMARIA TIENE POCOS DIGITOS (" + lcrValor.Trim().Length.ToString() + ")";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    if (lcrValor.Trim().Length > 12)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " CÓDIGO DE HABILITACIÓN IPS PRIMARIA TIENE MUCHOS DIGITOS (" + lcrValor.Trim().Length.ToString() + ")";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 3 - Tipo de identificación del usuario
    //--------------------------------------------------
    #region SSP_CAM003_MS45
    public class Ssp_cam003_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "3. Tipo de identificación del usuario";
            var lcrValor        = tobRegistro.Ssp_cam003_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 3;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "CC,CE,PA,TI,RC,NU,MS,AS,CD"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TIPO DE IDENTIFICACION ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 4 - Número de identificación del usuario
    //--------------------------------------------------
    #region SSP_CAM004_MS45
    public class Ssp_cam004_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "4. Número de identificación del usuario";
            var lcrValor        = tobRegistro.Ssp_cam004_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 4;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length <= 4)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " IDENTIFICACION NO ES VALIDA POCOS DIGITOS (" + lcrValor.Trim().Length.ToString() + ")";
                    lcrNivelError = "5";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"))
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 5 - Primer apellido del usuario
    //--------------------------------------------------
    #region SSP_CAM005_MS45
    public class Ssp_cam005_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "5. Primer apellido del usuario";
            var lcrValor        = tobRegistro.Ssp_cam005_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 5;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length <= 2)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " APELLIDO NO ES VALIDO POCOS DIGITOS (" + lcrValor.Trim().Length.ToString() + ")";
                    lcrNivelError = "5";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"))
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                        lcrNivelError = "5";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 6 - Segundo apellido del usuario
    //--------------------------------------------------
    #region SSP_CAM006_MS45
    public class Ssp_cam006_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "6. Segundo apellido del usuario";
            var lcrValor        = tobRegistro.Ssp_cam006_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 6;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length <= 2)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " APELLIDO NO ES VALIDO POCOS DIGITOS (" + lcrValor.Trim().Length.ToString() + ")";
                    lcrNivelError = "5";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"))
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                        lcrNivelError = "5";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 7 - Primer nombre del usuario
    //--------------------------------------------------
    #region SSP_CAM007_MS45
    public class Ssp_cam007_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "7. Primer nombre del usuario";
            var lcrValor        = tobRegistro.Ssp_cam007_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 7;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length <= 2)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " PRIMER NOMBRE NO ES VALIDO POCOS DIGITOS (" + lcrValor.Trim().Length.ToString() + ")";
                    lcrNivelError = "5";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"))
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                        lcrNivelError = "5";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 8 - Segundo nombre del usuario
    //--------------------------------------------------    
    #region SSP_CAM008_MS45
    public class Ssp_cam008_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "8. Segundo nombre del usuario";
            var lcrValor        = tobRegistro.Ssp_cam008_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 8;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (!String.IsNullOrWhiteSpace(lcrValor))
            {
                if (lcrValor.Trim().Length <= 2)
                {
                    lcrCodError = lcrCodigoError + "E1";
                    lcrMens = " SEGUNDO NOMBRE NO ES VALIDO POCOS DIGITOS (" + lcrValor.Trim().Length.ToString() + ")";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"))
                    {
                        lcrCodError = lcrCodigoError + "E2";
                        lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 9 - Fecha de Nacimiento
    //--------------------------------------------------    
    #region SSP_CAM009_MS45
    public class Ssp_cam009_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "9. Fecha de Nacimiento";
            var lcrValor        = tobRegistro.Ssp_cam009_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 9;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError   = lcrCodigoError + "E1";
                lcrMens       = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    lcrNivelError = "5";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA NACIMIENTO ERRADA";
                    lcrNivelError = "5";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA NACIMIENTO MAYOR QUE FECHA ACTUAL DE VALIDACIÓN";
                        lcrNivelError = "5";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 10 - Sexo
    //--------------------------------------------------    
    #region SSP_CAM010_MS45
    public class Ssp_cam010_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "10. Sexo";
            var lcrValor        = tobRegistro.Ssp_cam010_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 10;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "M,F"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " SEXO DEL AFILIADO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 11 - Codigo pertenencia étnica
    //--------------------------------------------------    
    #region SSP_CAM011_MS45
    public class Ssp_cam011_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "11. Codigo pertenencia étnica";
            var lcrValor        = tobRegistro.Ssp_cam011_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 11;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2,3,4,5,6"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " CÓDIGO DE PERTENENCIA ÉTNICA DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 12 - Codigo de ocupación
    //--------------------------------------------------
    #region SSP_CODOCU_CIUO
    public class Ssp_codocu_ciuo : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "12. Código de ocupación";
            var lcrValor        = tobRegistro.Ssp_codocu_ciuo;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 12;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor.Trim().Length < 4)
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " CÓDIGO DE OCUPACIÓN TIENE POCOS DIGITOS (" + lcrValor.Trim().Length.ToString() + ")";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    if (lcrValor.Trim().Length > 4)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " CÓDIGO DE OCUPACIÓN TIENE MUCHOS DIGITOS (" + lcrValor.Trim().Length.ToString() + ")";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 13 - Codigo pertenencia étnica
    //--------------------------------------------------    
    #region SSP_CAM013_MS45
    public class Ssp_cam013_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "13. Código de nivel educativo";
            var lcrValor        = tobRegistro.Ssp_cam011_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 13;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2,3,4,5,6,7,8,9,10,11,12,13"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " CÓDIGO NIVEL EDUCATIVO DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 14 - Gestación
    //--------------------------------------------------    
    #region SSP_CAM014_MS45
    public class Ssp_cam014_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "14. Gestación";
            var lcrValor        = tobRegistro.Ssp_cam014_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 14;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " GESTACIÓN DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor == "0")
                    {
                        if (lcrSexo == "F" && (lnuEdadDias > 3650 && lnuEdadDias < 17885)) // 3650 = 10 años : 17885 = 49 años
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " VALOR NO APLICA PARA MUJERES EN EDAD FERTIL (10 A 49 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else 
                    {
                        if (Funciones.flgExisteElemento(lcrValor, ",", "1,2,21"))
                        {
                            if (lcrSexo == "M") 
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " DATO GESTACIÓN ERRADO - VALOR 1 2 o 21 NO APLICA PARA HOMBRES";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        if (lcrValor == "1" && lcrSexo == "F")
                        {
                            if (lnuEdadDias < 3650 && lnuEdadDias > 17885)
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " EDAD NO ESTA DENTRO DEL RANGO DE MUJERES FERTIL (10 A 49 AÑOS)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 15 - Sifilis Gestacional o congénita
    //--------------------------------------------------    
    #region SSP_CAM015_MS45
    public class Ssp_cam015_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "15. Sifilis Gestacional o congénita";
            var lcrValor        = tobRegistro.Ssp_cam015_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 15;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " SIFILIS GESTACIONAL O CONGÉNITA DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrSexo == "M" && lnuEdadDias > 28) // Hombre con mas de 28 días
                    {
                        if (lcrValor != "0")
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " VALOR " + lcrValor + " NO APLICA PARA SEXO MASCULINO CON EDAD MAYOR DE 28 DIAS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else 
                    {
                        if (lcrSexo == "F" && lnuEdadDias > 480) // mujer con mas de 16 meses
                        {
                            if (lcrValor == "2")
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " VALOR DOS (2) SÓLO APLICA PARA MENOR CON SIFILIS CONGENITA (MENOS DE 16 MESES DE EDAD)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lcrGestacion == "1")
                            {
                                if (lcrValor == "0")
                                {
                                    lcrCodError = lcrCodigoError + "E5";
                                    lcrMens = " VALOR CERO (0) SÓLO APLICA PARA SEXO MASCULINO CON EDAD MAYOR A 16 MESES SE ESPERABA VALOR 1 - 3 - 21";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                            }
                            else
                            {
                                if (lcrValor == "1")
                                {
                                    lcrCodError = lcrCodigoError + "E6";
                                    lcrMens = " VALOR UNO (1) SÍFILIS GESTACIONAL SÓLO APLICA PARA MUJERES EN GESTACIÓN (GESTACION CAMPO 14)";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                                if (lcrValor == "0" && !Funciones.flgExisteElemento(lcrGestacion, ",", "0,2"))
                                {
                                    lcrCodError = lcrCodigoError + "E7";
                                    lcrMens = " EL VALOR (0), SE EMPLEA EN PERSONAS DE SEXO MASCULINO MAYORES DE 16 MESES O CUANDO EL CAMPO 14 SE DILIGENCIA CON LOS VALORES (0)";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                                if (lcrValor == "3" && Funciones.flgExisteElemento(lcrGestacion, ",", "0,2,21"))
                                {
                                    lcrCodError = lcrCodigoError + "E8";
                                    lcrMens = " VALOR TRES (3) SÓLO APLICA PARA MUJERES GESTANTES O SEXO MASCULINO O MUJER CON EDAD MENOR A 16 MESES";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }                              
                            }
                        }else
                        {
                            // Niños posibles de 16 meses
                            if (lcrValor == "1")
                            {
                                lcrCodError = lcrCodigoError + "E9";
                                lcrMens = " VALOR UNO (1) SÓLO APLICA PARA MUJERES CON SIFILIS GESTACIONAL";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lcrValor == "0")
                            {
                                lcrCodError = lcrCodigoError + "E10";
                                lcrMens = " VALOR CERO (0) NO APLICA SE ESPERABA VALOR 2 - 3 - 21  PARA EDAD MENOR A 16 MESES";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 16 - Hipertension Inducida por la Gestación
    //--------------------------------------------------    
    #region SSP_CAM016_MS45
    public class Ssp_cam016_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "16. Hipertension Inducida por la Gestación";
            var lcrValor        = tobRegistro.Ssp_cam016_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 16;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " HIPERTENSIÓN INDUCIDA POR LA GESTACIÓN DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,21"))
                    {
                        if (lcrSexo == "M") // Hombre 
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " HIPERTENSIÓN INDUCIDA POR LA GESTACIÓN ERRADO - VALOR UNO (1) DOS (2) o VALOR (21) NO APLICA PARA HOMBRES";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    if (Funciones.flgExisteElemento(lcrValor, ",", "1,21") && (lcrSexo == "F"))
                    {
                        if (lnuEdadDias < 3650 && lnuEdadDias > 17885) // es menor de 10 años o mayor de 49 años
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " VALOR UNO (1) O (21) SÓLO APLICA EN EDAD DENTRO DEL RANGO MUJERES FERTILES (10 A 49 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (lcrGestacion != "1") // No esta en gestación
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " HIPERTENSIÓN INDUCIDA POR LA GESTACIÓN SÓLO APLICA PARA MUJERES EN GESTACIÓN";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 17 - Hipotiroidismo Congénito
    //--------------------------------------------------    
    #region SSP_CAM017_MS45
    public class Ssp_cam017_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "17. Hipotiroidismo Congénito";
            var lcrValor        = tobRegistro.Ssp_cam017_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 17;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " HIPOTIROIDISMO CONGÉNITO DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias < 1095) // es menor de 3 años
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " DATO HIPOTIROIDISMO CONGÉNITO ERRADO  - VALOR CERO (0) NO APLICA PARA MENORES DE TRES AÑOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    if (lcrValor == "1")
                    {
                        if (lnuEdadDias > 1095) // es mayor de 3 años
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " DATO HIPOTIROIDISMO CONGÉNITO ERRADO  - APLICA PARA MENORES DE 36 MESES";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    } 
                    if (Funciones.flgExisteElemento(lcrValor, ",", "1,2,21"))
                    {
                        if (lnuEdadDias > 1095) // es mayor de 3 años
                        {
                            lcrCodError = lcrCodigoError + "E5";
                            lcrMens = " DATO HIPOTIROIDISMO CONGÉNITO ERRADO  - VALOR " + lcrValor + " NO APLICA PARA MAYORES DE TRES AÑOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 18 - Sintomático Respiratorio
    //--------------------------------------------------    
    #region SSP_CAM018_MS45
    public class Ssp_cam018_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "18. Sintomático Respiratorio";
            var lcrValor        = tobRegistro.Ssp_cam018_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 18;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " SINTOMÁTICO RESPIRATORIO DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 19 - Tuberculosis Multidrogoresistente
    //--------------------------------------------------    
    #region SSP_CAM019_MS45
    public class Ssp_cam019_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "19. Tuberculosis Multidrogoresistente";
            var lcrValor        = tobRegistro.Ssp_cam019_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 19;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TUBERCULOSIS MULTIDROGORESISTENTE DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 20 - Lepra
    //--------------------------------------------------    
    #region SSP_CAM020_MS45
    public class Ssp_cam020_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "20. Lepra";
            var lcrValor        = tobRegistro.Ssp_cam020_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 20;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2,3,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " LEPRA DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 21 - Obesidad o Desnutrición Proteico Calórica
    //--------------------------------------------------    
    #region SSP_CAM021_MS45
    public class Ssp_cam021_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo      = "21. Obesidad o Desnutrición Proteico Calórica";
            var lcrValor            = tobRegistro.Ssp_cam021_ms45;
            var lcrMens             = String.Empty;
            var lcNumeroCampo       = 21;
            var lcrNivelError       = "1";
            var lcrCodigoError      = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError         = String.Empty;

            var lcrFecFormato       = tobParam.FechaFormato;
            var lcrFecSeparad       = tobParam.FechaSeparador;
            var lnuPeso             = Convert.ToDecimal(tobRegistro.Ssp_cam030_ms45);
            var lnuTalla            = Convert.ToInt32(tobRegistro.Ssp_cam032_ms45);
            Decimal lnuIMC          = 0;
            var llgPesoTallaValido  = true;
            var ldaFechNacim        = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias         = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2,3,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " OBESIDAD O DESNUTRICIÓN PROTEICO CALÓRICA DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else 
                {
                    // verificar si se puede hacer el calculo para IMC
                    if (lnuPeso == 999 || lnuTalla == 999) 
                    {
                        llgPesoTallaValido= false;
                    }
                    else
                    {
                        lnuIMC = (lnuTalla / ((lnuPeso / 100) * (lnuPeso / 100)));    
                    }
                    // mayores de 18 años con obesidad
                    if (lcrValor == "1")
                    {
                        if (llgPesoTallaValido == false)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " DATO OBESIDAD O DESNUTRICIÓN PROTEICO CALÓRICA ERRADO  - NO SE CUENTA CON VALOR PESO O TALLA";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else 
                        {
                            if (lnuIMC < 39) // se cambio de 30 a 39
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " DATO OBESIDAD O DESNUTRICIÓN PROTEICO CALÓRICA ERRADO  - APLICA PARA IMC MAYOR DE 39";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lnuEdadDias < 6570) // menor de 18 años
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " DATO OBESIDAD O DESNUTRICIÓN PROTEICO CALÓRICA ERRADO  - APLICA PARA IMC MAYOR DE 18 AÑOS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                             }
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 22 - Víctima de Maltrato
    //--------------------------------------------------    
    #region SSP_CAM022_MS45
    public class Ssp_cam022_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "22. Víctima de Maltrato";
            var lcrValor        = tobRegistro.Ssp_cam022_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 22;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " OBESIDAD O DESNUTRICIÓN PROTEICO CALÓRICA DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    // Hombres menores de 19 años Y 3 meses
                    if (lnuEdadDias > 7025 && lcrSexo == "M")
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " VALOR " + lcrValor + " NO APLICA PARA SEXO MASCULINO CON EDAD MAYOR DE 19 AÑOS Y TRES MESES";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (lcrValor == "0")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " VALOR CERO (0) SÓLO APLICA PARA SEXO MASCULINO CON EDAD MAYOR A 19 AÑOS Y TRES MESES";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        if (lnuEdadDias > 7025 && lcrSexo == "F")
                        {
                            if (lcrValor == "2")
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " VALOR DOS (2) SÓLO APLICA PARA MENOR VICTIMA DE MALTRATO (MENOR A 19 AÑOS Y TRES MESES)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrValor == "1")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " VALOR UNO (1) SÓLO APLICA PARA MUJERES Y EDAD MAYOR A 19 AÑOS Y TRES MESES";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion      
    //--------------------------------------------------
    // 23 - Víctima de Violencia Sexual
    //--------------------------------------------------    
    #region SSP_CAM023_MS45
    public class Ssp_cam023_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "23. Víctima de Violencia Sexual";
            var lcrValor        = tobRegistro.Ssp_cam019_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 23;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " VÍCTIMA DE VIOLENCIA SEXUAL DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 24 - Infecciones de Trasmisión Sexual
    //--------------------------------------------------    
    #region SSP_CAM024_MS45
    public class Ssp_cam024_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "24. Infecciones de Trasmisión Sexual";
            var lcrValor        = tobRegistro.Ssp_cam024_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 24;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " INFECCIONES DE TRANSMISIÓN SEXUAL DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 25 - Enfermedad Mental
    //--------------------------------------------------    
    #region SSP_CAM025_MS45
    public class Ssp_cam025_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "25. Enfermedad Mental";
            var lcrValor        = tobRegistro.Ssp_cam025_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 25;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2,3,4,5,6,7,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " ENFERMEDAD MENTAL DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 26 - Cáncer de Cérvix
    //--------------------------------------------------    
    #region SSP_CAM026_MS45
    public class Ssp_cam026_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "26. Cáncer de Cérvix";
            var lcrValor        = tobRegistro.Ssp_cam026_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 26;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " CÁNCER DE CÉRVIX DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    // MUJERES
                    if (lcrValor == "0")
                    {
                        if (lcrSexo == "F") 
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " VALOR CERO (0) SÓLO APLICA PARA HOMBRES";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    // HOMBRES
                    if (lcrValor == "1")
                    {
                        if (lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " VALOR UNO (1) SÓLO APLICA PARA MUJERES";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    if (lcrValor == "21")
                    {
                        if (lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E5";
                            lcrMens = " VALOR 21 SÓLO APLICA PARA MUJERES";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion      
    //--------------------------------------------------
    // 27 - Cáncer de Seno
    //--------------------------------------------------    
    #region SSP_CAM027_MS45
    public class Ssp_cam027_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "27. Cáncer de Seno";
            var lcrValor        = tobRegistro.Ssp_cam027_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 27;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " CANCER DE SENO DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 28 - Fluorosis Dental
    //--------------------------------------------------    
    #region SSP_CAM028_MS45
    public class Ssp_cam028_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "28. Fluorosis Dental";
            var lcrValor        = tobRegistro.Ssp_cam028_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 28;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FLUOROSIS DENTAL DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion         
    //--------------------------------------------------
    // 29 - Fecha del Peso
    //--------------------------------------------------
    #region SSP_CAM029_MS45
    public class Ssp_cam029_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "29. Fecha del Peso";
            var lcrValor        = tobRegistro.Ssp_cam029_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 29;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA DE PESO ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA DE PESO MAYOR QUE FECHA FIN PERIODO REPORTADO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 30 - Peso en Kilogramos
    //--------------------------------------------------    
    #region SSP_CAM030_MS45
    public class Ssp_cam030_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "30. Peso en Kilogramos";
            var lcrValor        = tobRegistro.Ssp_cam030_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 30;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (Convert.ToInt32(lcrValor) <= 0)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " PESO DEBE SER MAYOR QUE CERO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // Dato diferente a 999
                    if (Convert.ToInt32(lcrValor) != 999)
                    {
                        if (Convert.ToDecimal(lcrValor) >= 250)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " DATO PESO " + lcrValor + " EN KILOGRAMOS NO VALIDO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 31 - Fecha de la Talla
    //--------------------------------------------------
    #region SSP_CAM031_MS45
    public class Ssp_cam031_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "31. Fecha de la Talla";
            var lcrValor        = tobRegistro.Ssp_cam031_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 31;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA DE TALLA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA DE TALLA MAYOR QUE FECHA FIN PERIODO REPORTADO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 32 - Valor Talla en Centímetros
    //--------------------------------------------------    
    #region SSP_CAM032_MS45
    public class Ssp_cam032_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "32. Valor Talla en Centímetros";
            var lcrValor        = tobRegistro.Ssp_cam032_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 32;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechaTalla   = tobRegistro.Ssp_cam031_ms45;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (Convert.ToInt32(lcrValor) <= 0)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TALLA DEBE SER MAYOR QUE CERO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // Dato diferente a 999
                    if (Convert.ToInt32(lcrValor) != 999)
                    {
                        if (Convert.ToDecimal(lcrValor) >= 225)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " DATO TALLA EN CENTIMETROS ERRADO  - NO ES UNA TALLA VALIDA";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else 
                    {
                        if (Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, ldaFechaTalla))
                        {
                            if (ldaFechaTalla != "1800-01-01")
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " TALLA EN CENTIMETROS NO CONCUERDA CON CAMPO 31 (FECHA TOMA DE TALLA)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 33 - Fecha Probable de Parto
    //--------------------------------------------------
    #region SSP_CAM033_MS45
    public class Ssp_cam033_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "33. Fecha Probable de Parto";
            var lcrValor        = tobRegistro.Ssp_cam033_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 33;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA PROBABLE DE PARTO ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor != "1845-01-01")
                    {
                        if (lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " DATO FECHA PROBABLE PARTO - NO APLICA PARA HOMBRE";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (lcrGestacion != "1")
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " NO ES UNA MUJER EN GESTACIÓN";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lcrGestacion == "1")
                            {
                                if (lnuEdadDias < 3650 && lnuEdadDias > 17885)
                                {
                                    lcrCodError = lcrCodigoError + "E6";
                                    lcrMens = " FUERA DE RANGO EDAD GESTACIÓN (10 A 49 AÑOS)";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion      
    //--------------------------------------------------
    // 34 - Edad Gestacional al Nacer
    //--------------------------------------------------    
    #region SSP_CAM034_MS45
    public class Ssp_cam034_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "34. Edad Gestacional al Nacer";
            var lcrValor        = tobRegistro.Ssp_cam034_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 34;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (Convert.ToInt32(lcrValor) != 0)
                {
                    if (lnuEdadDias >= 2280) // 2280= 6 años y 3 meses
                    {
                        lcrCodError = lcrCodigoError + "E2";
                        lcrMens = " DATO EDAD GESTACIONAL AL NACER ERRADO  - ES MAYOR DE 6 AÑOS";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
                if (Convert.ToInt32(lcrValor) == 0)
                {
                    if (lnuEdadDias < 2280) // 2280= 6 años y 3 meses
                    {
                        lcrCodError = lcrCodigoError + "E2";
                        lcrMens = " DATO EDAD GESTACIONAL AL NACER ERRADO  - ES MENOR DE 6 AÑOS";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }                    
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 35 - BCG
    //--------------------------------------------------    
    #region SSP_CAM035_MS45
    public class Ssp_cam035_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "35. BCG";
            var lcrValor        = tobRegistro.Ssp_cam035_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 35;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " BCG - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias < 2280) // sólo mayores de 6 años y 3 meses
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " LA OPCIÓN CERO (0) APLICA SOLO EN MAYORES DE 6 AÑOS DE EDAD";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 36 - Hepatitis B menores de 1 año
    //--------------------------------------------------    
    #region SSP_CAM036_MS45
    public class Ssp_cam036_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "36. Hepatitis B menores de 1 año";
            var lcrValor        = tobRegistro.Ssp_cam036_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 36;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " HEPATITIS B MENORES DE 1 AÑO - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mayores de 28 dias de nacidos
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias <= 28) // menores de, o con 28 días de nacidos
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " LA OPCIÓN CERO (0) APLICA SOLO EN MAYORES DE 28 DIAS DE NACIDO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 37 - Pentavalente
    //--------------------------------------------------    
    #region SSP_CAM037_MS45
    public class Ssp_cam037_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "37. Pentavalente";
            var lcrValor        = tobRegistro.Ssp_cam037_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 37;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " PENTAVALENTE - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mayores de 2 años de edad
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias < 730) // menores de 2 años
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " LA OPCIÓN CERO (0) APLICA SOLO EN MAYORES DE 2 AÑOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 38 - Polio
    //--------------------------------------------------    
    #region SSP_CAM038_MS45
    public class Ssp_cam038_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "38. Polio";
            var lcrValor        = tobRegistro.Ssp_cam038_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 38;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,4,5,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " POLIO - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mayores de 6 años Y 3 meses
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias <= 2280)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " POLIO DEBERIA APLICAR POR LA EDAD (MENOR DE 6 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else 
                    {
                        if (lnuEdadDias > 2280)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " POLIO NO APLICA POR LA EDAD (MAYOR DE 6 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 39 - DPT menores de 5 años
    //--------------------------------------------------    
    #region SSP_CAM039_MS45
    public class Ssp_cam039_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "39. DPT menores de 5 años";
            var lcrValor        = tobRegistro.Ssp_cam039_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 39;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,4,5,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " DPT MENORES DE 5 AÑOS - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mayores de 6 años Y 3 meses
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias <= 2280)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " DPT DEBERIA APLICAR POR LA EDAD (MENOR DE 6 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias > 2280)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " DPT NO APLICA POR LA EDAD (MAYOR DE 6 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 40 - Rotavirus
    //--------------------------------------------------    
    #region SSP_CAM040_MS45
    public class Ssp_cam040_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "40. Rotavirus";
            var lcrValor        = tobRegistro.Ssp_cam040_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 40;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " ROTAVIRUS - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mayores de 8 meses de edad
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias <= 240)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " ROTAVIRUS DEBERIA APLICAR POR LA EDAD (MENOR DE 8 MESES)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias > 240)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " ROTAVIRUS NO APLICA POR LA EDAD (MAYOR DE 8 MESES)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 41 - Neumococo
    //--------------------------------------------------    
    #region SSP_CAM041_MS45
    public class Ssp_cam041_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "41. Neumococo";
            var lcrValor        = tobRegistro.Ssp_cam041_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 41;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " NEUMOCOCO - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mayores de 3 años
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias <= 1095)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " NEUMOCOCO DEBERIA APLICAR POR LA EDAD (MENOR DE 3 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias > 1095)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " NEUMOCOCO NO APLICA POR LA EDAD (MAYOR DE 3 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 42 - Influenza Niños
    //--------------------------------------------------    
    #region SSP_CAM042_MS45
    public class Ssp_cam042_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "42. Influenza Niños";
            var lcrValor        = tobRegistro.Ssp_cam042_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 42;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " INFLUENZA NIÑOS - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mayores de 3 años
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias <= 1095)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " INFLUENZA DEBERIA APLICAR POR LA EDAD (MENOR DE 3 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias > 1095)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " INFLUENZA NO APLICA POR LA EDAD (MAYOR DE 3 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 43 - Fiebre Amarilla niños de 1 año
    //--------------------------------------------------    
    #region SSP_CAM043_MS45
    public class Ssp_cam043_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "43. Fiebre Amarilla niños de 1 año";
            var lcrValor        = tobRegistro.Ssp_cam043_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 43;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FIEBRE AMARILLA - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mayores de 2 años
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias <= 730)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " FIEBRE AMARILLA DEBERIA APLICAR POR LA EDAD (MENOR DE 2 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias > 730)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " FIEBRE AMARILLA NO APLICA POR LA EDAD (MAYOR DE 2 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 44 - Hepatitis A
    //--------------------------------------------------    
    #region SSP_CAM044_MS45
    public class Ssp_cam044_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "44. Hepatitis A";
            var lcrValor        = tobRegistro.Ssp_cam044_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 44;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " HEPATITIS A - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mayores de 2 años
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias <= 730)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " HEPATITIS DEBERIA APLICAR POR LA EDAD (MENOR DE 2 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias > 730)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " HEPATITIS NO APLICA POR LA EDAD (MAYOR DE 2 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 45 - Triple Viral Niños
    //--------------------------------------------------    
    #region SSP_CAM045_MS45
    public class Ssp_cam045_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "45. Triple Viral Niños";
            var lcrValor        = tobRegistro.Ssp_cam045_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 45;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TRIPLE VIRAL - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mayores de 6 años
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias <= 2190)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " TRIPLE VIRAL DEBERÍA APLICAR POR LA EDAD (MENOR DE 6 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias > 2190)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " TRIPLE VIRAL NO APLICA POR LA EDAD (MAYOR DE 6 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 46 - Virus del Papiloma Humano (VPH)
    //--------------------------------------------------    
    #region SSP_CAM046_MS45
    public class Ssp_cam046_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "46. Virus del Papiloma Humano (VPH)";
            var lcrValor        = tobRegistro.Ssp_cam046_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 46;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " VIRUS DEL PAPILOMA HUMANO (VPH) - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor == "0")
                    {
                        if (lcrSexo != "M") 
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " VIRUS DEL PAPILOMA HUMANO (VPH) DEBE APLICAR PARA SEXO FEMENINO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    if (lcrValor != "0")
                    {
                        if (lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " VIRUS DEL PAPILOMA HUMANO (VPH) NO APLICA PARA SEXO MASCULINO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 47 - TD o TT Mujeres en Edad Fértil 15 a 49 años
    //--------------------------------------------------    
    #region SSP_CAM047_MS45
    public class Ssp_cam047_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "47. TD o TT Mujeres en Edad Fértil 15 a 49 años";
            var lcrValor        = tobRegistro.Ssp_cam047_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 47;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,4,5,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TD O TT - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor == "0")
                    {
                        if (lcrSexo == "F" && lnuEdadDias >= 5475 && lnuEdadDias <= 17885)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " VALOR CERO (0) ERRADO PARA MUJERES EN EDAD FERTIL (15 A 49 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " TD O TT MUJERES EN EDAD FÉRTIL 15 A 49 SOLO APLICA PARA SEXO FEMENINO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (lnuEdadDias < 5475 || lnuEdadDias > 17885)
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " VALOR " + lcrValor + " SOLO APLICA PARA MUJERES EN EDAD FERTIL (15 A 49 AÑOS)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }

                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 48 - Control de Placa Bacteriana
    //--------------------------------------------------    
    #region SSP_CAM048_MS45
    public class Ssp_cam048_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "48. Control de Placa Bacteriana";
            var lcrValor        = tobRegistro.Ssp_cam048_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 48;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " CONTROL DE PLACA BACTERIANA - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // menores de 2 años
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias > 730)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " VALOR CERO (0) CONTROL DE PLACA BACTERIANA APLICA PARA MENORES DE 2 AÑOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    if (lcrValor != "0")
                    {
                        if (lnuEdadDias < 730)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " VALOR " + lcrValor + " CONTROL DE PLACA BACTERIANA APLICA PARA MAYORES DE 2 AÑOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 49 - Fecha atención parto o cesárea
    //--------------------------------------------------
    #region SSP_CAM049_MS45
    public class Ssp_cam049_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "49. Fecha atención parto o cesárea";
            var lcrValor        = tobRegistro.Ssp_cam049_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 49;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA DE ATENCIÓN PARTO O CESÁREA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA DE ATENCIÓN PARTO O CESÁREA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (lcrValor == "1845-01-01")
                        {
                            if (lcrGestacion == "1")
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA ATENCIÓN PARTO O CESÁREA NO CONCUERDA CON CAMPO 14 (GESTACIÓN)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA ATENCIÓN PARTO O CESÁREA NO APLICA PARA HOMBRES";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 50 - Fecha salida de la atención del parto o cesárea
    //--------------------------------------------------
    #region SSP_CAM050_MS45
    public class Ssp_cam050_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "50. Fecha salida de la atención del parto o cesárea";
            var lcrValor        = tobRegistro.Ssp_cam050_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 50;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA SALIDA ATENCIÓN PARTO O CESÁREA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA DE SALIDA DE LA ATENCIÓN PARTO O CESÁREA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (lcrValor == "1845-01-01")
                        {
                            if (lcrGestacion == "1")
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA SALIDA ATENCIÓN PARTO O CESÁREA NO CONCUERDA CON CAMPO 14 (GESTACIÓN)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA SALIDA ATENCIÓN PARTO O CESÁREA NO APLICA PARA HOMBRES";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 51 - Fecha de consejería en Lactancia Materna
    //--------------------------------------------------
    #region SSP_CAM051_MS45
    public class Ssp_cam051_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "51. Fecha de consejería en Lactancia Materna";
            var lcrValor        = tobRegistro.Ssp_cam051_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 51;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA DE CONSEJERIA EN LACTANCIA MATERNA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA DE CONSEJERIA EN LACTANCIA MATERNA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (lcrValor == "1845-01-01")
                        {
                            if (lcrGestacion == "1")
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA DE CONSEJERÍA EN LACTANCIA MATERNA NO CONCUERDA CON CAMPO 14 (GESTACIÓN)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA DE CONSEJERÍA EN LACTANCIA MATERNA NO APLICA PARA HOMBRES";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 52 - Control Recién Nacido
    //--------------------------------------------------
    #region SSP_CAM052_MS45
    public class Ssp_cam052_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "52. Control Recién Nacido";
            var lcrValor        = tobRegistro.Ssp_cam052_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 52;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA DE CONTROL RECIÉN NACIDO ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA DE CONTROL RECIÉN NACIDO MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        // mayores de 30 dias de nacidos
                        if (lcrValor == "1845-01-01")
                        {
                            if (lnuEdadDias < 30)
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " VALOR 1845-01-01 CONTROL RECIÉN NACIDO NO APLICA PARA RECIÉN NACIDO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lnuEdadDias > 30)
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " DATO CONTROL RECIÉN NACIDO ERRADO - NO ES UN RECIÉN NACIDO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 53 - Planificación Familiar Primera vez
    //--------------------------------------------------
    #region SSP_CAM053_MS45
    public class Ssp_cam053_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "53. Planificación Familiar Primera vez";
            var lcrValor        = tobRegistro.Ssp_cam053_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 53;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA PLANIFICACIÓN FAMILIAR PRIMERA VEZ ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA PLANIFICACIÓN FAMILIAR PRIMERA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        // menores de 10 Años
                        if (lcrValor == "1845-01-01")
                        {
                            if (lnuEdadDias > 3650 && lnuEdadDias < 16425 && lcrGestacion != "1") // ENTRE 10 Y 45 AÑOS
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " EDAD APTA PARA RECIBIR PLANIFICACIÓN FAMILIAR";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lnuEdadDias < 3650)
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " PLANIFICACIÓN FAMILIAR NO APLICA PARA MENORES DE 10 AÑOS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lcrGestacion == "1")
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " PLANIFICACIÓN FAMILIAR NO APLICA PARA MUJERES GESTANTES";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion       
    //--------------------------------------------------
    // 54 - Suministro de Método Anticonceptivo
    //--------------------------------------------------    
    #region SSP_CAM054_MS45
    public class Ssp_cam054_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "54. Suministro de Método Anticonceptivo";
            var lcrValor        = tobRegistro.Ssp_cam054_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 54;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,20,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " POLIO - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // menores de 10 Años Y hombres
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias > 3650 && lnuEdadDias < 17885 && lcrSexo == "F" && lcrGestacion != "1") // Excluye a mujeres fertiles
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " SUMINISTRO DE MÉTODO ANTICONCEPTIVO SE DEBERIA APLICAR POR EDAD Y SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        if (lnuEdadDias > 3650 && lnuEdadDias < 17885 && lcrSexo == "M") // Excluye a hombres menores de 10 y mayores de 49 años
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " SUMINISTRO DE MÉTODO ANTICONCEPTIVO SE DEBERIA APLICAR POR EDAD Y SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias < 3650)
                        {
                            lcrCodError = lcrCodigoError + "E5";
                            lcrMens = " SUMINISTRO DE MÉTODO ANTICONCEPTIVO NO APLICA POR EDAD";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        if (lcrGestacion == "1")
                        {
                            lcrCodError = lcrCodigoError + "E6";
                            lcrMens = " SUMINISTRO DE MÉTODO ANTICONCEPTIVO NO APLICA PARA MUJERES GESTANTES";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion   
    // 55 - Fecha Suministro de Método Anticonceptivo
    //--------------------------------------------------
    #region SSP_CAM055_MS45
    public class Ssp_cam055_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "55. Fecha Suministro de Método Anticonceptivo";
            var lcrValor        = tobRegistro.Ssp_cam055_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 55;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA SUMINISTRO METODO ANTICONCEPTIVO ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA SUMINISTRO METODO ANTICONCEPTIVO MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        // menores de 10 Años Y hombres
                        if (lcrValor == "1845-01-01")
                        {
                            if (lnuEdadDias > 3650 && lnuEdadDias < 16425 && lcrGestacion != "1") // ENTRE 10 Y 45 AÑOS
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA SUMINISTRO DE MÉTODO ANTICONCEPTIVO SE DEBERIA APLICAR POR EDAD";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lnuEdadDias < 3650)
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA SUMINISTRO DE MÉTODO ANTICONCEPTIVO NO APLICA POR EDAD";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lcrGestacion == "1")
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " FECHA SUMINISTRO DE MÉTODO ANTICONCEPTIVO NO APLICA PARA MUJERES GESTANTES";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion       
    // 56 - Fecha Control Prenatal de Primera vez
    //--------------------------------------------------
    #region SSP_CAM056_MS45
    public class Ssp_cam056_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "56. Fecha Control Prenatal de Primera vez";
            var lcrValor        = tobRegistro.Ssp_cam056_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 56;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CONTROL PRENATAL DE PRIMERA VEZ ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CONTROL PRENATAL DE PRIMERA VEZ MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        // hombres Y mujeres no gestantes
                        if (lcrValor == "1845-01-01")
                        {
                            if (lcrSexo == "F" && lnuEdadDias > 3650 && lcrGestacion == "1") // lnuEdadDias = 3650 es 10 años
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA CONTROL PRENATAL DE PRIMERA SE DEBERIA APLICAR POR EDAD Y SEXO Y GESTACIÓN";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA CONTROL PRENATAL DE PRIMERA VEZ NO APLICA PARA SEXO MASCULINO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lcrGestacion != "1" || lnuEdadDias < 3650)
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " FECHA CONTROL PRENATAL DE PRIMERA VEZ NO APLICA POR EDAD O ESTADO DE GESTACIÓN";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 57 - Número de Control Prenatal
    //--------------------------------------------------    
    #region SSP_CAM057_MS45
    public class Ssp_cam057_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "57. Número de Control Prenatal";
            var lcrValor        = tobRegistro.Ssp_cam057_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 57;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (Convert.ToInt32(lcrValor) < 0)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " NÚMERO DE CONTROLES DEBE SER MAYOR QUE CERO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Convert.ToInt32(lcrValor) > 999)
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " NÚMERO DE CONTROLES ERRADO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        // hombres Y mujeres no gestantes
                        if (Convert.ToInt32(lcrValor) == 0)
                        {
                            if (lcrSexo == "F" && lnuEdadDias > 3650 && lcrGestacion == "1")
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " VALOR CERO (0) CONTROL PRENATAL DE PRIMERA SE DEBERIA APLICAR POR EDAD Y SEXO Y GESTACIÓN";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " DATO CONTROL PRENATAL DE PRIMERA VEZ NO APLICA PARA SEXO MASCULINO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            else
                            {
                                if (lcrGestacion != "1" || lnuEdadDias < 3650)
                                {
                                    lcrCodError = lcrCodigoError + "E6";
                                    lcrMens = " DATO CONTROL PRENATAL DE PRIMERA VEZ NO APLICA POR EDAD O ESTADO DE GESTACIÓN";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion         
    // 58 - Fecha Último Control Prenatal
    //--------------------------------------------------
    #region SSP_CAM058_MS45
    public class Ssp_cam058_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "58. Fecha Último Control Prenatal";
            var lcrValor        = tobRegistro.Ssp_cam058_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 58;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA ULTIMO CONTROL PRENATAL ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA ULTIMO CONTROL PRENATAL MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        // hombres Y mujeres no gestantes
                        if (lcrValor == "1845-01-01")
                        {
                            if (lcrSexo == "F" && lnuEdadDias > 3650 && lcrGestacion == "1") // lnuEdadDias = 3650 es 10 años
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA ÚLTIMO CONTROL PRENATAL SE DEBERIA APLICAR POR EDAD Y SEXO Y GESTACIÓN";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA ULTIMO CONTROL PRENATAL NO APLICA PARA SEXO MASCULINO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lcrGestacion != "1" || lnuEdadDias < 3650)
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " FECHA ULTIMO CONTROL PRENATAL NO APLICA POR EDAD O ESTADO DE GESTACIÓN";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 59 - Suministro de Ácido Fólico en el Último Control Prenatal
    //--------------------------------------------------    
    #region SSP_CAM059_MS45
    public class Ssp_cam059_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "59. Suministro de Ácido Fólico en el Último Control Prenatal";
            var lcrValor        = tobRegistro.Ssp_cam059_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 59;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,16,17,18,20,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " SUMINISTRO DE ÁCIDO FÓLICO - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mujeres no gestantes
                    if (lcrValor == "0")
                    {
                        if (lcrSexo == "F" && lnuEdadDias > 3650 && lcrGestacion == "1") 
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " DATO SUMINISTRO DE ÁCIDO FÓLICO EN EL ÚLTIMO CONTROL PRENATAL SE DEBERIA APLICAR POR EDAD SEXO Y GESTACIÓN";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " DATO SUMINISTRO DE ÁCIDO FÓLICO EN EL ÚLTIMO CONTROL PRENATAL NO APLICA PARA SEXO MASCULINO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        if (lcrGestacion != "1" || lnuEdadDias < 3650)
                        {
                            lcrCodError = lcrCodigoError + "E5";
                            lcrMens = " DATO SUMINISTRO DE ÁCIDO FÓLICO EN ÚLTIMO CONTROL PRENATAL NO APLICA POR EDAD O ESTADO DE GESTACIÓN";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 60 - Suministro de Sulfato Ferroso en el Último Control Prenatal
    //--------------------------------------------------    
    #region SSP_CAM060_MS45
    public class Ssp_cam060_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "60. Suministro de Sulfato Ferroso en el Último Control Prenatal";
            var lcrValor        = tobRegistro.Ssp_cam060_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 60;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,16,17,18,20,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " SUMINISTRO DE SULFATO FERROSO - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mujeres no gestantes
                    if (lcrValor == "0")
                    {
                        if (lcrSexo == "F" && lnuEdadDias > 3650 && lcrGestacion == "1")
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " SUMINISTRO DE SULFATO FERROSO EN EL ÚLTIMO CONTROL PRENATAL SE DEBERIA APLICAR POR EDAD SEXO Y GESTACIÓN";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " SUMINISTRO DE SULFATO FERROSO EN EL ÚLTIMO CONTROL PRENATAL NO APLICA PARA SEXO MASCULINO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        if (lcrGestacion != "1" || lnuEdadDias < 3650)
                        {
                            lcrCodError = lcrCodigoError + "E5";
                            lcrMens = " SUMINISTRO DE SULFATO FERROSO EN ÚLTIMO CONTROL PRENATAL NO APLICA POR EDAD O ESTADO DE GESTACIÓN";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 61 - Suministro de Carbonato de Calcio en el Último Control Prenatal
    //--------------------------------------------------    
    #region SSP_CAM061_MS45
    public class Ssp_cam061_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "61. Suministro de Carbonato de Calcio en el Último Control Prenatal";
            var lcrValor        = tobRegistro.Ssp_cam061_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 61;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,16,17,18,20,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " SUMINISTRO DE CARBONATO DE CALCIO - DATO NO VALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // mujeres no gestantes
                    if (lcrValor == "0")
                    {
                        if (lcrSexo == "F" && lnuEdadDias > 3650 && lcrGestacion == "1")
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " SUMINISTRO DE CARBONATO DE CALCIO EN ÚLTIMO CONTROL PRENATAL SE DEBERIA APLICAR POR EDAD SEXO Y GESTACIÓN";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E5";
                            lcrMens = " SUMINISTRO DE CARBONATO DE CALCIO EN ÚLTIMO CONTROL PRENATAL NO APLICA PARA SEXO MASCULINO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        if (lcrGestacion != "1" || lnuEdadDias < 3650)
                        {
                            lcrCodError = lcrCodigoError + "E6";
                            lcrMens = " SUMINISTRO DE CARBONATO DE CALCIO EN ÚLTIMO CONTROL PRENATAL NO APLICA POR EDAD O ESTADO DE GESTACIÓN";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion   
    //--------------------------------------------------
    // 62 - Valoración de la Agudeza Visual
    //--------------------------------------------------    
    #region SSP_CAM062_MS45
    public class Ssp_cam062_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "62. Valoración de la Agudeza Visual";
            var lcrValor        = tobRegistro.Ssp_cam062_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 62;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA VALORACIÓN DE LA AGUDEZA VISUAL ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA VALORACIÓN DE LA AGUDEZA VISUAL MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 63 - Consulta por Oftalmología
    //--------------------------------------------------    
    #region SSP_CAM063_MS45
    public class Ssp_cam063_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "63. Consulta por Oftalmología";
            var lcrValor        = tobRegistro.Ssp_cam063_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 63;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CONSULTA POR OFTALMOLOGIA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CONSULTA POR OFTALMOLOGIA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 64 - Fecha Diagnóstico Desnutrición Proteico Calórica
    //--------------------------------------------------    
    #region SSP_CAM064_MS45
    public class Ssp_cam064_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "64. Fecha Diagnóstico Desnutrición Proteico Calórica";
            var lcrValor        = tobRegistro.Ssp_cam064_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 64;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrDesnutricion = tobRegistro.Ssp_cam021_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA DIAGNOSTICO DESNUTRICIÓN PROTEICO CALORICA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA DIAGNOSTICO DESNUTRICIÓN PROTEICO CALORICA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    { // Desnutrición Proteico Calórica
                        if (lcrValor == "1845-01-01")
                        {
                            if (Funciones.flgExisteElemento(lcrDesnutricion,",","1,2"))
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA DESNUTRICION PROTEICA CALORICA NO CONCUERDA CON CAMPO 21(DESNUTRICION)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrDesnutricion == "3")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA DESNUTRICION PROTEICA CALORICA NO CONCUERDA CON CAMPO 21(DESNUTRICION)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 65 - Fecha Consulta Mujer o Menor Víctima del Maltrato
    //--------------------------------------------------    
    #region SSP_CAM065_MS45
    public class Ssp_cam065_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "65. Fecha Consulta Mujer o Menor Víctima del Maltrato";
            var lcrValor        = tobRegistro.Ssp_cam065_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 65;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrVictimaMal   = tobRegistro.Ssp_cam022_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CONSULTA MUJER O MENOR VICTIMA DEL MALTRATO ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CONSULTA MUJER O MENOR VICTIMA DEL MALTRATO MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    { // Mujer o Menor Víctima del Maltrato
                        if (lcrValor != "1845-01-01")
                        {
                            if (lcrVictimaMal != "1" && lcrVictimaMal != "2")
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA CONSULTA MUJER O MENOR VICTIMA DEL MALTRATO NO CONCUERDA CON CAMPO 22 (VICTIMA MALTRATO)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrValor == "1845-01-01")
                            {
                                if (lcrVictimaMal == "1" || lcrVictimaMal == "2")
                                {
                                    lcrCodError = lcrCodigoError + "E6";
                                    lcrMens = " FECHA CONSULTA MUJER O MENOR VICTIMA DEL MALTRATO NO CONCUERDA CON CAMPO 22 (VICTIMA MALTRATO)";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 66 - Consulta Víctimas de Violencia Sexual
    //--------------------------------------------------    
    #region SSP_CAM066_MS45
    public class Ssp_cam066_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "66. Consulta Víctimas de Violencia Sexual";
            var lcrValor        = tobRegistro.Ssp_cam066_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 66;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrVictimaSex   = tobRegistro.Ssp_cam023_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CONSULTA VICTIMAS DE VIOLENCIA SEXUAL ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CONSULTA VICTIMAS DE VIOLENCIA SEXUAL MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    { // Víctimas de Violencia Sexual
                        if (lcrValor == "1845-01-01")
                        {
                            if (lcrVictimaSex == "1")
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA CONSULTA VICTIMAS DE VIOLENCIA SEXUAL NO CONCUERDA CON CAMPO 23 (VICTIMA VIOLENCIA SEXUAL)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(lcrVictimaSex, ",", "1,21"))
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA CONSULTA VICTIMAS DE VIOLENCIA SEXUAL NO CONCUERDA CON CAMPO 23 (VICTIMA VIOLENCIA SEXUAL)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 67 - Fecha Consulta Nutrición
    //--------------------------------------------------    
    #region SSP_CAM067_MS45
    public class Ssp_cam067_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "67. Fecha Consulta Nutrición";
            var lcrValor        = tobRegistro.Ssp_cam067_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 67;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CONSULTA DE NUTRICIÓN ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CONSULTA DE NUTRICIÓN MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion    
    //--------------------------------------------------
    // 68 - Consulta de Psicología
    //--------------------------------------------------    
    #region SSP_CAM068_MS45
    public class Ssp_cam068_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "68. Consulta de Psicología";
            var lcrValor        = tobRegistro.Ssp_cam068_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 68;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CONSULTA DE PSICOLOGIA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CONSULTA DE PSICOLOGIA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 69 - Fecha Consulta de Crecimiento y Desarrollo Primera vez
    //--------------------------------------------------    
    #region SSP_CAM069_MS45
    public class Ssp_cam069_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "69. Fecha Consulta de Crecimiento y Desarrollo Primera vez";
            var lcrValor        = tobRegistro.Ssp_cam069_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 69;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CONSULTA DE CRECIMIENTO Y DESARROLLO PRIMERA VEZ ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CONSULTA DE CRECIMIENTO Y DESARROLLO PRIMERA VEZ MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        // mayores de 10 años
                        if (lcrValor != "1845-01-01" && lcrValor != "1800-01-01")
                        {
                            if (lnuEdadDias > 3830) // 10 años y 6 meses
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " CONSULTA DE CRECIMIENTO Y DESARROLLO NO APLICA PARA MAYORES DE 10 AÑOS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 70 - Suministro de Sulfato Ferroso en la Última Consulta del Menor de 10 años
    //--------------------------------------------------    
    #region SSP_CAM070_MS45
    public class Ssp_cam070_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "70. Suministro de Sulfato Ferroso en la Última Consulta del Menor de 10 años";
            var lcrValor        = tobRegistro.Ssp_cam070_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 70;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,16,17,18,20,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " SUMINISTRO DE SULFATO FERROSO EN LA ULTIMA CONSULTA - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    //menores de 10 años
                    if (lcrValor != "0")
                    {
                        if (lnuEdadDias > 3650)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " SUMINISTRO DE SULFATO FERROSO EN LA ULTIMA CONSULTA SOLO APLICA PARA MENOR DE 10 AÑOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias < 3650)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " VALOR CERO (0) EN SUMINISTRO DE SULFATO FERROSO EN ULTIMA CONSULTA NO APLICA PARA MENOR DE 10 AÑOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 71 - Suministro de Vitamina A en la Última Consulta del Menor de 10 años
    //--------------------------------------------------    
    #region SSP_CAM071_MS45
    public class Ssp_cam071_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "71. Suministro de Vitamina A en la Última Consulta del Menor de 10 años";
            var lcrValor        = tobRegistro.Ssp_cam071_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 71;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,16,17,18,20,21"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " SUMINISTRO DE VITAMINA A EN LA ULTIMA CONSULTA - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    //menores de 10 años
                    if (lcrValor != "0")
                    {
                        if (lnuEdadDias > 3650)
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " SUMINISTRO DE VITAMINA A EN LA ULTIMA CONSULTA SOLO APLICA PARA MENOR DE 10 AÑOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias < 3650)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " VALOR CERO (0) EN SUMINISTRO DE VITAMINA A EN LA ULTIMA CONSULTA NO APLICA PARA MENOR DE 10 AÑOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 72 - Fecha Consulta de Joven Primera vez
    //--------------------------------------------------    
    #region SSP_CAM072_MS45
    public class Ssp_cam072_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "72. Fecha Consulta de Joven Primera vez";
            var lcrValor        = tobRegistro.Ssp_cam072_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 72;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CONSULTA DE JOVEN PRIMERA VEZ ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CONSULTA DE JOVEN PRIMERA VEZ MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        // jovenes entre 10 y 29 años
                        if (lcrValor == "1845-01-01")
                        {
                            if (lnuEdadDias >= 3830 && lnuEdadDias <= 10585) // ver si es poblacion objeto
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " VALOR 1845-01-01 NO APLICA PARA CONSULTA DE JOVEN PRIMERA VEZ CON EDAD 10 A 29 AÑOS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lnuEdadDias < 3830 || lnuEdadDias > 10585) 
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA CONSULTA DE JOVEN PRIMERA VEZ NO CUMPLE CON EDAD (10 A 29 AÑOS)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 73 - Fecha Consulta de Adulto Primera vez
    //--------------------------------------------------    
    #region SSP_CAM073_MS45
    public class Ssp_cam073_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "73. Fecha Consulta de Adulto Primera vez";
            var lcrValor        = tobRegistro.Ssp_cam073_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 73;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CONSULTA DE ADULTO PRIMERA VEZ ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CONSULTA DE ADULTO PRIMERA VEZ MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        // mayores de 45 años
                        if (lcrValor == "1845-01-01")
                        {
                            if (lnuEdadDias >= 16425) 
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " VALOR 1845-01-01 NO APLICA PARA CONSULTA DE ADULTO PRIMERA CON EDAD MAYOR DE 45 AÑOS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lnuEdadDias < 16425)
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA CONSULTA DE ADULTO PRIMERA VEZ NO CUMPLE CON EDAD (MAYOR DE 45 AÑOS)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 74 - Preservativos entregados a pacientes con ITS
    //--------------------------------------------------    
    #region SSP_CAM074_MS45
    public class Ssp_cam074_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "74. Preservativos entregados a pacientes con ITS";
            var lcrValor        = tobRegistro.Ssp_cam074_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 74;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrITS          = tobRegistro.Ssp_cam024_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (Convert.ToInt32(lcrValor) < 0)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " DATO PRESERVATIVOS ENTREGADOS DEBE SER MAYOR QUE CERO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Convert.ToInt32(lcrValor) > 999)
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " DATO PRESERVATIVOS ENTREGADOS ERRADO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    // con ITS
                    if (Convert.ToInt32(lcrValor) == 0)
                    {
                        if (lcrITS  == "1")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " VALOR CERO (0) NO APLICA PARA PRESERVATIVOS EN POBLACION POSITIVA PARA ENFERMEDAD DE TRASMISION SEXUAL";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 75 - Asesoría Pre test Elisa para VIH
    //--------------------------------------------------
    #region SSP_CAM075_MS45
    public class Ssp_cam075_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "75. Asesoría Pre test Elisa para VIH";
            var lcrValor        = tobRegistro.Ssp_cam075_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 75;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA PRE TEST ELISA PARA VIH ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA PRE TEST ELISA PARA VIH MAYOR QUE FECHA FIN PERIODO REPORTADO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 76 - Asesoría Pos test Elisa para VIH
    //--------------------------------------------------
    #region SSP_CAM076_MS45
    public class Ssp_cam076_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "76. Asesoría Pos test Elisa para VIH";
            var lcrValor        = tobRegistro.Ssp_cam076_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 76;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);


            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA POS TEST ELISA PARA VIH ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA POS TEST ELISA PARA VIH MAYOR QUE FECHA FIN PERIODO REPORTADO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    //  Paciente con Diagnóstico de: Ansiedad, Depresión, Esquizofrenia, déficit de atención, 
    //  consumo SPA y Bipolaridad recibió Atención en los últimos 6 meses por Equipo Interdisciplinario 
    //  Completo
    //--------------------------------------------------    
    #region SSP_CAM077_MS45
    public class Ssp_cam077_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "77. Paciente con Diagnóstico de Ansiedad";
            var lcrValor        = tobRegistro.Ssp_cam077_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 77;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;
            var lcrLoco     = tobRegistro.Ssp_cam025_ms45;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,16,17,18,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " PACIENTE CON DIAGNOSTICO DE ANSIEDAD DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {  //Paciente con locura 
                    if (lcrValor == "0")
                    {
                        if (Funciones.flgExisteElemento(lcrLoco, ",", "1,2,3,4,5,6,21"))
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " PACIENTE CON DIAGNOSTICO DE ANSIEDAD NO CORRESPONDE CON CAMPO 25 (ENFERMEDAD MENTAL)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (!Funciones.flgExisteElemento(lcrLoco, ",", "1,2,3,4,5,6,21"))
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " PACIENTE CON DIAGNOSTICO DE ANSIEDAD NO CORRESPONDE CON CAMPO 25 (ENFERMEDAD MENTAL)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion         
    //--------------------------------------------------
    // 78 - Fecha Antígeno de Superficie Hepatitis B en Gestantes
    //--------------------------------------------------
    #region SSP_CAM078_MS45
    public class Ssp_cam078_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "78. Fecha Antígeno de Superficie Hepatitis B en Gestantes";
            var lcrValor        = tobRegistro.Ssp_cam078_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 78;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            try
            {
                var lcrFecFormato   = tobParam.FechaFormato;
                var lcrFecSeparad   = tobParam.FechaSeparador;
                var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
                var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
                var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
                var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

                if (String.IsNullOrWhiteSpace(lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E1";
                    lcrMens     = " FALTA DATO EN CAMPO OBLIGATORIO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor.Trim().Length != 10)
                    {
                        lcrCodError = lcrCodigoError + "E2";
                        lcrMens = " FORMATO DE FECHA INVALIDO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " FECHA ANTIGENO DE SUPERFICIE HEPATITIS B EN GESTANTES ERRADA";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " FECHA ANTIGENO DE SUPERFICIE HEPATITIS B EN GESTANTES MAYOR QUE FECHA FIN DE PERIODO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) == Funciones.fdaConvertFecha("DMY", "/", "01/01/1845"))
                        {
                            if (lcrSexo == "F" && lnuEdadDias > 3650 && lnuEdadDias < 21899 && lcrGestacion == "1") // lnuEdadDias = 3650 es 10 años, 21899 es 60 años
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA ANTIGENO DE SUPERFICIE HEPATITIS B EN GESTANTES SE DEBERIA APLICAR POR EDAD SEXO Y GESTACIÓN";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA ANTIGENO DE SUPERFICIE HEPATITIS B EN GESTANTES NO APLICA PARA SEXO MASCULINO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            else
                            {
                                if (lcrGestacion != "1")
                                {
                                    lcrCodError = lcrCodigoError + "E7";
                                    lcrMens = " FECHA ANTIGENO DE SUPERFICIE HEPATITIS B EN GESTANTES NO APLICA PARA ESTADOS NO GESTANTE";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Validación campo 78 Fecha Antígeno de Superficie");
                lcrCodError = lcrCodigoError + "E5";
                lcrMens = " " + ex.Message;
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
        }
    }
    #endregion    
    // 79 - Resultado Antígeno de Superficie Hepatitis B en Gestantes 
    //--------------------------------------------------    
    #region SSP_CAM079_MS45
    public class Ssp_cam079_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "79. Resultado Antígeno de Superficie Hepatitis B en Gestantes";
            var lcrValor        = tobRegistro.Ssp_cam079_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 79;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " RESULTADO ANTIGENO DE SUPERFICIE HEPATITIS B EN GESTANTES - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor == "0")
                    {
                        if (lcrGestacion == "1")
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " RESULTADO ANTIGENO DE SUPERFICIE HEPATITIS B EN GESTANTES NO CONCUERDA CON CAMPO 14 (MUJER GESTANTE)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " RESULTADO ANTIGENO DE SUPERFICIE HEPATITIS B EN GESTANTES NO APLICA PARA SEXO MASCULINO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        if (lcrGestacion != "1")
                        {
                            lcrCodError = lcrCodigoError + "E5";
                            lcrMens = " RESULTADO ANTIGENO DE SUPERFICIE HEPATITIS B EN GESTANTES NO CONCUERDA CON CAMPO 14 (MUJER GESTANTE)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion          
    //--------------------------------------------------
    // 80 - Fecha Serología para Sífilis 
    //--------------------------------------------------    
    #region SSP_CAM080_MS45
    public class Ssp_cam080_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "80. Fecha Serología para Sífilis";
            var lcrValor        = tobRegistro.Ssp_cam080_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 80;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSifilis      = tobRegistro.Ssp_cam025_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA SEROLOGÍA PARA SÍFILIS ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA SEROLOGÍA PARA SÍFILIS MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        // aplica
                        if (lcrValor == "1845-01-01")
                        {
                            if (Funciones.flgExisteElemento(lcrSifilis, ",", "1,2"))
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA SEROLOGÍA PARA SÍFILIS ERRADO SE ENCONTRO DIAGNOSTICO DE SIFILIS EN CAMPO 15 (SIFILIS GESTACIONAL O CONGENITA)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 81 - Resultado Serología para Sífilis 
    //--------------------------------------------------
    #region SSP_CAM081_MS45
    public class Ssp_cam081_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo      = "81. Resultado Serología para Sífilis ";
            var lcrValor            = tobRegistro.Ssp_cam081_ms45;
            var lcrMens             = String.Empty;
            var lcNumeroCampo       = 81;
            var lcrNivelError       = "1";
            var lcrCodigoError      = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError         = String.Empty;

            var lcrFecFormato       = tobParam.FechaFormato;
            var lcrFecSeparad       = tobParam.FechaSeparador;
            var ldaFechaSerologia   = tobRegistro.Ssp_cam080_ms45;
            var ldaFechNacim        = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias         = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " RESULTADO SEROLOGÍA PARA SÍFILIS - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor == "0")
                    {
                        if (ldaFechaSerologia != "1845-01-01")
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " RESULTADO SEROLOGÍA PARA SÍFILIS NO CONCUERDA CON FECHA SEROLOGÍA EN CAMPO 80";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 82 - Fecha de Toma de Elisa para VIH 
    //--------------------------------------------------    
    #region SSP_CAM082_MS45
    public class Ssp_cam082_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "82. Fecha de Toma de Elisa para VIH";
            var lcrValor        = tobRegistro.Ssp_cam082_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 82;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSifilis      = tobRegistro.Ssp_cam025_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA DE TOMA DE ELISA PARA VIH ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA DE TOMA DE ELISA PARA VIH MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 83 - Resultado Elisa para VIH
    //--------------------------------------------------
    #region SSP_CAM083_MS45
    public class Ssp_cam083_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo      = "83. Resultado Elisa para VIH";
            var lcrValor            = tobRegistro.Ssp_cam083_ms45;
            var lcrMens             = String.Empty;
            var lcNumeroCampo       = 83;
            var lcrNivelError       = "1";
            var lcrCodigoError      = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError         = String.Empty;

            var lcrFecFormato       = tobParam.FechaFormato;
            var lcrFecSeparad       = tobParam.FechaSeparador;
            var ldaFechaElisaVIH    = tobRegistro.Ssp_cam082_ms45;
            var ldaFechNacim        = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias         = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " RESULTADO SEROLOGÍA PARA SÍFILIS - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor == "0")
                    {
                        if (ldaFechaElisaVIH != "1845-01-01")
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " RESULTADO ELISA PARA VIH NO CONCUERDA CON FECHA ELISA PARA VIH EN CAMPO 82";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 84 - Fecha TSH Neonatal
    //--------------------------------------------------    
    #region SSP_CAM084_MS45
    public class Ssp_cam084_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "84. Fecha TSH Neonatal";
            var lcrValor        = tobRegistro.Ssp_cam084_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 84;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA TSH NEONATAL ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA TSH NEONATAL MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (lcrValor == "1845-01-01")
                        {
                            if (lnuEdadDias < 3) 
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA TSH NEONATAL ERRADO DEBERIA APLICAR PARA RECIEN NACIDO (0 A 2 DIAS)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lnuEdadDias >= 3)
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA TSH NEONATAL NO APLICA PARA RECIEN NACIDO MAYORES DE 3 DIAS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 85 - Resultado de TSH Neonatal
    //--------------------------------------------------
    #region SSP_CAM085_MS45
    public class Ssp_cam085_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "85. Resultado de TSH Neonatal";
            var lcrValor        = tobRegistro.Ssp_cam085_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 85;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechaTSH     = tobRegistro.Ssp_cam084_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " RESULTADO DE TSH NEONATAL - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias < 3) 
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " RESULTADO DE TSH NEONATAL DEBERIA APLICAR PARA RECIEN NACIDO (0 A 2 DIAS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        if (ldaFechaTSH != "1845-01-01")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " RESULTADO DE TSH NEONATAL NO CONCUERDA CON TSH NEONATAL EN CAMPO 84";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 86 - Tamizaje Cáncer de Cuello Uterino
    //--------------------------------------------------
    #region SSP_CAM086_MS45
    public class Ssp_cam086_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "86. Tamizaje Cáncer de Cuello Uterino";
            var lcrValor        = tobRegistro.Ssp_cam086_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 86;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TAMIZAJE CANCER DE CUELLO UTERINO - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // menores de 10 Años Y hombres
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias > 3650 && lcrSexo == "F") // Excluye a mujeres fertiles
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " TAMIZAJE CANCER DE CUELLO UTERINO SE DEBERIA APLICAR POR EDAD Y SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias < 3650 || lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " TAMIZAJE CANCER DE CUELLO UTERINO NO APLICA POR EDAD O SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }   
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 87 - Citología Cervico uterina
    //--------------------------------------------------    
    #region SSP_CAM087_MS45
    public class Ssp_cam087_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "87. Citología Cervico uterina";
            var lcrValor        = tobRegistro.Ssp_cam087_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 87;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var lcrTamizajeCancerUterino = tobRegistro.Ssp_cam086_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CITOLOGÍA CERVICO UTERINA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CITOLOGÍA CERVICO UTERINA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {   // menores de 10 Años Y hombres
                        if (lcrValor == "1845-01-01")
                        {
                            if (lnuEdadDias > 3650 && lcrSexo == "F") //Excluye a mujeres fertiles
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " CITOLOGÍA CERVICO UTERINA SE DEBERIA APLICAR POR EDAD Y SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lcrTamizajeCancerUterino != "0")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA CITOLOGÍA CERVICO UTERINA NO CONCUERDA CON TAMIZAJE CANCER CUELLO UTERINO EN CAMPO 86";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrTamizajeCancerUterino == "0")
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " FECHA CITOLOGÍA CERVICO UTERINA NO COINCIDE CON TAMIZAJE CANCER CUELLO UTERINO EN CAMPO (86)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lnuEdadDias < 3650 || lcrSexo == "M") 
                            {
                                lcrCodError = lcrCodigoError + "E8";
                                lcrMens = " CITOLOGÍA CERVICO UTERINA NO APLICA POR EDAD O SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 88 - Citología Cervico uterina Resultados según Bethesda
    //--------------------------------------------------
    #region SSP_CAM088_MS45
    public class Ssp_cam088_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "88. Citología Cervico uterina Resultados según Bethesda";
            var lcrValor        = tobRegistro.Ssp_cam088_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 88;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrTamizajeCancerUterino = tobRegistro.Ssp_cam086_ms45;
            var ldaFechaCitoCerviUterina = tobRegistro.Ssp_cam087_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,999"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " CITOLOGIA CERVICO UTERINA - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // menores de 10 Años Y hombres
                    if (lcrValor == "0")
                    {
                        if (Funciones.flgExisteElemento(lcrTamizajeCancerUterino, ",", "1,2,3"))
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " CITOLOGIA CERVICO UTERINA NO COINCIDE CON TAMIZAJE CANCER CUELLO UTERINO EN CAMPO (86)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);

                            if (lnuEdadDias > 3650 && lcrSexo == "F") // Excluye a mujeres fertiles
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " CITOLOGIA CERVICO UTERINA SE DEBERIA APLICAR POR EDAD Y SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lnuEdadDias < 3650 || lcrSexo != "F") // Excluye a Hombre y mujeres menores de 10 años
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " CITOLOGIA CERVICO UTERINA NO APLICA POR EDAD Y SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                    else
                    {
                        if (lnuEdadDias < 3650 || lcrSexo == "M") 
                        {
                            lcrCodError = lcrCodigoError + "E6";
                            lcrMens = " CITOLOGIA CERVICO UTERINA NO APLICA POR EDAD O SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }else
                        {
                            if (ldaFechaCitoCerviUterina == "1845-01-01")
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " CITOLOGIA CERVICO UTERINA NO CONCUERDA CON FECHA CITOLOGÍA CERVICO UTERINA EN CAMPO 87";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }

                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 89 - Calidad en la Muestra de Citología Cervicouterina
    //--------------------------------------------------
    #region SSP_CAM089_MS45
    public class Ssp_cam089_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "89. Calidad en la Muestra de Citología Cervicouterina";
            var lcrValor        = tobRegistro.Ssp_cam089_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 89;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrTamizajeCancerUterino = tobRegistro.Ssp_cam086_ms45;
            var lcrCitologia    = tobRegistro.Ssp_cam088_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,4,999"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " CALIDAD DE LA MUESTRA DE CITOLOGIA CERVICO UTERINA - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // menores de 10 Años Y hombres
                    if (lcrValor == "0")
                    {
                        if (Funciones.flgExisteElemento(lcrTamizajeCancerUterino, ",", "1,2,3"))
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " CALIDAD DE LA MUESTRA DE CITOLOGIA CERVICO UTERINA NO COINCIDE CON TAMIZAJE CANCER CUELLO UTERINO EN CAMPO (86)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);

                            if (lnuEdadDias > 3650 && lcrSexo == "F") // Excluye a mujeres fertiles
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " CALIDAD DE LA MUESTRA DE CITOLOGIA CERVICO UTERINA SE DEBERIA APLICAR POR EDAD Y SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (lnuEdadDias < 3650 || lcrSexo != "F") // Excluye a Hombre y mujeres menores de 10 años
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " CALIDAD DE LA MUESTRA DE CITOLOGIA CERVICO UTERINA SE DEBERIA APLICAR POR EDAD Y SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                    else
                    {
                        if (lnuEdadDias < 3650 || lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E6";
                            lcrMens = " CALIDAD DE LA MUESTRA DE CITOLOGIA CERVICO UTERINA NO APLICA POR EDAD O SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (lcrCitologia == "0")
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " CALIDAD DE LA MUESTRA DE CITOLOGIA CERVICO UTERINA NO CONCUERDA CON CITOLOGÍA CERVICO UTERINA CAMPO 88";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }

                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 90 - Código de habilitación IPS donde se toma Citología Cervicouterina
    //--------------------------------------------------
    #region SSP_CAM090_MS45
    public class Ssp_cam090_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "90. Código de habilitación IPS donde se toma Citología Cervicouterina";
            var lcrValor        = tobRegistro.Ssp_cam090_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 90;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrTamizajeCancerUterino = tobRegistro.Ssp_cam086_ms45;
            var lcrCitologia    = tobRegistro.Ssp_cam088_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor == "0")
                {
                    if (Funciones.flgExisteElemento(lcrTamizajeCancerUterino, ",", "1,2,3"))
                    {
                        lcrCodError = lcrCodigoError + "E2";
                        lcrMens = " CODIGO HABILITACION IPS CITOLOGIA CERVICO UTERINA NO COINCIDE CON TAMIZAJE CANCER CUELLO UTERINO EN CAMPO (86)";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        if (lnuEdadDias > 3650 && lcrSexo == "F" && !Funciones.flgExisteElemento(lcrCitologia, ",", "17,999")) // Excluye a mujeres fertiles
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " CODIGO DE IPS DONDE SE TOMA CITOLOGIA SE DEBERIA APLICAR POR EDAD Y SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (lnuEdadDias < 3650 && lcrValor == "999")
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " CODIGO DE IPS DONDE SE TOMA CITOLOGIA NO APLICA POR EDAD";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        if (lcrCitologia != "0" && lcrCitologia != "999" && lcrValor == "0")
                        {
                            lcrCodError = lcrCodigoError + "E5";
                            lcrMens = " CODIGO DE IPS DONDE SE TOMA CITOLOGIA NO CONCUERDA CON CITOLOGÍA CERVICO UTERINA CAMPO 88";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
                else
                {
                    if (lcrSexo == "M")
                    {
                        lcrCodError = lcrCodigoError + "E6";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA CITOLOGIA NO APLICA PARA SEXO MASCULINO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (lcrCitologia == "0")
                        {
                            lcrCodError = lcrCodigoError + "E7";
                            lcrMens = " CODIGO DE IPS DONDE SE TOMA CITOLOGIA NO CONCUERDA CON CITOLOGÍA CERVICO UTERINA CAMPO 88";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    if (lcrValor != "999" && Funciones.fnuContarElemListaString(",", lcrValor) < 12)
                    {
                        lcrCodError = lcrCodigoError + "E8";
                        lcrMens = " CÓDIGO DE HABILITACIÓN IPS ERRADA";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (Funciones.fnuContarElemListaString(",", lcrValor) > 12)
                        {
                            lcrCodError = lcrCodigoError + "E9";
                            lcrMens = " CÓDIGO DE HABILITACIÓN IPS NO ES VALIDA MUCHOS DIGITOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(lcrValor,"0123456789"))
                            {
                                lcrCodError = lcrCodigoError + "E10";
                                lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 91 - Fecha Colposcopia
    //--------------------------------------------------    
    #region SSP_CAM091_MS45
    public class Ssp_cam091_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "91. Fecha Colposcopia";
            var lcrValor        = tobRegistro.Ssp_cam091_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 91;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrCitologia    = tobRegistro.Ssp_cam088_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA COLPOSCOPIA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA COLPOSCOPIA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {   // menores de 10 Años Y hombres
                        if (lcrValor == "1845-01-01")
                        {
                            if (lnuEdadDias > 3650 && lcrSexo == "F" && !Funciones.flgExisteElemento(lcrCitologia, ",", "17,999"))
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA COLPOSCOPIA SE DEBERIA APLICAR POR EDAD SEXO Y SEGUN REPORTE CITOLOGIA CAMPO 88";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            else
                            {
                                if (lcrCitologia != "0")
                                {
                                    lcrCodError = lcrCodigoError + "E6";
                                    lcrMens = " FECHA COLPOSCOPIA NO CONCUERDA CON RESULTADOS CITOLOGÍA CERVICO UTERINA EN CAMPO 88";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                            }
                        }
                        else
                        {
                            if (lnuEdadDias < 3650 || lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " FECHA COLPOSCOPIA NO APLICA POR EDAD O SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 92 - Código de habilitación IPS donde se toma Colposcopia
    //--------------------------------------------------
    #region SSP_CAM092_MS45
    public class Ssp_cam092_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "92. CODIGO DE IPS DONDE SE TOMA COLPOSCOPIA";
            var lcrValor        = tobRegistro.Ssp_cam092_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 92;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrCitologia    = tobRegistro.Ssp_cam088_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor == "0")
                {
                    if (lnuEdadDias > 3650 && lcrSexo == "F" && !Funciones.flgExisteElemento(lcrCitologia, ",", "17,999")) // Excluye a mujeres fertiles
                    {
                        lcrCodError = lcrCodigoError + "E2";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA COLPOSCOPIA SE DEBERIA APLICAR POR EDAD Y SEXO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (lnuEdadDias < 3650 && lcrValor == "999")
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " CODIGO DE IPS DONDE SE TOMA COLPOSCOPIA NO APLICA POR EDAD";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    if (lcrCitologia != "0" && lcrCitologia != "999" && lcrValor == "0")
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA COLPOSCOPIA NO CONCUERDA CON CITOLOGÍA CERVICO UTERINA CAMPO 88";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
                else
                {
                    if (lcrSexo == "M")
                    {
                        lcrCodError = lcrCodigoError + "E5";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA COLPOSCOPIA NO APLICA PARA SEXO MASCULINO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    if (lcrValor != "999" && Funciones.fnuContarElemListaString(",", lcrValor) < 12)
                    {
                        lcrCodError = lcrCodigoError + "E6";
                        lcrMens = " CÓDIGO DE HABILITACIÓN IPS ERRADA";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (Funciones.fnuContarElemListaString(",", lcrValor) > 12)
                        {
                            lcrCodError = lcrCodigoError + "E7";
                            lcrMens = " CÓDIGO DE HABILITACIÓN IPS NO ES VALIDA - MUCHOS DIGITOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789"))
                            {
                                lcrCodError = lcrCodigoError + "E8";
                                lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 93 - Fecha Biopsia Cervical
    //--------------------------------------------------    
    #region SSP_CAM093_MS45
    public class Ssp_cam093_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "93. Fecha Biopsia Cervical";
            var lcrValor        = tobRegistro.Ssp_cam093_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 93;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrCitologia    = tobRegistro.Ssp_cam088_ms45;
            var lcrTamizajeCancerUterino = tobRegistro.Ssp_cam086_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA BIOPSIA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA BIOPSIA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {   // menores de 10 Años Y hombres
                        if (lcrValor == "1845-01-01")
                        {
                            if (Funciones.flgExisteElemento(lcrTamizajeCancerUterino, ",", "1,2,3"))
                            {
                                if (lnuEdadDias > 3650 && lcrSexo == "F" && !Funciones.flgExisteElemento(lcrCitologia, ",", "17,999"))
                                {
                                    lcrCodError = lcrCodigoError + "E5";
                                    lcrMens = " FECHA BIOPSIA CERVICAL SE DEBERIA APLICAR POR EDAD SEXO Y SEGUN REPORTE CITOLOGIA CAMPO 88";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                                else
                                {
                                    if (lcrCitologia != "0")
                                    {
                                        lcrCodError = lcrCodigoError + "E6";
                                        lcrMens = " FECHA BIOPSIA CERVICAL NO CONCUERDA CON RESULTADOS CITOLOGÍA CERVICO UTERINA EN CAMPO 88";
                                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (lnuEdadDias < 3650 || lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " FECHA BIOPSIA CERVICAL NO APLICA POR EDAD O SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 94 - Resultado de Biopsia Cervical
    //--------------------------------------------------
    #region SSP_CAM094_MS45
    public class Ssp_cam094_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "94. Resultado de Biopsia Cervical";
            var lcrValor        = tobRegistro.Ssp_cam094_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 94;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrCitologia    = tobRegistro.Ssp_cam088_ms45;
            var lcrTamizajeCancerUterino = tobRegistro.Ssp_cam086_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,4,5,6,999"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " RESULTADO DE BIOPSIA CERVICAL - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // menores de 10 Años Y hombres
                    if (lcrValor == "0")
                    {
                        if (Funciones.flgExisteElemento(lcrTamizajeCancerUterino, ",", "1,2,3"))
                        {
                            if (lnuEdadDias > 3650 && lcrSexo == "F" && !Funciones.flgExisteElemento(lcrCitologia, ",", "17,999")) // Excluye a mujeres fertiles
                            {
                                lcrCodError = lcrCodigoError + "E3";
                                lcrMens = " RESULTADO DE BIOPSIA CERVICAL SE DEBERIA APLICAR POR EDAD Y SEXO Y SEGUN REPORTE CITOLOGIA CAMPO 88";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                    else
                    {
                        if (lnuEdadDias < 3650 || lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " RESULTADO DE BIOPSIA CERVICAL NO APLICA POR EDAD O SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (lcrCitologia == "0")
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " RESULTADO DE BIOPSIA CERVICAL NO CONCUERDA CON CITOLOGÍA CERVICO UTERINA CAMPO 88";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 95 - Código de habilitación IPS donde se toma Biopsia Cervical
    //--------------------------------------------------
    #region SSP_CAM095_MS45
    public class Ssp_cam095_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "95. Código de habilitación IPS donde se toma Biopsia Cervical";
            var lcrValor        = tobRegistro.Ssp_cam095_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 95;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrTamizajeCancerUterino = tobRegistro.Ssp_cam086_ms45;
            var lcrCitologia    = tobRegistro.Ssp_cam088_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor == "999") // Es no aplica o no se tiene el dato
                {
                    if (lcrCitologia == "0")
                    {
                        lcrCodError = lcrCodigoError + "E2";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA BIOPSIA CERVICAL NO CONCUERDA CON CITOLOGÍA CERVICO UTERINA CAMPO 88";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
                if (lcrValor == "0")
                {
                    if ((lnuEdadDias > 3650 && lcrSexo == "F" && !Funciones.flgExisteElemento(lcrCitologia, ",", "17,999")) && Funciones.flgExisteElemento(lcrTamizajeCancerUterino, ",", "1,2,3")) // Excluye a mujeres fertiles
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA BIOPSIA CERVICAL SE DEBERIA APLICAR POR EDAD Y SEXO; O POR DATO EN CAMPO (86)";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (lnuEdadDias < 3650 && lcrValor == "999")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " CODIGO DE IPS DONDE SE TOMA BIOPSIA CERVICAL NO APLICA POR EDAD";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    if (lcrCitologia != "0" && lcrCitologia != "999" && lcrValor == "0")
                    {
                        lcrCodError = lcrCodigoError + "E5";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA BIOPSIA CERVICAL NO CONCUERDA CON CITOLOGÍA CERVICO UTERINA CAMPO 88";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }                        
                }
                else
                {
                    if (lcrSexo == "M")
                    {
                        lcrCodError = lcrCodigoError + "E6";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA BIOPSIA CERVICAL NO APLICA PARA SEXO MASCULINO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    if (lcrValor != "999" && Funciones.fnuContarElemListaString(",", lcrValor) < 12)
                    {
                        lcrCodError = lcrCodigoError + "E7";
                        lcrMens = " CÓDIGO DE HABILITACIÓN IPS ERRADA";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (Funciones.fnuContarElemListaString(",", lcrValor) > 12)
                        {
                            lcrCodError = lcrCodigoError + "E8";
                            lcrMens = " CÓDIGO DE HABILITACIÓN IPS NO ES VALIDA MUCHOS DIGITOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789"))
                            {
                                lcrCodError = lcrCodigoError + "E9";
                                lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 96 - Fecha Mamografía
    //--------------------------------------------------    
    #region SSP_CAM096_MS45
    public class Ssp_cam096_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "96. Fecha Mamografía";
            var lcrValor        = tobRegistro.Ssp_cam096_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 96;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrCitologia    = tobRegistro.Ssp_cam088_ms45;
            var lcrTamizajeCancerUterino = tobRegistro.Ssp_cam086_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA MAMOGRAFÍA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA MAMOGRAFÍA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {   // hombres
                        if (lcrValor == "1845-01-01")
                        {
                            if (lcrSexo == "F" && lnuEdadDias > 12775) // mujer mayor de 35 años
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA MAMOGRAFÍA DEBERIA APLICAR POR EDAD Y SEXO (MUJER MAYOR DE 35 AÑOS)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }else
                        {
                            if (lnuEdadDias < 12775 || lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA MAMOGRAFÍA NO APLICA POR EDAD O SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 97 - Resultado Mamografía
    //--------------------------------------------------
    #region SSP_CAM097_MS45
    public class Ssp_cam097_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "97. Resultado Mamografía";
            var lcrValor        = tobRegistro.Ssp_cam097_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 97;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var ldaFechaMamografia = tobRegistro.Ssp_cam096_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,4,5,6,7,999"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " RESULTADO DE BIOPSIA CERVICAL - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // hombres
                    if (lcrValor == "0")
                    {   // mujer mayor de 35 años
                        if (lcrSexo == "F" && lnuEdadDias > 12775) 
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " RESULTADO MAMOGRAFIA DEBERIA APLICAR POR EDAD Y SEXO (MUJER MAYOR DE 35 AÑOS)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        if (ldaFechaMamografia != "1845-01-01")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " RESULTADO MAMOGRAFIA NO CONCUERDA CON FECHA MAMOGRAFIA EN CAMPO 96";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias < 12775 || lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E5";
                            lcrMens = " RESULTADO MAMOGRAFIA NO APLICA POR EDAD O SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 98 - Código de habilitación IPS donde se toma Mamografía
    //--------------------------------------------------
    #region SSP_CAM098_MS45
    public class Ssp_cam098_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "98. Código de habilitación IPS donde se toma Mamografía";
            var lcrValor        = tobRegistro.Ssp_cam098_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 98;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrMamografia   = tobRegistro.Ssp_cam097_ms45;
            var ldaFechaMamografia = tobRegistro.Ssp_cam096_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor == "0" || lcrValor == "999") // Es no aplica o no se tiene el dato
                {
                    if (lnuEdadDias > 12775 && lcrSexo == "F" && !Funciones.flgExisteElemento(lcrMamografia, ",", "2,999")) // edad menor a 35 años
                    {
                        lcrCodError = lcrCodigoError + "E2";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA MAMOGRAFIA SE DEBERIA APLICAR POR EDAD SEXO Y SEGUN REPORTE MAMOGRAFIA CAMPO 97";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    if (lcrMamografia != "0" && lcrValor == "0")
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA MAMOGRAFIA NO CONCUERDA CON RESULTADOS REPORTE MAMOGRAFIA CAMPO 97";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    if (ldaFechaMamografia != "1845-01-01" && lcrValor == "0")
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA MAMOGRAFIA NO CONCUERDA CON CAMPO 96 FECHA TOMA MAMOGRAFIA";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
                else
                {
                    if (lnuEdadDias < 12775 || lcrSexo == "M")
                    {
                        lcrCodError = lcrCodigoError + "E5";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA MAMOGRAFIA NO APLICA POR EDAD O SEXO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (lcrValor != "999" && Funciones.fnuContarElemListaString(",", lcrValor) < 12)
                        {
                            lcrCodError = lcrCodigoError + "E6";
                            lcrMens = " CÓDIGO DE HABILITACIÓN IPS ERRADA";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (Funciones.fnuContarElemListaString(",", lcrValor) > 12)
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " CÓDIGO DE HABILITACIÓN IPS NO ES VALIDA MUCHOS DIGITOS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789"))
                                {
                                    lcrCodError = lcrCodigoError + "E8";
                                    lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion 
    //--------------------------------------------------
    // 99 - Fecha Toma Biopsia Seno por BACAF
    //--------------------------------------------------    
    #region SSP_CAM099_MS45
    public class Ssp_cam099_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "99. Fecha Toma Biopsia Seno por BACAF";
            var lcrValor        = tobRegistro.Ssp_cam099_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 99;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrMamografia   = tobRegistro.Ssp_cam097_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA TOMA BIOPSIA SENO POR BACAF ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA TOMA BIOPSIA SENO POR BACAF MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {   // hombres
                        if (lcrValor == "1845-01-01")
                        {
                            if (lnuEdadDias > 12775 && lcrSexo == "F" && !Funciones.flgExisteElemento(lcrMamografia, ",", "2,999")) // edad menor a 35 años
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA TOMA BIOPSIA SENO POR BACAF SE DEBERIA APLICAR POR EDAD SEXO Y SEGUN REPORTE CITOLOGIA CAMPO 88";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            else
                            {
                                if (lcrMamografia !="0") 
                                {
                                    lcrCodError = lcrCodigoError + "E6";
                                    lcrMens = " FECHA TOMA BIOPSIA SENO POR BACAF NO CONCUERDA CON RESULTADOS CITOLOGÍA CERVICO UTERINA EN CAMPO 88";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                            }
                        }
                        else
                        {
                            if (lnuEdadDias < 12775 || lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " FECHA TOMA BIOPSIA SENO POR BACAF NO APLICA POR EDAD O SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 100 - Fecha Resultado Biopsia Seno por BACAF
    //--------------------------------------------------    
    #region SSP_CAM100_MS45
    public class Ssp_cam100_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "100. Fecha Resultado Biopsia Seno por BACAF";
            var lcrValor        = tobRegistro.Ssp_cam100_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 100;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrMamografia   = tobRegistro.Ssp_cam097_ms45;
            var ldaFechaBiopsia = tobRegistro.Ssp_cam099_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA RESULTADO BIOPSIA SENO POR BACAF ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA RESULTADO BIOPSIA SENO POR BACAF MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {   // hombres
                        if (lcrValor == "1845-01-01")
                        {
                            if (lnuEdadDias > 12775 && lcrSexo == "F") // Excluye a mujeres fertiles
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA RESULTADO BIOPSIA SENO POR BACAF SE DEBERIA APLICAR POR EDAD Y SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (Funciones.flgExisteElemento(lcrMamografia, ",", "1,3,4,5,6,7"))
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " FECHA RESULTADO BIOPSIA SENO POR BACAF NO CONCUERDA CON MAMOGRAFIA EN CAMPO 97";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                            if (ldaFechaBiopsia != "1845-01-01")
                            {
                                lcrCodError = lcrCodigoError + "E7";
                                lcrMens = " FECHA RESULTADO BIOPSIA SENO POR BACAF NO CONCUERDA CON BIOPSIA EN CAMPO 99";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lnuEdadDias < 12775 || lcrSexo == "M")
                            {
                                lcrCodError = lcrCodigoError + "E8";
                                lcrMens = " FECHA RESULTADO BIOPSIA SENO POR BACAF NO APLICA POR EDAD O SEXO";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 101 - Biopsia Seno por BACAF
    //--------------------------------------------------
    #region SSP_CAM101_MS45
    public class Ssp_cam101_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "101. Biopsia Seno por BACAF";
            var lcrValor        = tobRegistro.Ssp_cam101_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 101;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrMamografia   = tobRegistro.Ssp_cam097_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,3,4,5,999"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " RESULTADO BIOPSIA SENO POR BACAF - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // hombres
                    if (lcrValor == "0")
                    {
                        if (lnuEdadDias > 12775 && lcrSexo == "F") // mujer mayor de 35 años
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " RESULTADO BIOPSIA SENO POR BACAF SE DEBERIA APLICAR POR EDAD Y SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        if (Funciones.flgExisteElemento(lcrMamografia, ",", "1,3,4,5,6,7"))
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " RESULTADO BIOPSIA SENO POR BACAF NO CONCUERDA CON MAMOGRAFIA EN CAMPO 97";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lnuEdadDias < 12775 || lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E5";
                            lcrMens = " RESULTADO BIOPSIA SENO POR BACAF NO APLICA POR EDAD O SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (lcrMamografia == "0")
                            {
                                lcrCodError = lcrCodigoError + "E6";
                                lcrMens = " RESULTADO BIOPSIA SENO POR BACAF NO CONCUERDA CON CON MAMOGRAFIA EN CAMPO 97";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 102 - Código de habilitación IPS donde se toma Biopsia Seno por BACAF
    //--------------------------------------------------
    #region SSP_CAM102_MS45
    public class Ssp_cam102_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "102. Código de habilitación IPS donde se toma Biopsia Seno por BACAF";
            var lcrValor        = tobRegistro.Ssp_cam102_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 102;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrMamografia   = tobRegistro.Ssp_cam097_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor == "0" || lcrValor == "999") // Es no aplica o no se tiene el dato
                {
                    if (lnuEdadDias >= 12775 && lcrSexo == "F" && !Funciones.flgExisteElemento(lcrMamografia, ",", "2,999")) // Excluye a mujeres de 35 años
                    {
                        lcrCodError = lcrCodigoError + "E2";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA BIOPSIA SENO POR BACAF SE DEBERIA APLICAR POR EDAD Y SEXO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (lnuEdadDias < 12775 && lcrValor == "999")
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " CODIGO DE IPS DONDE SE TOMA BIOPSIA SENO POR BACAF NO APLICA POR EDAD O SEXO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    if (lcrMamografia != "0" && lcrMamografia != "999" && lcrValor == "0")
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA BIOPSIA SENO POR BACAF NO CONCUERDA CON MAMOGRAFIA EN CAMPO 97";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
                else
                {
                    if (lcrSexo == "M")
                    {
                        lcrCodError = lcrCodigoError + "E5";
                        lcrMens = " CODIGO DE IPS DONDE SE TOMA BIOPSIA SENO POR BACAF NO APLICA PARA SEXO MASCULINO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    if (lcrValor != "999" && Funciones.fnuContarElemListaString(",", lcrValor) < 12)
                    {
                        lcrCodError = lcrCodigoError + "E6";
                        lcrMens = " CÓDIGO DE HABILITACIÓN IPS ERRADA";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (Funciones.fnuContarElemListaString(",", lcrValor) > 12)
                        {
                            lcrCodError = lcrCodigoError + "E7";
                            lcrMens = " CÓDIGO DE HABILITACIÓN IPS NO ES VALIDA - MUCHOS DIGITOS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(lcrValor, "0123456789"))
                            {
                                lcrCodError = lcrCodigoError + "E8";
                                lcrMens = " DATO CONTIENE CARACTERES NO PERMITIDOS";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 103 - Fecha Toma de Hemoglobina
    //--------------------------------------------------
    #region SSP_CAM103_MS45
    public class Ssp_cam103_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "103. Fecha Toma de Hemoglobina";
            var lcrValor        = tobRegistro.Ssp_cam103_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 103;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA TOMA DE HEMOGLOBINA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA TOMA DE HEMOGLOBINA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion
    //--------------------------------------------------
    // 104 - Resultado Hemoglobina
    //--------------------------------------------------    
    #region SSP_CAM104_MS45
    public class Ssp_cam104_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "104. Resultado Hemoglobina";
            var lcrValor        = tobRegistro.Ssp_cam104_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 104;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var ldaFechaHemoglobina = tobRegistro.Ssp_cam103_ms45;            

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (Convert.ToInt32(lcrValor) < 0)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " HEMOGLOBINA DEBE SER MAYOR QUE CERO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Convert.ToInt32(lcrValor) > 9998)
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " DATO DE HEMOGLOBINA ERRADO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else 
                    {
                        if (Convert.ToInt32(lcrValor) == 0)
                        {
                            if (ldaFechaHemoglobina != "1845-01-01")
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " RESULTADO HEMOGLOBINA NO CONCUERDA CON FECHA TOMA DE HEMOGLOBINA EN CAMPO 103";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(lcrValor) < 1.5 || Convert.ToInt32(lcrValor) > 20)
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " DATO HEMOGLOBINA ERRADO - NO ESTA EN EL RANGO PERMITIDO (1.5 - 20)";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 105 - Fecha de la Toma de Glicemia Basal
    //--------------------------------------------------    
    #region SSP_CAM105_MS45
    public class Ssp_cam105_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "105. Fecha de la Toma de Glicemia Basal";
            var lcrValor        = tobRegistro.Ssp_cam105_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 105;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA TOMA DE GLICEMIA BASAL ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA TOMA DE GLICEMIA BASAL MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 106 - Fecha Creatinina
    //--------------------------------------------------    
    #region SSP_CAM106_MS45
    public class Ssp_cam106_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "106. Fecha Creatinina";
            var lcrValor        = tobRegistro.Ssp_cam106_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 106;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA CREATININA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA CREATININA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 107 - Resultado valor Creatinina
    //--------------------------------------------------    
    #region SSP_CAM107_MS45
    public class Ssp_cam107_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "107. Resultado valor Creatinina";
            var lcrValor        = tobRegistro.Ssp_cam107_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 107;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var ldaFechaCreatina = tobRegistro.Ssp_cam106_ms45;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (Convert.ToInt32(lcrValor) < 0)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " CREATININA DEBE SER MAYOR QUE CERO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Convert.ToInt32(lcrValor) > 999)
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = "DATO DE CREATININA ERRADO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {
                        if (Convert.ToInt32(lcrValor) == 0)
                        {
                            if (ldaFechaCreatina != "1845-01-01")
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " DATO CREATININA NO CONCUERDA CON FECHA CREATINA EN CAMPO 106";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrValor != "999")
                            {
                                if (Convert.ToInt32(lcrValor) < 0.2 && Convert.ToInt32(lcrValor) > 25)
                                {
                                    lcrCodError = lcrCodigoError + "E5";
                                    lcrMens = " DATO CREATININA ERRADO - NO ESTA EN EL RANGO PERMITIDO (0.2 - 25)";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 108 - Fecha Hemoglobina Glicosilada
    //--------------------------------------------------    
    #region SSP_CAM108_MS45
    public class Ssp_cam108_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "108. Fecha Hemoglobina Glicosilada";
            var lcrValor        = tobRegistro.Ssp_cam108_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 108;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA HEMOGLOBINA GLICOSILADA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA HEMOGLOBINA GLICOSILADA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 109 - Hemoglobina Glicosilada
    //--------------------------------------------------    
    #region SSP_CAM109_MS45
    public class Ssp_cam109_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "109. Hemoglobina Glicosilada";
            var lcrValor        = tobRegistro.Ssp_cam109_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 109;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var ldaFechaGlicosilada = tobRegistro.Ssp_cam108_ms45;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (Convert.ToInt32(lcrValor) < 0)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " HEMOGLOBINA GLICOSILADA DEBE SER MAYOR QUE CERO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Convert.ToInt32(lcrValor) > 999)
                    {
                        lcrCodError = lcrCodigoError + "E3";
                        lcrMens = " DATO DE HEMOGLOBINA GLICOSILADA ERRADO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                    else
                    {   // si no aplica
                        if (Convert.ToInt32(lcrValor) == 0)
                        {
                            if (ldaFechaGlicosilada != "1845-01-01")
                            {
                                lcrCodError = lcrCodigoError + "E4";
                                lcrMens = " DATO HEMOGLOBINA GLICOSILADA NO CONCUERDA  CON FECHA HEMOGLOBINA GLICOSILADA EN CAMPO 108";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                        else
                        {
                            if (lcrValor != "999")
                            {
                                if (Convert.ToInt32(lcrValor) < 5 || Convert.ToInt32(lcrValor) > 20)
                                {
                                    lcrCodError = lcrCodigoError + "E5";
                                    lcrMens = " DATO HEMOGLOBINA GLICOSILADA ERRADO - NO ESTA EN EL RANGO PERMITIDO (5 - 20)";
                                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion     
    //--------------------------------------------------
    // 110 - Fecha Toma de Microalbuminuria
    //--------------------------------------------------    
    #region SSP_CAM110_MS45
    public class Ssp_cam110_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "110. Fecha Toma de Microalbuminuria";
            var lcrValor        = tobRegistro.Ssp_cam110_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 110;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA TOMA DE MICROALBUMINURIA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA TOMA DE MICROALBUMINURIA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 111 - Fecha Toma de HDL
    //--------------------------------------------------    
    #region SSP_CAM111_MS45
    public class Ssp_cam111_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "111. Fecha Toma de HDL";
            var lcrValor        = tobRegistro.Ssp_cam111_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 111;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA TOMA DE HDL ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA TOMA DE HDL MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 112 - Fecha Toma de Baciloscopia de Diagnóstico
    //--------------------------------------------------    
    #region SSP_CAM112_MS45
    public class Ssp_cam112_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "112. Fecha Toma de Baciloscopia de Diagnóstico";
            var lcrValor        = tobRegistro.Ssp_cam112_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 112;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA TOMA DE BASILOSCOPIA ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA TOMA DE BASILOSCOPIA MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 113 - Baciloscopia de Diagnóstico
    //--------------------------------------------------
    #region SSP_CAM113_MS45
    public class Ssp_cam113_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "113. Baciloscopia de Diagnóstico";
            var lcrValor        = tobRegistro.Ssp_cam113_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 113;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "1,2,3,4,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " BACILOSCOPIA DE DIAGNOSTICO - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 114 - Tratamiento para Hipotiroidismo Congénito
    //--------------------------------------------------
    #region SSP_CAM114_MS45
    public class Ssp_cam114_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "114. Tratamiento para Hipotiroidismo Congénito";
            var lcrValor        = tobRegistro.Ssp_cam114_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 114;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TRATAMIENTO PARA HIPOTIROIDISMO CONGÉNITO - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 115 - Tratamiento para Sífilis gestacional
    //--------------------------------------------------
    #region SSP_CAM115_MS45
    public class Ssp_cam115_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "115. Tratamiento para Sífilis gestacional";
            var lcrValor        = tobRegistro.Ssp_cam115_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 115;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrGestacion    = tobRegistro.Ssp_cam014_ms45;
            var lcrSifilis      = tobRegistro.Ssp_cam015_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TRATAMIENTO PARA SIFILIS GESTACIONAL - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // aplica
                    if (lcrValor == "0")
                    {
                        if (lcrSexo == "F" && lnuEdadDias >= 3650 && lcrGestacion == "1" && lcrSifilis == "1") // lnuEdadDias = 3650 es 10 años
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " TRATAMIENTO PARA SIFILIS GESTACIONAL SE DEBERIA APLICAR POR EDAD SEXO GESTACIÓN Y SIFILIS";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lcrSexo == "M")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " TRATAMIENTO PARA SIFILIS GESTACIONAL NO APLICA PARA SEXO MASCULINO";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (lcrGestacion != "1" || lnuEdadDias < 3650 || lcrGestacion != "1")
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " FECHA ANTIGENO DE SUPERFICIE HEPATITIS B EN GESTANTES NO APLICA PARA ESTADOS NO GESTANTE";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 116 - Tratamiento para Sífilis Congénita
    //--------------------------------------------------
    #region SSP_CAM116_MS45
    public class Ssp_cam116_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "116. Tratamiento para Sífilis Congénita";
            var lcrValor        = tobRegistro.Ssp_cam116_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 116;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrSifilis      = tobRegistro.Ssp_cam015_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TRATAMIENTO PARA SIFILIS CONGÉNITA - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // aplica
                    if (lcrValor == "0")
                    {
                        if (lcrSifilis == "2") 
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " TRATAMIENTO PARA SIFILIS CONGÉNITA NO CONCUERDA CON DIAGNOSTICO CAMPO 15 (SIFILIS CONGENITA)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lcrSifilis != "2") 
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " TRATAMIENTO PARA SIFILIS CONGÉNITA NO CONCUERDA CON DIAGNOSTICO CAMPO 15 (SIFILIS CONGENITA)";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                        else
                        {
                            if (lnuEdadDias > 480) // 16 meses
                            {
                                lcrCodError = lcrCodigoError + "E5";
                                lcrMens = " DATO SÍFILIS GESTACIONAL O CONGENITA NO APLICA PARA MAYORES DE 16 MESES";
                                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 117 - Tratamiento para Lepra
    //--------------------------------------------------
    #region SSP_CAM117_MS45
    public class Ssp_cam117_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "117. Tratamiento para Lepra";
            var lcrValor        = tobRegistro.Ssp_cam117_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 117;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;
            var lcrLepra        = tobRegistro.Ssp_cam020_ms45;
            var lcrSexo         = tobRegistro.Ssp_cam010_ms45;
            var ldaFechNacim    = Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, tobRegistro.Ssp_cam009_ms45);
            var lnuEdadDias     = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechNacim, tobParam.FechaFinPeriodo);

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                lcrNivelError = "5";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (!Funciones.flgExisteElemento(lcrValor, ",", "0,1,2,16,17,18,19,20,22"))
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " TRATAMIENTO PARA LEPRA - DATO ERRADO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {   // aplica
                    if (lcrValor == "0")
                    {
                        if (Funciones.flgExisteElemento(lcrLepra, ",", "1,2,21"))
                        {
                            lcrCodError = lcrCodigoError + "E3";
                            lcrMens = " TRATAMIENTO PARA LEPRA NO CONCUERDA CON LEPRA EN CAMPO 20";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                    else
                    {
                        if (lcrLepra == "3")
                        {
                            lcrCodError = lcrCodigoError + "E4";
                            lcrMens = " TRATAMIENTO PARA LEPRA NO CONCUERDA CON LEPRA EN CAMPO 20";
                            tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                        }
                    }
                }
            }
        }
    }
    #endregion  
    //--------------------------------------------------
    // 118 - Fecha de Terminación Tratamiento para Leishmaniasis
    //--------------------------------------------------    
    #region SSP_CAM118_MS45
    public class Ssp_cam118_ms45 : IValidador4505
    {
        public void EjecutarValidCampo(IRegistroError tobIObjeto, ModeloSspNsRes4505Ex tobRegistro, int tnuNumeroRegistro, ParamValid4505 tobParam)
        {
            var lcrTituloCampo  = "118. Fecha de Terminación Tratamiento para Leishmaniasis";
            var lcrValor        = tobRegistro.Ssp_cam118_ms45;
            var lcrMens         = String.Empty;
            var lcNumeroCampo   = 118;
            var lcrNivelError   = "1";
            var lcrCodigoError  = "C" + lcNumeroCampo.ToString().Trim();
            var lcrCodError     = String.Empty;

            var lcrFecFormato   = tobParam.FechaFormato;
            var lcrFecSeparad   = tobParam.FechaSeparador;

            if (String.IsNullOrWhiteSpace(lcrValor))
            {
                lcrCodError = lcrCodigoError + "E1";
                lcrMens = " FALTA DATO EN CAMPO OBLIGATORIO";
                tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
            }
            else
            {
                if (lcrValor.Trim().Length != 10)
                {
                    lcrCodError = lcrCodigoError + "E2";
                    lcrMens = " FORMATO DE FECHA INVALIDO";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else if (!Funciones.flgValidaFecha(lcrFecFormato, lcrFecSeparad, lcrValor))
                {
                    lcrCodError = lcrCodigoError + "E3";
                    lcrMens = " FECHA DE TERMINACION TRATAMIENTO PARA LEISHMANIASIS ERRADA";
                    tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                }
                else
                {
                    if (Funciones.fdaConvertFecha(lcrFecFormato, lcrFecSeparad, lcrValor) > tobParam.FechaFinPeriodo)
                    {
                        lcrCodError = lcrCodigoError + "E4";
                        lcrMens = " FECHA DE TERMINACION TRATAMIENTO PARA LEISHMANIASIS MAYOR QUE FECHA FIN DE PERIODO";
                        tobIObjeto.AddRegistroError(lcrCodError, lcrMens, tnuNumeroRegistro, lcNumeroCampo, lcrTituloCampo, lcrValor, lcrNivelError);
                    }
                }
            }
        }
    }
    #endregion  
}
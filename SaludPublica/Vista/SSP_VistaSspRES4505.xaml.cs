//- MARMOTA-GENCODE: VERSION 2.0 - 01/09/2014 06:21:22 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Media.Converters;
using System.Windows.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
using Microsoft.Win32;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Utilidades;
using Sistema.Clases;
using Sistema.Validacion;
using SaludPublica.Modelo;
using SaludPublica.VistaModelo;
using SaludPublica.Utilidades;
using System.Text.RegularExpressions;

namespace SaludPublica.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sptablmsres4505
    /// </summary>
    public partial class VistaSspRes4505 : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public bool glgVistaEtiquetaEstadoVisible = false;
        public String gcrCtrF2TexBox;
        public static VistaModeloSspRes4505 gobObjVModelo = null;
        public static ParamValid4505 gobParamValid = new ParamValid4505();
        private DispatcherTimer timer;
        String gcrPeriodo;
        DialogVistaErrores lobDlgLogs = null;
        CollectionViewSource _DataGridSErroresFiltro = null;
        ICollectionView DataGridVErroresFiltro = null;
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
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaSspRes4505(ModeloSspNsRes4505Ex tobRegistro, ParamValid4505 tobParamValid)
        {
            InitializeComponent();

            gobObjVModelo = this.DataContext as VistaModeloSspRes4505;
            gobObjVModelo.Restaurar();
            gobObjVModelo.glgSIS_ModoTempEdicion = false;
            llgObjetosCargados = true;

            fcvActivarModoEdicionVista(tobRegistro, tobParamValid);

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            Aplicacion oAppEntorno = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oAppEntorno.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oAppEntorno.gcrUsuCodigoPerfil;

            cmdGuardar.Visibility = Visibility.Hidden;
            cmdCancelar.Visibility = Visibility.Hidden;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Ssp_cam009_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam029_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam031_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam033_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam049_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam050_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam051_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam052_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam053_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam055_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam056_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam058_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam062_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam063_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam064_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam065_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam066_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam067_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam068_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam069_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam072_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam073_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam075_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam076_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam078_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam080_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam082_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam084_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam087_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam091_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam093_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam096_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam099_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam100_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam103_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam105_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam106_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam108_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam110_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam111_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam112_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            dpkG1Ssp_cam118_ms45.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Start();        
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

            this.cvaEtiqueta.Width = lduBarraWidth - (lduBarraWidth * 0.037);
            this.grdEtiqueta.Width = lduBarraWidth - (lduBarraWidth * 0.037);

        }
        #endregion
        #region temporizador para ventana de periodos
        /// <summary>
        /// temporizador para ventana de periodos
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.IsLoaded)
            {
                if (gobObjVModelo.glgSIS_ModoTempEdicion == false)
                {
                    if (string.IsNullOrWhiteSpace(flgObtenerPeriodos()))
                    {
                        this.Close();
                    }
                }
                else 
                {
                    // Activar la vista
                    gobObjVModelo.Modificar();
                    fcvActivarModoEdicion("EDT");
                    gobObjVModelo.fcvValidarRegistroVista();

                }
                timer.Stop();
            }

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }
        private String flgObtenerPeriodos()
        {

            Browser01 frbro = new Browser01("SSP", "SPTABLAPERIODOS", "", "Tabla periodos 4505...");
            gcrCtrF2TexBox = "PERIODOS";
            frbro.Owner = this;
            frbro.ShowDialog();
            return gcrPeriodo;
        }
        #endregion
        #region fcvActivarModoEdicionVista: Activa el modo edicion para registros o temporal
        /// <summary>
        /// Activa el modo edicion para registros de base de datos o vista temporal
        /// </summary>
        private void fcvActivarModoEdicionVista(ModeloSspNsRes4505Ex tobRegistro, ParamValid4505 tobParamValid)
        {
            // Verificar si hubo parametro
            gobObjVModelo.TmpRegActivo4505Ex = new ModeloSspNsRes4505Ex();
            if (tobRegistro != null)
            {
                gobObjVModelo.glgSIS_ModoTempEdicion = true;
                gobObjVModelo.TmpRegActivo4505Ex = tobRegistro;
                gobObjVModelo.fcvCargarVariablesDesdeRegActivoEx(tobParamValid.FechaFormato, tobParamValid.FechaSeparador);

                gobObjVModelo.G1Ssp_codper_peri = tobParamValid.CodigoPeriodo;
                gobObjVModelo.G1Ssp_fecini_peri = tobParamValid.FechaIniPeriodo.ToShortDateString();
                gobObjVModelo.G1Ssp_fecfin_peri = tobParamValid.FechaFinPeriodo.ToShortDateString();
                gobObjVModelo.G1Sia_codeps_teps = tobParamValid.CodigoEps;

                gobObjVModelo.gdaIniPeriodo = tobParamValid.FechaIniPeriodo;
                gobObjVModelo.gdaFinPeriodo = tobParamValid.FechaFinPeriodo;
                gobParamValid = tobParamValid;

                var tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(tobParamValid.CodigoEps);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codeps_teps))
                {
                    gobObjVModelo.G1Sia_deseps_teps = tmp.sia_deseps_teps;
                }

                this.cmdBrowser.Visibility = Visibility.Collapsed;
                this.pagTABS6.Visibility = Visibility.Collapsed;
                this.cmdAdicionar.Visibility = Visibility.Collapsed;
                this.cmdModificar.Visibility = Visibility.Collapsed;
                this.cmdEliminar.Visibility = Visibility.Collapsed;

            }
            else
            {
                WindowState = WindowState.Maximized;
                SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
                fcvResizePantalla();
            }
        }
        #endregion
        #region fcvValidarRegistroVista: Realiza una validacion general al registro en la vista
        /// <summary>
        /// Realiza una validacion general al registro en la vista
        /// </summary>
        private void fcvValidarRegistroVista()
        {
            gobObjVModelo.fcrValidacion("G1Ssp_cam001_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam002_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam003_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam004_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam005_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam006_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam007_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam008_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam009_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam010_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam011_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_codocu_ciuo");
            gobObjVModelo.fcrValidacion("G1Ssp_cam013_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam014_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam015_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam016_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam017_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam018_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam019_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam020_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam021_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam022_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam023_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam024_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam025_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam026_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam027_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam028_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam029_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam030_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam031_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam032_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam033_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam034_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam035_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam036_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam037_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam038_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam039_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam040_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam041_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam042_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam043_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam044_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam045_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam046_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam047_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam048_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam049_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam050_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam051_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam052_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam053_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam054_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam055_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam056_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam057_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam058_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam059_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam060_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam061_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam062_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam063_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam064_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam065_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam066_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam067_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam068_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam069_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam070_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam071_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam072_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam073_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam074_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam075_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam076_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam077_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam078_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam079_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam080_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam081_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam082_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam083_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam084_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam085_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam086_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam087_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam088_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam089_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam090_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam091_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam092_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam093_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam094_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam095_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam096_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam097_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam098_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam099_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam100_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam101_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam102_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam103_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam104_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam105_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam106_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam107_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam108_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam109_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam110_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam111_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam112_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam113_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam114_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam115_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam116_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam117_ms45");
            gobObjVModelo.fcrValidacion("G1Ssp_cam118_ms45");
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region Gestion Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
        }

        //- clic en Boton Nuevo registro Grilla
        private void fcvNuevoRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("ADDREL");
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
            if (gobObjVModelo.glgSIS_ModoTempEdicion == true)
            {
                gobObjVModelo.fcvCargarRegActivoDesdeVariablesEx();
                fcvRetornoInterface();
            }
            else 
            {
                fcvActivarModoEdicion("SAV");
            }
        }

        //-Clic en Boton Guardar registro Grilla
        private void fcvGuardarRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("SAVREL");
            FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
        }

        //-Clic en Boton Cancelar
        private void fcvCancelarRegistro(object sender, RoutedEventArgs e)
        {
            if (gobObjVModelo.glgSIS_ModoTempEdicion == true)
            {
                this.Close();
            }
            else
            {
                fcvActivarModoEdicion("CAN");
            }
        }

        //-Clic en Boton Eliminar registro Grilla
        private void fcvEliminarRegistroRel(object sender, RoutedEventArgs e)
        {
            //fcvActivarModoEdicion("DELREL");
            FocusManager.SetFocusedElement(this, txtG1Sia_nroide_usua);
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
            lobDlgLogs.fcvCargarVista("Vista errores", gobObjVModelo.tmpLogErrores);
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
                cmdAdicionar.Visibility = Visibility.Visible;
                cmdModificar.Visibility = Visibility.Visible;
                cmdGuardar.Visibility = Visibility.Hidden;
                cmdCancelar.Visibility = Visibility.Hidden;
            }
        }
        #endregion
        //-------------------------------------------------
        // Eventos Auxiliares Salir y Cerrar Vista
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
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Decimal)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void fcvMoverFocus2_KeyDown(object sender, KeyEventArgs e)
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
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Ssp_cam001_ms45":
                    txtG1Ssp_cam001_ms45.Text = tcrCodigo;
                    break;

                case "txtG1Sia_idesec_usua":
                    txtG1Sia_idesec_usua.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codeps_teps":
                    txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                case "txtG1Ssp_codocu_ciuo":
                    txtG1Ssp_codocu_ciuo.Text = tcrCodigo;
                    break;

                case "txtG1Sia_nroide_usua":
                    txtG1Sia_nroide_usua.Text = tcrCodigo;
                    break;

                case "PERIODOS":
                    gcrPeriodo = tcrCodigo;
                    EFsptablaperiodos tmpPeriodo = new EFsptablaperiodos();
                    tmpPeriodo = SSPValidarCodigo.fobRegBuscarSptablaperiodos(gcrPeriodo);
                    gobObjVModelo.gdaIniPeriodo = (DateTime)tmpPeriodo.ssp_fecini_peri;
                    gobObjVModelo.gdaFinPeriodo = (DateTime)tmpPeriodo.ssp_fecfin_peri;
                    this.txtG1Ssp_codper_peri.Text = tmpPeriodo.ssp_codper_peri;
                    this.txtG1Ssp_fecini_peri.Text = ((DateTime)tmpPeriodo.ssp_fecini_peri).ToShortDateString();
                    this.txtG1Ssp_fecfin_peri.Text = ((DateTime)tmpPeriodo.ssp_fecfin_peri).ToShortDateString();
                    break;
            }
        }
        #endregion
        #region fcvRetornoInterface: interface para devolver el registro modificado
        /// <summary>
        /// Retoma la interfase con la ventana principal
        /// entrega el registro modificado y cierra la ventana de digitacion
        /// </summary>
        private void fcvRetornoInterface()
        {
            IEdicionRegistro lobRefEnlace = this.Owner as IEdicionRegistro;
            if (lobRefEnlace != null)
            {
                lobRefEnlace.fcvIEdicionRegistro(gobObjVModelo.TmpRegActivo4505Ex);
            }
            this.Close();
        }
        #endregion
        //-------------------------------------------------
        //  metodos Key para F2
        //-------------------------------------------------
        #region metodos Key para F2
        // SPTABLMSRES4505 : Tabla maestra de digitacion RES4505
        #region KeyDown para campos con F2 Tabla: SPTABLMSRES4505
        #region SIA_IDESEC_USUA : Maestro de Pacientes atendidos
        private void txtG1Sia_idesec_usua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_idesec_usua_Browser();
            }
        }
        private void cmdG1Sia_idesec_usua_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_idesec_usua_Browser();
        }
        private void txtG1Sia_idesec_usua_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATEND", "", "Maestro de Pacientes atendidos...");
            gcrCtrF2TexBox = "txtG1Sia_idesec_usua";
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
                txtG1Sia_nroide_usua_Browser();
            }
        }
        private void cmdG1Sia_nroide_usua_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_nroide_usua_Browser();
        }
        private void txtG1Sia_nroide_usua_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATENDIU", "", "Maestro de Pacientes atendidos...");
            gcrCtrF2TexBox = "txtG1Sia_nroide_usua";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        // SPTABLNSRES4505 : Novedades mensuales RES4505
        #region fcvBrowserBuscar: KeyDown para Tabla maestra de digitacion 
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SSP", "SPTABLMSRES4505", "", "Tabla maestra de digitacion RES4505...");
            gcrCtrF2TexBox = "txtG1Ssp_cam001_ms45";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                    string lcrValor = string.Empty;
                    switch (lobCombo.Name)
                    {
                        case "cboG1Ssp_cam010_ms45":
                            txtG1Ssp_cam010_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam010_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam010_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam011_ms45":
                            txtG1Ssp_cam011_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam011_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam011_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam013_ms45":
                            txtG1Ssp_cam013_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam013_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam013_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam014_ms45":
                            txtG1Ssp_cam014_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam014_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam014_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam015_ms45":
                            txtG1Ssp_cam015_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam015_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam015_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam016_ms45":
                            txtG1Ssp_cam016_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam016_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam016_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam017_ms45":
                            txtG1Ssp_cam017_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam017_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam017_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam018_ms45":
                            txtG1Ssp_cam018_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam018_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam018_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam019_ms45":
                            txtG1Ssp_cam019_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam019_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam019_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam020_ms45":
                            txtG1Ssp_cam020_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam020_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam020_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam021_ms45":
                            txtG1Ssp_cam021_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam021_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam021_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam022_ms45":
                            txtG1Ssp_cam022_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam022_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam022_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam023_ms45":
                            txtG1Ssp_cam023_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam023_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam023_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam024_ms45":
                            txtG1Ssp_cam024_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam024_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam024_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam025_ms45":
                            txtG1Ssp_cam025_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam025_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam025_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam026_ms45":
                            txtG1Ssp_cam026_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam026_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam026_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam027_ms45":
                            txtG1Ssp_cam027_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam027_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam027_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam028_ms45":
                            txtG1Ssp_cam028_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam028_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam028_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam029_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam029_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam029_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam029_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam030_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam030_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam030_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam030_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam031_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam031_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            //MessageBox.Show("valor  " + lcrValor);
                            txtG1Ssp_cam031_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam031_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam032_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam032_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam032_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam032_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam033_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam033_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam033_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam033_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam034_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam034_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam034_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam034_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam035_ms45":
                            txtG1Ssp_cam035_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam035_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam035_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam036_ms45":
                            txtG1Ssp_cam036_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam036_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam036_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam037_ms45":
                            txtG1Ssp_cam037_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam037_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam037_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam038_ms45":
                            txtG1Ssp_cam038_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam038_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam038_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam039_ms45":
                            txtG1Ssp_cam039_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam039_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam039_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam040_ms45":
                            txtG1Ssp_cam040_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam040_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam040_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam041_ms45":
                            txtG1Ssp_cam041_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam041_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam041_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam042_ms45":
                            txtG1Ssp_cam042_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam042_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam042_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam043_ms45":
                            txtG1Ssp_cam043_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam043_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam043_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam044_ms45":
                            txtG1Ssp_cam044_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam044_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam044_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam045_ms45":
                            txtG1Ssp_cam045_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam045_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam045_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam046_ms45":
                            txtG1Ssp_cam046_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam046_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam046_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam047_ms45":
                            txtG1Ssp_cam047_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam047_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam047_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam048_ms45":
                            txtG1Ssp_cam048_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam048_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam048_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam049_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam049_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam049_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam049_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam050_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam050_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam050_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam050_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam051_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam051_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam051_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam051_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam052_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam052_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam052_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam052_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam053_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam053_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam053_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam053_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam054_ms45":
                            txtG1Ssp_cam054_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam054_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam054_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam055_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam055_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam055_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam055_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam056_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam056_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam056_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam056_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam057_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam057_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam057_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam057_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam058_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam058_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam058_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam058_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam059_ms45":
                            txtG1Ssp_cam059_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam059_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam059_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam060_ms45":
                            txtG1Ssp_cam060_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam060_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam060_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam061_ms45":
                            txtG1Ssp_cam061_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam061_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam061_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam062_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam062_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam062_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam062_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam063_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam063_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam063_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam063_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam064_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam064_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam064_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam064_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam065_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam065_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam065_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam065_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam066_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam066_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam066_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam066_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam067_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam067_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam067_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam067_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam068_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam068_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam068_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam068_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam069_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam069_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam069_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam069_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam070_ms45":
                            txtG1Ssp_cam070_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam070_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam070_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam071_ms45":
                            txtG1Ssp_cam071_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam071_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam071_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam072_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam072_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam072_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam072_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam073_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam073_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam073_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam073_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam074_ms45":
                            txtG1Ssp_cam074_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam074_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam074_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam075_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam075_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam075_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam075_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam076_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam076_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam076_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam076_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam077_ms45":
                            txtG1Ssp_cam077_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam077_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam077_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam078_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam078_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam078_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam078_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam079_ms45":
                            txtG1Ssp_cam079_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam079_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam079_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam080_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam080_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam080_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam080_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam081_ms45":
                            txtG1Ssp_cam081_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam081_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam081_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam082_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam082_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam082_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam082_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam083_ms45":
                            txtG1Ssp_cam083_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam083_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam083_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam084_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam084_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam084_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam084_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam085_ms45":
                            txtG1Ssp_cam085_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam085_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam085_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam086_ms45":
                            txtG1Ssp_cam086_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam086_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam086_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam087_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam087_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam087_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam087_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam088_ms45":
                            txtG1Ssp_cam088_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam088_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam088_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam089_ms45":
                            txtG1Ssp_cam089_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam089_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam089_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam090_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam090_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam090_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam090_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam091_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam091_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam091_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam091_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam092_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam092_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam092_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam092_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam093_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam093_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam093_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam093_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam094_ms45":
                            txtG1Ssp_cam094_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam094_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam094_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam095_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam095_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam095_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam095_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam096_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam096_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam096_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam096_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam097_ms45":
                            txtG1Ssp_cam097_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam097_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam097_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam098_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam098_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam098_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam098_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam099_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam099_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam099_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam099_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam100_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam100_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam100_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam100_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam101_ms45":
                            txtG1Ssp_cam101_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam101_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam101_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam102_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam102_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam102_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam102_ms45.Text : lcrValor;                            
                            break;
                        case "cboG1Ssp_cam103_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam103_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam103_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam103_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam104_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam104_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam104_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam104_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam105_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam105_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam105_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam105_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam106_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam106_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam106_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam106_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam107_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam107_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam107_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam107_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam108_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam108_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam108_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam108_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam109_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam109_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam109_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam109_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam110_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam110_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam110_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam110_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam111_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam111_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam111_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam111_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam112_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam112_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam112_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam112_ms45.Text : lcrValor;
                            break;
                        case "cboG1Ssp_cam113_ms45":
                            txtG1Ssp_cam113_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam113_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam113_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam114_ms45":
                            txtG1Ssp_cam114_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam114_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam114_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam115_ms45":
                            txtG1Ssp_cam115_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam115_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam115_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam116_ms45":
                            txtG1Ssp_cam116_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam116_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam116_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam117_ms45":
                            txtG1Ssp_cam117_ms45.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam117_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Ssp_cam117_ms45.Text, ",", lobList.ListaValoresSel);
                            break;
                        case "cboG1Ssp_cam118_ms45":
                            lcrValor = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Ssp_cam118_ms45.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobList.ListaValoresSel);
                            txtG1Ssp_cam118_ms45.Text = lcrValor == "VP" ? txtG1Ssp_cam118_ms45.Text : lcrValor;
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
                    Decimal ldeInicial;         // valor inicial entre rangos decimales
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
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

            _DataGridSErroresFiltro = new CollectionViewSource() { Source = gobObjVModelo.tmpLogError };
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
                luxAnimacion.To = -540; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
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
        // ACCIONES BARRA DE OPCIONES SUPERIOR
        //------------------------------------------------------------
        #region fcvMostrarMenuContextual: Mostrar menu contextual
        private void fcvMostrarMenuContextual(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #endregion
        //---------------------------------------------------------------
        // EJECUTAR VALIDACION DE DATOS EN VISTA
        //---------------------------------------------------------------
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
        #region fcvIniciarValidacionDatos: Inicia el proceso de validacion de los datos en la vista
        /// <summary>
        /// <para>Inicia el proceso de validacion de los datos en la vista</para>
        /// </summary>
        private void fcvIniciarValidacionDatos()
        {
            if (String.IsNullOrWhiteSpace(this.txtG1Ssp_codper_peri.Text)) { MessageBox.Show("Debe seleccionar un rango periodo de datos."); return; }

            String lcrCodigoFuente = fcrCargarCodigoFuente();
            var larListaDll = new List<String>();
            larListaDll.Add("System.dll");
            larListaDll.Add("System.Data.Entity.dll");
            larListaDll.Add("Datos.dll");
            gobObjVModelo.tmpLogError = new List<LogErrores>();
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

                if (gobObjVModelo.tmpLogError.Count > 0 && glgVistaEtiquetaEstadoVisible == false)
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
            gobParam.FechaFormato    = "YMD";
            gobParam.FechaSeparador  = "-";
            gobParam.CodigoPlantilla = gobObjVModelo.G1Sis_secreg_siva;
            gobParam.CodigoPeriodo   = this.txtG1Ssp_codper_peri.Text;
            gobParam.OrigenDatos     = !String.IsNullOrWhiteSpace(gobParam.OrigenDatos) ? gobParam.OrigenDatos : "BDATOS";
            this.lblTituloEtiqueta.Text = "Resultados validación de datos...";

            // Ejecutar validacion
            IRegistroError lobRefIRegistroError = new RefIRegistroError();
            fcvEjecutarScripts(lobRefIRegistroError, gobObjVModelo.TmpRegActivo4505Ex, gobObjVModelo.TmpRegActivo4505Ex.Ssp_ideaux_ns45);

            return llgreturn;
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
                lobRegistro.Secuencial = gnuSecuencialErrores;
                lobRegistro.IdRegistro = tnuNumeroRegistro.ToString();
                lobRegistro.NombreCampo = tcrTituloCampo;
                lobRegistro.ValorCampo = tcrValorCampo;
                lobRegistro.CodigoError = tcrCodigoError;
                lobRegistro.MensajeError = tcrMensaje;
                lobRegistro.NivelError = tcrNivelError;
                // Datos del registro
                lobRegistro.IdUnicoUsuario = gobObjVModelo.TmpRegActivo4505Ex.Sia_idesec_usua;
                lobRegistro.IdUsuario   = gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam004_ms45;
                lobRegistro.PApellido   = gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam005_ms45;
                lobRegistro.SApellido   = gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam006_ms45;
                lobRegistro.PNombre     = gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam007_ms45;
                lobRegistro.SNombre     = gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam008_ms45;
                // llave de busqueda 
                lcrllave1 = gobObjVModelo.TmpRegActivo4505Ex.Ssp_ideaux_ns45.ToString().Trim() + " ";
                lcrllave2 = gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam004_ms45 != null ? gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam004_ms45.ToUpper() + " " : String.Empty;
                lcrllave3 = gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam005_ms45 != null ? gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam005_ms45.ToUpper() + " " : String.Empty;
                lcrllave4 = gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam006_ms45 != null ? gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam006_ms45.ToUpper() + " " : String.Empty;
                lcrllave5 = gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam007_ms45 != null ? gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam007_ms45.ToUpper() + " " : String.Empty;
                lcrllave6 = gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam008_ms45 != null ? gobObjVModelo.TmpRegActivo4505Ex.Ssp_cam008_ms45.ToUpper() : String.Empty;

                lobRegistro.LlaveBusqueda = lcrllave1 + lcrllave2 + lcrllave3 + lcrllave4 + lcrllave5 +
                                            lcrllave6 + " " + tcrTituloCampo.ToUpper() + " " + tcrCodigoError + " " + tcrMensaje;

                // adicionar al temporal de errores
                gobObjVModelo.tmpLogError.Add(lobRegistro);

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
        #region flgRefAppICampo90118: Referencia validacion Rango 90 a 118
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
            var lobTemp = ModeloSismadeplavalid.flsListaSismadeplavalid(gobObjVModelo.G1Sis_secreg_siva);
            var lcrCodigo = String.Empty;

            foreach (var lobreg in lobTemp)
            {
                if (lobreg.Sis_estreg_sivd == "1")
                {
                    lcrCodigo += lobreg.Sis_codval_sivd.Trim() + "\n";
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
    }
}
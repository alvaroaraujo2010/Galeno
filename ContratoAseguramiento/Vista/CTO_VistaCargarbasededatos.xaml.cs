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
using Microsoft.CSharp;
using Sistema.Utilidades;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.EntityClient;
using Sistema.Vista;
using Sistema.Modelo;
using Datos.Modelos;
using Sistema.Clases;
using Sistema.Validacion;
using ContratoAseguramiento.VistaModelo;
using ContratoAseguramiento.Utilidades;
using Excel = Microsoft.Office.Interop.Excel;

namespace ContratoAseguramiento.Vista
{
    /// <summary>
    /// Interaction logic for SSP_VistaGestionValidacion.xaml
    /// </summary>
    public partial class VistaCargarbasededatos : Window, IEdicionRegistro
    {
        #region Iniciar Formulario principal
        //- Variables para control de validacion 
        public static CompilerResults gobEnsamblado = null;
        public static Type gobRefoAppType = null;
        public static ParamValidMS gobParam = new ParamValidMS();
        public static int gnuSecuencialErrores = 0;
        private static DbAplicacion db;
        //- Variables para ejecuacion de Interface
        #region Referencias a Funciones personalizadas
        // General
        public static IValidadorMS oAppISia_tipide_tide = null;
        public static IValidadorMS oAppISia_nroide_usua = null;
        public static IValidadorMS oAppISia_priape_usua = null;
        public static IValidadorMS oAppISia_segape_usua = null;
        public static IValidadorMS oAppISia_prinom_usua = null;
        public static IValidadorMS oAppISia_segnom_usua = null;
        public static IValidadorMS oAppISia_fecnac_usua = null;
        public static IValidadorMS oAppISis_codsex_sexo = null;
        public static IValidadorMS oAppISis_codmun_muni = null;
        public static IValidadorMS oAppISis_coddep_dpto = null;
        public static IValidadorMS oAppISis_zonres_tzon = null;
        public static IValidadorMS oAppISia_codeps_teps = null;
        // Subsidiado
        public static IValidadorMS oAppISia_tippob_tpob = null;
        public static IValidadorMS oAppISia_nivsbn_nsbn = null;
        public static IValidadorMS oAppISia_feceps_usua = null;
        public static IValidadorMS oAppISia_modsub_usua = null;
        // Contributivo
        public static IValidadorMS oAppISia_tipcot_tcot = null;
        public static IValidadorMS oAppISia_tipafi_tafi = null;
        public static IValidadorMS oAppISia_parent_tafi = null;
        public static IValidadorMS oAppISia_conben_usua = null;
        public static IValidadorMS oAppISia_fecsss_usua = null;
        public static IValidadorMS oAppISia_tpidap_tide = null;
        public static IValidadorMS oAppISia_ideapo_usua = null;
        public static IValidadorMS oAppISis_codocu_ocup = null;
        #endregion

        // variables varias
        bool glgObjetosCargados              = false;
        bool glgVistaPropiedades             = false;
        bool glgVistaMenuSuperiorVisible     = false;
        bool glgVistaEtiquetaEstadoVisible   = false;
        public String gcrOrigenDatosCargados = "PLANO";// BDATOS/EXCEL/PLANO
        public String gcrFechaFormato        = "DMY";
        public String gcrFechaSeparador      = "/";
        public static String gcrPrmEstructuraArchivo = String.Empty;
        public static char[] gcrPrmCharSeparadorCampos = null;
        public static int gnuPrmRegistroInicioCargue = 1;
        public String gcrPrmNombreArchivoTemporal = String.Empty;
        public int gnuPrmResumenValidTotalOk = 0;
        public int gnuPrmResumenValidTotalErrados = 0;
        public List<RegistroDuplicado> tmpRegDuplicados = null;

        // variables para Actualizar en base de datos
        public String gcrActualizNumeroContrato = String.Empty;
        public String gcrActualizIdUnicoContrato = String.Empty;
        public String gcrActualizIdCodigoEps = String.Empty;
        public String gcrActualizRegimenSalud = String.Empty; 
        public bool glgActualizEliminarReg = false;

        // Variables Referencia VistaModelo y archivos temporales de datos
        static ModeloCtomaestroafiliadosEx tmpRegActAfiliado = null;
        static VistaModeloCargarbasededatos vm = null;
        public String gcrCtrF2TexBox = String.Empty;

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
        public String gcrExportarArchivoNombreyRuta = @"C:\Users\familia\Desktop\ARCHIVOPLANOEJM.TXT";
        public String gcrExportarArchivoRuta        = String.Empty;
        #endregion

        public VistaCargarbasededatos()
        {
            InitializeComponent();

            vm = this.DataContext as VistaModeloCargarbasededatos; //Binding con el Vista Modelo
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            vm.TmpG2ListaBrow = new System.Collections.ObjectModel.ObservableCollection<ModeloCtomaestroafiliadosEx>();
            glgObjetosCargados = true;
            fcvResizePantalla();
            fcvTimerGeneral();

            // Valores por defecto
            vm.glgSIS_DatosVerificados = false;
            this.txtFechaValidacion.Text = DateTime.Now.Date.ToShortDateString();
            this.txtPrmEstructuraArchivo.Text ="2629";
            this.txtPrmFormatoArchivo.Text = "3";
            this.txtRegistrosBdatos.Text = "1";
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
            this.objHistCortina.Height = lduHeight;

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
                fcvValoresParaActualizarBdatos();
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
        #region Ventana Historial
        #region fcvActivarVistaHistorial: Mostrar u Ocultar la Ventana Propiedades
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

                case "txtG1Cto_seccon_carg":
                    this.txtG1Cto_seccon_carg.Text = tcrCodigo;
                    gcrCtrF2TexBox = "OK";
                    break;
                case "txtG1Cto_seccon_cont":
                    this.txtG1Cto_seccon_cont.Text = tcrCodigo;
                    gcrCtrF2TexBox = "OK";
                    break;

                case "txtG1Sia_codeps_teps":
                    //this.txtG1Sia_codeps_teps.Text = tcrCodigo;
                    break;

                default:
                    // seleccion desde un browser para una tabla
                    //gcrCtrF2TexBoxObj.Text = tcrCodigo;
                    break;
            }
        }
        #endregion
        #region fcvIEdicionRegistro: Metodo que recoge registro modificado en la vista
        /// <summary>
        /// <para>Metodo que recoge registro modificado en la vista</para>
        /// </summary>
        public void fcvIEdicionRegistro(ModeloCtomaestroafiliadosEx tobRegistro)
        {
            if (tobRegistro != null)
            {
                /*
                var lobRegEx = gobObjVModelo.TmpG2ListaBrow.FirstOrDefault(x => x.Ssp_ideaux_ctou.Equals(tobRegistro.Ssp_ideaux_ctou));
                if (lobRegEx != null)
                {
                    #region Valores actualizados
                    lobRegEx.Cto_idesec_ctou = tobRegistro.Cto_idesec_ctou;
                    lobRegEx.Sia_nroide_usua = tobRegistro.Sia_nroide_usua;
                    lobRegEx.Sia_codeps_teps = tobRegistro.Sia_codeps_teps;
                    lobRegEx.Ssp_cam000_ms45 = tobRegistro.Ssp_cam000_ms45;
                    #endregion
                }
                */
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
            var lcrFiltro = "Sismaesplavalid.sis_codarc_siar = 'MSARC'";

            Browser01 frbro = new Browser01("SIS", "SISMAESPLAVALID", lcrFiltro, "Maestro plantillas para validación de archivos...");
            gcrCtrF2TexBox = "txtG1Sis_secreg_siva";
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
        private void txtG1Cto_seccon_carg_Browser()
        {
            Browser01 frbro = new Browser01("CTO", "CTOMAESCONTRATO", "", "Maestro contratos  EPS...");
            gcrCtrF2TexBox = "txtG1Cto_seccon_carg";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        private void txtG1Cto_seccon_cont_Browser()
        {
            Browser01 frbro = new Browser01("CTO", "CTOMAESCONTRATO", "", "Maestro contratos  EPS...");
            gcrCtrF2TexBox = "txtG1Cto_seccon_cont";
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
        // Actualizar Objeto TextBox desde CombBox
        #region Actualizar Objeto TextBox desde CombBox
        private void SeleccionComboBoxOpcion(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true)
                {
                    CrtForms.ListaComboBox lobList = (CrtForms.ListaComboBox)e.AddedItems[0];
                    ComboBox lobCombo = (ComboBox)sender;

                    switch (lobCombo.Name)
                    {
                        case "cboPrmEstructuraArchivo":
                            this.txtPrmEstructuraArchivo.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtPrmEstructuraArchivo.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtPrmEstructuraArchivo.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboPrmFormatoArchivo":
                            this.txtPrmFormatoArchivo.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtPrmFormatoArchivo.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtPrmFormatoArchivo.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboRegistrosBdatos":
                            this.txtRegistrosBdatos.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtRegistrosBdatos.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtRegistrosBdatos.Text, ",", lobList.ListaValoresSel);
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
                if (glgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
                        case "txtPrmEstructuraArchivo":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboPrmEstructuraArchivo.SelectedItem;
                            this.cboPrmEstructuraArchivo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;

                        case "txtPrmFormatoArchivo":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)cboPrmFormatoArchivo.SelectedItem;
                            this.cboPrmFormatoArchivo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;

                        case "txtRegistrosBdatos":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)cboRegistrosBdatos.SelectedItem;
                            this.cboRegistrosBdatos.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
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
                    case "dpkFechaValidacion":
                        this.txtFechaValidacion.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, this.txtFechaValidacion);
                        break;
                    case "dpkxxx":
                        //txtG1Sia_fecedt_usua.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        //FocusManager.SetFocusedElement(this, txtG1Sia_fecedt_usua);
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
                            case "txtFechaValidacion":
                                this.dpkFechaValidacion.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtxxx":
                                //dpkG1Sia_feceps_usua.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        // FUNCIONES PARA UTILIDADES VARIAS 
        //---------------------------------------------------------------
        #region fcvReiniciarValoresEnVariables: Reiniciar valores en variables y objetos
        /// <summary>
        /// <para>Reiniciar valores en variables y objetos al cargar archivos o validar</para>
        /// </summary>
        private void fcvReiniciarValoresEnVariables()
        {
            // Restablecer valores en variables de parametros iniciales 
            gcrPrmEstructuraArchivo = this.txtPrmEstructuraArchivo.Text;
            vm.glgSIS_DatosVerificados = false;
            gnuPrmResumenValidTotalOk = 0;
            gnuPrmResumenValidTotalErrados = 0;
            this.txtG1ValidacionOk.Text = String.Empty;
            this.txtG1ValidacionErrados.Text = String.Empty;
        }
        #endregion
        #region fcvValoresParaActualizarBdatos: Valores en variables para actualizar en base de datos
        /// <summary>
        /// <para>Valores en variables para actualizar en base de datos</para>
        /// </summary>
        private void fcvValoresParaActualizarBdatos()
        {
            // Restablecer valores en variables de parametros iniciales 
            gcrActualizNumeroContrato   = this.txtG1Cto_nrocon_cont.Text;
            gcrActualizIdUnicoContrato  = this.txtG1Cto_seccon_cont.Text;
            gcrActualizIdCodigoEps      = this.txtG1Sia_codeps_teps.Text;
            glgActualizEliminarReg      = (bool)this.chkEliminar.IsChecked ? true : false;

            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(gcrActualizIdUnicoContrato);
            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cto_seccon_cont))
            {
                gcrActualizRegimenSalud = tmp.sia_tipusu_regi;
            }
        }
        #endregion
        //---------------------------------------------------------------
        // IMPORTAR DATOS
        //---------------------------------------------------------------
        #region fcvAccAbrirArchivos: Iniciar vista explorar archivos en sistema
        /// <summary>
        /// <para>Iniciar vista explorar archivos en sistema</para>
        /// </summary>
        private void fcvAccAbrirArchivos(object sender, RoutedEventArgs e)
        {
            // Restablecer valores en variables de parametros iniciales 
            fcvReiniciarValoresEnVariables();

            if (!Funciones.flgExisteSubCadenaStringEx(this.txtG1NumRegIniCargue.Text, "0123456789"))
            {
                this.txtG1NumRegIniCargue.Text = "1";
            }
            gnuPrmRegistroInicioCargue = Convert.ToInt32(this.txtG1NumRegIniCargue.Text);

            var lcrOpc = this.txtPrmFormatoArchivo.Text;

            switch (lcrOpc)
            {
                case "1": // desde Excel
                    fcvAccAbrirArchivoExcel();
                    break;

                case "2": // Base de datos en sistema
                    fcvAccAbrirAfiliadosBdatos();
                    break;

                default: // Desde formato archivos planos
                    fcvAccAbrirArchivoPlano();
                    break;
            }

        }
        #endregion
        // Importar datos archivos planos externos
        #region fcvAccAbrirArchivoPlano: abrir archivos planos
        private void fcvAccAbrirArchivoPlano()
        {
            if (flgDialogoBuscarArchivo("Buscar Archivo plano...", "Buscar archivo plano |*.txt", ".txt"))
            {
                gcrPrmCharSeparadorCampos   = fcrCharSeparadorCampos();

                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cargando archivo plano de datos...", "CENTRO");
                lobDlgAdd.Show();

                glgObjetosCargados = false;
                vm.glgSIS_DatosVerificados = false;
                this.objDataGrid.ItemsSource = null;
                fcvFiltroDataGridQuitarValores();
                this.objDataGridErrores.ItemsSource = null;
                gcrOrigenDatosCargados = "PLANO";

                vm.TmpG2ListaBrow = new System.Collections.ObjectModel.ObservableCollection<ModeloCtomaestroafiliadosEx>();
                flgCargarDesdeArchivoPlano();
                flgFiltroDataGridDatos();

                glgObjetosCargados = true;
                lobDlgAdd.Close();
            }
        }
        #endregion
        //Importar desde base de datos
        #region fcvAccAbrirAfiliadosBdatos: Cargar datos maestro afiliados contratos  sistema
        private void fcvAccAbrirAfiliadosBdatos()
        {
            gcrCtrF2TexBox = String.Empty;
            txtG1Cto_seccon_carg_Browser(); // Seleccionar contrato

            if (gcrCtrF2TexBox == "OK")
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cargando maestro afiliados desde Base de datos...", "CENTRO");
                lobDlgAdd.Show();

                // Mostrar Contrato y EPS Seleccionado
                var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(this.txtG1Cto_seccon_carg.Text);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cto_seccon_cont))
                {
                    this.txtG1Cto_nrocon_carg.Text = tmp.cto_nrocon_cont;
                    this.txtG1Sia_codeps_carg.Text = tmp.sia_codeps_teps;
                    // Nombre de la EPS
                    var tmp1 = SIAValidarCodigo.fobRegBuscarSiatablaeps(tmp.sia_codeps_teps);
                    if (tmp1 != null && !String.IsNullOrWhiteSpace(tmp1.sia_codeps_teps))
                    {
                        this.txtG1Sia_deseps_carg.Text = tmp1.sia_deseps_teps;
                    }
                }

                // Limpiar la vista Browser principal
                glgObjetosCargados = false;
                vm.glgSIS_DatosVerificados = false;
                this.objDataGrid.ItemsSource = null;
                fcvFiltroDataGridQuitarValores();
                this.objDataGridErrores.ItemsSource = null;
                gcrOrigenDatosCargados = "BDATOS";

                vm.TmpG2ListaBrow = new ObservableCollection<ModeloCtomaestroafiliadosEx>
                                                   (ModeloCtomaestroafiliadosEx.CtomaestroafiliadosContrato(this.txtG1Cto_seccon_carg.Text));
                this.txtG1Ssp_rutarc_carg.Text = "ORIGEN DESDE BASE DE DATOS";
                this.txtG1ArchivoOrigen.Text   = "DATOS BASE DE DATOS";
                //this.txtG1Sia_codeps_carg.Text = this.txtG1Sia_codeps_teps.Text;
                this.txtG1Ssp_totreg_carg.Text = vm.TmpG2ListaBrow.Count().ToString();

                flgFiltroDataGridDatos();

                glgObjetosCargados = true;
                lobDlgAdd.Close();
            }
        }
        #endregion
        // Importar datos desde archivos Microsoft Excel 
        #region fcvAccAbrirArchivoExcel: abrir archivos planos
        private void fcvAccAbrirArchivoExcel()
        {
            if (flgDialogoBuscarArchivo("Buscar Archivo Microsoft Excel...", "Buscar archivo Microsoft Excel |*.xls; *.xlsx; *.xlsm; *.xlsb", ".xlsx"))
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cargando archivo de Microsoft Excel...", "CENTRO");
                lobDlgAdd.Show();

                glgObjetosCargados = false;
                this.objDataGrid.ItemsSource = null;
                vm.glgSIS_DatosVerificados = false;
                fcvFiltroDataGridQuitarValores();
                this.objDataGridErrores.ItemsSource = null;
                gcrOrigenDatosCargados = "EXCEL";

                vm.TmpG2ListaBrow = new System.Collections.ObjectModel.ObservableCollection<ModeloCtomaestroafiliadosEx>();
                //flgCargarArchivoExcel(gcrArchivoExternoNombreyRuta);
                flgArchivoExcelPlano(gcrArchivoExternoNombreyRuta);
                flgFiltroDataGridDatos();

                glgObjetosCargados = true;
                lobDlgAdd.Close();
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
            int lnuContadorLineas = 0;
            int lnuContadorRegCargados = 0;

            while (lcrRegistroLinea != null)
            {
                lnuContadorLineas++;

                lcrRegistroLinea = lobjReader.ReadLine();

                if (lcrRegistroLinea != null)
                {
                    if (lnuContadorLineas >= gnuPrmRegistroInicioCargue)
                    {
                        // registros cargados
                        lnuContadorRegCargados++;
                        flgGenerarRegistroDesdeArray(lcrRegistroLinea, lnuContadorRegCargados);
                        llgReturn = true;
                    }
                }
            }
            this.txtG1Ssp_totreg_carg.Text = lnuContadorRegCargados.ToString();
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

            string[] larArray = tcrRegistroLinea.Split(gcrPrmCharSeparadorCampos);
            if (gcrPrmEstructuraArchivo == "S2629")
            {
                this.txtG1Sia_codeps_carg.Text = larArray[0];
            }
            else 
            {
                this.txtG1Sia_codeps_carg.Text = larArray[1]; // 812
            }
            // Nombre de la EPS
            if (!String.IsNullOrWhiteSpace(this.txtG1Sia_codeps_carg.Text))
            {
                var tmp1 = SIAValidarCodigo.fobRegBuscarSiatablaeps(this.txtG1Sia_codeps_carg.Text);
                if (tmp1 != null && !String.IsNullOrWhiteSpace(tmp1.sia_codeps_teps))
                {
                    this.txtG1Sia_deseps_carg.Text = tmp1.sia_deseps_teps;
                }
            }
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
            var llgAuxRet = false;

            string[] larArray = tcrRegistroLinea.Split(gcrPrmCharSeparadorCampos);
            int i = 0;
            String lcrllave1 = String.Empty;
            String lcrllave2 = String.Empty;
            String lcrllave3 = String.Empty;
            String lcrllave4 = String.Empty;
            String lcrllave5 = String.Empty;
            String lcrllave6 = String.Empty;

            tmpRegActAfiliado = new ModeloCtomaestroafiliadosEx();
            tmpRegActAfiliado.Estado = "INCLUIDO";
            tmpRegActAfiliado.Ssp_ideaux_ctou = tnuNumeroRegistro;


            for (i = 0; i < larArray.Length; i++)
            {
                llgAuxRet = llgReturn == true ? true : llgAuxRet;
                llgReturn = flgCargarCampoTipoEstructura(i, larArray[i]);
                llgReturn = llgAuxRet == true ? true : llgReturn;
            }
            if (llgReturn == true)
            {
                #region Campos
                tmpRegActAfiliado.Sia_codeps_teps = tmpRegActAfiliado.Sia_codeps_teps == null ? String.Empty : tmpRegActAfiliado.Sia_codeps_teps;
                tmpRegActAfiliado.Sia_tipide_tide = tmpRegActAfiliado.Sia_tipide_tide == null ? String.Empty : tmpRegActAfiliado.Sia_tipide_tide;
                tmpRegActAfiliado.Sia_nroide_usua = tmpRegActAfiliado.Sia_nroide_usua == null ? String.Empty : tmpRegActAfiliado.Sia_nroide_usua;
                tmpRegActAfiliado.Sia_priape_usua = tmpRegActAfiliado.Sia_priape_usua == null ? String.Empty : tmpRegActAfiliado.Sia_priape_usua;
                tmpRegActAfiliado.Sia_segape_usua = tmpRegActAfiliado.Sia_segape_usua == null ? String.Empty : tmpRegActAfiliado.Sia_segape_usua;
                tmpRegActAfiliado.Sia_prinom_usua = tmpRegActAfiliado.Sia_prinom_usua == null ? String.Empty : tmpRegActAfiliado.Sia_prinom_usua;
                tmpRegActAfiliado.Sia_segnom_usua = tmpRegActAfiliado.Sia_segnom_usua == null ? String.Empty : tmpRegActAfiliado.Sia_segnom_usua;
                tmpRegActAfiliado.Sia_fecnac_usua = tmpRegActAfiliado.Sia_fecnac_usua == null ? String.Empty : tmpRegActAfiliado.Sia_fecnac_usua;
                tmpRegActAfiliado.Sis_codsex_sexo = tmpRegActAfiliado.Sis_codsex_sexo == null ? String.Empty : tmpRegActAfiliado.Sis_codsex_sexo;
                tmpRegActAfiliado.Sia_tippob_tpob = tmpRegActAfiliado.Sia_tippob_tpob == null ? String.Empty : tmpRegActAfiliado.Sia_tippob_tpob;
                tmpRegActAfiliado.Sia_nivsbn_nsbn = tmpRegActAfiliado.Sia_nivsbn_nsbn == null ? String.Empty : tmpRegActAfiliado.Sia_nivsbn_nsbn;
                tmpRegActAfiliado.Sis_coddep_dpto = tmpRegActAfiliado.Sis_coddep_dpto == null ? String.Empty : tmpRegActAfiliado.Sis_coddep_dpto;
                tmpRegActAfiliado.Sis_codmun_muni = tmpRegActAfiliado.Sis_codmun_muni == null ? String.Empty : tmpRegActAfiliado.Sis_codmun_muni;
                tmpRegActAfiliado.Sis_zonres_tzon = tmpRegActAfiliado.Sis_zonres_tzon == null ? String.Empty : tmpRegActAfiliado.Sis_zonres_tzon;
                tmpRegActAfiliado.Sia_feceps_usua = tmpRegActAfiliado.Sia_feceps_usua == null ? String.Empty : tmpRegActAfiliado.Sia_feceps_usua;
                tmpRegActAfiliado.Sia_modsub_usua = tmpRegActAfiliado.Sia_modsub_usua == null ? String.Empty : tmpRegActAfiliado.Sia_modsub_usua;
                tmpRegActAfiliado.Sis_idemun_muni = tmpRegActAfiliado.Sis_coddep_dpto.Trim() + tmpRegActAfiliado.Sis_codmun_muni.Trim();
                tmpRegActAfiliado.Sia_tpicot_tide = tmpRegActAfiliado.Sia_tpicot_tide == null ? String.Empty : tmpRegActAfiliado.Sia_tpicot_tide;
                tmpRegActAfiliado.Sia_idecot_usua = tmpRegActAfiliado.Sia_idecot_usua == null ? String.Empty : tmpRegActAfiliado.Sia_idecot_usua;
                tmpRegActAfiliado.Sia_tipcot_tcot = tmpRegActAfiliado.Sia_tipcot_tcot == null ? String.Empty : tmpRegActAfiliado.Sia_tipcot_tcot;
                tmpRegActAfiliado.Sia_tipafi_tafi = tmpRegActAfiliado.Sia_tipafi_tafi == null ? String.Empty : tmpRegActAfiliado.Sia_tipafi_tafi;
                tmpRegActAfiliado.Sia_parent_tafi = tmpRegActAfiliado.Sia_parent_tafi == null ? String.Empty : tmpRegActAfiliado.Sia_parent_tafi;
                tmpRegActAfiliado.Sia_conben_usua = tmpRegActAfiliado.Sia_conben_usua == null ? String.Empty : tmpRegActAfiliado.Sia_conben_usua;
                tmpRegActAfiliado.Sia_tpidap_tide = tmpRegActAfiliado.Sia_tpidap_tide == null ? String.Empty : tmpRegActAfiliado.Sia_tpidap_tide;
                tmpRegActAfiliado.Sia_ideapo_usua = tmpRegActAfiliado.Sia_ideapo_usua == null ? String.Empty : tmpRegActAfiliado.Sia_ideapo_usua;
                tmpRegActAfiliado.Sis_codocu_ocup = tmpRegActAfiliado.Sis_codocu_ocup == null ? String.Empty : tmpRegActAfiliado.Sis_codocu_ocup;
                #endregion

                lcrllave1 = tmpRegActAfiliado.Ssp_ideaux_ctou.ToString().Trim() + " ";
                lcrllave2 = tmpRegActAfiliado.Sia_nroide_usua != null ? tmpRegActAfiliado.Sia_nroide_usua.ToUpper() + " " : String.Empty;
                lcrllave3 = tmpRegActAfiliado.Sia_priape_usua != null ? tmpRegActAfiliado.Sia_priape_usua.ToUpper() + " " : String.Empty;
                lcrllave4 = tmpRegActAfiliado.Sia_segape_usua != null ? tmpRegActAfiliado.Sia_segape_usua.ToUpper() + " " : String.Empty;
                lcrllave5 = tmpRegActAfiliado.Sia_prinom_usua != null ? tmpRegActAfiliado.Sia_prinom_usua.ToUpper() + " " : String.Empty;
                lcrllave6 = tmpRegActAfiliado.Sia_segnom_usua != null ? tmpRegActAfiliado.Sia_segnom_usua.ToUpper() : String.Empty;

                tmpRegActAfiliado.LlaveBusqueda     = lcrllave1 + lcrllave2 + lcrllave3 + lcrllave4 + lcrllave5 + lcrllave6;
                tmpRegActAfiliado.Ssp_niverr_ctou   = String.Empty;
                tmpRegActAfiliado.Estado            = "NO-VALIDADO";
                tmpRegActAfiliado.NotaRegistro      = String.Empty;

                vm.TmpG2ListaBrow.Add(tmpRegActAfiliado);
            }
            return llgReturn;
        }
        #endregion
        #region fcrCharSeparadorCampos: Devolver caracter separador campo
        /// <summary>
        /// <para>Devolver el caracter separador para campos en archivo plano</para>
        /// </summary>
        public char[] fcrCharSeparadorCampos()
        {
            var lcrOpc = this.txtPrmFormatoArchivo.Text;
            char[] lcrCharSeparador = (",").ToCharArray();

            switch (lcrOpc)
            {
                case "3":
                    lcrCharSeparador = (",").ToCharArray();
                    break;

                case "4":
                    lcrCharSeparador = (";").ToCharArray();
                    break;

                case "5":
                    lcrCharSeparador = ("\t").ToCharArray();
                    break;
            }
            return lcrCharSeparador;
        }
        #endregion
        #region flgCargarCampoTipoEstructura: Cargar campo segun tipo archivo
        /// <summary>
        /// <para>Carga el campo segun el tipo de estructura seleccionada "MS"/"MC" segun resolución "2629"/"812"</para>
        /// </summary>
        public bool flgCargarCampoTipoEstructura(int tnuNumeroCampo, String tcrValorEnCampo)
        {
            var llgReturn = false;
            var lcrNumeroCampo = tnuNumeroCampo.ToString().Trim();

            if (gcrPrmEstructuraArchivo == "S2629" && tnuNumeroCampo <= 15) // 15 Campos iniciando desde campo cero 
            {
                // Subsidiado 2629                
                llgReturn = flgCargarCampoEstructura_MS2629(lcrNumeroCampo, tcrValorEnCampo);
            }
            else if (gcrPrmEstructuraArchivo == "S812" && tnuNumeroCampo <= 27) // 27 CAMPOS iniciando desde campo cero 
            {
                // Subsidiado 2812
                llgReturn = flgCargarCampoEstructura_MS812(lcrNumeroCampo, tcrValorEnCampo);
            }
            else if (gcrPrmEstructuraArchivo == "C2629" && tnuNumeroCampo <= 21) // 21 Campos iniciando desde campo cero 
            {
                // Contributivo 2629                
                llgReturn = flgCargarCampoEstructura_MC2629(lcrNumeroCampo, tcrValorEnCampo);
            }
            else if (gcrPrmEstructuraArchivo == "C812" && tnuNumeroCampo <= 23) // 23 CAMPOS iniciando desde campo cero 
            {
                // Contributivo 2812
                llgReturn = flgCargarCampoEstructura_MC812(lcrNumeroCampo, tcrValorEnCampo);
            }
            return llgReturn;
        }
        #endregion
        // Maestro subsidiado - Cargar campos segun estructura de archivo plano
        #region flgCargarCampoEstructura_MS2629: Registros Estructura Resolucion 2629  Maestro Subsidiado
        /// <summary>
        /// <para>Registros Estructura Resolucion 2629 Maestro Subsidiado</para>
        /// </summary>
        public bool flgCargarCampoEstructura_MS2629(String tcrNombreCampo, String tcrValor)
        {
            tcrValor = String.IsNullOrWhiteSpace(tcrValor) || tcrValor == null ? String.Empty : tcrValor;
            var llgReturn = false;
            #region Campos
            if (tmpRegActAfiliado != null)
            {
                switch (tcrNombreCampo)
                {
                    case "0":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_codeps_teps = tcrValor;
                        break;

                    case "1":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tipide_tide = tcrValor;
                        break;

                    case "2":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_nroide_usua = tcrValor;
                        break;

                    case "3":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_priape_usua = tcrValor;
                        break;

                    case "4":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_segape_usua = tcrValor;
                        break;

                    case "5":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_prinom_usua = tcrValor;
                        break;

                    case "6":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_segnom_usua = tcrValor;
                        break;

                    case "7":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_fecnac_usua = tcrValor;
                        break;

                    case "8":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_codsex_sexo = tcrValor;
                        break;

                    case "9":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_coddep_dpto = tcrValor;
                        break;

                    case "10":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_codmun_muni = tcrValor;
                        break;

                    case "11":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_zonres_tzon = tcrValor;
                        break;

                    case "12":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_feceps_usua = tcrValor;
                        break;

                    case "13":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tippob_tpob = tcrValor;
                        break;

                    case "14":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_nivsbn_nsbn = tcrValor;
                        break;

                    case "15":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_modsub_usua = tcrValor;
                        break;
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgCargarCampoEstructura_MS812: Registros Estructura Resolucion 812 Maestro Subsidiado
        /// <summary>
        /// <para>Registros Estructura Resolucion 812 Maestro Subsidiado</para>
        /// </summary>
        public bool flgCargarCampoEstructura_MS812(String tcrNombreCampo, String tcrValor)
        {
            tcrValor = String.IsNullOrWhiteSpace(tcrValor) || tcrValor == null ? String.Empty : tcrValor;
            var llgReturn = false;
            #region Campos
            if (tmpRegActAfiliado != null)
            {

                switch (tcrNombreCampo)
                {
                        // 0 En esta esctructura el campo 0 es un secuencial que no se toma

                    case "1":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_codeps_teps = tcrValor;
                        break;

                        // 2 Tipo Id Cabeza Grupo
                        // 3 Numero id cabeza  grupo

                    case "4":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tipide_tide = tcrValor;
                        break;

                    case "5":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_nroide_usua = tcrValor;
                        break;

                    case "6":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_priape_usua = tcrValor;
                        break;

                    case "7":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_segape_usua = tcrValor;
                        break;

                    case "8":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_prinom_usua = tcrValor;
                        break;

                    case "9":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_segnom_usua = tcrValor;
                        break;

                    case "10":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_fecnac_usua = tcrValor;
                        break;

                    case "11":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_codsex_sexo = tcrValor;
                        break;

                        //12,13

                    case "14":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tippob_tpob = tcrValor;
                        break;

                    case "15":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_nivsbn_nsbn = tcrValor;
                        break;

                        //16,17

                    case "18":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_coddep_dpto = tcrValor;
                        break;

                    case "19":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_codmun_muni = tcrValor;
                        break;

                    case "20":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_zonres_tzon = tcrValor;
                        break;

                        //21,21

                    case "22":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_feceps_usua = tcrValor;
                        break;

                        //23,24,25,26

                    case "27":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_modsub_usua = tcrValor;
                        break;
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        // Maestro contributivo - Cargar campos segun estructura de archivo plano
        #region flgCargarCampoEstructura_MC2629: Registros Estructura Resolucion 2629  Maestro Contributivo
        /// <summary>
        /// <para>Registros Estructura Resolucion 2629 Maestro Contributivo</para>
        /// </summary>
        public bool flgCargarCampoEstructura_MC2629(String tcrNombreCampo, String tcrValor)
        {
            tcrValor = String.IsNullOrWhiteSpace(tcrValor) || tcrValor == null ? String.Empty : tcrValor;
            var llgReturn = false;
            #region Campos
            if (tmpRegActAfiliado != null)
            {
                switch (tcrNombreCampo)
                {
                    case "0":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_codeps_teps = tcrValor;
                        break;

                    case "1":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tpicot_tide = tcrValor;
                        break;

                    case "2":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_idecot_usua = tcrValor;
                        break;

                    case "3":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tipide_tide = tcrValor;
                        break;

                    case "4":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_nroide_usua = tcrValor;
                        break;

                    case "5":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_priape_usua = tcrValor;
                        break;

                    case "6":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_segape_usua = tcrValor;
                        break;

                    case "7":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_prinom_usua = tcrValor;
                        break;

                    case "8":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_segnom_usua = tcrValor;
                        break;

                    case "9":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_fecnac_usua = tcrValor;
                        break;

                    case "10":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_codsex_sexo = tcrValor;
                        break;

                    case "11":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tipcot_tcot = tcrValor;
                        break;

                    case "12":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tipafi_tafi = tcrValor;
                        break;

                    case "13":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_parent_tafi = tcrValor;
                        break;

                    case "14":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_conben_usua = tcrValor;
                        break;

                    case "15":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_coddep_dpto = tcrValor;
                        break;

                    case "16":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_codmun_muni = tcrValor;
                        break;

                    case "17":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_zonres_tzon = tcrValor;
                        break;

                    case "18":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_feceps_usua = tcrValor;
                        break;

                    case "19":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tpidap_tide = tcrValor;
                        break;

                    case "20":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_ideapo_usua = tcrValor;
                        break;

                    case "21":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_codocu_ocup = tcrValor;
                        break;
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgCargarCampoEstructura_MC812: Registros Estructura Resolucion 812 Maestro Contributivo
        /// <summary>
        /// <para>Registros Estructura Resolucion 812 Maestro Contributivo</para>
        /// </summary>
        public bool flgCargarCampoEstructura_MC812(String tcrNombreCampo, String tcrValor)
        {
            tcrValor = String.IsNullOrWhiteSpace(tcrValor) || tcrValor == null ? String.Empty : tcrValor;
            var llgReturn = false;
            #region Campos
            if (tmpRegActAfiliado != null)
            {
                switch (tcrNombreCampo)
                {
                    case "0":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_codeps_teps = tcrValor;
                        break;

                    case "1":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tpicot_tide = tcrValor;
                        break;

                    case "2":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_idecot_usua = tcrValor;
                        break;

                    case "3":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tipide_tide = tcrValor;
                        break;

                    case "4":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_nroide_usua = tcrValor;
                        break;

                    case "5":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_priape_usua = tcrValor;
                        break;

                    case "6":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_segape_usua = tcrValor;
                        break;

                    case "7":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_prinom_usua = tcrValor;
                        break;

                    case "8":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_segnom_usua = tcrValor;
                        break;

                    case "9":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_fecnac_usua = tcrValor;
                        break;

                    case "10":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_codsex_sexo = tcrValor;
                        break;

                    case "11":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tipcot_tcot = tcrValor;
                        break;

                    case "12":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tipafi_tafi = tcrValor;
                        break;

                    case "13":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_parent_tafi = tcrValor;
                        break;

                    case "14":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_conben_usua = tcrValor;
                        break;

                    case "15":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_coddep_dpto = tcrValor;
                        break;

                    case "16":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_codmun_muni = tcrValor;
                        break;

                    case "17":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_zonres_tzon = tcrValor;
                        break;

                    case "18":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_fecsss_usua = tcrValor;
                        break;

                    case "19":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_feceps_usua = tcrValor;
                        break;

                    case "20":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_tpidap_tide = tcrValor;
                        break;

                    case "21":
                        llgReturn = true;
                        tmpRegActAfiliado.Sia_ideapo_usua = tcrValor;
                        break;

                    case "22":
                        llgReturn = true;
                        tmpRegActAfiliado.Sis_codocu_ocup = tcrValor;
                        break;

                    // 23 	Fecha de vinculación con el aportante
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        // Resolucion 2629 y 812 Cargar desde archivo de Microsoft Excel
        #region flgArchivoExcelPlano: Convertir desde Microsoft excel a formato plano
        /// <summary>
        /// <para>Convertir desde Microsoft excel a formato plano</para>
        /// </summary>
        private void flgArchivoExcelPlano(String tcrArchivo)
        {

            Excel.Application lobApp;
            Excel.Workbook lobLibro;

            lobApp = new Excel.Application();
            var luxValue = Type.Missing;//System.Reflection.Missing.Value;

            // abrir el documento
            lobLibro = lobApp.Workbooks.Open(tcrArchivo, luxValue, luxValue,
                                                luxValue, luxValue, luxValue, luxValue, luxValue, luxValue,
                                                luxValue, luxValue, luxValue, luxValue, luxValue, luxValue);

            // abrir el archvo y guardar en ruta temporal del sistema
            gcrPrmNombreArchivoTemporal = System.IO.Path.GetTempPath() + "excelplano-" + Funciones.fnuFechaLlaveIndiceRegistro().ToString().Trim()+".txt";
            gcrPrmCharSeparadorCampos = (",").ToCharArray();
            lobApp.DisplayAlerts = false;
            lobLibro.SaveAs(gcrPrmNombreArchivoTemporal, 6);
            lobLibro.Close(true);
            lobApp.Quit();

            // Cargar como si fuera un plano
            gcrArchivoExternoNombreyRuta = gcrPrmNombreArchivoTemporal;
            flgCargarDesdeArchivoPlano();

        }
        #endregion
        #region flgCargarArchivoExcel: Cargar registros desde Microsoft excel con estructura 2629
        /// <summary>
        /// <para>Cargar registros desde Microsoft excel con estructura 2629</para>
        /// </summary>
        private void flgCargarArchivoExcel(String tcrArchivo)
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
            int lnuContadorLineas = 0;
            int tnuContadorRegCargados = 0;
            String lcrllave1 = String.Empty;
            String lcrllave2 = String.Empty;
            String lcrllave3 = String.Empty;
            String lcrllave4 = String.Empty;
            String lcrllave5 = String.Empty;
            String lcrllave6 = String.Empty;

            for (int lnuFila = 1; lnuFila <= lnuTotalFilas; lnuFila++)
            {
                lnuContadorLineas++;
                if (lnuContadorLineas >= gnuPrmRegistroInicioCargue)
                {

                    tnuContadorRegCargados++;
                    tmpRegActAfiliado = new ModeloCtomaestroafiliadosEx();
                    if (tnuContadorRegCargados == 1)
                    {
                        this.txtG1Sia_codeps_carg.Text = lobRange.Cells[lnuFila, 2].Value.ToString();
                    }
                    #region Campos
                    tmpRegActAfiliado.BoolEstado = true;
                    tmpRegActAfiliado.Estado = "INCLUIDO";
                    tmpRegActAfiliado.Ssp_ideaux_ctou = tnuContadorRegCargados;

                    tmpRegActAfiliado.Sia_codeps_teps = lobRange.Cells[lnuFila, 01].Value != null ? lobRange.Cells[lnuFila, 01].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_tipide_tide = lobRange.Cells[lnuFila, 02].Value != null ? lobRange.Cells[lnuFila, 02].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_nroide_usua = lobRange.Cells[lnuFila, 03].Value != null ? lobRange.Cells[lnuFila, 03].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_priape_usua = lobRange.Cells[lnuFila, 04].Value != null ? lobRange.Cells[lnuFila, 04].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_segape_usua = lobRange.Cells[lnuFila, 05].Value != null ? lobRange.Cells[lnuFila, 05].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_prinom_usua = lobRange.Cells[lnuFila, 06].Value != null ? lobRange.Cells[lnuFila, 06].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_segnom_usua = lobRange.Cells[lnuFila, 07].Value != null ? lobRange.Cells[lnuFila, 07].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_fecnac_usua = lobRange.Cells[lnuFila, 08].Value != null ? lobRange.Cells[lnuFila, 08].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sis_codsex_sexo = lobRange.Cells[lnuFila, 09].Value != null ? lobRange.Cells[lnuFila, 09].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sis_coddep_dpto = lobRange.Cells[lnuFila, 10].Value != null ? lobRange.Cells[lnuFila, 10].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sis_codmun_muni = lobRange.Cells[lnuFila, 11].Value != null ? lobRange.Cells[lnuFila, 11].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sis_zonres_tzon = lobRange.Cells[lnuFila, 12].Value != null ? lobRange.Cells[lnuFila, 12].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_feceps_usua = lobRange.Cells[lnuFila, 13].Value != null ? lobRange.Cells[lnuFila, 13].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_tippob_tpob = lobRange.Cells[lnuFila, 14].Value != null ? lobRange.Cells[lnuFila, 14].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_nivsbn_nsbn = lobRange.Cells[lnuFila, 15].Value != null ? lobRange.Cells[lnuFila, 15].Value.ToString() : String.Empty;
                    tmpRegActAfiliado.Sia_modsub_usua = lobRange.Cells[lnuFila, 16].Value != null ? lobRange.Cells[lnuFila, 16].Value.ToString() : String.Empty;

                    lcrllave1 = tmpRegActAfiliado.Ssp_ideaux_ctou.ToString().Trim() + " ";
                    lcrllave2 = tmpRegActAfiliado.Sia_nroide_usua != null ? tmpRegActAfiliado.Sia_nroide_usua.ToUpper() + " " : String.Empty;
                    lcrllave3 = tmpRegActAfiliado.Sia_priape_usua != null ? tmpRegActAfiliado.Sia_priape_usua.ToUpper() + " " : String.Empty;
                    lcrllave4 = tmpRegActAfiliado.Sia_segape_usua != null ? tmpRegActAfiliado.Sia_segape_usua.ToUpper() + " " : String.Empty;
                    lcrllave5 = tmpRegActAfiliado.Sia_prinom_usua != null ? tmpRegActAfiliado.Sia_prinom_usua.ToUpper() + " " : String.Empty;
                    lcrllave6 = tmpRegActAfiliado.Sia_segnom_usua != null ? tmpRegActAfiliado.Sia_segnom_usua.ToUpper() : String.Empty;

                    tmpRegActAfiliado.LlaveBusqueda = lcrllave1 + lcrllave2 + lcrllave3 + lcrllave4 + lcrllave5 + lcrllave6;
                    #endregion

                    vm.TmpG2ListaBrow.Add(tmpRegActAfiliado);
                }
            }

            this.txtG1Ssp_totreg_carg.Text = tnuContadorRegCargados.ToString();
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
            gcrExportarArchivoNombreyRuta = System.IO.Path.GetTempPath() + "exportarplano.txt";
            if (!string.IsNullOrEmpty(gcrExportarArchivoNombreyRuta))
            {

                llgReturn = true;

                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Exportando datos...", "CENTRO");
                lobDlgAdd.Show();

                var lcrRegcontrol = fcrGenerarRegEncabezadoPlano();
                var lcrPlano = lcrRegcontrol + "\n" + fcrExportarForamtoPlano();

                System.IO.File.WriteAllText(@gcrExportarArchivoNombreyRuta, lcrPlano, Encoding.UTF8);

                lobDlgAdd.Close();
            }
            return llgReturn;
        }
        #endregion
        #region fcrGenerarRegEncabezadoPlano: Generar el registro Encabezado del archivo
        /// <summary>
        /// <para>Generar el registro Encabezado del archivo</para>
        /// </summary>
        public String fcrGenerarRegEncabezadoPlano()
        {
            var lcrNombreArchivo = String.Empty;
            var lcrRegControl = String.Empty;

            if (gcrPrmEstructuraArchivo == "S2629" || gcrPrmEstructuraArchivo == "S812")
            {
                lcrNombreArchivo = "Estructura Maestro Subsidiado Resolución 2629 de 2014" + "\n" +
                                   "----------------------------------------------------------------------" + "\n";

                lcrRegControl = "Codigo EPS,Tipo Id,Identificacion,Primer Apellido,Segundo Apellido, Primer Nommbre, Segundo nombre, Fecha nacimiento,Sexo," +
                                    "Departamento,Municipio,Zona Residencia,Afiliacion a EPS,Grupo Poblacional,Nivel Sisben,Modalidad Subsidio,Nivel error,Notas";
            }
            else
            {
                lcrNombreArchivo = "Estructura Maestro Contributivo Resolución 2629 de 2014" + "\n" +
                                   "----------------------------------------------------------------------" + "\n";

                lcrRegControl = "Codigo EPS,Tipo id Cotizante,Numero id Cotizante,Tipo Id,Identificacion,Primer Apellido,Segundo Apellido,Primer Nommbre," +
                                "Segundo nombre, Fecha nacimiento,Sexo,Tipo cotizante,Tipo Afiliado,Parentesco con cotizante,Condicion beneficiario mayor 18,"+
                                "Departamento,Municipio,Zona Residencia,Fecha afiliación EPS,Tipo aportante,Numero id aportante,Actividad economica,Nivel error,Notas";
            }
            return lcrNombreArchivo + lcrRegControl;
        }
        #endregion
        #region fcrExportarForamtoPlano: Exportar los datos a formato Archivo Plano
        /// <summary>
        /// <para>Exportar los datos a formato Archivo Plano</para>
        /// </summary>
        public String fcrExportarForamtoPlano()
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
                    if (gcrPrmEstructuraArchivo == "S2629" || gcrPrmEstructuraArchivo == "S812") 
                    {
                        // Maestro regimen subsidiado 2629
                        #region Campos
                        lcrTexto1 = lobReg.Sia_codeps_teps.Trim() + "," +
                                    lobReg.Sia_tipide_tide.Trim() + "," +
                                    lobReg.Sia_nroide_usua.Trim() + "," +
                                    lobReg.Sia_priape_usua.Trim() + "," +
                                    lobReg.Sia_segape_usua.Trim() + "," +
                                    lobReg.Sia_prinom_usua.Trim() + "," +
                                    lobReg.Sia_segnom_usua.Trim() + "," +
                                    lobReg.Sia_fecnac_usua.Trim() + "," +
                                    lobReg.Sis_codsex_sexo.Trim() + "," +
                                    lobReg.Sis_coddep_dpto.Trim() + "," +
                                    lobReg.Sis_codmun_muni.Trim() + "," +
                                    lobReg.Sis_zonres_tzon.Trim() + "," +
                                    lobReg.Sia_feceps_usua.Trim() + "," +
                                    lobReg.Sia_tippob_tpob.Trim() + "," +
                                    lobReg.Sia_nivsbn_nsbn.Trim() + "," +
                                    lobReg.Sia_modsub_usua.Trim() + "," +
                                    lobReg.Ssp_niverr_ctou.Trim() + "," +
                                    lobReg.NotaRegistro.Trim();
                        #endregion
                    }
                    else
                    { 
                        // Maestro contributivo 2629
                        #region Campos
                        lcrTexto1 = lobReg.Sia_codeps_teps.Trim() + "," +
                                    lobReg.Sia_tpicot_tide.Trim() + "," +
                                    lobReg.Sia_idecot_usua.Trim() + "," +
                                    lobReg.Sia_tipide_tide.Trim() + "," +
                                    lobReg.Sia_nroide_usua.Trim() + "," +
                                    lobReg.Sia_priape_usua.Trim() + "," +
                                    lobReg.Sia_segape_usua.Trim() + "," +
                                    lobReg.Sia_prinom_usua.Trim() + "," +
                                    lobReg.Sia_segnom_usua.Trim() + "," +
                                    lobReg.Sia_fecnac_usua.Trim() + "," +
                                    lobReg.Sis_codsex_sexo.Trim() + "," +
                                    lobReg.Sia_tipcot_tcot.Trim() + "," +
                                    lobReg.Sia_tipafi_tafi.Trim() + "," +
                                    lobReg.Sia_parent_tafi.Trim() + "," +
                                    lobReg.Sia_conben_usua.Trim() + "," +
                                    lobReg.Sis_coddep_dpto.Trim() + "," +
                                    lobReg.Sis_codmun_muni.Trim() + "," +
                                    lobReg.Sis_zonres_tzon.Trim() + "," +
                                    lobReg.Sia_feceps_usua.Trim() + "," +
                                    lobReg.Sia_tpidap_tide.Trim() + "," +
                                    lobReg.Sia_ideapo_usua.Trim() + "," +
                                    lobReg.Sis_codocu_ocup.Trim() + "," +
                                    lobReg.Ssp_niverr_ctou.Trim() + "," +
                                    lobReg.NotaRegistro.Trim();
                        #endregion
                    }
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
        // Exportar a Excel
        #region fcvExportarForamtoExcel: Exportar a excel opcion desde menu
        private void fcvExportarForamtoExcel(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Desea exportar los datos a Microsoft Excel?", "Galeno Versión 4.0", 
                                                       MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                flgExportarFormatoExcel();
            }
        }
        #endregion
        #region flgExportarFormatoExcel: Exportar datos a archivo excel
        /// <summary>
        /// <para>Exportar datos a archivo excel</para>
        /// </summary>
        private bool flgExportarFormatoExcel()
        {
            flgExportarForamtoPlano();
            //gcrExportarArchivoNombreyRuta
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Abriendo en Microsoft Excel...", "CENTRO");
            lobDlgAdd.Show();

            var llgreturn = true;
            var tmpDatos = (from tmp in vm.TmpG2ListaBrow where tmp.Estado == "INCLUIDO" select tmp);

            Excel.Application   lobApp;
            Excel.Workbook      lobLibroTrabajo;

            lobApp       = new Excel.Application();
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;

            // Cargar todos los campos interpretando todo en formato texto
            object objInfoFormatoCampos = new int[21, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 2 },{ 5, 2 },{ 6, 2 },{ 7, 2 },{ 8, 2 },{ 9, 2 },{ 10, 2 },
                                        { 11, 2 },{ 12, 2 },{ 13, 2},{ 14, 2 },{ 15, 2},{ 16, 2 },{ 17, 2 },{ 18, 2 },{ 19, 2 },{ 20, 2 },{ 21, 2 }};

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8
            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta,65001, 1, Excel.XlTextParsingType.xlDelimited,
                                     Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, true, luxValue, luxValue, luxValue, objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);

            try
            {
                //String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs("MAESTRODATOSEXCEL.XLS", Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

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
                    this.txtErrorCompiler.Visibility = Visibility.Visible;
                }
            }
            gobEnsamblado = null;
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
            gobParam.CodigoEps       = this.txtG1Sia_codeps_carg.Text;
            gobParam.FechaFormato    = "DMY";
            gobParam.CodigoPlantilla = this.txtG1Sis_secreg_siva.Text;
            gobParam.OrigenDatos     = gcrOrigenDatosCargados;
            gobParam.FechaValidacion = Funciones.fdaConvertFecha("DMY", "/", this.txtFechaValidacion.Text); 

            this.lblTituloEtiqueta.Text = "Resultados validación de datos...";

            // Mostrar la Barra de progreso
            DialogProgressBar dlg = new DialogProgressBar();
            dlg.Owner = this;
            int lnuValorInicio = 1;
            dlg.EjecutarHiloDeTrabajo(lnuValorInicio, fcvEjecutarScriptsValidacion);

            // Resultados en validacion
            this.txtG1ValidacionOk.Text      = gnuPrmResumenValidTotalOk.ToString();
            this.txtG1ValidacionErrados.Text = gnuPrmResumenValidTotalErrados.ToString();

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
            var lobRegDx            = new RegistroDuplicado();
            var lobRegDuplic        = new RegistroDuplicado();
            tmpRegDuplicados        = new List<RegistroDuplicado>();
            var lcrMensaje          = "IDENTIFICACION DUPLICADA EN ARCHIVO";
            IRegistroError lobRefIRegistroError = new RefIRegistroError();

            foreach (var lobReg in vm.TmpG2ListaBrow)
            {
                lnuProgreso++;
                lobReg.Estado = "NO-VALIDADO";
                lobReg.NotaRegistro = String.Empty;

                if (lobReg.BoolEstado == true)
                {
                    lnuPorcentaje = Funciones.fnuPorcentaje(lnuProgreso, lnutotalRegistros);

                    String lcrMsg = "Validando datos en la vista {0}%...";
                    lcrMsg = String.Format(lcrMsg, lnuPorcentaje);

                    lobReg.Ssp_niverr_ctou  = "0";
                    lobReg.Ssp_toterr_ctou  = 0;
                    lobReg.Estado           = "VALIDADO-OK";
                    tmpRegActAfiliado       = lobReg;

                    fcvEjecutarScripts(lobRefIRegistroError, lobReg, lobReg.Ssp_ideaux_ctou);

                    // Validar duplicidad 
                    lobRegDx = tmpRegDuplicados.FirstOrDefault(x => x.Identificacion == lobReg.Sia_nroide_usua);

                    if (lobRegDx != null)
                    {
                        lobRefIRegistroError.AddRegistroError("C02E1A", lcrMensaje, lobReg.Ssp_ideaux_ctou, 2, "2. Numero de Identificacion", lobReg.Sia_nroide_usua, "5");
                    }
                    else 
                    {
                        lobRegDx                = new RegistroDuplicado();
                        lobRegDx.Identificacion = lobReg.Sia_nroide_usua;
                        lobRegDx.IdUnico        = lobReg.Cto_idesec_ctou;
                        lobRegDx.Contador++;
                        tmpRegDuplicados.Add(lobRegDx);
                    }
                    // resumen validacion 
                    if (tmpRegActAfiliado.Estado != "VALIDADO-OK")
                    {
                        gnuPrmResumenValidTotalErrados++;
                    }
                    else 
                    {
                        gnuPrmResumenValidTotalOk++;
                    }
                    // Reportar avance del proceso
                    if ((lnuPorcentaje - lnuPorcentajeAux) >= 1 || lnuPorcentaje>=99)
                    {
                        luxWorker.ReportProgress(lnuPorcentaje, lcrMsg);
                        lnuPorcentajeAux = lnuPorcentaje;
                    }
                }
            }
            // si hay registros ok activar el boton guardar
            vm.glgSIS_DatosVerificados = gnuPrmResumenValidTotalOk > 0 ? true : false;
        }
        #endregion
        #region fcvEjecutarScripts: Ejecutar Scrips de validación
        /// <summary>
        /// <para>Ejecutar Scrips de validación</para>
        /// </summary>
        private void fcvEjecutarScripts(IRegistroError tobIRegistroError, ModeloCtomaestroafiliadosEx tobRegistro, int tnuNumeroRegistro)
        {
            fcvEjecutarScriptsCampos(tobIRegistroError, tobRegistro, tnuNumeroRegistro);
        }
        #endregion
        #region fcvEjecutarScriptsCampos: Ejecutar Scrips de validación campos 
        /// <summary>
        /// <para>Ejecutar Scrips de validación campos</para>
        /// </summary>
        private void fcvEjecutarScriptsCampos(IRegistroError tobIRegistroError, ModeloCtomaestroafiliadosEx tobRegistro, int tnuNumeroRegistro)
        {
            #region Campos 
            //--------------------------------------------------
            //- 1. Tipo Identificacion
            //--------------------------------------------------
            if (oAppISia_tipide_tide != null) { oAppISia_tipide_tide.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 2. Numero de Identificacion
            //--------------------------------------------------
            if (oAppISia_nroide_usua != null) { oAppISia_nroide_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 3. Primer Apellido
            //--------------------------------------------------
            if (oAppISia_priape_usua != null) { oAppISia_priape_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 4. Segundo Apellido
            //--------------------------------------------------
            if (oAppISia_segape_usua != null) { oAppISia_segape_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 5. Primer Nombre
            //--------------------------------------------------
            if (oAppISia_prinom_usua != null) { oAppISia_prinom_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 6. Segundo Nombre
            //--------------------------------------------------
            if (oAppISia_segnom_usua != null) { oAppISia_segnom_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 7. Fecha Nacimiento
            //--------------------------------------------------
            if (oAppISia_fecnac_usua != null) { oAppISia_fecnac_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 8. Sexo del Afiliado
            //--------------------------------------------------
            if (oAppISis_codsex_sexo != null) { oAppISis_codsex_sexo.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 9. Codigo DANE Municipio
            //--------------------------------------------------
            if (oAppISis_codmun_muni != null) { oAppISis_codmun_muni.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 10. Codigo DANE Departamento
            //--------------------------------------------------
            if (oAppISis_coddep_dpto != null) { oAppISis_coddep_dpto.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 11. Zona de Residencia
            //--------------------------------------------------
            if (oAppISis_zonres_tzon != null) { oAppISis_zonres_tzon.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 12. Codigo EPS
            //--------------------------------------------------
            if (oAppISia_codeps_teps != null) { oAppISia_codeps_teps.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 13. Grupo Poblacion Especial
            //--------------------------------------------------
            if (oAppISia_tippob_tpob != null) { oAppISia_tippob_tpob.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 14. Nivel Sisben
            //--------------------------------------------------
            if (oAppISia_nivsbn_nsbn != null) { oAppISia_nivsbn_nsbn.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 14. Fecha Afiliacion a la EPS
            //--------------------------------------------------
            if (oAppISia_feceps_usua != null) { oAppISia_feceps_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 16. Modalidad del Subsidio
            //--------------------------------------------------
            if (oAppISia_modsub_usua != null) { oAppISia_modsub_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 17. Tipo cotizante Contributivo
            //--------------------------------------------------
            if (oAppISia_tipcot_tcot != null) { oAppISia_tipcot_tcot.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 18. Tipo afiliado Contributivo
            //--------------------------------------------------
            if (oAppISia_tipafi_tafi != null) { oAppISia_tipafi_tafi.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 19. Relacion parentesco con cotizante
            //--------------------------------------------------
            if (oAppISia_parent_tafi != null) { oAppISia_parent_tafi.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 20. Condicion beneficiario mayor de 18 años
            //--------------------------------------------------
            if (oAppISia_conben_usua != null) { oAppISia_conben_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 21.Fecha afiliacion a seguridad social
            //--------------------------------------------------
            if (oAppISia_fecsss_usua != null) { oAppISia_fecsss_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 22. Tipo Ide Aportante contributivo
            //--------------------------------------------------
            if (oAppISia_tpidap_tide != null) { oAppISia_tpidap_tide.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 23. Numero identificacion aportante contributivo
            //--------------------------------------------------
            if (oAppISia_ideapo_usua != null) { oAppISia_ideapo_usua.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }
            //--------------------------------------------------
            //- 24. Codigo ocupacion o profesion
            //--------------------------------------------------
            if (oAppISis_codocu_ocup != null) { oAppISis_codocu_ocup.EjecutarValidCampo(tobIRegistroError, tobRegistro, tnuNumeroRegistro, gobParam); }

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
                lobRegistro.IdUnicoUsuario  = tmpRegActAfiliado.Cto_idesec_ctou;
                lobRegistro.IdUsuario       = tmpRegActAfiliado.Sia_nroide_usua;
                lobRegistro.PApellido       = tmpRegActAfiliado.Sia_priape_usua;
                lobRegistro.SApellido       = tmpRegActAfiliado.Sia_segape_usua;
                lobRegistro.PNombre         = tmpRegActAfiliado.Sia_prinom_usua;
                lobRegistro.SNombre         = tmpRegActAfiliado.Sia_segnom_usua;
                // llave de busqueda 
                lcrllave1 = tmpRegActAfiliado.Ssp_ideaux_ctou.ToString().Trim() + " ";
                lcrllave2 = tmpRegActAfiliado.Sia_nroide_usua != null ? tmpRegActAfiliado.Sia_nroide_usua.ToUpper() + " " : String.Empty;
                lcrllave3 = tmpRegActAfiliado.Sia_priape_usua != null ? tmpRegActAfiliado.Sia_priape_usua.ToUpper() + " " : String.Empty;
                lcrllave4 = tmpRegActAfiliado.Sia_segape_usua != null ? tmpRegActAfiliado.Sia_segape_usua.ToUpper() + " " : String.Empty;
                lcrllave5 = tmpRegActAfiliado.Sia_prinom_usua != null ? tmpRegActAfiliado.Sia_prinom_usua.ToUpper() + " " : String.Empty;
                lcrllave6 = tmpRegActAfiliado.Sia_segnom_usua != null ? tmpRegActAfiliado.Sia_segnom_usua.ToUpper() : String.Empty;

                lobRegistro.LlaveBusqueda = lcrllave1 + lcrllave2 + lcrllave3 + lcrllave4 + lcrllave5 +
                                            lcrllave6 + " " + tcrTituloCampo.ToUpper() + " " + tcrCodigoError + " " + tcrMensaje;

                // adicionar al temporal de errores
                vm.tmpLogError.Add(lobRegistro);
                gnuSecuencialErrores++;

                var lcrMensaje = tcrTituloCampo.ToUpper() + " : " + tcrMensaje;
                var lobReg = vm.TmpG2ListaBrow.FirstOrDefault(x => x.Ssp_ideaux_ctou == tnuNumeroRegistro);
                lobReg.Ssp_toterr_ctou++;
                lobReg.Estado = lobReg.Estado == "VALIDADO-OK" ? "VALIDADO-ERROR-BAJO" : lobReg.Estado;
                lobReg.NotaRegistro = !String.IsNullOrWhiteSpace(lobReg.NotaRegistro) ? lobReg.NotaRegistro + "/" + lcrMensaje : lcrMensaje;

                if (!String.IsNullOrWhiteSpace(tcrNivelError))
                {
                    if (!String.IsNullOrWhiteSpace(lobReg.Ssp_niverr_ctou))
                    {
                        if (Convert.ToInt32(tcrNivelError) > Convert.ToInt32(lobReg.Ssp_niverr_ctou))
                        {
                            lobReg.Ssp_niverr_ctou = tcrNivelError;
                        }
                    }
                    else 
                    {
                        lobReg.Ssp_niverr_ctou = tcrNivelError;
                    }
                    lobReg.Estado = Convert.ToInt32(tcrNivelError) == 5 ? "VALIDADO-ERROR-ALTO" : lobReg.Estado;
                }
                tmpRegActAfiliado.Estado = lobReg.Estado;
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
                var lobScriptTypes = Compilador.farGetTypesInterface(gobEnsamblado.CompiledAssembly, typeof(IValidadorMS));
                llgReturn = lobScriptTypes != null ? true : false;

                foreach (var lobScriptType in lobScriptTypes)
                {
                    gobRefoAppType = lobScriptType;

                    llgReturn = flgRefAppCamposInstanciaInterface(lobScriptType.Name);
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgRefAppCamposInstanciaInterface: Referencia a validacion de campos
        /// <summary>
        /// <para>Referencia validacion Rango 0 a 29</para>
        /// </summary>
        public static bool flgRefAppCamposInstanciaInterface(String tcrNombreCampo)
        {
            var llgReturn = false;
            #region Lista nombre de campos desde scripts en memos
            if (!String.IsNullOrWhiteSpace(tcrNombreCampo))
            {
                switch (tcrNombreCampo)
                {
                    case "Sia_codeps_teps":
                        llgReturn = true;
                        oAppISia_codeps_teps = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_tipide_tide":
                        llgReturn = true;
                        oAppISia_tipide_tide = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_nroide_usua":
                        llgReturn = true;
                        oAppISia_nroide_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_priape_usua":
                        llgReturn = true;
                        oAppISia_priape_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_segape_usua":
                        llgReturn = true;
                        oAppISia_segape_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_prinom_usua":
                        llgReturn = true;
                        oAppISia_prinom_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_segnom_usua":
                        llgReturn = true;
                        oAppISia_segnom_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_fecnac_usua":
                        llgReturn = true;
                        oAppISia_fecnac_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sis_codsex_sexo":
                        llgReturn = true;
                        oAppISis_codsex_sexo = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_tippob_tpob":
                        llgReturn = true;
                        oAppISia_tippob_tpob = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_nivsbn_nsbn":
                        llgReturn = true;
                        oAppISia_nivsbn_nsbn = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sis_coddep_dpto":
                        llgReturn = true;
                        oAppISis_coddep_dpto = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sis_codmun_muni":
                        llgReturn = true;
                        oAppISis_codmun_muni = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sis_zonres_tzon":
                        llgReturn = true;
                        oAppISis_zonres_tzon = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_feceps_usua":
                        llgReturn = true;
                        oAppISia_feceps_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_modsub_usua":
                        llgReturn = true;
                        oAppISia_modsub_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_tipcot_tcot":
                        llgReturn = true;
                        oAppISia_tipcot_tcot = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_tipafi_tafi":
                        llgReturn = true;
                        oAppISia_tipafi_tafi = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_parent_tafi":
                        llgReturn = true;
                        oAppISia_parent_tafi = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_conben_usua":
                        llgReturn = true;
                        oAppISia_conben_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_fecsss_usua":
                        llgReturn = true;
                        oAppISia_fecsss_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_tpidap_tide":
                        llgReturn = true;
                        oAppISia_tpidap_tide = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sia_ideapo_usua":
                        llgReturn = true;
                        oAppISia_ideapo_usua = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
                        break;

                    case "Sis_codocu_ocup":
                        llgReturn = true;
                        oAppISis_codocu_ocup = (Activator.CreateInstance(gobRefoAppType)) as IValidadorMS;
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
            var lobTemp = ModeloSismadeplavalid.flsListaSismadeplavalid(this.txtG1Sis_secreg_siva.Text);
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
        #region RegistroDuplicado: Estructura Para registros duplicados
        /// <summary>
        /// <para>clase para enviar Parametros a las funciones de validacion Maestro subsidiado 1344 y 812</para>
        /// </summary>
        public class RegistroDuplicado
        {
            #region Campos
            public String IdUnico { get; set; }          // Id unico del registro inicial
            public String Identificacion { get; set; }   // Numero de identificacion
            public int  Contador { get; set; }           // Contador de registros duplicados
            #endregion
        }
        #endregion
        //---------------------------------------------------------------
        // GUARDAR DATOS EN BASE DE DATOS 
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
                    if (String.IsNullOrWhiteSpace(lobRegEx.Sia_nroide_usua))
                    {
                        lobRegEx.NotaRegistro = "- NUMERO DE IDENTIFICACION VACIO ";
                        lobRegEx.BoolEstado = false;
                    }
                    // debe contener minimo los datos principales
                    if (lobRegEx.BoolEstado == true)
                    {
                        if (String.IsNullOrWhiteSpace(lobRegEx.Sia_tipide_tide) || String.IsNullOrWhiteSpace(lobRegEx.Sia_nroide_usua) ||
                            String.IsNullOrWhiteSpace(lobRegEx.Sia_priape_usua) || String.IsNullOrWhiteSpace(lobRegEx.Sia_prinom_usua) ||
                            String.IsNullOrWhiteSpace(lobRegEx.Sia_fecnac_usua) || String.IsNullOrWhiteSpace(lobRegEx.Sis_codsex_sexo))
                        {

                            lobRegEx.NotaRegistro += "- DATOS OBLIGATORIOS SON INCONSISTENTES O NO EXISTE ALGUNO DE ELLOS ";
                            lobRegEx.BoolEstado = false;
                        }
                        else 
                        {
                            if (lobRegEx.Sia_fecnac_usua.Trim().Length != 10)
                            {
                                lobRegEx.NotaRegistro += "- FECHA NACIMIENTO ERRADA ";
                                lobRegEx.BoolEstado = false;
                            }
                            else if (!Funciones.flgValidaFecha("DMY", "/", lobRegEx.Sia_fecnac_usua))
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
            fcvValoresParaActualizarBdatos();

            // guardar datos
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Guardando datos...", "CENTRO");
            lobDlgAdd.Show();

            //MessageBox.Show("aqui voy ");

            // Rescatar llaves y complementos 
            fcvComplementarIdRegistros();

            // si se selecciono el chk Eliminar todos los registros
            if (glgActualizEliminarReg == true)
            {
                // eliminar todos los registros
                flgEliminarRegistrosEnBaseDeDatos();
            }
            //fcvGardarDatosEnBaseDeDatos();
            if (flgGenerarPlanoParaBdatos())
            {
                fcvMySqlCargarArchivoEnBaseDeDatos(gcrExportarArchivoNombreyRuta);
            }

            lobDlgAdd.Close();

            MessageBox.Show("Registros guardados con Éxito!!");
            return llgreturn;
        }
        #endregion
        #region flgEliminarRegistrosEnBaseDeDatos: Eliminar registros en base de datos
        /// <summary>
        /// <para>Eliminar registros del contrato seleccionado en la base de datos</para>
        /// </summary>
        private bool flgEliminarRegistrosEnBaseDeDatos()
        {
            var lobjRegistro = new EFctomaeafiliados();
            var llgReturn = true;
            try
            {
                using (db = new DbAplicacion())
                {
                    // Consulta para eliminar
                    var tmpDatos = from tmp in db.Ctomaeafiliados
                                   where tmp.cto_seccon_cont == gcrActualizIdUnicoContrato
                                   select tmp;

                    foreach (var lobReg in tmpDatos)
                    {
                        db.DeleteObject(lobReg);
                    }
                    if (tmpDatos.Count() > 0)
                    {
                        db.SaveChanges();
                    }
                    // eliminar registros existentes con la misma llave
                    foreach (var lobRegEx in vm.TmpG2ListaBrow)
                    {
                        if (lobRegEx.BoolEstado == true && (lobRegEx.Estado == "VALIDADO-OK" || lobRegEx.Estado == "VALIDADO-ERROR-BAJO"))
                        {
                            lobjRegistro = db.Ctomaeafiliados.FirstOrDefault(p => p.cto_idesec_ctou == lobRegEx.Cto_idesec_ctou);
                            if (lobjRegistro != null)
                            {
                                db.DeleteObject(lobjRegistro);
                            }
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                llgReturn = false;
            }
            return llgReturn;
        }
        #endregion
        #region fcvComplementarIdRegistros: Complementar los registros para actualizar en maestro
        /// <summary>
        /// <para>Complementar los registros para actualizar en maestro</para>
        /// </summary>
        public void fcvComplementarIdRegistros()
        {
            var lnutotalRegistros   = vm.TmpG2ListaBrow.Count;
            var lobRegUsuAtendido   = new EFsiausuarioatend();
            var lobRegUsuAfiliado   = new EFctomaeafiliados();

            using (db = new DbAplicacion())
            {
                // leer el ultimo secuencial generado
                var lobRegGenCod = db.Sysgeneradorcod.FirstOrDefault(p => p.sys_codsec_gcod == "SIA-MAE-USUARIOS-ATENDIDOS");

                // complementar todos los registros
                foreach (var lobRegEx in vm.TmpG2ListaBrow)
                {

                    if (lobRegEx.BoolEstado == true && (lobRegEx.Estado == "VALIDADO-OK" || lobRegEx.Estado == "VALIDADO-ERROR-BAJO"))
                    {
                        // Marcar para adicionar
                        lobRegEx.Sis_estado_imaen = "A";
                        lobRegEx.Sis_estreg_esrg = "1";
                        lobRegEx.Cto_idesec_ctou = String.Empty;

                        var lcrPApe = lobRegEx.Sia_priape_usua.Trim().ToUpper();
                        var lcrSApe = !String.IsNullOrWhiteSpace(lobRegEx.Sia_segape_usua) ? " " + lobRegEx.Sia_segape_usua.Trim().ToUpper() : String.Empty;
                        var lcrPnom = " " + lobRegEx.Sia_prinom_usua.Trim().ToUpper();
                        var lcrSnom = !String.IsNullOrWhiteSpace(lobRegEx.Sia_segnom_usua) ? " " + lobRegEx.Sia_segnom_usua.Trim().ToUpper() : String.Empty;
                        lobRegEx.Sia_nomusu_usua = lcrPApe + lcrSApe + lcrPnom + lcrSnom;

                        //Buscar en maestro de afiliados 
                        lobRegUsuAfiliado = CTOValidarCodigo.fobRegBuscarCtomaeafiliadosIu(lobRegEx.Sia_nroide_usua);
                        if (lobRegUsuAfiliado != null)
                        {
                            lobRegEx.Cto_idesec_ctou = lobRegUsuAfiliado.cto_idesec_ctou.Trim();
                        }
                        else
                        {
                            lobRegUsuAtendido = SIAValidarCodigo.fobRegBuscarIuSiausuarioatend(lobRegEx.Sia_nroide_usua);
                            if (lobRegUsuAtendido != null && !String.IsNullOrWhiteSpace(lobRegUsuAtendido.sia_priape_usua))
                            {
                                lobRegEx.Cto_idesec_ctou = lobRegUsuAtendido.sia_idesec_usua.Trim();
                                // se coloca el mismo Id unico pero se debe agregar el registro al maestro de afiliados de contrato
                            }
                            else
                            {
                                lobRegGenCod.sys_ultsec_gcod++;
                                lobRegEx.Cto_idesec_ctou = fcrGenFormatoSecuencial(lobRegGenCod);
                            }
                        }
                    }
                }
                if (lobRegGenCod != null)
                {
                    db.SaveChanges();
                }
            }
            glgObjetosCargados = true;
            vm.glgSIS_DatosVerificados = true;
        }
        #endregion
        #region fcrGenFormatoSecuencial: Complementa el formato del nuevo secuencial del afiliado
        /// <summary>
        /// <para>Complementa el formato del nuevo secuencial del afiliado</para>
        /// </summary>
        public String fcrGenFormatoSecuencial(EFsysgeneradorcod tobReg)
        {
            string lcrReturn = string.Empty;
            int lnuCharExiste = 0;
            int lnuMaxRelleno = 0;
            try
            {
                lnuCharExiste = tobReg.sys_prefij_gcod.Trim().Length + tobReg.sys_ultsec_gcod.ToString().Trim().Length;
                lnuMaxRelleno = ((int)tobReg.sys_maxsec_gcod - lnuCharExiste);
                if (tobReg.sys_relcer_gcod == "1" && lnuMaxRelleno > 0) // Rellenar con ceros
                {
                    string lcrRelleno = "0";
                    lcrReturn = tobReg.sys_prefij_gcod.Trim() + lcrRelleno.PadLeft(lnuMaxRelleno, '0').Trim() + tobReg.sys_ultsec_gcod.ToString().Trim();
                }
                else
                {
                    lcrReturn = tobReg.sys_prefij_gcod.Trim().ToUpper() + tobReg.sys_ultsec_gcod.ToString().Trim();
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error al generar secuencial registros de afiliados.");
            }
            return lcrReturn;
        }
        #endregion
        #region fcvGardarDatosEnBaseDeDatos: Guardar datos en base de datos
        /// <summary>
        /// <para>Guardar datos en base de datos</para>
        /// </summary>
        public void fcvGardarDatosEnBaseDeDatos()
        {
            var lnutotalRegistros   = vm.TmpG2ListaBrow.Count;
            var lobRegMsAfiliado    = new ModeloCtomaestroafiliados();
            var lobRegUsuAtendido   = new EFsiausuarioatend();
            var lcrNuevoCodigo      = String.Empty;

            foreach (var lobReg in vm.TmpG2ListaBrow)
            {

                if (lobReg.BoolEstado == true && (lobReg.Estado == "VALIDADO-OK" || lobReg.Estado == "VALIDADO-ERROR-BAJO"))
                {
                    //lobReg.Sia_codeps_teps = String.IsNullOrWhiteSpace(this.txtG1Sia_codeps_teps.Text) ? lobReg.Sia_codeps_teps : this.txtG1Sia_codeps_teps.Text;
                    lobRegMsAfiliado = new ModeloCtomaestroafiliados();

                    // Cargar datos en registro
                    #region Valores Variables
                    lobRegMsAfiliado.Cto_idesec_ctou = lobReg.Cto_idesec_ctou;
                    lobRegMsAfiliado.Sia_codeps_teps = gcrActualizIdCodigoEps;
                    lobRegMsAfiliado.Hcl_nrohis_hicl = lobReg.Hcl_nrohis_hicl;
                    lobRegMsAfiliado.Sia_tipide_tide = lobReg.Sia_tipide_tide;
                    lobRegMsAfiliado.Sia_nroide_usua = lobReg.Sia_nroide_usua;
                    lobRegMsAfiliado.Sia_priape_usua = lobReg.Sia_priape_usua;
                    lobRegMsAfiliado.Sia_segape_usua = lobReg.Sia_segape_usua;
                    lobRegMsAfiliado.Sia_prinom_usua = lobReg.Sia_prinom_usua;
                    lobRegMsAfiliado.Sia_segnom_usua = lobReg.Sia_segnom_usua;
                    lobRegMsAfiliado.Sia_fecnac_usua = Funciones.fdaConvertFecha("DMY", "/", lobReg.Sia_fecnac_usua);
                    lobRegMsAfiliado.Sis_codsex_sexo = lobReg.Sis_codsex_sexo;
                    lobRegMsAfiliado.Sia_nomusu_usua = lobReg.Sia_nomusu_usua;
                    lobRegMsAfiliado.Sia_tipusu_regi = gcrActualizRegimenSalud;
                    lobRegMsAfiliado.Sia_tipcot_tcot = lobReg.Sia_tipcot_tcot;
                    lobRegMsAfiliado.Sia_tipafi_tafi = lobReg.Sia_tipafi_tafi;
                    lobRegMsAfiliado.Sia_tippob_tpob = lobReg.Sia_tippob_tpob;
                    lobRegMsAfiliado.Sia_nivsbn_nsbn = lobReg.Sia_nivsbn_nsbn;
                    lobRegMsAfiliado.Sia_nivcon_ncon = lobReg.Sia_nivcon_ncon;
                    lobRegMsAfiliado.Sis_idemun_muni = lobReg.Sis_idemun_muni;
                    lobRegMsAfiliado.Sis_codmun_muni = lobReg.Sis_codmun_muni;
                    lobRegMsAfiliado.Sis_coddep_dpto = lobReg.Sis_coddep_dpto;
                    lobRegMsAfiliado.Sis_zonres_tzon = lobReg.Sis_zonres_tzon;
                    lobRegMsAfiliado.Sia_telres_usua = lobReg.Sia_telres_usua;
                    lobRegMsAfiliado.Sia_dirres_usua = lobReg.Sia_dirres_usua;
                    lobRegMsAfiliado.Sia_correo_usua = lobReg.Sia_correo_usua;
                    lobRegMsAfiliado.Sis_codocu_ocup = lobReg.Sis_codocu_ocup;
                    lobRegMsAfiliado.Sia_feceps_usua = Funciones.fdaConvertFecha("DMY", "/", lobReg.Sia_feceps_usua);
                    lobRegMsAfiliado.Cto_seccon_cont = gcrActualizIdUnicoContrato;
                    lobRegMsAfiliado.Cto_nrocon_cont = gcrActualizNumeroContrato;
                    lobRegMsAfiliado.Sia_tpidap_tide = lobReg.Sia_tpidap_tide;
                    lobRegMsAfiliado.Sia_ideapo_usua = lobReg.Sia_ideapo_usua;
                    lobRegMsAfiliado.Sia_modsub_usua = lobReg.Sia_modsub_usua;
                    lobRegMsAfiliado.Sia_discap_usua = lobReg.Sia_discap_usua;
                    lobRegMsAfiliado.Sia_tipdis_tdis = lobReg.Sia_tipdis_tdis;
                    lobRegMsAfiliado.Sia_edapac_usua = lobReg.Sia_edapac_usua;
                    lobRegMsAfiliado.Sia_codmed_tmed = lobReg.Sia_codmed_tmed;
                    lobRegMsAfiliado.Sia_edaano_usua = lobReg.Sia_edaano_usua;
                    lobRegMsAfiliado.Sia_edames_usua = lobReg.Sia_edames_usua;
                    lobRegMsAfiliado.Sia_edadia_usua = lobReg.Sia_edadia_usua;
                    lobRegMsAfiliado.Sia_codcat_ceat = lobReg.Sia_codcat_ceat;
                    lobRegMsAfiliado.Sys_codusu_usux = lobReg.Sys_codusu_usux;
                    lobRegMsAfiliado.Sia_fecedt_usua = lobReg.Sia_fecedt_usua;
                    lobRegMsAfiliado.Sia_llaveb_usua = lobReg.Sia_llaveb_usua;
                    lobRegMsAfiliado.Sis_estreg_esrg = lobReg.Sis_estreg_esrg;
                    #endregion
                    // guardar datos
                    if (lobReg.Sis_estado_imaen == "A")
                    {
                        lobReg.Cto_idesec_ctou = ModeloCtomaestroafiliados.flgAddRegistro(lobRegMsAfiliado);
                        lobRegMsAfiliado.Cto_idesec_ctou = lobReg.Cto_idesec_ctou;
                    }
                    else if (lobReg.Sis_estado_imaen != "I")
                    {
                        ModeloCtomaestroafiliados.fcvActualizar(lobRegMsAfiliado);
                    }
                }
            }
            glgObjetosCargados = true;
        }
        #endregion
        #region fcvMySqlCargarArchivoEnBaseDeDatos: Cargar Plano en Base de datos MySql
        /// <summary>
        /// <para>Cargar Plano en Base de datos MySql</para>
        /// </summary>
        public void fcvMySqlCargarArchivoEnBaseDeDatos(String tcrArchivoTexto)
        {
            DbAplicacion lobContextdb = new DbAplicacion();
            String lcrStringConn = ((EntityConnection)lobContextdb.Connection).StoreConnection.ConnectionString;
            MySqlConnection lobConn = new MySqlConnection(lcrStringConn);

            MySqlBulkLoader lobBulkLoader = new MySqlBulkLoader(lobConn);
            lobBulkLoader.TableName = "ctomaeafiliados";
            lobBulkLoader.CharacterSet = "latin1";
            lobBulkLoader.FieldTerminator = ",";
            lobBulkLoader.LineTerminator = "\n";
            lobBulkLoader.FileName = tcrArchivoTexto;

            //MessageBox.Show("aqui voy " + tcrArchivoTexto);
            // Ejecutar el proceso
            try
            {
                lobConn.Open();
                // Cargar datos desde archivo
                lobBulkLoader.Load();
                lobConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region flgGenerarPlanoParaBdatos: Generar plano para cargar en base de datos
        /// <summary>
        /// <para>Generar plano para cargar en base de datos</para>
        /// </summary>
        public bool flgGenerarPlanoParaBdatos()
        {
            var llgReturn = false;
            //gcrExportarArchivoNombreyRuta = System.IO.Path.GetTempPath() + "planobasededatos.txt";
            gcrExportarArchivoNombreyRuta = @"c:\GalenoReportes\planobasededatos.txt";
           
            if (!string.IsNullOrEmpty(gcrExportarArchivoNombreyRuta))
            {

                llgReturn = true;
                var lcrPlano = fcrForamtoPlanoCargarBdatos();

                //System.IO.File.WriteAllText(@gcrExportarArchivoNombreyRuta, lcrPlano, Encoding.UTF8);
                System.IO.File.WriteAllText(@gcrExportarArchivoNombreyRuta, lcrPlano, Encoding.GetEncoding("latin1"));
            }
            return llgReturn;
        }
        #endregion
        #region fcrForamtoPlanoCargarBdatos: Formato Registro Archivo Plano para cargar en base de datos
        /// <summary>
        /// <para>Formato Registro Archivo Plano para cargar en base de datos</para>
        /// </summary>
        public String fcrForamtoPlanoCargarBdatos()
        {
            var tmpDatos = (from tmp in vm.TmpG2ListaBrow where tmp.BoolEstado == true select tmp);
            int i = 0;
            int lnuTotalRegistros = tmpDatos.Count();
            String lcrArchivo = String.Empty;
            String lcrTextoRegistro;
            String lcrFechaEdicion = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", DateTime.Today.ToShortDateString(), "YMD", "-");

            if (tmpDatos != null)
            {
                foreach (var lobReg in tmpDatos)
                {
                    if (lobReg.BoolEstado == true && (lobReg.Estado == "VALIDADO-OK" || lobReg.Estado == "VALIDADO-ERROR-BAJO"))
                    {
                        lcrTextoRegistro = String.Empty;
                        i++;
                        lobReg.Sis_idemun_muni = lobReg.Sis_coddep_dpto.Trim() + lobReg.Sis_codmun_muni.Trim();
                        lobReg.Cto_seccon_cont = gcrActualizIdUnicoContrato;
                        lobReg.Cto_nrocon_cont = gcrActualizNumeroContrato;

                        lobReg.Sia_nivcon_ncon = lobReg.Sia_nivcon_ncon != null ? lobReg.Sia_nivcon_ncon.Trim() : "";
                        lobReg.Sia_telres_usua = lobReg.Sia_telres_usua != null ? lobReg.Sia_telres_usua.Trim() : "";
                        lobReg.Sia_dirres_usua = lobReg.Sia_dirres_usua != null ? lobReg.Sia_dirres_usua.Trim() : "";
                        lobReg.Sia_correo_usua = lobReg.Sia_correo_usua != null ? lobReg.Sia_correo_usua.Trim() : "";
                        lobReg.Sis_codocu_ocup = lobReg.Sis_codocu_ocup != null ? lobReg.Sis_codocu_ocup.Trim() : "";
                        lobReg.Hcl_nrohis_hicl = lobReg.Hcl_nrohis_hicl != null ? lobReg.Hcl_nrohis_hicl.Trim() : "";
                        lobReg.Sia_nomusu_usua = lobReg.Sia_nomusu_usua != null ? lobReg.Sia_nomusu_usua.Trim() : "";
                        lobReg.Sia_tipusu_regi = lobReg.Sia_tipusu_regi != null ? lobReg.Sia_tipusu_regi.Trim() : "";
                        lobReg.Sia_tipcot_tcot = lobReg.Sia_tipcot_tcot != null ? lobReg.Sia_tipcot_tcot.Trim() : "";
                        lobReg.Sia_tipafi_tafi = lobReg.Sia_tipafi_tafi != null ? lobReg.Sia_tipafi_tafi.Trim() : "";
                        lobReg.Sia_tpidap_tide = lobReg.Sia_tpidap_tide != null ? lobReg.Sia_tpidap_tide.Trim() : "";
                        lobReg.Sia_ideapo_usua = lobReg.Sia_ideapo_usua != null ? lobReg.Sia_ideapo_usua.Trim() : "";
                        lobReg.Sia_discap_usua = lobReg.Sia_discap_usua != null ? lobReg.Sia_discap_usua.Trim() : "";
                        lobReg.Sia_tipdis_tdis = lobReg.Sia_tipdis_tdis != null ? lobReg.Sia_tipdis_tdis.Trim() : "";
                        lobReg.Sia_valibc_usua = lobReg.Sia_valibc_usua != null ? lobReg.Sia_valibc_usua : "0";
                        lobReg.Sia_codper_pret = lobReg.Sia_codper_pret != null ? lobReg.Sia_codper_pret.Trim() : "6";
                        lobReg.Sia_codmed_tmed = lobReg.Sia_codmed_tmed != null ? lobReg.Sia_codmed_tmed.Trim() : "1";
                        lobReg.Sia_codcat_ceat = lobReg.Sia_codcat_ceat != null ? lobReg.Sia_codcat_ceat.Trim() : "";
                        lobReg.Sys_codusu_usux = lobReg.Sys_codusu_usux != null ? lobReg.Sys_codusu_usux.Trim() : "";
                        lobReg.Sia_fecedt_usua = Funciones.FdaFechaActual();
                        lobReg.Sia_llaveb_usua = lobReg.Sia_llaveb_usua != null ? lobReg.Sia_llaveb_usua.Trim() : "";
                        lobReg.Sis_estreg_esrg = lobReg.Sis_estreg_esrg != null ? lobReg.Sis_estreg_esrg.Trim() : "1";

                        #region Campos
                        lcrTextoRegistro = lobReg.Cto_idesec_ctou.Trim() + "," +
                                    lobReg.Sia_codeps_teps.Trim() + "," +
                                    lobReg.Sia_tipide_tide.Trim() + "," +
                                    lobReg.Sia_nroide_usua.Trim() + "," +
                                    lobReg.Sia_priape_usua.Trim() + "," +
                                    lobReg.Sia_segape_usua.Trim() + "," +
                                    lobReg.Sia_prinom_usua.Trim() + "," +
                                    lobReg.Sia_segnom_usua.Trim() + "," +
                                    Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lobReg.Sia_fecnac_usua.Trim(), "YMD", "-") + "," +
                                    lobReg.Sis_codsex_sexo.Trim() + "," +
                                    lobReg.Sis_coddep_dpto.Trim() + "," +
                                    lobReg.Sis_idemun_muni.Trim() + "," +
                                    lobReg.Sis_codmun_muni.Trim() + "," +
                                    lobReg.Sis_zonres_tzon.Trim() + "," +
                                    Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lobReg.Sia_feceps_usua.Trim(), "YMD", "-") + "," +
                                    lobReg.Sia_tippob_tpob.Trim() + "," +
                                    lobReg.Sia_codper_pret.Trim() + "," +
                                    lobReg.Sia_nivsbn_nsbn.Trim() + "," +
                                    lobReg.Sia_modsub_usua.Trim() + "," +
                                    lobReg.Cto_seccon_cont.Trim() + "," +
                                    lobReg.Cto_nrocon_cont.Trim() + "," +
                                    lobReg.Sia_nivcon_ncon.Trim() + "," +
                                    lobReg.Sia_telres_usua.Trim() + "," +
                                    lobReg.Sia_dirres_usua.Trim() + "," +
                                    lobReg.Sia_correo_usua.Trim() + "," +
                                    lobReg.Sis_codocu_ocup.Trim() + "," +
                                    lobReg.Hcl_nrohis_hicl.Trim() + "," +
                                    lobReg.Sia_nomusu_usua.Trim() + "," +
                                    lobReg.Sia_tipusu_regi.Trim() + "," +
                                    lobReg.Sia_tipcot_tcot.Trim() + "," +
                                    lobReg.Sia_tipafi_tafi.Trim() + "," +
                                    lobReg.Sia_valibc_usua.ToString().Trim() + "," +
                                    lobReg.Sia_tpidap_tide.Trim() + "," +
                                    lobReg.Sia_ideapo_usua.Trim() + "," +
                                    lobReg.Sia_discap_usua.Trim() + "," +
                                    lobReg.Sia_tipdis_tdis.Trim() + "," +
                                    lobReg.Sia_edapac_usua.ToString().Trim() + "," +
                                    lobReg.Sia_codmed_tmed.Trim() + "," +
                                    lobReg.Sia_edaano_usua.ToString().Trim() + "," +
                                    lobReg.Sia_edames_usua.ToString().Trim() + "," +
                                    lobReg.Sia_edadia_usua.ToString().Trim() + "," +
                                    lobReg.Sia_codcat_ceat.Trim() + "," +
                                    lobReg.Sys_codusu_usux.Trim() + "," +
                                    lcrFechaEdicion + "," +
                                    lobReg.Sia_llaveb_usua.Trim() + "," +
                                    lobReg.Sis_estreg_esrg.Trim() ;
                        #endregion
                        if (i != lnuTotalRegistros)
                        {
                            lcrTextoRegistro = lcrTextoRegistro + "\n";
                        }
                        lcrArchivo += lcrTextoRegistro;
                    }
                }
            }
            return lcrArchivo;
        }
        #endregion
        //-------------------------------------------------------
        // fcvSelectCheckBox: Marcar o desmarcar todos los registros
        //-------------------------------------------------------
        #region fcvSelectCheckBox: Marcar o desmarcar todos los registros
        private void fcvSelectCheckBox(object sender, RoutedEventArgs e)
        {
            //this.objDataGrid.IsEnabled = false;

            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Marcando todos los registros...", "CENTRO");
            lobDlgAdd.Show();

            var lobjChk = sender as CheckBox;
            var i = 0;
            var llgControlObj = true;

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
                ModeloCtomaestroafiliadosEx lobjRegistro = (ModeloCtomaestroafiliadosEx)lobjItem;
                if (lobjChk.IsChecked == true)
                {
                    lobjRegistro.BoolEstado = true;
                }
                else
                {
                    lobjRegistro.BoolEstado = false;
                }
            }

            Thread.Sleep(500); // darle tiempo a alguna transaccion AddNew o EditItem
            CollectionViewSource.GetDefaultView(this.objDataGrid.ItemsSource).Refresh();
            lobDlgAdd.Close();
            //this.objDataGrid.IsEnabled = true;
        }
        #endregion
        //-------------------------------------------------------
        // ACCINES PARA DETALLES EN GRILLA
        //-------------------------------------------------------
        #region fcvGrillaMostrarDetalles: Mostrar los detalles del registro de la grilla
        /// <summary>
        /// <para>Mostrar los detalles del registro de la grilla</para>
        /// </summary>
        private void fcvGrillaMostrarDetalles(object sender, RoutedEventArgs e)
        {
            for (var lobVisual = sender as Visual; lobVisual != null; lobVisual = VisualTreeHelper.GetParent(lobVisual) as Visual)
            {
                if (lobVisual is DataGridRow)
                {
                    var lobFila = (DataGridRow)lobVisual;
                    // Seleccionar el registro como activo
                    tmpRegActAfiliado = (ModeloCtomaestroafiliadosEx)lobFila.Item;
                    // Calcular la edad del paciente
                    if (lobFila.DetailsVisibility == Visibility.Collapsed)
                    {
                        if (flgGenerarDatosEdad(tmpRegActAfiliado))
                        {
                            tmpRegActAfiliado = (ModeloCtomaestroafiliadosEx)lobFila.Item;
                        }
                    }
                    // Mostrar la vista detalles para el registro
                    lobFila.DetailsVisibility = lobFila.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
            }
        }
        #endregion
        #region flgGenerarDatosEdad: Genera los datos de edad y edad en formato loargo
        /// <summary>
        /// <para>Genera los datos de edad y edad en formato loargo</para>
        /// </summary>
        public bool flgGenerarDatosEdad(ModeloCtomaestroafiliadosEx tobRegistro)
        {
            var llgValor        = false;
            var lobReg          = vm.TmpG2ListaBrow.FirstOrDefault(x => x.Ssp_ideaux_ctou == tobRegistro.Ssp_ideaux_ctou);
            var lcrSeparador    = "/";
            var lcrFechaHoy     = this.txtFechaValidacion.Text;

            if (Funciones.flgExisteSubCadenaStringEx(tobRegistro.Sia_fecnac_usua, "0123456789" + lcrSeparador))
            {
                var lcrFechaNac = Funciones.fdaConvertFecha(this.txtFechaValidacion.Text, lcrSeparador, tobRegistro.Sia_fecnac_usua).ToShortDateString();
                if (Funciones.flgValidarRangoFecha(lcrFechaNac, lcrFechaHoy))
                {
                    var ldaFechaNac = Funciones.fdaConvertFecha("DMY", "/", lcrFechaNac);
                    var ldaFechaHoy = Funciones.fdaConvertFecha("DMY", "/", lcrFechaHoy);

                    lobReg.Sia_edaano_usua = Funciones.fnuCalcularFormatoAñosMesesDias("AÑOS", ldaFechaNac, ldaFechaHoy);
                    lobReg.Sia_edames_usua = Funciones.fnuCalcularFormatoAñosMesesDias("MESES", ldaFechaNac, ldaFechaHoy);
                    lobReg.Sia_edadia_usua = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechaNac, ldaFechaHoy);
                    lobReg.Sia_edaymd_usua = Funciones.fcrFechaRangoForamtoLargo(ldaFechaNac, ldaFechaHoy);
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

            tmpRegActAfiliado = (ModeloCtomaestroafiliadosEx)lobBoton.DataContext;
            /*
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
            */
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
                tmpRegActAfiliado = (ModeloCtomaestroafiliadosEx)lobBoton.DataContext;

                if (vm.tmpLogError.Count > 0)
                {
                    var lcrNumRegistro = tmpRegActAfiliado.Ssp_ideaux_ctou.ToString().Trim();
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
           
            return llgReturn;
        }
        #endregion
        #region fcvFiltroDataGridDatos: Proceso gestion del filtro en la grilla principal
        /// <summary>
        /// <para>Proceso gestion del filtro en la grilla principal</para>
        /// </summary>
        private void fcvFiltroDataGridDatos(object sender, FilterEventArgs e)
        {
            var lobjObjeto = e.Item as ModeloCtomaestroafiliadosEx;
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
                            if (lobjObjeto.Ssp_ideaux_ctou.Equals(Convert.ToInt32(lcrValor)))
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
    }
}

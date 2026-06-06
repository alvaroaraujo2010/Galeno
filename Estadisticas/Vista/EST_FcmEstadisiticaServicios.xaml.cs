using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Win32;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;
using Sistema.Validacion;
using Estadisticas.Utilidades;
using Excel = Microsoft.Office.Interop.Excel;

namespace Estadisticas.Vista
{
    /// <summary>
    /// Interaction logic for EST_FcmEstadisiticaServicios.xaml
    /// </summary>
    public partial class FcmEstadisiticaServicios : Window, SIS_Interface
    {
        //-----------------------------------------------------------
        // Inicio Formulario
        //-----------------------------------------------------------
        #region Inicio Formulario
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = false;
        public bool llgObjetosCargados = false;
        public bool glgVistaSeleccion = false;
        public bool glgVistaPropiedades = false;
        public String gcrCtrF2TexBox;
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        //-----------------------------------------------------------
        // Temporales
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public List<CrtForms.ListaComboBox> lstTipoInforme;
        public List<TmpGestionItem> lstListaCampos;
        public List<TmpListaSeleccion> lstListaAgrupar;
        public List<TmpListaSeleccion> lstListaCondiciones;
        public List<TmpListaSeleccion> lstListSelFiltrFact = null;

        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        //-----------------------------------------------------------
        // Tempoarles para Resumen
        public ClasseTmpResumen tmpRegActivoResumen = new ClasseTmpResumen();
        public List<ClasseTmpResumen> tmpResumen = null;
        public List<ClasseTmpResumen> tmpAdmResumen = null;
        public DataTable tmpConsulta = null;
        public DataTable tmpAdmisiones = null;
        //-----------------------------------------------------------
        // Referencia Base de datos
        private static DbAplicacion db;
        //-----------------------------------------------------------
        // Vaiables para Compilacion de parametros
        Aplicacion oApp = Aplicacion.Instancia();
        DialogVistaErrores lobDlgLogs = null;
        ControlAddGrupo RefCrtAddGrupo = null;
        ControlAddCondicion RefCrtAddCondicion = null;
        public int gnuContadorvistaArchivos = 0;
        public String gcrExportarArchivoNombre = String.Empty;
        public String gcrExportarArchivoNombreyRuta = String.Empty;
        public String gcrStrinPlantilla = String.Empty;
        //-----------------------------------------------------------
        //- Variables para compilacion  plantillas de consultas
        public static CompilerResults gobEnsamblado = null;
        public static Type gobRefoAppType = null;
        public static IEjecutarConsulta oAppIConsulta = null;
        #endregion

        public FcmEstadisiticaServicios()
        {
            InitializeComponent();

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            llgObjetosCargados = true;
            IniciarComboBox();

            //cmdGuardar.Visibility = Visibility.Hidden;
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvResizePantalla();

            fcvTimerGeneral();
            #region Asignar Manejador de SelectedDateChanged a DatePiker
            this.dpkG1FechaInicial.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1FechaFinal.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion

        }
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
            if (this.IsLoaded)
            {
                if (llgModoEdicionKey == false && llgModoEdicionValid == false)
                {
                    llgModoEdicionValid = true;
                    flgValidacion();
                }
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
        // Eventos Auxiliares
        //-------------------------------------------------
        #region Eventos Auxiliares
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnCerrar_KeyDown(object sender, MouseEventArgs e)
        {
            gdspTimerSistema.Stop();
            this.Close();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            gdspTimerSistema.Stop();
            this.Close();
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
                    case "dpkG1FechaInicial":
                        this.txtG1FechaInicial.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, this.txtG1FechaInicial);
                        break;
                    case "dpkG1FechaFinal":
                        this.txtG1FechaFinal.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, this.txtG1FechaFinal);
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
                            case "txtG1FechaInicial":
                                this.dpkG1FechaInicial.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                            case "txtG1FechaFinal":
                                this.dpkG1FechaFinal.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        // Actualizar Objetos TextBox  y CombBox Relacionados
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
                        case "cboG1TipoInforme":
                            this.txtG1TipoInforme.Text = lstTipoInforme[lobCombo.SelectedIndex].ValorSeleccion;
                            if (this.txtG1TipoInforme.Text != "NA") { fcvCargarParametrosTipoInforme(); }

                            // Activar o desactivar filtro avanzado
                            this.chkFlitroAvanzado.IsEnabled = false;
                            this.chkFlitroAvanzado.IsChecked = false;
                            if (this.txtG1TipoInforme.Text == "RSM01" ||
                                this.txtG1TipoInforme.Text == "INF01" ||
                                this.txtG1TipoInforme.Text == "INF09" ||
                                this.txtG1TipoInforme.Text == "INF10" ||
                                this.txtG1TipoInforme.Text == "INF11" ||
                                this.txtG1TipoInforme.Text == "INF12" ||
                                this.txtG1TipoInforme.Text == "INF13")
                            {
                                this.chkFlitroAvanzado.IsEnabled = true;
                                this.chkFlitroAvanzado.IsChecked = true;
                            }

                            break;

                        case "cboTipoActividad":
                            //this.txtTipoActividad.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            //lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtTipoActividad.Text, ",", lobList.ListaValoresSel) - 1;
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
                /*
                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
                        case "txtTipoFiltro":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboTipoFiltro.SelectedItem;
                            cboTipoFiltro.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            fcvActivarTabs(lcrValor);
                            break;
                    }
                }
                */
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarComboBoxOpcion");
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
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void IniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                // TIPO INFORME
                //-------------------------------------------------
                #region Tipo Filtro
                string lcrG11Seleccion = "NA,RSM01,INF01,INF02,INF03,INF04,INF05," +
                                         "INF06,INF07,INF08,INF09,INF10,INF11,INF12,INF13";
                string lcrG11Descripcion = "Seleccione un informe...," +
                                           "Resumen general por centros de producción," +
                                           "Facturación Mensual por centros de producción," +
                                           "Usuarios Atendidos por grupos de edad Mensual," +
                                           "Produccion por areas de servicios," +
                                           "Listado de hospitalizados por mes," +
                                           "Listado urgencias con observación," +
                                           "Diagnosticos por grupos de edad," +
                                           "Listado usuarios por servicios y fechas," +
                                           "Usuarios asistentes crecimiento y desarrollo," +
                                           "Informe - Servcios facturados," +
                                           "Informe - Oportunidad por empresa," +
                                           "Informe - Indicadores de calidad," +
                                           "Informe - Servcios por centro de producción," +
                                           "Informe - Servicios por Contratos EPS y Clasificación";
                lstTipoInforme = new List<CrtForms.ListaComboBox>();
                lstTipoInforme = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion, "1");
                //- Asignar al control
                this.cboG1TipoInforme.ItemsSource = lstTipoInforme;
                this.cboG1TipoInforme.SelectedIndex = Convert.ToInt32(lstTipoInforme[0].IdIndice);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        //-------------------------------------------------
        // Referencia a ControlAddGrupo/ControlAddCondicion
        //-------------------------------------------------
        #region Referencia al control ControlAddGrupo
        /// <summary>
        /// <para>Tomar la referencia del objeto AddItems</para>
        /// </summary>
        private void crtAgruparLoaded(object sender, RoutedEventArgs e)
        {
            RefCrtAddGrupo = (ControlAddGrupo)sender;
            RefCrtAddGrupo.txtControlAddGrupo.TextChanged += new TextChangedEventHandler(fcvReporteCambiosAddGrupo);
        }
        #endregion
        #region Referencia al control ControlAddCondicion
        /// <summary>
        /// <para>Tomar la referencia del objeto Control AddCondicion</para>
        /// </summary>
        private void crtCondicionLoaded(object sender, RoutedEventArgs e)
        {
            RefCrtAddCondicion = (ControlAddCondicion)sender;
            RefCrtAddCondicion.txtControlAddCondicion.TextChanged += new TextChangedEventHandler(fcvReporteCambiosAddCondicion);
            RefCrtAddCondicion.txtValor.TextChanged += new TextChangedEventHandler(fcvValidarValoresAddCondicion);
            RefCrtAddCondicion.txtIdItemSelect.TextChanged += new TextChangedEventHandler(fcvValidarValoresAddCondicion);
            RefCrtAddCondicion.cmdAddBrowser.Click += new RoutedEventHandler(cmdBrowser);
        }
        #endregion
        #region fcvReporteCambiosAddGrupo: Saber que hay cambios en ControlAddGrupo
        /// <summary>
        /// Se ejecuta cuando hay cambios en los parametros del UserControl ControlAddGrupo
        /// </summary>
        private void fcvReporteCambiosAddGrupo(object sender, TextChangedEventArgs e)
        {
            var lobTextBox = sender as TextBox;
            if (lobTextBox.Text != "NA")
            {
                // Hay cambios
            }
        }
        #endregion
        #region fcvReporteCambiosAddCondicion: Saber que hay cambios en ControlAddCondicion
        /// <summary>
        /// Se ejecuta cuando cambian los parametros del control: ControlAddCondicion
        /// </summary>
        private void fcvReporteCambiosAddCondicion(object sender, TextChangedEventArgs e)
        {
            var lobTextBox = sender as TextBox;
            if (lobTextBox.Text != "NA")
            {
                // Hay cambios
            }
        }
        #endregion
        //-------------------------------------------------
        //  Generar Campos y parametros informes
        //-------------------------------------------------
        #region fcvCargarParametrosTipoInforme: Cargar parametros y campos segun tipo informe
        /// <summary>
        /// <para>Generar lista de campos y parametros agurupar segun tipo informe seleccionado en el combobox</para>
        /// </summary>
        private void fcvCargarParametrosTipoInforme()
        {
            // Generar parametros segun reporte
            fcvGenerarCamposReporte();
            fcvGenerarCamposAgrupar();
            fcvGenerarCamposCondiciones();
        }
        #endregion
        #region fcvGenerarCamposReporte: Generar lista campos para reportes
        /// <summary>
        /// <para>Generar lista campos para reportes</para>
        /// </summary>
        private void fcvGenerarCamposReporte()
        {
            lstListaCampos = new List<TmpGestionItem>();
            var lobTipo = this.txtG1TipoInforme.Text;

            if (lobTipo == "RSM01")
            {
                #region Campos para filtro el reporte
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Fcm_coddig_mant", ItemTitulo = "Codigo Digitación", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                #endregion
            }
            else if (lobTipo == "INF01")
            {
                #region Campos para filtro el reporte
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "facturas" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "facturas" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                #endregion
            }
            else if (lobTipo == "INF02")
            {
                #region Campos para filtro el reporte
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Fcm_coddig_mant", ItemTitulo = "Codigo Digitación", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                #endregion
            }
            else if (lobTipo == "INF03")
            {
                #region Campos para agrupar el reporte
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "CAMP1", ItemTitulo = "Nombre campo 1", ItemTipoDato = "CHAR", ItemTabla = "factura" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "CAMP2", ItemTitulo = "Nombre campo 2", ItemTipoDato = "CHAR", ItemTabla = "factura" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "CAMP3", ItemTitulo = "Nombre campo 3", ItemTipoDato = "CHAR", ItemTabla = "factura" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "CAMP4", ItemTitulo = "Nombre campo 4", ItemTipoDato = "CHAR", ItemTabla = "factura" });
                #endregion
            }
            else if (lobTipo == "INF04")
            {
                #region Campos para agrupar el reporte
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Sia_dixing_tdia", ItemTitulo = "Diagnostico de ingreso", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Sia_dixsal_tdia", ItemTitulo = "Diagnostico de salida", ItemTipoDato = "CHAR", ItemTabla = "egresos" });
                #endregion
            }
            else if (lobTipo == "INF05")
            {
                #region Campos para filtro el reporte
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Sia_dixing_tdia", ItemTitulo = "Diagnostico de ingreso", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Sia_dixsal_tdia", ItemTitulo = "Diagnostico de salida", ItemTipoDato = "CHAR", ItemTabla = "urgencias" });
                #endregion
            }
            else if (lobTipo == "INF06")
            {
                #region Campos para filtro el reporte
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Sia_coddia_tdia", ItemTitulo = "Codigo Diagnostico", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                #endregion
            }
            else if (lobTipo == "INF07")
            {
                #region Campos para filtro el reporte
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Fcm_coddig_mant", ItemTitulo = "Codigo Digitación servicio", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                #endregion
            }
            else if (lobTipo == "INF08")
            {
                #region Campos para filtro el reporte
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Fcm_coddig_mant", ItemTitulo = "Codigo Digitación servicio", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                #endregion
            }

        }
        #endregion
        #region fcvGenerarCamposAgrupar: Generar lista campos para agurpar
        /// <summary>
        /// <para>Generar lista campos para agurpar</para>
        /// </summary>
        private void fcvGenerarCamposAgrupar()
        {
            var lobTipo = this.txtG1TipoInforme.Text;

            RefCrtAddGrupo.lstItemsListaGeneral = lstListaCampos;
            RefCrtAddGrupo.lcrItemValorSelect = "ItemNombre";
            lstListaAgrupar = new List<TmpListaSeleccion>();

            if (lobTipo == "RSM01")
            {
                #region Grupos campos para agrupar el reporte
                //lstListaAgrupar.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                //lstListaAgrupar.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                #endregion
            }
            else if (lobTipo == "INF01")
            {
                #region Grupos campos para agrupar el reporte
                //lstListaAgrupar.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                //lstListaAgrupar.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                #endregion
            }
            else if (lobTipo == "INF02")
            {
                #region Grupos campos para agrupar el reporte
                //lstListaAgrupar.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "CAMP1" });
                //lstListaAgrupar.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "CAMP3" });
                #endregion
            }
            // Generar vista en combobox
            RefCrtAddGrupo.IniciarComboBoxDesdeSelect(lstListaAgrupar, "1");
        }
        #endregion
        #region fcvGenerarCamposCondiciones: Generar lista campos para expresiones
        /// <summary>
        /// <para>Generar lista campos para crear expresiones de filtro</para>
        /// </summary>
        private void fcvGenerarCamposCondiciones()
        {
            var lobTipo = this.txtG1TipoInforme.Text;

            RefCrtAddCondicion.lstItemsListaGeneral = lstListaCampos;
            RefCrtAddCondicion.gcrItemValorSelect = "ItemNombre";
            RefCrtAddCondicion.gcrExpresionEvaluable = String.Empty;
            lstListaCondiciones = new List<TmpListaSeleccion>();

            if (lobTipo == "RSM01")
            {
                #region Grupos campos para agrupar el reporte
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Fcm_coddig_mant" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Fcm_codcpr_cpro" });
                #endregion
            }
            else if (lobTipo == "INF01")
            {
                #region Grupos campos para agrupar el reporte
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                #endregion
            }
            else if (lobTipo == "INF02")
            {
                #region Grupos campos para agrupar el reporte
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Fcm_coddig_mant" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Fcm_codcpr_cpro" });
                #endregion
            }
            else if (lobTipo == "INF03")
            {
                #region Grupos campos para agrupar el reporte
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "CAMP1" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "CAMP3" });
                #endregion
            }
            else if (lobTipo == "INF04")
            {
                #region Grupos campos para agrupar el reporte
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Sia_dixing_tdia" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Sia_dixsal_tdia" });
                #endregion
            }
            else if (lobTipo == "INF05")
            {
                #region Grupos campos para agrupar el reporte
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Sia_dixing_tdia" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Sia_dixsal_tdia" });
                #endregion
            }
            else if (lobTipo == "INF06")
            {
                #region Grupos campos para agrupar el reporte
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Sia_coddia_tdia" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Fcm_codcpr_cpro" });
                #endregion
            }
            else if (lobTipo == "INF07")
            {
                #region Grupos campos para agrupar el reporte
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Fcm_coddig_mant" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Fcm_codcpr_cpro" });
                #endregion
            }
            else if (lobTipo == "INF08")
            {
                #region Grupos campos para agrupar el reporte
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Fcm_coddig_mant" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Fcm_codcpr_cpro" });
                #endregion
            }

            // Generar vista en combobox
            RefCrtAddCondicion.IniciarComboBoxDesdeSelect(lstListaCondiciones, "1");
        }
        #endregion
        //---------------------------------------------------------------
        // EJECUTAR CODIGO FUENTE DESDE PLANTILLA
        //---------------------------------------------------------------
        #region fcvEjecuctarPlantillaInforme: Inicia el proceso de ejecucion desde el boton ejecutar
        private void cmdEjecutar_Click(object sender, RoutedEventArgs e)
        {
            var lcrMsj = "NA";
            //try
            //{
            if (this.txtG1TipoInforme.Text == "RSM01")
            {
                #region Facturacion total por centros de produccion
                if (flsEjecutarConsultaRSM01(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                {
                    flgExportarFormatoExcel();
                    lcrMsj = "OK";
                }
                #endregion
            }
            else if (this.txtG1TipoInforme.Text == "INF01")
            {
                #region Facturacion total por centros de produccion
                if (flsEjecutarConsulta01(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                {
                    flgExportarFormatoExcel();
                    lcrMsj = "OK";
                }
                #endregion
            }
            else if (this.txtG1TipoInforme.Text == "INF02")
            {
                #region Informe general por servicios y grupos de edad
                if (flsEjecutarConsulta02(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                {
                    flgExportarFormatoExcel();
                    lcrMsj = "OK";
                }
                #endregion
            }
            else if (this.txtG1TipoInforme.Text == "INF07")
            {
                #region Listado de Usuarios por servicios y fecha
                if (flsEjecutarConsulta07(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                {
                    flgExportarFormatoExcel();
                    lcrMsj = "OK";
                }
                #endregion
            }
            else if (this.txtG1TipoInforme.Text == "INF09")
            {
                #region Gererar listado facturacion 
                if (flsEjecutarConsulta09(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                {
                    flgExportarFormatoExcel();
                    lcrMsj = "OK";
                }
                #endregion
            }
            else if (this.txtG1TipoInforme.Text == "INF10")
            {
                #region oportunidad por empresa
                if (flsEjecutarConsulta10(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                {
                    flgExportarFormatoExcel();
                    lcrMsj = "OK";
                }
                #endregion
            }
            else if (this.txtG1TipoInforme.Text == "INF11")
            {
                #region Indicadores de calidad
                if (flsEjecutarConsulta11(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                {
                    flgExportarFormatoExcel();
                    lcrMsj = "OK";
                }
                #endregion
            }
            else if (this.txtG1TipoInforme.Text == "INF12")
            {
                #region Servcios por centro de producción
                if (flsEjecutarConsulta12(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                {
                    flgExportarFormatoExcel();
                    lcrMsj = "OK";
                }
                #endregion
            }
            else if (this.txtG1TipoInforme.Text == "INF12")
            {
                #region Servcios por centro de producción
                if (flsEjecutarConsulta12(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                {
                    flgExportarFormatoExcel();
                    lcrMsj = "OK";
                }
                #endregion
            }
            else if (this.txtG1TipoInforme.Text == "INF13")
            {
                #region Servcios por contrato eps y clasificacion
                if (flsEjecutarConsulta13(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                {
                    flgExportarFormatoExcel();
                    lcrMsj = "OK";
                }
                #endregion
            }
            else
            {
                lcrMsj = String.Empty;
                fcvEjecuctarPlantillaInforme();
            }
            if (!String.IsNullOrWhiteSpace(lcrMsj))
            {
                lcrMsj = lcrMsj == "OK" ? "Proceso finalizado con Exito!" : "No se generó datos!";
                MessageBox.Show(lcrMsj);
            }
            //}
            //catch (Exception ex)
            //{
            //    Funciones.fcvVistaErroresEjecucion(ref ex, "Estadistica de servicios: CmdEjecutar");
            //}

        }
        #endregion
        #region fcvEjecuctarPlantillaInforme: Inicia el proceso de ejecucion del informe compilado
        /// <summary>
        /// <para>Inicia el proceso de ejecucion del informe compilado</para>
        /// </summary>
        private void fcvEjecuctarPlantillaInforme()
        {
            //String lcrCodigoFuente = System.IO.File.ReadAllText(@"C:\Users\JOSE\Desktop\estadisticas.cs");
            //String lcrCodigoFuente = System.IO.File.ReadAllText(@"C:\Users\familia\Desktop\estadisticas.cs");
            try
            {
                String lcrCodigoFuente = String.Empty;
                var lobReg = ESTValidarCodigo.fobRegBuscarEstplaninformesEx(this.txtG1TipoInforme.Text, "FCM");
                if (lobReg == null) { return; }

                lcrCodigoFuente = lobReg.est_script_esin;
                var larListaDll = new List<String>();
                larListaDll.Add("System.dll");
                larListaDll.Add("System.Data.Entity.dll");
                larListaDll.Add("System.IO.dll");
                larListaDll.Add("System.Xaml.dll");
                larListaDll.Add("System.Linq.dll");
                larListaDll.Add("Datos.dll");
                larListaDll.Add("System.Core.dll");
                larListaDll.Add("WindowsBase.dll");

                if (!string.IsNullOrWhiteSpace(RefCrtAddCondicion.gcrExpresionEvaluable))
                {
                    lcrCodigoFuente = lcrCodigoFuente.Replace("//<>//", " && (" + RefCrtAddCondicion.gcrExpresionEvaluable + ")");
                }

                gobEnsamblado = Compilador.fobCompilarEnsamblado("C#", lcrCodigoFuente, larListaDll);

                if (flgCargarInstanciaInterface())
                {
                    if (oAppIConsulta != null)
                    {
                        DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                        lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
                        lobDlgAdd.Show();

                        tmpResumen = oAppIConsulta.flsEjecutarConsulta(Convert.ToDateTime(this.txtG1FechaInicial.Text), Convert.ToDateTime(this.txtG1FechaFinal.Text));

                        if (tmpResumen != null)
                        {
                            lobDlgAdd.Close();
                            flgExportarFormatoExcel();
                            MessageBox.Show("Proceso finalizado con Exito!!");
                        }
                        else
                        {
                            lobDlgAdd.Close();
                            MessageBox.Show("No se genero datos!!");
                        }
                    }
                }
                else
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
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "VistaModelo Error Metodo: fcvEjecuctarPlantillaInforme");
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
                var lobScriptTypes = Compilador.farGetTypesInterface(gobEnsamblado.CompiledAssembly, typeof(IEjecutarConsulta));

                llgReturn = lobScriptTypes != null ? true : false;
                gobRefoAppType = lobScriptTypes.FirstOrDefault();
                oAppIConsulta = (Activator.CreateInstance(gobRefoAppType)) as IEjecutarConsulta;
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        //--------------------------------------------------
        // Exportar a Excel
        //--------------------------------------------------
        #region flgExportarFormatoExcel: Exportar datos a archivo excel
        /// <summary>
        /// <para>Exportar datos a archivo excel</para>
        /// </summary>
        private bool flgExportarFormatoExcel()
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Exportando datos a Microsoft Excel...", "CENTRO");
            lobDlgAdd.Show();

            var llgreturn = true;

            Excel.Application lobApp;
            Excel.Workbook lobLibroTrabajo;
            Excel.Worksheet lobHoja;

            lobApp = new Excel.Application();
            lobLibroTrabajo = lobApp.Workbooks.Add();
            lobHoja = (Excel.Worksheet)lobLibroTrabajo.Worksheets.get_Item(1);

            // Menu de Opciones
            if (this.txtG1TipoInforme.Text == "RSM01")
            {
                flgRsm01_ExcelProduccionMensual(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF01")
            {
                flgInf01_ExcelProduccionMensual(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF02")
            {
                flgInf02_ExcelServiciosPorGruposDeEdad();
            }
            else if (this.txtG1TipoInforme.Text == "INF03")
            {
                // aqui va el otro
            }
            else if (this.txtG1TipoInforme.Text == "INF04")
            {
                flgInf04_ExcelHospitalizadosMensual(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF05")
            {
                flgInf05_ExcelObservacionesMensual(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF06")
            {
                flgInf06_ExceldiagnosticosPorGruposDeEdad(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF07")
            {
                flgInf07_ExcelUsuariosPorServicios();
            }
            else if (this.txtG1TipoInforme.Text == "INF08")
            {
                flgInf08_ExcelControlCrecimDesarrollo(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF09")
            {
                flgInf09_ExcelServiciosFacturados();
            }
            else if (this.txtG1TipoInforme.Text == "INF10")
            {
                flgInf10_ExcelOportunidadEmpresa();
            }
            else if (this.txtG1TipoInforme.Text == "INF11")
            {
                flgInf11_ExcelIndicadoresCalidad();
            }
            else if (this.txtG1TipoInforme.Text == "INF12")
            {
                flgInf12_ExcelFacturacionCentroProd();
            }
            else if (this.txtG1TipoInforme.Text == "INF13")
            {
                FlgInf13_ExcelFacturacionContratoEpsClasifi(ref lobApp, ref lobHoja);
            }

            lobDlgAdd.Close();

            //lobLibroTrabajo.SaveAs(@gcrExportarArchivoNombreyRuta, Excel.XlFileFormat.xlWorkbookNormal);

            lobLibroTrabajo.Close(true);
            lobApp.Quit();

            return llgreturn;
        }
        #endregion
        // Informes
        #region flgRsm01_ExcelProduccionMensual: Informe General por centro de producción
        /// <summary>
        /// <para>Informe General por centro de producción mensual</para>
        /// </summary>
        private bool flgRsm01_ExcelProduccionMensual(ref Excel.Application tobApp, ref Excel.Worksheet tobHoja)
        {
            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            #region Gestion Excel
            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;

            // Cargar los dos primeros campos en formato texto los demas en numericos
            object objInfoFormatoCampos = new int[18, 2] {{ 1, 2 },{ 2, 2 },{ 3, 1 }, { 4, 1 },{ 5, 1 },{ 6, 1 },
                                                          { 7, 1 },{ 8, 1 },{ 9, 1 },{ 10, 1 },{ 11, 1 },{ 12, 1 },
                                                          { 13, 1 },{ 14, 1 },{ 15, 1 },{ 16, 1 },{ 17, 1 },{ 18, 1 }};

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8

            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                      Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, "|", objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);
            #endregion

            try
            {
                // Poner estilo al titulo
                #region Poner estilo al titulo
                lobApp.get_Range("A2:D2").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Recorrer la hoja para resaltar los titulos
                var lobHoja = (Excel.Worksheet)lobLibroTrabajo.Worksheets.get_Item(1);
                // rango de filas uasadas
                var lnuRangoFilas = (lobHoja.UsedRange).Rows.Count;
                lobHoja.Cells[1, 2].ColumnWidth = 60; // Cambiar el ancho de la columna

                #endregion
                #region Recorrer todo el archivo
                var i = 3;
                for (i = 3; i < lnuRangoFilas; i++)
                {
                    // Titulo valor total
                    #region Titulo valor total
                    if ((lobHoja.Cells[i, 9] as Excel.Range).Value2 != null)
                    {
                        var lcrValor = (lobHoja.Cells[i, 9] as Excel.Range).Value2.ToString();
                        if (lcrValor == "VALOR.TOTAL")
                        {
                            // resaltar los titulos
                            lobApp.get_Range("A" + i.ToString().Trim() + ":I" + i.ToString().Trim()).Select();
                            lobApp.Selection.AutoFormat(3, true, true, false, true, true, false);
                        }
                    }
                    #endregion
                    // Resaltar cada centro de produccion
                    #region Titulo valor total
                    if ((lobHoja.Cells[i, 10] as Excel.Range).Value2 != null)
                    {
                        var lcrValor = (lobHoja.Cells[i, 10] as Excel.Range).Value2.ToString();
                        if (lcrValor == "XXXX")
                        {
                            lobHoja.Cells[i, 10] = String.Empty; // quitar la marca
                            // resaltar los titulos
                            lobApp.get_Range("A" + i.ToString().Trim() + ":I" + i.ToString().Trim()).Select();
                            //lobApp.Selection.AutoFormat(3, true, true, false, true, true, false);
                            lobApp.Selection.Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                            //lobApp.Selection.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        }
                    }
                    #endregion
                }
                #endregion
                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(gcrExportarArchivoNombre + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);
                // Mostrar Excel
                lobApp.get_Range("A1:B1").Select(); // mover el puntero al principio
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;

        }
        #endregion
        #region flgInf01_ExcelProduccionMensual: Informe por centro de producción
        /// <summary>
        /// <para>Informe por centro de producción mensual</para>
        /// </summary>
        private bool flgInf01_ExcelProduccionMensual(ref Excel.Application tobApp, ref Excel.Worksheet tobHoja)
        {
            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            #region Gestion Excel
            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;

            // Cargar los dos primeros campos en formato texto los demas en numericos
            object objInfoFormatoCampos = new int[13, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 1 },{ 5, 1 },{ 6, 1 },
                                                          { 7, 1 },{ 8, 1 },{ 9, 1 },{ 10, 1 },{ 11, 1 },{ 12, 1 },{ 13, 1 }};

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8

            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                      Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, "|", objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);
            #endregion

            try
            {
                // Poner estilo al titulo
                #region Poner estilo al titulo
                lobApp.get_Range("A2:F2").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(gcrExportarArchivoNombre + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);

                // Recorrer la hoja para resaltar los titulos
                var lobHoja = (Excel.Worksheet)lobLibroTrabajo.Worksheets.get_Item(1);
                // rango de filas uasadas
                var lnuRangoFilas = (lobHoja.UsedRange).Rows.Count;
                #endregion
                #region Recorrer todo el archivo
                var i = 3;
                for (i = 3; i < lnuRangoFilas; i++)
                {
                    // grupo areas de servicios
                    if ((lobHoja.Cells[i, 11] as Excel.Range).Value2 != null)
                    {
                        var lcrValor = (lobHoja.Cells[i, 13] as Excel.Range).Value2.ToString();
                        if (lcrValor == "TOTAL GENERAL")
                        {
                            // resaltar los titulos
                            lobApp.get_Range("A" + i.ToString().Trim() + ":M" + i.ToString().Trim()).Select();
                            lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);
                        }
                    }
                }
                #endregion
                // Mostrar Excel
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;

        }
        #endregion
        #region flgInf02_ExcelServiciosPorGruposDeEdad: Informe cantidad servicios por grupos edad
        /// <summary>
        /// <para>Cantidad servicios facturados agrupados por rangos de edad en años</para>
        /// </summary>
        private bool flgInf02_ExcelServiciosPorGruposDeEdad()
        {
            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;

            // Cargar los dos primeros campos en formato texto los demas en numericos
            object objInfoFormatoCampos = new int[17, 2] {{ 1, 2 },{ 2, 1 },{ 3, 1 }, { 4, 1 },{ 5, 1 },{ 6, 1 },{ 7, 1 },{ 8, 1 },{ 9, 1 },{ 10, 1 },
                                        { 11, 1 },{ 12, 1 },{ 13, 1 },{ 14, 1 },{ 15, 1 },{ 16, 1 },{ 17, 1 }};

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8

            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                     Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, "|", objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);

            try
            {
                // Poner estilo al titulo
                lobApp.get_Range("A2:E2").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(gcrExportarArchivoNombre + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;

                // Recorrer la hoja para resaltar los titulos
                var lobHoja = (Excel.Worksheet)lobLibroTrabajo.Worksheets.get_Item(1);
                // rango de filas uasadas
                var lnuRangoFilas = (lobHoja.UsedRange).Rows.Count;

                var i = 3;
                for (i = 3; i < lnuRangoFilas; i++)
                {
                    if ((lobHoja.Cells[i, 17] as Excel.Range).Value2 != null)
                    {
                        var lcrValor = (lobHoja.Cells[i, 17] as Excel.Range).Value2.ToString();
                        if (lcrValor == "TOTAL GENERAL")
                        {
                            // resaltar los titulos
                            lobApp.get_Range("A" + i.ToString().Trim() + ":Q" + i.ToString().Trim()).Select();
                            lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;

            #region informe viejo
            /*
            var llgreturn = true;
            int i = 2;

            // poner formato texto a la hoja
            var lobCells = (Excel.Range)tobHoja.Cells;
            lobCells.NumberFormat = "@";

            // Encabezado del informe
            #region Encabezado del informe
            tobHoja.Cells[1, 2] = "SERVICIOS POR GRUPO DE EDAD";
            tobHoja.Cells[2, 2] = this.txtG1FechaInicial.Text;
            tobHoja.Cells[2, 3] = this.txtG1FechaFinal.Text;
            tobHoja.Cells[3, 2] = "TOTAL REGISTROS: " + tmpResumen.Count().ToString().Trim();
            // Titulos
            tobHoja.Cells[7, 1] = "CODIGIO";
            tobHoja.Cells[7, 2] = "SERVICIO";
            tobHoja.Cells[7, 3] = "0 AÑOS MASCULINO";
            tobHoja.Cells[7, 4] = "0 AÑOS FEMENINO";
            tobHoja.Cells[7, 5] = "1 a 4 AÑOS MASCULINO";
            tobHoja.Cells[7, 6] = "1 a 4 AÑOS FEMENINO";
            tobHoja.Cells[7, 7] = "5 a 14 AÑOS MASCULINO";
            tobHoja.Cells[7, 8] = "5 a 14 AÑOS FEMENINO";
            tobHoja.Cells[7, 9] = "15 a 44 AÑOS MASCULINO";
            tobHoja.Cells[7, 10] = "15 a 44 AÑOS FEMENINO";
            tobHoja.Cells[7, 11] = "45 a 64 AÑOS MASCULINO";
            tobHoja.Cells[7, 12] = "45 a 64 AÑOS FEMENINO";
            tobHoja.Cells[7, 13] = "MAS DE 65 AÑOS MASCULINO";
            tobHoja.Cells[7, 14] = "MAS DE 65 AÑOS FEMENINO";
            tobHoja.Cells[7, 15] = "TOTAL MASCULINO";
            tobHoja.Cells[7, 16] = "TOTAL FEMENINO";
            tobHoja.Cells[7, 17] = "TOTAL GENERAL";

            // poner formato fuente a los titulos
            //var lobTitulos = (Excel.Range)lobHoja.get_Range("A7:J7");
            tobApp.get_Range("A7:Q7").Select();
            tobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

            #endregion

            //Recorrer el temporal y rellenado hoja de trabajo
            i = 8;
            foreach (var lobReg in tmpResumen)
            {
                #region Campos
                tobHoja.Cells[i, 1] = lobReg.Texto1.Trim(); // Codigo servicio
                tobHoja.Cells[i, 2] = lobReg.Texto2.Trim(); // Nombre servicio
                tobHoja.Cells[i, 3] = lobReg.Grupo1;
                tobHoja.Cells[i, 4] = lobReg.Grupo2;
                tobHoja.Cells[i, 5] = lobReg.Grupo3;
                tobHoja.Cells[i, 6] = lobReg.Grupo4;
                tobHoja.Cells[i, 7] = lobReg.Grupo5;
                tobHoja.Cells[i, 8] = lobReg.Grupo6;
                tobHoja.Cells[i, 9] = lobReg.Grupo7;
                tobHoja.Cells[i, 10] = lobReg.Grupo8;
                tobHoja.Cells[i, 11] = lobReg.Grupo9;
                tobHoja.Cells[i, 12] = lobReg.Grupo10;
                tobHoja.Cells[i, 13] = lobReg.Grupo11;
                tobHoja.Cells[i, 14] = lobReg.Grupo12;
                tobHoja.Cells[i, 15] = lobReg.Grupo13;
                tobHoja.Cells[i, 16] = lobReg.Grupo14;
                tobHoja.Cells[i, 17] = lobReg.Grupo15;
                #endregion
                i++;
            }

            return llgreturn;
            */
            #endregion

        }
        #endregion
        #region flgInf04_ExcelHospitalizadosMensual: Informe hospitalizados mensual
        /// <summary>
        /// <para>Informe lista hospitalizados mensual</para>
        /// </summary>
        private bool flgInf04_ExcelHospitalizadosMensual(ref Excel.Application tobApp, ref Excel.Worksheet tobHoja)
        {
            var llgreturn = true;
            int i = 2;

            // poner formato texto a la hoja
            var lobCells = (Excel.Range)tobHoja.Cells;
            lobCells.NumberFormat = "@";

            // Encabezado del informe
            #region Encabezado del informe
            tobHoja.Cells[1, 2] = "HOSPITALIZADOS MENSUAL";
            tobHoja.Cells[2, 2] = this.txtG1FechaInicial.Text;
            tobHoja.Cells[2, 3] = this.txtG1FechaFinal.Text;
            tobHoja.Cells[3, 2] = "TOTAL REGISTROS: " + tmpResumen.Count().ToString().Trim();
            // Titulos
            tobHoja.Cells[7, 1] = "Contrato";
            tobHoja.Cells[7, 2] = "Código EPS";
            tobHoja.Cells[7, 3] = "Nombre EPS";
            tobHoja.Cells[7, 4] = "TIPO ID";
            tobHoja.Cells[7, 5] = "IDENTIFICACION";
            tobHoja.Cells[7, 6] = "PRIMER APELLIDO";
            tobHoja.Cells[7, 7] = "SEGUNDO APELLIDO";
            tobHoja.Cells[7, 8] = "PRIMER NOMBRE";
            tobHoja.Cells[7, 9] = "SEGUNDO NOMNRE";
            tobHoja.Cells[7, 10] = "FECHA NACIMIENTO";
            tobHoja.Cells[7, 11] = "SEXO";
            tobHoja.Cells[7, 12] = "EDAD EN AÑOS";
            tobHoja.Cells[7, 13] = "EDAD EN MESES";
            tobHoja.Cells[7, 14] = "EDAD EN DIAS";
            tobHoja.Cells[7, 15] = "FRECHA ADMISION";
            tobHoja.Cells[7, 16] = "HORA ADMISION";
            tobHoja.Cells[7, 17] = "PACIENTE EMBARAZADA";
            tobHoja.Cells[7, 18] = "DIAG.INGRESO";
            tobHoja.Cells[7, 19] = "FECHA HOSPITALIZACION";
            tobHoja.Cells[7, 20] = "HORA HOSPITALIZACION";
            tobHoja.Cells[7, 21] = "FECHA EGRESO";
            tobHoja.Cells[7, 22] = "HORA EGRESO";
            tobHoja.Cells[7, 23] = "DIAG.SALIDA";
            tobHoja.Cells[7, 24] = "TOTAL.DIAS.HOSPIT";
            tobHoja.Cells[7, 25] = "TOTAL.HORAS.HOSPIT";

            // poner formato fuente a los titulos
            //var lobTitulos = (Excel.Range)lobHoja.get_Range("A7:J7");
            tobApp.get_Range("A7:Y7").Select();
            tobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

            #endregion

            //Recorrer el temporal y rellenado hoja de trabajo
            i = 8;
            foreach (var lobReg in tmpResumen)
            {
                #region Campos
                tobHoja.Cells[i, 1] = lobReg.Texto1.Trim(); // Descripcion contrato
                tobHoja.Cells[i, 2] = lobReg.Texto2.Trim(); // Codigo Eps
                tobHoja.Cells[i, 3] = lobReg.Texto3.Trim(); // Nombre de la Eps
                tobHoja.Cells[i, 4] = lobReg.Texto4.Trim();
                tobHoja.Cells[i, 5] = lobReg.Texto5.Trim();
                tobHoja.Cells[i, 6] = lobReg.Texto6.Trim();
                tobHoja.Cells[i, 7] = lobReg.Texto7.Trim();
                tobHoja.Cells[i, 8] = lobReg.Texto8.Trim();
                tobHoja.Cells[i, 9] = lobReg.Texto9.Trim();
                tobHoja.Cells[i, 10] = lobReg.Fecha1.ToShortDateString();
                tobHoja.Cells[i, 11] = lobReg.Texto11.Trim();
                tobHoja.Cells[i, 12] = lobReg.Valor1;
                tobHoja.Cells[i, 13] = lobReg.Valor2;
                tobHoja.Cells[i, 14] = lobReg.Valor3;
                tobHoja.Cells[i, 15] = lobReg.Fecha2.ToShortDateString();
                tobHoja.Cells[i, 16] = lobReg.Decimal1;
                tobHoja.Cells[i, 17] = lobReg.Texto12.Trim() == "1" ? "SI" : "NO";
                tobHoja.Cells[i, 18] = lobReg.Texto13.Trim();
                tobHoja.Cells[i, 19] = lobReg.Fecha3.ToShortDateString();
                tobHoja.Cells[i, 20] = lobReg.Decimal2;
                tobHoja.Cells[i, 21] = lobReg.Fecha4.ToShortDateString();
                tobHoja.Cells[i, 22] = lobReg.Decimal3;
                tobHoja.Cells[i, 23] = lobReg.Texto14.Trim();
                tobHoja.Cells[i, 24] = lobReg.Valor4;
                tobHoja.Cells[i, 25] = lobReg.Valor5;
                #endregion
                i++;
            }

            return llgreturn;
        }
        #endregion
        #region flgInf05_ExcelObservacionesMensual: Informe observacions mensual
        /// <summary>
        /// <para>Informe observacions mensual</para>
        /// </summary>
        private bool flgInf05_ExcelObservacionesMensual(ref Excel.Application tobApp, ref Excel.Worksheet tobHoja)
        {
            var llgreturn = true;
            int i = 2;

            // poner formato texto a la hoja
            var lobCells = (Excel.Range)tobHoja.Cells;
            lobCells.NumberFormat = "@";

            // Encabezado del informe
            #region Encabezado del informe
            tobHoja.Cells[1, 2] = "OBSERVACIONES MENSUAL";
            tobHoja.Cells[2, 2] = this.txtG1FechaInicial.Text;
            tobHoja.Cells[2, 3] = this.txtG1FechaFinal.Text;
            tobHoja.Cells[3, 2] = "TOTAL REGISTROS: " + tmpResumen.Count().ToString().Trim();
            // Titulos
            tobHoja.Cells[7, 1] = "Contrato";
            tobHoja.Cells[7, 2] = "Código EPS";
            tobHoja.Cells[7, 3] = "Nombre EPS";
            tobHoja.Cells[7, 4] = "TIPO ID";
            tobHoja.Cells[7, 5] = "IDENTIFICACION";
            tobHoja.Cells[7, 6] = "PRIMER APELLIDO";
            tobHoja.Cells[7, 7] = "SEGUNDO APELLIDO";
            tobHoja.Cells[7, 8] = "PRIMER NOMBRE";
            tobHoja.Cells[7, 9] = "SEGUNDO NOMBRE";
            tobHoja.Cells[7, 10] = "FECHA NACIMIENTO";
            tobHoja.Cells[7, 11] = "SEXO";
            tobHoja.Cells[7, 12] = "EDAD EN AÑOS";
            tobHoja.Cells[7, 13] = "EDAD EN MESES";
            tobHoja.Cells[7, 14] = "EDAD EN DIAS";
            tobHoja.Cells[7, 15] = "FECHA ING.OBSERVACION";
            tobHoja.Cells[7, 16] = "HORA ING.OBSERVACION";
            tobHoja.Cells[7, 17] = "PACIENTE EMBARAZADA";
            tobHoja.Cells[7, 18] = "DESTINO SALIDA";
            tobHoja.Cells[7, 19] = "COD.PROF.ATIENDE";
            tobHoja.Cells[7, 20] = "PROFESIONAL QUE ATIENDE";
            tobHoja.Cells[7, 21] = "COD.PROF.SALIDA";
            tobHoja.Cells[7, 22] = "PROFESIONAL AUTORIZA SALIDA";
            tobHoja.Cells[7, 23] = "DIAG.INGRESO";
            tobHoja.Cells[7, 24] = "NOMBRE.DIAG.INGRESO";
            tobHoja.Cells[7, 25] = "DIAG.SALIDA";
            tobHoja.Cells[7, 26] = "DIAG.MUERTE";
            tobHoja.Cells[7, 27] = "REGIMEN SALUD";

            // poner formato fuente a los titulos
            //var lobTitulos = (Excel.Range)lobHoja.get_Range("A7:J7");
            tobApp.get_Range("A7:Z7").Select();
            tobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

            #endregion

            //Recorrer el temporal y rellenado hoja de trabajo
            i = 8;
            foreach (var lobReg in tmpResumen)
            {
                #region Campos
                tobHoja.Cells[i, 1] = lobReg.Texto1.Trim(); // Descripcion contrato
                tobHoja.Cells[i, 2] = lobReg.Texto2.Trim(); // Codigo Eps
                tobHoja.Cells[i, 3] = lobReg.Texto3.Trim(); // Nombre de la Eps
                tobHoja.Cells[i, 4] = lobReg.Texto4.Trim();
                tobHoja.Cells[i, 5] = lobReg.Texto5.Trim();
                tobHoja.Cells[i, 6] = lobReg.Texto6.Trim();
                tobHoja.Cells[i, 7] = lobReg.Texto7.Trim();
                tobHoja.Cells[i, 8] = lobReg.Texto8.Trim();
                tobHoja.Cells[i, 9] = lobReg.Texto9.Trim();
                tobHoja.Cells[i, 10] = lobReg.Fecha1.ToShortDateString();
                tobHoja.Cells[i, 11] = lobReg.Texto10.Trim();
                tobHoja.Cells[i, 12] = lobReg.Valor1;
                tobHoja.Cells[i, 13] = lobReg.Valor2;
                tobHoja.Cells[i, 14] = lobReg.Valor3;
                tobHoja.Cells[i, 15] = lobReg.Fecha2.ToShortDateString(); // FECHA ING OBSERVACION
                tobHoja.Cells[i, 16] = lobReg.Decimal1;
                tobHoja.Cells[i, 17] = lobReg.Texto11.Trim() == "1" ? "SI" : "NO"; // EMBARAZADA
                tobHoja.Cells[i, 18] = lobReg.Texto12.Trim() == "1" ? "ALTA (Salida)" : lobReg.Texto12.Trim() == "2" ? "REMISIÓN" : "HOSPITALIZACIÓN"; // 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion
                tobHoja.Cells[i, 19] = lobReg.Texto13 != null ? lobReg.Texto13.Trim() : ""; // codigo profesional que atiende
                tobHoja.Cells[i, 20] = lobReg.Texto14 != null ? lobReg.Texto14.Trim() : "";  // nombre profesional que atiende
                tobHoja.Cells[i, 21] = lobReg.Texto15 != null ? lobReg.Texto15.Trim() : ""; // codigo profesional autoriza salida
                tobHoja.Cells[i, 22] = lobReg.Texto16 != null ? lobReg.Texto16.Trim() : ""; // nombre profesional autoriza salida
                tobHoja.Cells[i, 23] = lobReg.Texto17 != null ? lobReg.Texto17.Trim() : ""; // Diagnostico ingreso 
                tobHoja.Cells[i, 24] = lobReg.Texto18 != null ? lobReg.Texto18.Trim() : ""; // Nombre Diagnostico ingreso 
                tobHoja.Cells[i, 25] = lobReg.Texto19 != null ? lobReg.Texto19.Trim() : ""; // Diagnostico de salida 
                tobHoja.Cells[i, 26] = lobReg.Texto20 != null ? lobReg.Texto20.Trim() : ""; // Diagnostico de de muerte 
                tobHoja.Cells[i, 27] = lobReg.Texto21 != null ? lobReg.Texto21.Trim() : ""; // Regimen salud
                #endregion
                i++;
            }
            return llgreturn;
        }
        #endregion
        #region flgInf06_ExceldiagnosticosPorGruposDeEdad: Informe diagnosticos por grupos edad
        /// <summary>
        /// <para>diagnosticos agrupados por rangos de edad en años</para>
        /// </summary>
        private bool flgInf06_ExceldiagnosticosPorGruposDeEdad(ref Excel.Application tobApp, ref Excel.Worksheet tobHoja)
        {
            var llgreturn = true;
            int i = 2;

            // poner formato texto a la hoja
            var lobCells = (Excel.Range)tobHoja.Cells;
            lobCells.NumberFormat = "@";

            // Encabezado del informe
            #region Encabezado del informe
            tobHoja.Cells[1, 2] = "DIANGNOSTICOS POR GRUPO DE EDAD";
            tobHoja.Cells[2, 2] = this.txtG1FechaInicial.Text;
            tobHoja.Cells[2, 3] = this.txtG1FechaFinal.Text;
            tobHoja.Cells[3, 2] = "TOTAL REGISTROS: " + tmpResumen.Count().ToString().Trim();
            // Titulos
            tobHoja.Cells[7, 1] = "CODIGO-CIE10";
            tobHoja.Cells[7, 2] = "DIAGNOSTICO";
            tobHoja.Cells[7, 3] = "0 AÑOS MASCULINO";
            tobHoja.Cells[7, 4] = "0 AÑOS FEMENINO";
            tobHoja.Cells[7, 5] = "1 a 4 AÑOS MASCULINO";
            tobHoja.Cells[7, 6] = "1 a 4 AÑOS FEMENINO";
            tobHoja.Cells[7, 7] = "5 a 14 AÑOS MASCULINO";
            tobHoja.Cells[7, 8] = "5 a 14 AÑOS FEMENINO";
            tobHoja.Cells[7, 9] = "15 a 44 AÑOS MASCULINO";
            tobHoja.Cells[7, 10] = "15 a 44 AÑOS FEMENINO";
            tobHoja.Cells[7, 11] = "45 a 64 AÑOS MASCULINO";
            tobHoja.Cells[7, 12] = "45 a 64 AÑOS FEMENINO";
            tobHoja.Cells[7, 13] = "MAS DE 65 AÑOS MASCULINO";
            tobHoja.Cells[7, 14] = "MAS DE 65 AÑOS FEMENINO";
            tobHoja.Cells[7, 15] = "TOTAL MASCULINO";
            tobHoja.Cells[7, 16] = "TOTAL FEMENINO";
            tobHoja.Cells[7, 17] = "TOTAL GENERAL";

            // poner formato fuente a los titulos
            //var lobTitulos = (Excel.Range)lobHoja.get_Range("A7:J7");
            tobApp.get_Range("A7:Q7").Select();
            tobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

            #endregion

            //Recorrer el temporal y rellenado hoja de trabajo
            i = 8;
            foreach (var lobReg in tmpResumen)
            {
                #region Campos
                tobHoja.Cells[i, 1] = lobReg.Texto1.Trim(); // Codigo servicio
                tobHoja.Cells[i, 2] = lobReg.Texto2.Trim(); // Nombre servicio
                tobHoja.Cells[i, 3] = lobReg.Grupo1;
                tobHoja.Cells[i, 4] = lobReg.Grupo2;
                tobHoja.Cells[i, 5] = lobReg.Grupo3;
                tobHoja.Cells[i, 6] = lobReg.Grupo4;
                tobHoja.Cells[i, 7] = lobReg.Grupo5;
                tobHoja.Cells[i, 8] = lobReg.Grupo6;
                tobHoja.Cells[i, 9] = lobReg.Grupo7;
                tobHoja.Cells[i, 10] = lobReg.Grupo8;
                tobHoja.Cells[i, 11] = lobReg.Grupo9;
                tobHoja.Cells[i, 12] = lobReg.Grupo10;
                tobHoja.Cells[i, 13] = lobReg.Grupo11;
                tobHoja.Cells[i, 14] = lobReg.Grupo12;
                tobHoja.Cells[i, 15] = lobReg.Grupo13;
                tobHoja.Cells[i, 16] = lobReg.Grupo14;
                tobHoja.Cells[i, 17] = lobReg.Grupo15;
                #endregion
                i++;
            }

            return llgreturn;
        }
        #endregion
        #region flgInf07_ExcelUsuariosPorServicios: Usuarios por servicios 
        /// <summary>
        /// <para>Usuarios por servicios</para>
        /// </summary>
        private bool flgInf07_ExcelUsuariosPorServicios()
        {
            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;
            //gcrExportarArchivoNombreyRuta = lcrMisDocs +@"\INFORME-SERVICIOS.XLS";

            // Cargar todos los campos interpretando todo en formato texto
            object objInfoFormatoCampos = new int[37, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 2 },{ 5, 2 },{ 6, 2 },{ 7, 2 },{ 8, 2 },{ 9, 2 },{ 10, 2 },
                                        { 11, 2 },{ 12, 2 },{ 13, 1},{ 14, 1},{ 15, 1},{ 16, 2 },{ 17, 2 },{ 18, 2 },{ 19, 2 },{ 20, 2 },{ 21, 2 },
                                        { 22, 2 },{ 23, 2 },{ 24, 2 },{ 25, 2},{ 26, 2 },{ 27, 1},{ 28, 1 },{ 29, 1 },{ 30, 1 },{ 31, 1 },{ 32, 1 },
                                        { 33, 1 },{ 34, 1 },{ 35, 1 },{ 36, 2 },{ 37, 2 }};

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8

            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                     Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, "|", objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);

            try
            {
                // Poner estilo al titulo
                lobApp.get_Range("A6:AL6").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(gcrExportarArchivoNombre + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;
        }
        #endregion
        #region flgInf08_ExcelControlCrecimDesarrollo: Usuarios que asisten a control de crecimiento 
        /// <summary>
        /// <para>Usuarios que asisten a controles de crecimiento y desarrollo</para>
        /// </summary>
        private bool flgInf08_ExcelControlCrecimDesarrollo(ref Excel.Application tobApp, ref Excel.Worksheet tobHoja)
        {
            var llgreturn = true;
            int i = 2;

            // poner formato texto a la hoja
            var lobCells = (Excel.Range)tobHoja.Cells;
            lobCells.NumberFormat = "@";

            // Encabezado del informe
            #region Encabezado del informe
            tobHoja.Cells[1, 2] = "CONTROLES DE CRECIMIENTO Y DESARROLLO";
            tobHoja.Cells[2, 2] = this.txtG1FechaInicial.Text;
            tobHoja.Cells[2, 3] = this.txtG1FechaFinal.Text;
            tobHoja.Cells[3, 2] = "TOTAL REGISTROS: " + tmpResumen.Count().ToString().Trim();
            // Titulos
            tobHoja.Cells[7, 1] = "ID UNICO";
            tobHoja.Cells[7, 2] = "TIPO";
            tobHoja.Cells[7, 3] = "IDENTIFICACIÓN";
            tobHoja.Cells[7, 4] = "P.APELLIDO";
            tobHoja.Cells[7, 5] = "S.APELLIDO";
            tobHoja.Cells[7, 6] = "P.NOMBRE";
            tobHoja.Cells[7, 7] = "S.NOMBRE";
            tobHoja.Cells[7, 8] = "FECHA NACIMIENTO";
            tobHoja.Cells[7, 9] = "SEXO";
            tobHoja.Cells[7, 10] = "EDAD EN AÑOS";
            tobHoja.Cells[7, 11] = "EDAD EN MESES";
            tobHoja.Cells[7, 12] = "EDAD EN DIAS";
            tobHoja.Cells[7, 13] = "REGIMEN SALUD";
            tobHoja.Cells[7, 14] = "CONTRATO";
            tobHoja.Cells[7, 15] = "CODIGO EPS";
            tobHoja.Cells[7, 16] = "NOMBRE EPS";
            tobHoja.Cells[7, 17] = "CODIGO SERVICIO";
            tobHoja.Cells[7, 18] = "NOMBRE SERVICIO";
            tobHoja.Cells[7, 19] = "FECHA SERVICIO";
            tobHoja.Cells[7, 20] = "COD.CENT.PRODUCCIÓN";
            tobHoja.Cells[7, 21] = "NOMBRE.CENT.PRODUCCIÓN";

            // poner formato fuente a los titulos
            //var lobTitulos = (Excel.Range)lobHoja.get_Range("A7:U7");
            tobApp.get_Range("A7:U7").Select();
            tobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

            #endregion

            //Recorrer el temporal y rellenado hoja de trabajo
            i = 8;
            foreach (var lobReg in tmpResumen)
            {
                #region Campos
                tobHoja.Cells[i, 1] = lobReg.Texto1.Trim();     // ID UNICO
                tobHoja.Cells[i, 2] = lobReg.Texto2.Trim();     // TIPO IDE
                tobHoja.Cells[i, 3] = lobReg.Texto3.Trim();     // IDENTIFICACIÓN
                tobHoja.Cells[i, 4] = lobReg.Texto4.Trim();     // P.APELLIDO
                tobHoja.Cells[i, 5] = lobReg.Texto5 != null ? lobReg.Texto5.Trim() : String.Empty;  // SEGUNDO APELLIDO
                tobHoja.Cells[i, 6] = lobReg.Texto6.Trim();     // P.NOMBRE
                tobHoja.Cells[i, 7] = lobReg.Texto7 != null ? lobReg.Texto7.Trim() : String.Empty;  // SEGUNDO NOMBRE
                tobHoja.Cells[i, 8] = lobReg.Fecha1.ToShortDateString(); // FECHA NACIMIENTO
                tobHoja.Cells[i, 9] = lobReg.Texto8.Trim();     // SEXO
                tobHoja.Cells[i, 10] = lobReg.Valor1;           // EDAD EN AÑOS
                tobHoja.Cells[i, 11] = lobReg.Valor2;           // EDAD EN MESES
                tobHoja.Cells[i, 12] = lobReg.Valor3;           // EDAD EN DIAS
                tobHoja.Cells[i, 13] = lobReg.Texto10 != null ? lobReg.Texto10.Trim() : String.Empty;  // DESCRIPCION REGIMEN SALUD
                tobHoja.Cells[i, 14] = lobReg.Texto12.Trim();   // NUMERO CONTRATO
                tobHoja.Cells[i, 15] = lobReg.Texto13.Trim();   // CODIGO EPS
                tobHoja.Cells[i, 16] = lobReg.Texto14 != null ? lobReg.Texto14.Trim() : String.Empty;  // NOMBRE EPS
                tobHoja.Cells[i, 17] = lobReg.Texto15.Trim();   // CODIGO SERVICIO
                tobHoja.Cells[i, 18] = lobReg.Texto17.Trim();   // NOMBRE SERVICIO
                tobHoja.Cells[i, 19] = lobReg.Fecha2.ToShortDateString();  // FECHA SERVICIO
                tobHoja.Cells[i, 20] = lobReg.Texto18.Trim();   // CODIGO CENTRO PRODUCCIÓN
                tobHoja.Cells[i, 21] = lobReg.Texto19 != null ? lobReg.Texto19.Trim() : String.Empty;  // NOMBRE.CENT.PRODUCCIÓN 
                #endregion
                i++;
            }

            return llgreturn;
        }
        #endregion
        #region flgInf09_ExcelServiciosFacturados: Servicios facturados
        /// <summary>
        /// <para>Servicios facturados</para>
        /// </summary>
        private bool flgInf09_ExcelServiciosFacturados()
        {
            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;
            //gcrExportarArchivoNombreyRuta = lcrMisDocs +@"\INFORME-SERVICIOS.XLS";

            // Cargar todos los campos interpretando todo en formato texto
            object objInfoFormatoCampos = new int[11, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 2 },{ 5, 2 },
                                                          { 6, 2 },{ 7, 2 },{ 8, 2 },{ 9, 1 },{ 10, 2 },{ 11, 1 }};

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8

            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                     Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, "|", objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);

            try
            {
                // Poner estilo al titulo
                lobApp.get_Range("A4:K4").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(gcrExportarArchivoNombre + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;
        }
        #endregion
        #region flgInf10_ExcelOportunidadEmpresa: Oportunidad por empresa
        /// <summary>
        /// <para>Oportunidad por empresa</para>
        /// </summary>
        private bool flgInf10_ExcelOportunidadEmpresa()
        {
            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;
            //gcrExportarArchivoNombreyRuta = lcrMisDocs +@"\INFORME-SERVICIOS.XLS";
            // Cargar todos los campos interpretando todo en formato texto
            object objInfoFormatoCampos = new int[13, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 2 },{ 5, 2 },
                                                          { 6, 2 },{ 7, 2 },{ 8, 2 },{ 9, 2 },{ 10, 2 },
                                                          { 11, 2 },{ 12, 2 },{ 13, 2 }};

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8

            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                     Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, "|", objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);

            try
            {
                // Poner estilo al titulo
                lobApp.get_Range("A4:M4").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(gcrExportarArchivoNombre + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;
        }
        #endregion
        #region flgInf11_ExcelIndicadoresCalidad: Indicadores de calidad
        /// <summary>
        /// <para>Indicadores de calidad</para>
        /// </summary>
        private bool flgInf11_ExcelIndicadoresCalidad()
        {
            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;
            //gcrExportarArchivoNombreyRuta = lcrMisDocs +@"\INFORME-SERVICIOS.XLS";

            // Cargar todos los campos interpretando todo en formato texto
            object objInfoFormatoCampos = new int[8, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 2 },{ 5, 2 },
                                                         { 6, 2 },{ 7, 1 },{ 8, 2 }};

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8

            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                     Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, "|", objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);

            try
            {
                // Poner estilo al titulo
                lobApp.get_Range("A4:H4").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(gcrExportarArchivoNombre + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;
        }
        #endregion
        #region flgInf12_ExcelFacturacionCentroProd: Facturación por centro de producción
        /// <summary>
        /// <para>Facturación por centro de producción</para>
        /// </summary>
        private bool flgInf12_ExcelFacturacionCentroProd()
        {
            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;
            //gcrExportarArchivoNombreyRuta = lcrMisDocs +@"\INFORME-SERVICIOS.XLS";

            // Cargar todos los campos interpretando todo en formato texto
            object objInfoFormatoCampos = new int[11, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 2 },{ 5, 2 },
                                                          { 6, 2 },{ 7, 2 },{ 8, 2 },{ 9, 2 },{ 10, 1 },{ 11, 1 }};

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8

            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                     Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, "|", objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);

            try
            {
                // Poner estilo al titulo
                lobApp.get_Range("A4:K4").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(gcrExportarArchivoNombre + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;
        }
        #endregion
        #region FlgInf13_ExcelFacturacionContratoEpsClasifi: Informe por Contrato Eps y clasificacion Servicios
        /// <summary>
        /// <para>Informe por Contrato Eps y clasificacion Servicios</para>
        /// </summary>
        private bool FlgInf13_ExcelFacturacionContratoEpsClasifi(ref Excel.Application tobApp, ref Excel.Worksheet tobHoja)
        {
            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            #region Gestion Excel
            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;

            // Cargar los dos primeros campos en formato texto los demas en numericos
            object objInfoFormatoCampos = new int[5, 2] { { 1, 2 }, { 2, 2 }, { 3, 1 }, { 4, 1 }, { 5, 1 } };

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8

            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                      Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, "|", objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);
            #endregion

            try
            {
                // Poner estilo al titulo
                #region Poner estilo al titulo
                lobApp.get_Range("A2:D2").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Recorrer la hoja para resaltar los titulos
                var lobHoja = (Excel.Worksheet)lobLibroTrabajo.Worksheets.get_Item(1);
                // rango de filas uasadas
                var lnuRangoFilas = (lobHoja.UsedRange).Rows.Count;
                lobHoja.Cells[1, 2].ColumnWidth = 60; // Cambiar el ancho de la columna

                #endregion
                #region Recorrer todo el archivo
                var i = 3;
                for (i = 3; i <= lnuRangoFilas; i++)
                {
                    // Titulo - Grupo Contrato y Eps
                    #region Titulo valor total
                    if ((lobHoja.Cells[i, 6] as Excel.Range).Value2 != null)
                    {
                        var lcrValor = (lobHoja.Cells[i, 6] as Excel.Range).Value2.ToString();
                        if (lcrValor == "XXGRUPO")
                        {
                            // resaltar los titulos
                            lobApp.get_Range("A" + i.ToString().Trim() + ":E" + i.ToString().Trim()).Select();
                            lobApp.Selection.AutoFormat(3, true, true, false, true, true, false);
                        }
                    }
                    #endregion
                    // Resaltar Categoria de serivcios
                    #region Titulo valor total
                    if ((lobHoja.Cells[i, 6] as Excel.Range).Value2 != null)
                    {
                        var lcrValor = (lobHoja.Cells[i, 6] as Excel.Range).Value2.ToString();
                        if (lcrValor == "XXSUBGRUPO")
                        {
                            // resaltar los titulos
                            lobApp.get_Range("A" + i.ToString().Trim() + ":E" + i.ToString().Trim()).Select();
                            //lobApp.Selection.AutoFormat(3, true, true, false, true, true, false);
                            lobApp.Selection.Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                            //lobApp.Selection.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        }
                    }
                    #endregion
                    lobHoja.Cells[i, 6] = String.Empty; // quitar la marca

                }
                #endregion
                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(gcrExportarArchivoNombre + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);
                // Mostrar Excel
                lobApp.get_Range("A1:B1").Select(); // mover el puntero al principio
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;

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
                case "Cto_seccon_cont": // Id Contratos
                    RefCrtAddCondicion.txtValor.Text = tcrCodigo;
                    break;

                case "Sia_codeps_teps": // Codigo Eps
                    RefCrtAddCondicion.txtValor.Text = tcrCodigo;
                    break;

                case "Hcl_tiptur_hctu": //Tipo Turno antencion medica
                    RefCrtAddCondicion.txtValor.Text = tcrCodigo;
                    break;

                case "Sia_codare_aser": // Area de servicio
                    RefCrtAddCondicion.txtValor.Text = tcrCodigo;
                    break;

                case "Fcm_codcpr_cpro": // Centro de produccion
                    RefCrtAddCondicion.txtValor.Text = tcrCodigo;
                    break;

                case "Sia_codpfa_prof": // Profesional que atiende
                    RefCrtAddCondicion.txtValor.Text = tcrCodigo;
                    break;

                case "Sia_coddia_tdia": // Codigo del diagnostico Tabla CIE 10
                    RefCrtAddCondicion.txtValor.Text = tcrCodigo;
                    break;

                case "Odn_coddia_oddx": // Codigo del diagnostico odontologia
                    RefCrtAddCondicion.txtValor.Text = tcrCodigo;
                    break;

                case "Fcm_coddig_mant": // Codigo digitacion servicio
                    RefCrtAddCondicion.txtValor.Text = tcrCodigo;
                    break;
            }
        }
        #endregion
        #region Browser para las vistas de seleccion
        #region Seleccion desde boton Browser 
        private void cmdBrowser(object sender, RoutedEventArgs e)
        {

            switch (RefCrtAddCondicion.txtIdItemSelect.Text)
            {
                case "Cto_seccon_cont": // Id Contratos
                    Cto_seccon_cont_Browser();
                    break;

                case "Sia_codeps_teps": // Codigo Eps
                    Sia_codeps_teps_Browser();
                    break;

                case "Hcl_tiptur_hctu": //Tipo Turno antencion medica
                    Hcl_tiptur_hctu_Browser();
                    break;

                case "Sia_codare_aser": // Area de servicio
                    Sia_codare_aser_Browser();
                    break;

                case "Fcm_codcpr_cpro": // Centro de produccion
                    Fcm_codcpr_cpro_Browser();
                    break;

                case "Sia_codpfa_prof": // Profesional que atiende
                    Sia_codpfa_prof_Browser();
                    break;

                case "Sia_coddia_tdia": // Codigo del diagnostico Tabla CIE 10
                    Sia_coddia_tdia_Browser();
                    break;

                case "Odn_coddia_oddx": // Codigo del diagnostico odontologia
                    Odn_coddia_oddx_Browser();
                    break;

                case "Fcm_coddig_mant": // Codigo digitacion servicio
                    //RefCrtAddCondicion.txtValor.Text = tcrCodigo;
                    break;
            }
        }
        #endregion
        #region CTO_SECCON_CONT : Maestro contratos con  EPS o aseguradores
        private void Cto_seccon_cont_Browser()
        {
            Browser01 frbro = new Browser01("CTO", "CTOMAESCONTRATO", "", "Maestro contratos con  EPS o aseguradores...");
            gcrCtrF2TexBox = "Cto_seccon_cont";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODEPS_TEPS : Lista de EPS o seguradores
        private void Sia_codeps_teps_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIATABLAEPS", "", "Lista de EPS o seguradores...");
            gcrCtrF2TexBox = "Sia_codeps_teps";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region HCL_TIPTUR_HCTU : Tipo registro turnos diarios prestacion de servicios medicos
        private void Hcl_tiptur_hctu_Browser()
        {
            Browser01 frbro = new Browser01("HCL", "HCLTIPOREGTURNO", "", "Tipo registro turnos diarios prestacion de servicios medicos...");
            gcrCtrF2TexBox = "Hcl_tiptur_hctu";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODARE_ASER : Areas prestacion de servicios
        private void Sia_codare_aser_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAAREAPRESERVI", "", "Areas prestacion de servicios...");
            gcrCtrF2TexBox = "Sia_codare_aser";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_CODCPR_CPRO : Centros de produccion asistenciales
        private void Fcm_codcpr_cpro_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMCENPRODUCCIO", "", "Centros de produccion asistenciales...");
            gcrCtrF2TexBox = "Fcm_codcpr_cpro";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODPFA_PROF : Profesionales que prestan servicios
        private void Sia_codpfa_prof_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
            gcrCtrF2TexBox = "Sia_codpfa_prof";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region ODN_CODDIA_ODDX : Diagnosticos odontologicos
        private void Odn_coddia_oddx_Browser()
        {
            Browser01 frbro = new Browser01("ODN", "ODNDIAGNOSTICOS", "", "Diagnosticos odontologicos...");
            gcrCtrF2TexBox = "Odn_coddia_oddx";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODDIA_TDIA : Tabla de diagnosticos CIE - 10
        private void Sia_coddia_tdia_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIADIAGNOSTICOS", "", "Tabla de diagnosticos CIE - 10...");
            gcrCtrF2TexBox = "Sia_coddia_tdia";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                llgModoEdicionKey = true;
                var lobTextBox = sender as TextBox;
                fcrValidacion(lobTextBox.Name);
                llgModoEdicionKey = false;
                llgModoEdicionValid = false;
            }
        }
        #endregion
        #region flgValidacion: Valida todos los datos antes de guardar
        /// <summary>
        /// Valida todos los datos del registro maestro antes de guardar
        /// </summary>
        public bool flgValidacion()
        {
            var lnuCont = 0;
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1FechaInicial"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1FechaFinal"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1TipoInforme"))) { lnuCont++; }

            this.cmdEjecutar.IsEnabled = lnuCont > 0 ? false : true;

            return lnuCont == 0 ? true : false;
        }
        #endregion
        #region fcrValidacion: Validacion parametros generales del modulo
        /// <summary>
        /// Validacion parametros generales del modulo
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        /// <param name="tcrNombrePropiedad">Nombre propiedad o campo seleccionado para realizar validación</param>
        /// </summary>
        public String fcrValidacion(String tcrNombrePropiedad)
        {

            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            try
            {

                switch (tcrNombrePropiedad)
                {
                    case "txtG1FechaInicial":
                        #region Validación
                        lcrNombreCampo = "Fecha inicio periodo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E01";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtG1FechaInicial.Text, lcrNombreCampo);

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtG1FechaFinal.Text, lcrNombreCampo)))
                            {
                                if (!Funciones.flgValidarRangoFecha(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": debe ser menor o igual a la fecha fin del periodo";
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtG1FechaInicial, lcrValorReturn);
                        break;
                    #endregion

                    case "txtG1FechaFinal":
                        #region Validación
                        lcrNombreCampo = "Fecha final perido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E02";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtG1FechaFinal.Text, lcrNombreCampo);

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtG1FechaInicial.Text, lcrNombreCampo)))
                            {
                                if (!Funciones.flgValidarRangoFecha(this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": debe ser mayor o igual a la fecha inicial del periodo";
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtG1FechaFinal, lcrValorReturn);
                        break;
                    #endregion

                    case "txtG1TipoInforme":
                        #region Validación
                        lcrNombreCampo = "Tipo informe";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E03";

                        if (this.txtG1TipoInforme.Text == "NA")
                        {
                            lcrValorReturn = lcrNombreCampo + ": debe seleccionar un tipo de informe desde la lista.";
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
        #endregion
        #region fcvValidarValoresAddCondicion: Validar el dato escrito en valor condicion
        /// <summary>
        /// Validar el dato escrito en el TextBox Valor condicion, antes de agregar la condicion
        /// </summary>
        private void fcvValidarValoresAddCondicion(object sender, TextChangedEventArgs e)
        {
            var lobTextBox = sender as TextBox;
            if (!String.IsNullOrWhiteSpace(lobTextBox.Text))
            {
                fcrValidacionAddCondiciones(RefCrtAddCondicion.txtIdItemSelect.Text);
            }
        }
        #endregion
        #region fcrValidacionAddCondiciones: Validacion antes de adicionar condiciones 
        /// <summary>
        /// Validacion antes de adicionar condiciones:
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        /// <param name="tcrNombreCampo">Nombre del campo seleccionado en el combobox para realizar validación</param>
        /// </summary>
        public String fcrValidacionAddCondiciones(String tcrNombreCampo)
        {

            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            String lcrValorDato = RefCrtAddCondicion.txtValor.Text;

            try
            {

                switch (tcrNombreCampo)
                {
                    case "FECHA":
                        #region Validacion
                        /*
                        lcrNombreCampo = "Fecha actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtG1Odn_fecact_odac.Text, "Fecha actividad");
                        fcvSetColorValidacion(this.txtG1Odn_fecact_odac, lcrValorReturn);
                        */
                        break;
                    #endregion

                    case "Hcl_tiptur_hctu":
                        #region Validacion
                        lcrNombreCampo = "Turno de atencion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";

                        if (String.IsNullOrWhiteSpace(lcrValorDato))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = HCLValidarCodigo.fobRegBuscarHcltiporegturno(lcrValorDato);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hcl_tiptur_hctu))
                            {
                                RefCrtAddCondicion.txtDescripcion.Text = tmp.hcl_destur_hctu;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                    #endregion

                    case "Sia_codpfa_prof":
                        #region Validacion
                        lcrNombreCampo = "Codigo profesional del servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";

                        if (string.IsNullOrWhiteSpace(lcrValorDato))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(lcrValorDato);
                            if (tmp != null && tmp.sia_nompro_prof != null)
                            {
                                RefCrtAddCondicion.txtDescripcion.Text = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                    #endregion

                    case "Cto_seccon_cont":
                        #region Validacion
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (string.IsNullOrWhiteSpace(lcrValorDato))
                        {
                            lcrValorReturn = "Secuencial de Contrato: Es requerido";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontratoEx(lcrValorDato);
                            if (tmp != null)
                            {
                                RefCrtAddCondicion.txtDescripcion.Text = tmp.cto_descon_cont;
                            }
                            else
                            {
                                lcrValorReturn = "Secuencial de Contrato: No existe";
                            }
                        }
                        break;
                    #endregion

                    case "Sia_codeps_teps":
                        #region Validacion
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (string.IsNullOrWhiteSpace(lcrValorDato))
                        {
                            lcrValorReturn = "Código EPS: Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(lcrValorDato);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codeps_teps))
                            {
                                RefCrtAddCondicion.txtDescripcion.Text = tmp.sia_deseps_teps;
                            }
                            else
                            {
                                lcrValorReturn = "Código EPS: No existe";
                            }
                        }
                        break;
                    #endregion

                    case "Sia_codare_aser":
                        #region Validacion
                        lcrNombreCampo = "Area de servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (string.IsNullOrWhiteSpace(lcrValorDato))
                        {
                            lcrValorReturn = "Código área servicio: Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(lcrValorDato);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codare_aser))
                            {
                                RefCrtAddCondicion.txtDescripcion.Text = tmp.sia_desare_aser;
                            }
                            else
                            {
                                lcrValorReturn = "Código área servicio: No existe";
                            }
                        }
                        break;
                    #endregion

                    case "Fcm_codcpr_cpro":
                        #region Validacion
                        lcrNombreCampo = "Código centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (string.IsNullOrWhiteSpace(lcrValorDato))
                        {
                            lcrValorReturn = "Código centro producción: Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(lcrValorDato);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codcpr_cpro))
                            {
                                RefCrtAddCondicion.txtDescripcion.Text = tmp.fcm_descpr_cpro;
                            }
                            else
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        break;
                        #endregion
                }

                fcvLimpiarValidacionCondicion();
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                            lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);

                fcvSetColorValidacion(RefCrtAddCondicion.txtValor, lcrValorReturn);
                this.cmdLogErrores.IsEnabled = tmpLogErrores.Count > 0 ? true : false;
                RefCrtAddCondicion.cmdAddItem.IsEnabled = !String.IsNullOrWhiteSpace(lcrValorReturn) ? false : true;

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionAddCondiciones");
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcvSetColorValidacion: Color de objetos al validar
        private void fcvSetColorValidacion(TextBox tobObjeto, String tcrValorReturn)
        {
            tobObjeto.ToolTip = !String.IsNullOrWhiteSpace(tcrValorReturn) ? tcrValorReturn : null;
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
        #region fcvLimpiarValidacionCondicion: Limpiar datos validacion adicionar condicion
        private void fcvLimpiarValidacionCondicion()
        {
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A01", "", "", "ALTO", "");
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A02", "", "", "ALTO", "");
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A03", "", "", "ALTO", "");
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A04", "", "", "ALTO", "");
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A05", "", "", "ALTO", "");
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A06", "", "", "ALTO", "");
            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A07", "", "", "ALTO", "");
        }
        #endregion
        //--------------------------------------------------
        // EJECUTAR CONSULTAS 
        //--------------------------------------------------
        #region flsEjecutarConsultaRSM01: Resumen general por centros de producción
        /// <summary>
        /// RSM01 - Resumen general por centros de producción
        /// </summary>
        public bool flsEjecutarConsultaRSM01(String tcrFechaIni, String tcrFechaFin)
        {
            lstListSelFiltrFact = null; // Lista vacia por defecto filtro avanzado
            var llgContinuar = true;
            var llgReturn = false;

            if (this.chkFlitroAvanzado.IsChecked == true)
            {
                lstListSelFiltrFact = FCMValidarCodigo.flsBrowserSeleccionFacturasGeneral(this, tcrFechaIni, tcrFechaFin);
                llgContinuar = lstListSelFiltrFact == null ? false : true;
            }

            if (llgContinuar == true)
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
                lobDlgAdd.Show();

                var lcrTextoPlano = String.Empty;
                tmpResumen = null;

                gcrExportarArchivoNombre = fcrGuardarGenerarNombreArchivo("INFORME-RESUMEN-GENERAL-PRODUCCION-MENSUAL");

                lcrTextoPlano = fcrGuardarDatosResumenRSM01(tcrFechaIni, tcrFechaFin);
                flgExportarForamtoPlano(gcrExportarArchivoNombre, lcrTextoPlano);

                llgReturn = tmpResumen == null ? false : true;

                lobDlgAdd.Close();
            }
            return llgReturn;
        }
        #endregion
        #region flsEjecutarConsulta01: Facturación total por centros de producción
        /// <summary>
        /// INF01 - Facturación total por centros de producción
        /// </summary>
        public bool flsEjecutarConsulta01(String tcrFechaIni, String tcrFechaFin)
        {
            var llgReturn = false;
            lstListSelFiltrFact = null; // Lista vacia por defecto filtro avanzado
            var llgContinuar = true;

            if (this.chkFlitroAvanzado.IsChecked == true)
            {
                lstListSelFiltrFact = FCMValidarCodigo.flsBrowserSeleccionFacturasGeneral(this, tcrFechaIni, tcrFechaFin);
                llgContinuar = lstListSelFiltrFact == null ? false : true;
            }

            if (llgContinuar == true)
            {

                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
                lobDlgAdd.Show();

                var lcrTextoPlano = String.Empty;
                tmpResumen = null;

                gcrExportarArchivoNombre = fcrGuardarGenerarNombreArchivo("INFORME-PRODUCCION-MENSUAL");

                lcrTextoPlano = fcrGuardarDatosResumenINF01(tcrFechaIni, tcrFechaFin);
                flgExportarForamtoPlano(gcrExportarArchivoNombre, lcrTextoPlano);

                llgReturn = tmpResumen == null ? false : true;

                lobDlgAdd.Close();
            }
            return llgReturn;
        }
        #endregion
        #region flsEjecutarConsulta02: Servicios por grupo de edad
        /// <summary>
        /// INF02 - Informe general servicios por grupo de edad
        /// </summary>
        public bool flsEjecutarConsulta02(String tdaFechaIni, String tdaFechaFin)
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
            lobDlgAdd.Show();

            var llgReturn = false;
            var lcrTextoPlano = String.Empty;
            gcrExportarArchivoNombre = fcrGuardarGenerarNombreArchivo("LISTADO-USUARIOS-ATENDIDOS");

            tmpAdmisiones = flstConsultarDatos("INF02", tdaFechaIni, tdaFechaFin);
            lcrTextoPlano = fcrGuardarDatosResumenINF02();

            flgExportarForamtoPlano(gcrExportarArchivoNombre, lcrTextoPlano);

            llgReturn = tmpAdmResumen == null ? false : true;

            lobDlgAdd.Close();
            return llgReturn;
        }
        #endregion
        #region flsEjecutarConsulta06: Diagnosticos por grupos de edad
        /// <summary>
        /// INF06 - Diagnosticos por grupos de edad
        /// </summary>
        public bool flsEjecutarConsulta06(String tdaFechaIni, String tdaFechaFin)
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
            lobDlgAdd.Show();

            var llgReturn = false;
            tmpResumen = null;
            tmpConsulta = flstConsultarDatos("INF06", tdaFechaIni, tdaFechaFin);
            //flgGuardarDatosResumenINF06();

            llgReturn = tmpResumen == null ? false : true;

            lobDlgAdd.Close();
            return llgReturn;
        }
        #endregion
        #region flsEjecutarConsulta07: Listado usuarios por servicios y fechas (sencillo)
        /// <summary>
        /// INF07 - Listado usuarios por servicios y fechas (sencillo)
        /// </summary>
        public bool flsEjecutarConsulta07(String tdaFechaIni, String tdaFechaFin)
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
            lobDlgAdd.Show();

            var llgReturn = true;
            var lcrTextoPlano = String.Empty;
            gcrExportarArchivoNombre = fcrGuardarGenerarNombreArchivo("LISTADO-USUARIOS-POR-SERVICIOS");

            tmpConsulta = flstConsultarDatos("INF07", tdaFechaIni, tdaFechaFin);
            lcrTextoPlano = fcrGuardarDatosResumenINF07();

            flgExportarForamtoPlano(gcrExportarArchivoNombre, lcrTextoPlano);

            lobDlgAdd.Close();
            return llgReturn;
        }
        #endregion
        #region flsEjecutarConsulta09: Listado servicios facturacion
        /// <summary>
        /// INF09 - Listado servicios facturacion
        /// </summary>
        public bool flsEjecutarConsulta09(String tcrFechaIni, String tcrFechaFin)
        {
            lstListSelFiltrFact = null; // Lista vacia por defecto filtro avanzado
            var llgContinuar = true;
            var llgReturn = false;

            if (this.chkFlitroAvanzado.IsChecked == true)
            {
                lstListSelFiltrFact = FCMValidarCodigo.flsBrowserSeleccionFacturasGeneral(this, tcrFechaIni, tcrFechaFin);
                llgContinuar = lstListSelFiltrFact == null ? false : true;
            }

            if (llgContinuar == true)
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
                lobDlgAdd.Show();

                var lcrTextoPlano = String.Empty;
                tmpResumen = null;

                gcrExportarArchivoNombre = fcrGuardarGenerarNombreArchivo("INFORME-FACTURACION-GENERAL");

                lcrTextoPlano = fcrGuardarDatosInformeR09(tcrFechaIni, tcrFechaFin);
                flgExportarForamtoPlano(gcrExportarArchivoNombre, lcrTextoPlano);

                llgReturn = tmpResumen == null ? false : true;

                lobDlgAdd.Close();
            }
            return llgReturn;
        }
        #endregion
        #region flsEjecutarConsulta10: Oportunidad por empresa
        /// <summary>
        /// INF10 - Oportunidad por empresa
        /// </summary>
        public bool flsEjecutarConsulta10(String tcrFechaIni, String tcrFechaFin)
        {
            lstListSelFiltrFact = null; // Lista vacia por defecto filtro avanzado
            var llgContinuar = true;
            var llgReturn = false;

            if (this.chkFlitroAvanzado.IsChecked == true)
            {
                lstListSelFiltrFact = FCMValidarCodigo.flsBrowserSeleccionFacturasGeneral(this, tcrFechaIni, tcrFechaFin);
                llgContinuar = lstListSelFiltrFact == null ? false : true;
            }

            if (llgContinuar == true)
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
                lobDlgAdd.Show();

                var lcrTextoPlano = String.Empty;
                tmpResumen = null;

                gcrExportarArchivoNombre = fcrGuardarGenerarNombreArchivo("INFORME-OPRTUNIDAD-EMPRESA");

                lcrTextoPlano = fcrGuardarDatosInformeR10(tcrFechaIni, tcrFechaFin);
                flgExportarForamtoPlano(gcrExportarArchivoNombre, lcrTextoPlano);

                llgReturn = tmpResumen == null ? false : true;

                lobDlgAdd.Close();
            }
            return llgReturn;
        }
        #endregion
        #region flsEjecutarConsulta11: Indicadores de calidad
        /// <summary>
        /// INF11 - Indicadores de calidad
        /// </summary>
        public bool flsEjecutarConsulta11(String tcrFechaIni, String tcrFechaFin)
        {
            lstListSelFiltrFact = null; // Lista vacia por defecto filtro avanzado
            var llgContinuar = true;
            var llgReturn = false;

            if (this.chkFlitroAvanzado.IsChecked == true)
            {
                lstListSelFiltrFact = FCMValidarCodigo.flsBrowserSeleccionFacturasGeneral(this, tcrFechaIni, tcrFechaFin);
                llgContinuar = lstListSelFiltrFact == null ? false : true;
            }

            if (llgContinuar == true)
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
                lobDlgAdd.Show();

                var lcrTextoPlano = String.Empty;
                tmpResumen = null;

                gcrExportarArchivoNombre = fcrGuardarGenerarNombreArchivo("INFORME-INDICADORES-CALIDAD");

                lcrTextoPlano = fcrGuardarDatosInformeR11(tcrFechaIni, tcrFechaFin);
                flgExportarForamtoPlano(gcrExportarArchivoNombre, lcrTextoPlano);

                llgReturn = tmpResumen == null ? false : true;

                lobDlgAdd.Close();
            }
            return llgReturn;
        }
        #endregion
        #region flsEjecutarConsulta12: Servicios por centro de produccion
        /// <summary>
        /// INF12 - Facturación por centro de producción
        /// </summary>
        public bool flsEjecutarConsulta12(String tcrFechaIni, String tcrFechaFin)
        {
            lstListSelFiltrFact = null; // Lista vacia por defecto filtro avanzado
            var llgContinuar = true;
            var llgReturn = false;

            if (this.chkFlitroAvanzado.IsChecked == true)
            {
                lstListSelFiltrFact = FCMValidarCodigo.flsBrowserSeleccionFacturasGeneral(this, tcrFechaIni, tcrFechaFin);
                llgContinuar = lstListSelFiltrFact == null ? false : true;
            }

            if (llgContinuar == true)
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
                lobDlgAdd.Show();

                var lcrTextoPlano = String.Empty;
                tmpResumen = null;

                gcrExportarArchivoNombre = fcrGuardarGenerarNombreArchivo("INFORME-SERVICIOS-CENT-PRODUCCION");

                lcrTextoPlano = fcrGuardarDatosInformeR12(tcrFechaIni, tcrFechaFin);
                flgExportarForamtoPlano(gcrExportarArchivoNombre, lcrTextoPlano);

                llgReturn = tmpResumen == null ? false : true;

                lobDlgAdd.Close();
            }
            return llgReturn;
        }
        #endregion
        #region flsEjecutarConsulta13: Servicios por contrato EPS y Clasificación
        /// <summary>
        /// INF13 - Servicios por contrato EPS y Clasificación
        /// </summary>
        public bool flsEjecutarConsulta13(String tcrFechaIni, String tcrFechaFin)
        {
            lstListSelFiltrFact = null; // Lista vacia por defecto filtro avanzado
            var llgContinuar = true;
            var llgReturn = false;

            if (this.chkFlitroAvanzado.IsChecked == true)
            {
                lstListSelFiltrFact = FCMValidarCodigo.flsBrowserSeleccionFacturasGeneral(this, tcrFechaIni, tcrFechaFin);
                llgContinuar = lstListSelFiltrFact == null ? false : true;
            }

            if (llgContinuar == true)
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
                lobDlgAdd.Show();

                var lcrTextoPlano = String.Empty;
                tmpResumen = null;

                gcrExportarArchivoNombre = fcrGuardarGenerarNombreArchivo("INFORME-CONTRATO-EPS-CLAS-SERVICIOS");

                lcrTextoPlano = fcrGuardarDatosInformeR13(tcrFechaIni, tcrFechaFin);
                flgExportarForamtoPlano(gcrExportarArchivoNombre, lcrTextoPlano);

                llgReturn = tmpResumen == null ? false : true;

                lobDlgAdd.Close();
            }
            return llgReturn;
        }
        #endregion
        // GUARDAR REPORTES
        #region fcrGuardarDatosResumenRSM01: Resumen general por centros de producción
        /// <summary>
        /// <para>Resumen general por centros de producción</para>
        /// </summary>
        public String fcrGuardarDatosResumenRSM01(String tdaFechaIni, String tdaFechaFin)
        {
            #region Gestion de datos
            var lcrPlanoLineaRegTexto = String.Empty;
            var lcrPlanoLineaSumaTotal = String.Empty;
            var lcrPlanoLineaSumaTotal1 = String.Empty;
            var lcrPlanoLineaSumaTotal2 = String.Empty;
            var lcrTextoTituloGeneral = String.Empty;
            var lcrTextoTituloGrupo = String.Empty;
            var lcrTextoTituloRegistro = String.Empty;
            var lcrFcm_codcpr_cpro = String.Empty;
            var lnuFcm_valfac_dfac = 0;
            var lnuFcm_totuni_dfac = 0;
            var lcrSeparador = "|";
            var lcrFcm_coddig_mant = String.Empty;
            var lcrFcm_descpr_cpro = String.Empty;
            var lcrCto_seccon_cont = String.Empty;
            var lcrCto_nrocon_cont = String.Empty;
            var lcrSia_codeps_teps = String.Empty;
            var lcrSia_deseps_teps = String.Empty;
            var lcrFcm_codser_mant = String.Empty;
            var lcrFcm_desser_dfac = String.Empty;
            var lcrSia_tipusu_regi = String.Empty;
            var llgSiCumpleFiltro = true;
            #endregion
            var lobParam = new ESTUtilidades.RegistroResumen();
            // Primera parte - Cantidades y valores totales por centros de produccion
            #region Primera parte - Resumen general
            tmpConsulta = flstConsultarDatos("RSM01A", tdaFechaIni, tdaFechaFin);
            if (tmpConsulta != null)
            {
                tmpResumen = new List<ClasseTmpResumen>();
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    lcrCto_seccon_cont = lobReg["cto_seccon_cont"].ToString().Trim();
                    lcrSia_codeps_teps = lobReg["sia_codeps_teps"].ToString().Trim();
                    llgSiCumpleFiltro = flgSiFiltroAvanzado(lcrCto_seccon_cont, lcrSia_codeps_teps);

                    if (llgSiCumpleFiltro == true)
                    {
                        #region gestion de datos
                        lcrFcm_codcpr_cpro = lobReg["fcm_codcpr_cpro"].ToString().Trim(); // Codigo centro de produccion lobReg.Fcm_codcpr_cpro
                        lcrFcm_descpr_cpro = lobReg["fcm_descpr_cpro"].ToString().Trim(); // Descripcion centro produccion 
                        lnuFcm_totuni_dfac = Convert.ToInt32(lobReg["fcm_totuni_dfac"].ToString());
                        lnuFcm_valfac_dfac = Convert.ToInt32(lobReg["fcm_valfac_dfac"].ToString());
                        lcrSia_tipusu_regi = lobReg["sia_tipusu_regi"].ToString().Trim(); // Regimen de salud
                        #endregion
                        //---------------------------------------------------------
                        //- CANTIDADES Y VALORES MENSUAL POR CENTROS DE PRODUCCION
                        //---------------------------------------------------------
                        #region 11 - TOTALES POR CENTROS DE PRODUCCION CONTRATO Y EPS
                        lobParam.GrupoId = "RESUMEN";
                        lobParam.GrupoTitulo = "RESUMEN GENERAL CANTIDADES Y VALORES PRODUCCION MENSUAL";
                        lobParam.GrupoOrdenVista = 11;
                        lobParam.Parametro1 = lcrSia_tipusu_regi;
                        #region 11 - Resumen por contrato eps y area de servicios
                        lobParam.Registrollave = lobParam.GrupoId + "X" + lcrFcm_codcpr_cpro;
                        lobParam.RegistroCodigo = lcrFcm_codcpr_cpro;
                        lobParam.RegistroTitulo = lcrFcm_descpr_cpro;
                        lobParam.RegistroOrdVista = 1;
                        fcvGenRegGrupoResumCentroProduccion(lobParam, lnuFcm_totuni_dfac, lnuFcm_valfac_dfac);
                        #endregion
                        #endregion
                    }
                }
            }
            #endregion
            // Segunda parte - Cantidades y valores por centros de produccion y servicios
            #region Segunda parte
            tmpConsulta = flstConsultarDatos("RSM01B", tdaFechaIni, tdaFechaFin);

            if (tmpConsulta != null)
            {
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    lcrCto_seccon_cont = lobReg["cto_seccon_cont"].ToString().Trim();
                    lcrSia_codeps_teps = lobReg["sia_codeps_teps"].ToString().Trim();
                    llgSiCumpleFiltro = flgSiFiltroAvanzado(lcrCto_seccon_cont, lcrSia_codeps_teps);

                    if (llgSiCumpleFiltro == true)
                    {
                        #region Gestion de datos
                        lcrFcm_codcpr_cpro = lobReg["fcm_codcpr_cpro"].ToString().Trim(); // Codigo centro de produccion lobReg.Fcm_codcpr_cpro
                        lnuFcm_valfac_dfac = Convert.ToInt32(lobReg["fcm_valfac_dfac"].ToString());
                        lnuFcm_totuni_dfac = Convert.ToInt32(lobReg["fcm_totuni_dfac"].ToString());
                        lcrFcm_coddig_mant = lobReg["fcm_coddig_mant"].ToString().Trim(); // Codigo de digitacion 
                        lcrFcm_codser_mant = lobReg["fcm_codser_mant"].ToString().Trim(); // Codigo servicio en tarifario
                        lcrFcm_desser_dfac = lobReg["fcm_desser_dfac"].ToString().Trim(); // Descripcion servicio
                        lcrFcm_descpr_cpro = lobReg["fcm_descpr_cpro"].ToString().Trim(); // Descripcion centro produccion 
                        lcrSia_tipusu_regi = lobReg["sia_tipusu_regi"].ToString().Trim(); // Regimen de salud
                        #endregion
                        //---------------------------------------------------------
                        //- 12 VALORES PRODUCCION MENSUAL POR CENTROS DE PRODUCCION y EPS
                        //---------------------------------------------------------
                        #region 12 - TOTALES POR CENTROS DE PRODUCCION CONTRATO Y EPS
                        lobParam.GrupoId = "SERVICIOS";
                        lobParam.GrupoTitulo = "CANTIDADES Y VALORES SERVICIOS MENSUALES POR CENTRO DE PRODUCCION";
                        lobParam.GrupoOrdenVista = 12;
                        lobParam.Parametro1 = lcrSia_tipusu_regi;
                        #region 11 - Resumen por contrato eps y area de servicios
                        lobParam.Registrollave = lobParam.GrupoId + "X" + lcrFcm_codcpr_cpro + "X" + lcrFcm_coddig_mant;
                        lobParam.RegistroCodigo = lcrFcm_codcpr_cpro;
                        lobParam.RegistroCodigo1 = lcrFcm_coddig_mant;
                        lobParam.RegistroCodigo2 = lcrFcm_codser_mant;
                        lobParam.RegistroTitulo = lcrFcm_descpr_cpro;
                        lobParam.RegistroTitulo1 = lcrFcm_desser_dfac;
                        lobParam.RegistroOrdVista = 1;
                        fcvGenRegGrupoResumCentroProduccion(lobParam, lnuFcm_totuni_dfac, lnuFcm_valfac_dfac);
                        #endregion
                        #endregion
                    }
                }
            }
            #endregion
            // Resumen general
            #region 1 - Resumen general 
            if (tmpResumen != null)
            {
                //----------------------------------------------------------------
                // 1 - Generar vista Resumen General Primera parte
                //----------------------------------------------------------------
                #region Gestion de datos Primera parte
                var tmpResumenAux = (from tmp in tmpResumen where tmp.GrupoIdRegistro == "RESUMEN" select tmp).ToList();
                String tcrFechaRango = this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                String lcrRelleno = "-";
                lcrTextoTituloGeneral = lcrRelleno.PadRight(100, '-') + "\r\n" + " RESUMEN GENERAL CENTROS DE PRODUCCION : " + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-');
                // Titulo registros
                lcrTextoTituloRegistro = "CODIGO|CENTRO PRODUCCION|CONTRIBUTIVO|SUBSIDIADO|VINCULADO|PARTICULAR|OTRO|CANT.SERVICIOS|VALOR.TOTAL";

                foreach (var lobReg in tmpResumenAux)
                {
                    #region gestion de datos
                    lcrPlanoLineaRegTexto = lobReg.RegistroCodigo.Trim() + lcrSeparador +
                                            lobReg.RegistroTitulo.Trim() + lcrSeparador +
                                            lobReg.Valor1.ToString().Trim() + lcrSeparador +
                                            lobReg.Valor2.ToString().Trim() + lcrSeparador +
                                            lobReg.Valor3.ToString().Trim() + lcrSeparador +
                                            lobReg.Valor4.ToString().Trim() + lcrSeparador +
                                            lobReg.Valor5.ToString().Trim() + lcrSeparador +
                                            lobReg.Total1.ToString().Trim() + lcrSeparador +
                                            lobReg.Total2.ToString().Trim();

                    lcrPlanoLineaRegTexto = !String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal1) ? "\r\n" + lcrPlanoLineaRegTexto : lcrPlanoLineaRegTexto;

                    lcrPlanoLineaSumaTotal1 += lcrPlanoLineaRegTexto;
                    #endregion
                }
                lcrPlanoLineaSumaTotal1 = lcrTextoTituloGeneral + "\r\n" + lcrTextoTituloRegistro + "\r\n" + lcrPlanoLineaSumaTotal1;
                #endregion
            }
            #endregion
            #region 2 - Resumen servicios por centro de produccion
            if (tmpResumen != null)
            {
                //----------------------------------------------------------------
                // 2 - Generar Vista detalles
                //----------------------------------------------------------------
                #region Gestion de datos Segunda parte
                var tmpResumenAux = (from tmp in tmpResumen where tmp.GrupoIdRegistro == "SERVICIOS" select tmp).ToList();
                String tcrFechaRango = this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                String lcrRelleno = "-";
                lcrTextoTituloGeneral = lcrRelleno.PadRight(100, '-') + "\r\n" + " RESUMEN POR CENTROS DE PRODUCCION Y SERVICIOS : " + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-');
                lcrTextoTituloRegistro = "CODIGO|CENTRO PRODUCCION|CONTRIBUTIVO|SUBSIDIADO|VINCULADO|PARTICULAR|OTRO|CANT.SERVICIOS|VALOR.TOTAL";

                var lcrCodigoGrupoAux = "XX";
                lcrTextoTituloGrupo = String.Empty;

                foreach (var lobReg in tmpResumenAux)
                {
                    #region gestion de datos
                    lcrTextoTituloGrupo = String.Empty;
                    // Titulo y encabezado del grupo segun el centro de produccion
                    if (lcrCodigoGrupoAux != lobReg.RegistroCodigo)
                    {
                        // Buscar en el resumen de la primera parte los valores totales del centro de produccion
                        var lcrGrup = tmpResumen.FirstOrDefault(x => x.GrupoIdRegistro == "RESUMEN" && x.RegistroCodigo == lobReg.RegistroCodigo);
                        if (lcrGrup != null)
                        {
                            lcrTextoTituloGrupo = lobReg.RegistroCodigo.Trim() + lcrSeparador +
                                                  lobReg.RegistroTitulo.Trim() + lcrSeparador +
                                                  lcrGrup.Valor1.ToString().Trim() + lcrSeparador +
                                                  lcrGrup.Valor2.ToString().Trim() + lcrSeparador +
                                                  lcrGrup.Valor3.ToString().Trim() + lcrSeparador +
                                                  lcrGrup.Valor4.ToString().Trim() + lcrSeparador +
                                                  lcrGrup.Valor5.ToString().Trim() + lcrSeparador +
                                                  lcrGrup.Total1.ToString().Trim() + lcrSeparador +
                                                  lcrGrup.Total2.ToString().Trim() + lcrSeparador + "XXXX" + "\r\n";  // XXXX es una marca de guia para color en excel
                        }
                        lcrCodigoGrupoAux = lobReg.RegistroCodigo;
                    }
                    // Generar cada registro detalle servicio
                    lcrPlanoLineaRegTexto = lcrTextoTituloGrupo +
                                            lobReg.RegistroCodigo2.Trim() + lcrSeparador +
                                            lobReg.RegistroTitulo1.Trim() + lcrSeparador +
                                            lobReg.Valor1.ToString().Trim() + lcrSeparador +
                                            lobReg.Valor2.ToString().Trim() + lcrSeparador +
                                            lobReg.Valor3.ToString().Trim() + lcrSeparador +
                                            lobReg.Valor4.ToString().Trim() + lcrSeparador +
                                            lobReg.Valor5.ToString().Trim() + lcrSeparador +
                                            lobReg.Total1.ToString().Trim() + lcrSeparador +
                                            lobReg.Total2.ToString().Trim();

                    lcrPlanoLineaRegTexto = !String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal2) ? "\r\n" + lcrPlanoLineaRegTexto : lcrPlanoLineaRegTexto;

                    lcrPlanoLineaSumaTotal2 += lcrPlanoLineaRegTexto;
                    #endregion
                }
                //lcrPlanoLineaSumaTotal = lcrTextoTituloGeneral + "\r\n" + lcrTextoTituloRegistro + "\r\n" + lcrPlanoLineaSumaTotal;
                lcrPlanoLineaSumaTotal2 = lcrTextoTituloGeneral + "\r\n" + lcrTextoTituloRegistro + "\r\n" + lcrPlanoLineaSumaTotal2;
                #endregion
            }
            #endregion
            lcrPlanoLineaSumaTotal = lcrPlanoLineaSumaTotal1 + "\r\n" + lcrPlanoLineaSumaTotal2;

            return lcrPlanoLineaSumaTotal;
        }
        #endregion
        #region fcrGuardarDatosResumenINF01: Facturación Mensual por centros de producción
        /// <summary>
        /// <para>Facturación Mensual por centros de producción</para>
        /// </summary>
        public String fcrGuardarDatosResumenINF01(String tdaFechaIni, String tdaFechaFin)
        {
            #region gestion de datos
            var lcrPlanoLineaRegTexto = String.Empty;
            var lcrPlanoLineaSumaTotal = String.Empty;
            var lcrTextoTituloGeneral = String.Empty;
            var lcrTextoTituloGrupo = String.Empty;
            var lcrTextoTituloRegistro = String.Empty;
            var lcrFcm_codcpr_cpro = String.Empty;
            var lnuFcm_valfac_dfac = 0;
            var lnuFcm_totuni_dfac = 0;
            var lcrSeparador = "|";
            var lcrFcm_coddig_mant = String.Empty;
            var lcrCto_seccon_cont = String.Empty;
            var lcrCto_nrocon_cont = String.Empty;
            var lcrSia_codeps_teps = String.Empty;
            var lcrSia_deseps_teps = String.Empty;
            var lcrCto_descon_cont = String.Empty;
            var lcrSia_tipusu_regi = String.Empty;
            var lcrSia_destip_regi = String.Empty;
            var lcrFcm_codser_mant = String.Empty;
            var lcrFcm_desser_dfac = String.Empty;
            var lcrSia_tipact_tsac = String.Empty;
            var llgSiCumpleFiltro = true;
            #endregion
            var lobParam = new ESTUtilidades.RegistroResumen();
            // Primera parte - Valores por servicios
            #region Primera parte - Valores por servicios
            tmpConsulta = flstConsultarDatos("INF01A", tdaFechaIni, tdaFechaFin);
            if (tmpConsulta != null)
            {
                tmpResumen = new List<ClasseTmpResumen>();
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    lcrCto_seccon_cont = lobReg["cto_seccon_cont"].ToString().Trim();
                    lcrSia_codeps_teps = lobReg["sia_codeps_teps"].ToString().Trim().ToUpper();
                    llgSiCumpleFiltro = flgSiFiltroAvanzado(lcrCto_seccon_cont, lcrSia_codeps_teps);

                    if (llgSiCumpleFiltro == true)
                    {

                        #region gestion de datos
                        lcrFcm_codcpr_cpro = lobReg["fcm_codcpr_cpro"].ToString().Trim(); // Codigo centro de produccion lobReg.Fcm_codcpr_cpro
                        lnuFcm_valfac_dfac = lobReg["fcm_valfac_dfac"] != null ? Convert.ToInt32(lobReg["fcm_valfac_dfac"].ToString()) : 0;
                        lnuFcm_totuni_dfac = lobReg["fcm_totuni_dfac"] != null ? Convert.ToInt32(lobReg["fcm_totuni_dfac"].ToString()) : 0;
                        lcrFcm_coddig_mant = lobReg["fcm_coddig_mant"].ToString().Trim(); // Codigo de digitacion 
                        lcrFcm_codser_mant = lobReg["fcm_codser_mant"].ToString().Trim(); // Codigo servicio en tarifario
                        lcrFcm_desser_dfac = lobReg["fcm_desser_dfac"].ToString().Trim(); // Descripcion servicio
                        lcrCto_nrocon_cont = lobReg["cto_nrocon_cont"].ToString().Trim();
                        lcrSia_deseps_teps = lobReg["sia_deseps_teps"].ToString().Trim();
                        lcrCto_descon_cont = lobReg["cto_descon_cont"].ToString().Trim();
                        lcrSia_tipusu_regi = lobReg["sia_tipusu_regi"].ToString().Trim();
                        //lcrSia_destip_regi = lobReg["sia_destip_regi"].ToString().Trim().ToUpper();
                        lcrSia_tipact_tsac = lobReg["sia_tipact_tsac"].ToString().Trim(); // Asistencial o PyP
                        #endregion
                        //---------------------------------------------------------
                        //- 1 VALORES PRODUCCION MENSUAL POR CENTROS DE PRODUCCION y EPS
                        //---------------------------------------------------------
                        #region 11 - TOTALES POR CENTROS DE PRODUCCION CONTRATO Y EPS
                        lobParam.GrupoId = "VALORCPRODCC";
                        lobParam.GrupoTipo = "CONTRATO|CÓDIGO EPS|NOMBRE EPS|";
                        lobParam.GrupoTitulo = "VALORES PRODUCCION MENSUAL POR CONTRATO, CENTROS DE PRODUCCION Y EPS";
                        lobParam.GrupoOrdenVista = 11;
                        #region 11 - Resumen por contrato eps y area de servicios
                        lobParam.Registrollave = lobParam.GrupoId + "X" + lcrSia_codeps_teps + "X" + lcrCto_seccon_cont;
                        lobParam.RegistroCodigo = lcrCto_nrocon_cont;
                        lobParam.RegistroTitulo = lcrCto_descon_cont;
                        lobParam.RegistroTitulo1 = lcrSia_codeps_teps;
                        lobParam.RegistroTitulo2 = lcrSia_deseps_teps;
                        lobParam.RegistroOrdVista = 1;
                        fcrGenRegGrupoAreaServicios(lobParam, lcrFcm_codcpr_cpro, lcrFcm_coddig_mant, lnuFcm_valfac_dfac);
                        #endregion
                        #endregion
                        //---------------------------------------------------------
                        //- 2 VALORES PRODUCCION MENSUAL POR CENTROS DE PRODUCCION Y REGIMEN
                        //---------------------------------------------------------
                        #region 12 - TOTALES POR CENTROS DE PRODUCCION Y REGIMEN SALUD
                        lobParam.GrupoId = "VALORREGIMEN";
                        lobParam.GrupoTipo = "NA|CÓDIGO REGIMEN|REGIMEN SALUD|";
                        lobParam.GrupoTitulo = "VALORES PRODUCCION MENSUAL POR CENTROS DE PRODUCCION Y REGIMEN";
                        lobParam.GrupoOrdenVista = 12;
                        #region 12 - Resumen por centros de procuccion y regimen
                        lobParam.Registrollave = lobParam.GrupoId + "X" + lcrSia_tipusu_regi;
                        lobParam.RegistroCodigo = "NA";
                        lobParam.RegistroTitulo = "NA";
                        lobParam.RegistroTitulo1 = lcrSia_tipusu_regi;
                        lobParam.RegistroTitulo2 = lcrSia_destip_regi;
                        lobParam.RegistroOrdVista = Convert.ToInt32(lcrSia_tipusu_regi);
                        fcrGenRegGrupoAreaServicios(lobParam, lcrFcm_codcpr_cpro, lcrFcm_coddig_mant, lnuFcm_valfac_dfac);
                        #endregion
                        #endregion
                    }
                }
            }
            #endregion
            // Segunda parte - Cantidades por servicios
            #region Segunda parte del resumen
            tmpConsulta = flstConsultarDatos("INF01B", tdaFechaIni, tdaFechaFin);
            if (tmpConsulta != null)
            {
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    lcrCto_seccon_cont = lobReg["cto_seccon_cont"].ToString().Trim();
                    lcrSia_codeps_teps = lobReg["sia_codeps_teps"].ToString().Trim();
                    llgSiCumpleFiltro = flgSiFiltroAvanzado(lcrCto_seccon_cont, lcrSia_codeps_teps);

                    if (llgSiCumpleFiltro == true)
                    {
                        #region gestion de datos
                        lcrFcm_codcpr_cpro = lobReg["fcm_codcpr_cpro"].ToString().Trim(); // Codigo centro de produccion lobReg.Fcm_codcpr_cpro
                        lnuFcm_valfac_dfac = Convert.ToInt32(lobReg["fcm_valfac_dfac"].ToString());
                        lnuFcm_totuni_dfac = Convert.ToInt32(lobReg["fcm_totuni_dfac"].ToString());
                        lcrFcm_coddig_mant = lobReg["fcm_coddig_mant"].ToString().Trim(); // Codigo de digitacion 
                        lcrFcm_codser_mant = lobReg["fcm_codser_mant"].ToString().Trim(); // Codigo servicio en tarifario
                        lcrFcm_desser_dfac = lobReg["fcm_desser_dfac"].ToString().Trim(); // Descripcion servicio
                        lcrCto_nrocon_cont = lobReg["cto_nrocon_cont"].ToString().Trim();
                        lcrSia_deseps_teps = lobReg["sia_deseps_teps"].ToString().Trim();
                        lcrCto_descon_cont = lobReg["cto_descon_cont"].ToString().Trim();
                        lcrSia_tipusu_regi = lobReg["sia_tipusu_regi"].ToString().Trim();
                        lcrSia_destip_regi = lobReg["sia_destip_regi"].ToString().Trim().ToUpper();
                        lcrSia_tipact_tsac = lobReg["sia_tipact_tsac"].ToString().Trim(); // Asistencial o PyP
                        #endregion
                        //---------------------------------------------------------
                        //- 13 CANTIDAD SERVICIOS MENSUAL POR CENTROS DE PRODUCCION y EPS
                        //---------------------------------------------------------
                        #region 13 - CANTIDAD SERVICIOS MENSUAL POR CENTROS DE PRODUCCION y EPS
                        lobParam.GrupoId = "CANTCPRODCC";
                        lobParam.GrupoTipo = "CONTRATO|CÓDIGO EPS|NOMBRE EPS|";
                        lobParam.GrupoTitulo = "CANTIDAD SERVICIOS MENSUAL POR CENTROS DE PRODUCCION y EPS";
                        lobParam.GrupoOrdenVista = 13;
                        #region 13 - Resumen por contrato eps y area de servicios
                        lobParam.Registrollave = lobParam.GrupoId + "X" + lcrSia_codeps_teps + "X" + lcrCto_seccon_cont;
                        lobParam.RegistroCodigo = lcrCto_nrocon_cont;
                        lobParam.RegistroTitulo = lcrCto_descon_cont;
                        lobParam.RegistroTitulo1 = lcrSia_codeps_teps;
                        lobParam.RegistroTitulo2 = lcrSia_deseps_teps;
                        lobParam.RegistroOrdVista = 1;
                        fcrGenRegGrupoAreaServicios(lobParam, lcrFcm_codcpr_cpro, lcrFcm_coddig_mant, lnuFcm_totuni_dfac);
                        #endregion
                        #endregion
                        //---------------------------------------------------------
                        //- 14 CANTIDAD SERVICIOS MENSUAL POR CENTROS DE PRODUCCION Y REGIMEN
                        //---------------------------------------------------------
                        #region 14 - CANTIDAD SERVICIOS CENTROS DE PRODUCCION Y REGIMEN SALUD
                        lobParam.GrupoId = "CANTREGIMEN";
                        lobParam.GrupoTipo = "NA|CÓDIGO REGIMEN|REGIMEN SALUD|";
                        lobParam.GrupoTitulo = "CANTIDAD SERVICIOS MENSUAL POR CENTROS DE PRODUCCION Y REGIMEN";
                        lobParam.GrupoOrdenVista = 14;
                        #region 14 - Resumen servicios centros de produccion y regimen
                        lobParam.Registrollave = lobParam.GrupoId + "X" + lcrSia_tipusu_regi;
                        lobParam.RegistroCodigo = "NA";
                        lobParam.RegistroTitulo = "NA";
                        lobParam.RegistroTitulo1 = lcrSia_tipusu_regi;
                        lobParam.RegistroTitulo2 = lcrSia_destip_regi;
                        lobParam.RegistroOrdVista = Convert.ToInt32(lcrSia_tipusu_regi);
                        fcrGenRegGrupoAreaServicios(lobParam, lcrFcm_codcpr_cpro, lcrFcm_coddig_mant, lnuFcm_totuni_dfac);
                        #endregion
                        #endregion
                        //---------------------------------------------------------
                        //- 15 RESUMEN CANTIDAD POR CADA SERVICIO Y CENTROS DE PRODUCCION
                        //---------------------------------------------------------
                        #region 15 - RESUMEN CANTIDAD POR CADA SERVICIO Y CENTROS DE PRODUCCION
                        lobParam.GrupoId = "SERVGEN";
                        lobParam.GrupoTipo = "CÓDIGO DIGITACION|CÓDIGO TARIFARIO|DESCRIPCIÓN SERVICIO|";
                        lobParam.GrupoTitulo = "RESUMEN CANTIDAD SERVICIOS GENERAL Y CENTROS DE PRODUCCION";
                        lobParam.GrupoOrdenVista = 15;
                        #region 15 - Resumen Cantidad servicios y centros de producción
                        lobParam.Registrollave = lobParam.GrupoId + "X" + lcrFcm_coddig_mant;
                        lobParam.RegistroCodigo = "NA";
                        lobParam.RegistroTitulo = lcrFcm_coddig_mant;
                        lobParam.RegistroTitulo1 = lcrFcm_codser_mant;
                        lobParam.RegistroTitulo2 = lcrFcm_desser_dfac;
                        lobParam.RegistroOrdVista = 1;
                        fcrGenRegGrupoAreaServicios(lobParam, lcrFcm_codcpr_cpro, lcrFcm_coddig_mant, lnuFcm_totuni_dfac);
                        #endregion
                        #endregion
                        //---------------------------------------------------------
                        //- 16 RESUMEN CANTIDAD SERVICIOS ASISTENCIAL Y CENTROS DE PRODUCCION
                        //---------------------------------------------------------
                        #region 16 - RESUMEN CANTIDAD SERVICIOS ASISTENCIAL Y CENTROS DE PRODUCCION
                        if (lcrSia_tipact_tsac == "1")
                        {
                            lobParam.GrupoId = "SERVASIS";
                            lobParam.GrupoTipo = "CÓDIGO DIGITACION|CÓDIGO TARIFARIO|DESCRIPCIÓN SERVICIO|";
                            lobParam.GrupoTitulo = "RESUMEN CANTIDAD SERVICIOS ASISTENCIALES Y CENTROS DE PRODUCCION";
                            lobParam.GrupoOrdenVista = 16;
                            #region 16 - Resumen cantidad  por  servicios y centros de propor regimen y area de servicios
                            lobParam.Registrollave = lobParam.GrupoId + "X" + lcrFcm_coddig_mant;
                            lobParam.RegistroCodigo = "NA";
                            lobParam.RegistroTitulo = lcrFcm_coddig_mant;
                            lobParam.RegistroTitulo1 = lcrFcm_codser_mant;
                            lobParam.RegistroTitulo2 = lcrFcm_desser_dfac;
                            lobParam.RegistroOrdVista = 1;
                            fcrGenRegGrupoAreaServicios(lobParam, lcrFcm_codcpr_cpro, lcrFcm_coddig_mant, lnuFcm_totuni_dfac);
                            #endregion
                        }
                        #endregion
                        //---------------------------------------------------------
                        //- 17 RESUMEN CANTIDAD SERVICIOS ASISTENCIAL Y CENTROS DE PRODUCCION
                        //---------------------------------------------------------
                        #region 17 - RESUMEN CANTIDAD SERVICIOS ASISTENCIAL Y CENTROS DE PRODUCCION
                        if (lcrSia_tipact_tsac != "1")
                        {
                            lobParam.GrupoId = "SERVPYP";
                            lobParam.GrupoTipo = "CÓDIGO DIGITACION|CÓDIGO TARIFARIO|DESCRIPCIÓN SERVICIO|";
                            lobParam.GrupoTitulo = "RESUMEN CANTIDAD SERVICIOS PROMOCION/PREVENCION Y CENTROS DE PRODUCCION";
                            lobParam.GrupoOrdenVista = 17;
                            #region 1 - Resumen por regimen y area de servicios
                            lobParam.Registrollave = lobParam.GrupoId + "X" + lcrFcm_coddig_mant;
                            lobParam.RegistroCodigo = "NA";
                            lobParam.RegistroTitulo = lcrFcm_coddig_mant;
                            lobParam.RegistroTitulo1 = lcrFcm_codser_mant;
                            lobParam.RegistroTitulo2 = lcrFcm_desser_dfac;
                            lobParam.RegistroOrdVista = 1;
                            fcrGenRegGrupoAreaServicios(lobParam, lcrFcm_codcpr_cpro, lcrFcm_coddig_mant, lnuFcm_totuni_dfac);
                            #endregion
                        }
                        #endregion
                    }
                }
            }
            #endregion
            // Resumen general
            #region Resumen general
            if (tmpResumen != null)
            {
                //- ORGANIZAR LOS DATOS
                tmpResumen = (from tmp in tmpResumen orderby tmp.GrupoOrdenVista, tmp.RegistroOrdenVista select tmp).ToList();

                // Generar vista resumen general plano
                //-------------------------------------------------------------
                // TEXTO RESUMEN GENRAL
                //-------------------------------------------------------------
                #region gestion de datos
                // Titulo general
                String tcrFechaRango = this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                String lcrRelleno = "-";
                lcrTextoTituloGeneral = lcrRelleno.PadRight(100, '-') + "\r\n" + " INFORME PRODUCCION MENSUAL : " + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-');
                // Titulo registros
                lcrTextoTituloRegistro = "CONSULTA EXTERNA|OBSERVACION URGENCIAS|" +
                                         "ODONTOLOGIA|REMISIONES|LABORATORIO CLINICO|" +
                                         "HOSPITALIZACION|PROMOCION Y PREVENCION|" +
                                         "DROGRAS Y FARMACIA|OTROS CENTROS.PRODUC|TOTAL GENERAL";
                var lcrCodigoGrupoAux = "XX";
                lcrTextoTituloGrupo = String.Empty;
                foreach (var lobReg in tmpResumen)
                {
                    #region gestion de datos
                    lcrTextoTituloGrupo = String.Empty;
                    // Titulo y encabezado del grupo
                    if (lcrCodigoGrupoAux != lobReg.GrupoIdRegistro)
                    {
                        lcrTextoTituloGrupo = lcrRelleno.PadRight(100, '-') + "\r\n" + lobReg.GrupoTitulo + " : " + "\r\n";
                        lcrTextoTituloGrupo += "\r\n" + lobReg.GrupoTipo + lcrTextoTituloRegistro + "\r\n";
                        lcrCodigoGrupoAux = lobReg.GrupoIdRegistro;
                    }
                    lcrPlanoLineaRegTexto = lcrTextoTituloGrupo + fcrGenLineaTextoFormatoAreasServicios(lobReg, lcrSeparador);
                    lcrPlanoLineaRegTexto = !String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal) ? "\r\n" + lcrPlanoLineaRegTexto : lcrPlanoLineaRegTexto;

                    lcrPlanoLineaSumaTotal += lcrPlanoLineaRegTexto;
                    #endregion
                }
                lcrPlanoLineaSumaTotal = lcrTextoTituloGeneral + "\r\n" + lcrPlanoLineaSumaTotal;
                #endregion

            }
            #endregion
            return lcrPlanoLineaSumaTotal;
        }
        #endregion
        #region fcrGuardarDatosResumenINF02: INF02 - Informe general atencion por grupo de edad
        /// <summary>
        /// <para>INF02 - Informe general atencion por grupo de edad </para>
        /// </summary>
        public String fcrGuardarDatosResumenINF02()
        {
            #region gestion de datos
            var lcrPlanoLineaRegTexto = String.Empty;
            var lcrPlanoLineaSumaTotal = String.Empty;
            var lcrTextoTituloGeneral = String.Empty;
            var lcrTextoTituloGrupo = String.Empty;
            var lcrTextoTituloRegistro = String.Empty;
            var lcrSeparador = "|";
            var lcrValorIdAdmison = String.Empty;
            var lnuValorEdadAño = 0;
            var lcrValorTipoAtencion = String.Empty;
            var lcrValorSexo = String.Empty;
            var lcrValorEmbarazada = "2";
            var llgValorRemitidosSiNo = false;
            var lobParam = new ESTUtilidades.RegistroResumen();
            var lcrGruposRegistrados = String.Empty;
            var lcrCodigoRegimenSalud = String.Empty;
            var lcrNombreRegimenSalud = String.Empty;
            var lcrCodigoEps = String.Empty;
            var lcrNombreEps = String.Empty;
            var lcrCodigoContrato = String.Empty;
            #endregion
            var lcrRegDat = new ClasseTmpResumen();
            tmpAdmResumen = new List<ClasseTmpResumen>();

            if (tmpAdmisiones != null)
            {
                foreach (DataRow lobReg in tmpAdmisiones.Rows)
                {
                    #region gestion de datos
                    // Iniciar variables para cada registro
                    llgValorRemitidosSiNo = false;
                    lcrValorIdAdmison = lobReg["adm_secadm_rgad"].ToString().Trim();
                    lcrValorTipoAtencion = lobReg["sia_regate_rgat"].ToString().Trim();
                    lnuValorEdadAño = lobReg["sia_edaano_usua"] != null ? Convert.ToInt32(lobReg["sia_edaano_usua"].ToString().Trim()) : 0;
                    lcrValorSexo = lobReg["sis_codsex_sexo"] != null ? lobReg["sis_codsex_sexo"].ToString().Trim() : String.Empty;
                    lcrValorEmbarazada = lobReg["adm_pacemb_rgad"] != null ? lobReg["adm_pacemb_rgad"].ToString().Trim() : "2";
                    lcrCodigoRegimenSalud = lobReg["sia_tipusu_regi"].ToString().Trim();
                    lcrNombreRegimenSalud = lobReg["sia_destip_regi"].ToString().Trim().ToUpper();
                    lcrCodigoEps = lobReg["sia_codeps_teps"].ToString().Trim();
                    lcrNombreEps = lobReg["sia_deseps_teps"].ToString().Trim();
                    lcrCodigoContrato = lobReg["cto_seccon_cont"].ToString().Trim();

                    // verificar si es una embarazada en caso que la admision diga que no
                    #region verificar si es una embarazada
                    if (lcrValorEmbarazada == "2" && lcrValorSexo == "F" && lnuValorEdadAño >= 12)
                    {
                        lcrValorEmbarazada = HCLValidarCodigo.flgRegBuscarHclregiseventosEmbarazadas(lcrValorIdAdmison) == true ? "1" : "2";
                    }
                    #endregion
                    // Verificar si se remitio
                    #region Verificar si se remitio
                    var lcrFormato = lcrValorTipoAtencion == "1" ? "FRM-SOLIC-REMISION" : "FRM-SOL-REMI-CEXTER";
                    var tmp = HCLValidarCodigo.fobRegBuscarHclregiseventosAdm(lcrValorIdAdmison, lcrFormato, "ASCEN");
                    if (tmp != null)
                    {
                        // se diligiencio formato de remision
                        llgValorRemitidosSiNo = true;
                    }
                    #endregion
                    //---------------------------------------------------------
                    //- 1 - USUARIOS ATENDIDOS
                    //---------------------------------------------------------
                    #region 1 - USUARIOS ATENDIDOS
                    lobParam.GrupoId = "GENERAL";
                    lobParam.GrupoTitulo = "USUARIOS ATENDIDOS";
                    lobParam.GrupoOrdenVista = 1;
                    //-Registrar grupo etareo
                    #region 1 - Resumen general por sexo y edad
                    lobParam.Registrollave = lobParam.GrupoId + "R01";
                    lobParam.RegistroCodigo = lobParam.GrupoId + "R01";
                    lobParam.RegistroTitulo = "RESUMEN USUARIOS ATENDIDOS";
                    lobParam.RegistroOrdVista = 1;
                    lcrGruposRegistrados = fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                    #endregion
                    #endregion
                    //---------------------------------------------------------
                    //- 2 ATENDIDOS SEGUN REGIMEN DE SALUD
                    //---------------------------------------------------------
                    #region 2 - USUARIOS ATENDIDOS
                    lobParam.GrupoId = "REGIMEN";
                    lobParam.GrupoTitulo = "USUARIOS ATENDIDOS POR REGIMEN SALUD";
                    lobParam.GrupoOrdenVista = 2;
                    #region 1 - Resumen por regimen de salud
                    lobParam.Registrollave = lobParam.GrupoId + "R0" + lcrCodigoRegimenSalud;
                    lobParam.RegistroCodigo = lobParam.GrupoId + "R0" + lcrCodigoRegimenSalud;
                    lobParam.RegistroTitulo = lcrNombreRegimenSalud;
                    lobParam.RegistroOrdVista = Convert.ToInt32(lcrCodigoRegimenSalud);
                    fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                    #endregion
                    #endregion
                    //---------------------------------------------------------
                    //- 3 ATENDIDOS SEGUN EPS Y CONTRATO
                    //---------------------------------------------------------
                    #region 3 - USUARIOS ATENDIDOS
                    lobParam.GrupoId = "EPS";
                    lobParam.GrupoTitulo = "USUARIOS POR EPS Y CONTRATO";
                    lobParam.GrupoOrdenVista = 3;
                    #region 1 - Resumen por regimen de salud
                    lobParam.Registrollave = lobParam.GrupoId + "X" + lcrCodigoEps + "X" + lcrCodigoContrato;
                    lobParam.RegistroCodigo = lobParam.Registrollave;
                    lobParam.RegistroTitulo = lcrNombreEps;
                    lobParam.RegistroOrdVista = 1;
                    fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                    #endregion
                    #endregion
                    //---------------------------------------------------------
                    //- 4 - ATENCION ADMITIDOS
                    //---------------------------------------------------------
                    #region 4 - ATENCION ADMITIDOS
                    lobParam.GrupoId = "ADMITIDOS";
                    lobParam.GrupoTitulo = "USUARIOS ADMITIDOS URGENCIAS Y HOSPITALIZACION";
                    lobParam.GrupoOrdenVista = 4;
                    #region 1 y 2 - Atencion Usuarios admitidos hospitalizacion y urgencias
                    if (lcrValorTipoAtencion == "1")
                    {
                        var tmp1 = ADMValidarCodigo.fobRegBuscarAdmregistegresoAdm(lcrValorIdAdmison);
                        if (tmp1 == null)
                        {
                            // Es un Urgencias
                            lobParam.Registrollave = lobParam.GrupoId + "R01";
                            lobParam.RegistroCodigo = lobParam.GrupoId + "R01";
                            lobParam.RegistroTitulo = "OBSERVACIÓN URGENCIAS";
                            lobParam.RegistroOrdVista = 1;
                        }
                        else
                        {
                            // Es un hospitalizado
                            lobParam.Registrollave = lobParam.GrupoId + "R02";
                            lobParam.RegistroCodigo = lobParam.GrupoId + "R02";
                            lobParam.RegistroTitulo = "OBSERVACIÓN HOSPITALIZACION";
                            lobParam.RegistroOrdVista = 2;
                        }
                        fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                        lcrGruposRegistrados += "-" + lobParam.RegistroCodigo;
                    }
                    #endregion
                    #region 3 y 4 - Solicitudes de remision y Traslados en ambulancia
                    if (lcrValorTipoAtencion == "1")
                    {
                        // Solicitudes de remision
                        #region Solicitudes de remision
                        lobParam.Registrollave = lobParam.GrupoId + "R03";
                        lobParam.RegistroCodigo = lobParam.GrupoId + "R03";
                        lobParam.RegistroTitulo = "SOLCITUDES DE REMISIÓN";
                        lobParam.RegistroOrdVista = 3;
                        if (llgValorRemitidosSiNo == true)
                        {
                            //  se diligiencio formato de remision
                            fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                            lcrGruposRegistrados += "-" + lobParam.RegistroCodigo;
                        }
                        #endregion
                        // Traslado en ambulancias
                        #region Traslado en ambulancias
                        lobParam.Registrollave = lobParam.GrupoId + "R04";
                        lobParam.RegistroCodigo = lobParam.GrupoId + "R04";
                        lobParam.RegistroTitulo = "TRASLADO EN AMBULANCIA";
                        lobParam.RegistroOrdVista = 4;
                        var tmp1 = HCLValidarCodigo.fobRegBuscarHclregiseventosAdm(lcrValorIdAdmison, "FRM-TRASLA-AMBULAN", "ASCEN");
                        if (tmp1 != null)
                        {
                            //  se diligiencio formato traslado en ambulancia
                            fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                            lcrGruposRegistrados += "-" + lobParam.RegistroCodigo;
                        }
                        #endregion
                    }
                    #endregion
                    #region 5 y 6 - Embarazadas atendidas y Partos 
                    if (lcrValorTipoAtencion == "1" && lcrValorEmbarazada == "1")
                    {
                        // Embarazadas
                        #region Embarazadas
                        lobParam.Registrollave = lobParam.GrupoId + "R05";
                        lobParam.RegistroCodigo = lobParam.GrupoId + "R05";
                        lobParam.RegistroTitulo = "EMBARAZADAS";
                        lobParam.RegistroOrdVista = 5;
                        fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                        lcrGruposRegistrados += "-" + lobParam.RegistroCodigo;
                        #endregion
                        // Partos atendidos
                        #region Partos atendidos
                        lobParam.Registrollave = lobParam.GrupoId + "R06";
                        lobParam.RegistroCodigo = lobParam.GrupoId + "R06";
                        lobParam.RegistroTitulo = "PARTOS ATENDIDOS";
                        lobParam.RegistroOrdVista = 6;
                        if (HCLValidarCodigo.flgRegBuscarHclregiseventosAtencionParto(lcrValorIdAdmison) == true)
                        {
                            //  se diligiencio formato atención del parto
                            fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                            lcrGruposRegistrados += "-" + lobParam.RegistroCodigo;
                        }
                        #endregion
                    }
                    #endregion
                    #endregion
                    //---------------------------------------------------------
                    //- 5 - ATENCION AMBULATORIA
                    //---------------------------------------------------------
                    #region 5 - ATENCION AMBULATORIA
                    lobParam.GrupoId = "AMBULATORIA";
                    lobParam.GrupoTitulo = "USUARIOS ATENCIÓN AMBULATORIA";
                    lobParam.GrupoOrdenVista = 5;
                    #region 5 - Usuarios antención ambulatoria
                    if (lcrValorTipoAtencion == "2")
                    {
                        // 1 Usuarios atendidos
                        #region 1 Usuarios atendidos
                        lobParam.Registrollave = lobParam.GrupoId + "R01";
                        lobParam.RegistroCodigo = lobParam.GrupoId + "R01";
                        lobParam.RegistroTitulo = "USUARIOS ATENCIÓN AMBULATORIA";
                        lobParam.RegistroOrdVista = 1;
                        fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                        lcrGruposRegistrados += "-" + lobParam.RegistroCodigo;
                        #endregion
                        // 2 Solicitudes de remision
                        #region 2 vSolicitudes de remision
                        lobParam.Registrollave = lobParam.GrupoId + "R02";
                        lobParam.RegistroCodigo = lobParam.GrupoId + "R02";
                        lobParam.RegistroTitulo = "SOLCITUDES DE REMISIÓN";
                        lobParam.RegistroOrdVista = 2;
                        if (llgValorRemitidosSiNo == true)
                        {
                            //  se diligiencio formato de remision
                            fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                            lcrGruposRegistrados += "-" + lobParam.RegistroCodigo;
                        }
                        #endregion
                        // 3 Embarazadas
                        #region 3 Embarazadas
                        if (lcrValorEmbarazada == "1")
                        {
                            lobParam.Registrollave = lobParam.GrupoId + "R03";
                            lobParam.RegistroCodigo = lobParam.GrupoId + "R03";
                            lobParam.RegistroTitulo = "EMBARAZADAS";
                            lobParam.RegistroOrdVista = 3;
                            fcrGenRegGrupoEtareoAdmisionAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                            lcrGruposRegistrados += "-" + lobParam.RegistroCodigo;
                        }
                        #endregion
                    }
                    #endregion
                    #endregion
                    #endregion
                }
                //- ORGANIZAR LOS DATOS
                tmpAdmResumen = (from tmp in tmpAdmResumen orderby tmp.GrupoOrdenVista, tmp.RegistroOrdenVista select tmp).ToList();

                // Generar vista resumen general plano
                //-------------------------------------------------------------
                // TEXTO RESUMEN GENRAL
                //-------------------------------------------------------------
                #region gestion de datos
                // Titulo general
                String tcrFechaRango = this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                String lcrRelleno = "-";
                lcrTextoTituloGeneral = lcrRelleno.PadRight(100, '-') + "\r\n" + " USUARIOS ATENDIDOS : " + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-');
                // Titulo registros
                lcrTextoTituloRegistro = "REGISTRO|TITULO|0 AÑOS MASCULINO|0 AÑOS FEMENINO|1 a 4 AÑOS MASCULINO" +
                                         "|1 a 4 AÑOS FEMENINO|5 a 14 AÑOS MASCULINO|5 a 14 AÑOS FEMENINO" +
                                         "|15 a 44 AÑOS MASCULINO|15 a 44 AÑOS FEMENINO|45 a 64 AÑOS MASCULINO" +
                                         "|45 a 64 AÑOS FEMENINO|MAS DE 65 AÑOS MASCULINO|MAS DE 65 AÑOS FEMENINO" +
                                         "|TOTAL MASCULINO|TOTAL FEMENINO|TOTAL GENERAL";

                var lcrCodigoGrupoAux = "XX";
                lcrTextoTituloGrupo = String.Empty;
                foreach (var lobReg in tmpAdmResumen)
                {
                    #region gestion de datos
                    lcrTextoTituloGrupo = String.Empty;
                    // Titulo y encabezado del grupo
                    if (lcrCodigoGrupoAux != lobReg.GrupoIdRegistro)
                    {
                        lcrTextoTituloGrupo = lcrRelleno.PadRight(100, '-') + "\r\n" + lobReg.GrupoTitulo + " : " + "\r\n";
                        lcrTextoTituloGrupo += "\r\n" + lcrTextoTituloRegistro + "\r\n";
                        lcrCodigoGrupoAux = lobReg.GrupoIdRegistro;
                    }
                    lcrPlanoLineaRegTexto = lcrTextoTituloGrupo + fcrGenLineaTextoFormatoGruposEtareos(lobReg, lcrSeparador);
                    lcrPlanoLineaRegTexto = !String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal) ? "\r\n" + lcrPlanoLineaRegTexto : lcrPlanoLineaRegTexto;

                    lcrPlanoLineaSumaTotal += lcrPlanoLineaRegTexto;
                    #endregion
                }
                lcrPlanoLineaSumaTotal = lcrTextoTituloGeneral + "\r\n" + lcrPlanoLineaSumaTotal;
                #endregion
            }
            return lcrPlanoLineaSumaTotal;
        }
        #endregion
        #region fcrGuardarDatosResumenINF06: INF06 - Informe general Diagnosticos por grupo de edad
        /// <summary>
        /// <para>INF06 - Informe general Diagnosticos por grupo de edad</para>
        /// </summary>
        public String fcrGuardarDatosResumenINF06()
        {
            #region gestion de datos
            var lcrPlanoLineaRegTexto = String.Empty;
            var lcrPlanoLineaSumaTotal = String.Empty;
            var lcrTextoTituloGeneral = String.Empty;
            var lcrTextoTituloGrupo = String.Empty;
            var lcrTextoTituloRegistro = String.Empty;
            var lcrSeparador = "|";
            var lcrValorIdAdmison = String.Empty;
            var lnuValorEdadAño = 0;
            var lcrValorTipoAtencion = String.Empty;
            var lcrValorSexo = String.Empty;
            var lobParam = new ESTUtilidades.RegistroResumen();
            var lcrGruposRegistrados = String.Empty;
            var lcrCodigoRegimenSalud = String.Empty;
            var lcrNombreRegimenSalud = String.Empty;
            var lcrCodigoDiag = String.Empty;
            var lcrNombreDiag = String.Empty;
            var lcrCodigoContrato = String.Empty;
            #endregion
            var lcrRegDat = new ClasseTmpResumen();
            tmpResumen = new List<ClasseTmpResumen>();

            if (tmpAdmisiones != null)
            {
                foreach (DataRow lobReg in tmpAdmisiones.Rows)
                {
                    #region gestion de datos
                    // Iniciar variables para cada registro
                    lcrValorIdAdmison = lobReg["adm_secadm_rgad"].ToString().Trim();
                    lcrValorTipoAtencion = lobReg["sia_regate_rgat"].ToString().Trim();
                    lnuValorEdadAño = lobReg["sia_edaano_usua"] != null ? Convert.ToInt32(lobReg["sia_edaano_usua"].ToString().Trim()) : 0;
                    lcrValorSexo = lobReg["sis_codsex_sexo"] != null ? lobReg["sis_codsex_sexo"].ToString().Trim() : String.Empty;
                    lcrCodigoRegimenSalud = lobReg["sia_tipusu_regi"].ToString().Trim();
                    lcrNombreRegimenSalud = lobReg["sia_destip_regi"].ToString().Trim().ToUpper();
                    lcrCodigoDiag = lobReg["sia_coddia_tdia"].ToString().Trim();
                    lcrNombreDiag = lobReg["sia_desdia_tdia"].ToString().Trim();
                    lcrCodigoContrato = lobReg["cto_seccon_cont"].ToString().Trim();

                    //---------------------------------------------------------
                    //- 1 -  DIAGNOSTICOS USUARIOS ATENDIDOS GENERAL
                    //---------------------------------------------------------
                    #region 1 - USUARIOS ATENDIDOS
                    lobParam.GrupoId = "GENERAL";
                    lobParam.GrupoTitulo = "RESUMEN DIAGNOSTICOS GENERAL USUARIOS ATENDIDOS";
                    lobParam.GrupoOrdenVista = 1;
                    //-Registrar grupo etareo
                    #region 1 - Resumen Diagnosticos general por sexo y edad
                    lobParam.Registrollave = lobParam.GrupoId + "X" + lcrCodigoDiag;
                    lobParam.RegistroCodigo = lcrCodigoDiag;
                    lobParam.RegistroTitulo = lcrNombreDiag;
                    lobParam.RegistroOrdVista = 1;
                    lcrGruposRegistrados = fcrGenRegGrupoEtareoResumenAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                    #endregion
                    #endregion
                    //---------------------------------------------------------
                    //- 3 y 4 - DIAGNOSTICOS USUARIOS ATENCION ADMITIDOS
                    //---------------------------------------------------------
                    #region 3 Y 4 - ATENCION ADMITIDOS
                    #region 1 y 2 - Diagnosticos atencion usuarios admitidos hospitalizacion y urgencias
                    if (lcrValorTipoAtencion == "1")
                    {
                        var tmp1 = ADMValidarCodigo.fobRegBuscarAdmregistegresoAdm(lcrValorIdAdmison);
                        if (tmp1 == null)
                        {
                            // Es un Urgencias
                            lobParam.GrupoId = "ADMITIDOS-URG";
                            lobParam.GrupoTitulo = "USUARIOS OBSERVACIÓN URGENCIAS";
                            lobParam.GrupoOrdenVista = 3;

                            lobParam.Registrollave = lobParam.GrupoId + "X" + lcrCodigoDiag;
                            lobParam.RegistroCodigo = lcrCodigoDiag;
                            lobParam.RegistroTitulo = lcrNombreDiag;
                            lobParam.RegistroOrdVista = 1;
                        }
                        else
                        {
                            // Es un hospitalizado
                            lobParam.GrupoId = "ADMITIDOS-HOS";
                            lobParam.GrupoTitulo = "USUARIOS OBSERVACIÓN HOSPITALIZACION";
                            lobParam.GrupoOrdenVista = 4;

                            lobParam.Registrollave = lobParam.GrupoId + "X" + lcrCodigoDiag;
                            lobParam.RegistroCodigo = lcrCodigoDiag;
                            lobParam.RegistroTitulo = lcrNombreDiag;
                            lobParam.RegistroOrdVista = 2;
                        }
                        fcrGenRegGrupoEtareoResumenAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                        lcrGruposRegistrados += "-" + lobParam.RegistroCodigo;
                    }
                    #endregion
                    #endregion
                    //---------------------------------------------------------
                    //- 5 - DIAGNOSTICOS ATENCION AMBULATORIA
                    //---------------------------------------------------------
                    #region 5 - ATENCION AMBULATORIA
                    lobParam.GrupoId = "AMBULATORIA";
                    lobParam.GrupoTitulo = "USUARIOS ATENCIÓN AMBULATORIA";
                    lobParam.GrupoOrdenVista = 5;
                    #region 5 - Usuarios antención ambulatoria
                    if (lcrValorTipoAtencion == "2")
                    {
                        // 1 Usuarios atendidos ambulatoria
                        #region 1 Usuarios atendidos
                        lobParam.Registrollave = lobParam.GrupoId + "X" + lcrCodigoDiag;
                        lobParam.RegistroCodigo = lcrCodigoDiag;
                        lobParam.RegistroTitulo = lcrNombreDiag;
                        lobParam.RegistroOrdVista = 1;

                        fcrGenRegGrupoEtareoResumenAños(lobParam, lnuValorEdadAño, lcrValorSexo, 1);
                        lcrGruposRegistrados += "-" + lobParam.RegistroCodigo;
                        #endregion
                    }
                    #endregion
                    #endregion
                    #endregion
                }
                //- ORGANIZAR LOS DATOS
                tmpResumen = (from tmp in tmpResumen orderby tmp.GrupoOrdenVista, tmp.RegistroOrdenVista select tmp).ToList();

                // Generar vista resumen general plano
                //-------------------------------------------------------------
                // TEXTO RESUMEN GENRAL
                //-------------------------------------------------------------
                #region gestion de datos
                // Titulo general
                String tcrFechaRango = this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                String lcrRelleno = "-";
                lcrTextoTituloGeneral = lcrRelleno.PadRight(100, '-') + "\r\n" + " DIAGNOSTICOS USUARIOS ATENDIDOS : " + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-');
                // Titulo registros
                lcrTextoTituloRegistro = "CODIGO|DIAGNOSTICO|0 AÑOS MASCULINO|0 AÑOS FEMENINO|1 a 4 AÑOS MASCULINO" +
                                         "|1 a 4 AÑOS FEMENINO|5 a 14 AÑOS MASCULINO|5 a 14 AÑOS FEMENINO" +
                                         "|15 a 44 AÑOS MASCULINO|15 a 44 AÑOS FEMENINO|45 a 64 AÑOS MASCULINO" +
                                         "|45 a 64 AÑOS FEMENINO|MAS DE 65 AÑOS MASCULINO|MAS DE 65 AÑOS FEMENINO" +
                                         "|TOTAL MASCULINO|TOTAL FEMENINO|TOTAL GENERAL";

                var lcrCodigoGrupoAux = "XX";
                lcrTextoTituloGrupo = String.Empty;
                foreach (var lobReg in tmpResumen)
                {
                    #region gestion de datos
                    lcrTextoTituloGrupo = String.Empty;
                    // Titulo y encabezado del grupo
                    if (lcrCodigoGrupoAux != lobReg.GrupoIdRegistro)
                    {
                        lcrTextoTituloGrupo = lcrRelleno.PadRight(100, '-') + "\r\n" + lobReg.GrupoTitulo + " : " + "\r\n";
                        lcrTextoTituloGrupo += "\r\n" + lcrTextoTituloRegistro + "\r\n";
                        lcrCodigoGrupoAux = lobReg.GrupoIdRegistro;
                    }
                    lcrPlanoLineaRegTexto = lcrTextoTituloGrupo + fcrGenLineaTextoFormatoGruposEtareos(lobReg, lcrSeparador);
                    lcrPlanoLineaRegTexto = !String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal) ? "\r\n" + lcrPlanoLineaRegTexto : lcrPlanoLineaRegTexto;

                    lcrPlanoLineaSumaTotal += lcrPlanoLineaRegTexto;
                    #endregion
                }
                lcrPlanoLineaSumaTotal = lcrTextoTituloGeneral + "\r\n" + lcrPlanoLineaSumaTotal;
                #endregion
            }
            return lcrPlanoLineaSumaTotal;
        }
        #endregion
        #region fcrGuardarDatosResumenINF07: Listado usuarios por servicios y fechas (sencillo)
        /// <summary>
        /// <para>Listado usuarios por servicios y fechas (sencillo)</para>
        /// </summary>
        public String fcrGuardarDatosResumenINF07()
        {
            var lcrReturn = String.Empty;
            var lcrLinea = String.Empty;
            var lcrTextoTitulo = String.Empty;
            var lcrSepara = "|";
            var lcrTitulo = "LISTADO USUARIOS POR SERVICIOS Y FECHAS";

            var lcrCit_codasi_mcit = String.Empty; // Codigo solicitud cita
            var lcrCit_fecsol_mcit = String.Empty; // Fecha solicitud cita
            var lcrSia_fecnac_usua = String.Empty; // Fecha Nacimiento
            var lcrFcm_fecfac_dfac = String.Empty; // Fecha de la factura
            var lcrFcm_fecser_dfac = String.Empty; // Fecha del servicio
            var lcrCit_diasol_mcit = "0";          // Total dias solicitud cita
            var lcrFcm_horser_dfac = "0";          // Hora del servicio
            var lnuContadorReg = 0;            // Contador de registros
            DateTime ldaFcm_fecser_dfac;             // Codigo solicitud cita

            //var lobRegConfig = SISValidarCodigo.fobRegBuscarSisparametroips();
            #region Gestion datos
            if (tmpConsulta != null)
            {
                using (db = new DbAplicacion())
                {
                    foreach (DataRow lobReg in tmpConsulta.Rows)
                    {
                        //MessageBox.Show("FECHA " + lobReg["fcm_fecser_dfac"].ToString());
                        #region Gestion datos
                        lcrCit_codasi_mcit = lobReg["cit_codasi_mcit"] != null ? lobReg["cit_codasi_mcit"].ToString().Trim() : String.Empty;
                        ldaFcm_fecser_dfac = Funciones.fdaConvertFecha("DMY", "/", lobReg["fcm_fecser_dfac"].ToString());
                        lcrFcm_horser_dfac = lobReg["fcm_horser_dfac"].ToString();
                        lcrSia_fecnac_usua = Funciones.fcrConvertFecha(Funciones.fdaConvertFecha("DMY", "/", lobReg["Sia_fecnac_usua"].ToString()));
                        lcrFcm_fecfac_dfac = Funciones.fcrConvertFecha(Funciones.fdaConvertFecha("DMY", "/", lobReg["fcm_fecfac_mfac"].ToString()));
                        lcrFcm_fecser_dfac = Funciones.fcrConvertFecha(ldaFcm_fecser_dfac);
                        lcrCit_fecsol_mcit = "00/00/0000";
                        lcrCit_diasol_mcit = "0";
                        lnuContadorReg++;

                        // Calcualr dias asignacion cita
                        if (!string.IsNullOrWhiteSpace(lcrCit_codasi_mcit))
                        {
                            var lobRegx = db.Citmaesasigcita.FirstOrDefault(rxp => rxp.cit_codasi_mcit == lcrCit_codasi_mcit);
                            if (lobRegx != null)
                            {
                                lcrCit_fecsol_mcit = lobRegx.cit_fecsol_mcit != null ? Funciones.fcrConvertFecha((DateTime)lobRegx.cit_fecsol_mcit) : lcrCit_fecsol_mcit;
                                lcrCit_diasol_mcit = Funciones.fnuCalcularDiasFechas((DateTime)lobRegx.cit_fecsol_mcit, ldaFcm_fecser_dfac).ToString();
                            }
                        }
                        #region  Cargar datos en registro 
                        lcrLinea = lobReg["Cto_seccon_cont"].ToString() + lcrSepara +
                                    lobReg["Cto_nrocon_cont"].ToString() + lcrSepara +
                                    lobReg["Sia_codeps_teps"].ToString() + lcrSepara +
                                    lobReg["Sia_deseps_teps"].ToString() + lcrSepara +
                                    lobReg["Sia_tipide_tide"].ToString() + lcrSepara +
                                    lobReg["Sia_nroide_usua"].ToString() + lcrSepara +
                                    lobReg["Sia_priape_usua"].ToString() + lcrSepara +
                                    lobReg["Sia_segape_usua"].ToString() + lcrSepara +
                                    lobReg["Sia_prinom_usua"].ToString() + lcrSepara +
                                    lobReg["Sia_segnom_usua"].ToString() + lcrSepara +
                                    lcrSia_fecnac_usua + lcrSepara +
                                    lobReg["Sis_codsex_sexo"].ToString() + lcrSepara +
                                    lobReg["Sia_edaano_usua"].ToString() + lcrSepara +
                                    lobReg["Sia_edames_usua"].ToString() + lcrSepara +
                                    lobReg["Sia_edadia_usua"].ToString() + lcrSepara +
                                    lobReg["sia_telres_usua"].ToString() + lcrSepara +
                                    lobReg["sia_dirres_usua"].ToString() + lcrSepara +
                                    lobReg["adm_secadm_rgad"].ToString() + lcrSepara +
                                    lobReg["fcm_numfac_mfac"].ToString() + lcrSepara +
                                    lcrFcm_fecfac_dfac + lcrSepara +
                                    lobReg["fcm_coddig_mant"].ToString() + lcrSepara +
                                    lobReg["Fcm_codser_mant"].ToString() + lcrSepara +
                                    lobReg["Fcm_desser_dfac"].ToString() + lcrSepara +
                                    lcrFcm_fecser_dfac + lcrSepara +
                                    lcrFcm_horser_dfac + lcrSepara +
                                    lcrCit_fecsol_mcit + lcrSepara +
                                    lcrCit_diasol_mcit + lcrSepara +
                                    lobReg["Fcm_valser_mant"].ToString() + lcrSepara +
                                    lobReg["Fcm_totuni_dfac"].ToString() + lcrSepara +
                                    lobReg["Fcm_valdes_dfac"].ToString() + lcrSepara +
                                    lobReg["fcm_valiva_dfac"].ToString() + lcrSepara +
                                    lobReg["Fcm_valcpa_dfac"].ToString() + lcrSepara +
                                    lobReg["Fcm_valcmo_dfac"].ToString() + lcrSepara +
                                    lobReg["Fcm_valusu_dfac"].ToString() + lcrSepara +
                                    lobReg["fcm_valfac_dfac"].ToString() + lcrSepara +
                                    lobReg["Fcm_codcpr_cpro"].ToString() + lcrSepara +
                                    lobReg["Fcm_descpr_cpro"].ToString() + lcrSepara +
                                    lobReg["Sia_descat_ceat"].ToString();

                        lcrReturn = String.IsNullOrWhiteSpace(lcrReturn) ? lcrLinea : lcrReturn + "\n" + lcrLinea;
                        #endregion
                        #endregion
                    }
                }
                if (!String.IsNullOrWhiteSpace(lcrReturn))
                {
                    // Titulo general
                    String tcrFechaRango = " PERIODO: " + this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                    String lcrRelleno = "-";
                    lcrTextoTitulo = lcrRelleno.PadRight(100, '-') + "\r\n" + lcrTitulo + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-') + "\r\n" +
                                     "TOTAL REGISTROS: " + lnuContadorReg.ToString() + "\r\n" + lcrRelleno.PadRight(100, '-');
                    #region Titulos de campos
                    lcrTextoTitulo += "\r\n" +
                                    "Id.Contrato" + lcrSepara +
                                    "Contrato" + lcrSepara +
                                    "Codigo.Eps" + lcrSepara +
                                    "Nombre.Eps" + lcrSepara +
                                    "Tipo.Ide" + lcrSepara +
                                    "Numero.Ide.Usuario" + lcrSepara +
                                    "P.Apellido" + lcrSepara +
                                    "S.Apellido" + lcrSepara +
                                    "P.Nombre" + lcrSepara +
                                    "S.Nombre" + lcrSepara +
                                    "Fecha.Nacimiento" + lcrSepara +
                                    "Sexo" + lcrSepara +
                                    "Edad.En.Años" + lcrSepara +
                                    "Edad.En.Meses" + lcrSepara +
                                    "Edad.En.Dias" + lcrSepara +
                                    "Telefono" + lcrSepara +
                                    "Dirección" + lcrSepara +
                                    "Numero.Admisión" + lcrSepara +
                                    "Numero.Factura" + lcrSepara +
                                    "Fecha.Factura" + lcrSepara +
                                    "Codigo.digitación" + lcrSepara +
                                    "Codigo.Servicio" + lcrSepara +
                                    "Nombre.Servicio" + lcrSepara +
                                    "Fecha.Servicio" + lcrSepara +
                                    "Hora.Servicio" + lcrSepara +
                                    "Fecha.Solicita.Cita" + lcrSepara +
                                    "Dias.Solicita.Cita" + lcrSepara +
                                    "Valor.Servicio" + lcrSepara +
                                    "Unidades" + lcrSepara +
                                    "Descuento" + lcrSepara +
                                    "Iva" + lcrSepara +
                                    "Copago" + lcrSepara +
                                    "Cuota.Moderadora" + lcrSepara +
                                    "Valor.Cargo.Usuario" + lcrSepara +
                                    "Valor.Total" + lcrSepara +
                                    "Codigo.Cent.Produccion" + lcrSepara +
                                    "Nombre.Cent.Produccion" + lcrSepara +
                                    "Sede.de.Atención";
                    #endregion
                }
                lcrReturn = lcrTextoTitulo + "\r\n" + lcrReturn;

            }
            #endregion

            return lcrReturn;
        }
        #endregion
        #region fcrGuardarDatosInformeR09: Informe general general por centros de producción
        /// <summary>
        /// <para>Resumen general por centros de producción</para>
        /// </summary>
        public String fcrGuardarDatosInformeR09(String tdaFechaIni, String tdaFechaFin)
        {
            #region Gestion de datos
            var lcrPlanoLineaRegTexto = String.Empty;
            var lcrPlanoLineaSumaTotal = String.Empty;
            var lcrPlanoLineaSumaTotal1 = String.Empty;
            var lcrSeparador = "|";
            var lcrTextoTitulo = String.Empty;
            var lcrTitulo = "SERVICIOS FACTURADOS";

            var lcrCto_seccon_cont = String.Empty;
            var lcrSia_codeps_teps = String.Empty;

            var lcrFcm_fecfac_dfac = String.Empty;
            var llgSiCumpleFiltro = true;
            var lcIndex = 1;
            #endregion
            var lobParam = new ESTUtilidades.RegistroResumen();
            // Ejecutar la consulta SQL
            #region informe general
            tmpConsulta = flstConsultarDatos("INF09", tdaFechaIni, tdaFechaFin);
            if (tmpConsulta != null)
            {
                tmpResumen = new List<ClasseTmpResumen>();
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    lcrCto_seccon_cont = lobReg["cto_seccon_cont"].ToString().Trim();
                    lcrSia_codeps_teps = lobReg["sia_codeps_teps"].ToString().Trim();
                    llgSiCumpleFiltro = flgSiFiltroAvanzado(lcrCto_seccon_cont, lcrSia_codeps_teps);

                    if (llgSiCumpleFiltro == true)
                    {
                        #region gestion de datos
                        lcrFcm_fecfac_dfac = Funciones.fcrConvertFecha(Funciones.fdaConvertFecha("DMY", "/", lobReg["fcm_fecfac_mfac"].ToString()));
                        // Generar cada registro detalle servicio
                        lcrPlanoLineaRegTexto = lcIndex.ToString().Trim() + lcrSeparador +
                                                lobReg["adm_caucon_rgad"].ToString().Trim() + lcrSeparador +
                                                lobReg["adm_nroaut_rgad"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_tipide_tide"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_nroide_usua"].ToString().Trim() + lcrSeparador +
                                                lcrFcm_fecfac_dfac.Trim() + lcrSeparador +
                                                lobReg["fcm_codser_mant"].ToString().Trim() + lcrSeparador +
                                                lobReg["fcm_desser_dfac"].ToString().Trim() + lcrSeparador +
                                                lobReg["fcm_totuni_dfac"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_deseps_teps"].ToString().Trim() + lcrSeparador +
                                                lobReg["fcm_valfac_dfac"].ToString().Trim();

                        lcrPlanoLineaSumaTotal1 = String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal1) ? lcrPlanoLineaRegTexto : lcrPlanoLineaSumaTotal1 + "\r\n" + lcrPlanoLineaRegTexto;
                        #endregion
                        lcIndex++;
                    }
                }
                if (!String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal1))
                {
                    // Titulo general
                    String tcrFechaRango = " PERIODO: " + this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                    String lcrRelleno = "-";
                    lcrTextoTitulo = lcrRelleno.PadRight(100, '-') + "\r\n" +
                                    lcrTitulo + tcrFechaRango + "\r\n" +
                                    lcrRelleno.PadRight(100, '-');
                    #region Titulos de campos
                    lcrTextoTitulo += "\r\n" +
                                    "ITEM" + lcrSeparador +
                                    "INGRESO" + lcrSeparador +
                                    "ORDEN.DE.SERVICIO" + lcrSeparador +
                                    "TIPO.ID" + lcrSeparador +
                                    "NUMERO.IDENTIFIC" + lcrSeparador +
                                    "FECHA" + lcrSeparador +
                                    "CODIGO" + lcrSeparador +
                                    "NOMBRE.SERVICIO" + lcrSeparador +
                                    "CANTIDAD" + lcrSeparador +
                                    "ENTIDAD" + lcrSeparador +
                                    "VALOR.TOTAL";
                    #endregion
                }
            }
            #endregion
            lcrPlanoLineaSumaTotal = lcrTextoTitulo + "\r\n" + lcrPlanoLineaSumaTotal1;

            return lcrPlanoLineaSumaTotal;
        }
        #endregion
        #region fcrGuardarDatosInformeR10: Oportunidad por empresa
        /// <summary>
        /// <para>Oportunidad por empresa</para>
        /// </summary>
        public String fcrGuardarDatosInformeR10(String tdaFechaIni, String tdaFechaFin)
        {
            #region Gestion de datos
            var lcrPlanoLineaRegTexto = String.Empty;
            var lcrPlanoLineaSumaTotal = String.Empty;
            var lcrPlanoLineaSumaTotal1 = String.Empty;
            var lcrSeparador = "|";
            var lcrTextoTitulo = String.Empty;
            var lcrTitulo = "OPRTUNIDAD POR EMPRESA";

            var lcrCto_seccon_cont = String.Empty;
            var lcrSia_codeps_teps = String.Empty;

            var lcrFcm_fecfac_dfac = String.Empty;
            var lcrsia_fecnac_usua = String.Empty;
            var llgSiCumpleFiltro = true;
            var lcIndex = 1;
            #endregion
            var lobParam = new ESTUtilidades.RegistroResumen();
            // Ejecutar la consulta SQL
            #region informe general
            tmpConsulta = flstConsultarDatos("INF10", tdaFechaIni, tdaFechaFin);
            if (tmpConsulta != null)
            {
                tmpResumen = new List<ClasseTmpResumen>();
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    lcrCto_seccon_cont = lobReg["cto_seccon_cont"].ToString().Trim();
                    lcrSia_codeps_teps = lobReg["sia_codeps_teps"].ToString().Trim();
                    llgSiCumpleFiltro = flgSiFiltroAvanzado(lcrCto_seccon_cont, lcrSia_codeps_teps);

                    if (llgSiCumpleFiltro == true)
                    {
                        #region gestion de datos
                        lcrFcm_fecfac_dfac = Funciones.fcrConvertFecha(Funciones.fdaConvertFecha("DMY", "/", lobReg["fcm_fecfac_mfac"].ToString()));
                        lcrsia_fecnac_usua = Funciones.fcrConvertFecha(Funciones.fdaConvertFecha("DMY", "/", lobReg["sia_fecnac_usua"].ToString()));

                        // Generar cada registro detalle servicio
                        lcrPlanoLineaRegTexto = lobReg["sia_tipide_tide"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_nroide_usua"].ToString().Trim() + lcrSeparador +
                                                lcrsia_fecnac_usua.Trim() + lcrSeparador +
                                                lobReg["sis_dessex_sexo"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_priape_usua"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_segape_usua"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_prinom_usua"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_segnom_usua"].ToString().Trim() + lcrSeparador +
                                                lobReg["fcm_codser_mant"].ToString().Trim() + lcrSeparador +
                                                lcrFcm_fecfac_dfac.Trim() + lcrSeparador +
                                                "SI" + lcrSeparador +
                                                lcrFcm_fecfac_dfac.Trim() + lcrSeparador +
                                                lcrFcm_fecfac_dfac.Trim() + lcrSeparador;

                        lcrPlanoLineaSumaTotal1 = String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal1) ? lcrPlanoLineaRegTexto : lcrPlanoLineaSumaTotal1 + "\r\n" + lcrPlanoLineaRegTexto;
                        #endregion
                        lcIndex++;
                    }
                }
                if (!String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal1))
                {
                    // Titulo general
                    String tcrFechaRango = " PERIODO: " + this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                    String lcrRelleno = "-";
                    lcrTextoTitulo = lcrRelleno.PadRight(100, '-') + "\r\n" +
                                    lcrTitulo + tcrFechaRango + "\r\n" +
                                    lcrRelleno.PadRight(100, '-');
                    #region Titulos de campos
                    lcrTextoTitulo += "\r\n" +
                                    "TIPO.ID" + lcrSeparador +
                                    "IDENTIFICACION" + lcrSeparador +
                                    "FECHA.NACIMIENTO" + lcrSeparador +
                                    "SEXO" + lcrSeparador +
                                    "P.APELLIDO" + lcrSeparador +
                                    "S.APELLIDO" + lcrSeparador +
                                    "P.NOMBRE" + lcrSeparador +
                                    "S.NOMBRE" + lcrSeparador +
                                    "SERVICIO" + lcrSeparador +
                                    "FECHA.ADMISION" + lcrSeparador +
                                    "ADMISION" + lcrSeparador +
                                    "FECHA.REALIZACION" + lcrSeparador +
                                    "FECHA.FINALIZACION";
                    #endregion
                }
            }
            #endregion
            lcrPlanoLineaSumaTotal = lcrTextoTitulo + "\r\n" + lcrPlanoLineaSumaTotal1;

            return lcrPlanoLineaSumaTotal;
        }
        #endregion
        #region fcrGuardarDatosInformeR11: Indicadores de calidad
        /// <summary>
        /// <para>Indicadores de calidad</para>
        /// </summary>
        public String fcrGuardarDatosInformeR11(String tdaFechaIni, String tdaFechaFin)
        {
            #region Gestion de datos
            var lcrPlanoLineaRegTexto = String.Empty;
            var lcrPlanoLineaSumaTotal = String.Empty;
            var lcrPlanoLineaSumaTotal1 = String.Empty;
            var lcrSeparador = "|";
            var lcrTextoTitulo = String.Empty;
            var lcrTitulo = "INDICADORES DE CALIDAD";

            var lcrCto_seccon_cont = String.Empty;
            var lcrSia_codeps_teps = String.Empty;

            var lcrFcm_fecfac_dfac = String.Empty;
            var lcrsia_fecnac_usua = String.Empty;
            var llgSiCumpleFiltro = true;
            var lcIndex = 1;
            #endregion
            var lobParam = new ESTUtilidades.RegistroResumen();
            // Ejecutar la consulta SQL
            #region informe general
            tmpConsulta = flstConsultarDatos("INF11", tdaFechaIni, tdaFechaFin);
            if (tmpConsulta != null)
            {
                tmpResumen = new List<ClasseTmpResumen>();
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    lcrCto_seccon_cont = lobReg["cto_seccon_cont"].ToString().Trim();
                    lcrSia_codeps_teps = lobReg["sia_codeps_teps"].ToString().Trim();
                    llgSiCumpleFiltro = flgSiFiltroAvanzado(lcrCto_seccon_cont, lcrSia_codeps_teps);

                    if (llgSiCumpleFiltro == true)
                    {
                        #region gestion de datos
                        lcrFcm_fecfac_dfac = Funciones.fcrConvertFecha(Funciones.fdaConvertFecha("DMY", "/", lobReg["fcm_fecfac_mfac"].ToString()));
                        lcrsia_fecnac_usua = Funciones.fcrConvertFecha(Funciones.fdaConvertFecha("DMY", "/", lobReg["sia_fecnac_usua"].ToString()));

                        // Generar cada registro detalle servicio
                        lcrPlanoLineaRegTexto = lcIndex.ToString().Trim() + lcrSeparador +
                                                lobReg["sia_tipide_tide"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_nroide_usua"].ToString().Trim() + lcrSeparador +
                                                lcrFcm_fecfac_dfac.Trim() + lcrSeparador +
                                                lobReg["fcm_codser_mant"].ToString().Trim() + lcrSeparador +
                                                lobReg["fcm_desser_dfac"].ToString().Trim() + lcrSeparador +
                                                lobReg["fcm_totuni_dfac"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_deseps_teps"].ToString().Trim();

                        lcrPlanoLineaSumaTotal1 = String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal1) ? lcrPlanoLineaRegTexto : lcrPlanoLineaSumaTotal1 + "\r\n" + lcrPlanoLineaRegTexto;
                        #endregion
                        lcIndex++;
                    }
                }
                if (!String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal1))
                {
                    // Titulo general
                    String tcrFechaRango = " PERIODO: " + this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                    String lcrRelleno = "-";
                    lcrTextoTitulo = lcrRelleno.PadRight(100, '-') + "\r\n" +
                                    lcrTitulo + tcrFechaRango + "\r\n" +
                                    lcrRelleno.PadRight(100, '-');
                    #region Titulos de campos
                    lcrTextoTitulo += "\r\n" +
                                    "ITEM" + lcrSeparador +
                                    "TIPO.ID" + lcrSeparador +
                                    "IDENTIFICACION" + lcrSeparador +
                                    "FECHA.SERVICIO" + lcrSeparador +
                                    "CODIGO" + lcrSeparador +
                                    "SERVICIO" + lcrSeparador +
                                    "CANTIDAD" + lcrSeparador +
                                    "ENTIDAD";
                    #endregion
                }
            }
            #endregion
            lcrPlanoLineaSumaTotal = lcrTextoTitulo + "\r\n" + lcrPlanoLineaSumaTotal1;

            return lcrPlanoLineaSumaTotal;
        }
        #endregion
        #region fcrGuardarDatosInformeR12: Facturación por centro de producción
        /// <summary>
        /// <para>Facturación por centro de producción</para>
        /// </summary>
        public String fcrGuardarDatosInformeR12(String tdaFechaIni, String tdaFechaFin)
        {
            #region Gestion de datos
            var lcrPlanoLineaRegTexto = String.Empty;
            var lcrPlanoLineaSumaTotal = String.Empty;
            var lcrPlanoLineaSumaTotal1 = String.Empty;
            var lcrPlanoLineaCenProducc = String.Empty;
            var lcrSeparador = "|";
            var lcrTextoTitulo = String.Empty;
            var lcrTitulo = "FACTURACIÓN POR CENTROS DE PRODUCCIÓN";

            var lcrCto_seccon_cont = String.Empty;
            var lcrSia_codeps_teps = String.Empty;
            var lcrFcm_codcpr_cpro = "XX";

            var lcrFcm_fecfac_dfac = String.Empty;
            var lcrsia_fecnac_usua = String.Empty;
            var llgSiCumpleFiltro = true;
            var lcIndex = 1;
            #endregion
            var lobParam = new ESTUtilidades.RegistroResumen();
            // Ejecutar la consulta SQL
            #region informe general
            tmpConsulta = flstConsultarDatos("INF11", tdaFechaIni, tdaFechaFin);
            if (tmpConsulta != null)
            {
                tmpResumen = new List<ClasseTmpResumen>();
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    lcrCto_seccon_cont = lobReg["cto_seccon_cont"].ToString().Trim();
                    lcrSia_codeps_teps = lobReg["sia_codeps_teps"].ToString().Trim();
                    llgSiCumpleFiltro = flgSiFiltroAvanzado(lcrCto_seccon_cont, lcrSia_codeps_teps);

                    if (llgSiCumpleFiltro == true)
                    {
                        #region gestion de datos
                        lcrFcm_fecfac_dfac = Funciones.fcrConvertFecha(Funciones.fdaConvertFecha("DMY", "/", lobReg["fcm_fecfac_mfac"].ToString()));
                        lcrsia_fecnac_usua = Funciones.fcrConvertFecha(Funciones.fdaConvertFecha("DMY", "/", lobReg["sia_fecnac_usua"].ToString()));

                        lcrPlanoLineaCenProducc = String.Empty;
                        if (lcrFcm_codcpr_cpro != lobReg["fcm_codcpr_cpro"].ToString().Trim())
                        {
                            lcrPlanoLineaCenProducc = lobReg["fcm_descpr_cpro"].ToString().Trim() + "\r\n";
                        }

                        // Generar cada registro detalle servicio
                        lcrPlanoLineaRegTexto = lcrPlanoLineaCenProducc + lcIndex.ToString().Trim() + lcrSeparador +
                                                lobReg["sia_priape_usua"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_segape_usua"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_prinom_usua"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_segnom_usua"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_nroide_usua"].ToString().Trim() + lcrSeparador +
                                                lobReg["sia_deseps_teps"].ToString().Trim() + lcrSeparador +
                                                lobReg["fcm_codser_mant"].ToString().Trim() + lcrSeparador +
                                                lobReg["fcm_desser_dfac"].ToString().Trim() + lcrSeparador +
                                                lobReg["fcm_totuni_dfac"].ToString().Trim() + lcrSeparador +
                                                lobReg["fcm_valfac_dfac"].ToString().Trim();

                        lcrPlanoLineaSumaTotal1 = String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal1) ? lcrPlanoLineaRegTexto : lcrPlanoLineaSumaTotal1 + "\r\n" + lcrPlanoLineaRegTexto;
                        #endregion

                        lcrFcm_codcpr_cpro = lobReg["fcm_codcpr_cpro"].ToString().Trim();
                        lcIndex++;
                    }
                }
                if (!String.IsNullOrWhiteSpace(lcrPlanoLineaSumaTotal1))
                {
                    // Titulo general
                    String tcrFechaRango = " PERIODO: " + this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                    String lcrRelleno = "-";
                    lcrTextoTitulo = lcrRelleno.PadRight(100, '-') + "\r\n" +
                                    lcrTitulo + tcrFechaRango + "\r\n" +
                                    lcrRelleno.PadRight(100, '-');
                    #region Titulos de campos
                    lcrTextoTitulo += "\r\n" +
                                    "ITEM" + lcrSeparador +
                                    "P.APELLIDO" + lcrSeparador +
                                    "S.APELLIDO" + lcrSeparador +
                                    "P.NOMBRE" + lcrSeparador +
                                    "S.NOMBRE" + lcrSeparador +
                                    "IDENTIFICACION" + lcrSeparador +
                                    "ENTIDAD" + lcrSeparador +
                                    "CODIGO" + lcrSeparador +
                                    "SERVICIO" + lcrSeparador +
                                    "CANTIDAD" + lcrSeparador +
                                    "VALOR";
                    #endregion
                }
            }
            #endregion
            lcrPlanoLineaSumaTotal = lcrTextoTitulo + "\r\n" + lcrPlanoLineaSumaTotal1;

            return lcrPlanoLineaSumaTotal;
        }
        #endregion
        #region fcrGuardarDatosInformeR13: Resumen por contrato EPS y Clasificacion
        /// <summary>
        /// <para>Resumen por contrato EPS y Clasificacion</para>
        /// </summary>
        public String fcrGuardarDatosInformeR13(String tdaFechaIni, String tdaFechaFin)
        {
            #region Gestion de datos
            var lcrSeparador = "|";
            String lcrPlanoLineaRegTexto;
            String lcrTextoTituloGeneral = String.Empty;
            String lcrPlanoLineaSumaTotal = String.Empty;
            String lcrTextoTituloGrupo;
            String lcrTextoTituloSubGrupo;
            String lcrTextoDatosRegistro;
            String lcrTextoTotalSubGrupoAnterior;
            int lnuTotalSubGrupo = 0;
            // Datos del grupo
            String lcrCto_seccon_cont;
            String lcrCto_nrocon_cont;
            String lcrSia_codeps_teps;
            String lcrSia_deseps_teps;
            String lcrFcm_idesec_fcct;
            String lcrFcm_descat_fcct;
            // Datos del registro
            String lcrFcm_coddig_mant;
            String lcrFcm_codser_mant;
            String lcrFcm_desser_dfac;
            int lnuFcm_totuni_dfac;
            int lnuFcm_valser_mant;
            int lnuFcm_valfac_dfac;
            bool llgSiCumpleFiltro;
            #endregion
            var lobParam = new ESTUtilidades.RegistroResumen();
            // Cantidades y valores por contrato eps y claificacion servicios
            #region Gestion de datos
            tmpConsulta = flstConsultarDatos("INF13", tdaFechaIni, tdaFechaFin);

            if (tmpConsulta != null)
            {
                tmpResumen = new List<ClasseTmpResumen>();
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    // Daos del grupo: lcrCto_seccon_cont+ lcrSia_codeps_teps + lcrFcm_idesec_fcct
                    lcrCto_seccon_cont = lobReg["cto_seccon_cont"].ToString().Trim();
                    lcrCto_nrocon_cont = lobReg["cto_nrocon_cont"].ToString().Trim();
                    lcrSia_codeps_teps = lobReg["sia_codeps_teps"].ToString().Trim();
                    lcrSia_deseps_teps = lobReg["sia_deseps_teps"].ToString().Trim();
                    lcrFcm_idesec_fcct = lobReg["fcm_idesec_fcct"].ToString().Trim(); // Codigo clasificacion servicios
                    lcrFcm_descat_fcct = lobReg["fcm_descat_fcct"].ToString().Trim(); // Descripcion clasificacion servicios

                    llgSiCumpleFiltro = flgSiFiltroAvanzado(lcrCto_seccon_cont, lcrSia_codeps_teps);

                    if (llgSiCumpleFiltro == true)
                    {
                        #region Gestion de datos del registro
                        lcrFcm_coddig_mant = lobReg["fcm_coddig_mant"].ToString().Trim(); // Codigo de digitacion 
                        lcrFcm_codser_mant = lobReg["fcm_codser_mant"].ToString().Trim(); // Codigo servicio en tarifario
                        lcrFcm_desser_dfac = lobReg["fcm_desser_dfac"].ToString().Trim(); // Descripcion servicio
                        lnuFcm_totuni_dfac = Convert.ToInt32(lobReg["fcm_totuni_dfac"].ToString());
                        lnuFcm_valser_mant = Convert.ToInt32(lobReg["fcm_valser_mant"].ToString());
                        lnuFcm_valfac_dfac = Convert.ToInt32(lobReg["fcm_valfac_dfac"].ToString());
                        #endregion
                        //---------------------------------------------------------
                        //- 12 VALORES PRODUCCION MENSUAL POR CENTROS DE PRODUCCION y EPS
                        //---------------------------------------------------------
                        #region CONTRATO EPS Y CLASIFICACION SERVICIOS
                        // Grupo Contrato y EPS
                        lobParam.GrupoId = lcrCto_seccon_cont + "X" + lcrSia_codeps_teps;
                        lobParam.GrupoTitulo = lcrCto_nrocon_cont + " - " + lcrSia_deseps_teps;
                        lobParam.GrupoOrdenVista = 12;
                        //lobParam.Parametro1       = lcrSia_tipusu_regi;
                        #region Resumen por contrato eps y area de servicios
                        // Sub grupo  - Clasificacion serivicios
                        lobParam.RegistroCodigo = lobParam.GrupoId + "X" + lcrFcm_idesec_fcct; // llave el subgrupo
                        lobParam.RegistroTitulo = lcrFcm_descat_fcct; // Titulo subgrupo
                        // Registro del servicio como tal
                        lobParam.Registrollave = lobParam.Registrollave + "X" + lcrFcm_coddig_mant; // llave unica registro
                        lobParam.RegistroCodigo1 = lcrFcm_coddig_mant;
                        lobParam.RegistroCodigo2 = lcrFcm_codser_mant;
                        lobParam.RegistroTitulo1 = lcrFcm_desser_dfac;
                        lobParam.RegistroOrdVista = 1;
                        fcvGenRegGrupoResumContratoEpsClasific(lobParam, lnuFcm_totuni_dfac, lnuFcm_valser_mant, lnuFcm_valfac_dfac);
                        #endregion
                        #endregion
                    }
                }
            }
            #endregion
            // Gestion Resumen formato texto
            #region Generar Texto resumen
            if (tmpResumen != null)
            {
                //----------------------------------------------------------------
                // 2 - Generar Vista 
                //----------------------------------------------------------------
                #region Gestion de datos 
                String tcrFechaRango = this.txtG1FechaInicial.Text + " - " + this.txtG1FechaFinal.Text;
                String lcrRelleno = "-";
                lcrTextoTituloGeneral = lcrRelleno.PadRight(100, '-') + "\r\n" +
                                        " RESUMEN CONTRATO EPS Y CLASIFICACION SERVICIOS : " + tcrFechaRango + "\r\n" +
                                        lcrRelleno.PadRight(100, '-') + "\r\n";

                lnuTotalSubGrupo = 0;
                foreach (var lobReg in tmpResumen)
                {
                    #region gestion de datos

                    // Antes de cambiar el subgrupo poner el valor total del anterior
                    #region Valor total del SubGrupo
                    lcrTextoTotalSubGrupoAnterior = string.Empty;
                    if ((lobReg.GrupoTipo == "SUBGRUPO" || lobReg.GrupoTipo == "GRUPO") && lnuTotalSubGrupo > 0)
                    {
                        lcrTextoTotalSubGrupoAnterior = lcrSeparador +
                                                        "TOTAL" +
                                                        lcrSeparador +
                                                        lcrSeparador +
                                                        lcrSeparador +
                                                        lnuTotalSubGrupo.ToString().Trim() +
                                                        lcrSeparador +
                                                        "XXTOTAL" + "\r\n";
                        lnuTotalSubGrupo = 0; // para que no se repita
                    }
                    #endregion

                    // Titulo del grupo (contrato y Nombre Eps)
                    #region Titulo Grupo
                    lcrTextoTituloGrupo = string.Empty;
                    if (lobReg.GrupoTipo == "GRUPO")
                    {
                        // Buscar en el resumen de la primera parte los valores totales del centro de produccion
                        //var lcrGrup = tmpResumen.FirstOrDefault(x => x.GrupoIdRegistro == "RESUMEN" && x.RegistroCodigo == lobReg.RegistroCodigo);
                        lcrTextoTituloGrupo = lobReg.GrupoTitulo.Trim() +
                                              lcrSeparador +
                                              lcrSeparador +
                                              lcrSeparador +
                                              lcrSeparador +
                                              lcrSeparador +
                                              "XXGRUPO" + "\r\n";  // XXXX es una marca de guia para color en excel
                    }
                    #endregion

                    // Titulo Subgrupo (Clasificación de servicios)
                    #region Titulo SubGrupo
                    lcrTextoTituloSubGrupo = string.Empty;
                    if (lobReg.GrupoTipo == "SUBGRUPO")
                    {
                        // Buscar en el resumen de la primera parte los valores totales del centro de produccion
                        //var lcrGrup = tmpResumen.FirstOrDefault(x => x.GrupoIdRegistro == "RESUMEN" && x.RegistroCodigo == lobReg.RegistroCodigo);
                        lnuTotalSubGrupo = lobReg.TotalGrupo1;
                        var lcrTitulo1 = lobReg.RegistroTitulo.Trim() +
                                         lcrSeparador +
                                         lcrSeparador +
                                         lcrSeparador +
                                         lcrSeparador +
                                         lcrSeparador +
                                         "XXSUBGRUPO" + "\r\n";

                        var lcrTitulo2 = "CODIGO" + lcrSeparador +
                                         "NOMBRE DEL SERVICIO" + lcrSeparador +
                                         "VALOR UNITARIO" + lcrSeparador +
                                         "CANTIDAD" + lcrSeparador +
                                         "VALOR TOTAL" + lcrSeparador +
                                         "XXTITULOREGISTRO" + "\r\n";

                        lcrTextoTituloSubGrupo = lcrTitulo1 + lcrTitulo2;
                    }
                    #endregion

                    // Generar cada registro detalle servicio
                    #region Generar Registro
                    lcrTextoDatosRegistro = string.Empty;
                    if (lobReg.GrupoTipo == "REGISTRO")
                    {
                        lcrTextoDatosRegistro = lobReg.RegistroCodigo1.Trim() + lcrSeparador +
                                                lobReg.RegistroTitulo1.Trim() + lcrSeparador +
                                                lobReg.Total1.ToString().Trim() + lcrSeparador +
                                                lobReg.Valor1.ToString().Trim() + lcrSeparador +
                                                lobReg.Total2.ToString().Trim() + lcrSeparador +
                                                "XXREGISTRO" + "\r\n";
                    }
                    #endregion

                    lcrPlanoLineaRegTexto = lcrTextoTotalSubGrupoAnterior +
                                            lcrTextoTituloGrupo +
                                            lcrTextoTituloSubGrupo +
                                            lcrTextoDatosRegistro;

                    lcrPlanoLineaSumaTotal += lcrPlanoLineaRegTexto;

                    lcrTextoTotalSubGrupoAnterior = string.Empty; // para evitar que se repita
                    #endregion
                }
                #endregion
                #region ultimo Valor total del SubGrupo
                if (lnuTotalSubGrupo > 0)
                {
                    lcrTextoTotalSubGrupoAnterior = lcrSeparador +
                                                    "TOTAL" +
                                                    lcrSeparador +
                                                    lcrSeparador +
                                                    lcrSeparador +
                                                    lnuTotalSubGrupo.ToString().Trim() +
                                                    lcrSeparador +
                                                    "XXTOTAL" + "\r\n";
                    lcrPlanoLineaSumaTotal += lcrTextoTotalSubGrupoAnterior;
                }
                #endregion

            }
            #endregion
            lcrPlanoLineaSumaTotal = lcrTextoTituloGeneral + lcrPlanoLineaSumaTotal;

            return lcrPlanoLineaSumaTotal;
        }
        #endregion
        // comprobar si cumple filtro avanzado
        #region flgSiFiltroAvanzado: Generar el nombre unico del archivo
        /// <summary>
        /// Generar el nombre unico del archivo
        /// </summary>
        public bool flgSiFiltroAvanzado(String tcrIDContrato, String tcrCodigoEps)
        {
            var llgReturn = true;
            if (this.chkFlitroAvanzado.IsChecked == true)
            {
                llgReturn = lstListSelFiltrFact == null ? false : true;
                if (llgReturn == true)
                {
                    var lcrllava = tcrIDContrato + "X" + tcrCodigoEps;
                    var lobReg = lstListSelFiltrFact.FirstOrDefault(x => x.ValorSeleccion == lcrllava);
                    llgReturn = lobReg == null ? false : true;
                }
            }
            return llgReturn;
        }
        #endregion
        // Generar nombre archivo
        #region fcrGuardarGenerarNombreArchivo: Generar el nombre unico del archivo 
        /// <summary>
        /// Generar el nombre unico del archivo
        /// </summary>
        public String fcrGuardarGenerarNombreArchivo(String tcrNombreArchivoBase)
        {
            gnuContadorvistaArchivos++;

            var lcrNombre = gnuContadorvistaArchivos.ToString().Trim() + "-" + Funciones.fnuFechaLlaveIndiceRegistro().ToString().Trim();
            lcrNombre = tcrNombreArchivoBase + "-" + lcrNombre;

            return lcrNombre;
        }
        #endregion
        //----------------------------------------------------------------------
        // GESTION  RESUMEN GENERAL
        //----------------------------------------------------------------------
        // Generar registro y hacer sumatorias en grupos para la clase ClasseTmpResumen
        #region fcvGenRegGrupoResumCentroProduccion: Generar resumen general centro de produccion
        /// <summary>
        /// <para> Generar resumen general centro de produccion en la clase ClasseTmpResumen</para>
        /// </summary>
        public void fcvGenRegGrupoResumCentroProduccion(ESTUtilidades.RegistroResumen tobParam, int tnuCantidad, int tnuValor)
        {
            var lcrReturn = String.Empty;
            // Buscar en resumen
            tmpRegActivoResumen = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == tobParam.Registrollave);
            if (tmpRegActivoResumen == null)
            {
                tmpRegActivoResumen = new ClasseTmpResumen();
                // Grupo
                tmpRegActivoResumen.GrupoIdRegistro = tobParam.GrupoId;
                tmpRegActivoResumen.GrupoTipo = tobParam.GrupoTipo;
                tmpRegActivoResumen.GrupoOrdenVista = tobParam.GrupoOrdenVista;
                tmpRegActivoResumen.GrupoTitulo = tobParam.GrupoTitulo;
                // Registro
                tmpRegActivoResumen.LlaveRegistro = tobParam.Registrollave; // llave unica
                tmpRegActivoResumen.RegistroCodigo = tobParam.RegistroCodigo;
                tmpRegActivoResumen.RegistroCodigo1 = tobParam.RegistroCodigo1;
                tmpRegActivoResumen.RegistroCodigo2 = tobParam.RegistroCodigo2;
                tmpRegActivoResumen.RegistroCodigo3 = tobParam.RegistroCodigo3;
                tmpRegActivoResumen.RegistroTitulo = tobParam.RegistroTitulo;
                tmpRegActivoResumen.RegistroTitulo1 = tobParam.RegistroTitulo1;
                tmpRegActivoResumen.RegistroTitulo2 = tobParam.RegistroTitulo2;
                tmpRegActivoResumen.RegistroOrdenVista = tobParam.RegistroOrdVista;

                tmpResumen.Add(tmpRegActivoResumen);
            }
            // Generar datos
            // 1 = Contributivo 2 = Subsidiado 3 = Vinculado 4 = Particular 5 = Otro
            switch (tobParam.Parametro1)
            {
                case "1": // Contributivo
                    tmpRegActivoResumen.Valor1 += tnuCantidad;
                    break;

                case "2": // Subsidiado
                    tmpRegActivoResumen.Valor2 += tnuCantidad;
                    break;

                case "3": // Vinculados Poblacion pobre no asegurada
                    tmpRegActivoResumen.Valor3 += tnuCantidad;
                    break;

                case "4": // Particulares
                    tmpRegActivoResumen.Valor4 += tnuCantidad;
                    break;

                default: // Otros
                    tmpRegActivoResumen.Valor5 += tnuCantidad;
                    break;
            }
            tmpRegActivoResumen.Total1 += tnuCantidad;
            tmpRegActivoResumen.Total2 += tnuValor;

        }
        #endregion
        #region fcrGenRegGrupoEtareoResumenAños: Generar datos para resumen general (multi proposito) por grupos etareos edead en años
        /// <summary>
        /// <para> Generar datos resumen general (multi proposito) por grupos etareos clase ClasseTmpResumen</para>
        /// <para> devuelve el codigo del grupo etareo al que fue agregado o actualizado el registro</para>
        /// </summary>
        public String fcrGenRegGrupoEtareoResumenAños(ESTUtilidades.RegistroResumen tobParam, int tnuEdadAños, String tcSexo, int tnuValor)
        {
            var lcrReturn = String.Empty;
            // Buscar en resumen
            tmpRegActivoResumen = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == tobParam.Registrollave);
            if (tmpRegActivoResumen == null)
            {
                tmpRegActivoResumen = new ClasseTmpResumen();
                // Grupo
                tmpRegActivoResumen.GrupoIdRegistro = tobParam.GrupoId;
                tmpRegActivoResumen.GrupoOrdenVista = tobParam.GrupoOrdenVista;
                tmpRegActivoResumen.GrupoTitulo = tobParam.GrupoTitulo;
                // Registro
                tmpRegActivoResumen.LlaveRegistro = tobParam.Registrollave; // llave unica
                tmpRegActivoResumen.RegistroCodigo = tobParam.RegistroCodigo;
                tmpRegActivoResumen.RegistroTitulo = tobParam.RegistroTitulo;
                tmpRegActivoResumen.RegistroTitulo1 = tobParam.RegistroTitulo1;
                tmpRegActivoResumen.RegistroTitulo2 = tobParam.RegistroTitulo2;
                tmpRegActivoResumen.RegistroOrdenVista = tobParam.RegistroOrdVista;

                tmpResumen.Add(tmpRegActivoResumen);
            }
            // Generar datos
            lcrReturn = ESTUtilidades.fcrGuardarDatosGrupoEtareosAños(tnuEdadAños, tcSexo, ref tmpRegActivoResumen, tnuValor);
            return lcrReturn;
        }
        #endregion
        #region fcrGenRegGrupoEtareoAdmisionAños: Generar datos para resumen por grupos etareos edead en años
        /// <summary>
        /// <para> Generar datos para resumen por grupos etareos y otros para la clase ClasseTmpResumen</para>
        /// <para> devuelve el codigo del grupo etareo al que fue agregado o actualizado el registro</para>
        /// </summary>
        public String fcrGenRegGrupoEtareoAdmisionAños(ESTUtilidades.RegistroResumen tobParam, int tnuEdadAños, String tcSexo, int tnuValor)
        {
            var lcrReturn = String.Empty;
            // Buscar en resumen
            tmpRegActivoResumen = tmpAdmResumen.FirstOrDefault(x => x.LlaveRegistro == tobParam.Registrollave);
            if (tmpRegActivoResumen == null)
            {
                tmpRegActivoResumen = new ClasseTmpResumen();
                // Grupo
                tmpRegActivoResumen.GrupoIdRegistro = tobParam.GrupoId;
                tmpRegActivoResumen.GrupoOrdenVista = tobParam.GrupoOrdenVista;
                tmpRegActivoResumen.GrupoTitulo = tobParam.GrupoTitulo;
                // Registro
                tmpRegActivoResumen.LlaveRegistro = tobParam.Registrollave; // llave unica
                tmpRegActivoResumen.RegistroCodigo = tobParam.RegistroCodigo;
                tmpRegActivoResumen.RegistroTitulo = tobParam.RegistroTitulo;
                tmpRegActivoResumen.RegistroTitulo1 = tobParam.RegistroTitulo1;
                tmpRegActivoResumen.RegistroTitulo2 = tobParam.RegistroTitulo2;
                tmpRegActivoResumen.RegistroOrdenVista = tobParam.RegistroOrdVista;

                tmpAdmResumen.Add(tmpRegActivoResumen);
            }
            // Generar datos
            lcrReturn = ESTUtilidades.fcrGuardarDatosGrupoEtareosAños(tnuEdadAños, tcSexo, ref tmpRegActivoResumen, tnuValor);
            return lcrReturn;
        }
        #endregion
        #region fcrGenRegGrupoAreaServicios: Generar datos para resumen por area de servicios
        /// <summary>
        /// <para> Generar datos para resumen por Area prestacion servicios de la clase ClasseTmpResumen</para>
        /// <para> devuelve el codigo del grupo al que fue agregado o actualizado el registro</para>
        /// </summary>
        public String fcrGenRegGrupoAreaServicios(ESTUtilidades.RegistroResumen tobParam, String tcrCodigoCentProduccion, String tcrCodigoDigitacion, int tnuValor)
        {
            var lcrReturn = String.Empty;
            // Buscar en resumen
            tmpRegActivoResumen = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == tobParam.Registrollave);
            if (tmpRegActivoResumen == null)
            {
                tmpRegActivoResumen = new ClasseTmpResumen();
                // Grupo
                tmpRegActivoResumen.GrupoIdRegistro = tobParam.GrupoId;
                tmpRegActivoResumen.GrupoTipo = tobParam.GrupoTipo;
                tmpRegActivoResumen.GrupoOrdenVista = tobParam.GrupoOrdenVista;
                tmpRegActivoResumen.GrupoTitulo = tobParam.GrupoTitulo;
                // Registro
                tmpRegActivoResumen.LlaveRegistro = tobParam.Registrollave; // llave unica
                tmpRegActivoResumen.RegistroCodigo = tobParam.RegistroCodigo;
                tmpRegActivoResumen.RegistroTitulo = tobParam.RegistroTitulo;
                tmpRegActivoResumen.RegistroTitulo1 = tobParam.RegistroTitulo1;
                tmpRegActivoResumen.RegistroTitulo2 = tobParam.RegistroTitulo2;
                tmpRegActivoResumen.RegistroOrdenVista = tobParam.RegistroOrdVista;

                tmpResumen.Add(tmpRegActivoResumen);
            }
            // Generar datos
            lcrReturn = ESTUtilidades.fcrGuardarDatosGrupoAreaServicios(tcrCodigoCentProduccion, tcrCodigoDigitacion, ref tmpRegActivoResumen, tnuValor);
            return lcrReturn;
        }
        #endregion
        #region fcvGenResumenFactServiciosR09: Genera el listado de registros del resumen facturacion informe R09
        /// <summary>
        /// <para> Genera el listado de registros del resumen facturacion informe R09</para>
        /// </summary>
        public void fcvGenResumenFactServiciosR09(ESTUtilidades.RegistroResumen tobParam)
        {
            var lcrReturn = String.Empty;
            // Buscar en resumen
            tmpRegActivoResumen = new ClasseTmpResumen();
            // Grupo
            tmpRegActivoResumen.GrupoIdRegistro = tobParam.GrupoId;
            tmpRegActivoResumen.GrupoTipo = tobParam.GrupoTipo;
            tmpRegActivoResumen.GrupoOrdenVista = tobParam.GrupoOrdenVista;
            tmpRegActivoResumen.GrupoTitulo = tobParam.GrupoTitulo;
            // Registro
            tmpRegActivoResumen.LlaveRegistro = tobParam.Registrollave; // llave unica
            tmpRegActivoResumen.RegistroCodigo = tobParam.RegistroCodigo;
            tmpRegActivoResumen.RegistroTitulo = tobParam.RegistroTitulo;
            tmpRegActivoResumen.RegistroTitulo1 = tobParam.RegistroTitulo1;
            tmpRegActivoResumen.RegistroTitulo2 = tobParam.RegistroTitulo2;
            tmpRegActivoResumen.RegistroOrdenVista = tobParam.RegistroOrdVista;

            tmpResumen.Add(tmpRegActivoResumen);
        }
        #endregion
        #region fcvGenRegGrupoResumContratoEpsClasific: Generar resumen Contrato Eps y clasificación servicios
        /// <summary>
        /// <para> Generar resumen Contrato Eps y clasificación servicios</para>
        /// </summary>
        public void fcvGenRegGrupoResumContratoEpsClasific(ESTUtilidades.RegistroResumen tobParam,
                                                           int tnuCantidad,
                                                           int tnuPrecio,
                                                           int tnuTotal)
        {
            var lcrReturn = String.Empty;

            //-----------------------------------------------------------
            // Registro tipo Grupo
            //-----------------------------------------------------------
            var tmpRegGrupo = tmpResumen.FirstOrDefault(x => x.GrupoIdRegistro == "GRUPO" + tobParam.GrupoId);
            if (tmpRegGrupo == null)
            {
                tmpRegGrupo = new ClasseTmpResumen();
                // Grupo
                tmpRegGrupo.GrupoTipo = "GRUPO";
                tmpRegGrupo.GrupoIdRegistro = "GRUPO" + tobParam.GrupoId;
                tmpRegGrupo.GrupoOrdenVista = tobParam.GrupoOrdenVista;
                tmpRegGrupo.GrupoTitulo = tobParam.GrupoTitulo;

                // Agregar
                tmpResumen.Add(tmpRegGrupo);
            }

            //-----------------------------------------------------------
            // Registro tipo subGrupo
            //-----------------------------------------------------------
            var tmpRegSubGrupo = tmpResumen.FirstOrDefault(x => x.RegistroCodigo == "SUB" + tobParam.RegistroCodigo);
            if (tmpRegSubGrupo == null)
            {
                tmpRegSubGrupo = new ClasseTmpResumen();
                // Grupo
                tmpRegSubGrupo.GrupoIdRegistro = tobParam.GrupoId;
                tmpRegSubGrupo.GrupoOrdenVista = tobParam.GrupoOrdenVista;
                tmpRegSubGrupo.GrupoTitulo = tobParam.GrupoTitulo;
                // sub grupo
                tmpRegSubGrupo.GrupoTipo = "SUBGRUPO";
                tmpRegSubGrupo.RegistroCodigo = "SUB" + tobParam.RegistroCodigo;
                tmpRegSubGrupo.RegistroTitulo = tobParam.RegistroTitulo;

                // Agregar
                tmpResumen.Add(tmpRegSubGrupo);
            }
            tmpRegSubGrupo.TotalGrupo1 += tnuTotal;

            //-----------------------------------------------------------
            // Generar el registro de datos
            //-----------------------------------------------------------
            tmpRegActivoResumen = new ClasseTmpResumen
            {
                // Grupo
                GrupoIdRegistro = tobParam.GrupoId,
                GrupoOrdenVista = tobParam.GrupoOrdenVista,
                GrupoTitulo = tobParam.GrupoTitulo,
                // sub grupo
                RegistroCodigo = tobParam.RegistroCodigo,
                RegistroTitulo = tobParam.RegistroTitulo,
                // Registro
                GrupoTipo = "REGISTRO",
                LlaveRegistro = tobParam.Registrollave, // llave unica
                RegistroCodigo1 = tobParam.RegistroCodigo1,
                RegistroCodigo2 = tobParam.RegistroCodigo2,
                RegistroCodigo3 = tobParam.RegistroCodigo3,
                RegistroTitulo1 = tobParam.RegistroTitulo1,
                RegistroTitulo2 = tobParam.RegistroTitulo2,
                Total1 = tnuPrecio,
                Valor1 = tnuCantidad,
                Total2 = tnuTotal,
                RegistroOrdenVista = tobParam.RegistroOrdVista
            };
            tmpResumen.Add(tmpRegActivoResumen);

        }
        #endregion
        // Generar lineas
        #region fcrGenLineaTextoFormatoAreasServicios: Generar linea texto segun registro formato areas de servicios
        /// <summary>
        /// <para> Generar linea texto segun registro formato areas de servicio</para>
        /// </summary>
        public String fcrGenLineaTextoFormatoAreasServicios(ClasseTmpResumen tobReg, String tcrSeparador)
        {
            var lcrReturn = tobReg.RegistroTitulo.Trim() + tcrSeparador +
                            tobReg.RegistroTitulo1.Trim() + tcrSeparador +
                            tobReg.RegistroTitulo2.Trim() + tcrSeparador +
                            tobReg.Grupo1.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo2.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo3.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo4.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo5.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo6.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo7.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo8.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo9.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo10.ToString().Trim() + tcrSeparador;

            return lcrReturn;
        }
        #endregion
        #region fcrGenLineaTextoFormatoGruposEtareos: Generar linea texto segun registro formato grupos etareos
        /// <summary>
        /// <para> Generar linea texto segun registro formato grupos etareos</para>
        /// </summary>
        public String fcrGenLineaTextoFormatoGruposEtareos(ClasseTmpResumen tobReg, String tcrSeparador)
        {
            var lcrReturn = tobReg.RegistroCodigo.Trim() + tcrSeparador +
                            tobReg.RegistroTitulo.Trim() + tcrSeparador +
                            tobReg.Grupo1.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo2.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo3.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo4.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo5.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo6.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo7.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo8.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo9.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo10.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo11.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo12.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo13.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo14.ToString().Trim() + tcrSeparador +
                            tobReg.Grupo15.ToString().Trim() + tcrSeparador;

            return lcrReturn;
        }
        #endregion
        // Generar registro y hacer sumatorias en grupos etareos del registro
        #region flgGuardarDatosGrupoEtareos: Generar datos para resumen por grupos etareos
        /// <summary>
        /// <para> Generar datos para resumen por grupos etareos</para>
        /// </summary>
        public bool flgGuardarDatosGrupoEtareosxx(int tnuEdad, String tcSexo, ref ClasseTmpResumen lcrRegDat, int tnuValor)
        {
            var llgReturn = true;

            #region Datos del resumen
            // 0 AÑOS MASCULINO
            if (tnuEdad < 1 && tcSexo == "M")
            {
                lcrRegDat.Grupo1 += tnuValor;
            }
            // 0 AÑOS FEMENINO
            if (tnuEdad < 1 && tcSexo == "F")
            {
                lcrRegDat.Grupo2 += tnuValor;
            }
            // 1 a 4 AÑOS MASCULINO
            if (tnuEdad >= 1 && tnuEdad <= 4 && tcSexo == "M")
            {
                lcrRegDat.Grupo3 += tnuValor;
            }
            // 1 a 4 AÑOS FEMENINO
            if (tnuEdad >= 1 && tnuEdad <= 4 && tcSexo == "F")
            {
                lcrRegDat.Grupo4 += tnuValor;
            }
            // 5 a 14 AÑOS MASCULINO
            if (tnuEdad >= 5 && tnuEdad <= 14 && tcSexo == "M")
            {
                lcrRegDat.Grupo5 += tnuValor;
            }
            // 5 a 14 AÑOS FEMENINO
            if (tnuEdad >= 5 && tnuEdad <= 14 && tcSexo == "F")
            {
                lcrRegDat.Grupo6 += tnuValor;
            }
            // 15 a 44 AÑOS MASCULINO
            if (tnuEdad >= 15 && tnuEdad <= 44 && tcSexo == "M")
            {
                lcrRegDat.Grupo7 += tnuValor;
            }
            // 15 a 44 AÑOS FEMENINO
            if (tnuEdad >= 15 && tnuEdad <= 44 && tcSexo == "F")
            {
                lcrRegDat.Grupo8 += tnuValor;
            }
            // 45 a 64 AÑOS MASCULINO
            if (tnuEdad >= 45 && tnuEdad <= 64 && tcSexo == "M")
            {
                lcrRegDat.Grupo9 += tnuValor;
            }
            // 45 a 64 AÑOS FEMENINO
            if (tnuEdad >= 45 && tnuEdad <= 64 && tcSexo == "F")
            {
                lcrRegDat.Grupo10 += tnuValor;
            }
            // MAS DE 65 AÑOS MASCULINO
            if (tnuEdad >= 65 && tcSexo == "M")
            {
                lcrRegDat.Grupo11 += tnuValor;
            }
            // MAS DE 65 AÑOS FEMENINO
            if (tnuEdad >= 65 && tcSexo == "F")
            {
                lcrRegDat.Grupo12 += tnuValor;
            }
            // TOTAL MASCULINO
            if (tcSexo == "M")
            {
                lcrRegDat.Grupo13 += tnuValor;
            }
            // TOTAL FEMENINO
            if (tcSexo == "F")
            {
                lcrRegDat.Grupo14 += tnuValor;
            }
            // TOTAL GENERAL
            lcrRegDat.Grupo15 += tnuValor;
            #endregion
            return llgReturn;
        }
        #endregion
        // Exportar en plano
        #region flgExportarForamtoPlano: Exportar datos a archivo plano
        /// <summary>
        /// <para>Exportar datos a archivo plano</para>
        /// </summary>
        public bool flgExportarForamtoPlano(String tcrNombreArchivo, String tcrTextoPlano)
        {
            var llgReturn = false;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            gcrExportarArchivoNombreyRuta = lcrMisDocs + @"\" + tcrNombreArchivo + ".TXT";

            if (!string.IsNullOrEmpty(gcrExportarArchivoNombreyRuta))
            {
                llgReturn = true;
                System.IO.File.WriteAllText(@gcrExportarArchivoNombreyRuta, tcrTextoPlano, Encoding.UTF8);
            }
            return llgReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //  FILTRO DE TEMPORALES SQL
        //----------------------------------------------------------------------
        #region flstConsultarDatos: Ejecutar consultas para generar temporales de reporte
        /// <summary>
        /// <para>Ejecutar consultas para generar temporales de reporte</para>
        /// </summary>
        public DataTable flstConsultarDatos(String tcrTipoInforme, String tcrFechaIni, String tcrFechaFin)
        {
            DataTable objDatosTabla = new DataTable();
            var lcrLineaSqlSelct = String.Empty;

            switch (tcrTipoInforme)
            {
                case "RSM01A":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;
                case "RSM01B":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF01A":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF01B":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF02":
                    // Consulta admisiones servicios
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF07":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF09":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF10":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF11":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF12":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF13":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;
            }

            return objDatosTabla;
        }
        #endregion
        #region fcrStringSQLInformes: Generar String SQl para las consultas
        /// <summary>
        /// <para>Generar String SQl para las consultas</para>
        /// </summary>
        public String fcrStringSQLInformes(String tcrTipoInforme, String tcrFechaIni, String tcrFechaFin)
        {
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", tcrFechaIni, "YMD", "-");
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", tcrFechaFin, "YMD", "-");
            String lcrLineaSqlSelct = String.Empty;

            switch (tcrTipoInforme)
            {
                case "RSM01A":
                    #region Linea SQl para resumen general Valores y cantidades facturacion
                    lcrLineaSqlSelct = "SELECT fcmmaesfacturas.cto_seccon_cont," +
                                              "fcmmaesfacturas.sia_codeps_teps," +
                                              "fcmmaedetallfac.fcm_codcpr_cpro," +
                                              "fcmcenproduccio.fcm_descpr_cpro," +
                                              "admregadmision.sia_tipusu_regi," +
                                              "SUM(fcmmaedetallfac.fcm_totuni_dfac) AS fcm_totuni_dfac," +
                                              "SUM(fcmmaedetallfac.fcm_valfac_dfac) AS fcm_valfac_dfac " +
                                       "FROM fcmmaedetallfac " +
                                         "INNER JOIN fcmcenproduccio ON (fcmmaedetallfac.fcm_codcpr_cpro = fcmcenproduccio.fcm_codcpr_cpro) " +
                                         "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                         "INNER JOIN admregadmision ON (fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                       "WHERE " +
                                           "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND " +
                                           "(fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                           "(fcmmaesfacturas.fcm_estfac_mfac = '2') " +
                                           "GROUP BY fcmmaesfacturas.cto_seccon_cont,fcmmaesfacturas.sia_codeps_teps," +
                                                     "fcmcenproduccio.fcm_codcpr_cpro,admregadmision.sia_tipusu_regi " +
                                           "ORDER BY fcmcenproduccio.fcm_descpr_cpro";
                    #endregion
                    break;

                case "RSM01B":
                    #region Linea SQl para resumen general Valores y cantidades centros de produccion y servcios
                    lcrLineaSqlSelct = "SELECT fcmmaesfacturas.cto_seccon_cont," +
                                              "fcmmaesfacturas.sia_codeps_teps," +
                                              "fcmmaedetallfac.fcm_codcpr_cpro," +
                                              "fcmcenproduccio.fcm_descpr_cpro," +
                                              "fcmmaedetallfac.fcm_codser_mant," +
                                              "fcmmaedetallfac.fcm_coddig_mant," +
                                              "fcmmaedetallfac.fcm_desser_dfac," +
                                              "admregadmision.sia_tipusu_regi," +
                                              "SUM(fcmmaedetallfac.fcm_totuni_dfac) AS fcm_totuni_dfac," +
                                              "SUM(fcmmaedetallfac.fcm_valfac_dfac) AS fcm_valfac_dfac " +
                                       "FROM fcmmaedetallfac " +
                                         "INNER JOIN fcmcenproduccio ON (fcmmaedetallfac.fcm_codcpr_cpro = fcmcenproduccio.fcm_codcpr_cpro) " +
                                         "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                         "INNER JOIN admregadmision ON (fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                       "WHERE " +
                                           "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND " +
                                           "(fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                           "(fcmmaesfacturas.fcm_estfac_mfac = '2') " +
                                           "GROUP BY fcmmaesfacturas.cto_seccon_cont,fcmmaesfacturas.sia_codeps_teps," +
                                                    "fcmcenproduccio.fcm_codcpr_cpro,fcmmaedetallfac.fcm_coddig_mant, " +
                                                    "admregadmision.sia_tipusu_regi " +
                                           "ORDER BY fcmcenproduccio.fcm_descpr_cpro,fcmmaedetallfac.fcm_desser_dfac";
                    #endregion
                    break;

                case "INF01A":
                    #region Linea SQl para ejecutar Valores facturacion
                    lcrLineaSqlSelct = "SELECT fcmmaesfacturas.cto_seccon_cont," +
                                     "fcmmaesfacturas.cto_nrocon_cont," +
                                     "fcmmaesfacturas.sia_codeps_teps," +
                                     "siatablaeps.sia_deseps_teps," +
                                     "ctomaescontrato.cto_descon_cont," +
                                     "fcmmaedetallfac.fcm_codcpr_cpro," +
                                     "fcmcenproduccio.fcm_descpr_cpro," +
                                     "fcmmaedetallfac.fcm_codser_mant," +
                                     "fcmmaedetallfac.fcm_coddig_mant," +
                                     "fcmmaedetallfac.fcm_desser_dfac," +
                                     "fcmmaedetallfac.fcm_totuni_dfac," +
                                     "fcmmaedetallfac.fcm_valfac_dfac," +
                                     "fcmmaedetallfac.fcm_valdes_dfac," +
                                     "fcmmaedetallfac.fcm_valcpa_dfac," +
                                     "fcmmaedetallfac.fcm_valcmo_dfac," +
                                     "fcmmaedetallfac.fcm_valusu_dfac," +
                                     "fcmmaedetallfac.sia_tipact_tsac," +
                                     "admregadmision.sia_tipusu_regi," +
                                     "siaregimensalud.sia_destip_regi " +
                               "FROM fcmmaedetallfac " +
                                 "INNER JOIN fcmcenproduccio ON (fcmmaedetallfac.fcm_codcpr_cpro = fcmcenproduccio.fcm_codcpr_cpro) " +
                                 "INNER JOIN admregadmision ON (fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                 "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                 "INNER JOIN ctomaescontrato ON (fcmmaesfacturas.cto_seccon_cont = ctomaescontrato.cto_seccon_cont) " +
                                 "INNER JOIN siaregimensalud ON (admregadmision.sia_tipusu_regi = siaregimensalud.sia_tipusu_regi) " +
                                 "INNER JOIN siatablaeps ON (fcmmaesfacturas.sia_codeps_teps = siatablaeps.sia_codeps_teps) " +
                               "WHERE " +
                                   "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND " +
                                   "(fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                   "(fcmmaesfacturas.fcm_estfac_mfac = '2') " +
                                   "ORDER BY ctomaescontrato.cto_seccon_cont, fcmmaedetallfac.sia_codeps_teps,fcmmaedetallfac.fcm_desser_dfac";
                    #endregion
                    break;

                case "INF01B":
                    #region Linea SQl para ejecutar cantidades servicios
                    lcrLineaSqlSelct = "SELECT fcmmaesfacturas.cto_seccon_cont," +
                                     "fcmmaesfacturas.cto_nrocon_cont," +
                                     "fcmmaesfacturas.sia_codeps_teps," +
                                     "siatablaeps.sia_deseps_teps," +
                                     "ctomaescontrato.cto_descon_cont," +
                                     "fcmmaedetallfac.fcm_codcpr_cpro," +
                                     "fcmcenproduccio.fcm_descpr_cpro," +
                                     "fcmmaedetallfac.fcm_codser_mant," +
                                     "fcmmaedetallfac.fcm_coddig_mant," +
                                     "fcmmaedetallfac.fcm_desser_dfac," +
                                     "fcmmaedetallfac.fcm_totuni_dfac," +
                                     "fcmmaedetallfac.fcm_valfac_dfac," +
                                     "fcmmaedetallfac.fcm_valdes_dfac," +
                                     "fcmmaedetallfac.fcm_valcpa_dfac," +
                                     "fcmmaedetallfac.fcm_valcmo_dfac," +
                                     "fcmmaedetallfac.fcm_valusu_dfac," +
                                     "fcmmaedetallfac.sia_tipact_tsac," +
                                     "admregadmision.sia_tipusu_regi," +
                                     "siaregimensalud.sia_destip_regi " +
                               "FROM " +
                                 "fcmmaedetallfac " +
                                 "INNER JOIN ctomaescontrato ON (fcmmaedetallfac.cto_seccon_cont = ctomaescontrato.cto_seccon_cont) " +
                                 "INNER JOIN fcmcenproduccio ON (fcmmaedetallfac.fcm_codcpr_cpro = fcmcenproduccio.fcm_codcpr_cpro) " +
                                 "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                 "INNER JOIN admregadmision ON(fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                 "INNER JOIN siaregimensalud ON (admregadmision.sia_tipusu_regi = siaregimensalud.sia_tipusu_regi) " +
                                 "INNER JOIN siatablaeps ON (fcmmaedetallfac.sia_codeps_teps = siatablaeps.sia_codeps_teps) " +
                               "WHERE " +
                                   "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND " +
                                   "(fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                   "(fcmmaesfacturas.fcm_estfac_mfac = '2') " +
                                   "ORDER BY ctomaescontrato.cto_seccon_cont, fcmmaedetallfac.sia_codeps_teps,fcmmaedetallfac.fcm_desser_dfac";
                    #endregion
                    break;

                case "INF02":
                    #region Linea SQl admisiones involucradas en servicios prestados
                    lcrLineaSqlSelct = "SELECT admregadmision.adm_secadm_rgad," +
                                  "admregadmision.adm_fecadm_rgad," +
                                  "admregadmision.sia_tipide_tide," +
                                  "admregadmision.sia_nroide_usua," +
                                  "siausuarioatend.sia_priape_usua," +
                                  "siausuarioatend.sia_segape_usua," +
                                  "siausuarioatend.sia_prinom_usua," +
                                  "siausuarioatend.sia_segnom_usua," +
                                  "siausuarioatend.sia_fecnac_usua," +
                                  "siausuarioatend.sis_codsex_sexo," +
                                  "admregadmision.sia_edaano_usua," +
                                  "admregadmision.sia_edames_usua," +
                                  "admregadmision.sia_edadia_usua," +
                                  "admregadmision.sia_edaymd_usua," +
                                  "admregadmision.sia_tipusu_regi," +
                                  "admregadmision.adm_pacemb_rgad," +
                                  "admregadmision.cit_codasi_mcit," +
                                  "admregadmision.sia_regate_rgat," +
                                  "admregadmision.sia_tipusu_regi," +
                                  "siaregimensalud.sia_destip_regi," +
                                  "admregadmision.cto_seccon_cont," +
                                  "admregadmision.cto_nrocon_cont," +
                                  "admregadmision.sia_codeps_teps," +
                                  "siatablaeps.sia_deseps_teps," +
                                  "admregadmision.sia_codcat_ceat," +
                                  "siacentroaten.sia_descat_ceat" +
                                  " FROM " +
                                      "fcmmaedetallfac " +
                                      "INNER JOIN admregadmision ON(fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                      "INNER JOIN siausuarioatend ON(fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                      "INNER JOIN siacentroaten ON (admregadmision.sia_codcat_ceat = siacentroaten.sia_codcat_ceat) " +
                                      "INNER JOIN siaregimensalud ON (admregadmision.sia_tipusu_regi = siaregimensalud.sia_tipusu_regi) " +
                                      "INNER JOIN siatablaeps ON (fcmmaedetallfac.sia_codeps_teps = siatablaeps.sia_codeps_teps)" +
                                  " WHERE " +
                                       "(fcmmaedetallfac.fcm_fecser_dfac >= '" + lcrFechaIni + "') AND " +
                                       "(fcmmaedetallfac.fcm_fecser_dfac <= '" + lcrFechaFin + "') AND " +
                                       "(fcmmaedetallfac.fcm_estfac_mfac = '2') " +
                                       "GROUP BY admregadmision.adm_secadm_rgad " +
                                       "ORDER BY fcmmaedetallfac.sia_codeps_teps";

                    break;
                #endregion

                case "INF07":
                    #region Linea SQl para ejecutar
                    lcrLineaSqlSelct = "SELECT fcmmaedetallfac.cto_seccon_cont," +
                                  "fcmmaedetallfac.cto_nrocon_cont," +
                                  "fcmmaedetallfac.sia_codeps_teps," +
                                  "siatablaeps.sia_deseps_teps," +
                                  "admregadmision.sia_tipide_tide," +
                                  "admregadmision.sia_nroide_usua," +
                                  "siausuarioatend.sia_priape_usua," +
                                  "siausuarioatend.sia_segape_usua," +
                                  "siausuarioatend.sia_prinom_usua," +
                                  "siausuarioatend.sia_segnom_usua," +
                                  "siausuarioatend.sia_fecnac_usua," +
                                  "siausuarioatend.sis_codsex_sexo," +
                                  "admregadmision.sia_edaano_usua," +
                                  "admregadmision.sia_edames_usua," +
                                  "admregadmision.sia_edadia_usua," +
                                  "siausuarioatend.sia_telres_usua," +
                                  "siausuarioatend.sia_dirres_usua," +
                                  "admregadmision.sia_tipusu_regi," +
                                  "admregadmision.cit_codasi_mcit," +
                                  "admregadmision.adm_secadm_rgad," +
                                  "fcmmaedetallfac.fcm_numfac_mfac," +
                                  "fcmmaesfacturas.fcm_fecfac_mfac," +
                                  "fcmmaedetallfac.fcm_codser_mant," +
                                  "fcmmaedetallfac.fcm_coddig_mant," +
                                  "fcmmaedetallfac.fcm_desser_dfac," +
                                  "fcmmaedetallfac.fcm_fecser_dfac," +
                                  "fcmmaedetallfac.fcm_horser_dfac," +
                                  "fcmmaedetallfac.fcm_totuni_dfac," +
                                  "fcmmaedetallfac.fcm_valdes_dfac," +
                                  "fcmmaedetallfac.fcm_valiva_dfac," +
                                  "fcmmaedetallfac.fcm_valcpa_dfac," +
                                  "fcmmaedetallfac.fcm_valcmo_dfac," +
                                  "fcmmaedetallfac.fcm_valusu_dfac," +
                                  "fcmmaedetallfac.fcm_valsub_dfac," +
                                  "fcmmaedetallfac.fcm_valser_mant," +
                                  "fcmmaedetallfac.fcm_valfac_dfac," +
                                  "fcmmaedetallfac.fcm_codcpr_cpro," +
                                  "fcmcenproduccio.fcm_descpr_cpro," +
                                  "siacentroaten.sia_descat_ceat" +
                                  " FROM " +
                                      "fcmmaedetallfac " +
                                      "INNER JOIN admregadmision ON(fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                      "INNER JOIN siausuarioatend ON(fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                      "INNER JOIN siacentroaten ON (admregadmision.sia_codcat_ceat = siacentroaten.sia_codcat_ceat) " +
                                      "INNER JOIN fcmcenproduccio ON (fcmmaedetallfac.fcm_codcpr_cpro = fcmcenproduccio.fcm_codcpr_cpro) " +
                                      "INNER JOIN siatablaeps ON (fcmmaedetallfac.sia_codeps_teps = siatablaeps.sia_codeps_teps)" +
                                      "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                  "WHERE " +
                                           "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND " +
                                           "(fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                           "(fcmmaesfacturas.fcm_estfac_mfac = '2') " +
                                       "ORDER BY fcmmaedetallfac.sia_codeps_teps,fcmmaedetallfac.fcm_fecser_dfac";
                    break;
                #endregion

                case "INF09":

                    #region Linea SQl para ejecutar
                    lcrLineaSqlSelct = "SELECT admregadmision.adm_caucon_rgad," +
                                              "admregadmision.adm_nroaut_rgad," +
                                              "admregadmision.sia_tipide_tide," +
                                              "admregadmision.sia_nroide_usua," +
                                              "fcmmaesfacturas.fcm_fecfac_mfac," +
                                              "fcmmaedetallfac.fcm_codser_mant," +
                                              "fcmmaedetallfac.fcm_desser_dfac," +
                                              "fcmmaedetallfac.fcm_totuni_dfac," +
                                              "siatablaeps.sia_deseps_teps," +
                                              "fcmmaedetallfac.fcm_valfac_dfac," +
                                              "fcmmaesfacturas.cto_seccon_cont," +
                                              "fcmmaesfacturas.sia_codeps_teps," +
                                              "fcmmaedetallfac.fcm_codcpr_cpro " +
                                          " FROM " +
                                              "fcmmaedetallfac " +
                                              "INNER JOIN admregadmision ON(fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                              "INNER JOIN siatablaeps ON (fcmmaedetallfac.sia_codeps_teps = siatablaeps.sia_codeps_teps)" +
                                              "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                          "WHERE " +
                                                   "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND " +
                                                   "(fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                                   "(fcmmaesfacturas.fcm_estfac_mfac = '2')";
                    break;
                #endregion

                case "INF10":

                    #region informe de oportunidad semestral
                    lcrLineaSqlSelct = "SELECT siausuarioatend.sia_tipide_tide," +
                                              "siausuarioatend.sia_nroide_usua," +
                                              "siausuarioatend.sia_fecnac_usua," +
                                              "sistablasexos.sis_dessex_sexo," +
                                              "siausuarioatend.sia_priape_usua," +
                                              "siausuarioatend.sia_segape_usua," +
                                              "siausuarioatend.sia_prinom_usua," +
                                              "siausuarioatend.sia_segnom_usua," +
                                              "fcmmaedetallfac.fcm_codser_mant," +
                                              "fcmmaesfacturas.fcm_fecfac_mfac," +
                                              "fcmmaesfacturas.cto_seccon_cont," +
                                              "fcmmaesfacturas.sia_codeps_teps" +
                                            " FROM " +
                                              "fcmmaedetallfac " +
                                              "INNER JOIN siausuarioatend ON (fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                              "INNER JOIN sistablasexos ON (siausuarioatend.sis_codsex_sexo = sistablasexos.sis_codsex_sexo) " +
                                              "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                            "WHERE " +
                                               "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND " +
                                               "(fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                               "(fcmmaesfacturas.fcm_estfac_mfac = '2') " +
                                               "ORDER BY fcmmaesfacturas.fcm_fecfac_mfac";
                    break;
                #endregion

                case "INF11":

                    #region Indicadores de calidad
                    lcrLineaSqlSelct = "SELECT fcmmaesfacturas.sia_tipide_tide," +
                                              "fcmmaesfacturas.sia_nroide_usua," +
                                              "fcmmaesfacturas.fcm_fecfac_mfac," +
                                              "fcmmaedetallfac.fcm_codser_mant," +
                                              "fcmmaedetallfac.fcm_desser_dfac," +
                                              "fcmmaedetallfac.fcm_totuni_dfac," +
                                              "siatablaeps.sia_deseps_teps," +
                                              "fcmmaesfacturas.cto_seccon_cont," +
                                              "fcmmaesfacturas.sia_codeps_teps" +
                                            " FROM " +
                                              "fcmmaedetallfac " +
                                              "INNER JOIN siatablaeps ON (fcmmaedetallfac.sia_codeps_teps = siatablaeps.sia_codeps_teps)" +
                                              "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                            "WHERE " +
                                               "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND " +
                                               "(fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                               "(fcmmaesfacturas.fcm_estfac_mfac = '2') " +
                                               "ORDER BY fcmmaesfacturas.fcm_fecfac_mfac";
                    break;
                #endregion

                case "INF12":

                    #region Linea SQl para ejecutar
                    lcrLineaSqlSelct = "SELECT siausuarioatend.sia_priape_usua," +
                                              "siausuarioatend.sia_segape_usua," +
                                              "siausuarioatend.sia_prinom_usua," +
                                              "siausuarioatend.sia_segnom_usua," +
                                              "siausuarioatend.sia_nroide_usua," +
                                              "siatablaeps.sia_deseps_teps," +
                                              "fcmmaedetallfac.fcm_codser_mant," +
                                              "fcmmaedetallfac.fcm_desser_dfac," +
                                              "fcmmaedetallfac.fcm_totuni_dfac," +
                                              "fcmmaedetallfac.fcm_valfac_dfac," +
                                              "fcmmaesfacturas.cto_seccon_cont," +
                                              "fcmmaesfacturas.sia_codeps_teps," +
                                              "fcmmaedetallfac.fcm_codcpr_cpro," +
                                              "fcmcenproduccio.fcm_descpr_cpro" +
                                              "fcmmaesfacturas.cto_seccon_cont," +
                                              "fcmmaesfacturas.sia_codeps_teps" +
                                          " FROM " +
                                              "fcmmaedetallfac " +
                                              "INNER JOIN fcmcenproduccio ON (fcmmaedetallfac.fcm_codcpr_cpro = fcmcenproduccio.fcm_codcpr_cpro)" +
                                              "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                              "INNER JOIN siatablaeps ON (fcmmaesfacturas.sia_codeps_teps = siatablaeps.sia_codeps_teps)" +
                                          "WHERE " +
                                                   "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND " +
                                                   "(fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                                   "(fcmmaesfacturas.fcm_estfac_mfac = '2')" +
                                                   "ORDER BY fcmmaedetallfac.fcm_codcpr_cpro,fcmmaesfacturas.sia_codeps_teps";
                    break;
                #endregion

                case "INF13":

                    #region Linea SQl para ejecutar
                    lcrLineaSqlSelct = @"SELECT fcmmaesfacturas.cto_seccon_cont,
						                        fcmmaesfacturas.cto_nrocon_cont,
						                        fcmmaesfacturas.sia_codeps_teps,
						                        siatablaeps.sia_deseps_teps,
						                        fcmmanservicips.fcm_idesec_fcct,
						                        fcmmanservicate.fcm_descat_fcct,
                                                fcmmaedetallfac.fcm_coddig_mant,
						                        fcmmaedetallfac.fcm_codser_mant,
						                        fcmmaedetallfac.fcm_desser_dfac,
						                        SUM(fcmmaedetallfac.fcm_totuni_dfac) AS fcm_totuni_dfac,
                                                fcmmaedetallfac.fcm_valser_mant,
						                        SUM(fcmmaedetallfac.fcm_valfac_dfac) AS fcm_valfac_dfac
                                           FROM fcmmaedetallfac
                                                  INNER JOIN fcmmaesfacturas ON(fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac)
                                                  INNER JOIN siatablaeps ON(fcmmaesfacturas.sia_codeps_teps = siatablaeps.sia_codeps_teps)
                                                  INNER JOIN fcmmanservicips ON(fcmmaedetallfac.fcm_idesec_sips = fcmmanservicips.fcm_idesec_sips)
                                                  INNER JOIN fcmmanservicate ON(fcmmanservicips.fcm_idesec_fcct = fcmmanservicate.fcm_idesec_fcct)
                                            WHERE(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + @"' AND
                                                  fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + @"' AND
                                                  fcmmaesfacturas.fcm_estfac_mfac = '2')
                                           GROUP BY fcmmaesfacturas.cto_seccon_cont,
							                     fcmmaesfacturas.sia_codeps_teps,
							                     fcmmanservicips.fcm_idesec_fcct,
							                     fcmmaedetallfac.fcm_coddig_mant
                                           ORDER BY fcmmaesfacturas.cto_seccon_cont,
							                     fcmmaesfacturas.sia_codeps_teps,
							                     fcmmanservicips.fcm_idesec_fcct,
                                                 fcmmaedetallfac.fcm_desser_dfac";

                    break;
                    #endregion
            }
            return lcrLineaSqlSelct;
        }
        #endregion
    }
}
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
    /// Interaction logic for EST_EstInformesHospitalizados.xaml
    /// </summary>
    public partial class EstInformesHospitalizados : Window, SIS_Interface
    {
        //-----------------------------------------------------------
        // Inicio Formulario
        //-----------------------------------------------------------
        #region Inicio Formulario
        public bool llgModoEdicionKey   = false;
        public bool llgModoEdicionValid = false;
        public bool llgObjetosCargados  = false;
        public bool glgVistaSeleccion   = false;
        public bool glgVistaPropiedades = false;
        public int gnuNumeroSecuencial  = 0;
        public String gcrCtrF2TexBox;
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        //-----------------------------------------------------------
        // Temporales
        public List<LogsErrores> tmpLogErrores      = new List<LogsErrores>();
        public List<CrtForms.ListaComboBox> lstTipoInforme;
        public List<TmpGestionItem> lstListaCampos;
        public List<TmpListaSeleccion> lstListaAgrupar;
        public List<TmpListaSeleccion> lstListaCondiciones;
        public DispatcherTimer gdspTimerSistema     = new DispatcherTimer();
        public List<ClasseTmpResumen> tmpResumen    = null;
        public DataTable tmpConsulta                = null;
        private static DbAplicacion db;

        // Vaiables para Compilacion de parametros
        Aplicacion oApp = Aplicacion.Instancia();
        DialogVistaErrores lobDlgLogs               = null;
        ControlAddGrupo RefCrtAddGrupo              = null;
        ControlAddCondicion RefCrtAddCondicion      = null;
        public String gcrExportarArchivoNombreyRuta = @"C:\Users\JOSE\Desktop\INFORME-PRODUCCION.XLS";
        //public String gcrExportarArchivoNombreyRuta = @"C:\Users\familia\Desktop\INFORME-PRODUCCION.XLS";
        public String gcrStrinPlantilla             = String.Empty;
        public int gnuContadorvistaArchivos         = 0;
        //-----------------------------------------------------------
        //- Variables para compilacion  plantillas de consultas
        public static CompilerResults gobEnsamblado = null;
        public static Type gobRefoAppType = null;
        public static IEjecutarConsulta oAppIConsulta = null;
        #endregion

        public EstInformesHospitalizados()
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

            this.grdPropSelect.Height = lduHeight;
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
            this.grdPropSelect.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
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
                string lcrG11Seleccion = "NA,INF01,INF02,INF03,INF04,INF05,INF06,INF07,INF08,INF09";
                string lcrG11Descripcion = "Seleccione un informe...,Remisiones desde Urgencias,Remisiones desde hospitalización," +
                                           "Remisiones desde Consulta externa,Listado de hospitalizados por mes,Listado urgencias con observación," +
                                           "Diagnosticos por grupos de edad,Listado usuarios por servicios y fechas," +
                                           "Usuarios asistentes crecimiento y desarrollo,Diagnosticos por centros de producción";
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

            if (lobTipo == "INF01")
            {
                #region Campos para agrupar el reporte
                /*
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "facturas" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "facturas" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                */
                #endregion
            }
            else if (lobTipo == "INF02")
            {
                #region Campos para filtro el reporte
                /*
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Fcm_coddig_mant", ItemTitulo = "Codigo Digitación", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                */
                #endregion
            }
            else if (lobTipo == "INF03")
            {
                #region Campos para agrupar el reporte
                /*
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "CAMP1", ItemTitulo = "Nombre campo 1", ItemTipoDato = "CHAR", ItemTabla = "factura" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "CAMP2", ItemTitulo = "Nombre campo 2", ItemTipoDato = "CHAR", ItemTabla = "factura" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "CAMP3", ItemTitulo = "Nombre campo 3", ItemTipoDato = "CHAR", ItemTabla = "factura" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "CAMP4", ItemTitulo = "Nombre campo 4", ItemTipoDato = "CHAR", ItemTabla = "factura" });
                */
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
                /*
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Sia_coddia_tdia", ItemTitulo = "Codigo Diagnostico", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                */
                #endregion
            }
            else if (lobTipo == "INF07")
            {
                #region Campos para filtro el reporte
                /*
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Fcm_coddig_mant", ItemTitulo = "Codigo Digitación servicio", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                */
                #endregion
            }
            else if (lobTipo == "INF08")
            {
                #region Campos para filtro el reporte
                /*
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Fcm_coddig_mant", ItemTitulo = "Codigo Digitación servicio", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                */
                #endregion
            }
            else if (lobTipo == "INF09")
            {
                #region Campos para filtro el reporte
                /*
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R1", ItemNombre = "Cto_seccon_cont", ItemTitulo = "Secuencial contrato", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R2", ItemNombre = "Sia_codeps_teps", ItemTitulo = "Codigo de la EPS", ItemTipoDato = "CHAR", ItemTabla = "admision" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R3", ItemNombre = "Sia_coddia_tdia", ItemTitulo = "Codigo Diagnostico", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                lstListaCampos.Add(new TmpGestionItem { Itemllave = "R4", ItemNombre = "Fcm_codcpr_cpro", ItemTitulo = "Codigo Centro producción", ItemTipoDato = "CHAR", ItemTabla = "detalles" });
                */
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

            if (lobTipo == "INF01")
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

            if (lobTipo == "INF01")
            {
                #region Grupos campos para agrupar el reporte
                /*
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                */
                #endregion
            }
            else if (lobTipo == "INF02")
            {
                #region Grupos campos para agrupar el reporte
                /*
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Fcm_coddig_mant" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Fcm_codcpr_cpro" });
                */
                #endregion
            }
            else if (lobTipo == "INF03")
            {
                #region Grupos campos para agrupar el reporte
                /*
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "CAMP1" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "CAMP3" });
                */
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
                /*
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Sia_coddia_tdia" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Fcm_codcpr_cpro" });
                */
                #endregion
            }
            else if (lobTipo == "INF07")
            {
                #region Grupos campos para agrupar el reporte
                /*
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Fcm_coddig_mant" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Fcm_codcpr_cpro" });
                */
                #endregion
            }
            else if (lobTipo == "INF08")
            {
                #region Grupos campos para agrupar el reporte
                /*
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Fcm_coddig_mant" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Fcm_codcpr_cpro" });
                */
                #endregion
            }
            else if (lobTipo == "INF09")
            {
                #region Grupos campos para agrupar el reporte
                /*
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "0", ValorSeleccion = "Cto_seccon_cont" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "1", ValorSeleccion = "Sia_codeps_teps" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "2", ValorSeleccion = "Sia_coddia_tdia" });
                lstListaCondiciones.Add(new TmpListaSeleccion { IdIndice = "3", ValorSeleccion = "Fcm_codcpr_cpro" });
                */
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
            try
            {

                if (this.txtG1TipoInforme.Text == "INF01" || this.txtG1TipoInforme.Text == "INF02" || this.txtG1TipoInforme.Text == "INF03")
                {
                    #region Remision desde urgencias
                    if (flsEjecutarConsultaRemisiones(this.txtG1TipoInforme.Text, this.txtG1FechaInicial.Text, this.txtG1FechaFinal.Text))
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
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Error Metodo: cmdEjecutar_Click");
                //MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvRegCargarXMLZonas");
            }
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
            var lcrArchivo = "REPORTE";

            Excel.Application lobApp;
            Excel.Workbook lobLibroTrabajo;
            Excel.Worksheet lobHoja;

            lobApp = new Excel.Application();
            lobLibroTrabajo = lobApp.Workbooks.Add();
            lobHoja = (Excel.Worksheet)lobLibroTrabajo.Worksheets.get_Item(1);

            // Menu de Opciones
            if (this.txtG1TipoInforme.Text == "INF01")
            {
                //lcrArchivo = "REMISIONES-URGENCIAS";
                flgInf01_ExcelRemisiones(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF02")
            {
                //lcrArchivo = "REMISIONES-HOSPITALIZACION";
                flgInf01_ExcelRemisiones(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF03")
            {
                //lcrArchivo = "REMISIONES-CONSULTA-EXTERNA";
                flgInf01_ExcelRemisiones(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF04")
            {
                lcrArchivo = "HOSPITALIZACIONES";
                flgInf04_ExcelHospitalizadosMensual(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF05")
            {
                lcrArchivo = "OBSERVACIONES-Y-HOSPITALIZACIONES";
                flgInf05_ExcelObservacionesMensual(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF06")
            {
                lcrArchivo = "DIAGNOSTICOS-POR-EDAD";
                flgInf06_ExceldiagnosticosPorGruposDeEdad(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF07")
            {
                lcrArchivo = "USUARIOS-POR-SERVICIOS";
                flgInf07_ExcelUsuariosPorServicios();
            }
            else if (this.txtG1TipoInforme.Text == "INF08")
            {
                lcrArchivo = "CRECIMIENTO-Y-DESARROLLO";
                flgInf08_ExcelControlCrecimDesarrollo(ref lobApp, ref lobHoja);
            }
            else if (this.txtG1TipoInforme.Text == "INF09")
            {
                lcrArchivo = "DIAGNOSTICOS-POR-CENT-PRODUCCION";
                flgInf09_ExceldiagnosticosPorCentProduccion(ref lobApp, ref lobHoja);
            }

            lobDlgAdd.Close();

            if (this.txtG1TipoInforme.Text != "INF01" &&
                this.txtG1TipoInforme.Text != "INF02" &&
                this.txtG1TipoInforme.Text != "INF03")
            {
                // Abrir Microsoft Excel 
                lobApp.DisplayAlerts = false;
                lcrArchivo = fcrExportarForamtoPlanoGenerarNombreArchivo(lcrArchivo) + ".XLS";
                lobLibroTrabajo.SaveAs(lcrArchivo, Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;
            }
            /*
            lobLibroTrabajo.SaveAs(@gcrExportarArchivoNombreyRuta, Excel.XlFileFormat.xlWorkbookNormal);

            lobLibroTrabajo.Close(true);
            lobApp.Quit();
            */

            return llgreturn;
        }
        #endregion
        #region fcrGuardarGenerarNombreArchivo: Generar el nombre unico del archivo
        /// <summary>
        /// Generar el nombre unico del archivo
        /// </summary>
        public String fcrExportarForamtoPlanoGenerarNombreArchivo(String tcrNombreArchivoBase)
        {
            gnuContadorvistaArchivos++;

            var lcrNombre = gnuContadorvistaArchivos.ToString().Trim() + "-" + Funciones.fnuFechaLlaveIndiceRegistro().ToString().Trim();
            lcrNombre = tcrNombreArchivoBase + "-" + lcrNombre;

            return lcrNombre;
        }
        #endregion
        // Informes
        #region flgInf01_ExcelRemisiones: Informe Remisiones mensuales
        /// <summary>
        /// <para>Informe Remisiones mensuales  desde INF01=Urgencias INF02=Hospitalizacion INF03=Ambulatoria</para>
        /// </summary>
        private bool flgInf01_ExcelRemisiones(ref Excel.Application tobApp, ref Excel.Worksheet tobHoja)
        {
            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;
            //gcrExportarArchivoNombreyRuta = lcrMisDocs +@"\INFORME-SERVICIOS.XLS";

            // Cargar todos los campos interpretando todo en formato texto
            object objInfoFormatoCampos = new int[29, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 2 },{ 5, 2 },{ 6, 2 },{ 7, 2 },{ 8, 2 },{ 9, 2 },{ 10, 2 },
                                        { 11, 2 },{ 12, 2 },{ 13, 2},{ 14, 2 },{ 15, 2},{ 16, 2 },{ 17, 2 },{ 18, 2 },{ 19, 2 },{ 20, 2 },{ 21, 2 },
                                        { 22, 2 },{ 23, 2},{ 24, 2 },{ 25, 2},{ 26, 2 },{ 27, 2 },{ 28, 2 },{ 29, 2 }};

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
                lobApp.get_Range("A6:W6").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(fcrTituloConsultaRemisiones(this.txtG1TipoInforme.Text, "2") + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;
        }
        #endregion
        #region flgInf04_ExcelServiciosPorGruposDeEdad: Informe cantidad servicios por grupos edad
        /// <summary>
        /// <para>Cantidad servicios facturados agrupados por rangos de edad en años</para>
        /// </summary>
        private bool flgInf02_ExcelServiciosPorGruposDeEdad(ref Excel.Application tobApp, ref Excel.Worksheet tobHoja)
        {
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
                tobHoja.Cells[i, 2] = lobReg.Texto2 == null ? "" : lobReg.Texto2.Trim(); // Codigo Eps
                tobHoja.Cells[i, 3] = lobReg.Texto3 == null ? "" : lobReg.Texto3.Trim(); // Nombre de la Eps
                tobHoja.Cells[i, 4] = lobReg.Texto4 == null ? "" : lobReg.Texto4.Trim();
                tobHoja.Cells[i, 5] = lobReg.Texto5 == null ? "" : lobReg.Texto5.Trim();
                tobHoja.Cells[i, 6] = lobReg.Texto6 == null ? "" : lobReg.Texto6.Trim();
                tobHoja.Cells[i, 7] = lobReg.Texto7 == null ? "" : lobReg.Texto7.Trim();
                tobHoja.Cells[i, 8] = lobReg.Texto6 == null ? "" : lobReg.Texto8.Trim();
                tobHoja.Cells[i, 9] = lobReg.Texto9 == null ? "" : lobReg.Texto9.Trim();
                tobHoja.Cells[i, 10] = lobReg.Fecha1 == null ? "" : lobReg.Fecha1.ToShortDateString();
                tobHoja.Cells[i, 11] = lobReg.Texto11 == null ? "" : lobReg.Texto11.Trim();
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
            tobHoja.Cells[7, 4] = "REGIMEN";
            tobHoja.Cells[7, 5] = "NUMERO ADMISION";
            tobHoja.Cells[7, 6] = "TIPO ID";
            tobHoja.Cells[7, 7] = "IDENTIFICACION";
            tobHoja.Cells[7, 8] = "PRIMER APELLIDO";
            tobHoja.Cells[7, 9] = "SEGUNDO APELLIDO";
            tobHoja.Cells[7, 10] = "PRIMER NOMBRE";
            tobHoja.Cells[7, 11] = "SEGUNDO NOMBRE";
            tobHoja.Cells[7, 12] = "FECHA NACIMIENTO";
            tobHoja.Cells[7, 13] = "SEXO";
            tobHoja.Cells[7, 14] = "EDAD EN AÑOS";
            tobHoja.Cells[7, 15] = "EDAD EN MESES";
            tobHoja.Cells[7, 16] = "EDAD EN DIAS";
            tobHoja.Cells[7, 17] = "NUMERO AUTORIZACIÓN";
            tobHoja.Cells[7, 18] = "FECHA ING.OBSERVACION";
            tobHoja.Cells[7, 19] = "HORA ING.OBSERVACION";
            tobHoja.Cells[7, 20] = "PACIENTE EMBARAZADA";
            tobHoja.Cells[7, 21] = "DIAG.INGRESO";
            tobHoja.Cells[7, 22] = "NOMBRE.DIAG.INGRESO";
            tobHoja.Cells[7, 23] = "COD.PROF.ATIENDE";
            tobHoja.Cells[7, 24] = "PROFESIONAL QUE ATIENDE";
            tobHoja.Cells[7, 25] = "DESTINO SALIDA";
            tobHoja.Cells[7, 26] = "COD.PROF.SALIDA";
            tobHoja.Cells[7, 27] = "PROFESIONAL AUTORIZA SALIDA";
            tobHoja.Cells[7, 28] = "DIAG.SALIDA";
            tobHoja.Cells[7, 29] = "NOMBRE.DIAG.SALIDA";
            tobHoja.Cells[7, 30] = "DIAG.MUERTE";

            // poner formato fuente a los titulos
            //var lobTitulos = (Excel.Range)lobHoja.get_Range("A7:J7");
            tobApp.get_Range("A7:AD7").Select();
            tobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

            #endregion

            //Recorrer el temporal y rellenado hoja de trabajo
            i = 8;
            foreach (var lobReg in tmpResumen)
            {
                #region Campos
                tobHoja.Cells[i, 1] = lobReg.Texto1.Trim(); // Descripcion contrato
                tobHoja.Cells[i, 2] = lobReg.Texto2.Trim(); // Codigo Eps
                tobHoja.Cells[i, 3] = lobReg.Texto3 != null? lobReg.Texto3.Trim(): "NO ENCONTRADO"; // Nombre de la Eps
                tobHoja.Cells[i, 4] = lobReg.Texto22.Trim(); // Regimen salud
                tobHoja.Cells[i, 5] = lobReg.Texto20.Trim(); // admision
                tobHoja.Cells[i, 6] = lobReg.Texto4.Trim();
                tobHoja.Cells[i, 7] = lobReg.Texto5.Trim();
                tobHoja.Cells[i, 8] = lobReg.Texto6.Trim();
                tobHoja.Cells[i, 9] = lobReg.Texto7.Trim();
                tobHoja.Cells[i, 10] = lobReg.Texto8.Trim();
                tobHoja.Cells[i, 11] = lobReg.Texto9.Trim();
                tobHoja.Cells[i, 12] = lobReg.Fecha1.ToShortDateString();
                tobHoja.Cells[i, 13] = lobReg.Texto10.Trim();
                tobHoja.Cells[i, 14] = lobReg.Valor1;
                tobHoja.Cells[i, 15] = lobReg.Valor2;
                tobHoja.Cells[i, 16] = lobReg.Valor3;
                tobHoja.Cells[i, 17] = lobReg.Texto23.Trim();
                tobHoja.Cells[i, 18] = lobReg.Fecha2.ToShortDateString(); // FECHA ING OBSERVACION
                tobHoja.Cells[i, 19] = lobReg.Decimal1;
                tobHoja.Cells[i, 20] = lobReg.Texto11.Trim() == "1" ? "SI" : "NO"; // EMBARAZADA
                tobHoja.Cells[i, 21] = lobReg.Texto12.Trim(); // Dx ingreso
                tobHoja.Cells[i, 22] = lobReg.Texto13.Trim(); // Nombre Dx ingreso
                tobHoja.Cells[i, 23] = lobReg.Texto14.Trim(); // codigo profesional que atiende
                tobHoja.Cells[i, 24] = lobReg.Texto15 != null ? lobReg.Texto15.Trim() : "NO ASIGNADO";  // nombre profesional que atiende
                tobHoja.Cells[i, 25] = lobReg.Texto16.Trim(); // Destino al salir
                if (lobReg.Texto16 != "PENDIENTE")
                {
                    tobHoja.Cells[i, 25] = lobReg.Texto16.Trim() == "1" ? "ALTA (Salida)" : lobReg.Texto16.Trim() == "2" ? "REMISIÓN" : "HOSPITALIZACIÓN"; // 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion
                }
                tobHoja.Cells[i, 26] = lobReg.Texto17.Trim(); // codigo profesional autoriza salida
                tobHoja.Cells[i, 27] = "PENDIENTE";
                if (lobReg.Texto17 != "NA")
                {
                    var lobRef = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(lobReg.Texto17.Trim());

                    if (lobRef != null)
                    {
                        tobHoja.Cells[i, 27] = lobRef.sia_nompro_prof;
                    }
                }
                tobHoja.Cells[i, 28] = lobReg.Texto18.Trim(); // Diagnostico de salida 
                tobHoja.Cells[i, 29] = "PENDIENTE"; // Descripcion Ddagnostico salida
                if (lobReg.Texto18 != "PENDIENTE")
                {
                    tobHoja.Cells[i, 29] = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(lobReg.Texto18.Trim()).sia_desdia_tdia;
                }
                tobHoja.Cells[i, 30] = lobReg.Texto19.Trim(); // Diagnostico de de muerte 
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
            object objInfoFormatoCampos = new int[29, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 2 },{ 5, 2 },{ 6, 2 },{ 7, 2 },{ 8, 2 },{ 9, 2 },{ 10, 2 },
                                        { 11, 2 },{ 12, 2 },{ 13, 2},{ 14, 2 },{ 15, 2},{ 16, 2 },{ 17, 2 },{ 18, 2 },{ 19, 2 },{ 20, 2 },{ 21, 2 },
                                        { 22, 2 },{ 23, 2},{ 24, 2 },{ 25, 2},{ 26, 2 },{ 27, 2 },{ 28, 2 },{ 29, 2 }};

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
                lobApp.get_Range("A4:AC4").Select();
                lobApp.Selection.AutoFormat(3, true, true, true, true, true, true);

                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs("LISTADO-USUARIOS-POR-SERVICIOS.XLS", Excel.XlFileFormat.xlWorkbookNormal);
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
        #region flgInf09_ExceldiagnosticosPorCentProduccion: Informe diagnosticos centro de producción
        /// <summary>
        /// <para>Informe diagnosticos centro de producción</para>
        /// </summary>
        private bool flgInf09_ExceldiagnosticosPorCentProduccion(ref Excel.Application tobApp, ref Excel.Worksheet tobHoja)
        {
            var llgreturn = true;
            int i = 2;

            // poner formato texto a la hoja
            var lobCells = (Excel.Range)tobHoja.Cells;
            lobCells.NumberFormat = "@";

            // Encabezado del informe
            #region Encabezado del informe
            tobHoja.Cells[1, 2] = "DIANGNOSTICOS POR CENTRO PRODUCCIÓN";
            tobHoja.Cells[2, 2] = this.txtG1FechaInicial.Text;
            tobHoja.Cells[2, 3] = this.txtG1FechaFinal.Text;
            tobHoja.Cells[3, 2] = "TOTAL REGISTROS: " + tmpResumen.Count().ToString().Trim();
            // Titulos
            tobHoja.Cells[7, 1] = "CODIGO-CIE10";
            tobHoja.Cells[7, 2] = "DIAGNOSTICO";
            tobHoja.Cells[7, 3] = "CONSULTA EXTERNA";
            tobHoja.Cells[7, 4] = "OBSERVACIÓN URGENCIAS";
            tobHoja.Cells[7, 5] = "ODONTOLOGIA";
            tobHoja.Cells[7, 6] = "REMISIONES";
            tobHoja.Cells[7, 7] = "LABORATORIO CLINICO";
            tobHoja.Cells[7, 8] = "HOSPITALIZACION";
            tobHoja.Cells[7, 9] = "PROMOCION Y PREVENCION";
            tobHoja.Cells[7, 10] = "DROGRAS Y FARMACIA";
            tobHoja.Cells[7, 11] = "TOTAL GENERAL";

            // poner formato fuente a los titulos
            //var lobTitulos = (Excel.Range)lobHoja.get_Range("A7:J7");
            tobApp.get_Range("A7:K7").Select();
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
                #endregion
                i++;
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
        #region flsEjecutarConsultaRemisiones: Facturación total por centros de producción
        /// <summary>
        /// <para>PARAMETROS</para>
        /// <para>tcrTipoInforme:</para>
        /// INF01 - Remision desde urgencias
        /// INF02 - Remision desde Hispitalizacion
        /// INF03 - Remision desde Consulta externa
        /// </summary>
        public bool flsEjecutarConsultaRemisiones(String tcrTipoInforme, String tdaFechaIni, String tdaFechaFin)
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos de la consulta...", "CENTRO");
            lobDlgAdd.Show();

            gnuNumeroSecuencial++;
            var llgReturn        = false;
            var lcrTextoPlano    = String.Empty;
            var lcrnombreArchivo = fcrTituloConsultaRemisiones(tcrTipoInforme, "2");

            tmpResumen  = null;
            tmpConsulta = flstConsultarDatos(tcrTipoInforme, tdaFechaIni, tdaFechaFin);
            lcrTextoPlano = fcrGuardarDatosRemisiones(tcrTipoInforme);
            llgReturn = flgExportarForamtoPlano(lcrnombreArchivo, lcrTextoPlano);

            //llgReturn = tmpResumen == null ? false : true;

            lobDlgAdd.Close();
            return llgReturn;
        }
        #region fcrTituloConsultaRemisiones: Titulos consultas remisiones
        /// <summary>
        /// <para>PARAMETROS</para>
        /// <para>tcrTipoInforme:</para>
        /// INF01 - Remision desde urgencias
        /// INF02 - Remision desde Hispitalizacion
        /// INF03 - Remision desde Consulta externa
        /// <para>tcrTipoTexto: 1= Ttulo 2= Nombre para archivo de salida</para>
        /// </summary>
        public String fcrTituloConsultaRemisiones(String tcrTipoInforme, String tcrTipoTexto)
        {
            var lcrReturn = tcrTipoInforme == "INF01" ? "URGENCIAS" : tcrTipoInforme == "INF02" ? "HOSPTUALIZACION" : "CONSULTA-EXTERNA";

            if (tcrTipoTexto == "1")
            {
                lcrReturn = "INFORME REMISIONES POR " + lcrReturn;
            }
            else
            {
                gnuNumeroSecuencial++;
                lcrReturn = "REMISIONES-POR-" + lcrReturn + "-" + Funciones.fcrGenLlaveRangoFechaHoraActual() + "-" + gnuNumeroSecuencial.ToString();
            }
            return lcrReturn;
        }
        #endregion
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
            //flgGuardarDatosResumenINF01();

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

            var llgReturn     = true;
            var lcrTextoPlano = String.Empty;

            tmpConsulta = flstConsultarDatos("INF07", tdaFechaIni, tdaFechaFin);
            lcrTextoPlano = fcrGuardarDatosResumenINF07();
            flgExportarForamtoPlano("LISTADO-USUARIOS-POR-SERVICIOS", lcrTextoPlano);

            lobDlgAdd.Close();
            return llgReturn;
        }
        #endregion
        // Generar texto plano de cada archivo
        #region fcrGuardarDatosRemisiones: Generar texto plano informe remisiones
        /// <summary>
        /// <para>Generar texto plano informe remisiones</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrTipoInforme:</para>
        /// INF01 - Remision desde urgencias
        /// INF02 - Remision desde Hispitalizacion
        /// INF03 - Remision desde Consulta externa
        /// </summary>
        public String fcrGuardarDatosRemisiones(String tcrTipoInforme)
        {
            var lcrReturn       = String.Empty;
            var lcrLinea        = String.Empty;
            var lcrTextoTitulo  = String.Empty;
            var lcrSepara       = "|";
            var lcrTitulo       = fcrTituloConsultaRemisiones(tcrTipoInforme, "1");
            var lcrFechaAdmision        = String.Empty;
            var lcrUsuarioPApellido     = String.Empty;
            var lcrUsuarioSApellido     = String.Empty;
            var lcrUsuarioPNombre       = String.Empty;
            var lcrUsuarioSNombre       = String.Empty;
            var lcrUsuarioFecNacimi     = String.Empty;
            var lcrUsuarioSexo          = String.Empty;
            var lcrCodigoAdmison        = String.Empty;
            var lcrCodigoDiagnostico    = String.Empty;
            var lcrCodigoProfesional    = "NA";
            var lcrNombreProfesional    = "NA";
            var lcrVersionPalntilla     = "XX";
            var lcrDbCodigoCampoServi   = "NA";
            var lcrDbNombreCampoServi   = "NA";
            var lcrDbNombreCampoFecha   = "NA";
            var lcrDatoCodigoServ       = "NA";
            var lcrDatoNombreServ       = "NA";
            var lcrDatoFechaRemis       = "NA";
            var lnuTotalRegistros       = 0;
            HclModeloHistorialEventos lobRegEvento = null;
            ModeloGrpplantvistcam lobRegCampoServi = null;
            ModeloGrpplantvistcam lobRegCampoFecha = null;
            DataRow lobRegHistServi = null;
            DataRow lobRegHistFecha = null;

            #region Gestion datos
            if (tmpConsulta != null)
            {
                using (db = new DbAplicacion())
                {
                    foreach (DataRow lobReg in tmpConsulta.Rows)
                    {
                        lnuTotalRegistros++;
                        lcrCodigoAdmison = lobReg["Adm_secadm_rgad"].ToString();

                        #region consulta eventos encontrar datos en el formato diligenciado
                        // Consultar el evento y sacar los datos de la remision
                        lobRegEvento = HclModeloHistorialEventos.fobRegUnicaActividadHistorial(lcrCodigoAdmison, "FRM-SOLIC-REMISION");
                        if (lobRegEvento != null)
                        {
                            lcrCodigoProfesional = lobRegEvento.Sia_codpfa_prof;
                            lcrNombreProfesional = lobRegEvento.Sia_nompro_prof;
                            if (lcrVersionPalntilla != lobRegEvento.Grp_idepla_grpv)
                            {
                                lcrVersionPalntilla = lobRegEvento.Grp_idepla_grpv;

                                // buscar la variable publica asociada al campo servicio solicitado y fecha de remision
                                lobRegCampoServi = ModeloGrpplantvistcam.flsListaGrpplantvistcam("2", "REMISION_CODIGO_SERVICIO", lcrVersionPalntilla);
                                if (lobRegCampoServi == null) 
                                {
                                    lobRegCampoServi = ModeloGrpplantvistcam.flsListaGrpplantvistcam("2", "REMISION_NOMBRE_SERVICIO", lcrVersionPalntilla);
                                }
                                lobRegCampoFecha = ModeloGrpplantvistcam.flsListaGrpplantvistcam("2", "REMISION_FECHA_REMISION", lcrVersionPalntilla);
                            }
                            // Sacar datos desde historicos digitados vista formato
                            #region consulta Campo Servicio solicitado
                            if (lobRegCampoServi != null)
                            {
                                if (lobRegCampoServi.Hcl_camdes_hccm != null)
                                {
                                    lcrDbCodigoCampoServi = lobRegCampoServi.Hcl_nomcam_hccm;
                                    lcrDbNombreCampoServi = !String.IsNullOrWhiteSpace(lobRegCampoServi.Hcl_camdes_hccm) ? lobRegCampoServi.Hcl_camdes_hccm : "NA";
                                }
                                else
                                {
                                    lcrDbCodigoCampoServi = "NA";
                                    lcrDbNombreCampoServi = lobRegCampoServi.Hcl_nomcam_hccm;
                                }
                                lobRegHistServi = fobRegistroHistoricoCampos(lobRegEvento.Hcl_nroreg_hcev, lobRegCampoServi);
                                if (lobRegHistServi != null)
                                {
                                    lcrDatoCodigoServ = lcrDbCodigoCampoServi != "NA" ? lobRegHistServi[lcrDbCodigoCampoServi].ToString() : "NA";
                                    lcrDatoNombreServ = lcrDbNombreCampoServi != "NA" ? lobRegHistServi[lcrDbNombreCampoServi].ToString() : "NA";
                                }
                            }
                            #endregion
                            #region consulta Campo Fecha remision
                            if (lobRegCampoFecha != null)
                            {
                                lcrDbNombreCampoFecha = lobRegCampoFecha.Hcl_nomcam_hccm;
                                lobRegHistFecha = fobRegistroHistoricoCampos(lobRegEvento.Hcl_nroreg_hcev, lobRegCampoFecha);
                                if (lobRegHistFecha != null)
                                {
                                    lcrDatoFechaRemis = lobRegHistFecha[lcrDbNombreCampoFecha].ToString();
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region Gestion datos
                        lcrFechaAdmision    = Funciones.fcrConvertFecha(Convert.ToDateTime(lobReg["Adm_fecadm_rgad"].ToString().Substring(0, 10)));
                        #region  Cargar datos en registro
                        #region  datos basicos del usario
                        if (tcrTipoInforme != "INF03")
                        {
                            lcrUsuarioPApellido  = lobReg["Sia_priape_usua"].ToString();
                            lcrUsuarioSApellido  = lobReg["Sia_segape_usua"].ToString();
                            lcrUsuarioPNombre    = lobReg["Sia_prinom_usua"].ToString();
                            lcrUsuarioSNombre    = lobReg["Sia_segnom_usua"].ToString();
                            lcrUsuarioFecNacimi  = Funciones.fcrConvertFecha(Convert.ToDateTime(lobReg["Sia_fecnac_usua"].ToString().Substring(0,10)));
                            lcrUsuarioSexo       = lobReg["Sis_codsex_sexo"].ToString();
                            lcrCodigoDiagnostico = lobReg["Sia_dixsal_tdia"].ToString();
                        }
                        else
                        {
                            var lobRegUs = SIAValidarCodigo.fobRegBuscarSiausuarioatendEx(lobReg["Sia_idesec_usua"].ToString().Trim());
                            if (lobRegUs != null)
                            {
                                lcrUsuarioPApellido  = lobRegUs.sia_priape_usua;
                                lcrUsuarioSApellido  = lobRegUs.sia_segape_usua;
                                lcrUsuarioPNombre    = lobRegUs.sia_prinom_usua;
                                lcrUsuarioSNombre    = lobRegUs.sia_segnom_usua;
                                lcrUsuarioFecNacimi  = Funciones.fcrConvertFecha((DateTime)lobRegUs.sia_fecnac_usua);
                                lcrUsuarioSexo       = lobRegUs.sis_codsex_sexo;
                            }
                            lcrCodigoDiagnostico = lobReg["Sia_coddia_tdia"].ToString();
                        }
                        #endregion
                        lcrLinea  = lobReg["Adm_secadm_rgad"].ToString() + lcrSepara +
                                    lcrFechaAdmision + lcrSepara +
                                    lobReg["Sia_codeps_teps"].ToString() + lcrSepara +
                                    lobReg["Sia_deseps_teps"].ToString() + lcrSepara +
                                    lobReg["Sia_tipide_tide"].ToString() + lcrSepara +
                                    lobReg["Sia_nroide_usua"].ToString() + lcrSepara +
                                    lcrUsuarioPApellido + lcrSepara +
                                    lcrUsuarioSApellido + lcrSepara +
                                    lcrUsuarioPNombre + lcrSepara +
                                    lcrUsuarioSNombre + lcrSepara +
                                    lcrUsuarioFecNacimi + lcrSepara +
                                    lcrUsuarioSexo + lcrSepara +
                                    lobReg["Sia_edaano_usua"].ToString() + lcrSepara +
                                    lobReg["Sia_edames_usua"].ToString() + lcrSepara +
                                    lobReg["Sia_edadia_usua"].ToString() + lcrSepara +
                                    lobReg["Sia_destip_regi"].ToString() + lcrSepara +
                                    lcrDatoFechaRemis + lcrSepara +
                                    lcrCodigoProfesional + lcrSepara +
                                    lcrNombreProfesional + lcrSepara +
                                    lcrDatoCodigoServ + lcrSepara +
                                    lcrDatoNombreServ + lcrSepara +
                                    lcrCodigoDiagnostico + lcrSepara +
                                    lobReg["Sia_desdia_tdia"].ToString();

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
                    lcrTextoTitulo = lcrRelleno.PadRight(100, '-') + "\r\n" + lcrTitulo + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-')+ "\r\n" +
                                     "TOTAL REGISTROS: "+ lnuTotalRegistros.ToString() + "\r\n" + lcrRelleno.PadRight(100, '-');
                    #region Titulos de campos
                    lcrTextoTitulo += "\r\n" +
                                    "Id.Registro.Admisión" + lcrSepara +
                                    "Fecha.Admisión" + lcrSepara +
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
                                    "Regimen" + lcrSepara +
                                    "Fecha.Remision" + lcrSepara +
                                    "Codigo.Profesional" + lcrSepara +
                                    "Nombre.Profesional" + lcrSepara +
                                    "Codigo.Serv.Solicitado" + lcrSepara +
                                    "Nombre.Serv.Solicitado" + lcrSepara +
                                    "Cod.Diagnostico" + lcrSepara +
                                    "Diagnostico";
                    #endregion
                }
                lcrReturn = lcrTextoTitulo + "\r\n" + lcrReturn;

            }
            #endregion
            return lcrReturn;
        }
        #region fobRegistroHistoricoCampos: Consultar datos en historicos guardados 
        /// <summary>
        /// <para>Consultar datos en historicos guardados </para>
        /// </summary>
        public DataRow fobRegistroHistoricoCampos(String tcrIdRegistroEvento, ModeloGrpplantvistcam tobRegistro)
        {
            DataRow lobReturn = null;
            var lcrConsultaSql = "SELECT * FROM " + tobRegistro.Hcl_nomarc_hccm.ToLower() + "01 WHERE hcl_nroreg_hcev ='" + tcrIdRegistroEvento + "'";
            var lobjDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrConsultaSql);

            if (lobjDatosTabla.Rows != null)
            {
                lobReturn = lobjDatosTabla.Rows[0];
            }
            return lobReturn;
        }
        #endregion
        #endregion
        #region flgGuardarDatosResumenINF07: Listado usuarios por servicios y fechas (sencillo)
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
            var lcrFcm_fecser_dfac = String.Empty; // Fecha del servicio
            var lcrCit_diasol_mcit = "0";          // Total dias solicitud cita
            var lcrFcm_horser_dfac = "0";          // Hora del servicio   
            DateTime ldaFcm_fecser_dfac;             // Codigo solicitud cita

            //var lobRegConfig = SISValidarCodigo.fobRegBuscarSisparametroips();
            #region Gestion datos
            if (tmpConsulta != null)
            {
                using (db = new DbAplicacion())
                {
                    foreach (DataRow lobReg in tmpConsulta.Rows)
                    {
                        #region Gestion datos
                        lcrCit_codasi_mcit = lobReg["cit_codasi_mcit"] != null ? lobReg["cit_codasi_mcit"].ToString().Trim() : String.Empty;
                        ldaFcm_fecser_dfac = Convert.ToDateTime(lobReg["fcm_fecser_dfac"].ToString());
                        lcrFcm_horser_dfac = lobReg["fcm_horser_dfac"].ToString();
                        lcrSia_fecnac_usua = Funciones.fcrConvertFecha(Convert.ToDateTime(lobReg["Sia_fecnac_usua"].ToString()));
                        lcrFcm_fecser_dfac = Funciones.fcrConvertFecha(ldaFcm_fecser_dfac);
                        lcrCit_fecsol_mcit = "00/00/0000";
                        lcrCit_diasol_mcit = "0";

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
                                    lobReg["Fcm_codser_mant"].ToString() + lcrSepara +
                                    lobReg["Fcm_desser_dfac"].ToString() + lcrSepara +
                                    lcrFcm_fecser_dfac + lcrSepara +
                                    lcrFcm_horser_dfac + lcrSepara +
                                    lcrCit_fecsol_mcit + lcrSepara +
                                    lcrCit_diasol_mcit + lcrSepara +
                                    lobReg["Fcm_valser_mant"].ToString() + lcrSepara +
                                    lobReg["Fcm_totuni_dfac"].ToString() + lcrSepara +
                                    lobReg["Fcm_valdes_dfac"].ToString() + lcrSepara +
                                    lobReg["Fcm_valcpa_dfac"].ToString() + lcrSepara +
                                    lobReg["Fcm_valcmo_dfac"].ToString() + lcrSepara +
                                    lobReg["Fcm_valusu_dfac"].ToString() + lcrSepara +
                                    lobReg["Fcm_codcpr_cpro"].ToString() + lcrSepara +
                                    lobReg["Fcm_descpr_cpro"].ToString();

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
                    lcrTextoTitulo = lcrRelleno.PadRight(100, '-') + "\r\n" + lcrTitulo + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-');
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
                                    "Codigo.Servicio" + lcrSepara +
                                    "Nombre.Servicio" + lcrSepara +
                                    "Fecha.Servicio" + lcrSepara +
                                    "Hora.Servicio" + lcrSepara +
                                    "Fecha.Solicita.Cita" + lcrSepara +
                                    "Dias.Solicita.Cita" + lcrSepara +
                                    "Valor.Servicio" + lcrSepara +
                                    "Unidades" + lcrSepara +
                                    "Descuento" + lcrSepara +
                                    "Copago" + lcrSepara +
                                    "Cuota.Moderadora" + lcrSepara +
                                    "Valor.Cargo.Usuario" + lcrSepara +
                                    "Codigo.Cent.Produccion" + lcrSepara +
                                    "Nombre.Cent.Produccion" + lcrSepara;
                    #endregion
                }
                lcrReturn = lcrTextoTitulo + "\r\n" + lcrReturn;

            }
            #endregion

            return lcrReturn;
        }
        #endregion
        #region flgGuardarDatosResumenINFXXX: Ejemplo pendiente
        /// <summary>
        /// <para>Ejemplo pendiente</para>
        /// </summary>
        public bool flgGuardarDatosResumenINFXXX()
        {
            var llgReturn = false;
            var llgRegsuma = false;
            var lcrFcm_codcpr_cpro = String.Empty;
            var lnuFcm_valfac_dfac = 0;
            var lcrFcm_coddig_mant = String.Empty;
            var lcrllave = String.Empty;

            if (tmpConsulta != null)
            {

                tmpResumen = new List<ClasseTmpResumen>();
                llgReturn = true;
                foreach (DataRow lobReg in tmpConsulta.Rows)
                {
                    var lobRegAux = new ClasseTmpResumen();
                    llgRegsuma = false;
                    // llave (se generara como parametro para compilar)
                    //lcrllave = lobReg.Cto_seccon_cont.Trim() + lobReg.Sia_codeps_teps.Trim(); //%%
                    lcrllave = lobReg["cto_seccon_cont"].ToString().Trim() + lobReg[2].ToString().Trim(); //%%

                    // Buscar en resumen
                    var lcrRegDat = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == lcrllave);
                    if (lcrRegDat == null)
                    {
                        lcrRegDat = new ClasseTmpResumen();

                        lcrRegDat.LlaveRegistro = lcrllave;
                        lcrRegDat.Texto1 = lobReg["cto_seccon_cont"].ToString().Trim();  //lobReg.Cto_seccon_cont; //0
                        lcrRegDat.Texto2 = lobReg["cto_nrocon_cont"].ToString().Trim();  //lobReg.Cto_nrocon_cont; //1 
                        lcrRegDat.Texto3 = lobReg["sia_codeps_teps"].ToString().Trim();  //lobReg.Sia_codeps_teps; //2
                        lcrRegDat.Texto4 = lobReg["sia_deseps_teps"].ToString().Trim();  //lobReg.Sia_deseps_teps; //3
                        lcrRegDat.Texto5 = lobReg["cto_descon_cont"].ToString().Trim();  //lobReg.Cto_descon_cont; //4
                        // Gaurdadr datos
                        tmpResumen.Add(lcrRegDat);

                    }
                    #region Condiciones
                    lcrFcm_codcpr_cpro = lobReg["fcm_codcpr_cpro"].ToString().Trim(); // Codigo centro de produccion lobReg.Fcm_codcpr_cpro
                    lnuFcm_valfac_dfac = Convert.ToInt32(lobReg["fcm_valfac_dfac"].ToString());
                    lcrFcm_coddig_mant = lobReg["fcm_coddig_mant"].ToString().Trim(); // Codigo de digitacion lobReg.Fcm_coddig_mant
                    // GR01 CONSULTA EXTERNA 
                    if (lcrFcm_codcpr_cpro == "1110" ||
                        lcrFcm_codcpr_cpro == "1408" ||
                        lcrFcm_codcpr_cpro == "1415")
                    {
                        if (llgRegsuma == false)
                        {
                            llgRegsuma = true;
                            lcrRegDat.Grupo1 += lnuFcm_valfac_dfac;
                        }
                    }
                    // GR02 OBSERVACION URGENCIAS
                    if (lcrFcm_codcpr_cpro == "1200" ||
                        lcrFcm_codcpr_cpro == "1501" ||
                        lcrFcm_codcpr_cpro == "1201" ||
                        lcrFcm_codcpr_cpro == "1418")
                    {
                        if (llgRegsuma == false)
                        {
                            llgRegsuma = true;
                            lcrRegDat.Grupo2 += lnuFcm_valfac_dfac;
                        }
                    }
                    // GR03 ODONTOLOGIA
                    if (lcrFcm_codcpr_cpro == "1311" ||
                        lcrFcm_codcpr_cpro == "1312" ||
                        lcrFcm_codcpr_cpro == "1313" ||
                        lcrFcm_codcpr_cpro == "1314")
                    {
                        if (llgRegsuma == false)
                        {
                            llgRegsuma = true;
                            lcrRegDat.Grupo3 += lnuFcm_valfac_dfac;
                        }
                    }
                    // GR04 REMISIONES
                    if (lcrFcm_coddig_mant == "T001" ||
                        lcrFcm_codcpr_cpro == "0008")
                    {
                        if (llgRegsuma == false)
                        {
                            llgRegsuma = true;
                            lcrRegDat.Grupo4 += lnuFcm_valfac_dfac;
                        }
                    }
                    // GR05 LABORATORIO CLINICO
                    if (lcrFcm_codcpr_cpro == "3100")
                    {
                        if (llgRegsuma == false)
                        {
                            llgRegsuma = true;
                            lcrRegDat.Grupo5 += lnuFcm_valfac_dfac;
                        }
                    }
                    // GR06 HOSPITALIZACION
                    if (lcrFcm_codcpr_cpro == "1502" ||
                        lcrFcm_codcpr_cpro == "1503" ||
                        lcrFcm_codcpr_cpro == "1504" ||
                        lcrFcm_codcpr_cpro == "1506" ||
                        lcrFcm_coddig_mant == "U009")
                    {
                        if (llgRegsuma == false)
                        {
                            llgRegsuma = true;
                            lcrRegDat.Grupo6 += lnuFcm_valfac_dfac;
                        }
                    }
                    // GR07 PROMOCION Y PREVENCION
                    if (lcrFcm_codcpr_cpro == "1114" ||
                        lcrFcm_codcpr_cpro == "1125" ||
                        lcrFcm_codcpr_cpro == "1314" ||
                        lcrFcm_codcpr_cpro == "1401" ||
                        lcrFcm_codcpr_cpro == "1402" ||
                        lcrFcm_codcpr_cpro == "1405" ||
                        lcrFcm_codcpr_cpro == "1407" ||
                        lcrFcm_codcpr_cpro == "1408" ||
                        lcrFcm_codcpr_cpro == "1409" ||
                        lcrFcm_codcpr_cpro == "1410" ||
                        lcrFcm_codcpr_cpro == "1411" ||
                        lcrFcm_codcpr_cpro == "1413" ||
                        lcrFcm_codcpr_cpro == "1415" ||
                        lcrFcm_codcpr_cpro == "1422" ||
                        lcrFcm_codcpr_cpro == "1423" ||
                        lcrFcm_codcpr_cpro == "1111" ||
                        lcrFcm_codcpr_cpro == "1112" ||
                        lcrFcm_codcpr_cpro == "1114" ||
                        lcrFcm_codcpr_cpro == "1113" ||
                        lcrFcm_codcpr_cpro == "0009" ||
                        lcrFcm_codcpr_cpro == "0010" ||
                        lcrFcm_codcpr_cpro == "0011" ||
                        lcrFcm_codcpr_cpro == "1406" ||
                        lcrFcm_codcpr_cpro == "1414")
                    {
                        if (llgRegsuma == false)
                        {
                            llgRegsuma = true;
                            lcrRegDat.Grupo7 += lnuFcm_valfac_dfac;
                        }
                    }
                    // GR08 DROGRAS Y FARMACIA
                    if (lcrFcm_codcpr_cpro == "6023" ||
                        lcrFcm_codcpr_cpro == "7720")
                    {
                        if (llgRegsuma == false)
                        {
                            llgRegsuma = true;
                            lcrRegDat.Grupo8 += lnuFcm_valfac_dfac;
                        }
                    }

                    #endregion
                }
            }
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
        #region fobTempFiltroSqlCitas: Generar temporal Detalles citas
        /// <summary>
        /// <para>Registros detalles informes citas</para>
        /// </summary>
        public DataTable flstConsultarDatos(String tcrTipoInforme, String tcrFechaIni, String tcrFechaFin)
        {
            DataTable objDatosTabla = new DataTable();
            var lcrLineaSqlSelct = String.Empty;

            switch (tcrTipoInforme)
            {
                case "INF01":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF02":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF03":
                    lcrLineaSqlSelct = fcrStringSQLInformes(tcrTipoInforme, tcrFechaIni, tcrFechaFin);
                    objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
                    break;

                case "INF07":
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
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", tcrFechaIni, "YMD", "-"); ;
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", tcrFechaFin, "YMD", "-");
            String lcrLineaSqlSelct = String.Empty;

            switch (tcrTipoInforme)
            {
                case "INF01":
                    #region Resmisiones desde urgencias a otras instituciones
                    lcrLineaSqlSelct = "SELECT  admregadmision.adm_secadm_rgad," +
                                            "admregadmision.adm_fecadm_rgad," +
                                            "admregadmision.sia_idesec_usua," +
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
                                            "admregadmision.sia_tipusu_regi," +
                                            "siaregimensalud.sia_destip_regi," +
                                            "admregadmision.sia_codeps_teps," +
                                            "siatablaeps.sia_deseps_teps," +
                                            "admregurgencias.adm_fecegr_regu," +
                                            "admregurgencias.adm_horegr_regu," +
                                            "admregurgencias.adm_diases_regu," +
                                            "admregurgencias.adm_horase_regu," +
                                            "admregurgencias.adm_secaut_aegr," +
                                            "admregurgencias.hos_codesp_espa," +
                                            "admregurgencias.sia_codpfa_prof," +
                                            "admregurgencias.adm_dessal_regr," +
                                            "admregurgencias.sia_dixsal_tdia," +
                                            "siadiagnosticos.sia_desdia_tdia," +
                                            "admregurgencias.sia_dixre1_tdia," +
                                            "admregurgencias.sia_dixre2_tdia," +
                                            "admregurgencias.sia_dixre3_tdia," +
                                            "admregurgencias.adm_observ_regu " +
                                     "FROM admregurgencias " +
                                          "INNER JOIN admregadmision ON (admregurgencias.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                          "INNER JOIN siausuarioatend ON (admregurgencias.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                          "INNER JOIN siatablaeps ON (admregadmision.sia_codeps_teps = siatablaeps.sia_codeps_teps) " +
                                          "INNER JOIN siaregimensalud ON (admregadmision.sia_tipusu_regi = siaregimensalud.sia_tipusu_regi) " +
                                          "INNER JOIN siadiagnosticos ON (admregurgencias.sia_dixsal_tdia = siadiagnosticos.sia_coddia_tdia) " +
                                     "WHERE admregurgencias.adm_fecegr_regu >= '" + lcrFechaIni + "' AND " +
                                          "admregurgencias.adm_fecegr_regu <= '" + lcrFechaFin + "' AND " +
                                          "admregurgencias.adm_dessal_regr ='2' " +
                                        "ORDER BY admregurgencias.adm_fecegr_regu,admregadmision.sia_tipusu_regi";
                    #endregion
                    break;

                case "INF02":
                    #region Resmisiones desde Hospitalizacion a otras instituciones
                    lcrLineaSqlSelct = "SELECT  admregadmision.adm_secadm_rgad," +
                                            "admregadmision.adm_fecadm_rgad," +
                                            "admregadmision.sia_idesec_usua," +
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
                                            "admregadmision.sia_tipusu_regi," +
                                            "siaregimensalud.sia_destip_regi," +
                                            "admregadmision.sia_codeps_teps," +
                                            "siatablaeps.sia_deseps_teps," +
                                            "admregistegreso.adm_fecegr_regr," +
                                            "admregistegreso.adm_horegr_regr," +
                                            "admregistegreso.adm_diases_regr," +
                                            "admregistegreso.adm_horase_regr," +
                                            "admregistegreso.adm_secaut_aegr," +
                                            "admregistegreso.sia_codpfa_prof," +
                                            "admregistegreso.adm_dessal_regr," +
                                            "admregistegreso.sia_dixing_tdia," +
                                            "admregistegreso.sia_dixsal_tdia," +
                                            "siadiagnosticos.sia_desdia_tdia," +
                                            "admregistegreso.adm_observ_regr " +
                                     "FROM admregistegreso " +
                                          "INNER JOIN admregadmision ON (admregistegreso.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                          "INNER JOIN siausuarioatend ON (admregistegreso.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                          "INNER JOIN siatablaeps ON (admregadmision.sia_codeps_teps = siatablaeps.sia_codeps_teps) " +
                                          "INNER JOIN siaregimensalud ON (admregadmision.sia_tipusu_regi = siaregimensalud.sia_tipusu_regi) " +
                                          "INNER JOIN siadiagnosticos ON (admregistegreso.sia_dixsal_tdia = siadiagnosticos.sia_coddia_tdia) " +
                                     "WHERE admregistegreso.adm_fecegr_regr >= '" + lcrFechaIni + "' AND " +
                                          "admregistegreso.adm_fecegr_regr <= '" + lcrFechaFin + "' AND " +
                                          "admregistegreso.adm_dessal_regr ='2' " +
                                        "ORDER BY admregistegreso.adm_fecegr_regr,admregadmision.sia_tipusu_regi";
                    #endregion
                    break;

                case "INF03":
                    #region Resmisiones desde consulta externa a otras instituciones
                    lcrLineaSqlSelct = "SELECT  admregadmision.adm_secadm_rgad," +
                                            "admregadmision.adm_fecadm_rgad," +
                                            "admregadmision.sia_idesec_usua," +
                                            "admregadmision.sia_tipide_tide," +
                                            "admregadmision.sia_nroide_usua," +
                                            "admregadmision.sia_edaano_usua," +
                                            "admregadmision.sia_edames_usua," +
                                            "admregadmision.sia_edadia_usua," +
                                            "admregadmision.sia_tipusu_regi," +
                                            "siaregimensalud.sia_destip_regi," +
                                            "admregadmision.sia_codeps_teps," +
                                            "siatablaeps.sia_deseps_teps," +
                                            "admregadmision.adm_fecadm_rgad," +
                                            "admregadmision.adm_horadm_rgad," +
                                            "admregadmision.sia_codpfa_prof," +
                                            "admregadmision.sia_coddia_tdia," +
                                            "admregadmision.sia_dixre1_tdia," +
                                            "admregadmision.sia_dixre2_tdia," +
                                            "admregadmision.sia_dixre3_tdia," +
                                            "siadiagnosticos.sia_desdia_tdia," +
                                            "admregadmision.adm_caucon_rgad " +
                                     "FROM admregadmision " +
                                          "INNER JOIN siatablaeps ON (admregadmision.sia_codeps_teps = siatablaeps.sia_codeps_teps) " +
                                          "INNER JOIN siaregimensalud ON (admregadmision.sia_tipusu_regi = siaregimensalud.sia_tipusu_regi) " +
                                          "INNER JOIN siadiagnosticos ON (admregadmision.sia_coddia_tdia = siadiagnosticos.sia_coddia_tdia) " +
                                     "WHERE adm_secadm_rgad IN "+
                                            "(SELECT  DISTINCT hclregiseventos.adm_secadm_rgad "+
                                                "FROM  hclregiseventos "+
                                                "WHERE (hclregiseventos.hcl_codreg_hcca = 'FRM-SOL-REMI-CEXTER' OR "+
                                                        "hclregiseventos.hcl_codreg_hcca = 'FRM-SOLIC-REMISION') AND " +
                                                        "hclregiseventos.hcl_gesfec_hcev >= '" + lcrFechaIni + "' AND " +
                                                        "hclregiseventos.hcl_gesfec_hcev <= '" + lcrFechaFin + "' AND " +
                                                        "hclregiseventos.sis_estpro_espr = '2') AND "+
                                                        "admregadmision.sia_regate_rgat = '2' "+
                                        "ORDER BY admregadmision.adm_fecadm_rgad";
                    #endregion
                    break;
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
                                  "admregadmision.adm_fecadm_rgad," +
                                  "admregadmision.sia_tipusu_regi," +
                                  "admregadmision.cit_codasi_mcit," +
                                  "fcmmaedetallfac.fcm_codser_mant," +
                                  "fcmmaedetallfac.fcm_coddig_mant," +
                                  "fcmmaedetallfac.fcm_desser_dfac," +
                                  "fcmmaedetallfac.fcm_fecser_dfac," +
                                  "fcmmaedetallfac.fcm_horser_dfac," +
                                  "fcmmaedetallfac.fcm_valser_mant," +
                                  "fcmmaedetallfac.fcm_valfac_dfac," +
                                  "fcmmaedetallfac.fcm_totuni_dfac," +
                                  "fcmmaedetallfac.fcm_valdes_dfac," +
                                  "fcmmaedetallfac.fcm_valcpa_dfac," +
                                  "fcmmaedetallfac.fcm_valcmo_dfac," +
                                  "fcmmaedetallfac.fcm_valusu_dfac," +
                                  "fcmmaedetallfac.fcm_codcpr_cpro," +
                                  "fcmcenproduccio.fcm_descpr_cpro" +
                                  " FROM " +
                                      "fcmmaedetallfac " +
                                      "INNER JOIN admregadmision ON(fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                      "INNER JOIN siausuarioatend ON(fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                      "INNER JOIN fcmcenproduccio ON (fcmmaedetallfac.fcm_codcpr_cpro = fcmcenproduccio.fcm_codcpr_cpro) " +
                                      "INNER JOIN siatablaeps ON (fcmmaedetallfac.sia_codeps_teps = siatablaeps.sia_codeps_teps)" +
                                  " WHERE " +
                                       "(fcmmaedetallfac.fcm_fecser_dfac >= '" + lcrFechaIni + "') AND " +
                                       "(fcmmaedetallfac.fcm_fecser_dfac <= '" + lcrFechaFin + "') AND " +
                                       "(fcmmaedetallfac.fcm_estfac_mfac = '2') " +
                                       "ORDER BY fcmmaedetallfac.sia_codeps_teps,fcmmaedetallfac.fcm_fecser_dfac";

                    break;
                    #endregion
            }
            return lcrLineaSqlSelct;
        }
        #endregion
    }
      
}

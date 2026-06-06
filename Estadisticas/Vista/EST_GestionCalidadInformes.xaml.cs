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
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;
using Sistema.Validacion;
using Estadisticas.Utilidades;
using Estadisticas.Modelo;
using Excel = Microsoft.Office.Interop.Excel;

namespace Estadisticas.Vista
{
    /// <summary>
    /// Interaction logic for EST_GestionCalidadInformes.xaml
    /// </summary>
    public partial class EstGestionCalidadInformes : Window, SIS_Interface
    {
        //-----------------------------------------------------------
        // Inicio Formulario
        //-----------------------------------------------------------
        #region Inicio Formulario
        Aplicacion oApp = Aplicacion.Instancia();
        public bool llgModoEdicionKey   = false;
        public bool llgModoEdicionValid = false;
        public bool llgObjetosCargados  = false;
        public bool glgVistaSeleccion   = false;
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public String gcrCtrF2TexBox;
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public HosProcesos m = new HosProcesos();
        //-----------------------------------------------------------
        // Tempoarles para Resumen
        #region Temporales 
        public ClasseTmpResumen         tmpRegActivoResumen = new ClasseTmpResumen();
        public List<ClasseTmpResumen>   tmpResumen = null;
        DialogVistaErrores              lobDlgLogs = null;
        public List<CrtForms.ListaComboBox> lstTipoFiltro;
        public EFctomaescontrato        tmpContrato = null;
        public List<ClassLista>         tmpLista = null;
        #endregion
        //-----------------------------------------------------------
        // Varaibles de control proceso
        #region Variables Parametros
        public static EFsisparametroips lobPrmReg = SISValidarCodigo.fobRegBuscarSisparametroips();
        static String lcrPrmIdNombreArchivo     = String.Empty;
        static String lcrPrmIPSCodigoPrestador  = lobPrmReg.sis_codips_pips;
        static String lcrPrmIPSTipoNit          = "NI";
        static String lcrPrmIPSCodigoNit        = (lobPrmReg.sis_nitips_pips.Replace("-", "")).Replace(".", "");
        static String lcrPrmIPSNombre           = lobPrmReg.sis_razsoc_pips;
        static String lcrPrmTipoInforme         = String.Empty;
        static String lcrPrmCodigoContrato      = String.Empty;
        static String lcrPrmCodigoEps           = String.Empty;
        static String lcrPrmRegimenSalud        = String.Empty;
        static String lcrPrmFechaIniFiltro      = "01/07/2015";
        static String lcrPrmFechaFinFiltro      = "30/07/2015";
        static DateTime ldaPrmFechaIniFiltro    = Funciones.fdaConvertFecha("DMY", "/", "01/07/2015");
        static DateTime ldaPrmFechaFinFiltro    = Funciones.fdaConvertFecha("DMY", "/", "30/07/2015");
        #endregion
        // Variables para gestion exportar
        #region Variables Gestion Planos
        public String gcrTipoFormatoDestino  = "TXT"; // TXT=Texto o XLS=Excel
        public String gcrTipoSeparadorCampo  = "|";   // Para archivos planos es el Pipe "|" para excel es la coma ","
        public String gcrExportarArchivoRuta = String.Empty;
        public int    gnuContadorvistaArchivos = 0;
        public String gcrNombreArchivoFisico = "INFORMES";
        public String gcrNombreArchivoOtros  = String.Empty;
        public String gcrExportarArchivoNombreyRuta = String.Empty;
        //- Varialbes para datos de texto
        public String gcrTextoArchivoCitas          = String.Empty;
        public String gcrTextoArchivoTriage         = String.Empty;
        public String gcrTextoArchivoEvnAdverso     = String.Empty;
        public String gcrTextoArchivoMedicamentos   = String.Empty;
        public String gcrTextoArchivoRes2175        = String.Empty;
        public String gcrTextoArchivoRes2193        = String.Empty;
        public int gnuTotalCitas = 0;
        public int gnuTotalTriage           = 0;
        public int gnuTotalMedicRegistros   = 0;
        public int gnuTotalMedicValCompras  = 0;
        public int gnuTotalMedicValVentas   = 0;
        public int gnuTotalRes2175          = 0;
        public int gnuTotalRes2193          = 0;
        public List<ClassMedicVenta> tmpMedicVentas = null;
        public List<ClassMedicCompra> tmpMedicCompras   = null;
        public List<ClassRes2175Tipo2> tmpRes2175Tipo2  = null;
        public List<ClassRes2175Tipo3> tmpRes2175Tipo3  = null;
        public List<ClassRes2175Tipo4> tmpRes2175Tipo4 = null;
        public List<ClassRes2175Tipo5> tmpRes2175Tipo5 = null;
        public List<ClassRes2175Tipo6> tmpRes2175Tipo6 = null;
        public List<ClassRes2175Tipo7> tmpRes2175Tipo7 = null;
        #endregion
        // Temporales de Rips 
        #region Variables gestion  tablas temporales
        public static tmpAdmision tobRegAdmision = null;
        public List<tmpRipsCT> tmpRipsArchivoControl = null;
        #endregion
        //-----------------------------------------------------------
        // Temporales para informe 2193
        #region Inicio Formulario
        DataTable tmpR025 = null; // Días estancia de los egresos obstétricos
        DataTable tmpR027 = null; // Días estancia de los egresos No quirúrgicos
        #endregion
        #endregion

        public EstGestionCalidadInformes()
        {
            InitializeComponent();

            llgObjetosCargados = true;
            IniciarComboBox();

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);

            this.dpkFiltroFechaInicio.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkFiltroFechaFin.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);

            fcvTimerGeneral();
            flgActivarObjetosVista("1");
            fcvVerficarRutaTemReportes(); 
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
        //  Clase propositos varios
        //------------------------------------------------------------
        #region Clase Cargar listas
        public class ClassLista
        {
            public ClassLista() { }
            public String RegistroCodigo { get; set; }
            public String RegistroDescrip { get; set; }
            public String RegistroTipo { get; set; }
            public String RegistroString { get; set; }
            public String RegistroTitulo { get; set; }
            public string campo1 { get; set; }
            public string campo2 { get; set; }
            public string campo3 { get; set; }
            public string campo4 { get; set; }
            public string campo5 { get; set; }
            public string campo6 { get; set; }
            public string campo7 { get; set; }
            public string campo8 { get; set; }
            public int valor1 { get; set; }
            public int valor2 { get; set; }
            public int valor3 { get; set; }
            public int valor4 { get; set; }
        }
        #endregion
        #region Ventas Medicamentos Sispro
        public class ClassMedicVenta
        {
            public ClassMedicVenta() { }
            public String Secuencial { get; set; }
            public String CodigoCum { get; set; }
            public int PrecioUnitMin { get; set; }
            public int PrecioUnitMax { get; set; }
            public int TotalBrutoVenta { get; set; }
            public int TotalUniVentas { get; set; }
            public String NumeroFacMinimo { get; set; }
            public String NumeroFacMaximo { get; set; }
        }
        #endregion
        #region Compras Medicamentos Sispro
        public class ClassMedicCompra
        {
            public ClassMedicCompra() { }
            public String Secuencial { get; set; }
            public String CodigoCum { get; set; }
            public int PrecioUnitMin { get; set; }
            public int PrecioUnitMax { get; set; }
            public int TotalBrutoCompra { get; set; }
            public int TotalUniCompras { get; set; }
            public String NumeroFacMinimo { get; set; }
            public String NumeroFacMaximo { get; set; }
        }
        #endregion
        #region Resolución 2175 Registro tipo 2 Sispro
        public class ClassRes2175Tipo2
        {
            public ClassRes2175Tipo2() { }
            public String   Secuencial { get; set; }
            public String   TipoId { get; set; }
            public String   NumeroId { get; set; }
            public String   FechaNac { get; set; }
            public String   Sexo { get; set; }
            public String   PertEtnica { get; set; }
            public String   PrimerApellido { get; set; }
            public String   SegundoApellido { get; set; }
            public String   PrimerNombre { get; set; }
            public String   SegundoNombre { get; set; }
            public String   TamizajeNeonatal { get; set; }
            public String   FechaTamizaje { get; set; }
        }
        #endregion
        #region Resolución 2175 Registro tipo 3 Sispro
        public class ClassRes2175Tipo3
        {
            public ClassRes2175Tipo3() { }
            public String Secuencial { get; set; }
            public String TipoId { get; set; }
            public String NumeroId { get; set; }
            public String FechaNac { get; set; }
            public String Sexo { get; set; }
            public String PertEtnica { get; set; }
            public String PrimerApellido { get; set; }
            public String SegundoApellido { get; set; }
            public String PrimerNombre { get; set; }
            public String SegundoNombre { get; set; }
            public String FechaAtencion { get; set; }
            public String Finalidad { get; set; }
            public String CodCups { get; set; }
            public String Peso { get; set; }
            public String Talla { get; set; }
            public String FecSulfato { get; set; }
            public String FecVitaminaA { get; set; }
            public String FecMicronutrientes { get; set; }
            public String FecHemoglobina { get; set; }
            public String ResHemoglobina { get; set; }
        }
        #endregion
        #region Resolución 2175 Registro tipo 4 Sispro
        public class ClassRes2175Tipo4
        {
            public ClassRes2175Tipo4() { }
            public String Secuencial { get; set; }
            public String TipoId { get; set; }
            public String NumeroId { get; set; }
            public String FechaNac { get; set; }
            public String Sexo { get; set; }
            public String PertEtnica { get; set; }
            public String PrimerApellido { get; set; }
            public String SegundoApellido { get; set; }
            public String PrimerNombre { get; set; }
            public String SegundoNombre { get; set; }
            public String FechaAtencion { get; set; }
            public String Finalidad { get; set; }
            public String CodCups { get; set; }
            public String Peso { get; set; }
            public String Talla { get; set; }
            public String FecHemoglobina { get; set; }
            public String ResHemoglobina { get; set; }
        }
        #endregion
        #region Resolución 2175 Registro tipo 5 Sispro
        public class ClassRes2175Tipo5
        {
            public ClassRes2175Tipo5() { }
            public String Secuencial { get; set; }
            public String TipoId { get; set; }
            public String NumeroId { get; set; }
            public String FechaNac { get; set; }
            public String Sexo { get; set; }
            public String PertEtnica { get; set; }
            public String PrimerApellido { get; set; }
            public String SegundoApellido { get; set; }
            public String PrimerNombre { get; set; }
            public String SegundoNombre { get; set; }
            public String FechaAtencion { get; set; }
            public String Finalidad { get; set; }
            public String CodCups { get; set; }
            public String Peso { get; set; }
            public String Talla { get; set; }
            public String FecHemoglobina { get; set; }
            public String ResHemoglobina { get; set; }
        }
        #endregion
        #region Resolución 2175 Registro tipo 6 Sispro
        public class ClassRes2175Tipo6
        {
            public ClassRes2175Tipo6() { }
            public String Secuencial { get; set; }
            public String TipoId { get; set; }
            public String NumeroId { get; set; }
            public String PrimerApellido { get; set; }
            public String SegundoApellido { get; set; }
            public String PrimerNombre { get; set; }
            public String SegundoNombre { get; set; }
            public String FechaNac { get; set; }
            public String EdadGestacional { get; set; }
            public String PertEtnica { get; set; }
            public String FechaAtencion { get; set; }
            public String Finalidad { get; set; }
            public String CodCups { get; set; }           
            public String FecAcidoFolico { get; set; }
            public String FecSulfatoFerroso { get; set; }
            public String FecCarbonatoCalcio { get; set; }
            public String FecAntigenoSupHep { get; set; }
            public String ResAntigenoSupHep { get; set; }
            public String FecTomaSerologia { get; set; }
            public String ResSerologiaSifilis { get; set; }
            public String FecAsesPreTestElisa { get; set; }
            public String FecTomaTestElisa { get; set; }
            public String ResTestElisaVIH { get; set; }
            public String FecHemoglobina { get; set; }
            public String ResHemoglobina { get; set; }
            public String FecConsLactMaterna { get; set; }
        }
        #endregion
        #region Resolución 2175 Registro tipo 7 Sispro
        public class ClassRes2175Tipo7
        {
            public ClassRes2175Tipo7() { }
            public String Secuencial { get; set; }
            public String TipoId { get; set; }
            public String NumeroId { get; set; }
            public String PrimerApellido { get; set; }
            public String SegundoApellido { get; set; }
            public String PrimerNombre { get; set; }
            public String SegundoNombre { get; set; }
            public String PertEtnica { get; set; }
            public String FechaAtenParto { get; set; }
            public String Finalidad { get; set; }
            public String CodCups { get; set; }
            public String TomaPruebaSifilis { get; set; }
            public String FecTomaPruebaSifilis { get; set; }
            public String ResSerologiaSifilis { get; set; }
            public String AsesPreTestElisa { get; set; }
            public String FecAsesPreTestElisa { get; set; }
            public String TomaTestElisa { get; set; }
            public String FecTomaTestElisa { get; set; }
            public String ResTestElisaVIH { get; set; }
            public String SuministroAntconcep { get; set; }
            public String FecSuminAntconcep { get; set; }
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

                case "txtG1Cto_seccon_cont":
                    this.txtG1Sia_codeps_teps.Text = String.Empty;
                    this.txtG1Cto_seccon_cont.Text = tcrCodigo;
                    gcrCtrF2TexBox = String.Empty;
                    break;

                case "txtG1Sia_codeps_teps":
                    this.txtG1Sia_codeps_teps.Text = tcrCodigo;
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
        #endregion
        //-------------------------------------------------
        // Eventos Auxiliares
        //-------------------------------------------------
        #region Eventos Auxiliares
        private void fcvMostrarMenuEdicion(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
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
        #region fcvVerficarRutaTemReportes: Crear ruta Generar reportes Rips
        /// <summary>
        /// Verificar cuando no existe la ruta tempral para los reportes Rips y la crea 
        /// </summary>
        private void fcvVerficarRutaTemReportes()
        {
            if (!Directory.Exists(oApp.gcrAppPathInicioTempReportes + @"\InformesCalidad\"))
            {
                Directory.CreateDirectory(oApp.gcrAppPathInicioTempReportes + @"\InformesCalidad");
            }
            this.txtRutaDestinoPlanos.Text = oApp.gcrAppPathInicioTempReportes + @"\InformesCalidad\";
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
                    case "dpkFiltroFechaInicio":
                        this.txtFiltroFechaInicio.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, this.txtFiltroFechaInicio);
                        break;

                    case "dpkFiltroFechaFin":
                        this.txtFiltroFechaFin.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, this.txtFiltroFechaFin);
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
                            case "txtFiltroFechaInicio":
                                this.dpkFiltroFechaInicio.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtFiltroFechaFin":
                                this.dpkFiltroFechaFin.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
                        case "cboTipoInforme":
                            this.txtTipoInforme.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtTipoInforme.Text, ",", lobList.ListaValoresSel) - 1;
                            flgActivarObjetosVista(this.txtTipoInforme.Text);
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
                        case "txtTipoInforme":
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
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Cto_seccon_cont"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codeps_teps"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFiltroFechaInicio"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFiltroFechaFin"))) { lnuCont++; }

            this.cmdGenerar.IsEnabled = lnuCont > 0 ? false : true;

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

            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgValidDefault = false;

            try
            {

                switch (tcrNombrePropiedad)
                {
                    case "txtG1Cto_seccon_cont":
                        #region Validacion
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(this.txtG1Cto_seccon_cont.Text))
                        {
                            this.txtG1Cto_nrocon_cont.Text = String.Empty;
                            this.txtG1Cto_descon_cont.Text = String.Empty;
                            //this.txtG1Sia_codeps_teps.Text = String.Empty;
                        }
                        else
                        {
                            tmpContrato = CTOValidarCodigo.fobRegBuscarCtomaescontratoEx(this.txtG1Cto_seccon_cont.Text);
                            if (tmpContrato != null)
                            {
                                this.txtG1Cto_nrocon_cont.Text = tmpContrato.cto_nrocon_cont;
                                this.txtG1Cto_descon_cont.Text = tmpContrato.cto_descon_cont;
                                if (gcrCtrF2TexBox == "txtG1Cto_seccon_cont")
                                {
                                    this.txtG1Sia_codeps_teps.Text = String.IsNullOrWhiteSpace(this.txtG1Sia_codeps_teps.Text) ?
                                                                                              tmpContrato.sia_codeps_teps : this.txtG1Sia_codeps_teps.Text;
                                }
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
                        lcrNombreCampo = "Código Empresa (EPS)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (!String.IsNullOrWhiteSpace(this.txtG1Sia_codeps_teps.Text))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatablaepsEx(this.txtG1Sia_codeps_teps.Text);
                            if (tmp != null)
                            {
                                this.txtG1Sia_deseps_teps.Text = tmp.sia_deseps_teps;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            this.txtG1Sia_deseps_teps.Text = String.Empty;
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codeps_teps, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFiltroFechaInicio":
                        #region Validación
                        lcrNombreCampo = "Fecha inicio periodo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtFiltroFechaInicio.Text, lcrNombreCampo);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtFiltroFechaFin.Text, lcrNombreCampo)))
                            {
                                if (!Funciones.flgValidarRangoFecha(this.txtFiltroFechaInicio.Text, this.txtFiltroFechaFin.Text))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": debe ser menor o igual a la fecha fin del periodo";
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtFiltroFechaInicio, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFiltroFechaFin":
                        #region Validación
                        lcrNombreCampo = "Fecha final perido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtFiltroFechaFin.Text, lcrNombreCampo);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtFiltroFechaInicio.Text, lcrNombreCampo)))
                            {
                                if (!Funciones.flgValidarRangoFecha(this.txtFiltroFechaInicio.Text, this.txtFiltroFechaFin.Text))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": debe ser mayor o igual a la fecha inicial del periodo";
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtFiltroFechaFin, lcrValorReturn);
                        break;
                        #endregion

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
        #region flgActivarObjetosVista: Activa o desactiva los objetos en la vista segun el tipo filtro
        /// <summary>
        /// Activa o desactiva los objetos en la vista segun el tipo filtro 
        /// <para>PARAMETRO:</para>
        /// <para>tcrTipoFiltro: 1 = Vista Filtro segun parametros 2 = Filtro Cuenta de cobro</para>
        /// </summary>
        public bool flgActivarObjetosVista(String tcrTipoFiltro)
        {
            var llgReturn = true;

            this.txtG1Cto_seccon_cont.IsEnabled = true;
            this.txtG1Sia_codeps_teps.IsEnabled = true;
            this.cmdG1Contrato.IsEnabled = true;
            this.cmdG1CodigoEps.IsEnabled = true;

            this.txtG1Cto_seccon_cont.Text = String.Empty;
            this.txtG1Cto_nrocon_cont.Text = String.Empty;
            this.txtG1Cto_descon_cont.Text = String.Empty;
            this.txtG1Sia_codeps_teps.Text = String.Empty;
            this.txtG1Sia_deseps_teps.Text = String.Empty;
            this.txtFiltroFechaInicio.Text = String.Empty;
            this.txtFiltroFechaFin.Text    = String.Empty;

            flgValidacion();

            return llgReturn;
        }
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
                String lcrG11Seleccion = "1,2,3,4,5,6,7,8";
                String lcrG11Descripcion = "Oportunidad del servicio (citas),Resolución 256 - Oportunidad (citas) Triage y eventos adversos,"+
                                           "Oportunidad y Triage Resolución 2193,Oportunidad de Citas Resolución 2193,"+
                                           "Sispro Compra Medicamentos (Circular 002 de 2011),Sispro Venta Medicamentos (Circular 002 de 2011),"+
                                           "Sispro - Menores de 18 años; gestantes y atención de partos (Resolución 2175 de 2015),"+
                                           "Resumen producción servicios (Resolución 2193)";
                lstTipoFiltro = new List<CrtForms.ListaComboBox>();
                lstTipoFiltro = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion, "1");
                //- Asignar al control
                this.cboTipoInforme.ItemsSource = lstTipoFiltro;
                this.cboTipoInforme.SelectedIndex = Convert.ToInt32(lstTipoFiltro[0].IdIndice);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        //---------------------------------------------------------------
        // EXPORTAR DATOS A PLANO O EXCEL
        //---------------------------------------------------------------
        #region fcvCargarParametros: Cargar parametros para generar de planos
        /// <summary>
        /// Cargar parametros para generar de planos
        /// </summary>
        private void fcvCargarParametros()
        {
            #region Cargar datos en variables
            lcrPrmTipoInforme       = this.txtTipoInforme.Text;
            lcrPrmCodigoContrato    = this.txtG1Cto_seccon_cont.Text.Trim();
            lcrPrmCodigoEps         = this.txtG1Sia_codeps_teps.Text;
            lcrPrmFechaIniFiltro    = this.txtFiltroFechaInicio.Text.Trim();
            lcrPrmFechaFinFiltro    = this.txtFiltroFechaFin.Text.Trim();
            ldaPrmFechaIniFiltro    = Funciones.fdaConvertFecha("DMY", "/", this.txtFiltroFechaInicio.Text);
            ldaPrmFechaFinFiltro    = Funciones.fdaConvertFecha("DMY", "/", this.txtFiltroFechaFin.Text);
            gcrExportarArchivoRuta  = this.txtRutaDestinoPlanos.Text.Trim();

            // Nombre de archivo segun tipo informe
            if (this.txtTipoInforme.Text == "1" ||
                this.txtTipoInforme.Text == "2" ||
                this.txtTipoInforme.Text == "3" ||
                this.txtTipoInforme.Text == "5" ||
                this.txtTipoInforme.Text == "6" ||
                this.txtTipoInforme.Text == "7" ||
                this.txtTipoInforme.Text == "8")
            {
                gcrNombreArchivoFisico = fcrGenerarNombreArchivo(this.txtTipoInforme.Text);
            }
            #endregion
        }
        #endregion
        #region fcrGenerarNombreArchivo: Generar nombre archivos
        /// <summary>
        /// Generar nombre archivos
        /// </summary>
        private String fcrGenerarNombreArchivo(String tcrTipoArchivo)
        {
            var lcrNombre = String.Empty;

            if (tcrTipoArchivo == "1" || tcrTipoArchivo == "2" || tcrTipoArchivo == "3") // Informe citas o Citas y Triage
            {
                var lcrNit          = lcrPrmIPSCodigoNit;
                var lcrFecha        = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");
                var lnuTotalRelleno = 12 - lcrNit.Length;

                // complementar 
                lcrNit = lcrPrmIPSCodigoNit.PadLeft(lnuTotalRelleno, '0').Trim();
                lcrFecha    = lcrFecha.Replace("-", "");

                // Nombre completo ejemplo: MCA195MOCA20160630NI000824002672C01
                lcrNombre = "MCA195MOCA" + lcrFecha + lcrPrmIPSTipoNit + lcrNit + "C01";
            }
            else if (tcrTipoArchivo == "5")
            {
                var lcrNit = "824002672"; // ----- OJO PARAMETRIZAR
                var lcrFecha = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");
                var lnuTotalRelleno = 12 - lcrNit.Length;

                // complementar 
                lcrNit = lcrNit.PadLeft(lnuTotalRelleno, '0').Trim();
                lcrFecha = lcrFecha.Replace("-", "");

                // Sispro Compra Medicamentos
                lcrNombre = "MED114MCOM" + lcrFecha + lcrPrmIPSTipoNit + lcrNit;
            }
            else if (tcrTipoArchivo == "6")
            {
                var lcrNit          = "824002672"; // ----- OJO PARAMETRIZAR
                var lcrFecha        = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");
                var lnuTotalRelleno = 12 - lcrNit.Length;

                // complementar 
                lcrNit = lcrNit.PadLeft(lnuTotalRelleno, '0').Trim();
                lcrFecha = lcrFecha.Replace("-", "");

                // Sispro Venta Medicamentos
                lcrNombre = "MED113MVEN" + lcrFecha + lcrPrmIPSTipoNit + lcrNit;
            }
            else if (tcrTipoArchivo == "7")
            {
                var lcrNit = "824002672"; // ----- OJO PARAMETRIZAR
                var lcrFecha = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");
                var lnuTotalRelleno = 12 - lcrNit.Length;

                // complementar 
                lcrNit = lcrNit.PadLeft(lnuTotalRelleno, '0').Trim();
                lcrFecha = lcrFecha.Replace("-", "");

                // Sispro Venta Medicamentos
                lcrNombre = "REC165ATGE" + lcrFecha + lcrPrmIPSTipoNit + lcrNit;
            }
            else if (tcrTipoArchivo == "8")
            {
                // Resumen general 2193 
                gnuContadorvistaArchivos++;

                lcrNombre = gnuContadorvistaArchivos.ToString().Trim() + "-" + Funciones.fnuFechaLlaveIndiceRegistro().ToString().Trim();
                lcrNombre = "RESUMEN-GENERAL-2193-" + lcrNombre;

            }
            return lcrNombre;
        }
        #endregion
        #region fcvLimpiarTextoPlanos: Limpiar las variables para generar texto Planos Rips
        /// <summary>
        /// <para>Limpiar las variables para generar texto Planos Rips</para>
        /// </summary>
        public void fcvLimpiarTextoPlanos()
        {
            #region Variables Gestion Planos
            gcrExportarArchivoRuta      = String.Empty;
            gcrTextoArchivoCitas        = String.Empty;
            gcrTextoArchivoTriage       = String.Empty;
            gcrTextoArchivoMedicamentos = String.Empty;
            #endregion
            tobRegAdmision          = null;
            tmpRipsArchivoControl   = new List<tmpRipsCT>();
            tmpMedicVentas          = new List<ClassMedicVenta>();

            this.stkHistorial.Children.Clear();
        }
        #endregion
        #region fcvEliminarArchivosGenerados: Eliminar archivos planos pre-existentes
        /// <summary>
        /// <para>Eliminar archivos planos o de excel pre-existentes</para>
        /// </summary>
        public void fcvEliminarArchivosGenerados()
        {
            #region Eliminar archivos planos pre-existentes
            var lcrArchivo = String.Empty;

            // Archvos tipo informe citas
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoFisico + "." + gcrTipoFormatoDestino;
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Otros por ahora 
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoOtros + "." + gcrTipoFormatoDestino;
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            #endregion
        }
        #endregion
        //- Exportar a plano procesos generales
        #region fcvExportarFormatoPlano: Exportar formato archivos planos
        private void fcvExportarFormatoPlano(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Desea generar datos en formato Archivos Planos?", "Galeno Versión 4.0",
                                                       MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Exportando datos en formato planos...", "CENTRO");
                lobDlgAdd.Show();

                gcrTipoFormatoDestino = "TXT"; // TXT=Texto o XLS=Excel

                // Para archivos planos es el Pipe "|" para excel es la coma ","
                if (this.txtTipoInforme.Text == "5" || this.txtTipoInforme.Text == "6" || this.txtTipoInforme.Text == "8")
                {
                    gcrTipoSeparadorCampo = ",";  
                }
                else
                {
                    gcrTipoSeparadorCampo = "|";  
                }

                fcvLimpiarTextoPlanos();
                fcvCargarParametros();
                fcvEliminarArchivosGenerados();
                flgGenerarStringForamtoPlano(gcrTipoFormatoDestino);

                lobDlgAdd.Close();

                MessageBox.Show("Proceso finalizado con éxito!!");
            }
        }
        #endregion
        #region flgGenerarStringForamtoPlano: Genera la string de datos para archivos planos
        /// <summary>
        /// <para>Genera la string de datos para archivos planos o exportar a Excel</para>
        /// </summary>
        public bool flgGenerarStringForamtoPlano(String tcrTipoDestino)
        {
            var llgReturn = false;
            var lcrArchivo = String.Empty;

            if (!string.IsNullOrEmpty(gcrExportarArchivoRuta))
            {
                llgReturn = true;
                //------------------------------------------------
                // GENERAR ARCHIVOS
                //------------------------------------------------
                if (this.txtTipoInforme.Text == "1")
                {
                    // Solo Archivo Citas
                    #region citas
                    fcvLeerTextoInformeCitas256(gcrTipoSeparadorCampo);
                    gcrTextoArchivoCitas = fcrLeerTextoRegistroControl("1", gnuTotalCitas, gcrTipoSeparadorCampo) + "\r\n" + gcrTextoArchivoCitas;
                    flgExportarForamtoPlano(gcrNombreArchivoFisico, tcrTipoDestino, gcrTextoArchivoCitas);
                    #endregion
                }
                else if (this.txtTipoInforme.Text == "2")
                {
                    // Citas y Triage
                    #region citas y Ty riage
                    var lcrTextoArchivo = String.Empty;
                    var lnuTotalRegistros = 0;

                    // Cargar los datos 
                    fcvLeerTextoInformeCitas256(gcrTipoSeparadorCampo);
                    fcvLeerTextoInformeTriage256(gcrTipoSeparadorCampo);

                    // Cargar datos generados
                    lcrTextoArchivo = gcrTextoArchivoCitas + "\r\n" + gcrTextoArchivoTriage;
                    lnuTotalRegistros = gnuTotalCitas + gnuTotalTriage;
                    lcrTextoArchivo = fcrLeerTextoRegistroControl("1", lnuTotalRegistros, gcrTipoSeparadorCampo) + "\r\n" + lcrTextoArchivo;

                    // Generar plano
                    flgExportarForamtoPlano(gcrNombreArchivoFisico, tcrTipoDestino, lcrTextoArchivo);
                    #endregion
                }
                else if (this.txtTipoInforme.Text == "3")
                {
                    // Citas y Triage 2193
                    #region citas y triage 2193
                    var lcrTextoArchivo = String.Empty;
                    //var lnuTotalRegistros = 0;

                    // Cargar los datos 
                    fcvLeerTextoInformeCitas2193(gcrTipoSeparadorCampo);
                    fcvLeerTextoInformeTriage2193(gcrTipoSeparadorCampo);

                    // Cargar datos generados
                    lcrTextoArchivo = gcrTextoArchivoCitas + "\r\n" + gcrTextoArchivoTriage;
                    //lnuTotalRegistros = gnuTotalCitas + gnuTotalTriage;
                    //lcrTextoArchivo = fcrLeerTextoRegistroControl("1", lnuTotalRegistros, gcrTipoSeparadorCampo) + "\r\n" + lcrTextoArchivo;

                    // Generar plano
                    flgExportarForamtoPlano(gcrNombreArchivoFisico, tcrTipoDestino, lcrTextoArchivo);
                    #endregion
                }
                else if (this.txtTipoInforme.Text == "5")
                {
                    // Informe Sispro Compra Medicamentos
                    #region Informe sispro
                    var lcrTextoArchivo = String.Empty;

                    // Cargar los datos 
                    fcvLeerTextoInformeSisproMedicCompras(gcrTipoSeparadorCampo);

                    // Cargar datos generados
                    lcrTextoArchivo = fcrLeerTextoRegistroControlCompraMedic(gcrTipoSeparadorCampo) + "\r\n" + gcrTextoArchivoMedicamentos;

                    // Generar plano
                    flgExportarForamtoPlano(gcrNombreArchivoFisico, tcrTipoDestino, lcrTextoArchivo);
                    #endregion
                }
                else if (this.txtTipoInforme.Text == "6")
                {
                    // Informe Sispro Venta Medicamentos
                    #region Sispro medicamentos
                    var lcrTextoArchivo = String.Empty;

                    // Cargar los datos 
                    fcvLeerTextoInformeSisproMedicVentas(gcrTipoSeparadorCampo);

                    // Cargar datos generados
                    lcrTextoArchivo = fcrLeerTextoRegistroControlVentaMedic(gcrTipoSeparadorCampo) + "\r\n" + gcrTextoArchivoMedicamentos;

                    // Generar plano
                    flgExportarForamtoPlano(gcrNombreArchivoFisico, tcrTipoDestino, lcrTextoArchivo);
                    #endregion
                }
                else if (this.txtTipoInforme.Text == "7")
                {
                    // Informe Sispro Resolución 2175
                    #region Sispro Resolución 2175
                    var lcrTextoArchivo = String.Empty;

                    // Cargar los datos 
                    fcvLeerTextoInformeSisproRes2175(gcrTipoSeparadorCampo);

                    // Cargar datos generados
                    lcrTextoArchivo = fcrLeerTextoRegistroControlRes2175(gcrTipoSeparadorCampo) + "\r\n" + gcrTextoArchivoRes2175;

                    // Generar plano
                    flgExportarForamtoPlano(gcrNombreArchivoFisico, tcrTipoDestino, lcrTextoArchivo);
                    #endregion
                }
                else if (this.txtTipoInforme.Text == "8")
                {
                    // Informe Resumen general Resolución 2193
                    #region Resumen general Resolución 2193
                    //var lcrTextoArchivo = String.Empty;

                    // Cargar los datos 
                    fcvLeerTextoInformeResumen2193(gcrTipoSeparadorCampo);

                    // Generar plano
                    flgExportarForamtoPlano(gcrNombreArchivoFisico, tcrTipoDestino, gcrTextoArchivoRes2193);
                    #endregion
                }

                // Mostrar resumen en vista
                fcvGenerarVistaPantallaProceso();
            }
            return llgReturn;
        }
        #endregion
        #region flgExportarForamtoPlano: Exportar datos a archivo plano
        /// <summary>
        /// <para>Exportar datos a archivo plano</para>
        /// <para>tcrTipoDestino: TXT = Archivo plano XLS=Archivo Excel</para>
        /// </summary>
        public bool flgExportarForamtoPlano(String tcrNombreArchivo, String tcrTipoDestino, String tcrStringDatos)
        {
            var llgReturn = false;
            gcrExportarArchivoNombreyRuta = tcrTipoDestino == "TXT" ? gcrExportarArchivoRuta : System.IO.Path.GetTempPath(); // cuando es excel es una ruta temp del sistema
            gcrExportarArchivoNombreyRuta = gcrExportarArchivoNombreyRuta + tcrNombreArchivo + ".TXT";

            if (!string.IsNullOrEmpty(gcrExportarArchivoNombreyRuta))
            {
                llgReturn = true;
                if (tcrTipoDestino == "TXT")
                {
                    // Plano normal
                    System.IO.File.WriteAllText(@gcrExportarArchivoNombreyRuta, tcrStringDatos, Encoding.Default);
                }
                else
                {
                    // Plano para abrir en Excel
                    System.IO.File.WriteAllText(@gcrExportarArchivoNombreyRuta, tcrStringDatos, Encoding.UTF8);
                }
            }
            return llgReturn;
        }
        #endregion
        //-----------------------------------------------------------
        // Exportar a Excel
        #region fcvExportarForamtoExcel: Accion desde boton exportar a excel opcion desde menu
        private void fcvExportarForamtoExcel(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Desea exportar los datos a Microsoft Excel?", "Galeno Versión 4.0",
                                                       MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var lobDlgAddx = new DialogProgressBarEx();
                lobDlgAddx.fcvProgressBarIniciar("Generando los datos...", "CENTRO");
                lobDlgAddx.Show();

                gcrTipoFormatoDestino = "XLS"; // TXT=Texto o XLS=Excel
                gcrTipoSeparadorCampo = this.txtTipoInforme.Text != "8" ? "," : "|";   // Para archivos planos es el Pipe "|" para excel es la coma ","
                fcvLimpiarTextoPlanos();
                fcvCargarParametros();
                fcvEliminarArchivosGenerados();
                flgGenerarStringForamtoPlano(gcrTipoFormatoDestino);

                lobDlgAddx.Close();

                if (this.txtTipoInforme.Text != "8")
                {
                    flgExportarFormatoExcel();
                }
                else
                {
                    flgInforme8_ExcelResumeGeneral2193();
                }
            }
        }
        #endregion
        #region flgExportarFormatoExcel: Exportar datos a archivo excel
        /// <summary>
        /// <para>Exportar datos a archivo excel</para>
        /// </summary>
        private bool flgExportarFormatoExcel()
        {
            // Generando datos en temporal planos
            // Exportando a Excel
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Abriendo en Microsoft Excel...", "CENTRO");
            lobDlgAdd.Show();

            var llgreturn = true;
            // Generar los d atos

            Excel.Application lobApp;
            Excel.Workbook lobLibroTrabajo;

            lobApp = new Excel.Application();
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;

            // Cargar todos los campos interpretando todo en formato texto
            object objInfoFormatoCampos = new int[16, 2] {{ 1, 2 },{ 2, 2 },{ 3, 2 }, { 4, 2 },{ 5, 2 },{ 6, 2 },{ 7, 2 },{ 8, 2 },{ 9, 2 },{ 10, 2 },
                                        { 11, 2 },{ 12, 2 },{ 13, 2},{ 14, 2 },{ 15, 2},{ 16, 2 }};

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8
            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                     Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, true, luxValue, luxValue, gcrTipoSeparadorCampo, objInfoFormatoCampos,
                                      luxValue, luxValue, luxValue, luxValue, luxValue); // Abrir el archivo plano 

            // referencial el libro activo cargado
            lobLibroTrabajo = lobApp.Workbooks.get_Item(1);

            try
            {
                //String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs("ARCHIVO.XLS", Excel.XlFileFormat.xlWorkbookNormal);
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            lobDlgAdd.Close();

            return llgreturn;
        }
        #endregion
        // Excel Informes cada uno
        #region flgInforme8_ExcelResumeGeneral2193: Informe General 2193
        /// <summary>
        /// <para>Informe General 2193</para>
        /// </summary>
        private bool flgInforme8_ExcelResumeGeneral2193()
        {
            DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Abriendo en Microsoft Excel...", "CENTRO");
            lobDlgAdd.Show();

            var llgreturn = true;
            var luxValue = Type.Missing;  //System.Reflection.Missing.Value;
            String lcrMisDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            #region Gestion Excel
            Excel.Application lobApp;
            lobApp = new Excel.Application();
            Excel.Workbook lobLibroTrabajo;

            // Cargar los dos primeros campos en formato texto los demas en numericos
            object objInfoFormatoCampos = new int[7, 2] { { 1, 2 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 }, { 6, 1 }, { 7, 1 } };

            // Se carga el archivo plano desde la ruta para ser exportado
            // Parametro Origin: 65001 es para cargar en UTF8

            lobApp.Workbooks.OpenText(gcrExportarArchivoNombreyRuta, 65001, 1, Excel.XlTextParsingType.xlDelimited,
                                      Excel.XlTextQualifier.xlTextQualifierNone,
                                      luxValue, luxValue, true, false, luxValue, true, gcrTipoSeparadorCampo, objInfoFormatoCampos,
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

                // Guardar como archivo de Excel
                //lobApp.DisplayAlerts = false;
                //lobLibroTrabajo.SaveAs(gcrNombreArchivoFisico + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);

                // Recorrer la hoja para resaltar los titulos
                var lobHoja = (Excel.Worksheet)lobLibroTrabajo.Worksheets.get_Item(1);
                // rango de filas uasadas
                var lnuRangoFilas = (lobHoja.UsedRange).Rows.Count;
                lobHoja.Cells[1, 1].ColumnWidth = 80; // Cambiar el ancho de la columna

                #endregion
                #region Recorrer todo el archivo
                var i = 3;
                for (i = 3; i < lnuRangoFilas; i++)
                {
                    // Titulo valor total
                    #region Titulo valor total
                    if ((lobHoja.Cells[i, 7] as Excel.Range).Value2 != null)
                    {
                        var lcrValor = (lobHoja.Cells[i, 7] as Excel.Range).Value2.ToString();
                        if (lcrValor == "Total")
                        {
                            // resaltar los titulos
                            lobApp.get_Range("A" + i.ToString().Trim() + ":G" + i.ToString().Trim()).Select();
                            //lobApp.Selection.AutoFormat(3, true, true, false, true, true, false);
                            lobApp.Selection.Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                        }
                    }
                    #endregion
                }
                #endregion

                // Guardar como archivo de Excel
                lobApp.DisplayAlerts = false;
                lobLibroTrabajo.SaveAs(gcrNombreArchivoFisico + ".XLS", Excel.XlFileFormat.xlWorkbookNormal);

                lobDlgAdd.Close();
                // Mostrar Excel
                lobApp.get_Range("A1:B1").Select();
                lobApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return llgreturn;

        }
        #endregion
        //-----------------------------------------------------------
        //- Lectura de temporales para generar textos de archivos
        #region fcvGenerarVistaPantallaProceso: Generar Resumen Vista en pantalla del proceso
        /// <summary>
        /// <para>Generar Resumen Vista en pantalla del proceso</para>
        /// </summary>
        public void fcvGenerarVistaPantallaProceso()
        {
            String lcrTextoCT = String.Empty;
            var lcrUri = "/Sistema;component/Imagenes/";
            this.stkHistorial.Children.Clear();

            if (tmpRipsArchivoControl != null)
            {

                foreach (var lobReg in tmpRipsArchivoControl)
                {
                    //- Generar el registro vista 
                    var lobRegistro = new FcmControlGenPlanosRips();

                    lobRegistro.txtDescripArchivo.Text  = lobReg.Descripcion;
                    lobRegistro.txtNombreArchivo.Text   = lobReg.NombreArchivo;
                    lobRegistro.txtTotalRegistros.Text  = lobReg.TotalRegistros.ToString().Trim();
                    lobRegistro.txtFechaPeriodoIni.Text = this.txtFiltroFechaInicio.Text;
                    lobRegistro.txtFechaPeriodoFin.Text = this.txtFiltroFechaFin.Text;
                    lobRegistro.imgArchivo.Source       = new BitmapImage(new Uri(lcrUri + lobReg.ImagenJpg, UriKind.RelativeOrAbsolute));

                    this.stkHistorial.Children.Add(lobRegistro);
                    //
                }
                if (tmpRipsArchivoControl.Count <= 0)
                {
                    var lobRegistro = new TextBlock();
                    lobRegistro.FontSize = 16;
                    lobRegistro.Text = "No hay registros";
                    this.stkHistorial.Children.Add(lobRegistro);
                }
            }
        }
        #endregion
        #region fcvLeerTextoInformeCitas256: Leer Datos detalles archivo maestro asignacion citas
        /// <summary>
        /// <para>Leer Datos detalles archivo maestro asignacion citas, para informe calidad prestacion del servicio</para>
        /// </summary>
        public void fcvLeerTextoInformeCitas256(String tcrSeparador)
        {
            //MessageBox.Show("AQUI VOY CITAS A ");
            #region generar datos
            var tmpDetallesCitas = fobTempFiltroSqlGeneral("1");
            if (tmpDetallesCitas != null)
            {
                String lcrTextoCits;
                gnuTotalCitas = 0;
                //MessageBox.Show("AQUI VOY CITAS B ");

                foreach (DataRow lobReg in tmpDetallesCitas.Rows)
                {
                    lcrTextoCits = String.Empty;
                    // Preguntar por el tipo de registro y leer
                    gnuTotalCitas++;
                    lcrTextoCits = fcrLeerTextoRegistroCitas("2", gnuTotalCitas, lobReg, tcrSeparador);
                    lcrTextoCits = !String.IsNullOrWhiteSpace(gcrTextoArchivoCitas) ? "\r\n" + lcrTextoCits : lcrTextoCits;
                    gcrTextoArchivoCitas += lcrTextoCits;
                    //MessageBox.Show("AQUI VOY CITAS C " + lcrTextoCits);
                }
                #region Concatenar textos y resumen final
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoCitas))
                {
                    //gcrTextoArchivoCitas = fcrLeerTextoRegistroControl("1", lnuTotalCitas, tcrSeparador) + "\r\n" + gcrTextoArchivoCitas;

                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.NombreArchivo      = gcrNombreArchivoFisico;
                    lobRegCT.TotalRegistros     = gnuTotalCitas;
                    lobRegCT.Descripcion        = "CALIDAD CITAS";
                    lobRegCT.ImagenJpg          = "sys_cit02.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
            #endregion
        }
        #endregion
        #region fcvLeerTextoInformeTriage256: Leer Datos detalles archivo maestro Triage
        /// <summary>
        /// <para>Leer Datos detalles archivo maestro Triage, para informe calidad prestacion del servicio</para>
        /// </summary>
        public void fcvLeerTextoInformeTriage256(String tcrSeparador)
        {
            #region generar datos
            var tmpDetallesTriage = fobTempFiltroSqlGeneral("2");
            if (tmpDetallesTriage != null)
            {
                gnuTotalTriage = 0;
                String lcrTextoTriage;

                foreach (DataRow lobReg in tmpDetallesTriage.Rows)
                {
                    lcrTextoTriage = String.Empty;
                    // Prguntar por el tipo de registro y leer
                    gnuTotalTriage++;
                    lcrTextoTriage = fcrLeerTextoRegistroTriage("6", gnuTotalTriage, lobReg, tcrSeparador);
                    lcrTextoTriage = !String.IsNullOrWhiteSpace(gcrTextoArchivoTriage) ? "\r\n" + lcrTextoTriage : lcrTextoTriage;
                    gcrTextoArchivoTriage += lcrTextoTriage;
                }
                #region Concatenar textos y resumen final
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoTriage))
                {
                    //gcrTextoArchivoTriage = fcrLeerTextoRegistroControl("1", gnuTotalTriage, tcrSeparador) + "\r\n" + gcrTextoArchivoTriage;

                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.NombreArchivo = gcrNombreArchivoFisico;
                    lobRegCT.TotalRegistros = gnuTotalTriage;
                    lobRegCT.Descripcion = "CALIDAD TRIAGE";
                    lobRegCT.ImagenJpg = "sys_atm01.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
            #endregion
        }
        #endregion
        #region fcvLeerTextoInformeCitas2193: Leer Datos detalles archivo maestro asignacion citas
        /// <summary>
        /// <para>Leer Datos detalles archivo maestro asignacion citas, para informe calidad 2193/para>
        /// </summary>
        public void fcvLeerTextoInformeCitas2193(String tcrSeparador)
        {
            #region generar datos
            var tmpDetallesCitas = fobTempFiltroSqlGeneral("4");
            if (tmpDetallesCitas != null)
            {
                var lcrTextoTitulo   = String.Empty;
                var lcrTextoCits     = String.Empty;
                var lcrFechaSol      = String.Empty;
                var lcrFechaAsi      = String.Empty;
                var lcrCodigoServ    = String.Empty;
                var lcrDescriServ    = String.Empty;
                var lcrRegimSalud    = String.Empty;
                gcrTextoArchivoCitas = String.Empty;

                DateTime ldaFechaSol;
                DateTime ldaFechaAsi;
                var lnuDiasCitas = 0;
                gnuTotalCitas    = 0;

                var lobRegEx = new ClassLista();
                tmpLista = new List<ClassLista>();

                foreach (DataRow lobReg in tmpDetallesCitas.Rows)
                {
                    // Prguntar por el tipo de registro y leer
                    lcrFechaSol = lobReg["cit_fecsol_mcit"] != null ? lobReg["cit_fecsol_mcit"].ToString() : String.Empty;
                    lcrFechaAsi = lobReg["cit_feccit_mcit"] != null ? lobReg["cit_feccit_mcit"].ToString() : String.Empty;
                    lcrCodigoServ = lobReg["cit_codspr_spro"] != null ? lobReg["cit_codspr_spro"].ToString().Trim() : String.Empty;
                    lcrDescriServ = lobReg["cit_desspr_spro"] != null ? lobReg["cit_desspr_spro"].ToString().Trim() : String.Empty;
                    lcrRegimSalud = lobReg["sia_tipusu_regi"] != null ? lobReg["sia_tipusu_regi"].ToString().Trim() : String.Empty;

                    if (!String.IsNullOrWhiteSpace(lcrFechaSol) && !String.IsNullOrWhiteSpace(lcrFechaAsi))
                    {
                        gnuTotalCitas++;
                        var lobTmp = SIAValidarCodigo.fobRegBuscarSiaregimensalud(lcrRegimSalud);
                        lcrRegimSalud = lobTmp.sia_destip_regi;

                        ldaFechaSol  = Funciones.fdaConvertFecha("DMY","/", lcrFechaSol);
                        ldaFechaAsi  = Funciones.fdaConvertFecha("DMY", "/", lcrFechaAsi);
                        lnuDiasCitas = Funciones.fnuCalcularDiasFechas(ldaFechaSol, ldaFechaAsi);

                        // Buscar el registro en temporal 
                        lobRegEx = tmpLista.FirstOrDefault(x => x.RegistroCodigo == lcrCodigoServ && x.campo1 == lcrRegimSalud);
                        if (lobRegEx == null)
                        {
                            lobRegEx = new ClassLista();
                            lobRegEx.RegistroCodigo  = lcrCodigoServ;
                            lobRegEx.RegistroDescrip = lcrDescriServ;
                            lobRegEx.campo1          = lcrRegimSalud;

                            tmpLista.Add(lobRegEx);
                        }
                        lobRegEx.valor1 += lnuDiasCitas;
                        lobRegEx.valor2 += 1; // Contador cantidad de personas o citas
                    }
                }
                //-------------------------------------------------------------
                // TEXTO RESUMEN GENRAL
                //-------------------------------------------------------------
                // Titulo general
                String tcrFechaRango = this.txtFiltroFechaInicio.Text + " - " + this.txtFiltroFechaFin.Text;
                String lcrRelleno = "-";
                lcrTextoTitulo = lcrRelleno.PadRight(100, '-') + "\r\n" + " ASIGNACIÓN CITAS: " + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-');
                // Titulo registros
                lcrTextoTitulo += "\r\n" + "SERVICIO" + tcrSeparador + "REGIMEN" + tcrSeparador + "SUMATORIA DIAS" + tcrSeparador + "TOTAL CITAS";

                foreach (var lobReg in tmpLista)
                {
                    lcrTextoCits = lobReg.RegistroDescrip + tcrSeparador + lobReg.campo1 + tcrSeparador +
                                                    lobReg.valor1.ToString() + tcrSeparador + lobReg.valor2.ToString();
                    lcrTextoCits = !String.IsNullOrWhiteSpace(gcrTextoArchivoCitas) ? "\r\n" + lcrTextoCits : lcrTextoCits;
                    gcrTextoArchivoCitas += lcrTextoCits;
                }
                gcrTextoArchivoCitas = lcrTextoTitulo  + "\r\n" + gcrTextoArchivoCitas;

                //-------------------------------------------------------------
                // VISTA GESTION EN GRILLA
                //-------------------------------------------------------------
                #region Concatenar textos y resumen final
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoCitas))
                {
                    //gcrTextoArchivoCitas = fcrLeerTextoRegistroControl("1", lnuTotalCitas, tcrSeparador) + "\r\n" + gcrTextoArchivoCitas;

                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.NombreArchivo  = gcrNombreArchivoFisico;
                    lobRegCT.TotalRegistros = gnuTotalCitas;
                    lobRegCT.Descripcion    = "CITAS 2193";
                    lobRegCT.ImagenJpg      = "sys_cit02.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
            #endregion
        }
        #endregion
        #region fcvLeerTextoInformeTriage2193: Leer Datos detalles archivo maestro Triage
        /// <summary>
        /// <para>Leer Datos detalles archivo maestro Triage, para informe calidad 2193</para>
        /// </summary>
        public void fcvLeerTextoInformeTriage2193(String tcrSeparador)
        {
            var lcrTextoTitulo   = String.Empty;
            var lcrTextoTriage   = String.Empty;
            var lcrFechaTriage   = String.Empty;
            var lcrFechaAdmi     = String.Empty;
            var lcrHoraTriage    = String.Empty;
            var lcrHoraAdmis     = String.Empty;
            var lcrCodigoServ    = String.Empty;
            var lcrDescriServ    = String.Empty;
            var lcrRegimSalud    = String.Empty;
            var lnuMinutos = 0;
            gcrTextoArchivoTriage = String.Empty;
            DateTime ldaFechaTriage;
            DateTime ldaFechaAdmi;
            tmpLista = new List<ClassLista>();
            var lobRegEx = new ClassLista();

            #region generar datos
            var tmpDetallesTriage = fobTempFiltroSqlGeneral("3");
            if (tmpDetallesTriage != null)
            {
                gnuTotalTriage = 0;
                foreach (DataRow lobReg in tmpDetallesTriage.Rows)
                {
                    //var lob = tmpDetallesTriage.Rows[0];
                    //var ll = lob["adm_gesfec_tria"]

                    lcrFechaTriage = lobReg["adm_gesfec_tria"] != null ? lobReg["adm_gesfec_tria"].ToString() : String.Empty;
                    lcrFechaAdmi   = lobReg["adm_fecadm_rgad"] != null ? lobReg["adm_fecadm_rgad"].ToString() : String.Empty;
                    lcrHoraTriage  = lobReg["adm_geshor_tria"] != null ? lobReg["adm_geshor_tria"].ToString().Trim() : String.Empty;
                    lcrHoraAdmis   = lobReg["adm_horadm_rgad"] != null ? lobReg["adm_horadm_rgad"].ToString().Trim() : String.Empty;
                    lcrRegimSalud  = lobReg["sia_destip_regi"] != null ? lobReg["sia_destip_regi"].ToString().Trim() : String.Empty;

                    if (!String.IsNullOrWhiteSpace(lcrFechaTriage) && !String.IsNullOrWhiteSpace(lcrFechaAdmi))
                    {
                        gnuTotalTriage++;

                        ldaFechaTriage = Funciones.fdaConvertFecha("DMY", "/", lcrFechaTriage);
                        ldaFechaAdmi   = Funciones.fdaConvertFecha("DMY", "/", lcrFechaAdmi);

                        lnuMinutos = Funciones.fnuFechasCalHorasMinutos(ldaFechaTriage, ldaFechaAdmi, lcrHoraTriage, lcrHoraAdmis, "24", gcrSeparadorDecimal, "M");
                        lnuMinutos = lnuMinutos <= 0 ? 1 : lnuMinutos; // ojo ----- Parapeto

                        // Buscar el registro en temporal 
                        lobRegEx = tmpLista.FirstOrDefault(x => x.campo1 == lcrRegimSalud);
                        if (lobRegEx == null)
                        {
                            lobRegEx = new ClassLista();
                            lobRegEx.campo1 = lcrRegimSalud;

                            tmpLista.Add(lobRegEx);
                        }
                        lobRegEx.valor1 += lnuMinutos;
                        lobRegEx.valor2 += 1; // Contador cantidad de personas o citas
                    }
                }
                //-------------------------------------------------------------
                // TEXTO RESUMEN GENRAL 2193 ADMITIDOS
                //-------------------------------------------------------------
                #region Resumen general
                // Titulo general
                String tcrFechaRango = this.txtFiltroFechaInicio.Text + " - " + this.txtFiltroFechaFin.Text;
                String lcrRelleno = "-";
                lcrTextoTitulo = lcrRelleno.PadRight(100, '-') + "\r\n" + " ATENCION URGENCIAS CON OBSERVACION: " + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-');
                // Titulo registros
                lcrTextoTitulo += "\r\n" + "REGIMEN" + tcrSeparador + "SUMATORIA MINUTOS" + tcrSeparador + "TOTAL REGISTROS";

                foreach (var lobReg in tmpLista)
                {
                    lcrTextoTriage = lobReg.campo1 + tcrSeparador +
                                                    lobReg.valor1.ToString() + tcrSeparador + lobReg.valor2.ToString();
                    lcrTextoTriage = !String.IsNullOrWhiteSpace(gcrTextoArchivoTriage) ? "\r\n" + lcrTextoTriage : lcrTextoTriage;
                    gcrTextoArchivoTriage += lcrTextoTriage;
                }
                gcrTextoArchivoTriage = lcrTextoTitulo + "\r\n" + gcrTextoArchivoTriage;
                #endregion

                #region Concatenar textos y resumen final
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoTriage))
                {
                    //gcrTextoArchivoTriage = fcrLeerTextoRegistroControl("1", gnuTotalTriage, tcrSeparador) + "\r\n" + gcrTextoArchivoTriage;

                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.NombreArchivo = gcrNombreArchivoFisico;
                    lobRegCT.TotalRegistros = gnuTotalTriage;
                    lobRegCT.Descripcion = "CALIDAD TRIAGE 2193";
                    lobRegCT.ImagenJpg = "sys_atm01.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
            #endregion
        }
        #endregion
        #region fcvLeerTextoInformeSisproMedicVentas: Leer Datos detalles archivo medicamento
        /// <summary>
        /// <para>Leer Datos detalles archivo maestro venta medicamento en facturacion para informe Sispro</para>
        /// </summary>
        public void fcvLeerTextoInformeSisproMedicVentas(String tcrSeparador)
        {
            #region generar datos
            // Mes inicio
            var lcrMesIniReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaInicio.Text, "MES");
            lcrMesIniReporte     = Convert.ToInt32(lcrMesIniReporte).ToString().Trim();
            // Mes Fin 
            var lcrMesFinReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaFin.Text,"MES");
            lcrMesFinReporte     = Convert.ToInt32(lcrMesFinReporte).ToString().Trim();

            var tmpDetallesMedicVenta = fobTempFiltroSqlGeneral("6");

            if (tmpDetallesMedicVenta != null)
            {
                gnuTotalMedicRegistros = 0;
                gnuTotalMedicValVentas = 0;
                String lcrTextoMedVenta;
                String lcrCodigoCum = String.Empty;
                tmpMedicVentas = new List<ClassMedicVenta>();

                // Generar el Resumen
                #region Concatenar textos y resumen final
                foreach (DataRow lobReg in tmpDetallesMedicVenta.Rows)
                {
                    // Prguntar por el tipo de registro y leer
                    lcrCodigoCum = lobReg["fcm_codcum_sips"] != null ? lobReg["fcm_codcum_sips"].ToString(): "11111111";
                    if (lcrCodigoCum != "11111111")
                    {
                        // llamar la funcion auxiliar
                        fcvGenearTemporalSisproMedicVentas(lobReg);
                    }
                }
                #endregion

                // Generar el String todo el Texto 
                foreach (var lobReg in tmpMedicVentas)
                {
                    lcrTextoMedVenta = String.Empty;
                    // Prguntar por el tipo de registro y leer
                    lcrTextoMedVenta = fcrLeerTextoRegistroTipo2SisproMedicVentas(lcrMesIniReporte,lcrMesFinReporte, lobReg, tcrSeparador);
                    lcrTextoMedVenta = !String.IsNullOrWhiteSpace(gcrTextoArchivoMedicamentos) ? "\r\n" + lcrTextoMedVenta : lcrTextoMedVenta;
                    gcrTextoArchivoMedicamentos += lcrTextoMedVenta;
                }
                #region Concatenar textos y resumen final
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoMedicamentos))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.NombreArchivo = gcrNombreArchivoFisico;
                    lobRegCT.TotalRegistros = gnuTotalMedicRegistros;
                    lobRegCT.Descripcion = "SISPRO VENTA MEDICAMENTOS";
                    lobRegCT.ImagenJpg = "sys_atm01.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
            #endregion
        }
        #region fcvGenearTemporalSisproMedicVentas: Generar registros temporal resumen sispro venta medicamentos
        /// <summary>
        /// <para>Generar registros temporal resumen sispro venta medicamentos</para>
        /// </summary>
        public void fcvGenearTemporalSisproMedicVentas(DataRow tobRegistro)
        {
            var lcrCodigoCum       = tobRegistro["fcm_codcum_sips"].ToString().Trim();
            var lobReg             = tmpMedicVentas.FirstOrDefault(x => x.CodigoCum == lcrCodigoCum);
            var lnuPrecioUnitMin   = Convert.ToInt32(tobRegistro["fcm_valser_mant"].ToString());
            var lnuPrecioUnitMax   = Convert.ToInt32(tobRegistro["fcm_valser_mant"].ToString());
            var lnuTotalBrutoVenta = Convert.ToInt32(tobRegistro["fcm_valbru_dfac"].ToString());
            var lnuTotalUniVentas  = Convert.ToInt32(tobRegistro["fcm_totuni_dfac"].ToString());
            var lcrNumeroFacMinimo = tobRegistro["fcm_numfac_mfac"].ToString();
            var lcrNumeroFacMaximo = tobRegistro["fcm_numfac_mfac"].ToString();

            if (lobReg == null)
            {
                gnuTotalMedicRegistros++;
                // se agrega el registro
                tmpMedicVentas.Add(new ClassMedicVenta
                {
                    Secuencial      = gnuTotalMedicRegistros.ToString(),
                    CodigoCum       = lcrCodigoCum,
                    PrecioUnitMin   = lnuPrecioUnitMin,
                    PrecioUnitMax   = lnuPrecioUnitMax,
                    TotalBrutoVenta = lnuTotalBrutoVenta,
                    TotalUniVentas  = lnuTotalUniVentas,
                    NumeroFacMinimo = lcrNumeroFacMinimo,
                    NumeroFacMaximo = lcrNumeroFacMaximo
                });
            }
            else
            { 
                // Suma General
                lobReg.TotalBrutoVenta += lnuTotalBrutoVenta;
                lobReg.TotalUniVentas += lnuTotalUniVentas;
                // Precio Unit Minimo
                if (lobReg.PrecioUnitMin > lnuPrecioUnitMin) 
                {
                    lobReg.PrecioUnitMin = lnuPrecioUnitMin;
                    lobReg.NumeroFacMinimo = lcrNumeroFacMinimo;
                }
                // Precio Unit Maximo
                if (lobReg.PrecioUnitMax < lnuPrecioUnitMax)
                {
                    lobReg.PrecioUnitMax = lnuPrecioUnitMax;
                    lobReg.NumeroFacMaximo = lcrNumeroFacMaximo;
                }
            }
            gnuTotalMedicValVentas += lnuTotalBrutoVenta;
        }
        #endregion
        #endregion
        #region fcvLeerTextoInformeSisproMedicCompras: Leer Datos detalles archivo medicamento
        /// <summary>
        /// <para>Leer Datos detalles archivo maestro compra medicamento en facturacion para informe Sispro</para>
        /// </summary>
        public void fcvLeerTextoInformeSisproMedicCompras(String tcrSeparador)
        {
            #region generar datos
            // Mes inicio
            var lcrMesIniReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaInicio.Text, "MES");
            lcrMesIniReporte = Convert.ToInt32(lcrMesIniReporte).ToString().Trim();
            // Mes Fin 
            var lcrMesFinReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaFin.Text, "MES");
            lcrMesFinReporte = Convert.ToInt32(lcrMesFinReporte).ToString().Trim();
            var tmpDetallesMedicCompra = fobTempFiltroSqlGeneral("5");
            if (tmpDetallesMedicCompra != null)
            {
                gnuTotalMedicRegistros = 0;
                gnuTotalMedicValCompras = 0;
                String lcrTextoMedCompra;
                String lcrCodigoCum = String.Empty;
                tmpMedicCompras = new List<ClassMedicCompra>();

                // Generar el Resumen
                #region Concatenar textos y resumen final
                foreach (DataRow lobReg in tmpDetallesMedicCompra.Rows)
                {
                    // Prguntar por el tipo de registro y leer
                    lcrCodigoCum = lobReg["fcm_codcum_sips"] != null ? lobReg["fcm_codcum_sips"].ToString() : "11111111";
                    if (lcrCodigoCum != "11111111")
                    {
                        // llamar la funcion auxiliar
                        fcvGenerarTemporalSisproMedicCompras(lobReg);
                    }
                }
                #endregion

                // Generar el String todo el Texto 
                foreach (var lobReg in tmpMedicCompras)
                {
                    lcrTextoMedCompra = String.Empty;
                    // Preguntar por el tipo de registro y leer
                    lcrTextoMedCompra = fcrLeerTextoRegistroTipo2SisproMedicCompras(lcrMesIniReporte, lcrMesFinReporte, lobReg, tcrSeparador);
                    lcrTextoMedCompra = !String.IsNullOrWhiteSpace(gcrTextoArchivoMedicamentos) ? "\r\n" + lcrTextoMedCompra : lcrTextoMedCompra;
                    gcrTextoArchivoMedicamentos += lcrTextoMedCompra;
                }
                #region Concatenar textos y resumen final
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoMedicamentos))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.NombreArchivo      = gcrNombreArchivoFisico;
                    lobRegCT.TotalRegistros     = gnuTotalMedicRegistros;
                    lobRegCT.Descripcion        = "SISPRO COMPRA MEDICAMENTOS";
                    lobRegCT.ImagenJpg          = "sys_atm01.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
            #endregion
        }
        #region fcvGenerarTemporalSisproMedicCompras: Generar registros temporal resumen sispro compra medicamentos
        /// <summary>
        /// <para>Generar registros temporal resumen sispro compra medicamentos</para>
        /// </summary>
        public void fcvGenerarTemporalSisproMedicCompras(DataRow tobRegistro)
        {
            var lcrCodigoCum        = tobRegistro["fcm_codcum_sips"].ToString().Trim();
            var lnuPrecioUnitMin    = Convert.ToInt32(tobRegistro["fcm_valser_mant"].ToString());
            var lnuPrecioUnitMax    = Convert.ToInt32(tobRegistro["fcm_valser_mant"].ToString());
            var lnuTotalBrutoCompra = Convert.ToInt32(tobRegistro["fcm_valbru_dfac"].ToString());
            var lnuTotalUniCompras  = Convert.ToInt32(tobRegistro["fcm_totuni_dfac"].ToString());
            var lcrNumeroFacMinimo  = tobRegistro["fcm_numfac_mfac"].ToString();
            var lcrNumeroFacMaximo  = tobRegistro["fcm_desser_sips"].ToString();
            
            var lobReg = tmpMedicCompras.FirstOrDefault(x => x.CodigoCum == lcrCodigoCum);
            if (lobReg == null)
            {
                gnuTotalMedicRegistros++;
                // se agrega el registro
                tmpMedicCompras.Add(new ClassMedicCompra
                {
                    Secuencial = gnuTotalMedicRegistros.ToString(),
                    CodigoCum = lcrCodigoCum,
                    PrecioUnitMin = lnuPrecioUnitMin,
                    PrecioUnitMax = lnuPrecioUnitMax,
                    TotalBrutoCompra = lnuTotalBrutoCompra,
                    TotalUniCompras = lnuTotalUniCompras,
                    NumeroFacMinimo = lcrNumeroFacMinimo,
                    NumeroFacMaximo = lcrNumeroFacMaximo
                });
            }
            else
            {
                // Suma General
                lobReg.TotalBrutoCompra += lnuTotalBrutoCompra;
                lobReg.TotalUniCompras += lnuTotalUniCompras;
                // Precio Unit Minimo
                if (lobReg.PrecioUnitMin > lnuPrecioUnitMin)
                {
                    lobReg.PrecioUnitMin = lnuPrecioUnitMin;
                    lobReg.NumeroFacMinimo = lcrNumeroFacMinimo;
                }
                // Precio Unit Maximo
                if (lobReg.PrecioUnitMax < lnuPrecioUnitMax)
                {
                    lobReg.PrecioUnitMax = lnuPrecioUnitMax;
                    lobReg.NumeroFacMaximo = lcrNumeroFacMaximo;
                }
            }
            gnuTotalMedicValCompras += lnuTotalBrutoCompra;
        }
        #endregion
        #endregion
        #region fcvLeerTextoInformeSisproRes2175: Leer Datos detalles archivo Resolución 2175
        /// <summary>
        /// <para>Leer Datos detalles archivo maestro Resolución 2175 en facturacion para informe Sispro</para>
        /// </summary>
        public void fcvLeerTextoInformeSisproRes2175(String tcrSeparador)
        {
            #region generar datos
            var tmpDetallesRes2175Tipo2 = fobTempFiltroSqlGeneral("7");
            var tmpDetallesRes2175Tipo3 = fobTempFiltroSqlGeneral("8");
            var tmpDetallesRes2175Tipo4 = fobTempFiltroSqlGeneral("9");
            var tmpDetallesRes2175Tipo5 = fobTempFiltroSqlGeneral("10");
            var tmpDetallesRes2175Tipo6 = fobTempFiltroSqlGeneral("11");
            var tmpDetallesRes2175Tipo7 = fobTempFiltroSqlGeneral("12");

            String lcrTextoRes2175Tipo2;
            tmpRes2175Tipo2 = new List<ClassRes2175Tipo2>();
            String lcrTextoRes2175Tipo3;
            tmpRes2175Tipo3 = new List<ClassRes2175Tipo3>();
            String lcrTextoRes2175Tipo4;
            tmpRes2175Tipo4 = new List<ClassRes2175Tipo4>();
            String lcrTextoRes2175Tipo5;
            tmpRes2175Tipo5 = new List<ClassRes2175Tipo5>();
            String lcrTextoRes2175Tipo6;
            tmpRes2175Tipo6 = new List<ClassRes2175Tipo6>();
            String lcrTextoRes2175Tipo7;
            tmpRes2175Tipo7 = new List<ClassRes2175Tipo7>();

            #region Generar temporales según el tipo
            if (tmpDetallesRes2175Tipo2 != null)
            {
                // Generar el Resumen
                #region Concatenar textos y resumen final
                foreach (DataRow lobReg in tmpDetallesRes2175Tipo2.Rows)
                {
                    // llamar la funcion auxiliar
                    fcvGenerarTemporalSisproRes2175Tipo2(lobReg);
                }
                #endregion
            }
            if (tmpDetallesRes2175Tipo3 != null)
            {
                // Generar el Resumen
                #region Concatenar textos y resumen final
                foreach (DataRow lobReg in tmpDetallesRes2175Tipo3.Rows)
                {
                    // llamar la funcion auxiliar
                    fcvGenerarTemporalSisproRes2175Tipo3(lobReg);
                }
                #endregion
            }
            if (tmpDetallesRes2175Tipo4 != null)
            {
                // Generar el Resumen
                #region Concatenar textos y resumen final
                foreach (DataRow lobReg in tmpDetallesRes2175Tipo4.Rows)
                {
                    // llamar la funcion auxiliar
                    fcvGenerarTemporalSisproRes2175Tipo4(lobReg);
                }
                #endregion
            }
            if (tmpDetallesRes2175Tipo5 != null)
            {
                // Generar el Resumen
                #region Concatenar textos y resumen final
                foreach (DataRow lobReg in tmpDetallesRes2175Tipo5.Rows)
                {
                    // llamar la funcion auxiliar
                    fcvGenerarTemporalSisproRes2175Tipo5(lobReg);
                }
                #endregion
            }
            if (tmpDetallesRes2175Tipo6 != null)
            {
                // Generar el Resumen
                #region Concatenar textos y resumen final
                foreach (DataRow lobReg in tmpDetallesRes2175Tipo6.Rows)
                {
                    // llamar la funcion auxiliar
                    fcvGenerarTemporalSisproRes2175Tipo6(lobReg);
                }
                #endregion
            }
            if (tmpDetallesRes2175Tipo7 != null)
            {
                // Generar el Resumen
                #region Concatenar textos y resumen final
                foreach (DataRow lobReg in tmpDetallesRes2175Tipo7.Rows)
                {
                    // llamar la funcion auxiliar
                    fcvGenerarTemporalSisproRes2175Tipo7(lobReg);
                }
                #endregion
            }
            #endregion
            #region Generar el String del Texto según tipo
            #region Tipo 2
            foreach (var lobReg in tmpRes2175Tipo2)
            {
                lcrTextoRes2175Tipo2 = String.Empty;
                // Prguntar por el tipo de registro y leer
                lcrTextoRes2175Tipo2 = fcrLeerTextoRegistroTipo2Res2175(lobReg, tcrSeparador);
                lcrTextoRes2175Tipo2 = !String.IsNullOrWhiteSpace(gcrTextoArchivoRes2175) ? "\r\n" + lcrTextoRes2175Tipo2 : lcrTextoRes2175Tipo2;
                gcrTextoArchivoRes2175 += lcrTextoRes2175Tipo2;
            }
            #endregion
            #region Tipo 3
            foreach (var lobReg in tmpRes2175Tipo3)
            {
                lcrTextoRes2175Tipo3 = String.Empty;
                // Prguntar por el tipo de registro y leer
                lcrTextoRes2175Tipo3 = fcrLeerTextoRegistroTipo3Res2175(lobReg, tcrSeparador);
                lcrTextoRes2175Tipo3 = !String.IsNullOrWhiteSpace(gcrTextoArchivoRes2175) ? "\r\n" + lcrTextoRes2175Tipo3 : lcrTextoRes2175Tipo3;
                gcrTextoArchivoRes2175 += lcrTextoRes2175Tipo3;
            }
            #endregion
            #region Tipo 4
            foreach (var lobReg in tmpRes2175Tipo4)
            {
                lcrTextoRes2175Tipo4 = String.Empty;
                // Prguntar por el tipo de registro y leer
                lcrTextoRes2175Tipo4 = fcrLeerTextoRegistroTipo4Res2175(lobReg, tcrSeparador);
                lcrTextoRes2175Tipo4 = !String.IsNullOrWhiteSpace(gcrTextoArchivoRes2175) ? "\r\n" + lcrTextoRes2175Tipo4 : lcrTextoRes2175Tipo4;
                gcrTextoArchivoRes2175 += lcrTextoRes2175Tipo4;
            }
            #endregion
            #region Tipo 5
            foreach (var lobReg in tmpRes2175Tipo5)
            {
                lcrTextoRes2175Tipo5 = String.Empty;
                // Prguntar por el tipo de registro y leer
                lcrTextoRes2175Tipo5 = fcrLeerTextoRegistroTipo5Res2175(lobReg, tcrSeparador);
                lcrTextoRes2175Tipo5 = !String.IsNullOrWhiteSpace(gcrTextoArchivoRes2175) ? "\r\n" + lcrTextoRes2175Tipo5 : lcrTextoRes2175Tipo5;
                gcrTextoArchivoRes2175 += lcrTextoRes2175Tipo5;
            }
            #endregion
            #region Tipo 6
            foreach (var lobReg in tmpRes2175Tipo6)
            {
                lcrTextoRes2175Tipo6 = String.Empty;
                // Prguntar por el tipo de registro y leer
                lcrTextoRes2175Tipo6 = fcrLeerTextoRegistroTipo6Res2175(lobReg, tcrSeparador);
                lcrTextoRes2175Tipo6 = !String.IsNullOrWhiteSpace(gcrTextoArchivoRes2175) ? "\r\n" + lcrTextoRes2175Tipo6 : lcrTextoRes2175Tipo6;
                gcrTextoArchivoRes2175 += lcrTextoRes2175Tipo6;
            }
            #endregion
            #region Tipo 7
            foreach (var lobReg in tmpRes2175Tipo7)
            {
                lcrTextoRes2175Tipo7 = String.Empty;
                // Prguntar por el tipo de registro y leer
                lcrTextoRes2175Tipo7 = fcrLeerTextoRegistroTipo7Res2175(lobReg, tcrSeparador);
                lcrTextoRes2175Tipo7 = !String.IsNullOrWhiteSpace(gcrTextoArchivoRes2175) ? "\r\n" + lcrTextoRes2175Tipo7 : lcrTextoRes2175Tipo7;
                gcrTextoArchivoRes2175 += lcrTextoRes2175Tipo7;
            }
            #endregion
            #endregion
            #region Concatenar textos y resumen final
            if (!String.IsNullOrWhiteSpace(gcrTextoArchivoRes2175))
            {
                // Cargar el archivo de control
                var lobRegCT = new tmpRipsCT();
                lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                lobRegCT.NombreArchivo = gcrNombreArchivoFisico;
                lobRegCT.TotalRegistros = gnuTotalRes2175;
                lobRegCT.Descripcion = "SISPRO Resolucion 2175";
                lobRegCT.ImagenJpg = "sys_atm01.png";

                tmpRipsArchivoControl.Add(lobRegCT);
            }
            #endregion
            #endregion
        }
        #region fcvGenerarTemporalSisproRes2175Tipo2: Generar registros temporal resumen sispro Resolución 2175 Tipo 2
        /// <summary>
        /// <para>Generar registros temporal resumen sispro Resolución 2175 Tipo 2</para>
        /// </summary>
        public void fcvGenerarTemporalSisproRes2175Tipo2(DataRow tobRegistro)
        {
            var lcrTipoId           = tobRegistro["sia_tipide_tide"].ToString().Trim();
            var lcrNumeroId         = tobRegistro["sia_nroide_usua"].ToString();
            var lcrFechaNac         = tobRegistro["sia_fecnac_usua"].ToString().Substring(0, 10);
            lcrFechaNac             = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaNac, "YMD", "-");
            var lcrSexo             = tobRegistro["sis_codsex_sexo"].ToString().Trim();
            var lcrPertEtnica       = "6";
            var lcrPrimerApellido   = tobRegistro["sia_priape_usua"].ToString().Trim();
            var lcrSegundoApellido  = tobRegistro["sia_segape_usua"].ToString().Trim();
            var lcrPrimerNombre     = tobRegistro["sia_prinom_usua"].ToString().Trim();
            var lcrSegundoNombre    = tobRegistro["sia_segnom_usua"].ToString().Trim();
            var lcrTamizajeNeonatal = "1";
            var lcrFechaTamizaje    = tobRegistro["sia_fecnac_usua"].ToString();
            lcrFechaTamizaje        = lcrFechaNac;

            var lobReg = tmpRes2175Tipo2.FirstOrDefault(x => x.NumeroId == lcrNumeroId);
            if (lobReg == null)
            {
                gnuTotalRes2175++;
                // se agrega el registro
                tmpRes2175Tipo2.Add(new ClassRes2175Tipo2
                {
                    Secuencial       = gnuTotalRes2175.ToString(),
                    TipoId           = lcrTipoId,
                    NumeroId         = lcrNumeroId,
                    FechaNac         = lcrFechaNac,
                    Sexo             = lcrSexo,
                    PertEtnica       = lcrPertEtnica,
                    PrimerApellido   = lcrPrimerApellido,
                    SegundoApellido  = lcrSegundoApellido,
                    PrimerNombre     = lcrPrimerNombre,
                    SegundoNombre    = lcrSegundoNombre,
                    TamizajeNeonatal = lcrTamizajeNeonatal,
                    FechaTamizaje    = lcrFechaTamizaje
                });
            }
        }
        #endregion
        #region fcvGenerarTemporalSisproRes2175Tipo3: Generar registros temporal resumen sispro Resolución 2175 Tipo 3
        /// <summary>
        /// <para>Generar registros temporal resumen sispro Resolución 2175 Tipo 3</para>
        /// </summary>
        public void fcvGenerarTemporalSisproRes2175Tipo3(DataRow tobRegistro)
        {
            var lcrTipoId       = tobRegistro["sia_tipide_tide"].ToString().Trim();
            var lcrNumeroId     = tobRegistro["sia_nroide_usua"].ToString();
            var lcrFechaNac     = tobRegistro["sia_fecnac_usua"].ToString().Substring(0, 10);
            lcrFechaNac         = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaNac, "YMD", "-");
            var lcrSexo         = tobRegistro["sis_codsex_sexo"].ToString().Trim();
            var lcrPertEtnica   = "6";
            var lcrPrimerApellido   = tobRegistro["sia_priape_usua"].ToString().Trim();
            var lcrSegundoApellido  = tobRegistro["sia_segape_usua"].ToString().Trim();
            var lcrPrimerNombre     = tobRegistro["sia_prinom_usua"].ToString().Trim();
            var lcrSegundoNombre    = tobRegistro["sia_segnom_usua"].ToString().Trim();
            var lcrFechaAtencion    = tobRegistro["fcm_fecser_dfac"].ToString().Substring(0, 10);
            lcrFechaAtencion        = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaAtencion, "YMD", "-");
            var lcrFinalidad        = "4"; // Detección de alteraciones de crecimiento y desarrollo
            var lcrCodCups          = tobRegistro["fcm_codser_mant"].ToString();
            var lcrPeso             = "XX";
            var lcrTalla            = "XX";
            var lcrFecSulfato       = "XX";
            var lcrFecVitaminaA     = "XX";
            var lcrFecMicronutrientes   = "XX";
            var lcrFecHemoglobina       = "1845-01-01";
            var lcrResHemoglobina       = "XX";

            var lobReg = tmpRes2175Tipo3.FirstOrDefault(x => x.NumeroId == lcrNumeroId);
            if (lobReg == null)
            {
                gnuTotalRes2175++;
                // se agrega el registro
                tmpRes2175Tipo3.Add(new ClassRes2175Tipo3
                {
                    Secuencial = gnuTotalRes2175.ToString(),
                    TipoId = lcrTipoId,
                    NumeroId = lcrNumeroId,
                    FechaNac = lcrFechaNac,
                    Sexo = lcrSexo,
                    PertEtnica = lcrPertEtnica,
                    PrimerApellido = lcrPrimerApellido,
                    SegundoApellido = lcrSegundoApellido,
                    PrimerNombre = lcrPrimerNombre,
                    SegundoNombre = lcrSegundoNombre,
                    FechaAtencion = lcrFechaAtencion,
                    Finalidad = lcrFinalidad,
                    CodCups = lcrCodCups,
                    Peso = lcrPeso,
                    Talla = lcrTalla,
                    FecSulfato = lcrFecSulfato,
                    FecVitaminaA = lcrFecVitaminaA,
                    FecMicronutrientes = lcrFecMicronutrientes,
                    FecHemoglobina = lcrFecHemoglobina,
                    ResHemoglobina = lcrResHemoglobina
                });
            }
        }
        #endregion
        #region fcvGenerarTemporalSisproRes2175Tipo4: Generar registros temporal resumen sispro Resolución 2175 Tipo 4
        /// <summary>
        /// <para>Generar registros temporal resumen sispro Resolución 2175 Tipo 4</para>
        /// </summary>
        public void fcvGenerarTemporalSisproRes2175Tipo4(DataRow tobRegistro)
        {
            var lcrTipoId = tobRegistro["sia_tipide_tide"].ToString().Trim();
            var lcrNumeroId = tobRegistro["sia_nroide_usua"].ToString();
            var lcrFechaNac = tobRegistro["sia_fecnac_usua"].ToString().Substring(0, 10);
            lcrFechaNac = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaNac, "YMD", "-");
            var lcrSexo = tobRegistro["sis_codsex_sexo"].ToString().Trim();
            var lcrPertEtnica = "6";
            var lcrPrimerApellido = tobRegistro["sia_priape_usua"].ToString().Trim();
            var lcrSegundoApellido = tobRegistro["sia_segape_usua"].ToString().Trim();
            var lcrPrimerNombre = tobRegistro["sia_prinom_usua"].ToString().Trim();
            var lcrSegundoNombre = tobRegistro["sia_segnom_usua"].ToString().Trim();
            var lcrFechaAtencion = tobRegistro["fcm_fecser_dfac"].ToString().Substring(0, 10);
            lcrFechaAtencion = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaAtencion, "YMD", "-");
            var lcrFinalidad = "4"; // Detección de alteraciones de crecimiento y desarrollo
            var lcrCodCups = tobRegistro["fcm_codser_mant"].ToString();
            var lcrPeso = "XX";
            var lcrTalla = "XX";         
            var lcrFecHemoglobina = "1845-01-01";
            var lcrResHemoglobina = "XX";

            var lobReg = tmpRes2175Tipo4.FirstOrDefault(x => x.NumeroId == lcrNumeroId);
            if (lobReg == null)
            {
                gnuTotalRes2175++;
                // se agrega el registro
                tmpRes2175Tipo4.Add(new ClassRes2175Tipo4
                {
                    Secuencial = gnuTotalRes2175.ToString(),
                    TipoId = lcrTipoId,
                    NumeroId = lcrNumeroId,
                    FechaNac = lcrFechaNac,
                    Sexo = lcrSexo,
                    PertEtnica = lcrPertEtnica,
                    PrimerApellido = lcrPrimerApellido,
                    SegundoApellido = lcrSegundoApellido,
                    PrimerNombre = lcrPrimerNombre,
                    SegundoNombre = lcrSegundoNombre,
                    FechaAtencion = lcrFechaAtencion,
                    Finalidad = lcrFinalidad,
                    CodCups = lcrCodCups,
                    Peso = lcrPeso,
                    Talla = lcrTalla,                   
                    FecHemoglobina = lcrFecHemoglobina,
                    ResHemoglobina = lcrResHemoglobina
                });
            }
        }
        #endregion
        #region fcvGenerarTemporalSisproRes2175Tipo5: Generar registros temporal resumen sispro Resolución 2175 Tipo 5
        /// <summary>
        /// <para>Generar registros temporal resumen sispro Resolución 2175 Tipo 5</para>
        /// </summary>
        public void fcvGenerarTemporalSisproRes2175Tipo5(DataRow tobRegistro)
        {
            var lcrTipoId = tobRegistro["sia_tipide_tide"].ToString().Trim();
            var lcrNumeroId = tobRegistro["sia_nroide_usua"].ToString();
            var lcrFechaNac = tobRegistro["sia_fecnac_usua"].ToString().Substring(0, 10);
            lcrFechaNac = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaNac, "YMD", "-");
            var lcrSexo = tobRegistro["sis_codsex_sexo"].ToString().Trim();
            var lcrPertEtnica = "6";
            var lcrPrimerApellido = tobRegistro["sia_priape_usua"].ToString().Trim();
            var lcrSegundoApellido = tobRegistro["sia_segape_usua"].ToString().Trim();
            var lcrPrimerNombre = tobRegistro["sia_prinom_usua"].ToString().Trim();
            var lcrSegundoNombre = tobRegistro["sia_segnom_usua"].ToString().Trim();
            var lcrFechaAtencion = tobRegistro["fcm_fecser_dfac"].ToString().Substring(0, 10);
            lcrFechaAtencion = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaAtencion, "YMD", "-");
            var lcrFinalidad = "4"; // Detección de alteraciones de crecimiento y desarrollo
            var lcrCodCups = tobRegistro["fcm_codser_mant"].ToString();
            var lcrPeso = "XX";
            var lcrTalla = "XX";           
            var lcrFecHemoglobina = "1845-01-01";
            var lcrResHemoglobina = "XX";

            var lobReg = tmpRes2175Tipo5.FirstOrDefault(x => x.NumeroId == lcrNumeroId);
            if (lobReg == null)
            {
                gnuTotalRes2175++;
                // se agrega el registro
                tmpRes2175Tipo5.Add(new ClassRes2175Tipo5
                {
                    Secuencial = gnuTotalRes2175.ToString(),
                    TipoId = lcrTipoId,
                    NumeroId = lcrNumeroId,
                    FechaNac = lcrFechaNac,
                    Sexo = lcrSexo,
                    PertEtnica = lcrPertEtnica,
                    PrimerApellido = lcrPrimerApellido,
                    SegundoApellido = lcrSegundoApellido,
                    PrimerNombre = lcrPrimerNombre,
                    SegundoNombre = lcrSegundoNombre,
                    FechaAtencion = lcrFechaAtencion,
                    Finalidad = lcrFinalidad,
                    CodCups = lcrCodCups,
                    Peso = lcrPeso,
                    Talla = lcrTalla,                  
                    FecHemoglobina = lcrFecHemoglobina,
                    ResHemoglobina = lcrResHemoglobina
                });
            }
        }
        #endregion
        #region fcvGenerarTemporalSisproRes2175Tipo6: Generar registros temporal resumen sispro Resolución 2175 Tipo 6
        /// <summary>
        /// <para>Generar registros temporal resumen sispro Resolución 2175 Tipo 6</para>
        /// </summary>
        public void fcvGenerarTemporalSisproRes2175Tipo6(DataRow tobRegistro)
        {
            var lcrTipoId = tobRegistro["sia_tipide_tide"].ToString().Trim();
            var lcrNumeroId = tobRegistro["sia_nroide_usua"].ToString();
            var lcrPrimerApellido = tobRegistro["sia_priape_usua"].ToString().Trim();
            var lcrSegundoApellido = tobRegistro["sia_segape_usua"].ToString().Trim();
            var lcrPrimerNombre = tobRegistro["sia_prinom_usua"].ToString().Trim();
            var lcrSegundoNombre = tobRegistro["sia_segnom_usua"].ToString().Trim();
            var lcrFechaNac = tobRegistro["sia_fecnac_usua"].ToString().Substring(0, 10);
            lcrFechaNac = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaNac, "YMD", "-");
            var lcrEdadGestacional = "40";
            var lcrPertEtnica = "6";           
            var lcrFechaAtencion = tobRegistro["fcm_fecser_dfac"].ToString().Substring(0, 10);
            lcrFechaAtencion = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaAtencion, "YMD", "-");
            var lcrFinalidad = "4"; // Detección de alteraciones de crecimiento y desarrollo
            var lcrCodCups = tobRegistro["fcm_codser_mant"].ToString();
            var lcrFecAcidoFolico = "XX";
            lcrFecAcidoFolico = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecAcidoFolico, "YMD", "-");
            var lcrFecSulfatoFerroso = "XX";
            lcrFecSulfatoFerroso = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecSulfatoFerroso, "YMD", "-");
            var lcrFecCarbonatoCalcio = "XX";
            lcrFecCarbonatoCalcio = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecCarbonatoCalcio, "YMD", "-");
            var lcrFecAntigenoSupHep = "XX";
            lcrFecAntigenoSupHep = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecAntigenoSupHep, "YMD", "-");
            var lcrResAntigenoSupHep = "XX";
            var lcrFecTomaSerologia = "XX";
            lcrFecTomaSerologia = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecTomaSerologia, "YMD", "-");
            var lcrResSerologiaSifilis = "XX";
            var lcrFecAsesPreTestElisa = "XX";
            lcrFecAsesPreTestElisa = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecAsesPreTestElisa, "YMD", "-");
            var lcrFecTomaTestElisa = "XX";
            lcrFecTomaTestElisa = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecTomaTestElisa, "YMD", "-");
            var lcrResTestElisaVIH = "XX";            
            var lcrFecHemoglobina = "1845-01-01";
            var lcrResHemoglobina = "XX";
            var lcrFecConsLactMaterna = "XX";
            lcrFecConsLactMaterna = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecConsLactMaterna, "YMD", "-");

            var lobReg = tmpRes2175Tipo6.FirstOrDefault(x => x.NumeroId == lcrNumeroId);
            if (lobReg == null)
            {
                gnuTotalRes2175++;
                // se agrega el registro
                tmpRes2175Tipo6.Add(new ClassRes2175Tipo6
                {
                    Secuencial = gnuTotalRes2175.ToString(),
                    TipoId = lcrTipoId,
                    NumeroId = lcrNumeroId,
                    PrimerApellido = lcrPrimerApellido,
                    SegundoApellido = lcrSegundoApellido,
                    PrimerNombre = lcrPrimerNombre,
                    SegundoNombre = lcrSegundoNombre,
                    FechaNac = lcrFechaNac,
                    EdadGestacional = lcrEdadGestacional,
                    PertEtnica = lcrPertEtnica,                   
                    FechaAtencion = lcrFechaAtencion,
                    Finalidad = lcrFinalidad,
                    CodCups = lcrCodCups,         
                    FecAcidoFolico = lcrFecAcidoFolico,
                    FecSulfatoFerroso = lcrFecSulfatoFerroso,
                    FecCarbonatoCalcio = lcrFecCarbonatoCalcio,
                    FecAntigenoSupHep = lcrFecAntigenoSupHep,
                    ResAntigenoSupHep = lcrResAntigenoSupHep,
                    FecTomaSerologia = lcrFecTomaSerologia,
                    ResSerologiaSifilis = lcrResSerologiaSifilis,
                    FecAsesPreTestElisa = lcrFecAsesPreTestElisa,
                    FecTomaTestElisa = lcrFecTomaTestElisa,
                    ResTestElisaVIH = lcrResTestElisaVIH,
                    FecHemoglobina = lcrFecHemoglobina,
                    ResHemoglobina = lcrResHemoglobina,
                    FecConsLactMaterna = lcrFecConsLactMaterna
                });
            }
        }
        #endregion
        #region fcvGenerarTemporalSisproRes2175Tipo7: Generar registros temporal resumen sispro Resolución 2175 Tipo 7
        /// <summary>
        /// <para>Generar registros temporal resumen sispro Resolución 2175 Tipo 7</para>
        /// </summary>
        public void fcvGenerarTemporalSisproRes2175Tipo7(DataRow tobRegistro)
        {
            var lcrTipoId = tobRegistro["sia_tipide_tide"].ToString().Trim();
            var lcrNumeroId = tobRegistro["sia_nroide_usua"].ToString();
            var lcrPrimerApellido = tobRegistro["sia_priape_usua"].ToString().Trim();
            var lcrSegundoApellido = tobRegistro["sia_segape_usua"].ToString().Trim();
            var lcrPrimerNombre = tobRegistro["sia_prinom_usua"].ToString().Trim();
            var lcrSegundoNombre = tobRegistro["sia_segnom_usua"].ToString().Trim();
            var lcrPertEtnica = "6";                                     
            var lcrFecAtencionParto = "XX";
            lcrFecAtencionParto = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecAtencionParto, "YMD", "-");
            var lcrFinalidad = "4"; // Detección de alteraciones de crecimiento y desarrollo
            var lcrCodCups = tobRegistro["fcm_codser_mant"].ToString();
            var lcrTomaPruebaSifilis = "XX";
            var lcrFecTomaPruebaSifilis = "XX";
            lcrFecTomaPruebaSifilis = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecTomaPruebaSifilis, "YMD", "-");
            var lcrResSerologiaSifilis = "XX";
            var lcrAsesPreTestElisa = "XX";
            var lcrFecAsesPreTestElisa = "XX";
            lcrFecAsesPreTestElisa = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecAsesPreTestElisa, "YMD", "-");
            var lcrTomaTestElisa = "XX";
            var lcrFecTomaTestElisa = "XX";
            lcrFecTomaTestElisa = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecTomaTestElisa, "YMD", "-");
            var lcrResTestElisaVIH = "XX";
            var lcrSuministroAntconcep = "XX";
            var lcrFecSuminAntconcep = "XX";
            lcrFecSuminAntconcep = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFecSuminAntconcep, "YMD", "-");

            var lobReg = tmpRes2175Tipo7.FirstOrDefault(x => x.NumeroId == lcrNumeroId);
            if (lobReg == null)
            {
                gnuTotalRes2175++;
                // se agrega el registro
                tmpRes2175Tipo7.Add(new ClassRes2175Tipo7
                {
                    Secuencial = gnuTotalRes2175.ToString(),
                    TipoId = lcrTipoId,
                    NumeroId = lcrNumeroId,
                    PrimerApellido = lcrPrimerApellido,
                    SegundoApellido = lcrSegundoApellido,
                    PrimerNombre = lcrPrimerNombre,
                    SegundoNombre = lcrSegundoNombre,
                    PertEtnica = lcrPertEtnica,
                    FechaAtenParto = lcrFecAtencionParto,
                    Finalidad = lcrFinalidad,
                    CodCups = lcrCodCups,
                    TomaPruebaSifilis = lcrTomaPruebaSifilis,
                    FecTomaPruebaSifilis = lcrFecTomaPruebaSifilis,
                    ResSerologiaSifilis = lcrResSerologiaSifilis,
                    AsesPreTestElisa = lcrAsesPreTestElisa,
                    FecAsesPreTestElisa = lcrFecAsesPreTestElisa,
                    TomaTestElisa = lcrTomaTestElisa,
                    FecTomaTestElisa = lcrFecTomaTestElisa,
                    ResTestElisaVIH = lcrResTestElisaVIH,
                    SuministroAntconcep = lcrSuministroAntconcep,
                    FecSuminAntconcep = lcrFecSuminAntconcep
                });
            }
        }
        #endregion     
        #endregion
        // Procesos informe 2193 general
        #region fcvLeerTextoInformeResumen2193: Leer Datos detalles servicios para informe 2193
        /// <summary>
        /// <para>Leer Datos detalles servicios para informe general Resolución 2193</para>
        /// </summary>
        public void fcvLeerTextoInformeResumen2193(String tcrSeparador)
        {
            var lcrTextoResumen2193 = String.Empty;
            var lcrTextoTitulo      = String.Empty;
            var lcrTextoTituloGrupo = String.Empty;
            gcrTextoArchivoRes2193  = String.Empty;

            var lobParam = new ESTUtilidades.RegistroResumen();
            tmpResumen = ModeloEstParametros2193MA.flsListaTempResumen();  // Reiniciar la vista Resumen con totales vacios

            // Cargar parametros personalizados por grupo
            var lcrParamGrupoR006 = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == "R006").Parametro1;  // Consultas de urgencias
            var lcrParamGrupoR0X6 = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == "R0X6").Parametro1;  // Consultas de urgencias
 
            #region generar datos

            //-------------------------------------------------------------
            // CONSULTAS 2193  - "General"
            //-------------------------------------------------------------
            #region Primera parte del reporte
            var tmpDetalles = fobTempFiltroSql2193("TODOS");
            if (tmpDetalles != null)
            {
                #region Consulta principal
                foreach (DataRow lobReg in tmpDetalles.Rows)
                {
                    fcvLeerTextoInformeResumen2193Guardar(lobReg, "TODOS");
                }
                #endregion
            }
            #endregion
            //-------------------------------------------------------------
            // R006 = Consulta de urgencias Triage 1,2,3
            //-------------------------------------------------------------
            #region Consulta Urgencias 
            if (lcrParamGrupoR006 == "1") // Cuando el parametro para R006 es 2 se hace en el grupo "General"
            {
                tmpDetalles = fobTempFiltroSql2193("R006");
                if (tmpDetalles != null)
                {
                    foreach (DataRow lobReg in tmpDetalles.Rows)
                    {
                        fcvLeerTextoInformeResumen2193Guardar(lobReg, "R006");
                    }
                }
            }
            #endregion
            #region Consulta Urgencia Triage 4 y 5
            if (lcrParamGrupoR0X6 == "1") // Cuando el parametro para R006 es 2 se hace en el grupo "General"
            {
                tmpDetalles = fobTempFiltroSql2193("R0X6");
                if (tmpDetalles != null)
                {
                    foreach (DataRow lobReg in tmpDetalles.Rows)
                    {
                        fcvLeerTextoInformeResumen2193Guardar(lobReg, "R0X6");
                    }
                }
            }
            #endregion
            //-------------------------------------------------------------
            // R012 = Tratamientos odontologicos terminados
            //-------------------------------------------------------------
            #region Tratamientos odontologicos terminados
            var tmpR012 = fobTempFiltroSql2193("R012"); // Tratamientos odontologicos terminados
            if (tmpR012 != null)
            {
                #region Consulta principal
                foreach (DataRow lobReg in tmpR012.Rows)
                {
                    fcvLeerTextoInformeResumen2193Guardar(lobReg, "R012");
                }
                #endregion
            }
            #endregion
            //-------------------------------------------------------------
            // R025=Egresos ostetricos -//- R027=Estancia egresos no quirurgicos 
            //-------------------------------------------------------------
            #region Egresos no quirurgicos sin los partos
            tmpR025 = fobTempFiltroSql2193("R025"); // Días estancia de los egresos obstétricos
            tmpR027 = fobTempFiltroSql2193("R027"); // Días estancia de los egresos No quirúrgicos
            if (tmpR027 != null)
            {
                #region Consulta principal
                foreach (DataRow lobReg in tmpR027.Rows)
                {
                    fcvLeerTextoInformeResumen2193R027(lobReg);
                }
                #endregion
            }
            #endregion
            //-------------------------------------------------------------
            // R031 = Total camas habilitadas
            //-------------------------------------------------------------
            #region Total camas habilitadas
            var tmpRegistro = fobTempFiltroSql2193("R031"); 
            if (tmpRegistro != null)
            {
                #region Consulta principal
                foreach (DataRow lobReg in tmpRegistro.Rows)
                {
                    var lnuTotal = Convert.ToInt32(lobReg["fcm_totuni_dfac"].ToString());
                    fcvGenRegGrupoResumen2193("R031", lnuTotal);
                }
                #endregion
            }
            #endregion
            //-------------------------------------------------------------
            // R032 = Dias camas ocupadas en el periodo
            //-------------------------------------------------------------
            fcvLeerTextoInformeResumen2193R032();
            //-------------------------------------------------------------
            // TEXTO RESUMEN GENRAL 2193 
            //-------------------------------------------------------------
            #region Resumen general
            // Titulo general
            String tcrFechaRango = this.txtFiltroFechaInicio.Text + " - " + this.txtFiltroFechaFin.Text;
            String lcrRelleno = "-";
            lcrTextoTitulo = lcrRelleno.PadRight(100, '-') + "\r\n" + " RESUMEN GENERAL 2193: " + tcrFechaRango + "\r\n" + lcrRelleno.PadRight(100, '-');

            var lcrCodigoGrupoAux = "XX";
            gnuTotalRes2193 = 0;

            foreach (var lobReg in tmpResumen)
            {
                gnuTotalRes2193++;
                lcrTextoTituloGrupo = String.Empty;

                if (lcrCodigoGrupoAux != lobReg.GrupoIdRegistro)
                {
                    lcrTextoTituloGrupo = lobReg.GrupoTitulo.Trim() + tcrSeparador + "Pobalción Pobre" + tcrSeparador +
                                          "No Pos" + tcrSeparador + "Subsidiado" + tcrSeparador + "Contributivo" + tcrSeparador +
                                          "Otros" + tcrSeparador + "Total" + "\r\n";
                }

                lcrCodigoGrupoAux = lobReg.GrupoIdRegistro;

                lcrTextoResumen2193 = lcrTextoTituloGrupo +
                                      lobReg.RegistroTitulo + tcrSeparador +
                                      lobReg.Decimal1.ToString() + tcrSeparador + lobReg.Decimal2.ToString() + tcrSeparador +
                                      lobReg.Decimal3.ToString() + tcrSeparador + lobReg.Decimal4.ToString() + tcrSeparador +
                                      lobReg.Decimal5.ToString() + tcrSeparador + lobReg.Decimal6.ToString();

                lcrTextoResumen2193 = !String.IsNullOrWhiteSpace(gcrTextoArchivoRes2193) ? "\r\n" + lcrTextoResumen2193 : lcrTextoResumen2193;
                gcrTextoArchivoRes2193 += lcrTextoResumen2193;
            }
            gcrTextoArchivoRes2193 = lcrTextoTitulo + "\r\n" + gcrTextoArchivoRes2193;
            #endregion
            #region Concatenar textos y resumen final
            if (!String.IsNullOrWhiteSpace(gcrTextoArchivoRes2193))
            {

                // Cargar el archivo de control
                var lobRegCT = new tmpRipsCT();
                lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                lobRegCT.NombreArchivo = gcrNombreArchivoFisico;
                lobRegCT.TotalRegistros = gnuTotalRes2193;
                lobRegCT.Descripcion = "CALIDAD RESUMEN GENERAL 2193";
                lobRegCT.ImagenJpg = "sys_atm01.png";

                tmpRipsArchivoControl.Add(lobRegCT);
            }
            #endregion
            #endregion
        }
        #region fcvLeerTextoInformeResumen2193Guardar: Leer y gaurdar detalles servicios
        /// <summary>
        /// <para>Leer y guardar detalles servicios</para>
        /// </summary>
        public void fcvLeerTextoInformeResumen2193Guardar(DataRow tobReg, String tcrTipoRegistro)
        {
            var llgCargar = true;
            var lobParam = new ESTUtilidades.RegistroResumen();

            var lcrEst_nroreg_esgr = String.Empty;
            var lcrEst_nomgru_esgr = String.Empty;
            var lcrSia_tipusu_regi = String.Empty;
            var lcrFcm_serpos_sips = String.Empty;
            var lnuFcm_totuni_dfac = 0;

            if (tcrTipoRegistro == "TODOS" || tcrTipoRegistro == "R006" || tcrTipoRegistro == "R0X6")
            {
                lcrEst_nroreg_esgr = tobReg["est_nroreg_esgr"].ToString().Trim();
                lcrEst_nomgru_esgr = tobReg["est_nomgru_esgr"].ToString().Trim();
                lcrFcm_serpos_sips = tobReg["fcm_serpos_sips"].ToString().Trim();
            }
            else if (tcrTipoRegistro == "R012")
            {
                // Tratamientos odontologicos terminados
                lcrEst_nroreg_esgr = "R012";
                lcrEst_nomgru_esgr = "NA";
                lcrFcm_serpos_sips = "1";
            }

            lcrSia_tipusu_regi = tobReg["sia_tipusu_regi"].ToString().Trim();
            lnuFcm_totuni_dfac = Convert.ToInt32(tobReg["fcm_totuni_dfac"].ToString());

            // Validar si se guarda o no
            #region Validar si se guarda o no
            if (tcrTipoRegistro == "TODOS") 
            {
                if (lcrEst_nroreg_esgr == "R006" ) // Parametro 2 para incluir todos los triage desde 1 hasta 5
                {
                    llgCargar = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == "R006").Parametro1 == "2" ? true : false;
                }
                else if (lcrEst_nroreg_esgr == "R0X6") // Parametro 2 para incluir todos los triage desde 1 hasta 5
                {
                    llgCargar = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == "R0X6").Parametro1 == "2" ? true : false;
                }
                else
                {
                    llgCargar = true; // General
                }
            }
            if (llgCargar == true) 
            {
                #region 1 - Resumen general 2193
                lobParam.Registrollave  = lcrEst_nroreg_esgr;
                lobParam.RegistroCodigo = lcrEst_nroreg_esgr;
                lobParam.RegistroTitulo = lcrEst_nomgru_esgr;

                fcvGenRegGrupoResumen2193(lobParam, lnuFcm_totuni_dfac, lcrSia_tipusu_regi, lcrFcm_serpos_sips);
                #endregion
            }
            #endregion
        }
        #endregion
        #region fcvLeerTextoInformeResumen2193R027: Estancia egresos no quirurgicos
        /// <summary>
        /// <para>Estancia egresos no quirurgicos</para>
        /// </summary>
        public void fcvLeerTextoInformeResumen2193R027(DataRow tobReg)
        {
            var lobParam = new ESTUtilidades.RegistroResumen();

            DateTime ldaFechaIniLiquid;
            DateTime ldaFechaFinLiquid;
            var lcrHoraIniLiquid = String.Empty;
            var lcrHoraFinLiquid = String.Empty;
            var ldaFechaFinPerio = Funciones.fdaConvertFecha("DMY", "/", this.txtFiltroFechaFin.Text);
            var llgCargar = true;

            var lcrSia_tipusu_regi = String.Empty;
            var lcrFcm_serpos_sips = "1"; // Es pos
            var lnuFcm_totuni_dfac = 0;
            // Datos base
            var lcrTipoRegAdmitido = String.IsNullOrWhiteSpace(tobReg["adm_fecegr_regr"].ToString()) == false ? "1" : "2"; // 1=Hospitalizacion 2=Urgencia
            lcrSia_tipusu_regi     = tobReg["sia_tipusu_regi"].ToString().Trim();
            ldaFechaIniLiquid      = Funciones.fdaConvertFecha("DMY", "/", tobReg["adm_fecadm_rgad"].ToString());
            lcrHoraIniLiquid       = tobReg["adm_horadm_rgad"].ToString();


            if (lcrTipoRegAdmitido == "1") // Hospitalizacion
            {

                ldaFechaFinLiquid = Funciones.fdaConvertFecha("DMY", "/", tobReg["adm_fecegr_regr"].ToString());
                lcrHoraFinLiquid  = tobReg["adm_horegr_regr"].ToString();
                llgCargar = ldaFechaFinLiquid > ldaFechaFinPerio ? false : true; // por si salio en siguiente mes
            }
            else
            {
                ldaFechaFinLiquid = Funciones.fdaConvertFecha("DMY", "/", tobReg["adm_fecegr_regu"].ToString());
                lcrHoraFinLiquid  = tobReg["adm_horegr_regu"].ToString();
            }
            if (llgCargar == true)
            {
                lnuFcm_totuni_dfac = fnuGenerarDiasEstancia(ldaFechaIniLiquid, ldaFechaFinLiquid, lcrHoraIniLiquid, lcrHoraFinLiquid);
                lobParam.Registrollave = "T002";
                fcvGenRegGrupoResumen2193(lobParam, 1, lcrSia_tipusu_regi, lcrFcm_serpos_sips);

                // Todos se cuentan en "Numero de Pacientes en observacion"
                lobParam.Registrollave = "R022";
                fcvGenRegGrupoResumen2193(lobParam, 1, lcrSia_tipusu_regi, lcrFcm_serpos_sips);

                // Comprobar que no este en los egresos obstetricos
                var lcrFiltro = "adm_secadm_rgad ='" + tobReg["adm_secadm_rgad"].ToString().Trim() + "'";
                var lobReR025 = tmpR025.Select(lcrFiltro);
                if (lobReR025.Length > 0)
                {

                    // Cantidad egresos obstetricos
                    lobParam.Registrollave = "R018";
                    fcvGenRegGrupoResumen2193(lobParam, 1, lcrSia_tipusu_regi, lcrFcm_serpos_sips);

                    // Dias estancia obstetricos
                    lobParam.Registrollave = "R025";
                    fcvGenRegGrupoResumen2193(lobParam, lnuFcm_totuni_dfac, lcrSia_tipusu_regi, lcrFcm_serpos_sips);
                }
                else
                {
                    // Cantidad egresos no quirurjicos
                    lobParam.Registrollave = "R020";
                    fcvGenRegGrupoResumen2193(lobParam, 1, lcrSia_tipusu_regi, lcrFcm_serpos_sips);

                    // Dias estancia no quirurgicos
                    lobParam.Registrollave = "R027";
                    fcvGenRegGrupoResumen2193(lobParam, lnuFcm_totuni_dfac, lcrSia_tipusu_regi, lcrFcm_serpos_sips);
                }
                // Todos los dias de estancia General
                lobParam.Registrollave = "T003";
                fcvGenRegGrupoResumen2193(lobParam, lnuFcm_totuni_dfac, lcrSia_tipusu_regi, lcrFcm_serpos_sips);
            }
        }
        #endregion
        #region fcvLeerTextoInformeResumen2193R032: Dias camas ocupadas
        /// <summary>
        /// <para>Dias camas ocupadas dentro del periodo</para>
        /// </summary>
        public void fcvLeerTextoInformeResumen2193R032()
        {
            var lobParam = new ESTUtilidades.RegistroResumen();

            var ldaFechaIniPer   = Funciones.fdaConvertFecha("DMY", "/", this.txtFiltroFechaInicio.Text);
            var ldaFechaFinPer   = Funciones.fdaConvertFecha("DMY", "/", this.txtFiltroFechaFin.Text);
            var lnuDiasPeriodo   = Funciones.fnuCalcularDiasFechas(ldaFechaIniPer, ldaFechaFinPer);
            DateTime ldaFechaIniLiquid;
            DateTime ldaFechaFinLiquid;
            var lcrHoraIniLiquid = String.Empty;
            var lcrHoraFinLiquid = String.Empty;

            var lcrSia_tipusu_regi = String.Empty;
            var lcrFcm_serpos_sips = "1"; // Es pos
            var lnuFcm_totuni_dfac = 0;
            var lcrTipoRegAdmitido = "1";

            #region Consulta todos los pacientes que usaron cama en el periodo
            var tmpRegistro = fobTempFiltroSql2193("R032");
            if (tmpRegistro != null)
            {
                #region Consulta principal
                foreach (DataRow lobReg in tmpRegistro.Rows)
                {
                    // Parametros iniciales el proceso
                    #region Parametros iniciales el proceso
                    lcrTipoRegAdmitido  = String.IsNullOrWhiteSpace(lobReg["adm_fecegr_regr"].ToString()) == false ? "1" : "2"; // 1=Hospitalizacion 2=Urgencia
                    lcrSia_tipusu_regi  = lobReg["sia_tipusu_regi"].ToString().Trim();
                    ldaFechaIniLiquid   = Funciones.fdaConvertFecha("DMY", "/", lobReg["adm_fecadm_rgad"].ToString());
                    lcrHoraIniLiquid    = lobReg["adm_horadm_rgad"].ToString();

                    if (lcrTipoRegAdmitido == "1") // Hospitalizacion
                    {
                        ldaFechaFinLiquid = Funciones.fdaConvertFecha("DMY", "/", lobReg["adm_fecegr_regr"].ToString());
                        lcrHoraFinLiquid = lobReg["adm_horegr_regr"].ToString();
                    }
                    else
                    {
                        ldaFechaFinLiquid = Funciones.fdaConvertFecha("DMY", "/", lobReg["adm_fecegr_regu"].ToString());
                        lcrHoraFinLiquid = lobReg["adm_horegr_regu"].ToString();
                    }
                    #endregion
                    // Verificar valores parametros
                    #region Verificar valores parametros

                    if (ldaFechaIniLiquid < ldaFechaIniPer) 
                    {
                        ldaFechaIniLiquid = ldaFechaIniPer;
                        lcrHoraIniLiquid = "01" + gcrSeparadorDecimal + "00";
                    }

                    if (ldaFechaFinLiquid > ldaFechaFinPer)
                    {
                        ldaFechaFinLiquid = ldaFechaFinPer;
                        lcrHoraFinLiquid = "23" + gcrSeparadorDecimal + "59";
                    }
                    #endregion

                    lnuFcm_totuni_dfac = fnuGenerarDiasEstancia(ldaFechaIniLiquid, ldaFechaFinLiquid, lcrHoraIniLiquid, lcrHoraFinLiquid);

                    lobParam.Registrollave = "R032";
                    fcvGenRegGrupoResumen2193(lobParam, lnuFcm_totuni_dfac, lcrSia_tipusu_regi, lcrFcm_serpos_sips);
                }
                #endregion
                var lnuTotalEgresosPer = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == "T002").Decimal6; //Numero de egresos en el mes
                var lnuTotalDiasEgrPer = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == "T003").Decimal6; //Numero dias estancias de egresos en el mes
                var lnuTotalCamaIPSPer = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == "R031").Decimal6; //Numero de camas habilitadas de la IPS
                var lnuDiasCamaOcupPer = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == "R032").Decimal6; //Total dias camas ocupadas en el mes

                var lnuDiasCamaDispPer = flgValidarDatos(lnuTotalCamaIPSPer, (decimal)lnuDiasPeriodo) == true ? lnuTotalCamaIPSPer * lnuDiasPeriodo : 0;
                var lnuPromeDiaEstaPer = flgValidarDatos(lnuTotalDiasEgrPer, lnuTotalEgresosPer) == true ? lnuTotalDiasEgrPer / lnuTotalEgresosPer : 0; // Promedio Dias estancia (debe dar un Porcentaje)
                var lnuPorcentOcupaPer = flgValidarDatos(lnuDiasCamaOcupPer, lnuDiasCamaDispPer) == true ? (lnuDiasCamaOcupPer / lnuDiasCamaDispPer) * 100 : 0; // Porcentaje de ocupacion de camas en periodo
                var lnuRotaCamaPaciPer = flgValidarDatos(lnuTotalEgresosPer, lnuTotalCamaIPSPer) == true ? lnuTotalEgresosPer / lnuTotalCamaIPSPer : 0; // Rotacion cama por pacientes

                fcvGenRegGrupoResumen2193("R033", lnuDiasCamaDispPer); // Dias Camas disponibles
                fcvGenRegGrupoResumen2193("R034", lnuPromeDiaEstaPer); // Promedio Dias estancia en mes
                fcvGenRegGrupoResumen2193("R035", lnuPorcentOcupaPer); // Porcentaje de ocupacion de camas en periodo
                fcvGenRegGrupoResumen2193("R036", lnuRotaCamaPaciPer); // Rotacion cama por pacientes

            }
            #endregion
        }
        #endregion
        #region fcvGenRegGrupoResumen2193: Generar resumen general 2193
        /// <summary>
        /// <para> Generar resumen general 2193 en clase ClasseTmpResumen</para>
        /// </summary>
        public void fcvGenRegGrupoResumen2193(ESTUtilidades.RegistroResumen tobParam, Decimal tnuCantidad, String tcrRegimen, String tcrPosNoPos)
        {
            var lcrReturn = String.Empty;
            // Buscar en resumen
            tmpRegActivoResumen = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == tobParam.Registrollave);
            if (tmpRegActivoResumen != null)
            {
                // Generar datos
                if (tcrPosNoPos == "1") // cuando es pos
                {
                    // 1 = Contributivo 2 = Subsidiado 3 = Vinculado 4 = Particular 5 = Otro
                    switch (tcrRegimen)
                    {
                        case "1": // Contributivo
                            tmpRegActivoResumen.Decimal4 += tnuCantidad;
                            break;

                        case "2": // Subsidiado
                            tmpRegActivoResumen.Decimal3 += tnuCantidad;
                            break;

                        case "3": // Poblacion pobre no asegurada
                            tmpRegActivoResumen.Decimal1 += tnuCantidad;
                            break;

                        default: // los demas
                            tmpRegActivoResumen.Decimal5 += tnuCantidad;
                            break;
                    }
                }
                else
                {
                    tmpRegActivoResumen.Decimal2 += tnuCantidad; // Los No Pos
                }
                tmpRegActivoResumen.Decimal6 += tnuCantidad; // sumatoria total
            }
        }
        #endregion
        #region fcvGenRegGrupoResumen2193: Guardar solo en columna total general
        /// <summary>
        /// <para>Guardar solo en columna total general dado el ID del Registro grupo</para>
        /// </summary>
        public void fcvGenRegGrupoResumen2193(String tcrIdGrupo, Decimal tnuCantidad)
        {
            var lcrReturn = String.Empty;
            // Buscar en resumen
            tmpRegActivoResumen = tmpResumen.FirstOrDefault(x => x.LlaveRegistro == tcrIdGrupo);
            if (tmpRegActivoResumen != null)
            {
                tmpRegActivoResumen.Decimal6 += tnuCantidad; // sumatoria total
            }
        }
        #endregion
        #region  fnuGenerarDiasEstanciaHospitalarias: Genera la estancia dias
        /// <summary>
        ///Genera los dias de estancia segun parametros dados
        /// </summary>
        public int fnuGenerarDiasEstancia(DateTime tdaFechaIni, DateTime tdaFechaFin, String tcrHoraIni, String tcrHoraFin)
        {
            var lcrValorReturn = String.Empty;
            //---------------------------------------------------
            var lnuHorasEstancia = Funciones.fnuFechasCalHorasMinutos(tdaFechaIni, tdaFechaFin, tcrHoraIni, tcrHoraFin, "24", gcrSeparadorDecimal, "H");
            var lnuDiasEstancia = (int)(lnuHorasEstancia / 24);

            lnuDiasEstancia = lnuDiasEstancia * 24 != lnuHorasEstancia ? lnuDiasEstancia + 1 : lnuDiasEstancia;
            lnuDiasEstancia = lnuDiasEstancia <= 0 ? 1 : lnuDiasEstancia;

            return lnuDiasEstancia;
        }
        #endregion
        #endregion
        //-----------------------------------------------------------
        //- Lectura texto registros
        #region fcrLeerTextoRegistroControl: Leer Texto registro control
        /// <summary>
        /// <para>Leer Texto registro control para Formato Informe</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipoRegistro: 1=Registro de control 2=Registro detalle citas</para>
        /// </summary>
        public String fcrLeerTextoRegistroControl(String tcrTipoRegistro, int tnuTotalRegistros, String tcrSeparador)
        {
            var lcrTexto = String.Empty;
            var lcrFecha1 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrPrmFechaIniFiltro, "YMD", "-") + tcrSeparador;
            var lcrFecha2 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrPrmFechaFinFiltro, "YMD", "-") + tcrSeparador;

            lcrTexto = tcrTipoRegistro + tcrSeparador + lcrPrmIPSCodigoPrestador + tcrSeparador +
                       lcrPrmIPSTipoNit + tcrSeparador + lcrPrmIPSCodigoNit + tcrSeparador +
                       lcrFecha1 + lcrFecha2 + tnuTotalRegistros.ToString().Trim();

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroControlVentaMedic: Leer Texto registro control venta medicamentos
        /// <summary>
        /// <para>Leer Texto registro control venta medicamentos</para>
        /// <para>PARAMETROS:</para>
        /// </summary>
        public String fcrLeerTextoRegistroControlVentaMedic(String tcrSeparador)
        {
            var lcrTexto = String.Empty;
            // Mes inicio
            var lcrMesIniReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaInicio.Text, "MES");
            lcrMesIniReporte = Convert.ToInt32(lcrMesIniReporte).ToString().Trim();
            // Mes Fin 
            var lcrMesFinReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaFin.Text, "MES");
            lcrMesFinReporte = Convert.ToInt32(lcrMesFinReporte).ToString().Trim();
            // Año del reporte
            var lcrAñoReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaFin.Text, "AÑO");

            lcrTexto = "1" + tcrSeparador + "1" + tcrSeparador + "NI" + tcrSeparador + "824002672" +
                       tcrSeparador + "8" + tcrSeparador + gnuTotalMedicRegistros.ToString().Trim() +
                       tcrSeparador + tcrSeparador + tcrSeparador + tcrSeparador +
                       lcrAñoReporte + tcrSeparador + lcrMesIniReporte + tcrSeparador + 
                       lcrMesFinReporte + tcrSeparador + gnuTotalMedicRegistros.ToString().Trim() +
                       tcrSeparador + gnuTotalMedicValVentas.ToString().Trim();

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroControlCompraMedic: Leer Texto registro control Compra medicamentos
        /// <summary>
        /// <para>Leer Texto registro control compra medicamentos</para>
        /// <para>PARAMETROS:</para>
        /// </summary>
        public String fcrLeerTextoRegistroControlCompraMedic(String tcrSeparador)
        {
            var lcrTexto = String.Empty;
            // Mes inicio
            var lcrMesIniReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaInicio.Text, "MES");
            lcrMesIniReporte = Convert.ToInt32(lcrMesIniReporte).ToString().Trim();
            // Mes Fin 
            var lcrMesFinReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaFin.Text, "MES");
            lcrMesFinReporte = Convert.ToInt32(lcrMesFinReporte).ToString().Trim();
            // Año del reporte
            var lcrAñoReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaFin.Text, "AÑO");

            lcrTexto = "1" + tcrSeparador + "1" + tcrSeparador + "NI" + tcrSeparador + "824002672" +
                       tcrSeparador + "8" + tcrSeparador + tcrSeparador + lcrAñoReporte + tcrSeparador + lcrMesIniReporte + tcrSeparador +
                       lcrMesFinReporte + tcrSeparador + gnuTotalMedicRegistros.ToString().Trim() + tcrSeparador + gnuTotalMedicValCompras.ToString().Trim();

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroControlRes2175: Leer Texto registro control Res2175
        /// <summary>
        /// <para>Leer Texto registro control Resolución 2175</para>
        /// <para>PARAMETROS:</para>
        /// </summary>
        public String fcrLeerTextoRegistroControlRes2175(String tcrSeparador)
        {
            var lcrTexto = String.Empty;
            // Mes inicio
            var lcrFechaIniReporte = this.txtFiltroFechaInicio.Text;
            lcrFechaIniReporte = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaIniReporte, "YMD", "-");
            // Mes Fin 
            var lcrFechaFinReporte = this.txtFiltroFechaFin.Text;
            lcrFechaFinReporte = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrFechaFinReporte, "YMD", "-");
            // Año del reporte
            var lcrAñoReporte = Funciones.fcrComponenteFecha(this.txtFiltroFechaFin.Text, "AÑO");

            lcrTexto = "1" + tcrSeparador + "NI" + tcrSeparador + "824002672" + tcrSeparador + "205700023601" + tcrSeparador +
                       lcrFechaIniReporte + tcrSeparador + lcrFechaFinReporte + tcrSeparador + gnuTotalRes2175.ToString().Trim();
            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroCitas: Leer Texto registro para Formato Citas
        /// <summary>
        /// <para>Leer Texto registro para Formato Informe Citas</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipoRegistro: 1=Registro de control 2=Registro detalle citas</para>
        /// </summary>
        public String fcrLeerTextoRegistroCitas(String tcrTipoRegistro, int tnuordenVista, DataRow tobRegistro, String tcrSeparador)
        {
            var lcrTexto = String.Empty;

            #region Cargar campos
            var lcrCampo01 = tcrTipoRegistro + tcrSeparador;
            var lcrCampo02 = tobRegistro["sia_tipide_tide"] != null ? tobRegistro["sia_tipide_tide"].ToString() + tcrSeparador : tcrSeparador; // Tipo Ide
            var lcrCampo03 = tobRegistro["sia_nroide_usua"] != null ? tobRegistro["sia_nroide_usua"].ToString() + tcrSeparador : tcrSeparador; // Numero ide
            var lcrCampo04 = tobRegistro["sia_fecnac_usua"] != null ? tobRegistro["sia_fecnac_usua"].ToString() + tcrSeparador : tcrSeparador; // Fecha nacimiento
            var lcrCampo05 = tobRegistro["sis_codsex_sexo"] != null ? tobRegistro["sis_codsex_sexo"].ToString() : String.Empty; // Sexo
            var lcrCampo06 = tobRegistro["sia_priape_usua"] != null ? tobRegistro["sia_priape_usua"].ToString() + tcrSeparador : tcrSeparador; // Primer apellido
            var lcrCampo07 = tobRegistro["sia_segape_usua"] != null ? tobRegistro["sia_segape_usua"].ToString() + tcrSeparador : tcrSeparador; // Segund apellido
            var lcrCampo08 = tobRegistro["sia_prinom_usua"] != null ? tobRegistro["sia_prinom_usua"].ToString() + tcrSeparador : tcrSeparador; // Primer nombre
            var lcrCampo09 = tobRegistro["sia_segnom_usua"] != null ? tobRegistro["sia_segnom_usua"].ToString() + tcrSeparador : tcrSeparador; // Segundo nombre
            var lcrCampo10 = tobRegistro["sia_codeps_teps"] != null ? tobRegistro["sia_codeps_teps"].ToString() + tcrSeparador : tcrSeparador; // Codigo EPS
            // Tipo indicador segun codigo Cups
            var lcrCodigoCups = tobRegistro["fcm_codser_mant"] != null ? tobRegistro["fcm_codser_mant"].ToString() : String.Empty;
            var lcrCampo11 = fcrTipoIndicadorCalidad(lcrCodigoCups) + tcrSeparador; // Tipo indicador calidad
            var lcrCampo12 = tobRegistro["cit_fecsol_mcit"] != null ? tobRegistro["cit_fecsol_mcit"].ToString() + tcrSeparador : tcrSeparador; // Fecha solicitud
            var lcrCampo13 = tobRegistro["cit_estcit_easi"] != null ? tobRegistro["cit_estcit_easi"].ToString() + tcrSeparador : tcrSeparador; // Estado de la Cita Asiganda o No asignada
            var lcrCampo14 = tobRegistro["cit_feccit_mcit"] != null ? tobRegistro["cit_feccit_mcit"].ToString() : tcrSeparador; // Fecha Asignacion Cita
            var lcrCampo15 = tobRegistro["cit_fecreq_mcit"] != null ? tobRegistro["cit_fecreq_mcit"].ToString() : tcrSeparador; // Fecha solicitada o requerida
            #endregion

            #region Verificar datos citas 12
            if (lcrCampo12.Length >= 10)
            {
                if (lcrCampo12.Substring(0, 10) == "01/01/0001") // No hay datos desde maestro citas
                {
                    lcrCampo12 = tcrSeparador; // Fecha solicitud errada mas adelante se corrige
                }
            }
            #endregion

            // verificar si hubo relacion con maestro citas
            #region Verificar datos citas
            if (lcrCampo12 == tcrSeparador || lcrCampo14 == tcrSeparador || lcrCampo12 == "01/01/0001") // No hay datos desde maestro citas
            {
                lcrCampo12 = tobRegistro["fcm_fecser_dfac"] != null ? tobRegistro["fcm_fecser_dfac"].ToString() + tcrSeparador : tcrSeparador; // Fecha solicitud
                lcrCampo13 = "1";
                lcrCampo14 = lcrCampo12;
                lcrCampo15 = lcrCampo12;
            }
            #endregion
            /*
            if (lcrCampo03 == ("1007460939" + tcrSeparador))
            {
                MessageBox.Show("aqui voy  " + lcrCampo12);
            }
            */
            // Corregir fechas 
            #region Sexo, Estado cita y Corregir fechas

            // Sexo M=masculino F=Femenino
            lcrCampo05 = lcrCampo05 == "M" ? "H" + tcrSeparador : "M" + tcrSeparador;

            // Citga signada o no Asiganda
            //1=Libre 2=Asignada 3=Confirmada o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algun motivo)' 
            lcrCampo13 = lcrCampo13 == "5" ? "2" + tcrSeparador : "1" + tcrSeparador;

            // Fecha nacimiento
            if (lcrCampo04 != tcrSeparador)
            {
                lcrCampo04 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrCampo04.Substring(0, 10), "YMD", "-") + tcrSeparador; 
            }
            // Fecha Asignacion cita
            if (lcrCampo14 != tcrSeparador)
            {
                lcrCampo14 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrCampo14.Substring(0, 10), "YMD", "-");
            }
            else
            {
                lcrCampo14 = String.Empty; // cuando es solo el separador
            }
            // Fecha solicitud
            if (lcrCampo12 == tcrSeparador || lcrCampo12 == "01/01/0001")
            {
                lcrCampo12 = lcrCampo14 + tcrSeparador;
            }
            else
            {
                lcrCampo12 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrCampo12.Substring(0, 10), "YMD", "-") + tcrSeparador;
            }
            // Fecha solicitada o requerida
            if (lcrCampo15 == tcrSeparador || lcrCampo15 == "01/01/0001" || String.IsNullOrWhiteSpace(lcrCampo15))
            {
                lcrCampo15 = lcrCampo14;
            }
            else
            {
                lcrCampo15 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrCampo15.Substring(0, 10), "YMD", "-");
            }
            #endregion
            lcrCampo14 = lcrCampo14 + tcrSeparador;

            lcrTexto = lcrCampo01 + tnuordenVista.ToString().Trim() + tcrSeparador + lcrCampo02 + lcrCampo03 + lcrCampo04 + lcrCampo05 +
                       lcrCampo06 + lcrCampo07 + lcrCampo08 + lcrCampo09 + lcrCampo10 + lcrCampo11 + lcrCampo12 + lcrCampo13 + lcrCampo14 + lcrCampo15;

            return lcrTexto;
        }
        //- Indicador de calidad 
        #region fcrTipoIndicadorCalidad: Tipos indicadores Calidad Segun codigo del servicio
        /// <summary>
        /// <para>Tipos indicadores Calidad Segun codigo del servicio</para>
        /// </summary>
        public String fcrTipoIndicadorCalidad(String tcrCodigoCups)
        {
            var lcrTipo = "1";

            switch (tcrCodigoCups)
            {
                case "890201":
                    // Consulta externa primera vez
                    lcrTipo = "1";
                    break;

                case "890203":
                    // Consulta de odontologia primera vez
                    lcrTipo = "2";
                    break;

                case "882841":
                    // Ecografia
                    lcrTipo = "8";
                    break;

                case "881402":
                    // Ecografia
                    lcrTipo = "8";
                    break;
             }
            return lcrTipo;
        }
        #endregion
        #endregion
        #region fcrLeerTextoRegistroTriage: Leer Texto registro para Formato Triage
        /// <summary>
        /// <para>Leer Texto registro para Formato Triage</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipoRegistro: 1=Registro de control 2=Registro detalle Triage</para>
        /// </summary>
        public String fcrLeerTextoRegistroTriage(String tcrTipoRegistro, int tnuordenVista, DataRow tobRegistro, String tcrSeparador)
        {
            var lcrTexto = String.Empty;

            #region Cargar campos
            var lcrCampo01 = tcrTipoRegistro + tcrSeparador;
            var lcrCampo02 = tobRegistro[0] != null ? tobRegistro[0].ToString() + tcrSeparador : tcrSeparador;   // Tipo Ide
            var lcrCampo03 = tobRegistro[1] != null ? tobRegistro[1].ToString() + tcrSeparador : tcrSeparador;   // Numero ide
            var lcrCampo04 = tobRegistro[2] != null ? tobRegistro[2].ToString() + tcrSeparador : tcrSeparador;   // Fecha nacimiento
            var lcrCampo05 = tobRegistro[3] != null ? tobRegistro[3].ToString() : tcrSeparador;   // Sexo
            var lcrCampo06 = tobRegistro[4] != null ? tobRegistro[4].ToString() + tcrSeparador : tcrSeparador;   // Primer apellido
            var lcrCampo07 = tobRegistro[5] != null ? tobRegistro[5].ToString() + tcrSeparador : tcrSeparador;   // Segund apellido
            var lcrCampo08 = tobRegistro[6] != null ? tobRegistro[6].ToString() + tcrSeparador : tcrSeparador;   // Primer nombre
            var lcrCampo09 = tobRegistro[7] != null ? tobRegistro[7].ToString() + tcrSeparador : tcrSeparador;   // Segund Primer
            var lcrCampo10 = tobRegistro[8] != null ? tobRegistro[8].ToString() + tcrSeparador : tcrSeparador;   // Codigo EPS
            var lcrCampo11 = tobRegistro[9] != null ? tobRegistro[9].ToString() : tcrSeparador;                  // Fecha Clasificacion  Triage II
            var lcrCampo12 = tobRegistro[10] != null ? tobRegistro[10].ToString() : tcrSeparador;                // Hora clasificacion Triage II
            var lcrCampo13 = tobRegistro[11] != null ? tobRegistro[11].ToString() : tcrSeparador;                // Fecha Atencion Urgencia
            var lcrCampo14 = tobRegistro[12] != null ? tobRegistro[12].ToString() : tcrSeparador;                // Hora atencion urgencia
            #endregion

            // Sexo M=masculino F=Femenino
            lcrCampo05 = lcrCampo05 == "M" ? "H" + tcrSeparador : "M" + tcrSeparador;
            // Corregir fechas 
            lcrCampo04 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrCampo04.Substring(0, 10), "YMD", "-") + tcrSeparador;
            lcrCampo11 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrCampo11.Substring(0, 10), "YMD", "-") + tcrSeparador;
            lcrCampo13 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", lcrCampo13.Substring(0, 10), "YMD", "-") + tcrSeparador;
            // Corregir formato hora

            //MessageBox.Show("AQUI VOY " + lcrCampo12 + " " + lcrCampo14);

            lcrCampo12 = fcrConvierteHora(lcrCampo12) + tcrSeparador;
            lcrCampo14 = fcrConvierteHora(lcrCampo14);

            lcrTexto = lcrCampo01 + tnuordenVista.ToString().Trim() + tcrSeparador + lcrCampo02 + lcrCampo03 + lcrCampo04 + lcrCampo05 +
                       lcrCampo06 + lcrCampo07 + lcrCampo08 + lcrCampo09 + lcrCampo10 + lcrCampo11 + lcrCampo12 + lcrCampo13 + lcrCampo14;

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroTipo2SisproMedicVentas: Leer Texto registro Medicamento Venta
        /// <summary>
        /// <para>Leer Texto registro Medicamento Venta Sispro registros tipo detalles</para>
        /// </summary>
        public String fcrLeerTextoRegistroTipo2SisproMedicVentas(String tcrMesInicial, String tcrMesFinal,
                                                            ClassMedicVenta tobRegistro, String tcrSeparador)
        {
            var lcrTexto = String.Empty;

            #region Cargar campos
            var lcrCampo01 = "2" + tcrSeparador;                                    // Tipo registro
            var lcrCampo02 = tobRegistro.Secuencial + tcrSeparador;                 // Orden Vista
            var lcrCampo03 = tcrMesFinal + tcrSeparador;                            // Mes Final
            var lcrCampo04 = "INS" + tcrSeparador;                                  // Canal
            var lcrCampo05 = tobRegistro.CodigoCum + tcrSeparador;                  // Codigo CUM
            var lcrCampo06 = "NO" + tcrSeparador;                                   // Se Comercializa
            var lcrCampo07 = tobRegistro.PrecioUnitMin.ToString() + tcrSeparador;   // Precion Unit Minimo
            var lcrCampo08 = tobRegistro.PrecioUnitMax.ToString() + tcrSeparador;   // Precion Unit Maximo
            var lcrCampo09 = tobRegistro.TotalBrutoVenta.ToString() + tcrSeparador; // Valor total bruto ventas
            var lcrCampo10 = tobRegistro.TotalUniVentas.ToString() + tcrSeparador;  // Total unidades ventas
            var lcrCampo11 = tobRegistro.NumeroFacMinimo + tcrSeparador;            // Numero Factura Minimo
            var lcrCampo12 = tobRegistro.NumeroFacMaximo;                           // Numero Factura Maximo
            #endregion

            lcrTexto = lcrCampo01 + lcrCampo02 + lcrCampo03 + lcrCampo04 + lcrCampo05 +
                       lcrCampo06 + lcrCampo07 + lcrCampo08 + lcrCampo09 + lcrCampo10 + lcrCampo11 + lcrCampo12;

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroTipo2SisproMedicCompras: Leer Texto registro Medicamento Compra
        /// <summary>
        /// <para>Leer Texto registro Medicamento Compra Sispro registros tipo detalles</para>
        /// </summary>
        public String fcrLeerTextoRegistroTipo2SisproMedicCompras(String tcrMesInicial, String tcrMesFinal,
                                                            ClassMedicCompra tobRegistro, String tcrSeparador)
        {
            var lcrTexto = String.Empty;

            #region Cargar campos
            var lcrCampo01 = "2" + tcrSeparador;                                    // Tipo registro
            var lcrCampo02 = tobRegistro.Secuencial + tcrSeparador;                 // Orden Vista
            var lcrCampo03 = tcrMesFinal + tcrSeparador;                            // Mes Final
            var lcrCampo04 = tobRegistro.CodigoCum + tcrSeparador;                  // Codigo CUM
            var lcrCampo05 = tobRegistro.PrecioUnitMin.ToString() + tcrSeparador;   // Precion Unit Minimo
            var lcrCampo06 = tobRegistro.PrecioUnitMax.ToString() + tcrSeparador;   // Precion Unit Maximo
            var lcrCampo07 = tobRegistro.TotalBrutoCompra.ToString() + tcrSeparador; // Valor total bruto ventas
            var lcrCampo08 = tobRegistro.TotalUniCompras.ToString() + tcrSeparador;  // Total unidades ventas
            var lcrCampo09 = tobRegistro.NumeroFacMinimo + tcrSeparador;            // Numero Factura Minimo
            var lcrCampo10 = tobRegistro.NumeroFacMaximo;                           // Numero Factura Maximo
            #endregion

            lcrTexto = lcrCampo01 + lcrCampo02 + lcrCampo03 + lcrCampo04 + lcrCampo05 +
                       lcrCampo06 + lcrCampo07 + lcrCampo08 + lcrCampo09 + lcrCampo10;

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroTipo2Res2175: Leer Texto registro Detalle tipo 2 Recién Nacido
        /// <summary>
        /// <para>Leer Texto registro Detalle tipo 2 Recién Nacido</para>
        /// </summary>
        public String fcrLeerTextoRegistroTipo2Res2175(ClassRes2175Tipo2 tobRegistro, String tcrSeparador)
        {
            var lcrTexto = String.Empty;

            #region Cargar campos
            var lcrCampo00 = "2" + tcrSeparador;                                    // Tipo registro 2
            var lcrCampo01 = tobRegistro.Secuencial + tcrSeparador;                 // Orden Vista
            var lcrCampo02 = tobRegistro.TipoId + tcrSeparador;                     // Tipo de Identificación
            var lcrCampo03 = tobRegistro.NumeroId + tcrSeparador;                   // Numero de Identificación
            var lcrCampo04 = tobRegistro.FechaNac + tcrSeparador;                   // Fecha Nacimiento
            var lcrCampo05 =  tobRegistro.Sexo.ToString()=="F"? "M":"H";            // Sexo
                lcrCampo05 = lcrCampo05 + tcrSeparador;   
            var lcrCampo06 = tobRegistro.PertEtnica.ToString() + tcrSeparador;      // Pertenencia Etnica
            var lcrCampo07 = tobRegistro.PrimerApellido.ToString() + tcrSeparador;  // Primer apellido
            var lcrCampo08 = tobRegistro.SegundoApellido.ToString() + tcrSeparador; // segundo apellido
            var lcrCampo09 = tobRegistro.PrimerNombre.ToString() + tcrSeparador;    // Primer Nombre
            var lcrCampo10 = tobRegistro.SegundoNombre + tcrSeparador;              // Segundo Nombre
            var lcrCampo11 = tobRegistro.TamizajeNeonatal + tcrSeparador;           // Realizacion Tamizaje
            var lcrCampo12 = tobRegistro.FechaTamizaje;                             // Fecha Tamizaje
            #endregion
            lcrTexto = lcrCampo00 + lcrCampo01 + lcrCampo02 + lcrCampo03 + lcrCampo04 + lcrCampo05 + lcrCampo06 +
                       lcrCampo07 + lcrCampo08 + lcrCampo09 + lcrCampo10 + lcrCampo11 + lcrCampo12;

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroTipo3Res2175: Leer Texto registro Detalle tipo 3 detalle de O a 5 años
        /// <summary>
        /// <para>Leer Texto registro Detalle tipo 3 de O a 5 años</para>
        /// </summary>
        public String fcrLeerTextoRegistroTipo3Res2175(ClassRes2175Tipo3 tobRegistro, String tcrSeparador)
        {
            var lcrTexto = String.Empty;

            #region Cargar campos
            var lcrCampo00 = "3" + tcrSeparador;                                    // Tipo registro 3
            var lcrCampo01 = tobRegistro.Secuencial + tcrSeparador;                 // Orden Vista
            var lcrCampo02 = tobRegistro.TipoId + tcrSeparador;                     // Tipo de Identificación
            var lcrCampo03 = tobRegistro.NumeroId + tcrSeparador;                   // Numero de Identificación
            var lcrCampo04 = tobRegistro.FechaNac + tcrSeparador;                   // Fecha Nacimiento
            var lcrCampo05 = tobRegistro.Sexo.ToString() == "F" ? "M" : "H";        // Sexo
                lcrCampo05 = lcrCampo05 + tcrSeparador;
            var lcrCampo06 = tobRegistro.PertEtnica.ToString() + tcrSeparador;      // Pertenencia Etnica
            var lcrCampo07 = tobRegistro.PrimerApellido.ToString() + tcrSeparador;  // Primer apellido
            var lcrCampo08 = tobRegistro.SegundoApellido.ToString() + tcrSeparador; // segundo apellido
            var lcrCampo09 = tobRegistro.PrimerNombre.ToString() + tcrSeparador;    // Primer Nombre
            var lcrCampo10 = tobRegistro.SegundoNombre + tcrSeparador;              // Segundo Nombre
            var lcrCampo11 = tobRegistro.FechaAtencion + tcrSeparador;           	// Fecha de Atención
            var lcrCampo12 = tobRegistro.Finalidad + tcrSeparador;                 	// Finalidad Consulta
            var lcrCampo13 = tobRegistro.CodCups + tcrSeparador;                   	// Codigo CUPS
            var lcrCampo14 = tobRegistro.Peso + tcrSeparador;                       // Peso
            var lcrCampo15 = tobRegistro.Talla + tcrSeparador;                      // Talla
            var lcrCampo16 = tobRegistro.FecSulfato + tcrSeparador;                 // Fecha Sulfato Ferroso
            var lcrCampo17 = tobRegistro.FecVitaminaA + tcrSeparador;               // Fecha Vitamina A
            var lcrCampo18 = tobRegistro.FecMicronutrientes + tcrSeparador;         // Fecha Micronutrientes
            var lcrCampo19 = tobRegistro.FecHemoglobina + tcrSeparador;             // Fecha Hemoglobina		
            var lcrCampo20 = tobRegistro.ResHemoglobina;                            // Resultado Hemoglobina
            #endregion
            lcrTexto = lcrCampo00 + lcrCampo01 + lcrCampo02 + lcrCampo03 + lcrCampo04 + lcrCampo05 + lcrCampo06 +
                       lcrCampo07 + lcrCampo08 + lcrCampo09 + lcrCampo10 + lcrCampo11 + lcrCampo12 + lcrCampo13 +
                       lcrCampo14 + lcrCampo15 + lcrCampo16 + lcrCampo17 + lcrCampo18 + lcrCampo19 + lcrCampo20;

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroTipo4Res2175: Leer Texto registro Detalle tipo 4 detalle de 6 a 11 años
        /// <summary>
        /// <para>Leer Texto registro Detalle tipo 4 de 6 a 11 años</para>
        /// </summary>
        public String fcrLeerTextoRegistroTipo4Res2175(ClassRes2175Tipo4 tobRegistro, String tcrSeparador)
        {
            var lcrTexto = String.Empty;

            #region Cargar campos
            var lcrCampo00 = "4" + tcrSeparador;                                    // Tipo registro 4
            var lcrCampo01 = tobRegistro.Secuencial + tcrSeparador;                 // Orden Vista
            var lcrCampo02 = tobRegistro.TipoId + tcrSeparador;                     // Tipo de Identificación
            var lcrCampo03 = tobRegistro.NumeroId + tcrSeparador;                   // Numero de Identificación
            var lcrCampo04 = tobRegistro.FechaNac + tcrSeparador;                   // Fecha Nacimiento
            var lcrCampo05 = tobRegistro.Sexo.ToString() == "F" ? "M" : "H";        // Sexo
            lcrCampo05 = lcrCampo05 + tcrSeparador;
            var lcrCampo06 = tobRegistro.PertEtnica.ToString() + tcrSeparador;      // Pertenencia Etnica
            var lcrCampo07 = tobRegistro.PrimerApellido.ToString() + tcrSeparador;  // Primer apellido
            var lcrCampo08 = tobRegistro.SegundoApellido.ToString() + tcrSeparador; // segundo apellido
            var lcrCampo09 = tobRegistro.PrimerNombre.ToString() + tcrSeparador;    // Primer Nombre
            var lcrCampo10 = tobRegistro.SegundoNombre + tcrSeparador;              // Segundo Nombre
            var lcrCampo11 = tobRegistro.FechaAtencion + tcrSeparador;           	// Fecha de Atención
            var lcrCampo12 = tobRegistro.Finalidad + tcrSeparador;                 	// Finalidad Consulta
            var lcrCampo13 = tobRegistro.CodCups + tcrSeparador;                   	// Codigo CUPS
            var lcrCampo14 = tobRegistro.Peso + tcrSeparador;                       // Peso
            var lcrCampo15 = tobRegistro.Talla + tcrSeparador;                      // Talla           
            var lcrCampo16 = tobRegistro.FecHemoglobina + tcrSeparador;             // Fecha Hemoglobina		
            var lcrCampo17 = tobRegistro.ResHemoglobina;                            // Resultado Hemoglobina
            #endregion
            lcrTexto = lcrCampo00 + lcrCampo01 + lcrCampo02 + lcrCampo03 + lcrCampo04 + lcrCampo05 + lcrCampo06 +
                       lcrCampo07 + lcrCampo08 + lcrCampo09 + lcrCampo10 + lcrCampo11 + lcrCampo12 + lcrCampo13 +
                       lcrCampo14 + lcrCampo15 + lcrCampo16 + lcrCampo17;

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroTipo5Res2175: Leer Texto registro Detalle tipo 5 detalle de 12 a 17 años
        /// <summary>
        /// <para>Leer Texto registro Detalle tipo 5 de 12 a 17 años</para>
        /// </summary>
        public String fcrLeerTextoRegistroTipo5Res2175(ClassRes2175Tipo5 tobRegistro, String tcrSeparador)
        {
            var lcrTexto = String.Empty;

            #region Cargar campos
            var lcrCampo00 = "5" + tcrSeparador;                                    // Tipo registro 5
            var lcrCampo01 = tobRegistro.Secuencial + tcrSeparador;                 // Orden Vista
            var lcrCampo02 = tobRegistro.TipoId + tcrSeparador;                     // Tipo de Identificación
            var lcrCampo03 = tobRegistro.NumeroId + tcrSeparador;                   // Numero de Identificación
            var lcrCampo04 = tobRegistro.FechaNac + tcrSeparador;                   // Fecha Nacimiento
            var lcrCampo05 = tobRegistro.Sexo.ToString() == "F" ? "M" : "H";        // Sexo
            lcrCampo05 = lcrCampo05 + tcrSeparador;
            var lcrCampo06 = tobRegistro.PertEtnica.ToString() + tcrSeparador;      // Pertenencia Etnica
            var lcrCampo07 = tobRegistro.PrimerApellido.ToString() + tcrSeparador;  // Primer apellido
            var lcrCampo08 = tobRegistro.SegundoApellido.ToString() + tcrSeparador; // segundo apellido
            var lcrCampo09 = tobRegistro.PrimerNombre.ToString() + tcrSeparador;    // Primer Nombre
            var lcrCampo10 = tobRegistro.SegundoNombre + tcrSeparador;              // Segundo Nombre
            var lcrCampo11 = tobRegistro.FechaAtencion + tcrSeparador;           	// Fecha de Atención
            var lcrCampo12 = tobRegistro.Finalidad + tcrSeparador;                 	// Finalidad Consulta
            var lcrCampo13 = tobRegistro.CodCups + tcrSeparador;                   	// Codigo CUPS
            var lcrCampo14 = tobRegistro.Peso + tcrSeparador;                       // Peso
            var lcrCampo15 = tobRegistro.Talla + tcrSeparador;                      // Talla           
            var lcrCampo16 = tobRegistro.FecHemoglobina + tcrSeparador;             // Fecha Hemoglobina		
            var lcrCampo17 = tobRegistro.ResHemoglobina;                            // Resultado Hemoglobina
            #endregion
            lcrTexto = lcrCampo00 + lcrCampo01 + lcrCampo02 + lcrCampo03 + lcrCampo04 + lcrCampo05 + lcrCampo06 +
                       lcrCampo07 + lcrCampo08 + lcrCampo09 + lcrCampo10 + lcrCampo11 + lcrCampo12 + lcrCampo13 +
                       lcrCampo14 + lcrCampo15 + lcrCampo16 + lcrCampo17;

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroTipo6Res2175: Leer Texto registro Detalle tipo 6 detalle mujeres gestantes
        /// <summary>
        /// <para>Leer Texto registro Detalle tipo 6 mujeres gestantes</para>
        /// </summary>
        public String fcrLeerTextoRegistroTipo6Res2175(ClassRes2175Tipo6 tobRegistro, String tcrSeparador)
        {
            var lcrTexto = String.Empty;

            #region Cargar campos
            var lcrCampo00 = "6" + tcrSeparador;                                    // Tipo registro 6
            var lcrCampo01 = tobRegistro.Secuencial + tcrSeparador;                 // Orden Vista
            var lcrCampo02 = tobRegistro.TipoId + tcrSeparador;                     // Tipo de Identificación
            var lcrCampo03 = tobRegistro.NumeroId + tcrSeparador;                   // Numero de Identificación
            var lcrCampo04 = tobRegistro.PrimerApellido.ToString() + tcrSeparador;  // Primer apellido
            var lcrCampo05 = tobRegistro.SegundoApellido.ToString() + tcrSeparador; // segundo apellido
            var lcrCampo06 = tobRegistro.PrimerNombre.ToString() + tcrSeparador;    // Primer Nombre
            var lcrCampo07 = tobRegistro.SegundoNombre + tcrSeparador;              // Segundo Nombre
            var lcrCampo08 = tobRegistro.FechaNac + tcrSeparador;                   // Fecha Nacimiento
            var lcrCampo09 = tobRegistro.EdadGestacional + tcrSeparador;            // Edad Gestacional  
            var lcrCampo10 = tobRegistro.PertEtnica.ToString() + tcrSeparador;      // Pertenencia Etnica           
            var lcrCampo11 = tobRegistro.FechaAtencion + tcrSeparador;           	// Fecha de Atención
            var lcrCampo12 = tobRegistro.Finalidad + tcrSeparador;                 	// Finalidad Consulta
            var lcrCampo13 = tobRegistro.CodCups + tcrSeparador;                   	// Codigo CUPS
            var lcrCampo14 = tobRegistro.FecAcidoFolico + tcrSeparador;             // Fecha Acido Folico
            var lcrCampo15 = tobRegistro.FecSulfatoFerroso + tcrSeparador;          // Fecha Sulfato Ferroso          
            var lcrCampo16 = tobRegistro.FecCarbonatoCalcio + tcrSeparador;         // Fecha Carbonato de Calcio
            var lcrCampo17 = tobRegistro.FecAntigenoSupHep + tcrSeparador;          // Fecha de toma de Antígeno de superficie Hepatitis B
            var lcrCampo18 = tobRegistro.ResAntigenoSupHep + tcrSeparador;          // Resultado Antígeno de superficie Hepatitis B 
            var lcrCampo19 = tobRegistro.FecTomaSerologia + tcrSeparador;           // Fecha de toma de serología para sífilis	
            var lcrCampo20 = tobRegistro.ResSerologiaSifilis + tcrSeparador;        // Resultado serología para sífilis
            var lcrCampo21 = tobRegistro.FecAsesPreTestElisa + tcrSeparador;        // Fecha de asesoría pre test Elisa para VIH	
            var lcrCampo22 = tobRegistro.FecTomaTestElisa + tcrSeparador;           // Fecha de toma de Elisa para VIH 
            var lcrCampo23 = tobRegistro.ResTestElisaVIH + tcrSeparador;            // Resultado de Elisa para VIH 	
            var lcrCampo24 = tobRegistro.FecHemoglobina + tcrSeparador;             // Fecha Hemoglobina		
            var lcrCampo25 = tobRegistro.ResHemoglobina + tcrSeparador;             // Resultado Hemoglobina
            var lcrCampo26 = tobRegistro.FecConsLactMaterna;                        // Fecha de consejería en lactancia materna 

            #endregion
            lcrTexto = lcrCampo00 + lcrCampo01 + lcrCampo02 + lcrCampo03 + lcrCampo04 + lcrCampo05 + lcrCampo06 +
                       lcrCampo07 + lcrCampo08 + lcrCampo09 + lcrCampo10 + lcrCampo11 + lcrCampo12 + lcrCampo13 +
                       lcrCampo14 + lcrCampo15 + lcrCampo16 + lcrCampo17 + lcrCampo18 + lcrCampo19 + lcrCampo20 +
                       lcrCampo21 + lcrCampo22 + lcrCampo23 + lcrCampo24 + lcrCampo25 + lcrCampo26;

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroTipo7Res2175: Leer Texto registro Detalle tipo 7 detalle atenciones del parto
        /// <summary>
        /// <para>Leer Texto registro Detalle tipo 7 atenciones del parto</para>
        /// </summary>
        public String fcrLeerTextoRegistroTipo7Res2175(ClassRes2175Tipo7 tobRegistro, String tcrSeparador)
        {
            var lcrTexto = String.Empty;

            #region Cargar campos
            var lcrCampo00 = "7" + tcrSeparador;                                    // Tipo registro 7
            var lcrCampo01 = tobRegistro.Secuencial + tcrSeparador;                 // Orden Vista
            var lcrCampo02 = tobRegistro.TipoId + tcrSeparador;                     // Tipo de Identificación
            var lcrCampo03 = tobRegistro.NumeroId + tcrSeparador;                   // Numero de Identificación
            var lcrCampo04 = tobRegistro.PrimerApellido.ToString() + tcrSeparador;  // Primer apellido
            var lcrCampo05 = tobRegistro.SegundoApellido.ToString() + tcrSeparador; // segundo apellido
            var lcrCampo06 = tobRegistro.PrimerNombre.ToString() + tcrSeparador;    // Primer Nombre
            var lcrCampo07 = tobRegistro.SegundoNombre + tcrSeparador;              // Segundo Nombre
            var lcrCampo08 = tobRegistro.PertEtnica.ToString() + tcrSeparador;      // Pertenencia Etnica 
            var lcrCampo09 = tobRegistro.FechaAtenParto + tcrSeparador;             // Fecha Nacimiento
            var lcrCampo10 = tobRegistro.Finalidad + tcrSeparador;                 	// Finalidad Consulta   
            var lcrCampo11 = tobRegistro.CodCups + tcrSeparador;                   	// Codigo CUPS
            var lcrCampo12 = tobRegistro.TomaPruebaSifilis + tcrSeparador;          // Toma de prueba rápida para sífilis                   
            var lcrCampo13 = tobRegistro.FecTomaPruebaSifilis + tcrSeparador;       // Fecha de toma de prueba rápida para sífilis 
            var lcrCampo14 = tobRegistro.ResSerologiaSifilis + tcrSeparador;        // Resultados serología para sífilis 
            var lcrCampo15 = tobRegistro.AsesPreTestElisa + tcrSeparador;           // Asesoría pre test Elisa para VIH 
            var lcrCampo16 = tobRegistro.FecAsesPreTestElisa + tcrSeparador;        // Fecha Asesoría pre test Elisa para VIH
            var lcrCampo17 = tobRegistro.TomaTestElisa + tcrSeparador;              // Toma de prueba rápida para VIH 
            var lcrCampo18 = tobRegistro.FecTomaTestElisa + tcrSeparador;           // Fecha de Toma de prueba rápida para VIH		
            var lcrCampo19 = tobRegistro.ResTestElisaVIH + tcrSeparador;            // Resultado prueba rápida para VIH 
            var lcrCampo20 = tobRegistro.SuministroAntconcep + tcrSeparador;        // Suministro de anticonceptivo post evento obstétrico
            var lcrCampo21 = tobRegistro.FecSuminAntconcep;                         // Fecha suministro de anticonceptivo post evento obstétrico
            #endregion

            lcrTexto = lcrCampo00 + lcrCampo01 + lcrCampo02 + lcrCampo03 + lcrCampo04 + lcrCampo05 + lcrCampo06 +
                       lcrCampo07 + lcrCampo08 + lcrCampo09 + lcrCampo10 + lcrCampo11 + lcrCampo12 + lcrCampo13 +
                       lcrCampo14 + lcrCampo15 + lcrCampo16 + lcrCampo17 + lcrCampo18 + lcrCampo19 + lcrCampo20 +
                       lcrCampo21;

            return lcrTexto;
        }
        #endregion
        //----------------------------------------------------------------------
        //  FILTRO DE TEMPORALES SQL
        //----------------------------------------------------------------------
        //- Filtro
        #region fobTempFiltroSqlGeneral: Generar temporal Detalles citas/Triage
        /// <summary>
        /// <para>Generar temporal Detalles citas/Triage</para>
        /// <para>tcrTipoArchivo: "1"= Citas (resolucion 256) "2"=Triage (resolucion 256)</para>
        /// <para>"3"=Triage 2193 "4" = Citas 2193</para>
        /// <para>"5"=TMedicamentos Compras Sispro "6" = Medicamentos Ventas Sispro "7" = Resolución 2175 - Detalle Tipo 2</para>
        /// </summary>
        public DataTable fobTempFiltroSqlGeneral(String tcrTipoArchivo)
        {
            DataTable lobjDatosTabla = new DataTable();
            var lcrLineaSqlSelct = String.Empty;
            switch (tcrTipoArchivo)
            {
                case "1":
                    // Citas (resolucion 256)
                    lcrLineaSqlSelct = fcrStringCitasSQL("256");
                    break;

                case "2":
                    // Triage (resolucion 256)
                    lcrLineaSqlSelct = fcrStringTriageSQL("256");
                    break;

                case "3":
                    // Triage (resolucion 2193)
                    lcrLineaSqlSelct = fcrStringTriageSQL("2193");
                    break;

                case "4":
                    // Citas (resolucion 2193)
                    lcrLineaSqlSelct = fcrStringCitasSQL("2193");
                    break;

                case "5":
                    // Medicamentos - Compras
                    lcrLineaSqlSelct = fcrStringMedicamentosSisproSQL("COMPRA");
                    break;

                case "6":
                    // Medicamentos - Ventas
                    lcrLineaSqlSelct = fcrStringMedicamentosSisproSQL("VENTA");
                    break;
                
                case "7":
                    // Res2175 - Recién Nacidos
                    lcrLineaSqlSelct = fcrStringRes2175SisproSQL("TIPO2");
                    break;

                case "8":
                    // Res2175 - Atenciones en salud a los niños de 0 a 5 años.
                    lcrLineaSqlSelct = fcrStringRes2175SisproSQL("TIPO3");
                    break;

                case "9":
                    // Res2175 - Atenciones en salud de 6 a 11 años.
                    lcrLineaSqlSelct = fcrStringRes2175SisproSQL("TIPO4");
                    break;

                case "10":
                    // Res2175 - Atenciones en salud de 12 a 17 años.
                    lcrLineaSqlSelct = fcrStringRes2175SisproSQL("TIPO5");
                    break;

                case "11":
                    // Res2175 - Atenciones en salud a mujeres gestantes.
                    lcrLineaSqlSelct = fcrStringRes2175SisproSQL("TIPO6");
                    break;

                case "12":
                    // Res2175 - Atenciones en salud a atenciones del parto.
                    lcrLineaSqlSelct = fcrStringRes2175SisproSQL("TIPO7");
                    break;
            }
            lobjDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
            return lobjDatosTabla;
        }
        #endregion
        #region fobTempFiltroSql2193: filtro generar para informe 2193
        /// <summary>
        /// <para>Generar temporal Detalles segun grupo de registros 2193</para>
        /// </summary>
        public DataTable fobTempFiltroSql2193(String tcrTipoArchivo)
        {
            DataTable lobjDatosTabla = new DataTable();
            var lcrLineaSqlSelct = String.Empty;

            lcrLineaSqlSelct = fcrStringResumen2193Sql(tcrTipoArchivo);

            lobjDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
            return lobjDatosTabla;
        }
        #endregion
        //- Citas
        #region fcrStringCitasSQL: Generar String SQl para la consulta datos Citas
        /// <summary>
        /// <para>Generar String SQl para la consulta datos Citas</para>
        /// </summary>
        public String fcrStringCitasSQL(String tcrResolucion)
        {
            //1=Libre 2=Asignada 3=Confirmada o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algun motivo)' 
            var lcrLineaSqlSelct = String.Empty;
            var lcrFiltro = fcrStringCitasFiltro();

            if (tcrResolucion == "256")
            {
                #region Linea SQl para ejecutar
                lcrLineaSqlSelct = "SELECT admregadmision.sia_tipide_tide," +
                                           "admregadmision.sia_nroide_usua," +
                                           "siausuarioatend.sia_fecnac_usua," +
                                           "siausuarioatend.sis_codsex_sexo," +
                                           "siausuarioatend.sia_priape_usua," +
                                           "siausuarioatend.sia_segape_usua," +
                                           "siausuarioatend.sia_prinom_usua," +
                                           "siausuarioatend.sia_segnom_usua," +
                                           "fcmmaesfacturas.sia_codeps_teps," +
                                           "citmaesasigcita.cit_fecsol_mcit," +
                                           "citmaesasigcita.cit_estcit_easi," +
                                           "citmaesasigcita.cit_feccit_mcit," +
                                           "citmaesasigcita.cit_fecreq_mcit," +
                                           "fcmmaedetallfac.fcm_codser_mant," +
                                           "fcmmaedetallfac.fcm_coddig_mant," +
                                           "fcmmaedetallfac.sia_codrip_trip," +
                                           "fcmmaedetallfac.fcm_fecser_dfac," +
                                           "citmaesasigcita.cit_codasi_mcit " +
                                       "FROM fcmmaedetallfac " +
                                              "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                              "INNER JOIN admregadmision ON (fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                              "INNER JOIN siausuarioatend ON (admregadmision.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                              "LEFT JOIN citmaesasigcita ON (admregadmision.cit_codasi_mcit = citmaesasigcita.cit_codasi_mcit) " +
                                        "WHERE " + lcrFiltro + " AND " +
                                              "(fcmmaesfacturas.fcm_estfac_mfac = '2') AND  " +
                                              "((fcmmaedetallfac.fcm_codser_mant = '890201' AND fcmmaedetallfac.sia_codfco_fcon = '10') OR  " +
                                              "(fcmmaedetallfac.fcm_codser_mant = '890203') OR " +
                                              "(fcmmaedetallfac.fcm_codser_mant = '882841') OR "+
                                              "(fcmmaedetallfac.fcm_codser_mant = '881402'))";
                #endregion
            }
            else
            {
                lcrFiltro = fcrStringCitasFiltro2193();
                // por defecto 2193
                #region Linea SQl para ejecutar
                lcrLineaSqlSelct = "SELECT citmaesasigcita.sia_tipide_tide," +
                                          "citmaesasigcita.sia_nroide_usua," +
                                          "siausuarioatend.sia_fecnac_usua," +
                                          "siausuarioatend.sis_codsex_sexo," +
                                          "siausuarioatend.sia_priape_usua," +
                                          "siausuarioatend.sia_segape_usua," +
                                          "siausuarioatend.sia_prinom_usua," +
                                          "siausuarioatend.sia_segnom_usua," +
                                          "citmaesasigcita.sia_codeps_teps," +
                                          "siausuarioatend.sia_tipusu_regi," +
                                          "citservicioprog.cit_incali_spro," +
                                          "citmaesasigcita.cit_fecsol_mcit," +
                                          "citmaesasigcita.cit_estcit_easi," +
                                          "citmaesasigcita.cit_feccit_mcit," +
                                          "citmaesasigcita.cit_fecreq_mcit," +
                                          "citservicioprog.cit_codspr_spro," +
                                          "citservicioprog.cit_desspr_spro " +
                                        "FROM " +
                                          "citmaesasigcita " +
                                          "INNER JOIN citservicioprog ON (citmaesasigcita.cit_codspr_spro = citservicioprog.cit_codspr_spro) " +
                                          "INNER JOIN siausuarioatend ON (citmaesasigcita.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                        "WHERE " + lcrFiltro + " AND " +
                                          "(citservicioprog.cit_incali_spro <>'NA') AND " +
                                          "(citmaesasigcita.cit_estcit_easi <> '1' AND citmaesasigcita.cit_estcit_easi <> '6') " +
                                        "ORDER BY citmaesasigcita.cit_feccit_mcit,citmaesasigcita.sia_codeps_teps";
                #endregion
            }
            return lcrLineaSqlSelct;
        }
        #endregion
        #region fcrStringCitasFiltro: Generar la string filtro para informe citas
        /// <summary>
        /// <para>Generar la string filtro para informe citas</para>
        /// </summary>
        public String fcrStringCitasFiltro()
        {
            var lcrReturn   = String.Empty;
            var lcrReturn1  = String.Empty;
            var lcrReturn2  = String.Empty;
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaInicio.Text, "YMD", "-"); ;
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY","/", this.txtFiltroFechaFin.Text, "YMD", "-");

            // FILTRO RANGO DE FECHAS
            lcrReturn1 = "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND (fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "')";

            // FILTRO CONTRATO Y EPS
            #region Numero Contrato y EPS
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) && !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(fcmmaesfacturas.cto_seccon_cont = '" + lcrPrmCodigoContrato + "') " +
                            "AND (fcmmaesfacturas.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
            {
                lcrReturn2 = "(fcmmaesfacturas.cto_seccon_cont = '" + lcrPrmCodigoContrato + "')";
            }
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(fcmmaesfacturas.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            #endregion

            // Concatenar todo
            lcrReturn = !String.IsNullOrWhiteSpace(lcrReturn2) ? lcrReturn1 + " AND " + lcrReturn2 : lcrReturn1;

            return lcrReturn;
        }
        #endregion
        #region fcrStringCitasFiltro2193: Generar la string filtro para informe citas 2193
        /// <summary>
        /// <para>Generar la string filtro para informe citas 2193</para>
        /// </summary>
        public String fcrStringCitasFiltro2193()
        {
            var lcrReturn = String.Empty;
            var lcrReturn1 = String.Empty;
            var lcrReturn2 = String.Empty;
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaInicio.Text, "YMD", "-"); ;
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");

            // FILTRO RANGO DE FECHAS
            lcrReturn = "(citmaesasigcita.cit_feccit_mcit >= '" + lcrFechaIni + "') AND (citmaesasigcita.cit_feccit_mcit <= '" + lcrFechaFin + "')";

            return lcrReturn;
        }
        #endregion
        // Triage
        #region fcrStringTriageSQL: Generar String SQl para consulta Triage
        /// <summary>
        /// <para>Generar String SQl para consulta Triage</para>
        /// </summary>
        public String fcrStringTriageSQL(String tcrResolucion)
        {
            var lcrLineaSqlSelct = String.Empty;
            var lcrFiltro = fcrStringTriageFiltro();
            if (tcrResolucion == "256")
            {
                #region Linea SQl para ejecutar
                lcrLineaSqlSelct = "SELECT admregadmision.sia_tipide_tide," +
                                          "admregadmision.sia_nroide_usua," +
                                          "siausuarioatend.sia_fecnac_usua," +
                                          "siausuarioatend.sis_codsex_sexo," +
                                          "siausuarioatend.sia_priape_usua," +
                                          "siausuarioatend.sia_segape_usua," +
                                          "siausuarioatend.sia_prinom_usua," +
                                          "siausuarioatend.sia_segnom_usua," +
                                          "admregadmision.sia_codeps_teps," +
                                          "admtriagemaestr.adm_gesfec_tria," +
                                          "admtriagemaestr.adm_geshor_tria," +
                                          "admregadmision.adm_fecadm_rgad," +
                                          "admregadmision.adm_horadm_rgad " +
                                        "FROM " +
                                          "admregadmision " +
                                          "INNER JOIN siausuarioatend ON (admregadmision.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                          "INNER JOIN admtriagemaestr ON (admregadmision.adm_nroreg_tria = admtriagemaestr.adm_nroreg_tria) " +
                                        "WHERE " + lcrFiltro + " AND " +
                                          "(admregadmision.sia_regate_rgat = '1' AND admregadmision.adm_codtat_tatn = '3') AND " +
                                          "(admregadmision.sis_estpro_espr = '2' AND admtriagemaestr.adm_clasif_tria = '2') " +
                                        "ORDER BY admtriagemaestr.adm_gesfec_tria,admregadmision.sia_codeps_teps";

                #endregion
            }
            else
            {
                // Resolucion 2193
                #region Linea SQl para ejecutar
                lcrLineaSqlSelct = "SELECT admregadmision.sia_tipide_tide," +
                                          "admregadmision.sia_nroide_usua," +
                                          "siausuarioatend.sia_fecnac_usua," +
                                          "siausuarioatend.sis_codsex_sexo," +
                                          "siausuarioatend.sia_priape_usua," +
                                          "siausuarioatend.sia_segape_usua," +
                                          "siausuarioatend.sia_prinom_usua," +
                                          "siausuarioatend.sia_segnom_usua," +
                                          "admregadmision.sia_codeps_teps," +
                                          "admregadmision.sia_tipusu_regi," +
                                          "siaregimensalud.sia_destip_regi," +
                                          "admtriagemaestr.adm_gesfec_tria," +
                                          "admtriagemaestr.adm_geshor_tria," +
                                          "admregadmision.adm_fecadm_rgad," +
                                          "admregadmision.adm_horadm_rgad," +
                                          "admtriagemaestr.adm_clasif_tria," +
                                          "admtriagemaestr.adm_gesfec_tria," +
                                          "admtriagemaestr.adm_geshor_tria " +
                                        "FROM " +
                                          "admregadmision " +
                                          "INNER JOIN siausuarioatend ON (admregadmision.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                          "INNER JOIN siaregimensalud ON (admregadmision.sia_tipusu_regi = siaregimensalud.sia_tipusu_regi) " +
                                          "INNER JOIN admtriagemaestr ON (admregadmision.adm_nroreg_tria = admtriagemaestr.adm_nroreg_tria) " +
                                        "WHERE " + lcrFiltro + " AND " +
                                          "(admregadmision.sia_regate_rgat = '1' AND admregadmision.adm_codtat_tatn = '3') AND " +
                                          "(admregadmision.sis_estpro_espr = '2') " +
                                        "ORDER BY admtriagemaestr.adm_gesfec_tria,admregadmision.sia_codeps_teps";

                                         //"(admregadmision.sia_regate_rgat = '1' AND admregadmision.adm_codtat_tatn = '3') AND "

                #endregion
            }
            return lcrLineaSqlSelct;
        }
        #endregion
        #region fcrStringTriageFiltro: Generar la string filtro para informe triage
        /// <summary>
        /// <para>Generar la string filtro para informe triage</para>
        /// </summary>
        public String fcrStringTriageFiltro()
        {
            var lcrReturn = String.Empty;
            var lcrReturn1 = String.Empty;
            var lcrReturn2 = String.Empty;
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaInicio.Text, "YMD", "-"); ;
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");

            // FILTRO RANGO DE FECHAS
            lcrReturn1 = "(admtriagemaestr.adm_gesfec_tria >= '" + lcrFechaIni + "') AND (admtriagemaestr.adm_gesfec_tria <= '" + lcrFechaFin + "')";

            // FILTRO CONTRATO Y EPS
            #region Numero Contrato y EPS
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) && !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(admregadmision.cto_seccon_cont = '" + lcrPrmCodigoContrato + "') " +
                            "AND (admregadmision.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
            {
                lcrReturn2 = "(admregadmision.cto_seccon_cont = '" + lcrPrmCodigoContrato + "')";
            }
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(admregadmision.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            #endregion

            // Concatenar todo
            lcrReturn = !String.IsNullOrWhiteSpace(lcrReturn2) ? lcrReturn1 + " AND " + lcrReturn2 : lcrReturn1;

            return lcrReturn;
        }
        #endregion
        // Medicamentos
        #region fcrStringMedicamentosSisproSQL: Generar String SQl consulta Medicamentos
        /// <summary>
        /// <para>Generar String SQl consulta Medicamentos informe compra y venta Sispro</para>
        /// <para>tcrTipoReporte: "COMPRA" "VENTA"</para>
        /// </summary>
        public String fcrStringMedicamentosSisproSQL(String tcrTipoReporte)
        {
            var lcrLineaSqlSelct = String.Empty;
            var lcrFiltro        = String.Empty;

            if (tcrTipoReporte == "COMPRA")
            {
                lcrFiltro = fcrStringMedicamentosFiltroCompras();
                #region Linea SQl Compras
                lcrLineaSqlSelct = "SELECT  fcmmanservicips.fcm_codcum_sips," +
                              "fcmmanservicips.fcm_desser_sips," +
                              "fcmmaedetallfac.fcm_desser_dfac," +
                              "fcmmaedetallfac.fcm_numfac_mfac," +
                              "fcmmaedetallfac.fcm_valser_mant," +
                              "fcmmaedetallfac.fcm_totuni_dfac," +
                              "fcmmaedetallfac.fcm_valbru_dfac " +
                          "FROM " +
                              "fcmmaedetallfac " +
                              "INNER JOIN fcmmanservicips ON (fcmmaedetallfac.fcm_idesec_sips = fcmmanservicips.fcm_idesec_sips) " +
                          "WHERE " + lcrFiltro + " AND " +
                                  "(fcmmaedetallfac.fcm_estfac_mfac = '2') AND " +
                                  "((fcmmaedetallfac.sia_codrip_trip = '12') OR " +
                                  "(fcmmaedetallfac.sia_codrip_trip = '13')) " +
                          "ORDER BY fcmmaedetallfac.fcm_fecfac_mfac";
                #endregion
            }
            else if (tcrTipoReporte == "VENTA")
            {
                lcrFiltro = fcrStringMedicamentosFiltroVentas();
                #region Linea SQl ventas
                lcrLineaSqlSelct = "SELECT  fcmmanservicips.fcm_codcum_sips," +
                              "fcmmaedetallfac.fcm_desser_dfac," +
                              "fcmmaedetallfac.fcm_numfac_mfac," +
                              "fcmmaedetallfac.fcm_valser_mant," +
                              "fcmmaedetallfac.fcm_totuni_dfac," +
                              "fcmmaedetallfac.fcm_valbru_dfac " +
                          "FROM " +
                              "fcmmaedetallfac " +
                              "INNER JOIN fcmmanservicips ON (fcmmaedetallfac.fcm_idesec_sips = fcmmanservicips.fcm_idesec_sips) " +
                          "WHERE " + lcrFiltro + " AND " +
                                  "(fcmmaedetallfac.fcm_estfac_mfac = '2') AND " +
                                  "((fcmmaedetallfac.sia_codrip_trip = '12') OR " +
                                  "(fcmmaedetallfac.sia_codrip_trip = '13')) " +
                          "ORDER BY fcmmaedetallfac.fcm_fecfac_mfac";
                #endregion
            }
            return lcrLineaSqlSelct;
        }
        #endregion
        #region fcrStringMedicamentosFiltroVentas: Generar la string filtro para informes sispro ventas
        /// <summary>
        /// <para>Generar la string filtro para informes sispro medicamentos</para>
        /// </summary>
        public String fcrStringMedicamentosFiltroVentas()
        {
            var lcrReturn = String.Empty;
            var lcrReturn1 = String.Empty;
            var lcrReturn2 = String.Empty;
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaInicio.Text, "YMD", "-"); ;
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");

            // FILTRO RANGO DE FECHAS
            lcrReturn1 = "(fcmmaedetallfac.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND (fcmmaedetallfac.fcm_fecfac_mfac <= '" + lcrFechaFin + "')";

            // FILTRO CONTRATO Y EPS
            #region Numero Contrato y EPS
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) && !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(fcmmaedetallfac.cto_seccon_cont = '" + lcrPrmCodigoContrato + "') " +
                            "AND (fcmmaedetallfac.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
            {
                lcrReturn2 = "(fcmmaedetallfac.cto_seccon_cont = '" + lcrPrmCodigoContrato + "')";
            }
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(fcmmaedetallfac.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            #endregion

            // Concatenar todo
            lcrReturn = !String.IsNullOrWhiteSpace(lcrReturn2) ? lcrReturn1 + " AND " + lcrReturn2 : lcrReturn1;

            return lcrReturn;
        }
        #endregion
        #region fcrStringMedicamentosFiltroCompras: Generar la string filtro para informes sispro compras
        /// <summary>
        /// <para>Generar la string filtro para informes sispro medicamentos</para>
        /// </summary>
        public String fcrStringMedicamentosFiltroCompras()
        {
            var lcrReturn = String.Empty;
            var lcrReturn1 = String.Empty;
            var lcrReturn2 = String.Empty;
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaInicio.Text, "YMD", "-"); ;
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");

            // FILTRO RANGO DE FECHAS - se debe actualizar para que se haga desde la tabla de inventario
            lcrReturn1 = "(fcmmaedetallfac.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND (fcmmaedetallfac.fcm_fecfac_mfac <= '" + lcrFechaFin + "')";

            // FILTRO CONTRATO Y EPS
            #region Numero Contrato y EPS
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) && !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(fcmmaedetallfac.cto_seccon_cont = '" + lcrPrmCodigoContrato + "') " +
                            "AND (fcmmaedetallfac.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
            {
                lcrReturn2 = "(fcmmaedetallfac.cto_seccon_cont = '" + lcrPrmCodigoContrato + "')";
            }
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(fcmmaedetallfac.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            #endregion

            // Concatenar todo
            lcrReturn = !String.IsNullOrWhiteSpace(lcrReturn2) ? lcrReturn1 + " AND " + lcrReturn2 : lcrReturn1;

            return lcrReturn;
        }
        #endregion
        // Resolución 2175
        #region fcrStringRes2175SisproSQL: Generar String SQl consulta Resolución 2175
        /// <summary>
        /// <para>Generar String SQl consulta Resolución 2175 Sispro</para>
        /// <para>tcrTipoReporte: "TIPO2" "TIPO3" "TIPO4" "TIPO5" "TIPO6" "TIPO7"</para>
        /// </summary>
        public String fcrStringRes2175SisproSQL(String tcrTipoReporte)
        {
            var lcrLineaSqlSelct = String.Empty;
            var lcrFiltro = String.Empty;

            if (tcrTipoReporte == "TIPO2")
            {
                lcrFiltro = fcrStringRes2175Filtro("2");
                #region Linea SQl para ejecutar

                lcrLineaSqlSelct = "SELECT  siausuarioatend.sia_tipide_tide," +
                              "siausuarioatend.sia_nroide_usua," +
                              "siausuarioatend.sia_fecnac_usua," +
                              "siausuarioatend.sis_codsex_sexo," +
                              "siausuarioatend.sia_priape_usua," +
                              "siausuarioatend.sia_segape_usua," +
                              "siausuarioatend.sia_prinom_usua," +
                              "siausuarioatend.sia_segnom_usua " +
                          "FROM " +
                              "fcmmaesfacturas " +
                              "INNER JOIN admregadmision ON (fcmmaesfacturas.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                              "INNER JOIN siausuarioatend ON (fcmmaesfacturas.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                          "WHERE " + lcrFiltro + "ORDER BY siausuarioatend.sia_fecnac_usua";
                #endregion
            }
            else if (tcrTipoReporte == "TIPO3")
            {
                lcrFiltro = fcrStringRes2175Filtro("3");
                #region Linea SQl para ejecutar

                lcrLineaSqlSelct = "SELECT  siausuarioatend.sia_tipide_tide," +
                              "siausuarioatend.sia_nroide_usua," +
                              "siausuarioatend.sia_fecnac_usua," +
                              "siausuarioatend.sis_codsex_sexo," +
                              "siausuarioatend.sia_priape_usua," +
                              "siausuarioatend.sia_segape_usua," +
                              "siausuarioatend.sia_prinom_usua," +
                              "siausuarioatend.sia_segnom_usua," +
                              "fcmmaedetallfac.fcm_fecser_dfac," +
                              "fcmmaedetallfac.fcm_codser_mant," +
                              "fcmmaedetallfac.sia_codfco_fcon " +
                          "FROM " +
                              "fcmmaedetallfac " +
                              "INNER JOIN siausuarioatend ON (fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                          "WHERE " + lcrFiltro + " AND " +
                                  "(fcmmaedetallfac.sia_codrip_trip = '01') AND "+
                                  "(fcmmaedetallfac.fcm_estfac_mfac = '2') AND " +
                                  "(fcmmaedetallfac.sia_codfco_fcon = '04') " +
                          "ORDER BY fcmmaedetallfac.fcm_fecfac_mfac"; //
                #endregion
            }
            else if (tcrTipoReporte == "TIPO4")
            {
                lcrFiltro = fcrStringRes2175Filtro("4");
                #region Linea SQl para ejecutar

                lcrLineaSqlSelct = "SELECT  siausuarioatend.sia_tipide_tide," +
                              "siausuarioatend.sia_nroide_usua," +
                              "siausuarioatend.sia_fecnac_usua," +
                              "siausuarioatend.sis_codsex_sexo," +
                              "siausuarioatend.sia_priape_usua," +
                              "siausuarioatend.sia_segape_usua," +
                              "siausuarioatend.sia_prinom_usua," +
                              "siausuarioatend.sia_segnom_usua," +
                              "fcmmaedetallfac.fcm_fecser_dfac," +
                              "fcmmaedetallfac.fcm_codser_mant," +
                              "fcmmaedetallfac.sia_codfco_fcon " +
                          "FROM " +
                              "fcmmaedetallfac " +
                              "INNER JOIN siausuarioatend ON (fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                          "WHERE " + lcrFiltro + " AND " +
                                  "(fcmmaedetallfac.sia_codrip_trip = '01') AND " +
                                  "(fcmmaedetallfac.fcm_estfac_mfac = '2') AND " +
                                  "(fcmmaedetallfac.sia_codfco_fcon = '04') " +
                          "ORDER BY fcmmaedetallfac.fcm_fecfac_mfac"; 
                #endregion
            }
            else if (tcrTipoReporte == "TIPO5")
            {
                
                lcrFiltro = fcrStringRes2175Filtro("5");
                #region Linea SQl para ejecutar

                lcrLineaSqlSelct = "SELECT  siausuarioatend.sia_tipide_tide," +
                              "siausuarioatend.sia_nroide_usua," +
                              "siausuarioatend.sia_fecnac_usua," +
                              "siausuarioatend.sis_codsex_sexo," +
                              "siausuarioatend.sia_priape_usua," +
                              "siausuarioatend.sia_segape_usua," +
                              "siausuarioatend.sia_prinom_usua," +
                              "siausuarioatend.sia_segnom_usua," +
                              "fcmmaedetallfac.fcm_fecser_dfac," +
                              "fcmmaedetallfac.fcm_codser_mant," +
                              "fcmmaedetallfac.sia_codfco_fcon " +
                          "FROM " +
                              "fcmmaedetallfac " +
                              "INNER JOIN siausuarioatend ON (fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                          "WHERE " + lcrFiltro + " AND " +
                                  "(fcmmaedetallfac.sia_codrip_trip = '01') AND " +
                                  "(fcmmaedetallfac.fcm_estfac_mfac = '2') AND " +
                                  "(fcmmaedetallfac.sia_codfco_fcon = '05') " +
                          "ORDER BY fcmmaedetallfac.fcm_fecfac_mfac"; 
                #endregion
            
            }
            else if (tcrTipoReporte == "TIPO6")
            {
                lcrFiltro = fcrStringRes2175Filtro("6");
                #region Linea SQl para ejecutar

                lcrLineaSqlSelct = "SELECT  siausuarioatend.sia_tipide_tide," +
                              "siausuarioatend.sia_nroide_usua," +
                              "siausuarioatend.sia_fecnac_usua," +                              
                              "siausuarioatend.sia_priape_usua," +
                              "siausuarioatend.sia_segape_usua," +
                              "siausuarioatend.sia_prinom_usua," +
                              "siausuarioatend.sia_segnom_usua," +
                              "fcmmaedetallfac.fcm_fecser_dfac," +
                              "fcmmaedetallfac.fcm_codser_mant," +
                              "fcmmaedetallfac.sia_codfco_fcon " +
                          "FROM " +
                              "fcmmaedetallfac " +
                              "INNER JOIN siausuarioatend ON (fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                          "WHERE " + lcrFiltro + " AND " +
                                  "(fcmmaedetallfac.sia_codrip_trip = '01') AND " +
                                  "(fcmmaedetallfac.fcm_estfac_mfac = '2') AND " +
                                  "(fcmmaedetallfac.sia_codfco_fcon = '06') " +
                          "ORDER BY fcmmaedetallfac.fcm_fecfac_mfac"; 
                #endregion
            }
            else if (tcrTipoReporte == "TIPO7")
            {
                lcrFiltro = fcrStringRes2175Filtro("7");
                #region Linea SQl para ejecutar

                lcrLineaSqlSelct = "SELECT  siausuarioatend.sia_tipide_tide," +
                              "siausuarioatend.sia_nroide_usua," +
                              "siausuarioatend.sia_fecnac_usua," +                          
                              "siausuarioatend.sia_priape_usua," +
                              "siausuarioatend.sia_segape_usua," +
                              "siausuarioatend.sia_prinom_usua," +
                              "siausuarioatend.sia_segnom_usua," +
                              "fcmmaedetallfac.fcm_fecser_dfac," +
                              "fcmmaedetallfac.fcm_codser_mant," +
                              "fcmmaedetallfac.sia_codfco_fcon " +
                          "FROM " +
                              "fcmmaedetallfac " +
                              "INNER JOIN siausuarioatend ON (fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                          "WHERE " + lcrFiltro + " AND " +
                                  "(fcmmaedetallfac.sia_codrip_trip = '01') AND " +
                                  "(fcmmaedetallfac.fcm_estfac_mfac = '2') AND " +
                                  "(fcmmaedetallfac.sia_codfco_fcon = '01') " + 
                                  "ORDER BY fcmmaedetallfac.fcm_fecfac_mfac"; 
                #endregion
            }
            return lcrLineaSqlSelct;
        }
        #endregion
        #region fcrStringRes2175Filtro: Generar la string filtro para informes sispro
        /// <summary>
        /// <para>Generar la string filtro para informes sispro Resolución 2175</para>
        /// </summary>
        public String fcrStringRes2175Filtro(String tcrTipo)
        {
            var lcrReturn = String.Empty;
            var lcrReturn1 = String.Empty;
            var lcrReturn2 = String.Empty;
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaInicio.Text, "YMD", "-"); ;
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");

            // FILTRO RANGO DE FECHAS
            if (tcrTipo == "2") // RECIEN NACIDOS
            {
                lcrReturn1 = "(siausuarioatend.sia_fecnac_usua >= '" + lcrFechaIni + "') AND (siausuarioatend.sia_fecnac_usua <= '" + lcrFechaFin + "')";
            }else
            {
                if (tcrTipo == "3") // 0 A 5 AÑOS -  31- 2160
                {
                    lcrReturn1 = "(fcmmaedetallfac.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND (fcmmaedetallfac.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND "+
                              "(siausuarioatend.sia_edadia_usua >= 31) AND (siausuarioatend.sia_edadia_usua < 2190) AND "+
                              "((fcmmaedetallfac.fcm_codser_mant = '890201') OR (fcmmaedetallfac.fcm_codser_mant = '890205') OR (fcmmaedetallfac.fcm_codser_mant = '890301') OR (fcmmaedetallfac.fcm_codser_mant = '890305'))";
                }else
                {
                    if (tcrTipo == "4") // 6 A 11 AÑOS -  2160 - 4320
                    {
                        lcrReturn1 = "(fcmmaedetallfac.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND (fcmmaedetallfac.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                  "(siausuarioatend.sia_edadia_usua >= 2190) AND (siausuarioatend.sia_edadia_usua < 4380) AND " +
                                  "((fcmmaedetallfac.fcm_codser_mant = '890201') OR (fcmmaedetallfac.fcm_codser_mant = '890205') OR (fcmmaedetallfac.fcm_codser_mant = '890301') OR (fcmmaedetallfac.fcm_codser_mant = '890305'))";
                    }
                    else
                    {
                        if (tcrTipo == "5") // 12 A 17 AÑOS - 4320 - 6480
                        {
                            lcrReturn1 = "(fcmmaedetallfac.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND (fcmmaedetallfac.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                      "(siausuarioatend.sia_edadia_usua >= 4380) AND (siausuarioatend.sia_edadia_usua < 6570) AND " +
                                      "((fcmmaedetallfac.fcm_codser_mant = '890201') OR (fcmmaedetallfac.fcm_codser_mant = '890205') OR (fcmmaedetallfac.fcm_codser_mant = '890301') OR (fcmmaedetallfac.fcm_codser_mant = '890305'))";
                        }
                        else
                        {
                            if (tcrTipo == "6") // MUJERES GESTANTES
                            {
                                lcrReturn1 = "(fcmmaedetallfac.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND (fcmmaedetallfac.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                          "((fcmmaedetallfac.fcm_codser_mant = '890201') OR (fcmmaedetallfac.fcm_codser_mant = '890301') OR " +
                                          "(fcmmaedetallfac.fcm_codser_mant = '890305') OR (fcmmaedetallfac.fcm_codser_mant = '890203') OR" +
                                          "(fcmmaedetallfac.fcm_codser_mant = '890303') OR (fcmmaedetallfac.fcm_codser_mant = '890206') OR " +
                                          "(fcmmaedetallfac.fcm_codser_mant = '890306'))";
                            }
                            else
                            {
                                if (tcrTipo == "7") // REGISTRO DETALLE DE PARTO
                                {
                                    lcrReturn1 = "(fcmmaedetallfac.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND (fcmmaedetallfac.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                              "((fcmmaedetallfac.fcm_codser_mant = '735300') OR (fcmmaedetallfac.fcm_codser_mant = '735910') OR " +
                                              "(fcmmaedetallfac.fcm_codser_mant = '740100'))";
                                }
                                else
                                {
                                    lcrReturn1 = "(fcmmaedetallfac.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND (fcmmaedetallfac.fcm_fecfac_mfac <= '" + lcrFechaFin + "') AND " +
                                                  "(siausuarioatend.sia_edadia_usua >= 31) AND (siausuarioatend.sia_edadia_usua < 2160) AND " +
                                                  "((fcmmaedetallfac.fcm_codser_mant = 'XDXDXDXDXD'))";
                                }
                            }
                        }
                    }
                }
            }

            // FILTRO CONTRATO Y EPS
            #region Numero Contrato y EPS
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) && !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(fcmmaedetallfac.cto_seccon_cont = '" + lcrPrmCodigoContrato + "') " +
                            "AND (fcmmaedetallfac.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
            {
                lcrReturn2 = "(fcmmaedetallfac.cto_seccon_cont = '" + lcrPrmCodigoContrato + "')";
            }
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(fcmmaedetallfac.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            #endregion

            // Concatenar todo
            lcrReturn = !String.IsNullOrWhiteSpace(lcrReturn2) ? lcrReturn1 + " AND " + lcrReturn2 : lcrReturn1;

            return lcrReturn;
        }
        #endregion
        // Produiccion general Resolucion 2193
        #region fcrStringResumen2193SQL: Generar String SQl resumen general 2193
        /// <summary>
        /// <para>Generar String SQl resumen resolucion 2193 completa</para>
        /// </summary>
        public String fcrStringResumen2193Sql(String tcrTipoConsulta)
        {
            var lcrLineaSqlSelct = String.Empty;
            var lcrFiltro   = fcrStringResumen2193Filtro();
            var lcrReturn1  = String.Empty;
            var lcrReturn2  = String.Empty;
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaInicio.Text, "YMD", "-"); 
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");

            #region Linea SQl para ejecutar
            switch (tcrTipoConsulta)
            {

                case "TODOS": // Todos los servicios facturados
                    #region Linea SQl para ejecutar
                    lcrLineaSqlSelct = "SELECT  estplangr2193md.est_nroreg_esgr, " +
                                                "estplangr2193ma.est_nomgru_esgr, " +
                                                "admregadmision.sia_tipusu_regi, " +
                                                "fcmmaedetallfac.fcm_serpos_sips, " +
                                                "SUM(fcmmaedetallfac.fcm_totuni_dfac) AS fcm_totuni_dfac " +
                                           "FROM fcmmaedetallfac " +
                                                 "INNER JOIN admregadmision ON (fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                                 "INNER JOIN estplangr2193md ON (fcmmaedetallfac.fcm_coddig_mant = estplangr2193md.fcm_coddig_mant) " +
                                                 "INNER JOIN estplangr2193ma ON (estplangr2193md.est_nroreg_esgr = estplangr2193ma.est_nroreg_esgr) " +
                                                 "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                            "WHERE " + lcrFiltro + " AND " +
                                                 "(fcmmaesfacturas.fcm_estfac_mfac = '2') AND " +
                                                 "(estplangr2193md.est_estreg_esgr = '1') " +
                                           "GROUP BY estplangr2193md.est_nroreg_esgr, " +
                                                 "admregadmision.sia_tipusu_regi, " +
                                                 "fcmmaedetallfac.fcm_serpos_sips	 " +
                                           "ORDER BY estplangr2193ma.est_ordgru_esgr,estplangr2193ma.est_ordvis_esgr";
                    #endregion
                    break;

                case "R006": // Solo para consulta de urgencias
                    #region Linea SQl consulta de urgencias
                    lcrLineaSqlSelct = "SELECT  estplangr2193md.est_nroreg_esgr, " +
                                                "estplangr2193ma.est_nomgru_esgr, " +
                                                "admregadmision.sia_tipusu_regi, " +
                                                "fcmmaedetallfac.fcm_serpos_sips, " +
                                                "SUM(fcmmaedetallfac.fcm_totuni_dfac) AS fcm_totuni_dfac " +
                                           "FROM fcmmaedetallfac " +
                                                 "INNER JOIN admregadmision ON (fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                                 "INNER JOIN estplangr2193md ON (fcmmaedetallfac.fcm_coddig_mant = estplangr2193md.fcm_coddig_mant) " +
                                                 "INNER JOIN estplangr2193ma ON (estplangr2193md.est_nroreg_esgr = estplangr2193ma.est_nroreg_esgr) " +
                                                 "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                            "WHERE " + lcrFiltro + " AND " +
                                                 "(fcmmaesfacturas.fcm_estfac_mfac = '2') AND " +
                                                 "(admregadmision.sia_regate_rgat = '1') AND " +
                                                 "(estplangr2193md.est_nroreg_esgr = 'R006') AND " +
                                                 "(estplangr2193md.est_estreg_esgr = '1') " +
                                           "GROUP BY estplangr2193md.est_nroreg_esgr, " +
                                                 "admregadmision.sia_tipusu_regi, " +
                                                 "fcmmaedetallfac.fcm_serpos_sips	 " +
                                           "ORDER BY estplangr2193ma.est_ordgru_esgr,estplangr2193ma.est_ordvis_esgr";
                    #endregion
                    break;

                case "R0X6": // Solo para consulta de urgencias Triage 4 y 5 
                    #region Linea SQl consulta de urgencias
                    lcrLineaSqlSelct = "SELECT  estplangr2193md.est_nroreg_esgr, " +
                                                "estplangr2193ma.est_nomgru_esgr, " +
                                                "admregadmision.sia_tipusu_regi, " +
                                                "fcmmaedetallfac.fcm_serpos_sips, " +
                                                "SUM(fcmmaedetallfac.fcm_totuni_dfac) AS fcm_totuni_dfac " +
                                           "FROM fcmmaedetallfac " +
                                                 "INNER JOIN admregadmision ON (fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                                                 "INNER JOIN estplangr2193md ON (fcmmaedetallfac.fcm_coddig_mant = estplangr2193md.fcm_coddig_mant) " +
                                                 "INNER JOIN estplangr2193ma ON (estplangr2193md.est_nroreg_esgr = estplangr2193ma.est_nroreg_esgr) " +
                                                 "INNER JOIN fcmmaesfacturas ON (fcmmaedetallfac.fcm_numfac_mfac = fcmmaesfacturas.fcm_numfac_mfac) " +
                                            "WHERE " + lcrFiltro + " AND " +
                                                 "(fcmmaesfacturas.fcm_estfac_mfac = '2') AND " +
                                                 "(admregadmision.sia_regate_rgat = '2') AND " +
                                                 "(estplangr2193md.est_nroreg_esgr = 'R0X6') AND " +
                                                 "(estplangr2193md.est_estreg_esgr = '1') " +
                                           "GROUP BY estplangr2193md.est_nroreg_esgr, " +
                                                 "admregadmision.sia_tipusu_regi, " +
                                                 "fcmmaedetallfac.fcm_serpos_sips	 " +
                                           "ORDER BY estplangr2193ma.est_ordgru_esgr,estplangr2193ma.est_ordvis_esgr";

                    #endregion
                    break;

                case "R012": // Tratamientos terminados odontologia
                    #region Tratamientos terminados odontologia

                    lcrFiltro = "(odneventosmaest.odn_feccie_odev >= '" + lcrFechaIni + "') AND (odneventosmaest.odn_feccie_odev <= '" + lcrFechaFin + "')";
                    // FILTRO CONTRATO Y EPS
                    #region Numero Contrato y EPS
                    if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) && !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                    {
                        lcrReturn1 = "(siausuarioatend.cto_seccon_cont = '" + lcrPrmCodigoContrato + "') " +
                                    "AND (siausuarioatend.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
                    }
                    else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
                    {
                        lcrReturn1 = "(siausuarioatend.cto_seccon_cont = '" + lcrPrmCodigoContrato + "')";
                    }
                    if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                    {
                        lcrReturn1 = "(siausuarioatend.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
                    }
                    #endregion

                    lcrFiltro = !String.IsNullOrWhiteSpace(lcrReturn1) ? lcrFiltro + " AND " + lcrReturn1 : lcrFiltro;

                    // se utilizan SET para cumplir estructura y poder utilizar la funcion "fcvLeerTextoInformeResumen2193Guardar"
                    lcrLineaSqlSelct = "SELECT siausuarioatend.sia_tipusu_regi, " +
                                              "COUNT(siausuarioatend.sia_tipusu_regi) AS fcm_totuni_dfac " +
                                        "FROM odneventosmaest " +
                                                "INNER JOIN siausuarioatend ON (odneventosmaest.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                          "WHERE " + lcrFiltro + " " +
                                        "GROUP BY siausuarioatend.sia_tipusu_regi";
                    #endregion
                    break;

                case "R025": // Días estancia de los egresos obstétricos (Partos, cesáreas y otros obstétricos)
                    #region Días estancia de los egresos obstétricos
                    lcrLineaSqlSelct = "SELECT admregadmision.sia_idesec_usua, " +
						                      "admregadmision.adm_secadm_rgad, " +
						                      "admregadmision.sia_tipide_tide, " +
						                      "admregadmision.sia_nroide_usua, " +
						                      "admregadmision.adm_fecadm_rgad, " +
						                      "admregadmision.adm_horadm_rgad, " +
						                      "admregistegreso.adm_fecegr_regr, " +
						                      "admregistegreso.adm_horegr_regr, " +
						                      "admregistegreso.adm_aparto_regr, " +
						                      "admregistegreso.adm_actpar_regr, " +
						                      "admregistegreso.adm_diases_regr, " +
						                      "admregistegreso.adm_horase_regr, " +
						                      "admregadmision.adm_dessal_regr, " +
						                      "admregadmision.sia_tipusu_regi, " +
						                      "admregadmision.sia_edaano_usua, " +
						                      "admregadmision.sia_edames_usua, " +
						                      "admregadmision.sia_edadia_usua, " +
						                      "admregadmision.sia_regate_rgat, " +
						                      "admregadmision.adm_codtat_tatn " +
					                    "FROM " +
						                      "admregadmision " +
						                      "LEFT  JOIN admregistegreso ON (admregadmision.adm_secadm_rgad = admregistegreso.adm_secadm_rgad) " +
						                      "INNER JOIN fcmmaesfacturas ON (admregadmision.adm_secadm_rgad = fcmmaesfacturas.adm_secadm_rgad) " +
                                        "WHERE " + lcrFiltro + " AND " +
                                               "fcmmaesfacturas.fcm_estfac_mfac = '2' AND " +
						                       "admregadmision.sia_regate_rgat = '1' AND " +
						                       "admregistegreso.adm_aparto_regr = '1' " +
					                    "ORDER BY admregadmision.adm_fecadm_rgad";
                    #endregion
                    break;

                case "R027": // Días estancia de los egresos No quirúrgicos 
                    #region Total dias camas ocupadas en periodo
                    // Filtro General
                    lcrFiltro = "((admregurgencias.adm_fecegr_regu >= '" + lcrFechaIni + "' AND admregurgencias.adm_fecegr_regu <= '" + lcrFechaFin + "') OR " +
                                "(admregistegreso.adm_fecegr_regr >= '" + lcrFechaIni + "' AND admregistegreso.adm_fecegr_regr <= '" + lcrFechaFin + "'))";

                    // FILTRO CONTRATO Y EPS
                    #region Numero Contrato y EPS
                    if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) && !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                    {
                        lcrReturn1 = "(admregadmision.cto_seccon_cont = '" + lcrPrmCodigoContrato + "') " +
                                    "AND (admregadmision.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
                    }
                    else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
                    {
                        lcrReturn1 = "(admregadmision.cto_seccon_cont = '" + lcrPrmCodigoContrato + "')";
                    }
                    if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                    {
                        lcrReturn1 = "(admregadmision.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
                    }
                    #endregion
                    lcrFiltro = !String.IsNullOrWhiteSpace(lcrReturn1) ? lcrFiltro + " AND " + lcrReturn1 : lcrFiltro;

                    #region Días estancia de los egresos No quirúrgicos
                    lcrLineaSqlSelct = "SELECT admregadmision.sia_idesec_usua, " +
						                      "admregadmision.adm_secadm_rgad, " +
						                      "admregadmision.sia_tipide_tide, " +
						                      "admregadmision.sia_nroide_usua, " +
						                      "admregurgencias.adm_fecegr_regu, " +
						                      "admregurgencias.adm_horegr_regu, " +
						                      "admregurgencias.adm_diases_regu, " +
						                      "admregurgencias.adm_horase_regu, " +
						                      "admregurgencias.sia_dixsal_tdia, " +
						                      "admregurgencias.sia_dixre1_tdia, " +
						                      "admregurgencias.sia_dixre2_tdia, " +
						                      "admregurgencias.sia_dixre3_tdia, " +
						                      "admregistegreso.adm_fecegr_regr, " +
						                      "admregistegreso.adm_horegr_regr, " +
						                      "admregistegreso.adm_aparto_regr, " +
						                      "admregistegreso.adm_actpar_regr, " +
						                      "admregistegreso.adm_diases_regr, " +
						                      "admregistegreso.adm_horase_regr, " +
						                      "admregadmision.adm_dessal_regr, " +
						                      "admregadmision.sia_tipusu_regi, " +
						                      "admregadmision.sia_edaano_usua, " +
						                      "admregadmision.sia_edames_usua, " +
						                      "admregadmision.sia_edadia_usua, " +
						                      "admregadmision.adm_fecadm_rgad, " +
						                      "admregadmision.adm_horadm_rgad, " +
						                      "admregadmision.sia_regate_rgat, " +
						                      "admregadmision.adm_codtat_tatn " +
					                    "FROM " +
						                      "admregadmision " +
						                      "INNER JOIN admregurgencias ON (admregadmision.adm_secadm_rgad = admregurgencias.adm_secadm_rgad) " +
						                      "LEFT  JOIN admregistegreso ON (admregadmision.adm_secadm_rgad = admregistegreso.adm_secadm_rgad) " +
                                        "WHERE " + lcrFiltro + " AND " +
						                       "admregadmision.sia_regate_rgat = '1' " +
					                    "ORDER BY admregadmision.adm_fecadm_rgad";
                    #endregion
                    #endregion
                    break;

                case "R031": // Total camas habilitadas
                    #region Total camas habilitadas
                    lcrLineaSqlSelct = "SELECT COUNT(*) AS fcm_totuni_dfac FROM hoscamasareas WHERE hos_estcam_ecam <> '5'";
                    #endregion
                    break;

                case "R032": // Total dias camas ocupadas en periodo
                    #region Total dias camas ocupadas en periodo
                    // Filtro General
                    lcrFiltro = "((admregadmision.adm_fecadm_rgad >= '" + lcrFechaIni + "' AND admregadmision.adm_fecadm_rgad <= '" + lcrFechaFin + "') OR " +
                                "(admregurgencias.adm_fecegr_regu >= '" + lcrFechaIni + "' AND admregurgencias.adm_fecegr_regu <= '" + lcrFechaFin + "') OR " +
                                "(admregistegreso.adm_fecegr_regr >= '" + lcrFechaIni + "' AND admregistegreso.adm_fecegr_regr <= '" + lcrFechaFin + "')) AND " +
                                "admregadmision.sia_regate_rgat = '1'";

                    // FILTRO CONTRATO Y EPS
                    #region Numero Contrato y EPS
                    if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) && !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                    {
                        lcrReturn1 = "(admregadmision.cto_seccon_cont = '" + lcrPrmCodigoContrato + "') " +
                                    "AND (admregadmision.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
                    }
                    else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
                    {
                        lcrReturn1 = "(admregadmision.cto_seccon_cont = '" + lcrPrmCodigoContrato + "')";
                    }
                    if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                    {
                        lcrReturn1 = "(admregadmision.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
                    }
                    #endregion
                    lcrFiltro = !String.IsNullOrWhiteSpace(lcrReturn1) ? lcrFiltro + " AND " + lcrReturn1 : lcrFiltro;

                    #region Linea SQL
                    lcrLineaSqlSelct = "SELECT admregadmision.sia_idesec_usua," +
		                                       "admregadmision.adm_secadm_rgad,"+
		                                       "admregadmision.sia_tipide_tide,"+
		                                       "admregadmision.sia_nroide_usua,"+
		                                       "admregadmision.adm_fecadm_rgad,"+
		                                       "admregadmision.adm_horadm_rgad,"+
		                                       "admregurgencias.adm_fecegr_regu,"+
		                                       "admregurgencias.adm_horegr_regu,"+
		                                       "admregurgencias.adm_diases_regu,"+
		                                       "admregurgencias.adm_horase_regu,"+
		                                       "admregistegreso.adm_fecegr_regr,"+
		                                       "admregistegreso.adm_horegr_regr,"+
		                                       "admregistegreso.adm_diases_regr,"+
		                                       "admregistegreso.adm_horase_regr,"+
		                                       "admregadmision.adm_dessal_regr,"+
		                                       "admregadmision.sia_tipusu_regi,"+
		                                       "admregadmision.sia_edaano_usua,"+
		                                       "admregadmision.sia_edames_usua,"+
		                                       "admregadmision.sia_edadia_usua,"+
		                                       "admregadmision.sia_regate_rgat,"+
		                                       "admregadmision.adm_codtat_tatn "+
	                                        "FROM admregadmision "+
	                                          "INNER JOIN admregurgencias ON (admregadmision.adm_secadm_rgad = admregurgencias.adm_secadm_rgad) "+
	                                          "LEFT  JOIN admregistegreso ON (admregadmision.adm_secadm_rgad = admregistegreso.adm_secadm_rgad) "+
                                          "WHERE " + lcrFiltro + " " +
	                                      "ORDER BY admregadmision.adm_fecadm_rgad";
                    #endregion
                    #endregion
                    break;

            }
            #endregion
            return lcrLineaSqlSelct;
        }
        #endregion
        #region fcrStringResumen2193Filtro: Generar la string filtro resumen general 2193
        /// <summary>
        /// <para>Generar la string filtro para Resumen general 2193</para>
        /// </summary>
        public String fcrStringResumen2193Filtro()
        {
            var lcrReturn   = String.Empty;
            var lcrReturn1  = String.Empty;
            var lcrReturn2  = String.Empty;
            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaInicio.Text, "YMD", "-"); ;
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", this.txtFiltroFechaFin.Text, "YMD", "-");

            // FILTRO RANGO DE FECHAS
            lcrReturn1 = "(fcmmaesfacturas.fcm_fecfac_mfac >= '" + lcrFechaIni + "') AND (fcmmaesfacturas.fcm_fecfac_mfac <= '" + lcrFechaFin + "')";

            // FILTRO CONTRATO Y EPS
            #region Numero Contrato y EPS
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) && !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(fcmmaesfacturas.cto_seccon_cont = '" + lcrPrmCodigoContrato + "') " +
                            "AND (fcmmaesfacturas.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
            {
                lcrReturn2 = "(fcmmaesfacturas.cto_seccon_cont = '" + lcrPrmCodigoContrato + "')";
            }
            if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
            {
                lcrReturn2 = "(fcmmaesfacturas.sia_codeps_teps = '" + lcrPrmCodigoEps + "')";
            }
            #endregion

            // Concatenar todo
            lcrReturn = !String.IsNullOrWhiteSpace(lcrReturn2) ? lcrReturn1 + " AND " + lcrReturn2 : lcrReturn1;

            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        // PROCESO GESTION RIPS AUXILIAR POR ACTIVIDAD SIN FACTURAS
        //----------------------------------------------------------------------
        #region flsAuxFiltroTempDetallesServicios: (FILTRO) Detalles servicios sin facturas
        /// <summary>
        /// <para>FILTRO auxiliar Rips paa detalles servicios en facturacion separados por Asistencial y PyP</para>
        /// <para>Desde tipo filtro por actividad sin facturas</para>
        /// <para>Rips: AC=Consultas/AP=Procedimientos/AM=Medicamentos/AT=Otros Servicios</para>
        /// </summary>
        public List<EFfcmmaedetallfac> flsAuxFiltroTempDetallesServicios()
        {
            List<EFfcmmaedetallfac> tmpDatos = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                //Contrato Eps y Regimen
                #region Filtro
                tmpDatos = (from detalles in db.Fcmmaedetallfac
                            join contrato in db.Ctomaescontrato on detalles.cto_seccon_cont equals contrato.cto_seccon_cont
                            where detalles.fcm_fecfac_mfac >= ldaPrmFechaIniFiltro &&
                                  detalles.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                  detalles.cto_seccon_cont == lcrPrmCodigoContrato &&
                                  detalles.sia_codeps_teps == lcrPrmCodigoEps &&
                                  detalles.fcm_estfac_mfac == "2"
                            orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                            select detalles).ToList();
                #endregion
            }
            return tmpDatos;
        }
        #endregion
        //----------------------------------------------------------------------
        // CLASES PARA ESTRUCTURAS RIPS
        //----------------------------------------------------------------------
        #region tmpAdmision: Estructura temporal Datos admision
        /// <summary>
        /// <para>Estructura temporal Datos admision</para>
        /// </summary>
        public class tmpAdmision
        {
            #region Datos admision
            ///<summary>Numero de la factura generada en el cierre de facturación</summary>
            public String Fcm_numfac_mfac { get; set; }
            ///<summary>Secuencial de Admisión</summary>
            public String Adm_secadm_rgad { get; set; }
            ///<summary>Consecutivo Único de paciente en el sistema</summary>
            public String Sia_idesec_usua { get; set; }
            ///<summary>Tipo identificación del usuario o Paciente</summary>
            public String Sia_tipide_tide { get; set; }
            ///<summary>Numero de identificación del paciente: Registro civil...</summary>
            public String Sia_nroide_usua { get; set; }
            ///<summary>Fecha de la Admisión o del registro de atención ambulatoria</summary>
            public DateTime Adm_fecadm_rgad { get; set; }
            ///<summary>Hora de Admisión o atención ambulatoria en formato militar (HH) ejm: 16</summary>
            public decimal Adm_horadm_rgad { get; set; }
            ///<summary>La paciente esta embarazada : 1=SI 2=NO</summary>
            public String Adm_pacemb_rgad { get; set; }
            ///<summary>Origen de Admisión o vía de ingreso a la institución</summary>
            public String Adm_codoad_toad { get; set; }
            ///<summary>Tipo de Atención o ámbito donde se prestara el servicio :1=Ambulatoria 2=Hospitalización 3=Urgencia</summary>
            public String Adm_codtat_tatn { get; set; }
            ///<summary>Causa Externa Origen que origina la atención según Resolución: 3374 RIPS</summary>
            public String Adm_codcex_tcex { get; set; }
            ///<summary>Diagnostico de Ingreso a hospitalización/Urgencias con Observación</summary>
            public String Sia_dixing_tdia { get; set; }
            ///<summary>Fecha en que Inicia Hospitalización</summary>
            public DateTime Adm_fechos_rgad { get; set; }
            ///<summary>Hora en que Inicia Hospitalización</summary>
            public decimal Adm_horhos_rgad { get; set; }
            ///<summary>Numero Autorización Admisión solicitada a la EPS o Asegurador</summary>
            public String Adm_nroaut_rgad { get; set; }
            ///<summary>Secuencial Único de Contrato</summary>
            public String Cto_seccon_cont { get; set; }
            ///<summary>Numero de Contrato</summary>
            public String Cto_nrocon_cont { get; set; }
            ///<summary>Tipo Usuario segun regimen 1=Contributivo 2=Subsidiado y otros(Resol: 3374 RIPS)</summary>
            public String Sia_tipusu_regi { get; set; }
            ///<summary>Código de Eps o Asegurador según códigos asignados por la supersalud</summary>
            public String Sia_codeps_teps { get; set; }
            ///<summary>Edad Paciente al Momento de Admisión</summary>
            public int Sia_edapac_usua { get; set; }
            ///<summary>Unidad Medida Edad Paciente 1=Año 2=Mes 3=Día</summary>
            public String Sia_codmed_tmed { get; set; }
            ///<summary>Tipo Registro  de Atención: 1 = Admitidos 2=Ambulatoria</summary>
            public String Sia_regate_rgat { get; set; }
            ///<summary>Finalidad de la consulta:01=Atención del Parto 02=Atencion del Recien Nacido y demas  según Resolucion 3374 RIPS</summary>
            public String Sia_codfco_fcon { get; set; }
            ///<summary>Diagnostico de consulta según CIE-10</summary>
            public String Sia_coddia_tdia { get; set; }
            ///<summary>Tipo de diagnostico principal</summary>
            public String Sia_tipdxp_tdix { get; set; }
            ///<summary>Destino al salir: 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion</summary>
            public String Adm_dessal_regr { get; set; }
            ///<summary>Diagnostico relacionado 1 según CIE-10</summary>
            public String Sia_dixre1_tdia { get; set; }
            ///<summary>Diagnostico relacionado 2 según CIE-10</summary>
            public String Sia_dixre2_tdia { get; set; }
            ///<summary>Diagnostico relacionado 3 según CIE-10</summary>
            public String Sia_dixre3_tdia { get; set; }
            ///<summary>Primer apellido del usuario o paciente</summary>
            public String Sia_priape_usua { get; set; }
            ///<summary>Segundo apellido del usuario o paciente</summary>
            public String Sia_segape_usua { get; set; }
            ///<summary>Primer nombre del usuario o paciente</summary>
            public String Sia_prinom_usua { get; set; }
            ///<summary>Segundo nombre del usuario o paciente</summary>
            public String Sia_segnom_usua { get; set; }
            ///<summary>Fecha nacimiento del usuario o paciente</summary>
            public DateTime Sia_fecnac_usua { get; set; }
            ///<summary>Sexo del  usuario o paciente</summary>
            public String Sis_codsex_sexo { get; set; }
            ///<summary>Codigo Municipio según DANE</summary>
            public String Sis_codmun_muni { get; set; }
            ///<summary>Codigo  del departamento DANE</summary>
            public String Sis_coddep_dpto { get; set; }
            ///<summary>Zona de residencia según norma U=Urbana R= Rural</summary>
            public String Sis_zonres_tzon { get; set; }
            #endregion
        }
        #endregion
        #region tmpRipsCT: Estructura temporal Rips Archivo Control
        /// <summary>
        /// <para>Estructura temporal Rips Archivo Control</para>
        /// </summary>
        public class tmpRipsCT
        {
            #region Rips Control
            public String IPSCodigoPrestador { get; set; }
            public String FechaRemision { get; set; }
            public String NombreArchivo { get; set; }
            public int TotalRegistros { get; set; }
            // Parametros adicionales
            public String Descripcion { get; set; }
            public String ImagenJpg { get; set; }
            #endregion
        }
        #endregion
        //----------------------------------------------------------------------
        // FUNCIONES AUXILIARES
        //----------------------------------------------------------------------
        #region flgValidarDatos: Validar los datos antes de realiar los calculos
        /// <summary>
        /// Validar los datos antes de realiar los calculos
        /// </summary>
        public bool flgValidarDatos(decimal tdeDato1, decimal tdeDato2)
        {
            return tdeDato1 == 0 || tdeDato2 == 0 ? false : true;
        }
        #endregion
        #region fcrConvierteHora: Retorna horta militar con separador ajustado al formato Rips
        /// <summary>
        /// Retorna horta militar con separador ajustado al formato Rips
        /// </summary>
        public String fcrConvierteHora(String tdeHoraMilitar)
        {
            String lcrHoraMilitar = String.Empty;
            if (!String.IsNullOrWhiteSpace(tdeHoraMilitar))
            {

                lcrHoraMilitar = Funciones.fcrExtraerCompHora(tdeHoraMilitar, "HH", "24", gcrSeparadorDecimal) + ":" +
                                 Funciones.fcrExtraerCompHora(tdeHoraMilitar, "MM", "24", gcrSeparadorDecimal);
            }
            return lcrHoraMilitar;

        }
        #endregion
    }
}
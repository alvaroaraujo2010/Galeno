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
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;

namespace Estadisticas.Vista
{
    /// <summary>
    /// Interaction logic for EST_FcmGenerarPlanosRips.xaml 
    /// </summary>
    public partial class FcmGenerarPlanosRips : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoEdicionKey   = false;
        public bool llgModoEdicionValid = false;
        public bool llgObjetosCargados  = false;
        public bool glgVistaSeleccion   = false;
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public String gcrCtrF2TexBox;
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        Aplicacion oApp = Aplicacion.Instancia();
        DialogVistaErrores lobDlgLogs = null;
        public List<CrtForms.ListaComboBox> lstTipoFiltro;
        public List<CrtForms.ListaComboBox> lstTipoActividad;
        public EFctomaescontrato tmpContrato = null;
        // Varaibles de control proceso
        #region Variables Parametros
        public static EFsisparametroips lobPrmReg = SISValidarCodigo.fobRegBuscarSisparametroips();
        static String lcrPrmIdNombreArchivo     = String.Empty;
        static String lcrPrmIPSCodigoPrestador  = lobPrmReg.sis_codips_pips;
        static String lcrPrmIPSTipoNit          = "NI";
        static String lcrPrmIPSCodigoNit        = lobPrmReg.sis_nitips_pips;
        static String lcrPrmIPSNombre           = lobPrmReg.sis_razsoc_pips;
        static String lcrPrmTipoFiltro          = String.Empty;
        static String lcrPrmTipoActividad       = String.Empty;
        static String lcrPrmCodigoCuenta        = String.Empty;
        static String lcrPrmCodigoContrato      = String.Empty;
        static String lcrPrmCodigoEps           = String.Empty;
        static String lcrPrmRegimenSalud        = String.Empty;
        static String lcrPrmFechaRemision       = "30/07/2015";
        static String lcrPrmFechaInicioFiltro   = "01/07/2015";
        static String lcrPrmFechaFinFiltro      = "30/07/2015";
        static String lcrPrmRipsAuxiliares      = "2";
        static int lnuPrmContadorRipsSispro     = 0;
        static DateTime ldaPrmFechaInicioFiltro = Funciones.fdaConvertFecha("DMY", "/", "01/07/2015");
        static DateTime ldaPrmFechaFinFiltro    = Funciones.fdaConvertFecha("DMY", "/", "30/07/2015");
        static int lnuPrmValorCopagoAF = 0;
        static int lnuPrmValorComisionAF = 0;
        static int lnuPrmValorDescuenAF = 0;
        static int lnuPrmValorFacturaAF = 0;
        // Variables gestion cada archivo
        public int lnuTotalAC = 0;
        public int lnuTotalAP = 0;
        public int lnuTotalAM = 0;
        public int lnuTotalAT = 0;
        public String lcrTextoAC, lcrTextoAP, lcrTextoAM, lcrTextoAT;
        // Control para generar varios registros segun cantidad del servicio
        public String gcrGenVariosReg_SINO_AC = Funciones.fcrLeerConfigVarSistema("EST-RIPS-GENERAR-ARCHIVO-AC", "1");
        public String gcrGenVariosReg_SINO_AP = Funciones.fcrLeerConfigVarSistema("EST-RIPS-GENERAR-ARCHIVO-AP", "1");
        #endregion
        // Variables para gestion exportar
        #region Variables Gestion Planos
        public String gcrExportarArchivoRuta = String.Empty;
        public String gcrNombreArchivoCT = String.Empty;
        public String gcrNombreArchivoAF = String.Empty;
        public String gcrNombreArchivoAD = String.Empty;
        public String gcrNombreArchivoAC = String.Empty;
        public String gcrNombreArchivoAP = String.Empty;
        public String gcrNombreArchivoAM = String.Empty;
        public String gcrNombreArchivoAT = String.Empty;
        public String gcrNombreArchivoAN = String.Empty;
        public String gcrNombreArchivoAH = String.Empty;
        public String gcrNombreArchivoAU = String.Empty;
        public String gcrNombreArchivoUS = String.Empty;
        //- Varialbes para datos de texto
        public String gcrTextoArchivoCT = String.Empty;
        public String gcrTextoArchivoAF = String.Empty;
        public String gcrTextoArchivoAD = String.Empty;
        public String gcrTextoArchivoAC = String.Empty;
        public String gcrTextoArchivoAP = String.Empty;
        public String gcrTextoArchivoAM = String.Empty;
        public String gcrTextoArchivoAT = String.Empty;
        public String gcrTextoArchivoAN = String.Empty;
        public String gcrTextoArchivoAH = String.Empty;
        public String gcrTextoArchivoAU = String.Empty;
        public String gcrTextoArchivoUS = String.Empty;
        #endregion
        // Temporales de Rips 
        #region Variables gestion  tablas temporales
        public static tmpAdmision tobRegAdmision = null;
        public static tmpRipsAH tobRegHospitaliz = null;
        public List<tmpAdmision> tmpRipsAdmision = null;
        public List<tmpRipsAH> tmpRipsHospitaliz = null;
        public List<tmpRipsAU> tmpRipsUrgencias  = null;
        public List<tmpRipsAN> tmpRipsNacimientos = null;
        public List<tmpAdmision> tmpRipsUsuarios = null;
        public List<tmpRipsCT> tmpRipsArchivoControl = null;
        public List<tmpRipsAF> tmpRipsMaestroFact = null;
        public List<tmpRipsAD> tmpRipsDesAgrupada = null;
        public List<EFfcmmaedetallfac> tmpRipsDetallesFact = null;
        public List<TmpListaSeleccion> lstListSelFiltrFact = null;
        #endregion
        #endregion

        public FcmGenerarPlanosRips()
        {
            InitializeComponent();

            llgObjetosCargados = true;
            IniciarComboBox();

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);

            this.dpkFechaRemision.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkFiltroFechaInicio.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkFiltroFechaFin.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkFechaCuenta.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);

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

                case "txtG1Sia_tipusu_regi":
                    this.txtG1Sia_tipusu_regi.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_secreg_mfcb":
                    this.txtFacturaCuenta.Text = String.Empty;
                    this.txtG1Fcm_secreg_mfcb.Text = tcrCodigo;
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
        #region SIA_TIPUSU_REGI : Lista de Régimenes en Salud
        private void txtG1Sia_tipusu_regi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_tipusu_regi_Browser();
            }
        }
        private void cmdG1Sia_tipusu_regi_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_tipusu_regi_Browser();
        }
        private void txtG1Sia_tipusu_regi_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAREGIMENSALUD", "", "Lista de Régimenes en Salud...");
            gcrCtrF2TexBox = "txtG1Sia_tipusu_regi";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_SECREG_MFCB : Maestro de facturas - Cuentas de cobro facturación
        private void txtG1Fcm_secreg_mfcb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_secreg_mfcb_Browser();
            }
        }
        private void cmdG1Fcm_secreg_mfcb_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_secreg_mfcb_Browser();
        }
        private void txtG1Fcm_secreg_mfcb_Browser()
        {
            Browser01Ex frbro = new Browser01Ex("FCM", "FCMCUENTACOBRMS", "ACTIVAS", "Cuentas de cobro facturación...");
            gcrCtrF2TexBox = "txtG1Fcm_secreg_mfcb";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
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
            if (!Directory.Exists(oApp.gcrAppPathInicioTempReportes + @"\Rips\"))
            {
                Directory.CreateDirectory(oApp.gcrAppPathInicioTempReportes + @"\Rips");
            }
            this.txtRutaDestinoPlanos.Text = oApp.gcrAppPathInicioTempReportes + @"\Rips\";
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
                    case "dpkFechaRemision":
                        this.txtFechaRemision.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, this.txtFechaRemision);
                        break;

                    case "dpkFiltroFechaInicio":
                        this.txtFiltroFechaInicio.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, this.txtFiltroFechaInicio);
                        break;

                    case "dpkFiltroFechaFin":
                        this.txtFiltroFechaFin.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, this.txtFiltroFechaFin);
                        break;

                    case "dpkFechaCuenta":
                        this.txtFechaCuenta.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, this.txtFechaCuenta);
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
                            case "txtFechaRemision":
                                this.dpkFechaRemision.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtFiltroFechaInicio":
                                this.dpkFiltroFechaInicio.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtFiltroFechaFin":
                                this.dpkFiltroFechaFin.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtFechaCuenta":
                                this.dpkFechaCuenta.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
                        case "cboTipoFiltro":
                            this.txtTipoFiltro.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtTipoFiltro.Text, ",", lobList.ListaValoresSel) - 1;
                            flgActivarObjetosVista(this.txtTipoFiltro.Text);
                            break;

                        case "cboTipoActividad":
                            this.txtTipoActividad.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtTipoActividad.Text, ",", lobList.ListaValoresSel) - 1;
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
        // MARCAR NUMERO DE CUENTA COMO INCLUIDA
        //-------------------------------------------------
        #region fcvSelectCheckBox: Incluir o excluir numero de cuenta en Rips
        /// <summary>
        /// Incluir o excluir numero de cuenta en Rips
        /// </summary>
        private void fcvSelectCheckBox(object sender, RoutedEventArgs e)
        {
            this.txtFacturaCuenta.Text  = this.chkIncNumCuentaEnPlanos.IsChecked == false ? String.Empty : this.txtFacturaCuenta.Text;
            this.txtFechaCuenta.Text    = this.chkIncNumCuentaEnPlanos.IsChecked == false ? String.Empty : this.txtFechaCuenta.Text;

            // Activar valor capitado
            this.txtValorCapitado.IsEnabled     = this.chkIncValorCapitado.IsChecked == true ? true : false;
            this.txtValorCapitado.Text          = this.chkIncValorCapitado.IsChecked == true ? this.txtValorCapitado.Text : String.Empty;

            flgValidacion();
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
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_tipusu_regi"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFechaRemision"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFiltroFechaInicio"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFiltroFechaFin"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFacturaCuenta"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFechaCuenta"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Fcm_secreg_mfcb"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtValorCapitado"))) { lnuCont++; }

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
                    case "txtG1Cto_seccon_cont":
                        #region Validacion
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (this.txtTipoFiltro.Text == "1")
                        {
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
                        }
                        fcvSetColorValidacion(this.txtG1Cto_seccon_cont, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Sia_codeps_teps":
                        #region Validacion
                        lcrNombreCampo = "Código Empresa (EPS)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (this.txtTipoFiltro.Text == "1")
                        {
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
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codeps_teps, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Sia_tipusu_regi":
                        #region Validacion
                        lcrNombreCampo = "Regimen Salud";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (this.txtTipoFiltro.Text == "1")
                        {
                            if (!String.IsNullOrWhiteSpace(this.txtG1Sia_tipusu_regi.Text))
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiaregimensalud(this.txtG1Sia_tipusu_regi.Text);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipusu_regi))
                                {
                                    this.txtG1Sia_destip_regi.Text = tmp.sia_destip_regi;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                            else
                            {
                                this.txtG1Sia_destip_regi.Text = String.Empty;
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sia_tipusu_regi, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFechaRemision":
                        #region Validación
                        lcrNombreCampo = "Fecha remision archivos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtFechaRemision.Text, lcrNombreCampo);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtFiltroFechaFin.Text, lcrNombreCampo)))
                            {
                                if (!Funciones.flgValidarRangoFecha(this.txtFiltroFechaFin.Text, this.txtFechaRemision.Text))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": debe ser igual o mayor que fecha fin del periodo";
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtFechaRemision, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFiltroFechaInicio":
                        #region Validación
                        lcrNombreCampo = "Fecha inicio periodo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (this.txtTipoFiltro.Text == "1")
                        {
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
                        }
                        fcvSetColorValidacion(this.txtFiltroFechaInicio, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFiltroFechaFin":
                        #region Validación
                        lcrNombreCampo = "Fecha final perido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (this.txtTipoFiltro.Text == "1")
                        {
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
                        }
                        fcvSetColorValidacion(this.txtFiltroFechaFin, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFacturaCuenta":
                        #region Validacion
                        lcrNombreCampo = "Numero de factura para cuenta de cobro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (!String.IsNullOrWhiteSpace(this.txtFacturaCuenta.Text))
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(this.txtFacturaCuenta.Text, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no permitidos";
                            }
                        }
                        else
                        {
                            if (this.chkIncNumCuentaEnPlanos.IsChecked == true)
                            {
                                lcrValorReturn = lcrNombreCampo + ": debe contener un numero o dato valido";
                            }
                        }
                        fcvSetColorValidacion(this.txtFacturaCuenta, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFechaCuenta":
                        #region Validación
                        lcrNombreCampo = "Fecha para numero de la cuenta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (this.chkIncNumCuentaEnPlanos.IsChecked == true)
                        {
                            lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtFechaCuenta.Text, lcrNombreCampo);
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtFiltroFechaFin.Text, lcrNombreCampo)))
                                {
                                    if (!Funciones.flgValidarRangoFecha(this.txtFiltroFechaFin.Text, this.txtFechaCuenta.Text))
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": debe ser igual o mayor que fecha fin del periodo";
                                    }
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtFechaCuenta, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Fcm_secreg_mfcb":
                        #region FCM_SECREG_MFCB: Código cuenta cobro
                        lcrNombreCampo = "Código cuenta cobro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (this.txtTipoFiltro.Text == "2")
                        {
                            if (String.IsNullOrWhiteSpace(this.txtG1Fcm_secreg_mfcb.Text))
                            {
                                lcrValorReturn = lcrNombreCampo + ": es requerido";
                            }
                            else
                            {
                                var tmp = FCMValidarCodigo.fobRegBuscarFcmcuentacobrms(this.txtG1Fcm_secreg_mfcb.Text);
                                if (tmp != null)
                                {
                                    this.txtFacturaCuenta.Text = String.IsNullOrWhiteSpace(this.txtFacturaCuenta.Text) ? tmp.fcm_numfac_mfac : this.txtFacturaCuenta.Text;
                                    this.txtG1Fcm_descue_mfcb.Text = tmp.fcm_descue_mfcb;
                                    this.txtFiltroFechaInicio.Text = Funciones.fcrConvertFecha((DateTime)tmp.sia_fecini_mfcb);
                                    this.txtFiltroFechaFin.Text = Funciones.fcrConvertFecha((DateTime)tmp.sia_fecfin_mfcb);
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                    this.txtG1Fcm_descue_mfcb.Text = String.Empty;
                                    this.txtFiltroFechaInicio.Text = String.Empty;
                                    this.txtFiltroFechaFin.Text = String.Empty;
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Fcm_secreg_mfcb, lcrValorReturn);
                        break;
                        #endregion

                    case "txtValorCapitado":
                        #region txtValorCapitado: Valor capitado
                        if (this.chkIncValorCapitado.IsChecked == true)
                        {
                            if (String.IsNullOrWhiteSpace(this.txtValorCapitado.Text))
                            {
                                lcrValorReturn = "Valor capitado: debe ser mayor que cero";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(this.txtValorCapitado.Text, "0123456789"))
                                {
                                    lcrValorReturn = "Valor capitado: Contiene caracteres que no son numeros";
                                }
                            }
                        }
                        fcvSetColorValidacion(this.txtValorCapitado, lcrValorReturn);
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

            this.txtG1Fcm_secreg_mfcb.IsEnabled = false;
            this.cmdCuentaCobro.IsEnabled = false;

            this.txtG1Cto_seccon_cont.IsEnabled = true;
            this.txtG1Sia_codeps_teps.IsEnabled = true;
            this.txtG1Sia_tipusu_regi.IsEnabled = true;
            this.txtFiltroFechaInicio.IsEnabled = true;
            this.txtFiltroFechaFin.IsEnabled = true;
            this.dpkFiltroFechaInicio.IsEnabled = true;
            this.dpkFiltroFechaFin.IsEnabled = true;
            this.cmdG1Contrato.IsEnabled = true;
            this.cmdG1CodigoEps.IsEnabled = true;
            this.cmdG1RegimenSalud.IsEnabled = true;
            
            // Filtro normal
            if (tcrTipoFiltro=="1")
            {
                this.txtG1Fcm_secreg_mfcb.Text = String.Empty;
                this.txtG1Fcm_descue_mfcb.Text = String.Empty;
            }
            else // Filtro por numero de cuenta
            {
                this.txtG1Fcm_secreg_mfcb.IsEnabled = true;
                this.cmdCuentaCobro.IsEnabled = true;

                this.txtG1Cto_seccon_cont.IsEnabled = false;
                this.txtG1Sia_codeps_teps.IsEnabled = false;
                this.txtG1Sia_tipusu_regi.IsEnabled = false;
                this.txtFiltroFechaInicio.IsEnabled = false;
                this.txtFiltroFechaFin.IsEnabled = false;
                this.dpkFiltroFechaInicio.IsEnabled = false;
                this.dpkFiltroFechaFin.IsEnabled = false;
                this.cmdG1Contrato.IsEnabled = false;
                this.cmdG1CodigoEps.IsEnabled = false;
                this.cmdG1RegimenSalud.IsEnabled = false;

                this.txtG1Cto_seccon_cont.Text = String.Empty;
                this.txtG1Cto_nrocon_cont.Text = String.Empty;
                this.txtG1Cto_descon_cont.Text = String.Empty;
                this.txtG1Sia_codeps_teps.Text = String.Empty;
                this.txtG1Sia_deseps_teps.Text = String.Empty;
                this.txtG1Sia_tipusu_regi.Text = String.Empty;
                this.txtG1Sia_destip_regi.Text = String.Empty;
                this.txtFiltroFechaInicio.Text = String.Empty;
                this.txtFiltroFechaFin.Text = String.Empty;
            }

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
                // TIPO FILTRO RIPS
                //-------------------------------------------------
                #region Tipo Filtro 
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Generar Rips desde filtro,Generar Rips para cuenta de cobro";
                lstTipoFiltro = new List<CrtForms.ListaComboBox>();
                lstTipoFiltro = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion, "1");
                //- Asignar al control
                this.cboTipoFiltro.ItemsSource = lstTipoFiltro;
                this.cboTipoFiltro.SelectedIndex = Convert.ToInt32(lstTipoFiltro[0].IdIndice);
                #endregion
                //-------------------------------------------------
                // TIPO TIPO ACTIVIDAD
                //-------------------------------------------------
                #region Tipo actividad
                string lcrG12Seleccion = "1,2,3,4";
                string lcrG12Descripcion = "Activiades asistenciales,Activiades de Promoción y Prevención,Todas las actividades,Informe Rips formato SISPRO";
                lstTipoFiltro = new List<CrtForms.ListaComboBox>();
                lstTipoFiltro = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion, "1");
                //- Asignar al control
                this.cboTipoActividad.ItemsSource = lstTipoFiltro;
                this.cboTipoActividad.SelectedIndex = Convert.ToInt32(lstTipoFiltro[2].IdIndice);
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
        //- Exportar a plano procesos generales
        #region fcvExportarForamtoPlano: Exportar a plano opcion desde menu
        private void fcvExportarForamtoPlano(object sender, RoutedEventArgs e)
        {
            lstListSelFiltrFact = null; // Lista vacia por defecto filtro avanzado
            var llgContinuar = true;

            if (this.chkFlitroAvanzado.IsChecked == true && this.txtTipoFiltro.Text == "1") // "1" es filtro normal (no es desde cuenta de cobro)
            {
                lstListSelFiltrFact = FCMValidarCodigo.flsBrowserSeleccionFacturasGeneral(this, this.txtFiltroFechaInicio.Text, this.txtFiltroFechaFin.Text);
                llgContinuar = lstListSelFiltrFact == null ? false : true;
            }

            if (llgContinuar == true)
            {
                fcvLimpiarTextoPlanos();
                fcvCargarParametros();
                fcvEliminarArchivosPlanos();
                flgExportarForamtoPlano();
            }
            else
            {
                MessageBox.Show("Debe seleccionar algo en el filtro avanzado.");
            }
        }
        #endregion
        #region fcvCargarParametros: Cargar parametros para generar de planos
        /// <summary>
        /// Cargar parametros para generar de planos
        /// </summary>
        private void fcvCargarParametros()
        {
            #region Cargar datos en variables
            lcrPrmTipoFiltro        = this.txtTipoFiltro.Text;
            lcrPrmTipoActividad     = this.txtTipoActividad.Text;
            lcrPrmCodigoCuenta      = this.txtG1Fcm_secreg_mfcb.Text;
            lcrPrmCodigoContrato    = this.txtG1Cto_seccon_cont.Text.Trim();
            lcrPrmCodigoEps         = this.txtG1Sia_codeps_teps.Text;
            lcrPrmRegimenSalud      = this.txtG1Sia_tipusu_regi.Text.Trim();
            lcrPrmFechaRemision     = this.txtFechaRemision.Text.Trim();
            lcrPrmFechaInicioFiltro = this.txtFiltroFechaInicio.Text.Trim();
            lcrPrmFechaFinFiltro    = this.txtFiltroFechaFin.Text.Trim();
            ldaPrmFechaInicioFiltro = Funciones.fdaConvertFecha("DMY", "/", this.txtFiltroFechaInicio.Text);
            ldaPrmFechaFinFiltro    = Funciones.fdaConvertFecha("DMY", "/", this.txtFiltroFechaFin.Text);
            gcrExportarArchivoRuta  = this.txtRutaDestinoPlanos.Text.Trim();
            lcrPrmRipsAuxiliares    = this.txtRips.Text == "A" ? "1" : "2";

            // Cambiar el nombre de archivos planos segun numero de cuenta
            if (this.chkIncNumCuentaEnPlanos.IsChecked == true && this.chkCuentaEnNomPlano.IsChecked == true)
            {
                lcrPrmIdNombreArchivo = this.txtFacturaCuenta.Text.Trim();
            }
            else
            {
                lcrPrmIdNombreArchivo   = this.txtFiltroFechaInicio.Text.Substring(3, 2) + this.txtFiltroFechaInicio.Text.Substring(6, 4);
            }

            // Nombre de los archivos planos \n\t
            gcrNombreArchivoCT = "CT" + lcrPrmIdNombreArchivo;
            gcrNombreArchivoAF = "AF" + lcrPrmIdNombreArchivo;
            gcrNombreArchivoAD = "AD" + lcrPrmIdNombreArchivo;
            gcrNombreArchivoAC = "AC" + lcrPrmIdNombreArchivo;
            gcrNombreArchivoAP = "AP" + lcrPrmIdNombreArchivo;
            gcrNombreArchivoAM = "AM" + lcrPrmIdNombreArchivo;
            gcrNombreArchivoAT = "AT" + lcrPrmIdNombreArchivo;
            gcrNombreArchivoAN = "AN" + lcrPrmIdNombreArchivo;
            gcrNombreArchivoAH = "AH" + lcrPrmIdNombreArchivo;
            gcrNombreArchivoAU = "AU" + lcrPrmIdNombreArchivo;
            gcrNombreArchivoUS = "US" + lcrPrmIdNombreArchivo;
            #endregion
        }
        #endregion
        #region fcvLimpiarTextoPlanos: Limpiar las variables para generar texto Planos Rips
        /// <summary>
        /// <para>Limpiar las variables para generar texto Planos Rips</para>
        /// </summary>
        public void fcvLimpiarTextoPlanos()
        {
            #region Variables Gestion Planos
            gcrExportarArchivoRuta = String.Empty;
            gcrTextoArchivoCT = String.Empty;
            gcrTextoArchivoAF = String.Empty;
            gcrTextoArchivoAD = String.Empty;
            gcrTextoArchivoAC = String.Empty;
            gcrTextoArchivoAP = String.Empty;
            gcrTextoArchivoAM = String.Empty;
            gcrTextoArchivoAT = String.Empty;
            gcrTextoArchivoAN = String.Empty;
            gcrTextoArchivoAH = String.Empty;
            gcrTextoArchivoAU = String.Empty;
            gcrTextoArchivoUS = String.Empty;
            #endregion
            tobRegAdmision          = null;
            tobRegHospitaliz        = null;
            tmpRipsAdmision         = new List<tmpAdmision>();
            tmpRipsHospitaliz       = new List<tmpRipsAH>();
            tmpRipsUrgencias        = new List<tmpRipsAU>();
            tmpRipsUsuarios         = new List<tmpAdmision>();
            tmpRipsNacimientos      = new List<tmpRipsAN>();
            tmpRipsArchivoControl   = new List<tmpRipsCT>();
            tmpRipsMaestroFact      = new List<tmpRipsAF>();
            tmpRipsDesAgrupada      = new List<tmpRipsAD>();
            tmpRipsDetallesFact     = new List<EFfcmmaedetallfac>();
        }
        #endregion
        #region fcvEliminarArchivosPlanos: Eliminar archivos planos pre-existentes
        /// <summary>
        /// <para>Eliminar archivos planos pre-existentes</para>
        /// </summary>
        public void fcvEliminarArchivosPlanos()
        {
            #region Eliminar archivos planos pre-existentes
            var lcrArchivo = String.Empty;
            // Control
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoCT + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Transacciones 
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAF + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Descripcion agrupada
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAD + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Consultas
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAC + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Procedimientos
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAP + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Medicamentos 
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAM + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Otros servicios 
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAT + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Hospitalizaciones
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAH + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Urgencias 
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAU + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Nacimientos
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAN + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            // Usuarios
            lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoUS + ".TXT";
            if (File.Exists(@lcrArchivo))
            {
                System.IO.File.Delete(@lcrArchivo);
            }
            #endregion
        }
        #endregion
        #region flgExportarForamtoPlano: Exportar datos a archivos planos
        /// <summary>
        /// <para>Exportar datos a Archivo Planos Rips</para>
        /// </summary>
        public bool flgExportarForamtoPlano()
        {
            var llgReturn = false;
            var lcrArchivo = String.Empty;
            lnuPrmContadorRipsSispro = 0;

            if (!string.IsNullOrEmpty(gcrExportarArchivoRuta))
            {
                llgReturn = true;

                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Exportando plano de datos...", "CENTRO");
                lobDlgAdd.Show();

                //------------------------------------------------
                // GENERAR ARCHIVOS PLANOS
                //------------------------------------------------
                // Segun el tipo de informe
                if (lcrPrmTipoActividad != "4")
                {
                    fcvLeerTextoRipsMastroFacturas();
                    fcvLeerTextoRipsDetallesFacturas();
                    fcvLeerTextoRipsMaestroFacturasParaAF();
                    fcvLeerTextoRipsHospitalizacion();
                    fcvLeerTextoRipsNacimientos();
                    fcvLeerTextoRipsUrgencias();
                    fcvLeerTextoRipsUsuarios();
                    fcvLeerTextoRipsDesAgrupada();
                    fcvLeerTextoRipsArchivoControl();
                    fcvExportarForamtoPlanoGen();
                }
                else
                { 
                    // aqui hay que concatenar los textos de todos los archivos
                    fcvLeerTextoRipsMastroFacturas();
                    // ORDEN SEGUN RIPS SISPRO
                    fcvLeerTextoRipsUsuarios();
                    fcvLeerTextoRipsDetallesFacturas("AC");
                    fcvLeerTextoRipsDetallesFacturas("AP");
                    fcvLeerTextoRipsUrgencias();
                    fcvLeerTextoRipsHospitalizacion();
                    fcvLeerTextoRipsNacimientos();
                    //fcvLeerTextoRipsDetallesFacturas("AM");
                    fcvLeerTextoRipsDetallesFacturas("AT");
                    fcvLeerTextoRipsMaestroFacturasParaAF();
                    fcvExportarForamtoPlanoGenSispro();
                }
                // Cerrar vista ventana de espera
                lobDlgAdd.Close();

                MessageBox.Show("Proceso finalizado con éxito!!");
            }
            return llgReturn;
        }
        #endregion
        #region fcvExportarForamtoPlanoGen: Generar cada archivos plano
        /// <summary>
        /// <para>Generar cada archivos planos</para>
        /// </summary>
        public void fcvExportarForamtoPlanoGen()
        {
            var lcrArchivo = String.Empty;

            if (!string.IsNullOrEmpty(gcrExportarArchivoRuta))
            {
                #region Generar archivos en la ruta destino
                // Agregar Datos de Rips Control   -- >  Encoding.UTF8
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoCT))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoCT + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoCT, Encoding.Default);
                }
                // Agregar Datos de Rips transacciones
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAF))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAF + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoAF, Encoding.Default);
                }
                // Agregar Datos de Rips Descripcion agrupada
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAD))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAD + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoAD, Encoding.Default);
                }
                // Agregar Datos de Rips consulta
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAC))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAC + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoAC, Encoding.Default);
                }
                // Agregar Datos de Rips Procedimientos
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAP))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAP + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoAP, Encoding.Default);
                    //System.IO.File.Delete(
                }
                // Agregar Datos de Rips Medicamentos
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAM))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAM + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoAM, Encoding.Default);
                }
                // Agregar Datos de Rips otros servicios
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAT))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAT + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoAT, Encoding.Default);
                }
                // Agregar Datos de Rips Hospitalizacion
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAH))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAH + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoAH, Encoding.Default);
                }
                // Agregar Datos de Rips Urgencias
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAU))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAU + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoAU, Encoding.Default);
                }
                // Agregar Datos de Rips Nacimientos
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAN))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoAN + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoAN, Encoding.Default);
                }
                // Agregar Datos de Rips Usuarios atendidos
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoUS))
                {
                    lcrArchivo = gcrExportarArchivoRuta + gcrNombreArchivoUS + ".TXT";
                    System.IO.File.WriteAllText(lcrArchivo, gcrTextoArchivoUS, Encoding.Default);
                }
                #endregion
            }
        }
        #endregion
        #region fcvExportarForamtoPlanoGenSispro: Generar cada archivos plano SISPRO
        /// <summary>
        /// <para>Generar archivo plano RIPS SISPRO</para>
        /// </summary>
        public void fcvExportarForamtoPlanoGenSispro()
        {
            var lcrArchivo = String.Empty;

            if (!string.IsNullOrEmpty(gcrExportarArchivoRuta))
            {
                #region Generar archivos en la ruta destino
                // Agregar Datos de Rips Control   -- >  Encoding.UTF8
                lcrArchivo = "1,REGISTRO DE CONTROL," + lnuPrmContadorRipsSispro.ToString().Trim();

                // Agregar Datos de Rips Usuarios atendidos
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoUS))
                {
                    lcrArchivo = lcrArchivo + "\r\n" + gcrTextoArchivoUS;
                }
                // Agregar Datos de Rips consulta
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAC))
                {
                    lcrArchivo = lcrArchivo + "\r\n" + gcrTextoArchivoAC;
                }
                // Agregar Datos de Rips Procedimientos
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAP))
                {
                    lcrArchivo = lcrArchivo + "\r\n" + gcrTextoArchivoAP;
                }
                // Agregar Datos de Rips Urgencias
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAU))
                {
                    lcrArchivo = lcrArchivo + "\r\n" + gcrTextoArchivoAU;
                }
                // Agregar Datos de Rips Hospitalizacion
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAH))
                {
                    lcrArchivo = lcrArchivo + "\r\n" + gcrTextoArchivoAH;
                }
                // Agregar Datos de Rips Nacimientos
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAN))
                {
                    lcrArchivo = lcrArchivo + "\r\n" + gcrTextoArchivoAN;
                }
                // Agregar Datos de Rips Medicamentos
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAM))
                {
                    lcrArchivo = lcrArchivo + "\r\n" + gcrTextoArchivoAM;
                }
                // Agregar Datos de Rips otros servicios
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAT))
                {
                    lcrArchivo = lcrArchivo + "\r\n" + gcrTextoArchivoAT;
                }
                // Agregar Datos de Rips transacciones
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAF))
                {
                    lcrArchivo = lcrArchivo + "\r\n" + gcrTextoArchivoAF;
                }
                // Generar el archivo plano
                if (!String.IsNullOrWhiteSpace(lcrArchivo))
                {
                    var lcrPlano = gcrExportarArchivoRuta + "RIPS-SISPRO.TXT";
                    System.IO.File.WriteAllText(lcrPlano, lcrArchivo, Encoding.Default);
                }
                #endregion
            }
        }
        #endregion
        //- Lectura de temporales para generar textos de archivos
        #region fcvLeerTextoRipsArchivoControl: Generar el archivo de control Rips
        /// <summary>
        /// <para>Generar el archivo de control Rips</para>
        /// </summary>
        public void fcvLeerTextoRipsArchivoControl()
        {
            String lcrTextoCT = String.Empty;
            var lcrUri = "/Sistema;component/Imagenes/";
            this.stkHistorial.Children.Clear();

            if (tmpRipsArchivoControl != null)
            {

                foreach (var lobReg in tmpRipsArchivoControl)
                {
                    lcrTextoCT = String.Empty;
                    lcrTextoCT = fcrLeerTextoRegistroRipsCT(lobReg);
                    lcrTextoCT = !String.IsNullOrWhiteSpace(gcrTextoArchivoCT) ? "\r\n" + lcrTextoCT : lcrTextoCT;
                    gcrTextoArchivoCT += lcrTextoCT;

                    //- Generar el registro vista 
                    var lobRegistro = new FcmControlGenPlanosRips();

                    lobRegistro.txtDescripArchivo.Text = lobReg.Descripcion;
                    lobRegistro.txtNombreArchivo.Text = lobReg.NombreArchivo;
                    lobRegistro.txtTotalRegistros.Text = lobReg.TotalRegistros.ToString().Trim();
                    lobRegistro.txtFechaPeriodoIni.Text = this.txtFiltroFechaInicio.Text;
                    lobRegistro.txtFechaPeriodoFin.Text = this.txtFiltroFechaFin.Text;
                    lobRegistro.imgArchivo.Source = new BitmapImage(new Uri(lcrUri + lobReg.ImagenJpg, UriKind.RelativeOrAbsolute));

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
        #region fcvLeerTextoRipsMastroFacturas: Leer Datos maestro facturas AF y registros para AH AN US AU
        /// <summary>
        /// <para>Leer Datos maestro facturas AF y registros para AH AN US AU </para>
        /// </summary>
        public void fcvLeerTextoRipsMastroFacturas()
        {
            //int lnuTotalAF = 0;
            String lcrTextoAF = String.Empty;
            var llgSiCumpleFiltro = true;

            #region Acciones segun Tipo filtro
            if (lcrPrmTipoFiltro == "2") // Filtro cuenta de cobro
            {
                tmpRipsMaestroFact = flsFiltroTempMaestroFactCuentas();
            }
            else
            {
                if (lcrPrmRipsAuxiliares == "2") // Rips normal
                {
                    // Desde filtro nromal o Formato SISPRO
                    if (lcrPrmTipoActividad == "3" || lcrPrmTipoActividad == "4")
                    {
                        // Todas las actividades
                        tmpRipsMaestroFact = flsFiltroTempMaestroFacturas();
                    }
                    else
                    {
                        // Separado por asistencial y pyp
                        tmpRipsMaestroFact = flsFiltroTempMaestroFacturaAsistPyP();
                    }
                }
                else
                { 
                    // Variable en "1" Rips Auxiliar parametro oculto
                    tmpRipsMaestroFact = flsFiltroTempMaestroFacturas();
                }
            }
            #endregion

            if (tmpRipsMaestroFact != null && tmpRipsMaestroFact.Count > 0)
            {
                foreach (var lobReg in tmpRipsMaestroFact)
                {
                    lobReg.Marca = "NO";
                    llgSiCumpleFiltro = flgSiFiltroAvanzado(lobReg.Cto_seccon_cont, lobReg.Sia_codeps_teps);

                    if (llgSiCumpleFiltro == true)
                    {
                        lobReg.Marca = "SI";
                        // leer datos Para rips de Usuario se genera temporal: tobRegAdmision
                        fcvLeerRipsArchivoUsuarioAdm(lobReg);

                        // leer Datos par hospitalizacion/Urgencias/nacimientos
                        if (tobRegAdmision != null)
                        {
                            lobReg.Sia_tipide_tide = tobRegAdmision.Sia_tipide_tide;
                            lobReg.Sia_nroide_usua = tobRegAdmision.Sia_nroide_usua;
                            lobReg.Adm_nroaut_rgad = tobRegAdmision.Adm_nroaut_rgad;

                            if (tobRegAdmision.Cto_seccon_cont == lobReg.Cto_seccon_cont)
                            {
                                fcrLeerRipsArchivoHospitalizacion(lobReg);
                                fcrLeerRipsArchivoNacimientos(lobReg);
                                fcrLeerRipsArchivoUrgencias(lobReg);
                            }
                        }
                    }
                }
                tmpRipsMaestroFact = (from tmp in tmpRipsMaestroFact where tmp.Marca == "SI" select tmp).ToList();
            }
        }
        #endregion
        #region fcvLeerTextoRipsMaestroFacturasParaAF: Generar texto facturas para archivo AF
        /// <summary>
        /// <para>Generar texto facturas para archivo AF</para>
        /// </summary>
        public void fcvLeerTextoRipsMaestroFacturasParaAF()
        {
            String lcrTextoAF = String.Empty;
            int lnuTotalAF = 0;

            #region Limpiar sumatoria facturas 
            if (tmpRipsMaestroFact != null && tmpRipsMaestroFact.Count > 0)
            {
                lnuPrmValorCopagoAF = 0;
                lnuPrmValorComisionAF = 0;
                lnuPrmValorDescuenAF = 0;
                lnuPrmValorFacturaAF = 0;

                // Recalcular segun detalles
                #region Recalcular segun detalles
                foreach (var lobReg in tmpRipsMaestroFact)
                {
                    lobReg.ValorCopago = 0;
                    lobReg.ValorComision = 0;
                    lobReg.ValorDescuen = 0;
                    lobReg.ValorFactura = 0;
                }
                if (tmpRipsDetallesFact != null)
                {
                    foreach (var lobReg in tmpRipsDetallesFact)
                    {
                        var lobRegFac = tmpRipsMaestroFact.FirstOrDefault(x => x.Fcm_numfac_mfac == lobReg.fcm_numfac_mfac);
                        if (lobRegFac != null)
                        {
                            // Sumatoria de valores por si se necesitan
                            if (lobReg.sia_codrip_trip =="01") // Solo copagos de consultas, el resto no se refleja
                            {
                                lobRegFac.ValorCopago += (int)lobReg.fcm_valcpa_dfac + (int)lobReg.fcm_valcmo_dfac;
                            }
                            lobRegFac.ValorComision += (int)lobReg.fcm_valcom_dfac;
                            lobRegFac.ValorDescuen += (int)lobReg.fcm_valdes_dfac;
                            lobRegFac.ValorFactura += (int)lobReg.fcm_valfac_dfac;
                        }
                    }
                }
                #endregion
                // Generar Registr texto archivo plano
                #region Generar Registr texto archivo plano
                foreach (var lobReg in tmpRipsMaestroFact)
                {
                    if (lobReg.ValorFactura > 0)
                    {
                        lnuPrmValorCopagoAF += (int)lobReg.ValorCopago;
                        //lnuPrmValorCmoderaAF += (int)lobReg.ValorCmodera;
                        lnuPrmValorDescuenAF += (int)lobReg.ValorDescuen;
                        lnuPrmValorFacturaAF += (int)lobReg.ValorFactura;

                        lcrTextoAF = String.Empty;
                        lnuTotalAF++;
                        lcrTextoAF = fcrLeerTextoRegistroRipsAF(lobReg);
                        lcrTextoAF = !String.IsNullOrWhiteSpace(gcrTextoArchivoAF) ? "\r\n" + lcrTextoAF : lcrTextoAF;
                        gcrTextoArchivoAF += lcrTextoAF;
                    }
                }
                #endregion
                // Cuando se incluye numero de cuenta en Rips, solo s genera un registro AF
                #region Numero de cuenta en Rips
                if (this.chkIncNumCuentaEnPlanos.IsChecked == true)
                {
                    lnuTotalAF = 1;
                    var lobReg = new tmpRipsAF();

                    lobReg.IPSCodigoPrestador   = lcrPrmIPSCodigoPrestador;
                    lobReg.IPSNombreEmpresa     = lcrPrmIPSNombre;
                    lobReg.IPSTipoNit           = lcrPrmIPSTipoNit;
                    lobReg.IPSCodigoNit         = lcrPrmIPSCodigoNit;
                    lobReg.Fcm_numfac_mfac      = this.txtFacturaCuenta.Text;
                    lobReg.Fcm_fecfac_mfac      = Convert.ToDateTime(this.txtFechaCuenta.Text);
                    lobReg.FechaIniPeriodo      = lcrPrmFechaInicioFiltro;
                    lobReg.FechaFinPeriodo      = lcrPrmFechaFinFiltro;
                    lobReg.Sia_codeps_teps      = this.txtG1Sia_codeps_teps.Text;
                    lobReg.EpsNombre            = this.txtG1Sia_deseps_teps.Text;
                    lobReg.ValorCopago          = lnuPrmValorCopagoAF;
                    lobReg.ValorComision        = lnuPrmValorComisionAF;
                    lobReg.ValorDescuen         = lnuPrmValorDescuenAF;
                    lobReg.ValorFactura         = lnuPrmValorFacturaAF;

                    var tmpContrato = CTOValidarCodigo.fobRegBuscarCtomaescontratoEx(this.txtG1Cto_seccon_cont.Text);
                    if (tmpContrato != null)
                    {
                        lobReg.ContratoNumero = tmpContrato.cto_nrocon_cont;
                        lobReg.ContratoPlanBen = tmpContrato.cto_plaben_cont;
                        lobReg.ContratoPoliza = tmpContrato.cto_polcon_cont;
                    }
                    else
                    {
                        lobReg.ContratoNumero = String.Empty;
                        lobReg.ContratoPlanBen = String.Empty;
                        lobReg.ContratoPoliza = String.Empty;
                    }
                    gcrTextoArchivoAF = fcrLeerTextoRegistroRipsAF(lobReg);
                }
                #endregion
                // Cargar el archivo de control
                #region Registro de control
                var lobRegCT = new tmpRipsCT();
                lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                lobRegCT.FechaRemision      = lcrPrmFechaRemision;
                lobRegCT.NombreArchivo      = gcrNombreArchivoAF;
                lobRegCT.TotalRegistros     = lnuTotalAF;
                lobRegCT.Descripcion        = "Rips transacciones";
                lobRegCT.ImagenJpg          = "sys_car01.png";
                tmpRipsArchivoControl.Add(lobRegCT);
                #endregion

            }
            #endregion
        }
        #endregion
        #region fcvLeerTextoRipsDetallesFacturas: Leer Datos detalles facturas y cargar texto en formato Plano
        /// <summary>
        /// <para>Leer Datos detalles facturas y cargar texto en formato Plano</para>
        /// </summary>
        public void fcvLeerTextoRipsDetallesFacturas()
        {
            lnuTotalAC = 0;
            lnuTotalAP = 0;
            lnuTotalAM = 0;
            lnuTotalAT = 0;
            lcrTextoAC = String.Empty;
            lcrTextoAP = String.Empty;
            lcrTextoAM = String.Empty;
            lcrTextoAT = String.Empty;

            #region Acciones segun Tipo filtro
            if (lcrPrmTipoFiltro == "2") // Filtro cuenta de cobro
            {
                tmpRipsDetallesFact = flsFiltroTempDetallesServFactCuentas();
            }
            else
            {
                if (lcrPrmRipsAuxiliares == "2") // Rips normal
                {
                    // Desde filtro nromal
                    if (lcrPrmTipoActividad == "3" || lcrPrmTipoActividad == "4")
                    {
                        // Todas las actividades
                        tmpRipsDetallesFact = flsFiltroTempDetallesServiciosFacturados();
                    }
                    else
                    {
                        // Separado por asistencial y pyp
                        tmpRipsDetallesFact = flsFiltroTempDetallesServiciosAsistPyP();
                    }
                }
                else 
                {
                    // Rips auxiliar
                    //MessageBox.Show("Generar Rips auxiliar detalles");
                    tmpRipsDetallesFact = flsAuxFiltroTempDetallesServicios();
                }
            }
            #endregion

            if (tmpRipsDetallesFact != null)
            {
                if (lcrPrmTipoActividad != "4")
                {
                    // Todas las actividades
                    fcvLeerTextoRipsDetallesFacturasAux1();
                }
                #region Rips AC
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAC))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAC;
                    lobRegCT.TotalRegistros = lnuTotalAC;
                    lobRegCT.Descripcion = "Rips Consultas";
                    lobRegCT.ImagenJpg = "sys_atm01.png";
                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
                #region Rips AP
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAP))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAP;
                    lobRegCT.TotalRegistros = lnuTotalAP;
                    lobRegCT.Descripcion = "Rips Procedimientos";
                    lobRegCT.ImagenJpg = "sys_enf01.png";
                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
                #region Rips AM
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAM))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAM;
                    lobRegCT.TotalRegistros = lnuTotalAM;
                    lobRegCT.Descripcion = "Rips Medicamentos";
                    lobRegCT.ImagenJpg = "sys_far01.png";
                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
                #region Rips AT
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAT))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAT;
                    lobRegCT.TotalRegistros = lnuTotalAT;
                    lobRegCT.Descripcion = "Rips Otros Servicios";
                    lobRegCT.ImagenJpg = "sys_inv01.png";
                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
        }
        #endregion
        #region fcvLeerTextoRipsDetallesFacturas: (Con parametro) Leer Datos detalles facturas y cargar texto en formato Plano
        /// <summary>
        /// <para>Leer Datos detalles facturas y cargar texto en formato Plano</para>
        /// <para>tcrTipoRips: "AC"=Consultas "AP"=Procedimientos "AM"=Medicamentos "AT"=</para>
        /// </summary>
        public void fcvLeerTextoRipsDetallesFacturas(String tcrTipoRips)
        {
            if (tcrTipoRips == "AC")
            {
                // Reinicia todo la primera vez
                tmpRipsDetallesFact = flsFiltroTempDetallesServiciosFacturados();
                lnuTotalAC = 0;
                lnuTotalAP = 0;
                lnuTotalAM = 0;
                lnuTotalAT = 0;
                lcrTextoAC = String.Empty;
                lcrTextoAP = String.Empty;
                lcrTextoAM = String.Empty;
                lcrTextoAT = String.Empty;
            }

            if (tmpRipsDetallesFact != null)
            {

                fcvLeerTextoRipsDetallesFacturasAux2(tcrTipoRips); // se pasaron a ejecutar afuera donde se llama a fcvLeerTextoRipsDetallesFacturas()
                #region Rips AC
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAC) && tcrTipoRips == "AC")
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAC;
                    lobRegCT.TotalRegistros = lnuTotalAC;
                    lobRegCT.Descripcion = "Rips Consultas";
                    lobRegCT.ImagenJpg = "sys_atm01.png";
                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
                #region Rips AP
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAP) && tcrTipoRips == "AP")
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAP;
                    lobRegCT.TotalRegistros = lnuTotalAP;
                    lobRegCT.Descripcion = "Rips Procedimientos";
                    lobRegCT.ImagenJpg = "sys_enf01.png";
                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
                #region Rips AM
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAM) && tcrTipoRips == "AM")
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAM;
                    lobRegCT.TotalRegistros = lnuTotalAM;
                    lobRegCT.Descripcion = "Rips Medicamentos";
                    lobRegCT.ImagenJpg = "sys_far01.png";
                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
                #region Rips AT
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAT) && tcrTipoRips == "AT")
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();
                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAT;
                    lobRegCT.TotalRegistros = lnuTotalAT;
                    lobRegCT.Descripcion = "Rips Otros Servicios";
                    lobRegCT.ImagenJpg = "sys_inv01.png";
                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
        }
        #endregion
        #region fcvLeerTextoRipsDetallesFacturasAux1: Leer detalles facturas y cargar texto RIPS NORMAL
        /// <summary>
        /// <para>Leer detalles facturas y cargar texto RIPS NORMAL</para>
        /// </summary>
        public void fcvLeerTextoRipsDetallesFacturasAux1()
        {
            foreach (var lobReg in tmpRipsDetallesFact)
            {
                lcrTextoAC = String.Empty;
                lcrTextoAP = String.Empty;
                lcrTextoAM = String.Empty;
                lcrTextoAT = String.Empty;
                #region Datos Rips
                var lobRegFac = tmpRipsMaestroFact.FirstOrDefault(x => x.Fcm_numfac_mfac == lobReg.fcm_numfac_mfac);
                if (lobRegFac != null)
                {
                    lobReg.sia_tipide_tide = lobRegFac.Sia_tipide_tide;
                    lobReg.sia_nroide_usua = lobRegFac.Sia_nroide_usua;
                    lobReg.adm_nroaut_rgad = lobRegFac.Adm_nroaut_rgad;

                    if (lobReg.sia_codrip_trip == "01")
                    {
                        // Consultas
                        if (lobReg.fcm_totuni_dfac > 1 && lobReg.fcm_valcpa_dfac == 0 && lobReg.fcm_valcmo_dfac == 0)
                        {
                            // Porque se generará por cada unidad facturada un registro 
                            lnuTotalAC = fnuAddUnidadesRegistroAC(lnuTotalAC, lobReg);
                        }
                        else
                        {
                            lnuTotalAC++;
                        }
                        lcrTextoAC = fcrLeerTextoRegistroRipsAC(lobReg);
                        lcrTextoAC = !String.IsNullOrWhiteSpace(gcrTextoArchivoAC) ? "\r\n" + lcrTextoAC : lcrTextoAC;
                        gcrTextoArchivoAC += lcrTextoAC;
                    }
                    else if (lobReg.sia_codrip_trip == "02" || lobReg.sia_codrip_trip == "03" ||
                             lobReg.sia_codrip_trip == "04" || lobReg.sia_codrip_trip == "05")
                    {
                        // Procedimientos

                        lnuTotalAP += (int)lobReg.fcm_totuni_dfac;
                        lcrTextoAP = fcrLeerTextoRegistroRipsAP(lobReg);
                        lcrTextoAP = !String.IsNullOrWhiteSpace(gcrTextoArchivoAP) ? "\r\n" + lcrTextoAP : lcrTextoAP;
                        gcrTextoArchivoAP += lcrTextoAP;
                    }
                    else if (lobReg.sia_codrip_trip == "12" || lobReg.sia_codrip_trip == "13")
                    {
                        // Medicamentos

                        lnuTotalAM++;
                        lcrTextoAM = fcrLeerTextoRegistroRipsAM(lobReg);
                        lcrTextoAM = !String.IsNullOrWhiteSpace(gcrTextoArchivoAM) ? "\r\n" + lcrTextoAM : lcrTextoAM;
                        gcrTextoArchivoAM += lcrTextoAM;
                    }
                    else
                    {
                        // Otros servicios

                        lnuTotalAT++;
                        lcrTextoAT = fcrLeerTextoRegistroRipsAT(lobReg);
                        lcrTextoAT = !String.IsNullOrWhiteSpace(gcrTextoArchivoAT) ? "\r\n" + lcrTextoAT : lcrTextoAT;
                        gcrTextoArchivoAT += lcrTextoAT;
                    }
                    // Descripción agrupada
                    fcrLeerRipsArchivoDescAgrupada(lobReg);
                }
                #endregion
            }
        }
        #endregion
        #region fcvLeerTextoRipsDetallesFacturasAux2: Leer detalles texto RIPS segun parametro
        /// <summary>
        /// <para>Leer detalles facturas y cargar texto RIPS NORMAL</para>
        /// <para>tcrTipoRips: "AC"=Consultas "AP"=Procedimientos "AM"=Medicamentos "AT"=</para>
        /// </summary>
        public void fcvLeerTextoRipsDetallesFacturasAux2(String tcrTipoRips)
        {
            var llgEncontrado = false;
            foreach (var lobReg in tmpRipsDetallesFact)
            {
                #region Datos Rips
                var lobRegFac = tmpRipsMaestroFact.FirstOrDefault(x => x.Fcm_numfac_mfac == lobReg.fcm_numfac_mfac);
                if (lobRegFac != null)
                {
                    lobReg.sia_tipide_tide = lobRegFac.Sia_tipide_tide;
                    lobReg.sia_nroide_usua = lobRegFac.Sia_nroide_usua;
                    lobReg.adm_nroaut_rgad = lobRegFac.Adm_nroaut_rgad;

                    if (lobReg.sia_codrip_trip == "01" && tcrTipoRips == "AC")
                    {
                        // Consultas
                        lnuTotalAC = fnuAddUnidadesRegistroAC(lnuTotalAC, lobReg);
                        lcrTextoAC = fcrLeerTextoRegistroRipsAC(lobReg);
                        lcrTextoAC = !String.IsNullOrWhiteSpace(gcrTextoArchivoAC) ? "\r\n" + lcrTextoAC : lcrTextoAC;
                        gcrTextoArchivoAC += lcrTextoAC;
                        llgEncontrado = true;
                    }

                    if ((lobReg.sia_codrip_trip == "02" || lobReg.sia_codrip_trip == "03" ||
                       lobReg.sia_codrip_trip == "04" || lobReg.sia_codrip_trip == "05") && tcrTipoRips == "AP")
                    {
                        // Procedimientos
                        lnuTotalAP = fnuAddUnidadesRegistroAP(lnuTotalAP, lobReg);
                        lcrTextoAP = fcrLeerTextoRegistroRipsAP(lobReg);
                        lcrTextoAP = !String.IsNullOrWhiteSpace(gcrTextoArchivoAP) ? "\r\n" + lcrTextoAP : lcrTextoAP;
                        gcrTextoArchivoAP += lcrTextoAP;
                        llgEncontrado = true;
                    }

                    if ((lobReg.sia_codrip_trip == "12" || lobReg.sia_codrip_trip == "13") && tcrTipoRips == "AM")
                    {
                        // Medicamentos
                        lnuTotalAM++;
                        lcrTextoAM = fcrLeerTextoRegistroRipsAM(lobReg);
                        lcrTextoAM = !String.IsNullOrWhiteSpace(gcrTextoArchivoAM) ? "\r\n" + lcrTextoAM : lcrTextoAM;
                        gcrTextoArchivoAM += lcrTextoAM;
                        llgEncontrado = true;
                    }

                    if (tcrTipoRips == "AT")
                    {
                        if (lobReg.sia_codrip_trip != "01" &&  
                            lobReg.sia_codrip_trip != "02" && lobReg.sia_codrip_trip != "03" &&
                            lobReg.sia_codrip_trip != "04" && lobReg.sia_codrip_trip != "05" &&
                            lobReg.sia_codrip_trip != "12" && lobReg.sia_codrip_trip != "13")
                        {
                            // Otros servicios
                            lnuTotalAT++;
                            lcrTextoAT = fcrLeerTextoRegistroRipsAT(lobReg);
                            lcrTextoAT = !String.IsNullOrWhiteSpace(gcrTextoArchivoAT) ? "\r\n" + lcrTextoAT : lcrTextoAT;
                            gcrTextoArchivoAT += lcrTextoAT;
                            llgEncontrado = true;
                        }
                    }
                    // Descripción agrupada
                    if (llgEncontrado == true)
                    {
                        fcrLeerRipsArchivoDescAgrupada(lobReg);
                    }
                }
                #endregion
            }
        }
        #endregion
        #region fcvLeerTextoRipsHospitalizacion: Generar el texto para archivo Rips Hospitalizacion
        /// <summary>
        /// <para>Generar el texto para archivo Rips Hospitalizacion</para>
        /// </summary>
        public void fcvLeerTextoRipsHospitalizacion()
        {
            String lcrTextoAH = String.Empty;

            if (tmpRipsHospitaliz != null)
            {
                var lnuTotalReg = 0;
                gcrTextoArchivoAH = String.Empty;
                foreach (var lobReg in tmpRipsHospitaliz)
                {
                    if (lcrPrmRipsAuxiliares == "2") // Rips normal
                    {
                        lnuTotalReg++;
                        lcrTextoAH = String.Empty;
                        lcrTextoAH = fcrLeerTextoRegistroRipsAH(lobReg);
                        lcrTextoAH = !String.IsNullOrWhiteSpace(gcrTextoArchivoAH) ? "\r\n" + lcrTextoAH : lcrTextoAH;
                        gcrTextoArchivoAH += lcrTextoAH;
                    }
                    else
                    {
                        // Rips Auxiliares verificar se hay detalles en facturas para el usuario
                        var lobReAux = tmpRipsDetallesFact.FirstOrDefault(x => x.sia_idesec_usua == lobReg.Sia_idesec_usua);
                        if (lobReAux != null)
                        {
                            lnuTotalReg++;
                            lcrTextoAH = String.Empty;
                            lcrTextoAH = fcrLeerTextoRegistroRipsAH(lobReg);
                            lcrTextoAH = !String.IsNullOrWhiteSpace(gcrTextoArchivoAH) ? "\r\n" + lcrTextoAH : lcrTextoAH;
                            gcrTextoArchivoAH += lcrTextoAH;
                        }
                    }
                }
                #region Registrar Rips Hospitalización en archivo de control
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAH))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();

                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAH;
                    lobRegCT.TotalRegistros = lnuTotalReg;
                    lobRegCT.Descripcion = "Rips Hospitalización";
                    lobRegCT.ImagenJpg = "sys_notific_hospitalizacion.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
        }
        #endregion
        #region fcvLeerTextoRipsUrgencias: Generar el texto para archivo Rips Urgencias
        /// <summary>
        /// <para>Generar el texto para archivo Rips Urgencias</para>
        /// </summary>
        public void fcvLeerTextoRipsUrgencias()
        {
            String lcrTextoAU = String.Empty;

            if (tmpRipsUrgencias != null)
            {
                var lnuTotalReg = 0;
                gcrTextoArchivoAU = String.Empty;
                foreach (var lobReg in tmpRipsUrgencias)
                {
                    if (lcrPrmRipsAuxiliares == "2") // Rips normal
                    {
                        lnuTotalReg++;
                        lcrTextoAU = String.Empty;
                        lcrTextoAU = fcrLeerTextoRegistroRipsAU(lobReg);
                        lcrTextoAU = !String.IsNullOrWhiteSpace(gcrTextoArchivoAU) ? "\r\n" + lcrTextoAU : lcrTextoAU;
                        gcrTextoArchivoAU += lcrTextoAU;
                    }
                    else
                    {
                        // Rips Auxiliares verificar se hay detalles en facturas para el usuario
                        var lobReAux = tmpRipsDetallesFact.FirstOrDefault(x => x.sia_idesec_usua == lobReg.Sia_idesec_usua);
                        if (lobReAux != null)
                        {
                            lnuTotalReg++;
                            lcrTextoAU = String.Empty;
                            lcrTextoAU = fcrLeerTextoRegistroRipsAU(lobReg);
                            lcrTextoAU = !String.IsNullOrWhiteSpace(gcrTextoArchivoAU) ? "\r\n" + lcrTextoAU : lcrTextoAU;
                            gcrTextoArchivoAU += lcrTextoAU;
                        }
                    }
                }
                #region Registrar Rips Urgencias en archivo de control
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAU))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();

                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAU;
                    lobRegCT.TotalRegistros = lnuTotalReg;
                    lobRegCT.Descripcion = "Rips Observación en Urgencias";
                    lobRegCT.ImagenJpg = "sys_notific_traslado.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
        }
        #endregion
        #region fcvLeerTextoRipsNacimientos: Generar el texto para archivo Rips Nacimientos
        /// <summary>
        /// <para>Generar el texto para archivo Rips Nacimientos</para>
        /// </summary>
        public void fcvLeerTextoRipsNacimientos()
        {
            String lcrTextoAN = String.Empty;

            if (tmpRipsNacimientos != null)
            {
                var lnuTotalReg = 0;
                gcrTextoArchivoAN = String.Empty;
                foreach (var lobReg in tmpRipsNacimientos)
                {
                    if (lcrPrmRipsAuxiliares == "2") // Rips normal
                    {
                        lnuTotalReg++;
                        lcrTextoAN = String.Empty;
                        lcrTextoAN = fcrLeerTextoRegistroRipsAN(lobReg);
                        lcrTextoAN = !String.IsNullOrWhiteSpace(gcrTextoArchivoAN) ? "\r\n" + lcrTextoAN : lcrTextoAN;
                        gcrTextoArchivoAN += lcrTextoAN;
                    }
                    else
                    {
                        // Rips Auxiliares vrificar se hay detalles en facturas para el usuario
                        var lobReAux = tmpRipsDetallesFact.FirstOrDefault(x => x.sia_idesec_usua == lobReg.Sia_idesec_usua);
                        if (lobReAux != null)
                        {
                            lnuTotalReg++;
                            lcrTextoAN = String.Empty;
                            lcrTextoAN = fcrLeerTextoRegistroRipsAN(lobReg);
                            lcrTextoAN = !String.IsNullOrWhiteSpace(gcrTextoArchivoAN) ? "\r\n" + lcrTextoAN : lcrTextoAN;
                            gcrTextoArchivoAN += lcrTextoAN;
                        }
                    }

                }
                #region Registrar Rips Nacimientos
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAN))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();

                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoAN;
                    lobRegCT.TotalRegistros = lnuTotalReg;
                    lobRegCT.Descripcion = "Rips Nacimientos";
                    lobRegCT.ImagenJpg = "sys_nom01.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
        }
        #endregion
        #region fcvLeerTextoRipsUsuarios: Generar el texto para archivo Rips Usuarios atendidos
        /// <summary>
        /// <para>Generar el texto para archivo Rips Usuarios atendidos</para>
        /// </summary>
        public void fcvLeerTextoRipsUsuarios()
        {
            String lcrTextoUS = String.Empty;
            var lnuTotalReg = 0;

            if (tmpRipsUsuarios != null)
            {
                gcrTextoArchivoUS = String.Empty;
                foreach (var lobReg in tmpRipsUsuarios)
                {
                    if (lcrPrmRipsAuxiliares == "2") // Rips normal
                    {
                        lnuTotalReg++;
                        lcrTextoUS = String.Empty;
                        lcrTextoUS = fcrLeerTextoRegistroRipsUS(lobReg);
                        lcrTextoUS = !String.IsNullOrWhiteSpace(gcrTextoArchivoUS) ? "\r\n" + lcrTextoUS : lcrTextoUS;
                        gcrTextoArchivoUS += lcrTextoUS;
                    }
                    else
                    {
                        // Rips Auxiliares verificar se hay detalles en facturas para el usuario
                        var lobReAux = tmpRipsDetallesFact.FirstOrDefault(x => x.sia_idesec_usua == lobReg.Sia_idesec_usua);
                        if (lobReAux != null)
                        {
                            lnuTotalReg++;
                            lcrTextoUS = String.Empty;
                            lcrTextoUS = fcrLeerTextoRegistroRipsUS(lobReg);
                            lcrTextoUS = !String.IsNullOrWhiteSpace(gcrTextoArchivoUS) ? "\r\n" + lcrTextoUS : lcrTextoUS;
                            gcrTextoArchivoUS += lcrTextoUS;
                        }

                    }
                }
                #region Registrar Rips Usuarios atendidos
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoUS))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();

                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo = gcrNombreArchivoUS;
                    lobRegCT.TotalRegistros = lnuTotalReg;
                    lobRegCT.Descripcion = "Rips Usuarios atendidos";
                    lobRegCT.ImagenJpg = "sys_cit02.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
        }
        #endregion
        #region fcvLeerTextoRipsDesAgrupada: Generar el texto para archivo Rips Descripción agrupada
        /// <summary>
        /// <para>Generar el texto para archivo Rips Descripción agrupada</para>
        /// </summary>
        public void fcvLeerTextoRipsDesAgrupada()
        {
            String lcrTextoAD = String.Empty;

            if (tmpRipsDesAgrupada != null)
            {
                gcrTextoArchivoAD = String.Empty;
                foreach (var lobReg in tmpRipsDesAgrupada)
                {
                    lcrTextoAD = String.Empty;
                    lcrTextoAD = fcrLeerTextoRegistroRipsAD(lobReg);
                    lcrTextoAD = !String.IsNullOrWhiteSpace(gcrTextoArchivoAD) ? "\r\n" + lcrTextoAD : lcrTextoAD;
                    gcrTextoArchivoAD += lcrTextoAD;
                }
                #region Registrar Rips Descripción agrupada
                if (!String.IsNullOrWhiteSpace(gcrTextoArchivoAD))
                {
                    // Cargar el archivo de control
                    var lobRegCT = new tmpRipsCT();

                    lobRegCT.IPSCodigoPrestador = lcrPrmIPSCodigoPrestador;
                    lobRegCT.FechaRemision      = lcrPrmFechaRemision;
                    lobRegCT.NombreArchivo      = gcrNombreArchivoAD;
                    lobRegCT.TotalRegistros     = tmpRipsDesAgrupada.Count();
                    lobRegCT.Descripcion        = "Rips Descripción agrupada";
                    lobRegCT.ImagenJpg          = "sys_notific_pago.png";

                    tmpRipsArchivoControl.Add(lobRegCT);
                }
                #endregion
            }
        }
        #endregion
        // Auxiliar para total registro AC y AP
        #region fnuAddUnidadesRegistroAC: Agregar total unidades del registro AC activo
        /// <summary>
        /// <para>Agregar unidades del registro activo AC al gran total del archivo AC, segun parametro configuracion sistema</para>
        /// <para>esto para saber si se generan varios registros en el plano segun cantidad de unidades facturadas</para>
        /// </summary>
        public int fnuAddUnidadesRegistroAC(int tnuTotalGeneralAC, EFfcmmaedetallfac tobRegActivo)
        {
            var lnuTotal = tnuTotalGeneralAC;
            // Porque se generará por cada unidad facturada un registro 
            if (gcrGenVariosReg_SINO_AC == "1")
            {
                lnuTotal += (int)tobRegActivo.fcm_totuni_dfac;
            }
            else
            {
                lnuTotal++;
            }
            return lnuTotal;
        }
        #endregion
        #region fnuAddUnidadesRegistroAP: Agregar total unidades del registro AP activo
        /// <summary>
        /// <para>Agregar unidades del registro activo AP al gran total del archivo AP, segun parametro configuracion sistema</para>
        /// <para>esto para saber si se generan varios registros en el plano segun cantidad de unidades facturadas</para>
        /// </summary>
        public int fnuAddUnidadesRegistroAP(int tnuTotalGeneralAP, EFfcmmaedetallfac tobRegActivo)
        {
            var lnuTotal = tnuTotalGeneralAP;
            // Porque se generará por cada unidad facturada un registro 
            if (gcrGenVariosReg_SINO_AP == "1")
            {
                lnuTotal += (int)tobRegActivo.fcm_totuni_dfac;
            }
            else
            {
                lnuTotal++;
            }
            return lnuTotal;
        }
        #endregion
        //- Lectura texto registros
        #region fcrLeerTextoRegistroRipsCT: Leer Texto registro para Formato Rips Archivo control
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips Archivo control</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsCT(tmpRipsCT tobRegistro)
        {
            var lcrTexto = tobRegistro.IPSCodigoPrestador + "," +
                           tobRegistro.FechaRemision + "," +
                           tobRegistro.NombreArchivo + "," +
                           tobRegistro.TotalRegistros.ToString().Trim();
            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsAF: Leer Texto registro para Formato Rips Transacciones
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips Transacciones</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsAF(tmpRipsAF tobRegistro)
        {
            // Para cuando es SISPRO
            var lcrTipoArchivoSispro = String.Empty;
            if (lcrPrmTipoActividad == "4")
            {
                lnuPrmContadorRipsSispro++;
                lcrTipoArchivoSispro = "10," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
            }

            var lcrNombreIPS = tobRegistro.IPSNombreEmpresa.Trim();
            lcrNombreIPS = lcrNombreIPS.Length > 60 ? lcrNombreIPS.Substring(0, 60) : lcrNombreIPS;

            var lcrDesEps = tobRegistro.EpsNombre.Trim();
            lcrDesEps = lcrDesEps.Length > 30 ? lcrDesEps.Substring(0, 30) : lcrDesEps;
            tobRegistro.ContratoPoliza = tobRegistro.ContratoPoliza == null ? "" : tobRegistro.ContratoPoliza;

            var lcrTexto = lcrTipoArchivoSispro + tobRegistro.IPSCodigoPrestador + "," +
                           lcrNombreIPS + "," +
                           tobRegistro.IPSTipoNit + "," +
                           tobRegistro.IPSCodigoNit + "," +
                           tobRegistro.Fcm_numfac_mfac.Trim() + "," +
                           ((DateTime)tobRegistro.Fcm_fecfac_mfac).ToShortDateString().Trim() + "," +
                           tobRegistro.FechaIniPeriodo + "," +
                           tobRegistro.FechaFinPeriodo + "," +
                           tobRegistro.Sia_codeps_teps.Trim() + "," +
                           lcrDesEps + "," +
                           tobRegistro.ContratoNumero.Trim() + "," +
                           tobRegistro.ContratoPlanBen.Trim() + "," +
                           tobRegistro.ContratoPoliza.Trim() + "," +
                           tobRegistro.ValorCopago.ToString().Trim() + "," +
                           tobRegistro.ValorComision.ToString().Trim() + "," +
                           tobRegistro.ValorDescuen.ToString().Trim() + "," +
                           tobRegistro.ValorFactura.ToString().Trim();
            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsAD: Leer Texto registro para Formato Rips Archivo Descripción agrupada
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips Archivo Descripción agrupada</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsAD(tmpRipsAD tobRegistro)
        {
            var lcrTexto = tobRegistro.Fcm_numfac_mfac + "," +
                           tobRegistro.IPSCodPrestador + "," +
                           tobRegistro.Sia_codrip_trip + "," +
                           tobRegistro.Fcm_totuni_dfac.ToString().Trim() + "," +
                           tobRegistro.Fcm_valser_mant.ToString().Trim() + "," +
                           tobRegistro.Fcm_valfac_dfac.ToString().Trim();
            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsAC: Leer Texto registro para Formato Rips consulta
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips consulta</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsAC(EFfcmmaedetallfac tobRegistro)
        {
            // Para cuando es SISPRO
            var lcrTipoArchivoSispro = String.Empty;
            if (lcrPrmTipoActividad == "4") 
            {
                lnuPrmContadorRipsSispro++;
                lcrTipoArchivoSispro = "3," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
            }

            var lcrNumeroAutori = tobRegistro.adm_nroaut_rgad != null ? tobRegistro.adm_nroaut_rgad.Trim() : "";
            var lcrFinConsulta  = tobRegistro.sia_codfco_fcon != null ? tobRegistro.sia_codfco_fcon.Trim() : "";
            var lcrCausaExtern  = tobRegistro.adm_codcex_tcex != null ? tobRegistro.adm_codcex_tcex.Trim() : "";
            var lcrDiagnost     = tobRegistro.sia_coddia_tdia != null ? tobRegistro.sia_coddia_tdia.Trim() : "";
            var lcrTipDiag      = tobRegistro.sia_tipdxp_tdix != null ? tobRegistro.sia_tipdxp_tdix.Trim() : "";
            var lcrDiagnos1     = tobRegistro.sia_coddx1_tdia != null ? tobRegistro.sia_coddx1_tdia.Trim() : "";
            var lcrDiagnos2     = tobRegistro.sia_coddx2_tdia != null ? tobRegistro.sia_coddx2_tdia.Trim() : "";
            var lcrDiagnos3     = tobRegistro.sia_coddx3_tdia != null ? tobRegistro.sia_coddx3_tdia.Trim() : "";
            var lnuValBruto     = tobRegistro.fcm_valbru_dfac - (tobRegistro.fcm_valusu_dfac);
            var lnuCopago       = tobRegistro.fcm_valcpa_dfac > 0 ? tobRegistro.fcm_valcpa_dfac : tobRegistro.fcm_valcmo_dfac;
            var lcrNumeroFactura = this.chkIncNumCuentaEnPlanos.IsChecked == true ? this.txtFacturaCuenta.Text : tobRegistro.fcm_numfac_mfac;

            #region String completa
            var lcrTexto = lcrTipoArchivoSispro + lcrNumeroFactura + "," +
                           lcrPrmIPSCodigoPrestador + "," +
                           tobRegistro.sia_tipide_tide.Trim() + "," +
                           tobRegistro.sia_nroide_usua.Trim() + "," +
                           ((DateTime)tobRegistro.fcm_fecser_dfac).ToShortDateString().Trim() + "," +
                           lcrNumeroAutori + "," +
                           tobRegistro.fcm_codser_mant.Trim() + "," +
                           lcrFinConsulta + "," +
                           lcrCausaExtern + "," +
                           lcrDiagnost + "," +
                           lcrDiagnos1 + "," +
                           lcrDiagnos2 + "," +
                           lcrDiagnos3 + "," +
                           lcrTipDiag + "," +
                           lnuValBruto.ToString().Trim() + "," +
                           lnuCopago.ToString().Trim() + "," +
                           tobRegistro.fcm_valfac_dfac.ToString().Trim();
            #endregion
            // para cuando hay varias unidades del servicio sin copagos (para no afectar el valor bruto)
            #region String modificada cuando hay varias unidades del servicio
            if (tobRegistro.fcm_totuni_dfac > 1 && tobRegistro.fcm_valcpa_dfac == 0 && tobRegistro.fcm_valcmo_dfac == 0)
            {
                if (gcrGenVariosReg_SINO_AC == "1")
                {
                    lnuPrmContadorRipsSispro = lnuPrmContadorRipsSispro - 1; // para que no se salte al entrar al ciclo For

                    #region String modificada
                    lcrTexto = lcrNumeroFactura + "," +
                               lcrPrmIPSCodigoPrestador + "," +
                               tobRegistro.sia_tipide_tide.Trim() + "," +
                               tobRegistro.sia_nroide_usua.Trim() + "," +
                               ((DateTime)tobRegistro.fcm_fecser_dfac).ToShortDateString().Trim() + "," +
                               lcrNumeroAutori + "," +
                               tobRegistro.fcm_codser_mant.Trim() + "," +
                               lcrFinConsulta + "," +
                               lcrCausaExtern + "," +
                               lcrDiagnost + "," +
                               lcrDiagnos1 + "," +
                               lcrDiagnos2 + "," +
                               lcrDiagnos3 + "," +
                               lcrTipDiag + ",";
                    #endregion
                    // el valor unidad se debe ajustar al valor facturado total, porque pudo haber descuentos y otras deducciones
                    // en el mismo registro
                    var i = 0;
                    var lnuValorAx = String.Empty;
                    var lnuValorUnidad = (int)(tobRegistro.fcm_valfac_dfac / tobRegistro.fcm_totuni_dfac);
                    var lcrTexto1 = String.Empty;
                    float lnuSumaValor = 0;
                    var lcrTextoAux = String.Empty;

                    // Generar un regtistro por cada unidad
                    #region Generar un regtistro por cada unidad
                    for (i = 1; i <= tobRegistro.fcm_totuni_dfac; i++)
                    {
                        lcrTipoArchivoSispro = String.Empty;
                        if (lcrPrmTipoActividad == "4")
                        {
                            lnuPrmContadorRipsSispro++;
                            lcrTipoArchivoSispro = "3," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
                        }

                        if (i == tobRegistro.fcm_totuni_dfac)
                        {
                            lnuValorAx = ((float)tobRegistro.fcm_valfac_dfac - lnuSumaValor).ToString().Trim();
                            lcrTextoAux = lcrTipoArchivoSispro + lcrTexto + lnuValorAx + ",0," + lnuValorAx; // Bruto + Copago + ValorTotal
                        }
                        else
                        {
                            lnuValorAx = lnuValorUnidad.ToString().Trim();
                            lcrTextoAux = lcrTipoArchivoSispro + lcrTexto + lnuValorAx + ",0," + lnuValorAx; // Bruto + Copago + ValorTotal
                            lnuSumaValor += lnuValorUnidad;
                        }
                        lcrTexto1 = String.IsNullOrWhiteSpace(lcrTexto1) ? lcrTextoAux : lcrTexto1 + "\r\n" + lcrTextoAux;
                    }
                    lcrTexto = lcrTexto1;
                    #endregion
                }
            }
            #endregion
            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsACxx: Leer Texto registro para Formato Rips consulta
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips consulta</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsACxx(EFfcmmaedetallfac tobRegistro)
        {
            // Para cuando es SISPRO
            var lcrTipoArchivoSispro = String.Empty;
            if (lcrPrmTipoActividad == "4")
            {
                lnuPrmContadorRipsSispro++;
                lcrTipoArchivoSispro = "3," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
            }

            var lcrNumeroAutori  = tobRegistro.adm_nroaut_rgad != null ? tobRegistro.adm_nroaut_rgad.Trim() : "";
            var lcrFinConsulta   = tobRegistro.sia_codfco_fcon != null ? tobRegistro.sia_codfco_fcon.Trim() : "";
            var lcrCausaExtern   = tobRegistro.adm_codcex_tcex != null ? tobRegistro.adm_codcex_tcex.Trim() : "";
            var lcrDiagnost      = tobRegistro.sia_coddia_tdia != null ? tobRegistro.sia_coddia_tdia.Trim() : "";
            var lcrTipDiag       = tobRegistro.sia_tipdxp_tdix != null ? tobRegistro.sia_tipdxp_tdix.Trim() : "";
            var lcrDiagnos1      = tobRegistro.sia_coddx1_tdia != null ? tobRegistro.sia_coddx1_tdia.Trim() : "";
            var lcrDiagnos2      = tobRegistro.sia_coddx2_tdia != null ? tobRegistro.sia_coddx2_tdia.Trim() : "";
            var lcrDiagnos3      = tobRegistro.sia_coddx3_tdia != null ? tobRegistro.sia_coddx3_tdia.Trim() : "";
            var lnuValBruto      = tobRegistro.fcm_valbru_dfac - (tobRegistro.fcm_valusu_dfac);
            var lnuCopago        = tobRegistro.fcm_valcpa_dfac > 0 ? tobRegistro.fcm_valcpa_dfac : tobRegistro.fcm_valcmo_dfac;
            var lcrNumeroFactura = this.chkIncNumCuentaEnPlanos.IsChecked == true ? this.txtFacturaCuenta.Text : tobRegistro.fcm_numfac_mfac;

            var lcrTexto = lcrTipoArchivoSispro + lcrNumeroFactura + "," +
                           lcrPrmIPSCodigoPrestador + "," +
                           tobRegistro.sia_tipide_tide.Trim() + "," +
                           tobRegistro.sia_nroide_usua.Trim() + "," +
                           ((DateTime)tobRegistro.fcm_fecser_dfac).ToShortDateString().Trim() + "," +
                           lcrNumeroAutori + "," +
                           tobRegistro.fcm_codser_mant.Trim() + "," +
                           lcrFinConsulta + "," +
                           lcrCausaExtern + "," +
                           lcrDiagnost + "," +
                           lcrDiagnos1 + "," +
                           lcrDiagnos2 + "," +
                           lcrDiagnos3 + "," +
                           lcrTipDiag + "," +
                           lnuValBruto.ToString().Trim() + "," +
                           lnuCopago.ToString().Trim() + "," +
                           tobRegistro.fcm_valfac_dfac.ToString().Trim();

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsAP: Leer Texto registro para Formato Rips Procedimiento
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips Procedimiento</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsAP(EFfcmmaedetallfac tobRegistro)
        {
            var lcrTipoArchivoSispro = String.Empty;
            var i = 0;
            var lcrNumeroAutori = tobRegistro.adm_nroaut_rgad != null ? tobRegistro.adm_nroaut_rgad.Trim() : "";
            var lcrTipoAtencio  = tobRegistro.adm_codtat_tatn != null ? tobRegistro.adm_codtat_tatn.Trim() : "";
            var lcrFinProcedim  = tobRegistro.sia_codfpr_fpor != null ? tobRegistro.sia_codfpr_fpor.Trim() : "";
            var lcrPersAtiende  = tobRegistro.sia_codpat_tpat != null ? tobRegistro.sia_codpat_tpat.Trim() : "";
            var lcrDiagnost     = tobRegistro.sia_coddia_tdia != null ? tobRegistro.sia_coddia_tdia.Trim() : "";
            var lcrDiagnos1     = tobRegistro.sia_coddx1_tdia != null ? tobRegistro.sia_coddx1_tdia.Trim() : "";
            var lcrDiagComp     = tobRegistro.sia_coddxc_tdia != null ? tobRegistro.sia_coddxc_tdia.Trim() : "";
            var lcrActoQuir     = tobRegistro.fcm_codaqx_aqir != null ? tobRegistro.fcm_codaqx_aqir.Trim() : "";
            var lcrNumeroFactura = this.chkIncNumCuentaEnPlanos.IsChecked == true ? this.txtFacturaCuenta.Text : tobRegistro.fcm_numfac_mfac;

            // Revisar si esta relaciondo con parto (en blanco por ahora)
            lcrPersAtiende = String.Empty;

            // quitar diagnostico cuando no es porc quirurjico
            if (tobRegistro.sia_codrip_trip != "04")
            {
                lcrDiagnost = String.Empty;
                lcrDiagnos1 = String.Empty;
                lcrDiagComp = String.Empty;
                lcrActoQuir = String.Empty;
            }

            //- generar registro de texto 
            var lcrTexto = lcrNumeroFactura + "," +
                           lcrPrmIPSCodigoPrestador + "," +
                           tobRegistro.sia_tipide_tide.Trim() + "," +
                           tobRegistro.sia_nroide_usua.Trim() + "," +
                           ((DateTime)tobRegistro.fcm_fecser_dfac).ToShortDateString().Trim() + "," +
                           lcrNumeroAutori + "," +
                           tobRegistro.fcm_codser_mant.Trim() + "," +
                           lcrTipoAtencio + "," +
                           lcrFinProcedim + "," +
                           lcrPersAtiende + "," +
                           lcrDiagnost + "," +
                           lcrDiagnos1 + "," +
                           lcrDiagComp + "," +
                           lcrActoQuir + ",";

            // para cuando hay varias unidades del mismo procedimiento
            if (tobRegistro.fcm_totuni_dfac > 1)
            {
                if (gcrGenVariosReg_SINO_AP == "1")
                {
                    // el valor unidad se debe ajustar al valor facturado total, porque pudo haber descuentos y otras deducciones
                    // en el mismo registro
                    var lnuValorUnidad = (int)(tobRegistro.fcm_valfac_dfac / tobRegistro.fcm_totuni_dfac);
                    var lcrTexto1 = String.Empty;
                    float lnuSumaValor = 0;
                    var lcrTextoAux = String.Empty;

                    for (i = 1; i <= tobRegistro.fcm_totuni_dfac; i++)
                    {
                        lcrTipoArchivoSispro = String.Empty;
                        if (lcrPrmTipoActividad == "4")
                        {
                            lnuPrmContadorRipsSispro++;
                            lcrTipoArchivoSispro = "4," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
                        }

                        if (i == tobRegistro.fcm_totuni_dfac)
                        {
                            lcrTextoAux = lcrTipoArchivoSispro + lcrTexto + ((float)tobRegistro.fcm_valfac_dfac - lnuSumaValor).ToString().Trim();
                        }
                        else
                        {
                            lcrTextoAux = lcrTipoArchivoSispro + lcrTexto + lnuValorUnidad.ToString().Trim();
                            lnuSumaValor += lnuValorUnidad;
                        }
                        lcrTexto1 = String.IsNullOrWhiteSpace(lcrTexto1) ? lcrTextoAux : lcrTexto1 + "\r\n" + lcrTextoAux;
                    }
                    lcrTexto = lcrTexto1;
                }
            }
            else
            {
                // Para cuando es SISPRO
                if (lcrPrmTipoActividad == "4")
                {
                    lnuPrmContadorRipsSispro++;
                    lcrTipoArchivoSispro = "4," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
                }

                lcrTexto = lcrTipoArchivoSispro + lcrTexto + tobRegistro.fcm_valfac_dfac.ToString().Trim();
            }
            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsAM: Leer Texto registro para Formato Rips Medicamentos
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips Medicamentos</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsAM(EFfcmmaedetallfac tobRegistro)
        {
            // Para cuando es SISPRO
            var lcrTipoArchivoSispro = String.Empty;
            if (lcrPrmTipoActividad == "4")
            {
                lnuPrmContadorRipsSispro++;
                lcrTipoArchivoSispro = "8," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
            }

            var lobRegIps = FCMValidarCodigo.fobRegBuscarFcmmanservicipsId(tobRegistro.fcm_idesec_sips);
            if (lobRegIps != null) 
            {
                if (!String.IsNullOrWhiteSpace(lobRegIps.fcm_codcum_sips)) { tobRegistro.fcm_codser_mant = lobRegIps.fcm_codcum_sips; }
            }
            var lcrNumeroAutori     = tobRegistro.adm_nroaut_rgad != null ? tobRegistro.adm_nroaut_rgad.Trim() : "";
            var lcrMedicamPos       = tobRegistro.fcm_serpos_sips != null ? tobRegistro.fcm_serpos_sips.Trim() : "";
            var lcrFormaFarma       = tobRegistro.fcm_forfar_sips != null ? tobRegistro.fcm_forfar_sips.Trim() : "";
            var lcrConcentrac       = tobRegistro.fcm_conmed_sips != null ? tobRegistro.fcm_conmed_sips.Trim() : "";
            var lcrUnidMedida       = tobRegistro.fcm_unimed_sips != null ? tobRegistro.fcm_unimed_sips.Trim() : "";
            var lcrNumeroFactura    = this.chkIncNumCuentaEnPlanos.IsChecked == true ? this.txtFacturaCuenta.Text : tobRegistro.fcm_numfac_mfac;

            var lcrDesMedicam = tobRegistro.fcm_desser_dfac.Trim();
            lcrDesMedicam = lcrDesMedicam.Length > 30 ? lcrDesMedicam.Substring(0, 30) : lcrDesMedicam;

            var lcrTexto = lcrTipoArchivoSispro + lcrNumeroFactura + "," +
                           lcrPrmIPSCodigoPrestador + "," +
                           tobRegistro.sia_tipide_tide.Trim() + "," +
                           tobRegistro.sia_nroide_usua.Trim() + "," +
                           lcrNumeroAutori + "," +
                           tobRegistro.fcm_codser_mant.Trim() + "," +
                           lcrMedicamPos + "," +
                           lcrDesMedicam + "," +
                           lcrFormaFarma + "," +
                           lcrConcentrac + "," +
                           lcrUnidMedida + "," +
                           tobRegistro.fcm_totuni_dfac.ToString().Trim() + "," +
                           tobRegistro.fcm_valser_mant.ToString().Trim() + "," +
                           tobRegistro.fcm_valfac_dfac.ToString().Trim();

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsAT: Leer Texto registro para Formato Rips Otros Servicios
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips Otros Servicios</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsAT(EFfcmmaedetallfac tobRegistro)
        {
            // Para cuando es SISPRO
            var lcrTipoArchivoSispro = String.Empty;
            if (lcrPrmTipoActividad == "4")
            {
                lnuPrmContadorRipsSispro++;
                lcrTipoArchivoSispro = "9," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
            }

            var lcrNumeroAutori = tobRegistro.adm_nroaut_rgad != null ? tobRegistro.adm_nroaut_rgad.Trim() : "";
            var lcrTipoServicio = tobRegistro.fcm_otserv_sips != null ? tobRegistro.fcm_otserv_sips.Trim() : "";
            var lcrNumeroFactura = this.chkIncNumCuentaEnPlanos.IsChecked == true ? this.txtFacturaCuenta.Text : tobRegistro.fcm_numfac_mfac;

            var lcrDesOtroServ = tobRegistro.fcm_desser_dfac.Trim();
            lcrDesOtroServ = lcrDesOtroServ.Length > 60 ? lcrDesOtroServ.Substring(0, 60) : lcrDesOtroServ;

            var lcrTexto = lcrTipoArchivoSispro + lcrNumeroFactura + "," +
                           lcrPrmIPSCodigoPrestador + "," +
                           tobRegistro.sia_tipide_tide.Trim() + "," +
                           tobRegistro.sia_nroide_usua.Trim() + "," +
                           lcrNumeroAutori + "," +
                           lcrTipoServicio + "," +
                           tobRegistro.fcm_codser_mant.Trim() + "," +
                           lcrDesOtroServ + "," +
                           tobRegistro.fcm_totuni_dfac.ToString().Trim() + "," +
                           tobRegistro.fcm_valser_mant.ToString().Trim() + "," +
                           tobRegistro.fcm_valfac_dfac.ToString().Trim();

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsAH: Leer Texto registro para Formato Rips Hospitalizacion
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips Hospitalizacion</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsAH(tmpRipsAH tobRegistro)
        {
            // Para cuando es SISPRO
            var lcrTipoArchivoSispro = String.Empty;
            if (lcrPrmTipoActividad == "4")
            {
                lnuPrmContadorRipsSispro++;
                lcrTipoArchivoSispro = "6," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
            }

            var lcrNumeroFactura = this.chkIncNumCuentaEnPlanos.IsChecked == true ? this.txtFacturaCuenta.Text : tobRegistro.Fcm_numfac_mfac;

            var lcrTexto = lcrTipoArchivoSispro + lcrNumeroFactura + "," +
                                      tobRegistro.IPSCodPrestador + "," +
                                      tobRegistro.Sia_tipide_tide.Trim() + "," +
                                      tobRegistro.Sia_nroide_usua.Trim() + "," +
                                      tobRegistro.Adm_codoad_toad.Trim() + "," +
                                      Funciones.fcrConvertFecha(tobRegistro.Adm_fechos_rgad) + "," +
                                      fcrConvierteHora(tobRegistro.Adm_horhos_rgad) + "," +
                                      tobRegistro.Adm_nroaut_rgad.Trim() + "," +
                                      tobRegistro.Adm_codcex_tcex.Trim() + "," +
                                      tobRegistro.Sia_dixing_tdia.Trim() + "," +
                                      tobRegistro.Sia_dixsal_tdia.Trim() + "," +
                                      tobRegistro.Sia_dixre1_tdia.Trim() + "," +
                                      tobRegistro.Sia_dixre2_tdia.Trim() + "," +
                                      tobRegistro.Sia_dixre3_tdia.Trim() + "," +
                                      tobRegistro.Sia_dixcom_tdia.Trim() + "," +
                                      tobRegistro.Adm_estsal_regr.Trim() + "," +
                                      tobRegistro.Sia_dixmue_tdia.Trim() + "," +
                                      Funciones.fcrConvertFecha(tobRegistro.Adm_fecegr_regr) + "," +
                                      fcrConvierteHora(tobRegistro.Adm_horegr_regr);
            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsAU: Leer Texto registro para Formato Rips Urgencias
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips Urgencias</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsAU(tmpRipsAU tobRegistro)
        {
            // Para cuando es SISPRO
            var lcrTipoArchivoSispro = String.Empty;
            if (lcrPrmTipoActividad == "4")
            {
                lnuPrmContadorRipsSispro++;
                lcrTipoArchivoSispro = "5," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
            }

            var lcrNumeroFactura = this.chkIncNumCuentaEnPlanos.IsChecked == true ? this.txtFacturaCuenta.Text : tobRegistro.Fcm_numfac_mfac;

            var lcrTexto = lcrTipoArchivoSispro + lcrNumeroFactura + "," +
                           tobRegistro.IPSCodPrestador + "," +
                           tobRegistro.Sia_tipide_tide.Trim() + "," +
                           tobRegistro.Sia_nroide_usua.Trim() + "," +
                           Funciones.fcrConvertFecha(tobRegistro.Adm_fecurg_rgad) + "," +
                           fcrConvierteHora(tobRegistro.Adm_horurg_rgad) + "," +
                           tobRegistro.Adm_nroaut_rgad.Trim() + "," +
                           tobRegistro.Adm_codcex_tcex.Trim() + "," +
                           tobRegistro.Sia_dixsal_tdia.Trim() + "," +
                           tobRegistro.Sia_dixre1_tdia.Trim() + "," +
                           tobRegistro.Sia_dixre2_tdia.Trim() + "," +
                           tobRegistro.Sia_dixre3_tdia.Trim() + "," +
                           tobRegistro.Adm_dessal_regr.Trim() + "," +
                           tobRegistro.Adm_estsal_regu.Trim() + "," +
                           tobRegistro.Sia_dixmue_tdia.Trim() + "," +
                           Funciones.fcrConvertFecha(tobRegistro.Adm_fecegr_regu) + "," +
                           fcrConvierteHora(tobRegistro.Adm_horegr_regu);

            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsAN: Leer Texto registro para Formato Rips Nacimientos
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips Nacimientos</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsAN(tmpRipsAN tobRegistro)
        {
            // Para cuando es SISPRO
            var lcrTipoArchivoSispro = String.Empty;
            if (lcrPrmTipoActividad == "4")
            {
                lnuPrmContadorRipsSispro++;
                lcrTipoArchivoSispro = "7," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
            }

            var lcrNumeroFactura = this.chkIncNumCuentaEnPlanos.IsChecked == true ? this.txtFacturaCuenta.Text : tobRegistro.Fcm_numfac_mfac;

            var lcrTexto = lcrNumeroFactura + "," +
                           tobRegistro.IPSCodPrestador + "," +
                           tobRegistro.Sia_tipide_tide.Trim() + "," +
                           tobRegistro.Sia_nroide_usua.Trim() + "," +
                           Funciones.fcrConvertFecha(tobRegistro.Adm_fecnac_regn) + "," +
                           fcrConvierteHora(tobRegistro.Adm_hornac_regn) + "," +
                           tobRegistro.Adm_semges_regr.ToString().Trim() + "," +
                           tobRegistro.Adm_contrl_regr.Trim() + "," +
                           tobRegistro.Sis_codsex_sexo.Trim() + "," +
                           tobRegistro.Adm_peson_regn.ToString().Trim() + "," +
                           tobRegistro.Sia_dixnac_tdia.Trim() + "," +
                           tobRegistro.Sia_dixmue_tdia.Trim() + "," +
                           Funciones.fcrConvertFecha(tobRegistro.Adm_fecmue_regn) + "," +
                           fcrConvierteHora(tobRegistro.Adm_hormue_regn);
            return lcrTexto;
        }
        #endregion
        #region fcrLeerTextoRegistroRipsUS: Leer Texto registro para Formato Rips Usuarios atendidos
        /// <summary>
        /// <para>Leer Texto registro para Formato Rips Usuarios atendidos</para>
        /// </summary>
        public String fcrLeerTextoRegistroRipsUS(tmpAdmision tobRegistro)
        {
            // Para cuando es SISPRO
            var lcrTipoArchivoSispro = String.Empty;
            if (lcrPrmTipoActividad == "4")
            {
                lnuPrmContadorRipsSispro++;
                lcrTipoArchivoSispro = "2," + lnuPrmContadorRipsSispro.ToString().Trim() + ",";
            }

            var lcrTexto = lcrTipoArchivoSispro + tobRegistro.Sia_tipide_tide.Trim() + "," +
                           tobRegistro.Sia_nroide_usua.Trim() + "," +
                           tobRegistro.Sia_codeps_teps.Trim() + "," +
                           tobRegistro.Sia_tipusu_regi.Trim() + "," +
                           tobRegistro.Sia_priape_usua.Trim() + "," +
                           tobRegistro.Sia_segape_usua.Trim() + "," +
                           tobRegistro.Sia_prinom_usua.Trim() + "," +
                           tobRegistro.Sia_segnom_usua.Trim() + "," +
                           tobRegistro.Sia_edapac_usua.ToString().Trim() + "," +
                           tobRegistro.Sia_codmed_tmed.Trim() + "," +
                           tobRegistro.Sis_codsex_sexo.Trim() + "," +
                           tobRegistro.Sis_coddep_dpto.Trim() + "," +
                           tobRegistro.Sis_codmun_muni.Trim() + "," +
                           tobRegistro.Sis_zonres_tzon.Trim();
            return lcrTexto;
        }
        #endregion
        //- Lectura registros auxuiliares desde TextoRipsFacturas y detalles factura
        #region fcrLeerRipsArchivoUsuarioAdm: Leer Datos maestro de admision para generar archivo usuarios Rips
        /// <summary>
        /// <para>Leer Datos maestro de admision para generar archivo usuarios Rips</para>
        /// </summary>
        public void fcvLeerRipsArchivoUsuarioAdm(tmpRipsAF tobRegFactura)
        {
            var lcrIdAdmision = tobRegFactura.Adm_secadm_rgad;
            tmpAdmision lobReAdm = null;
            if (tobRegAdmision == null)
            {
                lobReAdm = fobFiltroTempRegistroAdmision(lcrIdAdmision);
                if (lobReAdm != null)
                {
                    lobReAdm.Fcm_numfac_mfac = tobRegFactura.Fcm_numfac_mfac;
                    tobRegAdmision = lobReAdm;
                }
            }
            else
            {
                if (tobRegAdmision.Adm_secadm_rgad != lcrIdAdmision)
                {
                    lobReAdm = fobFiltroTempRegistroAdmision(lcrIdAdmision);
                    if (lobReAdm != null)
                    {
                        lobReAdm.Fcm_numfac_mfac = tobRegFactura.Fcm_numfac_mfac;
                        tobRegAdmision = lobReAdm;
                    }
                }
            }
            tobRegAdmision.Sia_codeps_teps = tobRegFactura.Sia_codeps_teps;
            //tobRegAdmision.Sia_tipusu_regi = tobRegFactura.Sia_tipusu_regi;
            // Agregar en admisiones 
            var lobReg = tmpRipsAdmision.FirstOrDefault(x => x.Adm_secadm_rgad == lcrIdAdmision);
            if (lobReg == null && lobReAdm != null)
            {
                tmpRipsAdmision.Add(lobReAdm);
            }

            // Agregar a lista Rips usuario
            //var lobRegUs = tmpRipsUsuarios.FirstOrDefault(x => x.Sia_idesec_usua == tobRegFactura.Sia_idesec_usua);
            if (lobReAdm != null)
            {
                var lobRegUs = tmpRipsUsuarios.FirstOrDefault(x => x.Sia_nroide_usua == lobReAdm.Sia_nroide_usua);
                if (lobRegUs == null)
                {
                    lobReAdm.Sia_tipusu_regi = tobRegFactura.Sia_tipusu_regi;
                    lobReAdm.Sia_codeps_teps = !String.IsNullOrWhiteSpace(this.txtG1Sia_codeps_teps.Text) ?
                                                                          this.txtG1Sia_codeps_teps.Text.Trim() : lobReAdm.Sia_codeps_teps;
                    tmpRipsUsuarios.Add(lobReAdm);
                }
            }
        }
        #endregion
        #region fcrLeerRipsArchivoHospitalizacion: Leer datos maestro hospitalizacion para generar archivo Rips
        /// <summary>
        /// <para>Leer datos maestro hospitalizacion para generar archivo Rips</para>
        /// </summary>
        public void fcrLeerRipsArchivoHospitalizacion(tmpRipsAF tobRegFactura)
        {
            var lcrIdAdmision = tobRegFactura.Adm_secadm_rgad;
            // Agregar en Registros Hospitalizacion 
            tobRegHospitaliz = fobFiltroTempRegistroHospitalizacion(lcrIdAdmision);
            if (tobRegHospitaliz != null)
            {
                var lobReg = tmpRipsHospitaliz.FirstOrDefault(x => x.Adm_secadm_rgad == lcrIdAdmision);
                if (lobReg == null)
                {
                    var lobRegHosp = fobFiltroTempRegistroHospitalizacion(lcrIdAdmision);
                    tmpRipsHospitaliz.Add(lobRegHosp);
                }
            }
        }
        #endregion
        #region fcrLeerRipsArchivoUrgencias: Leer datos maestro urgencias para generar archivo Rips
        /// <summary>
        /// <para>Leer datos maestro urgencias para generar archivo Rips</para>
        /// </summary>
        public void fcrLeerRipsArchivoUrgencias(tmpRipsAF tobRegFactura)
        {
            var lcrIdAdmision = tobRegFactura.Adm_secadm_rgad;
            // Agregar en Registros Urgencias 
            var lobRegUrgEx = fobFiltroTempRegistroUrgencias(lcrIdAdmision);
            //MessageBox.Show(" aqui voy1 " + lcrIdAdmision);
            if (lobRegUrgEx != null)
            {
                var lobReg = tmpRipsUrgencias.FirstOrDefault(x => x.Adm_secadm_rgad == lcrIdAdmision);
                if (lobReg == null)
                {
                    //MessageBox.Show(" aqui voy2 " + lcrIdAdmision);
                    var lobRegUrg = fobFiltroTempRegistroUrgencias(lcrIdAdmision);
                    tmpRipsUrgencias.Add(lobRegUrg);
                }
            }
        }
        #endregion
        #region fcrLeerRipsArchivoNacimientos: Leer datos maestro nacimientos para generar archivo Rips
        /// <summary>
        /// <para>Leer datos maestro nacimientos para generar archivo Rips nacimientos</para>
        /// </summary>
        public void fcrLeerRipsArchivoNacimientos(tmpRipsAF tobRegFactura)
        {
            var lcrIdAdmision = tobRegFactura.Adm_secadm_rgad;
            // Agregar en Registros Hospitalizacion 
            var lobReg = tmpRipsNacimientos.FirstOrDefault(x => x.Adm_secadm_rgad == lcrIdAdmision);
            if (lobReg == null && tobRegHospitaliz != null)
            {
                var lobRegNac = flsFiltroTempRegistroNacimientos(lcrIdAdmision);
                if (lobRegNac != null)
                {
                    foreach (var lobRegN in lobRegNac)
                    {
                        tmpRipsNacimientos.Add(lobRegN);
                    }
                }
            }
        }
        #endregion
        #region fcrLeerRipsArchivoDescAgrupada: Leer datos servicios facturados para generar archivo Rips Descripción agrupada
        /// <summary>
        /// <para>Leer datos servicios facturados para generar archivo Rips Descripción agrupada</para>
        /// </summary>
        public void fcrLeerRipsArchivoDescAgrupada(EFfcmmaedetallfac tobRegistro)
        {
            var lcrNumeroFactura = this.chkIncNumCuentaEnPlanos.IsChecked == true ? this.txtFacturaCuenta.Text : tobRegistro.fcm_numfac_mfac;

            // Agregar en Registros Hospitalizacion 
            var lobReg = tmpRipsDesAgrupada.FirstOrDefault(x => x.Fcm_numfac_mfac == lcrNumeroFactura &&
                                                                x.Sia_codrip_trip == tobRegistro.sia_codrip_trip);
            if (lobReg == null)
            {
                var lobRegAD = new tmpRipsAD();

                lobRegAD.Fcm_numfac_mfac = lcrNumeroFactura;
                lobRegAD.IPSCodPrestador = lcrPrmIPSCodigoPrestador;
                lobRegAD.Sia_codrip_trip = tobRegistro.sia_codrip_trip;
                lobRegAD.Fcm_totuni_dfac = (int)tobRegistro.fcm_totuni_dfac;
                lobRegAD.Fcm_valser_mant = (int)tobRegistro.fcm_valser_mant;
                lobRegAD.Fcm_valfac_dfac = (int)tobRegistro.fcm_valfac_dfac;

                tmpRipsDesAgrupada.Add(lobRegAD);
            }
            else 
            {
                lobReg.Fcm_totuni_dfac += (int)tobRegistro.fcm_totuni_dfac;
                lobReg.Fcm_valser_mant = (int)tobRegistro.fcm_valser_mant;
                lobReg.Fcm_valfac_dfac += (int)tobRegistro.fcm_valfac_dfac;
            }
        }
        #endregion
        //----------------------------------------------------------------------
        //  FILTRO DE TEMPORALES
        //----------------------------------------------------------------------
        #region flsFiltroTempMaestroFactCuentas: (FILTRO) Maestro factura general desde cuentas
        /// <summary>
        /// <para>(FILTRO) Maestro factura general desde cuentas</para>
        /// </summary>
        public List<tmpRipsAF> flsFiltroTempMaestroFactCuentas()
        {
            List<tmpRipsAF> tmpDatos = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                #region Filtro
                tmpDatos = (from facturas in db.Fcmmaesfacturas
                            join factcuentas in db.Fcmcuentacobrde on facturas.fcm_numfac_mfac equals factcuentas.fcm_numfac_mfac
                            join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                            join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                            where factcuentas.fcm_secreg_mfcb == lcrPrmCodigoCuenta
                            orderby facturas.fcm_numfac_mfac
                            select new tmpRipsAF
                            {
                                #region Rips Transacciones
                                IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                IPSNombreEmpresa = lcrPrmIPSNombre,
                                IPSTipoNit = lcrPrmIPSTipoNit,
                                IPSCodigoNit = lcrPrmIPSCodigoNit,
                                Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                Sia_codeps_teps = facturas.sia_codeps_teps,
                                EpsNombre = tablaeps.sia_deseps_teps,
                                ContratoNumero = facturas.cto_nrocon_cont,
                                ContratoPlanBen = contrato.cto_plaben_cont,
                                ContratoPoliza = contrato.cto_polcon_cont,
                                ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                ValorComision = (int)facturas.fcm_valcom_dfac,
                                ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                ValorFactura = (int)facturas.fcm_valfac_dfac,
                                Sia_idesec_usua = facturas.sia_idesec_usua,
                                Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                Cto_seccon_cont = facturas.cto_seccon_cont,
                                Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                #endregion
                            }).ToList();
                #endregion
            }
            return tmpDatos;
        }
        #endregion
        #region flsFiltroTempMaestroFacturas: (FILTRO) Maestro factura general sin separar
        /// <summary>
        /// <para>(FILTRO) Maestro factura general sin separar</para>
        /// </summary>
        public List<tmpRipsAF> flsFiltroTempMaestroFacturas()
        {
            List<tmpRipsAF> tmpDatos = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                    !String.IsNullOrWhiteSpace(lcrPrmCodigoEps) &&
                    !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //Contrato Eps y Regimen
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador  = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa    = lcrPrmIPSNombre,
                                    IPSTipoNit          = lcrPrmIPSTipoNit,
                                    IPSCodigoNit        = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac     = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac     = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo     = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo     = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps     = facturas.sia_codeps_teps,
                                    EpsNombre           = tablaeps.sia_deseps_teps,
                                    ContratoNumero      = facturas.cto_nrocon_cont,
                                    ContratoPlanBen     = contrato.cto_plaben_cont,
                                    ContratoPoliza      = contrato.cto_polcon_cont,
                                    ValorCopago         = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision        = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen        = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura        = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua     = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad     = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont     = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi     = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                         !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //Contrato y Regimen
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                         !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                {
                    //Contrato y Eps
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
                {
                    //Contrato 
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps) &&
                         !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    // EPS y regimen
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                {
                    // EPS
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    // Regimen
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else
                {
                    // Solo fechas
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
            }
            return tmpDatos;
        }
        #endregion
        #region flsFiltroTempMaestroFacturaAsistPyP: (FILTRO) Maestro factura separadas por Asistencial y PyP
        /// <summary>
        /// <para>(FILTRO) Maestro factura separadas por Asistencial y PyP</para>
        /// </summary>
        public List<tmpRipsAF> flsFiltroTempMaestroFacturaAsistPyP()
        {
            List<tmpRipsAF> tmpDatos = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                    !String.IsNullOrWhiteSpace(lcrPrmCodigoEps) &&
                    !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //Contrato Eps y Regimen
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                         !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //Contrato y Regimen
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                         !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                {
                    //Contrato y Eps
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
                {
                    //Contrato 
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps) &&
                         !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    // EPS y regimen
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                {
                    // EPS
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    // Regimen
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
                else
                {
                    // Solo fechas
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
                }
            }
            return tmpDatos;
        }
        #endregion
        #region flsFiltroTempDetallesServFactCuentas: Detalles servicios en facturacion desde filtro y todas la actividades
        /// <summary>
        /// <para>Detalles servicios en facturacion desde Cuentas de cobro</para>
        /// <para>genera el temporal de servicios facturados (detalles de facturación)</para>
        /// <para>Rips: AC=Consultas/AP=Procedimientos/AM=Medicamentos/AT=Otros Servicios</para>
        /// </summary>
        public List<EFfcmmaedetallfac> flsFiltroTempDetallesServFactCuentas()
        {
            List<EFfcmmaedetallfac> tmpDatos = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                #region Filtro
                tmpDatos = (from detalles in db.Fcmmaedetallfac
                            join factcuentas in db.Fcmcuentacobrde on detalles.fcm_numfac_mfac equals factcuentas.fcm_numfac_mfac
                            where factcuentas.fcm_secreg_mfcb == lcrPrmCodigoCuenta
                            orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                            select detalles).ToList();
                #endregion
            }
            return tmpDatos;
        }
        #endregion
        #region flsFiltroTempDetallesServiciosFacturados: Detalles servicios en facturacion desde filtro y todas la actividades
        /// <summary>
        /// <para>Detalles servicios en facturacion desde filtro y todas la actividades(no estan separados por PyP)</para>
        /// <para>Desde Tipo Filtro, genera el temporal de servicios facturados (detalles de facturación)</para>
        /// <para>Rips: AC=Consultas/AP=Procedimientos/AM=Medicamentos/AT=Otros Servicios</para>
        /// </summary>
        public List<EFfcmmaedetallfac> flsFiltroTempDetallesServiciosFacturados()
        {
            List<EFfcmmaedetallfac> tmpDatos = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                    !String.IsNullOrWhiteSpace(lcrPrmCodigoEps) &&
                    !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //Contrato Eps y Regimen
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                join contrato in db.Ctomaescontrato on detalles.cto_seccon_cont equals contrato.cto_seccon_cont
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                         !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //Contrato y Regimen
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                join contrato in db.Ctomaescontrato on detalles.cto_seccon_cont equals contrato.cto_seccon_cont
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                         !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                {
                    //Contrato y Eps
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
                {
                    //Contrato 
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps) && 
                         !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    // EPS y regimen
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                join contrato in db.Ctomaescontrato on detalles.cto_seccon_cont equals contrato.cto_seccon_cont
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                {
                    // EPS
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    // EPS y regimen
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                join contrato in db.Ctomaescontrato on detalles.cto_seccon_cont equals contrato.cto_seccon_cont
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else
                {
                    // Solo fechas
                    #region Filtro 
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
            }
            return tmpDatos;
        }
        #endregion
        #region flsFiltroTempDetallesServiciosAsistPyP: (FILTRO) Detalles servicios en facturacion separados por Asistencial y PyP
        /// <summary>
        /// <para>(FILTRO) Detalles servicios en facturacion separados por Asistencial y PyP</para>
        /// <para>Desde Tipo Filtro, genera el temporal de servicios facturados (detalles de facturación)</para>
        /// <para>Rips: AC=Consultas/AP=Procedimientos/AM=Medicamentos/AT=Otros Servicios</para>
        /// </summary>
        public List<EFfcmmaedetallfac> flsFiltroTempDetallesServiciosAsistPyP()
        {
            List<EFfcmmaedetallfac> tmpDatos = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                    !String.IsNullOrWhiteSpace(lcrPrmCodigoEps) &&
                    !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //Contrato Eps y Regimen
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                join contrato in db.Ctomaescontrato on detalles.cto_seccon_cont equals contrato.cto_seccon_cont
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                         !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    //Contrato y Regimen
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                join contrato in db.Ctomaescontrato on detalles.cto_seccon_cont equals contrato.cto_seccon_cont
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato) &&
                         !String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                {
                    //Contrato y Eps
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                    //MessageBox.Show("AQUI VOY / ASIS / PYP / Contrato y Eps : " + tmpDatos.Count.ToString());
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoContrato))
                {
                    //Contrato 
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps) &&
                         !String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    // EPS y regimen
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                join contrato in db.Ctomaescontrato on detalles.cto_seccon_cont equals contrato.cto_seccon_cont
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmCodigoEps))
                {
                    // EPS
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else if (!String.IsNullOrWhiteSpace(lcrPrmRegimenSalud))
                {
                    // EPS y regimen
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                join contrato in db.Ctomaescontrato on detalles.cto_seccon_cont equals contrato.cto_seccon_cont
                                where contrato.sia_tipusu_regi == lcrPrmRegimenSalud &&
                                      facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
                else
                {
                    // Solo fechas
                    #region Filtro
                    tmpDatos = (from detalles in db.Fcmmaedetallfac
                                join facturas in db.Fcmmaesfacturas on detalles.fcm_numfac_mfac equals facturas.fcm_numfac_mfac
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.sia_tipact_tsac == lcrPrmTipoActividad &&
                                      facturas.fcm_estfac_mfac == "2" && facturas.fcm_numfac_mfac != ""
                                orderby detalles.sia_codrip_trip, detalles.fcm_numfac_mfac
                                select detalles).ToList();
                    #endregion
                }
            }
            return tmpDatos;
        }
        #endregion
        #region fobFiltroTempRegistroAdmision: Retorna un registro admision completo con datos para Rips de Usuario
        /// <summary>
        /// Retorna un registro admision completo con datos para Rips de Usuario
        /// </summary>
        public static tmpAdmision fobFiltroTempRegistroAdmision(String tcrCodigoAdmision)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                // adm_secadm_rgad = 'VAC12YE25R00304'
                //tmpAdmision lobConsulta = null;
                #region Consulta
                /*
                if (tcrCodigoAdmision == "VAC12YE25R00304" || tcrCodigoAdmision == "VAC12YE25R00356"
                    || tcrCodigoAdmision == "VAC12YE25R00251")
                {
                    lobConsulta = (from admregadmision in db.Admregadmision
                                   join usua in db.Siausuarioatend on admregadmision.sia_idesec_usua equals usua.sia_idesec_usua
                                   where admregadmision.adm_secadm_rgad == tcrCodigoAdmision
                                   select new tmpAdmision
                                   {
                                       #region Datos
                                       Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                       Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                       Sia_tipide_tide = usua.sia_tipide_tide,
                                       Sia_nroide_usua = usua.sia_nroide_usua,
                                       //Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                       Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                       Adm_pacemb_rgad = admregadmision.adm_pacemb_rgad,
                                       Adm_codoad_toad = admregadmision.adm_codoad_toad,
                                       Adm_codtat_tatn = admregadmision.adm_codtat_tatn,
                                       Adm_codcex_tcex = admregadmision.adm_codcex_tcex,
                                       Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                       //Adm_fechos_rgad = (DateTime)admregadmision.adm_fechos_rgad,
                                       Adm_horhos_rgad = (Decimal)admregadmision.adm_horhos_rgad,
                                       Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                       Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                       Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                       Sia_edapac_usua = (int)admregadmision.sia_edapac_usua,
                                       Sia_codmed_tmed = admregadmision.sia_codmed_tmed,
                                       Adm_nroaut_rgad = admregadmision.adm_nroaut_rgad,
                                       Sia_tipusu_regi = admregadmision.sia_tipusu_regi,
                                       Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                       Sia_codfco_fcon = admregadmision.sia_codfco_fcon,
                                       Sia_coddia_tdia = admregadmision.sia_coddia_tdia,
                                       Sia_tipdxp_tdix = admregadmision.sia_tipdxp_tdix,
                                       Adm_dessal_regr = admregadmision.adm_dessal_regr,
                                       Sia_dixre1_tdia = admregadmision.sia_dixre1_tdia,
                                       Sia_dixre2_tdia = admregadmision.sia_dixre2_tdia,
                                       Sia_dixre3_tdia = admregadmision.sia_dixre3_tdia,
                                       Sia_priape_usua = usua.sia_priape_usua,
                                       Sia_segape_usua = usua.sia_segape_usua,
                                       Sia_prinom_usua = usua.sia_prinom_usua,
                                       Sia_segnom_usua = usua.sia_segnom_usua,
                                       //Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                       Sis_codsex_sexo = usua.sis_codsex_sexo,
                                       Sis_coddep_dpto = usua.sis_coddep_dpto,
                                       Sis_codmun_muni = usua.sis_codmun_muni,
                                       Sis_zonres_tzon = usua.sis_zonres_tzon,
                                       #endregion
                                   }).FirstOrDefault();
                }
                else
                {
                    lobConsulta = (from admregadmision in db.Admregadmision
                                   join usua in db.Siausuarioatend on admregadmision.sia_idesec_usua equals usua.sia_idesec_usua
                                   where admregadmision.adm_secadm_rgad == tcrCodigoAdmision
                                   select new tmpAdmision
                                   {
                                       #region Datos
                                       Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                       Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                       Sia_tipide_tide = usua.sia_tipide_tide,
                                       Sia_nroide_usua = usua.sia_nroide_usua,
                                       Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                       Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                       Adm_pacemb_rgad = admregadmision.adm_pacemb_rgad,
                                       Adm_codoad_toad = admregadmision.adm_codoad_toad,
                                       Adm_codtat_tatn = admregadmision.adm_codtat_tatn,
                                       Adm_codcex_tcex = admregadmision.adm_codcex_tcex,
                                       Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                       Adm_fechos_rgad = (DateTime)admregadmision.adm_fechos_rgad,
                                       Adm_horhos_rgad = (Decimal)admregadmision.adm_horhos_rgad,
                                       Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                       Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                       Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                       Sia_edapac_usua = (int)admregadmision.sia_edapac_usua,
                                       Sia_codmed_tmed = admregadmision.sia_codmed_tmed,
                                       Adm_nroaut_rgad = admregadmision.adm_nroaut_rgad,
                                       Sia_tipusu_regi = admregadmision.sia_tipusu_regi,
                                       Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                       Sia_codfco_fcon = admregadmision.sia_codfco_fcon,
                                       Sia_coddia_tdia = admregadmision.sia_coddia_tdia,
                                       Sia_tipdxp_tdix = admregadmision.sia_tipdxp_tdix,
                                       Adm_dessal_regr = admregadmision.adm_dessal_regr,
                                       Sia_dixre1_tdia = admregadmision.sia_dixre1_tdia,
                                       Sia_dixre2_tdia = admregadmision.sia_dixre2_tdia,
                                       Sia_dixre3_tdia = admregadmision.sia_dixre3_tdia,
                                       Sia_priape_usua = usua.sia_priape_usua,
                                       Sia_segape_usua = usua.sia_segape_usua,
                                       Sia_prinom_usua = usua.sia_prinom_usua,
                                       Sia_segnom_usua = usua.sia_segnom_usua,
                                       Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                       Sis_codsex_sexo = usua.sis_codsex_sexo,
                                       Sis_coddep_dpto = usua.sis_coddep_dpto,
                                       Sis_codmun_muni = usua.sis_codmun_muni,
                                       Sis_zonres_tzon = usua.sis_zonres_tzon,
                                       #endregion
                                   }).FirstOrDefault();

                }

                return lobConsulta;
                */
                #endregion

                #region Consulta
                
                var lobConsulta = (from admregadmision in db.Admregadmision
                                   join usua in db.Siausuarioatend on admregadmision.sia_idesec_usua equals usua.sia_idesec_usua
                                  where admregadmision.adm_secadm_rgad == tcrCodigoAdmision
                                  select new tmpAdmision
                                  {
                                      #region Datos
                                      Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                      Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                      Sia_tipide_tide = usua.sia_tipide_tide,
                                      Sia_nroide_usua = usua.sia_nroide_usua,
                                      Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                      Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                      Adm_pacemb_rgad = admregadmision.adm_pacemb_rgad,
                                      Adm_codoad_toad = admregadmision.adm_codoad_toad,
                                      Adm_codtat_tatn = admregadmision.adm_codtat_tatn,
                                      Adm_codcex_tcex = admregadmision.adm_codcex_tcex,
                                      Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                      Adm_fechos_rgad = (DateTime)admregadmision.adm_fechos_rgad,
                                      Adm_horhos_rgad = (Decimal)admregadmision.adm_horhos_rgad,
                                      Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                      Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                      Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                      Sia_edapac_usua = (int)admregadmision.sia_edapac_usua,
                                      Sia_codmed_tmed = admregadmision.sia_codmed_tmed,
                                      Adm_nroaut_rgad = admregadmision.adm_nroaut_rgad,
                                      Sia_tipusu_regi = admregadmision.sia_tipusu_regi,
                                      Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                      Sia_codfco_fcon = admregadmision.sia_codfco_fcon,
                                      Sia_coddia_tdia = admregadmision.sia_coddia_tdia,
                                      Sia_tipdxp_tdix = admregadmision.sia_tipdxp_tdix,
                                      Adm_dessal_regr = admregadmision.adm_dessal_regr,
                                      Sia_dixre1_tdia = admregadmision.sia_dixre1_tdia,
                                      Sia_dixre2_tdia = admregadmision.sia_dixre2_tdia,
                                      Sia_dixre3_tdia = admregadmision.sia_dixre3_tdia,
                                      Sia_priape_usua = usua.sia_priape_usua,
                                      Sia_segape_usua = usua.sia_segape_usua,
                                      Sia_prinom_usua = usua.sia_prinom_usua,
                                      Sia_segnom_usua = usua.sia_segnom_usua,
                                      Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                      Sis_codsex_sexo = usua.sis_codsex_sexo,
                                      Sis_coddep_dpto = usua.sis_coddep_dpto,
                                      Sis_codmun_muni = usua.sis_codmun_muni,
                                      Sis_zonres_tzon = usua.sis_zonres_tzon,
                                      #endregion
                                  }).FirstOrDefault();

                return lobConsulta;
                #endregion
                #region Consulta
                /*
                var lobConsulta = (from admregadmision in db.Admregadmision
                                   join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   where admregadmision.adm_secadm_rgad == tcrCodigoAdmision
                                   select new tmpAdmision
                                   {
                                       #region Datos
                                       Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                       Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                       Sia_tipide_tide = usua.sia_tipide_tide,
                                       Sia_nroide_usua = usua.sia_nroide_usua,
                                       Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                       Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                       Adm_pacemb_rgad = admregadmision.adm_pacemb_rgad,
                                       Adm_codoad_toad = admregadmision.adm_codoad_toad,
                                       Adm_codtat_tatn = admregadmision.adm_codtat_tatn,
                                       Adm_codcex_tcex = admregadmision.adm_codcex_tcex,
                                       Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                       Adm_fechos_rgad = (DateTime)admregadmision.adm_fechos_rgad,
                                       Adm_horhos_rgad = (Decimal)admregadmision.adm_horhos_rgad,
                                       Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                       Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                       Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                       Sia_edapac_usua = (int)admregadmision.sia_edapac_usua,
                                       Sia_codmed_tmed = admregadmision.sia_codmed_tmed,
                                       Adm_nroaut_rgad = admregadmision.adm_nroaut_rgad,
                                       Sia_tipusu_regi = admregadmision.sia_tipusu_regi,
                                       Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                       Sia_codfco_fcon = admregadmision.sia_codfco_fcon,
                                       Sia_coddia_tdia = admregadmision.sia_coddia_tdia,
                                       Sia_tipdxp_tdix = admregadmision.sia_tipdxp_tdix,
                                       Adm_dessal_regr = admregadmision.adm_dessal_regr,
                                       Sia_dixre1_tdia = admregadmision.sia_dixre1_tdia,
                                       Sia_dixre2_tdia = admregadmision.sia_dixre2_tdia,
                                       Sia_dixre3_tdia = admregadmision.sia_dixre3_tdia,
                                       Sia_priape_usua = usua.sia_priape_usua,
                                       Sia_segape_usua = usua.sia_segape_usua,
                                       Sia_prinom_usua = usua.sia_prinom_usua,
                                       Sia_segnom_usua = usua.sia_segnom_usua,
                                       Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                       Sis_codsex_sexo = usua.sis_codsex_sexo,
                                       Sis_coddep_dpto = usua.sis_coddep_dpto,
                                       Sis_codmun_muni = usua.sis_codmun_muni,
                                       Sis_zonres_tzon = usua.sis_zonres_tzon,
                                       #endregion
                                   }).FirstOrDefault();

                return lobConsulta;
                */
                #endregion

            }
        }
        #endregion
        #region fobFiltroTempRegistroHospitalizacion: Retorna un registro de hospitalizacion completo con datos para Rips Hospitalizacion
        /// <summary>
        /// Retorna un registro de hospitalizacion completo con datos para Rips Hospitalizacion
        /// </summary>
        public static tmpRipsAH fobFiltroTempRegistroHospitalizacion(String tcrCodigoAdmision)
        {
            tmpRipsAH lobConsulta = null;

            using (DbAplicacion db = new DbAplicacion())
            {
                #region Consulta
                var lobConsultaSql = (from tmpHosp in db.Admregistegreso
                                   where tmpHosp.adm_secadm_rgad == tcrCodigoAdmision &&
                                         tmpHosp.sis_estpro_espr!="3"
                                   select new tmpRipsAH
                                   {
                                       #region Datos
                                       Fcm_numfac_mfac = tobRegAdmision.Fcm_numfac_mfac,
                                       IPSCodPrestador = lcrPrmIPSCodigoPrestador,
                                       Sia_idesec_usua = tobRegAdmision.Sia_idesec_usua,
                                       Sia_tipide_tide = tobRegAdmision.Sia_tipide_tide,
                                       Sia_nroide_usua = tobRegAdmision.Sia_nroide_usua,
                                       Adm_codoad_toad = tobRegAdmision.Adm_codoad_toad,
                                       Adm_horhos_rgad = tobRegAdmision.Adm_horhos_rgad,
                                       Adm_nroaut_rgad = tobRegAdmision.Adm_nroaut_rgad,
                                       Adm_codcex_tcex = tobRegAdmision.Adm_codcex_tcex,
                                       Sia_dixing_tdia = tmpHosp.sia_dixing_tdia,
                                       Sia_dixsal_tdia = tmpHosp.sia_dixsal_tdia,
                                       Sia_dixre1_tdia = tmpHosp.sia_dixre1_tdia,
                                       Sia_dixre2_tdia = tmpHosp.sia_dixre2_tdia,
                                       Sia_dixre3_tdia = tmpHosp.sia_dixre3_tdia,
                                       Sia_dixcom_tdia = tmpHosp.sia_dixcom_tdia,
                                       Adm_estsal_regr = tmpHosp.adm_estsal_regr,
                                       Sia_dixmue_tdia = tmpHosp.sia_dixmue_tdia,
                                       Adm_fecegr_regr = (DateTime)tmpHosp.adm_fecegr_regr,
                                       Adm_horegr_regr = (decimal)tmpHosp.adm_horegr_regr,
                                       Adm_secadm_rgad = tmpHosp.adm_secadm_rgad,
                                       Adm_secegr_regr = tmpHosp.adm_secegr_regr,
                                       Adm_semges_regr = (int)tmpHosp.adm_semges_regr,
                                       Adm_contrl_regr = tmpHosp.adm_contrl_regr,
                                       #endregion
                                   }).FirstOrDefault();

                if (lobConsultaSql != null) 
                {
                    lobConsulta = lobConsultaSql;
                    lobConsulta.Adm_fechos_rgad = tobRegAdmision.Adm_fechos_rgad;
                }
                return lobConsulta;
                #endregion
            }
        }
        #endregion
        #region fobFiltroTempRegistroUrgencias: Retorna un registro de urgencias completo con datos para Rips Urgencias
        /// <summary>
        /// Retorna un registro de urgencias completo con datos para Rips Urgencias
        /// </summary>
        public static tmpRipsAU fobFiltroTempRegistroUrgencias(String tcrCodigoAdmision)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                #region Consulta
                var lobConsulta = (from tmpUrgen in db.Admregurgencias
                                   where tmpUrgen.adm_secadm_rgad == tcrCodigoAdmision &&
                                         tmpUrgen.sis_estpro_espr != "3"
                                   orderby tmpUrgen.adm_fecegr_regu
                                   select new tmpRipsAU
                                   {
                                       #region Datos
                                       Fcm_numfac_mfac = tobRegAdmision.Fcm_numfac_mfac,
                                       IPSCodPrestador = lcrPrmIPSCodigoPrestador,
                                       Sia_tipide_tide = tobRegAdmision.Sia_tipide_tide,
                                       Sia_nroide_usua = tobRegAdmision.Sia_nroide_usua,
                                       Adm_horurg_rgad = tobRegAdmision.Adm_horadm_rgad,
                                       Adm_nroaut_rgad = tobRegAdmision.Adm_nroaut_rgad,
                                       Adm_codcex_tcex = tobRegAdmision.Adm_codcex_tcex,
                                       Sia_dixsal_tdia = tmpUrgen.sia_dixsal_tdia,
                                       Sia_dixre1_tdia = tmpUrgen.sia_dixre1_tdia,
                                       Sia_dixre2_tdia = tmpUrgen.sia_dixre2_tdia,
                                       Sia_dixre3_tdia = tmpUrgen.sia_dixre3_tdia,
                                       Adm_dessal_regr = tmpUrgen.adm_dessal_regr,
                                       Adm_estsal_regu = tmpUrgen.adm_estsal_regu,
                                       Sia_dixmue_tdia = tmpUrgen.sia_dixmue_tdia,
                                       Adm_fecegr_regu = (DateTime)tmpUrgen.adm_fecegr_regu,
                                       Adm_horegr_regu = (decimal)tmpUrgen.adm_horegr_regu,
                                       Adm_secegr_regu = tmpUrgen.adm_secegr_regu,
                                       Adm_secadm_rgad = tmpUrgen.adm_secadm_rgad,
                                       Sia_idesec_usua = tobRegAdmision.Sia_idesec_usua,
                                       #endregion
                                   }).FirstOrDefault();

                if (lobConsulta != null)
                {
                    lobConsulta.Adm_fecurg_rgad = tobRegAdmision.Adm_fecadm_rgad;
                }
                return lobConsulta;
                #endregion
            }
        }
        #endregion
        #region flsFiltroTempRegistroNacimientos: Retorna lista registros de nacimientos con datos para Rips
        /// <summary>
        ///Retorna lista registros de nacimientos con datos para Rips
        /// </summary>
        public static List<tmpRipsAN> flsFiltroTempRegistroNacimientos(String tcrCodigoAdmision)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                #region Consulta
                var lobConsulta = (from tmpNaci in db.Admregnacimient
                                   where tmpNaci.adm_secadm_rgad == tcrCodigoAdmision &&
                                         tmpNaci.sis_estpro_espr != "3"
                                   select new tmpRipsAN
                                   {
                                       #region Datos
                                       Fcm_numfac_mfac = tobRegAdmision.Fcm_numfac_mfac,
                                       IPSCodPrestador = lcrPrmIPSCodigoPrestador,
                                       Sia_tipide_tide = tobRegAdmision.Sia_tipide_tide,
                                       Sia_nroide_usua = tobRegAdmision.Sia_nroide_usua,
                                       Adm_fecnac_regn = (DateTime)tmpNaci.adm_fecnac_regn,
                                       Adm_hornac_regn = (decimal)tmpNaci.adm_hornac_regn,
                                       Adm_semges_regr = tobRegHospitaliz.Adm_semges_regr,
                                       Adm_contrl_regr = tobRegHospitaliz.Adm_contrl_regr,
                                       Sis_codsex_sexo = tmpNaci.sis_codsex_sexo,
                                       Adm_peson_regn = (int)tmpNaci.adm_peson_regn,
                                       Sia_dixnac_tdia = tmpNaci.sia_dixnac_tdia,
                                       Sia_dixmue_tdia = tmpNaci.sia_dixmue_tdia,
                                       Adm_fecmue_regn = (DateTime)tmpNaci.adm_fecmue_regn,
                                       Adm_hormue_regn = (decimal)tmpNaci.adm_hormue_regn,
                                       Adm_secegr_regn = tmpNaci.adm_secegr_regn,
                                       Adm_secadm_rgad = tmpNaci.adm_secadm_rgad,
                                       Sia_idesec_usua = tmpNaci.sia_idesec_usua
                                       #endregion
                                   }).ToList();
                return lobConsulta;
                #endregion
            }
        }
        #endregion
        // comprobar si cumple filtro avanzado
        #region fcrGuardarGenerarNombreArchivo: Generar el nombre unico del archivo
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
        //----------------------------------------------------------------------
        // PROCESO GESTION RIPS AUXILIAR POR ACTIVIDAD SIN FACTURAS
        //----------------------------------------------------------------------
        #region flsAuxFiltroTempMaestroFactura: (FILTRO) Maestro todas las facturas sin separar
        /// <summary>
        /// <para>(FILTRO) Maestro todas las facturas sin separar</para>
        /// </summary>
        public List<tmpRipsAF> flsAuxFiltroTempMaestroFactura()
        {
            List<tmpRipsAF> tmpDatos = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                    //Contrato Eps y Regimen
                    #region Filtro
                    tmpDatos = (from facturas in db.Fcmmaesfacturas
                                join contrato in db.Ctomaescontrato on facturas.cto_seccon_cont equals contrato.cto_seccon_cont
                                join tablaeps in db.Siatablaeps on facturas.sia_codeps_teps equals tablaeps.sia_codeps_teps
                                where facturas.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                      facturas.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                      facturas.cto_seccon_cont == lcrPrmCodigoContrato &&
                                      facturas.sia_codeps_teps == lcrPrmCodigoEps &&
                                      facturas.fcm_estfac_mfac == "2"
                                orderby facturas.fcm_numfac_mfac
                                select new tmpRipsAF
                                {
                                    #region Rips Transacciones
                                    IPSCodigoPrestador = lcrPrmIPSCodigoPrestador,
                                    IPSNombreEmpresa = lcrPrmIPSNombre,
                                    IPSTipoNit = lcrPrmIPSTipoNit,
                                    IPSCodigoNit = lcrPrmIPSCodigoNit,
                                    Fcm_numfac_mfac = facturas.fcm_numfac_mfac,
                                    Fcm_fecfac_mfac = (DateTime)facturas.fcm_fecfac_mfac,
                                    FechaIniPeriodo = lcrPrmFechaInicioFiltro,
                                    FechaFinPeriodo = lcrPrmFechaFinFiltro,
                                    Sia_codeps_teps = facturas.sia_codeps_teps,
                                    EpsNombre = tablaeps.sia_deseps_teps,
                                    ContratoNumero = facturas.cto_nrocon_cont,
                                    ContratoPlanBen = contrato.cto_plaben_cont,
                                    ContratoPoliza = contrato.cto_polcon_cont,
                                    ValorCopago = (int)facturas.fcm_valcpa_dfac,
                                    ValorComision = (int)facturas.fcm_valcmo_dfac,
                                    ValorDescuen = (int)facturas.fcm_valdes_dfac,
                                    ValorFactura = (int)facturas.fcm_valfac_dfac,
                                    Sia_idesec_usua = facturas.sia_idesec_usua,
                                    Adm_secadm_rgad = facturas.adm_secadm_rgad,
                                    Cto_seccon_cont = facturas.cto_seccon_cont,
                                    Sia_tipusu_regi = contrato.sia_tipusu_regi,
                                    #endregion
                                }).ToList();
                    #endregion
            }
            return tmpDatos;
        }
        #endregion
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
                            where detalles.fcm_fecfac_mfac >= ldaPrmFechaInicioFiltro &&
                                  detalles.fcm_fecfac_mfac <= ldaPrmFechaFinFiltro &&
                                  detalles.cto_seccon_cont == lcrPrmCodigoContrato &&
                                  detalles.sia_codeps_teps == lcrPrmCodigoEps &&
                                  detalles.sia_tipact_tsac == lcrPrmTipoActividad &&
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
        #region tmpRipsAD: Estructura temporal Rips Descripción agrupada
        /// <summary>
        /// <para>Estructura temporal Rips Descripción agrupada</para>
        /// </summary>
        public class tmpRipsAD
        {
            #region Rips Descripcion agrupada
            ///<summary>Numero de la factura generada en el cierre de facturación</summary>
            public String Fcm_numfac_mfac { get; set; }
            ///<summary>Codigo Prestador servicios IPS</summary>
            public String IPSCodPrestador { get; set; }
            ///<summary>Codigo clasificacion servicio según Resolucion 3374 RIPS: 01=Consulta 02= Procedimientos y mas</summary>
            public String Sia_codrip_trip { get; set; }
            ///<summary>Total unidades del servicio (sumatoria)</summary>
            public int Fcm_totuni_dfac { get; set; }
            ///<summary>Valor unidades del servicio</summary>
            public int Fcm_valser_mant { get; set; }
            ///<summary>Valor total (sumatoria del servicio)</summary>
            public int Fcm_valfac_dfac { get; set; }
            #endregion
        }
        #endregion
        #region tmpRipsAF: Estructura temporal Rips Archivo Transacciones
        /// <summary>
        /// <para>Estructura temporal Rips Archivo Transacciones</para>
        /// </summary>
        public class tmpRipsAF
        {
            #region Rips Transacciones
            public String IPSCodigoPrestador { get; set; }
            public String IPSNombreEmpresa { get; set; }
            public String IPSTipoNit { get; set; }
            public String IPSCodigoNit { get; set; }
            ///<summary>Numero de la factura generada en el cierre de facturación</summary>
            public String Fcm_numfac_mfac { get; set; }
            ///<summary>Fecha de la factura (fecha en que fue cerrada y generado el secuencial de factrua)</summary>
            public DateTime Fcm_fecfac_mfac { get; set; }
            public String FechaIniPeriodo { get; set; }
            public String FechaFinPeriodo { get; set; }
            public String Sia_codeps_teps { get; set; }
            public String EpsNombre { get; set; }
            public String ContratoNumero { get; set; }
            public String ContratoPlanBen { get; set; }
            public String ContratoPoliza { get; set; }
            public int ValorCopago { get; set; }
            public int ValorComision { get; set; }
            public int ValorDescuen { get; set; }
            public int ValorFactura { get; set; }
            // Parametros adicionales
            ///<summary>Consecutivo Único de paciente en el sistema</summary>
            public String Sia_idesec_usua { get; set; }
            ///<summary>Tipo identificacion del usuario</summary>
            public String Sia_tipide_tide { get; set; }
            ///<summary>Numero de identificacion del usuario</summary>
            public String Sia_nroide_usua { get; set; }
            ///<summary>Secuencial de Admisión</summary>
            public String Adm_secadm_rgad { get; set; }
            ///<summary>Secuencial Único de Contrato</summary>
            public String Cto_seccon_cont { get; set; }
            ///<summary>Tipo Usuario segun regimen de salud: 1=Contributivo 2= Subsidiado y 3 = ...</summary>
            public String Sia_tipusu_regi { get; set; }
            ///<summary>Numero de autorizacion</summary>
            public String Adm_nroaut_rgad { get; set; }
            public String Marca { get; set; }
            #endregion
        }
        #endregion
        #region tmpRipsAH: Estructura temporal Rips hospitalización
        /// <summary>
        /// <para>Estructura temporal Rips hospitalización</para>
        /// </summary>
        public class tmpRipsAH
        {
            #region Datos hospitalización
            ///<summary>Numero de la factura generada en el cierre de facturación</summary>
            public String Fcm_numfac_mfac { get; set; }
            ///<summary>Codigo Prestador servicios IPS</summary>
            public String IPSCodPrestador { get; set; }
            ///<summary>Tipo identificación del usuario o Paciente</summary>
            public String Sia_tipide_tide { get; set; }
            ///<summary>Numero de identificación del paciente: Registro civil...</summary>
            public String Sia_nroide_usua { get; set; }
            ///<summary>Origen de Admisión o vía de ingreso a la institución</summary>
            public String Adm_codoad_toad { get; set; }
            ///<summary>Fecha en que Inicia Hospitalización</summary>
            public DateTime Adm_fechos_rgad { get; set; }
            ///<summary>Hora en que Inicia Hospitalización</summary>
            public decimal Adm_horhos_rgad { get; set; }
            ///<summary>Numero Autorización Admisión solicitada a la EPS o Asegurador</summary>
            public String Adm_nroaut_rgad { get; set; }
            ///<summary>Causa Externa Origen que origina la atención según Resolución: 3374 RIPS</summary>
            public String Adm_codcex_tcex { get; set; }
            ///<summary>Diagnostico de Ingreso a hospitalización/Urgencias con Observación</summary>
            public String Sia_dixing_tdia { get; set; }
            ///<summary>Diagnostico de salida hospitalizacion según CIE-10</summary>
            public String Sia_dixsal_tdia { get; set; }
            ///<summary>Diagnostico relacionado 1 según CIE-10</summary>
            public String Sia_dixre1_tdia { get; set; }
            ///<summary>Diagnostico relacionado 2 según CIE-10</summary>
            public String Sia_dixre2_tdia { get; set; }
            ///<summary>Diagnostico relacionado 3 según CIE-10</summary>
            public String Sia_dixre3_tdia { get; set; }
            ///<summary>Diagnostico de la complicacion cuando exista según CIE-10</summary>
            public String Sia_dixcom_tdia { get; set; }
            ///<summary>Estado al salir: 1=Vivo 2= Muerto</summary>
            public String Adm_estsal_regr { get; set; }
            ///<summary>Diagnostico de causa muerte cuando exista según CIE-10</summary>
            public String Sia_dixmue_tdia { get; set; }
            ///<summary>Fecha de egreso del servicio de hospitalizacion u Observacion en urgencia</summary>
            public DateTime Adm_fecegr_regr { get; set; }
            ///<summary>Hora egreso hopitalizacion en formato militar  (HH) ejm: 16.25</summary>
            public decimal Adm_horegr_regr { get; set; }
            //- datos adicionales
            ///<summary>Secuencial registro de egreso Hospitalizacion</summary>
            public String Adm_secegr_regr { get; set; }
            ///<summary>Secuencial de Admisión</summary>
            public String Adm_secadm_rgad { get; set; }
            ///<summary>Consecutivo Único de paciente en el sistema</summary>
            public String Sia_idesec_usua { get; set; }
            ///<summary>Numero semanas de gestación</summary>
            public int Adm_semges_regr { get; set; }
            ///<summary>Se realizo control penatal 1=SI,2=No</summary>
            public String Adm_contrl_regr { get; set; }
            #endregion
        }
        #endregion
        #region tmpRipsAU: Estructura temporal Rips Urgencias
        /// <summary>
        /// <para>Estructura temporal Rips Urgencias</para>
        /// </summary>
        public class tmpRipsAU
        {
            #region Datos Urgencias
            ///<summary>Numero de la factura generada en el cierre de facturación</summary>
            public String Fcm_numfac_mfac { get; set; }
            ///<summary>Codigo Prestador servicios IPS</summary>
            public String IPSCodPrestador { get; set; }
            ///<summary>Tipo identificación del usuario o Paciente</summary>
            public String Sia_tipide_tide { get; set; }
            ///<summary>Numero de identificación del paciente: Registro civil...</summary>
            public String Sia_nroide_usua { get; set; }
            ///<summary>Fecha en que ingresa a Observación Urgencia</summary>
            public DateTime Adm_fecurg_rgad { get; set; }
            ///<summary>Hora en que inicia Observación Urgencias</summary>
            public decimal Adm_horurg_rgad { get; set; }
            ///<summary>Numero Autorización Admisión solicitada a la EPS o Asegurador</summary>
            public String Adm_nroaut_rgad { get; set; }
            ///<summary>Causa Externa Origen que origina la atención de urgencias según Resolución: 3374 RIPS</summary>
            public String Adm_codcex_tcex { get; set; }
            ///<summary>Diagnostico de salida Urgencias según CIE-10</summary>
            public String Sia_dixsal_tdia { get; set; }
            ///<summary>Diagnostico relacionado 1 según CIE-10</summary>
            public String Sia_dixre1_tdia { get; set; }
            ///<summary>Diagnostico relacionado 2 según CIE-10</summary>
            public String Sia_dixre2_tdia { get; set; }
            ///<summary>Diagnostico relacionado 3 según CIE-10</summary>
            public String Sia_dixre3_tdia { get; set; }
            ///<summary>Destino al salir: 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion</summary>
            public String Adm_dessal_regr { get; set; }
            ///<summary>Estado al salir: 1=Vivo 2= Muerto</summary>
            public String Adm_estsal_regu { get; set; }
            ///<summary>Diagnostico de causa muerte cuando exista según CIE-10</summary>
            public String Sia_dixmue_tdia { get; set; }
            ///<summary>Fecha de egreso del servicio de Observacion en urgencia</summary>
            public DateTime Adm_fecegr_regu { get; set; }
            ///<summary>Hora egreso Observacion Urgencias en formato militar  (HH) ejm: 16.25</summary>
            public decimal Adm_horegr_regu { get; set; }
            //- datos adicionales
            ///<summary>Secuencial registro de egreso urgencias</summary>
            public String Adm_secegr_regu { get; set; }
            ///<summary>Secuencial de Admisión</summary>
            public String Adm_secadm_rgad { get; set; }
            ///<summary>Consecutivo Único de paciente en el sistema</summary>
            public String Sia_idesec_usua { get; set; }
            #endregion
        }
        #endregion
        #region tmpRipsAN: Estructura temporal Rips Nacimientos
        /// <summary>
        /// <para>Estructura temporal Rips Nacimientos</para>
        /// </summary>
        public class tmpRipsAN
        {
            #region Datos Nacimientos
            ///<summary>Numero de la factura generada en el cierre de facturación</summary>
            public String Fcm_numfac_mfac { get; set; }
            ///<summary>Codigo Prestador servicios IPS</summary>
            public String IPSCodPrestador { get; set; }
            ///<summary>Tipo identificación del usuario o Paciente</summary>
            public String Sia_tipide_tide { get; set; }
            ///<summary>Numero de identificación del paciente: Registro civil...</summary>
            public String Sia_nroide_usua { get; set; }
            ///<summary>Fecha del nacimiento del recien nacido</summary>
            public DateTime Adm_fecnac_regn { get; set; }
            ///<summary>Hora del nacimiento recien nacido en formato militar (HH:mm) ejm: 16:25</summary>
            public decimal Adm_hornac_regn { get; set; }
            ///<summary>Edad gestacional (Numero semanas de gestación)</summary>
            public int Adm_semges_regr { get; set; }
            ///<summary>Se realizo control penatal 1=SI,2=No</summary>
            public String Adm_contrl_regr { get; set; }
            ///<summary>Sexo del del recien nacido</summary>
            public String Sis_codsex_sexo { get; set; }
            ///<summary>Peso recien nacido, en gramos</summary>
            public int Adm_peson_regn { get; set; }
            ///<summary>Diagnostico de nacimiento según CIE-10</summary>
            public String Sia_dixnac_tdia { get; set; }
            ///<summary>Diagnostico del fallecimiento según CIE-10</summary>
            public String Sia_dixmue_tdia { get; set; }
            ///<summary>Fecha muerte recien nacido dentro del servicio de hospitalizacion u Observacion en urgencia</summary>
            public DateTime Adm_fecmue_regn { get; set; }
            ///<summary>Hora muerte del recien nacido en formato militar (HH:mm) ejm: 16.25</summary>
            public decimal Adm_hormue_regn { get; set; }
            //- datos adicionales
            ///<summary>Secuencial unico registro de naciemiento</summary>
            public String Adm_secegr_regn { get; set; }
            ///<summary>Secuencial de Admisión</summary>
            public String Adm_secadm_rgad { get; set; }
            ///<summary>Consecutivo Único de paciente en el sistema (la madre)</summary>
            public String Sia_idesec_usua { get; set; }
            #endregion
        }
        #endregion
        //----------------------------------------------------------------------
        // FUNCIONES AUXILIARES
        //----------------------------------------------------------------------
        #region fcrConvierteHora: Retorna horta militar con separador ajustado al formato Rips
        /// <summary>
        /// Retorna hora militar con separador ajustado al formato Rips
        /// </summary>
        public String fcrConvierteHora(decimal tdeHoraMilitar)
        {
            String lcrHoraMilitar = String.Empty;
            if (tdeHoraMilitar > 0)
            {
                lcrHoraMilitar = tdeHoraMilitar.ToString();

                lcrHoraMilitar = Funciones.fcrExtraerCompHora(lcrHoraMilitar, "HH", "24", gcrSeparadorDecimal) + ":" +
                                 Funciones.fcrExtraerCompHora(lcrHoraMilitar, "MM", "24", gcrSeparadorDecimal);
            }
            return lcrHoraMilitar;
        }
        #endregion
    } 
}
//- MARMOTA-GENCODE: VERSION 2.0 - 25/05/2014 12:12:21 PM
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
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using GestorReportes.Modelo;
using GestorReportes.Vista;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for HCL_SolicitNotasMedicas.xaml
    /// </summary>
    public partial class SolicitNotasMedicas : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = false;
        public bool llgObjetosCargados = false;
        public String gcrCtrF2TexBox;
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public String gcrFormModoPopup = "DFL";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public String gcrCodigoAdmision = String.Empty;
        public String gcrCodigoMaestro = String.Empty;
        public String gcrCodigoRegistro = String.Empty;
        public String gcrTipoMsRegistro = String.Empty;
        public String gcrTipoRegistro = String.Empty;
        public String lcrValiFechayHoraNotasHC = Funciones.fcrLeerConfigVarSistema("HCL-HCLVAL-EVOLU-FECHA-Y-HORA-SYS", "SI");

        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public ModeloHclregordeserms tmpRegMaestro = null;
        public ModeloHclregnotasmedi tmpRegDetalle = null;
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        DialogVistaErrores lobDlgLogs = null;
        Aplicacion oApp = Aplicacion.Instancia();
        /// <summary>
        /// Gestionar evoluciones medicas y notas de enfermeria
        /// </summary>
        /// <param name="tcrModoAccion">Tipo Accion ADD=Adicionar,MOD=Modificar o Editar,DEL=Eliminar,DFL=Default</param>
        /// <param name="tcrTipoRegistro">Tipo registro 1=Evolucion medica 2=Nota de enfermeria</param>
        /// <param name="tcrCodigoRegistro">Codigo unico del registro cuando modo accion "tcrModoAccion" es diferendte de "ADD"</param>
        /// <param name="tcrCodigoAdmision">Codigo de la admision</param>
        public SolicitNotasMedicas(String tcrModoAccion,String tcrTipoRegistro , String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            InitializeComponent();

            fcvSetRichTextBoxEditor();
            IniciarComboBox();
            llgObjetosCargados = true;
            gcrCodigoMaestro = String.Empty;
            gcrTipoRegistro = tcrTipoRegistro;
            gcrTipoMsRegistro = tcrTipoRegistro == "1" ? "EVOL" : "NENF"; // 1 = Evolucion medica 2=Notas de enfermeria
            gcrCodigoRegistro = tcrCodigoRegistro;
            gcrCodigoAdmision = tcrCodigoAdmision;
            this.txtTitulo.Text = tcrTipoRegistro == "1" ? "Evolución Médica" : "Nota de enfermeria";
            this.lblG1hcl_notreg_hcnm.Text = this.txtTitulo.Text;

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            //oApp.gcrUsuIdUsuario;
            //oApp.gcrUsuCodigoPerfil;
            fcvIniciarVariables();

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Hcl_gesfec_hcor.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            if (!String.IsNullOrWhiteSpace(tcrModoAccion))
            {
                fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoRegistro, tcrCodigoAdmision);
            }
            fcvTimerGeneral();
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
            var llgExiste = false;

            if (!String.IsNullOrWhiteSpace(tcrCodigoRegistro))
            {
                var lobReg = HCLValidarCodigo.fobRegBuscarHclregnotasmedi(tcrCodigoRegistro);
                if (lobReg != null) { llgExiste = true; }
            }

            switch (tcrModoAccion)
            {
                case "ADD": // Modo Adicion
                    gcrFormModoPopup = "ADD";
                    if (llgExiste == true) { gcrFormModoPopup = "EDT"; }
                    break;

                case "EDT": // Modo Edicion
                    gcrFormModoPopup = "EDT";
                    if (llgExiste == false) { gcrFormModoPopup = "ADD"; }
                    break;

                default:
                    //- Opcion por Defecto
                    gcrFormModoPopup = "DFL";
                    break;
            }

            if (tcrModoAccion == "ADD")
            {
                // EL PROFESIONA ACTIVO EN EL SISTEMA
                this.txtG1Sia_codpfa_prof.Text = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario).sia_codpfa_prof;
            }

            // Cargar datos en temporales y en vista
            fcvBuscarRegistroMaestroEvolucion();

            // Para que siempre muestre las descripciones
            fcrValidacion("txtG1Sia_codpfa_prof");
            fcrValidacion("txtG1Hcl_tiptur_hctu");

            fcvActivarModoEdicion(gcrFormModoPopup);
        }
        private void fcvBuscarRegistroMaestroEvolucion()
        {
            if (gcrFormModoPopup == "ADD")
            {
                var lobRegEx = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoMsRegistro, gcrCodigoAdmision, "1");
                if (lobRegEx.Count != 0)
                {
                    tmpRegMaestro = lobRegEx.FirstOrDefault();
                    gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;
                    this.txtG1Sia_codpfa_prof.Text = tmpRegMaestro.Sia_codpfa_prof;
                    this.txtG1Hcl_tiptur_hctu.Text = tmpRegMaestro.Hcl_tiptur_hctu;
                }
            }
            else
            {
                tmpRegDetalle = ModeloHclregnotasmedi.fobRegistroHclregnotasmedi(gcrCodigoRegistro);
                if (tmpRegDetalle != null)
                {
                    // El registro ya existe
                    gcrCodigoMaestro = tmpRegDetalle.Hcl_nroreg_hcms;
                    fcvCargarDatosEnObjetosVista();

                    // Datos del Registro maestro 
                    var lobRegEx = ModeloHclregordeserms.flsListaHclregordesermsEx("NA", gcrCodigoMaestro, "");
                    if (lobRegEx.Count != 0)
                    {
                        tmpRegMaestro = lobRegEx.FirstOrDefault();
                    }
                }
            }
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
            FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcnm);
        }

        //-Clic en Boton Guardar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            var lcrNuevoCodigo = String.Empty;
            if (flgValidacion() == true)
            {
                if (flgGenerarRegistroMaestro() == true)
                {
                    fcvCargarRegActivoDesdeVariables();

                    if (gcrFormModoPopup == "ADD")
                    {
                        lcrNuevoCodigo = ModeloHclregnotasmedi.flgAddRegistro(tmpRegDetalle);
                    }
                    else
                    { 
                        // Se asume que es modificacion
                        ModeloHclregnotasmedi.fcvActualizar(tmpRegDetalle);
                    }
                    fcvRetornoInterface(gcrCodigoMaestro);
                }
            }
            else
            {
                MessageBox.Show("No es posible guardar los datos.");
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
            }
            FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcnm);
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
                lobRefEnlace.fcvBuscarRegistro(tcrCodigSelect);
            }
            this.Close();
        }
        #endregion
        #region  Validar Registro maestro R1
        //- Activar modo edicion en la Vista
        public bool flgGenerarRegistroMaestro()
        {
            var llgReturn = true;
            if (tmpRegMaestro == null)
            {
                var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoMsRegistro, gcrCodigoAdmision, "1");
                if (lobReg.Count != 0)
                {
                    tmpRegMaestro = lobReg.FirstOrDefault();
                    gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;
                }
                else
                {
                    // Adicionar el registro
                    tmpRegMaestro = new ModeloHclregordeserms();
                    #region Valores Variables
                    //tmpRegMaestro.Hcl_nroreg_hcms  al guardar
                    //tmpRegMaestro.Hcl_nroreg_hcev  cuando se confirme
                    tmpRegMaestro.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    tmpRegMaestro.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    tmpRegMaestro.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    tmpRegMaestro.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    tmpRegMaestro.Hcl_tiptur_hctu = txtG1Hcl_tiptur_hctu.Text;
                    tmpRegMaestro.Hcl_tipreg_hctr = gcrTipoMsRegistro; 
                    tmpRegMaestro.Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
                    tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcnm.Text);
                    tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcnm.Text, "12", ":", gcrSeparadorDecimal));
                    tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                    tmpRegMaestro.Sis_estpro_espr = "1";
                    #endregion
                    gcrCodigoMaestro = ModeloHclregordeserms.flgAddRegistro(tmpRegMaestro);
                    tmpRegMaestro.Hcl_nroreg_hcms = gcrCodigoMaestro;
                }
                llgReturn = !String.IsNullOrWhiteSpace(gcrCodigoMaestro) ? true : false;
            }
            return llgReturn;
        }
        #endregion
        #region flgCargarDatosEnObjetosVista: Cargar los datos en los objetos de la vista
        /// <summary>
        ///  Cargar los datos en los objetos de la vista
        /// </summary>
        public void fcvCargarDatosEnObjetosVista()
        {
            if (tmpRegDetalle != null)
            {
                var lobG1Hcl_notreg_hcnm = fcvRefRichTextBoxEditor();
                lobG1Hcl_notreg_hcnm.Text = tmpRegDetalle.Hcl_notreg_hcnm;

                this.txtG1Sia_codpfa_prof.Text = tmpRegDetalle.Sia_codpfa_prof;
                this.txtG1Hcl_tiptur_hctu.Text = tmpRegDetalle.Hcl_tiptur_hctu;
                this.txtG1Hcl_gesfec_hcnm.Text = tmpRegDetalle.Hcl_gesfec_hcnm.ToShortDateString();
                this.txtG1Hcl_geshor_hcnm.Text = Funciones.fcrConvierteHora(tmpRegDetalle.Hcl_geshor_hcnm.ToString(), "24", gcrSeparadorDecimal, ":");

                flgActivarObjetosVista();
            }
        }
        #endregion
        #region flgActivarObjetosVista: Activar o desactivar los objetos de la vista 
        /// <summary>
        /// Activar o desactivar los objetos de la vista, segun estado del registro
        /// </summary>
        public void flgActivarObjetosVista()
        {
            if (tmpRegDetalle != null)
            {
                var llgSoloLectura = tmpRegDetalle.Sis_estpro_espr == "1" ? false : true;

                //- Activar o desactivar los objetos de la vista
                this.txtG1Hcl_tiptur_hctu.IsReadOnly = llgSoloLectura;
                this.txtG1Hcl_gesfec_hcnm.IsReadOnly = llgSoloLectura;
                this.txtG1Hcl_geshor_hcnm.IsReadOnly = llgSoloLectura;
                this.txtG1Hcl_notreg_hcnm.IsReadOnly = llgSoloLectura;
                this.dpkG1Hcl_gesfec_hcor.IsEnabled  = !llgSoloLectura;

                //- los botones
                this.cmdBrowTurno.Visibility  = llgSoloLectura == true ? Visibility.Collapsed : Visibility.Visible;
                this.cmdLogErrores.Visibility = llgSoloLectura == true ? Visibility.Collapsed : Visibility.Visible;
                this.cmdGuardar.Visibility    = llgSoloLectura == true ? Visibility.Collapsed : Visibility.Visible;
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
            gdspTimerSistema.Stop();
            this.Close();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            gdspTimerSistema.Stop();
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
        //  KeyDown llamada funciones compos con F2
        //-------------------------------------------------
        #region llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("HCL", "HCLREGORDESERVI", "", "Maestro ordenes servicios intrahospitalarios...");
            gcrCtrF2TexBox = "txtG1Hcl_nroreg_hcor";
            frbro.Owner = this;
            frbro.ShowDialog();
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
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Hcl_tiptur_hctu":
                    this.txtG1Hcl_tiptur_hctu.Text = tcrCodigo;
                    break;
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
                Browser01 frbro = new Browser01("HCL", "HCLTIPOREGTURNO", "", "Tipo registro turnos servicios medicos...");
                gcrCtrF2TexBox = "txtG1Hcl_tiptur_hctu";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region HCL_TIPTUR_HCTU : Browser desde boton - Tipo registro turnos diarios prestacion de servicios medicos
        private void fcvBuscarTurno(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("HCL", "HCLTIPOREGTURNO", "", "Tipo registro turnos servicios medicos...");
            gcrCtrF2TexBox = "txtG1Hcl_tiptur_hctu";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
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
                        this.txtG1Hcl_gesfec_hcnm.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, this.txtG1Hcl_gesfec_hcnm);
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
        #region Iniciar las variables de la vista
        private void fcvIniciarVariables()
        {
            tmpRegDetalle = new ModeloHclregnotasmedi();
            if (!String.IsNullOrWhiteSpace(gcrCodigoAdmision))
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision);
                if (lobRegAdm.Count == 0) { return; }
                tmpRegAdm = lobRegAdm.FirstOrDefault();
            }
            this.txtG1Hcl_gesfec_hcnm.Text = DateTime.Now.ToShortDateString();
            this.txtG1Hcl_geshor_hcnm.Text = Funciones.fcrHoraActual("12", ":");
        }
        #endregion
        #region Cargar datos existentes
        private void fcvCargarDatosExitentes(String tcrCodigo)
        {
            // cargar datos
        }
        #endregion
        #region Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariables()
        {
            try
            {
                var lobG1Hcl_notreg_hcnm = fcvRefRichTextBoxEditor();
                #region Valores Variables
                //tmpRegDetalle.Hcl_nroreg_hcor
                tmpRegDetalle.Hcl_nroreg_hcms = tmpRegMaestro.Hcl_nroreg_hcms;
                //tmpRegDetalle.Hcl_secreg_hcor
                tmpRegDetalle.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                tmpRegDetalle.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegDetalle.Hcl_tipreg_hcnm = gcrTipoRegistro;
                tmpRegDetalle.Hcl_tiptur_hctu = tmpRegMaestro.Hcl_tiptur_hctu;
                tmpRegDetalle.Hcl_gesfec_hcnm = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcnm.Text);
                tmpRegDetalle.Hcl_geshor_hcnm = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcnm.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegDetalle.Hcl_sisfec_hcnm = DateTime.Now;
                tmpRegDetalle.Hcl_sishor_hcnm = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                tmpRegDetalle.Hcl_notreg_hcnm = lobG1Hcl_notreg_hcnm.Text;
                tmpRegDetalle.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegDetalle.Sis_estpro_espr = "1";
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
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
        private void fcvValidacionTextoRt(object sender, TextChangedEventArgs e)
        {
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
            var lnuCont = 0;
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_gesfec_hcnm"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_geshor_hcnm"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_notreg_hcnm"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codpfa_prof"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_tiptur_hctu"))) { lnuCont++; }

            this.cmdGuardar.IsEnabled = lnuCont > 0 || llgModoEdicion == false ? false : true;

            return lnuCont == 0 ? true : false;
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
            String lcrValorReturn       = string.Empty;
            String lcrNumeroRegistro    = "USUARIO";
            String lcrCodigoError       = String.Empty;
            String lcrNombreCampo       = String.Empty;
            String lcrNivelError        = "ALTO";
            String lcrImgNivelError     = "Edt_hist_vista_anulado.png";

            try
            {
                switch (tcrNombrePropiedad)
                {

                    case "txtG1Hcl_gesfec_hcnm":
                        #region Validacion
                        lcrNombreCampo = "Fecha del registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";

                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtG1Hcl_gesfec_hcnm.Text, lcrNombreCampo);
                        fcvSetColorValidacion(txtG1Hcl_gesfec_hcnm, lcrValorReturn);

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            this.txtG1Hcl_gesfec_hcnm.BorderBrush = Brushes.White;

                            lcrValorReturn = Funciones.fcrValidaHoraTexto(true, txtG1Hcl_geshor_hcnm.Text, "12", ":", "Hora servicio");
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                var lcrFechaAdm = Funciones.fcrConvertFecha(tmpRegAdm.Adm_fecadm_rgad);
                                var lcrHoraAdm  = Funciones.fcrConvierteHora(tmpRegAdm.Adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                                var lcrHoraGest = this.txtG1Hcl_geshor_hcnm.Text;

                                if (!Funciones.flgValidarRangoFechasHoras(lcrFechaAdm, this.txtG1Hcl_gesfec_hcnm.Text, "DMY", "/",
                                                                                lcrHoraAdm, lcrHoraGest, "12", ":"))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No corresponde con fecha y hora del registro admision x (Admitido: " +
                                                             lcrFechaAdm + " - " + lcrHoraAdm + ")";
                                }
                                else
                                {
                                    // Validacion Con Evoluciones o notas anteriores
                                    #region Validacion Con Evoluciones o notas anteriores
                                    var lobReg = HCLValidarCodigo.fobRegBuscarHclregnotasmediUltima(gcrCodigoAdmision, gcrTipoRegistro);
                                    if (lobReg != null)
                                    {
                                        var lcrNomTipo = gcrTipoRegistro == "1" ? "Evolución" : "Nota";
                                        var lcrFechaNota = Funciones.fcrConvertFecha((DateTime)lobReg.hcl_gesfec_hcnm);
                                        var lcrHoraNota = Funciones.fcrConvierteHora(lobReg.hcl_geshor_hcnm.ToString(), "24", gcrSeparadorDecimal, ":");

                                        if (gcrFormModoPopup == "ADD")
                                        {
                                            if (!Funciones.flgValidarRangoFechasHoras(lcrFechaNota, this.txtG1Hcl_gesfec_hcnm.Text, "DMY", "/",
                                                                                            lcrHoraNota, lcrHoraGest, "12", ":"))
                                            {
                                                lcrValorReturn = lcrNombreCampo + ": No corresponde con fecha y hora de la ultima " + lcrNomTipo + " (" +
                                                                 lcrFechaNota + " - " + lcrHoraNota + ")";
                                            }
                                        }
                                    }
                                    #endregion
                                    // Validacion con fecha y hora de la atencion de urgencias
                                    #region Validacion con fecha y hora de la atencion de urgencias
                                    // Datos de la fecha 
                                    var lobRegUrgFecha   = ModeloHclvariabactual.fobRegistroHclVariabActual("2", gcrCodigoAdmision, "ATENURGEN_FECH_URGENCIA");
                                    var lcrUrgenciaFecha = lobRegUrgFecha != null ? lobRegUrgFecha.Hcl_valvar_hcvr : String.Empty;
                                    var lobRegUrgHora    = ModeloHclvariabactual.fobRegistroHclVariabActual("2", gcrCodigoAdmision, "ATENURGEN_HORA_LLEGADA_URG");
                                    var lcrUrgenciaHora  = lobRegUrgHora != null ? lobRegUrgHora.Hcl_valvar_hcvr : String.Empty;

                                    if (lobRegUrgFecha != null && lobRegUrgHora != null)
                                    {
                                        lcrUrgenciaHora = Funciones.fcrConvierteHora(lcrUrgenciaHora, "24", gcrSeparadorDecimal, ":");

                                        if (gcrFormModoPopup == "ADD")
                                        {
                                            if (!Funciones.flgValidarRangoFechasHoras(lcrUrgenciaFecha, this.txtG1Hcl_gesfec_hcnm.Text, "DMY", "/",
                                                                                            lcrUrgenciaHora, lcrHoraGest, "12", ":"))
                                            {
                                                lcrValorReturn = lcrNombreCampo + ": No corresponde con fecha y hora atención de la urgencia (" +
                                                                 lcrUrgenciaFecha + " - " + lcrUrgenciaHora + ")";
                                            }
                                        }
                                    }
                                    #endregion
                                    // validar que no sea mayor que fecha y hora actual
                                    #region Validacion para fecha actual del sistema
                                    if (String.IsNullOrWhiteSpace(lcrValorReturn))
                                    {
                                        if (lcrValiFechayHoraNotasHC == "SI")
                                        {
                                            if (!Funciones.flgValidarRangoFechasHorasEx(this.txtG1Hcl_gesfec_hcnm.Text, Funciones.fcrFechaActual(), "DMY", "/",
                                                                                            lcrHoraGest, Funciones.fcrHoraActual("12", ":"), "12", ":"))
                                            {
                                                lcrValorReturn = lcrNombreCampo + ": fecha y hora del registro no debe superar fecha y hora actual (ACTUAL: " +
                                                                         Funciones.fcrFechaActual() + " - " + Funciones.fcrHoraActual("12", ":") + ")";
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                        break;
                        #endregion

                    case "txtG1Hcl_geshor_hcnm":
                        #region Validacion
                        lcrNombreCampo = "Hora del registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";

                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, txtG1Hcl_geshor_hcnm.Text, "12", ":", lcrNombreCampo);
                        fcvSetColorValidacion(txtG1Hcl_geshor_hcnm, lcrValorReturn);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", this.txtG1Hcl_gesfec_hcnm.Text, "Fecha del registro");
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                var lcrFechaAdm = Funciones.fcrConvertFecha(tmpRegAdm.Adm_fecadm_rgad);
                                var lcrHoraAdm = Funciones.fcrConvierteHora(tmpRegAdm.Adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                                var lcrHoraGest = this.txtG1Hcl_geshor_hcnm.Text;

                                if (!Funciones.flgValidarRangoFechasHoras(lcrFechaAdm, this.txtG1Hcl_gesfec_hcnm.Text, "DMY", "/",
                                                                                lcrHoraAdm, lcrHoraGest, "12", ":"))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No corresponde con fecha y hora del registro admision";
                                }
                                else
                                {
                                    var lobReg = HCLValidarCodigo.fobRegBuscarHclregnotasmediUltima(gcrCodigoAdmision, gcrTipoRegistro);
                                    if (lobReg != null)
                                    {
                                        var lcrNomTipo = gcrTipoRegistro == "1" ? "Evolución" : "Nota";
                                        var lcrFechaNota = Funciones.fcrConvertFecha((DateTime)lobReg.hcl_gesfec_hcnm);
                                        var lcrHoraNota = Funciones.fcrConvierteHora(lobReg.hcl_geshor_hcnm.ToString(), "24", gcrSeparadorDecimal, ":");

                                        if (gcrFormModoPopup == "ADD")
                                        {
                                            if (!Funciones.flgValidarRangoFechasHoras(lcrFechaNota, this.txtG1Hcl_gesfec_hcnm.Text, "DMY", "/",
                                                                                            lcrHoraNota, lcrHoraGest, "12", ":"))
                                            {
                                                lcrValorReturn = lcrNombreCampo + ": No corresponde con fecha y hora de la ultima " + lcrNomTipo + " (" +
                                                                 lcrFechaNota + "- " + lcrHoraNota + ")";
                                            }
                                        }
                                    }
                                    // validar que no sea mayor que fecha y hora actual
                                    if (String.IsNullOrWhiteSpace(lcrValorReturn))
                                    {
                                        if (lcrValiFechayHoraNotasHC == "SI")
                                        {
                                            if (!Funciones.flgValidarRangoFechasHorasEx(this.txtG1Hcl_gesfec_hcnm.Text, Funciones.fcrFechaActual(), "DMY", "/",
                                                                                            lcrHoraGest, Funciones.fcrHoraActual("12", ":"), "12", ":"))
                                            {
                                                lcrValorReturn = lcrNombreCampo + ": fecha y hora del registro no debe superar fecha y hora actual (ACTUAL: " +
                                                                         Funciones.fcrFechaActual() + " - " + Funciones.fcrHoraActual("12", ":") + ")";
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        break;
                        #endregion

                    case "txtG1Hcl_notreg_hcnm":
                        #region Validacion
                        lcrNombreCampo = "Nota observación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        var lobG1Hcl_notreg_hcnm = fcvRefRichTextBoxEditor();
                        if (String.IsNullOrWhiteSpace(lobG1Hcl_notreg_hcnm.Text))
                        {
                            lcrValorReturn = "Nota observación: Es requerida";
                        }
                        fcvSetColorValidacionRt(txtG1Hcl_notreg_hcnm, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Sia_codpfa_prof":
                        #region Validacion
                        lcrNombreCampo = "Hora servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";

                        if (string.IsNullOrWhiteSpace(this.txtG1Sia_codpfa_prof.Text))
                        {
                            lcrValorReturn = "Profesional atiende: Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(this.txtG1Sia_codpfa_prof.Text);
                            if (tmp != null && tmp.sia_nompro_prof != null)
                            {
                                this.txtG1Sia_nompro_prof.Text = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = "Profesional atiende: No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codpfa_prof, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_tiptur_hctu":
                        #region Validacion
                        lcrNombreCampo = "Hora servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";

                        if (String.IsNullOrWhiteSpace(this.txtG1Hcl_tiptur_hctu.Text))
                        {
                            lcrValorReturn = "Codigo turno: Es requerido";
                        }
                        else
                        {
                            var tmp = HCLValidarCodigo.fobRegBuscarHcltiporegturno(this.txtG1Hcl_tiptur_hctu.Text);
                            if (tmp != null && tmp.hcl_destur_hctu != null)
                            {
                                this.txtG1Hcl_destur_hctu.Text = tmp.hcl_destur_hctu;
                            }
                            else
                            {
                                lcrValorReturn = "Codigo turno: No existe";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_tiptur_hctu, lcrValorReturn);
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
        //-------------------------------------------------
        // Referencias a objetos editores
        //-------------------------------------------------
        #region fcvRefRichTextBoxEditor: Referencia a objetos editor de texto
        /// <summary>
        /// <para>Referencia a objetos editor de texto</para>
        /// </summary>
        private TextRange fcvRefRichTextBoxEditor()
        {
            TextRange lobTextRange = null;
            lobTextRange = new TextRange(txtG1Hcl_notreg_hcnm.Document.ContentStart, txtG1Hcl_notreg_hcnm.Document.ContentEnd);

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
            this.txtG1Hcl_notreg_hcnm.SpellCheck.IsEnabled = true; // Corrector de ortografia
            this.txtG1Hcl_notreg_hcnm.Language = System.Windows.Markup.XmlLanguage.GetLanguage("es-US");
            this.txtG1Hcl_notreg_hcnm.Document.LineHeight = 3;
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
                // 
                //-------------------------------------------------
                #region HOS_TIPHAB_HABI: Unipersonal SI/NO
                //string lcrG11Seleccion = "1,2";
                //string lcrG11Descripcion = "Servicio,Inidicacion médica";
                //lstG1Hcl_tipser_hcor = new List<CrtForms.ListaComboBox>();
                //lstG1Hcl_tipser_hcor = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                //- Asignar al control
                //cboG1Hcl_tipser_hcor.ItemsSource = lstG1Hcl_tipser_hcor;
                //cboG1Hcl_tipser_hcor.SelectedIndex = Convert.ToInt32(lstG1Hcl_tipser_hcor[0].IdIndice);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        //-------------------------------------------------
        // Lista de Errores
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
    }
}

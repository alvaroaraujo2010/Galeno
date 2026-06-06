//- MARMOTA-GENCODE: VERSION 2.0 - 26/01/2015 01:14:10 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Modelo;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GestorReportes.Modelo;
using GestorReportes.Vista;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Descripcion para la Vista de: Balance de liquidos
    /// </summary>
    public partial class VistaMaestroTratamiento : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgObjetosCargados = false;
        public String gcrCtrF2TexBox;
        public String lcrFormModoPopup = "DFL";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public String gcrTipoRegistro = String.Empty;
        public String gcrCodigoAdmision = String.Empty;
        public String gcrCodigoMaestro = String.Empty;
        public String gcrCodigoRegistro = String.Empty;
        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public ModeloOdnMaestroTratamiento tmpRegMaestro = null;
        public ModeloOdnMsActivTratamiento tmpRegDetalle = null;
        public List<CrtForms.ListaComboBox> lstG1Odn_tgrafi_odev;
        public List<CrtForms.ListaComboBox> G1CbOdn_estado_odev;

        /// <summary>
        /// <para>tcrTipoRegistro: "1" = Apertura Tratamiento odontologico "2" = Cierre Registro maestro tratamiento odontologico</para>
        /// <para>tcrCodigoRegistro: Codigo del registro maestro de tratamiento odontológico</para>
        /// </summary>
        public VistaMaestroTratamiento(String tcrModoAccion, String tcrTipoRegistro, String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            InitializeComponent();

            IniciarComboBox();
            llgObjetosCargados = true;
            gcrCodigoMaestro = String.Empty;
            gcrTipoRegistro = tcrTipoRegistro;
            gcrCodigoRegistro = tcrCodigoRegistro;
            gcrCodigoAdmision = tcrCodigoAdmision;

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;
            this.txtG1Sia_codpfa_prof.Text = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario).sia_codpfa_prof;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            this.dpkG1Odn_fecape_odev.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Odn_feccie_odev.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            if (!String.IsNullOrWhiteSpace(tcrModoAccion))
            {
                fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoRegistro, tcrCodigoAdmision);
            }
        }
        #endregion
        //-------------------------------------------------
        // Gestion Modo Formulario Popup
        //-------------------------------------------------
        #region fcvCargarVistaFormPopup
        private void fcvCargarVistaFormPopup(String tcrModoAccion, String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            var llgExiste = false;

            // Cargar registro de admision
            if (!String.IsNullOrWhiteSpace(gcrCodigoAdmision))
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision);
                if (lobRegAdm.Count == 0) { return; }
                tmpRegAdm = lobRegAdm.FirstOrDefault();
            }

            // Registro ya existente
            if (!String.IsNullOrWhiteSpace(tcrCodigoRegistro))
            {
                EFodneventosmaest lobReg = ODNValidarCodigo.fobRegBuscarOdneventosmaest(tcrCodigoRegistro);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.odn_nroreg_odev)) 
                { 
                    llgExiste = true;
                    this.txtG1Sia_codpfa_prof.Text = lobReg.sia_codpfa_prof;
                }
            }
            // Solo mostrar la pestaña requerida
            if (gcrTipoRegistro == "1")
            {
                this.pagTabsCierre.Visibility = Visibility.Collapsed;
                this.pagRegistro.SelectedItem = pagTabsApertura;

            }
            else
            {
                this.pagTabsApertura.Visibility = Visibility.Collapsed;
                this.pagRegistro.SelectedItem = pagTabsCierre;
                this.txtG1Odn_estado_odev.Text = "2";
            }

            this.txtG1Odn_tgrafi_odev.Text = String.Empty;
            this.txtG1Odn_feccie_odev.Text = DateTime.Now.ToShortDateString();
            //this.txtG1Hcl_horcie_hcbm.Text = Funciones.fcrHoraActual("12", gcrSeparadorDecimal);

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
        #region Gestion Edicion
        //- clic en Boton Nuevo
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Sia_codpfa_prof);
        }

        //-Clic en Boton Guardar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            var lcrNuevoCodigo = String.Empty;
            if (flgValidacion() == true)
            {
                if (flgGenerarRegistroMaestro() == true)
                {
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
                    fcvIniciarVariables();
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = true;
                    break;
            }
            FocusManager.SetFocusedElement(this, txtG1Sia_codpfa_prof);
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
        #region flgGenerarRegistroMaestro: Generar datos del registro maestro
        //- Activar modo edicion en la Vista
        public bool flgGenerarRegistroMaestro()
        {
            var llgReturn = false;
            if (gcrTipoRegistro == "2")
            {
                var lobReg = ModeloOdnMaestroTratamiento.flsListaOdneventosmaestEx("1", gcrCodigoRegistro);
                if (lobReg.Count != 0)
                {
                    tmpRegMaestro = lobReg.FirstOrDefault();

                    // Datos para el cierre turno
                    tmpRegMaestro.Odn_feccie_odev = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Odn_feccie_odev.Text);
                    tmpRegMaestro.Odn_obscie_odev = this.txtG1Odn_obscie_odev.Text;
                    tmpRegMaestro.Sis_estpro_espr = "2";
                    tmpRegMaestro.Odn_estado_odev = this.txtG1Odn_estado_odev.Text;

                    var lcrCodigoHistorial = fcvHclinicaGenerarActividad();

                    ModeloOdnMaestroTratamiento.fcvActualizar(tmpRegMaestro);
                    //--------------------------
                    // cerrar registros detalles
                    //--------------------------
                    var lobDetall = ModeloOdnMsActivTratamiento.flsListaOdneventosactms("R1", tmpRegMaestro.Odn_nroreg_odev);
                    if (lobDetall.Count != 0)
                    {
                        foreach (var lobRegEx in lobDetall)
                        {
                            lobRegEx.Sis_estpro_espr = "2";
                            ModeloOdnMsActivTratamiento.fcvActualizar(lobRegEx);
                        }
                        llgReturn = true;
                    }
                    llgReturn = true;
                    gcrCodigoMaestro = tmpRegMaestro.Odn_nroreg_odev;
                }
            }
            else
            {
                // Adicionar el registro
                tmpRegMaestro = new ModeloOdnMaestroTratamiento();

                #region Valores Variables
                tmpRegMaestro.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegMaestro.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                tmpRegMaestro.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                tmpRegMaestro.Odn_fecape_odev = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Odn_fecape_odev.Text);
                tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegMaestro.Odn_sisfec_odev = DateTime.Now;
                tmpRegMaestro.Odn_sishor_odev = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                tmpRegMaestro.Odn_obsape_odev = this.txtG1Odn_obsape_odev.Text;
                tmpRegMaestro.Sia_codare_aser = this.txtG1Sia_codare_aser.Text;
                tmpRegMaestro.Odn_estado_odev = "1";
                tmpRegMaestro.Odn_tgrafi_odev = this.txtG1Odn_tgrafi_odev.Text;
                tmpRegMaestro.Odn_tipreg_odev = "1"; // ---------------------    OJO ES SEGUN PARAMETRO :  Tipo de registro maestro: 1=tratamiento 2=Consulta externa
                tmpRegMaestro.Odn_secdet_odev = 0;
                tmpRegMaestro.Sis_estpro_espr = "2";

                var lcrCodigoHistorial = fcvHclinicaGenerarActividad();
                tmpRegMaestro.Hcl_nroreg_hcev = lcrCodigoHistorial;

                gcrCodigoMaestro = ModeloOdnMaestroTratamiento.flgAddRegistro(tmpRegMaestro);
                tmpRegMaestro.Odn_nroreg_odev = gcrCodigoMaestro;
                #endregion

                llgReturn = !String.IsNullOrWhiteSpace(gcrCodigoMaestro) ? true : false;
            }
            return llgReturn;
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
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Sia_codpfa_prof":
                    this.txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Hcl_tiptur_hctu":
                    //this.txtG1Hcl_tiptur_hctu.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codare_aser":
                    this.txtG1Sia_codare_aser.Text = tcrCodigo;
                    break;

            }
        }
        #endregion
        // HCLREGORDESERVI : Maestro ordenes servicios intrahospitalarios
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
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
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
                        case "cboG1Odn_tgrafi_odev":
                            txtG1Odn_tgrafi_odev.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Odn_tgrafi_odev.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Odn_tgrafi_odev.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboG1Odn_estado_odev":
                            txtG1Odn_estado_odev.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Odn_estado_odev.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Odn_estado_odev.Text, ",", lobList.ListaValoresSel);
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
                        case "txtG1Odn_tgrafi_odev":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Odn_tgrafi_odev.SelectedItem;
                            cboG1Odn_tgrafi_odev.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
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
                    case "txtG1Hcl_fecape_hcbm":
                        txtG1Odn_fecape_odev.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Odn_fecape_odev);
                        break;

                    case "txtG1Hcl_feccie_hcbm":
                        txtG1Odn_feccie_odev.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Odn_feccie_odev);
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
                            case "txtG1Hcl_fecape_hcbm":
                                dpkG1Odn_fecape_odev.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtG1Hcl_feccie_hcbm":
                                dpkG1Odn_feccie_odev.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                        }
                    }
                    fcrValidacion(lobTexto.Name);
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
                    fcrValidacion(lobTexto.Name);
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
            this.txtG1Sia_codpfa_prof.Text = tmpRegAdm.Sia_codpfa_prof;
            this.txtG1Sia_codare_aser.Text = tmpRegAdm.Sia_codare_aser;
            this.txtG1Odn_fecape_odev.Text = tmpRegAdm.Adm_fecadm_rgad.ToShortDateString();
        }
        #endregion
        #region Cargar datos existentes
        private void fcvCargarDatosExitentes(String tcrCodigo)
        {
            // cargar datos
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
            var lobTextBox = sender as TextBox;
            fcrValidacion(lobTextBox.Name);
        }
        #endregion
        #region flgValidacion: Valida todos los datos antes de guardar
        /// <summary>
        /// Valida todos los datos antes de guardar
        /// </summary>
        public bool flgValidacion()
        {
            var lnuCont = 0;
            if (gcrTipoRegistro == "1") // Apertura del turno
            {
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codpfa_prof"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Odn_tgrafi_odev"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Odn_fecape_odev"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codare_aser"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Odn_obsape_odev"))) { lnuCont++; }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Odn_feccie_odev"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Odn_obscie_odev"))) { lnuCont++; }
            }
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
            string lcrValorReturn = string.Empty;
            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "txtG1Sia_codpfa_prof":
                        if (string.IsNullOrWhiteSpace(this.txtG1Sia_codpfa_prof.Text))
                        {
                            lcrValorReturn = "Profesional atiende: Es requerido";
                        }
                        else
                        {
                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(this.txtG1Sia_codpfa_prof.Text);
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

                    case "txtG1Odn_tgrafi_odev":
                        if (String.IsNullOrWhiteSpace(this.txtG1Odn_tgrafi_odev.Text))
                        {
                            lcrValorReturn = "Tipo grafica odontograma: Es requerido";
                        }
                        break;

                    case "txtG1Sia_codare_aser":
                        if (string.IsNullOrWhiteSpace(txtG1Sia_codare_aser.Text))
                        {
                            lcrValorReturn = "Area de servicios: Es requerido";
                        }
                        else
                        {
                            EFsiaareapreservi tmp = new EFsiaareapreservi();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(txtG1Sia_codare_aser.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desare_aser))
                            {
                                this.txtG1Sia_desare_aser.Text = tmp.sia_desare_aser;
                            }
                            else
                            {
                                lcrValorReturn = "Area de servicios: No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codare_aser, lcrValorReturn);
                        break;

                    case "txtG1Odn_fecape_odev":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", txtG1Odn_fecape_odev.Text, "Fecha inicio tratamiento");
                        fcvSetColorValidacion(txtG1Odn_fecape_odev, lcrValorReturn);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            txtG1Odn_fecape_odev.BorderBrush = Brushes.White;
                        }
                        break;


                    case "txtG1Odn_obsape_odev":
                        if (String.IsNullOrWhiteSpace(txtG1Odn_obsape_odev.Text))
                        {
                            lcrValorReturn = "Observación inicio tratamiento: Es requerida";
                        }
                        fcvSetColorValidacion(txtG1Odn_obsape_odev, lcrValorReturn);
                        break;

                    //------------------------------------------------------
                    // datos del cierre turno
                    //------------------------------------------------------
                    case "txtG1Odn_feccie_odev":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", txtG1Odn_feccie_odev.Text, "Fecha cierre tratamiento");
                        fcvSetColorValidacion(txtG1Odn_feccie_odev, lcrValorReturn);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            txtG1Odn_feccie_odev.BorderBrush = Brushes.White;
                        }
                        break;

                    case "txtG1Odn_obscie_odev":
                        if (String.IsNullOrWhiteSpace(txtG1Odn_obscie_odev.Text))
                        {
                            lcrValorReturn = "Observación cierre: Es requerida";
                        }
                        fcvSetColorValidacion(txtG1Odn_obscie_odev, lcrValorReturn);
                        break;
                }
                if (!String.IsNullOrWhiteSpace(lcrValorReturn))
                {
                    MessageBox.Show(lcrValorReturn);
                }
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

                if (!String.IsNullOrWhiteSpace(lobReg.grp_idepla_grpl))
                {
                    // Generar registro de actividad en historia clinica
                    var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);
                    var lobHist = new HclModeloHistorialEventos();
                    var lcrEvento = lobRegEx.hcl_desreg_hctr;
                    var ldaFechaEvento = tmpRegMaestro.Odn_fecape_odev;
                    var ldaHoraEvento = tmpRegMaestro.Odn_sishor_odev;

                    if (gcrTipoRegistro == "2")
                    {
                        lcrEvento = "Odontologia - Cierre tratamiento";
                        ldaFechaEvento = tmpRegMaestro.Odn_feccie_odev;
                        ldaHoraEvento = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                    }

                    #region Datos del registro
                    lobHist.Hcl_secreg_hcev = 1;
                    lobHist.Hcl_nrohis_hicl = tmpRegAdm.Hcl_nrohis_hicl;
                    lobHist.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    lobHist.Cit_codasi_mcit = tmpRegAdm.Cit_codasi_mcit;
                    lobHist.Fcm_codcpr_cpro = String.Empty;
                    lobHist.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    lobHist.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    lobHist.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    lobHist.Hcl_codaux_hcev = tmpRegMaestro.Odn_nroreg_odev;
                    lobHist.Hcl_gesfec_hcev = ldaFechaEvento;
                    lobHist.Hcl_geshor_hcev = ldaHoraEvento;
                    lobHist.Sia_codpfa_prof = tmpRegMaestro.Sia_codpfa_prof;
                    lobHist.Hcl_keydat_hcev = fcrGenerarLlaveMs(tmpRegMaestro).ToLower() + " " + lobRegEx.hcl_desreg_hctr.ToLower();
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
        public String fcrGenerarLlaveMs(ModeloOdnMaestroTratamiento tobRegistro)
        {
            // llave registro maestro
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + "  " + "  " + tobRegistro.Odn_nroreg_odev;
            var lcrllave2 = tobRegistro.Odn_fecape_odev.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + "  " + tobRegistro.Sia_desare_aser;
            var lcrllave4 = String.Empty;

            // llave de los detalles
            var lobDetall = ModeloOdnMsActivTratamiento.flsListaOdneventosactms("R1", tobRegistro.Odn_nroreg_odev);
            if (lobDetall.Count != 0 && lobDetall != null)
            {
                foreach (var lobReg in lobDetall)
                {
                    lcrllave4 += " " + fcrGenerarLlaveDetalles(lobReg);
                }
            }
            return lcrllave1 + "  " + lcrllave2 + "  " + lcrllave3 + " " + lcrllave4;
        }
        #endregion
        #region fcrGenerarLlaveDetalles: Generar llave desde registros detalles
        /// <summary>
        /// <para>Generar llave desde registros detalles</para>
        /// </summary>
        public String fcrGenerarLlaveDetalles(ModeloOdnMsActivTratamiento tobRegistro)
        {
            var lcrllave1 = tobRegistro.Odn_obsape_odev + " " + tobRegistro.Sia_nompro_prof + " " + tobRegistro.Fcm_descpr_cpro;
            var lcrllave2 = tobRegistro.Odn_fecact_odac.ToString();

            return lcrllave1 + " " + lcrllave2;
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
                // TIPO ODONTOGRMA 
                //-------------------------------------------------
                #region Tipo de odontogrmama para graficar servicios
                string lcrG11Seleccion = "1,2,3";
                string lcrG11Descripcion = "Odontograma adultos,Odontograma niños,Odontograma mixto";
                lstG1Odn_tgrafi_odev = new List<CrtForms.ListaComboBox>();
                lstG1Odn_tgrafi_odev = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                //- Asignar al control
                cboG1Odn_tgrafi_odev.ItemsSource = lstG1Odn_tgrafi_odev;
                cboG1Odn_tgrafi_odev.SelectedIndex = Convert.ToInt32(lstG1Odn_tgrafi_odev[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //ODN_ESTADO_ODEV: Estado tratamiento
                //-------------------------------------------------
                #region ODN_ESTADO_ODEV: Estado tratamiento
                string lcrG12Seleccion = "2,3";
                string lcrG12Descripcion = "Finalizado y completado,Finalizado sin completar";
                G1CbOdn_estado_odev = new List<CrtForms.ListaComboBox>();
                G1CbOdn_estado_odev = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                //- Asignar al control
                cboG1Odn_estado_odev.ItemsSource = G1CbOdn_estado_odev;
                cboG1Odn_estado_odev.SelectedIndex = Convert.ToInt32(G1CbOdn_estado_odev[1].IdIndice);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion

    }
}
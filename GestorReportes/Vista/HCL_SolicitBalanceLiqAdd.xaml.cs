//- MARMOTA-GENCODE: VERSION 2.0 - 30/06/2014 04:12:50 PM
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
    /// Interaction logic for HCL_SolicitBalanceLiqAdd.xaml
    /// </summary>
    public partial class VistaSolicitBalanceLiqAdd : Window, SIS_Interface
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
        public String gcrCodigoAdmision = String.Empty;
        public String gcrCodigoMaestro  = String.Empty;
        public String gcrCodigoRegistro = String.Empty;
        public String gcrTipoRegistro   = "1";  // Administracion de liquidos
        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public ModeloHclregbliqidoms tmpRegMaestro = null;
        public ModeloHclregbliqidode tmpRegDetalle = null;
        public List<CrtForms.ListaComboBox> lstG1CbHcl_tipreg_hcbd;

        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaSolicitBalanceLiqAdd(String tcrModoAccion, String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            InitializeComponent();
            IniciarComboBox();
            llgObjetosCargados = true;
            gcrCodigoMaestro  = String.Empty;
            gcrCodigoRegistro = tcrCodigoRegistro;
            gcrCodigoAdmision = tcrCodigoAdmision;

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;
            this.txtG1Sia_codpfa_prof.Text = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario).sia_codpfa_prof;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            this.dpkG1Hcl_gesfec_hcbd.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG2Hcl_gesfec_hcbd.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
            if (!String.IsNullOrWhiteSpace(tcrCodigoRegistro))
            {
                EFhclregordeserde lobReg = HCLValidarCodigo.fobRegBuscarHclregordeserde(tcrCodigoRegistro);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.hcl_nroreg_hcor)) { llgExiste = true; }
            }

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

            var lobRegEx = ModeloHclregbliqidoms.flsListaHclregbliqidomsEx("2", gcrCodigoAdmision, "1");
            if (lobRegEx.Count != 0)
            {
                tmpRegMaestro = lobRegEx.FirstOrDefault();
                gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcbm;
            }

            gcrTipoRegistro = "2";
            fcvActivarTabs("1");
            this.txtG1Hcl_tipreg_hcbd.Text = "1";
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
                fcvCargarRegActivoDesdeVariables();
                lcrNuevoCodigo = ModeloHclregbliqidode.flgAddRegistro(tmpRegDetalle);
                fcvRetornoInterface(gcrCodigoMaestro);
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
                    this.txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Hcl_codliq_hctl":
                    this.txtG1Hcl_codliq_hctl.Text = tcrCodigo;
                    break;

                case "txtG1Hcl_vialiq_hcvl":
                    this.txtG1Hcl_vialiq_hcvl.Text = tcrCodigo;
                    break;

                case "txtG2Hcl_codliq_hctl":
                    this.txtG2Hcl_codliq_hctl.Text = tcrCodigo;
                    break;

                case "txtG2Hcl_vialiq_hcvl":
                    this.txtG2Hcl_vialiq_hcvl.Text = tcrCodigo;
                    break;

            }
        }
        // HCLREGORDESERVI : Maestro ordenes servicios intrahospitalarios
        #region KeyDown para campos con F2 Tabla: HCLREGORDESERVI
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
        #region HCL_CODLIQ_HCTL : Nombres tipos de liquidos administrados o eliminados
        private void txtG1Hcl_codliq_hctl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                gcrCtrF2TexBox = ((TextBox)sender).Name;
                var lcrTitulo = fcrTituloTipoLiquidos() + "...";
                var lcrFiltro = gcrCtrF2TexBox == "txtG1Hcl_codliq_hctl" ? "Hcltipoliquidos.hcl_tipliq_hctl ='1'" : "Hcltipoliquidos.hcl_tipliq_hctl ='2'";

                Browser01 frbro = new Browser01("HCL", "HCLTIPOLIQUIDOS", lcrFiltro, lcrTitulo);
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region HCL_CODLIQ_HCTL : Browser desde boton - Nombres tipos de liquidos administrados o eliminados
        private void fcvTipoLiquidoAdmElim(object sender, RoutedEventArgs e)
        {
            var lcrNombreBoton  = ((Button)sender).Name;
            var lcrTitulo       = fcrTituloTipoLiquidos() + "...";
            var lcrFiltro       = this.txtG1Hcl_tipreg_hcbd.Text != "3" ? "Hcltipoliquidos.hcl_tipliq_hctl ='1'" : "Hcltipoliquidos.hcl_tipliq_hctl ='2'";
            gcrCtrF2TexBox      = lcrNombreBoton == "cmdBrowAdmTipoLiquido" ? "txtG1Hcl_codliq_hctl" : "txtG2Hcl_codliq_hctl";

            Browser01 frbro = new Browser01("HCL", "HCLTIPOLIQUIDOS", lcrFiltro, lcrTitulo);
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region HCL_VIALIQ_HCVL : Vias de administración o eliminación de  liquidos
        private void txtG1Hcl_vialiq_hcvl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                gcrCtrF2TexBox = ((TextBox)sender).Name;
                var lcrTitulo = "Via " + fcrTituloTipoLiquidos() + "...";
                var lcrFiltro = this.txtG1Hcl_tipreg_hcbd.Text != "3" ? "Hclviasliquidos.hcl_tipliq_hcvl ='1'" : "Hclviasliquidos.hcl_tipliq_hcvl ='2'";

                Browser01 frbro = new Browser01("HCL", "HCLVIASLIQUIDOS", lcrFiltro, lcrTitulo);
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region HCL_VIALIQ_HCVL : Browser desde boton - Vias de administración o eliminación de  liquidos
        private void fcvViaAdmElimLiquidos(object sender, RoutedEventArgs e)
        {
            var lcrNombreBoton = ((Button)sender).Name;
            var lcrTitulo = "Via " + fcrTituloTipoLiquidos() + "...";

            gcrCtrF2TexBox = lcrNombreBoton == "cmdBrowViaAdmliquido" ? "txtG1Hcl_vialiq_hcvl" : "txtG2Hcl_vialiq_hcvl";
            var lcrFiltro = gcrCtrF2TexBox == "txtG1Hcl_vialiq_hcvl" ? "Hclviasliquidos.hcl_tipliq_hcvl ='1'" : "Hclviasliquidos.hcl_tipliq_hcvl ='2'";

            Browser01 frbro = new Browser01("HCL", "HCLVIASLIQUIDOS", lcrFiltro, lcrTitulo);
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #region Titulos del Browser tipos de liquidos Indicados administrados o eliminados
        private String fcrTituloTipoLiquidos()
        {
            var lcrTitulo = "Liquidos administrados";

            if (this.txtG1Hcl_tipreg_hcbd.Text == "1")
            {
                lcrTitulo = "Liquidos indicados";
            }
            else if (this.txtG1Hcl_tipreg_hcbd.Text == "2")
            {
                lcrTitulo = "Liquidos administrados";
            }
            else if (this.txtG1Hcl_tipreg_hcbd.Text == "3")
            {
                lcrTitulo = "Liquidos eliminados";
            }
            return lcrTitulo;
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

                    switch (lobCombo.Name)
                    {
                        case "cboG1Hcl_tipreg_hcbd":
                            txtG1Hcl_tipreg_hcbd.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_tipreg_hcbd.Text, ",", lobList.ListaValoresSel)-1;
                            fcvActivarTabs(txtG1Hcl_tipreg_hcbd.Text);
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
                /*
                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
                        case "txtG1Hcl_tipreg_hcbd":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Hcl_tipreg_hcbd.SelectedItem;
                            cboG1Hcl_tipreg_hcbd.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            fcvActivarTabs(lcrValor);
                            break;
                    }
                    fcrValidacion(lobTexto.Name, lobTexto);
                }
                */
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarComboBoxOpcion");
            }
        }
        #endregion
        #region fcvActivarTabs: activa el tabs segun el tipo registro a diligenciar
        /// <summary>
        /// <para>activa el tabs segun el tipo registro a diligenciar</para>
        /// </summary>
        private void fcvActivarTabs(String tcrTipoVista)
        {
            if (tcrTipoVista == "1") // Liqudos indicados
            {
                if (gcrTipoRegistro != "1")
                {
                    gcrTipoRegistro = "1";
                    this.pagLiqAdm.Visibility = Visibility.Visible;
                    this.pagLiqElim.Visibility = Visibility.Collapsed;
                    this.pagDatos.SelectedItem = pagLiqAdm;
                    this.pagLiqAdm.Header = "Liquidos indicados";
                    this.lblG1hcl_codliq_hctl.Text = "Liquido indicado";
                }
            }
            else if (tcrTipoVista == "2") // Administracion de liqudos
            {
                if (gcrTipoRegistro != "2")
                {
                    gcrTipoRegistro = "2";
                    this.pagLiqAdm.Visibility = Visibility.Visible;
                    this.pagLiqElim.Visibility = Visibility.Collapsed;
                    this.pagDatos.SelectedItem = pagLiqAdm;
                    this.pagLiqAdm.Header = "Liquidos administrados";
                    this.lblG1hcl_codliq_hctl.Text = "Liquido administrado";
                }
            }
            else if (tcrTipoVista == "3")
            {
                if (gcrTipoRegistro != "3")
                {
                    gcrTipoRegistro = "3";
                    this.pagLiqAdm.Visibility = Visibility.Collapsed;
                    this.pagLiqElim.Visibility = Visibility.Visible;
                    this.pagDatos.SelectedItem = pagLiqElim;
                }
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
                    case "dpkG1Hcl_gesfec_hcbd":
                        txtG1Hcl_gesfec_hcbd.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcbd);
                        break;

                    case "dpkG2Hcl_gesfec_hcbd":
                        txtG2Hcl_gesfec_hcbd.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG2Hcl_gesfec_hcbd);
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
                            case "txtG1Hcl_gesfec_hcbd":
                                dpkG1Hcl_gesfec_hcbd.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtG2Hcl_gesfec_hcbd":
                                dpkG2Hcl_gesfec_hcbd.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                        }
                    }
                    fcrValidacion(lobTexto.Name, lobTexto);
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
                    fcrValidacion(lobTexto.Name, lobTexto);
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
            tmpRegDetalle = new ModeloHclregbliqidode();
            if (!String.IsNullOrWhiteSpace(gcrCodigoAdmision))
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision);
                if (lobRegAdm.Count == 0) { return; }
                tmpRegAdm = lobRegAdm.FirstOrDefault();

                tmpRegMaestro = ModeloHclregbliqidoms.flsListaHclregbliqidomsEx("2", gcrCodigoAdmision, "1").FirstOrDefault();

            }
            this.txtG1Hcl_gesfec_hcbd.Text = DateTime.Now.ToShortDateString();
            this.txtG2Hcl_gesfec_hcbd.Text = DateTime.Now.ToShortDateString();
            this.txtG1Hcl_horini_hcbd.Text = Funciones.fcrHoraActual("12", ":");
            this.txtG2Hcl_horeli_hcbd.Text = Funciones.fcrHoraActual("12", ":");
            this.txtG1Hcl_cantid_hcbd.Text = "1";
            this.txtG2Hcl_cantid_hcbd.Text = "1";
        }
        #endregion
        #region Cargar datos existentes
        private void fcvCargarDatosExitentes(String tcrCodigo)
        {
            // cargar datos
        }
        #endregion
        #region fcvCargarRegActivoDesdeVariables: Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariables()
        {
            try
            {
                #region Valores Variables
                tmpRegDetalle.Hcl_nroreg_hcbm = tmpRegMaestro.Hcl_nroreg_hcbm;
                tmpRegDetalle.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                tmpRegDetalle.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegDetalle.Hcl_tipreg_hcbd = gcrTipoRegistro;
                tmpRegDetalle.Hcl_tiptur_hctu = tmpRegMaestro.Hcl_tiptur_hctu;
                tmpRegDetalle.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegDetalle.Hcl_sisfec_hcbd = DateTime.Now;
                tmpRegDetalle.Hcl_sishor_hcbd = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                tmpRegDetalle.Sis_estpro_espr = "1";
                #endregion

                if (gcrTipoRegistro == "1" || gcrTipoRegistro == "2") // Administracion de liqudos
                {
                    #region Valores Variables
                    tmpRegDetalle.Hcl_codliq_hctl = this.txtG1Hcl_codliq_hctl.Text;
                    tmpRegDetalle.Hcl_vialiq_hcvl = this.txtG1Hcl_vialiq_hcvl.Text;
                    tmpRegDetalle.Hcl_gesfec_hcbd = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcbd.Text);
                    tmpRegDetalle.Hcl_cantid_hcbd = Decimal.Parse(this.txtG1Hcl_cantid_hcbd.Text);
                    tmpRegDetalle.Hcl_horini_hcbd = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_horini_hcbd.Text, "12", ":", gcrSeparadorDecimal));
                    tmpRegDetalle.Hcl_horfin_hcbd = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_horfin_hcbd.Text, "12", ":", gcrSeparadorDecimal));
                    tmpRegDetalle.Hcl_notreg_hcbd = this.txtG1Hcl_notreg_hcbd.Text;
                    #endregion
                }
                else 
                {
                    #region Valores Variables
                    tmpRegDetalle.Hcl_codliq_hctl = this.txtG2Hcl_codliq_hctl.Text;
                    tmpRegDetalle.Hcl_vialiq_hcvl = this.txtG2Hcl_vialiq_hcvl.Text;
                    tmpRegDetalle.Hcl_gesfec_hcbd = Funciones.fdaConvertFecha("DMY", "/", this.txtG2Hcl_gesfec_hcbd.Text);
                    tmpRegDetalle.Hcl_cantid_hcbd = Decimal.Parse(this.txtG2Hcl_cantid_hcbd.Text);
                    tmpRegDetalle.Hcl_horeli_hcbd = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG2Hcl_horeli_hcbd.Text, "12", ":", gcrSeparadorDecimal));
                    tmpRegDetalle.Hcl_notreg_hcbd = this.txtG2Hcl_notreg_hcbd.Text;
                    #endregion
                }

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
            var lobTextBox = sender as TextBox;
            fcrValidacion(lobTextBox.Name, lobTextBox);
        }
        #endregion
        #region flgValidacion: Valida todos los datos antes de guardar
        /// <summary>
        /// Valida todos los datos antes de guardar
        /// </summary>
        public bool flgValidacion()
        {
            var lnuCont = 0;

            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codpfa_prof", txtG1Sia_codpfa_prof))) { lnuCont++; }

            if (gcrTipoRegistro == "1" || gcrTipoRegistro == "2") // Administracion de liqudos
            {
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_gesfec_hcbd", txtG1Hcl_gesfec_hcbd))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_horini_hcbd", txtG1Hcl_horini_hcbd))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_horfin_hcbd", txtG1Hcl_horfin_hcbd))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_codliq_hctl", txtG1Hcl_codliq_hctl))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_vialiq_hcvl", txtG1Hcl_vialiq_hcvl))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_cantid_hcbd", txtG1Hcl_cantid_hcbd))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_notreg_hcbd", txtG1Hcl_notreg_hcbd))) { lnuCont++; }
            }
            else 
            {
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_gesfec_hcbd", txtG2Hcl_gesfec_hcbd))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG2Hcl_horeli_hcbd", txtG2Hcl_horeli_hcbd))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG2Hcl_codliq_hctl", txtG2Hcl_codliq_hctl))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG2Hcl_vialiq_hcvl", txtG2Hcl_vialiq_hcvl))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG2Hcl_cantid_hcbd", txtG2Hcl_cantid_hcbd))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG2Hcl_notreg_hcbd", txtG2Hcl_notreg_hcbd))) { lnuCont++; }
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
        public String fcrValidacion(String tcrNombrePropiedad, TextBox tobObjetoTexto)
        {
            string lcrValorReturn = string.Empty;
            try
            {
                var lcrTitulo = String.Empty;

                //---------------------------------------------
                //- PROFESIONAL
                //---------------------------------------------
                if (tcrNombrePropiedad == "txtG1Sia_codpfa_prof")
                {
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
                }
                //---------------------------------------------
                //- TIPO LIQUIDOS ADMINISTRADOS O ELIMINADOS
                //---------------------------------------------
                else if (tcrNombrePropiedad == "txtG1Hcl_codliq_hctl" || tcrNombrePropiedad == "txtG2Hcl_codliq_hctl")
                {

                    lcrTitulo = tobObjetoTexto.Name == "txtG1Hcl_codliq_hctl" ? "Liquido administrado" : "Liquido eliminado";
                    if (string.IsNullOrWhiteSpace(tobObjetoTexto.Text))
                    {
                        lcrValorReturn = lcrTitulo + ": Es requerido";
                    }
                    else
                    {
                        EFhcltipoliquidos tmp = new EFhcltipoliquidos();
                        tmp = HCLValidarCodigo.fobRegBuscarHcltipoliquidos(tobObjetoTexto.Text);
                        if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hcl_desliq_hctl))
                        {
                            if (gcrTipoRegistro == "1" || gcrTipoRegistro == "2") // Liquidos indicados y Administracion de liqudos 
                            {
                                this.txtG1Hcl_desliq_hctl.Text = tmp.hcl_desliq_hctl;
                            }
                            else
                            {
                                this.txtG2Hcl_desliq_hctl.Text = tmp.hcl_desliq_hctl;
                            }
                            if (tobObjetoTexto.Name == "txtG1Hcl_codliq_hctl" && tmp.hcl_tipliq_hctl == "2")
                            {
                                lcrValorReturn = lcrTitulo + ": Tipo liquido administrado no valido";
                            }
                            else if (tobObjetoTexto.Name == "txtG2Hcl_codliq_hctl" && tmp.hcl_tipliq_hctl == "1")
                            {
                                lcrValorReturn = lcrTitulo + ": Tipo liquido eliminado no valido";
                            }
                        }
                        else
                        {
                            lcrValorReturn = lcrTitulo + ": No existe";
                        }
                    }
                    fcvSetColorValidacion(tobObjetoTexto, lcrValorReturn);
                }
                //---------------------------------------------
                //- VIA ADMINISTRACICION O ELIMINACION
                //---------------------------------------------
                else if (tcrNombrePropiedad == "txtG1Hcl_vialiq_hcvl" || tcrNombrePropiedad == "txtG2Hcl_vialiq_hcvl")
                {
                    lcrTitulo = tobObjetoTexto.Name == "txtG1Hcl_vialiq_hcvl" ? "Via administración" : "Via eliminación";
                    if (string.IsNullOrWhiteSpace(tobObjetoTexto.Text))
                    {
                        lcrValorReturn = lcrTitulo + ": Es requerida";
                    }
                    else
                    {
                        EFhclviasliquidos tmp = new EFhclviasliquidos();
                        tmp = HCLValidarCodigo.fobRegBuscarHclviasliquidos(tobObjetoTexto.Text);
                        if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hcl_desvia_hcvl))
                        {
                            if (gcrTipoRegistro == "1" || gcrTipoRegistro == "2") // Liquidos indicados y Administracion de liqudos 
                            {
                                this.txtG1Hcl_desvia_hcvl.Text = tmp.hcl_desvia_hcvl;
                            }
                            else
                            {
                                this.txtG2Hcl_desvia_hcvl.Text = tmp.hcl_desvia_hcvl;
                            }
                            if (tobObjetoTexto.Name == "txtG1Hcl_vialiq_hcvl" && tmp.hcl_tipliq_hcvl == "2")
                            {
                                lcrValorReturn = lcrTitulo + ": Via administracion liquido no valida";
                            }
                            else if (tobObjetoTexto.Name == "txtG2Hcl_vialiq_hcvl" && tmp.hcl_tipliq_hcvl == "1")
                            {
                                lcrValorReturn = lcrTitulo + ": Via eliminacion liquido no valida";
                            }
                        }
                        else
                        {
                            lcrValorReturn = lcrTitulo + ": No existe";
                        }
                    }
                    fcvSetColorValidacion(tobObjetoTexto, lcrValorReturn);
                }
                //---------------------------------------------
                //- FECHA ACTIVIDAD
                //---------------------------------------------
                else if (tcrNombrePropiedad == "txtG1Hcl_gesfec_hcbd")
                {
                    lcrTitulo = "Fecha actividad";
                    lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", tobObjetoTexto.Text, lcrTitulo);
                    fcvSetColorValidacion(tobObjetoTexto, lcrValorReturn);
                    if (String.IsNullOrWhiteSpace(lcrValorReturn))
                    {
                        tobObjetoTexto.BorderBrush = Brushes.White;
                    }
                }
                //---------------------------------------------
                // HORA HORA INICIA
                //---------------------------------------------
                else if (tcrNombrePropiedad == "txtG1Hcl_horini_hcbd")
                {

                    lcrValorReturn = Funciones.fcrValidaHoraTexto(true, txtG1Hcl_horini_hcbd.Text, "12", ":", "Hora inicia");
                    fcvSetColorValidacion(txtG1Hcl_horini_hcbd, lcrValorReturn);
                }
                //---------------------------------------------
                // HORA FINALIZA
                //---------------------------------------------
                else if (tcrNombrePropiedad == "txtG1Hcl_horfin_hcbd")
                {

                    lcrValorReturn = Funciones.fcrValidaHoraTexto(true, txtG1Hcl_horfin_hcbd.Text, "12", ":", "Hora finaliza");
                    fcvSetColorValidacion(txtG1Hcl_horfin_hcbd, lcrValorReturn);
                }
                //---------------------------------------------
                // HORA ELIMINACION
                //---------------------------------------------
                else if (tcrNombrePropiedad == "txtG2Hcl_horeli_hcbd")
                {

                    lcrValorReturn = Funciones.fcrValidaHoraTexto(true, txtG2Hcl_horeli_hcbd.Text, "12", ":", "Hora eliminación");
                    fcvSetColorValidacion(txtG2Hcl_horeli_hcbd, lcrValorReturn);

                }
                //---------------------------------------------
                // CANTIDAD ADMINISTRADA O ELIMINADA
                //---------------------------------------------
                else if (tcrNombrePropiedad == "txtG1Hcl_vialiq_hcvl" || tcrNombrePropiedad == "txtG2Hcl_vialiq_hcvl")
                {

                    lcrTitulo = tobObjetoTexto.Name == "txtG1Hcl_cantid_hcbd" ? "Cantidad administrada" : "Cantidad eliminada";
                    if (String.IsNullOrWhiteSpace(tobObjetoTexto.Text))
                    {
                        lcrValorReturn = lcrTitulo + ": Debe ser mayor que cero";
                    }
                    else
                    {
                        if (Funciones.flgSoloNumeros(tobObjetoTexto.Text))
                        {
                            if (Convert.ToUInt32(tobObjetoTexto.Text) < 1 || Convert.ToUInt32(tobObjetoTexto.Text) > 4500)
                            {
                                lcrValorReturn = lcrTitulo + ": Valor fuera del rango";
                            }
                        }
                        else
                        {
                            lcrValorReturn = lcrTitulo + ": Valor debe ser númerico";
                        }
                    }
                    fcvSetColorValidacion(tobObjetoTexto, lcrValorReturn);
                }
                //---------------------------------------------
                // OBSERVACION 
                //---------------------------------------------
                else if (tcrNombrePropiedad == "txtG1Hcl_notreg_hcbd")
                {
                    lcrTitulo = "Observación";
                    if (String.IsNullOrWhiteSpace(tobObjetoTexto.Text))
                    {
                        lcrValorReturn = lcrTitulo + ": Es requerida";
                    }
                    fcvSetColorValidacion(tobObjetoTexto, lcrValorReturn);
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
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void IniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                // TIPO REGISTRO A DILIGENCIAR
                //-------------------------------------------------
                #region HOS_TIREG_HCBD: Gestion Balance de liquidos
                string lcrG11Seleccion = "1,2,3";
                string lcrG11Descripcion = "Liquidos indicados,Liuqidos administrados,Liquidos eliminados";
                lstG1CbHcl_tipreg_hcbd = new List<CrtForms.ListaComboBox>();
                lstG1CbHcl_tipreg_hcbd = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion,"1");
                //- Asignar al control
                this.cboG1Hcl_tipreg_hcbd.ItemsSource = lstG1CbHcl_tipreg_hcbd;
                this.cboG1Hcl_tipreg_hcbd.SelectedIndex = Convert.ToInt32(lstG1CbHcl_tipreg_hcbd[0].IdIndice);
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
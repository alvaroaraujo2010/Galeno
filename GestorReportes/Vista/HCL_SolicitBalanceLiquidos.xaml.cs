//- MARMOTA-GENCODE: VERSION 2.0 - 19/06/2014 06:28:50 AM
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
    public partial class VistaMsBalanceLiquidos : Window, SIS_Interface
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
        public ModeloHclregbliqidoms tmpRegMaestro = null;
        public ModeloHclregbliqidode tmpRegDetalle = null;
        public List<CrtForms.ListaComboBox> lstG1Hcl_tipser_hcor;

        /// <summary>
        /// <para>tcrTipoRegistro: "1" = Apertura registro turno Balance de liquidos "2" = Cierre Registro del turno</para>
        /// </summary>
        public VistaMsBalanceLiquidos(String tcrModoAccion, String tcrTipoRegistro, String tcrCodigoRegistro, String tcrCodigoAdmision)
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
            this.dpkG1Hcl_fecape_hcbm.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            this.dpkG1Hcl_feccie_hcbm.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
                EFhclregbliqidoms lobReg = HCLValidarCodigo.fobRegBuscarHclregbliqidoms(tcrCodigoRegistro);
                if (lobReg != null && !String.IsNullOrWhiteSpace(lobReg.hcl_nroreg_hcbm)) { llgExiste = true; }
            }
            // Solo mostrar la pestaña requerida
            if (gcrTipoRegistro=="1")
            {
                this.pagTabsCierre.Visibility = Visibility.Collapsed;
                this.pagRegistro.SelectedItem = pagTabsApertura;

            }
           else
            {
                this.pagTabsApertura.Visibility = Visibility.Collapsed;
                this.pagRegistro.SelectedItem = pagTabsCierre;
                flgGenerarResumenCierre();
            }

            this.txtG1Hcl_feccie_hcbm.Text = DateTime.Now.ToShortDateString();
            this.txtG1Hcl_horcie_hcbm.Text = Funciones.fcrHoraActual("12", gcrSeparadorDecimal);

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
                if (MessageBox.Show("Desea confirmar el cierre?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    if (flgGenerarRegistroMaestro() == true)
                    {
                        fcvRetornoInterface(gcrCodigoMaestro);
                    }
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
                var lobReg = ModeloHclregbliqidoms.flsListaHclregbliqidomsEx("2", gcrCodigoAdmision, "1");
                if (lobReg.Count != 0)
                {
                    tmpRegMaestro = lobReg.FirstOrDefault();
                    var lcrCodigoHistorial = fcvHclinicaGenerarActividad();

                    // Datos para el cierre turno
                    #region Valores Variables
                    tmpRegMaestro.Hcl_nroreg_hcev = lcrCodigoHistorial;
                    tmpRegMaestro.Hcl_feccie_hcbm = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_feccie_hcbm.Text);
                    tmpRegMaestro.Hcl_horcie_hcbm = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_horcie_hcbm.Text, "12", ":", gcrSeparadorDecimal));
                    tmpRegMaestro.Hcl_totind_hcbm = Convert.ToDecimal(this.txtG1Hcl_totind_hcbm.Text);
                    tmpRegMaestro.Hcl_totadm_hcbm = Convert.ToDecimal(this.txtG1Hcl_totadm_hcbm.Text);
                    tmpRegMaestro.Hcl_toteli_hcbm = Convert.ToDecimal(this.txtG1Hcl_toteli_hcbm.Text);
                    tmpRegMaestro.Hcl_totpen_hcbm = Convert.ToDecimal(this.txtG1Hcl_totpen_hcbm.Text);
                    tmpRegMaestro.Hcl_result_hcbm = Convert.ToDecimal(this.txtG1Hcl_result_hcbm.Text);
                    tmpRegMaestro.Hcl_obscie_hcbm = this.txtG1Hcl_obscie_hcbm.Text;
                    tmpRegMaestro.Sis_estpro_espr = "2";
                    ModeloHclregbliqidoms.fcvActualizar(tmpRegMaestro);
                    //--------------------------
                    // cerrar registros detalles
                    //--------------------------
                    var lobDetall = ModeloHclregbliqidode.flsListaHclregbliqidode("R1", tmpRegMaestro.Hcl_nroreg_hcbm);
                    if (lobDetall.Count != 0)
                    {
                        foreach (var lobRegEx in lobDetall)
                        {
                            lobRegEx.Sis_estpro_espr = "2";
                            ModeloHclregbliqidode.fcvActualizar(lobRegEx);
                        }
                        llgReturn = true;
                    }
                    #endregion
                    llgReturn = true;
                    gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcbm;
                }
            }
            else
            {
                // Adicionar el registro
                tmpRegMaestro = new ModeloHclregbliqidoms();

                EFhcltiporegturno tmp = new EFhcltiporegturno();
                tmp = HCLValidarCodigo.fobRegBuscarHcltiporegturno(this.txtG1Hcl_tiptur_hctu.Text);

                #region Valores Variables
                tmpRegMaestro.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                tmpRegMaestro.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegMaestro.Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
                tmpRegMaestro.Hcl_fecape_hcbm = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_fecape_hcbm.Text);
                tmpRegMaestro.Hcl_tiptur_hctu = this.txtG1Hcl_tiptur_hctu.Text;
                tmpRegMaestro.Hcl_horini_hcbm = (Decimal)tmp.hcl_horini_hctu;
                tmpRegMaestro.Hcl_horfin_hcbm = (Decimal)tmp.hcl_horfin_hctu;
                tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegMaestro.Hcl_sisfec_hcbm = DateTime.Now;
                tmpRegMaestro.Hcl_sishor_hcbm = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                tmpRegMaestro.Hcl_totape_hcbm = Convert.ToDecimal(this.txtG1Hcl_totape_hcbm.Text);
                tmpRegMaestro.Hcl_obsape_hcbm = this.txtG1Hcl_obsape_hcbm.Text;
                tmpRegMaestro.Sis_estpro_espr = "1";

                gcrCodigoMaestro = ModeloHclregbliqidoms.flgAddRegistro(tmpRegMaestro);
                tmpRegMaestro.Hcl_nroreg_hcbm = gcrCodigoMaestro;
                #endregion

                llgReturn = !String.IsNullOrWhiteSpace(gcrCodigoMaestro) ? true : false;
            }
            return llgReturn;
        }
        #endregion
        #region flgGenerarResumenCierre: Generar datos resumen del cierre turno
        /// <summary>
        /// <para>Generar datos resumen del cierre turno</para>
        /// </summary>
        public bool flgGenerarResumenCierre()
        {
            var llgReturn = false;
            var lobReg = ModeloHclregbliqidoms.flsListaHclregbliqidomsEx("2", gcrCodigoAdmision, "1");
            if (lobReg.Count != 0)
            {
                tmpRegMaestro = lobReg.FirstOrDefault();

                Decimal lnuTotalIndicados    = 0;
                Decimal lnuTotalAdministrado = 0;
                Decimal lnuTotalEliminados = 0;
                Decimal lnuTotalPendientes = tmpRegMaestro.Hcl_totape_hcbm; // el pendiente la apertura
                Decimal lnutotalResultado  = 0;
                //--------------------------
                // Generar Resumen 
                //--------------------------
                var lobDetall = ModeloHclregbliqidode.flsListaHclregbliqidode("R1", tmpRegMaestro.Hcl_nroreg_hcbm);
                if (lobDetall.Count != 0)
                {
                    foreach (var lobRegEx in lobDetall)
                    {
                        lnuTotalIndicados    = lobRegEx.Hcl_tipreg_hcbd == "1" ? lnuTotalIndicados + lobRegEx.Hcl_cantid_hcbd : lnuTotalIndicados;
                        lnuTotalAdministrado = lobRegEx.Hcl_tipreg_hcbd == "2" ? lnuTotalAdministrado + lobRegEx.Hcl_cantid_hcbd : lnuTotalAdministrado;
                        lnuTotalEliminados = lobRegEx.Hcl_tipreg_hcbd == "3" ? lnuTotalEliminados + lobRegEx.Hcl_cantid_hcbd : lnuTotalEliminados;
                    }
                    lnutotalResultado = lnuTotalAdministrado - lnuTotalEliminados;
                    lnuTotalPendientes = (lnuTotalIndicados + lnuTotalPendientes) - lnuTotalAdministrado;
                }
                this.txtG1Hcl_totind_hcbm.Text = lnuTotalIndicados.ToString();
                this.txtG1Hcl_totadm_hcbm.Text = lnuTotalAdministrado.ToString();
                this.txtG1Hcl_toteli_hcbm.Text = lnuTotalEliminados.ToString();
                this.txtG1Hcl_result_hcbm.Text = lnutotalResultado.ToString();
                this.txtG1Hcl_totpen_hcbm.Text = lnuTotalPendientes.ToString();

                llgReturn = true;
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
        //  KeyDown llamada funciones compos con F2
        //-------------------------------------------------
        #region llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            /*
            Browser01 frbro = new Browser01("HCL", "HCLREGORDESERVI", "", "Maestro ordenes servicios intrahospitalarios...");
            gcrCtrF2TexBox = "txtG1Hcl_nroreg_hcor";
            frbro.Owner = this;
            frbro.ShowDialog();
            */
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
                    this.txtG1Hcl_tiptur_hctu.Text = tcrCodigo;
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
                Browser01 frbro = new Browser01("SIA", "SIAAREAPRESERVI", "", "Areas prestacion de servicios...");
                gcrCtrF2TexBox = "txtG1Sia_codare_aser";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODARE_ASER : Browser desde boton - Areas prestacion de servicios
        private void fcvBuscarAreaServicios(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIA", "SIAAREAPRESERVI", "", "Areas prestacion de servicios...");
            gcrCtrF2TexBox = "txtG1Sia_codare_aser";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
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
                        case "cboG1Hcl_tipser_hcor":
                            /*
                            txtG1Hcl_tipser_hcor.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_tipser_hcor.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_tipser_hcor.Text, ",", lobList.ListaValoresSel);
                            */
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
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
                        case "txtG1Hcl_tipser_hcor":
                            /*
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Hcl_tipser_hcor.SelectedItem;
                            cboG1Hcl_tipser_hcor.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            */
                            break;
                    }
                    fcrValidacion(lobTexto.Name);
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
                        txtG1Hcl_fecape_hcbm.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Hcl_fecape_hcbm);
                        break;

                    case "txtG1Hcl_feccie_hcbm":
                        txtG1Hcl_feccie_hcbm.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Hcl_feccie_hcbm);
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
                                dpkG1Hcl_fecape_hcbm.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;

                            case "txtG1Hcl_feccie_hcbm":
                                dpkG1Hcl_feccie_hcbm.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
            //tmpRegDetalle = new ModeloHclregordeserde();
            if (!String.IsNullOrWhiteSpace(gcrCodigoAdmision))
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision);
                if (lobRegAdm.Count == 0) { return; }
                tmpRegAdm = lobRegAdm.FirstOrDefault();
            }
            txtG1Hcl_fecape_hcbm.Text = DateTime.Now.ToShortDateString();
            //txtG1Hcl_geshor_hcor.Text = Funciones.fcrHoraActual("12", ":");
            //txtG1Hcl_totuni_hcor.Text = "1";
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
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_fecape_hcbm"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_tiptur_hctu"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_totape_hcbm"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codare_aser"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_obsape_hcbm"))) { lnuCont++; }
            }
            else 
            {
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_feccie_hcbm"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_toteli_hcbm"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_totadm_hcbm"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_horcie_hcbm"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_totpen_hcbm"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_obscie_hcbm"))) { lnuCont++; }
                if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_totpen_hcbm"))) { lnuCont++; }
                
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

                    case "txtG1Hcl_fecape_hcbm":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", txtG1Hcl_fecape_hcbm.Text, "Fecha apertura");
                        fcvSetColorValidacion(txtG1Hcl_fecape_hcbm, lcrValorReturn);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            txtG1Hcl_fecape_hcbm.BorderBrush = Brushes.White;
                        }
                        break;

                    case "txtG1Hcl_totape_hcbm":
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_totape_hcbm.Text))
                        {
                            this.txtG1Hcl_totape_hcbm.Text = "0";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumeros(txtG1Hcl_totape_hcbm.Text))
                            {
                                if (Convert.ToUInt32(txtG1Hcl_totape_hcbm.Text) < 0 || Convert.ToUInt32(txtG1Hcl_totape_hcbm.Text) > 2500)
                                {
                                    lcrValorReturn = "Total liquidos pendientes: Valor fuera del rango";
                                }
                            }
                            else 
                            {
                                lcrValorReturn = "Total liquidos pendientes: Valor debe ser solo numerico";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_totape_hcbm, lcrValorReturn);
                        break;

                    case "txtG1Hcl_tiptur_hctu":
                        if (String.IsNullOrWhiteSpace(this.txtG1Hcl_tiptur_hctu.Text))
                        {
                            lcrValorReturn = "Codigo turno: Es requerido";
                        }
                        else
                        {
                            EFhcltiporegturno tmp = new EFhcltiporegturno();
                            tmp = HCLValidarCodigo.fobRegBuscarHcltiporegturno(this.txtG1Hcl_tiptur_hctu.Text);
                            if (tmp != null && tmp.hcl_destur_hctu != null)
                            {
                                this.txtG1Hcl_destur_hctu.Text = tmp.hcl_destur_hctu;
                                this.txtG1Hcl_horini_hcbm.Text = Funciones.fcrConvierteHora(tmp.hcl_horini_hctu.ToString(), "24", gcrSeparadorDecimal, ":");
                                this.txtG1Hcl_horfin_hcbm.Text = Funciones.fcrConvierteHora(tmp.hcl_horfin_hctu.ToString(), "24", gcrSeparadorDecimal, ":");
                            }
                            else
                            {
                                lcrValorReturn = "Codigo turno: No existe";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_tiptur_hctu, lcrValorReturn);
                        break;

                    case "txtG1Hcl_obsape_hcbm":
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_obsape_hcbm.Text))
                        {
                            lcrValorReturn = "Observación apertura: Es requerida";
                        }
                        fcvSetColorValidacion(txtG1Hcl_obsape_hcbm, lcrValorReturn);
                        break;

                        //------------------------------------------------------
                        // datos del cierre turno
                        //------------------------------------------------------
                    case "txtG1Hcl_feccie_hcbm":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", txtG1Hcl_feccie_hcbm.Text, "Fecha cierre turno");
                        fcvSetColorValidacion(txtG1Hcl_feccie_hcbm, lcrValorReturn);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            txtG1Hcl_feccie_hcbm.BorderBrush = Brushes.White;
                        }
                        break;

                    case "txtG1Hcl_horcie_hcbm":
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, txtG1Hcl_horcie_hcbm.Text, "12", ":", "Hora entrega turno");
                        fcvSetColorValidacion(txtG1Hcl_horcie_hcbm, lcrValorReturn);
                        break;

                    case "txtG1Hcl_obscie_hcbm":
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_obscie_hcbm.Text))
                        {
                            lcrValorReturn = "Observación cierre: Es requerida";
                        }
                        fcvSetColorValidacion(txtG1Hcl_obscie_hcbm, lcrValorReturn);
                        break;

                    case "txtG1Hcl_toteli_hcbm":
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_toteli_hcbm.Text))
                        {
                            this.txtG1Hcl_toteli_hcbm.Text = "0";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumeros(txtG1Hcl_toteli_hcbm.Text))
                            {
                                if (Convert.ToUInt32(txtG1Hcl_toteli_hcbm.Text) < 0 || Convert.ToUInt32(txtG1Hcl_toteli_hcbm.Text) > 2500)
                                {
                                    lcrValorReturn = "Total liquidos eliminados: Valor fuera del rango";
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Total liquidos eliminados: Valor debe ser solo numerico";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_toteli_hcbm, lcrValorReturn);
                        break;

                    case "txtG1Hcl_totadm_hcbm":
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_totadm_hcbm.Text))
                        {
                            this.txtG1Hcl_totadm_hcbm.Text = "0";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumeros(txtG1Hcl_totadm_hcbm.Text))
                            {
                                if (Convert.ToUInt32(txtG1Hcl_totadm_hcbm.Text) < 0 || Convert.ToUInt32(txtG1Hcl_totadm_hcbm.Text) > 2500)
                                {
                                    lcrValorReturn = "Total liquidos administrados: Valor fuera del rango";
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Total liquidos administrados: Valor debe ser solo numerico";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_totadm_hcbm, lcrValorReturn);
                        break;

                    case "txtG1Hcl_totpen_hcbm":
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_totpen_hcbm.Text))
                        {
                            this.txtG1Hcl_totadm_hcbm.Text = "0";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumeros(txtG1Hcl_totpen_hcbm.Text))
                            {
                                if (Convert.ToUInt32(txtG1Hcl_totpen_hcbm.Text) < 0 || Convert.ToUInt32(txtG1Hcl_totpen_hcbm.Text) > 2500)
                                {
                                    lcrValorReturn = "Liquidos por administrar: Valor fuera del rango";
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Liquidos por administrar: Valor debe ser solo numerico";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_totpen_hcbm, lcrValorReturn);
                        break;

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
                tmpRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision).FirstOrDefault();
                var lobRegEx = HCLValidarCodigo.fobRegBuscarHcltiporegserms("BLIQ");
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(lobRegEx.hcl_codreg_hcca);

                if (!String.IsNullOrWhiteSpace(lobReg.grp_idepla_grpl))
                {
                    // Generar registro de actividad en historia clinica
                    var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);
                    var lobHist = new HclModeloHistorialEventos();

                    #region Datos del registro
                    lobHist.Hcl_secreg_hcev = 1;
                    lobHist.Hcl_nrohis_hicl = tmpRegAdm.Hcl_nrohis_hicl;
                    lobHist.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    lobHist.Cit_codasi_mcit = tmpRegAdm.Cit_codasi_mcit;
                    lobHist.Fcm_codcpr_cpro = String.Empty;
                    lobHist.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    lobHist.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    lobHist.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    lobHist.Hcl_codaux_hcev = tmpRegMaestro.Hcl_nroreg_hcbm;
                    lobHist.Hcl_gesfec_hcev = tmpRegMaestro.Hcl_fecape_hcbm;
                    lobHist.Hcl_geshor_hcev = tmpRegMaestro.Hcl_horini_hcbm;
                    lobHist.Sia_codpfa_prof = tmpRegMaestro.Sia_codpfa_prof;
                    lobHist.Hcl_keydat_hcev = fcrGenerarLlaveMs(tmpRegMaestro).ToLower() + " " + lobRegEx.hcl_desreg_hctr.ToLower();
                    lobHist.Hcl_xmldat_hcev = String.Empty;
                    lobHist.Hcl_xmltmp_hcev = String.Empty;
                    lobHist.Hcl_xmlcom_hcev = String.Empty;
                    lobHist.Hcl_conobj_hcev = 0;
                    lobHist.Hcl_desreg_hcev = lobRegEx.hcl_desreg_hctr;
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
        public String fcrGenerarLlaveMs(ModeloHclregbliqidoms tobRegistro)
        {
            // llave registro maestro
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + "  " + tobRegistro.Adm_secadm_rgad + "  " + tobRegistro.Hcl_nroreg_hcbm;
            var lcrllave2 = tobRegistro.Hcl_fecape_hcbm.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + "  " + tobRegistro.Sia_desare_aser;
            var lcrllave4 = String.Empty;

            // llave de los detalles
            var lobDetall = ModeloHclregbliqidode.flsListaHclregbliqidode("R1", tobRegistro.Hcl_nroreg_hcbm);
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
        public String fcrGenerarLlaveDetalles(ModeloHclregbliqidode tobRegistro)
        {
            var lcrllave1 = tobRegistro.Hcl_desliq_hctl + " " + tobRegistro.Hcl_desvia_hcvl + " " + tobRegistro.Hcl_notreg_hcbd;
            var lcrllave2 = tobRegistro.Hcl_gesfec_hcbd.ToString();

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
                // 
                //-------------------------------------------------
                #region HOS_TIPHAB_HABI: Unipersonal SI/NO
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Servicio,Inidicacion médica";
                lstG1Hcl_tipser_hcor = new List<CrtForms.ListaComboBox>();
                lstG1Hcl_tipser_hcor = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
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

    }
}
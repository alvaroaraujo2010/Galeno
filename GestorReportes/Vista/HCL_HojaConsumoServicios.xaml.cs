//- MARMOTA-GENCODE: VERSION 2.0 - 25/05/2014 12:12:21 PM
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
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Modelo;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GestorReportes.Modelo;
using GestorReportes.Vista;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclregordeservi
    /// </summary>
    public partial class HojaConsumoServicios : Window, SIS_Interface
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
        public String gcrCodigoMaestro = String.Empty;
        public String gcrCodigoRegistro = String.Empty;
        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public ModeloHclregordeserms tmpRegMaestro = null;
        public ModeloHclregordeserde tmpRegDetalle = null;
        public List<CrtForms.ListaComboBox> lstG1Hcl_tipser_hcor;

        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public HojaConsumoServicios(String tcrModoAccion, String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            InitializeComponent();
            IniciarComboBox();
            llgObjetosCargados = true;
            gcrCodigoMaestro = String.Empty;
            gcrCodigoRegistro = tcrCodigoRegistro;
            gcrCodigoAdmision = tcrCodigoAdmision;

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Hcl_gesfec_hcor.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
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
            FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcor);
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
                    lcrNuevoCodigo = ModeloHclregordeserde.flgAddRegistro(tmpRegDetalle);
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
            FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcor);
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
        #region  Validar Registro maestro R1
        //- Activar modo edicion en la Vista
        public bool flgGenerarRegistroMaestro()
        {
            var llgReturn = false;
            if (tmpRegMaestro == null)
            {
                var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx("SERV", gcrCodigoAdmision, "1");
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
                    tmpRegMaestro.Hcl_tipreg_hctr = "HCON";
                    tmpRegMaestro.Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
                    tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcor.Text);
                    tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
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

                case "txtG1Fcm_coddig_mant":
                    txtG1Fcm_coddig_mant.Text = tcrCodigo;
                    break;

            }
        }
        // HCLREGORDESERVI : Maestro ordenes servicios intrahospitalarios
        #region KeyDown para campos con F2 Tabla: HCLREGORDESERVI
        #region FCM_IDESEC_SIPS : Maestro de servicios habilitados para la IPS
        private void txtG1Fcm_idesec_sips_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIPSAUX", "", "Maestro de servicios ...");
                gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region FCM_IDESEC_SIPS : Maestro de servicios habilitados para la IPS
        private void fcvBuscarServicio(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIPSAUX", "", "Maestro de servicios ...");
            gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIS_ESTPRO_ESPR : Estados de procesos (Abierto, Cerrado,Anulado)
        private void txtG1Sis_estpro_espr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIS", "SISESTADOPROCES", "", "Estados de procesos (Abierto, Cerrado,Anulado)...");
                gcrCtrF2TexBox = "txtG1Sis_estpro_espr";
                frbro.Owner = this;
                frbro.ShowDialog();
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
                        case "cboG1Hcl_tipser_hcor":
                            txtG1Hcl_tipser_hcor.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_tipser_hcor.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_tipser_hcor.Text, ",", lobList.ListaValoresSel);
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
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Hcl_tipser_hcor.SelectedItem;
                            cboG1Hcl_tipser_hcor.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
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
                    case "dpkG1Hcl_gesfec_hcor":
                        txtG1Hcl_gesfec_hcor.Text = lobDpk.SelectedDate.ToString().Substring(0, 10);
                        FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcor);
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
            tmpRegDetalle = new ModeloHclregordeserde();
            if (!String.IsNullOrWhiteSpace(gcrCodigoAdmision))
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision);
                if (lobRegAdm.Count == 0) { return; }
                tmpRegAdm = lobRegAdm.FirstOrDefault();
            }
            txtG1Hcl_gesfec_hcor.Text = DateTime.Now.ToShortDateString();
            txtG1Hcl_geshor_hcor.Text = Funciones.fcrHoraActual("12", ":");
            txtG1Hcl_totuni_hcor.Text = "1";
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
                #region Valores Variables
                //tmpRegDetalle.Hcl_nroreg_hcor 
                tmpRegDetalle.Hcl_nroreg_hcms = tmpRegMaestro.Hcl_nroreg_hcms;
                //tmpRegDetalle.Hcl_secreg_hcor
                tmpRegDetalle.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                tmpRegDetalle.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegDetalle.Hcl_tipreg_hcor = "1";
                //tmpRegDetalle.Fcm_secreg_dfac
                //tmpRegDetalle.Fcm_idesec_sips se llena en validacion
                tmpRegDetalle.Fcm_coddig_mant = txtG1Fcm_coddig_mant.Text;
                tmpRegDetalle.Hcl_totuni_hcor = (int)Convert.ToUInt32(txtG1Hcl_totuni_hcor.Text);
                //tmpRegDetalle.Inv_secart_mart  se llena en validacion del campo Fcm_coddig_mant
                //tmpRegDetalle.Hcl_aplmed_hcor 
                //tmpRegDetalle.Hcl_termed_hcor 
                //tmpRegDetalle.Hcl_nrodia_hcor 
                tmpRegDetalle.Hcl_gesfec_hcor = Funciones.fdaConvertFecha("DMY", "/", txtG1Hcl_gesfec_hcor.Text);
                tmpRegDetalle.Hcl_geshor_hcor = Decimal.Parse(Funciones.fcrConvierteHora(txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegDetalle.Hcl_sisfec_hcor = DateTime.Now;
                tmpRegDetalle.Hcl_sishor_hcor = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                tmpRegDetalle.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegDetalle.Hcl_notreg_hcor = txtG1Hcl_notreg_hcor.Text;
                tmpRegDetalle.Hcl_tipser_hcor = txtG1Hcl_tipser_hcor.Text;
                tmpRegDetalle.Hcl_envfac_hcor = txtG1Hcl_tipser_hcor.Text == "1" ? "1" : "2";
                tmpRegDetalle.Hcl_envalm_hcor = "2";
                tmpRegDetalle.Hcl_confac_hcor = tmpRegDetalle.Hcl_envfac_hcor == "1" ? "1" : "2";
                tmpRegDetalle.Hcl_conalm_hcor = "2";
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
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Fcm_coddig_mant"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_totuni_hcor"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_gesfec_hcor"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_geshor_hcor"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_tipser_hcor"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_notreg_hcor"))) { lnuCont++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codpfa_prof"))) { lnuCont++; }
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
                    case "txtG1Fcm_coddig_mant":
                        if (String.IsNullOrWhiteSpace(txtG1Fcm_coddig_mant.Text))
                        {
                            lcrValorReturn = "Código servicio: Es requerido";
                        }
                        else
                        {
                            EFfcmmanservicips tmp = new EFfcmmanservicips();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(txtG1Fcm_coddig_mant.Text);
                            if (tmp != null && tmp.fcm_idesec_sips != null)
                            {
                                txtG1Fcm_idesec_sips.Text = tmp.fcm_idesec_sips;
                                txtG1Fcm_desser_sips.Text = tmp.fcm_desser_sips;
                                //- Actualizar temporal
                                tmpRegDetalle.Fcm_idesec_sips = tmp.fcm_idesec_sips;
                                tmpRegDetalle.Inv_secart_mart = tmp.inv_secart_mart;
                            }
                            else
                            {
                                lcrValorReturn = "Código servicio: No existe";
                                txtG1Fcm_desser_sips.Text = lcrValorReturn;
                            }
                        }
                        fcvSetColorValidacion(txtG1Fcm_coddig_mant, lcrValorReturn);
                        break;

                    case "txtG1Hcl_totuni_hcor":
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_totuni_hcor.Text))
                        {
                            lcrValorReturn = "Total unidades: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (Convert.ToUInt32(txtG1Hcl_totuni_hcor.Text) < 1 || Convert.ToUInt32(txtG1Hcl_totuni_hcor.Text) > 150)
                            {
                                lcrValorReturn = "Total unidades: Valor fuera del rango";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_totuni_hcor, lcrValorReturn);
                        break;

                    case "txtG1Hcl_gesfec_hcor":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", txtG1Hcl_gesfec_hcor.Text, "Fecha servicio");
                        fcvSetColorValidacion(txtG1Hcl_gesfec_hcor, lcrValorReturn);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            txtG1Hcl_gesfec_hcor.BorderBrush = Brushes.White;
                        }
                        break;

                    case "txtG1Hcl_geshor_hcor":
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, txtG1Hcl_geshor_hcor.Text, "12", ":", "Hora servicio");
                        fcvSetColorValidacion(txtG1Hcl_geshor_hcor, lcrValorReturn);
                        break;

                    case "txtG1Hcl_tipser_hcor":
                        if (string.IsNullOrWhiteSpace(txtG1Hcl_tipser_hcor.Text))
                        {
                            lcrValorReturn = "Tipo orden servicio: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(txtG1Hcl_tipser_hcor.Text, ",", "1,2"))
                            {
                                lcrValorReturn = "Tipo orden servicio: Dato no es valido";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_tipser_hcor, lcrValorReturn);
                        break;

                    case "txtG1Hcl_notreg_hcor":
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_notreg_hcor.Text))
                        {
                            lcrValorReturn = "Observación: Es requerida";
                        }
                        fcvSetColorValidacion(txtG1Hcl_notreg_hcor, lcrValorReturn);
                        break;

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
                // 
                //-------------------------------------------------
                #region HOS_TIPHAB_HABI: Unipersonal SI/NO
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Servicio,Inidicacion médica";
                lstG1Hcl_tipser_hcor = new List<CrtForms.ListaComboBox>();
                lstG1Hcl_tipser_hcor = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                //- Asignar al control
                cboG1Hcl_tipser_hcor.ItemsSource = lstG1Hcl_tipser_hcor;
                cboG1Hcl_tipser_hcor.SelectedIndex = Convert.ToInt32(lstG1Hcl_tipser_hcor[0].IdIndice);
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
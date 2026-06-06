using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Validacion;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_ControlVistaFramingHam.xaml
    /// </summary>
    public partial class ControlVistaFramingHam : UserControl
    {
        public List<CrtForms.ListaComboBox> lsSiNoGeneral;
        public List<CrtForms.ListaComboBox> lsTabaquismo;
        public List<CrtForms.ListaComboBox> lsDiabetes;
        public ControlVistaImc gobRefIMC = null;
        public bool llgObjetosCargados = false;
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = true;
        public String gcrValorGenerado = String.Empty;

        public String lcrModoVistaObjeto = "D"; // D=Modo diseño /E=Edicion o Modo captura/V = Modo vista solo lectura
        
        public ControlVistaFramingHam()
        {
            InitializeComponent();

        }
        #region fcvCargarVista: Generar la vista segun parametro
        /// <summary>
        /// <para>Generar la vista segun parametro</para>
        /// </summary>
        public void fcvCargarVista(String tcrValor)
        {
            fcvCargarValoresDesdeString(tcrValor);
            // cargar modo vista 
            fcrModoVistaObjetos();

            llgModoEdicionValid = false;
            llgObjetosCargados = true;
            // Cargar demas parametros
        }
        #endregion
        //-------------------------------------------------
        // Modo Vista objetos 
        //-------------------------------------------------
        #region fcrModoVistaObjetos: Cargar el modo vista objetos
        /// <summary>
        /// <para>Cargar el modo vista objetos</para>
        /// </summary>
        public void fcrModoVistaObjetos()
        {

            if (lcrModoVistaObjeto == "E" || lcrModoVistaObjeto == "G")
            {
                IniciarComboBox();
            }
            else
            {
                this.txtColesterolChdl.IsReadOnly = true;
                this.txtColesterolTotal.IsReadOnly = true;
                this.txtPresionArtSistolica.IsReadOnly = true;
                this.txtTabaco.IsReadOnly = true;
                this.txtDiabetes.IsReadOnly = true;
                this.txtFrmMedidCintura.IsReadOnly = true;

                this.cboFrgFamiMuerCorazon.Visibility   = Visibility.Collapsed;
                this.cboFamiliDiabetes.Visibility       = Visibility.Collapsed;
                this.cboFrmInfarto.Visibility           = Visibility.Collapsed;
                this.cboFrmTaAlta.Visibility            = Visibility.Collapsed;
                this.cboFrmTaMedicamento.Visibility     = Visibility.Collapsed;
                this.cboFrmAzucarSangre.Visibility      = Visibility.Collapsed;
                this.cboFrmActividadFisica.Visibility   = Visibility.Collapsed;

                this.cboTabaco.Visibility   = Visibility.Collapsed;
                this.cboDiabetes.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public void IniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                // Lista General para SI/NO
                //-------------------------------------------------
                String lcrG15Seleccion = "NO,SI";
                String lcrG15Descripcion = "Niega,Afirma";
                lsSiNoGeneral = new List<CrtForms.ListaComboBox>();
                lsSiNoGeneral = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);

                //-------------------------------------------------
                //  Familiares muertos del corazon Si/No
                //-------------------------------------------------
                #region Familiares muertos del corazon Si/No
                //- Asignar al control
                this.cboFrgFamiMuerCorazon.ItemsSource = lsSiNoGeneral;
                this.cboFrgFamiMuerCorazon.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  Familiares con Diabetes Si/No
                //-------------------------------------------------
                #region Familiares con Diabetes Si/No
                //- Asignar al control
                this.cboFamiliDiabetes.ItemsSource = lsSiNoGeneral;
                this.cboFamiliDiabetes.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  Infarto o derrame cerebral Si/No
                //-------------------------------------------------
                #region Infarto o derrame cerebral Si/No
                //- Asignar al control
                this.cboFrmInfarto.ItemsSource = lsSiNoGeneral;
                this.cboFrmInfarto.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  Tensión Arterial Alta (TA) Si/No
                //-------------------------------------------------
                #region Tensión Arterial Alta (TA) Si/No
                //- Asignar al control
                this.cboFrmTaAlta.ItemsSource = lsSiNoGeneral;
                this.cboFrmTaAlta.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  Medicamentos para tenion arterial Si/No
                //-------------------------------------------------
                #region Medicamentos para tenion arterial Si/No
                //- Asignar al control
                this.cboFrmTaMedicamento.ItemsSource = lsSiNoGeneral;
                this.cboFrmTaMedicamento.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  Azucar en la sangre Si/No
                //-------------------------------------------------
                #region Azucar en la sangre Si/No
                //- Asignar al control
                this.cboFrmAzucarSangre.ItemsSource = lsSiNoGeneral;
                this.cboFrmAzucarSangre.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                // Actividad fisica Si/No
                //-------------------------------------------------
                #region Actividad fisica Si/No
                //- Asignar al control
                this.cboFrmActividadFisica.ItemsSource = lsSiNoGeneral;
                this.cboFrmActividadFisica.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  Tabaquismo:  Fumador Si/No
                //-------------------------------------------------
                #region Fumador Si/No
                string lcrG11Seleccion = "NO,SI";
                string lcrG11Descripcion = "Niega,Afirma";
                lsTabaquismo = new List<CrtForms.ListaComboBox>();
                lsTabaquismo = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                //- Asignar al control
                this.cboTabaco.ItemsSource = lsTabaquismo;
                this.cboTabaco.SelectedIndex = Convert.ToInt32(lsTabaquismo[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  Diabetes:  Diabetie Si/No
                //-------------------------------------------------
                #region Diabetes Si/No
                string lcrG12Seleccion = "NO,SI";
                string lcrG12Descripcion = "Niega,Afirma";
                lsDiabetes = new List<CrtForms.ListaComboBox>();
                lsDiabetes = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                //- Asignar al control
                this.cboDiabetes.ItemsSource = lsDiabetes;
                this.cboDiabetes.SelectedIndex = Convert.ToInt32(lsDiabetes[0].IdIndice);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        // Actualizar ComboBox desde Campo Texto
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
                        case "txtFrgFamiMuerCorazon":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)this.cboFrgFamiMuerCorazon.SelectedItem;
                            this.cboFrgFamiMuerCorazon.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            break;

                        case "txtFrmFamiliDiabetes":
                            CrtForms.ListaComboBox lobG1ComboBox2x = (CrtForms.ListaComboBox)this.cboFamiliDiabetes.SelectedItem;
                            this.cboFamiliDiabetes.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2x.ListaValoresSel);
                            break;

                        case "txtFrmInfarto":
                            CrtForms.ListaComboBox lobG1ComboBox2 = (CrtForms.ListaComboBox)this.cboFrmInfarto.SelectedItem;
                            this.cboFrmInfarto.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox2.ListaValoresSel);
                            break;

                        case "txtFrmTaAlta":
                            CrtForms.ListaComboBox lobG1ComboBox3 = (CrtForms.ListaComboBox)this.cboFrmTaAlta.SelectedItem;
                            this.cboFrmTaAlta.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox3.ListaValoresSel);
                            break;

                        case "txtFrmTaMedicamento":
                            CrtForms.ListaComboBox lobG1ComboBox4 = (CrtForms.ListaComboBox)this.cboFrmTaMedicamento.SelectedItem;
                            this.cboFrmTaMedicamento.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox4.ListaValoresSel);
                            break;

                        case "txtFrmAzucarSangre":
                            CrtForms.ListaComboBox lobG1ComboBox5 = (CrtForms.ListaComboBox)this.cboFrmAzucarSangre.SelectedItem;
                            this.cboFrmAzucarSangre.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox5.ListaValoresSel);
                            break;

                        case "txtFrmActividadFisica":
                            CrtForms.ListaComboBox lobG1ComboBox6 = (CrtForms.ListaComboBox)this.cboFrmActividadFisica.SelectedItem;
                            this.cboFrmActividadFisica.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox6.ListaValoresSel);
                            break;

                        case "txtTabaco":
                            CrtForms.ListaComboBox lobG1ComboBox11 = (CrtForms.ListaComboBox)this.cboTabaco.SelectedItem;
                            this.cboTabaco.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox11.ListaValoresSel);
                            break;

                        case "txtDiabetes":
                            CrtForms.ListaComboBox lobG1ComboBox12 = (CrtForms.ListaComboBox)this.cboDiabetes.SelectedItem;
                            this.cboDiabetes.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox12.ListaValoresSel);
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
        // Actualizar Objeto TextBox desde CombBox
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
                        case "cboFrgFamiMuerCorazon":
                            this.txtFrgFamiMuerCorazon.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, this.txtFrgFamiMuerCorazon.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtFrgFamiMuerCorazon.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboFamiliDiabetes":
                            this.txtFrmFamiliDiabetes.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, this.txtFrmFamiliDiabetes.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtFrmFamiliDiabetes.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboFrmInfarto":
                            this.txtFrmInfarto.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, this.txtFrmInfarto.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtFrmInfarto.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboFrmTaAlta":
                            this.txtFrmTaAlta.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, this.txtFrmTaAlta.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtFrmTaAlta.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboFrmTaMedicamento":
                            this.txtFrmTaMedicamento.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, this.txtFrmTaMedicamento.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtFrmTaMedicamento.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboFrmAzucarSangre":
                            this.txtFrmAzucarSangre.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, this.txtFrmAzucarSangre.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtFrmAzucarSangre.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboFrmActividadFisica":
                            this.txtFrmActividadFisica.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, this.txtFrmActividadFisica.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtFrmActividadFisica.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboTabaco":
                            this.txtTabaco.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, this.txtTabaco.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtTabaco.Text, ",", lobList.ListaValoresSel);
                            break;

                        case "cboDiabetes":
                            this.txtDiabetes.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, this.txtDiabetes.Text, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(this.txtDiabetes.Text, ",", lobList.ListaValoresSel);
                            break;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: SeleccionComboBoxOpcion");
            }
        }
        #endregion
        //-------------------------------------------------
        // Validacion campos
        //-------------------------------------------------
        #region fcvValidacionTexto: Validacion campos
        /// <summary>
        /// <para>Validacion campos</para>
        /// </summary>
        private void fcvValidacionTexto(object sender, TextChangedEventArgs e)
        {
            if (!llgObjetosCargados) { return; }

            llgModoEdicionKey = true;
            var lobTextBox = sender as TextBox;
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
            var lnuCont1 = 0;

            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFrgFamiMuerCorazon"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFrmFamiliDiabetes"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFrmInfarto"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFrmTaAlta"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFrmTaMedicamento"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFrmAzucarSangre"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFrmIMCImc"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFrmMedidCintura"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtFrmActividadFisica"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtColesterolChdl"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtColesterolTotal"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtPresionArtSistolica"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtTabaco"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtDiabetes"))) { lnuCont1++; }

            return lnuCont1 < 1 ? true : false;
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
            String lcrValorReturn = string.Empty;
            String lcrNombreCampo = String.Empty;

            try
            {
                switch (tcrNombrePropiedad)
                {
                    #region Validacion Framingham
                    case "txtFrgSia_edaymd_usua":
                        #region Validacion
                        lcrNombreCampo = "Edad del paciente en años";
                        lcrValorReturn = String.Empty;
                        this.txtSexo_Puntaje.Text = "0";

                        if (String.IsNullOrWhiteSpace(this.txtFrgSia_edaymd_usua.Text))
                        {
                            lcrValorReturn = "Debe diligenciar valor númerico";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumeros(this.txtFrgSia_edaymd_usua.Text))
                            {
                                var lnuValor = Convert.ToUInt32(this.txtFrgSia_edaymd_usua.Text);
                                if (lnuValor <= 0 || lnuValor > 130)
                                {
                                    lcrValorReturn = "Valor fuera del rango";
                                }
                                else
                                {
                                    fcvPuntajeSexoEdad();
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Valor debe ser númerico";
                            }
                        }
                        this.txtSexo_Puntaje_Titulo.Text = lcrValorReturn;
                        fcvSetColorValidacion(this.txtFrgSia_edaymd_usua, lcrValorReturn);
                        break;
                        #endregion

                    case "txtColesterolChdl":
                        #region Validacion
                        lcrNombreCampo = "Colesterol HDL";
                        lcrValorReturn = String.Empty;
                        this.txtColesterolChdl_Puntaje.Text = "0";

                        if (String.IsNullOrWhiteSpace(this.txtColesterolChdl.Text))
                        {
                            lcrValorReturn = "Debe diligenciar valor númerico";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumeros(this.txtColesterolChdl.Text))
                            {
                                var lnuValor = Convert.ToUInt32(this.txtColesterolChdl.Text);
                                if (lnuValor < 0 || lnuValor > 300)
                                {
                                    lcrValorReturn = "Valor fuera del rango";
                                }
                                else
                                {
                                    fcvPuntajeColesterolHDL();
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Valor debe ser númerico";
                            }
                        }
                        this.txtColesterolChdl_Puntaje_Titulo.Text = lcrValorReturn;
                        fcvSetColorValidacion(this.txtColesterolChdl, lcrValorReturn);
                        break;
                        #endregion

                    case "txtColesterolTotal":
                        #region Validacion
                        lcrNombreCampo = "Colesterol Total";
                        lcrValorReturn = String.Empty;
                        this.txtColesterolTotal_Puntaje.Text = "0";

                        if (String.IsNullOrWhiteSpace(this.txtColesterolTotal.Text))
                        {
                            lcrValorReturn = "Debe diligenciar valor númerico";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumeros(this.txtColesterolTotal.Text))
                            {
                                var lnuValor = Convert.ToUInt32(this.txtColesterolTotal.Text);
                                if (lnuValor < 0 || lnuValor > 999)
                                {
                                    lcrValorReturn = "Valor fuera del rango";
                                }
                                else
                                {
                                    fcvPuntajeColesterolTotal();
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Valor debe ser númerico";
                            }
                        }
                        this.txtColesterolTotal_Puntaje_Titulo.Text = lcrValorReturn;
                        fcvSetColorValidacion(this.txtColesterolTotal, lcrValorReturn);
                        break;
                        #endregion

                    case "txtPresionArtSistolica":
                        #region Validacion
                        lcrNombreCampo = "Presión Arterial Sistólica";
                        lcrValorReturn = String.Empty;
                        this.txtPresionArtSistolica_Puntaje.Text = "0";

                        if (String.IsNullOrWhiteSpace(this.txtPresionArtSistolica.Text))
                        {
                            lcrValorReturn = "Debe diligenciar valor númerico";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumeros(this.txtPresionArtSistolica.Text))
                            {
                                var lnuValor = Convert.ToUInt32(this.txtPresionArtSistolica.Text);
                                if (lnuValor < 50 || lnuValor > 200)
                                {
                                    lcrValorReturn = "Valor fuera del rango";
                                }
                                else
                                {
                                    fcvPuntajePresionsistolica();
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Valor debe ser númerico";
                            }
                        }
                        this.txtPresionArtSistolica_Puntaje_Titulo.Text = lcrValorReturn;
                        fcvSetColorValidacion(this.txtPresionArtSistolica, lcrValorReturn);
                        break;
                        #endregion

                    case "txtTabaco":
                        #region Validacion
                        lcrNombreCampo = "Paciente fumador (SI/NO)";
                        lcrValorReturn = String.Empty;
                        //this.txtTabaco_Puntaje.Text = "0";

                        if (String.IsNullOrWhiteSpace(this.txtTabaco.Text))
                        {
                            lcrValorReturn = lcrNombreCampo+ ": Valor SI/NO es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtTabaco.Text, ",", "SI,NO"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            { 
                                // validacion para buscar puntaje
                                fcvPuntajeTabaco();
                            }
                        }
                        fcvSetColorValidacion(this.txtTabaco, lcrValorReturn);
                        break;
                        #endregion

                    case "txtDiabetes":
                        #region Validacion
                        lcrNombreCampo = "Paciente Diabetico (SI/NO)";
                        lcrValorReturn = String.Empty;
                        //this.txtDiabetes_Puntaje.Text = "0";

                        if (String.IsNullOrWhiteSpace(this.txtDiabetes.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor SI/NO es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtDiabetes.Text, ",", "SI,NO"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                // validacion para buscar puntaje
                                fcvPuntajeDiabetes();
                            }
                        }
                        fcvSetColorValidacion(this.txtDiabetes, lcrValorReturn);
                        break;
                        #endregion
                    #endregion
                    #region Validacion Tamizaje
                    case "txtFrgFamiMuerCorazon":
                        #region Validacion
                        lcrNombreCampo = "Algún familiar ha muerto del corazón (SI/NO)";
                        lcrValorReturn = String.Empty;

                        if (String.IsNullOrWhiteSpace(this.txtFrgFamiMuerCorazon.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor SI/NO es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtFrgFamiMuerCorazon.Text, ",", "SI,NO"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                // validacion para buscar puntaje
                                fcvPuntajeFamiliMuertCorazon();
                            }
                        }
                        fcvSetColorValidacion(this.txtFrgFamiMuerCorazon, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFrmFamiliDiabetes":
                        #region Validacion
                        lcrNombreCampo = "Algún familiar con diabetes (SI/NO)";
                        lcrValorReturn = String.Empty;

                        if (String.IsNullOrWhiteSpace(this.txtFrmFamiliDiabetes.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor SI/NO es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtFrmFamiliDiabetes.Text, ",", "SI,NO"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                // validacion para buscar puntaje
                                fcvPuntajeFamiliConDiabetes();
                            }
                        }
                        fcvSetColorValidacion(this.txtFrmFamiliDiabetes, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFrmInfarto":
                        #region Validacion
                        lcrNombreCampo = "Ha sufrido infrato (SI/NO)";
                        lcrValorReturn = String.Empty;

                        if (String.IsNullOrWhiteSpace(this.txtFrmInfarto.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor SI/NO es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtFrmInfarto.Text, ",", "SI,NO"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                // validacion para buscar puntaje
                                fcvPuntajeInfarto();
                            }
                        }
                        fcvSetColorValidacion(this.txtFrmInfarto, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFrmTaAlta":
                        #region Validacion
                        lcrNombreCampo = "Tension arterial (TA) alta (SI/NO)";
                        lcrValorReturn = String.Empty;

                        if (String.IsNullOrWhiteSpace(this.txtFrmTaAlta.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor SI/NO es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtFrmTaAlta.Text, ",", "SI,NO"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                // validacion para buscar puntaje
                                fcvPuntajeTensionArterialAlta();
                            }
                        }
                        fcvSetColorValidacion(this.txtFrmTaAlta, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFrmTaMedicamento":
                        #region Validacion
                        lcrNombreCampo = "Medicamentos para Tension arterial (TA) alta (SI/NO)";
                        lcrValorReturn = String.Empty;

                        if (String.IsNullOrWhiteSpace(this.txtFrmTaMedicamento.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor SI/NO es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtFrmTaMedicamento.Text, ",", "SI,NO"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                // validacion para buscar puntaje
                                fcvPuntajeMedicamentosTensionArterialAlta();
                            }
                        }
                        fcvSetColorValidacion(this.txtFrmTaMedicamento, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFrmAzucarSangre":
                        #region Validacion
                        lcrNombreCampo = "Azucar en la sangre (SI/NO)";
                        lcrValorReturn = String.Empty;

                        if (String.IsNullOrWhiteSpace(this.txtFrmAzucarSangre.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor SI/NO es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtFrmAzucarSangre.Text, ",", "SI,NO"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                // validacion para buscar puntaje
                                fcvPuntajeAzucarEnSangre();
                            }
                        }
                        fcvSetColorValidacion(this.txtFrmAzucarSangre, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFrmIMCImc":
                        #region Validacion
                        lcrNombreCampo = "Indice de Masa corporal (IMC)";
                        lcrValorReturn = String.Empty;
                        this.txtFrmImc_Puntaje.Text = "0";

                        if (String.IsNullOrWhiteSpace(this.txtFrmIMCImc.Text))
                        {
                            lcrValorReturn = "Debe diligenciar valor númerico";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumerosEx(this.txtFrmIMCImc.Text))
                            {
                                var lnuValor = Convert.ToDouble(this.txtFrmIMCImc.Text);

                                if (lnuValor < 0 || lnuValor > 300)
                                {
                                    lcrValorReturn = "Valor fuera del rango";
                                }
                                else
                                {
                                    // Traer Puntaje
                                    fcvPuntajeIndiceMasaCorporalIMC();
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Valor debe ser númerico";
                            }
                        }
                        this.txtFrmImc_Puntaje_Titulo.Text = lcrValorReturn;
                        fcvSetColorValidacion(this.txtFrmIMCImc, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFrmMedidCintura":
                        #region Validacion
                        lcrNombreCampo = "Medida de la cintura";
                        lcrValorReturn = String.Empty;
                        this.txtFrmMedidCintura_Puntaje.Text = "0";

                        if (String.IsNullOrWhiteSpace(this.txtFrmMedidCintura.Text))
                        {
                            lcrValorReturn = "Debe diligenciar valor númerico";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumerosEx(this.txtFrmMedidCintura.Text))
                            {
                                var lnuValor = Convert.ToDouble(this.txtFrmMedidCintura.Text);

                                if (lnuValor < 0 || lnuValor > 300)
                                {
                                    lcrValorReturn = "Valor fuera del rango";
                                }
                                else
                                {
                                    // Traer Puntaje
                                    fcvPuntajeMedidaCintura();
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Valor debe ser númerico";
                            }
                        }
                        this.txtFrmMedidCintura_Puntaje_Titulo.Text = lcrValorReturn;
                        fcvSetColorValidacion(this.txtFrmMedidCintura, lcrValorReturn);
                        break;
                        #endregion

                    case "txtFrmActividadFisica":
                        #region Validacion
                        lcrNombreCampo = "Realiza actividad fisica (SI/NO)";
                        lcrValorReturn = String.Empty;

                        if (String.IsNullOrWhiteSpace(this.txtFrmActividadFisica.Text))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor SI/NO es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(this.txtFrmActividadFisica.Text, ",", "SI,NO"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                // validacion para buscar puntaje
                                fcvPuntajeActividadFisica();
                            }
                        }
                        fcvSetColorValidacion(this.txtFrmActividadFisica, lcrValorReturn);
                        break;
                        #endregion

                    #endregion

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
        // Calcular puntajes
        //-------------------------------------------------
        // Test Framingham
        #region fcvPuntajeSexoEdad: Puntaje Valor sexo y edad
        /// <summary>
        /// Obtener puntaje segun valor sexo y edad
        /// </summary>
        public void fcvPuntajeSexoEdad()
        {
            var lnuEdad = Convert.ToInt32(this.txtFrgSia_edaymd_usua.Text);

            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamedadRango(this.txtFrgSis_codsex_sexo.Text, lnuEdad);
            if (tmp != null)
            {
                this.txtSexo_Puntaje.Text = tmp.hcl_puntos_hcfe.ToString();
                this.txtSexo_Puntaje_Titulo.Text = tmp.hcl_observ_hcfe.Trim() != "NA" ? tmp.hcl_observ_hcfe : String.Empty;
            }
            else
            {
                this.txtSexo_Puntaje.Text = "0";
            }
        }
        #endregion
        #region fcvPuntajeColesterolHDL: Puntaje Valor colesterol HDL
        /// <summary>
        /// Obtener puntaje segun valor Valor colesterol HDL
        /// </summary>
        public void fcvPuntajeColesterolHDL()
        {
            this.txtColesterolChdl_Puntaje.Text = "0";
            var lnuValor = Convert.ToInt32(this.txtColesterolChdl.Text);

            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamctrlRango("A","1", lnuValor);
            if (tmp != null)
            {
                this.txtColesterolChdl_Puntaje.Text = tmp.hcl_puntos_hcfc.ToString();
                this.txtColesterolChdl_Puntaje_Titulo.Text = tmp.hcl_observ_hcfc.Trim() != "NA" ? tmp.hcl_observ_hcfc : String.Empty;
            }
        }
        #endregion
        #region fcvPuntajeColesterolTotal: Puntaje Valor colesterol total
        /// <summary>
        /// Obtener puntaje segun valor Valor colesterol total
        /// </summary>
        public void fcvPuntajeColesterolTotal()
        {
            this.txtColesterolTotal_Puntaje.Text = "0";
            var lnuValor = Convert.ToInt32(this.txtColesterolTotal.Text);

            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamctrlRango("A", "2", lnuValor);
            if (tmp != null)
            {
                this.txtColesterolTotal_Puntaje.Text = tmp.hcl_puntos_hcfc.ToString();
                this.txtColesterolTotal_Puntaje_Titulo.Text = tmp.hcl_observ_hcfc.Trim() != "NA" ? tmp.hcl_observ_hcfc : String.Empty;
            }
        }
        #endregion
        #region fcvPuntajePresionsistolica: Puntaje Valor presion sistolica
        /// <summary>
        /// Obtener puntaje segun valor presion sistolica
        /// </summary>
        public void fcvPuntajePresionsistolica()
        {
            this.txtPresionArtSistolica_Puntaje.Text = "0";

            var lnuEdad = Convert.ToInt32(this.txtFrgSia_edaymd_usua.Text);
            var lnuValor = Convert.ToInt32(this.txtPresionArtSistolica.Text);

            var tmp = HCLValidarCodigo.fobRegBuscarHclframghampartRango(this.txtFrgSis_codsex_sexo.Text, lnuEdad, lnuValor);
            if (tmp != null)
            {
                this.txtPresionArtSistolica_Puntaje.Text = tmp.hcl_puntos_hcfp.ToString();
                this.txtPresionArtSistolica_Puntaje_Titulo.Text = tmp.hcl_observ_hcfp.Trim() != "NA" ? tmp.hcl_observ_hcfp : String.Empty;
            }
        }
        #endregion
        #region fcvPuntajeDiabetes: Puntaje segun respuesta diabetes SI/NO
        /// <summary>
        /// Obtener puntaje segun respuesta diabetes SI/NO
        /// </summary>
        public void fcvPuntajeDiabetes()
        {

            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamotrsRango(this.txtFrgSis_codsex_sexo.Text, "1", this.txtDiabetes.Text);
            if (tmp != null)
            {
                this.txtDiabetes_Puntaje.Text = tmp.hcl_puntos_hcft.ToString();
                this.txtDiabetes_Puntaje_Titulo.Text = tmp.hcl_observ_hcft.Trim() != "NA" ? tmp.hcl_observ_hcft : String.Empty;
            }
            else
            {
                this.txtDiabetes_Puntaje.Text = "0";
            }
        }
        #endregion
        // Tamizaje 
        #region fcvPuntajeFamiliMuertCorazon: Puntaje Familia muere del corazón
        /// <summary>
        /// Obtener puntaje segun Familia muere del corazón
        /// </summary>
        public void fcvPuntajeFamiliMuertCorazon()
        {
            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamotrsRango(this.txtFrgSis_codsex_sexo.Text, "3", this.txtFrgFamiMuerCorazon.Text);
            if (tmp != null)
            {
                this.txtFrmFamiMuerCorazon_Puntaje.Text = tmp.hcl_puntos_hcft.ToString();
                this.txtFrmFamiMuerCorazon_Puntaje_Titulo.Text = tmp.hcl_observ_hcft.Trim() != "NA" ? tmp.hcl_observ_hcft : String.Empty;
            }
            else
            {
                this.txtFrmFamiMuerCorazon_Puntaje.Text = "0";
            }
        }
        #endregion
        #region fcvPuntajeFamiliConDiabetes: Puntaje Familia con diabetes
        /// <summary>
        /// Obtener puntaje segun Familia con diabetes
        /// </summary>
        public void fcvPuntajeFamiliConDiabetes()
        {
            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamotrsRango(this.txtFrgSis_codsex_sexo.Text, "9", this.txtFrmFamiliDiabetes.Text);
            if (tmp != null)
            {
                this.txtFamiliDiabetes_Puntaje.Text = tmp.hcl_puntos_hcft.ToString();
                this.txtFamiliDiabetes_Puntaje_Titulo.Text = tmp.hcl_observ_hcft.Trim() != "NA" ? tmp.hcl_observ_hcft : String.Empty;
            }
            else
            {
                this.txtFamiliDiabetes_Puntaje.Text = "0";
            }
        }
        #endregion
        #region fcvPuntajeInfarto: Puntaje Ha sufrido un infarto
        /// <summary>
        /// Obtener puntaje segun "Ha sufrido un infarto"
        /// </summary>
        public void fcvPuntajeInfarto()
        {
            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamotrsRango(this.txtFrgSis_codsex_sexo.Text, "4", this.txtFrmInfarto.Text);
            if (tmp != null)
            {
                this.txtFrmInfarto_Puntaje.Text = tmp.hcl_puntos_hcft.ToString();
                this.txtFrmInfarto_Puntaje_Titulo.Text = tmp.hcl_observ_hcft.Trim() != "NA" ? tmp.hcl_observ_hcft : String.Empty;
            }
            else
            {
                this.txtFrmInfarto_Puntaje.Text = "0";
            }
        }
        #endregion
        #region fcvPuntajeTensionArterialAlta: Puntaje Tensión arterial alta
        /// <summary>
        /// Obtener puntaje segun Tensión arterial alta
        /// </summary>
        public void fcvPuntajeTensionArterialAlta()
        {
            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamotrsRango(this.txtFrgSis_codsex_sexo.Text, "5", this.txtFrmTaAlta.Text);
            if (tmp != null)
            {
                this.txtFrmTaAlta_Puntaje.Text = tmp.hcl_puntos_hcft.ToString();
                this.txtFrmTaAlta_Puntaje_Titulo.Text = tmp.hcl_observ_hcft.Trim() != "NA" ? tmp.hcl_observ_hcft : String.Empty;
            }
            else
            {
                this.txtFrmTaAlta_Puntaje.Text = "0";
            }
        }
        #endregion
        #region fcvPuntajeMedicamentosTensionArterialAlta: Puntaje Medicamentos Tensión arterial alta
        /// <summary>
        /// Obtener puntaje segun Medicamentos Tensión arterial alta
        /// </summary>
        public void fcvPuntajeMedicamentosTensionArterialAlta()
        {
            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamotrsRango(this.txtFrgSis_codsex_sexo.Text, "6", this.txtFrmTaMedicamento.Text);
            if (tmp != null)
            {
                this.txtFrmTaMedicamento_Puntaje.Text = tmp.hcl_puntos_hcft.ToString();
                this.txtFrmTaMedicamento_Puntaje_Titulo.Text = tmp.hcl_observ_hcft.Trim() != "NA" ? tmp.hcl_observ_hcft : String.Empty;
            }
            else
            {
                this.txtFrmTaMedicamento_Puntaje.Text = "0";
            }
        }
        #endregion
        #region fcvPuntajeAzucarEnSangre: Puntaje Azucar en la sangre
        /// <summary>
        /// Obtener puntaje segun Azucar en la sangre
        /// </summary>
        public void fcvPuntajeAzucarEnSangre()
        {
            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamotrsRango(this.txtFrgSis_codsex_sexo.Text, "7", this.txtFrmAzucarSangre.Text);
            if (tmp != null)
            {
                this.txtFrmAzucarSangre_Puntaje.Text = tmp.hcl_puntos_hcft.ToString();
                this.txtFrmAzucarSangre_Puntaje_Titulo.Text = tmp.hcl_observ_hcft.Trim() != "NA" ? tmp.hcl_observ_hcft : String.Empty;
            }
            else
            {
                this.txtFrmAzucarSangre_Puntaje.Text = "0";
            }
        }
        #endregion
        #region fcvPuntajeIndiceMasaCorporalIMC: Puntaje Indice de masa corporal
        /// <summary>
        /// Obtener puntaje segun Indice de masa corporal IMC
        /// </summary>
        public void fcvPuntajeIndiceMasaCorporalIMC()
        {
            this.txtFrmImc_Puntaje.Text = "0";
            var lnuValor = Convert.ToDouble(this.txtFrmIMCImc.Text); 

            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamctrlRango("A", "3", lnuValor);
            if (tmp != null)
            {
                this.txtFrmImc_Puntaje.Text = tmp.hcl_puntos_hcfc.ToString();
                this.txtFrmImc_Puntaje_Titulo.Text = tmp.hcl_observ_hcfc.Trim() != "NA" ? tmp.hcl_observ_hcfc : String.Empty;
            }
        }
        #endregion
        #region fcvPuntajeMedidaCintura: Puntaje Medida de la cintura
        /// <summary>
        /// Obtener puntaje segun Medida de la cintura
        /// </summary>
        public void fcvPuntajeMedidaCintura()
        {
            this.txtFrmMedidCintura_Puntaje.Text = "0";
            var lnuValor = Convert.ToDouble(this.txtFrmMedidCintura.Text);

            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamctrlRango(this.txtFrgSis_codsex_sexo.Text, "4", lnuValor);
            if (tmp != null)
            {
                this.txtFrmMedidCintura_Puntaje.Text = tmp.hcl_puntos_hcfc.ToString();
                this.txtFrmMedidCintura_Puntaje_Titulo.Text = tmp.hcl_observ_hcfc.Trim() != "NA" ? tmp.hcl_observ_hcfc : String.Empty;
            }
        }
        #endregion
        #region fcvPuntajeActividadFisica: Puntaje Actividad fisica
        /// <summary>
        /// Obtener puntaje segun Actividad fisica
        /// </summary>
        public void fcvPuntajeActividadFisica()
        {
            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamotrsRango(this.txtFrgSis_codsex_sexo.Text, "8", this.txtFrmActividadFisica.Text);
            if (tmp != null)
            {
                this.txtFrmActividadFisica_Puntaje.Text = tmp.hcl_puntos_hcft.ToString();
                this.txtFrmActividadFisica_Puntaje_Titulo.Text = tmp.hcl_observ_hcft.Trim() != "NA" ? tmp.hcl_observ_hcft : String.Empty;
            }
            else
            {
                this.txtFrmActividadFisica_Puntaje.Text = "0";
            }
        }
        #endregion
        #region fcvPuntajeTabaco: Puntaje Valor Tabaco
        /// <summary>
        /// Obtener puntaje segun Respuesta Tabaco
        /// </summary>
        public void fcvPuntajeTabaco()
        {
            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamotrsRango(this.txtFrgSis_codsex_sexo.Text, "2", this.txtTabaco.Text);
            if (tmp != null)
            {
                this.txtTabaco_Puntaje.Text = tmp.hcl_puntos_hcft.ToString();
                this.txtTabaco_Puntaje_Titulo.Text = tmp.hcl_observ_hcft.Trim() != "NA" ? tmp.hcl_observ_hcft : String.Empty;
            }
            else
            {
                this.txtTabaco_Puntaje.Text = "0";
            }
        }
        #endregion
        //-------------------------------------------------
        // Calcular Totales
        //-------------------------------------------------
        #region fcvGenerarVistaFinalDatos: Generar vista final de datos
        /// <summary>
        /// Generar vista final de datos
        /// </summary>
        public void fcvGenerarVistaFinalDatos()
        {
            fcvSumatoriaPuntajes();
            fcvPorcentajeRiesgoFramingham();
            fcvNivelRiesgoFramingham();
            fcvNivelRiesgoTamizaje();
        }
        #endregion
        #region fcvSumatoriaPuntajes: Sumatoria puntajes
        /// <summary>
        /// Sumatoria puntajes 
        /// </summary>
        public void fcvSumatoriaPuntajes()
        {
            fcvSumatoriaPuntajesFramingham();
            fcvSumatoriaPuntajesTamizaje();
            fcvGenerarStrinDatos();
        }
        public void fcvSumatoriaPuntajesFramingham()
        {
            this.txtGeneralTotalPuntos.Text = "0";

            // Test de Framingham
            var lnuSexoEdad         = Convert.ToInt32(this.txtSexo_Puntaje.Text);
            var lnuColesterolHDL    = Convert.ToInt32(this.txtColesterolChdl_Puntaje.Text);
            var lnuColesterolTotal  = Convert.ToInt32(this.txtColesterolTotal_Puntaje.Text);
            var lnuPresionArt       = Convert.ToInt32(this.txtPresionArtSistolica_Puntaje.Text);
            var lnuDiabetes         = Convert.ToInt32(this.txtDiabetes_Puntaje.Text);
            var lnuTabaco           = Convert.ToInt32(this.txtTabaco_Puntaje.Text);

            this.txtGeneralTotalPuntos.Text = (lnuSexoEdad + lnuColesterolHDL + lnuColesterolTotal + lnuPresionArt + lnuDiabetes + lnuTabaco).ToString();
        }
        public void fcvSumatoriaPuntajesTamizaje()
        {
            this.txtTamiGeneralTotalPuntos.Text = "0";
            // Tamizaje
            var lnutTamiFamiMCorazon = Convert.ToInt32(this.txtFrmFamiMuerCorazon_Puntaje.Text);
            var lnutTamiFamiDiabetes = Convert.ToInt32(this.txtFamiliDiabetes_Puntaje.Text);
            var lnutTamiInfarto      = Convert.ToInt32(this.txtFrmInfarto_Puntaje.Text);
            var lnutTamiTensionAlta  = Convert.ToInt32(this.txtFrmTaAlta_Puntaje.Text);
            var lnutTamiMedicamentos = Convert.ToInt32(this.txtFrmTaMedicamento_Puntaje.Text);
            var lnutTamiAzucar       = Convert.ToInt32(this.txtFrmAzucarSangre_Puntaje.Text);
            var lnutTamiIMC          = Convert.ToInt32(this.txtFrmImc_Puntaje.Text);
            var lnutTamiCintura      = Convert.ToInt32(this.txtFrmMedidCintura_Puntaje.Text);
            var lnutTamiActivFisica  = Convert.ToInt32(this.txtFrmActividadFisica_Puntaje.Text);
            var lnuTabaco            = Convert.ToInt32(this.txtTabaco_Puntaje.Text);

            this.txtTamiGeneralTotalPuntos.Text = (lnutTamiFamiMCorazon + lnutTamiFamiDiabetes + lnutTamiInfarto +
                                                lnutTamiTensionAlta + lnutTamiMedicamentos + lnutTamiAzucar +
                                                lnutTamiIMC + lnutTamiCintura + lnutTamiActivFisica + lnuTabaco).ToString();
        }
        #endregion
        #region fcvPorcentajeRiesgoFramingham: Porcentaje riesgo cardiovascular segun puntos
        /// <summary>
        /// Porcentaje riesgo cardiovascular desde sumatoria puntos del test framingham
        /// </summary>
        public void fcvPorcentajeRiesgoFramingham()
        {
            this.txtGeneralPorcentaje.Text = "0";

            var lnuValor = Convert.ToInt32(this.txtGeneralTotalPuntos.Text);

            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamr10aRango(this.txtFrgSis_codsex_sexo.Text, lnuValor);
            if (tmp != null)
            {
                this.txtGeneralPorcentaje.Text = ((int)tmp.hcl_riesgo_hcfr).ToString();
            }
        }
        #endregion
        #region fcvNivelRiesgoFramingham: Nivel de riesgo cardiovascular segun porcentaje
        /// <summary>
        /// obtener Nivel de riesgo cardiovascular segun porcentaje
        /// </summary>
        public void fcvNivelRiesgoFramingham()
        {
            this.txtGeneralNivelClasificacion.Text = "NO ASIGNADO";

            var lnuValor = Convert.ToInt32(this.txtGeneralPorcentaje.Text);

            var tmp = HCLValidarCodigo.fobRegBuscarHclframghamniveRango(this.txtFrgSis_codsex_sexo.Text, lnuValor);
            if (tmp != null)
            {
                this.txtGeneralNivelClasificacion.Text = tmp.hcl_titulo_hcft;
                this.txtFrgGeneralNotaNivel.Text = tmp.hcl_observ_hcfn;
                this.FrgFondoNivel.Background = Funciones.FuxSetSolidColorBrush(tmp.hcl_vcolor_hcfn);
            }
        }
        #endregion
        #region fcvNivelRiesgoTamizaje: Nivel de riesgo cardiovascular segun tamizaje
        /// <summary>
        /// obtener Nivel de riesgo cardiovascular segun tamizaje
        /// </summary>
        public void fcvNivelRiesgoTamizaje()
        {
            this.txtTamiNivelClasificacion.Text = "NO ASIGNADO";

            var lnuValor = Convert.ToInt32(this.txtTamiGeneralTotalPuntos.Text);

            // los niveles no estan en tabla, se hacen manual aqui (me dio flojera crear tabla)


            if (lnuValor >= 0 && lnuValor <= 10) // Latente
            {
                this.txtTamiNivelClasificacion.Text = "LATENTE";
                this.TamiFondoNivel.Background = Funciones.FuxSetSolidColorBrush("#FF06B03C"); // Verde
            }
            else if (lnuValor >= 11 && lnuValor <= 15) // Intermedio
            {
                this.txtTamiNivelClasificacion.Text = "INTERMEDIO";
                this.TamiFondoNivel.Background = Funciones.FuxSetSolidColorBrush("#FFEEF379"); // Amarillo
            }
            else if (lnuValor >= 16 && lnuValor <= 25) // Alto
            {
                this.txtTamiNivelClasificacion.Text = "ALTO";
                this.TamiFondoNivel.Background = Funciones.FuxSetSolidColorBrush("#FFFD9110"); // Naranja
            }
            else
            { 
                // mayor o igual a 26
                this.txtTamiNivelClasificacion.Text = "MUY ALTO";
                this.TamiFondoNivel.Background = Funciones.FuxSetSolidColorBrush("#FFFB133D"); // Rojo
            }
        }
        #endregion
        #region fcvGenerarStrinDatos: Generar el string de datos para guardar en tablas
        /// <summary>
        /// Generar el string de datos para guardar en tablas
        /// </summary>
        public void fcvGenerarStrinDatos()
        {
            // V1*SEXO*EDAD*HDL*CTOTAL*PRES-ART*DIABETES*TABACO*FAMILI-M-CORAZON*FAMILIA-DIABETES*INFARTO*TA*MEDICAMENT*
            //AZUCAR*PESO*TALLA*IMC*CINTURA*ACT-FISICA*TAMIZAJE-PUNTOS-TOTALES*FRG-PUNTOS-TOTAL*FRG-PORCENT-RIESGO

            gcrValorGenerado = "V1*" + this.txtFrgSis_codsex_sexo.Text + "*" +
                                       this.txtFrgSia_edaymd_usua.Text + "*" +
                                       this.txtColesterolChdl.Text + "*" +
                                       this.txtColesterolTotal.Text + "*" +
                                       this.txtPresionArtSistolica.Text + "*" +
                                       this.txtDiabetes.Text + "*" +
                                       this.txtTabaco.Text + "*" +
                                       this.txtFrgFamiMuerCorazon.Text + "*" +
                                       this.txtFrmFamiliDiabetes.Text + "*" +
                                       this.txtFrmInfarto.Text + "*" +
                                       this.txtFrmTaAlta.Text + "*" +
                                       this.txtFrmTaMedicamento.Text + "*" +
                                       this.txtFrmAzucarSangre.Text + "*" +
                                       this.txtFrmIMCPeso.Text + "*" +
                                       this.txtFrmIMCTalla.Text + "*" +
                                       this.txtFrmIMCImc.Text + "*" +
                                       this.txtFrmMedidCintura.Text + "*" +
                                       this.txtFrmActividadFisica.Text + "*" +
                                       this.txtTamiGeneralTotalPuntos.Text + "*" +
                                       this.txtGeneralTotalPuntos.Text + "*" +
                                       this.txtGeneralPorcentaje.Text;
        }
        #endregion
        #region fcvCargarValoresDesdeString: Cargar los valores desde String 
        /// <summary>
        /// Cargar los valores desde String 
        /// </summary>
        public void fcvCargarValoresDesdeString(String tcrValorString)
        {
            if (!String.IsNullOrWhiteSpace(tcrValorString))
            {
                String[] larArray = (tcrValorString).Split("*".ToCharArray());

                if (larArray[0].Trim() == "V1")
                {
                    // Cargar datos guardados con la version 1
                    // V1*SEXO*EDAD*HDL*CTOTAL*PRES-ART*DIABETES*TABACO*FAMILI-M-CORAZON*FAMILIA-DIABETES*INFARTO*TA*MEDICAMENT*
                    //AZUCAR*PESO*TALLA*IMC*CINTURA*ACT-FISICA*TAMIZAJE-PUNTOS-TOTALES*FRG-PUNTOS-TOTAL*FRG-PORCENT-RIESGO

                    this.txtFrgSis_codsex_sexo.Text     = larArray[1].Trim();
                    this.txtFrgSia_edaymd_usua.Text     = larArray[2].Trim();
                    this.txtColesterolChdl.Text         = larArray[3].Trim();
                    this.txtColesterolTotal.Text        = larArray[4].Trim();
                    this.txtPresionArtSistolica.Text    = larArray[5].Trim();
                    this.txtDiabetes.Text               = larArray[6].Trim();
                    this.txtTabaco.Text                 = larArray[7].Trim();
                    this.txtFrgFamiMuerCorazon.Text     = larArray[8].Trim();
                    this.txtFrmFamiliDiabetes.Text      = larArray[9].Trim();
                    this.txtFrmInfarto.Text             = larArray[10].Trim();
                    this.txtFrmTaAlta.Text              = larArray[11].Trim();
                    this.txtFrmTaMedicamento.Text       = larArray[12].Trim();
                    this.txtFrmAzucarSangre.Text        = larArray[13].Trim();
                    this.txtFrmIMCPeso.Text             = larArray[14].Trim();
                    this.txtFrmIMCTalla.Text            = larArray[15].Trim();
                    this.txtFrmIMCImc.Text              = larArray[16].Trim();
                    this.txtFrmMedidCintura.Text        = larArray[17].Trim();
                    this.txtFrmActividadFisica.Text     = larArray[18].Trim();
                    this.txtTamiGeneralTotalPuntos.Text = larArray[19].Trim();
                    this.txtGeneralTotalPuntos.Text     = larArray[20].Trim();
                    this.txtGeneralPorcentaje.Text      = larArray[21].Trim();
                }
            }
        }
        #endregion
        //-------------------------------------------------
        // Varios
        //-------------------------------------------------
        #region fcvLimpiarVista: Limpiar la vista de datos
        /// <summary>
        /// Limpiar la vista de datos
        /// </summary>
        public void fcvLimpiarVista()
        {
            fcvLimpiarVistaFramingham();
            fcvLimpiarVistaTamizaje();
        }
        #endregion
        #region fcvLimpiarVistaFramingham: Limpiar la vista Framingham
        /// <summary>
        /// Limpiar la vista de datos
        /// </summary>
        public void fcvLimpiarVistaFramingham()
        {
            // Test Framingham
            this.txtGeneralTotalPuntos.Text        = String.Empty;
            this.txtGeneralPorcentaje.Text         = String.Empty;
            this.txtGeneralNivelClasificacion.Text = String.Empty;
            this.txtFrgGeneralNotaNivel.Text       = String.Empty;
            this.FrgFondoNivel.Background          = Funciones.FuxSetSolidColorBrush("#FFEAEAEA");
        }
        #endregion
        #region fcvLimpiarVistaTamizaje: Limpiar la vista tamizaje
        /// <summary>
        /// Limpiar la vista de datos
        /// </summary>
        public void fcvLimpiarVistaTamizaje()
        {
            this.txtTamiNivelClasificacion.Text = String.Empty;
            this.TamiFondoNivel.Background      = Funciones.FuxSetSolidColorBrush("#FFEAEAEA");
        }
        #endregion

    }
}

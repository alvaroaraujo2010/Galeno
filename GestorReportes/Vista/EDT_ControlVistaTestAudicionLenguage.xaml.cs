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
using System.Threading;
using System.Windows.Threading;
using System.Windows.Shapes;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Validacion;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// TEST: EAD - Escala abereviada del desarrollo
    /// evolución y perfeccionamiento del habla y el lenguaje
    /// </summary>
    public partial class ControlEscalaEadAudicionLenguage : UserControl
    {
        public int gnuTotalAlInicio         = 0;
        public int gnuTotalAlInicioBruto    = 0;
        public int gnuTotalItemCorretos     = 0;
        public int gnuTotalPD               = 0;
        public int gnuTotalPT               = 0;
        public int gnuNumeroRango           = 0;

        public bool llgObjetosCargados      = false;
        public bool llgModoEdicionKey       = false;
        public bool llgModoEdicionValid     = true;
        public String gcrValorGenerado      = String.Empty;
        public String lcrModoVistaObjeto    = "D"; // D=Modo diseño /E=Edicion o Modo captura/V = Modo vista solo lectura
        public String lcrPrefijo            = "Al";  // Audicion lenguaje
        public TextBox lobRefTexto          = null;
        public ComboBox lobRefComboBox      = null;
        public List<CrtForms.ListaComboBox> lsSiNoGeneral;
        public List<ListCrtComboBox> tmpListObjetos = new List<ListCrtComboBox>();

        public ControlEscalaEadAudicionLenguage()
        {
            InitializeComponent();
        }
        #region fcvCargarVista: Generar la vista segun parametro
        /// <summary>
        /// <para>Generar la vista segun parametro</para>
        /// </summary>
        public void fcvCargarVista(String tcrValor)
        {
            // cargar modo vista 
            fcrModoVistaObjetos();
            llgObjetosCargados = true;
            fcvResaltarRangoSegunEdad();
            fcvCargarValoresDesdeString(tcrValor);
            llgModoEdicionValid = false;
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
                fcrModoVistaObjetosComboBoxColapsed();
            }
        }
        #endregion
        #region fcrModoVistaObjetosComboBoxColapsed: Ocultar los combobox cuando no es modo edicion
        /// <summary>
        /// <para>Ocultar los combobox cuando no es modo edicion</para>
        /// </summary>
        public void fcrModoVistaObjetosComboBoxColapsed()
        {
            foreach (var lobReg in tmpListObjetos)
            {
                lobReg.ComboBoxRef.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
        #region fcvCargarValoresDesdeString: Cargar los valores desde String
        /// <summary>
        /// Cargar los valores desde String 
        /// </summary>
        public void fcvCargarValoresDesdeString(String tcrValorString)
        {
            // RANGO*TOTAL-ACUM-INICIO*NUM-ITEM-CORRECTOS*TOTAL-PD*TOTAL-PT*31-1,32-0,33-1,34-1,35-1,...

            if (!String.IsNullOrWhiteSpace(tcrValorString))
            {
                String[] larArray = (tcrValorString).Split("*".ToCharArray());

                if (larArray.Length > 4)
                {
                    // cargar los datos totales
                    gnuNumeroRango                  = Convert.ToInt32(larArray[0].Trim());
                    this.txtAlTotalAcumulado.Text   = larArray[1].Trim();
                    this.txtAlItemsCorrectos.Text   = larArray[2].Trim();
                    this.txtAlTotalPD.Text          = larArray[3].Trim();

                    gnuTotalAlInicio        = Convert.ToInt32(larArray[1].Trim());
                    gnuTotalItemCorretos    = Convert.ToInt32(larArray[2].Trim());
                    gnuTotalPD              = Convert.ToInt32(larArray[3].Trim());
                    gnuTotalPT              = Convert.ToInt32(larArray[4].Trim());

                    // sacar el resto de elementos (combobox seleccionados 31-1,32-0,33-1,34-1,35-1,...)
                    HclUtilidades.fcvGenerarVistaDatosEscalaEAD(lcrModoVistaObjeto, larArray[5].Trim(), ref tmpListObjetos);
                }
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
                String lcrG15Seleccion = "X,0,1";
                String lcrG15Descripcion = "SIN EVALUACIÓN,NO,SI";
                lsSiNoGeneral = new List<CrtForms.ListaComboBox>();
                lsSiNoGeneral = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                //-------------------------------------------------
                //  RANGO 1
                //-------------------------------------------------
                #region Valores Rango 1
                // combo 1
                this.cboAlR1I1.ItemsSource = lsSiNoGeneral;
                this.cboAlR1I1.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR1I2.ItemsSource = lsSiNoGeneral;
                this.cboAlR1I2.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR1I3.ItemsSource = lsSiNoGeneral;
                this.cboAlR1I3.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  RANGO 2
                //-------------------------------------------------
                #region Valores Rango 2
                // combo 1
                this.cboAlR2I4.ItemsSource = lsSiNoGeneral;
                this.cboAlR2I4.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR2I5.ItemsSource = lsSiNoGeneral;
                this.cboAlR2I5.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR2I6.ItemsSource = lsSiNoGeneral;
                this.cboAlR2I6.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  RANGO 3
                //-------------------------------------------------
                #region Valores Rango 3
                // combo 1
                this.cboAlR3I7.ItemsSource = lsSiNoGeneral;
                this.cboAlR3I7.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR3I8.ItemsSource = lsSiNoGeneral;
                this.cboAlR3I8.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR3I9.ItemsSource = lsSiNoGeneral;
                this.cboAlR3I9.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  RANGO 4
                //-------------------------------------------------
                #region Valores Rango 4
                // combo 1
                this.cboAlR4I10.ItemsSource = lsSiNoGeneral;
                this.cboAlR4I10.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR4I11.ItemsSource = lsSiNoGeneral;
                this.cboAlR4I11.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR4I12.ItemsSource = lsSiNoGeneral;
                this.cboAlR4I12.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  RANGO 5
                //-------------------------------------------------
                #region Valores Rango 5
                // combo 1
                this.cboAlR5I13.ItemsSource = lsSiNoGeneral;
                this.cboAlR5I13.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR5I14.ItemsSource = lsSiNoGeneral;
                this.cboAlR5I14.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR5I15.ItemsSource = lsSiNoGeneral;
                this.cboAlR5I15.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  RANGO 6
                //-------------------------------------------------
                #region Valores Rango 6
                // combo 1
                this.cboAlR6I16.ItemsSource = lsSiNoGeneral;
                this.cboAlR6I16.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR6I17.ItemsSource = lsSiNoGeneral;
                this.cboAlR6I17.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR6I18.ItemsSource = lsSiNoGeneral;
                this.cboAlR6I18.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  RANGO 7
                //-------------------------------------------------
                #region Valores Rango 7
                // combo 1
                this.cboAlR7I19.ItemsSource = lsSiNoGeneral;
                this.cboAlR7I19.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR7I20.ItemsSource = lsSiNoGeneral;
                this.cboAlR7I20.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR7I21.ItemsSource = lsSiNoGeneral;
                this.cboAlR7I21.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion

                //-------------------------------------------------
                //  RANGO 8
                //-------------------------------------------------
                #region Valores Rango 8
                // combo 1
                this.cboAlR8I22.ItemsSource = lsSiNoGeneral;
                this.cboAlR8I22.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR8I23.ItemsSource = lsSiNoGeneral;
                this.cboAlR8I23.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR8I24.ItemsSource = lsSiNoGeneral;
                this.cboAlR8I24.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion

                //-------------------------------------------------
                //  RANGO 9
                //-------------------------------------------------
                #region Valores Rango 9
                // combo 1
                this.cboAlR9I25.ItemsSource = lsSiNoGeneral;
                this.cboAlR9I25.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR9I26.ItemsSource = lsSiNoGeneral;
                this.cboAlR9I26.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR9I27.ItemsSource = lsSiNoGeneral;
                this.cboAlR9I27.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  RANGO 10
                //-------------------------------------------------
                #region Valores Rango 10
                // combo 1
                this.cboAlR10I28.ItemsSource = lsSiNoGeneral;
                this.cboAlR10I28.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR10I29.ItemsSource = lsSiNoGeneral;
                this.cboAlR10I29.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR10I30.ItemsSource = lsSiNoGeneral;
                this.cboAlR10I30.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  RANGO 11
                //-------------------------------------------------
                #region Valores Rango 6
                // combo 1
                this.cboAlR11I31.ItemsSource = lsSiNoGeneral;
                this.cboAlR11I31.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR11I32.ItemsSource = lsSiNoGeneral;
                this.cboAlR11I32.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR11I33.ItemsSource = lsSiNoGeneral;
                this.cboAlR11I33.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                #endregion
                //-------------------------------------------------
                //  RANGO 12
                //-------------------------------------------------
                #region Valores Rango 12
                // combo 1
                this.cboAlR12I34.ItemsSource = lsSiNoGeneral;
                this.cboAlR12I34.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 2
                this.cboAlR12I35.ItemsSource = lsSiNoGeneral;
                this.cboAlR12I35.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
                // combo 3
                this.cboAlR12I36.ItemsSource = lsSiNoGeneral;
                this.cboAlR12I36.SelectedIndex = Convert.ToInt32(lsSiNoGeneral[0].IdIndice);
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
                if (llgObjetosCargados == true && lcrModoVistaObjeto != "V" && lcrModoVistaObjeto != "D")
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    if (lobRefTexto != lobTexto)
                    {
                        // buscar en temporal
                        var lobReg = tmpListObjetos.FirstOrDefault(x => x.TextBoxNombre == lobTexto.Name);
                        if (lobReg != null)
                        {
                            // guardar la referencia
                            lobRefComboBox = lobReg.ComboBoxRef;
                            lobRefTexto = lobTexto;
                        }
                    }
                    // hacer la gestion 
                    if (lobRefComboBox != null)
                    {
                        //lcrValor = lcrValor == "X" ? String.Empty : lcrValor;
                        var lobG1ComboBox1 = (CrtForms.ListaComboBox)lobRefComboBox.SelectedItem;
                        lobRefComboBox.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                        fcvGenerarTotalSumatoria();
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

                    if (lobRefComboBox != lobCombo)
                    {
                        // buscar en temporal
                        var lobReg = tmpListObjetos.FirstOrDefault(x => x.ComboBoxNombre == lobCombo.Name);
                        if (lobReg != null)
                        {
                            // guardar la referencia
                            lobRefComboBox = lobCombo;
                            lobRefTexto = lobReg.TextBoxRef;
                        }
                    }
                    // hacer la gestion 
                    if (lobRefTexto != null)
                    {
                        lobRefTexto.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, lobRefTexto.Text, ",", lobList.ListaValoresSel);
                        lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(lobRefTexto.Text, ",", lobList.ListaValoresSel);
                        fcvGenerarTotalSumatoria();
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
        // Generar Listas referencia de objetos 
        //-------------------------------------------------
        #region Actualizar ComboBox desde Campo Texto
        public void fcvSetListaEnumVisual(Visual tobParen)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(tobParen); i++)
            {
                // Tomar el objeto hijo segun el index. 
                Visual lobObjchildVisual = (Visual)VisualTreeHelper.GetChild(tobParen, i);

                // cuando sea un combobox Adicionar a la lista
                var lobCoboBox = lobObjchildVisual as ComboBox;

                if (lobCoboBox != null)
                {
                    // sacar el numero unico del registro desde: cboPsR2I5
                    String[] larArray = (lobCoboBox.Name).Split("I".ToCharArray());
                    var lnuIdRegistro = Convert.ToInt32(larArray[1].Trim());

                    String[] larArray1 = (larArray[0].Trim()).Split("R".ToCharArray());
                    var lnuRango = Convert.ToInt32(larArray1[1].Trim());

                    var lcrObjTexto = "txt" + lcrPrefijo + "R" + lnuRango.ToString().Trim() + "I" + lnuIdRegistro.ToString().Trim();
                    var lobRefObjTexto = this.FindName(lcrObjTexto) as TextBox;

                    var lobReg = new ListCrtComboBox
                    {
                        TextBoxRef      = lobRefObjTexto,
                        TextBoxNombre   = lcrObjTexto,
                        ComboBoxRef     = lobCoboBox,
                        ComboBoxNombre  = lobCoboBox.Name,
                        IdRegistro      = lnuIdRegistro,
                        CodigoRango     = lnuRango
                    };

                    tmpListObjetos.Add(lobReg);
                }
                else
                {
                    //llamada con recursividad
                    fcvSetListaEnumVisual(lobObjchildVisual);
                }
            }
        }
        #endregion
        //-------------------------------------------------
        // Generar Listas referencia de objetos 
        //-------------------------------------------------
        #region fcvCboLoaded: registrar el objeto en la lista temporal
        private void fcvCboLoaded(object sender, RoutedEventArgs e)
        {
            var lobCoboBox = (ComboBox)sender;

            if (lobCoboBox != null)
            {
                // sacar el numero unico del registro desde: cboPsR2I5
                String[] larArray = (lobCoboBox.Name).Split("I".ToCharArray());
                var lnuIdRegistro = Convert.ToInt32(larArray[1].Trim());

                String[] larArray1 = (larArray[0].Trim()).Split("R".ToCharArray());
                var lnuRango = Convert.ToInt32(larArray1[1].Trim());

                var lcrObjTexto = "txt" + lcrPrefijo + "R" + lnuRango.ToString().Trim() + "I" + lnuIdRegistro.ToString().Trim();
                var lobRefObjTexto = this.FindName(lcrObjTexto) as TextBox;

                var lobReg = new ListCrtComboBox
                {
                    TextBoxRef      = lobRefObjTexto,
                    TextBoxNombre   = lcrObjTexto,
                    ComboBoxRef     = lobCoboBox,
                    ComboBoxNombre  = lobCoboBox.Name,
                    IdRegistro      = lnuIdRegistro,
                    CodigoRango     = lnuRango
                };

                tmpListObjetos.Add(lobReg);

                if (lcrModoVistaObjeto != "E" && lcrModoVistaObjeto != "G")
                {
                    //lobCoboBox.Visibility = Visibility.Collapsed;
                }
            }

        }
        #endregion
        //-------------------------------------------------
        // generar sumatoria total
        //-------------------------------------------------
        #region fcvGenerarTotalSumatoria: Generar total sumatoria
        private void fcvGenerarTotalSumatoria()
        {
            gnuTotalAlInicio = 0;
            gnuTotalAlInicioBruto = 100;
            gnuTotalItemCorretos = 0;
            gnuTotalPD = 0;

            foreach (var lobReg in tmpListObjetos)
            {
                if (lobReg.TextBoxRef.Text == "1")
                {
                    gnuTotalItemCorretos++;

                    if (lobReg.IdRegistro < gnuTotalAlInicioBruto)
                    {
                        gnuTotalAlInicio = lobReg.IdRegistro > 1 ? lobReg.IdRegistro - 1 : lobReg.IdRegistro;
                        gnuTotalAlInicioBruto = lobReg.IdRegistro;
                    }
                }
            }
            gnuTotalPD = gnuTotalAlInicio + gnuTotalItemCorretos;

            // Refrescar la vista
            this.txtAlTotalAcumulado.Text   = gnuTotalAlInicio.ToString();
            this.txtAlItemsCorrectos.Text   = gnuTotalItemCorretos.ToString();
            this.txtAlTotalPD.Text          = gnuTotalPD.ToString();
            var lcrEdad                     = Convert.ToInt32(this.txtEadAlSia_edadia_usua.Text);

            var lobRegTmp = HCLValidarCodigo.fobRegBuscarHcltesteadescalValor(lcrPrefijo, gnuTotalPD, lcrEdad);
            if (lobRegTmp != null)
            {
                var loRegAux    = HCLValidarCodigo.fobRegBuscarHcltesteadrango(lobRegTmp.hcl_nroreg_hcer);
                gnuNumeroRango  = (int)loRegAux.hcl_nroran_hcer;
                gnuTotalPT      = (int)lobRegTmp.hcl_valran_hceb;
            }

            // Generar la string para guardar
            // RANGO*TOTAL-ACUM-INICIO*NUM-ITEM-CORRECTOS*TOTAL-PD*TOTAL-PT*31-1,32-0,33-1,34-1,35-1,...
            var lcrValor = gnuNumeroRango.ToString().Trim() + "*" + this.txtAlTotalAcumulado.Text + "*" +
                           this.txtAlItemsCorrectos.Text + "*" + this.txtAlTotalPD.Text + "*" + gnuTotalPT;

            gcrValorGenerado = lcrValor + "*" + HclUtilidades.fcrGenerarStringDatosEscalaEAD(ref tmpListObjetos);
        }
        #endregion
        //-------------------------------------------------
        // Resaltar Vista Rango edad
        #region fcvResaltarRangoSegunEdad: Resaltar el rango segun la edad del paciente
        private void fcvResaltarRangoSegunEdad()
        {
            if (lcrModoVistaObjeto == "E" || lcrModoVistaObjeto == "G")
            {
                var lcrNombreBordeRango = HclUtilidades.fcrEscalaEADRangoSegunEdad(lcrPrefijo, this.txtEadAlSia_edadia_usua.Text);

                if (!String.IsNullOrWhiteSpace(lcrNombreBordeRango))
                {
                    var lobRefObBorder = this.FindName(lcrNombreBordeRango) as Border;

                    if (lobRefObBorder != null)
                    {
                        lobRefObBorder.Background = EdtUtilidades.SetSolidColorBrush("#FF04B44C");
                    }
                }
            }
        }
        #endregion

    }
}

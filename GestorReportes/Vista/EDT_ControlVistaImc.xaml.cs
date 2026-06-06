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
    /// Interaction logic for EDT_ControlVistaImc.xaml
    /// </summary>
    public partial class ControlVistaImc : UserControl
    {
        public bool llgObjetosCargados = false;
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = true;
        public String gcrValorGenerado = String.Empty;
        public String lcrModoVistaObjeto = "D"; // D=Modo diseño /E=Edicion o Modo captura/V = Modo vista solo lectura
        // Referencia a objetos en formato de H.C relacioandos con imc  -> segun variables publicas asociasdas al objeto
        public TextBox gobRefPeso = null; // TRIAGE_PESO_CORPORAL_EN_KILOG/EXAMFISICO_EXP_FISICO_PESO/EXAMFISC_PESO_URGENCIA/MATERPERI_PESO_MPTL/ATENRNACID_GRAMO_PESO_AL_NACER
        public TextBox gobRefTalla = null; // TRIAGE_TALLA_EN_CENTIMETROS/EXAMFISICO_EXP_FISICO_TALLA/EXAMFISC_TALLA_URGENCIA/MATERPERI_TALLA_MPTL/ATENRNACID_TALLA_CENTIMETROS
        public TextBox gobRefImc = null; // EXAMFISICO_EXP_FISICO_IMC/EXAMFISC_IMC_URGINCIA/MATERPERI_IMC_MPTL

        public ControlVistaImc()
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
            if (lcrModoVistaObjeto != "E")
            {
                this.txtImcPeso.IsReadOnly = true;
                this.txtImcTalla.IsReadOnly = true;
                this.txtImc.IsReadOnly = true;
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

            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtImcPeso"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtImcTalla"))) { lnuCont1++; }

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
                    case "txtImcPeso":
                        #region Validacion
                        lcrNombreCampo = "Peso en Kilosgramos";
                        lcrValorReturn = String.Empty;

                        if (String.IsNullOrWhiteSpace(this.txtImcPeso.Text))
                        {
                            lcrValorReturn = "Debe diligenciar valor númerico";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumerosEx(this.txtImcPeso.Text))
                            {
                                var lcrPeso = Funciones.fcrRemplazarChrDecimal(this.txtImcPeso.Text);
                                var lnuPeso = Convert.ToDouble(lcrPeso);

                                if (lnuPeso < 1 || lnuPeso > 200)
                                {
                                    lcrValorReturn = "Valor fuera del rango";
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Valor debe ser númerico";
                            }
                        }
                        fcvSetColorValidacion(this.txtImcPeso, lcrValorReturn);
                        break;
                        #endregion

                    case "txtImcTalla":
                        #region Validacion
                        lcrNombreCampo = "Talla en centimetros";
                        lcrValorReturn = String.Empty;

                        if (String.IsNullOrWhiteSpace(this.txtImcTalla.Text))
                        {
                            lcrValorReturn = "Debe diligenciar valor númerico";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumeros(this.txtImcTalla.Text))
                            {
                                var lnuValor = Convert.ToUInt32(this.txtImcTalla.Text);
                                if (lnuValor < 10 || lnuValor > 230)
                                {
                                    lcrValorReturn = "Valor fuera del rango";
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Valor debe ser númerico";
                            }
                        }
                        fcvSetColorValidacion(this.txtImcTalla, lcrValorReturn);
                        break;
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
        // Calcular IMC
        //-------------------------------------------------
        #region fcvGenerarVistaFinalDatos: Generar vista final de datos
        /// <summary>
        /// Generar vista final de datos
        /// </summary>
        public void fcvGenerarVistaFinalDatos()
        {
            var lcrPeso  = Funciones.fcrRemplazarChrDecimal(this.txtImcPeso.Text);
            var lcrTalla = Funciones.fcrRemplazarChrDecimal(this.txtImcTalla.Text);

            var lnuPeso  = Convert.ToDouble(lcrPeso);
            var lnuTalla = Convert.ToDouble(lcrTalla);

            var lnuImc = lnuPeso / ((lnuTalla / 100) * (lnuTalla / 100));
            var lcrImc = lnuImc.ToString();

            if (lcrImc.Length > 5)
            {
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                lcrImc = lcrImc.Substring(0, 5);
                // cuando se hace el substring y el caracter separador decimal queda de ultimo, suprimirlo
                lcrImc = lcrImc.Substring(4, 1) == lcrSeparadorDecimal ? lcrImc.Substring(0, 4) : lcrImc;
            }

            this.txtImc.Text = lcrImc;
            fcvGenerarStrinDatos();
        }
        #endregion
        //-------------------------------------------------
        // Calcular Totales
        //-------------------------------------------------
        #region fcvGenerarStrinDatos: Generar el string de datos para guardar en tablas
        /// <summary>
        /// Generar el string de datos para guardar en tablas
        /// </summary>
        public void fcvGenerarStrinDatos()
        {
            // V1*PESO*TALLA*IMC

            gcrValorGenerado = "V1*" + this.txtImcPeso.Text + "*" +
                                       this.txtImcTalla.Text + "*" +
                                       this.txtImc.Text;
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
                    // V1*PESO*TALLA*IMC

                    this.txtImcPeso.Text  = larArray[1].Trim();
                    this.txtImcTalla.Text = larArray[2].Trim();
                    this.txtImc.Text   = larArray[3].Trim();
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
            //this.txtImcPeso.Text   = String.Empty;
            //this.txtImcTalla.Text  = String.Empty;
            this.txtImc.Text    = String.Empty;
        }
        #endregion

    }
}

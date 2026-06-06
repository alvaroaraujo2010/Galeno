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
    /// Interaction logic for EDT_ControlVistaEscalaEaPuntuacion.xaml
    /// </summary>
    public partial class ControlVistaEscalaEadPuntuacion : UserControl
    {
        #region Referencia a objetos
        private TextBox lobRefObjAlPD;
        private TextBox lobRefObjAlPT;
        private TextBox lobRefObjAlPV;
        #endregion
        #region Referencia a objetos
        private TextBox lobRefObjMgPD;
        private TextBox lobRefObjMgPT;
        private TextBox lobRefObjMgPV;
        #endregion
        #region Referencia a objetos
        private TextBox lobRefObjMfPD;
        private TextBox lobRefObjMfPT;
        private TextBox lobRefObjMfPV;
        #endregion
        #region Referencia a objetos
        private TextBox lobRefObjPsPD;
        private TextBox lobRefObjPsPT;
        private TextBox lobRefObjPsPV;
        #endregion

        public bool llgObjetosCargados = false;
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = true;
        public String gcrValorGenerado = String.Empty;
        public String lcrModoVistaObjeto = "D"; // D=Modo diseño /E=Edicion o Modo captura/V = Modo vista solo lectura
        public List<CrtForms.ListaComboBox> lsSiNoGeneral;

        public ControlVistaEscalaEadPuntuacion()
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
                //IniciarComboBox();
            }
            else
            {
                //this.txtColesterolChdl.IsReadOnly = true;

                //this.cboFrgFamiMuerCorazon.Visibility = Visibility.Collapsed;
                //this.cboFamiliDiabetes.Visibility = Visibility.Collapsed;
            }
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

                    //this.txtFrgSis_codsex_sexo.Text = larArray[1].Trim();
                    //this.txtFrgSia_edaymd_usua.Text = larArray[2].Trim();
                    //this.txtColesterolChdl.Text = larArray[3].Trim();
                }
            }
        }
        #endregion
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region fcvCargarVista: Generar la vista segun parametro
        /// <summary>
        /// <para>Generar la vista segun parametro</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrArea: "AL"=Audicion Lenguaje/ "MG"=Motricidad Grues/ "MF"=Motricidad Fina/ "PS"=Personal social </para>
        /// </summary>
        public void fcvGenerarGrafico(int tnuRango, String tcrArea, int tnuPuntajePD, int tnuPuntajePT)
        {

            var lcrValorPD = "txtR" + tnuRango.ToString().Trim() + tcrArea + "PD";
            var lcrValorPT = "txtR" + tnuRango.ToString().Trim() + tcrArea + "PT";
            var lcrValorPV = "R" + tnuRango.ToString().Trim() + tcrArea.ToUpper() + "PTV" + tnuPuntajePT.ToString().Trim();

            var lobRefObjPD = this.FindName(lcrValorPD) as TextBox;
            var lobRefObjPT = this.FindName(lcrValorPT) as TextBox;
            var lobRefObjPV = this.FindName(lcrValorPV) as TextBox;

            fcvLimpiarVistaDatos(tcrArea, ref lobRefObjPD, ref lobRefObjPT, ref lobRefObjPV);

            if (lobRefObjPD != null) 
            {
                lobRefObjPD.IsReadOnly = true;
                lobRefObjPD.Text = tnuPuntajePD.ToString(); 
            }
            if (lobRefObjPT != null) 
            {
                lobRefObjPT.IsReadOnly = true;
                lobRefObjPT.Text = tnuPuntajePT.ToString(); 
            }

            if (lobRefObjPV != null && tnuPuntajePT >= 16 && tnuPuntajePT <= 61) 
            {
                lobRefObjPV.IsReadOnly = true;
                lobRefObjPV.Text = "X"; 
            }

        }
        #endregion
        #region fcvLimpiarVistaDatos: Limpiar la vista datos graficados anteriores segun cad area
        /// <summary>
        /// <para>Limpiar la vista datos graficados anteriores segun cad area</para>
        /// </summary>
        public void fcvLimpiarVistaDatos(String tcrArea, ref TextBox tobRefObjPD, ref TextBox tobRefObjPT, ref TextBox tobRefObjPV)
        {
            #region Limpiar datos AL
            if (tcrArea == "AL")
            {
                if (lobRefObjAlPD != null) { lobRefObjAlPD.Text = String.Empty; }
                if (lobRefObjAlPT != null) { lobRefObjAlPT.Text = String.Empty; }
                if (lobRefObjAlPV != null) { lobRefObjAlPV.Text = String.Empty; }

                lobRefObjAlPD = tobRefObjPD;
                lobRefObjAlPT = tobRefObjPT;
                lobRefObjAlPV = tobRefObjPV;
            }
            #endregion
            #region Limpiar datos MG
            if (tcrArea == "MG")
            {
                if (lobRefObjMgPD != null) { lobRefObjMgPD.Text = String.Empty; }
                if (lobRefObjMgPT != null) { lobRefObjMgPT.Text = String.Empty; }
                if (lobRefObjMgPV != null) { lobRefObjMgPV.Text = String.Empty; }

                lobRefObjMgPD = tobRefObjPD;
                lobRefObjMgPT = tobRefObjPT;
                lobRefObjMgPV = tobRefObjPV;
            }
            #endregion
            #region Limpiar datos MF
            if (tcrArea == "MF")
            {
                if (lobRefObjMfPD != null) { lobRefObjMfPD.Text = String.Empty; }
                if (lobRefObjMfPT != null) { lobRefObjMfPT.Text = String.Empty; }
                if (lobRefObjMfPV != null) { lobRefObjMfPV.Text = String.Empty; }

                lobRefObjMfPD = tobRefObjPD;
                lobRefObjMfPT = tobRefObjPT;
                lobRefObjMfPV = tobRefObjPV;
            }
            #endregion
            #region Limpiar datos PS
            if (tcrArea == "PS")
            {
                if (lobRefObjPsPD != null) { lobRefObjPsPD.Text = String.Empty;}
                if (lobRefObjPsPT != null) { lobRefObjPsPT.Text = String.Empty; }
                if (lobRefObjPsPV != null) { lobRefObjPsPV.Text = String.Empty; }

                lobRefObjPsPD = tobRefObjPD;
                lobRefObjPsPT = tobRefObjPT;
                lobRefObjPsPV = tobRefObjPV;
            }
            #endregion
        }
        #endregion
    }
}

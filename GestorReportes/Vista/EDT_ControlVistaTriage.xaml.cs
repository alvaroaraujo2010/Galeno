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


namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for ControlVistaTriage.xaml
    /// </summary>
    public partial class ControlVistaTriage : UserControl
    {
        private List<CrtForms.ListaComboBox> G1CbSia_tipide_tide;
        private List<CrtForms.ListaComboBox> G1CbSis_codsex_sexo;
        private List<CrtForms.ListaComboBox> G1CbSia_codmed_tmed;
        private List<CrtForms.ListaComboBox> G1CbAdm_tiplle_tria;
        private List<CrtForms.ListaComboBox> G1CbAdm_clasif_tria;
        private List<CrtForms.ListaComboBox> G1CbAdm_remisi_tria;
        private List<CrtForms.ListaComboBox> G1CbAdm_tipreg_tria;

        public ADMModeloTriage tmpReg = null;
        public ControlVistaTriage()
        {
            InitializeComponent();
            fcvIniciarComboBox();
        }
        /// <summary>
        /// <para>Generar la vista segun el parametro Registro triage</para>
        /// </summary>
        public void fcvCargarVista(String tcrRegistro)
        {
            if (!String.IsNullOrWhiteSpace(tcrRegistro))
            {
                var lobReg = ADMModeloTriage.flsListaAdmtriagemaestr(tcrRegistro);
                if (lobReg.Count == 0) { return; }

                tmpReg = lobReg.FirstOrDefault();
                fcvCargarVistaObjetos();
            }
        }
        /// <summary>
        /// <para>Carga los datos del registro en la vista de objetos</para>
        /// </summary>
        public void fcvCargarVistaObjetos()
        {
            if (tmpReg != null)
            {
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                // Datos encabezado
                this.txtG1Adm_nroreg_tria.Text = tmpReg.Adm_nroreg_tria;
                this.txtG1Adm_gesfec_tria.Text = tmpReg.Adm_gesfec_tria.ToShortDateString();
                this.txtG1Adm_geshor_tria.Text = Funciones.fcrConvierteHora(tmpReg.Adm_geshor_tria.ToString(), "24", lcrSeparadorDecimal, ":");
                this.txtG1Sis_estpro_espr.Text = tmpReg.Sis_estpro_espr;
                this.txtG1Sis_despro_espr.Text = tmpReg.Sis_despro_espr;
                // Datos del uusario / paciente 
                this.txtG1Sia_tipide_tide.Text = tmpReg.Sia_tipide_tide;
                this.txtG1Sia_nroide_usua.Text = tmpReg.Sia_nroide_usua;
                this.txtG1Sia_priape_usua.Text = tmpReg.Sia_priape_usua;
                this.txtG1Sia_segape_usua.Text = tmpReg.Sia_segape_usua;
                this.txtG1Sia_prinom_usua.Text = tmpReg.Sia_prinom_usua;
                this.txtG1Sia_segnom_usua.Text = tmpReg.Sia_segnom_usua;
                this.txtG1Sia_fecnac_usua.Text = tmpReg.Sia_fecnac_usua.ToShortDateString();
                this.txtG1Sis_codsex_sexo.Text = tmpReg.Sis_codsex_sexo;
                this.txtG1Sia_edapac_usua.Text = tmpReg.Sia_edapac_usua.ToString();
                this.txtG1Sia_codeps_teps.Text = tmpReg.Sia_codeps_teps;
                this.txtG1Sia_deseps_teps.Text = tmpReg.Sia_deseps_teps;
                this.txtG1Hcl_nrohis_hicl.Text = tmpReg.Hcl_nrohis_hicl;
                this.txtG1Sis_idemun_muni.Text = tmpReg.Sis_idemun_muni;
                this.txtG1Sis_nommun_muni.Text = tmpReg.Sis_nommun_muni;
                this.txtG1Sis_coddep_dpto.Text = tmpReg.Sis_coddep_dpto;
                this.txtG1Sis_desdep_dpto.Text = tmpReg.Sis_desdep_dpto;
                // Signos vitales
                this.txtG1Adm_frecar_tria.Text = tmpReg.Adm_frecar_tria.ToString();
                this.txtG1Adm_temper_tria.Text = tmpReg.Adm_temper_tria.ToString();
                this.txtG1Adm_freres_tria.Text = tmpReg.Adm_freres_tria.ToString();
                this.txtG1Adm_pesokg_tria.Text = tmpReg.Adm_pesokg_tria.ToString();
                this.txtG1Adm_tasist_tria.Text = tmpReg.Adm_tasist_tria.ToString();
                this.txtG1Adm_tallac_tria.Text = tmpReg.Adm_tallac_tria.ToString();
                this.txtG1Adm_tadias_tria.Text = tmpReg.Adm_tadias_tria.ToString();
                //Motivo consulta y varios
                this.txtG1Adm_motcon_tria.Text = tmpReg.Adm_motcon_tria;
                this.txtG1Adm_clasif_tria.Text = G1CbAdm_clasif_tria.FirstOrDefault(x => x.IdIndice == tmpReg.Adm_clasif_tria).NombreOpcion;
                this.txtG1Adm_remisi_tria.Text = G1CbAdm_remisi_tria.FirstOrDefault(x => x.IdIndice == tmpReg.Adm_remisi_tria).NombreOpcion;
                this.txtG1Adm_observ_tria.Text = tmpReg.Adm_observ_tria;
                this.txtG1Sia_codcat_ceat.Text = tmpReg.Sia_codcat_ceat;
                this.txtG1Sia_descat_ceat.Text = tmpReg.Sia_descat_ceat;
                this.txtG1Sia_codpfa_prof.Text = tmpReg.Sia_codpfa_prof;
                this.txtG1Sia_nompro_prof.Text = tmpReg.Sia_nompro_prof;
            }
        }
        /// <summary>
        /// <para>Limiar vista de objetos</para>
        /// </summary>
        public void fcvLimpiarVista()
        {
            if (tmpReg != null)
            {
                this.txtG1Adm_nroreg_tria.Text = String.Empty;
                this.txtG1Adm_gesfec_tria.Text = String.Empty;
                this.txtG1Adm_geshor_tria.Text = String.Empty;
                this.txtG1Sis_estpro_espr.Text = String.Empty;
                this.txtG1Sis_despro_espr.Text = String.Empty;
                // Datos del uusario / paciente 
                this.txtG1Sia_tipide_tide.Text = String.Empty;
                this.txtG1Sia_nroide_usua.Text = String.Empty;
                this.txtG1Sia_priape_usua.Text = String.Empty;
                this.txtG1Sia_segape_usua.Text = String.Empty;
                this.txtG1Sia_prinom_usua.Text = String.Empty;
                this.txtG1Sia_segnom_usua.Text = String.Empty;
                this.txtG1Sia_fecnac_usua.Text = String.Empty;
                this.txtG1Sis_codsex_sexo.Text = String.Empty;
                this.txtG1Sia_edapac_usua.Text = String.Empty;
                this.txtG1Sia_codeps_teps.Text = String.Empty;
                this.txtG1Sia_deseps_teps.Text = String.Empty;
                this.txtG1Hcl_nrohis_hicl.Text = String.Empty;
                this.txtG1Sis_idemun_muni.Text = String.Empty;
                this.txtG1Sis_nommun_muni.Text = String.Empty;
                this.txtG1Sis_coddep_dpto.Text = String.Empty;
                this.txtG1Sis_desdep_dpto.Text = String.Empty;
                // Signos vitales
                this.txtG1Adm_frecar_tria.Text = String.Empty;
                this.txtG1Adm_temper_tria.Text = String.Empty;
                this.txtG1Adm_freres_tria.Text = String.Empty;
                this.txtG1Adm_pesokg_tria.Text = String.Empty;
                this.txtG1Adm_tasist_tria.Text = String.Empty;
                this.txtG1Adm_tallac_tria.Text = String.Empty;
                this.txtG1Adm_tadias_tria.Text = String.Empty;
                //Motivo consulta y varios
                this.txtG1Adm_motcon_tria.Text = String.Empty;
                this.txtG1Adm_clasif_tria.Text = String.Empty;
                this.txtG1Adm_remisi_tria.Text = String.Empty;
                this.txtG1Adm_observ_tria.Text = String.Empty;
                this.txtG1Sia_codcat_ceat.Text = String.Empty;
                this.txtG1Sia_descat_ceat.Text = String.Empty;
                this.txtG1Sia_codpfa_prof.Text = String.Empty;
                this.txtG1Sia_nompro_prof.Text = String.Empty;
            }
        }
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void fcvIniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                //SIA_TIPIDE_TIDE: Tipo Identificación
                //-------------------------------------------------
                #region SIA_TIPIDE_TIDE: Tipo Identificación
                string lcrG17Seleccion = "AS,CC,CD,CE,MS,NU,RC,TI";
                string lcrG17Descripcion = "Adulto sin identificación,Cédula de ciudadanía,Carné diplomático min rel-ext,Cédula de extrangería,Menor sin identificación,Número único de identificación,Registro civil,Tarjeta identidad";
                G1CbSia_tipide_tide = new List<CrtForms.ListaComboBox>();
                G1CbSia_tipide_tide = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_CODSEX_SEXO: Sexo
                //-------------------------------------------------
                #region SIS_CODSEX_SEXO: Sexo
                string lcrG11Seleccion = "M,F";
                string lcrG11Descripcion = "Masculino,Femenino";
                G1CbSis_codsex_sexo = new List<CrtForms.ListaComboBox>();
                G1CbSis_codsex_sexo = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_CODMED_TMED: Medida Edad
                //-------------------------------------------------
                #region SIA_CODMED_TMED: Medida Edad
                string lcrG12Seleccion = "1,2,3";
                string lcrG12Descripcion = "Años,Meses,Dias";
                G1CbSia_codmed_tmed = new List<CrtForms.ListaComboBox>();
                G1CbSia_codmed_tmed = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_TIPLLE_TRIA: llegada al servicio
                //-------------------------------------------------
                #region ADM_TIPLLE_TRIA: llegada al servicio
                string lcrG13Seleccion = "1,2,3,4,5,6,7,8,9,10";
                string lcrG13Descripcion = "Caminando,Vehiculo particular,Ambulancia,Vehiculo policia,Carro de bomberos,Taxi,Motocicleta,Bicicleta,Helicoptero,Otro";
                G1CbAdm_tiplle_tria = new List<CrtForms.ListaComboBox>();
                G1CbAdm_tiplle_tria = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CLASIF_TRIA: Clasificación triage
                //-------------------------------------------------
                #region ADM_CLASIF_TRIA: Clasificación triage
                string lcrG14Seleccion = "1,2,3,4,5";
                string lcrG14Descripcion = "TRIAGE I (1),TRIAGE II (2),TRIAGE III (3),TRIAGE IV (4),TRIAGE V (5)";
                G1CbAdm_clasif_tria = new List<CrtForms.ListaComboBox>();
                G1CbAdm_clasif_tria = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_REMISI_TRIA: Destino Remisión
                //-------------------------------------------------
                #region ADM_REMISI_TRIA: Destino Remisión
                string lcrG15Seleccion = "1,2,3";
                string lcrG15Descripcion = "Consulta Externa,Consulta prioritaria,Urgencia";
                G1CbAdm_remisi_tria = new List<CrtForms.ListaComboBox>();
                G1CbAdm_remisi_tria = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_TIPREG_TRIA: Tipo registro
                //-------------------------------------------------
                #region ADM_TIPREG_TRIA: Tipo registro
                string lcrG16Seleccion = "1,2";
                string lcrG16Descripcion = "Solo valoración inicial,Evaluación completa";
                G1CbAdm_tipreg_tria = new List<CrtForms.ListaComboBox>();
                G1CbAdm_tipreg_tria = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
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

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
    /// Interaction logic for EDT_ControlHojaAdmision.xaml
    /// </summary>
    public partial class ControlHojaAdmision : UserControl
    {
        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public ControlHojaAdmision()
        {
            InitializeComponent();
            this.IsManipulationEnabled = true;
        }
        /// <summary>
        /// <para>Generar la vista segun el parametro Registro de admision</para>
        /// </summary>
        public void fcvCargarVista(String tcrCodigoAdmision)
        {
            if (!String.IsNullOrWhiteSpace(tcrCodigoAdmision))
            {

                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(tcrCodigoAdmision);
                if (lobRegAdm.Count == 0) { return; }

                tmpRegAdm = lobRegAdm.FirstOrDefault();
                fcvCargarVistaObjetos();
            }
        }
        /// <summary>
        /// <para>Carga los datos del registro en la vista de objetos</para>
        /// </summary>
        public void fcvCargarVistaObjetos()
        {
            if (tmpRegAdm!=null)
            {
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                // Datos del usuario / paciente 
                this.txtG1Sia_tipide_tide.Text = tmpRegAdm.Sia_tipide_tide;
                this.txtG1Sia_nroide_usua.Text = tmpRegAdm.Sia_nroide_usua;
                this.txtG1Sia_nomusu_usua.Text = tmpRegAdm.Sia_nomusu_usua;
                this.txtSia_fecnac_usua.Text = tmpRegAdm.Sia_fecnac_usua.ToShortDateString();
                this.txtSis_codsex_sexo.Text = tmpRegAdm.Sis_dessex_sexo;
                this.txtSia_edaymd_usua.Text = tmpRegAdm.Sia_edaymd_usua;
                // Datos de la admision
                this.txtHcl_nrohis_hicl.Text = tmpRegAdm.Hcl_nrohis_hicl;
                this.txtSis_Desadm_espr.Text = tmpRegAdm.Sis_despro_espr;
                this.txtG1Adm_secadm_rgad.Text = tmpRegAdm.Adm_secadm_rgad;
                this.txtG1Adm_fecadm_rgad.Text = tmpRegAdm.Adm_fecadm_rgad.ToShortDateString();
                this.txtG1Adm_horadm_rgad.Text = Funciones.fcrConvierteHora(tmpRegAdm.Adm_horadm_rgad.ToString(), "24", lcrSeparadorDecimal, ":");
                this.txtSia_dixivng_tdia.Text = tmpRegAdm.Sia_dixing_tdia + " - " + tmpRegAdm.Sia_desdia_tdia;
                this.txtAdm_caucon_rgad.Text = tmpRegAdm.Adm_caucon_rgad;
                this.txtSia_areing_aser.Text = tmpRegAdm.Desia_areing_aser;
                this.txtAdm_codcex_tcex.Text = tmpRegAdm.Adm_descex_tcex;
                this.txtAdm_codtat_tatn.Text = tmpRegAdm.Adm_destat_tatn;
                this.txtSia_codeps_teps.Text = tmpRegAdm.Sia_deseps_teps;
                this.txtG1Sia_codpfa_prof.Text = tmpRegAdm.Sia_nompro_prof;
                // datos atención
                this.txtAdm_pacemb_rgad.Text = tmpRegAdm.Adm_pacemb_rgad;
                this.txtG1Adm_reingr_rgad.Text = tmpRegAdm.Adm_reingr_rgad;
                this.txtG1Adm_codoad_toad.Text = tmpRegAdm.Adm_codoad_toad; //
                this.txtG1Sia_regate_rgat.Text = tmpRegAdm.Sia_regate_rgat; //SIA_DESREG_RGAT
                this.txtG1Sia_codcat_ceat.Text = tmpRegAdm.Sia_descat_ceat;
                this.txtG1Sia_dixing_tdia.Text = tmpRegAdm.Sia_desdia_tdia;
                this.txtG1Sia_codare_aser.Text = tmpRegAdm.Sia_desare_aser;
                this.txtG1Adm_codcex_tcex.Text = tmpRegAdm.Adm_descex_tcex;
                this.txtG1Hos_codcam_caho.Text = tmpRegAdm.Hos_codcam_caho;
                // contrato
                this.txtG1Cto_nrocon_cont.Text = tmpRegAdm.Cto_nrocon_cont;
                this.txtG1Sia_codeps_teps.Text = tmpRegAdm.Sia_codeps_teps;
                this.txtG1Adm_nroaut_rgad.Text = tmpRegAdm.Adm_nroaut_rgad;
                this.txtG1Sia_tipusu_regi.Text = tmpRegAdm.Sia_tipusu_regi;
                this.txtG1Sia_tipafi_tafi.Text = tmpRegAdm.Sia_tipafi_tafi;
                this.txtG1Sia_nivsbn_nsbn.Text = tmpRegAdm.Sia_nivsbn_nsbn;
                this.txtG1Sia_tippob_tpob.Text = tmpRegAdm.Sia_tippob_tpob;
                this.txtG1Sia_nivcon_ncon.Text = tmpRegAdm.Sia_nivcon_ncon;
                // remision
                this.txtG1Adm_nrorem_rgad.Text = tmpRegAdm.Adm_nrorem_rgad;
                this.txtG1Adm_fecrem_rgad.Text = tmpRegAdm.Adm_fecrem_rgad.ToShortDateString();
                this.txtG1Sis_idemun_muni.Text = tmpRegAdm.Sis_nommun_muni;
                this.txtG1Sia_codips_tips.Text = tmpRegAdm.Sia_desips_tips;
                // acompañante
                this.txtG1Adm_nomaco_rgad.Text = tmpRegAdm.Adm_nomaco_rgad;
                this.txtG1Adm_telaco_rgad.Text = tmpRegAdm.Adm_telaco_rgad;
                this.txtG1Adm_diraco_rgad.Text = tmpRegAdm.Adm_diraco_rgad;
            }
        }
    }
}

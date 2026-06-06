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
    /// Interaction logic for EDT_ControlVistaAdmitido.xaml
    /// </summary>
    public partial class ControlVistaAdmitido : UserControl
    {
        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public ControlVistaAdmitido()
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
            if (tmpRegAdm != null)
            {
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                // Datos del uusario / paciente 
                this.txtG1Sia_tipide_tide.Text  = tmpRegAdm.Sia_tipide_tide;
                this.txtG1Sia_nroide_usua.Text  = tmpRegAdm.Sia_nroide_usua;
                this.txtG1Sia_nomusu_usua.Text  = tmpRegAdm.Sia_nomusu_usua;
                this.txtSia_fecnac_usua.Text    = tmpRegAdm.Sia_fecnac_usua.ToShortDateString();
                this.txtSis_codsex_sexo.Text    = tmpRegAdm.Sis_dessex_sexo;
                this.txtSia_edaymd_usua.Text    = tmpRegAdm.Sia_edaymd_usua;
                this.txtSia_telres_usua.Text    = tmpRegAdm.Sia_telres_usua;
                this.txtSia_dirres_usua.Text    = tmpRegAdm.Sia_dirres_usua;
                // Datos de la admision
                this.txtHcl_nrohis_hicl.Text    = tmpRegAdm.Hcl_nrohis_hicl;
                //this.txtCit_codasi_mcit.Text    = tmpRegAdm.Cit_codasi_mcit;
                this.txtAdm_nroaut_rgad.Text    = tmpRegAdm.Adm_nroaut_rgad;
                this.txtSis_Desadm_espr.Text    = tmpRegAdm.Sis_despro_espr;
                this.txtG1Adm_secadm_rgad.Text  = tmpRegAdm.Adm_secadm_rgad;
                this.txtG1Adm_fecadm_rgad.Text  = tmpRegAdm.Adm_fecadm_rgad.ToShortDateString();
                this.txtG1Adm_horadm_rgad.Text  = Funciones.fcrConvierteHora(tmpRegAdm.Adm_horadm_rgad.ToString(), "24", lcrSeparadorDecimal, ":");
                this.txtAdm_codtat_tatn.Text    = tmpRegAdm.Adm_destat_tatn;
                this.txtSia_codeps_teps.Text    = tmpRegAdm.Sia_deseps_teps;
                this.txtG1Sia_tipusu_regi.Text  = tmpRegAdm.Sia_destip_regi;
                this.txtSis_nommun_muni.Text    = SISValidarCodigo.fobRegBuscarSistabmunicipio(tmpRegAdm.Sis_idemun_muni).sis_nommun_muni;

                this.txtG1Sis_desocu_ocup.Text = tmpRegAdm.Sis_desocu_ocup;
                this.txtG1Sia_desper_pret.Text = tmpRegAdm.Sia_desper_pret;
                this.txtG1Sia_desedu_sine.Text = tmpRegAdm.Sia_desedu_sine;

            }
        }
        /// <summary>
        /// <para>Limiar vista de objetos</para>
        /// </summary>
        public void fcvLimpiarVista()
        {
            if (tmpRegAdm != null)
            {
                // Datos del uusario / paciente 
                this.txtG1Sia_tipide_tide.Text  = String.Empty;
                this.txtG1Sia_nroide_usua.Text  = String.Empty;
                this.txtG1Sia_nomusu_usua.Text  = String.Empty;
                this.txtSia_fecnac_usua.Text    = String.Empty;
                this.txtSis_codsex_sexo.Text    = String.Empty;
                this.txtSia_edaymd_usua.Text    = String.Empty;
                // Datos de la admision
                this.txtHcl_nrohis_hicl.Text    = String.Empty;
                this.txtAdm_nroaut_rgad.Text    = String.Empty;
                //this.txtCit_codasi_mcit.Text    = String.Empty;
                this.txtSis_Desadm_espr.Text    = String.Empty;
                this.txtG1Adm_secadm_rgad.Text  = String.Empty;
                this.txtG1Adm_fecadm_rgad.Text  = String.Empty;
                this.txtG1Adm_horadm_rgad.Text  = String.Empty;
                this.txtAdm_codtat_tatn.Text    = String.Empty;
                this.txtSia_codeps_teps.Text    = String.Empty;
                this.txtSia_telres_usua.Text    = String.Empty;
                this.txtSia_dirres_usua.Text    = String.Empty;
                this.txtG1Sia_tipusu_regi.Text  = String.Empty;

            }
        }
    }
}

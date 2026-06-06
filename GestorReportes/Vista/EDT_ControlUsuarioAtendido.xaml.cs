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
    /// Interaction logic for EDT_ControlUsuarioAtendido.xaml
    /// </summary>
    public partial class ControlUsuarioAtendido : UserControl
    {
        public SIAModeloUsuariosAtendidos tmpRegUsuario = null;
        public ControlUsuarioAtendido()
        {
            InitializeComponent();
            this.IsManipulationEnabled = true;
        }
        /// <summary>
        /// <para>Generar la vista segun el parametro Registro de admision</para>
        /// </summary>
        public void fcvCargarVista(String tcrCodigoUnico)
        {
            if (!String.IsNullOrWhiteSpace(tcrCodigoUnico))
            {
                var lobReg = SIAModeloUsuariosAtendidos.flsListaSiausuarioatend(tcrCodigoUnico);
                if (lobReg.Count == 0) { return; }

                tmpRegUsuario = lobReg.FirstOrDefault();
                fcvCargarVistaObjetos();
            }
        }
        /// <summary>
        /// <para>Carga los datos del registro en la vista de objetos</para>
        /// </summary>
        public void fcvCargarVistaObjetos()
        {
            if (tmpRegUsuario != null)
            {
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                // Datos del uusario / paciente 
                this.txtSia_idesec_usua.Text    = tmpRegUsuario.Sia_idesec_usua;
                this.txtG1Sia_tipide_tide.Text  = tmpRegUsuario.Sia_tipide_tide;
                this.txtG1Sia_nroide_usua.Text  = tmpRegUsuario.Sia_nroide_usua;
                this.txtG1Sia_nomusu_usua.Text  = tmpRegUsuario.Sia_nomusu_usua;
                this.txtSia_fecnac_usua.Text    = tmpRegUsuario.Sia_fecnac_usua.ToShortDateString();
                this.txtSis_codsex_sexo.Text    = tmpRegUsuario.Sis_dessex_sexo;
                this.txtSia_edaymd_usua.Text    = tmpRegUsuario.Sia_edaymd_usua;
                this.txtSia_telres_usua.Text    = tmpRegUsuario.Sia_telres_usua;
                this.txtSia_dirres_usua.Text    = tmpRegUsuario.Sia_dirres_usua;
                // Datos varios
                this.txtHcl_nrohis_hicl.Text    = tmpRegUsuario.Hcl_nrohis_hicl;
                this.txtSia_codeps_teps.Text    = tmpRegUsuario.Sia_deseps_teps;
                this.txtG1Sis_nommun_muni.Text  = tmpRegUsuario.Sis_nommun_muni;
            }
        }
        /// <summary>
        /// <para>Limiar vista de objetos</para>
        /// </summary>
        public void fcvLimpiarVista()
        {
            if (tmpRegUsuario != null)
            {
                // Datos del uusario / paciente 
                this.txtSia_idesec_usua.Text    = String.Empty;
                this.txtG1Sia_tipide_tide.Text  = String.Empty;
                this.txtG1Sia_nroide_usua.Text  = String.Empty;
                this.txtG1Sia_nomusu_usua.Text  = String.Empty;
                this.txtSia_fecnac_usua.Text    = String.Empty;
                this.txtSis_codsex_sexo.Text    = String.Empty;
                this.txtSia_edaymd_usua.Text    = String.Empty;
                // Datos de la admision
                this.txtHcl_nrohis_hicl.Text    = String.Empty;
                this.txtSia_codeps_teps.Text    = String.Empty;
                this.txtG1Sis_nommun_muni.Text  = String.Empty;
            }
        }
    }
}

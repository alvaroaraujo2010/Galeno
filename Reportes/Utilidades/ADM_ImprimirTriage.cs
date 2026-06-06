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
using System.Drawing.Printing;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;

namespace Reportes.Utilidades
{
    public class ADMImprimirTriage
    {
        //-------------------------------------------------
        // Variables de control general
        //-------------------------------------------------
        #region Variables de control general
        public String gcrCodigoAdmision = String.Empty;
        public String gcrCodigoRegistro = String.Empty;  // Codigo Codigo registro maestro cuando sea requerido
        public String gcrTipoRegistro = "GENERAL";    // "GENERAL" = Maestro evaluación Triage
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public bool glgVistaPrevia = true;          // true = mostrar vista previa / fase = no mostrar vista previa
        public Window gobOwner;
        public DataSet01 gobDataSet = new DataSet01();
        #endregion
        //-------------------------------------------------
        // fcvEjecutar: Ejecutar reportes
        //-------------------------------------------------
        #region Mostrar la vista del reporte
        /// <summary>
        /// Mostrar la vista del reoprte
        /// </summary>
        public void fcvEjecutar()
        {
            //- Barra de Espera
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos para vista reporte...", "CENTRO");
            lobDlgAdd.Show();

            fcvCargarEncabezados();
            // Formato Maestro evaluación Triage
            if (gcrTipoRegistro == "GENERAL")
            {
                #region Formato Maestro evaluación Triage
                if (flgCargarTempDatosEvaluacionTriage())
                {
                    //- Maestro evaluación Triage
                    ADM_ImprimirTriage lobRepTriage01 = new ADM_ImprimirTriage();
                    lobRepTriage01.SetDataSource(gobDataSet);

                    VisorReportes lobVisorPm = new VisorReportes();
                    lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepTriage01;
                    lobVisorPm.Owner = gobOwner;
                    lobVisorPm.Activate();
                    lobDlgAdd.Close();
                    lobVisorPm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay datos");
                }
                #endregion
            }
        }
        #endregion
        #region fcvCargarEncabezados Cargar datos encabezado reporte y admision
        /// <summary>
        /// Cargar datos encabezado reporte y admision
        /// </summary>
        public void fcvCargarEncabezados()
        {
            // Encabezados 
            var lobEncab = REPUtilidades.fobDataSet01Encabezado(ref gobDataSet);
            gobDataSet.SisEncabezado.AddSisEncabezadoRow(lobEncab);
        }
        #endregion
        //-------------------------------------------------
        // flgCargarTempDatosEvaluacionTriage: Cargar Datos evaluación Triage
        //-------------------------------------------------
        #region flgCargarTempDatosEvaluacionTriage: Cargar Datos evaluación Triage
        /// <summary>
        /// <para>Cargar Datos evaluación Triage</para>
        /// </summary>
        private bool flgCargarTempDatosEvaluacionTriage()
        {
            var llgReturn = false;            

            Aplicacion oApp = Aplicacion.Instancia();
            // Definir temporales para los datos 
            List<ADMModeloTriage> lobTempMaestro = null;            

            //gobDataSet = new DataSet01();
            DataSet01.AdmtriagemaestrDataTable lobMaestro = gobDataSet.Admtriagemaestr;
    
            //----------------------------------------------------------
            // Maestro evaluación Triage
            //----------------------------------------------------------
            #region Maestro evaluación Triage
            DataSet01.AdmtriagemaestrRow lobRegistroMa = lobMaestro.NewAdmtriagemaestrRow();
            lobTempMaestro = ADMModeloTriage.flsListaAdmtriagemaestrRpt(gcrCodigoRegistro);

            foreach (var lobReg in lobTempMaestro)
            {
                var lcrApellidos  = lobReg.Sia_priape_usua;
                var lcrNombres    = lobReg.Sia_prinom_usua;
                var lcrEdad       = lobReg.Sia_edapac_usua;
                var lcrMedidaEdad = fcrLeerDescripcionMedida(lobReg.Sia_codmed_tmed);
                var lcrCodDiag    = lobReg.Sia_coddia_tdia;
                var lcrDescDiag   = lobReg.Sia_desdia_tdia;

                llgReturn = true;
                lobRegistroMa = lobMaestro.NewAdmtriagemaestrRow();
              
                lobRegistroMa.Adm_nroreg_tria = lobReg.Adm_nroreg_tria;
                lobRegistroMa.Sia_idesec_usua = lobReg.Sia_idesec_usua;
                lobRegistroMa.Hcl_nrohis_hicl = lobReg.Hcl_nrohis_hicl;
                lobRegistroMa.Adm_secadm_rgad = lobReg.Adm_secadm_rgad;
                lobRegistroMa.Sia_tipide_tide = lobReg.Sia_tipide_tide;
                lobRegistroMa.Sia_nroide_usua = lobReg.Sia_nroide_usua;                         
                lobRegistroMa.Sia_fecnac_usua = Funciones.fcrConvertFecha(lobReg.Sia_fecnac_usua);
                lobRegistroMa.Sis_codsex_sexo = lobReg.Sis_codsex_sexo == "F" ? "FEMENINO" : "MASCULINO";           
                lobRegistroMa.Sia_nomusu_usua = lobReg.Sia_nomusu_usua;              
                lobRegistroMa.Sia_edapac_usua = lobReg.Sia_edapac_usua;                                              
                lobRegistroMa.Adm_gesfec_tria = Funciones.fcrConvertFecha(lobReg.Adm_gesfec_tria);
                lobRegistroMa.Adm_geshor_tria = Funciones.fcrConvierteHora(lobReg.Adm_geshor_tria.ToString(), "24", gcrSeparadorDecimal, ":"); 
                lobRegistroMa.Adm_frecar_tria = lobReg.Adm_frecar_tria;
                lobRegistroMa.Adm_freres_tria = lobReg.Adm_freres_tria;
                lobRegistroMa.Adm_tasist_tria = lobReg.Adm_tasist_tria;
                lobRegistroMa.Adm_tadias_tria = lobReg.Adm_tadias_tria;
                lobRegistroMa.Adm_temper_tria = lobReg.Adm_temper_tria;
                lobRegistroMa.Adm_pesokg_tria = lobReg.Adm_pesokg_tria;
                lobRegistroMa.Adm_tallac_tria = lobReg.Adm_tallac_tria;
                lobRegistroMa.Adm_tiplle_tria = lobReg.Adm_tiplle_tria;
                lobRegistroMa.Adm_motcon_tria = lobReg.Adm_motcon_tria;
                lobRegistroMa.Adm_clasif_tria = fcrDescripcionTriage(lobReg.Adm_clasif_tria);
                lobRegistroMa.Adm_remisi_tria = fcrLeerDescripcionRemision(lobReg.Adm_remisi_tria);                
                lobRegistroMa.Adm_observ_tria = lobReg.Adm_observ_tria;
                lobRegistroMa.Sia_codeps_teps = lobReg.Sia_codeps_teps;
                lobRegistroMa.Fcm_codcpr_cpro = lobReg.Fcm_codcpr_cpro;
                lobRegistroMa.Sis_idemun_muni = lobReg.Sis_idemun_muni;
                lobRegistroMa.Sis_codmun_muni = lobReg.Sis_codmun_muni;
                lobRegistroMa.Sis_coddep_dpto = lobReg.Sis_coddep_dpto;
                lobRegistroMa.Sia_codcat_ceat = lobReg.Sia_codcat_ceat;
                lobRegistroMa.Sia_codpfa_prof = lobReg.Sia_codpfa_prof;
                lobRegistroMa.Sia_llaveb_usua = lobReg.Sia_llaveb_usua;
                lobRegistroMa.Adm_tipreg_tria = lobReg.Adm_tipreg_tria;
                lobRegistroMa.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                lobRegistroMa.Fcm_descpr_cpro = lobReg.Fcm_descpr_cpro;
                lobRegistroMa.Sia_descat_ceat = lobReg.Sia_descat_ceat;                
                lobRegistroMa.Sis_despro_espr = lobReg.Sis_despro_espr;
                lobRegistroMa.Sia_deseps_teps = lobReg.Sia_deseps_teps;
                lobRegistroMa.Sia_nompro_prof = lobReg.Sia_nompro_prof;
                lobRegistroMa.Sis_nommun_muni = lobReg.Sis_nommun_muni;
                lobRegistroMa.Sis_desdep_dpto = lobReg.Sis_desdep_dpto;
                lobRegistroMa.Adm_descla_adct = lobReg.Adm_descla_adct;
                lobRegistroMa.Adm_tiempo_adct = lobReg.Adm_tiempo_adct;

                //-----------------------------------------------------  
                // CONCATENAR NOMBRES USUARIOS
                //----------------------------------------------------- 
                lcrApellidos = !String.IsNullOrWhiteSpace(lobReg.Sia_segape_usua) ? lcrApellidos + " " + lobReg.Sia_segape_usua : lcrApellidos;
                lcrNombres   = !String.IsNullOrWhiteSpace(lobReg.Sia_segnom_usua) ? lcrNombres + " " + lobReg.Sia_segnom_usua : lcrNombres;
                lobRegistroMa.Sia_nomcomp_usua = lcrApellidos + " " + lcrNombres;
                //-----------------------------------------------------
                // CONCATENAR EDAD USUARIOS
                //-----------------------------------------------------
                lobRegistroMa.Sia_edadymes_usua = lcrEdad +" "+lcrMedidaEdad;
                //-----------------------------------------------------
                //-----------------------------------------------------
                // CONCATENAR DIAGNOSTICO 
                //-----------------------------------------------------
                lobRegistroMa.Sia_diagnost_tdia = lcrCodDiag + " - " + lcrDescDiag;
                //-----------------------------------------------------

                //-----------------------------------------------------
                // Add en temporal
                gobDataSet.Admtriagemaestr.AddAdmtriagemaestrRow(lobRegistroMa);
            }
            return llgReturn;
            #endregion
        }      
        #endregion  
        #region fcrDescripcionTriage: Convertir valores a Texto (Triage)
        public String fcrDescripcionTriage(String lcrNivelTriage)
        {
            var lcrReturn = String.Empty;
            switch (lcrNivelTriage)
            {
                case "1":
                    lcrReturn = "TRIAGE (I)";
                    break;

                case "2":
                    lcrReturn = "TRIAGE (II)";
                    break;

                case "3":
                    lcrReturn = "TRIAGE (III)";
                    break;

                case "4":
                    lcrReturn = "TRIAGE (IV)";
                    break;

                case "5":
                    lcrReturn = "TRIAGE (V)";
                    break;
            }         
            return lcrReturn;          
        }
        #endregion
        #region fcrLeerDescripcionRemision: Convertir valores a Texto (Remision)
        public String fcrLeerDescripcionRemision(String lcrDestinoRemision)
        {
            var lcrReturn = String.Empty;
            switch (lcrDestinoRemision)
            {
                case "1":
                    lcrReturn = "CONSULTA EXTERNA";
                    break;

                case "2":
                    lcrReturn = "CONSULTA PRIORITARIA";
                    break;

                case "3":
                    lcrReturn = "URGENCIAS";
                    break;
            }           
            return lcrReturn;            
        }
        #endregion         
        #region fcrLeerDescripcionMedida: Convertir valores a Texto (Medida Edad)
        public String fcrLeerDescripcionMedida(String lcrDescripcionMedida)
        {
            var lcrReturn = String.Empty;
            switch (lcrDescripcionMedida)
            {
                case "1":
                    lcrReturn = "Años";
                    break;

                case "2":
                    lcrReturn = "Meses";
                    break;

                case "3":
                    lcrReturn = "Dias";
                    break;
            }
            return lcrReturn;
        }
        #endregion         
    }
}

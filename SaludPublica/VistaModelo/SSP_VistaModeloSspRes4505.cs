//- MARMOTA-GENCODE: VERSION 2.0 - 02/09/2014 05:56:39 PM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using SaludPublica.Modelo;

namespace SaludPublica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sptablmsres4505</para>
    /// <para>DESCRIPCION:
    /// Tabla maestra de digitacion RES4505
    /// </para>
    /// </summary>
    public class VistaModeloSspRes4505 : VistaModeloSspRes4505Base
    {
        #region Modificar Registro
        /// <summary>
        /// Modificar Registro
        /// </summary>
        public override void Modificar()
        {
            try
            {
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
                tmpLogErrores = new List<LogsErrores>();
                if (TmpG2ListaBrow.Count == 0)
                {
                    AdicionarRel();
                }
                fcvValidarRegistroVista();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Modificar");
            }
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacion: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacion
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override string fcrValidacion(string tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgValidDefault = false;
            String lcrMsgErrorFecha=String.Empty;
            DateTime gdaFechaIniRes = Convert.ToDateTime("01/01/2010");  // Fecha inicial Para registros de Res 4505
            DateTime gdaFechaAtencion;   // Fecha de atención en el periodo
            int gnuDias=0;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Sia_idesec_usua":
                        lcrNombreCampo = "Código único del paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (glgSIS_ModoTempEdicion == false)
                        {
                            if (string.IsNullOrWhiteSpace(G1Sia_idesec_usua))
                            {
                                lcrValorReturn = "Código único del paciente: Es requerido";
                            }
                            else
                            {
                                EFsiausuarioatend tmp = new EFsiausuarioatend();
                                tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(G1Sia_idesec_usua);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_idesec_usua))
                                {
                                    G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                    G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                    G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                                }
                                else
                                {
                                    lcrValorReturn = "Código único del paciente: No existe";
                                }
                            }
                        }
                        break;

                    case "G1Sia_nroide_usua":
                        lcrNombreCampo = "Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (string.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                        {
                            lcrValorReturn = "Identificación: Es requerido";
                        }
                        else if (glgSIS_ModoTempEdicion==false)
                        {
                            // Buscar en maestro de usuarios; verificar que exista un registro para este paciente
                            EFsiausuarioatend tmp = new EFsiausuarioatend();
                            tmp = SIAValidarCodigo.fobRegBuscarIuSiausuarioatend(G1Sia_nroide_usua);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nroide_usua))
                            {
                                G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                                // Buscar en maestro de 4505; verificar que exista un registro para este paciente
                                var lcrMes = Funciones.fcrComponenteFecha(gdaFinPeriodo, "MES");
                                var lcrAno = Funciones.fcrComponenteFecha(gdaFinPeriodo, "AÑO");
                                ModeloSspNsRes4505 tmpNS4505 = null;

                                var tmpMae4505 = ModeloSspRes4505x.flsListaSptablmsres4505(tmp.sia_idesec_usua).FirstOrDefault();
                                if (tmpMae4505 != null)
                                {
                                    tmpNS4505 = ModeloSspNsRes4505.flsListaSptablnsres4505LlaveUnica(G1Sia_idesec_usua.Trim() + lcrAno + lcrMes);
                                }
                                if (tmpNS4505 != null)
                                {
                                    #region Datos
                                    G1Ssp_cam000_ms45 = "2"; // Registro Tipo 2
                                    G1Ssp_cam001_ms45 = tmpNS4505.Ssp_cam001_ms45;
                                    G1Ssp_cam002_ms45 = tmpNS4505.Ssp_cam002_ms45;
                                    G1Ssp_cam003_ms45 = tmp.sia_tipide_tide;
                                    G1Ssp_cam004_ms45 = tmp.sia_nroide_usua;
                                    G1Ssp_cam005_ms45 = tmp.sia_priape_usua;
                                    G1Ssp_cam006_ms45 = !String.IsNullOrWhiteSpace(tmp.sia_segape_usua) ? tmp.sia_segape_usua : "NONE"; // Si esta en blanco; colocar "NONE"
                                    G1Ssp_cam007_ms45 = tmp.sia_prinom_usua;
                                    G1Ssp_cam008_ms45 = !String.IsNullOrWhiteSpace(tmp.sia_segnom_usua) ? tmp.sia_segnom_usua : "NONE"; // Si esta en blanco; colocar "NONE"
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam009_ms45)) { G1Ssp_cam009_ms45 = tmp.sia_fecnac_usua.ToString().Remove(10, 14);}
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam010_ms45)) { G1Ssp_cam010_ms45 = tmp.sis_codsex_sexo; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam011_ms45)) { G1Ssp_cam011_ms45 = tmpNS4505.Ssp_cam011_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_codocu_ciuo)) { G1Ssp_codocu_ciuo = tmpNS4505.Ssp_codocu_ciuo; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam013_ms45)) { G1Ssp_cam013_ms45 = tmpNS4505.Ssp_cam013_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam014_ms45)) { G1Ssp_cam014_ms45 = tmpNS4505.Ssp_cam014_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam015_ms45)) { G1Ssp_cam015_ms45 = tmpNS4505.Ssp_cam015_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam016_ms45)) { G1Ssp_cam016_ms45 = tmpNS4505.Ssp_cam016_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam017_ms45)) { G1Ssp_cam017_ms45 = tmpNS4505.Ssp_cam017_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam018_ms45)) { G1Ssp_cam018_ms45 = tmpNS4505.Ssp_cam018_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam019_ms45)) { G1Ssp_cam019_ms45 = tmpNS4505.Ssp_cam019_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam020_ms45)) { G1Ssp_cam020_ms45 = tmpNS4505.Ssp_cam020_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam021_ms45)) { G1Ssp_cam021_ms45 = tmpNS4505.Ssp_cam021_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam022_ms45)) { G1Ssp_cam022_ms45 = tmpNS4505.Ssp_cam022_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam023_ms45)) { G1Ssp_cam023_ms45 = tmpNS4505.Ssp_cam023_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam024_ms45)) { G1Ssp_cam024_ms45 = tmpNS4505.Ssp_cam024_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam025_ms45)) { G1Ssp_cam025_ms45 = tmpNS4505.Ssp_cam025_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam026_ms45)) { G1Ssp_cam026_ms45 = tmpNS4505.Ssp_cam026_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam027_ms45)) { G1Ssp_cam027_ms45 = tmpNS4505.Ssp_cam027_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam028_ms45)) { G1Ssp_cam028_ms45 = tmpNS4505.Ssp_cam028_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam029_ms45)) { G1Ssp_cam029_ms45 = tmpNS4505.Ssp_cam029_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam030_ms45.ToString())) { G1Ssp_cam030_ms45 = tmpNS4505.Ssp_cam030_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam031_ms45)) { G1Ssp_cam031_ms45 = tmpNS4505.Ssp_cam031_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam032_ms45.ToString())) { G1Ssp_cam032_ms45 = tmpNS4505.Ssp_cam032_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam033_ms45)) { G1Ssp_cam033_ms45 = tmpNS4505.Ssp_cam033_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam034_ms45.ToString())) { G1Ssp_cam034_ms45 = tmpNS4505.Ssp_cam034_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam035_ms45)) { G1Ssp_cam035_ms45 = tmpNS4505.Ssp_cam035_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam036_ms45)) { G1Ssp_cam036_ms45 = tmpNS4505.Ssp_cam036_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam037_ms45)) { G1Ssp_cam037_ms45 = tmpNS4505.Ssp_cam037_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam038_ms45)) { G1Ssp_cam038_ms45 = tmpNS4505.Ssp_cam038_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam039_ms45)) { G1Ssp_cam039_ms45 = tmpNS4505.Ssp_cam039_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam040_ms45)) { G1Ssp_cam040_ms45 = tmpNS4505.Ssp_cam040_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam041_ms45)) { G1Ssp_cam041_ms45 = tmpNS4505.Ssp_cam041_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam042_ms45)) { G1Ssp_cam042_ms45 = tmpNS4505.Ssp_cam042_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam043_ms45)) { G1Ssp_cam043_ms45 = tmpNS4505.Ssp_cam043_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam044_ms45)) { G1Ssp_cam044_ms45 = tmpNS4505.Ssp_cam044_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam045_ms45)) { G1Ssp_cam045_ms45 = tmpNS4505.Ssp_cam045_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam046_ms45)) { G1Ssp_cam046_ms45 = tmpNS4505.Ssp_cam046_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam047_ms45)) { G1Ssp_cam047_ms45 = tmpNS4505.Ssp_cam047_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam048_ms45)) { G1Ssp_cam048_ms45 = tmpNS4505.Ssp_cam048_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam049_ms45)) { G1Ssp_cam049_ms45 = tmpNS4505.Ssp_cam049_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam050_ms45)) { G1Ssp_cam050_ms45 = tmpNS4505.Ssp_cam050_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam051_ms45)) { G1Ssp_cam051_ms45 = tmpNS4505.Ssp_cam051_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam052_ms45)) { G1Ssp_cam052_ms45 = tmpNS4505.Ssp_cam052_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam053_ms45)) { G1Ssp_cam053_ms45 = tmpNS4505.Ssp_cam053_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam054_ms45)) { G1Ssp_cam054_ms45 = tmpNS4505.Ssp_cam054_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam055_ms45)) { G1Ssp_cam055_ms45 = tmpNS4505.Ssp_cam055_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam056_ms45)) { G1Ssp_cam056_ms45 = tmpNS4505.Ssp_cam056_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam057_ms45.ToString())) { G1Ssp_cam057_ms45 = tmpNS4505.Ssp_cam057_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam058_ms45)) { G1Ssp_cam058_ms45 = tmpNS4505.Ssp_cam058_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam059_ms45)) { G1Ssp_cam059_ms45 = tmpNS4505.Ssp_cam059_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam060_ms45)) { G1Ssp_cam060_ms45 = tmpNS4505.Ssp_cam060_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam061_ms45)) { G1Ssp_cam061_ms45 = tmpNS4505.Ssp_cam061_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam062_ms45)) { G1Ssp_cam062_ms45 = tmpNS4505.Ssp_cam062_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam063_ms45)) { G1Ssp_cam063_ms45 = tmpNS4505.Ssp_cam063_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam064_ms45)) { G1Ssp_cam064_ms45 = tmpNS4505.Ssp_cam064_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam065_ms45)) { G1Ssp_cam065_ms45 = tmpNS4505.Ssp_cam065_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam066_ms45)) { G1Ssp_cam066_ms45 = tmpNS4505.Ssp_cam066_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam067_ms45)) { G1Ssp_cam067_ms45 = tmpNS4505.Ssp_cam067_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam068_ms45)) { G1Ssp_cam068_ms45 = tmpNS4505.Ssp_cam068_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam069_ms45)) { G1Ssp_cam069_ms45 = tmpNS4505.Ssp_cam069_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam070_ms45)) { G1Ssp_cam070_ms45 = tmpNS4505.Ssp_cam070_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam071_ms45)) { G1Ssp_cam071_ms45 = tmpNS4505.Ssp_cam071_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam072_ms45)) { G1Ssp_cam072_ms45 = tmpNS4505.Ssp_cam072_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam073_ms45)) { G1Ssp_cam073_ms45 = tmpNS4505.Ssp_cam073_ms45.ToShortDateString(); }
                                    if (G1Ssp_cam074_ms45 == 0) { G1Ssp_cam074_ms45 = tmpNS4505.Ssp_cam074_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam075_ms45)) { G1Ssp_cam075_ms45 = tmpNS4505.Ssp_cam075_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam076_ms45)) { G1Ssp_cam076_ms45 = tmpNS4505.Ssp_cam076_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam077_ms45)) { G1Ssp_cam077_ms45 = tmpNS4505.Ssp_cam077_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam078_ms45)) { G1Ssp_cam078_ms45 = tmpNS4505.Ssp_cam078_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam079_ms45)) { G1Ssp_cam079_ms45 = tmpNS4505.Ssp_cam079_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam080_ms45)) { G1Ssp_cam080_ms45 = tmpNS4505.Ssp_cam080_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam081_ms45)) { G1Ssp_cam081_ms45 = tmpNS4505.Ssp_cam081_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam082_ms45)) { G1Ssp_cam082_ms45 = tmpNS4505.Ssp_cam082_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam083_ms45)) { G1Ssp_cam083_ms45 = tmpNS4505.Ssp_cam083_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam084_ms45)) { G1Ssp_cam084_ms45 = tmpNS4505.Ssp_cam084_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam085_ms45)) { G1Ssp_cam085_ms45 = tmpNS4505.Ssp_cam085_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam086_ms45)) { G1Ssp_cam086_ms45 = tmpNS4505.Ssp_cam086_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam087_ms45)) { G1Ssp_cam087_ms45 = tmpNS4505.Ssp_cam087_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam088_ms45)) { G1Ssp_cam088_ms45 = tmpNS4505.Ssp_cam088_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam089_ms45)) { G1Ssp_cam089_ms45 = tmpNS4505.Ssp_cam089_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam090_ms45)) { G1Ssp_cam090_ms45 = tmpNS4505.Ssp_cam090_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam091_ms45)) { G1Ssp_cam091_ms45 = tmpNS4505.Ssp_cam091_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam092_ms45)) { G1Ssp_cam092_ms45 = tmpNS4505.Ssp_cam092_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam093_ms45)) { G1Ssp_cam093_ms45 = tmpNS4505.Ssp_cam093_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam094_ms45)) { G1Ssp_cam094_ms45 = tmpNS4505.Ssp_cam094_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam095_ms45)) { G1Ssp_cam095_ms45 = tmpNS4505.Ssp_cam095_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam096_ms45)) { G1Ssp_cam096_ms45 = tmpNS4505.Ssp_cam096_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam097_ms45)) { G1Ssp_cam097_ms45 = tmpNS4505.Ssp_cam097_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam098_ms45)) { G1Ssp_cam098_ms45 = tmpNS4505.Ssp_cam098_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam099_ms45)) { G1Ssp_cam099_ms45 = tmpNS4505.Ssp_cam099_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam100_ms45)) { G1Ssp_cam100_ms45 = tmpNS4505.Ssp_cam100_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam101_ms45)) { G1Ssp_cam101_ms45 = tmpNS4505.Ssp_cam101_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam102_ms45)) { G1Ssp_cam102_ms45 = tmpNS4505.Ssp_cam102_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam103_ms45)) { G1Ssp_cam103_ms45 = tmpNS4505.Ssp_cam103_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam104_ms45.ToString())) { G1Ssp_cam104_ms45 = tmpNS4505.Ssp_cam104_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam105_ms45)) { G1Ssp_cam105_ms45 = tmpNS4505.Ssp_cam105_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam106_ms45)) { G1Ssp_cam106_ms45 = tmpNS4505.Ssp_cam106_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam107_ms45.ToString())) { G1Ssp_cam107_ms45 = tmpNS4505.Ssp_cam107_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam108_ms45)) { G1Ssp_cam108_ms45 = tmpNS4505.Ssp_cam108_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam109_ms45.ToString())) { G1Ssp_cam109_ms45 = tmpNS4505.Ssp_cam109_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam110_ms45)) { G1Ssp_cam110_ms45 = tmpNS4505.Ssp_cam110_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam111_ms45)) { G1Ssp_cam111_ms45 = tmpNS4505.Ssp_cam111_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam112_ms45)) { G1Ssp_cam112_ms45 = tmpNS4505.Ssp_cam112_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam113_ms45)) { G1Ssp_cam113_ms45 = tmpNS4505.Ssp_cam113_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam114_ms45)) { G1Ssp_cam114_ms45 = tmpNS4505.Ssp_cam114_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam115_ms45)) { G1Ssp_cam115_ms45 = tmpNS4505.Ssp_cam115_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam116_ms45)) { G1Ssp_cam116_ms45 = tmpNS4505.Ssp_cam116_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam117_ms45)) { G1Ssp_cam117_ms45 = tmpNS4505.Ssp_cam117_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam118_ms45)) { G1Ssp_cam118_ms45 = tmpNS4505.Ssp_cam118_ms45.ToShortDateString(); }
                                    #endregion
                                }
                                else if (GlgSIS_ModoAdicion == true)
                                {
                                    // Cargar valores por defecto según el perfil
                                    G1Ssp_cam000_ms45 = "2"; // Registro Tipo 2
                                    G1Ssp_cam001_ms45 = String.Empty;
                                    G1Ssp_cam002_ms45 = G1Ssp_codips_sscf;
                                    G1Ssp_cam003_ms45 = tmp.sia_tipide_tide;
                                    G1Ssp_cam004_ms45 = tmp.sia_nroide_usua;
                                    G1Ssp_cam005_ms45 = tmp.sia_priape_usua;
                                    G1Ssp_cam006_ms45 = !String.IsNullOrWhiteSpace(tmp.sia_segape_usua) ? tmp.sia_segape_usua : "NONE"; // Si esta en blanco; colocar "NONE"
                                    G1Ssp_cam007_ms45 = tmp.sia_prinom_usua;
                                    G1Ssp_cam008_ms45 = !String.IsNullOrWhiteSpace(tmp.sia_segnom_usua) ? tmp.sia_segnom_usua : "NONE"; // Si esta en blanco; colocar "NONE"
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam009_ms45)) { G1Ssp_cam009_ms45 = tmp.sia_fecnac_usua.ToString().Remove(10, 14); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam010_ms45)) { G1Ssp_cam010_ms45 = tmp.sis_codsex_sexo; }
                                    // valores que vienen desde tabla valores por defecto 
                                    var lnuEdadDias = Funciones.fnuCalcularDiasFechas(Convert.ToDateTime(G1Ssp_cam009_ms45), gdaIniPeriodo);
                                    var lobReg = ModeloSspRes4505.flsNuevoRegistroDefault4505(lnuEdadDias, G1Ssp_cam010_ms45);

                                    #region Datos
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam011_ms45)) { G1Ssp_cam011_ms45 = lobReg.Ssp_cam011_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_codocu_ciuo)) { G1Ssp_codocu_ciuo = lobReg.Ssp_codocu_ciuo; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam013_ms45)) { G1Ssp_cam013_ms45 = lobReg.Ssp_cam013_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam014_ms45)) { G1Ssp_cam014_ms45 = lobReg.Ssp_cam014_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam015_ms45)) { G1Ssp_cam015_ms45 = lobReg.Ssp_cam015_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam016_ms45)) { G1Ssp_cam016_ms45 = lobReg.Ssp_cam016_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam017_ms45)) { G1Ssp_cam017_ms45 = lobReg.Ssp_cam017_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam018_ms45)) { G1Ssp_cam018_ms45 = lobReg.Ssp_cam018_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam019_ms45)) { G1Ssp_cam019_ms45 = lobReg.Ssp_cam019_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam020_ms45)) { G1Ssp_cam020_ms45 = lobReg.Ssp_cam020_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam021_ms45)) { G1Ssp_cam021_ms45 = lobReg.Ssp_cam021_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam022_ms45)) { G1Ssp_cam022_ms45 = lobReg.Ssp_cam022_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam023_ms45)) { G1Ssp_cam023_ms45 = lobReg.Ssp_cam023_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam024_ms45)) { G1Ssp_cam024_ms45 = lobReg.Ssp_cam024_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam025_ms45)) { G1Ssp_cam025_ms45 = lobReg.Ssp_cam025_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam026_ms45)) { G1Ssp_cam026_ms45 = lobReg.Ssp_cam026_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam027_ms45)) { G1Ssp_cam027_ms45 = lobReg.Ssp_cam027_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam028_ms45)) { G1Ssp_cam028_ms45 = lobReg.Ssp_cam028_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam029_ms45)) { G1Ssp_cam029_ms45 = lobReg.Ssp_cam029_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam030_ms45.ToString())) { G1Ssp_cam030_ms45 = lobReg.Ssp_cam030_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam031_ms45)) { G1Ssp_cam031_ms45 = lobReg.Ssp_cam031_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam032_ms45.ToString())) { G1Ssp_cam032_ms45 = lobReg.Ssp_cam032_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam033_ms45)) { G1Ssp_cam033_ms45 = lobReg.Ssp_cam033_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam034_ms45.ToString())) { G1Ssp_cam034_ms45 = lobReg.Ssp_cam034_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam035_ms45)) { G1Ssp_cam035_ms45 = lobReg.Ssp_cam035_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam036_ms45)) { G1Ssp_cam036_ms45 = lobReg.Ssp_cam036_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam037_ms45)) { G1Ssp_cam037_ms45 = lobReg.Ssp_cam037_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam038_ms45)) { G1Ssp_cam038_ms45 = lobReg.Ssp_cam038_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam039_ms45)) { G1Ssp_cam039_ms45 = lobReg.Ssp_cam039_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam040_ms45)) { G1Ssp_cam040_ms45 = lobReg.Ssp_cam040_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam041_ms45)) { G1Ssp_cam041_ms45 = lobReg.Ssp_cam041_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam042_ms45)) { G1Ssp_cam042_ms45 = lobReg.Ssp_cam042_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam043_ms45)) { G1Ssp_cam043_ms45 = lobReg.Ssp_cam043_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam044_ms45)) { G1Ssp_cam044_ms45 = lobReg.Ssp_cam044_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam045_ms45)) { G1Ssp_cam045_ms45 = lobReg.Ssp_cam045_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam046_ms45)) { G1Ssp_cam046_ms45 = lobReg.Ssp_cam046_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam047_ms45)) { G1Ssp_cam047_ms45 = lobReg.Ssp_cam047_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam048_ms45)) { G1Ssp_cam048_ms45 = lobReg.Ssp_cam048_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam049_ms45)) { G1Ssp_cam049_ms45 = lobReg.Ssp_cam049_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam050_ms45)) { G1Ssp_cam050_ms45 = lobReg.Ssp_cam050_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam051_ms45)) { G1Ssp_cam051_ms45 = lobReg.Ssp_cam051_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam052_ms45)) { G1Ssp_cam052_ms45 = lobReg.Ssp_cam052_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam053_ms45)) { G1Ssp_cam053_ms45 = lobReg.Ssp_cam053_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam054_ms45)) { G1Ssp_cam054_ms45 = lobReg.Ssp_cam054_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam055_ms45)) { G1Ssp_cam055_ms45 = lobReg.Ssp_cam055_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam056_ms45)) { G1Ssp_cam056_ms45 = lobReg.Ssp_cam056_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam057_ms45.ToString())) { G1Ssp_cam057_ms45 = lobReg.Ssp_cam057_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam058_ms45)) { G1Ssp_cam058_ms45 = lobReg.Ssp_cam058_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam059_ms45)) { G1Ssp_cam059_ms45 = lobReg.Ssp_cam059_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam060_ms45)) { G1Ssp_cam060_ms45 = lobReg.Ssp_cam060_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam061_ms45)) { G1Ssp_cam061_ms45 = lobReg.Ssp_cam061_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam062_ms45)) { G1Ssp_cam062_ms45 = lobReg.Ssp_cam062_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam063_ms45)) { G1Ssp_cam063_ms45 = lobReg.Ssp_cam063_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam064_ms45)) { G1Ssp_cam064_ms45 = lobReg.Ssp_cam064_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam065_ms45)) { G1Ssp_cam065_ms45 = lobReg.Ssp_cam065_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam066_ms45)) { G1Ssp_cam066_ms45 = lobReg.Ssp_cam066_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam067_ms45)) { G1Ssp_cam067_ms45 = lobReg.Ssp_cam067_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam068_ms45)) { G1Ssp_cam068_ms45 = lobReg.Ssp_cam068_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam069_ms45)) { G1Ssp_cam069_ms45 = lobReg.Ssp_cam069_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam070_ms45)) { G1Ssp_cam070_ms45 = lobReg.Ssp_cam070_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam071_ms45)) { G1Ssp_cam071_ms45 = lobReg.Ssp_cam071_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam072_ms45)) { G1Ssp_cam072_ms45 = lobReg.Ssp_cam072_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam073_ms45)) { G1Ssp_cam073_ms45 = lobReg.Ssp_cam073_ms45.ToShortDateString(); }
                                    if (G1Ssp_cam074_ms45 == 0) { G1Ssp_cam074_ms45 = lobReg.Ssp_cam074_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam075_ms45)) { G1Ssp_cam075_ms45 = lobReg.Ssp_cam075_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam076_ms45)) { G1Ssp_cam076_ms45 = lobReg.Ssp_cam076_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam077_ms45)) { G1Ssp_cam077_ms45 = lobReg.Ssp_cam077_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam078_ms45)) { G1Ssp_cam078_ms45 = lobReg.Ssp_cam078_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam079_ms45)) { G1Ssp_cam079_ms45 = lobReg.Ssp_cam079_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam080_ms45)) { G1Ssp_cam080_ms45 = lobReg.Ssp_cam080_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam081_ms45)) { G1Ssp_cam081_ms45 = lobReg.Ssp_cam081_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam082_ms45)) { G1Ssp_cam082_ms45 = lobReg.Ssp_cam082_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam083_ms45)) { G1Ssp_cam083_ms45 = lobReg.Ssp_cam083_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam084_ms45)) { G1Ssp_cam084_ms45 = lobReg.Ssp_cam084_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam085_ms45)) { G1Ssp_cam085_ms45 = lobReg.Ssp_cam085_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam086_ms45)) { G1Ssp_cam086_ms45 = lobReg.Ssp_cam086_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam087_ms45)) { G1Ssp_cam087_ms45 = lobReg.Ssp_cam087_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam088_ms45)) { G1Ssp_cam088_ms45 = lobReg.Ssp_cam088_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam089_ms45)) { G1Ssp_cam089_ms45 = lobReg.Ssp_cam089_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam090_ms45)) { G1Ssp_cam090_ms45 = lobReg.Ssp_cam090_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam091_ms45)) { G1Ssp_cam091_ms45 = lobReg.Ssp_cam091_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam092_ms45)) { G1Ssp_cam092_ms45 = lobReg.Ssp_cam092_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam093_ms45)) { G1Ssp_cam093_ms45 = lobReg.Ssp_cam093_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam094_ms45)) { G1Ssp_cam094_ms45 = lobReg.Ssp_cam094_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam095_ms45)) { G1Ssp_cam095_ms45 = lobReg.Ssp_cam095_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam096_ms45)) { G1Ssp_cam096_ms45 = lobReg.Ssp_cam096_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam097_ms45)) { G1Ssp_cam097_ms45 = lobReg.Ssp_cam097_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam098_ms45)) { G1Ssp_cam098_ms45 = lobReg.Ssp_cam098_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam099_ms45)) { G1Ssp_cam099_ms45 = lobReg.Ssp_cam099_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam100_ms45)) { G1Ssp_cam100_ms45 = lobReg.Ssp_cam100_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam101_ms45)) { G1Ssp_cam101_ms45 = lobReg.Ssp_cam101_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam102_ms45)) { G1Ssp_cam102_ms45 = lobReg.Ssp_cam102_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam103_ms45)) { G1Ssp_cam103_ms45 = lobReg.Ssp_cam103_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam104_ms45.ToString())) { G1Ssp_cam104_ms45 = lobReg.Ssp_cam104_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam105_ms45)) { G1Ssp_cam105_ms45 = lobReg.Ssp_cam105_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam106_ms45)) { G1Ssp_cam106_ms45 = lobReg.Ssp_cam106_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam107_ms45.ToString())) { G1Ssp_cam107_ms45 = lobReg.Ssp_cam107_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam108_ms45)) { G1Ssp_cam108_ms45 = lobReg.Ssp_cam108_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam109_ms45.ToString())) { G1Ssp_cam109_ms45 = lobReg.Ssp_cam109_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam110_ms45)) { G1Ssp_cam110_ms45 = lobReg.Ssp_cam110_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam111_ms45)) { G1Ssp_cam111_ms45 = lobReg.Ssp_cam111_ms45.ToShortDateString(); }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam112_ms45)) { G1Ssp_cam112_ms45 = lobReg.Ssp_cam112_ms45.ToShortDateString(); }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam113_ms45)) { G1Ssp_cam113_ms45 = lobReg.Ssp_cam113_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam114_ms45)) { G1Ssp_cam114_ms45 = lobReg.Ssp_cam114_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam115_ms45)) { G1Ssp_cam115_ms45 = lobReg.Ssp_cam115_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam116_ms45)) { G1Ssp_cam116_ms45 = lobReg.Ssp_cam116_ms45; }
                                    if (String.IsNullOrWhiteSpace(G1Ssp_cam117_ms45)) { G1Ssp_cam117_ms45 = lobReg.Ssp_cam117_ms45; }
                                    if (!Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam118_ms45)) { G1Ssp_cam118_ms45 = lobReg.Ssp_cam118_ms45.ToShortDateString(); }
                                    #endregion
                                }                                
                                // aqui validacion de todo el registro la primera vez 
                                if (GlgSIS_ValidaEdicion == false)
                                {
                                    GlgSIS_ValidaEdicion = true;
                                    fcvValidarRegistroVista();
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Identificación: No existe";
                            }
                        }
                        break;

                    case "G1Sia_codeps_teps":
                        lcrNombreCampo = "Código Eps/Asegurador";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (string.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            lcrValorReturn = "Código Eps/Asegurador: Es requerido";
                        }
                        else
                        {
                            EFsiatablaeps tmp = new EFsiatablaeps();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codeps_teps))
                            {
                                G1Sia_deseps_teps = tmp.sia_deseps_teps;
                            }
                            else
                            {
                                lcrValorReturn = "Código Eps/Asegurador: No existe";
                            }
                        }
                        break;

                    case "G1Ssp_cam000_ms45":
                        lcrNombreCampo = "0.Tipo De Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E00";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam000_ms45))
                        {
                            lcrValorReturn = "0.Tipo De Registro: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam002_ms45":
                        lcrNombreCampo = "2.Código de Habilitación IPS primaria";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E02";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam002_ms45))
                        {
                            lcrValorReturn = "2.Código de Habilitación IPS primaria: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam003_ms45":
                        lcrNombreCampo = "3.Tipo de identificación del usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E03";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam003_ms45))
                        {
                            lcrValorReturn = "3.Tipo de identificación del usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam004_ms45":
                        lcrNombreCampo = "4.Número de identificación del usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E04";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam004_ms45))
                        {
                            lcrValorReturn = "4.Número de identificación del usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam005_ms45":
                        lcrNombreCampo = "5.Primer apellido del usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E05";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam005_ms45))
                        {
                            lcrValorReturn = "5.Primer apellido del usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam006_ms45":
                        lcrNombreCampo = "6.Segundo apellido del usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E06";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam006_ms45))
                        {
                            lcrValorReturn = "6.Segundo apellido del usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam007_ms45":
                        lcrNombreCampo = "7.Primer nombre del usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E07";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam007_ms45))
                        {
                            lcrValorReturn = "7.Primer nombre del usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam008_ms45":
                        lcrNombreCampo = "8.Segundo nombre del usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E08";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam008_ms45))
                        {
                            lcrValorReturn = "8.Segundo nombre del usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam009_ms45":
                        lcrNombreCampo = "9.Fecha de Nacimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E09";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam009_ms45, "9.Fecha de Nacimiento");
                        break;

                    case "G1Ssp_cam010_ms45":
                        lcrNombreCampo = "10.Sexo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E10";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam010_ms45))
                        {
                            lcrValorReturn = "10.Sexo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam010_ms45, ",", "M,F"))
                            {
                                lcrValorReturn = "10.Sexo: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam011_ms45":
                        lcrNombreCampo = "11.Codigo pertenencia étnica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E11";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam011_ms45))
                        {
                            lcrValorReturn = "11.Codigo pertenencia étnica: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam011_ms45, ",", "1,2,3,4,5,6"))
                            {
                                lcrValorReturn = "11.Codigo pertenencia étnica: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_codocu_ciuo":
                        lcrNombreCampo = "12.Codigo de ocupación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E12";
                        if (string.IsNullOrWhiteSpace(G1Ssp_codocu_ciuo))
                        {
                            lcrValorReturn = "12.Codigo de ocupación: Es requerido";
                        }
                        else
                        {
                            EFspocupacionciuo tmp = new EFspocupacionciuo();
                            tmp = SSPValidarCodigo.fobRegBuscarSpocupacionciuo(G1Ssp_codocu_ciuo);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.ssp_codocu_ciuo))
                            {
                                G1Ssp_desocu_ciuo = tmp.ssp_desocu_ciuo;
                            }
                            else
                            {
                                lcrValorReturn = "12.Codigo de ocupación: No existe";
                            }
                        }
                        break;

                    case "G1Ssp_cam013_ms45":
                        lcrNombreCampo = "13.Codigo de nivel educativo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam013_ms45))
                        {
                            lcrValorReturn = "13.Codigo de nivel educativo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam013_ms45, ",", "1,2,3,4,5,6,7,8,9,10,11,12,13"))
                            {
                                lcrValorReturn = "13.Codigo de nivel educativo: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam014_ms45":
                        lcrNombreCampo = "14.Gestacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam014_ms45))
                        {
                            lcrValorReturn = "14.Gestacion: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam014_ms45, ",", "0,1,2,21"))
                            {
                                lcrValorReturn = "14.Gestacion: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam015_ms45":
                        lcrNombreCampo = "15.Sifilis Gestacional o congénita";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam015_ms45))
                        {
                            lcrValorReturn = "15.Sifilis Gestacional o congénita: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam015_ms45, ",", "0,1,2,3,21"))
                            {
                                lcrValorReturn = "15.Sifilis Gestacional o congénita: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam016_ms45":
                        lcrNombreCampo = "16.Hipertension Inducida por la Gestació";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam016_ms45))
                        {
                            lcrValorReturn = "16.Hipertension Inducida por la Gestación: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam016_ms45, ",", "0,1,2,21"))
                            {
                                lcrValorReturn = "16.Hipertension Inducida por la Gestación: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam017_ms45":
                        lcrNombreCampo = "17.Hipotiroidismo Congénito";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam017_ms45))
                        {
                            lcrValorReturn = "17.Hipotiroidismo Congénito: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam017_ms45, ",", "0,1,2,21"))
                            {
                                lcrValorReturn = "17.Hipotiroidismo Congénito: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam018_ms45":
                        lcrNombreCampo = "18.Sintomatico Respiratorio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam018_ms45))
                        {
                            lcrValorReturn = "18.Sintomatico Respiratorio: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam018_ms45, ",", "1,2,21"))
                            {
                                lcrValorReturn = "18.Sintomatico Respiratorio: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam019_ms45":
                        lcrNombreCampo = "19.Tuberculosis Multidrogoresistente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam019_ms45))
                        {
                            lcrValorReturn = "19.Tuberculosis Multidrogoresistente: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam019_ms45, ",", "0,1,2,21"))
                            {
                                lcrValorReturn = "19.Tuberculosis Multidrogoresistente: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam020_ms45":
                        lcrNombreCampo = "20.Lepra";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam020_ms45))
                        {
                            lcrValorReturn = "20.Lepra: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam020_ms45, ",", "1,2,3,21"))
                            {
                                lcrValorReturn = "20.Lepra: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam021_ms45":
                        lcrNombreCampo = "21.Obesidad o Desnutrición Proteico Caló";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A25";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam021_ms45))
                        {
                            lcrValorReturn = "21.Obesidad o Desnutrición Proteico Caló: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam021_ms45, ",", "1,2,3,21"))
                            {
                                lcrValorReturn = "21.Obesidad o Desnutrición Proteico Caló: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam022_ms45":
                        lcrNombreCampo = "22.Mujer Victima de Maltrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A26";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam022_ms45))
                        {
                            lcrValorReturn = "22.Mujer Victima de Maltrato: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam022_ms45, ",", "0,1,2,3,21"))
                            {
                                lcrValorReturn = "22.Mujer Victima de Maltrato: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam023_ms45":
                        lcrNombreCampo = "23.Victima de Violencia Sexual";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A27";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam023_ms45))
                        {
                            lcrValorReturn = "23.Victima de Violencia Sexual: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam023_ms45, ",", "1,2,21"))
                            {
                                lcrValorReturn = "23.Victima de Violencia Sexual: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam024_ms45":
                        lcrNombreCampo = "24.Infecciones de Trasmisión Sexual";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A28";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam024_ms45))
                        {
                            lcrValorReturn = "24.Infecciones de Trasmisión Sexual: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam024_ms45, ",", "1,2,21"))
                            {
                                lcrValorReturn = "24.Infecciones de Trasmisión Sexual: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam025_ms45":
                        lcrNombreCampo = "25.Enfermedad Mental";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A29";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam025_ms45))
                        {
                            lcrValorReturn = "25.Enfermedad Mental: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam025_ms45, ",", "1,2,3,4,5,6,7,21"))
                            {
                                lcrValorReturn = "25.Enfermedad Mental: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam026_ms45":
                        lcrNombreCampo = "26.Cancer de Cérvix";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A30";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam026_ms45))
                        {
                            lcrValorReturn = "26.Cancer de Cérvix: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam026_ms45, ",", "0,1,2,21"))
                            {
                                lcrValorReturn = "26.Cancer de Cérvix: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam027_ms45":
                        lcrNombreCampo = "27.Cancer de Seno";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A31";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam027_ms45))
                        {
                            lcrValorReturn = "27.Cancer de Seno: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam027_ms45, ",", "1,2,21"))
                            {
                                lcrValorReturn = "27.Cancer de Seno: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam028_ms45":
                        lcrNombreCampo = "28.Fluorosis Dental";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A32";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam028_ms45))
                        {
                            lcrValorReturn = "28.Fluorosis Dental: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam028_ms45, ",", "1,2,21"))
                            {
                                lcrValorReturn = "28.Fluorosis Dental: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam029_ms45":
                        lcrNombreCampo = "29.Fecha del Peso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A33";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam029_ms45, "29.Fecha del Peso");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam029_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);

                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam029_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam029_ms45.ToString(), "ssp_cam029_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "29.Fecha del Peso: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam029_ms45.ToString(), "ssp_cam029_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "29.Fecha del Peso: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam030_ms45":
                        lcrNombreCampo = "30.Peso en Kilogramos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A34";
                        if (string.IsNullOrEmpty(G1Ssp_cam030_ms45.ToString()))
                        {
                            lcrValorReturn = "30.Peso en Kilogramos: Es requerido";
                        }
                        else
                        {
                            if (Funciones.flgSoloNumerosEx(G1Ssp_cam030_ms45.ToString()))
                            {
                                if (G1Ssp_cam030_ms45 >= 1 && G1Ssp_cam030_ms45 < 250)
                                {
                                }
                                else
                                {
                                    if (G1Ssp_cam030_ms45 != 999)
                                    {
                                        lcrValorReturn = "30.Peso en Kilogramos: Debe tener un valor válido";
                                    }
                                }
                            }
                            else 
                            {
                                lcrValorReturn = "30.Peso en Kilogramos: Dato debe ser Numerico";
                            }
                        }
                        break;                        

                    case "G1Ssp_cam031_ms45":
                        lcrNombreCampo = "31.Fecha de la Talla";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A35";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam031_ms45, "31.Fecha de la Talla");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam031_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);

                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam031_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam031_ms45.ToString(), "ssp_cam031_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "31.Fecha de la Talla: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam031_ms45.ToString(), "ssp_cam031_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "31.Fecha de la Talla: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam032_ms45":
                        lcrNombreCampo = "32.Talla en Centímetros";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A36";
                        if (G1Ssp_cam032_ms45 >= 20 && G1Ssp_cam032_ms45 < 225) // entre 20cm y 225cm
                        {
                        }
                        else
                        {
                            if (G1Ssp_cam032_ms45 != 999)
                            {
                                lcrValorReturn = "32.Talla en Centímetros: Debe tener un valor válido";
                            }
                        }
                        break;                        

                    case "G1Ssp_cam033_ms45":
                        lcrNombreCampo = "33.Fecha Probable de Parto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A37";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam033_ms45, "33.Fecha Probable de Parto");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam033_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);

                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam033_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam033_ms45.ToString(), "ssp_cam033_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "33.Fecha Probable de Parto: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam033_ms45.ToString(), "ssp_cam033_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "33.Fecha Probable de Parto: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam034_ms45":
                        lcrNombreCampo = "34.Edad Gestacional al Nacer";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A38";

                        if (string.IsNullOrEmpty(G1Ssp_cam034_ms45.ToString()))
                        {
                            lcrValorReturn = "34.Edad Gestacional al Nacer: Es requerido";
                        }else
                        {
                            if (G1Ssp_cam034_ms45 >= 20 && G1Ssp_cam034_ms45 <= 48) // entre 20 semanas y 48 semanas
                            {
                            }
                            else
                            {
                                if (G1Ssp_cam034_ms45 != 999 && G1Ssp_cam034_ms45 != 0)
                                {
                                    lcrValorReturn = "34.Edad Gestacional al Nacer: Debe tener un valor válido" + G1Ssp_cam034_ms45.ToString();
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam035_ms45":
                        lcrNombreCampo = "35.BCG";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A39";

                        if (string.IsNullOrWhiteSpace(G1Ssp_cam035_ms45))
                        {
                            lcrValorReturn = "35.BCG: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam035_ms45, ",", "0,1,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "35.BCG: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam036_ms45":
                        lcrNombreCampo = "36.Hepatitis B menores de 1 año";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A40";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam036_ms45))
                        {
                            lcrValorReturn = "36.Hepatitis B menores de 1 año: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam036_ms45, ",", "0,1,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "36.Hepatitis B menores de 1 año: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam037_ms45":
                        lcrNombreCampo = "37.Pentavalente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A41";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam037_ms45))
                        {
                            lcrValorReturn = "37.Pentavalente: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam037_ms45, ",", "0,1,2,3,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "37.Pentavalente: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam038_ms45":
                        lcrNombreCampo = "38.Polio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A42";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam038_ms45))
                        {
                            lcrValorReturn = "38.Polio: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam038_ms45, ",", "0,1,2,3,4,5,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "38.Polio: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam039_ms45":
                        lcrNombreCampo = "39.DPT menores de 5 años";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A43";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam039_ms45))
                        {
                            lcrValorReturn = "39.DPT menores de 5 años: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam039_ms45, ",", "0,4,5,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "39.DPT menores de 5 años: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam040_ms45":
                        lcrNombreCampo = "40.Rotavirus";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A44";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam040_ms45))
                        {
                            lcrValorReturn = "40.Rotavirus: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam040_ms45, ",", "0,1,2,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "40.Rotavirus: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam041_ms45":
                        lcrNombreCampo = "41.Neumococo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A45";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam041_ms45))
                        {
                            lcrValorReturn = "41.Neumococo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam041_ms45, ",", "0,1,2,3,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "41.Neumococo: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam042_ms45":
                        lcrNombreCampo = "42.Influenza Niños";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A46";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam042_ms45))
                        {
                            lcrValorReturn = "42.Influenza Niños: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam042_ms45, ",", "0,1,2,3,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "42.Influenza Niños: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam043_ms45":
                        lcrNombreCampo = "43.Fiebre Amarilla niños de 1 año";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A47";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam043_ms45))
                        {
                            lcrValorReturn = "43.Fiebre Amarilla niños de 1 año: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam043_ms45, ",", "0,1,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "43.Fiebre Amarilla niños de 1 año: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam044_ms45":
                        lcrNombreCampo = "44.Hepatitis A";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A48";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam044_ms45))
                        {
                            lcrValorReturn = "44.Hepatitis A: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam044_ms45, ",", "0,1,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "44.Hepatitis A: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam045_ms45":
                        lcrNombreCampo = "45.Triple Viral Niños";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A49";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam045_ms45))
                        {
                            lcrValorReturn = "45.Triple Viral Niños: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam045_ms45, ",", "0,1,2,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "45.Triple Viral Niños: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam046_ms45":
                        lcrNombreCampo = "46.Virus del Papiloma Humano (VPH)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A50";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam046_ms45))
                        {
                            lcrValorReturn = "46.Virus del Papiloma Humano (VPH): Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam046_ms45, ",", "0,1,2,3,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "46.Virus del Papiloma Humano (VPH): Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam047_ms45":
                        lcrNombreCampo = "47.TD o TT Mujeres en Edad Fértil 15 a 4";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A51";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam047_ms45))
                        {
                            lcrValorReturn = "47.TD o TT Mujeres en Edad Fértil 15 a 4: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam047_ms45, ",", "0,1,2,3,4,5,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "47.TD o TT Mujeres en Edad Fértil 15 a 4: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam048_ms45":
                        lcrNombreCampo = "48.Control de Placa Bacteriana";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A52";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam048_ms45))
                        {
                            lcrValorReturn = "48.Control de Placa Bacteriana: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam048_ms45, ",", "0,1,2,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "48.Control de Placa Bacteriana: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam049_ms45":
                        lcrNombreCampo = "49.Fecha atención parto o cesárea";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A53";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam049_ms45, "49.Fecha atención parto o cesárea");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam049_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam049_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam049_ms45.ToString(), "ssp_cam049_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "49.Fecha atención parto o cesárea: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam049_ms45.ToString(), "ssp_cam049_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "49.Fecha atención parto o cesárea: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam050_ms45":
                        lcrNombreCampo = "50.Fecha salida de la atención del parto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A54";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam050_ms45, "50.Fecha salida de la atención del parto");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam050_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam050_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam050_ms45.ToString(), "ssp_cam050_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "50.Fecha salida de la atención del parto: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam050_ms45.ToString(), "ssp_cam050_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "50.Fecha salida de la atención del parto: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam051_ms45":
                        lcrNombreCampo = "51.Fecha de consejería en Lactancia Materna";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A55";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam051_ms45, "51.Fecha de consejería en Lactancia Mate");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam051_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam051_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam051_ms45.ToString(), "ssp_cam051_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "51.Fecha de consejería en Lactancia Materna: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam051_ms45.ToString(), "ssp_cam051_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "51.Fecha de consejería en Lactancia Materna: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }               
                        break;

                    case "G1Ssp_cam052_ms45":
                        lcrNombreCampo = "52.Control Recién Nacido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A56";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam052_ms45, "52.Control Recién Nacido");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam052_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam052_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam052_ms45.ToString(), "ssp_cam052_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "52.Control Recién Nacido: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam052_ms45.ToString(), "ssp_cam052_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "52.Control Recién Nacido: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                   
                        break;

                    case "G1Ssp_cam053_ms45":
                        lcrNombreCampo = "53.Planificacion Familiar Primera vez";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A57";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam053_ms45, "53.Planificacion Familiar Primera vez");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam053_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam053_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam053_ms45.ToString(), "ssp_cam053_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "53.Planificacion Familiar Primera vez: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam053_ms45.ToString(), "ssp_cam053_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "53.Planificacion Familiar Primera vez: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                   
                        break;

                    case "G1Ssp_cam054_ms45":
                        lcrNombreCampo = "54.Suministro de Método Anticonceptivo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A58";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam054_ms45))
                        {
                            lcrValorReturn = "54.Suministro de Método Anticonceptivo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam054_ms45, ",", "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,20,21"))
                            {
                                lcrValorReturn = "54.Suministro de Método Anticonceptivo: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam055_ms45":
                        lcrNombreCampo = "55.Fecha Suministro de Método Anticonceptivo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A59";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam055_ms45, "55.Fecha Suministro de Método Anticoncep");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam055_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam055_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam055_ms45.ToString(), "ssp_cam055_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "55.Fecha Suministro de Método Anticonceptivo: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam055_ms45.ToString(), "ssp_cam055_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "55.Fecha Suministro de Método Anticonceptivo: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                  
                        break;

                    case "G1Ssp_cam056_ms45":
                        lcrNombreCampo = "56.Control Prenatal de Primera vez";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A60";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam056_ms45, "56.Control Prenatal de Primera vez");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam056_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam056_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam056_ms45.ToString(), "ssp_cam056_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "56.Control Prenatal de Primera vez: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam056_ms45.ToString(), "ssp_cam056_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "56.Control Prenatal de Primera vez: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }             
                        break;

                    case "G1Ssp_cam057_ms45":
                        lcrNombreCampo = "57.Control Prenatal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A61";
                        if (G1Ssp_cam057_ms45 >= 0 && G1Ssp_cam057_ms45 <= 10)
                        {
                        }
                        else
                        {
                            if (G1Ssp_cam057_ms45 != 999)
                            {
                                lcrValorReturn = "57.Control Prenatal: Debe tener un valor válido";
                            }
                        }                        
                        break;

                    case "G1Ssp_cam058_ms45":
                        lcrNombreCampo = "58.ultimo Control Prenatal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A62";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam058_ms45, "58.ultimo Control Prenatal");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam058_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam058_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam058_ms45.ToString(), "ssp_cam058_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "58.ultimo Control Prenatal: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam058_ms45.ToString(), "ssp_cam058_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "58.ultimo Control Prenatal: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                  
                        break;

                    case "G1Ssp_cam059_ms45":
                        lcrNombreCampo = "59.Suministro de acido Fólico en el ulti";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A63";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam059_ms45))
                        {
                            lcrValorReturn = "59.Suministro de acido Fólico en el ulti: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam059_ms45, ",", "0,1,16,17,18,19,20,21"))
                            {
                                lcrValorReturn = "59.Suministro de acido Fólico en el ulti: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam060_ms45":
                        lcrNombreCampo = "60.Suministro de Sulfato Ferroso en el u";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A64";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam060_ms45))
                        {
                            lcrValorReturn = "60.Suministro de Sulfato Ferroso en el u: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam060_ms45, ",", "0,1,16,17,18,19,20,21"))
                            {
                                lcrValorReturn = "60.Suministro de Sulfato Ferroso en el u: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam061_ms45":
                        lcrNombreCampo = "61.Suministro de Carbonato de Calcio en";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A65";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam061_ms45))
                        {
                            lcrValorReturn = "61.Suministro de Carbonato de Calcio en: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam061_ms45, ",", "0,1,16,17,18,19,20,21"))
                            {
                                lcrValorReturn = "61.Suministro de Carbonato de Calcio en: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam062_ms45":
                        lcrNombreCampo = "62.Valoracion de la Agudeza Visual";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A66";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam062_ms45, "62.Valoracion de la Agudeza Visual");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam062_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam062_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam062_ms45.ToString(), "ssp_cam062_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "62.Valoracion de la Agudeza Visual: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam062_ms45.ToString(), "ssp_cam062_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "62.Valoracion de la Agudeza Visual: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }               
                        break;

                    case "G1Ssp_cam063_ms45":
                        lcrNombreCampo = "63.Consulta por Oftalmología";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A67";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam063_ms45, "63.Consulta por Oftalmología");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam063_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam063_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam063_ms45.ToString(), "ssp_cam063_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "63.Consulta por Oftalmología: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam063_ms45.ToString(), "ssp_cam063_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "63.Consulta por Oftalmología: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }               
                        break;

                    case "G1Ssp_cam064_ms45":
                        lcrNombreCampo = "64.Fecha Diagnostico Desnutrición Proteico Calórica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A68";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam064_ms45, "64.Fecha Diagnostico Desnutrición Protei");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam064_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam064_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam064_ms45.ToString(), "ssp_cam064_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "64.Fecha Diagnostico Desnutrición Proteico Calórica: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam064_ms45.ToString(), "ssp_cam064_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "64.Fecha Diagnostico Desnutrición Proteico Calórica: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                
                        break;

                    case "G1Ssp_cam065_ms45":
                        lcrNombreCampo = "65.Consulta Mujer o Menor Victima del Maltrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A69";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam065_ms45, "65.Consulta Mujer o Menor Victima del Ma");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam065_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam065_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam065_ms45.ToString(), "ssp_cam065_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "65.Consulta Mujer o Menor Victima del Maltrato: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam065_ms45.ToString(), "ssp_cam065_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "65.Consulta Mujer o Menor Victima del Maltrato: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }          
                        break;

                    case "G1Ssp_cam066_ms45":
                        lcrNombreCampo = "66.Consulta Victimas de Violencia Sexual";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A70";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam066_ms45, "66.Consulta Victimas de Violencia Sexual");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam066_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam066_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam066_ms45.ToString(), "ssp_cam066_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "66.Consulta Victimas de Violencia Sexual: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam066_ms45.ToString(), "ssp_cam066_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "66.Consulta Victimas de Violencia Sexual: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                  
                        break;

                    case "G1Ssp_cam067_ms45":
                        lcrNombreCampo = "67.Consulta Nutrición";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A71";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam067_ms45, "67.Consulta Nutrición");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam067_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam067_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam067_ms45.ToString(), "ssp_cam067_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "67.Consulta Nutrición: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam067_ms45.ToString(), "ssp_cam067_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "67.Consulta Nutrición: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                  
                        break;

                    case "G1Ssp_cam068_ms45":
                        lcrNombreCampo = "68.Consulta de Psicología";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A72";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam068_ms45, "68.Consulta de Psicología");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam068_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam068_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam068_ms45.ToString(), "ssp_cam068_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "68.Consulta de Psicología: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam068_ms45.ToString(), "ssp_cam068_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "68.Consulta de Psicología: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }              
                        break;

                    case "G1Ssp_cam069_ms45":
                        lcrNombreCampo = "69.Consulta de Crecimiento y Desarrollo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A73";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam069_ms45, "69.Consulta de Crecimiento y Desarrollo");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam069_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam069_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam069_ms45.ToString(), "ssp_cam069_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "69.Consulta de Crecimiento y Desarrollo: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam069_ms45.ToString(), "ssp_cam069_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "69.Consulta de Crecimiento y Desarrollo: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                   
                        break;

                    case "G1Ssp_cam070_ms45":
                        lcrNombreCampo = "70.Suministro de Sulfato Ferroso en la u";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A74";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam070_ms45))
                        {
                            lcrValorReturn = "70.Suministro de Sulfato Ferroso en la u: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam070_ms45, ",", "0,1,16,17,18,20,21"))
                            {
                                lcrValorReturn = "70.Suministro de Sulfato Ferroso en la u: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam071_ms45":
                        lcrNombreCampo = "71.Suministro de Vitamina A en la ultima";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A75";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam071_ms45))
                        {
                            lcrValorReturn = "71.Suministro de Vitamina A en la ultima: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam071_ms45, ",", "0,1,16,17,18,20,21"))
                            {
                                lcrValorReturn = "71.Suministro de Vitamina A en la ultima: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam072_ms45":
                        lcrNombreCampo = "72.Consulta de Joven Primera vez";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A76";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam072_ms45, "72.Consulta de Joven Primera vez");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam072_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam072_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam072_ms45.ToString(), "ssp_cam072_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "72.Consulta de Joven Primera vez: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam072_ms45.ToString(), "ssp_cam072_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "72.Consulta de Joven Primera vez: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                  
                        break;

                    case "G1Ssp_cam073_ms45":
                        lcrNombreCampo = "73.Consulta de Adulto Primera vez";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A77";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam073_ms45, "73.Consulta de Adulto Primera vez");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam073_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam073_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam073_ms45.ToString(), "ssp_cam073_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "73.Consulta de Adulto Primera vez: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam073_ms45.ToString(), "ssp_cam073_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "73.Consulta de Adulto Primera vez: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                  
                        break;

                    case "G1Ssp_cam074_ms45":
                        lcrNombreCampo = "74.Preservativos entregados a pacientes";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A78";
                        if (G1Ssp_cam074_ms45 < 0)
                        {
                            lcrValorReturn = "74.Preservativos entregados a pacientes: Debe ser mayor o igual que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam075_ms45":
                        lcrNombreCampo = "75.Asesoria Pre test Elisa para VIH";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A79";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam075_ms45, "75.Asesoria Pre test Elisa para VIH");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam075_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam075_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam075_ms45.ToString(), "ssp_cam075_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "75.Asesoria Pre test Elisa para VIH: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam075_ms45.ToString(), "ssp_cam075_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "75.Asesoria Pre test Elisa para VIH: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                  
                        break;

                    case "G1Ssp_cam076_ms45":
                        lcrNombreCampo = "76.Asesoria Pos test Elisa para VIH";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A80";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam076_ms45, "76.Asesoria Pos test Elisa para VIH");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam076_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam076_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam076_ms45.ToString(), "ssp_cam076_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "76.Asesoria Pos test Elisa para VIH: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam076_ms45.ToString(), "ssp_cam076_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "76.Asesoria Pos test Elisa para VIH: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                
                        break;

                    case "G1Ssp_cam077_ms45":
                        lcrNombreCampo = "77.Paciente con Diagnostico de: Ansiedad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A81";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam077_ms45))
                        {
                            lcrValorReturn = "77.Paciente con Diagnostico de: Ansiedad: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam077_ms45, ",", "0,1,2,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "77.Paciente con Diagnostico de: Ansiedad: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam078_ms45":
                        lcrNombreCampo = "78.Fecha Antigeno de Superficie Hepatitis B en Gestantes";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A82";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam078_ms45, "78.Fecha Antígeno de Superficie Hepatiti");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam078_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam078_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam078_ms45.ToString(), "ssp_cam078_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "78.Fecha Antigeno de Superficie Hepatitis B en Gestantes: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam078_ms45.ToString(), "ssp_cam078_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "78.Fecha Antigeno de Superficie Hepatitis B en Gestantes: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }             
                        break;

                    case "G1Ssp_cam079_ms45":
                        lcrNombreCampo = "79.Resultado Antígeno de Superficie Hepa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A83";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam079_ms45))
                        {
                            lcrValorReturn = "79.Resultado Antígeno de Superficie Hepa: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam079_ms45, ",", "0,1,2,22"))
                            {
                                lcrValorReturn = "79.Resultado Antígeno de Superficie Hepa: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam080_ms45":
                        lcrNombreCampo = "80.Fecha Serología para Sífilis";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A84";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam080_ms45, "80.Fecha Serología para Sífilis");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam080_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam080_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam080_ms45.ToString(), "ssp_cam080_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "80.Fecha Serología para Sífilis: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam080_ms45.ToString(), "ssp_cam080_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "80.Fecha Serología para Sífilis: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }               
                        break;

                    case "G1Ssp_cam081_ms45":
                        lcrNombreCampo = "81.Resultado Serología para Sífilis";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A85";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam081_ms45))
                        {
                            lcrValorReturn = "81.Resultado Serología para Sífilis: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam081_ms45, ",", "0,1,2,22"))
                            {
                                lcrValorReturn = "81.Resultado Serología para Sífilis: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam082_ms45":
                        lcrNombreCampo = "82.Fecha de Toma de Elisa para VIH";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A86";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam082_ms45, "82.Fecha de Toma de Elisa para VIH");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam082_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam082_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam082_ms45.ToString(), "ssp_cam082_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "82.Fecha de Toma de Elisa para VIH: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam082_ms45.ToString(), "ssp_cam082_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "82.Fecha de Toma de Elisa para VIH: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }               
                        break;

                    case "G1Ssp_cam083_ms45":
                        lcrNombreCampo = "83.Resultado Elisa para VIH";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A87";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam083_ms45))
                        {
                            lcrValorReturn = "83.Resultado Elisa para VIH: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam083_ms45, ",", "0,1,2,22"))
                            {
                                lcrValorReturn = "83.Resultado Elisa para VIH: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam084_ms45":
                        lcrNombreCampo = "84.Fecha TSH Neonatal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A88";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam084_ms45, "84.Fecha TSH Neonatal");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam084_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam084_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam084_ms45.ToString(), "ssp_cam084_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "84.Fecha TSH Neonatal: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam084_ms45.ToString(), "ssp_cam084_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "84.Fecha TSH Neonatal: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                
                        break;

                    case "G1Ssp_cam085_ms45":
                        lcrNombreCampo = "85.Resultado de TSH Neonatal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A89";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam085_ms45))
                        {
                            lcrValorReturn = "85.Resultado de TSH Neonatal: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam085_ms45, ",", "0,1,2,22"))
                            {
                                lcrValorReturn = "85.Resultado de TSH Neonatal: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam086_ms45":
                        lcrNombreCampo = "86.Tamizaje Cáncer de Cuello Uterino";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A90";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam086_ms45))
                        {
                            lcrValorReturn = "86.Tamizaje Cáncer de Cuello Uterino: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam086_ms45, ",", "0,1,2,3,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "86.Tamizaje Cáncer de Cuello Uterino: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam087_ms45":
                        lcrNombreCampo = "87.Citologia Cervico uterina";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A91";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam087_ms45, "87.Citologia Cervico uterina");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam087_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam087_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam087_ms45.ToString(), "ssp_cam087_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "87.Citologia Cervico uterina: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam087_ms45.ToString(), "ssp_cam087_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "87.Citologia Cervico uterina: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                
                        break;

                    case "G1Ssp_cam088_ms45":
                        lcrNombreCampo = "88.Citologia Cervico uterina Resultados";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A92";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam088_ms45))
                        {
                            lcrValorReturn = "88.Citologia Cervico uterina Resultados: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam088_ms45, ",", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,999,0"))
                            {
                                lcrValorReturn = "88.Citologia Cervico uterina Resultados: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam089_ms45":
                        lcrNombreCampo = "89.Calidad en la Muestra de Citología Ce";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A93";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam089_ms45))
                        {
                            lcrValorReturn = "89.Calidad en la Muestra de Citología Ce: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam089_ms45, ",", "1,2,3,4,999,0"))
                            {
                                lcrValorReturn = "89.Calidad en la Muestra de Citología Ce: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam090_ms45":
                        lcrNombreCampo = "90.Codigo de habilitación IPS donde se toma Citologia Cervicouterina";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A94";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam090_ms45))
                        {
                            lcrValorReturn = "90.Código de habilitación IPS donde se toma Citologia Cervicouterina: Es requerido";
                        }
                        else
                        {
                            if(!Funciones.flgSoloNumeros(G1Ssp_cam090_ms45))
                            {
                                lcrValorReturn = "90.Codigo de habilitación IPS donde se toma Citologia Cervicouterina: Dato no es númerico";
                            }
                            else
                            {   
                                if (G1Ssp_cam090_ms45.Length > 12)
                                {
                                    lcrValorReturn = "90.Codigo de habilitación IPS donde se toma Citologia Cervicouterina: Dato excede 12 caracteres";
                                }
                                else
                                {
                                    if (G1Ssp_cam090_ms45.Length >= 1 && G1Ssp_cam090_ms45.Length <= 3)
                                    {
                                        if (Convert.ToInt32(G1Ssp_cam090_ms45) != 0 && Convert.ToInt32(G1Ssp_cam090_ms45) != 999)
                                        {
                                            lcrValorReturn = "90.Codigo de habilitación IPS donde se toma Citologia Cervicouterina: Dato no es valido";
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam091_ms45":
                        lcrNombreCampo = "91.Fecha Colposcopia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A95";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam091_ms45, "91.Fecha Colposcopia");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam091_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam091_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam091_ms45.ToString(), "ssp_cam091_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "91.Fecha Colposcopia: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam091_ms45.ToString(), "ssp_cam091_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "91.Fecha Colposcopia: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }               
                        break;

                    case "G1Ssp_cam092_ms45":
                        lcrNombreCampo = "92.Codigo de habilitación IPS donde se toma Colposcopia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A96";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam092_ms45))
                        {
                            lcrValorReturn = "92.Codigo de habilitación IPS donde se toma Colposcopia: Es requerido";
                        }
                        else
                        {
                            if (G1Ssp_cam092_ms45.Length > 12)
                            {
                                lcrValorReturn = "92.Codigo de habilitación IPS donde se toma Colposcopia: Dato excede 12 caracteres";
                            }
                            else
                            {
                                if (G1Ssp_cam092_ms45.Length >= 1 && G1Ssp_cam092_ms45.Length <= 3)
                                {
                                    if (Convert.ToInt32(G1Ssp_cam092_ms45) != 0 && Convert.ToInt32(G1Ssp_cam092_ms45) != 999)
                                    {
                                        lcrValorReturn = "92.Codigo de habilitación IPS donde se toma Colposcopia: Dato no es valido";
                                    }
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam093_ms45":
                        lcrNombreCampo = "93.Fecha Biopsia Cervical";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A97";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam093_ms45, "93.Fecha Biopsia Cervical");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam093_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam093_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam093_ms45.ToString(), "ssp_cam093_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "93.Fecha Biopsia Cervical: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam093_ms45.ToString(), "ssp_cam093_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "93.Fecha Biopsia Cervical: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }             
                        break;

                    case "G1Ssp_cam094_ms45":
                        lcrNombreCampo = "94.Resultado de Biopsia Cervical";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A98";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam094_ms45))
                        {
                            lcrValorReturn = "94.Resultado de Biopsia Cervical: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam094_ms45, ",", "1,2,3,4,5,6,999,0"))
                            {
                                lcrValorReturn = "94.Resultado de Biopsia Cervical: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam095_ms45":
                        lcrNombreCampo = "95.Código de habilitacion IPS donde se toma Biopsia Cervical";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A99";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam095_ms45))
                        {
                            lcrValorReturn = "95.Código de habilitacion IPS donde se toma Biopsia Cervical: Es requerido";
                        }
                        else
                        {
                            if (G1Ssp_cam095_ms45.Length > 12)
                            {
                                lcrValorReturn = "95.Código de habilitacion IPS donde se toma Biopsia Cervical: Dato excede 12 caracteres";
                            }
                            else
                            {
                                if (G1Ssp_cam095_ms45.Length >= 1 && G1Ssp_cam095_ms45.Length <= 3)
                                {
                                    if (Convert.ToInt32(G1Ssp_cam095_ms45) != 0 && Convert.ToInt32(G1Ssp_cam095_ms45) != 999)
                                    {
                                        lcrValorReturn = "95.Código de habilitacion IPS donde se toma Biopsia Cervical: Dato no es valido";
                                    }
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam096_ms45":
                        lcrNombreCampo = "96.Fecha Mamografía";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A100";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam096_ms45, "96.Fecha Mamografía");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam096_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam096_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam096_ms45.ToString(), "ssp_cam096_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "96.Fecha Mamografía: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam096_ms45.ToString(), "ssp_cam096_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "96.Fecha Mamografía: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }               
                        break;

                    case "G1Ssp_cam097_ms45":
                        lcrNombreCampo = "97.Resultado Mamografía";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A101";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam097_ms45))
                        {
                            lcrValorReturn = "97.Resultado Mamografía: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam097_ms45, ",", "1,2,3,4,5,6,7,999,0"))
                            {
                                lcrValorReturn = "97.Resultado Mamografía: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam098_ms45":
                        lcrNombreCampo = "98.Código de habilitacion IPS donde se toma Mamografía";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A102";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam098_ms45))
                        {
                            lcrValorReturn = "98.Código de habilitacion IPS donde se toma Mamografía: Es requerido";
                        }
                        else
                        {
                            if (G1Ssp_cam098_ms45.Length > 12)
                            {
                                lcrValorReturn = "98.Código de habilitacion IPS donde se toma Mamografía: Dato excede 12 caracteres";
                            }
                            else
                            {
                                if (G1Ssp_cam098_ms45.Length >= 1 && G1Ssp_cam098_ms45.Length <= 3)
                                {
                                    if (Convert.ToInt32(G1Ssp_cam098_ms45) != 0 && Convert.ToInt32(G1Ssp_cam098_ms45) != 999)
                                    {
                                        lcrValorReturn = "98.Código de habilitacion IPS donde se toma Mamografía: Dato no es valido";
                                    }
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam099_ms45":
                        lcrNombreCampo = "99.Fecha Toma Biopsia Seno por BACAF";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A103";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam099_ms45, "99.Fecha Toma Biopsia Seno por BACAF");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam099_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam099_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam099_ms45.ToString(), "ssp_cam099_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "99.Fecha Toma Biopsia Seno por BACAF: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam099_ms45.ToString(), "ssp_cam099_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "99.Fecha Toma Biopsia Seno por BACAF: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }           
                        break;

                    case "G1Ssp_cam100_ms45":
                        lcrNombreCampo = "100.Fecha Resultado Biopsia Seno por BACAF";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A104";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam100_ms45, "100.Fecha Resultado Biopsia Seno por BAC");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam100_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam100_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam100_ms45.ToString(), "ssp_cam100_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "100.Fecha Resultado Biopsia Seno por BACAF: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam100_ms45.ToString(), "ssp_cam100_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "100.Fecha Resultado Biopsia Seno por BACAF: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                 
                        break;

                    case "G1Ssp_cam101_ms45":
                        lcrNombreCampo = "101.Biopsia Seno por BACAF";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A105";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam101_ms45))
                        {
                            lcrValorReturn = "101.Biopsia Seno por BACAF: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam101_ms45, ",", "1,2,3,4,5,999,0"))
                            {
                                lcrValorReturn = "101.Biopsia Seno por BACAF: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam102_ms45":
                        lcrNombreCampo = "102.Código de habilitacion IPS donde se toma Biopsia Seno por BACAF";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A106";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam102_ms45))
                        {
                            lcrValorReturn = "102.Código de habilitacion IPS donde se toma Biopsia Seno por BACAF: Es requerido";
                        }
                        else
                        {
                            if (G1Ssp_cam102_ms45.Length > 12)
                            {
                                lcrValorReturn = "102.Código de habilitacion IPS donde se toma Biopsia Seno por BACAF: Dato excede 12 caracteres";
                            }
                            else
                            {
                                if (G1Ssp_cam102_ms45.Length >= 1 && G1Ssp_cam102_ms45.Length <= 3)
                                {
                                    if (Convert.ToInt32(G1Ssp_cam102_ms45) != 0 && Convert.ToInt32(G1Ssp_cam102_ms45) != 999)
                                    {
                                        lcrValorReturn = "102.Código de habilitacion IPS donde se toma Biopsia Seno por BACAF: Dato no es valido";
                                    }
                                }
                            }
                        }
                        break;

                    case "G1Ssp_cam103_ms45":
                        lcrNombreCampo = "103.Fecha Toma de Hemoglobina";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A107";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam103_ms45, "103.Fecha Toma de Hemoglobina");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam103_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam103_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam103_ms45.ToString(), "ssp_cam103_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "103.Fecha Toma de Hemoglobina: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam103_ms45.ToString(), "ssp_cam103_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "103.Fecha Toma de Hemoglobina: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }         
                        break;

                    case "G1Ssp_cam104_ms45":
                        lcrNombreCampo = "104.Hemoglobina";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A108";
                        if (G1Ssp_cam104_ms45 >= 1.5 && G1Ssp_cam104_ms45 <= 20)
                        {
                        }
                        else
                        {
                            if (G1Ssp_cam104_ms45 != 0)
                            {
                                lcrValorReturn = "104.Hemoglobina: Debe tener un valor válido";
                            }
                        }
                        break;

                    case "G1Ssp_cam105_ms45":
                        lcrNombreCampo = "105.Fecha de la Toma de Glicemia Basal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A109";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam105_ms45, "105.Fecha de la Toma de Glicemia Basal");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam105_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam105_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam105_ms45.ToString(), "ssp_cam105_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "105.Fecha de la Toma de Glicemia Basal: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam105_ms45.ToString(), "ssp_cam105_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "105.Fecha de la Toma de Glicemia Basal: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }     
                        break;

                    case "G1Ssp_cam106_ms45":
                        lcrNombreCampo = "106.Fecha Creatinina";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A110";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam106_ms45, "106.Fecha Creatinina");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam106_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam106_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam106_ms45.ToString(), "ssp_cam106_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "106.Fecha Creatinina: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam106_ms45.ToString(), "ssp_cam106_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "106.Fecha Creatinina: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }              
                        break;

                    case "G1Ssp_cam107_ms45":
                        lcrNombreCampo = "107.Creatinina";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A111";
                        if (G1Ssp_cam107_ms45 >= 0.2 && G1Ssp_cam107_ms45 <= 25)
                        {
                        }
                        else
                        {
                            if (G1Ssp_cam107_ms45 != 0 && G1Ssp_cam107_ms45 != 999)
                            {
                                lcrValorReturn = "107.Creatinina: Debe tener un valor válido";
                            }
                        }
                        break;

                    case "G1Ssp_cam108_ms45":
                        lcrNombreCampo = "108.Fecha Hemoglobina Glicosilada";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A112";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam108_ms45, "108.Fecha Hemoglobina Glicosilada");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam108_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam108_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam108_ms45.ToString(), "ssp_cam108_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "108.Fecha Hemoglobina Glicosilada: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam108_ms45.ToString(), "ssp_cam108_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "108.Fecha Hemoglobina Glicosilada: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }                
                        break;

                    case "G1Ssp_cam109_ms45":
                        lcrNombreCampo = "109.Hemoglobina Glicosilada";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A113";
                        if (G1Ssp_cam109_ms45 >= 5 && G1Ssp_cam109_ms45 <= 20)
                        {
                        }
                        else
                        {
                            if (G1Ssp_cam109_ms45 != 0 && G1Ssp_cam109_ms45 != 999)
                            {
                                lcrValorReturn = "109.Hemoglobina Glicosilada: Debe tener un valor válido";
                            }
                        }
                        break;

                    case "G1Ssp_cam110_ms45":
                        lcrNombreCampo = "110.Fecha Toma de Microalbuminuria";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A114";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam110_ms45, "110.Fecha Toma de Microalbuminuria");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam110_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam110_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam110_ms45.ToString(), "ssp_cam110_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "110.Fecha Toma de Microalbuminuria: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam110_ms45.ToString(), "ssp_cam110_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "110.Fecha Toma de Microalbuminuria: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }             
                        break;

                    case "G1Ssp_cam111_ms45":
                        lcrNombreCampo = "111.Fecha Toma de HDL";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A115";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam111_ms45, "111.Fecha Toma de HDL");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam111_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam111_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam111_ms45.ToString(), "ssp_cam111_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "111.Fecha Toma de HDL: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam111_ms45.ToString(), "ssp_cam111_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "111.Fecha Toma de HDL: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }           
                        break;

                    case "G1Ssp_cam112_ms45":
                        lcrNombreCampo = "112.Fecha Toma de Baciloscopia de Diagnostico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A116";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam112_ms45, "112.Fecha Toma de Baciloscopia de Diagno");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam112_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam112_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam112_ms45.ToString(), "ssp_cam112_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "112.Fecha Toma de Baciloscopia de Diagnostico: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam112_ms45.ToString(), "ssp_cam112_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "112.Fecha Toma de Baciloscopia de Diagnostico: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }              
                        break;

                    case "G1Ssp_cam113_ms45":
                        lcrNombreCampo = "113.Baciloscopia de Diagnostico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A117";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam113_ms45))
                        {
                            lcrValorReturn = "113.Baciloscopia de Diagnostico: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam113_ms45, ",", "1,2,3,4,22"))
                            {
                                lcrValorReturn = "113.Baciloscopia de Diagnostico: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam114_ms45":
                        lcrNombreCampo = "114.Tratamiento para Hipotiroidismo Cong";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A118";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam114_ms45))
                        {
                            lcrValorReturn = "114.Tratamiento para Hipotiroidismo Cong: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam114_ms45, ",", "0,1,2,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "114.Tratamiento para Hipotiroidismo Cong: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam115_ms45":
                        lcrNombreCampo = "115.Tratamiento para Sífilis gestacional";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A119";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam115_ms45))
                        {
                            lcrValorReturn = "115.Tratamiento para Sífilis gestacional: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam115_ms45, ",", "0,1,2,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "115.Tratamiento para Sífilis gestacional: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam116_ms45":
                        lcrNombreCampo = "116.Tratamiento para Sífilis Congénita";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A120";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam116_ms45))
                        {
                            lcrValorReturn = "116.Tratamiento para Sífilis Congénita: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam116_ms45, ",", "0,1,2,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "116.Tratamiento para Sífilis Congénita: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam117_ms45":
                        lcrNombreCampo = "117.Tratamiento para Lepra";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A121";
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam117_ms45))
                        {
                            lcrValorReturn = "117.Tratamiento para Lepra: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam117_ms45, ",", "0,1,2,16,17,18,19,20,22"))
                            {
                                lcrValorReturn = "117.Tratamiento para Lepra: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam118_ms45":
                        lcrNombreCampo = "118.Fecha de Terminacion Tratamiento para Leishmaniasis";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A122";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam118_ms45, "118.Fecha de Terminación Tratamiento par");

                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            gdaFechaAtencion = Convert.ToDateTime(G1Ssp_cam118_ms45);
                            gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaIniRes, gdaFechaAtencion);
                            if (gnuDias == 0 || !Funciones.flgValidaFecha("DMY", "/", G1Ssp_cam118_ms45))
                            {
                                lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam118_ms45.ToString(), "ssp_cam118_ms45", gdaFinPeriodo);
                                if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                {
                                    lcrValorReturn = "118.Fecha de Terminacion Tratamiento para Leishmaniasis: Fecha Invalida - " + lcrMsgErrorFecha;
                                }
                            }
                            else
                            {
                                gnuDias = Funciones.fnuCalcularDiasFechas(gdaFechaAtencion, gdaFinPeriodo);
                                if (gnuDias == 0)
                                {
                                    lcrMsgErrorFecha = fcrValidVarDatosCampoTablaFecha(G1Ssp_cam118_ms45.ToString(), "ssp_cam118_ms45", gdaFinPeriodo);
                                    if (!String.IsNullOrEmpty(lcrMsgErrorFecha))
                                    {
                                        lcrValorReturn = "118.Fecha de Terminacion Tratamiento para Leishmaniasis: Fecha es mayor al periodo procesado - " + lcrMsgErrorFecha;
                                    }
                                }
                            }
                        }        
                        break;

                    default:
                        lcrValorReturn = fcrValidacionRel(tcrNombrePropiedad);
                        llgValidDefault = true;
                        break;
                }
                if (llgValidDefault == false)
                {
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacionRel: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacionRel
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override string fcrValidacionRel(string tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            //lcrValorReturn=base.fcrValidacionRel(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "XX":
                        // aqui 
                        break;
                }
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionRel");
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidVarDatosCampoTablaFecha: Validar datos relacionados tipo fecha
        /// <summary>
        /// <para>Validar datos relacionados tipo fecha para actualizar RIPS, RE4505 y otros</para>
        /// </summary>
        public String fcrValidVarDatosCampoTablaFecha(String tcrValor, String tcrNombreCampo, DateTime tdaFechaFinPeriodo)
        {
            var lcrCampo = SISValidarCodigo.fobRegBuscarSisactualizcampIu(tcrNombreCampo);
            var lcrValorReturn = String.Empty;

            if (!String.IsNullOrWhiteSpace(lcrCampo.sis_ranini_siac) && !String.IsNullOrWhiteSpace(tdaFechaFinPeriodo.ToString()))
            {
                if (!Funciones.flgValidarRangoFecha(tcrValor, lcrCampo.sis_ranini_siac, tdaFechaFinPeriodo.ToString()))
                {
                    // Es posible que este en valores permitidos
                    if (!Funciones.flgExisteElemento(tcrValor, ",", lcrCampo.sis_valper_siac))
                    {
                        lcrValorReturn = " Valor no esta dentro del rango " + lcrCampo.sis_ranini_siac + " - " + tdaFechaFinPeriodo.ToString().Remove(14,10);
                    }
                }
            }
            else if (!String.IsNullOrWhiteSpace(lcrCampo.sis_valper_siac))
            {
                if (!Funciones.flgExisteElemento(tcrValor, ",", lcrCampo.sis_valper_siac))
                {
                    lcrValorReturn = " Valor no esta permitido";
                }
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcvValidarRegistroVista: Realiza una validacion general al registro en la vista
        /// <summary>
        /// Realiza una validacion general al registro en la vista
        /// </summary>
        public void fcvValidarRegistroVista()
        {
            GlgSIS_ValidaEdicion = true;
            #region Validacion
            fcrValidacion("G1Ssp_cam001_ms45");
            fcrValidacion("G1Ssp_cam002_ms45");
            fcrValidacion("G1Ssp_cam003_ms45");
            fcrValidacion("G1Ssp_cam004_ms45");
            fcrValidacion("G1Ssp_cam005_ms45");
            fcrValidacion("G1Ssp_cam006_ms45");
            fcrValidacion("G1Ssp_cam007_ms45");
            fcrValidacion("G1Ssp_cam008_ms45");
            fcrValidacion("G1Ssp_cam009_ms45");
            fcrValidacion("G1Ssp_cam010_ms45");
            fcrValidacion("G1Ssp_cam011_ms45");
            fcrValidacion("G1Ssp_codocu_ciuo");
            fcrValidacion("G1Ssp_cam013_ms45");
            fcrValidacion("G1Ssp_cam014_ms45");
            fcrValidacion("G1Ssp_cam015_ms45");
            fcrValidacion("G1Ssp_cam016_ms45");
            fcrValidacion("G1Ssp_cam017_ms45");
            fcrValidacion("G1Ssp_cam018_ms45");
            fcrValidacion("G1Ssp_cam019_ms45");
            fcrValidacion("G1Ssp_cam020_ms45");
            fcrValidacion("G1Ssp_cam021_ms45");
            fcrValidacion("G1Ssp_cam022_ms45");
            fcrValidacion("G1Ssp_cam023_ms45");
            fcrValidacion("G1Ssp_cam024_ms45");
            fcrValidacion("G1Ssp_cam025_ms45");
            fcrValidacion("G1Ssp_cam026_ms45");
            fcrValidacion("G1Ssp_cam027_ms45");
            fcrValidacion("G1Ssp_cam028_ms45");
            fcrValidacion("G1Ssp_cam029_ms45");
            fcrValidacion("G1Ssp_cam030_ms45");
            fcrValidacion("G1Ssp_cam031_ms45");
            fcrValidacion("G1Ssp_cam032_ms45");
            fcrValidacion("G1Ssp_cam033_ms45");
            fcrValidacion("G1Ssp_cam034_ms45");
            fcrValidacion("G1Ssp_cam035_ms45");
            fcrValidacion("G1Ssp_cam036_ms45");
            fcrValidacion("G1Ssp_cam037_ms45");
            fcrValidacion("G1Ssp_cam038_ms45");
            fcrValidacion("G1Ssp_cam039_ms45");
            fcrValidacion("G1Ssp_cam040_ms45");
            fcrValidacion("G1Ssp_cam041_ms45");
            fcrValidacion("G1Ssp_cam042_ms45");
            fcrValidacion("G1Ssp_cam043_ms45");
            fcrValidacion("G1Ssp_cam044_ms45");
            fcrValidacion("G1Ssp_cam045_ms45");
            fcrValidacion("G1Ssp_cam046_ms45");
            fcrValidacion("G1Ssp_cam047_ms45");
            fcrValidacion("G1Ssp_cam048_ms45");
            fcrValidacion("G1Ssp_cam049_ms45");
            fcrValidacion("G1Ssp_cam050_ms45");
            fcrValidacion("G1Ssp_cam051_ms45");
            fcrValidacion("G1Ssp_cam052_ms45");
            fcrValidacion("G1Ssp_cam053_ms45");
            fcrValidacion("G1Ssp_cam054_ms45");
            fcrValidacion("G1Ssp_cam055_ms45");
            fcrValidacion("G1Ssp_cam056_ms45");
            fcrValidacion("G1Ssp_cam057_ms45");
            fcrValidacion("G1Ssp_cam058_ms45");
            fcrValidacion("G1Ssp_cam059_ms45");
            fcrValidacion("G1Ssp_cam060_ms45");
            fcrValidacion("G1Ssp_cam061_ms45");
            fcrValidacion("G1Ssp_cam062_ms45");
            fcrValidacion("G1Ssp_cam063_ms45");
            fcrValidacion("G1Ssp_cam064_ms45");
            fcrValidacion("G1Ssp_cam065_ms45");
            fcrValidacion("G1Ssp_cam066_ms45");
            fcrValidacion("G1Ssp_cam067_ms45");
            fcrValidacion("G1Ssp_cam068_ms45");
            fcrValidacion("G1Ssp_cam069_ms45");
            fcrValidacion("G1Ssp_cam070_ms45");
            fcrValidacion("G1Ssp_cam071_ms45");
            fcrValidacion("G1Ssp_cam072_ms45");
            fcrValidacion("G1Ssp_cam073_ms45");
            fcrValidacion("G1Ssp_cam074_ms45");
            fcrValidacion("G1Ssp_cam075_ms45");
            fcrValidacion("G1Ssp_cam076_ms45");
            fcrValidacion("G1Ssp_cam077_ms45");
            fcrValidacion("G1Ssp_cam078_ms45");
            fcrValidacion("G1Ssp_cam079_ms45");
            fcrValidacion("G1Ssp_cam080_ms45");
            fcrValidacion("G1Ssp_cam081_ms45");
            fcrValidacion("G1Ssp_cam082_ms45");
            fcrValidacion("G1Ssp_cam083_ms45");
            fcrValidacion("G1Ssp_cam084_ms45");
            fcrValidacion("G1Ssp_cam085_ms45");
            fcrValidacion("G1Ssp_cam086_ms45");
            fcrValidacion("G1Ssp_cam087_ms45");
            fcrValidacion("G1Ssp_cam088_ms45");
            fcrValidacion("G1Ssp_cam089_ms45");
            fcrValidacion("G1Ssp_cam090_ms45");
            fcrValidacion("G1Ssp_cam091_ms45");
            fcrValidacion("G1Ssp_cam092_ms45");
            fcrValidacion("G1Ssp_cam093_ms45");
            fcrValidacion("G1Ssp_cam094_ms45");
            fcrValidacion("G1Ssp_cam095_ms45");
            fcrValidacion("G1Ssp_cam096_ms45");
            fcrValidacion("G1Ssp_cam097_ms45");
            fcrValidacion("G1Ssp_cam098_ms45");
            fcrValidacion("G1Ssp_cam099_ms45");
            fcrValidacion("G1Ssp_cam100_ms45");
            fcrValidacion("G1Ssp_cam101_ms45");
            fcrValidacion("G1Ssp_cam102_ms45");
            fcrValidacion("G1Ssp_cam103_ms45");
            fcrValidacion("G1Ssp_cam104_ms45");
            fcrValidacion("G1Ssp_cam105_ms45");
            fcrValidacion("G1Ssp_cam106_ms45");
            fcrValidacion("G1Ssp_cam107_ms45");
            fcrValidacion("G1Ssp_cam108_ms45");
            fcrValidacion("G1Ssp_cam109_ms45");
            fcrValidacion("G1Ssp_cam110_ms45");
            fcrValidacion("G1Ssp_cam111_ms45");
            fcrValidacion("G1Ssp_cam112_ms45");
            fcrValidacion("G1Ssp_cam113_ms45");
            fcrValidacion("G1Ssp_cam114_ms45");
            fcrValidacion("G1Ssp_cam115_ms45");
            fcrValidacion("G1Ssp_cam116_ms45");
            fcrValidacion("G1Ssp_cam117_ms45");
            fcrValidacion("G1Ssp_cam118_ms45");
            #endregion
        }
        #endregion

    }
}
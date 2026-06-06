//- MARMOTA-GENCODE: VERSION 2.0 - 18/09/2014 09:50:18 PM
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
    public class VistaModeloGestionValidacion : VistaModeloGestionValidacionBase
    {
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
        public override string fcrValidacion(String tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgValidDefault = false;

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Sis_secreg_siva":
                        lcrNombreCampo = "Codigo plantilla";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (string.IsNullOrWhiteSpace(G2Sis_secreg_siva))
                        {
                            lcrValorReturn = "Codigo plantilla: Es requerido";
                        }
                        else
                        {
                            EFsismaesplavalid tmp = new EFsismaesplavalid();
                            tmp = SISValidarCodigo.fobRegBuscarSismaesplavalid(G2Sis_secreg_siva);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_secreg_siva))
                            {
                                G2Sis_despla_siva = tmp.sis_despla_siva;
                            }
                            else
                            {
                                lcrValorReturn = "Codigo plantilla: No existe";
                            }
                        }
                        break;

                    case "G2Ssp_codper_peri":
                        lcrNombreCampo = "Código de periodo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (string.IsNullOrWhiteSpace(G1Ssp_codper_peri))
                        {
                            lcrValorReturn = "Código de periodo: Es requerido";
                        }
                        else
                        {
                            EFsptablaperiodos tmp = new EFsptablaperiodos();
                            tmp = SSPValidarCodigo.fobRegBuscarSptablaperiodos(G1Ssp_codper_peri);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.ssp_codper_peri))
                            {
                                G2Ssp_desper_peri = tmp.ssp_desper_peri;
                                G2Ssp_fecini_peri = Funciones.fcrConvertFecha((DateTime)tmp.ssp_fecini_peri);
                                G2Ssp_fecfin_peri = Funciones.fcrConvertFecha((DateTime)tmp.ssp_fecfin_peri);
                                fcvGenerarNombreArchivoDestino();
                            }
                            else
                            {
                                lcrValorReturn = "Código de periodo: No existe";
                            }
                        }
                        break;

                    case "G2Sia_codeps_teps":
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (string.IsNullOrWhiteSpace(G2Sia_codeps_teps))
                        {
                            lcrValorReturn = "Código EPS: Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatablaepsEx(G1Sia_codeps_teps);
                            if (tmp != null)
                            {
                                G2Sia_deseps_teps = tmp.sia_deseps_teps;
                                fcvGenerarNombreArchivoDestino();
                            }
                            else
                            {
                                lcrValorReturn = "Código EPS: No existe";
                            }
                        }
                        break;

                    case "G2Sia_codeps_carg":
                        lcrNombreCampo = "Código EPS desde archivo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (!string.IsNullOrWhiteSpace(G2Sia_codeps_carg))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatablaepsEx(G2Sia_codeps_carg);
                            if (tmp != null)
                            {
                                G2Sia_deseps_carg = tmp.sia_deseps_teps;
                                fcvGenerarNombreArchivoDestino();
                            }
                        }
                        break;

                    case "G2Ssp_regims_sgss":
                        lcrNombreCampo = "Código regimen salud";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (!string.IsNullOrWhiteSpace(G2Ssp_regims_sgss))
                        {
                            fcvGenerarNombreArchivoDestino();
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
                    case "G1Ssp_codper_peri":
                        lcrNombreCampo = "Código del periodo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B02";
                        if (string.IsNullOrWhiteSpace(G2Ssp_codper_peri))
                        {
                            lcrValorReturn = "Código del periodo: Es requerido";
                        }
                        else
                        {
                            EFsptablaperiodos tmp = new EFsptablaperiodos();
                            tmp = SSPValidarCodigo.fobRegBuscarSptablaperiodos(G2Ssp_codper_peri);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.ssp_codper_peri))
                            {
                                G1Ssp_desper_peri = tmp.ssp_desper_peri;
                                G1Ssp_mesper_peri = tmp.ssp_mesper_peri;
                                G1Ssp_anoper_peri = tmp.ssp_anoper_peri;
                            }
                            else
                            {
                                lcrValorReturn = "Código del periodo: No existe";
                            }
                        }
                        break;

                    case "G2Ssp_llaper_ns45":
                        lcrNombreCampo = "Llave del periodo (año+mes)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        if (string.IsNullOrWhiteSpace(G1Ssp_llaper_ns45))
                        {
                            lcrValorReturn = "Llave del periodo (año+mes): Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G2Ssp_llaloc_ns45":
                        lcrNombreCampo = "Llave del periodo (año+mes)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (string.IsNullOrWhiteSpace(G1Ssp_llaloc_ns45))
                        {
                            lcrValorReturn = "Llave del periodo (año+mes): Es requerido";
                        }
                        else
                        {
                            EFsptablnsres4505 tmp = new EFsptablnsres4505();
                            tmp = SSPValidarCodigo.fobRegBuscarSptablnsres4505(G1Ssp_llaloc_ns45);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.ssp_idesec_ns45))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = "Llave del periodo (año+mes): Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G1Ssp_idesec_ns45 != tmp.ssp_idesec_ns45) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = "Llave del periodo (año+mes): Ya existe en Base de Datos";
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    case "G2Ssp_codocu_ciuo":
                        lcrNombreCampo = "12.Codigo de ocupación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B22";
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
        //-------------------------------------------------
        // fcvGenerarNombreArchivoDestino: Generar Nombre archivo destino
        //-------------------------------------------------
        #region fcvGenerarNombreArchivoDestino: Generar el nombre del archivo destino
        /// <summary>
        /// <para>Generar el nombre del archivo destino</para>
        /// </summary>
        private void fcvGenerarNombreArchivoDestino()
        {
            if (!String.IsNullOrWhiteSpace(G2Ssp_fecfin_peri))
            {
                var lcrAño = Funciones.fcrElementoFecha("AÑO", "DMY", "/", G2Ssp_fecfin_peri);
                var lcrMes = Funciones.fcrElementoFecha("MES", "DMY", "/", G2Ssp_fecfin_peri);
                var lcrDia = Funciones.fcrElementoFecha("DIA", "DMY", "/", G2Ssp_fecfin_peri);

                G2ArchivoDestino = "SGD280RPED" + lcrAño + lcrMes + lcrDia + "NI" + G2Ssp_nitips_sscf + G2Ssp_regims_sgss + "01";
            }
        }
        #endregion
    }
}
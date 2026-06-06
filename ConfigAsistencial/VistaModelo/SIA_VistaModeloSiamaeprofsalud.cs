//- MARMOTA-GENCODE: VERSION 2.0 - 11/04/2015 08:40:29 AM
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
using ConfigAsistencial.Modelo;

namespace ConfigAsistencial.VistaModelo
{
    /// <summary>
    /// <para>TABLA: siamaeprofsalud</para>
    /// <para>DESCRIPCION:
    /// Lista de profesionales que prestan servicio de salud
    /// </para>
    /// </summary>
    public class VistaModeloSiamaeprofsalud : VistaModeloSiamaeprofsaludBase
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
        public override string fcrValidacion(string tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgValidDefault = false;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Sia_tipide_tide":
                        #region SIA_TIPIDE_TIDE: Tipo Identificación
                        lcrNombreCampo = "Tipo Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Sia_tipide_tide))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            EFsiatipideusario tmp = new EFsiatipideusario();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatipideusario(G1Sia_tipide_tide);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipide_tide))
                            {
                                G1Sia_deside_tide = tmp.sia_deside_tide;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Nom_nroide_nomi":
                        #region NOM_NROIDE_NOMI: Identificación
                        lcrNombreCampo = "Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Nom_nroide_nomi))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sia_rmedic_prof":
                        #region SIA_RMEDIC_PROF: Registro medico
                        lcrNombreCampo = "Registro medico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Sia_rmedic_prof))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Sia_nompro_prof))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_nompro_prof":
                        #region SIA_NOMPRO_PROF: Nombre del Profesional
                        lcrNombreCampo = "Nombre del Profesional";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Sia_nompro_prof))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Sia_nompro_prof = G1Sia_nompro_prof.ToUpper();
                            if (!Funciones.flgSoloTexto("AN", G1Sia_nompro_prof))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codprm_prom":
                        #region SIA_CODPRM_PROM: Profesión salud
                        lcrNombreCampo = "Profesión salud";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Sia_codprm_prom))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            EFsiaprofesisalud tmp = new EFsiaprofesisalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaprofesisalud(G1Sia_codprm_prom);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codprm_prom))
                            {
                                G1Sia_desprm_prom = tmp.sia_desprm_prom;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codpat_tpat":
                        #region SIA_CODPAT_TPAT: Tipo de profesional
                        lcrNombreCampo = "Tipo de profesional";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Sia_codpat_tpat))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatipprofatien(G1Sia_codpat_tpat);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codpat_tpat))
                            {
                                G1Sia_despat_tpat = tmp.sia_despat_tpat;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_idterc_sitr":
                        #region Sis_idterc_sitr: Código tercero (contable)
                        lcrNombreCampo = "Código tercero (contable)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Sis_idterc_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSismaesterceros(G1Sis_idterc_sitr);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_razsoc_sitr))
                            {
                                G1Sis_razsoc_sitr = tmp.sis_razsoc_sitr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sys_codusu_usux":
                        #region SYS_CODUSU_USUX: código usuario sistema
                        lcrNombreCampo = "código usuario sistema";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Sys_codusu_usux))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SYSValidarCodigo.fobRegBuscarSysusuarios(G1Sys_codusu_usux);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sys_codusu_usux))
                            {
                                G1Sys_nomusu_usux = tmp.sys_nomusu_usux;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_estreg_esrg":
                        #region SIS_ESTREG_ESRG: Estado
                        lcrNombreCampo = "Estado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Sis_estreg_esrg))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sis_estreg_esrg, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

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
                    case "G2Sia_codesp_esme":
                        #region SIA_CODESP_ESME: Código especialidad
                        lcrNombreCampo = "Código especialidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";
                        if (String.IsNullOrWhiteSpace(G2Sia_codesp_esme))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            EFsiaespecialimed tmp = new EFsiaespecialimed();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaespecialimed(G2Sia_codesp_esme);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codesp_esme))
                            {
                                G2Sia_desesp_esme = tmp.sia_desesp_esme;
                                G2Sis_estreg_esrg = tmp.sis_estreg_esrg;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Sis_estreg_esrg":
                        #region SIS_ESTREG_ESRG: Estado
                        lcrNombreCampo = "Estado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        if (String.IsNullOrWhiteSpace(G2Sis_estreg_esrg))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Sis_estreg_esrg, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

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
    }
}
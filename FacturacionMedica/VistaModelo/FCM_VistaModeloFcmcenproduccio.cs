//- MARMOTA-GENCODE: VERSION 2.0 - 28/04/2015 03:43:30 PM
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
using FacturacionMedica.Modelo;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: fcmcenproduccio</para>
    /// <para>DESCRIPCION:
    ///  Centros de produccion, existentes en las diferentes areas de
    ///  prestacion de servicios medicos ejm : 1110 = Consulta Médica
    ///  General   1145 = Consulta de Nutrición (esta tabla pertenece
    ///  a facturacion)
    /// </para>
    /// </summary>
    public class VistaModeloFcmcenproduccio : VistaModeloFcmcenproduccioBase
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

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Fcm_descpr_cpro":
                        #region FCM_DESCPR_CPRO: Nombre centro producción
                        lcrNombreCampo = "Nombre centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Fcm_descpr_cpro))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Fcm_descpr_cpro = G1Fcm_descpr_cpro.ToUpper();
                            if (G1Fcm_descpr_cpro.Trim().Length <= 10)
                            {
                                lcrValorReturn = lcrNombreCampo + ": No es valido pocos caracteres(" + G1Fcm_descpr_cpro.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Fcm_descpr_cpro, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ0123456789.-() "))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                                }
                            }

                        }
                        break;
                        #endregion

                    case "G1Sia_codare_aser":
                        #region SIA_CODARE_ASER: Código área de servicios
                        lcrNombreCampo = "Código área de servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Sia_codare_aser))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G1Sia_codare_aser);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codare_aser))
                            {
                                G1Sia_desare_aser = tmp.sia_desare_aser;
                                //G1Con_codafu_afun = tmp.con_codafu_afun;
                                //G1Sia_codcat_ceat = tmp.sia_codcat_ceat;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Con_codafu_afun":
                        #region CON_CODAFU_AFUN: Código área funcional
                        lcrNombreCampo = "Código área funcional";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Con_codafu_afun))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = CONValidarCodigo.fobRegBuscarConareasfuncion(G1Con_codafu_afun);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.con_codafu_afun))
                            {
                                G1Con_desafu_afun = tmp.con_desafu_afun;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codcat_ceat":
                        #region SIA_CODCAT_CEAT: Código centro atención
                        lcrNombreCampo = "Código centro atención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Sia_codcat_ceat))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiacentroaten(G1Sia_codcat_ceat);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codcat_ceat))
                            {
                                G1Sia_descat_ceat = tmp.sia_descat_ceat;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Con_codsco_ccos":
                        #region CON_CODSCO_CCOS: Código centro de costo
                        lcrNombreCampo = "Código centro de costo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Con_codsco_ccos))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = CONValidarCodigo.fobRegBuscarConcentrodcosto(G1Con_codsco_ccos);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.con_codsco_ccos))
                            {
                                G1Con_dessco_ccos = tmp.con_dessco_ccos;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_genhis_cpro":
                        #region FCM_GENHIS_CPRO: Registrar actividad
                        lcrNombreCampo = "Generar actividad en historia clinica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Fcm_genhis_cpro))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_genhis_cpro, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else if (G1Fcm_genhis_cpro=="2")
                            {
                                G1Hcl_codreg_hcca = !String.IsNullOrWhiteSpace(G1Hcl_codreg_hcca) ? G1Hcl_codreg_hcca : "NA";
                                G1Grp_idepla_grpl = !String.IsNullOrWhiteSpace(G1Grp_idepla_grpl) ? G1Grp_idepla_grpl : "NA";
                            }
                        }
                        break;
                        #endregion

                    case "G1Grp_idepla_grpl":
                        #region GRP_IDEPLA_GRPL: Código único plantilla
                        lcrNombreCampo = "Código plantilla actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Grp_idepla_grpl))
                        {
                            if (G1Fcm_genhis_cpro == "1")
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                            else 
                            {
                                G1Grp_idepla_grpl = "NA";
                            }
                        }
                        else
                        {
                            var tmp = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(G1Grp_idepla_grpl);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.grp_idepla_grpl))
                            {
                                G1Grp_despla_grpl = tmp.grp_despla_grpl;
                            }
                            else
                            {
                                if (G1Grp_idepla_grpl == "NA" && G1Fcm_genhis_cpro == "1")
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Debe escribir un código de plantilla valido.";
                                }
                                else if (G1Hcl_codreg_hcca != "NA")
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe, valor permitido cuando no exista es 'NA'";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_codreg_hcca":
                        #region HCL_CODREG_HCCA: Tipo Registro actividad
                        lcrNombreCampo = "Tipo Registro actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Hcl_codreg_hcca))
                        {
                            if (G1Fcm_genhis_cpro == "1")
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                            else
                            {
                                G1Hcl_codreg_hcca = "NA";
                            }
                        }
                        else
                        {
                            var tmp = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(G1Hcl_codreg_hcca);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hcl_codreg_hcca))
                            {
                                G1Hcl_desreg_hcca = tmp.hcl_desreg_hcca;
                                G1Grp_idepla_grpl = !String.IsNullOrWhiteSpace(G1Grp_idepla_grpl) ? G1Grp_idepla_grpl : tmp.grp_idepla_grpl;
                            }
                            else
                            {
                                if (G1Hcl_codreg_hcca != "NA")
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe, valor permitido cuando no exista es 'NA'";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_idesec_sips":
                        #region FCM_IDESEC_SIPS: Código servicio IPS
                        lcrNombreCampo = "Código servicio IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Fcm_idesec_sips))
                        {
                            if (G1Fcm_genhis_cpro == "1")
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                            else
                            {
                                G1Fcm_coddig_mant = String.Empty;
                            }
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G1Fcm_idesec_sips);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_idesec_sips))
                            {
                                G1Fcm_coddig_mant = tmp.fcm_coddig_mant;
                                G1Fcm_desser_sips = tmp.fcm_desser_sips;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_coddig_mant":
                        #region FCM_CODDIG_MANT: Código digitación servicio
                        lcrNombreCampo = "Código digitación servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (G1Fcm_genhis_cpro == "1")
                        {
                            if (String.IsNullOrWhiteSpace(G1Fcm_coddig_mant))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_estreg_esrg":
                        #region SIS_ESTREG_ESRG: Estado centro producción
                        lcrNombreCampo = "Estado centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
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

                }
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 22/03/2015 11:09:16 AM
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
    /// <para>TABLA: fcmmanservicips</para>
    /// <para>DESCRIPCION:
    ///  Maestro de servicios habilitados para la IPS, contiene la validacion
    ///  de pertinencia, tipo de servicio RIPS, configuracion general
    ///  del servicio (sexo al que aplica edad y otros)
    /// </para>
    /// </summary>
    public class VistaModeloFcmManualdeserviciosIPS : VistaModeloFcmManualdeserviciosIPSBase
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

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Fcm_codser_sips":
                        #region FCM_CODSER_SIPS: Código servicio en tarifario
                        lcrNombreCampo = "Código servicio en tarifario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codser_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            EFfcmmanservicips tmp = new EFfcmmanservicips();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G1Fcm_codser_sips);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.fcm_idesec_sips))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = "Código servicio en tarifario: Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G1Fcm_idesec_sips != tmp.fcm_idesec_sips) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = "Código servicio en tarifario: Ya existe en Base de Datos";
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codser_soat":
                        #region FCM_CODSER_SOAT: Codigo SOAT
                        lcrNombreCampo = "Codigo SOAT";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codser_soat))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (G1Fcm_codser_soat != "NA")
                            {
                                var tmp = FCMValidarCodigo.fobRegBuscarFcmsoatmanualma(G1Fcm_codser_soat);
                                if (tmp != null)
                                {
                                    G1Fcm_desman_soat = tmp.fcm_desman_soat;
                                    G1Fcm_punuvr_sips = (float)tmp.fcm_punuvr_sips;
                                    G1Fcm_valser_sips = (float)tmp.fcm_valser_sips;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                            else
                            {
                                G1Fcm_desman_soat = String.Empty;
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_coddig_mant":
                        #region FCM_CODDIG_MANT: Código digitación servicio
                        lcrNombreCampo = "Código digitación servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Fcm_coddig_mant))
                        {
                            lcrValorReturn = "Código digitación servicio: Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(G1Fcm_coddig_mant);
                            if (tmp != null)
                            {
                                G1Fcm_coddig_mant = G1Fcm_coddig_mant.ToUpper();

                                if (!String.IsNullOrWhiteSpace(tmp.fcm_idesec_sips))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = "Código digitación servicio: Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G1Fcm_idesec_sips != tmp.fcm_idesec_sips) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = "Código digitación servicio: Ya existe en Base de Datos para algún servicio";
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codbar_sips":
                        #region FCM_CODBAR_SIPS: Código de Barras
                        lcrNombreCampo = "Código de Barras";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";

                        if (!string.IsNullOrWhiteSpace(G1Fcm_codbar_sips))
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Fcm_codbar_sips))
                            {
                                lcrValorReturn = "Código de Barras: Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codcum_sips":
                        #region FCM_CODCUM_SIPS: Código CUM
                        lcrNombreCampo = "Código CUM";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06X";
                        if (!string.IsNullOrWhiteSpace(G1Fcm_codcum_sips))
                        {                           
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Fcm_codcum_sips, "1234567890-"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no permitidos";
                            }
                        }                        
                        break;
                    #endregion

                    case "G1Fcm_idesec_fcct":
                        #region FCM_IDESEC_FCCT: Código categoria
                        lcrNombreCampo = "Código categoria";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A70";
                        if (String.IsNullOrWhiteSpace(G1Fcm_idesec_fcct))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicate(G1Fcm_idesec_fcct);
                            if (tmp != null)
                            {
                                G1Fcm_descat_fcct = tmp.fcm_descat_fcct;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_desser_sips":
                        #region FCM_DESSER_SIPS: Nombre servicio
                        lcrNombreCampo = "Nombre servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Fcm_desser_sips))
                        {
                            lcrValorReturn = "Nombre servicio: Es requerido";
                        }
                        else
                        {
                            G1Fcm_desser_sips = G1Fcm_desser_sips.ToUpper();
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Fcm_desser_sips, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789%()./+ "))
                            {
                                lcrValorReturn = lcrValorReturn + ": Contiene caracteres no permitidos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codtse_sips":
                        #region FCM_CODTSE_SIPS: Tipo procedimientos o servicios
                        lcrNombreCampo = "Tipo procedimientos o servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";

                        if (String.IsNullOrWhiteSpace(G1Fcm_codtse_sips))
                        {
                            lcrValorReturn = "Tipo procedimientos o servicios: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_codtse_sips, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = "Tipo procedimientos o servicios: Dato no es valido";
                            }
                            if (glgSIS_ControlRipsAP == true && G1Fcm_codtse_sips == "4")
                            {
                                lcrValorReturn = "Tipo procedimientos o servicios: valor (4) no es valido para Rips procedimiento";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_claser_sips":
                        #region FCM_CLASER_SIPS: Clasificación servicio
                        lcrNombreCampo = "Clasificación servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Fcm_claser_sips))
                        {
                            lcrValorReturn = "Clasificación servicio: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_claser_sips, ",", "1,2,3,4,5,6,7"))
                            {
                                lcrValorReturn = "Clasificación servicio: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_punuvr_sips":
                        #region FCM_PUNUVR_SIPS: Puntaje o UVR
                        lcrNombreCampo = "Puntaje o UVR";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        /*
                        if (G1Fcm_punuvr_sips <= 0)
                        {
                            lcrValorReturn = "Puntaje o UVR: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_punuvr_sips < 0 || G1Fcm_punuvr_sips > 999)
                            {
                                lcrValorReturn = "Puntaje o UVR: Valor fuera del rango";
                            }
                        }
                        */
                        break;
                        #endregion

                    case "G1Fcm_valser_sips":
                        #region FCM_VALSER_SIPS: Valor de servicio
                        lcrNombreCampo = "Valor de servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (G1Fcm_valser_sips <= 0)
                        {
                            lcrValorReturn = "Valor del servicio: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_codser_soat == "NA")
                            {
                                if (G1Fcm_valser_sips < 0 || G1Fcm_valser_sips > 999999999)
                                {
                                    lcrValorReturn = "Valor de servicio: Valor fuera del rango";
                                }
                                if (G1Sis_valdia_tsal > 0)
                                {
                                    G1Fcm_punuvr_sips = G1Fcm_valser_sips / G1Sis_valdia_tsal;
                                }
                                else if (gflOldValorServicio > 0 && G1Fcm_valser_sips != gflOldValorServicio)
                                {
                                    lcrValorReturn = "Valor de servicio: debe seleccionar salario mensual vigente para calcular puntaje";
                                }
                                else if (GlgSIS_ModoAdicion == true && G1Sis_valdia_tsal <= 0)
                                {
                                    lcrValorReturn = "Valor de servicio: debe seleccionar salario mensual vigente para calcular puntaje";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_edtval_sips":
                        #region FCM_EDTVAL_SIPS: Editar valor servicio
                        lcrNombreCampo = "Editar valor servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Fcm_edtval_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_edtval_sips, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_lamccp_sips":
                        #region FCM_LAMCCP_SIPS: Ambulatoria Copago C.moderad
                        lcrNombreCampo = "Copago o cuota moderadora en ambulatoria ";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Fcm_lamccp_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_lamccp_sips, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_lhoccp_sips":
                        #region FCM_LHOCCP_SIPS: Hospitalización Copago C.moderad
                        lcrNombreCampo = "Copago o cuota moderadora en Hospitalización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Fcm_lhoccp_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_lhoccp_sips, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_luoccp_sips":
                        #region FCM_LUOCCP_SIPS: Urgencias Copago C.moderad
                        lcrNombreCampo = "Copago o cuota moderadora en Urgencias";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (String.IsNullOrWhiteSpace(G1Fcm_luoccp_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_luoccp_sips, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codcpr_cpro":
                        #region FCM_CODCPR_CPRO: Código centro producción
                        lcrNombreCampo = "Código centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codcpr_cpro))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(G1Fcm_codcpr_cpro);
                            if (tmp != null)
                            {
                                G1Fcm_descpr_cpro = tmp.fcm_descpr_cpro;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codfpr_fpro":
                        #region SIA_CODFPR_FPRO: Finalidad Procedimiento
                        lcrNombreCampo = "Finalidad Procedimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";

                        if (G1Sia_codrip_trip == "02" || G1Sia_codrip_trip == "03" ||
                            G1Sia_codrip_trip == "04" || G1Sia_codrip_trip == "05")
                        {

                            if (String.IsNullOrWhiteSpace(G1Sia_codfpr_fpro))
                            {
                                lcrValorReturn = lcrNombreCampo+ ": Es obligatoria para Rips de Procedimientos";
                            }
                            else
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiafinaliproced(G1Sia_codfpr_fpro);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codfpr_fpro))
                                {
                                    G1Sia_desfpr_fpro = tmp.sia_desfpr_fpro;
                                }
                                else
                                {
                                    lcrValorReturn = "Finalidad Procedimiento: No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codfco_fcon":
                        #region SIA_CODFCO_FCON: Finalidad consulta
                        lcrNombreCampo = "Finalidad consulta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";

                        if (G1Sia_codrip_trip == "01")
                        {
                            if (String.IsNullOrWhiteSpace(G1Sia_codfco_fcon))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es obligatoria para Rips de consultas";
                            }
                            else
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiafinaliconsul(G1Sia_codfco_fcon);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codfco_fcon))
                                {
                                    G1Sia_desfco_fcon = tmp.sia_desfco_fcon;
                                }
                                else
                                {
                                    lcrValorReturn = "Finalidad consulta: No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_codcex_tcex":
                        #region ADM_CODCEX_TCEX: Causa Externa
                        lcrNombreCampo = "Causa Externa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (String.IsNullOrWhiteSpace(G1Adm_codcex_tcex))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = ADMValidarCodigo.fobRegBuscarAdmcausaexterna(G1Adm_codcex_tcex);
                            if (tmp != null)
                            {
                                G1Adm_descex_tcex = tmp.adm_descex_tcex;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_mededi_sips":
                        #region FCM_MEDEDI_SIPS: Medida edad Inicial
                        lcrNombreCampo = "Medida edad Inicial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (String.IsNullOrWhiteSpace(G1Fcm_mededi_sips))
                        {
                            lcrValorReturn = "Medida edad Inicial: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_mededi_sips, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Medida edad Inicial: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_edaini_sips":
                        #region FCM_EDAINI_SIPS: Edad Inicial
                        lcrNombreCampo = "Edad Inicial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (G1Fcm_edaini_sips <= 0)
                        {
                            lcrValorReturn = "Edad Inicial: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_edaini_sips < 0 || G1Fcm_edaini_sips > 999)
                            {
                                lcrValorReturn = "Edad Inicial: Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_mededf_sips":
                        #region FCM_MEDEDF_SIPS: Medida edad final
                        lcrNombreCampo = "Medida edad final";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (String.IsNullOrWhiteSpace(G1Fcm_mededf_sips))
                        {
                            lcrValorReturn = "Medida edad final: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_mededf_sips, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Medida edad final: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_edafin_sips":
                        #region FCM_EDAFIN_SIPS: Edad final
                        lcrNombreCampo = "Edad final";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (G1Fcm_edafin_sips <= 0)
                        {
                            lcrValorReturn = "Edad final: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_edafin_sips < 0 || G1Fcm_edafin_sips > 999)
                            {
                                lcrValorReturn = "Edad final: Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_mededp_sips":
                        #region FCM_MEDEDP_SIPS: Medida edad puntual
                        lcrNombreCampo = "Medida edad puntual";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (!String.IsNullOrWhiteSpace(G1Fcm_mededp_sips))
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_mededp_sips, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_edapun_sips":
                        #region FCM_EDAPUN_SIPS: Lista edad puntual
                        lcrNombreCampo = "Lista edad puntual";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (!String.IsNullOrWhiteSpace(G1Fcm_edapun_sips))
                        {
                            if (G1Fcm_edapun_sips != "NA")
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Fcm_edapun_sips, "RVDMA1234567890-*"))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no permitidos";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_sexapl_sips":
                        #region FCM_SEXAPL_SIPS: Sexo que aplica
                        lcrNombreCampo = "Sexo que aplica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (String.IsNullOrWhiteSpace(G1Fcm_sexapl_sips))
                        {
                            lcrValorReturn = "Sexo que aplica: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_sexapl_sips, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Sexo que aplica: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_nivcom_sips":
                        #region FCM_NIVCOM_SIPS: Nivel de complejidad
                        lcrNombreCampo = "Nivel de complejidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (String.IsNullOrWhiteSpace(G1Fcm_nivcom_sips))
                        {
                            lcrValorReturn = "Nivel de complejidad: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_nivcom_sips, ",", "1,2,3,4,5,6"))
                            {
                                lcrValorReturn = "Nivel de complejidad: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codrip_trip":
                        #region SIA_CODRIP_TRIP: Tipo servicio RIPS
                        lcrNombreCampo = "Tipo servicio RIPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (String.IsNullOrWhiteSpace(G1Sia_codrip_trip))
                        {
                            lcrValorReturn = "Tipo servicio RIPS: Es requerido";
                        }
                        else
                        {
                            EFsiatablatprips tmp = new EFsiatablatprips();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatablatprips(G1Sia_codrip_trip);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codrip_trip))
                            {
                                G1Sia_desrip_trip = tmp.sia_desrip_trip;
                            }
                            else
                            {
                                lcrValorReturn = "Tipo servicio RIPS: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_aplfus_sips":
                        #region FCM_APLFUS_SIPS: Frecuencia de uso
                        lcrNombreCampo = "Frecuencia de uso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (String.IsNullOrWhiteSpace(G1Fcm_aplfus_sips))
                        {
                            lcrValorReturn = "Frecuencia de uso: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_aplfus_sips, ",", "1,2"))
                            {
                                lcrValorReturn = "Frecuencia de uso: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_intser_sips":
                        #region FCM_INTSER_SIPS: Intervalos días orden servicio
                        lcrNombreCampo = "Intervalos días frecuencia para orden servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (G1Fcm_intser_sips < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor o igual a cero";
                        }
                        else
                        {
                            if (G1Fcm_intser_sips < 0 || G1Fcm_intser_sips > 9999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                            if (G1Fcm_aplfus_sips == "1" && (G1Fcm_intser_sips <= 0 || G1Fcm_intser_sips > 9999))
                            {
                                lcrValorReturn = lcrNombreCampo + ": no puede ser cero o mayor a 9999";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_perfus_sips":
                        #region FCM_PERFUS_SIPS: Periodo frecuencia de uso
                        lcrNombreCampo = "Periodo frecuencia de uso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A32";
                        if (String.IsNullOrWhiteSpace(G1Fcm_perfus_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_perfus_sips, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_semeps_sips":
                        #region FCM_SEMEPS_SIPS: Semanas cotizadas
                        lcrNombreCampo = "Semanas cotizadas";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (G1Fcm_semeps_sips < 0 || G1Fcm_semeps_sips > 9999)
                        {
                            lcrValorReturn = "Semanas cotizadas: Valor fuera del rango";
                        }
                        break;
                        #endregion

                    case "G1Fcm_semsss_sips":
                        #region FCM_SEMSSS_SIPS: Semanas en SSS
                        lcrNombreCampo = "Semanas en SSS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A25";
                        if (G1Fcm_semsss_sips < 0 || G1Fcm_semsss_sips > 999)
                        {
                            lcrValorReturn = "Semanas en Sistema general de seguridad social (SGSS): Valor fuera del rango";
                        }
                        break;
                        #endregion

                    case "G1Fcm_maxord_sips":
                        #region FCM_MAXORD_SIPS: Cantidad orden facturación
                        lcrNombreCampo = "Cantidad orden facturación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A26";
                        if (G1Fcm_maxord_sips <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_maxord_sips < 0 || G1Fcm_maxord_sips > 999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_maxint_sips":
                        #region FCM_MAXINT_SIPS: Cantidad máxima intervalo
                        lcrNombreCampo = "Cantidad máxima intervalo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A27";
                        if (G1Fcm_maxint_sips < 0 || G1Fcm_maxint_sips > 999999)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                        }
                        break;
                        #endregion

                    case "G1Sis_codiva_tiva":
                        #region SIS_CODIVA_TIVA: IVA Aplicado
                        lcrNombreCampo = "IVA Aplicado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A28";
                        if (String.IsNullOrWhiteSpace(G1Sis_codiva_tiva))
                        {
                            lcrValorReturn = "IVA Aplicado: Es requerido";
                        }
                        else
                        {
                            EFsistablaiva tmp = new EFsistablaiva();
                            tmp = SISValidarCodigo.fobRegBuscarSistablaiva(G1Sis_codiva_tiva);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_codiva_tiva))
                            {
                                G1Sis_desiva_tiva = tmp.sis_desiva_tiva;
                            }
                            else
                            {
                                lcrValorReturn = "IVA Aplicado: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipact_tsac":
                        #region SIA_TIPACT_TSAC: Tipo Servicio o actividad
                        lcrNombreCampo = "Tipo Servicio o actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A29";
                        if (String.IsNullOrWhiteSpace(G1Sia_tipact_tsac))
                        {
                            lcrValorReturn = "Tipo Servicio o actividad: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_tipact_tsac, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = "Tipo Servicio o actividad: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_otserv_sips":
                        #region FCM_OTSERV_SIPS: Tipo Rips otros servicios
                        lcrNombreCampo = "Tipo Rips otros servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A30";
                        if (G1Sia_codrip_trip == "06" || G1Sia_codrip_trip == "07" ||
                            G1Sia_codrip_trip == "09" || G1Sia_codrip_trip == "14")
                        {

                            if (String.IsNullOrWhiteSpace(G1Fcm_otserv_sips))
                            {
                                lcrValorReturn = "Tipo Rips otros servicios: Es requerido";
                            }
                            else
                            {
                                if (!Funciones.flgExisteElemento(G1Fcm_otserv_sips, ",", "1,2,3,4"))
                                {
                                    lcrValorReturn = "Tipo Rips otros servicios: Dato no es valido";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_forfar_sips":
                        #region FCM_FORFAR_SIPS: Forma farmacéutica
                        lcrNombreCampo = "Forma farmacéutica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A31";
                        if (G1Sia_codrip_trip == "12" || G1Sia_codrip_trip == "13")
                        {
                            if (String.IsNullOrWhiteSpace(G1Fcm_forfar_sips))
                            {
                                lcrValorReturn = "Forma farmacéutica: Valor es requerido";
                            }
                            else 
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Fcm_forfar_sips, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789%()./+ "))
                                {
                                    lcrValorReturn = lcrValorReturn + ": Contiene caracteres no permitidos";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_conmed_sips":
                        #region FCM_CONMED_SIPS: Concentración
                        lcrNombreCampo = "Concentración";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A32";
                        if (G1Sia_codrip_trip == "12" || G1Sia_codrip_trip == "13")
                        {
                            if (String.IsNullOrWhiteSpace(G1Fcm_conmed_sips))
                            {
                                lcrValorReturn = "Concentración: Valor es requerido";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Fcm_conmed_sips, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789%()./+ "))
                                {
                                    lcrValorReturn = lcrValorReturn + ": Contiene caracteres no permitidos";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_unimed_sips":
                        #region FCM_UNIMED_SIPS: Unidad de medida
                        lcrNombreCampo = "Unidad de medida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A33";

                        if (G1Sia_codrip_trip == "12" || G1Sia_codrip_trip == "13")
                        {
                            if (String.IsNullOrWhiteSpace(G1Fcm_unimed_sips))
                            {
                                lcrValorReturn = "Unidad de medida: Valor es requerido";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Fcm_unimed_sips, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789%()./+ "))
                                {
                                    lcrValorReturn = lcrValorReturn + ": Contiene caracteres no permitidos";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codpat_tpat":
                        #region SIA_CODPAT_TPAT: Tipo de profesional
                        lcrNombreCampo = "Tipo de profesional";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A34";
                        if (!string.IsNullOrWhiteSpace(G1Sia_codpat_tpat))
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_codpat_tpat, ",", "1,2,3,4,5"))
                            {
                                lcrValorReturn = "Tipo de profesional: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_serpos_sips":
                        #region FCM_SERPOS_SIPS: Servicio POS/NO POS
                        lcrNombreCampo = "Servicio POS/NO POS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A35";
                        if (String.IsNullOrWhiteSpace(G1Fcm_serpos_sips))
                        {
                            lcrValorReturn = "Servicio POS/NO POS: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_serpos_sips, ",", "1,2"))
                            {
                                lcrValorReturn = "Servicio POS/NO POS: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_tipser_sips":
                        #region FCM_TIPSER_SIPS: Servicio o Suministro
                        lcrNombreCampo = "Servicio o Suministro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A36";
                        if (!string.IsNullOrWhiteSpace(G1Fcm_tipser_sips))
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_tipser_sips, ",", "1,2"))
                            {
                                lcrValorReturn = "Servicio o Suministro: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_secart_mart":
                        #region INV_SECART_MART: Secuencial Suministro
                        lcrNombreCampo = "Secuencial Suministro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A37";
                        /*
                        if (!string.IsNullOrWhiteSpace(G1Inv_secart_mart))
                        {
                            EFinvmaearticulos tmp = new EFinvmaearticulos();
                            tmp = INVValidarCodigo.fobRegBuscarInvmaearticulos(G1Inv_secart_mart);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.inv_secart_mart))
                            {
                                G1Inv_codaux_mart = tmp.inv_codaux_mart;
                                G1Inv_desart_mart = tmp.inv_desart_mart;
                                G1Sis_codiva_tiva = tmp.sis_codiva_tiva;
                            }
                            else
                            {
                                lcrValorReturn = "Secuencial Suministro: No existe";
                            }
                        }
                        */
                        break;
                        #endregion

                    case "G1Inv_codaux_mart":
                        #region INV_CODAUX_MART: Código Auxiliar
                        lcrNombreCampo = "Código Auxiliar";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A38";
                        /*
                        if (!string.IsNullOrWhiteSpace(G1Inv_codaux_mart))
                        {
                            EFinvmaearticulos tmp = new EFinvmaearticulos();
                            tmp = INVValidarCodigo.fobRegBuscarIuInvmaearticulos(G1Inv_codaux_mart);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.inv_codaux_mart))
                            {
                                G1Inv_secart_mart = tmp.inv_secart_mart;
                                G1Inv_desart_mart = tmp.inv_desart_mart;
                                G1Sis_codiva_tiva = tmp.sis_codiva_tiva;
                            }
                            else
                            {
                                lcrValorReturn = "Código Auxiliar: No existe";
                            }
                        }
                        */
                        break;
                        #endregion

                    case "G1Fcm_numuni_sips":
                        #region FCM_NUMUNI_SIPS: Total Unidades
                        lcrNombreCampo = "Total Unidades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A39";
                        if (G1Fcm_numuni_sips > 0)
                        {
                            if (G1Fcm_numuni_sips < 0 || G1Fcm_numuni_sips > 99)
                            {
                                lcrValorReturn = "Total Unidades: Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Ssp_codcam_resc":
                        #region SSP_CODCAM_RESC: Campo Resolucion 4505
                        lcrNombreCampo = "Campo Resolucion 4505";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A40";
                        if (!String.IsNullOrWhiteSpace(G1Ssp_codcam_resc))
                        {
                            EFsptabcampos4505 tmp = new EFsptabcampos4505();
                            tmp = SSPValidarCodigo.fobRegBuscarSptabcampos4505(G1Ssp_codcam_resc);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.ssp_codcam_resc))
                            {
                                G1Ssp_nomcam_resc = tmp.ssp_nomcam_resc;
                                G1Ssp_tipval_resc = tmp.ssp_tipval_resc;
                                G1Ssp_valper_resc = tmp.ssp_valper_resc;
                                G1Ssp_camdig_resc = tmp.ssp_camdig_resc;
                            }
                            else
                            {
                                lcrValorReturn = "Campo Resolucion 4505: No existe";
                                G1Ssp_nomcam_resc = String.Empty;
                                G1Ssp_tipval_resc = String.Empty;
                                G1Ssp_valper_resc = String.Empty;
                                G1Ssp_camdig_resc = String.Empty;
                            }
                        }
                        break;
                        #endregion

                    case "G1Ssp_tipval_resc":
                        #region SSP_TIPVAL_RESC: Tipo de Valor
                        lcrNombreCampo = "Tipo de Valor";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A41";

                        if (!String.IsNullOrWhiteSpace(G1Ssp_codcam_resc))
                        {
                            if (String.IsNullOrWhiteSpace(G1Ssp_tipval_resc))
                            {
                                lcrValorReturn = "Tipo de Valor: Es requerido";
                            }
                            else
                            {
                                if (!Funciones.flgExisteElemento(G1Ssp_tipval_resc, ",", "D,C,N"))
                                {
                                    lcrValorReturn = "Tipo de Valor: Dato no es valido";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Ssp_camdig_resc":
                        #region SSP_CAMDIG_RESC: Campo digitable
                        lcrNombreCampo = "Campo digitable";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A42";

                        if (!String.IsNullOrWhiteSpace(G1Ssp_codcam_resc))
                        {

                            if (String.IsNullOrWhiteSpace(G1Ssp_camdig_resc))
                            {
                                lcrValorReturn = "Campo digitable: Es requerido";
                            }
                            else
                            {
                                if (!Funciones.flgExisteElemento(G1Ssp_camdig_resc, ",", "1,2"))
                                {
                                    lcrValorReturn = "Campo digitable: Dato no es valido";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Ssp_valper_resc":
                        #region SSP_VALPER_RESC: Valor Permitido
                        lcrNombreCampo = "Valor Permitido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A43";

                        if (!String.IsNullOrWhiteSpace(G1Ssp_codcam_resc))
                        {
                            if (String.IsNullOrWhiteSpace(G1Ssp_valper_resc))
                            {
                                lcrValorReturn = "Valor Permitido: Es requerido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_estser_sips":
                        #region FCM_ESTSER_SIPS: Estado del servicio
                        lcrNombreCampo = "Estado del servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A44";
                        if (String.IsNullOrWhiteSpace(G1Fcm_estser_sips))
                        {
                            lcrValorReturn = "Estado del servicio: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_estser_sips, ",", "1,2"))
                            {
                                lcrValorReturn = "Estado del servicio: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_codsal_tsal":
                        #region SIS_CODSAL_TSAL: Código salario minimo
                        lcrNombreCampo = "Código salario minimo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A45";

                        if (!String.IsNullOrWhiteSpace(G1Sis_codsal_tsal))
                        {
                            EFsissalariomin tmp = new EFsissalariomin();
                            tmp = SISValidarCodigo.fobRegBuscarSissalariomin(G1Sis_codsal_tsal);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_codsal_tsal))
                            {
                                G1Sis_dessal_tsal = tmp.sis_dessal_tsal;
                                G1Sis_valsal_tsal = (int)tmp.sis_valsal_tsal;
                                G1Sis_valdia_tsal = (int)(G1Sis_valsal_tsal / 30);

                                if (G1Fcm_codser_soat == "NA")
                                {
                                    G1Fcm_punuvr_sips = G1Fcm_valser_sips / G1Sis_valdia_tsal;
                                    fcrValidacion("G1Fcm_valser_sips");
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codgqx_grqx":
                        #region FCM_CODGQX_GRQX: Grupo Quirúrgico
                        lcrNombreCampo = "Grupo Quirúrgico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A46";
                        if (glgSIS_ControlRipsQX == true)
                        {
                            if (String.IsNullOrWhiteSpace(G1Fcm_codgqx_grqx))
                            {
                                lcrValorReturn = "Grupo Quirúrgico: Es requerido";
                            }
                            else
                            {
                                EFfcmgrquirurgico tmp = new EFfcmgrquirurgico();
                                tmp = FCMValidarCodigo.fobRegBuscarFcmgrquirurgico(G1Fcm_codgqx_grqx);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codgqx_grqx))
                                {
                                    G1Fcm_desgqx_grqx = tmp.fcm_desgqx_grqx;
                                }
                                else
                                {
                                    lcrValorReturn = "Grupo Quirúrgico: No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_genhis_sips":
                        #region FCM_GENHIS_CPRO: Registrar actividad
                        lcrNombreCampo = "Generar actividad en historia clinica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Fcm_genhis_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_genhis_sips, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else if (G1Fcm_genhis_sips == "2")
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
                            if (G1Fcm_genhis_sips == "1")
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
                                if (G1Grp_idepla_grpl == "NA" && G1Fcm_genhis_sips == "1")
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
                            if (G1Fcm_genhis_sips == "1")
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

                    case "G1Sia_coddia_tdia":
                        #region SIA_CODDIA_TDIA: Codigo Diagnostico
                        lcrNombreCampo = "Código diagnóstico por defecto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A49";
                        if (String.IsNullOrWhiteSpace(G1Sia_coddia_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (G1Sia_coddia_tdia == "NA")
                            {
                                fcvAsignarDiagnosticos();
                            }
                            else
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_coddia_tdia);
                                if (tmp != null)
                                {
                                    G1Sia_desdia_tdia = tmp.sia_desdia_tdia;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                        }                                 
                        break;
                        #endregion                    

                    case "G1Sia_tipdxp_tdix":
                        #region SIA_TIPDXP_TDIX: Tipo diagnostico principal
                        lcrNombreCampo = "Tipo diagnostico principal";
                        lcrValorReturn = String.Empty;                        
                        lcrCodigoError = "A52";                        
                        if (String.IsNullOrWhiteSpace(G1Sia_tipdxp_tdix))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (G1Sia_tipdxp_tdix == "N" && G1Sia_coddia_tdia != "NA")
                            {
                                lcrValorReturn = lcrNombreCampo + ": debe ser diferente de 'NA'";
                            }
                            else if (G1Sia_coddia_tdia == "NA")
                            {
                                fcvAsignarDiagnosticos(); 
                                //G1Sia_tipdxp_tdix = "N";
                                //G1Sia_desdxp_tdix = "NO ASIGNADO";
                            }
                            else
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiatipodiagprin(G1Sia_tipdxp_tdix);
                                if (tmp != null)
                                {
                                    G1Sia_desdxp_tdix = tmp.sia_desdxp_tdix;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_coddia_sips":
                        #region FCM_CODDIA_SIPS: Lista diagnosticos
                        lcrNombreCampo = "Lista diagnósticos permitidos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A50";
                        if (String.IsNullOrWhiteSpace(G1Fcm_coddia_sips))
                        {
                            if (!String.IsNullOrWhiteSpace(G1Sia_coddia_tdia) && G1Sia_coddia_tdia != "NA")
                            {
                                lcrValorReturn = lcrNombreCampo + ": al menos debe contener el diagnóstico: " + G1Sia_coddia_tdia;
                            }
                        }                       
                        break;
                    #endregion

                    case "G1Fcm_codpro_fcpr":
                        #region FCM_CODPRO_FCPR: Codigo Producto
                        lcrNombreCampo = "Codigo Producto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A60";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codpro_fcpr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmfeunspscdprodu(G1Fcm_codpro_fcpr);
                            if (tmp != null)
                            {
                                G1Fcm_despro_fcpr = tmp.fcm_despro_fcpr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                    #endregion


                    case "G1Fcm_coddia_sipsxx":
                        #region FCM_CODDIA_SIPS: Lista diagnosticos resumen para ejecucion desde boton en vista
                        lcrNombreCampo = "Lista diagnosticos resumen";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A50";
                        if (!String.IsNullOrWhiteSpace(G1Fcm_coddia_sips))
                        {
                            //EFhclvariabmaestr lcrRegVar = null;
                            string[] larArray = G1Fcm_coddia_sips.Split((";").ToCharArray());
                            var lnuTotElemtos = larArray.Length;
                            var lcrValor = String.Empty;
                            var lnuIx = String.Empty;
                            var llgSiError = false;
                            var i = 0;

                            // Limpiar errores
                            for (i = 0; i < lnuTotElemtos; i++)
                            {
                                lnuIx = i.ToString().Trim();
                                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A50A" + lnuIx, lcrNombreCampo, "", "ALTO", lcrImgNivelError);
                                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A50B" + lnuIx, lcrNombreCampo, "", "ALTO", lcrImgNivelError);
                                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A50C" + lnuIx, lcrNombreCampo, "", "ALTO", lcrImgNivelError);
                                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A50D" + lnuIx, lcrNombreCampo, "", "ALTO", lcrImgNivelError);
                                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A50E" + lnuIx, lcrNombreCampo, "", "ALTO", lcrImgNivelError);
                            }

                            // Validar lista
                            for (i = 0; i < lnuTotElemtos; i++)
                            {
                                lnuIx = i.ToString().Trim();
                                lcrValor = larArray[i].ToUpper();

                                if (String.IsNullOrWhiteSpace(lcrValor))
                                {
                                    llgSiError = true;
                                    lcrCodigoError = "A50A" + lnuIx;
                                    lcrValorReturn = lcrNombreCampo + ": hay espacios vacios posición " + lnuIx;
                                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                                 lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                                }
                                else if (lcrValor.Length != 4) // Nombre tamaño del nombre incorrecto
                                {
                                    llgSiError = true;
                                    lcrCodigoError = "A50B" + lnuIx;
                                    lcrValorReturn = lcrNombreCampo + ": Codigo del diagnostico no es valido en tamaño (" + lcrValor.Length.ToString() + " caracteres)";

                                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                                 lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                                }
                            }
                            // El valor por defecto tambien debe estar en lista
                            if (llgSiError == false)
                            {
                                lcrCodigoError = "A50E";
                                lcrValorReturn = String.Empty;

                                if (String.IsNullOrWhiteSpace(G1Sia_coddia_tdia) || G1Sia_coddia_tdia == "NA")
                                {
                                    lcrValorReturn = "Código diagnóstico por defecto: es requerido";
                                    llgSiError = true;
                                }
                                else
                                {
                                    if (!Funciones.flgExisteElemento(G1Sia_coddia_tdia, ";", G1Fcm_coddia_sips))
                                    {
                                        lcrValorReturn = "Código diagnóstico por defecto: " + G1Sia_coddia_tdia + 
                                                         " debe estar en la lista de diagnósticos permitidos para el servicio";
                                        llgSiError = true;
                                    }
                                }
                                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                            }
                            lcrCodigoError = "A50";
                            lcrValorReturn = llgSiError == true ? lcrNombreCampo + ": Hay errores en la lista" : String.Empty;
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
        #region fcvAsignarDiagnosticos
        /// <summary>
        /// Asignar Diagnosticos
        /// </summary>
        public void fcvAsignarDiagnosticos()
        {
            G1Sia_coddia_tdia = "NA";
            G1Sia_desdia_tdia = "NO ASIGNADO";
            G1Sia_tipdxp_tdix = "N";                     
            G1Sia_desdxp_tdix = "NO ASIGNADO";
            G1Fcm_coddia_sips = String.Empty;
        }
        #endregion
    }
}
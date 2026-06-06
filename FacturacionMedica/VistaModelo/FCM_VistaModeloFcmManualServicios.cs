//- MARMOTA-GENCODE: VERSION 2.0 - 27/03/2015 12:14:30 PM
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
    /// <para>TABLA: fcmmanservicios</para>
    /// <para>DESCRIPCION:
    ///  Maestro de servicios derivados de SERVICIOS IPS, en este archivo
    ///  se configuran los precios y codigos de tarifarios para ventas(SOAT
    ///  ISS CUPS), se crea paquetes de servicios
    /// </para>
    /// </summary>
    public class VistaModeloFcmManualServicios : VistaModeloFcmManualServiciosBase
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
                    case "G1Fcm_idesec_sips":
                        #region FCM_IDESEC_SIPS: Código servicio IPS
                        lcrNombreCampo = "Código servicio IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Fcm_idesec_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            EFfcmmanservicips tmp = new EFfcmmanservicips();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G1Fcm_idesec_sips);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_idesec_sips))
                            {
                                G1Fcm_coddig_mant = tmp.fcm_coddig_mant;
                                G1Fcm_codbar_sips = String.IsNullOrWhiteSpace(G1Fcm_codbar_sips) ? tmp.fcm_codbar_sips : G1Fcm_codbar_sips;
                                G1Fcm_desser_sips = tmp.fcm_desser_sips;
                                G1Sia_codrip_trip = tmp.sia_codrip_trip;
                                G1Fcm_desser_mant = String.IsNullOrWhiteSpace(G1Fcm_desser_mant) ? tmp.fcm_desser_sips : G1Fcm_desser_mant;
                                G1Fcm_aplfus_sips = String.IsNullOrWhiteSpace(G1Fcm_aplfus_sips) ? tmp.fcm_aplfus_sips : G1Fcm_aplfus_sips;
                                G1Fcm_codser_mant = String.IsNullOrWhiteSpace(G1Fcm_codser_mant) ? tmp.fcm_codser_sips : G1Fcm_codser_mant;
                                G1Fcm_valser_mant = G1Fcm_valser_mant <= 0 ? (float)tmp.fcm_valser_sips : G1Fcm_valser_mant;
                                G1Fcm_punuvr_mant = G1Fcm_punuvr_mant <= 0 ? (float)tmp.fcm_punuvr_sips : G1Fcm_punuvr_mant;
                                // Decripcion tipo rips
                                var tmpx = SIAValidarCodigo.fobRegBuscarSiatablatprips(G1Sia_codrip_trip);
                                if (tmpx != null && !String.IsNullOrWhiteSpace(tmpx.sia_codrip_trip))
                                {
                                    G1Sia_desrip_trip = tmpx.sia_desrip_trip;
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codbar_sips":
                        #region FCM_CODBAR_SIPS: Código de Barras
                        lcrNombreCampo = "Código de Barras";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codbar_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Fcm_coddig_mant":
                        #region FCM_CODDIG_MANT: Código digitación servicio
                        lcrNombreCampo = "Código digitación servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Fcm_coddig_mant))
                        {
                            lcrValorReturn = "Código digitación servicio: Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarIuFcmmanservicios(G1Fcm_coddig_mant, G1Fcm_codman_mans);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.fcm_idesec_sips))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = "Código digitación servicio: Ya existe para algun registro en  manual tarifario activo";
                                    }
                                    else
                                    {
                                        if (G1Fcm_idesec_mant != tmp.fcm_idesec_mant) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = "Código digitación servicio: Ya existe para algun registro en manual tarifario activo";
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codser_mant":
                        #region FCM_CODSER_MANT: Código servicio en tarifario
                        lcrNombreCampo = "Código servicio en tarifario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codser_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Fcm_desser_mant":
                        #region FCM_DESSER_MANT: Nombre servicio
                        lcrNombreCampo = "Nombre servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Fcm_desser_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Fcm_valser_mant":
                        #region FCM_VALSER_MANT: Valor de servicio
                        lcrNombreCampo = "Valor de servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (G1Fcm_valser_mant <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_valser_mant < 0 || G1Fcm_valser_mant > 999999999)
                            {
                                lcrValorReturn = "Valor de servicio: Valor fuera del rango";
                            }
                            if (G1Fcm_codtar_ttar == "2") // Es ISS  no necesita salario minimo
                            {
                                G1Fcm_punuvr_mant = fflCalcularPuntaje();
                            }
                            else
                            {
                                if (G1Sis_valdia_tsal > 0)
                                {
                                    // Calcular puntaje o cantidades en UVR
                                    G1Fcm_punuvr_mant = fflCalcularPuntaje();
                                }
                                else if (gflOldValorServicio > 0 && G1Fcm_valser_mant != gflOldValorServicio)
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

                    case "G1Fcm_punuvr_mant":
                        #region FCM_PUNUVR_MANT: Puntaje o UVR
                        lcrNombreCampo = "Puntaje o UVR";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (G1Fcm_punuvr_mant <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        break;
                        #endregion

                    case "G1Fcm_valren_mant":
                        #region FCM_VALREN_MANT: Valor recargo nocturno
                        lcrNombreCampo = "Valor recargo nocturno";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (G1Fcm_valren_mant > 999999)
                        {
                            lcrValorReturn = lcrNombreCampo + ": no es valido";
                        }
                        break;
                        #endregion

                    case "G1Fcm_tipccp_mant":
                        #region FCM_TIPCCP_MANT: Tipo liquidación copagos
                        lcrNombreCampo = "Tipo liquidación copagos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Fcm_tipccp_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_tipccp_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_vficop_mant":
                        #region FCM_VFICOP_MANT: Valor fijo Copagos c.mod
                        lcrNombreCampo = "Valor fijo Copagos c.mod";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (G1Fcm_vficop_mant <= 0 && G1Fcm_tipccp_mant =="2")
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        break;
                        #endregion

                    case "G1Fcm_facpln_mant":
                        #region FCM_FACPLN_MANT: Tarifa Plena SI/NO
                        lcrNombreCampo = "Tarifa Plena SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (String.IsNullOrWhiteSpace(G1Fcm_facpln_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_facpln_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_facvmc_mant":
                        #region FCM_FACVMC_MANT: Valores en cero SI/NO
                        lcrNombreCampo = "Valores en cero SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (String.IsNullOrWhiteSpace(G1Fcm_facvmc_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_facvmc_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_perman_mant":
                        #region FCM_PERMAN_MANT: Código Pertenece al manual
                        lcrNombreCampo = "Código Pertenece al manual";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (String.IsNullOrWhiteSpace(G1Fcm_perman_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_perman_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_alcamb_mant":
                        #region FCM_ALCAMB_MANT: Ambulatoria POS/NO POS
                        lcrNombreCampo = "Ambulatoria POS/NO POS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (String.IsNullOrWhiteSpace(G1Fcm_alcamb_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_alcamb_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_alcurg_mant":
                        #region FCM_ALCURG_MANT: Urgencia POS/NO POS
                        lcrNombreCampo = "Urgencia POS/NO POS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (String.IsNullOrWhiteSpace(G1Fcm_alcurg_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_alcurg_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_alchos_mant":
                        #region FCM_ALCHOS_MANT: Hospitalización POS/NO POS
                        lcrNombreCampo = "Hospitalización POS/NO POS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (String.IsNullOrWhiteSpace(G1Fcm_alchos_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_alchos_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_aplfus_sips":
                        #region FCM_APLFUS_SIPS: Frecuencia de uso SI/NO
                        lcrNombreCampo = "Frecuencia de uso SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (String.IsNullOrWhiteSpace(G1Fcm_aplfus_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_aplfus_sips, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_estser_mant":
                        #region FCM_ESTSER_MANT: Estado del servicio
                        lcrNombreCampo = "Estado del servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (String.IsNullOrWhiteSpace(G1Fcm_estser_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_estser_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_codsal_tsal":
                        #region SIS_CODSAL_TSAL: Código
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
                                G1Sis_valdia_tsal = (G1Sis_valsal_tsal / 30);
                                G1Fcm_punuvr_mant = fflCalcularPuntaje(); // Calcular puntaje o cantidades en UVR
                                // Validar
                                fcrValidacion("G1Fcm_valser_sips");
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            if (G1Fcm_codtar_ttar == "2") // Es ISS  no necesita salario minimo
                            {
                                G1Fcm_punuvr_mant = fflCalcularPuntaje();
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
        #region floCalcularPuntaje
        /// <summary>
        ///Calcular puntaje o valor en UVR del servicio
        /// </summary>
        public float fflCalcularPuntaje()
        {
            float lflValor = 0;
            try
            {
                if (G1Fcm_codtar_ttar != "2") // Diferente de ISS 
                {
                    // Soat y Cups se calculan igual
                    lflValor = G1Fcm_valser_mant / G1Sis_valdia_tsal;
                }
                else
                {
                    // Calculo para ISS
                    lflValor = G1Fcm_valser_mant / 100;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: floCalcularPuntaje");
            }
            return lflValor;
        }
        #endregion

    }
}
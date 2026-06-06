//- MARMOTA-GENCODE: VERSION 2.0 - 31/01/2018 04:56:05 PM
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
using GalaSoft.MvvmLight.Messaging;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using FacturacionMedica.Modelo;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: fcmsoatmanualma</para>
    /// <para>DESCRIPCION:
    ///  Lista de servicios con puntajes y valores según tarifario SOAT,
    ///  para consulta y referencia actualizable cada año
    /// </para>
    /// </summary>
    public class VistaModeloFcmsoatmanualma : VistaModeloFcmsoatmanualmaBase
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
        public override String fcrValidacion(String tcrNombrePropiedad)
        {
            String lcrValorReturn = String.Empty;
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
                    case "G1Fcm_codser_soat":
                        #region FCM_CODSER_SOAT: Codigo SOAT
                        lcrNombreCampo = "Codigo SOAT";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codser_soat))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && FCMValidarCodigo.flgBuscarFcmsoatmanualma(G1Fcm_codser_soat))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_punuvr_sips":
                        #region FCM_PUNUVR_SIPS: Puntaje o UVR
                        lcrNombreCampo = "Puntaje o UVR";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (G1Fcm_punuvr_sips <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_punuvr_sips < 0 || G1Fcm_punuvr_sips > 999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_valser_sips":
                        #region FCM_VALSER_SIPS: Valor de servicio
                        lcrNombreCampo = "Valor de servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (G1Fcm_valser_sips <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_valser_sips < 0 || G1Fcm_valser_sips > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_deskey_soat":
                        #region FCM_DESKEY_SOAT: Campo llave
                        //lcrNombreCampo = "Campo llave";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A05";
                        //if (String.IsNullOrWhiteSpace(G1Fcm_deskey_soat))
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        //}
                        //else
                        //{
                        //}
                        break;
                        #endregion

                    case "G1Fcm_valkey_soat":
                        #region FCM_VALKEY_SOAT: Indice llave
                        //lcrNombreCampo = "Indice llave";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A06";
                        //if (G1Fcm_valkey_soat <= 0)
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        //}
                        //else
                        //{
                        //}
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
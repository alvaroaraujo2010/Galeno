//- MARMOTA-GENCODE: VERSION 2.0 - 17/10/2020 05:34:55 AM
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

namespace Sistema.VistaModelo
{
    /// <summary>
    /// <para>TABLA: carfemailgestioma</para>
    ///  <para>DESCRIPCIÓN: 
    ///  Maestro Administrador lista correos de facturas que se envian a los adquirentes, permite llevar
    ///  un control de correos enviados y facilitar esta gestion
    ///  </para>
    /// </summary>
    public class VistaModeloGestorCorreos : VistaModeloGestorCorreosBase
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
            bool llgValidDefault = false;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Car_arcnom_cagm":
                        #region CAR_ARCNOM_CAGM: Nombre archivo resumen
                        lcrNombreCampo = "Nombre archivo resumen";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Car_arcnom_cagm))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            // Vlidar el nombre del archivo aqui
                        }
                        #endregion
                        break;

                    case "G1Sis_idterc_sitr":
                        #region SIS_IDTERC_SITR: Codigo Adquirente
                        lcrNombreCampo = "Codigo Adquirente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Sis_idterc_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSismaesterceros(G1Sis_idterc_sitr);
                            if (tmp != null)
                            {
                                G1Sis_razsoc_sitr = tmp.sis_razsoc_sitr;
                                G1Car_taddre_caml = string.IsNullOrWhiteSpace(G1Car_taddre_caml) ? tmp.sis_emailc_sitr : G1Car_taddre_caml;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        #endregion
                        break;

                    case "G1Car_taddre_caml":
                        #region CAR_TADDRE_CAML: Destinatario
                        lcrNombreCampo = "Correo del Destinatario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (string.IsNullOrWhiteSpace(G1Car_taddre_caml))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            // Validar en correo 
                        }
                        #endregion
                        break;

                    case "G1Car_caddre_caml":
                        #region CAR_CADDRE_CAML: Segundo Destinatario
                        lcrNombreCampo = "Segundo Destinatario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Car_caddre_caml))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        #endregion
                        break;

                    case "G1Car_subjec_caml":
                        #region CAR_SUBJEC_CAML: Asunto
                        lcrNombreCampo = "Asunto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Car_subjec_caml))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            // Validar el texto del asunto
                        }
                        #endregion
                        break;

                    case "G1Car_envfec_caml":
                        #region CAR_ENVFEC_CAML: Fecha envio
                        lcrNombreCampo = "Fecha envio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Car_envfec_caml, "Fecha envio");
                        #endregion
                        break;

                    case "G1Car_envhor_caml":
                        #region CAR_ENVHOR_CAML: Hora envio
                        lcrNombreCampo = "Hora envio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Car_envhor_caml, "12", ":", "Hora envio");
                        #endregion
                        break;

                    case "G1Car_estenv_caml":
                        #region CAR_ESTENV_CAML: Estado del envio
                        lcrNombreCampo = "Estado del envio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (String.IsNullOrWhiteSpace(G1Car_estenv_caml))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Car_estenv_caml, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        #endregion
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
        public override String fcrValidacionRel(String tcrNombrePropiedad)
        {
            String lcrValorReturn = String.Empty;
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
                    case "G2Fcm_secreg_mfac":
                        #region FCM_SECREG_MFAC: Codigo facturacion
                        /*
                        lcrNombreCampo = "Codigo facturacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B03";
                        if (String.IsNullOrWhiteSpace(G2Fcm_secreg_mfac))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmfemaesfactefma(G2Fcm_secreg_mfac);
                            if (tmp != null)
                            {
                                G2Fcm_numfac_mfac = tmp.fcm_numfac_mfac;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        */
                        #endregion
                        break;

                    case "G2Car_estreg_cagf":
                        #region CAR_ESTREG_CAGF: Estado Registro
                        /*
                        lcrNombreCampo = "Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        if (String.IsNullOrWhiteSpace(G2Car_estreg_cagf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Car_estreg_cagf, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        */
                        #endregion
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

    }
}
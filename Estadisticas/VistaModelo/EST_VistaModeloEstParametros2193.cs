//- MARMOTA-GENCODE: VERSION 2.0 - 21/07/2018 02:10:14 PM
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
using Estadisticas.Modelo;

namespace Estadisticas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: estplangr2193ma</para>
    /// <para>DESCRIPCION:
    ///  grupos tipo detalles para plantillas de informes de la tabla
    ///  ESTPLANINFORMES
    /// </para>
    /// </summary>
    public class VistaModeloEstParametros2193 : VistaModeloEstParametros2193Base
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
                    case "G1Est_codinf_esin":
                         #region EST_CODINF_ESIN: Código infrome
                         //lcrNombreCampo = "Código informe";
                         //lcrValorReturn = String.Empty;
                         //lcrCodigoError = "A02";

                         //var tmp = ESTValidarCodigo.fobRegBuscarEstplaninformes(G1Est_codinf_esin);
                         //if (tmp != null)
                         //{
                         //   G1Est_nominf_esin = tmp.est_nominf_esin;
                         //}
                         //else
                         //{
                         //   lcrValorReturn = lcrNombreCampo + ": No existe";
                         //}

                        break;
                        #endregion

                    case "G1Est_nomgru_esgr":
                         #region EST_NOMGRU_ESGR: Nombre del  grupo
                        //lcrNombreCampo = "Nombre del  grupo";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A03";
                        //if (String.IsNullOrWhiteSpace(G1Est_nomgru_esgr))
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        //}
                        //else
                        //{
                        //}
                        //break;
                        #endregion

                    case "G1Est_ordgru_esgr":
                         #region EST_ORDGRU_ESGR: Orden Grupo
                        //lcrNombreCampo = "Orden Grupo";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A04";
                        //if (G1Est_ordgru_esgr <= 0)
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        //}
                        //else
                        //{
                        //}
                        //break;
                        #endregion

                    case "G1Est_ordvis_esgr":
                         #region EST_ORDVIS_ESGR: Orden Vista
                        //lcrNombreCampo = "Orden Vista";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A05";
                        //if (G1Est_ordvis_esgr <= 0)
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        //}
                        //else
                        //{
                        //}
                        //break;
                        #endregion

                    case "G1Est_estreg_esgr":
                         #region EST_ESTREG_ESGR: Estado del registro
                        lcrNombreCampo = "Estado del registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Est_estreg_esgr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Est_estreg_esgr, ",", "1,2"))
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
                    case "G2Fcm_codser_sips":
                        #region FCM_CODSER_SIPS: Código servicio en tarifario
                        //lcrNombreCampo = "Código servicio en tarifario";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "B03";
                        //if (String.IsNullOrWhiteSpace(G2Fcm_codser_sips))
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        //}
                        //else
                        //{
                        //}
                        break;
                        #endregion

                    case "G2Fcm_coddig_mant":
                        #region FCM_CODDIG_MANT: Código digitación servicio
                        lcrNombreCampo = "Código digitación servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";
                        if (String.IsNullOrWhiteSpace(G2Fcm_coddig_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(G2Fcm_coddig_mant);
                            if (tmp != null)
                            {                            
                                G2Fcm_desser_mant = tmp.fcm_desser_sips;
                                G2Fcm_codser_sips = tmp.fcm_codser_sips;
                                G2Sia_codrip_trip = tmp.sia_codrip_trip;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Sia_codrip_trip":
                        #region SIA_CODRIP_TRIP: Tipo servicio RIPS
                        lcrNombreCampo = "Tipo servicio RIPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        if (String.IsNullOrWhiteSpace(G2Sia_codrip_trip))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatablatprips(G2Sia_codrip_trip);
                            if (tmp != null)
                            {
                                G2Sia_desrip_trip = tmp.sia_desrip_trip;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Sia_codfpr_fpro":
                        #region SIA_CODFPR_FPRO: Finalidad Procedimiento
                        lcrNombreCampo = "Finalidad Procedimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (String.IsNullOrWhiteSpace(G2Sia_codfpr_fpro))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (G2Sia_codfpr_fpro == "NA")
                            {
                                G2Sia_desfpr_fpro = "NO ASIGNADO";
                            }
                            else
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiafinaliproced(G2Sia_codfpr_fpro);
                                if (tmp != null)
                                {
                                    G2Sia_desfpr_fpro = tmp.sia_desfpr_fpro;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Sia_codfco_fcon":
                        #region SIA_CODFCO_FCON: Finalidad consulta
                        lcrNombreCampo = "Finalidad consulta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        if (String.IsNullOrWhiteSpace(G2Sia_codfco_fcon))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (G2Sia_codfco_fcon == "NA")
                            {
                                G2Sia_desfco_fcon = "NO ASIGNADO";
                            }
                            else
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiafinaliconsul(G2Sia_codfco_fcon);
                                if (tmp != null)
                                {
                                    G2Sia_desfco_fcon = tmp.sia_desfco_fcon;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Adm_codcex_tcex":
                        #region ADM_CODCEX_TCEX: Causa Externa
                        lcrNombreCampo = "Causa Externa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B08";
                        if (String.IsNullOrWhiteSpace(G2Adm_codcex_tcex))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (G2Adm_codcex_tcex == "NA")
                            {
                                G2Adm_descex_tcex = "NO ASIGNADO";
                            }
                            else
                            {
                                var tmp = ADMValidarCodigo.fobRegBuscarAdmcausaexterna(G2Adm_codcex_tcex);
                                if (tmp != null)
                                {
                                    G2Adm_descex_tcex = tmp.adm_descex_tcex;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_mededi_sips":
                        #region FCM_MEDEDI_SIPS: Medida edad Inicial
                        lcrNombreCampo = "Medida edad Inicial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B09";
                        if (String.IsNullOrWhiteSpace(G2Fcm_mededi_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Fcm_mededi_sips, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_edaini_sips":
                        #region FCM_EDAINI_SIPS: Edad Inicial
                        lcrNombreCampo = "Edad Inicial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B10";
                        if (G2Fcm_edaini_sips <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G2Fcm_edaini_sips < 0 || G2Fcm_edaini_sips > 999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_mededf_sips":
                        #region FCM_MEDEDF_SIPS: Medida edad final
                        lcrNombreCampo = "Medida edad final";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B11";
                        if (String.IsNullOrWhiteSpace(G2Fcm_mededf_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Fcm_mededf_sips, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_edafin_sips":
                        #region FCM_EDAFIN_SIPS: Edad final
                        lcrNombreCampo = "Edad final";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B12";
                        if (G2Fcm_edafin_sips <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G2Fcm_edafin_sips < 0 || G2Fcm_edafin_sips > 999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_sexapl_sips":
                        #region FCM_SEXAPL_SIPS: Sexo que aplica
                        lcrNombreCampo = "Sexo que aplica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B13";
                        if (String.IsNullOrWhiteSpace(G2Fcm_sexapl_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Fcm_sexapl_sips, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Est_estreg_esgr":
                        #region EST_ESTREG_ESGR: Estado del registro
                        lcrNombreCampo = "Estado del registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B16";
                        if (String.IsNullOrWhiteSpace(G2Est_estreg_esgr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Est_estreg_esgr, ",", "1,2"))
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
//- MARMOTA-GENCODE: VERSION 2.0 - 07/05/2015 07:38:59 AM
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
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hoscamasareas</para>
    /// <para>DESCRIPCION:
    ///  Lista de camas creadas en el sistema, según las camas existentes
    ///  en cada area funcional de la IPS ejm: Cama Hospitalizacion
    ///  Mujeres, Cama Hospitalizacion Niños y otras
    /// </para>
    /// </summary>
    public class VistaModeloHoscamasareas : VistaModeloHoscamasareasBase
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
                    case "G1Hos_nrohab_habi":
                        #region HOS_NROHAB_HABI: Habitacion
                        lcrNombreCampo = "Habitacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Hos_nrohab_habi))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = HOSValidarCodigo.fobRegBuscarHoshabitaciones(G1Hos_nrohab_habi);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hos_nrohab_habi))
                            {
                                G1Hos_deshab_habi = tmp.hos_deshab_habi;
                                G1Hos_codsec_hsec = tmp.hos_codsec_hsec;
                                G1Sis_estreg_esrg = tmp.sis_estreg_esrg;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hos_descam_caho":
                        #region HOS_DESCAM_CAHO: Descripcion cama
                        lcrNombreCampo = "Descripcion cama";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Hos_descam_caho))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Hos_descam_caho = G1Hos_descam_caho.ToUpper();
                            if (!Funciones.flgSoloTexto("AN", G1Hos_descam_caho))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hos_tipcam_tcam":
                        #region HOS_TIPCAM_TCAM: Tipo cama
                        lcrNombreCampo = "Tipo cama";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Hos_tipcam_tcam))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = HOSValidarCodigo.fobRegBuscarHostipocamas(G1Hos_tipcam_tcam);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hos_tipcam_tcam))
                            {
                                G1Hos_destip_tcam = tmp.hos_destip_tcam;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hos_camaux_caho":
                        #region HOS_CAMAUX_CAHO: Cama adecuada
                        lcrNombreCampo = "Cama adecuada";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Hos_camaux_caho))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hos_camaux_caho, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_idesec_sips":
                        #region FCM_IDESEC_SIPS: Codigo servicio estancia
                        lcrNombreCampo = "Codigo servicio estancia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Fcm_idesec_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G1Fcm_idesec_sips);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_idesec_sips))
                            {
                                G1Fcm_coddig_mant = tmp.fcm_coddig_mant;
                                G1Fcm_desser_sips = tmp.fcm_desser_sips;
                                G1Fcm_codser_sips = tmp.fcm_codser_sips;
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
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Fcm_coddig_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Hos_codsec_hsec":
                        #region HOS_CODSEC_HSEC: Sección
                        lcrNombreCampo = "Sección";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Hos_codsec_hsec))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = HOSValidarCodigo.fobRegBuscarHosseccionareas(G1Hos_codsec_hsec);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hos_codsec_hsec))
                            {
                                G1Hos_dessec_hsec = tmp.hos_dessec_hsec;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hos_estcam_ecam":
                        #region HOS_ESTCAM_ECAM: Disponibilidad
                        lcrNombreCampo = "Disponibilidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Hos_estcam_ecam))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = HOSValidarCodigo.fobRegBuscarHosestadocama(G1Hos_estcam_ecam);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hos_estcam_ecam))
                            {
                                G1Hos_desest_ecam = tmp.hos_desest_ecam;
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
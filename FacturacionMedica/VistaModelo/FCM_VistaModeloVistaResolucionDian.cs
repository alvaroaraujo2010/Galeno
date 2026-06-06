//- MARMOTA-GENCODE: VERSION 2.0 - 24/08/2017 04:12:32 PM
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
    /// <para>TABLA: fcmsecrfacturas</para>
    /// <para>DESCRIPCION:
    ///  Maestro para gestion de secuenciales de facturación asignados
    ///  por la Dian con fecha inicio vigencia y estado en el sistema
    /// </para>
    /// </summary>
    public class VistaModeloVistaResolucionDian : VistaModeloVistaResolucionDianBase
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
                    case "G1Fcm_numres_srfa":
                        #region FCM_NUMRES_SRFA: Resolucion DIAN
                        lcrNombreCampo = "Resolucion DIAN";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Fcm_numres_srfa))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmsecrfacturas(G1Fcm_numres_srfa);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.fcm_secres_srfa))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G1Fcm_secres_srfa != tmp.fcm_secres_srfa) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_desres_srfa":
                        #region FCM_DESRES_SRFA: Descripción
                        lcrNombreCampo = "Descripción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Fcm_desres_srfa))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Fcm_desres_srfa))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_fecini_srfa":
                        #region FCM_FECINI_SRFA: Fecha Inicia vigencia
                        lcrNombreCampo = "Fecha Inicia vigencia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Fcm_fecini_srfa, "Fecha Inicia vigencia");
                        break;
                    #endregion

                    case "G1Fcm_fecfin_srfa":
                        #region FCM_FECFIN_SRFA: Fecha final vigencia
                        lcrNombreCampo = "Fecha final vigencia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Fcm_fecfin_srfa, "Fecha final vigencia");
                        break;
                    #endregion

                    case "G1Fcm_facini_srfa":
                        #region FCM_FACINI_SRFA: Numero secuencial inicio
                        lcrNombreCampo = "Numero secuencial inicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (G1Fcm_facini_srfa <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_facini_srfa < 1 || G1Fcm_facini_srfa > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_facfin_srfa":
                        #region FCM_FACFIN_SRFA: Numero secuencial fin
                        lcrNombreCampo = "Numero secuencial fin";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (G1Fcm_facfin_srfa <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_facfin_srfa < 1 || G1Fcm_facfin_srfa > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_ultgen_srfa":
                        #region FCM_ULTGEN_SRFA: Ultimo secuencial generado
                        lcrNombreCampo = "Ultimo secuencial generado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (G1Fcm_ultgen_srfa < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor o igual a cero";
                        }
                        else
                        {
                            if (G1Fcm_ultgen_srfa < 0 || G1Fcm_ultgen_srfa > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_prefij_srfa":
                        #region FCM_PREFIJ_SRFA: Numero de resolucion
                        lcrNombreCampo = "Numero de resolucion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Fcm_prefij_srfa))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Fcm_prefij_srfa))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_maxsec_srfa":
                        #region FCM_MAXSEC_SRFA: Tamaño Secuencial
                        lcrNombreCampo = "Tamaño Secuencial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (G1Fcm_maxsec_srfa <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_maxsec_srfa < 5 || G1Fcm_maxsec_srfa > 20)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_alrsec_srfa":
                        #region FCM_ALRSEC_SRFA: Limite secuencial alarma
                        lcrNombreCampo = "Limite secuencial alarma";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (G1Fcm_alrsec_srfa <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Fcm_alrsec_srfa < 50 || G1Fcm_alrsec_srfa > 120)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_relcer_srfa":
                        #region FCM_RELCER_SRFA: Rellenar con Ceros
                        lcrNombreCampo = "Rellenar con Ceros";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Fcm_relcer_srfa))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_relcer_srfa, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_estreg_srfa":
                        #region FCM_ESTREG_SRFA: Estado registro
                        lcrNombreCampo = "Estado registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (String.IsNullOrWhiteSpace(G1Fcm_estreg_srfa))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_estreg_srfa, ",", "1,2"))
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
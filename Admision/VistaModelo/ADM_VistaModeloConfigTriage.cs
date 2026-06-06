//- MARMOTA-GENCODE: VERSION 2.0 - 22/03/2018 04:59:56 PM
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
using Admision.Modelo;

namespace Admision.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admtriagemaconf</para>
    /// <para>DESCRIPCION:
    ///  Configuracion parametros según niveles en la evaluación inicial
    ///  Triage realizada a pacientes.
    /// </para>
    /// </summary>
    public class VistaModeloConfigTriage : VistaModeloConfigTriageBase
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
                    case "G1Adm_clasif_tria":
                        #region ADM_CLASIF_TRIA: Clasificación triage
                        lcrNombreCampo = "Clasificación triage";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Adm_clasif_tria))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_clasif_tria, ",", "1,2,3,4,5"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_remisi_tria":
                        #region ADM_REMISI_TRIA: Destino Remisión
                        lcrNombreCampo = "Destino Remisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Adm_remisi_tria))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_remisi_tria, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_titcla_adct":
                        #region ADM_TITCLA_ADCT: Titulo clasificación
                        lcrNombreCampo = "Titulo clasificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Adm_titcla_adct))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Adm_tiempo_adct":
                        #region ADM_TIEMPO_ADCT: Tiempos para atencion medica
                        lcrNombreCampo = "Tiempos para atencion medica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Adm_tiempo_adct))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Adm_imagen_adct":
                        #region ADM_IMAGEN_ADCT: Imagen (jpg)
                        lcrNombreCampo = "Imagen (jpg)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Adm_imagen_adct))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Adm_icolor_adct":
                        #region ADM_ICOLOR_ADCT: Color  clasificación
                        lcrNombreCampo = "Color  clasificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Adm_icolor_adct))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Adm_codoad_toad":
                        #region ADM_CODOAD_TOAD: Código Origen admisión
                        lcrNombreCampo = "Código Origen admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Adm_codoad_toad))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = ADMValidarCodigo.fobRegBuscarAdmviaingreso(G1Adm_codoad_toad);
                            if (tmp != null)
                            {
                                G1Adm_desoad_toad = tmp.adm_desoad_toad;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codare_aser":
                        #region SIA_CODARE_ASER: Código Área de servicios
                        lcrNombreCampo = "Código Área de servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Sia_codare_aser))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G1Sia_codare_aser);
                            if (tmp != null)
                            {
                                G1Sia_desare_aser = tmp.sia_desare_aser;
                                //G1Adm_codtat_tatn = tmp.adm_codtat_tatn;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_areing_aser":
                        #region SIA_AREING_ASER: Código Área de Ingreso
                        lcrNombreCampo = "Código Área de Ingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Sia_areing_aser))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G1Sia_areing_aser);
                            if (tmp != null)
                            {
                               // G1Sia_codare_aser = tmp.sia_codare_aser;
                                G1Desia_areing_aser = tmp.sia_desare_aser;
                                //G1Adm_codtat_tatn = tmp.adm_codtat_tatn;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codcpr_cpro":
                        #region FCM_CODCPR_CPRO: Centro producción
                        lcrNombreCampo = "Centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
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
                                //G1Sia_codare_aser = tmp.sia_codare_aser;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                   case "G1Adm_codtat_tatn":
                        #region ADM_CODTAT_TATN: Tipo ambito de atención
                        lcrNombreCampo = "Tipo ambito de atención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Adm_codtat_tatn))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = ADMValidarCodigo.fobRegBuscarAdmtipoatencion(G1Adm_codtat_tatn);
                            if (tmp != null)
                            {
                               G1Adm_destat_tatn = tmp.adm_destat_tatn;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_codcex_tcex":
                        #region ADM_CODCEX_TCEX: Causa Externa
                        lcrNombreCampo = "Causa Externa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
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

                    case "G1Adm_estreg_adct":
                        #region ADM_ESTREG_ADCT: Estado Registro
                        lcrNombreCampo = "Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (String.IsNullOrWhiteSpace(G1Adm_estreg_adct))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_estreg_adct, ",", "1,2"))
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
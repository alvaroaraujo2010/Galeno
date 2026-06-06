//- MARMOTA-GENCODE: VERSION 2.0 - 02/11/2016 10:38:25 PM
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
using Inventarios.Modelo;

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invalmacenmaest</para>
    /// <para>DESCRIPCION:
    ///  Registra todos los almacenes existentes dentro de la empresa
    /// </para>
    /// </summary>
    public class VistaModeloInvMaestroalmacen : VistaModeloInvMaestroalmacenBase
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
                    case "G1Inv_desalm_inal":
                        #region INV_DESALM_INAL: Descripción Almacén
                        lcrNombreCampo = "Descripción Almacén";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Inv_desalm_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Inv_desalm_inal))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_polpre_inal":
                        #region INV_POLPRE_INAL: Origen Gestion Precios
                        lcrNombreCampo = "Origen Gestion Precios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Inv_polpre_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_polpre_inal, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_polppi_inal":
                        #region INV_POLPPI_INAL: Politica precios
                        lcrNombreCampo = "Politica precios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Inv_polppi_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_polppi_inal, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                if (G1Inv_polpre_inal != "1")
                                {
                                    G1Inv_polppi_inal = "1";
                                }
                                else
                                {
                                    G1Inv_polppi_inal = "2";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_porive_inal":
                        #region INV_PORIVE_INAL: Procentaje incremento
                        lcrNombreCampo = "Procentaje incremento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (G1Inv_polpre_inal == "1")
                        {
                            if (G1Inv_porive_inal > 200 || G1Inv_porive_inal < -80)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Rango no es valido";
                            }
                        }
                        else
                        {
                            G1Inv_porive_inal = 0;
                        }
                        break;
                        #endregion

                    case "G1Inv_gesfar_inal":
                        #region INV_GESFAR_INAL: Formulas consulta externa
                        lcrNombreCampo = "Formulas consulta externa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Inv_gesfar_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_gesfar_inal, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_geshos_inal":
                        #region INV_GESHOS_INAL: Medicamentos intrahospitalarios
                        lcrNombreCampo = "Medicamentos intrahospitalarios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Inv_geshos_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_geshos_inal, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_genfac_inal":
                        #region INV_GENFAC_INAL: Facturacion medicamentos
                        lcrNombreCampo = "Facturacion medicamentos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Inv_genfac_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_genfac_inal, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codare_aser":
                        #region SIA_CODARE_ASER: Código área de servicios
                        lcrNombreCampo = "Código área de servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Sia_codare_aser))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (G1Inv_gesfar_inal == "2" && G1Inv_geshos_inal == "2")
                            {
                                G1Sia_codare_aser = "NA";
                            }
                            else
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G1Sia_codare_aser);
                                if (tmp != null)
                                {
                                    G1Sia_desare_aser = tmp.sia_desare_aser;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codcpr_cpro":
                        #region FCM_CODCPR_CPRO: Centro producción
                        lcrNombreCampo = "Centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codcpr_cpro))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (G1Inv_gesfar_inal == "2" && G1Inv_geshos_inal == "2")
                            {
                                G1Fcm_codcpr_cpro = "NA";
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
                        }
                        break;
                        #endregion

                    case "G1Sia_codcat_ceat":
                        #region SIA_CODCAT_CEAT: Código centro atención
                        lcrNombreCampo = "Código centro atención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Sia_codcat_ceat))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiacentroaten(G1Sia_codcat_ceat);
                            if (tmp != null)
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

                    case "G1Inv_estalm_inal":
                        #region INV_ESTALM_INAL: Estado del Almacén
                        lcrNombreCampo = "Estado del Almacén";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Inv_estalm_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_estalm_inal, ",", "1,2"))
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
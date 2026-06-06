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
    public class VistaModeloInvajusteconcep : VistaModeloInvajusteconcepBase
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
                    case "G1Inv_conaju_incp":
                        #region INV_CONAJU_INCP: Código Concepto Ajuste
                        lcrNombreCampo = "Código Concepto Ajuste";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(G1Inv_conaju_incp))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && INVValidarCodigo.flgBuscarInvajusteconcep(G1Inv_conaju_incp))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_desaju_incp":
                        #region INV_DESAJU_INCP: Descripción Contenedor
                        lcrNombreCampo = "Descripción concepto de Ajuste";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Inv_desaju_incp))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Inv_desaju_incp = G1Inv_desaju_incp.ToUpper();
                            if (G1Inv_desaju_incp.Trim().Length <= 2)
                            {
                                lcrValorReturn = lcrNombreCampo + ": No es valido pocos caracteres(" + G1Inv_desaju_incp.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Inv_desaju_incp, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                                }
                            }

                        }
                        break;
                        #endregion

                    case "G1Inv_tipaju_incp":
                        #region INV_TIPAJU_INCP: Tipo Ajuste
                        lcrNombreCampo = "Tipo ajuste";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Inv_tipaju_incp))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_tipaju_incp, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_conmov_incm":
                        #region INV_CONMOV_INCM: Concepto Movimiento
                        lcrNombreCampo = "Código Movimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Inv_conmov_incm))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Inv_conmov_incm = G1Inv_conmov_incm.ToUpper();
                            var tmp = INVValidarCodigo.fobRegBuscarInvtipoconcemov(G1Inv_conmov_incm);
                            if (tmp != null)
                            {
                                G1Inv_descon_incm = tmp.inv_descon_incm;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_estreg_incp":
                        #region INV_ESTREG_INCP: Estado del registro
                        lcrNombreCampo = "Estado del registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Inv_estreg_incp))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_estreg_incp, ",", "1,2"))
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

//- MARMOTA-GENCODE: VERSION 2.0 - 03/04/2017 08:07:10 PM
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
    /// <para>TABLA: invcontenedores</para>
    /// <para>DESCRIPCION:
    ///  Tabla que contiene los diferentes tipos de contenedores conocidos
    ///  o presentaciones de un Artículo: Caja Bolsas, Sacos,Bultos,Galones,Docena
    ///  s y otros.
    /// </para>
    /// </summary>
    public class VistaModeloInvcontenedores : VistaModeloInvcontenedoresBase
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
                    case "G1Inv_codctn_intc":
                        #region INV_CODCTN_INTC: Código Contenedor
                        lcrNombreCampo = "Código Contenedor";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(G1Inv_codctn_intc))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && INVValidarCodigo.flgBuscarInvcontenedores(G1Inv_codctn_intc))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos DDDDD";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_desctn_intc":
                        #region INV_DESCTN_INTC: Descripción Contenedor
                        lcrNombreCampo = "Descripción Contenedor";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Inv_desctn_intc))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (G1Inv_desctn_intc.Trim().Length <= 2)
                            {
                                lcrValorReturn = lcrNombreCampo + ": No es valido pocos caracteres(" + G1Inv_desctn_intc.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Inv_desctn_intc, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                                }
                            }

                        }
                        break;
                        #endregion

                    case "G1Inv_estreg_intc":
                        #region INV_ESTREG_INTC: Estado del registro
                        lcrNombreCampo = "Estado del registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Inv_estreg_intc))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_estreg_intc, ",", "1,2"))
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
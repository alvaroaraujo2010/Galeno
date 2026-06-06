//- MARMOTA-GENCODE: VERSION 2.0 - 16/08/2017 06:15:04 PM
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
    /// <para>TABLA: invperiodomaest</para>
    /// <para>DESCRIPCION:
    ///  Maestro gestion periodos inventario para control de cierres
    ///  y demas
    /// </para>
    /// </summary>
    public class VistaModeloInvperiodomaest : VistaModeloInvperiodomaestBase
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
                    case "G1Inv_codper_inpe":
                        #region INV_CODPER_INPE: Código periodo
                        //lcrNombreCampo = "Código periodo";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A03";
                        //if (String.IsNullOrWhiteSpace(G1Inv_codper_inpe))
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        //}
                        //else
                        //{
                        //    G1Inv_codper_inpe = G1Inv_codper_inpe.ToUpper();
                        //    if (GlgSIS_ModoAdicion == true && INVValidarCodigo.flgBuscarInvperiodomaest(G1Inv_codper_inpe))
                        //    {
                        //        lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                        //    }
                        //}
                        break;
                        #endregion

                    case "G1Inv_desper_inpe":
                        #region INV_DESPER_INPE: Descripcion
                        lcrNombreCampo = "Descripcion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Inv_desper_inpe))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                            G1Inv_desper_inpe = G1Inv_desper_inpe.ToUpper();
                        {
                        }
                        break;
                        #endregion

                    case "G1Inv_codalm_inal":
                        #region INV_CODALM_INAL: Código Almacén
                        lcrNombreCampo = "Código Almacén";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Inv_codalm_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvalmacenmaest(G1Inv_codalm_inal);
                            if (tmp != null)
                            {
                                G1Inv_desalm_inal = tmp.inv_desalm_inal;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_fecini_inpe":
                        #region INV_FECINI_INPE: Fecha inicio
                        lcrNombreCampo = "Fecha inicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Inv_fecini_inpe, "Fecha inicio");
                        break;
                        #endregion

                    case "G1Inv_fecfin_inpe":
                        #region INV_FECFIN_INPE: Fecha fin
                        lcrNombreCampo = "Fecha fin";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Inv_fecfin_inpe, "Fecha fin");
                        break;
                        #endregion

                    case "G1Inv_peract_inpe":
                        #region INV_PERACT_INPE: Estado
                        lcrNombreCampo = "Estado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Inv_peract_inpe))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_peract_inpe, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_estreg_inpe":
                        #region INV_ESTREG_INPE: Estado
                        lcrNombreCampo = "Estado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Inv_estreg_inpe))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_estreg_inpe, ",", "1,2"))
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
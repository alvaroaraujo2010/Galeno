//- MARMOTA-GENCODE: VERSION 2.0 - 13/04/2015 03:37:54 PM
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
using HistoriasClinicas.Modelo;

namespace HistoriasClinicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hcltiporegactiv</para>
    /// <para>DESCRIPCION:
    ///  Clasificacion del registro de actividad generada en el historial,
    ///  para actividades con caracterisiticas especiales, ejemplo :
    ///  apertura de historia clinica general -> APE-HCL-GENE =Apertura
    ///  historia clinica general
    /// </para>
    /// </summary>
    public class VistaModeloHcltiporegactiv : VistaModeloHcltiporegactivBase
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
                    case "G1Hcl_codreg_hcca":
                        #region HCL_CODREG_HCCA: Tipo registro actividad
                        lcrNombreCampo = "Tipo registro actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(G1Hcl_codreg_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Hcl_codreg_hcca = G1Hcl_codreg_hcca.ToUpper().Trim();
                            if (GlgSIS_ModoAdicion == true && HCLValidarCodigo.flgBuscarHcltiporegactiv(G1Hcl_codreg_hcca))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                            }
                            else if (G1Hcl_codreg_hcca.Trim().Length > 20)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Llave registro tiene demasiados caracteres (" + G1Hcl_codreg_hcca.Trim().Length + ")";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_desreg_hcca":
                        #region HCL_DESREG_HCCA: Descripcion tipo registro
                        lcrNombreCampo = "Descripcion tipo registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Hcl_desreg_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Grp_idepla_grpl":
                        #region GRP_IDEPLA_GRPL: Código único plantilla
                        lcrNombreCampo = "Código único plantilla";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Grp_idepla_grpl))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else if (G1Grp_idepla_grpl != "NA")
                        {
                            var tmp = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(G1Grp_idepla_grpl);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.grp_idepla_grpl))
                            {
                                G1Grp_despla_grpl = tmp.grp_despla_grpl;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sys_codtip_sytm":
                        #region SYS_CODTIP_SYTM: Codigo tipo de mensajes
                        lcrNombreCampo = "Codigo tipo de mensajes";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Sys_codtip_sytm))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else if (G1Sys_codtip_sytm != "NA")
                        {
                            var tmp = SYSValidarCodigo.fobRegBuscarSysadmstipomens(G1Sys_codtip_sytm);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sys_codtip_sytm))
                            {
                                G1Sys_desmsj_sytm = tmp.sys_desmsj_sytm;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_imagen_hcca":
                        #region HCL_IMAGEN_HCCA: Imagen (jpg)
                        lcrNombreCampo = "Imagen (jpg)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Hcl_imagen_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
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
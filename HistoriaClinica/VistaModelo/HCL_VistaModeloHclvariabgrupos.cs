//- MARMOTA-GENCODE: VERSION 2.0 - 01/07/2016 06:45:22 AM
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
using HistoriasClinicas.Modelo;

namespace HistoriasClinicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hclvariabgrupos</para>
    /// <para>DESCRIPCION:
    ///  Maestro grupos de variables publicas de historias clinicas,
    ///  para organización y visualizacion en formatos de impresion
    /// </para>
    /// </summary>
    public class VistaModeloHclvariabgrupos : VistaModeloHclvariabgruposBase
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
                    case "G1Hcl_desgru_hcgv":
                        #region HCL_DESGRU_HCGV: Descripcion grupo
                        lcrNombreCampo = "Descripcion grupo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Hcl_desgru_hcgv))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Hcl_desgru_hcgv = G1Hcl_desgru_hcgv.ToUpper();
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Hcl_desgru_hcgv, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_nomvar_hcgv":
                        #region HCL_NOMVAR_HCGV: Nombre variable
                        lcrNombreCampo = "Nombre variable";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Hcl_nomvar_hcgv))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Hcl_nomvar_hcgv = G1Hcl_nomvar_hcgv.Trim().ToUpper();
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Hcl_nomvar_hcgv, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                            }
                            var lcrCharIni = G1Hcl_nomvar_hcgv.Substring(0, 1);
                            if (!Funciones.flgExisteSubCadenaStringEx(lcrCharIni, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": El nombre de variable debe inciar con una letra";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_sisgru_hcgv":
                        #region HCL_SISGRU_HCGV: Grupo protegido
                        lcrNombreCampo = "Grupo protegido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Hcl_sisgru_hcgv))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_sisgru_hcgv, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_estreg_esrg":
                        #region SIS_ESTREG_ESRG: Código Estado Registro
                        lcrNombreCampo = "Código Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
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
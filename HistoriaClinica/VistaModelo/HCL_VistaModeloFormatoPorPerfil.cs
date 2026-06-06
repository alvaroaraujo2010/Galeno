//- MARMOTA-GENCODE: VERSION 2.0 - 12/12/2017 10:21:54 AM
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
    /// <para>TABLA: sysperfiusuario</para>
    /// <para>DESCRIPCION:
    ///  Tabla maestra para registrar perfiles de usuarios que creados
    ///  para gestión de datos en el sistema ejm: P01 =Súper Usuario
    ///  P02=Administrador  P03=Facturadores P04=Regente de farmacia
    /// </para>
    /// </summary>
    public class VistaModeloFormatoPorPerfil : VistaModeloFormatoPorPerfilBase
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
                    case "G1Sys_desper_perf":
                        #region SYS_DESPER_PERF: Nombre del Perfil
                        lcrNombreCampo = "Nombre del Perfil";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Sys_desper_perf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sys_rutimg_perf":
                        #region SYS_RUTIMG_PERF: Imagen de  Vista
                        lcrNombreCampo = "Imagen de  Vista";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Sys_rutimg_perf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sys_estper_perf":
                        #region SYS_ESTPER_PERF: Estado del perfil
                        lcrNombreCampo = "Estado del perfil";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Sys_estper_perf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_estper_perf, ",", "1,2"))
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
                    case "G2Hcl_codreg_hcca":
                        #region HCL_CODREG_HCCA: Tipo registro actividad
                        lcrNombreCampo = "Tipo registro actividad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B03";
                        if (String.IsNullOrWhiteSpace(G2Hcl_codreg_hcca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(G2Hcl_codreg_hcca);
                            if (tmp != null)
                            {
                                G2Hcl_desreg_hcca = tmp.hcl_desreg_hcca;
                                if ((flgCompararFormatos(G2Hcl_codreg_hcca) == true))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": El Formato ya existe en la grilla";
                                }
                            }
                            
                        }
                        break;
                        #endregion

                    case "G2Hcl_accvis_hcpr":
                        #region HCL_ACCVIS_HCPR: Acceso a vistia
                        lcrNombreCampo = "Acceso a vistia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";
                        if (String.IsNullOrWhiteSpace(G2Hcl_accvis_hcpr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_accvis_hcpr, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_accedt_hcpr":
                        #region HCL_ACCEDT_HCPR: Acceso a edicion
                        lcrNombreCampo = "Acceso a edicion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        if (String.IsNullOrWhiteSpace(G2Hcl_accedt_hcpr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_accedt_hcpr, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_accprn_hcpr":
                        #region HCL_ACCPRN_HCPR: Acceso a imprimir
                        lcrNombreCampo = "Acceso a imprimir";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (String.IsNullOrWhiteSpace(G2Hcl_accprn_hcpr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_accprn_hcpr, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_accges_hcpr":
                        #region HCL_ACCGES_HCPR: Acceso a funcionalidad
                        lcrNombreCampo = "Acceso a funcionalidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        if (String.IsNullOrWhiteSpace(G2Hcl_accges_hcpr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_accges_hcpr, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hcl_estfor_hcpr":
                        #region HCL_ESTFOR_HCPR: Estado formato
                        lcrNombreCampo = "Estado formato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B08";
                        if (String.IsNullOrWhiteSpace(G2Hcl_estfor_hcpr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hcl_estfor_hcpr, ",", "1,2"))
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
        #region flgCompararFormatos
        /// <summary>
        /// Comparar Los formatos guardados en la grilla con el que se esta
        /// ingresando.
        /// </summary>
        private bool flgCompararFormatos(String tcrCodigo)
        {

            var llgReturn = false;
            var lobjRegistro = TmpG2ListaBrow.FirstOrDefault(p => p.Hcl_codreg_hcca == tcrCodigo);
            if (lobjRegistro != null)
            {
                if (lobjRegistro != TmpG2RegActivo)
                {
                    llgReturn = true;
                }
            }
            return llgReturn;
        }
        #endregion
    }
}
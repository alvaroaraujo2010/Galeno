//- MARMOTA-GENCODE: VERSION 2.0 - 29/11/2018 04:41:42 PM
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
using Systemas.Modelo;

namespace Systemas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sysusuarios</para>
    /// <para>DESCRIPCION:
    ///  Maestro de Usuarios del Sistema a quienes se les asignan perfiles
    ///  para  realizar acciones o  ejecutan módulos
    /// </para>
    /// </summary>
    public class VistaModeloSysusuarios : VistaModeloSysusuariosBase
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
                    case "G1Sys_ideusu_usux":
                        #region SYS_IDEUSU_USUX: ID del  Usuario
                        lcrNombreCampo = "ID del Usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Sys_ideusu_usux))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SYSValidarCodigo.fobRegBuscarSysusuariosCx(G1Sys_ideusu_usux);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.sys_ideusu_usux))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                    }                                     
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sys_nomusu_usux":
                        #region SYS_NOMUSU_USUX: Nombre Usuario
                        lcrNombreCampo = "Nombre Usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Sys_nomusu_usux))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sys_clausu_usux":
                        #region SYS_CLAUSU_USUX: Clave del Usuario
                        //     lcrNombreCampo = "Clave del Usuario";
                        //     lcrValorReturn = String.Empty;
                        //     lcrCodigoError = "A04";
                        // 	if (String.IsNullOrWhiteSpace(G1Sys_clausu_usux))
                        // 	{
                        // 	   	lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        // 	}
                        // 	else
                        // 	{
                        // 	}
                        break;
                        #endregion

                    case "lcrTmpClave":
                        #region lcrTmpClave: Digite la Clave
                        lcrNombreCampo = "Confirmar Clave";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (string.IsNullOrWhiteSpace(lcrTmpClave))
                        {
                            lcrValorReturn = "Clave del Usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "lcrTmpConfirmar":
                        #region lcrTmpConfirmar: Confirmar la Clave
                        lcrNombreCampo = "Confirmar Clave";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (string.IsNullOrWhiteSpace(lcrTmpConfirmar))
                        {
                            lcrValorReturn = "Confirmar Clave: Es requerido";
                        }
                        else
                        {
                            if (lcrTmpConfirmar != lcrTmpClave)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Las claves no son iguales";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sys_codper_perf":
                        #region SYS_CODPER_PERF: Código del Perfil
                        lcrNombreCampo = "Código del Perfil";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Sys_codper_perf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SYSValidarCodigo.fobRegBuscarSysperfiusuario(G1Sys_codper_perf);
                            if (tmp != null)
                            {
                                G1Sys_desper_perf = tmp.sys_desper_perf;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sys_imagen_usux":
                        #region SYS_IMAGEN_USUX: Imagen usuario
                        //    lcrNombreCampo = "Imagen usuario";
                        //    lcrValorReturn = String.Empty;
                        //    lcrCodigoError = "A08";
                        //	if (String.IsNullOrWhiteSpace(G1Sys_imagen_usux))
                        //	{
                        //	   	lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        //	}
                        //	else
                        //	{
                        //	}
                        break;
                        #endregion

                    case "G1Sys_estusu_usux":
                        #region SYS_ESTUSU_USUX: Estado Usuario
                        lcrNombreCampo = "Estado Usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Sys_estusu_usux))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sys_estusu_usux, ",", "1,2"))
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
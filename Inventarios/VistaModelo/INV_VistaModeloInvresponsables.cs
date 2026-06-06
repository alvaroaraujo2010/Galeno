//- MARMOTA-GENCODE: VERSION 2.0 - 06/06/2017 12:50:34 PM
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
    /// <para>TABLA: invresponsables</para>
    /// <para>DESCRIPCION:
    ///  Tabla personas responsables en proceso de gestion en el modulo
    ///  inventarios, persona que solicita pedido para gasto interno
    ///  de la empresa y otros procesos
    /// </para>
    /// </summary>
    public class VistaModeloInvresponsables : VistaModeloInvresponsablesBase
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
                    case "G1Inv_nroide_inre":
                        #region INV_NROIDE_INRE: Identificacion
                        lcrNombreCampo = "Identificacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Inv_nroide_inre))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Inv_nomres_inre":
                        #region INV_NOMRES_INRE: Persona responsable
                        lcrNombreCampo = "Persona responsable";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Inv_nomres_inre))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Inv_telefo_inre":
                        #region INV_TELEFO_INRE: Teléfonos
                        lcrNombreCampo = "Teléfonos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Inv_telefo_inre))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Inv_dirres_inre":
                        #region INV_DIRRES_INRE: Dirección recidencia
                        lcrNombreCampo = "Dirección recidencia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Inv_dirres_inre))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Inv_correo_inre":
                        #region INV_CORREO_INRE: Correo electronico
                        lcrNombreCampo = "Correo electronico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Inv_correo_inre))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sys_codusu_usux":
                        #region SYS_CODUSU_USUX: Usuario del sistema
                        lcrNombreCampo = "Usuario del sistema";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Sys_codusu_usux))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SYSValidarCodigo.fobRegBuscarSysusuarios(G1Sys_codusu_usux);
                            if (tmp != null)
                            {
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_estreg_inre":
                        #region INV_ESTREG_INRE: Estado del registro
                        lcrNombreCampo = "Estado del registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Inv_estreg_inre))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_estreg_inre, ",", "1,2"))
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
//- MARMOTA-GENCODE: VERSION 2.0 - 25/07/2015 09:54:29 PM
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
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hosconfigmodulo</para>
    /// <para>DESCRIPCION:
    ///  Configuración parametros generales de funcionamiento modulo
    ///  hospitalización
    /// </para>
    /// </summary>
    public class VistaModeloHosconfigmodulo : VistaModeloHosconfigmoduloBase
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
                    case "G1Hos_codsys_hoxx":
                        #region HOS_CODSYS_HOXX: Codigo configuración
                        lcrNombreCampo = "Codigo configuración";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(G1Hos_codsys_hoxx))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && HOSValidarCodigo.flgBuscarHosconfigmodulo(G1Hos_codsys_hoxx))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hos_epicri_hoxx":
                        #region HOS_EPICRI_HOXX: Gestión epicrisis
                        lcrNombreCampo = "Gestión epicrisis";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Hos_epicri_hoxx))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hos_epicri_hoxx, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hos_epicrh_hoxx":
                        #region HOS_EPICRH_HOXX: Horas estancia epicrisis
                        lcrNombreCampo = "Horas estancia epicrisis";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (G1Hos_epicrh_hoxx <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Hos_autegr_hoxx":
                        #region HOS_AUTEGR_HOXX: Autorización egreso
                        lcrNombreCampo = "Autorización egreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Hos_autegr_hoxx))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hos_autegr_hoxx, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hos_format_hoxx":
                        #region HOS_FORMAT_HOXX: Gestion formatos
                        lcrNombreCampo = "Gestion formatos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Hos_format_hoxx))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hos_format_hoxx, ",", "1,2"))
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
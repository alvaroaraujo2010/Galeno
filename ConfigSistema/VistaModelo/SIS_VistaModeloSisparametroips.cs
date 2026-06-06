//- MARMOTA-GENCODE: VERSION 2.0 - 01/04/2015 06:54:54 PM
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
using Systemas.Modelo;

namespace Systemas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sisparametroips</para>
    /// <para>DESCRIPCION:
    ///  Registro maestro para configracion de datos basicos IPS tales
    ///  como:  razon social Nit codigo prestador logotipo eslogan y
    ///  mas
    /// </para>
    /// </summary>
    public class VistaModeloSisparametroips : VistaModeloSisparametroipsBase
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
                    case "G1Sis_idereg_pips":
                        #region SIS_IDEREG_PIPS: Codigo registro
                        lcrNombreCampo = "Codigo registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(G1Sis_idereg_pips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sis_razsoc_pips":
                        #region SIS_RAZSOC_PIPS: Razon social
                        lcrNombreCampo = "Razon social";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Sis_razsoc_pips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_nitips_pips":
                        #region SIS_NITIPS_PIPS: Numero Nit
                        lcrNombreCampo = "Numero Nit";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Sis_nitips_pips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_codips_pips":
                        #region SIS_CODIPS_PIPS: Codigo Prestador IPS
                        lcrNombreCampo = "Codigo Prestador IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Sis_codips_pips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_nitipx_pips":
                        #region SIS_NITIPX_PIPS: Nit  con separadores
                        lcrNombreCampo = "Nit  con separadores";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Sis_nitipx_pips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_dirips_pips":
                        #region SIS_DIRIPS_PIPS: Direccion
                        lcrNombreCampo = "Direccion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Sis_dirips_pips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_telefo_pips":
                        #region SIS_TELEFO_PIPS: Telefono
                        lcrNombreCampo = "Telefono";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Sis_telefo_pips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_nomdpt_pips":
                        #region SIS_NOMDPT_PIPS: Departamento
                        lcrNombreCampo = "Departamento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Sis_nomdpt_pips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_nommun_pips":
                        #region SIS_NOMMUN_PIPS: Ciudad
                        lcrNombreCampo = "Ciudad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Sis_nommun_pips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_eslog_pips":
                        #region SIS_ESLOG_PIPS: Eslogan IPS
                        lcrNombreCampo = "Eslogan IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Sis_eslog_pips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_logtip_pips":
                        #region SIS_LOGTIP_PIPS: Logotipo
                        lcrNombreCampo = "Logotipo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Sis_logtip_pips))
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
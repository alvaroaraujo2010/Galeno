//- MARMOTA-GENCODE: VERSION 2.0 - 09/08/2015 10:58:48 AM
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
using ConfigAsistencial.Modelo;

namespace ConfigAsistencial.VistaModelo
{
    /// <summary>
    /// <para>TABLA: siatablaeps</para>
    /// <para>DESCRIPCION:
    ///  Lista Codigos y nombres  de EPS contributivo, subsidiado y
    ///  Aseguradores, direcciones departamentales de salud  según
    ///  la supersalud
    /// </para>
    /// </summary>
    public class VistaModeloSiatablaeps : VistaModeloSiatablaepsBase
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
                    case "G1Sia_codeps_teps":
                        #region SIA_CODEPS_TEPS: Código EPS
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && SIAValidarCodigo.flgBuscarSiatablaeps(G1Sia_codeps_teps))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codnit_teps":
                        #region SIA_CODNIT_TEPS: Numero Nit EPS
                        lcrNombreCampo = "Numero Nit EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Sia_codnit_teps))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sia_deseps_teps":
                        #region SIA_DESEPS_TEPS: Nombre EPS
                        lcrNombreCampo = "Nombre EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Sia_deseps_teps))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sia_tipase_sita":
                        #region SIA_TIPASE_SITA: Código tipo asegurador
                        lcrNombreCampo = "Código tipo asegurador";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Sia_tipase_sita))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatipoasegurad(G1Sia_tipase_sita);
                            if (tmp != null)
                            {
                                G1Sia_desase_sita = tmp.sia_desase_sita;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
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
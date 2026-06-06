//- MARMOTA-GENCODE: VERSION 2.0 - 10/01/2018 06:16:06 PM
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
using ConfigAsistencial.Modelo;

namespace ConfigAsistencial.VistaModelo
{
    /// <summary>
    /// <para>TABLA: siadiagnosticos</para>
    /// <para>DESCRIPCION:
    /// Talba de diagnositicos CIE-10
    /// </para>
    /// </summary>
    public class VistaModeloSiaDiagnosticos : VistaModeloSiaDiagnosticosBase
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
                    case "G1Sia_coddia_tdia":
                        #region SIA_CODDIA_TDIA: Codgo Diagnostico
                        lcrNombreCampo = "Codgo Diagnostico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(G1Sia_coddia_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && SIAValidarCodigo.flgBuscarSiadiagnosticos(G1Sia_coddia_tdia))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                            }
                        }
                        break;
                        #endregion                   

                    case "G1Sia_desdia_tdia":
                        #region SIA_DESDIA_TDIA: Descripcion diagnostico
                        lcrNombreCampo = "Descripcón diagnostico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Sia_desdia_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sia_desaux_tdia":
                        #region SIA_DESAUX_TDIA: Descripcion auxiliar
                        lcrNombreCampo = "Descripcion auxiliar";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sia_desaux_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        */
                        break;
                        #endregion

                    case "G1Sia_altcos_tdia":
                        #region SIA_ALTCOS_TDIA: Alto Costo SI/No
                        lcrNombreCampo = "Alto Costo SI/No";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Sia_altcos_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_altcos_tdia, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_notifc_tdia":
                        #region SIA_NOTIFC_TDIA: Notificacion obligatoria
                        lcrNombreCampo = "Notificacion obligatoria";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Sia_notifc_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_notifc_tdia, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_sexapl_tdia":
                        #region SIA_SEXAPL_TDIA: Sexo al que aplica
                        lcrNombreCampo = "Sexo al que aplica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Sia_sexapl_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Sia_sexapl_tdia = G1Sia_sexapl_tdia.ToUpper();
                            if (!Funciones.flgExisteElemento(G1Sia_sexapl_tdia, ",", "A,M,F"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_edaini_tdia":
                        #region SIA_EDAINI_TDIA: Edad inicial
                        lcrNombreCampo = "Edad inicial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (G1Sia_edaini_tdia <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Sia_edaini_tdia < 0 || G1Sia_edaini_tdia > 99)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_medini_tdia":
                        #region SIA_MEDINI_TDIA: Medida edad inicial
                        lcrNombreCampo = "Medida edad inicial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Sia_medini_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_medini_tdia, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_edafin_tdia":
                        #region SIA_EDAFIN_TDIA: Edad final
                        lcrNombreCampo = "Edad final";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (G1Sia_edafin_tdia <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Sia_edafin_tdia < 0 || G1Sia_edafin_tdia > 999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_medfin_tdia":
                        #region SIA_MEDFIN_TDIA: Medida endad final
                        lcrNombreCampo = "Medida endad final";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Sia_medfin_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_medfin_tdia, ",", "1,2,3"))
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

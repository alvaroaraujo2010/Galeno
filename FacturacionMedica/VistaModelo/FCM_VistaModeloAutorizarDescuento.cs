//- MARMOTA-GENCODE: VERSION 2.0 - 24/04/2015 05:04:20 PM
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
using FacturacionMedica.Modelo;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: fcmdescueautori</para>
    /// <para>DESCRIPCION:
    ///  Maestro para registrar los descuentos solicitados y  autorizados
    ///  en pagos de servicios, copagos y otros
    /// </para>
    /// </summary>
    public class VistaModeloAutorizarDescuento : VistaModeloAutorizarDescuentoBase
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
                    case "G4Fcm_fecaut_ades":
                        #region FCM_FECAUT_ADES: Fecha autorización
                        lcrNombreCampo = "Fecha autorización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G4Fcm_fecaut_ades, "Fecha autorización");
                        break;
                        #endregion

                    case "G4Fcm_horaut_ades":
                        #region FCM_HORAUT_ADES: Hora autorización
                        lcrNombreCampo = "Hora autorización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G4Fcm_horaut_ades, "12", ":", "Hora autorización");
                        break;
                        #endregion

                    case "G4Fcm_notaut_ades":
                        #region FCM_NOTAUT_ADES: Nota
                        lcrNombreCampo = "Observación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (String.IsNullOrWhiteSpace(G4Fcm_notaut_ades))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G4Fcm_valdes_dfac":
                        #region FCM_VALDES_DFAC: Descuento autorizado
                        lcrNombreCampo = "Descuento autorizado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (G4Fcm_valdes_dfac <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else if (G4Fcm_valdes_dfac > G4Fcm_valref_dfac)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es mayor que valor a cobrar sin descuento";
                        }
                        else 
                        {
                            G4Fcm_valefe_dfac = G4Fcm_valref_dfac - G4Fcm_valdes_dfac;
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
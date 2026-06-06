//- MARMOTA-GENCODE: VERSION 2.0 - 27/04/2015 05:12:42 PM
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
using Meci.Modelo;

namespace Meci.VistaModelo
{
    /// <summary>
    /// <para>TABLA: mcievaluacionms</para>
    /// <para>DESCRIPCION:
    ///  Tabla para almacenar las evaluaciones que se realizan con una
    ///  plantilla MECI en el sistema
    /// </para>
    /// </summary>
    public class VistaModeloMcievaluacionms : VistaModeloMcievaluacionmsBase
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
                    case "G1Mci_deseva_mcms":
                        #region MCI_DESEVA_MCMS: Evaluación
                        lcrNombreCampo = "Evaluación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Mci_deseva_mcms))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Mci_feceva_mcms":
                        #region MCI_FECEVA_MCMS: Fecha
                        lcrNombreCampo = "Fecha";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Mci_feceva_mcms, "Fecha");
                        break;
                        #endregion

                    case "G1Mci_idepla_mcpl":
                        #region MCI_IDEPLA_MCPL: Plantilla
                        lcrNombreCampo = "Plantilla";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Mci_idepla_mcpl))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = MCIValidarCodigo.fobRegBuscarMciplantillmeci(G1Mci_idepla_mcpl);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.mci_idesec_mcpl))
                            {
                                G1Mci_despla_mcpl = tmp.mci_despla_mcpl;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Mci_estreg_mcms":
                        #region MCI_ESTREG_MCMS: Estado Evaluación
                        lcrNombreCampo = "Estado Evaluación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Mci_estreg_mcms))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Mci_estreg_mcms, ",", "1,2"))
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
//- MARMOTA-GENCODE: VERSION 2.0 - 23/04/2015 05:16:13 PM
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
    /// <para>TABLA: mcicomponenmeci</para>
    /// <para>DESCRIPCION:
    ///  Tabla para los componentes pertenecientes a los módulos de
    ///  las plantillas de evaluaciones del MECI
    /// </para>
    /// </summary>
    public class VistaModeloMcicomponenmeci : VistaModeloMcicomponenmeciBase
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
                    case "G1Mci_idesec_mcpl":
                        #region MCI_IDESEC_MCPL: Código Plantilla
                        lcrNombreCampo = "Código Plantilla";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Mci_idesec_mcpl))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Mci_idesec_mcmo":
                        #region MCI_IDESEC_MCMO: Código Módulo
                        lcrNombreCampo = "Código Módulo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Mci_idesec_mcmo))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = MCIValidarCodigo.fobRegBuscarMcimoduloevmeci(G1Mci_idesec_mcmo);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.mci_idesec_mcmo))
                            {
                                G1Mci_idesec_mcpl = tmp.mci_idesec_mcpl;
                                G1Mci_desmod_mcmo = tmp.mci_desmod_mcmo;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Mci_etqcom_mcco":
                        #region MCI_ETQCOM_MCCO: Etiqueta Componente
                        lcrNombreCampo = "Etiqueta Componente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Mci_etqcom_mcco))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Mci_descom_mcco":
                        #region MCI_DESCOM_MCCO: Descripción Componente
                        lcrNombreCampo = "Descripción Componente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Mci_descom_mcco))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Mci_ordvis_mcco":
                        #region MCI_ORDVIS_MCCO: Orden Vista
                        lcrNombreCampo = "Orden Vista";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (G1Mci_ordvis_mcco<=0)
                    	{
                    	   	lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                    	}
                    	else
                    	{
                    	}
                    	break;
                        #endregion

                    case "G1Mci_estreg_mcco":
                        #region MCI_ESTREG_MCCO: Estado del Componente
                        lcrNombreCampo = "Estado del Componente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Mci_estreg_mcco))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Mci_estreg_mcco, ",", "1,2"))
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
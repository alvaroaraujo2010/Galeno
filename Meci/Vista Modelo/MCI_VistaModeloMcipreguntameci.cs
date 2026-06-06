//- MARMOTA-GENCODE: VERSION 2.0 - 24/04/2015 10:08:52 PM
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
    /// <para>TABLA: mcipreguntameci</para>
    /// <para>DESCRIPCION:
    ///  Tabla para las preguntas de un grupo en los parámetros dentro
    ///  de los componentes pertenecientes a los módulos de las plantillas
    ///  de evaluaciones del MECI
    /// </para>
    /// </summary>
    public class VistaModeloMcipreguntameci : VistaModeloMcipreguntameciBase
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
                        }
                        break;
                        #endregion

                    case "G1Mci_idesec_mcco":
                        #region MCI_IDESEC_MCCO: Código de Componente
                        lcrNombreCampo = "Código de Componente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Mci_idesec_mcco))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Mci_idesec_mcpa":
                        #region MCI_IDESEC_MCPA: Código de Parámetro
                        lcrNombreCampo = "Código de Parámetro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Mci_idesec_mcpa))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Mci_idesec_mcgr":
                        #region MCI_IDESEC_MCGR: Código de Grupo
                        lcrNombreCampo = "Código de Grupo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Mci_idesec_mcgr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = MCIValidarCodigo.fobRegBuscarMcigrupoprgmeci(G1Mci_idesec_mcgr);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.mci_idesec_mcgr))
                            {
                                G1Mci_idesec_mcpl = tmp.mci_idesec_mcpl;
                                G1Mci_idesec_mcmo = tmp.mci_idesec_mcmo;
                                G1Mci_idesec_mcco = tmp.mci_idesec_mcco;
                                G1Mci_idesec_mcpa = tmp.mci_idesec_mcpa;
                                G1Mci_desgrp_mcgr = tmp.mci_desgrp_mcgr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Mci_etqpre_mcpr":
                        #region MCI_ETQPRE_MCPR: Etiqueta Pregunta
                        lcrNombreCampo = "Etiqueta Pregunta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Mci_etqpre_mcpr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Mci_despre_mcpr":
                        #region MCI_DESPRE_MCPR: Descripción Pregunta
                        lcrNombreCampo = "Descripción Pregunta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Mci_despre_mcpr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Mci_ordvis_mcpr":
                        #region MCI_ORDVIS_MCPR: Orden Vista
                        lcrNombreCampo = "Orden Vista";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (G1Mci_ordvis_mcpr <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Mci_estreg_mcpr":
                        #region MCI_ESTREG_MCPR: Estado del Pregunta
                        lcrNombreCampo = "Estado del Pregunta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Mci_estreg_mcpr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Mci_estreg_mcpr, ",", "1,2"))
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
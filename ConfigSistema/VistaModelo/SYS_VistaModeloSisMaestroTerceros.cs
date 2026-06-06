//- MARMOTA-GENCODE: VERSION 2.0 - 04/10/2017 11:50:03 AM
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
    /// <para>TABLA: sismaesterceros</para>
    /// <para>DESCRIPCION:
    ///  Tabla terceros para gestion contable y referencias en otros
    ///  modulos del sistema
    /// </para>
    /// </summary>
    public class VistaModeloSisMaestroTerceros : VistaModeloSisMaestroTercerosBase
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
                    case "G1Sis_tipide_tido":
                        #region SIS_TIPIDE_TIDO: Tipo documento
                        lcrNombreCampo = "Tipo documento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Sis_tipide_tido))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSistipidtercer(G1Sis_tipide_tido);
                            if (tmp != null)
                            {
                                G1Sis_deside_tido = tmp.sis_deside_tido;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_numide_sitr":
                        #region SIS_NUMIDE_SITR: Numero dcumento
                        lcrNombreCampo = "Numero dcumento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Sis_numide_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSismaesterceros(G1Sis_numide_sitr);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.sis_idterc_sitr))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G1Sis_idterc_sitr != tmp.sis_idterc_sitr) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_lugexp_sitr":
                        #region SIS_LUGEXP_SITR: Lugar exped documento
                        lcrNombreCampo = "Lugar exped documento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sis_lugexp_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        */
                        break;
                        #endregion

                    case "G1Sis_priape_sitr":
                        #region SIS_PRIAPE_SITR: Primer apellido
                        lcrNombreCampo = "Primer apellido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sis_priape_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        */
                        break;
                        #endregion

                    case "G1Sis_segape_sitr":
                        #region SIS_SEGAPE_SITR: Segundo apellido
                        lcrNombreCampo = "Segundo apellido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sis_segape_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        */
                        break;
                        #endregion

                    case "G1Sis_prinom_sitr":
                        #region SIS_PRINOM_SITR: Primer nombre
                        lcrNombreCampo = "Primer nombre";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sis_prinom_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        */
                        break;
                        #endregion

                    case "G1Sis_segnom_sitr":
                        #region SIS_SEGNOM_SITR: Segundo nombre
                        lcrNombreCampo = "Segundo nombre";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sis_segnom_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        */
                        break;
                        #endregion

                    case "G1Sis_razsoc_sitr":
                        #region SIS_RAZSOC_SITR: Nombre / Razon social
                        lcrNombreCampo = "Nombre / Razon social";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Sis_razsoc_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sis_tipper_sitr":
                        #region SIS_TIPPER_SITR: Tipo Persona
                        lcrNombreCampo = "Tipo Persona";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Sis_tipper_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sis_tipper_sitr, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_idemun_muni":
                        #region SIS_IDEMUN_MUNI: Id Unico Municipio
                        lcrNombreCampo = "Id Unico Municipio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Sis_idemun_muni))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSistabmunicipio(G1Sis_idemun_muni);
                            if (tmp != null)
                            {
                                G1Sis_codmun_muni = tmp.sis_codmun_muni;
                                G1Sis_coddep_dpto = tmp.sis_coddep_dpto;
                                G1Sis_nommun_muni = tmp.sis_nommun_muni;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_codmun_muni":
                        #region SIS_CODMUN_MUNI: Codigo Municipio
                        lcrNombreCampo = "Codigo Municipio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sis_codmun_muni))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        */
                        break;
                        #endregion

                    case "G1Sis_coddep_dpto":
                        #region SIS_CODDEP_DPTO: Codigo Dpartamento
                        lcrNombreCampo = "Codigo Dpartamento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Sis_coddep_dpto))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSistabdepartame(G1Sis_coddep_dpto);
                            if (tmp != null)
                            {
                                G1Sis_desdep_dpto = tmp.sis_desdep_dpto;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_codact_sitr":
                        #region SIS_CODACT_SITR: Codigo actividad economica
                        lcrNombreCampo = "Codigo actividad economica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sis_codact_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        */
                        break;
                        #endregion

                    case "G1Sis_tipcnt_sitr":
                        #region SIS_TIPCNT_SITR: Regimen contribuyente
                        lcrNombreCampo = "Regimen contribuyente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sis_tipcnt_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sis_tipcnt_sitr, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        */
                        break;
                        #endregion

                    case "G1Sis_relret_sitr":
                        #region SIS_RELRET_SITR: Ralizar retención
                        lcrNombreCampo = "Ralizar retención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sis_relret_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sis_relret_sitr, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        */
                        break;
                        #endregion

                    case "G1Sis_tipter_tter":
                        #region SIS_TIPTER_TTER: Tipo contribuyente
                        lcrNombreCampo = "Tipo contribuyente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Sis_tipter_tter))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sis_tipter_tter, ",", "1,2,3,4,5,6"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        */
                        break;
                        #endregion

                    case "G1Sis_telefo_sitr":
                        #region SIS_TELEFO_SITR: Telefono
                        lcrNombreCampo = "Telefono";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (String.IsNullOrWhiteSpace(G1Sis_telefo_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_direcc_sitr":
                        #region SIS_DIRECC_SITR: Direccion
                        lcrNombreCampo = "Direccion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (String.IsNullOrWhiteSpace(G1Sis_direcc_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_estreg_esrg":
                        #region SIS_ESTREG_ESRG: Estado
                        lcrNombreCampo = "Estado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (String.IsNullOrWhiteSpace(G1Sis_estreg_esrg))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sis_estreg_esrg, ",", "1,2"))
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
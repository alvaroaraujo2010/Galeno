//- MARMOTA-GENCODE: VERSION 2.0 - 19/04/2015 11:36:29 AM
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
using ContratoAseguramiento.Modelo;

namespace ContratoAseguramiento.VistaModelo
{
    /// <summary>
    /// <para>TABLA: ctomaescontrato</para>
    /// <para>DESCRIPCION:
    ///  Maestro de contratos con las EPS o aseguradores para servicios
    ///  de salud, incluye todas las condiciones del contrato
    /// </para>
    /// </summary>
    public class VistaModeloCtomaestrocontratos : VistaModeloCtomaestrocontratosBase
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
            bool llgValidDefault = false;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Fcm_secraz_fcem":
                        #region FCM_SECRAZ_FCEM: Razon social Empresa
                        lcrNombreCampo = "Razon social Empresa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "AO1";
                        if (String.IsNullOrWhiteSpace(G1Fcm_secraz_fcem))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerida";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.FobRegBuscarFcmfemaesrazsocma(G1Fcm_secraz_fcem);
                            if (tmp != null)
                            {
                                if (tmp.fcm_estreg_fcem.Trim() != "1")
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Se encuentra en estado inactiva";
                                }
                                else
                                {
                                    G1Fcm_nomcom_fcem = tmp.fcm_nomcom_fcem;
                                    G1Fcm_numdoc_fcem = tmp.fcm_numdoc_fcem;
                                    //G1Fcm_secres_srfa = tmp.fcm_secres_srfa;
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                    #endregion

                    case "G1Fcm_numdoc_fcem":
                        #region FCM_NUMDOC_FCEM: Numero Documento Nit Empresa
                        lcrNombreCampo = "Numero Documento Nit Empresa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(G1Fcm_numdoc_fcem))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.FobRegBuscarFcmfemaesrazsocmaNIT(G1Fcm_numdoc_fcem);
                            if (tmp != null)
                            {
                                if (tmp.fcm_estreg_fcem.Trim() != "1")
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Se encuentra en estado inactivo";
                                }
                                else
                                {

                                    G1Fcm_nomcom_fcem = tmp.fcm_nomcom_fcem;
                                    G1Fcm_secraz_fcem = tmp.fcm_secraz_fcem;
                                    //G1Fcm_secres_srfa = tmp.fcm_secres_srfa;
                                    fcrValidacion("G1Fcm_secraz_fcem");
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                    #endregion

                    case "G1Cto_nrocon_cont":
                        #region CTO_NROCON_CONT: Número Contrato
                        lcrNombreCampo = "Número Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Cto_nrocon_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_nrocon_cont);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.cto_seccon_cont))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G1Cto_seccon_cont != tmp.cto_seccon_cont) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_modeps_cont":
                        #region CTO_MODEPS_CONT: Modificar código EPS
                        lcrNombreCampo = "Modificar código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Cto_modeps_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_modeps_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codeps_teps":
                        #region SIA_CODEPS_TEPS: Código EPS
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codeps_teps))
                            {
                                G1Sia_deseps_teps = tmp.sia_deseps_teps;                                
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_idterc_sitr":
                        #region SIS_IDTERC_SITR: Código tercero (contable)
                        lcrNombreCampo = "Código tercero (contable)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Sis_idterc_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSismaesterceros(G1Sis_idterc_sitr);
                            if (tmp != null)
                            {
                                G1Sis_razsoc_sitr = tmp.sis_razsoc_sitr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_fecico_cont":
                        #region CTO_FECICO_CONT: Fecha Inicio vigencia
                        lcrNombreCampo = "Fecha Inicio vigencia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Cto_fecico_cont, "Fecha Inicio vigencia");
                        break;
                        #endregion

                    case "G1Cto_fecfco_cont":
                        #region CTO_FECFCO_CONT: Fecha fin vigencia
                        lcrNombreCampo = "Fecha fin vigencia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Cto_fecfco_cont, "Fecha fin vigencia");
                        break;
                        #endregion

                    case "G1Cto_descon_cont":
                        #region CTO_DESCON_CONT: Descripción contrato
                        lcrNombreCampo = "Descripción contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Cto_descon_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Cto_descon_cont = G1Cto_descon_cont.ToUpper();
                        }
                        break;
                        #endregion

                    case "G1Fcm_codman_mans":
                        #region FCM_CODMAN_MANS: Código manual servicios
                        lcrNombreCampo = "Código manual servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codman_mans))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmantarifario(G1Fcm_codman_mans);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codman_mans))
                            {
                                G1Fcm_desman_mans = tmp.fcm_desman_mans;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_plaben_cont":
                        #region CTO_PLABEN_CONT: Plan de beneficios
                        lcrNombreCampo = "Plan de beneficios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Cto_plaben_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sia_tipusu_regi":
                        #region SIA_TIPUSU_REGI: Tipo población Cubierta
                        lcrNombreCampo = "Tipo población Cubierta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Sia_tipusu_regi))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaregimensalud(G1Sia_tipusu_regi);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipusu_regi))
                            {
                                G1Sia_destip_regi = tmp.sia_destip_regi;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_polcon_cont":
                        #region CTO_POLCON_CONT: Numero Póliza del contrato
                        lcrNombreCampo = "Numero Póliza del contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (!String.IsNullOrWhiteSpace(G1Cto_polcon_cont))
                        {
                            G1Cto_polcon_cont = G1Cto_polcon_cont.ToUpper();
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Cto_polcon_cont, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789-"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_codtco_cont":
                        #region CTO_CODTCO_CONT: Contrato Capitado/Evento
                        lcrNombreCampo = "Contrato Capitado/Evento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Cto_codtco_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_codtco_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_tipact_cont":
                        #region CTO_TIPACT_CONT: Contrato Asistencial/PyP
                        lcrNombreCampo = "Contrato Asistencial/PyP";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (String.IsNullOrWhiteSpace(G1Cto_tipact_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_tipact_cont, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_sepser_cont":
                        #region CTO_SEPSER_CONT: Separar Asistencial y PyP
                        lcrNombreCampo = "Separar Asistencial y PyP";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (String.IsNullOrWhiteSpace(G1Cto_sepser_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_sepser_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_gruite_cont":
                        #region CTO_GRUITE_CONT: Agrupar facturas
                        lcrNombreCampo = "Agrupar facturas";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (String.IsNullOrWhiteSpace(G1Cto_gruite_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_gruite_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_fcdian_cont":
                        #region CTO_FCDIAN_CONT: Secuencial facturas DIAN
                        lcrNombreCampo = "Secuencial facturas DIAN";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (String.IsNullOrWhiteSpace(G1Cto_fcdian_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_fcdian_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_ajupre_cont":
                        #region CTO_AJUPRE_CONT: Ajuste precio servicios
                        lcrNombreCampo = "Valor ajuste o redondeo precio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (G1Cto_ajupre_cont < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser cero o mayor que cero";
                        }
                        else if (G1Cto_ajupre_cont >= 0)
                        {
                            if (G1Cto_ajupre_cont > 0)
                            {
                                var lnuUnidades = (int)(G1Cto_ajupre_cont / 5);
                                var lnuSaldo = G1Cto_ajupre_cont - (5 * lnuUnidades);
                                if (lnuSaldo > 0)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Debe ser cero, cinco (5) o un multiplo de cinco";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_frecus_cont":
                        #region CTO_FRECUS_CONT: Frecuencia uso servicios
                        lcrNombreCampo = "Frecuencia uso servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (String.IsNullOrWhiteSpace(G1Cto_frecus_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_frecus_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_porrec_cont":
                        #region CTO_PORREC_CONT: Porcentaje Recargo precio
                        lcrNombreCampo = "Porcentaje Recargo precio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (G1Cto_porrec_cont < -100 || G1Cto_porrec_cont > 150)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                        }
                        break;
                        #endregion

                    case "G1Cto_porcub_cont":
                        #region CTO_PORCUB_CONT: Porcentaje cubrimiento
                        lcrNombreCampo = "Porcentaje cubrimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (G1Cto_porcub_cont <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Cto_porcub_cont < 0 || G1Cto_porcub_cont > 100)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_cubniv_cont":
                        #region CTO_CUBNIV_CONT: Niveles de complejidad
                        lcrNombreCampo = "Niveles de complejidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (String.IsNullOrWhiteSpace(G1Cto_cubniv_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_cubniv_cont, ",", "1,2,3,4,5,6,7"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_vibaud_cont":
                        #region CTO_VIBAUD_CONT: Visto Bueno Auditoria SI/NO
                        lcrNombreCampo = "Visto Bueno Auditoria SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (String.IsNullOrWhiteSpace(G1Cto_vibaud_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_vibaud_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_porcn1_cont":
                        #region CTO_PORCN1_CONT: Porcentaje cubrimiento Nivel 1
                        lcrNombreCampo = "Porcentaje cubrimiento Nivel 1";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (G1Cto_porcn1_cont > 0)
                        {
                            if (G1Cto_porcn1_cont < 0 || G1Cto_porcn1_cont > 100)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_porcn2_cont":
                        #region CTO_PORCN2_CONT: Porcentaje cubrimiento Nivel 2
                        lcrNombreCampo = "Porcentaje cubrimiento Nivel 2";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A25";
                        if (G1Cto_porcn2_cont > 0)
                        {
                            if (G1Cto_porcn2_cont < 0 || G1Cto_porcn2_cont > 100)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_porcn3_cont":
                        #region CTO_PORCN3_CONT: Porcentaje cubrimiento Nivel 3
                        lcrNombreCampo = "Porcentaje cubrimiento Nivel 3";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A26";
                        if (G1Cto_porcn3_cont > 0)
                        {
                            if (G1Cto_porcn3_cont < 0 || G1Cto_porcn3_cont > 100)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_porcn4_cont":
                        #region CTO_PORCN4_CONT: Porcentaje cubrimiento Nivel 4
                        lcrNombreCampo = "Porcentaje cubrimiento Nivel 4";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A27";
                        if (G1Cto_porcn4_cont > 0)
                        {
                            if (G1Cto_porcn4_cont < 0 || G1Cto_porcn4_cont > 100)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_porcn5_cont":
                        #region CTO_PORCN5_CONT: Porcentaje cubrimiento Nivel 5
                        lcrNombreCampo = "Porcentaje cubrimiento Nivel 5";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A28";
                        if (G1Cto_porcn5_cont > 0)
                        {
                            if (G1Cto_porcn5_cont < 0 || G1Cto_porcn5_cont > 100)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_porcn6_cont":
                        #region CTO_PORCN6_CONT: Porcentaje cubrimiento Nivel 6
                        lcrNombreCampo = "Porcentaje cubrimiento Nivel 6";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A29";
                        if (G1Cto_porcn6_cont > 0)
                        {
                            if (G1Cto_porcn6_cont < 0 || G1Cto_porcn6_cont > 100)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_totafi_cont":
                        #region CTO_TOTAFI_CONT: Total asegurados
                        lcrNombreCampo = "Total asegurados";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A30";
                        if (G1Cto_totafi_cont <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Cto_estcon_cont":
                        #region CTO_ESTCON_CONT: Estado del contrato
                        lcrNombreCampo = "Estado del contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A31";
                        if (String.IsNullOrWhiteSpace(G1Cto_estcon_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_estcon_cont, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_prnord_cont":
                        #region CTO_PRNORD_CONT: Imprimir orden Servi SI/NO
                        lcrNombreCampo = "Imprimir orden Servi SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A32";
                        if (String.IsNullOrWhiteSpace(G1Cto_prnord_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_prnord_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_prnrca_cont":
                        #region CTO_PRNRCA_CONT: Imprimir recibo caja SI/NO
                        lcrNombreCampo = "Imprimir recibo caja SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A33";
                        if (String.IsNullOrWhiteSpace(G1Cto_prnrca_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_prnrca_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_apldes_cont":
                        #region CTO_APLDES_CONT: Aplicar descuento SI/NO
                        lcrNombreCampo = "Aplicar descuento SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A34";
                        if (String.IsNullOrWhiteSpace(G1Cto_apldes_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_apldes_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_cobser_cont":
                        #region CTO_COBSER_CONT: Cobro efectivo servicios SI/NO
                        lcrNombreCampo = "Cobro efectivo servicios SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A35";
                        if (String.IsNullOrWhiteSpace(G1Cto_cobser_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_cobser_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_cobcop_cont":
                        #region CTO_COBCOP_CONT: Cobro efectivo copago SI/NO
                        lcrNombreCampo = "Cobro efectivo copago SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A36";
                        if (String.IsNullOrWhiteSpace(G1Cto_cobcop_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_cobcop_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_cobmod_cont":
                        #region CTO_COBMOD_CONT: Cobro efectivo c.moderadora SI/NO
                        lcrNombreCampo = "Cobro efectivo c.moderadora SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A37";
                        if (String.IsNullOrWhiteSpace(G1Cto_cobmod_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_cobmod_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_cobcus_cont":
                        #region CTO_COBCUS_CONT: Cobro efectivo cargo usuario SI/NO
                        lcrNombreCampo = "Cobro efectivo cargo usuario SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A38";
                        if (String.IsNullOrWhiteSpace(G1Cto_cobcus_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_cobcus_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_liqcop_cont":
                        #region CTO_LIQCOP_CONT: Cobrar Copago SI/NO
                        lcrNombreCampo = "Cobrar Copago SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A39";
                        if (String.IsNullOrWhiteSpace(G1Cto_liqcop_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_liqcop_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_liqmod_cont":
                        #region CTO_LIQMOD_CONT: Cobrar cuota moder SI/NO
                        lcrNombreCampo = "Cobrar cuota moder SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A40";
                        if (String.IsNullOrWhiteSpace(G1Cto_liqmod_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_liqmod_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_tiplcp_cont":
                        #region CTO_TIPLCP_CONT: Tipo copago c. moder Liquidado SI/NO
                        lcrNombreCampo = "Tipo copago c. moder Liquidado SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A41";
                        if (String.IsNullOrWhiteSpace(G1Cto_tiplcp_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_tiplcp_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_sepcon_cont":
                        #region CTO_SEPCON_CONT: Separa Facturas por contrato SI/NO
                        lcrNombreCampo = "Separa Facturas por contrato SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A42";
                        if (String.IsNullOrWhiteSpace(G1Cto_sepcon_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_sepcon_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_posnpo_cont":
                        #region CTO_POSNPO_CONT: Tipo servicios permitidos
                        lcrNombreCampo = "Tipo servicios permitidos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A43";
                        if (String.IsNullOrWhiteSpace(G1Cto_posnpo_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_posnpo_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_genrip_cont":
                        #region CTO_GENRIP_CONT: Generar Planos Rips
                        lcrNombreCampo = "Generar Planos Rips";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A44";
                        if (String.IsNullOrWhiteSpace(G1Cto_genrip_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_genrip_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_gcorip_cont":
                        #region CTO_GCORIP_CONT: Generar copagos en Rips
                        lcrNombreCampo = "Generar copagos en Rips";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A45";
                        if (String.IsNullOrWhiteSpace(G1Cto_gcorip_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_gcorip_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipase_sita":
                        #region SIA_TIPASE_SITA: Código tipo asegurador
                        lcrNombreCampo = "Código tipo asegurador";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A46";
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

                    case "G1Cto_gestho_cont":
                        #region CTO_GESTHO_CONT: Horas min cobro estancia hospitalización
                        lcrNombreCampo = "Horas min cobro estancia hospitalización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A46";
                        if (G1Cto_gestho_cont <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Cto_gestho_cont < 1 || G1Cto_gestho_cont > 10)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_gestur_cont":
                        #region CTO_GESTUR_CONT: Horas min cobro estancia Urgencias
                        lcrNombreCampo = "Horas min cobro estancia Urgencias";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A47";
                        if (G1Cto_gestur_cont <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Cto_gestur_cont < 1 || G1Cto_gestur_cont > 10)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_esthos_cont":
                        #region CTO_ESTHOS_CONT: Horas permanecia hospitalización
                        lcrNombreCampo = "Horas permanecia hospitalización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A48";
                        if (G1Cto_esthos_cont <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Cto_esthos_cont < 0 || G1Cto_esthos_cont > 99999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_esturg_cont":
                        #region CTO_ESTURG_CONT: Horas permanecia Urgencias
                        lcrNombreCampo = "Horas permanecia Urgencias";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A49";
                        if (G1Cto_esturg_cont <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Cto_esturg_cont < 0 || G1Cto_esturg_cont > 999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_autrad_cont":
                        #region CTO_AUTRAD_CONT: Autorización paciente admitido
                        lcrNombreCampo = "Autorización paciente admitido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A50";
                        if (String.IsNullOrWhiteSpace(G1Cto_autrad_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_autrad_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_autadh_cont":
                        #region CTO_AUTADH_CONT: Horas para solicitar autorizacion
                        lcrNombreCampo = "Horas para solicitar autorizacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A51";
                        if (G1Cto_autadh_cont <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Cto_autadh_cont < 0 || G1Cto_autadh_cont > 999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_autram_cont":
                        #region CTO_AUTRAM_CONT: Autorización paciente ambulatoria
                        lcrNombreCampo = "Autorización paciente ambulatoria";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A52";
                        if (String.IsNullOrWhiteSpace(G1Cto_autram_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_autram_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_autamh_cont":
                        #region CTO_AUTAMH_CONT: Horas para solicitar autorizacion
                        lcrNombreCampo = "Horas para solicitar autorizacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A53";
                        if (G1Cto_autamh_cont <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Cto_autamh_cont < 0 || G1Cto_autamh_cont > 999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_serper_cont":
                        #region CTO_SERPER_CONT: Servicios personalizados
                        lcrNombreCampo = "Servicios personalizados";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A48";
                        if (String.IsNullOrWhiteSpace(G1Cto_serper_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_serper_cont, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_idvalc_cont":
                        #region CTO_IDVALC_CONT: Validar usuarios del contrato
                        lcrNombreCampo = "Validar usuarios del contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A49";
                        if (String.IsNullOrWhiteSpace(G1Cto_idvalc_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_idvalc_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_suminv_cont":
                        #region CTO_SUMINV_CONT: Afectar inventarios y farmacia
                        lcrNombreCampo = "Afectar inventarios y farmacia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A50";
                        if (String.IsNullOrWhiteSpace(G1Cto_suminv_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_suminv_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_liqvsm_cont":
                        #region CTO_LIQVSM_CONT: Tipo Valor suministro
                        lcrNombreCampo = "Tipo Valor suministro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A51";
                        if (String.IsNullOrWhiteSpace(G1Cto_liqvsm_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_liqvsm_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_topval_cont":
                        #region CTO_TOPVAL_CONT: Validación topes servicios
                        lcrNombreCampo = "Validación topes servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A52";
                        if (String.IsNullOrWhiteSpace(G1Cto_topval_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cto_topval_cont, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_maxpdx_cont":
                        #region CTO_MAXPDX_CONT: Tope Proc Diagnósticos
                        lcrNombreCampo = "Tope Procedimiento Diagnósticos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A53";
                        if (G1Cto_maxpdx_cont > 0)
                        {
                            if (G1Cto_maxpdx_cont < 1 || G1Cto_maxpdx_cont > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_maxpnq_cont":
                        #region CTO_MAXPNQ_CONT: Tope Proc no quirúrgicos
                        lcrNombreCampo = "Tope Procedimiento no quirúrgicos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A54";
                        if (G1Cto_maxpnq_cont > 0)
                        {
                            if (G1Cto_maxpnq_cont < 1 || G1Cto_maxpnq_cont > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_maxpqx_cont":
                        #region CTO_MAXPQX_CONT: Tope Proc quirúrgicos
                        lcrNombreCampo = "Tope Procedimiento quirúrgicos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A55";
                        if (G1Cto_maxpqx_cont > 0)
                        {
                            if (G1Cto_maxpqx_cont < 1 || G1Cto_maxpqx_cont > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_maxpyp_cont":
                        #region CTO_MAXPYP_CONT: Tope Procedimientos PyP
                        lcrNombreCampo = "Tope Procedimientos Promoción y Prevención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A56";
                        if (G1Cto_maxpyp_cont > 0)
                        {
                            if (G1Cto_maxpyp_cont < 1 || G1Cto_maxpyp_cont > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_maxcns_cont":
                        #region CTO_MAXCNS_CONT: Tope Consultas
                        lcrNombreCampo = "Tope Consultas";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A57";
                        if (G1Cto_maxcns_cont > 0)
                        {
                            if (G1Cto_maxcns_cont < 1 || G1Cto_maxcns_cont > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_maxmps_cont":
                        #region CTO_MAXMPS_CONT: Tope medicamentos pos
                        lcrNombreCampo = "Tope medicamentos pos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A58";
                        if (G1Cto_maxmps_cont > 0)
                        {
                            if (G1Cto_maxmps_cont < 1 || G1Cto_maxmps_cont > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_maxmnp_cont":
                        #region CTO_MAXMNP_CONT: Tope medicamentos no pos
                        lcrNombreCampo = "Tope medicamentos no pos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A59";
                        if (G1Cto_maxmnp_cont > 0)
                        {
                            if (G1Cto_maxmnp_cont < 1 || G1Cto_maxmnp_cont > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_maxots_cont":
                        #region CTO_MAXOTS_CONT: Tope otros servicios
                        lcrNombreCampo = "Tope otros servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A60";
                        if (G1Cto_maxots_cont > 0)
                        {
                            if (G1Cto_maxots_cont < 1 || G1Cto_maxots_cont > 999999999)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    default:
                        lcrValorReturn = fcrValidacionRel(tcrNombrePropiedad);
                        llgValidDefault = true;
                        break;

                }

                if (llgValidDefault == false)
                {
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacionRel: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacionRel
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override string fcrValidacionRel(string tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            //lcrValorReturn=base.fcrValidacionRel(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Fcm_codman_mans":
                        #region FCM_CODMAN_MANS: Código manual servicios
                        lcrNombreCampo = "Código manual para personalizar servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B01";
                        if (String.IsNullOrWhiteSpace(G2Fcm_codman_mans))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmantarifario(G2Fcm_codman_mans);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codman_mans))
                            {
                                G2Fcm_desman_mans = tmp.fcm_desman_mans;
                                G2Fcm_codtar_ttar = tmp.fcm_codtar_ttar;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_idesec_sips":
                        #region FCM_IDESEC_SIPS: Código servicio IPS
                        lcrNombreCampo = "Código servicio IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B14";
                        if (String.IsNullOrWhiteSpace(G2Fcm_idesec_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            EFfcmmanservicips tmp = new EFfcmmanservicips();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G2Fcm_idesec_sips);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_idesec_sips))
                            {
                                /*
                                G2Fcm_coddig_mant = tmp.fcm_coddig_mant;
                                G2Fcm_desser_sips = tmp.fcm_desser_sips;
                                G2Fcm_desser_mant = String.IsNullOrWhiteSpace(G2Fcm_desser_mant) ? tmp.fcm_desser_sips : G2Fcm_desser_mant;
                                G2Fcm_codser_mant = String.IsNullOrWhiteSpace(G2Fcm_codser_mant) ? tmp.fcm_codser_sips : G2Fcm_codser_mant;
                                G2Fcm_valser_mant = G2Fcm_valser_mant <= 0 ? (float)tmp.fcm_valser_sips : G2Fcm_valser_mant;
                                G2Fcm_punuvr_mant = G2Fcm_punuvr_mant <= 0 ? (float)tmp.fcm_punuvr_sips : G2Fcm_punuvr_mant;
                                */
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_coddig_mant":
                        #region FCM_CODDIG_MANT: Código digitación servicio
                        lcrNombreCampo = "Código digitación servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B02";
                        if (String.IsNullOrWhiteSpace(G2Fcm_coddig_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarIuFcmmanservicios(G2Fcm_coddig_mant, G2Fcm_codman_mans);
                            if (tmp != null)
                            {
                                var tmpEx = CTOValidarCodigo.fobRegBuscarCtomanserviciosReg(G2Fcm_coddig_mant, G1Cto_seccon_cont);

                                if (tmpEx != null)
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en servicios personalizados del contrato";
                                    }
                                }
                                var lobRegTemp = TmpG2ListaBrow.FirstOrDefault(x => x.Fcm_coddig_mant == G2Fcm_coddig_mant);
                                if (lobRegTemp != null)
                                {
                                    if (lobRegTemp.Cto_idesec_cspr != G2Cto_idesec_cspr)
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en servicios personalizados del contrato";
                                    }
                                }
                                // cuando no hay error 
                                if (String.IsNullOrWhiteSpace(lcrValorReturn))
                                {
                                    G2Fcm_coddig_mant = tmp.fcm_coddig_mant;
                                    G2Fcm_desser_sips = tmp.fcm_desser_mant;
                                    G2Fcm_idesec_sips = tmp.fcm_idesec_sips;
                                    G2Fcm_desser_mant = String.IsNullOrWhiteSpace(G2Fcm_desser_mant) ? tmp.fcm_desser_mant : G2Fcm_desser_mant;
                                    G2Fcm_codser_mant = String.IsNullOrWhiteSpace(G2Fcm_codser_mant) ? tmp.fcm_codser_mant : G2Fcm_codser_mant;
                                    G2Fcm_valser_mant = G2Fcm_valser_mant <= 0 ? (float)tmp.fcm_valser_mant : G2Fcm_valser_mant;
                                    G2Fcm_punuvr_mant = G2Fcm_punuvr_mant <= 0 ? (float)tmp.fcm_punuvr_mant : G2Fcm_punuvr_mant;
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe en manual tarifario seleccionado (" + G2Fcm_desman_mans + ")";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_codser_mant":
                        #region FCM_CODSER_MANT: Código servicio en tarifario
                        lcrNombreCampo = "Código servicio en tarifario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B03";
                        if (String.IsNullOrWhiteSpace(G2Fcm_codser_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Fcm_valser_mant":
                        #region FCM_VALSER_MANT: Valor de servicio
                        lcrNombreCampo = "Valor de servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";
                        if (G2Fcm_valser_mant <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G2Fcm_valser_mant < 0 || G2Fcm_valser_mant > 999999999)
                            {
                                lcrValorReturn = "Valor de servicio: Valor fuera del rango";
                            }
                            if (G1Sis_valdia_tsal > 0)
                            {
                                fcvCalcularUvrPuntaje();
                            }
                            else if (gflOldValorServicio > 0 && G2Fcm_valser_mant != gflOldValorServicio)
                            {
                                lcrValorReturn = "Valor de servicio: debe seleccionar salario mensual vigente para calcular puntaje";
                            }
                            else if (GlgSIS_ModoAdicion == true && G1Sis_valdia_tsal <= 0)
                            {
                                lcrValorReturn = "Valor de servicio: debe seleccionar salario mensual vigente para calcular puntaje";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_punuvr_mant":
                        #region FCM_PUNUVR_MANT: Puntaje o UVR
                        lcrNombreCampo = "Puntaje o UVR";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        if (G2Fcm_punuvr_mant <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Fcm_valren_mant":
                        #region FCM_VALREN_MANT: Valor recargo nocturno
                        lcrNombreCampo = "Valor recargo nocturno";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (G2Fcm_valren_mant > 99999999)
                        {
                            lcrValorReturn = lcrNombreCampo + ": no es valido";
                        }
                        break;
                        #endregion

                    case "G2Fcm_tipccp_mant":
                        #region FCM_TIPCCP_MANT: Tipo liquidación copagos
                        lcrNombreCampo = "Tipo liquidación copagos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        if (String.IsNullOrWhiteSpace(G2Fcm_tipccp_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Fcm_tipccp_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_vficop_mant":
                        #region FCM_VFICOP_MANT: Valor fijo Copagos c.mod
                        lcrNombreCampo = "Valor fijo Copagos cuota moderadora";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B08";
                        if (G2Fcm_vficop_mant <= 0 && G2Fcm_tipccp_mant == "2")
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        break;
                        #endregion

                    case "G2Fcm_facvmc_mant":
                        #region FCM_FACVMC_MANT: Valores en cero SI/NO
                        lcrNombreCampo = "Valores en cero SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B12";
                        if (String.IsNullOrWhiteSpace(G2Fcm_facvmc_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Fcm_facvmc_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_estser_mant":
                        #region FCM_ESTSER_MANT: Estado del servicio
                        lcrNombreCampo = "Estado del servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B13";
                        if (String.IsNullOrWhiteSpace(G2Fcm_estser_mant))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Fcm_estser_mant, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Sis_codsal_tsal":
                        #region SIS_CODSAL_TSAL: Código
                        lcrNombreCampo = "Código salario minimo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A45";

                        if (!String.IsNullOrWhiteSpace(G1Sis_codsal_tsal))
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSissalariomin(G1Sis_codsal_tsal);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_codsal_tsal))
                            {
                                G1Sis_dessal_tsal = tmp.sis_dessal_tsal;
                                G1Sis_valsal_tsal = (int)tmp.sis_valsal_tsal;
                                G1Sis_valdia_tsal = (G1Sis_valsal_tsal / 30);
                                fcvCalcularUvrPuntaje();
                                fcrValidacionRel("G2Fcm_valser_sips");
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionRel");
            }
            return lcrValorReturn;
        }
        #endregion
        private void fcvCalcularUvrPuntaje()
        {
            G2Fcm_punuvr_mant = Funciones.fflCalcularPuntajeUvr(G2Fcm_codtar_ttar, G2Fcm_valser_mant, G1Sis_valsal_tsal);
        }
    }
}
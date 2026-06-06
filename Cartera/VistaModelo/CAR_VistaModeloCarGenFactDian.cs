//- MARMOTA-GENCODE: VERSION 2.0 - 29/08/2017 05:48:09 PM
using System;
using System.Windows;
using System.Data;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using Cartera.Modelo;

namespace Cartera.VistaModelo
{
    /// <summary>
    /// <para>TABLA: carmaesfactuma</para>
    /// <para>DESCRIPCION:
    ///  Maestro facturas cobro facturacion, para generar facturas con
    ///  secuencial DIAN, importa cuentas de cobro generadas en modulo
    ///  facturacion
    /// </para>
    /// </summary>
    public class VistaModeloCarGenFactDian : VistaModeloCarGenFactDianBase
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
                        lcrCodigoError = "A11";
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
                                    G1Fcm_secres_srfa = tmp.fcm_secres_srfa;

                                    if (FlgCargarDatosEmpresa(tmp, null)) // si se cargar entonces cargar la resolucion
                                    {
                                        fcrValidacion("G1Fcm_secres_srfa");
                                    }
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                    #endregion

                    case "G1Fcm_typdoc_fctd":
                        #region FCM_TYPDOC_FCTD: Tipo documento
                        lcrNombreCampo = "Tipo documento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Fcm_typdoc_fctd))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_typdoc_fctd, ",", "01,91,92"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_numdoc_fcem":
                        #region FCM_NUMDOC_FCEM: Numero Documento Nit Empresa
                        lcrNombreCampo = "Numero Documento Nit Empresa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
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
                                    G1Fcm_secres_srfa = tmp.fcm_secres_srfa;
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

                    case "G1Cto_seccon_cont":
                        #region CTO_SECCON_CONT: Secuencial de Contrato
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Cto_seccon_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
                            if (tmp != null)
                            {
                                G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                G1Sia_codeps_teps = String.IsNullOrWhiteSpace(G1Sia_codeps_teps) ? tmp.sia_codeps_teps : G1Sia_codeps_teps;
                                G1Sis_idterc_sitr = String.IsNullOrWhiteSpace(G1Sis_idterc_sitr) ? tmp.sis_idterc_sitr : G1Sis_idterc_sitr;
                                G1Cto_descon_cont = tmp.cto_descon_cont;
                                fcrValidacion("G1Sis_idterc_sitr");
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
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Cto_nrocon_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sia_codeps_teps":
                        #region SIA_CODEPS_TEPS: Código EPS
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                            if (tmp != null)
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
                        #region SIS_IDTERC_SITR: Código tercero Adquirente
                        lcrNombreCampo = "Código Adquirente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Sis_idterc_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            lobRegAdquirente = null;
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSismaesterceros(G1Sis_idterc_sitr);
                            if (tmp != null)
                            {
                                G1Sis_razsoc_sitr = tmp.sis_razsoc_sitr;
                                G1Sis_numide_sitr = tmp.sis_numide_sitr;
                                // cargar datos del adquirente
                                lobRegAdquirente = ModeloSismaesterceros.FobRegistrosSismaesterceros("ID", G1Sis_idterc_sitr);
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                                lobRegAdquirente = null;
                            }
                        }
                        break;
                    #endregion

                    case "G1Sis_numide_sitr":
                        #region SIS_IDTERC_SITR: Nit Adquirente
                        lcrNombreCampo = "Nit del Adquirente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A77";
                        if (String.IsNullOrWhiteSpace(G1Sis_numide_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            lobRegAdquirente = null;
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSismaestercerosNit(G1Sis_numide_sitr);
                            if (tmp != null)
                            {
                                G1Sis_razsoc_sitr = tmp.sis_razsoc_sitr;
                                G1Sis_numide_sitr = tmp.sis_numide_sitr;
                                G1Sis_idterc_sitr = tmp.sis_idterc_sitr;
                                // cargar datos del adquirente
                                lobRegAdquirente = ModeloSismaesterceros.FobRegistrosSismaesterceros("ID", G1Sis_idterc_sitr);
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                                lobRegAdquirente = null;
                            }
                        }
                        break;
                    #endregion

                    case "G1Fcm_secres_srfa":
                        #region FCM_SECRES_SRFA: Codigo resolución Dian
                        lcrNombreCampo = "Codigo resolución Dian";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Fcm_secres_srfa))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmsecrfacturas(G1Fcm_secres_srfa);
                            if (tmp != null)
                            {
                                //G1Fcm_desres_srfa = tmp.fcm_desres_srfa;
                                FlgCargarDatosEmpresa(null, tmp);
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + $": ({G1Fcm_secres_srfa}) No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Car_nrofac_camf":
                        #region CAR_NROFAC_CAMF: Numero factura Dian
                        //lcrNombreCampo = "Numero factura Dian";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A09";
                        //if (String.IsNullOrWhiteSpace(G1Car_nrofac_camf))
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        //}
                        //else
                        //{
                        //}
                        //break;
                        #endregion

                    case "G1Car_fecfac_camf":
                        #region CAR_FECFAC_CAMF: Fecha factura
                        lcrNombreCampo = "Fecha factura Documento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Car_fecfac_camf, "Fecha factura");
                        break;
                    #endregion

                    case "G1Fcm_horfac_camf":
                        #region FCM_HORFAC_CAMF: Hora emision documento
                        lcrNombreCampo = "Hora emisión documento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Fcm_horfac_camf, "12", ":", lcrNombreCampo);
                        break;
                        #endregion

                    case "G1Car_diavfa_camf":
                        #region CAR_diavfa_CAMF: Dias vencimiento factura
                        lcrNombreCampo = "Dias vencimiento factura";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (G1Fcm_metpag_mfac == "2") // Obligatorio cuando es venta a credito
                        {
                            if (G1Car_diavfa_camf <= 0)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                            }
                            else
                            {
                                // Calcualr Fecha Vencimiento
                                G1Fcm_fecven_mfac = FcrGenearFechaVencimiento();
                            }
                        }
                        else
                        {
                            G1Car_diavfa_camf = 0;
                        }
                        break;
                        #endregion

                    case "G1Fcm_fecven_mfac":
                        #region FCM_FECVEN_MFAC: Fecha Vencimiento
                        lcrNombreCampo = "Fecha Vencimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (G1Fcm_metpag_mfac == "2") // Obligatorio cuando es venta a credito
                        {
                            lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Fcm_fecven_mfac, lcrNombreCampo);
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                G1Fcm_fecven_mfac = FcrGenearFechaVencimiento();
                            }
                        }
                        else
                        {
                            G1Fcm_fecven_mfac = "  /  /    ";
                        }
                        //G1Fcm_fecven_mfac
                        break;
                        #endregion

                    case "G1Car_valfac_camf":
                        #region CAR_VALFAC_CAMF: Valor total factura Dian
                        //lcrNombreCampo = "Valor total factura Dian";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A11";
                        //if (G1Car_valfac_camf <= 0)
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        //}
                        //else
                        //{

                        //}
                        //break;
                        #endregion

                    case "G1Fcm_metpag_mfac":
                        #region FCM_METPAG_MFAC: Metodo de pago
                        lcrNombreCampo = "Metodo de pago";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (String.IsNullOrWhiteSpace(G1Fcm_metpag_mfac))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_metpag_mfac, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                    #endregion

                    case "G1Fcm_idrcre_mfac":
                        #region FCM_IDRCRE_MFAC: Referencia Notas Credito
                        lcrNombreCampo = "Referencia Notas Credito";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A38";
                        FlgValidarReferenciaNotaCredito(out DataRow tobRegCredito, out lcrValorReturn);
                        lobRefNotaCredito = tobRegCredito;
                        if (tobRegCredito != null)
                        {
                            G1Fcm_sercre_mfac = tobRegCredito["fcm_secreg_mfac"] != null ?
                                                tobRegCredito["fcm_secreg_mfac"].ToString().Trim() : string.Empty;

                            var lcrValor = tobRegCredito["fcm_valfac_dfac"] != null ?
                                           tobRegCredito["fcm_valfac_dfac"].ToString().Trim() : "0";

                            G2Car_valuni_cadf = G2Car_valuni_cadf <= 0 ? Convert.ToDecimal(lcrValor) : G2Car_valuni_cadf;
                        }
                        break;
                    #endregion

                    case "G1Fcm_idrdeb_mfac":
                        #region FCM_IDRDEB_MFAC: Referencia Notas Debito
                        lcrNombreCampo = "Referencia Notas Debito";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A39";
                        FlgValidarReferenciaNotaDebito(out DataRow tobRegDebito, out lcrValorReturn);
                        lobRefNotaDebito = tobRegDebito;
                        if (tobRegDebito != null)
                        {
                            G1Fcm_serdeb_mfac = tobRegDebito["fcm_secreg_mfac"] != null ?
                                                tobRegDebito["fcm_secreg_mfac"].ToString().Trim() : string.Empty;
                        }
                        break;
                    #endregion

                    // Notas  escritas de la factura
                    case "G1Car_prnobs_camf":
                        #region CAR_PRNOBS_CAMF: Imprimir la observacion
                        lcrNombreCampo = "Imprimir la observacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Car_prnobs_camf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Car_prnobs_camf, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                    #endregion

                    case "G1Car_observ_camf":
                        #region CAR_OBSERV_CAMF: Observacion
                        lcrNombreCampo = "Observacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Car_observ_camf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            /*
                            if (!Funciones.flgSoloTexto("AN", G1Car_observ_camf))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                            */
                            //G1Car_observ_camf = G1Car_observ_camf.ToUpper();
                        }
                        break;
                    #endregion

                    case "G1Car_prnnot_camf":
                        #region CAR_PRNNOT_CAMF: Imprimir Nota inferior
                        lcrNombreCampo = "Imprimir Nota inferior";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Car_prnnot_camf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            /*
                            if (!Funciones.flgExisteElemento(G1Car_prnnot_camf, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            */
                        }
                        break;
                    #endregion

                    case "G1Car_medpag_camf":
                        #region CAR_MEDPAG_CAMF: Nota impresa pagos
                        lcrNombreCampo = "Nota impresa pagos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (String.IsNullOrWhiteSpace(G1Car_medpag_camf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Car_medpag_camf))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                    #endregion

                    case "G1Sis_estpro_espr":
                        #region SIS_ESTPRO_ESPR: Estado Registro
                        lcrNombreCampo = "Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (String.IsNullOrWhiteSpace(G1Sis_estpro_espr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisestadoproces(G1Sis_estpro_espr);
                            if (tmp != null)
                            {
                                G1Sis_despro_espr = tmp.sis_despro_espr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                    #endregion

                    // Datos cuenta de cobro facturas provenients de lista factura
                    case "G1Car_tipfac_camf":
                        #region CAR_TIPFAC_CAMF: Incluye cuenta de cobro
                        lcrNombreCampo = "Incluye listado relacion facturas";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Car_tipfac_camf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Car_tipfac_camf, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            if (G1Car_tipfac_camf == "2")
                            {
                                G1Fcm_secreg_mfcb = String.Empty;
                            }
                        }
                        break;
                    #endregion

                    case "G1Fcm_secreg_mfcb":
                        #region FCM_SECREG_MFCB: Cuenta cobro facturacion
                        lcrNombreCampo = "Cuenta cobro facturacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (String.IsNullOrWhiteSpace(G1Fcm_secreg_mfcb))
                        {
                            fcvLimpiarVariablesCuentaCobroFact();
                            if (G1Car_tipfac_camf == "1")
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                            else
                            {
                                G1Fcm_valfac_dfac = G1Car_valfac_camf;
                                G1Fcm_valbru_dfac = G1Car_valfac_camf;
                            }

                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmcuentacobrms(G1Fcm_secreg_mfcb);
                            if (tmp != null)
                            {
                                G1Fcm_numfac_mfac = tmp.fcm_numfac_mfac;
                                G1Fcm_fecfac_mfac = Funciones.fcrConvertFecha((DateTime)tmp.fcm_fecfac_mfac);
                                G1Fcm_descue_mfcb = tmp.fcm_descue_mfcb;
                                G1Cto_seccon_cont = tmp.cto_seccon_cont;
                                G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                //G1Sis_idterc_sitr = tmp.sis_idterc_sitr;
                                G1Fcm_valbru_dfac = (decimal)tmp.fcm_valbru_dfac;
                                G1Fcm_valdes_dfac = (decimal)tmp.fcm_valdes_dfac;
                                G1Fcm_valiva_dfac = (decimal)tmp.fcm_valiva_dfac;
                                G1Fcm_valcpa_dfac = (decimal)tmp.fcm_valcpa_dfac;
                                G1Fcm_valfac_dfac = (decimal)tmp.fcm_valfac_dfac;
                                //G1Sis_estpro_espr = tmp.sis_estpro_espr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_fecfac_mfac":
                        #region FCM_FECFAC_MFAC: Fecha factura
                        lcrNombreCampo = "Fecha listado relación de usuarios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (G1Car_tipfac_camf == "1")
                        {
                            lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Fcm_fecfac_mfac, lcrNombreCampo);
                        }
                        break;
                    #endregion

                    #region FCM_VALBRU_DFAC: Valor bruto factura
                    //case "G1Fcm_valbru_dfac":
                    //    #region FCM_VALBRU_DFAC: Valor bruto factura
                    //    //lcrNombreCampo = "Valor bruto factura";
                    //    //lcrValorReturn = String.Empty;
                    //    //lcrCodigoError = "A17";
                    //    //if (G1Fcm_valbru_dfac <= 0)
                    //    //{
                    //    //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                    //    //}
                    //    //else
                    //    //{
                    //    //    //if (!Funciones.flgSoloTexto("AN", G1Fcm_valbru_dfac))
                    //    //    //{
                    //    //    //    lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                    //    //    //}
                    //    //}
                    //    //break;
                    //    #endregion
                    #endregion

                    case "G1Fcm_valdes_dfac":
                        #region FCM_VALDES_DFAC: Valor del descuento
                        //lcrNombreCampo = "Valor del descuento";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A18";
                        //if (G1Fcm_valdes_dfac <= 0)
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        //}
                        //else
                        //{
                        //}
                        //break;
                        #endregion

                    case "G1Fcm_valiva_dfac":
                        #region FCM_VALIVA_DFAC: Valor IVA
                        //lcrNombreCampo = "Valor IVA";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A19";
                        //if (G1Fcm_valiva_dfac <= 0)
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        //}
                        //else
                        //{
                        //}
                        //break;
                        #endregion

                    case "G1Fcm_valcpa_dfac":
                        #region FCM_VALCPA_DFAC: Valor copagos
                        //lcrNombreCampo = "Valor copagos";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "A20";
                        //if (G1Fcm_valcpa_dfac <= 0)
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        //}
                        //else
                        //{
                        //}
                        //break;
                        #endregion

                    case "G1Fcm_valfac_dfac":
                        #region FCM_VALFAC_DFAC: Valor total facturado
                        lcrNombreCampo = "Valor total facturado en relacion de usuarios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (G1Fcm_valfac_dfac < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser cero";
                        }
                        else
                        {
                            if (G1Car_tipfac_camf == "1" && G1Fcm_valfac_dfac <= 0)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                            }
                        }
                        break;
                        #endregion
                    // Fin lista facturas    

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
        public override String fcrValidacionRel(String tcrNombrePropiedad)
        {
            String lcrValorReturn = String.Empty;
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
                    case "G2Car_codcon_cacf":
                        #region CAR_CODCON_CACF: Codigo concepto
                        lcrNombreCampo = "Codigo concepto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B03";
                        if (String.IsNullOrWhiteSpace(G2Car_codcon_cacf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = CARValidarCodigo.fobRegBuscarCarconceptfact(G2Car_codcon_cacf);
                            if (tmp != null)
                            {
                                //G2Car_descon_cadf = tmp.car_descon_cacf;
                                G2Car_descon_cadf = String.IsNullOrWhiteSpace(G2Car_descon_cadf) ? tmp.car_descon_cacf : G2Car_descon_cadf;
                                G2Fcm_codpro_fcpr = tmp.fcm_codpro_fcpr;
                                G2Car_seccon_cacf = tmp.car_seccon_cacf;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                    
                        break;
                        #endregion

                    case "G2Car_descon_cadf":
                        #region CAR_DESCON_CADF: Descripcion concepto
                        lcrNombreCampo = "Descripcion concepto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";
                        if (String.IsNullOrWhiteSpace(G2Car_descon_cadf))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G2Car_descon_cadf = G2Car_descon_cadf.ToUpper();

                            /*
                            if (!Funciones.flgSoloTexto("AN", G2Car_descon_cadf))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                            */
                        }
                        break;
                        #endregion

                    case "G2Car_totuni_cadf":
                        #region CAR_TOTUNI_CADF: Total unidades
                        lcrNombreCampo = "Total unidades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        if (G2Car_totuni_cadf <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                         
                        }
                        break;
                        #endregion

                    case "G2Car_valuni_cadf":
                        #region CAR_VALUNI_CADF: Valor unidad
                        lcrNombreCampo = "Valor unidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (G2Car_valuni_cadf <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            
                        }
                        break;
                        #endregion

                    case "G2Fcm_subtot_dfac":
                        #region FCM_SUBTOT_DFAC: Valor subtotal
                        lcrNombreCampo = "Valor subtotal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        if (G2Fcm_subtot_dfac < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                           // fcvCalcularUnidades();
                           
                        }
                        else
                        {
                            fcvCalcularUnidades();
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

        // Funciones auxiliares
        #region FcvCargarDatosEmpresa: Cargar datos de Razon social
        /// <summary>
        /// Cargar datos de Razon social y Resolucion Dian
        /// </summary>
        private bool FlgCargarDatosEmpresa(EFfcmfemaesrazsocma tobRegRazonSocial, EFfcmsecrfacturas tobResolucion)
        {
            var llgReturn = false;
            if (tobRegRazonSocial != null)
            {
                // Cargar en registro temporal
                if (lobRegRazonSocial != null)
                {
                    if (lobRegRazonSocial.fcm_secraz_fcem != G1Fcm_secres_srfa)
                    {
                        lobRegRazonSocial = tobRegRazonSocial;
                        llgReturn = true;
                    }
                }
                else
                {
                    lobRegRazonSocial = tobRegRazonSocial;
                    llgReturn = true;
                }
            }

            if (tobResolucion != null)
            {
                // Cargar en registro temporal
                if (lobRegResolDian != null)
                {
                    if (lobRegResolDian.fcm_secres_srfa != G1Fcm_secres_srfa)
                    {
                        lobRegResolDian = tobResolucion;
                        llgReturn = true;
                    }
                }
                else
                {
                    lobRegResolDian = tobResolucion;
                    llgReturn = true;
                }
            }
            return llgReturn;
        }
        #endregion Cargar datos de Razon social>
        #region fcvCalcularUnidades: Calcular Unidades Concepto Factura
        /// <summary>
        /// Calcular Unidades Concepto de Factura
        /// </summary>
        private void fcvCalcularUnidades()
        {
            if (G2Car_valuni_cadf > 0 && G2Car_totuni_cadf > 0)
            {
                G2Fcm_subtot_dfac = (G2Car_valuni_cadf * G2Car_totuni_cadf);
                G2Fcm_valbru_dfac = G2Fcm_subtot_dfac;
                G2Fcm_valbsi_dfac = 0;
                G2Fcm_poriva_dfac = 0;
                G2Fcm_valiva_dfac = 0;
                G2Sis_coddes_side = "NA";
                G2Fcm_pordes_dfac = 0;
                G2Fcm_valdes_dfac = 0;
                G2Fcm_valfac_dfac = G2Fcm_subtot_dfac;
            }
            else
            {
                G2Fcm_subtot_dfac = 0;
                G2Fcm_valbru_dfac = G2Fcm_subtot_dfac;
                G2Fcm_valbsi_dfac = 0;
                G2Fcm_poriva_dfac = 0;
                G2Fcm_valiva_dfac = 0;
                G2Sis_coddes_side = "NA";
                G2Fcm_pordes_dfac = 0;
                G2Fcm_valdes_dfac = 0;
                G2Fcm_valfac_dfac = G2Fcm_subtot_dfac;
            }
        }
        #endregion
        #region fcvLimpiarVariablesCuentaCobroFact: Limpiar las variables que vienen de cuenta cobro
        /// <summary>
        /// Limpiar las variables que vienen de cuenta cobro desde modulo facturacion
        /// </summary>
        private void fcvLimpiarVariablesCuentaCobroFact()
        {
            G1Fcm_valbru_dfac = 0;
            G1Fcm_valdes_dfac = 0;
            G1Fcm_valiva_dfac = 0;
            G1Fcm_valcpa_dfac = 0;
            G1Fcm_valfac_dfac = 0;
        }
        #endregion
        #region FcrGenearFechaVencimiento: Validaciones referencias a Nota Crédito
        /// <summary>
        /// Calcular la fecha de vencimiento del documento
        /// </summary>
        /// <returns></returns>
        private string FcrGenearFechaVencimiento()
        {
            //DateTime.Now.AddDays(G1Car_diavfa_camf).ToShortDateString();
            var lcrFecha = Funciones.fcrConvertFecha(DateTime.Now.AddDays(G1Car_diavfa_camf)); 
            return lcrFecha;
        }
        #endregion FcrGenearFechaVencimiento>
        // Validaciones nota credito y debito
        #region FcrValidarReferenciaNotaCredito: Validaciones referencias a Nota Crédito
        /// <summary>
        /// Realizar todas las validaciones para las referencias del documento activo con respecto a nota credito
        /// </summary>
        /// <returns></returns>
        private bool FlgValidarReferenciaNotaCredito(out DataRow tobRegCredito, out string tcrValorReturn)
        {
            tobRegCredito = null;
            var lcrNombreCampo = "Referencia Notas Crédito";
            tcrValorReturn = String.Empty;

            if (G1Fcm_typdoc_fctd == "01") // Documento Factura
            {
                lcrNombreCampo = "Referencia Notas Crédito";
                // cuando existe una referenca 
                if (!string.IsNullOrWhiteSpace(G1Fcm_idrcre_mfac))
                {
                    // Verificar que la referencia sea un tipo de documento "91"
                    var lobReg = FCMValidarCodigo.FobRegBuscarFcmfemaesfactefmaDataRow(G1Fcm_idrcre_mfac, G1Fcm_secraz_fcem);
                    if (lobReg != null)
                    {
                        if (lobReg["fcm_codest_fcws"].ToString().Trim() != "R01")
                        {
                            tcrValorReturn = lcrNombreCampo + $": El documento referenciado ({G1Fcm_idrcre_mfac}) no esta radicado en la Dian";
                        }
                        else if (lobReg["sis_numide_sitr"].ToString().Trim() != G1Sis_numide_sitr)
                        {
                            tcrValorReturn = lcrNombreCampo + ": El Nit del Adquirente es diferente con el Nit del Documento actual";
                        }
                        else
                        {
                            if (lobReg["fcm_typdoc_fctd"].ToString().Trim() != "91")
                            {
                                tcrValorReturn = lcrNombreCampo + ": Solo se permite referencia a documentos tipo Notas Crédito";
                            }
                        }
                        G1Fcm_metpag_mfac = string.IsNullOrWhiteSpace(tcrValorReturn) ?
                                                lobReg["fcm_metpag_mfac"].ToString().Trim() : G1Fcm_metpag_mfac;
                        tobRegCredito = lobReg;
                    }
                    else
                    {
                        tcrValorReturn = lcrNombreCampo + $": No se encontro el registro <{G1Fcm_idrcre_mfac}> en base de datos";
                    }
                }
            }
            if (G1Fcm_typdoc_fctd == "91") // Documento Nota Credito
            {
                lcrNombreCampo = "Refrenecia Factura Crédito";
                // debe existir una referenca a una factura
                if (string.IsNullOrWhiteSpace(G1Fcm_idrcre_mfac))
                {
                    tcrValorReturn = lcrNombreCampo + ": Debe agregar referencia a una Factura en campo: <Refrenecia Factura Crédito>";
                }
                else
                {
                    // Verificar que la referencia sea un tipo de documento "01"
                    //var lobReg = FCMValidarCodigo.FobRegBuscarFcmfemaesfactefmaDoc(G1Fcm_idrcre_mfac);
                    var lobReg = FCMValidarCodigo.FobRegBuscarFcmfemaesfactefmaDataRow(G1Fcm_idrcre_mfac, G1Fcm_secraz_fcem);
                    if (lobReg != null)
                    {
                        var lnuFcm_valfac_dfac = Convert.ToDecimal(lobReg["fcm_valfac_dfac"].ToString());
                        var lcrTypDoc = lobReg["fcm_typdoc_fctd"].ToString().Trim();
                        
                        if (lobReg["fcm_codest_fcws"].ToString().Trim() != "R01")
                        {
                            tcrValorReturn = lcrNombreCampo + $": El documento referenciado ({G1Fcm_idrcre_mfac}) no esta radicado en la Dian";
                        }
                        else if (lobReg["sis_numide_sitr"].ToString().Trim() != G1Sis_numide_sitr)
                        {
                            var lcrNitDocEnDian = lobReg["sis_numide_sitr"].ToString().Trim();
                            tcrValorReturn = lcrNombreCampo + $": El Nit del adquirente en documento DIAN ({lcrNitDocEnDian}) es diferente con el Nit del documento actual ({G1Sis_numide_sitr})";
                        }
                        else if (G1Fcm_valfac_dfac > lnuFcm_valfac_dfac)
                        {
                            tcrValorReturn = lcrNombreCampo + $": Valor de Nota Credito ({G1Fcm_valfac_dfac}) es "+
                                                              $"superior al Valor Factura Referenciada ({lnuFcm_valfac_dfac})";
                        }
                        else
                        {
                            if (lcrTypDoc != "01")
                            {
                                var lcrTipo = lcrTypDoc == "91" ? "Nota Crédito" : "Nota Debito";
                                tcrValorReturn = lcrNombreCampo + $": En una Nota Crédito, no se permite referencia a una {lcrTipo}";
                            }
                        }
                        G1Fcm_metpag_mfac = string.IsNullOrWhiteSpace(tcrValorReturn) ?
                                                lobReg["fcm_metpag_mfac"].ToString().Trim() : G1Fcm_metpag_mfac;
                        tobRegCredito = lobReg;
                    }
                    else
                    {
                        tcrValorReturn = lcrNombreCampo + $": No se encontro el registro <{G1Fcm_idrcre_mfac}> " +
                            $"en base de dato para {G1Fcm_nomcom_fcem}";
                    }
                }
            }

            if (G1Fcm_typdoc_fctd == "92") // Documento Nota Debito no se debe permitir referencias en este campo
            {
                if (!string.IsNullOrWhiteSpace(G1Fcm_idrcre_mfac))
                {
                    tcrValorReturn = lcrNombreCampo + $": En una Nota Debito, no se permite referencia a Documentos Credito (Factura/Notas)";
                    tobRegCredito = null;
                }
            }
            return string.IsNullOrWhiteSpace(tcrValorReturn); // cuando esta vacio es porque no hay texto de error
        }
        #endregion FcrValidarReferencaNotaCredito>
        #region FlgValidarReferenciaNotaDebito: Validaciones referencias a Nota Debito
        /// <summary>
        /// Realizar todas las validaciones para las referencias del documento activo con respecto a nota debito
        /// </summary>
        /// <returns></returns>
        private bool FlgValidarReferenciaNotaDebito(out DataRow tobRegDebito, out string tcrValorReturn)
        {
            tobRegDebito = null;
            var lcrNombreCampo = "Referencia Notas Debito";
            tcrValorReturn = String.Empty;

            if (G1Fcm_typdoc_fctd == "01") // Documento Factura
            {
                lcrNombreCampo = "Referencia Notas Debito";
                // debe existir una referenca al menos 
                if (!string.IsNullOrWhiteSpace(G1Fcm_idrdeb_mfac))
                {
                    // Verificar que la referencia sea un tipo de documento "92"
                    var lobReg = FCMValidarCodigo.FobRegBuscarFcmfemaesfactefmaDataRow(G1Fcm_idrdeb_mfac, G1Fcm_secraz_fcem);
                    if (lobReg != null)
                    {
                        if (lobReg["fcm_codest_fcws"].ToString().Trim() != "R01")
                        {
                            tcrValorReturn = lcrNombreCampo + $": El documento referenciado ({G1Fcm_idrdeb_mfac}) no esta aceptado en la Dian";
                        }
                        if (lobReg["sis_numide_sitr"].ToString().Trim() != G1Sis_numide_sitr)
                        {
                            tcrValorReturn = lcrNombreCampo + ": El Nit del Adquirente es diferente con el Nit del Documento actual";
                        }
                        else
                        {
                            if (lobReg["fcm_typdoc_fctd"].ToString().Trim() != "92")
                            {
                                tcrValorReturn = lcrNombreCampo + ": Solo se permite referencia a documentos tipo Notas Debito";
                            }
                        }
                        G1Fcm_metpag_mfac = string.IsNullOrWhiteSpace(tcrValorReturn) ?
                                                lobReg["fcm_metpag_mfac"].ToString().Trim() : G1Fcm_metpag_mfac;
                        tobRegDebito = lobReg;
                    }
                    else
                    {
                        tcrValorReturn = lcrNombreCampo + $": No se encontro el registro <{G1Fcm_idrcre_mfac}> en base de datos";
                    }
                }
            }
            if (G1Fcm_typdoc_fctd == "92") // Documento Nota Debito
            {
                lcrNombreCampo = "Refrenecia Factura Debito";
                // debe existir una referenca a una factura
                if (string.IsNullOrWhiteSpace(G1Fcm_idrdeb_mfac))
                {
                    tcrValorReturn = lcrNombreCampo + ": Debe agregar referencia a una Factura en campo: <Refrenecia Factura Debito>";
                }
                else
                {
                    // Verificar que la referencia sea un tipo de documento "01"
                    var lobReg = FCMValidarCodigo.FobRegBuscarFcmfemaesfactefmaDataRow(G1Fcm_idrdeb_mfac, G1Fcm_secraz_fcem);
                    if (lobReg != null)
                    {
                        var lcrTypDoc = lobReg["fcm_typdoc_fctd"].ToString().Trim();

                        if (lobReg["fcm_codest_fcws"].ToString().Trim() != "R01")
                        {
                            tcrValorReturn = lcrNombreCampo + $": El documento referenciado ({G1Fcm_idrdeb_mfac}) no esta aceptado en la Dian";
                        }
                        if (lobReg["sis_numide_sitr"].ToString().Trim() != G1Sis_numide_sitr)
                        {
                            tcrValorReturn = lcrNombreCampo + ": El Nit del Adquirente es diferente con el Nit del Documento actual";
                        }
                        else
                        {
                            if (lcrTypDoc != "01")
                            {
                                var lcrTipo = lcrTypDoc == "91" ? "Nota Crédito" : "Nota Debito";
                                tcrValorReturn = lcrNombreCampo + $": En una Nota Credito, no se permite referencia a una {lcrTipo}";
                            }
                        }
                        G1Fcm_metpag_mfac = string.IsNullOrWhiteSpace(tcrValorReturn) ?
                                                lobReg["fcm_metpag_mfac"].ToString().Trim() : G1Fcm_metpag_mfac;
                        tobRegDebito = lobReg;
                    }
                    else
                    {
                        tcrValorReturn = lcrNombreCampo + $": No se encontro el registro <{G1Fcm_idrcre_mfac}> en base de datos";
                    }
                }
            }

            if (G1Fcm_typdoc_fctd == "91") // Documento Nota Credito no se debe permitir referencias en este campo
            {
                if (!string.IsNullOrWhiteSpace(G1Fcm_idrdeb_mfac))
                {
                    tcrValorReturn = lcrNombreCampo + $": En una Nota Credito, no se permite referencia a Documentos Debito (Factura/Notas)";
                    tobRegDebito = null;
                }
            }
            return string.IsNullOrWhiteSpace(tcrValorReturn); // cuando esta vacio es porque no hay texto de error
        }
        #endregion FcrValidarReferencaNotaDebito>
    }
}
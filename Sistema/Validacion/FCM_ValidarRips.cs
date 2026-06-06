using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;

namespace Sistema.Validacion
{
    public class FcmValidarRips
    {
        //----------------------------------------------------------------------------
        // flgValidarRegistro: Desencadena la validacion del registros Rips
        //----------------------------------------------------------------------------
        private static DbAplicacion _context;
        public static List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public static List<EFadmregadmision> tmpAdmisiones = new List<EFadmregadmision>();
        public static List<FcmModeloServDetallFacturas> tmpDetallesFact = new List<FcmModeloServDetallFacturas>();

        #region fcvValidarPeriodoDatosFacturados: Valida que los datos facturados esten dentro de un periodo valido
        /// <summary>
        /// <para>Valida que los datos facturados esten dentro de un periodo valido</para>
        /// </summary>
        public static void fcvValidarPeriodoDatosFacturados(String tcrCodigoEps, String tcrFechaIni, String tcrFechaFin)
        {
            var lcrNumeroAdmision = String.Empty;
            var lcrIdAdmisionAux  = "XXX";
            var lnuConRipsIncom   = 0;
            tmpLogErrores         = new List<LogsErrores>();
            tmpDetallesFact       = new List<FcmModeloServDetallFacturas>();

            var tmpListServFacturacion = flsCargHclSQLConsultDatosFacturados(tcrCodigoEps, tcrFechaIni, tcrFechaFin);
            tmpAdmisiones = ADMValidarCodigo.flstListaAdmregadmisionFiltro(tcrCodigoEps, tcrFechaIni, tcrFechaFin);

            #region Generar lista de todos los posibles registrios de 4505
            // Cargar los datos
            foreach (DataRow lobReServ in tmpListServFacturacion.Rows)
            {
                lcrNumeroAdmision = lobReServ["adm_secadm_rgad"].ToString().ToUpper().Trim();
                lcrIdAdmisionAux  = lcrIdAdmisionAux == "XXX" ? lcrNumeroAdmision : lcrIdAdmisionAux;

                // Verificar si ya esta en otra admision
                if (lcrNumeroAdmision != lcrIdAdmisionAux)
                {
                    // Marcar la admision anterior segun validacion
                    var lobRegAdm = tmpAdmisiones.FirstOrDefault(x => x.adm_secadm_rgad == lcrIdAdmisionAux);
                    if (lobRegAdm != null)
                    {
                        lobRegAdm.adm_ctarip_rgad = lnuConRipsIncom > 0 ? "ERROR" : "OK";
                        lnuConRipsIncom = 0;
                        /*
                        if (lcrIdAdmisionAux == "AP00003275")
                        {
                            MessageBox.Show("se confirma " + lobRegAdm.adm_ctarip_rgad);
                        }
                        */
                    }
                }

                //- Realizar validacion del registro activo
                var lobReg = fobRegDefaultDesdeServFacturados(lobReServ);
                lobReg.Fcm_ripsco_dfac = "2";
                if (!flgValidarRegistro(lobReg, ref tmpLogErrores))
                {
                    /*
                    if (lcrNumeroAdmision == "AP00003275")
                    {
                        MessageBox.Show(" error en " + lobReg.Fcm_desser_dfac);
                    }
                    */
                    lnuConRipsIncom++;
                    lobReg.Fcm_ripsco_dfac = "1"; // hay errores
                }
                lobReg.Fcm_desest_rips = lobReg.Fcm_ripsco_dfac == "2" ? "COMPLETO" : "PENDIENTE";
                lobReg.Sis_estado_imaen = "M";

                tmpDetallesFact.Add(lobReg);

                lcrIdAdmisionAux = lcrNumeroAdmision;
            }
            #endregion
            // Actualizar estados registros rips en admision y servicios facturacion
            fcvValidarActualizarEstadosRegistros();

        }
        #endregion
        #region fcvValidarActualizarEstadosRegistros: Actualizar los valores estado Rips en maestros
        /// <summary>
        /// <para>Actualizar los valores estado Rips en maestros admision y detalles facturacion</para>
        /// </summary>
        public static void fcvValidarActualizarEstadosRegistros()
        {
            #region Actualizar datos en Registros de Admision
            using (_context = new DbAplicacion())
            {
                // Cargar los datos
                foreach (var lobReg in tmpAdmisiones)
                {
                    var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == lobReg.adm_secadm_rgad.Trim());
                    if (lobjRegistro != null)
                    {
                        #region Modificar Registro
                        lobjRegistro.adm_ctarip_rgad = lobReg.adm_ctarip_rgad == "OK" ? "2" : "1"; //2=Completado 1=No completado
                        #endregion
                    }
                }
                _context.SaveChanges();
            }
            #endregion
            #region Actualizar registro detalle facturacion
            using (_context = new DbAplicacion())
            {
                // Cargar los datos
                foreach (var lobReg in tmpDetallesFact)
                {
                    var lobjRegistro = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == lobReg.Fcm_secreg_dfac.Trim());
                    if (lobjRegistro != null)
                    {
                        #region Modificar Registro
                        lobjRegistro.fcm_ripsco_dfac = lobReg.Fcm_ripsco_dfac; // 2=Completado 1=No completado
                        #endregion
                    }
                }
                _context.SaveChanges();
            }
            #endregion
        }
        #endregion
        // Funciones auxiliares para generar nuevos registros
        #region fobRegDefaultDesdeServFacturados: Cargar datos en registro con formato FcmModeloServDetallFacturas
        /// <summary>
        /// <para>Cargar datos en registro con formato FcmModeloServDetallFacturas, desde temporal de consulta nativa facturacion</para>
        /// </summary>
        public static FcmModeloServDetallFacturas fobRegDefaultDesdeServFacturados(DataRow tobRegFactura)
        {
            var lobReg = new FcmModeloServDetallFacturas();
            var lcrFechaServ = (tobRegFactura["fcm_fecser_dfac"].ToString()).Substring(0, 10);

            #region datos del registro
            lobReg.Fcm_secreg_dfac = tobRegFactura["fcm_secreg_dfac"].ToString().Trim();
            lobReg.Adm_secadm_rgad = tobRegFactura["adm_secadm_rgad"].ToString().Trim();
            lobReg.Sia_codeps_teps = tobRegFactura["sia_codeps_teps"].ToString().Trim();
            lobReg.Sia_idesec_usua = tobRegFactura["sia_idesec_usua"].ToString().Trim();
            lobReg.Sia_tipide_tide = tobRegFactura["sia_tipide_tide"].ToString().Trim();
            lobReg.Sia_nroide_usua = tobRegFactura["sia_nroide_usua"].ToString().Trim();
            lobReg.Sis_codsex_sexo = tobRegFactura["sis_codsex_sexo"].ToString().Trim();
            lobReg.Sia_edaano_usua = tobRegFactura["sia_edaano_usua"] != null ? Convert.ToInt32(tobRegFactura["sia_edaano_usua"].ToString()) : 0;
            lobReg.Sia_edames_usua = tobRegFactura["sia_edames_usua"] != null ? Convert.ToInt32(tobRegFactura["sia_edames_usua"].ToString()) : 0;
            lobReg.Sia_edadia_usua = tobRegFactura["sia_edadia_usua"] != null ? Convert.ToInt32(tobRegFactura["sia_edadia_usua"].ToString()) : 0;
            lobReg.Sia_edaymd_usua = tobRegFactura["sia_edaymd_usua"].ToString().Trim();
            lobReg.Adm_pacemb_rgad = tobRegFactura["adm_pacemb_rgad"].ToString().Trim();
            lobReg.Fcm_codser_mant = tobRegFactura["fcm_codser_mant"].ToString().Trim();
            lobReg.Fcm_coddig_mant = tobRegFactura["fcm_coddig_mant"].ToString().Trim();
            lobReg.Fcm_desser_dfac = tobRegFactura["fcm_desser_dfac"].ToString().Trim();
            lobReg.Adm_codtat_tatn = tobRegFactura["adm_codtat_tatn"].ToString().Trim();
            lobReg.Fcm_fecser_dfac = Convert.ToDateTime(lcrFechaServ);
            lobReg.Sia_codrip_trip = tobRegFactura["sia_codrip_trip"].ToString().Trim();
            lobReg.Fcm_horser_dfac = tobRegFactura["fcm_horser_dfac"] != null ? Convert.ToDecimal(tobRegFactura["fcm_horser_dfac"].ToString()) : 0;
            lobReg.Sia_tipact_tsac = tobRegFactura["sia_tipact_tsac"].ToString().Trim();
            lobReg.Sia_codpat_tpat = tobRegFactura["sia_codpat_tpat"].ToString().Trim();
            lobReg.Adm_nroaut_rgad = tobRegFactura["adm_nroaut_rgad"] != null ? tobRegFactura["adm_nroaut_rgad"].ToString().Trim() : "";
            lobReg.Sia_codfpr_fpor = tobRegFactura["sia_codfpr_fpor"] != null ? tobRegFactura["sia_codfpr_fpor"].ToString().Trim() : "";
            lobReg.Sia_codfco_fcon = tobRegFactura["sia_codfco_fcon"] != null ? tobRegFactura["sia_codfco_fcon"].ToString().Trim() : "";
            lobReg.Adm_codcex_tcex = tobRegFactura["adm_codcex_tcex"] != null ? tobRegFactura["adm_codcex_tcex"].ToString().Trim() : "";
            lobReg.Fcm_forfar_sips = tobRegFactura["fcm_forfar_sips"] != null ? tobRegFactura["fcm_forfar_sips"].ToString().Trim() : "";
            lobReg.Fcm_conmed_sips = tobRegFactura["fcm_conmed_sips"] != null ? tobRegFactura["fcm_conmed_sips"].ToString().Trim() : "";
            lobReg.Fcm_unimed_sips = tobRegFactura["fcm_unimed_sips"] != null ? tobRegFactura["fcm_unimed_sips"].ToString().Trim() : "";
            lobReg.Sia_coddia_tdia = tobRegFactura["sia_coddia_tdia"] != null ? tobRegFactura["sia_coddia_tdia"].ToString().Trim() : "";
            lobReg.Sia_tipdxp_tdix = tobRegFactura["sia_tipdxp_tdix"].ToString().Trim();
            lobReg.Fcm_serpos_sips = tobRegFactura["fcm_serpos_sips"].ToString().Trim();
            lobReg.Sia_coddx1_tdia = tobRegFactura["sia_coddx1_tdia"] != null ? tobRegFactura["sia_coddx1_tdia"].ToString().Trim() : "";
            lobReg.Sia_coddx2_tdia = tobRegFactura["sia_coddx2_tdia"] != null ? tobRegFactura["sia_coddx2_tdia"].ToString().Trim() : "";
            lobReg.Sia_coddx3_tdia = tobRegFactura["sia_coddx3_tdia"] != null ? tobRegFactura["sia_coddx3_tdia"].ToString().Trim() : "";
            lobReg.Sia_coddxc_tdia = tobRegFactura["sia_coddxc_tdia"].ToString().Trim();
            lobReg.Fcm_otserv_sips = tobRegFactura["fcm_otserv_sips"].ToString().Trim();
            lobReg.Modificado = "NO";
            #endregion

            return lobReg;
        }
        #endregion
        //----------------------------------------------------------------------------
        // flgValidarRegistro: Desencadena la validacion del registros Rips
        //----------------------------------------------------------------------------
        #region flgValidarRegistro: Desencadena la validacion del registros Rips
        /// <summary>
        /// Desencadena la validacion del registros Rips
        /// </summary>
        public static bool flgValidarRegistro(FcmModeloServDetallFacturas tobRegistro, ref List<LogsErrores> tmpLogErrores)
        {
            bool llgReturn = false;

            if (tobRegistro.Sia_codrip_trip == "01")  // Consulta
            {
                llgReturn = flgValidarRipsConsulta(tobRegistro, ref tmpLogErrores);
            }
            else if (tobRegistro.Sia_codrip_trip == "02" || tobRegistro.Sia_codrip_trip == "03" ||
                     tobRegistro.Sia_codrip_trip == "04" || tobRegistro.Sia_codrip_trip == "05") // Procedimientos
            {
                llgReturn = flgValidarRipsProcedimiento(tobRegistro, ref tmpLogErrores);
            }
            else if (tobRegistro.Sia_codrip_trip == "12" || tobRegistro.Sia_codrip_trip == "13") // Medicamentos
            {
                llgReturn = flgValidarRipsMedicamentos(tobRegistro, ref tmpLogErrores);
            }
            else  // Otros servicios
            {
                llgReturn = flgValidarRipsOtrosServicios(tobRegistro, ref tmpLogErrores);
            }
            return llgReturn;
        }
        #endregion
        #region flgValidarRegistroExt: Valida completar registro para finalizar consulta externa
        /// <summary>
        /// Valida completar registro para finalizar consulta externa
        /// </summary>
        public static bool flgValidarRegistroExt(FcmModeloServDetallFacturas tobRegistro, ref List<LogsErrores> tmpLogErrores)
        {
            bool llgReturn = false;

            if (tobRegistro.Sia_codrip_trip == "01")  // Consulta
            {
                llgReturn = flgValidarRipsConsulta(tobRegistro, ref tmpLogErrores);
            }
            else if (tobRegistro.Sia_codrip_trip == "02" || tobRegistro.Sia_codrip_trip == "03" ||
                     tobRegistro.Sia_codrip_trip == "04" || tobRegistro.Sia_codrip_trip == "05") // Procedimientos
            {
                llgReturn = flgValidarRipsProcedimiento(tobRegistro, ref tmpLogErrores);
            }
            else if (tobRegistro.Sia_codrip_trip == "12" || tobRegistro.Sia_codrip_trip == "13") // Medicamentos
            {
                llgReturn = true;
                //llgReturn = flgValidarRipsMedicamentos(tobRegistro, ref tmpLogErrores);
            }
            else  // Otros servicios
            {
                llgReturn = true;
                //llgReturn = flgValidarRipsOtrosServicios(tobRegistro, ref tmpLogErrores);
            }
            return llgReturn;
        }
        #endregion
        // Validar RIPS Consulta
        #region flgValidarRipsConsulta: Validar registro Rips de consulta
        /// <summary>
        /// <para>Validar registro rips consulta</para>
        /// </summary>
        public static bool flgValidarRipsConsulta(FcmModeloServDetallFacturas tobRegRips, ref List<LogsErrores> tmpLogErrores)
        {
            int lnuContErrores = 0;
            var llgReturn = false;

            String lcrValorReturn    = String.Empty;
            String lcrNumeroRegistro = String.Empty;
            String lcrCodigoError    = String.Empty;
            String lcrNombreCampo    = String.Empty;
            String lcrNivelError     = "ALTO";
            String lcrImgNivelError  = "Edt_hist_vista_anulado.png";

            #region Registro Rips AC
            if (tobRegRips != null)
            {
                //-------------------------------------------------
                // Fecha Consulta
                //-------------------------------------------------
                #region Fecha consulta
                lcrCodigoError = "001";
                lcrNombreCampo = "RIPS CONSULTA: Fecha Consulta";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() +"I"+ lcrCodigoError;

                lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", tobRegRips.Fcm_fecser_dfac.ToShortDateString(), lcrNombreCampo);
                if (!String.IsNullOrWhiteSpace(lcrValorReturn))
                {
                    lnuContErrores++;
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                #endregion
                //-------------------------------------------------
                // Numero de autorización
                //-------------------------------------------------
                #region Numero de autorización
                lcrCodigoError = "002";
                lcrNombreCampo = "RIPS CONSULTA: Numero de autorización";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (!String.IsNullOrWhiteSpace(tobRegRips.Adm_nroaut_rgad))
                {
                    // Validar caracteres validos en el numero
                    if (!Funciones.flgExisteSubCadenaStringEx(tobRegRips.Adm_nroaut_rgad, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Finalidad de la consulta
                //-------------------------------------------------
                #region Finalidad de la consulta
                lcrCodigoError = "003";
                lcrNombreCampo = "RIPS CONSULTA: Finalidad de la consulta";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Sia_codfco_fcon))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerida";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    if (!Funciones.flgExisteElemento(tobRegRips.Sia_codfco_fcon, ",", "01,02,03,04,05,06,07,08,09,10"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": valor no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Causa externa
                //-------------------------------------------------
                #region Causa externa
                lcrCodigoError = "004";
                lcrNombreCampo = "RIPS CONSULTA: Causa externa";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Adm_codcex_tcex))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerida";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    if (!Funciones.flgExisteElemento(tobRegRips.Adm_codcex_tcex, ",", "01,02,03,04,05,06,07,08,09,10,11,12,13,14,15"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Adm_codcex_tcex.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Diagnostico principal
                //-------------------------------------------------
                #region Diagnostico principal
                lcrCodigoError = "005";
                lcrNombreCampo = "RIPS CONSULTA: Diagnostico principal";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Sia_coddia_tdia))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(tobRegRips.Sia_coddia_tdia);
                    if (tmp == null)
                    {

                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Sia_coddia_tdia.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Tipo diagnostico principal
                //-------------------------------------------------
                #region Tipo diagnostico principal
                lcrCodigoError = "006";
                lcrNombreCampo = "RIPS CONSULTA: Tipo diagnostico principal";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Sia_tipdxp_tdix))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    if (!Funciones.flgExisteElemento(tobRegRips.Sia_tipdxp_tdix, ",", "1,2,3"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Sia_tipdxp_tdix.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Diagnostico relacionado 1
                //-------------------------------------------------
                #region Diagnostico relacionado 1
                lcrCodigoError = "007";
                lcrNombreCampo = "RIPS CONSULTA: Diagnostico relacionado 1";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (!String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx1_tdia))
                {
                    var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(tobRegRips.Sia_coddx1_tdia);
                    if (tmp == null)
                    {

                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Sia_coddx1_tdia.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Diagnostico relacionado 2
                //-------------------------------------------------
                #region Diagnostico relacionado 2
                lcrCodigoError = "008";
                lcrNombreCampo = "RIPS CONSULTA: Diagnostico relacionado 2";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (!String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx2_tdia))
                {
                    var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(tobRegRips.Sia_coddx2_tdia);
                    if (tmp == null)
                    {

                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Sia_coddx2_tdia.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Diagnostico relacionado 3
                //-------------------------------------------------
                #region Diagnostico relacionado 3
                lcrCodigoError = "009";
                lcrNombreCampo = "RIPS CONSULTA: Diagnostico relacionado 3";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (!String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx3_tdia))
                {
                    var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(tobRegRips.Sia_coddx3_tdia);
                    if (tmp == null)
                    {

                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Sia_coddx3_tdia.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
            }
            #endregion
            llgReturn = lnuContErrores > 0 ? false : true;

            return llgReturn;
        }
        #endregion
        // Validar RIPS Procedimiento
        #region flgValidarRipsProcedimiento: Validar registro Rips Procedimiento
        /// <summary>
        /// <para>Validar registro Rips Procedimiento</para>
        /// </summary>
        public static bool flgValidarRipsProcedimiento(FcmModeloServDetallFacturas tobRegRips, ref List<LogsErrores> tmpLogErrores)
        {
            int lnuContErrores = 0;
            var llgReturn = false;

            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = String.Empty;
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            #region Registro Rips AP
            if (tobRegRips != null)
            {
                //-------------------------------------------------
                // Fecha Procedimiento
                //-------------------------------------------------
                #region Fecha Procedimiento
                lcrCodigoError = "001";
                lcrNombreCampo = "RIPS PROCEDIMIENTO: Fecha Procedimiento";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", tobRegRips.Fcm_fecser_dfac.ToShortDateString(), lcrNombreCampo);
                if (!String.IsNullOrWhiteSpace(lcrValorReturn))
                {
                    lnuContErrores++;
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                #endregion
                //-------------------------------------------------
                // Numero de autorización
                //-------------------------------------------------
                #region Numero de autorización
                lcrCodigoError = "002";
                lcrNombreCampo = "RIPS PROCEDIMIENTO: Numero de autorización";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (!String.IsNullOrWhiteSpace(tobRegRips.Adm_nroaut_rgad))
                {
                    // Validar caracteres validos en el numero
                    if (!Funciones.flgExisteSubCadenaStringEx(tobRegRips.Adm_nroaut_rgad, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Tipo atención o ambito prestacion
                //-------------------------------------------------
                #region Tipo atención o ambito prestacion
                lcrCodigoError = "003";
                lcrNombreCampo = "RIPS PROCEDIMIENTO: Tipo atención o ambito prestacion";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Adm_codtat_tatn))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerida";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    if (!Funciones.flgExisteElemento(tobRegRips.Adm_codtat_tatn, ",", "1,2,3"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": valor " + tobRegRips.Adm_codtat_tatn.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Finalidad del Procedimiento
                //-------------------------------------------------
                #region Finalidad del Procedimiento
                lcrCodigoError = "004";
                lcrNombreCampo = "RIPS PROCEDIMIENTO: Finalidad del Procedimiento";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Sia_codfpr_fpor))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerida";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    if (!Funciones.flgExisteElemento(tobRegRips.Sia_codfpr_fpor, ",", "1,2,3,4,5"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": valor " + tobRegRips.Sia_codfpr_fpor.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Personal que atiende
                //-------------------------------------------------
                #region Personal que atiende
                lcrCodigoError = "005";
                lcrNombreCampo = "RIPS PROCEDIMIENTO: Personal que atiende";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Sia_codpat_tpat))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerida";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    if (!Funciones.flgExisteElemento(tobRegRips.Sia_codpat_tpat, ",", "1,2,3,4,5"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": valor " + tobRegRips.Sia_codpat_tpat.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Diagnostico principal
                //-------------------------------------------------
                #region Diagnostico principal
                lcrCodigoError = "006";
                lcrNombreCampo = "RIPS PROCEDIMIENTO: Diagnostico principal";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                /*
                if (String.IsNullOrWhiteSpace(tobRegRips.Sia_coddia_tdia))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                */
                if (!String.IsNullOrWhiteSpace(tobRegRips.Sia_coddia_tdia))
                {
                    var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(tobRegRips.Sia_coddia_tdia);
                    if (tmp == null)
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Sia_coddia_tdia.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Diagnostico relacionado 
                //-------------------------------------------------
                #region Diagnostico relacionado 
                lcrCodigoError = "007";
                lcrNombreCampo = "RIPS PROCEDIMIENTO: Diagnostico relacionado";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (!String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx1_tdia))
                {
                    var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(tobRegRips.Sia_coddx1_tdia);
                    if (tmp == null)
                    {

                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Sia_coddx1_tdia.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Diagnostico complicación
                //-------------------------------------------------
                #region Diagnostico complicación
                lcrCodigoError = "008";
                lcrNombreCampo = "RIPS PROCEDIMIENTO: Diagnostico complicación";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (!String.IsNullOrWhiteSpace(tobRegRips.Sia_coddxc_tdia))
                {
                    var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(tobRegRips.Sia_coddxc_tdia);
                    if (tmp == null)
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Sia_coddxc_tdia.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Forma realización acto quirúrgico
                //-------------------------------------------------
                #region Acto quirúrgico
                lcrCodigoError = "009";
                lcrNombreCampo = "RIPS PROCEDIMIENTO: Forma realización acto quirúrgico";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;
                /*
                if (String.IsNullOrWhiteSpace(tobRegRips.Fcm_codaqx_aqir))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerida";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                */
                if (!String.IsNullOrWhiteSpace(tobRegRips.Fcm_codaqx_aqir))
                {
                    if (!Funciones.flgExisteElemento(tobRegRips.Fcm_codaqx_aqir, ",", "1,2,3,4,5"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": valor " + tobRegRips.Fcm_codaqx_aqir.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
            }
            #endregion
            llgReturn = lnuContErrores > 0 ? false : true;

            return llgReturn;
        }
        #endregion
        // Validar RIPS Medicamentos
        #region flgValidarRipsMedicamentos: Validar registro Rips Medicamentos
        /// <summary>
        /// <para>Validar registro Rips Medicamentos</para>
        /// </summary>
        public static bool flgValidarRipsMedicamentos(FcmModeloServDetallFacturas tobRegRips, ref List<LogsErrores> tmpLogErrores)
        {
            int lnuContErrores = 0;
            var llgReturn = false;

            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = String.Empty;
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            #region Registro Rips AM
            if (tobRegRips != null)
            {
                //-------------------------------------------------
                // Fecha Servicio
                //-------------------------------------------------
                #region Fecha Servicio
                lcrCodigoError = "001";
                lcrNombreCampo = "RIPS MEDICAMENTOS : Fecha Servicio";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", tobRegRips.Fcm_fecser_dfac.ToShortDateString(), lcrNombreCampo);
                if (!String.IsNullOrWhiteSpace(lcrValorReturn))
                {
                    lnuContErrores++;
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                #endregion
                //-------------------------------------------------
                // Numero de autorización
                //-------------------------------------------------
                #region Numero de autorización
                lcrCodigoError = "002";
                lcrNombreCampo = "RIPS MEDICAMENTOS : Numero de autorización";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (!String.IsNullOrWhiteSpace(tobRegRips.Adm_nroaut_rgad))
                {
                    // Validar caracteres validos en el numero
                    if (!Funciones.flgExisteSubCadenaStringEx(tobRegRips.Adm_nroaut_rgad, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Medicamento Pos No Pos
                //-------------------------------------------------
                #region Medicamento Pos No Pos
                lcrCodigoError = "003";
                lcrNombreCampo = "RIPS MEDICAMENTOS : Tipo (Pos/No Pos)";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Fcm_serpos_sips))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Valor es requerido";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    if (!Funciones.flgExisteElemento(tobRegRips.Fcm_serpos_sips, ",", "1,2"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": valor " + tobRegRips.Fcm_serpos_sips.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Forma farmacéutica
                //-------------------------------------------------
                #region Forma farmacéutica
                lcrCodigoError = "004";
                lcrNombreCampo = "RIPS MEDICAMENTOS : Forma farmacéutica";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Fcm_forfar_sips))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerida";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    // Validar caracteres validos en el numero
                    if (!Funciones.flgExisteSubCadenaStringEx(tobRegRips.Fcm_forfar_sips, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789%()./+ "))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor "+ tobRegRips.Fcm_forfar_sips.Trim()+ " Contiene caracteres no validos";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Concentración del medicamento 
                //-------------------------------------------------
                #region Concentración del medicamento
                lcrCodigoError = "005";
                lcrNombreCampo = "RIPS MEDICAMENTOS : Concentración del medicamento";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Fcm_conmed_sips))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerida";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    // Validar caracteres validos en el numero
                    if (!Funciones.flgExisteSubCadenaStringEx(tobRegRips.Fcm_conmed_sips, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789%()./+ "))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Fcm_conmed_sips.Trim() + " Contiene caracteres no validos";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Unidad medida del medicamento  
                //-------------------------------------------------
                #region  Unidad medida del medicamento
                lcrCodigoError = "006";
                lcrNombreCampo = "RIPS MEDICAMENTOS : Concentración del medicamento";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Fcm_unimed_sips))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Es requerida";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    // Validar caracteres validos en el numero
                    if (!Funciones.flgExisteSubCadenaStringEx(tobRegRips.Fcm_unimed_sips, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789%()./+ "))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Valor " + tobRegRips.Fcm_unimed_sips.Trim() + " Contiene caracteres no validos";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
            }
            #endregion
            llgReturn = lnuContErrores > 0 ? false : true;

            return llgReturn;
        }
        #endregion
        // Validar RIPS Otros servicios
        #region flgValidarRipsOtrosServicios: Validar registro Rips Otros servicios
        /// <summary>
        /// <para>Validar registro Rips Otros servicios</para>
        /// </summary>
        public static bool flgValidarRipsOtrosServicios(FcmModeloServDetallFacturas tobRegRips, ref List<LogsErrores> tmpLogErrores)
        {
            int lnuContErrores = 0;
            var llgReturn = false;

            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = String.Empty;
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            #region Registro Rips AT
            if (tobRegRips != null)
            {
                //-------------------------------------------------
                // Fecha Servicio
                //-------------------------------------------------
                #region Fecha Servicio
                lcrCodigoError = "001";
                lcrNombreCampo = "RIPS OTROS SERVICIOS : Fecha Servicio";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", tobRegRips.Fcm_fecser_dfac.ToShortDateString(), lcrNombreCampo);
                if (!String.IsNullOrWhiteSpace(lcrValorReturn))
                {
                    lnuContErrores++;
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                #endregion
                //-------------------------------------------------
                // Numero de autorización
                //-------------------------------------------------
                #region Numero de autorización
                lcrCodigoError = "002";
                lcrNombreCampo = "RIPS OTROS SERVICIOS : Numero de autorización";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (!String.IsNullOrWhiteSpace(tobRegRips.Adm_nroaut_rgad))
                {
                    // Validar caracteres validos en el numero
                    if (!Funciones.flgExisteSubCadenaStringEx(tobRegRips.Adm_nroaut_rgad, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion
                //-------------------------------------------------
                // Tipo servicio
                //-------------------------------------------------
                #region Tipo servicio
                lcrCodigoError = "003";
                lcrNombreCampo = "RIPS OTROS SERVICIOS : Tipo servicio";
                lcrNivelError = "ALTO";
                lcrNumeroRegistro = tobRegRips.Fcm_secreg_dfac.Trim() + "I" + lcrCodigoError;

                if (String.IsNullOrWhiteSpace(tobRegRips.Fcm_otserv_sips))
                {
                    lnuContErrores++;
                    lcrValorReturn = lcrNombreCampo + ": Valor es requerido";
                    if (tmpLogErrores != null)
                    {
                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                    }
                }
                else
                {
                    if (!Funciones.flgExisteElemento(tobRegRips.Fcm_otserv_sips, ",", "1,2,3,4"))
                    {
                        lnuContErrores++;
                        lcrValorReturn = lcrNombreCampo + ": valor " + tobRegRips.Fcm_otserv_sips.Trim() + " no valido";
                        if (tmpLogErrores != null)
                        {
                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                        }
                    }
                }
                #endregion

            }
            #endregion
            llgReturn = lnuContErrores > 0 ? false : true;

            return llgReturn;
        }
        #endregion
        //----------------------------------------------------------------------------
        // Consultas SQL
        //----------------------------------------------------------------------------
        #region flsCargHclSQLConsultDatosFacturados: Ejecutar consultas desde registros facturados
        /// <summary>
        /// <para>Ejecutar consultas desde registros facturados y devuelve un temporal de tipo DateTable con todos</para>
        /// <para>los registros facturados en el periodo</para>
        /// </summary>
        public static DataTable flsCargHclSQLConsultDatosFacturados(String tcrCodigoEps, String tcrFechaIni, String tcrFechaFin)
        {
            DataTable objDatosTabla = new DataTable();
            var lcrLineaSqlSelct = String.Empty;
            var lcrFiltro = String.Empty;

            lcrFiltro        = fcrSQLFiltroStringDatosFacturados(tcrCodigoEps, tcrFechaIni, tcrFechaFin);
            lcrLineaSqlSelct = fcrSQLGenLineaStringDatosFacturados(lcrFiltro, "ORDER BY fcmmaedetallfac.adm_secadm_rgad, fcmmaedetallfac.fcm_fecser_dfac DESC");

            objDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);

            return objDatosTabla;
        }
        #endregion
        #region fcrSQLFiltroStringDatosFacturados: Expresion filtro SQL para servicios facturados
        /// <summary>
        /// <para>Generar la expresion filtro de la String SQL para consultar servicios facturados</para>
        /// </summary>
        public static String fcrSQLFiltroStringDatosFacturados(String tcrCodigoEps, String tcrFechaIni, String tcrFechaFin)
        {
            var lcrFiltro = String.Empty;

            var lcrFechaIni = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", tcrFechaIni, "YMD", "-"); ;
            var lcrFechaFin = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", tcrFechaFin, "YMD", "-");

            if (String.IsNullOrWhiteSpace(tcrCodigoEps))
            {
                lcrFiltro = "(admregadmision.adm_fecadm_rgad >= '" + lcrFechaIni + "') AND " +
                            "(admregadmision.adm_fecadm_rgad <= '" + lcrFechaFin + "') AND ";
            }
            else
            {
                lcrFiltro = "(admregadmision.adm_fecadm_rgad >= '" + lcrFechaIni + "') AND " +
                            "(admregadmision.adm_fecadm_rgad <= '" + lcrFechaFin + "') AND " +
                            "(admregadmision.sia_codeps_teps = '" + tcrCodigoEps + "') AND ";

            }

            return lcrFiltro;
        }
        #endregion
        #region fcrSQLGenLineaStringDatosFacturados: Linea SQL tipo texto para consulta
        /// <summary>
        /// <para>Linea SQL tipo texto para Ejecutar consultas desde registros facturados</para>
        /// </summary>
        public static String fcrSQLGenLineaStringDatosFacturados(String tcrFiltro, String tcrOrderBy)
        {
            var lcrLineaSqlSelct = String.Empty;
            #region Linea SQl para ejecutar
            lcrLineaSqlSelct = "SELECT fcmmaedetallfac.fcm_secreg_dfac," +
                             "fcmmaedetallfac.adm_secadm_rgad," +
                             "fcmmaedetallfac.sia_codeps_teps," +
                             "admregadmision.sia_idesec_usua," +
                             "admregadmision.sia_tipide_tide," +
                             "admregadmision.sia_nroide_usua," +
                             "siausuarioatend.sis_codsex_sexo," +
                             "admregadmision.sia_edaano_usua," +
                             "admregadmision.sia_edames_usua," +
                             "admregadmision.sia_edadia_usua," +
                             "admregadmision.sia_edaymd_usua," +
                             "admregadmision.sia_tipusu_regi," +
                             "admregadmision.adm_nroaut_rgad," +
                             "admregadmision.adm_pacemb_rgad," +
                             "fcmmaedetallfac.fcm_codser_mant," +
                             "fcmmaedetallfac.fcm_coddig_mant," +
                             "fcmmaedetallfac.fcm_desser_dfac," +
                             "fcmmaedetallfac.fcm_fecser_dfac," +
                             "fcmmaedetallfac.fcm_horser_dfac," +
                             "fcmmaedetallfac.sia_codrip_trip," +
                             "fcmmaedetallfac.sia_tipact_tsac," +
                             "fcmmaedetallfac.adm_codtat_tatn," +
                             "fcmmaedetallfac.sia_codpat_tpat," +
                             "fcmmaedetallfac.sia_codfpr_fpor," +
                             "fcmmaedetallfac.sia_codfco_fcon," +
                             "fcmmaedetallfac.adm_codcex_tcex," +
                             "fcmmaedetallfac.fcm_forfar_sips," +
                             "fcmmaedetallfac.fcm_conmed_sips," +
                             "fcmmaedetallfac.fcm_serpos_sips," +
                             "fcmmaedetallfac.fcm_unimed_sips," +
                             "fcmmaedetallfac.sia_coddia_tdia," +
                             "fcmmaedetallfac.sia_tipdxp_tdix," +
                             "fcmmaedetallfac.sia_coddx1_tdia," +
                             "fcmmaedetallfac.sia_coddx2_tdia," +
                             "fcmmaedetallfac.sia_coddx3_tdia," +
                             "fcmmaedetallfac.sia_coddxc_tdia," +
                             "fcmmaedetallfac.fcm_otserv_sips " +
                       "FROM " +
                         "fcmmaedetallfac " +
                                   "INNER JOIN siausuarioatend ON (fcmmaedetallfac.sia_idesec_usua = siausuarioatend.sia_idesec_usua) " +
                                   "INNER JOIN admregadmision ON (fcmmaedetallfac.adm_secadm_rgad = admregadmision.adm_secadm_rgad) " +
                       "WHERE " + tcrFiltro + "(admregadmision.sis_estpro_espr = '2') " + tcrOrderBy;
            #endregion

            return lcrLineaSqlSelct;
        }
        #endregion
    }
}

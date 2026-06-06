using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using Microsoft.Win32;
using Sistema.Modelo;
using Datos.Modelos;
using Sistema.Utilidades;
using GestorReportes.Modelo;
using GestorReportes.Vista;
using GestorReportes.VistaModelo;
using Sistema.Validacion;
using Sistema.Clases;

namespace GestorReportes.Utilidades
{
    public class HclUtilidades
    {
        //------------------------------------------------------------
        // Funciones utilitarias para graficar en odontograma
        //------------------------------------------------------------
        #region fobOdontogramaSeletImagenGraficar: Devuelve un registro tipo EFodnimagengrafde (tabla detalles imagenes para graficar)
        /// <summary>
        /// <para>DESCRIPCION:</para>
        /// <para>Devuelve un registro tipo EFodnimagengrafde (tabla detalles imagenes para graficar)</para>
        /// <para>dado los parametros llave imagen, tipo graficador (puede ser odontograma) zona grafica dentro del graficador</para>
        /// <para>y Codigo del item que requiere grafica (este es opcional para mostrar una grafica mas puntual)</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrCodigoImagen:      Codigo de registro desde la tabla maestra de imagenes para graficar ODNIMAGENGRAFMS.</para>
        /// <para>tcrGraficador:        "1" = Odontograma (adultos o niños) "2" = Vista Maxilofacial  "3" ...</para>
        /// <para>tcrZonaGraficador:    Zona dentro del graficador ejemplo: Para odontograma el valor "5" es el primer cuadrante en odontograma niños.</para>
        /// <para>tcrIdItem:            (opcional para graficas mas puntuales) Codigo o numero del item en graficador que mostrara</para>
        /// <para>la grafica ejemplo:   "21" Diente incisivo lateral superior izquierdo.</para>
        /// </summary>
        public static EFodnimagengrafde fobOdontogramaSeletImagenGraficar(String tcrCodigoImagen,String tcrGraficador,String tcrZonaGraficador,String tcrIdItem)
        {
            var lcrLlave = tcrCodigoImagen.Trim() + "G" + tcrGraficador.Trim() + tcrZonaGraficador.Trim() + "X" + tcrIdItem.Trim();
            EFodnimagengrafde lobRegReturn = ODNValidarCodigo.fobRegBuscarOdnimagengrafdeEx(lcrLlave);
            if (lobRegReturn == null)
            {
                lcrLlave = tcrCodigoImagen.Trim() + "G" + tcrGraficador.Trim() + tcrZonaGraficador.Trim() + "X";
                lobRegReturn = ODNValidarCodigo.fobRegBuscarOdnimagengrafdeEx(lcrLlave);
            }

            return lobRegReturn;
        }
        #endregion
        #region fcrOdontogramaCaraDiente: Devuelve string con nombre o codigo cara anatomia del diente
        /// <summary>
        /// <para>DESCRIPCION:</para>
        /// <para>Devuelve string con nombre o codigo cara anatomia del diente</para>
        /// <para>segun numero cara vista corona dado en orden del reloj</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumeroDiente: Codigo o numero del diente ejemplo "12", "12","82" ...</para>
        /// <para>tcrTipRetorno: "1" Nombre de cara anatomica "2" = Codigo cara anatomica correspondiente </para>
        /// <para>tcrNumeroCara: Numero de la cara segun vista corona -> "1","2","3","4","5" en el sentido del reloj</para>
        /// </summary>
        public static String fcrOdontogramaCaraDiente(String tcrNumeroDiente, String tcrTipRetorno, String tcrNumeroCara)
        {
            String lcrReturn = String.Empty;
            var tmp = HclOdontMaestroDientes.flsListaOdnmaestdientes(tcrNumeroDiente);

            if (tmp.Count != 0 && tmp != null)
            {
                var lobReg = tmp.FirstOrDefault();

                var lcrNumeroCara    = Convert.ToInt32(tcrNumeroCara) - 1;
                var lcrCodigoCara = lobReg.Odn_cardnt_odcd.Substring(lcrNumeroCara, 1);
                var lobRegAnat = ODNValidarCodigo.fobRegBuscarOdnanatomdiente(lcrCodigoCara);

                lcrReturn = tcrTipRetorno == "1" ? lobRegAnat.odn_desana_odan : lcrCodigoCara;
            }
            return lcrReturn;
        }
        #endregion
        #region fcrReturnNombreImagenEstadoAct : Devuelve string con nombre imagen para diferenciar estado por color
        /// <summary>
        /// <para>DESCRIPCION:</para>
        /// <para>Devuelve string con nombre imagen para diferenciar estado por color de imagen segun estado actividad:</para>
        /// <para>1= Pendiente 2 = En proceso  3 = Actividad Finalizada</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipoActividad: "1" = Diagnostico inicial "2" = Plan de tratamiento "3" = Actividades de evolucion</para>
        /// </summary>
        public static String fcrReturnNombreImagenEstadoAct(String tcrTipoActividad, ModeloOdnDeActivTratamiento tobRegistro, EFodnimagengrafde tobRegGafica)
        {
            var lcrImagenGrafica = tobRegGafica.odn_image1_odid;

            if (tcrTipoActividad == "1") // Diagnostico
            {
                lcrImagenGrafica = tobRegGafica.odn_image1_odid;
            }
            else
            {
                if (tobRegistro.Odn_prexis_odde == "1")
                {
                    lcrImagenGrafica = tobRegGafica.odn_image2_odid;
                }
                else if (tobRegistro.Odn_estact_odac == "1" || tobRegistro.Odn_estact_odac == "2")
                {
                    lcrImagenGrafica = tobRegGafica.odn_image1_odid;
                }
                else if (tobRegistro.Odn_estact_odac == "3")
                {
                    lcrImagenGrafica = tobRegGafica.odn_image3_odid;
                }
                lcrImagenGrafica = String.IsNullOrWhiteSpace(lcrImagenGrafica) ? tobRegGafica.odn_image1_odid : lcrImagenGrafica;

            }
            return lcrImagenGrafica;
        }
        #endregion
        #region fobRegMaestroTratamiento: Registro maestro del tratamiento
        /// <summary>
        /// <para>Devuelve registro maestro del tratamiento</para>
        /// </summary>
        public static ModeloOdnMaestroTratamiento fobRegMaestroTratamiento(String tcrCodigoTratamiento)
        {
            ModeloOdnMaestroTratamiento lobReturn = null;
            var lobReg = ModeloOdnMaestroTratamiento.flsListaOdneventosmaestEx("1", tcrCodigoTratamiento);
            if (lobReg != null && lobReg.Count != 0) { lobReturn = lobReg.FirstOrDefault(); }
            return lobReturn;
        }
        #endregion
        #region fobRegAdmisionAuxiliar: Generar registro admisión desde maestro o registro usuario atendido
        /// <summary>
        /// <para>Generar el registro desde Maestro Admision o en segundo caso lo carga de manera auxiliar desde</para>
        /// <para>Maestro Usuarios Atendidos, asumiendo que tcrCodigoAdmision contiene el Id unico de usuario en sistema.</para>
        /// </summary>
        public static ADMModeloAdmadmisiones fobRegAdmisionAuxiliar(String tcrCodigoAdmision)
        {
            // Cargar registro admision
            ADMModeloAdmadmisiones lobRegistro = null;
            var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(tcrCodigoAdmision);
            if (lobRegAdm.Count == 0)
            {
                // Se asume que en el campo Admision esta el Id unico del usuario, porque 
                // el dato que se quiere mostrar es un evento de cargue de algun archivo de recurso externo
                var lobRegUsuario = SIAModeloUsuariosAtendidos.fobRegSiausuarioatend(tcrCodigoAdmision);

                if (lobRegUsuario != null)
                {
                    // Cargar datos basicos admision desde maestro usuario atendido
                    // Esto es porque los cargue de recursos desde el modulo de gestion masivo o escaner
                    // no generan registro en admision de paciente
                    lobRegistro = new ADMModeloAdmadmisiones
                    {
                        #region Datos
                        Adm_secadm_rgad = lobRegUsuario.Sia_idesec_usua, // este dato es para compatibilidad al cargar recursos 
                        Sia_idesec_usua = lobRegUsuario.Sia_idesec_usua,
                        Sia_tipide_tide = lobRegUsuario.Sia_tipide_tide,
                        Sia_nroide_usua = lobRegUsuario.Sia_nroide_usua,
                        Hcl_nrohis_hicl = lobRegUsuario.Hcl_nrohis_hicl,
                        Cto_seccon_cont = lobRegUsuario.Cto_seccon_cont,
                        Cto_nrocon_cont = lobRegUsuario.Cto_nrocon_cont,
                        Sia_codeps_teps = lobRegUsuario.Sia_codeps_teps,
                        Sia_edapac_usua = (int)lobRegUsuario.Sia_edapac_usua,
                        Sia_codmed_tmed = lobRegUsuario.Sia_codmed_tmed,
                        Sia_edaano_usua = (int)lobRegUsuario.Sia_edaano_usua,
                        Sia_edames_usua = (int)lobRegUsuario.Sia_edames_usua,
                        Sia_edadia_usua = (int)lobRegUsuario.Sia_edadia_usua,
                        Sia_edaymd_usua = lobRegUsuario.Sia_edaymd_usua,
                        Sia_tipusu_regi = lobRegUsuario.Sia_tipusu_regi,
                        Sia_tipafi_tafi = lobRegUsuario.Sia_tipafi_tafi,
                        Sia_nivsbn_nsbn = lobRegUsuario.Sia_nivsbn_nsbn,
                        Sia_tippob_tpob = lobRegUsuario.Sia_tippob_tpob,
                        Sia_nivcon_ncon = lobRegUsuario.Sia_nivcon_ncon,
                        Sis_codocu_ocup = lobRegUsuario.Sis_codocu_ocup,
                        Sis_idemun_muni = lobRegUsuario.Sis_idemun_muni,
                        Sia_codcat_ceat = lobRegUsuario.Sia_codcat_ceat,
                        Sys_codusu_usux = lobRegUsuario.Sys_codusu_usux,
                        Adm_conest_rgad = 0,
                        Sis_estpro_espr = "2",
                        #endregion
                    };
                }
            }
            else
            {
                lobRegistro = lobRegAdm.FirstOrDefault();
            }

            return lobRegistro;
        }
        #endregion
        //------------------------------------------------------------
        // Funciones utilitarias para graficar Escalea EAD
        //------------------------------------------------------------
        #region fcvGenerarVistaDatosEscalaEAD: Generar vista datos en escala EAD
        /// <summary>
        /// <para>Generar vista datos en escala EAD</para>
        /// </summary>
        public static void fcvGenerarVistaDatosEscalaEAD(String tcrModoEdicion, String tcrLineaDatos, ref List<ListCrtComboBox> tmpListObjetos)
        {
            // 11-1,12-0,13-1,14-1,...

            String[] larArray = tcrLineaDatos.Split(",".ToCharArray());

            if (larArray.Length > 0)
            {
                var lnuTotElemtos = larArray.Length;
                String[] larLinea;
                var i = 0;

                for (i = 0; i < lnuTotElemtos; i++)
                {
                    larLinea = (larArray[i].Trim()).Split("-".ToCharArray());

                    if (larLinea.Length > 1)
                    {
                        var lnuIdRegistro = Convert.ToInt32(larLinea[0].Trim());

                        var lobRefObj = tmpListObjetos.FirstOrDefault(x => x.IdRegistro == lnuIdRegistro);
                        if (lobRefObj != null)
                        {
                            if (tcrModoEdicion != "E")
                            {
                                lobRefObj.TextBoxRef.Text = larLinea[1].Trim() == "1" ? "SI" : "NO";
                            }
                            else
                            {
                                lobRefObj.TextBoxRef.Text = larLinea[1].Trim();
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region fcvGenerarStringDatosEscalaEAD: Generar lista string para guardar en base de datos
        /// <summary>
        /// <para>lista string para guardar en base de datos</para>
        /// </summary>
        public static String fcrGenerarStringDatosEscalaEAD(ref List<ListCrtComboBox> tmpListObjetos)
        {
            var lcrValor = String.Empty;
            foreach (var lobReg in tmpListObjetos)
            {
                if (lobReg.TextBoxRef.Text == "1" || lobReg.TextBoxRef.Text == "0")
                {
                    var lcrDato = lobReg.IdRegistro.ToString().Trim() + "-" + lobReg.TextBoxRef.Text;
                    lcrValor = String.IsNullOrWhiteSpace(lcrValor) ? lcrDato : lcrValor + "," + lcrDato;
                }
            }
            return lcrValor;
        }
        #endregion
        #region fnuEscalaEADRangoSegunEdad: Devuelve el numero de rango segun area y edad del niño
        /// <summary>
        /// <para>Devuelve el numero de rango segun area y edad del niño</para>
        /// </summary>
        public static String fcrEscalaEADRangoSegunEdad(String tcrArea, String tcrEdad)
        {
            var lcrEdad = Convert.ToInt32(tcrEdad);
            var lcrReturn = String.Empty;

            var lobRegTmp = HCLValidarCodigo.fobRegBuscarHcltesteadescalRango(tcrArea.ToUpper(), lcrEdad);

            if (lobRegTmp != null)
            {
                var loRegAux = HCLValidarCodigo.fobRegBuscarHcltesteadrango(lobRegTmp.hcl_nroreg_hcer);
                lcrReturn = "VR" + (loRegAux.hcl_nroran_hcer).ToString().Trim() + tcrArea.ToUpper();
            }
            return lcrReturn;
        }
        #endregion
    }
    public class HclGenFacturServicios
    {
        //------------------------------------------------------------
        // Funciones Para generar Facturacion 
        //------------------------------------------------------------
        // Variables para gestion facturas
        #region Variables Generales
        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public ModeloHclregordeserms tmpRegMaestro = null;
        public ModeloHclregordeserde tmpRegDetalle = null;
        public FcmFacturarServicios gobLiq = new FcmFacturarServicios();
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public Aplicacion oApp = Aplicacion.Instancia();

        public String gcrTipoRegistro = String.Empty;           // FMED = Formula medica HCON=Hoja de consumo
        public String gcrCodigoProfesional = String.Empty;
        public String gcrCodigoAdmision = String.Empty;
        public String gcrCodigoAuxiliar = String.Empty;
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");

        //FCMMAESFACTURAS: Maestro de facturas en Ordenes de servicios medicos
        #region FCMMAESFACTURAS: Propiedad registro activo tmpRegFact
        /// <summary>
        ///  Registro activo tabla: Maestro facturas fcmmaesfacturas
        /// </summary>
        public FcmModeloMaestrofacturas tmpRegFact = new FcmModeloMaestrofacturas();
        #endregion
        #region FCMMAESFACTURAS: Propiedad lista registros maestro facturas: tmpListFact
        /// <summary>
        ///  Lista de registros tabla: fcmmaesfacturas Vista del Browser
        ///  para la grilla.
        /// </summary>
        public List<FcmModeloMaestrofacturas> tmpListFact;
        #endregion
        #region FCMMAEDETALLFAC: Propiedad Temporal para Edicion: tmpListDetallEdt
        /// <summary>
        ///  Lista registros tabla: detalles de facturación fcmmaedetallfac
        /// </summary>
        public List<FcmModeloServDetallFacturas> tmpListDetallEdt;
        #endregion
        #endregion
        //Funcion de inicio principal
        #region Confirmar Servicios
        /// <summary>
        ///  Confirmar servicios y generar datos en facturacion
        /// </summary>
        /// <param name="tcrTipoRegistro">Tipo registro FMED = Formula medica HCON=Hoja de consumo</param>
        /// <param name="tcrCodigoAdmision">Codigo Admision del paciente</param>
        /// <returns></returns>
        public bool ConfirmarServiciosFacturacion(String tcrTipoRegistro, String tcrCodigoAdmision)
        {
            var llgReturn = false;
            gcrTipoRegistro = tcrTipoRegistro;
            gcrCodigoAdmision = tcrCodigoAdmision;

            tmpRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmisionSimple(gcrCodigoAdmision);
            tmpRegMaestro = ModeloHclregordeserms.flsListaHclregordesermsEx(tcrTipoRegistro, gcrCodigoAdmision, "1").FirstOrDefault();
            gcrCodigoProfesional = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario).sia_codpfa_prof;

            if (tmpRegMaestro != null)
            {
                switch (gcrTipoRegistro)
                {

                    case "FMED":
                        llgReturn = flgConfirmarRegistroServicios();
                        break;

                    case "HCON":
                        llgReturn = flgConfirmarRegistroServicios();
                        break;
                }

            }

            return llgReturn;
        }
        #endregion
        // Confirmar Servicios
        #region flgConfirmarRegistroServicios: Hoja consumo y formaulas medicas
        /// <summary>
        /// <para>Confirmar registro maestro Hoja consumo y formula medica (plan manejo externo)</para> 
        /// </summary>
        public bool flgConfirmarRegistroServicios()
        {
            var llgReturn = false;
            var lcrCodigoHistorial = fcvHclinicaGenerarActividad();

            tmpRegMaestro.Hcl_nroreg_hcev   = lcrCodigoHistorial;
            tmpRegMaestro.Sis_estpro_espr   = "2";
            tmpRegMaestro.Sia_codpfa_prof   = gcrCodigoProfesional;

            ModeloHclregordeserms.fcvActualizar(tmpRegMaestro);
            // cerrar registros detalles
            var lobDetall = ModeloHclregordeserde.flsListaHclregordeserde("R1", tmpRegMaestro.Hcl_nroreg_hcms);
            if (lobDetall.Count != 0)
            {
                foreach (var lobReg in lobDetall)
                {
                    lobReg.Sis_estpro_espr = "2";
                    ModeloHclregordeserde.fcvActualizar(lobReg);
                }
                llgReturn = true;
            }
            // Generar notificacion al confirmar
            fcvSYSGenerarNotificacion();

            // Generar datos en facturacion
            llgReturn = flgConfirmarFacturaServicios();
            if (llgReturn == false)
            {
                MessageBox.Show("No fué posible generar datos para facturación Metodo: flgConfirmarRegistroServicios()");
            }

            return llgReturn;
        }
        #endregion
        // Genera factura y detalles servicios
        #region flgConfirmarFacturaServicios: Generar datos de hoja consumo y fomulas medicas
        /// <summary>
        /// Generar datos de hoja consumo y formula medicas ambulatiorias para enviar a facturacion
        /// </summary>
        public bool flgConfirmarFacturaServicios()
        {
            var llgReturn = false;
            try
            {
                if (flgGenerarFacturasServicios("2"))
                {
                    // Generar de nuevo para tomar datos de la admision y turno citas
                    if (flgGenerarFacturasServicios("1"))
                    {
                        llgReturn = flgConfirmarFacturasServicios();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Utilidades Error Metodo: flgConfirmarFacturaServicios() Confirmar factura y detalles factura");
            }
            return llgReturn;
        }
        #endregion
        #region flgGenerarFacturasServicios: Guardar en temporal Registro Relacion auxiliar
        /// <summary>
        /// Genera factura y servicios para hoja de consumo o formulas medicas
        /// <para>PARAMETROS:</para>
        /// <para>tcrAccion: "1" = Generar registro activo y resumen facturación "2" = No generar registro activo ni resumen facturación</para>
        /// </summary>
        public bool flgGenerarFacturasServicios(String tcrAccion)
        {
            String lcrValorReturn       = String.Empty;
            String lcrNumeroRegistro    = "GEN-FACTURA";
            String lcrCodigoError       = "GEN-FACTURA";
            String lcrNombreCampo       = "Generar factura desde Hoja de consumo";
            String lcrNivelError        = "ALTO";
            String lcrImgNivelError     = "Edt_hist_vista_anulado.png";
            tmpLogErrores = new List<LogsErrores>();

            var llgReturn = false;
            var i = 0;
            var lnuErrores = 0;

            try
            {
                tmpListFact = null;
                //var tmpServi = ModeloCitmaestroprotocolo.flsListaCitservprotocol(G1Cit_codspr_spro);
                var tmpTablaDetalEdt = ModeloHclregordeserde.flsListaHclregordeserde("R1", tmpRegMaestro.Hcl_nroreg_hcms);

                if (tmpTablaDetalEdt != null && tmpTablaDetalEdt.Count > 0)
                {
                    var tmpContrato = CTOValidarCodigo.fobRegBuscarCtomaescontrato(tmpRegAdm.Cto_seccon_cont);
                    var lcrCodigoDigiacion = String.Empty;

                    tmpListDetallEdt = new List<FcmModeloServDetallFacturas>();
                    gobLiq.tmpRegAdm = tmpRegAdm;

                    // Datos basicos del registro facturado
                    gobLiq.G2Adm_codtat_tatn = tmpRegAdm.Adm_codtat_tatn;
                    gobLiq.G2Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    gobLiq.G2Cto_seccon_cont = tmpRegAdm.Cto_seccon_cont;
                    gobLiq.G2Sia_aresol_aser = tmpRegAdm.Sia_codare_aser;
                    gobLiq.G2Sia_codare_aser = tmpRegMaestro.Sia_codare_aser;
                    gobLiq.G2Fcm_fecfac_mfac = Funciones.fcrConvertFecha(tmpRegMaestro.Hcl_gesfec_hcms);
                    gobLiq.G2Fcm_fecedt_dfac = Funciones.fcrFechaActual();
                    gobLiq.G2Fcm_estfac_mfac = "1";
                    gobLiq.G2Fcm_tiprfa_mfac = "1";

                    // Generar servicios 
                    foreach (var lobReg in tmpTablaDetalEdt)
                    {
                        lcrCodigoDigiacion = lobReg.Hcl_envalm_hcor == "1" ? lobReg.Fcm_secreg_dfac : lobReg.Fcm_coddig_mant; 
                        //var tmpSrv = FCMValidarCodigo.fobRegBuscarIuFcmmanservicios(lobReg.Fcm_coddig_mant, tmpContrato.fcm_codman_mans);
                        var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(lcrCodigoDigiacion);
                        var tmpSrv = FCMValidarCodigo.fobRegBuscarIuFcmmanserviciosProg(lcrCodigoDigiacion, tmpContrato.fcm_codman_mans,
                                                                                        tmpContrato.cto_seccon_cont, tmpContrato.cto_serper_cont);

                        if (tmp != null && tmpSrv != null)
                        {
                            if (lobReg.Hcl_envfac_hcor == "1") // si el registro esta marcado para enviar a facturacion
                            {
                                i++;
                                // Valores de digitacion
                                gobLiq.G2Sia_codpfa_prof = lobReg.Sia_codpfa_prof;
                                gobLiq.G2Fcm_coddig_mant = lcrCodigoDigiacion;
                                gobLiq.G2Sia_tipact_tsac = tmp.sia_tipact_tsac;
                                gobLiq.G2Fcm_totuni_dfac = lobReg.Hcl_totuni_hcor;
                                gobLiq.G2Hcl_codreg_hcca = "NA";
                                gobLiq.G2Fcm_codcpr_cpro = lobReg.Fcm_codcpr_cpro;
                                gobLiq.G2Fcm_fecser_dfac = Funciones.fcrConvertFecha(lobReg.Hcl_gesfec_hcor);
                                gobLiq.G2Fcm_horser_dfac = lobReg.Hcl_geshor_hcor.ToString();
                                gobLiq.G2Fac_horprs_dfac = gobLiq.G2Fcm_horser_dfac;

                                // completar Rips
                                gobLiq.G2Sia_codfco_fcon = tmp.sia_codfco_fcon;
                                gobLiq.G2Sia_codfpr_fpor = tmp.sia_codfpr_fpro;
                                gobLiq.G2Sia_codpat_tpat = tmp.sia_codpat_tpat;
                                gobLiq.G2Sia_coddia_tdia = String.IsNullOrWhiteSpace(gobLiq.G2Sia_coddia_tdia) ? tmpRegAdm.Sia_coddia_tdia : gobLiq.G2Sia_coddia_tdia;
                                gobLiq.G2Fcm_valser_mant = (float)tmpSrv.fcm_valser_mant;

                                // generar el numero de registro
                                if (tcrAccion == "1")
                                {
                                    tmpRegAdm.Adm_conest_rgad++;
                                    gobLiq.G2Fcm_secreg_dfac = "R" + tmpRegAdm.Adm_conest_rgad.ToString().Trim();
                                    gobLiq.tmpRegAdm.Adm_conest_rgad = tmpRegAdm.Adm_conest_rgad;

                                    //-  para agrupar o separar registros segun contrato y tipo actividad
                                    gobLiq.G2Fcm_secreg_mfac = "XXT" + tmpRegAdm.Cto_seccon_cont.Trim();
                                    if (gobLiq.G2Cto_sepser_cont == "1") // Separa por tipo de servicio
                                    {
                                        gobLiq.G2Fcm_secreg_mfac = "XXT" + gobLiq.G2Sia_tipact_tsac.Trim() + gobLiq.G2Cto_seccon_cont.Trim();
                                    }
                                }
                                // Validar y generar el registro a facturar desde parametros en manuales y servicios IPS
                                if (gobLiq.flgGenValidarRegistro(ref tmpLogErrores, i.ToString() + "-SERVICIO-" + lobReg.Fcm_coddig_mant))
                                {
                                    if (tcrAccion == "1")
                                    {
                                        var lobRegDe = gobLiq.fobGenRegistroServicioFacturado();
                                        tmpListDetallEdt.Add(lobRegDe);
                                    }
                                }
                                else
                                {
                                    lnuErrores++;
                                }
                            }
                        }
                        else
                        {
                            var lcrSeparador = String.IsNullOrWhiteSpace(lcrValorReturn) ? "" : "/";
                            lcrValorReturn += lcrSeparador + "SERVICIO NO AUTORIZADO EN CONTRATO: " +
                                                              lobReg.Fcm_coddig_mant + " - " + lobReg.Fcm_desser_sips;
                            lnuErrores++;
                        }
                    }

                    llgReturn = lnuErrores == 0 ? true : false;
                    if (llgReturn == true && tcrAccion == "1")
                    {
                        tmpListFact = gobLiq.flsGenerarResumenFacturas();
                    }
                }
                //- Registrar error 
                //lcrValorReturn = i == 0 ? "No existen actividades para el programa: " + G1Cit_codspr_spro : String.Empty;
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Utilidades Error Metodo: flgGenerarFacturasServicios()");
            }
            return llgReturn;
        }
        #endregion
        #region flgConfirmarFacturasServicios: Genera los numeros de factura
        /// <summary>
        /// <para>Genera los nuevos numeros de prefactura o factura y guarda en maestro factura</para>  
        /// <para>actualiza los registros detalles facturacion Hoja de consumo y Formulas medicas</para>  
        /// </summary>
        public bool flgConfirmarFacturasServicios()
        {
            var llgReturn = false;
            try
            {
                var lcrNewOrdenserv = String.Empty;
                if (tmpListFact == null) { return llgReturn; }

                foreach (FcmModeloMaestrofacturas lobFact in tmpListFact)
                {
                    lcrNewOrdenserv = SysModelo.fcrGenerarNuevoCodigo("FCM-ORDENSERVICIOS", "FCM", "Ordenes de servicios medicos");
                    //lobFact.Fcm_numfac_mfac = SysModelo.fcrGenerarNuevoCodigo("FCM-SECUENCIAL-FACTURAS", "FCM", "Secuencial facturas de venta");
                    lobFact.Fcm_secres_srfa = "NA";
                    lobFact.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    lobFact.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    lobFact.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    lobFact.Fcm_tiprfa_mfac = "1";
                    lobFact.Sia_tipact_tsac = "1"; // Puede cambiar al confirmar factura
                    lobFact.Sia_regate_rgat = "2";
                    lobFact.Fcm_numfac_mfac = String.Empty; // que pase a facturacion en estado abierto
                    lobFact.Fcm_estfac_mfac = "1";
                    lobFact.Fcm_desfac_mfac = "ABIERTA";
                    lobFact.Sis_estado_imaen = "A";
                    lobFact.Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                    int lnuIndice = 1;
                    //- Actualizar detalles de servicios
                    foreach (FcmModeloServDetallFacturas lobServ in tmpListDetallEdt)
                    {
                        lobServ.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                        lobServ.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                        lobServ.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                        if (lobServ.Fcm_secreg_mfac.Trim() == lobFact.Fcm_secreg_mfac.Trim())
                        {
                            lobServ.Fcm_numfac_mfac = lobFact.Fcm_numfac_mfac;
                            lobServ.Fcm_estfac_mfac = lobFact.Fcm_estfac_mfac;
                            lobServ.Fcm_secreg_mfac = lcrNewOrdenserv;
                            lobServ.Sis_estado_imaen = "A";
                            lobServ.Sis_estpro_espr = "1";
                            lobServ.Fcm_tiprfa_mfac = lobFact.Fcm_tiprfa_mfac;

                            FcmModeloServDetallFacturas.flgAddRegistro(lobServ, lobServ.Adm_secadm_rgad);
                        }
                        lnuIndice++;
                    }
                    lobFact.Fcm_secreg_mfac = lcrNewOrdenserv;
                    FcmModeloMaestrofacturas.flgAddRegistro(lobFact);
                }
                ADMModeloAdmadmisiones.fcvActualizarEstados(tmpRegAdm.Adm_secadm_rgad, "", "", "", "", "", tmpRegAdm.Adm_conest_rgad);
                llgReturn = true;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Utilidades Error Metodo: flgConfirmarFacturasServicios()");
            }
            return llgReturn;
        }
        #endregion
        // fcvclinicaGenerarActividad: Registro de actividad en Historial clinico
        #region fcvHclinicaGenerarActividad: Generar registro para atencion en historia clinica
        /// <summary>
        /// <para>Generar registro en historial clinico</para>
        /// </summary>
        public String fcvHclinicaGenerarActividad()
        {
            var lcrCodgioRegHist = String.Empty;
            try
            {
                var lobRegEx = HCLValidarCodigo.fobRegBuscarHcltiporegserms(gcrTipoRegistro);
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(lobRegEx.hcl_codreg_hcca);

                if (!String.IsNullOrWhiteSpace(lobReg.grp_idepla_grpl))
                {
                    // Generar registro de actividad en historia clinica
                    var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);
                    var lobHist = new HclModeloHistorialEventos();

                    #region Datos del registro
                    lobHist.Hcl_secreg_hcev = 1;
                    lobHist.Hcl_nrohis_hicl = tmpRegAdm.Hcl_nrohis_hicl;
                    lobHist.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    lobHist.Cit_codasi_mcit = tmpRegAdm.Cit_codasi_mcit;
                    lobHist.Fcm_codcpr_cpro = String.Empty;
                    lobHist.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    lobHist.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    lobHist.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    lobHist.Hcl_codaux_hcev = tmpRegMaestro.Hcl_nroreg_hcms;
                    lobHist.Hcl_gesfec_hcev = tmpRegMaestro.Hcl_gesfec_hcms;
                    lobHist.Hcl_geshor_hcev = tmpRegMaestro.Hcl_geshor_hcms;
                    lobHist.Sia_codpfa_prof = tmpRegMaestro.Sia_codpfa_prof;
                    lobHist.Hcl_keydat_hcev = fcrGenerarLlaveMs(tmpRegMaestro).ToLower() + " " + lobRegEx.hcl_desreg_hctr.ToLower();
                    lobHist.Hcl_xmldat_hcev = String.Empty;
                    lobHist.Hcl_xmltmp_hcev = String.Empty;
                    lobHist.Hcl_xmlcom_hcev = String.Empty;
                    lobHist.Hcl_conobj_hcev = 0;
                    lobHist.Hcl_desreg_hcev = lobRegEx.hcl_desreg_hctr;
                    lobHist.Hcl_codreg_hcca = lobReg.hcl_codreg_hcca;
                    lobHist.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                    lobHist.Grp_idepla_grpv = loPlant.grp_idepla_grpv;
                    lobHist.Fcm_secreg_dfac = String.Empty;
                    lobHist.Sis_estpro_espr = "2";  // cerrado por defecto

                    lcrCodgioRegHist = HclModeloHistorialEventos.fcrAddRegistro(lobHist);
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Utilidades Error Metodo: fcvHclinicaGenerarActividad");
            }
            return lcrCodgioRegHist;

        }
        #endregion
        // fcvSYSGenerarNotificacion: Registro notificaciones para servicios comfirmados
        #region fcvGenerarNotificacion: Generar registro notificacion del sistema
        /// <summary>
        /// <para>Generar registro notificacion del sistema</para>
        /// </summary>
        public void fcvSYSGenerarNotificacion()
        {
            try
            {
                var oApp = Aplicacion.Instancia();
                var lcrTipoMensPublico      = "1";  // Publico por defecto
                var lcrTipoIdNotfificacion  = "HOS-HOJA-CONSUMO";
                var lcrIdModuloNotfific     = String.Empty;
                var lcrIdUsuarioRecibe      = String.Empty;
                var lcrIdPerfilRecibe       = String.Empty;

                if (gcrTipoRegistro == "HCON")
                {
                    //Hoja de consumo 
                    lcrTipoIdNotfificacion = "HOS-HOJA-CONSUMO";
                    lcrTipoMensPublico = "1";
                }
                else if (gcrTipoRegistro == "FMED")
                {
                    // Formula medica 
                    lcrTipoIdNotfificacion = "CEX-FORMULA-MEDICA";
                    lcrTipoMensPublico = "1";
                }
                else
                {
                    // Otras
                }

                var lobReg = SYSValidarCodigo.fobRegBuscarSysadmstipomens(lcrTipoIdNotfificacion);
                var lcrIden = "ADMISIÓN: " + tmpRegMaestro.Adm_secadm_rgad.Trim() + " " +
                                             tmpRegMaestro.Sia_tipide_tide.Trim() + " " + tmpRegMaestro.Sia_nroide_usua.Trim();
                var lcrDesc = tmpRegAdm.Sia_nomusu_usua;

                var lcrLlave = tmpRegMaestro.Adm_secadm_rgad + "*" + tmpRegMaestro.Hcl_nroreg_hcms;
                if (gcrTipoRegistro == "FMED" && !String.IsNullOrWhiteSpace(gcrCodigoAuxiliar))
                {
                    lcrLlave = tmpRegMaestro.Adm_secadm_rgad + "*" + tmpRegMaestro.Hcl_nroreg_hcms + "*" + gcrCodigoAuxiliar;
                }

                var lobjRegistro = new SysModeloAdminMensajes();

                lobjRegistro.Sys_codsec_syam = String.Empty;    // lo genera la funcion de gestion
                lobjRegistro.Sys_llavis_syam = 0;               // lo genera la funcion de gestion
                lobjRegistro.Sys_parent_syam = String.Empty;
                lobjRegistro.Sys_desmsj_syam = lcrIden;
                lobjRegistro.Sys_notmsj_syam = lcrDesc;
                lobjRegistro.Sys_regeve_sytm = lcrLlave;
                lobjRegistro.Sys_tipmsj_syam = lcrTipoMensPublico;
                lobjRegistro.Sys_coduse_usux = oApp.gcrUsuIdUsuario;
                lobjRegistro.Sys_codusu_usux = lcrIdUsuarioRecibe;
                lobjRegistro.Sys_codtip_sytm = lcrTipoIdNotfificacion;
                lobjRegistro.Sys_codmsg_symg = lcrIdModuloNotfific;     // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_codper_perf = lcrIdPerfilRecibe;       // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_sisfec_syam = tmpRegMaestro.Hcl_gesfec_hcms;
                lobjRegistro.Sys_sishor_syam = tmpRegMaestro.Hcl_geshor_hcms;
                lobjRegistro.Sys_vinfec_syam = Funciones.fdaConvertFecha("DMY", "/", Funciones.fcrFechaActual());
                lobjRegistro.Sys_vinhor_syam = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                lobjRegistro.Sys_vfnfec_syam = ((DateTime)tmpRegMaestro.Hcl_gesfec_hcms).AddDays((Double)lobReg.sys_tievig_sytm);
                lobjRegistro.Sys_vfnhor_syam = lobjRegistro.Sys_vinhor_syam;
                lobjRegistro.Sys_vfrfec_syam = Convert.ToDateTime("01/01/1000");
                lobjRegistro.Sys_vfrhor_syam = 0;
                lobjRegistro.Sys_msjvis_syam = "1";

                SysNotificaciones.flgGenerarNotificaciones(lobjRegistro);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Confirmar servicios Error Metodo: fcvSYSGenerarNotificacion");
            }
        }
        #endregion
        // Generar llaves
        #region fcrGenerarLlaveMs: Generar llave de busquda para el objeto
        /// <summary>
        /// <para>Generar llave de busquda para el objeto</para>
        /// </summary>
        public String fcrGenerarLlaveMs(ModeloHclregordeserms tobRegistro)
        {
            // llave registro maestro
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + "  " + tobRegistro.Adm_secadm_rgad + "  " + tobRegistro.Hcl_nroreg_hcms;
            var lcrllave2 = tobRegistro.Hcl_gesfec_hcms.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + "  " + tobRegistro.Sia_desare_aser;
            var lcrllave4 = String.Empty;

            // llave de los detalles
            var lobDetall = ModeloHclregordeserde.flsListaHclregordeserde("R1", tobRegistro.Hcl_nroreg_hcms);
            if (lobDetall.Count != 0 && lobDetall != null)
            {
                foreach (var lobReg in lobDetall)
                {
                    lcrllave4 += " " + fcrGenerarLlaveDetalles(lobReg);
                }
            }
            return lcrllave1 + "  " + lcrllave2 + "  " + lcrllave3 + " " + lcrllave4;
        }
        #endregion
        #region fcrGenerarLlaveDetalles: Generar llave desde registros detalles
        /// <summary>
        /// <para>Generar llave desde registros detalles</para>
        /// </summary>
        public String fcrGenerarLlaveDetalles(ModeloHclregordeserde tobRegistro)
        {
            var lcrllave1 = tobRegistro.Fcm_idesec_sips + " " + tobRegistro.Fcm_desser_sips + " " + tobRegistro.Hcl_notreg_hcor;
            var lcrllave2 = tobRegistro.Fcm_coddig_mant;

            return lcrllave1 + " " + lcrllave2;
        }
        #endregion
    }
    //------------------------------------------------------------
    // TEMPORAL REFERENCIA VISTA OBJETOS GENERAL
    //------------------------------------------------------------
    #region ClassRegistroVista: temporarl para referencia de objetos en la vista
    /// <summary>
    /// <para>temporarl para referencia de objetos en vista</para>
    /// </summary>
    public class ClassRegistroVista
    {
        public FrameworkElement RefObjeto { get; set; }     // Referencia a la instancia del Objeto en la vista
        public String IdRegistro { get; set; }              // llave unica del registro en base de datos
        public String RegEventoHist { get; set; }           // HCL_NROREG_HCEV	Código secuencial del evento en historial del paciente
        public String NumeroAdmision { get; set; }          // Numero de Admision
        public String LlaveBusqueda { get; set; }           // llave de busqueda
        public String LlaveAuxiliar { get; set; }           // llave auxiliar para alguna funcionalidad adicional
        public String TipoRegistro { get; set; }            // "SERV" = ordenes de Servicios "HCON" = Hoja de consumo y otros
        public String EstadoRegistro { get; set; }          // Estado del registro 1,2,3 Abierto Confirmado Anulado
        public String ClickRefObjeto { get; set; }          // el objeto tiene el evento click referenciado
        public String DatoAuxiliar { get; set; }            // Dato Auxiliar 
    }
    #endregion
    //------------------------------------------------------------
    // TEMPORAL REFERENCIA COMBOBOX CONTROLES DE USUARIOS PARA TEST
    //------------------------------------------------------------
    #region ListaSeleccion: clase para devolver listas de propositos generales en vistas de seleccion
    /// <summary>
    /// <para>clase para cargar lista de notificaciones de gestion de datos</para>
    /// </summary>
    public class ListCrtComboBox
    {
        #region Parametros
        /// <summary>Referencia al objeto textbox</summary>
        public TextBox TextBoxRef { get; set; }
        /// <summary>Nombre del objeto TextBox</summary>
        public String TextBoxNombre { get; set; }
        /// <summary>Referencia al objeto combobox</summary>
        public ComboBox ComboBoxRef { get; set; }
        /// <summary>Nombre del objeto combobox</summary>
        public String ComboBoxNombre { get; set; }
        /// <summary>Id unico numerico cada registro en el formato</summary>
        public int IdRegistro { get; set; }
        /// <summary>Codigo del rango numerico</summary>
        public int CodigoRango{ get; set; }
        #endregion
    }
    #endregion

}

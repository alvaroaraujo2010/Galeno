using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using Datos.Modelos;
using Sistema.Modelo;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Clases;
using Sistema.Validacion;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for HCL_SolicitOrdConfirmar.xaml
    /// </summary>
    public partial class SolicitOrdConfirmar : Window, SIS_Interface
    {
        #region Variables Generales
        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public ModeloHclregordeserms tmpRegMaestro = null;
        public ModeloHclregordeserde tmpRegDetalle = null;
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();

        private String gcrCtrF2TexBox = String.Empty;
        public String gcrTipoRegistro = String.Empty;
        public String gcrCodigoAdmision = String.Empty;
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public Aplicacion oApp = Aplicacion.Instancia();
        #endregion
        #region Clase Objeto para liquidar valores servicios
        /// <summary>
        ///  Parametros generales para liquidar servicios de facturación
        /// </summary>
        public FcmFacturarServicios gobLiq = new FcmFacturarServicios();
        #endregion
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
        //Clase principal
        #region SolicitOrdConfirmar Clase principal
        public SolicitOrdConfirmar(String tcrTipoRegistro, String tcrCodigoAdmision)
        {
            InitializeComponent();

            gcrTipoRegistro = tcrTipoRegistro;
            gcrCodigoAdmision = tcrCodigoAdmision;

            tmpRegAdm   = ADMModeloAdmadmisiones.flsListaAdmregadmisionSimple(gcrCodigoAdmision);
            var lobReg  = ModeloHclregordeserms.flsListaHclregordesermsEx(tcrTipoRegistro, gcrCodigoAdmision, "1");
            if (lobReg.Count != 0)
            {
                tmpRegMaestro = lobReg.FirstOrDefault();
            }
            this.txtG1Sia_codpfa_prof.Text = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario).sia_codpfa_prof;
        }
        #endregion
        //-------------------------------------------------
        // Eventos Auxiliares
        //-------------------------------------------------
        #region Eventos Auxiliares
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void btnCerrar_KeyDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        #region fcvTouchEnterTeclado: mostrar teclado virtual
        private void fcvTouchEnterTeclado(object sender, TouchEventArgs e)
        {
            if (Process.GetProcessesByName("OSK").Length < 1)
            {
                TextBox lobTexto = sender as TextBox;
                Process.Start("osk.exe");
                FocusManager.SetFocusedElement(this, lobTexto);
            }
        }
        #endregion
        //-------------------------------------------------
        //  KeyDown y GotFocus General
        //-------------------------------------------------
        //-Clic en Boton Guardar
        #region fcvGuardarRegistro: Confirmar registro
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            var lcrNuevoCodigo = String.Empty;
            if (flgValidacion() == true)
            {
                if (flgConfirmarRegistros())
                {
                    fcvRetornoInterface(tmpRegMaestro.Hcl_nroreg_hcms);
                }
                else 
                {
                    MessageBox.Show("Error al confirmar datos.");
                }
            }
            else
            {
                MessageBox.Show("No es posible confirmar datos.");
            }
        }
        #endregion
        #region  Actualizar registro 
        //- Activar modo edicion en la Vista
        public bool flgConfirmarRegistros()
        {
            var llgReturn = false;
            if (tmpRegMaestro != null)
            {
                switch (gcrTipoRegistro)
                {
                    case "SERV":
                        llgReturn = flgConfirmarRegistroServicios();
                        break;

                    case "FMED":
                        llgReturn = flgConfirmarRegistroFormulaMedica();
                        break;

                    case "EVOL":
                        llgReturn = flgConfirmarRegistroEvolucion();
                        break;

                    case "NENF":
                        llgReturn = flgConfirmarRegistroEvolucion();
                        break;

                    case "HCON":
                        llgReturn = flgConfirmarRegistroHojaConsumo();
                        break;

                    default:
                        var lcrTipo = gcrTipoRegistro;
                        if (lcrTipo == "RDOC" || lcrTipo == "RXLS" || lcrTipo == "RPDF"
                        || lcrTipo == "RIMG" || lcrTipo == "RVID" || lcrTipo == "RXML"
                        || lcrTipo == "RHL7")
                        {
                            llgReturn = flgConfirmarRegistroRecursos();
                        }
                        break;

                }
            }
            return llgReturn;
        }
        #endregion
        #region fcvRetornoInterface
        /// <summary>
        /// Retoma la interfase con la ventana principal
        /// entrega el codigo seleccionado y cierra el Browser
        /// </summary>
        private void fcvRetornoInterface(string tcrCodigSelect)
        {
            SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
            if (lobRefEnlace != null)
            {
                this.Close();
                lobRefEnlace.fcvBuscarRegistro(tcrCodigSelect);
            }
        }
        #endregion
        #region flgConfirmarRegistroServicios
        /// <summary>
        /// <para>Confirmar registro maestro de servicios</para> 
        /// </summary>
        private bool flgConfirmarRegistroServicios()
        {
            var llgReturn = false;
            var lcrCodigoHistorial = fcvHclinicaGenerarActividad();

            tmpRegMaestro.Hcl_nroreg_hcev = lcrCodigoHistorial;
            tmpRegMaestro.Sis_estpro_espr = "2";
            tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
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
            return llgReturn;
        }
        #endregion
        #region flgConfirmarRegistroRecursos
        /// <summary>
        /// <para>Confirmar registro maestro de recursos imagenes videos pdf y otros</para> 
        /// </summary>
        private bool flgConfirmarRegistroRecursos()
        {
            var llgReturn = false;
            var lcrCodigoHistorial = fcvHclinicaGenerarActividad();

            tmpRegMaestro.Hcl_nroreg_hcev = lcrCodigoHistorial;
            tmpRegMaestro.Sis_estpro_espr = "2";
            tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
            ModeloHclregordeserms.fcvActualizar(tmpRegMaestro);
            // cerrar registros detalles
            var lobDetall = ModeloHclhistarchivos.flsListaHclhistarchivos("R1", tmpRegMaestro.Hcl_nroreg_hcms);
            if (lobDetall.Count != 0)
            {
                foreach (var lobReg in lobDetall)
                {
                    lobReg.Sis_estpro_espr = "2";
                    ModeloHclhistarchivos.fcvActualizar(lobReg);
                }
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region flgConfirmarRegistroEvolucion
        /// <summary>
        /// <para>Confirmar registro maestro evolucion medica  on nota de enfermeria</para> 
        /// </summary>
        private bool flgConfirmarRegistroEvolucion()
        {
            var llgReturn = false;
            var lcrCodigoHistorial = fcvHclinicaGenerarActividad();

            tmpRegMaestro.Hcl_nroreg_hcev = lcrCodigoHistorial;
            tmpRegMaestro.Sis_estpro_espr = "2";
            tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
            ModeloHclregordeserms.fcvActualizar(tmpRegMaestro);
            // cerrar registros detalles
            var lobDetall = ModeloHclregnotasmedi.flsListaHclregnotasmedi("R1", tmpRegMaestro.Hcl_nroreg_hcms);
            if (lobDetall.Count != 0)
            {
                foreach (var lobReg in lobDetall)
                {
                    lobReg.Sis_estpro_espr = "2";
                    ModeloHclregnotasmedi.fcvActualizar(lobReg);
                }
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region flgConfirmarRegistroHojaConsumo
        /// <summary>
        /// <para>Confirmar registro maestro de servicios Hoja de consumo</para> 
        /// </summary>
        private bool flgConfirmarRegistroHojaConsumo()
        {
            var llgReturn = false;
            // Cargar los parametros
            var lobClass = new HclGenFacturServicios();
            lobClass.gcrTipoRegistro    = gcrTipoRegistro;
            lobClass.gcrCodigoAdmision  = gcrCodigoAdmision;
            lobClass.tmpRegAdm          = tmpRegAdm;
            lobClass.tmpRegMaestro      = tmpRegMaestro;
            lobClass.gcrCodigoProfesional = tmpRegMaestro.Sia_codpfa_prof;

            llgReturn = lobClass.flgConfirmarRegistroServicios();
            tmpLogErrores = lobClass.tmpLogErrores;

            return llgReturn;
        }
        #endregion
        #region flgConfirmarRegistroFormulaMedica
        /// <summary>
        /// <para>Confirmar registro maestro formula medica (entrega medicamentos)</para> 
        /// </summary>
        private bool flgConfirmarRegistroFormulaMedica()
        {
            var llgReturn = false;
            // Cargar los parametros
            var lobClass = new HclGenFacturServicios();
            lobClass.gcrTipoRegistro        = gcrTipoRegistro;
            lobClass.gcrCodigoAdmision      = gcrCodigoAdmision;
            lobClass.tmpRegAdm              = tmpRegAdm;
            lobClass.tmpRegMaestro          = tmpRegMaestro;
            lobClass.gcrCodigoProfesional   = tmpRegMaestro.Sia_codpfa_prof;

            llgReturn = lobClass.flgConfirmarRegistroServicios();
            tmpLogErrores = lobClass.tmpLogErrores;

            return llgReturn;
        }
        #endregion
        // Genera factura y servicios progrmados
        #region flgConfirmarFacturaHojaConsumo: Confirmar factura y detalles factura
        /// <summary>
        /// Confirmar factura y detalles factura
        /// </summary>
        public bool flgConfirmarFacturaHojaConsumo()
        {
            var llgReturn = false;
            try
            {
                if (flgGenerarFacturasHojaConsumo("2"))
                {
                    // Generar de nuevo para tomar datos de la admision y turno citas
                    if (flgGenerarFacturasHojaConsumo("1"))
                    {
                        llgReturn = flgConfirmarFacturasHojaConsumo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Confirmar factura y detalles factura");
            }
            return llgReturn;
        }
        #endregion
        #region fcvGenerarFacturasHojaConsumo: Guardar en temporal Registro Relacion auxiliar
        /// <summary>
        /// Genera factura y servicios progrmados
        /// <para>PARAMETROS:</para>
        /// <para>tcrAccion: "1" = Generar registro activo y resumen facturación "2" = No generar registro activo ni resumen facturación</para>
        /// </summary>
        public bool flgGenerarFacturasHojaConsumo(String tcrAccion)
        {
            String lcrValorReturn    = String.Empty;
            String lcrNumeroRegistro = "GEN-FACTURA";
            String lcrCodigoError    = "GEN-FACTURA";
            String lcrNombreCampo    = "Generar factura desde Hoja de consumo";
            String lcrNivelError     = "ALTO";
            String lcrImgNivelError  = "Edt_hist_vista_anulado.png";
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

                    tmpListDetallEdt = new List<FcmModeloServDetallFacturas>();
                    gobLiq.tmpRegAdm = tmpRegAdm;

                    // Datos basicos del registro facturado
                    gobLiq.G2Adm_codtat_tatn = tmpRegAdm.Adm_codtat_tatn;
                    gobLiq.G2Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    gobLiq.G2Cto_seccon_cont = tmpRegAdm.Cto_seccon_cont;
                    gobLiq.G2Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                    gobLiq.G2Sia_aresol_aser = tmpRegAdm.Sia_codare_aser;
                    gobLiq.G2Sia_codare_aser = tmpRegMaestro.Sia_codare_aser;
                    gobLiq.G2Fcm_fecfac_mfac = Funciones.fcrConvertFecha(tmpRegMaestro.Hcl_gesfec_hcms); 
                    gobLiq.G2Fcm_fecedt_dfac = Funciones.fcrFechaActual();
                    gobLiq.G2Fcm_estfac_mfac = "1";
                    gobLiq.G2Fcm_tiprfa_mfac = "1";

                    // Generar servicios 
                    foreach (var lobReg in tmpTablaDetalEdt)
                    {
                        //var tmpSrv = FCMValidarCodigo.fobRegBuscarIuFcmmanservicios(lobReg.Fcm_coddig_mant, tmpContrato.fcm_codman_mans);
                        var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(lobReg.Fcm_coddig_mant);
                        var tmpSrv = FCMValidarCodigo.fobRegBuscarIuFcmmanserviciosProg(lobReg.Fcm_coddig_mant, tmpContrato.fcm_codman_mans,
                                                                                        tmpContrato.cto_seccon_cont, tmpContrato.cto_serper_cont);
                        if (tmp != null && tmpSrv != null)
                        {
                            i++;
                            // Valores de digitacion
                            gobLiq.G2Fcm_coddig_mant = lobReg.Fcm_coddig_mant;
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
                            gobLiq.G2Sia_coddia_tdia = tmpRegAdm.Sia_coddia_tdia;
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: flgGenerarFacturas");
            }
            return llgReturn;
        }
        #endregion
        #region flgConfirmarFacturasHojaConsumo: Genera los numeros de factura
        /// <summary>
        /// <para>Genera los nuevos numeros de factura y guarda en maestro factura</para>  
        /// <para>actualiza los registros detalles facutracion en las ordenes de servicios</para>  
        /// </summary>
        public bool flgConfirmarFacturasHojaConsumo()
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvConfirmarFacturas");
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Gestion seleccion desde Key F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "PROF":
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "XX":
                    break;
            }
        }
        #endregion
        #region KeyDown y GotFocus General
        private void fcvMoverFocus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }
        private void fcvTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.Source as TextBox;
            tb.SelectAll();
        }
        #endregion
        #region SIA_CODPFA_PROF : Profesionales que prestan servicios
        private void txtG1Sia_codpfa_prof_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
                gcrCtrF2TexBox = "PROF";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODPFA_PROF : Browser desde boton - Profesionales que prestan servicios
        private void fcvBuscarProfesional(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
            gcrCtrF2TexBox = "PROF";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacion: Validacion campos
        //-------------------------------------------------
        #region fcvValidacionTexto: Validacion campos
        /// <summary>
        /// <para>Validacion campos</para>
        /// </summary>
        private void fcvValidacionTexto(object sender, TextChangedEventArgs e)
        {
            var lobTextBox = sender as TextBox;
            fcrValidacion(lobTextBox.Name);
        }
        #endregion
        #region flgValidacion: Valida todos los datos antes de guardar
        /// <summary>
        /// Valida todos los datos antes de guardar
        /// </summary>
        public bool flgValidacion()
        {
            var lnuCont = 0;
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codpfa_prof"))) { lnuCont++; }
            return lnuCont == 0 ? true : false;
        }
        #endregion
        #region Validacion Campos: fcrValidacion
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        /// </summary>
        public String fcrValidacion(String tcrNombrePropiedad)
        {
            string lcrValorReturn = string.Empty;
            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "txtG1Sia_codpfa_prof":
                        if (string.IsNullOrWhiteSpace(this.txtG1Sia_codpfa_prof.Text))
                        {
                            lcrValorReturn = "Profesional que atiende: Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(this.txtG1Sia_codpfa_prof.Text);
                            if (tmp != null && tmp.sia_nompro_prof != null)
                            {
                                this.txtG1Sia_nompro_prof.Text = tmp.sia_nompro_prof;
                                tmpRegMaestro.Sia_codpfa_prof  = this.txtG1Sia_codpfa_prof.Text;
                            }
                            else
                            {
                                lcrValorReturn = "Profesional atiende: No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codpfa_prof, lcrValorReturn);
                        break;

                    case "XX":
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        private void fcvSetColorValidacion(TextBox tobObjeto, String tcrValorReturn)
        {
            tobObjeto.ToolTip = EdtUtilidades.SetToolTip(tcrValorReturn);
            if (!String.IsNullOrWhiteSpace(tcrValorReturn))
            {
                tobObjeto.BorderBrush = Brushes.Red;
            }
            else
            {
                tobObjeto.BorderBrush = Brushes.DarkTurquoise;
            }
        }
        #endregion
        //-------------------------------------------------
        // fcvclinicaGenerarActividad: Registro de actividad en Historial clinico
        //-------------------------------------------------
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
                    lobHist.Hcl_keydat_hcev = fcrGenerarLlaveMs(tmpRegMaestro).ToLower() +" "+ lobRegEx.hcl_desreg_hctr.ToLower();
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

                    lcrCodgioRegHist=HclModeloHistorialEventos.fcrAddRegistro(lobHist);
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvHclinicaGenerarActividad");
            }
            return lcrCodgioRegHist;

        }
        #endregion
        //-------------------------------------------------
        // fcvSYSGenerarNotificacion: Registro notificaciones
        //-------------------------------------------------
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
                var lcrDesc = tmpRegMaestro.Sia_nomusu_usua;

                var lobjRegistro = new SysModeloAdminMensajes();

                lobjRegistro.Sys_codsec_syam = String.Empty;    // lo genera la funcion de gestion
                lobjRegistro.Sys_llavis_syam = 0;               // lo genera la funcion de gestion
                lobjRegistro.Sys_parent_syam = String.Empty;
                lobjRegistro.Sys_desmsj_syam = lcrIden;
                lobjRegistro.Sys_notmsj_syam = lcrDesc;
                lobjRegistro.Sys_regeve_sytm = tmpRegMaestro.Adm_secadm_rgad + "*" + tmpRegMaestro.Hcl_nroreg_hcms;
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
        //-------------------------------------------------
        // Generar llaves
        //-------------------------------------------------
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
                    lcrllave4 += " "+ fcrGenerarLlaveDetalles(lobReg);
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
}
//- MARMOTA-GENCODE: VERSION 2.0 - 25/05/2014 12:12:21 PM
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;
using Sistema.Validacion;
using GestorReportes.Modelo;
using GestorReportes.Vista;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclregordeservi
    /// </summary>
    public partial class VistaHojaConsumoServicios : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        #region Variables
        public bool llgModoAdicion      = false;
        public bool llgModoEdicion      = false;
        public bool llgObjetosCargados  = false;
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = false;
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public int lnuContNuevoRegistro = 0; // Para codigo temporal de nuevos registros
        public String gcrCtrF2TexBox;
        public String lcrFormModoPopup      = "DFL";
        public String gcrSeparadorDecimal   = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public String gcrCodigoAdmision     = String.Empty;
        public String gcrCodigoMaestro      = String.Empty;
        public String gcrCodigoRegistro     = String.Empty;
        public String gcrNombreAlmacen      = String.Empty; // almacen activo
        public String gcrDescarInventario   = "1"; // Activa o desactivar descargar medicamentos de inventario
        public int gnuTotalUnidExisten      = 0;
        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public ModeloHclregordeserms tmpRegMaestro  = null;
        public ModeloHclregordeserde tmpRegDetalle  = new ModeloHclregordeserde();
        public EFsiaareapreservi tmpRegAreaSer      = null;
        public List<ModeloHclregordeserde> tmpDatosDetalle = null;
        public EFctomaescontrato tmpRegContrato = null;
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public List<CrtForms.ListaComboBox> lstG1Hcl_tipser_hcor;
        DialogVistaErrores lobDlgLogs = null;
        Aplicacion oApp = Aplicacion.Instancia();
        #endregion
        #region Datos para gestion de inventarios
        List<ModeloInvKardexMaestro> tmpKardex = null;
        #endregion
        #region Clase Objeto para liquidar valores servicios
        /// <summary>
        ///  Parametros generales para liquidar servicios de facturación
        /// </summary>
        public FcmFacturarServicios gobLiq = new FcmFacturarServicios();
        #endregion
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// </summary>
        public VistaHojaConsumoServicios(String tcrModoAccion, String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            InitializeComponent();

            IniciarComboBox();
            llgObjetosCargados = true;
            gcrCodigoMaestro = String.Empty;
            gcrCodigoRegistro = tcrCodigoRegistro;
            gcrCodigoAdmision = tcrCodigoAdmision;

            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;
            fcvCargarDatosUsuarioProfesionalActivo();
            gcrDescarInventario = Funciones.fcrLeerConfigVarSistema("HCL-HCLVAL-HCONSUMO-INVENTARIO", "2"); 

            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Hcl_gesfec_hcor.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            if (!String.IsNullOrWhiteSpace(tcrModoAccion))
            {
                fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoRegistro, tcrCodigoAdmision);
            }
            fcvTimerGeneral();
        }
        #endregion
        //------------------------------------------------------------
        //  Timer Para propositos varios
        //------------------------------------------------------------
        #region fcvTimer: Control Tiempo para cosas varias
        public void fcvTimerGeneral()
        {
            gdspTimerSistema.Tick += new System.EventHandler(out fcvTimerProcesos);
            gdspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 300);
            gdspTimerSistema.Start();
        }
        #endregion
        #region fcvTimerProcesos: Timer para procesos varios y validacion
        /// <summary>
        /// <para>Timer para procesos varios y validacion</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            if (this.IsLoaded && llgModoEdicion == true)
            {
                if (llgModoEdicionKey == false && llgModoEdicionValid == false)
                {
                    llgModoEdicionValid = true;
                    flgValidacion();
                }
            }
            if (llgModoEdicion == false) { gdspTimerSistema.Stop(); }

        }
        #endregion
        //-------------------------------------------------
        // Gestion Modo Formulario Popup
        //-------------------------------------------------
        #region fcvCargarVistaFormPopup
        private void fcvCargarVistaFormPopup(String tcrModoAccion, String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            var llgExiste = flgCargarDatosExitentes(tcrCodigoRegistro);

            switch (tcrModoAccion)
            {
                case "ADD": // Modo Adicion
                    lcrFormModoPopup = "ADD";
                    if (llgExiste == true) { lcrFormModoPopup = "EDT"; }
                    break;

                case "EDT": // Modo Edicion
                    lcrFormModoPopup = "EDT";
                    if (llgExiste == false) { lcrFormModoPopup = "ADD"; }
                    break;

                default:
                    //- Opcion por Defecto
                    lcrFormModoPopup = "DFL";
                    break;
            }
            fcvActivarModoEdicion(lcrFormModoPopup);
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region Gestion Edicion
        //- clic en Boton Nuevo 
        #region Nuevo registro detalle
        private void fcvNuevoRegistroDetalle(object sender, RoutedEventArgs e)
        {
            fcvNuevoRegistroDetalles();
        }
        #endregion
        #region Nuevo Maestro
        private void fcvNuevoRegistro(object sender, RoutedEventArgs e)
        {
            fcvActivarModoEdicion("ADD");
            FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcor);
        }
        #endregion
        #region fcvNuevoRegistroDetalles: Activar modo edicion y generar datos par nuevo registro
        /// <summary>
        /// Activar modo edicion y generar datos par nuevo registro detalle Medicamento/Indicacion
        /// </summary>
        private void fcvNuevoRegistroDetalles()
        {
            tmpRegDetalle = new ModeloHclregordeserde();
            fcvCargarActivarObjetosCaptura(true);
            fcvCargarReiniciarVistaRegActivo("2");
            tmpRegDetalle.Hcl_nroreg_hcor = String.Empty;
            tmpRegDetalle.Sis_estado_imaen = "A";
            tmpRegDetalle.Hcl_tserax_hcor = "NA";
        }
        #endregion
        //-Clic en Boton Guardar
        #region fcvGuardarAgregarRegDetalle: Guardar registro modificado/agregado en pantalla
        private void fcvGuardarAgregarRegDetalle(object sender, RoutedEventArgs e)
        {
            var lobDetalle = new ControlOrdHojaConsumoDeEdt();
            fcvAuxRegistroActivoDesdeVariables();
            if (tmpRegDetalle.Sis_estado_imaen == "A" && String.IsNullOrWhiteSpace(tmpRegDetalle.Hcl_nroreg_hcor))
            {
                lnuContNuevoRegistro++;
                tmpRegDetalle.Hcl_nroreg_hcor = "R" + lnuContNuevoRegistro.ToString().Trim();

                tmpRegDetalle.RefObjeto = lobDetalle;
                fcvVistaObjetosDatosBasicos(ref lobDetalle, tmpRegDetalle);
                flgVistaObjetosValoresRegistro(ref lobDetalle, tmpRegDetalle);

                tmpDatosDetalle.Add(fobAuxCopiarRegistro(tmpRegDetalle));
                this.stkDetalles.Children.Add(lobDetalle);
            }
            else
            {
                lobDetalle = tmpRegDetalle.RefObjeto as ControlOrdHojaConsumoDeEdt;
                fcvAuxActualizarEnMaestroTemporal(tmpRegDetalle);
                flgVistaObjetosValoresRegistro(ref lobDetalle, tmpRegDetalle);
            }
            // actualizar vista del objeto y modificar el temporal tmpDatosDetalle
            fcvNuevoRegistroDetalles();
        }
        #endregion
        #region Guardar Maestro  Click en Boton Guardar de la vista
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea guardar los registros?", "Guardar",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                fcvGuardarRegistroMaestro("1");
            }
        }
        #endregion
        #endregion
        //--------------------------------------------------
        //- Eventos Guardar y confirmar
        //--------------------------------------------------
        #region fcvGuardarConfirmarRegistro: Guardar y confirmar proceso
        private void fcvGuardarConfirmarRegistro(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea guardar y confirmar los registros?", "Confirmación",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var llgRealizar = true;

                if (gcrDescarInventario == "1")
                {
                    var lobRegPeriodo = INVValidarCodigo.fobRegBuscarInvperiodomaest(tmpRegAreaSer.inv_codalm_inal, tmpRegMaestro.Hcl_gesfec_hcms);

                    if (lobRegPeriodo != null)
                    {
                        llgRealizar = true;
                    }
                    else
                    {
                        llgRealizar = false;
                        MessageBox.Show("No hay perido activo en inventario para la fecha: " + this.txtG1Hcl_gesfec_hcor.Text);
                    }
                }

                if (llgRealizar == true)
                {
                    fcvGuardarRegistroMaestro("2");
                }
            }
        }
        #endregion
        #region fcvGuardarRegistroMaestro: Guardar registro maestro
        /// <summary>
        /// <para>Guardar todo el proceso de digitacion y cerrar la vista </para>
        /// <para>tcrEstado: "1"= Guardar todo sin confirmar "2"= Guardar todo y confirmar el proceso</para>
        /// </summary>
        private void fcvGuardarRegistroMaestro(String tcrEstado)
        {
            var llgReturn = true;
            var lcrNuevoCodigo = String.Empty;
            tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;

            if (flgValidacion() == true)
            {
                if (flgGuardarRegistroMaestro(tcrEstado) == true)
                {
                    fcvGuardarRegistroDetalles(gcrCodigoMaestro);

                    if (tcrEstado == "2")
                    {
                        // Generar datos para facturacion
                        var lobClass = new HclGenFacturServicios();
                        // Cargar los parametros
                        lobClass.gcrTipoRegistro      = "HCON";
                        lobClass.gcrCodigoAdmision    = gcrCodigoAdmision;
                        lobClass.tmpRegAdm            = tmpRegAdm;
                        lobClass.tmpRegMaestro        = tmpRegMaestro;
                        lobClass.gcrCodigoProfesional = tmpRegMaestro.Sia_codpfa_prof;

                        // Generar datos en facturacion y notificacion
                        lobClass.fcvSYSGenerarNotificacion();
                        llgReturn       = lobClass.flgConfirmarFacturaServicios();
                        tmpLogErrores   = lobClass.tmpLogErrores;
                        // Confirmar descarga de inventarios
                        if (llgReturn == true)  // Cuando no hay error al confirmar factura descargar de inventarios
                        {
                            fcvGuardarDescargarInventario();
                        }
                    }
                    if (llgReturn == true)  // Cuando hay error al confirmar factura, no se cierra la ventana
                    {
                        fcvRetornoInterface(gcrCodigoMaestro);
                    }
                    else
                    {
                        MessageBox.Show("No fué posible enviar los servicios a facturación");
                    }
                }
            }
            else
            {
                MessageBox.Show("No es posible guardar los datos.");
            }
        }
        #endregion
        #region fcvGuardarRegistroDetalles: Guardar registros Detalles en base de datos
        /// <summary>
        /// Guardar registros Detalles en base de datos
        /// </summary>
        private void fcvGuardarRegistroDetalles(String tcrCodigoMaestro)
        {
            var lcrNuevoCodigo = String.Empty;

            foreach (var lobReg in tmpDatosDetalle)
            {
                // actualizar datos que en registro R1 posiblemente se cambiaron
                if (String.IsNullOrWhiteSpace(lobReg.Fcm_coddig_mant))
                {
                    lobReg.Sis_estado_imaen = "N"; // se marca como nulo para ser ignorado pór completo en el futuro
                    if (!String.IsNullOrWhiteSpace(lobReg.Hcl_nroreg_hcor))
                    {
                        ModeloHclregordeserde.fcvEliminar(lobReg.Hcl_nroreg_hcor);
                    }
                }
                else 
                {
                    lobReg.Hcl_nroreg_hcms = tcrCodigoMaestro;
                    lobReg.Hcl_gesfec_hcor = tmpRegMaestro.Hcl_gesfec_hcms;
                    lobReg.Hcl_geshor_hcor = tmpRegMaestro.Hcl_geshor_hcms;
                    lobReg.Sia_codpfa_prof = tmpRegMaestro.Sia_codpfa_prof;
                    lobReg.Sis_estpro_espr = tmpRegMaestro.Sis_estpro_espr;

                    // Apllicar politica de gestion registro
                    if (lobReg.Sis_estado_imaen == "E")
                    {
                        ModeloHclregordeserde.fcvEliminar(lobReg.Hcl_nroreg_hcor);
                        lobReg.Sis_estado_imaen = "N"; // se marca como nulo para ser ignorado pór completo en el futuro
                    }
                    else if (lobReg.Sis_estado_imaen != "A" && lobReg.Sis_estado_imaen != "N")
                    {
                        ModeloHclregordeserde.fcvActualizar(lobReg);
                        lobReg.Sis_estado_imaen = "I";
                    }
                    else if (lobReg.Sis_estado_imaen == "A")
                    {
                        lcrNuevoCodigo = ModeloHclregordeserde.flgAddRegistro(lobReg);
                        if (!String.IsNullOrWhiteSpace(lcrNuevoCodigo))
                        {
                            lobReg.Hcl_nroreg_hcor = lcrNuevoCodigo;
                            lobReg.Sis_estado_imaen = "I";
                        }
                    }
                }
            }
        }
        #endregion
        #region fcvGuardarDescargarInventario: Descargar los medicamentos del stock
        /// <summary>
        /// Descargar medicamentos hoja consumo desde stock que corresponda (farmacia - urgencias - hospitalizacion)
        /// </summary>
        private void fcvGuardarDescargarInventario()
        {
            tmpKardex = ModeloHclregordeserde.flsTempHojaConsumoMedicamentos(tmpRegMaestro.Hcl_nroreg_hcms,
                                                                                     tmpRegAreaSer.inv_codalm_inal, tmpRegMaestro.Hcl_gesfec_hcms);
            var lobRegPeriodo = INVValidarCodigo.fobRegBuscarInvperiodomaest(tmpRegAreaSer.inv_codalm_inal, tmpRegMaestro.Hcl_gesfec_hcms);

            if (tmpKardex != null && lobRegPeriodo != null)
            {
                foreach (var lobReg in tmpKardex)
                {
                    lobReg.Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                    lobReg.Inv_codalm_inal = tmpRegAreaSer.inv_codalm_inal;
                    lobReg.Inv_codper_inpe = lobRegPeriodo.inv_codper_inpe;
                    lobReg.Inv_llavkr_inka = tmpRegAreaSer.inv_codalm_inal + "P" + lobRegPeriodo.inv_codper_inpe;
                    lobReg.Inv_fecges_inka = tmpRegMaestro.Hcl_gesfec_hcms;
                }
                ModeloInvKardexMaestro.flgInvGestKardexMovSalidas("S25", tmpRegAreaSer.inv_codalm_inal, "", tmpKardex);
            }
        }
        #endregion
        //- Activar modo edicion en la Vista
        #region flgGuardarRegistroMaestro: Validar y generar el registro maestro R1
        /// <summary>
        /// Validar y generar el registro maestro R1
        /// <para>tcrEstado: "1"= Guardar todo sin confirmar "2"= Guardar todo y confirmar el proceso</para>
        /// </summary>
        public bool flgGuardarRegistroMaestro(String tcrEstado)
        {
            var llgReturn = false;
            var lcrIdActividadHClinico = String.Empty;

            // Generar el registro Vista en historial clinico
            if (tcrEstado == "2") // se confirmo  por primera vez
            {
                lcrIdActividadHClinico = fcvHclinicaGenerarActividad();
            }

            var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx("HCON", gcrCodigoAdmision, "1");
            if (lobReg.Count != 0)
            {
                tmpRegMaestro = lobReg.FirstOrDefault();
                gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;

                tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcor.Text);
                tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegMaestro.Sis_estpro_espr = tcrEstado;

                ModeloHclregordeserms.fcvActualizar(tmpRegMaestro);
            }
            else
            {
                // Adicionar el registro
                tmpRegMaestro = new ModeloHclregordeserms();
                #region Valores Variables
                //tmpRegMaestro.Hcl_nroreg_hcms  al guardar
                //tmpRegMaestro.Hcl_nroreg_hcev  cuando se confirme
                tmpRegMaestro.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                tmpRegMaestro.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegMaestro.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                tmpRegMaestro.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                tmpRegMaestro.Sia_nomusu_usua = tmpRegAdm.Sia_nomusu_usua;
                tmpRegMaestro.Hcl_tipreg_hctr = "HCON";
                tmpRegMaestro.Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
                tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcor.Text);
                tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegMaestro.Hcl_tiptur_hctu = this.txtG1Hcl_tiptur_hctu.Text;
                tmpRegMaestro.Sis_estpro_espr = tcrEstado;
                #endregion
                gcrCodigoMaestro = ModeloHclregordeserms.flgAddRegistro(tmpRegMaestro);
                tmpRegMaestro.Hcl_nroreg_hcms = gcrCodigoMaestro;
            }
            llgReturn = !String.IsNullOrWhiteSpace(gcrCodigoMaestro) ? true : false;
            return llgReturn;
        }
        #endregion
        #region fcvActivarModoEdicion: Activar modo adicion
        //- Activar modo edicion en la Vista
        public void fcvActivarModoEdicion(string tcrTipoEdicion)
        {
            switch (tcrTipoEdicion)
            {
                case "ADD":
                    llgModoAdicion = true;
                    llgModoEdicion = true;
                    fcvCargarIniciarVariables();
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = tmpRegMaestro.Sis_estpro_espr == "1" ? true : false;
                    break;
            }
            fcvCargarActivarObjetosCaptura(llgModoEdicion);

            FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcor);
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
        #region fcvVistaLogErrores: Mostrar la vista de errores
        private void fcvVistaLogErrores(object sender, RoutedEventArgs e)
        {
            fcvVistaLogErrores();
        }
        #endregion
        #region fcvVistaLogErrores: Mostrar la vista de errores
        /// <summary>
        /// Mostrar la vista de errores
        /// </summary>
        public void fcvVistaLogErrores()
        {
            if (lobDlgLogs != null)
            {
                lobDlgLogs.Close();
                lobDlgLogs = null;
            }
            lobDlgLogs = new DialogVistaErrores();
            lobDlgLogs.fcvCargarVista("Vista errores", tmpLogErrores);
            lobDlgLogs.Show();
            lobDlgLogs.fcvActivarVista();
        }
        private void fcvGotFocus(object sender, EventArgs e)
        {
            if (lobDlgLogs != null)
            {
                lobDlgLogs.fcvCerrarVista();
            }
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
        //-------------------------------------------------
        //  KeyDown llamada funciones compos con F2
        //-------------------------------------------------
        #region llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("HCL", "HCLREGORDESERVI", "", "Maestro ordenes servicios intrahospitalarios...");
            gcrCtrF2TexBox = "txtG1Hcl_nroreg_hcor";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        //-------------------------------------------------
        //  Metodo que recoge el valor Key desde browser F2
        //-------------------------------------------------
        #region Metodo que recoge el valor Key desde browser F2
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "txtG1Sia_codpfa_prof":
                    txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_coddig_mant":
                    txtG1Fcm_coddig_mant.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codcpr_cpro":
                    txtG1Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG1Sia_codare_aser":
                    txtG1Sia_codare_aser.Text = tcrCodigo;
                    break;

                case "txtG1Hcl_tiptur_hctu":
                    txtG1Hcl_tiptur_hctu.Text = tcrCodigo;
                    break;

            }
        }
        // HCLREGORDESERVI : Maestro ordenes servicios intrahospitalarios
        #region KeyDown para campos con F2 Tabla: HCLREGORDESERVI
        #region FCM_IDESEC_SIPS : Maestro de servicios habilitados para la IPS
        private void txtG1Fcm_idesec_sips_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                fcvBuscarServicio();
            }
        }
        private void fcvBuscarServicio(object sender, RoutedEventArgs e)
        {
            fcvBuscarServicio();
        }
        private void fcvBuscarServicio()
        {
            var lcrFiltro = "Fcmmanservicios.fcm_codman_mans='" + tmpRegAdm.Fcm_codman_mans.Trim() + "'";
            if (this.chkG1Hcl_envalm_hcor.IsChecked == true)
            {
                Browser01Ex frbro = new Browser01Ex("INV", "INVALMACEXISTEN-SERV-IPS", tmpRegAreaSer.inv_codalm_inal, gcrNombreAlmacen + "...");
                gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
            else
            {
                Browser01Ex frbro = new Browser01Ex("FCM", "FCMMANSERVICIOSIU", lcrFiltro, "Maestro de servicios ...");
                gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        //tmpRegContrato
        #region SIS_ESTPRO_ESPR : Estados de procesos (Abierto, Cerrado,Anulado)
        private void txtG1Sis_estpro_espr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                Browser01 frbro = new Browser01("SIS", "SISESTADOPROCES", "", "Estados de procesos (Abierto, Cerrado,Anulado)...");
                gcrCtrF2TexBox = "txtG1Sis_estpro_espr";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
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
                gcrCtrF2TexBox = "txtG1Sia_codpfa_prof";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        #region SIA_CODPFA_PROF : Browser desde boton - Profesionales que prestan servicios
        private void fcvBuscarProfesional(object sender, RoutedEventArgs e)
        {
            Browser01 frbro = new Browser01("SIA", "SIAMAEPROFSALUD", "", "Profesionales que prestan servicios...");
            gcrCtrF2TexBox = "txtG1Sia_codpfa_prof";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region FCM_CODCPR_CPRO : Centros de produccion asistenciales
        private void txtG1Fcm_codcpr_cpro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Fcm_codcpr_cpro_Browser();
            }
        }
        private void cmdG1Fcm_codcpr_cpro_Click(object sender, RoutedEventArgs e)
        {
            txtG1Fcm_codcpr_cpro_Browser();
        }
        private void txtG1Fcm_codcpr_cpro_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMCENPRODUCCIO", "", "Centros de produccion asistenciales...");
            gcrCtrF2TexBox = "txtG1Fcm_codcpr_cpro";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region SIA_CODARE_ASER : Areas prestacion de servicios
        private void txtG1Sia_codare_aser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Sia_codare_aser_Browser();
            }
        }
        private void cmdG1Sia_codare_aser_Click(object sender, RoutedEventArgs e)
        {
            txtG1Sia_codare_aser_Browser();
        }
        private void txtG1Sia_codare_aser_Browser()
        {
            Browser01 frbro = new Browser01("SIA", "SIAAREAPRESERVI", "", "Areas prestacion de servicios...");
            gcrCtrF2TexBox = "txtG1Sia_codare_aser";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region HCL_TIPTUR_HCTU : Tipo registro turnos diarios prestacion de servicios medicos
        private void txtG1Hcl_tiptur_hctu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                txtG1Hcl_tiptur_hctu_Browser();
            }
        }
        private void cmdG1Hcl_tiptur_hctu_Click(object sender, RoutedEventArgs e)
        {
            txtG1Hcl_tiptur_hctu_Browser();
        }
        private void txtG1Hcl_tiptur_hctu_Browser()
        {
            Browser01 frbro = new Browser01("HCL", "HCLTIPOREGTURNO", "", "Turnos diarios servicios medicos...");
            gcrCtrF2TexBox = "txtG1Hcl_tiptur_hctu";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        // Actualizar Objeto TextBox desde CombBox
        //-------------------------------------------------
        #region Actualizar Objeto TextBox desde CombBox
        private void SeleccionComboBoxOpcion(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    CrtForms.ListaComboBox lobList = (CrtForms.ListaComboBox)e.AddedItems[0];
                    ComboBox lobCombo = (ComboBox)sender;

                    switch (lobCombo.Name)
                    {
                        case "cboG1Hcl_tipser_hcor":
                            /*
                            txtG1Hcl_tipser_hcor.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice,
                                                                                    txtG1Hcl_tipser_hcor.Text, ",",
                                                                                    lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Hcl_tipser_hcor.Text, ",", lobList.ListaValoresSel);
                            */
                            break;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: SeleccionOpcion");
            }
        }
        #endregion
        //-------------------------------------------------
        // Actualizar ComboBox desde Campo Texto
        //-------------------------------------------------
        #region Actualizar ComboBox desde Campo Texto
        private void ActualizarComboBoxOpcion(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
                        case "txtG1Hcl_tipser_hcor":
                            /*
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Hcl_tipser_hcor.SelectedItem;
                            cboG1Hcl_tipser_hcor.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            */
                            break;
                    }
                    fcrValidacion(lobTexto.Name);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarComboBoxOpcion");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de DatePiker Fechas
        //-------------------------------------------------
        #region Metodos Para Gestion de DatePiker Fechas
        //-------------------------------------------------
        //  Actualizar Campo TextBox desde DatePiker
        //-------------------------------------------------
        #region  Actualizar Campo TextBox desde DatePiker
        private void fcvDatePickerSelected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DatePicker lobDpk = (sender as DatePicker);
                switch (lobDpk.Name)
                {
                    case "dpkG1Hcl_gesfec_hcor":
                        txtG1Hcl_gesfec_hcor.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcor);
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvDatePickerSelected");
            }
        }
        #endregion
        //-------------------------------------------------
        // Actualizar DatePiker desde Campo Texto
        //-------------------------------------------------
        #region Actualizar DatePiker desde Campo Texto
        private void fcvActualizarDatePicker(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    DateTime ldaFecha;
                    TextBox lobTexto = (TextBox)sender;
                    var lnuPosCursor = lobTexto.SelectionStart;
                    var lcrValor = CrtForms.fcrFormatoCapturaFecha("DMY", "/", lobTexto.Text);
                    if (lobTexto.Text.Trim() != lcrValor.Trim())
                    {
                        lobTexto.Text = lcrValor;
                        lobTexto.SelectionStart = CrtForms.fnuNewPosCursorFecha("DMY", lnuPosCursor);
                    }
                    if (DateTime.TryParse(lobTexto.Text, out ldaFecha) && lobTexto.Text.Trim().Length == 10)
                    {
                        switch (lobTexto.Name)
                        {
                            case "txtG1Hcl_gesfec_hcor":
                                dpkG1Hcl_gesfec_hcor.SelectedDate = Convert.ToDateTime(lobTexto.Text);
                                break;
                        }
                    }
                    llgModoEdicionKey = true;
                    fcrValidacion(lobTexto.Name);
                    llgModoEdicionKey = false;
                    llgModoEdicionValid = false;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvActualizarDatePicker");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //Formato para captura de la hora 
        //-------------------------------------------------
        #region Formato para captura de la hora
        private void fcvCapturaHora(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    var lnuPosCursor = lobTexto.SelectionStart;
                    var lcrValor = CrtForms.fcrFormatoCapturaHora("12", ":", lobTexto.Text);
                    if (lobTexto.Text.Trim() != lcrValor.Trim())
                    {
                        lobTexto.Text = lcrValor;
                        lobTexto.SelectionStart = CrtForms.fnuNewPosCursorHora("12", lnuPosCursor);
                    }
                    llgModoEdicionKey = true;
                    fcrValidacion(lobTexto.Name);
                    llgModoEdicionKey = false;
                    llgModoEdicionValid = false;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvCampturaHora.");
            }
        }
        #endregion
        //-------------------------------------------------
        // CARGAR DATOS EN VARIABLES O TEMPORAL 
        //-------------------------------------------------
        #region Cargar datos existentes
        private void fcvCargarDatosExitentes(String tcrCodigo)
        {
            // cargar datos
        }
        #endregion
        #region Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariables()
        {
            try
            {
                #region Valores Variables
                //tmpRegDetalle.Hcl_nroreg_hcor 
                tmpRegDetalle.Hcl_nroreg_hcms = tmpRegMaestro.Hcl_nroreg_hcms;
                //tmpRegDetalle.Hcl_secreg_hcor
                tmpRegDetalle.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                tmpRegDetalle.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegDetalle.Hcl_tipreg_hcor = "1";
                //tmpRegDetalle.Fcm_secreg_dfac
                //tmpRegDetalle.Fcm_idesec_sips se llena en validacion
                tmpRegDetalle.Fcm_coddig_mant = txtG1Fcm_coddig_mant.Text;
                tmpRegDetalle.Hcl_totuni_hcor = (int)Convert.ToUInt32(txtG1Hcl_totuni_hcor.Text);
                //tmpRegDetalle.Inv_secart_mart  se llena en validacion del campo Fcm_coddig_mant
                //tmpRegDetalle.Hcl_aplmed_hcor 
                //tmpRegDetalle.Hcl_termed_hcor 
                //tmpRegDetalle.Hcl_nrodia_hcor 
                tmpRegDetalle.Hcl_gesfec_hcor = Funciones.fdaConvertFecha("DMY", "/", txtG1Hcl_gesfec_hcor.Text);
                tmpRegDetalle.Hcl_geshor_hcor = Decimal.Parse(Funciones.fcrConvierteHora(txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegDetalle.Hcl_sisfec_hcor = DateTime.Now;
                tmpRegDetalle.Hcl_sishor_hcor = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                tmpRegDetalle.Hcl_tiptur_hctu = this.txtG1Hcl_tiptur_hctu.Text;
                tmpRegDetalle.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegDetalle.Fcm_codcpr_cpro = this.txtG1Fcm_codcpr_cpro.Text;
                tmpRegDetalle.Sia_codare_aser = this.txtG1Sia_codare_aser.Text;
                tmpRegDetalle.Hcl_notreg_hcor = txtG1Hcl_notreg_hcor.Text;
                tmpRegDetalle.Hcl_tipser_hcor = "1";
                tmpRegDetalle.Hcl_envfac_hcor = "1";
                tmpRegDetalle.Hcl_envalm_hcor = this.chkG1Hcl_envalm_hcor.IsChecked == true ? "1" : "2";
                tmpRegDetalle.Hcl_confac_hcor = tmpRegDetalle.Hcl_envfac_hcor == "1" ? "1" : "2";
                tmpRegDetalle.Hcl_conalm_hcor = "2";
                tmpRegDetalle.Sis_estpro_espr = "1";
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
            }
        }
        #endregion
        #region fcvCargarIniciarVariables: Iniciar las variables de la vista
        private void fcvCargarIniciarVariables()
        {
            tmpRegMaestro = new ModeloHclregordeserms();
            tmpRegDetalle = new ModeloHclregordeserde();
            tmpDatosDetalle = new List<ModeloHclregordeserde>();

            if (!String.IsNullOrWhiteSpace(gcrCodigoAdmision))
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision);
                if (lobRegAdm.Count == 0) { return; }

                tmpRegAdm = lobRegAdm.FirstOrDefault();
                tmpRegContrato = CTOValidarCodigo.fobRegBuscarCtomaescontrato(tmpRegAdm.Cto_seccon_cont);
            }
            if (tmpRegAdm != null)
            {
                fcvCargarReiniciarVistaRegActivo("1");
                fcvNuevoRegistroDetalles();
            }
        }
        #endregion
        #region flgCargarDatosExitentes: Cargar datos existentes
        /// <summary>
        /// Cargar datos existentes dado el Id unico del Registro R1
        /// </summary>
        private bool flgCargarDatosExitentes(String tcrCodigo)
        {
            var llgExiste = false;
            var lcrCodigo = tcrCodigo;
            fcvCargarIniciarVariables();
            if (!String.IsNullOrWhiteSpace(tcrCodigo))
            {
                var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx("NA", tcrCodigo, "");
                if (lobReg != null && lobReg.Count != 0)
                {
                    tmpRegMaestro = lobReg.FirstOrDefault();
                    gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;
                    llgExiste = true;
                }
            }
            else
            {
                var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx("HCON", gcrCodigoAdmision, "1");
                if (lobReg.Count != 0)
                {
                    tmpRegMaestro = lobReg.FirstOrDefault();
                    gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;
                    llgExiste = true;
                }
            }
            // cargar datos
            if (!String.IsNullOrWhiteSpace(gcrCodigoMaestro))
            {
                tmpDatosDetalle = ModeloHclregordeserde.flsListaHclregordeserde("R1", gcrCodigoMaestro);
                fcvCargarVistaRegistroMaestro();
                fcvCargarVistaObjetosDetallServicios();
            }

            return llgExiste;
        }
        #endregion
        #region fcvCargarVistaRegistroMaestro: Cargar vista de variables registro maestro
        /// <summary>
        /// Cargar vista de variables registro maestro
        /// </summary>
        public virtual void fcvCargarVistaRegistroMaestro()
        {
            try
            {
                #region Valores Variables
                if (tmpDatosDetalle != null && tmpDatosDetalle.Count != 0)
                {
                    this.txtG1Fcm_codcpr_cpro.Text = tmpDatosDetalle.FirstOrDefault().Fcm_codcpr_cpro;
                }
                this.txtG1Hcl_gesfec_hcor.Text = tmpRegMaestro.Hcl_gesfec_hcms.ToShortDateString();
                this.txtG1Hcl_geshor_hcor.Text = Funciones.fcrConvierteHora(tmpRegMaestro.Hcl_geshor_hcms.ToString(), "24", gcrSeparadorDecimal, ":");
                this.txtG1Sia_codpfa_prof.Text = tmpRegMaestro.Sia_codpfa_prof;
                this.txtG1Hcl_tiptur_hctu.Text = tmpRegMaestro.Hcl_tiptur_hctu;
                this.txtG1Sia_codare_aser.Text = tmpRegMaestro.Sia_codare_aser;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVistaRegistroMaestro");
            }
        }
        #endregion
        #region fcvCargarVistaVariablesDesdeRegActivo: Cargar vista de variables desde registro activo
        /// <summary>
        /// Cargar vista de variables desde registro activo
        /// </summary>
        public virtual void fcvCargarVistaVariablesDesdeRegActivo()
        {
            try
            {
                #region Valores Variables
                this.txtG1Hcl_gesfec_hcor.Text      = tmpRegMaestro.Hcl_gesfec_hcms.ToShortDateString();
                this.txtG1Hcl_geshor_hcor.Text      = Funciones.fcrConvierteHora(tmpRegMaestro.Hcl_geshor_hcms.ToString(), "24", gcrSeparadorDecimal, ":");
                this.txtG1Fcm_codcpr_cpro.Text      = tmpRegDetalle.Fcm_codcpr_cpro;
                this.txtG1Fcm_coddig_mant.Text      = tmpRegDetalle.Fcm_coddig_mant;
                this.txtG1Hcl_totuni_hcor.Text      = tmpRegDetalle.Hcl_totuni_hcor.ToString();
                this.txtG1Hcl_notreg_hcor.Text      = tmpRegDetalle.Hcl_notreg_hcor;
                this.txtG1Sia_codare_aser.Text      = tmpRegDetalle.Sia_codare_aser;
                this.chkG1Hcl_envalm_hcor.IsChecked = tmpRegDetalle.Hcl_envalm_hcor == "1" ? true : false;
                #endregion
                this.lblAgregar.Text = "Actualizar";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVistaVariablesDesdeRegActivo");
            }
        }
        #endregion
        #region fcvCargarVistaObjetosDetallServicios: Carga registros en vista detalles
        /// <summary>
        /// <para>Carga registros en vista detalles</para>
        /// </summary>
        public void fcvCargarVistaObjetosDetallServicios()
        {
            if (tmpDatosDetalle != null)
            {
                this.stkDetalles.Children.Clear();

                foreach (var lobReg in tmpDatosDetalle)
                {
                    // Configuracion del registro 
                    var lobDetalle = new ControlOrdHojaConsumoDeEdt();
                    lobReg.RefObjeto = lobDetalle;

                    fcvVistaObjetosDatosBasicos(ref lobDetalle, lobReg);
                    flgVistaObjetosValoresRegistro(ref lobDetalle, lobReg);

                    this.stkDetalles.Children.Add(lobDetalle);
                }
            }
        }
        #endregion
        #region fcvCargarActivarObjetosCaptura: Activar o desactivar los objetos de captura de datos
        /// <summary>
        /// <para>Activar o desactivar los objetos de captura de datos</para>
        /// </summary>
        private void fcvCargarActivarObjetosCaptura(bool tlgEstado)
        {
            #region Vista campos

            this.txtG1Hcl_gesfec_hcor.IsEnabled = tlgEstado;
            this.txtG1Hcl_geshor_hcor.IsEnabled = tlgEstado;
            this.txtG1Hcl_tiptur_hctu.IsEnabled = tlgEstado;
            this.txtG1Sia_codpfa_prof.IsEnabled = tlgEstado;
            this.txtG1Fcm_codcpr_cpro.IsEnabled = tlgEstado;

            this.txtG1Fcm_coddig_mant.IsEnabled = tlgEstado;
            this.txtG1Hcl_totuni_hcor.IsEnabled = tlgEstado;
            this.txtG1Hcl_notreg_hcor.IsEnabled = tlgEstado;
            this.txtG1Sia_codare_aser.IsEnabled = tlgEstado;
            this.chkG1Hcl_envalm_hcor.IsEnabled = tlgEstado;

            // segun parametro de configuracion del sistema
            if (gcrDescarInventario != "1")
            {
                this.chkG1Hcl_envalm_hcor.IsChecked = false;
                this.chkG1Hcl_envalm_hcor.IsEnabled = false;
            }

            // Botones
            this.cmdBrowTurno.IsEnabled         = tlgEstado;
            this.cmdBrowProfesional.IsEnabled   = tlgEstado;
            this.cmdG1Fcm_codcpr_cpro.IsEnabled = tlgEstado;
            this.cmdG1Sia_codare_aser.IsEnabled = tlgEstado;
            this.dpkG1Hcl_gesfec_hcor.IsEnabled = tlgEstado;
            this.cmdBrowServicios.IsEnabled     = tlgEstado;

            this.cmdAgregar.IsEnabled    = tlgEstado;
            this.cmdNuevo.IsEnabled      = tlgEstado;
            this.cmdGuardar.IsEnabled    = tlgEstado;
            this.cmdConfirmar.IsEnabled  = tlgEstado;
            this.cmdLogErrores.IsEnabled = tlgEstado;

            if (tmpRegMaestro != null)
            {
                this.cmdNuevo.IsEnabled = tmpRegMaestro.Sis_estpro_espr == "1" ? true : false;
            }
            #endregion
        }
        #endregion
        #region fcvCargarReiniciarVistaRegActivo: Limpiar vista de variables para nueva captura de datos
        /// <summary>
        /// <para>Limpiar vista de variables para nueva captura de datos</para>
        /// <para>tcrGrupoVista: 1= Objetos Zona 1 o registro maestro "2"= Objetos de la zona detalles</para>
        /// </summary>
        public virtual void fcvCargarReiniciarVistaRegActivo(String tcrGrupoVista)
        {
            try
            {
                #region Valores Variables
                if (tcrGrupoVista == "1")
                {
                    this.txtG1Hcl_gesfec_hcor.Text = DateTime.Now.ToShortDateString();
                    this.txtG1Hcl_geshor_hcor.Text = Funciones.fcrHoraActual("12", ":");
                    this.txtG1Fcm_codcpr_cpro.Text = Funciones.fcrLeerConfigVarSistema("HCL-SUMHCL-CENT-PRODUC-SUMI", "6023");  // "6023" = Medicamentos y Farmacia (por defecto)

                    tmpRegMaestro.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    tmpRegMaestro.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    tmpRegMaestro.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    tmpRegMaestro.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    tmpRegMaestro.Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
                    tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcor.Text);
                    tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
                    tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                    tmpRegMaestro.Sis_estpro_espr = "1";

                }
                else
                {
                    this.txtG1Fcm_coddig_mant.Text      = String.Empty;
                    this.txtG1Fcm_desser_sips.Text      = String.Empty;
                    this.txtG1Hcl_totuni_hcor.Text      = "1";
                    this.chkG1Hcl_envalm_hcor.IsChecked = gcrDescarInventario == "1" ? true : false;

                    tmpRegDetalle = new ModeloHclregordeserde();

                    this.lblAgregar.Text = "Agregar";
                }
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarReiniciarVistaRegActivo");
            }
        }
        #endregion
        // Funciones auxiliares copiar y actualizar temporal de registros detalle
        #region fcvAuxRegistroActivoDesdeVariables: Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables de la vista
        /// </summary>
        public void fcvAuxRegistroActivoDesdeVariables()
        {
            try
            {
                #region Valores Variables
                tmpRegDetalle.Hcl_tipser_hcor = "1";
                tmpRegDetalle.Hcl_gesfec_hcor = Funciones.fdaConvertFecha("DMY", "/", txtG1Hcl_gesfec_hcor.Text);
                tmpRegDetalle.Hcl_geshor_hcor = Decimal.Parse(Funciones.fcrConvierteHora(txtG1Hcl_geshor_hcor.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegDetalle.Hcl_sisfec_hcor = DateTime.Now;
                tmpRegDetalle.Hcl_sishor_hcor = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                tmpRegDetalle.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegDetalle.Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
                tmpRegDetalle.Fcm_codcpr_cpro = this.txtG1Fcm_codcpr_cpro.Text;
                tmpRegDetalle.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                tmpRegDetalle.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                tmpRegDetalle.Hcl_tipreg_hcor = "1";
                tmpRegDetalle.Hcl_conalm_hcor = "1"; // No por ahora (debe ser segun parametro contrato)
                tmpRegDetalle.Hcl_envfac_hcor = "1"; // "1" sujeto a lo que diga el contrato
                tmpRegDetalle.Hcl_confac_hcor = tmpRegDetalle.Hcl_envfac_hcor == "1" ? "1" : "2";
                tmpRegDetalle.Sis_estpro_espr = "1";
                tmpRegDetalle.Fcm_codser_sips = this.txtG1Fcm_coddig_mant.Text;
                tmpRegDetalle.Fcm_desser_sips = this.txtG1Fcm_desser_sips.Text;
                tmpRegDetalle.Fcm_coddig_mant = this.txtG1Fcm_coddig_mant.Text;
                tmpRegDetalle.Hcl_notreg_hcor = this.txtG1Hcl_notreg_hcor.Text;
                tmpRegDetalle.Hcl_envalm_hcor = this.chkG1Hcl_envalm_hcor.IsChecked == true ? "1" : "2";
                tmpRegDetalle.Hcl_totuni_hcor = (int)Convert.ToUInt32(this.txtG1Hcl_totuni_hcor.Text);
                tmpRegDetalle.Hcl_nrodia_hcor = 0;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
            }
        }
        #endregion
        #region fobAuxCopiarRegistro: Copiar Registro desde Registro temporal dado en parametro
        /// <summary>
        /// Copiar Registro desde Registro temporal dado en parametro
        /// </summary>
        public ModeloHclregordeserde fobAuxCopiarRegistro(ModeloHclregordeserde tobRegistro)
        {
            var lobReAux = new ModeloHclregordeserde();
            try
            {
                #region datos
                lobReAux.RefObjeto = tobRegistro.RefObjeto;
                lobReAux.Hcl_nroreg_hcor = tobRegistro.Hcl_nroreg_hcor;
                lobReAux.Hcl_nroreg_hcms = tobRegistro.Hcl_nroreg_hcms;
                lobReAux.Hcl_secreg_hcor = tobRegistro.Hcl_secreg_hcor;
                lobReAux.Adm_secadm_rgad = tobRegistro.Adm_secadm_rgad;
                lobReAux.Sia_idesec_usua = tobRegistro.Sia_idesec_usua;
                lobReAux.Hcl_tipreg_hcor = tobRegistro.Hcl_tipreg_hcor;
                lobReAux.Fcm_secreg_dfac = tobRegistro.Fcm_secreg_dfac;
                lobReAux.Fcm_idesec_sips = tobRegistro.Fcm_idesec_sips;
                lobReAux.Fcm_coddig_mant = tobRegistro.Fcm_coddig_mant;
                lobReAux.Hcl_totuni_hcor = tobRegistro.Hcl_totuni_hcor;
                lobReAux.Inv_secart_mart = tobRegistro.Inv_secart_mart;
                lobReAux.Hcl_aplmed_hcor = tobRegistro.Hcl_aplmed_hcor;
                lobReAux.Hcl_termed_hcor = tobRegistro.Hcl_termed_hcor;
                lobReAux.Hcl_dester_hcor = tobRegistro.Hcl_dester_hcor;
                lobReAux.Hcl_nrodia_hcor = tobRegistro.Hcl_nrodia_hcor;
                lobReAux.Hcl_gesfec_hcor = tobRegistro.Hcl_gesfec_hcor;
                lobReAux.Hcl_geshor_hcor = tobRegistro.Hcl_geshor_hcor;
                lobReAux.Hcl_tiptur_hctu = tobRegistro.Hcl_tiptur_hctu;
                lobReAux.Sia_codpfa_prof = tobRegistro.Sia_codpfa_prof;
                lobReAux.Fcm_codcpr_cpro = tobRegistro.Fcm_codcpr_cpro;
                lobReAux.Sia_codare_aser = tobRegistro.Sia_codare_aser;
                lobReAux.Hcl_sisfec_hcor = tobRegistro.Hcl_sisfec_hcor;
                lobReAux.Hcl_sishor_hcor = tobRegistro.Hcl_sishor_hcor;
                lobReAux.Hcl_notreg_hcor = tobRegistro.Hcl_notreg_hcor;
                lobReAux.Hcl_tipser_hcor = tobRegistro.Hcl_tipser_hcor;
                lobReAux.Hcl_envfac_hcor = tobRegistro.Hcl_envfac_hcor;
                lobReAux.Hcl_envalm_hcor = tobRegistro.Hcl_envalm_hcor;
                lobReAux.Hcl_confac_hcor = tobRegistro.Hcl_confac_hcor;
                lobReAux.Hcl_conalm_hcor = tobRegistro.Hcl_conalm_hcor;
                lobReAux.Sis_estpro_espr = tobRegistro.Sis_estpro_espr;
                lobReAux.Sia_nompro_prof = tobRegistro.Sia_nompro_prof;
                lobReAux.Fcm_desser_sips = tobRegistro.Fcm_desser_sips;
                lobReAux.Fcm_codser_sips = tobRegistro.Fcm_codser_sips;
                lobReAux.Fcm_descpr_cpro = tobRegistro.Fcm_descpr_cpro;
                lobReAux.Sia_desare_aser = tobRegistro.Sia_desare_aser;
                lobReAux.Sis_estado_imaen = tobRegistro.Sis_estado_imaen;
                #endregion

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAuxRegistroActivoDesdeTemporal");
            }
            return lobReAux;
        }
        #endregion
        #region fobAuxActualizarEnMaestroTemporal: Actualizar el registro modificado en pantalla
        /// <summary>
        /// Actualizar en temporal maestro detalles el registro modificado en pantalla
        /// </summary>
        public void fcvAuxActualizarEnMaestroTemporal(ModeloHclregordeserde tobRegistro)
        {
            try
            {
                var lobReAux = tmpDatosDetalle.FirstOrDefault(x => x.Hcl_nroreg_hcor == tobRegistro.Hcl_nroreg_hcor);
                if (lobReAux != null)
                {
                    #region datos
                    //lobReAux.RefObjeto = tobRegistro.RefObjeto;
                    lobReAux.Hcl_nroreg_hcor = tobRegistro.Hcl_nroreg_hcor;
                    lobReAux.Hcl_nroreg_hcms = tobRegistro.Hcl_nroreg_hcms;
                    lobReAux.Hcl_secreg_hcor = tobRegistro.Hcl_secreg_hcor;
                    lobReAux.Adm_secadm_rgad = tobRegistro.Adm_secadm_rgad;
                    lobReAux.Sia_idesec_usua = tobRegistro.Sia_idesec_usua;
                    lobReAux.Hcl_tipreg_hcor = tobRegistro.Hcl_tipreg_hcor;
                    lobReAux.Fcm_secreg_dfac = tobRegistro.Fcm_secreg_dfac;
                    lobReAux.Fcm_idesec_sips = tobRegistro.Fcm_idesec_sips;
                    lobReAux.Fcm_coddig_mant = tobRegistro.Fcm_coddig_mant;
                    lobReAux.Hcl_totuni_hcor = tobRegistro.Hcl_totuni_hcor;
                    lobReAux.Inv_secart_mart = tobRegistro.Inv_secart_mart;
                    lobReAux.Hcl_aplmed_hcor = tobRegistro.Hcl_aplmed_hcor;
                    lobReAux.Hcl_termed_hcor = tobRegistro.Hcl_termed_hcor;
                    lobReAux.Hcl_dester_hcor = tobRegistro.Hcl_dester_hcor;
                    lobReAux.Hcl_nrodia_hcor = tobRegistro.Hcl_nrodia_hcor;
                    lobReAux.Hcl_gesfec_hcor = tobRegistro.Hcl_gesfec_hcor;
                    lobReAux.Hcl_geshor_hcor = tobRegistro.Hcl_geshor_hcor;
                    lobReAux.Hcl_tiptur_hctu = tobRegistro.Hcl_tiptur_hctu;
                    lobReAux.Sia_codpfa_prof = tobRegistro.Sia_codpfa_prof;
                    lobReAux.Fcm_codcpr_cpro = tobRegistro.Fcm_codcpr_cpro;
                    lobReAux.Sia_codare_aser = tobRegistro.Sia_codare_aser;
                    lobReAux.Hcl_sisfec_hcor = tobRegistro.Hcl_sisfec_hcor;
                    lobReAux.Hcl_sishor_hcor = tobRegistro.Hcl_sishor_hcor;
                    lobReAux.Hcl_notreg_hcor = tobRegistro.Hcl_notreg_hcor;
                    lobReAux.Hcl_tipser_hcor = tobRegistro.Hcl_tipser_hcor;
                    lobReAux.Hcl_envfac_hcor = tobRegistro.Hcl_envfac_hcor;
                    lobReAux.Hcl_envalm_hcor = tobRegistro.Hcl_envalm_hcor;
                    lobReAux.Hcl_confac_hcor = tobRegistro.Hcl_confac_hcor;
                    lobReAux.Hcl_conalm_hcor = tobRegistro.Hcl_conalm_hcor;
                    lobReAux.Sis_estpro_espr = tobRegistro.Sis_estpro_espr;
                    lobReAux.Sia_nompro_prof = tobRegistro.Sia_nompro_prof;
                    lobReAux.Fcm_desser_sips = tobRegistro.Fcm_desser_sips;
                    lobReAux.Fcm_codser_sips = tobRegistro.Fcm_codser_sips;
                    lobReAux.Fcm_descpr_cpro = tobRegistro.Fcm_descpr_cpro;
                    lobReAux.Sia_desare_aser = tobRegistro.Sia_desare_aser;
                    lobReAux.Sis_estado_imaen = tobRegistro.Sis_estado_imaen;
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fobAuxActualizarEnMaestroTemporal");
            }
        }
        #endregion
        // Actaulizar objeto en grilla
        #region fcvVistaObjetosDatosBasicos: Enlazar Procedimientos al objeto y modo vista
        /// <summary>
        /// <para>Enlazar Procedimientos al objeto y modo vista del registro en la grilla</para>
        /// </summary>
        public void fcvVistaObjetosDatosBasicos(ref ControlOrdHojaConsumoDeEdt tobDetalle, ModeloHclregordeserde tobRegistro)
        {
            if (tobDetalle != null && tobRegistro != null)
            {
                tobDetalle.cmdEliminar.Click += new RoutedEventHandler(fcvEliminarRegDetalle);
                tobDetalle.cmdModificar.Click += new RoutedEventHandler(fcvModificarRegDetalle);

                // Datos requeridos
                tobDetalle.IdRegistro   = tobRegistro.Hcl_nroreg_hcor;
                tobDetalle.IdR1Registro = tobRegistro.Hcl_nroreg_hcms;

                tobDetalle.cmdEliminar.Visibility   = tobRegistro.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                tobDetalle.cmdModificar.Visibility  = tobRegistro.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                tobDetalle.imgEstado.Visibility     = tobRegistro.Sis_estpro_espr == "1" ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        #endregion
        #region flgVistaObjetosValoresRegistro: Mostrar datos del registro en objeto detalles
        /// <summary>
        /// <para>Mostrar datos del registro en objeto detalles</para>
        /// </summary>
        public bool flgVistaObjetosValoresRegistro(ref ControlOrdHojaConsumoDeEdt tobDetalle, ModeloHclregordeserde tobRegistro)
        {
            var llgReturn = false;
            if (tobDetalle != null && tobRegistro != null)
            {
                llgReturn = true;


                tobDetalle.txtFecha.Text    = tobRegistro.Hcl_gesfec_hcor.ToShortDateString();
                tobDetalle.txtHora.Text     = Funciones.fcrConvierteHora(tobRegistro.Hcl_geshor_hcor.ToString(), "24", gcrSeparadorDecimal, ":");
                tobDetalle.txtCantidad.Text = tobRegistro.Hcl_totuni_hcor.ToString();
                tobDetalle.txtServicio.Text = tobRegistro.Fcm_codser_sips;
                tobDetalle.txtDetalle.Text  = tobRegistro.Fcm_desser_sips;
                //tobDetalle.txtObservacion.Text  = tobRegistro.Hcl_notreg_hcor;
            }
            return llgReturn;
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
            if (!llgObjetosCargados) { return; }

            llgModoEdicionKey = true;
            var lobTextBox = sender as TextBox;
            fcrValidacion(lobTextBox.Name);
            llgModoEdicionKey = false;
            llgModoEdicionValid = false;
        }
        #endregion
        #region flgValidacion: Valida todos los datos antes de guardar
        /// <summary>
        /// Valida todos los datos antes de guardar
        /// </summary>
        public bool flgValidacion()
        {
            var lnuCont1 = 0;
            var lnuCont2 = 0;
            var llgMaestro = tmpRegMaestro.Sis_estpro_espr == "1" ? true : false;

            // Datos maestro 
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_gesfec_hcor"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_geshor_hcor"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_tiptur_hctu"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codpfa_prof"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codare_aser"))) { lnuCont1++; }

            // Detalles del servicio
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Fcm_coddig_mant"))) { lnuCont2++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_totuni_hcor"))) { lnuCont2++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_notreg_hcor"))) { lnuCont2++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Fcm_codcpr_cpro"))) { lnuCont2++; }

            // Activar botones
            this.cmdAgregar.IsEnabled   = lnuCont1 + lnuCont2 > 0 ? false : true;
            this.cmdGuardar.IsEnabled   = lnuCont1 > 0 ? false : tmpDatosDetalle.Count != 0 && llgMaestro == true ? true : false;
            this.cmdConfirmar.IsEnabled = lnuCont1 > 0 ? false : tmpDatosDetalle.Count != 0 && llgMaestro == true ? true : false;

            return lnuCont1 == 0 ? true : false;
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
            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgValidaServIPS = true;

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "txtG1Fcm_coddig_mant":
                        #region Código servicio
                        lcrNombreCampo = "Código servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        fcvCargarDatosParaLiquidarServ();
                        this.txtG1Fcm_coddig_mant.Text = this.txtG1Fcm_coddig_mant.Text.ToUpper().Trim();
                        gobLiq.G2Fcm_coddig_mant = this.txtG1Fcm_coddig_mant.Text;

                        if (String.IsNullOrWhiteSpace(this.txtG1Fcm_coddig_mant.Text))
                        {
                            lcrValorReturn = "Código servicio: Es requerido";
                            this.txtG1Fcm_desser_sips.Text = String.Empty;
                        }
                        else
                        {
                            llgValidaServIPS = false;
                            lcrValorReturn = fcrValidaCodigoDigitacionAlmacen();

                            if (lcrValorReturn == "OK")
                            {
                                lcrValorReturn = String.Empty;
                                llgValidaServIPS = true;
                            }
                            if (llgValidaServIPS == true)
                            {
                                lcrValorReturn = fcrValidaCodigoDigitacionIPS(lcrNumeroRegistro, lcrNombreCampo);
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Fcm_coddig_mant, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_totuni_hcor":
                        #region Total unidades
                        lcrNombreCampo = "Total unidades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_totuni_hcor.Text))
                        {
                            lcrValorReturn = "Total unidades: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(txtG1Hcl_totuni_hcor.Text, "0123456789"))
                            {
                                lcrValorReturn = "Total unidades: Contiene caracteres que no son numeros";
                            }
                            else
                            {
                                var lnuHcl_totuni_hcor = Convert.ToUInt32(this.txtG1Hcl_totuni_hcor.Text);
                                if (lnuHcl_totuni_hcor < 1 || lnuHcl_totuni_hcor > 9999999)
                                {
                                    lcrValorReturn = "Total unidades: Valor fuera del rango";
                                }
                                else
                                {
                                    if (tmpRegDetalle != null)
                                    {
                                        if (lnuHcl_totuni_hcor > gnuTotalUnidExisten && this.chkG1Hcl_envalm_hcor.IsChecked == true)
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": No hay existencias suficientes (existencias: " + gnuTotalUnidExisten.ToString() +
                                                                              ") para realizar el suministro (solicitado: " + this.txtG1Hcl_totuni_hcor.Text + ")";
                                        }
                                    }

                                }
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_totuni_hcor, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_gesfec_hcor":
                        #region Fecha servicio
                        lcrNombreCampo = "Fecha servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";

                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", txtG1Hcl_gesfec_hcor.Text, "Fecha servicio");
                        fcvSetColorValidacion(txtG1Hcl_gesfec_hcor, lcrValorReturn);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            txtG1Hcl_gesfec_hcor.BorderBrush = Brushes.White;
                        }
                        break;
                        #endregion

                    case "txtG1Hcl_geshor_hcor":
                        #region Hora servicio
                        lcrNombreCampo = "Hora servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";

                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, txtG1Hcl_geshor_hcor.Text, "12", ":", "Hora servicio");
                        fcvSetColorValidacion(txtG1Hcl_geshor_hcor, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_notreg_hcor":
                        #region Nota del registro
                        /*
                        if (String.IsNullOrWhiteSpace(txtG1Hcl_notreg_hcor.Text))
                        {
                            lcrValorReturn = "Observación: Es requerida";
                        }
                        fcvSetColorValidacion(txtG1Hcl_notreg_hcor, lcrValorReturn);
                        */
                        break;
                        #endregion

                    case "txtG1Sia_codpfa_prof":
                        #region Profesional atiende
                        lcrNombreCampo = "Profesional atiende";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";

                        if (string.IsNullOrWhiteSpace(this.txtG1Sia_codpfa_prof.Text))
                        {
                            lcrValorReturn = "Profesional atiende: Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(this.txtG1Sia_codpfa_prof.Text);
                            if (tmp != null && tmp.sia_nompro_prof != null)
                            {
                                this.txtG1Sia_nompro_prof.Text = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = "Profesional atiende: No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codpfa_prof, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Fcm_codcpr_cpro":
                        #region Código centro producción
                        lcrNombreCampo = "Código centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";

                        if (string.IsNullOrWhiteSpace(this.txtG1Fcm_codcpr_cpro.Text))
                        {
                            lcrValorReturn = "Código centro producción: Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(this.txtG1Fcm_codcpr_cpro.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codcpr_cpro))
                            {
                                this.txtG1Sia_codare_aser.Text = String.IsNullOrWhiteSpace(this.txtG1Sia_codare_aser.Text) ? tmp.sia_codare_aser : this.txtG1Sia_codare_aser.Text;
                                this.txtG1Fcm_descpr_cpro.Text = tmp.fcm_descpr_cpro;
                            }
                            else
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        fcvSetColorValidacion(txtG1Fcm_codcpr_cpro, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Sia_codare_aser":
                        #region Código área servicio
                        lcrNombreCampo = "Código área servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";

                        if (string.IsNullOrWhiteSpace(this.txtG1Sia_codare_aser.Text))
                        {
                            lcrValorReturn = "Código área servicio: Es requerido";
                        }
                        else
                        {
                            tmpRegAreaSer = SIAValidarCodigo.fobRegBuscarSiaareapreservi(this.txtG1Sia_codare_aser.Text);
                            if (tmpRegAreaSer != null && !String.IsNullOrWhiteSpace(tmpRegAreaSer.sia_codare_aser))
                            {
                                this.txtG1Sia_desare_aser.Text = tmpRegAreaSer.sia_desare_aser;

                                var lobReg = INVValidarCodigo.fobRegBuscarInvalmacenmaest(tmpRegAreaSer.inv_codalm_inal); 
                                if (lobReg != null)
                                {
                                    gcrNombreAlmacen = lobReg.inv_desalm_inal;
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Código área servicio: No existe";
                            }
                        }
                        fcvSetColorValidacion(txtG1Sia_codare_aser, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_tiptur_hctu":
                        #region Codigo turno
                        lcrNombreCampo = "Codigo turno";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (string.IsNullOrWhiteSpace(this.txtG1Hcl_tiptur_hctu.Text))
                        {
                            lcrValorReturn = "Codigo turno: Es requerido";
                        }
                        else
                        {
                            var tmp = HCLValidarCodigo.fobRegBuscarHcltiporegturno(this.txtG1Hcl_tiptur_hctu.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hcl_tiptur_hctu))
                            {
                                this.txtG1Hcl_destur_hctu.Text = tmp.hcl_destur_hctu;
                            }
                            else
                            {
                                lcrValorReturn = "Codigo turno: No existe";
                            }
                        }
                        fcvSetColorValidacion(txtG1Hcl_tiptur_hctu, lcrValorReturn);
                        break;
                        #endregion

                }
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);

                this.cmdLogErrores.IsEnabled = tmpLogErrores.Count > 0 ? true : false;

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #region fcvSetColorValidacion: Cambiar color del objeto segun validacion
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
        #endregion
        #region fcvCargarDatosParaLiquidarServ: Cargar datos en clase para validar
        /// <summary>
        /// <para>Cargar datos en clase para validar digitacion y liquidacion de servicios</para>  
        /// </summary>
        public void fcvCargarDatosParaLiquidarServ()
        {
            gobLiq.tmpRegAdm = tmpRegAdm;
            // Datos basicos del registro facturado
            gobLiq.G2Adm_codtat_tatn = tmpRegAdm.Adm_codtat_tatn;
            gobLiq.G2Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
            gobLiq.G2Cto_seccon_cont = tmpRegAdm.Cto_seccon_cont;
            gobLiq.G2Fcm_codcpr_cpro = this.txtG1Fcm_codcpr_cpro.Text;
            gobLiq.G2Fcm_fecser_dfac = this.txtG1Hcl_gesfec_hcor.Text;
            gobLiq.G2Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
            gobLiq.G2Sia_aresol_aser = tmpRegAdm.Sia_codare_aser;
            gobLiq.G2Sia_codare_aser = this.txtG1Sia_codare_aser.Text;
            gobLiq.G2Fcm_fecfac_mfac = this.txtG1Hcl_gesfec_hcor.Text;
            gobLiq.G2Fcm_horser_dfac = Funciones.fcrHoraActual("24", gcrSeparadorDecimal);
            gobLiq.G2Fac_horprs_dfac = gobLiq.G2Fcm_horser_dfac;
            gobLiq.G2Fcm_fecedt_dfac = Funciones.fcrFechaActual();
            gobLiq.G2Fcm_estfac_mfac = "1";
            gobLiq.G2Fcm_tiprfa_mfac = "1";
            gobLiq.G2Fcm_codman_mans = tmpRegContrato.fcm_codman_mans;
            gobLiq.G2Cto_seccon_cont = tmpRegContrato.cto_seccon_cont;
            gobLiq.G2Cto_serper_cont = tmpRegContrato.cto_serper_cont;
        }
        #endregion
        #region fcvCargarDatosUsuarioProfesionalActivo: Cargar datos del profesional activo en sistema
        /// <summary>
        /// <para>Cargar datos del profesional activo en sistema</para>  
        /// </summary>
        public void fcvCargarDatosUsuarioProfesionalActivo()
        {
            this.txtG1Sia_codpfa_prof.Text = "NA";
            var lobReg = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario);
            if (lobReg != null)
            {
                this.txtG1Sia_codpfa_prof.Text = lobReg.sia_codpfa_prof;
            }
        }
        #endregion
        // Validacion Codigo de digitacion del medicamento o insumo
        #region fcrValidaCodigoDigitacionAlmacen: Validar codigo en existencias y cantidad 
        /// <summary>
        /// <para>Validar codigo Medicamento en existencias almacen y cantidad</para>  
        /// </summary>
        public String fcrValidaCodigoDigitacionAlmacen()
        {
            var lcrValorReturn = "OK";
            gnuTotalUnidExisten = 0;

            #region Cuando es insumo o medicamento para descargar
            if (this.chkG1Hcl_envalm_hcor.IsChecked == true)
            {
                // Verificar 
                var lobReg = tmpDatosDetalle.FirstOrDefault(x => x.Fcm_coddig_mant == this.txtG1Fcm_coddig_mant.Text);
                if (lobReg != null)
                {
                    if (lobReg.Hcl_nroreg_hcor != tmpRegDetalle.Hcl_nroreg_hcor)
                    {
                        lcrValorReturn = "Ya existe un registro en la lista para el codigo: " + " - " + this.txtG1Fcm_coddig_mant.Text;
                    }
                }

                if (lcrValorReturn == "OK")
                {
                    var lobreAx = ModeloInvAlmacenExistencias.fobRegInvalmacexistenAlm(tmpRegAreaSer.inv_codalm_inal.Trim(), this.txtG1Fcm_coddig_mant.Text);
                    if (lobreAx != null)
                    {
                        gnuTotalUnidExisten = lobreAx.Inv_totuni_inex;

                        if (lobreAx.Inv_totuni_inex <= 0)
                        {
                            lcrValorReturn = "No hay existencias en: " + gcrNombreAlmacen + " - " + tmpRegAreaSer.inv_codalm_inal + " - " + this.txtG1Fcm_coddig_mant.Text;
                        } 

                        gobLiq.G2Fcm_coddig_mant = lobreAx.Fcm_coddig_mant;
                        tmpRegDetalle.Inv_secart_mart = lobreAx.Inv_secart_inar;
                    }
                    else
                    {
                        lcrValorReturn = "Código articulo no tiene existencias en: " + gcrNombreAlmacen + " - " + tmpRegAreaSer.inv_codalm_inal + " - " + this.txtG1Fcm_coddig_mant.Text;
                    }
                }
            }
            #endregion
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidaCodigoDigitacionIPS: Validacion del suministro cen configuracion en Servicios IPS
        /// <summary>
        /// <para>Realizar Validacion del suministro con respecto a configuracion en Servicios IPS</para>  
        /// </summary>
        public String fcrValidaCodigoDigitacionIPS(String tcrNumeroRegistro, String tcrNombreCampo)
        {
            String lcrValorReturn = gobLiq.fcrValidacionCampos("Fcm_coddig_mant", ref tmpLogErrores, tcrNumeroRegistro);

            #region Validar codigo servicio IPS
            if (String.IsNullOrWhiteSpace(lcrValorReturn))
            {
                var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(gobLiq.G2Fcm_coddig_mant);
                var tmpSrv = FCMValidarCodigo.fobRegBuscarIuFcmmanserviciosProg(gobLiq.G2Fcm_coddig_mant, tmpRegContrato.fcm_codman_mans,
                                                                                tmpRegContrato.cto_seccon_cont, tmpRegContrato.cto_serper_cont);
                if (tmp != null && tmp.fcm_idesec_sips != null && tmpSrv != null)
                {
                    this.txtG1Fcm_idesec_sips.Text = tmp.fcm_idesec_sips;
                    this.txtG1Fcm_desser_sips.Text = tmp.fcm_desser_sips;
                    this.txtG1Fcm_codcpr_cpro.Text = tmp.fcm_codcpr_cpro;

                    if (!flgValidacionPertinencia())
                    {
                        lcrValorReturn = tcrNombreCampo + " : Error en validación pertinencia";
                    }
                    else
                    {
                        //- Actualizar temporal
                        tmpRegDetalle.Fcm_idesec_sips = tmp.fcm_idesec_sips;

                        // Guardar el codigo de digitacion en campo auxiliar
                        if (this.chkG1Hcl_envalm_hcor.IsChecked == true)
                        {
                            tmpRegDetalle.Fcm_secreg_dfac = tmp.fcm_coddig_mant;
                        }
                    }
                }
                else
                {
                    lcrValorReturn = "Código servicio: " + gobLiq.G2Fcm_coddig_mant + " No existe";
                    txtG1Fcm_desser_sips.Text = lcrValorReturn;
                }
            }
            #endregion
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // Validacion de pertinencia
        //-------------------------------------------------
        #region flgValidacionPertinencia: Validacion pertinencia del servicio
        /// <summary>
        /// Validacion pertinencia del servicio
        /// </summary>
        public bool flgValidacionPertinencia()
        {
            var llgReturn = true;
            flgAsignarTotalUnidadesParaValidacion();
            //Validar pertinencia
            llgReturn = gobLiq.flgValidacionPertinencia(ref tmpLogErrores, "PERTINENCIA");
            return llgReturn;
        }
        #endregion
        #region flgAsignarTotalUnidadesParaValidacion: Asignar total unidades desde vista
        /// <summary>
        /// Asignar total unidades desde vista captura de datos
        /// </summary>
        public bool flgAsignarTotalUnidadesParaValidacion()
        {
            var llgReturn = false;

            if (!String.IsNullOrWhiteSpace(this.txtG1Hcl_totuni_hcor.Text))
            {
                if (Funciones.flgExisteSubCadenaStringEx(this.txtG1Hcl_totuni_hcor.Text, "0123456789"))
                {
                    gobLiq.G2Fcm_totuni_dfac = Convert.ToInt32(this.txtG1Hcl_totuni_hcor.Text);
                    llgReturn = true;
                }
                else
                {
                    gobLiq.G2Fcm_totuni_dfac = 1;
                }
            }
            else
            {
                gobLiq.G2Fcm_totuni_dfac = 1;
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void IniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                // 
                //-------------------------------------------------
                #region HOS_TIPHAB_HABI: Unipersonal SI/NO
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Servicio,Inidicacion médica";
                lstG1Hcl_tipser_hcor = new List<CrtForms.ListaComboBox>();
                lstG1Hcl_tipser_hcor = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                //- Asignar al control
                /*
                cboG1Hcl_tipser_hcor.ItemsSource = lstG1Hcl_tipser_hcor;
                cboG1Hcl_tipser_hcor.SelectedIndex = Convert.ToInt32(lstG1Hcl_tipser_hcor[0].IdIndice);
                */
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion objetos vista detalles 
        //-------------------------------------------------
        #region fcvModificarRegDetalle: Modificar registro detalle
        /// <summary>
        /// <para>Modificar registro detalle</para>
        /// </summary>
        private void fcvModificarRegDetalle(object sender, RoutedEventArgs e)
        {
            var lobObjeto       = fobRefControlVistaRegDetalle(sender);
            var lcrIdRegistro   = lobObjeto.IdRegistro;

            // cargar registro en vista variables
            var lobReg = tmpDatosDetalle.FirstOrDefault(x => x.Hcl_nroreg_hcor == lcrIdRegistro);
            if (lobReg != null)
            {
                tmpRegDetalle = fobAuxCopiarRegistro(lobReg);
                tmpRegDetalle.Sis_estado_imaen = tmpRegDetalle.Sis_estado_imaen != "A" ? "M" : "A";
                fcvCargarVistaVariablesDesdeRegActivo();
            }

        }
        #endregion
        #region fcvEliminarRegDetalle: Eliminar un registro detalle
        /// <summary>
        /// <para>Eliminar un registro detalle</para>
        /// </summary>
        private void fcvEliminarRegDetalle(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lobObjeto     = fobRefControlVistaRegDetalle(sender);
                var lcrIdRegistro = lobObjeto.IdRegistro;

                fcvEliminarRegistroRelacion(lcrIdRegistro);
                flgValidacion();
            }
        }
        #endregion
        #region fcvEliminarRegistroRelacion: Eliminar registro dado el codigo unico en temporal
        /// <summary>
        ///  Eliminar registro dado el codigo unico en temporal
        /// </summary>
        private void fcvEliminarRegistroRelacion(String tcrIdCodigoUnico)
        {
            ControlOrdHojaConsumoDeEdt lobObjeto = null;
            var lobReg = tmpDatosDetalle.FirstOrDefault(x => x.Hcl_nroreg_hcor == tcrIdCodigoUnico);

            if (lobReg != null)
            {
                lobObjeto = lobReg.RefObjeto as ControlOrdHojaConsumoDeEdt;

                if (lobReg.Sis_estado_imaen != "A")
                {
                    lobReg.Sis_estado_imaen = "E";
                }
                else
                {
                    // Es un registro que no esta en base de datos
                    tmpDatosDetalle.Remove(lobReg);  // lobReg.Sis_estado_imaen = "N";  Cuando es "A" se marca nulo
                }
            }
            if (lobObjeto != null)
            {
                // quitar de la vista
                this.stkDetalles.Children.Remove(lobObjeto);
            }
        }
        #endregion
        // Referencia control de usuario
        #region fobRefControlVistaRegDetalle: Referencia al control de usuario que representa el registro
        /// <summary>
        /// <para>Referencia al control de usuario que representa el registro</para>
        /// </summary>
        private ControlOrdHojaConsumoDeEdt fobRefControlVistaRegDetalle(object sender)
        {
            var lcrIdRegistro = String.Empty;
            var lobBoton = sender as Button;
            var lobGrid1 = lobBoton.Parent as Grid;
            var lobGrid2 = lobGrid1.Parent as Grid;
            var lobObjeto = lobGrid2.Parent as ControlOrdHojaConsumoDeEdt;

            return lobObjeto;
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
                var lobRegEx = HCLValidarCodigo.fobRegBuscarHcltiporegserms("HCON");
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(lobRegEx.hcl_codreg_hcca);

                if (!String.IsNullOrWhiteSpace(lobReg.grp_idepla_grpl))
                {
                    // Generar registro de actividad en historia clinica
                    var loPlant         = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);
                    var lobHist         = new HclModeloHistorialEventos();
                    var lcrEvento       = lobReg.hcl_desreg_hcca;
                    var ldaFechaEvento  = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcor.Text);
                    var ldaHoraEvento   = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));

                    #region Datos del registro
                    lobHist.Hcl_secreg_hcev = 1;
                    lobHist.Hcl_nrohis_hicl = tmpRegAdm.Hcl_nrohis_hicl;
                    lobHist.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                    lobHist.Cit_codasi_mcit = tmpRegAdm.Cit_codasi_mcit;
                    lobHist.Fcm_codcpr_cpro = tmpDatosDetalle.FirstOrDefault().Fcm_codcpr_cpro;
                    lobHist.Sia_idesec_usua = tmpRegAdm.Sia_idesec_usua;
                    lobHist.Sia_tipide_tide = tmpRegAdm.Sia_tipide_tide;
                    lobHist.Sia_nroide_usua = tmpRegAdm.Sia_nroide_usua;
                    lobHist.Hcl_codaux_hcev = tmpRegMaestro.Hcl_nroreg_hcms;
                    lobHist.Hcl_gesfec_hcev = ldaFechaEvento;
                    lobHist.Hcl_geshor_hcev = ldaHoraEvento;
                    lobHist.Sia_codpfa_prof = tmpRegMaestro.Sia_codpfa_prof;
                    lobHist.Hcl_keydat_hcev = (fcrGenerarLlaveMs(tmpRegMaestro) + " " + lcrEvento).ToLower();
                    lobHist.Hcl_xmldat_hcev = String.Empty;
                    lobHist.Hcl_xmltmp_hcev = String.Empty;
                    lobHist.Hcl_xmlcom_hcev = String.Empty;
                    lobHist.Hcl_conobj_hcev = 0;
                    lobHist.Hcl_desreg_hcev = lcrEvento;
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvHclinicaGenerarActividad");
            }
            return lcrCodgioRegHist;

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
            if (tmpDatosDetalle.Count != 0 && tmpRegDetalle != null)
            {
                foreach (var lobReg in tmpDatosDetalle)
                {
                    if (lobReg.Sis_estado_imaen != "N")
                    {
                        lcrllave4 += " " + fcrGenerarLlaveDetalles(lobReg);
                    }
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

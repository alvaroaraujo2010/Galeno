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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System.IO;
using GestorReportes.Modelo;
using GestorReportes.Vista;
using GestorReportes.Utilidades;
using Datos.Modelos;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclregordeservi
    /// </summary>
    public partial class SolicitAddRecursos : Window, SIS_Interface
    {
        //-------------------------------------------------
        // Inicio Formulario
        //-------------------------------------------------
        #region Inicio Formulario
        #region Variables
        public Aplicacion oApp = Aplicacion.Instancia();
        public bool llgModoAdicion = false;
        public bool llgModoEdicion = false;
        public bool llgModoEdicionKey = false;
        public bool llgModoEdicionValid = false;
        public bool llgObjetosCargados = false;
        public int lnuContNuevoRegistro = 0; // Para codigo temporal de nuevos registros
        public String gcrCtrF2TexBox;
        public DispatcherTimer gdspTimerSistema = new DispatcherTimer();
        public String lcrFormModoPopup      = "DFL";
        public String gcrSeparadorDecimal   = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public String gcrCodigoAdmision     = String.Empty;
        public String gcrCodigoMaestro      = String.Empty;
        public String gcrCodigoRegistro     = String.Empty;
        public String gcrModoAccion         = String.Empty;
        public String gcrTipoRecurso        = "IMG";  // IMG = Imagenes PDF,XLS,...,DOC, = documentos de word ....
        public Funciones.ArchivoRecurso gobArchivoRecurso = null;
        public ExplorerPropRecursos gobPropRecurso = null;

        // Temporales
        public ADMModeloAdmadmisiones tmpRegAdmision    = null;
        public ModeloHclregordeserms tmpRegMaestro      = null;
        public ModeloHclhistarchivos tmpRegDetalle      = new ModeloHclhistarchivos();
        public List<ModeloHclhistarchivos> tmpDatosDetalle = null;
        public EFctomaescontrato tmpRegContrato         = null;
        public List<LogsErrores> tmpLogErrores          = new List<LogsErrores>();
        DialogVistaErrores lobDlgLogs                   = null;
        public List<CrtForms.ListaComboBox> lstG1Grc_tiprec_grtr = null;
        #endregion
        /// <summary>
        /// Inicializar nueva instancia de la clase
        /// <para>PARAMETROS:</para>
        /// <para>tcrModoAccion: "ADD/EDT/DFL"= Edicion de registros desd HC.  "GES" = Para Gestion Cargue registros en modo masivo</para>
        /// </summary>
        public SolicitAddRecursos(String tcrModoAccion, String tcrTipoRecurso, String tcrCodigoRegistro, String tcrCodigoAdmision)
        {
            InitializeComponent();

            #region Iniciar procesos
            fcvSetRichTextBoxEditor();
            IniciarComboBox();

            gcrTipoRecurso      = tcrTipoRecurso;
            gcrModoAccion       = tcrModoAccion;
            gcrCodigoMaestro    = String.Empty;
            gcrCodigoRegistro   = tcrCodigoRegistro;
            gcrCodigoAdmision   = tcrCodigoAdmision;
            gobPropRecurso      = fobExplorerValoresParametrosRecurso();

            Aplicacion oApp = Aplicacion.Instancia();
            lblSysUsuIdUsuario.Text = oApp.gcrUsuIdUsuario;
            lblSysUsuCodigoPerfil.Text = oApp.gcrUsuCodigoPerfil;

            this.MouseDown += new MouseButtonEventHandler(fcvGotFocus);
            this.GotFocus += new RoutedEventHandler(fcvGotFocus);
            #region Asignar Manejador de SelectedDateChanged a DatePiker
            dpkG1Hcl_gesfec_hcms.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(fcvDatePickerSelected);
            #endregion
            if (!String.IsNullOrWhiteSpace(tcrModoAccion))
            {
                fcvCargarVistaFormPopup(tcrModoAccion, tcrCodigoRegistro, tcrCodigoAdmision);
            }
            llgObjetosCargados = true;
            fcvTimerGeneral();
            #endregion
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
            var llgExiste = flgCargarDatosHistoricoHclregordeserms(tcrCodigoRegistro);

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
                    //lcrFormModoPopup = "DFL";
                    lcrFormModoPopup = tcrModoAccion;
                    break;
            }
            fcvActivarModoEdicion(lcrFormModoPopup);
        }
        #endregion
        #region  Activar modo edicion
        //- Activar modo edicion en la Vista
        public void fcvActivarModoEdicion(string tcrTipoEdicion)
        {
            if (gcrModoAccion == "GES")
            {
                fcvAuxReiniciarTemporales();
                fcvEdicionNuevoRegistroDetalles();
            }

            llgModoAdicion = true;
            llgModoEdicion = true;

            switch (tcrTipoEdicion)
            {
                case "ADD":
                    llgModoAdicion = true;
                    llgModoEdicion = true;
                    fcvCargarDatosIniDesdeHclinica();
                    break;

                case "EDT":
                    llgModoAdicion = false;
                    llgModoEdicion = tmpRegMaestro.Sis_estpro_espr == "1" ? true : false;
                    fcvCargarDatosIniDesdeHclinica();
                    break;

                case "DFL":
                    llgModoAdicion = false;
                    llgModoEdicion = false;
                    fcvCargarDatosIniDesdeHclinica();
                    break;
            }
            fcvAuxActivarControlVistaRecurso(gcrTipoRecurso);
            fcvVistaObjetosActivarObjetosCaptura(llgModoEdicion);

            FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcms);
        }
        #endregion
        //-------------------------------------------------
        // Gestion Edicion
        //-------------------------------------------------
        #region Gestion Edicion
        //- clic en Boton Nuevo registro detalle
        #region fcvEdicionNuevoRegistroDetalle: Nuevo registro detalle
        /// <summary>
        /// Nuevo registro detalle metodo desde boton Nuevo Registro en formulario
        /// </summary>
        private void fcvEdicionNuevoRegistroDetalle(object sender, RoutedEventArgs e)
        {
            fcvEdicionNuevoRegistroDetalles();
        }
        #endregion
        #region fcvEdicionLimpiarVistaGeneral: Limpia la vista general
        /// <summary>
        /// Limpia vista general y la prepara para agregar nuevo registros
        /// </summary>
        private void fcvEdicionLimpiarVistaGeneral(object sender, RoutedEventArgs e)
        {
            fcvEdicionLimpiarVistaGeneral();
        }
        #endregion
        #region fcvEdicionNuevoRegistroDetalles: Activar modo edicion y generar datos par nuevo registro
        /// <summary>
        /// <para>Activar modo edicion y generar datos par nuevo registro detalle</para>
        /// <para>vaciar el registro activo detalle, limpiar objetos de zona 2</para>
        /// </summary>
        private void fcvEdicionNuevoRegistroDetalles()
        {
            tmpRegDetalle = new ModeloHclhistarchivos();
            fcvVistaObjetosActivarObjetosCaptura(true);
            fcvEdicionIniciarVistaObjetosZonas("2");
            tmpRegDetalle.Hcl_iderec_hclr = String.Empty;
            tmpRegDetalle.Grc_codest_gres = "NA"; // ojo por el momento porque no hay estandar definido
            tmpRegDetalle.Grc_codesp_grep = "NA"; // ojo por el momento porque no hay estandar definido
            tmpRegDetalle.Sis_estado_imaen = "A";
        }
        #endregion
        #region fcvEdicionLimpiarVistaGeneral: Limpia la vista general
        /// <summary>
        /// Limpia vista general y la prepara para agregar nuevo registro
        /// </summary>
        public void fcvEdicionLimpiarVistaGeneral()
        {
            this.txtG1Sia_idesec_usua.Text = String.Empty;
            this.txtG1Sia_tipide_tide.Text = String.Empty;
            this.txtG1Sia_nroide_usua.Text = String.Empty;
            this.txtG1Sia_nomusu_usua.Text = String.Empty;

            // 1- Salvar profesional y cent producc
            var lcrCodigoProfesional = this.txtG1Sia_codpfa_prof.Text;
            var lcrCentroProduccion = this.txtG1Fcm_codcpr_cpro.Text;

            // 2 - Limpiar temporales y vistas
            fcvAuxReiniciarTemporales();

            fcvEdicionIniciarVistaObjetosZonas("1");
            fcvEdicionIniciarVistaObjetosZonas("2");
            fcvEdicionNuevoRegistroDetalles();

            // Restaurar valores digitados por si se usan
            this.txtG1Sia_codpfa_prof.Text = lcrCodigoProfesional;
            this.txtG1Fcm_codcpr_cpro.Text = lcrCentroProduccion;

            tmpRegMaestro.Sis_estpro_espr = "1";
            flgValidacion();

            FocusManager.SetFocusedElement(this, this.cmdBrowser);

        }
        #endregion
        #region fcvEdicionIniciarVistaObjetosZonas: Limpiar vista de variables para nueva captura de datos
        /// <summary>
        /// <para>Iniciar valores vista objetos para nueva captura de datos</para>
        /// <para>tcrGrupoVista: 1= Objetos Zona 1 o registro maestro "2"= Objetos de la zona detalles</para>
        /// </summary>
        public void fcvEdicionIniciarVistaObjetosZonas(String tcrGrupoVista)
        {
            try
            {
                #region Valores Variables
                if (tcrGrupoVista == "1")
                {
                    this.txtG1Hcl_gesfec_hcms.Text = Funciones.fcrFechaActual();
                    this.txtG1Hcl_geshor_hcms.Text = Funciones.fcrHoraActual("12", ":");
                    this.txtG1Sia_codpfa_prof.Text = tmpRegAdmision.Sia_codpfa_prof; 
                    this.txtG1Fcm_codcpr_cpro.Text = tmpRegAdmision.Fcm_codcpr_cpro; // Historias clinicas -- Ojo esto debe estar en la tabla "Parametros configuracion modulo HC."
                }
                else
                {
                    var lobG1Hcl_texcon_hclr = fcvRefRichTextBoxEditor("txtG1Hcl_texcon_hclr");

                    this.txtRutaOrigen.Text = String.Empty;
                    this.txtG1Hcl_nomarc_hclr.Text = String.Empty;
                    this.txtG1Hcl_rutarc_hclr.Text = "2";

                    lobG1Hcl_texcon_hclr.Text = String.Empty;

                    tmpRegDetalle = new ModeloHclhistarchivos();

                    this.lblAgregar.Text = "Agregar";
                    this.cmdBuscarArchivo.IsEnabled = true;

                    // Limpiar vista de recuros en Zona 2
                    this.imgArchivo.Source = null;
                    this.pdfArchivo.Source = null;
                }
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvEdicionIniciarVistaObjetosZonas");
            }
        }
        #endregion
        //-Clic en Boton Guardar 
        #region fcvGuardarAgregarRegDetalle: Guardar registro modificado/agregado en pantalla
        private void fcvGuardarAgregarRegDetalle(object sender, RoutedEventArgs e)
        {
            ControlOrdRecursoDetalleEdt lobDetalle = null;
            fcvAuxRegistroActivoDesdeVariables();
            if (tmpRegDetalle.Sis_estado_imaen == "A" && String.IsNullOrWhiteSpace(tmpRegDetalle.Hcl_iderec_hclr))
            {
                lobDetalle = new ControlOrdRecursoDetalleEdt();
                lnuContNuevoRegistro++;
                tmpRegDetalle.Hcl_iderec_hclr = "R" + lnuContNuevoRegistro.ToString().Trim();

                tmpRegDetalle.RefObjeto = lobDetalle;
                fcvObjetosGridDatosBasicos(ref lobDetalle, tmpRegDetalle);
                flgObjetosGridValoresRegistro(ref lobDetalle, tmpRegDetalle);

                tmpDatosDetalle.Add(fobAuxCopiarRegistro(tmpRegDetalle));
                this.stkDetalles.Children.Add(lobDetalle);
            }
            else
            {
                fcvAuxActualizarEnMaestroTemporal();
                lobDetalle = tmpRegDetalle.RefObjeto as ControlOrdRecursoDetalleEdt;
                flgObjetosGridValoresRegistro(ref lobDetalle, tmpRegDetalle);
            }
            // actualizar vista del objeto y modificar el temporal tmpDatosDetalle
            fcvEdicionNuevoRegistroDetalles();
        }
        #endregion
        #region fcvGuardarRegistro: Guardar sin confirmar
        private void fcvGuardarRegistro(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea guardar los registros?", "Guardar",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                fcvGuardarRegistroMaestro("1");
            }
        }
        #endregion
        #region fcvGuardarConfirmarRegistro: Guardar y confirmar proceso
        private void fcvGuardarConfirmarRegistro(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea guardar y confirmar los registros?", "Confirmación",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                fcvGuardarRegistroMaestro("2");
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
            //- iniciar barra de progreso 
            var lobDlgAdd = Funciones.fobWindEspera("Guardando datos...", "CENTRO");

            var lcrNuevoCodigo = String.Empty;
            if (flgValidacion() == true)
            {
                if (flgGuardarRegistroMaestro(tcrEstado) == true)
                {
                    fcvGuardarRegistroDetalles(gcrCodigoMaestro);

                    if (gcrModoAccion == "GES")
                    {
                        // Reiniciar la vista para agregar otro
                        fcvEdicionLimpiarVistaGeneral();
                    }
                    else
                    {
                        fcvRetornoInterface(gcrCodigoMaestro);
                    }
                }
                lobDlgAdd.Close();
            }
            else
            {
                lobDlgAdd.Close();
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
            var lnuContador = HclModeloHistorialEventos.fnuGenSecuencialObjetosEvento(tmpRegMaestro.Hcl_nroreg_hcev, 0);

            foreach (var lobReg in tmpDatosDetalle)
            {
                // actualizar datos que en registro R1 posiblemente se cambiaron
                lobReg.Hcl_nroreg_hcms = tcrCodigoMaestro;
                lobReg.Sia_codpfa_prof = tmpRegMaestro.Sia_codpfa_prof;
                lobReg.Sis_estpro_espr = tmpRegMaestro.Sis_estpro_espr;
                lobReg.Hcl_nroreg_hcev = tmpRegMaestro.Hcl_nroreg_hcev;

                // Aplicar politica de gestion registro
                if (lobReg.Sis_estado_imaen == "E")
                {
                    ModeloHclhistarchivos.fcvEliminar(lobReg.Hcl_iderec_hclr);
                    lobReg.Sis_estado_imaen = "N"; // se marca como nulo para ser ignorado pór completo en el futuro
                }
                else if (lobReg.Sis_estado_imaen != "A" && lobReg.Sis_estado_imaen != "N")
                {
                    ModeloHclhistarchivos.fcvActualizar(lobReg);
                    lobReg.Sis_estado_imaen = "I";
                }
                else if (lobReg.Sis_estado_imaen == "A")
                {
                    // Generar el nombre de archivo
                    lobReg.Hcl_nomarc_hclr = lobReg.Sia_idesec_usua.Trim() + "_" +
                                                lobReg.Grc_tiprec_grtr + "_" + tcrCodigoMaestro + "R" +
                                                lnuContador.ToString().Trim() + "." + lobReg.Hcl_extarc_hclr;

                    lcrNuevoCodigo = ModeloHclhistarchivos.flgAddRegistro(lobReg);
                    if (!String.IsNullOrWhiteSpace(lcrNuevoCodigo))
                    {
                        lobReg.Hcl_iderec_hclr = lcrNuevoCodigo;
                        lobReg.Sis_estado_imaen = "I";
                    }
                }
                fcvGuardarGestionRegRecurso(lobReg);
                lnuContador++;
            }
            HclModeloHistorialEventos.fnuGenSecuencialObjetosEvento(tmpRegMaestro.Hcl_nroreg_hcev, lnuContador);
        }
        #endregion
        #region fcvGuardarGestionRegRecurso: Guardar modificar o eliminar archivo de recurso
        /// <summary>
        /// Guardar modificar o eliminar archivo de recurso
        /// </summary>
        private void fcvGuardarGestionRegRecurso(ModeloHclhistarchivos tobRegistro)
        {
            var lcrArchivoRutaOrigen = tobRegistro.Sis_rutorigen_temp;
            lcrArchivoRutaOrigen     = !String.IsNullOrWhiteSpace(lcrArchivoRutaOrigen) ? lcrArchivoRutaOrigen : String.Empty;

            var lcrRutaRecurso      = Funciones.fcrGenRutaArchivoRecurso(tobRegistro.Hcl_rutarc_hclr);
            var lcrArchivoDestino   = Funciones.fcrSystemIOPathCombine(tobRegistro.Hcl_nomarc_hclr, lcrRutaRecurso, false).ToLower();

                // Aplicar politica de gestion registro
                if (tobRegistro.Sis_estado_imaen == "E")
                {
                    if (File.Exists(@lcrArchivoDestino.ToLower()))
                    {
                        File.Delete(@lcrArchivoDestino);
                    }
                }
                else if (tobRegistro.Sis_estado_imaen != "A" && tobRegistro.Sis_estado_imaen != "N")
                {
                    // se actualiza cuando hay un cargue nuevo
                    if (!String.IsNullOrWhiteSpace(lcrArchivoRutaOrigen))
                    {
                        Funciones.flgCopiarArchivoRecurso(lcrArchivoRutaOrigen, lcrArchivoDestino);
                    }
                }
                else if (tobRegistro.Sis_estado_imaen == "A")
                {
                    // se actualiza cuando hay un cargue nuevo
                    if (!String.IsNullOrWhiteSpace(lcrArchivoRutaOrigen))
                    {
                        Funciones.flgCopiarArchivoRecurso(lcrArchivoRutaOrigen, lcrArchivoDestino);
                    }
                }
        }
        #endregion
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
                lcrIdActividadHClinico = fcvHclinicaGenerarActividad(gcrTipoRecurso);

                // Generar Registro Maestro historias clinicas cuando no exista
                var lobRegHc = HCLValidarCodigo.fobRegBuscarHclmaestrohisclIGEst(tmpRegMaestro.Sia_idesec_usua, "2");
                if (lobRegHc == null)
                {
                    ModeloHclmaehistoriasclinicas.fcrAddRegHClinicaUsuario(tmpRegMaestro.Sia_idesec_usua, this.txtG1Sia_codpfa_prof.Text);
                }
            }

            var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoRecurso, gcrCodigoAdmision, "1");
            if (lobReg.Count != 0)
            {
                tmpRegMaestro = lobReg.FirstOrDefault();
                gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;

                tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcms.Text);
                tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcms.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegMaestro.Hcl_tiptur_hctu = ModeloHcltiporegturno.fobRegistroHcltiporegturno(tmpRegMaestro.Hcl_geshor_hcms).Hcl_tiptur_hctu;
                tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegMaestro.Sis_estpro_espr = tcrEstado;

                ModeloHclregordeserms.fcvActualizar(tmpRegMaestro);
            }
            else
            {
                // Adicionar el registro
                tmpRegMaestro = new ModeloHclregordeserms();
                #region Valores Variables
                tmpRegMaestro.Adm_secadm_rgad = tmpRegAdmision.Adm_secadm_rgad;
                tmpRegMaestro.Sia_idesec_usua = tmpRegAdmision.Sia_idesec_usua;
                tmpRegMaestro.Sia_tipide_tide = tmpRegAdmision.Sia_tipide_tide;
                tmpRegMaestro.Sia_nroide_usua = tmpRegAdmision.Sia_nroide_usua;
                tmpRegMaestro.Hcl_tipreg_hctr = gcrTipoRecurso;
                tmpRegMaestro.Sia_codare_aser = tmpRegAdmision.Sia_codare_aser;
                tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcms.Text);
                tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcms.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegMaestro.Hcl_tiptur_hctu = ModeloHcltiporegturno.fobRegistroHcltiporegturno(tmpRegMaestro.Hcl_geshor_hcms).Hcl_tiptur_hctu;
                tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegMaestro.Sis_estpro_espr = tcrEstado;
                tmpRegMaestro.Hcl_nroreg_hcev = lcrIdActividadHClinico;
                #endregion
                gcrCodigoMaestro = ModeloHclregordeserms.flgAddRegistro(tmpRegMaestro);
                tmpRegMaestro.Hcl_nroreg_hcms = gcrCodigoMaestro;
            }

            llgReturn = !String.IsNullOrWhiteSpace(gcrCodigoMaestro) ? true : false;
            return llgReturn;
        }
        #endregion
        #endregion
        #region fcvRetornoInterface
        /// <summary>
        /// Retoma la interfase con la ventana principal
        /// entrega el codigo seleccionado y cierra el Browser
        /// </summary>
        private void fcvRetornoInterface(string tcrCodigSelect)
        {
            oApp.gcrWinMsCodigoMensaje = tcrCodigSelect;
            SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
            if (lobRefEnlace != null)
            {
                lobRefEnlace.fcvBuscarRegistro(tcrCodigSelect);
            }
            gdspTimerSistema.Stop(); // para que se finalice el timer
            fcvAuxLiberarObjetosGrilla();
            this.Close();
        }
        #endregion
        //-------------------------------------------------
        // Gestion vista errores
        //-------------------------------------------------
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
            gdspTimerSistema.Stop(); // para que se finalice el timer
            fcvAuxLiberarObjetosGrilla();
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
        private void fcvTouchEnterTecladoRt(object sender, TouchEventArgs e)
        {
            if (Process.GetProcessesByName("OSK").Length < 1)
            {
                RichTextBox lobTexto = sender as RichTextBox;
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
        private void fcvMoverFocus_KeyDownRt(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((RichTextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
        }
        private void fcvTextBox_GotFocusRt(object sender, RoutedEventArgs e)
        {
            RichTextBox tb = e.Source as RichTextBox;
            tb.SelectAll();
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
                    this.txtG1Sia_codpfa_prof.Text = tcrCodigo;
                    break;

                case "txtG1Fcm_codcpr_cpro":
                    this.txtG1Fcm_codcpr_cpro.Text = tcrCodigo;
                    break;

                case "txtG1Sia_idesec_usua":
                    this.txtG1Sia_idesec_usua.Text = tcrCodigo;
                    break;
            }
        }
        #endregion
        #region FCM_IDESEC_SIPS : Maestro de medicamentos manual de ventas
        private void txtG1Fcm_idesec_sips_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                e.Handled = true;
                ((TextBox)sender).MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
            }
            if (e.Key == Key.F2)
            {
                fcvBuscarServicio_Browser();
            }
        }
        private void fcvBuscarServicio(object sender, RoutedEventArgs e)
        {
            fcvBuscarServicio_Browser();
        }
        private void fcvBuscarServicio_Browser()
        {
            Browser01 frbro = new Browser01("FCM", "FCMMANSERVICIOS-MED", tmpRegContrato.fcm_codman_mans, "Maestro de servicios ...");
            gcrCtrF2TexBox = "txtG1Fcm_coddig_mant";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
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
        #region llamada funciones compos con F2
        private void fcvBrowserBuscar(object sender, RoutedEventArgs e)
        {
            gcrModoAccion = "GES"; // ojo solo para probar
            Browser01 frbro = new Browser01("SIA", "SIAUSUARIOATEND", "", "Maestro de Pacientes atendidos...");
            gcrCtrF2TexBox = "txtG1Sia_idesec_usua";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        //-------------------------------------------------
        // Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
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
                        case "cboG1Grc_tiprec_grtr":
                            txtG1Grc_tiprec_grtr.Text = CrtForms.fcrSeletDesdeComb(lobList.IdIndice, ",", lobList.ListaValoresSel);
                            lobCombo.SelectedIndex = CrtForms.fnuMostrarItemCombo(txtG1Grc_tiprec_grtr.Text, ",", lobList.ListaValoresSel) - 1;

                            gcrTipoRecurso = this.txtG1Grc_tiprec_grtr.Text;

                            fcvEdicionNuevoRegistroDetalles();
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
        #region Actualizar ComboBox desde Campo Texto
        private void ActualizarComboBoxOpcion(object sender, TextChangedEventArgs e)
        {
            try
            {
                /*
                if (llgObjetosCargados == true)
                {
                    TextBox lobTexto = (TextBox)sender;
                    string lcrValor = string.Empty;
                    if (!string.IsNullOrEmpty(lobTexto.Text)) { lcrValor = lobTexto.Text; }

                    switch (lobTexto.Name)
                    {
                        case "txtG1Hcl_tipreg_hcbd":
                            CrtForms.ListaComboBox lobG1ComboBox1 = (CrtForms.ListaComboBox)cboG1Hcl_tipreg_hcbd.SelectedItem;
                            cboG1Hcl_tipreg_hcbd.SelectedIndex = CrtForms.fnuMostrarItemCombo(lcrValor, ",", lobG1ComboBox1.ListaValoresSel);
                            fcvActivarTabs(lcrValor);
                            break;
                    }
                    fcrValidacion(lobTexto.Name, lobTexto);
                }
                */
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: ActualizarComboBoxOpcion");
            }
        }
        #endregion
        #region Generar Listas de Opciones Combobox
        public virtual void IniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                //  Lista tipo archivo de recursos
                //-------------------------------------------------
                #region HCL_TIPSER_HCOR: Tipo servicio: 1 = Medicamento 2= Indicacion medica
                string lcrG11Seleccion = "RIMG,RPDF,RVID";
                string lcrG11Descripcion = "Archivos de imagenes (PNG.JPG.BMP.JPEG...),Archvios PDF portables, Archivos de video";
                lstG1Grc_tiprec_grtr = new List<CrtForms.ListaComboBox>();
                lstG1Grc_tiprec_grtr = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion,"1");
                //- Asignar al control
                this.cboG1Grc_tiprec_grtr.ItemsSource = lstG1Grc_tiprec_grtr;
                this.cboG1Grc_tiprec_grtr.SelectedIndex = 0;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de DatePiker Fechas
        //-------------------------------------------------
        #region Metodos Para Gestion de DatePiker Fechas
        #region  Actualizar Campo TextBox desde DatePiker
        private void fcvDatePickerSelected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DatePicker lobDpk = (sender as DatePicker);
                switch (lobDpk.Name)
                {
                    case "dpkG1Hcl_gesfec_hcms":
                        txtG1Hcl_gesfec_hcms.Text = Funciones.fcrConvertFecha((DateTime)lobDpk.SelectedDate);
                        FocusManager.SetFocusedElement(this, txtG1Hcl_gesfec_hcms);
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvDatePickerSelected");
            }
        }
        #endregion
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
                            case "txtG1Hcl_gesfec_hcms":
                                dpkG1Hcl_gesfec_hcms.SelectedDate = Convert.ToDateTime(lobTexto.Text);
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
        // CARGAR DATOS EN VARIABLES O TEMPORALES
        //-------------------------------------------------
        #region flgCargarDatosAdmision: Cargar datos de admision
        /// <summary>
        /// Cargar datos de admision para el usuario activo
        /// </summary>
        private bool flgCargarDatosAdmision(String tcrCodigoAdmision)
        {
            var llgExiste = false;

            tmpRegAdmision = HclUtilidades.fobRegAdmisionAuxiliar(tcrCodigoAdmision);

            if (tmpRegAdmision != null)
            {
                tmpRegAdmision.Fcm_codcpr_cpro = String.IsNullOrWhiteSpace(tmpRegAdmision.Fcm_codcpr_cpro) ? "9999" : tmpRegAdmision.Fcm_codcpr_cpro;
                tmpRegContrato = CTOValidarCodigo.fobRegBuscarCtomaescontrato(tmpRegAdmision.Cto_seccon_cont);

                llgExiste = true;
                // si es gestion masiva conservar algunos datos de la vista
                if (gcrModoAccion == "GES")
                {
                    tmpRegAdmision.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                    tmpRegAdmision.Fcm_codcpr_cpro = this.txtG1Fcm_codcpr_cpro.Text;
                }
            }

            return llgExiste;
        }
        #endregion
        #region fcvCargarDatosBasicosPaciente: Generar y cargar datos basicos del paciente en la vista
        /// <summary>
        /// <para>Generar y cargar datos basicos del paciente en la vista (no genera temporal)</para>
        /// <para>Cuando hay error devuelve un string que describe lo ocurrido</para>
        /// </summary>
        private String fcrCargarDatosBasicosPaciente(String tcrCodigoUnico)
        {
            var lcrValorReturn = String.Empty;

            #region Vista campos
            var tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(tcrCodigoUnico);
            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_idesec_usua))
            {
                this.txtG1Sia_idesec_usua.Text = tmp.sia_idesec_usua;
                this.txtG1Sia_tipide_tide.Text = tmp.sia_tipide_tide;
                this.txtG1Sia_nroide_usua.Text = tmp.sia_nroide_usua;
                this.txtG1Sia_nomusu_usua.Text = tmp.sia_nomusu_usua;
            }
            else
            {
                lcrValorReturn = "Identificación del paciente: No existe";
            }
            #endregion

            return lcrValorReturn;
        }
        #endregion
        #region flgCargarDatosHistoricoHclregordeserms: Cargar datos existentes desde Hclregordeserms
        /// <summary>
        /// <para>Cargar registro desde maestro Hclregordeserms en temporal, dado el Id unico de Hclregordeserms</para>
        /// <para>cuando no lo encuentra se busca en Hclhistarchivos y luego se hace recursividad de funcion</para>
        /// </summary>
        private bool flgCargarDatosHistoricoHclregordeserms(String tcrCodigo)
        {
            var llgExiste = false;
            tmpRegMaestro = new ModeloHclregordeserms();

            if (!String.IsNullOrWhiteSpace(tcrCodigo))
            {
                var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx("NA", tcrCodigo, "");
                if (lobReg != null && lobReg.Count != 0)
                {
                    tmpRegMaestro    = lobReg.FirstOrDefault();
                    gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;
                    gcrTipoRecurso   = tmpRegMaestro.Hcl_tipreg_hctr;
                    llgExiste = true;
                }
                else
                {
                    // Se busca el registro en recurosos porque es posible que el codigo sea de un recuros 
                    // en la vista HC. se dio click sobre un registro detalle recurso
                    var lobRegistro = ModeloHclhistarchivos.fobRegistroHclHistarchivos(tcrCodigo);
                    if (lobRegistro != null)
                    {
                        llgExiste = flgCargarDatosHistoricoHclregordeserms(lobRegistro.Hcl_nroreg_hcms);
                    }
                }
            }
            else
            {
                // Buscar por la admision y el tipo de registro en estado abierto
                if (!String.IsNullOrWhiteSpace(gcrCodigoAdmision))
                {
                    var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoRecurso, gcrCodigoAdmision, "1");
                    if (lobReg.Count != 0)
                    {
                        tmpRegMaestro = lobReg.FirstOrDefault();
                        gcrCodigoMaestro = tmpRegMaestro.Hcl_nroreg_hcms;
                        gcrTipoRecurso = tmpRegMaestro.Hcl_tipreg_hctr;
                        llgExiste = true;
                    }
                }
            }
            return llgExiste;
        }
        #endregion
        #region flgCargarDatosDetallesHclhistarchivos: Cargar registros detalles desde historicos
        /// <summary>
        /// <para>Cargar temporal desde historico Hclhistarchivos, dado el Id unico Registro R1 de tabla Hclregordeserms</para>
        /// </summary>
        private bool flgCargarDatosDetallesHclhistarchivos(String tcrCodigoR1)
        {
            var llgExiste = false;

            // cargar datos
            if (!String.IsNullOrWhiteSpace(tcrCodigoR1))
            {
                llgExiste = true;
                tmpDatosDetalle = ModeloHclhistarchivos.flsListaHclhistarchivos("R1", tcrCodigoR1);
            }
            return llgExiste;
        }
        #endregion
        #region fcvCargarDatosIniDesdeHclinica: Cargar datos admision ingreso desde Historias clinicas
        /// <summary>
        /// Cargar datos de admision cuando se ingresa al modulo desde Historias clinicas
        /// </summary>
        private void fcvCargarDatosIniDesdeHclinica()
        {
            fcvAuxReiniciarTemporales();

            if (!flgCargarDatosAdmision(gcrCodigoAdmision))
            {
                return;
            }
            if (flgCargarDatosHistoricoHclregordeserms(gcrCodigoRegistro))
            {
                tmpRegAdmision.Sia_codpfa_prof = tmpRegMaestro.Sia_codpfa_prof;
            }
            fcrCargarDatosBasicosPaciente(tmpRegAdmision.Sia_idesec_usua);
            fcvEdicionIniciarVistaObjetosZonas("1");

            if (String.IsNullOrWhiteSpace(tmpRegMaestro.Hcl_nroreg_hcms))
            {
                fcvCargarDatosGenRegHclregordeserms();
            }
            fcvEdicionNuevoRegistroDetalles();
            fcvVistaObjetosActivarModoGestion();
            flgVistaObjetosTituloTipoRecurso(gcrTipoRecurso);

            // Cargar registros en vista detalles
            if (flgCargarDatosDetallesHclhistarchivos(tmpRegMaestro.Hcl_nroreg_hcms))
            {
                fcvObjetosGridCargarGrillaRecursos();
            }
            flgValidacion();
        }
        #endregion
        #region fcvCargarDatosGenRegHclregordeserms: Generar los datos en registro temporal Hclregordeserms
        /// <summary>
        /// <para>Generar nuevos valores en registro temporal Hclregordeserms</para>
        /// <para>desde datos maestro admision y captura de fechas horas y de mas datos en pantalla</para>
        /// </summary>
        public void fcvCargarDatosGenRegHclregordeserms()
        {
            try
            {
                #region Valores Variables
                tmpRegMaestro.Hcl_tipreg_hctr = gcrTipoRecurso;
                tmpRegMaestro.Adm_secadm_rgad = tmpRegAdmision.Adm_secadm_rgad;
                tmpRegMaestro.Sia_idesec_usua = tmpRegAdmision.Sia_idesec_usua;
                tmpRegMaestro.Sia_tipide_tide = tmpRegAdmision.Sia_tipide_tide;
                tmpRegMaestro.Sia_nroide_usua = tmpRegAdmision.Sia_nroide_usua;
                tmpRegMaestro.Sia_codare_aser = tmpRegAdmision.Sia_codare_aser;
                tmpRegMaestro.Hcl_gesfec_hcms = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcms.Text);
                tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcms.Text, "12", ":", gcrSeparadorDecimal));
                tmpRegMaestro.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegMaestro.Sis_estpro_espr = "1";
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarDatosGenRegHclregordeserms");
            }
        }
        #endregion
        //-------------------------------------------------
        // CARGAR DATOS EN OBJETOS VISTA ZONAS
        //-------------------------------------------------
        #region flgVistaObjetosTituloTipoRecurso: Cargar titulo del tipo recurso activo en la vista
        /// <summary>
        /// <para>Cargar titulo del tipo recurso activo en la vista</para>
        /// </summary>
        private bool flgVistaObjetosTituloTipoRecurso(String tcrCodigoTipoRecurso)
        {
            var llgExiste = true;
            this.txtTitulo.Text = GRCValidarCodigo.fobRegBuscarGrctiporecursos(tcrCodigoTipoRecurso).grc_titulo_grtr;
            this.txtG1Grc_titulo_grtr.Text = this.txtTitulo.Text;

            return llgExiste;
        }
        #endregion
        #region fcvVistaObjetosZona1CargarRegMaestro: Cargar Objetos vista desde registro maestro Hclregordeserms
        /// <summary>
        /// Cargar Objetos vista desde registro maestro Hclregordeserms en zona 1  de objetos
        /// </summary>
        public void fcvVistaObjetosZona1CargarRegMaestro()
        {
            try
            {
                #region Valores Variables
                this.txtG1Hcl_gesfec_hcms.Text = tmpRegMaestro.Hcl_gesfec_hcms.ToShortDateString();
                this.txtG1Hcl_geshor_hcms.Text = Funciones.fcrConvierteHora(tmpRegMaestro.Hcl_geshor_hcms.ToString(), "24", gcrSeparadorDecimal, ":");
                this.txtG1Fcm_codcpr_cpro.Text = tmpRegAdmision.Fcm_codcpr_cpro;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvVistaObjetosZona1CargarRegMaestro");
            }
        }
        #endregion
        #region fcvVistaObjetosZona2CargarDesdeRegActivo: Cargar vista de variables desde registro activo
        /// <summary>
        /// <para>Cargar vista objetos zona 2 desde registro activo archivo hclhistarchivos</para>
        /// <para>al hacer clic en un registro detalle de la grilla</para>
        /// </summary>
        public void fcvVistaObjetosZona2CargarDesdeRegActivo()
        {
            try
            {
                #region Valores Variables
                var lobG1Hcl_texcon_hclr = fcvRefRichTextBoxEditor("txtG1Hcl_texcon_hclr");
                lobG1Hcl_texcon_hclr.Text = tmpRegDetalle.Hcl_texcon_hclr;

                this.txtRutaOrigen.Text         = tmpRegDetalle.Sis_rutorigen_temp;
                this.txtG1Sia_codpfa_prof.Text  = tmpRegDetalle.Sia_codpfa_prof;
                this.txtG1Hcl_nomarc_hclr.Text  = tmpRegDetalle.Hcl_nomarc_hclr;
                this.txtG1Hcl_rutarc_hclr.Text  = tmpRegDetalle.Hcl_rutarc_hclr;  //Ruta destino
                this.cmdBuscarArchivo.IsEnabled = tmpRegDetalle.Sis_estpro_espr =="1"? true : false;
                // Mostrar la imagen o archivo
                fcvVistaObjetosCargarArchivoRecurso();
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvVistaObjetosZona2CargarDesdeRegActivo");
            }
        }
        #endregion
        #region fcvVistaObjetosCargarArchivoRecurso: Cargar vista del archivo de recursos desde registro activo
        /// <summary>
        /// Cargar vista en objetos zona 2 del archivo de recurso imagen/pdf/video y otros desde registro activo
        /// </summary>
        public void fcvVistaObjetosCargarArchivoRecurso()
        {
            try
            {
                var lcrArchivo = String.Empty;
                fcvAuxActivarControlVistaRecurso(tmpRegDetalle.Grc_tiprec_grtr);
                // Mostrar la imagen
                if (tmpRegDetalle.Grc_tiprec_grtr == "RIMG")
                {
                    // Cargar vista del archivo imagen
                    #region imagenes
                    if (!String.IsNullOrWhiteSpace(tmpRegDetalle.Sis_rutorigen_temp))
                    {
                        // desde ruta origen desconocida (sistema)
                        this.imgArchivo.Source = Funciones.fobCargarBitmapImage(tmpRegDetalle.Sis_rutorigen_temp);
                    }
                    else
                    {
                        // Viene desde historicos
                        var lcrRuta             = Funciones.fcrGenRutaArchivoRecurso(tmpRegDetalle.Hcl_rutarc_hclr);
                        lcrArchivo              = Funciones.fcrSystemIOPathCombine(tmpRegDetalle.Hcl_nomarc_hclr, lcrRuta, true);
                        this.imgArchivo.Source  = Funciones.fobCargarBitmapImage(lcrArchivo);
                    }
                    #endregion
                }
                else if (tmpRegDetalle.Grc_tiprec_grtr == "RPDF")
                {
                    #region PDF
                    if (!String.IsNullOrWhiteSpace(tmpRegDetalle.Sis_rutorigen_temp))
                    {
                        lcrArchivo = System.IO.Path.Combine(tmpRegDetalle.Sis_rutorigen_temp);
                    }
                    else
                    {
                        // Viene desde historicos
                        var lcrRuta = Funciones.fcrGenRutaArchivoRecurso(tmpRegDetalle.Hcl_rutarc_hclr);
                        lcrArchivo  = Funciones.fcrSystemIOPathCombine(tmpRegDetalle.Hcl_nomarc_hclr, lcrRuta, true);
                    }
                    #endregion
                    this.pdfArchivo.Navigate(lcrArchivo);
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvVistaObjetosCargarArchivoRecurso");
            }
        }
        #endregion
        #region fcvVistaObjetosActivarObjetosCaptura: Activar o desactivar los objetos de captura de datos
        /// <summary>
        /// <para>Activar o desactivar los objetos de captura de datos</para>
        /// </summary>
        private void fcvVistaObjetosActivarObjetosCaptura(bool tlgEstado)
        {
            #region Vista campos

            this.txtG1Hcl_gesfec_hcms.IsEnabled = tlgEstado;
            this.txtG1Hcl_geshor_hcms.IsEnabled = tlgEstado;
            this.txtG1Sia_codpfa_prof.IsEnabled = tlgEstado;
            this.txtG1Fcm_codcpr_cpro.IsEnabled = tlgEstado;

            // Botones
            this.cmdBrowProfesional.IsEnabled   = tlgEstado;
            this.cmdG1Fcm_codcpr_cpro.IsEnabled = tlgEstado;
            this.dpkG1Hcl_gesfec_hcms.IsEnabled = tlgEstado;
            this.cmdBuscarArchivo.IsEnabled     = tlgEstado;

            this.cmdAgregar.IsEnabled   = tlgEstado;
            this.cmdNuevo.IsEnabled     = tlgEstado;
            this.cmdGuardar.IsEnabled   = tlgEstado;
            this.cmdConfirmar.IsEnabled = tlgEstado;

            if (tmpRegMaestro != null)
            {
                this.cmdNuevo.IsEnabled = tmpRegMaestro.Sis_estpro_espr == "1" ? true : false;
            }
            #endregion
        }
        #endregion
        #region fcvVistaObjetosActivarModoGestion: Activar o desactivar controles segun el modo gestion
        /// <summary>
        /// Activar o desactivar algunos objetos y botones segun el modo gestion
        /// </summary>
        private void fcvVistaObjetosActivarModoGestion()
        {
            // Cuando se ingresa desde Historias Clinicas
            this.cmdBrowser.Visibility = Visibility.Collapsed;
            this.cmdLimpiar.Visibility = Visibility.Collapsed;
            this.cboG1Grc_tiprec_grtr.Visibility = Visibility.Collapsed;

            if (gcrModoAccion == "GES")
            {
                // Cuando es gestion masiva
                this.cmdBrowser.Visibility = Visibility.Visible;
                this.cmdGuardar.Visibility = Visibility.Collapsed;
                this.cmdLimpiar.Visibility = Visibility.Visible;
                this.cboG1Grc_tiprec_grtr.Visibility = Visibility.Visible;
            }
            if (tmpRegMaestro.Sis_estpro_espr != "1" && !String.IsNullOrWhiteSpace(tmpRegMaestro.Hcl_nroreg_hcms))
            {
                this.cmdBuscarArchivo.Visibility     = Visibility.Collapsed;
                this.dpkG1Hcl_gesfec_hcms.Visibility = Visibility.Collapsed;
                this.cmdNuevo.Visibility             = Visibility.Collapsed;
                this.cmdAgregar.Visibility           = Visibility.Collapsed;
                this.cmdConfirmar.Visibility         = Visibility.Collapsed;
                this.cmdGuardar.Visibility           = Visibility.Collapsed;
                this.cmdLogErrores.Visibility        = Visibility.Collapsed;
            }
        }
        #endregion
        //-------------------------------------------------
        // FUNCIONES AUXILIARES 
        //-------------------------------------------------
        #region fcvAuxReiniciarTemporales: Reiniciar los temporales, vaciar contenidos
        /// <summary>
        /// Reiniciar los temporales, vaciar contenidos
        /// </summary>
        private void fcvAuxReiniciarTemporales()
        {
            tmpRegAdmision  = new ADMModeloAdmadmisiones();
            tmpRegMaestro   = new ModeloHclregordeserms();
            tmpRegDetalle   = new ModeloHclhistarchivos();
            fcvAuxLiberarObjetosGrilla();
            tmpDatosDetalle = new List<ModeloHclhistarchivos>();
        }
        #endregion
        #region fcvAuxLiberarObjetosGrilla: Vaciar objetos de la grilla
        /// <summary>
        /// Vaciar datos y objetos de la grilla liberando los eventos asociados a objetos
        /// </summary>
        private void fcvAuxLiberarObjetosGrilla()
        {
            if (tmpDatosDetalle != null)
            {
                // cuando hay registros en el temporal detalles
                foreach (var lobReg in tmpDatosDetalle)
                {
                    var lobObjeto = lobReg.RefObjeto as ControlOrdRecursoDetalleEdt;

                    if (lobObjeto != null)
                    {
                        lobObjeto.cmdEliminar.Click -= new RoutedEventHandler(fcvEdtObjEliminarRegDetalle);
                        lobObjeto.cmdModificar.Click -= new RoutedEventHandler(fcvEdtObjModificarRegDetalle);

                        this.stkDetalles.Children.Remove(lobObjeto);
                    }
                }
            }
        }
        #endregion
        #region fcvAuxRegistroActivoDesdeVariables: Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables de la vista
        /// </summary>
        public void fcvAuxRegistroActivoDesdeVariables()
        {
            try
            {
                #region Valores Variables
                tmpRegDetalle.Sia_codpfa_prof = this.txtG1Sia_codpfa_prof.Text;
                tmpRegDetalle.Sia_codare_aser = tmpRegAdmision.Sia_codare_aser;
                tmpRegDetalle.Hcl_nomarc_hclr = this.txtG1Hcl_nomarc_hclr.Text;
                tmpRegDetalle.Hcl_rutarc_hclr = this.txtG1Hcl_rutarc_hclr.Text;
                tmpRegDetalle.Sis_rutorigen_temp = this.txtRutaOrigen.Text;
                //tmpRegDetalle.Fcm_codcpr_cpro = this.txtG1Fcm_codcpr_cpro.Text;
                tmpRegDetalle.Adm_secadm_rgad = tmpRegAdmision.Adm_secadm_rgad;
                tmpRegDetalle.Sia_idesec_usua = tmpRegAdmision.Sia_idesec_usua;
                tmpRegDetalle.Grc_tiprec_grtr = gcrTipoRecurso;
                tmpRegDetalle.Sis_estpro_espr = "1";

                var lobG1Hcl_texcon_hclr = fcvRefRichTextBoxEditor("txtG1Hcl_texcon_hclr");
                tmpRegDetalle.Hcl_texcon_hclr = lobG1Hcl_texcon_hclr.Text;

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
        public ModeloHclhistarchivos fobAuxCopiarRegistro(ModeloHclhistarchivos tobRegistro)
        {
            var lobReAux = new ModeloHclhistarchivos();
            try
            {
                #region datos
                lobReAux.RefObjeto       = tobRegistro.RefObjeto;
                lobReAux.Hcl_iderec_hclr = tobRegistro.Hcl_iderec_hclr;
                lobReAux.Hcl_nroreg_hcms = tobRegistro.Hcl_nroreg_hcms;
                lobReAux.Hcl_nroreg_hcev = tobRegistro.Hcl_nroreg_hcev;
                lobReAux.Adm_secadm_rgad = tobRegistro.Adm_secadm_rgad;
                lobReAux.Hcl_nrohis_hicl = tobRegistro.Hcl_nrohis_hicl;
                lobReAux.Sia_idesec_usua = tobRegistro.Sia_idesec_usua;
                lobReAux.Sia_codpfa_prof = tobRegistro.Sia_codpfa_prof;
                lobReAux.Sia_codare_aser = tobRegistro.Sia_codare_aser;
                lobReAux.Grc_codest_gres = tobRegistro.Grc_codest_gres;
                lobReAux.Grc_codesp_grep = tobRegistro.Grc_codesp_grep;
                lobReAux.Grc_tiprec_grtr = tobRegistro.Grc_tiprec_grtr;
                lobReAux.Hcl_extarc_hclr = tobRegistro.Hcl_extarc_hclr;
                lobReAux.Hcl_nomarc_hclr = tobRegistro.Hcl_nomarc_hclr;
                lobReAux.Hcl_rutarc_hclr = tobRegistro.Hcl_rutarc_hclr;
                lobReAux.Hcl_texcon_hclr = tobRegistro.Hcl_texcon_hclr;
                lobReAux.Hcl_texkey_hclr = tobRegistro.Hcl_texkey_hclr;
                lobReAux.Sis_estpro_espr = tobRegistro.Sis_estpro_espr;
                lobReAux.Sis_estpro_espr = tobRegistro.Sis_estpro_espr;
                lobReAux.Sia_nompro_prof = tobRegistro.Sia_nompro_prof;
                lobReAux.Sia_desare_aser = tobRegistro.Sia_desare_aser;
                lobReAux.Sis_rutorigen_temp = tobRegistro.Sis_rutorigen_temp;
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
        /// <para>Actualizar en temporal maestro detalles el registro modificado en pantalla</para>
        /// <para>tmpRegDetalle: es el registro de gestion temporal activo</para>
        /// </summary>
        public void fcvAuxActualizarEnMaestroTemporal()
        {
            try
            {
                var lobReAux = tmpDatosDetalle.FirstOrDefault(x => x.Hcl_iderec_hclr == tmpRegDetalle.Hcl_iderec_hclr);
                if (lobReAux != null)
                {
                    #region datos
                    tmpRegDetalle.RefObjeto = lobReAux.RefObjeto; // Referenciar en temporal

                    lobReAux.Hcl_iderec_hclr = tmpRegDetalle.Hcl_iderec_hclr;
                    lobReAux.Hcl_nroreg_hcms = tmpRegDetalle.Hcl_nroreg_hcms;
                    lobReAux.Hcl_nroreg_hcev = tmpRegDetalle.Hcl_nroreg_hcev;
                    lobReAux.Adm_secadm_rgad = tmpRegDetalle.Adm_secadm_rgad;
                    lobReAux.Hcl_nrohis_hicl = tmpRegDetalle.Hcl_nrohis_hicl;
                    lobReAux.Sia_idesec_usua = tmpRegDetalle.Sia_idesec_usua;
                    lobReAux.Sia_codpfa_prof = tmpRegDetalle.Sia_codpfa_prof;
                    lobReAux.Sia_codare_aser = tmpRegDetalle.Sia_codare_aser;
                    lobReAux.Grc_codest_gres = tmpRegDetalle.Grc_codest_gres;
                    lobReAux.Grc_codesp_grep = tmpRegDetalle.Grc_codesp_grep;
                    lobReAux.Grc_tiprec_grtr = tmpRegDetalle.Grc_tiprec_grtr;
                    lobReAux.Hcl_extarc_hclr = tmpRegDetalle.Hcl_extarc_hclr;
                    lobReAux.Hcl_nomarc_hclr = tmpRegDetalle.Hcl_nomarc_hclr;
                    lobReAux.Hcl_rutarc_hclr = tmpRegDetalle.Hcl_rutarc_hclr;
                    lobReAux.Hcl_texcon_hclr = tmpRegDetalle.Hcl_texcon_hclr;
                    lobReAux.Hcl_texkey_hclr = tmpRegDetalle.Hcl_texkey_hclr;
                    lobReAux.Sis_estpro_espr = tmpRegDetalle.Sis_estpro_espr;
                    lobReAux.Sis_estpro_espr = tmpRegDetalle.Sis_estpro_espr;
                    lobReAux.Sia_nompro_prof = tmpRegDetalle.Sia_nompro_prof;
                    lobReAux.Sia_desare_aser = tmpRegDetalle.Sia_desare_aser;
                    lobReAux.Sis_rutorigen_temp = tmpRegDetalle.Sis_rutorigen_temp;
                    lobReAux.Sis_estado_imaen = tmpRegDetalle.Sis_estado_imaen;
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fobAuxActualizarEnMaestroTemporal");
            }
        }
        #endregion
        #region fcvAuxActivarControlVistaRecurso: Activa control para vista preliminar segun tipo recurso
        /// <summary>
        /// <para>Activa control para vista preliminar segun tipo recurso</para>
        /// <para>que se este gestionando</para>
        /// </summary>
        private void fcvAuxActivarControlVistaRecurso(String tcrTipoRecurso)
        {
            this.imgArchivo.Visibility = Visibility.Collapsed;
            this.pdfArchivo.Visibility = Visibility.Collapsed;

            if (tcrTipoRecurso == "RIMG") // Imagenes
            {
                // Activar control para mostrar imagen
                this.imgArchivo.Visibility = Visibility.Visible;
            }
            else if (tcrTipoRecurso == "RVID") // Archivos de video
            {
                //Activar control
            }
            else if (tcrTipoRecurso == "RPDF") // Archivos PDF
            {
                //Activar visor pdf
                this.pdfArchivo.Visibility = Visibility.Visible;
            }
            else if (tcrTipoRecurso == "RDOC") // Archivos Word
            {
                //Activar visor Word
            }
            else if (tcrTipoRecurso == "RXLS") // Archivos Excel
            {
                //Activar visor Excel
            }
        }
        #endregion
        //-------------------------------------------------
        // Actualizar objetos en grilla - Mostrar en la vista
        //-------------------------------------------------
        #region fcvObjetosGridDatosBasicos: Enlazar Procedimientos al objeto y modo vista
        /// <summary>
        /// <para>Enlazar Procedimientos al objeto y modo vista del registro en la grilla</para>
        /// </summary>
        public void fcvObjetosGridDatosBasicos(ref ControlOrdRecursoDetalleEdt tobDetalle, ModeloHclhistarchivos tobRegistro)
        {
            if (tobDetalle != null && tobRegistro != null)
            {
                tobDetalle.cmdEliminar.Click += new RoutedEventHandler(fcvEdtObjEliminarRegDetalle);
                tobDetalle.cmdModificar.Click += new RoutedEventHandler(fcvEdtObjModificarRegDetalle);

                // Datos requeridos
                tobDetalle.IdRegistro               = tobRegistro.Hcl_iderec_hclr;
                tobDetalle.IdR1Registro             = tobRegistro.Hcl_nroreg_hcms;
                tobDetalle.cmdEliminar.Visibility   = tobRegistro.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                tobDetalle.imgEstado.Visibility     = tobRegistro.Sis_estpro_espr == "1" ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        #endregion
        #region flgObjetosGridValoresRegistro: Mostrar datos del registro en objeto detalles
        /// <summary>
        /// <para>Mostrar datos del registro en objeto detalles</para>
        /// </summary>
        public bool flgObjetosGridValoresRegistro(ref ControlOrdRecursoDetalleEdt tobDetalle, ModeloHclhistarchivos tobRegistro)
        {
            var llgReturn = false;
            if (tobDetalle != null && tobRegistro != null)
            {
                llgReturn = true;

                tobDetalle.txtObservacion.Text = tobRegistro.Hcl_texcon_hclr;

                if (tobRegistro.Grc_tiprec_grtr != "RIMG")
                {
                    tobDetalle.imgArchivo.Source = fobObjetosGridImageTipoRegistro(tobRegistro.Grc_tiprec_grtr);
                }
                else
                {
                    // Cargar vista del archivo imagen
                    if (!String.IsNullOrWhiteSpace(tobRegistro.Sis_rutorigen_temp))
                    {
                        // desde ruta origen desconocida (sistema)
                        tobDetalle.imgArchivo.Source = Funciones.fobCargarBitmapImage(tobRegistro.Sis_rutorigen_temp);
                    }
                    else
                    {
                        // Viene desde historicos
                        var lcrRuta     = Funciones.fcrGenRutaArchivoRecurso(tobRegistro.Hcl_rutarc_hclr);
                        var lcrArchivo  = Funciones.fcrSystemIOPathCombine(tobRegistro.Hcl_nomarc_hclr, lcrRuta, false);

                        tobDetalle.imgArchivo.Source = Funciones.fobCargarBitmapImage(lcrArchivo);
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        #region fobObjetosGridImageTipoRegistro: Mostrar imagen segun tipo recurso
        /// <summary>
        /// <para>Mostrar imagen segun tipo recurso</para>
        /// </summary>
        public BitmapImage fobObjetosGridImageTipoRegistro(String tcrTipoRecurso)
        {
            BitmapImage lobgReturn = null;
            var lcrUri = "/GestorReportes;component/Imagenes/";
            var lcrImagen = "Edt_edt_xcap_documento.png";

            if (tcrTipoRecurso == "RPDF")
            {
                lcrImagen = "Edt_edt_pdf2.png";
            }
            else if (tcrTipoRecurso == "RIMG")
            {
                lcrImagen = "Edt_controles_imagensimple.png";
            }
            else if (tcrTipoRecurso == "RDOC")
            {
                lcrImagen = "Edt_edt_xcap_documento.png";
            }
            else if (tcrTipoRecurso == "RXLS")
            {
                lcrImagen = "Edt_edt_excel.png";
            }
            else if (tcrTipoRecurso == "RHL7")
            {
                lcrImagen = "Edt_edt_xcap_documento.png";
            }
            else if (tcrTipoRecurso == "RXML")
            {
                lcrImagen = "Edt_edt_xcap_documento.png";
            }
            else if (tcrTipoRecurso == "RVID")
            {
                lcrImagen = "Edt_edt_xcap_documento.png";
            }
            lobgReturn = new BitmapImage(new Uri(lcrUri + lcrImagen, UriKind.RelativeOrAbsolute));
            return lobgReturn;
        }
        #endregion
        #region fcvObjetosGridCargarGrillaRecursos: Carga registros en vista grilla detalles
        /// <summary>
        /// <para>Carga vista grilla de todos los registros detalles que vienen de la tabla Hclhistarchivos</para>
        /// </summary>
        public void fcvObjetosGridCargarGrillaRecursos()
        {
            if (tmpDatosDetalle != null)
            {
                this.stkDetalles.Children.Clear();

                foreach (var lobReg in tmpDatosDetalle)
                {
                    // Configuracion del registro 
                    var lobDetalle = new ControlOrdRecursoDetalleEdt();

                    lobReg.RefObjeto = lobDetalle;

                    fcvObjetosGridDatosBasicos(ref lobDetalle, lobReg);
                    flgObjetosGridValoresRegistro(ref lobDetalle, lobReg);

                    this.stkDetalles.Children.Add(lobDetalle);
                }
            }
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
        #region fcvValidacionTextoRt: Validacion campos Editor
        /// <summary>
        /// <para>Validacion campos asociada a campos tipo editor</para>
        /// </summary>
        private void fcvValidacionTextoRt(object sender, TextChangedEventArgs e)
        {
            if (!llgObjetosCargados) { return; }

            llgModoEdicionKey = true;
            var lobTextBox = sender as RichTextBox;
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

            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_idesec_usua"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_gesfec_hcms"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_geshor_hcms"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Sia_codpfa_prof"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Fcm_codcpr_cpro"))) { lnuCont1++; }
            if (!String.IsNullOrWhiteSpace(fcrValidacion("txtG1Hcl_texcon_hclr"))) { lnuCont2++; }

            this.cmdAgregar.IsEnabled = lnuCont1 + lnuCont2 > 0 ? false : true;
            this.cmdGuardar.IsEnabled = lnuCont1 > 0 ? false : tmpDatosDetalle.Count != 0 && llgMaestro == true ? true : false;
            this.cmdConfirmar.IsEnabled = lnuCont1 > 0 ? false : tmpDatosDetalle.Count != 0 && llgMaestro == true ? true : false;

            return lnuCont1 == 0 ? true : false;
        }
        #endregion
        #region fcrValidacion: funciones de validacion campos 
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        /// </summary>
        public String fcrValidacion(String tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "txtG1Sia_idesec_usua":
                        #region Validacion
                        lcrNombreCampo = "Identificacion del paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";

                        // Para gesion masiva de registros
                        if (gcrModoAccion == "GES")
                        {
                            if (string.IsNullOrWhiteSpace(this.txtG1Sia_idesec_usua.Text))
                            {
                                lcrValorReturn = "Identificacion del paciente: Es requerido";
                            }
                            else
                            {
                                lcrValorReturn = fcrCargarDatosBasicosPaciente(this.txtG1Sia_idesec_usua.Text);

                                if (String.IsNullOrWhiteSpace(lcrValorReturn) == true)
                                {
                                    flgCargarDatosAdmision(this.txtG1Sia_idesec_usua.Text);
                                    fcvCargarDatosGenRegHclregordeserms();
                                    fcvEdicionIniciarVistaObjetosZonas("1");
                                }
                            }
                        }
                        break;
                        #endregion

                    case "txtG1Sia_codpfa_prof":
                        #region Validacion
                        lcrNombreCampo = "Profesional que atiende";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (string.IsNullOrWhiteSpace(this.txtG1Sia_codpfa_prof.Text))
                        {
                            lcrValorReturn = "Profesional que atiende: Es requerido";
                        }
                        else
                        {
                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(this.txtG1Sia_codpfa_prof.Text);
                            if (tmp != null && tmp.sia_nompro_prof != null)
                            {
                                this.txtG1Sia_nompro_prof.Text = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = "Profesional que atiende: No existe";
                            }
                        }
                        fcvSetColorValidacion(this.txtG1Sia_codpfa_prof, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Fcm_codcpr_cpro":
                        #region Validacion
                        lcrNombreCampo = "Código centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (string.IsNullOrWhiteSpace(this.txtG1Fcm_codcpr_cpro.Text))
                        {
                            lcrValorReturn = "Código centro producción: Es requerido";
                        }
                        else
                        {
                            var tmp = new EFfcmcenproduccio();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(this.txtG1Fcm_codcpr_cpro.Text);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codcpr_cpro))
                            {
                                this.txtG1Fcm_descpr_cpro.Text = tmp.fcm_descpr_cpro;
                                tmpRegAdmision.Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro;
                                tmpRegDetalle.Sia_codare_aser = String.IsNullOrWhiteSpace(tmpRegDetalle.Sia_codare_aser) ?
                                                                                          tmp.sia_codare_aser : tmpRegDetalle.Sia_codare_aser;
                            }
                            else
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        fcvSetColorValidacion(txtG1Fcm_codcpr_cpro, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Hcl_gesfec_hcms":
                        #region Validacion
                        lcrNombreCampo = "Fecha del servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", txtG1Hcl_gesfec_hcms.Text, "Fecha servicio");
                        fcvSetColorValidacion(txtG1Hcl_gesfec_hcms, lcrValorReturn);
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            txtG1Hcl_gesfec_hcms.BorderBrush = Brushes.White;
                        }
                        break;
                        #endregion

                    case "txtG1Hcl_geshor_hcms":
                        #region Validacion
                        lcrNombreCampo = "Hora servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, txtG1Hcl_geshor_hcms.Text, "12", ":", "Hora servicio");
                        // Cargar el turno segun la hora dada 
                        if (String.IsNullOrWhiteSpace(lcrValorReturn) && llgObjetosCargados == true)
                        {
                            tmpRegMaestro.Hcl_geshor_hcms = Decimal.Parse(Funciones.fcrConvierteHora(this.txtG1Hcl_geshor_hcms.Text, "12", ":", gcrSeparadorDecimal));
                            tmpRegMaestro.Hcl_tiptur_hctu = ModeloHcltiporegturno.fobRegistroHcltiporegturno(tmpRegMaestro.Hcl_geshor_hcms).Hcl_tiptur_hctu;
                        }
                        fcvSetColorValidacion(txtG1Hcl_geshor_hcms, lcrValorReturn);
                        break;
                        #endregion

                    case "txtG1Grc_tiprec_grtr":
                        #region Validacion
                        // aqui la validacion tipo recurso
                        break;
                        #endregion

                    case "txtG1Hcl_texcon_hclr":
                        #region Validacion
                        lcrNombreCampo = "Texto contenido del archivo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B10";
                        var lobG2Hcl_texcon_hclr = fcvRefRichTextBoxEditor("txtG1Hcl_texcon_hclr");

                        if (String.IsNullOrWhiteSpace(lobG2Hcl_texcon_hclr.Text))
                        {
                            lcrValorReturn = "Texto contenido del archivo: Es requerido";
                        }
                        //fcvSetColorValidacionRt(txtG2Hcl_notreg_hcor, lcrValorReturn);
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
        private void fcvSetColorValidacionRt(RichTextBox tobObjeto, String tcrValorReturn)
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
        // Gestion Edicion objetos vista detalles 
        //-------------------------------------------------
        #region fcvEdtObjModificarRegDetalle: Modificar registro detalle
        /// <summary>
        /// <para>Modificar registro detalle</para>
        /// </summary>
        private void fcvEdtObjModificarRegDetalle(object sender, RoutedEventArgs e)
        {
            var lcrIdRegistro = String.Empty;
            var lobBoton    = sender as Button;
            var lobGrid1    = lobBoton.Parent as Grid;
            var lobGrid2    = lobGrid1.Parent as Grid;
            var lobObjeto   = lobGrid2.Parent as ControlOrdRecursoDetalleEdt;
            lcrIdRegistro   = lobObjeto.IdRegistro;

            // cargar registro en vista variables
            var lobReg = tmpDatosDetalle.FirstOrDefault(x => x.Hcl_iderec_hclr == lcrIdRegistro);
            if (lobReg != null)
            {
                tmpRegDetalle = fobAuxCopiarRegistro(lobReg);
                tmpRegDetalle.Sis_estado_imaen = tmpRegDetalle.Sis_estado_imaen != "A" ? "M" : "A";
                fcvVistaObjetosZona2CargarDesdeRegActivo();
            }

        }
        #endregion
        #region fcvEdtObjEliminarRegDetalle: Eliminar un registro detalle
        /// <summary>
        /// <para>Eliminar un registro detalle</para>
        /// </summary>
        private void fcvEdtObjEliminarRegDetalle(object sender, RoutedEventArgs e)
        {
            var lcrIdRegistro = String.Empty;
            var lobBoton = sender as Button;
            var lobGrid1 = lobBoton.Parent as Grid;
            var lobGrid2 = lobGrid1.Parent as Grid;
            var lobObjeto = lobGrid2.Parent as ControlOrdRecursoDetalleEdt;
            lcrIdRegistro = lobObjeto.IdRegistro;

            if (flgEdtObjValidSiEliminarReg(lcrIdRegistro))
            {
                if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    fcvEdtObjEliminarRegistroRelacion(lcrIdRegistro);
                    // Verificar si estava activo en la vista edicion
                    if (tmpRegDetalle.Hcl_iderec_hclr == lobObjeto.IdRegistro)
                    {
                        fcvEdicionNuevoRegistroDetalles();
                    }
                    flgValidacion();
                }
            }
        }
        #endregion
        #region fcvEdtObjEliminarRegistroRelacion: Eliminar registro dado el codigo unico en temporal
        /// <summary>
        ///  Eliminar registro dado el codigo unico en temporal
        /// </summary>
        private void fcvEdtObjEliminarRegistroRelacion(String tcrIdCodigoUnico)
        {
            ControlOrdRecursoDetalleEdt lobObjeto = null;
            var lobReg = tmpDatosDetalle.FirstOrDefault(x => x.Hcl_iderec_hclr == tcrIdCodigoUnico);

            if (lobReg != null)
            {
                lobObjeto = lobReg.RefObjeto as ControlOrdRecursoDetalleEdt;
                // Es un registro que no esta en base de datos
                tmpDatosDetalle.Remove(lobReg);
            }
            if (lobObjeto != null)
            {
                // quitar de la vista
                this.stkDetalles.Children.Remove(lobObjeto);
            }
        }
        #endregion
        #region flgEdtObjValidSiEliminarReg: Validar si el registro se puede eliminar
        /// <summary>
        /// Validar si el registro se puede eliminar desde esta vista
        /// </summary>
        private bool flgEdtObjValidSiEliminarReg(String tcrIdCodigoUnico)
        {
            var llgReturn = true;
            var lobReg = tmpDatosDetalle.FirstOrDefault(x => x.Hcl_iderec_hclr == tcrIdCodigoUnico);

            if (lobReg != null)
            {
                // Cuando es diferente de adicionar, es porque se inicio el modulo desde HC 
                // y entonces el recurso esta en uso en la vista hitorial Clinico
                if (lobReg.Sis_estado_imaen != "A")
                {
                    llgReturn = false;
                    MessageBox.Show("El archivo esta en uso en vista Historias clinicas," + "\r\n" + " no se puede eliminar desde pantalla.");
                }
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Referencias a objetos editores
        //-------------------------------------------------
        #region fcvRefRichTextBoxEditor: Referencia a objetos editor de texto
        /// <summary>
        /// <para>Referencia a objetos editor de texto</para>
        /// </summary>
        private TextRange fcvRefRichTextBoxEditor(String tcrNombreObjeto)
        {
            TextRange lobTextRange = null;
            lobTextRange = new TextRange(txtG1Hcl_texcon_hclr.Document.ContentStart, txtG1Hcl_texcon_hclr.Document.ContentEnd);

            return lobTextRange;
        }
        #endregion
        #region fcvSetRichTextBoxEditor: Configurar objetos editor de texto
        /// <summary>
        /// <para>Configurar objetos editor de texto</para>
        /// </summary>
        private void fcvSetRichTextBoxEditor()
        {
            // Configuracion objetos editores
            this.txtG1Hcl_texcon_hclr.SpellCheck.IsEnabled = true; // Corrector de ortografia
            this.txtG1Hcl_texcon_hclr.Language = System.Windows.Markup.XmlLanguage.GetLanguage("es-US");
            this.txtG1Hcl_texcon_hclr.Document.LineHeight = 3;
        }
        #endregion
        //-------------------------------------------------
        // fcvclinicaGenerarActividad: Registro de actividad en Historial clinico
        //-------------------------------------------------
        #region fcvHclinicaGenerarActividad: Generar registro para atencion en historia clinica
        /// <summary>
        /// <para>Generar registro en historial clinico</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipoRegistro: "RDOC" = Documento Word "RIMG" = Imagenes (jpg png bm) y otros</para>
        /// </summary>
        public String fcvHclinicaGenerarActividad(String tcrTipoRecurso)
        {
            var lcrCodgioRegHist = String.Empty;
            try
            {
                var lobRegEx = HCLValidarCodigo.fobRegBuscarHcltiporegserms(tcrTipoRecurso);
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(lobRegEx.hcl_codreg_hcca);

                if (!String.IsNullOrWhiteSpace(lobReg.grp_idepla_grpl))
                {
                    // Generar registro de actividad en historia clinica
                    var loPlant         = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);
                    var lobHist         = new HclModeloHistorialEventos();
                    var lcrEvento       = GRCValidarCodigo.fobRegBuscarGrctiporecursos(tcrTipoRecurso).grc_titulo_grtr;
                    var ldaFechaEvento  = Funciones.fdaConvertFecha("DMY", "/", this.txtG1Hcl_gesfec_hcms.Text);
                    var ldaHoraEvento   = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));

                    #region Datos del registro
                    lobHist.Hcl_secreg_hcev = 1;
                    lobHist.Hcl_nrohis_hicl = tmpRegAdmision.Hcl_nrohis_hicl;
                    lobHist.Adm_secadm_rgad = tmpRegAdmision.Adm_secadm_rgad;
                    lobHist.Cit_codasi_mcit = tmpRegAdmision.Cit_codasi_mcit;
                    lobHist.Fcm_codcpr_cpro = tmpRegAdmision.Fcm_codcpr_cpro;
                    lobHist.Sia_idesec_usua = tmpRegAdmision.Sia_idesec_usua;
                    lobHist.Sia_tipide_tide = tmpRegAdmision.Sia_tipide_tide;
                    lobHist.Sia_nroide_usua = tmpRegAdmision.Sia_nroide_usua;
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
        public String fcrGenerarLlaveDetalles(ModeloHclhistarchivos tobRegistro)
        {
            var lcrllave1 = tobRegistro.Hcl_iderec_hclr + " " + tobRegistro.Hcl_texcon_hclr;

            return lcrllave1;
        }
        #endregion
        //-------------------------------------------------
        //  Metodos Explorar windowsw Buscar recurso
        //-------------------------------------------------
        #region fcvExplorerGetObjRecursoImportar: Abrir el explorador de windows para buscar un recurso
        /// <summary>
        /// <para>Abrir el explorador de windows para buscar un recurso</para>
        /// </summary>
        private void fcvExplorerGetObjRecursoImportar(object sender, RoutedEventArgs e)
        {

            try
            {
                gobPropRecurso = fobExplorerValoresParametrosRecurso();
                gobArchivoRecurso = Funciones.fobBuscarArchivoRecurso(gobPropRecurso.TituloBrowser, gobPropRecurso.Extencion, gobPropRecurso.Filtro);
                if (gobArchivoRecurso != null)
                {
                    // Mostrar datos en vista
                    //this.txtFirmaTipo.Text = "IMAGEN";
                    this.txtRutaOrigen.Text          = gobArchivoRecurso.RutayArchivo;
                    this.txtG1Hcl_nomarc_hclr.Text   = String.IsNullOrWhiteSpace(this.txtG1Hcl_nomarc_hclr.Text) ? "IDARCHIVO." + 
                                                                                    gobArchivoRecurso.Extencion : this.txtG1Hcl_nomarc_hclr.Text;
                    this.txtG1Hcl_rutarc_hclr.Text   = gobPropRecurso.RutaDestino;  //Ruta destino
                    tmpRegDetalle.Grc_tiprec_grtr    = gcrTipoRecurso;
                    tmpRegDetalle.Sis_rutorigen_temp = gobArchivoRecurso.RutayArchivo;
                    tmpRegDetalle.Hcl_extarc_hclr    = gobArchivoRecurso.Extencion;
                    // Mostrar la imagen o el archivo de recurso
                    fcvVistaObjetosCargarArchivoRecurso();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Error Metodo: fcvGetObjImagenImportar");
            }
        }
        #endregion
        #region ExplorerPropRecursos: Parametros explorador de recursos en windows
        /// <summary>
        /// <para>Parametros o propiedades tipo recurso activo para configurar explorador de windows</para>
        /// </summary>
        public class ExplorerPropRecursos
        {
            public ExplorerPropRecursos() { }

            public String Titulo { get; set; }
            public String TituloBrowser { get; set; }
            public String Extencion { get; set; }
            public String Filtro { get; set; }
            public String RutaDestino { get; set; }
        }
        #endregion
        #region fobExplorerValoresParametrosRecurso: Cargar los parametros utilitarios del tipo recurso
        /// <summary>
        /// <para>Cargar los parametros utilitarios del tipo recurso</para>
        /// </summary>
        public ExplorerPropRecursos fobExplorerValoresParametrosRecurso()
        {
            var lobParametros = new ExplorerPropRecursos();
            try
            {
                var lobRegEx = HCLValidarCodigo.fobRegBuscarHcltiporegserms(gcrTipoRecurso);
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(lobRegEx.hcl_codreg_hcca);
                // Cargar los parametros 
                lobParametros.Titulo = lobRegEx.hcl_desreg_hctr;
                lobParametros.RutaDestino = lobReg.hcl_rutarc_hcca;

                switch (gcrTipoRecurso)
                {
                    case "RIMG":
                        lobParametros.TituloBrowser = "Buscar imagen...";
                        lobParametros.Extencion = ".jpg";
                        lobParametros.Filtro = "Buscar imagenes (*.bmp, *.png, *.jpg, *.gif)|*.bmp;*.png;*.jpg;*.gif";
                        break;

                    case "RPDF":
                        lobParametros.TituloBrowser = "Buscar archivos PDF...";
                        lobParametros.Extencion = ".pdf";
                        lobParametros.Filtro = "Buscar PDF (*.pdf)|*.pdf";
                        break;

                    case "RVID":
                        lobParametros.TituloBrowser = "Buscar archivos Video...";
                        lobParametros.Extencion = ".mov";
                        lobParametros.Filtro = "Buscar videos (*.mp4, *.mkv, *.avi, *.dvd, *.wmv, *.mov, *.flv)|*.mp4;*.mkv;*.avi;*.dvd;*.wmv;*.mov;*.flv";
                        break;

                    case "RDOC":
                        lobParametros.TituloBrowser = "Buscar Documento Word...";
                        lobParametros.Extencion = ".doc";
                        lobParametros.Filtro = "Buscar documentos (*.doc, *.docx)|*.doc;*.docx";
                        break;

                    case "RXLS":
                        lobParametros.TituloBrowser = "Buscar Hoja de Excel...";
                        lobParametros.Extencion = ".xls";
                        lobParametros.Filtro = "Buscar Hoja (*.xls, *.xlsx)|*.xls;*.xlsx";
                        break;
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvHclinicaGenerarActividad");
            }
            return lobParametros;
        }
        #endregion
    }
}
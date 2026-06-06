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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Sistema.Utilidades;
using Sistema.Modelo;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_ControlOrdServicios.xaml
    /// </summary>
    public partial class ControlOrdServicios : UserControl
    {
        public Aplicacion oApp = Aplicacion.Instancia();
        public ModeloHclregordeserms tmpRegUsuario = null;
        public List<ModeloHclregordeserde> tmpdetalles = null;
        public List<ModeloHclregnotasmedi> tmpdetamedi = null;
        public List<ModeloHclhistarchivos> tmpdetaarch = null;
        public List<Utilidades.ClassRegistroVista> tmpRegistro = new List<Utilidades.ClassRegistroVista>();
       
        public String gcrTipoRegistro   = "SERV";
        public String gcrCodigoAdmision = String.Empty;
        public ControlOrdServicios()
        {
            InitializeComponent();
        }
        public String gcrCodigoUnico { get; set; }
        public String LlaveBusqueda { get; set; }
        public int IntRegistroServicio { get; set; }
        //------------------------------------------------------------
        // GESTION VISTA
        //------------------------------------------------------------
        #region fcvActivarVistaDetalles: Desplegar o colapsar los detalles
        /// <summary>
        /// <para>Desplegar o colapsar los detalles</para>
        /// </summary>
        private void fcvActivarVistaDetalles(object sender, RoutedEventArgs e)
        {
            var lcrUri = "/GestorReportes;component/Imagenes/";
            if (this.grdDetalles.Visibility == Visibility.Visible)
            {
                this.grdDetalles.Visibility = Visibility.Collapsed;
                this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer3.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                this.grdDetalles.Visibility = Visibility.Visible;
                this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer2.png", UriKind.RelativeOrAbsolute));
            }
        }
        #endregion
        #region fcvCargarVista: Generar la vista segun el parametro Registro Tabla tipo uno
        /// <summary>
        /// <para>Generar la vista segun el parametro Registro Tabla tipo uno</para>
        /// </summary>
        public void fcvCargarVista(String tcrCodigoUnico)
        {
            if (!String.IsNullOrWhiteSpace(tcrCodigoUnico))
            {
                gcrCodigoUnico = tcrCodigoUnico;
                var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx("NA",tcrCodigoUnico,"");
                if (lobReg.Count == 0) { return; }

                tmpRegUsuario       = lobReg.FirstOrDefault();
                gcrTipoRegistro     = tmpRegUsuario.Hcl_tipreg_hctr;
                gcrCodigoAdmision   = tmpRegUsuario.Adm_secadm_rgad;
                fcvCargarVistaObjetos();
                fcvCargarVistaDetalles(tcrCodigoUnico);
            }
        }
        #endregion
        #region fcvCargarVistaObjetos: Carga los datos del registro en la vista de objetos
        /// <summary>
        /// <para>Carga los datos del registro en la vista de objetos</para>
        /// </summary>
        public void fcvCargarVistaObjetos()
        {
            if (tmpRegUsuario != null)
            {
                var lcrUri = "/GestorReportes;component/Imagenes/";
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                // Datos del registro 
                this.txtG1Hcl_desreg_hctr.Text = tmpRegUsuario.Hcl_desreg_hctr;
                this.txtG1Hcl_nroreg_hcms.Text = tmpRegUsuario.Hcl_nroreg_hcms;
                this.txtG1Hcl_gesfec_hcms.Text = tmpRegUsuario.Hcl_gesfec_hcms.ToShortDateString();
                this.txtG1Hcl_geshor_hcms.Text = Funciones.fcrConvierteHora(tmpRegUsuario.Hcl_geshor_hcms.ToString(), "24", lcrSeparadorDecimal, ":");
                this.txtG1Sia_codpfa_prof.Text = tmpRegUsuario.Sia_codpfa_prof;
                this.txtG1Sia_nompro_prof.Text = tmpRegUsuario.Sia_nompro_prof;
                this.txtG1Sia_codare_aser.Text = tmpRegUsuario.Sia_codare_aser;
                this.txtG1Sia_desare_aser.Text = tmpRegUsuario.Sia_desare_aser;
                this.txtG1Sis_despro_espr.Text = tmpRegUsuario.Sis_despro_espr;

               //this.grdEncabezado.Visibility = tmpRegUsuario.Hcl_tipreg_hctr != "SERV" ? Visibility.Collapsed : Visibility.Visible;
                this.grdHcEncabezado.Visibility = tmpRegUsuario.Hcl_tipreg_hctr != "HCON" ? Visibility.Collapsed : Visibility.Visible;
                this.cmdImprimir.IsEnabled = tmpRegUsuario.Sis_estpro_espr != "1" ? true : false;

                LlaveBusqueda = fcrGenerarLlaveMs(tmpRegUsuario).ToLower();

                if (tmpRegUsuario.Sis_estpro_espr == "2") // confirmado 
                {
                    this.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_confirmado.png", UriKind.RelativeOrAbsolute));
                }
                else if (tmpRegUsuario.Sis_estpro_espr == "3") // Anulado
                {
                    this.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_anulado.png", UriKind.RelativeOrAbsolute));
                }
            }
        }
        #endregion
        #region fcvLimpiarVista: Limiar vista de objetos
        /// <summary>
        /// <para>Limiar vista de objetos</para>
        /// </summary>
        public void fcvLimpiarVista()
        {
            if (tmpRegUsuario != null)
            {
                // Datos del registro
                this.txtG1Hcl_desreg_hctr.Text = String.Empty;
                this.txtG1Hcl_nroreg_hcms.Text = String.Empty;
                this.txtG1Hcl_gesfec_hcms.Text = String.Empty;
                this.txtG1Hcl_geshor_hcms.Text = String.Empty;
                this.txtG1Sia_codpfa_prof.Text = String.Empty;
                this.txtG1Sia_nompro_prof.Text = String.Empty;
                this.txtG1Sia_codare_aser.Text = String.Empty;
                this.txtG1Sia_desare_aser.Text = String.Empty;
                this.txtG1Sis_despro_espr.Text = String.Empty;
                LlaveBusqueda = String.Empty;
            }
        }
        #endregion
        //------------------------------------------------------------
        // CARGAR REGISTROS DETALLES
        //------------------------------------------------------------
        #region fcvCargarVistaDetalles: Cargar la vista detalles servicios segun el Codigo solicitud R1
        /// <summary>
        /// <para>Cargar la vista detalles servicios segun el Codigo solicitud R1</para>
        /// </summary>
        public void fcvCargarVistaDetalles(String tcrCodigoUnico)
        {
            if (!String.IsNullOrWhiteSpace(tcrCodigoUnico))
            {
                if (gcrTipoRegistro == "SERV" || gcrTipoRegistro == "FMED")
                {
                    var lobDetall = ModeloHclregordeserde.flsListaHclregordeserde("R1", tcrCodigoUnico);
                    if (lobDetall.Count == 0) { return; }

                    tmpdetalles = lobDetall;
                    fcvCargarVistaObjetosDetallServicios();
                }
                else if (gcrTipoRegistro == "HCON")
                {
                    var lobDetall = ModeloHclregordeserde.flsListaHclregordeserde("R1", tcrCodigoUnico);
                    if (lobDetall.Count == 0) { return; }

                    tmpdetalles = lobDetall;
                    fcvCargarVistaObjetosDetallHojaConsumo();

                }
                else if (gcrTipoRegistro == "EVOL" || gcrTipoRegistro == "NENF")
                {
                    var lobDetall = ModeloHclregnotasmedi.flsListaHclregnotasmedi("R1", tcrCodigoUnico);
                    if (lobDetall.Count == 0) { return; }

                    tmpdetamedi = lobDetall;
                    fcvCargarVistaObjetosDetallEvolucion();
                }
                else if (gcrTipoRegistro == "RIMG" || gcrTipoRegistro == "RPDF" || gcrTipoRegistro == "RVID" ||
                         gcrTipoRegistro == "RDOC" || gcrTipoRegistro == "RXLS" || gcrTipoRegistro == "RHL7")
                {
                    var lobDetall = ModeloHclhistarchivos.flsListaHclhistarchivos("R1", tcrCodigoUnico);
                    if (lobDetall.Count == 0) { return; }

                    tmpdetaarch = lobDetall;
                    fcvCargarVistaObjetosDetallRecursos(tcrCodigoUnico);
                }
            }
        }
        #endregion
        #region fcvCargarVistaObjetosDetallRecursos: Carga recursos externos
        /// <summary>
        /// <para>Carga recursos externos tales como: Imagenes Videos PDF Historias clinicas en HL7 y otros</para>
        /// </summary>
        public void fcvCargarVistaObjetosDetallRecursos(String tcrCodigoR1)
        {
            if (tmpdetaarch != null)
            {
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                var lobTmpRegMs = ModeloHclregordeserms.fobRegistroHclregordeserms(tcrCodigoR1);

                this.stkDetalles.Children.Clear();
                foreach (var lobReg in tmpdetaarch)
                {
                    // Datos de la vista
                    #region Datos de la vista
                    var lobDetalle = new ControlOrdRecursoDetalle();
                    lobDetalle.cmdEliminar.Click    += new RoutedEventHandler(fcvEliminarRegRecurso);
                    lobDetalle.cmdVerRegistro.Click += new RoutedEventHandler(fcvVerRegistroRecurso);

                    lobDetalle.cmdEliminar.Visibility   = lobReg.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                    lobDetalle.imgEstado.Visibility     = lobReg.Sis_estpro_espr == "1" ? Visibility.Collapsed : Visibility.Visible;

                    lobDetalle.IdRegistro           = lobReg.Hcl_iderec_hclr;
                    lobDetalle.IdR1Registro         = lobReg.Hcl_nroreg_hcms;
                    lobDetalle.txtObservacion.Text  = lobReg.Hcl_texcon_hclr;

                    fcvCargarVistaArchivoRecurso(ref lobDetalle, lobReg);

                    this.stkDetalles.Children.Add(lobDetalle);
                    LlaveBusqueda += " " + fcrGenerarLlaveRecursos(lobReg, lobTmpRegMs).ToLower();
                    #endregion
                    //  Guardar referencia del objeto en registro temporal general
                    #region Datos del registro en temporal generaL
                    var lobRegVista = new Utilidades.ClassRegistroVista();

                    lobRegVista.LlaveAuxiliar   = "RECURSOS";
                    lobRegVista.RefObjeto       = lobDetalle;
                    lobRegVista.IdRegistro      = lobReg.Hcl_iderec_hclr;
                    lobRegVista.RegEventoHist   = lobReg.Hcl_nroreg_hcev;
                    lobRegVista.NumeroAdmision  = lobReg.Adm_secadm_rgad;
                    lobRegVista.TipoRegistro    = lobReg.Grc_tiprec_grtr;
                    lobRegVista.EstadoRegistro  = lobReg.Sis_estpro_espr;
                    lobRegVista.DatoAuxiliar    = "NA";

                    tmpRegistro.Add(lobRegVista);
                    #endregion
                }
            }
        }
        #endregion
        #region fcvCargarVistaArchivoRecurso: Cargar vista recursos desde registro activo
        /// <summary>
        /// Cargar vista de recursos imagenes videos pdf
        /// </summary>
        public void fcvCargarVistaArchivoRecurso(ref ControlOrdRecursoDetalle tobVistaObjeto,  ModeloHclhistarchivos tobRegistro)
        {
            try
            {
                var lcrRuta = Funciones.fcrGenRutaArchivoRecurso(tobRegistro.Hcl_rutarc_hclr);
                var lcrArchivo = Funciones.fcrSystemIOPathCombine(tobRegistro.Hcl_nomarc_hclr, lcrRuta, true);
                // Mostrar la imagen
                tobVistaObjeto.imgArchivo.Visibility = Visibility.Collapsed;
                tobVistaObjeto.wbrVistaPdf.Visibility = Visibility.Collapsed;

                if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                {
                    lcrArchivo = @"\\" + lcrArchivo;
                }
                if (File.Exists(lcrArchivo))
                {
                    if (tobRegistro.Grc_tiprec_grtr == "RIMG")
                    {
                        // Cargar vista del archivo imagen
                        #region imagenes
                        tobVistaObjeto.imgArchivo.Visibility = Visibility.Visible;
                        tobVistaObjeto.imgArchivo.Source = Funciones.fobCargarBitmapImage(lcrArchivo);
                        #endregion
                    }
                    else if (tobRegistro.Grc_tiprec_grtr == "RPDF")
                    {
                        // Viene desde historicos
                        #region PDF
                        tobVistaObjeto.wbrVistaPdf.Visibility = Visibility.Visible;
                        //tobVistaObjeto.wbrVistaPdf.BringToFront();
                        #endregion
                        tobVistaObjeto.wbrVistaPdf.Navigate(lcrArchivo);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVistaArchivoRecurso");
            }
        }
        #endregion
        #region fcvCargarVistaObjetosDetallEvolucion: Carga registros evolucion medica
        /// <summary>
        /// <para>Carga registros evolucion medica</para>
        /// </summary>
        public void fcvCargarVistaObjetosDetallEvolucion()
        {
            if (tmpdetamedi != null)
            {
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                this.stkDetalles.Children.Clear();
                foreach (var lobReg in tmpdetamedi)
                {
                    var lobDetalle = new ControlDetalleEvolucion();
                    lobDetalle.cmdEliminar.Click += new RoutedEventHandler(fcvEliminarRegEvolucion);
                    lobDetalle.cmdVerRegistro.Click += new RoutedEventHandler(fcvVerRegistroEvolucion);

                    lobDetalle.txtProfesional.Text  = lobReg.Sia_codpfa_prof + " - " + lobReg.Sia_nompro_prof;
                    lobDetalle.txtFecha.Text        = lobReg.Hcl_gesfec_hcnm.ToShortDateString();
                    lobDetalle.txtHora.Text         = Funciones.fcrConvierteHora(lobReg.Hcl_geshor_hcnm.ToString(), "24", lcrSeparadorDecimal, ":"); 
                    lobDetalle.txtObservacion.Text  = lobReg.Hcl_notreg_hcnm;
                    //lobDetalle.txtEspecialidad.Text = "Registro: " + lobReg.Hcl_nroreg_hcnm.Trim();

                    lobDetalle.cmdEliminar.Visibility   = lobReg.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                    lobDetalle.imgEstado.Visibility     = lobReg.Sis_estpro_espr == "1" ? Visibility.Collapsed : Visibility.Visible;

                    lobDetalle.IdRegistro = lobReg.Hcl_nroreg_hcnm;
                    lobDetalle.IdR1Registro = lobReg.Hcl_nroreg_hcms;
                    this.stkDetalles.Children.Add(lobDetalle);
                    LlaveBusqueda += " " + fcrGenerarLlaveEvolucion(lobReg).ToLower();
                }
            }
        }
        #endregion
        #region fcvCargarVistaObjetosDetallServicios: Carga registros en vista detalles
        /// <summary>
        /// <para>Carga registros en vista detalles</para>
        /// </summary>
        public void fcvCargarVistaObjetosDetallServicios()
        {
            if (tmpdetalles != null)
            {
                var lcrAuxTipoRegistro = String.Empty;
                this.stkDetalles.Children.Clear();

                foreach (var lobReg in tmpdetalles)
                {
                    var lobDetalle = new ControlOrdServiciosDetalle();
                    //lobDetalle.cmdEliminar.Click     += new RoutedEventHandler(fcvEliminarRegDetalle);
                    // Datos requeridos
                    lobDetalle.IdRegistro               = lobReg.Hcl_nroreg_hcor;
                    lobDetalle.IdR1Registro             = lobReg.Hcl_nroreg_hcms;
                    //lobDetalle.cmdEliminar.Visibility = lobReg.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                    lobDetalle.cmdEliminar.Visibility   = Visibility.Collapsed;
                    lobDetalle.imgEstado.Visibility     = lobReg.Sis_estpro_espr == "1" ? Visibility.Collapsed : Visibility.Visible;

                    // Titulo del grupo de registros
                    if (lcrAuxTipoRegistro != lobReg.Hcl_tipser_hcor)
                    {
                        var lobTitulo = new ControlOrdServiciosTitulo();
                        lobTitulo.lblTitulo.Text                = lobReg.Hcl_tipser_hcor == "1" ? "MEDICAMENTOS" : "INDICACIONES";
                        lobTitulo.grdTituloDetalle.Visibility   = lobReg.Hcl_tipser_hcor == "1" ? Visibility.Visible : Visibility.Collapsed;
                        this.stkDetalles.Children.Add(lobTitulo);
                    }
                    lcrAuxTipoRegistro = lobReg.Hcl_tipser_hcor;

                    // Medicamentos
                    lobDetalle.txtDetalle.Text = String.Empty;
                    if (lobReg.Hcl_tipser_hcor == "1")
                    {
                        // Cuando es un medicamento desde Vademecum
                        if (lobReg.Hcl_tserax_hcor != null)
                        {
                            if (lobReg.Hcl_tserax_hcor == "1")
                            {
                                // consulta desde vademecum farmacia
                                var lobReAx = FARValidarCodigo.fobRegBuscarFarexpedmedicmdCUM(lobReg.Fcm_coddig_mant);
                                lobDetalle.txtDetalle.Text = lobReAx.far_precom_famd;
                            }
                        }

                        lobDetalle.grdIndicacion.Visibility = Visibility.Collapsed;
                        lobDetalle.txtDetalle.Text          = String.IsNullOrWhiteSpace(lobDetalle.txtDetalle.Text) ?
                                                                        lobReg.Fcm_codser_sips + " - " + lobReg.Fcm_desser_sips : lobDetalle.txtDetalle.Text;
                        lobDetalle.txtCantidad.Text         = lobReg.Hcl_totuni_hcor.ToString();
                        lobDetalle.txtObservacion.Text      = lobReg.Hcl_notreg_hcor;
                        lobDetalle.txtDias.Text             = lobReg.Hcl_termed_hcor == "1" ? "INDEFINIDO" : lobReg.Hcl_nrodia_hcor.ToString();
                    }
                    else
                    { 
                        // Inidicaciones medicas
                        lobDetalle.grdMedicamento.Visibility = Visibility.Collapsed;
                        lobDetalle.txtInidicacion.Text       = lobReg.Hcl_notreg_hcor;
                    }

                    this.stkDetalles.Children.Add(lobDetalle);
                    LlaveBusqueda += " " + fcrGenerarLlaveDetalles(lobReg).ToLower();
                }
            }
        }
        #endregion
        #region fcvCargarVistaObjetosDetallHojaConsumo: Carga registros en vista detalles Hoja consumo
        /// <summary>
        /// <para>Carga registros en vista detalles hoja de consumo servicios o medicamentos aplicados</para>
        /// </summary>
        public void fcvCargarVistaObjetosDetallHojaConsumo()
        {
            if (tmpdetalles != null)
            {
                this.stkDetalles.Children.Clear();
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");

                foreach (var lobReg in tmpdetalles)
                {
                    var lobDetalle = new ControlOrdHojaConsumoDe();
                    //lobDetalle.cmdEliminar.Click += new RoutedEventHandler(fcvEliminarRegDetalle);

                    lobDetalle.txtProfesional.Text  = lobReg.Sia_nompro_prof;
                    lobDetalle.txtFecha.Text        = lobReg.Hcl_gesfec_hcor.ToShortDateString();
                    lobDetalle.txtHora.Text         = Funciones.fcrConvierteHora(lobReg.Hcl_geshor_hcor.ToString(), "24", lcrSeparadorDecimal, ":");
                    lobDetalle.txtCantidad.Text     = lobReg.Hcl_totuni_hcor.ToString();
                    lobDetalle.txtServicio.Text     = lobReg.Fcm_codser_sips;
                    lobDetalle.txtDetalle.Text      = lobReg.Fcm_desser_sips;

                    //lobDetalle.cmdEliminar.Visibility = lobReg.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                    lobDetalle.cmdEliminar.Visibility   = Visibility.Collapsed;
                    lobDetalle.imgEstado.Visibility     = lobReg.Sis_estpro_espr == "1" ? Visibility.Collapsed : Visibility.Visible;

                    lobDetalle.IdRegistro = lobReg.Hcl_nroreg_hcor;
                    lobDetalle.IdR1Registro = lobReg.Hcl_nroreg_hcms;
                    this.stkDetalles.Children.Add(lobDetalle);
                    LlaveBusqueda += " " + fcrGenerarLlaveDetalles(lobReg).ToLower();
                }
            }
        }
        #endregion
        //------------------------------------------------------------
        // GESTION GENERAR LLAVES Y ELIMINAR REGISTROS DETALLE
        //------------------------------------------------------------
        #region fcrGenerarLlaveMs: Generar llave de busquda para el objeto
        /// <summary>
        /// <para>Generar llave de busquda para el objeto</para>
        /// </summary>
        public String fcrGenerarLlaveMs(ModeloHclregordeserms tobRegistro)
        {
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + "  " + tobRegistro.Adm_secadm_rgad + "  " + tobRegistro.Hcl_nroreg_hcms;
            var lcrllave2 = tobRegistro.Hcl_gesfec_hcms.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + "  " + tobRegistro.Sia_desare_aser;

            return lcrllave1 + "  " + lcrllave2 + "  " + lcrllave3;
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
        #region fcvEliminarRegDetalle: Eliminar un registro detalle
        /// <summary>
        /// <para>Eliminar un registro detalle</para>
        /// </summary>
        private void fcvEliminarRegDetalle(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lcrIdRegistro = String.Empty;
                var lobBoton = sender as Button;
                if (gcrTipoRegistro == "HCON")
                {
                    var lobGrid = lobBoton.Parent as Grid;
                    var lobObjeto = lobGrid.Parent as ControlOrdHojaConsumoDe;
                    lcrIdRegistro = lobObjeto.IdRegistro;
                }
                else
                {
                    var lobGrid = lobBoton.Parent as Grid;
                    var lobObjeto = lobGrid.Parent as ControlOrdServiciosDetalle;
                    lcrIdRegistro = lobObjeto.IdRegistro;
                }



                var lobDetall = ModeloHclregordeserde.flsListaHclregordeserde("IG", lcrIdRegistro);

                if (lobDetall.Count != 0 && lobDetall != null)
                {
                    ModeloHclregordeserde.fcvEliminar(lcrIdRegistro);
                    fcvCargarVistaDetalles(gcrCodigoUnico);
                }
            }
        }
        #endregion
        #region fcvEliminarRegEvolucion: Eliminar un registro de evolución
        /// <summary>
        /// <para>Eliminar un registro de evolución</para>
        /// </summary>
        private void fcvEliminarRegEvolucion(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lobBoton = sender as Button;
                var lobGrid1 = lobBoton.Parent as Grid;
                var lobGrid2 = lobGrid1.Parent as Grid;
                var lobObjeto = lobGrid2.Parent as ControlDetalleEvolucion;

                var lobDetall = ModeloHclregnotasmedi.flsListaHclregnotasmedi("IG", lobObjeto.IdRegistro);

                if (lobDetall.Count != 0 && lobDetall != null)
                {
                    ModeloHclregnotasmedi.fcvEliminar(lobObjeto.IdRegistro);
                    fcvCargarVistaDetalles(gcrCodigoUnico);
                }
            }
        }
        #endregion
        #region fcvVerRegistroEvolucion: Ver el registro de evolución
        /// <summary>
        /// <para>Ver el registro de evolución</para>
        /// </summary>
        private void fcvVerRegistroEvolucion(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid1 = lobBoton.Parent as Grid;
            var lobGrid2 = lobGrid1.Parent as Grid;
            var lobObjeto = lobGrid2.Parent as ControlDetalleEvolucion;

            var lobDetall = ModeloHclregnotasmedi.fobRegistroHclregnotasmedi(lobObjeto.IdRegistro);

            if (lobDetall != null)
            {
                var lcrAccion = lobDetall.Sis_estpro_espr != "1" ? "DFL" : "EDT";
                var lobVistaEvol = new SolicitNotasMedicas(lcrAccion, lobDetall.Hcl_tipreg_hcnm, lobObjeto.IdRegistro, lobDetall.Adm_secadm_rgad);
                lobVistaEvol.ShowDialog();

                fcvCargarVistaDetalles(gcrCodigoUnico);
            }
        }
        #endregion
        #region fcrGenerarLlaveEvolucion: Generar llave desde registros detalles
        /// <summary>
        /// <para>Generar llave desde registros detalles</para>
        /// </summary>
        public String fcrGenerarLlaveEvolucion(ModeloHclregnotasmedi tobRegistro)
        {
            var lcrllave1 = tobRegistro.Hcl_gesfec_hcnm.ToShortDateString() + " " + tobRegistro.Hcl_notreg_hcnm + " " +
                            tobRegistro.Sia_nompro_prof;

            return lcrllave1;
        }
        #endregion
        #region fcvEliminarRegRecurso: Eliminar un registro de recurso
        /// <summary>
        /// <para>Eliminar un registro de recurso</para>
        /// </summary>
        private void fcvEliminarRegRecurso(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lobBoton = sender as Button;
                var lobGrid1 = lobBoton.Parent as Grid;
                var lobGrid2 = lobGrid1.Parent as Grid;
                var lobObjeto = lobGrid2.Parent as ControlOrdRecursoDetalle;

                fcvEliminarRegRecurso(lobObjeto.IdRegistro);
            }
        }
        #endregion
        #region fcvEliminarRecursosTodos: Eliminar todos los recursos
        /// <summary>
        /// <para>Eliminar todos los recursos del registro maestro</para>
        /// </summary>
        public void fcvEliminarRecursosTodos()
        {
            foreach (var lobReg in tmpRegistro)
            {
                fcvEliminarRegRecurso(lobReg.IdRegistro);
            }
            tmpRegistro = new List<ClassRegistroVista>();
        }
        #endregion
        #region fcvEliminarRegRecurso: Eliminar un registro de recurso
        /// <summary>
        /// <para>Eliminar un registro de recurso</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrCodigo: Codigo unico del registro archivo en maestro de recursos</para>
        /// </summary>
        public void fcvEliminarRegRecurso(String tcrCodigo)
        {
            var lobDetall = ModeloHclhistarchivos.flsListaHclhistarchivos("IG", tcrCodigo);

            if (lobDetall.Count != 0 && lobDetall != null)
            {
                var lobRegDetalle = lobDetall.FirstOrDefault();

                // Localizar el objeto ControlOrdRecursoDetalle en la vista
                if (flgLiberarRegRecurso(tcrCodigo))
                {
                    var lcrRutaRecurso = Funciones.fcrGenRutaArchivoRecurso(lobRegDetalle.Hcl_rutarc_hclr);
                    var lcrArchivoDestino = Funciones.fcrSystemIOPathCombine(lobRegDetalle.Hcl_nomarc_hclr, lcrRutaRecurso, false).ToLower();

                    // Eliminar fisicamente el archivo
                    if (File.Exists(@lcrArchivoDestino.ToLower()))
                    {
                        File.Delete(@lcrArchivoDestino);
                    }
                    ModeloHclhistarchivos.fcvEliminar(tcrCodigo);
                    fcvCargarVistaDetalles(gcrCodigoUnico);
                }
                else
                {
                    MessageBox.Show("No fue posible eliminar el archivo " + lobRegDetalle.Hcl_nomarc_hclr.ToUpper());
                }
            }
        }
        #endregion
        #region flgLiberarRegRecurso: iberar el objeto registro recurso de la vista
        /// <summary>
        /// <para>Liberar todos los registro recurso de la vista</para>
        /// </summary>
        public void flgLiberarRegRecurso()
        {
            foreach (var lobReg in tmpRegistro)
            {
                flgLiberarRegRecurso(lobReg.IdRegistro);
            }
            tmpRegistro = new List<ClassRegistroVista>();
        }
        #endregion
        #region flgLiberarRegRecurso: Liberar el objeto registro recurso de la vista
        /// <summary>
        /// <para>Liberar el objeto registro recurso de la vista</para>
        /// </summary>
        public bool flgLiberarRegRecurso(String tcrCodigo)
        {
            var llgReturn = false;
            var lobRegVista = tmpRegistro.FirstOrDefault(x => x.IdRegistro == tcrCodigo);

            if (lobRegVista != null)
            {
                var lobRef = lobRegVista.RefObjeto as ControlOrdRecursoDetalle;

                if (lobRef != null)
                {
                    llgReturn = true;

                    lobRef.cmdEliminar.Click -= new RoutedEventHandler(fcvEliminarRegRecurso);
                    lobRef.cmdVerRegistro.Click -= new RoutedEventHandler(fcvVerRegistroRecurso);

                    // controles que pueden tener abierto el archivo
                    lobRef.imgArchivo.Source    = null;
                    lobRef.wbrVistaPdf.Source   = null;
                    this.stkDetalles.Children.Remove(lobRef);
                }
            }
            return llgReturn;
        }
        #endregion
        #region fcvVerRegistroRecurso: Ver el registro de recurso
        /// <summary>
        /// <para>Ver el registro de recurso</para>
        /// </summary>
        private void fcvVerRegistroRecurso(object sender, RoutedEventArgs e)
        {
            var lobBoton = sender as Button;
            var lobGrid1 = lobBoton.Parent as Grid;
            var lobGrid2 = lobGrid1.Parent as Grid;
            var lobObjeto = lobGrid2.Parent as ControlOrdRecursoDetalle;

            var lobDetall = ModeloHclhistarchivos.fobRegistroHclHistarchivos(lobObjeto.IdRegistro);

            if (lobDetall != null)
            {
                var lobRegAdm = HclUtilidades.fobRegAdmisionAuxiliar(gcrCodigoAdmision);
                if (lobRegAdm == null) { return; }

                var lcrAccion = lobDetall.Sis_estpro_espr != "1" ? "DFL" : "EDT";
                var lobVistaRec = new SolicitAddRecursos(lcrAccion, lobDetall.Grc_tiprec_grtr, lobObjeto.IdRegistro, gcrCodigoAdmision);
                lobVistaRec.ShowDialog();

                fcvCargarVistaDetalles(oApp.gcrWinMsCodigoMensaje);
            }
        }
        #endregion
        #region fcrGenerarLlaveRecursos: Generar llave desde registros detalles
        /// <summary>
        /// <para>Generar llave desde registros detalles</para>
        /// </summary>
        public String fcrGenerarLlaveRecursos(ModeloHclhistarchivos tobRegistro,ModeloHclregordeserms tmpRegMs)
        {
            var lcrllave1 = tobRegistro.Hcl_texcon_hclr + " " + tmpRegMs.Sia_nompro_prof;

            return lcrllave1;
        }
        #endregion
    }
}

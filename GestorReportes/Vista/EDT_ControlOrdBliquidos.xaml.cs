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
using Sistema.Utilidades;
using Sistema.Modelo;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_ControlOrdBliquidos.xaml
    /// </summary>
    public partial class ControlOrdBliquidos : UserControl
    {
        public ModeloHclregbliqidoms tmpRegUsuario = null;
        public List<ModeloHclregbliqidode> tmpdetalles = null;
        //public List<ModeloHclregbliqidode> tmpdetamedi = null;
        public String gcrTipoRegistro = "ALIQ";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");

        public ControlOrdBliquidos()
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
            if (this.stkDetalles.Visibility == Visibility.Visible)
            {
                this.stkDetalles.Visibility = Visibility.Collapsed;
                this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer3.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                this.stkDetalles.Visibility = Visibility.Visible;
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
                var lobReg = ModeloHclregbliqidoms.flsListaHclregbliqidomsEx("1", tcrCodigoUnico, "");
                if (lobReg.Count == 0) { return; }

                tmpRegUsuario = lobReg.FirstOrDefault();
                fcvCargarVistaObjetos();
                fcvCargarVistaDetalles(tcrCodigoUnico);
                fcvCargarVistaResumenCierre();
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
                this.txtG1Hcl_nroreg_hcbm.Text = tmpRegUsuario.Hcl_nroreg_hcbm;
                this.txtG1Hcl_destur_hctu.Text = tmpRegUsuario.Hcl_destur_hctu;
                this.txtG1Hcl_gesfec_hcbm.Text = tmpRegUsuario.Hcl_fecape_hcbm.ToShortDateString();
                this.txtG1Hcl_sishor_hcms.Text = Funciones.fcrConvierteHora(tmpRegUsuario.Hcl_sishor_hcbm.ToString(), "24", lcrSeparadorDecimal, ":");
                this.txtG1Sia_codpfa_prof.Text = tmpRegUsuario.Sia_codpfa_prof;
                this.txtG1Sia_nompro_prof.Text = tmpRegUsuario.Sia_nompro_prof;
                this.txtG1Sia_codare_aser.Text = tmpRegUsuario.Sia_codare_aser;
                this.txtG1Sia_desare_aser.Text = tmpRegUsuario.Sia_desare_aser;
                this.txtG1Sis_despro_espr.Text = tmpRegUsuario.Sis_despro_espr;
                this.txtG1Hcl_totape_hcbm.Text = tmpRegUsuario.Hcl_totape_hcbm.ToString();
                this.txtG1Hcl_horini_hcbm.Text = Funciones.fcrConvierteHora(tmpRegUsuario.Hcl_horini_hcbm.ToString(), "24", lcrSeparadorDecimal, ":");
                this.txtG1Hcl_horfin_hcbm.Text = Funciones.fcrConvierteHora(tmpRegUsuario.Hcl_horfin_hcbm.ToString(), "24", lcrSeparadorDecimal, ":");
                this.txtG1Hcl_obsape_hcbm.Text = tmpRegUsuario.Hcl_obsape_hcbm;

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
        #region fcvCargarVistaResumenCierre: Carga los datos resumen del cierre turno
        /// <summary>
        /// <para>Carga los datos resumen del cierre turno</para>
        /// </summary>
        public void fcvCargarVistaResumenCierre()
        {
            if (tmpRegUsuario != null)
            {
                if (tmpRegUsuario.Sis_estpro_espr == "2") // confirmado 
                {
                    var lobResumen = new ControlOrdDetallesBLiquidoResumen();
                    lobResumen.txtFecha.Text = tmpRegUsuario.Hcl_feccie_hcbm.ToShortDateString();
                    lobResumen.txtHora.Text = Funciones.fcrConvierteHora(tmpRegUsuario.Hcl_horcie_hcbm.ToString(), "24", gcrSeparadorDecimal,":");

                    lobResumen.txtTotalIndicado.Text     = tmpRegUsuario.Hcl_totind_hcbm.ToString();
                    lobResumen.txtTotalAdministrado.Text = tmpRegUsuario.Hcl_totadm_hcbm.ToString();
                    lobResumen.txtTotalEliminados.Text   = tmpRegUsuario.Hcl_toteli_hcbm.ToString();
                    lobResumen.txtTotalPendiente.Text    = tmpRegUsuario.Hcl_totpen_hcbm.ToString();
                    lobResumen.txtTotalResultado.Text    = tmpRegUsuario.Hcl_result_hcbm.ToString();
                    lobResumen.txtObservacion.Text       = tmpRegUsuario.Hcl_obscie_hcbm.ToString();

                    this.stkDetalles.Children.Add(lobResumen);
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
                this.txtG1Hcl_nroreg_hcbm.Text = String.Empty;
                this.txtG1Hcl_destur_hctu.Text = String.Empty;
                this.txtG1Hcl_gesfec_hcbm.Text = String.Empty;
                this.txtG1Hcl_sishor_hcms.Text = String.Empty;
                this.txtG1Sia_codpfa_prof.Text = String.Empty;
                this.txtG1Sia_nompro_prof.Text = String.Empty;
                this.txtG1Sia_codare_aser.Text = String.Empty;
                this.txtG1Sia_desare_aser.Text = String.Empty;
                this.txtG1Sis_despro_espr.Text = String.Empty;
                this.txtG1Hcl_totape_hcbm.Text = String.Empty;
                this.txtG1Hcl_horini_hcbm.Text = String.Empty;
                this.txtG1Hcl_horfin_hcbm.Text = String.Empty;
                this.txtG1Hcl_obsape_hcbm.Text = String.Empty;

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
                var lobDetall = ModeloHclregbliqidode.flsListaHclregbliqidode("R1", tcrCodigoUnico);
                if (lobDetall.Count == 0) { return; }

                tmpdetalles = lobDetall;
                fcvCargarVistaObjetosDetalles();
            }
        }
        #endregion
        #region fcvCargarVistaObjetosDetallServicios: Carga registros en vista detalles
        /// <summary>
        /// <para>Carga registros en vista detalles</para>
        /// </summary>
        public void fcvCargarVistaObjetosDetalles()
        {
            if (tmpdetalles != null)
            {
                this.stkDetalles.Children.Clear();
                foreach (var lobReg in tmpdetalles)
                {
                    var lcrUri = "/GestorReportes;component/Imagenes/";
                    var lobDetalle = new ControlOrdDetallesBLiquido();
                    lobDetalle.cmdEliminar.Click += new RoutedEventHandler(fcvEliminarRegDetalle);


                    lobDetalle.txtLiquido.Text      = lobReg.Hcl_desliq_hctl;
                    lobDetalle.txtFecha.Text        = lobReg.Hcl_gesfec_hcbd.ToShortDateString();
                    lobDetalle.txtObservacion.Text  = lobReg.Hcl_notreg_hcbd;
                    lobDetalle.txtViaAdmiElim.Text  = lobReg.Hcl_desvia_hcvl;

                    lobDetalle.cmdEliminar.Visibility = lobReg.Sis_estpro_espr == "1" ? Visibility.Visible : Visibility.Collapsed;
                    lobDetalle.imgEstado.Visibility = lobReg.Sis_estpro_espr == "1" ? Visibility.Collapsed : Visibility.Visible;

                    lobDetalle.IdRegistro = lobReg.Hcl_nroreg_hcbd;
                    lobDetalle.IdR1Registro = lobReg.Hcl_nroreg_hcbm;
                    lobDetalle.TipoRegistro = lobReg.Hcl_tipreg_hcbd;

                    if (lobReg.Hcl_tipreg_hcbd != "3") // 1=Indicados /2=Administracion
                    {
                        if (lobReg.Hcl_tipreg_hcbd == "1")
                        {
                            lobDetalle.imgRegistro.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_xcap_liquidosindicados.png", UriKind.RelativeOrAbsolute));
                            lobDetalle.txtTituloRegistro.Text = "Liquidos indicados";
                            lobDetalle.lblAdmCantidad.Text = "Cantidad indicada (ml)";
                        }
                        lobDetalle.grdLiqElim.Visibility  = Visibility.Collapsed;
                        lobDetalle.txtHora.Text           = Funciones.fcrConvierteHora(lobReg.Hcl_horini_hcbd.ToString(), "24", gcrSeparadorDecimal, ":");
                        lobDetalle.txtAdmCantidad.Text    = lobReg.Hcl_cantid_hcbd.ToString();
                        lobDetalle.txtAdmHoraInicial.Text = Funciones.fcrConvierteHora(lobReg.Hcl_horini_hcbd.ToString(), "24", gcrSeparadorDecimal, ":");
                        lobDetalle.txtAdmHoraFinal.Text   = Funciones.fcrConvierteHora(lobReg.Hcl_horfin_hcbd.ToString(), "24", gcrSeparadorDecimal, ":");
                    }
                    else 
                    {
                        lobDetalle.grdLiqAdm.Visibility = Visibility.Collapsed;
                        lobDetalle.txtHora.Text          = Funciones.fcrConvierteHora(lobReg.Hcl_horeli_hcbd.ToString(), "24", gcrSeparadorDecimal, ":");
                        lobDetalle.txtElimCantidad.Text  = lobReg.Hcl_cantid_hcbd.ToString();
                        lobDetalle.txtElimHora.Text      = Funciones.fcrConvierteHora(lobReg.Hcl_horeli_hcbd.ToString(), "24", gcrSeparadorDecimal, ":");
                        lobDetalle.txtTituloRegistro.Text = "Liquidos eliminados";
                        lobDetalle.lblViaAdmiElim.Text   = "Via de eliminación";
                        lobDetalle.imgRegistro.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_xcap_liquidoseliminados.png", UriKind.RelativeOrAbsolute));

                    }

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
        public String fcrGenerarLlaveMs(ModeloHclregbliqidoms tobRegistro)
        {
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + "  " + tobRegistro.Adm_secadm_rgad + "  " + tobRegistro.Hcl_nroreg_hcbm;
            var lcrllave2 = tobRegistro.Hcl_fecape_hcbm.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + "  " + tobRegistro.Sia_desare_aser;

            return lcrllave1 + "  " + lcrllave2 + "  " + lcrllave3;
        }
        #endregion
        #region fcrGenerarLlaveDetalles: Generar llave desde registros detalles
        /// <summary>
        /// <para>Generar llave desde registros detalles</para>
        /// </summary>
        public String fcrGenerarLlaveDetalles(ModeloHclregbliqidode tobRegistro)
        {
            var lcrllave1 = tobRegistro.Hcl_desliq_hctl + " " + tobRegistro.Hcl_notreg_hcbd;
            var lcrllave2 = tobRegistro.Hcl_desvia_hcvl;

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
                var lobBoton = sender as Button;
                var lobGrid = lobBoton.Parent as Grid;
                var lobObjeto = lobGrid.Parent as ControlOrdDetallesBLiquido;

                var lobDetall = ModeloHclregbliqidode.flsListaHclregbliqidode("IG", lobObjeto.IdRegistro);

                if (lobDetall.Count != 0 && lobDetall != null)
                {
                    ModeloHclregbliqidode.fcvEliminar(lobObjeto.IdRegistro);
                    fcvCargarVistaDetalles(gcrCodigoUnico);
                }
            }
        }
        #endregion
    }
}

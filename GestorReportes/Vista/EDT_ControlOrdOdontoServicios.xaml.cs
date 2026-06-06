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
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_ControlOrdOdontoServicios.xaml
    /// </summary>
    public partial class ControlOrdOdontoServicios : UserControl
    {
        public ModeloOdnMaestroTratamiento tmpRegMsTratamiento = null;
        public ModeloOdnMsActivTratamiento tmpRegUsuario = null;
        public List<ModeloOdnDeActivTratamiento> tmpdetalles = null;
        public String gcrTipoRegistro = "ODDX"; // Asumir como diagnostico inicial
        public ControlOrdOdontoServicios()
        {
            InitializeComponent();
        }
        public String gcrCodigoTratamiento { get; set; }
        public String gcrCodigoActividad { get; set; }
        public String gcrCodigoAdmision { get; set; }
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
        public void fcvCargarVista(String tcrCodigoMsActividad)
        {
            if (!String.IsNullOrWhiteSpace(tcrCodigoMsActividad))
            {
                fcvLimpiarVista();
                gcrCodigoActividad = tcrCodigoMsActividad;
                var lobReg = ModeloOdnMsActivTratamiento.flsListaOdneventosactms("IG", tcrCodigoMsActividad);
                if (lobReg.Count == 0) { return; }

                tmpRegUsuario        = lobReg.FirstOrDefault();

                gcrTipoRegistro      = tmpRegUsuario.Hcl_tipreg_hctr;
                gcrCodigoAdmision    = tmpRegUsuario.Adm_secadm_rgad;
                gcrCodigoTratamiento = tmpRegUsuario.Odn_nroreg_odev;
                tmpRegMsTratamiento  = HclUtilidades.fobRegMaestroTratamiento(gcrCodigoTratamiento);

                this.odnAdulto.Visibility = tmpRegMsTratamiento.Odn_tgrafi_odev == "1" ? Visibility.Visible : Visibility.Collapsed;
                this.ondNinos.Visibility  = tmpRegMsTratamiento.Odn_tgrafi_odev == "2" ? Visibility.Visible : Visibility.Collapsed;
                this.odnMixto.Visibility = tmpRegMsTratamiento.Odn_tgrafi_odev == "3" ? Visibility.Visible : Visibility.Collapsed;

                fcvCargarVistaObjetos();
                fcvCargarVistaDetalles(tcrCodigoMsActividad);
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
                this.txtG1Odn_nroreg_odac.Text = tmpRegUsuario.Odn_nroreg_odac;
                this.txtG1Hcl_gesfec_hcms.Text = tmpRegUsuario.Odn_fecact_odac.ToShortDateString();
                //this.txtG1Hcl_geshor_hcms.Text = Funciones.fcrConvierteHora(tmpRegUsuario.Hcl_geshor_hcms.ToString(), "24", lcrSeparadorDecimal, ":");
                this.txtG1Sia_codpfa_prof.Text = tmpRegUsuario.Sia_codpfa_prof;
                this.txtG1Sia_nompro_prof.Text = tmpRegUsuario.Sia_nompro_prof;
                //this.txtG1Sia_codare_aser.Text = tmpRegUsuario.Sia_codare_aser;
                this.txtG1Sia_desare_aser.Text = tmpRegUsuario.Sia_desare_aser;
                this.txtG1Fcm_descpr_cpro.Text = tmpRegUsuario.Fcm_descpr_cpro;
                this.txtG1Sis_despro_espr.Text = tmpRegUsuario.Sis_despro_espr;
                this.txtObservacion.Text       = tmpRegUsuario.Odn_observ_odac;

                LlaveBusqueda = fcrGenerarLlaveMs(tmpRegUsuario).ToLower();

                if (tmpRegUsuario.Sis_estpro_espr == "2") // confirmado 
                {
                    this.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_confirmado.png", UriKind.RelativeOrAbsolute));
                }
                else if (tmpRegUsuario.Sis_estpro_espr == "3") // Anulado
                {
                    this.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_anulado.png", UriKind.RelativeOrAbsolute));
                }
                // Imagen que representa el registro
                switch (gcrTipoRegistro)
                {
                    case "ODDX":
                        // Diagnosticos
                        this.imgRegistro.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_xcap_odontologiadx.png", UriKind.RelativeOrAbsolute));
                        break;

                    case "ODTR":
                        // Plan de tratamiento
                        this.imgRegistro.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_xcap_odontologiaplan.png", UriKind.RelativeOrAbsolute));
                        break;

                    case "ODEV":
                        // Actividad Evolucion del tratamiento
                        var myGridLengthConverter = new GridLengthConverter();
                        this.grdFilaOdn.Height = (System.Windows.GridLength)myGridLengthConverter.ConvertFromString("0");
                        this.imgRegistro.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_xcap_odontologiaevolucion.png", UriKind.RelativeOrAbsolute));
                        break;
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
                this.txtG1Odn_nroreg_odac.Text = String.Empty;
                this.txtG1Hcl_gesfec_hcms.Text = String.Empty;
                //this.txtG1Hcl_geshor_hcms.Text = String.Empty;
                this.txtG1Sia_codpfa_prof.Text = String.Empty;
                this.txtG1Sia_nompro_prof.Text = String.Empty;
                //this.txtG1Sia_codare_aser.Text = String.Empty;
                this.txtG1Sia_desare_aser.Text = String.Empty;
                this.txtG1Sis_despro_espr.Text = String.Empty;
                LlaveBusqueda = String.Empty;
                this.odnAdulto.fcvLimpiarOdontograma();
                this.ondNinos.fcvLimpiarOdontograma();

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
        public void fcvCargarVistaDetalles(String tcrCodigoMsActividad)
        {
            if (!String.IsNullOrWhiteSpace(tcrCodigoMsActividad))
            {
                var lobDetall = ModeloOdnDeActivTratamiento.flsListaOdneventosactde("R1", tcrCodigoMsActividad);
                if (lobDetall.Count == 0) { return; }
                tmpdetalles = lobDetall;
                //- aqui cargar cada uno de los registros detalles de la actividad segun el tipo 
                fcvCargarVistaDetallPlanTratamiento();
            }
        }
        #endregion
        #region fcvCargarVistaDetallPlanTratamiento: Carga registros detalles tratamiento
        /// <summary>
        /// <para>Carga registros detalles tratamiento</para>
        /// </summary>
        public void fcvCargarVistaDetallPlanTratamiento()
        {
            if (tmpdetalles != null)
            {
                var lcrUri = "/GestorReportes;component/Imagenes/";
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                var lcrAuxCodDiente = String.Empty;
                var lcrCodigoServ = String.Empty;
                this.stkDetalles.Children.Clear();

                foreach (var lobReg in tmpdetalles)
                {
                    if (lcrAuxCodDiente != lobReg.Odn_coddie_oddi)
                    {
                        var lobTitulo = new ControlOrdOdontoTitulo();
                        lobTitulo.lblDiente.Text = lobReg.Odn_coddie_oddi != "NA" ? "DIENTE : " + lobReg.Odn_coddie_oddi : "GENERAL";

                        if (gcrTipoRegistro == "ODDX")// Diagnostico inicial
                        {
                            lobTitulo.lblDetalle.Text = "DIAGNOSTICO";
                        }
                        else if (gcrTipoRegistro == "ODTR") // Plan de tratamiento
                        {
                            lobTitulo.lblDetalle.Text = "TRATAMIENTO";
                        }
                        else if (gcrTipoRegistro == "ODEV") // Evolucion del tratamiento
                        {
                            lobTitulo.lblDetalle.Text = "ACTIVIDAD EVOLUCIÓN TRATAMIENTO";
                        }
                        this.stkDetalles.Children.Add(lobTitulo);
                    }
                    lcrAuxCodDiente = lobReg.Odn_coddie_oddi;

                    // Registro tipo detalle
                    var lobDetalle = new ControlOrdOdontoServiciosDetalle();

                    lcrCodigoServ               = gcrTipoRegistro == "ODDX" ? lobReg.Odn_coddia_oddx : lobReg.Fcm_codser_mant;
                    lobDetalle.txtItem.Text     = lobReg.Odn_desana_odan;
                    lobDetalle.txtDetalle.Text  = lcrCodigoServ + " - " + lobReg.Odn_desreg_odde;

                    // Imagen del estado registro detalle actividad
                    if (lobReg.Odn_prexis_odde == "1") // Tratamiento Pre existente
                    {
                        lobDetalle.txtEstado.Text = "Pre existente";
                        lobDetalle.imgProceso.Source = new BitmapImage(new Uri(lcrUri + "hc_od_dt2.png", UriKind.RelativeOrAbsolute));
                    }
                    else
                    {
                        lobDetalle.txtEstado.Text    = fcrEstadoRegistro(lobReg.Odn_estact_odac);
                        lobDetalle.imgProceso.Source = fobImagenEstadoRegistro(lobReg.Odn_estact_odac);
                    }

                    // agregar el registro a la vista
                    lobDetalle.IdRegistro = lobReg.Odn_nroreg_odde;
                    lobDetalle.IdR1Registro = lobReg.Odn_nroreg_odac;
                    this.stkDetalles.Children.Add(lobDetalle);
                    LlaveBusqueda += " " + fcrGenerarLlaveDetalles(lobReg).ToLower();
                    // Generar grafica 
                    if (lobReg.Odn_coddie_oddi != "NA")
                    {
                        fcrAddVistaGraficaEnOdontograma(lobReg);
                    }
                    // Aplicar registro en todo el odontograma
                    if (lobReg.Odn_aplvis_odde == "1")
                    {
                        var lcrListaDientes = lobReg.Odn_aplist_odde;
                        fcvAplicarTodosDxyServiOdontograma(lobReg, lobReg.Odn_tipreg_odac, lcrListaDientes);
                    }
                }
            }
        }
        #endregion
        #region fcrEstadoRegistro: Devuelve texto estado actividad 
        /// <summary>
        /// <para>Devuelve texto estado actividad segun proceso medico</para>
        /// </summary>
        public String fcrEstadoRegistro(String tcrEstadoRegistro)
        {
            var lcrReturn = "Pendiente";
            switch (tcrEstadoRegistro)
            {
                case "1":
                    lcrReturn = "Pendiente";
                    break;

                case "2": 
                    lcrReturn = "En Proceso";
                    break;

                case "3":
                    lcrReturn = "Finalizado";
                    break;
            }
            return lcrReturn;
        }
        #endregion
        #region fobImagenEstadoRegistro: Devuelve la imagen correspondiente al estado del registro
        /// <summary>
        /// <para>Devuelve la imagen correspondiente al estado del registro segun proceso medico</para>
        /// </summary>
        public BitmapImage fobImagenEstadoRegistro(String tcrEstadoRegistro)
        {
            var lcrUri = "/GestorReportes;component/Imagenes/";
            BitmapImage lobImagen = new BitmapImage(new Uri(lcrUri + "hc_od_dt1.png", UriKind.RelativeOrAbsolute));
            switch (tcrEstadoRegistro)
            {
                case "1":
                    lobImagen = new BitmapImage(new Uri(lcrUri + "hc_od_dt1.png", UriKind.RelativeOrAbsolute));
                    break;

                case "2":
                    lobImagen = new BitmapImage(new Uri(lcrUri + "hc_od_dt2.png", UriKind.RelativeOrAbsolute));
                    break;

                case "3":
                    lobImagen = new BitmapImage(new Uri(lcrUri + "hc_od_dt3.png", UriKind.RelativeOrAbsolute));
                    break;
            }
            return lobImagen;
        }
        #endregion
        //- Graficar y cargar registro detalles
        #region fcrAddVistaGraficaEnOdontograma: Genera vista graficada del registro detalle en odonograma
        /// <summary>
        /// <para>Genera vista graficada del registro detalle en odonograma</para>
        /// <para>segun el Odontograma y diente seleccionado</para>
        /// <para>VALOR RETORNO</para>
        /// <para>Retorna el nombre de la imagen utilizada para graaficar en odontograma</para>
        /// <para>cuando no se representa grafica en odontograma, devuelve un nombre de imagen por defecto</para>
        /// </summary>
        private String fcrAddVistaGraficaEnOdontograma(ModeloOdnDeActivTratamiento tobRegistro)
        {
            var lcrImagenGrafica = "hc_od_sinimagen.png";
            if (tobRegistro != null)
            {
                // Ver si se grafica en corona o en diente 
                if (tobRegistro.Odn_tipvis_odsi == "1") // se grafica en corona
                {
                    var lcrEstadoAct = tobRegistro.Odn_tipreg_odac == "1" ? "1" : tobRegistro.Odn_estact_odac.Trim();
                    lcrEstadoAct = tobRegistro.Odn_prexis_odde == "1" ? "2" : lcrEstadoAct;
                    var lcrEstadoCara = tobRegistro.Odn_carmar_odde.Trim() + lcrEstadoAct;

                    tobRegistro.Odn_imagen_odde = ODNValidarCodigo.fobRegBuscarOdnimgcracorona(lcrEstadoCara).odn_imagen_odcr;

                    if (tmpRegMsTratamiento.Odn_tgrafi_odev == "1") //Odontogrma adultos
                    {
                        this.odnAdulto.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi, "1", tobRegistro.Odn_imagen_odde, "2");
                    }
                    else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "2")  //Odontogrma niños
                    {
                        this.ondNinos.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi, "1", tobRegistro.Odn_imagen_odde, "2");
                    }
                    else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "3")  //Odontogrma Mixto
                    {
                        this.odnMixto.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi, "1", tobRegistro.Odn_imagen_odde, "2");
                    }
                    lcrImagenGrafica = tobRegistro.Odn_imagen_odde;
                }
                else if (tobRegistro.Odn_tipvis_odsi == "2")
                {
                    // se grafica en diente
                    if (!String.IsNullOrWhiteSpace(tobRegistro.Odn_codimg_odim))
                    {
                        var tmpDiente = ODNValidarCodigo.fobRegBuscarOdnmaestdientes(tobRegistro.Odn_coddie_oddi);
                        var tmpImagen = ODNValidarCodigo.fobRegBuscarOdnimagengrafms(tobRegistro.Odn_codimg_odim);

                        var lcrCuadrante = tmpDiente.odn_codcte_odcd;
                        var lcrCodImagen = tobRegistro.Odn_codimg_odim;
                        var lcrOcultaDiente = tmpImagen.odn_visite_odim;

                        var tmpGrafica = HclUtilidades.fobOdontogramaSeletImagenGraficar(lcrCodImagen, "1", lcrCuadrante, tobRegistro.Odn_coddie_oddi);
                        if (tmpGrafica != null)
                        {
                            var lcrZonaGrafica = tmpGrafica.odn_gravis_odid;

                            lcrImagenGrafica = HclUtilidades.fcrReturnNombreImagenEstadoAct(tmpRegUsuario.Odn_tipreg_odac, tobRegistro, tmpGrafica);

                            if (tmpRegMsTratamiento.Odn_tgrafi_odev == "1") //Odontogrma adultos
                            {
                                this.odnAdulto.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi, 
                                                                        lcrZonaGrafica, lcrImagenGrafica, lcrOcultaDiente);
                            }
                            else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "2") //Odontogrma niños
                            {
                                this.ondNinos.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi, 
                                                                       lcrZonaGrafica, lcrImagenGrafica, lcrOcultaDiente);
                            }
                            else if (tmpRegMsTratamiento.Odn_tgrafi_odev == "3") //Odontogrma Mixto
                            {
                                this.odnMixto.fcvGraficarImgenEnDiente(tobRegistro.Odn_nroreg_odde, tobRegistro.Odn_coddie_oddi,
                                                                       lcrZonaGrafica, lcrImagenGrafica, lcrOcultaDiente);
                            }
                        }
                    }
                }
            }
            return lcrImagenGrafica;
        }
        #endregion
        #region fcvAplicarTodosDxyServiOdontograma: Generar vista registro simple general aplicado en todo odontograma
        /// <summary>
        /// <para>Genera la vista en cada diente seleccionado, para aplicar un registro de la</para>
        /// <para>Pestaña general en el odontograma, para imagenes simples</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipoRegistro: 1 = Diagnostico, 2 = Plan de tratamiento</para>
        /// <para>tcrListaDientes: Lista de dientes separados por gion medio (-)</para>
        /// </summary>
        public void fcvAplicarTodosDxyServiOdontograma(ModeloOdnDeActivTratamiento tobRegistro, String tcrTipoRegistro, String tcrListaDientes)
        {

            int i;
            String lcrValor = string.Empty;
            String lcrBakLlave = tobRegistro.Odn_nroreg_odde;
            String lcrBakDiente = tobRegistro.Odn_coddie_oddi;
            String[] larArray = tcrListaDientes.Split('-');
            int lnuTotElemtos = larArray.Length;

            for (i = 0; i < lnuTotElemtos; i++)
            {
                tobRegistro.Odn_coddie_oddi = larArray[i].ToUpper();
                tobRegistro.Odn_nroreg_odde = lcrBakLlave + "D" + larArray[i].ToUpper();

                // Generar vista
                fcrAddVistaGraficaEnOdontograma(tobRegistro);
            }
            // Restaurar valores 
            tobRegistro.Odn_coddie_oddi = lcrBakDiente;
            tobRegistro.Odn_nroreg_odde = lcrBakLlave;

        }
        #endregion
        //------------------------------------------------------------
        // GESTION GENERAR LLAVES Y ELIMINAR REGISTROS DETALLE
        //------------------------------------------------------------
        #region fcrGenerarLlaveMs: Generar llave de busquda para el objeto
        /// <summary>
        /// <para>Generar llave de busquda para el objeto</para>
        /// </summary>
        public String fcrGenerarLlaveMs(ModeloOdnMsActivTratamiento tobRegistro)
        {
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + "  " + tobRegistro.Adm_secadm_rgad + "  " + tobRegistro.Odn_nroreg_odac;
            var lcrllave2 = tobRegistro.Odn_fecact_odac.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + "  " + tobRegistro.Sia_desare_aser;

            return lcrllave1 + "  " + lcrllave2 + "  " + lcrllave3;
        }
        #endregion
        #region fcrGenerarLlaveDetalles: Generar llave desde registros detalles
        /// <summary>
        /// <para>Generar llave desde registros detalles</para>
        /// </summary>
        public String fcrGenerarLlaveDetalles(ModeloOdnDeActivTratamiento tobRegistro)
        {
            var lcrllave1 = tobRegistro.Fcm_idesec_sips + " " + tobRegistro.Odn_desreg_odde + " " + tobRegistro.Odn_nroreg_odde;
            var lcrllave2 = tobRegistro.Fcm_coddig_mant;

            return lcrllave1 + " " + lcrllave2;
        }
        #endregion
        #region fcvEliminarRegDetalle: Eliminar un registro detalle
        /// <summary>
        /// <para>Eliminar un registro detalle sea Diagnostico Plan de tratamiento o evolucion</para>
        /// </summary>
        private void fcvEliminarRegDetalle(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lobBoton = sender as Button;
                var lobGrid = lobBoton.Parent as Grid;
                var lobObjeto = lobGrid.Parent as ControlOrdOdontoServiciosDetalle;

                var lobDetall = ModeloOdnDeActivTratamiento.flsListaOdneventosactde("IG", lobObjeto.IdRegistro);

                if (lobDetall.Count != 0 && lobDetall != null)
                {
                    ModeloOdnDeActivTratamiento.fcvEliminar(lobObjeto.IdRegistro);
                    fcvCargarVistaDetalles(gcrCodigoActividad);
                }
            }
        }
        #endregion
    }
}

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

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for ControlRegNotificacion.xaml
    /// </summary>
    public partial class ControlNotificacionReg : UserControl
    {
        /// <summary>
        /// <para> Codigo de la notificacion ejemplo: ADM-REG-URGENCIA</para>
        /// </summary>
        public String gcrIdNotificacion { get; set; }
        public String gcrIdUnicoRegistro { get; set; }
        public String gcrIdModulo { get; set; }
        public String gcrIdRegReferencia { get; set; }
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        bool glgTieneDetalles = false;
        bool glgTieneDetallesCargados = false;

        public ControlNotificacionReg()
        {
            InitializeComponent();
            this.IsManipulationEnabled = true;
            this.stkDetalle.Visibility = Visibility.Collapsed;
            this.cmdDetalles.Visibility = Visibility.Collapsed;
        }

        #region fcvActivarVistaHistorial: Mostrar u ocultar vista detalles
        /// <summary>
        /// <para> Mostrar u ocultar vista detalles</para>
        /// </summary>
        private void fcvActivarVistaHistorial(object sender, RoutedEventArgs e)
        {
            var lcrUri = "/Sistema;component/Imagenes/";
            if (this.stkDetalle.Visibility == Visibility.Visible)
            {
                this.stkDetalle.Visibility = Visibility.Collapsed;
                this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer3.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                if (glgTieneDetalles == true && glgTieneDetallesCargados == false)
                {
                    fcvCargarVistaDetalles();
                }
                this.stkDetalle.Visibility = Visibility.Visible;
                this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer2.png", UriKind.RelativeOrAbsolute));
            }
        }
        #endregion
        #region fcvCargarVistaDatos: Carga registros en vista
        /// <summary>
        /// <para>Carga registros en vista</para>
        /// </summary>
        public void fcvCargarVistaDatos(SysModeloAdminMensajes tobRegistro)
        {
            if (tobRegistro != null)
            {
                var lcrUri = "/Sistema;component/Imagenes/";
                this.txtFecha.Text = tobRegistro.Sys_sisfec_syam.ToShortDateString() + " " +
                                      Funciones.fcrConvierteHora(tobRegistro.Sys_sishor_syam.ToString(), "24", gcrSeparadorDecimal, ":");
                this.imgRegistro.Source = new BitmapImage(new Uri(lcrUri + tobRegistro.Grc_iderec_grcm.Trim(), UriKind.RelativeOrAbsolute));

                //Cambiar la imagen si ya fue visto
                if (tobRegistro.Sys_msjvis_syam == "2") 
                { 
                    this.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_confirmado.png", UriKind.RelativeOrAbsolute));
                    //this.cmdOk.IsEnabled = false;
                    this.cmdOk.Visibility = Visibility.Collapsed;
                }

                // Resto de datos
                fcvCargarVistaNotificacion(tobRegistro);
                this.cmdDetalles.Visibility = glgTieneDetalles == true ? Visibility.Visible : Visibility.Collapsed;

                //Guardar parametros importantes
                gcrIdUnicoRegistro  = tobRegistro.Sys_codsec_syam;
                gcrIdModulo          = tobRegistro.Sys_codmsg_symg;
                gcrIdNotificacion   = tobRegistro.Sys_codtip_sytm;
                gcrIdRegReferencia  = tobRegistro.Sys_regeve_sytm;

                //lobDetalle.cmdEliminar.Click += new RoutedEventHandler(fcvEliminarRegDetalle);
            }
        }
        #endregion
        #region fcvCargarVistaNotificacion: Carga los datos segun tipo notificacion
        /// <summary>
        /// <para>Carga los datos segun tipo notificacion</para>
        /// </summary>
        public void fcvCargarVistaNotificacion(SysModeloAdminMensajes tobRegistro)
        {
            if (tobRegistro != null)
            {
                this.stkDetalle.Children.Clear();
                glgTieneDetalles = false;

                // Admision urgencias Adm Hospitalizacion y Registro egreso
                if (tobRegistro.Sys_codtip_sytm == "ADM-ADMI-URGENCIAS" ||
                    tobRegistro.Sys_codtip_sytm == "ADM-ADMI-HOSPITALIZ")
                {
                    this.txtTitulo.Text = tobRegistro.Sys_desmsj_sytm;
                    this.txtTexto1.Text = tobRegistro.Sys_desmsj_syam;
                    this.txtTexto2.Text = tobRegistro.Sys_notmsj_syam;

                }
                // Servicios para facturar en hoja de consumo y Vista Valoracion Triage
                else if (tobRegistro.Sys_codtip_sytm == "HOS-HOJA-CONSUMO" ||
                         tobRegistro.Sys_codtip_sytm == "CEX-FORMULA-MEDICA" ||
                         tobRegistro.Sys_codtip_sytm == "HOS-AUTORI-SALIDA" ||
                         tobRegistro.Sys_codtip_sytm == "HOS-AUTORI-SALIDA-F" ||
                         tobRegistro.Sys_codtip_sytm == "ADM-TRIAGE-URGENCIA" ||
                         tobRegistro.Sys_codtip_sytm == "ADM-TRIAGE-PRIORITAR" ||
                         tobRegistro.Sys_codtip_sytm == "HOS-TRASLADO-PACIENT")
                {
                    this.txtTitulo.Text = tobRegistro.Sys_desmsj_sytm;
                    this.txtTexto1.Text = tobRegistro.Sys_desmsj_syam;
                    this.txtTexto2.Text = tobRegistro.Sys_notmsj_syam;
                    glgTieneDetalles = true;
                }
                else if (tobRegistro.Sys_codtip_sytm == "ODN-REG-ACTIV-TRATAM")
                {
                    this.txtTitulo.Text = tobRegistro.Sys_desmsj_sytm;
                    this.txtTexto1.Text = tobRegistro.Sys_desmsj_syam;
                    this.txtTexto2.Text = tobRegistro.Sys_notmsj_syam;
                    glgTieneDetalles = true;
                }
                else if (tobRegistro.Sys_codtip_sytm == "ADM-ATEN-AMBULATORIA")
                {
                    this.txtTitulo.Text = tobRegistro.Sys_desmsj_sytm;
                    this.txtTexto1.Text = tobRegistro.Sys_desmsj_syam;
                    this.txtTexto2.Text = tobRegistro.Sys_notmsj_syam;
                    glgTieneDetalles = true;
                }
                else
                {
                    // Para restantes general
                    this.txtTitulo.Text = tobRegistro.Sys_desmsj_sytm;
                    this.txtTexto1.Text = tobRegistro.Sys_desmsj_syam;
                    this.txtTexto2.Text = tobRegistro.Sys_notmsj_syam;
                }
                // Mostrar si esta anulada la admision
                // Servicios para facturar en hoja de consumo
                String[] larArray = tobRegistro.Sys_regeve_sytm.Split('*');
                var lcrCodigo = larArray[0];
                if (tobRegistro.Sys_codtip_sytm != "ADM-TRIAGE-URGENCIA" && tobRegistro.Sys_codtip_sytm != "ADM-TRIAGE-PRIORITAR")
                {
                    // todas 
                    var lobReg = ADMValidarCodigo.fobRegBuscarAdmregadmision(lcrCodigo);
                    if (lobReg!= null)
                    {
                        this.txtTexto1.Text = lobReg.sis_estpro_espr == "3" ? this.txtTexto1.Text + " - ADM ANULADA" : this.txtTexto1.Text;
                    }
                }
                else 
                {
                    // es triage
                    var lobReg = ADMValidarCodigo.fobRegBuscarAdmregadmisionTriage(lcrCodigo);
                    if (lobReg!= null)
                    {
                        this.txtTexto1.Text = lobReg.sis_estpro_espr == "3" ? this.txtTexto1.Text + " - ADM ANULADA" : this.txtTexto1.Text;
                    }
                }
            }
        }
        //
        #endregion
        #region fcvCargarVistaDetalles: Carga vista detalles notificacion
        /// <summary>
        /// <para>Carga vista detalles notificacion</para>
        /// </summary>
        public void fcvCargarVistaDetalles()
        {
            this.stkDetalle.Children.Clear();
            glgTieneDetallesCargados = true;
            // Servicios para facturar en hoja de consumo
            if (gcrIdNotificacion == "HOS-HOJA-CONSUMO")
            {
                fcvDetallesVistaHojaOFormula("HOJA DE CONSUMO");
            }
            else if (gcrIdNotificacion == "CEX-FORMULA-MEDICA")
            {
                fcvDetallesVistaHojaOFormula("FORMULA MEDICA");
            }
            else if (gcrIdNotificacion == "ADM-TRIAGE-URGENCIA")
            {
                // Vista detalles valoracion triage
                fcvDetallesVistaValoracionTriage();
            }
            else if (gcrIdNotificacion == "HOS-TRASLADO-PACIENT")
            {
                // Vista detalles traslados paciente
                fcvDetallesVistaTraslados();
            }
            else if (gcrIdNotificacion == "HOS-AUTORI-SALIDA" ||
                     gcrIdNotificacion == "HOS-AUTORI-SALIDA-F")
            {
                // Vista detalles Autorizacion salida admitido
                fcvDetallesVistaAutorizSalida();
            }
            else if (gcrIdNotificacion == "ODN-REG-ACTIV-TRATAM")
            {
                // Vista detalles evolucion odontologia
                fcvDetallesVistaEvolOdontologia();
            }
            else if (gcrIdNotificacion == "ADM-ATEN-AMBULATORIA")
            {
                // Vista detalles atencion ambulatoria
                fcvDetallesVistaAteAmbulatria();
            }
            else
            {
                // los que vengan
            }
        }
        #endregion
        //-------------------------------------------------------
        // Funciones para gestion de objetos de texto
        //-------------------------------------------------------
        #region fcvAddTitulo: Agrega un objeto titulo
        /// <summary>
        /// <para>Agrega un objeto titulo</para>
        /// </summary>
        public void fcvAddTitulo(String tcrTitulo)
        {
            var lobTitulo = new ControlNotificacionRegTitulo();

            lobTitulo.txtTitulo.Text = tcrTitulo;
            this.stkDetalle.Children.Add(lobTitulo);
        }
        #endregion
        #region fcvAddTitulo02: Agrega un objeto titulo sencillo
        /// <summary>
        /// <para>Agrega un objeto titulo sencillo</para>
        /// </summary>
        public void fcvAddTitulo02(String tcrTitulo)
        {
            var lobTitulo = new ControlNotificacionRegTitulo();
            lobTitulo.txtTitulo.FontWeight = FontWeights.Regular;
            lobTitulo.txtTitulo.Text = tcrTitulo;
            this.stkDetalle.Children.Add(lobTitulo);
        }
        #endregion
        #region fcvAddTexto: Agrega un objeto texto normal
        /// <summary>
        /// <para>Agrega un objeto texto normal</para>
        /// </summary>
        public void fcvAddTexto(String tcrTexto)
        {
            var lobTexto = new ControlNotificacionRegTexto();

            lobTexto.txtTexto.Text = tcrTexto;
            this.stkDetalle.Children.Add(lobTexto);
        }
        #endregion
        #region fcvAddTextoMemo: Agrega un objeto texto tipo memo
        /// <summary>
        /// <para>Agrega un objeto texto tipo memo</para>
        /// </summary>
        public void fcvAddTextoMemo(String tcrTitulo, String tcrTextoMemo)
        {
            // Titulo
            if (!String.IsNullOrWhiteSpace(tcrTitulo))
            {
                var lobTitulo = new ControlNotificacionRegTitulo();
                lobTitulo.txtTitulo.Text = tcrTitulo;
                this.stkDetalle.Children.Add(lobTitulo);
            }

            // Texto memo
            var lobTexto = new ControlNotificacionRegTexto();

            lobTexto.txtTexto.Text          = tcrTextoMemo;
            lobTexto.txtTexto.TextWrapping  = TextWrapping.Wrap;
            lobTexto.txtTexto.TextAlignment = TextAlignment.Justify;

            this.stkDetalle.Children.Add(lobTexto);
        }
        #endregion
        #region fcvAddLinea: Agrega Linea
        /// <summary>
        /// <para>Agrega linea</para>
        /// </summary>
        public void fcvAddLinea(int tnuWidth, HorizontalAlignment tuxAlignment)
        {
            var lobLinea = new ControlNotificacionRegLinea();

            if (tnuWidth > 0) { lobLinea.Width = tnuWidth; }
            lobLinea.HorizontalAlignment = tuxAlignment;
            this.stkDetalle.Children.Add(lobLinea);
        }
        #endregion
        //-------------------------------------------------------
        // Funciones para gestion Detalles notificaciones
        //-------------------------------------------------------
        #region fcvDetallesVistaHojaConsumo: Carga vista Hoja de consumo formula medica 
        /// <summary>
        /// <para>Carga vista detalles Hoja de consumo o formula medica </para>
        /// </summary>
        public void fcvDetallesVistaHojaOFormula(String tcrTitulo)
        {
            // Servicios para facturar en hoja de consumo
            String[] larArray = gcrIdRegReferencia.Split('*');
            var lcrCodigo = larArray[1];
            var tmpDatos = ModeloHclregordeserde.flsListaHclregordeserde("R1", lcrCodigo);
            if (tmpDatos != null)
            {
                // Linea final
                var lobLinea = new ControlNotificacionRegLinea();
                this.stkDetalle.Children.Add(lobLinea);
                var llgProfesional = false;

                foreach (var lobReg in tmpDatos)
                {
                    if (llgProfesional == false)
                    {
                        llgProfesional = true;
                        fcvAddTitulo("PROFESIONAL");
                        fcvAddTexto(lobReg.Sia_codpfa_prof.Trim() + " - " + lobReg.Sia_nompro_prof.Trim().ToUpper());
                        fcvAddTitulo(tcrTitulo);
                        fcvAddLinea(0, HorizontalAlignment.Left);
                    }
                    // Titulo 
                    fcvAddTitulo02("CANTIDAD\t\tCODIGO\t\t\tSERVICIO");

                    var lcrCodServicio = lobReg.Fcm_codser_sips != null ? lobReg.Fcm_codser_sips.Trim() : String.Empty;

                    // Datos debajo del titulo
                    var lcrTexto1 = "  " + lobReg.Hcl_totuni_hcor.ToString().Trim() +
                                    "\t\t\t" + lobReg.Fcm_coddig_mant.Trim() +
                                    "\t\t\t" + lcrCodServicio;
                    fcvAddTexto(lcrTexto1);

                    // Linea final
                    fcvAddLinea(200, HorizontalAlignment.Left);

                    // Descripcion suministro
                    fcvAddTexto(lobReg.Fcm_desser_sips);
                }
            }
        }
        #endregion
        #region fcvDetallesVistaValoracionTriage: Carga vista detalles Valoracion triage
        /// <summary>
        /// <para>Carga vista detalles Valoracion triage</para>
        /// </summary>
        public void fcvDetallesVistaValoracionTriage()
        {
            // tomar codigo del registro Triage en campo referencia
            var lcrCodigo = gcrIdRegReferencia;

            var lobReg = ADMValidarCodigo.fobRegBuscarAdmtriagemaestr(lcrCodigo);
            if (lobReg != null)
            {
                // Linea final
                var lobLinea = new ControlNotificacionRegLinea();
                this.stkDetalle.Children.Add(lobLinea);

                //------------------------------------------------
                // Titulo 1
                //------------------------------------------------
                fcvAddTitulo("Sexo | Edad de paciente");

                // Datos debajo del titulo
                var lcrTexto1 = "  " + lobReg.sis_codsex_sexo.ToString().Trim() +
                                "\t" + lobReg.sia_edapac_usua.ToString().Trim() + " " +
                                Funciones.fcrMedidaAñosMesesDias(lobReg.sia_codmed_tmed);
                fcvAddTexto(lcrTexto1);

                //------------------------------------------------
                // Titulo del grupo diagnostico
                //------------------------------------------------
                var lcrTextoDiag = "  NA \t SIN DIAGNOSTICO ASIGNADO";
                fcvAddTitulo("Cie-10 | Diagnostico");
                //  Diagnostico
                if (lobReg.sia_coddia_tdia != "NA" && !String.IsNullOrWhiteSpace(lobReg.sia_coddia_tdia))
                {
                    var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(lobReg.sia_coddia_tdia);
                    if (tmp != null)
                    {
                        lcrTextoDiag = "  " + tmp.sia_coddia_tdia.ToString().Trim() + "\t" + tmp.sia_desdia_tdia.ToString().Trim();
                    }
                }
                fcvAddTexto(lcrTextoDiag);
                //------------------------------------------------
                // Motivo consulta
                //------------------------------------------------
                fcvAddTextoMemo("Motivo consulta", lobReg.adm_motcon_tria);
                //------------------------------------------------
                // Observación
                //------------------------------------------------
                fcvAddTextoMemo("Observación", lobReg.adm_observ_tria);
            }
        }
        #endregion
        #region fcvDetallesVistaAutorizSalida: Carga vista detalles Autorizacion salida paciente admitido
        /// <summary>
        /// <para>Carga vista detalles Autorizacion salida paciente admitido</para>
        /// </summary>
        public void fcvDetallesVistaAutorizSalida()
        {
            String[] larArray = gcrIdRegReferencia.Split('*');
            var lcrCodigo = larArray[1];

            var lobReg = ADMValidarCodigo.fobRegBuscarAdmordendsalida(lcrCodigo);
            if (lobReg != null)
            {
                var lobProf = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(lobReg.sia_codpfa_prof);
                // Linea final
                var lobLinea = new ControlNotificacionRegLinea();
                this.stkDetalle.Children.Add(lobLinea);

                // Fecha salida
                fcvAddTitulo("Fecha salida");
                var lcrTexto1 = "  " + ((DateTime)lobReg.adm_fecsal_aegr).ToShortDateString().Trim() +
                                "\t" + Funciones.fcrConvierteHora(lobReg.adm_horsal_aegr.ToString(), "24", gcrSeparadorDecimal, ":");
                fcvAddTexto(lcrTexto1);

                // Quien autoriza 
                fcvAddTitulo("Profesional que autoriza");
                fcvAddTexto("  " + lobReg.sia_codpfa_prof+ " - " + lobProf.sia_nompro_prof);

                // Observación
                fcvAddTextoMemo("Observación", lobReg.adm_observ_aegr);
            }
        }
        #endregion
        #region fcvDetallesVistaTraslados: Vista traslados pacientes a nueva cama
        /// <summary>
        /// <para>Vista traslados pacientes a nueva cama</para>
        /// </summary>
        public void fcvDetallesVistaTraslados()
        {
            var tmpDatos = HosModeloTrasladoCama.flsListaHosestanciapaci(gcrIdRegReferencia);
            if (tmpDatos != null)
            {
                // Linea final
                var lobLinea = new ControlNotificacionRegLinea();
                this.stkDetalle.Children.Add(lobLinea);
                fcvAddTitulo("TRASLADOS");

                foreach (var lobReg in tmpDatos)
                {
                    // Titulo 
                    fcvAddTitulo02("FECHA\t\tHORA\t\t\tCAMA");

                    // Datos debajo del titulo
                    var lcrTexto1 = "  " + ((DateTime)lobReg.Hos_fecing_espa).ToShortDateString().Trim() +
                                    "\t" + Funciones.fcrConvierteHora(lobReg.Hos_horing_espa.ToString(), "24", gcrSeparadorDecimal, ":")+
                                    "\t\t" + lobReg.Hos_codcam_caho.Trim() + " - " + lobReg.Hos_descam_caho.Trim();

                    fcvAddTexto(lcrTexto1);

                    // Profesional que autoriza traslado
                    fcvAddTitulo("Profesional que autoriza");
                    fcvAddTexto(lobReg.Sia_codpfa_prof.Trim() + " - " + lobReg.Sia_nompro_prof.Trim().ToUpper());
                }
            }
        }
        #endregion
        #region fcvDetallesVistaEvolOdontologia: Carga vista detalles Evolucion odontologia
        /// <summary>
        /// <para>Carga vista detalles Evolucion odontologia</para>
        /// </summary>
        public void fcvDetallesVistaEvolOdontologia()
        {
            // Servicios para facturar en hoja de consumo
            String[] larArray = gcrIdRegReferencia.Split('*');
            var lcrCodigo = larArray[1];
            var tmpDatos = ModeloOdnDeActivTratamiento.flsListaOdneventosactde("R1", lcrCodigo);
            var lobRegMaestro = ODNValidarCodigo.fobRegBuscarOdneventosactms(lcrCodigo);

            if (tmpDatos != null)
            {
                // Linea final
                var lobLinea = new ControlNotificacionRegLinea();
                this.stkDetalle.Children.Add(lobLinea);
                var llgProfesional = false;
                var lobRegProf = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(lobRegMaestro.sia_codpfa_prof);

                foreach (var lobReg in tmpDatos)
                {
                    if (llgProfesional == false)
                    {
                        llgProfesional = true;
                        fcvAddTitulo("PROFESIONAL");
                        fcvAddTexto(lobRegProf.sia_codpfa_prof.Trim() + " - " + lobRegProf.sia_nompro_prof.Trim().ToUpper());
                        fcvAddTitulo("ACTIVIADES ODONTOLOGIA");
                        fcvAddLinea(0, HorizontalAlignment.Left);
                    }
                    // Titulo 
                    fcvAddTitulo02("CANTIDAD\t\tCODIGO\t\t\tSERVICIO");

                    // Datos debajo del titulo
                    var lcrTexto1 = "  " + lobReg.Odn_totuni_odde.ToString().Trim() +
                                    "\t\t\t" + lobReg.Fcm_coddig_mant.Trim() +
                                    "\t\t\t" + lobReg.Fcm_codser_mant.Trim();
                    fcvAddTexto(lcrTexto1);

                    // Linea final
                    fcvAddLinea(200, HorizontalAlignment.Left);

                    // Descripcion suministro
                    fcvAddTexto(lobReg.Fcm_desser_mant);
                }
            }
        }
        #endregion
        #region fcvDetallesVistaAteAmbulatria: Carga vista detalles Antencion ambulatoria
        /// <summary>
        /// <para>Carga vista detalles Evolucion odontologia</para>
        /// </summary>
        public void fcvDetallesVistaAteAmbulatria()
        {
            // Servicios para facturar en hoja de consumo
            String[] larArray = gcrIdRegReferencia.Split('*');
            var lcrCodigo = larArray[0];
            var tmpDatos = FCMValidarCodigo.fobRegBuscarFcmmaedetallfacR1(lcrCodigo, "2");

            if (tmpDatos != null)
            {
                // Linea final
                var lobLinea = new ControlNotificacionRegLinea();
                this.stkDetalle.Children.Add(lobLinea);

                foreach (var lobReg in tmpDatos)
                {
                    // Titulo 
                    fcvAddTitulo02("CANTIDAD\t\tCODIGO\t\t\tSERVICIO");

                    // Datos debajo del titulo
                    var lcrTexto1 = "  " + lobReg.fcm_totuni_dfac.ToString().Trim() +
                                    "\t\t\t" + lobReg.fcm_coddig_mant.Trim() +
                                    "\t\t\t" + lobReg.fcm_codser_mant.Trim();
                    fcvAddTexto(lcrTexto1);

                    // Linea final
                    fcvAddLinea(200, HorizontalAlignment.Left);

                    // Descripcion suministro
                    fcvAddTexto(lobReg.fcm_desser_dfac);
                }
            }
        }
        #endregion

    }
}

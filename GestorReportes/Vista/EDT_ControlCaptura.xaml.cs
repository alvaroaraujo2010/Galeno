using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Diagnostics;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_ControlCaptura.xaml
    /// </summary>
    public partial class ControlCaptura : UserControl
    {
        /// <summary>
        ///  BLIQ = Balance liqidos MEDI=Medicamentos SERV=servicios EVOL=Evoluciones NENF=Notas enfermeria ...
        /// </summary>
        public String gcrTipoControl { get; set; }
        public List<Utilidades.ClassRegistroVista> tmpRegistro = new List<Utilidades.ClassRegistroVista>();
        public ADMModeloAdmadmisiones gobRegAdmision = null;
        public HclModeloHistorialEventos gobRegHistorial = null;
        public String gcrCodigoAdmision = String.Empty;
        public String gcrCodigoRegMaest = String.Empty;
        public String gcrEstadoRegMaest = "NA";
        public bool llgCanAdicionar = false;
        public bool llgCanEliminar = false;
        public bool llgCanConfirmar = false;

        public ControlCaptura()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------
        // GESTION VISTA OBJETOS
        //------------------------------------------------------------
        #region fcvCargarVista: Generar toda la vista segun admisión
        /// <summary>
        /// <para>Generar la vista segun el parametro Registro de admision para</para>
        /// <para>mostrar todos los registros maestros existentes para la admision</para>
        /// </summary>
        public void fcvCargarVista(String tcrCodigoAdmision)
        {
            if (!String.IsNullOrWhiteSpace(tcrCodigoAdmision))
            {
                // Cargar registro admision
                gcrCodigoAdmision = tcrCodigoAdmision;
                //var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(gcrCodigoAdmision);
                var lobRegAdm = HclUtilidades.fobRegAdmisionAuxiliar(gcrCodigoAdmision);
                if (lobRegAdm == null) { return; }
                gobRegAdmision = lobRegAdm;

                fcvLimpiarVista();

                this.txtTitulo.Text = HCLValidarCodigo.fcrDEBuscarHcltiporegserms(gcrTipoControl).ToUpper();

                if (gcrTipoControl == "SERV" || gcrTipoControl == "EVOL" || 
                    gcrTipoControl == "NENF" || gcrTipoControl == "HCON" ||
                    gcrTipoControl == "FMED")
                {
                    var lobTmpReg = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoControl, tcrCodigoAdmision, "");
                    if (lobTmpReg.Count != 0)
                    {
                        foreach (var lobReg in lobTmpReg)
                        {
                            fobGenerarObjetoOrdenServicios(lobReg);
                        }
                    }
                }
                if (gcrTipoControl == "RPDF" || gcrTipoControl == "RIMG" ||
                    gcrTipoControl == "RHL7" || gcrTipoControl == "RDOC" ||
                    gcrTipoControl == "RXLS" || gcrTipoControl == "RXML")
                {
                    // este grupo es igual a  "SERV" "EVOL" "NENF" "HCON", se separaron por posibles futuras diferencias

                    var lobTmpReg = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoControl, tcrCodigoAdmision, "");
                    if (lobTmpReg.Count != 0)
                    {
                        foreach (var lobReg in lobTmpReg)
                        {
                            fobGenerarObjetoOrdenServicios(lobReg);
                        }
                    }
                }
                else if (gcrTipoControl == "BLIQ")
                {
                    var lobTmpReg = ModeloHclregbliqidoms.flsListaHclregbliqidomsEx("2", tcrCodigoAdmision, "");
                    if (lobTmpReg.Count != 0)
                    {
                        foreach (var lobReg in lobTmpReg)
                        {
                            fobGenerarObjetoBalanceLiquidos(lobReg);
                        }
                    }
                }
                else if (gcrTipoControl == "ODAP") // Odontologia
                {
                    var lobTmpReg = fobCargarVistaRegMaestroOdontologia("2", "2", tcrCodigoAdmision);
                    if (lobTmpReg != null)
                    {
                        gcrCodigoRegMaest = lobTmpReg.Odn_nroreg_odev;
                        gcrEstadoRegMaest = lobTmpReg.Odn_estado_odev;
                        var lobTmpRegAct = ModeloOdnMsActivTratamiento.flsListaOdneventosactms("R1", lobTmpReg.Odn_nroreg_odev);
                        // aqui el ciclo para el registro maestro cada actividad del tratamiento
                        foreach (var lobReg in lobTmpRegAct)
                        {
                            fobGenerarObjetoMsActividadTratamiento(lobReg);
                        }
                        // Cargar de ultimo registro apertura por ser el mas antiguo
                        fobCargarVistaRegMaestroOdontologia("1", "2", tcrCodigoAdmision);
                    }
                }
            }
            fcvValidarEstadoEdicion();
        }
        #endregion
        #region fcvValidarEstadoEdicion: Verifica el estado edicion para permitir editar datos
        /// <summary>
        /// <para>Verifica el estado edicion para permitir editar datos</para>
        /// </summary>
        public void fcvValidarEstadoEdicion()
        {
            llgCanAdicionar = false;
            llgCanEliminar = false;
            llgCanConfirmar = false;
            fcvActivarBotonesEdicion();

            if (!string.IsNullOrWhiteSpace(gcrCodigoAdmision))
            {
                var llgFinalizar = false;
                if (gobRegAdmision.Adm_estrad_rgad != "1") { return; }

                llgCanAdicionar = true;
                fcvActivarBotonesEdicion();

                if (tmpRegistro == null) { return; }

                foreach (var lobReg in tmpRegistro)
                {
                    if (lobReg.EstadoRegistro == "1")
                    {
                        llgCanEliminar = true;
                        llgCanConfirmar = true;
                        break;
                    }
                    //Verificar si es plan tratamiento odontologico y esta finalizado
                    if (lobReg.TipoRegistro == "ODTR" && lobReg.DatoAuxiliar == "3") { llgFinalizar = true; }
                }
                llgCanAdicionar = llgFinalizar == true ? false : llgCanAdicionar;
                llgCanConfirmar = gcrTipoControl == "ODAP" && gcrEstadoRegMaest =="1" ? true : llgCanConfirmar;
                fcvActivarBotonesEdicion();
            }
        }
        #endregion
        #region fcvActivarBotonesEdicion: Activiar o desactivar botones segun estado edición
        /// <summary>
        /// <para>Activiar o desactivar botones segun estado edición</para>
        /// </summary>
        public void fcvActivarBotonesEdicion()
        {
            cmdAdicionar.Visibility = llgCanAdicionar == true ? Visibility.Visible : Visibility.Collapsed;
            cmdEliminar.Visibility = llgCanEliminar == true ? Visibility.Visible : Visibility.Collapsed;
            cmdConfirmar.Visibility = llgCanConfirmar == true ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion
        #region fcvLimpiarVista: Limiar vista de objetos
        /// <summary>
        /// <para>Limiar vista de objetos</para>
        /// </summary>
        public void fcvLimpiarVista()
        {
            tmpRegistro = new List<Utilidades.ClassRegistroVista>();
            this.stkContenedor.Children.Clear();
        }
        #endregion
        #region fcvCargarRegistro: cargar solo un registro en la vista
        /// <summary>
        /// <para>Cargar solo un registro por el Id unico generado</para>
        /// <para>Verifica que tipo de control se debe mostrar en la vista</para>
        /// </summary>
        public void fcvCargarRegistro(String tcrCodigoUnico)
        {
            if (!String.IsNullOrWhiteSpace(tcrCodigoUnico))
            {
                switch (gcrTipoControl)
                {
                    case "SERV":
                        flgCargarRegistroMs(tcrCodigoUnico);
                        break;

                    case "FMED":
                        flgCargarRegistroMs(tcrCodigoUnico);
                        break;

                    case "EVOL":
                        flgCargarRegistroMs(tcrCodigoUnico);
                        break;

                    case "NENF":
                        flgCargarRegistroMs(tcrCodigoUnico);
                        break;

                    case "HCON":
                        flgCargarRegistroMs(tcrCodigoUnico);
                        break;

                    case "BLIQ":
                        flgCargarRegistroBl(tcrCodigoUnico);
                        break;

                    case "MED":
                        break;

                    case "DIAG":
                        break;

                    case "ODAP":
                        flgCargarRegistroOdont(tcrCodigoUnico);
                        break;

                    default:
                        if (gcrTipoControl == "RDOC" || gcrTipoControl == "RXLS" || gcrTipoControl == "RPDF"
                            || gcrTipoControl == "RIMG" || gcrTipoControl == "RVID" || gcrTipoControl == "RXML"
                            || gcrTipoControl == "RHL7")
                        {
                            flgCargarRegistroMs(tcrCodigoUnico);
                        }
                        break;
                }
            }
        }
        #endregion
        #region fobRegSelectRegistro : Seleccionar registros desde temporal vista
        /// <summary>
        /// <para>Seleccionar registros desde tmpVistaHistorial temporal de registros en la vista historial</para>
        /// <para>Posibles Valores tcrTipoId:</para>
        /// <para>tcrTipoId = "REGISTRO"    y tcrLlave = "IgRegistro" : Retorna el registro dado en "IgRegistro"</para>
        /// <para>tcrTipoId = "LLAVE"       y tcrLlave = "texto...  " : Retorna lista de registros contengan el texto en campo llave</para>
        /// </summary>
        public List<Utilidades.ClassRegistroVista> fobRegSelectRegistro(String tcrTipoId, String tcrLlave)
        {
            List<Utilidades.ClassRegistroVista> lcrQuery = null;

            if (tmpRegistro != null)
            {
                if (tcrTipoId == "REGISTRO")    // solo el regigstro dado
                {
                    lcrQuery = (from lst in tmpRegistro
                                where lst.IdRegistro.Equals(tcrLlave)
                                select lst).ToList();
                }
                else if (tcrTipoId == "LLAVE")  // llave de busqueda general 
                {
                    lcrQuery = (from lst in tmpRegistro
                                where lst.LlaveBusqueda.Contains(tcrLlave)
                                select lst).ToList();
                }
            }
            return lcrQuery;
        }
        #endregion
        //------------------------------------------------------------
        // HCLREGORDESERMS: SERVICIOS GESTION VISTA DATOS
        //------------------------------------------------------------
        #region flgCargarRegistroMs: temporarl para referencia de objetos en la vista
        /// <summary>
        /// <para>Cargar Vista "SERV" "EVOL" "NENF" "HCON" para un solo registro</para>
        /// <para>Verifica si ya existe la vista del objeto y lo actualiza o lo crea</para>
        /// </summary>
        public bool flgCargarRegistroMs(String tcrCodigoUnico)
        {
            var lcrReturn = false;
            var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx("NA", tcrCodigoUnico, "");
            if (lobReg.Count != 0)
            {
                var lobTmpMs = lobReg.FirstOrDefault();
                var lobRegHist = fobRegSelectRegistro("REGISTRO", tcrCodigoUnico);
                if (lobRegHist == null || lobRegHist.Count == 0)
                {
                    fcvCargarVista(gcrCodigoAdmision);
                }
                else
                {
                    var lobObjetoServicio = lobRegHist.FirstOrDefault().RefObjeto as ControlOrdServicios;
                    lobObjetoServicio.fcvCargarVista(tcrCodigoUnico);

                    lobRegHist.FirstOrDefault().LlaveBusqueda = lobObjetoServicio.LlaveBusqueda;
                    lobObjetoServicio.LlaveBusqueda = String.Empty;

                    lobRegHist.FirstOrDefault().EstadoRegistro = lobTmpMs.Sis_estpro_espr;
                    fcvValidarEstadoEdicion();

                }
            }
            return lcrReturn;
        }
        #endregion
        #region fobGenerarObjetoOrdenServicios: Mostrar servicios en la vista
        /// <summary>
        /// <para>Generar Objeto ControlOrdServicios para mostrar servicios en la vista</para>
        /// </summary>
        public ControlOrdServicios fobGenerarObjetoOrdenServicios(ModeloHclregordeserms tobTmpOrdenserv)
        {
            var lobObjetoServicio = new ControlOrdServicios();
            var lobRegVista = new Utilidades.ClassRegistroVista();

            lobRegVista.LlaveAuxiliar   = "ORDENSERVICIO";
            lobRegVista.RefObjeto       = lobObjetoServicio;
            lobRegVista.IdRegistro      = tobTmpOrdenserv.Hcl_nroreg_hcms;
            lobRegVista.RegEventoHist   = tobTmpOrdenserv.Hcl_nroreg_hcev;
            lobRegVista.NumeroAdmision  = tobTmpOrdenserv.Adm_secadm_rgad;
            //lobRegVista.LlaveBusqueda   = fcrGenerarLlaveMs(tobTmpOrdenserv);
            lobRegVista.TipoRegistro    = tobTmpOrdenserv.Hcl_tipreg_hctr;
            lobRegVista.EstadoRegistro  = tobTmpOrdenserv.Sis_estpro_espr;
            lobRegVista.DatoAuxiliar    = "NA";

            lobObjetoServicio.fcvCargarVista(tobTmpOrdenserv.Hcl_nroreg_hcms);

            lobRegVista.LlaveBusqueda       = lobObjetoServicio.LlaveBusqueda;
            lobObjetoServicio.LlaveBusqueda = String.Empty;
            tmpRegistro.Add(lobRegVista);
            this.stkContenedor.Children.Add(lobObjetoServicio);

            return lobObjetoServicio;
        }
        #endregion
        #region fcrGenerarLlaveMs: Generar llave de busquda para el objeto
        /// <summary>
        /// <para>Generar llave de busquda para el objeto</para>
        /// </summary>
        public String fcrGenerarLlaveMs(ModeloHclregordeserms tobRegistro)
        {
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + " " + tobRegistro.Adm_secadm_rgad + " " + tobRegistro.Hcl_nroreg_hcms;
            var lcrllave2 = tobRegistro.Hcl_gesfec_hcms.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + " " + tobRegistro.Sia_desare_aser;

            return lcrllave1 + " " + lcrllave2 + " " + lcrllave3;
        }
        #endregion
        #region fcvEliminarRegistroMs: Eliminar Registros
        /// <summary>
        /// <para>Eliminar Registros</para>
        /// </summary>
        public bool flgEliminarRegistroMs()
        {
            var llgReturn = false;
            var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoControl, gcrCodigoAdmision, "1");
            if (lobReg.Count != 0)
            {
                var tmpRegMaestro = lobReg.FirstOrDefault();
                ModeloHclregordeserms.fcvEliminar(tmpRegMaestro.Hcl_nroreg_hcms);

                var lobDetall = ModeloHclregordeserde.flsListaHclregordeserde("R1", tmpRegMaestro.Hcl_nroreg_hcms);

                if (lobDetall.Count != 0 && lobDetall != null) 
                {
                    foreach (var lobRegDtalle in lobDetall)
                    {
                        ModeloHclregordeserde.fcvEliminar(lobRegDtalle.Hcl_nroreg_hcor);
                    }
                }
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region flgEliminarRegistroMsRecursos: Eliminar Registros recursos
        /// <summary>
        /// <para>Eliminar Registros recursos</para>
        /// </summary>
        public bool flgEliminarRegistroMsRecursos()
        {
            var llgReturn = false;
            if (tmpRegistro == null || tmpRegistro.Count == 0) { return llgReturn; }

            var lobRegMs = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoControl, gcrCodigoAdmision, "1");
            if (lobRegMs.Count != 0)
            {
                var tmpRegMaestro = lobRegMs.FirstOrDefault();
                ModeloHclregordeserms.fcvEliminar(tmpRegMaestro.Hcl_nroreg_hcms);

                // Eliminar los archivos de recursos
                var lobReg = tmpRegistro.FirstOrDefault(x => x.IdRegistro == tmpRegMaestro.Hcl_nroreg_hcms);
                if (lobReg != null)
                {
                    // Liberar los objetos
                    var lobRef = lobReg.RefObjeto as ControlOrdServicios;
                    if (lobRef != null)
                    {
                        llgReturn = true;
                        lobRef.flgLiberarRegRecurso();
                        this.stkContenedor.Children.Remove(lobRef);
                        Thread.Sleep(100);
                        fcvEliminarMsRecursoDetalles(tmpRegMaestro.Hcl_nroreg_hcms);
                    }
                }
            }
            return llgReturn;
        }
        #endregion
        #region fcvEliminarMsRecursoDetalles: Eliminar los registros detalles de recursos
        /// <summary>
        /// <para>Eliminar los registros detalles del registro maestro dado</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrCodigo: Codigo unico del registro archivo en maestro de recursos</para>
        /// </summary>
        public void fcvEliminarMsRecursoDetalles(String tcrCodigo)
        {
            var lobDetall = ModeloHclhistarchivos.flsListaHclhistarchivos("R1", tcrCodigo);

            foreach (var lobReg in lobDetall)
            {
                var lcrRutaRecurso = Funciones.fcrGenRutaArchivoRecurso(lobReg.Hcl_rutarc_hclr);
                var lcrArchivoDestino = Funciones.fcrSystemIOPathCombine(lobReg.Hcl_nomarc_hclr, lcrRutaRecurso, false).ToLower();

                // Eliminar fisicamente el archivo
                if (File.Exists(@lcrArchivoDestino.ToLower()))
                {
                    File.Delete(@lcrArchivoDestino);
                }
                ModeloHclhistarchivos.fcvEliminar(tcrCodigo);
            }
        }
        #endregion
        #region fcvEliminarRegistroNm: Eliminar Registros notas medicas
        /// <summary>
        /// <para>Eliminar Registros</para>
        /// </summary>
        public bool fcvEliminarRegistroNm()
        {
            var llgReturn = false;
            var lobReg = ModeloHclregordeserms.flsListaHclregordesermsEx(gcrTipoControl, gcrCodigoAdmision, "1");
            if (lobReg.Count != 0)
            {
                var tmpRegMaestro = lobReg.FirstOrDefault();
                ModeloHclregordeserms.fcvEliminar(tmpRegMaestro.Hcl_nroreg_hcms);

                var lobDetall = ModeloHclregnotasmedi.flsListaHclregnotasmedi("R1", tmpRegMaestro.Hcl_nroreg_hcms);

                if (lobDetall.Count != 0 && lobDetall != null)
                {
                    foreach (var lobRegDtalle in lobDetall)
                    {
                        ModeloHclregnotasmedi.fcvEliminar(lobRegDtalle.Hcl_nroreg_hcnm);
                    }
                }
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        // HCLREGBLIQIDOMS: BALANCE DE LIQUIDOS GESTION VISTA DATOS
        //------------------------------------------------------------
        #region flgCargarRegistroBl: Cargar Vista balance de liquidis en la vista
        /// <summary>
        /// <para>Cargar Vista balance de liquidis en la vista</para>
        /// <para>Verifica si ya existe la vista del objeto y lo actualiza o lo crea</para>
        /// </summary>
        public bool flgCargarRegistroBl(String tcrCodigoUnico)
        {
            var lcrReturn = false;
            var lobReg = ModeloHclregbliqidoms.flsListaHclregbliqidomsEx("1", tcrCodigoUnico, "");
            if (lobReg.Count != 0)
            {
                var lobTmpMs = lobReg.FirstOrDefault();
                var lobRegHist = fobRegSelectRegistro("REGISTRO", tcrCodigoUnico);
                if (lobRegHist == null || lobRegHist.Count == 0)
                {
                    fcvCargarVista(gcrCodigoAdmision);
                }
                else
                {
                    var lobObjetoServicio = lobRegHist.FirstOrDefault().RefObjeto as ControlOrdBliquidos;
                    lobObjetoServicio.fcvCargarVista(tcrCodigoUnico);

                    lobRegHist.FirstOrDefault().LlaveBusqueda = lobObjetoServicio.LlaveBusqueda;
                    lobObjetoServicio.LlaveBusqueda = String.Empty;
                    lobRegHist.FirstOrDefault().EstadoRegistro = lobTmpMs.Sis_estpro_espr;
                    fcvValidarEstadoEdicion();
                }
            }
            return lcrReturn;
        }
        #endregion
        #region fobGenerarObjetoBalanceLiquidos: Mostrar servicios en la vista
        /// <summary>
        /// <para>Generar Objeto ControlOrdServicios para mostrar servicios en la vista</para>
        /// </summary>
        public ControlOrdBliquidos fobGenerarObjetoBalanceLiquidos(ModeloHclregbliqidoms tobTmpOrdenserv)
        {
            var lobObjetoServicio = new ControlOrdBliquidos();
            var lobRegVista = new Utilidades.ClassRegistroVista();

            lobRegVista.LlaveAuxiliar   = "BALANCELIQUIDOS";
            lobRegVista.RefObjeto       = lobObjetoServicio;
            lobRegVista.IdRegistro      = tobTmpOrdenserv.Hcl_nroreg_hcbm;
            lobRegVista.RegEventoHist   = tobTmpOrdenserv.Hcl_nroreg_hcev;
            lobRegVista.NumeroAdmision  = tobTmpOrdenserv.Adm_secadm_rgad;
            //lobRegVista.LlaveBusqueda = fcrGenerarLlaveBl(tobTmpOrdenserv);
            lobRegVista.TipoRegistro    = "BLIQ";
            lobRegVista.EstadoRegistro  = tobTmpOrdenserv.Sis_estpro_espr;
            lobRegVista.DatoAuxiliar    = "NA";

            lobObjetoServicio.fcvCargarVista(tobTmpOrdenserv.Hcl_nroreg_hcbm);

            lobRegVista.LlaveBusqueda = lobObjetoServicio.LlaveBusqueda;
            lobObjetoServicio.LlaveBusqueda = String.Empty;
            tmpRegistro.Add(lobRegVista);
            this.stkContenedor.Children.Add(lobObjetoServicio);

            return lobObjetoServicio;
        }
        #endregion
        #region fcrGenerarLlaveBl: Generar llave de busquda para el objeto
        /// <summary>
        /// <para>Generar llave de busquda para el objeto</para>
        /// </summary>
        public String fcrGenerarLlaveBl(ModeloHclregbliqidoms tobRegistro)
        {
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + " " + tobRegistro.Adm_secadm_rgad + " " + tobRegistro.Hcl_nroreg_hcbm;
            var lcrllave2 = tobRegistro.Hcl_fecape_hcbm.ToShortDateString() + "" + tobRegistro.Hcl_feccie_hcbm.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + " " + tobRegistro.Sia_desare_aser;

            return lcrllave1 + " " + lcrllave2 + " " + lcrllave3;
        }
        #endregion
        #region flgEliminarRegistroBl: Eliminar Registros
        /// <summary>
        /// <para>Eliminar Registros</para>
        /// </summary>
        public bool flgEliminarRegistroBl()
        {
            var llgReturn = false;
            var lobReg = ModeloHclregbliqidoms.flsListaHclregbliqidomsEx("2", gcrCodigoAdmision, "1");
            if (lobReg.Count != 0)
            {
                var tmpRegMaestro = lobReg.FirstOrDefault();
                ModeloHclregbliqidoms.fcvEliminar(tmpRegMaestro.Hcl_nroreg_hcbm);

                var lobDetall = ModeloHclregbliqidode.flsListaHclregbliqidode("R1", tmpRegMaestro.Hcl_nroreg_hcbm);

                if (lobDetall.Count != 0 && lobDetall != null)
                {
                    foreach (var lobRegDtalle in lobDetall)
                    {
                        ModeloHclregbliqidode.fcvEliminar(lobRegDtalle.Hcl_nroreg_hcbd);
                    }
                }
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        // ODNEVENTOSACTMS:	 Tratamiento de odontologia
        //------------------------------------------------------------
        #region flgCargarVistaRegMaestroOdontologia: Cargar el registro de apertura o cierre de odontologia
        /// <summary>
        /// <para>Cargar el registro de apertura o cierre de odontologia</para>
        /// <para>tcrTipoVista:  "1"= Registro Apertura tratammiento odontólgico "2"= Registro cierre tratammiento odontólgico</para>
        /// <para>tcrTipoRegistro:  "1"= Consulta por IG maestro tratamiento "2"= Consulta por codigo Admision paciente</para>
        /// </summary>
        public ModeloOdnMaestroTratamiento fobCargarVistaRegMaestroOdontologia(String tcrTipoVista, String tcrTipoRegistro, String tcrIdCodigo)
        {
            var lobTmpReg = ModeloOdnMaestroTratamiento.flsListaOdneventosmaestEx(tcrTipoRegistro, tcrIdCodigo);
            ModeloOdnMaestroTratamiento lobTmpMs = null;

            // intentar cargar registro por id unico en el sistema
            if (lobTmpReg == null)
            {
                lobTmpReg = ModeloOdnMaestroTratamiento.flsListaOdneventosmaestEstado(gobRegAdmision.Sia_idesec_usua, "1");
            }

            // cargar vista
            if (lobTmpReg != null && lobTmpReg.Count != 0)
            {
                lobTmpMs = lobTmpReg.FirstOrDefault();
                // cuando sea registro de cierre y no esta cerrado el tratamiento 
                if (tcrTipoVista == "2" && lobTmpMs.Odn_estado_odev == "1") { return lobTmpMs; }

                var lobObjetoVista = new ControlOrdOdontoCierre();
                var lcrUri = "/GestorReportes;component/Imagenes/";
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                var lcrTitulo = tcrTipoVista == "1" ? "Registro Apertura tratamiento" : "Registro Cierre tratamiento";
                var lcrObserv = tcrTipoVista == "1" ? lobTmpMs.Odn_obsape_odev : lobTmpMs.Odn_obscie_odev;
                var lcrFecha  = tcrTipoVista == "1" ? lobTmpMs.Odn_fecape_odev.ToShortDateString() : lobTmpMs.Odn_feccie_odev.ToShortDateString();

                // Datos del registro 
                lobObjetoVista.txtG1Hcl_desreg_hctr.Text  = lcrTitulo;
                lobObjetoVista.txtG1Odn_nroreg_odac.Text  = lobTmpMs.Odn_nroreg_odev;
                lobObjetoVista.txtG1Hcl_gesfec_hcms.Text  = lcrFecha;
                lobObjetoVista.txtG1Sia_codpfa_prof.Text  = lobTmpMs.Sia_codpfa_prof;
                lobObjetoVista.txtG1Sia_nompro_prof.Text  = lobTmpMs.Sia_nompro_prof;
                lobObjetoVista.txtG1Sia_desare_aser.Text  = lobTmpMs.Sia_desare_aser;
                lobObjetoVista.txtObservacion.Text        = lcrObserv;
                lobObjetoVista.txtG1Sis_despro_espr.Text  = lobTmpMs.Sis_despro_espr;
                lobObjetoVista.txtG1Odn_estado_odev.Text  = fcrEstadoRegTratamOdontologia(lobTmpMs.Odn_estado_odev);

                var LlaveBusqueda = (lcrObserv +" "+ lcrTitulo).ToLower();

                if (lobTmpMs.Sis_estpro_espr == "2") // confirmado 
                {
                    lobObjetoVista.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_confirmado.png", UriKind.RelativeOrAbsolute));
                }
                else if (lobTmpMs.Sis_estpro_espr == "3") // Anulado
                {
                    lobObjetoVista.imgEstado.Source = new BitmapImage(new Uri(lcrUri + "Edt_hist_vista_anulado.png", UriKind.RelativeOrAbsolute));
                }

                // agregar a vista historial
                var lobRegVista = new Utilidades.ClassRegistroVista();

                lobRegVista.LlaveAuxiliar   = "APER-TRATAM-ODONTOLOGIA";
                lobRegVista.RefObjeto       = lobObjetoVista;
                lobRegVista.IdRegistro      = lobTmpMs.Odn_nroreg_odev;
                lobRegVista.RegEventoHist   = lobTmpMs.Hcl_nroreg_hcev;
                lobRegVista.NumeroAdmision  = gcrCodigoAdmision;
                lobRegVista.TipoRegistro    = "ODAP";
                lobRegVista.EstadoRegistro  = lobTmpMs.Sis_estpro_espr;
                lobRegVista.ClickRefObjeto  = "2";
                lobRegVista.LlaveBusqueda   = LlaveBusqueda;
                lobRegVista.DatoAuxiliar    = "NA";

                tmpRegistro.Add(lobRegVista);
                this.stkContenedor.Children.Add(lobObjetoVista);


            }
            return lobTmpMs;
        }
        #endregion
        #region flgCargarRegistroOdont: Cargar un registro actividad de un tratamiento y sus detalles
        /// <summary>
        /// <para>Cargar un registro actividad de un tratamiento y sus detalles en la vista</para>
        /// <para>Verifica si ya existe la vista del objeto y lo actualiza o lo crea</para>
        /// </summary>
        public bool flgCargarRegistroOdont(String tcrCodigoUnico)
        {
            var lcrReturn = false;
            var lobReg = ModeloOdnMsActivTratamiento.flsListaOdneventosactms("IG", tcrCodigoUnico);
            if (lobReg.Count != 0)
            {
                var lobTmpMs = lobReg.FirstOrDefault();
                var lobRegHist = fobRegSelectRegistro("REGISTRO", tcrCodigoUnico);
                if (lobRegHist == null || lobRegHist.Count == 0)
                {
                    // Cuando no hay registro en el temporal del control , se genera toda la vista
                    fcvCargarVista(gcrCodigoAdmision);
                }
                else
                {
                    var lobObjetoServicio = lobRegHist.FirstOrDefault().RefObjeto as ControlOrdOdontoServicios;
                    lobObjetoServicio.fcvCargarVista(tcrCodigoUnico);

                    lobRegHist.FirstOrDefault().LlaveBusqueda = lobObjetoServicio.LlaveBusqueda;
                    lobObjetoServicio.LlaveBusqueda = String.Empty;
                    lobRegHist.FirstOrDefault().EstadoRegistro = lobTmpMs.Sis_estpro_espr;
                    fcvValidarEstadoEdicion();
                }
            }
            else 
            {
                // por si es el nuevo registro maestro
                fobCargarVistaRegMaestroOdontologia("1", "1", tcrCodigoUnico);
            }
            return lcrReturn;
        }
        #endregion
        #region fobGenerarObjetoMsActividadTratamiento: Mostrar actividad tratamiento en la vista
        /// <summary>
        /// <para>Generar Objeto ControlOrdOdontoServicios para mostrar una actividad en la vista</para>
        /// </summary>
        public ControlOrdOdontoServicios fobGenerarObjetoMsActividadTratamiento(ModeloOdnMsActivTratamiento tobTmpOrdenserv)
        {
            var lobObjetoServicio = new ControlOrdOdontoServicios();
            var lobRegVista = new Utilidades.ClassRegistroVista();

            lobRegVista.RefObjeto       = lobObjetoServicio;
            lobRegVista.LlaveAuxiliar   = "ODONTOGRAMA";
            lobRegVista.IdRegistro      = tobTmpOrdenserv.Odn_nroreg_odac;
            lobRegVista.RegEventoHist   = tobTmpOrdenserv.Hcl_nroreg_hcev;
            lobRegVista.NumeroAdmision  = tobTmpOrdenserv.Adm_secadm_rgad;
            //lobRegVista.LlaveBusqueda = fcrGenerarLlaveOdn(tobTmpOrdenserv);
            lobRegVista.TipoRegistro    = tobTmpOrdenserv.Hcl_tipreg_hctr; // Aqui es: ODDX, ODTR, ODCX y ODEV
            lobRegVista.EstadoRegistro  = tobTmpOrdenserv.Sis_estpro_espr;
            lobRegVista.ClickRefObjeto  = "2";
            lobRegVista.DatoAuxiliar    = tobTmpOrdenserv.Odn_estact_odac;

            lobObjetoServicio.fcvCargarVista(tobTmpOrdenserv.Odn_nroreg_odac);

            lobRegVista.LlaveBusqueda = lobObjetoServicio.LlaveBusqueda;
            lobObjetoServicio.LlaveBusqueda = String.Empty;
            tmpRegistro.Add(lobRegVista);
            this.stkContenedor.Children.Add(lobObjetoServicio);

            return lobObjetoServicio;
        }
        #endregion
        #region fcrGenerarLlaveOdn: Generar llave de busquda para el objeto
        /// <summary>
        /// <para>Generar llave de busquda para el objeto</para>
        /// </summary>
        public String fcrGenerarLlaveOdn(ModeloOdnMsActivTratamiento tobRegistro)
        {
            var lcrllave1 = tobRegistro.Hcl_nroreg_hcev + " " + tobRegistro.Adm_secadm_rgad + " " + tobRegistro.Odn_nroreg_odac;
            var lcrllave2 = tobRegistro.Odn_fecact_odac.ToShortDateString();
            var lcrllave3 = tobRegistro.Sia_nompro_prof + " " + tobRegistro.Sia_desare_aser;

            return lcrllave1 + " " + lcrllave2 + " " + lcrllave3;
        }
        #endregion
        #region flgEliminarRegistroOdn: Eliminar Registros
        /// <summary>
        /// <para>Eliminar Registros</para>
        /// </summary>
        public bool flgEliminarRegistroOdn()
        {
            var llgReturn = false;
            var lobReg = ModeloOdnMsActivTratamiento.flsListaOdneventosactmsEx("2", gcrCodigoAdmision, "1");
            if (lobReg.Count != 0)
            {
                var tmpRegMaestro = lobReg.FirstOrDefault();
                ModeloOdnMsActivTratamiento.fcvEliminar(tmpRegMaestro.Odn_nroreg_odac);

                var lobDetall = ModeloOdnDeActivTratamiento.flsListaOdneventosactde("R1", tmpRegMaestro.Odn_nroreg_odac);

                if (lobDetall.Count != 0 && lobDetall != null)
                {
                    foreach (var lobRegDtalle in lobDetall)
                    {
                        ModeloOdnDeActivTratamiento.fcvEliminar(lobRegDtalle.Odn_nroreg_odde);
                    }
                }
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region fcrEstadoRegTratamOdontologia: Devuelve descripcion estado tratamiento odontologico
        /// <summary>
        /// <para>Devuelve descripcion estado tratamiento odontológico</para>
        /// <para></para>
        /// </summary>
        public String fcrEstadoRegTratamOdontologia(String tcrEstado)
        {
            var lcrReturn = "Abierto para gestión tratamiento";
            switch (tcrEstado)
            {
                case "1":
                    lcrReturn = "Abierto para gestión tratamiento";
                    break;

                case "2":
                    lcrReturn = " Finalizado plan de tratamiento con éxito";
                    break;

                case "3":
                    lcrReturn = " Finalizado sin completar plan tratamiento";
                    break;

            }
            return lcrReturn;
        }
        #endregion
        //------------------------------------------------------------
        // GESTION  FILTR DE BUSQUEDA
        //------------------------------------------------------------
        #region Filtrar Vista Browser
        private void crtBuscarLoaded(object sender, RoutedEventArgs e)
        {
            crtBuscar lobControl = (crtBuscar)sender;
            lobControl.txtBuscar.TextChanged += new TextChangedEventHandler(fcvFiltroTextChanged);
        }
        private void fcvFiltroTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lobTexto = (TextBox)sender;
            fcvVistaHistorialFiltro(lobTexto.Text);
        }
        #endregion
        #region fcvVistaHistorialFiltro: filtro acercado del historial de eventos en el muro
        /// <summary>
        /// <para>filtro acercado de todos los registros exitentes en la vista </para>
        /// </summary>
        public void fcvVistaHistorialFiltro(String tcrTexto)
        {
            if (tmpRegistro == null || tmpRegistro.Count == 0) { return; }

            var lcrTexto = tcrTexto.ToLower();
            foreach (var lobReg in tmpRegistro)
            {
                var lobTile = lobReg.RefObjeto as FrameworkElement;
                lobTile.Visibility = Visibility.Visible;

                if (!String.IsNullOrWhiteSpace(tcrTexto))
                {
                    if (lobReg.LlaveBusqueda != null)
                    {
                        if (!lobReg.LlaveBusqueda.Contains(lcrTexto))
                        {
                            lobTile.Visibility = Visibility.Collapsed;
                        }
                    }
                    else
                    {
                        lobTile.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
        #endregion
        //------------------------------------------------------------
        // GESTION EDICION REGISTRO
        //------------------------------------------------------------
        #region fcvEliminarRegMaestro: Activar tipo ventana captura
        /// <summary>
        /// <para>Eliminar registro maestro</para>
        /// </summary>
        private void fcvEliminarRegMaestro(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                switch (gcrTipoControl)
                {
                    case "SERV":
                        if (flgEliminarRegistroMs())
                        {
                            fcvCargarVista(gcrCodigoAdmision);
                        }
                        break;

                    case "FMED":
                        if (flgEliminarRegistroMs())
                        {
                            fcvCargarVista(gcrCodigoAdmision);
                        }
                        break;

                    case "HCON":
                        if (flgEliminarRegistroMs())
                        {
                            fcvCargarVista(gcrCodigoAdmision);
                        }
                        break;

                    case "EVOL":
                        if (fcvEliminarRegistroNm())
                        {
                            fcvCargarVista(gcrCodigoAdmision);
                        }
                        break;

                    case "NENF":
                        if (fcvEliminarRegistroNm())
                        {
                            fcvCargarVista(gcrCodigoAdmision);
                        }
                        break;

                    case "BLIQ":
                        if (flgEliminarRegistroBl())
                        {
                            fcvCargarVista(gcrCodigoAdmision);
                        }
                        break;

                    case "ODAP":
                        if (flgEliminarRegistroOdn())
                        {
                            fcvCargarVista(gcrCodigoAdmision);
                        }
                        break;

                    case "MED":
                        break;

                    case "DIAG":
                        break;

                    default:
                        var lcrTipo = gcrTipoControl;
                        if (lcrTipo == "RDOC" || lcrTipo == "RXLS" || lcrTipo == "RPDF"
                        || lcrTipo == "RIMG" || lcrTipo == "RVID" || lcrTipo == "RXML"
                        || lcrTipo == "RHL7")
                        {
                            if (flgEliminarRegistroMsRecursos())
                            {
                                fcvCargarVista(gcrCodigoAdmision);
                            }
                        }
                        break;

                }

            }
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Datos.Modelos;
using System.Windows;
using Sistema.Utilidades;
using ConsultaExterna.Utilidades;

namespace ConsultaExterna.VistaModelo
{
    class clTilesConsultaExterna
    {
        //-----------------------------------
        //- Clase Cargar Browser de la tabla
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerTabla
        {
            public BrowerTabla() { }
            public String Adm_secadm_rgad { get; set; }
            public String Sia_idesec_usua { get; set; }
            public String Sia_tipide_tide { get; set; }
            public String Sia_nroide_usua { get; set; }
            public String Hcl_nrohis_hicl { get; set; }
            public String Cit_codasi_mcit { get; set; }
            public DateTime Adm_fecadm_rgad { get; set; }
            public Decimal Adm_horadm_rgad { get; set; }
            public String Sia_codare_aser { get; set; }
            public String Sia_areing_aser { get; set; }
            public String Fcm_codcpr_cpro { get; set; }
            public String Cto_seccon_cont { get; set; }
            public String Cto_nrocon_cont { get; set; }
            public String Sia_codeps_teps { get; set; }
            public String Sia_edaymd_usua { get; set; }
            public String Sia_codpfa_prof { get; set; }
            public int Adm_secite_rgad { get; set; }
            public String Sia_regate_rgat { get; set; }
            public DateTime Adm_fecedt_rgad { get; set; }
            public String Sis_estpro_espr { get; set; }
            public String Sia_nomusu_usua { get; set; }
            public String Sia_desare_aser { get; set; }
            public String Sia_deseps_teps { get; set; }
            public String Sia_nompro_prof { get; set; }
            public String Cit_codspr_spro { get; set; }
            public DateTime Cit_feccit_mcit { get; set; }
            public int Cit_ordcon_mcit { get; set; }
            public String Adm_estrad_rgad { get; set; } 
            public String Adm_ctarip_rgad { get; set; }
            public String Sis_despro_espr { get; set; }
            public String Cit_codtur_turn { get; set; }
            public String Sit_destur_turn { get; set; }
            public String Sia_desdia_tdia { get; set; }
            public String Cit_destur_turn { get; set; }
            public String Cit_desspr_spro { get; set; }
            public String Fcm_descpr_cpro { get; set; }
        
        }
        #endregion
        // Array de tipo Diccionario para el manejo de las rutas e iconos de los módulos y componentes para los tiles.
        public Dictionary<string, string[]> garDicRutaseIconos = new Dictionary<string, string[]>();
        public List<BrowerTabla> gobListaRegistros = new List<BrowerTabla>();
        //----------------------------------------------------------------------
        // fcArListaMenuTilesTurnos : Menu Cargar lista de Turnos por  profesional 
        //----------------------------------------------------------------------
        #region fcArListaMenuTiles : Menu Cargar lista de Turnos por  profesional
        /// <summary>
        /// Devuelve una estructura tipo Diccionario para cargar lista registros
        /// de ad admisión y el manejo de las rutas e iconos para los tiles. 
        /// <para>PARAMETROS:</para>
        /// <para>tcrVistaTipoRegistros : "EST"= Filtro por estado  y grupo "FIL"= Cuando es un filtro y lista de Turnos "ADM" = Lista de Regisros de admisión </para>
        /// <para>tcrVistaEstadoRegistro: "1"=Abierto "2"=Cerrado "3"= Anulado "T" =Todos</para>
        /// <para>tcrVistaAgrupar       : "TR"= Turno programado "SE"=Servicio o Programa, "DX"=Diagnostico, "AR"=Area servicio,"SH"= Seccion hospitalizacion,"PR"=Profesonal del serviciom </para>
        /// <para>tcrCampoVista         : Campo a mostrar en en Tile ->  "TR"= Turno programado, "DX"=Diagnostico "SE"=Servicio o Programa, "PR" = Profesional "AR"=Area del Servicio</para>
        /// <para>tcrVistaLista         : lista de Codigos registros de atencion separada por coma (,) dada desde Ventana filtro</para>
        /// </summary>
        public Dictionary<string, string[]> fcArListaMenuTiles(String tcrTipoRegistros, String tcrEstadoRegistro, String tcrAgrupar, String tcrCampoVista, String tcrLista)
        {
            switch (tcrTipoRegistros)
            {
                case "EST": // Filtro por estado  y grupo 
                    //fcvFiltroEstados(tcrEstadoRegistro, tcrAgrupar);
                    break;

                case "FIL": // Filtro por codigos de turnos (desde Ventana Filtro)
                    fcvFiltroTurnos(tcrAgrupar, tcrCampoVista, tcrLista);
                    break;

                case "ADM": // Filtro por registros de admision (desde Ventana Filtro por usuarios admitidos)
                    fcvFiltroAdmision(tcrAgrupar, tcrCampoVista, tcrLista);
                    break;
            }
            return garDicRutaseIconos;
        }
        #endregion
        #region fcvListaFiltroAmbulatoriosFecha: Consulta todos registros ambulatorios activos para una fecha y un profesional
        /// <summary>
        /// Consulta todos registros ambulatorios activos para una fecha y un profesional
        /// </summary>
        public Dictionary<string, string[]> fcvListaFiltroAmbulatoriosFecha(DateTime tdaFechaRegistro, String tcrCodigoProfesional, String tcrAgrupar, String tcrCampoVista)
        {
            int lnuIndice = 0;
            int lnuContadorTiles = 0;
            var lcrListaRegAdm = String.Empty;
            var lcrDato = String.Empty;
            garDicRutaseIconos = new Dictionary<string, string[]>();

            using (DbAplicacion db = new DbAplicacion())
            {
                #region Generar la consulta
                //-------------------------------------------------
                gobListaRegistros = (from admregadmision in db.Admregadmision
                                     join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                     join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                     join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                     join citmaesasigcita in db.Citmaesasigcita on admregadmision.cit_codasi_mcit equals citmaesasigcita.cit_codasi_mcit into tmcitmaesasigcita
                                     from usua in tmsiausuarioatend.DefaultIfEmpty()
                                     from aser in tmsiaareapreservi.DefaultIfEmpty()
                                     from teps in tmsiatablaeps.DefaultIfEmpty()
                                     from mcit in tmcitmaesasigcita.DefaultIfEmpty()
                                     where admregadmision.sia_codpfa_prof.Equals(tcrCodigoProfesional) &&
                                           admregadmision.adm_fecadm_rgad == tdaFechaRegistro &&
                                           admregadmision.sia_regate_rgat == "2" &&
                                           admregadmision.sis_estpro_espr != "1"
                                     orderby mcit.cit_codtur_turn, mcit.cit_ordcon_mcit
                                     select new BrowerTabla
                                     {
                                         #region Datos
                                         Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                         Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                         Sia_tipide_tide = admregadmision.sia_tipide_tide,
                                         Sia_nroide_usua = admregadmision.sia_nroide_usua,
                                         Hcl_nrohis_hicl = admregadmision.hcl_nrohis_hicl,
                                         Cit_codasi_mcit = admregadmision.cit_codasi_mcit,
                                         Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                         Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                         Sia_codare_aser = admregadmision.sia_codare_aser,
                                         Sia_areing_aser = admregadmision.sia_areing_aser,
                                         Fcm_codcpr_cpro = admregadmision.fcm_codcpr_cpro,
                                         Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                         Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                         Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                         Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                         Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                         Adm_secite_rgad = admregadmision.adm_secite_rgad != null ? (int)admregadmision.adm_secite_rgad : 0,
                                         Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                         Adm_estrad_rgad = admregadmision.adm_estrad_rgad,
                                         Adm_ctarip_rgad = admregadmision.adm_ctarip_rgad,
                                         Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                         Sia_nomusu_usua = usua.sia_nomusu_usua,
                                         Sia_desare_aser = aser.sia_desare_aser,
                                         Sia_deseps_teps = teps.sia_deseps_teps,
                                         Cit_destur_turn = db.Citmaestroturno.FirstOrDefault(rxp => rxp.cit_codtur_turn == mcit.cit_codtur_turn).cit_destur_turn,
                                         Sis_despro_espr = db.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregadmision.sis_estpro_espr).sis_despro_espr,
                                         Sia_nompro_prof = db.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == admregadmision.sia_codpfa_prof).sia_nompro_prof,
                                         Fcm_descpr_cpro = db.Fcmcenproduccio.FirstOrDefault(rxp => rxp.fcm_codcpr_cpro == admregadmision.fcm_codcpr_cpro).fcm_descpr_cpro,
                                         Cit_desspr_spro = db.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == mcit.cit_codspr_spro).cit_desspr_spro,
                                         Cit_codspr_spro = mcit.cit_codspr_spro,
                                         Cit_ordcon_mcit = mcit.cit_ordcon_mcit != null ? (int)mcit.cit_ordcon_mcit : 0,
                                         Cit_codtur_turn = mcit.cit_codtur_turn,
                                         #endregion
                                     }).ToList();

                #endregion

                // cargar en la lista
                if (gobListaRegistros.Count > 0)
                {
                    lnuIndice = fnuCargarListaConsulta(lnuIndice, tcrAgrupar, tcrCampoVista);
                    lnuContadorTiles++;
                }
                gobListaRegistros = new List<BrowerTabla>();

            }
            return garDicRutaseIconos;
        }
        #endregion
        //----------------------------------------------------------------------
        // fcvFiltroTurnos : Filtro por un o varios turnos en particular
        //----------------------------------------------------------------------
        #region fcvFiltroTurnos : Filtro por un o varios turnos en particular
        /// <summary>
        /// fcvFiltro : Filtro por un o varios turnos en particular
        /// </summary>
        private void fcvFiltroTurnos(String tcrAgrupar, String tcrCampoVista, String tcrCodigoRegistro)
        {
            garDicRutaseIconos = new Dictionary<string, string[]>();
            using (DbAplicacion db = new DbAplicacion())
            {
                int lnuIndice = 0;
                int lnuContadorTiles = 0;
                String lcrCodigoTurno = String.Empty;
                String lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                int i;
                int lnuTotElemtos = Funciones.fnuContarElemListaString(",", tcrCodigoRegistro);
                string[] larArray = tcrCodigoRegistro.Split(',');
                //--------------------------------------------------
                // cargar Registros
                //--------------------------------------------------
                for (i = 0; i < lnuTotElemtos; i++)
                {
                    if (lnuContadorTiles <= 200)
                    {
                        //-------------------------------------------------
                        // Generar la consulta
                        //-------------------------------------------------
                        lcrCodigoTurno = larArray[i].Trim().ToUpper();
                        //-------------------------------------------------
                        #region Ejecuta consulta Grupo para organizar Tiltes
                        switch (tcrAgrupar)
                        {
                            case "TR": // Por Turno programado
                                fcvConsultaGrupoTurnos(lcrCodigoTurno);
                                break;

                            case "SE": // Por Servicios o programa de la Agenda
                                fcvConsultaGrupoServicios(lcrCodigoTurno);
                                break;

                            case "PR": // Por profesional 
                                fcvConsultaGrupoProfesional(lcrCodigoTurno);
                                break;

                            case "AR": // Por area
                                fcvConsultaGrupoAreaServicio(lcrCodigoTurno);
                                break;
                        }
                        #endregion
                        // cargar en la lista
                        if (gobListaRegistros.Count > 0)
                        {
                            lnuIndice = fnuCargarListaConsulta(lnuIndice, tcrAgrupar, tcrCampoVista);
                            lnuContadorTiles++;
                        }
                        gobListaRegistros = new List<BrowerTabla>();
                    }
                }
            }
        }
        #endregion
        //----------------------------------------------------------------------
        // fcvFiltroAdmision : Filtro por un o varios registros de admisión en particular
        //----------------------------------------------------------------------
        #region fcvFiltroAdmision : Filtro por un o varios registros en particular
        /// <summary>
        /// fcvFiltro : Filtro por un o varios registros de admisión en particular
        /// </summary>
        private void fcvFiltroAdmision(String tcrAgrupar, String tcrCampoVista, String tcrLista)
        {
            garDicRutaseIconos = new Dictionary<string, string[]>();
            using (DbAplicacion db = new DbAplicacion())
            {
                int lnuIndice = 0;
                int lnuContadorTiles = 0;
                String lcrCodigoReg = String.Empty;
                String lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                int i;
                int lnuTotElemtos = Funciones.fnuContarElemListaString(",", tcrLista);
                string[] larArray = tcrLista.Split(',');
                //--------------------------------------------------
                // cargar Registros
                //--------------------------------------------------
                for (i = 0; i < lnuTotElemtos; i++)
                {
                    if (lnuContadorTiles <= 200)
                    {
                        //-------------------------------------------------
                        // Generar la consulta
                        //-------------------------------------------------
                        #region Generar la consulta
                        lcrCodigoReg = larArray[i].Trim().ToUpper();
                        //-------------------------------------------------
                        gobListaRegistros = (from admregadmision in db.Admregadmision
                                           join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                           join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                           join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                           join citmaesasigcita in db.Citmaesasigcita on admregadmision.cit_codasi_mcit equals citmaesasigcita.cit_codasi_mcit into tmcitmaesasigcita
                                           from usua in tmsiausuarioatend.DefaultIfEmpty()
                                           from aser in tmsiaareapreservi.DefaultIfEmpty()
                                           from teps in tmsiatablaeps.DefaultIfEmpty()
                                           from mcit in tmcitmaesasigcita.DefaultIfEmpty()
                                             where admregadmision.adm_secadm_rgad.Equals(lcrCodigoReg) && admregadmision.sis_estpro_espr!="1"
                                           orderby mcit.cit_codtur_turn, mcit.cit_ordcon_mcit
                                           select new BrowerTabla
                                           {
                                               #region Datos
                                               Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                               Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                               Sia_tipide_tide = admregadmision.sia_tipide_tide,
                                               Sia_nroide_usua = admregadmision.sia_nroide_usua,
                                               Hcl_nrohis_hicl = admregadmision.hcl_nrohis_hicl,
                                               Cit_codasi_mcit = admregadmision.cit_codasi_mcit,
                                               Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                               Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                               Sia_codare_aser = admregadmision.sia_codare_aser,
                                               Sia_areing_aser = admregadmision.sia_areing_aser,
                                               Fcm_codcpr_cpro = admregadmision.fcm_codcpr_cpro,
                                               Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                               Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                               Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                               Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                               Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                               Adm_secite_rgad = admregadmision.adm_secite_rgad!=null? (int)admregadmision.adm_secite_rgad : 0,
                                               Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                               Adm_estrad_rgad = admregadmision.adm_estrad_rgad,
                                               Adm_ctarip_rgad = admregadmision.adm_ctarip_rgad,
                                               Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                               Sia_nomusu_usua = usua.sia_nomusu_usua,
                                               Sia_desare_aser = aser.sia_desare_aser,
                                               Sia_deseps_teps = teps.sia_deseps_teps,
                                               Cit_destur_turn = db.Citmaestroturno.FirstOrDefault(rxp => rxp.cit_codtur_turn == mcit.cit_codtur_turn).cit_destur_turn,
                                               Sis_despro_espr = db.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregadmision.sis_estpro_espr).sis_despro_espr,
                                               Sia_nompro_prof = db.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == admregadmision.sia_codpfa_prof).sia_nompro_prof,
                                               Fcm_descpr_cpro = db.Fcmcenproduccio.FirstOrDefault(rxp => rxp.fcm_codcpr_cpro == admregadmision.fcm_codcpr_cpro).fcm_descpr_cpro,
                                               Cit_desspr_spro = db.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == mcit.cit_codspr_spro).cit_desspr_spro,
                                               Cit_codspr_spro = mcit.cit_codspr_spro,
                                               Cit_ordcon_mcit = mcit.cit_ordcon_mcit!=null? (int)mcit.cit_ordcon_mcit : 0,
                                               Cit_codtur_turn = mcit.cit_codtur_turn,
                                               #endregion
                                           }).ToList();
                                           //Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                           //Cit_feccit_mcit = (DateTime)mcit.cit_feccit_mcit,

                        #endregion
                        // cargar en la lista
                        if (gobListaRegistros.Count > 0)
                        {
                            lnuIndice = fnuCargarListaConsulta(lnuIndice, tcrAgrupar, tcrCampoVista);
                            lnuContadorTiles++;
                        }
                        gobListaRegistros = new List<BrowerTabla>();
                    }
                }
            }
        }
        #endregion
        //----------------------------------------------------------------------
        // fcvCargarListaConsulta : Cargar lista consulta SQL en Diccionario
        //----------------------------------------------------------------------
        #region Cargar en la lista
        /// <summary>
        /// fcvFiltro : Cargar lista consulta SQL en Diccionario
        /// </summary>
        private int fnuCargarListaConsulta(int tnuIndice, String tcrAgrupar, String tcrCampoVista)
        {
            var lnuIndice = tnuIndice;
            String lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
            using (DbAplicacion db = new DbAplicacion())
            {
                var lcrEstadoReg = "1"; // No antedido
                
                foreach (var p in gobListaRegistros)
                {
                    lcrEstadoReg = "1"; // No antedido por defecto

                    // Atendido por profesional y Rips completado
                    if (p.Adm_estrad_rgad == "2" && p.Adm_ctarip_rgad == "2")
                    { 
                        // Atendido y finalizado
                        lcrEstadoReg ="3";
                    }
                    else if (p.Adm_estrad_rgad == "2" || p.Adm_ctarip_rgad == "2")
                    {
                        lcrEstadoReg = "2";
                    }

                    p.Sia_deseps_teps = p.Sia_deseps_teps != null ? p.Sia_deseps_teps : String.Empty;
                    var lcrOrdenVista1 = p.Cit_ordcon_mcit.ToString().Trim();
                    var lcrOrdenVista2 = String.Empty;
                    var Cit_desspr_spro = String.Empty;
                    var lcrFechaAdmision = p.Adm_fecadm_rgad.ToShortDateString().Trim();
                    var lcrHoraAdmision = Funciones.fcrConvierteHora(p.Adm_horadm_rgad.ToString(), "24", lcrSeparadorDecimal, ":");
                    var lcrTitloAdmision = lcrFechaAdmision + "  - " + lcrHoraAdmision;
                    var lcrFoto = "sys_usu01.png";  // por ahora /  p.Sia_rtfoto_usua este es el campo de la foto
                    var lcrFondo = CEXUtilidades.fcrImagenEstadoRegAtencion(lcrEstadoReg);  // sys_cit03.png
                    var lcrCapa = "sys_panel_fondo2.png";  // sys_cit03.png
                    var lcrNomPaciente = p.Sia_nroide_usua.Trim() + " - " + p.Sia_nomusu_usua.Trim() + "\t\t\t\t" + p.Adm_secadm_rgad.Trim(); ;
                    var lcrEps = p.Sia_codeps_teps.Trim() + " - " + Funciones.fcrNotNull(p.Sia_deseps_teps.Trim(),"NA");
                    //----------------------------------------
                    // Grupo
                    //----------------------------------------
                    #region Grupo para organizar Tiltes
                    var lcrCodigoGrupo = String.Empty;
                    var lcrNombreGrupo = String.Empty;
                    //---------------------
                    switch (tcrAgrupar)
                    {
                        case "TR": // Por Turno programado
                            lcrCodigoGrupo = "SN";
                            lcrNombreGrupo = "SIN TURNO ASIGNADO";
                            if (p.Cit_codtur_turn != null) { lcrCodigoGrupo = p.Cit_codtur_turn.Trim(); }
                            if (p.Cit_destur_turn != null) { lcrNombreGrupo = p.Cit_destur_turn.Trim(); }
                            break;

                        case "SE": // Por Servicios o programa de la Agenda
                            lcrCodigoGrupo = "SN";
                            lcrNombreGrupo = "SIN SERVICIO PROGRAMADO";
                            if (p.Cit_codspr_spro != null) { lcrCodigoGrupo = p.Cit_codspr_spro.Trim(); }
                            if (p.Cit_desspr_spro != null) { lcrNombreGrupo = p.Cit_desspr_spro.Trim(); }
                            break;

                        case "PR": // Por profesional 
                            lcrCodigoGrupo = "SN";
                            lcrNombreGrupo = "SIN PROFESIONAL";
                            if (p.Sia_codpfa_prof != null) { lcrCodigoGrupo = p.Sia_codpfa_prof.Trim(); }
                            if (p.Sia_nompro_prof != null) { lcrNombreGrupo = p.Sia_nompro_prof.Trim(); }
                            break;

                        case "AR": // Por area
                            lcrCodigoGrupo = "SN";
                            lcrNombreGrupo = "SIN AREA DE SERVICIOS";
                            if (p.Sia_codare_aser != null) { lcrCodigoGrupo = p.Sia_codare_aser.Trim(); }
                            if (p.Sia_desare_aser != null) { lcrNombreGrupo = p.Sia_desare_aser.Trim(); }
                            break;

                        case "CP": // Por centro de produccion
                            lcrCodigoGrupo = "SN";
                            lcrNombreGrupo = "SIN CENTRO DE PRODUCCIÓN";
                            if (p.Fcm_codcpr_cpro != null) { lcrCodigoGrupo = p.Fcm_codcpr_cpro.Trim(); }
                            if (p.Fcm_descpr_cpro != null) { lcrNombreGrupo = p.Fcm_descpr_cpro.Trim(); }
                            break;
                    }
                    lcrNombreGrupo = lcrCodigoGrupo + " - " + lcrNombreGrupo;
                    #endregion
                    //----------------------------------------
                    //- Campo a mostrar 
                    //----------------------------------------
                    #region Campo para mostrar en Tiles
                    var lcrCodCampoVista= String.Empty;
                    var lcrNomCampoVista = String.Empty;
                    switch (tcrCampoVista)
                    {
                        case "TR": // Por Turno programado
                            lcrCodCampoVista = "SN";
                            lcrNomCampoVista = "SIN TURNO ASIGNADO";
                            if (p.Cit_codtur_turn != null) { lcrCodCampoVista = p.Cit_codtur_turn.Trim(); }
                            if (p.Cit_destur_turn != null) { lcrNomCampoVista = p.Cit_destur_turn.Trim(); }
                            break;

                        case "SE": // Por Servicios o programa de la Agenda
                            lcrCodCampoVista = "SN";
                            lcrNomCampoVista = "SIN SERVICIO PROGRAMADO";
                            if (p.Cit_codspr_spro != null) { lcrCodCampoVista = p.Cit_codspr_spro.Trim(); }
                            if (p.Cit_desspr_spro != null) { lcrNomCampoVista = p.Cit_desspr_spro.Trim(); }
                            break;

                        case "PR": // Por profesional 
                            lcrCodCampoVista = "SN";
                            lcrNomCampoVista = "SIN PROFESIONAL ASIGNADO";
                            if (p.Sia_codpfa_prof != null) { lcrCodCampoVista = p.Sia_codpfa_prof.Trim(); }
                            if (p.Sia_nompro_prof != null) { lcrNomCampoVista = p.Sia_nompro_prof.Trim(); }
                            break;

                        case "AR": // Por area
                            lcrCodCampoVista = "SN";
                            lcrNomCampoVista = "SIN SERVICIO PROGRAMADO";
                            if (p.Sia_codare_aser != null) { lcrCodCampoVista = p.Sia_codare_aser.Trim(); }
                            if (p.Sia_desare_aser != null) { lcrNomCampoVista = p.Sia_desare_aser.Trim(); }
                            break;

                    }
                    lcrNomCampoVista = lcrCodCampoVista + " - " + lcrNomCampoVista;
                    #endregion
                    //----------------------------------------
                    //- Agregar al Diccionario
                    //----------------------------------------
                    garDicRutaseIconos.Add(p.Adm_secadm_rgad.Trim(), new String[] {lnuIndice.ToString().Trim(),
                                            p.Adm_secadm_rgad.Trim(),lcrTitloAdmision,lcrNomCampoVista,
                                            lcrEps,p.Adm_secadm_rgad.Trim()+" - "+p.Sis_despro_espr.Trim(),lcrNomPaciente,lcrOrdenVista1,lcrOrdenVista2,
                                            lcrFechaAdmision,p.Sia_idesec_usua.Trim(),p.Sia_nroide_usua.Trim(),
                                            lcrFoto,lcrFondo,lcrCapa,"/Sistema;component/Imagenes/",lcrCodigoGrupo,lcrNombreGrupo});
                    lnuIndice++;
                }
            }
            return lnuIndice;
        }
         #endregion
        //----------------------------------------------------------------------
        // CONSULTAS PARAMETRIZADAS
        //----------------------------------------------------------------------
        #region CONSULTAS PARAMETRIZADAS PARA FILTRO
        #region fcvConsultaGrupoTurnos: Consulta Agrupada por turno
        /// <summary>
        /// Consulta Agrupada por turno
        /// </summary>
        private void fcvConsultaGrupoTurnos(String tcrCodigoTurno)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                #region Consulta
                gobListaRegistros = (from admregadmision in db.Admregadmision
                                     join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                     join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                     join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                     join citmaesasigcita in db.Citmaesasigcita on admregadmision.cit_codasi_mcit equals citmaesasigcita.cit_codasi_mcit into tmcitmaesasigcita
                                     from usua in tmsiausuarioatend.DefaultIfEmpty()
                                     from aser in tmsiaareapreservi.DefaultIfEmpty()
                                     from teps in tmsiatablaeps.DefaultIfEmpty()
                                     from mcit in tmcitmaesasigcita.DefaultIfEmpty()
                                     where admregadmision.cit_codasi_mcit.Trim() != "" && 
                                           mcit.cit_codtur_turn.Equals(tcrCodigoTurno) &&
                                           admregadmision.sia_regate_rgat == "2" &&
                                           admregadmision.sis_estpro_espr != "1"
                                     orderby mcit.cit_codtur_turn, mcit.cit_ordcon_mcit
                                     select new BrowerTabla
                                     {
                                         #region Datos
                                         Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                         Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                         Sia_tipide_tide = admregadmision.sia_tipide_tide,
                                         Sia_nroide_usua = admregadmision.sia_nroide_usua,
                                         Hcl_nrohis_hicl = admregadmision.hcl_nrohis_hicl,
                                         Cit_codasi_mcit = admregadmision.cit_codasi_mcit,
                                         Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                         Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                         Sia_codare_aser = admregadmision.sia_codare_aser,
                                         Sia_areing_aser = admregadmision.sia_areing_aser,
                                         Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                         Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                         Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                         Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                         Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                         Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                         Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                         Adm_estrad_rgad = admregadmision.adm_estrad_rgad,
                                         Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                         Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                         Adm_ctarip_rgad = admregadmision.adm_ctarip_rgad,
                                         Sia_nomusu_usua = usua.sia_nomusu_usua,
                                         Sia_desare_aser = aser.sia_desare_aser,
                                         Sia_deseps_teps = teps.sia_deseps_teps,
                                         Cit_destur_turn = db.Citmaestroturno.FirstOrDefault(rxp => rxp.cit_codtur_turn == mcit.cit_codtur_turn).cit_destur_turn,
                                         Sis_despro_espr = db.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregadmision.sis_estpro_espr).sis_despro_espr,
                                         Sia_nompro_prof = db.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == admregadmision.sia_codpfa_prof).sia_nompro_prof,
                                         Cit_desspr_spro = db.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == mcit.cit_codspr_spro).cit_desspr_spro,
                                         Cit_codspr_spro = mcit.cit_codspr_spro,
                                         Cit_feccit_mcit = (DateTime)mcit.cit_feccit_mcit,
                                         Cit_ordcon_mcit = (int)mcit.cit_ordcon_mcit,
                                         Cit_codtur_turn = mcit.cit_codtur_turn,
                                         #endregion
                                     }).ToList();

                #endregion
            }
        }
        #endregion
        #region fcvConsultaGrupoServicios: Consulta Agrupada por Servicios
        /// <summary>
        /// Consulta Agrupada por Servicios
        /// </summary>
        private void fcvConsultaGrupoServicios(String tcrCodigoTurno)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                #region Consulta
                gobListaRegistros = (from admregadmision in db.Admregadmision
                                     join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                     join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                     join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                     join citmaesasigcita in db.Citmaesasigcita on admregadmision.cit_codasi_mcit equals citmaesasigcita.cit_codasi_mcit into tmcitmaesasigcita
                                     from usua in tmsiausuarioatend.DefaultIfEmpty()
                                     from aser in tmsiaareapreservi.DefaultIfEmpty()
                                     from teps in tmsiatablaeps.DefaultIfEmpty()
                                     from mcit in tmcitmaesasigcita.DefaultIfEmpty()
                                     where admregadmision.cit_codasi_mcit.Trim() != "" && 
                                           mcit.cit_codtur_turn.Equals(tcrCodigoTurno) &&
                                           admregadmision.sia_regate_rgat == "2" &&
                                           admregadmision.sis_estpro_espr != "1"
                                     orderby mcit.cit_codspr_spro, admregadmision.sia_codpfa_prof, mcit.cit_codtur_turn
                                     select new BrowerTabla
                                     {
                                         #region Datos
                                         Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                         Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                         Sia_tipide_tide = admregadmision.sia_tipide_tide,
                                         Sia_nroide_usua = admregadmision.sia_nroide_usua,
                                         Hcl_nrohis_hicl = admregadmision.hcl_nrohis_hicl,
                                         Cit_codasi_mcit = admregadmision.cit_codasi_mcit,
                                         Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                         Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                         Sia_codare_aser = admregadmision.sia_codare_aser,
                                         Sia_areing_aser = admregadmision.sia_areing_aser,
                                         Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                         Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                         Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                         Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                         Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                         Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                         Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                         Adm_estrad_rgad = admregadmision.adm_estrad_rgad,
                                         Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                         Adm_ctarip_rgad = admregadmision.adm_ctarip_rgad,
                                         Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                         Sia_nomusu_usua = usua.sia_nomusu_usua,
                                         Sia_desare_aser = aser.sia_desare_aser,
                                         Sia_deseps_teps = teps.sia_deseps_teps,
                                         Cit_destur_turn = db.Citmaestroturno.FirstOrDefault(rxp => rxp.cit_codtur_turn == mcit.cit_codtur_turn).cit_destur_turn,
                                         Sis_despro_espr = db.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregadmision.sis_estpro_espr).sis_despro_espr,
                                         Sia_nompro_prof = db.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == admregadmision.sia_codpfa_prof).sia_nompro_prof,
                                         Cit_desspr_spro = db.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == mcit.cit_codspr_spro).cit_desspr_spro,
                                         Cit_codspr_spro = mcit.cit_codspr_spro,
                                         Cit_feccit_mcit = (DateTime)mcit.cit_feccit_mcit,
                                         Cit_ordcon_mcit = (int)mcit.cit_ordcon_mcit,
                                         Cit_codtur_turn = mcit.cit_codtur_turn,
                                         #endregion
                                     }).ToList();

                #endregion
            }
        }
        #endregion
        #region fcvConsultaGrupoProfesional: Consulta Agrupada por Profesional
        /// <summary>
        /// Consulta Agrupada por Profesional
        /// </summary>
        private void fcvConsultaGrupoProfesional(String tcrCodigoTurno)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                #region Consulta
                gobListaRegistros = (from admregadmision in db.Admregadmision
                                     join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                     join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                     join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                     join citmaesasigcita in db.Citmaesasigcita on admregadmision.cit_codasi_mcit equals citmaesasigcita.cit_codasi_mcit into tmcitmaesasigcita
                                     from usua in tmsiausuarioatend.DefaultIfEmpty()
                                     from aser in tmsiaareapreservi.DefaultIfEmpty()
                                     from teps in tmsiatablaeps.DefaultIfEmpty()
                                     from mcit in tmcitmaesasigcita.DefaultIfEmpty()
                                     where admregadmision.cit_codasi_mcit.Trim() != "" && 
                                           mcit.cit_codtur_turn.Equals(tcrCodigoTurno) &&
                                           admregadmision.sia_regate_rgat == "2" &&
                                           admregadmision.sis_estpro_espr != "1" 
                                     orderby admregadmision.sia_codpfa_prof, mcit.cit_codtur_turn, mcit.cit_ordcon_mcit
                                     select new BrowerTabla
                                     {
                                         #region Datos
                                         Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                         Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                         Sia_tipide_tide = admregadmision.sia_tipide_tide,
                                         Sia_nroide_usua = admregadmision.sia_nroide_usua,
                                         Hcl_nrohis_hicl = admregadmision.hcl_nrohis_hicl,
                                         Cit_codasi_mcit = admregadmision.cit_codasi_mcit,
                                         Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                         Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                         Sia_codare_aser = admregadmision.sia_codare_aser,
                                         Sia_areing_aser = admregadmision.sia_areing_aser,
                                         Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                         Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                         Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                         Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                         Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                         Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                         Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                         Adm_estrad_rgad = admregadmision.adm_estrad_rgad,
                                         Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                         Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                         Adm_ctarip_rgad = admregadmision.adm_ctarip_rgad,
                                         Sia_nomusu_usua = usua.sia_nomusu_usua,
                                         Sia_desare_aser = aser.sia_desare_aser,
                                         Sia_deseps_teps = teps.sia_deseps_teps,
                                         Cit_destur_turn = db.Citmaestroturno.FirstOrDefault(rxp => rxp.cit_codtur_turn == mcit.cit_codtur_turn).cit_destur_turn,
                                         Sis_despro_espr = db.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregadmision.sis_estpro_espr).sis_despro_espr,
                                         Sia_nompro_prof = db.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == admregadmision.sia_codpfa_prof).sia_nompro_prof,
                                         Cit_desspr_spro = db.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == mcit.cit_codspr_spro).cit_desspr_spro,
                                         Cit_codspr_spro = mcit.cit_codspr_spro,
                                         Cit_feccit_mcit = (DateTime)mcit.cit_feccit_mcit,
                                         Cit_ordcon_mcit = (int)mcit.cit_ordcon_mcit,
                                         Cit_codtur_turn = mcit.cit_codtur_turn,
                                         #endregion
                                     }).ToList();

                #endregion
            }
        }
        #endregion
        #region fcvConsultaGrupoAreaServicio: Consulta Agrupada por Area prestacion servicios
        /// <summary>
        /// Consulta Agrupada por Area prestacion servicios
        /// </summary>
        private void fcvConsultaGrupoAreaServicio(String tcrCodigoTurno)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                #region Consulta
                gobListaRegistros = (from admregadmision in db.Admregadmision
                                     join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                     join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                     join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                     join citmaesasigcita in db.Citmaesasigcita on admregadmision.cit_codasi_mcit equals citmaesasigcita.cit_codasi_mcit into tmcitmaesasigcita
                                     from usua in tmsiausuarioatend.DefaultIfEmpty()
                                     from aser in tmsiaareapreservi.DefaultIfEmpty()
                                     from teps in tmsiatablaeps.DefaultIfEmpty()
                                     from mcit in tmcitmaesasigcita.DefaultIfEmpty()
                                     where admregadmision.cit_codasi_mcit.Trim() != "" && 
                                           mcit.cit_codtur_turn.Equals(tcrCodigoTurno) &&
                                           admregadmision.sia_regate_rgat == "2" &&
                                           admregadmision.sis_estpro_espr != "1"
                                     orderby admregadmision.sia_codare_aser, admregadmision.sia_codpfa_prof
                                     select new BrowerTabla
                                     {
                                         #region Datos
                                         Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                         Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                         Sia_tipide_tide = admregadmision.sia_tipide_tide,
                                         Sia_nroide_usua = admregadmision.sia_nroide_usua,
                                         Hcl_nrohis_hicl = admregadmision.hcl_nrohis_hicl,
                                         Cit_codasi_mcit = admregadmision.cit_codasi_mcit,
                                         Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                         Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                         Sia_codare_aser = admregadmision.sia_codare_aser,
                                         Sia_areing_aser = admregadmision.sia_areing_aser,
                                         Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                         Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                         Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                         Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                         Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                         Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                         Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                         Adm_estrad_rgad = admregadmision.adm_estrad_rgad,
                                         Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                         Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                         Adm_ctarip_rgad = admregadmision.adm_ctarip_rgad,
                                         Sia_nomusu_usua = usua.sia_nomusu_usua,
                                         Sia_desare_aser = aser.sia_desare_aser,
                                         Sia_deseps_teps = teps.sia_deseps_teps,
                                         Cit_destur_turn = db.Citmaestroturno.FirstOrDefault(rxp => rxp.cit_codtur_turn == mcit.cit_codtur_turn).cit_destur_turn,
                                         Sis_despro_espr = db.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregadmision.sis_estpro_espr).sis_despro_espr,
                                         Sia_nompro_prof = db.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == admregadmision.sia_codpfa_prof).sia_nompro_prof,
                                         Cit_desspr_spro = db.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == mcit.cit_codspr_spro).cit_desspr_spro,
                                         Cit_codspr_spro = mcit.cit_codspr_spro,
                                         Cit_feccit_mcit = (DateTime)mcit.cit_feccit_mcit,
                                         Cit_ordcon_mcit = (int)mcit.cit_ordcon_mcit,
                                         Cit_codtur_turn = mcit.cit_codtur_turn,
                                         #endregion
                                     }).ToList();

                #endregion
            }
        }
        #endregion
        #region fcrListaTurnosFecha: Consulta turnos activos para una fecha y un profesional
        /// <summary>
        /// Devuelve la lista de turnos activos para una fecha y un profesional
        /// </summary>
        public static String fcrListaTurnosFecha(DateTime tdaFechaTurnos, String tcrCodigoProfesional)
        {
            var lcrTurnosFecha = String.Empty;
            var lcrDato=String.Empty;
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrCodigoProfesional))
                {
                    #region Codigo del profesional
                    var lobLista = (from admregadmision in db.Admregadmision
                                    join citmaesasigcita in db.Citmaesasigcita on admregadmision.cit_codasi_mcit equals citmaesasigcita.cit_codasi_mcit
                                    where admregadmision.cit_codasi_mcit.Trim() != "" &&
                                          admregadmision.sia_codpfa_prof.Equals(tcrCodigoProfesional) &&
                                          admregadmision.adm_fecadm_rgad == tdaFechaTurnos &&
                                          admregadmision.sia_regate_rgat == "2" &&
                                          admregadmision.sis_estpro_espr != "1"
                                    group citmaesasigcita by citmaesasigcita.cit_codtur_turn into tmp1
                                    select tmp1).ToList();
                    //---------------------------------------------
                    //- Generar la String con los codigos de turnos
                    var lcrTurnos = String.Empty;
                    foreach (var lcrCodigoTurno in lobLista)
                    {
                        lcrTurnos = lcrCodigoTurno.FirstOrDefault().cit_codtur_turn;
                        lcrTurnosFecha = String.IsNullOrWhiteSpace(lcrTurnosFecha) ? lcrTurnos : lcrTurnosFecha + "," + lcrTurnos;
                    }
                    #endregion

                }else
                {
                    #region Sin codigo del profesional
                    var lobLista = (from admregadmision in db.Admregadmision
                                    join citmaesasigcita in db.Citmaesasigcita on admregadmision.cit_codasi_mcit equals citmaesasigcita.cit_codasi_mcit 
                                    where admregadmision.cit_codasi_mcit.Trim() != "" &&
                                          admregadmision.sia_regate_rgat == "2" &&
                                          admregadmision.adm_fecadm_rgad == tdaFechaTurnos
                                    group citmaesasigcita by citmaesasigcita.cit_codtur_turn into tmp1
                                    select tmp1).ToList();
                    //---------------------------------------------
                    //- Generar la String con los codigos de turnos
                    var lcrTurnos = String.Empty;
                    foreach (var lcrCodigoTurno in lobLista)
                    {
                        lcrTurnos = lcrCodigoTurno.FirstOrDefault().cit_codtur_turn;
                        lcrTurnosFecha = String.IsNullOrWhiteSpace(lcrTurnosFecha) ? lcrTurnos : lcrTurnosFecha + "," + lcrTurnos;
                    }
                    #endregion
                }
            }
            return lcrTurnosFecha;
        }
        #endregion
        #region fcrListaRegAmbulatoriaFecha: Consulta todos registros ambulatorios activos para una fecha y un profesional
        /// <summary>
        /// Consulta todos registros ambulatorios activos para una fecha y un profesional
        /// </summary>
        public static String fcrListaRegAmbulatoriosFecha(DateTime tdaFechaRegistro, String tcrCodigoProfesional)
        {
            var lcrListaRegAdm = String.Empty;
            var lcrDato = String.Empty;
            List<EFadmregadmision> lobLista = null; 
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrCodigoProfesional))
                {
                    #region Codigo del profesional
                    lobLista = (from admregadmision in db.Admregadmision
                                    where admregadmision.sia_codpfa_prof.Equals(tcrCodigoProfesional) &&
                                          admregadmision.adm_fecadm_rgad == tdaFechaRegistro &&
                                          admregadmision.sia_regate_rgat == "2" &&
                                          admregadmision.sis_estpro_espr != "1"
                                    select admregadmision).ToList();
                    #endregion

                }
                else
                {
                    #region Sin codigo del profesional
                    lobLista = (from admregadmision in db.Admregadmision
                                    where admregadmision.adm_fecadm_rgad == tdaFechaRegistro &&
                                          admregadmision.sia_regate_rgat == "2" &&
                                          admregadmision.sis_estpro_espr != "1"
                                    select admregadmision).ToList();
                    #endregion
                }
                //---------------------------------------------
                //- Generar la String con los codigos de turnos
                var lcrCodRegAdmision = String.Empty;
                foreach (var lobReg in lobLista)
                {
                    lcrCodRegAdmision = lobReg.adm_secadm_rgad;
                    lcrListaRegAdm = String.IsNullOrWhiteSpace(lcrListaRegAdm) ? lcrCodRegAdmision : lcrListaRegAdm + "," + lcrCodRegAdmision;
                }

            }
            return lcrListaRegAdm;
        }
        #endregion
        #region fnuListaRegAmbulatoriaFecha: Cuenta todos registros ambulatorios activos para una fecha y un profesional
        /// <summary>
        /// Cuenta todos registros ambulatorios activos para una fecha y un profesional
        /// </summary>
        public static int fnuTotalRegAmbulatoriosFecha(DateTime tdaFechaRegistro, String tcrCodigoProfesional)
        {
            var lnuTotal = 0;
            List<EFadmregadmision> lobLista = null;

            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrCodigoProfesional))
                {
                    #region Codigo del profesional
                    lobLista = (from admregadmision in db.Admregadmision
                                where admregadmision.sia_codpfa_prof.Equals(tcrCodigoProfesional) &&
                                      admregadmision.adm_fecadm_rgad == tdaFechaRegistro &&
                                      admregadmision.sia_regate_rgat == "2" &&
                                      admregadmision.sis_estpro_espr != "1"
                                select admregadmision).ToList();
                    #endregion

                }
                else
                {
                    #region Sin codigo del profesional
                    lobLista = (from admregadmision in db.Admregadmision
                                where admregadmision.adm_fecadm_rgad == tdaFechaRegistro &&
                                      admregadmision.sia_regate_rgat == "2" &&
                                      admregadmision.sis_estpro_espr != "1"
                                select admregadmision).ToList();
                    #endregion
                }

            }
            if (lobLista!= null){lnuTotal = lobLista.Count;}

            return lnuTotal;
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        //  ACTUALIZAR Diccionario de Tiles02
        //------------------------------------------------------------
        #region fcvActualizDiccTiles02()
        public Dictionary<string, string[]> fcvActualizDiccTiles02(ref Dictionary<string, string[]> tarDiccionarioVista,
                                                ref Dictionary<string, string[]> tarDiccActualizTiles)
        {
            String lcrllave=String.Empty;
            String lcrPrueba = String.Empty;
            garDicRutaseIconos = new Dictionary<string, string[]>();

            foreach (KeyValuePair<string, string[]> lobReDicc in tarDiccionarioVista)
            {
                var lcrCodigo = lobReDicc.Key.Trim(); // el codigo del item en el tiles
                lcrllave = tarDiccActualizTiles.FirstOrDefault(k => k.Key.Equals(lcrCodigo)).Key;
                if (!String.IsNullOrWhiteSpace(lcrllave))
                {
                    lcrPrueba = lcrllave;
                    var lobRegAux = tarDiccActualizTiles.FirstOrDefault(k => k.Key.Trim().Equals(lcrCodigo));
                    //- Actualizar el diccionario
                    lobReDicc.Value[2] = lobRegAux.Value[2].Trim();
                    lobReDicc.Value[3] = lobRegAux.Value[3].Trim();
                    lobReDicc.Value[4] = lobRegAux.Value[4].Trim();
                    lobReDicc.Value[5] = lobRegAux.Value[5].Trim();
                    lobReDicc.Value[6] = lobRegAux.Value[6].Trim();
                    lobReDicc.Value[7] = lobRegAux.Value[7].Trim();
                    lobReDicc.Value[8] = lobRegAux.Value[8].Trim();
                    lobReDicc.Value[9] = lobRegAux.Value[9].Trim();
                    lobReDicc.Value[10] = lobRegAux.Value[10].Trim();
                    lobReDicc.Value[11] = lobRegAux.Value[11].Trim();
                    lobReDicc.Value[12] = lobRegAux.Value[12].Trim();
                    lobReDicc.Value[13] = lobRegAux.Value[13].Trim();
                    lobReDicc.Value[14] = lobRegAux.Value[14].Trim();
                    lobReDicc.Value[15] = lobRegAux.Value[15].Trim();
                }
                garDicRutaseIconos.Add(lobReDicc.Key.Trim(), new String[] {lobReDicc.Value[0],
                                            lobReDicc.Value[1],lobReDicc.Value[2],lobReDicc.Value[3],
                                            lobReDicc.Value[4],lobReDicc.Value[5],lobReDicc.Value[6],
                                            lobReDicc.Value[7],lobReDicc.Value[8],lobReDicc.Value[9],
                                            lobReDicc.Value[10],lobReDicc.Value[11],lobReDicc.Value[12],
                                            lobReDicc.Value[13],lobReDicc.Value[14],lobReDicc.Value[15],
                                            lobReDicc.Value[16],lobReDicc.Value[17]});

            }
            return garDicRutaseIconos;
        }
        #endregion
    }
}

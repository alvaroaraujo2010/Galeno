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
using Hospitalizacion.Utilidades;

namespace Hospitalizacion.VistaModelo
{
    class clTilesAdmision
    {
        // Array de tipo Diccionario para el manejo de las rutas e iconos de los módulos y componentes para los tiles.
        public Dictionary<string, string[]> gArDicRutaseIconos = new Dictionary<string, string[]>();
        //----------------------------------------------------------------------
        // fcArListaMenuTilesTurnos : Menu Cargar lista de Turnos por  profesional 
        //----------------------------------------------------------------------
        #region fcArListaMenuTiles : Menu Cargar lista de Turnos por  profesional
        /// <summary>
        /// Devuelve una estructura tipo Diccionario para cargar lista registros
        /// de ad admisión y el manejo de las rutas e iconos para los tiles. 
        /// <para>PARAMETROS:</para>
        /// <para>tcrVistaTipoRegistros : "1"=Atencion Admitidos "2"=Atención Ambulatoria, "F"=Cuando es un filtro y lista</para>
        /// <para>tcrVistaEstadoRegistro: "1"=Abierto "2"=Cerrado "3"= Anulado "T" =Todos</para>
        /// <para>tcrVistaAgrupar       : "DX"=Diagnostico,"AR"=Area servicio,"SE"=Seccion hospitalizacion,
        /// "PC"=Programación agenda Cita,"PR"=Profesonal del serviciom "PA" = Filtro Profesional Activo en sistema (Usuario Activo)</para>
        /// <para>tcrVistaLista         : lista de Codigos registros de atencion separada por coma (,) dada desde Ventana filtro</para>
        /// </summary>
        public Dictionary<string, string[]> fcArListaMenuTiles(String tcrTipoRegistros, String tcrEstadoRegistro, String tcrAgrupar, String tcrLista)
        {
            switch (tcrTipoRegistros)
            {
                case "1": // Admitidos 
                    fcvMenuAdmitidos(tcrEstadoRegistro, tcrAgrupar);
                    break;

                case "F": // Filtro Avanzado (desde Ventana Filtro)
                    fcvFiltro(tcrLista);
                    break;
            }
            return gArDicRutaseIconos;
        }
        #endregion
        //----------------------------------------------------------------------
        // fcvMenuAdmitidos : Menu Cargar admitidos
        //----------------------------------------------------------------------
        #region fcvMenuAdmitidos : Menu Cargar lista de Turnos por  profesional
        /// <summary>
        /// Devuelve una estructura tipo Diccionario para cargar lista registros
        /// de ad admisión y el manejo de las rutas e iconos para los tiles. 
        /// <para>tcrAgrupar: "DX"=Diagnostico,"AR"=Area servicio,"SE"=Seccion hospitalizacion,"PR"=Profesional del Servicio</para>
        /// </summary>
        private void fcvMenuAdmitidos(String tcrEstadoRegistro, String tcrAgrupar)
        {
            switch (tcrAgrupar)
            {
                case "DX": // Por diagnostico
                    fcvMenuAdmitidos_DX(tcrEstadoRegistro);
                    break;

                case "AR": // Por area
                    fcvMenuAdmitidos_AR(tcrEstadoRegistro);
                    break;
            }
        }
        #endregion
        #region Filtros admitidos
        //----------------------------------------------------------------------
        // fcvMenuAdmitidos_DX : Filtrar admitidos por Diagnostico
        //----------------------------------------------------------------------
        #region fcvMenuAdmitidos_DX : Filtrar admitidos por Diagnostico
        /// <summary>
        ///  Filtrar admitidos por Diagnostico
        /// </summary>
        private void fcvMenuAdmitidos_DX(String tcrEstadoRegistro)
        {
            gArDicRutaseIconos = new Dictionary<string, string[]>();
            using (DbAplicacion db = new DbAplicacion())
            {
                int lnuIndice = 0;
                String lcrCodigoTurno = String.Empty;
                String lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                //-------------------------------------------------
                // Generar la consulta
                //-------------------------------------------------
                if (String.IsNullOrWhiteSpace(tcrEstadoRegistro) || tcrEstadoRegistro == "T")  // Todos
                {
                    #region Generar la consulta
                    var lobConsulta = (from admregadmision in db.Admregadmision
                                       join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join hoscamasareas in db.Hoscamasareas on admregadmision.hos_codcam_caho equals hoscamasareas.hos_codcam_caho into tmhoscamasareas
                                       join siadiagnosticos in db.Siadiagnosticos on admregadmision.sia_dixing_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                       join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                       join sisestadoproces in db.Sisestadoproces on admregadmision.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from caho in tmhoscamasareas.DefaultIfEmpty()
                                       from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                       from teps in tmsiatablaeps.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where admregadmision.sia_regate_rgat.Equals("1")
                                       orderby admregadmision.sia_dixing_tdia
                                       select new
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
                                           Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                           Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                           Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                           Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                           Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                           Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                           Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                           Desia_areing_aser = db.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == admregadmision.sia_areing_aser).sia_desare_aser,
                                           Sia_nomusu_usua = usua.sia_nomusu_usua,
                                           Sia_desare_aser = aser.sia_desare_aser,
                                           Hos_descam_caho = caho.hos_descam_caho,
                                           Sia_desdia_tdia = tdia.sia_desdia_tdia,
                                           Sia_deseps_teps = teps.sia_deseps_teps,
                                           Sis_despro_espr = espr.sis_despro_espr,
                                           #endregion
                                       }).Take(200).ToList();

                    #endregion
                    //-------------------------------------------------
                    // cargar en la lista
                    //-------------------------------------------------
                    #region cargar en la lista
                    foreach (var p in lobConsulta)
                    {
                        var lcrOrdenVista1 = "";
                        var lcrOrdenVista2 = "";
                        var lcrFechaAdmision = p.Adm_fecadm_rgad.ToShortDateString().Trim();
                        var lcrHoraAdmision = Funciones.fcrConvierteHora(p.Adm_horadm_rgad.ToString(), "24", lcrSeparadorDecimal, ":");
                        var lcrTitloAdmision = lcrFechaAdmision + "  - " + lcrHoraAdmision;
                        //---------------------
                        var lcrFoto = "sys_usu01.png";  // por ahora /  p.Sia_rtfoto_usua este es el campo de la foto
                        var lcrFondo = AdmFunciones.fcrImagenEstadoRegAtencion(p.Sis_estpro_espr.Trim());  // sys_cit03.png
                        var lcrCapa = "sys_panel_fondo2.png";  // sys_cit03.png
                        var lcrNomPaciente = p.Sia_nroide_usua.Trim() + " - " + p.Sia_nomusu_usua.Trim() + "\t\t\t\t" + p.Adm_secadm_rgad.Trim();
                        var lcrEps = p.Sia_codeps_teps.Trim() + " - " + p.Sia_deseps_teps.Trim();
                        //---------------------
                        var lcrCodigoGrupo = "SN";
                        var lcrNombreGrupo = "SIN GRUPO";
                        if (p.Sia_dixing_tdia != null) { lcrCodigoGrupo = p.Sia_dixing_tdia.Trim(); }
                        if (p.Sia_desdia_tdia != null) { lcrNombreGrupo = p.Sia_desdia_tdia.Trim(); }
                        lcrNombreGrupo = lcrCodigoGrupo + " - " + lcrNombreGrupo;
                        //---------------------
                        var lcrAreaServicio = "Sin Area servicio";
                        if (p.Sia_desare_aser != null) { lcrAreaServicio = p.Sia_desare_aser.Trim(); }
                        //---------------------
                        gArDicRutaseIconos.Add(p.Adm_secadm_rgad.Trim(), new String[] {lnuIndice.ToString().Trim(),
                                            p.Adm_secadm_rgad.Trim(),lcrTitloAdmision,lcrAreaServicio.Trim(),
                                            lcrEps,p.Sis_despro_espr.Trim(),lcrNomPaciente,lcrOrdenVista1,lcrOrdenVista2,
                                            lcrFechaAdmision,p.Sia_idesec_usua.Trim(),p.Sia_nroide_usua.Trim(),
                                            lcrFoto,lcrFondo,lcrCapa,"/Sistema;component/Imagenes/",lcrCodigoGrupo,lcrNombreGrupo});
                        lnuIndice++;
                    }
                    #endregion
                }
                else
                {
                    #region Generar la consulta
                    var lobConsulta = (from admregadmision in db.Admregadmision
                                       join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join hoscamasareas in db.Hoscamasareas on admregadmision.hos_codcam_caho equals hoscamasareas.hos_codcam_caho into tmhoscamasareas
                                       join siadiagnosticos in db.Siadiagnosticos on admregadmision.sia_dixing_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                       join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                       join sisestadoproces in db.Sisestadoproces on admregadmision.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from caho in tmhoscamasareas.DefaultIfEmpty()
                                       from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                       from teps in tmsiatablaeps.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where admregadmision.sia_regate_rgat.Equals("1") &&
                                             admregadmision.sis_estpro_espr.Equals(tcrEstadoRegistro) &&
                                             admregadmision.adm_finate_rgad=="1"
                                       orderby admregadmision.sia_dixing_tdia
                                       select new
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
                                           Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                           Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                           Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                           Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                           Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                           Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                           Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                           Desia_areing_aser = db.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == admregadmision.sia_areing_aser).sia_desare_aser,
                                           Sia_nomusu_usua = usua.sia_nomusu_usua,
                                           Sia_desare_aser = aser.sia_desare_aser,
                                           Hos_descam_caho = caho.hos_descam_caho,
                                           Sia_desdia_tdia = tdia.sia_desdia_tdia,
                                           Sia_deseps_teps = teps.sia_deseps_teps,
                                           Sis_despro_espr = espr.sis_despro_espr,
                                           #endregion
                                       }).Take(200).ToList();

                    #endregion
                    //-------------------------------------------------
                    // cargar en la lista
                    //-------------------------------------------------
                    #region cargar en la lista
                    foreach (var p in lobConsulta)
                    {
                        var lcrOrdenVista1 = "";
                        var lcrOrdenVista2 = "";
                        var lcrFechaAdmision = p.Adm_fecadm_rgad.ToShortDateString().Trim();
                        var lcrHoraAdmision = Funciones.fcrConvierteHora(p.Adm_horadm_rgad.ToString(), "24", lcrSeparadorDecimal, ":");
                        var lcrTitloAdmision = lcrFechaAdmision + "  - " + lcrHoraAdmision;
                        //---------------------
                        var lcrFoto = "sys_usu01.png";  // por ahora /  p.Sia_rtfoto_usua este es el campo de la foto
                        var lcrFondo = AdmFunciones.fcrImagenEstadoRegAtencion(p.Sis_estpro_espr.Trim());  // sys_cit03.png
                        var lcrCapa = "sys_panel_fondo2.png";  // sys_cit03.png
                        var lcrNomPaciente = p.Sia_nroide_usua.Trim() + " - " + p.Sia_nomusu_usua.Trim() + "\t\t\t\t" + p.Adm_secadm_rgad.Trim();
                        var lcrEps = p.Sia_codeps_teps.Trim() + " - " + p.Sia_deseps_teps.Trim();
                        //---------------------
                        var lcrCodigoGrupo = "SN";
                        var lcrNombreGrupo = "SIN GRUPO";
                        if (p.Sia_dixing_tdia != null) { lcrCodigoGrupo = p.Sia_dixing_tdia.Trim(); }
                        if (p.Sia_desdia_tdia != null) { lcrNombreGrupo = p.Sia_desdia_tdia.Trim(); }
                        lcrNombreGrupo = lcrCodigoGrupo + " - " + lcrNombreGrupo;
                        //---------------------
                        var lcrAreaServicio = "Sin Area servicio";
                        if (p.Sia_desare_aser != null) { lcrAreaServicio = p.Sia_desare_aser.Trim(); }
                        //---------------------
                        gArDicRutaseIconos.Add(p.Adm_secadm_rgad.Trim(), new String[] {lnuIndice.ToString().Trim(),
                                            p.Adm_secadm_rgad.Trim(),lcrTitloAdmision,lcrAreaServicio.Trim(),
                                            lcrEps,p.Sis_despro_espr.Trim(),lcrNomPaciente,lcrOrdenVista1,lcrOrdenVista2,
                                            lcrFechaAdmision,p.Sia_idesec_usua.Trim(),p.Sia_nroide_usua.Trim(),
                                            lcrFoto,lcrFondo,lcrCapa,"/Sistema;component/Imagenes/",lcrCodigoGrupo,lcrNombreGrupo});
                        lnuIndice++;
                    }
                    #endregion
                }
            }
        }
        #endregion
        //----------------------------------------------------------------------
        // fcvMenuAdmitidos_AR : Filtrar admitidos por Area servicios
        //----------------------------------------------------------------------
        #region fcvMenuAdmitidos_AR : Filtrar admitidos por Area servicios
        /// <summary>
        /// Filtrar admitidos por Area servicios
        /// </summary>
        private void fcvMenuAdmitidos_AR(String tcrEstadoRegistro)
        {
            gArDicRutaseIconos = new Dictionary<string, string[]>();
            using (DbAplicacion db = new DbAplicacion())
            {
                int lnuIndice = 0;
                String lcrCodigoTurno = String.Empty;
                String lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                //-------------------------------------------------
                // Generar la consulta
                //-------------------------------------------------
                if (String.IsNullOrWhiteSpace(tcrEstadoRegistro) || tcrEstadoRegistro == "T")  // Todos
                {
                    #region Generar la consulta
                    var lobConsulta = (from admregadmision in db.Admregadmision
                                       join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join hoscamasareas in db.Hoscamasareas on admregadmision.hos_codcam_caho equals hoscamasareas.hos_codcam_caho into tmhoscamasareas
                                       join siadiagnosticos in db.Siadiagnosticos on admregadmision.sia_dixing_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                       join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                       join sisestadoproces in db.Sisestadoproces on admregadmision.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from caho in tmhoscamasareas.DefaultIfEmpty()
                                       from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                       from teps in tmsiatablaeps.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where admregadmision.sia_regate_rgat.Equals("1")
                                       orderby admregadmision.sia_codare_aser
                                       select new
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
                                           Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                           Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                           Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                           Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                           Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                           Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                           Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                           Desia_areing_aser = db.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == admregadmision.sia_areing_aser).sia_desare_aser,
                                           Sia_nomusu_usua = usua.sia_nomusu_usua,
                                           Sia_desare_aser = aser.sia_desare_aser,
                                           Hos_descam_caho = caho.hos_descam_caho,
                                           Sia_desdia_tdia = tdia.sia_desdia_tdia,
                                           Sia_deseps_teps = teps.sia_deseps_teps,
                                           Sis_despro_espr = espr.sis_despro_espr,
                                           #endregion
                                       }).Take(200).ToList();

                    #endregion
                    //-------------------------------------------------
                    // cargar en la lista
                    //-------------------------------------------------
                    #region cargar en la lista
                    foreach (var p in lobConsulta)
                    {
                        var lcrOrdenVista1 = "";
                        var lcrOrdenVista2 = "";
                        var lcrFechaAdmision = p.Adm_fecadm_rgad.ToShortDateString().Trim();
                        var lcrHoraAdmision = Funciones.fcrConvierteHora(p.Adm_horadm_rgad.ToString(), "24", lcrSeparadorDecimal, ":");
                        var lcrTitloAdmision = lcrFechaAdmision + "  - " + lcrHoraAdmision;
                        var lcrFoto = "sys_usu01.png";  // por ahora /  p.Sia_rtfoto_usua este es el campo de la foto
                        var lcrFondo = AdmFunciones.fcrImagenEstadoRegAtencion(p.Sis_estpro_espr.Trim());  // sys_cit03.png
                        var lcrCapa = "sys_panel_fondo2.png";  // sys_cit03.png
                        var lcrNomPaciente = p.Sia_nroide_usua.Trim() + " - " + p.Sia_nomusu_usua.Trim() + "\t\t\t\t" + p.Adm_secadm_rgad.Trim();
                        var lcrEps = p.Sia_codeps_teps.Trim() + " - " + p.Sia_deseps_teps.Trim();
                        var lcrCodigoGrupo = "SN";
                        var lcrNombreGrupo = "SIN GRUPO";
                        if (p.Sia_codare_aser != null) { lcrCodigoGrupo = p.Sia_codare_aser.Trim(); }
                        if (p.Sia_desare_aser != null) { lcrNombreGrupo = p.Sia_desare_aser.Trim(); }
                        lcrNombreGrupo = lcrCodigoGrupo + " - " + lcrNombreGrupo;
                        var lcrDiagnostico = "Sin Diagnostico";
                        if (p.Sia_desdia_tdia != null) { lcrDiagnostico = p.Sia_desdia_tdia.Trim(); }
                        //---------------------
                        gArDicRutaseIconos.Add(p.Adm_secadm_rgad.Trim(), new String[] {lnuIndice.ToString().Trim(),
                                            p.Adm_secadm_rgad.Trim(),lcrTitloAdmision,lcrDiagnostico.Trim(),
                                            lcrEps,p.Sis_despro_espr.Trim(),lcrNomPaciente,lcrOrdenVista1,lcrOrdenVista2,
                                            lcrFechaAdmision,p.Sia_idesec_usua.Trim(),p.Sia_nroide_usua.Trim(),
                                            lcrFoto,lcrFondo,lcrCapa,"/Sistema;component/Imagenes/",lcrCodigoGrupo,lcrNombreGrupo});
                        lnuIndice++;
                    }
                    #endregion
                }
                else
                {
                    #region Generar la consulta
                    var lobConsulta = (from admregadmision in db.Admregadmision
                                       join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join hoscamasareas in db.Hoscamasareas on admregadmision.hos_codcam_caho equals hoscamasareas.hos_codcam_caho into tmhoscamasareas
                                       join siadiagnosticos in db.Siadiagnosticos on admregadmision.sia_dixing_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                       join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                       join sisestadoproces in db.Sisestadoproces on admregadmision.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from caho in tmhoscamasareas.DefaultIfEmpty()
                                       from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                       from teps in tmsiatablaeps.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where admregadmision.sia_regate_rgat.Equals("1") &&
                                             admregadmision.sis_estpro_espr.Equals(tcrEstadoRegistro) &&
                                             admregadmision.adm_finate_rgad=="1"
                                       orderby admregadmision.sia_codare_aser
                                       select new
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
                                           Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                           Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                           Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                           Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                           Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                           Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                           Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                           Desia_areing_aser = db.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == admregadmision.sia_areing_aser).sia_desare_aser,
                                           Sia_nomusu_usua = usua.sia_nomusu_usua,
                                           Sia_desare_aser = aser.sia_desare_aser,
                                           Hos_descam_caho = caho.hos_descam_caho,
                                           Sia_desdia_tdia = tdia.sia_desdia_tdia,
                                           Sia_deseps_teps = teps.sia_deseps_teps,
                                           Sis_despro_espr = espr.sis_despro_espr,
                                           #endregion
                                       }).Take(200).ToList();

                    #endregion
                    //-------------------------------------------------
                    // cargar en la lista
                    //-------------------------------------------------
                    #region cargar en la lista
                    foreach (var p in lobConsulta)
                    {
                        var lcrOrdenVista1 = "";
                        var lcrOrdenVista2 = "";
                        var lcrFechaAdmision = p.Adm_fecadm_rgad.ToShortDateString().Trim();
                        var lcrHoraAdmision = Funciones.fcrConvierteHora(p.Adm_horadm_rgad.ToString(), "24", lcrSeparadorDecimal, ":");
                        var lcrTitloAdmision = lcrFechaAdmision + "  - " + lcrHoraAdmision;
                        var lcrFoto = "sys_usu01.png";  // por ahora /  p.Sia_rtfoto_usua este es el campo de la foto
                        var lcrFondo = AdmFunciones.fcrImagenEstadoRegAtencion(p.Sis_estpro_espr.Trim());  // sys_cit03.png
                        var lcrCapa = "sys_panel_fondo2.png";  // sys_cit03.png
                        var lcrNomPaciente = p.Sia_nroide_usua.Trim() + " - " + p.Sia_nomusu_usua.Trim() + "\t\t\t\t" + p.Adm_secadm_rgad.Trim();
                        var lcrEps = p.Sia_codeps_teps.Trim() + " - " + p.Sia_deseps_teps.Trim();
                        var lcrCodigoGrupo = "SN";
                        var lcrNombreGrupo = "SIN GRUPO";
                        if (p.Sia_codare_aser != null) { lcrCodigoGrupo = p.Sia_codare_aser.Trim(); }
                        if (p.Sia_desare_aser != null) { lcrNombreGrupo = p.Sia_desare_aser.Trim(); }
                        lcrNombreGrupo = lcrCodigoGrupo + " - " + lcrNombreGrupo;
                        var lcrDiagnostico = "Sin Diagnostico";
                        if (p.Sia_desdia_tdia != null) { lcrDiagnostico = p.Sia_desdia_tdia.Trim(); }
                        //---------------------
                        gArDicRutaseIconos.Add(p.Adm_secadm_rgad.Trim(), new String[] {lnuIndice.ToString().Trim(),
                                            p.Adm_secadm_rgad.Trim(),lcrTitloAdmision,lcrDiagnostico.Trim(),
                                            lcrEps,p.Sis_despro_espr.Trim(),lcrNomPaciente,lcrOrdenVista1,lcrOrdenVista2,
                                            lcrFechaAdmision,p.Sia_idesec_usua.Trim(),p.Sia_nroide_usua.Trim(),
                                            lcrFoto,lcrFondo,lcrCapa,"/Sistema;component/Imagenes/",lcrCodigoGrupo,lcrNombreGrupo});
                        lnuIndice++;
                    }
                    #endregion
                }
            }
        }
        #endregion
        #endregion
        //----------------------------------------------------------------------
        // fcvFiltro : Filtro por un o varios registros en particular
        //----------------------------------------------------------------------
        #region fcvFiltro : Filtro por un o varios registros en particular
        /// <summary>
        /// fcvFiltro : Filtro por un o varios registros en particular
        /// </summary>
        private void fcvFiltro(String tcrCodigoRegistro)
        {
            gArDicRutaseIconos = new Dictionary<string, string[]>();
            using (DbAplicacion db = new DbAplicacion())
            {
                int lnuIndice = 0;
                int lnuContadorTiles = 0;
                String lcrCodigoReg = String.Empty;
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
                        #region Generar la consulta
                        lcrCodigoReg = larArray[i].Trim().ToUpper();
                        //-------------------------------------------------
                        var lobConsulta = (from admregadmision in db.Admregadmision
                                           join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                           join siaareapreservi in db.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                           join hoscamasareas in db.Hoscamasareas on admregadmision.hos_codcam_caho equals hoscamasareas.hos_codcam_caho into tmhoscamasareas
                                           join siadiagnosticos in db.Siadiagnosticos on admregadmision.sia_dixing_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                           join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                           join sisestadoproces in db.Sisestadoproces on admregadmision.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                           from usua in tmsiausuarioatend.DefaultIfEmpty()
                                           from aser in tmsiaareapreservi.DefaultIfEmpty()
                                           from caho in tmhoscamasareas.DefaultIfEmpty()
                                           from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                           from teps in tmsiatablaeps.DefaultIfEmpty()
                                           from espr in tmsisestadoproces.DefaultIfEmpty()
                                           where admregadmision.adm_secadm_rgad.Equals(lcrCodigoReg)
                                           select new
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
                                               Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                               Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                               Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                               Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                               Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                               Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                               Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                               Desia_areing_aser = db.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == admregadmision.sia_areing_aser).sia_desare_aser,
                                               Sia_nomusu_usua = usua.sia_nomusu_usua,
                                               Sia_desare_aser = aser.sia_desare_aser,
                                               Hos_descam_caho = caho.hos_descam_caho,
                                               Sia_desdia_tdia = tdia.sia_desdia_tdia,
                                               Sia_deseps_teps = teps.sia_deseps_teps,
                                               Sis_despro_espr = espr.sis_despro_espr,
                                               #endregion
                                           }).ToList();

                        #endregion
                        //-------------------------------------------------
                        // cargar en la lista
                        //-------------------------------------------------
                        #region cargar en la lista
                        foreach (var p in lobConsulta)
                        {
                            var lcrOrdenVista1 = "";
                            var lcrOrdenVista2 = "";
                            var lcrFechaAdmision = p.Adm_fecadm_rgad.ToShortDateString().Trim();
                            var lcrHoraAdmision = Funciones.fcrConvierteHora(p.Adm_horadm_rgad.ToString(), "24", lcrSeparadorDecimal, ":");
                            var lcrTitloAdmision = lcrFechaAdmision + "  - " + lcrHoraAdmision;
                            var lcrFoto = "sys_usu01.png";  // por ahora /  p.Sia_rtfoto_usua este es el campo de la foto
                            var lcrFondo = AdmFunciones.fcrImagenEstadoRegAtencion(p.Sis_estpro_espr.Trim());  // sys_cit03.png
                            var lcrCapa = "sys_panel_fondo2.png";  // sys_cit03.png
                            var lcrNomPaciente = p.Sia_nroide_usua.Trim() + " - " + p.Sia_nomusu_usua.Trim() + "\t\t\t\t" + p.Adm_secadm_rgad.Trim();
                            var lcrEps = p.Sia_codeps_teps.Trim() + " - " + p.Sia_deseps_teps.Trim();
                            var lcrCodigoGrupo = "SN";
                            var lcrNombreGrupo = "SIN GRUPO";
                            if (p.Sia_codare_aser != null) { lcrCodigoGrupo = p.Sia_codare_aser.Trim(); }
                            if (p.Sia_desare_aser != null) { lcrNombreGrupo = p.Sia_desare_aser.Trim(); }
                            lcrNombreGrupo = lcrCodigoGrupo + " - " + lcrNombreGrupo;
                            var lcrDiagnostico = "Sin Diagnostico";
                            if (p.Sia_desdia_tdia != null) { lcrDiagnostico = p.Sia_desdia_tdia.Trim(); }
                            //---------------------
                            gArDicRutaseIconos.Add(p.Adm_secadm_rgad.Trim(), new String[] {lnuIndice.ToString().Trim(),
                                            p.Adm_secadm_rgad.Trim(),lcrTitloAdmision,lcrDiagnostico.Trim(),
                                            lcrEps,p.Sis_despro_espr.Trim(),lcrNomPaciente,lcrOrdenVista1,lcrOrdenVista2,
                                            lcrFechaAdmision,p.Sia_idesec_usua.Trim(),p.Sia_nroide_usua.Trim(),
                                            lcrFoto,lcrFondo,lcrCapa,"/Sistema;component/Imagenes/",lcrCodigoGrupo,lcrNombreGrupo});
                            lnuIndice++;
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion
        //------------------------------------------------------------
        //  ACTUALIZAR Diccionario de Tiles02
        //------------------------------------------------------------
        #region fcvActualizDiccTiles02()
        public Dictionary<string, string[]> fcvActualizDiccTiles02(ref Dictionary<string, string[]> tarDiccionarioVista,
                                                ref Dictionary<string, string[]> tarDiccActualizTiles)
        {
            String lcrllave = String.Empty;
            String lcrPrueba = String.Empty;
            gArDicRutaseIconos = new Dictionary<string, string[]>();

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
                gArDicRutaseIconos.Add(lobReDicc.Key.Trim(), new String[] {lobReDicc.Value[0],
                                            lobReDicc.Value[1],lobReDicc.Value[2],lobReDicc.Value[3],
                                            lobReDicc.Value[4],lobReDicc.Value[5],lobReDicc.Value[6],
                                            lobReDicc.Value[7],lobReDicc.Value[8],lobReDicc.Value[9],
                                            lobReDicc.Value[10],lobReDicc.Value[11],lobReDicc.Value[12],
                                            lobReDicc.Value[13],lobReDicc.Value[14],lobReDicc.Value[15],
                                            lobReDicc.Value[16],lobReDicc.Value[17]});

            }
            return gArDicRutaseIconos;
        }
        #endregion
    }
}

using System;
using System.Data;
using System.Data.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Data;
using Datos.Modelos;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sistema.Clases;

namespace Sistema.Utilidades
{
    public class ADM_Browser01 : AuxBrowser01
    {
        //-----------------------------------
        public object gobRefRegistro;
        public ListView gobDataGrid;
        public GridView gobGridView;
        public string gcrTabla = string.Empty;
        //-----------------------------------
        //-Variables Filtro activo de datos
        //-----------------------------------
        public string gcrFiltroAplicado = string.Empty;
        public string gcrFiltroDatos = string.Empty;
        public string gcrFiltroTabla = string.Empty;
        //----------------------------------------------------------------------
        //    Función: ConfigInicial()
        //----------------------------------------------------------------------
        #region ConfigInicial: Inicio y Configuracion de DataGrid

        public void ConfigInicial(ListView tobDataGrid, GridView tobGridView, string tcrTabla, string tcrFiltroDatos, string tcrFiltroTabla)
        {
            gobDataGrid = tobDataGrid;
            gobGridView = tobGridView;
            gcrTabla = tcrTabla;
            gcrFiltroDatos = tcrFiltroDatos;
            gcrFiltroTabla = tcrFiltroTabla;
            switch (tcrTabla.ToUpper())
            {
                case "ADMREGADMISION":
                    fcvAddColGrid_Admregadmision();
                    gobDataGrid.ItemsSource = flsBuscar_Admregadmision(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMVIAINGRESO":
                    fcvAddColGrid_Admviaingreso();
                    gobDataGrid.ItemsSource = flsBuscar_Admviaingreso(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMTIPOATENCION":
                    fcvAddColGrid_Admtipoatencion();
                    gobDataGrid.ItemsSource = flsBuscar_Admtipoatencion(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMCAUSAEXTERNA":
                    fcvAddColGrid_Admcausaexterna();
                    gobDataGrid.ItemsSource = flsBuscar_Admcausaexterna(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMDESTINOSALIR":
                    fcvAddColGrid_Admdestinosalir();
                    gobDataGrid.ItemsSource = flsBuscar_Admdestinosalir(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMTRIAGEMAESTR":
                    fcvAddColGrid_Admtriagemaestr();
                    gobDataGrid.ItemsSource = flsBuscar_Admtriagemaestr(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMREGURGENCIAS":
                    fcvAddColGrid_Admregurgencias();
                    gobDataGrid.ItemsSource = flsBuscar_Admregurgencias(gcrFiltroDatos, gcrFiltroTabla);
                    break;
            }

        }
        #endregion
        //----------------------------------------------------------------------
        //    Función: Buscar()
        //----------------------------------------------------------------------
        #region fcvBuscar: Buscar Registro

        public void fcvBuscar(ListView tobDataGrid, string tcrTabla, string tcrFiltroDatos, string tcrFiltroTabla)
        {
            gcrFiltroDatos = tcrFiltroDatos;
            gcrFiltroTabla = tcrFiltroTabla;
            switch (tcrTabla.ToUpper())
            {
                case "ADMREGADMISION":
                    tobDataGrid.ItemsSource = flsBuscar_Admregadmision(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMVIAINGRESO":
                    tobDataGrid.ItemsSource = flsBuscar_Admviaingreso(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMTIPOATENCION":
                    tobDataGrid.ItemsSource = flsBuscar_Admtipoatencion(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMCAUSAEXTERNA":
                    tobDataGrid.ItemsSource = flsBuscar_Admcausaexterna(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMDESTINOSALIR":
                    tobDataGrid.ItemsSource = flsBuscar_Admdestinosalir(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMTRIAGEMAESTR":
                    tobDataGrid.ItemsSource = flsBuscar_Admtriagemaestr(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ADMREGURGENCIAS":
                    tobDataGrid.ItemsSource = flsBuscar_Admregurgencias(gcrFiltroDatos, gcrFiltroTabla);
                    break;

            }

        }
        #endregion
        //----------------------------------------------------------------------
        //    Función: fcrRegistroSelect()
        //----------------------------------------------------------------------
        #region fcrRegistroSelect: Seleccion del Registro activo en la Grilla

        public string fcrRegistroSelect(ListView tobDataGrid, string tcrTabla)
        {
            gobDataGrid = tobDataGrid;
            string lcrReturnCodigo = string.Empty;
            switch (tcrTabla.ToUpper())
            {
                case "ADMREGADMISION":
                    lcrReturnCodigo = fcrSelect_Admregadmision();
                    break;

                case "ADMVIAINGRESO":
                    lcrReturnCodigo = fcrSelect_Admviaingreso();
                    break;

                case "ADMTIPOATENCION":
                    lcrReturnCodigo = fcrSelect_Admtipoatencion();
                    break;

                case "ADMCAUSAEXTERNA":
                    lcrReturnCodigo = fcrSelect_Admcausaexterna();
                    break;

                case "ADMDESTINOSALIR":
                    lcrReturnCodigo = fcrSelect_Admdestinosalir();
                    break;

                case "ADMTRIAGEMAESTR":
                    lcrReturnCodigo = fcrSelect_Admtriagemaestr();
                    break;

                case "ADMREGURGENCIAS":
                    lcrReturnCodigo = fcrSelect_Admregurgencias();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ADMREGADMISION - Admisión de pacientes
        //----------------------------------------------------------------------
        //-----------------------------------
        //- Browser de la tabla ADMISION Y EGRESO
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerAdmision
        {
            public BrowerAdmision() { }
            public string campo1 { get; set; }
            public string campo2 { get; set; }
            public string campo3 { get; set; }
            public string campo4 { get; set; }
            public DateTime campo5 { get; set; }
            public string campo6 { get; set; }
            public string campo7 { get; set; }
            public string campo8 { get; set; }
            public string campo9 { get; set; }
            public DateTime campo10 { get; set; }
            public string campo11 { get; set; }
            public string campo12 { get; set; }
            public string campo13 { get; set; }
            public string campo14 { get; set; }
            public string campo15 { get; set; }
            public string campo16 { get; set; }
            public string campo17 { get; set; }
            public string campo18 { get; set; }
            public int campo19 { get; set; }
        }
        #endregion
        #region ADMREGADMISION
        public static List<BrowerAdmision> flsBuscar_Admregadmision(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                var lcrTipo1 = Funciones.fuxExtraerElemento(1, "*", tcrFiltroTabla); // Admitido - Ambulatoria
                var lcrTipo2 = lcrTipo1;
                var lcrEstado1 = Funciones.fuxExtraerElemento(2, "*", tcrFiltroTabla); // abierto - Cerrado - Anulado
                var lcrEstado2 = lcrEstado1;
                var lcrEstado3 = lcrEstado1;

                if (lcrTipo1 == "TODOS")
                {
                    lcrTipo1 = "1"; // Adimitdos
                    lcrTipo2 = "2"; // Ambulatorios
                }
                if (lcrTipo1 == "ADMITIDOS")
                {
                    lcrTipo1 = "1"; // Adimitdos
                    lcrTipo2 = "1"; // Adimitdos
                }

                if (lcrEstado1 == "TODOS")
                {
                    lcrEstado1 = "1"; // Abierto
                    lcrEstado2 = "2"; // Cerrado
                    lcrEstado3 = "3"; // Anulado
                }
                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region Busqueda por filtro
                    var lcrQuery = from admregadmision in db.Admregadmision
                                   join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                   join sisestadoproces in db.Sisestadoproces on admregadmision.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from teps in tmsiatablaeps.DefaultIfEmpty()
                                   from espr in tmsisestadoproces.DefaultIfEmpty()
                                   where (admregadmision.adm_secadm_rgad.Contains(tcrBuscar) ||
                                          admregadmision.sia_nroide_usua.Contains(tcrBuscar) ||
                                          usua.sia_nomusu_usua.Contains(tcrBuscar)) &&
                                        (admregadmision.sia_regate_rgat == lcrTipo1 || admregadmision.sia_regate_rgat == lcrTipo2) &&
                                        (admregadmision.sis_estpro_espr == lcrEstado1 || admregadmision.sis_estpro_espr == lcrEstado2 || admregadmision.sis_estpro_espr == lcrEstado3)
                                   select new BrowerAdmision
                                   {
                                       campo1 = admregadmision.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                       campo2 = admregadmision.sia_idesec_usua,
                                       campo3 = admregadmision.sia_nroide_usua,
                                       campo4 = admregadmision.adm_secadm_rgad,
                                       campo5 = (DateTime)admregadmision.adm_fecadm_rgad,
                                       campo6 = usua.sia_priape_usua,
                                       campo7 = usua.sia_segape_usua,
                                       campo8 = usua.sia_prinom_usua,
                                       campo9 = usua.sia_segnom_usua,
                                       campo10 = (DateTime)usua.sia_fecnac_usua,
                                       campo11 = usua.sis_codsex_sexo,
                                       campo12 = admregadmision.sia_codeps_teps,
                                       campo13 = teps.sia_deseps_teps,
                                       campo14 = espr.sis_despro_espr,
                                   };
                    return lcrQuery.Take(100).ToList();
                    #endregion
                }
                else
                {
                    #region Busqueda por filtro
                    var lcrQuery = from admregadmision in db.Admregadmision
                                   join siausuarioatend in db.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join siatablaeps in db.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                   join sisestadoproces in db.Sisestadoproces on admregadmision.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from teps in tmsiatablaeps.DefaultIfEmpty()
                                   from espr in tmsisestadoproces.DefaultIfEmpty()
                                   orderby admregadmision.adm_fecadm_rgad descending
                                   where (admregadmision.sia_regate_rgat == lcrTipo1 || admregadmision.sia_regate_rgat == lcrTipo2) &&
                                        (admregadmision.sis_estpro_espr == lcrEstado1 || admregadmision.sis_estpro_espr == lcrEstado2 || admregadmision.sis_estpro_espr == lcrEstado3)
                                   select new BrowerAdmision
                                   {
                                       campo1 = admregadmision.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                       campo2 = admregadmision.sia_idesec_usua,
                                       campo3 = admregadmision.sia_nroide_usua,
                                       campo4 = admregadmision.adm_secadm_rgad,
                                       campo5 = (DateTime)admregadmision.adm_fecadm_rgad,
                                       campo6 = usua.sia_priape_usua,
                                       campo7 = usua.sia_segape_usua,
                                       campo8 = usua.sia_prinom_usua,
                                       campo9 = usua.sia_segnom_usua,
                                       campo10 = (DateTime)usua.sia_fecnac_usua,
                                       campo11 = usua.sis_codsex_sexo,
                                       campo12 = admregadmision.sia_codeps_teps,
                                       campo13 = teps.sia_deseps_teps,
                                       campo14 = espr.sis_despro_espr,
                                   };
                    return lcrQuery.Take(200).ToList();
                    #endregion
                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Admregadmision()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo atención",      Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id Unica Usuario",   Width = 120, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificación",     Width = 120, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Admisión",           Width = 100, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha Admisión",     Width = 100, DisplayMemberBinding = new Binding("campo5") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Apellido",    Width = 120, DisplayMemberBinding = new Binding("campo6") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Apellido",   Width = 120, DisplayMemberBinding = new Binding("campo7") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Nombre",      Width = 120, DisplayMemberBinding = new Binding("campo8") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Nombre",     Width = 120, DisplayMemberBinding = new Binding("campo9") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha Nacimiento",   Width = 100, DisplayMemberBinding = new Binding("campo10") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Sexo",               Width = 080, DisplayMemberBinding = new Binding("campo11") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo EPS",         Width = 100, DisplayMemberBinding = new Binding("campo12") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre EPS",         Width = 280, DisplayMemberBinding = new Binding("campo13") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado registro",    Width = 120, DisplayMemberBinding = new Binding("campo14") });

        }
        // Seleccionar Registro
        public string fcrSelect_Admregadmision()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerAdmision)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo4.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ADMVIAINGRESO - Tipo origen de la admisión
        //----------------------------------------------------------------------
        #region ADMVIAINGRESO
        public static List<EFadmviaingreso> flsBuscar_Admviaingreso(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("ADMVIAINGRESO", tcrBuscar, "like", "OR", "adm_codoad_toad,adm_desoad_toad", tcrFiltroTabla);
                ObjectQuery<EFadmviaingreso> lcrQuery = new ObjectQuery<EFadmviaingreso>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Admviaingreso()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código Origen admisión", Width = 120, DisplayMemberBinding = new Binding("adm_codoad_toad") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción Origen admisión", Width = 400, DisplayMemberBinding = new Binding("adm_desoad_toad") });
        }
        // Seleccionar Registro
        public string fcrSelect_Admviaingreso()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFadmviaingreso)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.adm_codoad_toad.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ADMTIPOATENCION - Ámbito de atención paciente
        //----------------------------------------------------------------------
        #region ADMTIPOATENCION
        public static List<EFadmtipoatencion> flsBuscar_Admtipoatencion(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("ADMTIPOATENCION", tcrBuscar, "like", "OR", "adm_codtat_tatn,adm_destat_tatn", tcrFiltroTabla);
                ObjectQuery<EFadmtipoatencion> lcrQuery = new ObjectQuery<EFadmtipoatencion>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Admtipoatencion()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código tipo de atención", Width = 120, DisplayMemberBinding = new Binding("adm_codtat_tatn") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción tipo atención", Width = 400, DisplayMemberBinding = new Binding("adm_destat_tatn") });
        }
        // Seleccionar Registro
        public string fcrSelect_Admtipoatencion()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFadmtipoatencion)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.adm_codtat_tatn.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ADMCAUSAEXTERNA - Causa externa origen de atención
        //----------------------------------------------------------------------
        #region ADMCAUSAEXTERNA
        public static List<EFadmcausaexterna> flsBuscar_Admcausaexterna(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("ADMCAUSAEXTERNA", tcrBuscar, "like", "OR", "adm_codcex_tcex,adm_descex_tcex", tcrFiltroTabla);
                ObjectQuery<EFadmcausaexterna> lcrQuery = new ObjectQuery<EFadmcausaexterna>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Admcausaexterna()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Causa Externa", Width = 120, DisplayMemberBinding = new Binding("adm_codcex_tcex") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción causa externa", Width = 400, DisplayMemberBinding = new Binding("adm_descex_tcex") });
        }
        // Seleccionar Registro
        public string fcrSelect_Admcausaexterna()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFadmcausaexterna)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.adm_codcex_tcex.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ADMDESTINOSALIR - Tabla de destino al Salir
        //----------------------------------------------------------------------
        #region ADMDESTINOSALIR
        public static List<EFadmdestinosalir> flsBuscar_Admdestinosalir(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("ADMDESTINOSALIR", tcrBuscar, "like", "OR", "adm_coddsa_tdsa,adm_desdsa_tdsa", tcrFiltroTabla);
                ObjectQuery<EFadmdestinosalir> lcrQuery = new ObjectQuery<EFadmdestinosalir>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Admdestinosalir()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código destino al salir", Width = 120, DisplayMemberBinding = new Binding("adm_coddsa_tdsa") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Destino al Salir", Width = 400, DisplayMemberBinding = new Binding("adm_desdsa_tdsa") });
        }
        // Seleccionar Registro
        public string fcrSelect_Admdestinosalir()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFadmdestinosalir)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.adm_coddsa_tdsa.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ADMTRIAGEMAESTR - Maestro evaluación Triage
        //----------------------------------------------------------------------
        #region ADMTRIAGEMAESTR
        public static List<BrowerAdmision> flsBuscar_Admtriagemaestr(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                // Destino remision: 1 = Consulta Externa  2 = Consulta prioritaria  3 = Urgencia

                var lcrFiltro1 = tcrFiltroTabla == "1*2" ? "1" : "3"; // 1*2 Viene de registro atencion ambulatoria
                var lcrFiltro2 = tcrFiltroTabla == "1*2" ? "2" : "3"; // 1*2 Viene de registro atencion ambulatoria

                if (String.IsNullOrWhiteSpace(tcrFiltroTabla))
                {
                    lcrFiltro1 = String.Empty;
                    lcrFiltro2 = String.Empty;
                }

                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    if (String.IsNullOrWhiteSpace(lcrFiltro1))
                    {
                        #region Busqueda por filtro
                        var lcrQuery = from triage in db.Admtriagemaestr
                                       where triage.adm_nroreg_tria.Contains(tcrBuscar) ||
                                              triage.sia_nroide_usua.Contains(tcrBuscar) ||
                                              triage.sia_priape_usua.Contains(tcrBuscar) ||
                                              triage.sia_segape_usua.Contains(tcrBuscar) ||
                                              triage.sia_prinom_usua.Contains(tcrBuscar) ||
                                              triage.sia_segnom_usua.Contains(tcrBuscar)
                                       orderby triage.adm_gesfec_tria descending
                                       select new BrowerAdmision
                                       {
                                           #region datos
                                           campo1 = triage.adm_nroreg_tria,
                                           campo5 = (DateTime)triage.adm_gesfec_tria,
                                           campo2 = triage.adm_clasif_tria,
                                           campo3 = triage.sia_tipide_tide,
                                           campo4 = triage.sia_nroide_usua,
                                           campo6 = triage.sia_priape_usua,
                                           campo7 = triage.sia_segape_usua,
                                           campo8 = triage.sia_prinom_usua,
                                           campo9 = triage.sia_segnom_usua,
                                           campo19 = (int)triage.sia_edapac_usua,
                                           #endregion
                                       };
                        return lcrQuery.Take(150).ToList();
                        #endregion
                    }
                    else
                    {
                        #region Busqueda por filtro
                        var lcrQuery = from triage in db.Admtriagemaestr
                                       where triage.adm_nroreg_tria.Contains(tcrBuscar) ||
                                              triage.sia_nroide_usua.Contains(tcrBuscar) ||
                                              triage.sia_priape_usua.Contains(tcrBuscar) ||
                                              triage.sia_segape_usua.Contains(tcrBuscar) ||
                                              triage.sia_prinom_usua.Contains(tcrBuscar) ||
                                              triage.sia_segnom_usua.Contains(tcrBuscar) &&
                                              (triage.adm_remisi_tria == lcrFiltro1 || triage.adm_remisi_tria == lcrFiltro2)
                                       orderby triage.adm_gesfec_tria descending
                                       select new BrowerAdmision
                                       {
                                           #region datos
                                           campo1 = triage.adm_nroreg_tria,
                                           campo5 = (DateTime)triage.adm_gesfec_tria,
                                           campo2 = triage.adm_clasif_tria,
                                           campo3 = triage.sia_tipide_tide,
                                           campo4 = triage.sia_nroide_usua,
                                           campo6 = triage.sia_priape_usua,
                                           campo7 = triage.sia_segape_usua,
                                           campo8 = triage.sia_prinom_usua,
                                           campo9 = triage.sia_segnom_usua,
                                           campo19 = (int)triage.sia_edapac_usua,
                                           #endregion
                                       };
                        return lcrQuery.Take(150).ToList();
                        #endregion
                    }
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(lcrFiltro1))
                    {
                        #region Busqueda por filtro
                        var lcrQuery = from triage in db.Admtriagemaestr
                                       orderby triage.adm_gesfec_tria descending
                                       select new BrowerAdmision
                                       {
                                           #region datos
                                           campo1 = triage.adm_nroreg_tria,
                                           campo5 = (DateTime)triage.adm_gesfec_tria,
                                           campo2 = triage.adm_clasif_tria,
                                           campo3 = triage.sia_tipide_tide,
                                           campo4 = triage.sia_nroide_usua,
                                           campo6 = triage.sia_priape_usua,
                                           campo7 = triage.sia_segape_usua,
                                           campo8 = triage.sia_prinom_usua,
                                           campo9 = triage.sia_segnom_usua,
                                           campo19 = (int)triage.sia_edapac_usua,
                                           #endregion
                                       };
                        return lcrQuery.Take(150).ToList();
                        #endregion
                    }
                    else
                    {
                        #region Busqueda por filtro
                        var lcrQuery = from triage in db.Admtriagemaestr
                                       where triage.adm_remisi_tria == lcrFiltro1 || 
                                             triage.adm_remisi_tria == lcrFiltro2
                                       orderby triage.adm_gesfec_tria descending
                                       select new BrowerAdmision
                                       {
                                           #region datos
                                           campo1 = triage.adm_nroreg_tria,
                                           campo5 = (DateTime)triage.adm_gesfec_tria,
                                           campo2 = triage.adm_clasif_tria,
                                           campo3 = triage.sia_tipide_tide,
                                           campo4 = triage.sia_nroide_usua,
                                           campo6 = triage.sia_priape_usua,
                                           campo7 = triage.sia_segape_usua,
                                           campo8 = triage.sia_prinom_usua,
                                           campo9 = triage.sia_segnom_usua,
                                           campo19 = (int)triage.sia_edapac_usua,
                                           #endregion
                                       };
                        return lcrQuery.Take(150).ToList();
                        #endregion
                    }
                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Admtriagemaestr()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Registro",         Width = 100, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha",            Width = 100, DisplayMemberBinding = new Binding("campo5") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Clasificación",    Width = 90, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo Id",          Width = 80, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificación",   Width = 120, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Apellido",  Width = 120, DisplayMemberBinding = new Binding("campo6") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo apellido", Width = 120, DisplayMemberBinding = new Binding("campo7") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Nombre",    Width = 120, DisplayMemberBinding = new Binding("campo8") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Nombre",   Width = 120, DisplayMemberBinding = new Binding("campo9") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Edad",             Width = 100, DisplayMemberBinding = new Binding("campo19") });
        }
        // Seleccionar Registro
        public string fcrSelect_Admtriagemaestr()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerAdmision)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo1.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ADMREGURGENCIAS - Maestro registro salida de urgencias
        //----------------------------------------------------------------------
        #region ADMREGURGENCIAS
        public static List<EFadmregurgencias> flsBuscar_Admregurgencias(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("ADMREGURGENCIAS", tcrBuscar, "like", "OR", "adm_secegr_regu,adm_observ_regu", tcrFiltroTabla);
                ObjectQuery<EFadmregurgencias> lcrQuery = new ObjectQuery<EFadmregurgencias>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Admregurgencias()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Egreso urgencias", Width = 120, DisplayMemberBinding = new Binding("adm_secegr_regu") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nota egreso", Width = 400, DisplayMemberBinding = new Binding("adm_observ_regu") });
        }
        // Seleccionar Registro
        public string fcrSelect_Admregurgencias()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFadmregurgencias)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.adm_secegr_regu.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

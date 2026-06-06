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
using Sistema.Utilidades;
using Sistema.Clases;

namespace Sistema.Utilidades
{
    public class ADM_Browser02 : AuxBrowser02
    {

        #region Configurar la vista General del Browser
        //----------------------------------------------------------------------
        //    Funcion: ConfigInicial()
        //----------------------------------------------------------------------
        #region ConfigInicial: Inicio y Configuracion de DataGrid
        public void ConfigInicial()
        {
            fcvReferenciaObjetos();
            switch (gcrTabla.ToUpper())
            {
                case "ADMREGADMISION":
                    fcvAddColGrid_Admregadmision();
                    gobDataGrid.ItemsSource = flsBuscar_Admregadmision().DefaultView;
                    break;

                case "ADMREGISTEGRESO":
                    fcvAddColGrid_Admregistegreso();
                    gobDataGrid.ItemsSource = flsBuscar_Admregistegreso();
                    break;

                case "ADMVISTAFACTURAS":
                    fcvAddColGrid_Admvistadfacturas();
                    gobDataGrid.ItemsSource = flsBuscar_Admvistadfacturas();
                    break;

            }

        }
        #endregion
        //----------------------------------------------------------------------
        //    Funcion: Buscar()
        //----------------------------------------------------------------------
        #region fcvBuscar: Buscar Registro
        public void fcvBuscar()
        {
            fcvReferenciaObjetos();
            switch (gcrTabla.ToUpper())
            {
                case "ADMREGADMISION":
                    gobDataGrid.ItemsSource = flsBuscar_Admregadmision().DefaultView;
                    break;

                case "ADMREGISTEGRESO":
                    gobDataGrid.ItemsSource = flsBuscar_Admregistegreso();
                    break;

                case "ADMVISTAFACTURAS":
                    gobDataGrid.ItemsSource = flsBuscar_Admvistadfacturas();
                    break;

            }

        }
        #endregion
        //----------------------------------------------------------------------
        //    Funcion: fcrRegistroSelect()
        //----------------------------------------------------------------------
        #region fcrRegistroSelect: Seleccion del Registro activo en la Grilla
        public string fcrRegistroSelect()
        {
            fcvReferenciaObjetos();
            string lcrReturnCodigo = string.Empty;
            switch (gcrTabla.ToUpper())
            {

                case "ADMREGADMISION":
                    lcrReturnCodigo = fcrSelect_Admregadmision();
                    break;

                case "ADMREGISTEGRESO":
                    lcrReturnCodigo = fcrSelect_Admregistegreso();
                    break;

                case "ADMVISTAFACTURAS":
                    lcrReturnCodigo = fcrSelect_Admvistadfacturas();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        #endregion
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
            public string campo10 { get; set; }
            public DateTime campo11 { get; set; }
            public string campo12 { get; set; }
            public string campo13 { get; set; }
            public string campo14 { get; set; }
            public string campo15 { get; set; }
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ADMREGADMISION - Admisión de pacientes
        //----------------------------------------------------------------------
        #region ADMREGADMISION
        #region Filtro de busquedas
        public DataTable flsBuscar_Admregadmision()
        {
            //var lnuTotalReg = 90;
            var lcrTipo1 = Funciones.fuxExtraerElemento(1, "*", gcrFiltroTabla); // Admitido - Ambulatoria
            var lcrTipo2 = lcrTipo1;
            var lcrEstado1 = Funciones.fuxExtraerElemento(2, "*", gcrFiltroTabla); // abierto - Cerrado - Anulado
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

            var lcrFiltro1 = " WHERE (admregadmision.sia_regate_rgat = '" + lcrTipo1 + "' OR "+ 
                                    "admregadmision.sia_regate_rgat = '" + lcrTipo2 + "') AND " +
                                    "(admregadmision.sis_estpro_espr = '" + lcrEstado1 + "' OR "+ 
                                    "admregadmision.sis_estpro_espr = '" + lcrEstado2 + "' OR "+
                                    "admregadmision.sis_estpro_espr = '" + lcrEstado3 + "')";
            var lcrFiltro2 = String.Empty;

            if (gcrIndiceActivo == "1") // Numero de admision
            {
                lcrFiltro2 = " AND admregadmision.adm_secadm_rgad LIKE '%" + gobjTextBox11.Text.Trim() + "%'";
            }
            else if (gcrIndiceActivo == "2") // Numero de Identificacion
            {
                lcrFiltro2 = " AND admregadmision.sia_nroide_usua LIKE '" + gobjTextBox11.Text.Trim() + "%'";
            }
            else if (gcrIndiceActivo == "3") // P.Apellido S.Apellido P.Nombre
            {
                var lcrApe1 = gobjTextBox31.Text.Trim();
                var lcrApe2 = gobjTextBox32.Text.Trim();
                var lcrNom1 = gobjTextBox33.Text.Trim();

                var lcrApell1 = !String.IsNullOrWhiteSpace(lcrApe1) ? "siausuarioatend.sia_priape_usua LIKE '"+lcrApe1+"%'": "";
                var lcrApell2 = !String.IsNullOrWhiteSpace(lcrApe2) ? "siausuarioatend.sia_segape_usua LIKE '"+lcrApe2+"%'": "";
                var lcrNombr1 = !String.IsNullOrWhiteSpace(lcrNom1) ? "siausuarioatend.sia_prinom_usua LIKE '"+lcrNom1+"%'": "";

                if (!String.IsNullOrWhiteSpace(lcrApell1) && !String.IsNullOrWhiteSpace(lcrApell2) && !String.IsNullOrWhiteSpace(lcrNombr1))
                {
                    lcrFiltro2 = " AND " + lcrApell1 + " AND "+ lcrApell2 +" AND " + lcrNombr1;
                }
                else if (!String.IsNullOrWhiteSpace(lcrApell1) && !String.IsNullOrWhiteSpace(lcrApell2))
                {
                    lcrFiltro2 = " AND " + lcrApell1 + " AND "+ lcrApell2;
                }
                else if (!String.IsNullOrWhiteSpace(lcrApell1) && !String.IsNullOrWhiteSpace(lcrNombr1))
                {
                    lcrFiltro2 = " AND " + lcrApell1 + " AND " + lcrNombr1;
                }
                else if (!String.IsNullOrWhiteSpace(lcrApell2) && !String.IsNullOrWhiteSpace(lcrNombr1))
                {
                    lcrFiltro2 = " AND "+ lcrApell2 +" AND " + lcrNombr1;
                }
                else if (!String.IsNullOrWhiteSpace(lcrApell1))
                {
                    lcrFiltro2 = " AND " + lcrApell1;
                }
                else if (!String.IsNullOrWhiteSpace(lcrApell2))
                {
                    lcrFiltro2 = " AND "+ lcrApell2;

                }
                else if (!String.IsNullOrWhiteSpace(lcrNombr1))
                {
                    lcrFiltro2 = " AND " + lcrNombr1;
                }
                else
                {
                    // todos estan vacios
                }
            }
            else
            {
                // por deefecto
            }
            //var lcrLineaSqlSelct = fcrLineaSqlAdmision() + lcrFiltro1 + lcrFiltro2 + " ORDER BY admregadmision.adm_fecadm_rgad DESC LIMIT 60";
            var lcrOrderBy = " ORDER BY admregadmision.adm_fllave_rgad DESC LIMIT 60";
            var lcrLineaSqlSelct = fcrLineaSqlAdmision() + lcrFiltro1 + lcrFiltro2 + lcrOrderBy;

            var lobjDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
            return lobjDatosTabla;
        }
        public String fcrLineaSqlAdmision()
        {
            var lcrLinea = "SELECT siatregatencion.sia_desreg_rgat," +
                           "admregadmision.sia_idesec_usua," +
                           "admregadmision.sia_nroide_usua," +
                           "admregadmision.adm_secadm_rgad," +
                           "admregadmision.adm_fecadm_rgad," +
                           "admregadmision.sia_codeps_teps," +
                           "siausuarioatend.sia_priape_usua," +
                           "siausuarioatend.sia_segape_usua," +
                           "siausuarioatend.sia_prinom_usua," +
                           "siausuarioatend.sia_segnom_usua," +
                           "siausuarioatend.sia_fecnac_usua," +
                           "siausuarioatend.sis_codsex_sexo," +
                           "sisestadoproces.sis_despro_espr" +
                     " FROM admregadmision" +
                           " INNER JOIN siatregatencion ON (admregadmision.sia_regate_rgat = siatregatencion.sia_regate_rgat)" +
                           " INNER JOIN siausuarioatend ON (admregadmision.sia_idesec_usua = siausuarioatend.sia_idesec_usua)" +
                           " INNER JOIN sisestadoproces ON (admregadmision.sis_estpro_espr = sisestadoproces.sis_estpro_espr)";
            return lcrLinea;
        }
        #endregion
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Admregadmision()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo atención", Width = 120, DisplayMemberBinding = new Binding("sia_desreg_rgat") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificación", Width = 090, DisplayMemberBinding = new Binding("sia_nroide_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Admisión", Width = 090, DisplayMemberBinding = new Binding("adm_secadm_rgad") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha Admisión", Width = 090, DisplayMemberBinding = new Binding("adm_fecadm_rgad") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Apellido", Width = 120, DisplayMemberBinding = new Binding("sia_priape_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Apellido", Width = 120, DisplayMemberBinding = new Binding("sia_segape_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Nombre", Width = 120, DisplayMemberBinding = new Binding("sia_prinom_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Nombre", Width = 120, DisplayMemberBinding = new Binding("sia_segnom_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha Nacimiento", Width = 100, DisplayMemberBinding = new Binding("sia_fecnac_usua") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Sexo", Width = 080, DisplayMemberBinding = new Binding("sis_codsex_sexo") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo EPS", Width = 100, DisplayMemberBinding = new Binding("sia_codeps_teps") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id Unica Usuario", Width = 120, DisplayMemberBinding = new Binding("sia_idesec_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado registro", Width = 120, DisplayMemberBinding = new Binding("sis_despro_espr") });
            //---------------------------
            // Lista de indices y titulos para Texbox de busqueda
            //---------------------------
            #region Configurar lista de indices
            gclListaIndices.Add(new ComboItem() { IdIndice = "1", NombreIndice = "Numero admisión", TotalCampos = 1, Titulos = new List<string> { "Numero Admisión"}});
            gclListaIndices.Add(new ComboItem() { IdIndice = "2", NombreIndice = "Identificación", TotalCampos = 1, Titulos = new List<string> { "Identificación"}});
            gclListaIndices.Add(new ComboItem() { IdIndice = "3", NombreIndice = "Apellidos y Nombre", TotalCampos = 3, Titulos = new List<string> { "Primer Apellido", "Segundo Apellido", "Primer Nombre" } });
            //---------------------------
            //Establecemos el itemssource del ComboBox a lista de Indices.
            gobListBoxIndices.ItemsSource = gclListaIndices;
            gobListBoxIndices.SelectedItem = gobListBoxIndices.Items[gnuIdIndiceInicial-1];
            // Activar el Tab de Textbox correspondiente
            fcvActivarTab("Tab" + fcrTotalCamposIndiceActivo());
            #endregion
        }
        // Seleccionar Registro
        public string fcrSelect_Admregadmision()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (DataRowView)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg["adm_secadm_rgad"].ToString().Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ADMREGISTEGRESO - Maestro registro egresos de hospitalizacion 			
        //----------------------------------------------------------------------
        #region ADMREGISTEGRESO
        #region Filtro de busquedas
        public List<BrowerAdmision> flsBuscar_Admregistegreso()
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                var lcrEstado1 = gcrFiltroTabla; // abierto - Cerrado - Anulado
                var lcrEstado2 = lcrEstado1;
                var lcrEstado3 = lcrEstado1;

                if (lcrEstado1 == "TODOS")
                {
                    lcrEstado1 = "1"; // Abierto
                    lcrEstado2 = "2"; // Cerrado
                    lcrEstado3 = "3"; // Anulado
                }

                if (gcrIndiceActivo == "1") // Numero de admision
                {

                    #region Numero de admision
                    var lcrQuery = from admregistegreso in db.Admregistegreso
                                   join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                   join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from rgad in tmadmregadmision.DefaultIfEmpty()
                                   from espr in tmsisestadoproces.DefaultIfEmpty()
                                   where admregistegreso.adm_secadm_rgad.Contains(gobjTextBox11.Text.Trim()) &&
                                        (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                   select new BrowerAdmision
                                   {
                                       campo1 = "ADMITIDO",
                                       campo2 = admregistegreso.sia_idesec_usua,
                                       campo3 = admregistegreso.sia_nroide_usua,
                                       campo4 = admregistegreso.adm_secadm_rgad,
                                       campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                       campo6 = rgad.sia_codeps_teps,
                                       campo7 = usua.sia_priape_usua,
                                       campo8 = usua.sia_segape_usua,
                                       campo9 = usua.sia_prinom_usua,
                                       campo10 = usua.sia_segnom_usua,
                                       campo11 = (DateTime)usua.sia_fecnac_usua,
                                       campo12 = usua.sis_codsex_sexo,
                                       campo13 = espr.sis_despro_espr,
                                       campo14 = admregistegreso.adm_secegr_regr,
                                   };
                    return lcrQuery.Take(300).ToList();
                    #endregion
                }
                else if (gcrIndiceActivo == "2") // Numero de Identificacion
                {
                    #region Numero de Identificacion
                    var lcrQuery = from admregistegreso in db.Admregistegreso
                                   join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                   join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from rgad in tmadmregadmision.DefaultIfEmpty()
                                   from espr in tmsisestadoproces.DefaultIfEmpty()
                                   where admregistegreso.sia_nroide_usua.Contains(gobjTextBox11.Text.Trim()) &&
                                        admregistegreso.adm_codtat_tatn != "1" &&
                                       (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                   select new BrowerAdmision
                                   {
                                       campo1 = "ADMITIDO",
                                       campo2 = admregistegreso.sia_idesec_usua,
                                       campo3 = admregistegreso.sia_nroide_usua,
                                       campo4 = admregistegreso.adm_secadm_rgad,
                                       campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                       campo6 = rgad.sia_codeps_teps,
                                       campo7 = usua.sia_priape_usua,
                                       campo8 = usua.sia_segape_usua,
                                       campo9 = usua.sia_prinom_usua,
                                       campo10 = usua.sia_segnom_usua,
                                       campo11 = (DateTime)usua.sia_fecnac_usua,
                                       campo12 = usua.sis_codsex_sexo,
                                       campo13 = espr.sis_despro_espr,
                                       campo14 = admregistegreso.adm_secegr_regr,
                                   };
                    return lcrQuery.Take(300).ToList();
                    #endregion
                }
                else if (gcrIndiceActivo == "3") // P.Apellido S.Apellido P.Nombre
                {
                    if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()) &&
                        !String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()) &&
                        !String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region P.Apellido S.Apellido P.Nombre
                        var lcrQuery = from admregistegreso in db.Admregistegreso
                                       join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                       join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from rgad in tmadmregadmision.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                             usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) &&
                                             usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) &&
                                             admregistegreso.adm_codtat_tatn != "1" &&
                                             (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                       select new BrowerAdmision
                                       {
                                           campo1 = "ADMITIDO",
                                           campo2 = admregistegreso.sia_idesec_usua,
                                           campo3 = admregistegreso.sia_nroide_usua,
                                           campo4 = admregistegreso.adm_secadm_rgad,
                                           campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                           campo6 = rgad.sia_codeps_teps,
                                           campo7 = usua.sia_priape_usua,
                                           campo8 = usua.sia_segape_usua,
                                           campo9 = usua.sia_prinom_usua,
                                           campo10 = usua.sia_segnom_usua,
                                           campo11 = (DateTime)usua.sia_fecnac_usua,
                                           campo12 = usua.sis_codsex_sexo,
                                           campo13 = espr.sis_despro_espr,
                                           campo14 = admregistegreso.adm_secegr_regr,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()) &&
                       !String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()))
                    {
                        #region P.Apellido S.Apellido
                        var lcrQuery = from admregistegreso in db.Admregistegreso
                                       join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                       join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from rgad in tmadmregadmision.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                             usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) &&
                                             admregistegreso.adm_codtat_tatn != "1" &&
                                             (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                       select new BrowerAdmision
                                       {
                                           campo1 = "ADMITIDO",
                                           campo2 = admregistegreso.sia_idesec_usua,
                                           campo3 = admregistegreso.sia_nroide_usua,
                                           campo4 = admregistegreso.adm_secadm_rgad,
                                           campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                           campo6 = rgad.sia_codeps_teps,
                                           campo7 = usua.sia_priape_usua,
                                           campo8 = usua.sia_segape_usua,
                                           campo9 = usua.sia_prinom_usua,
                                           campo10 = usua.sia_segnom_usua,
                                           campo11 = (DateTime)usua.sia_fecnac_usua,
                                           campo12 = usua.sis_codsex_sexo,
                                           campo13 = espr.sis_despro_espr,
                                           campo14 = admregistegreso.adm_secegr_regr,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()) &&
                       !String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region P.Apellido P.Nombre
                        var lcrQuery = from admregistegreso in db.Admregistegreso
                                       join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                       join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from rgad in tmadmregadmision.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                             usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) &&
                                             admregistegreso.adm_codtat_tatn != "1" &&
                                             (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                       select new BrowerAdmision
                                       {
                                           campo1 = "ADMITIDO",
                                           campo2 = admregistegreso.sia_idesec_usua,
                                           campo3 = admregistegreso.sia_nroide_usua,
                                           campo4 = admregistegreso.adm_secadm_rgad,
                                           campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                           campo6 = rgad.sia_codeps_teps,
                                           campo7 = usua.sia_priape_usua,
                                           campo8 = usua.sia_segape_usua,
                                           campo9 = usua.sia_prinom_usua,
                                           campo10 = usua.sia_segnom_usua,
                                           campo11 = (DateTime)usua.sia_fecnac_usua,
                                           campo12 = usua.sis_codsex_sexo,
                                           campo13 = espr.sis_despro_espr,
                                           campo14 = admregistegreso.adm_secegr_regr,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()) &&
                       !String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region S.Apellido P.Nombre
                        var lcrQuery = from admregistegreso in db.Admregistegreso
                                       join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                       join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from rgad in tmadmregadmision.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) &&
                                             usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) &&
                                             admregistegreso.adm_codtat_tatn != "1" &&
                                             (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                       select new BrowerAdmision
                                       {
                                           campo1 = "ADMITIDO",
                                           campo2 = admregistegreso.sia_idesec_usua,
                                           campo3 = admregistegreso.sia_nroide_usua,
                                           campo4 = admregistegreso.adm_secadm_rgad,
                                           campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                           campo6 = rgad.sia_codeps_teps,
                                           campo7 = usua.sia_priape_usua,
                                           campo8 = usua.sia_segape_usua,
                                           campo9 = usua.sia_prinom_usua,
                                           campo10 = usua.sia_segnom_usua,
                                           campo11 = (DateTime)usua.sia_fecnac_usua,
                                           campo12 = usua.sis_codsex_sexo,
                                           campo13 = espr.sis_despro_espr,
                                           campo14 = admregistegreso.adm_secegr_regr,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()))
                    {
                        #region P.Apellido
                        var lcrQuery = from admregistegreso in db.Admregistegreso
                                       join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                       join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from rgad in tmadmregadmision.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                             admregistegreso.adm_codtat_tatn != "1" &&
                                            (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                       select new BrowerAdmision
                                       {
                                           campo1 = "ADMITIDO",
                                           campo2 = admregistegreso.sia_idesec_usua,
                                           campo3 = admregistegreso.sia_nroide_usua,
                                           campo4 = admregistegreso.adm_secadm_rgad,
                                           campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                           campo6 = rgad.sia_codeps_teps,
                                           campo7 = usua.sia_priape_usua,
                                           campo8 = usua.sia_segape_usua,
                                           campo9 = usua.sia_prinom_usua,
                                           campo10 = usua.sia_segnom_usua,
                                           campo11 = (DateTime)usua.sia_fecnac_usua,
                                           campo12 = usua.sis_codsex_sexo,
                                           campo13 = espr.sis_despro_espr,
                                           campo14 = admregistegreso.adm_secegr_regr,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()))
                    {
                        #region S.Apellido
                        var lcrQuery = from admregistegreso in db.Admregistegreso
                                       join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                       join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from rgad in tmadmregadmision.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) &&
                                             admregistegreso.adm_codtat_tatn != "1" &&
                                            (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                       select new BrowerAdmision
                                       {
                                           campo1 = "ADMITIDO",
                                           campo2 = admregistegreso.sia_idesec_usua,
                                           campo3 = admregistegreso.sia_nroide_usua,
                                           campo4 = admregistegreso.adm_secadm_rgad,
                                           campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                           campo6 = rgad.sia_codeps_teps,
                                           campo7 = usua.sia_priape_usua,
                                           campo8 = usua.sia_segape_usua,
                                           campo9 = usua.sia_prinom_usua,
                                           campo10 = usua.sia_segnom_usua,
                                           campo11 = (DateTime)usua.sia_fecnac_usua,
                                           campo12 = usua.sis_codsex_sexo,
                                           campo13 = espr.sis_despro_espr,
                                           campo14 = admregistegreso.adm_secegr_regr,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region P.Nombre
                        var lcrQuery = from admregistegreso in db.Admregistegreso
                                       join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                       join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from rgad in tmadmregadmision.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) &&
                                             admregistegreso.adm_codtat_tatn != "1" &&
                                            (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                       select new BrowerAdmision
                                       {
                                           campo1 = "ADMITIDO",
                                           campo2 = admregistegreso.sia_idesec_usua,
                                           campo3 = admregistegreso.sia_nroide_usua,
                                           campo4 = admregistegreso.adm_secadm_rgad,
                                           campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                           campo6 = rgad.sia_codeps_teps,
                                           campo7 = usua.sia_priape_usua,
                                           campo8 = usua.sia_segape_usua,
                                           campo9 = usua.sia_prinom_usua,
                                           campo10 = usua.sia_segnom_usua,
                                           campo11 = (DateTime)usua.sia_fecnac_usua,
                                           campo12 = usua.sis_codsex_sexo,
                                           campo13 = espr.sis_despro_espr,
                                           campo14 = admregistegreso.adm_secegr_regr,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else
                    {
                        #region Por Defecto
                        var lcrQuery = from admregistegreso in db.Admregistegreso
                                       join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                       join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from rgad in tmadmregadmision.DefaultIfEmpty()
                                       from espr in tmsisestadoproces.DefaultIfEmpty()
                                       where admregistegreso.adm_codtat_tatn != "1" &&
                                             (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                       select new BrowerAdmision
                                       {
                                           campo1 = "ADMITIDO",
                                           campo2 = admregistegreso.sia_idesec_usua,
                                           campo3 = admregistegreso.sia_nroide_usua,
                                           campo4 = admregistegreso.adm_secadm_rgad,
                                           campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                           campo6 = rgad.sia_codeps_teps,
                                           campo7 = usua.sia_priape_usua,
                                           campo8 = usua.sia_segape_usua,
                                           campo9 = usua.sia_prinom_usua,
                                           campo10 = usua.sia_segnom_usua,
                                           campo11 = (DateTime)usua.sia_fecnac_usua,
                                           campo12 = usua.sis_codsex_sexo,
                                           campo13 = espr.sis_despro_espr,
                                           campo14 = admregistegreso.adm_secegr_regr,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                }
                else
                {
                    #region Sin Filtro
                    var lcrQuery = from admregistegreso in db.Admregistegreso
                                   join siausuarioatend in db.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join admregadmision in db.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                   join sisestadoproces in db.Sisestadoproces on admregistegreso.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from rgad in tmadmregadmision.DefaultIfEmpty()
                                   from espr in tmsisestadoproces.DefaultIfEmpty()
                                   where admregistegreso.adm_codtat_tatn != "1" &&
                                         (admregistegreso.sis_estpro_espr == lcrEstado1 || admregistegreso.sis_estpro_espr == lcrEstado2 || admregistegreso.sis_estpro_espr == lcrEstado3)
                                   select new BrowerAdmision
                                   {
                                       campo1 = "ADMITIDO",
                                       campo2 = admregistegreso.sia_idesec_usua,
                                       campo3 = admregistegreso.sia_nroide_usua,
                                       campo4 = admregistegreso.adm_secadm_rgad,
                                       campo5 = (DateTime)rgad.adm_fecadm_rgad,
                                       campo6 = rgad.sia_codeps_teps,
                                       campo7 = usua.sia_priape_usua,
                                       campo8 = usua.sia_segape_usua,
                                       campo9 = usua.sia_prinom_usua,
                                       campo10 = usua.sia_segnom_usua,
                                       campo11 = (DateTime)usua.sia_fecnac_usua,
                                       campo12 = usua.sis_codsex_sexo,
                                       campo13 = espr.sis_despro_espr,
                                       campo14 = admregistegreso.adm_secegr_regr,
                                   };
                    return lcrQuery.Take(300).ToList();
                    #endregion
                }
            }
        }
        #endregion
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Admregistegreso()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo atención", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id Unica Usuario", Width = 120, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificación", Width = 120, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Admisión", Width = 100, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha Admisión", Width = 100, DisplayMemberBinding = new Binding("campo5") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo EPS", Width = 100, DisplayMemberBinding = new Binding("campo6") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Apellido", Width = 120, DisplayMemberBinding = new Binding("campo7") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Apellido", Width = 120, DisplayMemberBinding = new Binding("campo8") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Nombre", Width = 120, DisplayMemberBinding = new Binding("campo9") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Nombre", Width = 120, DisplayMemberBinding = new Binding("campo10") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha Nacimiento", Width = 100, DisplayMemberBinding = new Binding("campo11") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Sexo", Width = 080, DisplayMemberBinding = new Binding("campo12") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado registro", Width = 120, DisplayMemberBinding = new Binding("campo13") });
            //---------------------------
            // Lista de indices y titulos para Texbox de busqueda
            //---------------------------
            #region Configurar lista de indices
            gclListaIndices.Add(new ComboItem() { IdIndice = "1", NombreIndice = "Numero admisión", TotalCampos = 1, Titulos = new List<string> { "Numero Admisión" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "2", NombreIndice = "Identificación", TotalCampos = 1, Titulos = new List<string> { "Identificación" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "3", NombreIndice = "Apellidos y Nombre", TotalCampos = 3, Titulos = new List<string> { "Primer Apellido", "Segundo Apellido", "Primer Nombre" } });
            //---------------------------
            //Establecemos el itemssource del ComboBox a lista de Indices.
            gobListBoxIndices.ItemsSource = gclListaIndices;
            gobListBoxIndices.SelectedItem = gobListBoxIndices.Items[gnuIdIndiceInicial-1];
            // Activar el Tab de Textbox correspondiente
            fcvActivarTab("Tab" + fcrTotalCamposIndiceActivo());
            #endregion
        }
        // Seleccionar Registro
        public string fcrSelect_Admregistegreso()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerAdmision)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo14.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FACTURAS - Vsita por numero de facturas
        //----------------------------------------------------------------------
        #region FACTURAS
        #region Filtro de busquedas
        public List<BrowerAdmision> flsBuscar_Admvistadfacturas()
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                var lcrTipo1 = Funciones.fuxExtraerElemento(1, "*", gcrFiltroTabla); // Admitido - Ambulatoria
                var lcrTipo2 = lcrTipo1;
                var lcrEstado1 = Funciones.fuxExtraerElemento(2, "*", gcrFiltroTabla); // abierto - Cerrado - Anulado
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

                if (gcrIndiceActivo == "1") // Numero de admision
                {
                    #region P.Apellido S.Apellido P.Nombre
                    var lcrQuery = from fcmmaesfacturas in db.Fcmmaesfacturas
                                   join siausuarioatend in db.Siausuarioatend on fcmmaesfacturas.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join siatablaeps in db.Siatablaeps on fcmmaesfacturas.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                   join sisestadoproces in db.Sisestadoproces on fcmmaesfacturas.fcm_estfac_mfac equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from teps in tmsiatablaeps.DefaultIfEmpty()
                                   from espr in tmsisestadoproces.DefaultIfEmpty()
                                   where fcmmaesfacturas.adm_secadm_rgad.Contains(gobjTextBox11.Text.Trim()) ||
                                         fcmmaesfacturas.fcm_numfac_mfac.Contains(gobjTextBox11.Text.Trim()) ||
                                         fcmmaesfacturas.sia_nroide_usua.Contains(gobjTextBox11.Text.Trim()) ||
                                         usua.sia_priape_usua.Contains(gobjTextBox11.Text.Trim()) ||
                                         usua.sia_segape_usua.Contains(gobjTextBox11.Text.Trim()) ||
                                         usua.sia_prinom_usua.Contains(gobjTextBox11.Text.Trim())
                                   select new BrowerAdmision
                                   {
                                       campo1 = fcmmaesfacturas.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                       campo2 = fcmmaesfacturas.sia_idesec_usua,
                                       campo3 = fcmmaesfacturas.sia_nroide_usua,
                                       campo4 = fcmmaesfacturas.adm_secadm_rgad,
                                       campo6 = fcmmaesfacturas.sia_codeps_teps,
                                       campo7 = usua.sia_priape_usua,
                                       campo8 = usua.sia_segape_usua,
                                       campo9 = usua.sia_prinom_usua,
                                       campo10 = usua.sia_segnom_usua,
                                       campo12 = usua.sis_codsex_sexo,
                                       campo13 = espr.sis_despro_espr,
                                       campo14 = fcmmaesfacturas.fcm_numfac_mfac,
                                   };
                    return lcrQuery.Take(300).ToList();
                    #endregion
                }
                else
                {
                    #region Por defecto sin filtro
                    var lcrQuery = from fcmmaesfacturas in db.Fcmmaesfacturas
                                   join siausuarioatend in db.Siausuarioatend on fcmmaesfacturas.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join siatablaeps in db.Siatablaeps on fcmmaesfacturas.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                   join sisestadoproces in db.Sisestadoproces on fcmmaesfacturas.fcm_estfac_mfac equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from teps in tmsiatablaeps.DefaultIfEmpty()
                                   from espr in tmsisestadoproces.DefaultIfEmpty()
                                   select new BrowerAdmision
                                   {
                                       campo1 = fcmmaesfacturas.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                       campo2 = fcmmaesfacturas.sia_idesec_usua,
                                       campo3 = fcmmaesfacturas.sia_nroide_usua,
                                       campo4 = fcmmaesfacturas.adm_secadm_rgad,
                                       campo6 = fcmmaesfacturas.sia_codeps_teps,
                                       campo7 = usua.sia_priape_usua,
                                       campo8 = usua.sia_segape_usua,
                                       campo9 = usua.sia_prinom_usua,
                                       campo10 = usua.sia_segnom_usua,
                                       campo12 = usua.sis_codsex_sexo,
                                       campo13 = espr.sis_despro_espr,
                                       campo14 = fcmmaesfacturas.fcm_numfac_mfac,
                                   };
                    return lcrQuery.Take(300).ToList();
                    #endregion
                }
            }
        }
        #endregion
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Admvistadfacturas()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo atención", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id Unica Usuario", Width = 120, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificación", Width = 120, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Admisión", Width = 100, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Factura", Width = 120, DisplayMemberBinding = new Binding("campo14") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo EPS", Width = 100, DisplayMemberBinding = new Binding("campo6") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Apellido", Width = 120, DisplayMemberBinding = new Binding("campo7") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Apellido", Width = 120, DisplayMemberBinding = new Binding("campo8") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Nombre", Width = 120, DisplayMemberBinding = new Binding("campo9") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Nombre", Width = 120, DisplayMemberBinding = new Binding("campo10") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado registro", Width = 120, DisplayMemberBinding = new Binding("campo13") });
            //---------------------------
            // Lista de indices y titulos para Texbox de busqueda
            //---------------------------
            #region Configurar lista de indices
            gclListaIndices.Add(new ComboItem() { IdIndice = "1", NombreIndice = "Filtro", TotalCampos = 1, Titulos = new List<string> { "Filtro" } });
            //---------------------------
            //Establecemos el itemssource del ComboBox a lista de Indices.
            gobListBoxIndices.ItemsSource = gclListaIndices;
            gobListBoxIndices.SelectedItem = gobListBoxIndices.Items[gnuIdIndiceInicial - 1];
            // Activar el Tab de Textbox correspondiente
            fcvActivarTab("Tab" + fcrTotalCamposIndiceActivo());
            #endregion
        }
        // Seleccionar Registro
        public string fcrSelect_Admvistadfacturas()
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
    }
}

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
    public class SIS_Browser01 : AuxBrowser01
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
                case "SISESTADOREGIST":
                    fcvAddColGrid_Sisestadoregist();
                    gobDataGrid.ItemsSource = flsBuscar_Sisestadoregist(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTABLASEXOS":
                    fcvAddColGrid_Sistablasexos();
                    gobDataGrid.ItemsSource = flsBuscar_Sistablasexos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTABMUNICIPIO":
                    fcvAddColGrid_Sistabmunicipio();
                    gobDataGrid.ItemsSource = flsBuscar_Sistabmunicipio(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTABDEPARTAME":
                    fcvAddColGrid_Sistabdepartame();
                    gobDataGrid.ItemsSource = flsBuscar_Sistabdepartame(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISZONARESIDENC":
                    fcvAddColGrid_Siszonaresidenc();
                    gobDataGrid.ItemsSource = flsBuscar_Siszonaresidenc(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISACTUALIZCAMP":
                    fcvAddColGrid_Sisactualizcamp();
                    gobDataGrid.ItemsSource = flsBuscar_Sisactualizcamp(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISACTUALIZCAMPIU":
                    fcvAddColGrid_SisactualizcampIu();
                    gobDataGrid.ItemsSource = flsBuscar_SisactualizcampIu(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISMAESPLAVALID":
                    fcvAddColGrid_Sismaesplavalid();
                    gobDataGrid.ItemsSource = flsBuscar_Sismaesplavalid(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTIPOARCHIVOS":
                    fcvAddColGrid_Sistipoarchivos();
                    gobDataGrid.ItemsSource = flsBuscar_Sistipoarchivos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISMADEPLAVALID":
                    fcvAddColGrid_Sismadeplavalid();
                    gobDataGrid.ItemsSource = flsBuscar_Sismadeplavalid(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISSALARIOMIN":
                    fcvAddColGrid_Sissalariomin();
                    gobDataGrid.ItemsSource = flsBuscar_Sissalariomin(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTABLAIVA":
                    fcvAddColGrid_Sistablaiva();
                    gobDataGrid.ItemsSource = flsBuscar_Sistablaiva(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISOCUPACIONES":
                    fcvAddColGrid_Sisocupaciones();
                    gobDataGrid.ItemsSource = flsBuscar_Sisocupaciones(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISPROVEEDORES":
                    fcvAddColGrid_Sisproveedores();
                    gobDataGrid.ItemsSource = flsBuscar_Sisproveedores(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISGRUPOMEDIDAS":
                    fcvAddColGrid_Sisgrupomedidas();
                    gobDataGrid.ItemsSource = flsBuscar_Sisgrupomedidas(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISUNIDADMEDIDA":
                    fcvAddColGrid_Sisunidadmedida();
                    gobDataGrid.ItemsSource = flsBuscar_Sisunidadmedida(gcrFiltroDatos, gcrFiltroTabla);
                    break;               

                case "SISMAESDEPENDEN":
                    fcvAddColGrid_Sismaesdependen();
                    gobDataGrid.ItemsSource = flsBuscar_Sismaesdependen(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISMAESTERCEROS":
                    fcvAddColGrid_Sismaesterceros();
                    gobDataGrid.ItemsSource = flsBuscar_Sismaesterceros(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISMAESTERCEROS-NIT":
                    fcvAddColGrid_Sismaesterceros();
                    gobDataGrid.ItemsSource = flsBuscar_Sismaesterceros(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTIPIDTERCER":
                    fcvAddColGrid_Sistipidtercer();
                    gobDataGrid.ItemsSource = flsBuscar_Sistipidtercer(gcrFiltroDatos, gcrFiltroTabla);
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
                case "SISESTADOREGIST":
                    tobDataGrid.ItemsSource = flsBuscar_Sisestadoregist(gcrFiltroDatos, gcrFiltroTabla);
                    break;
                
                case "SISTABLASEXOS":
                    tobDataGrid.ItemsSource = flsBuscar_Sistablasexos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTABMUNICIPIO":
                    tobDataGrid.ItemsSource = flsBuscar_Sistabmunicipio(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTABDEPARTAME":
                    tobDataGrid.ItemsSource = flsBuscar_Sistabdepartame(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISZONARESIDENC":
                    tobDataGrid.ItemsSource = flsBuscar_Siszonaresidenc(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISACTUALIZCAMP":
                    tobDataGrid.ItemsSource = flsBuscar_Sisactualizcamp(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISACTUALIZCAMPIU":
                    tobDataGrid.ItemsSource = flsBuscar_SisactualizcampIu(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISMAESPLAVALID":
                    tobDataGrid.ItemsSource = flsBuscar_Sismaesplavalid(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTIPOARCHIVOS":
                    tobDataGrid.ItemsSource = flsBuscar_Sistipoarchivos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISMADEPLAVALID":
                    tobDataGrid.ItemsSource = flsBuscar_Sismadeplavalid(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISSALARIOMIN":
                    tobDataGrid.ItemsSource = flsBuscar_Sissalariomin(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTABLAIVA":
                    tobDataGrid.ItemsSource = flsBuscar_Sistablaiva(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISOCUPACIONES":
                    tobDataGrid.ItemsSource = flsBuscar_Sisocupaciones(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISPROVEEDORES":
                    tobDataGrid.ItemsSource = flsBuscar_Sisproveedores(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISGRUPOMEDIDAS":
                    tobDataGrid.ItemsSource = flsBuscar_Sisgrupomedidas(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISUNIDADMEDIDA":
                    tobDataGrid.ItemsSource = flsBuscar_Sisunidadmedida(gcrFiltroDatos, gcrFiltroTabla);
                    break;
                
                case "SISMAESDEPENDEN":
                    tobDataGrid.ItemsSource = flsBuscar_Sismaesdependen(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISMAESTERCEROS":
                    tobDataGrid.ItemsSource = flsBuscar_Sismaesterceros(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISMAESTERCEROS-NIT":
                    tobDataGrid.ItemsSource = flsBuscar_Sismaesterceros(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SISTIPIDTERCER":
                    tobDataGrid.ItemsSource = flsBuscar_Sistipidtercer(gcrFiltroDatos, gcrFiltroTabla);
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
                case "SISESTADOREGIST":
                    lcrReturnCodigo = fcrSelect_Sisestadoregist();
                    break;
                
                case "SISTABLASEXOS":
                    lcrReturnCodigo = fcrSelect_Sistablasexos();
                    break;

                case "SISTABMUNICIPIO":
                    lcrReturnCodigo = fcrSelect_Sistabmunicipio();
                    break;

                case "SISTABDEPARTAME":
                    lcrReturnCodigo = fcrSelect_Sistabdepartame();
                    break;

                case "SISZONARESIDENC":
                    lcrReturnCodigo = fcrSelect_Siszonaresidenc();
                    break;

                case "SISACTUALIZCAMP":
                    lcrReturnCodigo = fcrSelect_Sisactualizcamp();
                    break;

                case "SISACTUALIZCAMPIU":
                    lcrReturnCodigo = fcrSelect_SisactualizcampIu();
                    break;

                case "SISMAESPLAVALID":
                    lcrReturnCodigo = fcrSelect_Sismaesplavalid();
                    break;

                case "SISTIPOARCHIVOS":
                    lcrReturnCodigo = fcrSelect_Sistipoarchivos();
                    break;

                case "SISMADEPLAVALID":
                    lcrReturnCodigo = fcrSelect_Sismadeplavalid();
                    break;

                case "SISSALARIOMIN":
                    lcrReturnCodigo = fcrSelect_Sissalariomin();
                    break;

                case "SISTABLAIVA":
                    lcrReturnCodigo = fcrSelect_Sistablaiva();
                    break;

                case "SISOCUPACIONES":
                    lcrReturnCodigo = fcrSelect_Sisocupaciones();
                    break;

                case "SISPROVEEDORES":
                    lcrReturnCodigo = fcrSelect_Sisproveedores();
                    break;

                case "SISGRUPOMEDIDAS":
                    lcrReturnCodigo = fcrSelect_Sisgrupomedidas();
                    break;

                case "SISUNIDADMEDIDA":
                    lcrReturnCodigo = fcrSelect_Sisunidadmedida();
                    break;
             
                case "SISMAESDEPENDEN":
                    lcrReturnCodigo = fcrSelect_Sismaesdependen();
                    break;

                case "SISMAESTERCEROS":
                    lcrReturnCodigo = fcrSelect_Sismaesterceros("ID");
                    break;

                case "SISMAESTERCEROS-NIT":
                    lcrReturnCodigo = fcrSelect_Sismaesterceros("NIT");
                    break;

                case "SISTIPIDTERCER":
                    lcrReturnCodigo = fcrSelect_Sistipidtercer();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISESTADOREGIST - Estados de registros (Activos o Inactivos)
        //----------------------------------------------------------------------
        #region SISESTADOREGIST
        public static List<EFsisestadoregist> flsBuscar_Sisestadoregist(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISESTADOREGIST", tcrBuscar, "like", "OR", "sis_estreg_esrg,sis_desest_esrg", tcrFiltroTabla);
                ObjectQuery<EFsisestadoregist> lcrQuery = new ObjectQuery<EFsisestadoregist>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sisestadoregist()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo Estado Registro", Width = 120, DisplayMemberBinding = new Binding("sis_estreg_esrg") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Decripción estado registro", Width = 400, DisplayMemberBinding = new Binding("sis_desest_esrg") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sisestadoregist()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsisestadoregist)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_estreg_esrg.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISTABLASEXOS - Sexo Personas
        //----------------------------------------------------------------------
        #region SISTABLASEXOS
        public static List<EFsistablasexos> flsBuscar_Sistablasexos(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISTABLASEXOS", tcrBuscar, "like", "OR", "sis_codsex_sexo,sis_dessex_sexo", tcrFiltroTabla);
                ObjectQuery<EFsistablasexos> lcrQuery = new ObjectQuery<EFsistablasexos>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sistablasexos()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("sis_codsex_sexo") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Sexo", Width = 400, DisplayMemberBinding = new Binding("sis_dessex_sexo") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sistablasexos()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsistablasexos)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_codsex_sexo.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISTABMUNICIPIO - Listado de Municipios  DANE
        //----------------------------------------------------------------------
        #region SISTABMUNICIPIO
        public static List<EFsistabmunicipio> flsBuscar_Sistabmunicipio(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISTABMUNICIPIO", tcrBuscar, "like", "OR", "sis_idemun_muni,sis_nommun_muni", tcrFiltroTabla);
                ObjectQuery<EFsistabmunicipio> lcrQuery = new ObjectQuery<EFsistabmunicipio>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sistabmunicipio()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id Unico Municipio", Width = 120, DisplayMemberBinding = new Binding("sis_idemun_muni") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre del Muncipio", Width = 400, DisplayMemberBinding = new Binding("sis_nommun_muni") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sistabmunicipio()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsistabmunicipio)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_idemun_muni.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISTABDEPARTAME - Departamentos del Pais DANE
        //----------------------------------------------------------------------
        #region SISTABDEPARTAME
        public static List<EFsistabdepartame> flsBuscar_Sistabdepartame(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISTABDEPARTAME", tcrBuscar, "like", "OR", "sis_coddep_dpto,sis_desdep_dpto", tcrFiltroTabla);
                ObjectQuery<EFsistabdepartame> lcrQuery = new ObjectQuery<EFsistabdepartame>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sistabdepartame()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo Dpartamento", Width = 120, DisplayMemberBinding = new Binding("sis_coddep_dpto") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre del departamento", Width = 400, DisplayMemberBinding = new Binding("sis_desdep_dpto") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sistabdepartame()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsistabdepartame)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_coddep_dpto.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISZONARESIDENC - Zona de residencia
        //----------------------------------------------------------------------
        #region SISZONARESIDENC
        public static List<EFsiszonaresidenc> flsBuscar_Siszonaresidenc(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISZONARESIDENC", tcrBuscar, "like", "OR", "sis_zonres_tzon,sis_deszon_tzon", tcrFiltroTabla);
                ObjectQuery<EFsiszonaresidenc> lcrQuery = new ObjectQuery<EFsiszonaresidenc>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siszonaresidenc()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo Zona residencia", Width = 120, DisplayMemberBinding = new Binding("sis_zonres_tzon") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Zona de residencia", Width = 400, DisplayMemberBinding = new Binding("sis_deszon_tzon") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siszonaresidenc()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiszonaresidenc)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_zonres_tzon.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISACTUALIZCAMP - Campos actalizables según archivo
        //----------------------------------------------------------------------
        #region SISACTUALIZCAMP
        public static List<EFsisactualizcamp> flsBuscar_Sisactualizcamp(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISACTUALIZCAMP", tcrBuscar, "like", "OR", "sis_secreg_siac,sis_nomcam_siac", tcrFiltroTabla);
                ObjectQuery<EFsisactualizcamp> lcrQuery = new ObjectQuery<EFsisactualizcamp>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sisactualizcamp()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo unico", Width = 130, DisplayMemberBinding = new Binding("sis_secreg_siac") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo", Width = 80, DisplayMemberBinding = new Binding("sis_tipval_siac") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Titulo o Etiqueta", Width = 400, DisplayMemberBinding = new Binding("sis_nomcam_siac") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sisactualizcamp()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsisactualizcamp)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_secreg_siac.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISACTUALIZCAMP - IU - Campos actalizables según archivo
        //----------------------------------------------------------------------
        #region SISACTUALIZCAMP
        public static List<EFsisactualizcamp> flsBuscar_SisactualizcampIu(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISACTUALIZCAMP", tcrBuscar, "like", "OR", "sis_codcam_siac,sis_nomcam_siac", tcrFiltroTabla);
                ObjectQuery<EFsisactualizcamp> lcrQuery = new ObjectQuery<EFsisactualizcamp>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_SisactualizcampIu()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Campo", Width = 130, DisplayMemberBinding = new Binding("sis_codcam_siac") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo", Width = 80, DisplayMemberBinding = new Binding("sis_tipval_siac") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Titulo o Etiqueta campo", Width = 400, DisplayMemberBinding = new Binding("sis_nomcam_siac") });
        }
        // Seleccionar Registro
        public string fcrSelect_SisactualizcampIu()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsisactualizcamp)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_codcam_siac.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISMAESPLAVALID - Maestro plantillas para validación de archivos
        //----------------------------------------------------------------------
        #region SISMAESPLAVALID
        public static List<EFsismaesplavalid> flsBuscar_Sismaesplavalid(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISMAESPLAVALID", tcrBuscar, "like", "OR", "sis_secreg_siva,sis_despla_siva", tcrFiltroTabla);
                ObjectQuery<EFsismaesplavalid> lcrQuery = new ObjectQuery<EFsismaesplavalid>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sismaesplavalid()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("sis_secreg_siva") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Plantilla", Width = 500, DisplayMemberBinding = new Binding("sis_despla_siva") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sismaesplavalid()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsismaesplavalid)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_secreg_siva.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISTIPOARCHIVOS - Clasificacion de archivos para gestion de datos e informes
        //----------------------------------------------------------------------
        #region SISTIPOARCHIVOS
        public static List<EFsistipoarchivos> flsBuscar_Sistipoarchivos(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISTIPOARCHIVOS", tcrBuscar, "like", "OR", "sis_codarc_siar,sis_desarc_siar", tcrFiltroTabla);
                ObjectQuery<EFsistipoarchivos> lcrQuery = new ObjectQuery<EFsistipoarchivos>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sistipoarchivos()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificador", Width = 120, DisplayMemberBinding = new Binding("sis_codarc_siar") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Archivo", Width = 400, DisplayMemberBinding = new Binding("sis_desarc_siar") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sistipoarchivos()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsistipoarchivos)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_codarc_siar.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISMADEPLAVALID - Registros o campos detalle para plantillas de validación
        //----------------------------------------------------------------------
        #region SISMADEPLAVALID
        public static List<EFsismadeplavalid> flsBuscar_Sismadeplavalid(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISMADEPLAVALID", tcrBuscar, "like", "OR", "sis_secreg_sivd,sis_codcam_sivd,sis_nomcam_sivd", tcrFiltroTabla);
                ObjectQuery<EFsismadeplavalid> lcrQuery = new ObjectQuery<EFsismadeplavalid>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sismadeplavalid()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Campo", Width = 80, DisplayMemberBinding = new Binding("sis_ordvis_sivd") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre interno", Width = 140, DisplayMemberBinding = new Binding("sis_codcam_sivd") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Etiqueta", Width = 420, DisplayMemberBinding = new Binding("sis_nomcam_sivd") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sismadeplavalid()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsismadeplavalid)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_secreg_sivd.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISSALARIOMIN - Tabla de salarios minimos mensuales
        //----------------------------------------------------------------------
        #region SISSALARIOMIN
        public static List<EFsissalariomin> flsBuscar_Sissalariomin(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISSALARIOMIN", tcrBuscar, "like", "OR", "sis_codsal_tsal,sis_dessal_tsal", tcrFiltroTabla);
                ObjectQuery<EFsissalariomin> lcrQuery = new ObjectQuery<EFsissalariomin>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sissalariomin()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("sis_codsal_tsal") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Año del salario", Width = 400, DisplayMemberBinding = new Binding("sis_dessal_tsal") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sissalariomin()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsissalariomin)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_codsal_tsal.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISTABLAIVA - Tabla de valores para el I.V.A.
        //----------------------------------------------------------------------
        #region SISTABLAIVA
        public static List<EFsistablaiva> flsBuscar_Sistablaiva(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISTABLAIVA", tcrBuscar, "like", "OR", "sis_codiva_tiva,sis_desiva_tiva", tcrFiltroTabla);
                ObjectQuery<EFsistablaiva> lcrQuery = new ObjectQuery<EFsistablaiva>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sistablaiva()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("sis_codiva_tiva") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 400, DisplayMemberBinding = new Binding("sis_desiva_tiva") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sistablaiva()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsistablaiva)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_codiva_tiva.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISOCUPACIONES - Tabla ocupaciones o profesiones
        //----------------------------------------------------------------------
        #region SISOCUPACIONES
        public static List<EFsisocupaciones> flsBuscar_Sisocupaciones(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISOCUPACIONES", tcrBuscar, "like", "OR", "sis_codocu_ocup,sis_desocu_ocup", tcrFiltroTabla);
                ObjectQuery<EFsisocupaciones> lcrQuery = new ObjectQuery<EFsisocupaciones>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sisocupaciones()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("sis_codocu_ocup") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Ocupación", Width = 400, DisplayMemberBinding = new Binding("sis_desocu_ocup") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sisocupaciones()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsisocupaciones)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_codocu_ocup.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISPROVEEDORES - Maestro Proveedores
        //----------------------------------------------------------------------
        #region SISPROVEEDORES
        public static List<EFsisproveedores> flsBuscar_Sisproveedores(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISPROVEEDORES", tcrBuscar, "like", "OR", "sis_secpro_sipr,sis_razsoc_sipr", tcrFiltroTabla);
                ObjectQuery<EFsisproveedores> lcrQuery = new ObjectQuery<EFsisproveedores>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sisproveedores()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("sis_secpro_sipr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nit", Width = 120, DisplayMemberBinding = new Binding("sis_nitpro_sipr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Razón Social", Width = 400, DisplayMemberBinding = new Binding("sis_razsoc_sipr") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sisproveedores()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsisproveedores)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_secpro_sipr.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISGRUPOMEDIDAS - Tabla Grupo de Medidas
        //----------------------------------------------------------------------
        #region SISGRUPOMEDIDAS
        public static List<EFsisgrupomedidas> flsBuscar_Sisgrupomedidas(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISGRUPOMEDIDAS", tcrBuscar, "like", "OR", "sis_codgme_sigr,sis_desgme_sigr", tcrFiltroTabla);
                ObjectQuery<EFsisgrupomedidas> lcrQuery = new ObjectQuery<EFsisgrupomedidas>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sisgrupomedidas()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("sis_codgme_sigr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Grupo medida", Width = 400, DisplayMemberBinding = new Binding("sis_desgme_sigr") });
        }
        // Seleccionar Registro
        public String fcrSelect_Sisgrupomedidas()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsisgrupomedidas)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_codgme_sigr.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISUNIDADMEDIDA - Tabla Unidades de Medidas
        //----------------------------------------------------------------------
        #region SISUNIDADMEDIDA
        public static List<BrowerTabla> flsBuscar_Sisunidadmedida(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                if (String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    var lobConsulta = from sisunidadmedida in db.Sisunidadmedida
                                      join sisgrupomedidas in db.Sisgrupomedidas on sisunidadmedida.sis_codgme_sigr equals sisgrupomedidas.sis_codgme_sigr into tmsisgrupomedidas
                                      from sigr in tmsisgrupomedidas.DefaultIfEmpty()
                                      orderby sigr.sis_desgme_sigr
                                      select new BrowerTabla
                                      {
                                          #region Datos
                                          campo1 = sisunidadmedida.sis_codume_sium,
                                          campo2 = sisunidadmedida.sis_desume_sium,
                                          campo3 = sisunidadmedida.sis_codgme_sigr,
                                          campo4 = sigr.sis_desgme_sigr,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sisunidadmedida in db.Sisunidadmedida
                                      join sisgrupomedidas in db.Sisgrupomedidas on sisunidadmedida.sis_codgme_sigr equals sisgrupomedidas.sis_codgme_sigr into tmsisgrupomedidas
                                      from sigr in tmsisgrupomedidas.DefaultIfEmpty()
                                       where sisunidadmedida.sis_codume_sium.Contains(tcrBuscar) ||
                                            sisunidadmedida.sis_desume_sium.Contains(tcrBuscar) ||
                                            sigr.sis_desgme_sigr.Contains(tcrBuscar)
                                      orderby sigr.sis_desgme_sigr
                                      select new BrowerTabla
                                      {
                                          #region Datos
                                          campo1 = sisunidadmedida.sis_codume_sium,
                                          campo2 = sisunidadmedida.sis_desume_sium,
                                          campo3 = sisunidadmedida.sis_codgme_sigr,
                                          campo4 = sigr.sis_desgme_sigr,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sisunidadmedida()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 90, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Grupo medida", Width = 150, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Subgrupo", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Subgrupo medida", Width = 250, DisplayMemberBinding = new Binding("campo2") });
        }
        // Seleccionar Registro
        public String fcrSelect_Sisunidadmedida()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerTabla)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo1.Trim();
            }
            return lcrReturn;
        }
        #endregion       
        //----------------------------------------------------------------------
        //    TABLA: SISMAESDEPENDEN - Dependencias o areas funcionales de la empresa
        //----------------------------------------------------------------------
        #region SISMAESDEPENDEN
        public static List<EFsismaesdependen> flsBuscar_Sismaesdependen(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISMAESDEPENDEN", tcrBuscar, "like", "OR", "sis_coddep_sidp,sis_nomdep_sidp", tcrFiltroTabla);
                ObjectQuery<EFsismaesdependen> lcrQuery = new ObjectQuery<EFsismaesdependen>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sismaesdependen()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo dependencia", Width = 120, DisplayMemberBinding = new Binding("sis_coddep_sidp") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre dependencia", Width = 400, DisplayMemberBinding = new Binding("sis_nomdep_sidp") });
        }
        // Seleccionar Registro
        public String fcrSelect_Sismaesdependen()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsismaesdependen)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_coddep_sidp.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISMAESTERCEROS - Tabla terceros para gestion contable
        //----------------------------------------------------------------------
        #region SISMAESTERCEROS
        public static List<EFsismaesterceros> flsBuscar_Sismaesterceros(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISMAESTERCEROS", tcrBuscar, "like", "OR", "sis_idterc_sitr,sis_numide_sitr,sis_numprn_sitr,sis_razsoc_sitr", tcrFiltroTabla);
                ObjectQuery<EFsismaesterceros> lcrQuery = new ObjectQuery<EFsismaesterceros>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sismaesterceros()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo unico tercero", Width = 120, DisplayMemberBinding = new Binding("sis_idterc_sitr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nit", Width = 120, DisplayMemberBinding = new Binding("sis_numide_sitr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre / Razon social", Width = 400, DisplayMemberBinding = new Binding("sis_razsoc_sitr") });
        }
        // Seleccionar Registro
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tcrTipoID">Tipo Id para devolver: "ID"=Codigo unico "NIT"=Numero Nit</param>
        /// <returns></returns>
        public String fcrSelect_Sismaesterceros(string tcrTipoID)
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsismaesterceros)gobDataGrid.Items[gobDataGrid.SelectedIndex];

                lcrReturn = tcrTipoID == "ID"? objReg.sis_idterc_sitr.Trim(): objReg.sis_numide_sitr.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SISTIPIDTERCER - Tipo identificacion tercero contable
        //----------------------------------------------------------------------
        #region SISTIPIDTERCER
        public static List<EFsistipidtercer> flsBuscar_Sistipidtercer(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SISTIPIDTERCER", tcrBuscar, "like", "OR", "sis_tipide_tido,sis_deside_tido", tcrFiltroTabla);
                ObjectQuery<EFsistipidtercer> lcrQuery = new ObjectQuery<EFsistipidtercer>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sistipidtercer()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo", Width = 120, DisplayMemberBinding = new Binding("sis_tipide_tido") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción tipo documento", Width = 400, DisplayMemberBinding = new Binding("sis_deside_tido") });
        }
        // Seleccionar Registro
        public String fcrSelect_Sistipidtercer()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsistipidtercer)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sis_tipide_tido.Trim();
            }
            return lcrReturn;
        }
        #endregion

    }
}

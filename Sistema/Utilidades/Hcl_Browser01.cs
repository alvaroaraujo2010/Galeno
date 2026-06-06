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

namespace Sistema.Utilidades
{
    public class HCL_Browser01 : ViewModelBase
    {
        //-----------------------------------
        //- Clase Cargar Browser de la tabla
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerTabla
        {
            public BrowerTabla() { }
            public String campo1 { get; set; }
            public String campo2 { get; set; }
            public String campo3 { get; set; }
            public String campo4 { get; set; }
            public String campo5 { get; set; }
            public String campo6 { get; set; }
            public String campo7 { get; set; }
            public String campo8 { get; set; }
            public String campo9 { get; set; }
            public String campo10 { get; set; }
            public String campo11 { get; set; }
            public String campo12 { get; set; }
            public String campo13 { get; set; }
            public String campo14 { get; set; }
            public DateTime campo15 { get; set; }
            public DateTime campo16 { get; set; }
            public DateTime campo17 { get; set; }
            public DateTime campo18 { get; set; }
            public DateTime campo19 { get; set; }
            public DateTime campo20 { get; set; }
        }
        #endregion
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
                case "HCLMAESTROHISCL":
                    fcvAddColGrid_Hclmaestrohiscl();
                    gobDataGrid.ItemsSource = flsBuscar_Hclmaestrohiscl(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLTIPOREGTURNO":
                    fcvAddColGrid_Hcltiporegturno();
                    gobDataGrid.ItemsSource = flsBuscar_Hcltiporegturno(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLTIPOLIQUIDOS":
                    fcvAddColGrid_Hcltipoliquidos();
                    gobDataGrid.ItemsSource = flsBuscar_Hcltipoliquidos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLVIASLIQUIDOS":
                    fcvAddColGrid_Hclviasliquidos();
                    gobDataGrid.ItemsSource = flsBuscar_Hclviasliquidos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLTIPOREGACTIV":
                    fcvAddColGrid_Hcltiporegactiv();
                    gobDataGrid.ItemsSource = flsBuscar_Hcltiporegactiv(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLVARIABMAESTR":
                    fcvAddColGrid_Hclvariabmaestr();
                    gobDataGrid.ItemsSource = flsBuscar_Hclvariabmaestr(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLVARIABGRUPOS":
                    fcvAddColGrid_Hclvariabgrupos();
                    gobDataGrid.ItemsSource = flsBuscar_Hclvariabgrupos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLFORMATVISTMA":
                    fcvAddColGrid_Hclformatvistma();
                    gobDataGrid.ItemsSource = flsBuscar_Hclformatvistma(gcrFiltroDatos, gcrFiltroTabla);
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
                case "HCLMAESTROHISCL":
                    tobDataGrid.ItemsSource = flsBuscar_Hclmaestrohiscl(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLTIPOREGTURNO":
                    tobDataGrid.ItemsSource = flsBuscar_Hcltiporegturno(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLTIPOLIQUIDOS":
                    tobDataGrid.ItemsSource = flsBuscar_Hcltipoliquidos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLVIASLIQUIDOS":
                    tobDataGrid.ItemsSource = flsBuscar_Hclviasliquidos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLTIPOREGACTIV":
                    tobDataGrid.ItemsSource = flsBuscar_Hcltiporegactiv(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLVARIABMAESTR":
                    tobDataGrid.ItemsSource = flsBuscar_Hclvariabmaestr(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLVARIABGRUPOS":
                    tobDataGrid.ItemsSource = flsBuscar_Hclvariabgrupos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HCLFORMATVISTMA":
                    tobDataGrid.ItemsSource = flsBuscar_Hclformatvistma(gcrFiltroDatos, gcrFiltroTabla);
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
                case "HCLMAESTROHISCL":
                    lcrReturnCodigo = fcrSelect_Hclmaestrohiscl();
                    break;

                case "HCLTIPOREGTURNO":
                    lcrReturnCodigo = fcrSelect_Hcltiporegturno();
                    break;

                case "HCLTIPOLIQUIDOS":
                    lcrReturnCodigo = fcrSelect_Hcltipoliquidos();
                    break;

                case "HCLVIASLIQUIDOS":
                    lcrReturnCodigo = fcrSelect_Hclviasliquidos();
                    break;

                case "HCLTIPOREGACTIV":
                    lcrReturnCodigo = fcrSelect_Hcltiporegactiv();
                    break;

                case "HCLVARIABMAESTR":
                    lcrReturnCodigo = fcrSelect_Hclvariabmaestr();
                    break;

                case "HCLVARIABGRUPOS":
                    lcrReturnCodigo = fcrSelect_Hclvariabgrupos();
                    break;

                case "HCLFORMATVISTMA":
                    lcrReturnCodigo = fcrSelect_Hclformatvistma();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: HCLMAESTROHISCL - Maestro de historias clínicas
        //----------------------------------------------------------------------
        #region HCLMAESTROHISCL
        public static List<EFhclmaestrohiscl> flsBuscar_Hclmaestrohiscl(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("HCLMAESTROHISCL", tcrBuscar, "like", "OR", "hcl_nrohis_hicl,hcl_notape_hicl", tcrFiltroTabla);
                ObjectQuery<EFhclmaestrohiscl> lcrQuery = new ObjectQuery<EFhclmaestrohiscl>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Hclmaestrohiscl()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Número historia", Width = 130, DisplayMemberBinding = new Binding("hcl_nrohis_hicl") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo Id", Width = 70, DisplayMemberBinding = new Binding("sia_tipide_tide") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificación", Width = 120, DisplayMemberBinding = new Binding("sia_nroide_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Paciente", Width = 400, DisplayMemberBinding = new Binding("campo1") });
        }
        // Seleccionar Registro
        public string fcrSelect_Hclmaestrohiscl()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhclmaestrohiscl)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hcl_nrohis_hicl.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: HCLTIPOREGTURNO - Tipo registro turnos diarios prestacion de servicios medicos
        //----------------------------------------------------------------------
        #region HCLTIPOREGTURNO
        public static List<EFhcltiporegturno> flsBuscar_Hcltiporegturno(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("HCLTIPOREGTURNO", tcrBuscar, "like", "OR", "hcl_tiptur_hctu,hcl_destur_hctu", tcrFiltroTabla);
                ObjectQuery<EFhcltiporegturno> lcrQuery = new ObjectQuery<EFhcltiporegturno>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Hcltiporegturno()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo turno", Width = 120, DisplayMemberBinding = new Binding("hcl_tiptur_hctu") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion", Width = 420, DisplayMemberBinding = new Binding("hcl_destur_hctu") });
        }
        // Seleccionar Registro
        public string fcrSelect_Hcltiporegturno()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhcltiporegturno)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hcl_tiptur_hctu.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: HCLTIPOLIQUIDOS - Nombres tipos de liquidos administrados o eliminados
        //----------------------------------------------------------------------
        #region HCLTIPOLIQUIDOS
        public static List<EFhcltipoliquidos> flsBuscar_Hcltipoliquidos(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("HCLTIPOLIQUIDOS", tcrBuscar, "like", "OR", "hcl_codliq_hctl,hcl_desliq_hctl", tcrFiltroTabla);
                ObjectQuery<EFhcltipoliquidos> lcrQuery = new ObjectQuery<EFhcltipoliquidos>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Hcltipoliquidos()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo liquido", Width = 120, DisplayMemberBinding = new Binding("hcl_codliq_hctl") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion liquido", Width = 400, DisplayMemberBinding = new Binding("hcl_desliq_hctl") });
        }
        // Seleccionar Registro
        public string fcrSelect_Hcltipoliquidos()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhcltipoliquidos)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hcl_codliq_hctl.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: HCLVIASLIQUIDOS - Vias de administración o eliminación de  liquidos
        //----------------------------------------------------------------------
        #region HCLVIASLIQUIDOS
        public static List<EFhclviasliquidos> flsBuscar_Hclviasliquidos(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("HCLVIASLIQUIDOS", tcrBuscar, "like", "OR", "hcl_vialiq_hcvl,hcl_desvia_hcvl", tcrFiltroTabla);
                ObjectQuery<EFhclviasliquidos> lcrQuery = new ObjectQuery<EFhclviasliquidos>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Hclviasliquidos()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Vias de liquidos", Width = 120, DisplayMemberBinding = new Binding("hcl_vialiq_hcvl") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion vias", Width = 400, DisplayMemberBinding = new Binding("hcl_desvia_hcvl") });
        }
        // Seleccionar Registro
        public string fcrSelect_Hclviasliquidos()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhclviasliquidos)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hcl_vialiq_hcvl.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: HCLTIPOREGACTIV - Tipo registro de actividad en historial
        //----------------------------------------------------------------------
        #region HCLTIPOREGACTIV
        public static List<EFhcltiporegactiv> flsBuscar_Hcltiporegactiv(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("HCLTIPOREGACTIV", tcrBuscar, "like", "OR", "hcl_codreg_hcca,hcl_desreg_hcca", tcrFiltroTabla);
                ObjectQuery<EFhcltiporegactiv> lcrQuery = new ObjectQuery<EFhcltiporegactiv>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Hcltiporegactiv()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo actividad", Width = 150, DisplayMemberBinding = new Binding("hcl_codreg_hcca") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion", Width = 430, DisplayMemberBinding = new Binding("hcl_desreg_hcca") });
        }
        // Seleccionar Registro
        public string fcrSelect_Hcltiporegactiv()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhcltiporegactiv)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hcl_codreg_hcca.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: HCLVARIABMAESTR - Maestro Variables publicas de gestion en formatos
        //----------------------------------------------------------------------
        #region HCLVARIABMAESTR
        public static List<BrowerTabla> flsBuscar_Hclvariabmaestr(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    #region Datos
                    var lobConsulta = from hclvariabmaestr in db.Hclvariabmaestr
                                      join hclvariabgrupos in db.Hclvariabgrupos on hclvariabmaestr.hcl_secgru_hcgv equals hclvariabgrupos.hcl_secgru_hcgv into tmhclvariabgrupos

                                      from hcgv in tmhclvariabgrupos.DefaultIfEmpty()
                                      where hclvariabmaestr.sis_estreg_esrg == "1"
                                      orderby hcgv.hcl_secgru_hcgv, hclvariabmaestr.hcl_ordvis_hcvr
                                      select new BrowerTabla
                                      {
                                          campo1 = hclvariabmaestr.hcl_titulo_hcvr,
                                          campo2 = hclvariabmaestr.hcl_descri_hcvr,
                                          campo3 = hclvariabmaestr.hcl_nomvar_hcvr,
                                          campo4 = hcgv.hcl_desgru_hcgv,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    #region Datos
                    var lobConsulta = from hclvariabmaestr in db.Hclvariabmaestr
                                      join hclvariabgrupos in db.Hclvariabgrupos on hclvariabmaestr.hcl_secgru_hcgv equals hclvariabgrupos.hcl_secgru_hcgv into tmhclvariabgrupos

                                      from hcgv in tmhclvariabgrupos.DefaultIfEmpty()
                                      where hclvariabmaestr.sis_estreg_esrg == "1" &&
                                            (hclvariabmaestr.hcl_titulo_hcvr.Contains(tcrBuscar) ||
                                             hclvariabmaestr.hcl_descri_hcvr.Contains(tcrBuscar) ||
                                             hclvariabmaestr.hcl_nomvar_hcvr.Contains(tcrBuscar) ||
                                             hcgv.hcl_desgru_hcgv.Contains(tcrBuscar))
                                      orderby hcgv.hcl_secgru_hcgv, hclvariabmaestr.hcl_ordvis_hcvr
                                      select new BrowerTabla
                                      {
                                          campo1 = hclvariabmaestr.hcl_titulo_hcvr,
                                          campo2 = hclvariabmaestr.hcl_descri_hcvr,
                                          campo3 = hclvariabmaestr.hcl_nomvar_hcvr,
                                          campo4 = hcgv.hcl_desgru_hcgv,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Hclvariabmaestr()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Grupo", Width = 210, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Variable", Width = 210, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Titulo", Width = 370, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 400, DisplayMemberBinding = new Binding("campo2") });
        }
        // Seleccionar Registro
        public string fcrSelect_Hclvariabmaestr()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerTabla)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo3.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: HCLVARIABGRUPOS - Maestro grupos de variables publicas
        //----------------------------------------------------------------------
        #region HCLVARIABGRUPOS
        public static List<EFhclvariabgrupos> flsBuscar_Hclvariabgrupos(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("HCLVARIABGRUPOS", tcrBuscar, "like", "OR", "hcl_secgru_hcgv,hcl_desgru_hcgv", tcrFiltroTabla);
                ObjectQuery<EFhclvariabgrupos> lcrQuery = new ObjectQuery<EFhclvariabgrupos>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Hclvariabgrupos()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("hcl_secgru_hcgv") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificador", Width = 130, DisplayMemberBinding = new Binding("hcl_nomvar_hcgv") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion", Width = 350, DisplayMemberBinding = new Binding("hcl_desgru_hcgv") });
        }
        // Seleccionar Registro
        public string fcrSelect_Hclvariabgrupos()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhclvariabgrupos)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hcl_secgru_hcgv.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: HCLFORMATVISTMA - Grupo vista actividades medicas  en captura Historias clinic
        //----------------------------------------------------------------------
        #region HCLFORMATVISTMA
        public static List<EFhclformatvistma> flsBuscar_Hclformatvistma(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("HCLFORMATVISTMA", tcrBuscar, "like", "OR", "hcl_codreg_hcra,hcl_desgru_hcra", tcrFiltroTabla);
                ObjectQuery<EFhclformatvistma> lcrQuery = new ObjectQuery<EFhclformatvistma>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Hclformatvistma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo grupo", Width = 120, DisplayMemberBinding = new Binding("hcl_codreg_hcra") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Grupo actividad", Width = 400, DisplayMemberBinding = new Binding("hcl_desgru_hcra") });
        }
        // Seleccionar Registro
        public String fcrSelect_Hclformatvistma()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhclformatvistma)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hcl_codreg_hcra.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

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
    public class EST_Browser01 : ViewModelBase
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
                case "ESTPLANINFORMES":
                    fcvAddColGrid_Estplaninformes();
                    gobDataGrid.ItemsSource = flsBuscar_Estplaninformes(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ESTPLANGR2193MA":
                    fcvAddColGrid_Estplangr2193ma();
                    gobDataGrid.ItemsSource = flsBuscar_Estplangr2193ma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ESTPLANGR2193MD":
                    fcvAddColGrid_Estplangr2193md();
                    gobDataGrid.ItemsSource = flsBuscar_Estplangr2193md(gcrFiltroDatos, gcrFiltroTabla);
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
                case "ESTPLANINFORMES":
                    tobDataGrid.ItemsSource = flsBuscar_Estplaninformes(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ESTPLANGR2193MA":
                    tobDataGrid.ItemsSource = flsBuscar_Estplangr2193ma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ESTPLANGR2193MD":
                    tobDataGrid.ItemsSource = flsBuscar_Estplangr2193md(gcrFiltroDatos, gcrFiltroTabla);
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

                case "ESTPLANINFORMES":
                    lcrReturnCodigo = fcrSelect_Estplaninformes();
                    break;

                case "ESTPLANGR2193MA":
                    lcrReturnCodigo = fcrSelect_Estplangr2193ma();
                    break;

                case "ESTPLANGR2193MD":
                    lcrReturnCodigo = fcrSelect_Estplangr2193md();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ESTPLANINFORMES - Plantills para informes
        //----------------------------------------------------------------------
        #region ESTPLANINFORMES
        public static List<EFestplaninformes> flsBuscar_Estplaninformes(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("ESTPLANINFORMES", tcrBuscar, "like", "OR", "est_nroreg_esin,est_nominf_esin", tcrFiltroTabla);
                ObjectQuery<EFestplaninformes> lcrQuery = new ObjectQuery<EFestplaninformes>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Estplaninformes()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código unico registro", Width = 120, DisplayMemberBinding = new Binding("est_nroreg_esin") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre del informe", Width = 400, DisplayMemberBinding = new Binding("est_nominf_esin") });
        }
        // Seleccionar Registro
        public String fcrSelect_Estplaninformes()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFestplaninformes)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.est_nroreg_esin.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ESTPLANGR2193MA - Grupos para plantillas de informes
        //----------------------------------------------------------------------
        #region ESTPLANGR2193MA
        public static List<EFestplangr2193ma> flsBuscar_Estplangr2193ma(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("ESTPLANGR2193MA", tcrBuscar, "like", "OR", "est_nroreg_esgr,est_nomgru_esgr", tcrFiltroTabla);
                ObjectQuery<EFestplangr2193ma> lcrQuery = new ObjectQuery<EFestplangr2193ma>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Estplangr2193ma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código unico grupo", Width = 120, DisplayMemberBinding = new Binding("est_nroreg_esgr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre del  grupo", Width = 400, DisplayMemberBinding = new Binding("est_nomgru_esgr") });
        }
        // Seleccionar Registro
        public String fcrSelect_Estplangr2193ma()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFestplangr2193ma)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.est_nroreg_esgr.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ESTPLANGR2193MD - Servicios para grupos de registros
        //----------------------------------------------------------------------
        #region ESTPLANGR2193MD
        public static List<EFestplangr2193md> flsBuscar_Estplangr2193md(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("ESTPLANGR2193MD", tcrBuscar, "like", "OR", "est_nroreg_essr,", tcrFiltroTabla);
                ObjectQuery<EFestplangr2193md> lcrQuery = new ObjectQuery<EFestplangr2193md>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Estplangr2193md()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código unico registro", Width = 120, DisplayMemberBinding = new Binding("est_nroreg_essr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "", Width = 400, DisplayMemberBinding = new Binding("") });
        }
        // Seleccionar Registro
        public String fcrSelect_Estplangr2193md()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFestplangr2193md)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.est_nroreg_essr.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

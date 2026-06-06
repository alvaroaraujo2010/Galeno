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
    public class CON_Browser01 : ViewModelBase
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
                case "CONTERCEROS":
                    fcvAddColGrid_Conterceros();
                    gobDataGrid.ItemsSource = flsBuscar_Conterceros(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMCENPRODUCCIO":
                    fcvAddColGrid_Fcmcenproduccio();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmcenproduccio(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CONAREASFUNCION":
                    fcvAddColGrid_Conareasfuncion();
                    gobDataGrid.ItemsSource = flsBuscar_Conareasfuncion(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CONCENTRODCOSTO":
                    fcvAddColGrid_Concentrodcosto();
                    gobDataGrid.ItemsSource = flsBuscar_Concentrodcosto(gcrFiltroDatos, gcrFiltroTabla);
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
                case "CONTERCEROS":
                    tobDataGrid.ItemsSource = flsBuscar_Conterceros(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMCENPRODUCCIO":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmcenproduccio(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CONAREASFUNCION":
                    tobDataGrid.ItemsSource = flsBuscar_Conareasfuncion(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CONCENTRODCOSTO":
                    tobDataGrid.ItemsSource = flsBuscar_Concentrodcosto(gcrFiltroDatos, gcrFiltroTabla);
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
                case "CONTERCEROS":
                    lcrReturnCodigo = fcrSelect_Conterceros();
                    break;

                case "FCMCENPRODUCCIO":
                    lcrReturnCodigo = fcrSelect_Fcmcenproduccio();
                    break;

                case "CONAREASFUNCION":
                    lcrReturnCodigo = fcrSelect_Conareasfuncion();
                    break;

                case "CONCENTRODCOSTO":
                    lcrReturnCodigo = fcrSelect_Concentrodcosto();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CONTERCEROS - Tabla terceros para gestion contable
        //----------------------------------------------------------------------
        #region CONTERCEROS
        public static List<EFconterceros> flsBuscar_Conterceros(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CONTERCEROS", tcrBuscar, "like", "OR", "con_idesec_mter,con_razsoc_mter", tcrFiltroTabla);
                ObjectQuery<EFconterceros> lcrQuery = new ObjectQuery<EFconterceros>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Conterceros()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("con_idesec_mter") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre / Razon social", Width = 400, DisplayMemberBinding = new Binding("con_razsoc_mter") });
        }
        // Seleccionar Registro
        public string fcrSelect_Conterceros()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFconterceros)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.con_idesec_mter.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMCENPRODUCCIO - Centros de Producción Asistenciales
        //----------------------------------------------------------------------
        #region FCMCENPRODUCCIO
        public static List<EFfcmcenproduccio> flsBuscar_Fcmcenproduccio(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMCENPRODUCCIO", tcrBuscar, "like", "OR", "fcm_codcpr_cpro,fcm_descpr_cpro", tcrFiltroTabla);
                ObjectQuery<EFfcmcenproduccio> lcrQuery = new ObjectQuery<EFfcmcenproduccio>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmcenproduccio()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("fcm_codcpr_cpro") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Centro Producción", Width = 400, DisplayMemberBinding = new Binding("fcm_descpr_cpro") });
        }
        // Seleccionar Registro
        public string fcrSelect_Fcmcenproduccio()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmcenproduccio)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.fcm_codcpr_cpro.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CONAREASFUNCION - Areas funcionales
        //----------------------------------------------------------------------
        #region CONAREASFUNCION
        public static List<EFconareasfuncion> flsBuscar_Conareasfuncion(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CONAREASFUNCION", tcrBuscar, "like", "OR", "con_codafu_afun,con_desafu_afun", tcrFiltroTabla);
                ObjectQuery<EFconareasfuncion> lcrQuery = new ObjectQuery<EFconareasfuncion>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Conareasfuncion()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("con_codafu_afun") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Área funcional", Width = 400, DisplayMemberBinding = new Binding("con_desafu_afun") });
        }
        // Seleccionar Registro
        public string fcrSelect_Conareasfuncion()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFconareasfuncion)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.con_codafu_afun.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CONCENTRODCOSTO - Centros de costos contables
        //----------------------------------------------------------------------
        #region CONCENTRODCOSTO
        public static List<EFconcentrodcosto> flsBuscar_Concentrodcosto(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CONCENTRODCOSTO", tcrBuscar, "like", "OR", "con_codsco_ccos,con_dessco_ccos", tcrFiltroTabla);
                ObjectQuery<EFconcentrodcosto> lcrQuery = new ObjectQuery<EFconcentrodcosto>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Concentrodcosto()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("con_codsco_ccos") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Centro de Costo", Width = 400, DisplayMemberBinding = new Binding("con_dessco_ccos") });
        }
        // Seleccionar Registro
        public string fcrSelect_Concentrodcosto()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFconcentrodcosto)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.con_codsco_ccos.Trim();
            }
            return lcrReturn;
        }
        #endregion    
    }
}

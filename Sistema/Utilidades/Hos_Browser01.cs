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
    public class HOS_Browser01 : ViewModelBase
    {
        //-----------------------------------
        public object   gobRefRegistro;
        public ListView gobDataGrid;
        public GridView gobGridView;
        public string   gcrTabla = string.Empty;
        //-----------------------------------
        //-Variables Filtro activo de datos
        //-----------------------------------
        public string gcrFiltroAplicado = string.Empty;
        public string gcrFiltroDatos    = string.Empty;
        public string gcrFiltroTabla    = string.Empty;
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
                case "HOSTIPOCAMAS":
                    fcvAddColGrid_Hostipocamas();
                    gobDataGrid.ItemsSource = flsBuscar_Hostipocamas(gcrFiltroDatos, gcrFiltroTabla);
                    break;
                
                case "HOSCAMASAREAS":
                    fcvAddColGrid_Hoscamasareas();
                    gobDataGrid.ItemsSource = flsBuscar_Hoscamasareas(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HOSSECCIONAREAS":
                    fcvAddColGrid_Hosseccionareas();
                    gobDataGrid.ItemsSource = flsBuscar_Hosseccionareas(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HOSESTADOCAMA":
                    fcvAddColGrid_Hosestadocama();
                    gobDataGrid.ItemsSource = flsBuscar_Hosestadocama(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HOSHABITACIONES":
                    fcvAddColGrid_Hoshabitaciones();
                    gobDataGrid.ItemsSource = flsBuscar_Hoshabitaciones(gcrFiltroDatos, gcrFiltroTabla);
                    break;
            }
            
        }
        #endregion

        //----------------------------------------------------------------------
        //    Función: Buscar()
        //----------------------------------------------------------------------
        #region fcvBuscar: Buscar Registro

        public void fcvBuscar(ListView tobDataGrid, string tcrTabla, string tcrFiltroDatos,string tcrFiltroTabla)
        {
            gcrFiltroDatos = tcrFiltroDatos;
            gcrFiltroTabla = tcrFiltroTabla;
            switch (tcrTabla.ToUpper())
            {
                case "HOSTIPOCAMAS":
                    tobDataGrid.ItemsSource = flsBuscar_Hostipocamas(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HOSCAMASAREAS":
                    tobDataGrid.ItemsSource = flsBuscar_Hoscamasareas(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HOSESTADOCAMA":
                    tobDataGrid.ItemsSource = flsBuscar_Hosestadocama(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HOSSECCIONAREAS":
                    tobDataGrid.ItemsSource = flsBuscar_Hosseccionareas(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "HOSHABITACIONES":
                    tobDataGrid.ItemsSource = flsBuscar_Hoshabitaciones(gcrFiltroDatos, gcrFiltroTabla);
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
            string lcrReturnCodigo =string.Empty;
            switch (tcrTabla.ToUpper())
            {
                case "HOSTIPOCAMAS":
                    lcrReturnCodigo = fcrSelect_Hostipocamas();
                    break;    
                
                case "HOSCAMASAREAS":
                    lcrReturnCodigo = fcrSelect_Hoscamasareas();
                    break;

                case "HOSESTADOCAMA":
                    lcrReturnCodigo = fcrSelect_Hosestadocama();
                    break;
                
                case "HOSSECCIONAREAS":
                    lcrReturnCodigo = fcrSelect_Hosseccionareas();
                    break;

                case "HOSHABITACIONES":
                    lcrReturnCodigo = fcrSelect_Hoshabitaciones();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion

        //----------------------------------------------------------------------
        //    TABLA:  HOSESTADOCAMA
        //----------------------------------------------------------------------
        #region HOSESTADOCAMA

        public static List<EFhosestadocama> flsBuscar_Hosestadocama(string tcrBuscar,string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrconsulta = Funciones.fcrGenConsultaSqlBrowser("hosestadocama", tcrBuscar, "like", "OR", "hos_estcam_ecam,hos_desest_ecam", tcrFiltroTabla);
                ObjectQuery<EFhosestadocama> lcrQuery = new ObjectQuery<EFhosestadocama>(lcrconsulta, db);
                return lcrQuery.ToList(); 
            }
        }

        // Crear Columans del DataGrid
        public void fcvAddColGrid_Hosestadocama()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("hos_estcam_ecam") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 220, DisplayMemberBinding = new Binding("hos_desest_ecam") });
        }
        // Seleccionar Registro
        public string fcrSelect_Hosestadocama()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhosestadocama)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hos_estcam_ecam.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA:  HOSCAMASAREAS
        //----------------------------------------------------------------------
        #region HOSCAMASAREAS

        public static List<EFhoscamasareas> flsBuscar_Hoscamasareas(string tcrBuscar,string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrconsulta = Funciones.fcrGenConsultaSqlBrowser("hoscamasareas", tcrBuscar, "like", "OR", "hos_codcam_caho,hos_descam_caho", tcrFiltroTabla);
                ObjectQuery<EFhoscamasareas> lcrQuery = new ObjectQuery<EFhoscamasareas>(lcrconsulta, db);
                return lcrQuery.ToList(); 
            }
        }

       // Crear Columans del DataGrid
        public void fcvAddColGrid_Hoscamasareas()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("hos_codcam_caho") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 400, DisplayMemberBinding = new Binding("hos_descam_caho") });
        }
        // Seleccionar Registro
        public string fcrSelect_Hoscamasareas()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhoscamasareas)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hos_codcam_caho;
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA:  HOSSECCIONAREAS
        //----------------------------------------------------------------------
        #region HOSSECCIONAREAS

        public static List<EFhosseccionareas> flsBuscar_Hosseccionareas(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrconsulta = Funciones.fcrGenConsultaSqlBrowser("hosseccionareas", tcrBuscar, "like", "OR", "hos_codsec_hsec,hos_dessec_hsec", tcrFiltroTabla);
                ObjectQuery<EFhosseccionareas> lcrQuery = new ObjectQuery<EFhosseccionareas>(lcrconsulta, db);
                return lcrQuery.ToList(); 
               /*
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lArDatos = (from reg in db.Hosseccionareas select reg).ToList();
                    return lArDatos;
                }
                else
                {
                    var lArDatos = (from reg in db.Hosseccionareas where reg.hos_codsec_hsec.Contains(tcrBuscar) || reg.hos_dessec_hsec.Contains(tcrBuscar) select reg).ToList();
                    return lArDatos;
                }
                */
            }
        }

        // Crear Columnas del DataGrid
        public void fcvAddColGrid_Hosseccionareas()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("hos_codsec_hsec") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 220, DisplayMemberBinding = new Binding("hos_dessec_hsec") });
        }
        // Seleccionar Registro
        public string fcrSelect_Hosseccionareas()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhosseccionareas)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hos_codsec_hsec;
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA:  HOSTIPOCAMAS
        //----------------------------------------------------------------------
        #region HOSTIPOCAMAS

        public static List<EFhostipocamas> flsBuscar_Hostipocamas(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrconsulta = Funciones.fcrGenConsultaSqlBrowser("Hostipocamas", tcrBuscar, "like", "OR", "hos_tipcam_tcam,hos_destip_tcam", tcrFiltroTabla);
                ObjectQuery<EFhostipocamas> lcrQuery = new ObjectQuery<EFhostipocamas>(lcrconsulta, db);
                return lcrQuery.ToList(); 
                /*
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lArDatos = (from reg in db.Hostipocamas select reg).ToList();
                    return lArDatos;
                }
                else
                {
                    var lArDatos = (from reg in db.Hostipocamas where reg.hos_tipcam_tcam.Contains(tcrBuscar) || reg.hos_destip_tcam.Contains(tcrBuscar) select reg).ToList();
                    return lArDatos;
                }
                */
            }
        }

        // Crear Columnas del DataGrid
        public void fcvAddColGrid_Hostipocamas()
        {
            gobGridView.Columns.Add( new GridViewColumn{ Header = "Código",Width = 120,DisplayMemberBinding = new Binding("hos_tipcam_tcam")});
            gobGridView.Columns.Add( new GridViewColumn { Header = "Descripción", Width = 220, DisplayMemberBinding = new Binding("hos_destip_tcam") }); 
        }

        // Seleccionar Registro
        public string fcrSelect_Hostipocamas()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhostipocamas)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hos_tipcam_tcam;
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA:  HOSHABITACIONES
        //----------------------------------------------------------------------
        #region HOSHABITACIONES

        public static List<EFhoshabitaciones> flsBuscar_Hoshabitaciones(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrconsulta = Funciones.fcrGenConsultaSqlBrowser("Hoshabitaciones", tcrBuscar, "like", "OR", "hos_nrohab_habi,hos_deshab_habi", tcrFiltroTabla);
                ObjectQuery<EFhoshabitaciones> lcrQuery = new ObjectQuery<EFhoshabitaciones>(lcrconsulta, db);
                return lcrQuery.ToList(); 
            }
        }

        // Crear Columnas del DataGrid
        public void fcvAddColGrid_Hoshabitaciones()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("hos_nrohab_habi") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 220, DisplayMemberBinding = new Binding("hos_deshab_habi") });
        }

        // Seleccionar Registro
        public string fcrSelect_Hoshabitaciones()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhoshabitaciones)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hos_nrohab_habi;
            }
            return lcrReturn;
        }
        #endregion

    }
}

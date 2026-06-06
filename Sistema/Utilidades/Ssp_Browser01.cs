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
    public class SSP_Browser01 : ViewModelBase
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

                case "SPOCUPACIONCIUO":
                    fcvAddColGrid_Spocupacionciuo();
                    gobDataGrid.ItemsSource = flsBuscar_Spocupacionciuo(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPTABLAPERIODOS":
                    fcvAddColGrid_Sptablaperiodos();
                    gobDataGrid.ItemsSource = flsBuscar_Sptablaperiodos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPTABCAMPOS4505":
                    fcvAddColGrid_Sptabcampos4505();
                    gobDataGrid.ItemsSource = flsBuscar_Sptabcampos4505(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPTABLMSRES4505":
                    fcvAddColGrid_Sptablmsres4505();
                    gobDataGrid.ItemsSource = flsBuscar_Sptablmsres4505(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPTABLNSRES4505":
                    fcvAddColGrid_Sptablnsres4505();
                    gobDataGrid.ItemsSource = flsBuscar_Sptablnsres4505(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPVALOREDEFMAES":
                    fcvAddColGrid_Spvaloredefmaes();
                    gobDataGrid.ItemsSource = flsBuscar_Spvaloredefmaes(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPVALOREDEFAULT":
                    fcvAddColGrid_Spvaloredefault();
                    gobDataGrid.ItemsSource = flsBuscar_Spvaloredefault(gcrFiltroDatos, gcrFiltroTabla);
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

                case "SPOCUPACIONCIUO":
                    tobDataGrid.ItemsSource = flsBuscar_Spocupacionciuo(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPTABLAPERIODOS":
                    tobDataGrid.ItemsSource = flsBuscar_Sptablaperiodos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPTABCAMPOS4505":
                    tobDataGrid.ItemsSource = flsBuscar_Sptabcampos4505(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPTABLMSRES4505":
                    tobDataGrid.ItemsSource = flsBuscar_Sptablmsres4505(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPTABLNSRES4505":
                    tobDataGrid.ItemsSource = flsBuscar_Sptablnsres4505(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPVALOREDEFMAES":
                    tobDataGrid.ItemsSource = flsBuscar_Spvaloredefmaes(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SPVALOREDEFAULT":
                    tobDataGrid.ItemsSource = flsBuscar_Spvaloredefault(gcrFiltroDatos, gcrFiltroTabla);
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

                case "SPOCUPACIONCIUO":
                    lcrReturnCodigo = fcrSelect_Spocupacionciuo();
                    break;

                case "SPTABLAPERIODOS":
                    lcrReturnCodigo = fcrSelect_Sptablaperiodos();
                    break;

                case "SPTABCAMPOS4505":
                    lcrReturnCodigo = fcrSelect_Sptabcampos4505();
                    break;

                case "SPTABLMSRES4505":
                    lcrReturnCodigo = fcrSelect_Sptablmsres4505();
                    break;

                case "SPTABLNSRES4505":
                    lcrReturnCodigo = fcrSelect_Sptablnsres4505();
                    break;

                case "SPVALOREDEFMAES":
                    lcrReturnCodigo = fcrSelect_Spvaloredefmaes();
                    break;

                case "SPVALOREDEFAULT":
                    lcrReturnCodigo = fcrSelect_Spvaloredefault();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SPOCUPACIONCIUO - Tabla Clasificación Internacional Uniforme de Ocupaciones (C
        //----------------------------------------------------------------------
        #region SPOCUPACIONCIUO
        public static List<EFspocupacionciuo> flsBuscar_Spocupacionciuo(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SPOCUPACIONCIUO", tcrBuscar, "like", "OR", "ssp_codocu_ciuo,ssp_desocu_ciuo", tcrFiltroTabla);
                ObjectQuery<EFspocupacionciuo> lcrQuery = new ObjectQuery<EFspocupacionciuo>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Spocupacionciuo()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("ssp_codocu_ciuo") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Ocupación", Width = 400, DisplayMemberBinding = new Binding("ssp_desocu_ciuo") });
        }
        // Seleccionar Registro
        public string fcrSelect_Spocupacionciuo()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFspocupacionciuo)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.ssp_codocu_ciuo.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SPTABLAPERIODOS - Tabla periodos SISPRO
        //----------------------------------------------------------------------
        #region SPTABLAPERIODOS
        public static List<EFsptablaperiodos> flsBuscar_Sptablaperiodos(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SPTABLAPERIODOS", tcrBuscar, "like", "OR", "ssp_codper_peri,ssp_desper_peri", tcrFiltroTabla);
                ObjectQuery<EFsptablaperiodos> lcrQuery = new ObjectQuery<EFsptablaperiodos>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sptablaperiodos()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código de periodo", Width = 120, DisplayMemberBinding = new Binding("ssp_codper_peri") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción periodo", Width = 400, DisplayMemberBinding = new Binding("ssp_desper_peri") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sptablaperiodos()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsptablaperiodos)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.ssp_codper_peri.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SPTABCAMPOS4505 - Campos de la Resolución 4505
        //----------------------------------------------------------------------
        #region SPTABCAMPOS4505
        public static List<EFsptabcampos4505> flsBuscar_Sptabcampos4505(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SPTABCAMPOS4505", tcrBuscar, "like", "OR", "ssp_codcam_resc,ssp_nomcam_resc", tcrFiltroTabla);
                ObjectQuery<EFsptabcampos4505> lcrQuery = new ObjectQuery<EFsptabcampos4505>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sptabcampos4505()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código Campo", Width = 120, DisplayMemberBinding = new Binding("ssp_codcam_resc") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Titulo o Etiqueta", Width = 450, DisplayMemberBinding = new Binding("ssp_nomcam_resc") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sptabcampos4505()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsptabcampos4505)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.ssp_codcam_resc.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SPTABLMSRES4505 - Tabla maestra de digitacion RES4505
        //----------------------------------------------------------------------
        #region SPTABLMSRES4505
        public static List<EFsptablmsres4505> flsBuscar_Sptablmsres4505(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SPTABLMSRES4505", tcrBuscar, "like", "OR", "ssp_cam001_ms45,", tcrFiltroTabla);
                ObjectQuery<EFsptablmsres4505> lcrQuery = new ObjectQuery<EFsptablmsres4505>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sptablmsres4505()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "1.Consecutivo de Registro", Width = 120, DisplayMemberBinding = new Binding("ssp_cam001_ms45") });
            //gobGridView.Columns.Add(new GridViewColumn { Header = "", Width = 400, DisplayMemberBinding = new Binding("") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sptablmsres4505()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsptablmsres4505)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.ssp_cam001_ms45.Trim();
            }
            return lcrReturn;
        }
        #endregion    
        //----------------------------------------------------------------------
        //    TABLA: SPTABLNSRES4505 - Novedades mensuales RES4505
        //----------------------------------------------------------------------
        #region SPTABLNSRES4505
        public static List<EFsptablnsres4505> flsBuscar_Sptablnsres4505(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SPTABLNSRES4505", tcrBuscar, "like", "OR", "ssp_idesec_ns45,", tcrFiltroTabla);
                ObjectQuery<EFsptablnsres4505> lcrQuery = new ObjectQuery<EFsptablnsres4505>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sptablnsres4505()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id único del registro", Width = 120, DisplayMemberBinding = new Binding("ssp_idesec_ns45") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "", Width = 400, DisplayMemberBinding = new Binding("") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sptablnsres4505()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsptablnsres4505)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.ssp_idesec_ns45.Trim();
            }
            return lcrReturn;
        }
        #endregion          
        //----------------------------------------------------------------------
        //    TABLA: SPVALOREDEFMAES - Maestro agrupa valores por defecto registros de pacientes 45
        //----------------------------------------------------------------------
        #region SPVALOREDEFMAES
        public static List<EFspvaloredefmaes> flsBuscar_Spvaloredefmaes(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SPVALOREDEFMAES", tcrBuscar, "like", "OR", "ssp_secreg_spdf,ssp_despro_spdf", tcrFiltroTabla);
                ObjectQuery<EFspvaloredefmaes> lcrQuery = new ObjectQuery<EFspvaloredefmaes>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Spvaloredefmaes()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código registro", Width = 120, DisplayMemberBinding = new Binding("ssp_secreg_spdf") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion", Width = 400, DisplayMemberBinding = new Binding("ssp_despro_spdf") });
        }
        // Seleccionar Registro
        public String fcrSelect_Spvaloredefmaes()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFspvaloredefmaes)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.ssp_secreg_spdf.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SPVALOREDEFAULT - Valores por defecto Novedades
        //----------------------------------------------------------------------
        #region SPVALOREDEFAULT
        public static List<EFspvaloredefault> flsBuscar_Spvaloredefault(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SPVALOREDEFAULT", tcrBuscar, "like", "OR", "ssp_idesec_spvd,ssp_desval_spvd", tcrFiltroTabla);
                ObjectQuery<EFspvaloredefault> lcrQuery = new ObjectQuery<EFspvaloredefault>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Spvaloredefault()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id único del registro", Width = 120, DisplayMemberBinding = new Binding("ssp_idesec_spvd") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción registro", Width = 400, DisplayMemberBinding = new Binding("ssp_desval_spvd") });
        }
        // Seleccionar Registro
        public String fcrSelect_Spvaloredefault()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFspvaloredefault)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.ssp_idesec_spvd.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}
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
    public class SYS_Browser01 : ViewModelBase
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
                case "SYSUSUARIOS":
                    fcvAddColGrid_Sysusuarios();
                    gobDataGrid.ItemsSource = flsBuscar_Sysusuarios(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SYSGENERADORCOD":
                    fcvAddColGrid_Sysgeneradorcod();
                    gobDataGrid.ItemsSource = flsBuscar_Sysgeneradorcod(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SYSMODULOSISTEM":
                    fcvAddColGrid_Sysmodulosistem();
                    gobDataGrid.ItemsSource = flsBuscar_Sysmodulosistem(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SYSPERFIUSUARIO":
                    fcvAddColGrid_Sysperfiusuario();
                    gobDataGrid.ItemsSource = flsBuscar_Sysperfiusuario(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SYSADMSTIPOMENS":
                    fcvAddColGrid_Sysadmstipomens();
                    gobDataGrid.ItemsSource = flsBuscar_Sysadmstipomens(gcrFiltroDatos, gcrFiltroTabla);
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
                case "SYSUSUARIOS":
                    tobDataGrid.ItemsSource = flsBuscar_Sysusuarios(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SYSGENERADORCOD":
                    tobDataGrid.ItemsSource = flsBuscar_Sysgeneradorcod(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SYSMODULOSISTEM":
                    tobDataGrid.ItemsSource = flsBuscar_Sysmodulosistem(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SYSPERFIUSUARIO":
                    tobDataGrid.ItemsSource = flsBuscar_Sysperfiusuario(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SYSADMSTIPOMENS":
                    tobDataGrid.ItemsSource = flsBuscar_Sysadmstipomens(gcrFiltroDatos, gcrFiltroTabla);
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
                case "SYSUSUARIOS":
                    lcrReturnCodigo = fcrSelect_Sysusuarios();
                    break;

                case "SYSGENERADORCOD":
                    lcrReturnCodigo = fcrSelect_Sysgeneradorcod();
                    break;

                case "SYSMODULOSISTEM":
                    lcrReturnCodigo = fcrSelect_Sysmodulosistem();
                    break;

                case "SYSPERFIUSUARIO":
                    lcrReturnCodigo = fcrSelect_Sysperfiusuario();
                    break;

                case "SYSADMSTIPOMENS":
                    lcrReturnCodigo = fcrSelect_Sysadmstipomens();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SYSUSUARIOS - Maestro de Usuarios del Sistema
        //----------------------------------------------------------------------
        #region SYSUSUARIOS
        public static List<EFsysusuarios> flsBuscar_Sysusuarios(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SYSUSUARIOS", tcrBuscar, "like", "OR", "sys_codusu_usux,sys_ideusu_usux,sys_nomusu_usux", tcrFiltroTabla);
                ObjectQuery<EFsysusuarios> lcrQuery = new ObjectQuery<EFsysusuarios>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sysusuarios()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo unico", Width = 80, DisplayMemberBinding = new Binding("sys_codusu_usux") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id Usuario", Width = 120, DisplayMemberBinding = new Binding("sys_ideusu_usux") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Usuario", Width = 220, DisplayMemberBinding = new Binding("sys_nomusu_usux") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sysusuarios()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsysusuarios)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sys_codusu_usux.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SYSGENERADORCOD - Tabla Generador de  secuenciales
        //----------------------------------------------------------------------
        #region SYSGENERADORCOD
        public static List<EFsysgeneradorcod> flsBuscar_Sysgeneradorcod(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SYSGENERADORCOD", tcrBuscar, "like", "OR", "sys_codsec_gcod,sys_dessec_gcod", tcrFiltroTabla);
                ObjectQuery<EFsysgeneradorcod> lcrQuery = new ObjectQuery<EFsysgeneradorcod>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sysgeneradorcod()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "llave  Registro", Width = 120, DisplayMemberBinding = new Binding("sys_codsec_gcod") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Secuencial", Width = 400, DisplayMemberBinding = new Binding("sys_dessec_gcod") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sysgeneradorcod()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsysgeneradorcod)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sys_codsec_gcod.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SYSMODULOSISTEM - Módulos del Sistema
        //----------------------------------------------------------------------
        #region SYSMODULOSISTEM
        public static List<EFsysmodulosistem> flsBuscar_Sysmodulosistem(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SYSMODULOSISTEM", tcrBuscar, "like", "OR", "sys_codmod_modu,sys_nommod_modu", tcrFiltroTabla);
                ObjectQuery<EFsysmodulosistem> lcrQuery = new ObjectQuery<EFsysmodulosistem>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sysmodulosistem()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código Módulo", Width = 120, DisplayMemberBinding = new Binding("sys_codmod_modu") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Módulo", Width = 400, DisplayMemberBinding = new Binding("sys_nommod_modu") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sysmodulosistem()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsysmodulosistem)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sys_codmod_modu.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SYSPERFIUSUARIO - Maestro perfiles de usuarios
        //----------------------------------------------------------------------
        #region SYSPERFIUSUARIO
        public static List<EFsysperfiusuario> flsBuscar_Sysperfiusuario(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SYSPERFIUSUARIO", tcrBuscar, "like", "OR", "sys_codper_perf,sys_desper_perf", tcrFiltroTabla);
                ObjectQuery<EFsysperfiusuario> lcrQuery = new ObjectQuery<EFsysperfiusuario>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sysperfiusuario()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código del Perfil", Width = 120, DisplayMemberBinding = new Binding("sys_codper_perf") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre del Perfil", Width = 400, DisplayMemberBinding = new Binding("sys_desper_perf") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sysperfiusuario()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsysperfiusuario)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sys_codper_perf.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SYSADMSTIPOMENS - Tipo notificacion servicio de mensajes
        //----------------------------------------------------------------------
        #region SYSADMSTIPOMENS
        public static List<EFsysadmstipomens> flsBuscar_Sysadmstipomens(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SYSADMSTIPOMENS", tcrBuscar, "like", "OR", "sys_codtip_sytm,sys_desmsj_sytm", tcrFiltroTabla);
                ObjectQuery<EFsysadmstipomens> lcrQuery = new ObjectQuery<EFsysadmstipomens>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sysadmstipomens()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo tipo de mensajes", Width = 120, DisplayMemberBinding = new Binding("sys_codtip_sytm") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion tipo", Width = 400, DisplayMemberBinding = new Binding("sys_desmsj_sytm") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sysadmstipomens()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsysadmstipomens)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sys_codtip_sytm.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

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
    public class CIT_Browser01 : ViewModelBase
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
                case "CITMAESTROTURNO":
                    fcvAddColGrid_Citmaestroturno();
                    gobDataGrid.ItemsSource = flsBuscar_Citmaestroturno(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CITMAESASIGCITA":
                    fcvAddColGrid_Citmaesasigcita();
                    gobDataGrid.ItemsSource = flsBuscar_Citmaesasigcita(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CITSERVICIOPROG":
                    fcvAddColGrid_Citservicioprog();
                    gobDataGrid.ItemsSource = flsBuscar_Citservicioprog(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CITCAUSACANCITA":
                    fcvAddColGrid_Citcausacancita();
                    gobDataGrid.ItemsSource = flsBuscar_Citcausacancita(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CITESTADOASCITA":
                    fcvAddColGrid_Citestadoascita();
                    gobDataGrid.ItemsSource = flsBuscar_Citestadoascita(gcrFiltroDatos, gcrFiltroTabla);
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
                case "CITMAESTROTURNO":
                    tobDataGrid.ItemsSource = flsBuscar_Citmaestroturno(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CITMAESASIGCITA":
                    tobDataGrid.ItemsSource = flsBuscar_Citmaesasigcita(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CITSERVICIOPROG":
                    tobDataGrid.ItemsSource = flsBuscar_Citservicioprog(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CITCAUSACANCITA":
                    tobDataGrid.ItemsSource = flsBuscar_Citcausacancita(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CITESTADOASCITA":
                    tobDataGrid.ItemsSource = flsBuscar_Citestadoascita(gcrFiltroDatos, gcrFiltroTabla);
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
                case "CITMAESTROTURNO":
                    lcrReturnCodigo = fcrSelect_Citmaestroturno();
                    break;

                case "CITMAESASIGCITA":
                    lcrReturnCodigo = fcrSelect_Citmaesasigcita();
                    break;

                case "CITSERVICIOPROG":
                    lcrReturnCodigo = fcrSelect_Citservicioprog();
                    break;

                case "CITCAUSACANCITA":
                    lcrReturnCodigo = fcrSelect_Citcausacancita();
                    break;

                case "CITESTADOASCITA":
                    lcrReturnCodigo = fcrSelect_Citestadoascita();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CITMAESTROTURNO - Maestro de turnos por profesional
        //----------------------------------------------------------------------
        #region CITMAESTROTURNO
        public static List<EFcitmaestroturno> flsBuscar_Citmaestroturno(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CITMAESTROTURNO", tcrBuscar, "like", "OR", "cit_codtur_turn,cit_destur_turn", tcrFiltroTabla);
                ObjectQuery<EFcitmaestroturno> lcrQuery = new ObjectQuery<EFcitmaestroturno>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Citmaestroturno()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Registro turno", Width = 120, DisplayMemberBinding = new Binding("cit_codtur_turn") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion", Width = 400, DisplayMemberBinding = new Binding("cit_destur_turn") });
        }
        // Seleccionar Registro
        public string fcrSelect_Citmaestroturno()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFcitmaestroturno)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.cit_codtur_turn.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CITMAESASIGCITA - Asignacion de citas a Pacientes
        //----------------------------------------------------------------------
        #region CITMAESASIGCITA
        public static List<EFcitmaesasigcita> flsBuscar_Citmaesasigcita(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CITMAESASIGCITA", tcrBuscar, "like", "OR", "cit_codasi_mcit,sia_nroide_usua", tcrFiltroTabla);
                ObjectQuery<EFcitmaesasigcita> lcrQuery = new ObjectQuery<EFcitmaesasigcita>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Citmaesasigcita()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo registro", Width = 120, DisplayMemberBinding = new Binding("cit_codasi_mcit") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id Usuario     ", Width = 120, DisplayMemberBinding = new Binding("sia_nroide_usua") });
        }
        // Seleccionar Registro
        public string fcrSelect_Citmaesasigcita()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFcitmaesasigcita)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.cit_codasi_mcit.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CITSERVICIOPROG - Servicios para programacion o citas medicas
        //----------------------------------------------------------------------
        #region CITSERVICIOPROG
        public static List<EFcitservicioprog> flsBuscar_Citservicioprog(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CITSERVICIOPROG", tcrBuscar, "like", "OR", "cit_codspr_spro,cit_desspr_spro", "Citservicioprog.Sis_estreg_esrg ='1'");
                ObjectQuery<EFcitservicioprog> lcrQuery = new ObjectQuery<EFcitservicioprog>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Citservicioprog()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo programa", Width = 120, DisplayMemberBinding = new Binding("cit_codspr_spro") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre programa", Width = 400, DisplayMemberBinding = new Binding("cit_desspr_spro") });
        }
        // Seleccionar Registro
        public string fcrSelect_Citservicioprog()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFcitservicioprog)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.cit_codspr_spro.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CITCAUSACANCITA - Causa cancelacion cita medica
        //----------------------------------------------------------------------
        #region CITCAUSACANCITA
        public static List<EFcitcausacancita> flsBuscar_Citcausacancita(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CITCAUSACANCITA", tcrBuscar, "like", "OR", "cit_caucan_ccan,cit_descan_ccan", tcrFiltroTabla);
                ObjectQuery<EFcitcausacancita> lcrQuery = new ObjectQuery<EFcitcausacancita>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Citcausacancita()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("cit_caucan_ccan") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Cancelacion cita", Width = 400, DisplayMemberBinding = new Binding("cit_descan_ccan") });
        }
        // Seleccionar Registro
        public string fcrSelect_Citcausacancita()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFcitcausacancita)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.cit_caucan_ccan.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CITESTADOASCITA - Estado asignacion cita medica
        //----------------------------------------------------------------------
        #region CITESTADOASCITA
        public static List<EFcitestadoascita> flsBuscar_Citestadoascita(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CITESTADOASCITA", tcrBuscar, "like", "OR", "cit_estcit_easi,cit_descit_easi", tcrFiltroTabla);
                ObjectQuery<EFcitestadoascita> lcrQuery = new ObjectQuery<EFcitestadoascita>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Citestadoascita()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("cit_estcit_easi") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado cita", Width = 400, DisplayMemberBinding = new Binding("cit_descit_easi") });
        }
        // Seleccionar Registro
        public string fcrSelect_Citestadoascita()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFcitestadoascita)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.cit_estcit_easi.Trim();
            }
            return lcrReturn;
        }
        #endregion


    }
}

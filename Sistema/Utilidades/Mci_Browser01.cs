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
    public class MCI_Browser01 : ViewModelBase
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
                case "MCIPLANTILLMECI":
                    fcvAddColGrid_Mciplantillmeci();
                    gobDataGrid.ItemsSource = flsBuscar_Mciplantillmeci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "MCIMODULOEVMECI":
                    fcvAddColGrid_Mcimoduloevmeci();
                    gobDataGrid.ItemsSource = flsBuscar_Mcimoduloevmeci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "MCICOMPONENMECI":
                    fcvAddColGrid_Mcicomponenmeci();
                    gobDataGrid.ItemsSource = flsBuscar_Mcicomponenmeci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "MCIPARAMETRMECI":
                    fcvAddColGrid_Mciparametrmeci();
                    gobDataGrid.ItemsSource = flsBuscar_Mciparametrmeci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "MCIGRUPOPRGMECI":
                    fcvAddColGrid_Mcigrupoprgmeci();
                    gobDataGrid.ItemsSource = flsBuscar_Mcigrupoprgmeci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "MCIPREGUNTAMECI":
                    fcvAddColGrid_Mcipreguntameci();
                    gobDataGrid.ItemsSource = flsBuscar_Mcipreguntameci(gcrFiltroDatos, gcrFiltroTabla);
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
                case "MCIPLANTILLMECI":
                    tobDataGrid.ItemsSource = flsBuscar_Mciplantillmeci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "MCIMODULOEVMECI":
                    tobDataGrid.ItemsSource = flsBuscar_Mcimoduloevmeci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "MCICOMPONENMECI":
                    tobDataGrid.ItemsSource = flsBuscar_Mcicomponenmeci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "MCIPARAMETRMECI":
                    tobDataGrid.ItemsSource = flsBuscar_Mciparametrmeci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "MCIGRUPOPRGMECI":
                    tobDataGrid.ItemsSource = flsBuscar_Mcigrupoprgmeci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "MCIPREGUNTAMECI":
                    tobDataGrid.ItemsSource = flsBuscar_Mcipreguntameci(gcrFiltroDatos, gcrFiltroTabla);
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
                case "MCIPLANTILLMECI":
                    lcrReturnCodigo = fcrSelect_Mciplantillmeci();
                    break;

                case "MCIMODULOEVMECI":
                    lcrReturnCodigo = fcrSelect_Mcimoduloevmeci();
                    break;

                case "MCICOMPONENMECI":
                    lcrReturnCodigo = fcrSelect_Mcicomponenmeci();
                    break;

                case "MCIPARAMETRMECI":
                    lcrReturnCodigo = fcrSelect_Mciparametrmeci();
                    break;

                case "MCIGRUPOPRGMECI":
                    lcrReturnCodigo = fcrSelect_Mcigrupoprgmeci();
                    break;

                case "MCIPREGUNTAMECI":
                    lcrReturnCodigo = fcrSelect_Mcipreguntameci();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: MCIPLANTILLMECI - PLANTILLAS DE EVALUACIÓN
        //----------------------------------------------------------------------
        #region MCIPLANTILLMECI
        public static List<EFmciplantillmeci> flsBuscar_Mciplantillmeci(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("MCIPLANTILLMECI", tcrBuscar, "like", "OR", "mci_idesec_mcpl,mci_despla_mcpl", tcrFiltroTabla);
                ObjectQuery<EFmciplantillmeci> lcrQuery = new ObjectQuery<EFmciplantillmeci>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Mciplantillmeci()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código",    Width = 100, DisplayMemberBinding = new Binding("mci_idesec_mcpl") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Plantilla", Width = 480, DisplayMemberBinding = new Binding("mci_despla_mcpl") });
        }
        // Seleccionar Registro
        public string fcrSelect_Mciplantillmeci()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFmciplantillmeci)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.mci_idesec_mcpl.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: MCIMODULOEVMECI - MÓDULOS PLANTILLA EVALUACIÓN MECI
        //----------------------------------------------------------------------
        #region MCIMODULOEVMECI
        public static List<EFmcimoduloevmeci> flsBuscar_Mcimoduloevmeci(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("MCIMODULOEVMECI", tcrBuscar, "like", "OR", "mci_idesec_mcmo,mci_etqmod_mcmo,mci_desmod_mcmo", tcrFiltroTabla);
                ObjectQuery<EFmcimoduloevmeci> lcrQuery = new ObjectQuery<EFmcimoduloevmeci>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Mcimoduloevmeci()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Módulo",      Width = 100, DisplayMemberBinding = new Binding("mci_idesec_mcmo") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Etiqueta",    Width = 90,  DisplayMemberBinding = new Binding("mci_etqmod_mcmo") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 480, DisplayMemberBinding = new Binding("mci_desmod_mcmo") });
        }
        // Seleccionar Registro
        public string fcrSelect_Mcimoduloevmeci()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFmcimoduloevmeci)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.mci_idesec_mcmo.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: MCICOMPONENMECI - Componentes de los Módulos Meci
        //----------------------------------------------------------------------
        #region MCICOMPONENMECI
        public static List<EFmcicomponenmeci> flsBuscar_Mcicomponenmeci(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("MCICOMPONENMECI", tcrBuscar, "like", "OR", "mci_idesec_mcco,mci_etqcom_mcco,mci_descom_mcco", tcrFiltroTabla);
                ObjectQuery<EFmcicomponenmeci> lcrQuery = new ObjectQuery<EFmcicomponenmeci>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Mcicomponenmeci()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Componente",  Width = 100, DisplayMemberBinding = new Binding("mci_idesec_mcco") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Etiqueta",    Width = 90,  DisplayMemberBinding = new Binding("mci_etqcom_mcco") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 480, DisplayMemberBinding = new Binding("mci_descom_mcco") });
        }
        // Seleccionar Registro
        public string fcrSelect_Mcicomponenmeci()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFmcicomponenmeci)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.mci_idesec_mcco.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: MCIPARAMETRMECI - Parametros en Componentes de Módulos Meci
        //----------------------------------------------------------------------
        #region MCIPARAMETRMECI
        public static List<EFmciparametrmeci> flsBuscar_Mciparametrmeci(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("MCIPARAMETRMECI", tcrBuscar, "like", "OR", "mci_idesec_mcpa,mci_etqpar_mcpa,mci_despar_mcpa", tcrFiltroTabla);
                ObjectQuery<EFmciparametrmeci> lcrQuery = new ObjectQuery<EFmciparametrmeci>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Mciparametrmeci()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Parámetro",   Width = 100, DisplayMemberBinding = new Binding("mci_idesec_mcpa") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Etiqueta",    Width = 80,  DisplayMemberBinding = new Binding("mci_etqpar_mcpa") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 480, DisplayMemberBinding = new Binding("mci_despar_mcpa") });
        }
        // Seleccionar Registro
        public string fcrSelect_Mciparametrmeci()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFmciparametrmeci)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.mci_idesec_mcpa.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: MCIGRUPOPRGMECI - Grupos en Parametros en Componentes de Módulos Meci
        //----------------------------------------------------------------------
        #region MCIGRUPOPRGMECI
        public static List<EFmcigrupoprgmeci> flsBuscar_Mcigrupoprgmeci(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("MCIGRUPOPRGMECI", tcrBuscar, "like", "OR", "mci_idesec_mcgr,mci_etqgrp_mcgr,mci_desgrp_mcgr", tcrFiltroTabla);
                ObjectQuery<EFmcigrupoprgmeci> lcrQuery = new ObjectQuery<EFmcigrupoprgmeci>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Mcigrupoprgmeci()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Grupo",       Width = 100, DisplayMemberBinding = new Binding("mci_idesec_mcgr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Etiqueta",    Width = 80,  DisplayMemberBinding = new Binding("mci_etqgrp_mcgr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 480, DisplayMemberBinding = new Binding("mci_desgrp_mcgr") });
        }
        // Seleccionar Registro
        public string fcrSelect_Mcigrupoprgmeci()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFmcigrupoprgmeci)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.mci_idesec_mcgr.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: MCIPREGUNTAMECI - Preguntas Dentro de Grupos en la Plantilla del Módulos Meci
        //----------------------------------------------------------------------
        #region MCIPREGUNTAMECI
        public static List<EFmcipreguntameci> flsBuscar_Mcipreguntameci(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("MCIPREGUNTAMECI", tcrBuscar, "like", "OR", "mci_idesec_mcpr,mci_despre_mcpr", tcrFiltroTabla);
                ObjectQuery<EFmcipreguntameci> lcrQuery = new ObjectQuery<EFmcipreguntameci>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Mcipreguntameci()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código de Pregunta", Width = 120, DisplayMemberBinding = new Binding("mci_idesec_mcpr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción Pregunta", Width = 400, DisplayMemberBinding = new Binding("mci_despre_mcpr") });
        }
        // Seleccionar Registro
        public string fcrSelect_Mcipreguntameci()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFmcipreguntameci)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.mci_idesec_mcpr.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

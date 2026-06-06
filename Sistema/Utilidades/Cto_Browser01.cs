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
    public class CTO_Browser01 : ViewModelBase
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
                case "CTOMAESCONTRATO":
                    fcvAddColGrid_Ctomaescontrato();
                    gobDataGrid.ItemsSource = flsBuscar_Ctomaescontrato(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CTOMAESCONTRATOIU":
                    fcvAddColGrid_Ctomaescontrato();
                    gobDataGrid.ItemsSource = flsBuscar_Ctomaescontrato(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CTOMAEAFILIADOS":
                    fcvAddColGrid_Ctomaeafiliados();
                    gobDataGrid.ItemsSource = flsBuscar_Ctomaeafiliados(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CTOMANSERVICIOS":
                    fcvAddColGrid_Ctomanservicios();
                    gobDataGrid.ItemsSource = flsBuscar_Ctomanservicios(gcrFiltroDatos, gcrFiltroTabla);
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
                case "CTOMAESCONTRATO":
                    tobDataGrid.ItemsSource = flsBuscar_Ctomaescontrato(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CTOMAESCONTRATOIU":
                    tobDataGrid.ItemsSource = flsBuscar_Ctomaescontrato(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CTOMAEAFILIADOS":
                    tobDataGrid.ItemsSource = flsBuscar_Ctomaeafiliados(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CTOMANSERVICIOS":
                    tobDataGrid.ItemsSource = flsBuscar_Ctomanservicios(gcrFiltroDatos, gcrFiltroTabla);
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
                case "CTOMAESCONTRATO":
                    lcrReturnCodigo = fcrSelect_Ctomaescontrato();
                    break;

                case "CTOMAESCONTRATOIU":
                    lcrReturnCodigo = fcrSelect_Ctomaescontrato(true);
                    break;

                case "CTOMAEAFILIADOS":
                    lcrReturnCodigo = fcrSelect_Ctomaeafiliados();
                    break;

                case "CTOMANSERVICIOS":
                    lcrReturnCodigo = fcrSelect_Ctomanservicios();
                    break;


            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CTOMAESCONTRATO - Maestro contratos con  EPS o aseguradores
        //----------------------------------------------------------------------
        #region CTOMAESCONTRATO
        public static List<EFctomaescontrato> flsBuscar_Ctomaescontrato(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CTOMAESCONTRATO", tcrBuscar, "like", "OR", "cto_seccon_cont,cto_nrocon_cont,cto_descon_cont", tcrFiltroTabla);
                ObjectQuery<EFctomaescontrato> lcrQuery = new ObjectQuery<EFctomaescontrato>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Ctomaescontrato()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id contrato ", Width = 80, DisplayMemberBinding = new Binding("cto_seccon_cont") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo contrato ", Width = 140, DisplayMemberBinding = new Binding("cto_nrocon_cont") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Decripcion contrato", Width = 430, DisplayMemberBinding = new Binding("cto_descon_cont") });
        }
        // Seleccionar Registro
        public string fcrSelect_Ctomaescontrato()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFctomaescontrato)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.cto_seccon_cont.Trim();
            }
            return lcrReturn;
        }
        // Seleccionar Registro
        public string fcrSelect_Ctomaescontrato(bool tlgDevolverIu)
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFctomaescontrato)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                if (tlgDevolverIu == false)
                {
                    lcrReturn = objReg.cto_seccon_cont.Trim();
                }
                else
                {
                    lcrReturn = objReg.cto_nrocon_cont.Trim();
                }
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CTOMAEAFILIADOS - Maestro de afiliados en contrato
        //----------------------------------------------------------------------
        #region CTOMAEAFILIADOS
        public static List<EFctomaeafiliados> flsBuscar_Ctomaeafiliados(string tcrBuscar, string tcrFiltroTabla)
        {
            List<EFctomaeafiliados> tmpDatos = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CTOMAEAFILIADOS", tcrBuscar, "like", "OR", "cto_idesec_ctou,sia_nroide_usua,sia_nomusu_usua", tcrFiltroTabla);
                ObjectQuery<EFctomaeafiliados> lcrQuery = new ObjectQuery<EFctomaeafiliados>(lcrConsulta, db);
                tmpDatos = lcrQuery.Take(100).ToList();

                return tmpDatos;
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Ctomaeafiliados()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Eps", Width = 80, DisplayMemberBinding = new Binding("sia_codeps_teps") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificacion", Width = 100, DisplayMemberBinding = new Binding("sia_nroide_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "P.Apellido", Width = 100, DisplayMemberBinding = new Binding("sia_priape_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "S.Apellido", Width = 100, DisplayMemberBinding = new Binding("sia_segape_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "P.Nombre", Width = 100, DisplayMemberBinding = new Binding("sia_prinom_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "S.Nombre", Width = 100, DisplayMemberBinding = new Binding("sia_segnom_usua") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "F.Nacimiento", Width = 100, DisplayMemberBinding = new Binding("sia_fecnac_usua") { StringFormat = "dd/MM/yyyy" } });

        }
        // Seleccionar Registro
        public string fcrSelect_Ctomaeafiliados()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFctomaeafiliados)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.cto_idesec_ctou.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CTOMANSERVICIOS - Manual ventas servicios personalizados
        //----------------------------------------------------------------------
        #region CTOMANSERVICIOS
        public static List<EFctomanservicios> flsBuscar_Ctomanservicios(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CTOMANSERVICIOS", tcrBuscar, "like", "OR", "fcm_coddig_mant,fcm_codser_mant,fcm_desser_mant", tcrFiltroTabla);
                ObjectQuery<EFctomanservicios> lcrQuery = new ObjectQuery<EFctomanservicios>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Ctomanservicios()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código digitación", Width = 120, DisplayMemberBinding = new Binding("fcm_coddig_mant") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código Servicio", Width = 120, DisplayMemberBinding = new Binding("fcm_codser_mant") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre servicio", Width = 400, DisplayMemberBinding = new Binding("fcm_desser_mant") });
        }
        // Seleccionar Registro
        public String fcrSelect_Ctomanservicios()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFctomanservicios)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.fcm_coddig_mant.Trim();
            }
            return lcrReturn;
        }
        #endregion

    }
}

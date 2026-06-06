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
    public class ODN_Browser01 : ViewModelBase
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
                case "ODNSERVICIOSIPS":
                    fcvAddColGrid_Odnserviciosips();
                    gobDataGrid.ItemsSource = flsBuscar_Odnserviciosips(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ODNDIAGNOSTICOS":
                    fcvAddColGrid_Odndiagnosticos();
                    gobDataGrid.ItemsSource = flsBuscar_Odndiagnosticos(gcrFiltroDatos, gcrFiltroTabla);
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
                case "ODNSERVICIOSIPS":
                    tobDataGrid.ItemsSource = flsBuscar_Odnserviciosips(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "ODNDIAGNOSTICOS":
                    tobDataGrid.ItemsSource = flsBuscar_Odndiagnosticos(gcrFiltroDatos, gcrFiltroTabla);
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
                case "ODNSERVICIOSIPS":
                    lcrReturnCodigo = fcrSelect_Odnserviciosips();
                    break;

                case "ODNDIAGNOSTICOS":
                    lcrReturnCodigo = fcrSelect_Odndiagnosticos();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        //-----------------------------------
        //- Browser de la tabla
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerOdn
        {
            public BrowerOdn() { }
            public string campo1 { get; set; }
            public string campo2 { get; set; }
            public string campo3 { get; set; }
            public string campo4 { get; set; }
            public string campo5 { get; set; }
            public string campo6 { get; set; }
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ODNSERVICIOSIPS - Servicios Ips para odontologia
        //----------------------------------------------------------------------
        #region ODNSERVICIOSIPS
        public static List<BrowerOdn> flsBuscar_Odnserviciosips(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region Consulta
                    var lcrQuery = from fcmmanservicios in db.Fcmmanservicios
                                   join odnserviciosips in db.Odnserviciosips on fcmmanservicios.fcm_idesec_sips equals odnserviciosips.fcm_idesec_sips
                                   where fcmmanservicios.fcm_codman_mans.Equals(tcrFiltroTabla) &&
                                        (fcmmanservicios.fcm_coddig_mant.Contains(tcrBuscar) ||
                                         fcmmanservicios.fcm_codser_mant.Contains(tcrBuscar) || 
                                         fcmmanservicios.fcm_desser_mant.Contains(tcrBuscar)) &&
                                         odnserviciosips.odn_estreg_odsi == "1" &&
                                         fcmmanservicios.fcm_estser_mant == "1" 
                                   select new BrowerOdn
                                   {
                                       campo1 = fcmmanservicios.fcm_codser_mant,
                                       campo2 = fcmmanservicios.fcm_coddig_mant,
                                       campo3 = fcmmanservicios.fcm_desser_mant,
                                       campo4 = odnserviciosips.odn_codser_odsi,
                                       campo5 = fcmmanservicios.fcm_codman_mans,
                                       campo6 = odnserviciosips.odn_tipvis_odsi,
                                   };
                    return lcrQuery.ToList();
                    #endregion
                }
                else 
                {
                    #region Consulta
                    var lcrQuery = from fcmmanservicios in db.Fcmmanservicios
                                   join odnserviciosips in db.Odnserviciosips on fcmmanservicios.fcm_idesec_sips equals odnserviciosips.fcm_idesec_sips
                                   where fcmmanservicios.fcm_codman_mans.Equals(tcrFiltroTabla) &&
                                         odnserviciosips.odn_estreg_odsi == "1" &&
                                         fcmmanservicios.fcm_estser_mant == "1" 
                                   select new BrowerOdn
                                   {
                                       campo1 = fcmmanservicios.fcm_codser_mant,
                                       campo2 = fcmmanservicios.fcm_coddig_mant,
                                       campo3 = fcmmanservicios.fcm_desser_mant,
                                       campo4 = odnserviciosips.odn_codser_odsi,
                                       campo5 = fcmmanservicios.fcm_codman_mans,
                                       campo6 = odnserviciosips.odn_tipvis_odsi,
                                   };
                    return lcrQuery.ToList();
                    #endregion
                }
           }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Odnserviciosips()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 65, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Digitación", Width = 90, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Servicio", Width = 470, DisplayMemberBinding = new Binding("campo3") });
        }
        // Seleccionar Registro
        public string fcrSelect_Odnserviciosips()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerOdn)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo2.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: ODNDIAGNOSTICOS - Diagnosticos odontologicos
        //----------------------------------------------------------------------
        #region ODNDIAGNOSTICOS
        public static List<EFodndiagnosticos> flsBuscar_Odndiagnosticos(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("ODNDIAGNOSTICOS", tcrBuscar, "like", "OR", "odn_coddia_oddx,odn_desdia_oddx", tcrFiltroTabla);
                ObjectQuery<EFodndiagnosticos> lcrQuery = new ObjectQuery<EFodndiagnosticos>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Odndiagnosticos()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 100, DisplayMemberBinding = new Binding("odn_coddia_oddx") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Diagnostico", Width = 490, DisplayMemberBinding = new Binding("odn_desdia_oddx") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "XX", Width = 490, DisplayMemberBinding = new Binding("odn_tipvis_oddx") });
        }
        // Seleccionar Registro
        public string fcrSelect_Odndiagnosticos()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFodndiagnosticos)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.odn_coddia_oddx.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

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
using Sistema.Clases;

namespace Sistema.Utilidades
{
    public class GRP_Browser01 : AuxBrowser01
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
                case "GRPMAEPLANTILLA":
                    fcvAddColGrid_Grpmaeplantilla();
                    gobDataGrid.ItemsSource = flsBuscar_Grpmaeplantilla(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "GRPFORMATOPLANT":
                    fcvAddColGrid_Grpformatoplant();
                    gobDataGrid.ItemsSource = flsBuscar_Grpformatoplant(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "GRPMAEVERSPLANT":
                    fcvAddColGrid_Grpmaeversplant();
                    gobDataGrid.ItemsSource = flsBuscar_Grpmaeversplant(gcrFiltroDatos, gcrFiltroTabla);
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
                case "GRPMAEPLANTILLA":
                    tobDataGrid.ItemsSource = flsBuscar_Grpmaeplantilla(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "GRPFORMATOPLANT":
                    tobDataGrid.ItemsSource = flsBuscar_Grpformatoplant(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "GRPMAEVERSPLANT":
                    tobDataGrid.ItemsSource = flsBuscar_Grpmaeversplant(gcrFiltroDatos, gcrFiltroTabla);
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
                case "GRPMAEPLANTILLA":
                    lcrReturnCodigo = fcrSelect_Grpmaeplantilla();
                    break;

                case "GRPFORMATOPLANT":
                    lcrReturnCodigo = fcrSelect_Grpformatoplant();
                    break;

                case "GRPMAEVERSPLANT":
                    lcrReturnCodigo = fcrSelect_Grpmaeversplant();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: GRPMAEPLANTILLA - Maestro de plantillas
        //----------------------------------------------------------------------
        #region GRPMAEPLANTILLA
        public static List<EFgrpmaeplantilla> flsBuscar_Grpmaeplantilla(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("GRPMAEPLANTILLA", tcrBuscar, "like", "OR", "grp_idepla_grpl,grp_despla_grpl", tcrFiltroTabla);
                ObjectQuery<EFgrpmaeplantilla> lcrQuery = new ObjectQuery<EFgrpmaeplantilla>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Grpmaeplantilla()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("grp_idepla_grpl") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre plantilla", Width = 550, DisplayMemberBinding = new Binding("grp_despla_grpl") });
        }
        // Seleccionar Registro
        public string fcrSelect_Grpmaeplantilla()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFgrpmaeplantilla)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.grp_idepla_grpl.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: GRPFORMATOPLANT - Lista de formatos basicos para nueva plantilla
        //----------------------------------------------------------------------
        #region GRPFORMATOPLANT
        public static List<EFgrpformatoplant> flsBuscar_Grpformatoplant(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("GRPFORMATOPLANT", tcrBuscar, "like", "OR", "grp_idefor_grfp,grp_desfor_grfp", tcrFiltroTabla);
                ObjectQuery<EFgrpformatoplant> lcrQuery = new ObjectQuery<EFgrpformatoplant>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Grpformatoplant()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("grp_idefor_grfp") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre formato", Width = 500, DisplayMemberBinding = new Binding("grp_desfor_grfp") });
        }
        // Seleccionar Registro
        public string fcrSelect_Grpformatoplant()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFgrpformatoplant)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.grp_idefor_grfp.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: GRPMAEVERSPLANT - Maestro versiones de plantillas
        //----------------------------------------------------------------------
        #region GRPMAEVERSPLANT
        public static List<BrowerTabla> flsBuscar_Grpmaeversplant(string tcrBuscar, string tcrFiltroTabla)
        {
            List<BrowerTabla> lcrTemporal = null;
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region con filtro de busqueda
                    var lcrQuery = from t1 in db.Grpmaeversplant
                                   join t2 in db.Grpmaeplantilla on t1.grp_idepla_grpl equals t2.grp_idepla_grpl
                                   where t1.grp_idepla_grpv.Contains(tcrBuscar) ||
                                        t1.grp_idepla_grpl.Contains(tcrBuscar) ||
                                        t2.grp_despla_grpl.Contains(tcrBuscar)
                                   orderby t1.grp_idepla_grpv
                                   select new BrowerTabla
                                   {
                                       campo1 = t1.grp_idepla_grpv,
                                       campo2 = t1.grp_idepla_grpl,
                                       campo3 = t2.grp_despla_grpl,
                                       campo4 = t1.grp_idepla_grpv ==  t2.grp_idepla_grpv ? "ACTIVO" : "INACTIVO"
                                   };
                    lcrTemporal = lcrQuery.ToList();
                    #endregion
                }
                else
                {
                    #region sin filtro de busqueda
                    var lcrQuery = from t1 in db.Grpmaeversplant
                                   join t2 in db.Grpmaeplantilla on t1.grp_idepla_grpl equals t2.grp_idepla_grpl
                                   orderby t1.grp_idepla_grpv
                                   select new BrowerTabla
                                   {
                                       campo1 = t1.grp_idepla_grpv,
                                       campo2 = t1.grp_idepla_grpl,
                                       campo3 = t2.grp_despla_grpl,
                                       campo4 = t1.grp_idepla_grpv == t2.grp_idepla_grpv ? "ACTIVO" : "INACTIVO"
                                   };
                    lcrTemporal = lcrQuery.ToList();
                    #endregion
                }
            }
            return lcrTemporal;
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Grpmaeversplant()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Plantilla", Width = 120, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Versión", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 700, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado", Width = 120, DisplayMemberBinding = new Binding("campo4") });
        }
        // Seleccionar Registro
        public string fcrSelect_Grpmaeversplant()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerTabla)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo1.Trim();
            }
            return lcrReturn;
        }
        #endregion

    }
 }
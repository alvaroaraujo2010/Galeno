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
    public class FAR_Browser01 : AuxBrowser01
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
                case "FARGRUFARMACOMA":
                    fcvAddColGrid_Fargrufarmacoma();
                    gobDataGrid.ItemsSource = flsBuscar_Fargrufarmacoma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FARGRUFARMACOMD":
                    fcvAddColGrid_Fargrufarmacomd();
                    gobDataGrid.ItemsSource = flsBuscar_Fargrufarmacomd(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FARMOVMEDICAMMA":
                    fcvAddColGrid_Farmovmedicamma();
                    gobDataGrid.ItemsSource = flsBuscar_Farmovmedicamma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FARMOVMEDICAMMD":
                    fcvAddColGrid_Farmovmedicammd();
                    gobDataGrid.ItemsSource = flsBuscar_Farmovmedicammd(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FAREXPEDMEDICMD":
                    fcvAddColGrid_Farexpedmedicmd();
                    gobDataGrid.ItemsSource = flsBuscar_Farexpedmedicmd(gcrFiltroDatos, gcrFiltroTabla).DefaultView;
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
                case "FARGRUFARMACOMA":
                    tobDataGrid.ItemsSource = flsBuscar_Fargrufarmacoma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FARGRUFARMACOMD":
                    tobDataGrid.ItemsSource = flsBuscar_Fargrufarmacomd(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FARMOVMEDICAMMA":
                    tobDataGrid.ItemsSource = flsBuscar_Farmovmedicamma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FARMOVMEDICAMMD":
                    tobDataGrid.ItemsSource = flsBuscar_Farmovmedicammd(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FAREXPEDMEDICMD":
                    tobDataGrid.ItemsSource = flsBuscar_Farexpedmedicmd(gcrFiltroDatos, gcrFiltroTabla).DefaultView;
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
                case "FARGRUFARMACOMA":
                    lcrReturnCodigo = fcrSelect_Fargrufarmacoma();
                    break;

                case "FARGRUFARMACOMD":
                    lcrReturnCodigo = fcrSelect_Fargrufarmacomd();
                    break;

                case "FARMOVMEDICAMMA":
                    lcrReturnCodigo = fcrSelect_Farmovmedicamma();
                    break;

                case "FARMOVMEDICAMMD":
                    lcrReturnCodigo = fcrSelect_Farmovmedicammd();
                    break;

                case "FAREXPEDMEDICMD":
                    lcrReturnCodigo = fcrSelect_Farexpedmedicmd();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FARGRUFARMACOMA - Grupo farmacologico del medicamento
        //----------------------------------------------------------------------
        #region FARGRUFARMACOMA
        public static List<EFfargrufarmacoma> flsBuscar_Fargrufarmacoma(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FARGRUFARMACOMA", tcrBuscar, "like", "OR", "far_grufar_fagf,far_desgru_fagf", tcrFiltroTabla);
                ObjectQuery<EFfargrufarmacoma> lcrQuery = new ObjectQuery<EFfargrufarmacoma>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fargrufarmacoma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Grupo", Width = 120, DisplayMemberBinding = new Binding("far_grufar_fagf") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion Grupo", Width = 400, DisplayMemberBinding = new Binding("far_desgru_fagf") });
        }
        // Seleccionar Registro
        public String fcrSelect_Fargrufarmacoma()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfargrufarmacoma)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.far_grufar_fagf.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FARGRUFARMACOMD - Subgrupo farmacologico del medicamento (detalles)
        //----------------------------------------------------------------------
        #region FARGRUFARMACOMD
        public static List<BrowerTabla> flsBuscar_Fargrufarmacomd(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from fargrufarmacomd in db.Fargrufarmacomd
                                      join fargrufarmacoma in db.Fargrufarmacoma on fargrufarmacomd.far_grufar_fagf equals fargrufarmacoma.far_grufar_fagf into tmfargrufarmacoma
                                      from fagf in tmfargrufarmacoma.DefaultIfEmpty()
                                      select new BrowerTabla
                                      {
                                          #region Datos
                                          campo1 = fargrufarmacomd.far_sugfar_fasg,
                                          campo2 = fargrufarmacomd.far_desgru_fasg,
                                          campo3 = fargrufarmacomd.far_grufar_fagf,
                                          campo4 = fagf.far_desgru_fagf,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from fargrufarmacomd in db.Fargrufarmacomd
                                      join fargrufarmacoma in db.Fargrufarmacoma on fargrufarmacomd.far_grufar_fagf equals fargrufarmacoma.far_grufar_fagf into tmfargrufarmacoma
                                      from fagf in tmfargrufarmacoma.DefaultIfEmpty()
                                      where fargrufarmacomd.far_sugfar_fasg.Contains(tcrBuscar) ||
                                            fargrufarmacomd.far_desgru_fasg.Contains(tcrBuscar) ||
                                            fargrufarmacomd.far_grufar_fagf.Contains(tcrBuscar) ||
                                            fagf.far_desgru_fagf.Contains(tcrBuscar) 
                                      select new BrowerTabla
                                      {
                                          #region Datos
                                          campo1 = fargrufarmacomd.far_sugfar_fasg,
                                          campo2 = fargrufarmacomd.far_desgru_fasg,
                                          campo3 = fargrufarmacomd.far_grufar_fagf,
                                          campo4 = fagf.far_desgru_fagf,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }

            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fargrufarmacomd()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 90, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Grupo farmacologico", Width = 300, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Subgrupo", Width = 100, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Subgrupo farmacologico", Width = 490, DisplayMemberBinding = new Binding("campo2") });
        }
        // Seleccionar Registro
        public String fcrSelect_Fargrufarmacomd()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerTabla)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo1.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FARMOVMEDICAMMA - Maestro entrega formulas y medicamentos intrahospitalarios
        //----------------------------------------------------------------------
        #region FARMOVMEDICAMMA
        public static List<BrowerTabla> flsBuscar_Farmovmedicamma(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                var lcrCodigoAlmacen = Funciones.fuxExtraerElemento(1, "*", tcrFiltroTabla); // Codigo Almacen
                var lcrEstadoRegistro = Funciones.fuxExtraerElemento(2, "*", tcrFiltroTabla); // Estado del registro
                
                var lcrEstado1 = lcrEstadoRegistro;
                var lcrEstado2 = lcrEstado1;
                var lcrEstado3 = lcrEstado1;

                if (lcrEstadoRegistro == "TODOS")
                {
                    lcrEstado1 = "1"; // Abierto
                    lcrEstado2 = "2"; // Confirmadas
                    lcrEstado3 = "3"; // Anulado
                }
                // Ejecutar consulta de datos
                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region Consulta farmovmedicamma
                    var lobConsulta = from farmovmedicamma in db.Farmovmedicamma
                                      join invalmacenmaest in db.Invalmacenmaest on farmovmedicamma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join siausuarioatend in db.Siausuarioatend on farmovmedicamma.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join admregadmision in db.Admregadmision on farmovmedicamma.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision 
                                      join sisestadoproces in db.Sisestadoproces on farmovmedicamma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      from rgda in tmadmregadmision.DefaultIfEmpty()
                                      where (farmovmedicamma.far_nroreg_fams.Contains(tcrBuscar) &&
                                      (farmovmedicamma.inv_codalm_inal == lcrCodigoAlmacen &&
                                            (farmovmedicamma.sis_estpro_espr == lcrEstado1 ||
                                             farmovmedicamma.sis_estpro_espr == lcrEstado2 ||
                                             farmovmedicamma.sis_estpro_espr == lcrEstado3)))
                                      select new BrowerTabla
                                      {
                                          campo1 = farmovmedicamma.far_nroreg_fams,
                                          campo2 = usua.sia_nomusu_usua,
                                          campo3 = rgda.adm_secadm_rgad,
                                          campo4 = espr.sis_despro_espr,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }
                else
                {
                    #region Consulta farmovmedicamma
                    var lobConsulta = from farmovmedicamma in db.Farmovmedicamma
                                      join invalmacenmaest in db.Invalmacenmaest on farmovmedicamma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join siausuarioatend in db.Siausuarioatend on farmovmedicamma.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join admregadmision in db.Admregadmision on farmovmedicamma.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision 
                                      join sisestadoproces in db.Sisestadoproces on farmovmedicamma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      from rgda in tmadmregadmision.DefaultIfEmpty()
                                      where (farmovmedicamma.inv_codalm_inal == lcrCodigoAlmacen &&
                                            (farmovmedicamma.sis_estpro_espr == lcrEstado1 ||
                                             farmovmedicamma.sis_estpro_espr == lcrEstado2 ||
                                             farmovmedicamma.sis_estpro_espr == lcrEstado3))
                                      select new BrowerTabla
                                      {
                                          campo1 = farmovmedicamma.far_nroreg_fams,
                                          campo2 = usua.sia_nomusu_usua,
                                          campo3 = rgda.adm_secadm_rgad,
                                          campo4 = espr.sis_despro_espr,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }

            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Farmovmedicamma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo registro", Width = 90, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Usuario", Width = 500, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Admisión", Width = 200, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado registro", Width = 200, DisplayMemberBinding = new Binding("campo4") });

        }
        // Seleccionar Registro
        public String fcrSelect_Farmovmedicamma()
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
        //----------------------------------------------------------------------
        //    TABLA: FARMOVMEDICAMMD - Maestro detalles entrega formulas y medicamentos intrahospit
        //----------------------------------------------------------------------
        #region FARMOVMEDICAMMD
        public static List<EFfarmovmedicammd> flsBuscar_Farmovmedicammd(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FARMOVMEDICAMMD", tcrBuscar, "like", "OR", "far_nroreg_fads,", tcrFiltroTabla);
                ObjectQuery<EFfarmovmedicammd> lcrQuery = new ObjectQuery<EFfarmovmedicammd>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Farmovmedicammd()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo registro", Width = 120, DisplayMemberBinding = new Binding("far_nroreg_fads") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "", Width = 400, DisplayMemberBinding = new Binding("") });
        }
        // Seleccionar Registro
        public String fcrSelect_Farmovmedicammd()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfarmovmedicammd)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.far_nroreg_fads.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FAREXPEDMEDICMD - Detalles expediente medicamentos INVIMA según concentracion y  presentacion  			
        //----------------------------------------------------------------------
        #region FAREXPEDMEDICMD
        public static DataTable flsBuscar_Farexpedmedicmd(String tcrBuscar, String tcrFiltroTabla)
        {
            var lcrFiltro = " WHERE farexpedmedicma.far_desexp_fama LIKE '%" + tcrBuscar + "%' OR " +
                                    "farexpedmedicmd.far_codcum_famd LIKE '%" + tcrBuscar + "%' " +
                                    " ORDER BY farexpedmedicma.far_desexp_fama DESC LIMIT 300";
            if (String.IsNullOrWhiteSpace(tcrBuscar))
            {
                lcrFiltro = " ORDER BY farexpedmedicma.far_desexp_fama DESC LIMIT 300";
            }
            var lcrLineaSqlSelct = fcrLineaSqlExpediente() + lcrFiltro;

            var lobjDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
            return lobjDatosTabla;

        }
        public static String fcrLineaSqlExpediente()
        {
            var lcrLinea = "SELECT farexpedmedicma.far_expedi_fama," +
                                   "farexpedmedicmd.far_codcum_famd," +
                                   "farexpedmedicma.far_desexp_fama," +
                                   "farexpedmedicmd.far_precom_famd" +
                            " FROM farexpedmedicmd" +
                                  " INNER JOIN farexpedmedicma ON (farexpedmedicmd.far_expedi_fama = farexpedmedicma.far_expedi_fama)";
            return lcrLinea;
        }

        // Crear Columans del DataGrid
        public void fcvAddColGrid_Farexpedmedicmd()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo Cum", Width = 130, DisplayMemberBinding = new Binding("far_codcum_famd") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Medicamento", Width = 500, DisplayMemberBinding = new Binding("far_desexp_fama") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Presentación", Width = 420, DisplayMemberBinding = new Binding("far_precom_famd") });
        }
        // Seleccionar Registro
        public String fcrSelect_Farexpedmedicmd()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                //var objReg = (BrowerAdmision)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                var objReg = (DataRowView)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg["far_codcum_famd"].ToString().Trim();
            }
            return lcrReturn;
        }
        #endregion

    }
}

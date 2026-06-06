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
    public class INV_Browser01 : AuxBrowser01
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
                case "INVMOVCOMPRASMA":
                    fcvAddColGrid_Invmovcomprasma();
                    gobDataGrid.ItemsSource = flsBuscar_Invmovcomprasma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVTIPOREGIMOVI":
                    fcvAddColGrid_Invtiporegimovi();
                    gobDataGrid.ItemsSource = flsBuscar_Invtiporegimovi(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVTIPORECOMPRA":
                    fcvAddColGrid_Invtiporecompra();
                    gobDataGrid.ItemsSource = flsBuscar_Invtiporecompra(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVTIPOCONCEMOV":
                    fcvAddColGrid_Invtipoconcemov();
                    gobDataGrid.ItemsSource = flsBuscar_Invtipoconcemov(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVALMACENMAEST":
                    fcvAddColGrid_Invalmacenmaest();
                    gobDataGrid.ItemsSource = flsBuscar_Invalmacenmaest(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVMAEARTICULOS":
                    fcvAddColGrid_Invmaearticulos();
                    gobDataGrid.ItemsSource = flsBuscar_Invmaearticulos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVINVENTGRUPOS":
                    fcvAddColGrid_Invinventgrupos();
                    gobDataGrid.ItemsSource = flsBuscar_Invinventgrupos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVINVENTSUBGRU":
                    fcvAddColGrid_Invinventsubgru();
                    gobDataGrid.ItemsSource = flsBuscar_Invinventsubgru(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVCONTENEDORES":
                    fcvAddColGrid_Invcontenedores();
                    gobDataGrid.ItemsSource = flsBuscar_Invcontenedores(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVAJUSTECONCEP":
                    fcvAddColGrid_Invajusteconcep();
                    gobDataGrid.ItemsSource = flsBuscar_Invajusteconcep(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVRESPONSABLES":
                    fcvAddColGrid_Invresponsables();
                    gobDataGrid.ItemsSource = flsBuscar_Invresponsables(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVMOVDIARIOSMA-TS":
                    fcvAddColGrid_Invmovdiariosma();
                    gobDataGrid.ItemsSource = flsBuscar_Invmovdiariosma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVMOVDIARIOSMD":
                    fcvAddColGrid_Invmovdiariosmd();
                    gobDataGrid.ItemsSource = flsBuscar_Invmovdiariosmd(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVALMACEXISTEN":
                    fcvAddColGrid_Invalmacexisten();
                    gobDataGrid.ItemsSource = flsBuscar_Invalmacexisten(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVPERIODOMAEST":
                    fcvAddColGrid_Invperiodomaest();
                    gobDataGrid.ItemsSource = flsBuscar_Invperiodomaest(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVAJUSTESMAEMA-AI":
                    fcvAddColGrid_Invajustesmaema();
                    gobDataGrid.ItemsSource = flsBuscar_Invajustesmaema(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVAJUSTESMAEMD":
                    fcvAddColGrid_Invajustesmaemd();
                    gobDataGrid.ItemsSource = flsBuscar_Invajustesmaemd(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVALMACEXISTEN-SERV-IPS":
                    fcvAddColGrid_InvalmacexistenIps();
                    gobDataGrid.ItemsSource = flsBuscar_InvalmacexistenIps(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVALMACEXISTEN-SERV-IPS-CODAUX":
                    fcvAddColGrid_InvalmacexistenIps();
                    gobDataGrid.ItemsSource = flsBuscar_InvalmacexistenIps(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FAREXPEDMEDICMD":
                    fcvAddColGrid_Farexpedmedicmd();
                    gobDataGrid.ItemsSource = flsBuscar_Farexpedmedicmd(gcrFiltroDatos, gcrFiltroTabla);
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
                case "INVMOVCOMPRASMA":
                    tobDataGrid.ItemsSource = flsBuscar_Invmovcomprasma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVTIPOREGIMOVI":
                    tobDataGrid.ItemsSource = flsBuscar_Invtiporegimovi(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVTIPORECOMPRA":
                    tobDataGrid.ItemsSource = flsBuscar_Invtiporecompra(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVTIPOCONCEMOV":
                    tobDataGrid.ItemsSource = flsBuscar_Invtipoconcemov(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVALMACENMAEST":
                    tobDataGrid.ItemsSource = flsBuscar_Invalmacenmaest(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVMAEARTICULOS":
                    tobDataGrid.ItemsSource = flsBuscar_Invmaearticulos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVINVENTGRUPOS":
                    tobDataGrid.ItemsSource = flsBuscar_Invinventgrupos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVINVENTSUBGRU":
                    tobDataGrid.ItemsSource = flsBuscar_Invinventsubgru(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVCONTENEDORES":
                    tobDataGrid.ItemsSource = flsBuscar_Invcontenedores(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVAJUSTECONCEP":
                    tobDataGrid.ItemsSource = flsBuscar_Invajusteconcep(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVRESPONSABLES":
                    tobDataGrid.ItemsSource = flsBuscar_Invresponsables(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVMOVDIARIOSMA-TS":
                    tobDataGrid.ItemsSource = flsBuscar_Invmovdiariosma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVMOVDIARIOSMD":
                    tobDataGrid.ItemsSource = flsBuscar_Invmovdiariosmd(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVALMACEXISTEN":
                    tobDataGrid.ItemsSource = flsBuscar_Invalmacexisten(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVPERIODOMAEST":
                    tobDataGrid.ItemsSource = flsBuscar_Invperiodomaest(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVAJUSTESMAEMA-AI":
                    tobDataGrid.ItemsSource = flsBuscar_Invajustesmaema(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVAJUSTESMAEMD":
                    tobDataGrid.ItemsSource = flsBuscar_Invajustesmaemd(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVALMACEXISTEN-SERV-IPS":
                    tobDataGrid.ItemsSource = flsBuscar_InvalmacexistenIps(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "INVALMACEXISTEN-SERV-IPS-CODAUX":
                    tobDataGrid.ItemsSource = flsBuscar_InvalmacexistenIps(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FAREXPEDMEDICMD":
                    tobDataGrid.ItemsSource = flsBuscar_Farexpedmedicmd(gcrFiltroDatos, gcrFiltroTabla);
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
                case "INVMOVCOMPRASMA":
                    lcrReturnCodigo = fcrSelect_Invmovcomprasma();
                    break;

                case "INVTIPOREGIMOVI":
                    lcrReturnCodigo = fcrSelect_Invtiporegimovi();
                    break;

                case "INVTIPORECOMPRA":
                    lcrReturnCodigo = fcrSelect_Invtiporecompra();
                    break;

                case "INVTIPOCONCEMOV":
                    lcrReturnCodigo = fcrSelect_Invtipoconcemov();
                    break;

                case "INVALMACENMAEST":
                    lcrReturnCodigo = fcrSelect_Invalmacenmaest();
                    break;

                case "INVMAEARTICULOS":
                    lcrReturnCodigo = fcrSelect_Invmaearticulos();
                    break;

                case "INVINVENTGRUPOS":
                    lcrReturnCodigo = fcrSelect_Invinventgrupos();
                    break;

                case "INVINVENTSUBGRU":
                    lcrReturnCodigo = fcrSelect_Invinventsubgru();
                    break;

                case "INVCONTENEDORES":
                    lcrReturnCodigo = fcrSelect_Invcontenedores();
                    break;

                case "INVAJUSTECONCEP":
                    lcrReturnCodigo = fcrSelect_Invajusteconcep();
                    break;

                case "INVRESPONSABLES":
                    lcrReturnCodigo = fcrSelect_Invresponsables();
                    break;

                case "INVMOVDIARIOSMA-TS":
                    lcrReturnCodigo = fcrSelect_Invmovdiariosma();
                    break;

                case "INVMOVDIARIOSMD":
                    lcrReturnCodigo = fcrSelect_Invmovdiariosmd();
                    break;

                case "INVALMACEXISTEN":
                    lcrReturnCodigo = fcrSelect_Invalmacexisten();
                    break;

                case "INVPERIODOMAEST":
                    lcrReturnCodigo = fcrSelect_Invperiodomaest();
                    break;

                case "INVAJUSTESMAEMA-AI":
                    lcrReturnCodigo = fcrSelect_Invajustesmaema();
                    break;

                case "INVAJUSTESMAEMD":
                    lcrReturnCodigo = fcrSelect_Invajustesmaemd();
                    break;

                case "INVALMACEXISTEN-SERV-IPS":
                    lcrReturnCodigo = fcrSelect_InvalmacexistenIps();
                    break;

                case "INVALMACEXISTEN-SERV-IPS-CODAUX":
                    lcrReturnCodigo = fcrSelect_InvalmacexistenIpsAux();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVMOVCOMPRASMA - Tabla maestro movimientos compras
        //----------------------------------------------------------------------
        #region INVMOVCOMPRASMA
        public static List<BrowerTabla> flsBuscar_Invmovcomprasma(string tcrBuscar, string tcrFiltroTabla)
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
                if (lcrEstadoRegistro == "ACTIVOS")
                {
                    lcrEstado1 = "1"; // Abierto
                    lcrEstado2 = "1"; // Abiertas
                    lcrEstado3 = "2"; // Confirmadas
                }
                else
                {
                    // Queda el estado que venia en el parametro puede ser "1" , "2" o estado  "3"
                }

                // Ejecutar consulta de datos
                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region Consulta invmovcomprasma
                    var lobConsulta = from invmovcomprasma in db.Invmovcomprasma
                                      join sisproveedores in db.Sisproveedores on invmovcomprasma.sis_secpro_sipr equals sisproveedores.sis_secpro_sipr into tmsisproveedores
                                      join invalmacenmaest in db.Invalmacenmaest on invmovcomprasma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join concentrodcosto in db.Concentrodcosto on invmovcomprasma.con_codsco_ccos equals concentrodcosto.con_codsco_ccos into tmconcentrodcosto
                                      join sysusuarios in db.Sysusuarios on invmovcomprasma.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      join sisestadoproces in db.Sisestadoproces on invmovcomprasma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from sipr in tmsisproveedores.DefaultIfEmpty()
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from ccos in tmconcentrodcosto.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where (invmovcomprasma.inv_secreg_inca.Contains(tcrBuscar) ||
                                            invmovcomprasma.inv_desreg_inca.Contains(tcrBuscar) ||
                                            invmovcomprasma.inv_numdoc_inca.Contains(tcrBuscar) ||
                                            sipr.sis_razsoc_sipr.Contains(tcrBuscar)) &&
                                            (invmovcomprasma.inv_codalm_inal == lcrCodigoAlmacen &&
                                            (invmovcomprasma.sis_estpro_espr == lcrEstado1 ||
                                             invmovcomprasma.sis_estpro_espr == lcrEstado2 ||
                                             invmovcomprasma.sis_estpro_espr == lcrEstado3))
                                      orderby invmovcomprasma.inv_fecges_inca descending
                                      select new BrowerTabla
                                      {
                                          campo1 = invmovcomprasma.inv_secreg_inca,
                                          campo15 = (DateTime)invmovcomprasma.inv_fecges_inca,
                                          campo2 = invmovcomprasma.inv_desreg_inca,
                                          campo3 = invmovcomprasma.sis_secpro_sipr,
                                          campo4 = sipr.sis_razsoc_sipr,
                                          campo5 = invmovcomprasma.inv_numdoc_inca,
                                          campo16 = (DateTime)invmovcomprasma.inv_fecdoc_inca,
                                          campo6 = invmovcomprasma.inv_codalm_inal,
                                          campo7 = inal.inv_desalm_inal,
                                          campo8 = invmovcomprasma.sis_estpro_espr,
                                          campo9 = espr.sis_despro_espr,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }
                else
                {
                    #region Consulta invmovcomprasma
                    var lobConsulta = from invmovcomprasma in db.Invmovcomprasma
                                      join sisproveedores in db.Sisproveedores on invmovcomprasma.sis_secpro_sipr equals sisproveedores.sis_secpro_sipr into tmsisproveedores
                                      join invalmacenmaest in db.Invalmacenmaest on invmovcomprasma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join concentrodcosto in db.Concentrodcosto on invmovcomprasma.con_codsco_ccos equals concentrodcosto.con_codsco_ccos into tmconcentrodcosto
                                      join sysusuarios in db.Sysusuarios on invmovcomprasma.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      join sisestadoproces in db.Sisestadoproces on invmovcomprasma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from sipr in tmsisproveedores.DefaultIfEmpty()
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from ccos in tmconcentrodcosto.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where invmovcomprasma.inv_codalm_inal == lcrCodigoAlmacen &&
                                            (invmovcomprasma.sis_estpro_espr == lcrEstado1 ||
                                             invmovcomprasma.sis_estpro_espr == lcrEstado2 ||
                                             invmovcomprasma.sis_estpro_espr == lcrEstado3)
                                      orderby invmovcomprasma.inv_fecges_inca descending
                                      select new BrowerTabla
                                      {
                                          campo1 = invmovcomprasma.inv_secreg_inca,
                                          campo15 = (DateTime)invmovcomprasma.inv_fecges_inca,
                                          campo2 = invmovcomprasma.inv_desreg_inca,
                                          campo3 = invmovcomprasma.sis_secpro_sipr,
                                          campo4 = sipr.sis_razsoc_sipr,
                                          campo5 = invmovcomprasma.inv_numdoc_inca,
                                          campo16 = (DateTime)invmovcomprasma.inv_fecdoc_inca,
                                          campo6 = invmovcomprasma.inv_codalm_inal,
                                          campo7 = inal.inv_desalm_inal,
                                          campo8 = invmovcomprasma.sis_estpro_espr,
                                          campo9 = espr.sis_despro_espr,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }

            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invmovcomprasma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Registro", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha", Width = 100, DisplayMemberBinding = new Binding("campo15") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 400, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Cod.Proveedor", Width = 100, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Proveedor", Width = 200, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Factura", Width = 120, DisplayMemberBinding = new Binding("campo5") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha Factura", Width = 120, DisplayMemberBinding = new Binding("campo16") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado Reg.", Width = 140, DisplayMemberBinding = new Binding("campo9") });
        }
        // Seleccionar Registro
        public string fcrSelect_Invmovcomprasma()
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
        //    TABLA: INVTIPOREGIMOVI - Tipos registro movimientos inventarios
        //----------------------------------------------------------------------
        #region INVTIPOREGIMOVI
        public static List<EFinvtiporegimovi> flsBuscar_Invtiporegimovi(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVTIPOREGIMOVI", tcrBuscar, "like", "OR", "inv_tipmov_intr,inv_desreg_intr", tcrFiltroTabla);
                ObjectQuery<EFinvtiporegimovi> lcrQuery = new ObjectQuery<EFinvtiporegimovi>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invtiporegimovi()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo", Width = 120, DisplayMemberBinding = new Binding("inv_tipmov_intr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Movimiento", Width = 400, DisplayMemberBinding = new Binding("inv_desreg_intr") });
        }
        // Seleccionar Registro
        public string fcrSelect_Invtiporegimovi()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvtiporegimovi)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_tipmov_intr.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVTIPORECOMPRA - Tipos registro movimientos en compra
        //----------------------------------------------------------------------
        #region INVTIPORECOMPRA
        public static List<EFinvtiporecompra> flsBuscar_Invtiporecompra(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVTIPORECOMPRA", tcrBuscar, "like", "OR", "inv_tipreg_incx,inv_desreg_incx", tcrFiltroTabla);
                ObjectQuery<EFinvtiporecompra> lcrQuery = new ObjectQuery<EFinvtiporecompra>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invtiporecompra()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo registro", Width = 120, DisplayMemberBinding = new Binding("inv_tipreg_incx") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo registro compra", Width = 400, DisplayMemberBinding = new Binding("inv_desreg_incx") });
        }
        // Seleccionar Registro
        public string fcrSelect_Invtiporecompra()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvtiporecompra)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_tipreg_incx.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVTIPOCONCEMOV - Concepto del detalle movimiento diario
        //----------------------------------------------------------------------
        #region INVTIPOCONCEMOV
        public static List<EFinvtipoconcemov> flsBuscar_Invtipoconcemov(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVTIPOCONCEMOV", tcrBuscar, "like", "OR", "inv_conmov_incm,inv_descon_incm", tcrFiltroTabla);
                ObjectQuery<EFinvtipoconcemov> lcrQuery = new ObjectQuery<EFinvtipoconcemov>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invtipoconcemov()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Concepto", Width = 120, DisplayMemberBinding = new Binding("inv_conmov_incm") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 400, DisplayMemberBinding = new Binding("inv_descon_incm") });
        }
        // Seleccionar Registro
        public string fcrSelect_Invtipoconcemov()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvtipoconcemov)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_conmov_incm.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVALMACENMAEST - Tabla Maestro almacenes
        //----------------------------------------------------------------------
        #region INVALMACENMAEST
        public static List<EFinvalmacenmaest> flsBuscar_Invalmacenmaest(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVALMACENMAEST", tcrBuscar, "like", "OR", "inv_codalm_inal,inv_desalm_inal", tcrFiltroTabla);
                ObjectQuery<EFinvalmacenmaest> lcrQuery = new ObjectQuery<EFinvalmacenmaest>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invalmacenmaest()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("inv_codalm_inal") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción Almacén", Width = 400, DisplayMemberBinding = new Binding("inv_desalm_inal") });
        }
        // Seleccionar Registro
        public string fcrSelect_Invalmacenmaest()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvalmacenmaest)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_codalm_inal.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVMAEARTICULOS - Tabla Maestro Artículos
        //----------------------------------------------------------------------
        #region INVMAEARTICULOS
        public static List<EFinvmaearticulos> flsBuscar_Invmaearticulos(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVMAEARTICULOS", tcrBuscar, "like", "OR", "inv_secart_inar,inv_nomart_inar,inv_codaux_inar", tcrFiltroTabla);
                ObjectQuery<EFinvmaearticulos> lcrQuery = new ObjectQuery<EFinvmaearticulos>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invmaearticulos()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id Unico", Width = 100, DisplayMemberBinding = new Binding("inv_secart_inar") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo digitación", Width = 120, DisplayMemberBinding = new Binding("inv_codaux_inar") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre artículo", Width = 400, DisplayMemberBinding = new Binding("inv_nomart_inar") });
        }
        // Seleccionar Registro
        public string fcrSelect_Invmaearticulos()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvmaearticulos)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_secart_inar.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVINVENTGRUPOS - Grupos  articulos de inventarios
        //----------------------------------------------------------------------
        #region INVINVENTGRUPOS
        public static List<EFinvinventgrupos> flsBuscar_Invinventgrupos(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVINVENTGRUPOS", tcrBuscar, "like", "OR", "inv_codgru_ingr,inv_desgru_ingr", tcrFiltroTabla);
                ObjectQuery<EFinvinventgrupos> lcrQuery = new ObjectQuery<EFinvinventgrupos>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invinventgrupos()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("inv_codgru_ingr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion Grupo", Width = 400, DisplayMemberBinding = new Binding("inv_desgru_ingr") });
        }
        // Seleccionar Registro
        public String fcrSelect_Invinventgrupos()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvinventgrupos)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_codgru_ingr.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVINVENTSUBGRU - Subgrupos de inventarios
        //----------------------------------------------------------------------
        #region INVINVENTSUBGRU
        public static List<BrowerTabla> flsBuscar_Invinventsubgru(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from invinventsubgru in db.Invinventsubgru
                                      join invinventgrupos in db.Invinventgrupos on invinventsubgru.inv_codgru_ingr equals invinventgrupos.inv_codgru_ingr into tminvinventgrupos
                                      from ingr in tminvinventgrupos.DefaultIfEmpty()
                                      select new BrowerTabla
                                      {
                                          #region Datos
                                          campo1 = invinventsubgru.inv_codsub_insg,
                                          campo2 = invinventsubgru.inv_dessub_insg,
                                          campo3 = invinventsubgru.inv_codgru_ingr,
                                          campo4 = ingr.inv_desgru_ingr,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from invinventsubgru in db.Invinventsubgru
                                      join invinventgrupos in db.Invinventgrupos on invinventsubgru.inv_codgru_ingr equals invinventgrupos.inv_codgru_ingr into tminvinventgrupos
                                      from ingr in tminvinventgrupos.DefaultIfEmpty()
                                      where invinventsubgru.inv_codsub_insg.Contains(tcrBuscar) ||
                                            invinventsubgru.inv_dessub_insg.Contains(tcrBuscar) ||
                                            invinventsubgru.inv_codgru_ingr.Contains(tcrBuscar) ||
                                            ingr.inv_desgru_ingr.Contains(tcrBuscar)
                                      select new BrowerTabla
                                      {
                                          #region Datos
                                          campo1 = invinventsubgru.inv_codsub_insg,
                                          campo2 = invinventsubgru.inv_dessub_insg,
                                          campo3 = invinventsubgru.inv_codgru_ingr,
                                          campo4 = ingr.inv_desgru_ingr,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }

            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invinventsubgru()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 90, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Grupo", Width = 150, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Subgrupo", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Subgrupo inventario", Width = 290, DisplayMemberBinding = new Binding("campo2") });
        }
        // Seleccionar Registro
        public String fcrSelect_Invinventsubgru()
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
        //    TABLA: INVCONTENEDORES - Tabla tipos de contenedores (presentacion articulos)
        //----------------------------------------------------------------------
        #region INVCONTENEDORES
        public static List<EFinvcontenedores> flsBuscar_Invcontenedores(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVCONTENEDORES", tcrBuscar, "like", "OR", "inv_codctn_intc,inv_desctn_intc", tcrFiltroTabla);
                ObjectQuery<EFinvcontenedores> lcrQuery = new ObjectQuery<EFinvcontenedores>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invcontenedores()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("inv_codctn_intc") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 400, DisplayMemberBinding = new Binding("inv_desctn_intc") });
        }
        // Seleccionar Registro
        public String fcrSelect_Invcontenedores()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvcontenedores)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_codctn_intc.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVAJUSTECONCEP - Tabla Concepto de ajuste inventario
        //----------------------------------------------------------------------
        #region INVAJUSTECONCEP
        public static List<EFinvajusteconcep> flsBuscar_Invajusteconcep(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVAJUSTECONCEP", tcrBuscar, "like", "OR", "inv_conaju_incp,inv_desaju_incp", tcrFiltroTabla);
                ObjectQuery<EFinvajusteconcep> lcrQuery = new ObjectQuery<EFinvajusteconcep>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invajusteconcep()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código Concepto", Width = 120, DisplayMemberBinding = new Binding("inv_conaju_incp") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion Concepto", Width = 400, DisplayMemberBinding = new Binding("inv_desaju_incp") });
        }
        // Seleccionar Registro
        public String fcrSelect_Invajusteconcep()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvajusteconcep)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_conaju_incp.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVRESPONSABLES - Tabla personas responsables
        //----------------------------------------------------------------------
        #region INVRESPONSABLES
        public static List<EFinvresponsables> flsBuscar_Invresponsables(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVRESPONSABLES", tcrBuscar, "like", "OR", "inv_codres_inre,inv_nomres_inre", tcrFiltroTabla);
                ObjectQuery<EFinvresponsables> lcrQuery = new ObjectQuery<EFinvresponsables>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invresponsables()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código responsable", Width = 120, DisplayMemberBinding = new Binding("inv_codres_inre") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Persona responsable", Width = 400, DisplayMemberBinding = new Binding("inv_nomres_inre") });
        }
        // Seleccionar Registro
        public string fcrSelect_Invresponsables()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvresponsables)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_codres_inre.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVMOVDIARIOSMA - Tabla maestro movimientos diarios inventarios
        //----------------------------------------------------------------------
        #region INVMOVDIARIOSMA
        public static List<BrowerTabla> flsBuscar_Invmovdiariosma(string tcrBuscar, string tcrFiltroTabla)
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
                if (lcrEstadoRegistro == "ACTIVOS")
                {
                    lcrEstado1 = "1"; // Abierto
                    lcrEstado2 = "1"; // Abiertas
                    lcrEstado3 = "2"; // Confirmadas
                }
                else
                {
                    // Queda el estado que venia en el parametro puede ser "1" , "2" o estado  "3"
                }

                // Ejecutar consulta de datos
                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region Consulta invmovdiariosma
                    var lobConsulta = from invmovdiariosma in db.Invmovdiariosma
                                      join invalmacenmaest in db.Invalmacenmaest on invmovdiariosma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join sisestadoproces in db.Sisestadoproces on invmovdiariosma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where (invmovdiariosma.inv_secreg_inma.Contains(tcrBuscar) ||
                                             invmovdiariosma.inv_desreg_inma.Contains(tcrBuscar)) &&
                                            (invmovdiariosma.inv_codalm_inal == lcrCodigoAlmacen &&
                                            (invmovdiariosma.sis_estpro_espr == lcrEstado1 ||
                                             invmovdiariosma.sis_estpro_espr == lcrEstado2 ||
                                             invmovdiariosma.sis_estpro_espr == lcrEstado3))
                                      orderby invmovdiariosma.inv_fecges_inma descending
                                      select new BrowerTabla
                                      {
                                          campo1 = invmovdiariosma.inv_secreg_inma,
                                          campo2 = invmovdiariosma.inv_desreg_inma,
                                          campo3 = espr.sis_despro_espr,
                                          campo15 = (DateTime)invmovdiariosma.inv_fecges_inma,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }
                else
                {
                    #region Consulta invmovdiariosma
                    var lobConsulta = from invmovdiariosma in db.Invmovdiariosma
                                      join invalmacenmaest in db.Invalmacenmaest on invmovdiariosma.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join sisestadoproces in db.Sisestadoproces on invmovdiariosma.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where (invmovdiariosma.inv_codalm_inal == lcrCodigoAlmacen &&
                                            (invmovdiariosma.sis_estpro_espr == lcrEstado1 ||
                                             invmovdiariosma.sis_estpro_espr == lcrEstado2 ||
                                             invmovdiariosma.sis_estpro_espr == lcrEstado3))
                                      orderby invmovdiariosma.inv_fecges_inma descending
                                      select new BrowerTabla
                                      {
                                          campo1 = invmovdiariosma.inv_secreg_inma,
                                          campo2 = invmovdiariosma.inv_desreg_inma,
                                          campo3 = espr.sis_despro_espr,
                                          campo15 = (DateTime)invmovdiariosma.inv_fecges_inma,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }

            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invmovdiariosma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Registro", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción registro", Width = 400, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado registro", Width = 120, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha registro", Width = 120, DisplayMemberBinding = new Binding("campo15") { StringFormat = "dd/MM/yyyy" } });
        }
        // Seleccionar Registro
        public String fcrSelect_Invmovdiariosma()
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
        //    TABLA: INVMOVDIARIOSMD - Tabla Detalle movimientos diarios
        //----------------------------------------------------------------------
        #region INVMOVDIARIOSMD
        public static List<EFinvmovdiariosmd> flsBuscar_Invmovdiariosmd(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVMOVDIARIOSMD", tcrBuscar, "like", "OR", "inv_secreg_inmd,", tcrFiltroTabla);
                ObjectQuery<EFinvmovdiariosmd> lcrQuery = new ObjectQuery<EFinvmovdiariosmd>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invmovdiariosmd()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo registro", Width = 120, DisplayMemberBinding = new Binding("inv_secreg_inmd") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "", Width = 400, DisplayMemberBinding = new Binding("") });
        }
        // Seleccionar Registro
        public String fcrSelect_Invmovdiariosmd()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvmovdiariosmd)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_secreg_inmd.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVALMACEXISTEN - Tabla Maestro existencias de cada almacen 			
        //----------------------------------------------------------------------
        #region INVALMACEXISTEN
        public static List<BrowerTabla> flsBuscar_Invalmacexisten(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                // Ejecutar consulta de datos
                if (String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region Consulta invalmacexisten
                    var lobConsulta = from invalmacexisten in db.Invalmacexisten
                                      join invalmacenmaest in db.Invalmacenmaest on invalmacexisten.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invmaearticulos in db.Invmaearticulos on invalmacexisten.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                      join sisunidadmedida in db.Sisunidadmedida on invalmacexisten.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from inar in tminvmaearticulos.DefaultIfEmpty()
                                      from sium in tmsisunidadmedida.DefaultIfEmpty()
                                      where (invalmacexisten.inv_codalm_inal == tcrFiltroTabla)
                                      orderby invalmacexisten.inv_codalm_inal descending
                                      select new BrowerTabla
                                      {
                                          campo1 = inal.inv_codalm_inal,
                                          campo2 = invalmacexisten.inv_secart_inar,
                                          campo3 = inar.inv_nomart_inar,
                                          campo4 = sium.sis_desume_sium,
                                          campo21 = (int)invalmacexisten.inv_totuni_inex,
                                          campo26 = (float)invalmacexisten.inv_valing_inar,
                                          campo27 = (float)invalmacexisten.inv_valmov_inar,
                                          campo28 = (float)invalmacexisten.inv_valcos_inex,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }
                else
                {
                    #region Consulta invalmacexisten
                    var lobConsulta = from invalmacexisten in db.Invalmacexisten
                                      join invalmacenmaest in db.Invalmacenmaest on invalmacexisten.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invmaearticulos in db.Invmaearticulos on invalmacexisten.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                      join sisunidadmedida in db.Sisunidadmedida on invalmacexisten.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from inar in tminvmaearticulos.DefaultIfEmpty()
                                      from sium in tmsisunidadmedida.DefaultIfEmpty()
                                      where (invalmacexisten.inv_codalm_inal == tcrFiltroTabla) &&
                                            (invalmacexisten.inv_secart_inar.Contains(tcrBuscar) || inar.inv_nomart_inar.Contains(tcrBuscar))
                                      orderby invalmacexisten.inv_codalm_inal descending
                                      select new BrowerTabla
                                      {
                                          campo1 = inal.inv_codalm_inal,
                                          campo2 = invalmacexisten.inv_secart_inar,
                                          campo3 = inar.inv_nomart_inar,
                                          campo4 = sium.sis_desume_sium,
                                          campo21 = (int)invalmacexisten.inv_totuni_inex,
                                          campo26 = (float)invalmacexisten.inv_valing_inar,
                                          campo27 = (float)invalmacexisten.inv_valmov_inar,
                                          campo28 = (float)invalmacexisten.inv_valcos_inex,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion

                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invalmacexisten()
        {
            //gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo Almacen", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo Articulo", Width = 120, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Articulo", Width = 400, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Medida de Almacenamiento", Width = 180, DisplayMemberBinding = new Binding("campo4") });
            //gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion Contenedor", Width = 120, DisplayMemberBinding = new Binding("campo5") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Existencias", Width = 150, DisplayMemberBinding = new Binding("campo21") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Valor de Ingreso", Width = 130, DisplayMemberBinding = new Binding("campo26") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Valor de Salida", Width = 130, DisplayMemberBinding = new Binding("campo27") });
            //gobGridView.Columns.Add(new GridViewColumn { Header = "Valor Total Costo", Width = 120, DisplayMemberBinding = new Binding("campo28") });
        }
        // Seleccionar Registro
        public String fcrSelect_Invalmacexisten()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerTabla)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo2.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVPERIODOMAEST - Maestro gestion periodos inventario
        //----------------------------------------------------------------------
        #region INVPERIODOMAEST
        public static List<EFinvperiodomaest> flsBuscar_Invperiodomaest(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVPERIODOMAEST", tcrBuscar, "like", "OR", "inv_codper_inpe,inv_desper_inpe", tcrFiltroTabla);
                ObjectQuery<EFinvperiodomaest> lcrQuery = new ObjectQuery<EFinvperiodomaest>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invperiodomaest()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código periodo", Width = 120, DisplayMemberBinding = new Binding("inv_codper_inpe") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion", Width = 400, DisplayMemberBinding = new Binding("inv_desper_inpe") });
        }
        // Seleccionar Registro
        public String fcrSelect_Invperiodomaest()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvperiodomaest)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_codper_inpe.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVAJUSTESMAEMA - Maestro ajustes de inventario
        //----------------------------------------------------------------------
        #region INVAJUSTESMAEMA
        public static List<BrowerTabla> flsBuscar_Invajustesmaema(string tcrBuscar, string tcrFiltroTabla)
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
                if (lcrEstadoRegistro == "ACTIVOS")
                {
                    lcrEstado1 = "1"; // Abierto
                    lcrEstado2 = "1"; // Abiertas
                    lcrEstado3 = "2"; // Confirmadas
                }
                else
                {
                    // Queda el estado que venia en el parametro puede ser "1" , "2" o estado  "3"
                }
                // Ejecutar consulta de datos
                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region Consulta invajustesmaema
                    var lobConsulta = from invajustesmaema in db.Invajustesmaema
                                      join invalmacenmaest in db.Invalmacenmaest on invajustesmaema.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invajusteconcep in db.Invajusteconcep on invajustesmaema.inv_conaju_incp equals invajusteconcep.inv_conaju_incp into tminvajusteconcep
                                      join sisestadoproces in db.Sisestadoproces on invajustesmaema.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from incp in tminvajusteconcep.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where (invajustesmaema.inv_secreg_inja.Contains(tcrBuscar) ||
                                             invajustesmaema.inv_desaju_inja.Contains(tcrBuscar)) &&
                                            (invajustesmaema.inv_codalm_inal == lcrCodigoAlmacen &&
                                            (invajustesmaema.sis_estpro_espr == lcrEstado1 ||
                                             invajustesmaema.sis_estpro_espr == lcrEstado2 ||
                                             invajustesmaema.sis_estpro_espr == lcrEstado3))
                                      orderby invajustesmaema.inv_fecges_inja descending
                                      select new BrowerTabla
                                      {
                                          campo1 = invajustesmaema.inv_secreg_inja,
                                          campo2 = invajustesmaema.inv_desaju_inja,
                                          campo3 = espr.sis_despro_espr,
                                          campo15 = (DateTime)invajustesmaema.inv_fecges_inja,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }
                else
                {
                    #region Consulta invajustesmaema
                    var lobConsulta = from invajustesmaema in db.Invajustesmaema
                                      join invalmacenmaest in db.Invalmacenmaest on invajustesmaema.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invajusteconcep in db.Invajusteconcep on invajustesmaema.inv_conaju_incp equals invajusteconcep.inv_conaju_incp into tminvajusteconcep
                                      join sisestadoproces in db.Sisestadoproces on invajustesmaema.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from incp in tminvajusteconcep.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where (invajustesmaema.inv_codalm_inal == lcrCodigoAlmacen &&
                                            (invajustesmaema.sis_estpro_espr == lcrEstado1 ||
                                             invajustesmaema.sis_estpro_espr == lcrEstado2 ||
                                             invajustesmaema.sis_estpro_espr == lcrEstado3))
                                      orderby invajustesmaema.inv_fecges_inja descending
                                      select new BrowerTabla
                                      {
                                          campo1 = invajustesmaema.inv_secreg_inja,
                                          campo2 = invajustesmaema.inv_desaju_inja,
                                          campo3 = espr.sis_despro_espr,
                                          campo15 = (DateTime)invajustesmaema.inv_fecges_inja,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }

            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invajustesmaema()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Registro", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción registro", Width = 400, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado registro", Width = 120, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha registro", Width = 120, DisplayMemberBinding = new Binding("campo15") { StringFormat = "dd/MM/yyyy" } });
        }
        // Seleccionar Registro
        public String fcrSelect_Invajustesmaema()
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
        //    TABLA: INVAJUSTESMAEMD - Registros tipo detalles para ajustes de inventario
        //----------------------------------------------------------------------
        #region INVAJUSTESMAEMD
        public static List<EFinvajustesmaemd> flsBuscar_Invajustesmaemd(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("INVAJUSTESMAEMD", tcrBuscar, "like", "OR", "inv_secreg_injd,", tcrFiltroTabla);
                ObjectQuery<EFinvajustesmaemd> lcrQuery = new ObjectQuery<EFinvajustesmaemd>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Invajustesmaemd()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo registro", Width = 120, DisplayMemberBinding = new Binding("inv_secreg_injd") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "", Width = 400, DisplayMemberBinding = new Binding("") });
        }
        // Seleccionar Registro
        public String fcrSelect_Invajustesmaemd()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFinvajustesmaemd)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.inv_secreg_injd.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: INVALMACEXISTEN-SERV-IPS - Tabla Maestro existencias de cada almacen relacionados con servicios IPS
        //----------------------------------------------------------------------
        #region INVALMACEXISTEN-SERV-IPS
        public static List<BrowerTabla> flsBuscar_InvalmacexistenIps(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                // Ejecutar consulta de datos
                if (String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region Consulta invalmacexisten
                    var lobConsulta = from invalmacexisten in db.Invalmacexisten
                                      join invalmacenmaest in db.Invalmacenmaest on invalmacexisten.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invmaearticulos in db.Invmaearticulos on invalmacexisten.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                      join sisunidadmedida in db.Sisunidadmedida on invalmacexisten.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from inar in tminvmaearticulos.DefaultIfEmpty()
                                      from sium in tmsisunidadmedida.DefaultIfEmpty()
                                      where (invalmacexisten.inv_codalm_inal == tcrFiltroTabla && inar.inv_gesips_inar == "1")
                                      orderby invalmacexisten.inv_codalm_inal descending
                                      select new BrowerTabla
                                      {
                                          campo1 = inal.inv_codalm_inal,
                                          campo2 = invalmacexisten.inv_secart_inar,
                                          campo3 = inar.inv_codaux_inar,
                                          campo4 = inar.far_codcum_famd,
                                          campo5 = inar.inv_nomart_inar,
                                          campo6 = sium.sis_desume_sium,
                                          campo21 = (int)invalmacexisten.inv_totuni_inex,
                                          campo26 = (float)invalmacexisten.inv_valing_inar,
                                          campo27 = (float)invalmacexisten.inv_valmov_inar,
                                          campo28 = (float)invalmacexisten.inv_valcos_inex,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }
                else
                {
                    #region Consulta invalmacexisten
                    var lobConsulta = from invalmacexisten in db.Invalmacexisten
                                      join invalmacenmaest in db.Invalmacenmaest on invalmacexisten.inv_codalm_inal equals invalmacenmaest.inv_codalm_inal into tminvalmacenmaest
                                      join invmaearticulos in db.Invmaearticulos on invalmacexisten.inv_secart_inar equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                                      join sisunidadmedida in db.Sisunidadmedida on invalmacexisten.sis_codume_sium equals sisunidadmedida.sis_codume_sium into tmsisunidadmedida
                                      from inal in tminvalmacenmaest.DefaultIfEmpty()
                                      from inar in tminvmaearticulos.DefaultIfEmpty()
                                      from sium in tmsisunidadmedida.DefaultIfEmpty()
                                      where (invalmacexisten.inv_codalm_inal == tcrFiltroTabla && inar.inv_gesips_inar == "1") &&
                                            (invalmacexisten.inv_secart_inar.Contains(tcrBuscar) || 
                                             inar.inv_nomart_inar.Contains(tcrBuscar) ||
                                             inar.fcm_coddig_mant.Contains(tcrBuscar) ||
                                             inar.far_codcum_famd.Contains(tcrBuscar))
                                      orderby invalmacexisten.inv_codalm_inal descending
                                      select new BrowerTabla
                                      {
                                          campo1 = inal.inv_codalm_inal,
                                          campo2 = invalmacexisten.inv_secart_inar,
                                          campo3 = inar.inv_codaux_inar,
                                          campo4 = inar.far_codcum_famd,
                                          campo5 = inar.inv_nomart_inar,
                                          campo6 = sium.sis_desume_sium,
                                          campo21 = (int)invalmacexisten.inv_totuni_inex,
                                          campo26 = (float)invalmacexisten.inv_valing_inar,
                                          campo27 = (float)invalmacexisten.inv_valmov_inar,
                                          campo28 = (float)invalmacexisten.inv_valcos_inex,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion

                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_InvalmacexistenIps()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo articulo",    Width = 120, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo digitación",  Width = 120, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo CUM",         Width = 120, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Medicamento", Width = 400, DisplayMemberBinding = new Binding("campo5") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Medida",             Width = 180, DisplayMemberBinding = new Binding("campo6") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Existencias",        Width = 150, DisplayMemberBinding = new Binding("campo21") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Valor Ingreso",      Width = 130, DisplayMemberBinding = new Binding("campo26") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Valor Salida",       Width = 130, DisplayMemberBinding = new Binding("campo27") });
        }
        // Seleccionar Registro
        public String fcrSelect_InvalmacexistenIps()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerTabla)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo2.Trim();
            }
            return lcrReturn;
        }
        public String fcrSelect_InvalmacexistenIpsAux()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerTabla)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo3.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FAREXPEDMEDICMD - Detalles expediente medicamentos INVIMA según concentracion
        //----------------------------------------------------------------------
        #region FAREXPEDMEDICMD
        public static List<EFfarexpedmedicmd> flsBuscar_Farexpedmedicmd(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FAREXPEDMEDICMD", tcrBuscar, "like", "OR", "far_secreg_famd,far_precom_famd", tcrFiltroTabla);
                ObjectQuery<EFfarexpedmedicmd> lcrQuery = new ObjectQuery<EFfarexpedmedicmd>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Farexpedmedicmd()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo CUM",     Width = 120, DisplayMemberBinding = new Binding("far_codcum_famd") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Presentación",   Width = 400, DisplayMemberBinding = new Binding("far_precom_famd") });
        }
        // Seleccionar Registro
        public String fcrSelect_Farexpedmedicmd()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfarexpedmedicmd)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.far_secreg_famd.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}
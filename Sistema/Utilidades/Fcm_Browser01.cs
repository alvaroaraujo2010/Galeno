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
    public class FCM_Browser01 : ViewModelBase
    {
        //-----------------------------------
        //- Clase Cargar Browser de la tabla
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerTabla
        {
            public BrowerTabla() { }
            public string campo1 { get; set; }
            public string campo2 { get; set; }
            public string campo3 { get; set; }
            public string campo4 { get; set; }
            public string campo5 { get; set; }
            public string campo6 { get; set; }
            public string campo7 { get; set; }
            public string campo8 { get; set; }
            public string campo9 { get; set; }
            public string campo10 { get; set; }
            public string campo11 { get; set; }
            public string campo12 { get; set; }
            public string campo13 { get; set; }
            public string campo14 { get; set; }
            public DateTime campo15 { get; set; }
            public DateTime campo16 { get; set; }
            public DateTime campo17 { get; set; }
        }
        #endregion
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
                case "FCMMANSERVICIPS":
                    fcvAddColGrid_Fcmmanservicips();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmmanservicips(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMMANSERVICIPSAUX":
                    fcvAddColGrid_Fcmmanservicips();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmmanservicips(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMCENPRODUCCIO":
                    fcvAddColGrid_Fcmcenproduccio();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmcenproduccio(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMMANSERVICIOS":
                    fcvAddColGrid_Fcmmanservicios();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmmanservicios(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMMANSERVICIOSIU":
                    fcvAddColGrid_Fcmmanservicios();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmmanservicios(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMACTQUIRURGIC":
                    fcvAddColGrid_Fcmactquirurgic();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmactquirurgic(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMDESCUEAUTORI":
                    fcvAddColGrid_Fcmdescueautori();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmdescueautori(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMDESCUEAUTORIAP":
                    fcvAddColGrid_FcmdescueautoriAP();
                    gobDataGrid.ItemsSource = flsBuscar_FcmdescueautoriAP(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMMANSERVICIOS-MED":
                    fcvAddColGrid_FcmmanserviciosMed();
                    gobDataGrid.ItemsSource = flsBuscar_FcmserviciosipsMed(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMGRQUIRURGICO":
                    fcvAddColGrid_Fcmgrquirurgico();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmgrquirurgico(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMMANTARIFARIO":
                    fcvAddColGrid_Fcmmantarifario();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmmantarifario(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMCUENTACOBRMS":
                    fcvAddColGrid_Fcmcuentacobrms();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmcuentacobrms(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMSOATMANUALMA":
                    fcvAddColGrid_Fcmsoatmanualma();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmsoatmanualma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMFEUNSPSCDPRODU":
                    fcvAddColGrid_Fcmfeunspscdprodu();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmfeunspscdprodu(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMFEMAESRAZSOCMA-NIT":
                    FcvAddColGrid_Fcmfemaesrazsocma();
                    gobDataGrid.ItemsSource = FlsBuscar_Fcmfemaesrazsocma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMFEMAESRAZSOCMA":
                    FcvAddColGrid_Fcmfemaesrazsocma();
                    gobDataGrid.ItemsSource = FlsBuscar_Fcmfemaesrazsocma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMFEMAESFACTEFMA-ND":
                    FcvAddColGrid_Fcmfemaesfactefma();
                    gobDataGrid.ItemsSource = FlsBuscar_Fcmfemaesfactefma(gcrFiltroDatos, gcrFiltroTabla).DefaultView;
                    break;

                case "FCMFEMAESFACTEFMA":
                    FcvAddColGrid_Fcmfemaesfactefma();
                    gobDataGrid.ItemsSource = FlsBuscar_Fcmfemaesfactefma(gcrFiltroDatos, gcrFiltroTabla).DefaultView;
                    break;

                case "FCMMANSERVICATE":
                    fcvAddColGrid_Fcmmanservicate();
                    gobDataGrid.ItemsSource = flsBuscar_Fcmmanservicate(gcrFiltroDatos, gcrFiltroTabla);
                    break;
            }

        }
        #endregion
        //----------------------------------------------------------------------
        //    Función: Buscar()
        //----------------------------------------------------------------------
        #region fcvBuscar: Buscar Registro
        public void FcvBuscar(ListView tobDataGrid, string tcrTabla, string tcrFiltroDatos, string tcrFiltroTabla)
        {
            gcrFiltroDatos = tcrFiltroDatos;
            gcrFiltroTabla = tcrFiltroTabla;
            switch (tcrTabla.ToUpper())
            {
                case "FCMMANSERVICIPS":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmmanservicips(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMMANSERVICIPSAUX":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmmanservicips(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMCENPRODUCCIO":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmcenproduccio(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMMANSERVICIOS":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmmanservicios(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMMANSERVICIOSIU":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmmanservicios(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMACTQUIRURGIC":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmactquirurgic(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMDESCUEAUTORI":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmdescueautori(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMDESCUEAUTORIAP":
                    tobDataGrid.ItemsSource = flsBuscar_FcmdescueautoriAP(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMMANSERVICIOS-MED":
                    tobDataGrid.ItemsSource = flsBuscar_FcmserviciosipsMed(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMGRQUIRURGICO":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmgrquirurgico(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMMANTARIFARIO":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmmantarifario(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMCUENTACOBRMS":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmcuentacobrms(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMSOATMANUALMA":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmsoatmanualma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMFEUNSPSCDPRODU":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmfeunspscdprodu(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMFEMAESRAZSOCMA-NIT":
                    tobDataGrid.ItemsSource = FlsBuscar_Fcmfemaesrazsocma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMFEMAESRAZSOCMA":
                    tobDataGrid.ItemsSource = FlsBuscar_Fcmfemaesrazsocma(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "FCMFEMAESFACTEFMA-ND":
                    tobDataGrid.ItemsSource = FlsBuscar_Fcmfemaesfactefma(gcrFiltroDatos, gcrFiltroTabla).DefaultView;
                    break;

                case "FCMFEMAESFACTEFMA":
                    tobDataGrid.ItemsSource = FlsBuscar_Fcmfemaesfactefma(gcrFiltroDatos, gcrFiltroTabla).DefaultView;
                    break;

                case "FCMMANSERVICATE":
                    tobDataGrid.ItemsSource = flsBuscar_Fcmmanservicate(gcrFiltroDatos, gcrFiltroTabla);
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
                case "FCMMANSERVICIPS":
                    lcrReturnCodigo = fcrSelect_Fcmmanservicips("FCMMANSERVICIPS");
                    break;

                case "FCMMANSERVICIPSAUX":
                    lcrReturnCodigo = fcrSelect_Fcmmanservicips("FCMMANSERVICIPSAUX");
                    break;

                case "FCMCENPRODUCCIO":
                    lcrReturnCodigo = fcrSelect_Fcmcenproduccio();
                    break;

                case "FCMMANSERVICIOS":
                    lcrReturnCodigo = fcrSelect_Fcmmanservicios(false);
                    break;

                case "FCMMANSERVICIOSIU":
                    lcrReturnCodigo = fcrSelect_Fcmmanservicios(true);
                    break;

                case "FCMACTQUIRURGIC":
                    lcrReturnCodigo = fcrSelect_Fcmactquirurgic();
                    break;

                case "FCMDESCUEAUTORI":
                    lcrReturnCodigo = fcrSelect_Fcmdescueautori();
                    break;

                case "FCMDESCUEAUTORIAP":
                    lcrReturnCodigo = fcrSelect_FcmdescueautoriAP();
                    break;

                case "FCMMANSERVICIOS-MED":
                    lcrReturnCodigo = fcrSelect_FcmmanserviciosMed();
                    break;

                case "FCMGRQUIRURGICO":
                    lcrReturnCodigo = fcrSelect_Fcmgrquirurgico();
                    break;

                case "FCMMANTARIFARIO":
                    lcrReturnCodigo = fcrSelect_Fcmmantarifario();
                    break;

                case "FCMCUENTACOBRMS":
                    lcrReturnCodigo = fcrSelect_Fcmcuentacobrms();
                    break;

                case "FCMSOATMANUALMA":
                    lcrReturnCodigo = fcrSelect_Fcmsoatmanualma();
                    break;

                case "FCMFEUNSPSCDPRODU":
                    lcrReturnCodigo = fcrSelect_Fcmfeunspscdprodu();
                    break;

                case "FCMFEMAESRAZSOCMA-NIT":
                    lcrReturnCodigo = FcrSelect_Fcmfemaesrazsocma("NIT");
                    break;

                case "FCMFEMAESRAZSOCMA":
                    lcrReturnCodigo = FcrSelect_Fcmfemaesrazsocma("ID");
                    break;

                case "FCMFEMAESFACTEFMA-ND":
                    lcrReturnCodigo = FcrSelect_Fcmfemaesfactefma("ND");
                    break;

                case "FCMFEMAESFACTEFMA":
                    lcrReturnCodigo = FcrSelect_Fcmfemaesfactefma("ID");
                    break;

                case "FCMMANSERVICATE":
                    lcrReturnCodigo = fcrSelect_Fcmmanservicate();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMMANSERVICIPS - Maestro de servicios habilitados para la IPS
        //----------------------------------------------------------------------
        #region FCMMANSERVICIPS
        public static List<EFfcmmanservicips> flsBuscar_Fcmmanservicips(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMMANSERVICIPS", tcrBuscar, "like", "OR", "fcm_idesec_sips,fcm_coddig_mant,fcm_desser_sips,fcm_codser_sips", tcrFiltroTabla);
                ObjectQuery<EFfcmmanservicips> lcrQuery = new ObjectQuery<EFfcmmanservicips>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmmanservicips()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Servicio", Width = 100, DisplayMemberBinding = new Binding("fcm_idesec_sips") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código digitación", Width = 100, DisplayMemberBinding = new Binding("fcm_coddig_mant") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código tarifario", Width = 100, DisplayMemberBinding = new Binding("fcm_codser_sips") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre servicio", Width = 650, DisplayMemberBinding = new Binding("fcm_desser_sips") });
        }
        // Seleccionar Registro
        public string fcrSelect_Fcmmanservicips(String tcrKey)
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmmanservicips)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = tcrKey == "FCMMANSERVICIPSAUX" ? objReg.fcm_coddig_mant.Trim() : objReg.fcm_idesec_sips.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMCENPRODUCCIO - Centros de produccion asistenciales
        //----------------------------------------------------------------------
        #region FCMCENPRODUCCIO
        public static List<EFfcmcenproduccio> flsBuscar_Fcmcenproduccio(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMCENPRODUCCIO", tcrBuscar, "like", "OR", "fcm_codcpr_cpro,fcm_descpr_cpro", tcrFiltroTabla);
                ObjectQuery<EFfcmcenproduccio> lcrQuery = new ObjectQuery<EFfcmcenproduccio>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmcenproduccio()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo centro producción", Width = 120, DisplayMemberBinding = new Binding("fcm_codcpr_cpro") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre centro producción", Width = 400, DisplayMemberBinding = new Binding("fcm_descpr_cpro") });
        }
        // Seleccionar Registro
        public string fcrSelect_Fcmcenproduccio()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmcenproduccio)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.fcm_codcpr_cpro.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMMANSERVICIOS - Manual ventas de servicios medicos
        //----------------------------------------------------------------------
        #region FCMMANSERVICIOS
        public static List<EFfcmmanservicios> flsBuscar_Fcmmanservicios(string tcrBuscar,string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMMANSERVICIOS", tcrBuscar, "like", "OR", "fcm_idesec_mant,fcm_coddig_mant,fcm_codser_mant,fcm_desser_mant", tcrFiltroTabla);
                ObjectQuery<EFfcmmanservicios> lcrQuery = new ObjectQuery<EFfcmmanservicios>(lcrConsulta, db);
                return lcrQuery.ToList(); 
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmmanservicios()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código Digitación", Width = 120, DisplayMemberBinding = new Binding("fcm_coddig_mant") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Servicio", Width = 130, DisplayMemberBinding = new Binding("fcm_codser_mant") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre servicio", Width = 760, DisplayMemberBinding = new Binding("fcm_desser_mant") });
        }
        // Seleccionar Registro
        public string fcrSelect_Fcmmanservicios(bool tlgDevolverIu)
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmmanservicios)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                if (tlgDevolverIu == false)
                {
                    lcrReturn = objReg.fcm_idesec_mant.Trim();
                }
                else 
                {
                    lcrReturn = objReg.fcm_coddig_mant.Trim();
                }
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMACTQUIRURGIC - Forma de realizacion acto quirurgico
        //----------------------------------------------------------------------
        #region FCMACTQUIRURGIC
        public static List<EFfcmactquirurgic> flsBuscar_Fcmactquirurgic(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMACTQUIRURGIC", tcrBuscar, "like", "OR", "fcm_codaqx_aqir,fcm_desaqx_aqir", tcrFiltroTabla);
                ObjectQuery<EFfcmactquirurgic> lcrQuery = new ObjectQuery<EFfcmactquirurgic>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmactquirurgic()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo Acto", Width = 120, DisplayMemberBinding = new Binding("fcm_codaqx_aqir") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion realizacion", Width = 400, DisplayMemberBinding = new Binding("fcm_desaqx_aqir") });
        }
        // Seleccionar Registro
        public string fcrSelect_Fcmactquirurgic()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmactquirurgic)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.fcm_codaqx_aqir.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMDESCUEAUTORI - Maestro para registrar los descuentos solicitados y  autoriz
        //----------------------------------------------------------------------
        #region FCMDESCUEAUTORI
        //-----------------------------------
        //- Clase Cargar Browser de la tabla
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerAutorizacion
        {
            public BrowerAutorizacion() { }
            public string campo1 { get; set; }
            public string campo2 { get; set; }
            public string campo3 { get; set; }
            public string campo4 { get; set; }
            public DateTime campo5 { get; set; }
            public float campo6 { get; set; }
            public float campo7 { get; set; }
            public float campo8 { get; set; }
            public float campo9 { get; set; }
            public string campo10 { get; set; }
            public string campo11 { get; set; }
            public string campo12 { get; set; }
            public string campo13 { get; set; }
            public string campo14 { get; set; }
        }
        #endregion
        public static List<BrowerAutorizacion> flsBuscar_Fcmdescueautori(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                var lcrEstado1 = tcrFiltroTabla;
                var lcrEstado2 = lcrEstado1; 
                var lcrEstado3 = lcrEstado1; 

                if (lcrEstado1 == "TODOS" || String.IsNullOrWhiteSpace(lcrEstado1))
                {
                    lcrEstado1 = "1"; // Abierto
                    lcrEstado2 = "2"; // Cerrado
                    lcrEstado3 = "3"; // Anulado
                }

                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {

                    var lobConsulta = from fcmdescueautori in db.Fcmdescueautori
                                      join siausuarioatend in db.Siausuarioatend on fcmdescueautori.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      where (fcmdescueautori.fcm_autdes_ades.Contains(tcrBuscar) || 
                                             fcmdescueautori.sia_nroide_usua.Contains(tcrBuscar) ||
                                             usua.sia_nomusu_usua.Contains(tcrBuscar)) &&
                                            (fcmdescueautori.fcm_estaut_ades == lcrEstado1 || 
                                             fcmdescueautori.fcm_estaut_ades == lcrEstado2 || 
                                             fcmdescueautori.fcm_estaut_ades == lcrEstado3)
                                      select new BrowerAutorizacion
                                      {
                                          campo1 = fcmdescueautori.fcm_autdes_ades,
                                          campo2 = fcmdescueautori.adm_secadm_rgad,
                                          campo3 = fcmdescueautori.sia_nroide_usua,
                                          campo4 = usua.sia_nomusu_usua,
                                          campo5 = (DateTime)fcmdescueautori.fcm_fecsol_ades,
                                          campo6 = (float)fcmdescueautori.fcm_valref_dfac,
                                          campo7 = (float)fcmdescueautori.fcm_valdes_dfac,
                                          campo8 = (float)fcmdescueautori.fcm_pordes_dfac,
                                          campo9 = (float)fcmdescueautori.fcm_valefe_dfac,
                                          campo10 = fcmdescueautori.fcm_estaut_ades,
                                      };
                    return lobConsulta.Take(200).ToList();
                }
                else
                {
                    var lobConsulta = from fcmdescueautori in db.Fcmdescueautori
                                      join siausuarioatend in db.Siausuarioatend on fcmdescueautori.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      where fcmdescueautori.fcm_estaut_ades == lcrEstado1 ||
                                            fcmdescueautori.fcm_estaut_ades == lcrEstado2 ||
                                            fcmdescueautori.fcm_estaut_ades == lcrEstado3
                                      select new BrowerAutorizacion
                                      {
                                          campo1 = fcmdescueautori.fcm_autdes_ades,
                                          campo2 = fcmdescueautori.adm_secadm_rgad,
                                          campo3 = fcmdescueautori.sia_nroide_usua,
                                          campo4 = usua.sia_nomusu_usua,
                                          campo5 = (DateTime)fcmdescueautori.fcm_fecsol_ades,
                                          campo6 = (float)fcmdescueautori.fcm_valref_dfac,
                                          campo7 = (float)fcmdescueautori.fcm_valdes_dfac,
                                          campo8 = (float)fcmdescueautori.fcm_pordes_dfac,
                                          campo9 = (float)fcmdescueautori.fcm_valefe_dfac,
                                          campo10 = fcmdescueautori.fcm_estaut_ades,
                                      };
                    return lobConsulta.Take(200).ToList();

                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmdescueautori()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Autorización  ", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Admisión      ", Width = 120, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificacion", Width = 120, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Usuario", Width = 400, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha Solicitud", Width = 120, DisplayMemberBinding = new Binding("campo5") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Cobro", Width = 120, DisplayMemberBinding = new Binding("campo6") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descuento", Width = 120, DisplayMemberBinding = new Binding("campo7") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Efectivo", Width = 120, DisplayMemberBinding = new Binding("campo9") });
        }
        // Seleccionar Registro
        public string fcrSelect_Fcmdescueautori()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerAutorizacion)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo1.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMDESCUEAUTORI - Maestro para registrar los descuentos solicitados para una admision 
        //----------------------------------------------------------------------
        #region FCMDESCUEAUTORI - AP
        public static List<BrowerAutorizacion> flsBuscar_FcmdescueautoriAP(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                var lobConsulta = from fcmdescueautori in db.Fcmdescueautori
                                  join siausuarioatend in db.Siausuarioatend on fcmdescueautori.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                  from usua in tmsiausuarioatend.DefaultIfEmpty()
                                  where fcmdescueautori.adm_secadm_rgad == tcrFiltroTabla && (fcmdescueautori.fcm_estaut_ades == "1" || fcmdescueautori.fcm_estaut_ades == "2")
                                  select new BrowerAutorizacion
                                  {
                                      campo1 = fcmdescueautori.fcm_autdes_ades,
                                      campo2 = fcmdescueautori.adm_secadm_rgad,
                                      campo3 = fcmdescueautori.sia_nroide_usua,
                                      campo4 = usua.sia_nomusu_usua,
                                      campo5 = (DateTime)fcmdescueautori.fcm_fecsol_ades,
                                      campo6 = (float)fcmdescueautori.fcm_valref_dfac,
                                      campo7 = (float)fcmdescueautori.fcm_valdes_dfac,
                                      campo8 = (float)fcmdescueautori.fcm_pordes_dfac,
                                      campo9 = (float)fcmdescueautori.fcm_valefe_dfac,
                                      campo10 = fcmdescueautori.fcm_estaut_ades,
                                  };
                return lobConsulta.Take(200).ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_FcmdescueautoriAP()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Autorización  ", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Admisión      ", Width = 120, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificacion", Width = 120, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Usuario", Width = 400, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha Solicitud", Width = 120, DisplayMemberBinding = new Binding("campo5") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Cobro", Width = 120, DisplayMemberBinding = new Binding("campo6") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descuento", Width = 120, DisplayMemberBinding = new Binding("campo7") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Efectivo", Width = 120, DisplayMemberBinding = new Binding("campo9") });
        }
        // Seleccionar Registro
        public string fcrSelect_FcmdescueautoriAP()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerAutorizacion)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo1.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMMANSERVICIOS-MED - Servicios solo medicamentos
        //----------------------------------------------------------------------
        #region FCMMANSERVICIOS-MED
        public static List<BrowerTabla> flsBuscar_FcmserviciosipsMed(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region Consulta
                    var lcrQuery = from fcmmanservicios in db.Fcmmanservicios
                                   join fcmserviciosips in db.Fcmmanservicips on fcmmanservicios.fcm_idesec_sips equals fcmserviciosips.fcm_idesec_sips
                                   where fcmmanservicios.fcm_codman_mans.Equals(tcrFiltroTabla) &&
                                        (fcmmanservicios.fcm_coddig_mant.Contains(tcrBuscar) ||
                                         fcmmanservicios.fcm_codser_mant.Contains(tcrBuscar) || 
                                         fcmmanservicios.fcm_desser_mant.Contains(tcrBuscar)) &&
                                         (fcmserviciosips.sia_codrip_trip.Equals("12") ||
                                         fcmserviciosips.sia_codrip_trip.Equals("13"))
                                   select new BrowerTabla
                                   {
                                       campo1 = fcmmanservicios.fcm_codser_mant,
                                       campo2 = fcmmanservicios.fcm_coddig_mant,
                                       campo3 = fcmmanservicios.fcm_desser_mant,
                                       campo4 = fcmserviciosips.sia_codrip_trip,
                                       campo5 = fcmmanservicios.fcm_codman_mans,
                                   };
                    return lcrQuery.ToList();
                    #endregion
                }
                else
                {
                    #region Consulta
                    var lcrQuery = from fcmmanservicios in db.Fcmmanservicios
                                   join fcmserviciosips in db.Fcmmanservicips on fcmmanservicios.fcm_idesec_sips equals fcmserviciosips.fcm_idesec_sips
                                   where fcmmanservicios.fcm_codman_mans.Equals(tcrFiltroTabla) &&
                                         (fcmserviciosips.sia_codrip_trip.Equals("12") ||
                                         fcmserviciosips.sia_codrip_trip.Equals("13"))
                                   select new BrowerTabla
                                   {
                                       campo1 = fcmmanservicios.fcm_codser_mant,
                                       campo2 = fcmmanservicios.fcm_coddig_mant,
                                       campo3 = fcmmanservicios.fcm_desser_mant,
                                       campo4 = fcmserviciosips.sia_codrip_trip,
                                       campo5 = fcmmanservicios.fcm_codman_mans,
                                   };
                    return lcrQuery.ToList();
                    #endregion
                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_FcmmanserviciosMed()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 65, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Digitación", Width = 90, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Servicio", Width = 470, DisplayMemberBinding = new Binding("campo3") });
        }
        // Seleccionar Registro
        public string fcrSelect_FcmmanserviciosMed()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerTabla)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo2.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMGRQUIRURGICO - Archivo para grupo quirurgicos
        //----------------------------------------------------------------------
        #region FCMGRQUIRURGICO
        public static List<EFfcmgrquirurgico> flsBuscar_Fcmgrquirurgico(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMGRQUIRURGICO", tcrBuscar, "like", "OR", "fcm_codgqx_grqx,fcm_desgqx_grqx", tcrFiltroTabla);
                ObjectQuery<EFfcmgrquirurgico> lcrQuery = new ObjectQuery<EFfcmgrquirurgico>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmgrquirurgico()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código Grupo", Width = 120, DisplayMemberBinding = new Binding("fcm_codgqx_grqx") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción Grupo", Width = 400, DisplayMemberBinding = new Binding("fcm_desgqx_grqx") });
        }
        // Seleccionar Registro
        public string fcrSelect_Fcmgrquirurgico()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmgrquirurgico)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.fcm_codgqx_grqx.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMMANTARIFARIO - Maestro manuales tarifarios
        //----------------------------------------------------------------------
        #region FCMMANTARIFARIO
        public static List<EFfcmmantarifario> flsBuscar_Fcmmantarifario(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMMANTARIFARIO", tcrBuscar, "like", "OR", "fcm_codman_mans,fcm_desman_mans", tcrFiltroTabla);
                ObjectQuery<EFfcmmantarifario> lcrQuery = new ObjectQuery<EFfcmmantarifario>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmmantarifario()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("fcm_codman_mans") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Manual tarifario", Width = 400, DisplayMemberBinding = new Binding("fcm_desman_mans") });
        }
        // Seleccionar Registro
        public string fcrSelect_Fcmmantarifario()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmmantarifario)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.fcm_codman_mans.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMCUENTACOBRMS - Maestro de facturas - Cuentas de cobro facturación
        //----------------------------------------------------------------------
        #region FCMCUENTACOBRMS
        public static List<BrowerTabla> flsBuscar_Fcmcuentacobrms(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                var lcrEstado1 = tcrFiltroTabla;
                var lcrEstado2 = lcrEstado1;
                var lcrEstado3 = lcrEstado1; 

                if (tcrFiltroTabla == "TODOS")
                {
                    lcrEstado1 = "1"; // Abierto
                    lcrEstado2 = "2"; // Confirmadas
                    lcrEstado3 = "3"; // Anulado
                }
                if (tcrFiltroTabla == "ACTIVAS")
                {
                    lcrEstado1 = "1"; // Abierto
                    lcrEstado2 = "1"; // Abiertas
                    lcrEstado3 = "2"; // Confirmadas
                }
                else 
                {
                    // Queda el estado que venia en el parametro
                }

                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region Consulta
                    var lobConsulta = from fcmcuentacobrms in db.Fcmcuentacobrms
                                      join ctomaescontrato in db.Ctomaescontrato on fcmcuentacobrms.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                      join siatablaeps in db.Siatablaeps on fcmcuentacobrms.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      from cont in tmctomaescontrato.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      where (fcmcuentacobrms.fcm_secreg_mfcb.Contains(tcrBuscar) ||
                                            fcmcuentacobrms.fcm_descue_mfcb.Contains(tcrBuscar) ||
                                            fcmcuentacobrms.fcm_notcue_mfcb.Contains(tcrBuscar) ||
                                            fcmcuentacobrms.cto_nrocon_cont.Contains(tcrBuscar) ||
                                            fcmcuentacobrms.sia_codeps_teps.Contains(tcrBuscar) ||
                                            teps.sia_deseps_teps.Contains(tcrBuscar)) &&
                                        (fcmcuentacobrms.sis_estpro_espr == lcrEstado1 || 
                                         fcmcuentacobrms.sis_estpro_espr == lcrEstado2 || 
                                         fcmcuentacobrms.sis_estpro_espr == lcrEstado3)
                                      orderby fcmcuentacobrms.fcm_fecfac_mfac descending
                                      select new BrowerTabla
                                      {
                                          campo1 = fcmcuentacobrms.fcm_secreg_mfcb,
                                          campo2 = fcmcuentacobrms.fcm_numfac_mfac,
                                          campo15 = (DateTime)fcmcuentacobrms.fcm_fecfac_mfac,
                                          campo3 = fcmcuentacobrms.fcm_descue_mfcb,
                                          campo4 = fcmcuentacobrms.fcm_notcue_mfcb,
                                          campo5 = fcmcuentacobrms.cto_seccon_cont,
                                          campo6 = fcmcuentacobrms.cto_nrocon_cont,
                                          campo7 = fcmcuentacobrms.sia_codeps_teps,
                                          campo8 = cont.cto_descon_cont,
                                          campo9 = teps.sia_deseps_teps,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }
                else
                {
                    #region Consulta
                    var lobConsulta = from fcmcuentacobrms in db.Fcmcuentacobrms
                                      join ctomaescontrato in db.Ctomaescontrato on fcmcuentacobrms.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                      join siatablaeps in db.Siatablaeps on fcmcuentacobrms.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      from cont in tmctomaescontrato.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      where fcmcuentacobrms.sis_estpro_espr == lcrEstado1 ||
                                            fcmcuentacobrms.sis_estpro_espr == lcrEstado2 ||
                                            fcmcuentacobrms.sis_estpro_espr == lcrEstado3
                                      orderby fcmcuentacobrms.fcm_fecfac_mfac descending
                                      select new BrowerTabla
                                      {
                                          campo1 = fcmcuentacobrms.fcm_secreg_mfcb,
                                          campo2 = fcmcuentacobrms.fcm_numfac_mfac,
                                          campo15 = (DateTime)fcmcuentacobrms.fcm_fecfac_mfac,
                                          campo3 = fcmcuentacobrms.fcm_descue_mfcb,
                                          campo4 = fcmcuentacobrms.fcm_notcue_mfcb,
                                          campo5 = fcmcuentacobrms.cto_seccon_cont,
                                          campo6 = fcmcuentacobrms.cto_nrocon_cont,
                                          campo7 = fcmcuentacobrms.sia_codeps_teps,
                                          campo8 = cont.cto_descon_cont,
                                          campo9 = teps.sia_deseps_teps,
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmcuentacobrms()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código",      Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Factura",     Width = 90, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha",       Width = 90, DisplayMemberBinding = new Binding("campo15"){StringFormat = "dd/MM/yyyy"}});
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 350, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Contrato",    Width = 150, DisplayMemberBinding = new Binding("campo6") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Eps",         Width = 70, DisplayMemberBinding = new Binding("campo7") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Eps",  Width = 300, DisplayMemberBinding = new Binding("campo9") });
        }
        // Seleccionar Registro
        public string fcrSelect_Fcmcuentacobrms()
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
        //    TABLA: FCMSOATMANUALMA - Maestro listado  tarifario soat
        //----------------------------------------------------------------------
        #region FCMSOATMANUALMA
        public static List<EFfcmsoatmanualma> flsBuscar_Fcmsoatmanualma(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMSOATMANUALMA", tcrBuscar, "like", "OR", "fcm_codser_soat,fcm_deskey_soat", tcrFiltroTabla);
                ObjectQuery<EFfcmsoatmanualma> lcrQuery = new ObjectQuery<EFfcmsoatmanualma>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmsoatmanualma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo SOAT", Width = 120, DisplayMemberBinding = new Binding("fcm_codser_soat") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion servicio", Width = 750, DisplayMemberBinding = new Binding("fcm_desman_soat") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Puntaje", Width = 100, DisplayMemberBinding = new Binding("fcm_punuvr_sips") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Precio", Width = 110, DisplayMemberBinding = new Binding("fcm_valser_sips") { StringFormat = "N0" } });
        }
        // Seleccionar Registro
        public String fcrSelect_Fcmsoatmanualma()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmsoatmanualma)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.fcm_codser_soat.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMFEUNSPSCDPRODU - UNSPSC Para productos
        //----------------------------------------------------------------------
        #region FCMFEUNSPSCDPRODU
        public static List<EFfcmfeunspscdprodu> flsBuscar_Fcmfeunspscdprodu(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMFEUNSPSCDPRODU", tcrBuscar, "like", "OR", "fcm_codpro_fcpr,fcm_despro_fcpr", tcrFiltroTabla);
                ObjectQuery<EFfcmfeunspscdprodu> lcrQuery = new ObjectQuery<EFfcmfeunspscdprodu>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmfeunspscdprodu()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo Producto", Width = 120, DisplayMemberBinding = new Binding("fcm_codpro_fcpr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion Producto", Width = 400, DisplayMemberBinding = new Binding("fcm_despro_fcpr") });
        }
        // Seleccionar Registro
        public String fcrSelect_Fcmfeunspscdprodu()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmfeunspscdprodu)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.fcm_codpro_fcpr.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMFEMAESRAZSOCMA - Maestro Razon social de la empresa
        //----------------------------------------------------------------------
        #region FCMFEMAESRAZSOCMA
        public static List<EFfcmfemaesrazsocma> FlsBuscar_Fcmfemaesrazsocma(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMFEMAESRAZSOCMA", tcrBuscar, "like", "OR", "fcm_secraz_fcem,fcm_numdoc_fcem,fcm_nomcom_fcem,fcm_razsoc_fcem", tcrFiltroTabla);
                ObjectQuery<EFfcmfemaesrazsocma> lcrQuery = new ObjectQuery<EFfcmfemaesrazsocma>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void FcvAddColGrid_Fcmfemaesrazsocma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Registro", Width = 120, DisplayMemberBinding = new Binding("fcm_secraz_fcem") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo Nit", Width = 70, DisplayMemberBinding = new Binding("fcm_tipdoc_fctn") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nit", Width = 120, DisplayMemberBinding = new Binding("fcm_numdoc_fcem") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Comercial", Width = 450, DisplayMemberBinding = new Binding("fcm_nomcom_fcem") });
        }
        // Seleccionar Registro
        /// <summary>
        /// Devuelve "ID"=ID unico del registro "NIT"=Nit del registro
        /// </summary>
        /// <param name="tcrTipo"></param>
        /// <returns></returns>
        public String FcrSelect_Fcmfemaesrazsocma(String tcrTipo)
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmfemaesrazsocma)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = tcrTipo == "ID" ? objReg.fcm_secraz_fcem.Trim() : objReg.fcm_numdoc_fcem.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMFEMAESFACTEFMA - Maestro de facturas electronicas
        //----------------------------------------------------------------------
        #region FCMFEMAESFACTEFMA
        public static DataTable FlsBuscar_Fcmfemaesfactefma(string tcrBuscar, string tcrFiltroTabla)
        {
            DataTable lobjDatosTabla;
            var lcrBuscar = string.Empty;
            var lcrFiltro = string.Empty;

            #region filtro
            // texto escrito por el usuario
            if (!string.IsNullOrWhiteSpace(tcrBuscar))
            {
                lcrBuscar = @"fcmfemaesfactefma.fcm_numfac_mfac LIKE '%"+tcrBuscar+@"%' OR 
                                      fcmfemaesfactefma.fcm_notdoc_mfac LIKE '%"+tcrBuscar+ @"%' OR 
                                      fcmfemaesrazsocma.fcm_nomcom_fcem LIKE '%" + tcrBuscar + @"%' OR 
                                      sismaesterceros.sis_razsoc_sitr LIKE '%" + tcrBuscar+@"%'";
            }
            // ambos tienen datos
            if (!string.IsNullOrWhiteSpace(tcrBuscar) && !string.IsNullOrWhiteSpace(tcrFiltroTabla))
            {
                lcrFiltro = "WHERE " + tcrFiltroTabla + " AND (" + lcrBuscar + ")";
            }
            else if (!string.IsNullOrWhiteSpace(tcrFiltroTabla))
            {
                lcrFiltro = "WHERE " + tcrFiltroTabla;
            }
            else 
            {
                lcrFiltro = "WHERE " + lcrBuscar;
            }
            #endregion filtro>
            #region string general
            var lcrString = @"SELECT fcmfemaesfactefma.fcm_secreg_mfac,
                                   fcmfemaesfactefma.fcm_numfac_mfac,
                                   fcmfemaesfactefma.fcm_valfac_dfac,
                                   fcmfemaesfactefma.fcm_typdoc_fctd,
                                   fcmfetipodocument.fcm_destyp_fctd,
                                   fcmfemaesfactefma.fcm_fecfac_mfac,
                                   fcmfemaesfactefma.fcm_horfac_mfac,
                                   fcmfemaesfactefma.fcm_notdoc_mfac,
                                   fcmfemaesfactefma.fcm_facori_mfac,
                                   sismaesterceros.sis_tipper_sitr,
                                   sismaesterceros.sis_numide_sitr,
                                   sismaesterceros.sis_razsoc_sitr,
                                   sismaesterceros.sis_nomcon_sitr,
								   fcmfemaesfactefma.fcm_secraz_fcem,
								   fcmfemaesrazsocma.fcm_numdoc_fcem,
								   fcmfemaesrazsocma.fcm_nomcom_fcem
                                FROM fcmfemaesfactefma
                                  INNER JOIN fcmfetipodocument ON(fcmfemaesfactefma.fcm_typdoc_fctd = fcmfetipodocument.fcm_typdoc_fctd)
                                  INNER JOIN fcmfemaesrazsocma ON(fcmfemaesfactefma.fcm_secraz_fcem = fcmfemaesrazsocma.fcm_secraz_fcem)
                                  INNER JOIN sismaesterceros ON(fcmfemaesfactefma.sis_idterc_sitr = sismaesterceros.sis_idterc_sitr)";
            #endregion string general>

            lcrString = lcrString + " " + lcrFiltro + " ORDER BY fcmfemaesfactefma.fcm_fecfac_mfac DESC LIMIT 100";
            lobjDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrString);

            return lobjDatosTabla;

        }
        // Crear Columans del DataGrid
        public void FcvAddColGrid_Fcmfemaesfactefma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Registro", Width = 100, DisplayMemberBinding = new Binding("fcm_secreg_mfac") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo Documento", Width = 110, DisplayMemberBinding = new Binding("fcm_destyp_fctd") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Documento", Width = 120, DisplayMemberBinding = new Binding("fcm_numfac_mfac") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Valor", Width = 110, DisplayMemberBinding = new Binding("fcm_valfac_dfac") { StringFormat = "N0" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha", Width = 90, DisplayMemberBinding = new Binding("fcm_fecfac_mfac") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nit", Width = 90, DisplayMemberBinding = new Binding("sis_numide_sitr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Adquirente", Width = 150, DisplayMemberBinding = new Binding("sis_razsoc_sitr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nota", Width = 250, DisplayMemberBinding = new Binding("fcm_notdoc_mfac") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Razon social", Width = 200, DisplayMemberBinding = new Binding("fcm_nomcom_fcem") });
        }
        // Seleccionar Registro
        /// <summary>
        /// Devuelve "ID"=ID unico del registro "ND"=Numero de documento factura
        /// </summary>
        /// <param name="tcrTipo">ID =Secuencal unico registro ND=Numero del documento factura</param>
        /// <returns></returns>
        public string FcrSelect_Fcmfemaesfactefma(string tcrTipo)
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (DataRowView)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = tcrTipo == "ID" ? objReg["fcm_secreg_mfac"].ToString().Trim() :
                                              objReg["fcm_numfac_mfac"].ToString().Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: FCMMANSERVICATE - Categorias servicios
        //----------------------------------------------------------------------
        #region FCMMANSERVICATE
        public static List<EFfcmmanservicate> flsBuscar_Fcmmanservicate(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("FCMMANSERVICATE", tcrBuscar, "like", "OR", "fcm_idesec_fcct,fcm_descat_fcct", tcrFiltroTabla);
                ObjectQuery<EFfcmmanservicate> lcrQuery = new ObjectQuery<EFfcmmanservicate>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Fcmmanservicate()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("fcm_idesec_fcct") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Categoria", Width = 400, DisplayMemberBinding = new Binding("fcm_descat_fcct") });
        }
        // Seleccionar Registro
        public String fcrSelect_Fcmmanservicate()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFfcmmanservicate)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.fcm_idesec_fcct.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

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
    public class CAR_Browser01 : AuxBrowser01
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
                case "CARMAESFACTUMA":
                    fcvAddColGrid_Carmaesfactuma();
                    gobDataGrid.ItemsSource = FlsBuscar_Carmaesfactuma(gcrFiltroDatos, gcrFiltroTabla).DefaultView;
                    break;

                case "CARMAESFACTUMD":
                    fcvAddColGrid_Carmaesfactumd();
                    gobDataGrid.ItemsSource = flsBuscar_Carmaesfactumd(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CARCONCEPTFACT":
                    fcvAddColGrid_Carconceptfact();
                    gobDataGrid.ItemsSource = flsBuscar_Carconceptfact(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CARFEMAILGESTIOMA":
                    fcvAddColGrid_Carfemailgestioma();
                    gobDataGrid.ItemsSource = flsBuscar_Carfemailgestioma(gcrFiltroDatos, gcrFiltroTabla);
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
                case "CARMAESFACTUMA":
                    tobDataGrid.ItemsSource = FlsBuscar_Carmaesfactuma(gcrFiltroDatos, gcrFiltroTabla).DefaultView; 
                    break;

                case "CARMAESFACTUMD":
                    tobDataGrid.ItemsSource = flsBuscar_Carmaesfactumd(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CARCONCEPTFACT":
                    tobDataGrid.ItemsSource = flsBuscar_Carconceptfact(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "CARFEMAILGESTIOMA":
                    tobDataGrid.ItemsSource = flsBuscar_Carfemailgestioma(gcrFiltroDatos, gcrFiltroTabla);
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
                case "CARMAESFACTUMA":
                    lcrReturnCodigo = fcrSelect_Carmaesfactuma();
                    break;

                case "CARMAESFACTUMD":
                    lcrReturnCodigo = fcrSelect_Carmaesfactumd();
                    break;

                case "CARCONCEPTFACT":
                    lcrReturnCodigo = fcrSelect_Carconceptfact();
                    break;

                case "CARFEMAILGESTIOMA":
                    lcrReturnCodigo = fcrSelect_Carfemailgestioma();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CARCONCEPTFACT - Conceptos para detalles facturas venta Dian
        //----------------------------------------------------------------------
        #region CARCONCEPTFACT
        public static List<EFcarconceptfact> flsBuscar_Carconceptfact(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CARCONCEPTFACT", tcrBuscar, "like", "OR", "car_codcon_cacf,car_descon_cacf", tcrFiltroTabla);
                ObjectQuery<EFcarconceptfact> lcrQuery = new ObjectQuery<EFcarconceptfact>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Carconceptfact()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo concepto", Width = 120, DisplayMemberBinding = new Binding("car_codcon_cacf") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion concepto", Width = 400, DisplayMemberBinding = new Binding("car_descon_cacf") });
        }
        // Seleccionar Registro
        public String fcrSelect_Carconceptfact()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFcarconceptfact)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.car_codcon_cacf.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CARMAESFACTUMA - Maestro facturas cobro facturacion
        //----------------------------------------------------------------------
        #region CARMAESFACTUMA
        public static DataTable FlsBuscar_Carmaesfactuma(string tcrBuscar , string tcrFiltroTabla)
        {
            DataTable lobjDatosTabla;
            var lcrFiltro = "WHERE "+ tcrFiltroTabla;

            #region filtro
            // texto escrito por el usuario
            if (!string.IsNullOrWhiteSpace(tcrBuscar))
            {
                lcrFiltro = lcrFiltro + @" AND (carmaesfactuma.car_nrofac_camf LIKE '%" + tcrBuscar + @"%' OR 
                                      carmaesfactuma.car_observ_camf LIKE '%" + tcrBuscar + @"%' OR 
                                      fcmfemaesrazsocma.fcm_nomcom_fcem LIKE '%" + tcrBuscar + @"%' OR 
                                      sismaesterceros.sis_razsoc_sitr LIKE '" + tcrBuscar + @"%')";
            }
            #endregion filtro>
            #region string general
            var lcrString = @"SELECT carmaesfactuma.car_secfac_camf,
                                   carmaesfactuma.car_nrofac_camf,
                                   carmaesfactuma.fcm_numfac_mfac,
                                   carmaesfactuma.fcm_valfac_dfac,
                                   carmaesfactuma.fcm_typdoc_fctd,
                                   fcmfetipodocument.fcm_destyp_fctd,
                                   carmaesfactuma.fcm_fecfac_mfac,
                                   carmaesfactuma.car_observ_camf,
                                   sismaesterceros.sis_tipper_sitr,
                                   sismaesterceros.sis_numide_sitr,
                                   sismaesterceros.sis_razsoc_sitr,
                                   sismaesterceros.sis_nomcon_sitr,
								   carmaesfactuma.fcm_secraz_fcem,
								   fcmfemaesrazsocma.fcm_numdoc_fcem,
								   fcmfemaesrazsocma.fcm_nomcom_fcem
                                FROM carmaesfactuma
                                  INNER JOIN fcmfetipodocument ON(carmaesfactuma.fcm_typdoc_fctd = fcmfetipodocument.fcm_typdoc_fctd)
                                  INNER JOIN fcmfemaesrazsocma ON(carmaesfactuma.fcm_secraz_fcem = fcmfemaesrazsocma.fcm_secraz_fcem)
                                  INNER JOIN sismaesterceros ON(carmaesfactuma.sis_idterc_sitr = sismaesterceros.sis_idterc_sitr)";
            #endregion string general>

            lcrString = lcrString + " " + lcrFiltro + " ORDER BY carmaesfactuma.fcm_fecfac_mfac DESC LIMIT 100";
            lobjDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrString);

            return lobjDatosTabla;

        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Carmaesfactuma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Registro", Width = 100, DisplayMemberBinding = new Binding("car_secfac_camf") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo Documento", Width = 110, DisplayMemberBinding = new Binding("fcm_destyp_fctd") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Documento", Width = 120, DisplayMemberBinding = new Binding("car_nrofac_camf") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Valor", Width = 110, DisplayMemberBinding = new Binding("fcm_valfac_dfac") { StringFormat = "N0" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha", Width = 90, DisplayMemberBinding = new Binding("fcm_fecfac_mfac") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nit", Width = 90, DisplayMemberBinding = new Binding("sis_numide_sitr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Adquirente", Width = 150, DisplayMemberBinding = new Binding("sis_razsoc_sitr") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nota", Width = 250, DisplayMemberBinding = new Binding("car_observ_camf") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Razon social", Width = 200, DisplayMemberBinding = new Binding("fcm_nomcom_fcem") });
        }
        // Seleccionar Registro
        public string fcrSelect_Carmaesfactuma()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (DataRowView)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg["car_secfac_camf"].ToString().Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CARMAESFACTUMD - Detalles conceptos y valores facturados
        //----------------------------------------------------------------------
        #region CARMAESFACTUMD
        public static List<EFcarmaesfactumd> flsBuscar_Carmaesfactumd(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CARMAESFACTUMD", tcrBuscar, "like", "OR", "car_secreg_cadf,car_descon_cadf", tcrFiltroTabla);
                ObjectQuery<EFcarmaesfactumd> lcrQuery = new ObjectQuery<EFcarmaesfactumd>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Carmaesfactumd()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo unico registro", Width = 120, DisplayMemberBinding = new Binding("car_secreg_cadf") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion concepto", Width = 400, DisplayMemberBinding = new Binding("car_descon_cadf") });
        }
        // Seleccionar Registro
        public String fcrSelect_Carmaesfactumd()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFcarmaesfactumd)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.car_secreg_cadf.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CARFEMAILGESTIOMA - Maestro gestor de correos grupales que se envian al adquiren
        //----------------------------------------------------------------------
        #region CARFEMAILGESTIOMA
        public static List<EFcarfemailgestioma> flsBuscar_Carfemailgestioma(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("CARFEMAILGESTIOMA", tcrBuscar, "like", "OR", "car_secreg_cagm,fcm_numfac_mfac,car_subjec_caml", tcrFiltroTabla);
                ObjectQuery<EFcarfemailgestioma> lcrQuery = new ObjectQuery<EFcarfemailgestioma>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Carfemailgestioma()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 90, DisplayMemberBinding = new Binding("car_secreg_cagm") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha envio", Width = 90, DisplayMemberBinding = new Binding("car_envfec_caml") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Hora envio", Width = 90, DisplayMemberBinding = new Binding("car_envhor_caml") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Asunto", Width = 400, DisplayMemberBinding = new Binding("car_subjec_caml") });
        }
        // Seleccionar Registro
        public String fcrSelect_Carfemailgestioma()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFcarfemailgestioma)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.car_secreg_cagm.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

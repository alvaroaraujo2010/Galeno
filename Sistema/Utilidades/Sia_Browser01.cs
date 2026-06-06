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
    public class SIA_Browser01 : ViewModelBase
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
                case "SIACENTROATEN":
                    fcvAddColGrid_Siacentroaten();
                    gobDataGrid.ItemsSource = flsBuscar_Siacentroaten(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAMAEPROFSALUD":
                    fcvAddColGrid_Siamaeprofsalud();
                    gobDataGrid.ItemsSource = flsBuscar_Siamaeprofsalud(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIACONSULTORIOS":
                    fcvAddColGrid_Siaconsultorios();
                    gobDataGrid.ItemsSource = flsBuscar_Siaconsultorios(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAESPECIALIMED":
                    fcvAddColGrid_Siaespecialimed();
                    gobDataGrid.ItemsSource = flsBuscar_Siaespecialimed(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAUSUARIOATEND":
                    fcvAddColGrid_Siausuarioatend();
                    gobDataGrid.ItemsSource = flsBuscar_Siausuarioatend(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAUSUARIOATENDIU":
                    fcvAddColGrid_Siausuarioatend();
                    gobDataGrid.ItemsSource = flsBuscar_Siausuarioatend(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPIDEUSARIO":
                    fcvAddColGrid_Siatipideusario();
                    gobDataGrid.ItemsSource = flsBuscar_Siatipideusario(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATABLAEPS":
                    fcvAddColGrid_Siatablaeps();
                    gobDataGrid.ItemsSource = flsBuscar_Siatablaeps(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAPROFESISALUD":
                    fcvAddColGrid_Siaprofesisalud();
                    gobDataGrid.ItemsSource = flsBuscar_Siaprofesisalud(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPPROFATIEN":
                    fcvAddColGrid_Siatipprofatien();
                    gobDataGrid.ItemsSource = flsBuscar_Siatipprofatien(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAMAEPROFESPAS":
                    fcvAddColGrid_Siamaeprofespas();
                    gobDataGrid.ItemsSource = flsBuscar_Siamaeprofespas(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPOCOTIZANTE":
                    fcvAddColGrid_Siatipocotizante();
                    gobDataGrid.ItemsSource = flsBuscar_Siatipocotizante(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPAFICONTRI":
                    fcvAddColGrid_Siatipaficontri();
                    gobDataGrid.ItemsSource = flsBuscar_Siatipaficontri(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPPOBLACION":
                    fcvAddColGrid_Siatippoblacion();
                    gobDataGrid.ItemsSource = flsBuscar_Siatippoblacion(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIANIVCONTRIBUT":
                    fcvAddColGrid_Sianivcontribut();
                    gobDataGrid.ItemsSource = flsBuscar_Sianivcontribut(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIANIVELSISBEN":
                    fcvAddColGrid_Sianivelsisben();
                    gobDataGrid.ItemsSource = flsBuscar_Sianivelsisben(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPDISCAPACI":
                    fcvAddColGrid_Siatipdiscapaci();
                    gobDataGrid.ItemsSource = flsBuscar_Siatipdiscapaci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAMEDIDAEDAD":
                    fcvAddColGrid_Siamedidaedad();
                    gobDataGrid.ItemsSource = flsBuscar_Siamedidaedad(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAREGIMENSALUD":
                    fcvAddColGrid_Siaregimensalud();
                    gobDataGrid.ItemsSource = flsBuscar_Siaregimensalud(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPOASEGURAD":
                    fcvAddColGrid_Siatipoasegurad();
                    gobDataGrid.ItemsSource = flsBuscar_Siatipoasegurad(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPACTIVIDAD":
                    fcvAddColGrid_Siatipactividad();
                    gobDataGrid.ItemsSource = flsBuscar_Siatipactividad(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAAREAPRESERVI":
                    fcvAddColGrid_Siaareapreservi();
                    gobDataGrid.ItemsSource = flsBuscar_Siaareapreservi(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIADIAGNOSTICOS":
                    fcvAddColGrid_Siadiagnosticos();
                    gobDataGrid.ItemsSource = flsBuscar_Siadiagnosticos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPODIAGPRIN":
                    fcvAddColGrid_Siatipodiagprin();
                    gobDataGrid.ItemsSource = flsBuscar_Siatipodiagprin(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAFINALICONSUL":
                    fcvAddColGrid_Siafinaliconsul();
                    gobDataGrid.ItemsSource = flsBuscar_Siafinaliconsul(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATABLATPRIPS":
                    fcvAddColGrid_Siatablatprips();
                    gobDataGrid.ItemsSource = flsBuscar_Siatablatprips(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAFINALIPROCED":
                    fcvAddColGrid_Siafinaliproced();
                    gobDataGrid.ItemsSource = flsBuscar_Siafinaliproced(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAPERTENETNICA":
                    fcvAddColGrid_Siapertenetnica();
                    gobDataGrid.ItemsSource = flsBuscar_Siapertenetnica(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIANIVELEDUCATI":
                    fcvAddColGrid_Sianiveleducati();
                    gobDataGrid.ItemsSource = flsBuscar_Sianiveleducati(gcrFiltroDatos, gcrFiltroTabla);
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
                case "SIACENTROATEN":
                    tobDataGrid.ItemsSource = flsBuscar_Siacentroaten(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAMAEPROFSALUD":
                    tobDataGrid.ItemsSource = flsBuscar_Siamaeprofsalud(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIACONSULTORIOS":
                    tobDataGrid.ItemsSource = flsBuscar_Siaconsultorios(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAESPECIALIMED":
                    tobDataGrid.ItemsSource = flsBuscar_Siaespecialimed(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAUSUARIOATEND":
                    tobDataGrid.ItemsSource = flsBuscar_Siausuarioatend(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAUSUARIOATENDIU":
                    tobDataGrid.ItemsSource = flsBuscar_Siausuarioatend(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPIDEUSARIO":
                    tobDataGrid.ItemsSource = flsBuscar_Siatipideusario(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATABLAEPS":
                    tobDataGrid.ItemsSource = flsBuscar_Siatablaeps(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAPROFESISALUD":
                    tobDataGrid.ItemsSource = flsBuscar_Siaprofesisalud(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPPROFATIEN":
                    tobDataGrid.ItemsSource = flsBuscar_Siatipprofatien(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAMAEPROFESPAS":
                    tobDataGrid.ItemsSource = flsBuscar_Siamaeprofespas(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPOCOTIZANTE":
                    tobDataGrid.ItemsSource = flsBuscar_Siatipocotizante(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPAFICONTRI":
                    tobDataGrid.ItemsSource = flsBuscar_Siatipaficontri(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPPOBLACION":
                    tobDataGrid.ItemsSource = flsBuscar_Siatippoblacion(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIANIVCONTRIBUT":
                    tobDataGrid.ItemsSource = flsBuscar_Sianivcontribut(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIANIVELSISBEN":
                    tobDataGrid.ItemsSource = flsBuscar_Sianivelsisben(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPDISCAPACI":
                    tobDataGrid.ItemsSource = flsBuscar_Siatipdiscapaci(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAMEDIDAEDAD":
                    tobDataGrid.ItemsSource = flsBuscar_Siamedidaedad(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAREGIMENSALUD":
                    tobDataGrid.ItemsSource = flsBuscar_Siaregimensalud(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPOASEGURAD":
                    tobDataGrid.ItemsSource = flsBuscar_Siatipoasegurad(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPACTIVIDAD":
                    tobDataGrid.ItemsSource = flsBuscar_Siatipactividad(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAAREAPRESERVI":
                    tobDataGrid.ItemsSource = flsBuscar_Siaareapreservi(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIADIAGNOSTICOS":
                    tobDataGrid.ItemsSource = flsBuscar_Siadiagnosticos(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATIPODIAGPRIN":
                    tobDataGrid.ItemsSource = flsBuscar_Siatipodiagprin(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAFINALICONSUL":
                    tobDataGrid.ItemsSource = flsBuscar_Siafinaliconsul(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIATABLATPRIPS":
                    tobDataGrid.ItemsSource = flsBuscar_Siatablatprips(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAFINALIPROCED":
                    tobDataGrid.ItemsSource = flsBuscar_Siafinaliproced(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIAPERTENETNICA":
                    tobDataGrid.ItemsSource = flsBuscar_Siapertenetnica(gcrFiltroDatos, gcrFiltroTabla);
                    break;

                case "SIANIVELEDUCATI":
                    tobDataGrid.ItemsSource = flsBuscar_Sianiveleducati(gcrFiltroDatos, gcrFiltroTabla);
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
                case "SIACENTROATEN":
                    lcrReturnCodigo = fcrSelect_Siacentroaten();
                    break;

                case "SIAMAEPROFSALUD":
                    lcrReturnCodigo = fcrSelect_Siamaeprofsalud();
                    break;

                case "SIACONSULTORIOS":
                    lcrReturnCodigo = fcrSelect_Siaconsultorios();
                    break;

                case "SIAESPECIALIMED":
                    lcrReturnCodigo = fcrSelect_Siaespecialimed();
                    break;

                case "SIAUSUARIOATEND":
                    lcrReturnCodigo = fcrSelect_Siausuarioatend(false);
                    break;

                case "SIAUSUARIOATENDIU":
                    lcrReturnCodigo = fcrSelect_Siausuarioatend(true);
                    break;

                case "SIATIPIDEUSARIO":
                    lcrReturnCodigo = fcrSelect_Siatipideusario();
                    break;

                case "SIATABLAEPS":
                    lcrReturnCodigo = fcrSelect_Siatablaeps();
                    break;

                case "SIAPROFESISALUD":
                    lcrReturnCodigo = fcrSelect_Siaprofesisalud();
                    break;

                case "SIATIPPROFATIEN":
                    lcrReturnCodigo = fcrSelect_Siatipprofatien();
                    break;

                case "SIAMAEPROFESPAS":
                    lcrReturnCodigo = fcrSelect_Siamaeprofespas();
                    break;

                case "SIATIPOCOTIZANTE":
                    lcrReturnCodigo = fcrSelect_Siatipocotizante();
                    break;

                case "SIATIPAFICONTRI":
                    lcrReturnCodigo = fcrSelect_Siatipaficontri();
                    break;

                case "SIATIPPOBLACION":
                    lcrReturnCodigo = fcrSelect_Siatippoblacion();
                    break;

                case "SIANIVCONTRIBUT":
                    lcrReturnCodigo = fcrSelect_Sianivcontribut();
                    break;

                case "SIANIVELSISBEN":
                    lcrReturnCodigo = fcrSelect_Sianivelsisben();
                    break;

                case "SIATIPDISCAPACI":
                    lcrReturnCodigo = fcrSelect_Siatipdiscapaci();
                    break;

                case "SIAMEDIDAEDAD":
                    lcrReturnCodigo = fcrSelect_Siamedidaedad();
                    break;

                case "SIAREGIMENSALUD":
                    lcrReturnCodigo = fcrSelect_Siaregimensalud();
                    break;

                case "SIATIPOASEGURAD":
                    lcrReturnCodigo = fcrSelect_Siatipoasegurad();
                    break;

                case "SIATIPACTIVIDAD":
                    lcrReturnCodigo = fcrSelect_Siatipactividad();
                    break;

                case "SIAAREAPRESERVI":
                    lcrReturnCodigo = fcrSelect_Siaareapreservi();
                    break;

                case "SIADIAGNOSTICOS":
                    lcrReturnCodigo = fcrSelect_Siadiagnosticos();
                    break;

                case "SIATIPODIAGPRIN":
                    lcrReturnCodigo = fcrSelect_Siatipodiagprin();
                    break;

                case "SIAFINALICONSUL":
                    lcrReturnCodigo = fcrSelect_Siafinaliconsul();
                    break;

                case "SIATABLATPRIPS":
                    lcrReturnCodigo = fcrSelect_Siatablatprips();
                    break;

                case "SIAFINALIPROCED":
                    lcrReturnCodigo = fcrSelect_Siafinaliproced();
                    break;

                case "SIAPERTENETNICA":
                    lcrReturnCodigo = fcrSelect_Siapertenetnica();
                    break;

                case "SIANIVELEDUCATI":
                    lcrReturnCodigo = fcrSelect_Sianiveleducati();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIACENTROATEN - Lista Centros de Atención  cuando hay varias sedes en lugare
        //----------------------------------------------------------------------
        #region SIACENTROATEN
        public static List<EFsiacentroaten> flsBuscar_Siacentroaten(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIACENTROATEN", tcrBuscar, "like", "OR", "sia_codcat_ceat,sia_descat_ceat", tcrFiltroTabla);
                ObjectQuery<EFsiacentroaten> lcrQuery = new ObjectQuery<EFsiacentroaten>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siacentroaten()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("sia_codcat_ceat") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Centro atención", Width = 400, DisplayMemberBinding = new Binding("sia_descat_ceat") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siacentroaten()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiacentroaten)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codcat_ceat.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAMAEPROFSALUD - Profesionales que prestan servicios
        //----------------------------------------------------------------------
        #region SIAMAEPROFSALUD
        public static List<EFsiamaeprofsalud> flsBuscar_Siamaeprofsalud(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIAMAEPROFSALUD", tcrBuscar, "like", "OR", "sia_codpfa_prof,sia_nompro_prof", tcrFiltroTabla);
                ObjectQuery<EFsiamaeprofsalud> lcrQuery = new ObjectQuery<EFsiamaeprofsalud>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siamaeprofsalud()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo del profesional", Width = 120, DisplayMemberBinding = new Binding("sia_codpfa_prof") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre del Profesional", Width = 400, DisplayMemberBinding = new Binding("sia_nompro_prof") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siamaeprofsalud()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiamaeprofsalud)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codpfa_prof.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIACONSULTORIOS - Consultorios para atencion medica
        //----------------------------------------------------------------------
        #region SIACONSULTORIOS
        public static List<EFsiaconsultorios> flsBuscar_Siaconsultorios(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIACONSULTORIOS", tcrBuscar, "like", "OR", "sia_codcon_ctor,sia_descon_ctor", tcrFiltroTabla);
                ObjectQuery<EFsiaconsultorios> lcrQuery = new ObjectQuery<EFsiaconsultorios>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siaconsultorios()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("sia_codcon_ctor") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre consultorio", Width = 400, DisplayMemberBinding = new Binding("sia_descon_ctor") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siaconsultorios()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiaconsultorios)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codcon_ctor.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAESPECIALIMED - Especialidades medicas
        //----------------------------------------------------------------------
        #region SIAESPECIALIMED
        public static List<EFsiaespecialimed> flsBuscar_Siaespecialimed(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIAESPECIALIMED", tcrBuscar, "like", "OR", "sia_codesp_esme,sia_desesp_esme", tcrFiltroTabla);
                ObjectQuery<EFsiaespecialimed> lcrQuery = new ObjectQuery<EFsiaespecialimed>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siaespecialimed()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo especialidad", Width = 120, DisplayMemberBinding = new Binding("sia_codesp_esme") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre especialidad", Width = 400, DisplayMemberBinding = new Binding("sia_desesp_esme") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siaespecialimed()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiaespecialimed)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codesp_esme.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAUSUARIOATEND - Maestro de Pacientes atendidos
        //----------------------------------------------------------------------
        #region SIAUSUARIOATEND
        public static List<EFsiausuarioatend> flsBuscar_Siausuarioatend(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIAUSUARIOATEND", tcrBuscar, "like", "OR", "sia_idesec_usua,sia_nroide_usua,sia_nomusu_usua", tcrFiltroTabla);
                ObjectQuery<EFsiausuarioatend> lcrQuery = new ObjectQuery<EFsiausuarioatend>(lcrConsulta, db);
                return lcrQuery.Take(300).ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siausuarioatend()
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
        public string fcrSelect_Siausuarioatend(bool tlgDevolverIu)
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiausuarioatend)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                if (tlgDevolverIu == false)
                {
                    lcrReturn = objReg.sia_idesec_usua.Trim();
                }
                else
                {
                    lcrReturn = objReg.sia_nroide_usua.Trim();
                }

            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIATIPIDEUSARIO - Configuracion para los tipos de identificacion de los uauari
        //----------------------------------------------------------------------
        #region SIATIPIDEUSARIO
        public static List<EFsiatipideusario> flsBuscar_Siatipideusario(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATIPIDEUSARIO", tcrBuscar, "like", "OR", "sia_tipide_tide,sia_deside_tide", tcrFiltroTabla);
                ObjectQuery<EFsiatipideusario> lcrQuery = new ObjectQuery<EFsiatipideusario>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatipideusario()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo", Width = 120, DisplayMemberBinding = new Binding("sia_tipide_tide") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo Identificación", Width = 400, DisplayMemberBinding = new Binding("sia_deside_tide") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siatipideusario()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatipideusario)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_tipide_tide.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIATABLAEPS - Lista de EPS o seguradores
        //----------------------------------------------------------------------
        #region SIATABLAEPS
        public static List<EFsiatablaeps> flsBuscar_Siatablaeps(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATABLAEPS", tcrBuscar, "like", "OR", "sia_codeps_teps,sia_deseps_teps", tcrFiltroTabla);
                ObjectQuery<EFsiatablaeps> lcrQuery = new ObjectQuery<EFsiatablaeps>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatablaeps()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código EPS", Width = 120, DisplayMemberBinding = new Binding("sia_codeps_teps") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre EPS", Width = 400, DisplayMemberBinding = new Binding("sia_deseps_teps") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siatablaeps()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatablaeps)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codeps_teps.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAPROFESISALUD - Profesiones de salud
        //----------------------------------------------------------------------
        #region SIAPROFESISALUD
        public static List<EFsiaprofesisalud> flsBuscar_Siaprofesisalud(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIAPROFESISALUD", tcrBuscar, "like", "OR", "sia_codprm_prom,sia_desprm_prom", tcrFiltroTabla);
                ObjectQuery<EFsiaprofesisalud> lcrQuery = new ObjectQuery<EFsiaprofesisalud>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siaprofesisalud()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("sia_codprm_prom") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre Profesión", Width = 400, DisplayMemberBinding = new Binding("sia_desprm_prom") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siaprofesisalud()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiaprofesisalud)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codprm_prom.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIATIPPROFATIEN - Tipo profesional que atiende
        //----------------------------------------------------------------------
        #region SIATIPPROFATIEN
        public static List<EFsiatipprofatien> flsBuscar_Siatipprofatien(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATIPPROFATIEN", tcrBuscar, "like", "OR", "sia_codpat_tpat,sia_despat_tpat", tcrFiltroTabla);
                ObjectQuery<EFsiatipprofatien> lcrQuery = new ObjectQuery<EFsiatipprofatien>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatipprofatien()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("sia_codpat_tpat") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo profesional", Width = 400, DisplayMemberBinding = new Binding("sia_despat_tpat") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siatipprofatien()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatipprofatien)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codpat_tpat.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAMAEPROFESPAS - Especialidades asignadas a profesional
        //----------------------------------------------------------------------
        #region SIAMAEPROFESPAS
        public static List<BrowerTabla> flsBuscar_Siamaeprofespas(string tcrBuscar, string tcrFiltroTabla)
        {

            using (DbAplicacion db = new DbAplicacion())
            {
                
                if (!String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    var lcrQuery = from proa in db.Siamaeprofespas
                                   join esme in db.Siaespecialimed on proa.sia_codesp_esme equals esme.sia_codesp_esme
                                   where proa.sia_codpfa_prof.Equals(tcrFiltroTabla) &&
                                   (esme.sia_desesp_esme.Contains(tcrBuscar) || proa.sia_codesp_esme.Contains(tcrBuscar)) 
                                   select new BrowerTabla
                                   {
                                       campo1 = proa.sia_codesp_esme,
                                       campo2 = esme.sia_desesp_esme
                                   };
                    return lcrQuery.ToList();
                }
                else
                {
                    var lcrQuery = from proa in db.Siamaeprofespas
                                   join esme in db.Siaespecialimed on proa.sia_codesp_esme equals esme.sia_codesp_esme into tmp
                                   where proa.sia_codpfa_prof.Equals(tcrFiltroTabla)
                                   from tmpx in tmp
                                   select new BrowerTabla
                                   {
                                       campo1 = proa.sia_codesp_esme,
                                       campo2 = tmpx.sia_desesp_esme
                                   };
                    return lcrQuery.ToList();
                }
               
                /*
                var lcrConsulta = "SELECT proa.sia_codesp_esme, esme.sia_desesp_esme " +
                                            " FROM Siamaeprofespas AS proa INNER JOIN Siaespecialimed AS esme " +
                                            " ON proa.sia_codesp_esme=esme.sia_codesp_esme"+
                                            " WHERE proa.sia_codpfa_prof ='"+tcrFiltroTabla+"'";

                //var lcrQuery = db.CreateQuery<BrowSiamaeprofespas>(lcrConsulta);
                var lcrQuery = new ObjectQuery<String>(lcrConsulta, db);
                return lcrQuery.ToList();
                */
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siamaeprofespas()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo especialidad", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre especialidad", Width = 400, DisplayMemberBinding = new Binding("campo2") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siamaeprofespas()
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
        //    TABLA: SIATIPOCOTIZANTE - Tipo cotizante contributivo según Resolucion: 1344 de 2012 B
        //----------------------------------------------------------------------
        #region SIATIPOCOTIZANTE
        public static List<EFsiatipocotizante> flsBuscar_Siatipocotizante(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATIPOCOTIZANTE", tcrBuscar, "like", "OR", "sia_tipcot_tcot,sia_descot_tcot", tcrFiltroTabla);
                ObjectQuery<EFsiatipocotizante> lcrQuery = new ObjectQuery<EFsiatipocotizante>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatipocotizante()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo cotizante", Width = 120, DisplayMemberBinding = new Binding("sia_tipcot_tcot") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción tipo cotizante", Width = 400, DisplayMemberBinding = new Binding("sia_descot_tcot") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siatipocotizante()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatipocotizante)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_tipcot_tcot.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIATIPAFICONTRI - Tipo Afiliado contributivo Resolucion 1344 de 2012 BDUA: C=C
        //----------------------------------------------------------------------
        #region SIATIPAFICONTRI
        public static List<EFsiatipaficontri> flsBuscar_Siatipaficontri(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATIPAFICONTRI", tcrBuscar, "like", "OR", "sia_tipafi_tafi,sia_destaf_tafi", tcrFiltroTabla);
                ObjectQuery<EFsiatipaficontri> lcrQuery = new ObjectQuery<EFsiatipaficontri>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatipaficontri()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo Afiliado Contributivo", Width = 120, DisplayMemberBinding = new Binding("sia_tipafi_tafi") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción tipo afiliado", Width = 400, DisplayMemberBinding = new Binding("sia_destaf_tafi") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siatipaficontri()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatipaficontri)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_tipafi_tafi.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIATIPPOBLACION - Tipo poblacional especial para subsidiado, según normas de b
        //----------------------------------------------------------------------
        #region SIATIPPOBLACION
        public static List<EFsiatippoblacion> flsBuscar_Siatippoblacion(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATIPPOBLACION", tcrBuscar, "like", "OR", "sia_tippob_tpob,sia_despob_tpob", tcrFiltroTabla);
                ObjectQuery<EFsiatippoblacion> lcrQuery = new ObjectQuery<EFsiatippoblacion>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatippoblacion()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo población especial", Width = 120, DisplayMemberBinding = new Binding("sia_tippob_tpob") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción población especial", Width = 400, DisplayMemberBinding = new Binding("sia_despob_tpob") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siatippoblacion()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatippoblacion)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_tippob_tpob.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIANIVCONTRIBUT - Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y
        //----------------------------------------------------------------------
        #region SIANIVCONTRIBUT
        public static List<EFsianivcontribut> flsBuscar_Sianivcontribut(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIANIVCONTRIBUT", tcrBuscar, "like", "OR", "sia_nivcon_ncon,sia_descon_ncon", tcrFiltroTabla);
                ObjectQuery<EFsianivcontribut> lcrQuery = new ObjectQuery<EFsianivcontribut>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sianivcontribut()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nivel Contributivo", Width = 120, DisplayMemberBinding = new Binding("sia_nivcon_ncon") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción nivel contributivo", Width = 400, DisplayMemberBinding = new Binding("sia_descon_ncon") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sianivcontribut()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsianivcontribut)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_nivcon_ncon.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIANIVELSISBEN - Codigo Nivel Sisben para cobro de copagos  según Resolución:
        //----------------------------------------------------------------------
        #region SIANIVELSISBEN
        public static List<EFsianivelsisben> flsBuscar_Sianivelsisben(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIANIVELSISBEN", tcrBuscar, "like", "OR", "sia_nivsbn_nsbn,sia_dessbn_nsbn", tcrFiltroTabla);
                ObjectQuery<EFsianivelsisben> lcrQuery = new ObjectQuery<EFsianivelsisben>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sianivelsisben()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nivel Sisben", Width = 120, DisplayMemberBinding = new Binding("sia_nivsbn_nsbn") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción nivel sisben", Width = 400, DisplayMemberBinding = new Binding("sia_dessbn_nsbn") });
        }
        // Seleccionar Registro
        public string fcrSelect_Sianivelsisben()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsianivelsisben)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_nivsbn_nsbn.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIATIPDISCAPACI - Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Vi
        //----------------------------------------------------------------------
        #region SIATIPDISCAPACI
        public static List<EFsiatipdiscapaci> flsBuscar_Siatipdiscapaci(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATIPDISCAPACI", tcrBuscar, "like", "OR", "sia_tipdis_tdis,sia_desdis_tdis", tcrFiltroTabla);
                ObjectQuery<EFsiatipdiscapaci> lcrQuery = new ObjectQuery<EFsiatipdiscapaci>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatipdiscapaci()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo discapacidad", Width = 120, DisplayMemberBinding = new Binding("sia_tipdis_tdis") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción discapacidad", Width = 400, DisplayMemberBinding = new Binding("sia_desdis_tdis") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siatipdiscapaci()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatipdiscapaci)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_tipdis_tdis.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAMEDIDAEDAD - Medida de la edad del Usuario/Paciente según  RIPS: 1=Año 2=
        //----------------------------------------------------------------------
        #region SIAMEDIDAEDAD
        public static List<EFsiamedidaedad> flsBuscar_Siamedidaedad(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIAMEDIDAEDAD", tcrBuscar, "like", "OR", "sia_codmed_tmed,sia_desmed_tmed", tcrFiltroTabla);
                ObjectQuery<EFsiamedidaedad> lcrQuery = new ObjectQuery<EFsiamedidaedad>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siamedidaedad()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código Medida Edad", Width = 120, DisplayMemberBinding = new Binding("sia_codmed_tmed") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción medida edad", Width = 400, DisplayMemberBinding = new Binding("sia_desmed_tmed") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siamedidaedad()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiamedidaedad)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codmed_tmed.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAREGIMENSALUD - Lista de Régimenes en Salud
        //----------------------------------------------------------------------
        #region SIAREGIMENSALUD
        public static List<EFsiaregimensalud> flsBuscar_Siaregimensalud(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIAREGIMENSALUD", tcrBuscar, "like", "OR", "sia_tipusu_regi,sia_destip_regi", tcrFiltroTabla);
                ObjectQuery<EFsiaregimensalud> lcrQuery = new ObjectQuery<EFsiaregimensalud>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siaregimensalud()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("sia_tipusu_regi") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Régimen Salud", Width = 400, DisplayMemberBinding = new Binding("sia_destip_regi") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siaregimensalud()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiaregimensalud)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_tipusu_regi.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIATIPOASEGURAD - Clasificacion aseguradores servicios de salud
        //----------------------------------------------------------------------
        #region SIATIPOASEGURAD
        public static List<EFsiatipoasegurad> flsBuscar_Siatipoasegurad(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATIPOASEGURAD", tcrBuscar, "like", "OR", "sia_tipase_sita,sia_desase_sita", tcrFiltroTabla);
                ObjectQuery<EFsiatipoasegurad> lcrQuery = new ObjectQuery<EFsiatipoasegurad>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatipoasegurad()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código tipo asegurador", Width = 120, DisplayMemberBinding = new Binding("sia_tipase_sita") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion tipo", Width = 400, DisplayMemberBinding = new Binding("sia_desase_sita") });
        }
        // Seleccionar Registro
        public String fcrSelect_Siatipoasegurad()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatipoasegurad)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_tipase_sita.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIATIPACTIVIDAD - Tipo de servicio o actividad
        //----------------------------------------------------------------------
        #region SIATIPACTIVIDAD
        public static List<EFsiatipactividad> flsBuscar_Siatipactividad(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATIPACTIVIDAD", tcrBuscar, "like", "OR", "sia_tipact_tsac,sia_desact_tsac", tcrFiltroTabla);
                ObjectQuery<EFsiatipactividad> lcrQuery = new ObjectQuery<EFsiatipactividad>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatipactividad()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo actividad", Width = 120, DisplayMemberBinding = new Binding("sia_tipact_tsac") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Servicio o actividad", Width = 400, DisplayMemberBinding = new Binding("sia_desact_tsac") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siatipactividad()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatipactividad)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_tipact_tsac.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAAREAPRESERVI - Areas prestacion de servicios
        //----------------------------------------------------------------------
        #region SIAAREAPRESERVI
        public static List<EFsiaareapreservi> flsBuscar_Siaareapreservi(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIAAREAPRESERVI", tcrBuscar, "like", "OR", "sia_codare_aser,sia_desare_aser", tcrFiltroTabla);
                ObjectQuery<EFsiaareapreservi> lcrQuery = new ObjectQuery<EFsiaareapreservi>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siaareapreservi()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("sia_codare_aser") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre área servicios", Width = 400, DisplayMemberBinding = new Binding("sia_desare_aser") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siaareapreservi()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiaareapreservi)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codare_aser.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIADIAGNOSTICOS - Tabla de diagnosticos CIE - 10
        //----------------------------------------------------------------------
        #region SIADIAGNOSTICOS
        public static List<BrowerTabla> flsBuscar_Siadiagnosticos(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                tcrBuscar = tcrBuscar.Trim();
                if (String.IsNullOrWhiteSpace(tcrBuscar))
                {
                    #region consulta
                    var lobConsulta = from siadiagnosticos in db.Siadiagnosticos
                                      select new BrowerTabla
                                      {
                                          #region Datos
                                          campo1 = siadiagnosticos.sia_coddia_tdia,
                                          campo2 = siadiagnosticos.sia_desdia_tdia,
                                          #endregion
                                      };
                    return lobConsulta.Take(300).ToList();
                    #endregion
                }
                else
                {
                    #region consulta
                    var lobConsulta = from siadiagnosticos in db.Siadiagnosticos
                                      where siadiagnosticos.sia_coddia_tdia.Contains(tcrBuscar) ||
                                            siadiagnosticos.sia_desdia_tdia.Contains(tcrBuscar)
                                      orderby siadiagnosticos.sia_indice_tdia ascending
                                      select new BrowerTabla
                                      {
                                          #region Datos
                                          campo1 = siadiagnosticos.sia_coddia_tdia,
                                          campo2 = siadiagnosticos.sia_desdia_tdia,
                                          #endregion
                                      };
                    return lobConsulta.Take(200).ToList();
                    #endregion
                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siadiagnosticos()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Diagnostico", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripcion diagnostico", Width = 510, DisplayMemberBinding = new Binding("campo2") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siadiagnosticos()
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
        //    TABLA: SIATIPODIAGPRIN - Tipo diagnostico principal
        //----------------------------------------------------------------------
        #region SIATIPODIAGPRIN
        public static List<EFsiatipodiagprin> flsBuscar_Siatipodiagprin(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATIPODIAGPRIN", tcrBuscar, "like", "OR", "sia_tipdxp_tdix,sia_desdxp_tdix", tcrFiltroTabla);
                ObjectQuery<EFsiatipodiagprin> lcrQuery = new ObjectQuery<EFsiatipodiagprin>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatipodiagprin()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo Tipo diagnostico", Width = 120, DisplayMemberBinding = new Binding("sia_tipdxp_tdix") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo diagnostico principal", Width = 400, DisplayMemberBinding = new Binding("sia_desdxp_tdix") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siatipodiagprin()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatipodiagprin)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_tipdxp_tdix.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAFINALICONSUL - Finalidad del Consulta
        //----------------------------------------------------------------------
        #region SIAFINALICONSUL
        public static List<EFsiafinaliconsul> flsBuscar_Siafinaliconsul(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIAFINALICONSUL", tcrBuscar, "like", "OR", "sia_codfco_fcon,sia_desfco_fcon", tcrFiltroTabla);
                ObjectQuery<EFsiafinaliconsul> lcrQuery = new ObjectQuery<EFsiafinaliconsul>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siafinaliconsul()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Finalidad Consulta", Width = 120, DisplayMemberBinding = new Binding("sia_codfco_fcon") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 400, DisplayMemberBinding = new Binding("sia_desfco_fcon") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siafinaliconsul()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiafinaliconsul)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codfco_fcon.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIATABLATPRIPS - Tabla tipo RIPS
        //----------------------------------------------------------------------
        #region SIATABLATPRIPS
        public static List<EFsiatablatprips> flsBuscar_Siatablatprips(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIATABLATPRIPS", tcrBuscar, "like", "OR", "sia_codrip_trip,sia_desrip_trip", tcrFiltroTabla);
                ObjectQuery<EFsiatablatprips> lcrQuery = new ObjectQuery<EFsiatablatprips>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siatablatprips()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo", Width = 120, DisplayMemberBinding = new Binding("sia_codrip_trip") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nombre", Width = 400, DisplayMemberBinding = new Binding("sia_desrip_trip") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siatablatprips()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiatablatprips)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codrip_trip.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAFINALIPROCED - Finalidad del Procedimiento
        //----------------------------------------------------------------------
        #region SIAFINALIPROCED
        public static List<EFsiafinaliproced> flsBuscar_Siafinaliproced(string tcrBuscar, string tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIAFINALIPROCED", tcrBuscar, "like", "OR", "sia_codfpr_fpro,sia_desfpr_fpro", tcrFiltroTabla);
                ObjectQuery<EFsiafinaliproced> lcrQuery = new ObjectQuery<EFsiafinaliproced>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siafinaliproced()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Finalidad", Width = 120, DisplayMemberBinding = new Binding("sia_codfpr_fpro") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 400, DisplayMemberBinding = new Binding("sia_desfpr_fpro") });
        }
        // Seleccionar Registro
        public string fcrSelect_Siafinaliproced()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiafinaliproced)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codfpr_fpro.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIAPERTENETNICA - Perntenencia Etnica
        //----------------------------------------------------------------------
        #region SIAPERTENETNICA
        public static List<EFsiapertenetnica> flsBuscar_Siapertenetnica(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIAPERTENETNICA", tcrBuscar, "like", "OR", "sia_codper_pret,sia_desper_pret", tcrFiltroTabla);
                ObjectQuery<EFsiapertenetnica> lcrQuery = new ObjectQuery<EFsiapertenetnica>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Siapertenetnica()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Pertenencia etnica", Width = 120, DisplayMemberBinding = new Binding("sia_codper_pret") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción Pertenencia etnica", Width = 400, DisplayMemberBinding = new Binding("sia_desper_pret") });
        }
        // Seleccionar Registro
        public String fcrSelect_Siapertenetnica()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsiapertenetnica)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_codper_pret.Trim();
            }
            return lcrReturn;
        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: SIANIVELEDUCATI - Nivel educativo usuario paciente
        //----------------------------------------------------------------------
        #region SIANIVELEDUCATI
        public static List<EFsianiveleducati> flsBuscar_Sianiveleducati(String tcrBuscar, String tcrFiltroTabla)
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                String lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("SIANIVELEDUCATI", tcrBuscar, "like", "OR", "sia_nivedu_sine,sia_desedu_sine", tcrFiltroTabla);
                ObjectQuery<EFsianiveleducati> lcrQuery = new ObjectQuery<EFsianiveleducati>(lcrConsulta, db);
                return lcrQuery.ToList();
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Sianiveleducati()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo", Width = 120, DisplayMemberBinding = new Binding("sia_nivedu_sine") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Nivel educativo", Width = 400, DisplayMemberBinding = new Binding("sia_desedu_sine") });
        }
        // Seleccionar Registro
        public String fcrSelect_Sianiveleducati()
        {
            var lcrReturn = String.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFsianiveleducati)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.sia_nivedu_sine.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

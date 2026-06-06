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
using Sistema.Utilidades;
using Sistema.Clases;

namespace Sistema.Utilidades
{
    public class CIT_Browser02 : AuxBrowser02
    {

        #region Configurar la vista General del Browser
        //----------------------------------------------------------------------
        //    Funcion: ConfigInicial()
        //----------------------------------------------------------------------
        #region ConfigInicial: Inicio y Configuracion de DataGrid
        public void ConfigInicial()
        {
            fcvReferenciaObjetos();
            switch (gcrTabla.ToUpper())
            {
                case "CITMAESTROTURNO":
                    fcvAddColGrid_Citmaestroturno();
                    gobDataGrid.ItemsSource = flsBuscar_Citmaestroturno();
                    break;

                case "CITMAESASIGCITA":
                    fcvAddColGrid_Citmaesasigcita();
                    gobDataGrid.ItemsSource = flsBuscar_Citmaesasigcita();
                    break;
                    
            }

        }
        #endregion
        //----------------------------------------------------------------------
        //    Funcion: Buscar()
        //----------------------------------------------------------------------
        #region fcvBuscar: Buscar Registro
        public void fcvBuscar()
        {
            fcvReferenciaObjetos();
            switch (gcrTabla.ToUpper())
            {
                case "CITMAESTROTURNO":
                    gobDataGrid.ItemsSource = flsBuscar_Citmaestroturno();
                    break;

                case "CITMAESASIGCITA":
                    gobDataGrid.ItemsSource = flsBuscar_Citmaesasigcita();
                    break;
            }

        }
        #endregion
        //----------------------------------------------------------------------
        //    Funcion: fcrRegistroSelect()
        //----------------------------------------------------------------------
        #region fcrRegistroSelect: Seleccion del Registro activo en la Grilla
        public string fcrRegistroSelect()
        {
            fcvReferenciaObjetos();
            string lcrReturnCodigo = string.Empty;
            switch (gcrTabla.ToUpper())
            {

                case "CITMAESTROTURNO":
                    lcrReturnCodigo = fcrSelect_Citmaestroturno();
                    break;

                case "CITMAESASIGCITA":
                    lcrReturnCodigo = fcrSelect_Citmaesasigcita();
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: CITMAESTROTURNO - Maestro de turnos por profesional
        //----------------------------------------------------------------------
        #region CITMAESTROTURNO
        public List<BrowerTabla> flsBuscar_Citmaestroturno()
        {
            var lcrValorFecha = String.Empty;
            var lcrTexto1 = gobjTextBox21.Text;
            var lcrTexto2 = gobjTextBox22.Text;

            DateTime ldaFecha = DateTime.Now;
            if (gcrIndiceActivo == "2" || gcrIndiceActivo == "3")
            {
                lcrValorFecha = Funciones.fcrValidaFechaTexto(true, "DMY", "/", gobjTextBox21.Text, "Fecha turno");
                if (String.IsNullOrWhiteSpace(lcrValorFecha))
                {
                    DateTime.TryParse(gobjTextBox21.Text, out ldaFecha);
                    lcrValorFecha = "OK";
                }
                else
                {
                    lcrValorFecha = String.Empty;
                }
            }

            using (DbAplicacion db = new DbAplicacion())
            {
                if (gcrIndiceActivo == "1") //Codigo y nombre del profesional
                {
                    #region Codigo y nombre
                    var lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where t1.sia_codpfa_prof.Contains(gobjTextBox11.Text.Trim()) ||
                                         t2.sia_nompro_prof.Contains(gobjTextBox11.Text.Trim())
                                   orderby t1.cit_fecitr_turn descending
                                   select new BrowerTabla
                                   {
                                       campo1 = t1.cit_codtur_turn,
                                       campo2 = t1.sia_codpfa_prof,
                                       campo3 = t2.sia_nompro_prof,
                                       campo4 = t1.cit_destur_turn
                                   };
                    return lcrQuery.Take(500).ToList();
                    #endregion
                }
                else if (gcrIndiceActivo == "2") //fecha turno y nombre del profesional
                {
                    #region Descripcion turno y nombre del profesional
                    /*
                    var lcrQuery = from t1 in db.Citmaestroturno
                                   join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                   where t1.cit_fecitr_turn == ldaFecha ||
                                         t2.sia_nompro_prof.Contains(gobjTextBox22.Text.Trim())
                                   orderby t1.cit_codtur_turn descending
                                   select new BrowerTabla
                                   {
                                       campo1 = t1.cit_codtur_turn,
                                       campo2 = t1.sia_codpfa_prof,
                                       campo3 = t2.sia_nompro_prof,
                                       campo4 = t1.cit_destur_turn
                                   };
                    return lcrQuery.Take(200).ToList();
                    */
                    #endregion
                    if (!String.IsNullOrWhiteSpace(lcrValorFecha) && !String.IsNullOrWhiteSpace(gobjTextBox22.Text.Trim()))
                    {
                        #region Ambos tienen datos
                        var lcrQuery = from t1 in db.Citmaestroturno
                                       join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                       where t1.cit_fecitr_turn == ldaFecha &&
                                             t2.sia_nompro_prof.Contains(gobjTextBox22.Text.Trim())
                                       orderby t1.cit_fecitr_turn descending
                                       select new BrowerTabla
                                       {
                                           campo1 = t1.cit_codtur_turn,
                                           campo2 = t1.sia_codpfa_prof,
                                           campo3 = t2.sia_nompro_prof,
                                           campo4 = t1.cit_destur_turn
                                       };
                        return lcrQuery.Take(200).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(lcrValorFecha) && String.IsNullOrWhiteSpace(gobjTextBox22.Text.Trim()))
                    {
                        #region Solo fecha
                        var lcrQuery = from t1 in db.Citmaestroturno
                                       join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                       where t1.cit_fecitr_turn == ldaFecha
                                       orderby t1.cit_fecitr_turn descending
                                       select new BrowerTabla
                                       {
                                           campo1 = t1.cit_codtur_turn,
                                           campo2 = t1.sia_codpfa_prof,
                                           campo3 = t2.sia_nompro_prof,
                                           campo4 = t1.cit_destur_turn
                                       };
                        return lcrQuery.Take(200).ToList();
                        #endregion
                    }
                    else if (String.IsNullOrWhiteSpace(lcrValorFecha) && !String.IsNullOrWhiteSpace(gobjTextBox22.Text.Trim()))
                    {
                        #region Solo codigo
                        var lcrQuery = from t1 in db.Citmaestroturno
                                       join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                       where t2.sia_nompro_prof.Contains(gobjTextBox22.Text.Trim())
                                       orderby t1.cit_fecitr_turn descending
                                       select new BrowerTabla
                                       {
                                           campo1 = t1.cit_codtur_turn,
                                           campo2 = t1.sia_codpfa_prof,
                                           campo3 = t2.sia_nompro_prof,
                                           campo4 = t1.cit_destur_turn
                                       };
                        return lcrQuery.Take(200).ToList();
                        #endregion
                    }
                    else
                    {
                        #region ambos vacios
                        var lcrQuery = from t1 in db.Citmaestroturno
                                       join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                       orderby t1.cit_fecitr_turn descending
                                       select new BrowerTabla
                                       {
                                           campo1 = t1.cit_codtur_turn,
                                           campo2 = t1.sia_codpfa_prof,
                                           campo3 = t2.sia_nompro_prof,
                                           campo4 = t1.cit_destur_turn
                                       };
                        return lcrQuery.Take(200).ToList();
                        #endregion
                    }

                }
                else if (gcrIndiceActivo == "3") // fecha turno y Codigo del profesional
                {
                    if (!String.IsNullOrWhiteSpace(lcrValorFecha) && !String.IsNullOrWhiteSpace(gobjTextBox22.Text.Trim()))
                    {
                        #region Ambos tienen datos
                        var lcrQuery = from t1 in db.Citmaestroturno
                                       join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                       where t1.cit_fecitr_turn == ldaFecha &&
                                             t1.sia_codpfa_prof.Contains(gobjTextBox22.Text.Trim())
                                       orderby t1.cit_fecitr_turn descending
                                       select new BrowerTabla
                                       {
                                           campo1 = t1.cit_codtur_turn,
                                           campo2 = t1.sia_codpfa_prof,
                                           campo3 = t2.sia_nompro_prof,
                                           campo4 = t1.cit_destur_turn
                                       };
                        return lcrQuery.Take(200).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(lcrValorFecha) && String.IsNullOrWhiteSpace(gobjTextBox22.Text.Trim()))
                    {
                        #region Solo fecha
                        var lcrQuery = from t1 in db.Citmaestroturno
                                       join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                       where t1.cit_fecitr_turn == ldaFecha
                                       orderby t1.cit_fecitr_turn descending
                                       select new BrowerTabla
                                       {
                                           campo1 = t1.cit_codtur_turn,
                                           campo2 = t1.sia_codpfa_prof,
                                           campo3 = t2.sia_nompro_prof,
                                           campo4 = t1.cit_destur_turn
                                       };
                        return lcrQuery.Take(200).ToList();
                        #endregion
                    }
                    else if (String.IsNullOrWhiteSpace(lcrValorFecha) && !String.IsNullOrWhiteSpace(gobjTextBox22.Text.Trim()))
                    {
                        #region Solo codigo
                        var lcrQuery = from t1 in db.Citmaestroturno
                                       join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                       where t1.sia_codpfa_prof.Contains(gobjTextBox22.Text.Trim())
                                       orderby t1.cit_fecitr_turn descending
                                       select new BrowerTabla
                                       {
                                           campo1 = t1.cit_codtur_turn,
                                           campo2 = t1.sia_codpfa_prof,
                                           campo3 = t2.sia_nompro_prof,
                                           campo4 = t1.cit_destur_turn
                                       };
                        return lcrQuery.Take(200).ToList();
                        #endregion
                    }
                    else
                    {
                        #region ambos vacios
                        var lcrQuery = from t1 in db.Citmaestroturno
                                       join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                       orderby t1.cit_fecitr_turn descending
                                       select new BrowerTabla
                                       {
                                           campo1 = t1.cit_codtur_turn,
                                           campo2 = t1.sia_codpfa_prof,
                                           campo3 = t2.sia_nompro_prof,
                                           campo4 = t1.cit_destur_turn
                                       };
                        return lcrQuery.Take(200).ToList();
                        #endregion
                    }
                }
                else
                {
                    #region Sin ningun filtro
                    var lcrQuery = (from t1 in db.Citmaestroturno
                                    join t2 in db.Siamaeprofsalud on t1.sia_codpfa_prof equals t2.sia_codpfa_prof
                                    orderby t1.cit_fecitr_turn descending
                                    select new BrowerTabla
                                    {
                                        campo1 = t1.cit_codtur_turn,
                                        campo2 = t1.sia_codpfa_prof,
                                        campo3 = t2.sia_nompro_prof,
                                        campo4 = t1.cit_destur_turn
                                    });

                    return lcrQuery.Take(200).ToList();
                    #endregion
                }
            }
        }
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Citmaestroturno()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Registro", Width = 120, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Profesional", Width = 220, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción turno", Width = 330, DisplayMemberBinding = new Binding("campo4") });
            //---------------------------
            // Lista de indices y titulos para Texbox de busqueda
            //---------------------------
            #region Configurar lista de indices
            gclListaIndices.Add(new ComboItem() { IdIndice = "1", NombreIndice = "Codigo o Nombre Profesional", TotalCampos = 1, Titulos = new List<string> { "Nombre Profesional" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "2", NombreIndice = "Fecha y Nombre Profesional", TotalCampos = 2, Titulos = new List<string> { "Fecha", "Nombre Profesional" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "3", NombreIndice = "Fecha y Codigo Profesional", TotalCampos = 2, Titulos = new List<string> { "Fecha", "Codigo Profesional" } });
            //---------------------------
            //Establecemos el itemssource del ComboBox a lista de Indices.
            gobListBoxIndices.ItemsSource = gclListaIndices;
            gobListBoxIndices.SelectedItem = gobListBoxIndices.Items[gnuIdIndiceInicial-1];
            // Activar el Tab de Textbox correspondiente
            fcvActivarTab("Tab" + fcrTotalCamposIndiceActivo());
            #endregion
        }
        // Seleccionar Registro
        public string fcrSelect_Citmaestroturno()
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
        //    TABLA: CITMAESASIGCITA - Consulta historial Maestro asignacion citas
        //----------------------------------------------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowserDatos
        {
            public BrowserDatos() { }
            public String campo1 { get; set; }
            public String campo2 { get; set; }
            public String campo3 { get; set; }
            public String campo4 { get; set; }
            public String campo5 { get; set; }
            public String campo6 { get; set; }
            public String campo7 { get; set; }
            public String campo8 { get; set; }
            public String campo9 { get; set; }
            public String campo10 { get; set; }
            public String campo11 { get; set; }
            public String campo12 { get; set; }
            public String campo13 { get; set; }
            public String campo14 { get; set; }
            public DateTime fecha1 { get; set; }
            public DateTime fecha2 { get; set; }
        }
        #endregion
        #region CITMAESASIGCITA
        #region Filtro de busquedas
        public List<BrowserDatos> flsBuscar_Citmaesasigcita()
        {
            using (DbAplicacion db = new DbAplicacion())
            {

                if (gcrIndiceActivo == "1") // Numero de Identificacion
                {
                    if (!String.IsNullOrWhiteSpace(gobjTextBox11.Text.Trim()))
                    {
                        #region Numero de Identificacion
                        var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                       join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from spro in tmcitservicioprog.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from aasi in tmcitestadoascita.DefaultIfEmpty()
                                       where citmaesasigcita.sia_nroide_usua.Contains(gobjTextBox11.Text)
                                       orderby citmaesasigcita.cit_feccit_mcit descending
                                       select new BrowserDatos
                                       {
                                           campo1 = aasi.cit_descit_easi,
                                           fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                           campo2 = spro.cit_desspr_spro,
                                           campo3 = citmaesasigcita.sia_tipide_tide,
                                           campo4 = citmaesasigcita.sia_nroide_usua,
                                           campo5 = usua.sia_priape_usua,
                                           campo6 = usua.sia_segape_usua,
                                           campo7 = usua.sia_prinom_usua,
                                           campo8 = usua.sia_segnom_usua,
                                           fecha2 = (DateTime)usua.sia_fecnac_usua,
                                           campo9 = usua.sis_codsex_sexo,
                                           campo10 = aser.sia_desare_aser,
                                           campo12 = citmaesasigcita.sia_codeps_teps,
                                           campo14 = citmaesasigcita.cit_codasi_mcit
                                       };
                        return lcrQuery.Take(200).ToList();
                        #endregion
                    }
                    else
                    {
                        #region Sin Filtro
                        var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                       join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from spro in tmcitservicioprog.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from aasi in tmcitestadoascita.DefaultIfEmpty()
                                       where citmaesasigcita.cit_estcit_easi != "1" && citmaesasigcita.cit_estcit_easi != "6"
                                       orderby citmaesasigcita.cit_feccit_mcit descending
                                       select new BrowserDatos
                                       {
                                           campo1 = aasi.cit_descit_easi,
                                           fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                           campo2 = spro.cit_desspr_spro,
                                           campo3 = citmaesasigcita.sia_tipide_tide,
                                           campo4 = citmaesasigcita.sia_nroide_usua,
                                           campo5 = usua.sia_priape_usua,
                                           campo6 = usua.sia_segape_usua,
                                           campo7 = usua.sia_prinom_usua,
                                           campo8 = usua.sia_segnom_usua,
                                           fecha2 = (DateTime)usua.sia_fecnac_usua,
                                           campo9 = usua.sis_codsex_sexo,
                                           campo10 = aser.sia_desare_aser,
                                           campo12 = citmaesasigcita.sia_codeps_teps,
                                           campo14 = citmaesasigcita.cit_codasi_mcit
                                       };
                        return lcrQuery.Take(100).ToList();
                        #endregion
                    }
                }
                else if (gcrIndiceActivo == "2") // P.Apellido S.Apellido P.Nombre
                {
                    if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()) &&
                        !String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()) &&
                        !String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region P.Apellido S.Apellido P.Nombre
                        var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                       join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from spro in tmcitservicioprog.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from aasi in tmcitestadoascita.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                             usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) &&
                                             usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim())
                                       orderby citmaesasigcita.cit_feccit_mcit descending
                                       select new BrowserDatos
                                       {
                                           campo1 = aasi.cit_descit_easi,
                                           fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                           campo2 = spro.cit_desspr_spro,
                                           campo3 = citmaesasigcita.sia_tipide_tide,
                                           campo4 = citmaesasigcita.sia_nroide_usua,
                                           campo5 = usua.sia_priape_usua,
                                           campo6 = usua.sia_segape_usua,
                                           campo7 = usua.sia_prinom_usua,
                                           campo8 = usua.sia_segnom_usua,
                                           fecha2 = (DateTime)usua.sia_fecnac_usua,
                                           campo9 = usua.sis_codsex_sexo,
                                           campo10 = aser.sia_desare_aser,
                                           campo12 = citmaesasigcita.sia_codeps_teps,
                                           campo14 = citmaesasigcita.cit_codasi_mcit
                                       };
                        return lcrQuery.Take(100).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()) &&
                       !String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()))
                    {
                        #region P.Apellido S.Apellido
                        var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                       join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from spro in tmcitservicioprog.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from aasi in tmcitestadoascita.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                             usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) 
                                       orderby citmaesasigcita.cit_feccit_mcit descending
                                       select new BrowserDatos
                                       {
                                           campo1 = aasi.cit_descit_easi,
                                           fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                           campo2 = spro.cit_desspr_spro,
                                           campo3 = citmaesasigcita.sia_tipide_tide,
                                           campo4 = citmaesasigcita.sia_nroide_usua,
                                           campo5 = usua.sia_priape_usua,
                                           campo6 = usua.sia_segape_usua,
                                           campo7 = usua.sia_prinom_usua,
                                           campo8 = usua.sia_segnom_usua,
                                           fecha2 = (DateTime)usua.sia_fecnac_usua,
                                           campo9 = usua.sis_codsex_sexo,
                                           campo10 = aser.sia_desare_aser,
                                           campo12 = citmaesasigcita.sia_codeps_teps,
                                           campo14 = citmaesasigcita.cit_codasi_mcit
                                       };
                        return lcrQuery.Take(100).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()) &&
                       !String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region P.Apellido P.Nombre
                        var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                       join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from spro in tmcitservicioprog.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from aasi in tmcitestadoascita.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                             usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) 
                                       orderby citmaesasigcita.cit_feccit_mcit descending
                                       select new BrowserDatos
                                       {
                                           campo1 = aasi.cit_descit_easi,
                                           fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                           campo2 = spro.cit_desspr_spro,
                                           campo3 = citmaesasigcita.sia_tipide_tide,
                                           campo4 = citmaesasigcita.sia_nroide_usua,
                                           campo5 = usua.sia_priape_usua,
                                           campo6 = usua.sia_segape_usua,
                                           campo7 = usua.sia_prinom_usua,
                                           campo8 = usua.sia_segnom_usua,
                                           fecha2 = (DateTime)usua.sia_fecnac_usua,
                                           campo9 = usua.sis_codsex_sexo,
                                           campo10 = aser.sia_desare_aser,
                                           campo12 = citmaesasigcita.sia_codeps_teps,
                                           campo14 = citmaesasigcita.cit_codasi_mcit
                                       };
                        return lcrQuery.Take(100).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()) &&
                       !String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region S.Apellido P.Nombre
                        var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                       join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from spro in tmcitservicioprog.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from aasi in tmcitestadoascita.DefaultIfEmpty()
                                       where usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) &&
                                             usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) 
                                       orderby citmaesasigcita.cit_feccit_mcit descending
                                       select new BrowserDatos
                                       {
                                           campo1 = aasi.cit_descit_easi,
                                           fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                           campo2 = spro.cit_desspr_spro,
                                           campo3 = citmaesasigcita.sia_tipide_tide,
                                           campo4 = citmaesasigcita.sia_nroide_usua,
                                           campo5 = usua.sia_priape_usua,
                                           campo6 = usua.sia_segape_usua,
                                           campo7 = usua.sia_prinom_usua,
                                           campo8 = usua.sia_segnom_usua,
                                           fecha2 = (DateTime)usua.sia_fecnac_usua,
                                           campo9 = usua.sis_codsex_sexo,
                                           campo10 = aser.sia_desare_aser,
                                           campo12 = citmaesasigcita.sia_codeps_teps,
                                           campo14 = citmaesasigcita.cit_codasi_mcit
                                       };
                        return lcrQuery.Take(100).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()))
                    {
                        #region P.Apellido
                        var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                       join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from spro in tmcitservicioprog.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from aasi in tmcitestadoascita.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) 
                                       orderby citmaesasigcita.cit_feccit_mcit descending
                                       select new BrowserDatos
                                       {
                                           campo1 = aasi.cit_descit_easi,
                                           fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                           campo2 = spro.cit_desspr_spro,
                                           campo3 = citmaesasigcita.sia_tipide_tide,
                                           campo4 = citmaesasigcita.sia_nroide_usua,
                                           campo5 = usua.sia_priape_usua,
                                           campo6 = usua.sia_segape_usua,
                                           campo7 = usua.sia_prinom_usua,
                                           campo8 = usua.sia_segnom_usua,
                                           fecha2 = (DateTime)usua.sia_fecnac_usua,
                                           campo9 = usua.sis_codsex_sexo,
                                           campo10 = aser.sia_desare_aser,
                                           campo12 = citmaesasigcita.sia_codeps_teps,
                                           campo14 = citmaesasigcita.cit_codasi_mcit
                                       };
                        return lcrQuery.Take(100).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()))
                    {
                        #region S.Apellido
                        var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                       join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from spro in tmcitservicioprog.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from aasi in tmcitestadoascita.DefaultIfEmpty()
                                       where usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim())
                                       orderby citmaesasigcita.cit_feccit_mcit descending
                                       select new BrowserDatos
                                       {
                                           campo1 = aasi.cit_descit_easi,
                                           fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                           campo2 = spro.cit_desspr_spro,
                                           campo3 = citmaesasigcita.sia_tipide_tide,
                                           campo4 = citmaesasigcita.sia_nroide_usua,
                                           campo5 = usua.sia_priape_usua,
                                           campo6 = usua.sia_segape_usua,
                                           campo7 = usua.sia_prinom_usua,
                                           campo8 = usua.sia_segnom_usua,
                                           fecha2 = (DateTime)usua.sia_fecnac_usua,
                                           campo9 = usua.sis_codsex_sexo,
                                           campo10 = aser.sia_desare_aser,
                                           campo12 = citmaesasigcita.sia_codeps_teps,
                                           campo14 = citmaesasigcita.cit_codasi_mcit
                                       };
                        return lcrQuery.Take(100).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region P.Nombre
                        var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                       join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from spro in tmcitservicioprog.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from aasi in tmcitestadoascita.DefaultIfEmpty()
                                       where usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) 
                                       orderby citmaesasigcita.cit_feccit_mcit descending
                                       select new BrowserDatos
                                       {
                                           campo1 = aasi.cit_descit_easi,
                                           fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                           campo2 = spro.cit_desspr_spro,
                                           campo3 = citmaesasigcita.sia_tipide_tide,
                                           campo4 = citmaesasigcita.sia_nroide_usua,
                                           campo5 = usua.sia_priape_usua,
                                           campo6 = usua.sia_segape_usua,
                                           campo7 = usua.sia_prinom_usua,
                                           campo8 = usua.sia_segnom_usua,
                                           fecha2 = (DateTime)usua.sia_fecnac_usua,
                                           campo9 = usua.sis_codsex_sexo,
                                           campo10 = aser.sia_desare_aser,
                                           campo12 = citmaesasigcita.sia_codeps_teps,
                                           campo14 = citmaesasigcita.cit_codasi_mcit
                                       };
                        return lcrQuery.Take(100).ToList();
                        #endregion
                    }
                    else
                    {
                        #region Por Defecto
                        var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                       join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                       join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from spro in tmcitservicioprog.DefaultIfEmpty()
                                       from aser in tmsiaareapreservi.DefaultIfEmpty()
                                       from aasi in tmcitestadoascita.DefaultIfEmpty()
                                       where citmaesasigcita.cit_estcit_easi != "1" && citmaesasigcita.cit_estcit_easi != "6"
                                       orderby citmaesasigcita.cit_feccit_mcit descending
                                       select new BrowserDatos
                                       {
                                           campo1 = aasi.cit_descit_easi,
                                           fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                           campo2 = spro.cit_desspr_spro,
                                           campo3 = citmaesasigcita.sia_tipide_tide,
                                           campo4 = citmaesasigcita.sia_nroide_usua,
                                           campo5 = usua.sia_priape_usua,
                                           campo6 = usua.sia_segape_usua,
                                           campo7 = usua.sia_prinom_usua,
                                           campo8 = usua.sia_segnom_usua,
                                           fecha2 = (DateTime)usua.sia_fecnac_usua,
                                           campo9 = usua.sis_codsex_sexo,
                                           campo10 = aser.sia_desare_aser,
                                           campo12 = citmaesasigcita.sia_codeps_teps,
                                           campo14 = citmaesasigcita.cit_codasi_mcit
                                       };
                        return lcrQuery.Take(100).ToList();
                        #endregion
                    }
                }
                else
                {
                    #region Sin Filtro
                    var lcrQuery = from citmaesasigcita in db.Citmaesasigcita
                                   join siausuarioatend in db.Siausuarioatend on citmaesasigcita.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join citservicioprog in db.Citservicioprog on citmaesasigcita.cit_codspr_spro equals citservicioprog.cit_codspr_spro into tmcitservicioprog
                                   join siaareapreservi in db.Siaareapreservi on citmaesasigcita.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                   join citestadoascita in db.Citestadoascita on citmaesasigcita.cit_estcit_easi equals citestadoascita.cit_estcit_easi into tmcitestadoascita
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from spro in tmcitservicioprog.DefaultIfEmpty()
                                   from aser in tmsiaareapreservi.DefaultIfEmpty()
                                   from aasi in tmcitestadoascita.DefaultIfEmpty()
                                   where citmaesasigcita.cit_estcit_easi != "1" && citmaesasigcita.cit_estcit_easi != "6"
                                   orderby citmaesasigcita.cit_feccit_mcit descending
                                   select new BrowserDatos
                                   {
                                       campo1 = aasi.cit_descit_easi,
                                       fecha1 = (DateTime)citmaesasigcita.cit_feccit_mcit,
                                       campo2 = spro.cit_desspr_spro,
                                       campo3 = citmaesasigcita.sia_tipide_tide,
                                       campo4 = citmaesasigcita.sia_nroide_usua,
                                       campo5 = usua.sia_priape_usua,
                                       campo6 = usua.sia_segape_usua,
                                       campo7 = usua.sia_prinom_usua,
                                       campo8 = usua.sia_segnom_usua,
                                       fecha2 = (DateTime)usua.sia_fecnac_usua,
                                       campo9 = usua.sis_codsex_sexo,
                                       campo10 = aser.sia_desare_aser,
                                       campo12 = citmaesasigcita.sia_codeps_teps,
                                       campo14 = citmaesasigcita.cit_codasi_mcit
                                   };
                    return lcrQuery.Take(100).ToList();
                    #endregion
                }
            }
        }
        #endregion
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Citmaesasigcita()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado cita",        Width = 150, DisplayMemberBinding = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha cita",         Width = 100, DisplayMemberBinding = new Binding("fecha1") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Servicio",           Width = 280, DisplayMemberBinding = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo id",            Width = 80, DisplayMemberBinding = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificacion",     Width = 100, DisplayMemberBinding = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Apellido",    Width = 120, DisplayMemberBinding = new Binding("campo5") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Apellido",   Width = 120, DisplayMemberBinding = new Binding("campo6") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Nombre",      Width = 120, DisplayMemberBinding = new Binding("campo7") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Nombre",     Width = 120, DisplayMemberBinding = new Binding("campo8") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Fecha Nacimiento",   Width = 100, DisplayMemberBinding = new Binding("fecha2") { StringFormat = "dd/MM/yyyy" } });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Sexo",               Width = 70, DisplayMemberBinding = new Binding("campo9") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Area servicio",      Width = 120, DisplayMemberBinding = new Binding("campo10") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Codigo EPS",         Width = 100, DisplayMemberBinding = new Binding("campo12") });
            //---------------------------
            // Lista de indices y titulos para Texbox de busqueda
            //---------------------------
            #region Configurar lista de indices
            gclListaIndices.Add(new ComboItem() { IdIndice = "1", NombreIndice = "Identificación", TotalCampos = 1, Titulos = new List<string> { "Identificación" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "2", NombreIndice = "Apellidos y Nombre", TotalCampos = 3, Titulos = new List<string> { "Primer Apellido", "Segundo Apellido", "Primer Nombre" } });
            //---------------------------
            //Establecemos el itemssource del ComboBox a lista de Indices.
            gobListBoxIndices.ItemsSource = gclListaIndices;
            gobListBoxIndices.SelectedItem = gobListBoxIndices.Items[gnuIdIndiceInicial - 1];
            // Activar el Tab de Textbox correspondiente
            fcvActivarTab("Tab" + fcrTotalCamposIndiceActivo());
            #endregion
        }
        // Seleccionar Registro
        public string fcrSelect_Citmaesasigcita()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowserDatos)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo14.Trim();
            }
            return lcrReturn;
        }
        #endregion
    }
}

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
    public class HCL_Browser02 : AuxBrowser02
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
                case "HCLMAESTROHISCL":
                    fcvAddColGrid_Hclmaestrohiscl();
                    gobDataGrid.ItemsSource = flsBuscar_Hclmaestrohiscl();
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
                case "HCLMAESTROHISCL":
                    gobDataGrid.ItemsSource = flsBuscar_Hclmaestrohiscl();
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

                case "HCLMAESTROHISCL":
                    lcrReturnCodigo = fcrSelect_Hclmaestrohiscl();
                    break;

            }
            return lcrReturnCodigo;
        }
        #endregion
        #endregion
        //-----------------------------------
        //- Browser de la tabla historias
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerHistorias
        {
            public BrowerHistorias() { }
            public string campo1 { get; set; }
            public string campo2 { get; set; }
            public string campo3 { get; set; }
            public string campo4 { get; set; }
            public string campo5 { get; set; }
            public string campo6 { get; set; }
            public string campo7 { get; set; }
            public string campo8 { get; set; }
            public string campo9 { get; set; }

        }
        #endregion
        //----------------------------------------------------------------------
        //    TABLA: HCLMAESTROHISCL - Historias Clínicas
        //----------------------------------------------------------------------
        #region HCLMAESTROHISCL
        #region Filtro de busquedas
        public List<BrowerHistorias> flsBuscar_Hclmaestrohiscl()
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                var lcrEstado1 = Funciones.fuxExtraerElemento(2, "*", gcrFiltroTabla); // Activo - Inactivo 
                var lcrEstado2 = lcrEstado1; 

                if (lcrEstado1 == "TODOS")
                {
                    lcrEstado1 = "1"; // Activo
                    lcrEstado2 = "2"; // Inactivo
                }

                if (gcrIndiceActivo == "1") // Numero de Historia Clinica
                {
                    #region Numero de Historia Clinica
                    var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                   join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from esrg in tmsisestadoregist.DefaultIfEmpty()
                                   where hclmaestrohiscl.hcl_nrohis_hicl.Contains(gobjTextBox11.Text.Trim()) &&
                                         (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                   select new BrowerHistorias
                                      {
                                          campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                          campo2 = usua.sia_tipide_tide,
                                          campo3 = usua.sia_nroide_usua,
                                          campo4 = usua.sia_priape_usua,
                                          campo5 = usua.sia_segape_usua,
                                          campo6 = usua.sia_prinom_usua,
                                          campo7 = usua.sia_segnom_usua,
                                          campo8 = esrg.sis_estreg_esrg,
                                          campo9 = hclmaestrohiscl.sia_idesec_usua,
                                      };
                    return lcrQuery.Take(300).ToList();
                    #endregion
                }
                else if (gcrIndiceActivo == "2") // Numero de Identificacion
                {
                    #region Numero de Identificacion
                    var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                   join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from esrg in tmsisestadoregist.DefaultIfEmpty()
                                   where usua.sia_nroide_usua.Contains(gobjTextBox11.Text.Trim()) &&
                                        (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                   select new BrowerHistorias
                                   {
                                       campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                       campo2 = usua.sia_tipide_tide,
                                       campo3 = usua.sia_nroide_usua,
                                       campo4 = usua.sia_priape_usua,
                                       campo5 = usua.sia_segape_usua,
                                       campo6 = usua.sia_prinom_usua,
                                       campo7 = usua.sia_segnom_usua,
                                       campo8 = esrg.sis_estreg_esrg,
                                       campo9 = hclmaestrohiscl.sia_idesec_usua,
                                   };
                    return lcrQuery.Take(300).ToList();
                    #endregion
                }
                else if (gcrIndiceActivo == "3") // P.Apellido S.Apellido P.Nombre
                {
                    if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()) &&
                        !String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()) &&
                        !String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region P.Apellido S.Apellido P.Nombre
                        var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                   join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from esrg in tmsisestadoregist.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                             usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) &&
                                             usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) &&
                                            (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                       select new BrowerHistorias
                                       {
                                           campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                           campo2 = usua.sia_tipide_tide,
                                           campo3 = usua.sia_nroide_usua,
                                           campo4 = usua.sia_priape_usua,
                                           campo5 = usua.sia_segape_usua,
                                           campo6 = usua.sia_prinom_usua,
                                           campo7 = usua.sia_segnom_usua,
                                           campo8 = esrg.sis_estreg_esrg,
                                           campo9 = hclmaestrohiscl.sia_idesec_usua,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()) &&
                       !String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()))
                    {
                        #region P.Apellido S.Apellido
                        var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                       join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from esrg in tmsisestadoregist.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                             usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) &&
                                            (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                       select new BrowerHistorias
                                       {
                                           campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                           campo2 = usua.sia_tipide_tide,
                                           campo3 = usua.sia_nroide_usua,
                                           campo4 = usua.sia_priape_usua,
                                           campo5 = usua.sia_segape_usua,
                                           campo6 = usua.sia_prinom_usua,
                                           campo7 = usua.sia_segnom_usua,
                                           campo8 = esrg.sis_estreg_esrg,
                                           campo9 = hclmaestrohiscl.sia_idesec_usua,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()) &&
                       !String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region P.Apellido P.Nombre
                        var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                       join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from esrg in tmsisestadoregist.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                             usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) &&
                                            (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                       select new BrowerHistorias
                                       {
                                           campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                           campo2 = usua.sia_tipide_tide,
                                           campo3 = usua.sia_nroide_usua,
                                           campo4 = usua.sia_priape_usua,
                                           campo5 = usua.sia_segape_usua,
                                           campo6 = usua.sia_prinom_usua,
                                           campo7 = usua.sia_segnom_usua,
                                           campo8 = esrg.sis_estreg_esrg,
                                           campo9 = hclmaestrohiscl.sia_idesec_usua,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()) &&
                       !String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region S.Apellido P.Nombre
                        var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                       join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from esrg in tmsisestadoregist.DefaultIfEmpty()
                                       where usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) &&
                                             usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) &&
                                            (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                       select new BrowerHistorias
                                       {
                                           campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                           campo2 = usua.sia_tipide_tide,
                                           campo3 = usua.sia_nroide_usua,
                                           campo4 = usua.sia_priape_usua,
                                           campo5 = usua.sia_segape_usua,
                                           campo6 = usua.sia_prinom_usua,
                                           campo7 = usua.sia_segnom_usua,
                                           campo8 = esrg.sis_estreg_esrg,
                                           campo9 = hclmaestrohiscl.sia_idesec_usua,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox31.Text.Trim()))
                    {
                        #region P.Apellido 
                        var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                       join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from esrg in tmsisestadoregist.DefaultIfEmpty()
                                       where usua.sia_priape_usua.Contains(gobjTextBox31.Text.Trim()) &&
                                            (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                       select new BrowerHistorias
                                       {
                                           campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                           campo2 = usua.sia_tipide_tide,
                                           campo3 = usua.sia_nroide_usua,
                                           campo4 = usua.sia_priape_usua,
                                           campo5 = usua.sia_segape_usua,
                                           campo6 = usua.sia_prinom_usua,
                                           campo7 = usua.sia_segnom_usua,
                                           campo8 = esrg.sis_estreg_esrg,
                                           campo9 = hclmaestrohiscl.sia_idesec_usua,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox32.Text.Trim()))
                    {
                        #region S.Apellido
                        var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                       join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from esrg in tmsisestadoregist.DefaultIfEmpty()
                                       where usua.sia_segape_usua.Contains(gobjTextBox32.Text.Trim()) &&
                                            (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                       select new BrowerHistorias
                                       {
                                           campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                           campo2 = usua.sia_tipide_tide,
                                           campo3 = usua.sia_nroide_usua,
                                           campo4 = usua.sia_priape_usua,
                                           campo5 = usua.sia_segape_usua,
                                           campo6 = usua.sia_prinom_usua,
                                           campo7 = usua.sia_segnom_usua,
                                           campo8 = esrg.sis_estreg_esrg,
                                           campo9 = hclmaestrohiscl.sia_idesec_usua,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else if (!String.IsNullOrWhiteSpace(gobjTextBox33.Text.Trim()))
                    {
                        #region P.Nombre
                        var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                       join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from esrg in tmsisestadoregist.DefaultIfEmpty()
                                       where usua.sia_prinom_usua.Contains(gobjTextBox33.Text.Trim()) &&
                                            (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                       select new BrowerHistorias
                                       {
                                           campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                           campo2 = usua.sia_tipide_tide,
                                           campo3 = usua.sia_nroide_usua,
                                           campo4 = usua.sia_priape_usua,
                                           campo5 = usua.sia_segape_usua,
                                           campo6 = usua.sia_prinom_usua,
                                           campo7 = usua.sia_segnom_usua,
                                           campo8 = esrg.sis_estreg_esrg,
                                           campo9 = hclmaestrohiscl.sia_idesec_usua,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                    else 
                    {
                        #region Por Defecto
                        var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                       join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from esrg in tmsisestadoregist.DefaultIfEmpty()
                                       where (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                       select new BrowerHistorias
                                       {
                                           campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                           campo2 = usua.sia_tipide_tide,
                                           campo3 = usua.sia_nroide_usua,
                                           campo4 = usua.sia_priape_usua,
                                           campo5 = usua.sia_segape_usua,
                                           campo6 = usua.sia_prinom_usua,
                                           campo7 = usua.sia_segnom_usua,
                                           campo8 = esrg.sis_estreg_esrg,
                                           campo9 = hclmaestrohiscl.sia_idesec_usua,
                                       };
                        return lcrQuery.Take(300).ToList();
                        #endregion
                    }
                }
                else
                {
                    #region Sin Filtro
                    var lcrQuery = from hclmaestrohiscl in db.Hclmaestrohiscl
                                   join siausuarioatend in db.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                   join sisestadoregist in db.Sisestadoregist on hclmaestrohiscl.sis_estreg_esrg equals sisestadoregist.sis_estreg_esrg into tmsisestadoregist
                                   from usua in tmsiausuarioatend.DefaultIfEmpty()
                                   from esrg in tmsisestadoregist.DefaultIfEmpty()
                                   where (hclmaestrohiscl.sis_estreg_esrg == lcrEstado1 || hclmaestrohiscl.sis_estreg_esrg == lcrEstado2)
                                   select new BrowerHistorias
                                   {
                                       campo1 = hclmaestrohiscl.hcl_nrohis_hicl,
                                       campo2 = usua.sia_tipide_tide,
                                       campo3 = usua.sia_nroide_usua,
                                       campo4 = usua.sia_priape_usua,
                                       campo5 = usua.sia_segape_usua,
                                       campo6 = usua.sia_prinom_usua,
                                       campo7 = usua.sia_segnom_usua,
                                       campo8 = esrg.sis_estreg_esrg,
                                       campo9 = hclmaestrohiscl.sia_idesec_usua,
                                   };                    
                    return lcrQuery.Take(300).ToList();
                    #endregion
                }
            }
        }
        #endregion
        // Crear Columans del DataGrid
        public void fcvAddColGrid_Hclmaestrohiscl()
        {
            gobGridView.Columns.Add(new GridViewColumn { Header = "Número historia", Width = 130, DisplayMemberBinding  = new Binding("campo1") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Id.única", Width = 120, DisplayMemberBinding          = new Binding("campo9") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Tipo Id.", Width = 60, DisplayMemberBinding          = new Binding("campo2") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Identificación", Width = 120, DisplayMemberBinding   = new Binding("campo3") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Apellido", Width = 120, DisplayMemberBinding  = new Binding("campo4") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Apellido", Width = 120, DisplayMemberBinding = new Binding("campo5") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Primer Nombre", Width = 120, DisplayMemberBinding    = new Binding("campo6") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Segundo Nombre", Width = 120, DisplayMemberBinding   = new Binding("campo7") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Estado registro", Width = 120, DisplayMemberBinding  = new Binding("campo8") });
            //---------------------------
            // Lista de indices y titulos para Texbox de busqueda
            //---------------------------
            #region Configurar lista de indices
            gclListaIndices.Add(new ComboItem() { IdIndice = "1", NombreIndice = "Número historia", TotalCampos = 1, Titulos = new List<string> { "Número Historia Clínica" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "2", NombreIndice = "Identificación", TotalCampos = 1, Titulos = new List<string> { "Identificación"}});
            gclListaIndices.Add(new ComboItem() { IdIndice = "3", NombreIndice = "Nombre Paciente", TotalCampos = 3, Titulos = new List<string> { "Primer Apellido", "Segundo Apellido", "Primer Nombre" } });
            //---------------------------
            //Establecemos el itemssource del ComboBox a lista de Indices.
            gobListBoxIndices.ItemsSource = gclListaIndices;
            gobListBoxIndices.SelectedItem = gobListBoxIndices.Items[gnuIdIndiceInicial-1];
            // Activar el Tab de Textbox correspondiente
            fcvActivarTab("Tab" + fcrTotalCamposIndiceActivo());
            #endregion
        }
        // Seleccionar Registro
        public string fcrSelect_Hclmaestrohiscl()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (BrowerHistorias)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.campo1.Trim();
            }
            return lcrReturn;
        }
        #endregion

    }
}

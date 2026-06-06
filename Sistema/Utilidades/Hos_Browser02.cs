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
    public class HOS_Browser02 : AuxBrowser02
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
                case "HOSCAMASAREAS":
                    break;

                case "HOSESTADOCAMA":
                    fcvAddColGrid_Hosestadocama();
                    gobDataGrid.ItemsSource = flsBuscar_Hosestadocama();
                    break;

                case "HOSHABITACIONES":
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
                case "HOSCAMASAREAS":
                    break;

                case "HOSESTADOCAMA":
                    gobDataGrid.ItemsSource = flsBuscar_Hosestadocama();
                    break;

                case "HOSHABITACIONES":
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
                case "HOSCAMASAREAS":
                    break;

                case "HOSESTADOCAMA":
                    lcrReturnCodigo=fcrSelect_Hosestadocama();
                    break;

                case "HOSHABITACIONES":
                    break;
            }
            return lcrReturnCodigo;
        }
        #endregion
        #endregion
        //----------------------------------------------------------------------
        //    TABLA:  HOSESTADOCAMA
        //----------------------------------------------------------------------
        #region HOSESTADOCAMA
        // Realizar la busqueda en la tabla
        public List<EFhosestadocama> flsBuscar_Hosestadocama()
        {
            using (DbAplicacion db = new DbAplicacion())
            {
                if (gcrIndiceActivo == "1")
                {
                    string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("Hosestadocama", gobjTextBox11.Text, "like", "OR", "hos_codcam_caho,hos_descam_caho", gcrFiltroTabla);
                    ObjectQuery<EFhosestadocama> lcrQuery = new ObjectQuery<EFhosestadocama>(lcrConsulta, db);
                    return lcrQuery.ToList();
                }
                else if (gcrIndiceActivo == "2")
                {
                    string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("Hosestadocama", gobjTextBox11.Text, "like", "OR", "hos_desest_ecam", gcrFiltroTabla);
                    ObjectQuery<EFhosestadocama> lcrQuery = new ObjectQuery<EFhosestadocama>(lcrConsulta, db);
                    return lcrQuery.ToList();
                }
                else if (gcrIndiceActivo == "3")
                {
                    string lcrConsulta = Funciones.fcrGenConsultaSqlBrowser("Hosestadocama", gobjTextBox21.Text.Trim(), "like", "AND", "hos_estcam_ecam", "hos_desest_ecam = '" + gobjTextBox22.Text.Trim() + "'");
                    ObjectQuery<EFhosestadocama> lcrQuery = new ObjectQuery<EFhosestadocama>(lcrConsulta, db);
                    return lcrQuery.ToList();
                }
                else 
                {
                    var lArDatos = (from reg in db.Hosestadocama select reg).ToList();
                    return lArDatos;
                }
            }
        }

        // Crear Columans del DataGrid e indices
        public void fcvAddColGrid_Hosestadocama()
        {
            //---------------------------
            // Lista de campos para grilla
            //---------------------------
            #region Configurar la Grilla
            gobGridView.Columns.Add(new GridViewColumn { Header = "Código", Width = 120, DisplayMemberBinding = new Binding("hos_estcam_ecam") });
            gobGridView.Columns.Add(new GridViewColumn { Header = "Descripción", Width = 220, DisplayMemberBinding = new Binding("hos_desest_ecam") });
            #endregion
            //---------------------------
            // Lista de indices y titulos para Texbox de busqueda
            //---------------------------
            #region Configurar lista de indices
            gclListaIndices.Add(new ComboItem() { IdIndice = "1", NombreIndice = "Codigo              ", TotalCampos = 1, Titulos = new List<string> {"Codigo" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "2", NombreIndice = "Descripcion         ", TotalCampos = 1, Titulos = new List<string> {"Descripcion" } });
            gclListaIndices.Add(new ComboItem() { IdIndice = "3", NombreIndice = "Codigo y Descripcion", TotalCampos = 2, Titulos = new List<string> {"Codigo", "Descripcion" } });
            //---------------------------
            //Establecemos el itemssource del ComboBox a lista de Indices.
            gobListBoxIndices.ItemsSource = gclListaIndices;
            gobListBoxIndices.SelectedItem = gobListBoxIndices.Items[gnuIdIndiceInicial];
            // Activar el Tab de Textbox correspondiente
            fcvActivarTab("Tab" + fcrTotalCamposIndiceActivo());
            #endregion

        }
        // Devolver el codigo de Registro Seleccionado
        public string fcrSelect_Hosestadocama()
        {
            var lcrReturn = string.Empty;
            if (gobDataGrid.SelectedIndex != -1)
            {
                var objReg = (EFhosestadocama)gobDataGrid.Items[gobDataGrid.SelectedIndex];
                lcrReturn = objReg.hos_estcam_ecam;
            }
            return lcrReturn;
        }
        #endregion
    }
}

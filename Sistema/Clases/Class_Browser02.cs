using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using Datos.Modelos;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Sistema.Clases
{
    /// <summary>
    /// Clase Auxiliar para el Browser02 que permite generar la lista 
    /// de indices para cada tabla
    /// </summary>
    public class AuxBrowser02 : ViewModelBase
    {
        public Window gobjForm;
        public object gobRefRegistro;
        public String gcrCodigoModulo;
        public String gcrTabla;
        public String gcrTabActivo;
        public String gcrIndiceActivo;
        public String gcrTotCamposIndiceAct;
        public int gnuIdIndiceInicial;
        public ListView gobDataGrid;
        public GridView gobGridView;
        public ComboBox gobListBoxIndices;
        public String gcrFiltroTabla;
        public List<ComboItem> gclListaIndices;
        // textos en marco de pagina de la ventana
        public TabControl gobjTabControl;
        public TextBox gobjTextBox11;
        public TextBox gobjTextBox21,gobjTextBox22;
        public TextBox gobjTextBox31,gobjTextBox32,gobjTextBox33;
        public TextBox gobjTextBox41,gobjTextBox42,gobjTextBox43,gobjTextBox44;
        // titulos 
        public Label gobjTitulo11;
        public Label gobjTitulo21, gobjTitulo22;
        public Label gobjTitulo31, gobjTitulo32, gobjTitulo33;
        public Label gobjTitulo41, gobjTitulo42, gobjTitulo43, gobjTitulo44;
        //-----------------------------------
        //- Clase Cargar Browser de la tabla
        //-----------------------------------
        #region Clase Cargar Browser de la tabla
        public class BrowerTabla
        {
            public BrowerTabla() { }
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
            public String campo15 { get; set; }
            public String campo16 { get; set; }
            public String campo17 { get; set; }
            public String campo18 { get; set; }
            public String campo19 { get; set; }
            public String campo20 { get; set; }
            public DateTime fecha1 { get; set; }
            public DateTime fecha2 { get; set; }
            public DateTime fecha3 { get; set; }
            public DateTime fecha4 { get; set; }
            public DateTime fecha5 { get; set; }
        }
        #endregion
        //-----------------------------------
        //- Clase para Cargar lista de Indices 
        //-----------------------------------
        #region para Cargar lista de indices
        public class ComboItem
        {
            public ComboItem() { } 
            public String IdIndice { get; set; }
            public String NombreIndice { get; set; }
            public int TotalCampos { get; set; }
            public List<string> Titulos { get; set; }
        }
        #endregion
        //-----------------------------------
        //- Referencias a objetos del Formulario
        //-----------------------------------
        #region Referencias a objetos del Formulario
        public void fcvReferenciaObjetos() 
        {
            // Referenciar objetos de la ventana

            gobDataGrid = gobjForm.FindName("objDataGrid") as ListView;
            gobGridView = gobjForm.FindName("objGridView") as GridView;
            gobListBoxIndices = gobjForm.FindName("cboListBoxIndices") as ComboBox;
            gobjTabControl = gobjForm.FindName("pagTabControl") as TabControl;
            //- campos
            gobjTextBox11 = gobjForm.FindName("txtText11") as TextBox;
            gobjTextBox21 = gobjForm.FindName("txtText21") as TextBox;
            gobjTextBox22 = gobjForm.FindName("txtText22") as TextBox;
            gobjTextBox31 = gobjForm.FindName("txtText31") as TextBox;
            gobjTextBox32 = gobjForm.FindName("txtText32") as TextBox;
            gobjTextBox33 = gobjForm.FindName("txtText33") as TextBox;
            gobjTextBox41 = gobjForm.FindName("txtText41") as TextBox;
            gobjTextBox42 = gobjForm.FindName("txtText42") as TextBox;
            gobjTextBox43 = gobjForm.FindName("txtText43") as TextBox;
            gobjTextBox44 = gobjForm.FindName("txtText44") as TextBox;
            //-Titulos
            gobjTitulo11 = gobjForm.FindName("lblTitulo11") as Label;
            gobjTitulo21 = gobjForm.FindName("lblTitulo21") as Label;
            gobjTitulo22 = gobjForm.FindName("lblTitulo22") as Label;
            gobjTitulo31 = gobjForm.FindName("lblTitulo31") as Label;
            gobjTitulo32 = gobjForm.FindName("lblTitulo32") as Label;
            gobjTitulo33 = gobjForm.FindName("lblTitulo33") as Label;
            gobjTitulo41 = gobjForm.FindName("lblTitulo41") as Label;
            gobjTitulo42 = gobjForm.FindName("lblTitulo42") as Label;
            gobjTitulo43 = gobjForm.FindName("lblTitulo43") as Label;
            gobjTitulo44 = gobjForm.FindName("lblTitulo44") as Label;
            //- Otros
            gcrIndiceActivo = fcrIndiceActivo();
            gcrTotCamposIndiceAct = fcrTotalCamposIndiceActivo();
        }
        #endregion
        #region Indice seleccionado y Actviar Tab
        //-----------------------------------
        //- Devolver Indice Actviar Tab
        //-----------------------------------
        public String fcrIndiceActivo() 
        {
            ComboItem gobIndice = (ComboItem)gobListBoxIndices.SelectedItem as ComboItem;
            if (gobIndice != null)
            {
                string gcrIndActivo = gobIndice.IdIndice;
                return gcrIndActivo;
            }
            return "";
        }

        //-----------------------------------
        //- Devolver total campos del Indice activo
        //-----------------------------------
        public String fcrTotalCamposIndiceActivo()
        {
            ComboItem gobIndice = (ComboItem)gobListBoxIndices.SelectedItem as ComboItem;
            if (gobIndice != null)
            {
                string gcrTotal = gobIndice.TotalCampos.ToString();
                return gcrTotal;
            }
            return "";
        }

        //-----------------------------------
        //- Activar Tab 
        //-----------------------------------
        public void fcvActivarTab(string tcrNombreTab)
        {
            // limpiar controles para escribir
            gobjTextBox11.Text=string.Empty;
            gobjTextBox21.Text=string.Empty;
            gobjTextBox22.Text=string.Empty;
            gobjTextBox31.Text=string.Empty;
            gobjTextBox32.Text=string.Empty;
            gobjTextBox33.Text=string.Empty;
            gobjTextBox41.Text=string.Empty;
            gobjTextBox42.Text=string.Empty;
            gobjTextBox43.Text=string.Empty;
            gobjTextBox44.Text=string.Empty;
            // Activar el Tab
            ComboItem lobIndice = (ComboItem)gobListBoxIndices.SelectedItem as ComboItem;
            gobjTabControl.SelectedItem = (TabItem)gobjTabControl.FindName(tcrNombreTab);

            switch (gcrTotCamposIndiceAct)
            {
                case "1":
                    gobjTitulo11.Content = lobIndice.Titulos[0].ToString();
                    gobjTextBox11.Focus();
                    break;

                case "2":
                    gobjTitulo21.Content = lobIndice.Titulos[0].ToString();
                    gobjTitulo22.Content = lobIndice.Titulos[1].ToString();
                    gobjTextBox21.Focus();
                    break;

                case "3":
                    gobjTitulo31.Content = lobIndice.Titulos[0].ToString();
                    gobjTitulo32.Content = lobIndice.Titulos[1].ToString();
                    gobjTitulo33.Content = lobIndice.Titulos[2].ToString();
                    gobjTextBox31.Focus();
                    break;

                case "4":
                    gobjTitulo41.Content = lobIndice.Titulos[0].ToString();
                    gobjTitulo42.Content = lobIndice.Titulos[1].ToString();
                    gobjTitulo43.Content = lobIndice.Titulos[2].ToString();
                    gobjTitulo44.Content = lobIndice.Titulos[3].ToString();
                    gobjTextBox41.Focus();
                    break;
            }
        }

        //-----------------------------------
        //- Devolver el nombre del tab Activo
        //-----------------------------------
        public String fcrNombreTabActivo()
        {
            TabItem lobPagina = gobjTabControl.SelectedItem as TabItem;
            gcrTabActivo = lobPagina.Name.ToString();
            return gcrTabActivo;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using Sistema.Utilidades;
using Sistema.Modelo;

namespace GestorReportes.Vista
{
    /// <summary>
    /// <para>Mantiene y actualiza las propiedades del objeto Actvio que fue seleccionado con click para </para>
    /// <para>reajustar tamaño o propiedades.</para>
    /// </summary>
    public class ObjetoActivo : ViewModelBase, IDataErrorInfo
    {
        public Window gobjForm;
        public UIElement gobRefObjeto;
        public string gcrCodigoModulo;
        public string gcrTabla;
        public string gcrTabActivo;
        public string gcrIndiceActivo;
        public string gcrTotCamposIndiceAct;
        public int gnuIdIndiceInicial;
        public ListView gobDataGrid;
        public GridView gobGridView;
        public ComboBox gobListBoxIndices;
        public string gcrFiltroTabla;
        public List<ComboItem> gclListaIndices;

        //------------------------------------------------
        //-Variables Control Edicion 
        //------------------------------------------------
        #region Vista Modelo Propiedad: glgSIS_ModoEdicion
        /// <summary>
        /// glgSIS_ModoEdicion: Variable para el control del modo
        /// Edicion del Vista Modelo.
        /// </summary>
        public string glgNomProp_SIS_ModoEdicion = "GlgSIS_ModoEdicion";
        private bool _glgSIS_ModoEdicion = false;
        public bool GlgSIS_ModoEdicion
        {
            get { return _glgSIS_ModoEdicion; }
            set
            {
                if (_glgSIS_ModoEdicion == value) { return; }
                _glgSIS_ModoEdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdicion);
            }
        }
        #endregion

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
            public string campo15 { get; set; }
            public string campo16 { get; set; }
            public string campo17 { get; set; }
            public string campo18 { get; set; }
            public string campo19 { get; set; }
            public string campo20 { get; set; }
        }
        #endregion

        //-----------------------------------
        //- Clase para Cargar lista de Indices 
        //-----------------------------------
        #region para Cargar lista de indices
        public class ComboItem
        {
            public ComboItem() { } 
            public string IdIndice { get; set; }
            public string NombreIndice { get; set; }
            public int TotalCampos { get; set; }
            public List<string> Titulos { get; set; }
        }
        #endregion
        //-------------------------------------------------
        // Implementacion para validacion
        //-------------------------------------------------
        #region Implementacion para validacion
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string tcrNombrePropiedad]
        {
            get
            {
                string lcrResult = string.Empty;
                if (GlgSIS_ModoEdicion == true)
                {
                    lcrResult = fcrValidacion(tcrNombrePropiedad);
                }
                return lcrResult;
            }
        }
        #endregion
        //-------------------------------------------------
        // Validacion de campos
        //-------------------------------------------------
        #region Validacion de Campos
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public virtual string fcrValidacion(string tcrNombrePropiedad)
        {
            // Para implementacion en la subclase
            return string.Empty;
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
            //- Otros
            gcrIndiceActivo = fcrIndiceActivo();
            gcrTotCamposIndiceAct = fcrTotalCamposIndiceActivo();
        }
        #endregion

        #region Indice seleccionado y Actviar Tab
        //-----------------------------------
        //- Devolver Indice Actviar Tab
        //-----------------------------------
        public string fcrIndiceActivo() 
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
        public string fcrTotalCamposIndiceActivo()
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
            switch (gcrTotCamposIndiceAct)
            {
                case "1":
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    break;
            }
        }
        #endregion
    }
}

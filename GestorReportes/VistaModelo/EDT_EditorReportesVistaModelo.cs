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
using System.Windows.Media;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;
using Sistema.Utilidades;
using Sistema.Modelo;
using GestorReportes.Utilidades;

namespace GestorReportes.VistaModelo
{
    /// <summary>
    /// <para>Mantiene y actualiza las propiedades del objeto Actvio que fue seleccionado con click para </para>
    /// <para>reajustar tamaño o propiedades.</para>
    /// </summary>
    public class VistaModeloObjetoActivo : ViewModelBase, IDataErrorInfo
    {
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        public Window gobjRefForm;
        public UIElement gobRefPagina;
        public UIElement gobRefObjeto;

        // Para control modificacion desde ventan propiedades
        public bool glgSiValidPropiedadObjeto = false;
        public String gcrValidPropDistribucion = "1111"; //Alto,Ancho,Ajuste Izquierda y Ajuste Arriba
        // referencia al puntero de gestion cambios (deshacer cambios en objetos)
        public int gnuTopeIdAccionEdicion = 0;
        public int gnuIdAccionEdicionPuntero = 0;

        #region Metodo instancia Publica
        public VistaModeloObjetoActivo()
        {
            gobRefPagina = null;
            gobRefObjeto = null;
            fcvGridReiniVariables("A");
            fcvIniciarComboBox();
            fcvRegistrarComandos();
        }
        #endregion

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
        //------------------------------------------------
        //-Variables Control Edicion 
        //------------------------------------------------
        #region Vista Modelo Propiedad: glgSIS_ModoEdicion
        public String glgNomProp_SIS_ModoEdicion = "GlgSIS_ModoEdicion";
        private bool _glgSIS_ModoEdicion = false;
        /// <summary>
        /// glgSIS_ModoEdicion: Variable para el control del modo
        /// Edicion del Vista Modelo.
        /// </summary>
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
        #region Vista Modelo Propiedad: gcrPropValorProgressBar
        /// <summary>
        /// PropValorProgressBar: valor avance de la barra de progreso
        /// </summary>
        public string glgNomProp_PropValorProgressBar = "gnuPropValorProgressBar";
        private int _propValorProgressBar = 0;
        public int gnuPropValorProgressBar
        {
            get { return _propValorProgressBar; }
            set
            {
                if (_propValorProgressBar == value) { return; }
                _propValorProgressBar = value;
                RaisePropertyChanged(glgNomProp_PropValorProgressBar);
            }
        }
        #endregion
        #region gcrTipoContenedorActivo: Tipo contenedor seleccionado
        public const String gcrNomProp_TipoContenedorActivo = "gcrTipoContenedorActivo";
        private String _TipoContenedorActivo = String.Empty;
        /// <summary>
        /// <para>Tipo contenedor activo en la vista para recibir objetos</para>
        /// </summary>
        public String gcrTipoContenedorActivo
        {
            get { return _TipoContenedorActivo; }
            set
            {
                if (_TipoContenedorActivo == value) return;
                _TipoContenedorActivo = value;
                RaisePropertyChanged(gcrNomProp_TipoContenedorActivo);
            }
        }
        #endregion
        #region PropNotifCambioListView: Notificar cual ListView fue actualizado
        public const String gcrNomProp_CambioListView = "PropNotifCambioListView";
        private String _cambioListView = String.Empty;
        /// <summary>
        /// <para>Notificar cual ListView fue actualizado</para>
        /// </summary>
        public String PropNotifCambioListView
        {
            get { return _cambioListView; }
            set
            {
                if (_cambioListView == value) return;
                _cambioListView = value;
                RaisePropertyChanged(gcrNomProp_CambioListView);
            }
        }
        #endregion
        #region glgPuedeEditarItemsComboBox: Variable control ComboBox edicion
        public String glgNomPropPuedeEditarItemsComboBox = "glgPuedeEditarItemsComboBox";
        private bool _glgSISPuedeEditarItemsComboBox = false;
        /// <summary>
        /// <para>Control activacion objetos texto para editar valores item ComboBox</para>
        /// </summary>
        public bool glgPuedeEditarItemsComboBox
        {
            get { return _glgSISPuedeEditarItemsComboBox; }
            set
            {
                if (_glgSISPuedeEditarItemsComboBox == value) { return; }
                _glgSISPuedeEditarItemsComboBox = value;
                RaisePropertyChanged(glgNomPropPuedeEditarItemsComboBox);
            }
        }
        #endregion
        #region glgPuedeEditarItemsEtiqueta: Variable control Etiquetas edicion
        public String glgNomPropPuedeEditarItemsEtiqueta = "glgPuedeEditarItemsEtiqueta";
        private bool _glgSISPuedeEditarItemsEtiqueta = false;
        /// <summary>
        /// <para>Control activacion objetos texto para editar valores item Etiquetas</para>
        /// </summary>
        public bool glgPuedeEditarItemsEtiqueta
        {
            get { return _glgSISPuedeEditarItemsEtiqueta; }
            set
            {
                if (_glgSISPuedeEditarItemsEtiqueta == value) { return; }
                _glgSISPuedeEditarItemsEtiqueta = value;
                RaisePropertyChanged(glgNomPropPuedeEditarItemsEtiqueta);
            }
        }
        #endregion
        //------------------------------------------------
        //- TXT - Popideades del objetos seleccionado
        //------------------------------------------------
        #region Propiedades Básicas
        #region PropTxtName: Nombre Interno del Objeto
        public const string gcrNomProp_PropTxtName = "PropTxtName";
        private string _propTxtName = string.Empty;
        /// <summary>
        /// <para>Nombre Interno del Objeto seleccionado</para>
        /// </summary>
        public string PropTxtName
        {
            get { return _propTxtName; }
            set
            {
                if (_propTxtName == value) return;
                _propTxtName = value;
                RaisePropertyChanged(gcrNomProp_PropTxtName);
            }
        }
        #endregion
        #region PropTxtTitulo: Titulo en vista del Objeto
        public const string gcrNomProp_PropTxtTitulo = "PropTxtTitulo";
        private string _propTxtTitulo = string.Empty;
        /// <summary>
        /// <para>Titulo en vista del Objeto</para>
        /// </summary>
        public string PropTxtTitulo
        {
            get { return _propTxtTitulo; }
            set
            {
                if (_propTxtTitulo == value) return;
                _propTxtTitulo = value;
                RaisePropertyChanged(gcrNomProp_PropTxtTitulo);
            }
        }
        #endregion
        #region PropTxtTituloVisible: Mostrar / Ocultar Titulo objeto
        public const string gcrNomProp_PropTxtTituloVisible = "PropTxtTituloVisible";
        private string _propTxtTituloVisible = string.Empty;
        /// <summary>
        /// <para>Mostrar / Ocultar Titulo objeto (cuando exista => true/False)</para>
        /// </summary>
        public string PropTxtTituloVisible
        {
            get { return _propTxtTituloVisible; }
            set
            {
                if (_propTxtTituloVisible == value) return;
                _propTxtTituloVisible = value;
                RaisePropertyChanged(gcrNomProp_PropTxtTituloVisible);
            }
        }
        #endregion
        #region PropTxtTipoObjeto: Tipo Objeto TextBox,ComboBox,Listbox... (independiene de su ClaseBase real)
        public const string gcrNomProp_PropTxtTipoObjeto = "PropTxtTipoObjeto";
        private string _propTxtTipoObjeto = string.Empty;
        /// <summary>
        /// <para>Tipo objeto: TextBox,ComboBox,Calendario,Hora,Imagen,Odontograma,Listbox...(independiene de su ClaseBase real)</para>
        /// <para>Es  </para>
        /// </summary>
        public string PropTxtTipoObjeto
        {
            get { return _propTxtTipoObjeto; }
            set
            {
                if (_propTxtTipoObjeto == value) return;
                _propTxtTipoObjeto = value;
                RaisePropertyChanged(gcrNomProp_PropTxtTipoObjeto);
            }
        }
        #endregion
        #region PropTxtClaseBase: Clase base real del Objeto TextBox,ComboBox,Listbox 
        public const string gcrNomProp_PropTxtClaseBase = "PropTxtClaseBase";
        private string _propTxtClaseBase = string.Empty;
        /// <summary>
        /// <para>Clase base real del Objeto TextBox,ComboBox,Listbox</para>
        /// </summary>
        public string PropTxtClaseBase
        {
            get { return _propTxtClaseBase; }
            set
            {
                if (_propTxtClaseBase == value) return;
                _propTxtClaseBase = value;
                RaisePropertyChanged(gcrNomProp_PropTxtClaseBase);
            }
        }
        #endregion
        #region PropTxtParent: Referencia al nombre objeto contenedor de nivel superior
        public const string gcrNomProp_PropTxtParent = "PropTxtParent";
        private string _propTxtParent = string.Empty;
        /// <summary>
        /// <para>Referencia al nombre objeto contenedor de nivel superior</para>
        /// </summary>
        public string PropTxtParent
        {
            get { return _propTxtParent; }
            set
            {
                if (_propTxtParent == value) return;
                _propTxtParent = value;
                RaisePropertyChanged(gcrNomProp_PropTxtParent);
            }
        }
        #endregion
        #region PropTxtTabIndex: Orden de Visualizacion y tabulacion de Objeto 
        public const string gcrNomProp_PropTxtTabIndex = "PropTxtTabIndex";
        private string _propTxtTabIndex = string.Empty;
        /// <summary>
        /// <para> Orden Cargue, Visualizacion y Tabulacion en vista</para>
        /// </summary>
        public string PropTxtTabIndex
        {
            get { return _propTxtTabIndex; }
            set
            {
                if (_propTxtTabIndex == value) return;
                _propTxtTabIndex = value;
                RaisePropertyChanged(gcrNomProp_PropTxtTabIndex);
            }
        }
        #endregion
        #region PropTxtPagina: Numero de la pagina donde esta anclado el objeto 
        public const string gcrNomProp_PropTxtPagina = "PropTxtPagina";
        private string _propTxtPagina = string.Empty;
        /// <summary>
        /// <para>Numero de la pagina donde esta anclado el objeto</para>
        /// </summary>
        public string PropTxtPagina
        {
            get { return _propTxtPagina; }
            set
            {
                if (_propTxtPagina == value) return;
                _propTxtPagina = value;
                RaisePropertyChanged(gcrNomProp_PropTxtPagina);
            }
        }
        #endregion
        #region PropTxtFocusable: Permitir que el objeto reciba enfoque "True/False"
        public const string gcrNomProp_PropTxtFocusable = "PropTxtFocusable";
        private string _propTxtFocusable = string.Empty;
        /// <summary>
        /// <para>Permitir que el objeto reciba enfoque "True/False"</para>
        /// </summary>
        public string PropTxtFocusable
        {
            get { return _propTxtFocusable; }
            set
            {
                if (_propTxtFocusable == value) return;
                _propTxtFocusable = value;
                RaisePropertyChanged(gcrNomProp_PropTxtFocusable);
            }
        }
        #endregion
        #region PropTxtCambiarTabs: Para Saber si se incluye en lista visual para cambiar orden de visualizacion y tabs (manejo interno) 
        public const string gcrNomProp_PropTxtCambiarTabs = "PropTxtCambiarTabs";
        private string _propTxtCambiarTabs = string.Empty;
        /// <summary>
        /// <para>Para Saber si se incluye en lista visual para cambiar orden de visualizacion y tabs (manejo interno) </para>
        /// </summary>
        public string PropTxtCambiarTabs
        {
            get { return _propTxtCambiarTabs; }
            set
            {
                if (_propTxtCambiarTabs == value) return;
                _propTxtCambiarTabs = value;
                RaisePropertyChanged(gcrNomProp_PropTxtCambiarTabs);
            }
        }
        #endregion
        #region PropTxtIsEnabled: Configurar estado del objeto Activo/inactivo "True/False"
        public const string gcrNomProp_PropTxtIsEnabled = "PropTxtIsEnabled";
        private string _propTxtIsEnabled = string.Empty;
        /// <summary>
        /// <para>Configurar estado del objeto Activo/inactivo "True/False"</para>
        /// </summary>
        public string PropTxtIsEnabled
        {
            get { return _propTxtIsEnabled; }
            set
            {
                if (_propTxtIsEnabled == value) return;
                _propTxtIsEnabled = value;
                RaisePropertyChanged(gcrNomProp_PropTxtIsEnabled);
            }
        }
        #endregion
        #region PropTxtVisibility: Configurar estado del objeto Visible/Oculto "True/False"
        public const string gcrNomProp_PropTxtVisibility = "PropTxtVisibility";
        private string _propTxtVisibility = string.Empty;
        /// <summary>
        /// <para>Configurar estado del objeto Visible/Oculto "True/False"</para>
        /// </summary>
        public string PropTxtVisibility
        {
            get { return _propTxtVisibility; }
            set
            {
                if (_propTxtVisibility == value) return;
                _propTxtVisibility = value;
                RaisePropertyChanged(gcrNomProp_PropTxtVisibility);
            }
        }
        #endregion
        #endregion
        #region Propiedades Apariencia
        #region PropTxtVerticalAlignment: Alineacion vertical del objeto seleccionado
        public const string gcrNomProp_PropTxtVerticalAlignment = "PropTxtVerticalAlignment";
        private string _propTxtVerticalAlignment = string.Empty;
        /// <summary>
        /// <para>Valor Alineacion vertical del objeto seleccionado</para>
        /// </summary>
        public string PropTxtVerticalAlignment
        {
            get { return _propTxtVerticalAlignment; }
            set
            {
                if (_propTxtVerticalAlignment == value) return;
                _propTxtVerticalAlignment = value;
                RaisePropertyChanged(gcrNomProp_PropTxtVerticalAlignment);
            }
        }
        #endregion
        #region PropTxtHorizontalAlignment: Alineacion horizontal del objeto seleccionado
        public const string gcrNomProp_PropTxtHorizontalAlignment = "PropTxtHorizontalAlignment";
        private string _propTxtHorizontalAlignment = string.Empty;
        /// <summary>
        /// <para>Valor Alineacion horizontal del objeto seleccionado</para>
        /// </summary>
        public string PropTxtHorizontalAlignment
        {
            get { return _propTxtHorizontalAlignment; }
            set
            {
                if (_propTxtHorizontalAlignment == value) return;
                _propTxtHorizontalAlignment = value;
                RaisePropertyChanged(gcrNomProp_PropTxtHorizontalAlignment);
            }
        }
        #endregion
        #region PropTxtStyle: Referencia al nombre del recurso de estilo para objeto
        public const string gcrNomProp_PropTxtStyle = "PropTxtStyle";
        private string _propTxtStyle = string.Empty;
        /// <summary>
        /// <para>Referencia al nombre del recurso de estilo para objeto</para>
        /// </summary>
        public string PropTxtStyle
        {
            get { return _propTxtStyle; }
            set
            {
                if (_propTxtStyle == value) return;
                _propTxtStyle = value;
                RaisePropertyChanged(gcrNomProp_PropTxtStyle);
            }
        }
        #endregion
        #region PropTxtMargin: Ajuste margenes del objeto
        public const string gcrNomProp_PropTxtMargin = "PropTxtStyle";
        private string _propTxtMargin = string.Empty;
        /// <summary>
        /// <para>Ajuste margenes del objeto</para>
        /// </summary>
        public string PropTxtMargin
        {
            get { return _propTxtMargin; }
            set
            {
                if (_propTxtMargin == value) return;
                _propTxtMargin = value;
                RaisePropertyChanged(gcrNomProp_PropTxtMargin);
            }
        }
        #endregion
        #region PropTxtBorder: lista Border Mostrar / Ocultar Bordes al Objeto (desde 0 hasta 8)
        public const string gcrNomProp_PropTxtBorder = "PropTxtBorder";
        private string _propTxtBorder = string.Empty;
        /// <summary>
        /// <para>PropTxtBorder: Mostrar / Ocultar Bordes al Objeto "1" = Si "0"=No</para>
        /// </summary>
        public string PropTxtBorder
        {
            get { return _propTxtBorder; }
            set
            {
                if (_propTxtBorder == value) return;
                _propTxtBorder = value;
                RaisePropertyChanged(gcrNomProp_PropTxtBorder);
            }
        }
        #endregion
        #region PropTxtForeground: Color del Primer plano del texto
        public const string gcrNomProp_PropTxtForeground = "PropTxtForeground";
        private string _propTxtForeground = string.Empty;
        /// <summary>
        /// <para>Color del Primer plano del texto</para>
        /// </summary>
        public string PropTxtForeground
        {
            get { return _propTxtForeground; }
            set
            {
                if (_propTxtForeground == value) return;
                _propTxtForeground = value;
                RaisePropertyChanged(gcrNomProp_PropTxtForeground);
            }
        }
        #endregion
        #region PropTxtBorderBrush: Color del borde
        public const string gcrNomProp_PropTxtBorderBrush = "PropTxtBorderBrush";
        private string _propTxtBorderBrush = string.Empty;
        /// <summary>
        /// <para>Color del borde</para>
        /// </summary>
        public string PropTxtBorderBrush
        {
            get { return _propTxtBorderBrush; }
            set
            {
                if (_propTxtBorderBrush == value) return;
                _propTxtBorderBrush = value;
                RaisePropertyChanged(gcrNomProp_PropTxtBorderBrush);
            }
        }
        #endregion
        #region PropTxtBackground: Color del fondo
        public const string gcrNomProp_PropTxtBackground = "PropTxtBackground";
        private string _propTxtBackground = string.Empty;
        /// <summary>
        /// <para>Color del fondo</para>
        /// </summary>
        public string PropTxtBackground
        {
            get { return _propTxtBackground; }
            set
            {
                if (_propTxtBackground == value) return;
                _propTxtBackground = value;
                RaisePropertyChanged(gcrNomProp_PropTxtBackground);
            }
        }
        #endregion
        #region PropTxtHeight: Valor alto del objeto
        public const string gcrNomProp_PropTxtHeight = "PropTxtHeight";
        private string _propTxtHeight = string.Empty;
        /// <summary>
        /// <para>Valor alto del objeto</para>
        /// </summary>
        public string PropTxtHeight
        {
            get { return _propTxtHeight; }
            set
            {
                if (_propTxtHeight == value) return;
                _propTxtHeight = value;
                RaisePropertyChanged(gcrNomProp_PropTxtHeight);
            }
        }
        #endregion
        #region PropTxtWidth: Valor ancho del objeto
        public const string gcrNomProp_PropTxtWidth = "PropTxtWidth";
        private string _propTxtWidth = string.Empty;
        /// <summary>
        /// <para>Valor ancho del objeto</para>
        /// </summary>
        public string PropTxtWidth
        {
            get { return _propTxtWidth; }
            set
            {
                if (_propTxtWidth == value) return;
                _propTxtWidth = value;
                RaisePropertyChanged(gcrNomProp_PropTxtWidth);
            }
        }
        #endregion
        #region PropTxtLeft: Valor ajuste a la Izquierda 
        public const string gcrNomProp_PropTxtLeft = "PropTxtLeft";
        private string _propTxtLeft = string.Empty;
        /// <summary>
        /// <para>Valor ajuste a la izquierda</para>
        /// </summary>
        public string PropTxtLeft
        {
            get { return _propTxtLeft; }
            set
            {
                if (_propTxtLeft == value) return;
                _propTxtLeft = value;
                RaisePropertyChanged(gcrNomProp_PropTxtLeft);
            }
        }
        #endregion
        #region PropTxtTop: Valor ajuste Arriba
        public const string gcrNomProp_PropTxtTop = "PropTxtTop";
        private string _propTxtTop = string.Empty;
        /// <summary>
        /// <para>Valor ajuste Arriba</para>
        /// </summary>
        public string PropTxtTop
        {
            get { return _propTxtTop; }
            set
            {
                if (_propTxtTop == value) return;
                _propTxtTop = value;
                RaisePropertyChanged(gcrNomProp_PropTxtTop);
            }
        }
        #endregion
        #region PropTxtFontFamily: Tipo fuente (texto) segun tipos existentes en el sistema
        public const string gcrNomProp_PropTxtFontFamily = "PropTxtFontFamily";
        private string _propTxtFontFamily = string.Empty;
        /// <summary>
        /// <para>Tipo fuente (texto) segun tipos existentes en el sistema</para>
        /// </summary>
        public string PropTxtFontFamily
        {
            get { return _propTxtFontFamily; }
            set
            {
                if (_propTxtFontFamily == value) return;
                _propTxtFontFamily = value;
                RaisePropertyChanged(gcrNomProp_PropTxtFontFamily);
            }
        }
        #endregion
        #region PropTxtFontStyle: Estilo de la fuente  Italic Normal o Cursiva
        public const string gcrNomProp_PropTxtFontStyle = "PropTxtFontStyle";
        private string _propTxtFontStyle = string.Empty;
        /// <summary>
        /// <para>Estilo de la fuente Italic Normal o Cursiva</para>
        /// </summary>
        public string PropTxtFontStyle
        {
            get { return _propTxtFontStyle; }
            set
            {
                if (_propTxtFontStyle == value) return;
                _propTxtFontStyle = value;
                RaisePropertyChanged(gcrNomProp_PropTxtFontStyle);
            }
        }
        #endregion
        #region PropTxtFontWeight: Estilo Negrita o Normal (FontWeight)
        public const string gcrNomProp_PropTxtFontWeight = "PropTxtFontWeight";
        private string _propTxtFontWeight = string.Empty;
        /// <summary>
        /// <para>Estilo Negrita o Normal (FontWeight)</para>
        /// </summary>
        public string PropTxtFontWeight
        {
            get { return _propTxtFontWeight; }
            set
            {
                if (_propTxtFontWeight == value) return;
                _propTxtFontWeight = value;
                RaisePropertyChanged(gcrNomProp_PropTxtFontWeight);
            }
        }
        #endregion
        #region PropTxtFontTextDecorations: Estilo Subrayado o tachado (TextDecorations)
        public const string gcrNomProp_PropTxtFontDecorations = "PropTxtFontDecorations";
        private string _propTxtFontDecorations = string.Empty;
        /// <summary>
        /// <para>Estilo Subrayado o tachado (TextDecorations)</para>
        /// </summary>
        public string PropTxtFontDecorations
        {
            get { return _propTxtFontDecorations; }
            set
            {
                if (_propTxtFontDecorations == value) return;
                _propTxtFontDecorations = value;
                RaisePropertyChanged(gcrNomProp_PropTxtFontDecorations);
            }
        }
        #endregion
        #region PropTxtFontSize: Tamaño de la fuente (desde una lista del sistema)
        public const string gcrNomProp_PropTxtFontSize = "PropTxtFontSize";
        private string _propTxtFontSize = string.Empty;
        /// <summary>
        /// <para>Tamaño de la fuente (desde una lista del sistema)</para>
        /// </summary>
        public string PropTxtFontSize
        {
            get { return _propTxtFontSize; }
            set
            {
                if (_propTxtFontSize == value) return;
                _propTxtFontSize = value;
                RaisePropertyChanged(gcrNomProp_PropTxtFontSize);
            }
        }
        #endregion
        #region PropTxtOrientacion: Orientacion de la Pagina Horizontal/Vertical (solo para paginas)
        public const string gcrNomProp_PropTxtOrientacion = "PropTxtOrientacion";
        private string _propTxtOrientacion = string.Empty;
        /// <summary>
        /// <para>Orientacion de la Pagina Horizontal/Vertical (solo para paginas)</para>
        /// </summary>
        public string PropTxtOrientacion
        {
            get { return _propTxtOrientacion; }
            set
            {
                if (_propTxtOrientacion == value) return;
                _propTxtOrientacion = value;
                RaisePropertyChanged(gcrNomProp_PropTxtOrientacion);
            }
        }
        #endregion
        #region PropTxtAngulo: Angulo de rotacion del objeto (no aplica para la pagina) Ejemplo "0.5,0.5"
        public const string gcrNomProp_PropTxtAngulo = "PropTxtAngulo";
        private string _propTxtAngulo = string.Empty;
        /// <summary>
        /// <para>Angulo de rotacion del objeto (no aplica para la pagina) Ejemplo "0.5,0.5"</para>
        /// </summary>
        public string PropTxtAngulo
        {
            get { return _propTxtAngulo; }
            set
            {
                if (_propTxtAngulo == value) return;
                _propTxtAngulo = value;
                RaisePropertyChanged(gcrNomProp_PropTxtAngulo);
            }
        }
        #endregion
        #region PropTxtXmlImagenFondo: XML con las propiedades de la imagen fondo de la pagina (solo para pagina)
        public const String gcrNomProp_PropXmlImagenFondo = "PropTxtXmlImagenFondo";
        private String _propTxtXmlImagenFondo = string.Empty;
        /// <summary>
        /// <para>PropXmlImagenFondo: Texto XML con propiedades de la imagen fondo de la pagina (solo para pagina)</para>
        /// </summary>
        public String PropTxtXmlImagenFondo
        {
            get { return _propTxtXmlImagenFondo; }
            set
            {
                if (_propTxtXmlImagenFondo == value) return;
                _propTxtXmlImagenFondo = value;
                RaisePropertyChanged(gcrNomProp_PropXmlImagenFondo);
            }
        }
        #endregion
        #endregion
        #region Propiedades Datos
        #region PropDatTxtBinding: Campo Binding asociado en la Base de datos
        public const string gcrNomProp_PropDatTxtBinding = "PropDatTxtBinding";
        private string _propDatTxtBinding = string.Empty;
        /// <summary>
        /// <para>PropDatTxtBinding: Campo Binding asociado en la Base de datos</para>
        /// </summary>
        public string PropDatTxtBinding
        {
            get { return _propDatTxtBinding; }
            set
            {
                if (_propDatTxtBinding == value) return;
                _propDatTxtBinding = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtBinding);
            }
        }
        #endregion
        #region PropDatTxtValorDefault: Valor por defecto que toma el campo al Adicionar registro (puede venir de una lista)
        public const string gcrNomProp_PropDatTxtValorDefault = "PropDatTxtValorDefault";
        private string _propDatTxtValorDefault = string.Empty;
        /// <summary>
        /// <para>PropDatTxtValorDefault: Valor por defecto que toma el campo al Adicionar registro.</para>
        /// <para>Cuando el origen es una lista, ValorDefault toma el Index de algun item de esta.</para>
        /// </summary>
        public string PropDatTxtValorDefault
        {
            get { return _propDatTxtValorDefault; }
            set
            {
                if (_propDatTxtValorDefault == value) return;
                _propDatTxtValorDefault = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtValorDefault);
            }
        }
        #endregion
        #region PropDatTxtTotalItems: Numero de opciones cuando es un combobox, radiobutton
        public const string gcrNomProp_PropDatTxtTotalItems = "PropDatTxtTotalItems";
        private string _propDatTxtTotalItems = string.Empty;
        /// <summary>
        /// <para>PropDatTxtTotalItems: Numero de opciones cuando el objeto es un combobox, radiobutton.</para>
        /// <para>Para los demas objetos el valor por defecto es 1.</para>
        /// </summary>
        public string PropDatTxtTotalItems
        {
            get { return _propDatTxtTotalItems; }
            set
            {
                if (_propDatTxtTotalItems == value) return;
                _propDatTxtTotalItems = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtTotalItems);
            }
        }
        #endregion
        #region PropDatTxtTipoDato: Tipo dato que captura el objeto TEXTO,FECHA,MEMO,NUMERICO,FLOTANTE (para manejo interno) 
        public const string gcrNomProp_PropDatTxtTipoDato = "PropDatTxtTipoDato";
        private string _propDatTxtTipoDato = string.Empty;
        /// <summary>
        /// <para>Tipo dato que captura el objeto TEXTO,FECHA,MEMO,NUMERICO,FLOTANTE,HORA (para manejo interno).</para>
        /// </summary>
        public string PropDatTxtTipoDato
        {
            get { return _propDatTxtTipoDato; }
            set
            {
                if (_propDatTxtTipoDato == value) return;
                _propDatTxtTipoDato = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtTipoDato);
            }
        }
        #endregion
        #region PropDatTxtTipoOrigenDatos: COLECCION,TABLA,CAPTURA (para manejo interno) 
        public const string gcrNomProp_PropDatTxtTipoOrigenDatos = "PropDatTxtTipoOrigenDatos";
        private string _propDatTxtTipoOrigenDatos = string.Empty;
        /// <summary>
        /// <para>COLECCION,TABLA,CAPTURA (para manejo interno).</para>
        /// </summary>
        public string PropDatTxtTipoOrigenDatos
        {
            get { return _propDatTxtTipoOrigenDatos; }
            set
            {
                if (_propDatTxtTipoOrigenDatos == value) return;
                _propDatTxtTipoOrigenDatos = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtTipoOrigenDatos);
            }
        }
        #endregion
        #region PropDatTxtTablaOrigen: Tabla origen de datos-> Diagnosticos, Usuarios,Pacientes,Profesionales ...
        public const string gcrNomProp_PropDatTxtTablaOrigen = "PropDatTxtTablaOrigen";
        private string _propDatTxtTablaOrigen = string.Empty;
        /// <summary>
        /// <para>Tabla origen de datos-> Diagnosticos, Usuarios,Pacientes,Profesionales ...</para>
        /// </summary>
        public string PropDatTxtTablaOrigen
        {
            get { return _propDatTxtTablaOrigen; }
            set
            {
                if (_propDatTxtTablaOrigen == value) return;
                _propDatTxtTablaOrigen = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtTablaOrigen);
            }
        }
        #endregion
        #region PropDatTxtRangoInicial: Rango inicial para captura de datos tipo numero o flotante
        public const string gcrNomProp_PropDatTxtRangoInicial = "PropDatTxtRangoInicial";
        private string _propDatTxtRangoInicial = string.Empty;
        /// <summary>
        /// <para>PropDatTxtRangoInicial: Rango inicial para captura de datos tipo numero o flotante.</para>
        /// </summary>
        public string PropDatTxtRangoInicial
        {
            get { return _propDatTxtRangoInicial; }
            set
            {
                if (_propDatTxtRangoInicial == value) return;
                _propDatTxtRangoInicial = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtRangoInicial);
            }
        }
        #endregion
        #region PropDatTxtRangoFinal: Rango final para captura de datos tipo numero o flotante
        public const string gcrNomProp_PropDatTxtRangoFinal = "PropDatTxtRangoFinal";
        private string _propDatTxtRangoFinal = string.Empty;
        /// <summary>
        /// <para>PropDatTxtRangoFinal: Rango final para captura de datos tipo numero o flotante.</para>
        /// </summary>
        public string PropDatTxtRangoFinal
        {
            get { return _propDatTxtRangoFinal; }
            set
            {
                if (_propDatTxtRangoFinal == value) return;
                _propDatTxtRangoFinal = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtRangoFinal);
            }
        }
        #endregion
        // Variables lista ComboBox
        #region PropItemIntIndice: Inidice numerico para organizar Items valores CoboBox
        public const String gcrNomProp_PropItemIntIndice = "PropItemIntIndice";
        private int _propItemIntIndice = 0;
        /// <summary>
        /// <para>Inidice numerico para organizar Items valores CoboBox</para>
        /// </summary>
        public int PropItemIntIndice
        {
            get { return _propItemIntIndice; }
            set
            {
                if (_propItemIntIndice == value) return;
                _propItemIntIndice = value;
                RaisePropertyChanged(gcrNomProp_PropItemIntIndice);
            }
        }
        #endregion
        #region PropItemTxtParent: Referencia al Objeto ComboBox padre
        public const String gcrNomProp_PropItemTxtParent = "PropItemTxtParent";
        private String _propItemTxtParent = String.Empty;
        /// <summary>
        /// <para>Referencia al Objeto ComboBox padre que usara  la lista</para>
        /// </summary>
        public String PropItemTxtParent
        {
            get { return _propItemTxtParent; }
            set
            {
                if (_propItemTxtParent == value) return;
                _propItemTxtParent = value;
                RaisePropertyChanged(gcrNomProp_PropItemTxtParent);
            }
        }
        #endregion
        #region PropItemTxtIndice: Indice secuencial del item dentro del ComboBox
        public const String gcrNomProp_PropItemTxtIndice = "PropItemTxtIndice";
        private String _propItemTxtIndice = String.Empty;
        /// <summary>
        /// <para>Indice secuencial del item dentro del ComboBox</para>
        /// </summary>
        public String PropItemTxtIndice
        {
            get { return _propItemTxtIndice; }
            set
            {
                if (_propItemTxtIndice == value) return;
                _propItemTxtIndice = value;
                RaisePropertyChanged(gcrNomProp_PropItemTxtIndice);
            }
        }
        #endregion
        #region PropItemTxtCodigo: Codigo (valor seleccion) del item dentro del ComboBox
        public const String gcrNomProp_PropItemTxtCodigo = "PropItemTxtCodigo";
        private String _propItemTxtCodigo = String.Empty;
        /// <summary>
        /// <para>Codigo (valor seleccion) del item dentro del ComboBox</para>
        /// </summary>
        public String PropItemTxtCodigo
        {
            get { return _propItemTxtCodigo; }
            set
            {
                if (_propItemTxtCodigo == value) return;
                _propItemTxtCodigo = value;
                RaisePropertyChanged(gcrNomProp_PropItemTxtCodigo);
            }
        }
        #endregion
        #region PropItemTxtDescripcion: Descripcion del item dentro del ComboBox
        public const String gcrNomProp_PropItemTxtDescripcion = "PropItemTxtDescripcion";
        private String _propItemTxtDescripcion = String.Empty;
        /// <summary>
        /// <para>Descripcion del item dentro del ComboBox</para>
        /// </summary>
        public String PropItemTxtDescripcion
        {
            get { return _propItemTxtDescripcion; }
            set
            {
                if (_propItemTxtDescripcion == value) return;
                _propItemTxtDescripcion = value;
                RaisePropertyChanged(gcrNomProp_PropItemTxtDescripcion);
            }
        }
        #endregion
        #region regComboBoxItems: Registro activo de valores para objetos ComboBox
        public const string gcrNomProp_PropDatRegComboBoxItems = "regComboBoxItems";
        private XmlEntorno.ClassXmlComboBoxItems _propDatRegComboBoxItems;
        /// <summary>
        /// <para>Registro activo en gestion Grilla de posibles</para>
        /// <para>valores en ComboBox o Tablas Dinamicas</para>
        /// </summary>
        public XmlEntorno.ClassXmlComboBoxItems regComboBoxItems
        {
            get { return _propDatRegComboBoxItems; }
            set
            {
                if (_propDatRegComboBoxItems == value) return;
                _propDatRegComboBoxItems = value;
                RaisePropertyChanged(gcrNomProp_PropDatRegComboBoxItems);
            }
        }
        #endregion
        #region tmpComboBoxItems: Temporal posibles valores para objetos ComboBox y Tabas Dinamicas
        public const string gcrNomProp_PropDatTempComboBoxItems = "tmpComboBoxItems";
        private List<XmlEntorno.ClassXmlComboBoxItems> _propDatRegListaComboBoxItems;
        /// <summary>
        /// <para> Temporal Grilla posibles valores en ComboBox o Tabas Dinamicas</para>
        /// </summary>
        public List<XmlEntorno.ClassXmlComboBoxItems> tmpComboBoxItems
        {
            get { return _propDatRegListaComboBoxItems; }
            set
            {
                if (_propDatRegListaComboBoxItems == value) return;
                _propDatRegListaComboBoxItems = value;
                RaisePropertyChanged(gcrNomProp_PropDatTempComboBoxItems);
            }
        }
        #endregion
        // Variables lista Etiqetas
        #region PropEtiqIntIndice: Inidice numerico para organizar Items valores CoboBox
        public const String gcrNomProp_PropEtiqIntIndice = "PropEtiqIntIndice";
        private int _propItemEtiqIndice = 0;
        /// <summary>
        /// <para>Inidice numerico para organizar Items valores Etiquetas</para>
        /// </summary>
        public int PropEtiqIntIndice
        {
            get { return _propItemEtiqIndice; }
            set
            {
                if (_propItemEtiqIndice == value) return;
                _propItemEtiqIndice = value;
                RaisePropertyChanged(gcrNomProp_PropEtiqIntIndice);
            }
        }
        #endregion
        #region PropEtiqTxtIndice: Indice unico secuencial de la etiqueta
        public const String gcrNomProp_PropEtiqTxtIndice = "PropEtiqTxtIndice";
        private String _PropEtiqTxtIndice = String.Empty;
        /// <summary>
        /// <para>Indice unico secuencial de la etiqueta</para>
        /// </summary>
        public String PropEtiqTxtIndice
        {
            get { return _PropEtiqTxtIndice; }
            set
            {
                if (_PropEtiqTxtIndice == value) return;
                _PropEtiqTxtIndice = value;
                RaisePropertyChanged(gcrNomProp_PropEtiqTxtIndice);
            }
        }
        #endregion
        #region PropEtiqTxtCodigo: Codigo (valor seleccion) del item etiqueta
        public const String gcrNomProp_PropEtiqTxtCodigo = "PropEtiqTxtCodigo";
        private String _PropEtiqTxtCodigo = String.Empty;
        /// <summary>
        /// <para>Codigo (valor seleccion) del item etiqueta</para>
        /// </summary>
        public String PropEtiqTxtCodigo
        {
            get { return _PropEtiqTxtCodigo; }
            set
            {
                if (_PropEtiqTxtCodigo == value) return;
                _PropEtiqTxtCodigo = value;
                RaisePropertyChanged(gcrNomProp_PropEtiqTxtCodigo);
            }
        }
        #endregion
        #region PropEtiqTxtIcono: Icono que representara el boton etiqueta
        public const String gcrNomProp_PropEtiqTxtIcono = "PropEtiqTxtIcono";
        private String _PropEtiqTxtIcono = String.Empty;
        /// <summary>
        /// <para>Icono que representara el boton etiqueta</para>
        /// </summary>
        public String PropEtiqTxtIcono
        {
            get { return _PropEtiqTxtIcono; }
            set
            {
                if (_PropEtiqTxtIcono == value) return;
                _PropEtiqTxtIcono = value;
                RaisePropertyChanged(gcrNomProp_PropEtiqTxtIcono);
            }
        }
        #endregion
        #region PropEtiqTxtDescripcion: Descripcion del item Etiqueta
        public const String gcrNomProp_PropEtiqTxtDescripcion = "PropEtiqTxtDescripcion";
        private String _PropEtiqTxtDescripcion = String.Empty;
        /// <summary>
        /// <para>Descripcion del item Etiqueta</para>
        /// </summary>
        public String PropEtiqTxtDescripcion
        {
            get { return _PropEtiqTxtDescripcion; }
            set
            {
                if (_PropEtiqTxtDescripcion == value) return;
                _PropEtiqTxtDescripcion = value;
                RaisePropertyChanged(gcrNomProp_PropEtiqTxtDescripcion);
            }
        }
        #endregion
        #region regEtiquetaItems: Registro activo de valores para objetos Etiquetas
        public const string gcrNomProp_PropDatRegEtiquetaItems = "regEtiquetaItems";
        private XmlEntorno.ClassXmlItemEtiquetas _propDatRegEtiquetaItems;
        /// <summary>
        /// <para>Registro activo en gestion Grilla de posibles</para>
        /// <para>etiquetas utilizables en la plantilla</para>
        /// </summary>
        public XmlEntorno.ClassXmlItemEtiquetas regEtiquetaItems
        {
            get { return _propDatRegEtiquetaItems; }
            set
            {
                if (_propDatRegEtiquetaItems == value) return;
                _propDatRegEtiquetaItems = value;
                RaisePropertyChanged(gcrNomProp_PropDatRegEtiquetaItems);
            }
        }
        #endregion
        #region tmpEtiquetaItems: Temporal posibles valores para Objetos etiquetas
        public const string gcrNomProp_PropDatTempEtiquetaItems = "tmpEtiquetaItems";
        private List<XmlEntorno.ClassXmlItemEtiquetas> _propDatRegListaEtiquetaItems;
        /// <summary>
        /// <para>Temporal posibles valores para Objetos etiquetas usables en la plantilla</para>
        /// </summary>
        public List<XmlEntorno.ClassXmlItemEtiquetas> tmpEtiquetaItems
        {
            get { return _propDatRegListaEtiquetaItems; }
            set
            {
                if (_propDatRegListaEtiquetaItems == value) return;
                _propDatRegListaEtiquetaItems = value;
                RaisePropertyChanged(gcrNomProp_PropDatTempEtiquetaItems);
            }
        }
        #endregion
        #endregion
        #region Propiedades Imagen
        #region PropImgTxtCodigoRecursoImagen: Codigo del recurso en la galeria de imagenes (solo para imagenes fijas)
        public const string gcrNomProp_PropImgTxtCodigoRecursoImagen = "PropImgTxtCodigoRecursoImagen";
        private string _propImgTxtCodigoRecursoImagen = string.Empty;
        /// <summary>
        /// <para>Codigo del recurso en la galeria de imagenes (solo para imagenes fijas).</para>
        /// </summary>
        public string PropImgTxtCodigoRecursoImagen
        {
            get { return _propImgTxtCodigoRecursoImagen; }
            set
            {
                if (_propImgTxtCodigoRecursoImagen == value) return;
                _propImgTxtCodigoRecursoImagen = value;
                RaisePropertyChanged(gcrNomProp_PropImgTxtCodigoRecursoImagen);
            }
        }
        #endregion
        #region PropImgTxtUriRecursoImagen: Ruta para buscar y cargar la imagen fija (solo para imagenes fijas)
        public const string gcrNomProp_PropImgTxtUriRecursoImagen = "PropImgTxtUriRecursoImagen";
        private string _propImgTxtUriRecursoImagen = string.Empty;
        /// <summary>
        /// <para>Ruta para buscar y cargar la imagen fija (solo para imagenes fijas).</para>
        /// </summary>
        public string PropImgTxtUriRecursoImagen
        {
            get { return _propImgTxtUriRecursoImagen; }
            set
            {
                if (_propImgTxtUriRecursoImagen == value) return;
                _propImgTxtUriRecursoImagen = value;
                RaisePropertyChanged(gcrNomProp_PropImgTxtUriRecursoImagen);
            }
        }
        #endregion
        #region PropImgTxtNombreRecursoImagen: Nombre del archivo de imagen (solo para imagenes fijas)
        public const string gcrNomProp_PropImgTxtNombreRecursoImagen = "PropImgTxtNombreRecursoImagen";
        private string _propImgTxtNombreRecursoImagen = string.Empty;
        /// <summary>
        /// <para>Nombre del archivo de imagen (solo para imagenes fijas).</para>
        /// </summary>
        public string PropImgTxtNombreRecursoImagen
        {
            get { return _propImgTxtNombreRecursoImagen; }
            set
            {
                if (_propImgTxtNombreRecursoImagen == value) return;
                _propImgTxtNombreRecursoImagen = value;
                RaisePropertyChanged(gcrNomProp_PropImgTxtNombreRecursoImagen);
            }
        }
        #endregion
        #region PropImgTxtStretch: Ajuste de la imagen dentro del objeto imagen
        public const string gcrNomProp_PropImgTxtStretch = "PropImgTxtStretch";
        private string _propImgTxtStretch = string.Empty;
        /// <summary>
        /// <para>Ajuste de la imagen dentro del objeto imagen.</para>
        /// </summary>
        public string PropImgTxtStretch
        {
            get { return _propImgTxtStretch; }
            set
            {
                if (_propImgTxtStretch == value) return;
                _propImgTxtStretch = value;
                RaisePropertyChanged(gcrNomProp_PropImgTxtStretch);
            }
        }
        #endregion
        #region PropImgTxtStretchDirection: Direccion ajuste de la imagen dentro del objeto imagen
        public const string gcrNomProp_PropImgTxtStretchDirection = "PropImgTxtStretchDirection";
        private string _propImgTxtStretchDirection = string.Empty;
        /// <summary>
        /// <para>Direccion ajuste de la imagen dentro del objeto imagen.</para>
        /// </summary>
        public string PropImgTxtStretchDirection
        {
            get { return _propImgTxtStretchDirection; }
            set
            {
                if (_propImgTxtStretchDirection == value) return;
                _propImgTxtStretchDirection = value;
                RaisePropertyChanged(gcrNomProp_PropImgTxtStretchDirection);
            }
        }
        #endregion
        #endregion
        #region Propiedades Varias
        #region PropTxtSiValorCalculado: Saber si el valor que recibe el objeto es calculado "SI"/"NO"
        public const string gcrNomProp_PropTxtSiValorCalculado = "PropTxtSiValorCalculado";
        private string _propTxtSiValorCalculado = string.Empty;
        /// <summary>
        /// <para>Saber si el valor que recibe el objeto es calculado "True"/"False"</para>
        /// </summary>
        public string PropTxtSiValorCalculado
        {
            get { return _propTxtSiValorCalculado; }
            set
            {
                if (_propTxtSiValorCalculado == value) return;
                _propTxtSiValorCalculado = value;
                RaisePropertyChanged(gcrNomProp_PropTxtSiValorCalculado);
            }
        }
        #endregion
        #region PropDatTxtNombreVariable: Nombre de la variable para calcular valores o recibir valor calculado
        public const string gcrNomProp_PropDatTxtNombreVariable = "PropDatTxtNombreVariable";
        private string _propDatTxtNombreVariable = string.Empty;
        /// <summary>
        /// <para>Nombre de la variable para calcular valores o recibir valor calculado</para>
        /// </summary>
        public string PropDatTxtNombreVariable
        {
            get { return _propDatTxtNombreVariable; }
            set
            {
                if (_propDatTxtNombreVariable == value) return;
                _propDatTxtNombreVariable = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtNombreVariable);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //- CBO - Lista para combobox relacionados con Propiedades
        //------------------------------------------------
        #region Lista de combos relacionados con Propiedades
        #region  PropCboVerticalAlignment: Lista valores alineacion Vertical del objeto seleccionado
        public const string gcrNomProp_PropCboVerticalAlignment = "PropCboVerticalAlignment";
        private List<ListaXmlValores> _propCboVerticalAlignment;
        /// <summary>
        /// <para>Lista valores alineacion vertical del objeto seleccionado</para>
        /// </summary>
        public List<ListaXmlValores> PropCboVerticalAlignment
        {
            get { return _propCboVerticalAlignment; }
            set
            {
                if (_propCboVerticalAlignment == value) return;
                _propCboVerticalAlignment = value;
                RaisePropertyChanged(gcrNomProp_PropCboVerticalAlignment);
            }
        }
        #endregion
        #region  PropCboHorizontalAlignment: Lista valores alineacion horizontal del objeto seleccionado
        public const string gcrNomProp_PropCboHorizontalAlignment = "PropCboHorizontalAlignment";
        private List<ListaXmlValores> _propCboHorizontalAlignment;
        /// <summary>
        /// <para>Lista valores alineacion horizontal del objeto seleccionado</para>
        /// </summary>
        public List<ListaXmlValores> PropCboHorizontalAlignment
        {
            get { return _propCboHorizontalAlignment; }
            set
            {
                if (_propCboHorizontalAlignment == value) return;
                _propCboHorizontalAlignment = value;
                RaisePropertyChanged(gcrNomProp_PropCboHorizontalAlignment);
            }
        }
        #endregion
        #region  PropCboBorder: Lista valores Mostrar / Ocultar Bordes al Objeto "1" = Si "0"=No
        public const string gcrNomProp_PropCboPropCboBorder = "PropCboBorder";
        private List<ListaXmlValores> _propCboPropCboBorder;
        /// <summary>
        /// <para>Lista valores Mostrar u Ocultar Bordes al Objeto ("1" = Mostrar / "0" = Ocultar)</para>
        /// </summary>
        public List<ListaXmlValores> PropCboBorder
        {
            get { return _propCboPropCboBorder; }
            set
            {
                if (_propCboPropCboBorder == value) return;
                _propCboPropCboBorder = value;
                RaisePropertyChanged(gcrNomProp_PropCboPropCboBorder);
            }
        }
        #endregion
        #region  PropCboFocusable: Lista valores para permitir que el objeto reciba enfoque "True/False" 
        public const string gcrNomProp_PropCboFocusable = "PropCboFocusable";
        private List<ListaXmlValores> _propCboFocusable;
        /// <summary>
        /// <para>Lista valores para permitir que el objeto reciba enfoque "True/False"</para>
        /// </summary>
        public List<ListaXmlValores> PropCboFocusable
        {
            get { return _propCboFocusable; }
            set
            {
                if (_propCboFocusable == value) return;
                _propCboFocusable = value;
                RaisePropertyChanged(gcrNomProp_PropCboFocusable);
            }
        }
        #endregion
        #region  PropCboIsEnabled: Lista valores para configurar estado objeto activo/inactivo "True/False" 
        public const string gcrNomProp_PropCboIsEnabled = "PropCboIsEnabled";
        private List<ListaXmlValores> _propCboIsEnabled;
        /// <summary>
        /// <para>Lista valores para configurar estado objeto activo/inactivo "True/False"</para>
        /// </summary>
        public List<ListaXmlValores> PropCboIsEnabled
        {
            get { return _propCboIsEnabled; }
            set
            {
                if (_propCboIsEnabled == value) return;
                _propCboIsEnabled = value;
                RaisePropertyChanged(gcrNomProp_PropCboIsEnabled);
            }
        }
        #endregion
        #region  PropCboVisibility: Lista valores para Mostrar / Ocultar el Objeto "True/False" 
        public const string gcrNomProp_PropCboVisibility = "PropCboVisibility";
        private List<ListaXmlValores> _propCboVisibility;
        /// <summary>
        /// <para>Lista valores para Mostrar / Ocultar el Objeto "True/False" </para>
        /// </summary>
        public List<ListaXmlValores> PropCboVisibility
        {
            get { return _propCboVisibility; }
            set
            {
                if (_propCboVisibility == value) return;
                _propCboVisibility = value;
                RaisePropertyChanged(gcrNomProp_PropCboVisibility);
            }
        }
        #endregion
        #region  PropCboSiValorCalculado: Lista Saber si el valor que recibe el objeto es calculado "SI"/"NO"
        public const string gcrNomProp_PropCboSiValorCalculado = "PropCboSiValorCalculado";
        private List<ListaXmlValores> _propCboSiValorCalculado;
        /// <summary>
        /// <para>Lista Saber si el valor que recibe el objeto es calculado "SI"/"NO"</para>
        /// </summary>
        public List<ListaXmlValores> PropCboSiValorCalculado
        {
            get { return _propCboSiValorCalculado; }
            set
            {
                if (_propCboSiValorCalculado == value) return;
                _propCboSiValorCalculado = value;
                RaisePropertyChanged(gcrNomProp_PropCboSiValorCalculado);
            }
        }
        #endregion
        #region  PropCboFontFamily: Lista Tipos de Fuente desde el sistema
        public const string gcrNomProp_PropCboFontFamily = "PropCboFontFamily";
        private List<ListaXmlValores> _propCboFontFamily;
        /// <summary>
        /// <para>Lista de Tipos de Fuente desde el sistema</para>
        /// </summary>
        public List<ListaXmlValores> PropCboFontFamily
        {
            get { return _propCboFontFamily; }
            set
            {
                if (_propCboFontFamily == value) return;
                _propCboFontFamily = value;
                RaisePropertyChanged(gcrNomProp_PropCboFontFamily);
            }
        }
        #endregion
        #region  PropCboFontSize: Lista tamaño de Fuente
        public const string gcrNomProp_PropCboFontSize = "PropCboFontSize";
        private List<ListaXmlValores> _propCboFontSize;
        /// <summary>
        /// <para>Lista tamaño de Fuente</para>
        /// </summary>
        public List<ListaXmlValores> PropCboFontSize
        {
            get { return _propCboFontSize; }
            set
            {
                if (_propCboFontSize == value) return;
                _propCboFontSize = value;
                RaisePropertyChanged(gcrNomProp_PropCboFontSize);
            }
        }
        #endregion
        #region  PropCboTituloVisible: Lista Mostrar / Ocultar Titulo objeto (cuando exista => true/False)
        public const string gcrNomProp_PropCboTituloVisible = "PropCboTituloVisible";
        private List<ListaXmlValores> _propCboTituloVisible;
        /// <summary>
        /// <para>Lista Mostrar / Ocultar Titulo objeto (cuando exista => true/False)</para>
        /// </summary>
        public List<ListaXmlValores> PropCboTituloVisible
        {
            get { return _propCboTituloVisible; }
            set
            {
                if (_propCboTituloVisible == value) return;
                _propCboTituloVisible = value;
                RaisePropertyChanged(gcrNomProp_PropCboTituloVisible);
            }
        }
        #endregion
        #region  PropCboStretch: Lista valores ajuste de la imagen dentro del objeto imagen.
        public const string gcrNomProp_PropCboStretch = "PropCboStretch";
        private List<ListaXmlValores> _propCboStretch;
        /// <summary>
        /// <para>Lista valores ajuste de la imagen dentro del objeto imagen.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboStretch
        {
            get { return _propCboStretch; }
            set
            {
                if (_propCboStretch == value) return;
                _propCboStretch = value;
                RaisePropertyChanged(gcrNomProp_PropCboStretch);
            }
        }
        #endregion
        #region  PropCboStretchDirection: Lista valores Direccion ajuste de la imagen dentro del objeto imagen.
        public const string gcrNomProp_PropCboStretchDirection = "PropCboStretchDirection";
        private List<ListaXmlValores> _propCboStretchDirection;
        /// <summary>
        /// <para>Lista valores direccion ajuste de la imagen dentro del objeto imagen.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboStretchDirection
        {
            get { return _propCboStretchDirection; }
            set
            {
                if (_propCboStretchDirection == value) return;
                _propCboStretchDirection = value;
                RaisePropertyChanged(gcrNomProp_PropCboStretchDirection);
            }
        }
        #endregion
        #region  PropCboTablaOrigen: Lista de Tablas Origen para campos relacionados.
        public const string gcrNomProp_PropCboTablaOrigen = "PropCboTablaOrigen";
        private List<ListaXmlValores> _propCboTablaOrigen;
        /// <summary>
        /// <para>Lista de Tablas Origen para campos relacionados.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboTablaOrigen
        {
            get { return _propCboTablaOrigen; }
            set
            {
                if (_propCboTablaOrigen == value) return;
                _propCboTablaOrigen = value;
                RaisePropertyChanged(gcrNomProp_PropCboTablaOrigen);
            }
        }
        #endregion
        #endregion
        #region  TmpEliminados: para ver los eliminados
        public const string gcrNomProp_PropCboTmpEliminados = "TmpEliminados";
        private List<XmlEntorno.ClassXmlPropObjeto> _propCboTmpEliminados;
        /// <summary>
        /// <para>Lista Mostrar / Ocultar Titulo objeto (cuando exista => true/False)</para>
        /// </summary>
        public List<XmlEntorno.ClassXmlPropObjeto> TmpEliminados
        {
            get { return _propCboTmpEliminados; }
            set
            {
                if (_propCboTmpEliminados == value) return;
                _propCboTmpEliminados = value;
                RaisePropertyChanged(gcrNomProp_PropCboTmpEliminados);
            }
        }
        #endregion
        #region  TmpAccion: para ver los eliminados
        public const string gcrNomProp_PropCboTmpTmpAccion = "TmpAccion";
        private List<XmlEntorno.ClassXmlPropObjeto> _propCboTmpTmpAccion;
        /// <summary>
        /// <para>Acciones en objetos</para>
        /// </summary>
        public List<XmlEntorno.ClassXmlPropObjeto> TmpAccion
        {
            get { return _propCboTmpTmpAccion; }
            set
            {
                if (_propCboTmpTmpAccion == value) return;
                _propCboTmpTmpAccion = value;
                RaisePropertyChanged(gcrNomProp_PropCboTmpTmpAccion);
            }
        }
        #endregion

        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        //Comandos para agregar Lista de ComboBoxItem
        public RelayCommand CmdComboItemSave { get; set; }
        public RelayCommand CmdComboItemNuevo { get; set; }
        public RelayCommand CmdComboItemEliminar { get; set; }
        //Comandos para agregar Lista de Etiquetas
        public RelayCommand CmdEtiquetaSave { get; set; }
        public RelayCommand CmdEtiquetaNuevo { get; set; }
        public RelayCommand CmdEtiquetaEliminar { get; set; }
        //-----------------------------------------------
        public RelayCommand CmdRadioButton { get; set; }
        //- Validacion Valores en Propiedades tipo texto
        public RelayCommand CmdCamposTexto { get; set; }
        //-----------------------------------------------
        // Comandos para Botones add pagina, eliminar objetos, Deshacer, Rehacer 
        public RelayCommand CmdEdtDeshacer { get; set; }
        public RelayCommand CmdEdtRehacer { get; set; }
        public RelayCommand CmdEdtEliminarPagina { get; set; }
        public RelayCommand CmdEdtEliminarObjeto { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            // Botones Items para ComboBox Desplegable
            CmdComboItemNuevo       = new RelayCommand(fcvAccionComboItemNuevo, CanComboItemNuevo); 
            CmdComboItemSave        = new RelayCommand(fcvAccionComboItemSave, CanComboItemSave);       
            CmdComboItemEliminar    = new RelayCommand(fcvAccionComboItemEliminar, CanComboItemEliminar);
            // Botones Items para Grid Etiquetas
            CmdEtiquetaNuevo        = new RelayCommand(fcvAccionEtiquetaNuevo, CanEtiquetaNuevo);
            CmdEtiquetaSave         = new RelayCommand(fcvAccionEtiquetaSave, CanEtiquetaSave);
            CmdEtiquetaEliminar     = new RelayCommand(fcvAccionEtiquetaEliminar, CanEtiquetaEliminar);
            // Activar Botones barra de Herramientas
            CmdRadioButton = new RelayCommand(fcvAccBotones, CanRadioButton);
            CmdCamposTexto = new RelayCommand(fcvAccPropValoresTexto, CanCamposTexto);
            // Comandos para Botones add pagina, eliminar objetos, Deshacer, Rehacer 
            CmdEdtDeshacer = new RelayCommand(fcvAccBotones, CanEdtDeshacer);
            CmdEdtRehacer = new RelayCommand(fcvAccBotones, CanEdtRehacer);
            CmdEdtEliminarPagina = new RelayCommand(fcvAccBotones, CanEliminarPagina);
            CmdEdtEliminarObjeto = new RelayCommand(fcvAccBotones, CanEliminarObjeto);
        }
        #endregion
        //-------------------------------------------------
        // ACCION  COMANDOS
        //-------------------------------------------------
        #region Metodos acciones comandos Pestaña Propieades
        #region fcvAccBotones
        /// <summary>
        /// Accion Botones barra de herramientas
        /// </summary>
        public virtual void fcvAccBotones()
        {
            try
            {
                // accion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccRadioButton");
            }
        }
        #endregion
        #region fcvAccPropValoresTexto
        /// <summary>
        /// Accion propiedades tipo texto 
        /// </summary>
        public virtual void fcvAccPropValoresTexto()
        {
            try
            {
                // accion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccRadioButton");
            }
        }
        #endregion
        #endregion
        #region Metodos acciones comandos Gestion ComboBox y Etiquetas
        //- Gestion Adicionar Items para ComboBox
        #region fcvAccionComboItemNuevo: Adicionar Item para ComboBox
        /// <summary>
        /// Adicionar Item para ComboBox
        /// </summary>
        public void fcvAccionComboItemNuevo()
        {
            try
            {
                fcvGridReiniVariables("I");
                regComboBoxItems.Parent = PropTxtName.Trim();
                regComboBoxItems = new XmlEntorno.ClassXmlComboBoxItems();
                regComboBoxItems.Imaen = "A";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionComboItemNuevo");
            }
        }
        #endregion
        #region fcvAccionComboItemSave: Guardar en temporal item para ComboBox
        /// <summary>
        /// Guardar en temporal item para ComboBox
        /// </summary>
        public void fcvAccionComboItemSave()
        {
            try
            {
                // Cuando es un nuevo registro
                if (String.IsNullOrEmpty(PropItemTxtIndice))
                {
                    PropItemIntIndice = fnuAccionComboItemGenSecuencial();
                    PropItemTxtIndice = PropItemIntIndice.ToString().Trim();
                }
                regComboBoxItems.Parent = PropTxtName.Trim();
                regComboBoxItems.Imaen  = String.IsNullOrEmpty(regComboBoxItems.Imaen) ? "A" : regComboBoxItems.Imaen;

                if (regComboBoxItems.Imaen != "A") { regComboBoxItems.Imaen = "M"; } // es modificado
                fcvGridCargarRegActivoDesdeVariables("I");
                fcvAccionComboItemSaveEx(regComboBoxItems);

                //- Preparar para Adicionar otro
                fcvAccionComboItemNuevo();
                PropNotifCambioListView = "COMBOBOX";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionComboItemSave");
            }
        }
        #endregion
        #region fcvAccionComboItemEliminar: Eliminar datos en temporal Item combobox
        /// <summary>
        /// Eliminar datos en temporal Item combobox
        /// </summary>
        public void fcvAccionComboItemEliminar()
        {
            try
            {
                if (!String.IsNullOrEmpty(PropItemTxtIndice) && regComboBoxItems!=null)
                {
                    regComboBoxItems.Imaen = "I"; // eliminar 
                    fcvAccionComboItemSaveEx(regComboBoxItems);
                    fcvAccionComboItemNuevo();
                    PropNotifCambioListView = "COMBOBOX";
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionComboItemEliminar");
            }
        }
        #endregion
        #region fcvAccionComboItemSaveEx: Guardar los datos en temporal Item combobox
        /// <summary>
        /// Guardar los datos en temporal Item combobox
        /// </summary>
        public void fcvAccionComboItemSaveEx(XmlEntorno.ClassXmlComboBoxItems tobRegistro)
        {
            tmpComboBoxItems.Remove(tobRegistro);
            //- Actualizar en  temporales
            if (tobRegistro.Imaen == "A" || tobRegistro.Imaen == "M")
            {
                tmpComboBoxItems.Add(tobRegistro);
            }
        }
        #endregion
        #region fnuAccionComboItemGenSecuencial: Organizar y generar nuevo secuencial item
        /// <summary>
        /// <para>Organiza y genera los nuevos secuenciales para el temporal de los ComboBox</para>
        /// </summary>
        public int fnuAccionComboItemGenSecuencial()
        {
            var lnuValor = 1;
            foreach (XmlEntorno.ClassXmlComboBoxItems lobReg in tmpComboBoxItems)
            {
                lobReg.IntIndice = lnuValor;
                lnuValor++;
            }
            return lnuValor;
        }
        #endregion
        //- Gestion Adicionar Items para Etiquetas
        #region fcvAccionEtiquetaNuevo: Adicionar Item para Etiquetas
        /// <summary>
        /// Adicionar Item para Etiquetas
        /// </summary>
        public void fcvAccionEtiquetaNuevo()
        {
            try
            {
                fcvGridReiniVariables("E");
                regEtiquetaItems = new XmlEntorno.ClassXmlItemEtiquetas();
                regEtiquetaItems.Imaen = "A";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionEtiquetaNuevo");
            }
        }
        #endregion
        #region fcvAccionEtiquetaSave: Guardar en temporal item para Etiquetas
        /// <summary>
        /// Guardar en temporal item para Etiquetas
        /// </summary>
        public void fcvAccionEtiquetaSave()
        {
            try
            {
                // Cuando es un nuevo registro
                if (String.IsNullOrEmpty(PropEtiqTxtIndice))
                {
                    PropEtiqIntIndice = fnuAccionEtiquetaGenSecuencial();
                    PropEtiqTxtIndice = PropEtiqIntIndice.ToString().Trim();
                }
                regEtiquetaItems.Imaen = String.IsNullOrEmpty(regEtiquetaItems.Imaen) ? "A" : regEtiquetaItems.Imaen;

                if (regEtiquetaItems.Imaen != "A") { regEtiquetaItems.Imaen = "M"; } // es modificado
                fcvGridCargarRegActivoDesdeVariables("E");
                fcvAccionEtiquetaSaveEx(regEtiquetaItems);

                //- Preparar para Adicionar otro
                fcvAccionEtiquetaNuevo();
                PropNotifCambioListView = "ETIQUETAS";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionEtiquetaSave");
            }
        }
        #endregion
        #region fcvAccionEtiquetaEliminar: Eliminar datos en temporal Item Etiquetas
        /// <summary>
        /// Eliminar datos en temporal Item Etiquetas
        /// </summary>
        public void fcvAccionEtiquetaEliminar()
        {
            try
            {
                if (!String.IsNullOrEmpty(PropEtiqTxtIndice) && regEtiquetaItems != null)
                {
                    regEtiquetaItems.Imaen = "I"; // eliminar 
                    fcvAccionEtiquetaSaveEx(regEtiquetaItems);
                    fcvAccionComboItemNuevo();
                    PropNotifCambioListView = "ETIQUETAS";
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionEtiquetaEliminar");
            }
        }
        #endregion
        #region fcvAccionEtiquetaSaveEx: Guardar los datos en temporal Item Etiquetas
        /// <summary>
        /// Guardar los datos en temporal Item Etiquetas
        /// </summary>
        public void fcvAccionEtiquetaSaveEx(XmlEntorno.ClassXmlItemEtiquetas tobRegistro)
        {
            tmpEtiquetaItems.Remove(tobRegistro);
            //- Actualizar en  temporales
            if (tobRegistro.Imaen == "A" || tobRegistro.Imaen == "M")
            {
                tmpEtiquetaItems.Add(tobRegistro);
            }
        }
        #endregion
        #region fnuAccionEtiquetaGenSecuencial: Organizar y generar nuevo secuencial item Etiquetas
        /// <summary>
        /// <para>Organiza y genera los nuevos secuenciales para el temporal de Etiquetas</para>
        /// </summary>
        public int fnuAccionEtiquetaGenSecuencial()
        {
            var lnuValor = 1;
            foreach (XmlEntorno.ClassXmlItemEtiquetas lobReg in tmpEtiquetaItems)
            {
                lobReg.IntIndice = lnuValor;
                lnuValor++;
            }
            return lnuValor;
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // COMANDOS DE ACTIVACION 
        //-------------------------------------------------
        #region Comandos de activacion Pestaña Propieades
        #region CanRadioButton
        /// <summary>
        /// Activar o desactivar comando add RadioButton
        /// </summary>
        public bool CanRadioButton()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && !String.IsNullOrWhiteSpace(PropTxtTipoObjeto))
                {
                    llgReturn = EdtUtilidades.flgSiContenedorAdicionarObjeto(gcrTipoContenedorActivo, "RADIOBUTTON");
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanRadioButton");
            }
            return llgReturn;
        }
        #endregion
        #region CanCamposTexto
        /// <summary>
        /// <para>Validación para propiedades tipo texto al ser modificadas</para>
        /// </summary>
        public virtual bool CanCamposTexto()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && !String.IsNullOrWhiteSpace(PropTxtTipoObjeto))
                {
                    #region Valores Variables
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("PropTxtTitulo")) &&
                                string.IsNullOrEmpty(fcrValidacion("txtPropTxtHeight")) &&
                                string.IsNullOrEmpty(fcrValidacion("PropTxtWidth")) &&
                                string.IsNullOrEmpty(fcrValidacion("PropTxtLeft")) &&
                                string.IsNullOrEmpty(fcrValidacion("PropTxtTop"));
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSAV");
            }
            return llgReturn;
        }
        #endregion
        #endregion
        #region Comandos de activacion Botones gestion ComboBox
        #region CanComboItemNuevo
        /// <summary>
        /// Activar Adicionar nuevo item a lista de combobox 
        /// </summary>
        public bool CanComboItemNuevo()
        {
            bool llgReturn = false;
            try
            {
                glgPuedeEditarItemsComboBox = false;
                if (GlgSIS_ModoEdicion == true && PropTxtTipoObjeto == "COMBOBOX")
                {
                    llgReturn = true;
                    glgPuedeEditarItemsComboBox = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanComboItemNuevos");
            }
            return llgReturn;
        }
        #endregion
        #region CanComboItemSave
        /// <summary>
        /// Activar Guardar nuevo item a lista de combobox 
        /// </summary>
        public bool CanComboItemSave()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && PropTxtTipoObjeto == "COMBOBOX")
                {
                    #region Valores Variables
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("PropItemTxtCodigo")) &&
                                String.IsNullOrEmpty(fcrValidacion("PropItemTxtDescripcion"));
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanComboItemSave");
            }
            return llgReturn;
        }
        #endregion
        #region CanComboItemEliminar
        /// <summary>
        /// Activar Eliminar item a lista de combobox 
        /// </summary>
        public bool CanComboItemEliminar()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && PropTxtTipoObjeto == "COMBOBOX")
                {
                    llgReturn = regComboBoxItems != null ? true : false; 
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanComboItemEliminar");
            }
            return llgReturn;
        }
        #endregion
        #endregion
        #region Comandos de activacion Botones gestion Etiquetas
        #region CanEtiquetaNuevo
        /// <summary>
        /// Activar Adicionar nuevo item a lista de Etiquetas 
        /// </summary>
        public bool CanEtiquetaNuevo()
        {
            bool llgReturn = false;
            try
            {
                glgPuedeEditarItemsEtiqueta = false;
                if (GlgSIS_ModoEdicion == true)
                {
                    llgReturn = true;
                    glgPuedeEditarItemsEtiqueta = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEtiquetaNuevo");
            }
            return llgReturn;
        }
        #endregion
        #region CanEtiquetaSave
        /// <summary>
        /// Activar Guardar nuevo item a lista de combobox 
        /// </summary>
        public bool CanEtiquetaSave()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    #region Valores Variables
                    /*
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("PropEtiqTxtCodigo")) &&
                                String.IsNullOrEmpty(fcrValidacion("PropEtiqTxtIcono")) &&
                                String.IsNullOrEmpty(fcrValidacion("PropEtiqTxtDescripcion"));
                    */
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("PropEtiqTxtCodigo"));
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEtiquetaSave");
            }
            return llgReturn;
        }
        #endregion
        #region CanEtiquetaEliminar
        /// <summary>
        /// Activar Eliminar item en lista de Etiqueta
        /// </summary>
        public bool CanEtiquetaEliminar()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    llgReturn = regEtiquetaItems != null ? true : false;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEtiquetaEliminar");
            }
            return llgReturn;
        }
        #endregion
        #endregion
        #region Comandos de activacion Botones gestion deshacer
        #region CanEdtDeshacer
        /// <summary>
        /// Activar Boton Deshacer hacia atras (felcha a la izquierda)
        /// </summary>
        public bool CanEdtDeshacer()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    if (gnuTopeIdAccionEdicion > 0 && gnuIdAccionEdicionPuntero > 0 && gnuIdAccionEdicionPuntero <= gnuTopeIdAccionEdicion)
                    {
                        llgReturn = true;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEdtDeshacer");
            }
            return llgReturn;
        }
        #endregion
        #region CanEdtRehacer
        /// <summary>
        /// Activar Boton rehacer hacia adelante (flecha a la derecha)
        /// </summary>
        public bool CanEdtRehacer()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    if (gnuTopeIdAccionEdicion > 0  && gnuIdAccionEdicionPuntero < gnuTopeIdAccionEdicion)
                    {
                        llgReturn = true;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEdtRehacer");
            }
            return llgReturn;
        }
        #endregion
        #region CanEliminarPagina
        /// <summary>
        /// Activar Eliminar pagina seleccionada
        /// </summary>
        public bool CanEliminarPagina()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && gobRefPagina != null)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEliminarPagina");
            }
            return llgReturn;
        }
        #endregion
        #region CanEliminarObjeto
        /// <summary>
        /// Activar Eliminar objeto seleccionado
        /// </summary>
        public bool CanEliminarObjeto()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && gobRefObjeto!=null)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEliminarObjeto");
            }
            return llgReturn;
        }
        #endregion
        #endregion

        //-------------------------------------------------
        // Grid GESTION INICIAR VALORES EN VARIABLES GRILLAS
        //-------------------------------------------------
        #region Iniciar Valores de Variables
        #region fcvGridReiniVariables: Reiniciar Variables
        /// <summary>
        /// Reiniciar Variables
        /// tcrGrupo: P=Propiedades, I=Items comboBox E=Etiquetas y A=Todas
        /// </summary>
        public void fcvGridReiniVariables(String tcrGrupo)
        {
            try
            {
                #region Reiniciar Variables Propiedades
                if (tcrGrupo == "P" || tcrGrupo == "A")
                {
                    #region Propiedades Vista modelo
                    // Propiedades Básicas
                    PropTxtName                 = String.Empty;
                    PropTxtTitulo               = String.Empty;
                    PropTxtTituloVisible        = String.Empty;
                    PropTxtTipoObjeto           = String.Empty;
                    PropTxtClaseBase            = String.Empty;
                    PropTxtParent               = String.Empty;
                    PropTxtTabIndex             = String.Empty;
                    PropTxtPagina               = String.Empty;
                    PropTxtCambiarTabs          = String.Empty;
                    PropTxtFocusable            = String.Empty;
                    PropTxtIsEnabled            = String.Empty;
                    PropTxtVisibility           = String.Empty;
                    // Propiedades Apariencia
                    PropTxtVerticalAlignment    = String.Empty;
                    PropTxtHorizontalAlignment  = String.Empty;
                    PropTxtStyle                = String.Empty;
                    PropTxtMargin               = String.Empty;
                    PropTxtBorder               = String.Empty;
                    PropTxtForeground           = String.Empty;
                    PropTxtBorderBrush          = String.Empty;
                    PropTxtBackground           = String.Empty;
                    PropTxtHeight               = String.Empty;
                    PropTxtWidth                = String.Empty;
                    PropTxtTop                  = String.Empty;
                    PropTxtLeft                 = String.Empty;
                    PropTxtFontFamily           = String.Empty;
                    PropTxtFontStyle            = String.Empty;
                    PropTxtFontWeight           = String.Empty;
                    PropTxtFontDecorations      = String.Empty;
                    PropTxtFontSize             = String.Empty;
                    PropTxtOrientacion          = String.Empty;
                    PropTxtAngulo               = String.Empty;
                    // Propiedades Datos
                    PropDatTxtBinding           = String.Empty;
                    PropDatTxtValorDefault      = String.Empty;
                    PropDatTxtTotalItems        = String.Empty;
                    PropDatTxtTipoDato          = String.Empty;
                    PropDatTxtTipoOrigenDatos   = String.Empty;
                    PropDatTxtTablaOrigen       = String.Empty;
                    PropDatTxtRangoInicial      = String.Empty;
                    PropDatTxtRangoFinal        = String.Empty;
                    // Propiedades Imagen 
                    PropImgTxtCodigoRecursoImagen   = String.Empty;
                    PropImgTxtUriRecursoImagen      = String.Empty;
                    PropImgTxtNombreRecursoImagen   = String.Empty;
                    PropImgTxtStretch               = String.Empty;
                    PropImgTxtStretchDirection      = String.Empty;
                    // Propiedades Varias
                    PropTxtSiValorCalculado         = String.Empty;
                    PropDatTxtNombreVariable        = String.Empty;
                    // control para validacion Alto,Ancho,Ajuste Izquierda y Ajuste Arriba
                    gcrValidPropDistribucion        = "1111";
                    //- Datos items cuando es ComboBox 
                    fcvGridReiniVariables("I");
                    #endregion
                }
                #endregion
                #region Reiniciar Variables ComboBox items
                if (tcrGrupo == "I" || tcrGrupo == "A")
                {
                    #region Valores Variables
                    PropItemIntIndice       = 0;
                    PropItemTxtParent       = String.Empty;
                    PropItemTxtIndice       = String.Empty;
                    PropItemTxtCodigo       = String.Empty;
                    PropItemTxtDescripcion  = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar temporales ComboBox items
                if (tcrGrupo == "TI" || tcrGrupo == "A")
                {
                    // Temporales 
                    regComboBoxItems = new XmlEntorno.ClassXmlComboBoxItems();
                    tmpComboBoxItems = new List<XmlEntorno.ClassXmlComboBoxItems>();
                }
                #endregion
                #region Reiniciar Variables Etiquetas
                if (tcrGrupo == "E" || tcrGrupo == "A")
                {
                    #region Valores Variables
                    PropEtiqIntIndice       = 0;
                    PropEtiqTxtIndice       = String.Empty;
                    PropEtiqTxtCodigo       = String.Empty;
                    PropEtiqTxtIcono        = String.Empty;
                    PropEtiqTxtDescripcion  = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar temporales Etiquetas
                if (tcrGrupo == "TE" || tcrGrupo == "A")
                {
                    regEtiquetaItems = new XmlEntorno.ClassXmlItemEtiquetas();
                    tmpEtiquetaItems = new List<XmlEntorno.ClassXmlItemEtiquetas>();
                }
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: ReiniVariables");
            }
        }
        #endregion
        #region fcvGridCargarRegActivoDesdeVariables: Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables
        /// tcrGrupo: P=Propiedades, I=Items comboBox E=Etiquetas y A=Todas
        /// </summary>
        public void fcvGridCargarRegActivoDesdeVariables(string tcrGrupo)
        {
            try
            {
                #region Cargar registro activo ComboBox items
                if (tcrGrupo == "I" || tcrGrupo == "A")
                {
                    if (regComboBoxItems != null)
                    {
                        #region Valores Variables
                        regComboBoxItems.IntIndice   = PropItemIntIndice;
                        regComboBoxItems.Parent      = PropItemTxtParent;
                        regComboBoxItems.Indice      = PropItemTxtIndice;
                        regComboBoxItems.Codigo      = PropItemTxtCodigo;
                        regComboBoxItems.Descripcion = PropItemTxtDescripcion;
                        #endregion
                    }
                }
                #endregion
                #region Cargar registro activo Etiquetas
                if (tcrGrupo == "E" || tcrGrupo == "A")
                {
                    if (regEtiquetaItems != null)
                    {
                        #region Valores Variables
                        regEtiquetaItems.IntIndice   = PropEtiqIntIndice;
                        regEtiquetaItems.Indice      = PropEtiqTxtIndice;
                        regEtiquetaItems.Codigo      = PropEtiqTxtCodigo;
                        regEtiquetaItems.Icono       = PropEtiqTxtIcono;
                        regEtiquetaItems.Descripcion = PropEtiqTxtDescripcion;
                        #endregion
                    }
                }
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
            }
        }
        #endregion
        #region fcvGridCargarVariablesDesdeRegActivo: Cargar Variables desde Registro activo
        /// <summary>
        /// Cargar Variables desde Registro activo
        /// tcrGrupo: P=Propiedades, I=Items comboBox E=Etiquetas y A=Todas
        /// </summary>
        public void fcvGridCargarVariablesDesdeRegActivo(String tcrGrupo)
        {
            try
            {
                #region Cargar Variables desde registro activo ComboBox items
                if (tcrGrupo == "I" || tcrGrupo == "A")
                {
                    if (regComboBoxItems != null)
                    {
                        #region Valores Variables
                        PropItemIntIndice       = regComboBoxItems.IntIndice;
                        PropItemTxtParent       = regComboBoxItems.Parent;
                        PropItemTxtIndice       = regComboBoxItems.Indice;
                        PropItemTxtCodigo       = regComboBoxItems.Codigo;
                        PropItemTxtDescripcion  = regComboBoxItems.Descripcion;
                        #endregion
                    }
                }
                #endregion
                #region Cargar Variables desde registro activo Etiquetas
                if (tcrGrupo == "E" || tcrGrupo == "A")
                {
                    if (regEtiquetaItems != null)
                    {
                        #region Valores Variables
                        PropEtiqIntIndice       = regEtiquetaItems.IntIndice;
                        PropEtiqTxtIndice       = regEtiquetaItems.Indice;
                        PropEtiqTxtCodigo       = regEtiquetaItems.Codigo;
                        PropEtiqTxtIcono        = regEtiquetaItems.Icono;
                        PropEtiqTxtDescripcion  = regEtiquetaItems.Descripcion;
                        #endregion
                    }
                }
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesDesdeRegActivo");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Implementacion para validacion
        //-------------------------------------------------
        #region Implementacion para validacion
        #region Implementacion
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
        #region Validacion de Campos
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public String fcrValidacion(string tcrNombrePropiedad)
        {
            String lcrValorReturn = String.Empty;
            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "PropTxtTitulo": // Titulo Objeto
                        lcrValorReturn = fcrValidacionTexto("AX", PropTxtTitulo, "Titulo objeto");
                        break;

                    case "PropTxtHeight": // Alto
                        lcrValorReturn = fcrValidacionNumerica(PropTxtHeight, 1, 1000, "Alto Objeto");
                        SetValidPropDistribucion(1, lcrValorReturn);
                        break;

                    case "PropTxtWidth": // Ancho
                        lcrValorReturn = fcrValidacionNumerica(PropTxtWidth, 1, 1000, "Ancho Objeto");
                        SetValidPropDistribucion(2, lcrValorReturn);
                        break;

                    case "PropTxtLeft": // Ajueste a la Izquierda
                        lcrValorReturn = fcrValidacionNumerica(PropTxtLeft, -100, 1000, "Ajueste a la Izquierda");
                        SetValidPropDistribucion(3, lcrValorReturn);
                        break;

                    case "PropTxtTop": // Ajueste arriba
                        lcrValorReturn = fcrValidacionNumerica(PropTxtTop, -100, 1000, "Ajueste arriba");
                        SetValidPropDistribucion(4, lcrValorReturn);
                        break;

                    case "PropItemTxtCodigo": // Codigo Item para objeto ComboBox
                        lcrValorReturn = fcrValidacionTexto("AM", PropItemTxtCodigo, "Codigo opción lista");
                        break;

                    case "PropItemTxtDescripcion": // Descripcion Item para objeto ComboBox
                        lcrValorReturn = fcrValidacionTexto("AX", PropItemTxtDescripcion, "Descripcion opción lista");
                        break;

                    case "PropEtiqTxtCodigo": // Codigo Item para objeto Etiquetas
                        lcrValorReturn = fcrValidacionTexto("AM", PropEtiqTxtCodigo, "Codigo Etiqueta");
                        break;

                    case "PropEtiqTxtIcono": // Icono Etiquetas
                        lcrValorReturn = fcrValidacionTexto("AX", PropEtiqTxtIcono, "Icono Etiqueta");
                        break;

                    case "PropEtiqTxtDescripcion": // Descripcion Item para objeto Etiquetas
                        lcrValorReturn = fcrValidacionTexto("AX", PropEtiqTxtDescripcion, "Descripcion Etiqueta");
                        break;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidacionTexto: Validacion texto
        /// <summary>
        /// Validacion texto
        /// <para>tcrTipo:</para>
        /// <para>"MX"= Verifica que sea solo texto (no distingue mayusculas y minusculas)</para>
        /// <para>"MA"= verifica que sea solo mayusculas</para>
        /// <para>"MI"= Verifica que solo sean minusculas</para>
        /// <para>"AN"= Texto y Numeros</para>
        /// <para>"AX"= Texto y Numeros con espacios o tabulacion (una oración)</para>
        /// <para>"AM"= Una sola expresion Alfanumerico con texto en mayuscuala y numeros</para>
        /// </summary>
        public String fcrValidacionTexto(String tcrTipoValidacion ,String tcrValor, String tcrTitulo)
        {
            var lcrValorReturn = String.Empty;
            try
            {
                if (String.IsNullOrWhiteSpace(tcrValor))
                {
                    lcrValorReturn = tcrTitulo + ": Es requerido";
                }
                else
                {
                    if (Funciones.flgSoloTexto(tcrTipoValidacion, tcrValor) == false)
                    {
                        lcrValorReturn = tcrTitulo + ": Solo acepta valores tipo texto";
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcrValidacionTexto");
            }
            glgSiValidPropiedadObjeto = String.IsNullOrWhiteSpace(lcrValorReturn) ? true : false;
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidacionNumerica: Validacion numerica
        /// <summary>
        /// Validacion numerica
        /// </summary>
        public String fcrValidacionNumerica(String tcrValor, int tnuRangoIni, int tnuRangoFin,String tcrTitulo)
        {
            var lcrValorReturn = String.Empty;
            try
            {
                if (String.IsNullOrWhiteSpace(tcrValor))
                {
                    lcrValorReturn = tcrTitulo + ": Es requerido";
                }
                else
                {
                    if (Funciones.flgSoloNumeros(PropTxtHeight) == false)
                    {
                        lcrValorReturn = tcrTitulo + ": Solo acepta valores numericos";
                    }
                    else if (Funciones.flgSoloNumeros(PropTxtHeight, tnuRangoIni, tnuRangoFin) == false)
                    {
                        lcrValorReturn = tcrTitulo + ": Valor esta fuera del rango permitido";
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcrValidacionNumerica");
            }
            glgSiValidPropiedadObjeto = String.IsNullOrWhiteSpace(lcrValorReturn) ? true : false;
            return lcrValorReturn;
        }
        #endregion
        #region SetValidPropDistribucion: Generar String control PropDistrubicion
        /// <summary>
        /// Generar String control (1111) PropDistrubicion 
        /// </summary>
        public void SetValidPropDistribucion(int tnuPosVariable, String tcrBanderaError)
        {
            String lcrV1 = String.Empty;
            String lcrV2 = String.Empty;
            var lcrValor = String.IsNullOrWhiteSpace(tcrBanderaError) ? "1" : "2";
            try
            {
                if (tnuPosVariable > 1 && tnuPosVariable < 4)
                {
                    lcrV1 = gcrValidPropDistribucion.Substring(0, tnuPosVariable - 1).Trim();
                    lcrV2 = gcrValidPropDistribucion.Substring(tnuPosVariable, 4 - tnuPosVariable).Trim();
                }
                else if (tnuPosVariable == 1)
                {
                    lcrV1 = String.Empty;
                    lcrV2 = gcrValidPropDistribucion.Substring(1, 3).Trim();
                }
                else if (tnuPosVariable == 4)
                {
                    lcrV1 = gcrValidPropDistribucion.Substring(0, 3).Trim();
                    lcrV2 = String.Empty;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: SetValidPropDistribucion");
            }
            gcrValidPropDistribucion = lcrV1 + lcrValor + lcrV2;
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Gestion de Combos Para propiedades
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
        #region fcvIniciarComboBox: Generar Listas Combobox  en Propiedades
        /// <summary>
        /// Listas Combobox en Propiedades
        /// </summary>
        public virtual void fcvIniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                // PropCboVerticalAlignment: Alineacion Vertical
                //-------------------------------------------------
                #region PropCboVerticalAlignment: Alineacion Vertical
                string lcrG11Seleccion = "Top,Bottom,Center,Stretch";
                string lcrG11Descripcion = "Arriba,Abajo,Centro,Ajustado";
                PropCboVerticalAlignment = new List<ListaXmlValores>();
                PropCboVerticalAlignment = flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboHorizontalAlignment: Alineacion Horizontal
                //-------------------------------------------------
                #region PropCboHorizontalAlignment: Alineacion Horizontal
                string lcrG15Seleccion = "Center,Left,Right,Stretch";
                string lcrG15Descripcion = "Centro,Izquierda,Derecha,Ajustado";
                PropCboHorizontalAlignment = new List<ListaXmlValores>();
                PropCboHorizontalAlignment = flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboFocusable: Objeto recibe enfoque
                //-------------------------------------------------
                #region PropCboFocusable: Objeto recibe enfoque
                string lcrG12Seleccion = "True,False";
                string lcrG12Descripcion = "Recibe enfoque,No recibe enfoque";
                PropCboFocusable = new List<ListaXmlValores>();
                PropCboFocusable = flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboIsEnabled: Activo/Inactivo  
                //-------------------------------------------------
                #region PropCboIsEnabled: Mostrar / Ocultar el Objeto
                string lcrG13Seleccion = "True,False";
                string lcrG13Descripcion = "Activo,Inactivo";
                PropCboIsEnabled = new List<ListaXmlValores>();
                PropCboIsEnabled = flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboVisibility: Objeto esta Visble o Invisible
                //-------------------------------------------------
                #region PropCboVisibility: Objeto recibe enfoque
                string lcrG14Seleccion = "True,False";
                string lcrG14Descripcion = "Visible,Oculto";
                PropCboVisibility = new List<ListaXmlValores>();
                PropCboVisibility = flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboBorder: Mostrar u ocultar el borde
                //-------------------------------------------------
                #region PropCboBorder: Mostrar u ocultar el borde
                string lcrG16Seleccion = "0,1,2,3,4,5,6,7,8";
                string lcrG16Descripcion = "0 px,1 px,2 px,3 px,4 px,5 px,6 px,7 px,8 px";
                PropCboBorder = new List<ListaXmlValores>();
                PropCboBorder = flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboSiValorCalculado: Saber si el valor objeto es calculado
                //-------------------------------------------------
                #region PropCboSiValorCalculado: Saber si el valor objeto es calculado
                string lcrG17Seleccion = "False,True";
                string lcrG17Descripcion = "Valor digitado,Valor calculado";
                PropCboSiValorCalculado = new List<ListaXmlValores>();
                PropCboSiValorCalculado = flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //PropCboFontFamily: Lista Tipos de fuente desde el sistema
                //-------------------------------------------------
                #region PropCboFontFamily: Lista Tipos de fuente desde el sistema
                PropCboFontFamily = new List<ListaXmlValores>();
                PropCboFontFamily = flsCargarListaFonts();
                #endregion
                //PropCboFontSize
                //-------------------------------------------------
                // PropCboFontSize: Lista tamaño de la fuente (texto)
                //-------------------------------------------------
                #region PropCboFontSize: Lista tamaño de la fuente (texto)
                string lcrG18Seleccion = "7,8,9,10,12,14,16,18,20,22,24,26,28,30,36,48,72";
                string lcrG18Descripcion = "7 Px,8 Px,9 Px,10 Px,12 Px,14 Px,16 Px,18 Px,20 Px,22 Px,24 Px,26 Px,28 Px,30 Px,36 Px,48 Px,72 Px";
                PropCboFontSize = new List<ListaXmlValores>();
                PropCboFontSize = flsCargarLista(lcrG18Seleccion, lcrG18Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboTituloVisible: Mostrar/Ocultar titulo objeto 
                //-------------------------------------------------
                #region PropCboTituloVisible: Mostrar/Ocultar titulo objeto
                string lcrG19Seleccion = "True,False";
                string lcrG19Descripcion = "Titulo Visible,Titulo Oculto";
                PropCboTituloVisible = new List<ListaXmlValores>();
                PropCboTituloVisible = flsCargarLista(lcrG19Seleccion, lcrG19Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboStretch: Lista valores ajuste de la imagen dentro del objeto imagen.
                //-------------------------------------------------
                #region PropCboStretch: Lista valores ajuste de la imagen dentro del objeto imagen.
                string lcrG20Seleccion = "Fill,None,Uniform,UniformToFill";
                string lcrG20Descripcion = "Ajustado,Sin Ajuste,Uniforme,Proporcional";
                PropCboStretch = new List<ListaXmlValores>();
                PropCboStretch = flsCargarLista(lcrG20Seleccion, lcrG20Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboStretchDirection: Lista valores direccion ajuste de la imagen dentro del objeto imagen.
                //-------------------------------------------------
                #region PropCboStretchDirection: Lista valores direccion ajuste de la imagen dentro del objeto imagen.
                string lcrG21Seleccion = "Both,DownOnly,UpOnly";
                string lcrG21Descripcion = "Ajustado,Solo hacia abajo,Solo arriba";
                PropCboStretchDirection = new List<ListaXmlValores>();
                PropCboStretchDirection = flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboTablaOrigen: Lista de Tablas Origen para campos relacionados.
                //-------------------------------------------------
                #region PropCboTablaOrigen: Lista de Tablas Origen para campos relacionados.
                string lcrG22Seleccion   = "DIAG,USUA,USUX,TIDE,TDIS,TMED,TAFI,TCOT,"+
                                           "TPOB,NSBN,TPAT,PROF,ESME,"+
                                           "ASER,TEPS,TRIP,FCON,TDIX";
                string lcrG22Descripcion = "Diagnosticos,Maestro usuarios atendidos,Usuarios del sistema,Tipo identificación,Tipo Discapacidad,Medida Edad,Tipo afiliación,Tipo cotizante,"+
                                           "Tipo población,Nivel Sisben,Tipo profesional que atiende,Nombre profesionales medicos,Especialidades medicas,"+
                                           "Areas prestacion servicios,Lista EPS aseguradoras,Clasificación RIPS,Finalidad consulta (RIPS AC),Tipo Diagnostico Principal (RIPS AP)";
                PropCboTablaOrigen = new List<ListaXmlValores>();
                PropCboTablaOrigen = flsCargarLista(lcrG22Seleccion, lcrG22Descripcion);
                #endregion
               
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        #region Cargar la clase del ComboBox Listas Desplegables
        public static List<ListaXmlValores> flsCargarLista(string tcrListaValores, string tcrListaDescripcionOp)
        {
            int lnuTotLista = Funciones.fnuContarElemListaString(",", tcrListaValores);
            int i = 0;
            string lcrValorSel = string.Empty;
            string lcrNombreOp = string.Empty;
            List<ListaXmlValores> llsLista = new List<ListaXmlValores>();

            for (i = 1; i <= lnuTotLista; i++)
            {
                //- Valor Seleccion
                lcrValorSel = Funciones.fuxExtraerElemento(i, ",", tcrListaValores);
                if (String.IsNullOrEmpty(lcrValorSel)) { lcrValorSel = "OP" + i.ToString().Trim(); }
                //- Titulo
                lcrNombreOp = Funciones.fuxExtraerElemento(i, ",", tcrListaDescripcionOp);
                if (String.IsNullOrEmpty(lcrNombreOp)) { lcrNombreOp = "Opcion Seleccion" + i.ToString().Trim(); }
                // llenar la lista
                llsLista.Add(new ListaXmlValores() { Indice = i.ToString().Trim(), Codigo = lcrValorSel, Descripcion = lcrNombreOp});
            }
            return llsLista;
        }
        #endregion
        #region Cargar lista tipo de fuentes del sistema
        public static List<ListaXmlValores> flsCargarListaFonts()
        {
            int i = 0;
            string lcrValorSel = string.Empty;
            string lcrNombreOp = string.Empty;
            List<ListaXmlValores> llsLista = new List<ListaXmlValores>();
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                i++;
                lcrValorSel = fontFamily.Source.Trim();
                lcrNombreOp = fontFamily.Source.Trim();
                llsLista.Add(new ListaXmlValores() { Indice = i.ToString().Trim(), Codigo = lcrValorSel, Descripcion = lcrNombreOp });
            }
            return llsLista;
        }
        #endregion
        #region Buscar Valores en Lista devolver el Index  para combobox
        /// <summary>
        /// Mostrar la opcion del combobox segun opcion escrita en textbox
        /// <param name="tcrValor">Valor a seleccionar</param>
        /// <param name="tlsLista">Lista de Valores</param>
        /// <returns>Retorna un valor de tipo entero para SelectedIndex del Combobox</returns>
        /// </summary>
        public static int fnuMostrarItemCombo(String tcrValor, List<ListaXmlValores> tlsLista)
        {
            int lnuValor = 0;
            var lcrQuery = from lst in tlsLista
                           where lst.Codigo.Equals(tcrValor)
                           select new ListaXmlValores
                           {
                               Indice      = lst.Indice,
                               Codigo      = lst.Codigo,
                               Descripcion = lst.Descripcion
                           };

            if (lcrQuery!=null) { lnuValor = Convert.ToInt32(lcrQuery.FirstOrDefault().Indice)-1; }
            return lnuValor;
        }
        #endregion
        //-----------------------------------
        //- ListaXmlValores
        //-----------------------------------
        #region ListaXmlValores: Carga lista de Valores para la propiedad
        /// <summary>
        /// <para>Contiene la lista de valores digitados para opciones un combobox, radiobutton colecciones y otras</para>
        /// </summary>
        public class ListaXmlValores
        {
            public ListaXmlValores() { }
            public string Indice { get; set; }
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
        }
        #endregion
        #endregion

    }
}

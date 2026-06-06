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
using Sistema.Clases;
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
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        public String gcrValorReturnChr = String.Empty; // para captura de error caracteres especiales
        // Perfil del usuario activo
        public Aplicacion oApp = Aplicacion.Instancia();
        public string gcrSIS_PerfilCmdEDT = String.Empty;

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
        #region Vista Modelo Propiedad: glgSIS_ModoAdicion
        /// <summary>
        /// glgSIS_ModoAdicion: Variable para el control del modo
        /// adicion del Vista Modelo.
        /// </summary>
        public string glgNomProp_SIS_ModoAdicion = "GlgSIS_ModoAdicion";
        private bool _glgSIS_ModoAdicion = false;
        public bool GlgSIS_ModoAdicion
        {
            get { return _glgSIS_ModoAdicion; }
            set
            {
                if (_glgSIS_ModoAdicion == value) { return; }
                _glgSIS_ModoAdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoAdicion);
            }
        }
        #endregion
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
        #region Vista Modelo Propiedad: glgSIS_ModoVistaObjetos
        public String glgNomProp_ModoVistaObjetos = "GlgSIS_ModoVistaObjetos";
        private bool _glgSIS_ModoVistaObjetos = false;
        /// <summary>
        /// <para>GlgSIS_ModoVistaObjetos: Variable para el control del modo</para> 
        /// <para>Captura o Vista del formato activo "True"= Modo Vista</para> 
        /// <para>"False"= Modo Captura de datos o Edicion</para> 
        /// </summary>
        public bool GlgSIS_ModoVistaObjetos
        {
            get { return _glgSIS_ModoVistaObjetos; }
            set
            {
                if (_glgSIS_ModoVistaObjetos == value) { return; }
                _glgSIS_ModoVistaObjetos = value;
                RaisePropertyChanged(glgNomProp_ModoVistaObjetos);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: gnuPropValorProgressBar
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
        #region Vista Modelo Propiedad: gnuPropValorMinimoProgressBar
        /// <summary>
        /// PropValorProgressBar: valor minimo de la barra de progreso
        /// </summary>
        public string glgNomProp_PropValorMinimoProgressBar = "gnuPropValorMinimoProgressBar";
        private int _propValorMinimoProgressBar = 0;
        public int gnuPropValorMinimoProgressBar
        {
            get { return _propValorMinimoProgressBar; }
            set
            {
                if (_propValorMinimoProgressBar == value) { return; }
                _propValorMinimoProgressBar = value;
                RaisePropertyChanged(glgNomProp_PropValorMinimoProgressBar);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: gnuPropValorMaximoProgressBar
        /// <summary>
        /// PropValorProgressBar: valor maximo de la barra de progreso
        /// </summary>
        public string glgNomProp_PropValorMaximoProgressBar = "gnuPropValorMaximoProgressBar";
        private int _propValorMaximoProgressBar = 0;
        public int gnuPropValorMaximoProgressBar
        {
            get { return _propValorMaximoProgressBar; }
            set
            {
                if (_propValorMaximoProgressBar == value) { return; }
                _propValorMaximoProgressBar = value;
                RaisePropertyChanged(glgNomProp_PropValorMaximoProgressBar);
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
        #region glgPuedeEditarItemsSecciones: Variable control Secciones edicion
        public String glgNomPropPuedeEditarItemsSecciones = "glgPuedeEditarItemsSecciones";
        private bool _glgSISPuedeEditarItemsSecciones = false;
        /// <summary>
        /// <para>Control activacion objetos texto para editar valores secciones</para>
        /// </summary>
        public bool glgPuedeEditarItemsSecciones
        {
            get { return _glgSISPuedeEditarItemsSecciones; }
            set
            {
                if (_glgSISPuedeEditarItemsSecciones == value) { return; }
                _glgSISPuedeEditarItemsSecciones = value;
                RaisePropertyChanged(glgNomPropPuedeEditarItemsSecciones);
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
        #region glgPuedeEditarImgPredefinidas: Variable control Imagenes predefinidas edicion
        public String glgNomPropPuedeEditarImgPredefinidas = "glgPuedeEditarImgPredefinidas";
        private bool _glgSISPuedeEditarImgPredefinidas = false;
        /// <summary>
        /// <para>Control activacion objetos texto para editar valores item Etiquetas</para>
        /// </summary>
        public bool glgPuedeEditarImgPredefinidas
        {
            get { return _glgSISPuedeEditarImgPredefinidas; }
            set
            {
                if (_glgSISPuedeEditarImgPredefinidas == value) { return; }
                _glgSISPuedeEditarImgPredefinidas = value;
                RaisePropertyChanged(glgNomPropPuedeEditarImgPredefinidas);
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
        #region PropTxtToolTip: Texto de ayuda al colocar el mouse sobre el objeto
        public const string gcrNomProp_PropTxtToolTip = "PropTxtToolTip";
        private string _propTxtToolTip = string.Empty;
        /// <summary>
        /// <para>Texto de ayuda al colocar el mouse sobre el objeto</para>
        /// </summary>
        public string PropTxtToolTip
        {
            get { return _propTxtToolTip; }
            set
            {
                if (_propTxtToolTip == value) return;
                _propTxtToolTip = value;
                RaisePropertyChanged(gcrNomProp_PropTxtToolTip);
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
        #region PropTxtTipoControl: Control para captura BLIQ = Balance liqidos MEDI=Medicamentos ...
        public const string gcrNomProp_PropTxtTipoControl = "PropTxtTipoControl";
        private string _propTxtTipoControl = string.Empty;
        /// <summary>
        /// <para>Control para captura BLIQ = Balance liqidos MEDI=Medicamentos ...</para>
        /// </summary>
        public string PropTxtTipoControl
        {
            get { return _propTxtTipoControl; }
            set
            {
                if (_propTxtTipoControl == value) return;
                _propTxtTipoControl = value;
                RaisePropertyChanged(gcrNomProp_PropTxtTipoControl);
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
        #region PropTxtTabIndex: Orden de tabulacion de Objeto 
        public const string gcrNomProp_PropTxtTabIndex = "PropTxtTabIndex";
        private string _propTxtTabIndex = string.Empty;
        /// <summary>
        /// <para> Orden tabulacion en vista</para>
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
        #region PropTxtOrdenVista: Orden Vizualizacion del objeto dentro de  seccion
        public const string gcrNomProp_PropTxtOrdenVista = "PropTxtOrdenVista";
        private string _propTxtOrdenVista = string.Empty;
        /// <summary>
        /// <para> Orden Vizualizacion del objeto dentro de la seccion y vista impresa </para>
        /// </summary>
        public string PropTxtOrdenVista
        {
            get { return _propTxtOrdenVista; }
            set
            {
                if (_propTxtOrdenVista == value) return;
                _propTxtOrdenVista = value;
                RaisePropertyChanged(gcrNomProp_PropTxtOrdenVista);
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
        #region PropTxtSeccionCodigo: Codigo seccion del formato a la cual pertenece el objetos
        public const String gcrNomProp_PropTxtSeccionCodigo = "PropTxtSeccionCodigo";
        private String _propTxtSeccionCodigo = String.Empty;
        /// <summary>
        /// <para>Codigo seccion del formato a la cual pertenece el objetos</para>
        /// </summary>
        public String PropTxtSeccionCodigo
        {
            get { return _propTxtSeccionCodigo; }
            set
            {
                if (_propTxtSeccionCodigo == value) return;
                _propTxtSeccionCodigo = value;
                RaisePropertyChanged(gcrNomProp_PropTxtSeccionCodigo);
            }
        }
        #endregion
        #region PropTxtSeccionDefault: Codigo Seccion del formato activa por defecto
        public const String gcrNomProp_PropTxtSeccionDefault = "PropTxtSeccionDefault";
        private String _propTxtSeccionDefault = "01";
        /// <summary>
        /// <para>Codigo seccion activa del formato, Activa por defecto inicialmente: 01 = Seccion base del formato</para>
        /// </summary>
        public String PropTxtSeccionDefault
        {
            get { return _propTxtSeccionDefault; }
            set
            {
                if (_propTxtSeccionDefault == value) return;
                _propTxtSeccionDefault = value;
                RaisePropertyChanged(gcrNomProp_PropTxtSeccionDefault);
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
        private string _propTxtFontSize = "12"; // Tamaño normal 12 px
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
        #region PropTxtAlineacionTexto: Alinaeacion del texto
        public const string gcrNomProp_PropTxtAlineacionTexto = "PropTxtAlineacionTexto";
        private string _propTxtAlineacionTexto = "Left"; // Por defecto alinado a la izquierda
        /// <summary>
        /// <para>Alinaeacion del texto: Left=Izquieda Right=Derecha Center=Centrado Justify=Justificado</para>
        /// </summary>
        public string PropTxtAlineacionTexto
        {
            get { return _propTxtAlineacionTexto; }
            set
            {
                if (_propTxtAlineacionTexto == value) return;
                _propTxtAlineacionTexto = value;
                RaisePropertyChanged(gcrNomProp_PropTxtAlineacionTexto);
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
        #region PropDatTxtBindingTabla: Archivo maestro historico origen del campo Binding asociado 
        public const string gcrNomProp_PropDatTxtBindingTabla = "PropDatTxtBindingTabla";
        private string _propDatTxtBindingTabla = string.Empty;
        /// <summary>
        /// <para>Archivo maestro historico origen del campo Binding asociado a un objeto de captura</para>
        /// </summary>
        public string PropDatTxtBindingTabla
        {
            get { return _propDatTxtBindingTabla; }
            set
            {
                if (_propDatTxtBindingTabla == value) return;
                _propDatTxtBindingTabla = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtBindingTabla);
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
        #region PropDatTxtVariablePublica: Referencia a la variable pubica asociada con el objeto de captura de datos
        public const string gcrNomProp_PropDatTxtVariablePublica = "PropDatTxtVariablePublica";
        private string _propDatTxtVariablePublica = string.Empty;
        /// <summary>
        /// <para>Referencia a la variable pubica asociada con el objeto de captura de datos</para>
        /// <para>Ejemplo: ADMISION_DIAGNOSTICO_DE_INGRESO,PYP_EMBARAZO_TOTAL_PARTOS, USUARIO_PRIMER_NOMBRE,USUARIO_PRIMER_APELLIDO</para>
        /// </summary>
        public string PropDatTxtVariablePublica
        {
            get { return _propDatTxtVariablePublica; }
            set
            {
                if (_propDatTxtVariablePublica == value) return;
                _propDatTxtVariablePublica = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtVariablePublica);
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
        #region PropDatTxtCodigoEtiqueta: Codigo de la platilla tipo etiqueta de datos relacionada con el objeto
        public const string gcrNomProp_PropDatTxtCodigoEtiqueta = "PropDatTxtCodigoEtiqueta";
        private string _propDatTxtCodigoEtiqueta = string.Empty;
        /// <summary>
        /// <para>Codigo de la platilla tipo etiqueta de datos relacionada con el objeto, solo para objetos que</para>
        /// <para>agregan en modo captura.</para>
        /// <para>Aplica en modo captura para: Imagenes, figuras y Etiquetas de texto.</para>
        /// </summary>
        public string PropDatTxtCodigoEtiqueta
        {
            get { return _propDatTxtCodigoEtiqueta; }
            set
            {
                if (_propDatTxtCodigoEtiqueta == value) return;
                _propDatTxtCodigoEtiqueta = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtCodigoEtiqueta);
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
        #region PropDatTxtIsRequerido: Valor  del campo es requerido (SI/NO)
        public const string gcrNomProp_PropDatTxtIsRequerido = "PropDatTxtIsRequerido";
        private string _propDatTxtIsRequerido = string.Empty;
        /// <summary>
        /// <para>Marcar el campo para valor requerido (SI/NO).</para>
        /// </summary>
        public string PropDatTxtIsRequerido
        {
            get { return _propDatTxtIsRequerido; }
            set
            {
                if (_propDatTxtIsRequerido == value) return;
                _propDatTxtIsRequerido = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtIsRequerido);
            }
        }
        #endregion
        #region PropDatTxtFechaDefault: Valor por defecto para campos tipo fecha
        public const string gcrNomProp_PropDatTxtFechaDefault = "PropDatTxtFechaDefault";
        private string _propDatTxtFechaDefault = String.Empty;
        /// <summary>
        /// <para>Valor por defecto para campos tipo fecha: 1=Valor Vacio 2=Fecha Actual.</para>
        /// </summary>
        public string PropDatTxtFechaDefault
        {
            get { return _propDatTxtFechaDefault; }
            set
            {
                if (_propDatTxtFechaDefault == value) return;
                _propDatTxtFechaDefault = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtFechaDefault);
            }
        }
        #endregion
        #region PropDatTxtHoraDefault: Valor por defecto para campos tipo hora
        public const string gcrNomProp_PropDatTxtHoraDefault = "PropDatTxtHoraDefault";
        private string _propDatTxtHoraDefault = String.Empty;
        /// <summary>
        /// <para>Valor por defecto para campos tipo hora: 1=Valor Vacio 2=Hora Actual.</para>
        /// </summary>
        public string PropDatTxtHoraDefault
        {
            get { return _propDatTxtHoraDefault; }
            set
            {
                if (_propDatTxtHoraDefault == value) return;
                _propDatTxtHoraDefault = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtHoraDefault);
            }
        }
        #endregion
        // Valores para gestion variables tipo vector (pila)
        #region PropDatTxtVarGestPosVector: Tipo Valor gestion Variable Publica vector o pila
        public const string gcrNomProp_PropDatTxtVarGestPosVector = "PropDatTxtVarGestPosVector";
        private string _propDatTxtVarGestPosVector = string.Empty;
        /// <summary>
        /// <para>Tipo Valor gestion Variable Publica (cuando aplique)/N=No Aplica/0=Campo solo captura de datos/1= Posicion elemento1/2=Posicion elemento2 /3...</para>
        /// </summary>
        public string PropDatTxtVarGestPosVector
        {
            get { return _propDatTxtVarGestPosVector; }
            set
            {
                if (_propDatTxtVarGestPosVector == value) return;
                _propDatTxtVarGestPosVector = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtVarGestPosVector);
            }
        }
        #endregion
        // referencia a objetos o valores auxiliares para multipropositos
        #region PropDatTxtRefObjProceso: Lista de objetos tipo campos referenciados para procesos
        public const string gcrNomProp_PropDatTxtRefObjProceso = "PropDatTxtRefObjProceso";
        private string _propDatTxtRefObjProceso = string.Empty;
        /// <summary>
        /// <para>Lista de objetos tipo campos referenciados por nombre variable interna para procesos de suma promedio y otros</para>
        /// <para>procesos de activar e inactivar entre otros</para>
        /// </summary>
        public string PropDatTxtRefObjProceso
        {
            get { return _propDatTxtRefObjProceso; }
            set
            {
                if (_propDatTxtRefObjProceso == value) return;
                _propDatTxtRefObjProceso = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtRefObjProceso);
            }
        }
        #endregion
        #region PropDatTxtRefListValAuxiliar: Lista de objetos o valores auxiliares para multiproposito
        public const string gcrNomProp_PropDatTxtRefListValAuxiliar = "PropDatTxtRefListValAuxiliar";
        private string _propDatTxtRefListValAuxiliar = string.Empty;
        /// <summary>
        /// <para>Lista de objetos o valores auxiliares para multiproposito</para>
        /// </summary>
        public string PropDatTxtRefObjActList
        {
            get { return _propDatTxtRefListValAuxiliar; }
            set
            {
                if (_propDatTxtRefListValAuxiliar == value) return;
                _propDatTxtRefListValAuxiliar = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtRefListValAuxiliar);
            }
        }
        #endregion
        // Otras validaciones
        #region PropDatTxtSiMultiSet: Los datos en el objeto pueden ser editados despues de confirmar
        public const string gcrNomProp_PropDatTxtSiMultiSet = "PropDatTxtSiMultiSet";
        private string _propDatTxtSiMultiSet = String.Empty;
        /// <summary>
        /// <para>Los datos en el objeto pueden ser editados si estan vacios despues de confirmar el formato de H.C.</para>
        /// <para>Valor True/False, por defecto (False)</para>
        /// </summary>
        public string PropDatTxtSiMultiSet
        {
            get { return _propDatTxtSiMultiSet; }
            set
            {
                if (_propDatTxtSiMultiSet == value) return;
                _propDatTxtSiMultiSet = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtSiMultiSet);
            }
        }
        #endregion
        #region PropDatTxtIsReadOnly: El dato es solo lectura, activa o inactiva actualizar variable publica actualizables
        public const string gcrNomProp_PropDatTxtIsReadOnly = "PropDatTxtIsReadOnly";
        private string _propDatTxtIsReadOnly = String.Empty;
        /// <summary>
        /// <para>El dato es solo lectura, activa o inactiva actualziar variable publica actualizable</para>
        /// <para>Valor True/False, por defecto (False)</para>
        /// </summary>
        public string PropDatTxtIsReadOnly
        {
            get { return _propDatTxtIsReadOnly; }
            set
            {
                if (_propDatTxtIsReadOnly == value) return;
                _propDatTxtIsReadOnly = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtIsReadOnly);
            }
        }
        #endregion
        #region PropDatTxtPrnSiValidar: Validar si valores por defecto se envian a reporte impreso
        public const string gcrNomProp_PropDatTxtPrnSiValidar = "PropDatTxtPrnSiValidar";
        private string _propDatTxtPrnSiValidar = String.Empty;
        /// <summary>
        /// <para>Validar si valores por defecto se envian a reporte impreso (por defecto es 1 = Todos se envian</para>
        /// <para>1,2,3,4: 1=Enviar todos a impresion,2=Enviar Solo valores lista, 3=Excluir valores de lista</para>
        /// <para>4=No enviar datos a impresion</para>
        /// </summary>
        public string PropDatTxtPrnSiValidar
        {
            get { return _propDatTxtPrnSiValidar; }
            set
            {
                if (_propDatTxtPrnSiValidar == value) return;
                _propDatTxtPrnSiValidar = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtPrnSiValidar);
            }
        }
        #endregion
        #region PropDatTxtPrnValorDefault: lista posibles valores por defecto para Validar envio a reporte impreso
        public const string gcrNomProp_PropDatTxtPrnValorDefault = "PropDatTxtPrnValorDefault";
        private string _propDatTxtPrnValorDefault = String.Empty;
        /// <summary>
        /// <para>lista separada por coma de posibles valores que al Validar se genere datos para reporte impreso</para>
        /// </summary>
        public string PropDatTxtPrnValorDefault
        {
            get { return _propDatTxtPrnValorDefault; }
            set
            {
                if (_propDatTxtPrnValorDefault == value) return;
                _propDatTxtPrnValorDefault = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtPrnValorDefault);
            }
        }
        #endregion
        #region PropDatTxtPrnValorPreView: Valor de ejemplo para probar vista previa del reporte impreso
        public const string gcrNomProp_PropDatTxtPrnValorPreView = "PropDatTxtPrnValorPreView";
        private string _propDatTxtPrnValorPreView = String.Empty;
        /// <summary>
        /// <para>Valor de ejemplo para probar vista previa del reporte impreso</para>
        /// </summary>
        public string PropDatTxtPrnValorPreView
        {
            get { return _propDatTxtPrnValorPreView; }
            set
            {
                if (_propDatTxtPrnValorPreView == value) return;
                _propDatTxtPrnValorPreView = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtPrnValorPreView);
            }
        }
        #endregion
        #region PropDatTxtPrnMostrarTitulo: Si se muestra el titulo del dato al enviar a impresión (por defecto 1=Mostrar)
        public const string gcrNomProp_PropDatTxtPrnMostrarTitulo = "PropDatTxtPrnMostrarTitulo";
        private string _propDatTxtPrnMostrarTitulo = String.Empty;
        /// <summary>
        /// <para>indicar si se muestra el titulo del dato al enviar a impresión (por defecto 1=Mostrar)</para>
        /// <para>1,2: "1"=Ver el titulo en impresion, "2"=No mostrar titulo en impresion</para>
        /// </summary>
        public string PropDatTxtPrnMostrarTitulo
        {
            get { return _propDatTxtPrnMostrarTitulo; }
            set
            {
                if (_propDatTxtPrnMostrarTitulo == value) return;
                _propDatTxtPrnMostrarTitulo = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtPrnMostrarTitulo);
            }
        }
        #endregion
        // Vaiables lista referencias archivos actualizables 4505/Rips y otros
        #region PropArchActualizIntIndice: Inidice numerico para organizar Items Campos acutalizables
        public const String gcrNomProp_PropArchActualizIntIndice = "PropArchActualizIntIndice";
        private int _propArchActualizIntIndice = 0;
        /// <summary>
        /// <para>Inidice numerico para organizar Items Campos acutalizables 4505/Rips y otros</para>
        /// </summary>
        public int PropArchActualizIntIndice
        {
            get { return _propArchActualizIntIndice; }
            set
            {
                if (_propArchActualizIntIndice == value) return;
                _propArchActualizIntIndice = value;
                RaisePropertyChanged(gcrNomProp_PropArchActualizIntIndice);
            }
        }
        #endregion
        #region PropArchActualizParent: Referencia al Objeto Textobox,RadioButton,ChkBox,ComboBox padre
        public const String gcrNomProp_PropArchActualizParent = "PropArchActualizParent";
        private String _propArchActualizParent = String.Empty;
        /// <summary>
        /// <para>Referencia al Objeto Textobox,RadioButton,ChkBox,ComboBox padre para archivos actualizables 4505/Rips y otros</para>
        /// </summary>
        public String PropArchActualizParent
        {
            get { return _propArchActualizParent; }
            set
            {
                if (_propArchActualizParent == value) return;
                _propArchActualizParent = value;
                RaisePropertyChanged(gcrNomProp_PropArchActualizParent);
            }
        }
        #endregion
        #region PropArchActualizIndice: Indice secuencial del item dentro del ComboBox
        public const String gcrNomProp_PropArchActualizIndice = "PropArchActualizIndice";
        private String _propArchActualizIndice = String.Empty;
        /// <summary>
        /// <para>Indice secuencial del item dentro del ComboBox</para>
        /// </summary>
        public String PropArchActualizIndice
        {
            get { return _propArchActualizIndice; }
            set
            {
                if (_propArchActualizIndice == value) return;
                _propArchActualizIndice = value;
                RaisePropertyChanged(gcrNomProp_PropArchActualizIndice);
            }
        }
        #endregion
        #region PropArchActualizCodigoArchivo: Referencia a tabla o dato para actualizar 4505/RIPS AC,AP... o Resolucion 4505 y otros
        public const string gcrNomProp_PropArchActualizCodigoArchivo = "PropArchActualizCodigoArchivo";
        private string _propArchActualizCodigoArchivo = "NA";
        /// <summary>
        /// <para>Referencia al codigo archivo para actualizar 4505/RIPS => AC,AP,RES4505,AT,US... </para>
        /// </summary>
        public string PropArchActualizCodigoArchivo
        {
            get { return _propArchActualizCodigoArchivo; }
            set
            {
                if (_propArchActualizCodigoArchivo == value) return;
                _propArchActualizCodigoArchivo = value;
                RaisePropertyChanged(gcrNomProp_PropArchActualizCodigoArchivo);
            }
        }
        #endregion
        #region PropArchActualizTituloArchivo: Titulo o descripcion del archivo actualizable 4505/Rips y otros.
        public const string gcrNomProp_PropArchActualizTituloArchivo = "PropArchActualizTituloArchivo";
        private string _propArchActualizTituloArchivo = string.Empty;
        /// <summary>
        /// <para>Titulo o descripcion del archivo actualizable 4505/Rips y otros.</para>
        /// </summary>
        public string PropArchActualizTituloArchivo
        {
            get { return _propArchActualizTituloArchivo; }
            set
            {
                if (_propArchActualizTituloArchivo == value) return;
                _propArchActualizTituloArchivo = value;
                RaisePropertyChanged(gcrNomProp_PropArchActualizTituloArchivo);
            }
        }
        #endregion
        #region PropArchActualizDatosCampo: Nombre del campo para actualizar RIPS AC,AP... o Resolucion 4505 y otros
        public const string gcrNomProp_PropArchActualizDatosCampo = "PropArchActualizCodigoCampo";
        private string _propArchActualizDatosCampo = string.Empty;
        /// <summary>
        /// <para>Nombre del campo para actualizar RIPS AC,AP... o Resolucion 4505 y otros.</para>
        /// </summary>
        public string PropArchActualizCodigoCampo
        {
            get { return _propArchActualizDatosCampo; }
            set
            {
                if (_propArchActualizDatosCampo == value) return;
                _propArchActualizDatosCampo = value;
                RaisePropertyChanged(gcrNomProp_PropArchActualizDatosCampo);
            }
        }
        #endregion
        #region PropArchActualizTituloCampo: Titulo  o descripcion del Campo actualizable para archivos 4505/Rips y otros.
        public const string gcrNomProp_PropArchActualizTituloCampo = "PropArchActualizTituloCampo";
        private string _propArchActualizTituloCampo = string.Empty;
        /// <summary>
        /// <para>Titulo o descripcion del campo actualizable para archivos 4505/Rips y otros.</para>
        /// </summary>
        public string PropArchActualizTituloCampo
        {
            get { return _propArchActualizTituloCampo; }
            set
            {
                if (_propArchActualizTituloCampo == value) return;
                _propArchActualizTituloCampo = value;
                RaisePropertyChanged(gcrNomProp_PropArchActualizTituloCampo);
            }
        }
        #endregion
        #region PropArchActualizDepenCampo: Referencia al campo 4505/Rips.., que condiciona el diligenciamiento del campo
        public const string gcrNomProp_PropArchActualizDependienteDe = "PropArchActualizDepenCampo";
        private string _propArchActualizDependienteDe = string.Empty;
        /// <summary>
        /// <para>Referencia al campo principal desde 4505/Rips..., que condiciona el diligenciamiento del campo</para>
        /// </summary>
        public string PropArchActualizDepenCampo
        {
            get { return _propArchActualizDependienteDe; }
            set
            {
                if (_propArchActualizDependienteDe == value) return;
                _propArchActualizDependienteDe = value;
                RaisePropertyChanged(gcrNomProp_PropArchActualizDependienteDe);
            }
        }
        #endregion
        #region PropArchActualizValorQueReporta: Referencia al valor reportado dentro del rango de valores permitidos para el campo 4505/Rips
        public const string gcrNomProp_PropArchActualizValorQueReporta = "PropArchActualizValorQueReporta";
        private string _propArchActualizValorQueReporta = string.Empty;
        /// <summary>
        /// <para>Referencia al valor que se reporta, el cual debe estar dentro del rango de valores permitidos para el campo 4505/Rips</para>
        /// </summary>
        public string PropArchActualizValorQueReporta
        {
            get { return _propArchActualizValorQueReporta; }
            set
            {
                if (_propArchActualizValorQueReporta == value) return;
                _propArchActualizValorQueReporta = value;
                RaisePropertyChanged(gcrNomProp_PropArchActualizValorQueReporta);
            }
        }
        #endregion
        #region regArchActualiz: Registro activo al seleccionar en Vista Grid de campos actualizables 4505/Rips y otros
        public const string gcrNomProp_PropDatRegCamposActualiz = "regArchActualiz";
        private XmlEntorno.ClassXmlRefActualizArchivos _propDatRegCamposActualiz;
        /// <summary>
        /// <para>Registro activo de valores para al seleccionar un registro en la Vista Grid</para>
        /// <para>de campos actualizables 4505/Rips y otros</para>
        /// </summary>
        public XmlEntorno.ClassXmlRefActualizArchivos regArchActualiz
        {
            get { return _propDatRegCamposActualiz; }
            set
            {
                if (_propDatRegCamposActualiz == value) return;
                _propDatRegCamposActualiz = value;
                RaisePropertyChanged(gcrNomProp_PropDatRegCamposActualiz);
            }
        }
        #endregion
        #region tmpArchActualiz: Temporal Valores campos actualizables 4505/Rips
        public const string gcrNomProp_PropDatTempArchActualiz = "tmpArchActualiz";
        private List<XmlEntorno.ClassXmlRefActualizArchivos> _propArchActualizTmp;
        /// <summary>
        /// <para>Temporal Valores campos actualizables 4505/Rips y otros</para>
        /// </summary>
        public List<XmlEntorno.ClassXmlRefActualizArchivos> tmpArchActualiz
        {
            get { return _propArchActualizTmp; }
            set
            {
                if (_propArchActualizTmp == value) return;
                _propArchActualizTmp = value;
                RaisePropertyChanged(gcrNomProp_PropDatTempArchActualiz);
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
        // Variables lista Secciones del formato
        #region PropSeccionIntIndice: Inidice numerico para organizar lista secciones del formato
        public const String gcrNomProp_PropSeccionIntIndice = "PropSeccionIntIndice";
        private int _propSeccionIntIndice = 0;
        /// <summary>
        /// <para>Inidice numerico para organizar lista secciones del formato</para>
        /// </summary>
        public int PropSeccionIntIndice
        {
            get { return _propSeccionIntIndice; }
            set
            {
                if (_propSeccionIntIndice == value) return;
                _propSeccionIntIndice = value;
                RaisePropertyChanged(gcrNomProp_PropSeccionIntIndice);
            }
        }
        #endregion
        #region PropSeccionTxtIndice: Indice secuencial del item dentro de lista secciones del formato
        public const String gcrNomProp_PropSeccionTxtIndice = "PropSeccionTxtIndice";
        private String _propSeccionTxtIndice = String.Empty;
        /// <summary>
        /// <para>Indice secuencial del item dentro de lista secciones del formato</para>
        /// </summary>
        public String PropSeccionTxtIndice
        {
            get { return _propSeccionTxtIndice; }
            set
            {
                if (_propSeccionTxtIndice == value) return;
                _propSeccionTxtIndice = value;
                RaisePropertyChanged(gcrNomProp_PropSeccionTxtIndice);
            }
        }
        #endregion
        #region PropSeccionTxtCodigo: Codigo (valor seleccion) Codigo seccion para referencia desde objetos
        public const String gcrNomProp_PropSeccionTxtCodigo = "PropSeccionTxtCodigo";
        private String _propSeccionTxtCodigo = String.Empty;
        /// <summary>
        /// <para>Codigo (valor seleccion) Codigo seccion para referencia desde objetos</para>
        /// </summary>
        public String PropSeccionTxtCodigo
        {
            get { return _propSeccionTxtCodigo; }
            set
            {
                if (_propSeccionTxtCodigo == value) return;
                _propSeccionTxtCodigo = value;
                RaisePropertyChanged(gcrNomProp_PropSeccionTxtCodigo);
            }
        }
        #endregion
        #region PropSeccionIntOrdenVista: Orden de visualizacion de la seccion para la impresion
        public const String gcrNomProp_PropSeccionIntOrdenVista = "PropSeccionIntOrdenVista";
        private int _propSeccionIntOrdenVista = 0;
        /// <summary>
        /// <para>Orden de visualizacion de la seccion para la impresion</para>
        /// </summary>
        public int PropSeccionIntOrdenVista
        {
            get { return _propSeccionIntOrdenVista; }
            set
            {
                if (_propSeccionIntOrdenVista == value) return;
                _propSeccionIntOrdenVista = value;
                RaisePropertyChanged(gcrNomProp_PropSeccionIntOrdenVista);
            }
        }
        #endregion
        #region PropSeccionIntColumnas: Total columnas para organizar visualizacion de la seccion en impresion
        public const String gcrNomProp_PropSeccionIntColumnas = "PropSeccionIntColumnas";
        private int _propSeccionIntColumnas = 0;
        /// <summary>
        /// <para>Total columnas para organizar visualizacion de la seccion en impresion</para>
        /// </summary>
        public int PropSeccionIntColumnas
        {
            get { return _propSeccionIntColumnas; }
            set
            {
                if (_propSeccionIntColumnas == value) return;
                _propSeccionIntColumnas = value;
                RaisePropertyChanged(gcrNomProp_PropSeccionIntColumnas);
            }
        }
        #endregion
        #region PropSeccionTxtDescripcion: Descripcion de la sección
        public const String gcrNomProp_PropSeccionTxtDescripcion = "PropSeccionTxtDescripcion";
        private String _propSeccionTxtDescripcion = String.Empty;
        /// <summary>
        /// <para>Descripcion de la sección activa</para>
        /// </summary>
        public String PropSeccionTxtDescripcion
        {
            get { return _propSeccionTxtDescripcion; }
            set
            {
                if (_propSeccionTxtDescripcion == value) return;
                _propSeccionTxtDescripcion = value;
                RaisePropertyChanged(gcrNomProp_PropSeccionTxtDescripcion);
            }
        }
        #endregion
        #region regSeccion: Registro de la seccion activa en la lista
        public const string gcrNomProp_PropDatRegSeccion = "regSeccion";
        private XmlEntorno.ClassXmlComboBoxItems _propDatRegSeccion;
        /// <summary>
        /// <para>Registro activo en gestion Grilla secciones del formato</para>
        /// </summary>
        public XmlEntorno.ClassXmlComboBoxItems regSeccion
        {
            get { return _propDatRegSeccion; }
            set
            {
                if (_propDatRegSeccion == value) return;
                _propDatRegSeccion = value;
                RaisePropertyChanged(gcrNomProp_PropDatRegSeccion);
            }
        }
        #endregion
        #region tmpSecciones: Temporal secciones del formato
        public const string gcrNomProp_PropDatTempSecciones = "tmpSecciones";
        private List<XmlEntorno.ClassXmlComboBoxItems> _propDatRegListaSecciones;
        /// <summary>
        /// <para> Temporal lista secciones del formato</para>
        /// </summary>
        public List<XmlEntorno.ClassXmlComboBoxItems> tmpSecciones
        {
            get { return _propDatRegListaSecciones; }
            set
            {
                if (_propDatRegListaSecciones == value) return;
                _propDatRegListaSecciones = value;
                RaisePropertyChanged(gcrNomProp_PropDatTempSecciones);
            }
        }
        #endregion
        // Variables lista Etiquetas
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
        #region PropEtiqTxtVersion: Codigo de la version en uso plantilla
        public const String gcrNomProp_PropEtiqTxtVersion = "PropEtiqTxtVersion";
        private String _PropEtiqTxtVersion = String.Empty;
        /// <summary>
        /// <para>Codigo de la version en uso plantilla</para>
        /// </summary>
        public String PropEtiqTxtVersion
        {
            get { return _PropEtiqTxtVersion; }
            set
            {
                if (_PropEtiqTxtVersion == value) return;
                _PropEtiqTxtVersion = value;
                RaisePropertyChanged(gcrNomProp_PropEtiqTxtVersion);
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
        //- Galeria Imagenes predefinidas
        #region PropGalTxtRutayArchivo: Ruta origen y nombre archivo al adicionar imagen predefinida
        public const string gcrNomProp_PropGalTxtRutayArchivoOrigen = "PropGalTxtRutayArchivoOrigen";
        private string _propGalTxtRutayArchivoOrigen = string.Empty;
        /// <summary>
        /// <para>Ruta origen y nombre archivo al adicionar imagen predefinida</para>
        /// </summary>
        public string PropGalTxtRutayArchivoOrigen
        {
            get { return _propGalTxtRutayArchivoOrigen; }
            set
            {
                if (_propGalTxtRutayArchivoOrigen == value) return;
                _propGalTxtRutayArchivoOrigen = value;
                RaisePropertyChanged(gcrNomProp_PropGalTxtRutayArchivoOrigen);
            }
        }
        #endregion
        #region PropGalTxtRutayArchivoDestino: Ruta origen y nombre archivo al adicionar imagen predefinida
        public const string gcrNomProp_PropGalTxtRutayArchivoDestino = "PropGalTxtRutayArchivoDestino";
        private string _propGalTxtRutayArchivoDestino = string.Empty;
        /// <summary>
        /// <para>Ruta destino y nombre archivo al adicionar imagen predefinida</para>
        /// </summary>
        public string PropGalTxtRutayArchivoDestino
        {
            get { return _propGalTxtRutayArchivoDestino; }
            set
            {
                if (_propGalTxtRutayArchivoDestino == value) return;
                _propGalTxtRutayArchivoDestino = value;
                RaisePropertyChanged(gcrNomProp_PropGalTxtRutayArchivoDestino);
            }
        }
        #endregion
        #region PropGalIntCodigo: Inidice numerico para organizar Items imagenes predefinidas
        public const String gcrNomProp_PropGalIntCodigo = "PropGalIntCodigo";
        private int _propGalIntCodigo = 0;
        /// <summary>
        /// <para>Inidice numerico para organizar Items imagenes predefinidas</para>
        /// </summary>
        public int PropGalIntCodigo
        {
            get { return _propGalIntCodigo; }
            set
            {
                if (_propGalIntCodigo == value) return;
                _propGalIntCodigo = value;
                RaisePropertyChanged(gcrNomProp_PropGalIntCodigo);
            }
        }
        #endregion
        #region PropGalTxtCodigo: Codigo unico Interno generado para imagen predefinida
        public const string gcrNomProp_PropGalTxtCodigo = "PropGalTxtCodigo";
        private string _propGalTxtCodigo = string.Empty;
        /// <summary>
        /// <para>Codigo unico Interno generado para imagen predefinida</para>
        /// </summary>
        public string PropGalTxtCodigo
        {
            get { return _propGalTxtCodigo; }
            set
            {
                if (_propGalTxtCodigo == value) return;
                _propGalTxtCodigo = value;
                RaisePropertyChanged(gcrNomProp_PropGalTxtCodigo);
            }
        }
        #endregion
        #region PropGalTxtTitulo: Titulo en vista para la imagen predefinida
        public const string gcrNomProp_PropGalTxtTitulo = "PropGalTxtTitulo";
        private string _propGalTxtTitulo = string.Empty;
        /// <summary>
        /// <para>Titulo en vista para la imagen predefinida</para>
        /// </summary>
        public string PropGalTxtTitulo
        {
            get { return _propGalTxtTitulo; }
            set
            {
                if (_propGalTxtTitulo == value) return;
                _propGalTxtTitulo = value;
                RaisePropertyChanged(gcrNomProp_PropGalTxtTitulo);
            }
        }
        #endregion
        #region PropGalTxtHeight: Valor alto imagen predefinida
        public const string gcrNomProp_PropGalTxtHeight = "PropGalTxtHeight";
        private string _propGalTxtHeight = string.Empty;
        /// <summary>
        /// <para>Valor alto imagen predefinida</para>
        /// </summary>
        public string PropGalTxtHeight
        {
            get { return _propGalTxtHeight; }
            set
            {
                if (_propGalTxtHeight == value) return;
                _propGalTxtHeight = value;
                RaisePropertyChanged(gcrNomProp_PropGalTxtHeight);
            }
        }
        #endregion
        #region PropGalTxtWidth: Valor ancho imagen predefinida
        public const string gcrNomProp_PropGalTxtWidth = "PropGalTxtWidth";
        private string _propGalTxtWidth = string.Empty;
        /// <summary>
        /// <para>Valor ancho imagen predefinida</para>
        /// </summary>
        public string PropGalTxtWidth
        {
            get { return _propGalTxtWidth; }
            set
            {
                if (_propGalTxtWidth == value) return;
                _propGalTxtWidth = value;
                RaisePropertyChanged(gcrNomProp_PropGalTxtWidth);
            }
        }
        #endregion
        #region PropGalTxtRecursoArchivoTipo: Tipo recurso galeria de recursos para imagenes predefinidas
        public const string gcrNomProp_PropGalTxtRecursoArchivoTipo = "PropGalTxtRecursoArchivoTipo";
        private string _propGalTxtRecursoArchivoTipo = string.Empty;
        /// <summary>
        /// <para>Tipo recurso en la galeria de recursos ("IMAGEN").</para>
        /// <para>para lista de imagenes predefinidas</para>
        /// </summary>
        public string PropGalTxtRecursoArchivoTipo
        {
            get { return _propGalTxtRecursoArchivoTipo; }
            set
            {
                if (_propGalTxtRecursoArchivoTipo == value) return;
                _propGalTxtRecursoArchivoTipo = value;
                RaisePropertyChanged(gcrNomProp_PropGalTxtRecursoArchivoTipo);
            }
        }
        #endregion
        #region PropGalTxtRecursoArchivoCodigo: Codigo del recurso en galeria de recursos para imagenes predefinidas
        public const string gcrNomProp_PropGalTxtRecursoArchivoCodigo = "PropGalTxtRecursoArchivoCodigo";
        private string _propGalTxtRecursoArchivoCodigo = string.Empty;
        /// <summary>
        /// <para>Codigo del recurso en galeria de recursos para imagenes predefinidas.</para>
        /// </summary>
        public string PropGalTxtRecursoArchivoCodigo
        {
            get { return _propGalTxtRecursoArchivoCodigo; }
            set
            {
                if (_propGalTxtRecursoArchivoCodigo == value) return;
                _propGalTxtRecursoArchivoCodigo = value;
                RaisePropertyChanged(gcrNomProp_PropGalTxtRecursoArchivoCodigo);
            }
        }
        #endregion
        #region PropGalTxtRecursoArchivoUri: Ruta para buscar y cargar la imagen para imagenes predefinidas
        public const string gcrNomProp_PropGalTxtRecursoArchivoUri = "PropGalTxtRecursoArchivoUri";
        private string _propGalTxtRecursoArchivoUri = string.Empty;
        /// <summary>
        /// <para>Ruta para buscar y cargar la imagen para imagenes predefinidas.</para>
        /// </summary>
        public string PropGalTxtRecursoArchivoUri
        {
            get { return _propGalTxtRecursoArchivoUri; }
            set
            {
                if (_propGalTxtRecursoArchivoUri == value) return;
                _propGalTxtRecursoArchivoUri = value;
                RaisePropertyChanged(gcrNomProp_PropGalTxtRecursoArchivoUri);
            }
        }
        #endregion
        #region PropGalTxtRecursoArchivoNombre: Nombre del archivo de imagen para imagenes predefinidas
        public const string gcrNomProp_PropGalTxtRecursoArchivoNombre = "PropGalTxtRecursoArchivoNombre";
        private string _propGalTxtRecursoArchivoNombre = string.Empty;
        /// <summary>
        /// <para>Nombre del archivo de imagen para imagenes predefinidas.</para>
        /// </summary>
        public string PropGalTxtRecursoArchivoNombre
        {
            get { return _propGalTxtRecursoArchivoNombre; }
            set
            {
                if (_propGalTxtRecursoArchivoNombre == value) return;
                _propGalTxtRecursoArchivoNombre = value;
                RaisePropertyChanged(gcrNomProp_PropGalTxtRecursoArchivoNombre);
            }
        }
        #endregion
        #region regImgPredefItems: Registro activo para imagen predefinida activa
        public const string gcrNomProp_PropImgPredefItems = "regImgPredefItems";
        private XmlEntorno.ClassXmlImgPredefinidas _propImgPredefItems;
        /// <summary>
        /// <para>Registro activo para imagen predefinida activa en la vista</para>
        /// </summary>
        public XmlEntorno.ClassXmlImgPredefinidas regImgPredefItems
        {
            get { return _propImgPredefItems; }
            set
            {
                if (_propImgPredefItems == value) return;
                _propImgPredefItems = value;
                RaisePropertyChanged(gcrNomProp_PropImgPredefItems);
            }
        }
        #endregion
        #region tmpImgPredefItems: Temporal para lista de imagenes predefinidas
        public const string gcrNomProp_PropDatImgPredefItems = "tmpImgPredefItems";
        private List<XmlEntorno.ClassXmlImgPredefinidas> _propDatRegImgPredefItems;
        /// <summary>
        /// <para>Temporal para lista de imagenes predefinidas</para>
        /// </summary>
        public List<XmlEntorno.ClassXmlImgPredefinidas> tmpImgPredefItems
        {
            get { return _propDatRegImgPredefItems; }
            set
            {
                if (_propDatRegImgPredefItems == value) return;
                _propDatRegImgPredefItems = value;
                RaisePropertyChanged(gcrNomProp_PropDatImgPredefItems);
            }
        }
        #endregion
        #endregion
        // Propiedades Recursos archivos de imagen videos y otros
        #region Propiedades Recursos archivos de Imagen videos y docuentos pdf,doc,xls...
        #region PropTxtRecursoArchivoTipo: Tipo recurso en la galeria de recursos Imagenes videos y mas
        public const string gcrNomProp_PropTxtRecursoArchivoTipo = "PropTxtRecursoArchivoTipo";
        private string _propImgTxtRecursoArchivoTipo = string.Empty;
        /// <summary>
        /// <para>Tipo recurso en la galeria de recursos.</para>
        /// <para>Imagenes videos y docuentos pdf,doc,xls...</para>
        /// </summary>
        public string PropTxtRecursoArchivoTipo
        {
            get { return _propImgTxtRecursoArchivoTipo; }
            set
            {
                if (_propImgTxtRecursoArchivoTipo == value) return;
                _propImgTxtRecursoArchivoTipo = value;
                RaisePropertyChanged(gcrNomProp_PropTxtRecursoArchivoTipo);
            }
        }
        #endregion
        #region PropTxtRecursoArchivoCodigo: Codigo del recurso en la galeria de recursos
        public const string gcrNomProp_PropTxtRecursoArchivoCodigo = "PropTxtRecursoArchivoCodigo";
        private string _propImgTxtRecursoArchivoCodigo = string.Empty;
        /// <summary>
        /// <para>Codigo del recurso en la galeria de recursos.</para>
        /// </summary>
        public string PropTxtRecursoArchivoCodigo
        {
            get { return _propImgTxtRecursoArchivoCodigo; }
            set
            {
                if (_propImgTxtRecursoArchivoCodigo == value) return;
                _propImgTxtRecursoArchivoCodigo = value;
                RaisePropertyChanged(gcrNomProp_PropTxtRecursoArchivoCodigo);
            }
        }
        #endregion
        #region PropTxtRecursoArchivoUri: Ruta para buscar y cargar la imagen fija (solo para imagenes fijas)
        public const string gcrNomProp_PropTxtRecursoArchivoUri = "PropTxtRecursoArchivoUri";
        private string _propImgTxtRecursoArchivoUri = string.Empty;
        /// <summary>
        /// <para>Ruta para buscar y cargar la imagen fija (solo para imagenes fijas).</para>
        /// </summary>
        public string PropTxtRecursoArchivoUri
        {
            get { return _propImgTxtRecursoArchivoUri; }
            set
            {
                if (_propImgTxtRecursoArchivoUri == value) return;
                _propImgTxtRecursoArchivoUri = value;
                RaisePropertyChanged(gcrNomProp_PropTxtRecursoArchivoUri);
            }
        }
        #endregion
        #region PropTxtRecursoArchivoNombre: Nombre del archivo de imagen (solo para imagenes fijas)
        public const string gcrNomProp_PropTxtRecursoArchivoNombre = "PropTxtRecursoArchivoNombre";
        private string _propImgTxtRecursoArchivoNombre = string.Empty;
        /// <summary>
        /// <para>Nombre del archivo de imagen (solo para imagenes fijas).</para>
        /// </summary>
        public string PropTxtRecursoArchivoNombre
        {
            get { return _propImgTxtRecursoArchivoNombre; }
            set
            {
                if (_propImgTxtRecursoArchivoNombre == value) return;
                _propImgTxtRecursoArchivoNombre = value;
                RaisePropertyChanged(gcrNomProp_PropTxtRecursoArchivoNombre);
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
        // Propiedades varias
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
        #region PropDatTxtSiMostrarEnMuro: True/False para generar imagen o vista del objeto o variable en muro historial
        public const string gcrNomProp_PropDatTxtSiMostrarEnMuro = "PropDatTxtSiMostrarEnMuro";
        private string _propDatTxtSiMostrarEnMuro = string.Empty;
        /// <summary>
        /// <para>True/False para generar imagen o vista del objeto o variable en muro historial</para>
        /// </summary>
        public string PropDatTxtSiMostrarEnMuro
        {
            get { return _propDatTxtSiMostrarEnMuro; }
            set
            {
                if (_propDatTxtSiMostrarEnMuro == value) return;
                _propDatTxtSiMostrarEnMuro = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtSiMostrarEnMuro);
            }
        }
        #endregion
        #region PropDatTxtSiFiltroBusqueda: True/False para incluir en filtro busquedas desde muro historial
        public const string gcrNomProp_PropDatTxtSiFiltroBusqueda = "PropDatTxtSiFiltroBusqueda";
        private string _propDatTxtSiFiltroBusqueda = string.Empty;
        /// <summary>
        /// <para>True/False para incluir en filtro busquedas desde muro historial</para>
        /// </summary>
        public string PropDatTxtSiFiltroBusqueda
        {
            get { return _propDatTxtSiFiltroBusqueda; }
            set
            {
                if (_propDatTxtSiFiltroBusqueda == value) return;
                _propDatTxtSiFiltroBusqueda = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtSiFiltroBusqueda);
            }
        }
        #endregion
        #region PropDatTxtSiImprimir: Para saber si un objeto es imprimible
        public const string gcrNomProp_PropDatTxtSiImprimir = "PropDatTxtSiImprimir";
        private string _propDatTxtSiImprimir = String.Empty;
        /// <summary>
        /// <para>Para saber si un objeto es imprimible, Valor True/False, por defecto (True)</para>
        /// </summary>
        public string PropDatTxtSiImprimir
        {
            get { return _propDatTxtSiImprimir; }
            set
            {
                if (_propDatTxtSiImprimir == value) return;
                _propDatTxtSiImprimir = value;
                RaisePropertyChanged(gcrNomProp_PropDatTxtSiImprimir);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //- TXT - Popideades Plantilla activa
        //------------------------------------------------
        #region Propiedades Plantilla activa
        #region PropTxtPlantTipoImpresion: Tipo formato impresion permitido para la plantilla Vista Diseño/Tipo informe
        public const string gcrNomProp_PropTxtTipoImpresion = "PropTxtPlantTipoImpresion";
        private string _propTxtTipoImpresion = string.Empty;
        /// <summary>
        /// <para>Tipo formato impresion permitido para la plantilla Vista Diseño/Tipo informe</para>
        /// <para>1,2,3: "1"=Imprimir Vista diseño y tipo informe, "2"=Imprimir solo Vista diseño, "3"=Imprimir solo tipo informe</para>
        /// </summary>
        public string PropTxtPlantTipoImpresion
        {
            get { return _propTxtTipoImpresion; }
            set
            {
                if (_propTxtTipoImpresion == value) return;
                _propTxtTipoImpresion = value;
                RaisePropertyChanged(gcrNomProp_PropTxtTipoImpresion);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //- CBO - Lista para combobox relacionados con Propiedades
        //------------------------------------------------
        #region Lista de combos relacionados con Propiedades
        #region  PropCboTipoControl: Control para captura BLIQ = Balance liqidos MEDI=Medicamentos ...
        public const string gcrNomProp_PropCboTipoControl = "PropCboTipoControl";
        private List<ListaXmlValores> _propCboTipoControl;
        /// <summary>
        /// <para>Control para captura BLIQ = Balance liqidos MEDI=Medicamentos ...</para>
        /// </summary>
        public List<ListaXmlValores> PropCboTipoControl
        {
            get { return _propCboTipoControl; }
            set
            {
                if (_propCboTipoControl == value) return;
                _propCboTipoControl = value;
                RaisePropertyChanged(gcrNomProp_PropCboTipoControl);
            }
        }
        #endregion
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
        #region PropCboValorDefault: Lista de valores por defecto para el objeto dado
        public const string gcrNomProp_PropCboValorDefault = "PropCboValorDefault";
        private List<ListaXmlValores> _propCboValorDefault;
        /// <summary>
        /// <para>Lista de valores por defecto en listas ComboBox chekbox y radiobutton para el objeto dado.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboValorDefault
        {
            get { return _propCboValorDefault; }
            set
            {
                if (_propCboValorDefault == value) return;
                _propCboValorDefault = value;
                RaisePropertyChanged(gcrNomProp_PropCboValorDefault);
            }
        }
        #endregion
        #region PropCboSeccionCodigo: ComboBox Seccion del formato asociada al objeto dado
        public const string gcrNomProp_PropCboSeccionCodigo = "PropCboSeccionCodigo";
        private List<ListaXmlValores> _propCboSeccionCodigo;
        /// <summary>
        /// <para>ComboBox Seccion del formato que esta asociada al objeto dado.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboSeccionCodigo
        {
            get { return _propCboSeccionCodigo; }
            set
            {
                if (_propCboSeccionCodigo == value) return;
                _propCboSeccionCodigo = value;
                RaisePropertyChanged(gcrNomProp_PropCboSeccionCodigo);
            }
        }
        #endregion
        #region PropCboSeccionCodigoDfl: ComboBox Seccion del formato asociada al objeto seeccion activa por defecto
        /*
        public const string gcrNomProp_PropCboSeccionCodigoDfl = "PropCboSeccionCodigoDfl";
        private List<ListaXmlValores> _propCboSeccionCodigoDfl;
        /// <summary>
        /// <para>ComboBox Seccion del formato asociada al objeto seeccion activa por defecto.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboSeccionCodigoDfl
        {
            get { return _propCboSeccionCodigoDfl; }
            set
            {
                if (_propCboSeccionCodigoDfl == value) return;
                _propCboSeccionCodigoDfl = value;
                RaisePropertyChanged(gcrNomProp_PropCboSeccionCodigoDfl);
            }
        }
        */
        #endregion
        #region PropCboSiMostrarEnMuro: Lista de valores True/False para saber si el objeto o variable se muestra en muro
        public const string gcrNomProp_PropCboSiMostrarEnMuro = "PropCboSiMostrarEnMuro";
        private List<ListaXmlValores> _propCboSiMostrarEnMuro;
        /// <summary>
        /// <para>Lista de valores True/False para saber si el objeto o variable se muestra en muro.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboSiMostrarEnMuro
        {
            get { return _propCboSiMostrarEnMuro; }
            set
            {
                if (_propCboSiMostrarEnMuro == value) return;
                _propCboSiMostrarEnMuro = value;
                RaisePropertyChanged(gcrNomProp_PropCboSiMostrarEnMuro);
            }
        }
        #endregion
        #region PropCboSiFiltroBusqueda: Lista de valores True/False para saber si la varaible se suma en valores para busqueda en filtro muro
        public const string gcrNomProp_PropCboSiFiltroBusqueda = "PropCboSiFiltroBusqueda";
        private List<ListaXmlValores> _propCboSiFiltroBusqueda;
        /// <summary>
        /// <para>Lista de valores True/False para saber si la varaible se suma en valores para busqueda en filtro muro.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboSiFiltroBusqueda
        {
            get { return _propCboSiFiltroBusqueda; }
            set
            {
                if (_propCboSiFiltroBusqueda == value) return;
                _propCboSiFiltroBusqueda = value;
                RaisePropertyChanged(gcrNomProp_PropCboSiFiltroBusqueda);
            }
        }
        #endregion
        #region PropCboTamAdornos: Lista de valores adornos para ajuste tamaño de objetos
        public const string gcrNomProp_PropCboTamAdornos = "PropCboTamAdornos";
        private List<ListaXmlValores> _propCboTamAdornos;
        /// <summary>
        /// <para>Lista de valores adornos para ajuste tamaño de objetos.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboTamAdornos
        {
            get { return _propCboTamAdornos; }
            set
            {
                if (_propCboTamAdornos == value) return;
                _propCboTamAdornos = value;
                RaisePropertyChanged(gcrNomProp_PropCboTamAdornos);
            }
        }
        #endregion
        #region PropCboDatosTipo: Lista de Archivos RIPS o 4505 para aplicar valores
        public const string gcrNomProp_PropCboDatosTipo = "PropCboRefVarDatosTipo";
        private List<ListaXmlValores> _propCboDatosTipo;
        /// <summary>
        /// <para>Lista de Archivos RIPS o 4505 para aplicar valores.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboRefVarDatosTipo
        {
            get { return _propCboDatosTipo; }
            set
            {
                if (_propCboDatosTipo == value) return;
                _propCboDatosTipo = value;
                RaisePropertyChanged(gcrNomProp_PropCboDatosTipo);
            }
        }
        #endregion
        #region  PropCboIsRequerido: El valor del campo es requerido
        public const string gcrNomProp_PropCboIsRequerido = "PropCboIsRequerido";
        private List<ListaXmlValores> _propCboIsRequerido;
        /// <summary>
        /// <para>Lista opciones para marcar el campo como requerido o no requerido (Si/NO) True,False.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboIsRequerido
        {
            get { return _propCboIsRequerido; }
            set
            {
                if (_propCboIsRequerido == value) return;
                _propCboIsRequerido = value;
                RaisePropertyChanged(gcrNomProp_PropCboIsRequerido);
            }
        }
        #endregion
        #region PropCboAlineacionTexto: Alineación del texto (para Textbox y TextBlock)
        public const string gcrNomProp_PropCboAlineacionTexto = "PropCboAlineacionTexto";
        private List<ListaXmlValores> _propCboAlineacionTexto;
        /// <summary>
        /// <para>Lista opciones para alineación del texto (para Textbox y TextBlock)</para>
        /// <para>Alinaeacion del texto: Left=Izquieda Right=Derecha Center=Centrado Justify=Justificado</para>
        /// </summary>
        public List<ListaXmlValores> PropCboAlineacionTexto
        {
            get { return _propCboAlineacionTexto; }
            set
            {
                if (_propCboAlineacionTexto == value) return;
                _propCboAlineacionTexto = value;
                RaisePropertyChanged(gcrNomProp_PropCboAlineacionTexto);
            }
        }
        #endregion
        #region  PropCboFechaDefault: Lista Valores por defecto para campos tipo fecha
        public const string gcrNomProp_PropCboFechaDefault = "PropCboFechaDefault";
        private List<ListaXmlValores> _propCboFechaDefault;
        /// <summary>
        /// <para>Lista opciones por defecto para valor campos tipo fecha: 1=Valor Vacio 2=Fecha actual del sistema.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboFechaDefault
        {
            get { return _propCboFechaDefault; }
            set
            {
                if (_propCboFechaDefault == value) return;
                _propCboFechaDefault = value;
                RaisePropertyChanged(gcrNomProp_PropCboFechaDefault);
            }
        }
        #endregion
        #region  PropCboHoraDefault: Lista Valores por defecto para campos tipo hora
        public const string gcrNomProp_PropCboHoraDefault = "PropCboHoraDefault";
        private List<ListaXmlValores> _propCboHoraDefault;
        /// <summary>
        /// <para>Lista opciones por defecto para valor campos tipo Hora: 1=Hora vacia 2=Hora Actual del sistema.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboHoraDefault
        {
            get { return _propCboHoraDefault; }
            set
            {
                if (_propCboHoraDefault == value) return;
                _propCboHoraDefault = value;
                RaisePropertyChanged(gcrNomProp_PropCboHoraDefault);
            }
        }
        #endregion
        #region  PropCboSiMultiSet: Los datos en el objeto pueden ser editados despues de confirmar el formato de hc.
        public const string gcrNomProp_PropCboSiMultiSet = "PropCboSiMultiSet";
        private List<ListaXmlValores> _propCboSiMultiSet;
        /// <summary>
        /// <para>Los datos en el objeto pueden ser editados cuando estan vacios despues de confirmar el formato de hc.</para>
        /// <para>Lista opciones (Si/NO) "True" = Modificable en Varias sesiones,"False" = Se inactiva al confirmar los datos en el formato de HC.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboSiMultiSet
        {
            get { return _propCboSiMultiSet; }
            set
            {
                if (_propCboSiMultiSet == value) return;
                _propCboSiMultiSet = value;
                RaisePropertyChanged(gcrNomProp_PropCboSiMultiSet);
            }
        }
        #endregion
        #region  PropCboIsReadOnly: Los datos en el objeto pueden ser editados despues de confirmar el formato de hc.
        public const string gcrNomProp_PropCboIsReadOnly = "PropCboIsReadOnly";
        private List<ListaXmlValores> _propCboIsReadOnly;
        /// <summary>
        /// <para>El dato es solo lectura, activa o inactiva actualziar variable publica actualizable</para>
        /// <para>Por defecto (False) Lista opciones (Si/NO) "True" = Datos modificables,"False" = Datos no modificables (solo lectura)</para>
        /// </summary>
        public List<ListaXmlValores> PropCboIsReadOnly
        {
            get { return _propCboIsReadOnly; }
            set
            {
                if (_propCboIsReadOnly == value) return;
                _propCboIsReadOnly = value;
                RaisePropertyChanged(gcrNomProp_PropCboIsReadOnly);
            }
        }
        #endregion
        #region  PropCboSiImprimir: Indica si el objeto es imprimible True/False (por defecto True)
        public const string gcrNomProp_PropCboSiImprimir = "PropCboSiImprimir";
        private List<ListaXmlValores> _propCboSiImprimir;
        /// <summary>
        /// <para>Indica si el objeto es imprimible True/False (por defecto True).</para>
        /// <para>Lista opciones "True" = Objeto Imprimible,"False" = No enviar a impresora.</para>
        /// </summary>
        public List<ListaXmlValores> PropCboSiImprimir
        {
            get { return _propCboSiImprimir; }
            set
            {
                if (_propCboSiImprimir == value) return;
                _propCboSiImprimir = value;
                RaisePropertyChanged(gcrNomProp_PropCboSiImprimir);
            }
        }
        #endregion
        #region  PropCboPrnSiValidar: Lista para indicar si se envian a impresion los valores digitados
        public const string gcrNomProp_PropPrnSiValidar = "PropCboPrnSiValidar";
        private List<ListaXmlValores> _propPrnSiValidar;
        /// <summary>
        /// <para>Validar si valores por defecto se envian a reporte impreso, 1,2,3,4 (por defecto "1")</para>
        /// <para>1,2,3,4: "1"=Todos los valores se imprimen, "2"=Solo Valores de la lista...</para>
        /// </summary>
        public List<ListaXmlValores> PropCboPrnSiValidar
        {
            get { return _propPrnSiValidar; }
            set
            {
                if (_propPrnSiValidar == value) return;
                _propPrnSiValidar = value;
                RaisePropertyChanged(gcrNomProp_PropPrnSiValidar);
            }
        }
        #endregion
        #region PropCboPrnMostrarTitulo: indicar si se muestra el titulo del dato al enviar a impresión
        public const string gcrNomProp_PropPrnMostrarTitulo = "PropCboPrnMostrarTitulo";
        private List<ListaXmlValores> _propPrnMostrarTitulo;
        /// <summary>
        /// <para>indicar si se muestra el titulo del dato al enviar a impresión (por defecto 1=Mostrar)</para>
        /// <para>1,2: "1"=Ver el titulo en impresion, "2"=No mostrar titulo en impresion</para>
        /// </summary>
        public List<ListaXmlValores> PropCboPrnMostrarTitulo
        {
            get { return _propPrnMostrarTitulo; }
            set
            {
                if (_propPrnMostrarTitulo == value) return;
                _propPrnMostrarTitulo = value;
                RaisePropertyChanged(gcrNomProp_PropPrnMostrarTitulo);
            }
        }
        #endregion
        #region PropCboPlantTipoImpresion: Tipo formato impresion permitido para la plantilla Vista Diseño/Tipo informe
        public const string gcrNomProp_PropPlantTipoImpresion = "PropCboPlantTipoImpresion";
        private List<ListaXmlValores> _propPlantTipoImpresion;
        /// <summary>
        /// <para>Tipo formato para imresion permitidos en la pantilla: Vista Diseño/Tipo informe (por defecto "1" = Vista diseño y Tipo informe)</para>
        /// <para>1,2,3: "1"=Imprimir Vista diseño y tipo informe, "2"=Imprimir solo Vista diseño, "3"=Imprimir solo tipo informe</para>
        /// </summary>
        public List<ListaXmlValores> PropCboPlantTipoImpresion
        {
            get { return _propPlantTipoImpresion; }
            set
            {
                if (_propPlantTipoImpresion == value) return;
                _propPlantTipoImpresion = value;
                RaisePropertyChanged(gcrNomProp_PropPlantTipoImpresion);
            }
        }
        #endregion
        #region PropCboPlantTipoHojaReporte: Configuracion del tamaño del papel para impresion en formato "Tipo informe"
        public const string gcrNomProp_PropPlantTipoHojaReporte = "PropCboPlantTipoHojaReporte";
        private List<ListaXmlValores> _propPlantTipoHojaReporte;
        /// <summary>
        /// <para>indicar Configuracion del tamaño del papel para impresion en formato "Tipo informe"</para>
        /// <para>01,02,03: "01"=Hoja tamaño carta, "02"=Hoja tamaño oficion, "03"=Hoja tamaño...</para>
        /// </summary>
        public List<ListaXmlValores> PropCboPlantTipoHojaReporte
        {
            get { return _propPlantTipoHojaReporte; }
            set
            {
                if (_propPlantTipoHojaReporte == value) return;
                _propPlantTipoHojaReporte = value;
                RaisePropertyChanged(gcrNomProp_PropPlantTipoHojaReporte);
            }
        }
        #endregion
        #region PropCboVarGestPosVector: Lista tipo valor gestion Variable Publica
        public const string gcrNomProp_PropCboVarGestPosVector = "PropCboVarGestPosVector";
        private List<ListaXmlValores> _propCboVarGestPosVector;
        /// <summary>
        /// <para>Lista tipo Valor gestion Variable Publica (cuando aplique)/N=No Aplica/0=Campo solo captura de datos/1= Posicion elemento1/2=Posicion elemento2 /3...</para>
        /// </summary>
        public List<ListaXmlValores> PropCboVarGestPosVector
        {
            get { return _propCboVarGestPosVector; }
            set
            {
                if (_propCboVarGestPosVector == value) return;
                _propCboVarGestPosVector = value;
                RaisePropertyChanged(gcrNomProp_PropCboVarGestPosVector);
            }
        }
        #endregion
        #endregion
        //- Para hacer seguimiento a deshacer ojo----------------- quitar mas adelante
        #region  TmpEliminados: para ver los eliminados
        public const string gcrNomProp_PropCboTmpEliminados = "TmpEliminados";
        private List<ClassXmlPropObjeto> _propCboTmpEliminados;
        /// <summary>
        /// <para>Lista Mostrar / Ocultar Titulo objeto (cuando exista => true/False)</para>
        /// </summary>
        public List<ClassXmlPropObjeto> TmpEliminados
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
        private List<ClassXmlPropObjeto> _propCboTmpTmpAccion;
        /// <summary>
        /// <para>Acciones en objetos</para>
        /// </summary>
        public List<ClassXmlPropObjeto> TmpAccion
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
        // Comandos lista ref achivos actualizables 4505/Rips...
        // -aqui-
        //Comandos para agregar Lista de ComboBoxItem
        public RelayCommand CmdComboItemNuevo { get; set; }
        public RelayCommand CmdComboItemSave { get; set; }
        public RelayCommand CmdComboItemEliminar { get; set; }
        //Comandos para agregar Lista Secciones
        public RelayCommand CmdSeccionesNuevo { get; set; }
        public RelayCommand CmdSeccionesSave { get; set; }
        public RelayCommand CmdSeccionesEliminar { get; set; }
        // Comandos para agregar Lista de Etiquetas
        //-----------------------------------------------
        public RelayCommand CmdRadioButton { get; set; }
        public RelayCommand CmdCheckBox { get; set; }
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
            // Botones lista ref achivos actualizables 4505/Rips...
            // -aqui- 

            // Botones Items para ComboBox Desplegable
            CmdComboItemNuevo    = new RelayCommand(fcvAccionComboItemNuevo, CanComboItemNuevo); 
            CmdComboItemSave     = new RelayCommand(fcvAccionComboItemSave, CanComboItemSave);       
            CmdComboItemEliminar = new RelayCommand(fcvAccionComboItemEliminar, CanComboItemEliminar);
            // Botones Items para Secciones
            CmdSeccionesNuevo    = new RelayCommand(fcvAccionSeccionNuevo, CanSeccionNuevo);
            CmdSeccionesSave     = new RelayCommand(fcvAccionSeccionSave, CanSeccionSave);
            CmdSeccionesEliminar = new RelayCommand(fcvAccionSeccionEliminar, CanSeccionEliminar);
            // Activar Botones barra de Herramientas
            CmdRadioButton  = new RelayCommand(fcvAccBotones, CanRadioButton);
            CmdCheckBox     = new RelayCommand(fcvAccBotones, CanCheckBox);
            CmdCamposTexto  = new RelayCommand(fcvAccPropValoresTexto, CanCamposTexto);

            // Comandos para Botones add pagina, eliminar objetos, Deshacer, Rehacer 
            CmdEdtDeshacer       = new RelayCommand(fcvAccBotones, CanEdtDeshacer);
            CmdEdtRehacer        = new RelayCommand(fcvAccBotones, CanEdtRehacer);
            CmdEdtEliminarPagina = new RelayCommand(fcvAccBotones, CanEliminarPagina);
            CmdEdtEliminarObjeto = new RelayCommand(fcvAccBotones, CanEliminarObjeto);
        }
        #endregion
        //-------------------------------------------------
        // ACCION  COMANDOS BOTONES DE GESTION
        //-------------------------------------------------
        #region Metodos acciones comandos Pestaña Propieades
        #region fcvAccBotones
        /// <summary>
        /// Accion Botones barra de herramientas, por defecto solo para cumplir con comando
        /// </summary>
        public virtual void fcvAccBotones()
        {
            try
            {
                // accion nada por defecto solo para cumplir con comando
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccBotones");
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccPropValoresTexto");
            }
        }
        #endregion
        #endregion
        #region Metodos acciones comandos Gestion ComboBox, secciones, Etiquetas y campos actualizables
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
                PropItemTxtParent = PropTxtName.Trim();
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
            foreach (var lobReg in tmpComboBoxItems)
            {
                lobReg.IntIndice = lnuValor;
                lnuValor++;
            }
            return lnuValor;
        }
        #endregion
        //- Gestion Secciones del formato
        #region fcvAccionSeccionNuevo: Adicionar una nueva seccion
        /// <summary>
        /// Adicionar una nueva seccion
        /// </summary>
        public void fcvAccionSeccionNuevo()
        {
            try
            {
                fcvGridReiniVariables("S");
                PropSeccionIntOrdenVista = fnuAccionSeccionGenSecuencial();

                regSeccion = new XmlEntorno.ClassXmlComboBoxItems();
                regSeccion.Imaen = "A";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionSeccionNuevo");
            }
        }
        #endregion
        #region fcvAccionSeccionSave: Guardar en temporal secciones
        /// <summary>
        /// Guardar en temporal secciones
        /// </summary>
        public void fcvAccionSeccionSave()
        {
            try
            {
                // Cuando es un nuevo registro
                if (String.IsNullOrEmpty(PropSeccionTxtIndice))
                {
                    PropSeccionIntIndice = fnuAccionSeccionGenSecuencial();
                    PropSeccionTxtIndice = PropSeccionIntIndice.ToString().Trim();
                    PropSeccionTxtCodigo = PropSeccionTxtIndice.Length < 2 ? "0" + PropSeccionTxtIndice : PropSeccionTxtIndice;
                    PropSeccionIntOrdenVista = PropSeccionIntIndice;
                }
                regSeccion.Imaen = String.IsNullOrEmpty(regSeccion.Imaen) ? "A" : regSeccion.Imaen;

                if (regSeccion.Imaen != "A") { regSeccion.Imaen = "M"; } // es modificado
                fcvGridCargarRegActivoDesdeVariables("S");
                fcvAccionSeccionSaveEx(regSeccion);

                //- Preparar para Adicionar otro
                fcvAccionSeccionNuevo();
                PropNotifCambioListView = "SECCION";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionSeccionSave");
            }
        }
        #endregion
        #region fcvAccionSeccionEliminar: Eliminar registros del temporal secciones del formato
        /// <summary>
        /// Eliminar registros del temporal secciones del formato
        /// </summary>
        public void fcvAccionSeccionEliminar()
        {
            try
            {
                if (!String.IsNullOrEmpty(PropSeccionTxtIndice) && regSeccion != null)
                {
                    regSeccion.Imaen = "I"; // eliminar 
                    fcvAccionSeccionSaveEx(regSeccion);
                    fcvAccionSeccionNuevo();

                    if (PropTxtSeccionCodigo==regSeccion.Codigo)
                    {
                        PropTxtSeccionCodigo = PropTxtSeccionDefault; // si se eleimino la seccion del objeto activo
                    }

                    PropNotifCambioListView = "SECCION-DEL";
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionSeccionEliminar");
            }
        }
        #endregion
        #region fcvAccionSeccionSaveEx: Guardar los datos en temporal secciones
        /// <summary>
        /// Guardar los datos en temporal secciones
        /// </summary>
        public void fcvAccionSeccionSaveEx(XmlEntorno.ClassXmlComboBoxItems tobRegistro)
        {
            tmpSecciones.Remove(tobRegistro);
            //- Actualizar en  temporales
            if (tobRegistro.Imaen == "A" || tobRegistro.Imaen == "M")
            {
                tmpSecciones.Add(tobRegistro);
                tmpSecciones = (from tmp in tmpSecciones orderby tmp.IntOrden select tmp).ToList();
            }
        }
        #endregion
        #region fnuAccionSeccionGenSecuencial: Generar nuevo secuencial secciones para metodo Add
        /// <summary>
        /// <para>Genera los nuevos secuenciales para el temporal Secciones desde metodo adicion nuevo</para>
        /// </summary>
        public int fnuAccionSeccionGenSecuencial()
        {
            var lnuValor = 0;
            var tmpAux = (from tmp in tmpSecciones orderby tmp.IntIndice select tmp).ToList();

            foreach (var lobReg in tmpAux)
            {
                lnuValor = lobReg.IntIndice;
            }
            lnuValor++;

            return lnuValor;
        }
        #endregion
        #region fnuAccionSeccionReOrganizarSecuencial: Organizar y generar nuevo secuencial secciones
        /// <summary>
        /// <para>Organiza y genera los nuevos secuenciales para el temporal Secciones</para>
        /// </summary>
        public int fnuAccionSeccionReOrganizarSecuencial()
        {
            var lnuValor = 1;
            var lcrValor = String.Empty;

            foreach (var lobReg in tmpSecciones)
            {
                lcrValor = lnuValor.ToString().Trim();

                lobReg.Auxiliar     = lobReg.Codigo; // Para reasignar/actualizar codigos secciones en objetos
                lobReg.IntIndice    = lnuValor;
                lobReg.Codigo       = lcrValor.Length < 2 ? "0" + lcrValor : lcrValor;

                lnuValor++;
            }
            return lnuValor;
        }
        #endregion
        //- Gestion Adicionar Items Lista Campos actualizables 4505/Rips
        // -aqui-
        #region fcvAccionCamposActualizables: Adicionar Item Lista campos actualizables 4505/Rips...
        /// <summary>
        /// Adicionar Item Lista campos actualizables 4505/Rips...
        /// </summary>
        public void fcvAccionCamposActualizables()
        {
            try
            {
                fcvGridReiniVariables("L");
                regArchActualiz.Parent = PropTxtName.Trim();
                regArchActualiz = new XmlEntorno.ClassXmlRefActualizArchivos();
                regArchActualiz.Imaen = "A";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAccionCamposActualizables");
            }
        }
        #endregion

        #endregion
        //-------------------------------------------------
        // COMANDOS DE ACTIVACION BOTONES
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
        #region CanCheckBox
        /// <summary>
        /// Activar o desactivar comando add CanCheckBox
        /// </summary>
        public bool CanCheckBox()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && !String.IsNullOrWhiteSpace(PropTxtTipoObjeto))
                {
                    llgReturn = EdtUtilidades.flgSiContenedorAdicionarObjeto(gcrTipoContenedorActivo, "MULTICHKBOX");
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanCheckBox");
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanCamposTexto");
            }
            return llgReturn;
        }
        #endregion
        #endregion
        #region Comandos de activacion lista ref achivos actualizables 4505/Rips...
        //-aqui-
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanComboItemNuevo");
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
        #region Comandos de activacion Botones Secciones del formato
        #region CanSeccionNuevo
        /// <summary>
        /// Activar Adicionar nueva seccion del formato
        /// </summary>
        public bool CanSeccionNuevo()
        {
            bool llgReturn = false;
            try
            {
                glgPuedeEditarItemsSecciones = false;
                if (GlgSIS_ModoEdicion == true)
                {
                    llgReturn = true;
                    glgPuedeEditarItemsSecciones = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSeccionNuevo");
            }
            return llgReturn;
        }
        #endregion
        #region CanSeccionSave
        /// <summary>
        /// Activar Guardar nueva seccion del formato
        /// </summary>
        public bool CanSeccionSave()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    #region Valores Variables
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("PropSeccionIntOrdenVista")) &&
                                String.IsNullOrEmpty(fcrValidacion("PropSeccionIntColumnas")) &&
                                String.IsNullOrEmpty(fcrValidacion("PropSeccionTxtDescripcion"));
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSeccionSave");
            }
            return llgReturn;
        }
        #endregion
        #region CanSeccionEliminar: Activar Eliminar seccion del formato
        /// <summary>
        /// Activar Eliminar seccion del formato
        /// </summary>
        public bool CanSeccionEliminar()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && PropSeccionTxtCodigo != "01") // no eliminar seccion por defecto
                {
                    llgReturn = tmpSecciones != null ? true : false;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSeccionEliminar");
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
        /// <para>Reiniciar Variables:</para>
        /// <para>tcrGrupo: P=Propiedades L= Archivos actualizables 4505/Rips..., I=Items comboBox E=Etiquetas G=Imagenes predefinidas y A=Todas</para>
        /// <para>S = Secciones del formato</para>
        /// <para> TI = Temporales ComboBoxItems TL=Temporales Campos actualizables 4505/Rips, TS= Temporales secciones del formato</para>
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
                    PropTxtToolTip              = String.Empty;
                    PropTxtTituloVisible        = String.Empty;
                    PropTxtTipoObjeto           = String.Empty;
                    PropTxtClaseBase            = String.Empty;
                    PropTxtParent               = String.Empty;
                    PropTxtTabIndex             = String.Empty;
                    PropTxtOrdenVista           = String.Empty;
                    PropTxtPagina               = String.Empty;
                    PropTxtCambiarTabs          = String.Empty;
                    PropTxtFocusable            = String.Empty;
                    PropTxtIsEnabled            = String.Empty;
                    PropTxtVisibility           = String.Empty;
                    PropTxtSeccionDefault       = "01";
                    PropTxtSeccionCodigo        = PropTxtSeccionDefault;
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
                    PropDatTxtBindingTabla      = String.Empty;
                    PropDatTxtValorDefault      = String.Empty;
                    PropDatTxtTotalItems        = String.Empty;
                    PropDatTxtNombreVariable    = String.Empty;
                    PropDatTxtVariablePublica   = String.Empty;
                    PropDatTxtTipoDato          = String.Empty;
                    PropDatTxtTipoOrigenDatos   = String.Empty;
                    PropDatTxtTablaOrigen       = String.Empty;
                    PropDatTxtCodigoEtiqueta    = String.Empty;
                    PropDatTxtRangoInicial      = String.Empty;
                    PropDatTxtRangoFinal        = String.Empty;
                    PropDatTxtIsRequerido       = String.Empty;
                    PropDatTxtSiMultiSet        = String.Empty;
                    PropDatTxtIsReadOnly        = String.Empty;
                    PropDatTxtPrnSiValidar      = String.Empty;
                    PropDatTxtPrnValorDefault   = String.Empty;
                    PropDatTxtPrnValorPreView   = String.Empty;
                    // Propiedades Recursos imagenes y otros
                    PropTxtRecursoArchivoTipo    = String.Empty;
                    PropTxtRecursoArchivoCodigo  = String.Empty;
                    PropTxtRecursoArchivoUri     = String.Empty;
                    PropTxtRecursoArchivoNombre  = String.Empty;
                    PropImgTxtStretch               = String.Empty;
                    PropImgTxtStretchDirection      = String.Empty;
                    // Propiedades Varias
                    PropTxtSiValorCalculado         = String.Empty;
                    PropDatTxtSiMostrarEnMuro       = String.Empty;
                    PropDatTxtSiFiltroBusqueda      = String.Empty;
                    PropDatTxtSiImprimir            = String.Empty;
                    // control para validacion Alto,Ancho,Ajuste Izquierda y Ajuste Arriba
                    gcrValidPropDistribucion        = "1111";
                    //- Datos items cuando es ComboBox 
                    fcvGridReiniVariables("I");
                    //- Temporal de valores por defecto
                    PropCboValorDefault = new List<ListaXmlValores>();
                    //PropCboSeccionCodigo = new List<ListaXmlValores>();
                    #endregion
                }
                #endregion
                #region Archivos actualizables 4505/Rips..
                //-aqui-
                if (tcrGrupo == "L" || tcrGrupo == "A")
                {
                    #region Valores Variables
                    PropArchActualizIntIndice     = 0;
                    PropArchActualizParent        = String.Empty;
                    PropArchActualizIndice        = String.Empty;
                    PropArchActualizCodigoArchivo = String.Empty;
                    PropArchActualizTituloArchivo = String.Empty;
                    PropArchActualizCodigoCampo   = String.Empty;
                    PropArchActualizTituloCampo   = String.Empty;
                    PropArchActualizDepenCampo    = String.Empty;
                    PropArchActualizValorQueReporta = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables ComboBox items
                if (tcrGrupo == "I" || tcrGrupo == "A")
                {
                    #region Valores Variables lista objetos combobox
                    PropItemIntIndice       = 0;
                    PropItemTxtParent       = PropTxtName.Trim();
                    PropItemTxtIndice       = String.Empty;
                    PropItemTxtCodigo       = String.Empty;
                    PropItemTxtDescripcion  = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Secciones del formato
                if (tcrGrupo == "S" || tcrGrupo == "A")
                {
                    #region Valores Variables Secciones del formato
                    PropSeccionIntIndice        = 0;
		            PropSeccionIntOrdenVista    = 0;
                    PropSeccionIntColumnas      = 0;
                    PropSeccionTxtIndice        = String.Empty;
                    PropSeccionTxtCodigo        = String.Empty;
                    PropSeccionTxtDescripcion   = String.Empty;
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
                #region Reiniciar temporales Secciones del formato
                if (tcrGrupo == "TS" || tcrGrupo == "A")
                {
                    // Temporales 
                    regSeccion = new XmlEntorno.ClassXmlComboBoxItems();
                    tmpSecciones = new List<XmlEntorno.ClassXmlComboBoxItems>();
                }
                #endregion
                #region Reiniciar temporales Campos actualizables
                if (tcrGrupo == "TL" || tcrGrupo == "A")
                {
                    // Temporales 
                    regArchActualiz = new XmlEntorno.ClassXmlRefActualizArchivos();
                    tmpArchActualiz = new List<XmlEntorno.ClassXmlRefActualizArchivos>();
                }
                #endregion
                #region Reiniciar Variables Etiquetas
                if (tcrGrupo == "E" || tcrGrupo == "A")
                {
                    #region Valores Variables
                    PropEtiqIntIndice       = 0;
                    PropEtiqTxtIndice       = String.Empty;
                    PropEtiqTxtCodigo       = String.Empty;
                    PropEtiqTxtVersion      = String.Empty;
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
                #region Reiniciar Variables Imagenes predefinidas
                if (tcrGrupo == "G" || tcrGrupo == "A")
                {
                    #region Valores Variables
                    PropGalTxtRutayArchivoOrigen = String.Empty;
                    PropGalTxtRutayArchivoDestino = String.Empty;
                    PropGalIntCodigo = 0;
                    PropGalTxtCodigo = String.Empty;
                    PropGalTxtTitulo = String.Empty;
                    PropGalTxtHeight = String.Empty;
                    PropGalTxtWidth = String.Empty;
                    PropGalTxtRecursoArchivoTipo = String.Empty;
                    PropGalTxtRecursoArchivoCodigo = String.Empty;
                    PropGalTxtRecursoArchivoUri = String.Empty;
                    PropGalTxtRecursoArchivoNombre = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar temporales Imagenes predefinidas
                if (tcrGrupo == "TG" || tcrGrupo == "A")
                {
                    regImgPredefItems = new XmlEntorno.ClassXmlImgPredefinidas();
                    tmpImgPredefItems = new List<XmlEntorno.ClassXmlImgPredefinidas>();
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
        /// <para>tcrGrupo: L=Archivos actualizables 4505/Rips.., I=Items comboBox E=Etiquetas G=Imagenes predefinidas y A=Todas</para>
        /// <para>S = Secciones del formato</para>
        /// </summary>
        public void fcvGridCargarRegActivoDesdeVariables(string tcrGrupo)
        {
            try
            {
                #region Archivos actualizables 4505/Rips..
                //-aqui-
                if (tcrGrupo == "L" || tcrGrupo == "A")
                {
                    if (regComboBoxItems != null)
                    {
                        #region Valores Variables
                        regArchActualiz.IntIndice      = PropArchActualizIntIndice;
                        regArchActualiz.Parent         = PropArchActualizParent;
                        regArchActualiz.Indice         = PropItemTxtIndice;
                        regArchActualiz.Archivo        = PropArchActualizCodigoArchivo;
                        regArchActualiz.ArchivoTitulo  = PropArchActualizTituloArchivo;
                        regArchActualiz.Campo          = PropArchActualizCodigoCampo;
                        regArchActualiz.CampoTitulo    = PropArchActualizTituloCampo;
                        regArchActualiz.DependienteDe  = PropArchActualizDepenCampo;
                        regArchActualiz.ValorReporta   = PropArchActualizValorQueReporta;
                        #endregion
                    }
                }
                #endregion
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
                #region Cargar Seccion del formato
                if (tcrGrupo == "S" || tcrGrupo == "A")
                {
                    if (regSeccion != null)
                    {
                        #region Valores Variables
                        regSeccion.IntIndice        = PropSeccionIntIndice;
                        regSeccion.IntOrden         = PropSeccionIntOrdenVista;
                        regSeccion.IntTotalColumnas = PropSeccionIntColumnas;
                        regSeccion.Indice           = PropSeccionTxtIndice;
                        regSeccion.Codigo           = PropSeccionTxtCodigo;
                        regSeccion.Descripcion      = PropSeccionTxtDescripcion;
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
                        regEtiquetaItems.Version     = PropEtiqTxtVersion;
                        regEtiquetaItems.Icono       = PropEtiqTxtIcono;
                        regEtiquetaItems.Descripcion = PropEtiqTxtDescripcion;
                        #endregion
                    }
                }
                #endregion
                #region Cargar registro activo imagenes predefinidas
                if (tcrGrupo == "G" || tcrGrupo == "A")
                {
                    if (regImgPredefItems != null)
                    {
                        #region Valores Variables
                        regImgPredefItems.IntCodigo             = PropGalIntCodigo;
                        regImgPredefItems.Codigo                = PropGalTxtCodigo;
                        regImgPredefItems.TipoObjeto            = "IMAGEN";
                        regImgPredefItems.ClaseBase             = "Image";
                        regImgPredefItems.Titulo                = PropGalTxtTitulo;
                        regImgPredefItems.ImagenWidth           = PropGalTxtWidth;
                        regImgPredefItems.ImagenHeight          = PropGalTxtHeight;
                        regImgPredefItems.RecursoArchivoTipo    = PropGalTxtRecursoArchivoTipo;
                        regImgPredefItems.RecursoArchivoCodigo  = PropGalTxtRecursoArchivoCodigo;
                        regImgPredefItems.RecursoArchivoUri     = PropGalTxtRecursoArchivoUri;
                        regImgPredefItems.RecursoArchivoNombre  = PropGalTxtRecursoArchivoNombre;
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
        /// <para>tcrGrupo: P=Propiedades, L= lista Archivos actualizables 4505/Rips..., I=Items comboBox E=Etiquetas G = Imagenes predefinidas y A=Todas</para>
        /// <para>S = Secciones del formato</para>
        /// </summary>
        public void fcvGridCargarVariablesDesdeRegActivo(String tcrGrupo)
        {
            try
            {
                #region L: Cargar lista ref achivos actualizables 4505/Rips...
                //-aqui-
                if (tcrGrupo == "L" || tcrGrupo == "A")
                {
                    /*
                    if (regComboBoxItems != null)
                    {
                        #region Valores Variables
                        PropItemIntIndice = regComboBoxItems.IntIndice;
                        PropItemTxtParent = regComboBoxItems.Parent;
                        PropItemTxtIndice = regComboBoxItems.Indice;
                        PropItemTxtCodigo = regComboBoxItems.Codigo;
                        PropItemTxtDescripcion = regComboBoxItems.Descripcion;
                        #endregion
                    }
                    */
                }
                #endregion
                #region I: Cargar Variables desde registro activo ComboBox items
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
                #region s: Cargar Variables Seccion del formato
                if (tcrGrupo == "S" || tcrGrupo == "A")
                {
                    if (regSeccion != null)
                    {
                        #region Valores Variables
                        PropSeccionIntIndice     = regSeccion.IntIndice;
                        PropSeccionIntOrdenVista = regSeccion.IntOrden;
                        PropSeccionIntColumnas   = regSeccion.IntTotalColumnas;
                        PropSeccionTxtIndice     = regSeccion.Indice;
                        PropSeccionTxtCodigo     = regSeccion.Codigo;
                        PropSeccionTxtDescripcion= regSeccion.Descripcion;
                        #endregion
                    }
                }
                #endregion
                #region E: Cargar Variables desde registro activo Etiquetas
                if (tcrGrupo == "E" || tcrGrupo == "A")
                {
                    if (regEtiquetaItems != null)
                    {
                        #region Valores Variables
                        PropEtiqIntIndice       = regEtiquetaItems.IntIndice;
                        PropEtiqTxtIndice       = regEtiquetaItems.Indice;
                        PropEtiqTxtCodigo       = regEtiquetaItems.Codigo;
                        PropEtiqTxtVersion      = regEtiquetaItems.Version;
                        PropEtiqTxtIcono        = regEtiquetaItems.Icono;
                        PropEtiqTxtDescripcion  = regEtiquetaItems.Descripcion;
                        #endregion
                    }
                }
                #endregion
                #region G: Cargar variables desde registro activo imagenes predefinidas
                if (tcrGrupo == "G" || tcrGrupo == "A")
                {
                    if (regImgPredefItems != null)
                    {
                        #region Valores Variables
                        PropGalIntCodigo                = regImgPredefItems.IntCodigo;
                        PropGalTxtCodigo                = regImgPredefItems.Codigo;
                        PropGalTxtTitulo                = regImgPredefItems.Titulo;
                        PropGalTxtWidth                 = regImgPredefItems.ImagenWidth;
                        PropGalTxtHeight                = regImgPredefItems.ImagenHeight;
                        PropGalTxtRecursoArchivoTipo    = regImgPredefItems.RecursoArchivoTipo;
                        PropGalTxtRecursoArchivoCodigo  = regImgPredefItems.RecursoArchivoCodigo;
                        PropGalTxtRecursoArchivoUri     = regImgPredefItems.RecursoArchivoUri;
                        PropGalTxtRecursoArchivoNombre  = regImgPredefItems.RecursoArchivoNombre;
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
        public virtual String fcrValidacion(string tcrNombrePropiedad)
        {
            String lcrValorReturn = String.Empty;
            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "PropTxtTitulo": // Titulo Objeto
                        glgSiValidPropiedadObjeto = true;
                        if (String.IsNullOrWhiteSpace(PropTxtTitulo))
                        {
                            lcrValorReturn = "Titulo objeto: Es requerido";
                            glgSiValidPropiedadObjeto = false;
                        }
                        break;

                    case "PropTxtTabIndex": // Alto
                        lcrValorReturn = fcrValidacionNumerica(PropTxtTabIndex, 1, 2000, "Orden tabulación");
                        break;

                    case "PropTxtHeight": // Alto
                        lcrValorReturn = fcrValidacionNumerica(PropTxtHeight, 1, 2000, "Alto Objeto");
                        SetValidPropDistribucion(1, lcrValorReturn);
                        break;

                    case "PropTxtWidth": // Ancho
                        lcrValorReturn = fcrValidacionNumerica(PropTxtWidth, 1, 2000, "Ancho Objeto");
                        SetValidPropDistribucion(2, lcrValorReturn);
                        break;

                    case "PropTxtLeft": // Ajueste a la Izquierda
                        lcrValorReturn = fcrValidacionNumerica(PropTxtLeft, -100, 2000, "Ajueste a la Izquierda");
                        SetValidPropDistribucion(3, lcrValorReturn);
                        break;

                    case "PropTxtTop": // Ajueste arriba
                        lcrValorReturn = fcrValidacionNumerica(PropTxtTop, -100, 2000, "Ajueste arriba");
                        SetValidPropDistribucion(4, lcrValorReturn);
                        break;

                    case "PropItemTxtCodigo": // Codigo Item para objeto ComboBox
                        lcrValorReturn = fcrValidacionTexto("AM", PropItemTxtCodigo, "Codigo opción lista");
                        break;

                    case "PropItemTxtDescripcion": // Descripcion Item para objeto ComboBox
                        lcrValorReturn = fcrValidacionTexto("AX", PropItemTxtDescripcion, "Descripcion opción lista");
                        break;

                    case "PropSeccionTxtDescripcion": // Descripcion Seccion
                        lcrValorReturn = fcrValidacionTexto("AX", PropSeccionTxtDescripcion, "Descripcion sección");
                        break;

                    case "PropSeccionIntOrdenVista": // Orden vista Seccion 
                        lcrValorReturn = fcrValidacionNumerica(PropSeccionIntOrdenVista.ToString(), 1, 999, "Orden visaulizacion sección");
                        break;

                    case "PropSeccionIntColumnas": // Total columnas de la seccion
                        lcrValorReturn = fcrValidacionNumerica(PropSeccionIntColumnas.ToString(), 1, 10, "Total columnas de la seccion");
                        break;

                    case "PropGalTxtTitulo": // Descripcion Item para imagen predefinida
                        lcrValorReturn = fcrValidacionTexto("AX", PropGalTxtTitulo, "Titulo imagen");
                        break;

                    case "PropGalTxtHeight": // Alto
                        lcrValorReturn = fcrValidacionNumerica(PropGalTxtHeight, 20, 2000, "Alto Imagen");
                        break;

                    case "PropGalTxtWidth": // Ancho
                        lcrValorReturn = fcrValidacionNumerica(PropGalTxtWidth, 20, 2000, "Ancho imagen");
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
        /// <para>"AM"= Una sola expresion Alfanumerico con texto en mayuscula y numeros</para>
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
                    if (!Funciones.flgExisteSubCadenaStringEx(tcrValor, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ0123456789-.*() "))
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
                    if (Funciones.flgSoloNumeros(tcrValor) == false)
                    {
                        lcrValorReturn = tcrTitulo + ": Solo acepta valores numericos";
                    }
                    else if (Funciones.flgSoloNumeros(tcrValor, tnuRangoIni, tnuRangoFin) == false)
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
        // Datos y Gestion de Combos Para propiedades
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
                // PropCboTipoControl: Control para captura MEDI=Medicamentos SERV= Servicios...
                //-------------------------------------------------
                #region PropCboTipoControl: Control captura
                //string lcrG30Seleccion = "MEDI,SERV,EVOL,NENF,SVIT,INCO,DIAG,ALIQ,ELIQ";
                string lcrG30Seleccion = "MEDI,SERV,EVOL,NENF,SVIT,INCO,DIAG,BLIQ,HCON,ODAP,FMED";
                string lcrG30Descripcion = "Suministro Medicamentos,Ordenes de servicios,Evoluciones médicas,Notas de enfermeria," +
                                           "Signos vitales,Inter consulta,Diagnosticos,Balance de liquidos,Hoja consumo servicios," +
                                           "Tratamiento odontológico,Formula médica";
                PropCboTipoControl = new List<ListaXmlValores>();
                PropCboTipoControl = flsCargarLista(lcrG30Seleccion, lcrG30Descripcion);
                #endregion
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
                // PropCboIsRequerido: El valor del campo es requerido
                //-------------------------------------------------
                #region PropCboIsRequerido: El valor del campo es requerido (SI/NO)
                string lcrG26Seleccion = "False,True";
                string lcrG26Descripcion = "Valor del campo no es requerido,Es requerido el valor del campo";
                PropCboIsRequerido = new List<ListaXmlValores>();
                PropCboIsRequerido = flsCargarLista(lcrG26Seleccion, lcrG26Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboTablaOrigen: Tablas para campos relacionados TDIA,USUA,USUX,TIDE,TDIS,TMED ...
                //-------------------------------------------------
                #region PropCboTablaOrigen: Lista de Tablas Origen para campos relacionados: TDIA,USUA,USUX,TIDE,TDIS,TMED ...
                string lcrG22Seleccion   = "TDIA,USUA,USUX,TIDE,TDIS,TMED,TAFI,TCOT,"+
                                           "TPOB,NSBN,TPAT,PROF,ESME,"+
                                           "ASER,TEPS,TRIP,FCON,TDIX,OCUP,MANT";
                string lcrG22Descripcion = "Diagnosticos,Maestro usuarios atendidos,Usuarios del sistema,Tipo identificación,Tipo Discapacidad,Medida Edad,Tipo afiliación,Tipo cotizante,"+
                                           "Tipo población,Nivel Sisben,Tipo profesional que atiende,Nombre profesionales medicos,Especialidades medicas,"+
                                           "Areas prestacion servicios,Lista EPS aseguradoras,Clasificación RIPS,Finalidad consulta (RIPS AC),Tipo Diagnostico Principal (RIPS AP),"+
                                           "Ocupación laboral,Manual Tarifario de Servicios";
                PropCboTablaOrigen = new List<ListaXmlValores>();
                PropCboTablaOrigen = flsCargarLista(lcrG22Seleccion, lcrG22Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboSiMostrarEnMuro: Mostrar/Ocultar objeto o variable en muro historial.
                //-------------------------------------------------
                #region PropCboSiMostrarEnMuro: Lista True/False para saber si el objeto o variable se muestra en muro.
                string lcrG23Seleccion = "False,True";
                string lcrG23Descripcion = "No mostrar imagen en historial,Mostrar imagen en historial";
                PropCboSiMostrarEnMuro = new List<ListaXmlValores>();
                PropCboSiMostrarEnMuro = flsCargarLista(lcrG23Seleccion, lcrG23Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboSiFiltroBusqueda:  True/False agregar dato del objeto o variable en busqueda historial.
                //-------------------------------------------------
                #region PropCboSiFiltroBusqueda: True/False agregar dato del objeto o variable en busqueda historial.
                string lcrG24Seleccion = "False,True";
                string lcrG24Descripcion = "No agregar a busqueda historial,Agregar en busqueda historial";
                PropCboSiFiltroBusqueda = new List<ListaXmlValores>();
                PropCboSiFiltroBusqueda = flsCargarLista(lcrG24Seleccion, lcrG24Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboTamAdornos: Lista tamaño adornos objetos
                //-------------------------------------------------
                #region PropCboFontSize: Lista tamaño de la fuente (texto)
                string lcrG25Seleccion = "15,20,25,30,35,40,45";
                string lcrG25Descripcion = "15,20,25,30,35,40,45";
                PropCboTamAdornos = new List<ListaXmlValores>();
                PropCboTamAdornos = flsCargarLista(lcrG25Seleccion, lcrG25Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboRefVarDatosTipo: Lista de Archivos RIPS o 4505 para aplicar valores.
                //-------------------------------------------------
                #region PropCboDatosTipo: Lista de Archivos RIPS o 4505 para aplicar valores.
                /*
                string lcrG26Seleccion = "NA,45,AC,AP,AN,AH,AM,AT,AU,US";
                string lcrG26Descripcion = "No Aplica,Registros Resolución 4505,RIPS Archivo Consulta,RIPS Archivo Procedimientos,"+
                                           "RIPS Archivo Recien nacido,RIPS Archivo Hospitalización,RIPS Archivo Medicamentos,"+
                                           "RIPS Archivo Otros Servicios,RIPS Archivo Urgencias,RIPS Archivo Usuarios atendidos";
                */
                //PropCboRefVarDatosTipo = flsCargarLista(lcrG26Seleccion, lcrG26Descripcion);

                PropCboRefVarDatosTipo = new List<ListaXmlValores>();
                PropCboRefVarDatosTipo.Add(new ListaXmlValores() { Indice = "1",
                                                                   Codigo = "NA",
                                                                   Descripcion = "No Aplica"});

                var tmp = SISValidarCodigo.fobRegBuscarSisactualizarchLista("1");
                var i = 2;
                foreach (var lcrReg in tmp)
                {
                    PropCboRefVarDatosTipo.Add(new ListaXmlValores() { Indice = i.ToString().Trim(), 
                                                                       Codigo = lcrReg.sis_codarc_siaa,
                                                                       Descripcion = lcrReg.sis_desarc_siaa});
                    i++;
                }
                #endregion
                //-------------------------------------------------
                // PropCboAlineacionTexto: Alineación del texto (para Textbox y TextBlock).
                //-------------------------------------------------
                #region PropCboAlineacionTexto: Alineacion texto: Left=Izquieda Right=Derecha Center=Centrado Justify=Justificado
                string lcrG27Seleccion = "Left,Right,Center,Justify";
                string lcrG27Descripcion = "Ajustado a la izquieda,Ajustado a la derecha,Centrado,Justificado";
                PropCboAlineacionTexto = new List<ListaXmlValores>();
                PropCboAlineacionTexto = flsCargarLista(lcrG27Seleccion, lcrG27Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboFechaDefault: Valor por defecto campo fecha: 1=Valor Vacio 2=Fecha actual del sistema
                //-------------------------------------------------
                #region PropCboFechaDefault: Valor por defecto campo fecha: 1=Valor Vacio 2=Fecha actual del sistema
                string lcrG28Seleccion = "1,2";
                string lcrG28Descripcion = "Fecha vacia,Fecha actual del sistema";
                PropCboFechaDefault = new List<ListaXmlValores>();
                PropCboFechaDefault = flsCargarLista(lcrG28Seleccion, lcrG28Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboHoraDefault: Valor por defecto campo hora: 1=Hora vacia 2=Hora Actual del sistema.
                //-------------------------------------------------
                #region PropCboHoraDefault: Valor por defecto campo hora: 1=Hora vacia 2=Hora Actual del sistema.
                string lcrG29Seleccion = "1,2";
                string lcrG29Descripcion = "Hora vacia,Hora actual del sistema";
                PropCboHoraDefault = new List<ListaXmlValores>();
                PropCboHoraDefault = flsCargarLista(lcrG29Seleccion, lcrG29Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboSiMultiSet: Los datos en el objeto pueden ser editados despues de confirmar el formato de hc.
                //-------------------------------------------------
                #region PropCboSiMultiSet: Los datos en el objeto pueden ser editados despues de confirmar el formato de hc.
                string lcrG33Seleccion = "False,True";
                string lcrG33Descripcion = "Se inactiva al confirmar los datos en el formulario,Modificable en varias sesiones";
                PropCboSiMultiSet = new List<ListaXmlValores>();
                PropCboSiMultiSet = flsCargarLista(lcrG33Seleccion, lcrG33Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboSiImprimir: Indica si el objeto es imprimible True/False (por defecto True)
                //-------------------------------------------------
                #region PropCboSiImprimir: Indica si el objeto es imprimible True/False (por defecto True)
                string lcrG34Seleccion = "True,False";
                string lcrG34Descripcion = "Objeto Imprimible,No enviar a impresora";
                PropCboSiImprimir = new List<ListaXmlValores>();
                PropCboSiImprimir = flsCargarLista(lcrG34Seleccion, lcrG34Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboIsReadOnly: El dato es solo lectura, activa o inactiva actualziar variable publica actualizable
                //-------------------------------------------------
                #region PropCboIsReadOnly: El dato es solo lectura, activa o inactiva actualziar variable publica actualizable
                string lcrG35Seleccion = "False,True";
                string lcrG35Descripcion = "Datos modificables,Datos son de solo lectura";
                PropCboIsReadOnly = new List<ListaXmlValores>();
                PropCboIsReadOnly = flsCargarLista(lcrG35Seleccion, lcrG35Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboPrnSiValidar: Lista para indicar si se envian a impresion los valores digitados como valor defecto
                //-------------------------------------------------
                #region PropCboPrnSiValidar: Lista para validar si se envian a impresion los valores digitados
                string lcrG37Seleccion = "1,2,3,4";
                string lcrG37Descripcion = "Todos los valores se imprimen,Se imprimen solo valores de lista,Valores de lista no se imprimen,"+
                                           "No enviar valores a impresión";
                PropCboPrnSiValidar = new List<ListaXmlValores>();
                PropCboPrnSiValidar = flsCargarLista(lcrG37Seleccion, lcrG37Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboPrnMostrarTitulo: indicar si se muestra el titulo del dato al enviar a impresión
                //-------------------------------------------------
                #region PropCboPrnMostrarTitulo: indicar si se muestra el titulo del dato al enviar a impresión
                string lcrG38Seleccion = "1,2";
                string lcrG38Descripcion = "Ver el titulo en impresión,No mostrar titulo en impresión";
                PropCboPrnMostrarTitulo = new List<ListaXmlValores>();
                PropCboPrnMostrarTitulo = flsCargarLista(lcrG38Seleccion, lcrG38Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboPlantTipoImpresion: Tipo formato impresion permitido para la plantilla Vista Diseño/Tipo informe
                //-------------------------------------------------
                #region PropCboPlantTipoImpresion: Tipo formato impresion permitido para la plantilla: Vista Diseño/Tipo informe
                string lcrG39Seleccion = "1,2,3";
                string lcrG39Descripcion = "Imprimir Vista diseño y tipo informe,Imprimir solo Vista diseño,Imprimir solo tipo informe";
                PropCboPlantTipoImpresion = new List<ListaXmlValores>();
                PropCboPlantTipoImpresion = flsCargarLista(lcrG39Seleccion, lcrG39Descripcion);
                #endregion
                //-------------------------------------------------
                // PropCboPlantTipoHojaReporte: Configuracion del tamaño del papel para impresion en formato "Tipo informe"
                //-------------------------------------------------
                #region PropCboPlantTipoHojaReporte: Configuracion del tamaño del papel para impresion en formato "Tipo informe"
                string lcrG40Seleccion = "01,02";
                string lcrG40Descripcion = "Hoja tamaño carta (Maximo 5 columnas por sección),Hoja tamaño oficio (Maximo 5 columnas por sección)";
                PropCboPlantTipoHojaReporte = new List<ListaXmlValores>();
                PropCboPlantTipoHojaReporte = flsCargarLista(lcrG40Seleccion, lcrG40Descripcion);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        #region flsCargarLista: Cargar la clase del ComboBox Listas Desplegables
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
        #region flsCargarListaFonts: Cargar lista tipo de fuentes del sistema
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
        #region fnuMostrarItemCombo: Buscar Valores en Lista devolver el Index  para combobox
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
        #region fnuMostrarEtiquetas: Buscar Valores en Lista devolver el Index  para etiquetas
        /// <summary>
        /// Mostrar la opcion del combobox segun opcion escrita en textbox
        /// <param name="tcrValor">Valor a seleccionar</param>
        /// <param name="tlsLista">Lista de Valores</param>
        /// <returns>Retorna un valor de tipo entero para SelectedIndex del Combobox</returns>
        /// </summary>
        public static int fnuMostrarEtiquetas(String tcrValor, List<XmlEntorno.ClassXmlItemEtiquetas> tlsLista)
        {
            int lnuValor = 0;
            var lcrQuery = from lst in tlsLista
                           where lst.Codigo.Equals(tcrValor)
                           select new ListaXmlValores
                           {
                               Indice = lst.Indice,
                               Codigo = lst.Codigo,
                               Descripcion = lst.Descripcion
                           };

            if (lcrQuery != null) { lnuValor = Convert.ToInt32(lcrQuery.FirstOrDefault().Indice) - 1; }
            return lnuValor;
        }
        #endregion
        #region fcvSetObjGenListaPilaVariablesPublicas: Generar lista de valores para la Pila
        /// <summary>
        /// <para>Generar lista de valores para la Pila en variable publica tipo vector</para>
        /// </summary>
        public void fcvSetObjGenListaPilaVariablesPublicas(Datos.Modelos.EFhclvariabmaestr tobRegVariable)
        {
            string lcrSeleccion = "N";
            string lcrDescripcion = "No aplica";
            
            if (tobRegVariable.hcl_varray_hcvr == "1") // Es tipo Array
            {
                lcrSeleccion = "0";
                lcrDescripcion = "Campo de Captura";
                for (int i = 1; i <= tobRegVariable.hcl_tmaray_hcvr; i++)
                {
                    lcrSeleccion += "," + i.ToString().Trim();
                    lcrDescripcion += ",Valor dato " + i.ToString().Trim();
                }
            }
            PropCboVarGestPosVector = new List<ListaXmlValores>();
            PropCboVarGestPosVector = flsCargarLista(lcrSeleccion, lcrDescripcion);
        }
        #endregion
        #region fcvSetObjGenListaPilaVariablesPublicas: Generar lista valores por defecto cuando no es Pila 
        /// <summary>
        /// <para>Generar lista valores por defecto cuando no es Pila</para>
        /// </summary>
        public void fcvSetObjGenListaPilaVariablesPublicas()
        {
            string lcrSeleccion = "N";
            string lcrDescripcion = "No aplica";

            PropCboVarGestPosVector = new List<ListaXmlValores>();
            PropCboVarGestPosVector = flsCargarLista(lcrSeleccion, lcrDescripcion);
        }
        #endregion
        //-------------------------------------------------
        //- ListaXmlValores
        //-------------------------------------------------
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
        //-------------------------------------------------
        //- Valores Barra de progesro
        //-------------------------------------------------
        #region fcvProgressBarIniciar: Inicia los valores para la barra de progresos
        /// <summary>
        /// <para>Inicia los valores para la barra de progreso</para>
        /// </summary>
        public void fcvProgressBarIniciar(int tnuValorMainimo, int tnuValorMaximo)
        {
            gnuPropValorMinimoProgressBar = tnuValorMainimo;
            gnuPropValorMaximoProgressBar = tnuValorMaximo;
        }
        #endregion
        #region fcvProgressBarAvance: Mostrar el avance barra de progresos
        /// <summary>
        /// <para>Mostrar el avance barra de progreso</para>
        /// </summary>
        public void fcvProgressBarAvance(int tnuValorAvance)
        {
            if (tnuValorAvance>0 && tnuValorAvance<=gnuPropValorMaximoProgressBar)
            {
                gnuPropValorProgressBar = (tnuValorAvance * 100) / gnuPropValorMaximoProgressBar;
            }
            else if (tnuValorAvance > gnuPropValorMaximoProgressBar)
            {
                gnuPropValorProgressBar = 100;
            }
            else
            {
                gnuPropValorProgressBar = 1;
            }
            gnuPropValorProgressBar = gnuPropValorProgressBar < 1 ? 1 : gnuPropValorProgressBar;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Converters;
using Microsoft.Win32;
using System.Xml;
using System.Windows.Markup;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Windows.Xps.Packaging;
using Sistema.Utilidades;
using Sistema.Vista;
using Sistema.Clases;
using GestorReportes.VistaModelo;
using GestorReportes.Modelo;
using GestorReportes.Utilidades;
using GestorReportes.Vista;
using Reportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Editor Reportes
    /// </summary>
    public partial class VistaEditorReportes : Window, SIS_Interface
    {
        AdornerLayer luxUIAgregarAdorno;

        // variables control zoom vista
        private Double gduBaseZoomVertical = 0;
        private Double gduBaseZoomHorizontal = 0;
        private Double gduBaseZoomSlider = 0;
        // Variables para control de Objetos
        #region Variables para control de Objetos
        bool glgModoArrastrarObjeto = false;
        bool glgAccionArrastrandoObjeto;
        bool glgSiObjetoSeleccionado = false;
        bool glgObjetosCargados =false;
        bool glgModoSetPropiedades = false;
        //- Mostrar Ventana propiedades
        bool glgVistaPropVisible = false;
        bool glgVistaPropAnclada = false;
        //- Mostrar barra de estado
        bool glgVistaBarraEstadoVisible = false;
        //- Orientacion Vista Navegacion y paginas
        bool glgVistaNavEscritorioVertical  = true;
        #endregion
        //Variables referencia Tree Objetos
        #region Variables referencia Tree Objetos
        public UIElement    guiRefObjetoSeleccionado = null;
        public GroupBox     gobRefGrupoSeleccionado = null;
        public Canvas       gobRefContenedorGrupoSeleccionado = null;
        public GroupBox     gobRefZonaSeleccionada = null;
        public Canvas       gobRefContenedorZonaSeleccionada = null;
        public Canvas       gobRefPaginaSeleccionada = null;
        public WrapPanel    gobRefContenedorPaginaSeleccionada = null;
        public Canvas       gobPaginaSelectParaAddZona = null;
        public GroupBox     gobZonaSelectParaAddObjeto = null;
        public int gnuContadorAddZonas = 1;
        public String gcrTipoObjetoNivel = "NA";
        public String gcrObjetoClassBase = "NA";
        #endregion
        // Variables referencia Posicion Mouse y otras
        #region Variables referencia Posicion Mouse y otras
        Point gptPuntoDeInicio;
        private double gduObjetoInicialLeft;
        private double gduObjetoInicialTop;
        // Posicion del canvas donde se hace 
        // clic para colocar el nuevo objeto
        public double gduCanvasClicPosX = 1;
        public double gduCanvasClicPosY = 1;
        public String gcrAddNuevoObjetoTipo = String.Empty; //TEXTBOX,LISTBOX,TEXTBLOCK,RADIOBUTTON ...
        public bool glgNuevoObjetoCrear = false; // Para indicar el momento de  instanciar el nuevo objeto
        #endregion
        // Variables Generales
        private String gcrCtrF2TexBox = String.Empty;
        //public String gcrAppIpServidor = "192.168.1.30";
        //public String gcrAppInicioPath = @"Proyectos\Galeno40";

        VistaModeloEditor vm = new VistaModeloEditor();
        XmlEntornoEdicion XmlEntorno = new XmlEntornoEdicion();
        Aplicacion oApp = Aplicacion.Instancia();

        public VistaEditorReportes()
        {
            InitializeComponent();
            #region Configuracion
            //- Establecer Directorio actual 
            //Directory.SetCurrentDirectory("..\\..\\..\\");

            // Binding con el Vista Modelo
            vm.gobjRefForm = this;
            this.DataContext = vm;
            this.stkPropBasicas.Visibility = Visibility.Hidden;

            XmlEntorno.gobRefPlantillaEtiqueta   = this.plaEtiqueta;
            XmlEntorno.gobRefPlantillaEscritorio = this.wraPlantilla;
            XmlEntorno.gobRefVM = vm;

            fcvResizePantalla();

            glgObjetosCargados = true;
            EventManager.RegisterClassHandler(typeof(Window), UIElement.KeyDownEvent, new KeyEventHandler(fcvEventoManejadorKeyDown));
            fcvNavEscritorioTouch();
            fcvCmdOrientacionNavEscritorio();
            //Process.Start("osk.exe");
            #endregion 

        }
        #region fcvResizePantalla: Tamaños de pantalla y objetos
        public void fcvResizePantalla()
        {
            double lduBarraWidth    = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 100;
            double lduWidth         = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 10;
            double lduHeight        = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 96.8;
            this.ExtrasGrid.Height  = lduHeight;
            this.cvaBarraEstado.Width = lduBarraWidth;
            this.grdBarraEstado.Width = lduBarraWidth;
            gduBaseZoomVertical = this.stkContenedor.ActualHeight;
            fcvGetValorBaseZoomScroll("SET");
            gduBaseZoomSlider = this.objSliderZoom.Value;

        }
        #endregion
        //------------------------------------------------------------
        // Cerrar o Minimizar la aplicacion
        //------------------------------------------------------------
        #region Cerrar o Minimizar la aplicacion
        private void MinimizeButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            oApp.glgWiniAplicacionDesactivar = true;
            //this.WindowState = System.Windows.WindowState.Minimized;
        }
        private void MinimizeButton_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;

            oApp.glgWiniAplicacionDesactivar = true;
            //this.WindowState = System.Windows.WindowState.Minimized;
        }
        private void CloseButton_Click(Object sender, System.Windows.RoutedEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            fcvCerrarVista();
        }
        private void CloseButton_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvCerrarVista();
        }
        private void fcvCerrarVista()
        {
            this.Close();
        }
        #endregion
        //------------------------------------------------------------ 
        //- MENU DESPLEGABLE OPCIONES - ACCIONES BARRA DE OPCIONES SUPERIOR
        //------------------------------------------------------------ 
        #region fcvMostrarMenuContextual: Mostrar menu contextual
        private void fcvMostrarMenuContextual(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }
        #endregion
        #region Menu Gestion plantilla
        #region fcvCmdCerrarVista: Cerrar la plantilla abierta
        /// <summary>
        ///  fcvCmdCerrarVista: cerrar la plantilla abierta
        /// </summary>
        private void fcvCmdCerrarVista(object sender, RoutedEventArgs e)
        {
            wraPlantilla.Children.Clear();
            XmlEntorno.fcvGestionReiniciarValriables();
            fcvGestionReinicarVariables();
            vm.GlgSIS_ModoEdicion = false;
            this.cmdEdtNuevaPagina.Visibility = Visibility.Collapsed;

        }
        #endregion
        #region fcvPlantillaImportar: Importar Plantilla
        private void fcvPlantillaImportar(object sender, RoutedEventArgs e)
        {
            if (XmlEntorno.flgDialogoBuscarPlantilla())
            {
                fcvActivarBarraEstado(true);
                this.wraPlantilla.Children.Clear();
                fcvGestionReinicarVariables();
                if (XmlEntorno.flgMostrarVistaPlantilla())
                {
                    this.objReglaHorizontal.Width = XmlEntorno.gduMinimoAnchoPlantilla + 120;
                    fcvAdicionarManejadorPaginasyZonas("OBJETOS");
                    fcvActivarBarraEstado(false);
                    vm.GlgSIS_ModoEdicion = true;
                    vm.tmpEtiquetaItems = XmlEntorno.fobRegSelectItemsEtiquetas("");
                    vm.tmpSecciones = XmlEntorno.fobRegSelectItemsSecciones("");
                    fcvSetSeccionesDefault();
                    vm.tmpImgPredefItems = XmlEntorno.tmpImagenesPredef;
                    this.cmdEdtNuevaPagina.Visibility = Visibility.Visible;
                    actualizar();
                }
                else
                {
                    MessageBox.Show("No fue posible cargar los datos.");
                }
            }
        }
        #endregion
        #region fcvPlantillaExportar: Exportar Plantilla
        private void fcvPlantillaExportar(object sender, RoutedEventArgs e)
        {
            if (XmlEntorno.flgDialogoExportarPlantilla())
            {
                XmlEntorno.fcvExportarPlantilla();
            }
        }
        #endregion
        //------------------------------------------------------------ 
        //- BARRA GUARDAR REGISTRO EN BASE DE DATOS
        //------------------------------------------------------------ 
        #region fcvPlantillaNueva: Crear nueva plantilla
        /// <summary>
        /// <para>Crear nueva plantilla</para>
        /// </summary>
        private void fcvPlantillaNueva(object sender, RoutedEventArgs e)
        {
            // por ahora solo para plantillas de historia clinica
            Browser01 frbro = new Browser01("GRP", "GRPFORMATOPLANT", "Grpformatoplant.grp_idegru_grpg ='GF001'", "Crear nueva plantilla...");
            gcrCtrF2TexBox = "NUEVA";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region fcvPlantillaAbrir: fcvPlantillaAbrir: Abrir Plantilla existente
        /// <summary>
        /// <para>Abrir Plantilla existente</para>
        /// </summary>
        private void fcvPlantillaAbrir(object sender, RoutedEventArgs e)
        {
            var frbro = new Browser01Ex("GRP", "GRPMAEVERSPLANT", "", "Buscar plantillas existentes...");
            gcrCtrF2TexBox = "ABRIR";
            frbro.Owner = this;
            frbro.ShowDialog();
            /*
            Browser01 frbro = new Browser01("GRP", "GRPMAEPLANTILLA", "", "Buscar plantillas existentes...");
            gcrCtrF2TexBox = "ABRIR";
            frbro.Owner = this;
            frbro.ShowDialog();
            */
        }
        #endregion
        #region fcvPlantillaGuardar: Guardar Plantilla
        private void fcvPlantillaGuardar(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtPlantNombre.Text))
            {
                fcvActivarPropDatosPlantilla();
                MessageBox.Show("Debe escribir un nombre para la plantilla");
                return;
            }
            if (String.IsNullOrWhiteSpace(this.txtPropPlantTituloReporte.Text))
            {
                fcvActivarPropDatosPlantilla();
                MessageBox.Show("Debe escribir un titulo para la vista del reporte impreso de plantilla");
                return;
            }
            var lobDlgCon = new DialogProgressBarEx();
            lobDlgCon.fcvProgressBarIniciar("Guardando datos...", "CENTRO");
            lobDlgCon.Show();

            // Completar parametros de impresion
            XmlEntorno.tmpPlantilla.FirstOrDefault().PlantTipoImpresion     = this.txtPlantTipoImpresion.Text;
            XmlEntorno.tmpPlantilla.FirstOrDefault().PlantTituloReporte     = this.txtPropPlantTituloReporte.Text;
            XmlEntorno.tmpPlantilla.FirstOrDefault().PlantTipoHojaReporte   = this.txtPlantTipoHojaReporte.Text;

            // Datos adicionales
            XmlEntorno.glgPlaniillaOptimizarTabsGenChar = true; // Trie = Si Optimizar los XML (por defecto)
            XmlEntorno.glgPlaniillaOptimizarTabsXml     = false; // indica que el ultimo XML generado no esta optimizado
            vm.G1Grp_conobj_grpl = XmlEntorno.gnuPlantillaGenerSecObjeto;

            if (vm.GlgSIS_ModoAdicion != true)
            {
                var lcrTextoXml = XmlEntorno.fcrGenerarTextoXmlPlantilla();

                // Revisar si el formato se puede guardar o toca optimizar
                if (XmlEntorno.glgPlaniillaOptimizarTabsGenChar == true && XmlEntorno.glgPlaniillaOptimizarTabsXml == false)
                {
                    if (lcrTextoXml.Length > 900000)
                    {
                        XmlEntorno.glgPlaniillaOptimizarTabsXml = true;
                        lcrTextoXml = XmlEntorno.fcrGenerarTextoXmlPlantilla();
                    }
                }

                var lobRegAux   = XmlEntorno.fcrStringXmlDividirTextoPlantilla(lcrTextoXml);

                // Actualizar en campos
                vm.G2Grp_xmlpla_grpv = lobRegAux.Grp_xmlpla_grpv;
                vm.G2Grp_xmlplb_grpv = lobRegAux.Grp_xmlplb_grpv;
                vm.G2Grp_xmlplc_grpv = lobRegAux.Grp_xmlplc_grpv;
                vm.G2Grp_xmlpld_grpv = lobRegAux.Grp_xmlpld_grpv;

                vm.Guardar();
            }
            else 
            {
                vm.Guardar();
                // Actualizar datos en tempral plantilla
                XmlEntorno.tmpPlantilla.FirstOrDefault().Codigo              = this.txtPlantCodigo.Text;
                XmlEntorno.tmpPlantilla.FirstOrDefault().VersionSistema      = vm.G2Grp_verpla_grpv;
                XmlEntorno.tmpPlantilla.FirstOrDefault().VersionPlantilla    = vm.G2Grp_idepla_grpv;
                XmlEntorno.tmpPlantilla.FirstOrDefault().ImagenIcono         = vm.G1Grc_iderec_grcm;

                // Generar XML 
                var lcrTextoXml = XmlEntorno.fcrGenerarTextoXmlPlantilla();
                var lobRegAux   = XmlEntorno.fcrStringXmlDividirTextoPlantilla(lcrTextoXml);

                // Actualizar en campos
                vm.G2Grp_xmlpla_grpv = lobRegAux.Grp_xmlpla_grpv;
                vm.G2Grp_xmlplb_grpv = lobRegAux.Grp_xmlplb_grpv;
                vm.G2Grp_xmlplc_grpv = lobRegAux.Grp_xmlplc_grpv;
                vm.G2Grp_xmlpld_grpv = lobRegAux.Grp_xmlpld_grpv;

                vm.Guardar();

                XmlEntorno.gcrModoEdicionPlantilla = "EDT";

            }
            // Guardar referencias secciones y campos en tablas
            XmlEntorno.flgGuardarRefSeccionesPlantilla();
            XmlEntorno.flgGuardarRefCamposSeccionesPlantilla(vm.G2Grp_idepla_grpv);
            XmlEntorno.flgGuardarRefCamposResolucion4505(vm.G2Grp_idepla_grpv);

            lobDlgCon.Close();

            MessageBox.Show("Datos Guardados");
        }
        #endregion
        #region fcvPlantillaImprimir: Vista preliminar modelo imprimir 
        private void fcvPlantillaImprimir(object sender, RoutedEventArgs e)
        {
            if (XmlEntorno.tmpPlantilla != null)
            {
                if (!String.IsNullOrWhiteSpace(this.txtPlantNombre.Text))
                {
                    if (XmlEntorno.flgPrnReporteImpresoraDetalles())
                    {
                        XmlEntorno.flgPrnReporteImpresoraMaestro();

                        var lobRegVista = new HCLImprimirFormatoHc();

                        //lobRegVista.gobArrayImgDiag = luxflujo1.ToArray();
                        //lobRegVista.gobArrayImgPlan = luxflujo2.ToArray();

                        lobRegVista.lobRegMa          = XmlEntorno.lobPrnRegMa;
                        lobRegVista.tmpDetalles       = XmlEntorno.tmpPrnDetalles;
                        lobRegVista.gcrCodigoAdmision = "PRUEBA";
                        lobRegVista.gcrCodigoRegistro = "R00000"; // Registro de prueba
                        lobRegVista.gcrTipoFormato    = XmlEntorno.gcrPlantillaTipoHojaReporte;   // Tipo formato ejemplo: hoja tamaño carta
                        lobRegVista.glgVistaPrevia    = true;     // true = mostrar vista previa / fase = no mostrar vista previa
                        lobRegVista.gobOwner = this;
                        lobRegVista.fcvEjecutar();

                    }
                    return;
                }
            }
        }
        #endregion
        #region fcvCmdTecladoVirtual: Mostrar teclado en pantalla
        private void fcvCmdTecladoVirtual(object sender, RoutedEventArgs e)
        {
            Process.Start("osk.exe");
        }
        #endregion
        #region fcvCmdNavEscritorioVertical: Estilo navegacion escritorio Vertical
        private void fcvCmdNavEscritorioVertical(object sender, RoutedEventArgs e)
        {
            if (glgVistaNavEscritorioVertical == false)
            {
                glgVistaNavEscritorioVertical = true;
                fcvCmdOrientacionNavEscritorio();
            }
        }
        #endregion
        #region fcvCmdNavEscritorioHorizontal: Estilo navegacion escritorio Horizontal
        private void fcvCmdNavEscritorioHorizontal(object sender, RoutedEventArgs e)
        {
            if (glgVistaNavEscritorioVertical == true)
            {
                glgVistaNavEscritorioVertical = false;
                fcvCmdOrientacionNavEscritorio();
            }
        }
        #endregion
        #region fcvCmdOrientacionNavEscritorio: Orientacion navegacion en escritorio
        private void fcvCmdOrientacionNavEscritorio()
        {
            this.objSliderMargenHorizontal.Value = 0;
            if (glgVistaNavEscritorioVertical == true)
            {
                wraPlantilla.Orientation = Orientation.Vertical;
                this.objSliderMargenHorizontal.Minimum = -585;
                fcvNavEscritorioTouch();
            }
            else
            {
                this.objSliderMargenHorizontal.Minimum = 0;
                wraPlantilla.Orientation = Orientation.Horizontal;
                fcvNavEscritorioTouch();
            }
        }
        #endregion
        #region fcvNavEscritorioTouch: Estilo navegacion tactil
        /// <summary>
        /// <para>Activa el Scroll de navegacion en el escritorio.</para>
        /// </summary>
        private void fcvNavEscritorioTouch()
        {
            this.stkBase.HorizontalAlignment = HorizontalAlignment.Center;
            this.stkBase.VerticalAlignment = VerticalAlignment.Center;
            if (glgVistaNavEscritorioVertical == true)
            {
                this.PanelScroll.PanningMode = PanningMode.VerticalOnly;
            }
            else
            {
                this.PanelScroll.PanningMode = PanningMode.HorizontalOnly;
            }
        }
        #endregion
        #region fcvAdicionarManejadorPaginasyZonas: Adicionar manejadores a paginas y zonas cargadas
        /// <summary>
        /// <para>Adicionar manejadores a paginas y zonas cargadas</para>
        /// <para>desde plantillas existentes o desde Deshacer / Rehacer </para>
        /// </summary>
        public void fcvAdicionarManejadorPaginasyZonas(String tcrArchivoOrigen)
        {
            List<ClassXmlPropObjeto> tobTemp = XmlEntorno.fobRegSelectReferenciaArchivo(tcrArchivoOrigen);

            foreach (var lobItem in tobTemp)
            {
                if (lobItem.TipoObjeto == "PAGINA")
                {
                    Canvas lobPag = lobItem.RefObjeto as Canvas;
                    lobPag.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                }
                if (lobItem.TipoObjeto == "ZONA")
                {
                    GroupBox lobZona = lobItem.RefObjeto as GroupBox;
                    lobZona.MouseLeftButtonDown += new MouseButtonEventHandler(fcvQuitarAdornoObjetoMouseLeftButtonDown);
                    lobZona.MouseLeftButtonUp += new MouseButtonEventHandler(fcvFinalizaDragMouseManejador);
                    lobZona.MouseMove += new MouseEventHandler(fcvEventoMoverMouseEnZona);
                    lobZona.MouseLeave += new MouseEventHandler(fcvEventoMoverMouseFueraDeZona);
                    lobZona.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                    lobZona.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(fcvFinalizaDragMouseManejador);
                }
                if (lobItem.TipoObjeto != "PAGINA")
                {
                    fcvMajenadorSizeChanged(lobItem.RefObjeto, lobItem.ClaseBase);
                }
            }
        }
        #region fcvMajenadorSizeChanged: Asignar el manejador SizeChangedEventHandler a los objetos 
        /// <summary>
        /// <para>Asignar el manejador SizeChangedEventHandler a los objetos, para que puedan reportar el</para>
        /// <para>cambio de tamaño a las propiedades correspondientes, cuando son ajustados con mouse</para>
        /// </summary>
        public void fcvMajenadorSizeChanged(FrameworkElement tobRefObjeto, String tcrTipoObjeto)
        {
            if (tobRefObjeto != null)
            {
                switch (tcrTipoObjeto.ToUpper())
                {
                    case "TEXTBOX":
                        TextBox lobjTextBox = tobRefObjeto as TextBox;
                        lobjTextBox.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "RICHTEXTBOX":
                        TextBox lobjRichTextBox = tobRefObjeto as TextBox;
                        lobjRichTextBox.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "COMBOBOX":
                        ComboBox lobjComboBox = tobRefObjeto as ComboBox;
                        lobjComboBox.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "TEXTBLOCK":
                        TextBlock lobjTextBlock = tobRefObjeto as TextBlock;
                        lobjTextBlock.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "RADIOBUTTON":
                        RadioButton lobjRadioButton = tobRefObjeto as RadioButton;
                        lobjRadioButton.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "CHECKBOX":
                        CheckBox lobjCheckBox = tobRefObjeto as CheckBox;
                        lobjCheckBox.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "USERCONTROL":
                        if (tobRefObjeto != null)
                        {
                            UserControl lobjCrtAdmision = tobRefObjeto as UserControl;
                            lobjCrtAdmision.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        }
                        break;

                    case "CANVAS":
                        Canvas lobjCanvas = tobRefObjeto as Canvas;
                        lobjCanvas.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "BUTTON":
                        Button lobjButton = tobRefObjeto as Button;
                        lobjButton.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "GROUPBOX":
                        GroupBox lobjGroupBox = tobRefObjeto as GroupBox;
                        lobjGroupBox.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "IMAGE":
                        Image lobjImage = tobRefObjeto as Image;
                        lobjImage.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "RECTANGLE":
                        System.Windows.Shapes.Rectangle lobjRectangle = tobRefObjeto as System.Windows.Shapes.Rectangle;
                        lobjRectangle.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "ELLIPSE":
                        System.Windows.Shapes.Ellipse lobjEllipse = tobRefObjeto as System.Windows.Shapes.Ellipse;
                        lobjEllipse.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "POLYLINE":
                        System.Windows.Shapes.Polyline lobjPolyline = tobRefObjeto as System.Windows.Shapes.Polyline;
                        lobjPolyline.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "POLYGON":
                        System.Windows.Shapes.Polygon lobjPolygon = tobRefObjeto as System.Windows.Shapes.Polygon;
                        lobjPolygon.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;

                    case "LINE":
                        System.Windows.Shapes.Line lobjLine = tobRefObjeto as System.Windows.Shapes.Line;
                        lobjLine.SizeChanged += new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                        break;
                }
            }
        }
        #endregion
        #endregion
        #region fcvSliderMargenZoomVista: Ajustar la vista del Zoom
        /// <summary>
        /// <para>Ajustar margenes superio zoom vista navegacion.</para>
        /// </summary>
        private void fcvSliderMargenZoomVista(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //var lobj = (Slider)sender;
            if (glgObjetosCargados == true)
            {
                var lduVertical = this.objSliderMargenVertical.Value;
                var lduHorizontal = this.objSliderMargenHorizontal.Value;
                this.stkBase.Margin = new Thickness(lduHorizontal, lduVertical, 0, 0);
            }
        }
        #endregion
        #region fcvSliderZoomScroll: Ajustar la vista del Zoom para mostrar scroll
        /// <summary>
        /// <para>Ajustar la vista del Zoom para mostrar scroll.</para>
        /// </summary>
        private void fcvSliderZoomScroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //var lobj = (Slider)sender;
            if (glgObjetosCargados == true)
            {
                var lduValor = this.objSliderZoom.Value;
                if (gduBaseZoomVertical == 0)
                { 
                    fcvGetValorBaseZoomScroll("GET");
                }
                if (gduBaseZoomSlider >= this.objSliderZoom.Value)
                {
                    // restablecer valores base
                    this.stkContenedor.Height = gduBaseZoomVertical;
                    this.stkContenedor.Width = gduBaseZoomHorizontal;
                }
                else 
                {
                    this.stkContenedor.Width = (gduBaseZoomHorizontal * lduValor);
                    this.stkContenedor.Height = (gduBaseZoomVertical * lduValor);
                }
            }
        }
        #endregion
        #region fcvGetValorBaseZoomScroll: Toma los valores base de alto y ancho para mostrar barras de scroll e zoom
        /// <summary>
        /// <para>Toma los valores base de alto y ancho para mostrar barras de scroll en Zoom.</para>
        /// <para>SET = Valores en Cero GET = Valores desde Objeto</para>
        /// </summary>
        private void fcvGetValorBaseZoomScroll(String tcrModo)
        {
            gduBaseZoomVertical = this.stkContenedor.ActualHeight;
            gduBaseZoomHorizontal = this.stkContenedor.ActualWidth;
            if (tcrModo == "SET")
            {
                gduBaseZoomVertical = 0;
                gduBaseZoomHorizontal = 0;
            }
        }
        #endregion
        // Interface con ventanas auxiliares
        #region fcvBuscarRegistro: Metodo que recoge el valor Key desde browser F2
        /// <summary>
        /// <para>Recoger el codigo dado en Browser de busqueda con  tecla F2</para>
        /// </summary>
        public void fcvBuscarRegistro(string tcrCodigo)
        {
            switch (gcrCtrF2TexBox)
            {
                case "NUEVA": // Crear nueva plantilla
                    #region  Crear nueva plantilla
                    this.wraPlantilla.Children.Clear();
                    XmlEntorno.fcvGestionReiniciarValriables();
                    fcvGestionReinicarVariables();
                    vm.Adicionar();
                    var lobRegFormato = ModeloFormatos.flsListaFormatoPlantillas(tcrCodigo).FirstOrDefault();
                    vm.G1Grp_despla_grpl = String.Empty;
                    vm.G1Grp_hl7for_grpl = "NA";                             // ---------------- Ojo por ahora cambiar mas adelante 
                    vm.G1Grp_idegru_grpg = lobRegFormato.Grp_idegru_grpg;
                    vm.G1Grp_tipfor_grpl = lobRegFormato.Grp_tipfor_grpl;
                    vm.G1Grc_iderec_grcm = "RG0001";                         // ---------------- Ojo codigo del icono que representa la plantilla
                    vm.G1Grp_prefij_grpl = "EX";                             // ---------------- Ojo prefijo para objetos
                    vm.G2Grp_xmlpla_grpv = lobRegFormato.Grp_xmlpla_grpv;
                    vm.G2Grp_hojalt_grpv = lobRegFormato.Grp_hojalt_grpv;
                    vm.G2Grp_hojanc_grpv = lobRegFormato.Grp_hojanc_grpv;
                    vm.G2Grp_marver_grpv = lobRegFormato.Grp_marver_grpv;
                    vm.G2Grp_marhor_grpv = lobRegFormato.Grp_marhor_grpv;
                    vm.G2Grp_epapel_grpv = lobRegFormato.Grp_epapel_grpv;
                    vm.G2Grp_estilo_grpv = "NA"; // por ahora

                    // generar datos en tmp plantilla
                    XmlEntorno.gcrTipoOrigenArchivo      = "BDATOS";
                    XmlEntorno.gcrModoEdicionPlantilla   = "ADD";
                    XmlEntorno.gcrImportArchivoPlantilla = lobRegFormato.Grp_xmlpla_grpv;
                    XmlEntorno.flgMostrarVistaPlantilla();
                    XmlEntorno.fobRegCargarXMLSeccionDefault();
                    // Valores por defecto
                    XmlEntorno.tmpPlantilla.FirstOrDefault().PlantTipoImpresion = "1";
                    XmlEntorno.tmpPlantilla.FirstOrDefault().PlantTituloReporte = String.Empty;
                    XmlEntorno.tmpPlantilla.FirstOrDefault().PlantTipoHojaReporte = "01";

                    vm.tmpSecciones = XmlEntorno.fobRegSelectItemsSecciones("");
                    fcvSetSeccionesDefault();
                    fcvCmdAddPaginaObjetosEx();
                    fcvActivarValoresPorDefectoPlantilla();
                    // Activar la vista para nombre de la plantilla
                    fcvActivarPropDatosPlantilla();
                    fcvGetValorBaseZoomScroll("SET");
                    break;
                    #endregion

                case "ABRIR": // Abrir plantilla existente
                    #region Abrir plantilla existente
                    if (XmlEntorno.flgBDatosBuscarPlantillaVersion(tcrCodigo))
                    {
                        glgModoSetPropiedades = true;
                        fcvActivarBarraEstado(true);
                        this.wraPlantilla.Children.Clear();
                        fcvGestionReinicarVariables();
                        if (XmlEntorno.flgMostrarVistaPlantilla())
                        {
                            this.objReglaHorizontal.Width = XmlEntorno.gduMinimoAnchoPlantilla + 120;
                            fcvAdicionarManejadorPaginasyZonas("OBJETOS");
                            //fcvAdicionarUserControls("OBJETOS");
                            fcvActivarBarraEstado(false);
                            vm.GlgSIS_ModoEdicion = true;
                            vm.tmpEtiquetaItems = XmlEntorno.fobRegSelectItemsEtiquetas("");
                            vm.tmpSecciones = XmlEntorno.fobRegSelectItemsSecciones("");
                            fcvSetSeccionesDefault();
                            vm.tmpImgPredefItems = XmlEntorno.tmpImagenesPredef;
                            this.cmdEdtNuevaPagina.Visibility = Visibility.Visible;
                            fcvActivarValoresPorDefectoPlantilla();
                            vm.FiltroVersion(tcrCodigo);
                            actualizar();
                            fcvGetValorBaseZoomScroll("SET");
                        }
                        glgModoSetPropiedades = false;
                    }
                    break;
                    #endregion

                case "ETIQUETA": // Adicionar etiquetas
                    #region Adicionar etiquetas
                    var lobPlantilla = ModeloPlantilla.flsListaGrpmaeplantilla(tcrCodigo).FirstOrDefault();
                    vm.PropEtiqTxtCodigo      = lobPlantilla.Grp_idepla_grpl;
                    vm.PropEtiqTxtVersion     = lobPlantilla.Grp_idepla_grpv;
                    vm.PropEtiqTxtIcono       = lobPlantilla.Grc_iderec_grcm;
                    vm.PropEtiqTxtDescripcion = lobPlantilla.Grp_despla_grpl;
                    fcvGetValorBaseZoomScroll("SET");
                    break;
                    #endregion

                case "DatTxtRefVarDatosCampo": // Campos para actualizar 
                    #region  Campos para actualizar
                    fcvSetObjBrowserCamposArchivoValid(tcrCodigo);
                    break;
                    #endregion

                case "PropDatTxtVariablePublica": // Variables publicas
                    #region Variables publicas
                    fcvSetObjBrowserVariablePublicaValid(tcrCodigo);
                    break;
                    #endregion
            }
        }
        #endregion
        #region fcvActivarPropDatosPlantilla: Activar la pestaña propiedades plantilla
        /// <summary>
        /// <para>Activar la pestaña propiedades plantilla</para>
        /// </summary>
        private void fcvActivarPropDatosPlantilla()
        {
            if (glgVistaPropVisible == false)
            {
                fcvActivarVistaPropiedades();
            }
            this.pagPropObjetos.SelectedItem = (TabItem)this.pagPropObjetos.FindName("pagPlantilla");
            this.PropPlantila.IsExpanded = true;
            FocusManager.SetFocusedElement(this, this.txtPlantNombre);
        }
        #endregion
        #region fcvActivarValoresPorDefectoPlantilla: Activar valores por defecto en plantilla
        /// <summary>
        /// <para>Activar valores por defecto al abrir o crear plantilla</para>
        /// </summary>
        private void fcvActivarValoresPorDefectoPlantilla()
        {
            var lcrTipoImpresion = XmlEntorno.tmpPlantilla.FirstOrDefault().PlantTipoImpresion;
            var lcrTituloReporte = XmlEntorno.tmpPlantilla.FirstOrDefault().PlantTituloReporte;
            var lcrColumnasReporte = XmlEntorno.tmpPlantilla.FirstOrDefault().PlantTipoHojaReporte;

            this.txtPlantTipoImpresion.Text     = lcrTipoImpresion;
            this.txtPropPlantTituloReporte.Text = lcrTituloReporte;
            this.txtPlantTipoHojaReporte.Text   = lcrColumnasReporte;

            this.cboPropCboPlantTipoImpresion.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(lcrTipoImpresion, vm.PropCboPlantTipoImpresion);
            this.cboPropCboPlantTipoHojaReporte.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(lcrColumnasReporte, vm.PropCboPlantTipoHojaReporte);
        }
        #endregion
        #endregion 
        //------------------------------------------------------------
        // GESTIONAR ADICIONAR ETIQUETAS y IMAGENES PREDEFINIDAS
        //------------------------------------------------------------
        #region fcvEtiquetasBuscarParaAdicionar: Browser etiquetas para adicionar en la lista
        /// <summary>
        /// <para>Browser etiquetas para adicionar en la lista</para>
        /// </summary>
        private void fcvEtiquetasBuscarParaAdicionar(object sender, RoutedEventArgs e)
        {
            // por ahora solo para plantillas de historia clinica
            Browser01 frbro = new Browser01("GRP", "GRPMAEPLANTILLA", "Grpmaeplantilla.grp_tipfor_grpl ='ETIQUETA'", "Adicionar etiquetas...");
            gcrCtrF2TexBox = "ETIQUETA";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region fcvGetImgPredefinidaBuscar: Abrir el explorador de windows para buscar una imagenes predefinidas
        /// <summary>
        /// <para>Abrir el explorador de windows para buscar una imagenes predefinidas</para>
        /// </summary>
        private void fcvGetImgPredefinidaBuscar(object sender, RoutedEventArgs e)
        {
            var lcrRutayArchivo = String.Empty;
            var lcrRutaGaleria = oApp.gcrAppRecursoPath + @"\Imagenes\Plantillas";
            var lcrRutaDestino = oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + lcrRutaGaleria;
            var lcrNombreArchivo = String.Empty;

            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                lcrRutaDestino = @"\\" + oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + lcrRutaGaleria;
            }

            try
            {
                var lobArchivo = EdtUtilidades.fobBuscarArchivoRecurso("Buscar Imagen...", ".jpg", "Buscar imagenes (*.bmp, *.png, *.jpg)|*.bmp;*.png;*.jpg");

                if (lobArchivo != null)
                {
                    vm.fcvAccionImgPredefNuevo();
                    lcrRutayArchivo = lobArchivo.RutayArchivo;
                    lcrNombreArchivo = "IMG001_" + lobArchivo.NombreArchivo;

                    String lcrArchivoOrigen = System.IO.Path.Combine(lcrRutayArchivo);
                    this.txtGaleriaImgRutaDestino.Text = lcrRutaDestino + @"\" + lcrNombreArchivo;

                    if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                    {
                        this.txtGaleriaImgRutaDestino.Text = System.IO.Path.Combine(lcrRutaDestino, lcrNombreArchivo);
                    }

                    this.txtGaleriaImgCodigo.Text = String.Empty;
                    this.txtGaleriaImgTitulo.Text = String.Empty;
                    this.txtGaleriaImgRecursoCodigo.Text = "IM000111";
                    this.txtGaleriaImgRutaOrigen.Text = lcrRutayArchivo;
                    this.txtGaleriaImgRecursoRuta.Text = lcrRutaGaleria;
                    this.txtGaleriaImgRecursoArchivo.Text = lcrNombreArchivo;

                    var lobUri = new Uri(lcrArchivoOrigen, UriKind.RelativeOrAbsolute);
                    this.imgImagenPredefinida.Source = new BitmapImage(lobUri);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGetObjImagenImportar");
            }
        }
        #endregion
        //------------------------------------------------------------
        // GESTION ARRASTRAR OBJETOS Y ADORNOS
        //------------------------------------------------------------
        #region Gestion Arrastrar Objetos y Adornos
        #region fcvPreViewClicSeleccionObjeto : Selecciona el objeto clickeado o adiciona nuevo objeto
        /// <summary>
        ///  fcvPreViewClicSeleccionObjeto: PreviewMouseLeftButtonDown, Selecciona el objeto clickeado
        /// <para>o adiciona nuevo objeto. Guarda valores e inicia las Variables al seleccionar un objeto,</para>
        /// <para>remueve cualquier seleccion anterior de algun otro objeto. </para>
        /// <para>Coloca los adornos al objeto seleccionado. </para>
        /// </summary>
        void fcvPreViewClicSeleccionObjeto(object sender, MouseButtonEventArgs e)
        {
            this.stkPropBasicas.Visibility = Visibility.Visible;
            fcvRemoverAdornos(); //Remover seleccion de algun objeto anterior

            FrameworkElement luiRefObjetoClic = e.Source as FrameworkElement;

            fcvArbolReferenciaSelectObjetoClik(sender, e);
            vm.gobRefObjeto = null;
            vm.gobRefPagina = null;
            if (gobRefPaginaSeleccionada != null)
            {
                FocusManager.SetFocusedElement(this, gobRefPaginaSeleccionada);
            }
            // Adicionar Zona en una pagina
            if (gcrTipoObjetoNivel == "PAGINA")
            {
                if (glgNuevoObjetoCrear == true)
                {
                    fcvAdicionarObjetosEnPagina();
                }
                else
                {
                    vm.gobRefPagina = gobRefPaginaSeleccionada;
                    fcvGetObjActivarPropiedades();
                }
            }
            // Adicionar objeto en una zona
            else if (glgNuevoObjetoCrear == true)
            {
                fcvAdicionarObjetosEnPagina();
            }
            else if (glgNuevoObjetoCrear != true) // Solo es seleccion para colocar adornos 
            {
                #region seleccion de Objeto ya existente
                // Seleccionar el objeto clickeado y colocar adornos
                if (e.Source != gobRefPaginaSeleccionada && e.Source != gobRefContenedorPaginaSeleccionada) // Contenedor principal
                {
                    glgModoArrastrarObjeto = true;

                    guiRefObjetoSeleccionado = e.Source as UIElement;
                    if (gcrTipoObjetoNivel == "ZONA") // Una Zona de la pagina
                    {
                        guiRefObjetoSeleccionado = gobRefZonaSeleccionada;
                        gptPuntoDeInicio = e.GetPosition(gobRefPaginaSeleccionada);
                    }
                    else if (gcrTipoObjetoNivel == "GRUPO") // un objeto Grupo
                    {
                        guiRefObjetoSeleccionado = gobRefGrupoSeleccionado;
                        gptPuntoDeInicio = e.GetPosition(gobRefContenedorZonaSeleccionada);
                    }
                    else if (gcrTipoObjetoNivel == "ZONA-OBJETO") // Objeto dentro de la Zona
                    {
                        gptPuntoDeInicio = e.GetPosition(gobRefContenedorZonaSeleccionada);
                    }
                    else if (gcrTipoObjetoNivel == "GRUPO-OBJETO") // Objeto dentro de Grupo
                    {
                        gptPuntoDeInicio = e.GetPosition(gobRefContenedorGrupoSeleccionado);
                    }
                    gduObjetoInicialLeft = Canvas.GetLeft(guiRefObjetoSeleccionado);
                    gduObjetoInicialTop = Canvas.GetTop(guiRefObjetoSeleccionado);

                    luxUIAgregarAdorno = AdornerLayer.GetAdornerLayer(guiRefObjetoSeleccionado);
                    luxUIAgregarAdorno.Add(new Utilidades.AddResizingAdornos(guiRefObjetoSeleccionado,14));
                    glgSiObjetoSeleccionado = true;
                    // Maenajdor y Propiedades
                    e.Handled = true;
                    vm.gobRefObjeto = guiRefObjetoSeleccionado; // informar a vistamodelo
                    vm.gobRefPagina = gobRefPaginaSeleccionada;
                    fcvGetObjActivarPropiedades();
                }
                else
                {
                    gobRefPaginaSeleccionada.Focus();
                }
                #endregion
            }
        }
        #endregion
        #region fcvQuitarAdornoObjetoMouseLeftButtonDown : Quitar los adornos a un objeto que pierde el enfoque
        /// <summary>
        /// fcvQuitarAdornoObjetoMouseLeftButtonDown : Quitar los adornos a un objeto que pierde
        /// el enfoque 
        /// </summary>
        void fcvQuitarAdornoObjetoMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (glgSiObjetoSeleccionado)
            {
                glgSiObjetoSeleccionado = false;
                if (guiRefObjetoSeleccionado != null)
                {
                    luxUIAgregarAdorno.Remove(luxUIAgregarAdorno.GetAdorners(guiRefObjetoSeleccionado)[0]);
                    guiRefObjetoSeleccionado = null;
                }
            }
        }
        #endregion
        #region fcvFinalizaDragMouseManejador : Finalizar Manejador cuando el mouse abandona la zona de objetos
        /// <summary>
        /// <para>fcvFinalizaDragMouseManejador : Finalizar Manejador cuando el mouse abandona la zona del Canvas,</para>
        /// <para>se llama a la funcion fcvFinalizarArrasteAlSoltarMouse() para finalizar el manejador desde el mouse.</para>
        /// </summary>
        void fcvFinalizaDragMouseManejador(object sender, MouseButtonEventArgs e)
        {
            fcvFinalizarArrasteAlSoltarMouse();
            e.Handled = true;
        }
        #endregion
        #region fcvFinalizarArrasteAlSoltarMouse : Finalizar arrastre al soltar el mouse
        /// <summary>
        /// fcvFinalizarArrasteAlSoltarMouse: Funcion para Finalizar la accion de Arrastrar,
        /// <para>al soltar el boton del mouse, esta funcion coloca las variables: </para> 
        /// <para>glgModoArrastrarObjeto, glgAccionArrastrandoObjeto en FALSE</para> 
        /// </summary>
        private void fcvFinalizarArrasteAlSoltarMouse()
        {
            if (glgModoArrastrarObjeto)
            {
                glgModoArrastrarObjeto = false;
                glgAccionArrastrandoObjeto = false;
            }
        }
        #endregion
        #region fcvEventoMoverMouseEnZona : Detecta el movimiento del Mouse dentro de la zona
        /// <summary>
        /// <para> fcvEventoMoverMouseEnZona: Detecta el movimiento del Mouse dentro de la zona.</para>
        /// <para> Provee la operacion arrastre del objeto seleccionado.</para>
        /// <para> Esta funcion detectar el movimiento del mouse dentro la zona que valida par gestion objetos. </para>
        /// <para> Verifica que la posicion del mouse este dentro de la zona valida para arrastrar o colocar objetos, </para>
        /// <para> se cambia el estado de la variable glgAccionArrastrandoObjeto  a verdadero y se reasigana la posicion del objeto</para>
        /// <para> que este siendo arrastrado. </para>
        /// </summary>
        void fcvEventoMoverMouseEnZona(object sender, MouseEventArgs e)
        {
            if (glgModoArrastrarObjeto)
            {
                // Verificar la referencia al contenedor relativo Zona o Pagina
                Canvas lobRefContenedor = gobRefContenedorZonaSeleccionada;
                FrameworkElement luiRefObjetoMouse = e.Source as FrameworkElement;

                if (gcrTipoObjetoNivel == "ZONA") // Una Zona de la pagina
                {
                    lobRefContenedor = gobRefPaginaSeleccionada;
                }
                else if (gcrTipoObjetoNivel == "GRUPO") // Objeto Grupo
                {
                    lobRefContenedor = gobRefContenedorZonaSeleccionada;
                }
                else if (gcrTipoObjetoNivel == "ZONA-OBJETO") // Objeto dentro de la Zona
                {
                    lobRefContenedor = gobRefContenedorZonaSeleccionada;
                }
                else if (gcrTipoObjetoNivel == "GRUPO-OBJETO") // Objeto dentro de Grupo
                {
                    lobRefContenedor = gobRefContenedorGrupoSeleccionado;
                }
                //
                if ((glgAccionArrastrandoObjeto == false) &&
                    ((Math.Abs(e.GetPosition(lobRefContenedor).X - gptPuntoDeInicio.X) > SystemParameters.MinimumHorizontalDragDistance) ||
                    (Math.Abs(e.GetPosition(lobRefContenedor).Y - gptPuntoDeInicio.Y) > SystemParameters.MinimumVerticalDragDistance)))
                    glgAccionArrastrandoObjeto = true;

                if (glgAccionArrastrandoObjeto)
                {
                    Point position = Mouse.GetPosition(lobRefContenedor);
                    Canvas.SetTop(guiRefObjetoSeleccionado, position.Y - (gptPuntoDeInicio.Y - gduObjetoInicialTop));
                    Canvas.SetLeft(guiRefObjetoSeleccionado, position.X - (gptPuntoDeInicio.X - gduObjetoInicialLeft));
                    fcvGetObjPropiedadesReSizeObjeto();
                }
            }
        }
        #endregion
        #region fcvEventoMoverMouseFueraDeZona : Detecta el movimiento del Mouse fuera de la zona
        /// <summary>
        /// <para>fcvEventoMoverMouseFueraDeZona: viene de MouseLeave, llama a la funcion fcvFinalizarArrasteAlSoltarMouse,</para>
        /// <para>porque se ha avandonado la zona de gestion del objeto, se devuelve el manejador (se deja libre)</para>
        /// </summary>
        void fcvEventoMoverMouseFueraDeZona(object sender, MouseEventArgs e)
        {
            fcvFinalizarArrasteAlSoltarMouse();
            e.Handled = true;
        }
        #endregion
        #region fcvRemoverAdornos : Remover adornos de seleccion de algun objeto anterior
        /// <summary>
        /// fcvRemoverAdornos : Remover adornos de seleccion de algun objeto anterior
        /// </summary>
        private void fcvRemoverAdornos()
        {
            if (glgSiObjetoSeleccionado)
            {
                glgSiObjetoSeleccionado = false;
                if (guiRefObjetoSeleccionado != null)
                {
                    // Quitar los adornos del anterior objeto seleccionado
                    luxUIAgregarAdorno.Remove(luxUIAgregarAdorno.GetAdorners(guiRefObjetoSeleccionado)[0]);
                    guiRefObjetoSeleccionado = null;
                }
            }
        }
        #endregion
        #region fcvAccionReSizeObjeto : Actualizar las propiedades en VistaModelo al ReSize objeto
        /// <summary>
        /// Actualizar las propiedades en VistaModelo al ReSize objeto
        /// </summary>
        public void fcvAccionReSizeObjeto(object sender, RoutedEventArgs e)
        {
            fcvGetObjPropiedadesReSizeObjeto();
        }
        #endregion
        #region Devolver apuntadores a todos los componentes del Tree del objeto seleccionado
        #region fcvArbolReferenciaSelectObjetoClik : Devolver apuntadores a todos los componentes del Tree del objeto seleccionado
        /// <summary>
        /// <para>Devolver apuntadores a todos los componentes del Arbol del objeto seleccionado con click.</para>
        /// <para>Tambien define el tipo de objetos seleccionado segun el nivel en el Arbol.</para>
        /// <para>gcrTipoObjetoNivel: Tipos de objetos a definir segun nivel:</para>
        /// <para>"PAGINA"      = Se selecciono el contenedor de la pagina.</para>
        /// <para>"ZONA"        = Click sobre el contenedor de una Zona .</para>
        /// <para>"ZONA-OBJETO" = es un Objeto dentro del contenedor de una Zona .</para>
        /// <para>"GRUPO"       = Un Grupo son Objetos en Zona del tipo radiobutton, odontogramas, imagenes complejas y otros.</para>
        /// <para>"GRUPO-OBJETO"= Es un objeto que hace parte de un grupo (radiobutton, odontogramas, imagenes complejas y otros).</para>
        /// </summary>
        private void fcvArbolReferenciaSelectObjetoClik(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement lobObjetoSelectClick = e.Source as FrameworkElement;
            
            gcrTipoObjetoNivel = "NA";
            gcrObjetoClassBase = "NA";
            gobRefPaginaSeleccionada = null;
            gobRefZonaSeleccionada = null;
            gobRefGrupoSeleccionado = null;
            gobRefContenedorPaginaSeleccionada = null;
            gobRefContenedorZonaSeleccionada = null;
            gobRefContenedorGrupoSeleccionado = null;
            guiRefObjetoSeleccionado = lobObjetoSelectClick as UIElement;
            String lcrNombreObjeto = lobObjetoSelectClick.Name.Substring(0, 7).ToUpper();
            String lcrNombreContenedor = String.Empty;
            // referencias en tree 
            XmlEntorno.refTreeObj.Pagina = null;
            XmlEntorno.refTreeObj.ContenedorPagina  = null;
            XmlEntorno.refTreeObj.Zona = null;
            XmlEntorno.refTreeObj.ContenedorZona = null;
            XmlEntorno.refTreeObj.Grupo = null;
            XmlEntorno.refTreeObj.ContenedorGrupo = null;
            XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
            //-----------------------------------------
            // Click en la Pagina
            //-----------------------------------------
            if (lcrNombreObjeto == "OBJPAGI" || lcrNombreObjeto == "OBJCPAG")
            {
                guiRefObjetoSeleccionado = null;
                gcrTipoObjetoNivel = "PAGINA";
                XmlEntorno.refTreeObj.NivelObjetoSelect = 1;
                fcvReferenciaVarNivelPagina(lobObjetoSelectClick);
                lcrNombreContenedor = gobRefPaginaSeleccionada.Name;
            }
            //-----------------------------------------
            // es una Zona / OBJCZON = Objeto tipo Canvas contenedor dentro de una Zona
            //-----------------------------------------
            else if (lcrNombreObjeto == "OBJZONA" || lcrNombreObjeto == "OBJCZON")
            {
                gcrTipoObjetoNivel = "ZONA";
                XmlEntorno.refTreeObj.NivelObjetoSelect = 2;
                fcvReferenciaVarNivelZona(lobObjetoSelectClick);
                lcrNombreContenedor = gobRefZonaSeleccionada.Name;
            }
            //-----------------------------------------
            // Ver si es Grupo de objetos dentro de zona / o el objeto contenedor del grupo 
            //-----------------------------------------
            else if (lcrNombreObjeto == "OBJGRUP" || lcrNombreObjeto == "OBJCGRU") // se selecciono Grupo de objetos o su contenedor
            {
                gcrTipoObjetoNivel = "GRUPO";
                XmlEntorno.refTreeObj.NivelObjetoSelect = 4;
                fcvReferenciaVarNivelGrupo(lobObjetoSelectClick);
                lcrNombreContenedor = gobRefGrupoSeleccionado.Name;
            }
            //-----------------------------------------
            // Objetos Dentro de Zona o Grupo
            //-----------------------------------------
            else
            {
                FrameworkElement lobParent = lobObjetoSelectClick.Parent as FrameworkElement;
                lcrNombreObjeto = lobParent.Name.Substring(0, 7).ToUpper();
                gcrTipoObjetoNivel = "ZONA-OBJETO";
                XmlEntorno.refTreeObj.NivelObjetoSelect = 3;

                if (lcrNombreObjeto == "OBJGRUP" || lcrNombreObjeto == "OBJCGRU") // se selecciono un objeto dentro de Grupo de objetos
                {
                    gcrTipoObjetoNivel = "GRUPO-OBJETO";
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 5;
                    fcvReferenciaVarNivelGrupo(lobParent);
                    lcrNombreContenedor = gobRefGrupoSeleccionado.Name;
                }
                else if (lcrNombreObjeto == "OBJZONA" || lcrNombreObjeto == "OBJCZON") // se selecciono un objeto dentro de la zona
                {
                    gcrTipoObjetoNivel = "ZONA-OBJETO";
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 3;
                    fcvReferenciaVarNivelZona(lobParent);
                    lcrNombreContenedor = gobRefZonaSeleccionada.Name;
                }
                guiRefObjetoSeleccionado = lobObjetoSelectClick as UIElement;
            }
            //Referencias tree
            var lcrObjeto =  XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lcrNombreContenedor).FirstOrDefault();

            XmlEntorno.refTreeObj.Pagina           = gobRefPaginaSeleccionada;
            XmlEntorno.refTreeObj.ContenedorPagina = gobRefContenedorPaginaSeleccionada;
            XmlEntorno.refTreeObj.Zona             = gobRefZonaSeleccionada;
            XmlEntorno.refTreeObj.ContenedorZona   = gobRefContenedorZonaSeleccionada;
            XmlEntorno.refTreeObj.Grupo            = gobRefGrupoSeleccionado;
            XmlEntorno.refTreeObj.ContenedorGrupo  = gobRefContenedorGrupoSeleccionado;
            XmlEntorno.refTreeObj.Navegador        = lcrObjeto.Navegador;
            XmlEntorno.refTreeObj.CodigoPlantilla  = lcrObjeto.CodigoPlantilla;
            vm.gcrTipoContenedorActivo     = lcrObjeto.TipoObjeto.ToUpper();

        }
        #endregion
        #region fcvReferenciaVarNivelPagina : Devolver las referencias a las variables iniciando desde Nivel Pagina
        /// <summary>
        /// Devolver las referencias a las variables iniciando desde Nivel Pagina
        /// </summary>
        private void fcvReferenciaVarNivelPagina(FrameworkElement tobObjetoSelectClick)
        {
            String lcrNombreObjeto = tobObjetoSelectClick.Name.Substring(0, 7).ToUpper();
            if (lcrNombreObjeto == "OBJPAGI" || lcrNombreObjeto == "OBJCPAG")
            {
                if (lcrNombreObjeto == "OBJCPAG")
                {
                    gobRefPaginaSeleccionada = tobObjetoSelectClick.Parent as  Canvas; // Buscar la Pagina que contiene la zona
                    gobRefContenedorPaginaSeleccionada = tobObjetoSelectClick as WrapPanel;
                }
                else
                {
                    gobRefPaginaSeleccionada = tobObjetoSelectClick as Canvas;
                    gobRefContenedorPaginaSeleccionada = XmlEntorno.fobRegSelectParenObjeto("OBJETOS","", gobRefPaginaSeleccionada.Name).
                                                                                               FirstOrDefault().RefContenedorObjeto as WrapPanel;
                }
                gcrObjetoClassBase = "CANVAS";
            }
        }
        #endregion
        #region fcvReferenciaVarNivelZona : Devolver las referencias a las variables iniciando desde Nivel Zona
        /// <summary>
        /// fcvReferenciaVarNivelZona : Devolver las referencias a las variables iniciando desde Nivel Zona
        /// </summary>
        private void fcvReferenciaVarNivelZona(FrameworkElement tobObjetoSelectClick)
        {
            String lcrNombreObjeto = tobObjetoSelectClick.Name.Substring(0, 7).ToUpper();
            if (lcrNombreObjeto == "OBJZONA" || lcrNombreObjeto == "OBJCZON")
            {
                if (lcrNombreObjeto == "OBJCZON")
                {
                    gobRefZonaSeleccionada = tobObjetoSelectClick.Parent as GroupBox;
                    gobRefContenedorZonaSeleccionada = tobObjetoSelectClick as Canvas;
                }
                else
                {
                    gobRefZonaSeleccionada = tobObjetoSelectClick as GroupBox;
                    gobRefContenedorZonaSeleccionada = XmlEntorno.fobRegSelectParenObjeto("OBJETOS","", gobRefZonaSeleccionada.Name).
                                                                                               FirstOrDefault().RefContenedorObjeto as Canvas;
                }
                gcrObjetoClassBase = "CANVAS";
            }
            guiRefObjetoSeleccionado = gobRefZonaSeleccionada;
            gobRefContenedorPaginaSeleccionada = gobRefZonaSeleccionada.Parent as WrapPanel; // Buscar la pagian que contiene la zona
            gobRefPaginaSeleccionada = gobRefContenedorPaginaSeleccionada.Parent as Canvas; // Buscar la pagian que contiene la zona
        }
        #endregion
        #region fcvReferenciaVarNivelGrupo : Devolver las referencias a las variables iniciando desde Nivel Grupo
        /// <summary>
        /// fcvReferenciaVarNivelGrupo : Devolver las referencias a las variables iniciando desde Nivel Grupo
        /// </summary>
        private void fcvReferenciaVarNivelGrupo(FrameworkElement tobObjetoSelectClick)
        {
            String lcrNombreObjeto = tobObjetoSelectClick.Name.Substring(0, 7).ToUpper();
            if (lcrNombreObjeto == "OBJGRUP" || lcrNombreObjeto == "OBJCGRU")
            {
                if (lcrNombreObjeto == "OBJCGRU")
                {
                    gobRefContenedorGrupoSeleccionado = tobObjetoSelectClick as Canvas;
                    gobRefGrupoSeleccionado = tobObjetoSelectClick.Parent as GroupBox;
                }
                else
                {
                    gobRefGrupoSeleccionado = tobObjetoSelectClick as GroupBox;
                    gobRefContenedorGrupoSeleccionado = XmlEntorno.fobRegSelectParenObjeto("OBJETOS","", gobRefGrupoSeleccionado.Name).
                                                                                               FirstOrDefault().RefContenedorObjeto as Canvas;

                }
                gcrObjetoClassBase                      = "GROUPBOX";
                gobRefContenedorZonaSeleccionada        = gobRefGrupoSeleccionado.Parent as Canvas;
                gobRefZonaSeleccionada                  = gobRefContenedorZonaSeleccionada.Parent as GroupBox;
                gobRefContenedorPaginaSeleccionada      = gobRefZonaSeleccionada.Parent as WrapPanel; // Buscar la pagian que contiene la zona
                gobRefPaginaSeleccionada                = gobRefContenedorPaginaSeleccionada.Parent as Canvas; // Buscar la pagian que contiene la zona
            }
        }
        #endregion
        #endregion
        #region fcvEventoManejadorKeyDown : Mover Objeto seleccionado con flechas del teclado
        /// <summary>
        /// fcvEventoManejadorKeyDown : Mover Objeto seleccionado con flechas del teclado
        /// </summary>
        void fcvEventoManejadorKeyDown(object sender, KeyEventArgs e)
        {
            if (guiRefObjetoSeleccionado != null)
            {
                double lduleft = Canvas.GetLeft(guiRefObjetoSeleccionado);
                if (Double.IsNaN(lduleft)) lduleft = 0;
                double lduTop = Canvas.GetTop(guiRefObjetoSeleccionado);
                if (Double.IsNaN(lduTop)) lduTop = 0;

                switch (e.Key)
                {
                    case Key.Left:
                        lduleft--;
                        break;

                    case Key.Right:
                        lduleft++;
                        break;

                    case Key.Up:
                        lduTop--;
                        break;

                    case Key.Down:
                        lduTop++;
                        break;

                    default: return;
                }
                // para no salir del Canvas contenedor
                if (lduleft < 0) lduleft = 0;
                if (lduTop < 0) lduTop = 0;

                Canvas.SetLeft(guiRefObjetoSeleccionado, lduleft);
                Canvas.SetTop(guiRefObjetoSeleccionado, lduTop);
                e.Handled = true;
                fcvGetObjPropiedadesReSizeObjeto();
            }
        }
        #endregion
        #endregion Fin Gestion Arrastrar y  Adornos 
        //------------------------------------------------------------
        // GESTION PARA ADICIONAR OBJETOS A ZONAS
        //------------------------------------------------------------
        #region Gestión adicionar objetos en Zonas
        #region fcvAdicionarObjetosEnPagina: Ubicacion para adicionar objeto en plantilla/pagina/zona/grupo seleccionado
        /// <summary>
        ///  Ubicacion para adicionar objeto en plantilla/pagina/zona/grupo seleccionado
        /// </summary>
        private void fcvAdicionarObjetosEnPagina()
        {
            bool llgRefValida = false;
            String lcrNombreContenedor = String.Empty;
            Point lptPosMouse = Mouse.GetPosition(gobRefContenedorPaginaSeleccionada);
            switch (gcrAddNuevoObjetoTipo)
            {
                case "ZONA":
                    if (gobRefPaginaSeleccionada != null)
                    {
                        llgRefValida = true;
                        lptPosMouse = Mouse.GetPosition(gobRefContenedorPaginaSeleccionada);
                        lcrNombreContenedor=gobRefPaginaSeleccionada.Name;
                    }
                    break;

                case "GRUPO":
                    if (gobRefContenedorZonaSeleccionada != null)
                    {
                        llgRefValida = true;
                        lptPosMouse = Mouse.GetPosition(gobRefContenedorZonaSeleccionada);
                        lcrNombreContenedor=gobRefZonaSeleccionada.Name;
                    }
                    break;
                default:
                    if (XmlEntorno.refTreeObj.NivelObjetoSelect <= 3) // Objetos en Zona
                    {
                        if (gobRefContenedorZonaSeleccionada != null)
                        {
                            llgRefValida = true;
                            lptPosMouse = Mouse.GetPosition(gobRefContenedorZonaSeleccionada);
                            lcrNombreContenedor=gobRefZonaSeleccionada.Name;
                        }
                    }
                    else 
                    {
                        if (gobRefContenedorGrupoSeleccionado != null)
                        {
                            llgRefValida = true;
                            lptPosMouse = Mouse.GetPosition(gobRefContenedorGrupoSeleccionado);
                            lcrNombreContenedor=gobRefGrupoSeleccionado.Name;
                        }
                    }
                    break;
            }
            if (llgRefValida == true && !String.IsNullOrWhiteSpace(lcrNombreContenedor)) 
            {
                var lcrTipoContenedor = XmlEntorno.fobRegSelectParenObjeto("OBJETOS","", lcrNombreContenedor).FirstOrDefault().TipoObjeto.ToUpper();

                if (EdtUtilidades.flgSiContenedorAdicionarObjeto(lcrTipoContenedor, gcrAddNuevoObjetoTipo) == true)
                {
                    gduCanvasClicPosX = lptPosMouse.X;
                    gduCanvasClicPosY = lptPosMouse.Y;
                    fcvAdicionarTipoObjeto(gcrAddNuevoObjetoTipo);
                }
            }
        }

        #endregion
        #region fcvAdicionarTipoObjeto: Seleccion tipo Objeto Adicionar en Pagina/Zona/grupo
        /// <summary>
        /// Seleccion tipo Objeto Adicionar en Pagina/Zona/grupo
        /// </summary>
        private void fcvAdicionarTipoObjeto(String tcrTipoObjeto)
        {
            gnuContadorAddZonas++;
            switch (tcrTipoObjeto.ToUpper())
            {
                case "ZONA":
                    fcvAddZonaObjeto();
                    break;

                case "TEXTBOX":
                    fcvAddTextBoxObjeto();
                    break;

                case "RICHTEXTBOX":
                    fcvAddRichTextBoxObjeto();
                    break;


                case "TEXTBOXREL":
                    fcvAddTextBoxRelObjeto();
                    break;

                case "COMBOBOX":
                    fcvAddComboBoxObjeto();
                    break;

                case "MULTIRADIOBUTTON":
                    fcvCmdAddRadioButtonObjeto();
                    break;

                case "MULTICHKBOX":
                    fcvCmdAddCheckBoxObjeto();
                    break;

                default: // Para el resto de objetos
                    XmlEntorno.flgAddNuevoObjeto(gcrAddNuevoObjetoTipo, gduCanvasClicPosX, gduCanvasClicPosY);
                    fcvMajenadorSizeChanged(XmlEntorno.refRegObjActivo.RefObjeto, XmlEntorno.refRegObjActivo.ClaseBase);
                    fnuCmdDesHacerAddRegistroPila("ADICIONADO", XmlEntorno.refRegObjActivo);
                    break;
            }
            fcvRestablecerPunteroMouse();
            gcrAddNuevoObjetoTipo = String.Empty;
            glgNuevoObjetoCrear = false;
        }
        #endregion
        #region fcvModificarPunteroMouse: modificar puntro mouse al modo adicionar
        /// <summary>
        /// <para>Modificar el puntero del mouse para mostrar el modo adicionar objeto</para>
        /// </summary>
        private void fcvModificarPunteroMouse()
        {
            fcvModificarPunteroMouseEx("ADD");
        }
        #endregion
        #region fcvRestablecerPunteroMouse: Restablecer puntro mouse del modo Adicionar
        private void fcvRestablecerPunteroMouse()
        {
            fcvModificarPunteroMouseEx("EDT");
        }
        #endregion
        #region fcvModificarPunteroMouseEx: modificar puntro mouse al modo adicionar
        /// <summary>
        /// <para>Recorre todos los contenedores para  Modificar el puntero del mouse.</para>
        /// <para>tcrTipoPuntero: ADD = Modo Adicionar objeto EDT= Modo Normal.</para>
        /// </summary>
        private void fcvModificarPunteroMouseEx(String tcrTipoPuntero)
        {
            foreach (var lobItem in XmlEntorno.tmpObjetos)
            {
                if (lobItem.ClaseBase == "GroupBox" || lobItem.ClaseBase == "Canvas" ||
                    lobItem.ClaseBase == "WrapPanel" || lobItem.ClaseBase == "StackPanel")
                {
                    FrameworkElement lobObjeto = lobItem.RefObjeto as FrameworkElement;
                    lobObjeto.Cursor = tcrTipoPuntero == "ADD" ? Cursors.Cross : Cursors.Arrow;
                }
            }
        }
        #endregion
        //- Pagina
        #region fcvCmdAddPaginaObjetos: Adicionar Pagina
        private void fcvCmdAddPaginaObjetos(object sender, RoutedEventArgs e)
        {
            fcvCmdAddPaginaObjetosEx();
        }
        private void fcvCmdAddPaginaObjetosEx()
        {
            if (XmlEntorno.flgAddNuevoObjeto("PAGINA", gduCanvasClicPosX, gduCanvasClicPosY))
            {
                fnuCmdDesHacerAddRegistroPila("ADICIONADO", XmlEntorno.refRegObjActivo);

                Canvas lobObjeto = XmlEntorno.refRegObjActivo.RefObjeto as Canvas;
                lobObjeto.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                lobObjeto.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                fcvGetValorBaseZoomScroll("SET");
            }
        }
        #endregion
        //- Objetos
        #region fcvCmdAddZonaObjetos: Adicionar Zona en la pagina activa
        private void fcvCmdAddZonaObjetos(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "ZONA";
            glgNuevoObjetoCrear = true;
            gobPaginaSelectParaAddZona = gobRefPaginaSeleccionada;
            fcvModificarPunteroMouse();
        }
        private void fcvAddZonaObjeto()
        {
            if (XmlEntorno.flgAddNuevoObjeto(gcrAddNuevoObjetoTipo, gduCanvasClicPosX, gduCanvasClicPosY))
            {
                fnuCmdDesHacerAddRegistroPila("ADICIONADO", XmlEntorno.refRegObjActivo);

                GroupBox lobObjeto = XmlEntorno.refRegObjActivo.RefObjeto as GroupBox;
                lobObjeto.MouseLeftButtonDown += new MouseButtonEventHandler(fcvQuitarAdornoObjetoMouseLeftButtonDown);
                lobObjeto.MouseLeftButtonUp += new MouseButtonEventHandler(fcvFinalizaDragMouseManejador);
                lobObjeto.MouseMove += new MouseEventHandler(fcvEventoMoverMouseEnZona);
                lobObjeto.MouseLeave += new MouseEventHandler(fcvEventoMoverMouseFueraDeZona);
                lobObjeto.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                lobObjeto.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(fcvFinalizaDragMouseManejador);
                fcvMajenadorSizeChanged(XmlEntorno.refRegObjActivo.RefObjeto, XmlEntorno.refRegObjActivo.ClaseBase);
            }
        }
        #endregion
        #region fcvCmdAddTextBoxRel: Adicionar Cuadro de texto Relacion
        private void fcvCmdAddTextBoxRel(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "TEXTBOXREL";
            if (flgCmdAddValidaAsignarCampos(gcrAddNuevoObjetoTipo))
            {
                glgNuevoObjetoCrear = true;
                fcvModificarPunteroMouse();
            }
        }
        private void fcvAddTextBoxRelObjeto()
        {
            if (XmlEntorno.flgAddNuevoObjeto(gcrAddNuevoObjetoTipo, gduCanvasClicPosX, gduCanvasClicPosY))
            {
               fcvAdicionarManejadorPaginasyZonas("AUXILIAR");
               foreach (var lobItem in XmlEntorno.tmpObjetosAux)
               {
                   if (lobItem.TipoObjeto == "TEXTBOXREL")
                   {
                       fnuCmdDesHacerAddRegistroPila("ADICIONADO", lobItem);
                   }
               }
            }
        }
        #endregion
        #region fcvCmdAddTextBox: Adicionar Cuadro de texto
        private void fcvCmdAddTextBox(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "TEXTBOX";
            if (flgCmdAddValidaAsignarCampos(gcrAddNuevoObjetoTipo))
            {
                glgNuevoObjetoCrear = true;
                fcvModificarPunteroMouse();
            }
        }
        private void fcvAddTextBoxObjeto()
        {
            if (XmlEntorno.flgAddNuevoObjeto(gcrAddNuevoObjetoTipo, gduCanvasClicPosX, gduCanvasClicPosY))
            {
                fnuCmdDesHacerAddRegistroPila("ADICIONADO", XmlEntorno.refRegObjActivo);
                TextBox lobTexto = XmlEntorno.refRegObjActivo.RefObjeto as TextBox;
                lobTexto.Focusable = false;
                fcvMajenadorSizeChanged(XmlEntorno.refRegObjActivo.RefObjeto, XmlEntorno.refRegObjActivo.ClaseBase);
            }
        }
        #endregion
        #region fcvCmdAddRichTextBox: Adicionar Cuadro de RichTextBox
        private void fcvCmdAddRichTextBox(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "RICHTEXTBOX";
            if (flgCmdAddValidaAsignarCampos(gcrAddNuevoObjetoTipo))
            {
                glgNuevoObjetoCrear = true;
                fcvModificarPunteroMouse();
            }
        }
        private void fcvAddRichTextBoxObjeto()
        {
            if (XmlEntorno.flgAddNuevoObjeto(gcrAddNuevoObjetoTipo, gduCanvasClicPosX, gduCanvasClicPosY))
            {
                fnuCmdDesHacerAddRegistroPila("ADICIONADO", XmlEntorno.refRegObjActivo);
                TextBox lobRichTextBox = XmlEntorno.refRegObjActivo.RefObjeto as TextBox;
                lobRichTextBox.Focusable = false;
                fcvMajenadorSizeChanged(XmlEntorno.refRegObjActivo.RefObjeto, XmlEntorno.refRegObjActivo.ClaseBase);
            }
        }
        #endregion
        #region fcvCmdAddTextBlock: Adicionar Cuadro de texto
        private void fcvCmdAddTextBlock(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "TEXTBLOCK";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddComboBox: Adicionar lista ComboBox
        private void fcvCmdAddComboBox(object sender, RoutedEventArgs e) 
        {
            gcrAddNuevoObjetoTipo = "COMBOBOX";
            if (flgCmdAddValidaAsignarCampos(gcrAddNuevoObjetoTipo))
            {
                glgNuevoObjetoCrear = true;
                fcvModificarPunteroMouse();
            }
        }
        private void fcvAddComboBoxObjeto()
        {
            if (XmlEntorno.flgAddNuevoObjeto(gcrAddNuevoObjetoTipo, gduCanvasClicPosX, gduCanvasClicPosY))
            {
                fnuCmdDesHacerAddRegistroPila("ADICIONADO", XmlEntorno.refRegObjActivo);
                ComboBox lobTexto = XmlEntorno.refRegObjActivo.RefObjeto as ComboBox;
                lobTexto.Focusable = false;
                fcvMajenadorSizeChanged(XmlEntorno.refRegObjActivo.RefObjeto, XmlEntorno.refRegObjActivo.ClaseBase);
            }
        }
        #endregion
        #region fcvCmdAddImage: Adicionar Imagen
        private void fcvCmdAddImage(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "IMAGEN";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlFecha: Adicionar Control Captura de fecha
        private void fcvCmdAddControlFecha(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "TEXTBOXDATE";
            if (flgCmdAddValidaAsignarCampos(gcrAddNuevoObjetoTipo))
            {
                glgNuevoObjetoCrear = true;
                fcvModificarPunteroMouse();
            }
        }
        #endregion
        #region fcvCmdAddControlHora: Adicionar Control Captura de Hora
        private void fcvCmdAddControlHora(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "TEXTBOXTIME";
            if (flgCmdAddValidaAsignarCampos(gcrAddNuevoObjetoTipo))
            {
                glgNuevoObjetoCrear = true;
                fcvModificarPunteroMouse();
            }
        }
        #endregion
        //- Controles Preguntas multiples
        #region fcvCmdAddMultiRadioButton: Multiples preguntas con unica respuesta (RadioButton)
        private void fcvCmdAddMultiRadioButton(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "MULTIGROUPRADIOBUTTON";
            if (flgCmdAddValidaAsignarCampos(gcrAddNuevoObjetoTipo))
            {
                glgNuevoObjetoCrear = true;
                fcvModificarPunteroMouse();
            }
        }
        #endregion
        #region fcvCmdAddRadioButton: Adicionar RadioButton
        private void fcvCmdAddRadioButton(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "MULTIRADIOBUTTON";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        private void fcvCmdAddRadioButtonObjeto()
        {
            if (XmlEntorno.flgAddNuevoObjeto(gcrAddNuevoObjetoTipo, gduCanvasClicPosX, gduCanvasClicPosY))
            {
                fcvCmdAddReindexGrupoObjetos(XmlEntorno.refRegObjActivo.Parent);
                fnuCmdDesHacerAddRegistroPila("ADICIONADO", XmlEntorno.refRegObjActivo);
                RadioButton lobObjeto = XmlEntorno.refRegObjActivo.RefObjeto as RadioButton;
                lobObjeto.Focusable = false;
                fcvMajenadorSizeChanged(XmlEntorno.refRegObjActivo.RefObjeto, XmlEntorno.refRegObjActivo.ClaseBase);
            }
        }
        #endregion
        #region fcvCmdAddMultiCheckBox: Multiples pregunas y multiples respuestas (CheckBox)
        private void fcvCmdAddMultiCheckBox(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "MULTIGROUPCHKBOX";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddCheckBox: Adicionar Control chequeo respuesta (CheckBox)
        private void fcvCmdAddCheckBox(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "MULTICHKBOX";
            if (flgCmdAddValidaAsignarCampos(gcrAddNuevoObjetoTipo))
            {
                glgNuevoObjetoCrear = true;
                fcvModificarPunteroMouse();
            }
        }
        private void fcvCmdAddCheckBoxObjeto()
        {
            if (XmlEntorno.flgAddNuevoObjeto(gcrAddNuevoObjetoTipo, gduCanvasClicPosX, gduCanvasClicPosY))
            {
                fcvCmdAddReindexGrupoObjetos(XmlEntorno.refRegObjActivo.Parent);
                fnuCmdDesHacerAddRegistroPila("ADICIONADO", XmlEntorno.refRegObjActivo);
                CheckBox lobObjeto = XmlEntorno.refRegObjActivo.RefObjeto as CheckBox;
                lobObjeto.Focusable = false;
                fcvMajenadorSizeChanged(XmlEntorno.refRegObjActivo.RefObjeto, XmlEntorno.refRegObjActivo.ClaseBase);
            }
        }
        #endregion
        // Asignacion de campos a nuevos objetos / Quitar campos de objetos eliminados
        #region flgCmdAddValidaAsignarCampos: Validar Asignar/marcar campos relacionados con objetos
        /// <summary>
        /// <para>Validar Asignar/marcar campos relacionados con objetos que guardan datos en tablas</para>
        /// </summary>
        public bool flgCmdAddValidaAsignarCampos(String tcrTipoObjeto)
        {
            var lcrCampos = "-TEXTBOX-TEXTBOXDATE-TEXTBOXTIME-RICHTEXTBOX-" +
                            "COMBOBOX-TEXTBOXREL-MULTICHKBOX-MULTIGROUPRADIOBUTTON-";
            var llgReturn = true;
            if (lcrCampos.Contains(tcrTipoObjeto))
            {
                var lobCampoCod = XmlEntorno.fobEdtCamposTablasBuscarLibre(tcrTipoObjeto);
                if (lobCampoCod == null)
                {
                    MessageBox.Show("No se permite agregar este tipo de objeto, se ha llegado al maximo permitido.");
                    llgReturn = false;
                }
            }
            return llgReturn;
        }
        #endregion
        // Controles
        #region fcvCmdAddControlAdmision: Adicionar Control datos basicos de admision (solo admitidos)
        private void fcvCmdAddControlAdmision(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLADMISION";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlFirmaProfesional: Adicionar Control firma del profesional medico que atiende
        private void fcvCmdAddControlFirmaProfesional(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLFIRMAPROFESIONAL";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlCaptura: Adicionar Control adicion de registros (solo admitidos)
        private void fcvCmdAddControlCaptura(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLCAPTURA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlHojaAdmision: Adicionar Control Hoja de admision (solo admitido)
        private void fcvCmdAddControlHojaAdmision(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLHOJAADMISION";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlAdmitido: Adicionar Control datos basicos paciente (admitido o ambulatoria)
        private void fcvCmdAddControlAdmitido(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLADMITIDO";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlTriage: Adicionar Control Triage de urgencia
        private void fcvCmdAddControlTriage(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLTRIAGE";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlUsuarioAtendido: Adicionar Control Vista datos en base de datos para usuario atendido
        private void fcvCmdAddControlUsuarioAtendido(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLUSUATENDIDO";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlFramingham: Adicionar Control test de Framingham
        private void fcvCmdAddControlFramingham(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLFRAMINGHAM";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlImc: Adicionar Control Indice de masa corporal
        private void fcvCmdAddControlImc(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLIMC";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlEadAudicionLenguage: Adicionar Control test Audicion y lenguaje
        private void fcvCmdAddControlEadAudicionLenguage(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLEADAUDICIONLENGUAJE";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlEadMotriFinoAdaptativa: Adicionar Control test Motricidad fino adaptativa
        private void fcvCmdAddControlEadMotriFinoAdaptativa(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLEADMOTRICIFINOADAPT";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlMotricidadGruesa: Adicionar Control test Motricidad gruesa
        private void fcvCmdAddControlMotricidadGruesa(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLEADMOTRICIGRUESA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlEadPersonalSocial: Adicionar Control test Personal social
        private void fcvCmdAddControlEadPersonalSocial(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLEADPERSONALSOCIAL";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddControlEadPuntuacion: Adicionar Control test Total puntuacion
        private void fcvCmdAddControlEadPuntuacion(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "CONTROLEADGRAFPUNTUACION";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        // Figuras
        #region fcvCmdAddRectangulo: Adicionar Rectangulo
        private void fcvCmdAddRectangulo(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "RECTANGULO";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddElipse: Adicionar elipse
        private void fcvCmdAddElipse(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "ELIPSE";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddLineaHorizontal: Adicionar Linea Horizontal
        private void fcvCmdAddLineaHorizontal(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "LINEA-HORIZONTAL";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddLineaVertical: Adicionar Linea Vertical
        private void fcvCmdAddLineaVertical(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "LINEA-VERTICAL";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddLineaderecha: Adicionar Linea Derecha
        private void fcvCmdAddLineaDerecha(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "LINEA-DERECHA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddLineaIzquierda: Adicionar Linea Izquierda
        private void fcvCmdAddLineaIzquierda(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "LINEA-IZQUIERDA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        // Flechas
        #region fcvCmdAddFlechaDerecha: Adicionar Flecha Derecha
        private void fcvCmdAddFlechaDerecha(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "FLECHA-DERECHA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddFlechaIzquierda: Adicionar Flecha Izquierda
        private void fcvCmdAddFlechaIzquierda(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "FLECHA-IZQUIERDA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddFlechaArriba: Adicionar Flecha arriba
        private void fcvCmdAddFlechaArriba(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "FLECHA-ARRIBA";
            glgNuevoObjetoCrear = true;
            fcvModificarPunteroMouse();
        }
        #endregion
        #region fcvCmdAddFlechaAbajo: Adicionar Flecha Abajo
        private void fcvCmdAddFlechaAbajo(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "FLECHA-ABAJO";
            glgNuevoObjetoCrear = true;
            gobRefZonaSeleccionada.Cursor = Cursors.Cross;
        }
        #endregion
        #region fcvCmdAddPoligono: Adicionar poligono
        private void fcvCmdAddPoligono(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "POLIGONO";
            glgNuevoObjetoCrear = true;
            gobRefZonaSeleccionada.Cursor = Cursors.Cross;
        }
        private void fcvCmdAddPoligonoObjeto()
        {
            PointCollection luxPuntos = new PointCollection();
            luxPuntos.Add(new Point(0, 0));
            luxPuntos.Add(new Point(0, 1));
            luxPuntos.Add(new Point(1, 1));

            Polygon lobPoligono = new Polygon();

            lobPoligono.Points = luxPuntos;
            lobPoligono.Name = "polPligono" + gnuContadorAddZonas.ToString().Trim();
            lobPoligono.Height = 100;
            lobPoligono.Width = 100;
            lobPoligono.Stretch = Stretch.Fill;
            lobPoligono.Stroke = Brushes.DarkBlue;
            lobPoligono.Fill = Brushes.White;
            lobPoligono.StrokeThickness = 1;
            //lobPoligono.Margin = new Thickness(150, 50, 0, 0);
            //RotateTransform luxAngulo = new RotateTransform(90,0,0);
            //lobPoligono.RenderTransform = luxAngulo;

            Canvas.SetLeft(lobPoligono, gduCanvasClicPosX);
            Canvas.SetTop(lobPoligono, gduCanvasClicPosY);
            gobRefContenedorZonaSeleccionada.Children.Add(lobPoligono);
        }
        #endregion
        //- organizar indice de Grupos radiobutton y otros...
        #region fcvCmdAddReindexGrupoObjetos: Reorganizar indice de objetos en grupo
        /// <summary>
        /// <para>Reorganizar los indices de los objetos Radibutton  y demas dentro del contenedor</para>
        /// </summary>
        private void fcvCmdAddReindexGrupoObjetos(String tcrNobreObjeto)
        {
            var lnuIndice = 0;
            var llgSiValorDefecto = false;
            var lobObjetoGrupo = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", tcrNobreObjeto).FirstOrDefault();
            var lobTemp = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "PARENT", tcrNobreObjeto);

            foreach (ClassXmlPropObjeto lobReg in lobTemp)
            {
                lnuIndice++;
                lobReg.Indice = lnuIndice.ToString();
                XmlEntorno.SetPropiedadObjeto(lobReg.Name, "Indice", lobReg.Indice);
                if (lobReg.Indice == lobObjetoGrupo.ValorDefault) { llgSiValorDefecto = true; }

            }
            // Actualizr Valordefault para el objeto contenedor
            if (llgSiValorDefecto == false) 
            {
                lobObjetoGrupo.ValorDefault = lnuIndice > 0 ? "1" : "0";
                XmlEntorno.SetPropiedadObjeto(lobObjetoGrupo.Name, "ValorDefault", lobObjetoGrupo.ValorDefault);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // GetObj: ACTIVAR PROPIEDADES AL SELECCIONAR EL OBJETO CON CLICK
        //------------------------------------------------------------
        #region Activar Propiedades al seleccionar objeto con click
        #region fcvGetObjActivarPropiedades: Activar vista propiedades del objeto activo
        /// <summary>
        /// <para>Activar vista propiedades del objeto activo</para>
        /// </summary>
        public void fcvGetObjActivarPropiedades()
        {
            try
            {
                FrameworkElement lobj=null;
                if (guiRefObjetoSeleccionado!=null)
                {
                    lobj = guiRefObjetoSeleccionado as FrameworkElement;
                }
                else if (gobRefPaginaSeleccionada!=null)
                {
                    lobj = gobRefPaginaSeleccionada as FrameworkElement;
                }
                if (lobj != null)
                {
                    fcvGetObjPropiedadVistaModelo(lobj);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvActivarPropiedades");
            }
        }
        #endregion
        #region fcvGetObjPropiedadVistaModelo: Activar Vista Propiedades de objetos
        /// <summary>
        /// <para>Activar Vista Propiedades de objetos en Vista Modelo</para>
        /// </summary>
        private void fcvGetObjPropiedadVistaModelo(FrameworkElement tobObjeto)
        {
            try
            {
                glgModoSetPropiedades = true;
                vm.fcvGridReiniVariables("P");
                vm.fcvGridReiniVariables("I");
                vm.fcvGridReiniVariables("TI");
                var tobProp = XmlEntorno.fobRegSelectParenObjeto("OBJETOS","", tobObjeto.Name).FirstOrDefault();
                vm.tmpComboBoxItems = XmlEntorno.fobRegSelectParenComboBoxItems("PARENT", tobObjeto.Name);
                // Activar Objetos propieades en Ventana
                fcvGetObjPropiedadesVisibleObjeto(tobProp.TipoObjeto);
                #region Propiedades
                // Propiedades Básicas
                vm.PropTxtName               = tobProp.Name;
                vm.PropTxtTitulo             = tobProp.Titulo;
                vm.PropTxtToolTip            = tobProp.ToolTip;
                vm.PropTxtTituloVisible      = tobProp.TituloVisible;
                vm.PropTxtTipoObjeto         = tobProp.TipoObjeto;
                vm.PropTxtClaseBase          = tobProp.ClaseBase;
                vm.PropTxtTipoControl        = tobProp.TipoControl;
                vm.PropTxtSeccionCodigo      = tobProp.SeccionCodigo;
                vm.PropTxtParent             = tobProp.Parent;
                vm.PropTxtOrdenVista         = tobProp.OrdenVista;
                vm.PropTxtTabIndex           = tobProp.TabIndex;
                vm.PropTxtPagina             = tobProp.Pagina;
                vm.PropTxtCambiarTabs        = tobProp.CambiarTabs;
                vm.PropTxtFocusable          = tobProp.Focusable;
                vm.PropTxtIsEnabled          = tobProp.IsEnabled;
                vm.PropTxtVisibility         = tobProp.Visibility;
                // Propiedades Apariencia
                vm.PropTxtVerticalAlignment  = tobProp.VerticalAlignment;
                vm.PropTxtHorizontalAlignment = tobProp.HorizontalAlignment;
                vm.PropTxtStyle              = tobProp.Style;
                vm.PropTxtMargin             = tobProp.Margin;
                vm.PropTxtBorder             = tobProp.Border;
                vm.PropTxtForeground         = tobProp.Foreground;
                vm.PropTxtBorderBrush        = tobProp.BorderBrush;
                vm.PropTxtBackground         = tobProp.Background;
                vm.PropTxtHeight             = tobProp.Height;
                vm.PropTxtWidth              = tobProp.Width;
                vm.PropTxtTop                = tobProp.Top;
                vm.PropTxtLeft               = tobProp.Left;
                vm.PropTxtFontFamily         = tobProp.FontFamily;
                vm.PropTxtFontStyle          = tobProp.FontStyle;
                vm.PropTxtFontWeight         = tobProp.FontWeight;
                vm.PropTxtFontDecorations    = tobProp.Decorations;
                vm.PropTxtFontSize           = tobProp.FontSize;
                vm.PropTxtAlineacionTexto    = tobProp.AlineacionTexto;
                vm.PropTxtOrientacion        = tobProp.Orientacion;
                vm.PropTxtAngulo             = tobProp.Angulo;
                // Propiedades Datos
                vm.PropDatTxtBinding         = tobProp.Binding;
                vm.PropDatTxtBindingTabla    = tobProp.BindingTabla;
                vm.PropDatTxtVariablePublica = tobProp.VariablePublica;
                vm.PropDatTxtVarGestPosVector = tobProp.VarGestPosVector;
                vm.PropDatTxtValorDefault    = tobProp.ValorDefault;
                vm.PropDatTxtTotalItems      = tobProp.TotalItems;
                vm.PropDatTxtTipoDato        = tobProp.TipoDato;
                vm.PropDatTxtTipoOrigenDatos = tobProp.TipoOrigenDatos;
                vm.PropDatTxtTablaOrigen     = tobProp.TablaOrigen;
                vm.PropDatTxtRangoInicial    = tobProp.RangoInicial;
                vm.PropDatTxtRangoFinal      = tobProp.RangoFinal;
                vm.PropArchActualizCodigoArchivo = tobProp.RefVarDatosTipo;
                vm.PropDatTxtSiMultiSet      = tobProp.SiMultiSet;
                vm.PropDatTxtIsReadOnly      = tobProp.IsReadOnly;
                vm.PropDatTxtPrnSiValidar    = tobProp.PrnSiValidar;
                vm.PropDatTxtPrnValorDefault = tobProp.PrnValorDefault;
                vm.PropDatTxtPrnValorPreView  = tobProp.PrnValorPreView;
                vm.PropDatTxtPrnMostrarTitulo = tobProp.PrnMostrarTitulo;
                // -aqui- nuevas variables
                vm.PropArchActualizCodigoCampo  = tobProp.RefVarDatosCampo;
                vm.PropDatTxtIsRequerido        = tobProp.IsRequerido;
                vm.PropDatTxtFechaDefault       = tobProp.FechaDefault;
                vm.PropDatTxtHoraDefault        = tobProp.HoraDefault;
                // Propiedades Imagen, Video y otros archivos
                vm.PropTxtRecursoArchivoTipo     = tobProp.RecursoArchivoTipo;
                vm.PropTxtRecursoArchivoCodigo   = tobProp.RecursoArchivoCodigo;
                vm.PropTxtRecursoArchivoUri      = tobProp.RecursoArchivoUri;
                vm.PropTxtRecursoArchivoNombre   = tobProp.RecursoArchivoNombre;
                vm.PropImgTxtStretch             = tobProp.Stretch;
                vm.PropImgTxtStretchDirection    = tobProp.StretchDirection;
                // Propiedades Varias
                vm.PropTxtSiValorCalculado       = tobProp.SiValorCalculado;
                vm.PropDatTxtNombreVariable      = tobProp.NombreVariable;
                vm.PropDatTxtSiMostrarEnMuro     = tobProp.SiMostrarEnMuro;
                vm.PropDatTxtSiFiltroBusqueda    = tobProp.SiFiltroBusqueda;
                vm.PropDatTxtSiImprimir          = tobProp.SiImprimir;
                // control para validacion Alto,Ancho,Ajuste Izquierda y Ajuste Arriba
                vm.gcrValidPropDistribucion      = "1111"; //Alto,Ancho,Ajuste Izquierda y Ajuste Arriba
                #endregion
                #region Listas ComboBox
                // Activar los combos de color
                cboPropForeground.SelectedColor = String.IsNullOrWhiteSpace(tobProp.Foreground) ? (Color)ColorConverter.ConvertFromString("Black") :
                                                                            (Color)ColorConverter.ConvertFromString(tobProp.Foreground);

                cboPropBorderBrush.SelectedColor = String.IsNullOrWhiteSpace(tobProp.BorderBrush) ? (Color)ColorConverter.ConvertFromString("Black") :
                                                                            (Color)ColorConverter.ConvertFromString(tobProp.BorderBrush);

                cboPropBackground.SelectedColor = String.IsNullOrWhiteSpace(tobProp.Background) ? (Color)ColorConverter.ConvertFromString("Transparent") :
                                                                            (Color)ColorConverter.ConvertFromString(tobProp.Background);
                //- Activar ComboBox de Fuentes y Distribucion
                fcvSetObjValoresDefault();
                // Propiedades campos
                fcvSetObjBrowserCamposArchivoActualizar(tobProp.RefVarDatosCampo);
                // Propiedades Varables publicas
                fcvSetObjVistaVariablesPublicas(tobProp.VariablePublica);

                this.cboPropCboTipoControl.SelectedIndex      = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.TipoControl, vm.PropCboTipoControl);
                this.cboPropCboTituloVisible.SelectedIndex    = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.TituloVisible, vm.PropCboTituloVisible);
                this.cboPropCboIsEnabled.SelectedIndex        = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.IsEnabled, vm.PropCboIsEnabled);
                this.cboPropCboSeccionCodigo.SelectedIndex    = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.SeccionCodigo, vm.PropCboSeccionCodigo);
                this.cboPropCboVisibility.SelectedIndex       = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.Visibility, vm.PropCboVisibility);
                this.cboVerticalAlignment.SelectedIndex       = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.VerticalAlignment, vm.PropCboVerticalAlignment);
                this.cboHorizontalAlignment.SelectedIndex     = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.HorizontalAlignment, vm.PropCboHorizontalAlignment);
                this.cboPropCboBorder.SelectedIndex           = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.Border, vm.PropCboBorder);
                this.cboPropFontFamily.SelectedIndex          = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.FontFamily, vm.PropCboFontFamily);
                this.cboPropCboFontSize.SelectedIndex         = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.FontSize, vm.PropCboFontSize);
                this.cboPropCboAlineacionTexto.SelectedIndex  = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.AlineacionTexto, vm.PropCboAlineacionTexto);
                this.cboPropCboValorDefault.SelectedIndex     = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.ValorDefault, vm.PropCboValorDefault);
                this.cboPropCboTablaOrigen.SelectedIndex      = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.TablaOrigen, vm.PropCboTablaOrigen);
                this.cboPropCboIsRequerido.SelectedIndex      = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.IsRequerido, vm.PropCboIsRequerido);
                this.cboPropCboFechaDefault.SelectedIndex     = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.FechaDefault, vm.PropCboFechaDefault);
                this.cboPropCboHoraDefault.SelectedIndex      = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.HoraDefault, vm.PropCboHoraDefault);
                this.cboPropCboSiValorCalculado.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.SiValorCalculado, vm.PropCboSiValorCalculado);
                this.cboPropCboStretch.SelectedIndex          = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.Stretch, vm.PropCboStretch);
                this.cboPropCboStretchDirection.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.StretchDirection, vm.PropCboStretchDirection);
                this.cboPropCboSiMostrarEnMuro.SelectedIndex  = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.SiMostrarEnMuro, vm.PropCboSiMostrarEnMuro);
                this.cboPropCboSiFiltroBusqueda.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.SiFiltroBusqueda, vm.PropCboSiFiltroBusqueda);
                this.cboPropCboDatosTipo.SelectedIndex        = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.RefVarDatosTipo, vm.PropCboRefVarDatosTipo);
                this.cboPropCboSiMultiSet.SelectedIndex       = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.SiMultiSet, vm.PropCboSiMultiSet);
                this.cboPropCboSiImprimir.SelectedIndex       = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.SiImprimir, vm.PropCboSiImprimir);
                this.cboPropCboIsReadOnly.SelectedIndex       = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.IsReadOnly, vm.PropCboIsReadOnly);
                this.cboPropCboPrnSiValidar.SelectedIndex     = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.PrnSiValidar, vm.PropCboPrnSiValidar);
                this.cboPropCboPrnMostrarTitulo.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.PrnMostrarTitulo, vm.PropCboPrnMostrarTitulo);
                this.cboVarGestPosVector.SelectedIndex        = EdtUtilidades.SetObjetoComboBoxValorDefault(tobProp.VarGestPosVector, vm.PropCboVarGestPosVector);
                
                // -aqui- en el caso que haya mas combos
                #endregion
                #region Listas Varios
                // CheckBox
                chkFuenteNegrita.IsChecked = (tobProp.FontWeight == "Bold") ? true : false;
                chkFuenteCursiva.IsChecked = (tobProp.FontStyle == "Italic") ? true : false;
                // Variable de control del modo
                glgModoSetPropiedades = false;
                #endregion
                //MessageBox.Show("CODIGO " + tobProp.SeccionCodigo);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetPropiedadVistaModelo");
            }
        }
        #endregion
        #region fcvGetObjPropiedadesReSizeObjeto: Actualizar las propiedades al arrastrar objeto
        /// <summary>
        /// <para>Actualizar en Vistamodelo, las propiedades al arrastrar el objeto o ajustar alto y ancho</para>
        /// <para>con el mouse desde las esquinas.</para>
        /// </summary>
        private void fcvGetObjPropiedadesReSizeObjeto()
        {
            if (guiRefObjetoSeleccionado != null)
            {
                var llgSetEstado = glgModoArrastrarObjeto;
                glgModoArrastrarObjeto = true;

                FrameworkElement lobj = guiRefObjetoSeleccionado as FrameworkElement;
                vm.PropTxtHeight = lobj.Height.ToString().Trim();
                vm.PropTxtWidth  = lobj.Width.ToString().Trim();
                vm.PropTxtTop    = Canvas.GetTop(lobj).ToString().Trim();
                vm.PropTxtLeft   = Canvas.GetLeft(lobj).ToString().Trim();
                // Actualizar el entorno
                XmlEntorno.SetPropiedadObjeto(lobj.Name, "Height", vm.PropTxtHeight);
                XmlEntorno.SetPropiedadObjeto(lobj.Name, "Width", vm.PropTxtWidth);
                XmlEntorno.SetPropiedadObjeto(lobj.Name, "Top", vm.PropTxtTop);
                XmlEntorno.SetPropiedadObjeto(lobj.Name, "Left", vm.PropTxtLeft);

                glgModoArrastrarObjeto = llgSetEstado;
            }
        }
        #endregion
        #region fcvGetObjPropiedadesVisibleObjeto: Activa las Propidedades en la Ventana
        /// <summary>
        /// <para>Activa las Propidedades en la Ventana segun el tipo de objeto seleccionado</para>
        /// </summary>
        private void fcvGetObjPropiedadesVisibleObjeto(String tcrTipoObjeto)
        {
            fcvGetObjSetPropiedadesVisibleTodas();
            fcvGetObjSetPropiedadVisibleVentana("GrupoRecursoArchivo", false);
            fcvGetObjSetPropiedadVisibleVentana("PropTipoControl", false);
            fcvGetObjSetPropiedadVisibleVentana("AlineacionTexto", false);
            fcvGetObjSetPropiedadVisibleVentana("TablaOrigen", false);
            fcvGetObjSetPropiedadVisibleVentana("IsRequerido", false);
            fcvGetObjSetPropiedadVisibleVentana("FechaDefault", false);
            fcvGetObjSetPropiedadVisibleVentana("HoraDefault", false);
            fcvGetObjSetPropiedadVisibleVentana("RecursoArchivo", false);
            fcvGetObjSetPropiedadVisibleVentana("txtValorDefault", false);
            fcvGetObjSetPropiedadVisibleVentana("cboValorDefault", false);
            fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", false);
            fcvGetObjSetPropiedadVisibleVentana("SiFiltroBusqueda", false);
            fcvGetObjSetPropiedadVisibleVentana("SiMultiSet", false);
            fcvGetObjSetPropiedadVisibleVentana("IsReadOnly", false);
            fcvGetObjSetPropiedadVisibleVentana("SiImprimir", false);
            fcvGetObjSetPropiedadVisibleVentana("VariablePublica", false);
            fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", false);
            fcvGetObjSetPropiedadVisibleVentana("OrdenVista", false);
            
            #region objetos
            switch (tcrTipoObjeto)
            {
                case "PAGINA":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", true);
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("Foreground", false);
                    fcvGetObjSetPropiedadVisibleVentana("NombreVariable", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("Top", false);
                    fcvGetObjSetPropiedadVisibleVentana("Left", false);
                    fcvGetObjSetPropiedadVisibleVentana("Font", false);
                    fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                    fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                    fcvGetObjSetPropiedadVisibleVentana("Visibility", false);
                    fcvGetObjSetPropiedadVisibleVentana("VerticalAlignment", false);
                    fcvGetObjSetPropiedadVisibleVentana("HorizontalAlignment", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiImprimir", true);
                    break;
                    #endregion

                case "ZONA":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", true);
                    fcvGetObjSetPropiedadVisibleVentana("NombreVariable", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("Top", false);
                    fcvGetObjSetPropiedadVisibleVentana("Left", false);
                    fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                    fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                    fcvGetObjSetPropiedadVisibleVentana("VerticalAlignment", false);
                    fcvGetObjSetPropiedadVisibleVentana("HorizontalAlignment", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiImprimir", true);
                    break;
                    #endregion

                case "TEXTBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiFiltroBusqueda", true);
                    fcvGetObjSetPropiedadVisibleVentana("IsRequerido", true);
                    fcvGetObjSetPropiedadVisibleVentana("AlineacionTexto", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiMultiSet", true);
                    fcvGetObjSetPropiedadVisibleVentana("VariablePublica", true);
                    fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", true);
                    fcvGetObjSetPropiedadVisibleVentana("IsReadOnly", true);
                    fcvGetObjSetPropiedadVisibleVentana("txtValorDefault", true);
                    fcvGetObjSetPropiedadVisibleVentana("OrdenVista", true);
                    break;
                    #endregion

                case "RICHTEXTBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiFiltroBusqueda", true);
                    fcvGetObjSetPropiedadVisibleVentana("IsRequerido", true);
                    fcvGetObjSetPropiedadVisibleVentana("AlineacionTexto", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiMultiSet", true);
                    fcvGetObjSetPropiedadVisibleVentana("VariablePublica", true);
                    fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", true);
                    fcvGetObjSetPropiedadVisibleVentana("IsReadOnly", true);
                    fcvGetObjSetPropiedadVisibleVentana("txtValorDefault", true);
                    fcvGetObjSetPropiedadVisibleVentana("OrdenVista", true);
                    break;
                    #endregion

                case "COMBOBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ValorDefault", true);
                    fcvGetObjSetPropiedadVisibleVentana("cboValorDefault", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiMultiSet", true);
                    fcvGetObjSetPropiedadVisibleVentana("VariablePublica", true);
                    fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", true);
                    fcvGetObjSetPropiedadVisibleVentana("IsReadOnly", true);
                    fcvGetObjSetPropiedadVisibleVentana("OrdenVista", true);
                    break;
                    #endregion

                case "TEXTBOXREL":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("ValorDefault", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("TablaOrigen", true);
                    fcvGetObjSetPropiedadVisibleVentana("IsRequerido", true);
                    fcvGetObjSetPropiedadVisibleVentana("NombreVariable", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("TipoDato", false);
                    fcvGetObjSetPropiedadVisibleVentana("Binding", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiFiltroBusqueda", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiMultiSet", true);
                    break;
                    #endregion

                case "TEXTBOXRELCOD":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", true);
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("IsRequerido", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiMultiSet", true);
                    fcvGetObjSetPropiedadVisibleVentana("VariablePublica", true);
                    fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", true);
                    fcvGetObjSetPropiedadVisibleVentana("IsReadOnly", true);
                    fcvGetObjSetPropiedadVisibleVentana("OrdenVista", true);
                    fcvGetObjSetPropiedadVisibleVentana("SeccionCodigo", false);
                    break;
                    #endregion

                case "TEXTBOXRELDES":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", true);
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("IsRequerido", false);
                    fcvGetObjSetPropiedadVisibleVentana("AlineacionTexto", true);
                    fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", true);
                    fcvGetObjSetPropiedadVisibleVentana("SeccionCodigo", false);
                    break;
                    #endregion

                case "TEXTBLOCK":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    fcvGetObjSetPropiedadVisibleVentana("AlineacionTexto", true);
                    break;
                    #endregion

                case "RADIOBUTTON":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiFiltroBusqueda", true);
                    fcvGetObjSetPropiedadVisibleVentana("SeccionCodigo", false);
                    break;
                    #endregion

                case "CHECKBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ValorDefault", true);
                    fcvGetObjSetPropiedadVisibleVentana("cboValorDefault", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiFiltroBusqueda", true);
                    fcvGetObjSetPropiedadVisibleVentana("VariablePublica", true);
                    fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", true);
                    fcvGetObjSetPropiedadVisibleVentana("IsReadOnly", true);
                    fcvGetObjSetPropiedadVisibleVentana("OrdenVista", true);
                    fcvGetObjSetPropiedadVisibleVentana("SeccionCodigo", false);
                    break;
                    #endregion

                case "BUTTON":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    break;
                    #endregion

                case "GROUPBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                    break;
                    #endregion

                case "MULTIGROUPCHKBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("NombreVariable", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiMultiSet", true);
                    break;
                    #endregion

                case "MULTIGROUPRADIOBUTTON":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ValorDefault", true);
                    fcvGetObjSetPropiedadVisibleVentana("cboValorDefault", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                    fcvGetObjSetPropiedadVisibleVentana("VariablePublica", true);
                    fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", true);
                    fcvGetObjSetPropiedadVisibleVentana("IsReadOnly", true);
                    fcvGetObjSetPropiedadVisibleVentana("OrdenVista", true);
                    break;
                    #endregion

                case "MULTICHKBOX":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("ValorDefault", true);
                    fcvGetObjSetPropiedadVisibleVentana("cboValorDefault", true);
                    fcvGetObjSetPropiedadVisibleVentana("SiFiltroBusqueda", true);
                    fcvGetObjSetPropiedadVisibleVentana("VariablePublica", true);
                    fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", true);
                    fcvGetObjSetPropiedadVisibleVentana("IsReadOnly", true);
                    fcvGetObjSetPropiedadVisibleVentana("OrdenVista", true);
                    fcvGetObjSetPropiedadVisibleVentana("SeccionCodigo", true);

                    break;
                    #endregion

                case "MULTIRADIOBUTTON":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("NombreVariable", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiValorCalculado", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiFiltroBusqueda", true);
                    fcvGetObjSetPropiedadVisibleVentana("SeccionCodigo", false);
                    break;
                    #endregion

                case "CONTROLCAPTURA":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("GrupoRecursoArchivo", false);
                    fcvGetObjSetPropiedadVisibleVentana("RecursoArchivo", false);
                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                    fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                    fcvGetObjSetPropiedadVisibleVentana("Font", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", true);
                    fcvGetObjSetPropiedadVisibleVentana("PropTipoControl", true);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                    fcvGetObjSetPropiedadVisibleVentana("Binding", false);
                    fcvGetObjSetPropiedadVisibleVentana("RefVarDatosTipo", false);
                    fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoInicial", false);
                    fcvGetObjSetPropiedadVisibleVentana("RangoFinal", false);
                    fcvGetObjSetPropiedadVisibleVentana("TipoDato", false);
                    break;
                    #endregion

                case "IMAGEN":
                    #region Propiedades
                    fcvGetObjSetPropiedadVisibleVentana("GrupoRecursoArchivo", true);
                    fcvGetObjSetPropiedadVisibleVentana("RecursoArchivo", true);

                    fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                    fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                    fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                    fcvGetObjSetPropiedadVisibleVentana("Font", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                    fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                    fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                    break;
                    #endregion

                default:
                    #region Propiedades Controles y Figuras
                    if (tcrTipoObjeto == "RECTANGULO" || tcrTipoObjeto == "ELIPSE" || tcrTipoObjeto == "POLYLINE" ||
                        tcrTipoObjeto == "POLYGON" || tcrTipoObjeto == "LINEA-HORIZONTAL" || tcrTipoObjeto == "LINEA-DERECHA" ||
                        tcrTipoObjeto == "LINEA-IZQUIERDA" || tcrTipoObjeto == "FLECHA-DERECHA" || tcrTipoObjeto == "FLECHA-IZQUIERDA" ||
                        tcrTipoObjeto == "FLECHA-ARRIBA" || tcrTipoObjeto == "FLECHA-ABAJO")
                    {
                        fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                        fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                        fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                        fcvGetObjSetPropiedadVisibleVentana("Font", false);
                        fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                        fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
 
                    }
                    else if (tcrTipoObjeto == "CONTROLADMISION" || tcrTipoObjeto == "CONTROLADMITIDO" ||
                            tcrTipoObjeto == "CONTROLUSUATENDIDO" || tcrTipoObjeto == "CONTROLFIRMAPROFESIONAL")
                    {
                        #region Propiedades
                        fcvGetObjSetPropiedadVisibleVentana("GrupoRecursoArchivo", false);
                        fcvGetObjSetPropiedadVisibleVentana("RecursoArchivo", false);
                        fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                        fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                        fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                        fcvGetObjSetPropiedadVisibleVentana("Font", false);
                        fcvGetObjSetPropiedadVisibleVentana("PropDatos", false);
                        fcvGetObjSetPropiedadVisibleVentana("PropVarios", false);
                        fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                        #endregion
                    }
                    else if (tcrTipoObjeto == "CONTROLFRAMINGHAM" || 
                        tcrTipoObjeto == "CONTROLIMC"  ||
                        tcrTipoObjeto == "CONTROLEADAUDICIONLENGUAJE" ||
                        tcrTipoObjeto == "CONTROLEADMOTRICIFINOADAPT" ||
                        tcrTipoObjeto == "CONTROLEADMOTRICIGRUESA" ||
                        tcrTipoObjeto == "CONTROLEADPERSONALSOCIAL" ||
                        tcrTipoObjeto == "CONTROLEADGRAFPUNTUACION")
                    {
                        #region Propiedades
                        fcvGetObjSetPropiedadVisibleVentana("GrupoRecursoArchivo", false);
                        fcvGetObjSetPropiedadVisibleVentana("RecursoArchivo", false);
                        fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                        fcvGetObjSetPropiedadVisibleVentana("Focusable", false);
                        fcvGetObjSetPropiedadVisibleVentana("IsEnabled", false);
                        fcvGetObjSetPropiedadVisibleVentana("Font", false);
                        fcvGetObjSetPropiedadVisibleVentana("PropDatos", true);
                        fcvGetObjSetPropiedadVisibleVentana("PropVarios", true);
                        fcvGetObjSetPropiedadVisibleVentana("NombreVariable", true);
                        fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                        #endregion
                    }
                    else if (tcrTipoObjeto == "TEXTBOXDATE")
                    {
                        #region Propiedades
                        fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                        fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                        fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                        fcvGetObjSetPropiedadVisibleVentana("SiFiltroBusqueda", true);
                        fcvGetObjSetPropiedadVisibleVentana("IsRequerido", true);
                        fcvGetObjSetPropiedadVisibleVentana("FechaDefault", true);
                        fcvGetObjSetPropiedadVisibleVentana("VariablePublica", true);
                        fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", true);
                        fcvGetObjSetPropiedadVisibleVentana("IsReadOnly", true);
                        fcvGetObjSetPropiedadVisibleVentana("txtValorDefault", true);
                        fcvGetObjSetPropiedadVisibleVentana("OrdenVista", true);
                        #endregion
                    }
                    else if (tcrTipoObjeto == "TEXTBOXTIME")
                    {
                        #region Propiedades
                        fcvGetObjSetPropiedadVisibleVentana("TituloVisible", false);
                        fcvGetObjSetPropiedadVisibleVentana("ComboBoxItems", false);
                        fcvGetObjSetPropiedadVisibleVentana("SiMostrarEnMuro", true);
                        fcvGetObjSetPropiedadVisibleVentana("SiFiltroBusqueda", true);
                        fcvGetObjSetPropiedadVisibleVentana("IsRequerido", true);
                        fcvGetObjSetPropiedadVisibleVentana("HoraDefault", true);
                        fcvGetObjSetPropiedadVisibleVentana("VariablePublica", true);
                        fcvGetObjSetPropiedadVisibleVentana("PrnSiValidar", true);
                        fcvGetObjSetPropiedadVisibleVentana("IsReadOnly", true);
                        fcvGetObjSetPropiedadVisibleVentana("txtValorDefault", true);
                        fcvGetObjSetPropiedadVisibleVentana("OrdenVista", true);
                        #endregion
                    }
                    #endregion
                    break;

            }
            #endregion

        }
        #endregion
        #region fcvGetObjSetPropiedadesVisibleTodas: Coloca Visible todas Propidedades en la Ventana
        /// <summary>
        /// <para>Coloca Visible todas Propidedades en la Ventana</para>
        /// </summary>
        private void fcvGetObjSetPropiedadesVisibleTodas()
        {
            #region Propiedades
            //Grupo Datos y Varios  
            this.PropDatos.Visibility               = Visibility.Visible;
            this.PropVarios.Visibility              = Visibility.Visible;
            this.PropArchivoRecurso.Visibility      = Visibility.Visible;

            // Propiedades Basicas           
            this.propTitulo.Visibility              = Visibility.Visible;
            this.propTituloVisible.Visibility       = Visibility.Visible;
            this.propTabIndex.Visibility            = Visibility.Visible;
            this.propFocusable.Visibility           = Visibility.Visible;
            this.propIsEnabled.Visibility           = Visibility.Visible;
            this.propVisibility.Visibility          = Visibility.Visible;
            this.PropOrdenVista.Visibility          = Visibility.Visible;
            this.PropSeccionCodigo.Visibility       = Visibility.Visible;

            // Propiedades Apariencia
            this.propVerticalAlignment.Visibility   = Visibility.Visible;
            this.propHorizontalAlignment.Visibility = Visibility.Visible;
            //this.propStyle.Visibility             = Visibility.Visible;
            //this.propMargin.Visibility            = Visibility.Visible;
            this.propBorder.Visibility              = Visibility.Visible;
            this.propForeground.Visibility          = Visibility.Visible;
            this.propBorderBrush.Visibility         = Visibility.Visible;
            this.propBackground.Visibility          = Visibility.Visible;
            this.propHeight.Visibility              = Visibility.Visible;
            this.propWidth.Visibility               = Visibility.Visible;
            this.propTop.Visibility                 = Visibility.Visible;
            this.propLeft.Visibility                = Visibility.Visible;
            this.propFont.Visibility                = Visibility.Visible;
            this.propAlineacionTexto.Visibility     = Visibility.Visible;
            //this.propFontFamily.Visibility        = Visibility.Visible;
            //this.propFontStyle.Visibility         = Visibility.Visible;
            //this.propFontWeight.Visibility        = Visibility.Visible;
            //this.propDecorations.Visibility       = Visibility.Visible;
            //this.propFontSize.Visibility          = Visibility.Visible;
            //this.propOrientacion.Visibility       = Visibility.Visible;
            //this.propAngulo.Visibility            = Visibility.Visible;

            //Propiedades Datos
            this.propBinding.Visibility             = Visibility.Visible;
            this.propValorDefault.Visibility        = Visibility.Visible;
            this.PropTipoControl.Visibility         = Visibility.Visible;
            this.txtpropValorDefault.Visibility     = Visibility.Visible;
            this.propVariablePublica.Visibility     = Visibility.Visible;
            this.PropPrnSiValidar.Visibility        = Visibility.Visible;
            this.cboPropCboValorDefault.Visibility  = Visibility.Visible;
            this.propComboBoxItems.Visibility       = Visibility.Visible;
            this.propTipoDato.Visibility            = Visibility.Visible;
            this.propIsRequerido.Visibility         = Visibility.Visible;
            this.propFechaDefault.Visibility        = Visibility.Visible;
            this.propHoraDefault.Visibility         = Visibility.Visible;
            this.propTablaOrigen.Visibility         = Visibility.Visible;
            this.propRangoInicial.Visibility        = Visibility.Visible;
            this.propRangoFinal.Visibility          = Visibility.Visible;
            this.propArchivoRecurso.Visibility      = Visibility.Visible;
            this.propRecursoArchivoTipo.Visibility  = Visibility.Visible;
            this.propRecursoArchivoCodigo.Visibility = Visibility.Visible;
            this.propRecursoArchivoUri.Visibility    = Visibility.Visible;
            this.propRecursoArchivoNombre.Visibility = Visibility.Visible;
            this.propRefVarDatosTipo.Visibility      = Visibility.Visible;
            this.propSiMultiSet.Visibility           = Visibility.Visible;
            this.propIsReadOnly.Visibility           = Visibility.Visible;
            
            // Propiedades Varias
            this.propSiValorCalculado.Visibility  = Visibility.Visible;
            this.propNombreVariable.Visibility    = Visibility.Visible;
            this.propSiMostrarEnMuro.Visibility   = Visibility.Visible;
            this.propSiFiltroBusqueda.Visibility  = Visibility.Visible;
            this.propSiImprimir.Visibility        = Visibility.Visible;
            #endregion
        }
        #endregion
        #region fcvGetObjSetPropiedadVisibleVentana: Visualizar u Ocultar la propiedad para un objeto
        /// <summary>
        /// <para>Visualizar u Ocultar la propiedad en la ventana propiedades para un objeto que asi lo requiera</para>
        /// </summary>
        private void fcvGetObjSetPropiedadVisibleVentana(String tcrPropiedad, bool tlgVisible)
        {
            #region Propiedades
            switch (tcrPropiedad.Trim())
            {
                //Grupo Datos y Varios  
                #region Grupo Datos y Varios
                case "PropDatos":
                    this.PropDatos.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "PropVarios":
                    this.PropVarios.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "GrupoRecursoArchivo":
                    this.PropArchivoRecurso.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;
                #endregion
                // Propiedades Basicas
                #region Propiedades Basicas
                case "Titulo":
                    this.propTitulo.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "TituloVisible":
                    this.propTituloVisible.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "TabIndex":
                    this.propTabIndex.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Focusable":
                    this.propFocusable.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "IsEnabled":
                    this.propIsEnabled.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Visibility":
                    this.propVisibility.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "OrdenVista":
                    this.PropOrdenVista.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;
                case "SeccionCodigo":
                    this.PropSeccionCodigo.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;
                    
                #endregion
                // Propiedades Apariencia
                #region Propiedades Apariencia
                case "VerticalAlignment":
                    this.propVerticalAlignment.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "HorizontalAlignment":
                    this.propHorizontalAlignment.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Style":
                    //this.propStyle.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Margin":
                    //this.propMargin.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Border":
                    this.propBorder.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Foreground":
                    this.propForeground.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "BorderBrush":
                    this.propBorderBrush.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Background":
                    this.propBackground.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Height":
                    this.propHeight.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Width":
                    this.propWidth.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Top":
                    this.propTop.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Left":
                    this.propLeft.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Font":
                    this.propFont.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "AlineacionTexto":
                    this.propAlineacionTexto.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "FontFamily":
                    //this.propFontFamily.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "FontStyle":
                    //this.propFontStyle.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "FontWeight":
                    //this.propFontWeight.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Decorations":
                    //this.propDecorations.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "FontSize":
                    //this.propFontSize.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Orientacion":
                    //this.propOrientacion.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "Angulo":
                    //this.propAngulo.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;
                #endregion
                //Propiedades Datos
                #region Propiedades Datos
                case "Binding":
                    this.propBinding.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "ValorDefault":
                    this.propValorDefault.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "txtValorDefault":
                    this.txtpropValorDefault.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "cboValorDefault":
                    this.cboPropCboValorDefault.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "SiMultiSet":
                    this.propSiMultiSet.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "ComboBoxItems":
                    this.propComboBoxItems.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "TipoDato":
                    this.propTipoDato.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "IsRequerido":
                    this.propIsRequerido.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "FechaDefault":
                    this.propFechaDefault.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "HoraDefault":
                    this.propHoraDefault.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "TablaOrigen":
                    this.propTablaOrigen.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "PropTipoControl":
                    this.PropTipoControl.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RangoInicial":
                    this.propRangoInicial.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RangoFinal":
                    this.propRangoFinal.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RecursoArchivo":
                    this.propArchivoRecurso.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RecursoArchivoTipo":
                    this.propRecursoArchivoTipo.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RecursoArchivoCodigo":
                    this.propRecursoArchivoCodigo.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RecursoArchivoUri":
                    this.propRecursoArchivoUri.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RecursoArchivoNombre":
                    this.propRecursoArchivoNombre.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "RefVarDatosTipo":
                    this.propRefVarDatosTipo.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "VariablePublica":
                    this.propVariablePublica.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "PrnSiValidar":
                    this.PropPrnSiValidar.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;
                    
                case "IsReadOnly":
                    this.propIsReadOnly.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                #endregion
                //Propiedades Varias
                #region Propiedades Varias
                case "SiValorCalculado":
                    this.propSiValorCalculado.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "NombreVariable":
                    this.propNombreVariable.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "SiMostrarEnMuro":
                    this.propSiMostrarEnMuro.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "SiFiltroBusqueda":
                    this.propSiFiltroBusqueda.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                case "SiImprimir":
                    this.propSiImprimir.Visibility = tlgVisible == true ? Visibility.Visible : Visibility.Collapsed;
                    break;

                #endregion
            }
            #endregion
        }
        #endregion
        #region fcvGetObjRecursoImportar: Abrir el explorador de windows para buscar una imagen fija
        /// <summary>
        /// <para>Abrir el explorador de windows para buscar una imagen fija</para>
        /// </summary>
        private void fcvGetObjRecursoImportar(object sender, RoutedEventArgs e)
        {
            /*
            var lcrRutayArchivo = String.Empty;
            var lcrRutaGaleria = oApp.gcrAppRecursoInicioPath + @"\" + oApp.gcrAppRecursoPath + @"\Imagenes\Plantillas";
            var lcrRutaDestino = oApp.gcrAppRecursoIpServidor + @"\" + lcrRutaGaleria;
            var lcrNombreArchivo = String.Empty;

            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                lcrRutaDestino = @"\\" + oApp.gcrAppRecursoIpServidor + @"\" + lcrRutaGaleria;
            }
            */
            var lcrRutayArchivo = String.Empty;
            var lcrRutaGaleria = oApp.gcrAppRecursoPath + @"\Imagenes\Plantillas";
            var lcrRutaDestino = oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + lcrRutaGaleria;
            var lcrNombreArchivo = String.Empty;

            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                lcrRutaDestino = @"\\" + oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + lcrRutaGaleria;
            }

            try
            {
                var lobArchivo = EdtUtilidades.fobBuscarArchivoRecurso("Buscar Imagen...", ".jpg", "Buscar imagenes (*.bmp, *.png, *.jpg)|*.bmp;*.png;*.jpg");

                if (lobArchivo != null)
                {
                    lcrRutayArchivo          = lobArchivo.RutayArchivo;
                    lcrNombreArchivo         = "IMG001_" + lobArchivo.NombreArchivo;
                    String lcrArchivoOrigen  = lcrRutayArchivo;
                    String lcrArchivoDestino = lcrRutaDestino + @"\" + lcrNombreArchivo;

                    if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                    {
                        lcrArchivoOrigen = System.IO.Path.Combine(lcrRutayArchivo);
                        lcrArchivoDestino = System.IO.Path.Combine(lcrRutaDestino, lcrNombreArchivo);
                    }

                    if (!File.Exists(lcrArchivoDestino))
                    {
                        System.IO.File.Copy(lcrArchivoOrigen, lcrArchivoDestino, true);
                    }
                    var lobUri = new Uri(lcrArchivoDestino, UriKind.RelativeOrAbsolute);
                    //this.txtPropImgTxtCodigoRecursoImagen.Text = "10";
                    this.txtPropTxtRecursoArchivoTipo.Text = "IMAGEN";
                    this.txtPropTxtRecursoArchivoUri.Text = lcrRutaGaleria;
                    this.txtPropTxtRecursoArchivoNombre.Text = lcrNombreArchivo;

                    var lobImagen = guiRefObjetoSeleccionado as Image;
                    lobImagen.Source = new BitmapImage(lobUri);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGetObjImagenImportar");
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // SetObj: ACTIVAR PROPIEDADES DESDE VENTANA PROPIEDADES
        //------------------------------------------------------------
        #region Activar Propiedades desde Ventana Propiedades
        // Actualizar propiedades objetos
        #region fcvSetObjActualizarTituloObjeto: Actualizar propiedad titulo desde Ventana
        /// <summary>
        /// Actualizar propiedad titulo desde ventana
        /// </summary>
        private void fcvSetObjActualizarTituloObjeto(object sender, TextChangedEventArgs e)
        {
            fcvSetObjPropActualizarTituloObjeto();
        }
        #endregion
        #region fcvSetObjPropActualizarTituloObjeto: Gestion Titulo objeto desde ventana propiedades
        /// <summary>
        /// Gestion Titulo objeto desde ventana propiedades
        /// </summary>
        private void fcvSetObjPropActualizarTituloObjeto()
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && guiRefObjetoSeleccionado != null)
                {
                    if (vm.glgSiValidPropiedadObjeto == true)
                    {
                        var lclTituloObj = new EdtUtilidades.ObjetoTitulo();
                        var lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(guiRefObjetoSeleccionado).ToUpper();

                        lclTituloObj.Titulo         = vm.PropTxtTitulo;
                        lclTituloObj.TituloVisible  = vm.PropTxtTituloVisible;
                        //- Actualizar Entorno
                        XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                         "Titulo", vm.PropTxtTitulo);

                        XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                         "TituloVisible", vm.PropTxtTituloVisible);

                        if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                        {
                            EdtUtilidades.flgSetPropiedadTituloObjeto(guiRefObjetoSeleccionado, lcrclassObjeto, lclTituloObj);
                        }

                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetPropActualizarTituloObjeto");
            }
        }
        #endregion
        #region fcvSetObjActualizarToolTipObjeto: Actualizar propiedad texto de ayuda objeto
        /// <summary>
        /// Actualizar propiedad texto de ayuda objeto
        /// </summary>
        private void fcvSetObjActualizarToolTipObjeto(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && guiRefObjetoSeleccionado != null)
                {
                    var lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(guiRefObjetoSeleccionado).ToUpper();
                    //- Actualizar Entorno
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "ToolTip", vm.PropTxtToolTip);

                    if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                    {
                        EdtUtilidades.flgSetPropiedadToolTipObjeto(guiRefObjetoSeleccionado, lcrclassObjeto, vm.PropTxtToolTip);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjActualizarToolTipObjeto");
            }
        }
        #endregion
        #region fcvSetObjActualizarTabIndex: Actualizar propiedad TabIndex (orden tabulacion objeto)
        /// <summary>
        /// Actualizar propiedad TabIndex (orden tabulacion objeto)
        /// </summary>
        private void fcvSetObjActualizarTabIndex(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && guiRefObjetoSeleccionado != null 
                    && vm.glgSiValidPropiedadObjeto == true)
                {
                    //- Actualizar Entorno
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "TabIndex", vm.PropTxtTabIndex);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjActualizarTabIndex");
            }
        }
        #endregion
        #region fcvSetObjActualizarDistribucionObjeto: Actualizar propiedades Alto, ancho,Left y Top
        /// <summary>
        /// Actualizar propiedades Alto, ancho,Left y Top
        /// </summary>
        private void fcvSetObjActualizarDistribucionObjeto(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && gobRefPaginaSeleccionada != null
                    && vm.glgSiValidPropiedadObjeto == true && glgModoArrastrarObjeto == false)
                {
                    #region
                    var luiObjeto = guiRefObjetoSeleccionado != null ? guiRefObjetoSeleccionado : gobRefPaginaSeleccionada as UIElement;
                    var lobRegProp = XmlEntorno.fobRegSelectParenObjeto("OBJETOS","", ((FrameworkElement)luiObjeto).Name).FirstOrDefault();
                    var lcrclassObjeto = String.Empty;
                    var lclDistribucion = new EdtUtilidades.ObjetoDistribucion();

                    //- Alto y Ancho
                    lclDistribucion.Height = vm.gcrValidPropDistribucion.Substring(0, 1) == "1" ?
                                                            Convert.ToDouble(vm.PropTxtHeight) : Convert.ToDouble(lobRegProp.Height);
                    lclDistribucion.Width = vm.gcrValidPropDistribucion.Substring(1, 1) == "1" ?
                                                            Convert.ToDouble(vm.PropTxtWidth) : Convert.ToDouble(lobRegProp.Width);

                    // Alineacion izquierda y Arriba
                    lclDistribucion.Left = vm.gcrValidPropDistribucion.Substring(2, 1) == "1" ?
                                                            Convert.ToDouble(vm.PropTxtLeft) : Convert.ToDouble(lobRegProp.Left);
                    lclDistribucion.Top = vm.gcrValidPropDistribucion.Substring(3, 1) == "1" ?
                                                            Convert.ToDouble(vm.PropTxtTop) : Convert.ToDouble(lobRegProp.Top);

                    //Actualizar Entorno Xml
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Height", lclDistribucion.Height.ToString().Trim());
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Width", lclDistribucion.Width.ToString().Trim());
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Left", lclDistribucion.Left.ToString().Trim());
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Top", lclDistribucion.Top.ToString().Trim());

                    //Actualizar Objeto
                    lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(luiObjeto).ToUpper();
                    if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                    {
                        EdtUtilidades.flgSetPropiedadDistribucionObjeto(luiObjeto, lobRegProp, lclDistribucion);
                        // si es una pagina Ajustar el contenedor
                        if (lobRegProp.TipoObjeto == "PAGINA")
                        {
                            var lobPagina = luiObjeto as Canvas;
                            var lobConte = lobRegProp.RefContenedorObjeto as WrapPanel;
                            XmlEntorno.SetPropiedadMargenContenedorPagina(ref lobPagina, ref lobConte);
                            if (lclDistribucion.Width > XmlEntorno.gduMinimoAnchoPlantilla)
                            {
                                XmlEntorno.gduMinimoAnchoPlantilla = lclDistribucion.Width;
                                this.objReglaHorizontal.Width = XmlEntorno.gduMinimoAnchoPlantilla + 120;
                            }

                        }
                    }
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvActualizarTituloObjeto");
            }
        }
        #endregion
        #region fcvSetObjSeleccionComboBoxPropiedadPlant: Actualizar propiedades al seleccionar CombBox para plantillas
        /// <summary>
        /// Actualizar propiedades al seleccionar CombBox para plantillas
        /// </summary>
        private void fcvSetObjSeleccionComboBoxPropiedadPlant(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //- Verificar ecepcion para objetos pagina y combobox puntuales
                if (glgObjetosCargados == true && glgModoSetPropiedades == false)
                {
                    ComboBox lobCombo = (ComboBox)sender;
                    VistaModeloObjetoActivo.ListaXmlValores lobList = (VistaModeloObjetoActivo.ListaXmlValores)e.AddedItems[0];

                    switch (lobCombo.Name)
                    {
                        case "cboPropCboPlantTipoImpresion":
                            this.txtPlantTipoImpresion.Text = lobList.Codigo;
                            XmlEntorno.gcrPlantillaTipoImpresion = lobList.Codigo;
                            //XmlEntorno.SetPropiedadPlantilla(this.txtPlantCodigo.Text, "PlantTipoImpresion", lobList.Codigo);
                            break;

                        case "cboPropCboPlantTipoHojaReporte":
                            this.txtPlantTipoHojaReporte.Text = lobList.Codigo;
                            XmlEntorno.gcrPlantillaTipoHojaReporte = lobList.Codigo;
                            //XmlEntorno.SetPropiedadPlantilla(this.txtPlantCodigo.Text, "PlantTipoHojaReporte", lobList.Codigo);
                            break;

                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjSeleccionComboBoxPropiedadPlant");
            }
        }
        #endregion
        #region fcvSetObjSeleccionComboBoxPropiedad: Actualizar propiedades al seleccionar desde CombBox
        /// <summary>
        /// Actualizar las propiedades al seleccionar desde CombBox
        /// </summary>
        private void fcvSetObjSeleccionComboBoxPropiedad(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //- Verificar ecepcion para objetos pagina y combobox puntuales
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && guiRefObjetoSeleccionado == null)
                {
                    if (gobRefPaginaSeleccionada != null)
                    {
                        ComboBox lobCombo = (ComboBox)sender;
                        if (lobCombo.Name == "cboPropCboSiImprimir" || lobCombo.Name == "cboPropCboSiMostrarEnMuro")
                        {
                            guiRefObjetoSeleccionado = gobRefPaginaSeleccionada;
                        }
                    }
                }

                // Validacio de objetos para cambiar propiedades desde combobox
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && guiRefObjetoSeleccionado != null)
                {
                    //MessageBox.Show("CAMBIA AQUI");

                    ComboBox lobCombo = (ComboBox)sender;
                    var lcrCodigo = String.Empty;

                    if (gcrCtrF2TexBox == "PropDatTxtVariablePublica")
                    {
                        lcrCodigo = "0";
                        gcrCtrF2TexBox = String.Empty;
                        this.cboVarGestPosVector.SelectedIndex = 0;
                    }
                    else
                    {
                        VistaModeloObjetoActivo.ListaXmlValores lobList = (VistaModeloObjetoActivo.ListaXmlValores)e.AddedItems[0];
                        lcrCodigo = lobList.Codigo;
                    }

                    #region Propiedades
                    switch (lobCombo.Name)
                    {
                        case "cboPropCboTipoControl":
                            vm.PropTxtTipoControl = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "TipoControl", vm.PropTxtTipoControl);
                            break;

                        case "cboPropCboSeccionCodigo":
                            vm.PropTxtSeccionCodigo = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "SeccionCodigo", vm.PropTxtSeccionCodigo);
                            break;

                        case "cboPropCboTituloVisible":
                            vm.PropTxtTituloVisible = lcrCodigo;
                            vm.glgSiValidPropiedadObjeto = true;
                            fcvSetObjPropActualizarTituloObjeto();
                            break;

                        case "cboPropCboIsEnabled":
                            vm.PropTxtIsEnabled = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "IsEnabled", vm.PropTxtIsEnabled);
                            break;

                        case "cboPropCboVisibility":
                            vm.PropTxtVisibility = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "Visibility", vm.PropTxtVisibility);
                            break;

                        case "cboPropCboBorder":
                            vm.PropTxtBorder = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "Border", vm.PropTxtBorder);
                            fcvSetObjComboBoxSelectBorder();
                            break;

                        case "cboVerticalAlignment":
                            vm.PropTxtVerticalAlignment = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "VerticalAlignment", vm.PropTxtVerticalAlignment);
                            break;

                        case "cboHorizontalAlignment":
                            vm.PropTxtHorizontalAlignment = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "HorizontalAlignment", vm.PropTxtHorizontalAlignment);
                            break;

                        case "cboPropFontFamily":
                            fcvSetObjFuenteVentanaPropToVistaModelo();
                            fcvSetObjComboBoxSelectPropiedadFuente();
                            break;

                        case "cboPropCboFontSize":
                            fcvSetObjFuenteVentanaPropToVistaModelo();
                            fcvSetObjComboBoxSelectPropiedadFuente();
                            break;

                        case "cboPropCboAlineacionTexto":
                            vm.PropTxtAlineacionTexto = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "AlineacionTexto", vm.PropTxtAlineacionTexto);
                            fcvSetObjComboBoxSelectAlineacionTexto();
                            break;

                        case "cboPropCboValorDefault":
                            if (lobCombo.Visibility == Visibility.Visible)
                            {
                                vm.PropDatTxtValorDefault = lcrCodigo;
                                XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                                 "ValorDefault", vm.PropDatTxtValorDefault);
                            }
                            break;

                        case "cboPropCboSiValorCalculado":
                            vm.PropTxtSiValorCalculado = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "SiValorCalculado", vm.PropTxtSiValorCalculado);
                            break;

                        case "cboPropCboStretch":
                            vm.PropImgTxtStretch = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "Stretch", vm.PropImgTxtStretch);

                            EdtUtilidades.flgSetPropiedadStretch(guiRefObjetoSeleccionado, vm.PropImgTxtStretch, vm.PropImgTxtStretchDirection);
                            break;

                        case "cboPropCboStretchDirection":
                            vm.PropImgTxtStretchDirection = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "StretchDirection", vm.PropImgTxtStretchDirection);

                            EdtUtilidades.flgSetPropiedadStretch(guiRefObjetoSeleccionado, vm.PropImgTxtStretch, vm.PropImgTxtStretchDirection);
                            break;

                        case "cboPropCboTablaOrigen":
                            vm.PropDatTxtTablaOrigen = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "TablaOrigen", vm.PropDatTxtTablaOrigen);
                            break;

                        case "cboPropCboIsRequerido":
                            vm.PropDatTxtIsRequerido = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "IsRequerido", vm.PropDatTxtIsRequerido);
                            break;

                        case "cboPropCboFechaDefault":
                            vm.PropDatTxtFechaDefault = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "FechaDefault", vm.PropDatTxtFechaDefault);
                            break;

                        case "cboPropCboHoraDefault":
                            vm.PropDatTxtHoraDefault = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "HoraDefault", vm.PropDatTxtHoraDefault);
                            break;


                        case "cboPropCboSiMostrarEnMuro":
                            vm.PropDatTxtSiMostrarEnMuro = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "SiMostrarEnMuro", vm.PropDatTxtSiMostrarEnMuro);
                            break;

                        case "cboPropCboSiMultiSet":
                            vm.PropDatTxtSiMultiSet = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "SiMultiSet", vm.PropDatTxtSiMultiSet);
                            break;

                        case "cboPropCboSiImprimir":
                            vm.PropDatTxtSiImprimir = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "SiImprimir", vm.PropDatTxtSiImprimir);
                            break;

                        case "cboPropCboSiFiltroBusqueda":
                            vm.PropDatTxtSiFiltroBusqueda = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "SiFiltroBusqueda", vm.PropDatTxtSiFiltroBusqueda);
                            break;

                        case "cboPropCboIsReadOnly":
                            vm.PropDatTxtIsReadOnly = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "IsReadOnly", vm.PropDatTxtIsReadOnly);
                            break;

                        case "cboPropCboDatosTipo":
                            if (vm.PropArchActualizCodigoArchivo != lcrCodigo)
                            {
                                // -aqui- agregar nuevos campos a funcion limpiar
                                fcvSetObjBrowserCamposArchivoActualizar("NA");
                            }
                            vm.PropArchActualizCodigoArchivo = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RefVarDatosTipo", vm.PropArchActualizCodigoArchivo);

                            break;

                        case "cboPropCboSeccionDefault":
                            vm.PropTxtSeccionDefault = lcrCodigo;
                            XmlEntorno.gcrSeccionDefault = lcrCodigo;
                            break;

                        case "cboPropCboPrnSiValidar":
                            vm.PropDatTxtPrnSiValidar = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "PrnSiValidar", vm.PropDatTxtPrnSiValidar);
                            break;

                        case "cboPropCboPrnMostrarTitulo":
                            vm.PropDatTxtPrnMostrarTitulo = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "PrnMostrarTitulo", vm.PropDatTxtPrnMostrarTitulo);
                            break;

                        case "cboVarGestPosVector":
                            vm.PropDatTxtVarGestPosVector = lcrCodigo;
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "VarGestPosVector", vm.PropDatTxtVarGestPosVector);
                            break;

                    }
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjSeleccionComboBoxPropiedad");
            }
        }
        #endregion
        #region fcvSetObjComboBoxSelectBorder: Seleccionar propiedad Border (grosor)
        /// <summary>
        /// Seleccionar propiedad Border (grosor)
        /// </summary>
        private void fcvSetObjComboBoxSelectBorder()
        {
            if (guiRefObjetoSeleccionado != null)
            {
                var lcrclassObjeto = String.Empty;
                lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(guiRefObjetoSeleccionado).ToUpper();
                if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                {
                    EdtUtilidades.flgSetPropiedadBorderObjeto(guiRefObjetoSeleccionado, lcrclassObjeto, vm.PropTxtBorder);
                }
            }
        }
        #endregion
        #region fcvSetObjComboBoxSelectAlineacionTexto: Seleccionar propiedad Alineacion del texto
        /// <summary>
        /// Activar propiedad Alineacion del texto para el objeto seleccionado
        /// </summary>
        private void fcvSetObjComboBoxSelectAlineacionTexto()
        {
            if (guiRefObjetoSeleccionado != null)
            {
                var lcrclassObjeto = String.Empty;
                lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(guiRefObjetoSeleccionado).ToUpper();
                if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                {
                    EdtUtilidades.flgSetPropiedadAlineacionTexto(guiRefObjetoSeleccionado, lcrclassObjeto, vm.PropTxtAlineacionTexto);
                }
            }
        }
        #endregion
        #region fcvSetObjSeleccionPropiedadColor: Gestion seleccion color de objeto activo desde ventana
        /// <summary>
        /// Seleccion las propiedades de color desde ventana propiedades
        /// </summary>
        private void fcvSetObjSeleccionPropiedadColor(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            if (glgModoSetPropiedades == false)
            {
                //var luiObjeto = new UIElement();
                var luiObjeto = guiRefObjetoSeleccionado != null ? guiRefObjetoSeleccionado : gobRefPaginaSeleccionada as UIElement;
                 

                var lcrclassObjeto=String.Empty;
                var lclColorObj = new EdtUtilidades.ObjetoPropiedadColor();

                lclColorObj.Fuente = cboPropForeground.SelectedColor;
                lclColorObj.Fondo = cboPropBackground.SelectedColor;
                lclColorObj.Bordes = cboPropBorderBrush.SelectedColor;
                // Actualizar Vista modelo
                vm.PropTxtForeground = lclColorObj.Fuente.ToString(); 
                vm.PropTxtBorderBrush = lclColorObj.Bordes.ToString();   
                vm.PropTxtBackground = lclColorObj.Fondo.ToString();     
                //Actualizar Entorno Xml
                XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Foreground", vm.PropTxtForeground);
                XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "BorderBrush", vm.PropTxtBorderBrush);
                XmlEntorno.SetPropiedadObjeto(((FrameworkElement)luiObjeto).Name, "Background", vm.PropTxtBackground);

                lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(luiObjeto).ToUpper();
                if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                {
                    EdtUtilidades.flgSetPropiedadColorObjeto(luiObjeto, lcrclassObjeto, lclColorObj);
                    if (lcrclassObjeto == "GROUPBOX" || lcrclassObjeto == "CANVAS" || lcrclassObjeto == "WRAPPANEL")
                    {
                        if (gcrTipoObjetoNivel == "PAGINA")
                        {
                            gobRefContenedorPaginaSeleccionada.Background = Brushes.Transparent;
                        }
                        if (gcrTipoObjetoNivel == "ZONA")
                        {
                            gobRefContenedorZonaSeleccionada.Background = Brushes.Transparent;
                        }
                        else if (gcrTipoObjetoNivel == "GRUPO")
                        {
                            gobRefContenedorGrupoSeleccionado.Background = Brushes.Transparent;
                        }
                    }
                }
            }
        }
        #endregion
        #region fcvSetObjSeleccionListViewPropiedad: Actualizar propiedades al seleccionar desde listView
        /// <summary>
        /// <para>Actualizar en VistaModelo campos y registro activo  para item ComboBox y Etiquetas desde listView</para>
        /// </summary>
        private void fcvSetObjSeleccionListViewPropiedad(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false)
                {
                    ListView lobListView = (ListView)sender;

                    switch (lobListView.Name)
                    {
                        case "lstComboItems":
                            if (guiRefObjetoSeleccionado != null)
                            {
                                XmlEntorno.ClassXmlComboBoxItems lobLista = (XmlEntorno.ClassXmlComboBoxItems)e.AddedItems[0];
                                vm.regComboBoxItems = lobLista;
                                vm.fcvGridCargarVariablesDesdeRegActivo("I");
                            }
                            break;

                        case "lstComboEtiquetas":
                            XmlEntorno.ClassXmlItemEtiquetas lobEtiq = (XmlEntorno.ClassXmlItemEtiquetas)e.AddedItems[0];
                            vm.regEtiquetaItems = lobEtiq;
                            vm.fcvGridCargarVariablesDesdeRegActivo("E");
                            break;

                        case "lstViewSecciones":
                            XmlEntorno.ClassXmlComboBoxItems lobSeccion = (XmlEntorno.ClassXmlComboBoxItems)e.AddedItems[0];
                            vm.regSeccion = lobSeccion;
                            vm.fcvGridCargarVariablesDesdeRegActivo("S");
                            break;

                        case "lstComboImgPredef":
                            XmlEntorno.ClassXmlImgPredefinidas lobImg = (XmlEntorno.ClassXmlImgPredefinidas)e.AddedItems[0];
                            vm.regImgPredefItems = lobImg;
                            this.txtGaleriaImgRutaOrigen.Text = String.Empty;
                            this.txtGaleriaImgRutaDestino.Text = String.Empty;
                            vm.fcvGridCargarVariablesDesdeRegActivo("G");

                            var lobUri = new EdtUtilidades.ObjetoBitmapImage();
                            lobUri.AppIpServidor    = oApp.gcrAppRecursoIpServidor;
                            lobUri.AppInicioPath    = oApp.gcrAppRecursoInicioPath;
                            lobUri.RutaGaleria      = vm.PropGalTxtRecursoArchivoUri;
                            lobUri.NombreArchivo    = vm.PropGalTxtRecursoArchivoNombre;
                            this.imgImagenPredefinida.Source = EdtUtilidades.SetBitmapImageUri(lobUri);
                            break;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjSeleccionListViewPropiedad");
            }
        }
        #endregion
        #region fcvSetObjNotifCambioListView: Actualizar los ListView por cambios en Vista Modelo
        /// <summary>
        /// <para>Actualizar los temporales que estan enlazados a los ListView por cambios en vista modelo</para>
        /// </summary>
        private void fcvSetObjNotifCambioListView(object sender, TextChangedEventArgs e)
        {
            if (glgObjetosCargados == true && glgModoSetPropiedades == false)
            {
                glgModoSetPropiedades = true;

                //- Cambios en temporal para lista opciones objetos ComboBox 
                if (vm.PropNotifCambioListView.Contains("COMBOBOX") && vm.PropTxtTipoObjeto.ToUpper() == "COMBOBOX")
                {
                    vm.PropNotifCambioListView = String.Empty; // Resetiar para que este atento de nuevo

                    if (XmlEntorno.flgEliminarParenComboBoxItems(vm.PropTxtName))
                    {
                        fcvSetObjAdicionarRegComboBoxItems();
                        vm.tmpComboBoxItems = XmlEntorno.fobRegSelectParenComboBoxItems("PARENT", vm.PropTxtName);
                        fcvSetObjValoresDefault();
                    }
                }

                //- Cambios en temporal para lista etiquetas
                if (vm.PropNotifCambioListView.Contains("ETIQUETAS"))
                {
                    vm.PropNotifCambioListView = String.Empty; // Resetiar para que este atento de nuevo
                    XmlEntorno.tmpEtiquetas = new List<XmlEntorno.ClassXmlItemEtiquetas>();
                    XmlEntorno.tmpEtiquetas = vm.tmpEtiquetaItems;

                    vm.tmpEtiquetaItems = new List<XmlEntorno.ClassXmlItemEtiquetas>();
                    vm.tmpEtiquetaItems = XmlEntorno.tmpEtiquetas;
                }

                //- Cambios en temporal para Secciones
                if (vm.PropNotifCambioListView.Contains("SECCION"))
                {
                    var lcrAccion = vm.PropNotifCambioListView;
                    vm.PropNotifCambioListView = String.Empty; // Resetiar para que este atento de nuevo
                    XmlEntorno.tmpSecciones = new List<XmlEntorno.ClassXmlComboBoxItems>();
                    XmlEntorno.tmpSecciones = vm.tmpSecciones;

                    vm.tmpSecciones = new List<XmlEntorno.ClassXmlComboBoxItems>();
                    vm.tmpSecciones = XmlEntorno.tmpSecciones;
                    fcvSetSeccionesDefault();

                    // Revisar y reasignar Seccion a objetos, si esta fue eliminada
                    if (lcrAccion == "SECCION-DEL")
                    {
                        fcvSetReAsignarSeccionesDefault();
                    }
                }

                //- Cambios en temporal para lista imagenes predefinidas
                if (vm.PropNotifCambioListView.Contains("IMG-PREDEF"))
                {
                    vm.PropNotifCambioListView = String.Empty; // Resetiar para que este atento de nuevo
                    XmlEntorno.tmpImagenesPredef = new List<XmlEntorno.ClassXmlImgPredefinidas>();
                    XmlEntorno.tmpImagenesPredef = vm.tmpImgPredefItems;

                    vm.tmpImgPredefItems = new List<XmlEntorno.ClassXmlImgPredefinidas>();
                    vm.tmpImgPredefItems = XmlEntorno.tmpImagenesPredef;
                }
                glgModoSetPropiedades = false;
            }
        }
        #endregion
        #region fcvSetObjAdicionarRegComboBoxItems: Adicionar registros
        /// <summary>
        /// <para>Adicionar registros de lista de Items para ComboBox</para>
        /// </summary>
        public void fcvSetObjAdicionarRegComboBoxItems()
        {
            foreach (XmlEntorno.ClassXmlComboBoxItems lobReg in vm.tmpComboBoxItems)
            {
                XmlEntorno.tmpComboItems.Add(lobReg);
            }
        }
        #endregion
        #region fcvSetObjValoresDefault: Actualizar lista valor por defecto ComboBox CheckBox y Radibutton
        /// <summary>
        /// <para>Actualizar lista valor por defecto ComboBox CheckBox, Radibutton y secciones del formato</para>
        /// </summary>
        public void fcvSetObjValoresDefault()
        {
            var llgAccion = false;
            vm.PropCboValorDefault = new List<VistaModeloObjetoActivo.ListaXmlValores>();
            var lobRegx = new VistaModeloObjetoActivo.ListaXmlValores();
            switch (vm.PropTxtTipoObjeto)
            {
                case "COMBOBOX":
                    llgAccion = true;
                    foreach (XmlEntorno.ClassXmlComboBoxItems lobReg in vm.tmpComboBoxItems)
                    {
                        lobRegx = new VistaModeloObjetoActivo.ListaXmlValores();
                        lobRegx.Indice = lobReg.Indice;
                        lobRegx.Codigo = lobReg.Codigo;
                        lobRegx.Descripcion = lobReg.Descripcion;
                        vm.PropCboValorDefault.Add(lobRegx);
                    }
                    break;

                case "MULTIGROUPRADIOBUTTON":
                    llgAccion = true;
                    var lobTemp = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "PARENT", vm.PropTxtName);

                    foreach (ClassXmlPropObjeto lobReg in lobTemp)
                    {
                        lobRegx = new VistaModeloObjetoActivo.ListaXmlValores();
                        lobRegx.Indice = lobReg.Indice;
                        lobRegx.Codigo = lobReg.Indice;
                        lobRegx.Descripcion = lobReg.Titulo;
                        vm.PropCboValorDefault.Add(lobRegx);
                    }
                    break;

                case "MULTICHKBOX":
                    llgAccion = true;
                    lobRegx = new VistaModeloObjetoActivo.ListaXmlValores();
                    lobRegx.Indice = "1";
                    lobRegx.Codigo = "False";
                    lobRegx.Descripcion = "No seleccionado";
                    vm.PropCboValorDefault.Add(lobRegx);

                    lobRegx = new VistaModeloObjetoActivo.ListaXmlValores();
                    lobRegx.Indice = "2";
                    lobRegx.Codigo = "True";
                    lobRegx.Descripcion = "Seleccionado";
                    vm.PropCboValorDefault.Add(lobRegx);
                    break;

            }
            if (llgAccion == true)
            {
                cboPropCboValorDefault.ItemsSource = null;
                cboPropCboValorDefault.ItemsSource = vm.PropCboValorDefault;
                vm.PropDatTxtValorDefault = EdtUtilidades.SetRealListaValorDefault("CODIGO", vm.PropDatTxtValorDefault, vm.PropCboValorDefault);

                if (guiRefObjetoSeleccionado != null)
                {
                    XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "ValorDefault", vm.PropDatTxtValorDefault);
                    cboPropCboValorDefault.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(vm.PropDatTxtValorDefault, vm.PropCboValorDefault);
                }
            }
        }
        #endregion
        #region fcvSetSeccionesDefault: Actualizar lista secciones por defecto
        /// <summary>
        /// <para>Actualizar lista valor por defecto Secciones</para>
        /// </summary>
        public void fcvSetSeccionesDefault()
        {
            this.cboPropCboSeccionCodigo.ItemsSource = null;
            this.cboPropCboSeccionDefault.ItemsSource = null;

            vm.PropCboSeccionCodigo = new List<VistaModeloObjetoActivo.ListaXmlValores>();
            var lobRegx = new VistaModeloObjetoActivo.ListaXmlValores();
            foreach (XmlEntorno.ClassXmlComboBoxItems lobReg in vm.tmpSecciones)
            {
                lobRegx = new VistaModeloObjetoActivo.ListaXmlValores();
                lobRegx.Indice = lobReg.Indice;
                lobRegx.Codigo = lobReg.Codigo;
                lobRegx.Descripcion = lobReg.Descripcion;
                vm.PropCboSeccionCodigo.Add(lobRegx);
            }
            vm.PropCboSeccionCodigo = (from tmp in vm.PropCboSeccionCodigo orderby tmp.Codigo select tmp).ToList();

            this.cboPropCboSeccionDefault.ItemsSource = vm.PropCboSeccionCodigo;
            this.cboPropCboSeccionCodigo.ItemsSource = vm.PropCboSeccionCodigo;

            vm.PropTxtSeccionDefault = EdtUtilidades.SetRealListaValorDefault("CODIGO", vm.PropTxtSeccionDefault, vm.PropCboSeccionCodigo);
            vm.PropTxtSeccionCodigo = EdtUtilidades.SetRealListaValorDefault("CODIGO", vm.PropTxtSeccionCodigo, vm.PropCboSeccionCodigo);
            this.cboPropCboSeccionDefault.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(vm.PropTxtSeccionDefault, vm.PropCboSeccionCodigo);

            if (guiRefObjetoSeleccionado != null)
            {
                XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "SeccionCodigo", vm.PropTxtSeccionCodigo);
                this.cboPropCboSeccionCodigo.SelectedIndex = EdtUtilidades.SetObjetoComboBoxValorDefault(vm.PropTxtSeccionCodigo, vm.PropCboSeccionCodigo);
            }
        }
        #endregion
        #region fcvSetReAsignarSeccionesDefault: Reasignar y o actualizar secciones cuando se ha eliminado alguna
        /// <summary>
        /// <para>Re-asignar y/o actualizar secciones cuando se ha eliminado alguna, para los objetos</para>
        /// <para>que posiblemente ya la seccion no exista.</para>
        /// <para>cuando no existe la seccion del objeto, este toma la seccion por defecto</para>
        /// </summary>
        public void fcvSetReAsignarSeccionesDefault()
        {
            if (XmlEntorno.tmpObjetos != null)
            {
                foreach (var lobReg in XmlEntorno.tmpObjetos)
                {
                    var lobAux = vm.tmpSecciones.FirstOrDefault(x => x.Codigo == lobReg.SeccionCodigo);
                    if (lobAux == null)
                    {
                        lobReg.SeccionCodigo = vm.PropTxtSeccionDefault;
                    }
                }
            }
        }
        #endregion
        #region Gestion del tipo Fuente
        #region fcvSetObjChkFuente: Leer Estilo de la fuente desde los checkbox en Ventana propiedades
        /// <summary>
        /// Leer Estilo de la fuente desde los chkbox en Ventana propiedades
        /// </summary>
        private void fcvSetObjChkFuente(object sender, RoutedEventArgs e)
        {
            if (glgObjetosCargados == true && glgModoSetPropiedades == false)
            {
                fcvSetObjFuenteVentanaPropToVistaModelo();
                fcvSetObjComboBoxSelectPropiedadFuente();
            }
        }
        #endregion
        #region fcvSetObjComboBoxSelectPropiedadFuente: Seleccionar propiedad fuente (texto)
        /// <summary>
        /// Seleccionar propiedad fuente (texto)
        /// </summary>
        private void fcvSetObjComboBoxSelectPropiedadFuente()
        {
            if (guiRefObjetoSeleccionado != null)
            {
                var lcrclassObjeto=String.Empty;
                var lclFontObj = fobSetObjFuenteVentanaPropToClass();
                lcrclassObjeto = EdtUtilidades.fcrGetClassBaseObjeto(guiRefObjetoSeleccionado).ToUpper();
                if (!String.IsNullOrWhiteSpace(lcrclassObjeto))
                {
                    EdtUtilidades.flgSetPropiedadFuenteObjeto(guiRefObjetoSeleccionado, lcrclassObjeto, lclFontObj);
                }
            }
        }
        #endregion
        #region fcvSetObjFuenteVentanaPropToVistaModelo: Leer Propiedades de fuente desde la ventana Propiedades y actualizar Vista Modelo
        /// <summary>
        /// Leer Propiedades de fuente desde la ventana Propiedades y actualizar Vista Modelo
        /// </summary>
        private void fcvSetObjFuenteVentanaPropToVistaModelo()
        {
            var lclFontObj = fobSetObjFuenteVentanaPropToClass();
            if (lclFontObj != null)
            {
                vm.PropTxtFontFamily = lclFontObj.FontFamily.ToString();
                vm.PropTxtFontSize = lclFontObj.FontSize.ToString();
                vm.PropTxtFontWeight = lclFontObj.FontWeight == FontWeights.Bold ? "Bold" : "Regular";
                vm.PropTxtFontStyle = lclFontObj.FontStyle == FontStyles.Italic ? "Italic" : "Normal";
                fcvSetObjPropiedadXmlEntornoFont();
            }
        }
        #endregion
        #region fcvSetObjPropiedadXmlEntornoFont: Actualizar las propiedades de Font en temporal XmlEntorno
        /// <summary>
        /// Actualizar las propiedades de Font en temporal XmlEntorno
        /// </summary>
        private void fcvSetObjPropiedadXmlEntornoFont()
        {
            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "FontFamily", vm.PropTxtFontFamily);
            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "FontStyle", vm.PropTxtFontStyle);
            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "FontSize", vm.PropTxtFontSize);
            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name, "FontWeight", vm.PropTxtFontWeight);
        }
        #endregion
        #region fobSetObjFuenteVentanaPropToClass: Lee Propiedades fuente desde ventana Propiedades y devuelve class ObjetoPropiedadFont
        /// <summary>
        /// Lee Propiedades fuente desde ventana Propiedades y devuelve class ObjetoPropiedadFont
        /// </summary>
        private EdtUtilidades.ObjetoPropiedadFont fobSetObjFuenteVentanaPropToClass()
        {
            VistaModeloObjetoActivo.ListaXmlValores lobListFontFamily = (VistaModeloObjetoActivo.ListaXmlValores)cboPropFontFamily.SelectedItem;
            VistaModeloObjetoActivo.ListaXmlValores lobListFontSize = (VistaModeloObjetoActivo.ListaXmlValores)cboPropCboFontSize.SelectedItem;

            var lclFontObj = new EdtUtilidades.ObjetoPropiedadFont();
            // Atributos de la fuente
            if (lobListFontFamily != null && lobListFontSize != null)
            {
                lclFontObj.FontFamily = new FontFamily(lobListFontFamily.Codigo);
                lclFontObj.FontSize = Convert.ToDouble(lobListFontSize.Codigo);
                lclFontObj.FontWeight = chkFuenteNegrita.IsChecked == true ? FontWeights.Bold : FontWeights.Regular;
                lclFontObj.FontStyle = chkFuenteCursiva.IsChecked == true ? FontStyles.Italic : FontStyles.Normal;
            }
            else
            { 
                lclFontObj = null; 
            }
            return lclFontObj;
        }
        #endregion
        #endregion
        #region fcvSetObjPropDatosActualizar: Actualizar Propiedades de Grupo Datos y otras
        /// <summary>
        /// <para>Actualizar Propiedades del grupo Datos y otras desde la ventaa propiedades</para>
        /// </summary>
        private void fcvSetObjPropDatosActualizar(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && guiRefObjetoSeleccionado != null)
                {
                    TextBox lobObjeto = (TextBox)sender;

                    switch (lobObjeto.Name)
                    {
                        case "txtpropValorDefault":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "ValorDefault", vm.PropDatTxtValorDefault);
                            break;

                        case "txtPropTxtOrdenVista":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "OrdenVista", vm.PropTxtOrdenVista);
                            break;

                        case "txtPropDatTxtRangoInicial":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RangoInicial", vm.PropDatTxtRangoInicial);
                            break;

                        case "txtPropDatTxtRangoFinal":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RangoFinal", vm.PropDatTxtRangoFinal);
                            break;

                        case "txtPropDatTxtNombreVariable":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "NombreVariable", vm.PropDatTxtNombreVariable);
                            break;

                        case "txtPropTxtRecursoArchivoTipo":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RecursoArchivoTipo", vm.PropTxtRecursoArchivoTipo);
                            break;

                        case "txtPropTxtRecursoArchivoCodigo":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RecursoArchivoCodigo", vm.PropTxtRecursoArchivoCodigo);
                            break;

                        case "txtPropTxtRecursoArchivoUri":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RecursoArchivoUri", vm.PropTxtRecursoArchivoUri);
                            break;

                        case "txtPropTxtRecursoArchivoNombre":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RecursoArchivoNombre", vm.PropTxtRecursoArchivoNombre);
                            break;

                        case "txtPropDatTxtRefVarDatosCampo":
                            // -aqui- esto se inhabilita
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "RefVarDatosCampo", vm.PropArchActualizCodigoCampo);
                            break;

                        case "txtPropDatTxtVariablePublica":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "VariablePublica", vm.PropDatTxtVariablePublica);
                            break;

                        case "txtPropDatTxtPrnSiValidar":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "PrnSiValidar", vm.PropDatTxtPrnSiValidar);
                            break;

                        case "txtPropDatTxtPrnValorDefault":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "PrnValorDefault", vm.PropDatTxtPrnValorDefault);
                            break;

                        case "txtPropDatTxtPrnValorPreView":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "PrnValorPreView", vm.PropDatTxtPrnValorPreView);
                            break;

                        case "txtPropDatTxtPrnMostrarTitulo":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "PrnMostrarTitulo", vm.PropDatTxtPrnMostrarTitulo);
                            break;

                        case "txtPropSeccionCodigo":
                            XmlEntorno.SetPropiedadObjeto(((FrameworkElement)guiRefObjetoSeleccionado).Name,
                                                             "SeccionCodigo", vm.PropTxtSeccionCodigo);
                            break;
                    }

                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjPropDatosActualizar");
            }
        }
        #endregion
        // Browser campos 4505 o RIPS
        #region fcvSetObjBrowserCamposArchivo: buscar Campos para Actualizar RIPS o 4505
        private void fcvSetObjBrowserCamposArchivo(object sender, RoutedEventArgs e)
        { 
            if (!String.IsNullOrWhiteSpace(vm.PropArchActualizCodigoArchivo) && vm.PropArchActualizCodigoArchivo!="NA")
            {
                var lcrCodigo = vm.PropArchActualizCodigoArchivo;
                var lcrNombreArchivo = SISValidarCodigo.fobRegBuscarSisactualizarchIu(lcrCodigo).sis_desarc_siaa;
                var lcrllave = "Sisactualizcamp.sis_codarc_siaa='" + lcrCodigo + "'";
                var lcrllave1 = " || Sisactualizcamp.sis_codarc_siaa='RIPS'"; // para mostrar varaibles generales para todo tipo rips
                lcrllave = lcrCodigo.Substring(0, 4).ToUpper() == "RIPS" ? lcrllave + lcrllave1 : lcrllave;

                Browser01 frbro = new Browser01("SIS", "SISACTUALIZCAMPIU", lcrllave, lcrNombreArchivo + "...");
                gcrCtrF2TexBox = "DatTxtRefVarDatosCampo";
                frbro.Owner = this;
                frbro.ShowDialog();
            }
        }
        #endregion
        // Buscar campos para actualizar RIPS / 4505
        #region fcvSetObjBrowserCamposArchivoValid: buscar Campos para Actualizar RIPS o 4505
        /// <summary>
        /// <para>Valida y asigna el nombre de campo seleccionado desde Brower de campos</para>
        /// <para>actualizables para archivos de RIPS 4505 y otros.</para>
        /// </summary>
        private bool fcvSetObjBrowserCamposArchivoValid(String tcrNombreCampo)
        {
            var llgReturn = true;

            if (guiRefObjetoSeleccionado != null && !String.IsNullOrWhiteSpace(tcrNombreCampo))
            {
                var lcrCampo = SISValidarCodigo.fobRegBuscarSisactualizcampIu(tcrNombreCampo);
                var lcrObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", ((FrameworkElement)guiRefObjetoSeleccionado).Name).FirstOrDefault();

                llgReturn = fcvSetObjValidacionTipoDato(lcrObjeto.TipoObjeto, lcrCampo.sis_tipval_siac);

                if (llgReturn) // si es asignable, asignar valores en la vista
                {
                    fcvSetObjBrowserCamposArchivoActualizar(tcrNombreCampo);
                }
                else
                {
                    fcvSetObjBrowserCamposArchivoActualizar("NA");
                }
            }
            return llgReturn;
        }
        #endregion
        #region fcvSetObjBrowserCamposArchivoActualizar: Actualizar Propiedades de Grupo Datos y otras
        /// <summary>
        /// <para>Mostrar o limpiar propiedades en datos de ventana propiedades para el campo relacionado</para>
        /// </summary>
        private void fcvSetObjBrowserCamposArchivoActualizar(String tcrNombreCampo)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(tcrNombreCampo) || tcrNombreCampo == "NA")
                {
                    // Limpiar los controles
                    this.txtPropDatTxtRefVarDatosCampo.Text     = String.Empty;
                    this.txtPropDatTxtVarDatosCampoTipo.Text    = String.Empty;
                    this.txtPropDatTxtVarDatosCampoTitulo.Text  = String.Empty;
                    this.txtPropDatTxtVarDatosCampoDes.Text     = String.Empty;
                    this.txtPropDatTxtVarDatosCampoValor.Text   = String.Empty;
                }
                else 
                {
                    // Cargar datos
                    var lcrCampo = SISValidarCodigo.fobRegBuscarSisactualizcampIu(tcrNombreCampo);

                    this.txtPropDatTxtRefVarDatosCampo.Text     = tcrNombreCampo;
                    this.txtPropDatTxtVarDatosCampoTipo.Text    = EdtUtilidades.fcrDescripcionTipoCampoRelacion(lcrCampo.sis_tipval_siac);
                    this.txtPropDatTxtVarDatosCampoTitulo.Text  = lcrCampo.sis_nomcam_siac;
                    this.txtPropDatTxtVarDatosCampoDes.Text     = lcrCampo.sis_descam_siac;
                    this.txtPropDatTxtVarDatosCampoValor.Text   = lcrCampo.sis_valper_siac;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjBrowserCamposArchivoActualizar");
            }
        }
        #endregion
        // Browser Variables publicas
        #region fcvSetObjBrowserVariablesPublicas: buscar Variables publicas
        private void fcvSetObjBrowserVariablesPublicas(object sender, RoutedEventArgs e)
        {
            Browser01Ex frbro = new Browser01Ex("HCL", "HCLVARIABMAESTR", "", "Variables Publicas...");
            gcrCtrF2TexBox = "PropDatTxtVariablePublica";
            frbro.Owner = this;
            frbro.ShowDialog();
        }
        #endregion
        #region fcvSetObjLimpiarVariablesPublicas: Limpiar vista de Variables publicas
        private void fcvSetObjLimpiarVariablesPublicas(object sender, RoutedEventArgs e)
        {
            fcvSetObjVistaVariablesPublicas("NA");
        }
        #endregion
        #region fcvSetObjVistaVariablesPublicas: Actualizar Propiedades Variable publica
        /// <summary>
        /// <para>Mostrar o limpiar propiedades Variables publicas</para>
        /// </summary>
        private void fcvSetObjVistaVariablesPublicas(String tcrNombreVariable)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(tcrNombreVariable) || tcrNombreVariable == "NA")
                {
                    // Generar los valores para el combobox de valores Pila
                    vm.fcvSetObjGenListaPilaVariablesPublicas();

                    // Limpiar los controles
                    this.txtPropDatTxtVariablePublica.Text          = String.Empty;
                    this.txtPropDatTxtVariablePublicaTipo.Text      = String.Empty;
                    this.txtPropDatTxtVariablePublicaTitulo.Text    = String.Empty;
                    this.txtPropDatTxtVariablePublicaDes.Text       = String.Empty;
                    this.txtPropDatTxtVariablePublicaValor.Text     = String.Empty;
                    this.txtPropDatTxtVariablePublicaSistema.Text   = String.Empty;
                }
                else
                {
                    // Cargar datos
                    var lcrRegVar = HCLValidarCodigo.fobRegBuscarHclvariabmaestrVr(tcrNombreVariable);
                    if (lcrRegVar != null)
                    {
                        //this.cboVarGestPosVector.SelectedIndex = 0;
                        // Generar los valores para el combobox de valores Pila
                        vm.fcvSetObjGenListaPilaVariablesPublicas(lcrRegVar);

                        this.txtPropDatTxtVariablePublica.Text          = tcrNombreVariable;
                        this.txtPropDatTxtVariablePublicaTipo.Text      = EdtUtilidades.fcrDescripcionTipoCampoRelacion(lcrRegVar.hcl_tipval_hcvr);
                        this.txtPropDatTxtVariablePublicaTitulo.Text    = lcrRegVar.hcl_titulo_hcvr;
                        this.txtPropDatTxtVariablePublicaDes.Text       = lcrRegVar.hcl_descri_hcvr;
                        this.txtPropDatTxtVariablePublicaValor.Text     = lcrRegVar.hcl_valper_hcvr;
                        this.txtPropDatTxtVariablePublicaSistema.Text   = lcrRegVar.hcl_sisvar_hcvr == "1" ? "VALOR PROTEGIDO" : "VALOR MODIFICABLE";

                    }
                    else
                    {
                        // Generar los valores para el combobox de valores Pila
                        vm.fcvSetObjGenListaPilaVariablesPublicas();
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjVistaVariablesPublicas");
            }
        }
        #endregion
        #region fcvSetObjBrowserVariablePublicaValid: Validar Compatibilidad tipo dato de variable publica
        /// <summary>
        /// <para>Validar Compatibilidad tipo dato de variable publica</para>
        /// </summary>
        private bool fcvSetObjBrowserVariablePublicaValid(String tcrNombreVariable)
        {
            var llgReturn = true;

            if (guiRefObjetoSeleccionado != null && !String.IsNullOrWhiteSpace(tcrNombreVariable))
            {
                var lcrRegVar = HCLValidarCodigo.fobRegBuscarHclvariabmaestrVr(tcrNombreVariable);
                var lcrObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", ((FrameworkElement)guiRefObjetoSeleccionado).Name).FirstOrDefault();

                llgReturn = fcvSetObjValidacionTipoDato(lcrObjeto.TipoObjeto, lcrRegVar.hcl_tipval_hcvr);

                if (llgReturn) // si es asignable, asignar valores en la vista
                {
                    fcvSetObjVistaVariablesPublicas(tcrNombreVariable);
                }
                else
                {
                    fcvSetObjVistaVariablesPublicas("NA");
                }
            }
            return llgReturn;
        }
        #endregion
        // Validacion tipo dato para campos y Variables publicas
        #region fcvSetObjValidacionTipoDato: Validar Tipo dato para objetos
        /// <summary>
        /// <para>Valida que el tipo de datos sea complatible con el objeto</para>
        /// </summary>
        private bool fcvSetObjValidacionTipoDato(String tcrTipoObjeto, String tcrTipoDato)
        {
            var llgReturn = true;
            var lcrMensaje = "Tipo dato no es compatible con objeto selecionado.";

            if (tcrTipoObjeto == "TEXTBOX" || tcrTipoObjeto == "TEXTBOXRELCOD" || tcrTipoObjeto == "TEXTBOXRELDES")
            {
                if (tcrTipoDato == "D" || tcrTipoDato == "H") // D = Fecha H = Hora 
                {
                    MessageBox.Show(lcrMensaje);
                    llgReturn = false;
                }
            }
            else if (tcrTipoObjeto == "RICHTEXTBOX")
            {
                if (tcrTipoDato != "C") // C = String / Texto
                {
                    MessageBox.Show(lcrMensaje);
                    llgReturn = false;
                }
            }
            else if (tcrTipoObjeto == "TEXTBOXDATE")
            {
                if (tcrTipoDato != "D") // D = Fecha 
                {
                    MessageBox.Show(lcrMensaje);
                    llgReturn = false;
                }
            }
            else if (tcrTipoObjeto == "TEXTBOXTIME")
            {
                if (tcrTipoDato != "H") // H = Hora
                {
                    MessageBox.Show(lcrMensaje);
                    llgReturn = false;
                }
            }
            else if (tcrTipoObjeto == "COMBOBOX")
            {
                if (tcrTipoDato == "D" || tcrTipoDato == "H" || tcrTipoDato == "R") // D = Fecha H = Hora R= Relacion tabla
                {
                    MessageBox.Show(lcrMensaje);
                    llgReturn = false;
                }
            }
            else if (tcrTipoObjeto == "MULTIGROUPRADIOBUTTON" || tcrTipoObjeto == "MULTICHKBOX")
            {
                if (tcrTipoDato == "D" || tcrTipoDato == "H" || tcrTipoDato == "R") // D = Fecha H = Hora R= Relacion tabla
                {
                    MessageBox.Show(lcrMensaje);
                    llgReturn = false;
                }
            }
            else
            {
                // Controles no compatibles
                llgReturn = false;
            }

            return llgReturn;
        }
        #endregion
        // Propiedades Plantilla
        #region fcvSetObjPropPlantillaActualizar: Actualizar Propiedades de Grupo Datos y otras
        /// <summary>
        /// <para>Actualizar Propiedades de la plantilla desde la ventana propiedades</para>
        /// </summary>
        private void fcvSetObjPropPlantillaActualizar(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (glgObjetosCargados == true && glgModoSetPropiedades == false && !String.IsNullOrWhiteSpace(this.txtPlantCodigo.Text))
                {
                    TextBox lobObjeto = (TextBox)sender;

                    switch (lobObjeto.Name)
                    {
                        case "txtPlantNombre":
                            XmlEntorno.SetPropiedadPlantilla(this.txtPlantCodigo.Text, "Name", vm.G1Grp_despla_grpl);
                            break;

                        case "txtPlantMargenHorizontal":
                            XmlEntorno.SetPropiedadPlantilla(this.txtPlantCodigo.Text, "MargenHorizontal", vm.G2Grp_marhor_grpv.ToString());
                            break;

                        case "txtPlantMargenVertical":
                            XmlEntorno.SetPropiedadPlantilla(this.txtPlantCodigo.Text, "MargenVertical", vm.G2Grp_marver_grpv.ToString());
                            break;

                        case "txtPlantPrefObjetos":
                            XmlEntorno.SetPropiedadPlantilla(this.txtPlantCodigo.Text, "PrefijoObjetos", vm.G1Grp_prefij_grpl);
                            break;

                        case "txtPropPlantTituloReporte":
                            XmlEntorno.gcrPlantillaTituloReporte = this.txtPropPlantTituloReporte.Text;
                            //XmlEntorno.SetPropiedadPlantilla(this.txtPlantCodigo.Text, "PlantTituloReporte", this.txtPropPlantTituloReporte.Text);
                            break;

                    }

                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: fcvSetObjPropDatosActualizar");
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // GESTION PARA ELIMINAR PAGINAS ZONAS Y OBJETOS 
        //------------------------------------------------------------
        #region Eliminar Pagina - objeto seleccionado
        #region fcvCmdEliminarPagina: Iniciar el evento eliminar Pagina
        /// <summary>
        /// Iniciar el evento eliminar Pagina
        /// </summary>
        private void fcvCmdEliminarPagina(object sender, System.EventArgs e)
        {
            if (gobRefPaginaSeleccionada != null)
            {
                MessageBoxResult result = MessageBox.Show("Eliminar pagina?", "Galeno Versión 4.0", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    fcvCmdEliminarObjetoTipo(gobRefPaginaSeleccionada as FrameworkElement, "ELIMINADO", 0);
                    // informar al vista modelo para activar botones
                    vm.gnuTopeIdAccionEdicion = XmlEntorno.gnuTopeIdAccionEdicion;
                    vm.gnuIdAccionEdicionPuntero = XmlEntorno.gnuIdAccionEdicionPuntero;
                    fcvGetValorBaseZoomScroll("SET");
                    actualizar();
                }
            }
        }
        #endregion
        #region fcvCmdEliminarObjeto: Iniciar el evento eliminar objeto
        /// <summary>
        /// Iniciar el evento eliminar objeto 
        /// </summary>
        private void fcvCmdEliminarObjeto(object sender, System.EventArgs e)
        {
            if (guiRefObjetoSeleccionado != null)
            {
                MessageBoxResult result = MessageBox.Show("Eliminar el objeto?", "Galeno Versión 4.0", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    fcvCmdEliminarObjetoTipo(guiRefObjetoSeleccionado as FrameworkElement, "ELIMINADO", 0);
                    // informar al vista modelo para activar botones
                    vm.gnuTopeIdAccionEdicion = XmlEntorno.gnuTopeIdAccionEdicion;
                    vm.gnuIdAccionEdicionPuntero = XmlEntorno.gnuIdAccionEdicionPuntero;

                    actualizar();
                }
            }
        }
        #endregion
        #region fcvCmdEliminarObjetoTipo: Accion eliminar objeto
        /// <summary>
        /// Accion eliminar objeto, cuando tnuIdAccion es cero se registra la nueva accion.
        /// </summary>
        private void fcvCmdEliminarObjetoTipo(FrameworkElement tobObjeto,String tcrAccion,int tnuIdAccion)
        {
            if (tobObjeto != null)
            {
                var lnuIdAccion = tnuIdAccion;
                var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS","", tobObjeto.Name).FirstOrDefault();
                if (tnuIdAccion <= 0) 
                {
                    lnuIdAccion = XmlEntorno.fnuEdtAccionAddObjetoPila(tcrAccion, lobObjeto);
                }
                var lobTemp     = XmlEntorno.fobEdtAccionEliminarObjetos("OBJETOS", lobObjeto.Name, tcrAccion, lnuIdAccion);

                if (lobObjeto.TipoObjeto == "MULTIRADIOBUTTON" || lobObjeto.TipoObjeto == "MULTICHKBOX")
                {
                    fcvCmdAddReindexGrupoObjetos(lobObjeto.Parent);
                }

                switch (lobObjeto.TipoObjeto.ToUpper())
                {
                    case "PAGINA": // Eliminar pagina
                        tobObjeto.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                        this.wraPlantilla.Children.Remove(tobObjeto);
                        //falta un ciclo para los objetos dentro  ---- ojo
                        break;

                    case "ZONA": // Eliminar Zona
                        WrapPanel lobPaginaContenedor = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobObjeto.Parent).
                                                                                               FirstOrDefault().RefContenedorObjeto as WrapPanel;

                        tobObjeto.MouseLeftButtonDown -= new MouseButtonEventHandler(fcvQuitarAdornoObjetoMouseLeftButtonDown);
                        tobObjeto.MouseLeftButtonUp -= new MouseButtonEventHandler(fcvFinalizaDragMouseManejador);
                        tobObjeto.MouseMove -= new MouseEventHandler(fcvEventoMoverMouseEnZona);
                        tobObjeto.MouseLeave -= new MouseEventHandler(fcvEventoMoverMouseFueraDeZona);
                        tobObjeto.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(fcvPreViewClicSeleccionObjeto);
                        tobObjeto.PreviewMouseLeftButtonUp -= new MouseButtonEventHandler(fcvFinalizaDragMouseManejador);
                        lobPaginaContenedor.Children.Remove(tobObjeto);
                        //falta un ciclo para los objetos dentro ---- ojo
                        break;

                    default: // Para el resto de objetos
                        Canvas lobContenedor = tobObjeto.Parent as Canvas;
                        lobContenedor.Children.Remove(tobObjeto);
                        break;

                }
                if (lobObjeto.TipoObjeto.ToUpper() != "PAGINA")
                {
                    tobObjeto.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);
                }
                // Quitar todas las referencias a los objetos 
                if (lobTemp != null)
                {
                    foreach (var lobReg in lobTemp)
                    {
                        if (lobReg.TipoObjeto.ToUpper() != "PAGINA" && lobReg.TipoObjeto.ToUpper() != "ZONA")
                        {
                            // Quitar referencias
                            var lob = lobReg.RefObjeto as FrameworkElement;
                            if (lob != null)
                            {
                                lob.SizeChanged -= new SizeChangedEventHandler(fcvAccionReSizeObjeto);

                                Canvas lobContenedor = lob.Parent as Canvas;
                                if (lobContenedor != null)
                                {
                                    lobContenedor.Children.Remove(lob);
                                }
                            }

                            // Liberar referencia a campos de tablas 
                            if (!String.IsNullOrWhiteSpace(lobReg.Binding))
                            {
                                XmlEntorno.flgEdtCamposLiberarCampo(lobReg.Binding);
                                if (!String.IsNullOrWhiteSpace(lobReg.BindingDescripcion))
                                {
                                    XmlEntorno.flgEdtCamposLiberarCampo(lobReg.BindingDescripcion);
                                }
                            }
                        }
                    }
                }
                // Quitar referencias Tree estructura Diseño
                fcvCmdEliminarObjetoQuitarReferencia(lobObjeto.TipoObjeto.ToUpper());
            }
        }
        #endregion
        #region fcvCmdEliminarObjetoQuitarReferencia: Quitar las referencias de seleccion
        /// <summary>
        /// <para>Quitar las referencias de seleccion de objeto al eliminar</para>
        /// </summary>
        private void fcvCmdEliminarObjetoQuitarReferencia(String tcrTipoObjeto)
        {
            switch (tcrTipoObjeto)
            {
                case "PAGINA": // Eliminar pagina
                    XmlEntorno.refTreeObj.Pagina = null;
                    XmlEntorno.refTreeObj.ContenedorPagina = null;
                    XmlEntorno.refTreeObj.Zona = null;
                    XmlEntorno.refTreeObj.ContenedorZona = null;
                    XmlEntorno.refTreeObj.Grupo = null;
                    XmlEntorno.refTreeObj.ContenedorGrupo = null;
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
                    //-Referencia a objetos
                    gobRefPaginaSeleccionada = null;
                    gobRefZonaSeleccionada = null;
                    gobRefGrupoSeleccionado = null;
                    gobRefContenedorPaginaSeleccionada = null;
                    gobRefContenedorZonaSeleccionada = null;
                    gobRefContenedorGrupoSeleccionado = null;
                    break;

                case "ZONA": // Eliminar Zona
                    XmlEntorno.refTreeObj.Zona = null;
                    XmlEntorno.refTreeObj.ContenedorZona = null;
                    XmlEntorno.refTreeObj.Grupo = null;
                    XmlEntorno.refTreeObj.ContenedorGrupo = null;
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
                    //-Referencia a objetos
                    gobRefZonaSeleccionada = null;
                    gobRefGrupoSeleccionado = null;
                    gobRefContenedorZonaSeleccionada = null;
                    gobRefContenedorGrupoSeleccionado = null;
                    break;

                case "GRUPO":
                    XmlEntorno.refTreeObj.Grupo = null;
                    XmlEntorno.refTreeObj.ContenedorGrupo = null;
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
                    //-Referencia a objetos
                    gobRefGrupoSeleccionado = null;
                    gobRefContenedorGrupoSeleccionado = null;
                    break;

                case "MULTIGROUPRADIOBUTTON":
                    XmlEntorno.refTreeObj.Grupo = null;
                    XmlEntorno.refTreeObj.ContenedorGrupo = null;
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
                    //-Referencia a objetos
                    gobRefGrupoSeleccionado = null;
                    gobRefContenedorGrupoSeleccionado = null;
                    break;

                case "MULTIGROUPCHKBOX":
                    XmlEntorno.refTreeObj.Grupo = null;
                    XmlEntorno.refTreeObj.ContenedorGrupo = null;
                    XmlEntorno.refTreeObj.NivelObjetoSelect = 0;
                    //-Referencia a objetos
                    gobRefGrupoSeleccionado = null;
                    gobRefContenedorGrupoSeleccionado = null;
                    break;

            }
            guiRefObjetoSeleccionado = null;
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // GESTION DESHACER CAMBIOS Y CANCELAR ADICIONAR OBJETO
        //------------------------------------------------------------
        #region Gestion deshacer cambios y cancelar adicion de objetos
        #region fcvCmdDesHacerAtras: Deshacer los cambios hacia atrás
        /// <summary>
        /// <para>Deshacer los cambios regresando el puntero (flecha izquierda)</para>
        /// </summary>
        private void fcvCmdDesHacerAtras(object sender, RoutedEventArgs e)
        {
            var lnuIdAccion = XmlEntorno.fnuEdtAccionDesHacer();
            if (lnuIdAccion > 0)
            {
                var lobRegistro = XmlEntorno.fobRegSelectEdtAccion(lnuIdAccion);

                if (lobRegistro != null)
                {
                    switch (lobRegistro.Accion)
                    {
                        case "ADICIONADO": // deshace Adicionar es eliminar el objeto
                            var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobRegistro.Name).FirstOrDefault().RefObjeto as FrameworkElement;
                            fcvCmdEliminarObjetoTipo(lobObjeto, lobRegistro.Accion, lnuIdAccion);
                            break;

                        case "ELIMINADO": // Adicionar el objeto eliminado, crear de nuevo
                            fcvAdicionarManejadorPaginasyZonas("AUXILIAR");
                            break;
                    }
                }
            }
            actualizar();
            // informar al vista modelo para activar botones
            vm.gnuTopeIdAccionEdicion    = XmlEntorno.gnuTopeIdAccionEdicion;
            vm.gnuIdAccionEdicionPuntero = XmlEntorno.gnuIdAccionEdicionPuntero;
        }
        #endregion
        #region fcvCmdDesHacerAdelante: Rehacer cambios hacia adelante
        /// <summary>
        /// <para>Rehacer cambios mover puntero hacia adelante (flecha derecha)</para>
        /// </summary>
        private void fcvCmdDesHacerAdelante(object sender, RoutedEventArgs e)
        {
            var lnuIdAccion = XmlEntorno.fnuEdtAccionReHacer();
            if (lnuIdAccion > 0)
            {
                var lobRegistro = XmlEntorno.fobRegSelectEdtAccion(lnuIdAccion);

                if (lobRegistro != null)
                {
                    switch (lobRegistro.Accion)
                    {
                        case "ADICIONADO": // Rehacer Adicionar (generar el objeto nuevamente)
                            fcvAdicionarManejadorPaginasyZonas("AUXILIAR");
                            break;

                        case "ELIMINADO": // Volver a eliminar el objeto, se supone que se recreo al deshacer a la izquierda

                            var lobObjeto = XmlEntorno.fobRegSelectParenObjeto("OBJETOS", "", lobRegistro.Name).FirstOrDefault().RefObjeto as FrameworkElement;
                            fcvCmdEliminarObjetoTipo(lobObjeto, lobRegistro.Accion, lnuIdAccion);
                            break;
                    }
                }
            }
            actualizar();
            // informar al vista modelo para activar botones
            vm.gnuTopeIdAccionEdicion = XmlEntorno.gnuTopeIdAccionEdicion;
            vm.gnuIdAccionEdicionPuntero = XmlEntorno.gnuIdAccionEdicionPuntero;
        }
        #endregion
        private void actualizar()
        {
            vm.TmpEliminados = new List<ClassXmlPropObjeto>();
            vm.TmpEliminados = XmlEntorno.tmpObjetosEliminado;
            vm.TmpAccion = new List<ClassXmlPropObjeto>();
            vm.TmpAccion = XmlEntorno.tmpObjetosAccion;
            //txtPuntero.Text = gobXmlEntorno.gnuIdAccionEdicionPuntero.ToString();
        }

        #region fnuCmdDesHacerAddRegistroPila: Registrar la accion en la pila
        /// <summary>
        /// <para>Registrar la accion en la pila que gestiona los cambios en objetos</para>
        /// <para>Retorna el Id numerico generado para la accion registrada.</para>
        /// </summary>
        private int fnuCmdDesHacerAddRegistroPila(String tcrAccion, ClassXmlPropObjeto tobRegistro)
        {
            var lnuIdAccion = XmlEntorno.fnuEdtAccionAddObjetoPila(tcrAccion, tobRegistro);
            // informar al vista modelo para activar botones
            vm.gnuTopeIdAccionEdicion = XmlEntorno.gnuTopeIdAccionEdicion;
            vm.gnuIdAccionEdicionPuntero = lnuIdAccion;
            actualizar();
            return lnuIdAccion;
        }
        #endregion
        #region fcvCmdDesHacerAddObjeto: Cancelar adicionar Objeto
        /// <summary>
        /// <para>Cancelar adicionar Objeto</para>
        /// </summary>
        private void fcvCmdDesHacerAddObjeto(object sender, RoutedEventArgs e)
        {
            gcrAddNuevoObjetoTipo = "";
            glgNuevoObjetoCrear = false;
            fcvRestablecerPunteroMouse();
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // MOSTRAR LA VENTANA DE PROPIEDADES
        //------------------------------------------------------------
        #region Ventana Propiedades
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades, clic en boton
        /// </summary>
        private void fcvActivarVistaPropiedades(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaPropiedades();
        }
        #region fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades
        /// </summary>
        private void fcvActivarVistaPropiedades()
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropVisible == false)
            {
                luxAnimacion.To = -445; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropAnclada = false;
                glgVistaPropVisible = true;
            }
            else
            {
                luxAnimacion.To = 150; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaPropVisible = false;
                if (glgVistaPropAnclada == true)
                {
                    fcvAnclarVentanPropiedades();
                }

            }
            this.ExtrasGrid.BeginAnimation(Canvas.LeftProperty, luxAnimacion);
        }
        #endregion
        #endregion
        #region fcvAnclarVentanPropiedades: Anclar la Ventan de propiedades y herramientas
        /// <summary>
        /// fcvAnclarVentanPropiedades: Click para anclar o desanclar ventana propiedades
        /// </summary>
        private void fcvAnclarVentanPropiedades(object sender, RoutedEventArgs e)
        {
            fcvAnclarVentanPropiedades();
        }
        /// <summary>
        /// fcvAnclarVentanPropiedades: Anclar o desanclar la ventan de propiedades
        /// </summary>
        private void fcvAnclarVentanPropiedades()
        {
            if (glgVistaPropAnclada == false)
            {
                if (glgVistaPropVisible == false)
                {
                    fcvActivarVistaPropiedades();
                }
                glgVistaPropAnclada = true;
                PanelScroll.Margin = new Thickness(0, 0, 436, 0);
                wraPlantilla.Margin = new Thickness(10, 0, 0, 0);
            }
            else
            {
                glgVistaPropAnclada = false;
                PanelScroll.Margin = new Thickness(0, 0, 40, 0);
                wraPlantilla.Margin = new Thickness(10, 0, 40, 0);
                if (glgVistaPropVisible == true)
                {
                    fcvActivarVistaPropiedades();
                }
            }
        }
        #endregion
        #region fcvClickTabsPropieades: Click en un tabs de la ventana propiedades
        /// <summary>
        /// fcvClickTabsPropieades: Click en un tabs de la ventana propiedades
        /// </summary>
        private void fcvClickTabsPropieades(object sender, RoutedEventArgs e)
        {
            lblVPropiedades.Text = "Propiedades c";
            TabItem lobj = sender as TabItem;
            if (lobj.Name == "pagHerramientas")
            {
                lblVPropiedades.Text = "Herramientas";
            }
        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // FUNCIONES DE UTILIDAD
        //------------------------------------------------------------
        #region Utilidades
        #region fcvGestionReinicarVariables: Reiniciar Variables de Gestion
        /// <summary>
        /// Reiniciar Variables de Gestion
        /// </summary>
        private void fcvGestionReinicarVariables()
        {
            //- Referencias a objetos
            vm.gcrTipoContenedorActivo = "";
            guiRefObjetoSeleccionado = null;
            gobRefGrupoSeleccionado = null;
            gobRefContenedorGrupoSeleccionado = null;
            gobRefZonaSeleccionada = null;
            gobRefContenedorZonaSeleccionada = null;
            gobRefPaginaSeleccionada = null;
            gobPaginaSelectParaAddZona = null;
            // colocar imagen por defecto en vista galeria imagenes
            var lobUri = new EdtUtilidades.ObjetoBitmapImage();
            lobUri.AppIpServidor = oApp.gcrAppRecursoIpServidor;
            lobUri.AppInicioPath = oApp.gcrAppRecursoInicioPath;
            lobUri.RutaGaleria   = @"GestorReportes\Imagenes";
            lobUri.NombreArchivo = "Edt_controles_imagensimple.png";
            this.imgImagenPredefinida.Source = EdtUtilidades.SetBitmapImageUri(lobUri);

            vm.fcvGridReiniVariables("A");

        }
        #endregion
        #endregion
        //------------------------------------------------------------
        // MOSTRAR BARRA DE ESTADO
        //------------------------------------------------------------
        #region Barra de Estado
        #region fcvBarraEstado: Mostrar u Ocultar la Ventana Propiedades
        /// <summary>
        /// fcvActivarVistaPropiedades: Mostrar u Ocultar la Ventana Propiedades, clic en boton
        /// </summary>
        private void fcvActivarBarraEstado(object sender, RoutedEventArgs e)
        {
            if (glgVistaBarraEstadoVisible == false)
            {
                fcvActivarBarraEstado(true);
            }
            else
            {
                fcvActivarBarraEstado(false);
            }
        }
        #endregion
        #region fcvActivarBarraEstado: Mostrar u Ocultar la barra de estado
        /// <summary>
        /// Mostrar u Ocultar la barra de estado
        /// </summary>
        private void fcvActivarBarraEstado(bool tlgModo)
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaBarraEstadoVisible == false)
            {
                if (tlgModo == true)
                {
                    luxAnimacion.To = -70; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                    glgVistaBarraEstadoVisible = true;
                }
            }
            else
            {
                if (tlgModo == false)
                {
                    luxAnimacion.To = 8; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                    glgVistaBarraEstadoVisible = false;
                }
            }
            this.grdBarraEstado.BeginAnimation(Canvas.TopProperty, luxAnimacion);
        }

        /*
        private void fcvActivarBarraEstado()
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaBarraEstadoVisible == false)
            {
                luxAnimacion.To = -70; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaBarraEstadoVisible = true;
            }
            else
            {
                luxAnimacion.To = 8; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(500));
                glgVistaBarraEstadoVisible = false;
            }
            this.grdBarraEstado.BeginAnimation(Canvas.TopProperty, luxAnimacion);
        }
        */
        #endregion
        #endregion
    }
}
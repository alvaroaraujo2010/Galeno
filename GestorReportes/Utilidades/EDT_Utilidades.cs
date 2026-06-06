using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Sistema.Utilidades;
using Sistema.Clases;
using System.IO;
using GestorReportes.Vista;
using GestorReportes.VistaModelo;
using Microsoft.Win32;

namespace GestorReportes.Utilidades
{
    public class EdtUtilidades
    {
        //------------------------------------------------------------
        //- ASIGNAR PROPIEDADES A OBJETO ACTIVO
        //------------------------------------------------------------
        #region flgSetPropiedadTituloObjeto: Asignar propiedades titulo objeto
        /// <summary>
        /// <para>Asignar propiedades titulo objeto</para>
        /// </summary>
        public static bool flgSetPropiedadTituloObjeto(UIElement tobRefObjeto, String tcrTipoObjeto, ObjetoTitulo tobTitulo)
        {
            var llgReturn = false;
            if (tobRefObjeto != null)
            {
                switch (tcrTipoObjeto.ToUpper())
                {
                    case "TEXTBOX":
                        llgReturn = true;
                        TextBox lobjTextBox = tobRefObjeto as TextBox;
                        lobjTextBox.Text = tobTitulo.Titulo.Trim();
                        break;

                    case "RICHTEXTBOX":
                        llgReturn = true;
                        RichTextBox lobjRichTextBox = tobRefObjeto as RichTextBox;
                        TextRange lobTextRange = new TextRange(lobjRichTextBox.Document.ContentStart, lobjRichTextBox.Document.ContentEnd);
                        lobTextRange.Text = tobTitulo.Titulo.Trim();
                        break;

                    case "COMBOBOX":
                        llgReturn = true;
                        ComboBox lobjComboBox = tobRefObjeto as ComboBox;
                        break;

                    case "TEXTBLOCK":
                        llgReturn = true;
                        TextBlock lobjTextBlock = tobRefObjeto as TextBlock;
                        lobjTextBlock.Text = tobTitulo.Titulo.Trim();
                        break;

                    case "RADIOBUTTON":
                        llgReturn = true;
                        RadioButton lobjRadioButton = tobRefObjeto as RadioButton;
                        lobjRadioButton.Content = String.IsNullOrWhiteSpace(tobTitulo.TituloVisible) || 
                                                         tobTitulo.TituloVisible == "True" ? tobTitulo.Titulo.Trim() : null;
                        break;

                    case "CHECKBOX":
                        llgReturn = true;
                        CheckBox lobjCheckBox = tobRefObjeto as CheckBox;
                        lobjCheckBox.Content = String.IsNullOrWhiteSpace(tobTitulo.TituloVisible) ||
                                                      tobTitulo.TituloVisible == "True" ? tobTitulo.Titulo.Trim() : null;
                        break;

                    case "BUTTON":
                        llgReturn = true;
                        Button lobjButton = tobRefObjeto as Button;
                        lobjButton.Content = tobTitulo.Titulo.Trim();
                        break;

                    case "GROUPBOX":
                        llgReturn = true;
                        GroupBox lobjGroupBox = tobRefObjeto as GroupBox;
                        lobjGroupBox.Header = String.IsNullOrWhiteSpace(tobTitulo.TituloVisible) || 
                                                     tobTitulo.TituloVisible == "True" ? tobTitulo.Titulo.Trim() : null;
                        break;

                    case "IMAGE":
                        llgReturn = true;
                        var lobjImage = tobRefObjeto as Image;
                        break;

                    case "RECTANGLE":
                        llgReturn = true;
                        var lobjRectangle = tobRefObjeto as System.Windows.Shapes.Rectangle;
                        break;

                    case "ELLIPSE":
                        llgReturn = true;
                        var lobjEllipse = tobRefObjeto as System.Windows.Shapes.Ellipse;
                        break;

                    case "LINE":
                        llgReturn = true;
                        break;

                    case "POLYLINE":
                        llgReturn = true;
                        var lobPolyline = tobRefObjeto as System.Windows.Shapes.Polyline;
                        break;

                    case "POLYGON":
                        llgReturn = true;
                        var lobPolygon = tobRefObjeto as System.Windows.Shapes.Polygon;
                        break;

                }
            }
            return llgReturn;
        }
        #endregion
        #region flgSetPropiedadToolTipObjeto: Asignar propiedades texto de ayuda objeto
        /// <summary>
        /// <para>Asignar propiedades texto de ayuda objeto</para>
        /// </summary>
        public static bool flgSetPropiedadToolTipObjeto(UIElement tobRefObjeto, String tcrTipoObjeto, String tcrTexto)
        {
            var llgReturn = false;
            if (tobRefObjeto != null)
            {
                switch (tcrTipoObjeto.ToUpper())
                {
                    case "TEXTBOX":
                        llgReturn = true;
                        TextBox lobjTextBox = tobRefObjeto as TextBox;
                        lobjTextBox.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "RICHTEXTBOX":
                        llgReturn = true;
                        RichTextBox lobjRichTextBox = tobRefObjeto as RichTextBox;
                        lobjRichTextBox.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto) ? tcrTexto : null;
                        break;

                    case "COMBOBOX":
                        llgReturn = true;
                        ComboBox lobjComboBox = tobRefObjeto as ComboBox;
                        lobjComboBox.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "TEXTBLOCK":
                        llgReturn = true;
                        TextBlock lobjTextBlock = tobRefObjeto as TextBlock;
                        lobjTextBlock.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "RADIOBUTTON":
                        llgReturn = true;
                        RadioButton lobjRadioButton = tobRefObjeto as RadioButton;
                        lobjRadioButton.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "USERCONTROL":
                        llgReturn = true;
                        UserControl lobjUserControl = tobRefObjeto as UserControl;
                        lobjUserControl.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto) ? tcrTexto : null;
                        break;

                    case "CHECKBOX":
                        llgReturn = true;
                        CheckBox lobjCheckBox = tobRefObjeto as CheckBox;
                        lobjCheckBox.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "BUTTON":
                        llgReturn = true;
                        Button lobjButton = tobRefObjeto as Button;
                        lobjButton.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "GROUPBOX":
                        llgReturn = true;
                        GroupBox lobjGroupBox = tobRefObjeto as GroupBox;
                        lobjGroupBox.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "IMAGE":
                        llgReturn = true;
                        var lobjImage = tobRefObjeto as Image;
                        lobjImage.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "RECTANGLE":
                        llgReturn = true;
                        var lobjRectangle = tobRefObjeto as System.Windows.Shapes.Rectangle;
                        lobjRectangle.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "ELLIPSE":
                        llgReturn = true;
                        var lobjEllipse = tobRefObjeto as System.Windows.Shapes.Ellipse;
                        lobjEllipse.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "LINE":
                        llgReturn = true;
                        var lobjLine = tobRefObjeto as System.Windows.Shapes.Line;
                        lobjLine.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "POLYLINE":
                        llgReturn = true;
                        var lobPolyline = tobRefObjeto as System.Windows.Shapes.Polyline;
                        lobPolyline.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                    case "POLYGON":
                        llgReturn = true;
                        var lobPolygon = tobRefObjeto as System.Windows.Shapes.Polygon;
                        lobPolygon.ToolTip = !String.IsNullOrWhiteSpace(tcrTexto)? tcrTexto : null;
                        break;

                }
            }
            return llgReturn;
        }
        #endregion
        #region flgSetPropiedadDistribucionObjeto: Asignar propiedades Alto,Largo,Left y Top
        /// <summary>
        /// <para>Asignar propiedades Alto,Largo,Left y Top</para>
        /// </summary>
        public static bool flgSetPropiedadDistribucionObjeto(UIElement tobRefObjeto, ClassXmlPropObjeto tobPropiedadObjeto, ObjetoDistribucion tobDistribucion)
        {
            var llgReturn = false;
            if (tobRefObjeto != null)
            {
                llgReturn = true;
                var lobj = tobRefObjeto as FrameworkElement;
                String lcrNombreObjeto = lobj.Name.Substring(0, 7).ToUpper();

                if (tobPropiedadObjeto.ClaseBase != "UserControl")
                {
                    lobj.Height = tobDistribucion.Height;
                    lobj.Width = tobDistribucion.Width;
                    if (lcrNombreObjeto != "OBJPAGI" && lcrNombreObjeto != "OBJCPAG" && lcrNombreObjeto != "OBJZONA" && lcrNombreObjeto != "OBJCZON")
                    {
                        Canvas.SetLeft(lobj, tobDistribucion.Left);
                        Canvas.SetTop(lobj, tobDistribucion.Top);
                    }
                }
                else
                {
                    var lobcontrol = lobj as UserControl;
                    lobcontrol.Height = tobDistribucion.Height;
                    lobcontrol.Width = tobDistribucion.Width;
                    Canvas.SetLeft(lobcontrol, tobDistribucion.Left);
                    Canvas.SetTop(lobcontrol, tobDistribucion.Top);
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgSetPropiedadColorObjeto: Asignar propiedades de color a objeto segun tipo objeto (TextBox,Listbox...)
        /// <summary>
        /// <para>Asignar propiedades de color a objeto segun tipo objeto (TextBox,Listbox...)</para>
        /// </summary>
        public static bool flgSetPropiedadColorObjeto(UIElement tobRefObjeto, String tcrTipoObjeto, ObjetoPropiedadColor tobColor)
        {
            var llgReturn = false;
            if (tobRefObjeto !=null)
            {
                switch (tcrTipoObjeto.ToUpper())
                {
                    case "TEXTBOX":
                        llgReturn = true;
                        TextBox lobjTextBox = tobRefObjeto as TextBox;
                        lobjTextBox.Foreground = new SolidColorBrush(tobColor.Fuente);
                        lobjTextBox.BorderBrush = new SolidColorBrush(tobColor.Bordes);
                        lobjTextBox.Background = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "RICHTEXTBOX":
                        llgReturn = true;
                        RichTextBox lobjRichTextBox = tobRefObjeto as RichTextBox;
                        lobjRichTextBox.Foreground = new SolidColorBrush(tobColor.Fuente);
                        lobjRichTextBox.BorderBrush = new SolidColorBrush(tobColor.Bordes);
                        lobjRichTextBox.Background = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "COMBOBOX":
                        llgReturn = true;
                        ComboBox lobjComboBox = tobRefObjeto as ComboBox;
                        lobjComboBox.Foreground = new SolidColorBrush(tobColor.Fuente);
                        lobjComboBox.BorderBrush = new SolidColorBrush(tobColor.Bordes);
                        lobjComboBox.Background = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "TEXTBLOCK":
                        llgReturn = true;
                        TextBlock lobjTextBlock = tobRefObjeto as TextBlock;
                        lobjTextBlock.Foreground = new SolidColorBrush(tobColor.Fuente);
                        lobjTextBlock.Background = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "RADIOBUTTON":
                        llgReturn = true;
                        RadioButton lobjRadioButton = tobRefObjeto as RadioButton;
                        lobjRadioButton.Foreground = new SolidColorBrush(tobColor.Fuente);
                        lobjRadioButton.BorderBrush = new SolidColorBrush(tobColor.Bordes);
                        lobjRadioButton.Background = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "CHECKBOX":
                        llgReturn = true;
                        CheckBox lobjCheckBox = tobRefObjeto as CheckBox;
                        lobjCheckBox.Foreground = new SolidColorBrush(tobColor.Fuente);
                        lobjCheckBox.BorderBrush = new SolidColorBrush(tobColor.Bordes);
                        lobjCheckBox.Background = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "CANVAS":
                        llgReturn = true;
                        Canvas lobjCanvas = tobRefObjeto as Canvas;
                        lobjCanvas.Background = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "BUTTON":
                        llgReturn = true;
                        Button lobjButton = tobRefObjeto as Button;
                        lobjButton.Foreground = new SolidColorBrush(tobColor.Fuente);
                        lobjButton.Background = new SolidColorBrush(tobColor.Fondo);
                        lobjButton.BorderBrush = new SolidColorBrush(tobColor.Bordes);
                        break;

                    case "GROUPBOX":
                        llgReturn = true;
                        GroupBox lobjGroupBox = tobRefObjeto as GroupBox;
                        lobjGroupBox.Foreground = new SolidColorBrush(tobColor.Fuente);
                        lobjGroupBox.BorderBrush = new SolidColorBrush(tobColor.Bordes);
                        lobjGroupBox.Background = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "USERCONTROL":
                        llgReturn = true;
                        UserControl lobjUserControl = tobRefObjeto as UserControl;
                        lobjUserControl.Foreground = new SolidColorBrush(tobColor.Fuente);
                        lobjUserControl.BorderBrush = new SolidColorBrush(tobColor.Bordes);
                        lobjUserControl.Background = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "IMAGE":
                        llgReturn = true;
                        break;

                    case "WRAPPANEL":
                        llgReturn = true;
                        WrapPanel lobjWrapPanel = tobRefObjeto as WrapPanel;
                        lobjWrapPanel.Background = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "RECTANGLE":
                        llgReturn = true;
                        System.Windows.Shapes.Rectangle lobjRectangle = tobRefObjeto as System.Windows.Shapes.Rectangle;
                        lobjRectangle.Stroke = new SolidColorBrush(tobColor.Bordes);
                        lobjRectangle.Fill = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "ELLIPSE":
                        llgReturn = true;
                        System.Windows.Shapes.Ellipse lobjEllipse = tobRefObjeto as System.Windows.Shapes.Ellipse;
                        lobjEllipse.Stroke = new SolidColorBrush(tobColor.Bordes);
                        lobjEllipse.Fill = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "LINE":
                        llgReturn = true;
                        System.Windows.Shapes.Line lobjLine = tobRefObjeto as System.Windows.Shapes.Line;
                        lobjLine.Stroke = new SolidColorBrush(tobColor.Bordes);
                        lobjLine.Fill = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "POLYLINE":
                        llgReturn = true;
                        System.Windows.Shapes.Polyline lobjPolyline = tobRefObjeto as System.Windows.Shapes.Polyline;
                        lobjPolyline.Stroke = new SolidColorBrush(tobColor.Bordes);
                        lobjPolyline.Fill = new SolidColorBrush(tobColor.Fondo);
                        break;

                    case "POLYGON":
                        llgReturn = true;
                        System.Windows.Shapes.Polygon lobjPolygon = tobRefObjeto as System.Windows.Shapes.Polygon;
                        lobjPolygon.Stroke = new SolidColorBrush(tobColor.Bordes);
                        lobjPolygon.Fill = new SolidColorBrush(tobColor.Fondo);
                        break;
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgSetPropiedadFuenteObjeto: Asignar propiedades fuente a objeto segun tipo objeto (TextBox,Listbox...)
        /// <summary>
        /// <para>Asignar propiedades fuente a objeto segun tipo objeto (TextBox,Listbox...)</para>
        /// </summary>
        public static bool flgSetPropiedadFuenteObjeto(UIElement tobRefObjeto, String tcrTipoObjeto, ObjetoPropiedadFont tcrFuente)
        {
            var llgReturn = false;
            if (tobRefObjeto !=null)
            {
                switch (tcrTipoObjeto.ToUpper())
                {
                    case "TEXTBOX":
                        llgReturn = true;
                        TextBox lobjTextBox = tobRefObjeto as TextBox;
                        lobjTextBox.FontFamily = tcrFuente.FontFamily;
                        lobjTextBox.FontStyle = tcrFuente.FontStyle;
                        lobjTextBox.FontWeight = tcrFuente.FontWeight;
                        lobjTextBox.FontSize = tcrFuente.FontSize;
                        break;

                    case "RICHTEXTBOX":
                        llgReturn = true;
                        RichTextBox lobjRichTextBox = tobRefObjeto as RichTextBox;
                        lobjRichTextBox.FontFamily = tcrFuente.FontFamily;
                        lobjRichTextBox.FontStyle = tcrFuente.FontStyle;
                        lobjRichTextBox.FontWeight = tcrFuente.FontWeight;
                        lobjRichTextBox.FontSize = tcrFuente.FontSize;
                        break;

                    case "COMBOBOX":
                        llgReturn = true;
                        ComboBox lobjComboBox = tobRefObjeto as ComboBox;
                        lobjComboBox.FontFamily = tcrFuente.FontFamily;
                        lobjComboBox.FontStyle = tcrFuente.FontStyle;
                        lobjComboBox.FontWeight = tcrFuente.FontWeight;
                        lobjComboBox.FontSize = tcrFuente.FontSize;
                        break;

                    case "TEXTBLOCK":
                        llgReturn = true;
                        TextBlock lobjTextBlock = tobRefObjeto as TextBlock;
                        lobjTextBlock.FontFamily = tcrFuente.FontFamily;
                        lobjTextBlock.FontStyle = tcrFuente.FontStyle;
                        lobjTextBlock.FontWeight = tcrFuente.FontWeight;
                        lobjTextBlock.FontSize = tcrFuente.FontSize;
                        break;

                    case "RADIOBUTTON":
                        llgReturn = true;
                        RadioButton lobjRadioButton = tobRefObjeto as RadioButton;
                        lobjRadioButton.FontFamily = tcrFuente.FontFamily;
                        lobjRadioButton.FontStyle = tcrFuente.FontStyle;
                        lobjRadioButton.FontWeight = tcrFuente.FontWeight;
                        lobjRadioButton.FontSize = tcrFuente.FontSize;
                        break;

                    case "CHECKBOX":
                        llgReturn = true;
                        CheckBox lobjCheckBox = tobRefObjeto as CheckBox;
                        lobjCheckBox.FontFamily = tcrFuente.FontFamily;
                        lobjCheckBox.FontStyle = tcrFuente.FontStyle;
                        lobjCheckBox.FontWeight = tcrFuente.FontWeight;
                        lobjCheckBox.FontSize = tcrFuente.FontSize;
                        break;

                    case "BUTTON":
                        llgReturn = true;
                        Button lobjButton = tobRefObjeto as Button;
                        lobjButton.FontFamily = tcrFuente.FontFamily;
                        lobjButton.FontStyle = tcrFuente.FontStyle;
                        lobjButton.FontWeight = tcrFuente.FontWeight;
                        lobjButton.FontSize = tcrFuente.FontSize;
                        break;

                    case "GROUPBOX":
                        llgReturn = true;
                        GroupBox lobjGroupBox = tobRefObjeto as GroupBox;
                        lobjGroupBox.FontFamily = tcrFuente.FontFamily;
                        lobjGroupBox.FontStyle = tcrFuente.FontStyle;
                        lobjGroupBox.FontWeight = tcrFuente.FontWeight;
                        lobjGroupBox.FontSize = tcrFuente.FontSize;
                        break;

                    case "USERCONTROL":
                        llgReturn = true;
                        UserControl lobjUserControl = tobRefObjeto as UserControl;
                        lobjUserControl.FontFamily = tcrFuente.FontFamily;
                        lobjUserControl.FontStyle = tcrFuente.FontStyle;
                        lobjUserControl.FontWeight = tcrFuente.FontWeight;
                        lobjUserControl.FontSize = tcrFuente.FontSize;
                        break;
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgSetPropiedadBorderObjeto: Asignar propiedades Border a objetos
        /// <summary>
        /// <para>Asignar propiedades Border a objetos</para>
        /// </summary>
        public static bool flgSetPropiedadBorderObjeto(UIElement tobRefObjeto, String tcrTipoObjeto, String tcrValor)
        {
            var llgReturn = false;
            if (tobRefObjeto !=null)
            {
                switch (tcrTipoObjeto.ToUpper())
                {
                    case "TEXTBOX":
                        llgReturn = true;
                        TextBox lobjTextBox = tobRefObjeto as TextBox;
                        lobjTextBox.BorderThickness = SetBorderThickness(tcrValor);
                        break;

                    case "RICHTEXTBOX":
                        llgReturn = true;
                        RichTextBox lobjRichTextBox = tobRefObjeto as RichTextBox;
                        lobjRichTextBox.BorderThickness = SetBorderThickness(tcrValor);
                        break;

                    case "COMBOBOX":
                        llgReturn = true;
                        ComboBox lobjComboBox = tobRefObjeto as ComboBox;
                        lobjComboBox.BorderThickness = SetBorderThickness(tcrValor);
                        break;

                    case "TEXTBLOCK":
                        llgReturn = true;
                        //TextBlock lobjTextBlock = tobRefObjeto as TextBlock;
                        break;

                    case "RADIOBUTTON":
                        llgReturn = true;
                        RadioButton lobjRadioButton = tobRefObjeto as RadioButton;
                        lobjRadioButton.BorderThickness = SetBorderThickness(tcrValor);
                        break;

                    case "CHECKBOX":
                        llgReturn = true;
                        CheckBox lobjCheckBox = tobRefObjeto as CheckBox;
                        lobjCheckBox.BorderThickness = SetBorderThickness(tcrValor);
                        break;

                    case "BUTTON":
                        llgReturn = true;
                        Button lobjButton = tobRefObjeto as Button;
                        lobjButton.BorderThickness = SetBorderThickness(tcrValor);
                        break;

                    case "GROUPBOX":
                        llgReturn = true;
                        GroupBox lobjGroupBox = tobRefObjeto as GroupBox;
                        lobjGroupBox.BorderThickness = SetBorderThickness(tcrValor);
                        break;

                    case "USERCONTROL":
                        llgReturn = true;
                        UserControl lobjUserControl = tobRefObjeto as UserControl;
                        lobjUserControl.BorderThickness = SetBorderThickness(tcrValor);
                        break;

                    case "CANVAS":
                        llgReturn = true;
                        //Canvas lobjCanvas = tobRefObjeto as Canvas;
                        break;

                    case "RECTANGLE":
                        llgReturn = true;
                        System.Windows.Shapes.Rectangle lobjRectangle = tobRefObjeto as System.Windows.Shapes.Rectangle;
                        lobjRectangle.StrokeThickness = SetStrokeThickness(tcrValor);
                        break;

                    case "ELLIPSE":
                        llgReturn = true;
                        System.Windows.Shapes.Ellipse lobjEllipse = tobRefObjeto as System.Windows.Shapes.Ellipse;
                        lobjEllipse.StrokeThickness = SetStrokeThickness(tcrValor);
                        break;

                    case "LINE":
                        llgReturn = true;
                        System.Windows.Shapes.Line lobjLine = tobRefObjeto as System.Windows.Shapes.Line;
                        lobjLine.StrokeThickness = SetStrokeThickness(tcrValor);
                        break;

                    case "POLYLINE":
                        llgReturn = true;
                        System.Windows.Shapes.Polyline lobjPolyline = tobRefObjeto as System.Windows.Shapes.Polyline;
                        lobjPolyline.StrokeThickness = SetStrokeThickness(tcrValor);
                        break;

                    case "POLYGON":
                        llgReturn = true;
                        System.Windows.Shapes.Polygon lobjPolygon = tobRefObjeto as System.Windows.Shapes.Polygon;
                        lobjPolygon.StrokeThickness = SetStrokeThickness(tcrValor);
                        break;

                }
            }
            return llgReturn;
        }
        #endregion
        #region flgSetPropiedadStretch: Asignar propiedades ajuste de imagen
        /// <summary>
        /// <para>Asignar propiedades ajuste de imagen</para>
        /// </summary>
        public static bool flgSetPropiedadStretch(UIElement tobRefObjeto, String tcrStretch, String tcrStretchDirection)
        {
            var llgReturn = false;
            if (tobRefObjeto != null)
            {
                llgReturn = true;
                Image lobjImage = tobRefObjeto as Image;
                lobjImage.Stretch = String.IsNullOrWhiteSpace(tcrStretch) ? lobjImage.Stretch : SetStretch(tcrStretch);
                lobjImage.StretchDirection = String.IsNullOrWhiteSpace(tcrStretchDirection) ? lobjImage.StretchDirection : SetStretchDirection(tcrStretchDirection);
            }
            return llgReturn;
        }
        #endregion
        #region flgSetPropiedadAlineacionTexto: Asignar propiedades alineacion del texto
        /// <summary>
        /// <para>Asignar propiedades alineacion del texto</para>
        /// </summary>
        public static bool flgSetPropiedadAlineacionTexto(UIElement tobRefObjeto, String tcrTipoObjeto, String tcrTexto)
        {
            var llgReturn = false;
            if (tobRefObjeto != null)
            {
                switch (tcrTipoObjeto.ToUpper())
                {
                    case "TEXTBOX":
                        llgReturn = true;
                        TextBox lobjTextBox = tobRefObjeto as TextBox;
                        lobjTextBox.TextAlignment = SetTextAlignment(tcrTexto);
                        break;

                    case "RICHTEXTBOX":
                        llgReturn = true;
                        RichTextBox lobjRichTextBox = tobRefObjeto as RichTextBox;
                        TextRange lobjTextRange = new TextRange(lobjRichTextBox.Document.ContentStart, lobjRichTextBox.Document.ContentEnd);
                        lobjTextRange.ApplyPropertyValue(FlowDocument.TextAlignmentProperty, SetTextAlignment(tcrTexto));
                        break;

                    case "TEXTBLOCK":
                        llgReturn = true;
                        TextBlock lobjTextBlock = tobRefObjeto as TextBlock;
                        lobjTextBlock.TextAlignment = SetTextAlignment(tcrTexto);
                        break;
                }
            }
            return llgReturn;
        }
        #endregion

        //------------------------------------------------------------
        // fcrGetClassBaseObjeto: Devuelve la clase Base del Objeto
        //------------------------------------------------------------
        #region fcrGetClassBaseObjeto: Devuelve la clase Base del Objeto
        /// <summary>
        /// <para>Devuelve la clase Base del Objeto dado en el parametro tobRefObjeto</para>
        /// </summary>
        public static String fcrGetClassBaseObjeto(UIElement tobRefObjeto)
        {
            var lcrReturn = String.Empty;
            if (tobRefObjeto != null)
            {
                switch (tobRefObjeto.GetType().ToString())
                {

                    case "System.Windows.Controls.UserControl":
                        lcrReturn = "UserControl";
                        break;

                    case "System.Windows.Controls.TextBox":
                        lcrReturn = "TextBox";
                        break;

                    case "System.Windows.Controls.RichTextBox":
                        lcrReturn = "RichTextBox";
                        break;

                    case "System.Windows.Controls.ComboBox":
                        lcrReturn = "ComboBox";
                        break;

                    case "System.Windows.Controls.TextBlock":
                        lcrReturn = "TextBlock";
                        break;

                    case "System.Windows.Controls.RadioButton":
                        lcrReturn = "RadioButton";
                        break;

                    case "System.Windows.Controls.Canvas":
                        lcrReturn = "Canvas";
                        break;

                    case "System.Windows.Controls.Button":
                        lcrReturn = "Button";
                        break;

                    case "System.Windows.Controls.CheckBox":
                        lcrReturn = "CheckBox";
                        break;

                    case "System.Windows.Controls.GroupBox":
                        lcrReturn = "GroupBox";
                        break;

                    case "System.Windows.Controls.WrapPanel":
                        lcrReturn = "WrapPanel";
                        break;

                    case "System.Windows.Controls.StackPanel":
                        lcrReturn = "StackPanel";
                        break;

                    case "System.Windows.Controls.Image":
                        lcrReturn = "Image";
                        break;

                    case "System.Windows.Shapes.Rectangle":  
                        lcrReturn = "Rectangle";
                        break;

                    case "System.Windows.Shapes.Ellipse":
                        lcrReturn = "Ellipse";
                        break;
                       
                    case "System.Windows.Shapes.Polyline":
                        lcrReturn = "Polyline";
                        break;

                    case "System.Windows.Shapes.Polygon":
                        lcrReturn = "Polygon";
                        break;

                    case "System.Windows.Shapes.Line":
                        lcrReturn = "Line"; 
                        break;

                    default:
                        if (Funciones.flgExisteSubCadenaString("Control", tobRefObjeto.GetType().ToString()))
                        {
                            lcrReturn = "UserControl";
                        }
                        break;
                }
            }
            return lcrReturn;
        }
        #endregion
        //------------------------------------------------------------
        //- CLASE PARA GESTION PROPIEDADES
        //------------------------------------------------------------
        #region ObjetoDistribucion: Carga lista de Valores Distribucion
        /// <summary>
        /// <para>Valores propiedades: Alto,Ancho,Alinacion Izquierda y Arriba</para>
        /// </summary>
        public class ObjetoDistribucion
        {
            public ObjetoDistribucion() { }

            public String Validacion { get; set; }     // 4 valores ejemplo: 1121, 1111, 2111
            public Double Height { get; set; }  // 1
            public Double Width { get; set; }   // 2
            public Double Left { get; set; }    // 3    
            public Double Top { get; set; }     // 4

        }
        #endregion
        #region ObjetoTitulo: Mostrar Valores para propiedad titulo
        /// <summary>
        /// <para>Mostrar Valores para propiedad titulo</para>
        /// </summary>
        public class ObjetoTitulo
        {
            public ObjetoTitulo() { }
            public String Titulo { get; set; }
            public String TituloVisible { get; set; }
        }
        #endregion
        #region ObjetoPropiedadColor: Carga lista de Valores para propiedad Color
        /// <summary>
        /// <para>Valores propiedades color para Objeto (Get/Set Color)</para>
        /// </summary>
        public class ObjetoPropiedadColor
        {
            public ObjetoPropiedadColor() { }
            public Color Fuente { get; set; }
            public Color Fondo { get; set; }
            public Color Bordes { get; set; }
        }
        #endregion
        #region ObjetoPropiedadFont: Valores propiedades fuente para Objeto (Get/Set Color)
        /// <summary>
        /// <para>Valores propiedades fuente para Objeto (Get/Set Color)</para>
        /// </summary>
        public class ObjetoPropiedadFont
        {
            public ObjetoPropiedadFont() { }

            public FontFamily FontFamily { get; set; }
            public FontStyle FontStyle { get; set; }
            public double FontSize { get; set; }
            public FontWeight FontWeight { get; set; }
            public TextDecoration TextDecoration { get; set; }
        }
        #endregion
        #region ObjetoBitmapImage: Valores para generar un BitmapImage
        /// <summary>
        /// <para>Valores para generar un BitmapImage (ip servidor, ruta app, ruta galeria, nombre imagen)</para>
        /// </summary>
        public class ObjetoBitmapImage
        {
            public ObjetoBitmapImage() { }

            public String AppIpServidor { get; set; }
            public String AppInicioPath { get; set; }
            public String RutaGaleria { get; set; }
            public String NombreArchivo { get; set; }
            public String RecursoCodigo { get; set; }
            public String RecursoTitulo { get; set; }
            public String RecursoDescripcion { get; set; }
        }
        #endregion
        #region ArchivoRecurso: Datos del archivo de recursos localizado en sistema
        /// <summary>
        /// <para>Datos del archivo de recursos localizado desde el explorador de windows</para>
        /// </summary>
        public class ArchivoRecurso
        {
            public ArchivoRecurso() { }

            public String RutayArchivo { get; set; }
            public String NombreArchivo { get; set; }
            public String Extencion { get; set; }
        }
        #endregion
        //------------------------------------------------------------
        // SET - Convertir Propiedades para asignar a objetos
        //------------------------------------------------------------
        #region SetHorizontalAlignment
        /// <summary>
        /// <para>Convertir propiedad de texto a tipo HorizontalAlignment </para>
        /// </summary>
        public static HorizontalAlignment SetHorizontalAlignment(String tcrValor)
        {
            HorizontalAlignment lcrValor = HorizontalAlignment.Left;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    switch (tcrValor)
                    {
                        case "Left":
                            lcrValor = HorizontalAlignment.Left;
                            break;

                        case "Right":
                            lcrValor = HorizontalAlignment.Right;
                            break;

                        case "Stretch":
                            lcrValor = HorizontalAlignment.Stretch;
                            break;

                        case "Center":
                            lcrValor = HorizontalAlignment.Center;
                            break;
                    }
                }
            }
            return lcrValor;
        }
        #endregion
        #region SetVerticalAlignment
        /// <summary>
        /// <para>Convertir propiedad de texto a tipo VerticalAlignment</para>
        /// </summary>
        public static VerticalAlignment SetVerticalAlignment(String tcrValor)
        {
            VerticalAlignment lcrValor = VerticalAlignment.Top;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    switch (tcrValor)
                    {
                        case "Top":
                            lcrValor = VerticalAlignment.Top;
                            break;

                        case "Center":
                            lcrValor = VerticalAlignment.Center;
                            break;

                        case "Stretch":
                            lcrValor = VerticalAlignment.Stretch;
                            break;

                        case "Bottom":
                            lcrValor = VerticalAlignment.Bottom;
                            break;
                    }
                }
            }
            return lcrValor;
        }
        #endregion
        #region SetMargin
        /// <summary>
        /// <para>Convertir propiedad de texto a tipo Margin</para>
        /// </summary>
        public static Thickness SetMargin(String tcrValor)
        {
            tcrValor = String.IsNullOrWhiteSpace(tcrValor) ? "0" : tcrValor;

            int lnuTotLista = Funciones.fnuContarElemListaString(",", tcrValor);
            Double lduV1=0,lduV2=0,lduV3=0,lduV4=0;
            Thickness lcrValor = new Thickness(0);
            if (lnuTotLista == 1 || lnuTotLista==0)
            {
                    lduV1 = Convert.ToDouble(tcrValor);
                    lcrValor = new Thickness(lduV1);
            }
             else
            {
                    lduV1 = Convert.ToDouble( Funciones.fuxExtraerElemento(1, ",", tcrValor));
                    lduV2 = Convert.ToDouble( Funciones.fuxExtraerElemento(2, ",", tcrValor));
                    lduV3 = Convert.ToDouble( Funciones.fuxExtraerElemento(3, ",", tcrValor));
                    lduV4 = Convert.ToDouble( Funciones.fuxExtraerElemento(4, ",", tcrValor));
                    lcrValor = new Thickness(lduV1,lduV2,lduV3,lduV4);
            }
            return lcrValor;
        }
        #endregion
        #region SetSolidColorBrush
        /// <summary>
        /// <para>Convertir propiedad de tipo texto a SolidColorBrush</para>
        /// </summary>
        public static SolidColorBrush SetSolidColorBrush(String tcrValor)
        {
            var lsbColor = Brushes.Black;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    lsbColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(tcrValor));
                }
            }
            return lsbColor;
        }
        #endregion
        #region SetSolidColorBrush Sobrecarga SolidColorBrush
        /// <summary>
        /// <para>Convertir propiedad de tipo texto a SolidColorBrush sobrecargado SolidColorBrush</para>
        /// </summary>
        public static SolidColorBrush SetSolidColorBrush(String tcrValor, Brush tschColor)
        {
            var lsbColor = (SolidColorBrush)tschColor;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    lsbColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(tcrValor));
                }
            }
            return lsbColor;
        }
        #endregion
        #region SetSolidColorBrush Sobrecarga String Color Default
        /// <summary>
        /// <para>Convertir propiedad de tipo texto a SolidColorBrush sobrecargado Sobrecarga String Color Default</para>
        /// </summary>
        public static SolidColorBrush SetSolidColorBrush(String tcrValor, String tcrDflColor)
        {
            var lsbColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(tcrDflColor));
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    lsbColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(tcrValor));
                }
            }
            return lsbColor;
        }
        #endregion
        #region SetFontFamily
        /// <summary>
        /// <para>Convertir fuente de tipo texto a FontFamily</para>
        /// </summary>
        public static FontFamily SetFontFamily(String tcrValor)
        {
            var lfntFont = new FontFamily("Arial");
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    lfntFont = new FontFamily(tcrValor);
                }
            }
            return lfntFont;
        }
        #endregion
        #region SetFontSize
        /// <summary>
        /// <para>Convertir tamaño fuente de tipo texto a Double</para>
        /// </summary>
        public static Double SetFontSize(String tcrValor)
        {
            Double lduSize = 12;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    lduSize = Convert.ToDouble(tcrValor);
                }
            }
            return lduSize;
        }
        #endregion
        #region SetFontWeight
        /// <summary>
        /// <para>Convertir tipo fuente negrita de texto a FontWeight</para>
        /// </summary>
        public static FontWeight SetFontWeight(String tcrValor)
        {
            FontWeight luxFontWeight = FontWeights.Regular;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    luxFontWeight = (tcrValor == "Bold") ? FontWeights.Bold : FontWeights.Regular;
                }
            }
            return luxFontWeight;
        }
        #endregion
        #region SetFontStyle
        /// <summary>
        /// <para>Convertir tipo fuente cursiva de texto a FontStyles</para>
        /// </summary>
        public static FontStyle SetFontStyle(String tcrValor)
        {
            FontStyle luxFontStyles = FontStyles.Normal;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    luxFontStyles = (tcrValor == "Italic") ? FontStyles.Italic : FontStyles.Normal;
                }
            }
            return luxFontStyles;
        }
        #endregion
        #region SetTextAlignment
        /// <summary>
        /// <para>Convertir alineacion texto de tipo texto a TextAlignment</para>
        /// </summary>
        public static TextAlignment SetTextAlignment(String tcrValor)
        {
            var luxTextAlignment = TextAlignment.Left;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    switch (tcrValor)
                    {
                        case "Left":
                            luxTextAlignment = TextAlignment.Left;
                            break;

                        case "Right":
                            luxTextAlignment = TextAlignment.Right;
                            break;

                        case "Center":
                            luxTextAlignment = TextAlignment.Center;
                            break;

                        case "Justify":
                            luxTextAlignment = TextAlignment.Justify;
                            break;
                    }
                }
            }
            return luxTextAlignment;
        }
        #endregion
        #region SetBorderThickness
        /// <summary>
        /// <para>Convertir propiedad de texto a tipo BorderThickness para objetos</para>
        /// </summary>
        public static Thickness SetBorderThickness(String tcrValor)
        {
           return SetBorder(tcrValor);
        }
        #endregion
        #region SetStrokeThickness
        /// <summary>
        /// <para>Convertir propiedad de texto a tipo StrokeThickness para objetos</para>
        /// </summary>
        public static Double SetStrokeThickness(String tcrValor)
        {
            Double lduSetStroke = 1;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    lduSetStroke = Convert.ToDouble(tcrValor);
                }
            }
            return lduSetStroke;
        }
        #endregion
        #region SetBorder
        /// <summary>
        /// <para>Convertir propiedad de texto a tipo Border para objetos</para>
        /// </summary>
        public static Thickness SetBorder(String tcrValor)
        {
            tcrValor = String.IsNullOrWhiteSpace(tcrValor) ? "1" : tcrValor;

            int lnuTotLista = Funciones.fnuContarElemListaString(",", tcrValor);
            Double lduV1 = 0, lduV2 = 0, lduV3 = 0, lduV4 = 0;
            Thickness lcrValor = new Thickness(0);
            if (lnuTotLista == 1 || lnuTotLista == 0)
            {
                lduV1 = Convert.ToDouble(tcrValor);
                lcrValor = new Thickness(lduV1);
            }
            else
            {
                lduV1 = Convert.ToDouble(Funciones.fuxExtraerElemento(1, ",", tcrValor));
                lduV2 = Convert.ToDouble(Funciones.fuxExtraerElemento(2, ",", tcrValor));
                lduV3 = Convert.ToDouble(Funciones.fuxExtraerElemento(3, ",", tcrValor));
                lduV4 = Convert.ToDouble(Funciones.fuxExtraerElemento(4, ",", tcrValor));
                lcrValor = new Thickness(lduV1, lduV2, lduV3, lduV4);
            }
            return lcrValor;
        }
        #endregion
        #region SetStretch
        /// <summary>
        /// <para>Convertir propiedad de texto a tipo Stretch (Aujuste de Imagen jpg...)</para>
        /// </summary>
        public static Stretch SetStretch(String tcrValor)
        {
            Stretch lcrValor = Stretch.Fill;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    switch (tcrValor)
                    {
                        case "Fill":
                            lcrValor = Stretch.Fill;
                            break;

                        case "None":
                            lcrValor = Stretch.None;
                            break;

                        case "Uniform":
                            lcrValor = Stretch.Uniform;
                            break;

                        case "UniformToFill":
                            lcrValor = Stretch.UniformToFill;
                            break;
                    }
                }
            }
            return lcrValor;
        }
        #endregion
        #region SetStretchDirection
        /// <summary>
        /// <para>Convertir propiedad de texto a tipo StretchDirection (Aujuste de Imagen jpg...)</para>
        /// </summary>
        public static StretchDirection SetStretchDirection(String tcrValor)
        {
            StretchDirection lcrValor = StretchDirection.Both;
            if (tcrValor != null)
            {
                if (!String.IsNullOrWhiteSpace(tcrValor))
                {
                    switch (tcrValor)
                    {
                        case "Both":
                            lcrValor = StretchDirection.Both;
                            break;

                        case "DownOnly":
                            lcrValor = StretchDirection.DownOnly;
                            break;

                        case "UpOnly":
                            lcrValor = StretchDirection.UpOnly;
                            break;
                    }
                }
            }
            return lcrValor;
        }
        #endregion
        #region SetBitmapImageUri: Cargar una imagen desde ruta servidor
        /// <summary>
        /// <para>Cargar una imagen desde ruta servidor</para>
        /// </summary>
        public static BitmapImage SetBitmapImageUri(ObjetoBitmapImage tobUri)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            BitmapImage lobImagen = null;
            var lcrNombreArchivo = tobUri.NombreArchivo.Trim();
            var lcrRutaDestino = tobUri.AppIpServidor.Trim() + @"\" + tobUri.AppInicioPath.Trim() + @"\" + tobUri.RutaGaleria.Trim();

            if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
            {
                lcrRutaDestino = @"\\" + tobUri.AppIpServidor.Trim() + @"\" + tobUri.AppInicioPath.Trim() + @"\" + tobUri.RutaGaleria.Trim();
            }
            try
            {
                //String lcrArchivoDestino = System.IO.Path.Combine(lcrRutaDestino, lcrNombreArchivo);
                String lcrArchivoDestino = lcrRutaDestino.Trim() + @"\" + lcrNombreArchivo.Trim();
                if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                {
                    lcrArchivoDestino = System.IO.Path.Combine(lcrRutaDestino, lcrNombreArchivo);
                }

                if (File.Exists(lcrArchivoDestino))
                {
                    var lobUri = new Uri(lcrArchivoDestino, UriKind.RelativeOrAbsolute);
                    lobImagen = new BitmapImage(lobUri);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Utilidades Error Metodo: SetBitmapImageUri");
            }
            return lobImagen;
        }
        #endregion
        #region SetTituloObjeto : Devolver el valor para texto titulo segun el estado visible
        /// <summary>
        /// <para>Devolver el valor para texto titulo segun el estado visible</para>
        /// </summary>
        public static String SetTituloObjeto(String tcrTextoTitulo, String tcrValorEstado)
        {
            String lcrValor = tcrTextoTitulo;
            if (!String.IsNullOrWhiteSpace(tcrTextoTitulo))
            {
                lcrValor = tcrValorEstado == "False" ? String.Empty : tcrTextoTitulo;
            }
            return lcrValor;
        }
        #endregion
        #region SetToolTip : Devolver el valor para texto ayuda 
        /// <summary>
        /// <para>Devolver el valor para texto ayuda, cuando es vacio devuelve null </para>
        /// <para>para que no se muestre la vista del tooltip vacia.</para>
        /// </summary>
        public static String SetToolTip(String tcrTexto)
        {
            var lcrValor = !String.IsNullOrWhiteSpace(tcrTexto) ? tcrTexto : null;
            return lcrValor;
        }
        #endregion
        #region SetEstadoTrueFalse : Devolver el valor estado True o False o valor por defecto
        /// <summary>
        /// <para>Devolver el valor estado True o False o valor por defecto</para>
        /// <para>tcrValor: debe contener el valor "True" o "False"</para>
        /// </summary>
        public static bool SetEstadoTrueFalse(String tcrValor, bool tlgValorDefecto)
        {
            bool lcrValor = tlgValorDefecto;
            if (!String.IsNullOrWhiteSpace(tcrValor))
            {
                lcrValor = tcrValor == "False" ? false : true;
            }
            return lcrValor;
        }
        #endregion
        #region SetRealListaValorDefault: Asiganar valor ValorDefault real Lsita de items 
        /// <summary>
        /// <para>Buscar el valor ValorDefault dado en el parametro tcrValorDefault dentro de la lista,</para>
        /// <para>devuelve el mismo ValorDefault cuando exite, cuando no existe,</para>
        /// <para>retorna el primer item de la lista como el nuevo ValorDefault</para>
        /// <para>tcrTipoValor:</para>
        /// <para>"INDICE" = Retorna como ValorDefault el indice (1,2,3,...) del item en la lista</para>
        /// <para>"CODIGO" = Retorna  como ValorDefault el codigo del item en la lista.</para>
        /// </summary>
        public static String SetRealListaValorDefault(String tcrTipoValor, String tcrValorDefault, List<VistaModeloObjetoActivo.ListaXmlValores> tlsLista)
        {
            String lnuValor = String.Empty;
            if (tlsLista.Count > 0)
            {
                var lcrQuery = (from lst in tlsLista
                               where lst.Codigo.Equals(tcrValorDefault)
                               select new VistaModeloObjetoActivo.ListaXmlValores
                               {
                                   Indice = lst.Indice,
                                   Codigo = lst.Codigo,
                                   Descripcion = lst.Descripcion
                               }).ToList();

                if (lcrQuery.Count == 0)
                {
                    if (tcrTipoValor == "CODIGO")
                    {
                        lnuValor = tlsLista.FirstOrDefault().Codigo;
                    }
                    else
                    {
                        lnuValor = tlsLista.FirstOrDefault().Indice;
                    }
                }
                else 
                {
                    if (tcrTipoValor == "CODIGO")
                    {
                        lnuValor = lcrQuery.FirstOrDefault().Codigo;
                    }
                    else
                    {
                        lnuValor = lcrQuery.FirstOrDefault().Indice;
                    }
                }
            }
            lnuValor = String.IsNullOrWhiteSpace(lnuValor) && tcrTipoValor == "INDICE"? "0" : lnuValor;

            return lnuValor;
        }
        #endregion
        #region SetObjetoComboBoxValorDefault: Asiganar valor real ValorDefault a ComboBox
        /// <summary>
        /// <para>Buscar el valor ValorDefault dado en el parametro tcrValorDefault dentro de la lista,</para>
        /// <para>devuelve el mismo ValorDefault cuando exite, cuando no existe,</para>
        /// <para>retorna el primer item de la lista como el nuevo ValorDefault</para>
        /// </summary>
        public static int SetObjetoComboBoxValorDefault(String ValorDefault, List<VistaModeloObjetoActivo.ListaXmlValores> tlsLista)
        {
            var lnuValor = 0;
            String lcrValor = SetRealListaValorDefault("INDICE",ValorDefault, tlsLista);
            lnuValor = lcrValor!="0"? (Convert.ToInt32(lcrValor) - 1) : 0;

            return lnuValor;
        }
        #endregion
        #region SetObjetoComboBoxValorDefault: Asiganar valor real ValorDefault a ComboBox SobreCargado
        /// <summary>
        /// <para>Buscar el valor ValorDefault dado en el parametro tcrValorDefault dentro de la lista,</para>
        /// <para>devuelve el mismo ValorDefault cuando exite, cuando no existe, retorna</para>
        /// <para>tnuIndiceDefault de la lista como el nuevo ValorDefault</para>
        /// </summary>
        public static int SetObjetoComboBoxValorDefault(int tnuIndiceDefault, String ValorDefault, List<VistaModeloObjetoActivo.ListaXmlValores> tlsLista)
        {
            var lnuValor = 0;
            String lcrValor = SetRealListaValorDefault("INDICE", ValorDefault, tlsLista);
            lnuValor = lcrValor != "0" ? (Convert.ToInt32(lcrValor) - 1) : tnuIndiceDefault;

            return lnuValor;
        }
        #endregion
        //------------------------------------------------------------
        // VALIDAR PARA SABER SI NUEVO OBJETO PUEDE SER ADICIONADO
        //------------------------------------------------------------
        #region flgSiContenedorAdicionarObjeto : Validar si tcrNuevoTipoObjeto se puede adicionar
        /// <summary>
        /// <para>Validar si tcrNuevoTipoObjeto se puede adicionar en el objeto contenedor tcrTipoContenedor</para>
        /// </summary>
        public static bool flgSiContenedorAdicionarObjeto(String tcrTipoContenedor, String tcrNuevoTipoObjeto)
        {
            var llgReturn = false;
            String lcrExepcion = String.Empty;
            String lcrLista = String.Empty;

            switch (tcrTipoContenedor)
            {
                case "PAGINA":
                    llgReturn = tcrNuevoTipoObjeto == "ZONA" ? true : false;
                    break;

                case "ZONA":
                    lcrExepcion = "ZONA,MULTIRADIOBUTTON,RADIOBUTTON,MULTICHKBOX,CHECKBOX";
                    llgReturn = !Funciones.flgExisteElemento(tcrNuevoTipoObjeto, ",", lcrExepcion);
                    break;

                case "GROUPBOX":
                    lcrExepcion = "ZONA,MULTIRADIOBUTTON,RADIOBUTTON,CONTROLADMISION,MULTICHKBOX,CHECKBOX";
                    llgReturn = !Funciones.flgExisteElemento(tcrNuevoTipoObjeto, ",", lcrExepcion);
                    break;

                case "MULTIGROUPRADIOBUTTON":
                    lcrLista = "MULTIRADIOBUTTON,RADIOBUTTON";
                    llgReturn = Funciones.flgExisteElemento(tcrNuevoTipoObjeto, ",", lcrLista);
                    break;

                case "MULTIGROUPCHKBOX":
                    lcrLista = "MULTICHKBOX,CHECKBOX";
                    llgReturn = Funciones.flgExisteElemento(tcrNuevoTipoObjeto, ",", lcrLista);
                    break;
            }
            return llgReturn;
        }
        #endregion
        //------------------------------------------------------------
        //  ABRIR EL EXPLORADOR PARA BUSCAR ARCHIVOS
        //------------------------------------------------------------
        #region fobBuscarArchivoRecurso: Abrir el explorador de windows para buscar un archivo de recurso
        /// <summary>
        /// <para>Abrir el explorador de windows para buscar un archivo de recurso</para>
        /// <para>tcrExtPorDefecto: ".jpg"</para>
        /// <para>tcrFiltro: "Buscar imagenes (*.bmp, *.png, *.jpg)|*.bmp;*.png;*.jpg" </para>
        /// </summary>
        public static ArchivoRecurso fobBuscarArchivoRecurso(String tcrTitulo, String tcrExtPorDefecto, String tcrFiltro)
        {
            ArchivoRecurso lobValor = null;

            OpenFileDialog lopenFileDialog = new OpenFileDialog();
            lopenFileDialog.Title = tcrTitulo;
            lopenFileDialog.Filter = tcrFiltro;
            lopenFileDialog.DefaultExt = tcrExtPorDefecto; // Extencion de archivos por defecto
            lopenFileDialog.FilterIndex = 1;
            lopenFileDialog.Multiselect = false;
            bool? llgSelectOK = lopenFileDialog.ShowDialog();

            if (llgSelectOK == true)
            {
                lobValor = new ArchivoRecurso();
                lobValor.RutayArchivo= lopenFileDialog.FileName;
                lobValor.NombreArchivo = lopenFileDialog.SafeFileName;
            }
            return lobValor;
        }
        #endregion
        //------------------------------------------------------------
        //  TIPO CAMPO
        //------------------------------------------------------------
        #region fcrDescripcionTipoCampoRelacion : Descripcion del tipo de campo
        /// <summary>
        /// <para>Devuelve la descripcion del tipo de campo</para>
        /// </summary>
        public static String fcrDescripcionTipoCampoRelacion(String tcrTipoCampo)
        {
            var llgReturn = String.Empty;

            switch (tcrTipoCampo)
            {
                case "C":
                    llgReturn = tcrTipoCampo + ": TEXTO";
                    break;

                case "D":
                    llgReturn = tcrTipoCampo + ": FECHA";
                    break;

                case "N":
                    llgReturn = tcrTipoCampo + ": NUMERICO";
                    break;

                case "F":
                    llgReturn = tcrTipoCampo + ": NUMERICO FLOTANTE";
                    break;

                case "R":
                    llgReturn = tcrTipoCampo + ": RELACION TABLA";
                    break;

                case "H":
                    llgReturn = tcrTipoCampo + ": HORA (FORMATO MILITAR)";
                    break;

                default:
                    llgReturn = tcrTipoCampo + ": INDEFINIDO";
                    break;
            }
            return llgReturn;
        }
        #endregion

    }
}



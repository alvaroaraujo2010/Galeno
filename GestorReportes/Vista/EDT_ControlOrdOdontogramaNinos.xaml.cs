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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sistema.Vista;
using Sistema.Utilidades;
using Sistema.Clases;
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_ControlOrdOdontogramaNinos.xaml
    /// </summary>
    public partial class OdontogramaNinos : UserControl
    {
        public String lcrUri = "/GestorReportes;component/Imagenes/";
        public String lcrRutaImagen = @"GaleriaRecursos\Imagenes\Odontologia\";
        Aplicacion oApp = Aplicacion.Instancia();
        public List<Registro> tmpRegistro = new List<Registro>();

        public OdontogramaNinos()
        {
            InitializeComponent();
        }
        #region Cargar vista del diente 01
        private void fcvLoadDiente01(object sender, RoutedEventArgs e)
        {
            Diente01 lobControl = (Diente01)sender;
            var lcrNumero = lobControl.Name.Substring(1, 2);
            lobControl.imgDiente.Source = new BitmapImage(new Uri(lcrUri + "hc_od_diente" + lcrNumero + ".png", UriKind.RelativeOrAbsolute));
            lobControl.lblNumero.Text = lcrNumero;
            lobControl.gnuNumeroDiente = (int)Convert.ToUInt32(lcrNumero);
        }
        #endregion
        #region Cargar vista del diente 02
        private void fcvLoadDiente02(object sender, RoutedEventArgs e)
        {
            Diente02 lobControl = (Diente02)sender;
            var lcrNumero = lobControl.Name.Substring(1, 2);
            lobControl.imgDiente.Source = new BitmapImage(new Uri(lcrUri + "hc_od_diente" + lcrNumero + ".png", UriKind.RelativeOrAbsolute));
            lobControl.lblNumero.Text = lcrNumero;
            lobControl.gnuNumeroDiente = (int)Convert.ToUInt32(lcrNumero);
        }
        #endregion
        #region fcvGraficarImgenEnDiente: Mostrar vista imagen a graficar en diente
        /// <summary>
        /// <para>fcvGraficarImgenEnDiente()</para>
        /// <para>DESCRIPCION:</para>
        /// <para> Genera la imagen y la grafica en la zona indicada del Diente</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrIdRegistro: Numero unico del registro para localizar imagen graficada</para>
        /// <para>tcrNumeroDiente: Numero que representa la pieza dental en el odontograma ejm: "11", "12", "21"...</para>
        /// <para>tcrZonaGrafica: "1" = Graficar en Corona "2" = Graficar en Corona Diente "3" = Graficar en Raiz Diente</para>
        /// <para>"4" = Diente completo "5" = Base diente (encia)</para>
        /// <para>tcrNombreImagen: Nimbre de la imagen en formato JPG, PNG u otros formatos de imagen</para>
        /// <para>tcrOcultarItem: "1" = Ocultar la imagen principal del diente "2" = No Ocultar la imagen principal del diente</para>
        /// </summary>
        public void fcvGraficarImgenEnDiente(String tcrIdRegistro, String tcrNumeroDiente, String tcrZonaGrafica, String tcrNombreImagen, String tcrOcultarItem)
        {
            FrameworkElement lobjDiente = null;
            var lcrTipoDiente = "1";
            switch (tcrNumeroDiente)
            {
                #region Cuadrante 1
                case "51":
                    lobjDiente = this.D51;
                    break;
                case "52":
                    lobjDiente = this.D52;
                    break;
                case "53":
                    lobjDiente = this.D53;
                    break;
                case "54":
                    lobjDiente = this.D54;
                    break;
                case "55":
                    lobjDiente = this.D55;
                    break;
                #endregion
                #region Cuadrante 2
                case "61":
                    lobjDiente = this.D61;
                    break;
                case "62":
                    lobjDiente = this.D62;
                    break;
                case "63":
                    lobjDiente = this.D63;
                    break;
                case "64":
                    lobjDiente = this.D64;
                    break;
                case "65":
                    lobjDiente = this.D65;
                    break;
                #endregion
                #region Cuadrante 3
                case "71":
                    lobjDiente = this.D71;
                    break;
                case "72":
                    lobjDiente = this.D72;
                    break;
                case "73":
                    lobjDiente = this.D73;
                    break;
                case "74":
                    lobjDiente = this.D74;
                    break;
                case "75":
                    lobjDiente = this.D75;
                    break;
                #endregion
                #region Cuadrante 4
                case "81":
                    lobjDiente = this.D81;
                    break;
                case "82":
                    lobjDiente = this.D82;
                    break;
                case "83":
                    lobjDiente = this.D83;
                    break;
                case "84":
                    lobjDiente = this.D84;
                    break;
                case "85":
                    lobjDiente = this.D85;
                    break;
                #endregion
            }
            // Tipo diente
            lcrTipoDiente = Convert.ToInt32(tcrNumeroDiente) >= 51 && Convert.ToInt32(tcrNumeroDiente) <= 65 ? "1" : "2";
            // generar la ruta Uri
            var lcrUriAux = lcrRutaImagen + tcrNombreImagen;

            // Cargar en la vista del odontograma
            if (lcrTipoDiente == "1")
            {
                Diente01 lobDiente = (Diente01)lobjDiente;
                lobDiente.gnuNumeroDiente = Convert.ToInt32(tcrNumeroDiente);
                fcvGraficarImagenEnDiente01(tcrIdRegistro, ref lobDiente, tcrZonaGrafica, tcrNombreImagen, tcrOcultarItem);
            }
            else
            {
                Diente02 lobDiente = (Diente02)lobjDiente;
                lobDiente.gnuNumeroDiente = Convert.ToInt32(tcrNumeroDiente);
                fcvGraficarImagenEnDiente02(tcrIdRegistro, ref lobDiente, tcrZonaGrafica, tcrNombreImagen, tcrOcultarItem);
            }
        }
        #endregion
        #region fcvGraficarImagenEnDiente01: Mostrar imagen a graficar en diente
        /// <summary>
        /// <para>fcvGraficarImagenEnDiente01()</para>
        /// <para>DESCRIPCION:</para>
        /// <para> Genera la imagen y la grafica en la zona indicada del Diente</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrZonaGrafica: "1" = Graficar en Corona "2" = Graficar en Corona Diente "3" = Graficar en Raiz Diente</para>
        /// <para>"4" = Diente completo "5" = Base diente (encia)</para>
        /// <para>tcrOcultarItem: "1" = Ocultar la imagen principal del diente "2" = No Ocultar la imagen principal del diente</para>
        /// </summary>
        private void fcvGraficarImagenEnDiente01(String tcrIdRegistro, ref Diente01 tobjDiente, String tcrZonaGrafica, String tcrNombreImagen, String tcrOcultarItem)
        {

            Image lobObjeto = new Image();
            var lobUri = new EdtUtilidades.ObjetoBitmapImage();

            lobUri.AppIpServidor = oApp.gcrAppRecursoIpServidor;
            lobUri.AppInicioPath = oApp.gcrAppRecursoInicioPath;
            lobUri.RutaGaleria = lcrRutaImagen;
            lobUri.NombreArchivo = tcrNombreImagen;
            lobObjeto.Source = EdtUtilidades.SetBitmapImageUri(lobUri);
            lobObjeto.Stretch = Stretch.Fill;
            flgAddRegistroRefImagen01(tcrIdRegistro, tobjDiente.gnuNumeroDiente.ToString(), ref tobjDiente, ref lobObjeto);

            switch (tcrZonaGrafica)
            {
                case "1":
                    lobObjeto.Height = 55;
                    lobObjeto.Width = 50;
                    Canvas.SetLeft(lobObjeto, -3);
                    Canvas.SetTop(lobObjeto, -7);
                    tobjDiente.cnvCorona.Children.Add(lobObjeto);
                    break;

                case "2":
                    lobObjeto.Height = 48;
                    lobObjeto.Width = 44;
                    Canvas.SetLeft(lobObjeto, 0);
                    Canvas.SetTop(lobObjeto, -4);
                    tobjDiente.cnvDienteCorona.Children.Add(lobObjeto);
                    break;

                case "3":
                    lobObjeto.Height = 90;
                    lobObjeto.Width = 50;
                    Canvas.SetLeft(lobObjeto, -2);
                    Canvas.SetTop(lobObjeto, 0);
                    tobjDiente.cnvDienteRaiz.Children.Add(lobObjeto);
                    break;

                case "4":
                    lobObjeto.Height = 140;
                    lobObjeto.Width = 50;
                    Canvas.SetLeft(lobObjeto, -4);
                    Canvas.SetTop(lobObjeto, 0);
                    tobjDiente.cnvDiente.Children.Add(lobObjeto);
                    break;

                case "5":
                    lobObjeto.Height = 100;
                    lobObjeto.Width = 42;
                    Canvas.SetLeft(lobObjeto, 0);
                    Canvas.SetTop(lobObjeto, -5);
                    tobjDiente.cnvBaseDiente.Children.Add(lobObjeto);
                    break;
            }
            if (tcrOcultarItem == "1")
            {
                tobjDiente.gnuContOcultDiente++;
                tobjDiente.imgDiente.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
        #region fcvGraficarImagenEnDiente02: Mostrar imagen a graficar en diente
        /// <summary>
        /// <para>fcvGraficarImagenEnDiente02()</para>
        /// <para>DESCRIPCION:</para>
        /// <para> Genera la imagen y la grafica en la zona indicada del Diente</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrZonaGrafica: "1" = Graficar en Corona "2" = Graficar en Corona Diente "3" = Graficar en Raiz Diente</para>
        /// <para>"4" = Diente completo "5" = Base diente (encia)</para>
        /// <para>tcrOcultarItem: "1" = Ocultar la imagen principal del diente "2" = No Ocultar la imagen principal del diente</para>
        /// </summary>
        private void fcvGraficarImagenEnDiente02(String tcrIdRegistro, ref Diente02 tobjDiente, String tcrZonaGrafica, String tcrNombreImagen, String tcrOcultarItem)
        {

            Image lobObjeto = new Image();
            var lobUri = new EdtUtilidades.ObjetoBitmapImage();

            lobUri.AppIpServidor = oApp.gcrAppRecursoIpServidor;
            lobUri.AppInicioPath = oApp.gcrAppRecursoInicioPath;
            lobUri.RutaGaleria = lcrRutaImagen;
            lobUri.NombreArchivo = tcrNombreImagen;
            lobObjeto.Source = EdtUtilidades.SetBitmapImageUri(lobUri);
            lobObjeto.Stretch = Stretch.Uniform;
            flgAddRegistroRefImagen02(tcrIdRegistro, tobjDiente.gnuNumeroDiente.ToString(), ref tobjDiente, ref lobObjeto);

            switch (tcrZonaGrafica)
            {
                case "1":
                    lobObjeto.Height = 55;
                    lobObjeto.Width = 50;
                    Canvas.SetLeft(lobObjeto, -3);
                    Canvas.SetTop(lobObjeto, -7);
                    tobjDiente.cnvCorona.Children.Add(lobObjeto);
                    break;

                case "2":
                    lobObjeto.Height = 50;
                    lobObjeto.Width = 50;
                    Canvas.SetLeft(lobObjeto, -3);
                    Canvas.SetTop(lobObjeto, -6);
                    tobjDiente.cnvDienteCorona.Children.Add(lobObjeto);
                    break;

                case "3":
                    lobObjeto.Height = 90;
                    lobObjeto.Width = 48;
                    Canvas.SetLeft(lobObjeto, -1);
                    Canvas.SetTop(lobObjeto, -1);
                    tobjDiente.cnvDienteRaiz.Children.Add(lobObjeto);
                    break;

                case "4":
                    lobObjeto.Height = 130;
                    lobObjeto.Width = 50;
                    Canvas.SetLeft(lobObjeto, -2);
                    Canvas.SetTop(lobObjeto, 0);
                    tobjDiente.cnvDiente.Children.Add(lobObjeto);
                    break;

                case "5":
                    lobObjeto.Height = 100;
                    lobObjeto.Width = 48;
                    Canvas.SetLeft(lobObjeto, -3);
                    Canvas.SetTop(lobObjeto, 0);
                    tobjDiente.cnvBaseDiente.Children.Add(lobObjeto);
                    break;
            }
            if (tcrOcultarItem == "1")
            {
                tobjDiente.gnuContOcultDiente++;
                tobjDiente.imgDiente.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
        #region fcvLimpiarImgenEnDiente: Limpiar imagen cargadas en diente
        /// <summary>
        /// <para>fcvLimpiarImgenEnDiente()</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Limpiar todas las zonas graficac del Diente</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumeroDiente: Numero que representa la pieza dental en el odontograma ejm: "51", "55", "73"...</para>
        /// </summary>
        public void fcvLimpiarImgenEnDiente(String tcrNumeroDiente)
        {
            FrameworkElement lobjDiente = null;
            var lcrTipoDiente = "1";
            switch (tcrNumeroDiente)
            {
                #region Cuadrante 1 Niños
                case "51":
                    lobjDiente = this.D51;
                    break;
                case "52":
                    lobjDiente = this.D52;
                    break;
                case "53":
                    lobjDiente = this.D53;
                    break;
                case "54":
                    lobjDiente = this.D54;
                    break;
                case "55":
                    lobjDiente = this.D55;
                    break;
                #endregion
                #region Cuadrante 2 Niños
                case "61":
                    lobjDiente = this.D61;
                    break;
                case "62":
                    lobjDiente = this.D62;
                    break;
                case "63":
                    lobjDiente = this.D63;
                    break;
                case "64":
                    lobjDiente = this.D64;
                    break;
                case "65":
                    lobjDiente = this.D65;
                    break;
                #endregion
                #region Cuadrante 3 Niños
                case "71":
                    lobjDiente = this.D71;
                    break;
                case "72":
                    lobjDiente = this.D72;
                    break;
                case "73":
                    lobjDiente = this.D73;
                    break;
                case "74":
                    lobjDiente = this.D74;
                    break;
                case "75":
                    lobjDiente = this.D75;
                    break;
                #endregion
                #region Cuadrante 4 Niños
                case "81":
                    lobjDiente = this.D81;
                    break;
                case "82":
                    lobjDiente = this.D82;
                    break;
                case "83":
                    lobjDiente = this.D83;
                    break;
                case "84":
                    lobjDiente = this.D84;
                    break;
                case "85":
                    lobjDiente = this.D85;
                    break;
                #endregion
            }
            // Tipo diente
            lcrTipoDiente = Convert.ToInt32(tcrNumeroDiente) >= 51 && Convert.ToInt32(tcrNumeroDiente) <= 65 ? "1" : "2";

            // Cargar en la vista del odontograma
            if (lcrTipoDiente == "1")
            {
                Diente01 lobDiente = (Diente01)lobjDiente;

                lobDiente.cnvCorona.Children.Clear();
                lobDiente.cnvDienteCorona.Children.Clear();
                lobDiente.cnvDienteRaiz.Children.Clear();
                lobDiente.cnvDiente.Children.Clear();
                lobDiente.cnvBaseDiente.Children.Clear();
                lobDiente.gnuContOcultDiente = 0;
                lobDiente.imgDiente.Visibility = Visibility.Visible;
            }
            else
            {
                Diente02 lobDiente = (Diente02)lobjDiente;

                lobDiente.cnvCorona.Children.Clear();
                lobDiente.cnvDienteCorona.Children.Clear();
                lobDiente.cnvDienteRaiz.Children.Clear();
                lobDiente.cnvDiente.Children.Clear();
                lobDiente.cnvBaseDiente.Children.Clear();
                lobDiente.gnuContOcultDiente = 0;
                lobDiente.imgDiente.Visibility = Visibility.Visible;
            }
            flgEliminarImagenVistaDiente(tcrNumeroDiente);
        }
        #endregion
        #region fcvLimpiarOdontograma: Limpiar todo el odontograma
        /// <summary>
        /// <para>fcvLimpiarOdontograma()</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Limpiar todos los objetos del Odontograma</para>
        /// </summary>
        public void fcvLimpiarOdontograma()
        {
            tmpRegistro = new List<Registro>();
            #region Cuadrante 1
            this.D51.cnvCorona.Children.Clear();
            this.D51.cnvDienteCorona.Children.Clear();
            this.D51.cnvDienteRaiz.Children.Clear();
            this.D51.cnvDiente.Children.Clear();
            this.D51.cnvBaseDiente.Children.Clear();
            this.D51.imgDiente.Visibility = Visibility.Visible;

            this.D52.cnvCorona.Children.Clear();
            this.D52.cnvDienteCorona.Children.Clear();
            this.D52.cnvDienteRaiz.Children.Clear();
            this.D52.cnvDiente.Children.Clear();
            this.D52.cnvBaseDiente.Children.Clear();
            this.D52.imgDiente.Visibility = Visibility.Visible;

            this.D53.cnvCorona.Children.Clear();
            this.D53.cnvDienteCorona.Children.Clear();
            this.D53.cnvDienteRaiz.Children.Clear();
            this.D53.cnvDiente.Children.Clear();
            this.D53.cnvBaseDiente.Children.Clear();
            this.D53.imgDiente.Visibility = Visibility.Visible;

            this.D54.cnvCorona.Children.Clear();
            this.D54.cnvDienteCorona.Children.Clear();
            this.D54.cnvDienteRaiz.Children.Clear();
            this.D54.cnvDiente.Children.Clear();
            this.D54.cnvBaseDiente.Children.Clear();
            this.D54.imgDiente.Visibility = Visibility.Visible;

            this.D55.cnvCorona.Children.Clear();
            this.D55.cnvDienteCorona.Children.Clear();
            this.D55.cnvDienteRaiz.Children.Clear();
            this.D55.cnvDiente.Children.Clear();
            this.D55.cnvBaseDiente.Children.Clear();
            this.D55.imgDiente.Visibility = Visibility.Visible;
            #endregion
            #region Cuadrante 2
            this.D61.cnvCorona.Children.Clear();
            this.D61.cnvDienteCorona.Children.Clear();
            this.D61.cnvDienteRaiz.Children.Clear();
            this.D61.cnvDiente.Children.Clear();
            this.D61.cnvBaseDiente.Children.Clear();
            this.D61.imgDiente.Visibility = Visibility.Visible;

            this.D62.cnvCorona.Children.Clear();
            this.D62.cnvDienteCorona.Children.Clear();
            this.D62.cnvDienteRaiz.Children.Clear();
            this.D62.cnvDiente.Children.Clear();
            this.D62.cnvBaseDiente.Children.Clear();
            this.D62.imgDiente.Visibility = Visibility.Visible;

            this.D63.cnvCorona.Children.Clear();
            this.D63.cnvDienteCorona.Children.Clear();
            this.D63.cnvDienteRaiz.Children.Clear();
            this.D63.cnvDiente.Children.Clear();
            this.D63.cnvBaseDiente.Children.Clear();
            this.D63.imgDiente.Visibility = Visibility.Visible;

            this.D64.cnvCorona.Children.Clear();
            this.D64.cnvDienteCorona.Children.Clear();
            this.D64.cnvDienteRaiz.Children.Clear();
            this.D64.cnvDiente.Children.Clear();
            this.D64.cnvBaseDiente.Children.Clear();
            this.D64.imgDiente.Visibility = Visibility.Visible;

            this.D65.cnvCorona.Children.Clear();
            this.D65.cnvDienteCorona.Children.Clear();
            this.D65.cnvDienteRaiz.Children.Clear();
            this.D65.cnvDiente.Children.Clear();
            this.D65.cnvBaseDiente.Children.Clear();
            this.D65.imgDiente.Visibility = Visibility.Visible;
            #endregion
            #region Cuadrante 3
            this.D71.cnvCorona.Children.Clear();
            this.D71.cnvDienteCorona.Children.Clear();
            this.D71.cnvDienteRaiz.Children.Clear();
            this.D71.cnvDiente.Children.Clear();
            this.D71.cnvBaseDiente.Children.Clear();
            this.D71.imgDiente.Visibility = Visibility.Visible;

            this.D72.cnvCorona.Children.Clear();
            this.D72.cnvDienteCorona.Children.Clear();
            this.D72.cnvDienteRaiz.Children.Clear();
            this.D72.cnvDiente.Children.Clear();
            this.D72.cnvBaseDiente.Children.Clear();
            this.D72.imgDiente.Visibility = Visibility.Visible;

            this.D73.cnvCorona.Children.Clear();
            this.D73.cnvDienteCorona.Children.Clear();
            this.D73.cnvDienteRaiz.Children.Clear();
            this.D73.cnvDiente.Children.Clear();
            this.D73.cnvBaseDiente.Children.Clear();
            this.D73.imgDiente.Visibility = Visibility.Visible;

            this.D74.cnvCorona.Children.Clear();
            this.D74.cnvDienteCorona.Children.Clear();
            this.D74.cnvDienteRaiz.Children.Clear();
            this.D74.cnvDiente.Children.Clear();
            this.D74.cnvBaseDiente.Children.Clear();
            this.D74.imgDiente.Visibility = Visibility.Visible;

            this.D75.cnvCorona.Children.Clear();
            this.D75.cnvDienteCorona.Children.Clear();
            this.D75.cnvDienteRaiz.Children.Clear();
            this.D75.cnvDiente.Children.Clear();
            this.D75.cnvBaseDiente.Children.Clear();
            this.D75.imgDiente.Visibility = Visibility.Visible;
            #endregion
            #region Cuadrante 4
            this.D81.cnvCorona.Children.Clear();
            this.D81.cnvDienteCorona.Children.Clear();
            this.D81.cnvDienteRaiz.Children.Clear();
            this.D81.cnvDiente.Children.Clear();
            this.D81.cnvBaseDiente.Children.Clear();
            this.D81.imgDiente.Visibility = Visibility.Visible;

            this.D82.cnvCorona.Children.Clear();
            this.D82.cnvDienteCorona.Children.Clear();
            this.D82.cnvDienteRaiz.Children.Clear();
            this.D82.cnvDiente.Children.Clear();
            this.D82.cnvBaseDiente.Children.Clear();
            this.D82.imgDiente.Visibility = Visibility.Visible;

            this.D83.cnvCorona.Children.Clear();
            this.D83.cnvDienteCorona.Children.Clear();
            this.D83.cnvDienteRaiz.Children.Clear();
            this.D83.cnvDiente.Children.Clear();
            this.D83.cnvBaseDiente.Children.Clear();
            this.D83.imgDiente.Visibility = Visibility.Visible;

            this.D84.cnvCorona.Children.Clear();
            this.D84.cnvDienteCorona.Children.Clear();
            this.D84.cnvDienteRaiz.Children.Clear();
            this.D84.cnvDiente.Children.Clear();
            this.D84.cnvBaseDiente.Children.Clear();
            this.D84.imgDiente.Visibility = Visibility.Visible;

            this.D85.cnvCorona.Children.Clear();
            this.D85.cnvDienteCorona.Children.Clear();
            this.D85.cnvDienteRaiz.Children.Clear();
            this.D85.cnvDiente.Children.Clear();
            this.D85.cnvBaseDiente.Children.Clear();
            this.D85.imgDiente.Visibility = Visibility.Visible;
            #endregion
        }
        #endregion
        #region fcvActivarCapaSeleccion: Activar capa vista seleccion
        /// <summary>
        /// <para>fcvActivarCapaSeleccion()</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Activar capa vista seleccion</para>
        /// </summary>
        public void fcvActivarCapaSeleccion(Visibility tcrVisibility)
        {
            #region Cuadrante 1 Niños
            this.D51.rctCapaSelect.Visibility = tcrVisibility;
            this.D52.rctCapaSelect.Visibility = tcrVisibility;
            this.D53.rctCapaSelect.Visibility = tcrVisibility;
            this.D54.rctCapaSelect.Visibility = tcrVisibility;
            this.D55.rctCapaSelect.Visibility = tcrVisibility;
            #endregion
            #region Cuadrante 2 Niños
            this.D61.rctCapaSelect.Visibility = tcrVisibility;
            this.D62.rctCapaSelect.Visibility = tcrVisibility;
            this.D63.rctCapaSelect.Visibility = tcrVisibility;
            this.D64.rctCapaSelect.Visibility = tcrVisibility;
            this.D65.rctCapaSelect.Visibility = tcrVisibility;
            #endregion
            #region Cuadrante 3 Niños
            this.D71.rctCapaSelect.Visibility = tcrVisibility;
            this.D72.rctCapaSelect.Visibility = tcrVisibility;
            this.D73.rctCapaSelect.Visibility = tcrVisibility;
            this.D74.rctCapaSelect.Visibility = tcrVisibility;
            this.D75.rctCapaSelect.Visibility = tcrVisibility;
            #endregion
            #region Cuadrante 4 Niños
            this.D81.rctCapaSelect.Visibility = tcrVisibility;
            this.D82.rctCapaSelect.Visibility = tcrVisibility;
            this.D83.rctCapaSelect.Visibility = tcrVisibility;
            this.D84.rctCapaSelect.Visibility = tcrVisibility;
            this.D85.rctCapaSelect.Visibility = tcrVisibility;
            #endregion
        }
        #endregion
        #region fcvMostrarSombraDiente: Mostra sombra en diente
        /// <summary>
        /// <para>fcvMostrarSombraDiente()</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Mostra sombra en diente</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrNumeroDiente: Numero que representa la pieza dental en el odontograma ejm: "11", "12", "21"...</para>
        /// <para>tcrAccion: "1" = Mostrar sombra "2" = Ocultar sombra...</para>
        /// </summary>
        public void fcvMostrarSombraDiente(String tcrNumeroDiente, String tcrAccion)
        {
            FrameworkElement lobjDiente = null;
            var lcrTipoDiente = "1";
            switch (tcrNumeroDiente)
            {
                #region Cuadrante 1 Niños
                case "51":
                    lobjDiente = this.D51;
                    break;
                case "52":
                    lobjDiente = this.D52;
                    break;
                case "53":
                    lobjDiente = this.D53;
                    break;
                case "54":
                    lobjDiente = this.D54;
                    break;
                case "55":
                    lobjDiente = this.D55;
                    break;
                #endregion
                #region Cuadrante 2 Niños
                case "61":
                    lobjDiente = this.D61;
                    break;
                case "62":
                    lobjDiente = this.D62;
                    break;
                case "63":
                    lobjDiente = this.D63;
                    break;
                case "64":
                    lobjDiente = this.D64;
                    break;
                case "65":
                    lobjDiente = this.D65;
                    break;
                #endregion
                #region Cuadrante 3 Niños
                case "71":
                    lobjDiente = this.D71;
                    break;
                case "72":
                    lobjDiente = this.D72;
                    break;
                case "73":
                    lobjDiente = this.D73;
                    break;
                case "74":
                    lobjDiente = this.D74;
                    break;
                case "75":
                    lobjDiente = this.D75;
                    break;
                #endregion
                #region Cuadrante 4 Niños
                case "81":
                    lobjDiente = this.D81;
                    break;
                case "82":
                    lobjDiente = this.D82;
                    break;
                case "83":
                    lobjDiente = this.D83;
                    break;
                case "84":
                    lobjDiente = this.D84;
                    break;
                case "85":
                    lobjDiente = this.D85;
                    break;
                #endregion
            }
            // Tipo diente
            lcrTipoDiente = Convert.ToInt32(tcrNumeroDiente) >= 51 && Convert.ToInt32(tcrNumeroDiente) <= 65 ? "1" : "2";

            // Cargar en la vista del odontograma
            if (lcrTipoDiente == "1")
            {
                Diente01 lobDiente = (Diente01)lobjDiente;

                lobDiente.rctCapaSombra.Visibility = tcrAccion == "1" ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                Diente02 lobDiente = (Diente02)lobjDiente;

                lobDiente.rctCapaSombra.Visibility = tcrAccion == "1" ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        #endregion
        //------------------------------------------------------------
        // GESTION TEMPORAL VISTA IMAGENES GRAFICADAS
        //------------------------------------------------------------
        #region Registro: temporarl para referencia de objetos en la vista
        /// <summary>
        /// <para>Temporarl para referenciar las imagenes graficadas en vista</para>
        /// </summary>
        public class Registro
        {
            public String IdRegistro { get; set; }              // llave unica del registro para busqueda de la referencia a imagen
            public String IdDiente { get; set; }                // Id del diente donde se grafica la imagen
            public FrameworkElement RefDiente { get; set; }     // Referencia al diente del odontograma
            public FrameworkElement RefObjeto { get; set; }     // Referencia a instancia del Objeto imagen en vista
        }
        #endregion
        #region fobRegSelectRegistro : Seleccionar registros desde temporal vista
        /// <summary>
        /// <para>Seleccionar registro desde temporal vista de imagenes graficadas</para>
        /// <para>tcrTipollave: "IMAGEN" = Devuelve el registro segun llave de la imagen</para>
        /// <para> "DIENTE" = Devuelve todos los registrs de las imagenes cargadas en el diente dado</para>
        /// <para>tcrLlave:Puede ser el Id unico de una imagen o el numero de un diente en particular</para>
        /// </summary>
        private List<Registro> fobRegSelectRegistro(String tcrTipollave, String tcrLlave)
        {
            List<Registro> lcrQuery = null;

            if (tmpRegistro != null)
            {
                if (tcrTipollave == "IMAGEN")
                {
                    lcrQuery = (from lst in tmpRegistro
                                where lst.IdRegistro.Equals(tcrLlave)
                                select lst).ToList();
                }
                else
                {
                    lcrQuery = (from lst in tmpRegistro
                                where lst.IdDiente.Equals(tcrLlave)
                                select lst).ToList();
                }
            }
            return lcrQuery;
        }
        #endregion
        #region flgEliminarImagenEnVista : Eliminar una imagen graficada en vista odontograma
        /// <summary>
        /// <para>Eliminar una imagen graficada en vista odontograma</para>
        /// </summary>
        public bool flgEliminarImagenEnVista(String tcrLlave)
        {
            var llgReturn = false;
            var lobTempQuery = fobRegSelectRegistro("IMAGEN", tcrLlave);

            if (lobTempQuery != null && lobTempQuery.Count != 0)
            {
                var lobReg = lobTempQuery.FirstOrDefault();
                var lobImagen = lobReg.RefObjeto as Image;

                Canvas lobContenedor = lobImagen.Parent as Canvas;
                lobContenedor.Children.Remove(lobImagen);

                // verificar item si estaba oculto el diente
                // Tipo diente
                var lcrTipoDiente = Convert.ToInt32(lobReg.IdDiente) >= 51 && Convert.ToInt32(lobReg.IdDiente) <= 65 ? "1" : "2";

                // Cargar en la vista del odontograma
                if (lcrTipoDiente == "1")
                {
                    Diente01 lobDiente = (Diente01)lobReg.RefDiente;
                    lobDiente.gnuContOcultDiente--;
                    if (lobDiente.gnuContOcultDiente <= 0)
                    {
                        lobDiente.imgDiente.Visibility = Visibility.Visible;
                        lobDiente.gnuContOcultDiente = 0;
                    }
                }
                else
                {
                    Diente02 lobDiente = (Diente02)lobReg.RefDiente;
                    lobDiente.gnuContOcultDiente--;
                    if (lobDiente.gnuContOcultDiente <= 0)
                    {
                        lobDiente.imgDiente.Visibility = Visibility.Visible;
                        lobDiente.gnuContOcultDiente = 0;
                    }
                }
                tmpRegistro.Remove(lobReg);

                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region flgEliminarImagenVistaDiente : Eliminar todas las imagen graficada para un diente
        /// <summary>
        /// <para>Eliminar todas las imagen graficada para un diente</para>
        /// <para>tcrIdDiente: Numero del diente ejemplo: "11", "45", "83" ...</para>
        /// </summary>
        public bool flgEliminarImagenVistaDiente(String tcrIdDiente)
        {
            var llgReturn = false;
            var lobTempQuery = fobRegSelectRegistro("DIENTE", tcrIdDiente);

            if (lobTempQuery != null)
            {
                foreach (var lobReg in lobTempQuery)
                {
                    var lobImagen = lobReg.RefObjeto as Image;
                    lobImagen = null;
                    tmpRegistro.Remove(lobReg);
                }
                llgReturn = true;
            }
            return llgReturn;
        }
        #endregion
        #region flgAddRegistroRefImagen01: Adicionar registro referencia de la imagen al temporal
        /// <summary>
        /// <para>Adicionar registro referencia de la imagen al temporal</para>
        /// <para>tcrIdRegistro: Id unico del registro para luego poder localizar la imagen</para>
        /// <para>tcrIdDiente: Numero del diente ejemplo: "11", "25", "53" ...</para>
        /// </summary>
        private bool flgAddRegistroRefImagen01(String tcrIdRegistro, String tcrIdDiente, ref Diente01 tobDiente, ref Image tobImagen)
        {
            var llgReturn = true;
            var lobReg = new Registro();

            lobReg.IdRegistro = tcrIdRegistro;
            lobReg.IdDiente = tcrIdDiente;
            lobReg.RefDiente = tobDiente;
            lobReg.RefObjeto = tobImagen;

            tmpRegistro.Add(lobReg);

            return llgReturn;
        }
        #endregion
        #region flgAddRegistroRefImagen02: Adicionar registro referencia de la imagen al temporal
        /// <summary>
        /// <para>Adicionar registro referencia de la imagen al temporal</para>
        /// <para>tcrIdRegistro: Id unico del registro para luego poder localizar la imagen</para>
        /// <para>tcrIdDiente: Numero del diente ejemplo: "31", "45", "83" ...</para>
        /// </summary>
        private bool flgAddRegistroRefImagen02(String tcrIdRegistro, String tcrIdDiente, ref Diente02 tobDiente, ref Image tobImagen)
        {
            var llgReturn = true;
            var lobReg = new Registro();

            lobReg.IdRegistro = tcrIdRegistro;
            lobReg.IdDiente = tcrIdDiente;
            lobReg.RefDiente = tobDiente;
            lobReg.RefObjeto = tobImagen;

            tmpRegistro.Add(lobReg);

            return llgReturn;
        }
        #endregion
    }
}

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
    /// Interaction logic for EDT_ControlOrdOdontogramaAdulto.xaml
    /// </summary>
    public partial class OdontogramaAdultos : UserControl
    {
        public String lcrUri = "/GestorReportes;component/Imagenes/";
        public String lcrRutaImagen = @"GaleriaRecursos\Imagenes\Odontologia\";
        Aplicacion oApp = Aplicacion.Instancia();
        public List<Registro> tmpRegistro = new List<Registro>();

        public OdontogramaAdultos()
        {
            InitializeComponent();
        }
        #region Cargar vista del diente 01
        private void fcvLoadDiente01(object sender, RoutedEventArgs e)
        {
            Diente01 lobControl = (Diente01)sender;
            var lcrNumero               = lobControl.Name.Substring(1, 2);
            lobControl.imgDiente.Source = new BitmapImage(new Uri(lcrUri + "hc_od_diente" + lcrNumero + ".png", UriKind.RelativeOrAbsolute));
            lobControl.lblNumero.Text   = lcrNumero;
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
                case "11": 
                    lobjDiente = this.D11;
                    break;
                case "12":
                    lobjDiente = this.D12;
                    break;
                case "13":
                    lobjDiente = this.D13;
                    break;
                case "14":
                    lobjDiente = this.D14;
                    break;
                case "15":
                    lobjDiente = this.D15;
                    break;
                case "16":
                    lobjDiente = this.D16;
                    break;
                case "17":
                    lobjDiente = this.D17;
                    break;
                case "18":
                    lobjDiente = this.D18;
                    break;
                #endregion
                #region Cuadrante 2
                case "21":
                    lobjDiente = this.D21;
                    break;
                case "22":
                    lobjDiente = this.D22;
                    break;
                case "23":
                    lobjDiente = this.D23;
                    break;
                case "24":
                    lobjDiente = this.D24;
                    break;
                case "25":
                    lobjDiente = this.D25;
                    break;
                case "26":
                    lobjDiente = this.D26;
                    break;
                case "27":
                    lobjDiente = this.D27;
                    break;
                case "28":
                    lobjDiente = this.D28;
                    break;
                #endregion
                #region Cuadrante 3
                case "31":
                    lobjDiente = this.D31;
                    break;
                case "32":
                    lobjDiente = this.D32;
                    break;
                case "33":
                    lobjDiente = this.D33;
                    break;
                case "34":
                    lobjDiente = this.D34;
                    break;
                case "35":
                    lobjDiente = this.D35;
                    break;
                case "36":
                    lobjDiente = this.D36;
                    break;
                case "37":
                    lobjDiente = this.D37;
                    break;
                case "38":
                    lobjDiente = this.D38;
                    break;
                #endregion
                #region Cuadrante 4
                case "41":
                    lobjDiente = this.D41;
                    break;
                case "42":
                    lobjDiente = this.D42;
                    break;
                case "43":
                    lobjDiente = this.D43;
                    break;
                case "44":
                    lobjDiente = this.D44;
                    break;
                case "45":
                    lobjDiente = this.D45;
                    break;
                case "46":
                    lobjDiente = this.D46;
                    break;
                case "47":
                    lobjDiente = this.D47;
                    break;
                case "48":
                    lobjDiente = this.D48;
                    break;
                #endregion
            }
            // Tipo diente
            lcrTipoDiente = Convert.ToInt32(tcrNumeroDiente) >= 11 && Convert.ToInt32(tcrNumeroDiente) <= 28 ? "1" : "2";
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
        /// <para>tcrOcultarItem: "1" = Ocultar imagen Base del diente "2" = No ocultar imagen base del diente</para>
        /// </summary>
        private void fcvGraficarImagenEnDiente01(String tcrIdRegistro, ref Diente01 tobjDiente, String tcrZonaGrafica, String tcrNombreImagen, String tcrOcultarItem)
        {

            Image lobObjeto = new Image();
            var lobUri = new EdtUtilidades.ObjetoBitmapImage();

            lobUri.AppIpServidor = oApp.gcrAppRecursoIpServidor;
            lobUri.AppInicioPath = oApp.gcrAppRecursoInicioPath;
            lobUri.RutaGaleria   = lcrRutaImagen;
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
        /// <para>tcrOcultarItem: "1" = Ocultar imagen Base del diente "2" = No ocultar imagen base del diente</para>
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
        /// <para>tcrNumeroDiente: Numero que representa la pieza dental en el odontograma ejm: "11", "12", "21"...</para>
        /// </summary>
        public void fcvLimpiarImgenEnDiente(String tcrNumeroDiente)
        {
            FrameworkElement lobjDiente = null;
            var lcrTipoDiente = "1";
            switch (tcrNumeroDiente)
            {
                #region Cuadrante 1
                case "11":
                    lobjDiente = this.D11;
                    break;
                case "12":
                    lobjDiente = this.D12;
                    break;
                case "13":
                    lobjDiente = this.D13;
                    break;
                case "14":
                    lobjDiente = this.D14;
                    break;
                case "15":
                    lobjDiente = this.D15;
                    break;
                case "16":
                    lobjDiente = this.D16;
                    break;
                case "17":
                    lobjDiente = this.D17;
                    break;
                case "18":
                    lobjDiente = this.D18;
                    break;
                #endregion
                #region Cuadrante 2
                case "21":
                    lobjDiente = this.D21;
                    break;
                case "22":
                    lobjDiente = this.D22;
                    break;
                case "23":
                    lobjDiente = this.D23;
                    break;
                case "24":
                    lobjDiente = this.D24;
                    break;
                case "25":
                    lobjDiente = this.D25;
                    break;
                case "26":
                    lobjDiente = this.D26;
                    break;
                case "27":
                    lobjDiente = this.D27;
                    break;
                case "28":
                    lobjDiente = this.D28;
                    break;
                #endregion
                #region Cuadrante 3
                case "31":
                    lobjDiente = this.D31;
                    break;
                case "32":
                    lobjDiente = this.D32;
                    break;
                case "33":
                    lobjDiente = this.D33;
                    break;
                case "34":
                    lobjDiente = this.D34;
                    break;
                case "35":
                    lobjDiente = this.D35;
                    break;
                case "36":
                    lobjDiente = this.D36;
                    break;
                case "37":
                    lobjDiente = this.D37;
                    break;
                case "38":
                    lobjDiente = this.D38;
                    break;
                #endregion
                #region Cuadrante 4
                case "41":
                    lobjDiente = this.D41;
                    break;
                case "42":
                    lobjDiente = this.D42;
                    break;
                case "43":
                    lobjDiente = this.D43;
                    break;
                case "44":
                    lobjDiente = this.D44;
                    break;
                case "45":
                    lobjDiente = this.D45;
                    break;
                case "46":
                    lobjDiente = this.D46;
                    break;
                case "47":
                    lobjDiente = this.D47;
                    break;
                case "48":
                    lobjDiente = this.D48;
                    break;
                #endregion
            }
            // Tipo diente
            lcrTipoDiente = Convert.ToInt32(tcrNumeroDiente) >= 11 && Convert.ToInt32(tcrNumeroDiente) <= 28 ? "1" : "2";

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
            this.D11.cnvCorona.Children.Clear();
            this.D11.cnvDienteCorona.Children.Clear();
            this.D11.cnvDienteRaiz.Children.Clear();
            this.D11.cnvDiente.Children.Clear();
            this.D11.cnvBaseDiente.Children.Clear();
            this.D11.imgDiente.Visibility = Visibility.Visible;

            this.D12.cnvCorona.Children.Clear();
            this.D12.cnvDienteCorona.Children.Clear();
            this.D12.cnvDienteRaiz.Children.Clear();
            this.D12.cnvDiente.Children.Clear();
            this.D12.cnvBaseDiente.Children.Clear();
            this.D12.imgDiente.Visibility = Visibility.Visible;

            this.D13.cnvCorona.Children.Clear();
            this.D13.cnvDienteCorona.Children.Clear();
            this.D13.cnvDienteRaiz.Children.Clear();
            this.D13.cnvDiente.Children.Clear();
            this.D13.cnvBaseDiente.Children.Clear();
            this.D13.imgDiente.Visibility = Visibility.Visible;

            this.D14.cnvCorona.Children.Clear();
            this.D14.cnvDienteCorona.Children.Clear();
            this.D14.cnvDienteRaiz.Children.Clear();
            this.D14.cnvDiente.Children.Clear();
            this.D14.cnvBaseDiente.Children.Clear();
            this.D14.imgDiente.Visibility = Visibility.Visible;

            this.D15.cnvCorona.Children.Clear();
            this.D15.cnvDienteCorona.Children.Clear();
            this.D15.cnvDienteRaiz.Children.Clear();
            this.D15.cnvDiente.Children.Clear();
            this.D15.cnvBaseDiente.Children.Clear();
            this.D15.imgDiente.Visibility = Visibility.Visible;

            this.D16.cnvCorona.Children.Clear();
            this.D16.cnvDienteCorona.Children.Clear();
            this.D16.cnvDienteRaiz.Children.Clear();
            this.D16.cnvDiente.Children.Clear();
            this.D16.cnvBaseDiente.Children.Clear();
            this.D16.imgDiente.Visibility = Visibility.Visible;

            this.D17.cnvCorona.Children.Clear();
            this.D17.cnvDienteCorona.Children.Clear();
            this.D17.cnvDienteRaiz.Children.Clear();
            this.D17.cnvDiente.Children.Clear();
            this.D17.cnvBaseDiente.Children.Clear();
            this.D17.imgDiente.Visibility = Visibility.Visible;

            this.D18.cnvCorona.Children.Clear();
            this.D18.cnvDienteCorona.Children.Clear();
            this.D18.cnvDienteRaiz.Children.Clear();
            this.D18.cnvDiente.Children.Clear();
            this.D18.cnvBaseDiente.Children.Clear();
            this.D18.imgDiente.Visibility = Visibility.Visible;
            #endregion
            #region Cuadrante 2
            this.D21.cnvCorona.Children.Clear();
            this.D21.cnvDienteCorona.Children.Clear();
            this.D21.cnvDienteRaiz.Children.Clear();
            this.D21.cnvDiente.Children.Clear();
            this.D21.cnvBaseDiente.Children.Clear();
            this.D21.imgDiente.Visibility = Visibility.Visible;

            this.D22.cnvCorona.Children.Clear();
            this.D22.cnvDienteCorona.Children.Clear();
            this.D22.cnvDienteRaiz.Children.Clear();
            this.D22.cnvDiente.Children.Clear();
            this.D22.cnvBaseDiente.Children.Clear();
            this.D22.imgDiente.Visibility = Visibility.Visible;

            this.D23.cnvCorona.Children.Clear();
            this.D23.cnvDienteCorona.Children.Clear();
            this.D23.cnvDienteRaiz.Children.Clear();
            this.D23.cnvDiente.Children.Clear();
            this.D23.cnvBaseDiente.Children.Clear();
            this.D23.imgDiente.Visibility = Visibility.Visible;

            this.D24.cnvCorona.Children.Clear();
            this.D24.cnvDienteCorona.Children.Clear();
            this.D24.cnvDienteRaiz.Children.Clear();
            this.D24.cnvDiente.Children.Clear();
            this.D24.cnvBaseDiente.Children.Clear();
            this.D24.imgDiente.Visibility = Visibility.Visible;

            this.D25.cnvCorona.Children.Clear();
            this.D25.cnvDienteCorona.Children.Clear();
            this.D25.cnvDienteRaiz.Children.Clear();
            this.D25.cnvDiente.Children.Clear();
            this.D25.cnvBaseDiente.Children.Clear();
            this.D25.imgDiente.Visibility = Visibility.Visible;

            this.D26.cnvCorona.Children.Clear();
            this.D26.cnvDienteCorona.Children.Clear();
            this.D26.cnvDienteRaiz.Children.Clear();
            this.D26.cnvDiente.Children.Clear();
            this.D26.cnvBaseDiente.Children.Clear();
            this.D26.imgDiente.Visibility = Visibility.Visible;

            this.D27.cnvCorona.Children.Clear();
            this.D27.cnvDienteCorona.Children.Clear();
            this.D27.cnvDienteRaiz.Children.Clear();
            this.D27.cnvDiente.Children.Clear();
            this.D27.cnvBaseDiente.Children.Clear();
            this.D27.imgDiente.Visibility = Visibility.Visible;

            this.D28.cnvCorona.Children.Clear();
            this.D28.cnvDienteCorona.Children.Clear();
            this.D28.cnvDienteRaiz.Children.Clear();
            this.D28.cnvDiente.Children.Clear();
            this.D28.cnvBaseDiente.Children.Clear();
            this.D28.imgDiente.Visibility = Visibility.Visible;
            #endregion
            #region Cuadrante 3
            this.D31.cnvCorona.Children.Clear();
            this.D31.cnvDienteCorona.Children.Clear();
            this.D31.cnvDienteRaiz.Children.Clear();
            this.D31.cnvDiente.Children.Clear();
            this.D31.cnvBaseDiente.Children.Clear();
            this.D31.imgDiente.Visibility = Visibility.Visible;

            this.D32.cnvCorona.Children.Clear();
            this.D32.cnvDienteCorona.Children.Clear();
            this.D32.cnvDienteRaiz.Children.Clear();
            this.D32.cnvDiente.Children.Clear();
            this.D32.cnvBaseDiente.Children.Clear();
            this.D32.imgDiente.Visibility = Visibility.Visible;

            this.D33.cnvCorona.Children.Clear();
            this.D33.cnvDienteCorona.Children.Clear();
            this.D33.cnvDienteRaiz.Children.Clear();
            this.D33.cnvDiente.Children.Clear();
            this.D33.cnvBaseDiente.Children.Clear();
            this.D33.imgDiente.Visibility = Visibility.Visible;

            this.D34.cnvCorona.Children.Clear();
            this.D34.cnvDienteCorona.Children.Clear();
            this.D34.cnvDienteRaiz.Children.Clear();
            this.D34.cnvDiente.Children.Clear();
            this.D34.cnvBaseDiente.Children.Clear();
            this.D34.imgDiente.Visibility = Visibility.Visible;

            this.D35.cnvCorona.Children.Clear();
            this.D35.cnvDienteCorona.Children.Clear();
            this.D35.cnvDienteRaiz.Children.Clear();
            this.D35.cnvDiente.Children.Clear();
            this.D35.cnvBaseDiente.Children.Clear();
            this.D35.imgDiente.Visibility = Visibility.Visible;

            this.D36.cnvCorona.Children.Clear();
            this.D36.cnvDienteCorona.Children.Clear();
            this.D36.cnvDienteRaiz.Children.Clear();
            this.D36.cnvDiente.Children.Clear();
            this.D36.cnvBaseDiente.Children.Clear();
            this.D36.imgDiente.Visibility = Visibility.Visible;

            this.D37.cnvCorona.Children.Clear();
            this.D37.cnvDienteCorona.Children.Clear();
            this.D37.cnvDienteRaiz.Children.Clear();
            this.D37.cnvDiente.Children.Clear();
            this.D37.cnvBaseDiente.Children.Clear();
            this.D37.imgDiente.Visibility = Visibility.Visible;

            this.D38.cnvCorona.Children.Clear();
            this.D38.cnvDienteCorona.Children.Clear();
            this.D38.cnvDienteRaiz.Children.Clear();
            this.D38.cnvDiente.Children.Clear();
            this.D38.cnvBaseDiente.Children.Clear();
            this.D38.imgDiente.Visibility = Visibility.Visible;
            #endregion
            #region Cuadrante 4
            this.D41.cnvCorona.Children.Clear();
            this.D41.cnvDienteCorona.Children.Clear();
            this.D41.cnvDienteRaiz.Children.Clear();
            this.D41.cnvDiente.Children.Clear();
            this.D41.cnvBaseDiente.Children.Clear();
            this.D41.imgDiente.Visibility = Visibility.Visible;

            this.D42.cnvCorona.Children.Clear();
            this.D42.cnvDienteCorona.Children.Clear();
            this.D42.cnvDienteRaiz.Children.Clear();
            this.D42.cnvDiente.Children.Clear();
            this.D42.cnvBaseDiente.Children.Clear();
            this.D42.imgDiente.Visibility = Visibility.Visible;

            this.D43.cnvCorona.Children.Clear();
            this.D43.cnvDienteCorona.Children.Clear();
            this.D43.cnvDienteRaiz.Children.Clear();
            this.D43.cnvDiente.Children.Clear();
            this.D43.cnvBaseDiente.Children.Clear();
            this.D43.imgDiente.Visibility = Visibility.Visible;

            this.D44.cnvCorona.Children.Clear();
            this.D44.cnvDienteCorona.Children.Clear();
            this.D44.cnvDienteRaiz.Children.Clear();
            this.D44.cnvDiente.Children.Clear();
            this.D44.cnvBaseDiente.Children.Clear();
            this.D44.imgDiente.Visibility = Visibility.Visible;

            this.D45.cnvCorona.Children.Clear();
            this.D45.cnvDienteCorona.Children.Clear();
            this.D45.cnvDienteRaiz.Children.Clear();
            this.D45.cnvDiente.Children.Clear();
            this.D45.cnvBaseDiente.Children.Clear();
            this.D45.imgDiente.Visibility = Visibility.Visible;

            this.D46.cnvCorona.Children.Clear();
            this.D46.cnvDienteCorona.Children.Clear();
            this.D46.cnvDienteRaiz.Children.Clear();
            this.D46.cnvDiente.Children.Clear();
            this.D46.cnvBaseDiente.Children.Clear();
            this.D46.imgDiente.Visibility = Visibility.Visible;

            this.D47.cnvCorona.Children.Clear();
            this.D47.cnvDienteCorona.Children.Clear();
            this.D47.cnvDienteRaiz.Children.Clear();
            this.D47.cnvDiente.Children.Clear();
            this.D47.cnvBaseDiente.Children.Clear();
            this.D47.imgDiente.Visibility = Visibility.Visible;

            this.D48.cnvCorona.Children.Clear();
            this.D48.cnvDienteCorona.Children.Clear();
            this.D48.cnvDienteRaiz.Children.Clear();
            this.D48.cnvDiente.Children.Clear();
            this.D48.cnvBaseDiente.Children.Clear();
            this.D48.imgDiente.Visibility = Visibility.Visible;
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
            #region Cuadrante 1
            this.D11.rctCapaSelect.Visibility = tcrVisibility;
            this.D12.rctCapaSelect.Visibility = tcrVisibility;
            this.D13.rctCapaSelect.Visibility = tcrVisibility;
            this.D14.rctCapaSelect.Visibility = tcrVisibility;
            this.D15.rctCapaSelect.Visibility = tcrVisibility;
            this.D16.rctCapaSelect.Visibility = tcrVisibility;
            this.D17.rctCapaSelect.Visibility = tcrVisibility;
            this.D18.rctCapaSelect.Visibility = tcrVisibility;
            #endregion
            #region Cuadrante 2
            this.D21.rctCapaSelect.Visibility = tcrVisibility;
            this.D22.rctCapaSelect.Visibility = tcrVisibility;
            this.D23.rctCapaSelect.Visibility = tcrVisibility;
            this.D24.rctCapaSelect.Visibility = tcrVisibility;
            this.D25.rctCapaSelect.Visibility = tcrVisibility;
            this.D26.rctCapaSelect.Visibility = tcrVisibility;
            this.D27.rctCapaSelect.Visibility = tcrVisibility;
            this.D28.rctCapaSelect.Visibility = tcrVisibility;
            #endregion
            #region Cuadrante 3
            this.D31.rctCapaSelect.Visibility = tcrVisibility;
            this.D32.rctCapaSelect.Visibility = tcrVisibility;
            this.D33.rctCapaSelect.Visibility = tcrVisibility;
            this.D34.rctCapaSelect.Visibility = tcrVisibility;
            this.D35.rctCapaSelect.Visibility = tcrVisibility;
            this.D36.rctCapaSelect.Visibility = tcrVisibility;
            this.D37.rctCapaSelect.Visibility = tcrVisibility;
            this.D38.rctCapaSelect.Visibility = tcrVisibility;
            #endregion
            #region Cuadrante 4
            this.D41.rctCapaSelect.Visibility = tcrVisibility;
            this.D42.rctCapaSelect.Visibility = tcrVisibility;
            this.D43.rctCapaSelect.Visibility = tcrVisibility;
            this.D44.rctCapaSelect.Visibility = tcrVisibility;
            this.D45.rctCapaSelect.Visibility = tcrVisibility;
            this.D46.rctCapaSelect.Visibility = tcrVisibility;
            this.D47.rctCapaSelect.Visibility = tcrVisibility;
            this.D48.rctCapaSelect.Visibility = tcrVisibility;
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
                #region Cuadrante 1
                case "11":
                    lobjDiente = this.D11;
                    break;
                case "12":
                    lobjDiente = this.D12;
                    break;
                case "13":
                    lobjDiente = this.D13;
                    break;
                case "14":
                    lobjDiente = this.D14;
                    break;
                case "15":
                    lobjDiente = this.D15;
                    break;
                case "16":
                    lobjDiente = this.D16;
                    break;
                case "17":
                    lobjDiente = this.D17;
                    break;
                case "18":
                    lobjDiente = this.D18;
                    break;
                #endregion
                #region Cuadrante 2
                case "21":
                    lobjDiente = this.D21;
                    break;
                case "22":
                    lobjDiente = this.D22;
                    break;
                case "23":
                    lobjDiente = this.D23;
                    break;
                case "24":
                    lobjDiente = this.D24;
                    break;
                case "25":
                    lobjDiente = this.D25;
                    break;
                case "26":
                    lobjDiente = this.D26;
                    break;
                case "27":
                    lobjDiente = this.D27;
                    break;
                case "28":
                    lobjDiente = this.D28;
                    break;
                #endregion
                #region Cuadrante 3
                case "31":
                    lobjDiente = this.D31;
                    break;
                case "32":
                    lobjDiente = this.D32;
                    break;
                case "33":
                    lobjDiente = this.D33;
                    break;
                case "34":
                    lobjDiente = this.D34;
                    break;
                case "35":
                    lobjDiente = this.D35;
                    break;
                case "36":
                    lobjDiente = this.D36;
                    break;
                case "37":
                    lobjDiente = this.D37;
                    break;
                case "38":
                    lobjDiente = this.D38;
                    break;
                #endregion
                #region Cuadrante 4
                case "41":
                    lobjDiente = this.D41;
                    break;
                case "42":
                    lobjDiente = this.D42;
                    break;
                case "43":
                    lobjDiente = this.D43;
                    break;
                case "44":
                    lobjDiente = this.D44;
                    break;
                case "45":
                    lobjDiente = this.D45;
                    break;
                case "46":
                    lobjDiente = this.D46;
                    break;
                case "47":
                    lobjDiente = this.D47;
                    break;
                case "48":
                    lobjDiente = this.D48;
                    break;
                #endregion
            }
            // Tipo diente
            lcrTipoDiente = Convert.ToInt32(tcrNumeroDiente) >= 11 && Convert.ToInt32(tcrNumeroDiente) <= 28 ? "1" : "2";

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
            var lobTempQuery = fobRegSelectRegistro("IMAGEN",tcrLlave);

            if (lobTempQuery != null && lobTempQuery.Count != 0)
            {
                var lobReg = lobTempQuery.FirstOrDefault();
                var lobImagen = lobReg.RefObjeto as Image;

                Canvas lobContenedor = lobImagen.Parent as Canvas;
                lobContenedor.Children.Remove(lobImagen);

                // verificar item si estaba oculto el diente
                // Tipo diente
                var lcrTipoDiente = Convert.ToInt32(lobReg.IdDiente) >= 11 && Convert.ToInt32(lobReg.IdDiente) <= 28 ? "1" : "2";

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

            lobReg.IdRegistro   = tcrIdRegistro;
            lobReg.IdDiente     = tcrIdDiente;
            lobReg.RefDiente    = tobDiente;
            lobReg.RefObjeto    = tobImagen;

            tmpRegistro.Add(lobReg);

            return llgReturn;
        }
        #endregion
    }
}

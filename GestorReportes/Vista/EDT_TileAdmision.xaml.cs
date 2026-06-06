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
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_TileTileAdmision.xaml
    /// </summary>
    public partial class TileAdmision : UserControl
    {
        public TileAdmision()
        {
            InitializeComponent();

            this.IsManipulationEnabled = true;

            this.stkHistorial.Visibility = Visibility.Collapsed;

            EstadoHistorial = "XX";
        }
        public String RegistroAdmision { get; set; }
        /// <summary>
        /// "OK" = Detalles cargados en vista "XX" = Detalles No cargado en vista historial
        /// </summary>
        public String EstadoHistorial { get; set; }

        /// <summary>
        /// Llamada desde el boton
        /// </summary>
        private void fcvActivarVistaDetalles(object sender, RoutedEventArgs e)
        {
            fcvActivarVistaDetalles();
        }
        /// <summary>
        /// Click sobre el texto
        /// </summary>
        private void txtTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            fcvActivarVistaDetalles();
        }
        /// <summary>
        /// un toque tactil sobre el texto
        /// </summary>
        private void txtTitulo_TouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            fcvActivarVistaDetalles();
        }
        /// <summary>
        /// Ejecutar la accion
        /// </summary>
        private void fcvActivarVistaDetalles()
        {
            if (this.stkHistorial.Visibility == Visibility.Visible)
            {
                fcvOpcActivarVistaDetalles("-");
            }
            else
            {
                fcvOpcActivarVistaDetalles("+");
            }
        }
        /// <summary>
        /// Ejecutar la accion segun parametro
        /// tcrAccion: "+" = Desplegar  "-" = Colapsar
        /// </summary>
        public void fcvOpcActivarVistaDetalles(String tcrAccion)
        {
            var lcrUri = "/GestorReportes;component/Imagenes/";

            if (tcrAccion == "+")
            {
                if (this.stkHistorial.Visibility != Visibility.Visible)
                {
                    this.stkHistorial.Visibility = Visibility.Visible;
                    this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer2.png", UriKind.RelativeOrAbsolute));
                }
            }

            if (tcrAccion == "-")
            {
                if (this.stkHistorial.Visibility == Visibility.Visible)
                {
                    this.stkHistorial.Visibility = Visibility.Collapsed;
                    this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer3.png", UriKind.RelativeOrAbsolute));
                }
            }
        }
    }
}

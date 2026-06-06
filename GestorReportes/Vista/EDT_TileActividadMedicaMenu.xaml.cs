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

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_TileMenuActividadesMedicas.xaml
    /// </summary>
    public partial class ActividadesMedicasMenu : UserControl
    {
        public ActividadesMedicasMenu()
        {
            InitializeComponent();
            this.IsManipulationEnabled = true;
            this.stkDetalles.Visibility = Visibility.Collapsed;
        }
        public String CodigoGrupo { get; set; }

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
            if (this.stkDetalles.Visibility == Visibility.Visible)
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
                if (this.stkDetalles.Visibility != Visibility.Visible)
                {
                    this.stkDetalles.Visibility = Visibility.Visible;
                    this.imgPropDetalles.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer2.png", UriKind.RelativeOrAbsolute));
                }
            }

            if (tcrAccion =="-")
            {
                if (this.stkDetalles.Visibility == Visibility.Visible)
                {
                    this.stkDetalles.Visibility = Visibility.Collapsed;
                    this.imgPropDetalles.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer3.png", UriKind.RelativeOrAbsolute));
                }
            }
        }

    }
}

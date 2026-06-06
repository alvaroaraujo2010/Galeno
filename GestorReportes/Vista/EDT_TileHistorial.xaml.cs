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
    /// Interaction logic for EDT_TileHistorial.xaml
    /// </summary>
    public partial class TileHistorial : UserControl
    {
        public TileHistorial()
        {
            InitializeComponent();
            this.IsManipulationEnabled = true;
            this.stkHistorial.Visibility = Visibility.Collapsed;
        }
        public String RegistroEvento { get; set; }
        public long IntRegistroEvento { get; set; }

        private void fcvActivarVistaHistorial(object sender, RoutedEventArgs e)
        {
            var lcrUri = "/GestorReportes;component/Imagenes/";
            if (this.stkHistorial.Visibility == Visibility.Visible)
            {
                this.stkHistorial.Visibility = Visibility.Collapsed;
                this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer3.png", UriKind.RelativeOrAbsolute));
            }
            else 
            {
                this.stkHistorial.Visibility = Visibility.Visible;
                this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer2.png", UriKind.RelativeOrAbsolute));
            }
        }
    }
}

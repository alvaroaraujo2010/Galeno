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
    /// Interaction logic for ControlOrdOdontoCierre.xaml
    /// </summary>
    public partial class ControlOrdOdontoCierre : UserControl
    {
        public ControlOrdOdontoCierre()
        {
            InitializeComponent();
        }
        public String IdRegistro = String.Empty;
        //------------------------------------------------------------
        // GESTION VISTA
        //------------------------------------------------------------
        #region fcvActivarVistaDetalles: Desplegar o colapsar los detalles
        /// <summary>
        /// <para>Desplegar o colapsar los detalles</para>
        /// </summary>
        private void fcvActivarVistaDetalles(object sender, RoutedEventArgs e)
        {
            var lcrUri = "/GestorReportes;component/Imagenes/";
            if (this.grdDetalles.Visibility == Visibility.Visible)
            {
                this.grdDetalles.Visibility = Visibility.Collapsed;
                this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer3.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                this.grdDetalles.Visibility = Visibility.Visible;
                this.imgPropHistorial.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer2.png", UriKind.RelativeOrAbsolute));
            }
        }
        #endregion
    }
}

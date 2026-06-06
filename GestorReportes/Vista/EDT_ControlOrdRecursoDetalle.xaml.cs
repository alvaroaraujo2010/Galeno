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
    /// Interaction logic for EDT_ControlOrdRecursoDetalleEdt.xaml
    /// </summary>
    public partial class ControlOrdRecursoDetalle : UserControl
    {
        public ControlOrdRecursoDetalle()
        {
            InitializeComponent();
        }
        public String IdR1Registro = String.Empty;
        public String IdRegistro = String.Empty;

        #region fcvActivarVistaDetalles: Desplegar o colapsar los detalles
        /// <summary>
        /// <para>Desplegar o colapsar los detalles</para>
        /// </summary>
        private void fcvActivarVistaDetalles(object sender, RoutedEventArgs e)
        {
            var lcrUri = "/GestorReportes;component/Imagenes/";
            if (this.grdDetalle.Visibility == Visibility.Visible)
            {
                this.grdDetalle.Visibility = Visibility.Collapsed;
                this.imgVerDeatlles.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer3.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                this.grdDetalle.Visibility = Visibility.Visible;
                this.imgVerDeatlles.Source = new BitmapImage(new Uri(lcrUri + "Edt_edt_contraer2.png", UriKind.RelativeOrAbsolute));
            }
        }
        #endregion

    }
}

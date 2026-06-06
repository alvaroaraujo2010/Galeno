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
    /// Interaction logic for ControlFirma.xaml
    /// </summary>
    public partial class ControlFirma : UserControl
    {
        public TextBox txtNombreFondo = null;
        public TextBox txtNombre = null;
        public Image ImgFirma = null;

        public ControlFirma()
        {
            InitializeComponent();
        }
        //-------------------------------------------------
        // Tomar Referencia objetos
        //-------------------------------------------------
        #region Tomar Referencia del objeto
        private void fcvLoadedTextoFirma(object sender, RoutedEventArgs e)
        {
            this.txtNombre = (TextBox)sender;
        }
        private void fcvLoadedTextoFirmaFondo(object sender, RoutedEventArgs e)
        {
            this.txtNombreFondo = (TextBox)sender;
        }
        #endregion

    }
}

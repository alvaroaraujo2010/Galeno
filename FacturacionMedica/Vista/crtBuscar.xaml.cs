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
using System.Diagnostics;

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Interaction logic for crtBuscar.xaml
    /// </summary>
    public partial class crtBuscar : UserControl
    {
        public crtBuscar()
        {
            InitializeComponent();

            this.cmdLimpiar.Visibility = Visibility.Collapsed;
        }
        #region fcvTouchEnterTeclado: mostrar teclado virtual
        private void fcvTouchEnterTeclado(object sender, TouchEventArgs e)
        {
            if (Process.GetProcessesByName("OSK").Length < 1)
            {
                TextBox lobTexto = sender as TextBox;
                Process.Start("osk.exe");
                FocusManager.SetFocusedElement(this, lobTexto);
            }
        }
        #endregion

        #region Limpiar cuador de texto
        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.cmdLimpiar.Visibility = String.IsNullOrWhiteSpace(this.txtBuscar.Text) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void fcvLimpiarTexto(object sender, RoutedEventArgs e)
        {
            this.txtBuscar.Text = String.Empty;
        }
        #endregion

    }
}

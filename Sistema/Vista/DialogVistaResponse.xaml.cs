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
using System.Windows.Shapes;
using Sistema.Clases;

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for DialogVistaErroresEjecucion.xaml
    /// </summary>
    public partial class VistaResponse : Window
    {
        public VistaResponse(String tcrTexto, String tcrTituloVista)
        {
            InitializeComponent();

            this.txtBlockTitulo.Text    = tcrTituloVista;
            this.txtTitulo.Text         = tcrTituloVista;
            this.txtErrorEjecucion.Text = tcrTexto != null ? tcrTexto : "";
        }
        #region Metodos de controles en formulario e interface
        /// <summary>
        /// Clic en Boton Cancelar
        /// </summary>
        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Metodos Varios
        /// <summary>
        /// Metodos Varios
        /// </summary>
        private void btnCerrar_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
    }
}

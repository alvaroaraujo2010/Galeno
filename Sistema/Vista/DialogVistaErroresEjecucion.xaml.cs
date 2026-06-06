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
    public partial class VistaErroresEjecucion : Window
    {
        public VistaErroresEjecucion(ref Exception ex, String tcrTituloError)
        {
            InitializeComponent();


            //LogErrores lst = null; // ojo quitar esto
            //lst.IdUsuario = ""; // genera un error al drede

            var lcrLinea = new String('=', 50) + Environment.NewLine;
            var lcrMensaje = "MENSAJE : " + ex.Message + Environment.NewLine ;
            var lcrLlamada = lcrLinea + "LLAMADA : " + ex.StackTrace + Environment.NewLine;
            var lcrInnerEx = ex.InnerException != null ? lcrLinea + "DETALLE : " + ex.InnerException.Message : String.Empty;

            this.txtTitulo.Text = tcrTituloError;
            this.txtErrorEjecucion.Text = lcrMensaje + lcrLlamada + lcrInnerEx;

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

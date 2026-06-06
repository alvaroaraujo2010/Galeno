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

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for TilesNotificacion.xaml
    /// </summary>
    public partial class TilesNotificacion : UserControl
    {
        public int gnuNotificaciones      = 0;
        public String gcrIdModulo         = String.Empty;
        public String gcrTipoNotificacion = String.Empty;

        public TilesNotificacion()
        {
            InitializeComponent();

            this.IsManipulationEnabled        = true;
            this.imgNotificacion.Visibility   = Visibility.Collapsed;
            this.txtNotificaciones.Visibility = Visibility.Collapsed;
        }
        #region fcvNotificaciones: guardar parametros iniciales del registro
        /// <summary>
        /// guardar parametros iniciales del registro
        /// </summary>
        public void fcvNotificaciones(int tnuNotificaciones, String tcrIdModulo, String tcrTipoNotificacion)
        {
            gnuNotificaciones   = tnuNotificaciones;
            gcrIdModulo         = tcrIdModulo;
            gcrTipoNotificacion = tcrTipoNotificacion;

            fcvActualizarNotificacion(tnuNotificaciones);
        }
        #endregion
        #region fcvActualizarNotificacion: Actualizar contador notifcaciones en vista del boton
        /// <summary>
        /// Actualizar contador notifcaciones en vista del boton
        /// </summary>
        public void fcvActualizarNotificacion(int tnuNotificaciones)
        {
            this.imgNotificacion.Visibility = tnuNotificaciones > 0 ? Visibility.Visible : Visibility.Collapsed;
            this.txtNotificaciones.Visibility = tnuNotificaciones > 0 ? Visibility.Visible : Visibility.Collapsed;

            this.txtNotificaciones.Text = tnuNotificaciones.ToString();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Threading;
using Sistema.Clases;
using Microsoft.Win32;

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for DialogVistaErrores.xaml
    /// </summary>
    public partial class DialogVistaErrores : Window
    {
        private double lduBarraWidth;
        private double lduHeight;
        private bool glgVistaPropVisible = false;
        public List<LogsErrores> tmpErrores = new List<LogsErrores>();
        DispatcherTimer ldspTimerSistema = null;

        public DialogVistaErrores()
        {
            InitializeComponent();

            fcvResizePantalla();
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            fcvTimerGeneral();

        }
        #region fcvTimer: Control Tiempo para cosas varias
        public void fcvTimerGeneral()
        {
            ldspTimerSistema = new DispatcherTimer();
            ldspTimerSistema.Tick += new System.EventHandler(out fcvTimerProcesos);
            ldspTimerSistema.Interval = new TimeSpan(0, 0, 0, 0, 120);
            ldspTimerSistema.Start();
        }
        #endregion
        #region fcvTimerProcesos: Timer para control Click y Touch X Horizontal
        /// <summary>
        /// <para>Timer para control Click y Touch X Horizontal</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            // al mostrar la vista del historial
            if (glgVistaPropVisible == false && this.Top == (lduHeight + 10))
            {
                ldspTimerSistema.Stop();
                this.Close();
            }
        }
        #endregion
        #region fcvResizePantalla: Tamaños de pantalla y objetos
        //------------------------------------------------------------
        // Evento para detectar el cambio de Resolucion de Pantalla en Windows
        //------------------------------------------------------------
        /// <summary>
        /// <para>Detectar el cambio de Resolucion de Pantalla en Windows y realizar ajustes</para>
        /// </summary>
        void SystemEvents_ReajustarVistaPantalla(object sender, EventArgs e)
        {
            fcvResizePantalla();
        }
        public void fcvResizePantalla()
        {
            lduBarraWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 96.2;
            lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 100;
            this.Width = lduBarraWidth;
            //this.Top = lduHeight >= 1000 ? lduHeight - 340 : lduHeight - 320;
            this.Top = lduHeight >= 1000 ? lduHeight + 470 : lduHeight + 450;
            this.Left = -2;
        }
        #endregion
        #region fcvCargarVista: Carga lista para log de errores
        /// <summary>
        /// <para>Carga lista para log de errores</para>
        /// </summary>
        public void fcvCargarVista(String tcrTitulo, List<LogsErrores> tmpListaErrores)
        {
            tmpErrores = tmpListaErrores;
            fcvCargarVistaDatos();
        }
        #endregion
        #region fcvCargarVistaDatos: Carga registros en vista detalles
        /// <summary>
        /// <para>Carga registros en vista detalles</para>
        /// </summary>
        public void fcvCargarVistaDatos()
        {
            if (tmpErrores != null)
            {
                this.stkContenedor.Children.Clear();
                foreach (var lobReg in tmpErrores)
                {
                    var lobDetalle = new ControlVistaRegErrores();

                    lobDetalle.imgEstado.Source = new BitmapImage(new Uri("/Sistema;component/Imagenes/" + lobReg.Imagen, UriKind.RelativeOrAbsolute));
                    lobDetalle.txtNumeroRegistro.Text = lobReg.NumeroRegistro;
                    lobDetalle.txtCodigoError.Text = lobReg.CodigoError;
                    lobDetalle.txtNombreCampo.Text = lobReg.NombreCampo;
                    lobDetalle.txtMensajeError.Text = lobReg.MensajeError;
                    lobDetalle.txtNivelError.Text = lobReg.NivelError;
                    this.stkContenedor.Children.Add(lobDetalle);
                }
            }
        }
        #endregion
        #region fcvCerraVista: cerrar la vista 
        /// <summary>
        /// <para>cerrar la vista</para>
        /// </summary>
        private void fcvCerraVista(object sender, RoutedEventArgs e)
        {
            fcvCerrarVista();
        }
        #endregion
        #region fcvActivarVistaHistorial: Mostrar u Ocultar la Ventana Historial del paciente
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Historial de errores</para>
        /// </summary>
        public void fcvActivarVista()
        {

            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropVisible == false)
            {
                //var lnuTop = lduHeight >= 1000 ? lduHeight - 340 : lduHeight - 320;
                var lnuTop = lduHeight >= 1000 ? lduHeight - 470 : lduHeight - 450;
                luxAnimacion.To = lnuTop; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(2000));
                glgVistaPropVisible = true;
                this.BeginAnimation(Window.TopProperty, luxAnimacion);
            }
        }
        #endregion
        #region fcvCerrarVista: Mostrar u Ocultar la Ventana Historial del paciente
        /// <summary>
        /// <para>Mostrar u Ocultar la Ventana Historial del paciente</para>
        /// </summary>
        public void fcvCerrarVista()
        {
            DoubleAnimation luxAnimacion = new DoubleAnimation();
            if (glgVistaPropVisible == true)
            {
                //this.Top = lduHeight >= 1000 ? lduHeight - 340 : lduHeight - 320;
                this.Top = lduHeight >= 1000 ? lduHeight - 470 : lduHeight - 450;
                var lnuTop = lduHeight + 10;
                luxAnimacion.To = lnuTop; luxAnimacion.Duration = new Duration(TimeSpan.FromMilliseconds(700));
                glgVistaPropVisible = false;
                this.BeginAnimation(Window.TopProperty, luxAnimacion);
            }
        }
        #endregion

    }
}

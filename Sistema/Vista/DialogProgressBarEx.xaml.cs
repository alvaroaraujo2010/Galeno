using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using Microsoft.Win32;

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for DialogProgressBarEx.xaml
    /// </summary>
    public partial class DialogProgressBarEx : Window
    {
        private double lduBarraWidth;
        private double lduHeight;
        private int lnuTotalregistros = 0;
        private String lcrTitulo= String.Empty;
        private String lcrTipo = "CENTRO";

        public DialogProgressBarEx()
        {
            InitializeComponent();

            fcvResizePantalla();
            SystemEvents.DisplaySettingsChanged += SystemEvents_ReajustarVistaPantalla;
            //Loaded += new RoutedEventHandler(AnimateLabelRotationInCode);

        }
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
            if (lcrTipo == "CENTRO")
            {
                lduBarraWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 100;
                lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 100;
                this.Width = (lduBarraWidth * 80 / 100);
                this.Top = (lduHeight / 2) + 80;
                this.Left = (lduBarraWidth * 10 / 100);
            }
            else if (lcrTipo == "ABAJO")
            {
                lduBarraWidth = (System.Windows.SystemParameters.PrimaryScreenWidth / 96) * 100;
                lduHeight = (System.Windows.SystemParameters.PrimaryScreenHeight / 96) * 100;
                this.Width = lduBarraWidth;
                this.Top = lduHeight >= 1000 ? lduHeight - 110 : lduHeight - 90;
                this.Left = 0;
            }
        }
        #endregion
        public void AnimateLabelRotationInCode(object sender, RoutedEventArgs e)
        {
            DoubleAnimation oLabelAngleAnimation = new DoubleAnimation();

            oLabelAngleAnimation.From = 0;
            oLabelAngleAnimation.To = 360;
            oLabelAngleAnimation.Duration = TimeSpan.FromMilliseconds(5000);
            //oLabelAngleAnimation.RepeatBehavior = new RepeatBehavior(4);
            oLabelAngleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            RotateTransform oTransform = new RotateTransform(0, 0, 0);
            rect.RenderTransform = oTransform;

            oTransform.BeginAnimation(RotateTransform.AngleProperty, oLabelAngleAnimation);
        }
        #region fcvProgressBarIniciar: Reinicia los valores y progreso de la barra
        /*
        /// <summary>
        /// <para>Reinicia lso valores y progreso de la barra</para>
        /// </summary>
        public void fcvProgressBarIniciar(String tcrTitulo, int tnuTotalregistros)
        {
            lcrTitulo           = tcrTitulo;
            lnuTotalregistros   = tnuTotalregistros;
            this.objProgressBar.Visibility = Visibility.Visible;
            this.objProgressBar.Value = 0;
            this.lblStatus.Text = tcrTitulo;
        }
        */
        #endregion
        #region fcvProgressBarIniciar: Inicia la barra simple sin progreso
        /// <summary>
        /// <para>Inicia la barra simple sin progreso</para>
        /// <para>tcrEstilovista: "CENTRO","ABAJO","ARRIBA"</para>
        /// </summary>
        public void fcvProgressBarIniciar(String tcrTitulo, String tcrEstilovista)
        {
            lcrTipo = tcrEstilovista;
            this.lblStatus.Text = tcrTitulo;
            if (lcrTipo != "CENTRO") // Cuando no es el valor por defecto
            {
                fcvResizePantalla();
            }
        }
        #endregion
        #region fcvReportarProgreso: Reportar el progreso del proceso
        /// <summary>
        /// <para>Reportar el progreso del proceso</para>
        /// </summary>
        public void fcvReportarProgreso(String tcrTitulo , int tnuProgreso)
        {
            var lnuValor = fnuProgressBarAvance(tnuProgreso, lnuTotalregistros);
            this.objProgressBar.Value = lnuValor;

            String lcrMsg = !String.IsNullOrWhiteSpace(tcrTitulo) ? tcrTitulo + " {0}%..." : lcrTitulo + " {0}%...";
            this.lblStatus.Text = String.Format(lcrMsg, lnuValor);
            Thread.Sleep(500);
        }
        #endregion
        #region fcvProgressBarAvance: Mostrar el avance barra de progresos
        /// <summary>
        /// <para>Mostrar el avance barra de progreso</para>
        /// </summary>
        public int fnuProgressBarAvance(int tnuValorAvance, int tnuTotalregistros)
        {
            int gnuPropValorProgressBar = 0;
            if (tnuValorAvance > 0 && tnuValorAvance <= tnuTotalregistros)
            {
                gnuPropValorProgressBar = (tnuValorAvance * 100) / tnuTotalregistros;
            }
            else if (tnuValorAvance > tnuTotalregistros)
            {
                gnuPropValorProgressBar = 100;
            }
            else
            {
                gnuPropValorProgressBar = 1;
            }
            gnuPropValorProgressBar = gnuPropValorProgressBar < 1 ? 1 : gnuPropValorProgressBar;

            return gnuPropValorProgressBar;
        }
        #endregion
    }
}

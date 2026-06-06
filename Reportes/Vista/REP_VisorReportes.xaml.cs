using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;
using System.Windows.Threading;
using System.Threading;

namespace Reportes.Vista
{
    /// <summary>
    /// Interaction logic for REP_VisorReportes.xaml
    /// </summary>
    public partial class VisorReportes : Window
    {
        DispatcherTimer ldspTimerSistema = null;
        public bool llgVistaPrevia = true;
        private bool llgPrint = false;
        public VisorReportes()
        {
            InitializeComponent();
            fcvTimerGeneral();
        }
        private void fcvCargarVista(object sender, RoutedEventArgs e)
        {
            if (llgVistaPrevia == false)
            {
                this.Left = -2000;
            }
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
        #region fcvTimerProcesos: Timer para control vista e impresion
        /// <summary>
        /// <para>Timer para control vista e impresion</para>
        /// </summary>
        void fcvTimerProcesos(object sender, EventArgs e)
        {
            // al cargar el formulario  cargar el historial del paciente
            if (this.IsLoaded && llgPrint == false && llgVistaPrevia == false && this.crpVisor.ViewerCore.IsLoaded)
            {
                ldspTimerSistema.Stop();
                llgPrint = true;
                this.crpVisor.ViewerCore.PrintReport();
                this.Close();
            }
        }
        #endregion

    }
}

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
using Sistema.Utilidades;
using GestorReportes.Utilidades;
using System.Diagnostics;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_ControlFecha.xaml
    /// </summary>
    public partial class ControlFecha : UserControl
    {
        //public TextBox txtFechaVista = null;
        //public DatePicker dpkFecha = null;
        //public Border objBorder = null;
        public bool llgFechaOk = false;
        public bool llgObjetosCargados = false;
        public ControlFecha()
        {
            InitializeComponent();
            llgObjetosCargados = true;
        }
        //-------------------------------------------------
        //  Actualizar Campo TextBox desde DatePiker
        //-------------------------------------------------
        #region  Actualizar Campo TextBox desde DatePiker
        private void fcvDatePickerSelected(object sender, SelectionChangedEventArgs e)
        {
            this.txtFechaVista.Text = dpkFecha.SelectedDate.ToString().Substring(0, 10);
            FocusManager.SetFocusedElement(this, this.txtFechaVista);
        }
        #endregion
        //-------------------------------------------------
        // Actualizar DatePiker desde Campo Texto
        //-------------------------------------------------
        #region Actualizar DatePiker desde Campo Texto
        private void fcvActualizarDatePicker(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados != true) return;

            DateTime ldaFecha;
            var lnuPosCursor = this.txtFechaVista.SelectionStart;
            var lcrValor = CrtForms.fcrFormatoCapturaFecha("DMY", "/", this.txtFechaVista.Text);
            this.txtFecha.Text = String.Empty;

            if (this.txtFechaVista.Text.Trim() != lcrValor.Trim())
            {
                this.txtFechaVista.Text = lcrValor;
                this.txtFechaVista.SelectionStart = CrtForms.fnuNewPosCursorFecha("DMY", lnuPosCursor);
            }
            if (DateTime.TryParse(this.txtFechaVista.Text, out ldaFecha) && this.txtFechaVista.Text.Trim().Length == 10)
            {
                this.dpkFecha.SelectedDate = Convert.ToDateTime(this.txtFechaVista.Text);
                this.txtFecha.Text = this.txtFechaVista.Text;
                fcvColorBorder("NA", "#FF34C4EE");
                llgFechaOk = true;
            }
            else 
            {
                fcvColorBorder("Formato o fecha errada","");
                llgFechaOk = false;
            }
        }
        #endregion
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
        #region fcvColorBorder: mostrar color del border segun vista
        public void fcvColorBorder(String tcrMensajeToolTip, String tcrColor)
        {
            if (String.IsNullOrWhiteSpace(tcrMensajeToolTip)|| tcrMensajeToolTip=="NA")
            {
                this.objBorder.BorderBrush = EdtUtilidades.SetSolidColorBrush(tcrColor, "#FF34C4EE");
                this.txtFechaVista.ToolTip = null;
            }
            else // "ERROR"
            {
                this.objBorder.BorderBrush = Brushes.Red; // rojo por error
                this.txtFechaVista.ToolTip = tcrMensajeToolTip;
            }
        }
        #endregion
        //-------------------------------------------------
        // Loaded: Tomar Referencia a los objetos 
        //-------------------------------------------------
        #region Tomar Referencia del objeto Texto
        private void fcvLoadedObjFecha(object sender, RoutedEventArgs e)
        {
            this.txtFechaVista = (TextBox)sender;
        }
        #endregion
        #region Tomar Referencia del objeto DatePicker
        private void fcvLoadedObjDatePicker(object sender, RoutedEventArgs e)
        {
            this.dpkFecha = (DatePicker)sender;
        }
        #endregion
        #region Tomar Referencia del objeto Border
        private void fcvLoadedObjBorder(object sender, RoutedEventArgs e)
        {
            this.objBorder = (Border)sender;
        }
        #endregion

    }
}

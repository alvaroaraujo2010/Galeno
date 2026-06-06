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
    /// Interaction logic for EDT_ControlHora.xaml
    /// </summary>
    public partial class ControlHora : UserControl
    {
        public bool llgHoraOk = false;
        public bool llgObjetosCargados = false;

        public ControlHora()
        {
            InitializeComponent();
            llgObjetosCargados = true;
        }
        //-------------------------------------------------
        //Formato para captura de la hora 
        //-------------------------------------------------
        #region Formato para captura de la hora
        private void fcvCapturaHora(object sender, TextChangedEventArgs e)
        {
            if (llgObjetosCargados != true) return;

            this.txtHora.Text = String.Empty;
            var lnuPosCursor = this.txtHoraVista.SelectionStart;
            var lcrValor = CrtForms.fcrFormatoCapturaHora("12", ":", this.txtHoraVista.Text);
            if (this.txtHoraVista.Text.Trim() != lcrValor.Trim())
            {
                this.txtHoraVista.Text = lcrValor;
                this.txtHoraVista.SelectionStart = CrtForms.fnuNewPosCursorHora("12", lnuPosCursor);
            }
            var lcrValorReturn = Funciones.fcrValidaHoraTexto(true, this.txtHoraVista.Text, "12", ":", "Hora ");
            if (String.IsNullOrWhiteSpace(lcrValorReturn))
            {
                this.txtHora.Text = Funciones.fcrConvierteHora(this.txtHoraVista.Text, "12", ":", ".");
                fcvColorBorder("NA", "#FF34C4EE");
                llgHoraOk = true;
            }
            else
            {
                fcvColorBorder(lcrValorReturn, "");
                llgHoraOk = false;
            }
        }
        #endregion
        //-------------------------------------------------
        //Formato para captura de la hora 
        //-------------------------------------------------
        /// <summary>
        /// <para>Recibe hora tipo texto y formato militar ejemplo (19.23)</para>
        /// <para>separador punto (.)</para>
        /// </summary>
        public void fcvCargarHora(String tcrHoraMilitar)
        {
            if (!String.IsNullOrWhiteSpace(tcrHoraMilitar))
            {
                this.txtHora.Text = tcrHoraMilitar;
                this.txtHoraVista.Text = Funciones.fcrConvierteHora(tcrHoraMilitar, "24", ".", ":");
            }
            else
            {
                this.txtHora.Text = String.Empty;
                this.txtHoraVista.Text = "  :  :  ";
            }
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
        #region fcvColorBorder: mostrar color del border segun vista
        public void fcvColorBorder(String tcrMensajeToolTip, String tcrColor)
        {
            if (String.IsNullOrWhiteSpace(tcrMensajeToolTip) || tcrMensajeToolTip == "NA")
            {
                this.objBorder.BorderBrush = EdtUtilidades.SetSolidColorBrush(tcrColor, "#FF34C4EE");
                this.txtHora.ToolTip = null;
            }
            else // "ERROR"
            {
                this.objBorder.BorderBrush = Brushes.Red; // rojo por error
                this.txtHora.ToolTip = tcrMensajeToolTip;
            }
        }
        #endregion
    }
}

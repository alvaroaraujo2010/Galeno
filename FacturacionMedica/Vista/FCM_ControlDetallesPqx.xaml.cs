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
using Datos.Modelos;
using Sistema.Modelo;
using Sistema.Utilidades;
using FacturacionMedica.Modelo;

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Interaction logic for FCM_ControlDetallesPqx.xaml
    /// </summary>
    public partial class ControlDetallesPqx : UserControl
    {
        public static DependencyProperty gcrIdCodigo = DependencyProperty.Register("ParamIdCodigo", typeof(String), typeof(ControlDetallesPqx));
        // Variable publica que recibe el parametro
        public String tcrIdCodigoProcedimiento
        {
            get { return (String)GetValue(gcrIdCodigo); }
            set { SetValue(gcrIdCodigo, value); }
        }
        int lnuTotal = 0;
        public EFfcmmansercompaq gobRePqx = null;

        public ControlDetallesPqx()
        {
            InitializeComponent();
        }
        private void fcvCargarDatos(object sender, RoutedEventArgs e)
        {
            lnuTotal = 0;
            this.stkDetalles.Children.Clear();
            gobRePqx = FCMValidarCodigo.fobRegBuscarFcmmansercompaqR1(tcrIdCodigoProcedimiento);
            this.Visibility = gobRePqx != null ? Visibility.Visible : Visibility.Collapsed;
            if (gobRePqx != null)
            {
                var tmpList = ModeloFcmmansercompaq.flsListaFcmmansercompaq(tcrIdCodigoProcedimiento, "1");
                foreach (var lobReg in tmpList)
                {
                    fcvAddRegistro(lobReg);
                }
            }
        }
        private void fcvAddRegistro(ModeloFcmmansercompaq tobReg)
        {
            var lobReg = new ControlDetallesPqxr();

            lobReg.gcrIdRegistro    = tobReg.Fcm_idesec_copq;
            lobReg.gcrIdRegMaestro  = tobReg.Fcm_idesec_mant;

            lobReg.txtCodigo.Text       = tobReg.Fcm_codser_mant;
            lobReg.txtCodigoDigita.Text = tobReg.Fcm_coddig_mant;
            lobReg.txtDescripcion.Text  = tobReg.Fcm_desser_mant;
            lobReg.txtCantidad.Text     = tobReg.Fcm_numuni_copq.ToString();
            lobReg.txtPuntaje.Text      = tobReg.Fcm_punuvr_mant.ToString();
            lobReg.txtValor.Text        = tobReg.Fcm_valser_mant.ToString();

            lnuTotal = lnuTotal + (int)tobReg.Fcm_valser_mant;

            this.stkDetalles.Children.Add(lobReg);
            this.lblTotal.Text = lnuTotal.ToString();
        }

    }
}

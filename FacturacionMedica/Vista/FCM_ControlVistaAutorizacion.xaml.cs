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

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Vista Registro autorizacion descuento en facturación FCM_ControlVistaAutorizacion.xaml
    /// </summary>
    public partial class ControlVistaAutorizacion : UserControl
    {
        #region IdUsuario: Identificacion del usuario
        /// <summary>
        /// Identificacion del usuario
        /// </summary>
        public static DependencyProperty tcrIdUsuario = DependencyProperty.Register("IdUsuario", typeof(String), typeof(ControlVistaAutorizacion));
        public String IdUsuario
        {
            get { return (String)GetValue(tcrIdUsuario); }
            set { SetValue(tcrIdUsuario, value); }
        }
        #endregion
        #region NombreUsuario: Nombre del usuario/paciente
        /// <summary>
        /// Nombre del usuario/paciente
        /// </summary>
        public static DependencyProperty tcrNombreUsuario = DependencyProperty.Register("NombreUsuario", typeof(String), typeof(ControlVistaAutorizacion));
        public String NombreUsuario
        {
            get { return (String)GetValue(tcrNombreUsuario); }
            set { SetValue(tcrNombreUsuario, value); }
        }
        #endregion
        #region ValorCobro: Valor a cobrar sin descuentos en facturación
        /// <summary>
        /// Valor a cobrar sin descuentos en facturación
        /// </summary>
        public static DependencyProperty tflValorCobro = DependencyProperty.Register("ValorCobro", typeof(float), typeof(ControlVistaAutorizacion));
        public float ValorCobro
        {
            get { return (float)GetValue(tflValorCobro); }
            set { SetValue(tflValorCobro, value); }
        }
        #endregion
        #region ValorDesSolict: Valor descuento solicitado en facturación
        /// <summary>
        /// Valor descuento solicitado en facturación
        /// </summary>
        public static DependencyProperty tflValorDesSolict = DependencyProperty.Register("ValorDesSolict", typeof(float), typeof(ControlVistaAutorizacion));
        public float ValorDesSolict
        {
            get { return (float)GetValue(tflValorDesSolict); }
            set { SetValue(tflValorDesSolict, value); }
        }
        #endregion
        #region ValorDesAutorizado: Valor descuento Autorizado
        /// <summary>
        /// Valor descuento Autorizado
        /// </summary>
        public static DependencyProperty tflValorDesAutorizado = DependencyProperty.Register("ValorDesAutorizado", typeof(float), typeof(ControlVistaAutorizacion));
        public float ValorDesAutorizado
        {
            get { return (float)GetValue(tflValorDesAutorizado); }
            set { SetValue(tflValorDesAutorizado, value); }
        }
        #endregion
        #region NombreFacturador: Nombre del usuario facturador que realiza solicitud
        /// <summary>
        /// Nombre del usuario facturador que realiza solicitud
        /// </summary>
        public static DependencyProperty tcrNombreFacturador = DependencyProperty.Register("NombreFacturador", typeof(String), typeof(ControlVistaAutorizacion));
        public String NombreFacturador
        {
            get { return (String)GetValue(tcrNombreFacturador); }
            set { SetValue(tcrNombreFacturador, value); }
        }
        #endregion
        #region FechaSolict: Fecha en que se realiza solicitud
        /// <summary>
        /// Nombre del usuario facturador que realiza solicitud
        /// </summary>
        public static DependencyProperty tdaFechaSolict = DependencyProperty.Register("FechaSolict", typeof(DateTime), typeof(ControlVistaAutorizacion));
        public DateTime FechaSolict
        {
            get { return (DateTime)GetValue(tdaFechaSolict); }
            set { SetValue(tdaFechaSolict, value); }
        }
        #endregion
        #region EstadoRegistro: Estado del registro  1=Abierto 2=Aprobado 3 = Aplicado al paciente 4 = Negado
        /// <summary>
        /// 1=Abierto 2=Aprobado 3 = Aplicado al paciente 4 = Negado o anulado
        /// </summary>
        public static DependencyProperty tcrEstadoRegistro = DependencyProperty.Register("EstadoRegistro", typeof(String), typeof(ControlVistaAutorizacion));
        public String EstadoRegistro
        {
            get { return (String)GetValue(tcrEstadoRegistro); }
            set { SetValue(tcrEstadoRegistro, value); }
        }
        #endregion

        public ControlVistaAutorizacion()
        {
            InitializeComponent();
        }
        private void fcvCargarDatos(object sender, RoutedEventArgs e)
        {
            this.txtSia_nroide_usua.Text = IdUsuario;
            this.txtSia_nomusu_usua.Text = NombreUsuario;
            this.txtFcm_valref_dfac.Text = ValorCobro.ToString().Trim();
            this.txtFcm_valdes_ades.Text = ValorDesSolict.ToString().Trim();
            this.txtFcm_valdes_dfac.Text = ValorDesAutorizado.ToString().Trim();
            this.txtDes_ususol_usux.Text = NombreFacturador;
            this.txtFcm_fecsol_ades.Text = FechaSolict.ToShortDateString();
            this.txtFcm_estaut_ades.Text = fcrEstadoRegistro(EstadoRegistro);
            fcvImagenEstadoRegistro(EstadoRegistro);
        }
        private String fcrEstadoRegistro(String tcrEstado)
        {
            var lcrEstado = "ABIERTA";
            switch (tcrEstado)
            {
                case "1":
                    lcrEstado = "ABIERTA";
                    break;

                case "2":
                    lcrEstado = "AUTORIZADA";
                    break;

                case "3":
                    lcrEstado = "APLICADA";
                    break;

                case "4":
                    lcrEstado = "NEGADA";
                    break;
            }
            return lcrEstado;
        }
        private void fcvImagenEstadoRegistro(String tcrEstado)
        {
            this.imgAbierto.Visibility = Visibility.Collapsed;
            this.imgAprobado .Visibility = Visibility.Collapsed;
            this.imgAplicado.Visibility = Visibility.Collapsed;
            this.imgNegado.Visibility = Visibility.Collapsed;

            switch (tcrEstado)
            {
                case "1":
                    this.imgAbierto.Visibility = Visibility.Visible;
                    break;

                case "2":
                    this.imgAprobado.Visibility = Visibility.Visible;
                    break;

                case "3":
                    this.imgAplicado.Visibility = Visibility.Visible;
                    break;

                case "4":
                    this.imgNegado.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}

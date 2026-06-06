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
using Datos.Modelos;
using Sistema.Utilidades;
using System.Reflection;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for HCL_SolicitOdontSelDientes.xaml
    /// </summary>
    public partial class SolicitOdontSelDientes : Window
    {
        public SolicitOdontSelDientes()
        {
            InitializeComponent();
            this.odnMixto.fcvActivarCapaSeleccion(Visibility.Visible);
            fcvActivarOdontogramaMixto();
        }
        //-------------------------------------------------------
        // Metodos Varios
        //-------------------------------------------------------
        #region Metodos Varios
        /// <summary>
        /// Metodos Varios
        /// </summary>
        private void btnCerrar_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        //-------------------------------------------------------
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        //-------------------------------------------------------
        private void objDataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            cmdAceptar.IsEnabled = true;
        }
        //-------------------------------------------------------
        /// <summary>
        /// Clic en Boton Cancelar
        /// </summary>
        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        // Cerrar la ventana
        #region cmdSalir_Click: Salir de la ventana
        /// <summary>
        /// Salir de la ventana
        /// </summary>
        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Hidden;
            // Quitar referencias a funciones
            this.Close();
        }
        #endregion
        //-------------------------------------------------------
        // Metodos de controles en formulario e interface
        //-------------------------------------------------------
        #region Metodos de controles en formulario e interface
        //-------------------------------------------------------
        // cmdAceptar_Click: Aceptar y cerrar vista 
        //-------------------------------------------------------
        /// <summary>
        /// Clic en Boton Aceptar
        /// </summary>
        private void cmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            fcvRetornoInterface(fcrListaSeleccionados());
        }
        #endregion
        //-------------------------------------------------------
        // fcvRetornoInterface: Retornar el valor al formulario 
        // principal
        //-------------------------------------------------------
        #region fcvRetornoInterface: Retornar el valor al formulario
        /// <summary>
        /// Retoma la interfase con la ventana principal
        /// entrega el codigo seleccionado y cierra el Browser
        /// </summary>
        private void fcvRetornoInterface(string tcrCodigSelect)
        {
            SIS_Interface lobRefEnlace = this.Owner as SIS_Interface;
            if (lobRefEnlace != null)
            {
                lobRefEnlace.fcvBuscarRegistro(tcrCodigSelect);
                this.Close();
            }

        }
        #endregion
        //-------------------------------------------------------
        // Marcas y Seleccion
        //-------------------------------------------------------
        #region fcvMarcarOdnAdultos click en boton marcar o desmarcar seleccion odontograma adulto
        /// <summary>
        ///  <para>click en boton marcar o desmarcar seleccion odontograma adulto</para>
        /// </summary>
        private void fcvMarcarOdnAdultos(object sender, RoutedEventArgs e)
        {
            var lobOpcion = (Button)sender;
            var lcrAccion = lobOpcion.Name == "cmdMarcaAdultos" ? "1" : "2";
            fcvMarcarTodos(lcrAccion, "1");
        }
        #endregion
        #region fcvMarcarOdnNiños click en boton marcar o desmarcar seleccion odontograma niños
        /// <summary>
        ///  <para>click en boton marcar o desmarcar seleccion odontograma niños</para>
        /// </summary>
        private void fcvMarcarOdnNiños(object sender, RoutedEventArgs e)
        {
            var lobOpcion = (Button)sender;
            var lcrAccion = lobOpcion.Name == "cmdMarcaNiños" ? "1" : "2";
            fcvMarcarTodos(lcrAccion, "2");
        }
        #endregion
        #region fcvMarcarTodos: Marcar o desmarcar todos
        /// <summary>
        /// Marcar o desmarcar todos
        /// <para>tcrAccion: 1= Marcar 2=Quitar marca</para>
        /// <para>tcrOdontograma: 1= Adulto 2= Niños</para>
        /// </summary>
        public void fcvMarcarTodos(String tcrAccion, String tcrOdontograma)
        {
            String lcrReturnCodigo = String.Empty;
            String lcrNumeroDiente = String.Empty;

            foreach (var lobReg in this.odnMixto.tmpDientes)
            {
                // Tipo diente
                lcrNumeroDiente = lobReg.IdDiente;

                if (tcrOdontograma == "1")
                {
                    if (Convert.ToInt32(lcrNumeroDiente) >= 11 && Convert.ToInt32(lcrNumeroDiente) <= 28 ||
                        Convert.ToInt32(lcrNumeroDiente) >= 31 && Convert.ToInt32(lcrNumeroDiente) <= 48)
                    {
                        fcvAddVistaGraficaEnOdontograma(tcrAccion, lcrNumeroDiente);
                    }
                }
                if (tcrOdontograma == "2")
                {
                    if (Convert.ToInt32(lcrNumeroDiente) >= 51 && Convert.ToInt32(lcrNumeroDiente) <= 65 ||
                        Convert.ToInt32(lcrNumeroDiente) >= 71 && Convert.ToInt32(lcrNumeroDiente) <= 86)
                    {
                        fcvAddVistaGraficaEnOdontograma(tcrAccion, lcrNumeroDiente);
                    }
                }
            }
        }
        #endregion
        #region fcrListaSeleccionados: Obtener lista de dientes Seleccionados
        /// <summary>
        /// Recorre el temporal de dientes para incluir los seleciconados
        /// en una variable String separada por guion(-)
        /// </summary>
        public String fcrListaSeleccionados()
        {
            String lcrReturnCodigo = String.Empty;
            String lcrSiSeleccion = String.Empty;

            foreach (var lobReg in this.odnMixto.tmpDientes)
            {
                lcrSiSeleccion = fcrSeleccionnDiente(lobReg.IdDiente);
                /*
                if (Convert.ToInt32(lcrNumeroDiente) >= 11 && Convert.ToInt32(lcrNumeroDiente) <= 28 ||
                    Convert.ToInt32(lcrNumeroDiente) >= 51 && Convert.ToInt32(lcrNumeroDiente) <= 65)
                {
                    Diente01 lobDiente = (Diente01)lobReg.RefObjeto;
                    lcrSiSeleccion = lobDiente.gcrSelect == "1" ? "1"  : "2";
                }
                else
                {
                    Diente02 lobDiente = (Diente02)lobReg.RefObjeto;
                    lcrSiSeleccion = lobDiente.gcrSelect == "1" ? "1" : "2";
                }
                */
                if (lcrSiSeleccion == "1")
                {
                    lcrReturnCodigo += String.IsNullOrWhiteSpace(lcrReturnCodigo) ? lobReg.IdDiente : "-" + lobReg.IdDiente;
                }
            }
            return lcrReturnCodigo;
        }
        #endregion
        #region fcrSeleccionnDiente: Estado seleccionado o no del diente
        /// <summary>
        /// <para>Devuelve el estado seleccionado o no del diente 1= Seleccionado 2= No seleccionado</para>
        /// </summary>
        public String fcrSeleccionnDiente(String tcrNumeroDiente)
        {
            FrameworkElement lobjDiente = null;
            var lcrSiSeleccion = "2";
            var lcrTipoDiente = "1";

            switch (tcrNumeroDiente)
            {
                #region Cuadrante 1 Adultos
                case "11":
                    lobjDiente = this.odnMixto.D11;
                    break;
                case "12":
                    lobjDiente = this.odnMixto.D12;
                    break;
                case "13":
                    lobjDiente = this.odnMixto.D13;
                    break;
                case "14":
                    lobjDiente = this.odnMixto.D14;
                    break;
                case "15":
                    lobjDiente = this.odnMixto.D15;
                    break;
                case "16":
                    lobjDiente = this.odnMixto.D16;
                    break;
                case "17":
                    lobjDiente = this.odnMixto.D17;
                    break;
                case "18":
                    lobjDiente = this.odnMixto.D18;
                    break;
                #endregion
                #region Cuadrante 2 Adultos
                case "21":
                    lobjDiente = this.odnMixto.D21;
                    break;
                case "22":
                    lobjDiente = this.odnMixto.D22;
                    break;
                case "23":
                    lobjDiente = this.odnMixto.D23;
                    break;
                case "24":
                    lobjDiente = this.odnMixto.D24;
                    break;
                case "25":
                    lobjDiente = this.odnMixto.D25;
                    break;
                case "26":
                    lobjDiente = this.odnMixto.D26;
                    break;
                case "27":
                    lobjDiente = this.odnMixto.D27;
                    break;
                case "28":
                    lobjDiente = this.odnMixto.D28;
                    break;
                #endregion
                #region Cuadrante 3 Adultos
                case "31":
                    lobjDiente = this.odnMixto.D31;
                    break;
                case "32":
                    lobjDiente = this.odnMixto.D32;
                    break;
                case "33":
                    lobjDiente = this.odnMixto.D33;
                    break;
                case "34":
                    lobjDiente = this.odnMixto.D34;
                    break;
                case "35":
                    lobjDiente = this.odnMixto.D35;
                    break;
                case "36":
                    lobjDiente = this.odnMixto.D36;
                    break;
                case "37":
                    lobjDiente = this.odnMixto.D37;
                    break;
                case "38":
                    lobjDiente = this.odnMixto.D38;
                    break;
                #endregion
                #region Cuadrante 4 Adultos
                case "41":
                    lobjDiente = this.odnMixto.D41;
                    break;
                case "42":
                    lobjDiente = this.odnMixto.D42;
                    break;
                case "43":
                    lobjDiente = this.odnMixto.D43;
                    break;
                case "44":
                    lobjDiente = this.odnMixto.D44;
                    break;
                case "45":
                    lobjDiente = this.odnMixto.D45;
                    break;
                case "46":
                    lobjDiente = this.odnMixto.D46;
                    break;
                case "47":
                    lobjDiente = this.odnMixto.D47;
                    break;
                case "48":
                    lobjDiente = this.odnMixto.D48;
                    break;
                #endregion
                #region Cuadrante 1 Niños
                case "51":
                    lobjDiente = this.odnMixto.D51;
                    break;
                case "52":
                    lobjDiente = this.odnMixto.D52;
                    break;
                case "53":
                    lobjDiente = this.odnMixto.D53;
                    break;
                case "54":
                    lobjDiente = this.odnMixto.D54;
                    break;
                case "55":
                    lobjDiente = this.odnMixto.D55;
                    break;
                #endregion
                #region Cuadrante 2 Niños
                case "61":
                    lobjDiente = this.odnMixto.D61;
                    break;
                case "62":
                    lobjDiente = this.odnMixto.D62;
                    break;
                case "63":
                    lobjDiente = this.odnMixto.D63;
                    break;
                case "64":
                    lobjDiente = this.odnMixto.D64;
                    break;
                case "65":
                    lobjDiente = this.odnMixto.D65;
                    break;
                #endregion
                #region Cuadrante 3 Niños
                case "71":
                    lobjDiente = this.odnMixto.D71;
                    break;
                case "72":
                    lobjDiente = this.odnMixto.D72;
                    break;
                case "73":
                    lobjDiente = this.odnMixto.D73;
                    break;
                case "74":
                    lobjDiente = this.odnMixto.D74;
                    break;
                case "75":
                    lobjDiente = this.odnMixto.D75;
                    break;
                #endregion
                #region Cuadrante 4 Niños
                case "81":
                    lobjDiente = this.odnMixto.D81;
                    break;
                case "82":
                    lobjDiente = this.odnMixto.D82;
                    break;
                case "83":
                    lobjDiente = this.odnMixto.D83;
                    break;
                case "84":
                    lobjDiente = this.odnMixto.D84;
                    break;
                case "85":
                    lobjDiente = this.odnMixto.D85;
                    break;
                #endregion
            }
            // Tipo diente
            if (Convert.ToInt32(tcrNumeroDiente) >= 11 && Convert.ToInt32(tcrNumeroDiente) <= 28 ||
                Convert.ToInt32(tcrNumeroDiente) >= 51 && Convert.ToInt32(tcrNumeroDiente) <= 65)
            {
                lcrTipoDiente = "1";
            }
            else
            {
                lcrTipoDiente = "2";
            }

            // Cargar en la vista del odontograma
            if (lcrTipoDiente == "1")
            {
                Diente01 lobDiente = (Diente01)lobjDiente;
                lcrSiSeleccion = lobDiente.gcrSelect == "1" ? "1" : "2";

            }
            else
            {
                Diente02 lobDiente = (Diente02)lobjDiente;
                lcrSiSeleccion = lobDiente.gcrSelect == "1" ? "1" : "2";
            }
            return lcrSiSeleccion;
        }
        #endregion
        //- Activar seleccion en odontograma
        #region fcvActivarOdontogramaMixto: Activar seleccion odontogrma adulto y niños en uno solo
        /// <summary>
        /// <para>fcvActivarOdontogramaMixto()</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Activar seleccion odontogrma adulto y niños en uno solo</para>
        /// </summary>
        public void fcvActivarOdontogramaMixto()
        {
            // Click Adulto
            #region Cuadrante 1
            this.odnMixto.D11.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D12.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D13.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D14.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D15.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D16.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D17.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D18.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 2
            this.odnMixto.D21.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D22.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D23.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D24.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D25.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D26.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D27.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D28.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 3
            this.odnMixto.D31.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D32.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D33.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D34.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D35.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D36.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D37.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D38.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            #region Cuadrante 4
            this.odnMixto.D41.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D42.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D43.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D44.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D45.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D46.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D47.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D48.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            // Touch Adulto
            #region Cuadrante 1
            this.odnMixto.D11.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D12.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D13.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D14.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D15.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D16.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D17.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D18.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 2
            this.odnMixto.D21.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D22.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D23.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D24.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D25.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D26.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D27.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D28.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 3
            this.odnMixto.D31.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D32.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D33.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D34.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D35.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D36.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D37.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D38.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
            #region Cuadrante 4
            this.odnMixto.D41.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D42.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D43.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D44.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D45.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D46.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D47.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D48.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
            // Click Niños
            #region Cuadrante 1
            this.odnMixto.D51.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D52.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D53.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D54.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D55.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 2
            this.odnMixto.D61.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D62.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D63.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D64.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            this.odnMixto.D65.MouseDown += new MouseButtonEventHandler(fcvClickItem01);
            #endregion
            #region Cuadrante 3
            this.odnMixto.D71.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D72.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D73.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D74.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D75.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            #region Cuadrante 4
            this.odnMixto.D81.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D82.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D83.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D84.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            this.odnMixto.D85.MouseDown += new MouseButtonEventHandler(fcvClickItem02);
            #endregion
            // Touch Niños
            #region Cuadrante 1
            this.odnMixto.D51.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D52.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D53.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D54.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D55.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 2
            this.odnMixto.D61.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D62.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D63.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D64.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            this.odnMixto.D65.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem01);
            #endregion
            #region Cuadrante 3
            this.odnMixto.D71.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D72.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D73.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D74.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D75.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
            #region Cuadrante 4
            this.odnMixto.D81.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D82.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D83.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D84.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            this.odnMixto.D85.TouchEnter += new EventHandler<TouchEventArgs>(fcvTilesTouchDownItem02);
            #endregion
        }
        #endregion
        // Click en cada diente
        #region Click o Touch sobre un item del odontograma
        /// <summary>
        ///  <para>fcvClickItem01: Click sobre un item del odontograma</para>
        /// </summary>
        private void fcvClickItem01(Object sender, MouseButtonEventArgs e)
        {
            Diente01 lobControl = (Diente01)sender;

            fcvSelectDiente01(ref lobControl);

        }
        /// <summary>
        ///  <para>fcvTilesTouchDownItem01: Touch sobre un item del odontograma</para>
        /// </summary>
        private void fcvTilesTouchDownItem01(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            Diente01 lobControl = (Diente01)sender;

            fcvSelectDiente01(ref lobControl);
        }
        /// <summary>
        ///  <para>fcvClickItem02: Click sobre un item del odontograma</para>
        /// </summary>
        private void fcvClickItem02(Object sender, MouseButtonEventArgs e)
        {
            Diente02 lobControl = (Diente02)sender;

            fcvSelectDiente02(ref lobControl);
        }
        /// <summary>
        ///  <para>fcvTilesTouchDownItem02: Touch sobre un item del odontograma</para>
        /// </summary>
        private void fcvTilesTouchDownItem02(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;

            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            Diente02 lobControl = (Diente02)sender;

            fcvSelectDiente02(ref lobControl);
           
        }
        #endregion
        #region fcvSelectDiente01: accion sobre dientes 01
        /// <summary>
        ///  <para>Accion sobre dientes 01</para>
        /// </summary>
        private void fcvSelectDiente01(ref Diente01 tobControl)
        {
            var lcrIdItemServicioGrafica = tobControl.gnuNumeroDiente.ToString();
            var lcrAccion = tobControl.gcrSelect == "1" ? "2" : "1";

            tobControl.gcrSelect = lcrAccion;
            fcvAddVistaGraficaEnOdontograma(lcrAccion, lcrIdItemServicioGrafica);

        }
        #endregion
        #region fcvSelectDiente02: accion sobre dientes 02
        /// <summary>
        ///  <para>Accion sobre dientes 02</para>
        /// </summary>
        private void fcvSelectDiente02(ref Diente02 tobControl)
        {
            var lcrIdItemServicioGrafica = tobControl.gnuNumeroDiente.ToString();
            var lcrAccion = tobControl.gcrSelect == "1" ? "2" : "1";

            tobControl.gcrSelect = lcrAccion;
            fcvAddVistaGraficaEnOdontograma(lcrAccion, lcrIdItemServicioGrafica);
           
        }
        #endregion
        //- Graficar y cargar registro detalles
        #region fcvAddVistaGraficaEnOdontograma: Genera vista graficada del registro detalle en odonograma
        /// <summary>
        /// <para>Marcar o desmarcar como selecionado</para>
        /// <para>PARAMETROS:</para>
        /// <para>lcrAccion: "1"= Marcar como seleccionado "2" = quitar marca de seleccionado</para>
        /// <para>tcrIdDiente: Numero del diente al que se le realizara el cambio</para>
        /// </summary>
        private void fcvAddVistaGraficaEnOdontograma(String tcrAccion, String tcrIdDiente)
        {
            var lcrRegistro = "I01R" + tcrIdDiente;

            if (tcrAccion == "1")
            {
                //  Revisar si ya existe la marca (por si se llama desde funcion por por lote)
                var lobRegx = this.odnMixto.fobRegSelectRegistro("IMAGEN", lcrRegistro).FirstOrDefault();
                // Marcar como seleccionado cuando no existe la marca 
                if (lobRegx == null)
                {
                    fcvMarcarGraficaDiente(tcrAccion, tcrIdDiente);
                    var lcrImagenGrafica = "hc_od_coronash4.png";
                    this.odnMixto.fcvGraficarImgenEnDiente(lcrRegistro, tcrIdDiente, "2", lcrImagenGrafica, "2");
                }
            }
            else
            { 
                // Quitar seleccion
                fcvMarcarGraficaDiente(tcrAccion, tcrIdDiente);
                this.odnMixto.flgEliminarImagenEnVista(lcrRegistro);
            }
        }
        #endregion
        #region fcvMarcarGraficaDiente: Establece el estado seleccionado o no del diente
        /// <summary>
        /// <para>Establece el estado seleccionado o no del diente</para>
        /// <para>tcrAccion: 1= Marcar 2=Desmarcar</para>
        /// </summary>
        public void fcvMarcarGraficaDiente(String tcrAccion, String tcrNumeroDiente)
        {
            FrameworkElement lobjDiente = null;
            var lcrTipoDiente = "1";

            switch (tcrNumeroDiente)
            {
                #region Cuadrante 1 Adultos
                case "11":
                    lobjDiente = this.odnMixto.D11;
                    break;
                case "12":
                    lobjDiente = this.odnMixto.D12;
                    break;
                case "13":
                    lobjDiente = this.odnMixto.D13;
                    break;
                case "14":
                    lobjDiente = this.odnMixto.D14;
                    break;
                case "15":
                    lobjDiente = this.odnMixto.D15;
                    break;
                case "16":
                    lobjDiente = this.odnMixto.D16;
                    break;
                case "17":
                    lobjDiente = this.odnMixto.D17;
                    break;
                case "18":
                    lobjDiente = this.odnMixto.D18;
                    break;
                #endregion
                #region Cuadrante 2 Adultos
                case "21":
                    lobjDiente = this.odnMixto.D21;
                    break;
                case "22":
                    lobjDiente = this.odnMixto.D22;
                    break;
                case "23":
                    lobjDiente = this.odnMixto.D23;
                    break;
                case "24":
                    lobjDiente = this.odnMixto.D24;
                    break;
                case "25":
                    lobjDiente = this.odnMixto.D25;
                    break;
                case "26":
                    lobjDiente = this.odnMixto.D26;
                    break;
                case "27":
                    lobjDiente = this.odnMixto.D27;
                    break;
                case "28":
                    lobjDiente = this.odnMixto.D28;
                    break;
                #endregion
                #region Cuadrante 3 Adultos
                case "31":
                    lobjDiente = this.odnMixto.D31;
                    break;
                case "32":
                    lobjDiente = this.odnMixto.D32;
                    break;
                case "33":
                    lobjDiente = this.odnMixto.D33;
                    break;
                case "34":
                    lobjDiente = this.odnMixto.D34;
                    break;
                case "35":
                    lobjDiente = this.odnMixto.D35;
                    break;
                case "36":
                    lobjDiente = this.odnMixto.D36;
                    break;
                case "37":
                    lobjDiente = this.odnMixto.D37;
                    break;
                case "38":
                    lobjDiente = this.odnMixto.D38;
                    break;
                #endregion
                #region Cuadrante 4 Adultos
                case "41":
                    lobjDiente = this.odnMixto.D41;
                    break;
                case "42":
                    lobjDiente = this.odnMixto.D42;
                    break;
                case "43":
                    lobjDiente = this.odnMixto.D43;
                    break;
                case "44":
                    lobjDiente = this.odnMixto.D44;
                    break;
                case "45":
                    lobjDiente = this.odnMixto.D45;
                    break;
                case "46":
                    lobjDiente = this.odnMixto.D46;
                    break;
                case "47":
                    lobjDiente = this.odnMixto.D47;
                    break;
                case "48":
                    lobjDiente = this.odnMixto.D48;
                    break;
                #endregion
                #region Cuadrante 1 Niños
                case "51":
                    lobjDiente = this.odnMixto.D51;
                    break;
                case "52":
                    lobjDiente = this.odnMixto.D52;
                    break;
                case "53":
                    lobjDiente = this.odnMixto.D53;
                    break;
                case "54":
                    lobjDiente = this.odnMixto.D54;
                    break;
                case "55":
                    lobjDiente = this.odnMixto.D55;
                    break;
                #endregion
                #region Cuadrante 2 Niños
                case "61":
                    lobjDiente = this.odnMixto.D61;
                    break;
                case "62":
                    lobjDiente = this.odnMixto.D62;
                    break;
                case "63":
                    lobjDiente = this.odnMixto.D63;
                    break;
                case "64":
                    lobjDiente = this.odnMixto.D64;
                    break;
                case "65":
                    lobjDiente = this.odnMixto.D65;
                    break;
                #endregion
                #region Cuadrante 3 Niños
                case "71":
                    lobjDiente = this.odnMixto.D71;
                    break;
                case "72":
                    lobjDiente = this.odnMixto.D72;
                    break;
                case "73":
                    lobjDiente = this.odnMixto.D73;
                    break;
                case "74":
                    lobjDiente = this.odnMixto.D74;
                    break;
                case "75":
                    lobjDiente = this.odnMixto.D75;
                    break;
                #endregion
                #region Cuadrante 4 Niños
                case "81":
                    lobjDiente = this.odnMixto.D81;
                    break;
                case "82":
                    lobjDiente = this.odnMixto.D82;
                    break;
                case "83":
                    lobjDiente = this.odnMixto.D83;
                    break;
                case "84":
                    lobjDiente = this.odnMixto.D84;
                    break;
                case "85":
                    lobjDiente = this.odnMixto.D85;
                    break;
                #endregion
            }
            // Tipo diente
            if (Convert.ToInt32(tcrNumeroDiente) >= 11 && Convert.ToInt32(tcrNumeroDiente) <= 28 ||
                Convert.ToInt32(tcrNumeroDiente) >= 51 && Convert.ToInt32(tcrNumeroDiente) <= 65)
            {
                lcrTipoDiente = "1";
            }
            else
            {
                lcrTipoDiente = "2";
            }

            // Cargar en la vista del odontograma
            if (lcrTipoDiente == "1")
            {
                Diente01 lobDiente = (Diente01)lobjDiente;
                lobDiente.gcrSelect = tcrAccion == "1" ? "1" : "2";
            }
            else
            {
                Diente02 lobDiente = (Diente02)lobjDiente;
                lobDiente.gcrSelect = tcrAccion == "1" ? "1" : "2";
            }
        }
        #endregion
    }
}

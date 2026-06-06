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
using System.IO;
using Sistema.Utilidades;
using Sistema.Modelo;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for ControlFirma.xaml
    /// </summary>
    public partial class ControlFirmaProfesional : UserControl
    {
        /*
        public TextBox txtNombreFondo = null;
        public TextBox txtNombre = null;
        public TextBox txtEspecialidad = null;
        public Image ImgFirma = null;
        */
        Aplicacion oApp = Aplicacion.Instancia();
        private String gcrRutaImgGaleria = String.Empty;
        private String gcrRutaImgDestino = String.Empty;

        public ControlFirmaProfesional()
        {
            InitializeComponent();

            gcrRutaImgGaleria = oApp.gcrAppRecursoPath + @"\Imagenes\General\Sistemas";
            gcrRutaImgDestino = oApp.gcrAppRecursoIpServidor + @"\" + oApp.gcrAppRecursoInicioPath + @"\" + gcrRutaImgGaleria;

        }
        //-------------------------------------------------
        // Tomar Referencia objetos
        //-------------------------------------------------
        #region Tomar Referencia del objeto
        private void fcvLoadedTextoFirma(object sender, RoutedEventArgs e)
        {
            this.txtNombre = (TextBox)sender;
        }
        private void fcvLoadedTextoFirmaFondo(object sender, RoutedEventArgs e)
        {
            this.txtNombreFondo = (TextBox)sender;
        }
        private void fcvLoadedTextoEspecialidad(object sender, RoutedEventArgs e)
        {
            this.txtEspecialidad = (TextBox)sender;
        }
        private void fcvLoadedImagen(object sender, RoutedEventArgs e)
        {
            this.ImgFirma = (Image)sender;
        }
        #endregion
        //-------------------------------------------------
        // Datos del profesional
        //-------------------------------------------------
        #region fcvCargarVista: Cargar los datos del profesional que presta servicio
        /// <summary>
        /// <para>Cargar los datos del profesional que presta servicio</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrCodigo: Codigo del profesional que presta servicio</para>
        /// </summary>
        public void fcvCargarVista(String tcrCodigo)
        {
            this.ImgFirma.Source = null;
            var tmp = ModeloSiamaeprofsalud.flsListaSiamaeprofsaludEx("1", tcrCodigo);

            if (tmp != null)
            {
                // Registro 
                this.txtRegistro.Text = tmp.Sia_rmedic_prof != null ? "REGISTRO: " + tmp.Sia_rmedic_prof.Trim() : String.Empty;
                // Nombre
                this.txtNombre.Text = "[" + tcrCodigo + "] " + tmp.Sia_nompro_prof.Trim() + " " + this.txtRegistro.Text;
                this.txtNombreFondo.Text = this.txtNombre.Text;
                // Profesion salud 
                this.txtEspecialidad.Text = tmp.Sia_desprm_prom;

                // Mostrar la firma
                if (!String.IsNullOrWhiteSpace(tmp.Sia_ifirma_prof))
                {
                    String lcrArchivoOrigen = gcrRutaImgDestino + @"\" + tmp.Sia_ifirma_prof.Trim();
                    if (oApp.gcrAppRecursoTipoIpServidor != "NORED")
                    {

                        lcrArchivoOrigen = @"\\" + gcrRutaImgDestino + @"\" + tmp.Sia_ifirma_prof.Trim();
                        lcrArchivoOrigen = System.IO.Path.Combine(lcrArchivoOrigen);
                    }
                    //MessageBox.Show("ruta firma " + lcrArchivoOrigen);
                    if (File.Exists(lcrArchivoOrigen))
                    {
                        var lobUri = new Uri(lcrArchivoOrigen, UriKind.RelativeOrAbsolute);
                        // Mostrar la imagen
                        this.ImgFirma.Source = new BitmapImage(lobUri);
                    }
                }
            }
        }
        #endregion

    }
}

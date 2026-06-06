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
using GestorReportes.Utilidades;

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for TileImgPredefinidas.xaml
    /// </summary>
    public partial class TileImgPredefinidas : UserControl
    {
        public TileImgPredefinidas()
        {
            InitializeComponent();
            this.IsManipulationEnabled = true;
        }
        public String Codigo { get; set; }
        public String Titulo { get; set; }
        public String ImagenWidth { get; set; }
        public String ImagenHeight { get; set; }
        public String RecursoArchivoCodigo { get; set; }
        public String RecursoArchivoUri { get; set; }
        public String RecursoArchivoNombre { get; set; }

        /// <summary>
        /// <para>Generar la vista de la imagen en el boton</para>
        /// </summary>
        public void fcvCargarVista(String tcrAppIpServidor, String tcrAppInicioPath, XmlEntorno.ClassXmlImgPredefinidas tobImagen)
        {
            // Generar la vista del objeto
            var lobUri = new EdtUtilidades.ObjetoBitmapImage();

            lobUri.AppIpServidor  = tcrAppIpServidor;
            lobUri.AppInicioPath  = tcrAppInicioPath;
            lobUri.RutaGaleria    = tobImagen.RecursoArchivoUri;
            lobUri.NombreArchivo  = tobImagen.RecursoArchivoNombre;
            this.imgImagen.Source = EdtUtilidades.SetBitmapImageUri(lobUri);
            this.txtTexto.Text    = tobImagen.Titulo;

            // Guardar valores para futuro
            Codigo               = tobImagen.Codigo;
            Titulo               = tobImagen.Titulo;
            ImagenWidth          = tobImagen.ImagenWidth;
            ImagenHeight         = tobImagen.ImagenHeight;
            RecursoArchivoCodigo = tobImagen.RecursoArchivoCodigo;
            RecursoArchivoUri    = tobImagen.RecursoArchivoUri;
            RecursoArchivoNombre = tobImagen.RecursoArchivoNombre;
        }
    }
}

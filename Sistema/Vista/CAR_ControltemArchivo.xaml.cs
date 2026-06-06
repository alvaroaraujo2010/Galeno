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

namespace Sistema.Vista
{
    /// <summary>
    /// Interaction logic for EST_ControlAddGrupoDe.xaml
    /// </summary>
    public partial class ControlCorreoItemArchivo : UserControl
    {

        /// <summary>
        /// Codigo unico del registro en temporal TmpGestionItem/TmpListCondicion que referencia al objeto ControlAddGrupoDe
        /// </summary>
        public string ItemllaveRegistro = string.Empty;
        /// <summary>
        /// Solo ruta del archivo
        /// </summary>
        public string RutaArchivo = string.Empty;
        /// <summary>
        /// Ruta del archivo y nombre
        /// </summary>
        public string RutaYNombre = string.Empty;
        /// <summary>
        /// Tamaño en KB
        /// </summary>
        public string Tamano = string.Empty;
        /// <summary>
        /// Tipo archivo: PDF/XML/ZIP/RAR/XLS/DOC/TXT/... 
        /// </summary>
        public string TipoArchivo = string.Empty;

        /// <summary>
        /// Nombre del archivo con extención
        /// </summary>
        public string NombreArchivo = string.Empty;

        public ControlCorreoItemArchivo()
        {
            InitializeComponent();
        }
    }
}

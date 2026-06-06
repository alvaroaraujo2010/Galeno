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
    /// Interaction logic for TileOdontSelectGrupo.xaml
    /// </summary>
    public partial class TileOdontSelectGrupo : UserControl
    {
        public TileOdontSelectGrupo()
        {
            InitializeComponent();
            this.IsManipulationEnabled = true;
        }
        public String CodigoRegistro { get; set; }

        /// <summary>
        /// <para>Generar la vista de la imagen en el boton</para>
        /// </summary>
        public void fcvCargarVista(EdtUtilidades.ObjetoBitmapImage tobImagen)
        {
            // Generar la vista del objeto
            this.imgImagen.Source    = EdtUtilidades.SetBitmapImageUri(tobImagen);
            this.txtTexto.Text       = tobImagen.RecursoTitulo;
            this.cmdRegistro.ToolTip = tobImagen.RecursoDescripcion;
        }
    }
}

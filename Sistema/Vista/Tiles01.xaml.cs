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
    /// Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tiles01 : UserControl
    {
        public Tiles01()
        {
            InitializeComponent();
            this.IsManipulationEnabled = true;
        }
        public int    gnuIndiceGrupo { get; set; }
        public int    gnuIndice { get; set; }
        public string gcrCodigoItem { get; set; }
        public string gcrTitulo { get; set; }
        public string gcrImgIcono { get; set; }
        public string gcrImgTiles { get; set; }
        public string gcrRutImagen { get; set; }
        public string gcrComponente { get; set; }
        public string[] garDatos { get; set; }
        public Window gobRefForm { get; set; }

        private void fcvTilesTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement lobObj = sender as FrameworkElement;
            if (lobObj == null) return;
            lobObj.CaptureTouch(e.TouchDevice);
            e.Handled = true;
        }
    }
}

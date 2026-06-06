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
    public partial class Tiles02 : UserControl
    {
        public Tiles02()
        {
            InitializeComponent();
            this.IsManipulationEnabled = true;
        }
        public int gnuIndiceGrupo { get; set; }
        public int gnuIndice { get; set; }
        public string gcrCodigoItem { get; set; }
        public string gcrTexto1 { get; set; }
        public string gcrTexto2 { get; set; }
        public string gcrTexto3 { get; set; }
        public string gcrTexto4 { get; set; }
        public string gcrTexto5 { get; set; }
        public string gcrTexto6 { get; set; }
        public string gcrTexto7 { get; set; }
        public string gcrImgIcono { get; set; }
        public string gcrImgTiles { get; set; }
        public string gcrImgCapa { get; set; }
        public string gcrRutImagen { get; set; }
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

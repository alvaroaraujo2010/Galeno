using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using Inicio.VistaModelo;
using System.Windows;
using Hospitalizacion.Vista;

namespace Inicio.Vista
{
    /// <summary>
    /// Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : UserControl
    {
        public Tile()
        {
            InitializeComponent();
        }
        public string gcrAccion { get; set; }
        public string gcrTituloModulo { get; set; }
        public string gcrModulo { get; set; }
        public string gcrComponente { get; set; }
        public string gcrImgIcono { get; set; }
        public string gcrImgTiles { get; set; }
        private void Tile_PreviewMouseDoubleClick(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.gcrAccion == "AbrirModulo")
            {
                //MainWindow form = new MainWindow(Modulo);
                MenuComponentes form = new MenuComponentes(gcrModulo, gcrTituloModulo, gcrImgIcono, gcrImgTiles);
                form.Show();
            }
            if (this.gcrAccion == "AbrirFormulario")
            {
                fcEjecutarFormulario(gcrComponente);
            }
        }
        public void fcEjecutarFormulario(String tcrComponente)
        {
            switch(tcrComponente)
            {
                case "FRM001":
                    VistaxHoscamasareas frm001 = new VistaxHoscamasareas();
                    frm001.Show();
                    break;
                case "FRM002":
                    VistaBxHoshabitaciones frm002 = new VistaBxHoshabitaciones();
                     frm002.Show(); 
                    break;
                case "FRM003":
                    VistaBcHoshabitaciones frm003 = new VistaBcHoshabitaciones();
                    frm003.Show();
                    break;
                    
            }
        }
    }
}

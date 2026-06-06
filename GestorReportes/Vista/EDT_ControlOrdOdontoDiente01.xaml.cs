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

namespace GestorReportes.Vista
{
    /// <summary>
    /// Interaction logic for EDT_ControlOrdOdontoDiente01.xaml
    /// </summary>
    public partial class Diente01 : UserControl
    {
        public String gcrCuadranteActivo = String.Empty;
        public int gnuNumeroDiente = 0;
        public int gnuContOcultDiente = 0;
        public String gcrSelect = "2"; // No seleccionado por defecto

        public Diente01()
        {
            InitializeComponent();
        }
    }
}

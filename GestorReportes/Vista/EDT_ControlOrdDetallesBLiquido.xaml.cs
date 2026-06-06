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
    /// Interaction logic for EDT_ControlOrdDetallesBLiquido.xaml
    /// </summary>
    public partial class ControlOrdDetallesBLiquido : UserControl
    {
        public ControlOrdDetallesBLiquido()
        {
            InitializeComponent();
        }
        public String TipoRegistro = "1";  // Adminstracion de liquido por defecto
        public String IdR1Registro = String.Empty;
        public String IdRegistro = String.Empty;
    }
}

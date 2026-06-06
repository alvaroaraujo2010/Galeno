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

namespace FacturacionMedica.Vista
{
    /// <summary>
    /// Interaction logic for FCM_ControlDetallesPqxr.xaml
    /// control para mostrar cada uno de los rregistros detalle
    /// </summary>
    public partial class ControlDetallesPqxr : UserControl
    {
        public String gcrIdRegistro = String.Empty;
        public String gcrIdRegMaestro = String.Empty;

        public ControlDetallesPqxr()
        {
            InitializeComponent();
        }
    }
}

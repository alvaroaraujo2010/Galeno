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

namespace Estadisticas.Vista
{
    /// <summary>
    /// Interaction logic for EST_ControlAddGrupoDe.xaml
    /// </summary>
    public partial class ControlAddGrupoDe : UserControl
    {

        /// <summary>
        /// Codigo unico del registro en temporal TmpGestionItem/TmpListCondicion que referencia al objeto ControlAddGrupoDe
        /// </summary>
        public String ItemllaveRegistro = String.Empty;
        /// <summary>
        /// Nombre unico del item o campo representado en la vista ejemplo: Sys_codusu_sist,Adm_nroide_usua... /item1,item2...
        /// </summary>
        public String gcrNombreItem = String.Empty;

        public ControlAddGrupoDe()
        {
            InitializeComponent();
        }
    }
}

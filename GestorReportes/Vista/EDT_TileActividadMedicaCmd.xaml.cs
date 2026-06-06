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
    /// Interaction logic for EDT_TileCmdActividadMedica.xaml
    /// </summary>
    public partial class ActividadMedicaCmd : UserControl
    {
        public ActividadMedicaCmd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Codigo actividad medica ejemplo: PYP-CRTL-CRECIM-DSARR
        /// </summary>
        public String CodigoActividad { get; set; }
        /// <summary>
        /// Grupos actividades medicas
        /// </summary>
        public String CodigoGrupo { get; set; }

    }
}

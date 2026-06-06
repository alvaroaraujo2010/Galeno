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
using System.Drawing.Printing;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;

namespace Reportes.Utilidades
{
    public static class FCMEjecutarReporte
    {
        public static void fcvEjecutar(String tcrCodigoReporte, ref DataSet01 tobDataSet, bool tlgVistaPrevia, Window tobOwner)
        {

            switch (tcrCodigoReporte)
            {
                case "FCM001": // Vista facturas 
                    //- Reporte 1

                    FCM_PrnFacturas01 lobReporte = new FCM_PrnFacturas01();
                    lobReporte.SetDataSource(tobDataSet);

                    VisorReportes lobVisor = new VisorReportes();
                    lobVisor.llgVistaPrevia = tlgVistaPrevia;
                    lobVisor.crpVisor.ViewerCore.ReportSource = lobReporte;
                    lobVisor.Owner= tobOwner;
                    lobVisor.ShowDialog(); 
                    break;

                case "FCM002":
                    //- Reporte 2
                    break;
            }
        }
    }
}

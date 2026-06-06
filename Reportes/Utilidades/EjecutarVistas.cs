using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
//using Reportes.Vista;

namespace Reportes.Utilidades
{
    public static class REPEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "REPP001":
                    //- Reporte 1
                    //VistaSspRes4505 lobREPP001 = new VistaSspRes4505(null, null);
                    //lobREPP001.ShowDialog();
                    break;

                case "REPP002":
                    //- Reporte 2
                    //VistaSspRes4505 lobREPP002 = new VistaSspRes4505(null, null);
                    //lobREPP002.ShowDialog();
                    break;
            }
        }
    }
}
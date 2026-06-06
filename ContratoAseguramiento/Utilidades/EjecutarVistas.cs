using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using ContratoAseguramiento.Vista;

namespace ContratoAseguramiento.Utilidades
{
    public static class CTOEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "CTO001":
                    //- Maestro de Contratos de Aseguramiento
                    VistaCtomaestrocontratos lobCTO001 = new VistaCtomaestrocontratos();
                    lobCTO001.Owner = tobOwner;
                    lobCTO001.ShowDialog();
                    break;

                case "CTO002":
                    //- Cargar Base de datos
                    VistaCargarbasededatos lobCTO002 = new VistaCargarbasededatos();
                    lobCTO002.Owner = tobOwner;
                    lobCTO002.ShowDialog();
                    break;
            }
        }
    }
}
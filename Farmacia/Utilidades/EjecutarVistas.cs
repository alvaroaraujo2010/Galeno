using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using Farmacia.Vista;

namespace Farmacia.Utilidades
{
    public static class FAREjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "FAR001":
                    // Entrega de medicamentos
                    VistaEntregaMedica lobFar001 = new VistaEntregaMedica();
                    lobFar001.Owner = tobOwner;
                    lobFar001.ShowDialog();
                    break;

                case "FAR002":
                    // Expedientes de medicamentos
                    VistaFarExpedienteMedicamento lobFar002 = new VistaFarExpedienteMedicamento();
                    lobFar002.Owner = tobOwner;
                    lobFar002.ShowDialog();
                    break;
            }
        }
    }
}
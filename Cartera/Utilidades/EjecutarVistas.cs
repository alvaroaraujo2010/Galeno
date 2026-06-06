using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using Cartera.Vista;
using Sistema.Vista;

namespace Cartera.Utilidades
{
    public static class CAREjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "CAR001":
                    //- Titulo Formulario: 
                    VistaCarGenFactDian lobCar001 = new VistaCarGenFactDian();
                    lobCar001.Owner = tobOwner;
                    lobCar001.ShowDialog();
                    break;

                case "CAR002":
                    //- Conceptos para facturas de venta
                    VistaCarconceptfact lobCar002 = new VistaCarconceptfact();
                    lobCar002.Owner = tobOwner;
                    lobCar002.ShowDialog();
                    break;

                case "CAR003":
                    //- Conceptos para facturas de venta
                    VistaGestorCorreos lobCar003 = new VistaGestorCorreos("NA","");
                    lobCar003.Owner = tobOwner;
                    lobCar003.ShowDialog();
                    break;
            }
            System.GC.Collect();
        }
    }
}
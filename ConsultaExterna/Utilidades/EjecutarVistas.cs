using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using ConsultaExterna.Vista;
using Sistema.Utilidades;

namespace ConsultaExterna.Utilidades
{
    public static class CEXEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "CEX001":
                    //- Vista pacientes por agenda de citas ambulatorias
                    VistaConsultaExterna lobCEX004 = new VistaConsultaExterna("Atención ambulatoria");
                    lobCEX004.Owner = tobOwner;
                    lobCEX004.ShowDialog();
                    break;
					
                case "CEX002":
                    //- OTROS
                    break;
            }
        }
    }
}
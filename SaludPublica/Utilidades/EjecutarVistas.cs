using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using SaludPublica.Vista;

namespace SaludPublica.Utilidades
{
    public static class SSPEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "SSP001":
                    //- Maestro res4505
                    VistaSspRes4505 lobSSP001 = new VistaSspRes4505(null, null);
                    lobSSP001.Owner = tobOwner;
                    lobSSP001.ShowDialog();
                    break;

                case "SSP002":
                    //- Tabla Periodos
                    VistaSptablaperiodos lobSSP002 = new VistaSptablaperiodos();
                    lobSSP002.Owner = tobOwner;
                    lobSSP002.ShowDialog();
                    break;

                case "SSP003":
                    //- Tabla Campos de la 4505
                    VistaSptabcampos4505 lobSSP003 = new VistaSptabcampos4505();
                    lobSSP003.Owner = tobOwner;
                    lobSSP003.ShowDialog();
                    break;

                case "SSP004":
                    //- validación
                    VistaGestionValidacion lobSSP004 = new VistaGestionValidacion();
                    lobSSP004.Owner = tobOwner;
                    lobSSP004.ShowDialog();
                    break;
            }
        }
    }
}
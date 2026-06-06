using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using CitasMedicas.Vista;

namespace CitasMedicas.Utilidades
{
    public static class CITEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "CIT001":
                    //- Titulo Formulario: 
                    VistaCitmaestroserviciosprog lobCIT001 = new VistaCitmaestroserviciosprog();
                    lobCIT001.Owner = tobOwner;
                    lobCIT001.ShowDialog();
                    break;

                case "CIT002":
                    //- gestion Maestro asignacion turnos a profesionales medicos
                    VistaCitmaestroturno lobCIT002 = new VistaCitmaestroturno();
                    lobCIT002.Owner = tobOwner;
                    lobCIT002.ShowDialog();
                    break;

                case "CIT003":
                    //- Asignar Citas Medicas
                    VistaMenuasignarcitas lobCIT003 = new VistaMenuasignarcitas();
                    lobCIT003.Owner = tobOwner;
                    lobCIT003.ShowDialog();
                    break;

                case "CIT004":
                    //- Confirmar Citas Medicas
                    //VistaConfirmarcitas lobCIT004 = new VistaConfirmarcitas();
                    //lobCIT004.Show();
                    break;
                    
            }
            System.GC.Collect();
        }
    }
}
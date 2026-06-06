using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using ConfigAsistencial.Vista;
using Sistema.Vista;

namespace ConfigAsistencial.Utilidades
{
    public static class SIAEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "SIA001":
                    //- Maestro de profesionales que prestan servicios de salud
                    VistaSiamaeprofsalud lobSIA001 = new VistaSiamaeprofsalud();
                    lobSIA001.ShowDialog();
                    break;

                case "SIA002":
                    //- Maestro de Usuarios Atendidos
                    VistaSiaUsuariosAtendidos lobSIA002 = new VistaSiaUsuariosAtendidos("DFL","","","","");
                    lobSIA002.Show();
                    break;

                case "SIA003":
                    //- Maestro Copagos para Nivel Sisben
                    VistaSiacopagosisben lobSIA003 = new VistaSiacopagosisben();
                    lobSIA003.ShowDialog();
                    break;

                case "SIA004":
                    //- Maestro Copagos para Contributivo
                    VistaSiacopagcontrib lobSIA004 = new VistaSiacopagcontrib();
                    lobSIA004.ShowDialog();
                    break;

                case "SIA005":
                    //- Maestro Eps
                    VistaSiatablaeps lobSIA005 = new VistaSiatablaeps();
                    lobSIA005.ShowDialog();
                    break;

                case "SIA006":
                    //- Maestro Diagnosticos Cie-10
                    VistaSiaDiagnosticos lobSIA006 = new VistaSiaDiagnosticos();
                    lobSIA006.ShowDialog();
                    break;
                    
                case "SIAX10":
                    //- Gestion codigo fuente validacion de archivos
                    VistaSismaesplavalid lobSIAX10 = new VistaSismaesplavalid();
                    lobSIAX10.ShowDialog();
                    break;

                case "SIA012":
                    //- Gestion Abrir registros facturacion
                    AbrirRegistrosAdm lobSIA012= new AbrirRegistrosAdm();
                    lobSIA012.ShowDialog();
                    break;
            }
        }
    }
}
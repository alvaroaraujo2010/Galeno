using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using Admision.Vista;
using Sistema.Utilidades;

namespace Admision.Utilidades
{
    public static class ADMEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            var lcrCodProfActivo = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario);
            switch (tcrComponente)
            {
                case "ADM001":
                    //- Admision de pacientes
                    VistaAdmadmisiones lobADM001 = new VistaAdmadmisiones("","","","","");
                    lobADM001.Owner = tobOwner;
                    lobADM001.ShowDialog();
                    break;
                case "ADM002":
                    //- Egreso de pacientes
                    //VistaRegistrosalida lobADM002 = new VistaRegistrosalida("", "", "", "", "");
                    //lobADM002.ShowDialog();
                    break;

                case "ADM003":
                    //- Vista pacientes admitidos
                    /*
                    if (!String.IsNullOrWhiteSpace(lcrCodProfActivo.sia_codpfa_prof))
                    {
                        VistaAdmitidos lobADM003 = new VistaAdmitidos("1", "2", "AR", "", "Atención Admitidos", "sys_adm01.png");
                        lobADM003.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usuario activo, no esta registrado como profesional que presta servicios de salud.");
                    }
                    */
                    break;

                case "ADM004":
                    //- Vista pacientes por agenda de citas ambulatorias
                    if (!String.IsNullOrWhiteSpace(lcrCodProfActivo.sia_codpfa_prof))
                    {
                        //VistaAdmitidos lobADM004 = new VistaAdmitidos("2", "1", "PA-TURNO", "", "Atención ambulatoria - " + lcrCodProfActivo.sia_nompro_prof.Trim(), "sys_adm01.png");
                        //lobADM004.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usuario activo, no esta registrado como profesional que presta servicios de salud.");
                    }
                    break;

                case "ADM007":
                    //- Valoracion Triage
                    VistaValoracionTriage lobADM007 = new VistaValoracionTriage("", "", "", "", "");
                    lobADM007.Owner = tobOwner;
                    lobADM007.ShowDialog();
                    break;

                case "ADM008":
                    //- Configuracion Traige
                    VistaConfigTriage lobADM008 = new VistaConfigTriage();
                    lobADM008.Owner = tobOwner;
                    lobADM008.ShowDialog();
                    break;

            }
        }
    }
}
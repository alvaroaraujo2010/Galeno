using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using Hospitalizacion.Vista;
using Sistema.Utilidades;

namespace Hospitalizacion.Utilidades
{
    public static class HOSEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            Aplicacion oApp = Aplicacion.Instancia();
            var lcrCodProfActivo = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(oApp.gcrUsuIdUsuario);

            switch (tcrComponente)
            {
                case "ADM002":
                    VistaRegistrosalida ADM002 = new VistaRegistrosalida("DFL","","","","");
                    ADM002.Owner = tobOwner;
                    ADM002.ShowDialog();
                    break;

                case "ADM006":
                    VistaAutorizarEgreso ADM006 = new VistaAutorizarEgreso("DFL", "", "", "", "");
                    ADM006.Owner = tobOwner;
                    ADM006.ShowDialog();
                    break;

                case "FRM001":
                    VistaHoscamasareas frm001 = new VistaHoscamasareas();
                    frm001.Owner = tobOwner;
                    frm001.ShowDialog();
                    break;
                case "FRM002":
                    VistaBxHoshabitaciones frm002 = new VistaBxHoshabitaciones();
                    frm002.Owner = tobOwner;
                    frm002.ShowDialog();
                    break;
                case "FRM003": // Vista admitidos
                    //- Vista pacientes admitidos
                    if (!String.IsNullOrWhiteSpace(lcrCodProfActivo.sia_codpfa_prof))
                    {
                        VistaAdmitidos lobADM003 = new VistaAdmitidos("1", "2", "AR", "", "Atención Admitidos", "sys_adm01.png");
                        lobADM003.Owner = tobOwner;
                        lobADM003.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Usuario activo, no esta registrado como profesional que presta servicios de salud.");
                    }
                    break;

                case "HOS006":
                    // REGISTRO EGRESO DE URGENCIAS
                    VistaHosEgresoUrgencias HOS006 = new VistaHosEgresoUrgencias("DFL", "", "", "", "");
                    HOS006.Owner = tobOwner;
                    HOS006.ShowDialog();
                    break;

                case "HOS007":
                    // REGISTRO EGRESO RTASLADO CAMA
                    VistaTrasladoCama HOS007 = new VistaTrasladoCama("DFL", "", "", "", "");
                    HOS007.Owner = tobOwner;
                    HOS007.ShowDialog();
                    break;

                case "HOS008":
                    // REGISTRO CONFIGURACION DEL MODULO
                    VistaHosconfigmodulo HOS008 = new VistaHosconfigmodulo();
                    HOS008.Owner = tobOwner;
                    HOS008.ShowDialog();
                    break;
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using Systemas.Vista;
using Sistema.Vista;
using Sistema.Utilidades;

namespace Systemas.Utilidades
{
    public static class SYSEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "SYS001":// Generador de Secuenciales
                    //- Titulo Formulario: Generador de Secuenciales
                    VistaSysgeneradorcod lobSYS001 = new VistaSysgeneradorcod();
                    lobSYS001.Show();
                    break;

                case "SYS002":// Usuarios del Sistema
                    //- Titulo Formulario: Usuarios del Sistema
                    VistaSysusuarios lobSYS002 = new VistaSysusuarios();
                    lobSYS002.Show();
                    break;
                
                case "SYS003":// Perfiles de Usuarios
                    //- Titulo Formulario: Perfiles de Usuarios
                    VistaSysperfiusuario lobSYS003 = new VistaSysperfiusuario();
                    lobSYS003.Show();
                    break;

                case "SIS001":// Parametros IPS
                    //- Parametros generales IPS
                    VistaSisparametroips lobSIS001 = new VistaSisparametroips();
                    lobSIS001.Show();
                    break;

                case "SIS002":// Maestro Terceros Contables
                    //- Maestro Terceros Contables
                    VistaSisMaestroterceros lobSIS002 = new VistaSisMaestroterceros();
                    lobSIS002.Show();
                    break;
            }
        }
    }
}
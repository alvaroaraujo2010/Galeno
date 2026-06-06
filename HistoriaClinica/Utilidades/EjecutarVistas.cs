using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using GestorReportes.Vista;
using HistoriasClinicas.Vista;

namespace HistoriasClinicas.Utilidades
{
    public static class HCLEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "HCL001":
                    // Editor fotmatos de historia clinica
                    VistaEditorReportes lobHCL001 = new VistaEditorReportes();
                    lobHCL001.Owner = tobOwner;
                    lobHCL001.ShowDialog();
                    break;

                case "HCL002":
                    // Cáptura fotmatos de historia clinica
                    VistaCapturaReportes lobHCL002 = new VistaCapturaReportes("","","");
                    lobHCL002.Owner = tobOwner;
                    lobHCL002.ShowDialog();
                    break;
					
                case "HCL003":
                    //- Maestro de Historia Clínicas: 
                    VistaHclmaehistoriasclinicas lobHCL003  = new VistaHclmaehistoriasclinicas("","","","","");
                    lobHCL003.Owner = tobOwner;
                    lobHCL003.ShowDialog();
                    break;

                case "HCL004":
                    // tipo de registrosde historia clinica
                    VistaHcltiporegactiv lobHCL004 = new VistaHcltiporegactiv();
                    lobHCL004.Owner = tobOwner;
                    lobHCL004.ShowDialog();
                    break;
					
                case "HCL005":
                    // Maestro Variables publicas
                    VistaHclvariabmaestro lobHCL005 = new VistaHclvariabmaestro();
                    lobHCL005.Owner = tobOwner;
                    lobHCL005.ShowDialog();
                    break;

                case "HCL006":
                    // Maestro grupos Variables publicas
                    VistaHclvariabgrupos lobHCL006 = new VistaHclvariabgrupos();
                    lobHCL006.Owner = tobOwner;
                    lobHCL006.ShowDialog();
                    break;

                case "HCL007":
                    // Gestion Recursos Imagens PDF Videos y otros
                    SolicitAddRecursos lobHCL007 = new SolicitAddRecursos("GES", "RIMG", "", "");
                    lobHCL007.Owner = tobOwner;
                    lobHCL007.ShowDialog();
                    break;

                case "HCL008":
                    // Formato por perfil
                    VistaFormatoPorPerfil lobHCL008 = new VistaFormatoPorPerfil();
                    lobHCL008.Owner = tobOwner;
                    lobHCL008.ShowDialog();
                    break;

                case "HCL009":
                    // Gestion Formatos
                    VistaHclgestionformat lobHCL009 = new VistaHclgestionformat();
                    lobHCL009.Owner = tobOwner;
                    lobHCL009.ShowDialog();
                    break;

            }
        }
    }
}
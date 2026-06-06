using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using Estadisticas.Vista;

namespace Estadisticas.Utilidades
{
    public static class ESTEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "EST001":
                    //- Generar  Planos Rips
                    FcmGenerarPlanosRips lobEST001 = new FcmGenerarPlanosRips();
                    lobEST001.Owner = tobOwner;
                    lobEST001.ShowDialog();
                    break;
             
                case "EST002":
                    //- Estadisitica Servicios Prestados
                    FcmEstadisiticaServicios lobEST002 = new FcmEstadisiticaServicios();
                    lobEST002.Owner = tobOwner;
                    lobEST002.ShowDialog();
                    break;
                    
                case "EST003":
                    //- Informes gestion de calidad
                    EstGestionCalidadInformes lobEST003 = new EstGestionCalidadInformes();
                    lobEST003.Owner = tobOwner;
                    lobEST003.ShowDialog();
                    break;
                    
                case "EST004":
                    //- Informes gestion de calidad
                    EstInformesHospitalizados lobEST004 = new EstInformesHospitalizados();
                    lobEST004.Owner = tobOwner;
                    lobEST004.ShowDialog();
                    break;

                case "EST005":
                    //- Informes parametros 2193
                    VistaEstParametros2193 lobEST005 = new VistaEstParametros2193();
                    lobEST005.Owner = tobOwner;
                    lobEST005.ShowDialog();
                    break;
                    
            }
        }
    }
}
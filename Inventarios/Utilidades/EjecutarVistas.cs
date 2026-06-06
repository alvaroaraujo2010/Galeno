using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using Inventarios.Vista;

namespace Inventarios.Utilidades
{
    public static class INVEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                    
                case "INV001":
                    // Maestro crear Almacen
                    VistaInvMaestroalmacen lobInv001 = new VistaInvMaestroalmacen();
                    lobInv001.Owner = tobOwner;
                    lobInv001.ShowDialog();
                    break;

                case "INV002":
                    // Gestion maestro de articulos
                    VistaInvmaestroarticulo lobInv002 = new VistaInvmaestroarticulo("");
                    lobInv002.Owner = tobOwner;
                    lobInv002.ShowDialog();
                    break;

                case "INV006":
                    // Entradas por compras
                    VistaEntradaCompras lobInv006 = new VistaEntradaCompras();
                    lobInv006.Owner = tobOwner;
                    lobInv006.ShowDialog();
                    break;

                case "INV007":
                    // Tipos de contenedores
                    VistaInvcontenedores lobInv007 = new VistaInvcontenedores();
                    lobInv007.Owner = tobOwner;
                    lobInv007.ShowDialog();
                    break;

                case "INV009":
                    // Personal Responsable
                    VistaInvperiodomaest lobInv009 = new VistaInvperiodomaest();
                    lobInv009.Owner = tobOwner;
                    lobInv009.ShowDialog();
                    break;


                case "INV010":
                    // Personal Responsable
                    VistaInvresponsables lobInv010 = new VistaInvresponsables();
                    lobInv010.Owner = tobOwner;
                    lobInv010.ShowDialog();
                    break;

                case "INV011":
                    // Concepto de ajuste inventario
                    VistaInvajusteconcep lobInv011 = new VistaInvajusteconcep();
                    lobInv011.Owner = tobOwner;
                    lobInv011.ShowDialog();
                    break;

                case "INV012":
                    // Suministro interno
                    VistaInvMovSuministro lobInv012 = new VistaInvMovSuministro();
                    lobInv012.Owner = tobOwner;
                    lobInv012.ShowDialog();
                    break;

                case "INV013":
                    // Ajuste inventario
                    VistaInvAjustInven lobInv013 = new VistaInvAjustInven();
                    lobInv013.Owner = tobOwner;
                    lobInv013.ShowDialog();
                    break;

                case "INV014":
                    // Vista almacen
                    VistaInvVistalmacen lobInv014 = new VistaInvVistalmacen();
                    lobInv014.Owner = tobOwner;
                    lobInv014.ShowDialog();
                    break;
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using FacturacionMedica.Vista;

namespace FacturacionMedica.Utilidades
{
    public static class FCMEjecutar
    {
        public static void fcvEjecutarFormularios(String tcrComponente, Window tobOwner)
        {
            switch (tcrComponente)
            {
                case "FCM001":
                    //- Ordenes de servicios medicos
                    VistaOrdenesmedicas lobFCM001 = new VistaOrdenesmedicas("", "", "", "", "");
                    lobFCM001.Owner = tobOwner;
                    lobFCM001.ShowDialog();
                    break;
             
                case "FCM002":
                    //- Manual de Servicios IPS
                    VistaFcmManualdeserviciosIPS lobFCM002 = new VistaFcmManualdeserviciosIPS();
                    lobFCM002.Owner = tobOwner;
                    lobFCM002.ShowDialog();
                    //VistaTransacpagoservicios lobFcmForm = new VistaTransacpagoservicios("AP00000006");
                    //lobFcmForm.ShowDialog();
                    break;
                    
                case "FCM003":
                    //- Manual tarifario venta de servicios 
                    VistaFcmManualServicios lobFCM003 = new VistaFcmManualServicios();
                    lobFCM003.Owner = tobOwner;
                    lobFCM003.ShowDialog();
                    break;


                case "FCM004":
                    //- Autorizacion para descuentos en facturacion
                    VistaAutorizarDescuento lobFCM004 = new VistaAutorizarDescuento();
                    lobFCM004.Owner = tobOwner;
                    lobFCM004.ShowDialog();
                    break;

                case "FCM005":
                    //- Centros de produccion
                    VistaFcmcenproduccio lobFCM005 = new VistaFcmcenproduccio();
                    lobFCM005.Owner = tobOwner;
                    lobFCM005.ShowDialog();
                    break;

                case "FCM006":
                    //- Cuentas de cobro
                    VistaCuentaCobro lobFCM006 = new VistaCuentaCobro("", "", "", "", "");
                    lobFCM006.Owner = tobOwner;
                    lobFCM006.ShowDialog();
                    break;

                case "FCM007":
                    //- Browser completar Rips
                    VistaBrowserRips lobFCM007 = new VistaBrowserRips();
                    lobFCM007.Owner = tobOwner;
                    lobFCM007.ShowDialog();
                    break;

                case "FCM008":
                    //- Browser Resolución Dian
                    VistaResolucionDian lobFCM008 = new VistaResolucionDian();
                    lobFCM008.Owner = tobOwner;
                    lobFCM008.ShowDialog();
                    break;

                case "FCM009":
                    //- Browser Listado SOAT
                    VistaFcmsoatmanualma lobFCM009 = new VistaFcmsoatmanualma();
                    lobFCM009.Owner = tobOwner;
                    lobFCM009.ShowDialog();
                    break;


            }
        }
    }
}
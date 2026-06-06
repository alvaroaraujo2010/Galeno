using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Printing;
using System.Data;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;
using static Sistema.Dian.Utilidades;

namespace Reportes.Utilidades
{
    /// <summary>
    /// <para>Imprimir registros para cuentas de cobro</para>
    /// </summary>
    public class FCMImprimir
    {
        //-------------------------------------------------
        // Variables de control general
        //-------------------------------------------------
        #region Variables de control general

        /// <summary>
        /// Parametro: "ID" = Buscar la razon social por coigo unico sistema "NIT"=Buscar Razon social por NIT
        /// </summary>
        public string gcrRazonSocialTipoId = "NA";
        /// <summary>
        /// Parametro: Codigo de la razon social a utilizar (codigo unico sistema / NIT)
        /// </summary>
        public string gcrRazonSocialCodigo = "NA";
        /// <summary>
        /// Parametro: Para imprimir solo la factura que esta activa en vista preliminar
        /// </summary>
        public string gcrNumeroFactura = "NA";
        /// <summary>
        /// Parametro: para forazar a imprimir la factura con el formato viejo antes de Factura electronica
        /// </summary>
        public string gcrFormatoFactura = "NA";

        public String gcrCodigoAdmision     = String.Empty;       
        public String gcrCodigoRegistro     = String.Empty;  // Codigo Codigo registro maestro cuando sea requerido
        public String gcrNumFacResolucion   = String.Empty;  // Numero de factura cuando esta relaionado en factrura global
        public String gcrTipoRegistro       = "CUENTA01";    // "CUENTA01" = Formato Cuenta de cobro 01
        public String gcrSeparadorDecimal   = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public bool glgVistaPrevia          = true;          // true = mostrar vista previa / fase = no mostrar vista previa
        public int gnuNumeroCopias          = 2; // Por defecto una sola copia
        public Window gobOwner;
        public DataSet01 gobDataSet         = new DataSet01();
        public string gcrTextoCodigoQr      = string.Empty;
        public ModeloFeRazonSocial loRegEmpresa;
        #endregion
        //-------------------------------------------------
        // fcvEjecutar: Ejecutar reportes
        //-------------------------------------------------
        #region Mostrar la vista del reoprte
        /// <summary>
        /// Mostrar la vista del reoprte
        /// </summary>
        public void fcvEjecutar()
        {

            fcvCargarEncabezados();
            // formatos de impresion cuentas de cobro
            if (gcrTipoRegistro == "CUENTA01")
            {
                fcvformatoCuentaCobro01();
            }
            else if (gcrTipoRegistro == "CUENTA02")
            {
                fcvformatoCuentaCobro02();
            }
            else if (gcrTipoRegistro == "CUENTA03")
            {
                fcvformatoCuentaCobro03();
            }
            else if (gcrTipoRegistro == "FACTURA")
            {
                fcvformatoFacturaServicios01();
            }
            else if (gcrTipoRegistro == "RECIBOCAJA")
            {
                fcvformatoReciboCaja01();
            }

        }
        #endregion
        // Foramtos Cuenta de cobro 
        #region fcvformatoCuentaCobro01 Lista de facturas usuarios y valores sencillo
        /// <summary>
        /// Cuenta de cobro formato 1 lista de facturas usuarios y valores sencillo
        /// </summary>
        public void fcvformatoCuentaCobro01()
        {
            #region Foramtos impresion cuenta de cobro
            //- Barra de Espera
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos para vista reporte...", "CENTRO");
            lobDlgAdd.Show();

            if (flgCargarTempDatosCuentaCobro())
            {
                VisorReportes lobVisorPm = new VisorReportes();
                var lcrFormato = Funciones.fcrLeerConfigVarSistema("FCM-PRNCUE-FORMATO-OPCION-01", "CUENTA01");

                if (lcrFormato == "CUENTA01")
                {
                    //- Cuenta de cobro formato 1 lista de facturas usuarios y valores sencillo
                    #region Foramtos impresion cuenta de cobro
                    FCM_CuentaCobro01 lobRepCuenta01 = new FCM_CuentaCobro01();
                    lobRepCuenta01.SetDataSource(gobDataSet);
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepCuenta01;
                    #endregion
                }
                else if (lcrFormato == "CUENTA01B")
                {
                    //- Cuenta de cobro formato 1 lista de facturas usuarios y valores con datos tercero contable
                    #region Foramtos impresion cuenta de cobro
                    FCM_CuentaCobro01B lobRepCuenta01 = new FCM_CuentaCobro01B();
                    lobRepCuenta01.SetDataSource(gobDataSet);
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepCuenta01;
                    #endregion
                }
                // Ejecutar el reporte
                lobDlgAdd.Close();
                lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                lobVisorPm.Owner = gobOwner;
                lobVisorPm.Activate();
                lobVisorPm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos");
            }
            // cerrar vista mensaje de espera
            if (lobDlgAdd != null) { lobDlgAdd.Close(); }
            #endregion
        }
        #endregion
        #region fcvformatoCuentaCobro02 Lista de usuarios Numero registro atencion
        /// <summary>
        /// Lista de usuarios Numero registro atencion (es una version del formato 1)
        /// </summary>
        public void fcvformatoCuentaCobro02()
        {
            #region Foramtos impresion cuenta de cobro
            //- Barra de Espera
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos para vista reporte...", "CENTRO");
            lobDlgAdd.Show();

            if (flgCargarTempDatosCuentaCobro())
            {
                VisorReportes lobVisorPm = new VisorReportes();
                var lcrFormato = Funciones.fcrLeerConfigVarSistema("FCM-PRNCUE-FORMATO-OPCION-02", "CUENTA02");

                if (lcrFormato == "CUENTA02")
                {
                    //- Cuenta de cobro formato 2 lista de usuarios Numero registro atencion (es una version del formato 1)
                    #region Foramtos impresion cuenta de cobro
                    FCM_CuentaCobro02 lobRepCuenta02 = new FCM_CuentaCobro02();
                    lobRepCuenta02.SetDataSource(gobDataSet);
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepCuenta02;
                    #endregion
                }
                else if (lcrFormato == "CUENTA02B")
                {
                    //- Cuenta de cobro formato 2 lista de usuarios Numero registro atencion (es una version del formato 1)
                    // Incluye datos del tercero contable
                    #region Foramtos impresion cuenta de cobro
                    FCM_CuentaCobro02B lobRepCuenta02 = new FCM_CuentaCobro02B();
                    lobRepCuenta02.SetDataSource(gobDataSet);
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepCuenta02;
                    #endregion
                }

                lobDlgAdd.Close();
                lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                lobVisorPm.Owner = gobOwner;
                lobVisorPm.Activate();
                lobVisorPm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos");
            }
            #endregion
            // cerrar vista mensaje de espera
            if (lobDlgAdd != null) { lobDlgAdd.Close(); }
        }
        #endregion
        #region fcvformatoCuentaCobro03 Relacion servicios facturados facturas en cuenta de cobro
        /// <summary>
        /// Relacion de servicios facturados para facturas en cuenta de cobro
        /// </summary>
        public void fcvformatoCuentaCobro03()
        {
            #region Foramtos impresion cuenta de cobro
            //- Barra de Espera
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos para vista reporte...", "CENTRO");
            lobDlgAdd.Show();

            if (flgCargarTempDatosCuentaCobro())
            {

                VisorReportes lobVisorPm = new VisorReportes();
                var lcrFormato = Funciones.fcrLeerConfigVarSistema("FCM-PRNCUE-FORMATO-OPCION-03", "CUENTA03");

                if (lcrFormato == "CUENTA03")
                {
                    //- Cuenta de cobro formato 3 Lista de usuarios y servicios facturados por factura (para cuenta de cobro Dian)
                    #region Foramtos impresion cuenta de cobro
                    FCM_CuentaCobro03 lobRepCuenta03 = new FCM_CuentaCobro03();
                    lobRepCuenta03.SetDataSource(gobDataSet);
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepCuenta03;
                    #endregion
                }
                else if (lcrFormato == "CUENTA03B")
                {
                    //- Cuenta de cobro formato 3 Lista de usuarios y servicios facturados por factura (para cuenta de cobro Dian)
                    // incluye datos del tercero contable
                    #region Foramtos impresion cuenta de cobro
                    FCM_CuentaCobro03B lobRepCuenta03 = new FCM_CuentaCobro03B();
                    lobRepCuenta03.SetDataSource(gobDataSet);
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepCuenta03;
                    #endregion
                }
                // Ejecutar el reporte
                lobDlgAdd.Close();
                lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                lobVisorPm.Owner = gobOwner;
                lobVisorPm.Activate();
                lobVisorPm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos");
            }
            #endregion
            // cerrar vista mensaje de espera
            if (lobDlgAdd != null) { lobDlgAdd.Close(); }
        }
        #endregion
        // Formato factura individual servicios
        #region fcvformatoFacturaServicios01 Lista de facturas usuarios y valores sencillo
        /// <summary>
        /// Factura individual de servicios medicos prestados a pacientes/Usuarios
        /// </summary>
        public void fcvformatoFacturaServicios01()
        {
            // Datos Admision
            //- Barra de Espera
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos para vista reporte...", "CENTRO");
            lobDlgAdd.Show();

            var lobAdm = REPUtilidades.fobDataSet01Admision(ref gobDataSet, gcrCodigoAdmision);
            gobDataSet.AdmAdmision.AddAdmAdmisionRow(lobAdm);

            #region Foramtos impresion factura
            if (fcvImprimirFactura())
            {
                //- Vista Reporte
                VisorReportes lobVisor = new VisorReportes();
                var lcrFormato = Funciones.fcrLeerConfigVarSistema("FCM-PRNFAC-FORMATO-FACT-SERV", "FACTURA01");
                // Forzar a usar un formato dado en parametros
                lcrFormato = gcrFormatoFactura != "NA" ? gcrFormatoFactura : lcrFormato;

                if (lcrFormato == "FACTURA01")
                {
                    FCM_PrnFacturas01 lobReporte = new FCM_PrnFacturas01();
                    lobReporte.SetDataSource(gobDataSet);
                    lobVisor.crpVisor.ViewerCore.ReportSource = lobReporte;
                }
                else if (lcrFormato == "FACTURA01B")
                {
                    FCM_PrnFacturas01B lobReporte = new FCM_PrnFacturas01B();
                    lobReporte.SetDataSource(gobDataSet);
                    lobVisor.crpVisor.ViewerCore.ReportSource = lobReporte;
                }
                else if (lcrFormato == "FACTURA01B1")
                {
                    FCM_PrnFacturas01B1 lobReporte = new FCM_PrnFacturas01B1();
                    lobReporte.SetDataSource(gobDataSet);
                    lobVisor.crpVisor.ViewerCore.ReportSource = lobReporte;
                }

                lobDlgAdd.Close(); 
                lobVisor.llgVistaPrevia = glgVistaPrevia;
                lobVisor.Owner = gobOwner;
                lobVisor.Activate();
                lobVisor.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos");
            }
            #endregion
            // cerrar vista mensaje de espera
            if (lobDlgAdd != null) { lobDlgAdd.Close(); }
        }
        #endregion       
        // Recibo de caja
        #region fcvformatoReciboCaja01 Recibo de Caja
        /// <summary>
        /// Cuenta de cobro formato 1 lista de facturas usuarios y valores sencillo
        /// </summary>
        public void fcvformatoReciboCaja01()
        {
            #region Formatos impresion recibo de caja
            //- Barra de Espera
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos para vista reporte...", "CENTRO");
            lobDlgAdd.Show();
            fcvCargarEncabezados();

            if (fcvImprimirReciboCaja())
            {
                //- Formato Recibo de caja 
                #region Foramtos impresion recibo de caja
                FCM_ImprimirReciboCaja lobRepReciboCaja01 = new FCM_ImprimirReciboCaja();
                lobRepReciboCaja01.SetDataSource(gobDataSet);

                // Ejecutar el reporte
                VisorReportes lobVisorPm = new VisorReportes();                
                lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepReciboCaja01;
                lobVisorPm.Owner = gobOwner;
                lobVisorPm.Activate();
                lobDlgAdd.Close();
                lobVisorPm.ShowDialog();
                #endregion
            }
            else
            {
                MessageBox.Show("No hay datos");
            }
            //// cerrar vista mensaje de espera
            //if (lobDlgAdd != null) { lobDlgAdd.Close(); }
            #endregion
        }
        #endregion
        // Cargar encabezado de reportes    
        #region fcvCargarEncabezados Cargar datos encabezado reporte y admision
        /// <summary>
        /// Cargar datos encabezado reporte y admision
        /// </summary>
        public void fcvCargarEncabezados()
        {
            // Encabezados 
            DataSet01.SisEncabezadoRow lobEncab;
            if (gcrRazonSocialTipoId != "NA")
            {
                lobEncab = REPUtilidades.FobDataSet01EncabezadoEx(gcrRazonSocialTipoId, gcrRazonSocialCodigo, ref gobDataSet);
            }
            else
            {
                lobEncab = REPUtilidades.fobDataSet01Encabezado(ref gobDataSet);
            }

            gobDataSet.SisEncabezado.AddSisEncabezadoRow(lobEncab);
        }
        #endregion
        //-------------------------------------------------
        // flgCargarTempDatosCuentaCobro: Cargar Datos cuenta de cobro
        //-------------------------------------------------
        #region flgCargarTempDatosCuentaCobro: Cargar Datos cuenta de cobro
        /// <summary>
        /// <para>Cargar Datos cuenta de cobro</para>
        /// </summary>
        private bool flgCargarTempDatosCuentaCobro()
        {
            var llgReturn = false;

            Aplicacion oApp = Aplicacion.Instancia();
            // Definir temporales para los datos 
            List<ModeloCuentaCobro> lobTempMaestro = null;
            List<ModeloDetallfacturas> lobTempDetalles = null;

            //gobDataSet = new DataSet01();
            DataSet01.FcmcuentacobrmsDataTable lobMaestro  = gobDataSet.Fcmcuentacobrms;
            DataSet01.FcmFacturasMaDataTable lobDetalles   = gobDataSet.FcmFacturasMa;
            DataSet01.FcmFacturasDeDataTable lobDetallSer  = gobDataSet.FcmFacturasDe;

            //----------------------------------------------------------
            // Maestro cuentas de cobro
            //----------------------------------------------------------
            #region Maestro cuentas de cobro
            DataSet01.FcmcuentacobrmsRow lobRegistroMa = lobMaestro.NewFcmcuentacobrmsRow();
            lobTempMaestro = ModeloCuentaCobro.flsListaFcmcuentacobrms(gcrCodigoRegistro);
            //-----------------------------------------------------------------
            // traer firma responsable para imprimir en factura
            //-----------------------------------------------------------------
            #region firmas
            var llgImagenFirma = false;
            var lcrNombreFirma = "NA";

            var tmp = SYSValidarCodigo.fobRegBuscarSysvarconfigmdKey("FCM-PRNCUE-NOMBRE-FIRMA-RESPONS");
            if (tmp != null)
            {
                lcrNombreFirma = tmp.sys_vardfl_sycv.Trim();
            }
            var tmp1 = SYSValidarCodigo.fobRegBuscarSysvarconfigmdKey("FCM-PRNCUE-IMG-FIRMA-RESPONSABLE");
            if (tmp1 != null)
            {
                llgImagenFirma = tmp1.sys_vardfl_sycv.Trim() != "NA" ? true : false;
            }
            #endregion

            foreach (var lobReg in lobTempMaestro)
            {
                llgReturn = true;
                lobRegistroMa = lobMaestro.NewFcmcuentacobrmsRow();
                #region Maestro
                //lobRegistroMa.Hcl_titulo_reporte = tcrTitulo;
                lobRegistroMa.Fcm_secreg_mfcb = lobReg.Fcm_secreg_mfcb;
                lobRegistroMa.Fcm_numfac_mfac = String.IsNullOrWhiteSpace(gcrNumFacResolucion) ? lobReg.Fcm_numfac_mfac : gcrNumFacResolucion;
                lobRegistroMa.Fcm_fecfac_mfac = Funciones.fcrConvertFecha(lobReg.Fcm_fecfac_mfac);
                lobRegistroMa.Sia_fecini_mfcb = Funciones.fcrConvertFecha(lobReg.Sia_fecini_mfcb);
                lobRegistroMa.Sia_fecfin_mfcb = Funciones.fcrConvertFecha(lobReg.Sia_fecfin_mfcb);
                lobRegistroMa.Fcm_descue_mfcb = lobReg.Fcm_descue_mfcb;
                lobRegistroMa.Fcm_notcue_mfcb = lobReg.Fcm_notcue_mfcb;
                lobRegistroMa.Fcm_firmar_mfcb = lobReg.Fcm_firmar_mfcb;
                lobRegistroMa.Cto_seccon_cont = lobReg.Cto_seccon_cont;
                lobRegistroMa.Cto_nrocon_cont = lobReg.Cto_nrocon_cont;
                lobRegistroMa.Sia_codeps_teps = lobReg.Sia_codeps_teps;
                lobRegistroMa.Fcm_valbru_dfac = lobReg.Fcm_valbru_dfac;
                lobRegistroMa.Fcm_pordes_dfac = lobReg.Fcm_pordes_dfac;
                lobRegistroMa.Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac;
                lobRegistroMa.Fcm_poriva_dfac = lobReg.Fcm_poriva_dfac;
                lobRegistroMa.Fcm_valiva_dfac = lobReg.Fcm_valiva_dfac;
                lobRegistroMa.Fcm_valcpa_dfac = lobReg.Fcm_valcpa_dfac <= 0 ? lobReg.Fcm_valcmo_dfac : lobReg.Fcm_valcpa_dfac;
                lobRegistroMa.Fcm_valusu_dfac = lobReg.Fcm_valusu_dfac;
                lobRegistroMa.Fcm_valsub_dfac = lobReg.Fcm_valsub_dfac;
                lobRegistroMa.Fcm_valfac_dfac = lobReg.Fcm_valfac_dfac;
                lobRegistroMa.Cto_descon_cont = lobReg.Cto_descon_cont;
                lobRegistroMa.Sia_deseps_teps = lobReg.Sia_deseps_teps;
                lobRegistroMa.Sia_codnit_teps = lobReg.Sia_codnit_teps;
                lobRegistroMa.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                // Datos Resolucion Facturacion
                lobRegistroMa.Fcm_numres_srfa = lobReg.Fcm_numres_srfa;
                lobRegistroMa.Fcm_desres_srfa = lobReg.Fcm_desres_srfa;
                lobRegistroMa.Fcm_notenc_srfa = lobReg.Fcm_notenc_srfa;
                lobRegistroMa.Fcm_noppag_srfa = lobReg.Fcm_noppag_srfa;
                // Datos Tercero contable
                lobRegistroMa.Sis_razsoc_sitr = lobReg.Sis_razsoc_sitr;
                lobRegistroMa.Sis_tipide_tido = lobReg.Sis_tipide_tido;
                lobRegistroMa.Sis_numide_sitr = lobReg.Sis_numide_sitr;
                lobRegistroMa.Sis_telefo_sitr = lobReg.Sis_telefo_sitr;
                lobRegistroMa.Sis_direcc_sitr = lobReg.Sis_direcc_sitr;
                lobRegistroMa.Sis_valor_letra = Funciones.fcrConvertirNumeroALetras(lobReg.Fcm_valfac_dfac.ToString(), "PESOS");
                /*
                 *  SE INACTIVA POR EL MOMENTO, NO ESTA COMPLETO: Sys_nomusu_usux
                 * 
                lobRegistroMa.Sys_nomusu_usux = SYSValidarCodigo.fcrDEBuscarSysusuarios(lobReg.Sys_codusu_usux);
                // Cargar nombre y firma para mostrar en factura
                lobRegistroMa.Fcm_nombre_firma1 = lcrNombreFirma == "NA" ? lobRegistroMa.Sys_nomusu_usux : lcrNombreFirma;
                if (llgImagenFirma == true && lcrNombreFirma != "NA")
                {
                    lobRegistroMa.Fcm_objeto_imagen1 = REPUtilidades.fobCargarImagenes(tmp1.sys_vardfl_sycv.Trim(), tmp1.sys_varaux_sycv.Trim());
                }
                */
                #endregion
                // Add en temporal
                gobDataSet.Fcmcuentacobrms.AddFcmcuentacobrmsRow(lobRegistroMa);
            }
            #endregion
            //----------------------------------------------------------
            // Detalles cuentas cobro - facturas 
            //----------------------------------------------------------
            #region Detalles cuentas cobro - facturas
            DataSet01.FcmFacturasMaRow lobRegistro = lobDetalles.NewFcmFacturasMaRow();
            lobTempDetalles = ModeloDetallfacturas.flsListaFcmcuentacobrde(gcrCodigoRegistro);
            llgReturn = false;
            #region Maestro facturas
            foreach (var lobReg in lobTempDetalles)
            {
                llgReturn = true;
                lobRegistro = lobDetalles.NewFcmFacturasMaRow();
                #region Detalles
                lobRegistro.Adm_secadm_rgad = lobReg.Adm_secadm_rgad;
                lobRegistro.Fcm_numfac_mfac = lobReg.Fcm_numfac_mfac;
                lobRegistro.Fcm_fecfac_mfac = Funciones.fcrConvertFecha(lobReg.Fcm_fecfac_mfac);
                lobRegistro.Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac;
                lobRegistro.Fcm_valiva_dfac = lobReg.Fcm_valiva_dfac;
                lobRegistro.Fcm_valcpa_dfac = lobReg.Fcm_valcpa_dfac <= 0 ? lobReg.Fcm_valcmo_dfac : lobReg.Fcm_valcpa_dfac;
                lobRegistro.Fcm_valcmo_dfac = lobReg.Fcm_valcmo_dfac;
                lobRegistro.Fcm_valusu_dfac = lobReg.Fcm_valusu_dfac;
                lobRegistro.Fcm_valsub_dfac = lobReg.Fcm_valsub_dfac;
                lobRegistro.Fcm_valfac_dfac = lobReg.Fcm_valfac_dfac;
                lobRegistro.Sia_tipide_tide = lobReg.Sia_tipide_tide;
                lobRegistro.Sia_nroide_usua = lobReg.Sia_nroide_usua;
                lobRegistro.Sia_nomusu_usua = lobReg.Sia_nomusu_usua;
                lobRegistro.Sys_nomusu_usux = oApp.gcrUsuNombreUsuario;
                //lobRegistro.Sis_valor_letra = Funciones.fcrConvertirNumeroALetras(lobReg.Fcm_valfac_dfac.ToString(), "PESOS");
                gobDataSet.FcmFacturasMa.AddFcmFacturasMaRow(lobRegistro);
                #endregion
            }
            #endregion
            #endregion
            //----------------------------------------------------------
            // Detalles servicios en facturas 
            //----------------------------------------------------------
            if (gcrTipoRegistro == "CUENTA03")
            {
                // Detalles gobObjVModelo.TmpG2ListaBrow
                #region Detalles facturas
                DataSet01.FcmFacturasDeRow lobRegServ = lobDetallSer.NewFcmFacturasDeRow();
                var lobTempDetallSrv = fobTempServiciosFacturas(gcrCodigoRegistro);
                if (lobTempDetallSrv != null)
                {
                    foreach (DataRow lobReg in lobTempDetallSrv.Rows)
                    {
                        llgReturn = true;
                        lobRegServ = lobDetallSer.NewFcmFacturasDeRow();

                        var lnuCopago = Convert.ToInt32(lobReg["fcm_valcpa_dfac"].ToString());
                        var lnuCModer = Convert.ToInt32(lobReg["fcm_valcmo_dfac"].ToString());

                        #region detalles facturas
                        lobRegServ.Fcm_numfac_mfac = lobReg["fcm_numfac_mfac"].ToString();
                        lobRegServ.Fcm_codser_mant = lobReg["Fcm_codser_mant"].ToString();
                        lobRegServ.Fcm_desser_dfac = lobReg["Fcm_desser_dfac"].ToString();
                        lobRegServ.Fcm_totuni_dfac = Convert.ToInt32(lobReg["fcm_totuni_dfac"].ToString());
                        lobRegServ.Fcm_valser_mant = Convert.ToInt32(lobReg["fcm_valser_mant"].ToString());
                        lobRegServ.Fcm_valcpa_dfac = lnuCopago > 0 ? lnuCopago : lnuCModer;
                        lobRegServ.Fcm_valfac_dfac = Convert.ToInt32(lobReg["fcm_valfac_dfac"].ToString());
                        #endregion
                        // Add en temporal
                        gobDataSet.FcmFacturasDe.AddFcmFacturasDeRow(lobRegServ);
                    }
                }
                #endregion

            }
            return llgReturn;
        }
        #endregion
        // Servicios en facturas para lista relacion cuenta cobro
        #region fobTempServiciosFacturas: Servicios en facturas
        /// <summary>
        /// <para>Generar Lista de servicios prestados por cada factura para una cuenta de cobro</para>
        /// <para>PARAMETRO</para>
        /// <para>tcrCodigoCuentaCobro: Codigo cuenta de cobro para realizar filtro</para>
        /// </summary>
        public DataTable fobTempServiciosFacturas(String tcrCodigoCuentaCobro)
        {
            DataTable lobjDatosTabla = new DataTable();
            #region Linea SQl para ejecutar
            var lcrLineaSqlSelct = "SELECT fcmcuentacobrde.fcm_numfac_mfac," +
                                            "fcmmaedetallfac.fcm_fecfac_mfac," +
                                            "fcmmaedetallfac.fcm_codser_mant," +
                                            "fcmmaedetallfac.fcm_desser_dfac," +
                                            "fcmmaedetallfac.fcm_totuni_dfac," +
                                            "fcmmaedetallfac.fcm_valser_mant," +
                                            "fcmmaedetallfac.fcm_valcpa_dfac," +
                                            "fcmmaedetallfac.fcm_valcmo_dfac," +
                                            "fcmmaedetallfac.fcm_valfac_dfac " +
                                    "FROM fcmmaedetallfac " +
                                          "INNER JOIN fcmcuentacobrde ON (fcmmaedetallfac.fcm_numfac_mfac = fcmcuentacobrde.fcm_numfac_mfac) " +
                                    "WHERE (fcmcuentacobrde.fcm_secreg_mfcb = '" + tcrCodigoCuentaCobro + "') " +
                                            "ORDER BY fcmmaedetallfac.fcm_fecfac_mfac,fcmcuentacobrde.fcm_numfac_mfac";
            #endregion
            lobjDatosTabla = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);
            return lobjDatosTabla;
        }
        #endregion
        //-------------------------------------------------
        // Imprimir factura 
        //-------------------------------------------------
        #region fcvImprimirFactura Imprimir factura
        /// <summary>
        /// Mostrar vista previa del reporte factura
        /// </summary>
        private bool fcvImprimirFactura()
        {
            var llgReturn = false;
            var lcrImagenFirma = "";
            var lcrNombreFirma = "NA";
            var lcrNotaCargo = "NA";

            // Definir temporales para los datos 
            DataSet01.FcmFacturasMaDataTable lobFacturas = gobDataSet.FcmFacturasMa;
            DataSet01.FcmFacturasDeDataTable lobDetalles = gobDataSet.FcmFacturasDe;

            // Maestro facturas gobObjVModelo.TmpG1ListaBrow
            #region Maestro facturas
            DataSet01.FcmFacturasMaRow lobRegistroMa = lobFacturas.NewFcmFacturasMaRow();
            //-----------------------------------------------------------------
            // consultar las facturas

            var lobTempFacturas = FcmModeloMaestrofacturas.flsListaFcmmaesfacturas(gcrCodigoAdmision, "1*2*3");

            // aplicar el filtro factura 
            if (gcrNumeroFactura != "NA")
            {
                lobTempFacturas = lobTempFacturas.Where(x => x.Fcm_numfac_mfac == gcrNumeroFactura).ToList();
                //lobTempFacturas = lobTempFacturas.ForEach(x => x.Fcm_numfac_mfac == gcrNumeroFactura);
            }

            //-----------------------------------------------------------------
            // traer firma responsable para imprimir en factura
            //-----------------------------------------------------------------
            #region firmas
            if (lobTempFacturas != null)
            {
                var lobRegEmp = lobTempFacturas.FirstOrDefault();
                if (lobRegEmp.lobRegDocDian != null)
                {
                    loRegEmpresa = lobRegEmp.lobRegDocDian.lobRegEmpresa ?? null;
                }
            }
            #region firmas
            if (loRegEmpresa != null)
            {
                lcrImagenFirma  = loRegEmpresa.Fcm_ctoimg_fcem;
                lcrNombreFirma  = loRegEmpresa.Fcm_ctonom_fcem;
                lcrNotaCargo    = loRegEmpresa.Fcm_ctondo_fcem;
            }
            #endregion
            #endregion
            //-----------------------------------------------------------------
            // DATOS
            //-----------------------------------------------------------------
            foreach (var lobReg in lobTempFacturas)
            {
                // Generar el codigo QR
                gcrTextoCodigoQr = string.Empty;
                if (lobReg.lobRegDocDian != null)
                {
                    FcrGenerarCodigoQR(lobReg.lobRegDocDian, lobReg.lobRegDocDian.Fcm_idcufe_mfac, out gcrTextoCodigoQr);
                }

                llgReturn = true;
                lobRegistroMa = lobFacturas.NewFcmFacturasMaRow();
                #region Maestro facturas
                lobRegistroMa.Cto_nrocon_cont = lobReg.Cto_nrocon_cont;
                lobRegistroMa.Cto_descon_cont = lobReg.Cto_descon_cont;
                lobRegistroMa.Sia_codeps_teps = lobReg.Sia_codeps_teps;
                lobRegistroMa.Sia_deseps_teps = lobReg.Sia_deseps_teps;
                lobRegistroMa.Sia_codnit_teps = lobReg.Sia_codnit_teps;
                lobRegistroMa.Fcm_numfac_mfac = String.IsNullOrWhiteSpace(lobReg.Fcm_numfac_mfac) ? lobReg.Fcm_secreg_mfac : lobReg.Fcm_numfac_mfac;
                lobRegistroMa.Fcm_fecfac_mfac = Funciones.fcrConvertFecha(lobReg.Fcm_fecfac_mfac);
                lobRegistroMa.Fcm_fecven_mfac = Funciones.fcrConvertFecha(lobReg.Fcm_fecven_mfac);
                lobRegistroMa.Fcm_idcufe_mfac = lobReg.lobRegDocDian != null ? lobReg.lobRegDocDian.Fcm_idcufe_mfac : "NA";
                lobRegistroMa.Fcm_metpag_mfac = lobReg.Fcm_metpag_mfac == "1" ? "CONTADO" : "CREDITO";
                lobRegistroMa.Fcm_valbru_dfac = lobReg.Fcm_valbru_dfac;
                lobRegistroMa.Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac;
                lobRegistroMa.Fcm_valiva_dfac = lobReg.Fcm_valiva_dfac;
                lobRegistroMa.Fcm_valcpa_dfac = lobReg.Fcm_valcpa_dfac <= 0 ? lobReg.Fcm_valcmo_dfac : lobReg.Fcm_valcpa_dfac;
                lobRegistroMa.Fcm_valcmo_dfac = lobReg.Fcm_valcmo_dfac;
                lobRegistroMa.Fcm_valusu_dfac = lobReg.Fcm_valusu_dfac;
                lobRegistroMa.Fcm_valcom_dfac = lobReg.Fcm_valcom_dfac;
                lobRegistroMa.Fcm_valsub_dfac = lobReg.Fcm_valsub_dfac;
                lobRegistroMa.Fcm_valfac_dfac = lobReg.Fcm_valfac_dfac;
                lobRegistroMa.Fcm_valref_dfac = lobReg.Fcm_valref_dfac;
                lobRegistroMa.Fcm_valefe_dfac = lobReg.Fcm_valefe_dfac;
                lobRegistroMa.Fcm_numres_srfa = lobReg.Fcm_numres_srfa;
                lobRegistroMa.Fcm_desres_srfa = lobReg.Fcm_desres_srfa;
                lobRegistroMa.Fcm_notenc_srfa = lobReg.Fcm_notenc_srfa;
                lobRegistroMa.Fcm_noppag_srfa = lobReg.Fcm_noppag_srfa;
                // Datos Tercero contable
                lobRegistroMa.Sis_razsoc_sitr = lobReg.Sis_razsoc_sitr;
                lobRegistroMa.Sis_tipide_tido = lobReg.Sis_tipide_tido;
                lobRegistroMa.Sis_numide_sitr = lobReg.Sis_numide_sitr;
                lobRegistroMa.Sis_telefo_sitr = lobReg.Sis_telefo_sitr;
                lobRegistroMa.Sis_direcc_sitr = lobReg.Sis_direcc_sitr;
                // Otros datos
                lobRegistroMa.Sis_despro_espr = String.IsNullOrWhiteSpace(lobReg.Fcm_desfac_mfac) ? "ABIERTA" : lobReg.Fcm_desfac_mfac;
                lobRegistroMa.Sys_nomusu_usux = SYSValidarCodigo.fcrDEBuscarSysusuarios(lobReg.Sys_codusu_usux);
                lobRegistroMa.Sis_valor_letra = Funciones.fcrConvertirNumeroALetras(lobReg.Fcm_valfac_dfac.ToString(), "PESOS");
                // Cargar nombre y firma para mostrar en factura
                lobRegistroMa.Fcm_nombre_firma1 = lcrNombreFirma == "NA" ? lobRegistroMa.Sys_nomusu_usux : lcrNombreFirma;
                lobRegistroMa.Fcm_titulo_imagen1 = lcrNotaCargo == "NA" ? "" : lcrNotaCargo;
                lobRegistroMa.Fcm_codigoqr_texto = !string.IsNullOrEmpty(gcrTextoCodigoQr) ? "OK" : "NA";

                // Imagen firma por el momento no
                if (lcrImagenFirma != null)
                {
                    if (lcrImagenFirma != "NA")
                    {
                        lobRegistroMa.Fcm_objeto_imagen1 = REPUtilidades.FobCargarImagenes(lcrImagenFirma, @"\Imagenes\General\Sistemas");
                    }
                }

                // Imagen codigo QR
                if (string.IsNullOrEmpty(gcrTextoCodigoQr) == false)
                {
                    lobRegistroMa.Fcm_objeto_imagen2 = Funciones.FobCodigoQrBitmapArray(gcrTextoCodigoQr, 250);
                }

                /*
                if (llgImagenFirma == true && lcrNombreFirma != "NA")
                {
                    lobRegistroMa.Fcm_objeto_imagen1 = REPUtilidades.FobCargarImagenes(tmp1.sys_vardfl_sycv.Trim(), tmp1.sys_varaux_sycv.Trim());
                }
                */
                #endregion
                // Add en temporal
                gobDataSet.FcmFacturasMa.AddFcmFacturasMaRow(lobRegistroMa);
            }
            #endregion
            // Detalles gobObjVModelo.TmpG2ListaBrow
            #region Detalles facturas
            DataSet01.FcmFacturasDeRow lobRegistro = lobDetalles.NewFcmFacturasDeRow();
            var lobTempDetalles = FcmModeloServDetallFacturas.flsListaFcmmaedetallfac(gcrCodigoAdmision);

            foreach (var lobReg in lobTempDetalles)
            {
                llgReturn = true;

                lobRegistro = lobDetalles.NewFcmFacturasDeRow();

                var lcrFcm_codser_mant = lobReg.Sia_codrip_trip.Trim() != "12" && 
                                         lobReg.Sia_codrip_trip.Trim() != "13" ? 
                                         lobReg.Fcm_codser_mant : lobReg.Far_codcum_famd;

                #region detalles facturas
                lobRegistro.Sia_codrip_trip = lobReg.Sia_codrip_trip;
                lobRegistro.Sia_desrip_trip = lobReg.Sia_desrip_trip;
                lobRegistro.Fcm_codser_mant = lcrFcm_codser_mant;
                lobRegistro.Fcm_desser_dfac = lobReg.Fcm_desser_dfac;
                lobRegistro.Fcm_numfac_mfac = String.IsNullOrWhiteSpace(lobReg.Fcm_numfac_mfac) ? lobReg.Fcm_secreg_mfac : lobReg.Fcm_numfac_mfac;
                lobRegistro.Fcm_totuni_dfac = lobReg.Fcm_totuni_dfac;
                lobRegistro.Fcm_valser_mant = lobReg.Fcm_valser_mant;
                lobRegistro.Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac;
                lobRegistro.Fcm_valiva_dfac = lobReg.Fcm_valiva_dfac;
                lobRegistro.Fcm_valcpa_dfac = lobReg.Fcm_valcpa_dfac <= 0 ? lobReg.Fcm_valcmo_dfac : lobReg.Fcm_valcpa_dfac;
                lobRegistro.Fcm_valcmo_dfac = lobReg.Fcm_valcmo_dfac;
                lobRegistro.Fcm_valusu_dfac = lobReg.Fcm_valusu_dfac;
                lobRegistro.Fcm_valcom_dfac = lobReg.Fcm_valcom_dfac;
                lobRegistro.Fcm_valsub_dfac = lobReg.Fcm_valsub_dfac;
                lobRegistro.Fcm_valfac_dfac = lobReg.Fcm_valfac_dfac;
                lobRegistro.Fcm_valref_dfac = lobReg.Fcm_valref_dfac;
                lobRegistro.Fcm_valefe_dfac = lobReg.Fcm_valefe_dfac;
                #endregion
                // Add en temporal
                gobDataSet.FcmFacturasDe.AddFcmFacturasDeRow(lobRegistro);
            }
            #endregion
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Imprimir recibo de caja
        //-------------------------------------------------
        #region fcvImprimirReciboCaja Imprimir recibo de caja
        /// <summary>
        /// Mostrar vista previa del reporte recibo de caja
        /// </summary>
        private bool fcvImprimirReciboCaja()
        {
            var llgReturn = false;

             // Definir temporales para los datos 
            List<FcmModeloTransacPagoEfectivo> lobTempReciboCaja = null;
            List<FcmModeloTransPagoDetalles> lobTempDetalles = null;
          
            // Definir temporales para los datos 
            DataSet01.FcmmaescajatranDataTable lobReciboCaj = gobDataSet.Fcmmaescajatran;
            DataSet01.FcmmaescajadetaDataTable lobDetalles = gobDataSet.Fcmmaescajadeta;

            // Maestro Recibo de caja
            #region Maestro recibo de caja
            DataSet01.FcmmaescajatranRow lobReciboMa = lobReciboCaj.NewFcmmaescajatranRow();
            lobTempReciboCaja = FcmModeloTransacPagoEfectivo.flsListaFcmmaescajatranRpt(gcrCodigoAdmision);              

            var i = 0;
            for (i = 1; i <= gnuNumeroCopias; i++)
            {
                foreach (var lobReg in lobTempReciboCaja)
                {
                    llgReturn = true;
                    lobReciboMa = lobReciboCaj.NewFcmmaescajatranRow();

                    #region Maestro facturas
                    lobReciboMa.Fcm_num_copia = i;

                    lobReciboMa.Fcm_codtra_mtrc = lobReg.Fcm_codtra_mtrc;
                    lobReciboMa.Adm_secadm_rgad = lobReg.Adm_secadm_rgad;
                    lobReciboMa.Sia_idesec_usua = lobReg.Sia_idesec_usua;
                    lobReciboMa.Sia_nroide_usua = lobReg.Sia_nroide_usua;
                    lobReciboMa.Fcm_autdes_ades = lobReg.Fcm_autdes_ades;
                    lobReciboMa.Fcm_descon_mtrc = lobReg.Fcm_descon_mtrc;
                    lobReciboMa.Fcm_rfecha_mtrc = lobReg.Fcm_rfecha_mtrc.ToShortDateString();
                    lobReciboMa.Fcm_rehora_mtrc = Funciones.fcrConvierteHora(lobReg.Fcm_rehora_mtrc.ToString(), "24", gcrSeparadorDecimal, ":"); 
                    lobReciboMa.Fcm_tipefe_mtrc = lobReg.Fcm_tipefe_mtrc;
                    lobReciboMa.Fcm_valref_dfac = lobReg.Fcm_valref_dfac;
                    lobReciboMa.Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac;
                    lobReciboMa.Fcm_valefe_mtrc = lobReg.Fcm_valefe_mtrc;
                    lobReciboMa.Fcm_valcam_mtrc = lobReg.Fcm_valcam_mtrc;
                    lobReciboMa.Fcm_valefe_dfac = lobReg.Fcm_valefe_dfac;
                    lobReciboMa.Sia_codcat_ceat = lobReg.Sia_codcat_ceat;
                    lobReciboMa.Fcm_secdet_mtrc = lobReg.Fcm_secdet_mtrc;
                    lobReciboMa.Sys_codusu_usux = lobReg.Sys_codusu_usux;
                    lobReciboMa.Sis_estreg_mtrc = lobReg.Sis_estreg_mtrc;
                    lobReciboMa.Sia_nomusu_usua = lobReg.Sia_nomusu_usua;
                    lobReciboMa.Sys_nomusu_usux = lobReg.Sys_nomusu_usux;
                    lobReciboMa.Sis_valor_letra = Funciones.fcrConvertirNumeroALetras(lobReg.Fcm_valefe_dfac.ToString(), "PESOS");

                    #endregion
                    // Add en temporal
                    gobDataSet.Fcmmaescajatran.AddFcmmaescajatranRow(lobReciboMa);
                }
            }
            #endregion
            // Detalles Recibo de caja
            #region Detalles recibo de caja
            DataSet01.FcmmaescajadetaRow lobReciboMd = lobDetalles.NewFcmmaescajadetaRow();
            lobTempDetalles = FcmModeloTransPagoDetalles.flsListaFcmmaescajadetaRpt(gcrCodigoAdmision);
            llgReturn = false;

            //for (i = 1; i <= gnuNumeroCopias; i++)
            //{
                foreach (var lobReg in lobTempDetalles)
                {
                    llgReturn = true;

                    lobReciboMd = lobDetalles.NewFcmmaescajadetaRow();

                    #region Detalles recibo de caja

                    lobReciboMd.Fcm_num_copia = i;
                   
                    lobReciboMd.Fcm_codrca_rcad = lobReg.Fcm_codrca_rcad;
                    lobReciboMd.Fcm_codtra_mtrc = lobReg.Fcm_codtra_mtrc;
                    lobReciboMd.Fcm_secreg_mfac = lobReg.Fcm_secreg_mfac;
                    lobReciboMd.Adm_secadm_rgad = lobReg.Adm_secadm_rgad;
                    lobReciboMd.Fcm_numfac_mfac = String.IsNullOrWhiteSpace(lobReg.Fcm_numfac_mfac) ? lobReg.Fcm_secreg_mfac : lobReg.Fcm_numfac_mfac;
                    lobReciboMd.Fcm_desser_sips = lobReg.Fcm_desser_sips;
                    lobReciboMd.Fcm_valref_dfac = lobReg.Fcm_valref_dfac;
                    lobReciboMd.Fcm_pordes_dfac = lobReg.Fcm_pordes_dfac;
                    lobReciboMd.Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac;
                    lobReciboMd.Fcm_valefe_dfac = lobReg.Fcm_valefe_dfac;
                    lobReciboMd.Fcm_tippag_rcad = lobReg.Fcm_tippag_rcad;
                    lobReciboMd.Sis_idterc_sitr = lobReg.Sis_idterc_sitr;
                    lobReciboMd.Fcm_estreg_rcad = lobReg.Fcm_estreg_rcad;
                    lobReciboMd.Fcm_descon_mtrc = lobReg.Fcm_descon_mtrc;
                    #endregion

                    // Add en temporal
                    gobDataSet.Fcmmaescajadeta.AddFcmmaescajadetaRow(lobReciboMd);
                }
            //}
            #endregion
            return llgReturn;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Windows;
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
    /// <para>Imprimir Cuenta de cobro Factura Dian</para>
    /// </summary>
    public class CARImprimirFactura
    {
        //-------------------------------------------------
        // Variables de control general
        //-------------------------------------------------
        #region Variables de control general
        /// <summary>
        /// Parametro: "ID" = Buscar la razon social por coigo unico sistema "NIT"=Buscar Razon social por NIT
        /// </summary>
        public string gcrRazonSocialTipoId = string.Empty;
        /// <summary>
        /// Parametro: Codigo de la razon social a utilizar (codigo unico sistema / NIT)
        /// </summary>
        public string gcrRazonSocialCodigo = string.Empty;

        // Resto de parametros
        public string gcrCodigoAdmision   = string.Empty;
        public string gcrCodigoRegistro   = string.Empty;  // Codigo Codigo registro maestro cuando sea requerido
        public string gcrTipoRegistro     = "GENERAL";    // "GENERAL" = Cuenta de Cobro Factura Dian
        public string gcrTextoCodigoQr    = string.Empty;
        public string gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public bool glgVistaPrevia        = true;          // true = mostrar vista previa / fase = no mostrar vista previa
        public Window gobOwner;
        public DataSet01 gobDataSet       = new DataSet01();
        public ModeloFeRazonSocial loRegEmpresa;
        #endregion
        //-------------------------------------------------
        // fcvEjecutar: Ejecutar reportes
        //-------------------------------------------------
        #region Mostrar la vista del reporte
        /// <summary>
        /// Mostrar la vista del reoprte
        /// </summary>
        public void FcvEjecutar()
        {
            //- Barra de Espera
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos para vista reporte...", "CENTRO");
            lobDlgAdd.Show();

            FcvCargarEncabezados();
            // Factura Cuenta de Cobro Factura Dian
            if (gcrTipoRegistro == "GENERAL")
            {
                #region Cuenta de Cobro Factura Dian
                if (flgCargarTempDatosFacturaDian())
                {
                    //- Factura Dian
                    CAR_FacturaDian lobRepFactura01 = new CAR_FacturaDian();
                    lobRepFactura01.SetDataSource(gobDataSet);

                    VisorReportes lobVisorPm = new VisorReportes();
                    lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                    lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepFactura01;
                    lobVisorPm.Owner = gobOwner;
                    lobVisorPm.Activate();
                    lobDlgAdd.Close();
                    lobVisorPm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay datos");
                }
                #endregion
            }
        }
        #region fcvCargarEncabezados Cargar datos encabezado reporte y admision
        /// <summary>
        /// Cargar datos encabezado reporte y admision
        /// </summary>
        public void FcvCargarEncabezados()
        {
            // Encabezados 
            var lobEncab = REPUtilidades.FobDataSet01EncabezadoEx(gcrRazonSocialTipoId, gcrRazonSocialCodigo, ref gobDataSet);
            gobDataSet.SisEncabezado.AddSisEncabezadoRow(lobEncab);
        }
        #endregion
        // flgCargarTempDatosFacturaDian :Cargar Datos Cuenta de cobro Factura Dian
        //-------------------------------------------------
        #region flgCargarTempDatosFacturaDian: Cargar Datos Cuenta de cobro Factura Dian
        /// <summary>
        /// <para>Cargar Datos cuenta de cobro factura Dian</para>
        /// </summary>
        private bool flgCargarTempDatosFacturaDian()
        {
            var llgReturn = false;
            var lcrImagenFirma = "";
            var lcrNombreFirma = "NA";
            var lcrNotaCargo   = "NA";

            Aplicacion oApp = Aplicacion.Instancia();
            // Definir temporales para los datos 
            ModeloCarGenFactDian lobReg = null;
            List<ModeloCarGenFactDianDe> lobTempDetalles = null;

            //gobDataSet = new DataSet01();
            DataSet01.CarmaesfactumaDataTable lobMaestro = gobDataSet.Carmaesfactuma;
            DataSet01.CarmaesfactumdDataTable lobDetalles = gobDataSet.Carmaesfactumd;
            //----------------------------------------------------------
            // Maestro facturas cobro facturacion
            //----------------------------------------------------------
            #region Maestro facturas cobro facturacion
            DataSet01.CarmaesfactumaRow lobRegistroMa = lobMaestro.NewCarmaesfactumaRow();
            lobReg = ModeloCarGenFactDian.FobRegistroCarmaesfactuma("ID",gcrCodigoRegistro);
            if (lobReg.lobRegDocDian != null)
            {
                loRegEmpresa = lobReg.lobRegDocDian.lobRegEmpresa ?? null;
            }
            //-----------------------------------------------------------------
            // traer firma responsable para imprimir en factura
            //-----------------------------------------------------------------
            #region firmas
            if (loRegEmpresa != null)
            {
                lcrImagenFirma  = loRegEmpresa.Fcm_ctoimg_fcem;
                lcrNombreFirma  = loRegEmpresa.Fcm_ctonom_fcem;
                lcrNotaCargo    = loRegEmpresa.Fcm_ctondo_fcem;
            }
            #endregion
            #region cuando hay datos
            if (lobReg != null)
            {
                llgReturn = true;
                lobRegistroMa = lobMaestro.NewCarmaesfactumaRow();

                #region cargar datos
                lobRegistroMa.Car_secfac_camf = lobReg.Car_secfac_camf;
                lobRegistroMa.Fcm_typdoc_fctd = "DOCUMENTO TIPO: "+ FcrTipoDocumento(lobReg.Fcm_typdoc_fctd)+ " ELECTRÓNICA";
                lobRegistroMa.Fcm_idcufe_fctd = FcrTipoDocCufeCude(lobReg.Fcm_typdoc_fctd);
                lobRegistroMa.Car_prnobs_camf = lobReg.Car_prnobs_camf;
                lobRegistroMa.Car_observ_camf = lobReg.Car_observ_camf;
                lobRegistroMa.Car_prnnot_camf = lobReg.Car_prnnot_camf;
                lobRegistroMa.Car_medpag_camf = lobReg.Car_medpag_camf;
                lobRegistroMa.Cto_seccon_cont = lobReg.Cto_seccon_cont;
                lobRegistroMa.Cto_nrocon_cont = lobReg.Cto_nrocon_cont;
                lobRegistroMa.Sia_codeps_teps = lobReg.Sia_codeps_teps;
                lobRegistroMa.Sia_deseps_teps = lobReg.Sia_deseps_teps;
                lobRegistroMa.Sia_codnit_teps = lobReg.Sia_codnit_teps;
                lobRegistroMa.Sis_idterc_sitr = lobReg.Sis_idterc_sitr;
                lobRegistroMa.Fcm_secres_srfa = lobReg.Fcm_secres_srfa;
                lobRegistroMa.Car_nrofac_camf = lobReg.Car_nrofac_camf;
                lobRegistroMa.Car_fecfac_camf = Funciones.fcrConvertFecha(lobReg.Car_fecfac_camf);
                lobRegistroMa.Fcm_fecven_mfac = Funciones.fcrConvertFecha(lobReg.Fcm_fecven_mfac);
                lobRegistroMa.Car_valfac_camf = lobReg.Car_valfac_camf;
                lobRegistroMa.Fcm_idcufe_mfac = lobReg.lobRegDocDian != null ? lobReg.lobRegDocDian.Fcm_idcufe_mfac : "NA";
                lobRegistroMa.Fcm_metpag_mfac = lobReg.Fcm_metpag_mfac == "1" ? "CONTADO" : "CREDITO";
                lobRegistroMa.Car_tipfac_camf = lobReg.Car_tipfac_camf;
                lobRegistroMa.Fcm_secreg_mfcb = lobReg.Fcm_secreg_mfcb;
                lobRegistroMa.Fcm_numfac_mfac = lobReg.Fcm_numfac_mfac;
                lobRegistroMa.Fcm_fecfac_mfac = Funciones.fcrConvertFecha(lobReg.Fcm_fecfac_mfac);
                lobRegistroMa.Fcm_valbru_dfac = lobReg.Fcm_valbru_dfac;
                lobRegistroMa.Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac;
                lobRegistroMa.Fcm_valiva_dfac = lobReg.Fcm_valiva_dfac;
                lobRegistroMa.Fcm_valcpa_dfac = lobReg.Fcm_valcpa_dfac;
                lobRegistroMa.Fcm_valfac_dfac = lobReg.Fcm_valfac_dfac;
                lobRegistroMa.Car_conest_camf = lobReg.Car_conest_camf;
                lobRegistroMa.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                // Datos Resolucion facturacion
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
                lobRegistroMa.Sis_emailc_sitr = lobReg.Sis_emailc_sitr;
                // Otros datos
                lobRegistroMa.Sis_valor_letra = Funciones.fcrConvertirNumeroALetras(lobReg.Fcm_valfac_dfac.ToString(), "PESOS");
                lobRegistroMa.Sys_nomusu_usux = SYSValidarCodigo.fcrDEBuscarSysusuarios(lobReg.Sys_codusu_usux);
                // Cargar nombre y firma para mostrar en factura
                lobRegistroMa.Fcm_nombre_firma1  = lcrNombreFirma == "NA" ? lobRegistroMa.Sys_nomusu_usux : lcrNombreFirma;
                lobRegistroMa.Fcm_titulo_imagen1 = lcrNotaCargo   == "NA" ? "" : lcrNotaCargo;
                lobRegistroMa.Fcm_codigoqr_texto = !string.IsNullOrEmpty(gcrTextoCodigoQr) ? "OK" : "NA";

                #endregion cargar datos>

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

                // Add en temporal
                gobDataSet.Carmaesfactuma.AddCarmaesfactumaRow(lobRegistroMa);
            }
            #endregion
            #region foreach viejo
            /*
            foreach (var lobReg in lobTempMaestro)
            {
                llgReturn = true;
                lobRegistroMa = lobMaestro.NewCarmaesfactumaRow();

                lobRegistroMa.Car_secfac_camf = lobReg.Car_secfac_camf;
                lobRegistroMa.Fcm_typdoc_fctd = FcrTipoDocumento(lobReg.Fcm_typdoc_fctd);
                lobRegistroMa.Car_observ_camf = lobReg.Car_observ_camf;
                lobRegistroMa.Car_prnobs_camf = lobReg.Car_prnobs_camf;
                lobRegistroMa.Cto_seccon_cont = lobReg.Cto_seccon_cont;
                lobRegistroMa.Cto_nrocon_cont = lobReg.Cto_nrocon_cont;
                lobRegistroMa.Sia_codeps_teps = lobReg.Sia_codeps_teps;
                lobRegistroMa.Sia_deseps_teps = lobReg.Sia_deseps_teps;
                lobRegistroMa.Sia_codnit_teps = lobReg.Sia_codnit_teps;
                lobRegistroMa.Sis_idterc_sitr = lobReg.Sis_idterc_sitr;
                lobRegistroMa.Fcm_secres_srfa = lobReg.Fcm_secres_srfa;
                lobRegistroMa.Car_nrofac_camf = lobReg.Car_nrofac_camf;
                lobRegistroMa.Car_fecfac_camf = Funciones.fcrConvertFecha(lobReg.Car_fecfac_camf);
                lobRegistroMa.Fcm_fecven_mfac = Funciones.fcrConvertFecha(lobReg.Fcm_fecven_mfac);
                lobRegistroMa.Car_valfac_camf = lobReg.Car_valfac_camf;
                lobRegistroMa.Car_medpag_camf = lobReg.Car_medpag_camf;
                lobRegistroMa.Fcm_metpag_mfac = lobReg.Fcm_metpag_mfac == "1" ? "CONTADO" : "CREDITO";
                lobRegistroMa.Car_tipfac_camf = lobReg.Car_tipfac_camf;
                lobRegistroMa.Fcm_secreg_mfcb = lobReg.Fcm_secreg_mfcb;
                lobRegistroMa.Fcm_numfac_mfac = lobReg.Fcm_numfac_mfac;
                lobRegistroMa.Fcm_fecfac_mfac = Funciones.fcrConvertFecha(lobReg.Fcm_fecfac_mfac);
                lobRegistroMa.Fcm_valbru_dfac = lobReg.Fcm_valbru_dfac;
                lobRegistroMa.Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac;
                lobRegistroMa.Fcm_valiva_dfac = lobReg.Fcm_valiva_dfac;
                lobRegistroMa.Fcm_valcpa_dfac = lobReg.Fcm_valcpa_dfac;
                lobRegistroMa.Fcm_valfac_dfac = lobReg.Fcm_valfac_dfac;
                lobRegistroMa.Car_conest_camf = lobReg.Car_conest_camf;
                lobRegistroMa.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                // Datos Resolucion facturacion
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
                lobRegistroMa.Sis_valor_letra = Funciones.fcrConvertirNumeroALetras(lobReg.Fcm_valfac_dfac.ToString(), "PESOS");
                lobRegistroMa.Sys_nomusu_usux = SYSValidarCodigo.fcrDEBuscarSysusuarios(lobReg.Sys_codusu_usux);
                // Cargar nombre y firma para mostrar en factura
                lobRegistroMa.Fcm_nombre_firma1  = lcrNombreFirma == "NA" ? lobRegistroMa.Sys_nomusu_usux : lcrNombreFirma;
                lobRegistroMa.Fcm_titulo_imagen1 = lcrNotaCargo   == "NA" ? "" : lcrNotaCargo;
                lobRegistroMa.Fcm_codigoqr_texto = !string.IsNullOrEmpty(gcrTextoCodigoQr) ? "OK" : "NA";

                // imagen firma
                if (llgImagenFirma == true && lcrNombreFirma != "NA")
                {
                    lobRegistroMa.Fcm_objeto_imagen1 = REPUtilidades.fobCargarImagenes(tmp1.sys_vardfl_sycv.Trim(), tmp1.sys_varaux_sycv.Trim());
                }
                // Imagen codigo QR
                if (string.IsNullOrEmpty(gcrTextoCodigoQr) == false)
                {
                    lobRegistroMa.Fcm_objeto_imagen2 = Funciones.FobCodigoQrBitmapArray(gcrTextoCodigoQr, 250);
                }

                // Add en temporal
                gobDataSet.Carmaesfactuma.AddCarmaesfactumaRow(lobRegistroMa);
            }
            */
            #endregion foreach>
            #endregion
            //----------------------------------------------------------
            // Detalles conceptos y valores facturados 
            //----------------------------------------------------------
            #region Detalles conceptos y valores facturados
            DataSet01.CarmaesfactumdRow lobRegistroMd = lobDetalles.NewCarmaesfactumdRow();
            lobTempDetalles = ModeloCarGenFactDianDe.FlsListaCarmaesfactumd(gcrCodigoRegistro);
            llgReturn = false;

            foreach (var lobRegx in lobTempDetalles)
            {
                llgReturn = true;
                lobRegistroMd = lobDetalles.NewCarmaesfactumdRow();

                lobRegistroMd.Car_secreg_cadf = lobRegx.Car_secreg_cadf;
                lobRegistroMd.Car_secfac_camf = lobRegx.Car_secfac_camf;
                lobRegistroMd.Car_codcon_cacf = lobRegx.Car_codcon_cacf;
                lobRegistroMd.Car_descon_cadf = lobRegx.Car_descon_cadf;
                lobRegistroMd.Car_totuni_cadf = lobRegx.Car_totuni_cadf;
                lobRegistroMd.Car_valuni_cadf = lobRegx.Car_valuni_cadf;
                lobRegistroMd.Car_subtot_cadf = lobRegx.Fcm_subtot_dfac;
                lobRegistroMd.Sis_estpro_espr = lobRegx.Sis_estpro_espr;
                // Add en temporal
                gobDataSet.Carmaesfactumd.AddCarmaesfactumdRow(lobRegistroMd);
            }
            #endregion
            return llgReturn;
        }
        #endregion                   
        #endregion
    }
}
        
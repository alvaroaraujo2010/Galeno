//- MARMOTA-GENCODE: VERSION 2.0 - 16/11/2016 06:36:40 AM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using Inventarios.Modelo;

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invmovcomprasma</para>
    /// <para>DESCRIPCION:
    ///  Tabla maestro movimientos de compras  e ingresos en inventarios:
    ///  1=Cotizacion compra  2=Ordenes de compra 3=Ingresos por compra
    ///  4=Devoluciones por compra
    /// </para>
    /// </summary>
    public class VistaModeloEntradaCompras : VistaModeloEntradaComprasBase
    {
        //-------------------------------------------------
        // Variables auxiliares de gestion
        //-------------------------------------------------
        public float gflAuxValorVenta = 0; // Variable auxiliar para calcular valor venta G2Inv_valmov_inar
        public float gflValorTotFactura = 0;
        //-------------------------------------------------
        // fcrValidacion: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacion
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override String fcrValidacion(String tcrNombrePropiedad)
        {
            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgValidDefault = false;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Inv_desreg_inca":
                        #region INV_DESREG_INCA: Descripción registro
                        lcrNombreCampo = "Descripción registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Inv_desreg_inca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Inv_desreg_inca = G1Inv_desreg_inca.ToUpper();
                            if (!Funciones.flgSoloTexto("AN", G1Inv_desreg_inca))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                                G1Inv_desreg_inca = G1Inv_desreg_inca.ToUpper();
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_fecges_inca":
                        #region INV_FECGES_INCA: Fecha gestion
                        lcrNombreCampo = "Fecha gestion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Inv_fecges_inca, "Fecha gestion");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            var lobRegPeriodo = INVValidarCodigo.fobRegBuscarInvperiodomaest(G1Inv_codalm_inal, Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecges_inca));
                            if (lobRegPeriodo != null)
                            {
                                if (lobRegPeriodo.inv_peract_inpe != "1")
                                {
                                    var lcrPeriodo = ((DateTime)lobRegPeriodo.inv_fecini_inpe).ToShortDateString() +
                                                     " A " + ((DateTime)lobRegPeriodo.inv_fecfin_inpe).ToShortDateString();

                                    lcrValorReturn = lcrNombreCampo + ": el perido " + lcrPeriodo + " no esta registrado como activo en el sistema";
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": no hay periodo de gestión de inventario para la fecha";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_numref_inca":
                        #region INV_NUMREF_INCA: Cotizacion/Orden.Compra
                        lcrNombreCampo = "Cotizacion/Orden.Compra";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Inv_numref_inca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sis_secpro_sipr":
                        #region SIS_SECPRO_SIPR: Código Proveedor
                        lcrNombreCampo = "Código Proveedor";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Sis_secpro_sipr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisproveedores(G1Sis_secpro_sipr);
                            if (tmp != null)
                            {
                                G1Sis_razsoc_sipr = tmp.sis_razsoc_sipr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_codalm_inal":
                        #region INV_CODALM_INAL: Código Almacén
                        lcrNombreCampo = "Código Almacén";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Inv_codalm_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvalmacenmaest(G1Inv_codalm_inal);
                            if (tmp != null)
                            {
                                tmpRegAlmacen = tmp;
                                G1Inv_desalm_inal = tmp.inv_desalm_inal;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Con_codsco_ccos":
                        #region CON_CODSCO_CCOS: Código centro de costo
                        lcrNombreCampo = "Código centro de costo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Con_codsco_ccos))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = CONValidarCodigo.fobRegBuscarConcentrodcosto(G1Con_codsco_ccos);
                            if (tmp != null)
                            {
                                G1Con_dessco_ccos = tmp.con_dessco_ccos;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_numdoc_inca":
                        #region INV_NUMDOC_INCA: Numero Factura
                        lcrNombreCampo = "Numero Factura";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Inv_numdoc_inca))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Inv_fecdoc_inca":
                        #region INV_FECDOC_INCA: Fecha documento
                        lcrNombreCampo = "Fecha documento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Inv_fecdoc_inca, "Fecha documento");
                        break;
                        #endregion

                    case "G1Inv_diapla_inca":
                        #region INV_DIAPLA_INCA: Dias plazo pago
                        lcrNombreCampo = "Dias plazo pago";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (G1Inv_diapla_inca <= 0)
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Inv_brufac_incd":
                        #region INV_BRUFAC_INCD: Valor Bruto factura
                        lcrNombreCampo = "Valor Bruto factura";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (G1Inv_brufac_incd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            fcvCalcularTotalFactura();
                            if (gflValorTotFactura != G1Inv_valfac_incd)
                            {
                                G1Inv_valfac_incd = gflValorTotFactura;
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_pordes_incd":
                        #region INV_PORDES_INCD: Porcentaje Descuento
                        lcrNombreCampo = "Porcentaje Descuento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (G1Inv_pordes_incd < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor o igaul a cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Inv_valdes_incd":
                        #region INV_VALDES_INCD: Valor total descuento
                        lcrNombreCampo = "Valor total descuento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (G1Inv_valdes_incd < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor o igual a cero";
                        }
                        else
                        {
                            fcvCalcularTotalFactura();
                        }
                        break;
                        #endregion

                    case "G1Inv_valiva_incd":
                        #region INV_VALIVA_INCD: Valor IVA
                        lcrNombreCampo = "Valor IVA";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (G1Inv_valiva_incd < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor o igual a cero";
                        }
                        else
                        {
                            fcvCalcularTotalFactura();
                        }
                        break;
                        #endregion

                    case "G1Inv_valing_inar":
                        #region INV_VALING_INAR: Total Valor Ingreso
                        lcrNombreCampo = "Total Valor Ingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (G1Inv_valing_inar <= 0)
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";                           
                        }
                        else
                        {
                            fcvCalcularTotalFactura();
                        }
                        break;
                        #endregion

                    case "G1Inv_valfac_incd":
                        #region INV_VALFAC_INCD: Valor total facturado
                        lcrNombreCampo = "Valor total factura de compra";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (G1Inv_valfac_incd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Inv_salpag_inca":
                        #region INV_SALPAG_INCA: Saldo por pagar
                        lcrNombreCampo = "Saldo por pagar";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (G1Inv_salpag_inca <= 0)
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sys_codusu_usux":
                        #region SYS_CODUSU_USUX: Código Usuario
                        lcrNombreCampo = "Código Usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (String.IsNullOrWhiteSpace(G1Sys_codusu_usux))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SYSValidarCodigo.fobRegBuscarSysusuarios(G1Sys_codusu_usux);
                            if (tmp != null)
                            {
                                G1Sys_nomusu_usux = tmp.sys_nomusu_usux;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_fecanu_inca":
                        #region INV_FECANU_INCA: Fecha Anulación
                        lcrNombreCampo = "Fecha Anulación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        //lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Inv_fecanu_inca, "Fecha Anulación");
                        break;
                        #endregion

                    case "G1Sis_estpro_espr":
                        #region SIS_ESTPRO_ESPR: Estado Registro
                        lcrNombreCampo = "Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A25";
                        if (String.IsNullOrWhiteSpace(G1Sis_estpro_espr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisestadoproces(G1Sis_estpro_espr);
                            if (tmp != null)
                            {
                                G1Sis_despro_espr = tmp.sis_despro_espr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    default:
                        lcrValorReturn = fcrValidacionRel(tcrNombrePropiedad);
                        llgValidDefault = true;
                        break;
                }
                if (llgValidDefault == false)
                {
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacionRel: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacionRel
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override String fcrValidacionRel(String tcrNombrePropiedad)
        {
            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            //lcrValorReturn=base.fcrValidacionRel(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Inv_secart_inar":
                        #region INV_SECART_INAR: Codigo articulo
                        lcrNombreCampo = "Codigo articulo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (String.IsNullOrWhiteSpace(G2Inv_secart_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!flgBuscarEnMaestroArticulos())
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_coddig_mant":
                        #region FCM_CODDIG_MANT: Código digitación servicio
                        lcrNombreCampo = "Código digitación servicio IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "S19";
                        if (String.IsNullOrWhiteSpace(G2Fcm_coddig_mant))
                        {
                            G2Fcm_coddig_mant = "NA";
                            G2Fcm_idesec_sips = "NA";
                        }
                        if (G2Fcm_coddig_mant == "NA")
                        {
                            G2Fcm_desser_sips = "REFERENCIA NO ESTABLECIDA CON SERVICIOS IPS";
                            G2Fcm_codser_sips = String.Empty;
                            G2Inv_gesips_inar = "2"; // Quitar referencia a servicios IPS
                            G2Fcm_idesec_sips = "NA";
                        }
                        else
                        {
                            G2Fcm_coddig_mant = G2Fcm_coddig_mant.ToUpper();
                            G2Inv_gesips_inar = "2";

                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(G2Fcm_coddig_mant);
                            if (tmp != null)
                            {
                                G2Fcm_desser_sips = tmp.fcm_desser_sips;
                                G2Fcm_codser_sips = tmp.fcm_codser_sips;
                                G2Inv_gesips_inar = "1"; // Se activa la referencia a servicios IPS
                                G2Fcm_idesec_sips = tmp.fcm_idesec_sips;

                                // Verificar si se cambia referencia a servicio IPS
                                G2Inv_refips_inar = tmpRegArticulo.fcm_idesec_sips != tmp.fcm_idesec_sips ? "1" : "2";
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }

                        }
                        break;
                        #endregion

                    case "G2Inv_codaux_inar":
                        #region INV_CODAUX_INAR: Código Auxiliar
                        lcrNombreCampo = "Código de digitación Auxiliar";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        if (String.IsNullOrWhiteSpace(G2Inv_codaux_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvmaearticulosAux(G2Inv_codaux_inar);
                            if (tmp != null)
                            {
                                G2Inv_secart_inar = tmp.inv_secart_inar;
                                fcrValidacionRel("G2Inv_secart_inar");
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2G2Far_codcum_famd":
                        #region FAR_CODCUM_FAMD: Código CUM
                        lcrNombreCampo = "Código de digitación CUM";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B09";
                        if (String.IsNullOrWhiteSpace(G2Far_codcum_famd))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G2Far_codcum_famd = G2Far_codcum_famd.ToUpper();
                        }
                        break;
                        #endregion

                    case "G2Inv_lotref_inar":
                        #region INV_LOTREF_INAR: Lote o Referencia
                        lcrNombreCampo = "Lote o referencia serial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B08";
                        if (String.IsNullOrWhiteSpace(G2Inv_lotref_inar))
                        {
                            var llgEsRequerido = true;
                            if (gcrCodigoArticuloActivo == G2Inv_secart_inar)
                            {
                                var tmp = INVValidarCodigo.fobRegBuscarInvinventsubgru(tmpRegArticulo.inv_codsub_insg);
                                if (tmp != null)
                                {
                                    llgEsRequerido = tmp.inv_silote_insg == "1" ? true : false;
                                }
                            }
                            lcrValorReturn = llgEsRequerido == true ? lcrNombreCampo + ": Es requerido" : String.Empty;
                        }
                        else
                        {
                            G2Inv_lotref_inar = G2Inv_lotref_inar.ToUpper();
                        }
                        break;
                        #endregion

                    case "G2Inv_fecven_incd":
                        #region INV_FECVEN_INCD: Fecha vencimiento
                        lcrNombreCampo = "Fecha vencimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B10";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G2Inv_fecven_incd, "Fecha vencimiento");
                        // cuando esta errada y es requerida
                        if (!String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            var llgEsRequerido = true;
                            if (gcrCodigoArticuloActivo == G2Inv_secart_inar)
                            {
                                var tmp = INVValidarCodigo.fobRegBuscarInvinventsubgru(tmpRegArticulo.inv_codsub_insg);
                                if (tmp != null)
                                {
                                    llgEsRequerido = tmp.inv_sifecv_insg == "1" ? true : false;
                                }
                            }
                            lcrValorReturn = llgEsRequerido == true ? lcrNombreCampo + ": Es requerida" : String.Empty;
                        }
                        break;
                        #endregion

                    case "G2Sis_codume_sium":
                        #region SIS_CODUME_SIUM: Medida consumo
                        lcrNombreCampo = "Medida consumo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B12";
                        if (String.IsNullOrWhiteSpace(G2Sis_codume_sium))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisunidadmedida(G2Sis_codume_sium);
                            if (tmp != null)
                            {
                                G2Sis_desume_sium = tmp.sis_desume_sium;
                                G2Sis_codgme_sigr = tmp.sis_codgme_sigr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Inv_codctn_intc":
                        #region INV_CODCTN_INTC: Código Contenedor
                        lcrNombreCampo = "Código Contenedor";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B13";
                        if (String.IsNullOrWhiteSpace(G2Inv_codctn_intc))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvcontenedores(G2Inv_codctn_intc);
                            if (tmp != null)
                            {
                                G2Inv_desctn_intc = tmp.inv_desctn_intc;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Inv_totctn_incd":
                        #region INV_TOTCTN_INCD: Total Contenedores
                        lcrNombreCampo = "Total Contenedores";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B14";
                        if (G2Inv_totctn_incd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            fcvCalcularUnidades();
                        }
                        break;
                        #endregion

                    case "G2Inv_unictn_incd":
                        #region INV_UNICTN_INCD: Unidad Contenedores
                        lcrNombreCampo = "Unidad Contenedores";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B15";
                        if (G2Inv_unictn_incd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            fcvCalcularUnidades();
                        }
                        break;
                        #endregion

                    case "G2Inv_unisue_incd":
                        #region INV_UNISUE_INCD: Unidades sueltas
                        lcrNombreCampo = "Unidades sueltas";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B16";
                        if (G2Inv_unisue_incd < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser cero o mayor";
                        }
                        fcvCalcularUnidades();
                        break;
                        #endregion

                    case "G2Inv_unitot_incd":
                        #region INV_UNITOT_INCD: Total Unidades
                        lcrNombreCampo = "Total Unidades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B17";
                        if (G2Inv_unitot_incd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            //fcvCalcularValorBrutoFactura();
                        }
                        break;
                        #endregion

                    case "G2Inv_valing_inar":
                        #region INV_VALING_INAR: Total Valor Ingreso
                        lcrNombreCampo = "Total Valor Ingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B19";
                        if (G2Inv_valing_inar <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            fcvCalcularValorBrutoFactura();
                        }
                        break;
                        #endregion

                    case "G2Inv_porive_inar":
                        #region INV_PORIVE_INAR: % Incremento venta
                        lcrNombreCampo = "% Incremento venta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B24";
                        fcvCalcularValorVenta();
                        break;
                        #endregion

                    case "G2Inv_valmov_inar":
                        #region INV_VALMOV_INAR: Valor unidad venta
                        lcrNombreCampo = "Valor unidad venta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B25";
                        if (G2Inv_valmov_inar <= 0)
                        {
                            fcvCalcularValorVenta();
                            if (G2Inv_valmov_inar <= 0)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                            }
                        }
                        else
                        {
                            fcvCalcularValorVenta();
                        }
                        break;
                        #endregion

                    case "G2Inv_codest_ines":
                        #region INV_CODEST_INES: Código Estante
                        lcrNombreCampo = "Código Estante";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B27";
                        if (String.IsNullOrWhiteSpace(G2Inv_codest_ines))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G2Inv_codest_ines = G2Inv_codest_ines.ToUpper();
                            /*
                            var tmp = INVValidarCodigo.fobRegBuscarInvalmacenestanEx(G1Inv_codalm_inal, G2Inv_codest_ines);
                            if (tmp != null)
                            {
                                G2Inv_desest_ines = tmp.inv_desest_ines;
                                G2Inv_seccio_ines = tmp.inv_seccio_ines;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                            */
                        }
                        break;
                        #endregion

                    case "G2Inv_seccio_ines":
                        #region INV_SECCIO_INES: Sección
                        lcrNombreCampo = "Sección";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B28";
                        if (String.IsNullOrWhiteSpace(G2Inv_seccio_ines))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G2Inv_seccio_ines = G2Inv_seccio_ines.ToUpper();
                        }
                        break;
                        #endregion

                }
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionRel");
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcvCalcularUnidades: Calcular total unidades del articulo
        /// <summary>
        /// Calcular total unidades del articulo
        /// </summary>
        private void fcvCalcularUnidades()
        {
            if (G2Inv_totctn_incd > 0 && G2Inv_unictn_incd > 0)
            {
                G2Inv_unitot_incd = (G2Inv_totctn_incd * G2Inv_unictn_incd) + G2Inv_unisue_incd;
                fcvCalcularValorBrutoFactura();
            }

        }
        #endregion
        #region flgBuscarEnMaestroArticulos: Cargar los datos del articulo activo
        /// <summary>
        /// Cargar los datos del articulo activo, devuelve verdadero o falso si teiene exito
        /// </summary>
        private bool flgBuscarEnMaestroArticulos()
        {
            var llgReturn = false;
            var tmp = INVValidarCodigo.fobRegBuscarInvmaearticulos(G2Inv_secart_inar);
            if (tmp != null)
            {
                llgReturn = true;
                tmpRegArticulo = tmp;

                if (gcrCodigoArticuloActivo != G2Inv_secart_inar)
                {
                    G2Inv_lotref_inar = String.Empty;
                    G2Inv_regsan_inar = String.Empty;
                    G2Fcm_idesec_sips = String.Empty;
                    G2Far_codcum_famd = String.Empty;
                    G2Inv_valing_inar = 0;
                    G2Inv_porive_inar = 0;
                    gflAuxValorVenta = 0;
                }
                G2Inv_codaux_inar = tmp.inv_codaux_inar;
                G2Inv_lotref_inar = String.IsNullOrWhiteSpace(G2Inv_lotref_inar) ? tmp.inv_lotref_inar : G2Inv_lotref_inar;
                G2Inv_regsan_inar = String.IsNullOrWhiteSpace(G2Inv_regsan_inar) ? tmp.inv_regsan_inar : G2Inv_regsan_inar;
                G2Inv_regsan_inar = String.IsNullOrWhiteSpace(G2Inv_regsan_inar) ? tmp.inv_regsan_inar : G2Inv_regsan_inar;
                G2Fcm_idesec_sips = String.IsNullOrWhiteSpace(G2Fcm_idesec_sips) ? tmp.fcm_idesec_sips : G2Fcm_idesec_sips;
                G2Far_codcum_famd = String.IsNullOrWhiteSpace(G2Far_codcum_famd) ? tmp.far_codcum_famd : G2Far_codcum_famd;
                G2Inv_nomart_inar = tmp.inv_nomart_inar;
                G2Sis_codgme_sigr = tmp.sis_codgme_sigr;
                G2Sis_codume_sium = tmp.sis_codume_sium;
                G2Inv_codctn_intc = tmp.inv_codctn_intc;
                G2Inv_valing_inar = G2Inv_valing_inar == 0 ? (float)tmp.inv_valing_inar : G2Inv_valing_inar;
                G2Inv_porive_inar = G2Inv_porive_inar == 0 ? (float)tmp.inv_porive_inar : G2Inv_porive_inar;
                gflAuxValorVenta = gflAuxValorVenta == 0 ? (float)tmp.inv_valmov_inar : gflAuxValorVenta;
                gflAuxValorVenta = gflAuxValorVenta == 0 ? 100 : gflAuxValorVenta; // cuando esta vacio en maestro articulos

                if (G2Fcm_idesec_sips != "NA")
                {
                    var tmpx = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G2Fcm_idesec_sips);
                    if (tmpx != null)
                    {
                        G2Fcm_coddig_mant = tmpx.fcm_coddig_mant;
                    }
                }

                fcvCalcularValorVenta();

                gcrCodigoArticuloActivo = G2Inv_secart_inar;

            }
            return llgReturn;
        }
        #endregion
        #region fnuCalcularValorVenta: Calcular valor venta articulos
        /// <summary>
        /// Calcular valor venta articulos
        /// </summary>
        public void fcvCalcularValorVenta()
        {
            G2Inv_porivx_inar = 0;
            if (G2Inv_porive_inar != 0)
            {
                G2Inv_porivx_inar = (int)(G2Inv_valing_inar * G2Inv_porive_inar / 100);
                gflAuxValorVenta = G2Inv_valing_inar + G2Inv_porivx_inar;
            }
            else if (gflAuxValorVenta <= 0)
            {
                flgBuscarEnMaestroArticulos();
            }
            // Realizar ajuste si el almacen lo aplica
            if (tmpRegAlmacen != null && gflAuxValorVenta > 0)
            {
                if (tmpRegAlmacen.inv_redapl_inal == "1")
                {
                    G2Inv_valmov_inar = Funciones.fnuRedondeoAjuste(gflAuxValorVenta, (int)tmpRegAlmacen.inv_redval_inal, tmpRegAlmacen.inv_redtip_inal);
                    G2Inv_valred_inar = G2Inv_valmov_inar - gflAuxValorVenta;
                }
            }
        }
        #endregion
        #region fcvCalcularTotalFactura: Calcular total factura de compra
        /// <summary>
        /// Calcular total factura de compra
        /// </summary>
        private void fcvCalcularTotalFactura()
        {
            gflValorTotFactura = (G1Inv_brufac_incd - G1Inv_valdes_incd) + G1Inv_valiva_incd;
        }
        #endregion
        #region fcvCalcularValorBrutoFactura: Calcular valor bruto factura de compra
        /// <summary>
        /// Calcular valor bruto factura de compra
        /// </summary>
        private void fcvCalcularValorBrutoFactura()
        {
            if (G2Inv_unitot_incd > 0 && G2Inv_valing_inar > 0)
            {
                G2Inv_brufac_incd = (G2Inv_unitot_incd * G2Inv_valing_inar);
            }
        }
        #endregion

    }
}
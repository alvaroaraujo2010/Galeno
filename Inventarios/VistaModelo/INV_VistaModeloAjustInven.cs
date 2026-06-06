//- MARMOTA-GENCODE: VERSION 2.0 - 21/08/2017 11:50:15 AM
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
    /// <para>TABLA: invajustesmaema</para>
    /// <para>DESCRIPCION:
    /// Archivo maestro para registrar los ajustes de inventarios
    /// </para>
    /// </summary>
    public class VistaModeloAjustInven : VistaModeloAjustInvenBase
    {
        public EFinvalmacexisten tmpExisten = null;
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
                    case "G1Inv_fecges_inja":
                        #region INV_FECGES_INJA: Fecha ajuste
                        lcrNombreCampo = "Fecha ajuste";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Inv_fecges_inja, "Fecha ajuste");
                        break;
                        #endregion

                    case "G1Inv_codalm_inal":
                        #region INV_CODALM_INAL: Código Almacén
                        lcrNombreCampo = "Código Almacén";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Inv_codalm_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvalmacenmaest(G1Inv_codalm_inal);
                            if (tmp != null)
                            {
                                G1Inv_desalm_inal = tmp.inv_desalm_inal;
                                G1Sia_codare_aser = tmp.sia_codare_aser;
                                G1Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro;
                                G1Sia_codcat_ceat = tmp.sia_codcat_ceat;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_conaju_incp":
                        #region INV_CONAJU_INCP: Código concepto ajuste
                        lcrNombreCampo = "Código concepto ajuste";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Inv_conaju_incp))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvajusteconcep(G1Inv_conaju_incp);
                            if (tmp != null)
                            {
                                G1Inv_desaju_incp = tmp.inv_desaju_incp;
                                G1Inv_conmov_incm = tmp.inv_conmov_incm;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_desaju_inja":
                        #region INV_DESAJU_INJA: Nota detallle
                        lcrNombreCampo = "Nota detallle";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Inv_desaju_inja))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Inv_desaju_inja = G1Inv_desaju_inja.ToUpper();
                            if (!Funciones.flgSoloTexto("AN", G1Inv_desaju_inja))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sys_codusu_usux":
                        #region SYS_CODUSU_USUX: Usuario del sistema
                        lcrNombreCampo = "Usuario del sistema";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
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

                    case "G1Sis_estpro_espr":
                        #region SIS_ESTPRO_ESPR: Estado Registro
                        lcrNombreCampo = "Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
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
            bool llgValidDefault = false;

            //lcrValorReturn=base.fcrValidacionRel(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Inv_secart_inar":
                        #region INV_SECART_INAR: Secuencial Articulo
                        //lcrNombreCampo = "Secuencial Articulo";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "B07";
                        //if (String.IsNullOrWhiteSpace(G2Inv_secart_inar))
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        //}
                        //else
                        //{
                        //    G2Inv_secart_inar = G2Inv_secart_inar.ToUpper();
                        //    var tmp = INVValidarCodigo.fobRegBuscarInvmaearticulos(G2Inv_secart_inar);
                        //    if (tmp != null)
                        //    {
                        //        G2Inv_codaux_inar = tmp.inv_codaux_inar;
                        //        G2Inv_nomart_inar = tmp.inv_nomart_inar;
                        //        //G2Inv_lotref_inar = tmp.inv_lotref_inar;
                        //        G2Sis_codgme_sigr = tmp.sis_codgme_sigr;                               
                        //        G2Inv_valing_inar = (float)tmp.inv_valing_inar;
                        //        G2Inv_valmov_inar = (float)tmp.inv_valmov_inar;
                        //    }
                        //    else
                        //    {
                        //        lcrValorReturn = lcrNombreCampo + ": No existe";
                        //    }
                        //}
                        break;
                        #endregion

                    case "G2Inv_codaux_inar":
                        #region INV_CODAUX_INAR: Código Auxiliar Articulo
                        lcrNombreCampo = "Código Auxiliar Articulo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B08";
                        if (String.IsNullOrWhiteSpace(G2Inv_codaux_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G2Inv_codaux_inar = G2Inv_codaux_inar.ToUpper();
                            tmpExisten = INVValidarCodigo.fobRegBuscarInvalmacexistenAux(G1Inv_codalm_inal, G2Inv_codaux_inar);
                            if (tmpExisten != null)
                            {
                                // Descripcion del articulo

                                var tmpAux = INVValidarCodigo.fobRegBuscarInvmaearticulos(tmpExisten.inv_codaux_inar);
                                if (tmpAux != null)
                                {
                                    G2Inv_secart_inar = tmpExisten.inv_secart_inar;
                                    G2Inv_nomart_inar = tmpAux.inv_nomart_inar;
                                    G2Sis_codgme_sigr = tmpExisten.sis_codgme_sigr;
                                    G2Inv_totuni_inex = (int)tmpExisten.inv_totuni_inex;
                                    G2Inv_valing_inar = (float)tmpExisten.inv_valing_inar;
                                    G2Inv_valmov_inar = (float)tmpExisten.inv_valmov_inar;
                                    G2Inv_codalm_inal = G1Inv_codalm_inal;
                                }
                                else
                                {
                                    if ((flgCompararCamposArticulos(G2Inv_codaux_inar) == true))
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": El codigo del Articulo ya existe en la grilla";
                                    }

                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Sis_codgme_sigr":
                        #region SIS_CODGME_SIGR: Patrón medida
                        //lcrNombreCampo = "Patrón medida";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "B10";
                        //if (String.IsNullOrWhiteSpace(G2Sis_codgme_sigr))
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        //}
                        //else
                        //{
                        //    var tmp = SISValidarCodigo.fobRegBuscarSisgrupomedidas(G2Sis_codgme_sigr);
                        //    if (tmp != null)
                        //    {
                        //        G2Sis_desgme_sigr = tmp.sis_desgme_sigr;
                        //    }
                        //    else
                        //    {
                        //        lcrValorReturn = lcrNombreCampo + ": No existe";
                        //    }
                        //}
                        break;
                        #endregion

                    case "G2Inv_totuni_inex":
                        #region INV_TOTUNI_INEX: Existencias Almacen
                        //lcrNombreCampo = "Existencias Almacen";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "B12";
                        //if (G2Inv_totuni_inex <= 0)
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        //}
                        //else
                        //{
                        //}
                        break;
                        #endregion

                    case "G2Inv_totuni_injd":
                        #region INV_TOTUNI_INJD: Nuevo total existencias
                        lcrNombreCampo = "Nuevo total existencias";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B15";
                        if (G2Inv_totuni_injd <= 0)
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Inv_valing_inar":
                        #region INV_VALING_INAR: Valor  Ingreso unidad
                        //lcrNombreCampo = "Valor  Ingreso unidad";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "B16";
                        //if (G2Inv_valing_inar <= 0)
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        //}
                        //else
                        //{
                        //}
                        break;
                        #endregion

                    case "G2Inv_valmov_inar":
                        #region INV_VALMOV_INAR: Valor salida unidad
                        //lcrNombreCampo = "Valor salida unidad";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "B17";
                        //if (G2Inv_valmov_inar <= 0)
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        //}
                        //else
                        //{
                        //}
                        break;
                        #endregion

                    default:
                        lcrValorReturn = fcrValidacionKar(tcrNombrePropiedad);
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionRel");
            }
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // fcrValidacionKar: Validacion campos
        //-------------------------------------------------
        #region Validacion Campos: fcrValidacionKar
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public override String fcrValidacionKar(String tcrNombrePropiedad)
        {
            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            //lcrValorReturn = base.fcrValidacionKar(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G3Inv_lotref_inar":
                        #region INV_LOTREF_INAR: Lote o Referencia
                        lcrNombreCampo = "Lote o Referencia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "C01";
                        if (String.IsNullOrWhiteSpace(G3Inv_lotref_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else                            
                        {                           
                            G3Inv_lotref_inar = G3Inv_lotref_inar.ToUpper();
                        }
                        break;
                        #endregion

                    case "G3Inv_fecven_inka":
                        #region INV_FECVEN_INKA: Fecha vencimiento
                        lcrNombreCampo = "Fecha vencimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "C02";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G3Inv_fecven_inka, "Fecha vencimiento");
                        break;
                        #endregion

                    case "G3Inv_codest_ines":
                        #region INV_CODEST_INES: Código Estante
                        lcrNombreCampo = "Código Estante";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "C03";
                        if (String.IsNullOrWhiteSpace(G3Inv_codest_ines))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G3Inv_codest_ines = G3Inv_codest_ines.ToUpper();
                            //var tmp = INVValidarCodigo.fobRegBuscarInvalmacenestan(G3Inv_codest_ines);
                            //if (tmp != null)
                            //{
                            //    //G3Inv_codalm_inal = tmp.inv_codalm_inal;
                            //    G3Inv_desest_ines = tmp.inv_desest_ines;
                            //    //G3Inv_seccio_ines = tmp.inv_seccio_ines;
                            //}
                            //else
                            //{
                            //    lcrValorReturn = lcrNombreCampo + ": No existe";
                            //}
                        }
                        break;
                        #endregion

                    case "G3Inv_seccio_ines":
                        #region INV_SECCIO_INES: Secciones
                        lcrNombreCampo = "Secciones";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "C04";
                        if (String.IsNullOrWhiteSpace(G3Inv_seccio_ines))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                            G3Inv_seccio_ines = G3Inv_seccio_ines.ToUpper();
                        {
                        }
                        break;
                        #endregion

                    case "G3Inv_totaju_injd":
                        #region INV_TOTAJU_INJD: Unidades digitadas
                        lcrNombreCampo = "Unidades digitadas";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "C05";
                        if (G3Inv_totaju_injd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            //fcvCalcularUnidades();
                        }
                        break;
                        #endregion

                    case "G3Inv_totmov_injd":
                        #region INV_TOTMOV_INJD: Unidades Movimiento
                        lcrNombreCampo = "Unidades Movimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "C05";
                        if (G3Inv_totmov_injd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            //G3Inv_totmov_injd = G3Inv_totaju_injd;
                            //fcvCalcularUnidades();
                        }
                        break;
                        #endregion

                    case "G3Inv_totuni_injd":
                        #region INV_UNITOT_INMD: Nuevo Total Existencias
                        lcrNombreCampo = "Nuevo Total Existencias";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B16";
                        if (G3Inv_totuni_injd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {                         
                        }
                        break;
                        #endregion

                }
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionKar");
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcvCalcularUnidades: Calcular total unidades del articulo
        /// <summary>
        /// Calcular total unidades del articulo: Reconteo unidades y/o Suma o Resta 
        /// </summary>
        //private void fcvCalcularUnidades()
        //{
        //    if (G3Inv_totuni_inex > G3Inv_totaju_injd)
        //    {                
        //        G3Inv_totuni_injd = G3Inv_totaju_injd - G3Inv_totuni_inex;               
        //    }
        //    else
        //    {
        //        //if (G3Inv_totuni_inex < G3Inv_totaju_injd)
        //        //{
        //            G3Inv_totuni_injd = G3Inv_totuni_inex - G3Inv_totaju_injd;
        //        //}
        //    }
        //}
        #endregion
        #region flgCargarDatosArticulo
        /// <summary>
        /// Cargar datos del articulo
        /// </summary>
        //private bool flgCargarDatosArticulo(String tcrTipoCampo, String tcrCodigo )
        //{
        //    var llgReturn = false;
        //    tmpExisten = null;

        //    switch (tcrTipoCampo)
        //    {
        //        ////Cargar datos con codigo auxiliar del articulo
        //        case "1":
        //            tmpExisten = INVValidarCodigo.fobRegBuscarInvalmacexistenAux(G1Inv_codalm_inal, G2Inv_codaux_inar);
        //            break;

        //    }
        //     //Cargar vista de datos
        //    if (tmpExisten != null)
        //    {

        //    }
        //    return llgReturn;
        //}
        #endregion
        #region fcvLimpiarCamposAlmacen
        /// <summary>
        /// Limpiar campos codigos del almacen, destino y personal responsable
        /// </summary>
        private void fcvLimpiarCamposAlmacen(String tcrTipoCampo)
        {
            switch (tcrTipoCampo)
            {
                //Limpiar datos relacionados con codigo almacen
                case "1":
                    G1Inv_desalm_inal = String.Empty;
                    break;
                //Limpiar datos relacionados con codigo almacen destino
                case "2":
                    G1Inv_desaju_incp = String.Empty;
                    break;
                //Limpiar datos relacionados con codigo del personsal responsable
                case "3":
                    G1Sys_nomusu_usux = String.Empty;
                    break;

                //Limpiar datos relacionados con codigo area de servicios
                case "4":
                    G1Sia_desare_aser = String.Empty;
                    break;
            }
        }
        #endregion
        #region fcvLimpiarCamposArticulo
        /// <summary>
        /// Limpiar campos codigos del articulo
        /// </summary>
        private void fcvLimpiarCamposArticulo(String tcrTipoCampo)
        {
            switch (tcrTipoCampo)
            {
                //Limpiar datos relacionados con secuencial de articulo
                case "1":
                    G2Inv_codaux_inar = String.Empty;
                    //G2Inv_codbar_inar = String.Empty;
                    break;
                //Limpiar datos relacionados con codigo auxiliar de articulo
                case "2":
                    G2Inv_secart_inar = String.Empty;
                    //G2Inv_codbar_inar = String.Empty;
                    break;
                ////Limpiar datos relacionados con codigo de barras de articulo
                //case "3":
                //    G2Inv_codbar_inar = String.Empty;
                //    break;
            }
            G2Inv_nomart_inar = String.Empty;
            G2Sis_codgme_sigr = String.Empty;
            G2Inv_valing_inar = 0;
            G2Inv_valmov_inar = 0;            
            G2Inv_totuni_inex = 0;
            G2Inv_totuni_injd = 0;
        }
        #endregion
        #region flgCompararArticulos
        /// <summary>
        /// Comparar articulos guardados en la grilla con el que se esta
        /// ingresando.
        /// </summary>
        private bool flgCompararCamposArticulos(String tcrCodigo)
        {
            var llgReturn = false;
            var lobjRegistro = TmpG2ListaBrow.FirstOrDefault(p => p.Inv_codaux_inar == tcrCodigo);
            if (lobjRegistro != null)
            {
                if (lobjRegistro != TmpG2RegActivo)
                {
                    llgReturn = true;
                }
            }
            return llgReturn;
        }
        #endregion
    }
}

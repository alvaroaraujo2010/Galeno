//- MARMOTA-GENCODE: VERSION 2.0 - 15/06/2017 11:25:17 AM
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

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invmovdiariosma</para>
    /// <para>DESCRIPCION:
    ///  Tabla maestro movimientos diarios inventarios, contiene un
    ///  registro maestro según cada tipo registro movimiento del inventario:
    ///  (INMA = Maestro de movimientos diarios del inventario) ,traslado
    ///  entre almacenes, pedidos para consumo interno y otros.
    /// </para>
    /// </summary>
    public class VistaModeloMovSuministro : VistaModeloMovSuministroBase
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
                    case "G1Inv_conmov_incm":
                        #region INV_CONMOV_INCM: Concepto movimiento
                        lcrNombreCampo = "Concepto movimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Inv_conmov_incm))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvtipoconcemov(G1Inv_conmov_incm);
                            if (tmp != null)
                            {
                                G1Inv_tipmov_intr = tmp.inv_tipmov_intr;
                                G1Inv_descon_incm = tmp.inv_descon_incm;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_desreg_inma":
                        #region INV_DESREG_INMA: Descripción registro
                        lcrNombreCampo = "Descripción registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Inv_desreg_inma))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Inv_desreg_inma))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                            G1Inv_desreg_inma = G1Inv_desreg_inma.ToUpper();
                        }
                        break;
                        #endregion

                    case "G1Inv_fecges_inma":
                        #region INV_FECGES_INMA: Fecha gestion
                        lcrNombreCampo = "Fecha gestion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Inv_fecges_inma, "Fecha gestion");
                        break;
                        #endregion

                    case "G1Inv_codalm_inal":
                        #region INV_CODALM_INAL: Código Almacén
                        lcrNombreCampo = "Código Almacén";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        fcvCompararCamposAlmacen("G1Inv_codalm_inal");
                        if (String.IsNullOrWhiteSpace(G1Inv_codalm_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (flgCargarDatosAlmacen("1", G1Inv_codalm_inal) == false)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Esta errado";
                                fcvLimpiarCamposAlmacen("1");
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_codald_inal":
                        #region INV_CODALD_INAL: Código Almacén Destino
                        lcrNombreCampo = "Código Almacén Destino";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        fcvCompararCamposAlmacen("G1Inv_codald_inal");
                        if (G1Inv_conmov_incm == "S22")
                        {
                            if (String.IsNullOrWhiteSpace(G1Inv_codald_inal))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                            else
                            {
                                if (flgCargarDatosAlmacen("2", G1Inv_codald_inal) == false)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Esta errado";
                                    fcvLimpiarCamposAlmacen("2");
                                }
                            }
                        }
                        else
                        {
                            G1Inv_codald_inal = "NA";
                        }
                        break;
                        #endregion

                    case "G1Inv_fecdoc_inma":
                        #region INV_FECDOC_INMA: Fecha registro referencia
                        lcrNombreCampo = "Fecha registro referencia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Inv_fecdoc_inma, "Fecha registro referencia");
                        break;
                        #endregion

                    case "G1Inv_codres_inre":
                        #region INV_CODRES_INRE: Código responsable
                        lcrNombreCampo = "Código responsable";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Inv_codres_inre))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvresponsables(G1Inv_codres_inre);
                            if (tmp != null)
                            {
                                G1Inv_nomres_inre = tmp.inv_nomres_inre;
                                G1Sys_codusu_usux = tmp.sys_codusu_usux;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                                fcvLimpiarCamposAlmacen("3");
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_coddep_sidp":
                        #region SIS_CODDEP_SIDP: Codigo dependencia
                        lcrNombreCampo = "Codigo dependencia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (String.IsNullOrWhiteSpace(G1Sis_coddep_sidp))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSismaesdependen(G1Sis_coddep_sidp);
                            if (tmp != null)
                            {
                                G1Sis_coddep_sidp = tmp.sis_coddep_sidp;
                                G1Sis_nomdep_sidp = tmp.sis_nomdep_sidp;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                                fcvLimpiarCamposAlmacen("4");
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codare_aser":
                        #region SIA_CODARE_ASER: Código area servicios
                        lcrNombreCampo = "Código area servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (String.IsNullOrWhiteSpace(G1Sia_codare_aser))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G1Sia_codare_aser);
                            if (tmp != null)
                            {
                                //G1Sia_codare_aser = tmp.sia_codare_aser;
                                G1Sia_desare_aser = tmp.sia_desare_aser;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                                fcvLimpiarCamposAlmacen("5");
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_estpro_espr":
                        #region SIS_ESTPRO_ESPR: Estado Registro
                        lcrNombreCampo = "Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
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
                        #region INV_SECART_INAR: Secuencial  Articulo
                        lcrNombreCampo = "Secuencial  Articulo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B01";
                        if (String.IsNullOrWhiteSpace(G2Inv_secart_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G2Inv_secart_inar = G2Inv_secart_inar.ToUpper();
                            if ((flgCargarDatosArticulo("1", G2Inv_secart_inar) == false))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Esta errado";
                            }
                            else
                            {
                                if ((flgCompararCamposArticulos(G2Inv_secart_inar) == true))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": El codigo del Articulo ya existe en la grilla";
                                }

                            }
                        }
                        break;
                        #endregion

                    case "G2Inv_codaux_inar":
                        #region INV_CODAUX_INAR: Código Auxiliar Articulo
                        lcrNombreCampo = "Código Auxiliar Articulo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (String.IsNullOrWhiteSpace(G2Inv_codaux_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G2Inv_codaux_inar = G2Inv_codaux_inar.ToUpper();
                            if (flgCargarDatosArticulo("2", G2Inv_codaux_inar) == false)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Esta errado";
                                //fcvLimpiarCamposArticulo("2");
                            }
                            else
                            {
                                if ((flgCompararCamposArticulos(G2Inv_secart_inar) == true))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": El codigo del Articulo ya existe en la grilla";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Inv_codbar_inar":
                        #region INV_CODBAR_INAR: Código Barras Articulo
                        //lcrNombreCampo = "Código Barras Articulo";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "B07";
                        //if (!String.IsNullOrWhiteSpace(G2Inv_codbar_inar))
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        //}
                        //else
                        //{
                        //    G2Inv_codbar_inar = G2Inv_codbar_inar.ToUpper();
                        //    if ((flgCargarDatosArticulo("3", G2Inv_codbar_inar) == false))
                        //    {
                        //        lcrValorReturn = lcrNombreCampo + ": Esta errado";
                        //    }
                        //    else
                        //    {
                        //        if ((flgCompararCamposArticulos(G2Inv_secart_inar) == true))
                        //        {
                        //            lcrValorReturn = lcrNombreCampo + ": El codigo del Articulo ya existe en la grilla";
                        //        }
                        //    }
                        //}
                        break;
                        #endregion

                    case "G2Sis_codgme_sigr":
                        #region SIS_CODGME_SIGR: Patrón medida
                        lcrNombreCampo = "Patrón medida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B12";
                        if (String.IsNullOrWhiteSpace(G2Sis_codgme_sigr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisgrupomedidas(G2Sis_codgme_sigr);
                            if (tmp != null)
                            {
                                G2Sis_desgme_sigr = tmp.sis_desgme_sigr;
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
                        lcrCodigoError = "B12";
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

                    case "G2Inv_totctn_inmd":
                        #region INV_TOTCTN_INMD: Total Contenedores
                        lcrNombreCampo = "Total Contenedores";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B13";
                        if (G2Inv_totctn_inmd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                            fcvCalcularUnidades();
                        }
                        else
                        {
                            fcvCalcularUnidades();
                        }
                        break;
                        #endregion

                    case "G2Inv_unictn_inmd":
                        #region INV_UNICTN_INMD: Unidad Contenedores
                        lcrNombreCampo = "Unidad Contenedores";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B14";
                        if (G2Inv_unictn_inmd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                            fcvCalcularUnidades();
                        }
                        else
                        {
                            fcvCalcularUnidades();
                        }
                        break;
                        #endregion

                    case "G2Inv_unisue_inmd":
                        #region INV_UNISUE_INMD: Unidades sueltas
                        lcrNombreCampo = "Unidades sueltas";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B15";
                        if (G2Inv_unisue_inmd < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser cero o mayor";
                        }
                        fcvCalcularUnidades();
                        break;
                        #endregion

                    case "G2Inv_unitot_inmd":
                        #region INV_UNITOT_INMD: Total Unidades
                        lcrNombreCampo = "Total Unidades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B16";
                        if (G2Inv_unitot_inmd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (tmpExisten != null)
                            {
                                if (G2Inv_unitot_inmd > tmpExisten.inv_totuni_inex)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No hay suficientes suministros para este pedido";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Inv_codest_ines":
                        #region INV_CODEST_INES: Código Estante
                        lcrNombreCampo = "Código Estante";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B24";
                        if (String.IsNullOrWhiteSpace(G2Inv_codest_ines))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvalmacenestan(G2Inv_codest_ines);
                            if (tmp != null)
                            {
                                G2Inv_codalm_inal = tmp.inv_codalm_inal;
                                G2Inv_seccio_ines = tmp.inv_seccio_ines;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Inv_seccio_ines":
                        #region INV_SECCIO_INES: Secciones
                        lcrNombreCampo = "Secciones";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B25";
                        if (String.IsNullOrWhiteSpace(G2Inv_seccio_ines))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Sis_estpro_espr":
                        #region SIS_ESTPRO_ESPR: Estado Registro
                        lcrNombreCampo = "Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B27";
                        if (String.IsNullOrWhiteSpace(G2Sis_estpro_espr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisestadoproces(G2Sis_estpro_espr);
                            if (tmp != null)
                            {
                                G2Sis_despro_espr = tmp.sis_despro_espr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
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
            if (G2Inv_totctn_inmd > 0 && G2Inv_unictn_inmd > 0)
            {
                G2Inv_unitot_inmd = (G2Inv_totctn_inmd * G2Inv_unictn_inmd) + G2Inv_unisue_inmd;
            }
            else
            {
                G2Inv_unitot_inmd = 0;
            }
        }
        #endregion
        #region flgCargarDatosAlmacen
        /// <summary>
        /// Cargar datos del articulo
        /// </summary>
        private bool flgCargarDatosAlmacen(String tcrTipoCampo, String tcrCodigo)
        {
            var llgReturn = false;
            EFinvalmacenmaest tmp = null;

            switch (tcrTipoCampo)
            {
                //Cargar datos con codigo secuencial del articulo
                case "1":
                    tmp = INVValidarCodigo.fobRegBuscarInvalmacenmaest(tcrCodigo);
                    if (tmp != null)
                    {
                        llgReturn = true;
                        G2Inv_codalm_inal = G1Inv_codalm_inal;
                        G1Inv_desalm_inal = tmp.inv_desalm_inal;
                    }
                    break;

                //Cargar datos con codigo de almacen destino
                case "2":
                    tmp = INVValidarCodigo.fobRegBuscarInvalmacenmaest(tcrCodigo);
                    if (tmp != null)
                    {
                        llgReturn = true;
                        G1Deinv_codald_inal = tmp.inv_desalm_inal;
                    }
                    break;
            }
            return llgReturn;
        }
        #endregion
        #region flgCargarDatosArticulo
        /// <summary>
        /// Cargar datos del articulo articulo segun codigo 
        /// </summary>
        private bool flgCargarDatosArticulo(String tcrTipoCampo, String tcrCodigo)
        {
            var llgReturn = false;
            tmpExisten = null;

            switch (tcrTipoCampo)
            {
                //Cargar datos con codigo secuencial del articulo
                case "1":
                    tmpExisten = INVValidarCodigo.fobRegBuscarInvalmacexisten(G1Inv_codalm_inal, G2Inv_secart_inar);
                    break;
                ////Cargar datos con codigo auxiliar del articulo
                case "2":
                    tmpExisten = INVValidarCodigo.fobRegBuscarInvalmacexistenAux(G1Inv_codalm_inal, G2Inv_codaux_inar);
                    break;
                ////Cargar datos con codigo de barras del articulo
                //case "3":
                //    tmpExisten = INVValidarCodigo.fobRegBuscarInvalmacexistenBarra(G1Inv_codalm_inal, G2Inv_codbar_inar);
                //    break;
            }
            // Cargar vista de datos
            if (tmpExisten != null)
            {
                var tmpAux = INVValidarCodigo.fobRegBuscarInvmaearticulos(tmpExisten.inv_secart_inar);
                if (tmpAux != null)
                {
                    #region Cargar vista datos
                    llgReturn = true;
                    G2Inv_secart_inar = tmpExisten.inv_secart_inar;
                    G2Inv_codaux_inar = tmpExisten.inv_codaux_inar;
                    //G2Inv_codbar_inar = tmpExisten.inv_codbar_inar;
                    G2Inv_nomart_inar = tmpAux.inv_nomart_inar;
                    G2Sis_codgme_sigr = tmpExisten.sis_codgme_sigr;
                    G2Inv_codctn_intc = tmpAux.inv_codctn_intc;
                    G2Inv_valing_inar = (float)tmpExisten.inv_valing_inar;
                    G2Inv_valmov_inar = (float)tmpExisten.inv_valmov_inar;
                    G2Inv_codalm_inal = G1Inv_codalm_inal;
                    G2Inv_codald_inal = G1Inv_codald_inal;
                    #endregion
                }
            }
            return llgReturn;
        }
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
                    G1Deinv_codald_inal = String.Empty;
                    break;
                //Limpiar datos relacionados con codigo del personsal responsable
                case "3":
                    G1Inv_nomres_inre = String.Empty;
                    break;
                //Limpiar datos relacionados con codigo de dependencia almacen
                case "4":
                    G1Sis_nomdep_sidp = String.Empty;
                    break;
                //Limpiar datos relacionados con codigo area de servicios
                case "5":
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
                    G2Inv_codbar_inar = String.Empty;
                    break;
                //Limpiar datos relacionados con codigo auxiliar de articulo
                case "2":
                    G2Inv_secart_inar = String.Empty;
                    G2Inv_codbar_inar = String.Empty;
                    break;
                //Limpiar datos relacionados con codigo de barras de articulo
                case "3":
                    G2Inv_codbar_inar = String.Empty;
                    break;
            }
            G2Inv_nomart_inar = String.Empty;
            G2Sis_codgme_sigr = String.Empty;
            G2Inv_codctn_intc = String.Empty;
            G2Inv_valing_inar = 0;
            G2Inv_valmov_inar = 0;
            G2Inv_totctn_inmd = 0;
            G2Inv_unictn_inmd = 0;
            G2Inv_unisue_inmd = 0;
            G2Inv_unitot_inmd = 0;
        }
        #endregion
        #region fcvCompararCamposAlmacen
        /// <summary>
        /// Comparar campos codigos del articulo
        /// </summary>
        public void fcvCompararCamposAlmacen(String tcrTipoCampo)
        {
            switch (tcrTipoCampo)
            {
                case "G1Inv_codalm_inal":
                    if (G1Inv_codalm_inal == G1Inv_codald_inal)
                    {
                        G1Inv_codald_inal = " ";
                        G1Deinv_codald_inal = " ";
                    }
                    break;

                case "G1Inv_codald_inal":
                    if (G1Inv_codald_inal == G1Inv_codalm_inal)
                    {
                        G1Inv_codalm_inal = " ";
                        G1Inv_desalm_inal = " ";
                    }
                    break;
            }
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
            var lobjRegistro = TmpG2ListaBrow.FirstOrDefault(p => p.Inv_secart_inar == tcrCodigo);
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


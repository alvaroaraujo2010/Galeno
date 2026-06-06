//- MARMOTA-GENCODE: VERSION 2.0 - 07/11/2016 11:28:17 AM
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
    /// <para>TABLA: invmaearticulos</para>
    /// <para>DESCRIPCION:
    ///  Contiene el manual de artículos, los cuales alimentaran el
    ///  inventario en la tabla maestro de inventario.
    /// </para>
    /// </summary>
    public class VistaModeloInvmaestroarticulo : VistaModeloInvmaestroarticuloBase
    {
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

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Inv_tipart_inar":
                        #region INV_TIPART_INAR: Tipo articulo
                        lcrNombreCampo = "Tipo articulo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Inv_tipart_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_tipart_inar, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_codgru_ingr":
                        #region INV_CODGRU_INGR: Grupo Clasificación
                        lcrNombreCampo = "Grupo Clasificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Inv_codgru_ingr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvinventgrupos(G1Inv_codgru_ingr);
                            if (tmp != null)
                            {
                                G1Inv_desgru_ingr = tmp.inv_desgru_ingr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_codsub_insg":
                        #region INV_CODSUB_INSG: Subgrupo Clasificación
                        lcrNombreCampo = "Subgrupo Clasificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Inv_codsub_insg))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvinventsubgru(G1Inv_codsub_insg);
                            if (tmp != null)
                            {
                                G1Inv_codgru_ingr = tmp.inv_codgru_ingr;
                                G1Inv_dessub_insg = tmp.inv_dessub_insg;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_codaux_inar":
                        #region INV_CODAUX_INAR: Código Auxiliar
                        lcrNombreCampo = "Código Auxiliar";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Inv_codaux_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvmaearticulos(G1Inv_codaux_inar);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.inv_secart_inar))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G1Inv_secart_inar != tmp.inv_secart_inar) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_codbar_inar":
                        #region INV_CODBAR_INAR: Código Barra
                        lcrNombreCampo = "Código Barra";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (!String.IsNullOrWhiteSpace(G1Inv_codbar_inar))
                        {
                            if (G1Inv_codbar_inar.Length < 7)
                            {
                                lcrValorReturn = lcrNombreCampo + ": requiere mas caracteres";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Inv_codbar_inar, "0123456789"))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Contiene caracteres que no son numeros";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_regsan_inar":
                        #region INV_REGSAN_INAR: Registro sanitario
                        lcrNombreCampo = "Registro sanitario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (!String.IsNullOrWhiteSpace(G1Inv_regsan_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            // -aqui-
                        }
                        break;
                        #endregion

                    case "G1Inv_nomart_inar":
                        #region INV_NOMART_INAR: Nombre artículo
                        lcrNombreCampo = "Nombre artículo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Inv_nomart_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Inv_nomart_inar = G1Inv_nomart_inar.ToUpper();
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Inv_nomart_inar, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ()0123456789.%/ "))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_desart_inar":
                        #region INV_DESART_INAR: Descripción Artículo
                        lcrNombreCampo = "Descripción Artículo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Inv_desart_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Inv_desart_inar = G1Inv_desart_inar.ToUpper();

                            if (!Funciones.flgExisteSubCadenaStringEx(G1Inv_desart_inar, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ()0123456789.%/ "))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_secimg_inaj":
                        #region INV_SECIMG_INAJ: Código imagen JPG PNG
                        lcrNombreCampo = "Código imagen JPG PNG";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (!String.IsNullOrWhiteSpace(G1Inv_secimg_inaj))
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvmaeartimagen(G1Inv_secimg_inaj);
                            if (tmp != null)
                            {
                                G1Inv_secart_inar = tmp.inv_secart_inar;
                                G1Inv_nomimg_inaj = tmp.inv_nomimg_inaj;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_simcrt_inar":
                        #region INV_SIMCRT_INAR: Medicamento de control
                        lcrNombreCampo = "Medicamento de control";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (String.IsNullOrWhiteSpace(G1Inv_simcrt_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_simcrt_inar, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else if (G1Inv_tipart_inar == "2" && G1Inv_simcrt_inar =="3")
                            {
                                lcrValorReturn = "'"+lcrNombreCampo + "': Valor 3=No es medicamento, dato no consistente con Campo 'Tipo Articulo': valor 2=Medicamento";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_forfar_fama":
                        #region FAR_FORFAR_FAMA: Forma Farmaceutica
                        lcrNombreCampo = "Forma Farmaceutica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (G1Inv_tipart_inar == "2")
                        {
                            if (String.IsNullOrWhiteSpace(G1Far_forfar_fama))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_prinac_fama":
                        #region FAR_PRINAC_FAMA: Principio activo
                        /*
                        lcrNombreCampo = "Principio activo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (G1Inv_tipart_inar == "2")
                        {
                            if (String.IsNullOrWhiteSpace(G1Far_prinac_fama))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                        }
                        */
                        break;
                        #endregion

                    case "G1Far_codcum_famd":
                        #region FAR_CODCUM_FAMD: Código CUM
                        lcrNombreCampo = "Código CUM";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (G1Inv_tipart_inar == "2")
                        {
                            if (String.IsNullOrWhiteSpace(G1Far_codcum_famd))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                            else
                            {
                                if (G1Far_codcum_famd.Length < 5)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Valor no es valido";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_gesips_inar":
                        #region INV_GESIPS_INAR: Activar servicio IPS
                        lcrNombreCampo = "Activar servicio IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "S17";
                        if (String.IsNullOrWhiteSpace(G1Inv_gesips_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_gesips_inar, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_idesec_sips":
                        #region FCM_IDESEC_SIPS: Servicio IPS
                        lcrNombreCampo = "Servicio IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "S18";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Fcm_idesec_sips))
                        {
                            G1Fcm_idesec_sips = "NA";
                        }
                        if (G1Fcm_idesec_sips == "NA")
                        {
                            G1Fcm_desser_sips = "REFERENCIA NO ESTABLECIDA CON SERVICIOS IPS";
                            G1Fcm_codser_sips = String.Empty;
                            G1Inv_gesips_inar = "2"; // Quitar referencia a servicios IPS
                        }
                        else
                        {
                            G1Inv_gesips_inar = "2";
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G1Fcm_idesec_sips);
                            if (tmp != null)
                            {
                                G1Fcm_desser_sips = tmp.fcm_desser_sips;
                                G1Fcm_codser_sips = tmp.fcm_codser_sips;
                                G1Inv_gesips_inar = "1"; // Se activa la referencia a servicios IPS
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        */
                        break;
                        #endregion

                    case "G1Fcm_coddig_mant":
                        #region FCM_CODDIG_MANT: Código digitación servicio
                        lcrNombreCampo = "Código digitación servicio IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "S19";
                        if (String.IsNullOrWhiteSpace(G1Fcm_coddig_mant))
                        {
                            G1Fcm_coddig_mant = "NA";
                            G1Fcm_idesec_sips = "NA";
                        }
                        if (G1Fcm_coddig_mant == "NA")
                        {
                            G1Fcm_desser_sips = "REFERENCIA NO ESTABLECIDA CON SERVICIOS IPS";
                            G1Fcm_codser_sips = String.Empty;
                            G1Inv_gesips_inar = "2"; // Quitar referencia a servicios IPS
                            G1Fcm_idesec_sips = "NA";
                        }
                        else
                        {
                            G1Fcm_coddig_mant = G1Fcm_coddig_mant.ToUpper();
                            G1Inv_gesips_inar = "2";

                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(G1Fcm_coddig_mant);
                            if (tmp != null)
                            {
                                G1Fcm_desser_sips = tmp.fcm_desser_sips;
                                G1Fcm_codser_sips = tmp.fcm_codser_sips;
                                G1Inv_gesips_inar = "1"; // Se activa la referencia a servicios IPS
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_grufar_fagf":
                        #region FAR_GRUFAR_FAGF: Grupo farmaceutico
                        lcrNombreCampo = "Grupo farmaceutico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (G1Inv_tipart_inar == "2")
                        {
                            if (String.IsNullOrWhiteSpace(G1Far_grufar_fagf))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                            else
                            {
                                var tmp = FARValidarCodigo.fobRegBuscarFargrufarmacoma(G1Far_grufar_fagf);
                                if (tmp != null)
                                {
                                    G1Far_desgru_fagf = tmp.far_desgru_fagf;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_sugfar_fasg":
                        #region FAR_SUGFAR_FASG: Subgrupo farmaceutico
                        lcrNombreCampo = "Subgrupo farmaceutico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (G1Inv_tipart_inar == "2")
                        {
                            if (String.IsNullOrWhiteSpace(G1Far_sugfar_fasg))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                            else
                            {
                                var tmp = FARValidarCodigo.fobRegBuscarFargrufarmacomd(G1Far_sugfar_fasg);
                                if (tmp != null)
                                {
                                    G1Far_grufar_fagf = tmp.far_grufar_fagf;
                                    G1Far_desgru_fasg = tmp.far_desgru_fasg;
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_codgme_sigr":
                        #region SIS_CODGME_SIGR: Patrón medida
                        lcrNombreCampo = "Patrón medida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (String.IsNullOrWhiteSpace(G1Sis_codgme_sigr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisgrupomedidas(G1Sis_codgme_sigr);
                            if (tmp != null)
                            {
                                G1Sis_desgme_sigr = tmp.sis_desgme_sigr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_codume_sium":
                        #region SIS_CODUME_SIUM: Medida Almacenamiento
                        lcrNombreCampo = "Medida Almacenamiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (String.IsNullOrWhiteSpace(G1Sis_codume_sium))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisunidadmedida(G1Sis_codume_sium);
                            if (tmp != null)
                            {
                                G1Sis_desume_sium = tmp.sis_desume_sium;
                                G1Sis_codgme_sigr = tmp.sis_codgme_sigr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_codctn_intc":
                        #region INV_CODCTN_INTC: Contenedor de gestion
                        lcrNombreCampo = "Contenedor de gestion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (String.IsNullOrWhiteSpace(G1Inv_codctn_intc))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvcontenedores(G1Inv_codctn_intc);
                            if (tmp != null)
                            {
                                G1Inv_desctn_intc = tmp.inv_desctn_intc;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_valing_inar":
                        #region INV_VALING_INAR: Costo Unidad ingreso
                        lcrNombreCampo = "Costo Unidad ingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (G1Inv_valing_inar <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        fcvCalcularValorVenta();
                        break;
                        #endregion

                    case "G1Inv_uvalin_inar":
                        #region INV_UVALIN_INAR: Ultimo costo unidad ingreso
                        lcrNombreCampo = "Ultimo costo unidad ingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A25";
                        if (G1Inv_uvalin_inar <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        break;
                        #endregion

                    case "G1Inv_porive_inar":
                        #region INV_PORIVE_INAR: Porcentaje Incremento
                        lcrNombreCampo = "Porcentaje Incremento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A26";
                        fcvCalcularValorVenta();
                        break;
                        #endregion

                    case "G1Inv_valmov_inar":
                        #region INV_VALMOV_INAR: Valor Unidad Salida
                        lcrNombreCampo = "Valor Unidad Salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A27";
                        if (G1Inv_valmov_inar <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            fcvCalcularValorVenta();
                        }
                        break;
                        #endregion

                    case "G1Sis_codiva_tiva":
                        #region SIS_CODIVA_TIVA: Codigo Valor I.V.A
                        lcrNombreCampo = "Codigo Valor I.V.A";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A28";
                        if (String.IsNullOrWhiteSpace(G1Sis_codiva_tiva))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSistablaiva(G1Sis_codiva_tiva);
                            if (tmp != null)
                            {
                                G1Sis_desiva_tiva = tmp.sis_desiva_tiva;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_sistok_inar":
                        #region INV_SISTOK_INAR: Maneja stock minimo
                        lcrNombreCampo = "Maneja stock minimo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A29";
                        if (String.IsNullOrWhiteSpace(G1Inv_sistok_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Inv_sistok_inar, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            { 
                                lcrValorReturn = fcrValidarStockArticulos(lcrNombreCampo);
                            }
                        }
                        break;
                        #endregion

                    case "G1Inv_stkmin_inar":
                        #region INV_STKMIN_INAR: Stock minimo
                        lcrNombreCampo = "Stock minimo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A30";
                        if (G1Inv_sistok_inar == "1")
                        {
                            lcrValorReturn = fcrValidarStockArticulos(lcrNombreCampo);
                        }
                        break;
                        #endregion

                    case "G1Inv_stkmax_inar":
                        #region INV_STKMAX_INAR: Stock maximo
                        lcrNombreCampo = "Stock maximo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A31";
                        if (G1Inv_sistok_inar == "1")
                        {
                            lcrValorReturn = fcrValidarStockArticulos(lcrNombreCampo);
                        }
                        break;
                        #endregion

                    case "G1Inv_stkntf_inar":
                        #region INV_STKNTF_INAR: Unidades notificar stock
                        lcrNombreCampo = "Unidades notificar stock";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A32";
                        if (G1Inv_sistok_inar == "1")
                        {
                            if (G1Inv_stkntf_inar <= 0)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidarStockArticulos: Validacion rango stock articulos
        /// <summary>
        /// Validacion rango stock articulos
        /// </summary>
        public String fcrValidarStockArticulos(String tcrTituloCampo)
        {
            var lcrResultado = String.Empty;

            if (G1Inv_sistok_inar == "1")
            {
                if (G1Inv_stkmin_inar <= 0 || G1Inv_stkmax_inar <= 0)
                {
                    lcrResultado = tcrTituloCampo + ": Stock minimo y Stock maximo errados";
                }
            }
            return lcrResultado;
        }
        #endregion
        #region fnuCalcularValorVenta: Calcular valor venta articulos
        /// <summary>
        /// Calcular valor venta articulos
        /// </summary>
        public void fcvCalcularValorVenta()
        {
            if (G1Inv_porive_inar != 0)
            {
                G1Inv_valmov_inar = (int)(G1Inv_valing_inar + (G1Inv_valing_inar * G1Inv_porive_inar / 100));
            }
        }
        #endregion
    }
}
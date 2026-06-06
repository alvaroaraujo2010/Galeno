//- MARMOTA-GENCODE: VERSION 2.0 - 08/06/2015 06:15:38 AM
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
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Validacion;
using Datos.Modelos;
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admregurgencias</para>
    /// <para>DESCRIPCION:
    ///  Maestro para registro datos salida de urgencias con observación
    ///  (sea que pase a hospitalizacion o salga de la IPS)
    /// </para>
    /// </summary>
    public class VistaModeloHosEgresoUrgencias : VistaModeloHosEgresoUrgenciasBase
    {
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdFILTRO { get; set; }
        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            CmdFILTRO = new RelayCommand(fcvFiltro, CanFiltro);
        }
        #endregion
        //-------------------------------------------------
        // Region Metodos que Validan activacion de opciones
        // en gestion de datos
        //-------------------------------------------------
        #region CanFiltro
        /// <summary>
        ///Validación para saber si se permite ejecutar Filtro 
        /// </summary>
        public bool CanFiltro()
        {
            bool llgReturn = false;
            try
            {
                if (GcrSIS_FormModoPopup == "DFL" || (GlgSIS_ModoEdicion == false && GcrSIS_FormModoPopup == "EDT"))
                {
                    llgReturn = CanFIL();
                    if (GlgSIS_FormModoPopupIni == true && llgReturn == true && GcrSIS_FormModoPopup != "DFL")
                    {
                        GlgSIS_FormModoPopupIni = false;
                        Modificar();
                    }
                }
                else if (GcrSIS_FormModoPopup == "ADD")
                {
                    var lcrCodigo1 = G1Adm_secadm_rgad;
                    var lcrCodigo2 = G1Adm_secaut_aegr;
                    var lcrCodigo3 = G1Hos_codesp_espa;
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        Adicionar();
                        G1Adm_secadm_rgad = lcrCodigo1;
                        G1Hos_codesp_espa = lcrCodigo3;
                        G1Adm_secaut_aegr = lcrCodigo2;
                        fcrValidacion("G1Adm_secadm_rgad");
                        fcrValidacion("G1Hos_codesp_espa");
                        fcrValidacion("G1Adm_secaut_aegr");
                        fcvCargarVariablesDesdeAdmision();
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanFiltro");
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos que realizan la funcion
        // de gestion de datos en la tabla
        //-------------------------------------------------
        #region fcvFiltro: Filtro Auxiliar
        /// <summary>
        /// Filtro Auxiliar
        /// </summary>
        public void fcvFiltro()
        {
            Filtro();
        }
        #endregion
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
        public override string fcrValidacion(string tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
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
                    case "G1Adm_secadm_rgad":
                        #region ADM_SECADM_RGAD: Código Admisión
                        lcrNombreCampo = "Código Admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Adm_secadm_rgad))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = ADMValidarCodigo.fobRegBuscarAdmregadmision(G1Adm_secadm_rgad);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.adm_secadm_rgad))
                            {
                                G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                G1Hcl_nrohis_hicl = tmp.hcl_nrohis_hicl;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_idesec_usua":
                        #region SIA_IDESEC_USUA: Codigo unico del paciente
                        lcrNombreCampo = "Codigo unico del paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Sia_idesec_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(G1Sia_idesec_usua);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_idesec_usua))
                            {
                                //G1Hcl_nrohis_hicl = tmp.hcl_nrohis_hicl;
                                //G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                //G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipide_tide":
                        #region SIA_TIPIDE_TIDE: Tipo Identificación
                        lcrNombreCampo = "Tipo Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Sia_tipide_tide))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatipideusario(G1Sia_tipide_tide);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipide_tide))
                            {
                                G1Sia_deside_tide = tmp.sia_deside_tide;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_nroide_usua":
                        #region SIA_NROIDE_USUA: Numero de Identificación
                        lcrNombreCampo = "Numero de Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Hcl_nrohis_hicl":
                        #region HCL_NROHIS_HICL: Numero historia clinica
                        lcrNombreCampo = "Numero historia clinica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Hcl_nrohis_hicl))
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Adm_fecegr_regu":
                        #region ADM_FECEGR_REGU: Fecha de salida
                        lcrNombreCampo = "Fecha de salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Adm_fecegr_regu, "Fecha de salida");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            //calcular dias de estancia
                            lcrValorReturn = fcrValidarFechaEgreso();
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                fcvGenerarEstanciaHorasDias();
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_horegr_regu":
                        #region ADM_HOREGR_REGU: Hora de salida
                        lcrNombreCampo = "Hora de salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Adm_horegr_regu, "12", ":", "Hora de salida");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            //calcular dias de estancia
                            lcrValorReturn = fcrValidarFechaEgreso();
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                fcvGenerarEstanciaHorasDias();
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_diases_regu":
                        #region ADM_DIASES_REGU: Dias de estancia
                        lcrNombreCampo = "Dias de estancia  en observación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (G1Adm_diases_regu < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor o igual a cero";
                        }
                        else
                        {
                            if (G1Adm_diases_regu < 0 || G1Adm_diases_regu > 99)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_horase_regu":
                        #region ADM_HORASE_REGU: Horas de estancia
                        lcrNombreCampo = "Horas de estancia en observación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (G1Adm_horase_regu < 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_horase_regu < 0 || G1Adm_horase_regu > 299)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_secaut_aegr":
                        #region ADM_SECAUT_AEGR: Autorización salida
                        lcrNombreCampo = "Autorización salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Adm_secaut_aegr))
                        {
                            if (String.IsNullOrWhiteSpace(G1Hos_codesp_espa))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerida";
                            }
                        }
                        else
                        {
                            // Solo aplica autorizacion cuando no hay traslado
                            if (String.IsNullOrWhiteSpace(G1Hos_codesp_espa))
                            {
                                var tmp = ADMValidarCodigo.fobRegBuscarAdmordendsalida(G1Adm_secaut_aegr);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.adm_secaut_aegr))
                                {
                                    G1Sia_codpfa_prof = tmp.sia_codpfa_prof;
                                    G1Adm_fecegr_regu = ((DateTime)tmp.adm_fecsal_aegr).ToShortDateString();
                                    G1Adm_horegr_regu = Funciones.fcrConvierteHora(tmp.adm_horsal_aegr.ToString(), "24", gcrSeparadorDecimal, ":");
                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Hos_codesp_espa":
                        #region HOS_CODESP_ESPA: Traslado a hospitalización
                        lcrNombreCampo = "Traslado a hospitalización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (!String.IsNullOrWhiteSpace(G1Hos_codesp_espa))
                        {
                            var tmp = HOSValidarCodigo.fobRegBuscarHosestanciapaci(G1Hos_codesp_espa);
                            if (tmp != null)
                            {
                                // Fecha y hora de traslado a hospitalizacion es la de salida Urgencias
                                G1Sia_codpfa_prof = tmp.sia_codpfa_prof;
                                G1Adm_fecegr_regu = ((DateTime)tmp.hos_fecing_espa).ToShortDateString();
                                G1Adm_horegr_regu = Funciones.fcrConvierteHora(tmp.hos_horing_espa.ToString(), "24", gcrSeparadorDecimal, ":");

                                // Complementar los datos
                                G1Adm_estsal_regu = "1"; // Sale Vivo
                                G1Adm_dessal_regr = "3"; // Pasa a Hospitalizacion

                                // No hay datos de muerte
                                GlgSIS_ModoEdtFallecido = false;
                                G1Adm_tipmue_regu = String.Empty;
                                G1Sia_dixmue_tdia = String.Empty;
                                G1Adm_fecmue_regu = "  /  /";
                                G1Adm_hormue_regu = "  : :";
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            if (String.IsNullOrWhiteSpace(G1Adm_secaut_aegr))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codpfa_prof":
                        #region SIA_CODPFA_PROF: Profesional Autoriza salida
                        lcrNombreCampo = "Profesional Autoriza salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (String.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codpfa_prof))
                            {
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nompro_prof = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixsal_tdia":
                        #region SIA_DIXSAL_TDIA: Diagnostico salida
                        lcrNombreCampo = "Diagnostico salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Sia_dixsal_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixsal_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_coddia_tdia))
                            {
                                G1Sia_desdia_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixre1_tdia":
                        #region SIA_DIXRE1_TDIA: Diagnostico relacionado1
                        lcrNombreCampo = "Diagnostico relacionado1";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (!string.IsNullOrWhiteSpace(G1Sia_dixre1_tdia))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixre1_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_coddia_tdia))
                            {
                                G1Desia_dixre1_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixre2_tdia":
                        #region SIA_DIXRE2_TDIA: Diagnostico relacionado2
                        lcrNombreCampo = "Diagnostico relacionado2";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (!string.IsNullOrWhiteSpace(G1Sia_dixre2_tdia))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixre2_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_coddia_tdia))
                            {
                                G1Desia_dixre2_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixre3_tdia":
                        #region SIA_DIXRE3_TDIA: Diagnostico relacionado3
                        lcrNombreCampo = "Diagnostico relacionado3";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (!string.IsNullOrWhiteSpace(G1Sia_dixre3_tdia))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixre3_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_coddia_tdia))
                            {
                                G1Desia_dixre3_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_estsal_regu":
                        #region ADM_ESTSAL_REGU: Estado al salir
                        lcrNombreCampo = "Estado al salir";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (String.IsNullOrWhiteSpace(G1Adm_estsal_regu))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_estsal_regu, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else if (G1Adm_estsal_regu == "1")
                            { 
                                // Sale vivo, no hay datos de muerte
                                GlgSIS_ModoEdtFallecido = false;
                                G1Adm_tipmue_regu = String.Empty;
                                G1Sia_dixmue_tdia = String.Empty;
                                G1Adm_fecmue_regu = "  /  /";
                                G1Adm_hormue_regu = "";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_dessal_regr":
                        #region ADM_DESSAL_REGR: Destino al salir
                        lcrNombreCampo = "Destino al salir";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (String.IsNullOrWhiteSpace(G1Adm_dessal_regr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_dessal_regr, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_tipmue_regu":
                        #region ADM_TIPMUE_REGU: Muerte intrahospitalaria
                        lcrNombreCampo = "Muerte intrahospitalaria";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (String.IsNullOrWhiteSpace(G1Adm_tipmue_regu))
                        {
                            if (G1Adm_estsal_regu == "2")
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_tipmue_regu, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixmue_tdia":
                        #region SIA_DIXMUE_TDIA: Diagnostico de muerte
                        lcrNombreCampo = "Diagnostico de muerte";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (String.IsNullOrWhiteSpace(G1Sia_dixmue_tdia))
                        {
                            if (G1Adm_estsal_regu == "2")
                            {
                                lcrValorReturn = lcrNombreCampo + ": Es requerido";
                            }
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixmue_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_coddia_tdia))
                            {
                                G1Desia_dixmue_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_fecmue_regu":
                        #region ADM_FECMUE_REGU: Fecha muerte
                        lcrNombreCampo = "Fecha muerte";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Adm_fecmue_regu, "Fecha muerte");
                        if (G1Adm_estsal_regu == "1")
                        {
                            lcrValorReturn = String.Empty;
                        }
                        break;
                        #endregion

                    case "G1Adm_hormue_regu":
                        #region ADM_HORMUE_REGU: Hora de muerte
                        lcrNombreCampo = "Hora de muerte";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Adm_hormue_regu, "12", ":", "Hora de muerte");
                        if (G1Adm_estsal_regu == "1")
                        {
                            lcrValorReturn = String.Empty;
                        }
                        break;
                        #endregion

                    case "G1Sis_estpro_espr":
                        #region SIS_ESTPRO_ESPR: Estado Egreso
                        lcrNombreCampo = "Estado registro egreso urgencias";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (String.IsNullOrWhiteSpace(G1Sis_estpro_espr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisestadoproces(G1Sis_estpro_espr);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_estpro_espr))
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
        #region  fcvGenerarEstanciaHorasDias: Genera la estancia en horas y dias
        /// <summary>
        ///Genera los dias y horas totales de estancia (suma todos los traslados)
        /// </summary>
        private void fcvGenerarEstanciaHorasDias()
        {
            //adm_fechos_rgad,adm_horhos_rgad - ojo toca verificar los traslados y generar dias estancias

            var lobAdm = ADMValidarCodigo.fobRegBuscarAdmregadmision(G1Adm_secadm_rgad);

            DateTime ldaFechaIni = (DateTime)lobAdm.adm_fecadm_rgad;
            DateTime ldaFechaFin = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecegr_regu);

            //---------------------------------------------------
            // cargar los parametros para realizar calculos
            var m = new HosProcesos();

            m.gcrEstContNumeroContrato = lobAdm.cto_seccon_cont;
            m.gcrEstTipoAtencionMedica = "3"; // Siempre urgencias
            m.gdaEstFechaInicioLiqidacion = ldaFechaIni;
            m.gdaEstFechaFinLiqidacion = ldaFechaFin;
            m.gcrEstHoraInicialLiquidacion = Funciones.fcrConvierteHora(lobAdm.adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
            m.gcrEstHoraFinalLiquidacion = G1Adm_horegr_regu;
            m.gcrEstHoraFormatoLiquiacion = "12";
            m.gcrEstHoraSeparadorFormato = ":";

            m.fcvEstGenerarEstanciaHorasDias();

            G1Adm_diases_regu = m.gnuEstDiasEstancia;
            G1Adm_horase_regu = m.gnuEstHorasEstancia;
        }
        #endregion
        #region  fcrValidarFechaEgreso:  Validar fecha de egreso urgencias
        /// <summary>
        /// Validar fecha de egreso urgencias
        /// </summary>
        private String fcrValidarFechaEgreso()
        {
            var lcrReturn = String.Empty;

            var lobAdm = ADMValidarCodigo.fobRegBuscarAdmregadmision(G1Adm_secadm_rgad);

            if (lobAdm != null)
            {
                var lcrFechaAdm = Funciones.fcrConvertFecha((DateTime)lobAdm.adm_fecadm_rgad);
                var lcrHoraAdm  = Funciones.fcrConvierteHora(lobAdm.adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                var lcrHoraGest = G1Adm_horegr_regu;

                if (!Funciones.flgValidarRangoFechasHoras(lcrFechaAdm, G1Adm_fecegr_regu, "DMY", "/",
                                                                lcrHoraAdm, lcrHoraGest, "12", ":"))
                {
                    lcrReturn = "Fecha y Hora salida: No corresponde con fecha y hora del registro ingreso (Admitido: " +
                                             lcrFechaAdm + " - " + lcrHoraAdm + ")";
                }

            }
            return lcrReturn;
        }
        #endregion

    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 03/07/2013 08:53:02 AM
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
    /// <para>TABLA: admregistegreso</para>
    /// <para>DESCRIPCION:
    ///  Maestro para registro egresos de hospitalizacion, se diligencia
    ///  al momento de confirmada la Autorizacion de salida del paciente
    /// </para>
    /// </summary>
    public class VistaModeloRegistroSalida : VistaModeloRegistroSalidaBase
    {
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdFILTRO { get; set; }
        public RelayCommand CmdLOGERRORES { get; set; }
        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            CmdFILTRO = new RelayCommand(fcvFiltro, CanFiltro);
            CmdLOGERRORES = new RelayCommand(fcvVistaLogErrores, CanLOGERRORES);
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
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        Adicionar();
                        G1Adm_secadm_rgad = lcrCodigo1;
                        G1Adm_secaut_aegr = lcrCodigo2;
                        fcrValidacion("G1Adm_secadm_rgad");
                        fcrValidacion("G1Adm_secaut_aegr");
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
        #region CanLOGERRORES
        /// <summary>
        ///Validación para saber si se permite
        ///Activar el boton par aver el log de errores
        /// </summary>
        public virtual bool CanLOGERRORES()
        {
            bool llgReturn = false;
            try
            {
                if (tmpLogErrores.Count > 0)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanLOGERRORES");
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
        #region fcvVistaLogErrores: Mostrar la vista de errores
        /// <summary>
        /// Mostrar la vista de errores
        /// </summary>
        public void fcvVistaLogErrores()
        {
            return;
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
            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            bool llgValidDefault = false;

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Adm_secadm_rgad":
                        #region Validacion
                        lcrNombreCampo = "Código Admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (string.IsNullOrWhiteSpace(G1Adm_secadm_rgad))
                        {
                            lcrValorReturn = "Código Admisión: Es requerido";
                        }
                        else
                        {
                            EFadmregadmision tmp = new EFadmregadmision();
                            tmp = ADMValidarCodigo.fobRegBuscarAdmregadmision(G1Adm_secadm_rgad);
                            if (tmp != null)
                            {
                                G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                G1Hcl_nrohis_hicl = tmp.hcl_nrohis_hicl;
                                G1Adm_fecadm_rgad = ((DateTime)tmp.adm_fecadm_rgad).ToShortDateString();
                                G1Adm_horadm_rgad = Funciones.fcrConvierteHora(tmp.adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                                G1Sia_dixing_tdia = tmp.sia_dixing_tdia;
                                G1Sia_edaymd_usua = tmp.sia_edaymd_usua;
                                G1Sia_edapac_usua = (int)tmp.sia_edapac_usua;
                                G1Sia_codmed_tmed= tmp.sia_codmed_tmed;
                                G1Sia_edaano_usua= (int)tmp.sia_edaano_usua;
                                G1Sia_edames_usua = (int)tmp.sia_edames_usua;
                                G1Sia_edadia_usua = (int)tmp.sia_edadia_usua;
                                G1Cto_seccon_cont = tmp.cto_seccon_cont;
                                G1Adm_codtat_tatn = tmp.adm_codtat_tatn;
                                //G1Sia_codpfa_prof = tmp.sia_codpfa_prof;
                                G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                G1Sia_deseps_teps = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps).sia_deseps_teps;
                            }
                            else
                            {
                                lcrValorReturn = "Código Admisión: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_idesec_usua":
                        #region Validacion
                        lcrNombreCampo = "Codigo unico del paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (string.IsNullOrWhiteSpace(G1Sia_idesec_usua))
                        {
                            lcrValorReturn = "Codigo unico del paciente: Es requerido";
                        }
                        else
                        {
                            EFsiausuarioatend tmp = new EFsiausuarioatend();
                            tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(G1Sia_idesec_usua);
                            if (tmp != null)
                            {
                                //G1Hcl_nrohis_hicl = tmp.hcl_nrohis_hicl;
                                //G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                //G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                G1Sia_fecnac_usua = ((DateTime)tmp.sia_fecnac_usua).ToShortDateString();
                                G1Sis_codsex_sexo = tmp.sis_codsex_sexo;
                                G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                                G1Sis_codmun_muni = tmp.sis_codmun_muni;
                                G1Sis_coddep_dpto = tmp.sis_coddep_dpto;
                                G1Sis_nommun_muni = SISValidarCodigo.fobRegBuscarSistabmunicipio(tmp.sis_idemun_muni).sis_nommun_muni;
                                G1Sis_desdep_dpto = SISValidarCodigo.fobRegBuscarSistabdepartame(G1Sis_coddep_dpto).sis_desdep_dpto;
                                if (String.IsNullOrWhiteSpace(G1Sia_tipdis_tdis)) { G1Sia_tipdis_tdis = tmp.sia_tipdis_tdis; }
                            }
                            else
                            {
                                lcrValorReturn = "Codigo unico del paciente: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipide_tide":
                        #region Validacion
                        lcrNombreCampo = "Tipo Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (string.IsNullOrWhiteSpace(G1Sia_tipide_tide))
                        {
                            lcrValorReturn = "Tipo Identificación: Es requerido";
                        }
                        else
                        {
                            EFsiatipideusario tmp = new EFsiatipideusario();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatipideusario(G1Sia_tipide_tide);
                            if (tmp != null)
                            {
                                G1Sia_deside_tide = tmp.sia_deside_tide;
                            }
                            else
                            {
                                lcrValorReturn = "Tipo Identificación: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_nrohis_hicl":
                        #region Validacion
                        lcrNombreCampo = "Numero Historia clinica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (!string.IsNullOrWhiteSpace(G1Hcl_nrohis_hicl))
                        {
                        }
                        break;
                        #endregion

                    case "G1Adm_fecegr_regr":
                        #region Validacion
                        lcrNombreCampo = "Fecha de salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Adm_fecegr_regr, "Fechas de salida");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            // Validar Rango 
                            if (!Funciones.flgValidarRangoFecha(G1Adm_fecadm_rgad, G1Adm_fecegr_regr))
                            {
                                lcrValorReturn = "Fechas y hora de salida: no es valida";
                            }
                            else
                            {
                                if (!flgValidarRangoFechasHoras("1"))
                                {
                                    lcrValorReturn = "Fechas y hora de salida: no corresponde con fecha y hora de admisión";
                                }
                                else if (String.IsNullOrWhiteSpace(Funciones.fcrValidaHoraTexto(true, G1Adm_horegr_regr, "12", ":", "Hora de salida")))
                                {
                                    //calcular dias de estancia
                                    fcvGenerarEstanciaHorasDias();
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_horegr_regr":
                        #region Validacion
                        lcrNombreCampo = "Hora de salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Adm_horegr_regr, "12", ":", "Hora de salida");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (!flgValidarRangoFechasHoras("1"))
                            {
                                lcrValorReturn = "Hora de salida: Rango horas no valido";
                            }
                            else
                            {
                                //calcular dias de estancia
                                fcvGenerarEstanciaHorasDias();
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_secaut_aegr":
                        #region Validacion
                        lcrNombreCampo = "Autorización salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (!string.IsNullOrWhiteSpace(G1Adm_secaut_aegr))
                        {
                            var tmp = ADMValidarCodigo.fobRegBuscarAdmordendsalida(G1Adm_secaut_aegr);
                            if (tmp != null)
                            {
                                G1Adm_secadm_rgad = tmp.adm_secadm_rgad; 
                                G1Adm_fecegr_regr = ((DateTime)tmp.adm_fecsal_aegr).ToShortDateString();
                                G1Adm_horegr_regr = Funciones.fcrConvierteHora(tmp.adm_horsal_aegr.ToString(), "24", gcrSeparadorDecimal, ":");
                                G1Sia_codpfa_prof = tmp.sia_codpfa_prof;
                                G1Adm_observ_regr = String.IsNullOrWhiteSpace(G1Adm_observ_regr) ? tmp.adm_observ_aegr.Trim() : G1Adm_observ_regr;
                            }
                            else
                            {
                                lcrValorReturn = "Numero autorización salida: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codpfa_prof":
                        #region Validacion
                        lcrNombreCampo = "Código Profesional autoriza";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (string.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
                        {
                            lcrValorReturn = "Código Profesional autoriza: Es requerido";
                        }
                        else
                        {
                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                            if (tmp != null)
                            {
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nompro_prof = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = "Código Profesional Autoriza: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixing_tdia":
                        #region Validacion
                        lcrNombreCampo = "Diagnostico Ingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (string.IsNullOrWhiteSpace(G1Sia_dixing_tdia))
                        {
                            lcrValorReturn = "Diagnostico Ingreso: Es requerido";
                        }
                        else
                        {
                            EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                            tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixing_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                            {
                                G1Desia_dixing_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = "Diagnostico Ingreso: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixsal_tdia":
                        #region Validacion
                        lcrNombreCampo = "Diagnostico salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (string.IsNullOrWhiteSpace(G1Sia_dixsal_tdia))
                        {
                            lcrValorReturn = "Diagnostico salida: Es requerido";
                        }
                        else
                        {
                            EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                            tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixsal_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                            {
                                G1Sia_desdia_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = "Diagnostico salida: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipdxp_tdix":
                        #region Validacion
                        lcrNombreCampo = "Tipo diagnostico principal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Sia_tipdxp_tdix))
                        {
                            lcrValorReturn = "Tipo diagnostico principal: Es requerido";
                        }
                        else
                        {
                            EFsiatipodiagprin tmp = new EFsiatipodiagprin();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatipodiagprin(G1Sia_tipdxp_tdix);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdxp_tdix))
                            {
                                G1Sia_desdxp_tdix = tmp.sia_desdxp_tdix;
                            }
                            else
                            {
                                lcrValorReturn = "Tipo diagnostico principal: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixre1_tdia":
                        #region Validacion
                        lcrNombreCampo = "Diagnostico relacionado 1";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (!string.IsNullOrWhiteSpace(G1Sia_dixre1_tdia))
                        {
                            EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                            tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixre1_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                            {
                                G1Desia_dixre1_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = "Diagnostico relacionado 1: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixre2_tdia":
                        #region Validacion
                        lcrNombreCampo = "Diagnostico relacionado 2";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (!string.IsNullOrWhiteSpace(G1Sia_dixre2_tdia))
                        {
                            EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                            tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixre2_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                            {
                                G1Desia_dixre2_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = "Diagnostico relacionado 2: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixre3_tdia":
                        #region Validacion
                        lcrNombreCampo = "Diagnostico relacionado 3";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (!string.IsNullOrWhiteSpace(G1Sia_dixre3_tdia))
                        {
                            EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                            tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixre3_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                            {
                                G1Desia_dixre3_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = "Diagnostico relacionado3: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixcom_tdia":
                        #region Validacion
                        lcrNombreCampo = "Diagnostico complicación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (!string.IsNullOrWhiteSpace(G1Sia_dixcom_tdia))
                        {
                            EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                            tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixcom_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                            {
                                G1Desia_dixcom_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = "Diagnostico complicación: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_estsal_regr":
                        #region Validacion
                        lcrNombreCampo = "Estado al salir";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (string.IsNullOrWhiteSpace(G1Adm_estsal_regr))
                        {
                            lcrValorReturn = "Estado al salir: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_estsal_regr, ",", "1,2"))
                            {
                                lcrValorReturn = "Estado al salir: Dato no es valido";
                            }
                            else if (G1Adm_estsal_regr=="1")
                            {
                                G1Adm_tipmue_regr = "4";
                                G1Sia_dixmue_tdia = String.Empty;
                                G1Adm_fecmue_regr = String.Empty;
                                G1Adm_hormue_regr = String.Empty;
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_dessal_regr":
                        #region Validacion
                        lcrNombreCampo = "Destino al salir";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (string.IsNullOrWhiteSpace(G1Adm_dessal_regr))
                        {
                            lcrValorReturn = "Destino al salir: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_dessal_regr, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Destino al salir: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipdis_tdis":
                        #region Validacion
                        lcrNombreCampo = "Discapacidad postenfermedad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (string.IsNullOrWhiteSpace(G1Sia_tipdis_tdis))
                        {
                            lcrValorReturn = "Discapacidad postenfermedad: Es requerido";
                        }
                        else
                        {
                            EFsiatipdiscapaci tmp = new EFsiatipdiscapaci();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatipdiscapaci(G1Sia_tipdis_tdis);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdis_tdis))
                            {
                                G1Sia_desdis_tdis = tmp.sia_desdis_tdis;
                            }
                            else
                            {
                                G1Sia_desdis_tdis = String.Empty;
                                lcrValorReturn = "Discapacidad postenfermedad: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_tipmue_regr":
                        #region Validacion
                        lcrNombreCampo = "Muerte intrahospitalaria";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (!string.IsNullOrWhiteSpace(G1Adm_tipmue_regr))
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_tipmue_regr, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = "Muerte intrahospitalaria: Dato no es valido";
                            }
                            else 
                            {
                                if ((G1Adm_estsal_regr == "1" && G1Adm_tipmue_regr != "4") || 
                                    (G1Adm_estsal_regr == "2" && G1Adm_tipmue_regr == "4"))
                                {
                                    lcrValorReturn = "Muerte intrahospitalaria: Dato no corresponde con el <<Estado al salir>>";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixmue_tdia":
                        #region Validacion
                        lcrNombreCampo = "Diagnostico de muerte";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (!string.IsNullOrWhiteSpace(G1Sia_dixmue_tdia))
                        {
                            EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                            tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixmue_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                            {
                                G1Desia_dixmue_tdia = tmp.sia_desdia_tdia;
                                lcrValorReturn = SiaValidarDatos.fcrPertinenciaDiagnostico(G1Sia_dixing_tdia, G1Sia_edadia_usua, "3",
                                                                                          G1Sis_codsex_sexo, "//", "Diagnostico de muerte");
                            }
                            else
                            {
                                lcrValorReturn = "Diagnostico de muerte: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_fecmue_regr":
                        #region Validacion
                        lcrNombreCampo = "Fecha de muerte paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (G1Adm_estsal_regr == "2")
                        {
                            lcrValorReturn = Funciones.fcrValidaFechaTexto(false, "DMY", "/", G1Adm_fecmue_regr, "Fecha de muerte paciente");
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                if (!Funciones.flgValidarRangoFecha(G1Adm_fecadm_rgad, G1Adm_fecmue_regr))
                                {
                                    lcrValorReturn = "Fecha de muerte paciente: no corresponde con fecha de admisión";
                                }
                                else if (!Funciones.flgValidarRangoFecha(G1Adm_fecmue_regr, G1Adm_fecegr_regr))
                                {
                                    lcrValorReturn = "Fecha de muerte paciente: no corresponde con fecha de egreso";
                                }else if (!flgValidarRangoFechasHoras("2"))
                                {
                                    lcrValorReturn = "Fecha de muerte paciente y hora muerte: no corresponde con fecha y hora de admisión";
                                }
                                else if (!flgValidarRangoFechasHoras("5"))
                                {
                                    lcrValorReturn = "Fecha de muerte paciente y hora muerte: no corresponde con fecha y hora de salida";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_hormue_regr":
                        #region Validacion
                        lcrNombreCampo = "Hora de muerte";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(false, G1Adm_hormue_regr, "12", ":", "Hora de muerte");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            lcrValorReturn = fcrValidacionRel("G1Adm_fecmue_regr");
                        }
                        break;
                        #endregion

                    case "G1Adm_diases_regr":
                        #region Validacion
                        lcrNombreCampo = "Dias de estancia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (G1Adm_diases_regr > 0)
                        {
                            if (G1Adm_diases_regr < 0 || G1Adm_diases_regr > 9999)
                            {
                                lcrValorReturn = "Dias de estancia: Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_horase_regr":
                        #region Validacion
                        lcrNombreCampo = "Horas de estancia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (G1Adm_horase_regr > 0)
                        {
                            if (G1Adm_horase_regr < 0 || G1Adm_horase_regr > 9999)
                            {
                                lcrValorReturn = "Horas de estancia: Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_aparto_regr":
                        #region Validacion
                        lcrNombreCampo = "Atención del parto (SI/NO)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A25";
                        if (String.IsNullOrWhiteSpace(G1Adm_aparto_regr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": se debe registrar dato";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_aparto_regr, ",", "1,2"))
                            {
                                lcrValorReturn = "Atención del parto (SI/NO/NO APLICA): Dato no es valido";
                            }
                            else
                            {
                                if (G1Adm_aparto_regr == "2" || G1Adm_aparto_regr == "3")
                                {
                                    G1Adm_tippar_regr = "3";
                                    G1Adm_actpar_regr = "3";
                                    G1Adm_semges_regr = 0;
                                    G1Adm_fecpar_regr = String.Empty;
                                    G1Adm_contrl_regr = "3";
                                }
                                else
                                {
                                    //----------------------------------------
                                    // Validacion Adicionar recien nacido
                                    //----------------------------------------
                                    #region Validación: Registro de recien nacido
                                    if (G1Adm_aparto_regr == "1" && TmpG2ListaBrow.Count == 0)
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": se debe registrar al menos un registro de recien nacido";
                                    }
                                    #endregion
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_tippar_regr":
                        #region Validacion
                        lcrNombreCampo = "Parto o Aborto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A26";
                        if (G1Adm_aparto_regr == "1")
                        {
                            if (!string.IsNullOrWhiteSpace(G1Adm_tippar_regr))
                            {
                                if (!Funciones.flgExisteElemento(G1Adm_tippar_regr, ",", "1,2"))
                                {
                                    lcrValorReturn = "Parto o Aborto: Dato no es valido";
                                }
                            }
                        }
                        else
                        {
                            G1Adm_tippar_regr = "3";
                        }
                        break;
                        #endregion

                    case "G1Adm_actpar_regr":
                        #region Validacion
                        lcrNombreCampo = "Tipo asistencia parto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A27";
                        if (G1Adm_aparto_regr == "1")
                        {
                            if (!string.IsNullOrWhiteSpace(G1Adm_actpar_regr))
                            {
                                if (!Funciones.flgExisteElemento(G1Adm_actpar_regr, ",", "1,2"))
                                {
                                    lcrValorReturn = "Tipo asistencia parto: Dato no es valido";
                                }
                            }
                        }
                        else
                        {
                            G1Adm_actpar_regr = "3";
                        }
                        break;
                        #endregion

                    case "G1Adm_semges_regr":
                        #region Validacion
                        lcrNombreCampo = "Semanas de gestación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A28";
                        if (G1Adm_aparto_regr == "1")
                        {
                            if (G1Adm_semges_regr > 0)
                            {
                                if (G1Adm_semges_regr <= 0 || G1Adm_semges_regr > 48)
                                {
                                    lcrValorReturn = "Semanas de gestación: Valor fuera del rango";
                                }
                            }
                        }
                        else
                        {
                            G1Adm_semges_regr = 0;
                        }
                        break;
                        #endregion

                    case "G1Adm_fecpar_regr":
                        #region Validacion
                        lcrNombreCampo = "Fecha atencion del parto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A29";
                        if (G1Adm_aparto_regr == "1")
                        {
                            lcrValorReturn = Funciones.fcrValidaFechaTexto(false, "DMY", "/", G1Adm_fecpar_regr, "Fecha de parto");
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                if (!Funciones.flgValidarRangoFecha(G1Adm_fecadm_rgad, G1Adm_fecpar_regr))
                                {
                                    lcrValorReturn = "Fecha atencion del parto: no corresponde con fecha de admisión";
                                }
                                else if (!Funciones.flgValidarRangoFecha(G1Adm_fecpar_regr, G1Adm_fecegr_regr))
                                {
                                    lcrValorReturn = "Fecha atencion del parto: no corresponde con fecha de egreso";
                                }
                            }
                        }
                        else
                        {
                            G1Adm_fecpar_regr = "01/01/0001";
                        }
                        break;
                        #endregion

                    case "G1Adm_contrl_regr":
                        #region Validacion
                        lcrNombreCampo = "Control prenatal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A30";
                        if (G1Adm_aparto_regr == "1")
                        {
                            if (String.IsNullOrWhiteSpace(G1Adm_contrl_regr))
                            {
                                lcrValorReturn = "Control prenatal: Dato es requerido";
                            }
                            else if (!Funciones.flgExisteElemento(G1Adm_contrl_regr, ",", "1,2"))
                            {
                                lcrValorReturn = "Control prenatal: Dato no es valido";
                            }
                        }
                        else
                        {
                            G1Adm_contrl_regr = "3";
                        }
                        break;
                        #endregion

                    case "G1Adm_observ_regr":
                        #region Validacion
                        lcrNombreCampo = "Observacion salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A31";
                        if (String.IsNullOrWhiteSpace(G1Adm_observ_regr))
                        {
                            lcrValorReturn = "Observacion salida: Dato es requerido";
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

                    //----------------------------------------
                    // Validacion Adicionar recien nacido
                    //----------------------------------------
                    #region Validación: Registro de recien nacido
                    var lcrExNombreCampo = "Registro de recien nacido";
                    var lcrExValorReturn = String.Empty;
                    var lcrExCodigoError = "B30";
                    if (G1Adm_aparto_regr == "1" && TmpG2ListaBrow.Count == 0)
                    {
                        lcrExValorReturn = "Registro de recien nacido: se debe registrar al menos un registro de recien nacido";
                    }
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrExCodigoError,
                                                lcrExNombreCampo, lcrExValorReturn, lcrNivelError, lcrImgNivelError);
                    #endregion
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
        public override string fcrValidacionRel(string tcrNombrePropiedad)
        {

            String lcrValorReturn = String.Empty;
            String lcrNumeroRegistro = "USUARIO";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";
            if (GlgSIS_ModoEdtNacimiento == false) { return lcrValorReturn; }

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Adm_fecnac_regn":
                        #region Validacion
                        lcrNombreCampo = "Fecha nacimiento del recien nacido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B32";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G2Adm_fecnac_regn, "Fecha nacimiento del recien nacido");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            // Validar Rango 
                            if (!Funciones.flgValidarRangoFecha(G1Adm_fecadm_rgad, G2Adm_fecnac_regn))
                            {
                                lcrValorReturn = "Fecha nacimiento del recien nacido: no es valida";
                            }
                            else
                            {
                                if (!flgValidarRangoFechasHoras("3"))
                                {
                                    lcrValorReturn = "Fecha nacimiento del recien nacido y hora nacimiento: no corresponde con fecha y hora de admisión";
                                }
                                else if (!flgValidarRangoFechasHoras("4"))
                                {
                                    lcrValorReturn = "Fecha nacimiento del recien nacido y  hora nacimiento: no corresponde con fecha y hora de salida";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Sis_codsex_sexo":
                        #region Validacion
                        lcrNombreCampo = "Sexo del recien nacido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B33";
                        if (string.IsNullOrWhiteSpace(G2Sis_codsex_sexo))
                        {
                            lcrValorReturn = "Sexo del recien nacido: Es requerido";
                        }
                        else
                        {
                            G2Sis_codsex_sexo = G2Sis_codsex_sexo.ToUpper();
                            EFsistablasexos tmp = new EFsistablasexos();
                            tmp = SISValidarCodigo.fobRegBuscarSistablasexos(G2Sis_codsex_sexo);
                            if (tmp != null)
                            {
                                G2Sis_dessex_sexo = tmp.sis_dessex_sexo;
                            }
                            else
                            {
                                lcrValorReturn = "Sexo: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Adm_hornac_regn":
                        #region Validacion
                        lcrNombreCampo = "Hora nacimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B34";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G2Adm_hornac_regn, "12", ":", "Hora nacimiento");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            lcrValorReturn = fcrValidacionRel("G2Adm_fecnac_regn");
                        }
                        break;
                        #endregion

                    case "G2Adm_peson_regn":
                        #region Validacion
                        lcrNombreCampo = "Peso al nacer (gr)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B35";
                        if (G2Adm_peson_regn <= 0)
                        {
                            lcrValorReturn = "Peso al nacer (gr): Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G2Adm_peson_regn < 200 || G2Adm_peson_regn > 18000)
                            {
                                lcrValorReturn = "Peso al nacer (gr): Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G2Adm_tallan_regn":
                        #region Validacion
                        lcrNombreCampo = "Talla al nacer (cm)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B36";
                        if (G2Adm_tallan_regn <= 0)
                        {
                            lcrValorReturn = "Talla al nacer (cm): Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G2Adm_tallan_regn < 0 || G2Adm_tallan_regn > 60)
                            {
                                lcrValorReturn = "Talla al nacer (cm): Valor fuera del rango";
                            }
                        }
                        break;
                        #endregion

                    case "G2Sia_dixnac_tdia":
                        #region Validacion
                        lcrNombreCampo = "Diagnostico nacimiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B37";
                        if (string.IsNullOrWhiteSpace(G2Sia_dixnac_tdia))
                        {
                            lcrValorReturn = "Diagnostico nacimiento: Es requerido";
                        }
                        else
                        {
                            EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                            tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G2Sia_dixnac_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                            {
                                G2Sia_desdia_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = "Diagnostico nacimiento: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Adm_estnac_regn":
                        #region Validacion
                        lcrNombreCampo = "Estado al nacer";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B38";
                        if (string.IsNullOrWhiteSpace(G2Adm_estnac_regn))
                        {
                            lcrValorReturn = "Estado al nacer: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Adm_estnac_regn, ",", "1,2"))
                            {
                                lcrValorReturn = "Estado al nacer: Dato no es valido";
                            }
                            else 
                            {
                                if (G2Adm_estnac_regn == "1")
                                {
                                    G2Adm_tipmue_regn = String.Empty;
                                    G2Sia_dixmue_tdia = String.Empty;
                                    G2Adm_fecmue_regn = String.Empty;
                                    G2Adm_hormue_regn = String.Empty;
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Adm_tipmue_regn":
                        #region Validacion
                        lcrNombreCampo = "Muerte postnatal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B39";
                        if (G2Adm_estnac_regn == "2")
                        {
                            if (!string.IsNullOrWhiteSpace(G2Adm_tipmue_regn))
                            {
                                if (!Funciones.flgExisteElemento(G2Adm_tipmue_regn, ",", "1,2"))
                                {
                                    lcrValorReturn = "Muerte postnatal: Dato no es valido";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Sia_dixmue_tdia":
                        #region Validacion
                        lcrNombreCampo = "Diagnostico de muerte";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B40";
                        if (G2Adm_estnac_regn == "2")
                        {
                            if (!string.IsNullOrWhiteSpace(G2Sia_dixmue_tdia))
                            {
                                EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                                tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G2Sia_dixmue_tdia);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                                {
                                    G2Desia_dixmue_tdia = tmp.sia_desdia_tdia;
                                }
                                else
                                {
                                    lcrValorReturn = "Diagnostico de muerte: No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Adm_fecmue_regn":
                        #region Validacion
                        lcrNombreCampo = "Fecha muerte recien nacido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B41";
                        if (G2Adm_estnac_regn == "2")
                        {
                            lcrValorReturn = Funciones.fcrValidaFechaTexto(false, "DMY", "/", G2Adm_fecmue_regn, "Fecha muerte recien nacido");
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                if (!Funciones.flgValidarRangoFecha(G1Adm_fecadm_rgad, G2Adm_fecmue_regn))
                                {
                                    lcrValorReturn = "Fecha de muerte recien nacido: no corresponde con fecha de admisión";
                                }
                                else if (!Funciones.flgValidarRangoFecha(G2Adm_fecmue_regn, G1Adm_fecegr_regr))
                                {
                                    lcrValorReturn = "Fecha de muerte recien nacido: no corresponde con fecha de egreso";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Adm_hormue_regn":
                        #region Validacion
                        lcrNombreCampo = "Hora de muerte";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B42";
                        if (G2Adm_estnac_regn == "2")
                        {
                            lcrValorReturn = Funciones.fcrValidaHoraTexto(false, G2Adm_hormue_regn, "12", ":", "Hora de muerte");
                        }
                        break;
                        #endregion

                }
                lcrValorReturn = G1Adm_aparto_regr == "1" ? lcrValorReturn : String.Empty;

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
        //-------------------------------------------------
        // FUNCIONES VARIAS
        //-------------------------------------------------
        #region  flgValidarRangoFechasHoras: Validar rango fechas y horas
        private bool flgValidarRangoFechasHoras(String tcrTipo)
        {
            var llgValor = false;
            switch (tcrTipo)
            {
                case "1": // Fecha Admision y fecha salida
                    llgValor = Funciones.flgValidarRangoFechasHoras(G1Adm_fecadm_rgad, G1Adm_fecegr_regr, "DMY", "/", 
                                                                    G1Adm_horadm_rgad, G1Adm_horegr_regr, "12", ":");
                    break;

                case "2": // Fecha Admision y fecha muerte paciente
                    llgValor = Funciones.flgValidarRangoFechasHoras(G1Adm_fecadm_rgad, G1Adm_fecmue_regr, "DMY", "/", 
                                                                    G1Adm_horadm_rgad, G1Adm_hormue_regr, "12", ":");
                    break;

                case "3": // Fecha Admision y Fecha nacimiento recien nacido
                    llgValor = Funciones.flgValidarRangoFechasHoras(G1Adm_fecadm_rgad, G2Adm_fecnac_regn, "DMY", "/",
                                                                    G1Adm_horadm_rgad, G2Adm_hornac_regn, "12", ":");
                    break;

                case "4": // Fecha nacimiento recien nacido y fecha y hora de salida
                    llgValor = Funciones.flgValidarRangoFechasHoras(G2Adm_fecnac_regn, G1Adm_fecegr_regr, "DMY", "/",
                                                                    G2Adm_hornac_regn, G1Adm_horegr_regr, "12", ":");
                    break;

                case "5": // fecha muerte paciente y fecha salida
                    llgValor = Funciones.flgValidarRangoFechasHoras(G1Adm_fecmue_regr, G1Adm_fecegr_regr, "DMY", "/",
                                                                    G1Adm_hormue_regr, G1Adm_horegr_regr, "12", ":");

                    break;

                case "8": // fecha atencion parto y fecha nacimiento recien nacido

                    break;

                case "9": // fecha muerte paciente y fecha salida

                    break;
            }
            return llgValor;
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
            DateTime ldaFechaFin = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecegr_regr); 

            //---------------------------------------------------
            // cargar los parametros para realizar calculos
            var m = new HosProcesos();

            m.gcrEstContNumeroContrato      = G1Cto_seccon_cont;
            m.gcrEstTipoAtencionMedica      = G1Adm_codtat_tatn;
            m.gdaEstFechaInicioLiqidacion   = ldaFechaIni;
            m.gdaEstFechaFinLiqidacion      = ldaFechaFin;
            m.gcrEstHoraInicialLiquidacion  = Funciones.fcrConvierteHora(lobAdm.adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
            m.gcrEstHoraFinalLiquidacion    = G1Adm_horegr_regr;
            m.gcrEstHoraFormatoLiquiacion   = "12";
            m.gcrEstHoraSeparadorFormato    = ":";

            m.fcvEstGenerarEstanciaHorasDias();

            G1Adm_diases_regr = m.gnuEstDiasEstancia;
            G1Adm_horase_regr = m.gnuEstHorasEstancia;
        }
        #endregion
        #region  fcvGenerarEstanciaHorasDias: Genera la estancia en horas y dias BAK
        private void fcvGenerarEstanciaHorasDiasXXX()
        {
            var lcrValorReturn = String.Empty;
            int lnuEstanciaUrgencia = 0, lnuEstanciaHospit = 0;
            DateTime ldaFechaIni, ldaFechaFin;
            //---------------------------------------------------
            DateTime.TryParse(G1Adm_fecadm_rgad, out ldaFechaIni);
            DateTime.TryParse(G1Adm_fecegr_regr, out ldaFechaFin);
            //---------------------------------------------------
            G1Adm_horase_regr = Funciones.fnuFechasCalHorasMinutos(ldaFechaIni, ldaFechaFin, G1Adm_horadm_rgad, G1Adm_horegr_regr, "12", ":", "H");
            G1Adm_diases_regr = (int)(G1Adm_horase_regr / 24);
            G1Adm_diases_regr = G1Adm_diases_regr * 24 != G1Adm_horase_regr ? G1Adm_diases_regr + 1 : G1Adm_diases_regr;
            // Verificar segun el contrato para cobro dias de estancia
            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cto_nrocon_cont))
            {
                lnuEstanciaUrgencia = (int)tmp.cto_gestur_cont;
                lnuEstanciaHospit = (int)tmp.cto_gestho_cont;
            }
            // Generar dias de estancia en hospitalizacion 
            if (G1Adm_codtat_tatn == "2")
            {
                G1Adm_diases_regr = lnuEstanciaHospit > G1Adm_horase_regr ? 0 : G1Adm_diases_regr;
            }
            // Generar dias de estancia en Urgencias 
            if (G1Adm_codtat_tatn == "3")
            {
                G1Adm_diases_regr = lnuEstanciaUrgencia > G1Adm_horase_regr ? 0 : G1Adm_diases_regr;
            }
        }
        #endregion
    }
}
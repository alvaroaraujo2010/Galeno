//- MARMOTA-GENCODE: VERSION 2.0 - 01/08/2013 05:34:08 AM
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
using Hospitalizacion.Utilidades;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admordendsalida</para>
    /// <para>DESCRIPCION:
    ///  Autorización de egreso a pacientes que se encuentran admitidos
    ///  por hospitalización o urgencias, estas autorizaciones las hacen
    ///  los profesionales (Médicos enfermeras y otros profesionales
    ///  de salud)
    /// </para>
    /// </summary>
    public class VistaModeloAutorizarEgreso : VistaModeloAutorizarEgresoBase
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
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        Adicionar();
                        G1Adm_secadm_rgad = lcrCodigo1;
                        G1Adm_estreg_aegr = "1";
                        G1Adm_fecsol_aegr = DateTime.Today.ToShortDateString();
                        G1Adm_fecsal_aegr = DateTime.Today.ToShortDateString();
                        // Codigo del profesional
                        EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                        tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsaludUs(GcrUsuIdUsuario);
                        if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nompro_prof))
                        {
                            G1Sia_nompro_prof = tmp.sia_nompro_prof;
                            G1Sia_codpfa_prof = tmp.sia_codpfa_prof;
                        }
                        fcrValidacion("G1Adm_secadm_rgad");
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

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Adm_secadm_rgad":
                        lcrNombreCampo = "Código Admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (string.IsNullOrWhiteSpace(G1Adm_secadm_rgad))
                        {
                            lcrValorReturn = "Código Admisión: Es requerido";
                        }
                        else
                        {
                            var tmp = ADMValidarCodigo.fobRegBuscarAdmregadmision(G1Adm_secadm_rgad);
                            if (tmp != null)
                            {
                                G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                G1Adm_fecadm_rgad = ((DateTime)tmp.adm_fecadm_rgad).ToShortDateString();
                                G1Sia_edaymd_usua = tmp.sia_edaymd_usua;
                                G1Adm_horadm_rgad = Funciones.fcrConvierteHora(tmp.adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                                //G1Sia_codpfa_prof = tmp.sia_codpfa_prof;
                            }
                            else
                            {
                                lcrValorReturn = "Código Admisión: No existe";
                            }
                        }
                        break;

                    case "G1Sia_idesec_usua":
                        lcrNombreCampo = "Código único del paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (string.IsNullOrWhiteSpace(G1Sia_idesec_usua))
                        {
                            lcrValorReturn = "Código único del paciente: Es requerido";
                        }
                        else
                        {
                            EFsiausuarioatend tmp = new EFsiausuarioatend();
                            tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(G1Sia_idesec_usua);
                            if (tmp != null)
                            {
                                //G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                //G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                G1Sia_fecnac_usua = ((DateTime)tmp.sia_fecnac_usua).ToShortDateString();
                                G1Sis_codsex_sexo = tmp.sis_codsex_sexo;
                                G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                                //G1Sia_edaymd_usua = tmp.sia_edaymd_usua;
                            }
                            else
                            {
                                lcrValorReturn = "Código único del paciente: No existe";
                            }
                        }
                        break;

                    case "G1Sia_tipide_tide":
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

                    case "G1Sia_nroide_usua":
                        lcrNombreCampo = "Numero de Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (string.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                        {
                            lcrValorReturn = "Numero de Identificación: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Adm_fecsol_aegr":
                        lcrNombreCampo = "Fecha solicitud";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Adm_fecsol_aegr, "Fecha solicitud");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (!Funciones.flgValidarRangoFecha(G1Adm_fecsol_aegr, G1Adm_fecsal_aegr))
                            {
                                lcrValorReturn = "Rango Fechas solicitud y de salida no valido";
                            }
                            if (!AdmFunciones.flgValidarRangoHorasAdmision(G1Adm_fecadm_rgad, G1Adm_fecsol_aegr, "DMY", "/", G1Adm_horadm_rgad, G1Adm_horsal_aegr, "12", ":"))
                            {
                                lcrValorReturn = "Fechas admisión, hora y fecha solicitud no valido";
                            }
                        }
                        break;
                        
                    case "G1Adm_fecsal_aegr":
                        lcrNombreCampo = "Fecha salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Adm_fecsal_aegr, "Fecha salida");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (!Funciones.flgValidarRangoFecha(G1Adm_fecsol_aegr, G1Adm_fecsal_aegr))
                            {
                                lcrValorReturn = "Rango Fechas solicitud y de salida no valido";
                            }
                            // Validar Rango 
                            if (!AdmFunciones.flgValidarRangoHorasAdmision(G1Adm_fecadm_rgad, G1Adm_fecsal_aegr, "DMY", "/", G1Adm_horadm_rgad, G1Adm_horsal_aegr, "12", ":"))
                            {
                                lcrValorReturn = "Fechas admisión, hora y fecha salida no valido";
                            }
                            else 
                            {
                                lcrValorReturn = fcrValidarGestionEpicrisis();
                            }
                        }
                        break;

                    case "G1Adm_horsal_aegr":
                        lcrNombreCampo = "Hora de salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Adm_horsal_aegr, "12", ":", "Hora de salida");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            // Validar Rango 
                            if (!AdmFunciones.flgValidarRangoHorasAdmision(G1Adm_fecadm_rgad, G1Adm_fecsal_aegr, "DMY", "/", G1Adm_horadm_rgad, G1Adm_horsal_aegr, "12", ":"))
                            {
                                lcrValorReturn = "Fechas Admisión, hora y fecha salida no valido";
                            }
                            else
                            {
                                lcrValorReturn = fcrValidarGestionEpicrisis();
                            }
                           
                        }
                        break;

                    case "G1Sia_codpfa_prof":
                        lcrNombreCampo = "Profesional que autoriza";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (string.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
                        {
                            lcrValorReturn = "Profesional Autoriza: Es requerido";
                        }
                        else
                        {
                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                            if (tmp != null)
                            {
                                G1Sia_nompro_prof = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = "Profesional que Autoriza: No existe";
                            }
                        }
                        break;

                    case "G1Adm_observ_aegr":
                        lcrNombreCampo = "Observación de la autorización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (!string.IsNullOrWhiteSpace(G1Adm_observ_aegr))
                        {
                            G1Adm_observ_aegr = G1Adm_observ_aegr.ToUpper();
                        }
                        break;

                    case "G1Adm_estreg_aegr":
                        if (string.IsNullOrWhiteSpace(G1Adm_estreg_aegr))
                        {
                            lcrValorReturn = "Estado orden: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_estreg_aegr, ",", "1,2"))
                            {
                                lcrValorReturn = "Estado orden: Dato no es valido";
                            }
                        }
                        break;

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
        #region fcrValidarGestionEpicrisis: Mostrar la vista de errores
        /// <summary>
        /// Validar si la epicrisis es obligatoria y esta diligenciada
        /// </summary>
        public String fcrValidarGestionEpicrisis()
        {
            var lcrError = String.Empty;
            var lnuHorasEstancia = 0;

            // Registro de Epicrisis  HCL-CAPTURA-EPIC
            var lobRegEpiCris = HCLValidarCodigo.fobRegBuscarHclregiseventosAdm(G1Adm_secadm_rgad, "HCL-CAPTURA-EPIC", "DESEN");

            // Registro configuracion Modulo Hospitalizacion
            var lobRegConfig = HOSValidarCodigo.fobRegBuscarHosconfigmodulo("01");

            if (lobRegConfig.hos_epicri_hoxx == "2" || lobRegConfig.hos_epicri_hoxx == "3")
            {
                // Verificar si hay las horas minimas para exigir la epicrisis
                if (lobRegConfig.hos_epicri_hoxx == "3")
                {
                    lnuHorasEstancia = fnuGenerarEstanciaHorasDias();
                    if (lobRegEpiCris == null && lnuHorasEstancia >= lobRegConfig.hos_epicrh_hoxx)
                    {
                        lcrError = "Registro de Epiciris es requerida segun horas minimas de estancia (" + lnuHorasEstancia.ToString().Trim() + ")";
                    }
                    else
                    {
                        if (lobRegEpiCris != null)
                        {
                            lcrError = lobRegEpiCris.sis_estpro_espr == "1" ? "Registro Epiciris debe estar en estado confirmado" : "";
                        }
                    }
                }
            }
            return lcrError;
        }
        #endregion
        #region  fcvGenerarEstanciaHorasDias: Genera la estancia en horas y dias
        /// <summary>
        ///Genera los dias y horas totales de estancia
        /// </summary>
        private int fnuGenerarEstanciaHorasDias()
        {
            var lnuHoras = 0;
                            
            DateTime ldaFechaIni = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecadm_rgad);
            DateTime ldaFechaFin = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecsal_aegr);

            lnuHoras = Funciones.fnuFechasCalHorasMinutos(ldaFechaIni, ldaFechaFin, G1Adm_horadm_rgad, 
                                                              G1Adm_horsal_aegr,"12", gcrSeparadorDecimal, "H");
            return lnuHoras;
        }
        #endregion

    }
}
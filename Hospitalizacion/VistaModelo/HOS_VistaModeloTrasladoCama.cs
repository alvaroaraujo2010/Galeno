//- MARMOTA-GENCODE: VERSION 2.0 - 11/06/2015 04:44:13 PM
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
using Datos.Modelos;
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admregadmision</para>
    /// <para>DESCRIPCION:
    ///  Tabla del modulo de facturación médica (fcm) - Registrar todas
    ///  las admisiones de pacientes en la institución IPS;
    /// </para>
    /// </summary>
    public class VistaModeloTrasladoCama : VistaModeloTrasladoCamaBase
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
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        Adicionar();
                        G1Adm_secadm_rgad = lcrCodigo1;
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
            bool llgValidDefault = false;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
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
        public override string fcrValidacionRel(string tcrNombrePropiedad)
        {
            String lcrValorReturn = string.Empty;
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
                    case "G2Hos_tipesp_espa":
                        #region HOS_TIPESP_ESPA: Tipo traslado
                        lcrNombreCampo = "Tipo traslado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B01";
                        if (String.IsNullOrWhiteSpace(G2Hos_tipesp_espa))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Hos_tipesp_espa, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hos_codant_caho":
                        #region HOS_CODANT_CAHO: Cama anterior
                        lcrNombreCampo = "Cama actual";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B02";
                        if (String.IsNullOrWhiteSpace(G2Hos_codant_caho))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = HOSValidarCodigo.fobRegBuscarHoscamasareas(G2Hos_codant_caho);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hos_codcam_caho))
                            {
                                G2Dehos_codant_caho = tmp.hos_descam_caho;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hos_codcam_caho":
                        #region HOS_CODCAM_CAHO: Cama actual
                        lcrNombreCampo = "nueva Cama donde ingresa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B03";
                        if (String.IsNullOrWhiteSpace(G2Hos_codcam_caho))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerida";
                        }
                        else
                        {
                            var tmp = HOSValidarCodigo.fobRegBuscarHoscamasareas(G2Hos_codcam_caho);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hos_codcam_caho))
                            {
                                G2Hos_descam_caho = tmp.hos_descam_caho;
                                TmpG1RegActivo.Hos_codcam_caho = G2Hos_codcam_caho;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hos_fecing_espa":
                        #region HOS_FECING_ESPA: Fecha ingreso
                        lcrNombreCampo = "Fecha ingreso a nueva cama";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G2Hos_fecing_espa, "Fecha ingreso");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (!Funciones.flgValidarRangoFechasHoras(G1Adm_fecadm_rgad, G2Hos_fecing_espa, "DMY", "/",
                                                                      G1Adm_horadm_rgad, G2Hos_horing_espa, "12", ":"))
                            {
                                lcrValorReturn = lcrNombreCampo + "/hora:  No concuerda con fecha y hora admisión";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hos_horing_espa":
                        #region HOS_HORING_ESPA: Hora ingreso
                        lcrNombreCampo = "Hora ingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G2Hos_horing_espa, "12", ":", "Hora ingreso");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (!Funciones.flgValidarRangoFechasHoras(G1Adm_fecadm_rgad, G2Hos_fecing_espa, "DMY", "/",
                                                                            G1Adm_horadm_rgad, G2Hos_horing_espa, "12", ":"))
                            {
                                lcrValorReturn = lcrNombreCampo + "/hora:  No concuerda con fecha y hora admisión";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hos_fecsal_espa":
                        #region HOS_FECSAL_ESPA: Fecha salida
                        lcrNombreCampo = "Fecha salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        var lcrValorRetur1 = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G2Hos_fecsal_espa, "Fecha salida");
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(false, "DMY", "/", G2Hos_fecsal_espa, "Fecha salida");

                        // hay una supesta fecha de salida 
                        if (String.IsNullOrWhiteSpace(lcrValorRetur1) && G2Hos_fecsal_espa != "01/01/1000")
                        {
                            if (!Funciones.flgValidarRangoFechasHoras(G2Hos_fecing_espa, G2Hos_fecsal_espa, "DMY", "/",
                                                                      G2Hos_horing_espa, G2Hos_horsal_espa, "12", ":"))
                            {
                                lcrValorReturn = lcrNombreCampo + "/hora:  No concuerda con fecha y hora ingreso cama";
                            }
                        }
                        break;
                        #endregion

                    case "G2Hos_horsal_espa":
                        #region HOS_HORSAL_ESPA: Hora salida
                        lcrNombreCampo = "Hora salida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(false, G2Hos_horsal_espa, "12", ":", "Hora salida");
                        break;
                        #endregion

                    case "G2Sia_codpfa_prof":
                        #region SIA_CODPFA_PROF: Profesional que autoriza
                        lcrNombreCampo = "Profesional que autoriza";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B08";
                        if (String.IsNullOrWhiteSpace(G2Sia_codpfa_prof))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G2Sia_codpfa_prof);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codpfa_prof))
                            {
                                G2Sia_nompro_prof = tmp.sia_nompro_prof;
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
    }
}
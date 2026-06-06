//- MARMOTA-GENCODE: VERSION 2.0 - 23/08/2015 08:52:10 PM
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
using FacturacionMedica.Modelo;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: fcmcuentacobrms</para>
    /// <para>DESCRIPCION:
    ///  Maestro para realizar la clasificacion de facturas para cuentras
    ///  de cobro a las EPS
    /// </para>
    /// </summary>
    public class VistaModeloCuentaCobro : VistaModeloCuentaCobroBase
    {
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdFILTRO { get; set; }
        public RelayCommand CmdADDFAC { get; set; }

        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            CmdFILTRO = new RelayCommand(fcvFiltro, CanFiltro);
            CmdADDFAC = new RelayCommand(Default, CanAddFactura);	
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
                    var lcrCodigo1 = G1Fcm_secreg_mfcb;
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        Adicionar();
                        G1Fcm_secreg_mfcb = lcrCodigo1;
                        fcrValidacion("G1Fcm_secreg_mfcb");
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
        #region CanAddFactura
        /// <summary>
        ///Activar el boton add facturas a la grilla
        /// </summary>
        public bool CanAddFactura()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    llgReturn = llgSiContrato && llgSiFechaIni && llgSiFechaFin ? true : false;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanAddFactura");
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
                    case "G1Fcm_fecfac_mfac":
                        #region FCM_FECFAC_MFAC: Fecha factura
                        lcrNombreCampo = "Fecha factura";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Fcm_fecfac_mfac, "Fecha factura");
                        break;
                        #endregion

                    case "G1Sia_fecini_mfcb":
                        #region SIA_FECINI_MFCB: Fecha inicio periodo
                        lcrNombreCampo = "Fecha inicio periodo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Sia_fecini_mfcb, "Fecha inicio periodo");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Sia_fecfin_mfcb, lcrNombreCampo)))
                            {
                                if (!Funciones.flgValidarRangoFecha(G1Sia_fecini_mfcb, G1Sia_fecfin_mfcb))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": debe ser menor o igual a la fecha fin del periodo";
                                }
                            }
                        }
                        llgSiFechaIni = String.IsNullOrWhiteSpace(lcrValorReturn) ? true : false;
                        break;
                        #endregion

                    case "G1Sia_fecfin_mfcb":
                        #region SIA_FECFIN_MFCB: Fecha fin periodo
                        lcrNombreCampo = "Fecha fin periodo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Sia_fecfin_mfcb, "Fecha fin periodo");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn))
                        {
                            if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Sia_fecini_mfcb, lcrNombreCampo)))
                            {
                                if (!Funciones.flgValidarRangoFecha(G1Sia_fecini_mfcb, G1Sia_fecfin_mfcb))
                                {
                                    lcrValorReturn = lcrNombreCampo + ": debe ser mayor o igual a la fecha inicial del periodo";
                                }
                            }
                        }
                        llgSiFechaFin = String.IsNullOrWhiteSpace(lcrValorReturn) ? true : false;
                        break;
                        #endregion

                    case "G1Fcm_descue_mfcb":
                        #region FCM_DESCUE_MFCB: Descripción
                        lcrNombreCampo = "Descripción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Fcm_descue_mfcb))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Fcm_descue_mfcb, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-. "))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene Caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_firmar_mfcb":
                        #region FCM_FIRMAR_MFCB: Firma responsable
                        lcrNombreCampo = "Firma responsable";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Fcm_firmar_mfcb))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Cto_seccon_cont":
                        #region CTO_SECCON_CONT: Secuencial de Contrato
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Cto_seccon_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cto_seccon_cont))
                            {
                                G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                G1Sia_codeps_teps = String.IsNullOrWhiteSpace(G1Sia_codeps_teps) ? tmp.sia_codeps_teps : G1Sia_codeps_teps;
                                G1Sis_idterc_sitr = tmp.sis_idterc_sitr;
                                G1Cto_descon_cont = tmp.cto_descon_cont;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        llgSiContrato = String.IsNullOrWhiteSpace(lcrValorReturn) ? true : false;
                        break;
                        #endregion

                    case "G1Sia_codeps_teps":
                        #region SIA_CODEPS_TEPS: Código EPS
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (!string.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codeps_teps))
                            {
                                G1Sia_deseps_teps = tmp.sia_deseps_teps;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        else
                        {
                            G1Sia_deseps_teps = String.Empty;
                        }
                        break;
                        #endregion

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
    }
}
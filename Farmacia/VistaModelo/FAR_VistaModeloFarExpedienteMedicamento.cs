//- MARMOTA-GENCODE: VERSION 2.0 - 14/11/2017 10:56:06 AM
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
using Farmacia.Modelo;

namespace Farmacia.VistaModelo
{
    /// <summary>
    /// <para>TABLA: farexpedmedicma</para>
    /// <para>DESCRIPCION:
    ///  Maestro expediente medicamentos INVIMA con registro Codigo
    ///  Expediente codigo ATC (principio activo) y laboratorios
    /// </para>
    /// </summary>
    public class VistaModeloFarExpedienteMedicamento : VistaModeloFarExpedienteMedicamentoBase
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
            bool llgValidDefault = false;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Far_expedi_fama":
                        #region FAR_EXPEDI_FAMA: Expediente invima
                        lcrNombreCampo = "Expediente invima";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (String.IsNullOrWhiteSpace(G1Far_expedi_fama))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (GlgSIS_ModoAdicion == true && FARValidarCodigo.flgBuscarFarexpedmedicma(G1Far_expedi_fama))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_desexp_fama":
                        #region FAR_DESEXP_FAMA: Descripcion producto
                        lcrNombreCampo = "Descripcion producto";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Far_desexp_fama))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Far_codatc_fatc":
                        #region FAR_CODATC_FATC: Codigo ATC
                        lcrNombreCampo = "Codigo ATC";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Far_codatc_fatc))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FARValidarCodigo.fobRegBuscarFarmaeclasifatc(G1Far_codatc_fatc);
                            if (tmp != null)
                            {
                                G1Far_desatc_fatc = tmp.far_desatc_fatc;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_grufar_fagf":
                        #region FAR_GRUFAR_FAGF: Grupo farmacologico
                        lcrNombreCampo = "Grupo farmacologico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
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
                        break;
                        #endregion

                    case "G1Far_sugfar_fasg":
                        #region FAR_SUGFAR_FASG: Subgrupo farmacologico
                        lcrNombreCampo = "Subgrupo farmacologico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
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
                        break;
                        #endregion

                    case "G1Far_unimed_faum":
                        #region FAR_UNIMED_FAUM: Codigo Unidad medida
                        lcrNombreCampo = "Codigo Unidad medida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Far_unimed_faum))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FARValidarCodigo.fobRegBuscarFarunidadmedida(G1Far_unimed_faum);
                            if (tmp != null)
                            {
                                G1Far_desmed_faum = tmp.far_desmed_faum;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_viaadm_fava":
                        #region FAR_VIAADM_FAVA: Via administracion
                        lcrNombreCampo = "Via administracion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Far_viaadm_fava))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FARValidarCodigo.fobRegBuscarFarmedicamviadm(G1Far_viaadm_fava);
                            if (tmp != null)
                            {
                                G1Far_desvia_fava = tmp.far_desvia_fava;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_invima_fama":
                        #region FAR_INVIMA_FAMA: Registro sanitario INVIMA
                        lcrNombreCampo = "Registro sanitario INVIMA";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (String.IsNullOrWhiteSpace(G1Far_invima_fama))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FARValidarCodigo.fobRegBuscarFarexpedmedicma(G1Far_invima_fama);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.far_expedi_fama))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G1Far_expedi_fama != tmp.far_expedi_fama) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_fecexp_fama":
                        #region FAR_FECEXP_FAMA: Fecha registro INVIMA
                        lcrNombreCampo = "Fecha registro INVIMA";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Far_fecexp_fama, "Fecha registro INVIMA");
                        break;
                        #endregion

                    case "G1Far_fecven_fama":
                        #region FAR_FECVEN_FAMA: Fecha vencimiento registro
                        lcrNombreCampo = "Fecha vencimiento registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Far_fecven_fama, "Fecha vencimiento registro");
                        break;
                        #endregion

                    case "G1Far_codlab_falb":
                        #region FAR_CODLAB_FALB: laboratorio fabricante
                        lcrNombreCampo = "laboratorio fabricante";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Far_codlab_falb))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FARValidarCodigo.fobRegBuscarFarlaboratorios(G1Far_codlab_falb);
                            if (tmp != null)
                            {
                                G1Far_deslab_falb = tmp.far_deslab_falb;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_comerc_falb":
                        #region FAR_COMERC_FALB: Codigo del Comerciante
                        lcrNombreCampo = "Codigo del Comerciante";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (String.IsNullOrWhiteSpace(G1Far_comerc_falb))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FARValidarCodigo.fobRegBuscarFarlaboratorios(G1Far_comerc_falb);
                            if (tmp != null)
                            {
                                G1Far_codlab_falb = tmp.far_codlab_falb;
                                G1Far_deslab_falb = tmp.far_deslab_falb;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_tiprol_fama":
                        #region FAR_TIPROL_FAMA: Tipo rol comerciente
                        lcrNombreCampo = "Tipo rol comerciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Far_tiprol_fama))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Far_tiprol_fama, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_modcom_famc":
                        #region FAR_MODCOM_FAMC: Modalidad comercial
                        lcrNombreCampo = "Modalidad comercial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (String.IsNullOrWhiteSpace(G1Far_modcom_famc))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FARValidarCodigo.fobRegBuscarFarmodalicomerc(G1Far_modcom_famc);
                            if (tmp != null)
                            {
                                G1Far_desmod_famc = tmp.far_desmod_famc;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_forfar_fama":
                        #region FAR_FORFAR_FAMA: Forma Farmaceutica
                        lcrNombreCampo = "Forma Farmaceutica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (String.IsNullOrWhiteSpace(G1Far_forfar_fama))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Far_concen_fama":
                        #region FAR_CONCEN_FAMA: Concentracion medicamento
                        lcrNombreCampo = "Concentracion medicamento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (String.IsNullOrWhiteSpace(G1Far_concen_fama))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Far_unimed_fama":
                        #region FAR_UNIMED_FAMA: Unidad de medida
                        lcrNombreCampo = "Unidad de medida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (String.IsNullOrWhiteSpace(G1Far_unimed_fama))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Far_estreg_fama":
                        #region FAR_ESTREG_FAMA: Estado Registro
                        lcrNombreCampo = "Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (String.IsNullOrWhiteSpace(G1Far_estreg_fama))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Far_estreg_fama, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
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
                    case "G2Far_concum_famd":
                        #region FAR_CONCUM_FAMD: Consecutivo presentacion
                        lcrNombreCampo = "Consecutivo presentacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B03";
                        if (G2Far_concum_famd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Far_codcum_famd":
                        #region FAR_CODCUM_FAMD: Código CUM
                        lcrNombreCampo = "Código CUM";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";
                        if (String.IsNullOrWhiteSpace(G2Far_codcum_famd))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FARValidarCodigo.fobRegBuscarFarexpedmedicmd(G2Far_codcum_famd);
                            if (tmp != null)
                            {
                                if (!String.IsNullOrWhiteSpace(tmp.far_secreg_famd))
                                {
                                    if (GlgSIS_ModoAdicion == true) // en modo adicion
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                    }
                                    else
                                    {
                                        if (G2Far_secreg_famd != tmp.far_secreg_famd) // en modo edicion existe para otro registro
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G2Far_cancum_famd":
                        #region FAR_CANCUM_FAMD: Cantidad de unidades
                        lcrNombreCampo = "Cantidad de unidades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        if (G2Far_cancum_famd <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Far_precom_famd":
                        #region FAR_PRECOM_FAMD: Descripcion presentacion
                        lcrNombreCampo = "Descripcion presentacion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (String.IsNullOrWhiteSpace(G2Far_precom_famd))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Far_secimg_faim":
                        #region FAR_SECIMG_FAIM: Código imagen JPG PNG
                        lcrNombreCampo = "Código imagen JPG PNG";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        if (String.IsNullOrWhiteSpace(G2Far_secimg_faim))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FARValidarCodigo.fobRegBuscarFarmedicamimage(G2Far_secimg_faim);
                            if (tmp != null)
                            {
                                G2Far_codcum_famd = tmp.far_codcum_famd;
                                G2Far_nomimg_faim = tmp.far_nomimg_faim;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Far_fecact_famd":
                        #region FAR_FECACT_FAMD: Fecha activación
                        lcrNombreCampo = "Fecha activación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B08";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G2Far_fecact_famd, "Fecha activación");
                        break;
                        #endregion

                    case "G2Far_fecina_famd":
                        #region FAR_FECINA_FAMD: Fecha inactivación
                        lcrNombreCampo = "Fecha inactivación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B09";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G2Far_fecina_famd, "Fecha inactivación");
                        break;
                        #endregion

                    case "G2Far_estreg_famd":
                        #region FAR_ESTREG_FAMD: Estado Registro
                        lcrNombreCampo = "Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B10";
                        if (String.IsNullOrWhiteSpace(G2Far_estreg_famd))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Far_estreg_famd, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
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
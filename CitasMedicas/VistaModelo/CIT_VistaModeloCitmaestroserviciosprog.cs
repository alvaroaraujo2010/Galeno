//- MARMOTA-GENCODE: VERSION 2.0 - 06/05/2013 09:53:41 PM
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
using CitasMedicas.Modelo;

namespace CitasMedicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: citservicioprog</para>
    /// <para>DESCRIPCION:
    ///  Lista de servicios que se manejan a través de programación
    ///  o citas medicas en la IPS tales como: Cirugías, consulta externa,
    ///  PyP, Laboratorios, Citas odontológicas y otros ejm: S001 =
    ///  Consulta externa S003=Consulta Control pyp Adulto joven
    /// </para>
    /// </summary>
    public class VistaModeloCitmaestroserviciosprog : VistaModeloCitmaestroserviciosprogBase
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
                    case "G1Cit_desspr_spro":
                        lcrNombreCampo = "Nombre servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (string.IsNullOrWhiteSpace(G1Cit_desspr_spro))
                        {
                            lcrValorReturn = "Nombre servicio: Es requerido";
                        }
                        else
                        {
                            G1Cit_desspr_spro = G1Cit_desspr_spro.ToUpper();
                        }
                        break;

                    case "G1Cit_indspr_spro":
                        lcrNombreCampo = "Tipo Pacientes";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (string.IsNullOrWhiteSpace(G1Cit_indspr_spro))
                        {
                            lcrValorReturn = "Tipo Pacientes: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cit_indspr_spro, ",", "1,2"))
                            {
                                lcrValorReturn = "Tipo Pacientes: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Cit_nropas_spro":
                        lcrNombreCampo = "Total pacientes";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (G1Cit_nropas_spro <= 0)
                        {
                            lcrValorReturn = "Total pacientes: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Cit_nropas_spro < 1 || G1Cit_nropas_spro > 250)
                            {
                                lcrValorReturn = "Total pacientes: Valor fuera del rango";
                            }
                        }
                        break;

                    case "G1Cit_indmed_spro":
                        lcrNombreCampo = "Indicación medica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (string.IsNullOrWhiteSpace(G1Cit_indmed_spro))
                        {
                            lcrValorReturn = "Indicación medica: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Cit_indmed_spro))
                            {
                                lcrValorReturn = "Indicación medica: Contiene Caracteres no validos";
                            }
                        }
                        break;

                    case "G1Cit_hordur_spro":
                        lcrNombreCampo = "Minutos Duración cita";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (G1Cit_hordur_spro <= 0)
                        {
                            lcrValorReturn = "Minutos Duración cita: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Cit_hordur_spro < 5 || G1Cit_hordur_spro > 250)
                            {
                                lcrValorReturn = "Minutos Duración cita: Valor fuera del rango";
                            }
                        }
                        break;

                    case "G1Sia_codesp_esme":
                        lcrNombreCampo = "Código especialidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (string.IsNullOrWhiteSpace(G1Sia_codesp_esme))
                        {
                            lcrValorReturn = "Código especialidad: Es requerido";
                        }
                        else
                        {
                            EFsiaespecialimed tmp = new EFsiaespecialimed();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaespecialimed(G1Sia_codesp_esme);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codesp_esme))
                            {
                                G1Sia_desesp_esme = tmp.sia_desesp_esme;
                            }
                            else
                            {
                                lcrValorReturn = "Código especialidad: No existe";
                            }
                        }
                        break;

                    case "G1Fcm_idesec_sips":
                        lcrNombreCampo = "Código servicio IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (string.IsNullOrWhiteSpace(G1Fcm_idesec_sips))
                        {
                            lcrValorReturn = "Código servicio IPS: Es requerido";
                        }
                        else
                        {
                            EFfcmmanservicips tmp = new EFfcmmanservicips();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G1Fcm_idesec_sips);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_idesec_sips))
                            {
                                G1Fcm_desser_sips = tmp.fcm_desser_sips;
                            }
                            else
                            {
                                lcrValorReturn = "Código servicio IPS: No existe";
                            }
                        }
                        break;

                    case "G1Adm_codtat_tatn":
                        lcrNombreCampo = "Ambito Atención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (string.IsNullOrWhiteSpace(G1Adm_codtat_tatn))
                        {
                            lcrValorReturn = "Ambito Atención: Es requerido";
                        }
                        else
                        {
                            EFadmtipoatencion tmp = new EFadmtipoatencion();
                            tmp = ADMValidarCodigo.fobRegBuscarAdmtipoatencion(G1Adm_codtat_tatn);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.adm_codtat_tatn))
                            {
                                G1Adm_destat_tatn = tmp.adm_destat_tatn;
                            }
                            else
                            {
                                lcrValorReturn = "Ambito Atención: No existe";
                            }
                        }
                        break;

                    case "G1Fcm_codcpr_cpro":
                        lcrNombreCampo = "Código centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (string.IsNullOrWhiteSpace(G1Fcm_codcpr_cpro))
                        {
                            lcrValorReturn = "Código centro producción: Es requerido";
                        }
                        else
                        {
                            EFfcmcenproduccio tmp = new EFfcmcenproduccio();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(G1Fcm_codcpr_cpro);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codcpr_cpro))
                            {
                                G1Fcm_descpr_cpro = tmp.fcm_descpr_cpro;
                            }
                            else
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        break;

                    case "G1Fcm_tiprfa_mfac":
                        #region FCM_TIPRFA_MFAC: Tipo registro factuación
                        lcrNombreCampo = "Tipo registro factuación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (String.IsNullOrWhiteSpace(G1Fcm_tiprfa_mfac))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Fcm_tiprfa_mfac, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_estreg_esrg":
                        lcrNombreCampo = "Estado programa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (string.IsNullOrWhiteSpace(G1Sis_estreg_esrg))
                        {
                            lcrValorReturn = "Estado programa: Es requerido";
                        }
                        else
                        {
                            EFsisestadoregist tmp = new EFsisestadoregist();
                            tmp = SISValidarCodigo.fobRegBuscarSisestadoregist(G1Sis_estreg_esrg);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_estreg_esrg))
                            {
                                G1Sis_desest_esrg = tmp.sis_desest_esrg;
                            }
                            else
                            {
                                lcrValorReturn = "Estado programa: No existe";
                            }
                        }
                        break;

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
                    case "G2Fcm_idesec_sips":
                        lcrNombreCampo = "Código servicio IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B03";
                        if (string.IsNullOrWhiteSpace(G2Fcm_idesec_sips))
                        {
                            lcrValorReturn = "Código servicio IPS: Es requerido";
                        }
                        else
                        {
                            EFfcmmanservicips tmp = new EFfcmmanservicips();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G2Fcm_idesec_sips);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_idesec_sips))
                            {
                                G2Fcm_coddig_mant = tmp.fcm_coddig_mant;
                                G2Fcm_desser_sips = tmp.fcm_desser_sips;
                                G2Sia_tipact_tsac = tmp.sia_tipact_tsac;
                            }
                            else
                            {
                                lcrValorReturn = "Código servicio IPS: No existe";
                            }
                        }
                        break;

                    case "G2Fcm_coddig_mant":
                        lcrNombreCampo = "Código digitación servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B04";
                        if (string.IsNullOrWhiteSpace(G2Fcm_coddig_mant))
                        {
                            lcrValorReturn = "Código digitación servicio: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G2Sia_tipact_tsac":
                        lcrNombreCampo = "Tipo Asistencial o PyP";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B05";
                        if (string.IsNullOrWhiteSpace(G2Sia_tipact_tsac))
                        {
                            lcrValorReturn = "Tipo Asistencial o PyP: Es requerido";
                        }
                        else
                        {
                            EFsiatipactividad tmp = new EFsiatipactividad();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatipactividad(G2Sia_tipact_tsac);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_tipact_tsac))
                            {
                                G2Sia_desact_tsac = tmp.sia_desact_tsac;
                            }
                            else
                            {
                                lcrValorReturn = "Tipo Asistencial o PyP: No existe";
                            }
                        }
                        break;

                    case "G2Fcm_codcpr_cpro":                   
                        lcrNombreCampo = "Código centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (String.IsNullOrWhiteSpace(G2Fcm_codcpr_cpro))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(G2Fcm_codcpr_cpro);
                            if (tmp != null)
                            {
                                G2Fcm_descpr_cpro = tmp.fcm_descpr_cpro;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;                    

                    case "G2Fcm_totuni_dfac":
                        lcrNombreCampo = "Total unidades";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B06";
                        if (G2Fcm_totuni_dfac <= 0)
                        {
                            lcrValorReturn = "Total unidades: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G2Fcm_totuni_dfac < 1 || G2Fcm_totuni_dfac > 50)
                            {
                                lcrValorReturn = "Total unidades: Valor fuera del rango";
                            }
                        }
                        break;

                    case "G2Cit_incrme_sprt":
                        lcrNombreCampo = "Incluir en receta medica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B07";
                        if (string.IsNullOrWhiteSpace(G2Cit_incrme_sprt))
                        {
                            lcrValorReturn = "Incluir en receta medica: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Cit_incrme_sprt, ",", "1,2"))
                            {
                                lcrValorReturn = "Incluir en receta medica: Dato no es valido";
                            }
                        }
                        break;

                    case "G2Cit_incfac_sprt":
                        lcrNombreCampo = "Incluir en facturación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B08";
                        if (string.IsNullOrWhiteSpace(G2Cit_incfac_sprt))
                        {
                            lcrValorReturn = "Incluir en facturación: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Cit_incfac_sprt, ",", "1,2"))
                            {
                                lcrValorReturn = "Incluir en facturación: Dato no es valido";
                            }
                        }
                        break;

                    case "G2Cit_incfrm_sprt":
                        lcrNombreCampo = "Entrega en farmacia";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B09";
                        if (string.IsNullOrWhiteSpace(G2Cit_incfrm_sprt))
                        {
                            lcrValorReturn = "Entrega en farmacia: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Cit_incfrm_sprt, ",", "1,2"))
                            {
                                lcrValorReturn = "Entrega en farmacia: Dato no es valido";
                            }
                        }
                        break;

                    case "G2Hcl_codreg_hcca":
                        lcrNombreCampo = "Registro actividad clinica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B10";
                        if (string.IsNullOrWhiteSpace(G2Hcl_codreg_hcca))
                        {
                            lcrValorReturn = "Registro actividad clinica: Es requerido";
                        }
                        else
                        {
                            EFhcltiporegactiv tmp = new EFhcltiporegactiv();
                            tmp = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(G2Hcl_codreg_hcca);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hcl_codreg_hcca))
                            {
                                G2Hcl_desreg_hcca = tmp.hcl_desreg_hcca;
                            }
                            else
                            {
                                lcrValorReturn = "Registro actividad clinica: No existe";
                            }
                        }
                        break;

                    case "G2Sis_estreg_esrg":
                        lcrNombreCampo = "Estado servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B11";
                        if (string.IsNullOrWhiteSpace(G2Sis_estreg_esrg))
                        {
                            lcrValorReturn = "Estado servicio: Es requerido";
                        }
                        else
                        {
                            EFsisestadoregist tmp = new EFsisestadoregist();
                            tmp = SISValidarCodigo.fobRegBuscarSisestadoregist(G2Sis_estreg_esrg);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_estreg_esrg))
                            {
                                G2Sis_desest_esrg = tmp.sis_desest_esrg;
                            }
                            else
                            {
                                lcrValorReturn = "Estado servicio: No existe";
                            }
                        }
                        break;

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
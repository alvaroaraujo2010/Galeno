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
    public class VistaModeloInvmaestroserviciosprog : VistaModeloInvmaestroserviciosprogBase
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
            string lcrValorReturn = string.Empty;

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Cit_desspr_spro":
                        if (string.IsNullOrWhiteSpace(G1Cit_desspr_spro))
                        {
                            lcrValorReturn = "Nombre servicio: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgSoloTexto("AN", G1Cit_desspr_spro))
                            {
                                lcrValorReturn = "Nombre servicio: Contiene Caracteres no validos";
                            }
                        }
                        break;

                    case "G1Cit_indspr_spro":
                        if (string.IsNullOrWhiteSpace(G1Cit_indspr_spro))
                        {
                            lcrValorReturn = "Individual o Grupal: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cit_indspr_spro, ",", "1,2"))
                            {
                                lcrValorReturn = "Individual o Grupal: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Cit_nropas_spro":
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
                        if (string.IsNullOrWhiteSpace(G1Sia_codesp_esme))
                        {
                            lcrValorReturn = "Código especialidad: Es requerido";
                        }
                        else
                        {
                            EFsiaespecialimed tmp = new EFsiaespecialimed();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaespecialimed(G1Sia_codesp_esme);
                            if (tmp != null)
                            {
                                G1Sia_desesp_esme = tmp.sia_desesp_esme;
                                G1Sis_estreg_esrg = tmp.sis_estreg_esrg;
                            }
                            if (string.IsNullOrWhiteSpace(G1Sia_desesp_esme))
                            {
                                lcrValorReturn = "Código especialidad: No existe";
                            }
                        }
                        break;

                    case "G1Fcm_idesec_sips":
                        if (string.IsNullOrWhiteSpace(G1Fcm_idesec_sips))
                        {
                            lcrValorReturn = "Código servicio IPS: Es requerido";
                        }
                        else
                        {
                            EFfcmmanservicips tmp = new EFfcmmanservicips();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G1Fcm_idesec_sips);
                            if (tmp != null)
                            {
                                G1Fcm_desser_sips = tmp.fcm_desser_sips;
                            }
                            if (string.IsNullOrWhiteSpace(G1Fcm_desser_sips))
                            {
                                lcrValorReturn = "Código servicio IPS: No existe";
                            }
                        }
                        break;

                    case "G1Adm_codtat_tatn":
                        if (string.IsNullOrWhiteSpace(G1Adm_codtat_tatn))
                        {
                            lcrValorReturn = "Ambito Atención: Es requerido";
                        }
                        else
                        {
                            EFadmtipoatencion tmp = new EFadmtipoatencion();
                            tmp = ADMValidarCodigo.fobRegBuscarAdmtipoatencion(G1Adm_codtat_tatn);
                            if (tmp != null)
                            {
                                G1Adm_destat_tatn = tmp.adm_destat_tatn;
                            }
                            if (string.IsNullOrWhiteSpace(G1Adm_destat_tatn))
                            {
                                lcrValorReturn = "Ambito Atención: No existe";
                            }
                        }
                        break;

                    case "G1Fcm_codcpr_cpro":
                        if (string.IsNullOrWhiteSpace(G1Fcm_codcpr_cpro))
                        {
                            lcrValorReturn = "Código centro producción: Es requerido";
                        }
                        else
                        {
                            EFfcmcenproduccio tmp = new EFfcmcenproduccio();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(G1Fcm_codcpr_cpro);
                            if (tmp != null)
                            {
                                G1Fcm_descpr_cpro = tmp.fcm_descpr_cpro;
                                G1Sis_estreg_esrg = tmp.sis_estreg_esrg;
                            }
                            if (string.IsNullOrWhiteSpace(G1Fcm_descpr_cpro))
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        break;

                    case "G1Sis_estreg_esrg":
                        if (string.IsNullOrWhiteSpace(G1Sis_estreg_esrg))
                        {
                            lcrValorReturn = "Estado programa: Es requerido";
                        }
                        else
                        {
                            EFsisestadoregist tmp = new EFsisestadoregist();
                            tmp = SISValidarCodigo.fobRegBuscarSisestadoregist(G1Sis_estreg_esrg);
                            if (tmp != null)
                            {
                                G1Sis_desest_esrg = tmp.sis_desest_esrg;
                            }
                            if (string.IsNullOrWhiteSpace(G1Sis_desest_esrg))
                            {
                                lcrValorReturn = "Estado programa: No existe";
                            }
                        }
                        break;

                    default:
                        lcrValorReturn = fcrValidacionRel(tcrNombrePropiedad);
                        break;
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
            string lcrValorReturn = string.Empty;

            //lcrValorReturn=base.fcrValidacionRel(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Fcm_idesec_sips":
                        if (string.IsNullOrWhiteSpace(G2Fcm_idesec_sips))
                        {
                            lcrValorReturn = "Código servicio IPS: Es requerido";
                        }
                        else
                        {
                            EFfcmmanservicips tmp = new EFfcmmanservicips();
                            tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G2Fcm_idesec_sips);
                            if (tmp != null)
                            {
                                G2Fcm_desser_sips = tmp.fcm_desser_sips;
                                G2Fcm_tipact_sips = tmp.fcm_tipact_sips;
                            }
                            if (string.IsNullOrWhiteSpace(G2Fcm_desser_sips))
                            {
                                lcrValorReturn = "Código servicio IPS: No existe";
                            }
                        }
                        break;

                    case "G2Fcm_tipact_sips":
                        if (string.IsNullOrWhiteSpace(G2Fcm_tipact_sips))
                        {
                            lcrValorReturn = "Tipo Asistencial o PyP: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Fcm_tipact_sips, ",", "1,2"))
                            {
                                lcrValorReturn = "Tipo Asistencial o PyP: Dato no es valido";
                            }
                        }
                        break;

                    case "G2Fcm_totuni_dfac":
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

                    case "G2Sis_estreg_esrg":
                        if (string.IsNullOrWhiteSpace(G2Sis_estreg_esrg))
                        {
                            lcrValorReturn = "Estado servicio: Es requerido";
                        }
                        else
                        {
                            EFsisestadoregist tmp = new EFsisestadoregist();
                            tmp = SISValidarCodigo.fobRegBuscarSisestadoregist(G2Sis_estreg_esrg);
                            if (tmp != null)
                            {
                                G2Sis_desest_esrg = tmp.sis_desest_esrg;
                            }
                            if (string.IsNullOrWhiteSpace(G2Sis_desest_esrg))
                            {
                                lcrValorReturn = "Estado servicio: No existe";
                            }
                        }
                        break;

                }
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
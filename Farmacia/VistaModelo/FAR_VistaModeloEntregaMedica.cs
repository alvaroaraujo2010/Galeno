//- MARMOTA-GENCODE: VERSION 2.0 - 13/11/2017 05:46:59 PM
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
    /// <para>TABLA: farmovmedicamma</para>
    /// <para>DESCRIPCION:
    ///  Maestro para registro movimientos entrega desde Almacen/Farmacia,
    ///  de los medicamentos dados en Planes de manejo interno/consumo
    ///  y externo (ordenes servicios y/o formulas receta medicas)
    /// </para>
    /// </summary>
    public class VistaModeloEntregaMedica : VistaModeloEntregaMedicaBase
    {
        public EFinvalmacexisten tmpExisten = null;
        public int gnuTotalUnidExisten = 0;
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
                    case "G1Hcl_nroreg_hcms":
                        #region HCL_NROREG_HCMS: Num.Solicitud medica
                        lcrNombreCampo = "Num.Solicitud medica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Hcl_nroreg_hcms))
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = HCLValidarCodigo.fobRegBuscarHclregordeserms(G1Hcl_nroreg_hcms);
                            if (tmp != null)
                            {
                                //G1Adm_secadm_rgad = tmp.adm_secadm_rgad;
                                //G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                //G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                //G1Sia_codare_aser = tmp.sia_codare_aser;
                                //G1Hcl_tiptur_hctu = tmp.hcl_tiptur_hctu;
                                //G1Sia_codpfa_prof = tmp.sia_codpfa_prof;
                                //G1Sis_estpro_espr = tmp.sis_estpro_espr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_secadm_rgad":
                        #region ADM_SECADM_RGAD: Código Admisión
                        lcrNombreCampo = "Código Admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (String.IsNullOrWhiteSpace(G1Adm_secadm_rgad))
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = ADMValidarCodigo.fobRegBuscarAdmregadmision(G1Adm_secadm_rgad);
                            if (tmp != null)
                            {
                                G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                //G1Sia_codare_aser = tmp.sia_codare_aser;
                                //G1Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro;
                                //G1Cto_seccon_cont = tmp.cto_seccon_cont;
                                //G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                //G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                //G1Sia_codpfa_prof = tmp.sia_codpfa_prof;
                                //G1Sys_codusu_usux = tmp.sys_codusu_usux;
                                //G1Sis_estpro_espr = tmp.sis_estpro_espr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_seccon_cont":
                        #region CTO_SECCON_CONT: Secuencial de Contrato
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Cto_seccon_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
                            if (tmp != null)
                            {
                                tmpRegContrato = tmp;
                                G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                //G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                //G1Cto_descon_cont = tmp.cto_descon_cont;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    //case "G1Cto_nrocon_cont":
                    #region CTO_NROCON_CONT: Número Contrato
                    //lcrNombreCampo = "Número Contrato";
                    //lcrValorReturn = String.Empty;
                    //lcrCodigoError = "A05";
                    //if (String.IsNullOrWhiteSpace(G1Cto_nrocon_cont))
                    //{
                    //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                    //}
                    //else
                    //{
                    //}
                    //break;
                    #endregion

                    case "G1Sia_codeps_teps":
                        #region SIA_CODEPS_TEPS: Código EPS
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmpc = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
                            if (tmpc != null)
                            {
                                if (tmpc.cto_modeps_cont == "2") // si es 2 no se permite modificar codigo EPS
                                {
                                    G1Sia_codeps_teps = tmpc.sia_codeps_teps;
                                }
                            }
                            if (G1Sia_codeps_teps != "NA")
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_deseps_teps))
                                {
                                    G1Sia_deseps_teps = tmp.sia_deseps_teps;
                                }
                                else
                                {
                                    lcrValorReturn = "Código EPS: No existe";
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Código EPS: debe escribir un dato valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_gesfec_fams":
                        #region FAR_GESFEC_FAMS: Fecha servicio
                        lcrNombreCampo = "Fecha servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Far_gesfec_fams, "Fecha servicio");
                        break;
                        #endregion

                    case "G1Far_geshor_fams":
                        #region FAR_GESHOR_FAMS: Hora servicio
                        lcrNombreCampo = "Hora servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Far_geshor_fams, "12", ":", "Hora servicio");
                        break;
                        #endregion

                    case "G1Sia_idesec_usua":
                        #region SIA_IDESEC_USUA: Código único del paciente
                        lcrNombreCampo = "Código único del paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Sia_idesec_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(G1Sia_idesec_usua);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nroide_usua))
                            {
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                                G1Sia_fecnac_usua = Funciones.fcrConvertFecha((DateTime)tmp.sia_fecnac_usua);
                                G1Sis_codsex_sexo = tmp.sis_codsex_sexo;
                                G1Sia_edaymd_usua = tmp.sia_edaymd_usua;
                                if (String.IsNullOrWhiteSpace(G1Cto_seccon_cont)) { G1Cto_seccon_cont = tmp.cto_seccon_cont; }
                                if (String.IsNullOrWhiteSpace(G1Cto_nrocon_cont)) { G1Cto_nrocon_cont = tmp.cto_nrocon_cont; }
                                if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps)) { G1Sia_codeps_teps = tmp.sia_codeps_teps; }
                                if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps)) { G1Sia_codeps_teps = tmp.sia_codeps_teps; }
                                //G1Sys_codusu_usux = tmp.sys_codusu_usux;
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
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Sia_tipide_tide))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_tipide_tide, ",", "PE,AS,CC,CD,CE,MS,UN,RC,TI,NV"))
                            {
                                lcrValorReturn = "Tipo Identificación: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_nroide_usua":
                        #region SIA_NROIDE_USUA: Numero de Identificación
                        lcrNombreCampo = "Numero de Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (String.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarIuSiausuarioatendEx(G1Sia_nroide_usua);
                            if (tmp != null)
                            {
                                G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                fcrValidacion("G1Sia_idesec_usua");
                            }
                            else
                            {
                                lcrValorReturn = "Numero de Identificación: No existe";
                                #region LIMPIAR VISTA
                                G1Sia_idesec_usua = String.Empty;
                                G1Sia_tipide_tide = String.Empty;
                                G1Sia_nomusu_usua = String.Empty;
                                G1Cto_seccon_cont = String.Empty;
                                G1Cto_nrocon_cont = String.Empty;
                                G1Cto_descon_cont = String.Empty;
                                G1Sia_codeps_teps = String.Empty;
                                G1Sia_edaymd_usua = String.Empty;
                                G1Sia_fecnac_usua = String.Empty;
                                G1Sia_deseps_teps = String.Empty;
                                #endregion
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_tipreg_fams":
                        #region FAR_TIPREG_FAMS: Tipo registro
                        lcrNombreCampo = "Tipo registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (String.IsNullOrWhiteSpace(G1Far_tipreg_fams))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Far_tipreg_fams, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_tipges_fams":
                        #region FAR_TIPGES_FAMS: Tipo gestion
                        lcrNombreCampo = "Tipo gestion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (String.IsNullOrWhiteSpace(G1Far_tipges_fams))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Far_tipges_fams, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_observ_fams":
                        #region FAR_OBSERV_FAMS: Nota detalle
                        lcrNombreCampo = "Nota detalle";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (String.IsNullOrWhiteSpace(G1Far_observ_fams))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sia_codare_aser":
                        #region SIA_CODARE_ASER: Código Área de servicios
                        lcrNombreCampo = "Código Área de servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (String.IsNullOrWhiteSpace(G1Sia_codare_aser))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G1Sia_codare_aser);
                            if (tmp != null)
                            {
                                G1Sia_desare_aser = tmp.sia_desare_aser;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codcpr_cpro":
                        #region FCM_CODCPR_CPRO: Centro producción
                        lcrNombreCampo = "Centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codcpr_cpro))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(G1Fcm_codcpr_cpro);
                            if (tmp != null)
                            {
                                G1Fcm_descpr_cpro = tmp.fcm_descpr_cpro;
                                G1Sia_codare_aser = tmp.sia_codare_aser;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_tiptur_hctu":
                        #region HCL_TIPTUR_HCTU: Codigo turno
                        lcrNombreCampo = "Codigo turno";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (String.IsNullOrWhiteSpace(G1Hcl_tiptur_hctu))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = HCLValidarCodigo.fobRegBuscarHcltiporegturno(G1Hcl_tiptur_hctu);
                            if (tmp != null)
                            {
                                G1Hcl_destur_hctu = tmp.hcl_destur_hctu;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codpfa_prof":
                        #region SIA_CODPFA_PROF: Código del profesional
                        lcrNombreCampo = "Código del profesional";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (String.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                            if (tmp != null)
                            {
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nompro_prof = tmp.sia_nompro_prof;
                                G1Sys_codusu_usux = tmp.sys_codusu_usux;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    //case "G1Sys_codusu_usux":
                    #region SYS_CODUSU_USUX: Usuario que gestiona
                    //lcrNombreCampo = "Usuario que gestiona";
                    //lcrValorReturn = String.Empty;
                    //lcrCodigoError = "A19";
                    //if (String.IsNullOrWhiteSpace(G1Sys_codusu_usux))
                    //{
                    //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                    //}
                    //else
                    //{
                    //    var tmp = SYSValidarCodigo.fobRegBuscarSysusuarios(G1Sys_codusu_usux);
                    //    if (tmp != null)
                    //    {
                    //    }
                    //    else
                    //    {
                    //        lcrValorReturn = lcrNombreCampo + ": No existe";
                    //    }
                    //}
                    //break;
                    #endregion

                    case "G1Inv_codalm_inal":
                        #region INV_CODALM_INAL: Código Almacén
                        lcrNombreCampo = "Código Almacén";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (String.IsNullOrWhiteSpace(G1Inv_codalm_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvalmacenmaest(G1Inv_codalm_inal);
                            if (tmp != null)
                            {
                                G1Inv_desalm_inal = tmp.inv_desalm_inal;
                                G1Sia_codare_aser = tmp.sia_codare_aser;
                                //G1Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_entreg_fams":
                        #region FAR_ENTREG_FAMS: Tipo registro
                        lcrNombreCampo = "Tipo registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (String.IsNullOrWhiteSpace(G1Far_entreg_fams))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Far_entreg_fams, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Far_entrex_fams":
                        #region FAR_ENTREX_FAMS: Pendientes entregados
                        lcrNombreCampo = "Pendientes entregados";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (String.IsNullOrWhiteSpace(G1Far_entrex_fams))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Far_entrex_fams, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sys_codusx_usux":
                        #region SYS_CODUSX_USUX: Usuario gestion almacen
                        lcrNombreCampo = "Usuario gestion almacen";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (String.IsNullOrWhiteSpace(G1Sys_codusx_usux))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SYSValidarCodigo.fobRegBuscarSysusuarios(G1Sys_codusx_usux);
                            if (tmp != null)
                            {
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_estpro_espr":
                        #region SIS_ESTPRO_ESPR: Estado Registro
                        lcrNombreCampo = "Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A25";
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
            bool llgValidaServIPS = true;

            //lcrValorReturn=base.fcrValidacionRel(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G2Inv_codalm_inal":
                        #region INV_CODALM_INAL: Código Almacén
                        lcrNombreCampo = "Código Almacén";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B11";
                        if (String.IsNullOrWhiteSpace(G2Inv_codalm_inal))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = INVValidarCodigo.fobRegBuscarInvalmacenmaest(G2Inv_codalm_inal);
                            if (tmp != null)
                            {
                                G2Inv_desalm_inal = tmp.inv_desalm_inal;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Inv_secart_inar":
                        #region INV_SECART_INAR: Secuencial  Articulo
                        lcrNombreCampo = "Secuencial  Articulo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B12";
                        if (String.IsNullOrWhiteSpace(G2Inv_secart_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Inv_codaux_inar":
                        #region INV_CODAUX_INAR: Código Auxiliar Articulo
                        lcrNombreCampo = "Código Auxiliar Articulo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B13";

                        fcvCargarDatosParaLiquidarServ();
                        G2Inv_codaux_inar = G2Inv_codaux_inar.ToUpper();
                        gobLiq.G2Fcm_coddig_mant = G2Inv_codaux_inar;

                        if (String.IsNullOrWhiteSpace(G2Inv_codaux_inar))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            llgValidaServIPS = false;
                            lcrValorReturn = fcrValidaCodigoDigitacionAlmacen();

                            if (lcrValorReturn == "OK")
                            {
                                lcrValorReturn = String.Empty;
                                llgValidaServIPS = true;
                            }
                            if (llgValidaServIPS == true)
                            {
                                lcrValorReturn = fcrValidaCodigoDigitacionIPS(lcrNumeroRegistro, lcrNombreCampo);
                            }
                        }
                        break;
                        #endregion

                    case "G2Fcm_idesec_sips":
                        #region FCM_IDESEC_SIPS: Servicio IPS
                        lcrNombreCampo = "Servicio IPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B14";
                        if (String.IsNullOrWhiteSpace(G2Fcm_idesec_sips))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicips(G2Fcm_idesec_sips);
                            if (tmp != null)
                            {
                                G2Fcm_desser_sips = tmp.fcm_desser_sips;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Far_codcum_famd":
                        #region FAR_CODCUM_FAMD: Código CUM
                        //lcrNombreCampo = "Código CUM";
                        //lcrValorReturn = String.Empty;
                        //lcrCodigoError = "B15";
                        //if (String.IsNullOrWhiteSpace(G2Far_codcum_famd))
                        //{
                        //    lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        //}
                        //else
                        //{
                        //    var tmp = FARValidarCodigo.fobRegBuscarFarexpedmedicmd(G2Far_codcum_famd);
                        //    if (tmp != null)
                        //    {
                        //        G2Far_precom_famd = tmp.far_precom_famd;
                        //    }
                        //    else
                        //    {
                        //        lcrValorReturn = lcrNombreCampo + ": No existe";
                        //    }
                        //}
                        break;
                        #endregion

                    case "G2Sis_codume_sium":
                        #region SIS_CODUME_SIUM: Medida Almacenamiento
                        lcrNombreCampo = "Medida Almacenamiento";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B17";
                        if (String.IsNullOrWhiteSpace(G2Sis_codume_sium))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSisunidadmedida(G2Sis_codume_sium);
                            if (tmp != null)
                            {
                                G2Sis_desume_sium = tmp.sis_desume_sium;
                                G2Sis_codgme_sigr = tmp.sis_codgme_sigr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G2Far_unisol_fads":
                        #region FAR_UNISOL_FADS: Unidades solicitadas
                        lcrNombreCampo = "Unidades solicitadas";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B18";
                        if (G2Far_unisol_fads <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            lcrValorReturn = fcrValidarCantidadUnidades();
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                fcvCalcularUnidadesPendientesArticulo();
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": " + lcrValorReturn;
                            }
                        }
                        break;
                        #endregion

                    case "G2Far_unient_fads":
                        #region FAR_UNIENT_FADS: Unidades entregadas
                        lcrNombreCampo = "Unidades entregadas";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B18";
                        if (G2Far_unient_fads <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                            fcrValidacionRel("G2Far_unisol_fads");
                            /*
                            lcrValorReturn = fcrValidarCantidadUnidades();
                            if (String.IsNullOrWhiteSpace(lcrValorReturn))
                            {
                                fcvCalcularUnidadesPendientesArticulo();
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": " + lcrValorReturn;
                            }
                            */
                        }
                        break;
                        #endregion

                    case "G2Far_unipen_fads":
                        #region FAR_UNIPEN_FADS: Unidades pendientes
                        lcrNombreCampo = "Unidades pendientes";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B20";
                        if (G2Far_unipen_fads <= 0)
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        break;
                        #endregion

                    case "G2Inv_valing_inar":
                        #region INV_VALING_INAR: Valor  Ingreso unidad
                        lcrNombreCampo = "Valor  Ingreso unidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B21";
                        if (G2Inv_valing_inar <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G2Inv_valmov_inar":
                        #region INV_VALMOV_INAR: Valor salida unidad
                        lcrNombreCampo = "Valor salida unidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "B22";
                        if (G2Inv_valmov_inar <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
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
        #region flgValidarCantidadUnidades: Validacion Unidades
        /// <summary>
        /// Validar unidades solicitadas y unidades entregadas
        /// </summary>
        private String fcrValidarCantidadUnidades()
        {
            var lcrReturn = String.Empty;
            if ((G2Far_unisol_fads <= 0 || G2Far_unient_fads <= 0) || (G2Far_unisol_fads < G2Far_unient_fads))
            {
                lcrReturn = "Error en Unidades solicitadas y entregadas";
            }

            return lcrReturn;
        }
        #endregion
        #region fcvCalcularUnidadesPendientesArticulo
        /// <summary>
        /// Calcular unidades pendientes Articulo
        /// </summary>
        private void fcvCalcularUnidadesPendientesArticulo()
        {
            G2Far_unipen_fads = G2Far_unisol_fads -  G2Far_unient_fads;
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
                    //G2Inv_codctn_intc = tmpAux.inv_codctn_intc;
                    G2Inv_valing_inar = (float)tmpExisten.inv_valing_inar;
                    G2Inv_valmov_inar = (float)tmpExisten.inv_valmov_inar;
                    G2Inv_codalm_inal = G1Inv_codalm_inal;
                    //G2Inv_codald_inal = G1Inv_codald_inal;
                    #endregion
                }
            }
            return llgReturn;
        }
        #endregion
        #region fcvCargarDatosParaLiquidarServ: Cargar datos en clase para validar
        /// <summary>
        /// <para>Cargar datos en clase para validar digitacion y liquidacion de servicios</para>  
        /// </summary>
        public void fcvCargarDatosParaLiquidarServ()
        {
            gobLiq.tmpRegAdm = tmpRegAdm;
            // Datos basicos del registro facturado
            gobLiq.G2Adm_codtat_tatn = tmpRegAdm.Adm_codtat_tatn;
            gobLiq.G2Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
            gobLiq.G2Cto_seccon_cont = tmpRegAdm.Cto_seccon_cont;
            gobLiq.G2Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
            gobLiq.G2Fcm_fecser_dfac = G1Far_gesfec_fams;
            gobLiq.G2Sia_codpfa_prof = G1Sia_codpfa_prof;
            gobLiq.G2Sia_aresol_aser = tmpRegAdm.Sia_codare_aser;
            gobLiq.G2Sia_codare_aser = tmpRegAdm.Sia_codare_aser;
            gobLiq.G2Fcm_fecfac_mfac = G1Far_gesfec_fams;
            gobLiq.G2Fcm_horser_dfac = Funciones.fcrHoraActual("24", gcrSeparadorDecimal);
            gobLiq.G2Fac_horprs_dfac = gobLiq.G2Fcm_horser_dfac;
            gobLiq.G2Fcm_fecedt_dfac = Funciones.fcrFechaActual();
            gobLiq.G2Fcm_estfac_mfac = "1";
            gobLiq.G2Fcm_tiprfa_mfac = "1";
            gobLiq.G2Fcm_codman_mans = tmpRegContrato.fcm_codman_mans;
            gobLiq.G2Cto_seccon_cont = tmpRegContrato.cto_seccon_cont;
            gobLiq.G2Cto_serper_cont = tmpRegContrato.cto_serper_cont;
        }
        #endregion
        // Validacion Codigo de digitacion del medicamento o insumo
        #region fcrValidaCodigoDigitacionAlmacen: Validar codigo en existencias y cantidad
        /// <summary>
        /// <para>Validar codigo Medicamento en existencias almacen y cantidad</para>  
        /// </summary>
        public String fcrValidaCodigoDigitacionAlmacen()
        {
            var lcrValorReturn = String.Empty;
            gnuTotalUnidExisten = 0;

            #region Cuando es insumo o medicamento para descargar
                lcrValorReturn = "OK";
                // Verificar 
                var lobReg = TmpG2ListaBrow.FirstOrDefault(x => x.Inv_codaux_inar == G2Inv_codaux_inar);
                if (lobReg != null)
                {
                    if (lobReg.Far_nroreg_fads != TmpG2RegActivo.Far_nroreg_fads)
                    {
                        lcrValorReturn = "Ya existe un registro en la lista para el codigo: " + " - " + G2Inv_codaux_inar;
                    }
                }

                if (lcrValorReturn == "OK")
                {
                    var lobreAx = ModeloInvAlmacenExistencias.fobRegInvalmacexistenAlm(tmpRegContrato.inv_codalm_inal.Trim(), G2Inv_codaux_inar);
                    if (lobreAx != null)
                    {
                        gnuTotalUnidExisten  = lobreAx.Inv_totuni_inex;
                        G2Inv_secart_inar    = lobreAx.Inv_secart_inar;
                        G2Inv_nomart_inar    = lobreAx.Inv_nomart_inar;
                        G2Inv_valing_inar    = lobreAx.Inv_valing_inar;
                        G2Inv_valmov_inar    = lobreAx.Inv_valmov_inar;
                        G2Sis_codume_sium    = lobreAx.Sis_codume_sium;
                        G2Sis_desume_sium    = lobreAx.Sis_desume_sium;

                        if (lobreAx.Inv_totuni_inex <= 0)
                        {
                            lcrValorReturn = "No hay existencias en: " + tmpRegContrato.inv_codalm_inal + " - " + G1Inv_desalm_inal +" para el medicamento: " + G2Inv_codaux_inar;
                        }

                        gobLiq.G2Fcm_coddig_mant = lobreAx.Fcm_coddig_mant;
                        //tmpRegDetalle.Inv_secart_mart = lobreAx.Inv_secart_inar;
                    }
                    else
                    {
                        lcrValorReturn = "Código medicamento " + G2Inv_codaux_inar + " no tiene existencias en: " + tmpRegContrato.inv_codalm_inal + " - " + G1Inv_desalm_inal;
                    }
                }
            #endregion
            return lcrValorReturn;
        }
        #endregion
        #region fcrValidaCodigoDigitacionIPS: Validacion del suministro cen configuracion en Servicios IPS
        /// <summary>
        /// <para>Realizar Validacion del suministro con respecto a configuracion en Servicios IPS</para>  
        /// </summary>
        public String fcrValidaCodigoDigitacionIPS(String tcrNumeroRegistro, String tcrNombreCampo)
        {
            String lcrValorReturn = gobLiq.fcrValidacionCampos("Fcm_coddig_mant", ref tmpLogErrores, tcrNumeroRegistro);

            #region Validar codigo servicio IPS
            if (String.IsNullOrWhiteSpace(lcrValorReturn))
            {
                var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(gobLiq.G2Fcm_coddig_mant);
                var tmpSrv = FCMValidarCodigo.fobRegBuscarIuFcmmanserviciosProg(gobLiq.G2Fcm_coddig_mant, tmpRegContrato.fcm_codman_mans,
                                                                                tmpRegContrato.cto_seccon_cont, tmpRegContrato.cto_serper_cont);
                if (tmp != null && tmp.fcm_idesec_sips != null && tmpSrv != null)
                {
                    G2Fcm_idesec_sips = tmp.fcm_idesec_sips;
                    G2Fcm_coddig_mant = tmp.fcm_coddig_mant;
                    G2Fcm_desser_sips = tmp.fcm_desser_sips;
                    G1Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro;

                    if (!flgValidacionPertinencia())
                    {
                        lcrValorReturn = tcrNombreCampo + " : Error en validación pertinencia";
                    }
                    else
                    {
                        //- Actualizar temporal
                        //tmpRegDetalle.Fcm_idesec_sips = tmp.fcm_idesec_sips;

                        // Guardar el codigo de digitacion en campo auxiliar
                        /*
                        if (this.chkG1Cto_suminv_cont.IsChecked == true)
                        {
                            tmpRegDetalle.Fcm_secreg_dfac = tmp.fcm_coddig_mant;
                        }
                        */
                    }
                }
                else
                {
                    lcrValorReturn = "Código servicio: " + gobLiq.G2Fcm_coddig_mant + " No existe";
                    //txtG1Fcm_desser_sips.Text = lcrValorReturn;
                }
            }
            #endregion
            return lcrValorReturn;
        }
        #endregion
        //-------------------------------------------------
        // Validacion de pertinencia
        //-------------------------------------------------
        #region flgValidacionPertinencia: Validacion pertinencia del servicio
        /// <summary>
        /// Validacion pertinencia del servicio
        /// </summary>
        public bool flgValidacionPertinencia()
        {
            var llgReturn = true;
            gobLiq.G2Fcm_totuni_dfac = G2Far_unient_fads;
            //Validar pertinencia
            llgReturn = gobLiq.flgValidacionPertinencia(ref tmpLogErrores, "PERTINENCIA");
            return llgReturn;
        }
        #endregion
    }
}
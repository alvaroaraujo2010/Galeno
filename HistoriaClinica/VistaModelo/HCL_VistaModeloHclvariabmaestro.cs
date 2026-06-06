//- MARMOTA-GENCODE: VERSION 2.0 - 28/06/2016 06:00:41 AM
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
using HistoriasClinicas.Modelo;

namespace HistoriasClinicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hclvariabmaestr</para>
    /// <para>DESCRIPCION:
    ///  Maestro Variables publicas gestion en formatos de historias
    ///  clinicas
    /// </para>
    /// </summary>
    public class VistaModeloHclvariabmaestro : VistaModeloHclvariabmaestroBase
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

            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Hcl_secgru_hcgv":
                        #region HCL_SECGRU_HCGV: Grupo de variables
                        lcrNombreCampo = "Grupo de variables";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (String.IsNullOrWhiteSpace(G1Hcl_secgru_hcgv))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = HCLValidarCodigo.fobRegBuscarHclvariabgrupos(G1Hcl_secgru_hcgv);
                            if (tmp != null)
                            {
                                G1Hcl_desgru_hcgv = tmp.hcl_desgru_hcgv;
                                G1Sis_estreg_esrg = tmp.sis_estreg_esrg;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_ordvis_hcvr":
                        #region HCL_ORDVIS_HCVR: Orden vista
                        lcrNombreCampo = "Orden vista";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (G1Hcl_ordvis_hcvr <= 0)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Hcl_titulo_hcvr":
                        #region HCL_TITULO_HCVR: Titulo Variable
                        lcrNombreCampo = "Titulo Variable";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (String.IsNullOrWhiteSpace(G1Hcl_titulo_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Hcl_descri_hcvr":
                        #region HCL_DESCRI_HCVR: Descripción Variable
                        lcrNombreCampo = "Descripción Variable";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        if (String.IsNullOrWhiteSpace(G1Hcl_descri_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Hcl_auxvar_hcvr":
                        #region Editar nuevo nombre de variable
                        lcrNombreCampo = "Nombre variable publica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "AX6";
                        if (String.IsNullOrWhiteSpace(G1Hcl_auxvar_hcvr) && GlgSIS_ModoAdicion == true)
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Hcl_auxvar_hcvr = G1Hcl_auxvar_hcvr.Trim().ToUpper();
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Hcl_auxvar_hcvr, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890_"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                            }
                            else
                            {
                                G1Hcl_nomvar_hcvr = (G1Hcl_nomvar_hcgv + "_" + G1Hcl_auxvar_hcvr).ToUpper();
                                G1Hcl_maxvar_hcvr = G1Hcl_nomvar_hcvr.Length;
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_nomvar_hcvr":
                        #region HCL_NOMVAR_HCVR: Nombre variable publica
                        lcrNombreCampo = "Nombre variable publica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        if (String.IsNullOrWhiteSpace(G1Hcl_nomvar_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Hcl_maxvar_hcvr = G1Hcl_nomvar_hcvr.Length;

                            if (G1Hcl_maxvar_hcvr > 30)
                            {
                                lcrValorReturn = lcrNombreCampo + ": nombre es demasiado largo " + G1Hcl_maxvar_hcvr.ToString()+", se permite maximo 30 caracteres ";
                            }
                            else if (G1Hcl_maxvar_hcvr < 18)
                            {
                                lcrValorReturn = lcrNombreCampo + ": nombre es muy corto " + G1Hcl_maxvar_hcvr.ToString() + ", minimo debe ser 18 caracteres y maximo 30";
                            }
                            else
                            {
                                var tmp = HCLValidarCodigo.fobRegBuscarHclvariabmaestr(G1Hcl_nomvar_hcvr);
                                if (tmp != null)
                                {
                                    if (!String.IsNullOrWhiteSpace(tmp.hcl_nroreg_hcvr))
                                    {
                                        if (GlgSIS_ModoAdicion == true) // en modo adicion
                                        {
                                            lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                        }
                                        else
                                        {
                                            if (G1Hcl_nroreg_hcvr != tmp.hcl_nroreg_hcvr) // en modo edicion existe para otro registro
                                            {
                                                lcrValorReturn = lcrNombreCampo + ": Ya existe en Base de Datos";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_tipval_hcvr":
                        #region HCL_TIPVAL_HCVR: Tipo dato Valor campo
                        lcrNombreCampo = "Tipo dato Valor campo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (String.IsNullOrWhiteSpace(G1Hcl_tipval_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Hcl_tipval_hcvr = G1Hcl_tipval_hcvr.ToUpper();
                            if (!Funciones.flgExisteElemento(G1Hcl_tipval_hcvr, ",", "D,C,N,R,F,H"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            if (G1Hcl_tipval_hcvr == "C" && String.IsNullOrWhiteSpace(G1Hcl_valper_hcvr))
                            {
                                G1Hcl_valper_hcvr = "TEXTO";
                            }
                            else if (G1Hcl_tipval_hcvr == "D" && String.IsNullOrWhiteSpace(G1Hcl_valper_hcvr))
                            {
                                G1Hcl_valper_hcvr = "FECHA";
                                G1Hcl_ranfin_hcvr = String.IsNullOrWhiteSpace(G1Hcl_ranfin_hcvr) ? "01/01/1900" : G1Hcl_ranfin_hcvr;
                                G1Hcl_ranfin_hcvr = String.IsNullOrWhiteSpace(G1Hcl_ranfin_hcvr) ? "31/12/2030" : G1Hcl_ranfin_hcvr;
                            }
                            else if (G1Hcl_tipval_hcvr == "N" && String.IsNullOrWhiteSpace(G1Hcl_valper_hcvr))
                            {
                                G1Hcl_valper_hcvr = "0";
                            }
                            else if (G1Hcl_tipval_hcvr == "R" && String.IsNullOrWhiteSpace(G1Hcl_valper_hcvr))
                            {
                                G1Hcl_valper_hcvr = "RELACION";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_camdig_hcvr":
                        #region HCL_CAMDIG_HCVR: Campo digitable
                        lcrNombreCampo = "Campo digitable";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (String.IsNullOrWhiteSpace(G1Hcl_camdig_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_camdig_hcvr, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_ranini_hcvr":
                        #region HCL_RANINI_HCVR: Rango inicial
                        lcrNombreCampo = "Rango inicial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Hcl_ranini_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        */
                        break;
                        #endregion

                    case "G1Hcl_ranfin_hcvr":
                        #region HCL_RANFIN_HCVR: Rango final
                        lcrNombreCampo = "Rango final";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        /*
                        if (String.IsNullOrWhiteSpace(G1Hcl_ranfin_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                        }
                        */
                        break;
                        #endregion

                    case "G1Hcl_raninr_hcvr":
                        #region HCL_RANINR_HCVR: Rango inicial normal
                        lcrNombreCampo = "Rango inicial normal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (!String.IsNullOrWhiteSpace(G1Hcl_raninr_hcvr))
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Hcl_ranfnr_hcvr":
                        #region HCL_RANFNR_HCVR: Rango final normal
                        lcrNombreCampo = "Rango final normal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (!String.IsNullOrWhiteSpace(G1Hcl_ranfnr_hcvr))
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Hcl_nivvar_hcvr":
                        #region HCL_NIVVAR_HCVR: Nivel gestion
                        lcrNombreCampo = "Nivel gestion";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (String.IsNullOrWhiteSpace(G1Hcl_nivvar_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_nivvar_hcvr, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_sistem_hcvr":
                        #region HCL_SISTEM_HCVR: Tipo variable
                        lcrNombreCampo = "Tipo variable";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (String.IsNullOrWhiteSpace(G1Hcl_sistem_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_sistem_hcvr, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_modoca_hcvr":
                        #region HCL_MODOCA_HCVR: Modo captura datos
                        lcrNombreCampo = "Modo captura datos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (String.IsNullOrWhiteSpace(G1Hcl_modoca_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_modoca_hcvr, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else
                            {
                                G1Hcl_resume_hcvr = G1Hcl_modoca_hcvr != "1" && !String.IsNullOrWhiteSpace(G1Hcl_modoca_hcvr) ? "2" : G1Hcl_resume_hcvr;
                                G1Hcl_siresu_hcvr = G1Hcl_modoca_hcvr == "1" ? "3" : G1Hcl_siresu_hcvr;
                                G1Hcl_siresu_hcvr = String.IsNullOrWhiteSpace(G1Hcl_siresu_hcvr) ? "3" : G1Hcl_siresu_hcvr;

                                // las variables simples no pueden tener lsita de variables 
                                if (!String.IsNullOrWhiteSpace(G1Hcl_vresum_hcvr) && G1Hcl_modoca_hcvr == "1")
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Variables simples no deben tener lista de variables para resumen";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_resume_hcvr":
                        #region HCL_RESUME_HCVR: Resumen de datos
                        lcrNombreCampo = "Resumen de datos";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (String.IsNullOrWhiteSpace(G1Hcl_resume_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Hcl_resume_hcvr = G1Hcl_modoca_hcvr != "1" && !String.IsNullOrWhiteSpace(G1Hcl_modoca_hcvr) ? "2" : G1Hcl_resume_hcvr;

                            if (!Funciones.flgExisteElemento(G1Hcl_resume_hcvr, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }

                        }
                        break;
                        #endregion

                    case "G1Hcl_siresu_hcvr":
                        #region HCL_SIRESU_HCVR: Opcion lista variables
                        lcrNombreCampo = "Opcion lista variables";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (String.IsNullOrWhiteSpace(G1Hcl_siresu_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Hcl_siresu_hcvr = G1Hcl_modoca_hcvr == "1" ? "3" : G1Hcl_siresu_hcvr;

                            if (!Funciones.flgExisteElemento(G1Hcl_siresu_hcvr, ",", "1,2,3"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_vresum_hcvr":
                        #region HCL_VRESUM_HCVR: Lista Variables resumen
                        lcrNombreCampo = "Lista Variables resumen";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (!String.IsNullOrWhiteSpace(G1Hcl_vresum_hcvr))
                        {
                            //lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Hcl_vresum_hcvrxx":
                        #region HCL_VRESUM_HCVR: Lista Variables resumen para ejecucion desde boton en vista
                        lcrNombreCampo = "Lista Variables resumen";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (!String.IsNullOrWhiteSpace(G1Hcl_vresum_hcvr))
                        {
                            EFhclvariabmaestr lcrRegVar = null;
                            string[] larArray = G1Hcl_vresum_hcvr.Split((";").ToCharArray());
                            var lnuTotElemtos = larArray.Length;
                            var lcrValor = String.Empty;
                            var lnuIx  = String.Empty;
                            var llgSiError = false;
                            var i = 0;

                            // Limpiar errores
                            for (i = 0; i < lnuTotElemtos; i++)
                            {
                                lnuIx = i.ToString().Trim();
                                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A22A" + lnuIx, lcrNombreCampo, "", "ALTO", lcrImgNivelError);
                                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A22B" + lnuIx, lcrNombreCampo, "", "ALTO", lcrImgNivelError);
                                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A22C" + lnuIx, lcrNombreCampo, "", "ALTO", lcrImgNivelError);
                                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, "USUARIO", "A22D" + lnuIx, lcrNombreCampo, "", "ALTO", lcrImgNivelError);
                            }

                            // Validar lista
                            for (i = 0; i < lnuTotElemtos; i++)
                            {
                                lnuIx = i.ToString().Trim();
                                lcrValor = larArray[i].ToUpper();

                                if (String.IsNullOrWhiteSpace(lcrValor))
                                {
                                    llgSiError = true;
                                    lcrCodigoError = "A22A" + lnuIx;
                                    lcrValorReturn = lcrNombreCampo + ": hay espacios vacios posición " + lnuIx;
                                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                                 lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                                }
                                else if (lcrValor.Length < 16 || lcrValor.Length > 30) // Nombre tamaño del nombre incorrecto
                                {
                                    llgSiError = true;
                                    lcrCodigoError = "A22B" + lnuIx;

                                    if (lcrValor.Length > 60)
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Nombre de variable no es valido en tamaño (" + lcrValor.Length.ToString() + " caracteres)";
                                    }
                                    else
                                    {
                                        lcrValorReturn = lcrNombreCampo + ": Nombre de variable  '" + lcrValor + "' no es valido en tamaño (" + lcrValor.Length.ToString() + " caracteres)";
                                    }
                                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                                 lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                                }
                                else 
                                {
                                    lcrRegVar = HCLValidarCodigo.fobRegBuscarHclvariabmaestrVr(lcrValor);
                                    if (lcrRegVar != null)
                                    {
                                        if (lcrRegVar.hcl_resume_hcvr == "2")
                                        {
                                            llgSiError = true;
                                            lcrCodigoError = "A22C" + lnuIx;
                                            lcrValorReturn = lcrNombreCampo + ": Variable '" + lcrValor + "' esta configurada para no ser incluida en resumen";
                                            LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                                         lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                                        }
                                    }
                                    else
                                    {
                                        llgSiError = true;
                                        lcrCodigoError = "A22D" + lnuIx;
                                        lcrValorReturn = lcrNombreCampo + ": Variable '" + lcrValor + "' no existe en archivo maestro";
                                        LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                                     lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                                    }
                                }
                            }
                            lcrValorReturn = llgSiError == true ? lcrNombreCampo + ": Hay errores en la lista" : String.Empty;
                        }
                        break;
                        #endregion

                    case "G1Hcl_tvigen_hcvr":
                        #region HCL_TVIGEN_HCVR: Vigencia en tiempo
                        lcrNombreCampo = "Vigencia en tiempo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (String.IsNullOrWhiteSpace(G1Hcl_tvigen_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_tvigen_hcvr, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_vvigen_hcvr":
                        #region HCL_VVIGEN_HCVR: Valor vigencia tiempo
                        lcrNombreCampo = "Valor vigencia tiempo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (G1Hcl_tvigen_hcvr != "1")
                        {
                            if (G1Hcl_vvigen_hcvr < 2)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                            }
                        }
                        else
                        {
                            G1Hcl_vvigen_hcvr = 0;
                        }
                        break;
                        #endregion

                    case "G1Hcl_varray_hcvr":
                        #region HCL_VARRAY_HCVR: Variable tipo pila
                        lcrNombreCampo = "Variable tipo pila";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (String.IsNullOrWhiteSpace(G1Hcl_varray_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_varray_hcvr, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_tmara_hcvr":
                        #region HCL_TMARAy_HCVR: Tamaño pila
                        lcrNombreCampo = "Tamaño pila";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (G1Hcl_varray_hcvr != "2")
                        {
                            if (G1Hcl_tmaray_hcvr < 1)
                            {
                                lcrValorReturn = lcrNombreCampo + ": Debe ser mayor que cero";
                            }
                        }
                        else
                        {
                            G1Hcl_tmaray_hcvr = 0;
                        }
                        break;
                        #endregion

                    case "G1Hcl_sisvar_hcvr":
                        #region HCL_SISVAR_HCVR: Variable protegida
                        lcrNombreCampo = "Variable protegida";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (String.IsNullOrWhiteSpace(G1Hcl_sisvar_hcvr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Hcl_sisvar_hcvr, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_estreg_esrg":
                        #region SIS_ESTREG_ESRG: Código Estado Registro
                        lcrNombreCampo = "Código Estado Registro";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (String.IsNullOrWhiteSpace(G1Sis_estreg_esrg))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sis_estreg_esrg, ",", "1,2"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                }
                if (tcrNombrePropiedad != "G1Hcl_vresum_hcvrxx")
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
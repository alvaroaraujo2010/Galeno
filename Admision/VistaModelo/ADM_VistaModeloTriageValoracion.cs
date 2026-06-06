//- MARMOTA-GENCODE: VERSION 2.0 - 04/04/2014 08:19:09 AM
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
using Admision.Modelo;

namespace Admision.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admtriagemaestr</para>
    /// <para>DESCRIPCION:
    ///  Maestro para  registro  de datos en la evaluación inicial Triage
    ///  realizada a pacientes antes de ser admitidos.
    /// </para>
    /// </summary>
    public class VistaModeloTriageValoracion : VistaModeloTriageBase
    {
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdFILTRO { get; set; }
        public RelayCommand CmdBROWSER { get; set; }
        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            CmdFILTRO  = new RelayCommand(fcvFiltro, CanFiltro);
            CmdBROWSER = new RelayCommand(fcvDefault, CanBrowser);
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
                    var lcrCodigo1 = G1Adm_nroreg_tria;
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        Adicionar();
                        G1Adm_nroreg_tria = lcrCodigo1;
                        fcrValidacion("G1Adm_nroreg_tria");
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
        #region CanBrowser
        /// <summary>
        ///Validación para saber si activa botones para browser busqueda
        /// </summary>
        public bool CanBrowser()
        {
            return GlgSIS_ModoEdicion;
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
        #region fcvDefault: Solo para cumplir con parametros comando
        /// <summary>
        /// Solo para cumplir con parametros comando
        /// </summary>
        public void fcvDefault()
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
                    case "G1Sia_tipide_tide":

                        lcrNombreCampo = "Tipo Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E01";

                        if (string.IsNullOrWhiteSpace(G1Sia_tipide_tide))
                        {
                            lcrValorReturn = "Tipo Identificación: Es requerido";
                        }
                        else
                        {
                            EFsiatipideusario tmp = new EFsiatipideusario();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatipideusario(G1Sia_tipide_tide);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_deside_tide))
                            {
                                G1Sia_deside_tide = tmp.sia_deside_tide;
                            }
                            else
                            {
                                lcrValorReturn = "Tipo Identificación: No existe";
                            }
                        }
                        break;

                    case "G1Sia_priape_usua":

                        lcrNombreCampo = "Primer Apellido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E02";

                        if (string.IsNullOrWhiteSpace(G1Sia_priape_usua))
                        {
                            lcrValorReturn = "Primer Apellido: Es requerido";
                        }
                        else
                        {
                            G1Sia_priape_usua = G1Sia_priape_usua.ToUpper().Trim();
                            if (G1Sia_priape_usua.Trim().Length <= 2)
                            {
                                lcrValorReturn = "Primer Apellido: No es valido pocos caracteres(" + G1Sia_priape_usua.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_priape_usua, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ "))
                                {
                                    lcrValorReturn = "Primer Apellido: Contiene caracteres no validos";
                                }
                            }
                        }
                        break;

                    case "G1Sia_prinom_usua":

                        lcrNombreCampo = "Primer Nombre";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E03";

                        if (String.IsNullOrWhiteSpace(G1Sia_prinom_usua))
                        {
                            lcrValorReturn = "Primer Nombre: Es requerido";
                        }
                        else
                        {
                            G1Sia_prinom_usua = G1Sia_prinom_usua.ToUpper().Trim();
                            if (G1Sia_prinom_usua.Trim().Length <= 2)
                            {
                                lcrValorReturn = "Primer Nombre: No es valido pocos caracteres(" + G1Sia_prinom_usua.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_prinom_usua, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ "))
                                {
                                    lcrValorReturn = "Primer Nombre: Contiene caracteres no validos";
                                }
                            }
                        }
                        break;

                    case "G1Sia_segape_usua":

                        lcrNombreCampo = "Segundo apellido";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E04";

                        if (!String.IsNullOrWhiteSpace(G1Sia_segape_usua))
                        {
                            G1Sia_segape_usua = G1Sia_segape_usua.ToUpper().Trim();
                            if (G1Sia_segape_usua.Trim().Length < 2)
                            {
                                lcrValorReturn = "Segundo Apellido: No es valido pocos caracteres(" + G1Sia_segape_usua.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_segape_usua, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ "))
                                {
                                    lcrValorReturn = "Segundo Apellido: Contiene caracteres no validos";
                                }
                            }
                        }
                        break;

                    case "G1Sia_segnom_usua":

                        lcrNombreCampo = "Segundo nombre";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E05";

                        if (!String.IsNullOrWhiteSpace(G1Sia_segnom_usua))
                        {
                            G1Sia_segnom_usua = G1Sia_segnom_usua.ToUpper();
                            if (G1Sia_segnom_usua.Trim().Length < 2)
                            {
                                lcrValorReturn = "Segundo nombre: No es valido pocos caracteres(" + G1Sia_segnom_usua.Trim().Length.ToString() + ")";
                            }
                            else
                            {
                                if (!Funciones.flgExisteSubCadenaStringEx(G1Sia_segnom_usua, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ "))
                                {
                                    lcrValorReturn = "Segundo nombre: Contiene caracteres no validos";
                                }
                            }
                        }
                        break;

                    case "G1Sis_codsex_sexo":

                        lcrNombreCampo = "Sexo del paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E06";

                        if (String.IsNullOrWhiteSpace(G1Sis_codsex_sexo))
                        {
                            lcrValorReturn = "Sexo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sis_codsex_sexo, ",", "M,F"))
                            {
                                lcrValorReturn = "Sexo: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sia_edapac_usua":

                        lcrNombreCampo = "Edad paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E07";

                        if (G1Sia_edapac_usua <= 0)
                        {
                            lcrValorReturn = "Edad paciente: Debe ser mayor que cero";
                        }
                        else
                        {
                            // Validar mas adelante
                        }
                        break;

                    case "G1Sia_codmed_tmed":

                        lcrNombreCampo = "Medida Edad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E08";

                        if (string.IsNullOrWhiteSpace(G1Sia_codmed_tmed))
                        {
                            lcrValorReturn = "Medida Edad: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_codmed_tmed, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Medida Edad: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Adm_gesfec_tria":

                        lcrNombreCampo = "Fecha servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E09";

                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Adm_gesfec_tria, "Fecha servicio");
                        break;

                    case "G1Adm_geshor_tria":

                        lcrNombreCampo = "Hora servicio";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E10";

                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Adm_geshor_tria, "12", ":", "Hora servicio");
                        break;

                    case "G1Adm_frecar_tria":

                        lcrNombreCampo = "Frecuencia cardiaca (FC)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E11";

                        if (G1Adm_frecar_tria < 0)
                        {
                            lcrValorReturn = "Frecuencia cardiaca (FC): Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_frecar_tria < 0 || G1Adm_frecar_tria > 200)
                            {
                                lcrValorReturn = "Frecuencia cardiaca (FC): Valor fuera del rango";
                            }
                        }
                        /*
                        if (G1Adm_frecar_tria <= 0)
                        {
                            lcrValorReturn = "Frecuencia cardiaca (FC): Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_frecar_tria < 10 || G1Adm_frecar_tria > 200)
                            {
                                lcrValorReturn = "Frecuencia cardiaca (FC): Valor fuera del rango";
                            }
                        }
                        */
                        break;

                    case "G1Adm_freres_tria":

                        lcrNombreCampo = "Frecuencia respiratoria (FR)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E12";

                        if (G1Adm_freres_tria < 0)
                        {
                            lcrValorReturn = "Frecuencia respiratoria (FR): Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_freres_tria < 0 || G1Adm_freres_tria > 45)
                            {
                                lcrValorReturn = "Frecuencia respiratoria (FR): Valor fuera del rango";
                            }
                        }

                        /*
                        if (G1Adm_freres_tria <= 0)
                        {
                            lcrValorReturn = "Frecuencia respiratoria (FR): Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_freres_tria < 15 || G1Adm_freres_tria > 45)
                            {
                                lcrValorReturn = "Frecuencia respiratoria (FR): Valor fuera del rango";
                            }
                        }
                        */
                        break;

                    case "G1Adm_tasist_tria":

                        lcrNombreCampo = "Tensión Arterial sistólica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E13";

                        if (G1Adm_tasist_tria < 0)
                        {
                            lcrValorReturn = "T.Arterial  sistólica: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_tasist_tria < 0 || G1Adm_tasist_tria > 250)
                            {
                                lcrValorReturn = "T.Arterial  sistólica: Valor fuera del rango";
                            }
                        }

                        /*
                        if (G1Adm_tasist_tria <= 0)
                        {
                            if ((G1Sia_edapac_usua > 10 && G1Sia_codmed_tmed == "1")) // no obligatorio para niños menores de 10 años
                            {
                                lcrValorReturn = "T.Arterial  sistólica: Debe ser mayor que cero";
                            }
                        }
                        else
                        {
                            if (G1Adm_tasist_tria < 50 || G1Adm_tasist_tria > 250)
                            {
                                lcrValorReturn = "T.Arterial  sistólica: Valor fuera del rango";
                            }
                        }
                        */
                        break;

                    case "G1Adm_tadias_tria":

                        lcrNombreCampo = "Tensión Arterial diastólica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E14";

                        if (G1Adm_tadias_tria < 0)
                        {
                            lcrValorReturn = "T.Arterial diastólica: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_tadias_tria < 0 || G1Adm_tadias_tria > 200)
                            {
                                lcrValorReturn = "T.Arterial diastólica: Valor fuera del rango";
                            }
                        }

                        /*
                        if (G1Adm_tadias_tria <= 0)
                        {
                            if ((G1Sia_edapac_usua > 10 && G1Sia_codmed_tmed == "1")) // no obligatorio para niños menores de 10 años
                            {
                                lcrValorReturn = "T.Arterial diastólica: Debe ser mayor que cero";
                            }
                        }
                        else
                        {
                            if (G1Adm_tadias_tria < 30 || G1Adm_tadias_tria > 200)
                            {
                                lcrValorReturn = "T.Arterial diastólica: Valor fuera del rango";
                            }
                        }
                        */
                        break;

                    case "G1Adm_temper_tria":

                        lcrNombreCampo = "Temperatura corporal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E15";

                        if (G1Adm_temper_tria < 0)
                        {
                            lcrValorReturn = "Temperatura corporal: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_temper_tria < 0 || G1Adm_temper_tria > 45)
                            {
                                lcrValorReturn = "Temperatura corporal: Valor fuera del rango";
                            }
                        }

                        /*
                        if (G1Adm_temper_tria <= 0)
                        {
                            lcrValorReturn = "Temperatura corporal: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_temper_tria < 30 || G1Adm_temper_tria > 45)
                            {
                                lcrValorReturn = "Temperatura corporal: Valor fuera del rango";
                            }
                        }
                        */
                        break;

                    case "G1Adm_pesokg_tria":

                        lcrNombreCampo = "Peso (kilogramos)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E16";

                        if (G1Adm_pesokg_tria <= 0)
                        {
                            lcrValorReturn = "Peso (kilogramos): Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_pesokg_tria < 1 || G1Adm_pesokg_tria > 400)
                            {
                                lcrValorReturn = "Peso (kilogramos): Valor fuera del rango";
                            }
                        }
                        break;

                    case "G1Adm_tallac_tria":

                        lcrNombreCampo = "Talla (centimetros)";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E17";

                        if (G1Adm_tallac_tria <= 0)
                        {
                            lcrValorReturn = "Talla (centimetros): Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Adm_tallac_tria < 15 || G1Adm_tallac_tria > 220)
                            {
                                lcrValorReturn = "Talla (centimetros): Valor fuera del rango";
                            }
                        }
                        break;

                    case "G1Adm_clasif_tria":

                        lcrNombreCampo = "Clasificación triage";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E18";

                        if (string.IsNullOrWhiteSpace(G1Adm_clasif_tria))
                        {
                            lcrValorReturn = "Clasificación triage: Es requerido";
                        }
                        else
                        {
                            var tmp = ADMValidarCodigo.fobRegBuscarAdmtriagemaconfNivel(G1Adm_clasif_tria);
                            if (tmp != null)
                            {
                                G1Adm_remisi_tria = tmp.adm_remisi_tria;
                            }
                            else
                            {
                                lcrValorReturn = "Clasificación triage: Dato no esta configurado en los Niveles Triage";
                            }
                        }
                        break;

                    case "G1Adm_remisi_tria":

                        lcrNombreCampo = "Destino Remisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E19";

                        if (string.IsNullOrWhiteSpace(G1Adm_remisi_tria))
                        {
                            lcrValorReturn = "Destino Remisión: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_remisi_tria, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Destino Remisión: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Sia_coddia_tdia":
                        #region SIA_CODDIA_TDIA: Codgo Diagnostico
                        lcrNombreCampo = "Codgo Diagnostico";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A28";
                        if (String.IsNullOrWhiteSpace(G1Sia_coddia_tdia))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Sia_coddia_tdia = G1Sia_coddia_tdia.ToUpper();
                            var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_coddia_tdia);
                            if (tmp != null)
                            {
                                G1Sia_desdia_tdia = tmp.sia_desdia_tdia;
                                G1Adm_observ_tria = String.IsNullOrWhiteSpace(G1Adm_observ_tria) ? G1Sia_coddia_tdia + " - " + G1Sia_desdia_tdia : G1Adm_observ_tria;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codeps_teps":

                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E20";

                        if (string.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            lcrValorReturn = "Código EPS: Es requerido";
                        }
                        else
                        {
                            G1Sia_codeps_teps = G1Sia_codeps_teps.Trim().ToUpper();
                            EFsiatablaeps tmp = new EFsiatablaeps();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                            if (tmp != null)
                            {
                                G1Sia_deseps_teps = tmp.sia_deseps_teps;
                            }
                            else
                            {
                                lcrValorReturn = "Código EPS: No existe";
                            }
                        }
                        break;

                    case "G1Sia_codcat_ceat":

                        lcrNombreCampo = "Código centro atención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E21";

                        if (string.IsNullOrWhiteSpace(G1Sia_codcat_ceat))
                        {
                            lcrValorReturn = "Código centro atención: Es requerido";
                        }
                        else
                        {
                            EFsiacentroaten tmp = new EFsiacentroaten();
                            tmp = SIAValidarCodigo.fobRegBuscarSiacentroaten(G1Sia_codcat_ceat);
                            if (tmp != null)
                            {
                                G1Sia_descat_ceat = tmp.sia_descat_ceat;
                            }
                            else
                            {
                                lcrValorReturn = "Código centro atención: No existe";
                            }
                        }
                        break;

                    case "G1Sia_codpfa_prof":

                        lcrNombreCampo = "Profesional que atiende";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "E22";

                        if (string.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
                        {
                            lcrValorReturn = "Profesional atiende: Es requerido";
                        }
                        else
                        {
                            G1Sia_codpfa_prof = G1Sia_codpfa_prof.Trim().ToUpper();
                            var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                            if (tmp != null)
                            {
                                G1Sia_nompro_prof = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = "Profesional atiende: No existe";
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
    }
}
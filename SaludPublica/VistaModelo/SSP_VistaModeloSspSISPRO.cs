//- MARMOTA-GENCODE: VERSION 2.0 - 30/06/2013 04:42:17 PM
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
using SaludPublica.Modelo;

namespace SaludPublica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sptablamssispro</para>
    /// <para>DESCRIPCION:
    /// Tabla maestra de digitacion SISPRO
    /// </para>
    /// </summary>
    public class VistaModeloSspSISPRO : VistaModeloSspSISPROBase
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
                    case "G1Sia_idesec_usua":
                        if (string.IsNullOrWhiteSpace(G1Sia_idesec_usua))
                        {
                            lcrValorReturn = "Código único del paciente: Es requerido";
                        }
                        else
                        {
                            EFsptablamssispro tmpaux = new EFsptablamssispro();
                            tmpaux = SSPValidarCodigo.fobRegIdBuscarSptablamssispro(G1Sia_idesec_usua);
                            if (tmpaux != null)
                            {
                                GlgSIS_ModoEdicion = false;
                                GlgSIS_ModoAdicion = false;
                                G1Ssp_cam001_spro = tmpaux.ssp_cam001_spro;
                                GcrFiltroDatos=String.Empty;
                                CanFIL();
                                GlgSIS_ModoEdicion = true;

                            }
                            else
                            {
                                EFsiausuarioatend tmp = new EFsiausuarioatend();
                                tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(G1Sia_idesec_usua);
                                if (tmp != null)
                                {
                                    G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                    G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                    G1Ssp_cam002_spro = "205700023601";
                                    G1Ssp_cam003_spro = tmp.sia_tipide_tide;
                                    G1Ssp_cam004_spro = tmp.sia_nroide_usua;
                                    G1Ssp_cam005_spro = tmp.sia_priape_usua;
                                    G1Ssp_cam006_spro = tmp.sia_segape_usua;
                                    G1Ssp_cam007_spro = tmp.sia_prinom_usua;
                                    G1Ssp_cam008_spro = tmp.sia_segnom_usua;
                                    G1Ssp_cam009_spro = ((DateTime)tmp.sia_fecnac_usua).ToShortDateString();
                                    G1Ssp_cam010_spro = tmp.sis_codsex_sexo;
                                    
                                }
                                else
                                {
                                    lcrValorReturn = "Código único del paciente: No existe";
                                }
                            }
                        }
                        break;

                    case "G1Sia_nroide_usua":
                        if (string.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                        {
                            lcrValorReturn = "Identificación: Es requerido";
                        }
                        else
                        {
                            EFsiausuarioatend tmp = new EFsiausuarioatend();
                            tmp = SIAValidarCodigo.fobRegBuscarIuSiausuarioatend(G1Sia_nroide_usua);
                            if (tmp != null)
                            {
                                G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                                fcrValidacion("G1Sia_idesec_usua");
                            }
                            else
                            {
                                lcrValorReturn = "Identificación: No existe";
                            }
                        }
                        break;

                    case "G1Sia_codeps_teps":
                        if (string.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            lcrValorReturn = "Código Eps/Asegurador: Es requerido";
                        }
                        else
                        {
                            EFsiatablaeps tmp = new EFsiatablaeps();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                            if (tmp != null)
                            {
                                G1Sia_deseps_teps = tmp.sia_deseps_teps;
                            }
                            else
                            {
                                lcrValorReturn = "Código Eps/Asegurador: No existe";
                            }
                        }
                        break;

                    case "G1Ssp_cam002_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam002_spro))
                        {
                            lcrValorReturn = "2.Código de Habilitación IPS primaria: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam003_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam003_spro))
                        {
                            lcrValorReturn = "3.Tipo de identificación del usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam004_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam004_spro))
                        {
                            lcrValorReturn = "4.Numero de identificación del usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam005_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam005_spro))
                        {
                            lcrValorReturn = "5.Primer apellido del usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam007_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam007_spro))
                        {
                            lcrValorReturn = "7.Primer nombre del usuario: Es requerido";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam009_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam009_spro, "9.Fecha de Nacimiento");
                        break;

                    case "G1Ssp_cam010_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam010_spro))
                        {
                            lcrValorReturn = "10.Sexo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam010_spro, ",", "M,F"))
                            {
                                lcrValorReturn = "10.Sexo: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam011_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam011_spro))
                        {
                            lcrValorReturn = "11.Codigo pertenencia étnica: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam011_spro, ",", "1,2,3,4,5,6"))
                            {
                                lcrValorReturn = "11.Codigo pertenencia étnica: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_codocu_ciuo":
                        if (string.IsNullOrWhiteSpace(G1Ssp_codocu_ciuo))
                        {
                            lcrValorReturn = "12.Codigo de ocupación: Es requerido";
                        }
                        else
                        {
                            EFspocupacionciuo tmp = new EFspocupacionciuo();
                            tmp = SSPValidarCodigo.fobRegBuscarSpocupacionciuo(G1Ssp_codocu_ciuo);
                            if (tmp != null)
                            {
                                G1Ssp_desocu_ciuo = tmp.ssp_desocu_ciuo;
                            }
                            else
                            {
                                lcrValorReturn = "12.Codigo de ocupación: No existe";
                            }
                        }
                        break;

                    case "G1Ssp_cam013_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam013_spro))
                        {
                            lcrValorReturn = "13.Codigo de nivel educativo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam013_spro, ",", "1,2,3,4,5,6,7,8,9,10,11,12,13"))
                            {
                                lcrValorReturn = "13.Codigo de nivel educativo: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam014_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam014_spro))
                        {
                            lcrValorReturn = "14.Gestacion: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam014_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "14.Gestacion: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam015_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam015_spro))
                        {
                            lcrValorReturn = "15.Sifilis Gestacional o congénita: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam015_spro, ",", "0,1,2,3,4"))
                            {
                                lcrValorReturn = "15.Sifilis Gestacional o congénita: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam016_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam016_spro))
                        {
                            lcrValorReturn = "16.Hipertension Inducida por la Gestació: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam016_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "16.Hipertension Inducida por la Gestació: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam017_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam017_spro))
                        {
                            lcrValorReturn = "17.Hipotiroidismo Congénito: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam017_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "17.Hipotiroidismo Congénito: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam018_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam018_spro))
                        {
                            lcrValorReturn = "18.Sintomatico Respiratorio: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam018_spro, ",", "0,1,2"))
                            {
                                lcrValorReturn = "18.Sintomatico Respiratorio: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam019_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam019_spro))
                        {
                            lcrValorReturn = "19.Tuberculosis Multidrogoresistente: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam019_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "19.Tuberculosis Multidrogoresistente: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam020_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam020_spro))
                        {
                            lcrValorReturn = "20.Lepra: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam020_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "20.Lepra: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam021_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam021_spro))
                        {
                            lcrValorReturn = "21.Obesidad o Desnutrición Proteico Caló: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam021_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "21.Obesidad o Desnutrición Proteico Caló: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam022_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam022_spro))
                        {
                            lcrValorReturn = "22.Mujer Victima de Maltrato: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam022_spro, ",", "0,1,2,3,4"))
                            {
                                lcrValorReturn = "22.Mujer Victima de Maltrato: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam023_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam023_spro))
                        {
                            lcrValorReturn = "23.Victima de Violencia Sexual: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam023_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "23.Victima de Violencia Sexual: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam024_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam024_spro))
                        {
                            lcrValorReturn = "24.Infecciones de Trasmisión Sexual: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam024_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "24.Infecciones de Trasmisión Sexual: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam025_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam025_spro))
                        {
                            lcrValorReturn = "25.Enfermedad Mental: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam025_spro, ",", "0,1,2,3,4,5,6,7"))
                            {
                                lcrValorReturn = "25.Enfermedad Mental: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam026_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam026_spro))
                        {
                            lcrValorReturn = "26.Cancer de Cérvix: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam026_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "26.Cancer de Cérvix: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam027_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam027_spro))
                        {
                            lcrValorReturn = "27.Cancer de Seno: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam027_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "27.Cancer de Seno: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam028_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam028_spro))
                        {
                            lcrValorReturn = "28.Fluorosis Dental: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam028_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "28.Fluorosis Dental: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam029_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam029_spro, "29.Fecha del Peso");
                        break;

                    case "G1Ssp_cam030_spro":
                        if (!(G1Ssp_cam030_spro > 0) && !((G1Ssp_cam030_spro == 999)))
                        {
                            lcrValorReturn = "30.Peso en Kilogramos: Dato no es valido";
                        }
                        else
                        {

                            //if (!Funciones.flgExisteElemento(G1Ssp_cam030_spro, ",", "VP,999"))
                            //{
                            //    lcrValorReturn = "30.Peso en Kilogramos: Dato no es valido";
                            //}

                        }
                        break;

                    case "G1Ssp_cam031_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam031_spro, "31.Fecha de la Talla");
                        break;

                    case "G1Ssp_cam032_spro":
                        if (G1Ssp_cam032_spro <= 0)
                        {
                            lcrValorReturn = "32.Talla en Centímetros: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam033_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam033_spro, "33.Fecha Probable de Parto");
                        break;

                    case "G1Ssp_cam034_spro":
                        if (!((G1Ssp_cam034_spro > 0) && (G1Ssp_cam034_spro <= 43)) && !((G1Ssp_cam034_spro == 98)) && !((G1Ssp_cam034_spro == 99)))
                        {
                            lcrValorReturn = "34.Edad Gestacional al Nacer: Debe ser entre 0 y 43";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam035_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam035_spro))
                        {
                            lcrValorReturn = "35.BCG: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam035_spro, ",", "0,1,2,3,4,5,6,7,8"))
                            {
                                lcrValorReturn = "35.BCG: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam036_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam036_spro))
                        {
                            lcrValorReturn = "36.Hepatitis B menores de 1 año: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam036_spro, ",", "0,1,2,3,4,5,6,7,8,9,10"))
                            {
                                lcrValorReturn = "36.Hepatitis B menores de 1 año: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam037_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam037_spro))
                        {
                            lcrValorReturn = "37.Pentavalente: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam037_spro, ",", "0,1,2,3,4,5,6,7,8,9"))
                            {
                                lcrValorReturn = "37.Pentavalente: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam038_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam038_spro))
                        {
                            lcrValorReturn = "38.Polio: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam038_spro, ",", "0,1,2,3,4,5,6,7,8,9,10,11"))
                            {
                                lcrValorReturn = "38.Polio: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam039_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam039_spro))
                        {
                            lcrValorReturn = "39.DPT menores de 5 años: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam039_spro, ",", "0,1,2,3,4,5,6,7,8,9,10,11"))
                            {
                                lcrValorReturn = "39.DPT menores de 5 años: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam040_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam040_spro))
                        {
                            lcrValorReturn = "40.Rotavirus: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam040_spro, ",", "0,1,2,3,4,5,6,7,8"))
                            {
                                lcrValorReturn = "40.Rotavirus: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam041_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam041_spro))
                        {
                            lcrValorReturn = "41.Neumococo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam041_spro, ",", "0,1,2,3,4,5,6,7,8,9"))
                            {
                                lcrValorReturn = "41.Neumococo: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam042_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam042_spro))
                        {
                            lcrValorReturn = "42.Influenza Niños: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam042_spro, ",", "0,1,2,3,4,5,6,7,8,9"))
                            {
                                lcrValorReturn = "42.Influenza Niños: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam043_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam043_spro))
                        {
                            lcrValorReturn = "43.Fiebre Amarilla niños de 1 año: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam043_spro, ",", "0,1,2,3,4,5,6,7"))
                            {
                                lcrValorReturn = "43.Fiebre Amarilla niños de 1 año: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam044_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam044_spro))
                        {
                            lcrValorReturn = "44.Hepatitis A: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam044_spro, ",", "0,1,2,3,4,5,6,7"))
                            {
                                lcrValorReturn = "44.Hepatitis A: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam045_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam045_spro))
                        {
                            lcrValorReturn = "45.Triple Viral Niños: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam045_spro, ",", "0,1,2,3,4,5,6,7,8"))
                            {
                                lcrValorReturn = "45.Triple Viral Niños: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam046_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam046_spro))
                        {
                            lcrValorReturn = "46.Virus del Papiloma Humano (VPH): Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam046_spro, ",", "0,1,2,3,4,5,6,7,8,9"))
                            {
                                lcrValorReturn = "46.Virus del Papiloma Humano (VPH): Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam047_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam047_spro))
                        {
                            lcrValorReturn = "47.TD o TT Mujeres en Edad Fértil 15 a 4: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam047_spro, ",", "0,1,2,3,4,5,6,7,8,9,10,11"))
                            {
                                lcrValorReturn = "47.TD o TT Mujeres en Edad Fértil 15 a 4: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam048_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam048_spro))
                        {
                            lcrValorReturn = "48.Control de Placa Bacteriana: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam048_spro, ",", "0,1,2,3,4,5,6,7,8"))
                            {
                                lcrValorReturn = "48.Control de Placa Bacteriana: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam049_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam049_spro, "49.Fecha atención parto o cesárea");
                        break;

                    case "G1Ssp_cam050_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam050_spro, "50.Fecha salida de la atención del parto");
                        break;

                    case "G1Ssp_cam051_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam051_spro, "51.Fecha de consejería en Lactancia Mate");
                        break;

                    case "G1Ssp_cam052_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam052_spro, "52.Control Recién Nacido");
                        break;

                    case "G1Ssp_cam053_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam053_spro, "53.Planificacion Familiar Primera vez");
                        break;

                    case "G1Ssp_cam054_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam054_spro))
                        {
                            lcrValorReturn = "54.Suministro de Método Anticonceptivo: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam054_spro, ",", "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20"))
                            {
                                lcrValorReturn = "54.Suministro de Método Anticonceptivo: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam055_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam055_spro, "55.Fecha Suministro de Método Anticoncep");
                        break;

                    case "G1Ssp_cam056_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam056_spro, "56.Control Prenatal de Primera vez");
                        break;

                    case "G1Ssp_cam057_spro":
                        if (G1Ssp_cam057_spro <= 0)
                        {
                            lcrValorReturn = "57.Control Prenatal: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam058_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam058_spro, "58.ultimo Control Prenatal");
                        break;

                    case "G1Ssp_cam059_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam059_spro))
                        {
                            lcrValorReturn = "59.Suministro de acido Fólico en el ulti: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam059_spro, ",", "0,1,2,3,4,5,6"))
                            {
                                lcrValorReturn = "59.Suministro de acido Fólico en el ulti: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam060_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam060_spro))
                        {
                            lcrValorReturn = "60.Suministro de Sulfato Ferroso en el u: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam060_spro, ",", "0,1,2,3,4,5,6"))
                            {
                                lcrValorReturn = "60.Suministro de Sulfato Ferroso en el u: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam061_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam061_spro))
                        {
                            lcrValorReturn = "61.Suministro de Carbonato de Calcio en: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam061_spro, ",", "0,1,2,3,4,5,6"))
                            {
                                lcrValorReturn = "61.Suministro de Carbonato de Calcio en: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam062_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam062_spro, "62.Valoracion de la Agudeza Visual");
                        break;

                    case "G1Ssp_cam063_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam063_spro, "63.Consulta por Oftalmología");
                        break;

                    case "G1Ssp_cam064_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam064_spro, "64.Fecha Diagnostico Desnutrición Protei");
                        break;

                    case "G1Ssp_cam065_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam065_spro, "65.Consulta Mujer o Menor Victima del Ma");
                        break;

                    case "G1Ssp_cam066_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam066_spro, "66.Consulta Victimas de Violencia Sexual");
                        break;

                    case "G1Ssp_cam067_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam067_spro, "67.Consulta Nutrición");
                        break;

                    case "G1Ssp_cam068_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam068_spro, "68.Consulta de Psicología");
                        break;

                    case "G1Ssp_cam069_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam069_spro, "69.Consulta de Crecimiento y Desarrollo");
                        break;

                    case "G1Ssp_cam070_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam070_spro))
                        {
                            lcrValorReturn = "70.Suministro de Sulfato Ferroso en la u: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam070_spro, ",", "0,1,2,3,4,5,6"))
                            {
                                lcrValorReturn = "70.Suministro de Sulfato Ferroso en la u: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam071_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam071_spro))
                        {
                            lcrValorReturn = "71.Suministro de Vitamina A en la ultima: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam071_spro, ",", "0,1,2,3,4,5,6"))
                            {
                                lcrValorReturn = "71.Suministro de Vitamina A en la ultima: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam072_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam072_spro, "72.Consulta de Joven Primera vez");
                        break;

                    case "G1Ssp_cam073_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam073_spro, "73.Consulta de Adulto Primera vez");
                        break;

                    case "G1Ssp_cam074_spro":
                        if (G1Ssp_cam074_spro <= 0)
                        {
                            lcrValorReturn = "74.Preservativos entregados a pacientes: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam075_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam075_spro, "75.Asesoria Pre test Elisa para VIH");
                        break;

                    case "G1Ssp_cam076_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam076_spro, "76.Asesoria Pos test Elisa para VIH");
                        break;

                    case "G1Ssp_cam077_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam077_spro))
                        {
                            lcrValorReturn = "77.Paciente con Diagnostico de: Ansiedad: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam077_spro, ",", "0,1,2,3,4,5,6,7"))
                            {
                                lcrValorReturn = "77.Paciente con Diagnostico de: Ansiedad: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam078_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam078_spro, "78.Fecha Antígeno de Superficie Hepatiti");
                        break;

                    case "G1Ssp_cam079_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam079_spro))
                        {
                            lcrValorReturn = "79.Resultado Antígeno de Superficie Hepa: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam079_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "79.Resultado Antígeno de Superficie Hepa: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam080_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam080_spro, "80.Fecha Serología para Sífilis");
                        break;

                    case "G1Ssp_cam081_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam081_spro))
                        {
                            lcrValorReturn = "81.Resultado Serología para Sífilis: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam081_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "81.Resultado Serología para Sífilis: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam082_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam082_spro, "82.Fecha de Toma de Elisa para VIH");
                        break;

                    case "G1Ssp_cam083_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam083_spro))
                        {
                            lcrValorReturn = "83.Resultado Elisa para VIH: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam083_spro, ",", "0,1,2,3,4"))
                            {
                                lcrValorReturn = "83.Resultado Elisa para VIH: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam084_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam084_spro, "84.Fecha TSH Neonatal");
                        break;

                    case "G1Ssp_cam085_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam085_spro))
                        {
                            lcrValorReturn = "85.Resultado de TSH Neonatal: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam085_spro, ",", "0,1,2,3"))
                            {
                                lcrValorReturn = "85.Resultado de TSH Neonatal: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam086_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam086_spro))
                        {
                            lcrValorReturn = "86.Tamizaje Cáncer de Cuello Uterino: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam086_spro, ",", "0,1,2,3,4,5,6,7,8,9"))
                            {
                                lcrValorReturn = "86.Tamizaje Cáncer de Cuello Uterino: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam087_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam087_spro, "87.Citologia Cervico uterina");
                        break;

                    case "G1Ssp_cam088_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam088_spro))
                        {
                            lcrValorReturn = "88.Citologia Cervico uterina Resultados: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam088_spro, ",", "1,2,3,4,5,6,7,8,9,10,11,99,98"))
                            {
                                lcrValorReturn = "88.Citologia Cervico uterina Resultados: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam089_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam089_spro))
                        {
                            lcrValorReturn = "89.Calidad en la Muestra de Citología Ce: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam089_spro, ",", "0,1,2,3,99,98"))
                            {
                                lcrValorReturn = "89.Calidad en la Muestra de Citología Ce: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam090_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam090_spro))
                        {
                            lcrValorReturn = "90.Codigo de habilitación IPS donde se t: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam090_spro, ",", "99,98"))
                            {
                                lcrValorReturn = "90.Codigo de habilitación IPS donde se t: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam091_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam091_spro, "91.Fecha Colposcopia");
                        break;

                    case "G1Ssp_cam092_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam092_spro))
                        {
                            lcrValorReturn = "92.Codigo de habilitación IPS donde se t: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam092_spro, ",", "99,98"))
                            {
                                lcrValorReturn = "92.Codigo de habilitación IPS donde se t: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam093_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam093_spro, "93.Fecha Biopsia Cervical");
                        break;

                    case "G1Ssp_cam094_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam094_spro))
                        {
                            lcrValorReturn = "94.Resultado de Biopsia Cervical: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam094_spro, ",", "0,1,2,3,4,5,99,98"))
                            {
                                lcrValorReturn = "94.Resultado de Biopsia Cervical: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam095_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam095_spro))
                        {
                            lcrValorReturn = "95.Codigo de habilitación IPS donde se t: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam095_spro, ",", "99,98"))
                            {
                                lcrValorReturn = "95.Codigo de habilitación IPS donde se t: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam096_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam096_spro, "96.Fecha Mamografía");
                        break;

                    case "G1Ssp_cam097_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam097_spro))
                        {
                            lcrValorReturn = "97.Resultado Mamografía: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam097_spro, ",", "0,1,2,3,4,5,6,99,98"))
                            {
                                lcrValorReturn = "97.Resultado Mamografía: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam098_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam098_spro))
                        {
                            lcrValorReturn = "98.Codigo de habilitación IPS donde se t: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam098_spro, ",", "99,98"))
                            {
                                lcrValorReturn = "98.Codigo de habilitación IPS donde se t: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam099_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam099_spro, "99.Fecha Toma Biopsia Seno por BACAF");
                        break;

                    case "G1Ssp_cam100_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam100_spro, "100.Fecha Resultado Biopsia Seno por BAC");
                        break;

                    case "G1Ssp_cam101_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam101_spro))
                        {
                            lcrValorReturn = "101.Biopsia Seno por BACAF: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam101_spro, ",", "0,1,2,3,4,99,98"))
                            {
                                lcrValorReturn = "101.Biopsia Seno por BACAF: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam102_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam102_spro))
                        {
                            lcrValorReturn = "102.Codigo de habilitación IPS donde se: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam102_spro, ",", "99,98"))
                            {
                                lcrValorReturn = "102.Codigo de habilitación IPS donde se: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam103_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam103_spro, "103.Fecha Toma de Hemoglobina");
                        break;

                    case "G1Ssp_cam104_spro":
                        if (G1Ssp_cam104_spro <= 0)
                        {
                            lcrValorReturn = "104.Hemoglobina: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam105_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam105_spro, "105.Fecha de la Toma de Glicemia Basal");
                        break;

                    case "G1Ssp_cam106_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam106_spro, "106.Fecha Creatinina");
                        break;

                    case "G1Ssp_cam107_spro":
                        if (G1Ssp_cam107_spro <= 0)
                        {
                            lcrValorReturn = "107.Creatinina: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam108_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam108_spro, "108.Fecha Hemoglobina Glicosilada");
                        break;

                    case "G1Ssp_cam109_spro":
                        if (G1Ssp_cam109_spro <= 0)
                        {
                            lcrValorReturn = "109.Hemoglobina Glicosilada: Debe ser mayor que cero";
                        }
                        else
                        {
                        }
                        break;

                    case "G1Ssp_cam110_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam110_spro, "110.Fecha Toma de Microalbuminuria");
                        break;

                    case "G1Ssp_cam111_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam111_spro, "111.Fecha Toma de HDL");
                        break;

                    case "G1Ssp_cam112_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam112_spro, "112.Fecha Toma de Baciloscopia de Diagnostico");
                        break;

                    case "G1Ssp_cam113_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam113_spro))
                        {
                            lcrValorReturn = "113.Baciloscopia de Diagnostico: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam113_spro, ",", "0,1,2,3,4"))
                            {
                                lcrValorReturn = "113.Baciloscopia de Diagnostico: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam114_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam114_spro))
                        {
                            lcrValorReturn = "114.Tratamiento para Hipotiroidismo Cong: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam114_spro, ",", "0,1,2,3,4,5,6,7"))
                            {
                                lcrValorReturn = "114.Tratamiento para Hipotiroidismo Cong: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam115_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam115_spro))
                        {
                            lcrValorReturn = "115.Tratamiento para Sífilis gestacional: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam115_spro, ",", "0,1,2,3,4,5,6,7"))
                            {
                                lcrValorReturn = "115.Tratamiento para Sífilis gestacional: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam116_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam116_spro))
                        {
                            lcrValorReturn = "116.Tratamiento para Sífilis Congénita: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam116_spro, ",", "0,1,2,3,4,5,6,7"))
                            {
                                lcrValorReturn = "116.Tratamiento para Sífilis Congénita: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam117_spro":
                        if (string.IsNullOrWhiteSpace(G1Ssp_cam117_spro))
                        {
                            lcrValorReturn = "117.Tratamiento para Lepra: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Ssp_cam117_spro, ",", "0,1,2,3,4,5,6,7,8"))
                            {
                                lcrValorReturn = "117.Tratamiento para Lepra: Dato no es valido";
                            }
                        }
                        break;

                    case "G1Ssp_cam118_spro":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Ssp_cam118_spro, "118.Fecha de Terminación Tratamiento par");
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
    }
}
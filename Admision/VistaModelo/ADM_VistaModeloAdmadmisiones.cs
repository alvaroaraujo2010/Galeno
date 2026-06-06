//- MARMOTA-GENCODE: VERSION 2.0 - 01/07/2013 09:43:16 AM
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
using Sistema.VistaModelo;
using Sistema.Clases;
using Datos.Modelos;
using Admision.Modelo;

namespace Admision.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admregadmision</para>
    /// <para>DESCRIPCION:
    ///  Tabla del modulo de facturación médica (fcm) - Registrar todas
    ///  las admisiones de pacientes en la institución IPS;
    /// </para>
    /// </summary>
    public class VistaModeloAdmadmisiones : VistaModeloAdmadmisionesBase
    {
        //-------------------------------------------------
        // Variables para varios usos
        //-------------------------------------------------
        #region Variables
        /// <summary>
        /// Tipo asegurador servicio de salud segun contratos
        /// </summary>
        public String gcrSia_tipase_sita = String.Empty;
        #endregion
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
                    var lcrCodigo1 = G1Cit_codasi_mcit;
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        Adicionar();
                        G1Cit_codasi_mcit = lcrCodigo1;
                        fcrValidacion("G1Cit_codasi_mcit");
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
            string lcrValorReturn = string.Empty;
            String lcrNumeroRegistro = "ADMISION";
            String lcrCodigoError = String.Empty;
            String lcrNombreCampo = String.Empty;
            String lcrNivelError = "ALTO";
            String lcrImgNivelError = "Edt_hist_vista_anulado.png";

            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Sia_idesec_usua":
                        #region Datos
                        lcrNombreCampo = "Código único del paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";
                        if (string.IsNullOrWhiteSpace(G1Sia_idesec_usua))
                        {
                            lcrValorReturn = "Código único del paciente: Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(G1Sia_idesec_usua);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_idesec_usua))
                            {
                                G1Hcl_nrohis_hicl = tmp.hcl_nrohis_hicl;
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nroide_usua = tmp.sia_nroide_usua;
                                G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                                if (String.IsNullOrWhiteSpace(G1Sia_tipusu_regi)) { G1Sia_tipusu_regi = tmp.sia_tipusu_regi; }
                                if (String.IsNullOrWhiteSpace(G1Sia_tippob_tpob)) { G1Sia_tippob_tpob = tmp.sia_tippob_tpob; }
                                if (String.IsNullOrWhiteSpace(G1Cto_seccon_cont)) { G1Cto_seccon_cont = tmp.cto_seccon_cont; }
                                if (String.IsNullOrWhiteSpace(G1Cto_nrocon_cont)) { G1Cto_nrocon_cont = tmp.cto_nrocon_cont; }
                                if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps)) { G1Sia_codeps_teps = tmp.sia_codeps_teps; }
                                if (String.IsNullOrWhiteSpace(G1Sia_nivsbn_nsbn)) { G1Sia_nivsbn_nsbn = tmp.sia_nivsbn_nsbn; }
                                if (G1Sia_tipusu_regi != "1")
                                {
                                    G1Sia_nivcon_ncon = String.Empty;
                                    G1Sia_tipafi_tafi = String.Empty;
                                }
                                else 
                                {
                                    if (String.IsNullOrWhiteSpace(G1Sia_nivcon_ncon)) { G1Sia_nivcon_ncon = tmp.sia_nivcon_ncon; }
                                    if (String.IsNullOrWhiteSpace(G1Sia_tipafi_tafi)) { G1Sia_tipafi_tafi = tmp.sia_tipafi_tafi; }
                                }
                                //G1Sis_idemun_muni = tmp.sis_idemun_muni; 
                                G1Sia_edapac_usua = (int)tmp.sia_edapac_usua;
                                G1Sia_codmed_tmed = tmp.sia_codmed_tmed;
                                G1Sia_fecnac_usua = ((DateTime)tmp.sia_fecnac_usua).ToShortDateString();
                                G1Sis_codsex_sexo = tmp.sis_codsex_sexo;
                                if (String.IsNullOrWhiteSpace(G1Sia_codcat_ceat)) { G1Sia_codcat_ceat = tmp.sia_codcat_ceat; }
                                G1Sys_codusu_usux = tmp.sys_codusu_usux;
                                flgGenerarDatosEdad();
                                /*
                                if (Funciones.flgExisteElemento(G1Sia_tipide_tide, ",", "AS,CC") && G1Sia_edaano_usua <= 17)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Tipo de identificación no corresponde con fecha de nacimiento";
                                }
                                else if (Funciones.flgExisteElemento(G1Sia_tipide_tide, ",", "MS,TI,RC") && G1Sia_edaano_usua >= 18)
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Tipo de identificación no corresponde con fecha de nacimiento";
                                }
                                */
                                // cuando es adicionar revisar que no exista alguan anterior abierta
                                if (GlgSIS_ModoAdicion==true)
                                {
                                    var lbReg = ADMValidarCodigo.fobRegBuscarAdmregadmisionFinAtencion(G1Sia_idesec_usua, "1", "1");
                                     if (lbReg != null) 
                                     { 
                                         lcrValorReturn = "Numero de Identificación: Existe una admisión abierto par el paciente (" + 
                                                                            lbReg.adm_secadm_rgad.Trim() + ")"; 
                                     }
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Código único del paciente: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipide_tide":
                        #region Datos
                        lcrNombreCampo = "Tipo identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (string.IsNullOrWhiteSpace(G1Sia_tipide_tide))
                        {
                            lcrValorReturn = "Tipo identificación: Es requerido";
                        }
                        else
                        {
                            G1Sia_tipide_tide = G1Sia_tipide_tide.ToUpper();

                            if (!Funciones.flgExisteElemento(G1Sia_tipide_tide, ",", "PE,AS,CC,CD,CE,MS,UN,RC,TI,NV"))
                            {
                                lcrValorReturn = "Tipo identificación: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_nroide_usua":
                        #region Datos
                        lcrNombreCampo = "Numero de Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";
                        if (string.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                        {
                            lcrValorReturn = "Numero de Identificación: Es requerido";
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

                    case "G1Hcl_nrohis_hicl":
                    	#region HCL_NROHIS_HICL: Historia Clínica
                        lcrNombreCampo = "Numero de historia clínica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                    	if (!string.IsNullOrWhiteSpace(G1Hcl_nrohis_hicl))
                    	{
                            var tmp = HCLValidarCodigo.fobRegBuscarHclmaestrohiscl(G1Hcl_nrohis_hicl);
                            if (tmp ==null || String.IsNullOrWhiteSpace(tmp.hcl_nrohis_hicl))
                            {
                            	lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                    	}
                    	break;
                    	#endregion

                    case "G1Adm_fecadm_rgad":
                        #region Datos
                        lcrNombreCampo = "Fecha Admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Adm_fecadm_rgad, "Fecha Admisión");
                        if (G1Adm_codtat_tatn == "2") // si es admitido por hospitalizacion 
                        {
                            G1Adm_fechos_rgad = G1Adm_fecadm_rgad;
                            G1Adm_horhos_rgad = G1Adm_horadm_rgad;
                        }
                        break;
                        #endregion

                    case "G1Adm_horadm_rgad":
                        #region Datos
                        lcrNombreCampo = "Hora Admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Adm_horadm_rgad, "12", ":", "Hora de Admisión");
                        if (G1Adm_codtat_tatn == "2") // si es admitido por hospitalizacion 
                        {
                            G1Adm_fechos_rgad = G1Adm_fecadm_rgad;
                            G1Adm_horhos_rgad = G1Adm_horadm_rgad;
                        }
                        break;
                        #endregion

                    case "G1Adm_pacemb_rgad":
                        #region Datos
                        lcrNombreCampo = "Embarazada SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        flgGenerarDatosEdad();
                        lcrValorReturn = SiaValidarDatos.fcrEmbarazadaSINO(G1Adm_pacemb_rgad, G1Sia_edaano_usua, 
                                                                            G1Sia_codmed_tmed, G1Sis_codsex_sexo, lcrNombreCampo);
                        break;
                        #endregion

                    case "G1Adm_reingr_rgad":
                        #region Datos
                        lcrNombreCampo = "Ingreso o reingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (string.IsNullOrWhiteSpace(G1Adm_reingr_rgad))
                        {
                            lcrValorReturn = "Ingreso o reingreso: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_reingr_rgad, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = "Ingreso o Reingreso: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_codoad_toad":
                        #region Datos
                        lcrNombreCampo = "Código origen admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (string.IsNullOrWhiteSpace(G1Adm_codoad_toad))
                        {
                            lcrValorReturn = "Código origen admisión: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_codoad_toad, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = "Código origen admisión: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codare_aser":
                        #region Datos
                        lcrNombreCampo = "Código área de servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        if (string.IsNullOrWhiteSpace(G1Sia_codare_aser))
                        {
                            lcrValorReturn = "Código Área de servicios: Es requerido";
                        }
                        else
                        {
                            EFsiaareapreservi tmp = new EFsiaareapreservi();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G1Sia_codare_aser);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desare_aser))
                            {
                                G1Sia_desare_aser = tmp.sia_desare_aser;
                                //G1Sia_codcat_ceat = tmp.sia_codcat_ceat;
                                //G1Adm_codtat_tatn = tmp.adm_codtat_tatn;
                            }
                            else
                            {
                                lcrValorReturn = "Código Área de servicios: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_areing_aser":
                        #region Datos
                        lcrNombreCampo = "Código área de ingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (string.IsNullOrWhiteSpace(G1Sia_areing_aser))
                        {
                            lcrValorReturn = "Código área de ingreso: Es requerido";
                        }
                        else
                        {
                            EFsiaareapreservi tmp = new EFsiaareapreservi();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G1Sia_areing_aser);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desare_aser))
                            {
                                //G1Sia_codare_aser = tmp.sia_codare_aser;
                                G1Desia_areing_aser = tmp.sia_desare_aser;
                                //G1Sia_codcat_ceat = tmp.sia_codcat_ceat;
                                //G1Adm_codtat_tatn = tmp.adm_codtat_tatn;
                            }
                            else
                            {
                                lcrValorReturn = "Código Área de Ingreso: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_codtat_tatn":
                        #region Datos
                        lcrNombreCampo = "Tipo de atención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (string.IsNullOrWhiteSpace(G1Adm_codtat_tatn))
                        {
                            lcrValorReturn = "Tipo de atención: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_codtat_tatn, ",", "2,3"))
                            {
                                lcrValorReturn = "Tipo de atención: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_codcex_tcex":
                        #region Datos
                        lcrNombreCampo = "Causa Externa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (string.IsNullOrWhiteSpace(G1Adm_codcex_tcex))
                        {
                            lcrValorReturn = "Causa Externa: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_codcex_tcex, ",", "01,02,03,04,05,06,07,08,09,10,11,12,13,14,15"))
                            {
                                lcrValorReturn = "Causa Externa: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Hos_codcam_caho":
                        #region Datos
                        lcrNombreCampo = "Código Cama";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (string.IsNullOrWhiteSpace(G1Hos_codcam_caho))
                        {
                            lcrValorReturn = "Código Cama: Es requerido";
                        }
                        else
                        {
                            var tmp = HOSValidarCodigo.fobRegBuscarHoscamasareas(G1Hos_codcam_caho);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hos_descam_caho))
                            {
                                G1Hos_descam_caho = tmp.hos_descam_caho;
                                G1Hos_codsec_hsec = tmp.hos_codsec_hsec;
                            }
                            else
                            {
                                lcrValorReturn = "Código Cama: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_dixing_tdia":
                        #region Datos
                        lcrNombreCampo = "Diagnostico ingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (String.IsNullOrWhiteSpace(G1Sia_dixing_tdia))
                        {
                            lcrValorReturn = "Diagnostico Ingreso: Es requerido";
                        }
                        else
                        {
                            G1Sia_dixing_tdia = G1Sia_dixing_tdia.ToUpper();
                            EFsiadiagnosticos tmp = new EFsiadiagnosticos();
                            tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_dixing_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                            {
                                G1Sia_desdia_tdia = tmp.sia_desdia_tdia;
                                lcrValorReturn = SiaValidarDatos.fcrPertinenciaDiagnostico(G1Sia_dixing_tdia, G1Sia_edadia_usua, "3",
                                                                                          G1Sis_codsex_sexo, "//", "Diagnostico ingreso");
                            }
                            else
                            {
                                lcrValorReturn = "Diagnostico Ingreso: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipdxp_tdix":
                        #region SIA_TIPDXP_TDIX: Tipo diagnostico principal
                        lcrNombreCampo = "Tipo diagnostico de ingreso";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (String.IsNullOrWhiteSpace(G1Sia_tipdxp_tdix))
                        {
                            lcrValorReturn = "Tipo diagnostico ingreso : Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiatipodiagprin(G1Sia_tipdxp_tdix);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdxp_tdix))
                            {
                                G1Sia_desdxp_tdix = tmp.sia_desdxp_tdix;
                            }
                            else
                            {
                                lcrValorReturn = "Tipo diagnostico ingreso : No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_caucon_rgad":
                        #region Datos
                        lcrNombreCampo = "Motivo textual de Consulta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (string.IsNullOrWhiteSpace(G1Adm_caucon_rgad))
                        {
                            lcrValorReturn = "Motivo textual de Consulta: Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Adm_fechos_rgad":
                        #region Datos
                        lcrNombreCampo = "Fecha Hospitalización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (G1Adm_codtat_tatn == "2") // si es admitido por hospitalizacion 
                        {
                            G1Adm_fechos_rgad = G1Adm_fecadm_rgad;
                            G1Adm_horhos_rgad = G1Adm_horadm_rgad;
                            lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Adm_fechos_rgad, "Fecha Hospitalización");
                        }
                        break;
                        #endregion

                    case "G1Adm_horhos_rgad":
                        #region Datos
                        lcrNombreCampo = "Hora Hospitalización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (G1Adm_codtat_tatn == "2") // si es admitido por hospitalizacion 
                        {
                            G1Adm_fechos_rgad = G1Adm_fecadm_rgad;
                            G1Adm_horhos_rgad = G1Adm_horadm_rgad;
                            lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Adm_horhos_rgad, "12", ":", "Hora Hospitalización");
                        }
                        break;
                        #endregion

                    case "G1Cto_seccon_cont":
                        #region Datos
                        lcrNombreCampo = "Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (string.IsNullOrWhiteSpace(G1Cto_seccon_cont))
                        {
                            lcrValorReturn = "Secuencial de Contrato: Es requerido";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cto_nrocon_cont))
                            {
                                G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                G1Cto_descon_cont = tmp.cto_descon_cont;
                                G1Sia_tipusu_regi = tmp.sia_tipusu_regi;
                                G1Sis_idterc_sitr = String.IsNullOrWhiteSpace(G1Sis_idterc_sitr) ? tmp.sis_idterc_sitr : G1Sis_idterc_sitr;
                                fcrValidacion("G1Sis_idterc_sitr");

                                if (tmp.cto_estcon_cont == "2") // Contrato inactivo
                                {
                                    lcrValorReturn = "Secuencial de Contrato: esta inactivo";
                                }
                                else
                                {
                                    gcrSia_tipase_sita = tmp.sia_tipase_sita;
                                    if (tmp.cto_modeps_cont == "1") // cuando se permite cambiar la eps
                                    {
                                        if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps)) { G1Sia_codeps_teps = tmp.sia_codeps_teps; }
                                    }
                                    else
                                    {
                                        G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                    }
                                    // Validar si el contrato verifica el usuario en maestro afiliados
                                    if (tmp.cto_idvalc_cont == "1" && !String.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                                    {
                                        lcrCodigoError = "A01";
                                        lcrValorReturn = CTOValidarCodigo.fcrValidarUsuarioEnContrato(G1Sia_tipide_tide, G1Sia_nroide_usua, tmp);
                                    }
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Secuencial de Contrato: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_nrocon_cont":
                        #region Datos
                        lcrNombreCampo = "Número Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (string.IsNullOrWhiteSpace(G1Cto_nrocon_cont))
                        {
                            lcrValorReturn = "Número Contrato: Es requerido";
                        }
                        else
                        {
                        }
                        break;
                        #endregion

                    case "G1Sia_codeps_teps":
                        #region Datos
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (string.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            lcrValorReturn = "Código EPS: Es requerido";
                        }
                        else
                        {
                            G1Sia_codeps_teps = G1Sia_codeps_teps.ToUpper(); 
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

                    case "G1Sis_idterc_sitr":
                        #region SIS_IDTERC_SITR: Código tercero Adquirente
                        lcrNombreCampo = "Código Adquirente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A75";
                        if (String.IsNullOrWhiteSpace(G1Sis_idterc_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSismaesterceros(G1Sis_idterc_sitr);
                            if (tmp != null)
                            {
                                G1Sis_razsoc_sitr = tmp.sis_razsoc_sitr;
                                G1Sis_numide_sitr = tmp.sis_numide_sitr;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_numide_sitr":
                        #region SIS_IDTERC_SITR: Nit Adquirente
                        lcrNombreCampo = "Nit del Adquirente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A36";
                        if (String.IsNullOrWhiteSpace(G1Sis_numide_sitr))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SISValidarCodigo.fobRegBuscarSismaestercerosNit(G1Sis_numide_sitr);
                            if (tmp != null)
                            {
                                G1Sis_razsoc_sitr = tmp.sis_razsoc_sitr;
                                G1Sis_numide_sitr = tmp.sis_numide_sitr;
                                G1Sis_idterc_sitr = tmp.sis_idterc_sitr;
                                // cargar datos del adquirente
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }

                            if (tmpRegcontr != null)
                            {
                                if (tmpRegcontr.cto_fcdian_cont == "1" && G1Sis_numide_sitr == "NA")
                                {
                                    lcrValorReturn = lcrNombreCampo + ": Datos del tercero contable no asignado (se requiere para factura DIAN)";
                                }
                            }
                        }
                        break;
                    #endregion

                    case "G1Sia_codpfa_prof":
                        #region Datos
                        lcrNombreCampo = "Código Profesional Autoriza";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (string.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
                        {
                            lcrValorReturn = "Código Profesional Autoriza: Es requerido";
                        }
                        else
                        {
                            G1Sia_codpfa_prof = G1Sia_codpfa_prof.ToUpper();

                            var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nompro_prof))
                            {
                                G1Sia_nompro_prof = tmp.sia_nompro_prof;
                                G1Sys_codusu_usux = tmp.sys_codusu_usux;
                            }
                            else
                            {
                                lcrValorReturn = "Código Profesional Autoriza: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_nroaut_rgad":
                        #region Datos
                        lcrNombreCampo = "Numero de autorizazión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (!string.IsNullOrWhiteSpace(G1Adm_nroaut_rgad))
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Adm_nroaut_rgad, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no permitidos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_nropol_rgad":
                        #region Datos
                        lcrNombreCampo = "Numero Poliza";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A36";
                        if (!String.IsNullOrWhiteSpace(gcrSia_tipase_sita) && gcrSia_tipase_sita =="03") // 03 =Accidentes SOAT
                        {
                            if (String.IsNullOrWhiteSpace(G1Adm_nropol_rgad))
                            {
                                lcrValorReturn = lcrNombreCampo + ": El valor es obligatorio para seguro contra accidentes";
                            }
                        }
                        if (!String.IsNullOrWhiteSpace(G1Adm_nropol_rgad))
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Adm_nropol_rgad, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no permitidos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipusu_regi":
                        #region Datos
                        lcrNombreCampo = "Régimen salud usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A24";
                        if (string.IsNullOrWhiteSpace(G1Sia_tipusu_regi))
                        {
                            lcrValorReturn = "Régimen salud usuario: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_tipusu_regi, ",", "1,2,3,4,5"))
                            {
                                lcrValorReturn = "Régimen salud usuario: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipafi_tafi":
                        #region Datos
                        lcrNombreCampo = "Tipo Afiliado";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A25";
                        if (G1Sia_tipusu_regi == "1")
                        {
                            if (!String.IsNullOrWhiteSpace(G1Sia_tipafi_tafi))
                            {
                                if (!Funciones.flgExisteElemento(G1Sia_tipafi_tafi, ",", "C,B,A"))
                                {
                                    lcrValorReturn = "Tipo Afiliado: Dato no es valido";
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Tipo Afiliado: es requerido";
                            }
                        }
                        else 
                        {
                            if (!String.IsNullOrWhiteSpace(G1Sia_tipafi_tafi))
                            {
                                lcrValorReturn = "Tipo Afiliado: Solo aplica pra contributivo";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_nivsbn_nsbn":
                        #region Datos
                        lcrNombreCampo = "Nivel Sisben";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A26";
                        if (!String.IsNullOrWhiteSpace(G1Sia_nivsbn_nsbn))
                        {
                            if (G1Sia_tipusu_regi == "2")
                            {
                                if (!Funciones.flgExisteElemento(G1Sia_nivsbn_nsbn, ",", "1,2,3,4,N"))
                                {
                                    lcrValorReturn = "Nivel Sisben: Dato no es valido";
                                }
                            }
                            else
                            {
                                if (G1Sia_nivsbn_nsbn != "N")
                                {
                                    lcrValorReturn = "Nivel Sisben: Valor diferenente de N solo aplica pra regimen subsidiado";
                                }
                            }
                        }
                        else 
                        {
                            lcrValorReturn = "Nivel Sisben: Es requerido";
                        }
                        break;
                        #endregion

                    case "G1Sia_tippob_tpob":
                        #region Datos
                        lcrNombreCampo = "Tipo población especial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A27";
                        if (string.IsNullOrWhiteSpace(G1Sia_tippob_tpob))
                        {
                            lcrValorReturn = "Tipo población especial: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_tippob_tpob, ",", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22"))
                            {
                                lcrValorReturn = "Tipo población especial: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_nivcon_ncon":
                        #region Datos
                        lcrNombreCampo = "Nivel Contributivo";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A28";
                        if (G1Sia_tipusu_regi == "1")
                        {
                            if (!String.IsNullOrWhiteSpace(G1Sia_nivcon_ncon))
                            {
                                if (!Funciones.flgExisteElemento(G1Sia_nivcon_ncon, ",", "1,2,3"))
                                {
                                    lcrValorReturn = "Nivel Contributivo: Dato no es valido";
                                }
                            }
                            else 
                            {
                                lcrValorReturn = "Nivel Contributivo: Dato es requerido";
                            }
                        }
                        else 
                        {
                            if (!String.IsNullOrWhiteSpace(G1Sia_nivcon_ncon))
                            {
                                lcrValorReturn = "Nivel Contributivo: solo aplica para contributivo";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_idemun_muni":
                        #region Datos
                        lcrNombreCampo = "Municipio Origen";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A29";
                        if (!string.IsNullOrWhiteSpace(G1Sis_idemun_muni))
                        {
                            EFsistabmunicipio tmp = new EFsistabmunicipio();
                            tmp = SISValidarCodigo.fobRegBuscarSistabmunicipio(G1Sis_idemun_muni);
                            if (tmp != null)
                            {
                                G1Sis_nommun_muni = tmp.sis_nommun_muni;
                            }
                            else
                            {
                                lcrValorReturn = "Municipio Origen: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codips_tips":
                        #region Datos
                        lcrNombreCampo = "IPS Origen";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A30";
                        if (!string.IsNullOrWhiteSpace(G1Sia_codips_tips))
                        {
                            EFsiatablaips tmp = new EFsiatablaips();
                            tmp = SIAValidarCodigo.fobRegBuscarSiatablaips(G1Sia_codips_tips);
                            if (tmp != null)
                            {
                                G1Sia_desips_tips = tmp.sia_desips_tips;
                            }
                            else
                            {
                                lcrValorReturn = "IPS Origen: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_nroreg_tria":
                        #region Datos
                        lcrNombreCampo = "Codigo Triage";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A31";
                        if (G1Adm_codoad_toad == "1" || G1Adm_codtat_tatn == "5") // Origen adm urgancia o  tipo atencion urgencias
                        {
                            if (String.IsNullOrWhiteSpace(G1Adm_nroreg_tria))
                            {
                                lcrValorReturn = "Codigo Triage: Es requerido";
                            }
                            else
                            {
                                var tmp = ADMValidarCodigo.fobRegBuscarAdmtriagemaestr(G1Adm_nroreg_tria);
                                if (tmp != null)
                                {
                                    if (tmp.adm_remisi_tria != "3")
                                    {
                                        lcrValorReturn = "Registro Triage: Debe tener Nivel 1 - 2 o 3 para realizar admisión";
                                    }
                                    else
                                    {
                                        if (String.IsNullOrWhiteSpace(G1Sia_idesec_usua)) { G1Sia_idesec_usua = tmp.sia_idesec_usua; }
                                        if (String.IsNullOrWhiteSpace(G1Hcl_nrohis_hicl)) { G1Hcl_nrohis_hicl = tmp.hcl_nrohis_hicl; }
                                        if (String.IsNullOrWhiteSpace(G1Sia_tipide_tide)) { G1Sia_tipide_tide = tmp.sia_tipide_tide; }
                                        if (String.IsNullOrWhiteSpace(G1Sia_nroide_usua)) { G1Sia_nroide_usua = tmp.sia_nroide_usua; }
                                        if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps)) { G1Sia_codeps_teps = tmp.sia_codeps_teps; }
                                        if (String.IsNullOrWhiteSpace(G1Sia_codcat_ceat)) { G1Sia_codcat_ceat = tmp.sia_codcat_ceat; }
                                        if (String.IsNullOrWhiteSpace(G1Sia_dixing_tdia)) { G1Sia_dixing_tdia = tmp.sia_coddia_tdia; }
                                        if (String.IsNullOrWhiteSpace(G1Adm_caucon_rgad)) { G1Adm_caucon_rgad = tmp.adm_motcon_tria; }
                                        //if (String.IsNullOrWhiteSpace(G1Sia_codpfa_prof)) { G1Sia_codpfa_prof = tmp.sia_codpfa_prof; }

                                        if (tmp.sis_estpro_espr == "1") { lcrValorReturn = "Registro Triage: No esta confirmado"; }

                                        fcvCargarDatosTriage(tmp.adm_clasif_tria);
                                    }
                                }
                                else
                                {
                                    lcrValorReturn = "Codigo Triage: No existe";
                                }
                            }
                        }
                        else 
                        {
                            if (!String.IsNullOrWhiteSpace(G1Adm_nroreg_tria))
                            {
                                lcrValorReturn = "Codigo Triage: Es requerido solo cuando origen es urgencias o tipo atención urgencias";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codcat_ceat":
                        #region Datos
                        lcrNombreCampo = "Centro atención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A33";
                        if (string.IsNullOrWhiteSpace(G1Sia_codcat_ceat))
                        {
                            lcrValorReturn = "Centro atención: Es requerido";
                        }
                        else
                        {
                            EFsiacentroaten tmp = new EFsiacentroaten();
                            tmp = SIAValidarCodigo.fobRegBuscarSiacentroaten(G1Sia_codcat_ceat);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_descat_ceat))
                            {
                                G1Sia_descat_ceat = tmp.sia_descat_ceat;
                            }
                            else
                            {
                                lcrValorReturn = "Centro atención: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sis_estpro_espr":
                        #region Datos
                        lcrNombreCampo = "Estado Admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A34";
                        if (string.IsNullOrWhiteSpace(G1Sis_estpro_espr))
                    	{
                    	   	lcrValorReturn = "Estado Admisión: Es requerido";
                    	}
                    	else
                    	{
                            EFsisestadoproces tmp = new EFsisestadoproces();
                            tmp = SISValidarCodigo.fobRegBuscarSisestadoproces(G1Sis_estpro_espr);
                            if (tmp!=null)
                            {
                            	G1Sis_despro_espr = tmp.sis_despro_espr;
                            }
                            else
                            {
                            	lcrValorReturn = "Estado Admisión: No existe";
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        #region fcvCargarDatosTriage: Cargar parametros desde registro atencion Tirage Urgencias
        public void fcvCargarDatosTriage(String tcrCodigoClasificacion)
        {
            // Parametros generales para admision
            var tmpx = ADMValidarCodigo.fobRegBuscarAdmtriagemaconfNivel(tcrCodigoClasificacion);
            if (tmpx != null)
            {
                if (String.IsNullOrWhiteSpace(G1Adm_codoad_toad)) { G1Adm_codoad_toad = tmpx.adm_codoad_toad; }
                if (String.IsNullOrWhiteSpace(G1Sia_codare_aser)) { G1Sia_codare_aser = tmpx.sia_codare_aser; }
                if (String.IsNullOrWhiteSpace(G1Sia_areing_aser)) { G1Sia_areing_aser = tmpx.sia_areing_aser; }
                if (String.IsNullOrWhiteSpace(G1Fcm_codcpr_cpro)) { G1Fcm_codcpr_cpro = tmpx.fcm_codcpr_cpro; }
                if (String.IsNullOrWhiteSpace(G1Adm_codtat_tatn)) { G1Adm_codtat_tatn = tmpx.adm_codtat_tatn; }
                if (String.IsNullOrWhiteSpace(G1Adm_codcex_tcex)) { G1Adm_codcex_tcex = tmpx.adm_codcex_tcex; }
                if (String.IsNullOrWhiteSpace(G1Sia_tipdxp_tdix)) { G1Sia_tipdxp_tdix = "1"; }
            }
        }
        #endregion
        //-------------------------------------------------
        // flgGenerarDatosEdad: Generar datos edad del paciente
        //-------------------------------------------------
        #region Calcular datos edad
        /// <summary>
        /// <para>Genera los datos de edad y edad en formato loargo</para>
        /// </summary>
        public bool flgGenerarDatosEdad()
        {
            var llgValor = false;
            if (Funciones.flgValidarRangoFecha(G1Sia_fecnac_usua,G1Adm_fecadm_rgad))
            {
                llgValor = true;
                var ldaFechaNac =Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecnac_usua);
                var ldaFechaAdm =Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecadm_rgad);

                G1Sia_edaano_usua = Funciones.fnuCalcularFormatoAñosMesesDias("AÑOS", ldaFechaNac, ldaFechaAdm);
                G1Sia_edames_usua = Funciones.fnuCalcularFormatoAñosMesesDias("MESES", ldaFechaNac, ldaFechaAdm);
                G1Sia_edadia_usua = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechaNac, ldaFechaAdm);
                G1Sia_edadia_usua = G1Sia_edadia_usua <= 0 ? 1 : G1Sia_edadia_usua;
                G1Sia_edaymd_usua = Funciones.fcrFechaRangoForamtoLargo(ldaFechaNac, ldaFechaAdm);
                G1Sia_codmed_tmed = Funciones.fcrMedidaAñosMesesDias(G1Sia_edaano_usua, G1Sia_edames_usua, G1Sia_edadia_usua);
            }
            return llgValor;
        }
        #endregion
    }
}
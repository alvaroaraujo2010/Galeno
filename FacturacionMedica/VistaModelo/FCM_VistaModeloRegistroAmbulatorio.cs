//- MARMOTA-GENCODE: VERSION 2.0 - 21/07/2014 06:53:14 AM
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
using Datos.Modelos;
using Sistema.Clases;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admregadmision</para>
    /// <para>DESCRIPCION:
    ///  Tabla del modulo de facturación médica (fcm) - Registrar todas
    ///  las admisiones de pacientes en la institución IPS;
    /// </para>
    /// </summary>
    public class VistaModeloRegistroAmbulatorio : VistaModeloAdmadmisionesBase
    {
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdFILTRO { get; set; }
        public RelayCommand CmdEDTAUX { get; set; }
        public RelayCommand CmdEDTUSU { get; set; }
        
        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            gcrIdVistaModeloForm = "FCM0X1";
            CmdFILTRO = new RelayCommand(fcvFiltro, CanFiltro);
            CmdEDTAUX = new RelayCommand(Modificar, CanEdtRegAtencion);
            CmdEDTUSU = new RelayCommand(Default,   CanEdtDatosUsuario);
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
        #region CanEdtRegAtencion
        /// <summary>
        ///Validación para saber si se permite ejecutar comando Modificar
        /// </summary>
        public virtual bool CanEdtRegAtencion()
        {
            bool llgReturn = false;
            try
            {
                if (G1Adm_estfac_rgad == "1" && GlgSIS_ModoEdicion == false)
                {
                    if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_secadm_rgad) && GlgSIS_ModoEdicion == false)
                    {
                        // verificar si el perfil tiene permiso
                        if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                        {
                            gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, "ADM001" + "-CMDMODIFICAR-EDT", "EDT");
                        }
                        if (gcrSIS_PerfilCmdEDT == "OK") { llgReturn = true; } else { llgReturn = false; }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEDT");
            }
            return llgReturn;
        }
        #endregion
        #region CanEdtDatosUsuario
        /// <summary>
        /// Se puede modificar los datos basicos del paciente atendido
        /// </summary>
        public virtual bool CanEdtDatosUsuario()
        {
            bool llgReturn = false;
            try
            {
                if (!String.IsNullOrWhiteSpace(G1Sia_nroide_usua) && GlgSIS_ModoEdicion == false)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEdtDatosUsuario");
            }
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos que realizan la funcion
        // de gestion de datos en la tabla
        //-------------------------------------------------
        #region Guardar Registro
        /// <summary>
        /// Guardar Registro
        /// </summary>
        public override void Guardar()
        {
            TmpG1RegActivo.Sia_areing_aser = G1Sia_codare_aser;
            base.Guardar();
            fcvSYSGenerarNotificacion();
        }
        #endregion
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
        // fcvReiniVariables: Reiniciar Variables
        //-------------------------------------------------
        #region Reiniciar Variables
        /// <summary>
        /// Reiniciar Variables
        /// </summary>
        public override void fcvReiniVariables()
        {
            base.fcvReiniVariables();
            try
            {
                #region Valores Variables
                G1Adm_codtat_tatn = "1"; // Tipo de atencion
                G1Sia_regate_rgat = "2"; // Registro de atencion Ambulatorio
                G1Sis_estpro_espr = "2"; // confirmar el registro
                G1Adm_estrad_rgad = "1"; // Abierta por ahora
                G1Adm_ctarip_rgad = "2";
                G1Sys_codusu_usux = GcrUsuIDUsuario;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Gestión Error Metodo: ReiniVariables");
            }
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
            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Sia_idesec_usua":
                    	#region SIA_IDESEC_USUA: Código único del paciente
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
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nroide_usua))

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
                                if (String.IsNullOrWhiteSpace(G1Sis_idemun_muni)) { G1Sis_idemun_muni = tmp.sis_idemun_muni; }

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
                                //G1Sis_idemun_muni = tmp.sis_idemun_muni;  ---- ojo 
                                G1Sia_edapac_usua = (int)tmp.sia_edapac_usua;
                                G1Sia_codmed_tmed = tmp.sia_codmed_tmed;
                                G1Sia_fecnac_usua = Funciones.fcrConvertFecha((DateTime)tmp.sia_fecnac_usua);
                                G1Sis_codsex_sexo = tmp.sis_codsex_sexo;
                                if (String.IsNullOrWhiteSpace(G1Sia_codcat_ceat)) { G1Sia_codcat_ceat = tmp.sia_codcat_ceat; }
                                G1Sys_codusu_usux = tmp.sys_codusu_usux;

                                flgGenerarDatosEdad();
                                fcvCargarValoresPorDefecto();

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

                            }
                            else
                            {
                                lcrValorReturn = "Código único del paciente: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipide_tide":
                    	#region SIA_TIPIDE_TIDE: Tipo Identificación
                        lcrNombreCampo = "Tipo Identificación";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";
                        if (string.IsNullOrWhiteSpace(G1Sia_tipide_tide))
                        {
                            lcrValorReturn = "Tipo Identificación: Es requerido";
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
                        lcrCodigoError = "A03";
                        if (string.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                        {
                            lcrValorReturn = "Numero de Identificación: Es requerido";
                            fcvLimpiarVistaDatos();
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
                                fcvLimpiarVistaDatos();
                            }
                        }
                        break;
                        #endregion

                    case "G1Hcl_nrohis_hicl":
                    	#region HCL_NROHIS_HICL: Numero historia clínica
                        lcrNombreCampo = "Numero historia clínica";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";
                        if (!string.IsNullOrWhiteSpace(G1Hcl_nrohis_hicl))
                        {
                        }
                        break;
                        #endregion

                    case "G1Adm_fecadm_rgad":
                    	#region ADM_FECADM_RGAD: Fecha Admisión
                        lcrNombreCampo = "Fecha Admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Adm_fecadm_rgad, lcrNombreCampo);
                        if (G1Adm_codtat_tatn == "2") // si es admitido por hospitalizacion 
                        {
                            G1Adm_fechos_rgad = G1Adm_fecadm_rgad;
                            G1Adm_horhos_rgad = G1Adm_horadm_rgad;
                        }
                        break;
                        #endregion

                    case "G1Adm_horadm_rgad":
                    	#region ADM_HORADM_RGAD: Hora de Admisión
                        lcrNombreCampo = "Hora de Admisión";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Adm_horadm_rgad, "12", ":", "Hora de atención");
                        if (G1Adm_codtat_tatn == "2") // si es admitido por hospitalizacion 
                        {
                            G1Adm_fechos_rgad = G1Adm_fecadm_rgad;
                            G1Adm_horhos_rgad = G1Adm_horadm_rgad;
                        }
                        break;
                        #endregion

                    case "G1Adm_pacemb_rgad":
                    	#region ADM_PACEMB_RGAD: Embarazada SI/NO
                        lcrNombreCampo = "Embarazada SI/NO";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        flgGenerarDatosEdad();
                        if (string.IsNullOrWhiteSpace(G1Adm_pacemb_rgad))
                        {
                            lcrValorReturn = "Embarazada SI/NO: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_pacemb_rgad, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Embarazada SI/NO: Dato no es válido";
                            }
                            else
                            {
                                if (G1Sis_codsex_sexo == "F")
                                {
                                    if (Funciones.flgExisteElemento(G1Adm_pacemb_rgad, ",", "1,2"))
                                    {
                                        if (G1Sia_edaano_usua < 12 || G1Sia_edaano_usua > 49)
                                        {
                                            lcrValorReturn = "Embarazada SI/NO: Valor no aplica por la edad";
                                        }
                                    }
                                }
                                else
                                {
                                    if (Funciones.flgExisteElemento(G1Adm_pacemb_rgad, ",", "1,2"))
                                    {
                                        lcrValorReturn = "Embarazada SI/NO: Valor no aplica para sexo masculino";
                                    }
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codare_aser":
                    	#region SIA_CODARE_ASER: Código Área de servicios
                        lcrNombreCampo = "Código Área de servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (string.IsNullOrWhiteSpace(G1Sia_codare_aser))
                        {
                            lcrValorReturn = "Código Área de servicios: Es requerido";
                        }
                        else
                        {
                            EFsiaareapreservi tmp = new EFsiaareapreservi();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G1Sia_codare_aser);
                            if (tmp != null)
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

                    case "G1Fcm_codcpr_cpro":
                        #region FCM_CODCPR_CPRO: Centro producción
                        lcrNombreCampo = "Centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (String.IsNullOrWhiteSpace(G1Fcm_codcpr_cpro))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(G1Fcm_codcpr_cpro);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codcpr_cpro))
                            {
                                G1Fcm_descpr_cpro = tmp.fcm_descpr_cpro;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_codtat_tatn":
                    	#region ADM_CODTAT_TATN: Tipo ambito de atención
                        lcrNombreCampo = "Tipo ambito de atención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
                        /*
                        if (string.IsNullOrWhiteSpace(G1Adm_codtat_tatn))
                        {
                            lcrValorReturn = "Tipo de Atención: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_codtat_tatn, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Tipo de Atención: Dato no es valido";
                            }
                        }
                         */ 
                        break;
                        #endregion

                    case "G1Adm_codcex_tcex":
                    	#region ADM_CODCEX_TCEX: Causa Externa
                        lcrNombreCampo = "Causa Externa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
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

                    case "G1Adm_caucon_rgad":
                    	#region ADM_CAUCON_RGAD: Causa de Consulta
                        lcrNombreCampo = "Causa de Consulta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A12";
                        if (string.IsNullOrWhiteSpace(G1Adm_caucon_rgad))
                        {
                            lcrValorReturn = "Causa de Consulta: Es requerido";
                        }
                        else
                        {
                            G1Adm_caucon_rgad = G1Adm_caucon_rgad.ToUpper();
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Adm_caucon_rgad, "ABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚ0123456789.-() "))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no validos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_seccon_cont":
                    	#region CTO_SECCON_CONT: Secuencial de Contrato
                        lcrNombreCampo = "Codigo Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (string.IsNullOrWhiteSpace(G1Cto_seccon_cont))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
                            if (tmp != null)
                            {
                                if (tmp.cto_estcon_cont == "2") // Contrato inactivo
                                {
                                    lcrValorReturn = "Secuencial de Contrato esta inactivo";
                                }
                                else
                                {
                                    tmpRegcontr = tmp;
                                    G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                    G1Cto_descon_cont = tmp.cto_descon_cont;
                                    G1Sia_tipusu_regi = tmp.sia_tipusu_regi;
                                    G1Sis_idterc_sitr = String.IsNullOrWhiteSpace(G1Sis_idterc_sitr) ? tmp.sis_idterc_sitr : G1Sis_idterc_sitr;
                                    fcrValidacion("G1Sis_idterc_sitr");

                                    if (tmp.cto_modeps_cont == "1") // cuando se permite cambiar la eps
                                    {
                                        if (String.IsNullOrWhiteSpace(G1Sia_codeps_teps)) { G1Sia_codeps_teps = tmp.sia_codeps_teps; }
                                    }
                                    else
                                    {
                                        G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                        // Validar si el contrato verifica el usuario en maestro afiliados
                                        if (tmp.cto_idvalc_cont == "1" && !String.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                                        {
                                            lcrCodigoError = "A01";
                                            lcrValorReturn = CTOValidarCodigo.fcrValidarUsuarioEnContrato(G1Sia_tipide_tide, G1Sia_nroide_usua, tmp);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codeps_teps":
                    	#region SIA_CODEPS_TEPS: Código EPS
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A14";
                        if (string.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            lcrValorReturn = "Código EPS: Es requerido";
                        }
                        else
                        {
                            G1Sia_codeps_teps = G1Sia_codeps_teps.ToUpper();
                            var tmpc = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
                            if (tmpc != null)
                            {
                                if (tmpc.cto_modeps_cont=="2") // si es 2 no se permite modificar codigo EPS
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
                        lcrCodigoError = "A25";
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

                    case "G1Adm_nroaut_rgad":
                    	#region ADM_NROAUT_RGAD: Numero Autorización
                        lcrNombreCampo = "Numero Autorización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A15";
                        if (!string.IsNullOrWhiteSpace(G1Adm_nroaut_rgad))
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(G1Adm_nroaut_rgad, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no permitidos";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipusu_regi":
                    	#region SIA_TIPUSU_REGI: Régimen salud usuario
                        lcrNombreCampo = "Régimen salud usuario";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A16";
                        if (string.IsNullOrWhiteSpace(G1Sia_tipusu_regi))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_tipusu_regi, ",", "1,2,3,4,5"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                            else if (G1Sia_tipusu_regi=="1" && String.IsNullOrWhiteSpace(G1Sia_nivcon_ncon))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Debe actualizar el nivel contributivo del usuario";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tippob_tpob":
                    	#region SIA_TIPPOB_TPOB: Tipo población especial
                        lcrNombreCampo = "Tipo población especial";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A17";
                        if (string.IsNullOrWhiteSpace(G1Sia_tippob_tpob))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Sia_tippob_tpob, ",", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codfco_fcon":
                    	#region SIA_CODFCO_FCON: Finalidad Consulta
                        lcrNombreCampo = "Finalidad Consulta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A18";
                        if (!String.IsNullOrWhiteSpace(G1Sia_codfco_fcon))
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiafinaliconsul(G1Sia_codfco_fcon);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desfco_fcon))
                            {
                                G1Sia_desfco_fcon = tmp.sia_desfco_fcon;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_coddia_tdia":
                    	#region SIA_CODDIA_TDIA: Diagnostico consulta
                        lcrNombreCampo = "Diagnostico consulta";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A19";
                        if (!String.IsNullOrWhiteSpace(G1Sia_coddia_tdia))
                        {
                            G1Sia_coddia_tdia = G1Sia_coddia_tdia.ToUpper();

                            var tmp = SIAValidarCodigo.fobRegBuscarSiadiagnosticos(G1Sia_coddia_tdia);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_desdia_tdia))
                            {
                                G1Sia_desdia_tdia = tmp.sia_desdia_tdia;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_tipdxp_tdix":
                    	#region SIA_TIPDXP_TDIX: Tipo diagnostico principal
                        lcrNombreCampo = "Tipo diagnostico principal";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A20";
                        if (String.IsNullOrWhiteSpace(G1Sia_tipdxp_tdix))
                        {
                            if (!String.IsNullOrWhiteSpace(G1Sia_coddia_tdia))
                            {
                                lcrValorReturn = "Tipo diagnostico principal: Es requerido";
                            }
                        }
                        else
                        {
                            if (String.IsNullOrWhiteSpace(G1Sia_coddia_tdia))
                            {
                                lcrValorReturn = "Tipo diagnostico principal: No es requerido";
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
                                    lcrValorReturn = "Tipo diagnostico principal: No existe";
                                }
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_dessal_regr":
                    	#region ADM_DESSAL_REGR: Destino al salir
                        lcrNombreCampo = "Destino al salir";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A21";
                        if (String.IsNullOrWhiteSpace(G1Adm_dessal_regr))
                        {
                            lcrValorReturn = "Destino al salir: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Adm_dessal_regr, ",", "1,2,3"))
                            {
                                lcrValorReturn = "Destino al salir: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Adm_nroreg_tria":
                        #region Datos
                        lcrNombreCampo = "Codigo Triage";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A31";
                        if (!String.IsNullOrWhiteSpace(G1Adm_nroreg_tria))
                        {
                            var tmp = ADMValidarCodigo.fobRegBuscarAdmtriagemaestr(G1Adm_nroreg_tria);
                            if (tmp != null)
                            {
                                if (tmp.adm_remisi_tria == "3") // cuando se remite a urgencias no aplica en ambulatoria
                                {
                                    lcrValorReturn = "Registro Triage: Debe tener Nivel 4 o 5 para atención ambulatoria";
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
                                    if (String.IsNullOrWhiteSpace(G1Sia_coddia_tdia)) { G1Sia_coddia_tdia = tmp.sia_coddia_tdia; }
                                    if (String.IsNullOrWhiteSpace(G1Adm_caucon_rgad)) { G1Adm_caucon_rgad = tmp.adm_motcon_tria; }
                                    if (String.IsNullOrWhiteSpace(G1Adm_codcex_tcex)) { G1Adm_codcex_tcex = "13"; }
                                    G1Adm_dessal_regr = "1";

                                    fcvCargarDatosTriage(tmp.adm_clasif_tria);
                                    if (tmp.sis_estpro_espr == "1") { lcrValorReturn = "Registro Triage: No esta confirmado"; }
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Codigo Triage: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codpfa_prof":
                    	#region SIA_CODPFA_PROF: Código Profesional Autoriza
                        lcrNombreCampo = "Código Profesional Autoriza";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A22";
                        if (String.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            G1Sia_codpfa_prof = G1Sia_codpfa_prof.ToUpper();

                            var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                            if (tmp != null)
                            {
                                G1Sia_nompro_prof = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codcat_ceat":
                    	#region SIA_CODCAT_CEAT: Código centro atención
                        lcrNombreCampo = "Código entro atención";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A23";
                        if (string.IsNullOrWhiteSpace(G1Sia_codcat_ceat))
                        {
                            lcrValorReturn = lcrNombreCampo + ": Es requerido";
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarSiacentroaten(G1Sia_codcat_ceat);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_descat_ceat))
                            {
                                G1Sia_descat_ceat = tmp.sia_descat_ceat;
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
                MessageBox.Show(ex.Message, "VistaModelo Gestión Error Metodo: fcrValidacion");
            }
            return lcrValorReturn;
        }
        #endregion
        // Limpiar vista de captura
        #region fcvLimpiarVistaDatos: Limpiar vista de captura
        /// <summary>
        /// Limpiar vista de captura
        /// </summary>
        public void fcvLimpiarVistaDatos()
        {
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
                G1Adm_dessal_regr = "1";
                G1Sia_codfco_fcon = "10";
            }
        }
        #endregion
        //-------------------------------------------------
        // flgGenerarDatosEdad: Generar datos edad del paciente
        //-------------------------------------------------
        #region Generar datos edad del paciente
        /// <summary>
        /// <para>Genera los datos de edad y edad en formato loargo</para>
        /// </summary>
        public bool flgGenerarDatosEdad()
        {
            var llgValor = false;
            if (Funciones.flgValidarRangoFecha(G1Sia_fecnac_usua, G1Adm_fecadm_rgad))
            {
                llgValor = true;
                var ldaFechaNac = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecnac_usua);
                var ldaFechaAdm = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecadm_rgad);

                G1Sia_edaano_usua = Funciones.fnuCalcularFormatoAñosMesesDias("AÑOS", ldaFechaNac, ldaFechaAdm);
                G1Sia_edames_usua = Funciones.fnuCalcularFormatoAñosMesesDias("MESES", ldaFechaNac, ldaFechaAdm);
                G1Sia_edadia_usua = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechaNac, ldaFechaAdm);
                G1Sia_edadia_usua = G1Sia_edadia_usua <= 0 ? 1 : G1Sia_edadia_usua;
                G1Sia_edaymd_usua = Funciones.fcrFechaRangoForamtoLargo(ldaFechaNac, ldaFechaAdm);

            }
            return llgValor;
        }
        #endregion
        //-------------------------------------------------
        // Gestion valores por defecto en captura de datos
        //-------------------------------------------------
        #region fcvCargarValoresPorDefecto: Cargar los valores por defecto en cada campo para agilizar digitación
        /// <summary>
        /// Cargar los valores por defecto en cada campo para agilizar digitación
        /// </summary>
        public void fcvCargarValoresPorDefecto()
        {
            var lcrValores = Funciones.fcrLeerConfigVarSistema("SIA-PARAMET-CAPT-ATEN-AMBUL", "NA");

            // cuando hay valores 
            if (lcrValores != "NA")
            {
                fcvCargarValoresPorDefectoString(lcrValores);
            }
        
        }
        #endregion
        #region fcvCargarValoresPorDefectoString: Cargar los valores desde String
        /// <summary>
        /// Cargar los valores desde String 
        /// </summary>
        public void fcvCargarValoresPorDefectoString(String tcrValorString)
        {
            if (!String.IsNullOrWhiteSpace(tcrValorString))
            {
                String[] larArray = (tcrValorString).Split("*".ToCharArray());

                if (larArray[0].Trim() == "V1")
                {
                    //Embarazada-AreaServicios-CentroProducción-CauExterna-MotivoConsulta-TipoPoblacion-
                    //FinalidadConsulta-DestinoSalir-ProfesionalQueAtiende-CentroAtención
                    // Ejemplo:
                    //V1*3*001*3200*13*GENERAL*5*10*1*P002*CNT001

                    //if (String.IsNullOrWhiteSpace(G1Adm_pacemb_rgad)) { G1Adm_pacemb_rgad = larArray[1].Trim(); } este tiene un trato especial 
                    if (String.IsNullOrWhiteSpace(G1Sia_codare_aser)) { G1Sia_codare_aser = larArray[2].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Fcm_codcpr_cpro)) { G1Fcm_codcpr_cpro = larArray[3].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Adm_codcex_tcex)) { G1Adm_codcex_tcex = larArray[4].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Adm_caucon_rgad)) { G1Adm_caucon_rgad = larArray[5].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_tippob_tpob)) { G1Sia_tippob_tpob = larArray[6].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_codfco_fcon)) { G1Sia_codfco_fcon = larArray[7].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Adm_dessal_regr)) { G1Adm_dessal_regr = larArray[8].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_codpfa_prof)) { G1Sia_codpfa_prof = larArray[9].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_codcat_ceat)) { G1Sia_codcat_ceat = larArray[10].Trim(); }

                    // Validar dato "Paciente embarazada SI/NO"
                    if (G1Sis_codsex_sexo == "F")
                    {
                        if (G1Sia_edaano_usua >= 12 && G1Sia_edaano_usua <= 49)
                        {
                            if (String.IsNullOrWhiteSpace(G1Adm_pacemb_rgad))
                            {
                                G1Adm_pacemb_rgad = larArray[1].Trim();
                            }
                            G1Adm_pacemb_rgad = G1Adm_pacemb_rgad != "1" ? "2" : G1Adm_pacemb_rgad;
                        }
                        else
                        {
                            G1Adm_pacemb_rgad = "3";
                        }

                    }
                    else
                    {
                        G1Adm_pacemb_rgad = "3";
                    }

                }
            }
        }
        #endregion

    }
}
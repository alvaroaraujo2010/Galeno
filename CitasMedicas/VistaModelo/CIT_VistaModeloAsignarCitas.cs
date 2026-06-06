//- MARMOTA-GENCODE: VERSION 2.0 - 23/05/2013 07:18:00 AM
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
using Microsoft.Practices.ServiceLocation;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using CitasMedicas.Modelo;
using FacturacionMedica.Modelo;

namespace CitasMedicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: citmaesasigcita</para>
    /// <para>DESCRIPCION:
    ///  Maestro de Citas asignadas a pacientes, con el respectivo profesional
    ///  que realiza la atención, y especialidad
    /// </para>
    /// </summary>
    public class VistaModeloAsignarCitas : VistaModeloAsignarCitasBase
    {
        //-------------------------------------------------
        // Variables de proposito auxiliar
        //-------------------------------------------------
        public List<LogsErrores> tmpAuxLogErrores = null;
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdSAVERELAUX { get; set; }
        public RelayCommand CmdASIGCITA { get; set; }
        public RelayCommand CmdCONFCITA { get; set; }
        public RelayCommand CmdCANCCITA { get; set; }
        public RelayCommand CmdCANSALIR { get; set; }
        public RelayCommand CmdCANFILTRO { get; set; }

        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            CmdSAVERELAUX = new RelayCommand(GuardarRelAux, CanSAVRELAUX);
            CmdASIGCITA = new RelayCommand(Default, CanAsignar);
            CmdCONFCITA = new RelayCommand(Default, CanConfirmar);
            CmdCANCCITA = new RelayCommand(Default, CanCancelar);
            CmdCANSALIR = new RelayCommand(Default, CanSalir);
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloAsignarCitas()
        {
            GlgSIS_ModoEdicion = false;
            GlgSIS_ModoCancelar = false;
        }
        #endregion
        //-------------------------------------------------
        // Region Metodos que Validan activacion de opciones
        // en gestion de datos
        //-------------------------------------------------
        #region Metodos para Activacion de opciones
        #region CanSAVRELAUX
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Guardar Registro Relación
        /// </summary>
        public bool CanSAVRELAUX()
        {
            bool llgReturn = false;
            try
            {
                if (CanSAVREL() && !String.IsNullOrWhiteSpace(G3Fcm_coddig_mant))
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSAVRELAUX");
            }
            return llgReturn;
        }
        #endregion
        #region CanAsignar
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando para asignar la cita
        /// </summary>
        public bool CanAsignar()
        {
            bool llgReturn = false;
            gcrSIS_PerfilCmdSAV = "NO";
            try
            {
                //if (G1Cit_estcit_easi == "1" && tmpListDetallFactBrw.Count > 0)
                if (G1Cit_estcit_easi == "1" || G1Cit_estcit_easi == "2")
                {
                    if (GlgSIS_ModoEdicion == false)
                    {
                        GlgSIS_ModoEdicion = true;
                        //GlgSIS_ModoCancelar = false;
                        GlgSIS_ModoCancelar = G1Cit_estcit_easi == "2" ? true : false;
                    }
                    if (CanSAV())
                    {
                        llgReturn = true; // por ahora
                        if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                    }
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Asignar citas");
            }
            return llgReturn;
        }
        #endregion
        #region CanConfirmar
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando para Confirmar la cita
        /// </summary>
        public bool CanConfirmar()
        {
            bool llgReturn = false;
            gcrSIS_PerfilCmdSAV = "NO";
            try
            {
                if (G1Cit_estcit_easi == "1" || G1Cit_estcit_easi == "2")
                {
                    if (gdaFechaCita <= Funciones.FdaFechaActual())
                    {
                        GlgSIS_ModoEdicion = true;

                        //if (CanSAV() && String.IsNullOrWhiteSpace(G1Cit_caucan_ccan) && tmpListDetallFactBrw.Count > 0)
                        if (CanSAV() && String.IsNullOrWhiteSpace(G1Cit_caucan_ccan))
                        {
                            llgReturn = true; // por ahora
                            if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Asignar citas");
            }
            return llgReturn;
        }
        #endregion
        #region CanCancelar
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Cancelar citas asignadas
        /// </summary>
        public bool CanCancelar()
        {
            bool llgReturn = false;
            gcrSIS_PerfilCmdSAV = "NO";
            try
            {
                if (G1Cit_estcit_easi == "2")
                {
                    //GlgSIS_ModoEdicion = false;
                    if (String.IsNullOrWhiteSpace(fcrValidacion("G1Cit_caucan_ccan")))
                    {
                        GlgSIS_ModoCancelar = true;
                        llgReturn = !String.IsNullOrWhiteSpace(G1Cit_caucan_ccan) ? true : false;
                        if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                    }
                }
                else
                {
                    GlgSIS_ModoCancelar = false;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Cancelar citas");
            }
            return llgReturn;
        }
        #endregion
        #region CanSalir
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Salir
        /// </summary>
        public bool CanSalir()
        {
            bool llgReturn = true;
            return llgReturn;
        }
        #endregion
        #endregion
        #region GuardarRelAux: Guardar en temporal Registro Relacion auxiliar
        /// <summary>
        /// Guardar Registro Relacion en temporal
        /// </summary>
        public void GuardarRelAux()
        {
            try
            {
                // Acumular cobros en efectivo
                //fcvCalcularCopagoyCmoderadoras();

                G2Fcm_valref_dfac = 0;
                if (gobLiq.m.gcrContEfectivoServicios == "1") { G2Fcm_valref_dfac += gobLiq.G2Fcm_valfac_dfac; }
                if (gobLiq.m.gcrContEfectivoCopago == "1") { G2Fcm_valref_dfac += gobLiq.G2Fcm_valcpa_dfac; }
                if (gobLiq.m.gcrContEfectivoCmoderad == "1") { G2Fcm_valref_dfac += gobLiq.G2Fcm_valcmo_dfac; }
                if (gobLiq.m.gcrContEfectivoCargUsuar == "1") { G2Fcm_valref_dfac += gobLiq.G2Fcm_valusu_dfac; }
                G2Fcm_valefe_dfac = G2Fcm_valref_dfac;
                gobLiq.G2Fcm_valref_dfac = G2Fcm_valref_dfac;
                gobLiq.G2Fcm_valefe_dfac = G2Fcm_valref_dfac;
                //- Guardar datos en grilla
                GuardarRel();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: GuardarRelAux");
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
                    case "G1Sia_nroide_usua":
                        #region G1Sia_nroide_usua: Identificación paciente
                        lcrNombreCampo = "Identificación paciente";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A01";

                        if (String.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                        {
                            lcrValorReturn = "Identificación paciente: Es requerido";
                            fcvLimpiarVariables();
                        }
                        else
                        {
                            var tmp = SIAValidarCodigo.fobRegBuscarIuSiausuarioatendEx(G1Sia_nroide_usua);
                            if (tmp != null)
                            {
                                G1Sia_idesec_usua = tmp.sia_idesec_usua;
                                G1Sia_tipide_tide = tmp.sia_tipide_tide;
                                G1Sia_nomusu_usua = tmp.sia_nomusu_usua;
                                G1Sys_codusu_usux = GcrUsuIDUsuario;
                                G1Sia_fecnac_usua = ((DateTime)tmp.sia_fecnac_usua).ToShortDateString();
                                A1Sis_codsex_sexo = tmp.sis_codsex_sexo;
                                // por ahora

                                if (!flgGenerarDatosEdad())
                                {
                                    lcrValorReturn = "Identificación paciente: Error en fecha de nacimiento o fecha de la cita";
                                }
                                else
                                {
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
                                if (String.IsNullOrWhiteSpace(G1Cto_seccon_cont))
                                {
                                    G1Cto_seccon_cont = tmp.cto_seccon_cont;
                                    G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                    G1Sia_codeps_teps = tmp.sia_codeps_teps;
                                }
                                // Tipo Ide del usuario
                                var tmpTide = SIAValidarCodigo.fobRegBuscarSiatipideusario(G1Sia_tipide_tide);
                                if (tmp != null)
                                {
                                    G1Sia_deside_tide = tmpTide.sia_deside_tide;
                                }
                                flgGenerarRegAdmision();
                                flgValidacionPertinencia();
                            }
                            else 
                            {
                                lcrValorReturn = "Identificación paciente: No existe";
                                fcvLimpiarVariables();
                            }
                        }
                        break;
                        #endregion

                    case "G1Cto_seccon_cont":
                        #region G1Cto_seccon_cont: Secuencial de Contrato
                        lcrNombreCampo = "Codigo único Secuencial de Contrato";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A02";

                        if (string.IsNullOrWhiteSpace(G1Cto_seccon_cont))
                        {
                            lcrValorReturn = "Identificación Secuencial de Contrato";
                        }
                        else
                        {
                            var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontratoEx(G1Cto_seccon_cont);
                            if (tmp != null)
                            {
                                if (tmp.cto_estcon_cont == "2") // Contrato inactivo
                                {
                                    lcrValorReturn = "Secuencial de Contrato esta inactivo";
                                }
                                else
                                {
                                    if (flgSiContratoDetallServicios())
                                    {
                                        tmpRegcontr = tmp;
                                        G1Cto_nrocon_cont = tmp.cto_nrocon_cont;
                                        G1Cto_descon_cont = tmp.cto_descon_cont;
                                        G1Fcm_codman_mans = tmp.fcm_codman_mans;
                                        G1Cto_sepser_cont = tmp.cto_sepser_cont;
                                        G1Cto_serper_cont = tmp.cto_serper_cont;
                                        G1Cto_fcdian_cont = tmp.cto_fcdian_cont;
                                        G1Sia_codeps_teps = String.IsNullOrWhiteSpace(G1Sia_codeps_teps) ? tmp.sia_codeps_teps : G1Sia_codeps_teps;
                                        G1Sis_idterc_sitr = String.IsNullOrWhiteSpace(G1Sis_idterc_sitr) ? tmp.sis_idterc_sitr : G1Sis_idterc_sitr;
                                        fcrValidacion("G1Sis_idterc_sitr");

                                        // Datos Contrato y Tarifario  para liquidacion
                                        tmp.sis_idterc_sitr = G1Sis_idterc_sitr; // por si el tercer se cambia
                                        gobLiq.fcvCargarValoresContrato(tmp);
                                        gobLiq.m.flgCargarParametrosContrato(tmp);

                                        // Datos Eps
                                        var tmpEps = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                                        if (tmp != null)
                                        {
                                            G1Sia_deseps_teps = tmpEps.sia_deseps_teps;
                                        }

                                        // Validar si el contrato verifica el usuario en maestro afiliados
                                        if (tmp.cto_idvalc_cont =="1" && !String.IsNullOrWhiteSpace(G1Sia_nroide_usua))
                                        {
                                            lcrCodigoError = "A01";
                                            lcrValorReturn = CTOValidarCodigo.fcrValidarUsuarioEnContrato(G1Sia_tipide_tide, G1Sia_nroide_usua, tmp);
                                        }
                                    }
                                    else
                                    {
                                        lcrValorReturn = "Secuencial de Contrato: diferente en servicios relacionados en lista detalles.";
                                    }
                                }
                            }
                            else
                            {
                                lcrValorReturn = "Identificación Secuencial de Contrato: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codeps_teps":
                        #region SIA_CODEPS_TEPS: Código EPS
                        lcrNombreCampo = "Código EPS";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";
                        if (!string.IsNullOrWhiteSpace(G1Sia_codeps_teps))
                        {
                            G1Sia_codeps_teps = G1Sia_codeps_teps.ToUpper();
                            if (G1Sia_codeps_teps != "NA")
                            {
                                var tmp = SIAValidarCodigo.fobRegBuscarSiatablaeps(G1Sia_codeps_teps);
                                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codeps_teps))
                                {
                                    G1Sia_deseps_teps = tmp.sia_deseps_teps;
                                    gobLiq.G2Sia_deseps_teps = tmp.sia_deseps_teps;

                                }
                                else
                                {
                                    lcrValorReturn = lcrNombreCampo + ": No existe";
                                }
                            }
                            else
                            {
                                lcrValorReturn = lcrNombreCampo + ": debe escribir un dato valido";
                            }

                        }
                        else
                        {
                            G1Sia_deseps_teps = String.Empty;
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

                    case "G1Cit_codspr_spro":
                        #region G1Cit_codspr_spro Código programa 
                        lcrNombreCampo = "Código programa";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A03";

                        if (String.IsNullOrWhiteSpace(G1Cit_codspr_spro))
                        {
                            //TmpG2ListaBrow = null;
                            lcrValorReturn = "Código programa: Es requerido";
                            //G1Fcm_coddig_mant = String.Empty;
                            TmpG2ListaBrow = new List<ModeloCitmaestroprotocolo>();
                        }
                        else 
                        {
                            G1Cit_codspr_spro = G1Cit_codspr_spro.ToUpper();
                            var tmp = CITValidarCodigo.fobRegBuscarCitservicioprog(G1Cit_codspr_spro);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.cit_codspr_spro))
                            {
                                if (GlgSIS_ModoAddPrograma == true)
                                {
                                    GlgSIS_ModoAddPrograma = false;

                                    TmpG2ListaBrow = ModeloCitmaestroprotocolo.flsListaCitservprotocol(G1Cit_codspr_spro);

                                    G1Cit_desspr_spro = tmp.cit_desspr_spro;
                                    A1Adm_codtat_tatn = tmp.adm_codtat_tatn;
                                    G1Fcm_codcpr_cpro = !String.IsNullOrWhiteSpace(G1Fcm_codcpr_cpro) ? G1Fcm_codcpr_cpro : tmp.fcm_codcpr_cpro;
                                    G1Fcm_tiprfa_mfac = tmp.fcm_tiprfa_mfac;
                                    tmpRegAdm.Adm_codtat_tatn = A1Adm_codtat_tatn; // Tipo Atencion 1= Ambulatoria 2=Hospitalizacion 3=Urgencias
                                    //- Datos relacionados con el servicio IPS
                                    var tmSIps = FCMValidarCodigo.fobRegBuscarFcmmanservicipsId(tmp.fcm_idesec_sips);
                                    if (tmSIps != null)
                                    {
                                        if (tmSIps.sia_codfco_fcon == "06") // PYP Atencion del Embarazo 
                                        { 
                                            tmpRegAdm.Adm_pacemb_rgad = "1";
                                            A1Adm_pacemb_rgad         = "1";
                                        }
                                    }
                                    //- Ambito de atencion medica
                                    var tmpAmbAte = new EFadmtipoatencion();
                                    tmpAmbAte = ADMValidarCodigo.fobRegBuscarAdmtipoatencion(A1Adm_codtat_tatn);
                                    if (tmpAmbAte != null)
                                    {
                                        G1Adm_destat_tatn = tmpAmbAte.adm_destat_tatn;
                                    }
                                    if (string.IsNullOrWhiteSpace(G1Adm_destat_tatn))
                                    {
                                        lcrValorReturn = "Ambito Atención: No existe";
                                    }
                                    fcvGenerarDetallesServProgramas();
                                }
                            }
                            else 
                            {
                                TmpG2ListaBrow = new List<ModeloCitmaestroprotocolo>();
                            }
                            if (string.IsNullOrWhiteSpace(G1Cit_desspr_spro))
                            {
                                lcrValorReturn = "Código programa: No existe";
                                TmpG2ListaBrow = new List<ModeloCitmaestroprotocolo>();
                            }
                        }
                        break;
                        #endregion

                    case "G1Cit_tipsol_mcit":
                        #region G1Cit_tipsol_mcit: Tipo solicitud cita
                        lcrNombreCampo = "Tipo solicitud cita";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A04";

                        if (string.IsNullOrWhiteSpace(G1Cit_tipsol_mcit))
                        {
                            lcrValorReturn = "Tipo solicitud cita: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G1Cit_tipsol_mcit, ",", "1,2,3,4"))
                            {
                                lcrValorReturn = "Tipo solicitud cita: Dato no es valido";
                            }
                        }
                        break;
                        #endregion

                    case "G1Cit_caucan_ccan":
                        #region G1Cit_caucan_ccan: Causa Cancelación cita
                        lcrNombreCampo = "Causa Cancelación cita";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A05";

                        //if (GlgSIS_ModoCancelar == true)
                        if (!String.IsNullOrWhiteSpace(G1Cit_caucan_ccan))
                        {
                            EFcitcausacancita tmp = new EFcitcausacancita();
                            tmp = CITValidarCodigo.fobRegBuscarCitcausacancita(G1Cit_caucan_ccan);
                            if (tmp != null)
                            {
                                G1Cit_descan_ccan = tmp.cit_descan_ccan;
                            }
                            if (string.IsNullOrWhiteSpace(G1Cit_descan_ccan))
                            {
                                lcrValorReturn = "Causa Cancelación cita: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sys_codusu_usux":
                        #region G1Sys_codusu_usux: Usuario facturador asigna
                        lcrNombreCampo = "Usuario facturador asigna";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A06";

                        if (string.IsNullOrWhiteSpace(G1Sys_codusu_usux))
                        {
                            lcrValorReturn = "Usuario facturador asigna: Es requerido";
                        }
                        else
                        {
                            EFsysusuarios tmp = new EFsysusuarios();
                            tmp = SYSValidarCodigo.fobRegBuscarSysusuarios(G1Sys_codusu_usux);
                            if (tmp != null)
                            {
                                G1Sys_nomusu_usux = tmp.sys_nomusu_usux;
                            }
                            if (string.IsNullOrWhiteSpace(G1Sys_nomusu_usux))
                            {
                                lcrValorReturn = "Usuario facturador asigna: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codare_aser":
                        #region G1Sia_codare_aser: Area de servicios
                        lcrNombreCampo = "Area de servicios";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A07";
                        if (string.IsNullOrWhiteSpace(G1Sia_codare_aser))
                        {
                            lcrValorReturn = "Area de servicios: Es requerido";
                        }
                        else
                        {
                            EFsiaareapreservi tmp = new EFsiaareapreservi();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaareapreservi(G1Sia_codare_aser);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codare_aser))
                            {
                                G1Sia_desare_aser = tmp.sia_desare_aser;
                                //G1Adm_codtat_tatn = tmp.adm_codtat_tatn;
                            }
                            else
                            {
                                lcrValorReturn = "Area de servicios: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Fcm_codcpr_cpro":
                        #region G1Fcm_codcpr_cpro: Código centro producción
                        lcrNombreCampo = "Código centro producción";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A08";
                        if (string.IsNullOrWhiteSpace(G1Fcm_codcpr_cpro))
                        {
                            lcrValorReturn = "Código centro producción: Es requerido";
                        }
                        else
                        {
                            var tmp = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(G1Fcm_codcpr_cpro);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.fcm_codcpr_cpro))
                            {
                                G1Fcm_descpr_cpro = tmp.fcm_descpr_cpro;
                                G1Sia_codare_aser = !String.IsNullOrWhiteSpace(G1Sia_codare_aser)?G1Sia_codare_aser: tmp.sia_codare_aser;
                            }
                            else
                            {
                                lcrValorReturn = "Código centro producción: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codpfa_prof":
                        #region G1Sia_codpfa_prof: Código profesional atiende
                        lcrNombreCampo = "Código profesional atiende";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A09";
                        if (string.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
                        {
                            lcrValorReturn = "Código profesional atiende: Es requerido";
                        }
                        else
                        {
                            G1Sia_codpfa_prof = G1Sia_codpfa_prof.ToUpper();

                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_codpfa_prof))
                            {
                                G1Sia_nompro_prof = tmp.sia_nompro_prof;
                            }
                            else
                            {
                                lcrValorReturn = "Código profesional atiende: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G1Sia_codesp_esme":
                        #region G1Sia_codesp_esme: Código especialidad
                        lcrNombreCampo = "Código especialidad";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A10";
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
                        #endregion

                    case "G1Cit_estcit_easi":
                        #region G2Cit_estcit_easi: Estado de la Cita
                        lcrNombreCampo = "Estado de la Cita:";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A11";

                        if (string.IsNullOrWhiteSpace(G1Cit_estcit_easi))
                        {
                            lcrValorReturn = "Estado de la Cita: Es requerido";
                        }
                        else
                        {
                            EFcitestadoascita tmp = new EFcitestadoascita();
                            tmp = CITValidarCodigo.fobRegBuscarCitestadoascita(G1Cit_estcit_easi);
                            if (tmp != null)
                            {
                                G1Cit_descit_easi = tmp.cit_descit_easi;
                            }
                            if (string.IsNullOrWhiteSpace(G1Cit_descit_easi))
                            {
                                lcrValorReturn = "Estado de la Cita: No existe";
                            }
                        }
                        break;
                        #endregion

                    case "G3Fcm_coddig_mant":
                        #region G5Fcm_coddig_mant: Validacion Código digitación servicio
                        lcrCodigoError = "A12";
                        lcrNombreCampo = "Código digitación servicio";
                        lcrNivelError = "ALTO";

                        gobLiq.G2Hcl_codreg_hcca = String.Empty;
                        gobLiq.G2Fcm_fecser_dfac = G1Cit_feccit_mcit;
                        gobLiq.G2Fcm_fecfac_mfac = G1Cit_feccit_mcit;
                        gobLiq.G2Cit_feccit_mcit = G1Cit_feccit_mcit;
                        gobLiq.G2Sis_estado_imaen = "A";

                        if (!String.IsNullOrWhiteSpace(G3Fcm_coddig_mant))
                        {
                            if (String.IsNullOrWhiteSpace(G1Cit_codspr_spro))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Primero debe diligenciar el valor Código del Programa";
                            }
                            else
                            {
                                G3Fcm_coddig_mant = G3Fcm_coddig_mant.ToUpper().Trim();
                                gobLiq.G2Fcm_coddig_mant = G3Fcm_coddig_mant;
                                gobLiq.G2Fcm_totuni_dfac = G3Fcm_totuni_dfac;
                                // aqui el codigo nuevo 
                                lcrValorReturn = gobLiq.fcrValidacionCampos("Fcm_coddig_mant", ref tmpAuxLogErrores, lcrNumeroRegistro);
                                if (String.IsNullOrWhiteSpace(lcrValorReturn))
                                {
                                    if (!flgValidacionPertinencia()) { lcrValorReturn = lcrNombreCampo + " : Error en validación pertinencia"; }

                                    G3Fcm_desser_dfac = gobLiq.G2Fcm_desser_dfac;
                                    fcvCalcularTotalServicio();
                                    fcvCalcularCopagoyCmoderadoras();
                                }
                            }
                        }
                        #endregion
                        break;

                    case "G3Fcm_totuni_dfac": // B02
                        #region Validacion Total unidades
                        lcrCodigoError = "B02";
                        lcrNombreCampo = "Total unidades";
                        lcrNivelError = "ALTO";

                        if (G3Fcm_totuni_dfac <= 0)
                        {
                            lcrValorReturn = "Total unidades: Debe ser mayor que cero";
                        }
                        else
                        {
                            gobLiq.G2Fcm_totuni_dfac = G3Fcm_totuni_dfac;
                            if (G3Fcm_totuni_dfac < 1 || G3Fcm_totuni_dfac > 9999)
                            {
                                lcrValorReturn = "Total unidades: Valor fuera del rango";
                            }
                            else if (G3Fcm_valser_mant > 0)
                            {
                                fcvCalcularTotalServicio();
                            }
                            else 
                            {
                                //lcrValorReturn = fcrValidacion("G3Fcm_coddig_mant");
                            }
                        }
                        #endregion
                        break;

                    case "A1Adm_nroaut_rgad":
                        #region ADM_NROAUT_RGAD: Numero Autorización
                        lcrNombreCampo = "Numero Autorización";
                        lcrValorReturn = String.Empty;
                        lcrCodigoError = "A13";
                        if (!string.IsNullOrWhiteSpace(A1Adm_nroaut_rgad))
                        {
                            if (!Funciones.flgExisteSubCadenaStringEx(A1Adm_nroaut_rgad, "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ-"))
                            {
                                lcrValorReturn = lcrNombreCampo + ": Contiene caracteres no permitidos";
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
        //-------------------------------------------------
        // fcvValorDefectoVariables: Valores por defecto variables de control
        //-------------------------------------------------
        #region fcvValorDefectoVariables: Valores por defecto variables de control
        /// <summary>
        /// Reiniciar los valores por defectos en las variables que controlan
        /// activacion de algunos campos y validacion de pertinencia.
        /// </summary>
        public void fcvValorDefectoVariables()
        {
            try
            {
                G3Fcm_valcmo_dfac = 0;
                G3Fcm_valcpa_dfac = 0;
                gobLiq.G2Fcm_valcmo_dfac = 0;
                gobLiq.G2Fcm_valcpa_dfac = 0;
                // Activar campos 
                gobLiq.m.fcvValorDefectoVariables();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvValorDefectoVar");
            }
        }
        #endregion
        #region flgValidContratoDetallesServ: Vlidacion detalles servicios y contrato
        /// <summary>
        /// <para>Validar para no permitir cambiar el numero de contrato despues</para>
        /// <para>de haber digitado servicios en lista detalles </para>
        /// </summary>
        private bool flgSiContratoDetallServicios()
        {
            var llgReturn = true;
            /*
            if (tmpListDetallFactBrw.Count > 0)
            {
                var lobreg = tmpListDetallFactBrw.FirstOrDefault(x => x.Cto_seccon_cont == G1Cto_seccon_cont);
                llgReturn = lobreg == null ? false : true;
            }*/
            return llgReturn;
        }
        #endregion
        #region fcvLimpiarVariables: Limpiar variables datos basicos
        /// <summary>
        /// <para>Limpiar variables datos basicos del paciente</para>
        /// </summary>
        private void fcvLimpiarVariables()
        {
            G1Sia_idesec_usua = String.Empty;
            G1Sia_tipide_tide = String.Empty;
            G1Sia_nomusu_usua = String.Empty;
            G1Cto_seccon_cont = String.Empty;
            G1Cto_nrocon_cont = String.Empty;
            G1Cto_descon_cont = String.Empty;
            G1Sia_codeps_teps = String.Empty;
            G1Sia_edaymd_usua = String.Empty;
            G1Sia_deside_tide = String.Empty;
            G1Sia_fecnac_usua = String.Empty;
            G1Sia_deseps_teps = String.Empty;
        }
        #endregion
    }
}
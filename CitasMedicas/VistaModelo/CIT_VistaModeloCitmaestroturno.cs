//- MARMOTA-GENCODE: VERSION 2.0 - 07/05/2013 07:36:27 PM
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
    /// <para>TABLA: citmaestroturno</para>
    /// <para>DESCRIPCION:
    ///  Maestro de turnos por profesional, contiene un registro por
    ///  cada fecha rengo de horas durante una jornada laboral (un día),
    ///  consultorio en que estará asignado el profesional
    /// </para>
    /// </summary>
    public class VistaModeloCitmaestroturno : VistaModeloCitmaestroturnoBase
    {
        //-------------------------------------------------
        // Variables Generales
        //-------------------------------------------------
        #region Variables Generales
        DbAplicacion db = new DbAplicacion();
        #endregion
        //-------------------------------------------------
        // tmpRegistro: Temporal para gestion de Registro
        //-------------------------------------------------
        #region tmpRegistro: Temporal para gestion de Registro
        public const string gcrNomProp_TmpRegistro = "TmpRegistro";
        private ModeloCitmaesasigcita _tmpRegistro;
        /// <summary>
        ///  Registro activo de la tabla: citmaesasigcita
        /// </summary>
        public ModeloCitmaesasigcita TmpRegistro
        {
            get { return _tmpRegistro; }
            set
            {
                if (_tmpRegistro == value) return;
                _tmpRegistro = value;
                RaisePropertyChanged(gcrNomProp_TmpRegistro);
            }
        }
        #endregion
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdGENTRN { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public override void fcvRegistrarComandos()
        {
            base.fcvRegistrarComandos();
            CmdGENTRN = new RelayCommand(fcvGenerarTurnos, CanGenTurno);  //Comando y Funcion para generar turnos
        }
        #endregion
        //-------------------------------------------------
        // fcvGenerarTurnos: Generar Turnos 
        //-------------------------------------------------
        #region fcvGenerarTurnos: Generar Turnos
        private void fcvGenerarTurnos()
        {
            #region Parametros generales
            //-----------------------------------------------
            // Parametros generales
            //-----------------------------------------------
            int lnuMinutosCita          = G1Cit_mindur_turn;
            int lnuMinutosCitaResto     = lnuMinutosCita;
            String lcrFormatoHora       = "12"; // Es doce horas AM/PM
            String lcrFormatoFecha      = "DMY";
            String lcrSeparadorFecha    = "/";
            String lcrSeparadorHora     = ":";
            String lcrSeparadorDecimal  = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
            //----
            fcvActualizarTempEdicion();
            TmpG2RegActivo = new ModeloCitmaesasigcita();
            TmpG2ListaBrow  = new ObservableCollection<ModeloCitmaesasigcita>();
            //-----------------------------------------------
            // Datos Inicio turno
            //-----------------------------------------------
            String lcrFechaIniTurno     = G1Cit_fecitr_turn.Trim();
            String lcrFechaIniTurnoGen  = lcrFechaIniTurno;
            DateTime ldaFechaIniTurno   = Convert.ToDateTime(lcrFechaIniTurno);
            String lcrHoraIniTurno      = G1Cit_horini_turn.Trim();
            String lcrHoraIniTurnoGen   = Funciones.fcrConvierteHora(lcrHoraIniTurno, lcrFormatoHora, lcrSeparadorHora, lcrSeparadorDecimal); // convierte a formato militar 24 
            Decimal lduHoraIniGen       = Convert.ToDecimal(lcrHoraIniTurnoGen);
            var lnullaveIniTurno        = Convert.ToInt64(Funciones.fcrGenLlaveRangoFechaHora(lcrFechaIniTurno, lcrFormatoFecha, 
                                                            lcrSeparadorFecha, lcrHoraIniTurno, lcrFormatoHora, lcrSeparadorHora));
            //-----------------------------------------------
            // Datos fin turno
            //-----------------------------------------------
            String lcrFechaFinTurno     = G1Cit_fecftr_turn.Trim();
            String lcrFechaFinTurnoGen  = lcrFechaFinTurno;
            DateTime ldaFechaFinTurno   = Convert.ToDateTime(lcrFechaFinTurno);
            String lcrHoraFinTurno      = G1Cit_horfin_turn.Trim();
            String lcrHoraFinTurnoGen   = lcrHoraIniTurnoGen;
            Decimal lduHoraFinGen       = lduHoraIniGen;
            var lnullaveFinTurno        = Convert.ToInt64(Funciones.fcrGenLlaveRangoFechaHora(lcrFechaFinTurno, lcrFormatoFecha, 
                                                            lcrSeparadorFecha, lcrHoraFinTurno, lcrFormatoHora, lcrSeparadorHora));
            //-----------------------------------------------
            // Tiempo total del turno 
            //-----------------------------------------------
            int lnuMinutosTruno = Funciones.fnuFechasCalHorasMinutos(ldaFechaIniTurno, ldaFechaFinTurno,
                                                                       lcrHoraIniTurno, lcrHoraFinTurno,
                                                                       lcrFormatoHora, lcrSeparadorHora, "M");
            int lnuHorasTurno = (int)(lnuMinutosTruno / 60);
            int lnuTotalTurnos = (int)(lnuMinutosTruno / lnuMinutosCita);
            if ((lnuMinutosTruno - (lnuTotalTurnos * lnuMinutosCita)) > 0)
            {
                lnuMinutosCitaResto = lnuMinutosTruno - (lnuTotalTurnos * lnuMinutosCita);
                lnuTotalTurnos = lnuTotalTurnos + 1;
            }
            //-Totales Horas de atencion y Espacios dentro del Turno
            G1Cit_hortdt_turn = lnuHorasTurno;
            G1Cit_totcit_turn = lnuTotalTurnos;
            #endregion
            //-----------------------------------------------
            // Datos que cambian al generar
            //-----------------------------------------------
            long lnullaveIniTurnoGen = 0;
            long lnullaveFinTurnoGen = 0;
            DateTime ldaFechaIniGen = ldaFechaIniTurno; // Inician en la misma fecha
            DateTime ldaFechaFinGen = ldaFechaIniTurno; // Inician en la misma fecha
            int lnuContador = 1;

            while (lnuContador <= lnuTotalTurnos)
            {
                //-------------------------------------
                //- Realizar Calculos de nuevo registro
                //-------------------------------------
                #region Realizar Calculos de nuevo registro
                TmpRegistro = new ModeloCitmaesasigcita();
                lcrFechaIniTurnoGen = lcrFechaFinTurnoGen;
                lcrHoraIniTurnoGen = lcrHoraFinTurnoGen;
                if (lnuContador == lnuTotalTurnos)
                {
                    lcrHoraFinTurnoGen = Funciones.fcrGenSiguienteHora(lcrHoraIniTurnoGen,
                                                                       lnuMinutosCitaResto, "24", "24", lcrSeparadorDecimal, lcrSeparadorDecimal);
                }
                else
                {
                    lcrHoraFinTurnoGen = Funciones.fcrGenSiguienteHora(lcrHoraIniTurnoGen,
                                                                       lnuMinutosCita, "24", "24", lcrSeparadorDecimal, lcrSeparadorDecimal);
                }
                lduHoraIniGen = Decimal.Parse(lcrHoraIniTurnoGen);
                lduHoraFinGen = Decimal.Parse(lcrHoraFinTurnoGen);
                // Verificar si la nueva hora esta en una fecha diferente 
                if ((int)lduHoraFinGen != (int)lduHoraIniGen) // se fue a siguiente hora 
                {
                    var lnuMinutoHoraIni = Convert.ToInt32(Funciones.fcrExtraerCompHora(lcrHoraIniTurnoGen, "MM", "24", lcrSeparadorDecimal));
                    var lnuSumaHoraSig = (int)((lnuMinutoHoraIni + lnuMinutosCita) / 60); // cuantas horas 
                    if ((int)lduHoraIniGen + lnuSumaHoraSig > 23)  // hora fin paso al siguiente dia 
                    {
                        ldaFechaFinGen = ldaFechaFinGen.AddDays(lnuSumaHoraSig);
                        lcrFechaFinTurnoGen = ldaFechaFinGen.ToShortDateString();
                    }
                }
                lnullaveIniTurnoGen = Convert.ToInt64(Funciones.fcrGenLlaveRangoFechaHora(lcrFechaIniTurnoGen, lcrFormatoFecha, 
                                                            lcrSeparadorFecha, lcrHoraIniTurnoGen, "24", lcrSeparadorDecimal));
                lnullaveFinTurnoGen = Convert.ToInt64(Funciones.fcrGenLlaveRangoFechaHora(lcrFechaFinTurnoGen, lcrFormatoFecha, 
                                                            lcrSeparadorFecha, lcrHoraFinTurnoGen, "24", lcrSeparadorDecimal)) - 1;
                #endregion
                //--------------------------------------
                //- Cargar el registro en temporal
                //--------------------------------------
                G1Cit_concit_turn++;
                #region Cargar valores desde Variables en registro
                TmpRegistro.Cit_codasi_mcit = "R" + G1Cit_concit_turn.ToString().Trim();
                TmpRegistro.Cit_codtur_turn = G1Cit_codtur_turn;
                TmpRegistro.Cit_ordvis_mcit = lnuContador;
                TmpRegistro.Cit_codspr_spro = "";
                TmpRegistro.Sia_codcat_ceat = G1Sia_codcat_ceat;
                TmpRegistro.Sia_codpfa_prof = G1Sia_codpfa_prof;
                TmpRegistro.Sia_codcon_ctor = G1Sia_codcon_ctor;
                TmpRegistro.Sia_codesp_esme = fcrEspecialidadProf("1", G1Sia_codpfa_prof.Trim());
                TmpRegistro.Cit_proqrx_mcit = "2";
                TmpRegistro.Sia_idesec_usua = "";
                TmpRegistro.Sia_tipide_tide = "";
                TmpRegistro.Sia_nroide_usua = "";
                TmpRegistro.Adm_secadm_rgad = "";
                TmpRegistro.Cit_fecreq_mcit = ldaFechaFinGen;
                TmpRegistro.Cit_feccit_mcit = ldaFechaFinGen;
                TmpRegistro.Cit_mindur_turn = G1Cit_mindur_turn;
                TmpRegistro.Cit_horini_mcit = lduHoraIniGen;
                TmpRegistro.Cit_horfni_mcit = lduHoraFinGen;
                TmpRegistro.Cit_idehin_mcit = lnullaveIniTurnoGen;
                TmpRegistro.Cit_idehfn_mcit = lnullaveFinTurnoGen;
                TmpRegistro.Cit_horina_mcit = 0;
                TmpRegistro.Cit_horfna_mcit = 0;
                TmpG2RegActivo.Cit_fecsol_mcit = Convert.ToDateTime("01/01/0001");
                TmpG2RegActivo.Cit_feccan_mcit = Convert.ToDateTime("01/01/0001");
                TmpG2RegActivo.Cit_horsol_mcit = 0;
                TmpG2RegActivo.Cit_horcon_mcit = 0;
                TmpG2RegActivo.Cit_horcan_mcit = 0;
                TmpG2RegActivo.Cit_notcan_mcit = "";
                TmpRegistro.Cit_tipsol_mcit = "";
                TmpRegistro.Cto_seccon_cont = "";
                TmpRegistro.Cto_nrocon_cont = "";
                TmpRegistro.Sia_codeps_teps = "";
                TmpRegistro.Cit_caucan_ccan = ""; 
                TmpRegistro.Sys_codusu_usux = "";
                TmpRegistro.Sys_codusc_usux = "";
                TmpRegistro.Cit_estcit_easi = "1";
                TmpRegistro.Sis_estpro_espr = "1";
                TmpRegistro.Sis_estado_imaen = "A";
                TmpRegistro.Sia_desesp_esme = fcrEspecialidadProf("2", TmpRegistro.Sia_codesp_esme.Trim());
                TmpRegistro.Cit_descit_easi = CITValidarCodigo.fcrDEBuscarCitestadoascita(TmpRegistro.Cit_estcit_easi.Trim());
                #endregion
                TmpG2ListaBrow.Add(TmpRegistro);
                TmpG2ListaEdt.Add(TmpRegistro);

                lnuContador++; // contar el turno 
            }
        }
        #endregion
        //-------------------------------------------------
        // fcvActualizarTempEdicion: Actualizar temporal edicion
        //-------------------------------------------------
        #region fcvActualizarTempEdicion: Actualizar temporal edicion
        /// <summary>
        ///Validación para saber si los registros existentes en 
        ///TmpG2ListaEdt se deben marcar para eliminacion en 
        ///base de datos o simplemente se eliminan del temporal
        /// </summary>
        private void fcvActualizarTempEdicion()
        {
            TmpG2ListaEdt = new ObservableCollection<ModeloCitmaesasigcita>();
            if (TmpG2ListaBrow.Count() > 0)
            {
                foreach (ModeloCitmaesasigcita lobReg in TmpG2ListaBrow)
                {
                    if (lobReg.Sis_estado_imaen != "A")
                    {
                        lobReg.Sis_estado_imaen = "E"; // maracar para eliminar
                        TmpG2ListaEdt.Add(lobReg);
                    }
                }
            }
        }
        #endregion
        //-------------------------------------------------
        // fcrEspecialidadProf: Especialidad por defecto
        //-------------------------------------------------
        #region fcrEspecialidadProf: Especialidad por defecto
        /// <summary>
        ///Devuelve el codigo de la especialidad por defecto
        ///para un profesional o la descripcion del codigo 
        ///especialidad dada en el parametro
        /// </summary>
        private String fcrEspecialidadProf(String tcrTipoCodigo,String tcrCodigo)
        {
            var lcrValor = String.Empty;
            if (tcrTipoCodigo == "1") // Codigo del profesional
            {
                lcrValor = db.Siamaeprofespas.FirstOrDefault(x => x.sia_codpfa_prof == tcrCodigo).sia_codesp_esme;
            }
            else 
            {
                lcrValor = db.Siaespecialimed.FirstOrDefault(x => x.sia_codesp_esme == tcrCodigo).sia_desesp_esme;
            }
            return lcrValor;
        }
        #endregion
        //-------------------------------------------------
        // Region Metodos que Validan activacion de opciones
        // en gestion de datos
        //-------------------------------------------------
        #region Metodos para Activacion de opciones
        #region CanGenTurno
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Generar turnos
        /// </summary>
        public bool CanGenTurno()
        {
            bool llgReturn = false;
            gcrSIS_PerfilCmdSAV = "NO";
            try
            {
                if (GlgSIS_ModoEdicion == true && CanSAV())
                {
                    #region Valores Variables
                    // Aqui validaciones para saber si generar turnos 
                    llgReturn = true; // por ahora
                    #endregion
                    if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanGenTurno");
            }
            return llgReturn;
        }
        #endregion
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
            //lcrValorReturn=base.fcrValidacion(tcrNombrePropiedad); //para llamar funcionalidad en clase Base
            try
            {
                switch (tcrNombrePropiedad)
                {
                    case "G1Sia_codcat_ceat":
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
                            if (string.IsNullOrWhiteSpace(G1Sia_descat_ceat))
                            {
                                lcrValorReturn = "Código centro atención: No existe";
                            }
                        }
                        break;

                    case "G1Sia_codpfa_prof":
                        if (string.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
                        {
                            lcrValorReturn = "Código profesional atiende: Es requerido";
                        }
                        else
                        {
                            EFsiamaeprofsalud tmp = new EFsiamaeprofsalud();
                            tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                            if (tmp != null)
                            {
                                G1Sia_nompro_prof = tmp.sia_nompro_prof;
                            }
                            if (string.IsNullOrWhiteSpace(G1Sia_nompro_prof))
                            {
                                lcrValorReturn = "Código profesional atiende: No existe";
                            }
                        }
                        break;

                    case "G1Sia_codcon_ctor":
                        if (string.IsNullOrWhiteSpace(G1Sia_codcon_ctor))
                        {
                            lcrValorReturn = "Código Consultorio: Es requerido";
                        }
                        else
                        {
                            EFsiaconsultorios tmp = new EFsiaconsultorios();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaconsultorios(G1Sia_codcon_ctor);
                            if (tmp != null)
                            {
                                G1Sia_descon_ctor = tmp.sia_descon_ctor;
                            }
                            if (string.IsNullOrWhiteSpace(G1Sia_descon_ctor))
                            {
                                lcrValorReturn = "Código Consultorio: No existe";
                            }
                        }
                        break;

                    case "G1Cit_fecitr_turn":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Cit_fecitr_turn, "Fecha Inicio turno");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                            String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Cit_fecftr_turn, "Fecha fin turno")))
                        {
                            // Validar Rango 
                            if (!Funciones.flgValidarRangoFecha(G1Cit_fecitr_turn, G1Cit_fecftr_turn))
                            {
                                lcrValorReturn = "Rango Fechas del turno no es valido";
                            }
                            else 
                            {
                                fcvGenDescripcionTurno();
                            }
                        }
                        break;

                    case "G1Cit_fecftr_turn":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Cit_fecftr_turn, "Fecha fin turno");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                            String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Cit_fecitr_turn, "Fecha Inicio turno")))
                        {
                            // Validar Rango 
                            if (!Funciones.flgValidarRangoFecha(G1Cit_fecitr_turn,G1Cit_fecftr_turn))
                            {
                                lcrValorReturn = "Rango Fechas del turno no es valido";
                            }
                            else
                            {
                                fcvGenDescripcionTurno();
                            }
                        }
                        break;

                    case "G1Cit_horini_turn":
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Cit_horini_turn, "12", ":", "Hora Inicio turno");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                            String.IsNullOrWhiteSpace(Funciones.fcrValidaHoraTexto(true, G1Cit_horfin_turn, "12", ":", "Hora fin turno")))
                        {
                            // Validar Rango de horas del turno
                            if (!flgValidarRangoHorasTurno())
                            {
                                lcrValorReturn = "Rango Horas turno no valido";
                            }
                            else 
                            {
                                fcvGenerarDatosVarios();
                            }
                        }
                        break;

                    case "G1Cit_horfin_turn":
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Cit_horfin_turn, "12", ":", "Hora fin turno");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                            String.IsNullOrWhiteSpace(Funciones.fcrValidaHoraTexto(true, G1Cit_horini_turn, "12", ":", "Hora Inicio turno")))
                        {
                            // Validar Rango de horas del turno
                            if (!flgValidarRangoHorasTurno())
                            {
                                lcrValorReturn = "Rango Horas turno no valido";
                            }
                            else
                            {
                                fcvGenerarDatosVarios();
                            }
                        }
                        break;

                    case "G1Cit_mindur_turn":
                        if (G1Cit_mindur_turn <= 0)
                        {
                            lcrValorReturn = "Minutos citas: Debe ser mayor que cero";
                        }
                        else
                        {
                            if (G1Cit_mindur_turn < 5 || G1Cit_mindur_turn > 250)
                            {
                                lcrValorReturn = "Minutos citas: Valor fuera del rango";
                            }
                        }
                        break;

                    case "G1Sis_estpro_espr":
                        if (string.IsNullOrWhiteSpace(G1Sis_estpro_espr))
                        {
                            lcrValorReturn = "Estado turno: Es requerido";
                        }
                        else
                        {
                            EFsisestadoproces tmp = new EFsisestadoproces();
                            tmp = SISValidarCodigo.fobRegBuscarSisestadoproces(G1Sis_estpro_espr);
                            if (tmp != null)
                            {
                                G1Sis_despro_espr = tmp.sis_despro_espr;
                            }
                            if (string.IsNullOrWhiteSpace(G1Sis_despro_espr))
                            {
                                lcrValorReturn = "Estado turno: No existe";
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
                    case "G2Sia_codesp_esme":
                        if (string.IsNullOrWhiteSpace(G2Sia_codesp_esme))
                        {
                            lcrValorReturn = "Código especialidad: Es requerido";
                        }
                        else
                        {
                            EFsiaespecialimed tmp = new EFsiaespecialimed();
                            tmp = SIAValidarCodigo.fobRegBuscarSiaespecialimed(G2Sia_codesp_esme);
                            if (tmp != null)
                            {
                                G2Sia_desesp_esme = tmp.sia_desesp_esme;
                            }
                            if (string.IsNullOrWhiteSpace(G2Sia_desesp_esme))
                            {
                                lcrValorReturn = "Código especialidad: No existe";
                            }
                        }
                        break;

                    case "G2Cit_proqrx_mcit":
                        if (string.IsNullOrWhiteSpace(G2Cit_proqrx_mcit))
                        {
                            lcrValorReturn = "Cita Quirúrgica: Es requerido";
                        }
                        else
                        {
                            if (!Funciones.flgExisteElemento(G2Cit_proqrx_mcit, ",", "1,2"))
                            {
                                lcrValorReturn = "Cita Quirúrgica: Dato no es valido";
                            }
                        }
                        break;

                    case "G2Cit_feccit_mcit":
                        lcrValorReturn = Funciones.fcrValidaFechaTexto(true, "DMY", "/", G2Cit_feccit_mcit, "Fecha cita");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                            String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Cit_fecitr_turn, "Fecha Inicio turno")) &&
                            String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Cit_fecftr_turn, "Fecha fin turno")))
                        {
                            DateTime ldaFechaIni, ldaFechaFin,ldaFechaCita;
                            DateTime.TryParse(G1Cit_fecitr_turn, out ldaFechaIni);
                            DateTime.TryParse(G1Cit_fecftr_turn, out ldaFechaFin);
                            DateTime.TryParse(G2Cit_feccit_mcit, out ldaFechaCita);
                            if (ldaFechaCita < ldaFechaIni || ldaFechaCita > ldaFechaFin) 
                            {
                                lcrValorReturn = "Fecha cita: No esta dentro rango del turno"; 
                            }
                        }
                        break;

                    case "G2Cit_horini_mcit":
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G2Cit_horini_mcit, "12", ":", "Hora Inicio programada");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                            String.IsNullOrWhiteSpace(Funciones.fcrValidaHoraTexto(true, G2Cit_horfni_mcit, "12", ":", "Hora fin programada")))
                        {
                            // Validar Rango de horas del turno
                            if (!flgValidarRangoHorasCita())
                            {
                                lcrValorReturn = "Rango de tiempo cita no valido";
                            }
                        }
                        break;

                    case "G2Cit_horfni_mcit":
                        lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G2Cit_horfni_mcit,"12", ":","Hora fin programada");
                        if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                            String.IsNullOrWhiteSpace(Funciones.fcrValidaHoraTexto(true, G2Cit_horini_mcit, "12", ":", "Hora Inicio programada")))
                        {
                            // Validar Rango de horas del turno
                            if (!flgValidarRangoHorasCita())
                            {
                                lcrValorReturn = "Rango de tiempo cita no valido";
                            }
                        }
                        break;

                    case "G2Cit_caucan_ccan":
                        if (!string.IsNullOrWhiteSpace(G2Cit_caucan_ccan))
                        {
                            EFcitcausacancita tmp = new EFcitcausacancita();
                            tmp = CITValidarCodigo.fobRegBuscarCitcausacancita(G2Cit_caucan_ccan);
                            if (tmp != null)
                            {
                                G2Cit_descan_ccan = tmp.cit_descan_ccan;
                            }
                            if (string.IsNullOrWhiteSpace(G2Cit_descan_ccan))
                            {
                                lcrValorReturn = "Causa Cancelación cita: No existe";
                            }
                        }
                        break;

                    case "G2Cit_estcit_easi":
                        if (string.IsNullOrWhiteSpace(G2Cit_estcit_easi))
                        {
                            lcrValorReturn = "Estado de la Cita: Es requerido";
                        }
                        else
                        {
                            EFcitestadoascita tmp = new EFcitestadoascita();
                            tmp = CITValidarCodigo.fobRegBuscarCitestadoascita(G2Cit_estcit_easi);
                            if (tmp != null)
                            {
                                G2Cit_descit_easi = tmp.cit_descit_easi;
                            }
                            if (string.IsNullOrWhiteSpace(G2Cit_descit_easi))
                            {
                                lcrValorReturn = "Estado de la Cita: No existe";
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
        //-------------------------------------------------
        // flgValidarRangoHorasTurno: Validar rango fechas 
        // y horas del turno.
        //-------------------------------------------------
        #region  flgValidarRangoHorasTurno: Validar rango fechas y horas
        /// <summary>
        ///Devuelve verdader si le rango de fechas y horas para 
        ///el turno es valido.
        /// </summary>
        private bool flgValidarRangoHorasTurno()
        {
            var llgValor = false;
            if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Cit_fecitr_turn, "Fecha Inicio turno")) &&
                String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", G1Cit_fecftr_turn, "Fecha fin turno")))
            {
                // Validar Rango 
                if (Funciones.flgValidarRangoFecha(G1Cit_fecitr_turn, G1Cit_fecftr_turn))
                {
                    var lnullaveIni = Convert.ToInt64(Funciones.fcrGenLlaveRangoFechaHora(G1Cit_fecitr_turn, "DMY", "/", G1Cit_horini_turn, "12", ":"));
                    var lnullaveFin = Convert.ToInt64(Funciones.fcrGenLlaveRangoFechaHora(G1Cit_fecftr_turn, "DMY", "/", G1Cit_horfin_turn, "12", ":"));
                    if (lnullaveIni < lnullaveFin) { llgValor = true; }
                }
            }
            return llgValor;
        }
        #endregion
        //-------------------------------------------------
        // flgValidarRangoHorasCita: Validar rango tiempo cita
        //-------------------------------------------------
        #region  flgValidarRangoHorasCita: Validar rango tiempo cita
        /// <summary>
        ///Devuelve verdader si la fecha y horas para 
        ///la cita es válida.
        /// </summary>
        private bool flgValidarRangoHorasCita()
        {
            var llgValor = false;
            var lcrValorReturn = String.Empty;
            //--------------------------------------------
            //  Validar que el rango del turno sea valido
            //--------------------------------------------
            lcrValorReturn = Funciones.fcrValidaHoraTexto(true, G1Cit_horini_turn, "12", ":", "Hora Inicio turno");
            if (String.IsNullOrWhiteSpace(lcrValorReturn) &&
                String.IsNullOrWhiteSpace(Funciones.fcrValidaHoraTexto(true, G1Cit_horfin_turn, "12", ":", "Hora fin turno")))
            {
                llgValor=flgValidarRangoHorasTurno();
            }
            if (llgValor == true)
            {
                llgValor = false;
                if (String.IsNullOrWhiteSpace(Funciones.fcrValidaFechaTexto(true, "DMY", "/", G2Cit_feccit_mcit, "Fecha cita")))
                {
                    // Validar Rango 
                    if (Funciones.flgValidarRangoFecha(G2Cit_feccit_mcit,G1Cit_fecitr_turn, G1Cit_fecftr_turn))
                    {
                        var lnullaveIni = Convert.ToInt32(Funciones.fcrGenLlaveRangoFechaHora(G1Cit_fecitr_turn, "DMY", "/", G1Cit_horini_turn, "12", ":"));
                        var lnullaveFin = Convert.ToInt32(Funciones.fcrGenLlaveRangoFechaHora(G1Cit_fecftr_turn, "DMY", "/", G1Cit_horfin_turn, "12", ":"));
                        var lnullaveIniCit = Convert.ToInt32(Funciones.fcrGenLlaveRangoFechaHora(G2Cit_feccit_mcit, "DMY", "/", G2Cit_horini_mcit, "12", ":"));
                        var lnullaveFinCit = Convert.ToInt32(Funciones.fcrGenLlaveRangoFechaHora(G2Cit_feccit_mcit, "DMY", "/", G2Cit_horfni_mcit, "12", ":"));
                        if (lnullaveIniCit >= lnullaveIni && lnullaveIniCit < lnullaveFin &&
                            lnullaveFinCit > lnullaveIni && lnullaveFinCit <= lnullaveFin) 
                        { 
                            llgValor = true; 
                        }
                    }
                }
            }
            return llgValor;
        }
        #endregion
        //-------------------------------------------------
        // fcvGenDescripcionTurno: Generar la descripcion del turno
        //-------------------------------------------------
        #region fcvGenDescripcionTurno: Generar la descripcion del turno
        /// <summary>
        /// Generar la descripcion del turno
        /// </summary>
        private void fcvGenDescripcionTurno()
        {
            // Validar Rango 
            if (Funciones.flgValidarRangoFecha(G1Cit_fecitr_turn, G1Cit_fecftr_turn))
            {
                DateTime ldaFechaIni, ldaFechaFin;
                DateTime.TryParse(G1Cit_fecitr_turn, out ldaFechaIni);
                DateTime.TryParse(G1Cit_fecftr_turn, out ldaFechaFin);
                var lcrRanFecha = G1Cit_fecitr_turn.Trim();
                if (G1Cit_fecitr_turn.Trim() != G1Cit_fecftr_turn.Trim())
                {
                    lcrRanFecha = G1Cit_fecitr_turn.Trim() + " a " + G1Cit_fecftr_turn.Trim();
                }
                var lcrFecha = ldaFechaIni.ToLongDateString().ToString();
                G1Cit_destur_turn = lcrFecha.Substring(0, 1).ToUpper() + lcrFecha.Substring(1, lcrFecha.Length - 1) +
                                    " (" + G1Cit_horini_turn.Trim() + " - " + G1Cit_horfin_turn.Trim()+")";
            }
        }
        #endregion
        //-------------------------------------------------
        // fcvGenerarDatosVarios: Genera datos varios basados en horas
        //-------------------------------------------------
        #region  flgValidarRangoHorasCita: Validar rango tiempo cita
        /// <summary>
        ///Devuelve verdader si la fecha y horas para 
        ///la cita es válida.
        /// </summary>
        private void fcvGenerarDatosVarios()
        {
            var lcrValorReturn = String.Empty;
            DateTime ldaFechaIni, ldaFechaFin;
            String lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
            if (G1Cit_mindur_turn >= 10 && G1Cit_mindur_turn <= 250)
            {
                //---------------------------------------------------
                DateTime.TryParse(G1Cit_fecitr_turn, out ldaFechaIni);
                DateTime.TryParse(G1Cit_fecftr_turn, out ldaFechaFin);
                //---------------------------------------------------
                int lnuMinutosTruno = Funciones.fnuFechasCalHorasMinutos(ldaFechaIni, ldaFechaFin, G1Cit_horini_turn, G1Cit_horfin_turn, "12", ":", "M");
                G1Cit_hortdt_turn = (int)(lnuMinutosTruno / 60);
                G1Cit_totcit_turn = (int)(lnuMinutosTruno / G1Cit_mindur_turn);
                if ((lnuMinutosTruno - (G1Cit_totcit_turn * G1Cit_mindur_turn)) > 0) { G1Cit_totcit_turn = G1Cit_totcit_turn + 1; }
            }
        }
        #endregion

    }
}
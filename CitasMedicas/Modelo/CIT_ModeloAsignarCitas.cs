//- MARMOTA-GENCODE: VERSION 2.0 - 02/06/2013 05:30:10 PM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using Datos.Modelos;
using Sistema.Utilidades;
using Sistema.Modelo;

namespace CitasMedicas.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: citmaesasigcita
    /// </summary>
    public class ModeloAsignarCitas : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Cit_codasi_mcit: Código único registro cita
        private String _cit_codasi_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Código único registro cita</para>
        /// <para>NOMBRE: cit_codasi_mcit (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del registro asignación de cita a paciente (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Cit_codasi_mcit
        {
            get { return _cit_codasi_mcit; }
            set
            {
                if (_cit_codasi_mcit == value) return;
                _cit_codasi_mcit = value;
                OnPropertyChanged("Cit_codasi_mcit");
            }
        }
        #endregion
        #region Cit_codtur_turn: Código turno medico
        private String _cit_codtur_turn;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Código turno medico</para>
        /// <para>NOMBRE: cit_codtur_turn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código único del turno medico que realizara la atención
        /// </para>
        /// </summary>
        public String Cit_codtur_turn
        {
            get { return _cit_codtur_turn; }
            set
            {
                if (_cit_codtur_turn == value) return;
                _cit_codtur_turn = value;
                OnPropertyChanged("Cit_codtur_turn");
            }
        }
        #endregion
        #region Cit_ordvis_mcit: Orden Vista
        private int _cit_ordvis_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: cit_ordvis_mcit (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion del registro de turno
        /// </para>
        /// </summary>
        public int Cit_ordvis_mcit
        {
            get { return _cit_ordvis_mcit; }
            set
            {
                if (_cit_ordvis_mcit == value) return;
                _cit_ordvis_mcit = value;
                OnPropertyChanged("Cit_ordvis_mcit");
            }
        }
        #endregion
        #region Cit_ordcon_mcit: Orden llegada cita
        private int _cit_ordcon_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Orden llegada cita</para>
        /// <para>NOMBRE: cit_ordcon_mcit (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Orden de confirmacion en facturacion o llegada  a consultorio
        /// </para>
        /// </summary>
        public int Cit_ordcon_mcit
        {
            get { return _cit_ordcon_mcit; }
            set
            {
                if (_cit_ordcon_mcit == value) return;
                _cit_ordcon_mcit = value;
                OnPropertyChanged("Cit_ordcon_mcit");
            }
        }
        #endregion
        #region Cit_codspr_spro: Código programa
        private String _cit_codspr_spro;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Código programa</para>
        /// <para>NOMBRE: cit_codspr_spro (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Código único del servicio para programación y gestión en citas
        /// medicas y otros ejm =S001 = Consulta externa S003=Consulta
        /// Control pyp Adulto joven
        /// </para>
        /// </summary>
        public String Cit_codspr_spro
        {
            get { return _cit_codspr_spro; }
            set
            {
                if (_cit_codspr_spro == value) return;
                _cit_codspr_spro = value;
                OnPropertyChanged("Cit_codspr_spro");
            }
        }
        #endregion
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public String Sia_codcat_ceat
        {
            get { return _sia_codcat_ceat; }
            set
            {
                if (_sia_codcat_ceat == value) return;
                _sia_codcat_ceat = value;
                OnPropertyChanged("Sia_codcat_ceat");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código profesional atiende
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código profesional atiende</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional que presta servicio medico
        /// </para>
        /// </summary>
        public String Sia_codpfa_prof
        {
            get { return _sia_codpfa_prof; }
            set
            {
                if (_sia_codpfa_prof == value) return;
                _sia_codpfa_prof = value;
                OnPropertyChanged("Sia_codpfa_prof");
            }
        }
        #endregion
        #region Sia_codcon_ctor: Código Consultorio
        private String _sia_codcon_ctor;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Código Consultorio</para>
        /// <para>NOMBRE: sia_codcon_ctor (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Código del consultorio donde se prestara el servicio
        /// </para>
        /// </summary>
        public String Sia_codcon_ctor
        {
            get { return _sia_codcon_ctor; }
            set
            {
                if (_sia_codcon_ctor == value) return;
                _sia_codcon_ctor = value;
                OnPropertyChanged("Sia_codcon_ctor");
            }
        }
        #endregion
        #region Sia_codesp_esme: Código especialidad
        private String _sia_codesp_esme;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Código especialidad</para>
        /// <para>NOMBRE: sia_codesp_esme (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código de la especialidad medica que aplica al  servicio
        /// </para>
        /// </summary>
        public String Sia_codesp_esme
        {
            get { return _sia_codesp_esme; }
            set
            {
                if (_sia_codesp_esme == value) return;
                _sia_codesp_esme = value;
                OnPropertyChanged("Sia_codesp_esme");
            }
        }
        #endregion
        #region Cit_proqrx_mcit: Cita Quirúrgica
        private String _cit_proqrx_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Cita Quirúrgica</para>
        /// <para>NOMBRE: cit_proqrx_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Cita para programación de Cirugía: 1=Cirugía 2=Cita no Quirúrgica
        /// </para>
        /// </summary>
        public String Cit_proqrx_mcit
        {
            get { return _cit_proqrx_mcit; }
            set
            {
                if (_cit_proqrx_mcit == value) return;
                _cit_proqrx_mcit = value;
                OnPropertyChanged("Cit_proqrx_mcit");
            }
        }
        #endregion
        #region Adm_codtat_tatn: Ambito Atención
        private String _adm_codtat_tatn;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Ambito Atención</para>
        /// <para>NOMBRE: adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codigo ambito dende se prestara el servicio :1=Ambulatoria
        /// 2=Hospitalizacion 3=Urgencia
        /// </para>
        /// </summary>
        public String Adm_codtat_tatn
        {
            get { return _adm_codtat_tatn; }
            set
            {
                if (_adm_codtat_tatn == value) return;
                _adm_codtat_tatn = value;
                OnPropertyChanged("Adm_codtat_tatn");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de paciente en el sistema
        /// </para>
        /// </summary>
        public String Sia_idesec_usua
        {
            get { return _sia_idesec_usua; }
            set
            {
                if (_sia_idesec_usua == value) return;
                _sia_idesec_usua = value;
                OnPropertyChanged("Sia_idesec_usua");
            }
        }
        #endregion
        #region Sia_tipide_tide: Tipo Identificación
        private String _sia_tipide_tide;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula, RC= Registro
        /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin identificación
        /// y otros
        /// </para>
        /// </summary>
        public String Sia_tipide_tide
        {
            get { return _sia_tipide_tide; }
            set
            {
                if (_sia_tipide_tide == value) return;
                _sia_tipide_tide = value;
                OnPropertyChanged("Sia_tipide_tide");
            }
        }
        #endregion
        #region Sia_nroide_usua: Identificación paciente
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación paciente</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public String Sia_nroide_usua
        {
            get { return _sia_nroide_usua; }
            set
            {
                if (_sia_nroide_usua == value) return;
                _sia_nroide_usua = value;
                OnPropertyChanged("Sia_nroide_usua");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Registro de atención o Admisión del paciente,
        /// cuando cumple la cita
        /// </para>
        /// </summary>
        public String Adm_secadm_rgad
        {
            get { return _adm_secadm_rgad; }
            set
            {
                if (_adm_secadm_rgad == value) return;
                _adm_secadm_rgad = value;
                OnPropertyChanged("Adm_secadm_rgad");
            }
        }
        #endregion
        #region Cit_fecsol_mcit: Fecha solicitud cita
        private DateTime _cit_fecsol_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha solicitud cita</para>
        /// <para>NOMBRE: cit_fecsol_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud de cita por parte del usuario
        /// </para>
        /// </summary>
        public DateTime Cit_fecsol_mcit
        {
            get { return _cit_fecsol_mcit; }
            set
            {
                if (_cit_fecsol_mcit == value) return;
                _cit_fecsol_mcit = value;
                OnPropertyChanged("Cit_fecsol_mcit");
            }
        }
        #endregion
        #region Cit_horsol_mcit: Hora solicitud cita
        private Decimal _cit_horsol_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora solicitud cita</para>
        /// <para>NOMBRE: cit_horsol_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Hora solicitud de cita (en formato militar) ejemplo:  14.00
        /// (dos de la tarde)
        /// </para>
        /// </summary>
        public Decimal Cit_horsol_mcit
        {
            get { return _cit_horsol_mcit; }
            set
            {
                if (_cit_horsol_mcit == value) return;
                _cit_horsol_mcit = value;
                OnPropertyChanged("Cit_horsol_mcit");
            }
        }
        #endregion
        #region Cit_fecreq_mcit: Fecha requiere cita
        private DateTime _cit_fecreq_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha requiere cita</para>
        /// <para>NOMBRE: cit_fecreq_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Fecha para la cual el usuario requiere la cita (esta puede
        /// ser igual a la fecha de programacion cita cuando hay espacio
        /// para la asignacion)
        /// </para>
        /// </summary>
        public DateTime Cit_fecreq_mcit
        {
            get { return _cit_fecreq_mcit; }
            set
            {
                if (_cit_fecreq_mcit == value) return;
                _cit_fecreq_mcit = value;
                OnPropertyChanged("Cit_fecreq_mcit");
            }
        }
        #endregion
        #region Cit_feccit_mcit: Fecha asignacion cita
        private DateTime _cit_feccit_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha cita</para>
        /// <para>NOMBRE: cit_feccit_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Fecha programada para la cita
        /// </para>
        /// </summary>
        public DateTime Cit_feccit_mcit
        {
            get { return _cit_feccit_mcit; }
            set
            {
                if (_cit_feccit_mcit == value) return;
                _cit_feccit_mcit = value;
                OnPropertyChanged("Cit_feccit_mcit");
            }
        }
        #endregion
        #region Cit_horcon_mcit: Hora confirmacion cita
        private Decimal _cit_horcon_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora confirmacion cita</para>
        /// <para>NOMBRE: cit_horcon_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Hora llegada del usuario a confirmacion de cita (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public Decimal Cit_horcon_mcit
        {
            get { return _cit_horcon_mcit; }
            set
            {
                if (_cit_horcon_mcit == value) return;
                _cit_horcon_mcit = value;
                OnPropertyChanged("Cit_horcon_mcit");
            }
        }
        #endregion
        #region Cit_mindur_turn: Minutos citas
        private int _cit_mindur_turn;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Minutos citas</para>
        /// <para>NOMBRE: cit_mindur_turn (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Numero minutos que demora la prestación del servicio ejm 30
        /// es un servicio que demora treinta minutos
        /// </para>
        /// </summary>
        public int Cit_mindur_turn
        {
            get { return _cit_mindur_turn; }
            set
            {
                if (_cit_mindur_turn == value) return;
                _cit_mindur_turn = value;
                OnPropertyChanged("Cit_mindur_turn");
            }
        }
        #endregion
        #region Cit_horini_mcit: Hora Inicio programada
        private Decimal _cit_horini_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora Inicio programada</para>
        /// <para>NOMBRE: cit_horini_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Hora programada para el inicio de la atención medica (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public Decimal Cit_horini_mcit
        {
            get { return _cit_horini_mcit; }
            set
            {
                if (_cit_horini_mcit == value) return;
                _cit_horini_mcit = value;
                OnPropertyChanged("Cit_horini_mcit");
            }
        }
        #endregion
        #region Cit_horfni_mcit: Hora fin programada
        private Decimal _cit_horfni_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora fin programada</para>
        /// <para>NOMBRE: cit_horfni_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Hora programada para finalizar la atención medica (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public Decimal Cit_horfni_mcit
        {
            get { return _cit_horfni_mcit; }
            set
            {
                if (_cit_horfni_mcit == value) return;
                _cit_horfni_mcit = value;
                OnPropertyChanged("Cit_horfni_mcit");
            }
        }
        #endregion
        #region Cit_horina_mcit: Hora Inicio atención
        private Decimal _cit_horina_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora Inicio atención</para>
        /// <para>NOMBRE: cit_horina_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Hora real en que inicio la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public Decimal Cit_horina_mcit
        {
            get { return _cit_horina_mcit; }
            set
            {
                if (_cit_horina_mcit == value) return;
                _cit_horina_mcit = value;
                OnPropertyChanged("Cit_horina_mcit");
            }
        }
        #endregion
        #region Cit_horfna_mcit: Hora fin atención
        private Decimal _cit_horfna_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora fin atención</para>
        /// <para>NOMBRE: cit_horfna_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Hora en que finaliza la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public Decimal Cit_horfna_mcit
        {
            get { return _cit_horfna_mcit; }
            set
            {
                if (_cit_horfna_mcit == value) return;
                _cit_horfna_mcit = value;
                OnPropertyChanged("Cit_horfna_mcit");
            }
        }
        #endregion
        #region Cit_idehin_mcit: llave Inicio cita
        private long _cit_idehin_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: llave Inicio cita</para>
        /// <para>NOMBRE: cit_idehin_mcit (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora inicio cita,  para
        /// validación rango o  vista en Browser formato: AñoInicio+MesInicio+DiaInic
        /// io+HoraInicio+MinutoInicio
        /// </para>
        /// </summary>
        public long Cit_idehin_mcit
        {
            get { return _cit_idehin_mcit; }
            set
            {
                if (_cit_idehin_mcit == value) return;
                _cit_idehin_mcit = value;
                OnPropertyChanged("Cit_idehin_mcit");
            }
        }
        #endregion
        #region Cit_idehfn_mcit: llave fin cita
        private long _cit_idehfn_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: llave fin cita</para>
        /// <para>NOMBRE: cit_idehfn_mcit (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora fin cita,  para
        /// validación rango  formato: AñoFin+MesFin+DiaFin+HoraFin+MinutoFin
        /// </para>
        /// </summary>
        public long Cit_idehfn_mcit
        {
            get { return _cit_idehfn_mcit; }
            set
            {
                if (_cit_idehfn_mcit == value) return;
                _cit_idehfn_mcit = value;
                OnPropertyChanged("Cit_idehfn_mcit");
            }
        }
        #endregion
        #region Cit_tipsol_mcit: Tipo solicitud cita
        private String _cit_tipsol_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Tipo solicitud cita</para>
        /// <para>NOMBRE: cit_tipsol_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Tipo de solicitud de la Cita o programación: 1= Solicitada
        /// en Ventanilla 2= Telefónica 3= Programa de control 4= Asignación
        /// por cirugía o especialidad
        /// </para>
        /// </summary>
        public String Cit_tipsol_mcit
        {
            get { return _cit_tipsol_mcit; }
            set
            {
                if (_cit_tipsol_mcit == value) return;
                _cit_tipsol_mcit = value;
                OnPropertyChanged("Cit_tipsol_mcit");
            }
        }
        #endregion
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Secuencial Único de Contrato
        /// </para>
        /// </summary>
        public String Cto_seccon_cont
        {
            get { return _cto_seccon_cont; }
            set
            {
                if (_cto_seccon_cont == value) return;
                _cto_seccon_cont = value;
                OnPropertyChanged("Cto_seccon_cont");
            }
        }
        #endregion
        #region Cto_nrocon_cont: Número Contrato
        private String _cto_nrocon_cont;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public String Cto_nrocon_cont
        {
            get { return _cto_nrocon_cont; }
            set
            {
                if (_cto_nrocon_cont == value) return;
                _cto_nrocon_cont = value;
                OnPropertyChanged("Cto_nrocon_cont");
            }
        }
        #endregion
        #region Sia_codeps_teps: Código EPS
        private String _sia_codeps_teps;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según códigos asignados por la supersalud
        /// </para>
        /// </summary>
        public String Sia_codeps_teps
        {
            get { return _sia_codeps_teps; }
            set
            {
                if (_sia_codeps_teps == value) return;
                _sia_codeps_teps = value;
                OnPropertyChanged("Sia_codeps_teps");
            }
        }
        #endregion
        #region Sia_codare_aser: Area de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Area de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Código área de servicio donde se prestan los servicios (puede
        /// ser la misma desde el ingreso, cuando no hay traslados internos
        /// a otras aéreas)
        /// </para>
        /// </summary>
        public String Sia_codare_aser
        {
            get { return _sia_codare_aser; }
            set
            {
                if (_sia_codare_aser == value) return;
                _sia_codare_aser = value;
                OnPropertyChanged("Sia_codare_aser");
            }
        }
        #endregion
        #region Fcm_codcpr_cpro: Código centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Codigo centro de produccion donde se presta el servicio solo
        /// aplicable para tipo de registros evolucion (para envio a facturacion)
        /// </para>
        /// </summary>
        public String Fcm_codcpr_cpro
        {
            get { return _fcm_codcpr_cpro; }
            set
            {
                if (_fcm_codcpr_cpro == value) return;
                _fcm_codcpr_cpro = value;
                OnPropertyChanged("Fcm_codcpr_cpro");
            }
        }
        #endregion
        #region Cit_caucan_ccan: Causa Cancelación cita
        private String _cit_caucan_ccan;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citcausacancita</para>
        /// <para>CAMPO: Causa Cancelación cita</para>
        /// <para>NOMBRE: cit_caucan_ccan (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Causa de Cancelación de la Cita medica
        /// </para>
        /// </summary>
        public String Cit_caucan_ccan
        {
            get { return _cit_caucan_ccan; }
            set
            {
                if (_cit_caucan_ccan == value) return;
                _cit_caucan_ccan = value;
                OnPropertyChanged("Cit_caucan_ccan");
            }
        }
        #endregion
        #region Cit_feccan_mcit: Fecha cancelacion cita
        private DateTime _cit_feccan_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha cancelacion cita</para>
        /// <para>NOMBRE: cit_feccan_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Fecha canelacion de cita por parte del usuario
        /// </para>
        /// </summary>
        public DateTime Cit_feccan_mcit
        {
            get { return _cit_feccan_mcit; }
            set
            {
                if (_cit_feccan_mcit == value) return;
                _cit_feccan_mcit = value;
                OnPropertyChanged("Cit_feccan_mcit");
            }
        }
        #endregion
        #region Cit_horcan_mcit: Hora cancelacion cita
        private Decimal _cit_horcan_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora cancelacion cita</para>
        /// <para>NOMBRE: cit_horcan_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Hora cancelacion de cita (en formato militar) ejemplo:  14.00
        /// (dos de la tarde)
        /// </para>
        /// </summary>
        public Decimal Cit_horcan_mcit
        {
            get { return _cit_horcan_mcit; }
            set
            {
                if (_cit_horcan_mcit == value) return;
                _cit_horcan_mcit = value;
                OnPropertyChanged("Cit_horcan_mcit");
            }
        }
        #endregion
        #region Cit_notcan_mcit: Nota cancelación cita
        private String _cit_notcan_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Nota cancelación cita</para>
        /// <para>NOMBRE: cit_notcan_mcit (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        ///Nota textual cancelacion de cita , cuando sea requerido
        /// </para>
        /// </summary>
        public String Cit_notcan_mcit
        {
            get { return _cit_notcan_mcit; }
            set
            {
                if (_cit_notcan_mcit == value) return;
                _cit_notcan_mcit = value;
                OnPropertyChanged("Cit_notcan_mcit");
            }
        }
        #endregion
        #region Sys_codusu_usux: Usuario facturador asigna
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario facturador asigna</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Código de  usuario facturador asigna la cita al paciente
        /// </para>
        /// </summary>
        public String Sys_codusu_usux
        {
            get { return _sys_codusu_usux; }
            set
            {
                if (_sys_codusu_usux == value) return;
                _sys_codusu_usux = value;
                OnPropertyChanged("Sys_codusu_usux");
            }
        }
        #endregion
        #region Desys_codusc_usux: Nombre Usuario
        private String _desys_codusc_usux;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: desys_codusc_usux (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sys_codusc_usux: Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public String Desys_codusc_usux
        {
            get { return _desys_codusc_usux; }
            set
            {
                if (_desys_codusc_usux == value) return;
                _desys_codusc_usux = value;
                OnPropertyChanged("Desys_codusc_usux");
            }
        }
        #endregion
        #region Sys_codusc_usux: Usuario facturador confirma
        private String _sys_codusc_usux;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario facturador confirma</para>
        /// <para>NOMBRE: sys_codusc_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Código de  usuario facturador que confirma la cita al paciente
        /// </para>
        /// </summary>
        public String Sys_codusc_usux
        {
            get { return _sys_codusc_usux; }
            set
            {
                if (_sys_codusc_usux == value) return;
                _sys_codusc_usux = value;
                OnPropertyChanged("Sys_codusc_usux");
            }
        }
        #endregion
        #region Cit_estcit_easi: Estado de la Cita
        private String _cit_estcit_easi;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citestadoascita</para>
        /// <para>CAMPO: Estado de la Cita</para>
        /// <para>NOMBRE: cit_estcit_easi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Estado de la cita o espacio de tiempo: 1=Libre 2=Asignada 3=Confirmada
        /// o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algún
        /// motivo)
        /// </para>
        /// </summary>
        public String Cit_estcit_easi
        {
            get { return _cit_estcit_easi; }
            set
            {
                if (_cit_estcit_easi == value) return;
                _cit_estcit_easi = value;
                OnPropertyChanged("Cit_estcit_easi");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado turno
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado turno</para>
        /// <para>NOMBRE: sis_estpro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del estado de turno  1= Abierto, 2= Cerrado
        /// Y 3= Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Cit_destur_turn: Descripción turno
        private String _cit_destur_turn;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Descripción turno</para>
        /// <para>NOMBRE: cit_destur_turn (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del turno, requerido para  filtro de búsquedas
        /// ejm: Lunes 10 marzo de 2013 07:00:AM - 12:00:PM
        /// </para>
        /// </summary>
        public String Cit_destur_turn
        {
            get { return _cit_destur_turn; }
            set
            {
                if (_cit_destur_turn == value) return;
                _cit_destur_turn = value;
                OnPropertyChanged("Cit_destur_turn");
            }
        }
        #endregion
        #region Cit_desspr_spro: Nombre servicio
        private String _cit_desspr_spro;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: cit_desspr_spro (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre del servicio a programar
        /// </para>
        /// </summary>
        public String Cit_desspr_spro
        {
            get { return _cit_desspr_spro; }
            set
            {
                if (_cit_desspr_spro == value) return;
                _cit_desspr_spro = value;
                OnPropertyChanged("Cit_desspr_spro");
            }
        }
        #endregion
        #region Sia_descat_ceat: Descripción centro atención
        private String _sia_descat_ceat;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Descripción centro atención</para>
        /// <para>NOMBRE: sia_descat_ceat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public String Sia_descat_ceat
        {
            get { return _sia_descat_ceat; }
            set
            {
                if (_sia_descat_ceat == value) return;
                _sia_descat_ceat = value;
                OnPropertyChanged("Sia_descat_ceat");
            }
        }
        #endregion
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional
        /// </para>
        /// </summary>
        public String Sia_nompro_prof
        {
            get { return _sia_nompro_prof; }
            set
            {
                if (_sia_nompro_prof == value) return;
                _sia_nompro_prof = value;
                OnPropertyChanged("Sia_nompro_prof");
            }
        }
        #endregion
        #region Sia_descon_ctor: Nombre consultorio
        private String _sia_descon_ctor;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Nombre consultorio</para>
        /// <para>NOMBRE: sia_descon_ctor (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripción del consultorio
        /// </para>
        /// </summary>
        public String Sia_descon_ctor
        {
            get { return _sia_descon_ctor; }
            set
            {
                if (_sia_descon_ctor == value) return;
                _sia_descon_ctor = value;
                OnPropertyChanged("Sia_descon_ctor");
            }
        }
        #endregion
        #region Sia_desesp_esme: Nombre especialidad
        private String _sia_desesp_esme;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Nombre especialidad</para>
        /// <para>NOMBRE: sia_desesp_esme (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre de la especialidad medica
        /// </para>
        /// </summary>
        public String Sia_desesp_esme
        {
            get { return _sia_desesp_esme; }
            set
            {
                if (_sia_desesp_esme == value) return;
                _sia_desesp_esme = value;
                OnPropertyChanged("Sia_desesp_esme");
            }
        }
        #endregion
        #region Adm_destat_tatn: Descripción tipo atención
        private String _adm_destat_tatn;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Descripción tipo atención</para>
        /// <para>NOMBRE: adm_destat_tatn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion del tipo de Atencion según RIPS: Ambulatoria, Hospitalizacion
        /// y Urgencias
        /// </para>
        /// </summary>
        public String Adm_destat_tatn
        {
            get { return _adm_destat_tatn; }
            set
            {
                if (_adm_destat_tatn == value) return;
                _adm_destat_tatn = value;
                OnPropertyChanged("Adm_destat_tatn");
            }
        }
        #endregion
        #region Sia_deside_tide: Descripción Tipo Usuario
        private String _sia_deside_tide;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Descripción Tipo Usuario</para>
        /// <para>NOMBRE: sia_deside_tide (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del Tipo de identificación para el usuario
        /// o paciente
        /// </para>
        /// </summary>
        public String Sia_deside_tide
        {
            get { return _sia_deside_tide; }
            set
            {
                if (_sia_deside_tide == value) return;
                _sia_deside_tide = value;
                OnPropertyChanged("Sia_deside_tide");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: sia_nomusu_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Nombre concatenado del paciente (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public String Sia_nomusu_usua
        {
            get { return _sia_nomusu_usua; }
            set
            {
                if (_sia_nomusu_usua == value) return;
                _sia_nomusu_usua = value;
                OnPropertyChanged("Sia_nomusu_usua");
            }
        }
        #endregion
        #region Cto_descon_cont: Descripción contrato
        private String _cto_descon_cont;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: cto_descon_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del contrato
        /// </para>
        /// </summary>
        public String Cto_descon_cont
        {
            get { return _cto_descon_cont; }
            set
            {
                if (_cto_descon_cont == value) return;
                _cto_descon_cont = value;
                OnPropertyChanged("Cto_descon_cont");
            }
        }
        #endregion
        #region Sia_deseps_teps: Nombre EPS
        private String _sia_deseps_teps;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según códigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public String Sia_deseps_teps
        {
            get { return _sia_deseps_teps; }
            set
            {
                if (_sia_deseps_teps == value) return;
                _sia_deseps_teps = value;
                OnPropertyChanged("Sia_deseps_teps");
            }
        }
        #endregion
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: sia_desare_aser (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción área de prestación servicios médicos
        /// </para>
        /// </summary>
        public String Sia_desare_aser
        {
            get { return _sia_desare_aser; }
            set
            {
                if (_sia_desare_aser == value) return;
                _sia_desare_aser = value;
                OnPropertyChanged("Sia_desare_aser");
            }
        }
        #endregion
        #region Fcm_descpr_cpro: Nombre centro producción
        private String _fcm_descpr_cpro;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: fcm_descpr_cpro (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del centro de produccion en prestacion
        /// de servicios medicos
        /// </para>
        /// </summary>
        public String Fcm_descpr_cpro
        {
            get { return _fcm_descpr_cpro; }
            set
            {
                if (_fcm_descpr_cpro == value) return;
                _fcm_descpr_cpro = value;
                OnPropertyChanged("Fcm_descpr_cpro");
            }
        }
        #endregion
        #region Cit_descan_ccan: Descripción cancelación cita
        private String _cit_descan_ccan;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citcausacancita</para>
        /// <para>CAMPO: Descripción cancelación cita</para>
        /// <para>NOMBRE: cit_descan_ccan (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la causa cancelación cita
        /// </para>
        /// </summary>
        public String Cit_descan_ccan
        {
            get { return _cit_descan_ccan; }
            set
            {
                if (_cit_descan_ccan == value) return;
                _cit_descan_ccan = value;
                OnPropertyChanged("Cit_descan_ccan");
            }
        }
        #endregion
        #region Sys_nomusu_usux: Nombre Usuario
        private String _sys_nomusu_usux;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: sys_nomusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public String Sys_nomusu_usux
        {
            get { return _sys_nomusu_usux; }
            set
            {
                if (_sys_nomusu_usux == value) return;
                _sys_nomusu_usux = value;
                OnPropertyChanged("Sys_nomusu_usux");
            }
        }
        #endregion
        #region Cit_descit_easi: Descripción estado cita
        private String _cit_descit_easi;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citestadoascita</para>
        /// <para>CAMPO: Descripción estado cita</para>
        /// <para>NOMBRE: cit_descit_easi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del estado asignación cita
        /// </para>
        /// </summary>
        public String Cit_descit_easi
        {
            get { return _cit_descit_easi; }
            set
            {
                if (_cit_descit_easi == value) return;
                _cit_descit_easi = value;
                OnPropertyChanged("Cit_descit_easi");
            }
        }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
            }
        }
        #endregion
        #region Sia_fecnac_usua: Fecha nacimiento
        private DateTime _sia_fecnac_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha nacimiento</para>
        /// <para>NOMBRE: sia_fecnac_usua (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Fecha nacimiento del usuario o paciente
        /// </para>
        /// </summary>
        public DateTime Sia_fecnac_usua
        {
            get { return _sia_fecnac_usua; }
            set
            {
                if (_sia_fecnac_usua == value) return;
                _sia_fecnac_usua = value;
                OnPropertyChanged("Sia_fecnac_usua");
            }
        }
        #endregion
        #region Sia_edapac_usua: Edad Paciente
        private int _sia_edapac_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad Paciente</para>
        /// <para>NOMBRE: sia_edapac_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Edad Paciente al Momento de Admisión
        /// </para>
        /// </summary>
        public int Sia_edapac_usua
        {
            get { return _sia_edapac_usua; }
            set
            {
                if (_sia_edapac_usua == value) return;
                _sia_edapac_usua = value;
                OnPropertyChanged("Sia_edapac_usua");
            }
        }
        #endregion
        #region Sia_codmed_tmed: Medida Edad
        private String _sia_codmed_tmed;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Medida Edad</para>
        /// <para>NOMBRE: sia_codmed_tmed (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Unidad Medida Edad Paciente 1=Año 2=Mes 3=Día
        /// </para>
        /// </summary>
        public String Sia_codmed_tmed
        {
            get { return _sia_codmed_tmed; }
            set
            {
                if (_sia_codmed_tmed == value) return;
                _sia_codmed_tmed = value;
                OnPropertyChanged("Sia_codmed_tmed");
            }
        }
        #endregion
        #region Sia_edaano_usua: Edad en años
        private int _sia_edaano_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en años</para>
        /// <para>NOMBRE: sia_edaano_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Edad en años
        /// </para>
        /// </summary>
        public int Sia_edaano_usua
        {
            get { return _sia_edaano_usua; }
            set
            {
                if (_sia_edaano_usua == value) return;
                _sia_edaano_usua = value;
                OnPropertyChanged("Sia_edaano_usua");
            }
        }
        #endregion
        #region Sia_edames_usua: Edad en meses
        private int _sia_edames_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en meses</para>
        /// <para>NOMBRE: sia_edames_usua (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Edad en meses
        /// </para>
        /// </summary>
        public int Sia_edames_usua
        {
            get { return _sia_edames_usua; }
            set
            {
                if (_sia_edames_usua == value) return;
                _sia_edames_usua = value;
                OnPropertyChanged("Sia_edames_usua");
            }
        }
        #endregion
        #region Sia_edadia_usua: Edad en días
        private int _sia_edadia_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en días</para>
        /// <para>NOMBRE: sia_edadia_usua (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Edad en días
        /// </para>
        /// </summary>
        public int Sia_edadia_usua
        {
            get { return _sia_edadia_usua; }
            set
            {
                if (_sia_edadia_usua == value) return;
                _sia_edadia_usua = value;
                OnPropertyChanged("Sia_edadia_usua");
            }
        }
        #endregion
        #region Sia_edaymd_usua: Edad formato largo
        private String _sia_edaymd_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad formato largo</para>
        /// <para>NOMBRE: sia_edaymd_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Edad en formato largo ejemplo: (20 años 8 meses 16 días)
        /// </para>
        /// </summary>
        public String Sia_edaymd_usua
        {
            get { return _sia_edaymd_usua; }
            set
            {
                if (_sia_edaymd_usua == value) return;
                _sia_edaymd_usua = value;
                OnPropertyChanged("Sia_edaymd_usua");
            }
        }
        #endregion
        #region Fcm_codman_mans: Código manual tarifario
        private String _fcm_codman_mans;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual tarifario</para>
        /// <para>NOMBRE: fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios configurados para
        /// ventas ejm: M01=Manual SOAT para ventas  a particulares  M02=Manual
        /// SOAT para ventas contributivo (se todam desde el contrato)
        /// </para>
        /// </summary>
        public String Fcm_codman_mans
        {
            get { return _fcm_codman_mans; }
            set
            {
                if (_fcm_codman_mans == value) return;
                _fcm_codman_mans = value;
                OnPropertyChanged("Fcm_codman_mans");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string fcrAddRegistro(ModeloAsignarCitas tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("CIT-ASIGNAR-CITAS", "CIT", "Asignar Citas medicas a pacientes");
            if (!flgBuscarCitmaesasigcita(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFcitmaesasigcita
                    {
                        #region cargar Registro
                        cit_codasi_mcit = tobjModelo.Cit_codasi_mcit,
                        cit_codtur_turn = tobjModelo.Cit_codtur_turn,
                        cit_ordvis_mcit = tobjModelo.Cit_ordvis_mcit,
                        cit_ordcon_mcit = tobjModelo.Cit_ordcon_mcit,
                        cit_codspr_spro = tobjModelo.Cit_codspr_spro,
                        sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        sia_codcon_ctor = tobjModelo.Sia_codcon_ctor,
                        sia_codesp_esme = tobjModelo.Sia_codesp_esme,
                        cit_proqrx_mcit = tobjModelo.Cit_proqrx_mcit,
                        adm_codtat_tatn = tobjModelo.Adm_codtat_tatn,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        cit_fecsol_mcit = tobjModelo.Cit_fecsol_mcit,
                        cit_horsol_mcit = tobjModelo.Cit_horsol_mcit,
                        cit_fecreq_mcit = tobjModelo.Cit_fecreq_mcit,
                        cit_feccit_mcit = tobjModelo.Cit_feccit_mcit,
                        cit_horcon_mcit = tobjModelo.Cit_horcon_mcit,
                        cit_mindur_turn = tobjModelo.Cit_mindur_turn,
                        cit_horini_mcit = tobjModelo.Cit_horini_mcit,
                        cit_horfni_mcit = tobjModelo.Cit_horfni_mcit,
                        cit_horina_mcit = tobjModelo.Cit_horina_mcit,
                        cit_horfna_mcit = tobjModelo.Cit_horfna_mcit,
                        cit_idehin_mcit = tobjModelo.Cit_idehin_mcit,
                        cit_idehfn_mcit = tobjModelo.Cit_idehfn_mcit,
                        cit_tipsol_mcit = tobjModelo.Cit_tipsol_mcit,
                        cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                        cto_nrocon_cont = tobjModelo.Cto_nrocon_cont,
                        sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                        sia_codare_aser = tobjModelo.Sia_codare_aser,
                        fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                        cit_caucan_ccan = tobjModelo.Cit_caucan_ccan,
                        cit_feccan_mcit = tobjModelo.Cit_feccan_mcit,
                        cit_horcan_mcit = tobjModelo.Cit_horcan_mcit,
                        cit_notcan_mcit = tobjModelo.Cit_notcan_mcit,
                        sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                        sys_codusc_usux = tobjModelo.Sys_codusc_usux,
                        cit_estcit_easi = tobjModelo.Cit_estcit_easi,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    // si se esta confirmando generar secuencial
                    if (tobjModelo.Cit_estcit_easi == "3" && lobjRegistro.cit_ordcon_mcit <= 0)
                    {
                        lobjRegistro.cit_ordcon_mcit = fnuNumeroOrdenllegadaCita(tobjModelo.Cit_codtur_turn);
                    }

                    lobjRegistro.cit_codasi_mcit = lcrCodigoGen;
                    _context.AddToCitmaesasigcita(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'CIT-ASIGNAR-CITAS': Asignar Citas medicas a pacientes en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static String fcrActualizar(ModeloAsignarCitas tobjModelo)
        {
            // si se esta confirmando generar secuencial
            if (tobjModelo.Cit_estcit_easi == "3" && tobjModelo.Cit_ordcon_mcit <= 0)
            {
                tobjModelo.Cit_ordcon_mcit = fnuNumeroOrdenllegadaCita(tobjModelo.Cit_codtur_turn);
            }
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaesasigcita.FirstOrDefault(p => p.cit_codasi_mcit == tobjModelo.Cit_codasi_mcit);
                if (lobjRegistro != null)
                {
                    #region Datos
                    lobjRegistro.cit_codasi_mcit = tobjModelo.Cit_codasi_mcit;
                    lobjRegistro.cit_codtur_turn = tobjModelo.Cit_codtur_turn;
                    lobjRegistro.cit_ordvis_mcit = tobjModelo.Cit_ordvis_mcit;
                    lobjRegistro.cit_ordcon_mcit = tobjModelo.Cit_ordcon_mcit;
                    lobjRegistro.cit_codspr_spro = tobjModelo.Cit_codspr_spro;
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.sia_codcon_ctor = tobjModelo.Sia_codcon_ctor;
                    lobjRegistro.sia_codesp_esme = tobjModelo.Sia_codesp_esme;
                    lobjRegistro.cit_proqrx_mcit = tobjModelo.Cit_proqrx_mcit;
                    lobjRegistro.adm_codtat_tatn = tobjModelo.Adm_codtat_tatn;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.cit_fecsol_mcit = tobjModelo.Cit_fecsol_mcit;
                    lobjRegistro.cit_horsol_mcit = tobjModelo.Cit_horsol_mcit;
                    lobjRegistro.cit_fecreq_mcit = tobjModelo.Cit_fecreq_mcit;
                    lobjRegistro.cit_feccit_mcit = tobjModelo.Cit_feccit_mcit;
                    lobjRegistro.cit_horcon_mcit = tobjModelo.Cit_horcon_mcit;
                    lobjRegistro.cit_mindur_turn = tobjModelo.Cit_mindur_turn;
                    lobjRegistro.cit_horini_mcit = tobjModelo.Cit_horini_mcit;
                    lobjRegistro.cit_horfni_mcit = tobjModelo.Cit_horfni_mcit;
                    lobjRegistro.cit_horina_mcit = tobjModelo.Cit_horina_mcit;
                    lobjRegistro.cit_horfna_mcit = tobjModelo.Cit_horfna_mcit;
                    lobjRegistro.cit_idehin_mcit = tobjModelo.Cit_idehin_mcit;
                    lobjRegistro.cit_idehfn_mcit = tobjModelo.Cit_idehfn_mcit;
                    lobjRegistro.cit_tipsol_mcit = tobjModelo.Cit_tipsol_mcit;
                    lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                    lobjRegistro.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                    lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                    lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                    lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                    lobjRegistro.cit_caucan_ccan = tobjModelo.Cit_caucan_ccan;
                    lobjRegistro.cit_feccan_mcit = tobjModelo.Cit_feccan_mcit;
                    lobjRegistro.cit_horcan_mcit = tobjModelo.Cit_horcan_mcit;
                    lobjRegistro.cit_notcan_mcit = tobjModelo.Cit_notcan_mcit;
                    lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                    lobjRegistro.sys_codusc_usux = tobjModelo.Sys_codusc_usux;
                    lobjRegistro.cit_estcit_easi = tobjModelo.Cit_estcit_easi;
                    lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                    #endregion
                    _context.SaveChanges();
                }
            }
            return tobjModelo.Cit_codasi_mcit;
        }
        #endregion
        #region Adicionar Registro
        public static string fcrCancelarRegistro(ModeloAsignarCitas tobjModelo)
        {
            var lcrCodigoGen = tobjModelo.Cit_codasi_mcit;

            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFcitmaesasigcita
                {
                    #region cargar Registro
                    cit_codasi_mcit = tobjModelo.Cit_codasi_mcit,
                    cit_codtur_turn = tobjModelo.Cit_codtur_turn,
                    cit_ordvis_mcit = tobjModelo.Cit_ordvis_mcit,
                    cit_ordcon_mcit = tobjModelo.Cit_ordcon_mcit,
                    cit_codspr_spro = tobjModelo.Cit_codspr_spro,
                    sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                    sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                    sia_codcon_ctor = tobjModelo.Sia_codcon_ctor,
                    sia_codesp_esme = tobjModelo.Sia_codesp_esme,
                    cit_proqrx_mcit = tobjModelo.Cit_proqrx_mcit,
                    adm_codtat_tatn = tobjModelo.Adm_codtat_tatn,
                    sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                    sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                    sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                    adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                    cit_fecsol_mcit = tobjModelo.Cit_fecsol_mcit,
                    cit_horsol_mcit = tobjModelo.Cit_horsol_mcit,
                    cit_fecreq_mcit = tobjModelo.Cit_fecreq_mcit,
                    cit_feccit_mcit = tobjModelo.Cit_feccit_mcit,
                    cit_horcon_mcit = tobjModelo.Cit_horcon_mcit,
                    cit_mindur_turn = tobjModelo.Cit_mindur_turn,
                    cit_horini_mcit = tobjModelo.Cit_horini_mcit,
                    cit_horfni_mcit = tobjModelo.Cit_horfni_mcit,
                    cit_horina_mcit = tobjModelo.Cit_horina_mcit,
                    cit_horfna_mcit = tobjModelo.Cit_horfna_mcit,
                    cit_idehin_mcit = tobjModelo.Cit_idehin_mcit,
                    cit_idehfn_mcit = tobjModelo.Cit_idehfn_mcit,
                    cit_tipsol_mcit = tobjModelo.Cit_tipsol_mcit,
                    cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                    cto_nrocon_cont = tobjModelo.Cto_nrocon_cont,
                    sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                    sia_codare_aser = tobjModelo.Sia_codare_aser,
                    fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                    cit_caucan_ccan = tobjModelo.Cit_caucan_ccan,
                    cit_feccan_mcit = tobjModelo.Cit_feccan_mcit,
                    cit_horcan_mcit = tobjModelo.Cit_horcan_mcit,
                    cit_notcan_mcit = tobjModelo.Cit_notcan_mcit,
                    sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                    sys_codusc_usux = tobjModelo.Sys_codusc_usux,
                    cit_estcit_easi = tobjModelo.Cit_estcit_easi,
                    sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                    #endregion
                };

                _context.AddToCitmaesasigcita(lobjRegistro);
                _context.SaveChanges();
            }
        
            return lcrCodigoGen;
        }
        #endregion
        #region fnuNumeroOrdenllegadaCita: Genera Numero secuencial orden llegada a cita
        /// <summary>
        /// Genera Numero secuencial orden llegada a cita
        /// </summary>
        public static int fnuNumeroOrdenllegadaCita(String tcrCodigoMaestroTurno)
        {
            var lnuOrdenllegada = 0;

            using (_context = new DbAplicacion())
            {
                var lobjRegMturno = _context.Citmaestroturno.FirstOrDefault(p => p.cit_codtur_turn == tcrCodigoMaestroTurno);

                if (lobjRegMturno != null)
                {
                    lobjRegMturno.cit_concon_turn++;
                    lnuOrdenllegada = (int)lobjRegMturno.cit_concon_turn;
                }
                _context.SaveChanges();
            }
            return lnuOrdenllegada;
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaesasigcita.FirstOrDefault(p => p.cit_codasi_mcit == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar CITMAESASIGCITA: Logica
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TITULO: Asignación de citas a Pacientes</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de Citas asignadas a pacientes, con el respectivo profesional
        /// que realiza la atención, y especialidad
        /// </para>
        /// </summary>
        public static bool flgBuscarCitmaesasigcita(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaesasigcita.FirstOrDefault(p => p.cit_codasi_mcit == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloAsignarCitas> flsListaCitmaesasigcita(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                    var lobConsulta = from tmp in _context.Citmaesasigcita
                                      join siausuarioatend in _context.Siausuarioatend on tmp.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      where tmp.cit_codasi_mcit == tcrBuscar
                                      select new ModeloAsignarCitas
                                      {
                                          Cit_codasi_mcit = tmp.cit_codasi_mcit,
                                          Cit_codtur_turn = tmp.cit_codtur_turn,
                                          Cit_ordvis_mcit = (int)tmp.cit_ordvis_mcit,
                                          Cit_ordcon_mcit = (int)tmp.cit_ordcon_mcit,
                                          Cit_codspr_spro = tmp.cit_codspr_spro,
                                          Sia_codcat_ceat = tmp.sia_codcat_ceat,
                                          Sia_codpfa_prof = tmp.sia_codpfa_prof,
                                          Sia_codcon_ctor = tmp.sia_codcon_ctor,
                                          Sia_codesp_esme = tmp.sia_codesp_esme,
                                          Cit_proqrx_mcit = tmp.cit_proqrx_mcit,
                                          Adm_codtat_tatn = tmp.adm_codtat_tatn,
                                          Sia_idesec_usua = tmp.sia_idesec_usua,
                                          Sia_tipide_tide = tmp.sia_tipide_tide,
                                          Sia_nroide_usua = tmp.sia_nroide_usua,
                                          Adm_secadm_rgad = tmp.adm_secadm_rgad,
                                          Cit_fecsol_mcit = (DateTime)tmp.cit_fecsol_mcit,
                                          Cit_horsol_mcit = (Decimal)tmp.cit_horsol_mcit,
                                          Cit_fecreq_mcit = (DateTime)tmp.cit_fecreq_mcit,
                                          Cit_feccit_mcit = (DateTime)tmp.cit_feccit_mcit,
                                          Cit_horcon_mcit = (Decimal)tmp.cit_horcon_mcit,
                                          Cit_mindur_turn = (int)tmp.cit_mindur_turn,
                                          Cit_horini_mcit = (Decimal)tmp.cit_horini_mcit,
                                          Cit_horfni_mcit = (Decimal)tmp.cit_horfni_mcit,
                                          Cit_horina_mcit = (Decimal)tmp.cit_horina_mcit,
                                          Cit_horfna_mcit = (Decimal)tmp.cit_horfna_mcit,
                                          Cit_idehin_mcit = (long)tmp.cit_idehin_mcit,
                                          Cit_idehfn_mcit = (long)tmp.cit_idehfn_mcit,
                                          Cit_tipsol_mcit = tmp.cit_tipsol_mcit,
                                          Cto_seccon_cont = tmp.cto_seccon_cont,
                                          Cto_nrocon_cont = tmp.cto_nrocon_cont,
                                          Sia_codeps_teps = tmp.sia_codeps_teps,
                                          Sia_codare_aser = tmp.sia_codare_aser,
                                          Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro,
                                          Cit_caucan_ccan = tmp.cit_caucan_ccan,
                                          Cit_feccan_mcit = (DateTime)tmp.cit_feccan_mcit,
                                          Cit_horcan_mcit = (Decimal)tmp.cit_horcan_mcit,
                                          Cit_notcan_mcit = tmp.cit_notcan_mcit,
                                          Sys_codusu_usux = tmp.sys_codusu_usux,
                                          Sys_codusc_usux = tmp.sys_codusc_usux,
                                          Cit_estcit_easi = tmp.cit_estcit_easi,
                                          Sis_estpro_espr = tmp.sis_estpro_espr,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_fecnac_usua = usua.sia_fecnac_usua != null ? (DateTime)usua.sia_fecnac_usua : (DateTime)tmp.cit_feccit_mcit,
                                          Sia_edapac_usua = usua.sia_edapac_usua != null ? (int)usua.sia_edapac_usua : 0,
                                          Sia_codmed_tmed = usua.sia_codmed_tmed,
                                          Sia_edaano_usua = usua.sia_edaano_usua != null ? (int)usua.sia_edaano_usua : 0,
                                          Sia_edames_usua = usua.sia_edames_usua != null ? (int)usua.sia_edames_usua : 0,
                                          Sia_edadia_usua = usua.sia_edadia_usua != null ? (int)usua.sia_edadia_usua : 0, 
                                          Sia_edaymd_usua = usua.sia_edaymd_usua,
                                          Desys_codusc_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == tmp.sys_codusu_usux).sys_nomusu_usux,
                                          Cit_destur_turn = _context.Citmaestroturno.FirstOrDefault(rxp => rxp.cit_codtur_turn == tmp.cit_codtur_turn).cit_destur_turn,
                                          Cit_desspr_spro = _context.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == tmp.cit_codspr_spro).cit_desspr_spro,
                                          Sia_descat_ceat = _context.Siacentroaten.FirstOrDefault(rxp => rxp.sia_codcat_ceat == tmp.sia_codcat_ceat).sia_descat_ceat,
                                          Sia_nompro_prof = _context.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == tmp.sia_codpfa_prof).sia_nompro_prof,
                                          Sia_descon_ctor = _context.Siaconsultorios.FirstOrDefault(rxp => rxp.sia_codcon_ctor == tmp.sia_codcon_ctor).sia_descon_ctor,
                                          Sia_desesp_esme = _context.Siaespecialimed.FirstOrDefault(rxp => rxp.sia_codesp_esme == tmp.sia_codesp_esme).sia_desesp_esme,
                                          Adm_destat_tatn = _context.Admtipoatencion.FirstOrDefault(rxp => rxp.adm_codtat_tatn == tmp.adm_codtat_tatn).adm_destat_tatn,
                                          Sia_deside_tide = _context.Siatipideusario.FirstOrDefault(rxp => rxp.sia_tipide_tide == tmp.sia_tipide_tide).sia_deside_tide,
                                          Cto_descon_cont = _context.Ctomaescontrato.FirstOrDefault(rxp => rxp.cto_seccon_cont == tmp.cto_seccon_cont).cto_descon_cont,
                                          Fcm_codman_mans = _context.Ctomaescontrato.FirstOrDefault(rxp => rxp.cto_seccon_cont == tmp.cto_seccon_cont).fcm_codman_mans,
                                          Sia_deseps_teps = _context.Siatablaeps.FirstOrDefault(rxp => rxp.sia_codeps_teps == tmp.sia_codeps_teps).sia_deseps_teps,
                                          Sia_desare_aser = _context.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == tmp.sia_codare_aser).sia_desare_aser,
                                          Fcm_descpr_cpro = _context.Fcmcenproduccio.FirstOrDefault(rxp => rxp.fcm_codcpr_cpro == tmp.fcm_codcpr_cpro).fcm_codcpr_cpro,
                                          Cit_descan_ccan = _context.Citcausacancita.FirstOrDefault(rxp => rxp.cit_caucan_ccan == tmp.cit_caucan_ccan).cit_descan_ccan,
                                          Sys_nomusu_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == tmp.sys_codusu_usux).sys_nomusu_usux,
                                          Cit_descit_easi = _context.Citestadoascita.FirstOrDefault(rxp => rxp.cit_estcit_easi == tmp.cit_estcit_easi).cit_descit_easi,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == tmp.sis_estpro_espr).sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
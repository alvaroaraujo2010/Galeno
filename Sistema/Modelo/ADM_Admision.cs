using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Datos.Modelos;
using Sistema.Utilidades;

namespace Sistema.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admregadmision
    /// </summary>
    public class ADMModeloAdmadmisiones : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _sia_idesec_usua;
        private String _sia_tipide_tide;
        private String _sia_nroide_usua;
        private String _hcl_nrohis_hicl;
        private String _cit_codasi_mcit;
        private DateTime _adm_fecadm_rgad;
        private Decimal _adm_horadm_rgad;
        private String _adm_reingr_rgad;
        private String _adm_codoad_toad;
        private String _sia_codare_aser;
        private String _desia_areing_aser;
        private String _sia_areing_aser;
        private String _adm_codtat_tatn;
        private String _hos_codcam_caho;
        private String _hos_codsec_hsec;
        private String _sia_dixing_tdia;
        private String _adm_caucon_rgad;
        private DateTime _adm_fechos_rgad;
        private Decimal _adm_horhos_rgad;
        private String _cto_seccon_cont;
        private String _cto_nrocon_cont;
        private String _sia_codeps_teps;
        private int _sia_edapac_usua;
        private String _sia_codmed_tmed;
        private int _sia_edaano_usua;
        private int _sia_edames_usua;
        private int _sia_edadia_usua;
        private String _sia_edaymd_usua;
        private String _sia_codpfa_prof;
        private String _adm_nroaut_rgad;
        private String _adm_nropol_rgad;
        private String _sia_tipusu_regi;
        private String _sia_tipafi_tafi;
        private String _sia_nivsbn_nsbn;
        private String _sia_tippob_tpob;
        private String _sia_nivcon_ncon;
        private String _adm_nomaco_rgad;
        private String _adm_diraco_rgad;
        private String _adm_telaco_rgad;
        private String _adm_nrorem_rgad;
        private String _sis_idemun_muni;
        private String _sia_codips_tips;
        private DateTime _adm_fecrem_rgad;
        private int _adm_secite_rgad;
        private String _sia_regate_rgat;
        private String _adm_estfac_rgad;
        private String _adm_estrad_rgad;
        private String _adm_liqest_rgad;
        private String _adm_ctarip_rgad;
        private String _sia_codcat_ceat;
        private String _sys_codusu_usux;
        private int _adm_conest_rgad;
        private DateTime _adm_fecedt_rgad;
        private String _sis_estpro_espr;
        private String _sia_nomusu_usua;
        private String _sia_desare_aser;
        private String _hos_descam_caho;
        private String _sia_desdia_tdia;
        private String _cto_descon_cont;
        private String _sia_deseps_teps;
        private String _sia_nompro_prof;
        private String _sis_nommun_muni;
        private String _sia_desips_tips;
        private String _sia_descat_ceat;
        private String _sys_nomusu_usux;
        private String _sis_despro_espr;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión
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
        #region Sia_idesec_usua: Código único del paciente
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula,otros
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
        #region Sia_nroide_usua: Numero de Identificación
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Hcl_nrohis_hicl: Numero historia clínica
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Numero historia clínica</para>
        /// <para>NOMBRE: hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Numero o código de la Ficha de Historias Clínicas
        /// </para>
        /// </summary>
        public String Hcl_nrohis_hicl
        {
            get { return _hcl_nrohis_hicl; }
            set
            {
                if (_hcl_nrohis_hicl == value) return;
                _hcl_nrohis_hicl = value;
                OnPropertyChanged("Hcl_nrohis_hicl");
            }
        }
        #endregion
        #region Cit_codasi_mcit: Código registro cita
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Código registro cita</para>
        /// <para>NOMBRE: cit_codasi_mcit (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código del registro asignación de cita a paciente, cuando el
        /// origen es desde citas medicas
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
        #region Adm_fecadm_rgad: Fecha Admisión
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha Admisión</para>
        /// <para>NOMBRE: adm_fecadm_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Admisión o del registro de atención ambulatoria
        /// </para>
        /// </summary>
        public DateTime Adm_fecadm_rgad
        {
            get { return _adm_fecadm_rgad; }
            set
            {
                if (_adm_fecadm_rgad == value) return;
                _adm_fecadm_rgad = value;
                OnPropertyChanged("Adm_fecadm_rgad");
            }
        }
        #endregion
        #region Adm_horadm_rgad: Hora de Admisión
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Hora de Admisión</para>
        /// <para>NOMBRE: adm_horadm_rgad (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Hora de Admisión o atención ambulatoria en formato militar
        /// (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Adm_horadm_rgad
        {
            get { return _adm_horadm_rgad; }
            set
            {
                if (_adm_horadm_rgad == value) return;
                _adm_horadm_rgad = value;
                OnPropertyChanged("Adm_horadm_rgad");
            }
        }
        #endregion
        #region Adm_pacemb_rgad: Embarazada SI/NO
        private String _adm_pacemb_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Embarazada SI/NO</para>
        /// <para>NOMBRE: adm_pacemb_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///La paciente esta embarazada : 1=SI 2=NO 3=NO APLICA
        /// </para>
        /// </summary>
        public String Adm_pacemb_rgad
        {
            get { return _adm_pacemb_rgad; }
            set
            {
                if (_adm_pacemb_rgad == value) return;
                _adm_pacemb_rgad = value;
                OnPropertyChanged("Adm_pacemb_rgad");
            }
        }
        #endregion
        #region Adm_reingr_rgad: Reingreso antes de 48h
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Reingreso antes de 48h</para>
        /// <para>NOMBRE: adm_reingr_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Para saber si el registro de atención o admisión es un reingreso
        /// antes de 48 horas de haberse dado de alta previamente al
        /// paciente: SI/NO
        /// </para>
        /// </summary>
        public String Adm_reingr_rgad
        {
            get { return _adm_reingr_rgad; }
            set
            {
                if (_adm_reingr_rgad == value) return;
                _adm_reingr_rgad = value;
                OnPropertyChanged("Adm_reingr_rgad");
            }
        }
        #endregion
        #region Adm_codoad_toad: Código Origen admisión
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admviaingreso</para>
        /// <para>CAMPO: Código Origen admisión</para>
        /// <para>NOMBRE: adm_codoad_toad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código Origen de Admisión o vía de ingreso a la institución
        /// (desde la tabla origen admisión o vía de ingreso a la institución)
        /// </para>
        /// </summary>
        public String Adm_codoad_toad
        {
            get { return _adm_codoad_toad; }
            set
            {
                if (_adm_codoad_toad == value) return;
                _adm_codoad_toad = value;
                OnPropertyChanged("Adm_codoad_toad");
            }
        }
        #endregion
        #region Adm_nroreg_tria: Codigo Triage
        private String _adm_nroreg_tria;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Codigo Triage</para>
        /// <para>NOMBRE: adm_nroreg_tria (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Codigo del registro evaluacion Triage  de Urgencia cuando aplica
        /// </para>
        /// </summary>
        public String Adm_nroreg_tria
        {
            get { return _adm_nroreg_tria; }
            set
            {
                if (_adm_nroreg_tria == value) return;
                _adm_nroreg_tria = value;
                OnPropertyChanged("Adm_nroreg_tria");
            }
        }
        #endregion
        #region Sia_codare_aser: Código Área de servicios
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region Desia_areing_aser: Nombre área de servicios
        /// <summary>
        /// <para>TABLA: siaareapreservi</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: desia_areing_aser (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_areing_aser: Descripción área de prestación
        /// servicios médicos
        /// </para>
        /// </summary>
        public String Desia_areing_aser
        {
            get { return _desia_areing_aser; }
            set
            {
                if (_desia_areing_aser == value) return;
                _desia_areing_aser = value;
                OnPropertyChanged("Desia_areing_aser");
            }
        }
        #endregion
        #region Sia_areing_aser: Código Área de Ingreso
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de Ingreso</para>
        /// <para>NOMBRE: sia_areing_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Código Área de Servicio Donde Ingresa o presta atención inicial,
        /// (este dato no cambia cuando hay traslados de área)
        /// </para>
        /// </summary>
        public String Sia_areing_aser
        {
            get { return _sia_areing_aser; }
            set
            {
                if (_sia_areing_aser == value) return;
                _sia_areing_aser = value;
                OnPropertyChanged("Sia_areing_aser");
            }
        }
        #endregion
        #region Fcm_codcpr_cpro: Centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Codigo del centro de producción generado por el sistema
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
        #region Adm_codtat_tatn: Tipo de Atención
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo de Atención</para>
        /// <para>NOMBRE: adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Código Tipo de Atención o ámbito donde se prestara el servicio
        /// :1=Ambulatoria 2=Hospitalización 3=Urgencia
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
        #region Adm_codcex_tcex: Causa Externa
        private String _adm_codcex_tcex;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public String Adm_codcex_tcex
        {
            get { return _adm_codcex_tcex; }
            set
            {
                if (_adm_codcex_tcex == value) return;
                _adm_codcex_tcex = value;
                OnPropertyChanged("Adm_codcex_tcex");
            }
        }
        #endregion
        #region Hos_codcam_caho: Código Cama
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Código Cama</para>
        /// <para>NOMBRE: hos_codcam_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Código Cama  Hospitalización u Observación de urgencia donde
        /// ingresa
        /// </para>
        /// </summary>
        public String Hos_codcam_caho
        {
            get { return _hos_codcam_caho; }
            set
            {
                if (_hos_codcam_caho == value) return;
                _hos_codcam_caho = value;
                OnPropertyChanged("Hos_codcam_caho");
            }
        }
        #endregion
        #region Hos_codsec_hsec: Código sección
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Código sección</para>
        /// <para>NOMBRE: hos_codsec_hsec (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Código seccionpara las subdivisiones de Hospitalización y Urgencias
        /// con observación donde esta la cama asignada EJM:S001= Hospitalización
        /// Mujeres, S002 =Hospitalización Niños y otras
        /// </para>
        /// </summary>
        public String Hos_codsec_hsec
        {
            get { return _hos_codsec_hsec; }
            set
            {
                if (_hos_codsec_hsec == value) return;
                _hos_codsec_hsec = value;
                OnPropertyChanged("Hos_codsec_hsec");
            }
        }
        #endregion
        #region Sia_dixing_tdia: Diagnostico Ingreso
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico Ingreso</para>
        /// <para>NOMBRE: sia_dixing_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de Ingreso a hospitalización/Urgencias con Observación
        /// (si no se digito en admisión)
        /// </para>
        /// </summary>
        public String Sia_dixing_tdia
        {
            get { return _sia_dixing_tdia; }
            set
            {
                if (_sia_dixing_tdia == value) return;
                _sia_dixing_tdia = value;
                OnPropertyChanged("Sia_dixing_tdia");
            }
        }
        #endregion
        #region Adm_caucon_rgad: Causa de Consulta
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Causa de Consulta</para>
        /// <para>NOMBRE: adm_caucon_rgad (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Causa Textual de Consulta
        /// </para>
        /// </summary>
        public String Adm_caucon_rgad
        {
            get { return _adm_caucon_rgad; }
            set
            {
                if (_adm_caucon_rgad == value) return;
                _adm_caucon_rgad = value;
                OnPropertyChanged("Adm_caucon_rgad");
            }
        }
        #endregion
        #region Adm_fechos_rgad: Fecha Hospitalización
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha Hospitalización</para>
        /// <para>NOMBRE: adm_fechos_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Fecha en que Inicia Hospitalización
        /// </para>
        /// </summary>
        public DateTime Adm_fechos_rgad
        {
            get { return _adm_fechos_rgad; }
            set
            {
                if (_adm_fechos_rgad == value) return;
                _adm_fechos_rgad = value;
                OnPropertyChanged("Adm_fechos_rgad");
            }
        }
        #endregion
        #region Adm_horhos_rgad: Hora Hospitalización
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Hora Hospitalización</para>
        /// <para>NOMBRE: adm_horhos_rgad (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Hora en que Inicia Hospitalización
        /// </para>
        /// </summary>
        public Decimal Adm_horhos_rgad
        {
            get { return _adm_horhos_rgad; }
            set
            {
                if (_adm_horhos_rgad == value) return;
                _adm_horhos_rgad = value;
                OnPropertyChanged("Adm_horhos_rgad");
            }
        }
        #endregion
        #region Cto_seccon_cont: Secuencial de Contrato
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
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
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
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
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
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
        #region Sis_idterc_sitr: Código tercero (contable)
        private String _sis_idterc_sitr;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCIÓN: Código de Empresa cliente y/o tercero EPS o asegurador según módulos administrativos</para>
        /// </summary>
        public String Sis_idterc_sitr
        {
            get { return _sis_idterc_sitr; }
            set
            {
                if (_sis_idterc_sitr == value) return;
                _sis_idterc_sitr = value;
                OnPropertyChanged("Sis_idterc_sitr");
            }
        }
        #endregion
        #region Sia_edapac_usua: Edad Paciente
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sia_codpfa_prof: Código Profesional Autoriza
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código Profesional Autoriza</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Código Profesional Que Autoriza Admisión o presta servicio
        /// ambulatorio
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
        #region Adm_nroaut_rgad: Numero Autorización
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Autorización</para>
        /// <para>NOMBRE: adm_nroaut_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Numero Autorización Admisión solicitada a la EPS o Asegurador
        /// </para>
        /// </summary>
        public String Adm_nroaut_rgad
        {
            get { return _adm_nroaut_rgad; }
            set
            {
                if (_adm_nroaut_rgad == value) return;
                _adm_nroaut_rgad = value;
                OnPropertyChanged("Adm_nroaut_rgad");
            }
        }
        #endregion
        #region Adm_nropol_rgad: Numero Poliza        
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Poliza</para>
        /// <para>NOMBRE: adm_nropol_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Numero de poliza de seguro cuando es un accidente SOAT o algun
        /// seguro especial
        /// </para>
        /// </summary>
        public String Adm_nropol_rgad
        {
            get { return _adm_nropol_rgad; }
            set
            {
                if (_adm_nropol_rgad == value) return;
                _adm_nropol_rgad = value;
                OnPropertyChanged("Adm_nropol_rgad");
            }
        }
        #endregion
        #region Sia_tipusu_regi: Régimen salud usuario
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen salud usuario</para>
        /// <para>NOMBRE: sia_tipusu_regi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Tipo Usuario según régimen 1=Contributivo 2=Subsidiado y otros(Resol:
        /// 3374 RIPS)
        /// </para>
        /// </summary>
        public String Sia_tipusu_regi
        {
            get { return _sia_tipusu_regi; }
            set
            {
                if (_sia_tipusu_regi == value) return;
                _sia_tipusu_regi = value;
                OnPropertyChanged("Sia_tipusu_regi");
            }
        }
        #endregion
        #region Sia_tipafi_tafi: Tipo Afiliado
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Tipo Afiliado</para>
        /// <para>NOMBRE: sia_tipafi_tafi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Tipo Afiliado: C=Cotizante B=Beneficiario A=Adicional
        /// </para>
        /// </summary>
        public String Sia_tipafi_tafi
        {
            get { return _sia_tipafi_tafi; }
            set
            {
                if (_sia_tipafi_tafi == value) return;
                _sia_tipafi_tafi = value;
                OnPropertyChanged("Sia_tipafi_tafi");
            }
        }
        #endregion
        #region Sia_nivsbn_nsbn: Nivel Sisben
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Nivel Sisben</para>
        /// <para>NOMBRE: sia_nivsbn_nsbn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Sisben para cobro de copagos  según Resolución:
        /// 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,4,N
        /// </para>
        /// </summary>
        public String Sia_nivsbn_nsbn
        {
            get { return _sia_nivsbn_nsbn; }
            set
            {
                if (_sia_nivsbn_nsbn == value) return;
                _sia_nivsbn_nsbn = value;
                OnPropertyChanged("Sia_nivsbn_nsbn");
            }
        }
        #endregion
        #region Sia_tippob_tpob: Tipo población especial
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatippoblacion</para>
        /// <para>CAMPO: Tipo población especial</para>
        /// <para>NOMBRE: sia_tippob_tpob (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Código del tipo poblacional especial para subsidiado, según
        /// normas de base de datos Resol: 1344 de 2012  BDUA
        /// </para>
        /// </summary>
        public String Sia_tippob_tpob
        {
            get { return _sia_tippob_tpob; }
            set
            {
                if (_sia_tippob_tpob == value) return;
                _sia_tippob_tpob = value;
                OnPropertyChanged("Sia_tippob_tpob");
            }
        }
        #endregion
        #region Sia_despob_tpob: Descripción población especial
        private String _sia_despob_tpob;
        /// <summary>
        /// <para>TABLA: tewmporal</para>
        /// <para>TABLA NATIVA: siatippoblacion</para>
        /// <para>CAMPO: Descripción población especial</para>
        /// <para>NOMBRE: sia_despob_tpob (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo población especial régimen subsidiado
        /// </para>
        /// </summary>
        public String Sia_despob_tpob
        {
            get { return _sia_despob_tpob; }
            set
            {
                if (_sia_despob_tpob == value) return;
                _sia_despob_tpob = value;
                OnPropertyChanged("Sia_despob_tpob");
            }
        }
        #endregion
        #region Sia_nivcon_ncon: Nivel Contributivo
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Nivel Contributivo</para>
        /// <para>NOMBRE: sia_nivcon_ncon (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Contributivo 1,2,3... para Calcular cuotas Moderadoras
        /// y copagos
        /// </para>
        /// </summary>
        public String Sia_nivcon_ncon
        {
            get { return _sia_nivcon_ncon; }
            set
            {
                if (_sia_nivcon_ncon == value) return;
                _sia_nivcon_ncon = value;
                OnPropertyChanged("Sia_nivcon_ncon");
            }
        }
        #endregion
        #region Adm_nomaco_rgad: Nombre Acompañante
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Nombre Acompañante</para>
        /// <para>NOMBRE: adm_nomaco_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Nombre del Acompañante (Familia Paciente)
        /// </para>
        /// </summary>
        public String Adm_nomaco_rgad
        {
            get { return _adm_nomaco_rgad; }
            set
            {
                if (_adm_nomaco_rgad == value) return;
                _adm_nomaco_rgad = value;
                OnPropertyChanged("Adm_nomaco_rgad");
            }
        }
        #endregion
        #region Adm_diraco_rgad: Dirección Acompañante
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Dirección Acompañante</para>
        /// <para>NOMBRE: adm_diraco_rgad (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Dirección Acompañante
        /// </para>
        /// </summary>
        public String Adm_diraco_rgad
        {
            get { return _adm_diraco_rgad; }
            set
            {
                if (_adm_diraco_rgad == value) return;
                _adm_diraco_rgad = value;
                OnPropertyChanged("Adm_diraco_rgad");
            }
        }
        #endregion
        #region Adm_telaco_rgad: Teléfono acompañante
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Teléfono acompañante</para>
        /// <para>NOMBRE: adm_telaco_rgad (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        ///Teléfono del Acompañante
        /// </para>
        /// </summary>
        public String Adm_telaco_rgad
        {
            get { return _adm_telaco_rgad; }
            set
            {
                if (_adm_telaco_rgad == value) return;
                _adm_telaco_rgad = value;
                OnPropertyChanged("Adm_telaco_rgad");
            }
        }
        #endregion
        #region Adm_nrorem_rgad: Numero Remisión
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Remisión</para>
        /// <para>NOMBRE: adm_nrorem_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        ///Numero de la Remisión
        /// </para>
        /// </summary>
        public String Adm_nrorem_rgad
        {
            get { return _adm_nrorem_rgad; }
            set
            {
                if (_adm_nrorem_rgad == value) return;
                _adm_nrorem_rgad = value;
                OnPropertyChanged("Adm_nrorem_rgad");
            }
        }
        #endregion
        #region Sis_idemun_muni: Municipio Origen
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Municipio Origen</para>
        /// <para>NOMBRE: sis_idemun_muni (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        ///Id Único Municipio origen Remisión
        /// </para>
        /// </summary>
        public String Sis_idemun_muni
        {
            get { return _sis_idemun_muni; }
            set
            {
                if (_sis_idemun_muni == value) return;
                _sis_idemun_muni = value;
                OnPropertyChanged("Sis_idemun_muni");
            }
        }
        #endregion
        #region Sia_codips_tips: IPS Origen
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatablaips</para>
        /// <para>CAMPO: IPS Origen</para>
        /// <para>NOMBRE: sia_codips_tips (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///IPS Origen Remisión
        /// </para>
        /// </summary>
        public String Sia_codips_tips
        {
            get { return _sia_codips_tips; }
            set
            {
                if (_sia_codips_tips == value) return;
                _sia_codips_tips = value;
                OnPropertyChanged("Sia_codips_tips");
            }
        }
        #endregion
        #region Adm_fecrem_rgad: Fecha Remisión
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha Remisión</para>
        /// <para>NOMBRE: adm_fecrem_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        ///Fecha de Remisión
        /// </para>
        /// </summary>
        public DateTime Adm_fecrem_rgad
        {
            get { return _adm_fecrem_rgad; }
            set
            {
                if (_adm_fecrem_rgad == value) return;
                _adm_fecrem_rgad = value;
                OnPropertyChanged("Adm_fecrem_rgad");
            }
        }
        #endregion
        #region Adm_secite_rgad: Secuencial de Ítem
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Secuencial de Ítem</para>
        /// <para>NOMBRE: adm_secite_rgad (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Item en Facturación desde aquí se generan los
        /// Id únicos  para detalles en servicios
        /// </para>
        /// </summary>
        public int Adm_secite_rgad
        {
            get { return _adm_secite_rgad; }
            set
            {
                if (_adm_secite_rgad == value) return;
                _adm_secite_rgad = value;
                OnPropertyChanged("Adm_secite_rgad");
            }
        }
        #endregion
        #region Sia_regate_rgat: Registro de Atención
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de Atención</para>
        /// <para>NOMBRE: sia_regate_rgat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        ///Tipo Registro  de Atención: 1 = Admitidos 2=Ambulatoria
        /// </para>
        /// </summary>
        public String Sia_regate_rgat
        {
            get { return _sia_regate_rgat; }
            set
            {
                if (_sia_regate_rgat == value) return;
                _sia_regate_rgat = value;
                OnPropertyChanged("Sia_regate_rgat");
            }
        }
        #endregion
        #region Adm_estfac_rgad: Estado Facturación
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Estado Facturación</para>
        /// <para>NOMBRE: adm_estfac_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Estado de la Facturación Para este Paciente 1=Abierta 2=Cerrada
        /// </para>
        /// </summary>
        public String Adm_estfac_rgad
        {
            get { return _adm_estfac_rgad; }
            set
            {
                if (_adm_estfac_rgad == value) return;
                _adm_estfac_rgad = value;
                OnPropertyChanged("Adm_estfac_rgad");
            }
        }
        #endregion
        #region Adm_estrad_rgad: Estado datos médicos
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Estado datos médicos</para>
        /// <para>NOMBRE: adm_estrad_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Estado de datos  atención medica para este Paciente 1=Abierta
        /// 2=Cerrada
        /// </para>
        /// </summary>
        public String Adm_estrad_rgad
        {
            get { return _adm_estrad_rgad; }
            set
            {
                if (_adm_estrad_rgad == value) return;
                _adm_estrad_rgad = value;
                OnPropertyChanged("Adm_estrad_rgad");
            }
        }
        #endregion
        #region Adm_liqest_rgad: Liquidado Estancias
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Liquidado Estancias</para>
        /// <para>NOMBRE: adm_liqest_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Liquidado Estancias Para Hospitalización/Urgencias 1=SI 2=No
        /// </para>
        /// </summary>
        public String Adm_liqest_rgad
        {
            get { return _adm_liqest_rgad; }
            set
            {
                if (_adm_liqest_rgad == value) return;
                _adm_liqest_rgad = value;
                OnPropertyChanged("Adm_liqest_rgad");
            }
        }
        #endregion
        #region Adm_ctarip_rgad: Marca Rips Completado
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Marca Rips Completado</para>
        /// <para>NOMBRE: adm_ctarip_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Marca de Rips Completado: 1=No Fue Completado 2=Rips Completado 3=No requiere Completar
        /// </para>
        /// </summary>
        public String Adm_ctarip_rgad
        {
            get { return _adm_ctarip_rgad; }
            set
            {
                if (_adm_ctarip_rgad == value) return;
                _adm_ctarip_rgad = value;
                OnPropertyChanged("Adm_ctarip_rgad");
            }
        }
        #endregion
        #region Adm_finate_rgad: Finalizar atención
        private String _adm_finate_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Finalizar atención</para>
        /// <para>NOMBRE: adm_finate_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Finalizar atencion 1= Atencion medica activa (se muestra en
        /// vista admitidos) 2=Finalizada Atencion (desaparece de vista
        /// admitidos)
        /// </para>
        /// </summary>
        public String Adm_finate_rgad
        {
            get { return _adm_finate_rgad; }
            set
            {
                if (_adm_finate_rgad == value) return;
                _adm_finate_rgad = value;
                OnPropertyChanged("Adm_finate_rgad");
            }
        }
        #endregion
        #region Sia_codfco_fcon: Finalidad Consulta
        private String _sia_codfco_fcon;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Finalidad Consulta</para>
        /// <para>NOMBRE: sia_codfco_fcon (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// SIA_REGATE_RGAT = 2 (registro atencion ambulatoria)  Finalidad
        /// de la consulta:01=Atención del Parto 02=Atencion del Recien
        /// Nacido y demas  según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public String Sia_codfco_fcon
        {
            get { return _sia_codfco_fcon; }
            set
            {
                if (_sia_codfco_fcon == value) return;
                _sia_codfco_fcon = value;
                OnPropertyChanged("Sia_codfco_fcon");
            }
        }
        #endregion
        #region Sia_coddia_tdia: Diagnostico consulta
        private String _sia_coddia_tdia;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico consulta</para>
        /// <para>NOMBRE: sia_coddia_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// SIA_REGATE_RGAT = 2 (solo para registro atencion ambulatoria) Diagnostico
        /// de  según CIE-10
        /// </para>
        /// </summary>
        public String Sia_coddia_tdia
        {
            get { return _sia_coddia_tdia; }
            set
            {
                if (_sia_coddia_tdia == value) return;
                _sia_coddia_tdia = value;
                OnPropertyChanged("Sia_coddia_tdia");
            }
        }
        #endregion
        #region Sia_tipdxp_tdix: Tipo diagnostico principal
        private String _sia_tipdxp_tdix;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: sia_tipdxp_tdix (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// SIA_REGATE_RGAT = 2 (registro atencion ambulatoria) Tipo de
        /// diagnostico principal
        /// </para>
        /// </summary>
        public String Sia_tipdxp_tdix
        {
            get { return _sia_tipdxp_tdix; }
            set
            {
                if (_sia_tipdxp_tdix == value) return;
                _sia_tipdxp_tdix = value;
                OnPropertyChanged("Sia_tipdxp_tdix");
            }
        }
        #endregion
        #region Adm_dessal_regr: Destino al salir
        private String _adm_dessal_regr;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: adm_dessal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// SIA_REGATE_RGAT = 2 (registro atencion ambulatoria)  Destino
        /// al salir: 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion
        /// </para>
        /// </summary>
        public String Adm_dessal_regr
        {
            get { return _adm_dessal_regr; }
            set
            {
                if (_adm_dessal_regr == value) return;
                _adm_dessal_regr = value;
                OnPropertyChanged("Adm_dessal_regr");
            }
        }
        #endregion
        #region Sia_dixre1_tdia: Diagnostico relacionado1
        private String _sia_dixre1_tdia;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado1</para>
        /// <para>NOMBRE: sia_dixre1_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 1 según CIE-10
        /// </para>
        /// </summary>
        public String Sia_dixre1_tdia
        {
            get { return _sia_dixre1_tdia; }
            set
            {
                if (_sia_dixre1_tdia == value) return;
                _sia_dixre1_tdia = value;
                OnPropertyChanged("Sia_dixre1_tdia");
            }
        }
        #endregion
        #region Sia_dixre2_tdia: Diagnostico relacionado2
        private String _sia_dixre2_tdia;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado2</para>
        /// <para>NOMBRE: sia_dixre2_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 2 según CIE-10
        /// </para>
        /// </summary>
        public String Sia_dixre2_tdia
        {
            get { return _sia_dixre2_tdia; }
            set
            {
                if (_sia_dixre2_tdia == value) return;
                _sia_dixre2_tdia = value;
                OnPropertyChanged("Sia_dixre2_tdia");
            }
        }
        #endregion
        #region Sia_dixre3_tdia: Diagnostico relacionado3
        private String _sia_dixre3_tdia;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado3</para>
        /// <para>NOMBRE: sia_dixre3_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 2 según CIE-10
        /// </para>
        /// </summary>
        public String Sia_dixre3_tdia
        {
            get { return _sia_dixre3_tdia; }
            set
            {
                if (_sia_dixre3_tdia == value) return;
                _sia_dixre3_tdia = value;
                OnPropertyChanged("Sia_dixre3_tdia");
            }
        }
        #endregion
        #region Sia_codcat_ceat: Código centro atención
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
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
        #region Sys_codusu_usux: Código Digitador
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Código del Digitador Usuario del sistema que diligencia el
        /// registro de atención o admisión
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
        #region Adm_conest_rgad: Contador traslados
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Contador traslados</para>
        /// <para>NOMBRE: adm_conest_rgad (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los registros únicos de estancias y traslados
        /// de camas del paciente
        /// </para>
        /// </summary>
        public int Adm_conest_rgad
        {
            get { return _adm_conest_rgad; }
            set
            {
                if (_adm_conest_rgad == value) return;
                _adm_conest_rgad = value;
                OnPropertyChanged("Adm_conest_rgad");
            }
        }
        #endregion
        #region Adm_fecedt_rgad: Fecha ultima edición
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha ultima edición</para>
        /// <para>NOMBRE: adm_fecedt_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        ///Fecha ultima edición
        /// </para>
        /// </summary>
        public DateTime Adm_fecedt_rgad
        {
            get { return _adm_fecedt_rgad; }
            set
            {
                if (_adm_fecedt_rgad == value) return;
                _adm_fecedt_rgad = value;
                OnPropertyChanged("Adm_fecedt_rgad");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Admisión
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Admisión</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Estado de la Admisión o atención ambulatoria  1=Abierta 2=Cerrada
        /// 3=Anulada
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
        // Datos adicionales
        #region Sia_nomusu_usua: Nombre paciente
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sia_desare_aser: Nombre área de servicios
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <para>TABLA: admregadmision</para>
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
        #region Hos_descam_caho: Descripcion cama
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Descripcion cama</para>
        /// <para>NOMBRE: hos_descam_caho (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion cama según area funcional
        /// </para>
        /// </summary>
        public String Hos_descam_caho
        {
            get { return _hos_descam_caho; }
            set
            {
                if (_hos_descam_caho == value) return;
                _hos_descam_caho = value;
                OnPropertyChanged("Hos_descam_caho");
            }
        }
        #endregion
        #region Cto_descon_cont: Descripción contrato
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sia_nompro_prof: Nombre del Profesional
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sis_nommun_muni: Nombre del Muncipio
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Nombre del Muncipio</para>
        /// <para>NOMBRE: sis_nommun_muni (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre del Muncipio
        /// </para>
        /// </summary>
        public String Sis_nommun_muni
        {
            get { return _sis_nommun_muni; }
            set
            {
                if (_sis_nommun_muni == value) return;
                _sis_nommun_muni = value;
                OnPropertyChanged("Sis_nommun_muni");
            }
        }
        #endregion
        #region Sia_desips_tips: Nombre IPS
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatablaips</para>
        /// <para>CAMPO: Nombre IPS</para>
        /// <para>NOMBRE: sia_desips_tips (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre de la Ips
        /// </para>
        /// </summary>
        public String Sia_desips_tips
        {
            get { return _sia_desips_tips; }
            set
            {
                if (_sia_desips_tips == value) return;
                _sia_desips_tips = value;
                OnPropertyChanged("Sia_desips_tips");
            }
        }
        #endregion
        #region Sia_desfco_fcon: Descripción finalidad consulta
        private String _sia_desfco_fcon;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: sia_desfco_fcon (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la finalidad
        /// </para>
        /// </summary>
        public String Sia_desfco_fcon
        {
            get { return _sia_desfco_fcon; }
            set
            {
                if (_sia_desfco_fcon == value) return;
                _sia_desfco_fcon = value;
                OnPropertyChanged("Sia_desfco_fcon");
            }
        }
        #endregion
        #region Sia_destip_regi: Descripción Regimen salud
        private String _sia_destip_regi;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: Siaregimensalud</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: sia_desfco_fcon (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Regimen salud
        /// </para>
        /// </summary>
        public String Sia_destip_regi
        {
            get { return _sia_destip_regi; }
            set
            {
                if (_sia_destip_regi == value) return;
                _sia_destip_regi = value;
                OnPropertyChanged("Sia_destip_regi");
            }
        }
        #endregion
        #region Sia_desdia_tdia: Descripcion diagnostico
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: sia_desdia_tdia (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Sia_desdia_tdia
        {
            get { return _sia_desdia_tdia; }
            set
            {
                if (_sia_desdia_tdia == value) return;
                _sia_desdia_tdia = value;
                OnPropertyChanged("Sia_desdia_tdia");
            }
        }
        #endregion
        #region Sia_desdxp_tdix: Tipo diagnostico principal
        private String _sia_desdxp_tdix;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: sia_desdxp_tdix (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion tipo diagnostico
        /// </para>
        /// </summary>
        public String Sia_desdxp_tdix
        {
            get { return _sia_desdxp_tdix; }
            set
            {
                if (_sia_desdxp_tdix == value) return;
                _sia_desdxp_tdix = value;
                OnPropertyChanged("Sia_desdxp_tdix");
            }
        }
        #endregion
        #region Sia_descat_ceat: Descripción centro atención
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sys_nomusu_usux: Nombre Usuario
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <para>TABLA: admregadmision</para>
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
        #region Sis_codsex_sexo: Sexo
        private String _sis_codsex_sexo;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION: Sexo del usuario o paciente </para>
        /// </summary>
        public String Sis_codsex_sexo
        {
            get { return _sis_codsex_sexo; }
            set
            {
                if (_sis_codsex_sexo == value) return;
                _sis_codsex_sexo = value;
                OnPropertyChanged("Sis_codsex_sexo");
            }
        }
        #endregion
        #region Sis_dessex_sexo: Descripcion Sexo
        private String _sis_dessex_sexo;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: sis_dessex_sexo (char:25)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion(Masculino,Femenino)
        /// </para>
        /// </summary>
        public String Sis_dessex_sexo
        {
            get { return _sis_dessex_sexo; }
            set
            {
                if (_sis_dessex_sexo == value) return;
                _sis_dessex_sexo = value;
                OnPropertyChanged("Sis_dessex_sexo");
            }
        }
        #endregion
        #region Adm_descex_tcex: Decripcion causa externa
        private String _adm_descex_tcex;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Decripcion causa externa</para>
        /// <para>NOMBRE: adm_descex_tcex (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual causa externa que origina la admision o
        /// atencion medica
        /// </para>
        /// </summary>
        public String Adm_descex_tcex
        {
            get { return _adm_descex_tcex; }
            set
            {
                if (_adm_descex_tcex == value) return;
                _adm_descex_tcex = value;
                OnPropertyChanged("Adm_descex_tcex");
            }
        }
        #endregion
        #region Adm_destat_tatn: Descripción tipo atención
        private String _adm_destat_tatn;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sia_tipdis_tdis: Tipo discapacidad
        private String _sia_tipdis_tdis;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siatipdiscapaci</para>
        /// <para>CAMPO: Tipo discapacidad</para>
        /// <para>NOMBRE: sia_tipdis_tdis (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Visual,
        /// 2=Motriz y mas
        /// </para>
        /// </summary>
        public String Sia_tipdis_tdis
        {
            get { return _sia_tipdis_tdis; }
            set
            {
                if (_sia_tipdis_tdis == value) return;
                _sia_tipdis_tdis = value;
                OnPropertyChanged("Sia_tipdis_tdis");
            }
        }
        #endregion
        #region Sia_desdis_tdis: Descripción discapacidad
        private String _sia_desdis_tdis;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siatipdiscapaci</para>
        /// <para>CAMPO: Descripción discapacidad</para>
        /// <para>NOMBRE: sia_desdis_tdis (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo discapacidad
        /// </para>
        /// </summary>
        public String Sia_desdis_tdis
        {
            get { return _sia_desdis_tdis; }
            set
            {
                if (_sia_desdis_tdis == value) return;
                _sia_desdis_tdis = value;
                OnPropertyChanged("Sia_desdis_tdis");
            }
        }
        #endregion
        #region Sis_codmun_muni: Código Municipio
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Código Municipio</para>
        /// <para>NOMBRE: sis_codmun_muni (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Código Municipio según DANE
        /// </para>
        /// </summary>
        public String Sis_codmun_muni = String.Empty;
        #endregion
        #region Sis_coddep_dpto: Código Departamento
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Código Departamento</para>
        /// <para>NOMBRE: sis_coddep_dpto (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION: Código  del departamento DANE</para>
        /// </summary>
        public String Sis_coddep_dpto = String.Empty;
        #endregion
        #region Sis_zonres_tzon: Zona de residencia
        private String _sis_zonres_tzon;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siszonaresidenc</para>
        /// <para>CAMPO: Zona de residencia</para>
        /// <para>NOMBRE: sis_zonres_tzon (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Zona de residencia según norma U=Urbana R= Rural
        /// </para>
        /// </summary>
        public String Sis_zonres_tzon
        {
            get { return _sis_zonres_tzon; }
            set
            {
                if (_sis_zonres_tzon == value) return;
                _sis_zonres_tzon = value;
                OnPropertyChanged("Sis_zonres_tzon");
            }
        }
        #endregion
        #region Sis_deszon_tzon: Descripcion zona de residencia
        private String _sis_deszon_tzon;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siszonaresidenc</para>
        /// <para>CAMPO: descripcion zona de residencia</para>
        /// <para>NOMBRE: sis_deszon_tzon (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Descripcion zona de residencia según norma U=Urbana R= Rural
        /// </para>
        /// </summary>
        public String Sis_deszon_tzon
        {
            get { return _sis_deszon_tzon; }
            set
            {
                if (_sis_deszon_tzon == value) return;
                _sis_deszon_tzon = value;
                OnPropertyChanged("Sis_deszon_tzon");
            }
        }
        #endregion
        #region Sis_desdep_dpto: Nombre del departamento
        private String _sis_desdep_dpto;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Nombre del departamento</para>
        /// <para>NOMBRE: sis_desdep_dpto (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre del departamento
        /// </para>
        /// </summary>
        public String Sis_desdep_dpto
        {
            get { return _sis_desdep_dpto; }
            set
            {
                if (_sis_desdep_dpto == value) return;
                _sis_desdep_dpto = value;
                OnPropertyChanged("Sis_desdep_dpto");
            }
        }
        #endregion
        #region Sia_telres_usua: Telefono
        private String _sia_telres_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Telefono</para>
        /// <para>NOMBRE: sia_telres_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Teléfono del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_telres_usua
        {
            get { return _sia_telres_usua; }
            set
            {
                if (_sia_telres_usua == value) return;
                _sia_telres_usua = value;
                OnPropertyChanged("Sia_telres_usua");
            }
        }
        #endregion
        #region Sia_dirres_usua: Dirección residencia
        private String _sia_dirres_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Dirección residencia</para>
        /// <para>NOMBRE: sia_dirres_usua (char:70)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Dirección de residencia del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_dirres_usua
        {
            get { return _sia_dirres_usua; }
            set
            {
                if (_sia_dirres_usua == value) return;
                _sia_dirres_usua = value;
                OnPropertyChanged("Sia_dirres_usua");
            }
        }
        #endregion
        #region Sia_correo_usua: Correo electronico
        private String _sia_correo_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Correo electronico</para>
        /// <para>NOMBRE: sia_correo_usua (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Correo electrónico del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_correo_usua
        {
            get { return _sia_correo_usua; }
            set
            {
                if (_sia_correo_usua == value) return;
                _sia_correo_usua = value;
                OnPropertyChanged("Sia_correo_usua");
            }
        }
        #endregion
        #region Sis_codocu_ocup: Codigo ocupación
        private String _sis_codocu_ocup;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sisocupaciones</para>
        /// <para>CAMPO: Codigo ocupación</para>
        /// <para>NOMBRE: sis_codocu_ocup (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Código ocupación o profesion usuario atendido
        /// </para>
        /// </summary>
        public String Sis_codocu_ocup
        {
            get { return _sis_codocu_ocup; }
            set
            {
                if (_sis_codocu_ocup == value) return;
                _sis_codocu_ocup = value;
                OnPropertyChanged("Sis_codocu_ocup");
            }
        }
        #endregion
        #region Sis_desocu_ocup: Descripción ocupacion
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sisocupaciones</para>
        /// <para>CAMPO: Descripción ocupacion</para>
        /// <para>NOMBRE: sis_desocu_ocup (char:180)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción ocupacion
        /// </para>
        /// </summary>
        public String Sis_desocu_ocup = String.Empty;
        #endregion
        #region Sia_priape_usua: Primer Apellido
        private String _sia_priape_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Primer Apellido</para>
        /// <para>NOMBRE: sia_priape_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_priape_usua
        {
            get { return _sia_priape_usua; }
            set
            {
                if (_sia_priape_usua == value) return;
                _sia_priape_usua = value;
                OnPropertyChanged("Sia_priape_usua");
            }
        }
        #endregion
        #region Sia_segape_usua: Segundo Apellido
        private String _sia_segape_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Segundo Apellido</para>
        /// <para>NOMBRE: sia_segape_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Segundo apellido del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_segape_usua
        {
            get { return _sia_segape_usua; }
            set
            {
                if (_sia_segape_usua == value) return;
                _sia_segape_usua = value;
                OnPropertyChanged("Sia_segape_usua");
            }
        }
        #endregion
        #region Sia_prinom_usua: Primer Nombre
        private String _sia_prinom_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Primer Nombre</para>
        /// <para>NOMBRE: sia_prinom_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_prinom_usua
        {
            get { return _sia_prinom_usua; }
            set
            {
                if (_sia_prinom_usua == value) return;
                _sia_prinom_usua = value;
                OnPropertyChanged("Sia_prinom_usua");
            }
        }
        #endregion
        #region Sia_segnom_usua: Segundo Nombre
        private String _sia_segnom_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Segundo Nombre</para>
        /// <para>NOMBRE: sia_segnom_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Segundo nombre del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_segnom_usua
        {
            get { return _sia_segnom_usua; }
            set
            {
                if (_sia_segnom_usua == value) return;
                _sia_segnom_usua = value;
                OnPropertyChanged("Sia_segnom_usua");
            }
        }
        #endregion
        #region Sia_codper_pret: Pertenencia Etnica
        private String _sia_codper_pret;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código pertenencia etnica</para>
        /// <para>NOMBRE: sia_codper_pret (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// pertenencia entinca: 1=indigena, 2=ROM, 3=Gitano, y otros.
        /// </para>
        /// </summary>
        public String Sia_codper_pret
        {
            get { return _sia_codper_pret; }
            set
            {
                if (_sia_codper_pret == value) return;
                _sia_codper_pret = value;
                OnPropertyChanged("Sia_codper_pret");
            }
        }
        #endregion
        #region Desia_dixre1_tdia: Descripcion diagnostico
        private String _desia_dixre1_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixre1_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixre1_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_dixre1_tdia
        {
            get { return _desia_dixre1_tdia; }
            set
            {
                if (_desia_dixre1_tdia == value) return;
                _desia_dixre1_tdia = value;
                OnPropertyChanged("Desia_dixre1_tdia");
            }
        }
        #endregion
        #region Desia_dixre2_tdia: Descripcion diagnostico
        private String _desia_dixre2_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixre2_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixre2_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_dixre2_tdia
        {
            get { return _desia_dixre2_tdia; }
            set
            {
                if (_desia_dixre2_tdia == value) return;
                _desia_dixre2_tdia = value;
                OnPropertyChanged("Desia_dixre2_tdia");
            }
        }
        #endregion
        #region Desia_dixre3_tdia: Descripcion diagnostico
        private String _desia_dixre3_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixre3_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixre3_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_dixre3_tdia
        {
            get { return _desia_dixre3_tdia; }
            set
            {
                if (_desia_dixre3_tdia == value) return;
                _desia_dixre3_tdia = value;
                OnPropertyChanged("Desia_dixre3_tdia");
            }
        }
        #endregion
        #region Sia_desate_rgat: Descripcion registro de atención
        private String _sia_desate_rgat;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de Atención</para>
        /// <para>NOMBRE: sia_regate_rgat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION: Nombre tipo registro de atención: 1 = Admitidos 2=Ambulatoria
        /// </para>
        /// </summary>
        public String Sia_desate_rgat
        {
            get { return _sia_desate_rgat; }
            set
            {
                if (_sia_desate_rgat == value) return;
                _sia_desate_rgat = value;
                OnPropertyChanged("Sia_desate_rgat");
            }
        }
        #endregion
        #region Fcm_codman_mans: Código manual servicios segun contrato
        private String _fcm_codman_mans;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual servicios</para>
        /// <para>NOMBRE: fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios (SOAT ISS o CUPS)
        /// ejm: 01=SOAT mas el 10 para la empresa XX
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
        #region Sia_desper_pret: Descripción Pertenencia etnica
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siapertenetnica</para>
        /// <para>CAMPO: Descripción Pertenencia etnica</para>
        /// <para>NOMBRE: sia_desper_pret (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción pertenencia etnica
        /// </para>
        /// </summary>
        public String Sia_desper_pret = String.Empty;
        #endregion
        #region Sia_desedu_sine: Descripcion Nivel educativo
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sianiveleducati</para>
        /// <para>CAMPO: Descripcion Nivel</para>
        /// <para>NOMBRE: sia_desedu_sine (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Descripción nivel educativo del usuario paciente</para>
        /// </summary>
        public String Sia_desedu_sine = String.Empty;
        #endregion
        #region Sis_numide_sitr: Numero dcumento
        private String _sis_numide_sitr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Numero dcumento</para>
        /// <para>NOMBRE: sis_numide_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Numero NIT o documeto de identificacion del tercero</para>
        /// </summary>
        public String Sis_numide_sitr
        {
            get { return _sis_numide_sitr; }
            set
            {
                if (_sis_numide_sitr == value) return;
                _sis_numide_sitr = value;
                OnPropertyChanged("Sis_numide_sitr");
            }
        }
        #endregion
        #region Sis_razsoc_sitr: Nombre / Razon social
        private String _sis_razsoc_sitr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: sis_razsoc_sitr (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCIÓN: Razon social del tercero/adquirente o nombre concatenado cuando es persona natural</para>
        /// </summary>
        public String Sis_razsoc_sitr
        {
            get { return _sis_razsoc_sitr; }
            set
            {
                if (_sis_razsoc_sitr == value) return;
                _sis_razsoc_sitr = value;
                OnPropertyChanged("Sis_razsoc_sitr");
            }
        }
        #endregion

        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region fobGenAdmisionDatosBasicos: Genera datos basicos admision dado id unico del paciente 
        /// <summary>
        ///  <para>General los nuevos datos minimo de admision del paciente cuando se pretende generar una nueva admision</para>
        ///  <para>La fucnion realiza la busqueda de los datos basicos del paciente</para>
        /// </summary>
        public static void fobGenAdmisionDatosBasicos(String tcrIdUnicoUsuario)
        {
            using (_context = new DbAplicacion())
            {
                /*
                var lobReg = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision);
                if (lobReg != null)
                {
                    
                    lobReg.adm_estfac_rgad = !String.IsNullOrWhiteSpace(tcrEstFact) ? tcrEstFact : lobReg.adm_estfac_rgad;
                    lobReg.adm_estrad_rgad = !String.IsNullOrWhiteSpace(tcrEstMedicos) ? tcrEstMedicos : lobReg.adm_estrad_rgad;
                    lobReg.adm_liqest_rgad = !String.IsNullOrWhiteSpace(tcrLiqEstancia) ? tcrLiqEstancia : lobReg.adm_liqest_rgad;
                    lobReg.adm_ctarip_rgad = !String.IsNullOrWhiteSpace(tcrEstRips) ? tcrEstRips : lobReg.adm_ctarip_rgad;
                    lobReg.adm_conest_rgad = tnuContador > 0 ? tnuContador : lobReg.adm_conest_rgad;
                    lobReg.sis_estpro_espr = !String.IsNullOrWhiteSpace(tcrEstAdm) ? tcrEstAdm : lobReg.sis_estpro_espr;
                    _context.SaveChanges();
                    
                }
                */
            }

        }
        #endregion
        #region Adicionar Registro
        public static string flgAddRegistro(ADMModeloAdmadmisiones tobjModelo)
        {
            var lcrCodigoGen = String.Empty;
            try
            {
                lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("ADM-SECADM-PACIENTES", "ADM", "Secuencial Unico para admisión de pacientes");
                if (!flgBuscarAdmregadmision(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFadmregadmision
                        {
                            #region cargar Registro
                            adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                            sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                            sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                            sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                            hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl,
                            cit_codasi_mcit = tobjModelo.Cit_codasi_mcit,
                            adm_fecadm_rgad = tobjModelo.Adm_fecadm_rgad,
                            adm_horadm_rgad = tobjModelo.Adm_horadm_rgad,
                            adm_pacemb_rgad = tobjModelo.Adm_pacemb_rgad,
                            adm_reingr_rgad = tobjModelo.Adm_reingr_rgad,
                            adm_codoad_toad = tobjModelo.Adm_codoad_toad,
                            adm_nroreg_tria = tobjModelo.Adm_nroreg_tria,
                            sia_codare_aser = tobjModelo.Sia_codare_aser,
                            sia_areing_aser = tobjModelo.Sia_areing_aser,
                            fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                            adm_codtat_tatn = tobjModelo.Adm_codtat_tatn,
                            adm_codcex_tcex = tobjModelo.Adm_codcex_tcex,
                            hos_codcam_caho = tobjModelo.Hos_codcam_caho,
                            hos_codsec_hsec = tobjModelo.Hos_codsec_hsec,
                            sia_dixing_tdia = tobjModelo.Sia_dixing_tdia,
                            adm_caucon_rgad = tobjModelo.Adm_caucon_rgad,
                            adm_fechos_rgad = tobjModelo.Adm_fechos_rgad,
                            adm_horhos_rgad = tobjModelo.Adm_horhos_rgad,
                            cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                            cto_nrocon_cont = tobjModelo.Cto_nrocon_cont,
                            sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                            sis_idterc_sitr = tobjModelo.Sis_idterc_sitr,
                            sia_edapac_usua = tobjModelo.Sia_edapac_usua,
                            sia_codmed_tmed = tobjModelo.Sia_codmed_tmed,
                            sia_edaano_usua = tobjModelo.Sia_edaano_usua,
                            sia_edames_usua = tobjModelo.Sia_edames_usua,
                            sia_edadia_usua = tobjModelo.Sia_edadia_usua,
                            sia_edaymd_usua = tobjModelo.Sia_edaymd_usua,
                            sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                            adm_nroaut_rgad = tobjModelo.Adm_nroaut_rgad,
                            adm_nropol_rgad = tobjModelo.Adm_nropol_rgad,
                            sia_tipusu_regi = tobjModelo.Sia_tipusu_regi,
                            sia_tipafi_tafi = tobjModelo.Sia_tipafi_tafi,
                            sia_nivsbn_nsbn = tobjModelo.Sia_nivsbn_nsbn,
                            sia_tippob_tpob = tobjModelo.Sia_tippob_tpob,
                            sia_nivcon_ncon = tobjModelo.Sia_nivcon_ncon,
                            adm_nomaco_rgad = tobjModelo.Adm_nomaco_rgad,
                            adm_diraco_rgad = tobjModelo.Adm_diraco_rgad,
                            adm_telaco_rgad = tobjModelo.Adm_telaco_rgad,
                            adm_nrorem_rgad = tobjModelo.Adm_nrorem_rgad,
                            sis_idemun_muni = tobjModelo.Sis_idemun_muni,
                            sia_codips_tips = tobjModelo.Sia_codips_tips,
                            adm_fecrem_rgad = tobjModelo.Adm_fecrem_rgad,
                            adm_secite_rgad = tobjModelo.Adm_secite_rgad,
                            sia_regate_rgat = tobjModelo.Sia_regate_rgat,
                            adm_estfac_rgad = tobjModelo.Adm_estfac_rgad,
                            adm_estrad_rgad = tobjModelo.Adm_estrad_rgad,
                            adm_liqest_rgad = tobjModelo.Adm_liqest_rgad,
                            adm_ctarip_rgad = tobjModelo.Adm_ctarip_rgad,
                            adm_finate_rgad = tobjModelo.Adm_finate_rgad,
                            sia_codfco_fcon = tobjModelo.Sia_codfco_fcon,
                            sia_coddia_tdia = tobjModelo.Sia_coddia_tdia,
                            sia_tipdxp_tdix = tobjModelo.Sia_tipdxp_tdix,
                            adm_dessal_regr = tobjModelo.Adm_dessal_regr,
                            sia_dixre1_tdia = tobjModelo.Sia_dixre1_tdia,
                            sia_dixre2_tdia = tobjModelo.Sia_dixre2_tdia,
                            sia_dixre3_tdia = tobjModelo.Sia_dixre3_tdia,
                            sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                            sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                            adm_conest_rgad = tobjModelo.Adm_conest_rgad,
                            adm_fecedt_rgad = tobjModelo.Adm_fecedt_rgad,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.adm_fllave_rgad = Funciones.fnuLlaveIdFecha(tobjModelo.Adm_fecadm_rgad);
                        lobjRegistro.adm_secadm_rgad = lcrCodigoGen;
                        tobjModelo.Adm_secadm_rgad = lcrCodigoGen;

                        if (lobjRegistro.adm_caucon_rgad != null)
                        {
                            if (lobjRegistro.adm_caucon_rgad.Length > 148)
                            {
                                lobjRegistro.adm_caucon_rgad = lobjRegistro.adm_caucon_rgad.Substring(0, 148);
                            }
                        }

                        _context.AddToAdmregadmision(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = string.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                    "'ADM-SECADM-PACIENTES': Secuencial Unico para admisión de pacientes en Maestro Secuenciales.");
                }

                // Generar Variables publicas
                if (!String.IsNullOrWhiteSpace(lcrCodigoGen))
                {
                    ModeloHclvariabactual.fcvGenAdmisionVariablesPublicas(lcrCodigoGen);
                }

            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: flgAddRegistro");
            }

            return lcrCodigoGen;

        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ADMModeloAdmadmisiones tobjModelo)
        {
            try
            {

                var lcrCodigoAdmision = String.Empty;

                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tobjModelo.Adm_secadm_rgad);
                    if (lobjRegistro != null)
                    {
                        lcrCodigoAdmision = tobjModelo.Adm_secadm_rgad;
                        #region Modificar Registro
                        lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                        lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                        lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                        lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                        lobjRegistro.hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl;
                        lobjRegistro.cit_codasi_mcit = tobjModelo.Cit_codasi_mcit;
                        lobjRegistro.adm_fecadm_rgad = (DateTime)tobjModelo.Adm_fecadm_rgad;
                        lobjRegistro.adm_horadm_rgad = (Decimal)tobjModelo.Adm_horadm_rgad;
                        lobjRegistro.adm_pacemb_rgad = tobjModelo.Adm_pacemb_rgad;
                        lobjRegistro.adm_reingr_rgad = tobjModelo.Adm_reingr_rgad;
                        lobjRegistro.adm_codoad_toad = tobjModelo.Adm_codoad_toad;
                        lobjRegistro.adm_nroreg_tria = tobjModelo.Adm_nroreg_tria;
                        lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                        lobjRegistro.sia_areing_aser = tobjModelo.Sia_areing_aser;
                        lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                        lobjRegistro.adm_codtat_tatn = tobjModelo.Adm_codtat_tatn;
                        lobjRegistro.adm_codcex_tcex = tobjModelo.Adm_codcex_tcex;
                        lobjRegistro.hos_codcam_caho = tobjModelo.Hos_codcam_caho;
                        lobjRegistro.hos_codsec_hsec = tobjModelo.Hos_codsec_hsec;
                        lobjRegistro.sia_dixing_tdia = tobjModelo.Sia_dixing_tdia;
                        lobjRegistro.adm_caucon_rgad = tobjModelo.Adm_caucon_rgad;
                        lobjRegistro.adm_fechos_rgad = (DateTime)tobjModelo.Adm_fechos_rgad;
                        lobjRegistro.adm_horhos_rgad = (Decimal)tobjModelo.Adm_horhos_rgad;
                        lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                        lobjRegistro.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                        lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                        lobjRegistro.sis_idterc_sitr = tobjModelo.Sis_idterc_sitr;
                        lobjRegistro.sia_edapac_usua = (int)tobjModelo.Sia_edapac_usua;
                        lobjRegistro.sia_codmed_tmed = tobjModelo.Sia_codmed_tmed;
                        lobjRegistro.sia_edaano_usua = (int)tobjModelo.Sia_edaano_usua;
                        lobjRegistro.sia_edames_usua = (int)tobjModelo.Sia_edames_usua;
                        lobjRegistro.sia_edadia_usua = (int)tobjModelo.Sia_edadia_usua;
                        lobjRegistro.sia_edaymd_usua = tobjModelo.Sia_edaymd_usua;
                        lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                        lobjRegistro.adm_nroaut_rgad = tobjModelo.Adm_nroaut_rgad;
                        lobjRegistro.adm_nropol_rgad = tobjModelo.Adm_nropol_rgad;
                        lobjRegistro.sia_tipusu_regi = tobjModelo.Sia_tipusu_regi;
                        lobjRegistro.sia_tipafi_tafi = tobjModelo.Sia_tipafi_tafi;
                        lobjRegistro.sia_nivsbn_nsbn = tobjModelo.Sia_nivsbn_nsbn;
                        lobjRegistro.sia_tippob_tpob = tobjModelo.Sia_tippob_tpob;
                        lobjRegistro.sia_nivcon_ncon = tobjModelo.Sia_nivcon_ncon;
                        lobjRegistro.adm_nomaco_rgad = tobjModelo.Adm_nomaco_rgad;
                        lobjRegistro.adm_diraco_rgad = tobjModelo.Adm_diraco_rgad;
                        lobjRegistro.adm_telaco_rgad = tobjModelo.Adm_telaco_rgad;
                        lobjRegistro.adm_nrorem_rgad = tobjModelo.Adm_nrorem_rgad;
                        lobjRegistro.sis_idemun_muni = tobjModelo.Sis_idemun_muni;
                        lobjRegistro.sia_codips_tips = tobjModelo.Sia_codips_tips;
                        lobjRegistro.adm_fecrem_rgad = (DateTime)tobjModelo.Adm_fecrem_rgad;
                        lobjRegistro.adm_secite_rgad = (int)tobjModelo.Adm_secite_rgad;
                        lobjRegistro.sia_regate_rgat = tobjModelo.Sia_regate_rgat;
                        lobjRegistro.adm_estfac_rgad = tobjModelo.Adm_estfac_rgad;
                        lobjRegistro.adm_estrad_rgad = tobjModelo.Adm_estrad_rgad;
                        lobjRegistro.adm_liqest_rgad = tobjModelo.Adm_liqest_rgad;
                        lobjRegistro.adm_ctarip_rgad = tobjModelo.Adm_ctarip_rgad;
                        lobjRegistro.adm_finate_rgad = tobjModelo.Adm_finate_rgad;
                        lobjRegistro.sia_codfco_fcon = tobjModelo.Sia_codfco_fcon;
                        lobjRegistro.sia_coddia_tdia = tobjModelo.Sia_coddia_tdia;
                        lobjRegistro.sia_tipdxp_tdix = tobjModelo.Sia_tipdxp_tdix;
                        lobjRegistro.adm_dessal_regr = tobjModelo.Adm_dessal_regr;
                        lobjRegistro.sia_dixre1_tdia = tobjModelo.Sia_dixre1_tdia;
                        lobjRegistro.sia_dixre2_tdia = tobjModelo.Sia_dixre2_tdia;
                        lobjRegistro.sia_dixre3_tdia = tobjModelo.Sia_dixre3_tdia;
                        lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                        lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                        lobjRegistro.adm_conest_rgad = (int)tobjModelo.Adm_conest_rgad;
                        lobjRegistro.adm_fecedt_rgad = (DateTime)tobjModelo.Adm_fecedt_rgad;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                        lobjRegistro.adm_fllave_rgad = Funciones.fnuLlaveIdFecha(tobjModelo.Adm_fecadm_rgad);

                        #endregion
                        _context.SaveChanges();
                    }
                }
                if (!String.IsNullOrWhiteSpace(lcrCodigoAdmision))
                {
                    ModeloHclvariabactual.fcvGenAdmisionVariablesPublicas(lcrCodigoAdmision);
                    FcmModeloServDetallFacturas.fcvActualizarEpsDetallesFacturas(lcrCodigoAdmision);
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: fcvActualizar");
            }
        }
        #endregion
        #region fcvActualizarEstados: Actualizar estados de la admision y contador detalles
        /// <summary>
        ///  <para>Actualizar: Estado admision, estado facturacion, estado datos medicos  y contador detalles</para>
        ///  <para>Cuando el parametro esta vacio, no se actualiza el valor en base de datos (7 PARAMETROS)</para>
        /// </summary>
        public static void fcvActualizarEstados(String tcrIdAdmision, String tcrEstAdm, String tcrEstMedicos,
                                                String tcrEstFact, String tcrLiqEstancia, String tcrEstRips, int tnuContador)
        {
            using (_context = new DbAplicacion())
            {
                var lobReg = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision);
                if (lobReg != null)
                {
                    lobReg.adm_estfac_rgad = !String.IsNullOrWhiteSpace(tcrEstFact) ? tcrEstFact : lobReg.adm_estfac_rgad;
                    lobReg.adm_estrad_rgad = !String.IsNullOrWhiteSpace(tcrEstMedicos) ? tcrEstMedicos : lobReg.adm_estrad_rgad;
                    lobReg.adm_liqest_rgad = !String.IsNullOrWhiteSpace(tcrLiqEstancia) ? tcrLiqEstancia : lobReg.adm_liqest_rgad;
                    lobReg.adm_ctarip_rgad = !String.IsNullOrWhiteSpace(tcrEstRips) ? tcrEstRips : lobReg.adm_ctarip_rgad;
                    lobReg.adm_conest_rgad = tnuContador > 0 ? tnuContador : lobReg.adm_conest_rgad;
                    lobReg.sis_estpro_espr = !String.IsNullOrWhiteSpace(tcrEstAdm) ? tcrEstAdm : lobReg.sis_estpro_espr;
                    _context.SaveChanges();
                }
            }
        }
        /// <summary>
        ///  <para>Actualizar: Estado admision, estado facturacion, estado datos medicos, estancias, finalizar atencion </para>
        ///  <para> y contador detalles  Cuando el parametro esta vacio, no se actualiza el valor en base de datos (8 PARAMETROS)</para>
        /// </summary>
        public static void fcvActualizarEstados(String tcrIdAdmision, String tcrEstAdm, String tcrEstMedicos,
                                                String tcrEstFact, String tcrLiqEstancia, String tcrEstRips,
                                                String tcrEstFinAtencion, int tnuContador)
        {
            using (_context = new DbAplicacion())
            {
                var lobReg = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision);
                if (lobReg != null)
                {
                    lobReg.adm_estfac_rgad = !String.IsNullOrWhiteSpace(tcrEstFact) ? tcrEstFact : lobReg.adm_estfac_rgad;
                    lobReg.adm_estrad_rgad = !String.IsNullOrWhiteSpace(tcrEstMedicos) ? tcrEstMedicos : lobReg.adm_estrad_rgad;
                    lobReg.adm_liqest_rgad = !String.IsNullOrWhiteSpace(tcrLiqEstancia) ? tcrLiqEstancia : lobReg.adm_liqest_rgad;
                    lobReg.adm_ctarip_rgad = !String.IsNullOrWhiteSpace(tcrEstRips) ? tcrEstRips : lobReg.adm_ctarip_rgad;
                    lobReg.adm_finate_rgad = !String.IsNullOrWhiteSpace(tcrEstFinAtencion) ? tcrEstFinAtencion : lobReg.adm_finate_rgad;
                    lobReg.adm_conest_rgad = tnuContador > 0 ? tnuContador : lobReg.adm_conest_rgad;
                    lobReg.sis_estpro_espr = !String.IsNullOrWhiteSpace(tcrEstAdm) ? tcrEstAdm : lobReg.sis_estpro_espr;
                    _context.SaveChanges();
                }
            }
        }
        /// <summary>
        ///  <para>Actualizar: Estado admision, al realizar un traslado </para>
        /// </summary>
        public static void fcvActualizarTraslado(String tcrIdAdmision, String tcrCodigoAreaServ,  int tnuContador)
        {
            using (_context = new DbAplicacion())
            {
                var lobReg = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision);
                if (lobReg != null)
                {
                    lobReg.adm_conest_rgad = tnuContador > 0 ? tnuContador : lobReg.adm_conest_rgad;
                    lobReg.sia_codare_aser = tcrCodigoAreaServ != "NA" ? tcrCodigoAreaServ : lobReg.sia_codare_aser;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fcvActualizGenIdItems: Actualizar el secuenciador que genera id unicos para item desde admision
        /// <summary>
        ///  <para>Actualizar el secuenciador que genera id unicos para item desde admision</para>
        /// </summary>
        public static void fcvActualizGenIdItems(String tcrIdAdmision, int tnuContador)
        {
            using (_context = new DbAplicacion())
            {
                var lobReg = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision);
                if (lobReg != null)
                {
                    lobReg.adm_secite_rgad = lobReg.adm_secite_rgad + tnuContador;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fnuGenerarIdItems: Generar un nuevo id unico para item desde admision
        /// <summary>
        ///  <para>Generar un nuevo id unico para item desde admision</para>
        /// </summary>
        public static int fnuGenerarIdItems(String tcrIdAdmision)
        {
            var lnuId = 0;
            using (_context = new DbAplicacion())
            {
                var lobReg = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision);
                if (lobReg != null)
                {
                    lobReg.adm_secite_rgad = lobReg.adm_secite_rgad + 1;
                    _context.SaveChanges();
                    lnuId = (int)lobReg.adm_secite_rgad;
                }
            }
            return lnuId;
        }
        #endregion
        #region fcvActualizDatosIngHospitaliz: Actualizar datos de ingreso a hospitalización desde traslado
        /// <summary>
        ///  <para>Actualizar datos de ingreso a hospitalización desde traslado</para>
        /// </summary>
        public static void fcvActualizDatosIngHospitaliz(String tcrIdAdmision, DateTime tdaFechaIngHosp, Decimal tdeHoraIngHosp, String tcrCodigoCama)
        {
            using (_context = new DbAplicacion())
            {
                var lobReg = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision);
                if (lobReg != null)
                {
                    lobReg.adm_fechos_rgad = tdaFechaIngHosp;
                    lobReg.adm_horhos_rgad = tdeHoraIngHosp;
                    lobReg.hos_codcam_caho = tcrCodigoCama;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fcvActualizDatosHistClinica: Actualizar numero de historia clinica
        /// <summary>
        ///  <para>Actualizar numero de historia clinica</para>
        /// </summary>
        public static void fcvActualizDatosHistClinica(String tcrIdAdmision, String tcrNumeroHClinica)
        {
            using (_context = new DbAplicacion())
            {
                var lobReg = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrIdAdmision);
                if (lobReg != null)
                {
                    lobReg.hcl_nrohis_hicl = tcrNumeroHClinica;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Actualizar Registro para Numero Historia clinica
        public static void fcvActualizarNumeroHc(EFadmregadmision tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tobjModelo.adm_secadm_rgad);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hcl_nrohis_hicl = tobjModelo.hcl_nrohis_hicl;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar ADMREGADMISION: Logica
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TITULO: Admisión de pacientes</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla del modulo de facturación médica (fcm) - Registrar todas
        /// las admisiones de pacientes en la institución IPS;
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmregadmision(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros con relaciones tablas
        /// <summary>
        /// Retorna un registro admision completo (con descripción de campos Relacion)
        /// </summary>
        public static List<ADMModeloAdmadmisiones> flsListaAdmregadmision(String tcrCodigoAdmision)
        {
            using (_context = new DbAplicacion())
            {
                #region Consulta
                var lobConsulta = from admregadmision in _context.Admregadmision
                                  join siausuarioatend in _context.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                  join siaareapreservi in _context.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                  join sismaesterceros in _context.Sismaesterceros on admregadmision.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                  join siadiagnosticos in _context.Siadiagnosticos on admregadmision.sia_dixing_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                  join ctomaescontrato in _context.Ctomaescontrato on admregadmision.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                  from usua in tmsiausuarioatend.DefaultIfEmpty()
                                  from aser in tmsiaareapreservi.DefaultIfEmpty()
                                  from sitr in tmsismaesterceros.DefaultIfEmpty()
                                  from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                  from cont in tmctomaescontrato.DefaultIfEmpty()
                                  where admregadmision.adm_secadm_rgad == tcrCodigoAdmision
                                  select new ADMModeloAdmadmisiones
                                  {
                                      #region Datos
                                      Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                      Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                      Sia_tipide_tide = admregadmision.sia_tipide_tide,
                                      Sia_nroide_usua = admregadmision.sia_nroide_usua,
                                      Hcl_nrohis_hicl = admregadmision.hcl_nrohis_hicl,
                                      Cit_codasi_mcit = admregadmision.cit_codasi_mcit,
                                      Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                      Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                      Adm_pacemb_rgad = admregadmision.adm_pacemb_rgad,
                                      Adm_reingr_rgad = admregadmision.adm_reingr_rgad,
                                      Adm_codoad_toad = admregadmision.adm_codoad_toad,
                                      Adm_nroreg_tria = admregadmision.adm_nroreg_tria,
                                      Sia_codare_aser = admregadmision.sia_codare_aser,
                                      Sia_areing_aser = admregadmision.sia_areing_aser,
                                      Fcm_codcpr_cpro = admregadmision.fcm_codcpr_cpro,
                                      Desia_areing_aser = _context.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == admregadmision.sia_areing_aser).sia_desare_aser,
                                      Adm_codtat_tatn = admregadmision.adm_codtat_tatn,
                                      Adm_codcex_tcex = admregadmision.adm_codcex_tcex,
                                      Hos_codcam_caho = admregadmision.hos_codcam_caho,
                                      Hos_codsec_hsec = admregadmision.hos_codsec_hsec,
                                      Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                      Adm_caucon_rgad = admregadmision.adm_caucon_rgad,
                                      Adm_fechos_rgad = (DateTime)admregadmision.adm_fechos_rgad,
                                      Adm_horhos_rgad = (Decimal)admregadmision.adm_horhos_rgad,
                                      Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                      Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                      Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                      Sis_idterc_sitr = admregadmision.sis_idterc_sitr,
                                      Sia_edapac_usua = (int)admregadmision.sia_edapac_usua,
                                      Sia_codmed_tmed = admregadmision.sia_codmed_tmed,
                                      Sia_edaano_usua = (int)admregadmision.sia_edaano_usua,
                                      Sia_edames_usua = (int)admregadmision.sia_edames_usua,
                                      Sia_edadia_usua = (int)admregadmision.sia_edadia_usua,
                                      Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                      Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                      Adm_nroaut_rgad = admregadmision.adm_nroaut_rgad,
                                      Adm_nropol_rgad = admregadmision.adm_nropol_rgad,
                                      Sia_tipusu_regi = admregadmision.sia_tipusu_regi,
                                      Sia_tipafi_tafi = admregadmision.sia_tipafi_tafi,
                                      Sia_nivsbn_nsbn = admregadmision.sia_nivsbn_nsbn,
                                      Sia_tippob_tpob = admregadmision.sia_tippob_tpob,
                                      Sia_nivcon_ncon = usua.sia_nivcon_ncon,
                                      Adm_nomaco_rgad = admregadmision.adm_nomaco_rgad,
                                      Adm_diraco_rgad = admregadmision.adm_diraco_rgad,
                                      Adm_telaco_rgad = admregadmision.adm_telaco_rgad,
                                      Adm_nrorem_rgad = admregadmision.adm_nrorem_rgad,
                                      Sis_idemun_muni = admregadmision.sis_idemun_muni,
                                      Sia_codips_tips = admregadmision.sia_codips_tips,
                                      Adm_fecrem_rgad = (DateTime)admregadmision.adm_fecrem_rgad,
                                      Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                      Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                      Adm_estfac_rgad = admregadmision.adm_estfac_rgad,
                                      Adm_estrad_rgad = admregadmision.adm_estrad_rgad,
                                      Adm_liqest_rgad = admregadmision.adm_liqest_rgad,
                                      Adm_ctarip_rgad = admregadmision.adm_ctarip_rgad,
                                      Adm_finate_rgad = admregadmision.adm_finate_rgad,
                                      Sia_codfco_fcon = admregadmision.sia_codfco_fcon,
                                      Sia_coddia_tdia = admregadmision.sia_coddia_tdia,
                                      Sia_tipdxp_tdix = admregadmision.sia_tipdxp_tdix,
                                      Adm_dessal_regr = admregadmision.adm_dessal_regr,
                                      Sia_dixre1_tdia = admregadmision.sia_dixre1_tdia,
                                      Sia_dixre2_tdia = admregadmision.sia_dixre2_tdia,
                                      Sia_dixre3_tdia = admregadmision.sia_dixre3_tdia,
                                      Sia_codcat_ceat = admregadmision.sia_codcat_ceat,
                                      Sys_codusu_usux = admregadmision.sys_codusu_usux,
                                      Adm_conest_rgad = (int)admregadmision.adm_conest_rgad,
                                      Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                      Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                      Sia_priape_usua = usua.sia_priape_usua,
                                      Sia_segape_usua = usua.sia_segape_usua,
                                      Sia_prinom_usua = usua.sia_prinom_usua,
                                      Sia_segnom_usua = usua.sia_segnom_usua,
                                      Sia_nomusu_usua = usua.sia_nomusu_usua,
                                      Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                      Sis_codsex_sexo = usua.sis_codsex_sexo,
                                      Sis_codmun_muni = usua.sis_codmun_muni,
                                      Sis_coddep_dpto = usua.sis_coddep_dpto,
                                      Sis_zonres_tzon = usua.sis_zonres_tzon,
                                      Sia_telres_usua = usua.sia_telres_usua,
                                      Sia_dirres_usua = usua.sia_dirres_usua,
                                      Sis_codocu_ocup = usua.sis_codocu_ocup,
                                      Sia_desare_aser = aser.sia_desare_aser,
                                      Sia_desdia_tdia = tdia.sia_desdia_tdia,
                                      Cto_descon_cont = cont.cto_descon_cont,
                                      Fcm_codman_mans = cont.fcm_codman_mans,
                                      Sia_tipdis_tdis = usua.sia_tipdis_tdis,
                                      Sia_codper_pret = usua.sia_codper_pret,
                                      Sis_numide_sitr = sitr.sis_numide_sitr,
                                      Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                      Sia_desate_rgat = admregadmision.sia_regate_rgat == "1" ? "ADMITIDO" : "AMBULATORIA",
                                      Sia_desdis_tdis = _context.Siatipdiscapaci.FirstOrDefault(rxp => rxp.sia_tipdis_tdis == usua.sia_tipdis_tdis).sia_desdis_tdis,
                                      Sia_despob_tpob = _context.Siatippoblacion.FirstOrDefault(rxp => rxp.sia_tippob_tpob == usua.sia_tippob_tpob).sia_despob_tpob,
                                      Adm_destat_tatn = _context.Admtipoatencion.FirstOrDefault(rxp => rxp.adm_codtat_tatn == admregadmision.adm_codtat_tatn).adm_destat_tatn,
                                      Adm_descex_tcex = _context.Admcausaexterna.FirstOrDefault(rxp => rxp.adm_codcex_tcex == admregadmision.adm_codcex_tcex).adm_descex_tcex,
                                      Sis_dessex_sexo = _context.Sistablasexos.FirstOrDefault(rxp => rxp.sis_codsex_sexo == usua.sis_codsex_sexo).sis_dessex_sexo,
                                      Sia_deseps_teps = _context.Siatablaeps.FirstOrDefault(rxp => rxp.sia_codeps_teps == admregadmision.sia_codeps_teps).sia_deseps_teps,
                                      Sia_nompro_prof = _context.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == admregadmision.sia_codpfa_prof).sia_nompro_prof,
                                      Sis_nommun_muni = _context.Sistabmunicipio.FirstOrDefault(rxp => rxp.sis_idemun_muni == admregadmision.sis_idemun_muni).sis_nommun_muni,
                                      Sis_desdep_dpto = _context.Sistabdepartame.FirstOrDefault(rxp => rxp.sis_coddep_dpto == usua.sis_coddep_dpto).sis_desdep_dpto,
                                      Sia_desips_tips = _context.Siatablaips.FirstOrDefault(rxp => rxp.sia_codips_tips == admregadmision.sia_codips_tips).sia_desips_tips,
                                      Sia_descat_ceat = _context.Siacentroaten.FirstOrDefault(rxp => rxp.sia_codcat_ceat == admregadmision.sia_codcat_ceat).sia_descat_ceat,
                                      Sys_nomusu_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == admregadmision.sys_codusu_usux).sys_nomusu_usux,
                                      Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregadmision.sis_estpro_espr).sis_despro_espr,
                                      Sis_desocu_ocup = _context.Sisocupaciones.FirstOrDefault(rxp => rxp.sis_codocu_ocup == admregadmision.sis_codocu_ocup).sis_desocu_ocup,
                                      Sia_destip_regi = _context.Siaregimensalud.FirstOrDefault(rxp => rxp.sia_tipusu_regi == admregadmision.sia_tipusu_regi).sia_destip_regi,
                                      Sis_deszon_tzon = _context.Siszonaresidenc.FirstOrDefault(rxp => rxp.sis_zonres_tzon == usua.sis_zonres_tzon).sis_deszon_tzon,
                                      Sia_desper_pret = _context.Siapertenetnica.FirstOrDefault(rxp => rxp.sia_codper_pret == usua.sia_codper_pret).sia_desper_pret,
                                      Sia_desedu_sine = _context.Sianiveleducati.FirstOrDefault(rxp => rxp.sia_nivedu_sine == usua.sia_nivedu_sine).sia_desedu_sine,
                                      Hos_descam_caho = _context.Hoscamasareas.FirstOrDefault(rxp => rxp.hos_codcam_caho == admregadmision.hos_codcam_caho).hos_descam_caho,
                                      #endregion
                                  };
                return lobConsulta.ToList();
                #endregion
            }
        }
        #endregion
        #region flsListaAdmregadmisionSimple: Listar Registros Simple
        /// <summary>
        /// <para>Devuelve el registro de admision sin datos relacion</para>
        /// </summary>
        public static ADMModeloAdmadmisiones flsListaAdmregadmisionSimple(String tcrCodigoAdmision)
        {
            using (_context = new DbAplicacion())
            {
                ADMModeloAdmadmisiones lobReg = null;
                #region Consulta
                var lobConsulta = from admregadmision in _context.Admregadmision
                                  join siausuarioatend in _context.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                  join sismaesterceros in _context.Sismaesterceros on admregadmision.sis_idterc_sitr equals sismaesterceros.sis_idterc_sitr into tmsismaesterceros
                                  from usua in tmsiausuarioatend.DefaultIfEmpty()
                                  from sitr in tmsismaesterceros.DefaultIfEmpty()
                                  where admregadmision.adm_secadm_rgad == tcrCodigoAdmision
                                  select new ADMModeloAdmadmisiones
                                  {
                                      #region Datos
                                      Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                      Sia_idesec_usua = admregadmision.sia_idesec_usua,
                                      Sia_tipide_tide = admregadmision.sia_tipide_tide,
                                      Sia_nroide_usua = admregadmision.sia_nroide_usua,
                                      Hcl_nrohis_hicl = admregadmision.hcl_nrohis_hicl,
                                      Cit_codasi_mcit = admregadmision.cit_codasi_mcit,
                                      Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                      Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                      Adm_pacemb_rgad = admregadmision.adm_pacemb_rgad,
                                      Adm_reingr_rgad = admregadmision.adm_reingr_rgad,
                                      Adm_codoad_toad = admregadmision.adm_codoad_toad,
                                      Adm_nroreg_tria = admregadmision.adm_nroreg_tria,
                                      Sia_codare_aser = admregadmision.sia_codare_aser,
                                      Sia_areing_aser = admregadmision.sia_areing_aser,
                                      Fcm_codcpr_cpro = admregadmision.fcm_codcpr_cpro,
                                      Adm_codtat_tatn = admregadmision.adm_codtat_tatn,
                                      Adm_codcex_tcex = admregadmision.adm_codcex_tcex,
                                      Hos_codcam_caho = admregadmision.hos_codcam_caho,
                                      Hos_codsec_hsec = admregadmision.hos_codsec_hsec,
                                      Sia_dixing_tdia = admregadmision.sia_dixing_tdia,
                                      Adm_caucon_rgad = admregadmision.adm_caucon_rgad,
                                      Adm_fechos_rgad = (DateTime)admregadmision.adm_fechos_rgad,
                                      Adm_horhos_rgad = (Decimal)admregadmision.adm_horhos_rgad,
                                      Cto_seccon_cont = admregadmision.cto_seccon_cont,
                                      Cto_nrocon_cont = admregadmision.cto_nrocon_cont,
                                      Sia_codeps_teps = admregadmision.sia_codeps_teps,
                                      Sis_idterc_sitr = admregadmision.sis_idterc_sitr,
                                      Sia_edapac_usua = (int)admregadmision.sia_edapac_usua,
                                      Sia_codmed_tmed = admregadmision.sia_codmed_tmed,
                                      Sia_edaano_usua = (int)admregadmision.sia_edaano_usua,
                                      Sia_edames_usua = (int)admregadmision.sia_edames_usua,
                                      Sia_edadia_usua = (int)admregadmision.sia_edadia_usua,
                                      Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                      Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                      Adm_nroaut_rgad = admregadmision.adm_nroaut_rgad,
                                      Adm_nropol_rgad = admregadmision.adm_nropol_rgad,
                                      Sia_tipusu_regi = admregadmision.sia_tipusu_regi,
                                      Sia_tipafi_tafi = admregadmision.sia_tipafi_tafi,
                                      Sia_nivsbn_nsbn = admregadmision.sia_nivsbn_nsbn,
                                      Sia_tippob_tpob = admregadmision.sia_tippob_tpob,
                                      Sia_nivcon_ncon = usua.sia_nivcon_ncon,
                                      Sia_nomusu_usua = usua.sia_nomusu_usua,
                                      Sis_codocu_ocup = admregadmision.sis_codocu_ocup,
                                      Adm_nomaco_rgad = admregadmision.adm_nomaco_rgad,
                                      Adm_diraco_rgad = admregadmision.adm_diraco_rgad,
                                      Adm_telaco_rgad = admregadmision.adm_telaco_rgad,
                                      Adm_nrorem_rgad = admregadmision.adm_nrorem_rgad,
                                      Sis_idemun_muni = admregadmision.sis_idemun_muni,
                                      Sia_codips_tips = admregadmision.sia_codips_tips,
                                      Adm_fecrem_rgad = (DateTime)admregadmision.adm_fecrem_rgad,
                                      Adm_secite_rgad = (int)admregadmision.adm_secite_rgad,
                                      Sia_regate_rgat = admregadmision.sia_regate_rgat,
                                      Adm_estfac_rgad = admregadmision.adm_estfac_rgad,
                                      Adm_estrad_rgad = admregadmision.adm_estrad_rgad,
                                      Adm_liqest_rgad = admregadmision.adm_liqest_rgad,
                                      Adm_ctarip_rgad = admregadmision.adm_ctarip_rgad,
                                      Adm_finate_rgad = admregadmision.adm_finate_rgad,
                                      Sia_codfco_fcon = admregadmision.sia_codfco_fcon,
                                      Sia_coddia_tdia = admregadmision.sia_coddia_tdia,
                                      Sia_tipdxp_tdix = admregadmision.sia_tipdxp_tdix,
                                      Adm_dessal_regr = admregadmision.adm_dessal_regr,
                                      Sia_dixre1_tdia = admregadmision.sia_dixre1_tdia,
                                      Sia_dixre2_tdia = admregadmision.sia_dixre2_tdia,
                                      Sia_dixre3_tdia = admregadmision.sia_dixre3_tdia,
                                      Sia_codcat_ceat = admregadmision.sia_codcat_ceat,
                                      Sys_codusu_usux = admregadmision.sys_codusu_usux,
                                      Adm_conest_rgad = (int)admregadmision.adm_conest_rgad,
                                      Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                      Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                      Sis_numide_sitr = sitr.sis_numide_sitr,
                                      Sis_razsoc_sitr = sitr.sis_razsoc_sitr,
                                      #endregion
                                  };
                if (lobConsulta != null)
                {
                    lobReg = lobConsulta.ToList().FirstOrDefault();
                }
                return lobReg;
                #endregion
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Tabla admtriagemaestr: Maestro registro Triage
    /// </summary>
    public class ADMModeloTriage : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Adm_nroreg_tria: Codigo registro
        private String _adm_nroreg_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: adm_nroreg_tria (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial del registro triage
        /// </para>
        /// </summary>
        public String Adm_nroreg_tria
        {
            get { return _adm_nroreg_tria; }
            set
            {
                if (_adm_nroreg_tria == value) return;
                _adm_nroreg_tria = value;
                OnPropertyChanged("Adm_nroreg_tria");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Consecutivo único de paciente en el sistema, se genera al crear
        /// el registro de usuario o cuando la base de datos es cargada
        /// en el sistema
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
        #region Hcl_nrohis_hicl: Numero historia clínica
        private String _hcl_nrohis_hicl;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Numero historia clínica</para>
        /// <para>NOMBRE: hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero o código de la Ficha de Historias Clínicas electronica
        /// </para>
        /// </summary>
        public String Hcl_nrohis_hicl
        {
            get { return _hcl_nrohis_hicl; }
            set
            {
                if (_hcl_nrohis_hicl == value) return;
                _hcl_nrohis_hicl = value;
                OnPropertyChanged("Hcl_nrohis_hicl");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión
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
        #region Sia_tipide_tide: Tipo Identificación
        private String _sia_tipide_tide;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region Sia_nroide_usua: Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region Sia_priape_usua: Primer Apellido
        private String _sia_priape_usua;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Primer Apellido</para>
        /// <para>NOMBRE: sia_priape_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_priape_usua
        {
            get { return _sia_priape_usua; }
            set
            {
                if (_sia_priape_usua == value) return;
                _sia_priape_usua = value;
                OnPropertyChanged("Sia_priape_usua");
            }
        }
        #endregion
        #region Sia_segape_usua: Segundo Apellido
        private String _sia_segape_usua;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Segundo Apellido</para>
        /// <para>NOMBRE: sia_segape_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Segundo apellido del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_segape_usua
        {
            get { return _sia_segape_usua; }
            set
            {
                if (_sia_segape_usua == value) return;
                _sia_segape_usua = value;
                OnPropertyChanged("Sia_segape_usua");
            }
        }
        #endregion
        #region Sia_prinom_usua: Primer Nombre
        private String _sia_prinom_usua;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Primer Nombre</para>
        /// <para>NOMBRE: sia_prinom_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_prinom_usua
        {
            get { return _sia_prinom_usua; }
            set
            {
                if (_sia_prinom_usua == value) return;
                _sia_prinom_usua = value;
                OnPropertyChanged("Sia_prinom_usua");
            }
        }
        #endregion
        #region Sia_segnom_usua: Segundo Nombre
        private String _sia_segnom_usua;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Segundo Nombre</para>
        /// <para>NOMBRE: sia_segnom_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Segundo nombre del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_segnom_usua
        {
            get { return _sia_segnom_usua; }
            set
            {
                if (_sia_segnom_usua == value) return;
                _sia_segnom_usua = value;
                OnPropertyChanged("Sia_segnom_usua");
            }
        }
        #endregion
        #region Sia_fecnac_usua: Fecha nacimiento
        private DateTime _sia_fecnac_usua;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region Sis_codsex_sexo: Sexo
        private String _sis_codsex_sexo;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Sexo del  usuario o paciente
        /// </para>
        /// </summary>
        public String Sis_codsex_sexo
        {
            get { return _sis_codsex_sexo; }
            set
            {
                if (_sis_codsex_sexo == value) return;
                _sis_codsex_sexo = value;
                OnPropertyChanged("Sis_codsex_sexo");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region Sia_edapac_usua: Edad paciente
        private int _sia_edapac_usua;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad paciente</para>
        /// <para>NOMBRE: sia_edapac_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Edad Paciente al momento de la atención
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
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Medida Edad</para>
        /// <para>NOMBRE: sia_codmed_tmed (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        #region Adm_gesfec_tria: Fecha servicio
        private DateTime _adm_gesfec_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: adm_gesfec_tria (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Fecha del evento o prestacion del servicio al paciente
        /// </para>
        /// </summary>
        public DateTime Adm_gesfec_tria
        {
            get { return _adm_gesfec_tria; }
            set
            {
                if (_adm_gesfec_tria == value) return;
                _adm_gesfec_tria = value;
                OnPropertyChanged("Adm_gesfec_tria");
            }
        }
        #endregion
        #region Adm_geshor_tria: Hora servicio
        private Decimal _adm_geshor_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: adm_geshor_tria (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Hora del evento o prestación del servicio al paciente en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Adm_geshor_tria
        {
            get { return _adm_geshor_tria; }
            set
            {
                if (_adm_geshor_tria == value) return;
                _adm_geshor_tria = value;
                OnPropertyChanged("Adm_geshor_tria");
            }
        }
        #endregion
        #region Adm_frecar_tria: Frecuencia cardiaca (FC)
        private float _adm_frecar_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Frecuencia cardiaca (FC)</para>
        /// <para>NOMBRE: adm_frecar_tria (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Toma de signo vital frecuencia cardiaca
        /// </para>
        /// </summary>
        public float Adm_frecar_tria
        {
            get { return _adm_frecar_tria; }
            set
            {
                if (_adm_frecar_tria == value) return;
                _adm_frecar_tria = value;
                OnPropertyChanged("Adm_frecar_tria");
            }
        }
        #endregion
        #region Adm_freres_tria: Frecuencia respiratoria (FR)
        private float _adm_freres_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Frecuencia respiratoria (FR)</para>
        /// <para>NOMBRE: adm_freres_tria (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Toma de signo vital frecuencia respiratoria
        /// </para>
        /// </summary>
        public float Adm_freres_tria
        {
            get { return _adm_freres_tria; }
            set
            {
                if (_adm_freres_tria == value) return;
                _adm_freres_tria = value;
                OnPropertyChanged("Adm_freres_tria");
            }
        }
        #endregion
        #region Adm_tasist_tria: T.Arterial  sistólica
        private float _adm_tasist_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: T.Arterial  sistólica</para>
        /// <para>NOMBRE: adm_tasist_tria (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Tensión arterial sistolica
        /// </para>
        /// </summary>
        public float Adm_tasist_tria
        {
            get { return _adm_tasist_tria; }
            set
            {
                if (_adm_tasist_tria == value) return;
                _adm_tasist_tria = value;
                OnPropertyChanged("Adm_tasist_tria");
            }
        }
        #endregion
        #region Adm_tadias_tria: T.Arterial diastólica
        private float _adm_tadias_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: T.Arterial diastólica</para>
        /// <para>NOMBRE: adm_tadias_tria (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Tensión arterial diastolica
        /// </para>
        /// </summary>
        public float Adm_tadias_tria
        {
            get { return _adm_tadias_tria; }
            set
            {
                if (_adm_tadias_tria == value) return;
                _adm_tadias_tria = value;
                OnPropertyChanged("Adm_tadias_tria");
            }
        }
        #endregion
        #region Adm_temper_tria: Temperatura corporal
        private float _adm_temper_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Temperatura corporal</para>
        /// <para>NOMBRE: adm_temper_tria (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Toma de signo vital Temperatura corporal
        /// </para>
        /// </summary>
        public float Adm_temper_tria
        {
            get { return _adm_temper_tria; }
            set
            {
                if (_adm_temper_tria == value) return;
                _adm_temper_tria = value;
                OnPropertyChanged("Adm_temper_tria");
            }
        }
        #endregion
        #region Adm_pesokg_tria: Peso (kilogramos)
        private float _adm_pesokg_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Peso (kilogramos)</para>
        /// <para>NOMBRE: adm_pesokg_tria (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Peso corporal dado en kilogramos
        /// </para>
        /// </summary>
        public float Adm_pesokg_tria
        {
            get { return _adm_pesokg_tria; }
            set
            {
                if (_adm_pesokg_tria == value) return;
                _adm_pesokg_tria = value;
                OnPropertyChanged("Adm_pesokg_tria");
            }
        }
        #endregion
        #region Adm_tallac_tria: Talla (centimetros)
        private float _adm_tallac_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Talla (centimetros)</para>
        /// <para>NOMBRE: adm_tallac_tria (float:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Talla (estatura del paciente) en centimetros
        /// </para>
        /// </summary>
        public float Adm_tallac_tria
        {
            get { return _adm_tallac_tria; }
            set
            {
                if (_adm_tallac_tria == value) return;
                _adm_tallac_tria = value;
                OnPropertyChanged("Adm_tallac_tria");
            }
        }
        #endregion
        #region Adm_tiplle_tria: llegada al servicio
        private String _adm_tiplle_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: llegada al servicio</para>
        /// <para>NOMBRE: adm_tiplle_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Tipo llegada para recibir la atencion: 1 =Caminando,2=Vehiculo
        /// particular,3= Ambulancia  y otros
        /// </para>
        /// </summary>
        public String Adm_tiplle_tria
        {
            get { return _adm_tiplle_tria; }
            set
            {
                if (_adm_tiplle_tria == value) return;
                _adm_tiplle_tria = value;
                OnPropertyChanged("Adm_tiplle_tria");
            }
        }
        #endregion
        #region Adm_motcon_tria: Motivo consulta
        private String _adm_motcon_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Motivo consulta</para>
        /// <para>NOMBRE: adm_motcon_tria (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Motivo textual de consulta
        /// </para>
        /// </summary>
        public String Adm_motcon_tria
        {
            get { return _adm_motcon_tria; }
            set
            {
                if (_adm_motcon_tria == value) return;
                _adm_motcon_tria = value;
                OnPropertyChanged("Adm_motcon_tria");
            }
        }
        #endregion
        #region Adm_clasif_tria: Clasificación triage
        private String _adm_clasif_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Clasificación triage</para>
        /// <para>NOMBRE: adm_clasif_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Clasificacion de evaluacion Triage : 1= TRIAGE I  2= TRIAGE
        /// II  3= TRIAGE III
        /// </para>
        /// </summary>
        public String Adm_clasif_tria
        {
            get { return _adm_clasif_tria; }
            set
            {
                if (_adm_clasif_tria == value) return;
                _adm_clasif_tria = value;
                OnPropertyChanged("Adm_clasif_tria");
            }
        }
        #endregion
        #region Adm_remisi_tria: Destino Remisión
        private String _adm_remisi_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Destino Remisión</para>
        /// <para>NOMBRE: adm_remisi_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Destino remisión paciente despues de evaluación : 1 = Consulta
        /// Externa  2 = Consulta prioritaria  3 = Urgencia
        /// </para>
        /// </summary>
        public String Adm_remisi_tria
        {
            get { return _adm_remisi_tria; }
            set
            {
                if (_adm_remisi_tria == value) return;
                _adm_remisi_tria = value;
                OnPropertyChanged("Adm_remisi_tria");
            }
        }
        #endregion
        #region Sia_coddia_tdia: Codgo Diagnostico
        private String _sia_coddia_tdia;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Codgo Diagnostico</para>
        /// <para>NOMBRE: sia_coddia_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Codgo del diagnostico según la tabla CIE-10 que determina el
        /// resultado de la evaluacion triage
        /// </para>
        /// </summary>
        public String Sia_coddia_tdia
        {
            get { return _sia_coddia_tdia; }
            set
            {
                if (_sia_coddia_tdia == value) return;
                _sia_coddia_tdia = value;
                OnPropertyChanged("Sia_coddia_tdia");
            }
        }
        #endregion
        #region Adm_observ_tria: Observación
        private String _adm_observ_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Observación</para>
        /// <para>NOMBRE: adm_observ_tria (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Nota de observación
        /// </para>
        /// </summary>
        public String Adm_observ_tria
        {
            get { return _adm_observ_tria; }
            set
            {
                if (_adm_observ_tria == value) return;
                _adm_observ_tria = value;
                OnPropertyChanged("Adm_observ_tria");
            }
        }
        #endregion
        #region Sia_codeps_teps: Código EPS
        private String _sia_codeps_teps;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
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
        #region Fcm_codcpr_cpro: Código centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Codgio del centro de producción en el cual se produce el evento
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
        #region Sis_idemun_muni: Id único Municipio
        private String _sis_idemun_muni;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Id único Municipio</para>
        /// <para>NOMBRE: sis_idemun_muni (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Id Único Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio
        /// </para>
        /// </summary>
        public String Sis_idemun_muni
        {
            get { return _sis_idemun_muni; }
            set
            {
                if (_sis_idemun_muni == value) return;
                _sis_idemun_muni = value;
                OnPropertyChanged("Sis_idemun_muni");
            }
        }
        #endregion
        #region Sis_codmun_muni: Código Municipio
        private String _sis_codmun_muni;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Código Municipio</para>
        /// <para>NOMBRE: sis_codmun_muni (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///Código Municipio según DANE
        /// </para>
        /// </summary>
        public String Sis_codmun_muni
        {
            get { return _sis_codmun_muni; }
            set
            {
                if (_sis_codmun_muni == value) return;
                _sis_codmun_muni = value;
                OnPropertyChanged("Sis_codmun_muni");
            }
        }
        #endregion
        #region Sis_coddep_dpto: Código Departamento
        private String _sis_coddep_dpto;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Código Departamento</para>
        /// <para>NOMBRE: sis_coddep_dpto (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        ///Código  del departamento DANE
        /// </para>
        /// </summary>
        public String Sis_coddep_dpto
        {
            get { return _sis_coddep_dpto; }
            set
            {
                if (_sis_coddep_dpto == value) return;
                _sis_coddep_dpto = value;
                OnPropertyChanged("Sis_coddep_dpto");
            }
        }
        #endregion
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
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
        #region Sia_codpfa_prof: Profesional atiende
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Profesional atiende</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Código Profesional que presta servicio
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
        #region Sia_llaveb_usua: llave búsqueda
        private String _sia_llaveb_usua;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: llave búsqueda</para>
        /// <para>NOMBRE: sia_llaveb_usua (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// llave de búsqueda avanzada concatena:tipo ide+ identificacion+apellidos+n
        /// ombres+eps
        /// </para>
        /// </summary>
        public String Sia_llaveb_usua
        {
            get { return _sia_llaveb_usua; }
            set
            {
                if (_sia_llaveb_usua == value) return;
                _sia_llaveb_usua = value;
                OnPropertyChanged("Sia_llaveb_usua");
            }
        }
        #endregion
        #region Adm_tipreg_tria: Tipo registro
        private String _adm_tipreg_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: adm_tipreg_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Tipo registro según destino valoracion inicial: 1 = Es valoración
        /// inicial 2 = Evaluación completa en consultorio triage
        /// </para>
        /// </summary>
        public String Adm_tipreg_tria
        {
            get { return _adm_tipreg_tria; }
            set
            {
                if (_adm_tipreg_tria == value) return;
                _adm_tipreg_tria = value;
                OnPropertyChanged("Adm_tipreg_tria");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Estado de procesos en atencion asistencial : 1= Abierto  2=
        /// Cerrado/Confirmado 3=Anulado
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
        #region Sia_deside_tide: Descripción Tipo Usuario
        private String _sia_deside_tide;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region Sia_deseps_teps: Nombre EPS
        private String _sia_deseps_teps;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region Fcm_descpr_cpro: Nombre centro producción
        private String _fcm_descpr_cpro;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region Sis_nommun_muni: Nombre del Muncipio
        private String _sis_nommun_muni;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Nombre del Muncipio</para>
        /// <para>NOMBRE: sis_nommun_muni (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre del Muncipio
        /// </para>
        /// </summary>
        public String Sis_nommun_muni
        {
            get { return _sis_nommun_muni; }
            set
            {
                if (_sis_nommun_muni == value) return;
                _sis_nommun_muni = value;
                OnPropertyChanged("Sis_nommun_muni");
            }
        }
        #endregion
        #region Sis_desdep_dpto: Nombre del departamento
        private String _sis_desdep_dpto;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Nombre del departamento</para>
        /// <para>NOMBRE: sis_desdep_dpto (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre del departamento
        /// </para>
        /// </summary>
        public String Sis_desdep_dpto
        {
            get { return _sis_desdep_dpto; }
            set
            {
                if (_sis_desdep_dpto == value) return;
                _sis_desdep_dpto = value;
                OnPropertyChanged("Sis_desdep_dpto");
            }
        }
        #endregion
        #region Sia_descat_ceat: Descripción centro atención
        private String _sia_descat_ceat;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        /// <para>TABLA: admtriagemaestr</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region Sia_desdia_tdia: Descripcion diagnostico
        private String _sia_desdia_tdia;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: sia_desdia_tdia (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Sia_desdia_tdia
        {
            get { return _sia_desdia_tdia; }
            set
            {
                if (_sia_desdia_tdia == value) return;
                _sia_desdia_tdia = value;
                OnPropertyChanged("Sia_desdia_tdia");
            }
        }
        #endregion
        #region Adm_descla_adct: Descripcion clasificacion
        private String _adm_descla_adct;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Descripcion clasificacion</para>
        /// <para>NOMBRE: adm_descla_adct (memo)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripcion de clasificacion Triage según caracteristicas de la 
        ///condicion clinica y fisiologica del paciente al llegar y referencia 
        ///en la normatividad 
        /// </para>
        /// </summary>
        public String Adm_descla_adct
        {
            get { return _adm_descla_adct; }
            set
            {
                if (_adm_descla_adct == value) return;
                _adm_descla_adct = value;
                OnPropertyChanged("Adm_descla_adct");
            }
        }
        #endregion
        #region Adm_tiempo_adct: Tiempos para atencion medica
        private String _adm_tiempo_adct;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Tiempos para atencion medica</para>
        /// <para>NOMBRE: adm_tiempo_adct (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripcion corta del tiempo minimo o maximo  para que el paciente reciba atencion  
        ///medica según la conducta tommada, Ejemplo: Atencion medica ambulatoria antes de 72 horas
        /// </para>
        /// </summary>
        public String Adm_tiempo_adct
        {
            get { return _adm_tiempo_adct; }
            set
            {
                if (_adm_tiempo_adct == value) return;
                _adm_tiempo_adct = value;
                OnPropertyChanged("Adm_tiempo_adct");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ADMModeloTriage tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("ADM-SECEGR-TRIAGE", "ADM", "Secuencial unico Evaluación Triage");
            if (!flgBuscarAdmtriagemaestr(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFadmtriagemaestr
                    {
                        #region cargar Registro
                        adm_nroreg_tria = tobjModelo.Adm_nroreg_tria,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        sia_priape_usua = tobjModelo.Sia_priape_usua,
                        sia_segape_usua = tobjModelo.Sia_segape_usua,
                        sia_prinom_usua = tobjModelo.Sia_prinom_usua,
                        sia_segnom_usua = tobjModelo.Sia_segnom_usua,
                        sia_fecnac_usua = tobjModelo.Sia_fecnac_usua,
                        sis_codsex_sexo = tobjModelo.Sis_codsex_sexo,
                        sia_nomusu_usua = tobjModelo.Sia_nomusu_usua,
                        sia_edapac_usua = tobjModelo.Sia_edapac_usua,
                        sia_codmed_tmed = tobjModelo.Sia_codmed_tmed,
                        adm_gesfec_tria = tobjModelo.Adm_gesfec_tria,
                        adm_geshor_tria = tobjModelo.Adm_geshor_tria,
                        adm_frecar_tria = tobjModelo.Adm_frecar_tria,
                        adm_freres_tria = tobjModelo.Adm_freres_tria,
                        adm_tasist_tria = tobjModelo.Adm_tasist_tria,
                        adm_tadias_tria = tobjModelo.Adm_tadias_tria,
                        adm_temper_tria = tobjModelo.Adm_temper_tria,
                        adm_pesokg_tria = tobjModelo.Adm_pesokg_tria,
                        adm_tallac_tria = tobjModelo.Adm_tallac_tria,
                        adm_tiplle_tria = tobjModelo.Adm_tiplle_tria,
                        adm_motcon_tria = tobjModelo.Adm_motcon_tria,
                        adm_clasif_tria = tobjModelo.Adm_clasif_tria,
                        adm_remisi_tria = tobjModelo.Adm_remisi_tria,
                        sia_coddia_tdia = tobjModelo.Sia_coddia_tdia,
                        adm_observ_tria = tobjModelo.Adm_observ_tria,
                        sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                        fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                        sis_idemun_muni = tobjModelo.Sis_idemun_muni,
                        sis_codmun_muni = tobjModelo.Sis_codmun_muni,
                        sis_coddep_dpto = tobjModelo.Sis_coddep_dpto,
                        sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        sia_llaveb_usua = tobjModelo.Sia_llaveb_usua,
                        adm_tipreg_tria = tobjModelo.Adm_tipreg_tria,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.adm_nroreg_tria = lcrCodigoGen;
                    _context.AddToAdmtriagemaestr(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'ADM-SECEGR-TRIAGE': Secuencial unico Evaluación Triage en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ADMModeloTriage tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaestr.FirstOrDefault(p => p.adm_nroreg_tria == tobjModelo.Adm_nroreg_tria);
                if (lobjRegistro != null)
                {
                    lobjRegistro.adm_nroreg_tria = tobjModelo.Adm_nroreg_tria;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.sia_priape_usua = tobjModelo.Sia_priape_usua;
                    lobjRegistro.sia_segape_usua = tobjModelo.Sia_segape_usua;
                    lobjRegistro.sia_prinom_usua = tobjModelo.Sia_prinom_usua;
                    lobjRegistro.sia_segnom_usua = tobjModelo.Sia_segnom_usua;
                    lobjRegistro.sia_fecnac_usua = (DateTime)tobjModelo.Sia_fecnac_usua;
                    lobjRegistro.sis_codsex_sexo = tobjModelo.Sis_codsex_sexo;
                    lobjRegistro.sia_nomusu_usua = tobjModelo.Sia_nomusu_usua;
                    lobjRegistro.sia_edapac_usua = (int)tobjModelo.Sia_edapac_usua;
                    lobjRegistro.sia_codmed_tmed = tobjModelo.Sia_codmed_tmed;
                    lobjRegistro.adm_gesfec_tria = (DateTime)tobjModelo.Adm_gesfec_tria;
                    lobjRegistro.adm_geshor_tria = (Decimal)tobjModelo.Adm_geshor_tria;
                    lobjRegistro.adm_frecar_tria = (float)tobjModelo.Adm_frecar_tria;
                    lobjRegistro.adm_freres_tria = (float)tobjModelo.Adm_freres_tria;
                    lobjRegistro.adm_tasist_tria = (float)tobjModelo.Adm_tasist_tria;
                    lobjRegistro.adm_tadias_tria = (float)tobjModelo.Adm_tadias_tria;
                    lobjRegistro.adm_temper_tria = (float)tobjModelo.Adm_temper_tria;
                    lobjRegistro.adm_pesokg_tria = (float)tobjModelo.Adm_pesokg_tria;
                    lobjRegistro.adm_tallac_tria = (float)tobjModelo.Adm_tallac_tria;
                    lobjRegistro.adm_tiplle_tria = tobjModelo.Adm_tiplle_tria;
                    lobjRegistro.adm_motcon_tria = tobjModelo.Adm_motcon_tria;
                    lobjRegistro.adm_clasif_tria = tobjModelo.Adm_clasif_tria;
                    lobjRegistro.adm_remisi_tria = tobjModelo.Adm_remisi_tria;
                    lobjRegistro.sia_coddia_tdia = tobjModelo.Sia_coddia_tdia;
                    lobjRegistro.adm_observ_tria = tobjModelo.Adm_observ_tria;
                    lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                    lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                    lobjRegistro.sis_idemun_muni = tobjModelo.Sis_idemun_muni;
                    lobjRegistro.sis_codmun_muni = tobjModelo.Sis_codmun_muni;
                    lobjRegistro.sis_coddep_dpto = tobjModelo.Sis_coddep_dpto;
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.sia_llaveb_usua = tobjModelo.Sia_llaveb_usua;
                    lobjRegistro.adm_tipreg_tria = tobjModelo.Adm_tipreg_tria;
                    lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaestr.FirstOrDefault(p => p.adm_nroreg_tria == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar ADMTRIAGEMAESTR: Logica
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TITULO: Maestro evaluación Triage</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para  registro  de datos en la evaluación inicial Triage
        /// realizada a pacientes antes de ser admitidos.
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmtriagemaestr(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admtriagemaestr.FirstOrDefault(p => p.adm_nroreg_tria == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ADMModeloTriage> flsListaAdmtriagemaestr(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from admtriagemaestr in _context.Admtriagemaestr
                                  join siatipideusario in _context.Siatipideusario on admtriagemaestr.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                  join fcmcenproduccio in _context.Fcmcenproduccio on admtriagemaestr.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                  join siacentroaten in _context.Siacentroaten on admtriagemaestr.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                  join siadiagnosticos in _context.Siadiagnosticos on admtriagemaestr.sia_coddia_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                  from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                  from tide in tmsiatipideusario.DefaultIfEmpty()
                                  from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                  from ceat in tmsiacentroaten.DefaultIfEmpty()
                                  where admtriagemaestr.adm_nroreg_tria == tcrBuscar
                                  select new ADMModeloTriage
                                  {
                                      #region Listar Registros
                                      Adm_nroreg_tria = admtriagemaestr.adm_nroreg_tria,
                                      Sia_idesec_usua = admtriagemaestr.sia_idesec_usua,
                                      Hcl_nrohis_hicl = admtriagemaestr.hcl_nrohis_hicl,
                                      Adm_secadm_rgad = admtriagemaestr.adm_secadm_rgad,
                                      Sia_tipide_tide = admtriagemaestr.sia_tipide_tide,
                                      Sia_nroide_usua = admtriagemaestr.sia_nroide_usua,
                                      Sia_priape_usua = admtriagemaestr.sia_priape_usua,
                                      Sia_segape_usua = admtriagemaestr.sia_segape_usua,
                                      Sia_prinom_usua = admtriagemaestr.sia_prinom_usua,
                                      Sia_segnom_usua = admtriagemaestr.sia_segnom_usua,
                                      Sia_fecnac_usua = (DateTime)admtriagemaestr.sia_fecnac_usua,
                                      Sis_codsex_sexo = admtriagemaestr.sis_codsex_sexo,
                                      Sia_nomusu_usua = admtriagemaestr.sia_nomusu_usua,
                                      Sia_edapac_usua = (int)admtriagemaestr.sia_edapac_usua,
                                      Sia_codmed_tmed = admtriagemaestr.sia_codmed_tmed,
                                      Adm_gesfec_tria = (DateTime)admtriagemaestr.adm_gesfec_tria,
                                      Adm_geshor_tria = (Decimal)admtriagemaestr.adm_geshor_tria,
                                      Adm_frecar_tria = (float)admtriagemaestr.adm_frecar_tria,
                                      Adm_freres_tria = (float)admtriagemaestr.adm_freres_tria,
                                      Adm_tasist_tria = (float)admtriagemaestr.adm_tasist_tria,
                                      Adm_tadias_tria = (float)admtriagemaestr.adm_tadias_tria,
                                      Adm_temper_tria = (float)admtriagemaestr.adm_temper_tria,
                                      Adm_pesokg_tria = (float)admtriagemaestr.adm_pesokg_tria,
                                      Adm_tallac_tria = (float)admtriagemaestr.adm_tallac_tria,
                                      Adm_tiplle_tria = admtriagemaestr.adm_tiplle_tria,
                                      Adm_motcon_tria = admtriagemaestr.adm_motcon_tria,
                                      Adm_clasif_tria = admtriagemaestr.adm_clasif_tria,
                                      Adm_remisi_tria = admtriagemaestr.adm_remisi_tria,
                                      Sia_coddia_tdia = admtriagemaestr.sia_coddia_tdia,
                                      Adm_observ_tria = admtriagemaestr.adm_observ_tria,
                                      Sia_codeps_teps = admtriagemaestr.sia_codeps_teps,
                                      Fcm_codcpr_cpro = admtriagemaestr.fcm_codcpr_cpro,
                                      Sis_idemun_muni = admtriagemaestr.sis_idemun_muni,
                                      Sis_codmun_muni = admtriagemaestr.sis_codmun_muni,
                                      Sis_coddep_dpto = admtriagemaestr.sis_coddep_dpto,
                                      Sia_codcat_ceat = admtriagemaestr.sia_codcat_ceat,
                                      Sia_codpfa_prof = admtriagemaestr.sia_codpfa_prof,
                                      Sia_llaveb_usua = admtriagemaestr.sia_llaveb_usua,
                                      Adm_tipreg_tria = admtriagemaestr.adm_tipreg_tria,
                                      Sis_estpro_espr = admtriagemaestr.sis_estpro_espr,
                                      Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                      Sia_descat_ceat = ceat.sia_descat_ceat,
                                      Sia_desdia_tdia = admtriagemaestr.sia_coddia_tdia == "NA" ? "NA" : tdia.sia_desdia_tdia,
                                      Sis_despro_espr = admtriagemaestr.sis_estpro_espr == "1" ? "ABIERTO" : admtriagemaestr.sis_estpro_espr == "2" ? "CONFIRMADO" : "ANULADO",
                                      Sia_deseps_teps = _context.Siatablaeps.FirstOrDefault(rxp => rxp.sia_codeps_teps == admtriagemaestr.sia_codeps_teps).sia_deseps_teps,
                                      Sia_nompro_prof = _context.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == admtriagemaestr.sia_codpfa_prof).sia_nompro_prof,
                                      Sis_nommun_muni = _context.Sistabmunicipio.FirstOrDefault(rxp => rxp.sis_idemun_muni == admtriagemaestr.sis_idemun_muni).sis_nommun_muni,
                                      Sis_desdep_dpto = _context.Sistabdepartame.FirstOrDefault(rxp => rxp.sis_coddep_dpto == admtriagemaestr.sis_coddep_dpto).sis_desdep_dpto,
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region Temporal para reporte Maestro evaluacion triage
        public static List<ADMModeloTriage> flsListaAdmtriagemaestrRpt(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from admtriagemaestr in _context.Admtriagemaestr
                                  join siatipideusario in _context.Siatipideusario on admtriagemaestr.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                  join fcmcenproduccio in _context.Fcmcenproduccio on admtriagemaestr.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                  join siacentroaten in _context.Siacentroaten on admtriagemaestr.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                  join siadiagnosticos in _context.Siadiagnosticos on admtriagemaestr.sia_coddia_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                  join admtriagemaconf in _context.Admtriagemaconf on admtriagemaestr.adm_clasif_tria equals admtriagemaconf.adm_clasif_tria into tmadmtriagemaconf
                                  from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                  from tide in tmsiatipideusario.DefaultIfEmpty()
                                  from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                  from ceat in tmsiacentroaten.DefaultIfEmpty()
                                  from tria in tmadmtriagemaconf.DefaultIfEmpty()
                                  where admtriagemaestr.adm_nroreg_tria == tcrBuscar
                                  select new ADMModeloTriage
                                  {
                                      #region Listar Registros
                                      Adm_nroreg_tria = admtriagemaestr.adm_nroreg_tria,
                                      Sia_idesec_usua = admtriagemaestr.sia_idesec_usua,
                                      Hcl_nrohis_hicl = admtriagemaestr.hcl_nrohis_hicl,
                                      Adm_secadm_rgad = admtriagemaestr.adm_secadm_rgad,
                                      Sia_tipide_tide = admtriagemaestr.sia_tipide_tide,
                                      Sia_nroide_usua = admtriagemaestr.sia_nroide_usua,
                                      Sia_priape_usua = admtriagemaestr.sia_priape_usua,
                                      Sia_segape_usua = admtriagemaestr.sia_segape_usua,
                                      Sia_prinom_usua = admtriagemaestr.sia_prinom_usua,
                                      Sia_segnom_usua = admtriagemaestr.sia_segnom_usua,
                                      Sia_fecnac_usua = (DateTime)admtriagemaestr.sia_fecnac_usua,
                                      Sis_codsex_sexo = admtriagemaestr.sis_codsex_sexo,
                                      Sia_nomusu_usua = admtriagemaestr.sia_nomusu_usua,
                                      Sia_edapac_usua = (int)admtriagemaestr.sia_edapac_usua,
                                      Sia_codmed_tmed = admtriagemaestr.sia_codmed_tmed,
                                      Adm_gesfec_tria = (DateTime)admtriagemaestr.adm_gesfec_tria,
                                      Adm_geshor_tria = (Decimal)admtriagemaestr.adm_geshor_tria,
                                      Adm_frecar_tria = (float)admtriagemaestr.adm_frecar_tria,
                                      Adm_freres_tria = (float)admtriagemaestr.adm_freres_tria,
                                      Adm_tasist_tria = (float)admtriagemaestr.adm_tasist_tria,
                                      Adm_tadias_tria = (float)admtriagemaestr.adm_tadias_tria,
                                      Adm_temper_tria = (float)admtriagemaestr.adm_temper_tria,
                                      Adm_pesokg_tria = (float)admtriagemaestr.adm_pesokg_tria,
                                      Adm_tallac_tria = (float)admtriagemaestr.adm_tallac_tria,
                                      Adm_tiplle_tria = admtriagemaestr.adm_tiplle_tria,
                                      Adm_motcon_tria = admtriagemaestr.adm_motcon_tria,
                                      Adm_clasif_tria = admtriagemaestr.adm_clasif_tria,
                                      Adm_remisi_tria = admtriagemaestr.adm_remisi_tria,
                                      Sia_coddia_tdia = admtriagemaestr.sia_coddia_tdia,
                                      Adm_observ_tria = admtriagemaestr.adm_observ_tria,
                                      Sia_codeps_teps = admtriagemaestr.sia_codeps_teps,
                                      Fcm_codcpr_cpro = admtriagemaestr.fcm_codcpr_cpro,
                                      Sis_idemun_muni = admtriagemaestr.sis_idemun_muni,
                                      Sis_codmun_muni = admtriagemaestr.sis_codmun_muni,
                                      Sis_coddep_dpto = admtriagemaestr.sis_coddep_dpto,
                                      Sia_codcat_ceat = admtriagemaestr.sia_codcat_ceat,
                                      Sia_codpfa_prof = admtriagemaestr.sia_codpfa_prof,
                                      Sia_llaveb_usua = admtriagemaestr.sia_llaveb_usua,
                                      Adm_tipreg_tria = admtriagemaestr.adm_tipreg_tria,
                                      Sis_estpro_espr = admtriagemaestr.sis_estpro_espr,
                                      Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                      Sia_descat_ceat = ceat.sia_descat_ceat,
                                      Adm_descla_adct = tria.adm_descla_adct,
                                      Adm_tiempo_adct = tria.adm_tiempo_adct,
                                      Sia_desdia_tdia = admtriagemaestr.sia_coddia_tdia == "NA" ? "NA" : tdia.sia_desdia_tdia,
                                      Sis_despro_espr = admtriagemaestr.sis_estpro_espr == "1" ? "ABIERTO" : admtriagemaestr.sis_estpro_espr == "2" ? "CONFIRMADO" : "ANULADO",
                                      Sia_deseps_teps = _context.Siatablaeps.FirstOrDefault(rxp => rxp.sia_codeps_teps == admtriagemaestr.sia_codeps_teps).sia_deseps_teps,
                                      Sia_nompro_prof = _context.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == admtriagemaestr.sia_codpfa_prof).sia_nompro_prof,
                                      Sis_nommun_muni = _context.Sistabmunicipio.FirstOrDefault(rxp => rxp.sis_idemun_muni == admtriagemaestr.sis_idemun_muni).sis_nommun_muni,
                                      Sis_desdep_dpto = _context.Sistabdepartame.FirstOrDefault(rxp => rxp.sis_coddep_dpto == admtriagemaestr.sis_coddep_dpto).sis_desdep_dpto,
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Mostrar la vista tree de amisiones en historial del paciente
    /// </summary>
    public class ADMModeloTreeAdmHistorial : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region SecuencialRegistro: Secuencial unico registro
        /// <summary>
        /// Secuencial unico registro
        /// </summary>
        public String SecuencialRegistro { get; set; }
        #endregion
        #region TipoRegistro: Tipo registro: "ADM" = Admision "DAT" = Tipo Fecha
        /// <summary>
        /// Tipo Registro "ADM" = Admision "DAT" = Tipo Fecha
        /// </summary>
        public String TipoRegistro { get; set; }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        /// <summary>
        /// Secuencial de Admisión del paciente
        /// </summary>
        public String Adm_secadm_rgad =String.Empty;
        #endregion
        #region Adm_fecadm_rgad: Fecha Admisión
        /// <summary>
        /// Fecha de la Admisión o del registro de atención ambulatoria
        /// </summary>
        public DateTime Adm_fecadm_rgad = Convert.ToDateTime("01/01/1000");
        #endregion
        #region Adm_horadm_rgad: Hora de Admisión
        /// <summary>
        /// Hora de Admisión o atención ambulatoria en formato militar
        /// </summary>
        public Decimal Adm_horadm_rgad = 0;
        #endregion
        #region Hcl_gesfec_hcev: Fecha servicio para registros tipo fecha
        /// <summary>
        /// Fecha del registro tipo fecha que agrupa eventos de prestacion servicio en la admision
        /// </summary>
        public DateTime Hcl_gesfec_hcev = Convert.ToDateTime("01/01/1000");
        #endregion
        #region Sia_coddia_tdia: Diagnostico consulta
        /// <summary>
        /// SIA_REGATE_RGAT = 2 (solo para registro atencion ambulatoria) Diagnostico según CIE-10
        /// </summary>
        public String Sia_coddia_tdia = String.Empty;
        #endregion
        #region Sia_desdia_tdia: Descripcion diagnostico
        /// <summary>
        ///Descripcion del diagnostico
        /// </summary>
        public String Sia_desdia_tdia = String.Empty;
        #endregion
        #region Adm_finate_rgad: Finalizar atención
        /// <summary>
        /// <para>Finalizar atencion 1= Atencion medica activa (se muestra en vista admitidos)</para>
        /// <para>2=Finalizada Atencion (desaparece de vista admitidos)</para>
        /// </summary>
        public String Adm_finate_rgad = String.Empty;
        #endregion
        #region Adm_caucon_rgad: Causa textual de Consulta
        /// <summary>
        ///Causa Textual de Consulta
        /// </summary>
        public String Adm_caucon_rgad = String.Empty;
        #endregion
        #region Sia_codare_aser: Código Área de servicios
        /// <summary>
        /// Código área prestacion de servicio 
        /// </summary>
        public String Sia_codare_aser = String.Empty;
        #endregion
        #region Sia_desare_aser: Nombre área de servicios
        /// <summary>
        ///Descripción área de prestación servicios médicos
        /// </summary>
        public String Sia_desare_aser = String.Empty;
        #endregion
        #region Fcm_codcpr_cpro: Codigo Centro producción
        /// <summary>
        ///Codigo del centro de producción generado por el sistema
        /// </summary>
        public String Fcm_codcpr_cpro  = String.Empty;
        #endregion
        #region Fcm_descpr_cpro: Nombre centro producción
        /// <summary>
        /// Nombre centro de produccion en prestacion de servicios medicos
        /// </summary>
        public String Fcm_descpr_cpro = String.Empty;
        #endregion
        #region Sis_estpro_espr: Estado Admisión
        /// <summary>
        /// Estado de la Admisión o atención ambulatoria  1=Abierta 2=Cerrada 3=Anulada
        /// </summary>
        public String Sis_estpro_espr = String.Empty;
        #endregion
        #region RefObjAdm: Referencia objeto instancia Admision
        /// <summary>
        /// Referencia objeto instancia Admision
        /// </summary>
        public FrameworkElement RefObjAdm { get; set; }
        #endregion
        #region RefObjFecha: Referencia objeto instancia Fechas en Admision
        /// <summary>
        /// Referencia objeto instancia Admision
        /// </summary>
        public FrameworkElement RefObjFecha { get; set; }
        #endregion
        #region GestionEstadoRegistro: Estado del registro en vista historial
        /// <summary>
        /// Estado del registro en vista: "XX" = Lista detalles no cargando en vista "OK" = Todo cargado en vista historial
        /// </summary>
        public String GestionEstadoRegistro { get; set; }
        #endregion
        #region RegistroVisible: Registro visible en vista historial
        /// <summary>
        ///Regisro visible en vista: "1" = Visible "2" = No esta visible
        /// </summary>
        public String RegistroVisible { get; set; }
        #endregion
        #endregion
        #region Listar Registros con relaciones tabla admision
        /// <summary>
        /// Retorna lista de registros admision para generar vista navegacion historial medico
        /// </summary>
        public static List<ADMModeloTreeAdmHistorial> flsListaHistorialAdmisiones(String tcrIdUnicoEnSistema)
        {
            using (_context = new DbAplicacion())
            {
                #region Consulta
                var lobConsulta = from admregadmision in _context.Admregadmision
                                  join siaareapreservi in _context.Siaareapreservi on admregadmision.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                  join siadiagnosticos in _context.Siadiagnosticos on admregadmision.sia_dixing_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                  from aser in tmsiaareapreservi.DefaultIfEmpty()
                                  from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                  where admregadmision.sia_idesec_usua.Equals(tcrIdUnicoEnSistema)
                                  orderby admregadmision.adm_fecadm_rgad descending
                                  select new ADMModeloTreeAdmHistorial
                                  {
                                      #region Datos
                                      Adm_secadm_rgad = admregadmision.adm_secadm_rgad,
                                      Adm_fecadm_rgad = (DateTime)admregadmision.adm_fecadm_rgad,
                                      Adm_horadm_rgad = (Decimal)admregadmision.adm_horadm_rgad,
                                      Hcl_gesfec_hcev = (DateTime)admregadmision.adm_fecadm_rgad,
                                      Sia_codare_aser = admregadmision.sia_codare_aser,
                                      Fcm_codcpr_cpro = admregadmision.fcm_codcpr_cpro,
                                      Adm_caucon_rgad = admregadmision.adm_caucon_rgad,
                                      Adm_finate_rgad = admregadmision.adm_finate_rgad,
                                      Sia_coddia_tdia = admregadmision.sia_coddia_tdia,
                                      Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                      Sia_desare_aser = aser.sia_desare_aser,
                                      Sia_desdia_tdia = tdia.sia_desdia_tdia,
                                      SecuencialRegistro    = admregadmision.adm_secadm_rgad,
                                      TipoRegistro          = "ADM",
                                      RegistroVisible       = "1",
                                      GestionEstadoRegistro = "XX",
                                      #endregion
                                  };
                return lobConsulta.ToList();
                #endregion
            }
        }
        #endregion
    }
}
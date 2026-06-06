//- MARMOTA-GENCODE: VERSION 2.0 - 03/07/2013 02:57:45 AM
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

namespace Hospitalizacion.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admregistegreso
    /// </summary>
    public class ModeloRegistroSalida : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _adm_secegr_regr;
        private String _adm_secadm_rgad;
        private String _sia_idesec_usua;
        private String _sia_tipide_tide;
        private String _sia_nroide_usua;
        private String _hcl_nrohis_hicl;
        private DateTime _adm_fecegr_regr;
        private Decimal _adm_horegr_regr;
        private String _adm_secaut_aegr;
        private String _sia_codpfa_prof;
        private String _desia_dixing_tdia;
        private String _sia_dixing_tdia;
        private String _sia_dixsal_tdia;
        private String _sia_tipdxp_tdix;
        private String _desia_dixre1_tdia;
        private String _sia_dixre1_tdia;
        private String _desia_dixre2_tdia;
        private String _sia_dixre2_tdia;
        private String _desia_dixre3_tdia;
        private String _sia_dixre3_tdia;
        private String _desia_dixcom_tdia;
        private String _sia_dixcom_tdia;
        private String _adm_estsal_regr;
        private String _adm_dessal_regr;
        private String _sia_tipdis_tdis;
        private String _adm_tipmue_regr;
        private String _desia_dixmue_tdia;
        private String _sia_dixmue_tdia;
        private DateTime _adm_fecmue_regr;
        private Decimal _adm_hormue_regr;
        private int _adm_diases_regr;
        private int _adm_horase_regr;
        private String _adm_aparto_regr;
        private String _adm_tippar_regr;
        private String _adm_actpar_regr;
        private int _adm_semges_regr;
        private DateTime _adm_fecpar_regr;
        private String _adm_contrl_regr;
        private int _adm_conest_regr;
        private String _adm_observ_regr;
        private String _sis_estpro_espr;
        private String _sia_nomusu_usua;
        private String _sia_deside_tide;
        private String _sia_nompro_prof;
        private String _sia_desdia_tdia;
        private String _sia_desdxp_tdix;
        private String _sia_desdis_tdis;
        private String _sis_despro_espr;
        private DateTime _sia_fecnac_usua;
        private String _sis_codsex_sexo;
        private String _sia_edaymd_usua;
        private String _sis_coddep_dpto;
        private String _sis_codmun_muni;
        private DateTime _adm_fecadm_rgad;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Adm_secegr_regr: Secuencial egreso
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Secuencial egreso</para>
        /// <para>NOMBRE: adm_secegr_regr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial registro de egreso
        /// </para>
        /// </summary>
        public String Adm_secegr_regr
        {
            get { return _adm_secegr_regr; }
            set
            {
                if (_adm_secegr_regr == value) return;
                _adm_secegr_regr = value;
                OnPropertyChanged("Adm_secegr_regr");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        #region Sia_idesec_usua: Codigo unico del paciente
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Codigo unico del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Unico de paciente en el sistema
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
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de d atos ejm: CC= Cedula,otros
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
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
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
        #region Hcl_nrohis_hicl: Numero historia clinica
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Numero historia clinica</para>
        /// <para>NOMBRE: hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Numero o codigo de la Ficha de Historias Clinicas
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
        #region Adm_fecegr_regr: Fecha de salida
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Fecha de salida</para>
        /// <para>NOMBRE: adm_fecegr_regr (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Fecha de egreso del servicio de hospitalizacion u Observacion
        /// en urgencia
        /// </para>
        /// </summary>
        public DateTime Adm_fecegr_regr
        {
            get { return _adm_fecegr_regr; }
            set
            {
                if (_adm_fecegr_regr == value) return;
                _adm_fecegr_regr = value;
                OnPropertyChanged("Adm_fecegr_regr");
            }
        }
        #endregion
        #region Adm_horegr_regr: Hora de salida
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Hora de salida</para>
        /// <para>NOMBRE: adm_horegr_regr (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Hora  egreso en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Adm_horegr_regr
        {
            get { return _adm_horegr_regr; }
            set
            {
                if (_adm_horegr_regr == value) return;
                _adm_horegr_regr = value;
                OnPropertyChanged("Adm_horegr_regr");
            }
        }
        #endregion
        #region Adm_secaut_aegr: Autorización salida
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Autorización salida</para>
        /// <para>NOMBRE: adm_secaut_aegr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Numero Secuencial Autorizacion de egreso paciente
        /// </para>
        /// </summary>
        public String Adm_secaut_aegr
        {
            get { return _adm_secaut_aegr; }
            set
            {
                if (_adm_secaut_aegr == value) return;
                _adm_secaut_aegr = value;
                OnPropertyChanged("Adm_secaut_aegr");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Codigo Profesional Autoriza
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Codigo Profesional Autoriza</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo Profesional Que Autoriza egreso o presta servicio ambulatorio
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
        #region Desia_dixing_tdia: Descripcion diagnostico
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixing_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixing_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_dixing_tdia
        {
            get { return _desia_dixing_tdia; }
            set
            {
                if (_desia_dixing_tdia == value) return;
                _desia_dixing_tdia = value;
                OnPropertyChanged("Desia_dixing_tdia");
            }
        }
        #endregion
        #region Sia_dixing_tdia: Diagnostico Ingreso
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico Ingreso</para>
        /// <para>NOMBRE: sia_dixing_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de Ingreso a hospitalizacion/Urgencias con Observacion
        /// (si no se digito en admision) según CIE-10
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
        #region Sia_dixsal_tdia: Diagnostico salida
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico salida</para>
        /// <para>NOMBRE: sia_dixsal_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de salida de hospitalizacion/Urgencias con Observacion
        /// según CIE-10
        /// </para>
        /// </summary>
        public String Sia_dixsal_tdia
        {
            get { return _sia_dixsal_tdia; }
            set
            {
                if (_sia_dixsal_tdia == value) return;
                _sia_dixsal_tdia = value;
                OnPropertyChanged("Sia_dixsal_tdia");
            }
        }
        #endregion
        #region Sia_tipdxp_tdix: Tipo diagnostico principal
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: sia_tipdxp_tdix (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Tipo de diagnostico principal
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
        #region Desia_dixre1_tdia: Descripcion diagnostico
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixre1_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        #region Sia_dixre1_tdia: Diagnostico relacionado1
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado1</para>
        /// <para>NOMBRE: sia_dixre1_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        #region Desia_dixre2_tdia: Descripcion diagnostico
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixre2_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
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
        #region Sia_dixre2_tdia: Diagnostico relacionado2
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado2</para>
        /// <para>NOMBRE: sia_dixre2_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
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
        #region Desia_dixre3_tdia: Descripcion diagnostico
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixre3_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
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
        #region Sia_dixre3_tdia: Diagnostico relacionado3
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado3</para>
        /// <para>NOMBRE: sia_dixre3_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
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
        #region Desia_dixcom_tdia: Descripcion diagnostico
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixcom_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixcom_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_dixcom_tdia
        {
            get { return _desia_dixcom_tdia; }
            set
            {
                if (_desia_dixcom_tdia == value) return;
                _desia_dixcom_tdia = value;
                OnPropertyChanged("Desia_dixcom_tdia");
            }
        }
        #endregion
        #region Sia_dixcom_tdia: Diagnostico complicación
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico complicación</para>
        /// <para>NOMBRE: sia_dixcom_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de la complicacion cuando exista según CIE-10
        /// </para>
        /// </summary>
        public String Sia_dixcom_tdia
        {
            get { return _sia_dixcom_tdia; }
            set
            {
                if (_sia_dixcom_tdia == value) return;
                _sia_dixcom_tdia = value;
                OnPropertyChanged("Sia_dixcom_tdia");
            }
        }
        #endregion
        #region Adm_estsal_regr: Estado al salir
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Estado al salir</para>
        /// <para>NOMBRE: adm_estsal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado al salir: 1=Vivo 2= Muerto
        /// </para>
        /// </summary>
        public String Adm_estsal_regr
        {
            get { return _adm_estsal_regr; }
            set
            {
                if (_adm_estsal_regr == value) return;
                _adm_estsal_regr = value;
                OnPropertyChanged("Adm_estsal_regr");
            }
        }
        #endregion
        #region Adm_dessal_regr: Destino al salir
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: adm_dessal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Destino al salir: 1=Alta (salida) 2= Remision a otro nivel
        /// 3 = Hospitalizacion
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
        #region Sia_tipdis_tdis: Discapacidad postenfermedad
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siatipdiscapaci</para>
        /// <para>CAMPO: Discapacidad postenfermedad</para>
        /// <para>NOMBRE: sia_tipdis_tdis (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Tipo de Discapacidad postenfermedad al momento de la salida
        /// cuando aplique ejm: 1=Visual, 2=Motriz y mas
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
        #region Adm_tipmue_regr: Muerte intrahospitalaria
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Muerte intrahospitalaria</para>
        /// <para>NOMBRE: adm_tipmue_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Muerte intrahospitalaria de pacientes admitidos: 1=En las primeras
        /// 48 horas 2= Despues de 48 horas
        /// </para>
        /// </summary>
        public String Adm_tipmue_regr
        {
            get { return _adm_tipmue_regr; }
            set
            {
                if (_adm_tipmue_regr == value) return;
                _adm_tipmue_regr = value;
                OnPropertyChanged("Adm_tipmue_regr");
            }
        }
        #endregion
        #region Desia_dixmue_tdia: Descripcion diagnostico
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixmue_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixmue_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_dixmue_tdia
        {
            get { return _desia_dixmue_tdia; }
            set
            {
                if (_desia_dixmue_tdia == value) return;
                _desia_dixmue_tdia = value;
                OnPropertyChanged("Desia_dixmue_tdia");
            }
        }
        #endregion
        #region Sia_dixmue_tdia: Diagnostico de muerte
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico de muerte</para>
        /// <para>NOMBRE: sia_dixmue_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de causa muerte cuando exista según CIE-10
        /// </para>
        /// </summary>
        public String Sia_dixmue_tdia
        {
            get { return _sia_dixmue_tdia; }
            set
            {
                if (_sia_dixmue_tdia == value) return;
                _sia_dixmue_tdia = value;
                OnPropertyChanged("Sia_dixmue_tdia");
            }
        }
        #endregion
        #region Adm_fecmue_regr: Fecha muerte
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Fecha muerte</para>
        /// <para>NOMBRE: adm_fecmue_regr (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Fecha muerte dentro del servicio de hospitalizacion u Observacion
        /// en urgencia
        /// </para>
        /// </summary>
        public DateTime Adm_fecmue_regr
        {
            get { return _adm_fecmue_regr; }
            set
            {
                if (_adm_fecmue_regr == value) return;
                _adm_fecmue_regr = value;
                OnPropertyChanged("Adm_fecmue_regr");
            }
        }
        #endregion
        #region Adm_hormue_regr: Hora de muerte
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Hora de muerte</para>
        /// <para>NOMBRE: adm_hormue_regr (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Hora  muerte en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Adm_hormue_regr
        {
            get { return _adm_hormue_regr; }
            set
            {
                if (_adm_hormue_regr == value) return;
                _adm_hormue_regr = value;
                OnPropertyChanged("Adm_hormue_regr");
            }
        }
        #endregion
        #region Adm_diases_regr: Dias de estancia
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Dias de estancia</para>
        /// <para>NOMBRE: adm_diases_regr (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Numero dias de estancia en la IPS
        /// </para>
        /// </summary>
        public int Adm_diases_regr
        {
            get { return _adm_diases_regr; }
            set
            {
                if (_adm_diases_regr == value) return;
                _adm_diases_regr = value;
                OnPropertyChanged("Adm_diases_regr");
            }
        }
        #endregion
        #region Adm_horase_regr: Horas de estancia
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Horas de estancia</para>
        /// <para>NOMBRE: adm_horase_regr (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Numero hora total  en estancia en la IPS
        /// </para>
        /// </summary>
        public int Adm_horase_regr
        {
            get { return _adm_horase_regr; }
            set
            {
                if (_adm_horase_regr == value) return;
                _adm_horase_regr = value;
                OnPropertyChanged("Adm_horase_regr");
            }
        }
        #endregion
        #region Adm_aparto_regr: Atención del parto (SI/NO)
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Atención del parto (SI/NO)</para>
        /// <para>NOMBRE: adm_aparto_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Hubo atencion del parto : 1=SI 2=NO
        /// </para>
        /// </summary>
        public String Adm_aparto_regr
        {
            get { return _adm_aparto_regr; }
            set
            {
                if (_adm_aparto_regr == value) return;
                _adm_aparto_regr = value;
                OnPropertyChanged("Adm_aparto_regr");
            }
        }
        #endregion
        #region Adm_tippar_regr: Parto o Aborto
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Parto o Aborto</para>
        /// <para>NOMBRE: adm_tippar_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Tipo atencion del parto : 1=Parto 2=Aborto
        /// </para>
        /// </summary>
        public String Adm_tippar_regr
        {
            get { return _adm_tippar_regr; }
            set
            {
                if (_adm_tippar_regr == value) return;
                _adm_tippar_regr = value;
                OnPropertyChanged("Adm_tippar_regr");
            }
        }
        #endregion
        #region Adm_actpar_regr: Tipo asistencia parto
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Tipo asistencia parto</para>
        /// <para>NOMBRE: adm_actpar_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Tipo acto asistencia del parto : 1=Asistencia parto  normal
        /// 2=Parto quirugico (cesarea)
        /// </para>
        /// </summary>
        public String Adm_actpar_regr
        {
            get { return _adm_actpar_regr; }
            set
            {
                if (_adm_actpar_regr == value) return;
                _adm_actpar_regr = value;
                OnPropertyChanged("Adm_actpar_regr");
            }
        }
        #endregion
        #region Adm_semges_regr: Semanas gestación
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Semanas gestación</para>
        /// <para>NOMBRE: adm_semges_regr (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Numero semanas de gestación
        /// </para>
        /// </summary>
        public int Adm_semges_regr
        {
            get { return _adm_semges_regr; }
            set
            {
                if (_adm_semges_regr == value) return;
                _adm_semges_regr = value;
                OnPropertyChanged("Adm_semges_regr");
            }
        }
        #endregion
        #region Adm_fecpar_regr: Fecha parto
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Fecha parto</para>
        /// <para>NOMBRE: adm_fecpar_regr (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Fecha en que se realizo la atencion del parto
        /// </para>
        /// </summary>
        public DateTime Adm_fecpar_regr
        {
            get { return _adm_fecpar_regr; }
            set
            {
                if (_adm_fecpar_regr == value) return;
                _adm_fecpar_regr = value;
                OnPropertyChanged("Adm_fecpar_regr");
            }
        }
        #endregion
        #region Adm_contrl_regr: Control prenatal
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Control prenatal</para>
        /// <para>NOMBRE: adm_contrl_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///se realizo control penatal 1=SI,2=No
        /// </para>
        /// </summary>
        public String Adm_contrl_regr
        {
            get { return _adm_contrl_regr; }
            set
            {
                if (_adm_contrl_regr == value) return;
                _adm_contrl_regr = value;
                OnPropertyChanged("Adm_contrl_regr");
            }
        }
        #endregion
        #region Adm_conest_regr: Contador registro nacimientos
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Contador registro nacimientos</para>
        /// <para>NOMBRE: adm_conest_regr (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los registros unicos de la tabla de nacimientos
        /// </para>
        /// </summary>
        public int Adm_conest_regr
        {
            get { return _adm_conest_regr; }
            set
            {
                if (_adm_conest_regr == value) return;
                _adm_conest_regr = value;
                OnPropertyChanged("Adm_conest_regr");
            }
        }
        #endregion
        #region Adm_observ_regr: Nota egreso
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Nota egreso</para>
        /// <para>NOMBRE: adm_observ_regr (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Nota u observación del egreso
        /// </para>
        /// </summary>
        public String Adm_observ_regr
        {
            get { return _adm_observ_regr; }
            set
            {
                if (_adm_observ_regr == value) return;
                _adm_observ_regr = value;
                OnPropertyChanged("Adm_observ_regr");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Egreso
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Egreso</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Estado del registro de egreso para admitidos   1=Abierta 2=Cerrada
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
        #region Sia_nomusu_usua: Nombre paciente
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        #region Sia_deside_tide: Descripción Tipo Usuario
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        #region Sia_nompro_prof: Nombre del Profesional
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        #region Sia_desdia_tdia: Descripcion diagnostico
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        #region Sia_desdis_tdis: Descripción discapacidad
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        #region Sia_fecnac_usua:
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_fecnac_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region Sis_codsex_sexo:
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sis_codsex_sexo (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region Sia_edaymd_usua:
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_edaymd_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region Sis_coddep_dpto:
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sis_coddep_dpto (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region Sis_codmun_muni:
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sis_codmun_muni (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region Adm_fecadm_rgad:
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: adm_fecadm_rgad (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region Adm_codtat_tatn: Tipo de Atención
        private String _adm_codtat_tatn;
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
        #region Adm_horadm_rgad: Hora de Admisión
        private Decimal _adm_horadm_rgad;
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
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
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
        #region Hos_codcam_caho: Cama actual 
        private String _hos_codcam_caho;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Cama actual</para>
        /// <para>NOMBRE: hos_codcam_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo cama asignada o actual del paciente
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloRegistroSalida tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("ADM-SECEGR-PACIENTES", "ADM", "Secuencial Unico para egreso pacientes");
            if (!flgBuscarAdmregistegreso(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFadmregistegreso
                    {
                        #region cargar Registro
                        adm_secegr_regr = tobjModelo.Adm_secegr_regr,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl,
                        adm_fecegr_regr = tobjModelo.Adm_fecegr_regr,
                        adm_horegr_regr = tobjModelo.Adm_horegr_regr,
                        adm_secaut_aegr = tobjModelo.Adm_secaut_aegr,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        sia_dixing_tdia = tobjModelo.Sia_dixing_tdia,
                        sia_dixsal_tdia = tobjModelo.Sia_dixsal_tdia,
                        sia_tipdxp_tdix = tobjModelo.Sia_tipdxp_tdix,
                        sia_dixre1_tdia = tobjModelo.Sia_dixre1_tdia,
                        sia_dixre2_tdia = tobjModelo.Sia_dixre2_tdia,
                        sia_dixre3_tdia = tobjModelo.Sia_dixre3_tdia,
                        sia_dixcom_tdia = tobjModelo.Sia_dixcom_tdia,
                        adm_estsal_regr = tobjModelo.Adm_estsal_regr,
                        adm_dessal_regr = tobjModelo.Adm_dessal_regr,
                        sia_tipdis_tdis = tobjModelo.Sia_tipdis_tdis,
                        adm_tipmue_regr = tobjModelo.Adm_tipmue_regr,
                        sia_dixmue_tdia = tobjModelo.Sia_dixmue_tdia,
                        adm_fecmue_regr = tobjModelo.Adm_fecmue_regr,
                        adm_hormue_regr = tobjModelo.Adm_hormue_regr,
                        adm_diases_regr = tobjModelo.Adm_diases_regr,
                        adm_horase_regr = tobjModelo.Adm_horase_regr,
                        adm_aparto_regr = tobjModelo.Adm_aparto_regr,
                        adm_tippar_regr = tobjModelo.Adm_tippar_regr,
                        adm_actpar_regr = tobjModelo.Adm_actpar_regr,
                        adm_semges_regr = tobjModelo.Adm_semges_regr,
                        adm_fecpar_regr = tobjModelo.Adm_fecpar_regr,
                        adm_contrl_regr = tobjModelo.Adm_contrl_regr,
                        adm_conest_regr = tobjModelo.Adm_conest_regr,
                        adm_observ_regr = tobjModelo.Adm_observ_regr,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        adm_codtat_tatn = tobjModelo.Adm_codtat_tatn,
                        #endregion
                    };
                    lobjRegistro.adm_secegr_regr = lcrCodigoGen;
                    _context.AddToAdmregistegreso(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'ADM-SECEGR-PACIENTES': Secuencial Unico para egreso pacientes en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloRegistroSalida tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregistegreso.FirstOrDefault(p => p.adm_secegr_regr == tobjModelo.Adm_secegr_regr);
                if (lobjRegistro != null)
                {
                    lobjRegistro.adm_secegr_regr = tobjModelo.Adm_secegr_regr;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl;
                    lobjRegistro.adm_fecegr_regr = (DateTime)tobjModelo.Adm_fecegr_regr;
                    lobjRegistro.adm_horegr_regr = (Decimal)tobjModelo.Adm_horegr_regr;
                    lobjRegistro.adm_secaut_aegr = tobjModelo.Adm_secaut_aegr;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.sia_dixing_tdia = tobjModelo.Sia_dixing_tdia;
                    lobjRegistro.sia_dixsal_tdia = tobjModelo.Sia_dixsal_tdia;
                    lobjRegistro.sia_tipdxp_tdix = tobjModelo.Sia_tipdxp_tdix;
                    lobjRegistro.sia_dixre1_tdia = tobjModelo.Sia_dixre1_tdia;
                    lobjRegistro.sia_dixre2_tdia = tobjModelo.Sia_dixre2_tdia;
                    lobjRegistro.sia_dixre3_tdia = tobjModelo.Sia_dixre3_tdia;
                    lobjRegistro.sia_dixcom_tdia = tobjModelo.Sia_dixcom_tdia;
                    lobjRegistro.adm_estsal_regr = tobjModelo.Adm_estsal_regr;
                    lobjRegistro.adm_dessal_regr = tobjModelo.Adm_dessal_regr;
                    lobjRegistro.sia_tipdis_tdis = tobjModelo.Sia_tipdis_tdis;
                    lobjRegistro.adm_tipmue_regr = tobjModelo.Adm_tipmue_regr;
                    lobjRegistro.sia_dixmue_tdia = tobjModelo.Sia_dixmue_tdia;
                    lobjRegistro.adm_fecmue_regr = (DateTime)tobjModelo.Adm_fecmue_regr;
                    lobjRegistro.adm_hormue_regr = (Decimal)tobjModelo.Adm_hormue_regr;
                    lobjRegistro.adm_diases_regr = (int)tobjModelo.Adm_diases_regr;
                    lobjRegistro.adm_horase_regr = (int)tobjModelo.Adm_horase_regr;
                    lobjRegistro.adm_aparto_regr = tobjModelo.Adm_aparto_regr;
                    lobjRegistro.adm_tippar_regr = tobjModelo.Adm_tippar_regr;
                    lobjRegistro.adm_actpar_regr = tobjModelo.Adm_actpar_regr;
                    lobjRegistro.adm_semges_regr = (int)tobjModelo.Adm_semges_regr;
                    lobjRegistro.adm_fecpar_regr = (DateTime)tobjModelo.Adm_fecpar_regr;
                    lobjRegistro.adm_contrl_regr = tobjModelo.Adm_contrl_regr;
                    lobjRegistro.adm_conest_regr = (int)tobjModelo.Adm_conest_regr;
                    lobjRegistro.adm_observ_regr = tobjModelo.Adm_observ_regr;
                    lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                    lobjRegistro.adm_codtat_tatn = tobjModelo.Adm_codtat_tatn;

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
                var lobjRegistro = _context.Admregistegreso.FirstOrDefault(p => p.adm_secegr_regr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar ADMREGISTEGRESO: Logica
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TITULO: Maestro registro egresos de hospitalizacion</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro egresos de hospitalizacion, se diligencia
        /// al momento de confirmada la Autorizacion de salida del paciente
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmregistegreso(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregistegreso.FirstOrDefault(p => p.adm_secegr_regr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloRegistroSalida> flsListaAdmregistegreso(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from admregistegreso in _context.Admregistegreso
                                      join admregadmision in _context.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join siausuarioatend in _context.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatipideusario in _context.Siatipideusario on admregistegreso.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                      join admordendsalida in _context.Admordendsalida on admregistegreso.adm_secaut_aegr equals admordendsalida.adm_secaut_aegr into tmadmordendsalida
                                      join siamaeprofsalud in _context.Siamaeprofsalud on admregistegreso.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from tide in tmsiatipideusario.DefaultIfEmpty()
                                      from aegr in tmadmordendsalida.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      select new ModeloRegistroSalida
                                      {
                                          Adm_secegr_regr = admregistegreso.adm_secegr_regr,
                                          Adm_secadm_rgad = admregistegreso.adm_secadm_rgad,
                                          Sia_idesec_usua = admregistegreso.sia_idesec_usua,
                                          Sia_tipide_tide = admregistegreso.sia_tipide_tide,
                                          Sia_nroide_usua = admregistegreso.sia_nroide_usua,
                                          Hcl_nrohis_hicl = admregistegreso.hcl_nrohis_hicl,
                                          Adm_fecegr_regr = (DateTime)admregistegreso.adm_fecegr_regr,
                                          Adm_horegr_regr = (Decimal)admregistegreso.adm_horegr_regr,
                                          Adm_secaut_aegr = admregistegreso.adm_secaut_aegr,
                                          Sia_codpfa_prof = admregistegreso.sia_codpfa_prof,
                                          Sia_dixing_tdia = admregistegreso.sia_dixing_tdia,
                                          Desia_dixing_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixing_tdia).sia_desdia_tdia,
                                          Sia_dixsal_tdia = admregistegreso.sia_dixsal_tdia,
                                          Sia_tipdxp_tdix = admregistegreso.sia_tipdxp_tdix,
                                          Sia_dixre1_tdia = admregistegreso.sia_dixre1_tdia,
                                          Desia_dixre1_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixre1_tdia).sia_desdia_tdia,
                                          Sia_dixre2_tdia = admregistegreso.sia_dixre2_tdia,
                                          Desia_dixre2_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixre2_tdia).sia_desdia_tdia,
                                          Sia_dixre3_tdia = admregistegreso.sia_dixre3_tdia,
                                          Desia_dixre3_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixre3_tdia).sia_desdia_tdia,
                                          Sia_dixcom_tdia = admregistegreso.sia_dixcom_tdia,
                                          Desia_dixcom_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixcom_tdia).sia_desdia_tdia,
                                          Adm_estsal_regr = admregistegreso.adm_estsal_regr,
                                          Adm_dessal_regr = admregistegreso.adm_dessal_regr,
                                          Sia_tipdis_tdis = admregistegreso.sia_tipdis_tdis,
                                          Adm_tipmue_regr = admregistegreso.adm_tipmue_regr,
                                          Sia_dixmue_tdia = admregistegreso.sia_dixmue_tdia,
                                          Desia_dixmue_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixmue_tdia).sia_desdia_tdia,
                                          Adm_fecmue_regr = (DateTime)admregistegreso.adm_fecmue_regr,
                                          Adm_hormue_regr = (Decimal)admregistegreso.adm_hormue_regr,
                                          Adm_diases_regr = (int)admregistegreso.adm_diases_regr,
                                          Adm_horase_regr = (int)admregistegreso.adm_horase_regr,
                                          Adm_aparto_regr = admregistegreso.adm_aparto_regr,
                                          Adm_tippar_regr = admregistegreso.adm_tippar_regr,
                                          Adm_actpar_regr = admregistegreso.adm_actpar_regr,
                                          Adm_semges_regr = (int)admregistegreso.adm_semges_regr,
                                          Adm_fecpar_regr = (DateTime)admregistegreso.adm_fecpar_regr,
                                          Adm_contrl_regr = admregistegreso.adm_contrl_regr,
                                          Adm_conest_regr = (int)admregistegreso.adm_conest_regr,
                                          Adm_observ_regr = admregistegreso.adm_observ_regr,
                                          Sis_estpro_espr = admregistegreso.sis_estpro_espr,
                                          Adm_fecadm_rgad = (DateTime)rgad.adm_fecadm_rgad,
                                          Sia_edaymd_usua = rgad.sia_edaymd_usua,
                                          Adm_horadm_rgad = (Decimal)rgad.adm_horadm_rgad,
                                          Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                          Cto_seccon_cont = rgad.cto_seccon_cont,
                                          Adm_codtat_tatn = rgad.adm_codtat_tatn,
                                          Hos_codcam_caho = rgad.hos_codcam_caho,
                                          Sis_codsex_sexo = usua.sis_codsex_sexo,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sis_codmun_muni = usua.sis_codmun_muni,
                                          Sis_coddep_dpto = usua.sis_coddep_dpto,
                                          Sia_deside_tide = tide.sia_deside_tide,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sia_desdia_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixsal_tdia).sia_desdia_tdia,
                                          Sia_desdxp_tdix = _context.Siatipodiagprin.FirstOrDefault(rxp => rxp.sia_tipdxp_tdix == admregistegreso.sia_tipdxp_tdix).sia_desdxp_tdix,
                                          Sia_desdis_tdis = _context.Siatipdiscapaci.FirstOrDefault(rxp => rxp.sia_tipdis_tdis == admregistegreso.sia_tipdis_tdis).sia_desdis_tdis,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregistegreso.sis_estpro_espr).sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from admregistegreso in _context.Admregistegreso
                                      join admregadmision in _context.Admregadmision on admregistegreso.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                      join siausuarioatend in _context.Siausuarioatend on admregistegreso.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatipideusario in _context.Siatipideusario on admregistegreso.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                      join admordendsalida in _context.Admordendsalida on admregistegreso.adm_secaut_aegr equals admordendsalida.adm_secaut_aegr into tmadmordendsalida
                                      join siamaeprofsalud in _context.Siamaeprofsalud on admregistegreso.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from rgad in tmadmregadmision.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from tide in tmsiatipideusario.DefaultIfEmpty()
                                      from aegr in tmadmordendsalida.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      where admregistegreso.adm_secegr_regr == tcrBuscar
                                      select new ModeloRegistroSalida
                                      {
                                          Adm_secegr_regr = admregistegreso.adm_secegr_regr,
                                          Adm_secadm_rgad = admregistegreso.adm_secadm_rgad,
                                          Sia_idesec_usua = admregistegreso.sia_idesec_usua,
                                          Sia_tipide_tide = admregistegreso.sia_tipide_tide,
                                          Sia_nroide_usua = admregistegreso.sia_nroide_usua,
                                          Hcl_nrohis_hicl = admregistegreso.hcl_nrohis_hicl,
                                          Adm_fecegr_regr = (DateTime)admregistegreso.adm_fecegr_regr,
                                          Adm_horegr_regr = (Decimal)admregistegreso.adm_horegr_regr,
                                          Adm_secaut_aegr = admregistegreso.adm_secaut_aegr,
                                          Sia_codpfa_prof = admregistegreso.sia_codpfa_prof,
                                          Sia_dixing_tdia = admregistegreso.sia_dixing_tdia,
                                          Desia_dixing_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixing_tdia).sia_desdia_tdia,
                                          Sia_dixsal_tdia = admregistegreso.sia_dixsal_tdia,
                                          Sia_tipdxp_tdix = admregistegreso.sia_tipdxp_tdix,
                                          Sia_dixre1_tdia = admregistegreso.sia_dixre1_tdia,
                                          Desia_dixre1_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixre1_tdia).sia_desdia_tdia,
                                          Sia_dixre2_tdia = admregistegreso.sia_dixre2_tdia,
                                          Desia_dixre2_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixre2_tdia).sia_desdia_tdia,
                                          Sia_dixre3_tdia = admregistegreso.sia_dixre3_tdia,
                                          Desia_dixre3_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixre3_tdia).sia_desdia_tdia,
                                          Sia_dixcom_tdia = admregistegreso.sia_dixcom_tdia,
                                          Desia_dixcom_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixcom_tdia).sia_desdia_tdia,
                                          Adm_estsal_regr = admregistegreso.adm_estsal_regr,
                                          Adm_dessal_regr = admregistegreso.adm_dessal_regr,
                                          Sia_tipdis_tdis = admregistegreso.sia_tipdis_tdis,
                                          Adm_tipmue_regr = admregistegreso.adm_tipmue_regr,
                                          Sia_dixmue_tdia = admregistegreso.sia_dixmue_tdia,
                                          Desia_dixmue_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixmue_tdia).sia_desdia_tdia,
                                          Adm_fecmue_regr = (DateTime)admregistegreso.adm_fecmue_regr,
                                          Adm_hormue_regr = (Decimal)admregistegreso.adm_hormue_regr,
                                          Adm_diases_regr = (int)admregistegreso.adm_diases_regr,
                                          Adm_horase_regr = (int)admregistegreso.adm_horase_regr,
                                          Adm_aparto_regr = admregistegreso.adm_aparto_regr,
                                          Adm_tippar_regr = admregistegreso.adm_tippar_regr,
                                          Adm_actpar_regr = admregistegreso.adm_actpar_regr,
                                          Adm_semges_regr = (int)admregistegreso.adm_semges_regr,
                                          Adm_fecpar_regr = (DateTime)admregistegreso.adm_fecpar_regr,
                                          Adm_contrl_regr = admregistegreso.adm_contrl_regr,
                                          Adm_conest_regr = (int)admregistegreso.adm_conest_regr,
                                          Adm_observ_regr = admregistegreso.adm_observ_regr,
                                          Sis_estpro_espr = admregistegreso.sis_estpro_espr,
                                          Adm_fecadm_rgad = (DateTime)rgad.adm_fecadm_rgad,
                                          Sia_edaymd_usua = rgad.sia_edaymd_usua,
                                          Adm_horadm_rgad = (Decimal)rgad.adm_horadm_rgad,
                                          Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                          Cto_seccon_cont = rgad.cto_seccon_cont,
                                          Adm_codtat_tatn = rgad.adm_codtat_tatn,
                                          Hos_codcam_caho = rgad.hos_codcam_caho,
                                          Sis_codsex_sexo = usua.sis_codsex_sexo,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sis_codmun_muni = usua.sis_codmun_muni,
                                          Sis_coddep_dpto = usua.sis_coddep_dpto,
                                          Sia_deside_tide = tide.sia_deside_tide,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sia_desdia_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregistegreso.sia_dixsal_tdia).sia_desdia_tdia,
                                          Sia_desdxp_tdix = _context.Siatipodiagprin.FirstOrDefault(rxp => rxp.sia_tipdxp_tdix == admregistegreso.sia_tipdxp_tdix).sia_desdxp_tdix,
                                          Sia_desdis_tdis = _context.Siatipdiscapaci.FirstOrDefault(rxp => rxp.sia_tipdis_tdis == admregistegreso.sia_tipdis_tdis).sia_desdis_tdis,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregistegreso.sis_estpro_espr).sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admregnacimient
    /// </summary>
    public class ModeloRegnacimiento : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _adm_secegr_regn;
        private String _adm_secegr_regr;
        private String _adm_secadm_rgad;
        private String _sia_idesec_usua;
        private String _sia_tipide_tide;
        private String _sia_nroide_usua;
        private DateTime _adm_fecnac_regn;
        private String _sis_codsex_sexo;
        private Decimal _adm_hornac_regn;
        private int _adm_peson_regn;
        private int _adm_tallan_regn;
        private String _sia_dixnac_tdia;
        private String _adm_estnac_regn;
        private String _adm_tipmue_regn;
        private String _desia_dixmue_tdia;
        private String _sia_dixmue_tdia;
        private DateTime _adm_fecmue_regn;
        private Decimal _adm_hormue_regn;
        private String _sis_estpro_espr;
        private String _sis_dessex_sexo;
        private String _sia_desdia_tdia;
        private String _sis_despro_espr;
        private string _sis_estado_imaen;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Adm_secegr_regn: Secuencial registro
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Secuencial registro</para>
        /// <para>NOMBRE: adm_secegr_regn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial registro de naciemiento (generado por el sistema)
        /// </para>
        /// </summary>
        public String Adm_secegr_regn
        {
            get { return _adm_secegr_regn; }
            set
            {
                if (_adm_secegr_regn == value) return;
                _adm_secegr_regn = value;
                OnPropertyChanged("Adm_secegr_regn");
            }
        }
        #endregion
        #region Adm_secegr_regr: Secuencial egreso
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Secuencial egreso</para>
        /// <para>NOMBRE: adm_secegr_regr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Secuencial registro de egreso
        /// </para>
        /// </summary>
        public String Adm_secegr_regr
        {
            get { return _adm_secegr_regr; }
            set
            {
                if (_adm_secegr_regr == value) return;
                _adm_secegr_regr = value;
                OnPropertyChanged("Adm_secegr_regr");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region Sia_idesec_usua: Codigo unico del paciente
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Codigo unico del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Unico de paciente en el sistema (la madre del recien
        /// nacido)
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
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de d atos ejm: CC= Cedula,otros
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
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros  (madre)
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
        #region Adm_fecnac_regn: Fecha de nacimiento
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Fecha de nacimiento</para>
        /// <para>NOMBRE: adm_fecnac_regn (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha de nacimiento del recien nacido
        /// </para>
        /// </summary>
        public DateTime Adm_fecnac_regn
        {
            get { return _adm_fecnac_regn; }
            set
            {
                if (_adm_fecnac_regn == value) return;
                _adm_fecnac_regn = value;
                OnPropertyChanged("Adm_fecnac_regn");
            }
        }
        #endregion
        #region Sis_codsex_sexo: Sexo
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Sexo del del recien nacido
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
        #region Adm_hornac_regn: Hora nacimiento
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Hora nacimiento</para>
        /// <para>NOMBRE: adm_hornac_regn (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Hora  del nacimiento recien nacido en formato militar  (HH)
        /// ejm: 16
        /// </para>
        /// </summary>
        public Decimal Adm_hornac_regn
        {
            get { return _adm_hornac_regn; }
            set
            {
                if (_adm_hornac_regn == value) return;
                _adm_hornac_regn = value;
                OnPropertyChanged("Adm_hornac_regn");
            }
        }
        #endregion
        #region Adm_peson_regn: Peso al nacer
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Peso al nacer</para>
        /// <para>NOMBRE: adm_peson_regn (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Peso recien nacido, en gramos
        /// </para>
        /// </summary>
        public int Adm_peson_regn
        {
            get { return _adm_peson_regn; }
            set
            {
                if (_adm_peson_regn == value) return;
                _adm_peson_regn = value;
                OnPropertyChanged("Adm_peson_regn");
            }
        }
        #endregion
        #region Adm_tallan_regn: Talla al nacer
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Talla al nacer</para>
        /// <para>NOMBRE: adm_tallan_regn (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Talla recien nacido, en centimetros
        /// </para>
        /// </summary>
        public int Adm_tallan_regn
        {
            get { return _adm_tallan_regn; }
            set
            {
                if (_adm_tallan_regn == value) return;
                _adm_tallan_regn = value;
                OnPropertyChanged("Adm_tallan_regn");
            }
        }
        #endregion
        #region Sia_dixnac_tdia: Diagnostico nacimiento
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico nacimiento</para>
        /// <para>NOMBRE: sia_dixnac_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de nacimiento según CIE-10
        /// </para>
        /// </summary>
        public String Sia_dixnac_tdia
        {
            get { return _sia_dixnac_tdia; }
            set
            {
                if (_sia_dixnac_tdia == value) return;
                _sia_dixnac_tdia = value;
                OnPropertyChanged("Sia_dixnac_tdia");
            }
        }
        #endregion
        #region Adm_estnac_regn: Estado al nacer
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Estado al nacer</para>
        /// <para>NOMBRE: adm_estnac_regn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado al nacer: 1=Vivo 2= Muerto
        /// </para>
        /// </summary>
        public String Adm_estnac_regn
        {
            get { return _adm_estnac_regn; }
            set
            {
                if (_adm_estnac_regn == value) return;
                _adm_estnac_regn = value;
                OnPropertyChanged("Adm_estnac_regn");
            }
        }
        #endregion
        #region Adm_tipmue_regn: Muerte postnatal
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Muerte postnatal</para>
        /// <para>NOMBRE: adm_tipmue_regn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Muerte despues del nacimiento: 1=En las primeras 48 horas 2=
        /// Despues de 48 horas
        /// </para>
        /// </summary>
        public String Adm_tipmue_regn
        {
            get { return _adm_tipmue_regn; }
            set
            {
                if (_adm_tipmue_regn == value) return;
                _adm_tipmue_regn = value;
                OnPropertyChanged("Adm_tipmue_regn");
            }
        }
        #endregion
        #region Desia_dixmue_tdia: Descripcion diagnostico
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixmue_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixmue_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_dixmue_tdia
        {
            get { return _desia_dixmue_tdia; }
            set
            {
                if (_desia_dixmue_tdia == value) return;
                _desia_dixmue_tdia = value;
                OnPropertyChanged("Desia_dixmue_tdia");
            }
        }
        #endregion
        #region Sia_dixmue_tdia: Diagnostico de muerte
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico de muerte</para>
        /// <para>NOMBRE: sia_dixmue_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de causa muerte cuando exista según CIE-10
        /// </para>
        /// </summary>
        public String Sia_dixmue_tdia
        {
            get { return _sia_dixmue_tdia; }
            set
            {
                if (_sia_dixmue_tdia == value) return;
                _sia_dixmue_tdia = value;
                OnPropertyChanged("Sia_dixmue_tdia");
            }
        }
        #endregion
        #region Adm_fecmue_regn: Fecha muerte
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Fecha muerte</para>
        /// <para>NOMBRE: adm_fecmue_regn (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Fecha muerte recien nacido dentro del servicio de hospitalizacion
        /// u Observacion en urgencia
        /// </para>
        /// </summary>
        public DateTime Adm_fecmue_regn
        {
            get { return _adm_fecmue_regn; }
            set
            {
                if (_adm_fecmue_regn == value) return;
                _adm_fecmue_regn = value;
                OnPropertyChanged("Adm_fecmue_regn");
            }
        }
        #endregion
        #region Adm_hormue_regn: Hora de muerte
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Hora de muerte</para>
        /// <para>NOMBRE: adm_hormue_regn (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Hora  muerte recien nacido en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Adm_hormue_regn
        {
            get { return _adm_hormue_regn; }
            set
            {
                if (_adm_hormue_regn == value) return;
                _adm_hormue_regn = value;
                OnPropertyChanged("Adm_hormue_regn");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Egreso
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Egreso</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Estado del registro de egreso para admitidos   1=Abierto 2=Cerrado
        /// 3=Anulado
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
        #region Sis_dessex_sexo: Sexo
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
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
        #region Sia_desdia_tdia: Descripcion diagnostico
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
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
        #region Sis_estado_imaen: Estado del registro para edicion
        /// <summary>
        /// <para>CAMPO: Estado del Registro Para Edicion</para>
        /// <para>NOMBRE: Sis_estado_imaen (char:1)</para>
        /// <para>DESCRIPCION:
        /// Estado del registro para proceso de edicion
        /// I=Ingnorar,M=Modificar,A=Adicionar
        /// E=Eliminar,N=Nulo (esta en nulo)
        /// </para>
        /// </summary>
        public String Sis_estado_imaen
        {
            get { return _sis_estado_imaen; }
            set
            {
                if (_sis_estado_imaen == value) return;
                _sis_estado_imaen = value;
                OnPropertyChanged("Sis_estado_imaen");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloRegnacimiento tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFadmregnacimient();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Admregnacimient.FirstOrDefault(p => p.adm_secegr_regn == tobTempReg.Adm_secegr_regn);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.adm_secegr_regn = tobTempReg.Adm_secegr_regn;
                            lobEFReg.adm_secegr_regr = tobTempReg.Adm_secegr_regr;
                            lobEFReg.adm_secadm_rgad = tobTempReg.Adm_secadm_rgad;
                            lobEFReg.sia_idesec_usua = tobTempReg.Sia_idesec_usua;
                            lobEFReg.sia_tipide_tide = tobTempReg.Sia_tipide_tide;
                            lobEFReg.sia_nroide_usua = tobTempReg.Sia_nroide_usua;
                            lobEFReg.adm_fecnac_regn = (DateTime)tobTempReg.Adm_fecnac_regn;
                            lobEFReg.sis_codsex_sexo = tobTempReg.Sis_codsex_sexo;
                            lobEFReg.adm_hornac_regn = (Decimal)tobTempReg.Adm_hornac_regn;
                            lobEFReg.adm_peson_regn = (int)tobTempReg.Adm_peson_regn;
                            lobEFReg.adm_tallan_regn = (int)tobTempReg.Adm_tallan_regn;
                            lobEFReg.sia_dixnac_tdia = tobTempReg.Sia_dixnac_tdia;
                            lobEFReg.adm_estnac_regn = tobTempReg.Adm_estnac_regn;
                            lobEFReg.adm_tipmue_regn = tobTempReg.Adm_tipmue_regn;
                            lobEFReg.sia_dixmue_tdia = tobTempReg.Sia_dixmue_tdia;
                            lobEFReg.adm_fecmue_regn = (DateTime)tobTempReg.Adm_fecmue_regn;
                            lobEFReg.adm_hormue_regn = (Decimal)tobTempReg.Adm_hormue_regn;
                            lobEFReg.sis_estpro_espr = tobTempReg.Sis_estpro_espr;
                        }
                        #endregion
                    }
                    //---------------------------
                    // Guardar cambios o eliminar
                    //---------------------------
                    if (lobEFReg != null)
                    {
                        switch (tobTempReg.Sis_estado_imaen)
                        {
                            case "A": // Adicionar el registro
                                lobEFReg.adm_secegr_regn = tcrCodigoR1 + lobEFReg.adm_secegr_regn; // concatenar
                                _context.AddToAdmregnacimient(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Admregnacimient.FirstOrDefault(p => p.adm_secegr_regn == tobTempReg.Adm_secegr_regn);
                                if (lobjRegistro != null)
                                {
                                    _context.DeleteObject(lobjRegistro);
                                    _context.SaveChanges();
                                }
                                break;
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ADMREGNACIMIENT: Logica
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TITULO: Maestro registro nacimiento en servicio hospitalizacion</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro de nacimientos en hospitalizacion, se
        /// diligencia al momento del egreso cuando en los datos de salida
        /// se especifica atencion del parto
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmregnacimient(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregnacimient.FirstOrDefault(p => p.adm_secegr_regn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloRegnacimiento> flsListaAdmregnacimient(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from admregnacimient in _context.Admregnacimient
                                  join admregistegreso in _context.Admregistegreso on admregnacimient.adm_secegr_regr equals admregistegreso.adm_secegr_regr into tmadmregistegreso
                                  join admregadmision in _context.Admregadmision on admregnacimient.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                  join sistablasexos in _context.Sistablasexos on admregnacimient.sis_codsex_sexo equals sistablasexos.sis_codsex_sexo into tmsistablasexos
                                  join siadiagnosticos in _context.Siadiagnosticos on admregnacimient.sia_dixnac_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                  join sisestadoproces in _context.Sisestadoproces on admregnacimient.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  from regr in tmadmregistegreso.DefaultIfEmpty()
                                  from rgad in tmadmregadmision.DefaultIfEmpty()
                                  from sexo in tmsistablasexos.DefaultIfEmpty()
                                  from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  where admregnacimient.adm_secegr_regr == tcrBuscar
                                  select new ModeloRegnacimiento
                                  {
                                      Adm_secegr_regn = admregnacimient.adm_secegr_regn,
                                      Adm_secegr_regr = admregnacimient.adm_secegr_regr,
                                      Adm_secadm_rgad = admregnacimient.adm_secadm_rgad,
                                      Sia_idesec_usua = admregnacimient.sia_idesec_usua,
                                      Sia_tipide_tide = admregnacimient.sia_tipide_tide,
                                      Sia_nroide_usua = admregnacimient.sia_nroide_usua,
                                      Adm_fecnac_regn = (DateTime)admregnacimient.adm_fecnac_regn,
                                      Sis_codsex_sexo = admregnacimient.sis_codsex_sexo,
                                      Adm_hornac_regn = (Decimal)admregnacimient.adm_hornac_regn,
                                      Adm_peson_regn = (int)admregnacimient.adm_peson_regn,
                                      Adm_tallan_regn = (int)admregnacimient.adm_tallan_regn,
                                      Sia_dixnac_tdia = admregnacimient.sia_dixnac_tdia,
                                      Adm_estnac_regn = admregnacimient.adm_estnac_regn,
                                      Adm_tipmue_regn = admregnacimient.adm_tipmue_regn,
                                      Sia_dixmue_tdia = admregnacimient.sia_dixmue_tdia,
                                      Desia_dixmue_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregnacimient.sia_dixmue_tdia).sia_desdia_tdia,
                                      Adm_fecmue_regn = (DateTime)admregnacimient.adm_fecmue_regn,
                                      Adm_hormue_regn = (Decimal)admregnacimient.adm_hormue_regn,
                                      Sis_estpro_espr = admregnacimient.sis_estpro_espr,
                                      Sis_dessex_sexo = sexo.sis_dessex_sexo,
                                      Sia_desdia_tdia = tdia.sia_desdia_tdia,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
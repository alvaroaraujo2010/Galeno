//- MARMOTA-GENCODE: VERSION 2.0 - 08/06/2015 06:15:41 AM
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
    /// Descripcion para la Vista de  la tabla: admregurgencias
    /// </summary>
    public class ModeloHosEgresoUrgencias : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Adm_secegr_regu: Egreso urgencias
        private String _adm_secegr_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Egreso urgencias</para>
        /// <para>NOMBRE: adm_secegr_regu (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial registro de egreso urgencias
        /// </para>
        /// </summary>
        public String Adm_secegr_regu
        {
            get { return _adm_secegr_regu; }
            set
            {
                if (_adm_secegr_regu == value) return;
                _adm_secegr_regu = value;
                OnPropertyChanged("Adm_secegr_regu");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        private String _sia_tipide_tide;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        private String _hcl_nrohis_hicl;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        #region Adm_fecegr_regu: Fecha de salida
        private DateTime _adm_fecegr_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Fecha de salida</para>
        /// <para>NOMBRE: adm_fecegr_regu (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha de egreso del servicio observacion en urgencias
        /// </para>
        /// </summary>
        public DateTime Adm_fecegr_regu
        {
            get { return _adm_fecegr_regu; }
            set
            {
                if (_adm_fecegr_regu == value) return;
                _adm_fecegr_regu = value;
                OnPropertyChanged("Adm_fecegr_regu");
            }
        }
        #endregion
        #region Adm_horegr_regu: Hora de salida
        private Decimal _adm_horegr_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Hora de salida</para>
        /// <para>NOMBRE: adm_horegr_regu (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Hora  egreso en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Adm_horegr_regu
        {
            get { return _adm_horegr_regu; }
            set
            {
                if (_adm_horegr_regu == value) return;
                _adm_horegr_regu = value;
                OnPropertyChanged("Adm_horegr_regu");
            }
        }
        #endregion
        #region Adm_diases_regu: Dias de estancia
        private int _adm_diases_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Dias de estancia</para>
        /// <para>NOMBRE: adm_diases_regu (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Numero dias de estancia en la IPS
        /// </para>
        /// </summary>
        public int Adm_diases_regu
        {
            get { return _adm_diases_regu; }
            set
            {
                if (_adm_diases_regu == value) return;
                _adm_diases_regu = value;
                OnPropertyChanged("Adm_diases_regu");
            }
        }
        #endregion
        #region Adm_horase_regu: Horas de estancia
        private int _adm_horase_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Horas de estancia</para>
        /// <para>NOMBRE: adm_horase_regu (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Numero hora total  en estancia en la IPS
        /// </para>
        /// </summary>
        public int Adm_horase_regu
        {
            get { return _adm_horase_regu; }
            set
            {
                if (_adm_horase_regu == value) return;
                _adm_horase_regu = value;
                OnPropertyChanged("Adm_horase_regu");
            }
        }
        #endregion
        #region Adm_secaut_aegr: Autorización salida
        private String _adm_secaut_aegr;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Autorización salida</para>
        /// <para>NOMBRE: adm_secaut_aegr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region Hos_codesp_espa: Traslado a hospitalización
        private String _hos_codesp_espa;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Traslado a hospitalización</para>
        /// <para>NOMBRE: hos_codesp_espa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Codigo registro traslado intrahospitalario cuando la salida
        /// de urgencias es un traslado a hospitalizacion
        /// </para>
        /// </summary>
        public String Hos_codesp_espa
        {
            get { return _hos_codesp_espa; }
            set
            {
                if (_hos_codesp_espa == value) return;
                _hos_codesp_espa = value;
                OnPropertyChanged("Hos_codesp_espa");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Profesional Autoriza salida
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Profesional Autoriza salida</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Codigo Profesional Que Autoriza salida o traslado a hospitalización
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
        #region Sia_dixsal_tdia: Diagnostico salida
        private String _sia_dixsal_tdia;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico salida</para>
        /// <para>NOMBRE: sia_dixsal_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de salida de urgencias con observacion según CIE-10
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
        #region Desia_dixre1_tdia: Descripcion diagnostico
        private String _desia_dixre1_tdia;
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
        private String _sia_dixre1_tdia;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        private String _desia_dixre2_tdia;
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
        private String _sia_dixre2_tdia;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        private String _desia_dixre3_tdia;
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
        private String _sia_dixre3_tdia;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        #region Adm_estsal_regu: Estado al salir
        private String _adm_estsal_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Estado al salir</para>
        /// <para>NOMBRE: adm_estsal_regu (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Estado al salir: 1=Vivo 2= Muerto
        /// </para>
        /// </summary>
        public String Adm_estsal_regu
        {
            get { return _adm_estsal_regu; }
            set
            {
                if (_adm_estsal_regu == value) return;
                _adm_estsal_regu = value;
                OnPropertyChanged("Adm_estsal_regu");
            }
        }
        #endregion
        #region Adm_dessal_regr: Destino al salir
        private String _adm_dessal_regr;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: adm_dessal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
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
        #region Adm_tipmue_regu: Muerte intrahospitalaria
        private String _adm_tipmue_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Muerte intrahospitalaria</para>
        /// <para>NOMBRE: adm_tipmue_regu (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Muerte intrahospitalaria de pacientes admitidos: 1=En las primeras
        /// 48 horas 2= Despues de 48 horas
        /// </para>
        /// </summary>
        public String Adm_tipmue_regu
        {
            get { return _adm_tipmue_regu; }
            set
            {
                if (_adm_tipmue_regu == value) return;
                _adm_tipmue_regu = value;
                OnPropertyChanged("Adm_tipmue_regu");
            }
        }
        #endregion
        #region Desia_dixmue_tdia: Descripcion diagnostico
        private String _desia_dixmue_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_dixmue_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        private String _sia_dixmue_tdia;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico de muerte</para>
        /// <para>NOMBRE: sia_dixmue_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        #region Adm_fecmue_regu: Fecha muerte
        private DateTime _adm_fecmue_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Fecha muerte</para>
        /// <para>NOMBRE: adm_fecmue_regu (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Fecha muerte dentro del servicio de hospitalizacion u Observacion
        /// en urgencia
        /// </para>
        /// </summary>
        public DateTime Adm_fecmue_regu
        {
            get { return _adm_fecmue_regu; }
            set
            {
                if (_adm_fecmue_regu == value) return;
                _adm_fecmue_regu = value;
                OnPropertyChanged("Adm_fecmue_regu");
            }
        }
        #endregion
        #region Adm_hormue_regu: Hora de muerte
        private Decimal _adm_hormue_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Hora de muerte</para>
        /// <para>NOMBRE: adm_hormue_regu (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Hora  muerte en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Adm_hormue_regu
        {
            get { return _adm_hormue_regu; }
            set
            {
                if (_adm_hormue_regu == value) return;
                _adm_hormue_regu = value;
                OnPropertyChanged("Adm_hormue_regu");
            }
        }
        #endregion
        #region Adm_observ_regu: Nota egreso
        private String _adm_observ_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Nota egreso</para>
        /// <para>NOMBRE: adm_observ_regu (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Nota u observación del egreso
        /// </para>
        /// </summary>
        public String Adm_observ_regu
        {
            get { return _adm_observ_regu; }
            set
            {
                if (_adm_observ_regu == value) return;
                _adm_observ_regu = value;
                OnPropertyChanged("Adm_observ_regu");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Egreso
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Egreso</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Estado del registro egreso urgencias  1=Abierto 2=Confirmado
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
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        private String _sia_deside_tide;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        private String _sia_desdia_tdia;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloHosEgresoUrgencias tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HOS-EGRESO-URGENCIAS", "HOS", "Registro egreso de urgencias");
            try
            {
                if (!flgBuscarAdmregurgencias(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFadmregurgencias
                        {
                            #region cargar Registro
                            adm_secegr_regu = tobjModelo.Adm_secegr_regu,
                            adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                            sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                            sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                            sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                            hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl,
                            adm_fecegr_regu = tobjModelo.Adm_fecegr_regu,
                            adm_horegr_regu = tobjModelo.Adm_horegr_regu,
                            adm_diases_regu = tobjModelo.Adm_diases_regu,
                            adm_horase_regu = tobjModelo.Adm_horase_regu,
                            adm_secaut_aegr = tobjModelo.Adm_secaut_aegr,
                            hos_codesp_espa = tobjModelo.Hos_codesp_espa,
                            sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                            sia_dixsal_tdia = tobjModelo.Sia_dixsal_tdia,
                            sia_dixre1_tdia = tobjModelo.Sia_dixre1_tdia,
                            sia_dixre2_tdia = tobjModelo.Sia_dixre2_tdia,
                            sia_dixre3_tdia = tobjModelo.Sia_dixre3_tdia,
                            adm_estsal_regu = tobjModelo.Adm_estsal_regu,
                            adm_dessal_regr = tobjModelo.Adm_dessal_regr,
                            adm_tipmue_regu = tobjModelo.Adm_tipmue_regu,
                            sia_dixmue_tdia = tobjModelo.Sia_dixmue_tdia,
                            adm_fecmue_regu = tobjModelo.Adm_fecmue_regu,
                            adm_hormue_regu = tobjModelo.Adm_hormue_regu,
                            adm_observ_regu = tobjModelo.Adm_observ_regu,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.adm_secegr_regu = lcrCodigoGen;
                        _context.AddToAdmregurgencias(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = string.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HOS-EGRESO-URGENCIAS': Registro egreso de urgencias en Maestro Secuenciales.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHosEgresoUrgencias tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Admregurgencias.FirstOrDefault(p => p.adm_secegr_regu == tobjModelo.Adm_secegr_regu);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.adm_secegr_regu = tobjModelo.Adm_secegr_regu;
                        lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                        lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                        lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                        lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                        lobjRegistro.hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl;
                        lobjRegistro.adm_fecegr_regu = (DateTime)tobjModelo.Adm_fecegr_regu;
                        lobjRegistro.adm_horegr_regu = (Decimal)tobjModelo.Adm_horegr_regu;
                        lobjRegistro.adm_diases_regu = (int)tobjModelo.Adm_diases_regu;
                        lobjRegistro.adm_horase_regu = (int)tobjModelo.Adm_horase_regu;
                        lobjRegistro.adm_secaut_aegr = tobjModelo.Adm_secaut_aegr;
                        lobjRegistro.hos_codesp_espa = tobjModelo.Hos_codesp_espa;
                        lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                        lobjRegistro.sia_dixsal_tdia = tobjModelo.Sia_dixsal_tdia;
                        lobjRegistro.sia_dixre1_tdia = tobjModelo.Sia_dixre1_tdia;
                        lobjRegistro.sia_dixre2_tdia = tobjModelo.Sia_dixre2_tdia;
                        lobjRegistro.sia_dixre3_tdia = tobjModelo.Sia_dixre3_tdia;
                        lobjRegistro.adm_estsal_regu = tobjModelo.Adm_estsal_regu;
                        lobjRegistro.adm_dessal_regr = tobjModelo.Adm_dessal_regr;
                        lobjRegistro.adm_tipmue_regu = tobjModelo.Adm_tipmue_regu;
                        lobjRegistro.sia_dixmue_tdia = tobjModelo.Sia_dixmue_tdia;
                        lobjRegistro.adm_fecmue_regu = (DateTime)tobjModelo.Adm_fecmue_regu;
                        lobjRegistro.adm_hormue_regu = (Decimal)tobjModelo.Adm_hormue_regu;
                        lobjRegistro.adm_observ_regu = tobjModelo.Adm_observ_regu;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvActualizar");
            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Admregurgencias.FirstOrDefault(p => p.adm_secegr_regu == tcrCodigo);
                    if (lobjRegistro != null)
                    {
                        _context.DeleteObject(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvEliminar");
            }
        }
        #endregion
        #region Buscar ADMREGURGENCIAS: Logica
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TITULO: Maestro registro salida de urgencias</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para registro datos salida de urgencias con observación
        /// (sea que pase a hospitalizacion o salga de la IPS)
        /// </para>
        /// </summary>
        public static bool flgBuscarAdmregurgencias(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregurgencias.FirstOrDefault(p => p.adm_secegr_regu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHosEgresoUrgencias> flsListaAdmregurgencias(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from admregurgencias in _context.Admregurgencias
                                  join siausuarioatend in _context.Siausuarioatend on admregurgencias.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                  join siatipideusario in _context.Siatipideusario on admregurgencias.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                  join siamaeprofsalud in _context.Siamaeprofsalud on admregurgencias.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                  join siadiagnosticos in _context.Siadiagnosticos on admregurgencias.sia_dixsal_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                  join sisestadoproces in _context.Sisestadoproces on admregurgencias.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  from usua in tmsiausuarioatend.DefaultIfEmpty()
                                  from tide in tmsiatipideusario.DefaultIfEmpty()
                                  from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                  from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  where admregurgencias.adm_secegr_regu == tcrBuscar
                                  select new ModeloHosEgresoUrgencias
                                  {
                                      Adm_secegr_regu = admregurgencias.adm_secegr_regu,
                                      Adm_secadm_rgad = admregurgencias.adm_secadm_rgad,
                                      Sia_idesec_usua = admregurgencias.sia_idesec_usua,
                                      Sia_tipide_tide = admregurgencias.sia_tipide_tide,
                                      Sia_nroide_usua = admregurgencias.sia_nroide_usua,
                                      Hcl_nrohis_hicl = admregurgencias.hcl_nrohis_hicl,
                                      Adm_fecegr_regu = (DateTime)admregurgencias.adm_fecegr_regu,
                                      Adm_horegr_regu = (Decimal)admregurgencias.adm_horegr_regu,
                                      Adm_diases_regu = (int)admregurgencias.adm_diases_regu,
                                      Adm_horase_regu = (int)admregurgencias.adm_horase_regu,
                                      Adm_secaut_aegr = admregurgencias.adm_secaut_aegr,
                                      Hos_codesp_espa = admregurgencias.hos_codesp_espa,
                                      Sia_codpfa_prof = admregurgencias.sia_codpfa_prof,
                                      Sia_dixsal_tdia = admregurgencias.sia_dixsal_tdia,
                                      Sia_dixre1_tdia = admregurgencias.sia_dixre1_tdia,
                                      Desia_dixre1_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregurgencias.sia_dixre1_tdia).sia_desdia_tdia,
                                      Sia_dixre2_tdia = admregurgencias.sia_dixre2_tdia,
                                      Desia_dixre2_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregurgencias.sia_dixre2_tdia).sia_desdia_tdia,
                                      Sia_dixre3_tdia = admregurgencias.sia_dixre3_tdia,
                                      Desia_dixre3_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregurgencias.sia_dixre3_tdia).sia_desdia_tdia,
                                      Adm_estsal_regu = admregurgencias.adm_estsal_regu,
                                      Adm_dessal_regr = admregurgencias.adm_dessal_regr,
                                      Adm_tipmue_regu = admregurgencias.adm_tipmue_regu,
                                      Sia_dixmue_tdia = admregurgencias.sia_dixmue_tdia,
                                      Desia_dixmue_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == admregurgencias.sia_dixmue_tdia).sia_desdia_tdia,
                                      Adm_fecmue_regu = (DateTime)admregurgencias.adm_fecmue_regu,
                                      Adm_hormue_regu = (Decimal)admregurgencias.adm_hormue_regu,
                                      Adm_observ_regu = admregurgencias.adm_observ_regu,
                                      Sis_estpro_espr = admregurgencias.sis_estpro_espr,
                                      Sia_nomusu_usua = usua.sia_nomusu_usua,
                                      Sia_deside_tide = tide.sia_deside_tide,
                                      Sia_nompro_prof = prof.sia_nompro_prof,
                                      Sia_desdia_tdia = tdia.sia_desdia_tdia,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
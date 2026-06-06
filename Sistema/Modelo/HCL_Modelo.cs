using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using Datos.Modelos;
using Sistema.Utilidades;

namespace Sistema.Modelo
{
    /// <summary>
    /// Maestro historial actividades clinicas realizadas pacientes
    /// </summary>
    public class HclModeloHistorialEventos : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        private static Aplicacion oApp = Aplicacion.Instancia();
        #region Modelo Propiedades Notificacion
        #region Hcl_nroreg_hcev: Codigo Evento medico
        private String _hcl_nroreg_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: hcl_nroreg_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial del evento medico  (generado por el sistema)
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcev
        {
            get { return _hcl_nroreg_hcev; }
            set
            {
                if (_hcl_nroreg_hcev == value) return;
                _hcl_nroreg_hcev = value;
                OnPropertyChanged("Hcl_nroreg_hcev");
            }
        }
        #endregion
        #region Hcl_codreg_hcca: Tipo Registro actividad
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Tipo Registro actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcca (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad medica ejemplo: APE-HCL-GENE
        /// = Apertura Historia clinica general APE-HCL-ODON= Apertura
        /// Historia clinica odontologia y otras
        /// </para>
        /// </summary>
        public String Hcl_codreg_hcca
        {
            get { return _hcl_codreg_hcca; }
            set
            {
                if (_hcl_codreg_hcca == value) return;
                _hcl_codreg_hcca = value;
                OnPropertyChanged("Hcl_codreg_hcca");
            }
        }
        #endregion
        #region Hcl_desreg_hcev: Descripción Evento
        private String _hcl_desreg_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Descripción Evento</para>
        /// <para>NOMBRE: hcl_desreg_hcev (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion evento medico
        /// </para>
        /// </summary>
        public String Hcl_desreg_hcev
        {
            get { return _hcl_desreg_hcev; }
            set
            {
                if (_hcl_desreg_hcev == value) return;
                _hcl_desreg_hcev = value;
                OnPropertyChanged("Hcl_desreg_hcev");
            }
        }
        #endregion
        #region Hcl_secreg_hcev: Secuencial evento
        private long _hcl_secreg_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Secuencial evento</para>
        /// <para>NOMBRE: hcl_secreg_hcev (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial tipo numerico del evento medico, generado desde el contador
        /// en registro maestro de historia clinica del paciente, para organizar vista
        /// </para>
        /// </summary>
        public long Hcl_secreg_hcev
        {
            get { return _hcl_secreg_hcev; }
            set
            {
                if (_hcl_secreg_hcev == value) return;
                _hcl_secreg_hcev = value;
                OnPropertyChanged("Hcl_secreg_hcev");
            }
        }
        #endregion
        #region Hcl_nrohis_hicl: Numero historia clínica
        private String _hcl_nrohis_hicl;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Numero historia clínica</para>
        /// <para>NOMBRE: hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero o código de la Ficha de Historias Clínicas (generado
        /// por el sistema)
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
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        #region Cit_codasi_mcit: Código registro cita
        private String _cit_codasi_mcit;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Código registro cita</para>
        /// <para>NOMBRE: cit_codasi_mcit (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region Fcm_secreg_dfac: Servicio en facturación
        private String _fcm_secreg_dfac;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Servicio en facturación</para>
        /// <para>NOMBRE: fcm_secreg_dfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Secuencial único del registro desde servicios facturados del
        /// modulo Facturación (cuando aplique)
        /// </para>
        /// </summary>
        public String Fcm_secreg_dfac
        {
            get { return _fcm_secreg_dfac; }
            set
            {
                if (_fcm_secreg_dfac == value) return;
                _fcm_secreg_dfac = value;
                OnPropertyChanged("Fcm_secreg_dfac");
            }
        }
        #endregion
        #region Hcl_codaux_hcev: Codigo auxiliar
        private String _hcl_codaux_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo auxiliar</para>
        /// <para>NOMBRE: hcl_codaux_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo auxiliar requerido por algun registro de actividad (puede
        /// contener codigo unicos provenientes de otras tablas)
        /// </para>
        /// </summary>
        public String Hcl_codaux_hcev
        {
            get { return _hcl_codaux_hcev; }
            set
            {
                if (_hcl_codaux_hcev == value) return;
                _hcl_codaux_hcev = value;
                OnPropertyChanged("Hcl_codaux_hcev");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Hcl_gesfec_hcev: Fecha servicio
        private DateTime _hcl_gesfec_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: hcl_gesfec_hcev (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Fecha del evento o prestacion del servicio al paciente
        /// </para>
        /// </summary>
        public DateTime Hcl_gesfec_hcev
        {
            get { return _hcl_gesfec_hcev; }
            set
            {
                if (_hcl_gesfec_hcev == value) return;
                _hcl_gesfec_hcev = value;
                OnPropertyChanged("Hcl_gesfec_hcev");
            }
        }
        #endregion
        #region Hcl_geshor_hcev: Hora servicio
        private Decimal _hcl_geshor_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: hcl_geshor_hcev (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Hora del evento o prestación del servicio al paciente en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_geshor_hcev
        {
            get { return _hcl_geshor_hcev; }
            set
            {
                if (_hcl_geshor_hcev == value) return;
                _hcl_geshor_hcev = value;
                OnPropertyChanged("Hcl_geshor_hcev");
            }
        }
        #endregion
        #region Hcl_sisfec_hcev: Fecha sistema
        private DateTime _hcl_sisfec_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Fecha sistema</para>
        /// <para>NOMBRE: hcl_sisfec_hcev (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Fecha  del sistema cuando se genera registro del evento
        /// </para>
        /// </summary>
        public DateTime Hcl_sisfec_hcev
        {
            get { return _hcl_sisfec_hcev; }
            set
            {
                if (_hcl_sisfec_hcev == value) return;
                _hcl_sisfec_hcev = value;
                OnPropertyChanged("Hcl_sisfec_hcev");
            }
        }
        #endregion
        #region Hcl_sishor_hcev: Hora sistema
        private Decimal _hcl_sishor_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Hora sistema</para>
        /// <para>NOMBRE: hcl_sishor_hcev (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema al generar registro de evento en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_sishor_hcev
        {
            get { return _hcl_sishor_hcev; }
            set
            {
                if (_hcl_sishor_hcev == value) return;
                _hcl_sishor_hcev = value;
                OnPropertyChanged("Hcl_sishor_hcev");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional que realiza la atencion del evento
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
        #region Grp_idepla_grpl: Código único plantilla
        private String _grp_idepla_grpl;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de la plantilla  base
        /// </para>
        /// </summary>
        public String Grp_idepla_grpl
        {
            get { return _grp_idepla_grpl; }
            set
            {
                if (_grp_idepla_grpl == value) return;
                _grp_idepla_grpl = value;
                OnPropertyChanged("Grp_idepla_grpl");
            }
        }
        #endregion
        #region Grp_idepla_grpv: Código version plantilla
        private String _grp_idepla_grpv;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Código version plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de la version plantilla usada
        /// </para>
        /// </summary>
        public String Grp_idepla_grpv
        {
            get { return _grp_idepla_grpv; }
            set
            {
                if (_grp_idepla_grpv == value) return;
                _grp_idepla_grpv = value;
                OnPropertyChanged("Grp_idepla_grpv");
            }
        }
        #endregion
        #region Hcl_keydat_hcev: Palabras claves busqueda
        private String _hcl_keydat_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Palabras claves busqueda</para>
        /// <para>NOMBRE: hcl_keydat_hcev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Palabras claves para usar como llaves de busqueda
        /// </para>
        /// </summary>
        public String Hcl_keydat_hcev
        {
            get { return _hcl_keydat_hcev; }
            set
            {
                if (_hcl_keydat_hcev == value) return;
                _hcl_keydat_hcev = value;
                OnPropertyChanged("Hcl_keydat_hcev");
            }
        }
        #endregion
        #region Hcl_xmldat_hcev: Datos XML digitados
        private String _hcl_xmldat_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Datos XML digitados</para>
        /// <para>NOMBRE: hcl_xmldat_hcev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Datos en formato XML diligenciados en el formato o plantilla
        /// (incluye imágenes y objetos vistas del muro)
        /// </para>
        /// </summary>
        public String Hcl_xmldat_hcev
        {
            get { return _hcl_xmldat_hcev; }
            set
            {
                if (_hcl_xmldat_hcev == value) return;
                _hcl_xmldat_hcev = value;
                OnPropertyChanged("Hcl_xmldat_hcev");
            }
        }
        #endregion
        #region Hcl_xmltmp_hcev: Datos XML temporal
        private String _hcl_xmltmp_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Datos XML temporal</para>
        /// <para>NOMBRE: hcl_xmltmp_hcev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Datos en formato XML diligenciados guardados de manera temporal
        /// por el sistema como respaldo de digitacion
        /// </para>
        /// </summary>
        public String Hcl_xmltmp_hcev
        {
            get { return _hcl_xmltmp_hcev; }
            set
            {
                if (_hcl_xmltmp_hcev == value) return;
                _hcl_xmltmp_hcev = value;
                OnPropertyChanged("Hcl_xmltmp_hcev");
            }
        }
        #endregion
        #region Hcl_xmlcom_hcev: Comentarios XML
        private String _hcl_xmlcom_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Comentarios XML</para>
        /// <para>NOMBRE: hcl_xmlcom_hcev (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Datos en formato XML comentarios realizados al registro
        /// </para>
        /// </summary>
        public String Hcl_xmlcom_hcev
        {
            get { return _hcl_xmlcom_hcev; }
            set
            {
                if (_hcl_xmlcom_hcev == value) return;
                _hcl_xmlcom_hcev = value;
                OnPropertyChanged("Hcl_xmlcom_hcev");
            }
        }
        #endregion
        #region Hcl_conobj_hcev: Contador generar objetos
        private int _hcl_conobj_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Contador generar objetos</para>
        /// <para>NOMBRE: hcl_conobj_hcev (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Contador para generar Nombres unicos de objetos se agregan
        /// como etiquetas imágenes videos y otros
        /// </para>
        /// </summary>
        public int Hcl_conobj_hcev
        {
            get { return _hcl_conobj_hcev; }
            set
            {
                if (_hcl_conobj_hcev == value) return;
                _hcl_conobj_hcev = value;
                OnPropertyChanged("Hcl_conobj_hcev");
            }
        }
        #endregion
        #region Fcm_codcpr_cpro: Código centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
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
        #region Hcl_archiv_hcev: Destino datos archivo
        private String _hcl_archiv_hcev;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Destino datos archivo</para>
        /// <para>NOMBRE: hcl_archiv_hcev (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Indica en que tipo destino se guardo el registro de datos del
        /// evento actual XM = Formato XML dentro del registro actual
        /// 01=Grupo de archivos Historicos01  02 = Grupos de archivos02
        /// y 03 Grupo archivos … hasta el grupo 10
        /// </para>
        /// </summary>
        public String Hcl_archiv_hcev
        {
            get { return _hcl_archiv_hcev; }
            set
            {
                if (_hcl_archiv_hcev == value) return;
                _hcl_archiv_hcev = value;
                OnPropertyChanged("Hcl_archiv_hcev");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
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
        #region Hcl_notape_hicl: Nota de apertura
        private String _hcl_notape_hicl;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Nota de apertura</para>
        /// <para>NOMBRE: hcl_notape_hicl (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Nota de apertura electronica de la historia clinica.
        /// </para>
        /// </summary>
        public String Hcl_notape_hicl
        {
            get { return _hcl_notape_hicl; }
            set
            {
                if (_hcl_notape_hicl == value) return;
                _hcl_notape_hicl = value;
                OnPropertyChanged("Hcl_notape_hicl");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
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
        /// <para>TABLA: hclregiseventos</para>
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
        /// <para>TABLA: hclregiseventos</para>
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
        #region Fcm_descpr_cpro: Nombre centro producción
        private String _fcm_descpr_cpro;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: fcm_descpr_cpro (char:40)</para>
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
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
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
        #region Grp_despla_grpl: Nombre plantilla
        private String _grp_despla_grpl;
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public String Grp_despla_grpl
        {
            get { return _grp_despla_grpl; }
            set
            {
                if (_grp_despla_grpl == value) return;
                _grp_despla_grpl = value;
                OnPropertyChanged("Grp_despla_grpl");
            }
        }
        #endregion
        #region Hcl_imagen_hcca: Imagen (jpg)
        private String _hcl_imagen_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: hcl_imagen_hcca (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Nombre de la imagen que representa el registro de actividad
        /// en las diferentes vistas
        /// </para>
        /// </summary>
        public String Hcl_imagen_hcca
        {
            get { return _hcl_imagen_hcca; }
            set
            {
                if (_hcl_imagen_hcca == value) return;
                _hcl_imagen_hcca = value;
                OnPropertyChanged("Hcl_imagen_hcca");
            }
        }
        #endregion
        #region Hcl_icolor_hcca: Color fondo en historial
        private String _hcl_icolor_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: hcl_icolor_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo color del fondo en imagen que representa el tipo registro en browser Historial Clinico
        /// </para>
        /// </summary>
        public String Hcl_icolor_hcca
        {
            get { return _hcl_icolor_hcca; }
            set
            {
                if (_hcl_icolor_hcca == value) return;
                _hcl_icolor_hcca = value;
                OnPropertyChanged("Hcl_icolor_hcca");
            }
        }
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
        #region RefObjEvento: Referencia objeto instancia eventos en fecha en Admision
        /// <summary>
        /// Referencia del objeto que instancia el registro evento en particular
        /// </summary>
        public FrameworkElement RefObjEvento { get; set; }
        #endregion
        #region GestionEstadoRegistro: Estado del registro en vista historial
        /// <summary>
        /// Estado del registro en vista: "XX" = No cargando en vista "OK" = Cargado en vista historial
        /// </summary>
        public String GestionEstadoRegistro { get; set; }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro en historial de actividades a paciente
        /// <summary>
        /// <para>Sistema.Modelo.flgAddRegistro: Generar registro en historial de actividades</para>
        /// <para>para atencion del paciente en historia clinica</para>
        /// </summary>
        public static String fcrAddRegistro(HclModeloHistorialEventos tobjModelo)
        {
            var lcrCodigoGen = String.Empty;
            try
            {
                lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-HCLREGISEVENTOS", "HCL", "Maestro historial actividades clinicas paciente");

                if (!flgBuscarHclregiseventos(lcrCodigoGen))
                {
                    var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");

                    // Variable global del sistema indica tipo guardado
                    tobjModelo.Hcl_archiv_hcev = String.IsNullOrWhiteSpace(tobjModelo.Hcl_archiv_hcev) ? oApp.gcrAppBdatosArchvioGuardarDatos : tobjModelo.Hcl_archiv_hcev;

                    var lnullaveIndice = Funciones.fnuFechaLlaveIndiceRegistro(tobjModelo.Hcl_gesfec_hcev, tobjModelo.Hcl_geshor_hcev);
                    /*
                    var lcrFecha = tobjModelo.Hcl_gesfec_hcev.ToShortDateString();
                    var lcrllHora = Funciones.fcrCompletarFormatoHora(tobjModelo.Hcl_geshor_hcev, lcrSeparadorDecimal);
                    int lnullaveIndice = Convert.ToInt32(lcrFecha.Substring(8, 2) + lcrFecha.Substring(3, 2) + lcrFecha.Substring(0, 2) + lcrllHora);
                    */
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFhclregiseventos
                        {
                            #region cargar Registro
                            hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev,
                            hcl_codreg_hcca = tobjModelo.Hcl_codreg_hcca,
                            hcl_desreg_hcev = tobjModelo.Hcl_desreg_hcev,
                            hcl_secreg_hcev = lnullaveIndice + tobjModelo.Hcl_secreg_hcev,
                            hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl,
                            adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                            cit_codasi_mcit = tobjModelo.Cit_codasi_mcit,
                            fcm_secreg_dfac = tobjModelo.Fcm_secreg_dfac,
                            hcl_codaux_hcev = tobjModelo.Hcl_codaux_hcev,
                            sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                            sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                            sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                            hcl_gesfec_hcev = tobjModelo.Hcl_gesfec_hcev,
                            hcl_geshor_hcev = tobjModelo.Hcl_geshor_hcev,
                            hcl_sisfec_hcev = DateTime.Parse(DateTime.Now.ToShortDateString()),
                            hcl_sishor_hcev = Decimal.Parse(Funciones.fcrHoraActual("24", lcrSeparadorDecimal)),
                            sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                            grp_idepla_grpl = tobjModelo.Grp_idepla_grpl,
                            grp_idepla_grpv = tobjModelo.Grp_idepla_grpv,
                            hcl_keydat_hcev = tobjModelo.Hcl_keydat_hcev,
                            hcl_xmldat_hcev = tobjModelo.Hcl_xmldat_hcev,
                            hcl_xmltmp_hcev = tobjModelo.Hcl_xmltmp_hcev,
                            hcl_xmlcom_hcev = tobjModelo.Hcl_xmlcom_hcev,
                            hcl_conobj_hcev = tobjModelo.Hcl_conobj_hcev,
                            fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                            hcl_archiv_hcev = tobjModelo.Hcl_archiv_hcev,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.hcl_nroreg_hcev = lcrCodigoGen;
                        _context.AddToHclregiseventos(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = string.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                    "'HCL-HCLREGISEVENTOS': Maestro historial actividades clinicas paciente en Maestro Secuenciales.");
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Sistema.Modelo.HclModeloHistorialEventos: fcrAddRegistro");
            }

            return lcrCodigoGen;

        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(HclModeloHistorialEventos tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.hcl_nroreg_hcev == tobjModelo.Hcl_nroreg_hcev);
                if (lobjRegistro != null)
                {
                    // Variable global del sistema indica tipo guardado
                    tobjModelo.Hcl_archiv_hcev = String.IsNullOrWhiteSpace(tobjModelo.Hcl_archiv_hcev) ? oApp.gcrAppBdatosArchvioGuardarDatos : tobjModelo.Hcl_archiv_hcev;

                    lobjRegistro.hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev;
                    lobjRegistro.hcl_codreg_hcca = tobjModelo.Hcl_codreg_hcca;
                    lobjRegistro.hcl_desreg_hcev = tobjModelo.Hcl_desreg_hcev;
                    lobjRegistro.hcl_secreg_hcev = tobjModelo.Hcl_secreg_hcev;
                    lobjRegistro.hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.cit_codasi_mcit = tobjModelo.Cit_codasi_mcit;
                    lobjRegistro.fcm_secreg_dfac = tobjModelo.Fcm_secreg_dfac;
                    lobjRegistro.hcl_codaux_hcev = tobjModelo.Hcl_codaux_hcev;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.hcl_gesfec_hcev = (DateTime)tobjModelo.Hcl_gesfec_hcev;
                    lobjRegistro.hcl_geshor_hcev = (Decimal)tobjModelo.Hcl_geshor_hcev;
                    lobjRegistro.hcl_sisfec_hcev = (DateTime)tobjModelo.Hcl_sisfec_hcev;
                    lobjRegistro.hcl_sishor_hcev = (Decimal)tobjModelo.Hcl_sishor_hcev;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.grp_idepla_grpl = tobjModelo.Grp_idepla_grpl;
                    lobjRegistro.grp_idepla_grpv = tobjModelo.Grp_idepla_grpv;
                    lobjRegistro.hcl_keydat_hcev = tobjModelo.Hcl_keydat_hcev;
                    lobjRegistro.hcl_xmldat_hcev = tobjModelo.Hcl_xmldat_hcev;
                    lobjRegistro.hcl_xmltmp_hcev = tobjModelo.Hcl_xmltmp_hcev;
                    lobjRegistro.hcl_xmlcom_hcev = tobjModelo.Hcl_xmlcom_hcev;
                    lobjRegistro.hcl_conobj_hcev = (int)tobjModelo.Hcl_conobj_hcev;
                    lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                    lobjRegistro.hcl_archiv_hcev = tobjModelo.Hcl_archiv_hcev;
                    lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Complementar registros de historia clinica Admision e Id unico
        /// <summary>
        /// <para>Complementar registros del historial clinico con datos desde</para>
        /// <para>Apertura de historia clinica, registro admision e Id unico del paciente en sistema</para>
        /// </summary>
        public static void fcvActualizarDatosHistoria(HclModeloHistorialEventos tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.hcl_nroreg_hcev == tobjModelo.Hcl_nroreg_hcev);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.cit_codasi_mcit = tobjModelo.Cit_codasi_mcit;
                    lobjRegistro.fcm_secreg_dfac = tobjModelo.Fcm_secreg_dfac;
                    lobjRegistro.hcl_codaux_hcev = tobjModelo.Hcl_codaux_hcev;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Eliminar registro
        public static bool flgEliminar(string tcrCodigo)
        {
            var llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.hcl_nroreg_hcev == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                    llgReturn = true;
                }
            }
            return llgReturn;
        }
        #endregion
        #region Complementar registros de historia clinica Admision e Id unico
        /// <summary>
        /// <para>Genera un nuevo numero secuencial para objetos dentro del evento</para>
        /// <para>cuadno el parametro es tnuValor = 0, se genera un nuevo secuencial,</para>
        /// <para>si el valor es mayor, este se remplaza en el maestro secuenciales de objetos del evento</para>
        /// </summary>
        public static int fnuGenSecuencialObjetosEvento(String tcrCodigoEvento, int tnuValor)
        {
            var lnuReturn = tnuValor;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.hcl_nroreg_hcev == tcrCodigoEvento);
                if (lobjRegistro != null)
                {
                    if (tnuValor <= 0)
                    {
                        // se genera nuevo secuencial
                        lobjRegistro.hcl_conobj_hcev = lobjRegistro.hcl_conobj_hcev + 1;
                    }
                    else
                    {
                        lobjRegistro.hcl_conobj_hcev = tnuValor;
                    }
                    lnuReturn = (int)lobjRegistro.hcl_conobj_hcev;
                    _context.SaveChanges();
                }
            }
            return lnuReturn;
        }
        #endregion
        #region Buscar HCLREGISEVENTOS: Logica
        /// <summary>
        /// <para>TABLA: hclregiseventos</para>
        /// <para>TITULO: Maestro registro secuencial de eventos historial</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro secuencial de cada eventos realizados al paciente
        /// durante la estancia el la institucion (genera el historial
        /// de la historia clinica)
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregiseventos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregiseventos.FirstOrDefault(p => p.hcl_nroreg_hcev == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region flsBuscarHistorialEventos: Listar Registros
        /// <summary>
        /// <para>tcrTipoId:</para>
        /// <para>HC = Codigo de la Historia clinica</para>
        /// <para>HR = Codigo registro unico en historial</para>
        /// <para>IG = Codigo unico del paciente en el sistema</para>
        /// <para>ID = Numero de identificacion del paciente en el sistema</para>
        /// <para>AX = Codigo auxiliar en campo Hcl_codaux_hcev</para>
        /// </summary>
        public static List<HclModeloHistorialEventos> flsBuscarHistorialEventos(String tcrTipoId, String tcrIdCodigo)
        {
            //List<ModeloHistorialEventos> lobConsulta = null;
            using (_context = new DbAplicacion())
            {
                if (tcrTipoId == "HC")//Codigo de la Historia clinica
                {
                    #region Registros
                    var lobConsulta = from hclregiseventos in _context.Hclregiseventos
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregiseventos.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join fcmcenproduccio in _context.Fcmcenproduccio on hclregiseventos.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join hcltiporegactiv in _context.Hcltiporegactiv on hclregiseventos.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                      where hclregiseventos.hcl_nrohis_hicl == tcrIdCodigo
                                      orderby hclregiseventos.hcl_secreg_hcev descending
                                      select new HclModeloHistorialEventos
                                      {
                                          Hcl_nroreg_hcev = hclregiseventos.hcl_nroreg_hcev,
                                          Hcl_desreg_hcev = hclregiseventos.hcl_desreg_hcev,
                                          Hcl_secreg_hcev = (long)hclregiseventos.hcl_secreg_hcev,
                                          Hcl_nrohis_hicl = hclregiseventos.hcl_nrohis_hicl,
                                          Adm_secadm_rgad = hclregiseventos.adm_secadm_rgad,
                                          Cit_codasi_mcit = hclregiseventos.cit_codasi_mcit,
                                          Fcm_secreg_dfac = hclregiseventos.fcm_secreg_dfac,
                                          Hcl_codaux_hcev = hclregiseventos.hcl_codaux_hcev,
                                          Sia_idesec_usua = hclregiseventos.sia_idesec_usua,
                                          Sia_tipide_tide = hclregiseventos.sia_tipide_tide,
                                          Sia_nroide_usua = hclregiseventos.sia_nroide_usua,
                                          Hcl_gesfec_hcev = (DateTime)hclregiseventos.hcl_gesfec_hcev,
                                          Hcl_geshor_hcev = (Decimal)hclregiseventos.hcl_geshor_hcev,
                                          Hcl_sisfec_hcev = (DateTime)hclregiseventos.hcl_sisfec_hcev,
                                          Hcl_sishor_hcev = (Decimal)hclregiseventos.hcl_sishor_hcev,
                                          Sia_codpfa_prof = hclregiseventos.sia_codpfa_prof,
                                          Grp_idepla_grpl = hclregiseventos.grp_idepla_grpl,
                                          Grp_idepla_grpv = hclregiseventos.grp_idepla_grpv,
                                          Hcl_keydat_hcev = hclregiseventos.hcl_keydat_hcev,
                                          Hcl_xmldat_hcev = hclregiseventos.hcl_xmldat_hcev,
                                          Hcl_xmltmp_hcev = hclregiseventos.hcl_xmltmp_hcev,
                                          Hcl_xmlcom_hcev = hclregiseventos.hcl_xmlcom_hcev,
                                          Hcl_conobj_hcev = (int)hclregiseventos.hcl_conobj_hcev,
                                          Fcm_codcpr_cpro = hclregiseventos.fcm_codcpr_cpro,
                                          Hcl_codreg_hcca = hclregiseventos.hcl_codreg_hcca,
                                          Hcl_archiv_hcev = hclregiseventos.hcl_archiv_hcev,
                                          Sis_estpro_espr = hclregiseventos.sis_estpro_espr,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Hcl_imagen_hcca = hcca.hcl_imagen_hcca,
                                          Hcl_icolor_hcca = hcca.hcl_icolor_hcca,
                                          Grp_despla_grpl = _context.Grpmaeplantilla.FirstOrDefault(rxp => rxp.grp_idepla_grpl == hclregiseventos.grp_idepla_grpl).grp_despla_grpl,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == hclregiseventos.sis_estpro_espr).sis_despro_espr,
                                          GestionEstadoRegistro = "XX",
                                      };
                    #endregion
                    return lobConsulta.ToList();
                }
                else if (tcrTipoId == "HR")// Codigo registro unico en historial  devuelve un solo registro
                {
                    #region Registros
                    var lobConsulta = from hclregiseventos in _context.Hclregiseventos
                                      join siausuarioatend in _context.Siausuarioatend on hclregiseventos.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregiseventos.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join fcmcenproduccio in _context.Fcmcenproduccio on hclregiseventos.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join hcltiporegactiv in _context.Hcltiporegactiv on hclregiseventos.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                      where hclregiseventos.hcl_nroreg_hcev == tcrIdCodigo
                                      orderby hclregiseventos.hcl_secreg_hcev descending
                                      select new HclModeloHistorialEventos
                                      {
                                          Hcl_nroreg_hcev = hclregiseventos.hcl_nroreg_hcev,
                                          Hcl_desreg_hcev = hclregiseventos.hcl_desreg_hcev,
                                          Hcl_secreg_hcev = (long)hclregiseventos.hcl_secreg_hcev,
                                          Hcl_nrohis_hicl = hclregiseventos.hcl_nrohis_hicl,
                                          Adm_secadm_rgad = hclregiseventos.adm_secadm_rgad,
                                          Cit_codasi_mcit = hclregiseventos.cit_codasi_mcit,
                                          Fcm_secreg_dfac = hclregiseventos.fcm_secreg_dfac,
                                          Hcl_codaux_hcev = hclregiseventos.hcl_codaux_hcev,
                                          Sia_idesec_usua = hclregiseventos.sia_idesec_usua,
                                          Sia_tipide_tide = hclregiseventos.sia_tipide_tide,
                                          Sia_nroide_usua = hclregiseventos.sia_nroide_usua,
                                          Hcl_gesfec_hcev = (DateTime)hclregiseventos.hcl_gesfec_hcev,
                                          Hcl_geshor_hcev = (Decimal)hclregiseventos.hcl_geshor_hcev,
                                          Hcl_sisfec_hcev = (DateTime)hclregiseventos.hcl_sisfec_hcev,
                                          Hcl_sishor_hcev = (Decimal)hclregiseventos.hcl_sishor_hcev,
                                          Sia_codpfa_prof = hclregiseventos.sia_codpfa_prof,
                                          Grp_idepla_grpl = hclregiseventos.grp_idepla_grpl,
                                          Grp_idepla_grpv = hclregiseventos.grp_idepla_grpv,
                                          Hcl_keydat_hcev = hclregiseventos.hcl_keydat_hcev,
                                          Hcl_xmldat_hcev = hclregiseventos.hcl_xmldat_hcev,
                                          Hcl_xmltmp_hcev = hclregiseventos.hcl_xmltmp_hcev,
                                          Hcl_xmlcom_hcev = hclregiseventos.hcl_xmlcom_hcev,
                                          Hcl_conobj_hcev = (int)hclregiseventos.hcl_conobj_hcev,
                                          Fcm_codcpr_cpro = hclregiseventos.fcm_codcpr_cpro,
                                          Hcl_codreg_hcca = hclregiseventos.hcl_codreg_hcca,
                                          Hcl_archiv_hcev = hclregiseventos.hcl_archiv_hcev,
                                          Sis_estpro_espr = hclregiseventos.sis_estpro_espr,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Hcl_imagen_hcca = hcca.hcl_imagen_hcca,
                                          Hcl_icolor_hcca = hcca.hcl_icolor_hcca,
                                          Grp_despla_grpl = _context.Grpmaeplantilla.FirstOrDefault(rxp => rxp.grp_idepla_grpl == hclregiseventos.grp_idepla_grpl).grp_despla_grpl,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == hclregiseventos.sis_estpro_espr).sis_despro_espr,
                                          GestionEstadoRegistro = "XX",
                                      };
                    #endregion
                    return lobConsulta.ToList();
                }
                else if (tcrTipoId == "IG")//Codigo unico del paciente en el sistema
                {
                    #region Registros
                    var lobConsulta = from hclregiseventos in _context.Hclregiseventos
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregiseventos.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join fcmcenproduccio in _context.Fcmcenproduccio on hclregiseventos.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join hcltiporegactiv in _context.Hcltiporegactiv on hclregiseventos.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                      where hclregiseventos.sia_idesec_usua == tcrIdCodigo
                                      orderby hclregiseventos.hcl_secreg_hcev descending
                                      select new HclModeloHistorialEventos
                                      {
                                          Hcl_nroreg_hcev = hclregiseventos.hcl_nroreg_hcev,
                                          Hcl_desreg_hcev = hclregiseventos.hcl_desreg_hcev,
                                          Hcl_secreg_hcev = (int)hclregiseventos.hcl_secreg_hcev,
                                          Hcl_nrohis_hicl = hclregiseventos.hcl_nrohis_hicl,
                                          Adm_secadm_rgad = hclregiseventos.adm_secadm_rgad,
                                          Cit_codasi_mcit = hclregiseventos.cit_codasi_mcit,
                                          Fcm_secreg_dfac = hclregiseventos.fcm_secreg_dfac,
                                          Hcl_codaux_hcev = hclregiseventos.hcl_codaux_hcev,
                                          Sia_idesec_usua = hclregiseventos.sia_idesec_usua,
                                          Sia_tipide_tide = hclregiseventos.sia_tipide_tide,
                                          Sia_nroide_usua = hclregiseventos.sia_nroide_usua,
                                          Hcl_gesfec_hcev = (DateTime)hclregiseventos.hcl_gesfec_hcev,
                                          Hcl_geshor_hcev = (Decimal)hclregiseventos.hcl_geshor_hcev,
                                          Hcl_sisfec_hcev = (DateTime)hclregiseventos.hcl_sisfec_hcev,
                                          Hcl_sishor_hcev = (Decimal)hclregiseventos.hcl_sishor_hcev,
                                          Sia_codpfa_prof = hclregiseventos.sia_codpfa_prof,
                                          Grp_idepla_grpl = hclregiseventos.grp_idepla_grpl,
                                          Grp_idepla_grpv = hclregiseventos.grp_idepla_grpv,
                                          Hcl_keydat_hcev = hclregiseventos.hcl_keydat_hcev,
                                          Hcl_xmldat_hcev = hclregiseventos.hcl_xmldat_hcev,
                                          Hcl_xmltmp_hcev = hclregiseventos.hcl_xmltmp_hcev,
                                          Hcl_xmlcom_hcev = hclregiseventos.hcl_xmlcom_hcev,
                                          Hcl_conobj_hcev = (int)hclregiseventos.hcl_conobj_hcev,
                                          Fcm_codcpr_cpro = hclregiseventos.fcm_codcpr_cpro,
                                          Hcl_codreg_hcca = hclregiseventos.hcl_codreg_hcca,
                                          Hcl_archiv_hcev = hclregiseventos.hcl_archiv_hcev,
                                          Sis_estpro_espr = hclregiseventos.sis_estpro_espr,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Hcl_imagen_hcca = hcca.hcl_imagen_hcca,
                                          Hcl_icolor_hcca = hcca.hcl_icolor_hcca,
                                          Grp_despla_grpl = _context.Grpmaeplantilla.FirstOrDefault(rxp => rxp.grp_idepla_grpl == hclregiseventos.grp_idepla_grpl).grp_despla_grpl,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == hclregiseventos.sis_estpro_espr).sis_despro_espr,
                                          GestionEstadoRegistro = "XX",
                                      };
                    #endregion

                    return lobConsulta.ToList();
                }
                else if (tcrTipoId == "ID")// Identificacion del paciente
                {
                    #region Registros
                    var lobConsulta = from hclregiseventos in _context.Hclregiseventos
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregiseventos.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join fcmcenproduccio in _context.Fcmcenproduccio on hclregiseventos.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join hcltiporegactiv in _context.Hcltiporegactiv on hclregiseventos.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                      where hclregiseventos.sia_nroide_usua == tcrIdCodigo
                                      orderby hclregiseventos.hcl_secreg_hcev descending
                                      select new HclModeloHistorialEventos
                                      {
                                          Hcl_nroreg_hcev = hclregiseventos.hcl_nroreg_hcev,
                                          Hcl_desreg_hcev = hclregiseventos.hcl_desreg_hcev,
                                          Hcl_secreg_hcev = (long)hclregiseventos.hcl_secreg_hcev,
                                          Hcl_nrohis_hicl = hclregiseventos.hcl_nrohis_hicl,
                                          Adm_secadm_rgad = hclregiseventos.adm_secadm_rgad,
                                          Cit_codasi_mcit = hclregiseventos.cit_codasi_mcit,
                                          Fcm_secreg_dfac = hclregiseventos.fcm_secreg_dfac,
                                          Hcl_codaux_hcev = hclregiseventos.hcl_codaux_hcev,
                                          Sia_idesec_usua = hclregiseventos.sia_idesec_usua,
                                          Sia_tipide_tide = hclregiseventos.sia_tipide_tide,
                                          Sia_nroide_usua = hclregiseventos.sia_nroide_usua,
                                          Hcl_gesfec_hcev = (DateTime)hclregiseventos.hcl_gesfec_hcev,
                                          Hcl_geshor_hcev = (Decimal)hclregiseventos.hcl_geshor_hcev,
                                          Hcl_sisfec_hcev = (DateTime)hclregiseventos.hcl_sisfec_hcev,
                                          Hcl_sishor_hcev = (Decimal)hclregiseventos.hcl_sishor_hcev,
                                          Sia_codpfa_prof = hclregiseventos.sia_codpfa_prof,
                                          Grp_idepla_grpl = hclregiseventos.grp_idepla_grpl,
                                          Grp_idepla_grpv = hclregiseventos.grp_idepla_grpv,
                                          Hcl_keydat_hcev = hclregiseventos.hcl_keydat_hcev,
                                          Hcl_xmldat_hcev = hclregiseventos.hcl_xmldat_hcev,
                                          Hcl_xmltmp_hcev = hclregiseventos.hcl_xmltmp_hcev,
                                          Hcl_xmlcom_hcev = hclregiseventos.hcl_xmlcom_hcev,
                                          Hcl_conobj_hcev = (int)hclregiseventos.hcl_conobj_hcev,
                                          Fcm_codcpr_cpro = hclregiseventos.fcm_codcpr_cpro,
                                          Hcl_codreg_hcca = hclregiseventos.hcl_codreg_hcca,
                                          Hcl_archiv_hcev = hclregiseventos.hcl_archiv_hcev,
                                          Sis_estpro_espr = hclregiseventos.sis_estpro_espr,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Hcl_imagen_hcca = hcca.hcl_imagen_hcca,
                                          Hcl_icolor_hcca = hcca.hcl_icolor_hcca,
                                          Grp_despla_grpl = _context.Grpmaeplantilla.FirstOrDefault(rxp => rxp.grp_idepla_grpl == hclregiseventos.grp_idepla_grpl).grp_despla_grpl,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == hclregiseventos.sis_estpro_espr).sis_despro_espr,
                                          GestionEstadoRegistro = "XX",
                                      };
                    #endregion
                    return lobConsulta.ToList();
                }
                else // Codigo auxiliar "AX"
                {
                    #region Registros
                    var lobConsulta = from hclregiseventos in _context.Hclregiseventos
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregiseventos.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join fcmcenproduccio in _context.Fcmcenproduccio on hclregiseventos.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join hcltiporegactiv in _context.Hcltiporegactiv on hclregiseventos.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                      where hclregiseventos.hcl_codaux_hcev == tcrIdCodigo
                                      orderby hclregiseventos.hcl_secreg_hcev descending
                                      select new HclModeloHistorialEventos
                                      {
                                          Hcl_nroreg_hcev = hclregiseventos.hcl_nroreg_hcev,
                                          Hcl_desreg_hcev = hclregiseventos.hcl_desreg_hcev,
                                          Hcl_secreg_hcev = (long)hclregiseventos.hcl_secreg_hcev,
                                          Hcl_nrohis_hicl = hclregiseventos.hcl_nrohis_hicl,
                                          Adm_secadm_rgad = hclregiseventos.adm_secadm_rgad,
                                          Cit_codasi_mcit = hclregiseventos.cit_codasi_mcit,
                                          Fcm_secreg_dfac = hclregiseventos.fcm_secreg_dfac,
                                          Hcl_codaux_hcev = hclregiseventos.hcl_codaux_hcev,
                                          Sia_idesec_usua = hclregiseventos.sia_idesec_usua,
                                          Sia_tipide_tide = hclregiseventos.sia_tipide_tide,
                                          Sia_nroide_usua = hclregiseventos.sia_nroide_usua,
                                          Hcl_gesfec_hcev = (DateTime)hclregiseventos.hcl_gesfec_hcev,
                                          Hcl_geshor_hcev = (Decimal)hclregiseventos.hcl_geshor_hcev,
                                          Hcl_sisfec_hcev = (DateTime)hclregiseventos.hcl_sisfec_hcev,
                                          Hcl_sishor_hcev = (Decimal)hclregiseventos.hcl_sishor_hcev,
                                          Sia_codpfa_prof = hclregiseventos.sia_codpfa_prof,
                                          Grp_idepla_grpl = hclregiseventos.grp_idepla_grpl,
                                          Grp_idepla_grpv = hclregiseventos.grp_idepla_grpv,
                                          Hcl_keydat_hcev = hclregiseventos.hcl_keydat_hcev,
                                          Hcl_xmldat_hcev = hclregiseventos.hcl_xmldat_hcev,
                                          Hcl_xmltmp_hcev = hclregiseventos.hcl_xmltmp_hcev,
                                          Hcl_xmlcom_hcev = hclregiseventos.hcl_xmlcom_hcev,
                                          Hcl_conobj_hcev = (int)hclregiseventos.hcl_conobj_hcev,
                                          Fcm_codcpr_cpro = hclregiseventos.fcm_codcpr_cpro,
                                          Hcl_codreg_hcca = hclregiseventos.hcl_codreg_hcca,
                                          Hcl_archiv_hcev = hclregiseventos.hcl_archiv_hcev,
                                          Sis_estpro_espr = hclregiseventos.sis_estpro_espr,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Hcl_imagen_hcca = hcca.hcl_imagen_hcca,
                                          Hcl_icolor_hcca = hcca.hcl_icolor_hcca,
                                          Grp_despla_grpl = _context.Grpmaeplantilla.FirstOrDefault(rxp => rxp.grp_idepla_grpl == hclregiseventos.grp_idepla_grpl).grp_despla_grpl,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == hclregiseventos.sis_estpro_espr).sis_despro_espr,
                                          GestionEstadoRegistro = "XX",
                                      };
                    #endregion
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region flsTipoActividadHistorial: Consultar registro en historial segun clsificacion actividad medica
        /// <summary>
        /// <para>tcrTipoActividad ejemplo:</para>
        /// <para>APE-HCL-GENE = Apertura Historia clinica general</para>
        /// <para>APE-HCL-ODON = Apertura Historia clinica odontologia</para>
        /// <para>ACT-HCL-GENE = Actividad clinica general</para>
        /// <para>tcrIdPaciente: Codigo unico del paciente o usuario en el sistema</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Devuelve una lista de registros para un paciente segun  codigo clasificacion tipo actividad (tcrTipoActividad)</para>
        /// </summary>
        public static List<HclModeloHistorialEventos> flsTipoActividadHistorial(String tcrTipoActividad, String tcrIdPaciente)
        {
            //List<ModeloHistorialEventos> lobConsulta = null;
            using (_context = new DbAplicacion())
            {
                #region Registros
                var lobConsulta = from hclregiseventos in _context.Hclregiseventos
                                  join siamaeprofsalud in _context.Siamaeprofsalud on hclregiseventos.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                  join fcmcenproduccio in _context.Fcmcenproduccio on hclregiseventos.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                  join hcltiporegactiv in _context.Hcltiporegactiv on hclregiseventos.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                  from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                  from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                  from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                  where hclregiseventos.sia_idesec_usua == tcrIdPaciente && hclregiseventos.hcl_codreg_hcca == tcrTipoActividad
                                  orderby hclregiseventos.hcl_secreg_hcev descending
                                  select new HclModeloHistorialEventos
                                  {
                                      Hcl_nroreg_hcev = hclregiseventos.hcl_nroreg_hcev,
                                      Hcl_codreg_hcca = hclregiseventos.hcl_codreg_hcca,
                                      Hcl_desreg_hcev = hclregiseventos.hcl_desreg_hcev,
                                      Hcl_secreg_hcev = (long)hclregiseventos.hcl_secreg_hcev,
                                      Hcl_nrohis_hicl = hclregiseventos.hcl_nrohis_hicl,
                                      Adm_secadm_rgad = hclregiseventos.adm_secadm_rgad,
                                      Cit_codasi_mcit = hclregiseventos.cit_codasi_mcit,
                                      Sia_idesec_usua = hclregiseventos.sia_idesec_usua,
                                      Sia_tipide_tide = hclregiseventos.sia_tipide_tide,
                                      Sia_nroide_usua = hclregiseventos.sia_nroide_usua,
                                      Hcl_gesfec_hcev = (DateTime)hclregiseventos.hcl_gesfec_hcev,
                                      Hcl_geshor_hcev = (Decimal)hclregiseventos.hcl_geshor_hcev,
                                      Hcl_sisfec_hcev = (DateTime)hclregiseventos.hcl_sisfec_hcev,
                                      Hcl_sishor_hcev = (Decimal)hclregiseventos.hcl_sishor_hcev,
                                      Sia_codpfa_prof = hclregiseventos.sia_codpfa_prof,
                                      Grp_idepla_grpl = hclregiseventos.grp_idepla_grpl,
                                      Grp_idepla_grpv = hclregiseventos.grp_idepla_grpv,
                                      Hcl_keydat_hcev = hclregiseventos.hcl_keydat_hcev,
                                      Hcl_xmldat_hcev = hclregiseventos.hcl_xmldat_hcev,
                                      Hcl_xmltmp_hcev = hclregiseventos.hcl_xmltmp_hcev,
                                      Hcl_xmlcom_hcev = hclregiseventos.hcl_xmlcom_hcev,
                                      Hcl_conobj_hcev = (int)hclregiseventos.hcl_conobj_hcev,
                                      Fcm_codcpr_cpro = hclregiseventos.fcm_codcpr_cpro,
                                      Hcl_archiv_hcev = hclregiseventos.hcl_archiv_hcev,
                                      Sis_estpro_espr = hclregiseventos.sis_estpro_espr,
                                      Sia_nompro_prof = prof.sia_nompro_prof,
                                      Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                      Hcl_imagen_hcca = hcca.hcl_imagen_hcca,
                                      Hcl_icolor_hcca = hcca.hcl_icolor_hcca,
                                      Grp_despla_grpl = _context.Grpmaeplantilla.FirstOrDefault(rxp => rxp.grp_idepla_grpl == hclregiseventos.grp_idepla_grpl).grp_despla_grpl,
                                      Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == hclregiseventos.sis_estpro_espr).sis_despro_espr,
                                      GestionEstadoRegistro ="XX",
                                  };
                #endregion
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region flgGenerarActividadUnica: Generar registro para atencion en historia clinica
        /// <summary>
        /// <para>tcrTipoActividad ejemplo:</para>
        /// <para>HCL-APERTURA-GENERAL Apertura Historia clinica general</para>
        /// <para>HCL-APERTURA-ODONT Apertura Historia clinica odontologia</para>
        /// <para>tcrIdPaciente: Codigo unico del paciente o usuario en el sistema</para>
        /// <para>Generar registro para atencion paciente en historial segun tcrTipoActividad clasificada unica</para>
        /// </summary>
        public static String fcrGenerarActividadUnica(String tcrTipoActividad, HclModeloHistorialEventos tobRegistro, String tcrIdPaciente)
        {
            var llgReturn = String.Empty;
            try
            {
                var lobReg = flsTipoActividadHistorial(tcrTipoActividad,tcrIdPaciente);
                if (lobReg.Count==0)
                {
                    // Generar registro de actividad en historia clinica
                    var lobTipoAct = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(tcrTipoActividad);
                    var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobTipoAct.grp_idepla_grpl);

                    tobRegistro.Hcl_desreg_hcev = lobTipoAct.hcl_desreg_hcca;
                    tobRegistro.Hcl_codreg_hcca = lobTipoAct.hcl_codreg_hcca;
                    tobRegistro.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                    tobRegistro.Grp_idepla_grpv = loPlant.grp_idepla_grpv;
                    tobRegistro.Sis_estpro_espr = "1";  // abierto por defecto
                    //- Registrar en base de daos
                    llgReturn = HclModeloHistorialEventos.fcrAddRegistro(tobRegistro);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgGenerarActividadUnica");
            }
            return llgReturn;
        }
        #endregion
        #region fobRegUnicaActividadHistorial: Consultar registro unico en historial clsificacion actividad y Codigo Admision
        /// <summary>
        /// <para>Consultar registro unico en historial clsificacion actividad y Codigo Admision</para>
        /// <para>tcrCodigoActividad</para>
        /// <para>Ejemplo:</para>
        /// <para>APE-HCL-GENE = Apertura Historia clinica general</para>
        /// <para>HCL-EVOLU-MEDI-AMBUL = evolucion medica ambulatoria</para>
        /// <para>ACT-HCL-GENE = Actividad clinica general</para>
        /// <para>tcrIdPaciente: Codigo unico del paciente o usuario en el sistema</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Devuelve un registro unico del maestro eventos medicos segun  parametro clasificacion tipo actividad (tcrCodigoActividad)</para>
        /// <para> y Codigo amision paciente</para>
        /// </summary>
        public static HclModeloHistorialEventos fobRegUnicaActividadHistorial(String tcrCodigoAdmision, String tcrCodigoActividad)
        {
            using (_context = new DbAplicacion())
            {
                #region Registros
                var lobConsulta = (from hclregiseventos in _context.Hclregiseventos
                                  join siamaeprofsalud in _context.Siamaeprofsalud on hclregiseventos.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                  join hcltiporegactiv in _context.Hcltiporegactiv on hclregiseventos.hcl_codreg_hcca equals hcltiporegactiv.hcl_codreg_hcca into tmhcltiporegactiv
                                  from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                  from hcca in tmhcltiporegactiv.DefaultIfEmpty()
                                  where hclregiseventos.adm_secadm_rgad == tcrCodigoAdmision && hclregiseventos.hcl_codreg_hcca == tcrCodigoActividad
                                  select new HclModeloHistorialEventos
                                  {
                                      Hcl_nroreg_hcev = hclregiseventos.hcl_nroreg_hcev,
                                      Hcl_codreg_hcca = hclregiseventos.hcl_codreg_hcca,
                                      Hcl_desreg_hcev = hclregiseventos.hcl_desreg_hcev,
                                      Hcl_secreg_hcev = (long)hclregiseventos.hcl_secreg_hcev,
                                      Hcl_nrohis_hicl = hclregiseventos.hcl_nrohis_hicl,
                                      Adm_secadm_rgad = hclregiseventos.adm_secadm_rgad,
                                      Cit_codasi_mcit = hclregiseventos.cit_codasi_mcit,
                                      Sia_idesec_usua = hclregiseventos.sia_idesec_usua,
                                      Sia_tipide_tide = hclregiseventos.sia_tipide_tide,
                                      Sia_nroide_usua = hclregiseventos.sia_nroide_usua,
                                      Hcl_gesfec_hcev = (DateTime)hclregiseventos.hcl_gesfec_hcev,
                                      Hcl_geshor_hcev = (Decimal)hclregiseventos.hcl_geshor_hcev,
                                      Hcl_sisfec_hcev = (DateTime)hclregiseventos.hcl_sisfec_hcev,
                                      Hcl_sishor_hcev = (Decimal)hclregiseventos.hcl_sishor_hcev,
                                      Sia_codpfa_prof = hclregiseventos.sia_codpfa_prof,
                                      Grp_idepla_grpl = hclregiseventos.grp_idepla_grpl,
                                      Grp_idepla_grpv = hclregiseventos.grp_idepla_grpv,
                                      Hcl_keydat_hcev = hclregiseventos.hcl_keydat_hcev,
                                      Hcl_xmldat_hcev = hclregiseventos.hcl_xmldat_hcev,
                                      Hcl_xmltmp_hcev = hclregiseventos.hcl_xmltmp_hcev,
                                      Hcl_xmlcom_hcev = hclregiseventos.hcl_xmlcom_hcev,
                                      Hcl_conobj_hcev = (int)hclregiseventos.hcl_conobj_hcev,
                                      Fcm_codcpr_cpro = hclregiseventos.fcm_codcpr_cpro,
                                      Hcl_archiv_hcev = hclregiseventos.hcl_archiv_hcev,
                                      Sis_estpro_espr = hclregiseventos.sis_estpro_espr,
                                      Sia_nompro_prof = prof.sia_nompro_prof,
                                      Hcl_imagen_hcca = hcca.hcl_imagen_hcca,
                                      Hcl_icolor_hcca = hcca.hcl_icolor_hcca,
                                      GestionEstadoRegistro = "XX",
                                  }).ToList().FirstOrDefault();
                #endregion
                return lobConsulta;
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Tabla hclregordeserms: Maestro ordenes servicios intrahospitalarios
    /// </summary>
    public class ModeloHclregordeserms : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_nroreg_hcms: Codigo registro
        private String _hcl_nroreg_hcms;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: hcl_nroreg_hcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial unico registro maestro en la orden que los
        /// agrupa
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcms
        {
            get { return _hcl_nroreg_hcms; }
            set
            {
                if (_hcl_nroreg_hcms == value) return;
                _hcl_nroreg_hcms = value;
                OnPropertyChanged("Hcl_nroreg_hcms");
            }
        }
        #endregion
        #region Hcl_secreg_hcms: Secuencial evento
        private long _hcl_secreg_hcms;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Secuencial evento</para>
        /// <para>NOMBRE: hcl_secreg_hcms (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del registro medico  para organizar la vista
        /// cronologica
        /// </para>
        /// </summary>
        public long Hcl_secreg_hcms
        {
            get { return _hcl_secreg_hcms; }
            set
            {
                if (_hcl_secreg_hcms == value) return;
                _hcl_secreg_hcms = value;
                OnPropertyChanged("Hcl_secreg_hcms");
            }
        }
        #endregion
        #region Hcl_nroreg_hcev: Codigo Evento medico
        private String _hcl_nroreg_hcev;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: hcl_nroreg_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código secuencial actividad medica en historial medico del
        /// paciente
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcev
        {
            get { return _hcl_nroreg_hcev; }
            set
            {
                if (_hcl_nroreg_hcev == value) return;
                _hcl_nroreg_hcev = value;
                OnPropertyChanged("Hcl_nroreg_hcev");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Hcl_tipreg_hctr: Tipo registro actividad
        private String _hcl_tipreg_hctr;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: hcltiporegserms</para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: hcl_tipreg_hctr (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Codigo clasificacion tipo registro: "SERV" = ordenes de Servicios "HCON" = Hoja de consumo y otros</para>
        /// </summary>
        public String Hcl_tipreg_hctr
        {
            get { return _hcl_tipreg_hctr; }
            set
            {
                if (_hcl_tipreg_hctr == value) return;
                _hcl_tipreg_hctr = value;
                OnPropertyChanged("Hcl_tipreg_hctr");
            }
        }
        #endregion
        #region Sia_codare_aser: Código Área de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Hcl_gesfec_hcms: Fecha servicio
        private DateTime _hcl_gesfec_hcms;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: hcl_gesfec_hcms (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud del servicio al paciente
        /// </para>
        /// </summary>
        public DateTime Hcl_gesfec_hcms
        {
            get { return _hcl_gesfec_hcms; }
            set
            {
                if (_hcl_gesfec_hcms == value) return;
                _hcl_gesfec_hcms = value;
                OnPropertyChanged("Hcl_gesfec_hcms");
            }
        }
        #endregion
        #region Hcl_geshor_hcms: Hora servicio
        private Decimal _hcl_geshor_hcms;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: hcl_geshor_hcms (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Hora solicitud del servicio al paciente en formato militar
        /// (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_geshor_hcms
        {
            get { return _hcl_geshor_hcms; }
            set
            {
                if (_hcl_geshor_hcms == value) return;
                _hcl_geshor_hcms = value;
                OnPropertyChanged("Hcl_geshor_hcms");
            }
        }
        #endregion
        #region Hcl_tiptur_hctu: Codigo turno
        private String _hcl_tiptur_hctu;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Codigo turno</para>
        /// <para>NOMBRE: hcl_tiptur_hctu (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion turnos diarios para la prestacion de servicios
        /// medicos
        /// </para>
        /// </summary>
        public String Hcl_tiptur_hctu
        {
            get { return _hcl_tiptur_hctu; }
            set
            {
                if (_hcl_tiptur_hctu == value) return;
                _hcl_tiptur_hctu = value;
                OnPropertyChanged("Hcl_tiptur_hctu");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código del Profesional que autoriza el servicio o medicamento
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
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        #region Hcl_desreg_hcev: Descripción Evento
        private String _hcl_desreg_hcev;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Descripción Evento</para>
        /// <para>NOMBRE: hcl_desreg_hcev (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion evento medico
        /// </para>
        /// </summary>
        public String Hcl_desreg_hcev
        {
            get { return _hcl_desreg_hcev; }
            set
            {
                if (_hcl_desreg_hcev == value) return;
                _hcl_desreg_hcev = value;
                OnPropertyChanged("Hcl_desreg_hcev");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
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
        /// <para>TABLA: hclregordeserms</para>
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
        #region Hcl_desreg_hctr: Descripcion
        private String _hcl_desreg_hctr;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TABLA NATIVA: hcltiporegserms</para>
        /// <para>CAMPO: Descripcion</para>
        /// <para>NOMBRE: hcl_desreg_hctr (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion  clasificacion tipo registro actividad registrada
        /// al paciente en ordenes medicas
        /// </para>
        /// </summary>
        public String Hcl_desreg_hctr
        {
            get { return _hcl_desreg_hctr; }
            set
            {
                if (_hcl_desreg_hctr == value) return;
                _hcl_desreg_hctr = value;
                OnPropertyChanged("Hcl_desreg_hctr");
            }
        }
        #endregion
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
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
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
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
        /// <para>TABLA: hclregordeserms</para>
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
        #region Hcl_destur_hctu: Descripcion turno
        private String _hcl_destur_hctu;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Descripcion turno</para>
        /// <para>NOMBRE: hcl_destur_hctu (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion  clasificacion turnos diarios
        /// </para>
        /// </summary>
        public String Hcl_destur_hctu
        {
            get { return _hcl_destur_hctu; }
            set
            {
                if (_hcl_destur_hctu == value) return;
                _hcl_destur_hctu = value;
                OnPropertyChanged("Hcl_destur_hctu");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloHclregordeserms tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-HCLREGORDESERMS", "HCL", "Maestro ordenes servicios intrahospitalarios");
            if (!flgBuscarHclregordeserms(lcrCodigoGen))
            {
                var lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");

                var lcrFecha = tobjModelo.Hcl_gesfec_hcms.ToShortDateString();
                var lcrllHora = Funciones.fcrCompletarFormatoHora(tobjModelo.Hcl_geshor_hcms, lcrSeparadorDecimal);
                var lcrllave = lcrFecha.Substring(8, 2) + lcrFecha.Substring(3, 2) + lcrFecha.Substring(0, 2) + lcrllHora;
                var lnullaveIndice = Convert.ToInt64(lcrllave);

                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFhclregordeserms
                    {
                        #region cargar Registro
                        hcl_nroreg_hcms = tobjModelo.Hcl_nroreg_hcms,
                        hcl_secreg_hcms = lnullaveIndice,
                        hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        hcl_tipreg_hctr = tobjModelo.Hcl_tipreg_hctr,
                        sia_codare_aser = tobjModelo.Sia_codare_aser,
                        hcl_gesfec_hcms = tobjModelo.Hcl_gesfec_hcms,
                        hcl_geshor_hcms = tobjModelo.Hcl_geshor_hcms,
                        hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.hcl_nroreg_hcms = lcrCodigoGen;
                    _context.AddToHclregordeserms(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-HCLREGORDESERMS': Maestro ordenes servicios intrahospitalarios en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHclregordeserms tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserms.FirstOrDefault(p => p.hcl_nroreg_hcms == tobjModelo.Hcl_nroreg_hcms);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hcl_nroreg_hcms = tobjModelo.Hcl_nroreg_hcms;
                    lobjRegistro.hcl_secreg_hcms = tobjModelo.Hcl_secreg_hcms;
                    lobjRegistro.hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.hcl_tipreg_hctr = tobjModelo.Hcl_tipreg_hctr;
                    lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                    lobjRegistro.hcl_gesfec_hcms = (DateTime)tobjModelo.Hcl_gesfec_hcms;
                    lobjRegistro.hcl_geshor_hcms = (Decimal)tobjModelo.Hcl_geshor_hcms;
                    lobjRegistro.hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fcvActualizarEstadoRegistro: Modificar estado registro
        /// <summary>
        /// <para>Cambar estado registro a notas y evoluciones medicas que estan asociadas</para>
        /// <para>a un registro envento en el historial clinico o eliminar el registro</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrCodigoRegistro: Codigo del registro de la tabla maestra hclregordeserms</para>
        /// <para>tcrEstadoRegistro: Cambiar el estado de los registros asi: 1=Abierto 2=Confirmado 3=Anulado 4=Eliminar registro</para>
        /// </summary>
        public static void fcvActualizarEstadoRegistro(String tcrCodigoRegistro, String tcrEstadoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserms.FirstOrDefault(p => p.hcl_nroreg_hcms == tcrCodigoRegistro);
                if (lobjRegistro != null)
                {
                    if (tcrEstadoRegistro == "4") // Eliminar registro
                    {
                        _context.DeleteObject(lobjRegistro);
                    }
                    else
                    {
                        lobjRegistro.sis_estpro_espr = tcrEstadoRegistro;
                    }

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
                var lobjRegistro = _context.Hclregordeserms.FirstOrDefault(p => p.hcl_nroreg_hcms == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar HCLREGORDESERMS: Logica
        /// <summary>
        /// <para>TABLA: hclregordeserms</para>
        /// <para>TITULO: Maestro ordenes servicios intrahospitalarios</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro solicitude ordenes servicios intrahospitalarios, registro
        /// maestro  para ordenes de servicios y o medicamen, solicitud
        /// de examenes, Balance de liquidos, notas de enfermeria y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregordeserms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserms.FirstOrDefault(p => p.hcl_nroreg_hcms == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Consultar un registros
        /// <summary>
        /// <para>Devuelve un registro unico desde la tabla Hclregordeserms</para>
        /// <para>tcrCodigoRegistro: Codigo unico IG del registrocampo hcl_nroreg_hcms</para>
        /// </summary>
        public static ModeloHclregordeserms fobRegistroHclregordeserms(String tcrCodigoRegistro)
        {
            ModeloHclregordeserms lobRegistro = null;
            using (_context = new DbAplicacion())
            {
                    #region consulta
                    var lobConsulta = (from hclregordeserms in _context.Hclregordeserms
                                      join hcltiporegserms in _context.Hcltiporegserms on hclregordeserms.hcl_tipreg_hctr equals hcltiporegserms.hcl_tipreg_hctr into tmhcltiporegserms
                                      join siaareapreservi in _context.Siaareapreservi on hclregordeserms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregordeserms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join sisestadoproces in _context.Sisestadoproces on hclregordeserms.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from hctr in tmhcltiporegserms.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where hclregordeserms.hcl_nroreg_hcms == tcrCodigoRegistro
                                      orderby hclregordeserms.hcl_secreg_hcms descending
                                      select new ModeloHclregordeserms
                                      {
                                          #region datos
                                          Hcl_nroreg_hcms = hclregordeserms.hcl_nroreg_hcms,
                                          Hcl_secreg_hcms = (long)hclregordeserms.hcl_secreg_hcms,
                                          Hcl_nroreg_hcev = hclregordeserms.hcl_nroreg_hcev,
                                          Adm_secadm_rgad = hclregordeserms.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregordeserms.sia_idesec_usua,
                                          Sia_tipide_tide = hclregordeserms.sia_tipide_tide,
                                          Sia_nroide_usua = hclregordeserms.sia_nroide_usua,
                                          Hcl_tipreg_hctr = hclregordeserms.hcl_tipreg_hctr,
                                          Sia_codare_aser = hclregordeserms.sia_codare_aser,
                                          Hcl_gesfec_hcms = (DateTime)hclregordeserms.hcl_gesfec_hcms,
                                          Hcl_geshor_hcms = (Decimal)hclregordeserms.hcl_geshor_hcms,
                                          Hcl_tiptur_hctu = hclregordeserms.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = hclregordeserms.sia_codpfa_prof,
                                          Sis_estpro_espr = hclregordeserms.sis_estpro_espr,
                                          Hcl_desreg_hctr = hctr.hcl_desreg_hctr,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                          Hcl_destur_hctu = _context.Hcltiporegturno.FirstOrDefault(rxp => rxp.hcl_tiptur_hctu == hclregordeserms.hcl_tiptur_hctu).hcl_destur_hctu,
                                          Sia_nomusu_usua = _context.Siausuarioatend.FirstOrDefault(rxp => rxp.sia_idesec_usua == hclregordeserms.sia_idesec_usua).sia_nomusu_usua,
                                          #endregion
                                      }).ToList().FirstOrDefault();
                    #endregion
                    lobRegistro = lobConsulta != null ? lobConsulta : lobRegistro;
            }
            return lobRegistro;
        }
        #endregion
        #region Listar Registros
        /// <summary>
        /// <para>tcrTipoConsulta:</para>
        /// <para>"NA" = consulta normal por campo hcl_nroreg_hcms IG de la tabla sin tener presente el parametro tcrEstadoRegistro</para>
        /// <para>"MEDI" = Medicamentos "ALIQ" = Balnace de liquidos "DIAG" = Diangosticos y mas</para>
        /// <para>tcrIDCodigo:</para>
        /// <para>Cuando tcrTipoConsulta = "NA", tcrIDCodigo contiene el codigo IG del campo hcl_nroreg_hcms</para>
        /// <para>en los demas casos tcrIDCodigo contiene el codigo Admision</para>
        /// <para>tcrEstadoRegistro:</para>
        /// <para>Estado registro: "1" = Abierto "2" = Confirmados "3" = Anulados</para>
        /// </summary>
        public static List<ModeloHclregordeserms> flsListaHclregordesermsEx(String tcrTipoConsulta, String tcrIDCodigo, String tcrEstadoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                if (tcrTipoConsulta!="NA")
                {
                    if (!String.IsNullOrWhiteSpace(tcrEstadoRegistro))
                    {
                        #region consulta
                        var lobConsulta = from hclregordeserms in _context.Hclregordeserms
                                          join hcltiporegserms in _context.Hcltiporegserms on hclregordeserms.hcl_tipreg_hctr equals hcltiporegserms.hcl_tipreg_hctr into tmhcltiporegserms
                                          join siaareapreservi in _context.Siaareapreservi on hclregordeserms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                          join siamaeprofsalud in _context.Siamaeprofsalud on hclregordeserms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                          join sisestadoproces in _context.Sisestadoproces on hclregordeserms.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                          from hctr in tmhcltiporegserms.DefaultIfEmpty()
                                          from aser in tmsiaareapreservi.DefaultIfEmpty()
                                          from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                          from espr in tmsisestadoproces.DefaultIfEmpty()
                                          where hclregordeserms.adm_secadm_rgad == tcrIDCodigo &&
                                                hclregordeserms.hcl_tipreg_hctr == tcrTipoConsulta &&
                                                hclregordeserms.sis_estpro_espr == tcrEstadoRegistro
                                                orderby hclregordeserms.hcl_secreg_hcms descending
                                          select new ModeloHclregordeserms
                                          {
                                              #region datos
                                              Hcl_nroreg_hcms = hclregordeserms.hcl_nroreg_hcms,
                                              Hcl_secreg_hcms = (long)hclregordeserms.hcl_secreg_hcms,
                                              Hcl_nroreg_hcev = hclregordeserms.hcl_nroreg_hcev,
                                              Adm_secadm_rgad = hclregordeserms.adm_secadm_rgad,
                                              Sia_idesec_usua = hclregordeserms.sia_idesec_usua,
                                              Sia_tipide_tide = hclregordeserms.sia_tipide_tide,
                                              Sia_nroide_usua = hclregordeserms.sia_nroide_usua,
                                              Hcl_tipreg_hctr = hclregordeserms.hcl_tipreg_hctr,
                                              Sia_codare_aser = hclregordeserms.sia_codare_aser,
                                              Hcl_gesfec_hcms = (DateTime)hclregordeserms.hcl_gesfec_hcms,
                                              Hcl_geshor_hcms = (Decimal)hclregordeserms.hcl_geshor_hcms,
                                              Hcl_tiptur_hctu = hclregordeserms.hcl_tiptur_hctu,
                                              Sia_codpfa_prof = hclregordeserms.sia_codpfa_prof,
                                              Sis_estpro_espr = hclregordeserms.sis_estpro_espr,
                                              Hcl_desreg_hctr = hctr.hcl_desreg_hctr,
                                              Sia_desare_aser = aser.sia_desare_aser,
                                              Sia_nompro_prof = prof.sia_nompro_prof,
                                              Sis_despro_espr = espr.sis_despro_espr,
                                              Hcl_destur_hctu = _context.Hcltiporegturno.FirstOrDefault(rxp => rxp.hcl_tiptur_hctu == hclregordeserms.hcl_tiptur_hctu).hcl_destur_hctu,
                                              Sia_nomusu_usua = _context.Siausuarioatend.FirstOrDefault(rxp => rxp.sia_idesec_usua == hclregordeserms.sia_idesec_usua).sia_nomusu_usua,
                                              #endregion
                                          };
                        return lobConsulta.ToList();
                        #endregion
                    }
                    else 
                    {
                        #region consulta
                        var lobConsulta = from hclregordeserms in _context.Hclregordeserms
                                          join hcltiporegserms in _context.Hcltiporegserms on hclregordeserms.hcl_tipreg_hctr equals hcltiporegserms.hcl_tipreg_hctr into tmhcltiporegserms
                                          join siaareapreservi in _context.Siaareapreservi on hclregordeserms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                          join siamaeprofsalud in _context.Siamaeprofsalud on hclregordeserms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                          join sisestadoproces in _context.Sisestadoproces on hclregordeserms.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                          from hctr in tmhcltiporegserms.DefaultIfEmpty()
                                          from aser in tmsiaareapreservi.DefaultIfEmpty()
                                          from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                          from espr in tmsisestadoproces.DefaultIfEmpty()
                                          where hclregordeserms.adm_secadm_rgad == tcrIDCodigo &&
                                                hclregordeserms.hcl_tipreg_hctr == tcrTipoConsulta
                                                orderby hclregordeserms.hcl_secreg_hcms descending
                                          select new ModeloHclregordeserms
                                          {
                                              #region datos
                                              Hcl_nroreg_hcms = hclregordeserms.hcl_nroreg_hcms,
                                              Hcl_secreg_hcms = (long)hclregordeserms.hcl_secreg_hcms,
                                              Hcl_nroreg_hcev = hclregordeserms.hcl_nroreg_hcev,
                                              Adm_secadm_rgad = hclregordeserms.adm_secadm_rgad,
                                              Sia_idesec_usua = hclregordeserms.sia_idesec_usua,
                                              Sia_tipide_tide = hclregordeserms.sia_tipide_tide,
                                              Sia_nroide_usua = hclregordeserms.sia_nroide_usua,
                                              Hcl_tipreg_hctr = hclregordeserms.hcl_tipreg_hctr,
                                              Sia_codare_aser = hclregordeserms.sia_codare_aser,
                                              Hcl_gesfec_hcms = (DateTime)hclregordeserms.hcl_gesfec_hcms,
                                              Hcl_geshor_hcms = (Decimal)hclregordeserms.hcl_geshor_hcms,
                                              Hcl_tiptur_hctu = hclregordeserms.hcl_tiptur_hctu,
                                              Sia_codpfa_prof = hclregordeserms.sia_codpfa_prof,
                                              Sis_estpro_espr = hclregordeserms.sis_estpro_espr,
                                              Hcl_desreg_hctr = hctr.hcl_desreg_hctr,
                                              Sia_desare_aser = aser.sia_desare_aser,
                                              Sia_nompro_prof = prof.sia_nompro_prof,
                                              Sis_despro_espr = espr.sis_despro_espr,
                                              Hcl_destur_hctu = _context.Hcltiporegturno.FirstOrDefault(rxp => rxp.hcl_tiptur_hctu == hclregordeserms.hcl_tiptur_hctu).hcl_destur_hctu,
                                              Sia_nomusu_usua = _context.Siausuarioatend.FirstOrDefault(rxp => rxp.sia_idesec_usua == hclregordeserms.sia_idesec_usua).sia_nomusu_usua,
                                              #endregion
                                          };
                        return lobConsulta.ToList();
                        #endregion
                    }
                }
                else
                {
                    #region consulta
                    var lobConsulta = from hclregordeserms in _context.Hclregordeserms
                                      join hcltiporegserms in _context.Hcltiporegserms on hclregordeserms.hcl_tipreg_hctr equals hcltiporegserms.hcl_tipreg_hctr into tmhcltiporegserms
                                      join siaareapreservi in _context.Siaareapreservi on hclregordeserms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregordeserms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join sisestadoproces in _context.Sisestadoproces on hclregordeserms.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from hctr in tmhcltiporegserms.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where hclregordeserms.hcl_nroreg_hcms == tcrIDCodigo
                                      orderby hclregordeserms.hcl_secreg_hcms descending
                                      select new ModeloHclregordeserms
                                      {
                                          #region datos
                                          Hcl_nroreg_hcms = hclregordeserms.hcl_nroreg_hcms,
                                          Hcl_secreg_hcms = (long)hclregordeserms.hcl_secreg_hcms,
                                          Hcl_nroreg_hcev = hclregordeserms.hcl_nroreg_hcev,
                                          Adm_secadm_rgad = hclregordeserms.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregordeserms.sia_idesec_usua,
                                          Sia_tipide_tide = hclregordeserms.sia_tipide_tide,
                                          Sia_nroide_usua = hclregordeserms.sia_nroide_usua,
                                          Hcl_tipreg_hctr = hclregordeserms.hcl_tipreg_hctr,
                                          Sia_codare_aser = hclregordeserms.sia_codare_aser,
                                          Hcl_gesfec_hcms = (DateTime)hclregordeserms.hcl_gesfec_hcms,
                                          Hcl_geshor_hcms = (Decimal)hclregordeserms.hcl_geshor_hcms,
                                          Hcl_tiptur_hctu = hclregordeserms.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = hclregordeserms.sia_codpfa_prof,
                                          Sis_estpro_espr = hclregordeserms.sis_estpro_espr,
                                          Hcl_desreg_hctr = hctr.hcl_desreg_hctr,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                          Hcl_destur_hctu = _context.Hcltiporegturno.FirstOrDefault(rxp => rxp.hcl_tiptur_hctu == hclregordeserms.hcl_tiptur_hctu).hcl_destur_hctu,
                                          Sia_nomusu_usua = _context.Siausuarioatend.FirstOrDefault(rxp => rxp.sia_idesec_usua == hclregordeserms.sia_idesec_usua).sia_nomusu_usua,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        // Generar temporal maestro entrega medicamentos
        #region fobRegistroMedicamentoFormulaMedicaMA
        /// <summary>
        /// genera el registro maestro (MA) con formato de la tabla "farmovmedicamma" para entrega medicamentos en farmacia
        /// </summary>
        public static ModeloEntregaMedica fobRegistroMedicamentoFormulaMedicaMA(String tcrCodigoRegistroR1, String tcrCodigoAlmacen, DateTime tdaFechaGestion)
        {
            using (_context = new DbAplicacion())
            {
                #region consulta
                var lobConsulta = (from hclregordeserms in _context.Hclregordeserms
                                   join admregadmision in _context.Admregadmision on hclregordeserms.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                                   from rgad in tmadmregadmision.DefaultIfEmpty()
                                   where hclregordeserms.hcl_nroreg_hcms == tcrCodigoRegistroR1
                                   select new ModeloEntregaMedica
                                   {
                                       #region Datos
                                       Far_nroreg_fams = tcrCodigoRegistroR1,
                                       Hcl_nroreg_hcms = hclregordeserms.hcl_nroreg_hcms,
                                       Adm_secadm_rgad = hclregordeserms.adm_secadm_rgad,
                                       Far_gesfec_fams = (DateTime)hclregordeserms.hcl_gesfec_hcms,
                                       Far_geshor_fams = (Decimal)hclregordeserms.hcl_geshor_hcms,
                                       Sia_idesec_usua = hclregordeserms.sia_idesec_usua,
                                       Sia_tipide_tide = hclregordeserms.sia_tipide_tide,
                                       Sia_nroide_usua = hclregordeserms.sia_nroide_usua,
                                       Far_tipreg_fams = "1",
                                       Far_tipges_fams = "1",
                                       Inv_codalm_inal = tcrCodigoAlmacen,
                                       Far_observ_fams = hclregordeserms.adm_secadm_rgad + " - ENTREGA FORMULA MEDICA",
                                       Sia_codare_aser = hclregordeserms.sia_codare_aser,
                                       Cto_seccon_cont = rgad.cto_seccon_cont,
                                       Cto_nrocon_cont = rgad.cto_nrocon_cont,
                                       Sia_codeps_teps = rgad.sia_codeps_teps,
                                       Fcm_codcpr_cpro = rgad.fcm_codcpr_cpro,
                                       Hcl_tiptur_hctu = hclregordeserms.hcl_tiptur_hctu,
                                       Sia_codpfa_prof = hclregordeserms.sia_codpfa_prof,
                                       Sys_codusu_usux = rgad.sys_codusu_usux,
                                       Far_entreg_fams = "1",
                                       Far_entrex_fams = "1",
                                       Sys_codusx_usux = "NA",
                                       Far_secdet_fams = 10,
                                       Sis_estpro_espr = "1",
                                       #endregion
                                   }).FirstOrDefault();
                return lobConsulta;
                #endregion
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// <para>tabla: hclregordeserde</para>
    /// <para>Tabla para guardar detalles solicitudes de servicios o medicamentos</para>
    /// <para>desde historias clinicas</para>
    /// </summary>
    public class ModeloHclregordeserde : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region RefObjeto: Referencia a la instancia del Objeto en la vista grilla
        /// <summary>
        /// Referencia a la instancia del Objeto en la vista grilla
        /// </summary>
        public FrameworkElement RefObjeto { get; set; }
        #endregion
        #region Hcl_nroreg_hcor: Codigo registro actividad
        private String _hcl_nroreg_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Codigo registro actividad</para>
        /// <para>NOMBRE: hcl_nroreg_hcor (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico  registro servicio o medicamento
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcor
        {
            get { return _hcl_nroreg_hcor; }
            set
            {
                if (_hcl_nroreg_hcor == value) return;
                _hcl_nroreg_hcor = value;
                OnPropertyChanged("Hcl_nroreg_hcor");
            }
        }
        #endregion
        #region Hcl_nroreg_hcms: Codigo registro maestro
        private String _hcl_nroreg_hcms;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Codigo registro maestro</para>
        /// <para>NOMBRE: hcl_nroreg_hcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código secuencial unico registro maestro en la orden que los
        /// agrupa
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcms
        {
            get { return _hcl_nroreg_hcms; }
            set
            {
                if (_hcl_nroreg_hcms == value) return;
                _hcl_nroreg_hcms = value;
                OnPropertyChanged("Hcl_nroreg_hcms");
            }
        }
        #endregion
        #region Hcl_secreg_hcor: Secuencial evento
        private long _hcl_secreg_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Secuencial evento</para>
        /// <para>NOMBRE: hcl_secreg_hcor (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del registro medico  para organizar la vista
        /// cronologica
        /// </para>
        /// </summary>
        public long Hcl_secreg_hcor
        {
            get { return _hcl_secreg_hcor; }
            set
            {
                if (_hcl_secreg_hcor == value) return;
                _hcl_secreg_hcor = value;
                OnPropertyChanged("Hcl_secreg_hcor");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region Hcl_tipreg_hcor: Tipo Registro actividad
        private String _hcl_tipreg_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Tipo Registro actividad</para>
        /// <para>NOMBRE: hcl_tipreg_hcor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION: Tipo registro: 1 = Plan de manejo Interno 2=Plan de manejo Externo</para>
        /// </summary>
        public String Hcl_tipreg_hcor
        {
            get { return _hcl_tipreg_hcor; }
            set
            {
                if (_hcl_tipreg_hcor == value) return;
                _hcl_tipreg_hcor = value;
                OnPropertyChanged("Hcl_tipreg_hcor");
            }
        }
        #endregion
        #region Fcm_secreg_dfac: Servicio en facturación
        private String _fcm_secreg_dfac;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Servicio en facturación</para>
        /// <para>NOMBRE: fcm_secreg_dfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Secuencial único del registro desde servicios facturados del
        /// modulo Facturación (cuando el registro se facture)
        /// </para>
        /// </summary>
        public String Fcm_secreg_dfac
        {
            get { return _fcm_secreg_dfac; }
            set
            {
                if (_fcm_secreg_dfac == value) return;
                _fcm_secreg_dfac = value;
                OnPropertyChanged("Fcm_secreg_dfac");
            }
        }
        #endregion
        #region Fcm_idesec_sips: Código servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS configurado (codigo
        /// CUPS)
        /// </para>
        /// </summary>
        public String Fcm_idesec_sips
        {
            get { return _fcm_idesec_sips; }
            set
            {
                if (_fcm_idesec_sips == value) return;
                _fcm_idesec_sips = value;
                OnPropertyChanged("Fcm_idesec_sips");
            }
        }
        #endregion
        #region Fcm_codser_sips: Código servicio en tarifario
        private String _fcm_codser_sips;
        /// <summary>
        /// <para>TABLA: campo temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio para venta y RIPS, pude ser codigo SOAT
        /// ISS o CUPS (es modificable en configuración)
        /// </para>
        /// </summary>
        public String Fcm_codser_sips
        {
            get { return _fcm_codser_sips; }
            set
            {
                if (_fcm_codser_sips == value) return;
                _fcm_codser_sips = value;
                OnPropertyChanged("Fcm_codser_sips");
            }
        }
        #endregion
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
        /// creado por el usuario administrador y unico en la tabla
        /// </para>
        /// </summary>
        public String Fcm_coddig_mant
        {
            get { return _fcm_coddig_mant; }
            set
            {
                if (_fcm_coddig_mant == value) return;
                _fcm_coddig_mant = value;
                OnPropertyChanged("Fcm_coddig_mant");
            }
        }
        #endregion
        #region Hcl_totuni_hcor: Total unidades
        private int _hcl_totuni_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: hcl_totuni_hcor (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Total de unidades autorizadas en la orden servicio
        /// </para>
        /// </summary>
        public int Hcl_totuni_hcor
        {
            get { return _hcl_totuni_hcor; }
            set
            {
                if (_hcl_totuni_hcor == value) return;
                _hcl_totuni_hcor = value;
                OnPropertyChanged("Hcl_totuni_hcor");
            }
        }
        #endregion
        #region Inv_secart_mart: Código único suministro
        private String _inv_secart_mart;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código único suministro</para>
        /// <para>NOMBRE: inv_secart_mart (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo del articulo medicamento relacionado con el inventario
        /// para realizar descargas cuando se suminstra medicamentos o
        /// materiales a pacientes
        /// </para>
        /// </summary>
        public String Inv_secart_mart
        {
            get { return _inv_secart_mart; }
            set
            {
                if (_inv_secart_mart == value) return;
                _inv_secart_mart = value;
                OnPropertyChanged("Inv_secart_mart");
            }
        }
        #endregion
        #region Hcl_aplmed_hcor: Aplicación medicamento
        private String _hcl_aplmed_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Aplicación medicamento</para>
        /// <para>NOMBRE: hcl_aplmed_hcor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Via de aplicación del medicamento: 1=Oral 2= Intramuscular
        /// 3=Intravenosa 4=Topica 5= Otras
        /// </para>
        /// </summary>
        public String Hcl_aplmed_hcor
        {
            get { return _hcl_aplmed_hcor; }
            set
            {
                if (_hcl_aplmed_hcor == value) return;
                _hcl_aplmed_hcor = value;
                OnPropertyChanged("Hcl_aplmed_hcor");
            }
        }
        #endregion
        #region Hcl_termed_hcor: Termino de uso
        private String _hcl_termed_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Termino de uso</para>
        /// <para>NOMBRE: hcl_termed_hcor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Termino de uso del medicamento (en dias): 1=Indefeinido 2=Definido
        /// </para>
        /// </summary>
        public String Hcl_termed_hcor
        {
            get { return _hcl_termed_hcor; }
            set
            {
                if (_hcl_termed_hcor == value) return;
                _hcl_termed_hcor = value;
                OnPropertyChanged("Hcl_termed_hcor");
            }
        }
        #endregion
        #region Hcl_nrodia_hcor: Numero dias uso
        private int _hcl_nrodia_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Numero dias uso</para>
        /// <para>NOMBRE: hcl_nrodia_hcor (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Numero de dias para uso del medicamento cuando el termino es
        /// definido según : HCL_TERMED_HCOR
        /// </para>
        /// </summary>
        public int Hcl_nrodia_hcor
        {
            get { return _hcl_nrodia_hcor; }
            set
            {
                if (_hcl_nrodia_hcor == value) return;
                _hcl_nrodia_hcor = value;
                OnPropertyChanged("Hcl_nrodia_hcor");
            }
        }
        #endregion
        #region Hcl_gesfec_hcor: Fecha servicio
        private DateTime _hcl_gesfec_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: hcl_gesfec_hcor (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud del servicio al paciente
        /// </para>
        /// </summary>
        public DateTime Hcl_gesfec_hcor
        {
            get { return _hcl_gesfec_hcor; }
            set
            {
                if (_hcl_gesfec_hcor == value) return;
                _hcl_gesfec_hcor = value;
                OnPropertyChanged("Hcl_gesfec_hcor");
            }
        }
        #endregion
        #region Hcl_geshor_hcor: Hora servicio
        private Decimal _hcl_geshor_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: hcl_geshor_hcor (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Hora solicitud del servicio al paciente en formato militar
        /// (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_geshor_hcor
        {
            get { return _hcl_geshor_hcor; }
            set
            {
                if (_hcl_geshor_hcor == value) return;
                _hcl_geshor_hcor = value;
                OnPropertyChanged("Hcl_geshor_hcor");
            }
        }
        #endregion
        #region Hcl_tiptur_hctu: Codigo turno
        private String _hcl_tiptur_hctu;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Codigo turno</para>
        /// <para>NOMBRE: hcl_tiptur_hctu (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion turnos diarios para la prestacion de servicios
        /// medicos
        /// </para>
        /// </summary>
        public String Hcl_tiptur_hctu
        {
            get { return _hcl_tiptur_hctu; }
            set
            {
                if (_hcl_tiptur_hctu == value) return;
                _hcl_tiptur_hctu = value;
                OnPropertyChanged("Hcl_tiptur_hctu");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Código del Profesional que autoriza el servicio o medicamento
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
        #region Fcm_codcpr_cpro: Código centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Codigo del centro de produccion donde se presta el servicio
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
        #region Sia_codare_aser: Código área servicio
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área servicio</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Codigo area donde se presta el servicio
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
        #region Hcl_sisfec_hcor: Fecha sistema
        private DateTime _hcl_sisfec_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Fecha sistema</para>
        /// <para>NOMBRE: hcl_sisfec_hcor (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Fecha  del sistema cuando se genera registro del evento
        /// </para>
        /// </summary>
        public DateTime Hcl_sisfec_hcor
        {
            get { return _hcl_sisfec_hcor; }
            set
            {
                if (_hcl_sisfec_hcor == value) return;
                _hcl_sisfec_hcor = value;
                OnPropertyChanged("Hcl_sisfec_hcor");
            }
        }
        #endregion
        #region Hcl_sishor_hcor: Hora sistema
        private Decimal _hcl_sishor_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Hora sistema</para>
        /// <para>NOMBRE: hcl_sishor_hcor (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema al generar registro de evento en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_sishor_hcor
        {
            get { return _hcl_sishor_hcor; }
            set
            {
                if (_hcl_sishor_hcor == value) return;
                _hcl_sishor_hcor = value;
                OnPropertyChanged("Hcl_sishor_hcor");
            }
        }
        #endregion
        #region Hcl_notreg_hcor: Conducta
        private String _hcl_notreg_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Conducta</para>
        /// <para>NOMBRE: hcl_notreg_hcor (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Nota justificacion del servicio y para los medicamentos se
        /// ecriber dosificacion  para el paciente
        /// </para>
        /// </summary>
        public String Hcl_notreg_hcor
        {
            get { return _hcl_notreg_hcor; }
            set
            {
                if (_hcl_notreg_hcor == value) return;
                _hcl_notreg_hcor = value;
                OnPropertyChanged("Hcl_notreg_hcor");
            }
        }
        #endregion
        #region Hcl_tserax_hcor: Tipo orden servicio
        private String _hcl_tserax_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Tipo orden servicio</para>
        /// <para>NOMBRE: _hcl_tserax_hcor (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio auxiliar para multiples usos : NA = No aplica  1= Medicamentos desde Vademecum  (solo para formulacion medica)
        /// </para>
        /// </summary>
        public String Hcl_tserax_hcor
        {
            get { return _hcl_tserax_hcor; }
            set
            {
                if (_hcl_tserax_hcor == value) return;
                _hcl_tserax_hcor = value;
                OnPropertyChanged("Hcl_tserax_hcor");
            }
        }
        #endregion
        #region Hcl_tipser_hcor: Tipo orden servicio
        private String _hcl_tipser_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Tipo orden servicio</para>
        /// <para>NOMBRE: hcl_tipser_hcor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio: 1 = Servicio o medicamento 2= Indicacion medica (para distinguier cuando solo es una indicacion medica)
        /// </para>
        /// </summary>
        public String Hcl_tipser_hcor
        {
            get { return _hcl_tipser_hcor; }
            set
            {
                if (_hcl_tipser_hcor == value) return;
                _hcl_tipser_hcor = value;
                OnPropertyChanged("Hcl_tipser_hcor");
            }
        }
        #endregion
        #region Hcl_envfac_hcor: Enviar a facturación
        private String _hcl_envfac_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Enviar a facturación</para>
        /// <para>NOMBRE: hcl_envfac_hcor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Enviar el registro para generar facturacion 1=Si 2= No
        /// </para>
        /// </summary>
        public String Hcl_envfac_hcor
        {
            get { return _hcl_envfac_hcor; }
            set
            {
                if (_hcl_envfac_hcor == value) return;
                _hcl_envfac_hcor = value;
                OnPropertyChanged("Hcl_envfac_hcor");
            }
        }
        #endregion
        #region Hcl_envalm_hcor: Descargar de farmacia
        private String _hcl_envalm_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Descargar de farmacia</para>
        /// <para>NOMBRE: hcl_envalm_hcor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Enviar el registro para descargar de stock farmacia  o almacen
        /// 1=Si 2= No
        /// </para>
        /// </summary>
        public String Hcl_envalm_hcor
        {
            get { return _hcl_envalm_hcor; }
            set
            {
                if (_hcl_envalm_hcor == value) return;
                _hcl_envalm_hcor = value;
                OnPropertyChanged("Hcl_envalm_hcor");
            }
        }
        #endregion
        #region Hcl_confac_hcor: Pendiente facturacion
        private String _hcl_confac_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Pendiente facturacion</para>
        /// <para>NOMBRE: hcl_confac_hcor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Pendiente por confiramar registro en facturacion 1=Si 2= No
        /// </para>
        /// </summary>
        public String Hcl_confac_hcor
        {
            get { return _hcl_confac_hcor; }
            set
            {
                if (_hcl_confac_hcor == value) return;
                _hcl_confac_hcor = value;
                OnPropertyChanged("Hcl_confac_hcor");
            }
        }
        #endregion
        #region Hcl_conalm_hcor: Pendiente farmacia
        private String _hcl_conalm_hcor;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Pendiente farmacia</para>
        /// <para>NOMBRE: hcl_conalm_hcor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Pendiente por confiramr registro en farmacia 1=Si 2= No
        /// </para>
        /// </summary>
        public String Hcl_conalm_hcor
        {
            get { return _hcl_conalm_hcor; }
            set
            {
                if (_hcl_conalm_hcor == value) return;
                _hcl_conalm_hcor = value;
                OnPropertyChanged("Hcl_conalm_hcor");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional autoriza o presta servicio
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
        #region Fcm_descpr_cpro: Nombre centro producción
        private String _fcm_descpr_cpro;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
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
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
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
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
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
        #region Fcm_desser_sips: Nombre servicio
        private String _fcm_desser_sips;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public String Fcm_desser_sips
        {
            get { return _fcm_desser_sips; }
            set
            {
                if (_fcm_desser_sips == value) return;
                _fcm_desser_sips = value;
                OnPropertyChanged("Fcm_desser_sips");
            }
        }
        #endregion
        #region Inv_desart_mart: Descripción Artículo
        private String _inv_desart_mart;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Descripción Artículo</para>
        /// <para>NOMBRE: inv_desart_mart (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Descripción del artículos
        /// </para>
        /// </summary>
        public String Inv_desart_mart
        {
            get { return _inv_desart_mart; }
            set
            {
                if (_inv_desart_mart == value) return;
                _inv_desart_mart = value;
                OnPropertyChanged("Inv_desart_mart");
            }
        }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
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
        #region Hcl_dester_hcor: Descripcion Termino de uso
        private String _hcl_dester_hcor;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclregordeserde</para>
        /// <para>CAMPO: Termino de uso</para>
        /// <para>NOMBRE: Hcl_dester_hcor (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Descripcion termino de uso del medicamento (en dias): 1=Indefeinido 2=Definido
        /// </para>
        /// </summary>
        public String Hcl_dester_hcor
        {
            get { return _hcl_dester_hcor; }
            set
            {
                if (_hcl_dester_hcor == value) return;
                _hcl_dester_hcor = value;
                OnPropertyChanged("Hcl_dester_hcor");
            }
        }
        #endregion
        #region Sis_estado_imaen: Estado del registro para edicion
        private string _sis_estado_imaen;
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
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloHclregordeserde tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-HCLREGORDESERDE", "HCL", "Detalles ordenes servicios intrahospitalarios");
            if (!flgBuscarHclregordeserde(lcrCodigoGen))
            {
                var lnullaveIndice = Funciones.fnuFechaLlaveIndiceRegistro(tobjModelo.Hcl_gesfec_hcor, tobjModelo.Hcl_geshor_hcor);

                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFhclregordeserde
                    {
                        #region cargar Registro
                        hcl_nroreg_hcor = tobjModelo.Hcl_nroreg_hcor,
                        hcl_nroreg_hcms = tobjModelo.Hcl_nroreg_hcms,
                        hcl_secreg_hcor = lnullaveIndice,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        hcl_tipreg_hcor = tobjModelo.Hcl_tipreg_hcor,
                        fcm_secreg_dfac = tobjModelo.Fcm_secreg_dfac,
                        fcm_idesec_sips = tobjModelo.Fcm_idesec_sips,
                        fcm_coddig_mant = tobjModelo.Fcm_coddig_mant,
                        hcl_totuni_hcor = tobjModelo.Hcl_totuni_hcor,
                        inv_secart_mart = tobjModelo.Inv_secart_mart,
                        hcl_aplmed_hcor = tobjModelo.Hcl_aplmed_hcor,
                        hcl_termed_hcor = tobjModelo.Hcl_termed_hcor,
                        hcl_nrodia_hcor = tobjModelo.Hcl_nrodia_hcor,
                        hcl_gesfec_hcor = tobjModelo.Hcl_gesfec_hcor,
                        hcl_geshor_hcor = tobjModelo.Hcl_geshor_hcor,
                        hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro,
                        sia_codare_aser = tobjModelo.Sia_codare_aser,
                        hcl_sisfec_hcor = tobjModelo.Hcl_sisfec_hcor,
                        hcl_sishor_hcor = tobjModelo.Hcl_sishor_hcor,
                        hcl_notreg_hcor = tobjModelo.Hcl_notreg_hcor,
                        hcl_tserax_hcor = tobjModelo.Hcl_tserax_hcor,
                        hcl_tipser_hcor = tobjModelo.Hcl_tipser_hcor,
                        hcl_envfac_hcor = tobjModelo.Hcl_envfac_hcor,
                        hcl_envalm_hcor = tobjModelo.Hcl_envalm_hcor,
                        hcl_confac_hcor = tobjModelo.Hcl_confac_hcor,
                        hcl_conalm_hcor = tobjModelo.Hcl_conalm_hcor,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.hcl_nroreg_hcor = lcrCodigoGen;
                    _context.AddToHclregordeserde(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-HCLREGORDESERDE': Detalles ordenes servicios intrahospitalarios en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHclregordeserde tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserde.FirstOrDefault(p => p.hcl_nroreg_hcor == tobjModelo.Hcl_nroreg_hcor);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hcl_nroreg_hcor = tobjModelo.Hcl_nroreg_hcor;
                    lobjRegistro.hcl_nroreg_hcms = tobjModelo.Hcl_nroreg_hcms;
                    lobjRegistro.hcl_secreg_hcor = (long)tobjModelo.Hcl_secreg_hcor;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.hcl_tipreg_hcor = tobjModelo.Hcl_tipreg_hcor;
                    lobjRegistro.fcm_secreg_dfac = tobjModelo.Fcm_secreg_dfac;
                    lobjRegistro.fcm_idesec_sips = tobjModelo.Fcm_idesec_sips;
                    lobjRegistro.fcm_coddig_mant = tobjModelo.Fcm_coddig_mant;
                    lobjRegistro.hcl_totuni_hcor = (int)tobjModelo.Hcl_totuni_hcor;
                    lobjRegistro.inv_secart_mart = tobjModelo.Inv_secart_mart;
                    lobjRegistro.hcl_aplmed_hcor = tobjModelo.Hcl_aplmed_hcor;
                    lobjRegistro.hcl_termed_hcor = tobjModelo.Hcl_termed_hcor;
                    lobjRegistro.hcl_nrodia_hcor = (int)tobjModelo.Hcl_nrodia_hcor;
                    lobjRegistro.hcl_gesfec_hcor = (DateTime)tobjModelo.Hcl_gesfec_hcor;
                    lobjRegistro.hcl_geshor_hcor = (Decimal)tobjModelo.Hcl_geshor_hcor;
                    lobjRegistro.hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.fcm_codcpr_cpro = tobjModelo.Fcm_codcpr_cpro;
                    lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                    lobjRegistro.hcl_sisfec_hcor = (DateTime)tobjModelo.Hcl_sisfec_hcor;
                    lobjRegistro.hcl_sishor_hcor = (Decimal)tobjModelo.Hcl_sishor_hcor;
                    lobjRegistro.hcl_notreg_hcor = tobjModelo.Hcl_notreg_hcor;
                    lobjRegistro.hcl_tserax_hcor = tobjModelo.Hcl_tserax_hcor;
                    lobjRegistro.hcl_tipser_hcor = tobjModelo.Hcl_tipser_hcor;
                    lobjRegistro.hcl_envfac_hcor = tobjModelo.Hcl_envfac_hcor;
                    lobjRegistro.hcl_envalm_hcor = tobjModelo.Hcl_envalm_hcor;
                    lobjRegistro.hcl_confac_hcor = tobjModelo.Hcl_confac_hcor;
                    lobjRegistro.hcl_conalm_hcor = tobjModelo.Hcl_conalm_hcor;
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
                var lobjRegistro = _context.Hclregordeserde.FirstOrDefault(p => p.hcl_nroreg_hcor == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar HCLREGORDESERDE: Logica
        /// <summary>
        /// <para>TABLA: hclregordeserde</para>
        /// <para>TITULO: Detalles ordenes servicios intrahospitalarios</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles solicitude ordenes servicios intrahospitalarios, almacena
        /// los registros de los consumos de medicamentos y servicios medicos
        /// de los pacientes durante la estancia en la IPS
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregordeserde(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregordeserde.FirstOrDefault(p => p.hcl_nroreg_hcor == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        /// <summary>
        /// <para>tcrTipo: "IG" = hcl_nroreg_hcor uno solo  "R1" = hcl_nroreg_hcms lista tipo detalles </para>
        /// </summary>
        public static List<ModeloHclregordeserde> flsListaHclregordeserde(String tcrTipo, String tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                if (tcrTipo=="R1")
                {
                    #region consulta
                    var lobConsulta = from hclregordeserde in _context.Hclregordeserde
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregordeserde.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join fcmmanservicips in _context.Fcmmanservicips on hclregordeserde.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      join fcmcenproduccio in _context.Fcmcenproduccio on hclregordeserde.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join siaareapreservi in _context.Siaareapreservi on hclregordeserde.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      where hclregordeserde.hcl_nroreg_hcms == tcrCodigo
                                      select new ModeloHclregordeserde
                                      {
                                          #region datos
                                          Hcl_nroreg_hcor = hclregordeserde.hcl_nroreg_hcor,
                                          Hcl_nroreg_hcms = hclregordeserde.hcl_nroreg_hcms,
                                          Hcl_secreg_hcor = (long)hclregordeserde.hcl_secreg_hcor,
                                          Adm_secadm_rgad = hclregordeserde.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregordeserde.sia_idesec_usua,
                                          Hcl_tipreg_hcor = hclregordeserde.hcl_tipreg_hcor,
                                          Fcm_secreg_dfac = hclregordeserde.fcm_secreg_dfac,
                                          Fcm_idesec_sips = hclregordeserde.fcm_idesec_sips,
                                          Fcm_coddig_mant = hclregordeserde.fcm_coddig_mant,
                                          Hcl_totuni_hcor = (int)hclregordeserde.hcl_totuni_hcor,
                                          Inv_secart_mart = hclregordeserde.inv_secart_mart,
                                          Hcl_aplmed_hcor = hclregordeserde.hcl_aplmed_hcor,
                                          Hcl_termed_hcor = hclregordeserde.hcl_termed_hcor,
                                          Hcl_dester_hcor = hclregordeserde.hcl_termed_hcor == "1" ? "INDEFINIDO" : "DEFINIDO",
                                          Hcl_nrodia_hcor = (int)hclregordeserde.hcl_nrodia_hcor,
                                          Hcl_gesfec_hcor = (DateTime)hclregordeserde.hcl_gesfec_hcor,
                                          Hcl_geshor_hcor = (Decimal)hclregordeserde.hcl_geshor_hcor,
                                          Hcl_tiptur_hctu = hclregordeserde.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = hclregordeserde.sia_codpfa_prof,
                                          Fcm_codcpr_cpro = hclregordeserde.fcm_codcpr_cpro,
                                          Sia_codare_aser = hclregordeserde.sia_codare_aser,
                                          Hcl_sisfec_hcor = (DateTime)hclregordeserde.hcl_sisfec_hcor,
                                          Hcl_sishor_hcor = (Decimal)hclregordeserde.hcl_sishor_hcor,
                                          Hcl_notreg_hcor = hclregordeserde.hcl_notreg_hcor,
                                          Hcl_tserax_hcor = hclregordeserde.hcl_tserax_hcor,
                                          Hcl_tipser_hcor = hclregordeserde.hcl_tipser_hcor,
                                          Hcl_envfac_hcor = hclregordeserde.hcl_envfac_hcor,
                                          Hcl_envalm_hcor = hclregordeserde.hcl_envalm_hcor,
                                          Hcl_confac_hcor = hclregordeserde.hcl_confac_hcor,
                                          Hcl_conalm_hcor = hclregordeserde.hcl_conalm_hcor,
                                          Sis_estpro_espr = hclregordeserde.sis_estpro_espr,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Fcm_codser_sips = sips.fcm_codser_sips,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Sis_estado_imaen = "I",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else 
                {
                    #region consulta
                    var lobConsulta = from hclregordeserde in _context.Hclregordeserde
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregordeserde.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join fcmmanservicips in _context.Fcmmanservicips on hclregordeserde.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      join fcmcenproduccio in _context.Fcmcenproduccio on hclregordeserde.fcm_codcpr_cpro equals fcmcenproduccio.fcm_codcpr_cpro into tmfcmcenproduccio
                                      join siaareapreservi in _context.Siaareapreservi on hclregordeserde.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      from cpro in tmfcmcenproduccio.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      where hclregordeserde.hcl_nroreg_hcor == tcrCodigo
                                      select new ModeloHclregordeserde
                                      {
                                          #region datos
                                          Hcl_nroreg_hcor = hclregordeserde.hcl_nroreg_hcor,
                                          Hcl_nroreg_hcms = hclregordeserde.hcl_nroreg_hcms,
                                          Hcl_secreg_hcor = (long)hclregordeserde.hcl_secreg_hcor,
                                          Adm_secadm_rgad = hclregordeserde.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregordeserde.sia_idesec_usua,
                                          Hcl_tipreg_hcor = hclregordeserde.hcl_tipreg_hcor,
                                          Fcm_secreg_dfac = hclregordeserde.fcm_secreg_dfac,
                                          Fcm_idesec_sips = hclregordeserde.fcm_idesec_sips,
                                          Fcm_coddig_mant = hclregordeserde.fcm_coddig_mant,
                                          Hcl_totuni_hcor = (int)hclregordeserde.hcl_totuni_hcor,
                                          Inv_secart_mart = hclregordeserde.inv_secart_mart,
                                          Hcl_aplmed_hcor = hclregordeserde.hcl_aplmed_hcor,
                                          Hcl_termed_hcor = hclregordeserde.hcl_termed_hcor,
                                          Hcl_dester_hcor = hclregordeserde.hcl_termed_hcor == "1" ? "INDEFINIDO" : "DEFINIDO",
                                          Hcl_nrodia_hcor = (int)hclregordeserde.hcl_nrodia_hcor,
                                          Hcl_gesfec_hcor = (DateTime)hclregordeserde.hcl_gesfec_hcor,
                                          Hcl_geshor_hcor = (Decimal)hclregordeserde.hcl_geshor_hcor,
                                          Hcl_tiptur_hctu = hclregordeserde.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = hclregordeserde.sia_codpfa_prof,
                                          Fcm_codcpr_cpro = hclregordeserde.fcm_codcpr_cpro,
                                          Sia_codare_aser = hclregordeserde.sia_codare_aser,
                                          Hcl_sisfec_hcor = (DateTime)hclregordeserde.hcl_sisfec_hcor,
                                          Hcl_sishor_hcor = (Decimal)hclregordeserde.hcl_sishor_hcor,
                                          Hcl_notreg_hcor = hclregordeserde.hcl_notreg_hcor,
                                          Hcl_tserax_hcor = hclregordeserde.hcl_tserax_hcor,
                                          Hcl_tipser_hcor = hclregordeserde.hcl_tipser_hcor,
                                          Hcl_envfac_hcor = hclregordeserde.hcl_envfac_hcor,
                                          Hcl_envalm_hcor = hclregordeserde.hcl_envalm_hcor,
                                          Hcl_confac_hcor = hclregordeserde.hcl_confac_hcor,
                                          Hcl_conalm_hcor = hclregordeserde.hcl_conalm_hcor,
                                          Sis_estpro_espr = hclregordeserde.sis_estpro_espr,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Fcm_codser_sips = sips.fcm_codser_sips,
                                          Fcm_descpr_cpro = cpro.fcm_descpr_cpro,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Sis_estado_imaen = "I",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #region Listar Registros segun admision y tipo registro
        /// <summary>
        /// <para>DESCRIPCION: Retorna lista de registros tipo detalles en una admision segun parametro tcrTipoRegistros</para>
        /// <para>tcrTipoRegistros: MEDI" = Medicamentos "ALIQ" = Balnace de liquidos "DIAG" = Diangosticos y mas </para>
        /// </summary>
        public static List<ModeloHclregordeserde> flsListaHclregordeserdeEx(String tcrTipoRegistros, String tcrCodigoAdmision)
        {
            using (_context = new DbAplicacion())
            {
                    #region consulta
                    var lobConsulta = from hclregordeserde in _context.Hclregordeserde
                                      join hclregordeserms in _context.Hclregordeserms on hclregordeserde.hcl_nroreg_hcms equals hclregordeserms.hcl_nroreg_hcms into tmhclregordeserms
                                      join fcmmanservicips in _context.Fcmmanservicips on hclregordeserde.fcm_idesec_sips equals fcmmanservicips.fcm_idesec_sips into tmfcmmanservicips
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregordeserde.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from hcms in tmhclregordeserms.DefaultIfEmpty()
                                      from sips in tmfcmmanservicips.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      where hclregordeserde.adm_secadm_rgad == tcrCodigoAdmision &&
                                            hcms.hcl_tipreg_hctr == tcrTipoRegistros
                                      orderby hclregordeserde.hcl_nroreg_hcms descending
                                      select new ModeloHclregordeserde
                                      {
                                          #region datos
                                          Hcl_nroreg_hcor = hclregordeserde.hcl_nroreg_hcor,
                                          Hcl_nroreg_hcms = hclregordeserde.hcl_nroreg_hcms,
                                          Hcl_secreg_hcor = (long)hclregordeserde.hcl_secreg_hcor,
                                          Adm_secadm_rgad = hclregordeserde.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregordeserde.sia_idesec_usua,
                                          Hcl_tipreg_hcor = hclregordeserde.hcl_tipreg_hcor,
                                          Fcm_secreg_dfac = hclregordeserde.fcm_secreg_dfac,
                                          Fcm_idesec_sips = hclregordeserde.fcm_idesec_sips,
                                          Fcm_coddig_mant = hclregordeserde.fcm_coddig_mant,
                                          Hcl_totuni_hcor = (int)hclregordeserde.hcl_totuni_hcor,
                                          Inv_secart_mart = hclregordeserde.inv_secart_mart,
                                          Hcl_aplmed_hcor = hclregordeserde.hcl_aplmed_hcor,
                                          Hcl_termed_hcor = hclregordeserde.hcl_termed_hcor,
                                          Hcl_dester_hcor = hclregordeserde.hcl_termed_hcor == "1" ? "INDEFINIDO" : "DEFINIDO",
                                          Hcl_nrodia_hcor = (int)hclregordeserde.hcl_nrodia_hcor,
                                          Hcl_gesfec_hcor = (DateTime)hclregordeserde.hcl_gesfec_hcor,
                                          Hcl_geshor_hcor = (Decimal)hclregordeserde.hcl_geshor_hcor,
                                          Hcl_tiptur_hctu = hclregordeserde.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = hclregordeserde.sia_codpfa_prof,
                                          Fcm_codcpr_cpro = hclregordeserde.fcm_codcpr_cpro,
                                          Sia_codare_aser = hclregordeserde.sia_codare_aser,
                                          Hcl_sisfec_hcor = (DateTime)hclregordeserde.hcl_sisfec_hcor,
                                          Hcl_sishor_hcor = (Decimal)hclregordeserde.hcl_sishor_hcor,
                                          Hcl_notreg_hcor = hclregordeserde.hcl_notreg_hcor,
                                          Hcl_tserax_hcor = hclregordeserde.hcl_tserax_hcor,
                                          Hcl_tipser_hcor = hclregordeserde.hcl_tipser_hcor,
                                          Hcl_envfac_hcor = hclregordeserde.hcl_envfac_hcor,
                                          Hcl_envalm_hcor = hclregordeserde.hcl_envalm_hcor,
                                          Hcl_confac_hcor = hclregordeserde.hcl_confac_hcor,
                                          Hcl_conalm_hcor = hclregordeserde.hcl_conalm_hcor,
                                          Sis_estpro_espr = hclregordeserde.sis_estpro_espr,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Fcm_desser_sips = sips.fcm_desser_sips,
                                          Fcm_codser_sips = sips.fcm_codser_sips,
                                          Sis_estado_imaen = "I",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                    #endregion
            }
        }
        #endregion
        // Generar temporal para hoja de consumo intrahospitalario
        #region flsTempHojaConsumoMedicamentos
        /// <summary>
        /// genera el temporal con formato para descargar la hoja de consumo desde stock inventario correspondiente
        /// </summary>
        public static List<ModeloInvKardexMaestro> flsTempHojaConsumoMedicamentos(String tcrCodigoRegistroR1, String tcrCodigoAlmacen, DateTime tdaFechaGestion)
        {
            List<ModeloInvKardexMaestro> lobConsulta = null;
            using (_context = new DbAplicacion())
            {
                #region consulta
                lobConsulta = (from hclregordeserde in _context.Hclregordeserde
                               join invmaearticulos in _context.Invmaearticulos on hclregordeserde.inv_secart_mart equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                               from inar in tminvmaearticulos.DefaultIfEmpty()
                               where hclregordeserde.hcl_nroreg_hcms == tcrCodigoRegistroR1 &&
                                     hclregordeserde.hcl_envalm_hcor == "1"
                               select new ModeloInvKardexMaestro
                               {
                                   #region cargar Registro
                                   Inv_seckar_inka = "",
                                   Inv_tiparc_inag = "05", // Entrega medicamentos
                                   Inv_numdoc_inka = hclregordeserde.adm_secadm_rgad,
                                   Inv_refkar_inka = "",
                                   Inv_tipreg_inka = "2",
                                   Inv_tipmov_intr = "2", // Salidas
                                   Inv_conmov_incm = "S25", // Suministro Hoja de consumo 
                                   Inv_secart_inar = inar.inv_secart_inar,
                                   Inv_codaux_inar = inar.inv_codaux_inar,
                                   Inv_lotref_inar = "",
                                   Sis_codgme_sigr = inar.sis_codgme_sigr,
                                   Sis_codume_sium = inar.sis_codume_sium,
                                   Inv_totuni_inex = 0,
                                   Inv_tottra_inex = (int)hclregordeserde.hcl_totuni_hcor,
                                   Inv_valing_inar = 0,
                                   Inv_valmov_inar = 0,
                                   Sis_estpro_espr = "2",
                                   #endregion
                               }).ToList();
                #endregion

            }
            return lobConsulta;
        }
        #endregion
        // Generar temporal para detalles entrega medicamentos en formula medica
        #region flsTempMedicamentoFormulaMedicaMD
        /// <summary>
        /// genera el temporal con formato detalles para entrega medicamentos en farmacia
        /// </summary>
        public static List<ModeloEntregaMedicad> flsTempMedicamentoFormulaMedicaMD(String tcrCodigoRegistroR1, String tcrCodigoAlmacen, DateTime tdaFechaGestion)
        {
            List<ModeloEntregaMedicad> lobConsulta = null;
            using (_context = new DbAplicacion())
            {
                #region consulta
                lobConsulta = (from hclregordeserde in _context.Hclregordeserde
                               join invmaearticulos in _context.Invmaearticulos on hclregordeserde.inv_secart_mart equals invmaearticulos.inv_secart_inar into tminvmaearticulos
                               join admregadmision in _context.Admregadmision on hclregordeserde.adm_secadm_rgad equals admregadmision.adm_secadm_rgad into tmadmregadmision
                               from inar in tminvmaearticulos.DefaultIfEmpty()
                               from rgad in tmadmregadmision.DefaultIfEmpty()
                               where hclregordeserde.hcl_nroreg_hcms == tcrCodigoRegistroR1 &&
                                     hclregordeserde.hcl_envalm_hcor == "1"
                               select new ModeloEntregaMedicad
                               {
                                   #region cargar Registro
                                   Far_nroreg_fads = hclregordeserde.hcl_nroreg_hcor, // que herede el mismo codigo detalle 
                                   Far_nroreg_fams = "NA",                            // se llena al confirmar en el modelo (ModeloEntregaMedicad)
                                   Hcl_nroreg_hcms = tcrCodigoRegistroR1,
                                   Adm_secadm_rgad = hclregordeserde.adm_secadm_rgad,
                                   Far_gesfec_fams = (DateTime)hclregordeserde.hcl_gesfec_hcor,
                                   Fcm_idesec_sips = hclregordeserde.fcm_idesec_sips,
                                   Sia_idesec_usua = rgad.sia_idesec_usua,
                                   Sia_tipide_tide = rgad.sia_tipide_tide,
                                   Sia_nroide_usua = rgad.sia_nroide_usua,
                                   Far_tipreg_fams = "1",
                                   Far_tipges_fams = "1",
                                   Inv_codalm_inal = tcrCodigoAlmacen,
                                   Inv_secart_inar = inar.inv_secart_inar,
                                   Far_codcum_famd = inar.far_codcum_famd,
                                   Inv_codaux_inar = inar.inv_codaux_inar,
                                   Sis_codgme_sigr = inar.sis_codgme_sigr, // Este campo no deberia estar en esta tabla (solo en maestro articulo)
                                   Sis_codume_sium = inar.sis_codume_sium, // Este campo no deberia estar en esta tabla (solo en maestro articulo)
                                   Far_unisol_fads = (int)hclregordeserde.hcl_totuni_hcor,
                                   Far_unient_fads = (int)hclregordeserde.hcl_totuni_hcor,
                                   Far_unipen_fads = 0,
                                   Inv_valing_inar = 0,                     // se llena en el ciclo mas abajo
                                   Inv_valmov_inar = 0,                     // se llena en el ciclo mas abajo
                                   Sis_estpro_espr = "1",
                                   Sis_estado_imaen = "A",
                                   #endregion
                               }).ToList();
                #endregion
                // completar los datos
                if (lobConsulta != null)
                {
                    foreach (var lobReg in lobConsulta)
                    {
                        var lobAux = _context.Invalmacexisten.FirstOrDefault(x => x.inv_secart_inar == lobReg.Inv_secart_inar && 
                                                                                  x.inv_codalm_inal == tcrCodigoAlmacen);
                        if (lobAux != null)
                        {
                            lobReg.Inv_valing_inar = (float)lobAux.inv_valing_inar;
                            lobReg.Inv_valmov_inar = (float)lobAux.inv_valmov_inar;
                        }
                    }
                }

            }
            return lobConsulta;
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// tabla hclregnotasmedi: Registros detalles evoluciones medicas y notas de enfermeria
    /// </summary>
    public class ModeloHclregnotasmedi : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_nroreg_hcnm: Codigo registro actividad
        private String _hcl_nroreg_hcnm;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hclregnotasmedi</para>
        /// <para>CAMPO: Codigo registro actividad</para>
        /// <para>NOMBRE: hcl_nroreg_hcnm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico  registro servicio o medicamento
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcnm
        {
            get { return _hcl_nroreg_hcnm; }
            set
            {
                if (_hcl_nroreg_hcnm == value) return;
                _hcl_nroreg_hcnm = value;
                OnPropertyChanged("Hcl_nroreg_hcnm");
            }
        }
        #endregion
        #region Hcl_notreg_hcnm: Evolución medica
        private String _hcl_notreg_hcnm;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hclregnotasmedi</para>
        /// <para>CAMPO: Evolución medica</para>
        /// <para>NOMBRE: hcl_notreg_hcnm (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Cuerpo de la evolución medica o nota de enfermeria
        /// </para>
        /// </summary>
        public String Hcl_notreg_hcnm
        {
            get { return _hcl_notreg_hcnm; }
            set
            {
                if (_hcl_notreg_hcnm == value) return;
                _hcl_notreg_hcnm = value;
                OnPropertyChanged("Hcl_notreg_hcnm");
            }
        }
        #endregion
        #region Hcl_nroreg_hcms: Codigo registro maestro
        private String _hcl_nroreg_hcms;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Codigo registro maestro</para>
        /// <para>NOMBRE: hcl_nroreg_hcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código secuencial unico registro maestro en la orden que los
        /// agrupa
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcms
        {
            get { return _hcl_nroreg_hcms; }
            set
            {
                if (_hcl_nroreg_hcms == value) return;
                _hcl_nroreg_hcms = value;
                OnPropertyChanged("Hcl_nroreg_hcms");
            }
        }
        #endregion
        #region Hcl_secreg_hcnm: Secuencial evento
        private long _hcl_secreg_hcnm;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hclregnotasmedi</para>
        /// <para>CAMPO: Secuencial evento</para>
        /// <para>NOMBRE: hcl_secreg_hcnm (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del registro medico  para organizar la vista
        /// cronologica
        /// </para>
        /// </summary>
        public long Hcl_secreg_hcnm
        {
            get { return _hcl_secreg_hcnm; }
            set
            {
                if (_hcl_secreg_hcnm == value) return;
                _hcl_secreg_hcnm = value;
                OnPropertyChanged("Hcl_secreg_hcnm");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Hcl_tipreg_hcnm: Tipo Registro actividad
        private String _hcl_tipreg_hcnm;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hclregnotasmedi</para>
        /// <para>CAMPO: Tipo Registro actividad</para>
        /// <para>NOMBRE: hcl_tipreg_hcnm (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Tipo registro: 1 = Evolucion medica 2=Notas de enfermeria
        /// </para>
        /// </summary>
        public String Hcl_tipreg_hcnm
        {
            get { return _hcl_tipreg_hcnm; }
            set
            {
                if (_hcl_tipreg_hcnm == value) return;
                _hcl_tipreg_hcnm = value;
                OnPropertyChanged("Hcl_tipreg_hcnm");
            }
        }
        #endregion
        #region Hcl_gesfec_hcnm: Fecha servicio
        private DateTime _hcl_gesfec_hcnm;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hclregnotasmedi</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: hcl_gesfec_hcnm (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud del servicio al paciente
        /// </para>
        /// </summary>
        public DateTime Hcl_gesfec_hcnm
        {
            get { return _hcl_gesfec_hcnm; }
            set
            {
                if (_hcl_gesfec_hcnm == value) return;
                _hcl_gesfec_hcnm = value;
                OnPropertyChanged("Hcl_gesfec_hcnm");
            }
        }
        #endregion
        #region Hcl_geshor_hcnm: Hora servicio
        private Decimal _hcl_geshor_hcnm;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hclregnotasmedi</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: hcl_geshor_hcnm (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Hora solicitud del servicio al paciente en formato militar
        /// (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_geshor_hcnm
        {
            get { return _hcl_geshor_hcnm; }
            set
            {
                if (_hcl_geshor_hcnm == value) return;
                _hcl_geshor_hcnm = value;
                OnPropertyChanged("Hcl_geshor_hcnm");
            }
        }
        #endregion
        #region Hcl_tiptur_hctu: Codigo turno
        private String _hcl_tiptur_hctu;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Codigo turno</para>
        /// <para>NOMBRE: hcl_tiptur_hctu (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion turnos diarios para la prestacion de servicios
        /// medicos
        /// </para>
        /// </summary>
        public String Hcl_tiptur_hctu
        {
            get { return _hcl_tiptur_hctu; }
            set
            {
                if (_hcl_tiptur_hctu == value) return;
                _hcl_tiptur_hctu = value;
                OnPropertyChanged("Hcl_tiptur_hctu");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código del Profesional que autoriza el servicio o medicamento
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
        #region Hcl_sisfec_hcnm: Fecha sistema
        private DateTime _hcl_sisfec_hcnm;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hclregnotasmedi</para>
        /// <para>CAMPO: Fecha sistema</para>
        /// <para>NOMBRE: hcl_sisfec_hcnm (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Fecha  del sistema cuando se genera registro del evento
        /// </para>
        /// </summary>
        public DateTime Hcl_sisfec_hcnm
        {
            get { return _hcl_sisfec_hcnm; }
            set
            {
                if (_hcl_sisfec_hcnm == value) return;
                _hcl_sisfec_hcnm = value;
                OnPropertyChanged("Hcl_sisfec_hcnm");
            }
        }
        #endregion
        #region Hcl_sishor_hcnm: Hora sistema
        private Decimal _hcl_sishor_hcnm;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hclregnotasmedi</para>
        /// <para>CAMPO: Hora sistema</para>
        /// <para>NOMBRE: hcl_sishor_hcnm (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema al generar registro de evento en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_sishor_hcnm
        {
            get { return _hcl_sishor_hcnm; }
            set
            {
                if (_hcl_sishor_hcnm == value) return;
                _hcl_sishor_hcnm = value;
                OnPropertyChanged("Hcl_sishor_hcnm");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        /// <para>TABLA: hclregnotasmedi</para>
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
        #region Hcl_destur_hctu: Descripcion
        private String _hcl_destur_hctu;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Descripcion</para>
        /// <para>NOMBRE: hcl_destur_hctu (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion  clasificacion turnos diarios
        /// </para>
        /// </summary>
        public String Hcl_destur_hctu
        {
            get { return _hcl_destur_hctu; }
            set
            {
                if (_hcl_destur_hctu == value) return;
                _hcl_destur_hctu = value;
                OnPropertyChanged("Hcl_destur_hctu");
            }
        }
        #endregion
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
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
        /// <para>TABLA: hclregnotasmedi</para>
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
        public static string flgAddRegistro(ModeloHclregnotasmedi tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-HCLREGNOTASMEDI", "HCL", "Detalles registros evoluciones medicas y notas de enfermeria");
            if (!flgBuscarHclregnotasmedi(lcrCodigoGen))
            {
                var lnullaveIndice = Funciones.fnuFechaLlaveIndiceRegistro(tobjModelo.Hcl_gesfec_hcnm, tobjModelo.Hcl_geshor_hcnm);

                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFhclregnotasmedi
                    {
                        #region cargar Registro
                        hcl_nroreg_hcnm = tobjModelo.Hcl_nroreg_hcnm,
                        hcl_notreg_hcnm = tobjModelo.Hcl_notreg_hcnm,
                        hcl_nroreg_hcms = tobjModelo.Hcl_nroreg_hcms,
                        hcl_secreg_hcnm = lnullaveIndice, 
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        hcl_tipreg_hcnm = tobjModelo.Hcl_tipreg_hcnm,
                        hcl_gesfec_hcnm = tobjModelo.Hcl_gesfec_hcnm,
                        hcl_geshor_hcnm = tobjModelo.Hcl_geshor_hcnm,
                        hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        hcl_sisfec_hcnm = tobjModelo.Hcl_sisfec_hcnm,
                        hcl_sishor_hcnm = tobjModelo.Hcl_sishor_hcnm,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.hcl_nroreg_hcnm = lcrCodigoGen;
                    _context.AddToHclregnotasmedi(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-HCLREGNOTASMEDI': Detalles registros evoluciones medicas y notas de enfermeria en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHclregnotasmedi tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregnotasmedi.FirstOrDefault(p => p.hcl_nroreg_hcnm == tobjModelo.Hcl_nroreg_hcnm);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hcl_nroreg_hcnm = tobjModelo.Hcl_nroreg_hcnm;
                    lobjRegistro.hcl_notreg_hcnm = tobjModelo.Hcl_notreg_hcnm;
                    lobjRegistro.hcl_nroreg_hcms = tobjModelo.Hcl_nroreg_hcms;
                    lobjRegistro.hcl_secreg_hcnm = (int)tobjModelo.Hcl_secreg_hcnm;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.hcl_tipreg_hcnm = tobjModelo.Hcl_tipreg_hcnm;
                    lobjRegistro.hcl_gesfec_hcnm = (DateTime)tobjModelo.Hcl_gesfec_hcnm;
                    lobjRegistro.hcl_geshor_hcnm = (Decimal)tobjModelo.Hcl_geshor_hcnm;
                    lobjRegistro.hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.hcl_sisfec_hcnm = (DateTime)tobjModelo.Hcl_sisfec_hcnm;
                    lobjRegistro.hcl_sishor_hcnm = (Decimal)tobjModelo.Hcl_sishor_hcnm;
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
                var lobjRegistro = _context.Hclregnotasmedi.FirstOrDefault(p => p.hcl_nroreg_hcnm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region fcvActualizarEstadoRegistrosEvento: Actualizar estado registro
        /// <summary>
        /// <para>Cambar estado registro a notas y evoluciones medicas que estan asociadas</para>
        /// <para>a un registro envento en el historial clinico o eliminar el registro</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrCodigoRegistroR1: Codigo del registro relacion R1 que viene de la tabla maestra hclregordeserms</para>
        /// <para>tcrEstadoRegistro: Cambiar el estado de los registros asi: 1=Abierto 2=Confirmado 3=Anulado 4=Eliminar registro</para>
        /// </summary>
        public static void fcvActualizarEstadoRegistrosEvento(String tcrCodigoRegistroR1, String tcrEstadoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                var tmpDatos = (from tmp in _context.Hclregnotasmedi where tmp.hcl_nroreg_hcms == tcrCodigoRegistroR1 select tmp).ToList();

                if (tmpDatos != null && tmpDatos.Count > 0)
                {
                    foreach (var lobReg in tmpDatos)
                    {
                        if (tcrEstadoRegistro == "4") // Eliminar registro
                        {
                            _context.DeleteObject(lobReg);
                        }
                        else
                        {
                            lobReg.sis_estpro_espr = tcrEstadoRegistro;
                        }
                    }
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar HCLREGNOTASMEDI: Logica
        /// <summary>
        /// <para>TABLA: hclregnotasmedi</para>
        /// <para>TITULO: Detalles registros evoluciones medicas y notas de enfermeria</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles registros evoluciones medicas y notas de enfermeria
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregnotasmedi(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregnotasmedi.FirstOrDefault(p => p.hcl_nroreg_hcnm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        /// <summary>
        /// <para>tcrTipo: "IG" = hcl_nroreg_hcor uno solo  "R1" = hcl_nroreg_hcms lista tipo detalles de un turno abierto </para>
        /// </summary>
        public static List<ModeloHclregnotasmedi> flsListaHclregnotasmedi(String tcrTipo, String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (tcrTipo == "R1")
                {
                    #region consulta
                    var lobConsulta = from hclregnotasmedi in _context.Hclregnotasmedi
                                      join hcltiporegturno in _context.Hcltiporegturno on hclregnotasmedi.hcl_tiptur_hctu equals hcltiporegturno.hcl_tiptur_hctu into tmhcltiporegturno
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregnotasmedi.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join sisestadoproces in _context.Sisestadoproces on hclregnotasmedi.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from hctu in tmhcltiporegturno.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where hclregnotasmedi.hcl_nroreg_hcms == tcrBuscar
                                      select new ModeloHclregnotasmedi
                                      {
                                          Hcl_nroreg_hcnm = hclregnotasmedi.hcl_nroreg_hcnm,
                                          Hcl_notreg_hcnm = hclregnotasmedi.hcl_notreg_hcnm,
                                          Hcl_nroreg_hcms = hclregnotasmedi.hcl_nroreg_hcms,
                                          Hcl_secreg_hcnm = (long)hclregnotasmedi.hcl_secreg_hcnm,
                                          Adm_secadm_rgad = hclregnotasmedi.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregnotasmedi.sia_idesec_usua,
                                          Hcl_tipreg_hcnm = hclregnotasmedi.hcl_tipreg_hcnm,
                                          Hcl_gesfec_hcnm = (DateTime)hclregnotasmedi.hcl_gesfec_hcnm,
                                          Hcl_geshor_hcnm = (Decimal)hclregnotasmedi.hcl_geshor_hcnm,
                                          Hcl_tiptur_hctu = hclregnotasmedi.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = hclregnotasmedi.sia_codpfa_prof,
                                          Hcl_sisfec_hcnm = (DateTime)hclregnotasmedi.hcl_sisfec_hcnm,
                                          Hcl_sishor_hcnm = (Decimal)hclregnotasmedi.hcl_sishor_hcnm,
                                          Sis_estpro_espr = hclregnotasmedi.sis_estpro_espr,
                                          Hcl_destur_hctu = hctu.hcl_destur_hctu,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    #region consulta
                    var lobConsulta = from hclregnotasmedi in _context.Hclregnotasmedi
                                      join hcltiporegturno in _context.Hcltiporegturno on hclregnotasmedi.hcl_tiptur_hctu equals hcltiporegturno.hcl_tiptur_hctu into tmhcltiporegturno
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregnotasmedi.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join sisestadoproces in _context.Sisestadoproces on hclregnotasmedi.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from hctu in tmhcltiporegturno.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where hclregnotasmedi.hcl_nroreg_hcnm == tcrBuscar
                                      select new ModeloHclregnotasmedi
                                      {
                                          Hcl_nroreg_hcnm = hclregnotasmedi.hcl_nroreg_hcnm,
                                          Hcl_notreg_hcnm = hclregnotasmedi.hcl_notreg_hcnm,
                                          Hcl_nroreg_hcms = hclregnotasmedi.hcl_nroreg_hcms,
                                          Hcl_secreg_hcnm = (int)hclregnotasmedi.hcl_secreg_hcnm,
                                          Adm_secadm_rgad = hclregnotasmedi.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregnotasmedi.sia_idesec_usua,
                                          Hcl_tipreg_hcnm = hclregnotasmedi.hcl_tipreg_hcnm,
                                          Hcl_gesfec_hcnm = (DateTime)hclregnotasmedi.hcl_gesfec_hcnm,
                                          Hcl_geshor_hcnm = (Decimal)hclregnotasmedi.hcl_geshor_hcnm,
                                          Hcl_tiptur_hctu = hclregnotasmedi.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = hclregnotasmedi.sia_codpfa_prof,
                                          Hcl_sisfec_hcnm = (DateTime)hclregnotasmedi.hcl_sisfec_hcnm,
                                          Hcl_sishor_hcnm = (Decimal)hclregnotasmedi.hcl_sishor_hcnm,
                                          Sis_estpro_espr = hclregnotasmedi.sis_estpro_espr,
                                          Hcl_destur_hctu = hctu.hcl_destur_hctu,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #region Registro unico desde notas evolucion
        /// <summary>
        /// <para>devuelve un registro del tipo Hclregnotasmedi, registro notas de enfermeria o evolucion medica </para>
        /// <para>tcrCodigoRegistro: "IG" o Registro unico desde notas evolucion</para>
        /// </summary>
        public static ModeloHclregnotasmedi fobRegistroHclregnotasmedi(String tcrCodigoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                #region consulta
                var lobConsulta = from hclregnotasmedi in _context.Hclregnotasmedi
                                  join hcltiporegturno in _context.Hcltiporegturno on hclregnotasmedi.hcl_tiptur_hctu equals hcltiporegturno.hcl_tiptur_hctu into tmhcltiporegturno
                                  join siamaeprofsalud in _context.Siamaeprofsalud on hclregnotasmedi.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                  join sisestadoproces in _context.Sisestadoproces on hclregnotasmedi.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  from hctu in tmhcltiporegturno.DefaultIfEmpty()
                                  from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  where hclregnotasmedi.hcl_nroreg_hcnm == tcrCodigoRegistro
                                  select new ModeloHclregnotasmedi
                                  {
                                      Hcl_nroreg_hcnm = hclregnotasmedi.hcl_nroreg_hcnm,
                                      Hcl_notreg_hcnm = hclregnotasmedi.hcl_notreg_hcnm,
                                      Hcl_nroreg_hcms = hclregnotasmedi.hcl_nroreg_hcms,
                                      Hcl_secreg_hcnm = (int)hclregnotasmedi.hcl_secreg_hcnm,
                                      Adm_secadm_rgad = hclregnotasmedi.adm_secadm_rgad,
                                      Sia_idesec_usua = hclregnotasmedi.sia_idesec_usua,
                                      Hcl_tipreg_hcnm = hclregnotasmedi.hcl_tipreg_hcnm,
                                      Hcl_gesfec_hcnm = (DateTime)hclregnotasmedi.hcl_gesfec_hcnm,
                                      Hcl_geshor_hcnm = (Decimal)hclregnotasmedi.hcl_geshor_hcnm,
                                      Hcl_tiptur_hctu = hclregnotasmedi.hcl_tiptur_hctu,
                                      Sia_codpfa_prof = hclregnotasmedi.sia_codpfa_prof,
                                      Hcl_sisfec_hcnm = (DateTime)hclregnotasmedi.hcl_sisfec_hcnm,
                                      Hcl_sishor_hcnm = (Decimal)hclregnotasmedi.hcl_sishor_hcnm,
                                      Sis_estpro_espr = hclregnotasmedi.sis_estpro_espr,
                                      Hcl_destur_hctu = hctu.hcl_destur_hctu,
                                      Sia_nompro_prof = prof.sia_nompro_prof,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                  };
                return lobConsulta.FirstOrDefault();
                #endregion
            }
        }
        #endregion
        #region Listar Registros Registro de Admision
        /// <summary>
        /// <para>DESCRIPCION: Retorna lista de registros tipo detalles en una admision segun parametro tcrTipoRegistros</para>
        /// <para>tcrTipoRegistros: EVOL" = Evoluiones medicas "NENF" = Notas de enfermeria</para>
        /// </summary>
        public static List<ModeloHclregnotasmedi> flsListaHclregnotasmediEx(String tcrTipoRegistros, String tcrCodigoAdmision)
        {
            using (_context = new DbAplicacion())
            {
                    #region consulta
                    var lobConsulta = from hclregnotasmedi in _context.Hclregnotasmedi
                                      join hclregordeserms in _context.Hclregordeserms on hclregnotasmedi.hcl_nroreg_hcms equals hclregordeserms.hcl_nroreg_hcms into tmhclregordeserms
                                      join hcltiporegturno in _context.Hcltiporegturno on hclregnotasmedi.hcl_tiptur_hctu equals hcltiporegturno.hcl_tiptur_hctu into tmhcltiporegturno
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregnotasmedi.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join sisestadoproces in _context.Sisestadoproces on hclregnotasmedi.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from hcms in tmhclregordeserms.DefaultIfEmpty()
                                      from hctu in tmhcltiporegturno.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where hclregnotasmedi.adm_secadm_rgad == tcrCodigoAdmision &&
                                            hcms.hcl_tipreg_hctr == tcrTipoRegistros
                                      orderby hcms.hcl_nroreg_hcms, hclregnotasmedi.hcl_nroreg_hcnm 

                                      select new ModeloHclregnotasmedi
                                      {
                                          Hcl_nroreg_hcnm = hclregnotasmedi.hcl_nroreg_hcnm,
                                          Hcl_notreg_hcnm = hclregnotasmedi.hcl_notreg_hcnm,
                                          Hcl_nroreg_hcms = hclregnotasmedi.hcl_nroreg_hcms,
                                          Hcl_secreg_hcnm = (int)hclregnotasmedi.hcl_secreg_hcnm,
                                          Adm_secadm_rgad = hclregnotasmedi.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregnotasmedi.sia_idesec_usua,
                                          Hcl_tipreg_hcnm = hclregnotasmedi.hcl_tipreg_hcnm,
                                          Hcl_gesfec_hcnm = (DateTime)hclregnotasmedi.hcl_gesfec_hcnm,
                                          Hcl_geshor_hcnm = (Decimal)hclregnotasmedi.hcl_geshor_hcnm,
                                          Hcl_tiptur_hctu = hclregnotasmedi.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = hclregnotasmedi.sia_codpfa_prof,
                                          Hcl_sisfec_hcnm = (DateTime)hclregnotasmedi.hcl_sisfec_hcnm,
                                          Hcl_sishor_hcnm = (Decimal)hclregnotasmedi.hcl_sishor_hcnm,
                                          Sis_estpro_espr = hclregnotasmedi.sis_estpro_espr,
                                          Hcl_destur_hctu = hctu.hcl_destur_hctu,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                    #endregion
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Maestro Balance de liquidos
    /// </summary>
    public class ModeloHclregbliqidoms : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_nroreg_hcbm: Codigo registro maestro
        private String _hcl_nroreg_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Codigo registro maestro</para>
        /// <para>NOMBRE: hcl_nroreg_hcbm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial unico registro maestro balance de liquidos
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcbm
        {
            get { return _hcl_nroreg_hcbm; }
            set
            {
                if (_hcl_nroreg_hcbm == value) return;
                _hcl_nroreg_hcbm = value;
                OnPropertyChanged("Hcl_nroreg_hcbm");
            }
        }
        #endregion
        #region Hcl_secreg_hcbm: Secuencial evento
        private long _hcl_secreg_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Secuencial evento</para>
        /// <para>NOMBRE: hcl_secreg_hcbm (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del registro medico  para organizar la vista
        /// cronologica
        /// </para>
        /// </summary>
        public long Hcl_secreg_hcbm
        {
            get { return _hcl_secreg_hcbm; }
            set
            {
                if (_hcl_secreg_hcbm == value) return;
                _hcl_secreg_hcbm = value;
                OnPropertyChanged("Hcl_secreg_hcbm");
            }
        }
        #endregion
        #region Hcl_nroreg_hcev: Codigo Evento medico
        private String _hcl_nroreg_hcev;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: hcl_nroreg_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código secuencial actividad medica en historial medico del
        /// paciente
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcev
        {
            get { return _hcl_nroreg_hcev; }
            set
            {
                if (_hcl_nroreg_hcev == value) return;
                _hcl_nroreg_hcev = value;
                OnPropertyChanged("Hcl_nroreg_hcev");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region Hcl_nrorea_hcbm: Registro turno anterior
        private String _hcl_nrorea_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Registro turno anterior</para>
        /// <para>NOMBRE: hcl_nrorea_hcbm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código registro maestro balance de liquidos anterior (turno
        /// que entrega para darle paso a apertura actual)
        /// </para>
        /// </summary>
        public String Hcl_nrorea_hcbm
        {
            get { return _hcl_nrorea_hcbm; }
            set
            {
                if (_hcl_nrorea_hcbm == value) return;
                _hcl_nrorea_hcbm = value;
                OnPropertyChanged("Hcl_nrorea_hcbm");
            }
        }
        #endregion
        #region Hcl_fecape_hcbm: Fecha inicia turno
        private DateTime _hcl_fecape_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Fecha inicia turno</para>
        /// <para>NOMBRE: hcl_fecape_hcbm (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha apertura del turno o inicio del turno
        /// </para>
        /// </summary>
        public DateTime Hcl_fecape_hcbm
        {
            get { return _hcl_fecape_hcbm; }
            set
            {
                if (_hcl_fecape_hcbm == value) return;
                _hcl_fecape_hcbm = value;
                OnPropertyChanged("Hcl_fecape_hcbm");
            }
        }
        #endregion
        #region Hcl_tiptur_hctu: Codigo turno
        private String _hcl_tiptur_hctu;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Codigo turno</para>
        /// <para>NOMBRE: hcl_tiptur_hctu (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion turnos diarios para la prestacion de servicios
        /// medicos
        /// </para>
        /// </summary>
        public String Hcl_tiptur_hctu
        {
            get { return _hcl_tiptur_hctu; }
            set
            {
                if (_hcl_tiptur_hctu == value) return;
                _hcl_tiptur_hctu = value;
                OnPropertyChanged("Hcl_tiptur_hctu");
            }
        }
        #endregion
        #region Sia_codare_aser: Area de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Area de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Hcl_horini_hcbm: Hora inicia turno
        private Decimal _hcl_horini_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Hora inicia turno</para>
        /// <para>NOMBRE: hcl_horini_hcbm (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Hora en que inicia suministro de liquido al paciente corresponde
        /// a la hora inicio de turno   en formato militar (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_horini_hcbm
        {
            get { return _hcl_horini_hcbm; }
            set
            {
                if (_hcl_horini_hcbm == value) return;
                _hcl_horini_hcbm = value;
                OnPropertyChanged("Hcl_horini_hcbm");
            }
        }
        #endregion
        #region Hcl_horfin_hcbm: Hora finaliza turno
        private Decimal _hcl_horfin_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Hora finaliza turno</para>
        /// <para>NOMBRE: hcl_horfin_hcbm (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Hora en que finaliza el suministro de liquido al paciente correspondiente
        /// a la hora en que finnaliza el turno en formato militar  (HH)
        /// ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_horfin_hcbm
        {
            get { return _hcl_horfin_hcbm; }
            set
            {
                if (_hcl_horfin_hcbm == value) return;
                _hcl_horfin_hcbm = value;
                OnPropertyChanged("Hcl_horfin_hcbm");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional del turno de servicio medicamento
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
        #region Hcl_sisfec_hcbm: Fecha sistema
        private DateTime _hcl_sisfec_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Fecha sistema</para>
        /// <para>NOMBRE: hcl_sisfec_hcbm (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Fecha  del sistema cuando se genera registro del evento
        /// </para>
        /// </summary>
        public DateTime Hcl_sisfec_hcbm
        {
            get { return _hcl_sisfec_hcbm; }
            set
            {
                if (_hcl_sisfec_hcbm == value) return;
                _hcl_sisfec_hcbm = value;
                OnPropertyChanged("Hcl_sisfec_hcbm");
            }
        }
        #endregion
        #region Hcl_sishor_hcbm: Hora sistema
        private Decimal _hcl_sishor_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Hora sistema</para>
        /// <para>NOMBRE: hcl_sishor_hcbm (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema al generar registro de evento en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_sishor_hcbm
        {
            get { return _hcl_sishor_hcbm; }
            set
            {
                if (_hcl_sishor_hcbm == value) return;
                _hcl_sishor_hcbm = value;
                OnPropertyChanged("Hcl_sishor_hcbm");
            }
        }
        #endregion
        #region Hcl_totape_hcbm: Pendiente administrar
        private Decimal _hcl_totape_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Pendiente administrar</para>
        /// <para>NOMBRE: hcl_totape_hcbm (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Cantidad total pendiente por administrar al momento de la apertura
        /// del turno
        /// </para>
        /// </summary>
        public Decimal Hcl_totape_hcbm
        {
            get { return _hcl_totape_hcbm; }
            set
            {
                if (_hcl_totape_hcbm == value) return;
                _hcl_totape_hcbm = value;
                OnPropertyChanged("Hcl_totape_hcbm");
            }
        }
        #endregion
        #region Hcl_obsape_hcbm: Observacion apertura
        private String _hcl_obsape_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Observacion apertura</para>
        /// <para>NOMBRE: hcl_obsape_hcbm (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Observacion para apertura del turno
        /// </para>
        /// </summary>
        public String Hcl_obsape_hcbm
        {
            get { return _hcl_obsape_hcbm; }
            set
            {
                if (_hcl_obsape_hcbm == value) return;
                _hcl_obsape_hcbm = value;
                OnPropertyChanged("Hcl_obsape_hcbm");
            }
        }
        #endregion
        #region Hcl_feccie_hcbm: Fecha entrega turno
        private DateTime _hcl_feccie_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Fecha entrega turno</para>
        /// <para>NOMBRE: hcl_feccie_hcbm (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Datos del cierre  - Fecha cierre o entrega del turno
        /// </para>
        /// </summary>
        public DateTime Hcl_feccie_hcbm
        {
            get { return _hcl_feccie_hcbm; }
            set
            {
                if (_hcl_feccie_hcbm == value) return;
                _hcl_feccie_hcbm = value;
                OnPropertyChanged("Hcl_feccie_hcbm");
            }
        }
        #endregion
        #region Hcl_horcie_hcbm: Hora entrega turno
        private Decimal _hcl_horcie_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Hora entrega turno</para>
        /// <para>NOMBRE: hcl_horcie_hcbm (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Datos del cierre  - Hora en que se entrega el turno en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_horcie_hcbm
        {
            get { return _hcl_horcie_hcbm; }
            set
            {
                if (_hcl_horcie_hcbm == value) return;
                _hcl_horcie_hcbm = value;
                OnPropertyChanged("Hcl_horcie_hcbm");
            }
        }
        #endregion
        #region Hcl_totadm_hcbm: Total administrados
        private Decimal _hcl_totadm_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Total administrados</para>
        /// <para>NOMBRE: hcl_totadm_hcbm (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Datos del cierre  - Cantidad total de liquido administrado
        /// durante el turno al momento del cierre
        /// </para>
        /// </summary>
        public Decimal Hcl_totadm_hcbm
        {
            get { return _hcl_totadm_hcbm; }
            set
            {
                if (_hcl_totadm_hcbm == value) return;
                _hcl_totadm_hcbm = value;
                OnPropertyChanged("Hcl_totadm_hcbm");
            }
        }
        #endregion
        #region Hcl_totind_hcbm: Total indicados
        private Decimal _hcl_totind_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Total indicados</para>
        /// <para>NOMBRE: hcl_totind_hcbm (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Datos del cierre  - Cantidad total de liquido indicados durante
        /// el turno al momento del cierre
        /// </para>
        /// </summary>
        public Decimal Hcl_totind_hcbm
        {
            get { return _hcl_totind_hcbm; }
            set
            {
                if (_hcl_totind_hcbm == value) return;
                _hcl_totind_hcbm = value;
                OnPropertyChanged("Hcl_totind_hcbm");
            }
        }
        #endregion
        #region Hcl_toteli_hcbm: Total eliminados
        private Decimal _hcl_toteli_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Total eliminados</para>
        /// <para>NOMBRE: hcl_toteli_hcbm (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Datos del cierre  - Cantidad total de liquido eliminados durante
        /// el turno al momento del cierre
        /// </para>
        /// </summary>
        public Decimal Hcl_toteli_hcbm
        {
            get { return _hcl_toteli_hcbm; }
            set
            {
                if (_hcl_toteli_hcbm == value) return;
                _hcl_toteli_hcbm = value;
                OnPropertyChanged("Hcl_toteli_hcbm");
            }
        }
        #endregion
        #region Hcl_result_hcbm: Resultado turno
        private Decimal _hcl_result_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Resultado turno</para>
        /// <para>NOMBRE: hcl_result_hcbm (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Datos del cierre  - Resultado final del turno al momento del
        /// cierre (Resultado = Administrados - Eliminados)
        /// </para>
        /// </summary>
        public Decimal Hcl_result_hcbm
        {
            get { return _hcl_result_hcbm; }
            set
            {
                if (_hcl_result_hcbm == value) return;
                _hcl_result_hcbm = value;
                OnPropertyChanged("Hcl_result_hcbm");
            }
        }
        #endregion
        #region Hcl_totpen_hcbm: Pendiente administrar
        private Decimal _hcl_totpen_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Pendiente administrar</para>
        /// <para>NOMBRE: hcl_totpen_hcbm (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Datos del cierre  - Cantidad total pendiente por  administrar
        /// al momento del cierre
        /// </para>
        /// </summary>
        public Decimal Hcl_totpen_hcbm
        {
            get { return _hcl_totpen_hcbm; }
            set
            {
                if (_hcl_totpen_hcbm == value) return;
                _hcl_totpen_hcbm = value;
                OnPropertyChanged("Hcl_totpen_hcbm");
            }
        }
        #endregion
        #region Hcl_obscie_hcbm: Observacion cierre
        private String _hcl_obscie_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Observacion cierre</para>
        /// <para>NOMBRE: hcl_obscie_hcbm (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Observacion para cierre del turno del turno
        /// </para>
        /// </summary>
        public String Hcl_obscie_hcbm
        {
            get { return _hcl_obscie_hcbm; }
            set
            {
                if (_hcl_obscie_hcbm == value) return;
                _hcl_obscie_hcbm = value;
                OnPropertyChanged("Hcl_obscie_hcbm");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        #region Hcl_desreg_hcev: Descripción Evento
        private String _hcl_desreg_hcev;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Descripción Evento</para>
        /// <para>NOMBRE: hcl_desreg_hcev (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion evento medico
        /// </para>
        /// </summary>
        public String Hcl_desreg_hcev
        {
            get { return _hcl_desreg_hcev; }
            set
            {
                if (_hcl_desreg_hcev == value) return;
                _hcl_desreg_hcev = value;
                OnPropertyChanged("Hcl_desreg_hcev");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
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
        #region Hcl_destur_hctu: Descripcion del turno diario
        private String _hcl_destur_hctu;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Descripcion</para>
        /// <para>NOMBRE: hcl_destur_hctu (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion  clasificacion turnos diarios
        /// </para>
        /// </summary>
        public String Hcl_destur_hctu
        {
            get { return _hcl_destur_hctu; }
            set
            {
                if (_hcl_destur_hctu == value) return;
                _hcl_destur_hctu = value;
                OnPropertyChanged("Hcl_destur_hctu");
            }
        }
        #endregion
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
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
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
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
        /// <para>TABLA: hclregbliqidoms</para>
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
        public static string flgAddRegistro(ModeloHclregbliqidoms tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-BALANCE-LIQUIDOSMS", "HCL", "Secuencial Balance de liquidos");
            if (!flgBuscarHclregbliqidoms(lcrCodigoGen))
            {
                var lnullaveIndice = Funciones.fnuFechaLlaveIndiceRegistro(tobjModelo.Hcl_fecape_hcbm, tobjModelo.Hcl_horini_hcbm);

                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFhclregbliqidoms
                    {
                        #region cargar Registro
                        hcl_nroreg_hcbm = tobjModelo.Hcl_nroreg_hcbm,
                        hcl_secreg_hcbm = lnullaveIndice,
                        hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        hcl_nrorea_hcbm = tobjModelo.Hcl_nrorea_hcbm,
                        hcl_fecape_hcbm = tobjModelo.Hcl_fecape_hcbm,
                        hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu,
                        sia_codare_aser = tobjModelo.Sia_codare_aser,
                        hcl_horini_hcbm = tobjModelo.Hcl_horini_hcbm,
                        hcl_horfin_hcbm = tobjModelo.Hcl_horfin_hcbm,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        hcl_sisfec_hcbm = tobjModelo.Hcl_sisfec_hcbm,
                        hcl_sishor_hcbm = tobjModelo.Hcl_sishor_hcbm,
                        hcl_totape_hcbm = tobjModelo.Hcl_totape_hcbm,
                        hcl_obsape_hcbm = tobjModelo.Hcl_obsape_hcbm,
                        hcl_feccie_hcbm = tobjModelo.Hcl_feccie_hcbm,
                        hcl_horcie_hcbm = tobjModelo.Hcl_horcie_hcbm,
                        hcl_totind_hcbm = tobjModelo.Hcl_totind_hcbm,
                        hcl_totadm_hcbm = tobjModelo.Hcl_totadm_hcbm,
                        hcl_toteli_hcbm = tobjModelo.Hcl_toteli_hcbm,
                        hcl_result_hcbm = tobjModelo.Hcl_result_hcbm,
                        hcl_totpen_hcbm = tobjModelo.Hcl_totpen_hcbm,
                        hcl_obscie_hcbm = tobjModelo.Hcl_obscie_hcbm,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.hcl_nroreg_hcbm = lcrCodigoGen;
                    _context.AddToHclregbliqidoms(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'SECUENCIAL BALANCE DE LIQUIDOS':  en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHclregbliqidoms tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregbliqidoms.FirstOrDefault(p => p.hcl_nroreg_hcbm == tobjModelo.Hcl_nroreg_hcbm);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hcl_nroreg_hcbm = tobjModelo.Hcl_nroreg_hcbm;
                    lobjRegistro.hcl_secreg_hcbm = tobjModelo.Hcl_secreg_hcbm;
                    lobjRegistro.hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.hcl_nrorea_hcbm = tobjModelo.Hcl_nrorea_hcbm;
                    lobjRegistro.hcl_fecape_hcbm = (DateTime)tobjModelo.Hcl_fecape_hcbm;
                    lobjRegistro.hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu;
                    lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                    lobjRegistro.hcl_horini_hcbm = (Decimal)tobjModelo.Hcl_horini_hcbm;
                    lobjRegistro.hcl_horfin_hcbm = (Decimal)tobjModelo.Hcl_horfin_hcbm;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.hcl_sisfec_hcbm = (DateTime)tobjModelo.Hcl_sisfec_hcbm;
                    lobjRegistro.hcl_sishor_hcbm = (Decimal)tobjModelo.Hcl_sishor_hcbm;
                    lobjRegistro.hcl_totape_hcbm = (Decimal)tobjModelo.Hcl_totape_hcbm;
                    lobjRegistro.hcl_obsape_hcbm = tobjModelo.Hcl_obsape_hcbm;
                    lobjRegistro.hcl_feccie_hcbm = (DateTime)tobjModelo.Hcl_feccie_hcbm;
                    lobjRegistro.hcl_horcie_hcbm = (Decimal)tobjModelo.Hcl_horcie_hcbm;
                    lobjRegistro.hcl_totind_hcbm = (Decimal)tobjModelo.Hcl_totind_hcbm;
                    lobjRegistro.hcl_totadm_hcbm = (Decimal)tobjModelo.Hcl_totadm_hcbm;
                    lobjRegistro.hcl_toteli_hcbm = (Decimal)tobjModelo.Hcl_toteli_hcbm;
                    lobjRegistro.hcl_result_hcbm = (Decimal)tobjModelo.Hcl_result_hcbm;
                    lobjRegistro.hcl_totpen_hcbm = (Decimal)tobjModelo.Hcl_totpen_hcbm;
                    lobjRegistro.hcl_obscie_hcbm = tobjModelo.Hcl_obscie_hcbm;
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
                var lobjRegistro = _context.Hclregbliqidoms.FirstOrDefault(p => p.hcl_nroreg_hcbm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar HCLREGBLIQIDOMS: Logica
        /// <summary>
        /// <para>TABLA: hclregbliqidoms</para>
        /// <para>TITULO: Maestro registros balance de liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Registro  maestro que agrupa un turno balance de liquidos administrados
        /// y eliminados en cada turno medico o de enfermeria y datos total
        /// del cierre
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregbliqidoms(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregbliqidoms.FirstOrDefault(p => p.hcl_nroreg_hcbm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region flsListaHclregbliqidomsEx: Listar Registros
        /// <summary>
        /// <para>tcrTipoConsulta:</para>
        /// <para>"1" = Consulta normal por campo Hcl_nroreg_hcbm IG de la tabla</para>
        /// <para>"2" = Consulta por registro de admision</para>
        /// <para>tcrEstadoRegistro:</para>
        /// <para>Estado registro: "1" = Abierto "2" = Confirmados "3" = Anulados  "" = vacio/todas</para>
        /// <para>El estado registro se usa para  tcrTipoConsulta =="2"</para>
        /// </summary>
        public static List<ModeloHclregbliqidoms> flsListaHclregbliqidomsEx(String tcrTipoConsulta, String tcrIDCodigo, String tcrEstadoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                if (tcrTipoConsulta == "2")
                {
                    if (!String.IsNullOrWhiteSpace(tcrEstadoRegistro))
                    {
                        #region consulta
                        var lobConsulta = from hclregbliqidoms in _context.Hclregbliqidoms
                                          join hcltiporegturno in _context.Hcltiporegturno on hclregbliqidoms.hcl_tiptur_hctu equals hcltiporegturno.hcl_tiptur_hctu into tmhcltiporegturno
                                          join siaareapreservi in _context.Siaareapreservi on hclregbliqidoms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                          join siamaeprofsalud in _context.Siamaeprofsalud on hclregbliqidoms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                          join sisestadoproces in _context.Sisestadoproces on hclregbliqidoms.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                          from hctu in tmhcltiporegturno.DefaultIfEmpty()
                                          from aser in tmsiaareapreservi.DefaultIfEmpty()
                                          from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                          from espr in tmsisestadoproces.DefaultIfEmpty()
                                          where hclregbliqidoms.adm_secadm_rgad == tcrIDCodigo &&
                                                hclregbliqidoms.sis_estpro_espr == tcrEstadoRegistro
                                          orderby hclregbliqidoms.hcl_secreg_hcbm descending
                                          select new ModeloHclregbliqidoms
                                          {
                                              Hcl_nroreg_hcbm = hclregbliqidoms.hcl_nroreg_hcbm,
                                              Hcl_secreg_hcbm = (long)hclregbliqidoms.hcl_secreg_hcbm,
                                              Hcl_nroreg_hcev = hclregbliqidoms.hcl_nroreg_hcev,
                                              Adm_secadm_rgad = hclregbliqidoms.adm_secadm_rgad,
                                              Sia_idesec_usua = hclregbliqidoms.sia_idesec_usua,
                                              Hcl_nrorea_hcbm = hclregbliqidoms.hcl_nrorea_hcbm,
                                              Hcl_fecape_hcbm = (DateTime)hclregbliqidoms.hcl_fecape_hcbm,
                                              Hcl_tiptur_hctu = hclregbliqidoms.hcl_tiptur_hctu,
                                              Sia_codare_aser = hclregbliqidoms.sia_codare_aser,
                                              Hcl_horini_hcbm = (Decimal)hclregbliqidoms.hcl_horini_hcbm,
                                              Hcl_horfin_hcbm = (Decimal)hclregbliqidoms.hcl_horfin_hcbm,
                                              Sia_codpfa_prof = hclregbliqidoms.sia_codpfa_prof,
                                              Hcl_sisfec_hcbm = (DateTime)hclregbliqidoms.hcl_sisfec_hcbm,
                                              Hcl_sishor_hcbm = (Decimal)hclregbliqidoms.hcl_sishor_hcbm,
                                              Hcl_totape_hcbm = (Decimal)hclregbliqidoms.hcl_totape_hcbm,
                                              Hcl_obsape_hcbm = hclregbliqidoms.hcl_obsape_hcbm,
                                              Hcl_feccie_hcbm = (DateTime)hclregbliqidoms.hcl_feccie_hcbm,
                                              Hcl_horcie_hcbm = (Decimal)hclregbliqidoms.hcl_horcie_hcbm,
                                              Hcl_totind_hcbm = (Decimal)hclregbliqidoms.hcl_totind_hcbm,
                                              Hcl_totadm_hcbm = (Decimal)hclregbliqidoms.hcl_totadm_hcbm,
                                              Hcl_toteli_hcbm = (Decimal)hclregbliqidoms.hcl_toteli_hcbm,
                                              Hcl_result_hcbm = (Decimal)hclregbliqidoms.hcl_result_hcbm,
                                              Hcl_totpen_hcbm = (Decimal)hclregbliqidoms.hcl_totpen_hcbm,
                                              Hcl_obscie_hcbm = hclregbliqidoms.hcl_obscie_hcbm,
                                              Sis_estpro_espr = hclregbliqidoms.sis_estpro_espr,
                                              Hcl_destur_hctu = hctu.hcl_destur_hctu,
                                              Sia_desare_aser = aser.sia_desare_aser,
                                              Sia_nompro_prof = prof.sia_nompro_prof,
                                              Sis_despro_espr = espr.sis_despro_espr,
                                          };
                        return lobConsulta.ToList();
                        #endregion
                    }
                    else 
                    {
                        #region consulta
                        var lobConsulta = from hclregbliqidoms in _context.Hclregbliqidoms
                                          join hcltiporegturno in _context.Hcltiporegturno on hclregbliqidoms.hcl_tiptur_hctu equals hcltiporegturno.hcl_tiptur_hctu into tmhcltiporegturno
                                          join siaareapreservi in _context.Siaareapreservi on hclregbliqidoms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                          join siamaeprofsalud in _context.Siamaeprofsalud on hclregbliqidoms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                          join sisestadoproces in _context.Sisestadoproces on hclregbliqidoms.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                          from hctu in tmhcltiporegturno.DefaultIfEmpty()
                                          from aser in tmsiaareapreservi.DefaultIfEmpty()
                                          from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                          from espr in tmsisestadoproces.DefaultIfEmpty()
                                          where hclregbliqidoms.adm_secadm_rgad == tcrIDCodigo
                                          orderby hclregbliqidoms.hcl_secreg_hcbm descending
                                          select new ModeloHclregbliqidoms
                                          {
                                              Hcl_nroreg_hcbm = hclregbliqidoms.hcl_nroreg_hcbm,
                                              Hcl_secreg_hcbm = (long)hclregbliqidoms.hcl_secreg_hcbm,
                                              Hcl_nroreg_hcev = hclregbliqidoms.hcl_nroreg_hcev,
                                              Adm_secadm_rgad = hclregbliqidoms.adm_secadm_rgad,
                                              Sia_idesec_usua = hclregbliqidoms.sia_idesec_usua,
                                              Hcl_nrorea_hcbm = hclregbliqidoms.hcl_nrorea_hcbm,
                                              Hcl_fecape_hcbm = (DateTime)hclregbliqidoms.hcl_fecape_hcbm,
                                              Hcl_tiptur_hctu = hclregbliqidoms.hcl_tiptur_hctu,
                                              Sia_codare_aser = hclregbliqidoms.sia_codare_aser,
                                              Hcl_horini_hcbm = (Decimal)hclregbliqidoms.hcl_horini_hcbm,
                                              Hcl_horfin_hcbm = (Decimal)hclregbliqidoms.hcl_horfin_hcbm,
                                              Sia_codpfa_prof = hclregbliqidoms.sia_codpfa_prof,
                                              Hcl_sisfec_hcbm = (DateTime)hclregbliqidoms.hcl_sisfec_hcbm,
                                              Hcl_sishor_hcbm = (Decimal)hclregbliqidoms.hcl_sishor_hcbm,
                                              Hcl_totape_hcbm = (Decimal)hclregbliqidoms.hcl_totape_hcbm,
                                              Hcl_obsape_hcbm = hclregbliqidoms.hcl_obsape_hcbm,
                                              Hcl_feccie_hcbm = (DateTime)hclregbliqidoms.hcl_feccie_hcbm,
                                              Hcl_horcie_hcbm = (Decimal)hclregbliqidoms.hcl_horcie_hcbm,
                                              Hcl_totind_hcbm = (Decimal)hclregbliqidoms.hcl_totind_hcbm,
                                              Hcl_totadm_hcbm = (Decimal)hclregbliqidoms.hcl_totadm_hcbm,
                                              Hcl_toteli_hcbm = (Decimal)hclregbliqidoms.hcl_toteli_hcbm,
                                              Hcl_result_hcbm = (Decimal)hclregbliqidoms.hcl_result_hcbm,
                                              Hcl_totpen_hcbm = (Decimal)hclregbliqidoms.hcl_totpen_hcbm,
                                              Hcl_obscie_hcbm = hclregbliqidoms.hcl_obscie_hcbm,
                                              Sis_estpro_espr = hclregbliqidoms.sis_estpro_espr,
                                              Hcl_destur_hctu = hctu.hcl_destur_hctu,
                                              Sia_desare_aser = aser.sia_desare_aser,
                                              Sia_nompro_prof = prof.sia_nompro_prof,
                                              Sis_despro_espr = espr.sis_despro_espr,
                                          };
                        return lobConsulta.ToList();
                        #endregion
                    }
                }
                else
                {
                    #region consulta
                    var lobConsulta = from hclregbliqidoms in _context.Hclregbliqidoms
                                      join hcltiporegturno in _context.Hcltiporegturno on hclregbliqidoms.hcl_tiptur_hctu equals hcltiporegturno.hcl_tiptur_hctu into tmhcltiporegturno
                                      join siaareapreservi in _context.Siaareapreservi on hclregbliqidoms.sia_codare_aser equals siaareapreservi.sia_codare_aser into tmsiaareapreservi
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregbliqidoms.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join sisestadoproces in _context.Sisestadoproces on hclregbliqidoms.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from hctu in tmhcltiporegturno.DefaultIfEmpty()
                                      from aser in tmsiaareapreservi.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where hclregbliqidoms.hcl_nroreg_hcbm == tcrIDCodigo
                                      orderby hclregbliqidoms.hcl_secreg_hcbm descending
                                      select new ModeloHclregbliqidoms
                                      {
                                          Hcl_nroreg_hcbm = hclregbliqidoms.hcl_nroreg_hcbm,
                                          Hcl_secreg_hcbm = (long)hclregbliqidoms.hcl_secreg_hcbm,
                                          Hcl_nroreg_hcev = hclregbliqidoms.hcl_nroreg_hcev,
                                          Adm_secadm_rgad = hclregbliqidoms.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregbliqidoms.sia_idesec_usua,
                                          Hcl_nrorea_hcbm = hclregbliqidoms.hcl_nrorea_hcbm,
                                          Hcl_fecape_hcbm = (DateTime)hclregbliqidoms.hcl_fecape_hcbm,
                                          Hcl_tiptur_hctu = hclregbliqidoms.hcl_tiptur_hctu,
                                          Sia_codare_aser = hclregbliqidoms.sia_codare_aser,
                                          Hcl_horini_hcbm = (Decimal)hclregbliqidoms.hcl_horini_hcbm,
                                          Hcl_horfin_hcbm = (Decimal)hclregbliqidoms.hcl_horfin_hcbm,
                                          Sia_codpfa_prof = hclregbliqidoms.sia_codpfa_prof,
                                          Hcl_sisfec_hcbm = (DateTime)hclregbliqidoms.hcl_sisfec_hcbm,
                                          Hcl_sishor_hcbm = (Decimal)hclregbliqidoms.hcl_sishor_hcbm,
                                          Hcl_totape_hcbm = (Decimal)hclregbliqidoms.hcl_totape_hcbm,
                                          Hcl_obsape_hcbm = hclregbliqidoms.hcl_obsape_hcbm,
                                          Hcl_feccie_hcbm = (DateTime)hclregbliqidoms.hcl_feccie_hcbm,
                                          Hcl_horcie_hcbm = (Decimal)hclregbliqidoms.hcl_horcie_hcbm,
                                          Hcl_totind_hcbm = (Decimal)hclregbliqidoms.hcl_totind_hcbm,
                                          Hcl_totadm_hcbm = (Decimal)hclregbliqidoms.hcl_totadm_hcbm,
                                          Hcl_toteli_hcbm = (Decimal)hclregbliqidoms.hcl_toteli_hcbm,
                                          Hcl_result_hcbm = (Decimal)hclregbliqidoms.hcl_result_hcbm,
                                          Hcl_totpen_hcbm = (Decimal)hclregbliqidoms.hcl_totpen_hcbm,
                                          Hcl_obscie_hcbm = hclregbliqidoms.hcl_obscie_hcbm,
                                          Sis_estpro_espr = hclregbliqidoms.sis_estpro_espr,
                                          Hcl_destur_hctu = hctu.hcl_destur_hctu,
                                          Sia_desare_aser = aser.sia_desare_aser,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Detalles registros para balance de liquidos
    /// </summary>
    public class ModeloHclregbliqidode : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_nroreg_hcbd: Codigo registro actividad
        private String _hcl_nroreg_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Codigo registro actividad</para>
        /// <para>NOMBRE: hcl_nroreg_hcbd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial unico  registro liquidos adminstrados o eliminados
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcbd
        {
            get { return _hcl_nroreg_hcbd; }
            set
            {
                if (_hcl_nroreg_hcbd == value) return;
                _hcl_nroreg_hcbd = value;
                OnPropertyChanged("Hcl_nroreg_hcbd");
            }
        }
        #endregion
        #region Hcl_nroreg_hcbm: Codigo registro maestro
        private String _hcl_nroreg_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Codigo registro maestro</para>
        /// <para>NOMBRE: hcl_nroreg_hcbm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código secuencial unico registro maestro balance de liquidos
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcbm
        {
            get { return _hcl_nroreg_hcbm; }
            set
            {
                if (_hcl_nroreg_hcbm == value) return;
                _hcl_nroreg_hcbm = value;
                OnPropertyChanged("Hcl_nroreg_hcbm");
            }
        }
        #endregion
        #region Hcl_secreg_hcbd: Secuencial evento
        private long _hcl_secreg_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Secuencial evento</para>
        /// <para>NOMBRE: hcl_secreg_hcbd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero secuencial del registro medico  para organizar la vista
        /// cronologica
        /// </para>
        /// </summary>
        public long Hcl_secreg_hcbd
        {
            get { return _hcl_secreg_hcbd; }
            set
            {
                if (_hcl_secreg_hcbd == value) return;
                _hcl_secreg_hcbd = value;
                OnPropertyChanged("Hcl_secreg_hcbd");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region Hcl_codliq_hctl: Tipo liquido
        private String _hcl_codliq_hctl;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hcltipoliquidos</para>
        /// <para>CAMPO: Tipo liquido</para>
        /// <para>NOMBRE: hcl_codliq_hctl (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codigo tipo liquido administrado o eliminado
        /// </para>
        /// </summary>
        public String Hcl_codliq_hctl
        {
            get { return _hcl_codliq_hctl; }
            set
            {
                if (_hcl_codliq_hctl == value) return;
                _hcl_codliq_hctl = value;
                OnPropertyChanged("Hcl_codliq_hctl");
            }
        }
        #endregion
        #region Hcl_vialiq_hcvl: Via liquidos
        private String _hcl_vialiq_hcvl;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclviasliquidos</para>
        /// <para>CAMPO: Via liquidos</para>
        /// <para>NOMBRE: hcl_vialiq_hcvl (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Via administracion o eliminacion de liquido
        /// </para>
        /// </summary>
        public String Hcl_vialiq_hcvl
        {
            get { return _hcl_vialiq_hcvl; }
            set
            {
                if (_hcl_vialiq_hcvl == value) return;
                _hcl_vialiq_hcvl = value;
                OnPropertyChanged("Hcl_vialiq_hcvl");
            }
        }
        #endregion
        #region Hcl_gesfec_hcbd: Fecha actividad
        private DateTime _hcl_gesfec_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Fecha actividad</para>
        /// <para>NOMBRE: hcl_gesfec_hcbd (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Fecha registro actividad
        /// </para>
        /// </summary>
        public DateTime Hcl_gesfec_hcbd
        {
            get { return _hcl_gesfec_hcbd; }
            set
            {
                if (_hcl_gesfec_hcbd == value) return;
                _hcl_gesfec_hcbd = value;
                OnPropertyChanged("Hcl_gesfec_hcbd");
            }
        }
        #endregion
        #region Hcl_tipreg_hcbd: Tipo Registro
        private String _hcl_tipreg_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Tipo Registro</para>
        /// <para>NOMBRE: hcl_tipreg_hcbd (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Tipo registro: 1= Indicados 2 = Administrado 3=Eliminado
        /// </para>
        /// </summary>
        public String Hcl_tipreg_hcbd
        {
            get { return _hcl_tipreg_hcbd; }
            set
            {
                if (_hcl_tipreg_hcbd == value) return;
                _hcl_tipreg_hcbd = value;
                OnPropertyChanged("Hcl_tipreg_hcbd");
            }
        }
        #endregion
        #region Hcl_cantid_hcbd: Cantidad de liquido
        private Decimal _hcl_cantid_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Cantidad de liquido</para>
        /// <para>NOMBRE: hcl_cantid_hcbd (decimal:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Cantidad de liquido administrado o eliminado
        /// </para>
        /// </summary>
        public Decimal Hcl_cantid_hcbd
        {
            get { return _hcl_cantid_hcbd; }
            set
            {
                if (_hcl_cantid_hcbd == value) return;
                _hcl_cantid_hcbd = value;
                OnPropertyChanged("Hcl_cantid_hcbd");
            }
        }
        #endregion
        #region Hcl_horini_hcbd: Hora inicia suministro
        private Decimal _hcl_horini_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Hora inicia suministro</para>
        /// <para>NOMBRE: hcl_horini_hcbd (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Hora en que inicia suministro de liquido al paciente en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_horini_hcbd
        {
            get { return _hcl_horini_hcbd; }
            set
            {
                if (_hcl_horini_hcbd == value) return;
                _hcl_horini_hcbd = value;
                OnPropertyChanged("Hcl_horini_hcbd");
            }
        }
        #endregion
        #region Hcl_horfin_hcbd: Hora finaliza suministro
        private Decimal _hcl_horfin_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Hora finaliza suministro</para>
        /// <para>NOMBRE: hcl_horfin_hcbd (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Hora en que finaliza el suministro de liquido al paciente en
        /// formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_horfin_hcbd
        {
            get { return _hcl_horfin_hcbd; }
            set
            {
                if (_hcl_horfin_hcbd == value) return;
                _hcl_horfin_hcbd = value;
                OnPropertyChanged("Hcl_horfin_hcbd");
            }
        }
        #endregion
        #region Hcl_horeli_hcbd: Hora eliminación
        private Decimal _hcl_horeli_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Hora eliminación</para>
        /// <para>NOMBRE: hcl_horeli_hcbd (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Hora en que paciente elimina  liquido formato militar  (HH)
        /// ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_horeli_hcbd
        {
            get { return _hcl_horeli_hcbd; }
            set
            {
                if (_hcl_horeli_hcbd == value) return;
                _hcl_horeli_hcbd = value;
                OnPropertyChanged("Hcl_horeli_hcbd");
            }
        }
        #endregion
        #region Hcl_tiptur_hctu: Codigo turno
        private String _hcl_tiptur_hctu;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Codigo turno</para>
        /// <para>NOMBRE: hcl_tiptur_hctu (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion turnos diarios para la prestacion de servicios
        /// medicos
        /// </para>
        /// </summary>
        public String Hcl_tiptur_hctu
        {
            get { return _hcl_tiptur_hctu; }
            set
            {
                if (_hcl_tiptur_hctu == value) return;
                _hcl_tiptur_hctu = value;
                OnPropertyChanged("Hcl_tiptur_hctu");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional del turno de servicio medicamento
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
        #region Hcl_sisfec_hcbd: Fecha sistema
        private DateTime _hcl_sisfec_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Fecha sistema</para>
        /// <para>NOMBRE: hcl_sisfec_hcbd (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Fecha  del sistema cuando se genera registro del evento
        /// </para>
        /// </summary>
        public DateTime Hcl_sisfec_hcbd
        {
            get { return _hcl_sisfec_hcbd; }
            set
            {
                if (_hcl_sisfec_hcbd == value) return;
                _hcl_sisfec_hcbd = value;
                OnPropertyChanged("Hcl_sisfec_hcbd");
            }
        }
        #endregion
        #region Hcl_sishor_hcbd: Hora sistema
        private Decimal _hcl_sishor_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Hora sistema</para>
        /// <para>NOMBRE: hcl_sishor_hcbd (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Hora de del sistema al generar registro de evento en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_sishor_hcbd
        {
            get { return _hcl_sishor_hcbd; }
            set
            {
                if (_hcl_sishor_hcbd == value) return;
                _hcl_sishor_hcbd = value;
                OnPropertyChanged("Hcl_sishor_hcbd");
            }
        }
        #endregion
        #region Hcl_notreg_hcbd: Observacion
        private String _hcl_notreg_hcbd;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidode</para>
        /// <para>CAMPO: Observacion</para>
        /// <para>NOMBRE: hcl_notreg_hcbd (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Nota de la actividad
        /// </para>
        /// </summary>
        public String Hcl_notreg_hcbd
        {
            get { return _hcl_notreg_hcbd; }
            set
            {
                if (_hcl_notreg_hcbd == value) return;
                _hcl_notreg_hcbd = value;
                OnPropertyChanged("Hcl_notreg_hcbd");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        #region Hcl_obsape_hcbm: Observacion apertura
        private String _hcl_obsape_hcbm;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclregbliqidoms</para>
        /// <para>CAMPO: Observacion apertura</para>
        /// <para>NOMBRE: hcl_obsape_hcbm (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Observacion para apertura del turno
        /// </para>
        /// </summary>
        public String Hcl_obsape_hcbm
        {
            get { return _hcl_obsape_hcbm; }
            set
            {
                if (_hcl_obsape_hcbm == value) return;
                _hcl_obsape_hcbm = value;
                OnPropertyChanged("Hcl_obsape_hcbm");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
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
        #region Hcl_desliq_hctl: Descripcion liquido
        private String _hcl_desliq_hctl;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hcltipoliquidos</para>
        /// <para>CAMPO: Descripcion liquido</para>
        /// <para>NOMBRE: hcl_desliq_hctl (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion  del liquido administrado o eliminado
        /// </para>
        /// </summary>
        public String Hcl_desliq_hctl
        {
            get { return _hcl_desliq_hctl; }
            set
            {
                if (_hcl_desliq_hctl == value) return;
                _hcl_desliq_hctl = value;
                OnPropertyChanged("Hcl_desliq_hctl");
            }
        }
        #endregion
        #region Hcl_desvia_hcvl: Descripcion vias
        private String _hcl_desvia_hcvl;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hclviasliquidos</para>
        /// <para>CAMPO: Descripcion vias</para>
        /// <para>NOMBRE: hcl_desvia_hcvl (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion vias de administracion o eliminacion de liquidos
        /// </para>
        /// </summary>
        public String Hcl_desvia_hcvl
        {
            get { return _hcl_desvia_hcvl; }
            set
            {
                if (_hcl_desvia_hcvl == value) return;
                _hcl_desvia_hcvl = value;
                OnPropertyChanged("Hcl_desvia_hcvl");
            }
        }
        #endregion
        #region Hcl_destur_hctu: Descripcion
        private String _hcl_destur_hctu;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Descripcion</para>
        /// <para>NOMBRE: hcl_destur_hctu (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion  clasificacion turnos diarios
        /// </para>
        /// </summary>
        public String Hcl_destur_hctu
        {
            get { return _hcl_destur_hctu; }
            set
            {
                if (_hcl_destur_hctu == value) return;
                _hcl_destur_hctu = value;
                OnPropertyChanged("Hcl_destur_hctu");
            }
        }
        #endregion
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
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
        /// <para>TABLA: hclregbliqidode</para>
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
        public static string flgAddRegistro(ModeloHclregbliqidode tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-HCLREGBLIQIDODE", "HCL", "Detalles registros balance de liquidos");
            if (!flgBuscarHclregbliqidode(lcrCodigoGen))
            {
                var lnuHora = tobjModelo.Hcl_tipreg_hcbd == "1" ? tobjModelo.Hcl_horini_hcbd : tobjModelo.Hcl_horeli_hcbd;
                var lnullaveIndice = Funciones.fnuFechaLlaveIndiceRegistro(tobjModelo.Hcl_gesfec_hcbd, lnuHora);

                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFhclregbliqidode
                    {
                        #region cargar Registro
                        hcl_nroreg_hcbd = tobjModelo.Hcl_nroreg_hcbd,
                        hcl_nroreg_hcbm = tobjModelo.Hcl_nroreg_hcbm,
                        hcl_secreg_hcbd = lnullaveIndice,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        hcl_codliq_hctl = tobjModelo.Hcl_codliq_hctl,
                        hcl_vialiq_hcvl = tobjModelo.Hcl_vialiq_hcvl,
                        hcl_gesfec_hcbd = tobjModelo.Hcl_gesfec_hcbd,
                        hcl_tipreg_hcbd = tobjModelo.Hcl_tipreg_hcbd,
                        hcl_cantid_hcbd = tobjModelo.Hcl_cantid_hcbd,
                        hcl_horini_hcbd = tobjModelo.Hcl_horini_hcbd,
                        hcl_horfin_hcbd = tobjModelo.Hcl_horfin_hcbd,
                        hcl_horeli_hcbd = tobjModelo.Hcl_horeli_hcbd,
                        hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        hcl_sisfec_hcbd = tobjModelo.Hcl_sisfec_hcbd,
                        hcl_sishor_hcbd = tobjModelo.Hcl_sishor_hcbd,
                        hcl_notreg_hcbd = tobjModelo.Hcl_notreg_hcbd,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.hcl_nroreg_hcbd = lcrCodigoGen;
                    _context.AddToHclregbliqidode(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-HCLREGBLIQIDODE': Detalles registros balance de liquidos en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHclregbliqidode tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregbliqidode.FirstOrDefault(p => p.hcl_nroreg_hcbd == tobjModelo.Hcl_nroreg_hcbd);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hcl_nroreg_hcbd = tobjModelo.Hcl_nroreg_hcbd;
                    lobjRegistro.hcl_nroreg_hcbm = tobjModelo.Hcl_nroreg_hcbm;
                    lobjRegistro.hcl_secreg_hcbd = tobjModelo.Hcl_secreg_hcbd;
                    lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.hcl_codliq_hctl = tobjModelo.Hcl_codliq_hctl;
                    lobjRegistro.hcl_vialiq_hcvl = tobjModelo.Hcl_vialiq_hcvl;
                    lobjRegistro.hcl_gesfec_hcbd = (DateTime)tobjModelo.Hcl_gesfec_hcbd;
                    lobjRegistro.hcl_tipreg_hcbd = tobjModelo.Hcl_tipreg_hcbd;
                    lobjRegistro.hcl_cantid_hcbd = (Decimal)tobjModelo.Hcl_cantid_hcbd;
                    lobjRegistro.hcl_horini_hcbd = (Decimal)tobjModelo.Hcl_horini_hcbd;
                    lobjRegistro.hcl_horfin_hcbd = (Decimal)tobjModelo.Hcl_horfin_hcbd;
                    lobjRegistro.hcl_horeli_hcbd = (Decimal)tobjModelo.Hcl_horeli_hcbd;
                    lobjRegistro.hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.hcl_sisfec_hcbd = (DateTime)tobjModelo.Hcl_sisfec_hcbd;
                    lobjRegistro.hcl_sishor_hcbd = (Decimal)tobjModelo.Hcl_sishor_hcbd;
                    lobjRegistro.hcl_notreg_hcbd = tobjModelo.Hcl_notreg_hcbd;
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
                var lobjRegistro = _context.Hclregbliqidode.FirstOrDefault(p => p.hcl_nroreg_hcbd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar HCLREGBLIQIDODE: Logica
        /// <summary>
        /// <para>TABLA: hclregbliqidode</para>
        /// <para>TITULO: Detalles registros balance de liquidos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Detalles registros balance de liquidos administrados y eliminados
        /// en cada turno medico o de enfermeria
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregbliqidode(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregbliqidode.FirstOrDefault(p => p.hcl_nroreg_hcbd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        /// <summary>
        /// <para>tcrTipo: "IG" = hcl_nroreg_hcor uno solo  "R1" = hcl_nroreg_hcms lista tipo detalles </para>
        /// </summary>
        public static List<ModeloHclregbliqidode> flsListaHclregbliqidode(String tcrTipo, String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (tcrTipo == "R1")
                {
                    #region consulta
                    var lobConsulta = from hclregbliqidode in _context.Hclregbliqidode
                                      join hcltiporegturno in _context.Hcltiporegturno on hclregbliqidode.hcl_tiptur_hctu equals hcltiporegturno.hcl_tiptur_hctu into tmhcltiporegturno
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregbliqidode.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join hcltipoliquidos in _context.Hcltipoliquidos on hclregbliqidode.hcl_codliq_hctl equals hcltipoliquidos.hcl_codliq_hctl into tmhcltipoliquidos
                                      join hclviasliquidos in _context.Hclviasliquidos on hclregbliqidode.hcl_vialiq_hcvl equals hclviasliquidos.hcl_vialiq_hcvl into tmhclviasliquidos
                                      from hctu in tmhcltiporegturno.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from hctl in tmhcltipoliquidos.DefaultIfEmpty()
                                      from hcvl in tmhclviasliquidos.DefaultIfEmpty()
                                      where hclregbliqidode.hcl_nroreg_hcbm == tcrBuscar
                                      select new ModeloHclregbliqidode
                                      {
                                          #region datos
                                          Hcl_nroreg_hcbd = hclregbliqidode.hcl_nroreg_hcbd,
                                          Hcl_nroreg_hcbm = hclregbliqidode.hcl_nroreg_hcbm,
                                          Hcl_secreg_hcbd = (long)hclregbliqidode.hcl_secreg_hcbd,
                                          Adm_secadm_rgad = hclregbliqidode.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregbliqidode.sia_idesec_usua,
                                          Hcl_codliq_hctl = hclregbliqidode.hcl_codliq_hctl,
                                          Hcl_vialiq_hcvl = hclregbliqidode.hcl_vialiq_hcvl,
                                          Hcl_gesfec_hcbd = (DateTime)hclregbliqidode.hcl_gesfec_hcbd,
                                          Hcl_tipreg_hcbd = hclregbliqidode.hcl_tipreg_hcbd,
                                          Hcl_cantid_hcbd = (Decimal)hclregbliqidode.hcl_cantid_hcbd,
                                          Hcl_horini_hcbd = (Decimal)hclregbliqidode.hcl_horini_hcbd,
                                          Hcl_horfin_hcbd = (Decimal)hclregbliqidode.hcl_horfin_hcbd,
                                          Hcl_horeli_hcbd = (Decimal)hclregbliqidode.hcl_horeli_hcbd,
                                          Hcl_tiptur_hctu = hclregbliqidode.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = hclregbliqidode.sia_codpfa_prof,
                                          Hcl_sisfec_hcbd = (DateTime)hclregbliqidode.hcl_sisfec_hcbd,
                                          Hcl_sishor_hcbd = (Decimal)hclregbliqidode.hcl_sishor_hcbd,
                                          Hcl_notreg_hcbd = hclregbliqidode.hcl_notreg_hcbd,
                                          Sis_estpro_espr = hclregbliqidode.sis_estpro_espr,
                                          Hcl_destur_hctu = hctu.hcl_destur_hctu,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Hcl_desliq_hctl = hctl.hcl_desliq_hctl,
                                          Hcl_desvia_hcvl = hcvl.hcl_desvia_hcvl,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    #region consulta
                    var lobConsulta = from hclregbliqidode in _context.Hclregbliqidode
                                      join hcltiporegturno in _context.Hcltiporegturno on hclregbliqidode.hcl_tiptur_hctu equals hcltiporegturno.hcl_tiptur_hctu into tmhcltiporegturno
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclregbliqidode.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      join hcltipoliquidos in _context.Hcltipoliquidos on hclregbliqidode.hcl_codliq_hctl equals hcltipoliquidos.hcl_codliq_hctl into tmhcltipoliquidos
                                      join hclviasliquidos in _context.Hclviasliquidos on hclregbliqidode.hcl_vialiq_hcvl equals hclviasliquidos.hcl_vialiq_hcvl into tmhclviasliquidos
                                      from hctu in tmhcltiporegturno.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      from hctl in tmhcltipoliquidos.DefaultIfEmpty()
                                      from hcvl in tmhclviasliquidos.DefaultIfEmpty()
                                      where hclregbliqidode.hcl_nroreg_hcbd == tcrBuscar
                                      select new ModeloHclregbliqidode
                                      {
                                          #region datos
                                          Hcl_nroreg_hcbd = hclregbliqidode.hcl_nroreg_hcbd,
                                          Hcl_nroreg_hcbm = hclregbliqidode.hcl_nroreg_hcbm,
                                          Hcl_secreg_hcbd = (long)hclregbliqidode.hcl_secreg_hcbd,
                                          Adm_secadm_rgad = hclregbliqidode.adm_secadm_rgad,
                                          Sia_idesec_usua = hclregbliqidode.sia_idesec_usua,
                                          Hcl_codliq_hctl = hclregbliqidode.hcl_codliq_hctl,
                                          Hcl_vialiq_hcvl = hclregbliqidode.hcl_vialiq_hcvl,
                                          Hcl_gesfec_hcbd = (DateTime)hclregbliqidode.hcl_gesfec_hcbd,
                                          Hcl_tipreg_hcbd = hclregbliqidode.hcl_tipreg_hcbd,
                                          Hcl_cantid_hcbd = (Decimal)hclregbliqidode.hcl_cantid_hcbd,
                                          Hcl_horini_hcbd = (Decimal)hclregbliqidode.hcl_horini_hcbd,
                                          Hcl_horfin_hcbd = (Decimal)hclregbliqidode.hcl_horfin_hcbd,
                                          Hcl_horeli_hcbd = (Decimal)hclregbliqidode.hcl_horeli_hcbd,
                                          Hcl_tiptur_hctu = hclregbliqidode.hcl_tiptur_hctu,
                                          Sia_codpfa_prof = hclregbliqidode.sia_codpfa_prof,
                                          Hcl_sisfec_hcbd = (DateTime)hclregbliqidode.hcl_sisfec_hcbd,
                                          Hcl_sishor_hcbd = (Decimal)hclregbliqidode.hcl_sishor_hcbd,
                                          Hcl_notreg_hcbd = hclregbliqidode.hcl_notreg_hcbd,
                                          Sis_estpro_espr = hclregbliqidode.sis_estpro_espr,
                                          Hcl_destur_hctu = hctu.hcl_destur_hctu,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Hcl_desliq_hctl = hctl.hcl_desliq_hctl,
                                          Hcl_desvia_hcvl = hcvl.hcl_desvia_hcvl,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Tabla hclhistarchivos: Maestro recursos usados en historias clinicas
    /// </summary>
    public class ModeloHclhistarchivos : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region RefObjeto: Referencia a la instancia del Objeto en la vista grilla
        /// <summary>
        /// Referencia a la instancia del Objeto en la vista grilla
        /// </summary>
        public FrameworkElement RefObjeto { get; set; }
        #endregion
        #region Hcl_iderec_hclr: Codigo registro recurso
        private String _hcl_iderec_hclr;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclhistarchivos</para>
        /// <para>CAMPO: Codigo registro recurso</para>
        /// <para>NOMBRE: hcl_iderec_hclr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código registro archivo de recurso utilizado en la HC (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Hcl_iderec_hclr
        {
            get { return _hcl_iderec_hclr; }
            set
            {
                if (_hcl_iderec_hclr == value) return;
                _hcl_iderec_hclr = value;
                OnPropertyChanged("Hcl_iderec_hclr");
            }
        }
        #endregion
        #region Hcl_nroreg_hcms: Codigo registro maestro
        private String _hcl_nroreg_hcms;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Codigo registro maestro</para>
        /// <para>NOMBRE: hcl_nroreg_hcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código registro maestro (HCLREGORDESERMS) que agrupa relacionado
        /// con el maestro de eventos medicos
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcms
        {
            get { return _hcl_nroreg_hcms; }
            set
            {
                if (_hcl_nroreg_hcms == value) return;
                _hcl_nroreg_hcms = value;
                OnPropertyChanged("Hcl_nroreg_hcms");
            }
        }
        #endregion
        #region Hcl_nroreg_hcev: Codigo Evento medico
        private String _hcl_nroreg_hcev;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Codigo Evento medico</para>
        /// <para>NOMBRE: hcl_nroreg_hcev (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código del evento medico que asocia el recurso en la vista
        /// historial clinico
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcev
        {
            get { return _hcl_nroreg_hcev; }
            set
            {
                if (_hcl_nroreg_hcev == value) return;
                _hcl_nroreg_hcev = value;
                OnPropertyChanged("Hcl_nroreg_hcev");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        #region Hcl_nrohis_hicl: Numero historia clínica
        private String _hcl_nrohis_hicl;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Numero historia clínica</para>
        /// <para>NOMBRE: hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero o código de la Ficha de Historias Clínicas (generado
        /// por el sistema)
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
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional del turno de servicio medicamento
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
        #region Sia_codare_aser: Area de servicios
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Area de servicios</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Grc_codest_gres: Tipo formato destino
        private String _grc_codest_gres;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: grcestandargest</para>
        /// <para>CAMPO: Tipo formato destino</para>
        /// <para>NOMBRE: grc_codest_gres (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo tipo formato o estandar XML en el cual se guarda el
        /// archivo: NA=Formato normal de origen , HL7, OOXML, OASIS,ISO
        /// 19005 PDF(A) y otros
        /// </para>
        /// </summary>
        public String Grc_codest_gres
        {
            get { return _grc_codest_gres; }
            set
            {
                if (_grc_codest_gres == value) return;
                _grc_codest_gres = value;
                OnPropertyChanged("Grc_codest_gres");
            }
        }
        #endregion
        #region Grc_codesp_grep: Tipo formato destino
        private String _grc_codesp_grep;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: grcestandarespe</para>
        /// <para>CAMPO: Tipo formato destino</para>
        /// <para>NOMBRE: grc_codesp_grep (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo especificacion del formato según  estandar: NA=Formato
        /// normal de origen (sin estandar) , HL7-CDA-R2=Especifiacionresultados
        /// de laboratorio, HL7-444 …
        /// </para>
        /// </summary>
        public String Grc_codesp_grep
        {
            get { return _grc_codesp_grep; }
            set
            {
                if (_grc_codesp_grep == value) return;
                _grc_codesp_grep = value;
                OnPropertyChanged("Grc_codesp_grep");
            }
        }
        #endregion
        #region Grc_tiprec_grtr: Tipo recurso
        private String _grc_tiprec_grtr;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: grctiporecursos</para>
        /// <para>CAMPO: Tipo recurso</para>
        /// <para>NOMBRE: grc_tiprec_grtr (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Tipo recurso cargado según software origen: RDOC = Word, RHL7=Estandar
        /// HL7, RXLS,RIMG=Imágenes,RPDF,RVID=Videos y otros
        /// </para>
        /// </summary>
        public String Grc_tiprec_grtr
        {
            get { return _grc_tiprec_grtr; }
            set
            {
                if (_grc_tiprec_grtr == value) return;
                _grc_tiprec_grtr = value;
                OnPropertyChanged("Grc_tiprec_grtr");
            }
        }
        #endregion
        #region Hcl_extarc_hclr: Extencion del archivo
        private String _hcl_extarc_hclr;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclhistarchivos</para>
        /// <para>CAMPO: Extencion del archivo</para>
        /// <para>NOMBRE: hcl_extarc_hclr (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Extencion del archivo cargado emplo: DOC, DOCX, PDF, XLS,
        /// XLSX, JPG, JPEG, PNG ,BMP,MOV,AVI,MP4 y Otros
        /// </para>
        /// </summary>
        public String Hcl_extarc_hclr
        {
            get { return _hcl_extarc_hclr; }
            set
            {
                if (_hcl_extarc_hclr == value) return;
                _hcl_extarc_hclr = value;
                OnPropertyChanged("Hcl_extarc_hclr");
            }
        }
        #endregion
        #region Hcl_nomarc_hclr: Nombre del archivo
        private String _hcl_nomarc_hclr;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclhistarchivos</para>
        /// <para>CAMPO: Nombre del archivo</para>
        /// <para>NOMBRE: hcl_nomarc_hclr (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Nombre del archivo destino con extencion incluida
        /// </para>
        /// </summary>
        public String Hcl_nomarc_hclr
        {
            get { return _hcl_nomarc_hclr; }
            set
            {
                if (_hcl_nomarc_hclr == value) return;
                _hcl_nomarc_hclr = value;
                OnPropertyChanged("Hcl_nomarc_hclr");
            }
        }
        #endregion
        #region Hcl_rutarc_hclr: Ruta archivo
        private String _hcl_rutarc_hclr;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclhistarchivos</para>
        /// <para>CAMPO: Ruta archivo</para>
        /// <para>NOMBRE: hcl_rutarc_hclr (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION: Ruta fisica relativa dentro de Galeria de Recursos donde se almacenara el archivo.</para>
        /// </summary>
        public String Hcl_rutarc_hclr
        {
            get { return _hcl_rutarc_hclr; }
            set
            {
                if (_hcl_rutarc_hclr == value) return;
                _hcl_rutarc_hclr = value;
                OnPropertyChanged("Hcl_rutarc_hclr");
            }
        }
        #endregion
        #region Hcl_texcon_hclr: Texto del contenido
        private String _hcl_texcon_hclr;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclhistarchivos</para>
        /// <para>CAMPO: Texto del contenido</para>
        /// <para>NOMBRE: hcl_texcon_hclr (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Texto transcripcion del contenido en la imagen o del PDF
        /// </para>
        /// </summary>
        public String Hcl_texcon_hclr
        {
            get { return _hcl_texcon_hclr; }
            set
            {
                if (_hcl_texcon_hclr == value) return;
                _hcl_texcon_hclr = value;
                OnPropertyChanged("Hcl_texcon_hclr");
            }
        }
        #endregion
        #region Hcl_texkey_hclr: Texto llave
        private String _hcl_texkey_hclr;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclhistarchivos</para>
        /// <para>CAMPO: Texto llave</para>
        /// <para>NOMBRE: hcl_texkey_hclr (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Texto transcripcion del contenido en la imagen o del PDF, abreviado
        /// para usar como llave de busqueda
        /// </para>
        /// </summary>
        public String Hcl_texkey_hclr
        {
            get { return _hcl_texkey_hclr; }
            set
            {
                if (_hcl_texkey_hclr == value) return;
                _hcl_texkey_hclr = value;
                OnPropertyChanged("Hcl_texkey_hclr");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        #region Hcl_desreg_hcev: Descripción Evento
        private String _hcl_desreg_hcev;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclregiseventos</para>
        /// <para>CAMPO: Descripción Evento</para>
        /// <para>NOMBRE: hcl_desreg_hcev (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion evento medico
        /// </para>
        /// </summary>
        public String Hcl_desreg_hcev
        {
            get { return _hcl_desreg_hcev; }
            set
            {
                if (_hcl_desreg_hcev == value) return;
                _hcl_desreg_hcev = value;
                OnPropertyChanged("Hcl_desreg_hcev");
            }
        }
        #endregion
        #region Hcl_notape_hicl: Nota de apertura
        private String _hcl_notape_hicl;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Nota de apertura</para>
        /// <para>NOMBRE: hcl_notape_hicl (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Nota de apertura electronica de la historia clinica.
        /// </para>
        /// </summary>
        public String Hcl_notape_hicl
        {
            get { return _hcl_notape_hicl; }
            set
            {
                if (_hcl_notape_hicl == value) return;
                _hcl_notape_hicl = value;
                OnPropertyChanged("Hcl_notape_hicl");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
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
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
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
        #region Grc_descri_gres: Titulo del estandar
        private String _grc_descri_gres;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: grcestandargest</para>
        /// <para>CAMPO: Titulo del estandar</para>
        /// <para>NOMBRE: grc_descri_gres (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Titulo o descripcion del estandar
        /// </para>
        /// </summary>
        public String Grc_descri_gres
        {
            get { return _grc_descri_gres; }
            set
            {
                if (_grc_descri_gres == value) return;
                _grc_descri_gres = value;
                OnPropertyChanged("Grc_descri_gres");
            }
        }
        #endregion
        #region Grc_descri_grep: Titulo especificacion
        private String _grc_descri_grep;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: grcestandarespe</para>
        /// <para>CAMPO: Titulo especificacion</para>
        /// <para>NOMBRE: grc_descri_grep (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Titulo o descripcion especificacion o del formato
        /// </para>
        /// </summary>
        public String Grc_descri_grep
        {
            get { return _grc_descri_grep; }
            set
            {
                if (_grc_descri_grep == value) return;
                _grc_descri_grep = value;
                OnPropertyChanged("Grc_descri_grep");
            }
        }
        #endregion
        #region Grc_titulo_grtr: Titulo del recursos
        private String _grc_titulo_grtr;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TABLA NATIVA: grctiporecursos</para>
        /// <para>CAMPO: Titulo del recursos</para>
        /// <para>NOMBRE: grc_titulo_grtr (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Titulo del recursos
        /// </para>
        /// </summary>
        public String Grc_titulo_grtr
        {
            get { return _grc_titulo_grtr; }
            set
            {
                if (_grc_titulo_grtr == value) return;
                _grc_titulo_grtr = value;
                OnPropertyChanged("Grc_titulo_grtr");
            }
        }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        private String _sis_despro_espr;
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
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
        #region Sis_estado_imaen: Gestion registro
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: campo de gestion edicion</para>
        /// <para>NOMBRE: Sis_estado_imaen (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: IMAEN </para>
        /// </summary>
        public String Sis_estado_imaen = "I";
        #endregion
        #region Sis_rutorigen_temp: Ruta temporal
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: campo de gestion edicion</para>
        /// <para>NOMBRE: Sis_rutorigen_temp</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>Nombre archivo y ruta cuando se esta cargando por primera vez, incluye la extencion del archivo</para>
        /// </summary>
        public String Sis_rutorigen_temp = String.Empty;
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloHclhistarchivos tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-HCLHISTARCHIVOS", "HCL", "Maestro recursos usados en historias clinicas");
            try
            {
                if (!flgBuscarHclhistarchivos(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFhclhistarchivos
                        {
                            #region cargar Registro
                            hcl_iderec_hclr = tobjModelo.Hcl_iderec_hclr,
                            hcl_nroreg_hcms = tobjModelo.Hcl_nroreg_hcms,
                            hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev,
                            adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                            hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl,
                            sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                            sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                            sia_codare_aser = tobjModelo.Sia_codare_aser,
                            grc_codest_gres = tobjModelo.Grc_codest_gres,
                            grc_codesp_grep = tobjModelo.Grc_codesp_grep,
                            grc_tiprec_grtr = tobjModelo.Grc_tiprec_grtr,
                            hcl_extarc_hclr = tobjModelo.Hcl_extarc_hclr,
                            hcl_nomarc_hclr = tobjModelo.Hcl_nomarc_hclr,
                            hcl_rutarc_hclr = tobjModelo.Hcl_rutarc_hclr,
                            hcl_texcon_hclr = tobjModelo.Hcl_texcon_hclr,
                            hcl_texkey_hclr = tobjModelo.Hcl_texkey_hclr,
                            sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                            #endregion
                        };
                        lobjRegistro.hcl_iderec_hclr = lcrCodigoGen;
                        _context.AddToHclhistarchivos(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-HCLHISTARCHIVOS': Maestro recursos usados en historias clinicas en Maestro Secuenciales.");
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHclhistarchivos tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclhistarchivos.FirstOrDefault(p => p.hcl_iderec_hclr == tobjModelo.Hcl_iderec_hclr);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.hcl_iderec_hclr = tobjModelo.Hcl_iderec_hclr;
                        lobjRegistro.hcl_nroreg_hcms = tobjModelo.Hcl_nroreg_hcms;
                        lobjRegistro.hcl_nroreg_hcev = tobjModelo.Hcl_nroreg_hcev;
                        lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                        lobjRegistro.hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl;
                        lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                        lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                        lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                        lobjRegistro.grc_codest_gres = tobjModelo.Grc_codest_gres;
                        lobjRegistro.grc_codesp_grep = tobjModelo.Grc_codesp_grep;
                        lobjRegistro.grc_tiprec_grtr = tobjModelo.Grc_tiprec_grtr;
                        lobjRegistro.hcl_extarc_hclr = tobjModelo.Hcl_extarc_hclr;
                        lobjRegistro.hcl_nomarc_hclr = tobjModelo.Hcl_nomarc_hclr;
                        lobjRegistro.hcl_rutarc_hclr = tobjModelo.Hcl_rutarc_hclr;
                        lobjRegistro.hcl_texcon_hclr = tobjModelo.Hcl_texcon_hclr;
                        lobjRegistro.hcl_texkey_hclr = tobjModelo.Hcl_texkey_hclr;
                        lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                        #endregion
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
        public static void fcvEliminar(String tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclhistarchivos.FirstOrDefault(p => p.hcl_iderec_hclr == tcrCodigo);
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
        #region Buscar HCLHISTARCHIVOS: Logica
        /// <summary>
        /// <para>TABLA: hclhistarchivos</para>
        /// <para>TITULO: Maestro recursos usados en historias clinicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro recursos  tipo imágenes videos y archivos son utilizados
        /// en historia clinica puden ser: Radiografias, Fotos, videos
        /// y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarHclhistarchivos(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclhistarchivos.FirstOrDefault(p => p.hcl_iderec_hclr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Registros unico
        /// <summary>
        /// <para>Devuelve un registro de tipo: ModeloHclhistarchivos</para>
        /// <para>PARAMETRO:</para>
        /// <para>tcrCodigoRegistro: Codigo unico del registro en la tabla HclHistarchivos</para>
        /// </summary>
        public static ModeloHclhistarchivos fobRegistroHclHistarchivos(String tcrCodigoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from hclhistarchivos in _context.Hclhistarchivos
                                  join grcestandargest in _context.Grcestandargest on hclhistarchivos.grc_codest_gres equals grcestandargest.grc_codest_gres into tmgrcestandargest
                                  join grctiporecursos in _context.Grctiporecursos on hclhistarchivos.grc_tiprec_grtr equals grctiporecursos.grc_tiprec_grtr into tmgrctiporecursos
                                  join sisestadoproces in _context.Sisestadoproces on hclhistarchivos.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                  from gres in tmgrcestandargest.DefaultIfEmpty()
                                  from grtr in tmgrctiporecursos.DefaultIfEmpty()
                                  from espr in tmsisestadoproces.DefaultIfEmpty()
                                  where hclhistarchivos.hcl_iderec_hclr == tcrCodigoRegistro
                                  select new ModeloHclhistarchivos
                                  {
                                      #region Datos
                                      Hcl_iderec_hclr = hclhistarchivos.hcl_iderec_hclr,
                                      Hcl_nroreg_hcms = hclhistarchivos.hcl_nroreg_hcms,
                                      Hcl_nroreg_hcev = hclhistarchivos.hcl_nroreg_hcev,
                                      Adm_secadm_rgad = hclhistarchivos.adm_secadm_rgad,
                                      Hcl_nrohis_hicl = hclhistarchivos.hcl_nrohis_hicl,
                                      Sia_idesec_usua = hclhistarchivos.sia_idesec_usua,
                                      Sia_codpfa_prof = hclhistarchivos.sia_codpfa_prof,
                                      Sia_codare_aser = hclhistarchivos.sia_codare_aser,
                                      Grc_codest_gres = hclhistarchivos.grc_codest_gres,
                                      Grc_codesp_grep = hclhistarchivos.grc_codesp_grep,
                                      Grc_tiprec_grtr = hclhistarchivos.grc_tiprec_grtr,
                                      Hcl_extarc_hclr = hclhistarchivos.hcl_extarc_hclr,
                                      Hcl_nomarc_hclr = hclhistarchivos.hcl_nomarc_hclr,
                                      Hcl_rutarc_hclr = hclhistarchivos.hcl_rutarc_hclr,
                                      Hcl_texcon_hclr = hclhistarchivos.hcl_texcon_hclr,
                                      Hcl_texkey_hclr = hclhistarchivos.hcl_texkey_hclr,
                                      Sis_estpro_espr = hclhistarchivos.sis_estpro_espr,
                                      Grc_descri_gres = gres.grc_descri_gres,
                                      Grc_titulo_grtr = grtr.grc_titulo_grtr,
                                      Sis_despro_espr = espr.sis_despro_espr,
                                      #endregion
                                  };
                return lobConsulta.ToList().FirstOrDefault();
            }
        }
        #endregion
        #region Listar Registros
        /// <summary>
        /// <para>Lista de registros</para>
        /// <para>tcrTipo: "IG" = hcl_iderec_hclr uno solo  "R1" = hcl_nroreg_hcms lista tipo detalles </para>
        /// </summary>
        public static List<ModeloHclhistarchivos> flsListaHclhistarchivos(String tcrTipo, String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (tcrTipo == "R1")
                {
                    var lobConsulta = from hclhistarchivos in _context.Hclhistarchivos
                                      join grcestandargest in _context.Grcestandargest on hclhistarchivos.grc_codest_gres equals grcestandargest.grc_codest_gres into tmgrcestandargest
                                      join grctiporecursos in _context.Grctiporecursos on hclhistarchivos.grc_tiprec_grtr equals grctiporecursos.grc_tiprec_grtr into tmgrctiporecursos
                                      join sisestadoproces in _context.Sisestadoproces on hclhistarchivos.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from gres in tmgrcestandargest.DefaultIfEmpty()
                                      from grtr in tmgrctiporecursos.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where hclhistarchivos.hcl_nroreg_hcms == tcrBuscar
                                      select new ModeloHclhistarchivos
                                      {
                                          #region Datos
                                          Hcl_iderec_hclr = hclhistarchivos.hcl_iderec_hclr,
                                          Hcl_nroreg_hcms = hclhistarchivos.hcl_nroreg_hcms,
                                          Hcl_nroreg_hcev = hclhistarchivos.hcl_nroreg_hcev,
                                          Adm_secadm_rgad = hclhistarchivos.adm_secadm_rgad,
                                          Hcl_nrohis_hicl = hclhistarchivos.hcl_nrohis_hicl,
                                          Sia_idesec_usua = hclhistarchivos.sia_idesec_usua,
                                          Sia_codpfa_prof = hclhistarchivos.sia_codpfa_prof,
                                          Sia_codare_aser = hclhistarchivos.sia_codare_aser,
                                          Grc_codest_gres = hclhistarchivos.grc_codest_gres,
                                          Grc_codesp_grep = hclhistarchivos.grc_codesp_grep,
                                          Grc_tiprec_grtr = hclhistarchivos.grc_tiprec_grtr,
                                          Hcl_extarc_hclr = hclhistarchivos.hcl_extarc_hclr,
                                          Hcl_nomarc_hclr = hclhistarchivos.hcl_nomarc_hclr,
                                          Hcl_rutarc_hclr = hclhistarchivos.hcl_rutarc_hclr,
                                          Hcl_texcon_hclr = hclhistarchivos.hcl_texcon_hclr,
                                          Hcl_texkey_hclr = hclhistarchivos.hcl_texkey_hclr,
                                          Sis_estpro_espr = hclhistarchivos.sis_estpro_espr,
                                          Grc_descri_gres = gres.grc_descri_gres,
                                          Grc_titulo_grtr = grtr.grc_titulo_grtr,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                          Sis_estado_imaen ="I",
                                          Sis_rutorigen_temp = "",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hclhistarchivos in _context.Hclhistarchivos
                                      join grcestandargest in _context.Grcestandargest on hclhistarchivos.grc_codest_gres equals grcestandargest.grc_codest_gres into tmgrcestandargest
                                      join grctiporecursos in _context.Grctiporecursos on hclhistarchivos.grc_tiprec_grtr equals grctiporecursos.grc_tiprec_grtr into tmgrctiporecursos
                                      join sisestadoproces in _context.Sisestadoproces on hclhistarchivos.sis_estpro_espr equals sisestadoproces.sis_estpro_espr into tmsisestadoproces
                                      from gres in tmgrcestandargest.DefaultIfEmpty()
                                      from grtr in tmgrctiporecursos.DefaultIfEmpty()
                                      from espr in tmsisestadoproces.DefaultIfEmpty()
                                      where hclhistarchivos.hcl_iderec_hclr == tcrBuscar
                                      select new ModeloHclhistarchivos
                                      {
                                          #region Datos
                                          Hcl_iderec_hclr = hclhistarchivos.hcl_iderec_hclr,
                                          Hcl_nroreg_hcms = hclhistarchivos.hcl_nroreg_hcms,
                                          Hcl_nroreg_hcev = hclhistarchivos.hcl_nroreg_hcev,
                                          Adm_secadm_rgad = hclhistarchivos.adm_secadm_rgad,
                                          Hcl_nrohis_hicl = hclhistarchivos.hcl_nrohis_hicl,
                                          Sia_idesec_usua = hclhistarchivos.sia_idesec_usua,
                                          Sia_codpfa_prof = hclhistarchivos.sia_codpfa_prof,
                                          Sia_codare_aser = hclhistarchivos.sia_codare_aser,
                                          Grc_codest_gres = hclhistarchivos.grc_codest_gres,
                                          Grc_codesp_grep = hclhistarchivos.grc_codesp_grep,
                                          Grc_tiprec_grtr = hclhistarchivos.grc_tiprec_grtr,
                                          Hcl_extarc_hclr = hclhistarchivos.hcl_extarc_hclr,
                                          Hcl_nomarc_hclr = hclhistarchivos.hcl_nomarc_hclr,
                                          Hcl_rutarc_hclr = hclhistarchivos.hcl_rutarc_hclr,
                                          Hcl_texcon_hclr = hclhistarchivos.hcl_texcon_hclr,
                                          Hcl_texkey_hclr = hclhistarchivos.hcl_texkey_hclr,
                                          Sis_estpro_espr = hclhistarchivos.sis_estpro_espr,
                                          Grc_descri_gres = gres.grc_descri_gres,
                                          Grc_titulo_grtr = grtr.grc_titulo_grtr,
                                          Sis_despro_espr = espr.sis_despro_espr,
                                          Sis_estado_imaen ="I",
                                          Sis_rutorigen_temp = "",
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: hclmaestrohiscl
    /// </summary>
    public class ModeloHclmaehistoriasclinicas : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_nrohis_hicl: número historia clínica
        private String _hcl_nrohis_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: número historia clínica</para>
        /// <para>NOMBRE: hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Número o código de la Ficha de Historias Clínicas (generado
        /// por el sistema)
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
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
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
        private String _sia_tipide_tide;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= cédula, otros
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
        #region Sia_nroide_usua: número de Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: número de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// número de identificación del paciente: Registro civil, cédula,
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
        #region Hcl_fecapp_hicl: Fecha apertura HC
        private DateTime _hcl_fecapp_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Fecha apertura HC</para>
        /// <para>NOMBRE: hcl_fecapp_hicl (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Fecha apertura de la historia clínica por primera vez (puede
        /// ser no electrónica)
        /// </para>
        /// </summary>
        public DateTime Hcl_fecapp_hicl
        {
            get { return _hcl_fecapp_hicl; }
            set
            {
                if (_hcl_fecapp_hicl == value) return;
                _hcl_fecapp_hicl = value;
                OnPropertyChanged("Hcl_fecapp_hicl");
            }
        }
        #endregion
        #region Hcl_fecape_hicl: Apertura electrónica
        private DateTime _hcl_fecape_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Apertura electrónica</para>
        /// <para>NOMBRE: hcl_fecape_hicl (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha apertura de la historia clínica electrónica
        /// </para>
        /// </summary>
        public DateTime Hcl_fecape_hicl
        {
            get { return _hcl_fecape_hicl; }
            set
            {
                if (_hcl_fecape_hicl == value) return;
                _hcl_fecape_hicl = value;
                OnPropertyChanged("Hcl_fecape_hicl");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código del profesional
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Código del Profesional que realiza la apertura de la historia
        /// electrónica
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
        #region Hcl_hpapel_hicl: Historia clínica en papel
        private String _hcl_hpapel_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Historia clínica en papel</para>
        /// <para>NOMBRE: hcl_hpapel_hicl (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Historia clínica anterior en papel: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Hcl_hpapel_hicl
        {
            get { return _hcl_hpapel_hicl; }
            set
            {
                if (_hcl_hpapel_hicl == value) return;
                _hcl_hpapel_hicl = value;
                OnPropertyChanged("Hcl_hpapel_hicl");
            }
        }
        #endregion
        #region Hcl_papeld_hicl: Historia clínica escaneada
        private String _hcl_papeld_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Historia clínica escaneada</para>
        /// <para>NOMBRE: hcl_papeld_hicl (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Historia clínica anterior escaneada : 1=Si 2=No
        /// </para>
        /// </summary>
        public String Hcl_papeld_hicl
        {
            get { return _hcl_papeld_hicl; }
            set
            {
                if (_hcl_papeld_hicl == value) return;
                _hcl_papeld_hicl = value;
                OnPropertyChanged("Hcl_papeld_hicl");
            }
        }
        #endregion
        #region Hcl_ncarpe_hicl: número carpeta
        private String _hcl_ncarpe_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: número carpeta</para>
        /// <para>NOMBRE: hcl_ncarpe_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// número de la carpeta, cuando existe historia clínica en papel.
        /// </para>
        /// </summary>
        public String Hcl_ncarpe_hicl
        {
            get { return _hcl_ncarpe_hicl; }
            set
            {
                if (_hcl_ncarpe_hicl == value) return;
                _hcl_ncarpe_hicl = value;
                OnPropertyChanged("Hcl_ncarpe_hicl");
            }
        }
        #endregion
        #region Hcl_nestan_hicl: número del estante
        private String _hcl_nestan_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: número del estante</para>
        /// <para>NOMBRE: hcl_nestan_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// número del estante donde se encuentra la carpeta, cuando existe
        /// historia clínica en papel.
        /// </para>
        /// </summary>
        public String Hcl_nestan_hicl
        {
            get { return _hcl_nestan_hicl; }
            set
            {
                if (_hcl_nestan_hicl == value) return;
                _hcl_nestan_hicl = value;
                OnPropertyChanged("Hcl_nestan_hicl");
            }
        }
        #endregion
        #region Grc_iderec_grcm: Código Imagen (foto)
        private String _grc_iderec_grcm;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Imagen (foto)</para>
        /// <para>NOMBRE: grc_iderec_grcm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Código único  de la imagen (foto)  perfil del paciente desde
        /// la galería de recursos
        /// </para>
        /// </summary>
        public String Grc_iderec_grcm
        {
            get { return _grc_iderec_grcm; }
            set
            {
                if (_grc_iderec_grcm == value) return;
                _grc_iderec_grcm = value;
                OnPropertyChanged("Grc_iderec_grcm");
            }
        }
        #endregion
        #region Hcl_notape_hicl: Nota de apertura
        private String _hcl_notape_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Nota de apertura</para>
        /// <para>NOMBRE: hcl_notape_hicl (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Nota de apertura electrónica de la historia clínica.
        /// </para>
        /// </summary>
        public String Hcl_notape_hicl
        {
            get { return _hcl_notape_hicl; }
            set
            {
                if (_hcl_notape_hicl == value) return;
                _hcl_notape_hicl = value;
                OnPropertyChanged("Hcl_notape_hicl");
            }
        }
        #endregion
        #region Grp_coneve_hicl: Contador eventos
        private int _grp_coneve_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Contador eventos</para>
        /// <para>NOMBRE: grp_coneve_hicl (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Contador secuencial para eventos que se generan en el historial
        /// del paciente
        /// </para>
        /// </summary>
        public int Grp_coneve_hicl
        {
            get { return _grp_coneve_hicl; }
            set
            {
                if (_grp_coneve_hicl == value) return;
                _grp_coneve_hicl = value;
                OnPropertyChanged("Grp_coneve_hicl");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Código Estado Registro
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Sis_estreg_esrg
        {
            get { return _sis_estreg_esrg; }
            set
            {
                if (_sis_estreg_esrg == value) return;
                _sis_estreg_esrg = value;
                OnPropertyChanged("Sis_estreg_esrg");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
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
        /// <para>TABLA: hclmaestrohiscl</para>
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
        /// <para>TABLA: hclmaestrohiscl</para>
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
        #region Sis_desest_esrg: Decripción estado registro
        private String _sis_desest_esrg;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public String Sis_desest_esrg
        {
            get { return _sis_desest_esrg; }
            set
            {
                if (_sis_desest_esrg == value) return;
                _sis_desest_esrg = value;
                OnPropertyChanged("Sis_desest_esrg");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloHclmaehistoriasclinicas tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-MAE-HISTORIAS", "HCL", "Maestro de historias");
            if (!flgBuscarHclmaestrohiscl(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFhclmaestrohiscl
                    {
                        #region cargar Registro
                        hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        hcl_fecapp_hicl = tobjModelo.Hcl_fecapp_hicl,
                        hcl_fecape_hicl = tobjModelo.Hcl_fecape_hicl,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        hcl_hpapel_hicl = tobjModelo.Hcl_hpapel_hicl,
                        hcl_papeld_hicl = tobjModelo.Hcl_papeld_hicl,
                        hcl_ncarpe_hicl = tobjModelo.Hcl_ncarpe_hicl,
                        hcl_nestan_hicl = tobjModelo.Hcl_nestan_hicl,
                        grc_iderec_grcm = tobjModelo.Grc_iderec_grcm,
                        hcl_notape_hicl = tobjModelo.Hcl_notape_hicl,
                        grp_coneve_hicl = tobjModelo.Grp_coneve_hicl,
                        sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                        #endregion
                    };
                    lobjRegistro.hcl_nrohis_hicl = lcrCodigoGen;
                    _context.AddToHclmaestrohiscl(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-MAE-HISTORIAS': Maestro de historias en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Adicionar Registro desde Admision
        public static EFhclmaestrohiscl fobAddRegistroAdmision(String tcrNumeroAdmision)
        {
            var lcrCodigoGen = string.Empty;
            var lobRegAdm = ADMValidarCodigo.fobRegBuscarAdmregadmision(tcrNumeroAdmision);
            var lobReg = new ModeloHclmaehistoriasclinicas();
            var lobjRegistro = HCLValidarCodigo.fobRegBuscarHclmaestrohisclIGEst(lobRegAdm.sia_idesec_usua.Trim(), "2");

            if (lobjRegistro == null)
            {
                //lobjRegistro.hcl_nrohis_hicl = Hcl_nrohis_hicl;
                lobReg.Sia_idesec_usua = lobRegAdm.sia_idesec_usua;
                lobReg.Sia_tipide_tide = lobRegAdm.sia_tipide_tide;
                lobReg.Sia_nroide_usua = lobRegAdm.sia_nroide_usua;
                lobReg.Hcl_fecapp_hicl = (DateTime)lobRegAdm.adm_fecadm_rgad;
                lobReg.Hcl_fecape_hicl = (DateTime)lobRegAdm.adm_fecadm_rgad;
                lobReg.Sia_codpfa_prof = lobRegAdm.sia_codpfa_prof;
                lobReg.Hcl_hpapel_hicl = "2";
                lobReg.Hcl_papeld_hicl = "2";
                lobReg.Hcl_ncarpe_hicl = "NA";
                lobReg.Hcl_nestan_hicl = "NA";
                lobReg.Grc_iderec_grcm = "NA";
                lobReg.Hcl_notape_hicl = String.IsNullOrWhiteSpace(lobRegAdm.adm_caucon_rgad) ? "APERTURA HISTORIA CLINICA" : lobRegAdm.adm_caucon_rgad;
                lobReg.Grp_coneve_hicl = 0;
                lobReg.Sis_estreg_esrg = "2";

                lcrCodigoGen = flgAddRegistro(lobReg);
                lobReg.Hcl_nrohis_hicl = lcrCodigoGen;
                lobjRegistro = HCLValidarCodigo.fobRegBuscarHclmaestrohiscl(lcrCodigoGen);
                ADMModeloAdmadmisiones.fcvActualizDatosHistClinica(tcrNumeroAdmision, lcrCodigoGen);
                // Actualizar el archivo de usuarios
                var lobRegUsua = new EFsiausuarioatend();
                lobRegUsua.hcl_nrohis_hicl = lcrCodigoGen;
                lobRegUsua.sia_idesec_usua = lobReg.Sia_idesec_usua;
                SIAModeloUsuariosAtendidos.fcvActualizarDatos(lobRegUsua);
            }
            return lobjRegistro;
        }
        #endregion
        #region fcrAddRegHClinicaUsuario: Adicionar Registro solo desde datos usuario
        /// <summary>
        ///  Genera el registro en maestro Historias clinicas
        /// </summary>
        /// <param name="tcrIdUnicoUsuario">Codigo unico del usuario en el sistema</param>
        /// <param name="tcrCodigoProfesional">Codigo del profesional que realiza apertura historia clinica</param>
        public static String fcrAddRegHClinicaUsuario(String tcrIdUnicoUsuario, String tcrCodigoProfesional)
        {
            var lcrCodigoGen = string.Empty;
            var lobjRegUsuario = SIAValidarCodigo.fobRegBuscarSiausuarioatendEx(tcrIdUnicoUsuario);

            var lobReg = new ModeloHclmaehistoriasclinicas();
            var lobjRegistro = HCLValidarCodigo.fobRegBuscarHclmaestrohisclIGEst(tcrIdUnicoUsuario, "2");

            if (lobjRegistro == null && lobjRegUsuario != null)
            {
                //lobjRegistro.hcl_nrohis_hicl = Hcl_nrohis_hicl;
                lobReg.Sia_idesec_usua = lobjRegUsuario.sia_idesec_usua;
                lobReg.Sia_tipide_tide = lobjRegUsuario.sia_tipide_tide;
                lobReg.Sia_nroide_usua = lobjRegUsuario.sia_nroide_usua;
                lobReg.Hcl_fecapp_hicl = Funciones.FdaFechaActual();
                lobReg.Hcl_fecape_hicl = Funciones.FdaFechaActual();
                lobReg.Sia_codpfa_prof = tcrCodigoProfesional;
                lobReg.Hcl_hpapel_hicl = "2";
                lobReg.Hcl_papeld_hicl = "2";
                lobReg.Hcl_ncarpe_hicl = "NA";
                lobReg.Hcl_nestan_hicl = "NA";
                lobReg.Grc_iderec_grcm = "NA";
                lobReg.Hcl_notape_hicl = "APERTURA HISTORIA CLINICA";
                lobReg.Grp_coneve_hicl = 0;
                lobReg.Sis_estreg_esrg = "2";

                lcrCodigoGen = flgAddRegistro(lobReg);
                lobReg.Hcl_nrohis_hicl = lcrCodigoGen;

                // Actualizar el archivo de usuarios
                var lobRegUsua = new EFsiausuarioatend();
                lobRegUsua.hcl_nrohis_hicl = lcrCodigoGen;
                lobRegUsua.sia_idesec_usua = lobReg.Sia_idesec_usua;
                SIAModeloUsuariosAtendidos.fcvActualizarDatos(lobRegUsua);
            }
            else
            {
                lcrCodigoGen = lobjRegistro.hcl_nrohis_hicl.Trim();
            }

            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloHclmaehistoriasclinicas tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclmaestrohiscl.FirstOrDefault(p => p.hcl_nrohis_hicl == tobjModelo.Hcl_nrohis_hicl);
                if (lobjRegistro != null)
                {
                    lobjRegistro.hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl;
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.hcl_fecapp_hicl = (DateTime)tobjModelo.Hcl_fecapp_hicl;
                    lobjRegistro.hcl_fecape_hicl = (DateTime)tobjModelo.Hcl_fecape_hicl;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.hcl_hpapel_hicl = tobjModelo.Hcl_hpapel_hicl;
                    lobjRegistro.hcl_papeld_hicl = tobjModelo.Hcl_papeld_hicl;
                    lobjRegistro.hcl_ncarpe_hicl = tobjModelo.Hcl_ncarpe_hicl;
                    lobjRegistro.hcl_nestan_hicl = tobjModelo.Hcl_nestan_hicl;
                    lobjRegistro.grc_iderec_grcm = tobjModelo.Grc_iderec_grcm;
                    lobjRegistro.hcl_notape_hicl = tobjModelo.Hcl_notape_hicl;
                    lobjRegistro.grp_coneve_hicl = (int)tobjModelo.Grp_coneve_hicl;
                    lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
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
                var lobjRegistro = _context.Hclmaestrohiscl.FirstOrDefault(p => p.hcl_nrohis_hicl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar HCLMAESTROHISCL: Logica
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TITULO: Maestro de historias clínicas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de historias clínicas electrónicas abiertas a pacientes
        /// </para>
        /// </summary>
        public static bool flgBuscarHclmaestrohiscl(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclmaestrohiscl.FirstOrDefault(p => p.hcl_nrohis_hicl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHclmaehistoriasclinicas> flsListaHclmaestrohiscl(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from hclmaestrohiscl in _context.Hclmaestrohiscl
                                      join siausuarioatend in _context.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatipideusario in _context.Siatipideusario on hclmaestrohiscl.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclmaestrohiscl.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from tide in tmsiatipideusario.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      select new ModeloHclmaehistoriasclinicas
                                      {
                                          Hcl_nrohis_hicl = hclmaestrohiscl.hcl_nrohis_hicl,
                                          Sia_idesec_usua = hclmaestrohiscl.sia_idesec_usua,
                                          Sia_tipide_tide = hclmaestrohiscl.sia_tipide_tide,
                                          Sia_nroide_usua = hclmaestrohiscl.sia_nroide_usua,
                                          Hcl_fecapp_hicl = (DateTime)hclmaestrohiscl.hcl_fecapp_hicl,
                                          Hcl_fecape_hicl = (DateTime)hclmaestrohiscl.hcl_fecape_hicl,
                                          Sia_codpfa_prof = hclmaestrohiscl.sia_codpfa_prof,
                                          Hcl_hpapel_hicl = hclmaestrohiscl.hcl_hpapel_hicl,
                                          Hcl_papeld_hicl = hclmaestrohiscl.hcl_papeld_hicl,
                                          Hcl_ncarpe_hicl = hclmaestrohiscl.hcl_ncarpe_hicl,
                                          Hcl_nestan_hicl = hclmaestrohiscl.hcl_nestan_hicl,
                                          Grc_iderec_grcm = hclmaestrohiscl.grc_iderec_grcm,
                                          Hcl_notape_hicl = hclmaestrohiscl.hcl_notape_hicl,
                                          Grp_coneve_hicl = (int)hclmaestrohiscl.grp_coneve_hicl,
                                          Sis_estreg_esrg = hclmaestrohiscl.sis_estreg_esrg,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_deside_tide = tide.sia_deside_tide,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sis_desest_esrg = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == hclmaestrohiscl.sis_estreg_esrg).sis_despro_espr,

                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hclmaestrohiscl in _context.Hclmaestrohiscl
                                      join siausuarioatend in _context.Siausuarioatend on hclmaestrohiscl.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatipideusario in _context.Siatipideusario on hclmaestrohiscl.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                      join siamaeprofsalud in _context.Siamaeprofsalud on hclmaestrohiscl.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from tide in tmsiatipideusario.DefaultIfEmpty()
                                      from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                      where hclmaestrohiscl.hcl_nrohis_hicl == tcrBuscar
                                      select new ModeloHclmaehistoriasclinicas
                                      {
                                          Hcl_nrohis_hicl = hclmaestrohiscl.hcl_nrohis_hicl,
                                          Sia_idesec_usua = hclmaestrohiscl.sia_idesec_usua,
                                          Sia_tipide_tide = hclmaestrohiscl.sia_tipide_tide,
                                          Sia_nroide_usua = hclmaestrohiscl.sia_nroide_usua,
                                          Hcl_fecapp_hicl = (DateTime)hclmaestrohiscl.hcl_fecapp_hicl,
                                          Hcl_fecape_hicl = (DateTime)hclmaestrohiscl.hcl_fecape_hicl,
                                          Sia_codpfa_prof = hclmaestrohiscl.sia_codpfa_prof,
                                          Hcl_hpapel_hicl = hclmaestrohiscl.hcl_hpapel_hicl,
                                          Hcl_papeld_hicl = hclmaestrohiscl.hcl_papeld_hicl,
                                          Hcl_ncarpe_hicl = hclmaestrohiscl.hcl_ncarpe_hicl,
                                          Hcl_nestan_hicl = hclmaestrohiscl.hcl_nestan_hicl,
                                          Grc_iderec_grcm = hclmaestrohiscl.grc_iderec_grcm,
                                          Hcl_notape_hicl = hclmaestrohiscl.hcl_notape_hicl,
                                          Grp_coneve_hicl = (int)hclmaestrohiscl.grp_coneve_hicl,
                                          Sis_estreg_esrg = hclmaestrohiscl.sis_estreg_esrg,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_deside_tide = tide.sia_deside_tide,
                                          Sia_nompro_prof = prof.sia_nompro_prof,
                                          Sis_desest_esrg = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == hclmaestrohiscl.sis_estreg_esrg).sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// hclvariabactual: Maestro Variables publicas actualizadas 
    /// </summary>
    public class ModeloHclvariabactual : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_nroreg_hcva: Codigo registro
        private String _hcl_nroreg_hcva;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: hclvariabactual</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: hcl_nroreg_hcva (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial unico registro maestro variables publicas
        /// actualizadas
        /// </para>
        /// </summary>
        public String Hcl_nroreg_hcva
        {
            get { return _hcl_nroreg_hcva; }
            set
            {
                if (_hcl_nroreg_hcva == value) return;
                _hcl_nroreg_hcva = value;
                OnPropertyChanged("Hcl_nroreg_hcva");
            }
        }
        #endregion
        #region Hcl_nomvar_hcvr: Identificador Variable
        private String _hcl_nomvar_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Identificador Variable</para>
        /// <para>NOMBRE: hcl_nomvar_hcvr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre unico identificador de la variable, para referencia
        /// dentro del sistema, este nombre debe incluir nombre identificador
        /// del grupo al que pertenece, ejemplo variables : VACUNACION_NIÑO_DPT_DOSIS
        /// 1, JOVEN_PLANIFICACION_SI_NO
        /// </para>
        /// </summary>
        public String Hcl_nomvar_hcvr
        {
            get { return _hcl_nomvar_hcvr; }
            set
            {
                if (_hcl_nomvar_hcvr == value) return;
                _hcl_nomvar_hcvr = value;
                OnPropertyChanged("Hcl_nomvar_hcvr");
            }
        }
        #endregion
        #region Hcl_nivvar_hcvr: Nivel gestion
        private String _hcl_nivvar_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Nivel gestion</para>
        /// <para>NOMBRE: hcl_nivvar_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nivel gestion variable (1,2,3) : 1= Unica  permanente en historia
        /// clinica, ejemplo: Numero admision activa 2=Unica tmporal en
        /// evento de admision, ejemplo: Diagnostico de ingreso, 3= Variable
        /// temporal  gestion evento, ejemplo: resultado de laboratorio
        /// </para>
        /// </summary>
        public String Hcl_nivvar_hcvr
        {
            get { return _hcl_nivvar_hcvr; }
            set
            {
                if (_hcl_nivvar_hcvr == value) return;
                _hcl_nivvar_hcvr = value;
                OnPropertyChanged("Hcl_nivvar_hcvr");
            }
        }
        #endregion
        #region Hcl_valvar_hcvr: Dato valor  variable
        private String _hcl_valvar_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Dato valor  variable</para>
        /// <para>NOMBRE: hcl_valvar_hcvr (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Valor digitado como dato actualizado de la variable
        /// </para>
        /// </summary>
        public String Hcl_valvar_hcvr
        {
            get { return _hcl_valvar_hcvr; }
            set
            {
                if (_hcl_valvar_hcvr == value) return;
                _hcl_valvar_hcvr = value;
                OnPropertyChanged("Hcl_valvar_hcvr");
            }
        }
        #endregion
        #region Hcl_valdes_hcva: Dato descripcion valor
        private String _hcl_valdes_hcva;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: hclvariabactual</para>
        /// <para>CAMPO: Dato descripcion valor</para>
        /// <para>NOMBRE: hcl_valdes_hcva (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion del valor digitado como dato actualizado de la
        /// variable
        /// </para>
        /// </summary>
        public String Hcl_valdes_hcva
        {
            get { return _hcl_valdes_hcva; }
            set
            {
                if (_hcl_valdes_hcva == value) return;
                _hcl_valdes_hcva = value;
                OnPropertyChanged("Hcl_valdes_hcva");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region Hcl_fecges_hcva: Fecha gestion
        private DateTime _hcl_fecges_hcva;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: hclvariabactual</para>
        /// <para>CAMPO: Fecha gestion</para>
        /// <para>NOMBRE: hcl_fecges_hcva (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Fecha gestion cuando se actualizo el valor de la variable
        /// </para>
        /// </summary>
        public DateTime Hcl_fecges_hcva
        {
            get { return _hcl_fecges_hcva; }
            set
            {
                if (_hcl_fecges_hcva == value) return;
                _hcl_fecges_hcva = value;
                OnPropertyChanged("Hcl_fecges_hcva");
            }
        }
        #endregion
        #region Hcl_horges_hcva: Hora  gestion
        private Decimal _hcl_horges_hcva;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: hclvariabactual</para>
        /// <para>CAMPO: Hora  gestion</para>
        /// <para>NOMBRE: hcl_horges_hcva (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Hora gestion al cuando se actualizo el valor,  en formato militar
        /// (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_horges_hcva
        {
            get { return _hcl_horges_hcva; }
            set
            {
                if (_hcl_horges_hcva == value) return;
                _hcl_horges_hcva = value;
                OnPropertyChanged("Hcl_horges_hcva");
            }
        }
        #endregion
        #region Hcl_auxges_hcva: Dato auxliar
        private String _hcl_auxges_hcva;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: hclvariabactual</para>
        /// <para>CAMPO: Dato auxliar</para>
        /// <para>NOMBRE: hcl_auxges_hcva (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Campo auxiliar, para realizar marcas y procesos en gestion
        /// de variables, poner estados y demas
        /// </para>
        /// </summary>
        public String Hcl_auxges_hcva
        {
            get { return _hcl_auxges_hcva; }
            set
            {
                if (_hcl_auxges_hcva == value) return;
                _hcl_auxges_hcva = value;
                OnPropertyChanged("Hcl_auxges_hcva");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Código Estado Registro
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Sis_estreg_esrg
        {
            get { return _sis_estreg_esrg; }
            set
            {
                if (_sis_estreg_esrg == value) return;
                _sis_estreg_esrg = value;
                OnPropertyChanged("Sis_estreg_esrg");
            }
        }
        #endregion
        #region Hcl_titulo_hcvr: Titulo Variable
        private String _hcl_titulo_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Titulo Variable</para>
        /// <para>NOMBRE: hcl_titulo_hcvr (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Titulo de la variable
        /// </para>
        /// </summary>
        public String Hcl_titulo_hcvr
        {
            get { return _hcl_titulo_hcvr; }
            set
            {
                if (_hcl_titulo_hcvr == value) return;
                _hcl_titulo_hcvr = value;
                OnPropertyChanged("Hcl_titulo_hcvr");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
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
        /// <para>TABLA: hclvariabactual</para>
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
        #region Sis_desest_esrg: Decripción estado registro
        private String _sis_desest_esrg;
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public String Sis_desest_esrg
        {
            get { return _sis_desest_esrg; }
            set
            {
                if (_sis_desest_esrg == value) return;
                _sis_desest_esrg = value;
                OnPropertyChanged("Sis_desest_esrg");
            }
        }
        #endregion
        // Propiedade de variables
        #region Hcl_secgru_hcgv: Grupo de variables
        private String _hcl_secgru_hcgv;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Grupo de variables</para>
        /// <para>NOMBRE: hcl_secgru_hcgv (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codigo grupo, al cual se asocia la variable
        /// </para>
        /// </summary>
        public String Hcl_secgru_hcgv
        {
            get { return _hcl_secgru_hcgv; }
            set
            {
                if (_hcl_secgru_hcgv == value) return;
                _hcl_secgru_hcgv = value;
                OnPropertyChanged("Hcl_secgru_hcgv");
            }
        }
        #endregion
        #region Hcl_ordvis_hcvr: Orden vista
        private int _hcl_ordvis_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Orden vista</para>
        /// <para>NOMBRE: hcl_ordvis_hcvr (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero para orden vista en gestion impresión en formatos dentro
        /// del grupo al que pertenece
        /// </para>
        /// </summary>
        public int Hcl_ordvis_hcvr
        {
            get { return _hcl_ordvis_hcvr; }
            set
            {
                if (_hcl_ordvis_hcvr == value) return;
                _hcl_ordvis_hcvr = value;
                OnPropertyChanged("Hcl_ordvis_hcvr");
            }
        }
        #endregion
        #region Hcl_descri_hcvr: Descripción Variable
        private String _hcl_descri_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Descripción Variable</para>
        /// <para>NOMBRE: hcl_descri_hcvr (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción larga de la variable
        /// </para>
        /// </summary>
        public String Hcl_descri_hcvr
        {
            get { return _hcl_descri_hcvr; }
            set
            {
                if (_hcl_descri_hcvr == value) return;
                _hcl_descri_hcvr = value;
                OnPropertyChanged("Hcl_descri_hcvr");
            }
        }
        #endregion
        #region Hcl_tipval_hcvr: Tipo de Valor
        private String _hcl_tipval_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: hcl_tipval_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Tipo valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico,F=Flotante,E=De
        /// cimal
        /// </para>
        /// </summary>
        public String Hcl_tipval_hcvr
        {
            get { return _hcl_tipval_hcvr; }
            set
            {
                if (_hcl_tipval_hcvr == value) return;
                _hcl_tipval_hcvr = value;
                OnPropertyChanged("Hcl_tipval_hcvr");
            }
        }
        #endregion
        #region Hcl_valper_hcvr: Valor Permitido
        private String _hcl_valper_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Valor Permitido</para>
        /// <para>NOMBRE: hcl_valper_hcvr (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Valores permitidos para el campo
        /// </para>
        /// </summary>
        public String Hcl_valper_hcvr
        {
            get { return _hcl_valper_hcvr; }
            set
            {
                if (_hcl_valper_hcvr == value) return;
                _hcl_valper_hcvr = value;
                OnPropertyChanged("Hcl_valper_hcvr");
            }
        }
        #endregion
        #region Hcl_camdig_hcvr: Campo digitable
        private String _hcl_camdig_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: hcl_camdig_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Campo digitable: 1=Si 2=No
        /// </para>
        /// </summary>
        public String Hcl_camdig_hcvr
        {
            get { return _hcl_camdig_hcvr; }
            set
            {
                if (_hcl_camdig_hcvr == value) return;
                _hcl_camdig_hcvr = value;
                OnPropertyChanged("Hcl_camdig_hcvr");
            }
        }
        #endregion
        #region Hcl_ranini_hcvr: Rango inicial
        private String _hcl_ranini_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango inicial</para>
        /// <para>NOMBRE: hcl_ranini_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Rango inicial general del valor digitable
        /// </para>
        /// </summary>
        public String Hcl_ranini_hcvr
        {
            get { return _hcl_ranini_hcvr; }
            set
            {
                if (_hcl_ranini_hcvr == value) return;
                _hcl_ranini_hcvr = value;
                OnPropertyChanged("Hcl_ranini_hcvr");
            }
        }
        #endregion
        #region Hcl_ranfin_hcvr: Rango final
        private String _hcl_ranfin_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango final</para>
        /// <para>NOMBRE: hcl_ranfin_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Rango final general del valor digitable
        /// </para>
        /// </summary>
        public String Hcl_ranfin_hcvr
        {
            get { return _hcl_ranfin_hcvr; }
            set
            {
                if (_hcl_ranfin_hcvr == value) return;
                _hcl_ranfin_hcvr = value;
                OnPropertyChanged("Hcl_ranfin_hcvr");
            }
        }
        #endregion
        #region Hcl_raninr_hcvr: Rango inicial normal
        private String _hcl_raninr_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango inicial normal</para>
        /// <para>NOMBRE: hcl_raninr_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Rango inicial valores normales dentro del rango general (para
        /// gestion posibles alarmas)
        /// </para>
        /// </summary>
        public String Hcl_raninr_hcvr
        {
            get { return _hcl_raninr_hcvr; }
            set
            {
                if (_hcl_raninr_hcvr == value) return;
                _hcl_raninr_hcvr = value;
                OnPropertyChanged("Hcl_raninr_hcvr");
            }
        }
        #endregion
        #region Hcl_ranfnr_hcvr: Rango final normal
        private String _hcl_ranfnr_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango final normal</para>
        /// <para>NOMBRE: hcl_ranfnr_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Rango final valores normales dentro del rango general (para
        /// gestion posibles alarmas)
        /// </para>
        /// </summary>
        public String Hcl_ranfnr_hcvr
        {
            get { return _hcl_ranfnr_hcvr; }
            set
            {
                if (_hcl_ranfnr_hcvr == value) return;
                _hcl_ranfnr_hcvr = value;
                OnPropertyChanged("Hcl_ranfnr_hcvr");
            }
        }
        #endregion
        #region Hcl_sistem_hcvr: Tipo variable
        private String _hcl_sistem_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Tipo variable</para>
        /// <para>NOMBRE: hcl_sistem_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Evaluar gestion de datos y notifcar alarma para valores referenciados
        /// como anormales: 1= Variable normal 2=Genera notificacion cuando
        /// hay valores anormales
        /// </para>
        /// </summary>
        public String Hcl_sistem_hcvr
        {
            get { return _hcl_sistem_hcvr; }
            set
            {
                if (_hcl_sistem_hcvr == value) return;
                _hcl_sistem_hcvr = value;
                OnPropertyChanged("Hcl_sistem_hcvr");
            }
        }
        #endregion
        #region Hcl_sisvar_hcvr: Variable protegida
        private String _hcl_sisvar_hcvr;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Variable protegida</para>
        /// <para>NOMBRE: hcl_sisvar_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Variable protegida del sistema: 1= Protegida 2=Variable no
        /// protegida
        /// </para>
        /// </summary>
        public String Hcl_sisvar_hcvr
        {
            get { return _hcl_sisvar_hcvr; }
            set
            {
                if (_hcl_sisvar_hcvr == value) return;
                _hcl_sisvar_hcvr = value;
                OnPropertyChanged("Hcl_sisvar_hcvr");
            }
        }
        #endregion
        #region NumeroRegistro: Numero registro para id unico
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Numero para generar registro unico</para>
        /// <para>NOMBRE: NumeroRegistro (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero auxiliar entero para generar registro unico variable publica
        /// </para>
        /// </summary>
        public int NumeroRegistro = 0;
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        // Varaibles Datos admision
        #region fcvGenAdmisionVariablesPublicas: Generar variables publicas codigo admision
        /// <summary>
        /// <para>fcvGenAdmisionVariablesPublicas()</para>
        /// <para>Generar variables publicas activas usuario admitido, dado codigo de admision como parametro</para>
        /// </summary>
        public static void fcvGenAdmisionVariablesPublicas(String tcrCodigoAdmision)
        {
            var gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
            var lobTemp = ADMModeloAdmadmisiones.flsListaAdmregadmision(tcrCodigoAdmision);
            var lnuContador1 = 0;
            var lnuContador2 = 0;

            if (lobTemp != null)
            {
                var tobRegAdm = lobTemp.FirstOrDefault();
                lnuContador1 = fcvGenAdmisionVariablesPublicas(ref tobRegAdm);
                if (!String.IsNullOrWhiteSpace(tobRegAdm.Adm_nroreg_tria))
                {
                    lnuContador2 = fnuGenTriageVariablesPublicas(ref tobRegAdm, tobRegAdm.Adm_nroreg_tria);
                }
                // Actualizar contador en admision del paciente
                if (lnuContador1 != 0 || lnuContador2 != 0)
                {
                    ADMModeloAdmadmisiones.fcvActualizGenIdItems(tobRegAdm.Adm_secadm_rgad, tobRegAdm.Adm_secite_rgad);
                }
            }
        }
        #endregion
        #region fcvGenAdmisionVariablesPublicas: Generar variables publicas desde temporal admision
        /// <summary>
        /// <para>fcvGenAdmisionVariablesPublicas()</para>
        /// <para>Generar variables publicas desde temporal admision</para>
        /// </summary>
        public static int fcvGenAdmisionVariablesPublicas(ref ADMModeloAdmadmisiones tobRegAdm)
        {
            var lnuContador = 0;
            try
            {
                var gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                if (tobRegAdm != null)
                {
                    //-------------------------------------------------------------------
                    // SISTEMA - VARIABLES DATOS BASICOS USUARIO 
                    //-------------------------------------------------------------------
                    #region VARIABLES DATOS BASICOS USUARIO
                    // Tipo identificacion
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_TIPO_IDENTIFICACION", tobRegAdm.Sia_tipide_tide, gcrSeparadorDecimal);
                    // Numero de identificación
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_NUMERO_IDENTIFICACION", tobRegAdm.Sia_nroide_usua, gcrSeparadorDecimal);
                    // Primer apellido del usuario
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_PRIMER_APELLIDO", tobRegAdm.Sia_priape_usua, gcrSeparadorDecimal);
                    // Segundo apellido del usuario
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_SEGUNDO_APELLIDO", tobRegAdm.Sia_segape_usua, gcrSeparadorDecimal);
                    // Primer nombre del usuario
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_PRIMER_NOMBRE", tobRegAdm.Sia_prinom_usua, gcrSeparadorDecimal);
                    // Segundo nombre del usuario
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_SEGUNDO_NOMBRE", tobRegAdm.Sia_segnom_usua, gcrSeparadorDecimal);
                    // Nombre completo usuario
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_NOMBRE_COMPLETO", tobRegAdm.Sia_nomusu_usua, gcrSeparadorDecimal);
                    // Fecha de Nacimiento
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_FECHA_NACIMIENTO", tobRegAdm.Sia_fecnac_usua.ToShortDateString(), gcrSeparadorDecimal);
                    // Codigo Sexo
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_SEXO_CODIGO", tobRegAdm.Sis_codsex_sexo, gcrSeparadorDecimal);
                    // Descripcion Sexo
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_SEXO_DESCRIPCION", tobRegAdm.Sis_dessex_sexo, gcrSeparadorDecimal);
                    // Edad del usuario formato largo
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_EDAD_FORMATO_LARGO", tobRegAdm.Sia_edaymd_usua, gcrSeparadorDecimal);
                    // Edad del usuario en años
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_EDAD_EN_AÑOS", tobRegAdm.Sia_edaano_usua.ToString(), gcrSeparadorDecimal);
                    // Edad del usuario en mese
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_EDAD_EN_MESES", tobRegAdm.Sia_edames_usua.ToString(), gcrSeparadorDecimal);
                    // Edad del usuario en dias
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_EDAD_EN_DIAS", tobRegAdm.Sia_edadia_usua.ToString(), gcrSeparadorDecimal);
                    // Tipo Usuario según régimen
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_REGIMEN_SALUD_CODIGO", tobRegAdm.Sia_tipusu_regi, gcrSeparadorDecimal);
                    // Descripcion tipo Usuario según régimen
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_REGIMEN_SALUD_NOMBRE", tobRegAdm.Sia_destip_regi, gcrSeparadorDecimal);
                    // Codigo zona de residencia
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_ZONA_RESIDENCIA_CODIGO", tobRegAdm.Sis_zonres_tzon, gcrSeparadorDecimal);
                    // Descripcion zona residencia
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_ZONA_RESIDENCIA_NOMBRE", tobRegAdm.Sis_deszon_tzon, gcrSeparadorDecimal);
                    // Teléfono del usuario
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_NUMERO_TELEFONO", tobRegAdm.Sia_telres_usua, gcrSeparadorDecimal);
                    // Dirección de residencia
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_DIRECCION_RESIDENCIA", tobRegAdm.Sia_dirres_usua, gcrSeparadorDecimal);
                    // Correo electrónico
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_CORREO_ELECTRONICO", tobRegAdm.Sia_correo_usua, gcrSeparadorDecimal);
                    // Código ocupación
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_OCUPACION_CODIGO", tobRegAdm.Sis_codocu_ocup, gcrSeparadorDecimal);
                    // Codigo Tipo discapacidad
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_DISCAPACIDAD_CODIGO", tobRegAdm.Sia_tipdis_tdis, gcrSeparadorDecimal);
                    // Descripcion tipo discapacidad
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_DISCAPACIDAD_NOMBRE", tobRegAdm.Sia_desdis_tdis, gcrSeparadorDecimal);
                    // Codigo Municipio
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_COD_MUNICIP_RESIDENCIA", tobRegAdm.Sis_codmun_muni, gcrSeparadorDecimal);
                    // Nombre municipio
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_NOM_MUNICIP_RESIDENCIA", tobRegAdm.Sis_nommun_muni, gcrSeparadorDecimal);
                    // Codigo departamento residencia
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_COD_DEPARTA_RESIDENCIA", tobRegAdm.Sis_coddep_dpto, gcrSeparadorDecimal);
                    // Nombre departamento residencia
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "USUARIO_NOM_DEPARTA_RESIDENCIA", tobRegAdm.Sis_desdep_dpto, gcrSeparadorDecimal);
                    #endregion
                    //-------------------------------------------------------------------
                    // ADMISION- VARIABLES DATOS ADMISION PACIENTES
                    //-------------------------------------------------------------------
                    #region VARIABLES DATOS ADMISION PACIENTES
                    var lcrValor = String.Empty;
                    // Numero unico admisión del paciente
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_NUMERO_REGISTRO_ADIM", tobRegAdm.Adm_secadm_rgad, gcrSeparadorDecimal);
                    // Numero historia clínica
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_NUM_HISTORIA_CLINICA", tobRegAdm.Hcl_nrohis_hicl, gcrSeparadorDecimal);
                    // Código registro cita
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CODIG_ASIGNACION_CITA", tobRegAdm.Cit_codasi_mcit, gcrSeparadorDecimal);
                    // Fecha Admisión
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_FECHA_ADMISION", tobRegAdm.Adm_fecadm_rgad.ToShortDateString(), gcrSeparadorDecimal);
                    // Hora de Admisión
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_HORA_ADMISION", tobRegAdm.Adm_horadm_rgad.ToString(), gcrSeparadorDecimal);
                    // Embarazada SI/NO/NO APLICA
                    lcrValor = tobRegAdm.Adm_pacemb_rgad == "1" ? "SI" : tobRegAdm.Adm_pacemb_rgad == "2" ? "NO" : "NO APLICA";
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_EMBARAZADA_SI_NO", lcrValor, gcrSeparadorDecimal);
                    // Reingreso antes de 48h
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_REINGRE_ANTES_48HORAS", tobRegAdm.Adm_reingr_rgad, gcrSeparadorDecimal);
                    // Código Origen admisión
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_RIPS_ORGIEN_ADMISON", tobRegAdm.Adm_codoad_toad, gcrSeparadorDecimal);
                    // Código Área de servicios
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CODIGO_AREA_SERVICIO", tobRegAdm.Sia_codare_aser, gcrSeparadorDecimal);
                    // Código Área de Ingreso
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_COD_AREA_SERV_INGRESA", tobRegAdm.Sia_areing_aser, gcrSeparadorDecimal);
                    // Tipo ambito de atención
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_RIPS_AMBITO_ATENCION", tobRegAdm.Adm_codtat_tatn, gcrSeparadorDecimal);
                    // Causa Externa
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CAUSA_EXTERNA_ORIGEN", tobRegAdm.Adm_codcex_tcex, gcrSeparadorDecimal);
                    // Código Cama
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CODIGO_CAMA_ESTANCIA", tobRegAdm.Hos_codcam_caho, gcrSeparadorDecimal);
                    // Código sección
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_COD_SECCION_ESTANCIA", tobRegAdm.Hos_codsec_hsec, gcrSeparadorDecimal);
                    // Diagnostico Ingreso
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CIE10_DIAG_DE_INGRESO", tobRegAdm.Sia_dixing_tdia, gcrSeparadorDecimal);
                    // Causa de Consulta
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CAUSA_TEXTUAL_INGRESO", tobRegAdm.Adm_caucon_rgad, gcrSeparadorDecimal);
                    // Fecha Hospitalización
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_FECHA_HOSPITALIZACION", tobRegAdm.Adm_fechos_rgad.ToShortDateString(), gcrSeparadorDecimal);
                    // Hora Hospitalización
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_HORA_HOSPITALIZACION", tobRegAdm.Adm_horhos_rgad.ToString(), gcrSeparadorDecimal);
                    // Secuencial de Contrato
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_SECUENCIAL_CONTRATO", tobRegAdm.Cto_seccon_cont, gcrSeparadorDecimal);
                    // Número Contrato
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_NUMERO_CONTRATO", tobRegAdm.Cto_nrocon_cont, gcrSeparadorDecimal);
                    // Código EPS
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CODIGO_EAPB_EPS", tobRegAdm.Sia_codeps_teps, gcrSeparadorDecimal);
                    // Código Profesional Autoriza ingreso
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_PROFESIONAL_ATIENDE", tobRegAdm.Sia_codpfa_prof, gcrSeparadorDecimal);
                    // Numero Autorización
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_NUM_AUTORIZACION_EPS", tobRegAdm.Adm_nroaut_rgad, gcrSeparadorDecimal);
                    // Nombre Acompañante
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_ACOMPAÑANTE_NOMBRE", tobRegAdm.Adm_nomaco_rgad, gcrSeparadorDecimal);
                    // Dirección Acompañante
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_ACOMPAÑANTE_DIRECCION", tobRegAdm.Adm_diraco_rgad, gcrSeparadorDecimal);
                    // Teléfono acompañante
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_ACOMPAÑANTE_TELEFONO", tobRegAdm.Adm_telaco_rgad, gcrSeparadorDecimal);
                    // Numero Remisión desde otra IPS
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CODINGRESO_X_REMISION", tobRegAdm.Adm_nrorem_rgad, gcrSeparadorDecimal);
                    // Codigo Id municipio Origen Remision
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_MUNICIPO_ORIGEN_REMIS", tobRegAdm.Sis_idemun_muni, gcrSeparadorDecimal);
                    // Nombre IPS Origen remisión
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_NOM_IPS_ORIGEN_REMISI", tobRegAdm.Sia_codips_tips, gcrSeparadorDecimal);
                    // Fecha Remisión desde otra IPS
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_FECHAING_REMI_OTS_IPS", tobRegAdm.Adm_fecrem_rgad.ToShortDateString(), gcrSeparadorDecimal);
                    // Tipo registro de atención (sistema)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_TIPO_REGISTR_ATENCION", tobRegAdm.Sia_regate_rgat, gcrSeparadorDecimal);
                    // Finalidad Consulta (según RIPS)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_RIPS_FINALID_CONSULTA", tobRegAdm.Sia_codfco_fcon, gcrSeparadorDecimal);
                    // Diagnostico principal consulta (CIE - 10)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CIE10_DIAGNOSTIC_PPAL", tobRegAdm.Sia_coddia_tdia, gcrSeparadorDecimal);
                    // Tipo diagnostico principal de consulta
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_RIPS_TIP_DX_PRINCIPAL", tobRegAdm.Sia_tipdxp_tdix, gcrSeparadorDecimal);
                    // Destino al salir de la atención
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_RIPS_DESTINO_AL_SALIR", tobRegAdm.Adm_dessal_regr, gcrSeparadorDecimal);
                    // Diagnostico relacionado1
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CIE10_DIAG_RELACIONA1", tobRegAdm.Sia_dixre1_tdia, gcrSeparadorDecimal);
                    // Diagnostico relacionado2
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CIE10_DIAG_RELACIONA2", tobRegAdm.Sia_dixre2_tdia, gcrSeparadorDecimal);
                    // Diagnostico relacionado3
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CIE10_DIAG_RELACIONA3", tobRegAdm.Sia_dixre3_tdia, gcrSeparadorDecimal);
                    // Código centro atención
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CODIGO_SEDE_ATENCION", tobRegAdm.Sia_codcat_ceat, gcrSeparadorDecimal);
                    // Código usuario Digitador
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ADMISION_CODIGO_USUARIO_DIGITA", tobRegAdm.Sys_codusu_usux, gcrSeparadorDecimal);
                    #endregion

                    // Devolver ultimo numero generado desde referencia al temporal de admision
                    lnuContador = tobRegAdm.Adm_secite_rgad;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvGenAdmisionVariablesPublicas");
            }
            return lnuContador;
        }
        #endregion
        // Variables Tirage
        #region fnuGenTriageVariablesPublicas: Generar variables publicas codigo Triage
        /// <summary>
        /// <para>fcvGenTriageVariablesPublicas()</para>
        /// <para>Generar variables publicas activas usuario cuando el triage decide internarlo en observacion</para>
        /// </summary>
        public static int fnuGenTriageVariablesPublicas(ref ADMModeloAdmadmisiones tobRegAdm, String tcrCodigoTriage)
        {
            var lnuContador = 0;
            var gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
            var lobTemp = ADMModeloTriage.flsListaAdmtriagemaestr(tcrCodigoTriage);
            if (lobTemp != null)
            {
                var tobReg = lobTemp.FirstOrDefault();
                lnuContador = fnuGenTriageVariablesPublicas(ref tobRegAdm, tobReg);
            }
            return lnuContador;
        }
        #endregion
        #region fcvGenTriageVariablesPublicas: Generar variables publicas temporal Triage
        /// <summary>
        /// <para>fcvGenTriageVariablesPublicas()</para>
        /// <para>Generar variables publicas activas usuario cuando el triage decide internarlo en observacion</para>
        /// </summary>
        public static int fnuGenTriageVariablesPublicas(ref ADMModeloAdmadmisiones tobRegAdm, ADMModeloTriage tobReg)
        {
            var lnuContador = 0;

            try
            {
                var gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                if (tobReg != null)
                {
                    //-------------------------------------------------------------------
                    // GRUPOS VARIABLES TRIAGE
                    //-------------------------------------------------------------------
                    #region VARIABLES DATOS TRIAGE
                    var lcrValor = String.Empty;
                    // Codigo registro
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_NUMERO_REGISTRO_TRIAGE", tobReg.Adm_nroreg_tria, gcrSeparadorDecimal);
                    // Fecha servicio
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_FECHA_SERVICIO", tobReg.Adm_gesfec_tria.ToShortDateString(), gcrSeparadorDecimal);
                    // Hora servicio
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_HORA_SERVICIO", tobReg.Adm_geshor_tria.ToString(), gcrSeparadorDecimal);
                    // Frecuencia cardiaca (FC)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_FRECUENCIA_CARDIACA_FC", tobReg.Adm_frecar_tria.ToString(), gcrSeparadorDecimal);
                    // Frecuencia respiratoria (FR)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_FRECUENCIA_RESPIRA_FR", tobReg.Adm_freres_tria.ToString(), gcrSeparadorDecimal);
                    // T.Arterial  sistólica
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_TEN_ARTERIAL_SISTOLICA", tobReg.Adm_tasist_tria.ToString(), gcrSeparadorDecimal);
                    // T.Arterial diastólica
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_TEN_ARTERIAL_DIASTOLIC", tobReg.Adm_tadias_tria.ToString(), gcrSeparadorDecimal);
                    // Temperatura corporal
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_TEMPERATURA_CORPORAL", tobReg.Adm_temper_tria.ToString(), gcrSeparadorDecimal);
                    // Peso (kilogramos)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_PESO_CORPORAL_EN_KILOG", tobReg.Adm_pesokg_tria.ToString(), gcrSeparadorDecimal);
                    // Talla (centimetros)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_TALLA_EN_CENTIMETROS", tobReg.Adm_tallac_tria.ToString(), gcrSeparadorDecimal);
                    // Signos vitales (todos)
                    lcrValor = "FRECUENCIA CARDIACA: " + tobReg.Adm_frecar_tria.ToString() + " FRECUENCIA RESPIRATORIA: " + tobReg.Adm_freres_tria.ToString() +
                               "TENSION ARTERIAL SISTOLICA: " + tobReg.Adm_tasist_tria.ToString() + " TENSION ARTERIAL DIASTOLICA: " + tobReg.Adm_tadias_tria.ToString()+
                               "TEMPERATURA CORPORAL: " + tobReg.Adm_temper_tria.ToString();
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_RESUMEN_SIGNOS_VITALES", lcrValor, gcrSeparadorDecimal);
                    // llegada al servicio
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_TIPO_TRANSPORT_LLEGA", tobReg.Adm_tiplle_tria, gcrSeparadorDecimal);
                    // Motivo consulta
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_MOTIVO_TEXTUAL_CONSULTA", tobReg.Adm_motcon_tria, gcrSeparadorDecimal);
                    // Clasificación triage
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_CLASIFICACION_TRIAGE", tobReg.Adm_clasif_tria, gcrSeparadorDecimal);
                    // Destino Remisión
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_DESTINO_REMISION_EVALUA", tobReg.Adm_remisi_tria, gcrSeparadorDecimal);
                    // Codgo Diagnostico
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_CIE10_DIAG_PRESUNTIVO", tobReg.Sia_coddia_tdia, gcrSeparadorDecimal);
                    // Observación
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_NOTA_OBSERVACION", tobReg.Adm_observ_tria, gcrSeparadorDecimal);
                    // Id único Municipio
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_CODIGO_MUNICIPIO", tobReg.Sis_idemun_muni, gcrSeparadorDecimal);
                    // Código centro atención
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_SEDE_RECIBE_ATENCION", tobReg.Sia_codcat_ceat, gcrSeparadorDecimal);
                    // Profesional atiende
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_COD_PROFESIONAL_ATIENDE", tobReg.Sia_codpfa_prof, gcrSeparadorDecimal);
                    // Tipo registro
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "TRIAGE_TIPO_VALORACION_TRIAGE", tobReg.Adm_tipreg_tria, gcrSeparadorDecimal);
                    #endregion
                    //-------------------------------------------------------------------
                    // GRUPOS VARIABLES DESDE TRIAGE PARA URGENCIAS
                    //-------------------------------------------------------------------
                    #region VARIABLES DATOS DESDE TRIAGE PARA URGENCIAS
                    lcrValor = String.Empty;
                    // Fecha servicio urgencias
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ATENURGEN_FECH_URGENCIA", tobReg.Adm_gesfec_tria.ToShortDateString(), gcrSeparadorDecimal);
                    // Hora servicio
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ATENURGEN_HORA_LLEGADA_URG", tobReg.Adm_geshor_tria.ToString(), gcrSeparadorDecimal);
                    // Frecuencia cardiaca (FC)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "EXAMFISC_FREC_CARDIACA_URG", tobReg.Adm_frecar_tria.ToString(), gcrSeparadorDecimal);
                    // Frecuencia respiratoria (FR)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "EXAMFISC_FREC_RESPIRAT_URG", tobReg.Adm_freres_tria.ToString(), gcrSeparadorDecimal);
                    // T.Arterial diastólica/T.Arterial  sistólica 
                    lcrValor = tobReg.Adm_tasist_tria.ToString() + "/" + tobReg.Adm_tadias_tria.ToString();
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "EXAMFISC_TENS_ARTERIAL_URG", lcrValor, gcrSeparadorDecimal);
                    // Temperatura corporal
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "EXAMFISC_TEMPERATURA_URG", tobReg.Adm_temper_tria.ToString(), gcrSeparadorDecimal);
                    // Peso (kilogramos)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "EXAMFISC_PESO_URGENCIA", tobReg.Adm_pesokg_tria.ToString(), gcrSeparadorDecimal);
                    // Talla (centimetros)
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "EXAMFISC_TALLA_URGENCIA", tobReg.Adm_tallac_tria.ToString(), gcrSeparadorDecimal);
                    // Motivo consulta
                    fcvGenerarValorVariablePublica(ref tobRegAdm, "ATENURGEN_MOTIVO_CONS_URG", tobReg.Adm_motcon_tria, gcrSeparadorDecimal);
                    #endregion

                    // Devolver ultimo numero generado desde referencia al temporal de admision
                    lnuContador = tobRegAdm.Adm_secite_rgad;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvGenTriageVariablesPublicas");
            }

            return lnuContador;
        }
        #endregion
        // Generar las variables 
        #region fcvGenerarValorVariablePublica: Cargar valores variables
        /// <summary>
        /// <para>fcvGenerarValorVariablePublica()</para>
        /// <para>Cargar valores variables</para>
        /// </summary>
        public static void fcvGenerarValorVariablePublica(ref ADMModeloAdmadmisiones tobRegAdm,
                                                           String tcrNombreVariable, String tcrValorVariable, String tcrSeparador)
        {
            try
            {
                var lobVar = HCLValidarCodigo.fobRegBuscarHclvariabmaestrVr(tcrNombreVariable);
                if (lobVar != null)
                {
                    // Para generar el secuencial unico
                    tobRegAdm.Adm_secite_rgad = tobRegAdm.Adm_secite_rgad + 1;

                    var lobReg = new ModeloHclvariabactual();

                    lobReg.Hcl_nomvar_hcvr = tcrNombreVariable;
                    lobReg.Hcl_nivvar_hcvr = lobVar.hcl_nivvar_hcvr;
                    lobReg.Hcl_valvar_hcvr = tcrValorVariable;
                    lobReg.Hcl_valdes_hcva = String.Empty;
                    lobReg.Adm_secadm_rgad = tobRegAdm.Adm_secadm_rgad;
                    lobReg.Sia_idesec_usua = tobRegAdm.Sia_idesec_usua;
                    lobReg.Sia_tipide_tide = tobRegAdm.Sia_tipide_tide;
                    lobReg.Sia_nroide_usua = tobRegAdm.Sia_nroide_usua;
                    lobReg.Hcl_fecges_hcva = Convert.ToDateTime(Funciones.fcrFechaActual());
                    lobReg.Hcl_horges_hcva = Decimal.Parse(Funciones.fcrHoraActual("24", tcrSeparador));
                    lobReg.Hcl_auxges_hcva = String.Empty;
                    lobReg.Sis_estreg_esrg = "1";
                    lobReg.NumeroRegistro = tobRegAdm.Adm_secite_rgad;

                    fcvActualizarVar(lobReg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo cargar valores: fcvGenAdmisionVariablesPublicas");
            }
        }
        #endregion
        #region fcvActualizarVariablePublica: Generar variable desde Id usuario y nombre variable
        /// <summary>
        /// <para>fcvActualizarVariablePublica()</para>
        /// <para>Generar variable desde Id usuario y nombre variable (para llamada desde formatos H.C.)</para>
        /// <para>PARAMETROS:</para>
        /// <para>tcrSistema: Segun el origen del llamado, cuando una variable es protegida puede ser modificada:</para>
        /// <para>"1" = llamado desde gestion sistema (se permite modificar valores protegidos y mas)</para>
        /// <para>"2" = llamado desde gestion formatos H.C.(modificar solo valores no protegidos)</para>
        /// <para>tcrCodigoAdmision: Numero de la admision del paciente</para>
        /// <para>tcrIdUnicoUsuario: Numero unico del usuario en base de datos</para>
        /// <para>tcrTipoIde: Tipo de identificacion del usuario o paciente, CC,TI,RC,...</para>
        /// <para>tcrNumeroIdentificacion: Numero de identificacion del usuario segun Registraduria Nacional</para>
        /// <para>tcrNombreVariable: Nombre de la variable a gestionar, ejemplo: "USUARIO_DIRECCION_RESIDENCIA"</para>
        /// <para>tcrValorVariable: Nuevo valor para la variable</para>
        /// <para>tcrSeparadorDecimal: Separador decimal configurado en Windows para valores flotantes o decimal</para>
        /// </summary>
        public static void fcvActualizarVariablePublica(String tcrSistema, String tcrCodigoAdmision, String tcrIdUnicoUsuario,
                                                          String tcrTipoIde, String tcrNumeroIdentificacion, String tcrNombreVariable,
                                                          String tcrValorVariable, int tnuIdRegistro , String tcrSeparadorDecimal)
        {
            try
            {
                var lobVar = HCLValidarCodigo.fobRegBuscarHclvariabmaestrVr(tcrNombreVariable);
                if (lobVar != null)
                {
                    var lobReg = new ModeloHclvariabactual();

                    lobReg.Hcl_nomvar_hcvr = tcrNombreVariable;
                    lobReg.Hcl_nivvar_hcvr = lobVar.hcl_nivvar_hcvr;
                    lobReg.Hcl_valvar_hcvr = tcrValorVariable;
                    lobReg.Hcl_valdes_hcva = String.Empty;
                    lobReg.Adm_secadm_rgad = tcrCodigoAdmision;
                    lobReg.Sia_idesec_usua = tcrIdUnicoUsuario;
                    lobReg.Sia_tipide_tide = tcrTipoIde;
                    lobReg.Sia_nroide_usua = tcrNumeroIdentificacion;
                    lobReg.Hcl_fecges_hcva = Convert.ToDateTime(Funciones.fcrFechaActual());
                    lobReg.Hcl_horges_hcva = Decimal.Parse(Funciones.fcrHoraActual("24", tcrSeparadorDecimal));
                    lobReg.Hcl_auxges_hcva = String.Empty;
                    lobReg.Sis_estreg_esrg = "1";
                    lobReg.NumeroRegistro = tnuIdRegistro;

                    if (tcrSistema == "1")
                    {
                        // si se llama desde sistema, se actualiza cualquier asi este protegida
                        fcvActualizarVar(lobReg);
                    }
                    else if (lobVar.hcl_camdig_hcvr == "1" || lobVar.hcl_camdig_hcvr == "2")
                    {
                        // Llamado desde formatos HC
                        // si el campo es modificable se actualiza
                        fcvActualizarVar(lobReg);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo Generar variable: fcvActualizarVariablePublica");
            }
        }
        #endregion
        // Gaurdar datos de variables 
        #region fcvActualizarVar: Actualizar registro id unico y Variable
        /// <summary>
        /// <para>fcvActualizar()</para>
        /// <para>Actualizar por Id unico usuario (Sia_idesec_usua) y Nombre variable publica (Hcl_nomvar_hcvr)</para>
        /// <para>COMENTARIO:</para>
        /// <para>Id unica paciente "ID00045289", Nombre de la variable para actualizar ejemplo: "ADMISION_DIAGNOSTICO_INGRESO".</para>
        /// </summary>
        public static void fcvActualizarVar(ModeloHclvariabactual tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclvariabactual.FirstOrDefault(p => p.sia_idesec_usua == tobjModelo.Sia_idesec_usua &&
                                                                                    p.hcl_nomvar_hcvr == tobjModelo.Hcl_nomvar_hcvr);
                    if (lobjRegistro != null)
                    {
                        //lobjRegistro.hcl_nroreg_hcva = tobjModelo.Hcl_nroreg_hcva;
                        lobjRegistro.hcl_nomvar_hcvr = tobjModelo.Hcl_nomvar_hcvr;
                        lobjRegistro.hcl_nivvar_hcvr = tobjModelo.Hcl_nivvar_hcvr;
                        lobjRegistro.hcl_valvar_hcvr = tobjModelo.Hcl_valvar_hcvr;
                        lobjRegistro.hcl_valdes_hcva = tobjModelo.Hcl_valdes_hcva;
                        lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                        lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                        lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                        lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                        lobjRegistro.hcl_fecges_hcva = (DateTime)tobjModelo.Hcl_fecges_hcva;
                        lobjRegistro.hcl_horges_hcva = (Decimal)tobjModelo.Hcl_horges_hcva;
                        lobjRegistro.hcl_auxges_hcva = tobjModelo.Hcl_auxges_hcva;
                        lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
                        _context.SaveChanges();
                    }
                    else
                    {
                        // No existe, se debe adicionar
                        fcrAddRegistroVariable(tobjModelo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo Error Metodo: fcvActualizar");
            }
        }
        #endregion
        #region flgAddRegistro: Adicionar Registro
        public static String fcrAddRegistroVariable(ModeloHclvariabactual tobjModelo)
        {
            var lcrllave = tobjModelo.Hcl_nivvar_hcvr == "1" ? "R" : "T";
            String lcrCodigoGen = String.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    lcrCodigoGen = tobjModelo.Adm_secadm_rgad.Trim() + lcrllave + tobjModelo.NumeroRegistro.ToString();
                    var lobjRegistro = new EFhclvariabactual
                    {
                        #region cargar Registro
                        hcl_nroreg_hcva = tobjModelo.Hcl_nroreg_hcva,
                        hcl_nomvar_hcvr = tobjModelo.Hcl_nomvar_hcvr,
                        hcl_nivvar_hcvr = tobjModelo.Hcl_nivvar_hcvr,
                        hcl_valvar_hcvr = tobjModelo.Hcl_valvar_hcvr,
                        hcl_valdes_hcva = tobjModelo.Hcl_valdes_hcva,
                        adm_secadm_rgad = tobjModelo.Adm_secadm_rgad,
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        hcl_fecges_hcva = tobjModelo.Hcl_fecges_hcva,
                        hcl_horges_hcva = tobjModelo.Hcl_horges_hcva,
                        hcl_auxges_hcva = tobjModelo.Hcl_auxges_hcva,
                        sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                        #endregion
                    };
                    lobjRegistro.hcl_nroreg_hcva = lcrCodigoGen;
                    _context.AddToHclvariabactual(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Sistema.Modelo.ModeloHclvariabactual: fcrAddRegistroVariable");
                //MessageBox.Show(ex.Message, "Sistema.Modelo.ModeloHclvariabactual: fcrAddRegistroVariable");
            }

            return lcrCodigoGen;
        }
        #endregion
        #region fcvActualizar: Actualizar registro
        /// <summary>
        /// <para>fcvActualizar()</para>
        /// <para>Actualizar por Id unico del registro en Historial variables publicas</para>
        /// </summary>
        public static void fcvActualizar(ModeloHclvariabactual tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclvariabactual.FirstOrDefault(p => p.hcl_nroreg_hcva == tobjModelo.Hcl_nroreg_hcva);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.hcl_nroreg_hcva = tobjModelo.Hcl_nroreg_hcva;
                        lobjRegistro.hcl_nomvar_hcvr = tobjModelo.Hcl_nomvar_hcvr;
                        lobjRegistro.hcl_nivvar_hcvr = tobjModelo.Hcl_nivvar_hcvr;
                        lobjRegistro.hcl_valvar_hcvr = tobjModelo.Hcl_valvar_hcvr;
                        lobjRegistro.hcl_valdes_hcva = tobjModelo.Hcl_valdes_hcva;
                        lobjRegistro.adm_secadm_rgad = tobjModelo.Adm_secadm_rgad;
                        lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                        lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                        lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                        lobjRegistro.hcl_fecges_hcva = (DateTime)tobjModelo.Hcl_fecges_hcva;
                        lobjRegistro.hcl_horges_hcva = (Decimal)tobjModelo.Hcl_horges_hcva;
                        lobjRegistro.hcl_auxges_hcva = tobjModelo.Hcl_auxges_hcva;
                        lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
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
        // Otros porcesos
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclvariabactual.FirstOrDefault(p => p.hcl_nroreg_hcva == tcrCodigo);
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
        #region fcvEliminarVariablesPublicas: Eliminar registros de variables
        /// <summary>
        /// Eliminar variables temporales activas del paciente que finaliza atencion medica.
        /// </summary>
        /// <param name="tcrIdUnicoUsuario">Numero unico de identificacion del usuario en la base de datos</param>
        public static void fcvEliminarVariablesPublicas(String tcrIdUnicoUsuario)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var tmpDatos = from tmp in _context.Hclvariabactual
                                   where tmp.sia_idesec_usua == tcrIdUnicoUsuario && tmp.hcl_nivvar_hcvr !="1"
                                   select tmp;

                    foreach (var lobReg in tmpDatos)
                    {
                        _context.DeleteObject(lobReg);
                    }
                    if (tmpDatos.Count() > 0)
                    {
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
        #region Buscar HCLVARIABACTUAL: Logica
        /// <summary>
        /// <para>TABLA: hclvariabactual</para>
        /// <para>TITULO: Maestro Variables publicas actualizadas</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO: Devuelve valor de tipo logico True/False pa indicar si existe o no el código.</para>
        /// <para>DESCRIPCION TABLA: Maestro Variables publicas con valores actualizados </para>
        /// </summary>
        public static bool flgBuscarHclvariabactual(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclvariabactual.FirstOrDefault(p => p.hcl_nroreg_hcva == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        /// <summary>
        /// <para>flsListaHclvariabactual()</para>
        /// <para>Devuelve una lista de registros que representan las variables publicas consultadas</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrTipoIdBusqueda: Indica que tipo llave busqueda se utilizara: "1" = Codigo unico secuencial del registro en archivo hclvariabactual</para>
        /// <para>"2" = Indica que el parametro tcrIdUsuario contendra un numero de Admision,"3" = Id o Numero unico del usuario en base de datos del sistema,</para>
        /// <para>"4" = Identificacion del usuario</para>
        /// <para>tcrIdUsuario: Contendra --> Id unico del registro/Numero admision/Ide unica en base de datos/Numero identificacion del paciente</para>
        /// <para>tcrNombreVariable: Nombre de la variable a consultar ejemplo: "ADMISION_DIAGNOSTICO_INGRESO".</para>
        /// </summary>
        public static List<ModeloHclvariabactual> flsListaHclvariabactual(String tcrTipoIdBusqueda, String tcrIdUsuario, String tcrNombreVariable)
        {
            using (_context = new DbAplicacion())
            {
                List<ModeloHclvariabactual> lobConsulta = null;
                // Filtro por Codigo unico del registro 
                if (tcrTipoIdBusqueda=="1")
                {
                    #region Filtro por Codigo unico del registro
                    lobConsulta = (from hclvariabactual in _context.Hclvariabactual
                                      join hclvariabmaestr in _context.Hclvariabmaestr on 
                                           hclvariabactual.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr

                                      from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                      where hclvariabactual.hcl_nroreg_hcva == tcrIdUsuario
                                      select new ModeloHclvariabactual
                                      {
                                          Hcl_nroreg_hcva = hclvariabactual.hcl_nroreg_hcva,
                                          Hcl_nomvar_hcvr = hclvariabactual.hcl_nomvar_hcvr,
                                          Hcl_valvar_hcvr = hclvariabactual.hcl_valvar_hcvr,
                                          Hcl_valdes_hcva = hclvariabactual.hcl_valdes_hcva,
                                          Adm_secadm_rgad = hclvariabactual.adm_secadm_rgad,
                                          Sia_idesec_usua = hclvariabactual.sia_idesec_usua,
                                          Sia_tipide_tide = hclvariabactual.sia_tipide_tide,
                                          Sia_nroide_usua = hclvariabactual.sia_nroide_usua,
                                          Hcl_fecges_hcva = (DateTime)hclvariabactual.hcl_fecges_hcva,
                                          Hcl_horges_hcva = (Decimal)hclvariabactual.hcl_horges_hcva,
                                          Hcl_auxges_hcva = hclvariabactual.hcl_auxges_hcva,
                                          Sis_estreg_esrg = hclvariabactual.sis_estreg_esrg,
                                          Hcl_secgru_hcgv = hcvr.hcl_secgru_hcgv,
                                          Hcl_ordvis_hcvr = (int)hcvr.hcl_ordvis_hcvr,
                                          Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                          Hcl_descri_hcvr = hcvr.hcl_descri_hcvr,
                                          Hcl_tipval_hcvr = hcvr.hcl_tipval_hcvr,
                                          Hcl_valper_hcvr = hcvr.hcl_valper_hcvr,
                                          Hcl_camdig_hcvr = hcvr.hcl_camdig_hcvr,
                                          Hcl_ranini_hcvr = hcvr.hcl_ranini_hcvr,
                                          Hcl_ranfin_hcvr = hcvr.hcl_ranfin_hcvr,
                                          Hcl_raninr_hcvr = hcvr.hcl_raninr_hcvr,
                                          Hcl_ranfnr_hcvr = hcvr.hcl_ranfnr_hcvr,
                                          Hcl_nivvar_hcvr = hcvr.hcl_nivvar_hcvr,
                                          Hcl_sistem_hcvr = hcvr.hcl_sistem_hcvr,
                                          Hcl_sisvar_hcvr = hcvr.hcl_sisvar_hcvr,

                                      }).ToList();
                    #endregion
                }
                else if (tcrTipoIdBusqueda == "2")
                {
                    #region Filtro por Numero unico admision
                    lobConsulta = (from hclvariabactual in _context.Hclvariabactual
                                  join hclvariabmaestr in _context.Hclvariabmaestr on 
                                       hclvariabactual.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr

                                  from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                  where hclvariabactual.adm_secadm_rgad == tcrIdUsuario && hclvariabactual.hcl_nomvar_hcvr == tcrNombreVariable
                                   orderby hclvariabactual.hcl_fecges_hcva, hclvariabactual.hcl_horges_hcva descending
                                  select new ModeloHclvariabactual
                                  {
                                      Hcl_nroreg_hcva = hclvariabactual.hcl_nroreg_hcva,
                                      Hcl_nomvar_hcvr = hclvariabactual.hcl_nomvar_hcvr,
                                      Hcl_valvar_hcvr = hclvariabactual.hcl_valvar_hcvr,
                                      Hcl_valdes_hcva = hclvariabactual.hcl_valdes_hcva,
                                      Adm_secadm_rgad = hclvariabactual.adm_secadm_rgad,
                                      Sia_idesec_usua = hclvariabactual.sia_idesec_usua,
                                      Sia_tipide_tide = hclvariabactual.sia_tipide_tide,
                                      Sia_nroide_usua = hclvariabactual.sia_nroide_usua,
                                      Hcl_fecges_hcva = (DateTime)hclvariabactual.hcl_fecges_hcva,
                                      Hcl_horges_hcva = (Decimal)hclvariabactual.hcl_horges_hcva,
                                      Hcl_auxges_hcva = hclvariabactual.hcl_auxges_hcva,
                                      Sis_estreg_esrg = hclvariabactual.sis_estreg_esrg,
                                      Hcl_secgru_hcgv = hcvr.hcl_secgru_hcgv,
                                      Hcl_ordvis_hcvr = (int)hcvr.hcl_ordvis_hcvr,
                                      Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                      Hcl_descri_hcvr = hcvr.hcl_descri_hcvr,
                                      Hcl_tipval_hcvr = hcvr.hcl_tipval_hcvr,
                                      Hcl_valper_hcvr = hcvr.hcl_valper_hcvr,
                                      Hcl_camdig_hcvr = hcvr.hcl_camdig_hcvr,
                                      Hcl_ranini_hcvr = hcvr.hcl_ranini_hcvr,
                                      Hcl_ranfin_hcvr = hcvr.hcl_ranfin_hcvr,
                                      Hcl_raninr_hcvr = hcvr.hcl_raninr_hcvr,
                                      Hcl_ranfnr_hcvr = hcvr.hcl_ranfnr_hcvr,
                                      Hcl_nivvar_hcvr = hcvr.hcl_nivvar_hcvr,
                                      Hcl_sistem_hcvr = hcvr.hcl_sistem_hcvr,
                                      Hcl_sisvar_hcvr = hcvr.hcl_sisvar_hcvr,

                                  }).ToList();
                    #endregion
                }
                else if (tcrTipoIdBusqueda == "3")
                {
                    #region Numero unico en base de datos del sistema
                    lobConsulta = (from hclvariabactual in _context.Hclvariabactual
                                  join hclvariabmaestr in _context.Hclvariabmaestr on
                                       hclvariabactual.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr

                                  from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                  where hclvariabactual.sia_idesec_usua == tcrIdUsuario && hclvariabactual.hcl_nomvar_hcvr == tcrNombreVariable
                                   orderby hclvariabactual.hcl_fecges_hcva, hclvariabactual.hcl_horges_hcva descending
                                   select new ModeloHclvariabactual
                                  {
                                      Hcl_nroreg_hcva = hclvariabactual.hcl_nroreg_hcva,
                                      Hcl_nomvar_hcvr = hclvariabactual.hcl_nomvar_hcvr,
                                      Hcl_valvar_hcvr = hclvariabactual.hcl_valvar_hcvr,
                                      Hcl_valdes_hcva = hclvariabactual.hcl_valdes_hcva,
                                      Adm_secadm_rgad = hclvariabactual.adm_secadm_rgad,
                                      Sia_idesec_usua = hclvariabactual.sia_idesec_usua,
                                      Sia_tipide_tide = hclvariabactual.sia_tipide_tide,
                                      Sia_nroide_usua = hclvariabactual.sia_nroide_usua,
                                      Hcl_fecges_hcva = (DateTime)hclvariabactual.hcl_fecges_hcva,
                                      Hcl_horges_hcva = (Decimal)hclvariabactual.hcl_horges_hcva,
                                      Hcl_auxges_hcva = hclvariabactual.hcl_auxges_hcva,
                                      Sis_estreg_esrg = hclvariabactual.sis_estreg_esrg,
                                      Hcl_secgru_hcgv = hcvr.hcl_secgru_hcgv,
                                      Hcl_ordvis_hcvr = (int)hcvr.hcl_ordvis_hcvr,
                                      Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                      Hcl_descri_hcvr = hcvr.hcl_descri_hcvr,
                                      Hcl_tipval_hcvr = hcvr.hcl_tipval_hcvr,
                                      Hcl_valper_hcvr = hcvr.hcl_valper_hcvr,
                                      Hcl_camdig_hcvr = hcvr.hcl_camdig_hcvr,
                                      Hcl_ranini_hcvr = hcvr.hcl_ranini_hcvr,
                                      Hcl_ranfin_hcvr = hcvr.hcl_ranfin_hcvr,
                                      Hcl_raninr_hcvr = hcvr.hcl_raninr_hcvr,
                                      Hcl_ranfnr_hcvr = hcvr.hcl_ranfnr_hcvr,
                                      Hcl_nivvar_hcvr = hcvr.hcl_nivvar_hcvr,
                                      Hcl_sistem_hcvr = hcvr.hcl_sistem_hcvr,
                                      Hcl_sisvar_hcvr = hcvr.hcl_sisvar_hcvr,

                                  }).ToList();
                    #endregion
                }
                else if (tcrTipoIdBusqueda == "4")
                {
                    #region Identificacion del usuario
                    lobConsulta = (from hclvariabactual in _context.Hclvariabactual
                                  join hclvariabmaestr in _context.Hclvariabmaestr on
                                       hclvariabactual.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr

                                  from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                  where hclvariabactual.sia_nroide_usua == tcrIdUsuario && hclvariabactual.hcl_nomvar_hcvr == tcrNombreVariable
                                   orderby hclvariabactual.hcl_fecges_hcva, hclvariabactual.hcl_horges_hcva descending
                                   select new ModeloHclvariabactual
                                  {
                                      Hcl_nroreg_hcva = hclvariabactual.hcl_nroreg_hcva,
                                      Hcl_nomvar_hcvr = hclvariabactual.hcl_nomvar_hcvr,
                                      Hcl_valvar_hcvr = hclvariabactual.hcl_valvar_hcvr,
                                      Hcl_valdes_hcva = hclvariabactual.hcl_valdes_hcva,
                                      Adm_secadm_rgad = hclvariabactual.adm_secadm_rgad,
                                      Sia_idesec_usua = hclvariabactual.sia_idesec_usua,
                                      Sia_tipide_tide = hclvariabactual.sia_tipide_tide,
                                      Sia_nroide_usua = hclvariabactual.sia_nroide_usua,
                                      Hcl_fecges_hcva = (DateTime)hclvariabactual.hcl_fecges_hcva,
                                      Hcl_horges_hcva = (Decimal)hclvariabactual.hcl_horges_hcva,
                                      Hcl_auxges_hcva = hclvariabactual.hcl_auxges_hcva,
                                      Sis_estreg_esrg = hclvariabactual.sis_estreg_esrg,
                                      Hcl_secgru_hcgv = hcvr.hcl_secgru_hcgv,
                                      Hcl_ordvis_hcvr = (int)hcvr.hcl_ordvis_hcvr,
                                      Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                      Hcl_descri_hcvr = hcvr.hcl_descri_hcvr,
                                      Hcl_tipval_hcvr = hcvr.hcl_tipval_hcvr,
                                      Hcl_valper_hcvr = hcvr.hcl_valper_hcvr,
                                      Hcl_camdig_hcvr = hcvr.hcl_camdig_hcvr,
                                      Hcl_ranini_hcvr = hcvr.hcl_ranini_hcvr,
                                      Hcl_ranfin_hcvr = hcvr.hcl_ranfin_hcvr,
                                      Hcl_raninr_hcvr = hcvr.hcl_raninr_hcvr,
                                      Hcl_ranfnr_hcvr = hcvr.hcl_ranfnr_hcvr,
                                      Hcl_nivvar_hcvr = hcvr.hcl_nivvar_hcvr,
                                      Hcl_sistem_hcvr = hcvr.hcl_sistem_hcvr,
                                      Hcl_sisvar_hcvr = hcvr.hcl_sisvar_hcvr,

                                  }).ToList();
                    #endregion
                }
                // retornar lista 
                return lobConsulta;
            }
        }
        #endregion
        #region fobRegistroHclVariabActual: Registro unico
        /// <summary>
        /// <para>flsListaHclvariabactual()</para>
        /// <para>Devuelve una lista de registros que representan las variables publicas consultadas</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrTipoIdBusqueda: Indica que tipo llave busqueda se utilizara: "1" = Codigo unico secuencial del registro en archivo hclvariabactual</para>
        /// <para>"2" = Indica que el parametro tcrIdUsuario contendra un numero de Admision,"3" = Id o Numero unico del usuario en base de datos del sistema,</para>
        /// <para>"4" = Identificacion del usuario</para>
        /// <para>tcrIdUsuario: Contendra --> Id unico del registro/Numero admision/Ide unica en base de datos/Numero identificacion del paciente</para>
        /// <para>tcrNombreVariable: Nombre de la variable a consultar ejemplo: "ADMISION_DIAGNOSTICO_INGRESO".</para>
        /// </summary>
        public static ModeloHclvariabactual fobRegistroHclVariabActual(String tcrTipoIdBusqueda, String tcrIdUsuario, String tcrNombreVariable)
        {
            using (_context = new DbAplicacion())
            {
                ModeloHclvariabactual lobConsulta = null;
                // Filtro por Codigo unico del registro 
                if (tcrTipoIdBusqueda == "1")
                {
                    #region Filtro por Codigo unico del registro
                    lobConsulta = (from hclvariabactual in _context.Hclvariabactual
                                   join hclvariabmaestr in _context.Hclvariabmaestr on
                                        hclvariabactual.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr
                                   from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                   where hclvariabactual.hcl_nroreg_hcva == tcrIdUsuario
                                   select new ModeloHclvariabactual
                                   {
                                       Hcl_nroreg_hcva = hclvariabactual.hcl_nroreg_hcva,
                                       Hcl_nomvar_hcvr = hclvariabactual.hcl_nomvar_hcvr,
                                       Hcl_valvar_hcvr = hclvariabactual.hcl_valvar_hcvr,
                                       Hcl_valdes_hcva = hclvariabactual.hcl_valdes_hcva,
                                       Adm_secadm_rgad = hclvariabactual.adm_secadm_rgad,
                                       Sia_idesec_usua = hclvariabactual.sia_idesec_usua,
                                       Sia_tipide_tide = hclvariabactual.sia_tipide_tide,
                                       Sia_nroide_usua = hclvariabactual.sia_nroide_usua,
                                       Hcl_fecges_hcva = (DateTime)hclvariabactual.hcl_fecges_hcva,
                                       Hcl_horges_hcva = (Decimal)hclvariabactual.hcl_horges_hcva,
                                       Hcl_auxges_hcva = hclvariabactual.hcl_auxges_hcva,
                                       Sis_estreg_esrg = hclvariabactual.sis_estreg_esrg,
                                       Hcl_secgru_hcgv = hcvr.hcl_secgru_hcgv,
                                       Hcl_ordvis_hcvr = (int)hcvr.hcl_ordvis_hcvr,
                                       Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                       Hcl_descri_hcvr = hcvr.hcl_descri_hcvr,
                                       Hcl_tipval_hcvr = hcvr.hcl_tipval_hcvr,
                                       Hcl_valper_hcvr = hcvr.hcl_valper_hcvr,
                                       Hcl_camdig_hcvr = hcvr.hcl_camdig_hcvr,
                                       Hcl_ranini_hcvr = hcvr.hcl_ranini_hcvr,
                                       Hcl_ranfin_hcvr = hcvr.hcl_ranfin_hcvr,
                                       Hcl_raninr_hcvr = hcvr.hcl_raninr_hcvr,
                                       Hcl_ranfnr_hcvr = hcvr.hcl_ranfnr_hcvr,
                                       Hcl_nivvar_hcvr = hcvr.hcl_nivvar_hcvr,
                                       Hcl_sistem_hcvr = hcvr.hcl_sistem_hcvr,
                                       Hcl_sisvar_hcvr = hcvr.hcl_sisvar_hcvr,

                                   }).FirstOrDefault();
                    #endregion
                }
                else if (tcrTipoIdBusqueda == "2")
                {
                    #region Filtro por Numero unico admision
                    lobConsulta = (from hclvariabactual in _context.Hclvariabactual
                                   join hclvariabmaestr in _context.Hclvariabmaestr on
                                        hclvariabactual.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr
                                   from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                   where hclvariabactual.adm_secadm_rgad == tcrIdUsuario && hclvariabactual.hcl_nomvar_hcvr == tcrNombreVariable
                                   orderby hclvariabactual.hcl_fecges_hcva, hclvariabactual.hcl_horges_hcva descending
                                   select new ModeloHclvariabactual
                                   {
                                       Hcl_nroreg_hcva = hclvariabactual.hcl_nroreg_hcva,
                                       Hcl_nomvar_hcvr = hclvariabactual.hcl_nomvar_hcvr,
                                       Hcl_valvar_hcvr = hclvariabactual.hcl_valvar_hcvr,
                                       Hcl_valdes_hcva = hclvariabactual.hcl_valdes_hcva,
                                       Adm_secadm_rgad = hclvariabactual.adm_secadm_rgad,
                                       Sia_idesec_usua = hclvariabactual.sia_idesec_usua,
                                       Sia_tipide_tide = hclvariabactual.sia_tipide_tide,
                                       Sia_nroide_usua = hclvariabactual.sia_nroide_usua,
                                       Hcl_fecges_hcva = (DateTime)hclvariabactual.hcl_fecges_hcva,
                                       Hcl_horges_hcva = (Decimal)hclvariabactual.hcl_horges_hcva,
                                       Hcl_auxges_hcva = hclvariabactual.hcl_auxges_hcva,
                                       Sis_estreg_esrg = hclvariabactual.sis_estreg_esrg,
                                       Hcl_secgru_hcgv = hcvr.hcl_secgru_hcgv,
                                       Hcl_ordvis_hcvr = (int)hcvr.hcl_ordvis_hcvr,
                                       Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                       Hcl_descri_hcvr = hcvr.hcl_descri_hcvr,
                                       Hcl_tipval_hcvr = hcvr.hcl_tipval_hcvr,
                                       Hcl_valper_hcvr = hcvr.hcl_valper_hcvr,
                                       Hcl_camdig_hcvr = hcvr.hcl_camdig_hcvr,
                                       Hcl_ranini_hcvr = hcvr.hcl_ranini_hcvr,
                                       Hcl_ranfin_hcvr = hcvr.hcl_ranfin_hcvr,
                                       Hcl_raninr_hcvr = hcvr.hcl_raninr_hcvr,
                                       Hcl_ranfnr_hcvr = hcvr.hcl_ranfnr_hcvr,
                                       Hcl_nivvar_hcvr = hcvr.hcl_nivvar_hcvr,
                                       Hcl_sistem_hcvr = hcvr.hcl_sistem_hcvr,
                                       Hcl_sisvar_hcvr = hcvr.hcl_sisvar_hcvr,

                                   }).FirstOrDefault();
                    #endregion
                }
                else if (tcrTipoIdBusqueda == "3")
                {
                    #region Numero unico en base de datos del sistema
                    lobConsulta = (from hclvariabactual in _context.Hclvariabactual
                                   join hclvariabmaestr in _context.Hclvariabmaestr on
                                        hclvariabactual.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr
                                   from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                   where hclvariabactual.sia_idesec_usua == tcrIdUsuario && hclvariabactual.hcl_nomvar_hcvr == tcrNombreVariable
                                   orderby hclvariabactual.hcl_fecges_hcva, hclvariabactual.hcl_horges_hcva descending
                                   select new ModeloHclvariabactual
                                   {
                                       Hcl_nroreg_hcva = hclvariabactual.hcl_nroreg_hcva,
                                       Hcl_nomvar_hcvr = hclvariabactual.hcl_nomvar_hcvr,
                                       Hcl_valvar_hcvr = hclvariabactual.hcl_valvar_hcvr,
                                       Hcl_valdes_hcva = hclvariabactual.hcl_valdes_hcva,
                                       Adm_secadm_rgad = hclvariabactual.adm_secadm_rgad,
                                       Sia_idesec_usua = hclvariabactual.sia_idesec_usua,
                                       Sia_tipide_tide = hclvariabactual.sia_tipide_tide,
                                       Sia_nroide_usua = hclvariabactual.sia_nroide_usua,
                                       Hcl_fecges_hcva = (DateTime)hclvariabactual.hcl_fecges_hcva,
                                       Hcl_horges_hcva = (Decimal)hclvariabactual.hcl_horges_hcva,
                                       Hcl_auxges_hcva = hclvariabactual.hcl_auxges_hcva,
                                       Sis_estreg_esrg = hclvariabactual.sis_estreg_esrg,
                                       Hcl_secgru_hcgv = hcvr.hcl_secgru_hcgv,
                                       Hcl_ordvis_hcvr = (int)hcvr.hcl_ordvis_hcvr,
                                       Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                       Hcl_descri_hcvr = hcvr.hcl_descri_hcvr,
                                       Hcl_tipval_hcvr = hcvr.hcl_tipval_hcvr,
                                       Hcl_valper_hcvr = hcvr.hcl_valper_hcvr,
                                       Hcl_camdig_hcvr = hcvr.hcl_camdig_hcvr,
                                       Hcl_ranini_hcvr = hcvr.hcl_ranini_hcvr,
                                       Hcl_ranfin_hcvr = hcvr.hcl_ranfin_hcvr,
                                       Hcl_raninr_hcvr = hcvr.hcl_raninr_hcvr,
                                       Hcl_ranfnr_hcvr = hcvr.hcl_ranfnr_hcvr,
                                       Hcl_nivvar_hcvr = hcvr.hcl_nivvar_hcvr,
                                       Hcl_sistem_hcvr = hcvr.hcl_sistem_hcvr,
                                       Hcl_sisvar_hcvr = hcvr.hcl_sisvar_hcvr,

                                   }).FirstOrDefault();
                    #endregion
                }
                else if (tcrTipoIdBusqueda == "4")
                {
                    #region Identificacion del usuario
                    lobConsulta = (from hclvariabactual in _context.Hclvariabactual
                                   join hclvariabmaestr in _context.Hclvariabmaestr on
                                        hclvariabactual.hcl_nomvar_hcvr equals hclvariabmaestr.hcl_nomvar_hcvr into tmhclvariabmaestr
                                   from hcvr in tmhclvariabmaestr.DefaultIfEmpty()
                                   where hclvariabactual.sia_nroide_usua == tcrIdUsuario && hclvariabactual.hcl_nomvar_hcvr == tcrNombreVariable
                                   orderby hclvariabactual.hcl_fecges_hcva, hclvariabactual.hcl_horges_hcva descending
                                   select new ModeloHclvariabactual
                                   {
                                       Hcl_nroreg_hcva = hclvariabactual.hcl_nroreg_hcva,
                                       Hcl_nomvar_hcvr = hclvariabactual.hcl_nomvar_hcvr,
                                       Hcl_valvar_hcvr = hclvariabactual.hcl_valvar_hcvr,
                                       Hcl_valdes_hcva = hclvariabactual.hcl_valdes_hcva,
                                       Adm_secadm_rgad = hclvariabactual.adm_secadm_rgad,
                                       Sia_idesec_usua = hclvariabactual.sia_idesec_usua,
                                       Sia_tipide_tide = hclvariabactual.sia_tipide_tide,
                                       Sia_nroide_usua = hclvariabactual.sia_nroide_usua,
                                       Hcl_fecges_hcva = (DateTime)hclvariabactual.hcl_fecges_hcva,
                                       Hcl_horges_hcva = (Decimal)hclvariabactual.hcl_horges_hcva,
                                       Hcl_auxges_hcva = hclvariabactual.hcl_auxges_hcva,
                                       Sis_estreg_esrg = hclvariabactual.sis_estreg_esrg,
                                       Hcl_secgru_hcgv = hcvr.hcl_secgru_hcgv,
                                       Hcl_ordvis_hcvr = (int)hcvr.hcl_ordvis_hcvr,
                                       Hcl_titulo_hcvr = hcvr.hcl_titulo_hcvr,
                                       Hcl_descri_hcvr = hcvr.hcl_descri_hcvr,
                                       Hcl_tipval_hcvr = hcvr.hcl_tipval_hcvr,
                                       Hcl_valper_hcvr = hcvr.hcl_valper_hcvr,
                                       Hcl_camdig_hcvr = hcvr.hcl_camdig_hcvr,
                                       Hcl_ranini_hcvr = hcvr.hcl_ranini_hcvr,
                                       Hcl_ranfin_hcvr = hcvr.hcl_ranfin_hcvr,
                                       Hcl_raninr_hcvr = hcvr.hcl_raninr_hcvr,
                                       Hcl_ranfnr_hcvr = hcvr.hcl_ranfnr_hcvr,
                                       Hcl_nivvar_hcvr = hcvr.hcl_nivvar_hcvr,
                                       Hcl_sistem_hcvr = hcvr.hcl_sistem_hcvr,
                                       Hcl_sisvar_hcvr = hcvr.hcl_sisvar_hcvr,

                                   }).FirstOrDefault();
                    #endregion
                }
                // retornar lista 
                return lobConsulta;
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// hclregisevcampo: Lista nombre campos para guardar datos de eventos en archivos historicos
    /// </summary>
    public class ModeloHclregisevcampo : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_nomcam_hccm: Nombre campo
        private String _hcl_nomcam_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Nombre campo</para>
        /// <para>NOMBRE: hcl_nomcam_hccm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Nombre del campo en la base de datos ejemplo: HCL_TXT018_HCTX
        /// </para>
        /// </summary>
        public String Hcl_nomcam_hccm
        {
            get { return _hcl_nomcam_hccm; }
            set
            {
                if (_hcl_nomcam_hccm == value) return;
                _hcl_nomcam_hccm = value;
                OnPropertyChanged("Hcl_nomcam_hccm");
            }
        }
        #endregion
        #region Hcl_dattip_hccm: Tipo dato
        private String _hcl_dattip_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Tipo dato</para>
        /// <para>NOMBRE: hcl_dattip_hccm (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Tipo dato que contiene: CHAR, DATE, NUMERICO y otros.
        /// </para>
        /// </summary>
        public String Hcl_dattip_hccm
        {
            get { return _hcl_dattip_hccm; }
            set
            {
                if (_hcl_dattip_hccm == value) return;
                _hcl_dattip_hccm = value;
                OnPropertyChanged("Hcl_dattip_hccm");
            }
        }
        #endregion
        #region Hcl_datanc_hccm: Ancho del campo
        private String _hcl_datanc_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Ancho del campo</para>
        /// <para>NOMBRE: hcl_datanc_hccm (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Ancho del campo en caracteres según tipo 
        /// </para>
        /// </summary>
        public String Hcl_datanc_hccm
        {
            get { return _hcl_datanc_hccm; }
            set
            {
                if (_hcl_datanc_hccm == value) return;
                _hcl_datanc_hccm = value;
                OnPropertyChanged("Hcl_datanc_hccm");
            }
        }
        #endregion
        #region Adm_datdec_hccm: Cantidad decimales
        private String _adm_datdec_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Cantidad decimales</para>
        /// <para>NOMBRE: adm_datdec_hccm (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero de caracteres decimales para tipo de datos mumericos,
        /// flotantes y otros
        /// </para>
        /// </summary>
        public String Adm_datdec_hccm
        {
            get { return _adm_datdec_hccm; }
            set
            {
                if (_adm_datdec_hccm == value) return;
                _adm_datdec_hccm = value;
                OnPropertyChanged("Adm_datdec_hccm");
            }
        }
        #endregion
        #region Hcl_descri_hccm: Descripcion campo
        private String _hcl_descri_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Descripcion campo</para>
        /// <para>NOMBRE: hcl_descri_hccm (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripcion larga del campo
        /// </para>
        /// </summary>
        public String Hcl_descri_hccm
        {
            get { return _hcl_descri_hccm; }
            set
            {
                if (_hcl_descri_hccm == value) return;
                _hcl_descri_hccm = value;
                OnPropertyChanged("Hcl_descri_hccm");
            }
        }
        #endregion
        #region Hcl_titulo_hccm: Titulo campo
        private String _hcl_titulo_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Titulo campo</para>
        /// <para>NOMBRE: hcl_titulo_hccm (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Titulo corto del campo, para mostrar el listas de selección
        /// </para>
        /// </summary>
        public String Hcl_titulo_hccm
        {
            get { return _hcl_titulo_hccm; }
            set
            {
                if (_hcl_titulo_hccm == value) return;
                _hcl_titulo_hccm = value;
                OnPropertyChanged("Hcl_titulo_hccm");
            }
        }
        #endregion
        #region Hcl_grupos_hccm: Identificador grupo
        private String _hcl_grupos_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Identificador grupo</para>
        /// <para>NOMBRE: hcl_grupos_hccm (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Identificador del grupo de objetos que pueden referenciar el
        /// campo para guardar datos
        /// </para>
        /// </summary>
        public String Hcl_grupos_hccm
        {
            get { return _hcl_grupos_hccm; }
            set
            {
                if (_hcl_grupos_hccm == value) return;
                _hcl_grupos_hccm = value;
                OnPropertyChanged("Hcl_grupos_hccm");
            }
        }
        #endregion
        #region Hcl_idecam_hccm: Identificador campo
        private String _hcl_idecam_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Identificador campo</para>
        /// <para>NOMBRE: hcl_idecam_hccm (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Numero de orden o identificador del campo o campos cuando se
        /// guardan valores compuestos, codigos y campos descripcion que
        /// conservan una relacion estrecha.
        /// </para>
        /// </summary>
        public String Hcl_idecam_hccm
        {
            get { return _hcl_idecam_hccm; }
            set
            {
                if (_hcl_idecam_hccm == value) return;
                _hcl_idecam_hccm = value;
                OnPropertyChanged("Hcl_idecam_hccm");
            }
        }
        #endregion
        #region Hcl_tipcam_hccm: Tipo campo
        private String _hcl_tipcam_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Tipo campo</para>
        /// <para>NOMBRE: hcl_tipcam_hccm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Tipo campo según relacion con datos compuestos guardados, para
        /// saber si el dato es el codigo o la descripcion de un dato guardado
        /// o talvez la ruta de un recurso, etc. Ejemplo: VALOR, CODIGO,
        /// DESCRIPCION… Y OTROS
        /// </para>
        /// </summary>
        public String Hcl_tipcam_hccm
        {
            get { return _hcl_tipcam_hccm; }
            set
            {
                if (_hcl_tipcam_hccm == value) return;
                _hcl_tipcam_hccm = value;
                OnPropertyChanged("Hcl_tipcam_hccm");
            }
        }
        #endregion
        #region Hcl_nomarc_hccm: Archivo historico
        private String _hcl_nomarc_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Archivo historico</para>
        /// <para>NOMBRE: hcl_nomarc_hccm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Nombre del archivo historico al cual pertence el campo ejemplo:
        /// HCLREGISEXTXA,HCLREGISEXFEC y otros
        /// </para>
        /// </summary>
        public String Hcl_nomarc_hccm
        {
            get { return _hcl_nomarc_hccm; }
            set
            {
                if (_hcl_nomarc_hccm == value) return;
                _hcl_nomarc_hccm = value;
                OnPropertyChanged("Hcl_nomarc_hccm");
            }
        }
        #endregion
        #region Hcl_ordvis_hccm: Orden vista campos
        private int _hcl_ordvis_hccm;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Orden vista campos</para>
        /// <para>NOMBRE: hcl_ordvis_hccm (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Orden vista secuencial de  la lista de campos
        /// </para>
        /// </summary>
        public int Hcl_ordvis_hccm
        {
            get { return _hcl_ordvis_hccm; }
            set
            {
                if (_hcl_ordvis_hccm == value) return;
                _hcl_ordvis_hccm = value;
                OnPropertyChanged("Hcl_ordvis_hccm");
            }
        }
        #endregion
        #region Grp_nomobj_grob: Nombre del objeto segun plantilla 
        private String _grp_nomobj_grob;
        /// <summary>
        /// <para>TABLA: Temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Nombre del objeto </para>
        /// <para>NOMBRE: Grp_nomobj_grob (Char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION: Nombre del objeto que tiene relacionado el campo de tabla</para>
        /// <para>"NA" = Por defecto no hay objeto</para>
        /// </summary>
        public String Grp_nomobj_grob
        {
            get { return _grp_nomobj_grob; }
            set
            {
                if (_grp_nomobj_grob == value) return;
                _grp_nomobj_grob = value;
                OnPropertyChanged("Grp_nomobj_grob");
            }
        }
        #endregion
        #region Hcl_relobj_hccm: Campo relacionado con un objeto
        private String _hcl_relobj_hccm;
        /// <summary>
        /// <para>TABLA: Temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Orden vista campos</para>
        /// <para>NOMBRE: hcl_ordvis_hccm (Char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Marca para saber que el Campo esta relacionado con un objeto "1"=Relacionado/Asignado "2"=Libre
        /// </para>
        /// </summary>
        public String Hcl_relobj_hccm
        {
            get { return _hcl_relobj_hccm; }
            set
            {
                if (_hcl_relobj_hccm == value) return;
                _hcl_relobj_hccm = value;
                OnPropertyChanged("Hcl_relobj_hccm");
            }
        }
        #endregion
        #region Sis_estreg_esrg: Código Estado Registro
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Sis_estreg_esrg
        {
            get { return _sis_estreg_esrg; }
            set
            {
                if (_sis_estreg_esrg == value) return;
                _sis_estreg_esrg = value;
                OnPropertyChanged("Sis_estreg_esrg");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloHclregisevcampo tobjModelo)
        {
            var lcrCodigoGen = string.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFhclregisevcampo
                    {
                        #region cargar Registro
                        hcl_nomcam_hccm = tobjModelo.Hcl_nomcam_hccm,
                        hcl_dattip_hccm = tobjModelo.Hcl_dattip_hccm,
                        hcl_datanc_hccm = tobjModelo.Hcl_datanc_hccm,
                        adm_datdec_hccm = tobjModelo.Adm_datdec_hccm,
                        hcl_descri_hccm = tobjModelo.Hcl_descri_hccm,
                        hcl_titulo_hccm = tobjModelo.Hcl_titulo_hccm,
                        hcl_grupos_hccm = tobjModelo.Hcl_grupos_hccm,
                        hcl_idecam_hccm = tobjModelo.Hcl_idecam_hccm,
                        hcl_tipcam_hccm = tobjModelo.Hcl_tipcam_hccm,
                        hcl_nomarc_hccm = tobjModelo.Hcl_nomarc_hccm,
                        hcl_ordvis_hccm = tobjModelo.Hcl_ordvis_hccm,
                        sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.hcl_nomcam_hccm;
                    _context.AddToHclregisevcampo(lobjRegistro);
                    _context.SaveChanges();
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
        public static void fcvActualizar(ModeloHclregisevcampo tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclregisevcampo.FirstOrDefault(p => p.hcl_nomcam_hccm == tobjModelo.Hcl_nomcam_hccm);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.hcl_nomcam_hccm = tobjModelo.Hcl_nomcam_hccm;
                        lobjRegistro.hcl_dattip_hccm = tobjModelo.Hcl_dattip_hccm;
                        lobjRegistro.hcl_datanc_hccm = tobjModelo.Hcl_datanc_hccm;
                        lobjRegistro.adm_datdec_hccm = tobjModelo.Adm_datdec_hccm;
                        lobjRegistro.hcl_descri_hccm = tobjModelo.Hcl_descri_hccm;
                        lobjRegistro.hcl_titulo_hccm = tobjModelo.Hcl_titulo_hccm;
                        lobjRegistro.hcl_grupos_hccm = tobjModelo.Hcl_grupos_hccm;
                        lobjRegistro.hcl_idecam_hccm = tobjModelo.Hcl_idecam_hccm;
                        lobjRegistro.hcl_tipcam_hccm = tobjModelo.Hcl_tipcam_hccm;
                        lobjRegistro.hcl_nomarc_hccm = tobjModelo.Hcl_nomarc_hccm;
                        lobjRegistro.hcl_ordvis_hccm = (int)tobjModelo.Hcl_ordvis_hccm;
                        lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
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
                    var lobjRegistro = _context.Hclregisevcampo.FirstOrDefault(p => p.hcl_nomcam_hccm == tcrCodigo);
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
        #region Buscar HCLREGISEVCAMPO: Logica
        /// <summary>
        /// <para>TABLA: hclregisevcampo</para>
        /// <para>TITULO: Maestro lista nombre campos estructura historicos datos even</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro lista nombre campos que son relacionados con objetos
        /// en formatos de H.C. para guardar datos digitados en archivos
        /// historicos de eventos ejemplo:  HCL_TXT018_HCTX, HCL_CBO015_HCCB…
        /// </para>
        /// </summary>
        public static bool flgBuscarHclregisevcampo(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclregisevcampo.FirstOrDefault(p => p.hcl_nomcam_hccm == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHclregisevcampo> flsListaHclregisevcampo(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from hclregisevcampo in _context.Hclregisevcampo
                                    select new ModeloHclregisevcampo
                                    {
                                        Hcl_nomcam_hccm = hclregisevcampo.hcl_nomcam_hccm,
                                        Hcl_dattip_hccm = hclregisevcampo.hcl_dattip_hccm,
                                        Hcl_datanc_hccm = hclregisevcampo.hcl_datanc_hccm,
                                        Adm_datdec_hccm = hclregisevcampo.adm_datdec_hccm,
                                        Hcl_descri_hccm = hclregisevcampo.hcl_descri_hccm,
                                        Hcl_titulo_hccm = hclregisevcampo.hcl_titulo_hccm,
                                        Hcl_grupos_hccm = hclregisevcampo.hcl_grupos_hccm,
                                        Hcl_idecam_hccm = hclregisevcampo.hcl_idecam_hccm,
                                        Hcl_tipcam_hccm = hclregisevcampo.hcl_tipcam_hccm,
                                        Hcl_nomarc_hccm = hclregisevcampo.hcl_nomarc_hccm,
                                        Hcl_ordvis_hccm = (int)hclregisevcampo.hcl_ordvis_hccm,
                                        Sis_estreg_esrg = hclregisevcampo.sis_estreg_esrg,
                                        Grp_nomobj_grob = "NA",
                                        Hcl_relobj_hccm = "2",
                                    };
                	return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hclregisevcampo in _context.Hclregisevcampo
                                    where hclregisevcampo.hcl_nomcam_hccm == tcrBuscar
                                    select new ModeloHclregisevcampo
                                    {
                                        Hcl_nomcam_hccm = hclregisevcampo.hcl_nomcam_hccm,
                                        Hcl_dattip_hccm = hclregisevcampo.hcl_dattip_hccm,
                                        Hcl_datanc_hccm = hclregisevcampo.hcl_datanc_hccm,
                                        Adm_datdec_hccm = hclregisevcampo.adm_datdec_hccm,
                                        Hcl_descri_hccm = hclregisevcampo.hcl_descri_hccm,
                                        Hcl_titulo_hccm = hclregisevcampo.hcl_titulo_hccm,
                                        Hcl_grupos_hccm = hclregisevcampo.hcl_grupos_hccm,
                                        Hcl_idecam_hccm = hclregisevcampo.hcl_idecam_hccm,
                                        Hcl_tipcam_hccm = hclregisevcampo.hcl_tipcam_hccm,
                                        Hcl_nomarc_hccm = hclregisevcampo.hcl_nomarc_hccm,
                                        Hcl_ordvis_hccm = (int)hclregisevcampo.hcl_ordvis_hccm,
                                        Sis_estreg_esrg = hclregisevcampo.sis_estreg_esrg,
                                        Grp_nomobj_grob = "NA",
                                        Hcl_relobj_hccm = "2",
                                    };
                	return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// grpplantvistsec: Mestro secciones objetos para organización vista formato plantilla H.C
    /// </summary>
    public class ModeloGrpplantvistsec : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Grp_idesec_grse: Codigo del registro
        /// <summary>
        /// <para>TABLA: grpplantvistsec</para>
        /// <para>TABLA NATIVA: grpplantvistsec</para>
        /// <para>CAMPO: Codigo del registro</para>
        /// <para>NOMBRE: grp_idesec_grse (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codgo registro GRP_IDEPLA_GRPV + R +GRP_CODSEC_GRSE
        /// </para>
        /// </summary>
        public String Grp_idesec_grse = String.Empty;
        #endregion
        #region Grp_idepla_grpv: Código version plantilla
        /// <summary>
        /// <para>TABLA: grpplantvistsec</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Código version plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de la version plantilla (generado por el
        /// sistema)
        /// </para>
        /// </summary>
        public String Grp_idepla_grpv = String.Empty;
        #endregion
        #region Grp_idepla_grpl: Código único plantilla
        /// <summary>
        /// <para>TABLA: grpplantvistsec</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de la plantilla  base
        /// </para>
        /// </summary>
        public String Grp_idepla_grpl = String.Empty;
        #endregion
        #region Grp_codsec_grse: Codgo seccion
        /// <summary>
        /// <para>TABLA: grpplantvistsec</para>
        /// <para>TABLA NATIVA: grpplantvistsec</para>
        /// <para>CAMPO: Codgo seccion</para>
        /// <para>NOMBRE: grp_codsec_grse (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo seccion de las diferentes secciones creadas en el formato,
        /// en cada formato existe la seccion por defecto  NA= General
        /// </para>
        /// </summary>
        public String Grp_codsec_grse = String.Empty;
        #endregion
        #region Grp_dessec_grse: Descripción seccion
        /// <summary>
        /// <para>TABLA: grpplantvistsec</para>
        /// <para>TABLA NATIVA: grpplantvistsec</para>
        /// <para>CAMPO: Descripción seccion</para>
        /// <para>NOMBRE: grp_dessec_grse (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual o titulo de la seccion
        /// </para>
        /// </summary>
        public String Grp_dessec_grse = String.Empty;
        #endregion
        #region Grp_ordvis_grse: Orden Vizaulizacion
        /// <summary>
        /// <para>TABLA: grpplantvistsec</para>
        /// <para>TABLA NATIVA: grpplantvistsec</para>
        /// <para>CAMPO: Orden Vizaulizacion</para>
        /// <para>NOMBRE: grp_ordvis_grse (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion de la seccion en informes
        /// </para>
        /// </summary>
        public int Grp_ordvis_grse = 0;
        #endregion
        #region Grp_numcol_grse: Numero columnas
        /// <summary>
        /// <para>TABLA: grpplantvistsec</para>
        /// <para>TABLA NATIVA: grpplantvistsec</para>
        /// <para>CAMPO: Numero columnas</para>
        /// <para>NOMBRE: grp_numcol_grse (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Numero de columnas en la vista de informe
        /// </para>
        /// </summary>
        public int Grp_numcol_grse = 0;
        #endregion
        #region Grp_titvis_grse: Titulo visble SI/NO
        /// <summary>
        /// <para>TABLA: grpplantvistsec</para>
        /// <para>TABLA NATIVA: grpplantvistsec</para>
        /// <para>CAMPO: Titulo visble SI/NO</para>
        /// <para>NOMBRE: grp_titvis_grse (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Titulo de la seccion es visible en informe impreso: 1= Si es
        /// visible 2=No es visible
        /// </para>
        /// </summary>
        public String Grp_titvis_grse = String.Empty;
        #endregion
        #region Sis_estado_imaen: Gestion registro
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: Sis_estado_imaen (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: IMAEN </para>
        /// </summary>
        public String Sis_estado_imaen = "I";
        #endregion
        #region Grp_despla_grpl: Nombre plantilla
        /// <summary>
        /// <para>TABLA: grpplantvistsec</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public String Grp_despla_grpl = String.Empty;
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Agregar o Actualizar secciones version plantillas
        /// <summary>
        /// Agregar o Actualizar secciones version plantillas
        /// </summary>
        public static void fcvActualizar(ModeloGrpplantvistsec tobjModelo, String tcrCodigoR1)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFgrpplantvistsec();
                    //-----------------------
                    if (tobjModelo.Sis_estado_imaen == "M")
                    {
                        lobjRegistro = _context.Grpplantvistsec.FirstOrDefault(p => p.grp_idesec_grse == tobjModelo.Grp_idesec_grse);
                    }
                    if (tobjModelo.Sis_estado_imaen == "A" || tobjModelo.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobjRegistro != null)
                        {
                            #region cargar Registro
                            lobjRegistro.grp_idesec_grse = tobjModelo.Grp_idesec_grse;
                            lobjRegistro.grp_idepla_grpv = tobjModelo.Grp_idepla_grpv;
                            lobjRegistro.grp_idepla_grpl = tobjModelo.Grp_idepla_grpl;
                            lobjRegistro.grp_codsec_grse = tobjModelo.Grp_codsec_grse;
                            lobjRegistro.grp_dessec_grse = tobjModelo.Grp_dessec_grse;
                            lobjRegistro.grp_ordvis_grse = (int)tobjModelo.Grp_ordvis_grse;
                            lobjRegistro.grp_numcol_grse = (int)tobjModelo.Grp_numcol_grse;
                            lobjRegistro.grp_titvis_grse = tobjModelo.Grp_titvis_grse;
                            #endregion
                        }
                        #endregion
                    }
                    //---------------------------
                    // Guardar cambios o eliminar
                    //---------------------------
                    if (lobjRegistro != null)
                    {
                        switch (tobjModelo.Sis_estado_imaen)
                        {
                            case "A": // Adicionar el registro
                                lobjRegistro.grp_idesec_grse = tcrCodigoR1 + lobjRegistro.grp_idesec_grse; // concatenar
                                _context.AddToGrpplantvistsec(lobjRegistro);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                lobjRegistro = _context.Grpplantvistsec.FirstOrDefault(p => p.grp_idesec_grse == tobjModelo.Grp_idesec_grse);
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
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: ModeloGrpplantvistsec.fcvActualizar");
            }
        }
        #endregion
        #region Eliminar registro
        /// <summary>
        /// Eliminar todos los registros que corresponden a una version plantilla
        /// </summary>
        /// <param name="tcrCodigoVersionPlantilla">Codigo del a version plantilla para eliminar registros</param>
        public static void fcvEliminar(String tcrCodigoVersionPlantilla)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobTmpRegistro = (from tmp in _context.Grpplantvistsec where tmp.grp_idepla_grpv == tcrCodigoVersionPlantilla select tmp).ToList();
                    if (lobTmpRegistro != null && lobTmpRegistro.Count != 0)
                    {
                        foreach (var lobjRegistro in lobTmpRegistro)
                        {
                            _context.DeleteObject(lobjRegistro);
                        }
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
        #region Listar Registros
        /// <summary>
        /// Cargar lista de grupos de una version plantilla en particular
        /// </summary>
        /// <param name="tcrCodigoVersPlantilla">Codigo de la version plantilla a consultar</param>
        /// <returns>Retorna un listado con las secciones creadas en la verion plantilla dada en parametro</returns>
        public static List<ModeloGrpplantvistsec> flsListaGrpplantvistsec(String tcrCodigoVersPlantilla)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from grpplantvistsec in _context.Grpplantvistsec
                                  where grpplantvistsec.grp_idepla_grpv == tcrCodigoVersPlantilla
                                  select new ModeloGrpplantvistsec
                                  {
                                      #region Datos
                                      Grp_idesec_grse = grpplantvistsec.grp_idesec_grse,
                                      Grp_idepla_grpv = grpplantvistsec.grp_idepla_grpv,
                                      Grp_idepla_grpl = grpplantvistsec.grp_idepla_grpl,
                                      Grp_codsec_grse = grpplantvistsec.grp_codsec_grse,
                                      Grp_dessec_grse = grpplantvistsec.grp_dessec_grse,
                                      Grp_ordvis_grse = (int)grpplantvistsec.grp_ordvis_grse,
                                      Grp_numcol_grse = (int)grpplantvistsec.grp_numcol_grse,
                                      Grp_titvis_grse = grpplantvistsec.grp_titvis_grse,
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// grpplantvistcam: Mestro lista objetos de captura y campos de vista formato H.C
    /// </summary>
    public class ModeloGrpplantvistcam : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Grp_idereg_grob: Codigo del registro
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpplantvistcam</para>
        /// <para>CAMPO: Codigo del registro</para>
        /// <para>NOMBRE: grp_idereg_grob (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codgo registro GRP_IDEPLA_GRPV + R + Contador_de_objetos
        /// </para>
        /// </summary>
        public String Grp_idereg_grob = String.Empty;
        #endregion
        #region Grp_idepla_grpv: Código version plantilla
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpmaeversplant</para>
        /// <para>CAMPO: Código version plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpv (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de la version plantilla (generado por el
        /// sistema)
        /// </para>
        /// </summary>
        public String Grp_idepla_grpv = String.Empty;
        #endregion
        #region Grp_idepla_grpl: Código único plantilla
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de la plantilla  base
        /// </para>
        /// </summary>
        public String Grp_idepla_grpl = String.Empty;
        #endregion
        #region Grp_nomobj_grob: Nombre del objeto
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpplantvistcam</para>
        /// <para>CAMPO: Nombre del objeto</para>
        /// <para>NOMBRE: grp_nomobj_grob (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Nombre interno del objeto en el formato diseñado desde el editor
        /// ejemplo:  txtTextBoxEX153, cboComboBoxEX25 y otros
        /// </para>
        /// </summary>
        public String Grp_nomobj_grob = String.Empty;
        #endregion
        #region Grp_desobj_grob: Titulo objeto
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpplantvistcam</para>
        /// <para>CAMPO: Titulo objeto</para>
        /// <para>NOMBRE: grp_desobj_grob (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual o titulo del objeto
        /// </para>
        /// </summary>
        public String Grp_desobj_grob = String.Empty;
        #endregion
        #region Grp_varobj_grob: Variable del objeto
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpplantvistcam</para>
        /// <para>CAMPO: Variable del objeto</para>
        /// <para>NOMBRE: grp_varobj_grob (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Nombre de la variable que acompaña al objeto en el diseño del
        /// formato
        /// </para>
        /// </summary>
        public String Grp_varobj_grob = String.Empty;
        #endregion
        #region Grp_claseb_grob: Clase base del objeto
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpplantvistcam</para>
        /// <para>CAMPO: Clase base del objeto</para>
        /// <para>NOMBRE: grp_claseb_grob (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Clase base nativa (C.NET) del objeto ejemplo: TextBox, ComboBox,
        /// DateTime,UserControl y otros
        /// </para>
        /// </summary>
        public String Grp_claseb_grob = String.Empty;
        #endregion
        #region Grp_claseg_grob: Clase base gestion vista
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpplantvistcam</para>
        /// <para>CAMPO: Clase base gestion vista</para>
        /// <para>NOMBRE: grp_claseg_grob (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Clase gestion vista objeto ejemplo: TextBoxFecha, ListComboBox,
        /// TextBoxDateTime,UserControlAdmision  y otros
        /// </para>
        /// </summary>
        public String Grp_claseg_grob = String.Empty;
        #endregion
        #region Grp_codsec_grse: Codgo seccion
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpplantvistsec</para>
        /// <para>CAMPO: Codgo seccion</para>
        /// <para>NOMBRE: grp_codsec_grse (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo seccion a la cual pertenece el objeto dentro de las
        /// diferentes secciones creadas en el formato
        /// </para>
        /// </summary>
        public String Grp_codsec_grse = String.Empty;
        #endregion
        #region Grp_ordvis_grob: Orden Vizaulizacion
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpplantvistcam</para>
        /// <para>CAMPO: Orden Vizaulizacion</para>
        /// <para>NOMBRE: grp_ordvis_grob (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Orden visualizacion del objeto dentro de  la seccion en informes
        /// </para>
        /// </summary>
        public int Grp_ordvis_grob = 0;
        #endregion
        #region Hcl_nomcam_hccm: Campo base de datos
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Campo base de datos</para>
        /// <para>NOMBRE: hcl_nomcam_hccm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Nombre del campo en la base de datos donde se guardaran los
        /// datos capturados desde el objeto, ejemplo: HCL_TXT018_HCTX,
        /// es un campo texto corto (char 130)  en el maestro HCLREGISEXTXA.
        /// </para>
        /// </summary>
        public String Hcl_nomcam_hccm = String.Empty;
        #endregion
        #region Hcl_camdes_hccm: Campo descripcion
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Campo descripcion</para>
        /// <para>NOMBRE: hcl_camdes_hccm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Opcional - Nombre del campo descripcion en la base de datos
        /// donde se guardaran las decripciones del campo codigo, para
        /// Combobox TextBoxRel y otros
        /// </para>
        /// </summary>
        public String Hcl_camdes_hccm = String.Empty;
        #endregion
        #region Hcl_nomvar_hcvr: Nombre variable publica
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Nombre variable publica</para>
        /// <para>NOMBRE: hcl_nomvar_hcvr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Nombre unico identificador de la variable publica, para referencia
        /// dentro del sistema, este nombre debe incluir nombre identificador
        /// del grupo al que pertenece, ejemplo variables : VACUNACION_NIÑO_DPT_DOSIS
        /// 1, JOVEN_PLANIFICACION_SI_NO
        /// </para>
        /// </summary>
        public String Hcl_nomvar_hcvr = String.Empty;
        #endregion
        #region Grp_repcam_grob: Tipo campo reporte
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpplantvistcam</para>
        /// <para>CAMPO: Tipo campo reporte</para>
        /// <para>NOMBRE: grp_repcam_grob (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo uso que se puede hacer con el  campo para generacion de
        /// reporte: 1= Solo Reporte 2=Reporte y Estadisticas 3= Solo Estadisticas
        /// 4 =Ninguno
        /// </para>
        /// </summary>
        public String Grp_repcam_grob = String.Empty;
        #endregion
        #region Grp_despla_grpl: Nombre plantilla
        /// <summary>
        /// <para>TABLA: grpplantvistcam</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public String Grp_despla_grpl = String.Empty;
        #endregion
        #region Sis_estado_imaen: Gestion registro
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Campo para gestion edicion</para>
        /// <para>NOMBRE: Sis_estado_imaen (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: IMAEN </para>
        /// </summary>
        public String Sis_estado_imaen = "I";
        #endregion
        #region Grp_dessec_grse: Descripción seccion
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: grpplantvistsec</para>
        /// <para>CAMPO: Descripción seccion</para>
        /// <para>NOMBRE: grp_dessec_grse (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual o titulo de la seccion
        /// </para>
        /// </summary>
        public String Grp_dessec_grse = String.Empty;
        #endregion
        #region Grp_ordvis_grse: Orden Vizaulizacion
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: grpplantvistsec</para>
        /// <para>CAMPO: Orden Vizaulizacion</para>
        /// <para>NOMBRE: grp_ordvis_grse (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion de la seccion en informes
        /// </para>
        /// </summary>
        public int Grp_ordvis_grse = 0;

        #endregion
        #region Hcl_nomarc_hccm: Archivo historico
        private String _hcl_nomarc_hccm;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Archivo historico</para>
        /// <para>NOMBRE: hcl_nomarc_hccm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Nombre del archivo historico al cual pertence el campo ejemplo:
        /// HCLREGISEXTXA,HCLREGISEXFEC y otros
        /// </para>
        /// </summary>
        public String Hcl_nomarc_hccm
        {
            get { return _hcl_nomarc_hccm; }
            set
            {
                if (_hcl_nomarc_hccm == value) return;
                _hcl_nomarc_hccm = value;
                OnPropertyChanged("Hcl_nomarc_hccm");
            }
        }
        #endregion
        #region Hcl_ordvis_hccm: Orden vista campos
        private int _hcl_ordvis_hccm;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Orden vista campos</para>
        /// <para>NOMBRE: hcl_ordvis_hccm (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Orden vista secuencial de  la lista de campos
        /// </para>
        /// </summary>
        public int Hcl_ordvis_hccm
        {
            get { return _hcl_ordvis_hccm; }
            set
            {
                if (_hcl_ordvis_hccm == value) return;
                _hcl_ordvis_hccm = value;
                OnPropertyChanged("Hcl_ordvis_hccm");
            }
        }
        #endregion
        #region Hcl_grupos_hccm: Identificador grupo
        private String _hcl_grupos_hccm;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: hclregisevcampo</para>
        /// <para>CAMPO: Identificador grupo</para>
        /// <para>NOMBRE: hcl_grupos_hccm (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Identificador del grupo de objetos que pueden referenciar el
        /// campo para guardar datos
        /// </para>
        /// </summary>
        public String Hcl_grupos_hccm
        {
            get { return _hcl_grupos_hccm; }
            set
            {
                if (_hcl_grupos_hccm == value) return;
                _hcl_grupos_hccm = value;
                OnPropertyChanged("Hcl_grupos_hccm");
            }
        }
        #endregion
        // Variables auxiliares codigo Grupos de actividad 
        // y campo 4505 para gestion completar actividades 4505
        #region Ssp_codpro_sspa: Grupo Actividades
        private String _ssp_codpro_sspa;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: spprogramgrupma</para>
        /// <para>CAMPO: Grupo programas</para>
        /// <para>NOMBRE: ssp_codpro_sspa (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Codigo grupos actividades de clasificacion 4505 Adulto, Partos, CyD Niños y otras</para>
        /// <para>Esta es una variable auxiliar para gestion 4505</para>
        /// </summary>
        public String Ssp_codpro_sspa
        {
            get { return _ssp_codpro_sspa; }
            set
            {
                if (_ssp_codpro_sspa == value) return;
                _ssp_codpro_sspa = value;
                OnPropertyChanged("Ssp_codpro_sspa");
            }
        }
        #endregion
        #region Ssp_codcam_resc: Campo 4505
        private String _ssp_codcam_resc;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Campo 4505</para>
        /// <para>NOMBRE: ssp_codcam_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION: Campo o nombre (ejemplo: SSP_CAM025_MS45) en historicos resolucion 4505</para>
        /// </summary>
        public String Ssp_codcam_resc
        {
            get { return _ssp_codcam_resc; }
            set
            {
                if (_ssp_codcam_resc == value) return;
                _ssp_codcam_resc = value;
                OnPropertyChanged("Ssp_codcam_resc");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Agregar o Actaulizar campos version plantillas
        /// <summary>
        /// Agregar o Actualizar campos version plantillas
        /// </summary>
        public static void fcvActualizar(ModeloGrpplantvistcam tobjModelo, String tcrCodigoR1)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFgrpplantvistcam();
                    //-----------------------
                    if (tobjModelo.Sis_estado_imaen == "M")
                    {
                        lobjRegistro = _context.Grpplantvistcam.FirstOrDefault(p => p.grp_idereg_grob == tobjModelo.Grp_idereg_grob);
                    }
                    if (tobjModelo.Sis_estado_imaen == "A" || tobjModelo.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobjRegistro != null)
                        {
                            lobjRegistro.grp_idereg_grob = tobjModelo.Grp_idereg_grob;
                            lobjRegistro.grp_idepla_grpv = tobjModelo.Grp_idepla_grpv;
                            lobjRegistro.grp_idepla_grpl = tobjModelo.Grp_idepla_grpl;
                            lobjRegistro.grp_nomobj_grob = tobjModelo.Grp_nomobj_grob;
                            lobjRegistro.grp_desobj_grob = tobjModelo.Grp_desobj_grob;
                            lobjRegistro.grp_varobj_grob = tobjModelo.Grp_varobj_grob;
                            lobjRegistro.grp_claseb_grob = tobjModelo.Grp_claseb_grob;
                            lobjRegistro.grp_claseg_grob = tobjModelo.Grp_claseg_grob;
                            lobjRegistro.grp_codsec_grse = tobjModelo.Grp_codsec_grse;
                            lobjRegistro.grp_ordvis_grob = (int)tobjModelo.Grp_ordvis_grob;
                            lobjRegistro.hcl_nomcam_hccm = tobjModelo.Hcl_nomcam_hccm;
                            lobjRegistro.hcl_camdes_hccm = tobjModelo.Hcl_camdes_hccm;
                            lobjRegistro.hcl_nomvar_hcvr = tobjModelo.Hcl_nomvar_hcvr;
                            lobjRegistro.grp_repcam_grob = tobjModelo.Grp_repcam_grob;
                        }
                        #endregion
                    }
                    //---------------------------
                    // Guardar cambios o eliminar
                    //---------------------------
                    if (lobjRegistro != null)
                    {
                        switch (tobjModelo.Sis_estado_imaen)
                        {
                            case "A": // Adicionar el registro
                                lobjRegistro.grp_idereg_grob = tcrCodigoR1 + lobjRegistro.grp_idereg_grob; // concatenar
                                _context.AddToGrpplantvistcam(lobjRegistro);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                lobjRegistro = _context.Grpplantvistcam.FirstOrDefault(p => p.grp_idereg_grob == tobjModelo.Grp_idereg_grob);
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
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Modelo Error Metodo: ModeloGrpplantvistcam.fcvActualizar");
            }
        }
        #endregion
        #region Eliminar registros
        /// <summary>
        /// Eliminar todos los registros que corresponden a una version plantilla
        /// </summary>
        /// <param name="tcrCodigoVersionPlantilla">Codigo del a version plantilla para eliminar registros</param>
        public static void fcvEliminar(String tcrCodigoVersionPlantilla)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobTmpRegistro = (from tmp in _context.Grpplantvistcam where tmp.grp_idepla_grpv == tcrCodigoVersionPlantilla select tmp).ToList();
                    if (lobTmpRegistro != null && lobTmpRegistro.Count != 0)
                    {
                        foreach (var lobjRegistro in lobTmpRegistro)
                        {
                            _context.DeleteObject(lobjRegistro);
                        }
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
        #region Listar Registros correspodientes a una version plantilla
        /// <summary>
        /// Lista de campos correspodientes a una version plantilla
        /// </summary>
        public static List<ModeloGrpplantvistcam> flsListaGrpplantvistcam(String tcrCodigoVersPlantilla)
        {
            using (_context = new DbAplicacion())
            {
                    var lobConsulta = from grpplantvistcam in _context.Grpplantvistcam
                                      join grpplantvistsec in _context.Grpplantvistsec on grpplantvistcam.grp_codsec_grse equals grpplantvistsec.grp_codsec_grse into tmgrpplantvistsec
                                      join hclregisevcampo in _context.Hclregisevcampo on grpplantvistcam.hcl_nomcam_hccm equals hclregisevcampo.hcl_nomcam_hccm into tmhclregisevcampo
                                      from grsecc in tmgrpplantvistsec.DefaultIfEmpty()
                                      from hccm in tmhclregisevcampo.DefaultIfEmpty()
                                      where grpplantvistcam.grp_idepla_grpv == tcrCodigoVersPlantilla
                                      orderby grsecc.grp_ordvis_grse, grpplantvistcam.grp_ordvis_grob
                                    select new ModeloGrpplantvistcam
                                    {
                                        #region Datos
                                        Grp_idereg_grob = grpplantvistcam.grp_idereg_grob,
                                        Grp_idepla_grpv = grpplantvistcam.grp_idepla_grpv,
                                        Grp_idepla_grpl = grpplantvistcam.grp_idepla_grpl,
                                        Grp_nomobj_grob = grpplantvistcam.grp_nomobj_grob,
                                        Grp_desobj_grob = grpplantvistcam.grp_desobj_grob,
                                        Grp_varobj_grob = grpplantvistcam.grp_varobj_grob,
                                        Grp_claseb_grob = grpplantvistcam.grp_claseb_grob,
                                        Grp_claseg_grob = grpplantvistcam.grp_claseg_grob,
                                        Grp_codsec_grse = grpplantvistcam.grp_codsec_grse,
                                        Grp_ordvis_grob = (int)grpplantvistcam.grp_ordvis_grob,
                                        Hcl_nomcam_hccm = grpplantvistcam.hcl_nomcam_hccm,
                                        Hcl_camdes_hccm = grpplantvistcam.hcl_camdes_hccm,
                                        Hcl_nomvar_hcvr = grpplantvistcam.hcl_nomvar_hcvr,
                                        Grp_repcam_grob = grpplantvistcam.grp_repcam_grob,
                                        Grp_dessec_grse = grsecc.grp_dessec_grse,
                                        Grp_ordvis_grse = (int)grsecc.grp_ordvis_grse,
                                        Hcl_nomarc_hccm = hccm.hcl_nomarc_hccm,
                                        Hcl_grupos_hccm = hccm.hcl_grupos_hccm,
                                        Hcl_ordvis_hccm = (int)hccm.hcl_ordvis_hccm,
                                        #endregion
                                    };
                	return lobConsulta.ToList();
            }
        }
        #endregion
        #region Listar Registros busqueda por tipo llave
        /// <summary>
        /// Lista de campos correspodientes a una version plantilla
        /// <para>PARAMETROS:</para>
        /// <para>tcrTipoCodigo: 1=Nombre Campo 2=Variable Publica  3=Nombre Objeto 4=Variable Objeto</para>
        /// </summary>
        public static ModeloGrpplantvistcam flsListaGrpplantvistcam(String tcrTipoCodigo, String tcrCodigo, String tcrCodigoVersPlantilla)
        {
            ModeloGrpplantvistcam lobRegistro = null;
            using (_context = new DbAplicacion())
            {
                if (tcrTipoCodigo == "1")
                {
                    #region Datos
                    var lobConsulta = (from grpplantvistcam in _context.Grpplantvistcam
                                      join grpplantvistsec in _context.Grpplantvistsec on grpplantvistcam.grp_codsec_grse equals grpplantvistsec.grp_codsec_grse into tmgrpplantvistsec
                                      join hclregisevcampo in _context.Hclregisevcampo on grpplantvistcam.hcl_nomcam_hccm equals hclregisevcampo.hcl_nomcam_hccm into tmhclregisevcampo
                                      from grsecc in tmgrpplantvistsec.DefaultIfEmpty()
                                      from hccm in tmhclregisevcampo.DefaultIfEmpty()
                                       where grpplantvistcam.hcl_nomcam_hccm == tcrCodigo &&
                                             grpplantvistcam.grp_idepla_grpv == tcrCodigoVersPlantilla 
                                      orderby grsecc.grp_ordvis_grse, grpplantvistcam.grp_ordvis_grob
                                      select new ModeloGrpplantvistcam
                                      {
                                          #region Datos
                                          Grp_idereg_grob = grpplantvistcam.grp_idereg_grob,
                                          Grp_idepla_grpv = grpplantvistcam.grp_idepla_grpv,
                                          Grp_idepla_grpl = grpplantvistcam.grp_idepla_grpl,
                                          Grp_nomobj_grob = grpplantvistcam.grp_nomobj_grob,
                                          Grp_desobj_grob = grpplantvistcam.grp_desobj_grob,
                                          Grp_varobj_grob = grpplantvistcam.grp_varobj_grob,
                                          Grp_claseb_grob = grpplantvistcam.grp_claseb_grob,
                                          Grp_claseg_grob = grpplantvistcam.grp_claseg_grob,
                                          Grp_codsec_grse = grpplantvistcam.grp_codsec_grse,
                                          Grp_ordvis_grob = (int)grpplantvistcam.grp_ordvis_grob,
                                          Hcl_nomcam_hccm = grpplantvistcam.hcl_nomcam_hccm,
                                          Hcl_camdes_hccm = grpplantvistcam.hcl_camdes_hccm,
                                          Hcl_nomvar_hcvr = grpplantvistcam.hcl_nomvar_hcvr,
                                          Grp_repcam_grob = grpplantvistcam.grp_repcam_grob,
                                          Grp_dessec_grse = grsecc.grp_dessec_grse,
                                          Grp_ordvis_grse = (int)grsecc.grp_ordvis_grse,
                                          Hcl_nomarc_hccm = hccm.hcl_nomarc_hccm,
                                          Hcl_grupos_hccm = hccm.hcl_grupos_hccm,
                                          Hcl_ordvis_hccm = (int)hccm.hcl_ordvis_hccm,
                                          #endregion
                                      }).ToList().FirstOrDefault();

                    lobRegistro = lobConsulta;
                    #endregion
                }
                else if (tcrTipoCodigo == "2")
                {
                    #region Datos
                    var lobConsulta = (from grpplantvistcam in _context.Grpplantvistcam
                                       join grpplantvistsec in _context.Grpplantvistsec on grpplantvistcam.grp_codsec_grse equals grpplantvistsec.grp_codsec_grse into tmgrpplantvistsec
                                       join hclregisevcampo in _context.Hclregisevcampo on grpplantvistcam.hcl_nomcam_hccm equals hclregisevcampo.hcl_nomcam_hccm into tmhclregisevcampo
                                       from grsecc in tmgrpplantvistsec.DefaultIfEmpty()
                                       from hccm in tmhclregisevcampo.DefaultIfEmpty()
                                       where grpplantvistcam.hcl_nomvar_hcvr == tcrCodigo &&
                                             grpplantvistcam.grp_idepla_grpv == tcrCodigoVersPlantilla
                                       orderby grsecc.grp_ordvis_grse, grpplantvistcam.grp_ordvis_grob
                                       select new ModeloGrpplantvistcam
                                       {
                                           #region Datos
                                           Grp_idereg_grob = grpplantvistcam.grp_idereg_grob,
                                           Grp_idepla_grpv = grpplantvistcam.grp_idepla_grpv,
                                           Grp_idepla_grpl = grpplantvistcam.grp_idepla_grpl,
                                           Grp_nomobj_grob = grpplantvistcam.grp_nomobj_grob,
                                           Grp_desobj_grob = grpplantvistcam.grp_desobj_grob,
                                           Grp_varobj_grob = grpplantvistcam.grp_varobj_grob,
                                           Grp_claseb_grob = grpplantvistcam.grp_claseb_grob,
                                           Grp_claseg_grob = grpplantvistcam.grp_claseg_grob,
                                           Grp_codsec_grse = grpplantvistcam.grp_codsec_grse,
                                           Grp_ordvis_grob = (int)grpplantvistcam.grp_ordvis_grob,
                                           Hcl_nomcam_hccm = grpplantvistcam.hcl_nomcam_hccm,
                                           Hcl_camdes_hccm = grpplantvistcam.hcl_camdes_hccm,
                                           Hcl_nomvar_hcvr = grpplantvistcam.hcl_nomvar_hcvr,
                                           Grp_repcam_grob = grpplantvistcam.grp_repcam_grob,
                                           Grp_dessec_grse = grsecc.grp_dessec_grse,
                                           Grp_ordvis_grse = (int)grsecc.grp_ordvis_grse,
                                           Hcl_nomarc_hccm = hccm.hcl_nomarc_hccm,
                                           Hcl_grupos_hccm = hccm.hcl_grupos_hccm,
                                           Hcl_ordvis_hccm = (int)hccm.hcl_ordvis_hccm,
                                           #endregion
                                       }).ToList().FirstOrDefault();

                    lobRegistro = lobConsulta;
                    #endregion
                }
            }
            return lobRegistro;
        }
        #endregion
        #region Listar todos los Registros correspodientes a todas las versiones plantillas
        /// <summary>
        /// Lista general todos los elementos (campos archivos y variables publicas) de todas las plantillas de Historias clinicas organizadas por version
        /// </summary>
        public static List<ModeloGrpplantvistcam> flsListaGrpplantvistcamTodas()
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from grpplantvistcam in _context.Grpplantvistcam
                                  join hclregisevcampo in _context.Hclregisevcampo on grpplantvistcam.hcl_nomcam_hccm equals hclregisevcampo.hcl_nomcam_hccm into tmhclregisevcampo
                                  from hccm in tmhclregisevcampo.DefaultIfEmpty()
                                  orderby grpplantvistcam.grp_idepla_grpv, grpplantvistcam.grp_ordvis_grob
                                  select new ModeloGrpplantvistcam
                                  {
                                      #region Datos
                                      Grp_idereg_grob = grpplantvistcam.grp_idereg_grob,
                                      Grp_idepla_grpv = grpplantvistcam.grp_idepla_grpv,
                                      Grp_idepla_grpl = grpplantvistcam.grp_idepla_grpl,
                                      Grp_nomobj_grob = grpplantvistcam.grp_nomobj_grob,
                                      Grp_desobj_grob = grpplantvistcam.grp_desobj_grob,
                                      Grp_varobj_grob = grpplantvistcam.grp_varobj_grob,
                                      Grp_claseb_grob = grpplantvistcam.grp_claseb_grob,
                                      Grp_claseg_grob = grpplantvistcam.grp_claseg_grob,
                                      Grp_codsec_grse = grpplantvistcam.grp_codsec_grse,
                                      Grp_ordvis_grob = (int)grpplantvistcam.grp_ordvis_grob,
                                      Hcl_nomcam_hccm = grpplantvistcam.hcl_nomcam_hccm,
                                      Hcl_camdes_hccm = grpplantvistcam.hcl_camdes_hccm,
                                      Hcl_nomvar_hcvr = grpplantvistcam.hcl_nomvar_hcvr,
                                      Grp_repcam_grob = grpplantvistcam.grp_repcam_grob,
                                      Hcl_nomarc_hccm = hccm.hcl_nomarc_hccm,
                                      Hcl_grupos_hccm = hccm.hcl_grupos_hccm,
                                      Hcl_ordvis_hccm = (int)hccm.hcl_ordvis_hccm,
                                      #endregion
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// hcltiporegturno: Maestro turnos de atencion medica
    /// </summary>
    public class ModeloHcltiporegturno : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Hcl_tiptur_hctu: Codigo turno
        private String _hcl_tiptur_hctu;
        /// <summary>
        /// <para>TABLA: hcltiporegturno</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Codigo turno</para>
        /// <para>NOMBRE: hcl_tiptur_hctu (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion turnos diarios para la prestacion de servicios
        /// medicos
        /// </para>
        /// </summary>
        public String Hcl_tiptur_hctu
        {
            get { return _hcl_tiptur_hctu; }
            set
            {
                if (_hcl_tiptur_hctu == value) return;
                _hcl_tiptur_hctu = value;
                OnPropertyChanged("Hcl_tiptur_hctu");
            }
        }
        #endregion
        #region Hcl_destur_hctu: Descripcion turno
        private String _hcl_destur_hctu;
        /// <summary>
        /// <para>TABLA: hcltiporegturno</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Descripcion turno</para>
        /// <para>NOMBRE: hcl_destur_hctu (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion clasificacion turnos diarios
        /// </para>
        /// </summary>
        public String Hcl_destur_hctu
        {
            get { return _hcl_destur_hctu; }
            set
            {
                if (_hcl_destur_hctu == value) return;
                _hcl_destur_hctu = value;
                OnPropertyChanged("Hcl_destur_hctu");
            }
        }
        #endregion
        #region Hcl_horini_hctu: Hora inicio
        private Decimal _hcl_horini_hctu;
        /// <summary>
        /// <para>TABLA: hcltiporegturno</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Hora inicio</para>
        /// <para>NOMBRE: hcl_horini_hctu (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Hora inicio del turno en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_horini_hctu
        {
            get { return _hcl_horini_hctu; }
            set
            {
                if (_hcl_horini_hctu == value) return;
                _hcl_horini_hctu = value;
                OnPropertyChanged("Hcl_horini_hctu");
            }
        }
        #endregion
        #region Hcl_horfin_hctu: Hora fin
        private Decimal _hcl_horfin_hctu;
        /// <summary>
        /// <para>TABLA: hcltiporegturno</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Hora fin</para>
        /// <para>NOMBRE: hcl_horfin_hctu (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Hora fin del turno en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Hcl_horfin_hctu
        {
            get { return _hcl_horfin_hctu; }
            set
            {
                if (_hcl_horfin_hctu == value) return;
                _hcl_horfin_hctu = value;
                OnPropertyChanged("Hcl_horfin_hctu");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloHcltiporegturno tobjModelo)
        {
            var lcrCodigoGen = String.Empty;
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFhcltiporegturno
                    {
                        #region cargar Registro
                        hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu,
                        hcl_destur_hctu = tobjModelo.Hcl_destur_hctu,
                        hcl_horini_hctu = tobjModelo.Hcl_horini_hctu,
                        hcl_horfin_hctu = tobjModelo.Hcl_horfin_hctu,
                        #endregion
                    };
                    lcrCodigoGen = lobjRegistro.hcl_tiptur_hctu;
                    _context.AddToHcltiporegturno(lobjRegistro);
                    _context.SaveChanges();
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
        public static void fcvActualizar(ModeloHcltiporegturno tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hcltiporegturno.FirstOrDefault(p => p.hcl_tiptur_hctu == tobjModelo.Hcl_tiptur_hctu);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.hcl_tiptur_hctu = tobjModelo.Hcl_tiptur_hctu;
                        lobjRegistro.hcl_destur_hctu = tobjModelo.Hcl_destur_hctu;
                        lobjRegistro.hcl_horini_hctu = (Decimal)tobjModelo.Hcl_horini_hctu;
                        lobjRegistro.hcl_horfin_hctu = (Decimal)tobjModelo.Hcl_horfin_hctu;
                        #endregion
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
        public static void fcvEliminar(String tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hcltiporegturno.FirstOrDefault(p => p.hcl_tiptur_hctu == tcrCodigo);
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
        #region Buscar HCLTIPOREGTURNO: Logica
        /// <summary>
        /// <para>TABLA: hcltiporegturno</para>
        /// <para>TITULO: Tipo registro turnos diarios prestacion de servicios medicos</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo registro turnos diarios prestacion de servicios medicos:
        /// T01=MAÑANA T02 = TARDE T03 = NOCHE
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltiporegturno(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegturno.FirstOrDefault(p => p.hcl_tiptur_hctu == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar turno por hora de atencion medica
        /// <summary>
        /// Devuelve un registro de la tabla Hcltiporegturno, que corresponde al turno segun la hora dada en parametro 
        /// </summary>
        /// <param name="tdeHoradeAtencion">Hora en formato militar dada para realizar la busqueda</param>
        /// <returns>Devuelve un registro con el turno correspondiente segun la hora  dada en parametro</returns>
        public static ModeloHcltiporegturno fobRegistroHcltiporegturno(Decimal tdeHoradeAtencion)
        {
            ModeloHcltiporegturno lobReg = null;

            using (_context = new DbAplicacion())
            {
                var lobConsulta = from hcltiporegturno in _context.Hcltiporegturno
                                  where hcltiporegturno.hcl_horini_hctu <= tdeHoradeAtencion &&
                                        hcltiporegturno.hcl_horfin_hctu >= tdeHoradeAtencion
                                  select new ModeloHcltiporegturno
                                  {
                                      #region Datos
                                      Hcl_tiptur_hctu = hcltiporegturno.hcl_tiptur_hctu,
                                      Hcl_destur_hctu = hcltiporegturno.hcl_destur_hctu,
                                      Hcl_horini_hctu = (Decimal)hcltiporegturno.hcl_horini_hctu,
                                      Hcl_horfin_hctu = (Decimal)hcltiporegturno.hcl_horfin_hctu,
                                      #endregion
                                  };
                lobReg = lobConsulta.ToList().FirstOrDefault();

                // Correccion por erro 
                if (lobReg == null)
                {
                    lobReg = (from hcltiporegturno in _context.Hcltiporegturno
                              where hcltiporegturno.hcl_tiptur_hctu == "T03"
                              select new ModeloHcltiporegturno
                              {
                                  #region Datos
                                  Hcl_tiptur_hctu = hcltiporegturno.hcl_tiptur_hctu,
                                  Hcl_destur_hctu = hcltiporegturno.hcl_destur_hctu,
                                  Hcl_horini_hctu = (Decimal)hcltiporegturno.hcl_horini_hctu,
                                  Hcl_horfin_hctu = (Decimal)hcltiporegturno.hcl_horfin_hctu,
                                  #endregion
                              }).ToList().FirstOrDefault();
                }
            }
            return lobReg;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHcltiporegturno> flsListaHcltiporegturno(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from hcltiporegturno in _context.Hcltiporegturno
                                      select new ModeloHcltiporegturno
                                      {
                                          #region Datos
                                          Hcl_tiptur_hctu = hcltiporegturno.hcl_tiptur_hctu,
                                          Hcl_destur_hctu = hcltiporegturno.hcl_destur_hctu,
                                          Hcl_horini_hctu = (Decimal)hcltiporegturno.hcl_horini_hctu,
                                          Hcl_horfin_hctu = (Decimal)hcltiporegturno.hcl_horfin_hctu,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hcltiporegturno in _context.Hcltiporegturno
                                      where hcltiporegturno.hcl_tiptur_hctu == tcrBuscar
                                      select new ModeloHcltiporegturno
                                      {
                                          #region Datos
                                          Hcl_tiptur_hctu = hcltiporegturno.hcl_tiptur_hctu,
                                          Hcl_destur_hctu = hcltiporegturno.hcl_destur_hctu,
                                          Hcl_horini_hctu = (Decimal)hcltiporegturno.hcl_horini_hctu,
                                          Hcl_horfin_hctu = (Decimal)hcltiporegturno.hcl_horfin_hctu,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// hclformatvistma: Grupo vista actividades medicas en captura Historias clinicas
    /// </summary>
    public class ModeloHclformatvistma : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region RefObjeto: Instancia del grupo en menu actividades medicas
        /// <summary>
        /// Referencia a instancia del grupo en menu actividades medicas
        /// </summary>
        public FrameworkElement RefObjeto { get; set; }
        #endregion
        #region Hcl_codreg_hcra: Codigo grupo actividad
        private String _hcl_codreg_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Codigo grupo actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcra (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico registro del grupo actividad para vista captura
        /// Historia clinica
        /// </para>
        /// </summary>
        public String Hcl_codreg_hcra
        {
            get { return _hcl_codreg_hcra; }
            set
            {
                if (_hcl_codreg_hcra == value) return;
                _hcl_codreg_hcra = value;
                OnPropertyChanged("Hcl_codreg_hcra");
            }
        }
        #endregion
        #region Hcl_desgru_hcra: Nombre grupo actividad
        private String _hcl_desgru_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Nombre grupo actividad</para>
        /// <para>NOMBRE: hcl_desgru_hcra (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion grupo actividades clasificadas para vista en captura
        /// historias clinicas
        /// </para>
        /// </summary>
        public String Hcl_desgru_hcra
        {
            get { return _hcl_desgru_hcra; }
            set
            {
                if (_hcl_desgru_hcra == value) return;
                _hcl_desgru_hcra = value;
                OnPropertyChanged("Hcl_desgru_hcra");
            }
        }
        #endregion
        #region Hcl_tipvis_hcra: Mostrar según admision
        private String _hcl_tipvis_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Mostrar según admision</para>
        /// <para>NOMBRE: hcl_tipvis_hcra (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Saber si se muestra el grupo según el tipo de registro de atencion
        /// activo: 1= Solo en pacientes admitidos 2=Solo en Pacientes
        /// ambulatoria 3= Ambos casos
        /// </para>
        /// </summary>
        public String Hcl_tipvis_hcra
        {
            get { return _hcl_tipvis_hcra; }
            set
            {
                if (_hcl_tipvis_hcra == value) return;
                _hcl_tipvis_hcra = value;
                OnPropertyChanged("Hcl_tipvis_hcra");
            }
        }
        #endregion
        #region Hcl_ordvis_hcra: Orden visualizacion
        private int _hcl_ordvis_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Orden visualizacion</para>
        /// <para>NOMBRE: hcl_ordvis_hcra (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion dentro de lista grupos
        /// </para>
        /// </summary>
        public int Hcl_ordvis_hcra
        {
            get { return _hcl_ordvis_hcra; }
            set
            {
                if (_hcl_ordvis_hcra == value) return;
                _hcl_ordvis_hcra = value;
                OnPropertyChanged("Hcl_ordvis_hcra");
            }
        }
        #endregion
        #region Hcl_imagen_hcra: Imagen (jpg)
        private String _hcl_imagen_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: hcl_imagen_hcra (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Nombre de la imagen que representa el grupo
        /// </para>
        /// </summary>
        public String Hcl_imagen_hcra
        {
            get { return _hcl_imagen_hcra; }
            set
            {
                if (_hcl_imagen_hcra == value) return;
                _hcl_imagen_hcra = value;
                OnPropertyChanged("Hcl_imagen_hcra");
            }
        }
        #endregion
        #region Hcl_estreg_hcra: Estado registro
        private String _hcl_estreg_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: hcl_estreg_hcra (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Hcl_estreg_hcra
        {
            get { return _hcl_estreg_hcra; }
            set
            {
                if (_hcl_estreg_hcra == value) return;
                _hcl_estreg_hcra = value;
                OnPropertyChanged("Hcl_estreg_hcra");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static String flgAddRegistro(ModeloHclformatvistma tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("HCL-HCLFORMATVISTMA", "HCL", "Grupo formatos captura Historias clinicas");
            try
            {
                if (!flgBuscarHclformatvistma(lcrCodigoGen))
                {
                    using (_context = new DbAplicacion())
                    {
                        var lobjRegistro = new EFhclformatvistma
                        {
                            #region cargar Registro
                            hcl_codreg_hcra = tobjModelo.Hcl_codreg_hcra,
                            hcl_desgru_hcra = tobjModelo.Hcl_desgru_hcra,
                            hcl_tipvis_hcra = tobjModelo.Hcl_tipvis_hcra,
                            hcl_ordvis_hcra = tobjModelo.Hcl_ordvis_hcra,
                            hcl_imagen_hcra = tobjModelo.Hcl_imagen_hcra,
                            hcl_estreg_hcra = tobjModelo.Hcl_estreg_hcra,
                            #endregion
                        };
                        lobjRegistro.hcl_codreg_hcra = lcrCodigoGen;
                        _context.AddToHclformatvistma(lobjRegistro);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    lcrCodigoGen = String.Empty;
                    MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'HCL-HCLFORMATVISTMA': Grupo formatos captura Historias clinicas.");
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
        public static void fcvActualizar(ModeloHclformatvistma tobjModelo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclformatvistma.FirstOrDefault(p => p.hcl_codreg_hcra == tobjModelo.Hcl_codreg_hcra);
                    if (lobjRegistro != null)
                    {
                        #region cargar Registro
                        lobjRegistro.hcl_codreg_hcra = tobjModelo.Hcl_codreg_hcra;
                        lobjRegistro.hcl_desgru_hcra = tobjModelo.Hcl_desgru_hcra;
                        lobjRegistro.hcl_tipvis_hcra = tobjModelo.Hcl_tipvis_hcra;
                        lobjRegistro.hcl_ordvis_hcra = (int)tobjModelo.Hcl_ordvis_hcra;
                        lobjRegistro.hcl_imagen_hcra = tobjModelo.Hcl_imagen_hcra;
                        lobjRegistro.hcl_estreg_hcra = tobjModelo.Hcl_estreg_hcra;
                        #endregion
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
        public static void fcvEliminar(String tcrCodigo)
        {
            try
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = _context.Hclformatvistma.FirstOrDefault(p => p.hcl_codreg_hcra == tcrCodigo);
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
        #region Buscar HCLFORMATVISTMA: Logica
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TITULO: Registro grupo formatos actividad servicios captura Historia</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupos formatos de actividad o servicios para organización
        /// en vista captura historias clinicas (capa Propiedades) y agrupados
        /// según funcionalidad de cada formato y perfil de usuario
        /// </para>
        /// </summary>
        public static bool flgBuscarHclformatvistma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hclformatvistma.FirstOrDefault(p => p.hcl_codreg_hcra == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloHclformatvistma> flsListaHclformatvistma(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (String.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from hclformatvistma in _context.Hclformatvistma
                                      select new ModeloHclformatvistma
                                      {
                                          #region Datos
                                          Hcl_codreg_hcra = hclformatvistma.hcl_codreg_hcra,
                                          Hcl_desgru_hcra = hclformatvistma.hcl_desgru_hcra,
                                          Hcl_tipvis_hcra = hclformatvistma.hcl_tipvis_hcra,
                                          Hcl_ordvis_hcra = (int)hclformatvistma.hcl_ordvis_hcra,
                                          Hcl_imagen_hcra = hclformatvistma.hcl_imagen_hcra,
                                          Hcl_estreg_hcra = hclformatvistma.hcl_estreg_hcra,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from hclformatvistma in _context.Hclformatvistma
                                      where hclformatvistma.hcl_codreg_hcra.Contains(tcrBuscar) || hclformatvistma.hcl_desgru_hcra.Contains(tcrBuscar)
                                      select new ModeloHclformatvistma
                                      {
                                          #region Datos
                                          Hcl_codreg_hcra = hclformatvistma.hcl_codreg_hcra,
                                          Hcl_desgru_hcra = hclformatvistma.hcl_desgru_hcra,
                                          Hcl_tipvis_hcra = hclformatvistma.hcl_tipvis_hcra,
                                          Hcl_ordvis_hcra = (int)hclformatvistma.hcl_ordvis_hcra,
                                          Hcl_imagen_hcra = hclformatvistma.hcl_imagen_hcra,
                                          Hcl_estreg_hcra = hclformatvistma.hcl_estreg_hcra,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #region flsVistaMenuGrupoActivMedicasPerfil: Lista Grupos Actividades medicas por perfil uasuario
        /// <summary>
        /// Lista Grupos Actividades por perfil usuario activo para vista del menu Historias clinicas
        /// </summary>
        /// <param name="tcrCodigoPerfil">Codigo del perfil usuario</param>
        /// <returns>Retorna lista grupos actividades permitidas del perfil</returns>
        public static List<ModeloHclformatvistma> flsVistaMenuGrupoActivMedicasPerfil(String tcrCodigoPerfil)
        {
            bool llgDatos = false;
            var tmpGrupos = new List<ModeloHclformatvistma>();
            ModeloHclformatvistma lobRegNew = null;


            using (_context = new DbAplicacion())
            {
                var tmpLista01 = (from hcltiporegactiv in _context.Hcltiporegactiv
                                    join hclformatperfil in _context.Hclformatperfil on hcltiporegactiv.hcl_codreg_hcca equals hclformatperfil.hcl_codreg_hcca into tmhclformatperfil
                                    from hcca in tmhclformatperfil.DefaultIfEmpty()
                                    where hcca.sys_codper_perf == tcrCodigoPerfil &&
                                          hcca.hcl_accedt_hcpr == "1" &&
                                          hcca.hcl_estfor_hcpr == "1" select hcltiporegactiv).ToList();

                var tmpLista02 = (from hclformatvistma in _context.Hclformatvistma
                                  where hclformatvistma.hcl_estreg_hcra == "1"
                                  orderby hclformatvistma.hcl_ordvis_hcra select hclformatvistma).ToList();

                foreach (var lobReg in tmpLista02)
                {
                    var lobReaux = tmpLista01.FirstOrDefault(x => x.hcl_codreg_hcra == lobReg.hcl_codreg_hcra);

                    if (lobReaux != null)
                    {
                        llgDatos = true;

                        lobRegNew = new ModeloHclformatvistma
                        {
                            #region Datos
                            Hcl_codreg_hcra = lobReg.hcl_codreg_hcra,
                            Hcl_desgru_hcra = lobReg.hcl_desgru_hcra,
                            Hcl_tipvis_hcra = lobReg.hcl_tipvis_hcra,
                            Hcl_ordvis_hcra = (int)lobReg.hcl_ordvis_hcra,
                            Hcl_imagen_hcra = lobReg.hcl_imagen_hcra,
                            Hcl_estreg_hcra = lobReg.hcl_estreg_hcra,
                            #endregion
                        };

                        tmpGrupos.Add(lobRegNew);
                    }
                }
            }


            // Realizar consulta nativa SQL inculye una Subconsulta
            /*
            var lcrLineaSqlSelct = "SELECT * FROM hclformatvistma WHERE hcl_codreg_hcra IN" +
                                          " (SELECT hcltiporegactiv.hcl_codreg_hcra" +
                                          "        FROM hcltiporegactiv" +
                                          "  INNER JOIN hclformatperfil ON (hcltiporegactiv.hcl_codreg_hcca = hclformatperfil.hcl_codreg_hcca)" +
                                          "       WHERE hclformatperfil.sys_codper_perf = '" + tcrCodigoPerfil + "' AND"+
                                          "             hclformatperfil.hcl_accedt_hcpr ='1' AND hclformatperfil.hcl_estfor_hcpr = '1'" +
                                          "    GROUP BY hcltiporegactiv.hcl_codreg_hcra) AND hclformatvistma.hcl_estreg_hcra = '1'" +
                                          " ORDER BY hclformatvistma.hcl_ordvis_hcra";
            var tmpGrupo = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);

            // Cargar los datos
            foreach (DataRow lobReg in tmpGrupo.Rows)
            {
                llgDatos = true;
                lobRegNew = new ModeloHclformatvistma
                                {
                                    #region Datos
                                    Hcl_codreg_hcra = lobReg["Hcl_codreg_hcra"].ToString(),
                                    Hcl_desgru_hcra = lobReg["Hcl_desgru_hcra"].ToString(),
                                    Hcl_tipvis_hcra = lobReg["hcl_tipvis_hcra"].ToString(),
                                    Hcl_ordvis_hcra = (int)lobReg["Hcl_ordvis_hcra"],
                                    Hcl_imagen_hcra = lobReg["Hcl_imagen_hcra"].ToString(),
                                    Hcl_estreg_hcra = lobReg["Hcl_estreg_hcra"].ToString(),
                                    #endregion
                                };
                tmpGrupos.Add(lobRegNew);
            }
            */
            if (llgDatos == false) { tmpGrupos = null; }

            return tmpGrupos;
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// hcltiporegactiv: Detalles tipo registro de actividad en historial 
    /// </summary>
    public class ModeloHcltiporegactiv : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region RefObjeto: Referencia a la instancia del comando actividad
        /// <summary>
        /// Referencia a la instancia del comando actividad medica en grupo
        /// </summary>
        public FrameworkElement RefObjeto { get; set; }
        #endregion
        #region Hcl_secreg_hcca: Codigo registro
        private String _hcl_secreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: hcl_secreg_hcca (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial registro en la tabla (generado por
        /// el sistema)
        /// </para>
        /// </summary>
        public String Hcl_secreg_hcca
        {
            get { return _hcl_secreg_hcca; }
            set
            {
                if (_hcl_secreg_hcca == value) return;
                _hcl_secreg_hcca = value;
                OnPropertyChanged("Hcl_secreg_hcca");
            }
        }
        #endregion
        #region Hcl_codreg_hcra: Codigo grupo actividad
        private String _hcl_codreg_hcra;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Codigo grupo actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcra (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo unico registro del grupo actividad para vista captura
        /// Historia clinica
        /// </para>
        /// </summary>
        public String Hcl_codreg_hcra
        {
            get { return _hcl_codreg_hcra; }
            set
            {
                if (_hcl_codreg_hcra == value) return;
                _hcl_codreg_hcra = value;
                OnPropertyChanged("Hcl_codreg_hcra");
            }
        }
        #endregion
        #region Hcl_codreg_hcca: Tipo registro actividad
        private String _hcl_codreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura
        /// Historia clinica general APE-HCL-ODON= Apertura Historia clinica
        /// odontologia
        /// </para>
        /// </summary>
        public String Hcl_codreg_hcca
        {
            get { return _hcl_codreg_hcca; }
            set
            {
                if (_hcl_codreg_hcca == value) return;
                _hcl_codreg_hcca = value;
                OnPropertyChanged("Hcl_codreg_hcca");
            }
        }
        #endregion
        #region Hcl_desreg_hcca: Descripcion tipo registro
        private String _hcl_desreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: hcl_desreg_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion  Tipo de registro actividad clasificada en historial
        /// del paciente
        /// </para>
        /// </summary>
        public String Hcl_desreg_hcca
        {
            get { return _hcl_desreg_hcca; }
            set
            {
                if (_hcl_desreg_hcca == value) return;
                _hcl_desreg_hcca = value;
                OnPropertyChanged("Hcl_desreg_hcca");
            }
        }
        #endregion
        #region Grp_idepla_grpl: Código único plantilla
        private String _grp_idepla_grpl;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo formato plantilla asociada para generar registro actividad
        /// en historia clinica
        /// </para>
        /// </summary>
        public String Grp_idepla_grpl
        {
            get { return _grp_idepla_grpl; }
            set
            {
                if (_grp_idepla_grpl == value) return;
                _grp_idepla_grpl = value;
                OnPropertyChanged("Grp_idepla_grpl");
            }
        }
        #endregion
        #region Sys_codtip_sytm: Tipo de mensajes sistema
        private String _sys_codtip_sytm;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Tipo de mensajes sistema</para>
        /// <para>NOMBRE: sys_codtip_sytm (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo unico tipos de mensaje que desencadena en el adminstrador
        /// de mensajeria del sistema
        /// </para>
        /// </summary>
        public String Sys_codtip_sytm
        {
            get { return _sys_codtip_sytm; }
            set
            {
                if (_sys_codtip_sytm == value) return;
                _sys_codtip_sytm = value;
                OnPropertyChanged("Sys_codtip_sytm");
            }
        }
        #endregion
        #region Hcl_imagen_hcca: Imagen (jpg)
        private String _hcl_imagen_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: hcl_imagen_hcca (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Nombre de la imagen que representa el registro de actividad
        /// en las diferentes vistas
        /// </para>
        /// </summary>
        public String Hcl_imagen_hcca
        {
            get { return _hcl_imagen_hcca; }
            set
            {
                if (_hcl_imagen_hcca == value) return;
                _hcl_imagen_hcca = value;
                OnPropertyChanged("Hcl_imagen_hcca");
            }
        }
        #endregion
        #region Hcl_icolor_hcca: Color fondo HC
        private String _hcl_icolor_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Color fondo HC</para>
        /// <para>NOMBRE: hcl_icolor_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Color del fondo en la vista navegacion del historial clinico
        /// </para>
        /// </summary>
        public String Hcl_icolor_hcca
        {
            get { return _hcl_icolor_hcca; }
            set
            {
                if (_hcl_icolor_hcca == value) return;
                _hcl_icolor_hcca = value;
                OnPropertyChanged("Hcl_icolor_hcca");
            }
        }
        #endregion
        #region Hcl_rutarc_hcca: Ruta archivos
        private String _hcl_rutarc_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Ruta archivos</para>
        /// <para>NOMBRE: hcl_rutarc_hcca (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Ruta en historial clinico de archivos generados por el grupo
        /// de actividad
        /// </para>
        /// </summary>
        public String Hcl_rutarc_hcca
        {
            get { return _hcl_rutarc_hcca; }
            set
            {
                if (_hcl_rutarc_hcca == value) return;
                _hcl_rutarc_hcca = value;
                OnPropertyChanged("Hcl_rutarc_hcca");
            }
        }
        #endregion
        #region Hcl_ordvis_hcca: Orden visualizacion
        private int _hcl_ordvis_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Orden visualizacion</para>
        /// <para>NOMBRE: hcl_ordvis_hcca (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion dentro de lista grupos
        /// </para>
        /// </summary>
        public int Hcl_ordvis_hcca
        {
            get { return _hcl_ordvis_hcca; }
            set
            {
                if (_hcl_ordvis_hcca == value) return;
                _hcl_ordvis_hcca = value;
                OnPropertyChanged("Hcl_ordvis_hcca");
            }
        }
        #endregion
        #region Hcl_psubgr_hcca: Primer reg subgrupo
        private String _hcl_psubgr_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Primer reg subgrupo</para>
        /// <para>NOMBRE: hcl_psubgr_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Primer registro cada subgrupo cuando dentro de un grupo hay
        /// varios sugrupos: 1= Primer registro 2=No es primero
        /// </para>
        /// </summary>
        public String Hcl_psubgr_hcca
        {
            get { return _hcl_psubgr_hcca; }
            set
            {
                if (_hcl_psubgr_hcca == value) return;
                _hcl_psubgr_hcca = value;
                OnPropertyChanged("Hcl_psubgr_hcca");
            }
        }
        #endregion
        #region Hcl_mededi_hcca: Medida edad Inicial
        private String _hcl_mededi_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: hcl_mededi_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica la actividad medica para
        /// validación pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Hcl_mededi_hcca
        {
            get { return _hcl_mededi_hcca; }
            set
            {
                if (_hcl_mededi_hcca == value) return;
                _hcl_mededi_hcca = value;
                OnPropertyChanged("Hcl_mededi_hcca");
            }
        }
        #endregion
        #region Hcl_edaini_hcca: Edad Inicial
        private int _hcl_edaini_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Edad Inicial</para>
        /// <para>NOMBRE: hcl_edaini_hcca (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Edad inicial para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int Hcl_edaini_hcca
        {
            get { return _hcl_edaini_hcca; }
            set
            {
                if (_hcl_edaini_hcca == value) return;
                _hcl_edaini_hcca = value;
                OnPropertyChanged("Hcl_edaini_hcca");
            }
        }
        #endregion
        #region Hcl_mededf_hcca: Medida edad final
        private String _hcl_mededf_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: hcl_mededf_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia actividad medica:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Hcl_mededf_hcca
        {
            get { return _hcl_mededf_hcca; }
            set
            {
                if (_hcl_mededf_hcca == value) return;
                _hcl_mededf_hcca = value;
                OnPropertyChanged("Hcl_mededf_hcca");
            }
        }
        #endregion
        #region Hcl_edafin_hcca: Edad final
        private int _hcl_edafin_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: hcl_edafin_hcca (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Edad final para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int Hcl_edafin_hcca
        {
            get { return _hcl_edafin_hcca; }
            set
            {
                if (_hcl_edafin_hcca == value) return;
                _hcl_edafin_hcca = value;
                OnPropertyChanged("Hcl_edafin_hcca");
            }
        }
        #endregion
        #region Hcl_sexapl_hcca: Sexo que aplica
        private String _hcl_sexapl_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: hcl_sexapl_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica la actividad medica: 1=Masculino 2=Femenino
        /// 3=Ambos
        /// </para>
        /// </summary>
        public String Hcl_sexapl_hcca
        {
            get { return _hcl_sexapl_hcca; }
            set
            {
                if (_hcl_sexapl_hcca == value) return;
                _hcl_sexapl_hcca = value;
                OnPropertyChanged("Hcl_sexapl_hcca");
            }
        }
        #endregion
        #region Hcl_mededl_hcca: Medida edad lista
        private String _hcl_mededl_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad lista</para>
        /// <para>NOMBRE: hcl_mededl_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Medida edad validacion para lista valores permitidos pertinencia:
        /// 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public String Hcl_mededl_hcca
        {
            get { return _hcl_mededl_hcca; }
            set
            {
                if (_hcl_mededl_hcca == value) return;
                _hcl_mededl_hcca = value;
                OnPropertyChanged("Hcl_mededl_hcca");
            }
        }
        #endregion
        #region Hcl_listar_hcca: Lista rango edades
        private String _hcl_listar_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Lista rango edades</para>
        /// <para>NOMBRE: hcl_listar_hcca (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Lista valores permitidos validacion edad según rango separados
        /// por el carácter COMA
        /// </para>
        /// </summary>
        public String Hcl_listar_hcca
        {
            get { return _hcl_listar_hcca; }
            set
            {
                if (_hcl_listar_hcca == value) return;
                _hcl_listar_hcca = value;
                OnPropertyChanged("Hcl_listar_hcca");
            }
        }
        #endregion
        #region Hcl_estreg_hcca: Estado registro
        private String _hcl_estreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: hcl_estreg_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public String Hcl_estreg_hcca
        {
            get { return _hcl_estreg_hcca; }
            set
            {
                if (_hcl_estreg_hcca == value) return;
                _hcl_estreg_hcca = value;
                OnPropertyChanged("Hcl_estreg_hcca");
            }
        }
        #endregion
        #region Hcl_desgru_hcra: Nombre grupo actividad
        private String _hcl_desgru_hcra;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Nombre grupo actividad</para>
        /// <para>NOMBRE: hcl_desgru_hcra (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion grupo actividades clasificadas para vista en captura
        /// historias clinicas
        /// </para>
        /// </summary>
        public String Hcl_desgru_hcra
        {
            get { return _hcl_desgru_hcra; }
            set
            {
                if (_hcl_desgru_hcra == value) return;
                _hcl_desgru_hcra = value;
                OnPropertyChanged("Hcl_desgru_hcra");
            }
        }
        #endregion
        #region Grp_despla_grpl: Nombre plantilla
        private String _grp_despla_grpl;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public String Grp_despla_grpl
        {
            get { return _grp_despla_grpl; }
            set
            {
                if (_grp_despla_grpl == value) return;
                _grp_despla_grpl = value;
                OnPropertyChanged("Grp_despla_grpl");
            }
        }
        #endregion
        #region Sys_desmsj_sytm: Descripción tipo
        private String _sys_desmsj_sytm;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Descripción tipo</para>
        /// <para>NOMBRE: sys_desmsj_sytm (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción del tipo notificación enviada según el evento ocurrido
        /// que debe ser notificado
        /// </para>
        /// </summary>
        public String Sys_desmsj_sytm
        {
            get { return _sys_desmsj_sytm; }
            set
            {
                if (_sys_desmsj_sytm == value) return;
                _sys_desmsj_sytm = value;
                OnPropertyChanged("Sys_desmsj_sytm");
            }
        }
        #endregion
        #region Sis_estado_imaen: Estado del registro para edicion
        private String _sis_estado_imaen;
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
        public static bool flgAddRegistro(ModeloHcltiporegactiv tobTempReg, String tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFhcltiporegactiv();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_secreg_hcca == tobTempReg.Hcl_secreg_hcca);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.hcl_secreg_hcca = tobTempReg.Hcl_secreg_hcca;
                            lobEFReg.hcl_codreg_hcra = tobTempReg.Hcl_codreg_hcra;
                            lobEFReg.hcl_codreg_hcca = tobTempReg.Hcl_codreg_hcca;
                            lobEFReg.hcl_desreg_hcca = tobTempReg.Hcl_desreg_hcca;
                            lobEFReg.grp_idepla_grpl = tobTempReg.Grp_idepla_grpl;
                            lobEFReg.sys_codtip_sytm = tobTempReg.Sys_codtip_sytm;
                            lobEFReg.hcl_imagen_hcca = tobTempReg.Hcl_imagen_hcca;
                            lobEFReg.hcl_icolor_hcca = tobTempReg.Hcl_icolor_hcca;
                            lobEFReg.hcl_rutarc_hcca = tobTempReg.Hcl_rutarc_hcca;
                            lobEFReg.hcl_ordvis_hcca = (int)tobTempReg.Hcl_ordvis_hcca;
                            lobEFReg.hcl_psubgr_hcca = tobTempReg.Hcl_psubgr_hcca;
                            lobEFReg.hcl_mededi_hcca = tobTempReg.Hcl_mededi_hcca;
                            lobEFReg.hcl_edaini_hcca = (int)tobTempReg.Hcl_edaini_hcca;
                            lobEFReg.hcl_mededf_hcca = tobTempReg.Hcl_mededf_hcca;
                            lobEFReg.hcl_edafin_hcca = (int)tobTempReg.Hcl_edafin_hcca;
                            lobEFReg.hcl_sexapl_hcca = tobTempReg.Hcl_sexapl_hcca;
                            lobEFReg.hcl_mededl_hcca = tobTempReg.Hcl_mededl_hcca;
                            lobEFReg.hcl_listar_hcca = tobTempReg.Hcl_listar_hcca;
                            lobEFReg.hcl_estreg_hcca = tobTempReg.Hcl_estreg_hcca;
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
                                lobEFReg.hcl_secreg_hcca = tcrCodigoR1 + lobEFReg.hcl_secreg_hcca; // concatenar
                                _context.AddToHcltiporegactiv(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_secreg_hcca == tobTempReg.Hcl_secreg_hcca);
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
            catch (Exception ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return llgReturn;
        }
        #endregion
        #region Buscar HCLTIPOREGACTIV: Logica
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TITULO: Detalles tipo registro de actividad en historial</para>
        /// <para>MODULO: HCL</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion del registro de actividad generada en el historial,
        /// para actividades con caracterisiticas especiales, ejemplo :
        /// apertura de historia clinica general -> APE-HCL-GENE =Apertura
        /// historia clinica general
        /// </para>
        /// </summary>
        public static bool flgBuscarHcltiporegactiv(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Hcltiporegactiv.FirstOrDefault(p => p.hcl_secreg_hcca == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Registro dado en parametro
        public static List<ModeloHcltiporegactiv> flsListaHcltiporegactiv(String tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from hcltiporegactiv in _context.Hcltiporegactiv
                                  where hcltiporegactiv.hcl_codreg_hcra == tcrBuscar
                                  select new ModeloHcltiporegactiv
                                  {
                                      Hcl_secreg_hcca = hcltiporegactiv.hcl_secreg_hcca,
                                      Hcl_codreg_hcra = hcltiporegactiv.hcl_codreg_hcra,
                                      Hcl_codreg_hcca = hcltiporegactiv.hcl_codreg_hcca,
                                      Hcl_desreg_hcca = hcltiporegactiv.hcl_desreg_hcca,
                                      Grp_idepla_grpl = hcltiporegactiv.grp_idepla_grpl,
                                      Sys_codtip_sytm = hcltiporegactiv.sys_codtip_sytm,
                                      Hcl_imagen_hcca = hcltiporegactiv.hcl_imagen_hcca,
                                      Hcl_icolor_hcca = hcltiporegactiv.hcl_icolor_hcca,
                                      Hcl_rutarc_hcca = hcltiporegactiv.hcl_rutarc_hcca,
                                      Hcl_ordvis_hcca = (int)hcltiporegactiv.hcl_ordvis_hcca,
                                      Hcl_psubgr_hcca = hcltiporegactiv.hcl_psubgr_hcca,
                                      Hcl_mededi_hcca = hcltiporegactiv.hcl_mededi_hcca,
                                      Hcl_edaini_hcca = (int)hcltiporegactiv.hcl_edaini_hcca,
                                      Hcl_mededf_hcca = hcltiporegactiv.hcl_mededf_hcca,
                                      Hcl_edafin_hcca = (int)hcltiporegactiv.hcl_edafin_hcca,
                                      Hcl_sexapl_hcca = hcltiporegactiv.hcl_sexapl_hcca,
                                      Hcl_mededl_hcca = hcltiporegactiv.hcl_mededl_hcca,
                                      Hcl_listar_hcca = hcltiporegactiv.hcl_listar_hcca,
                                      Hcl_estreg_hcca = hcltiporegactiv.hcl_estreg_hcca,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #region fobRegistroHcltiporegactiv: Registro
        /// <summary>
        /// Registro completo con relaciones en otras tablas
        /// </summary>
        /// <param name="tcrCodigoRegistro">Codigo del registro</param>
        /// <returns>Devuelve un registro del tipo ModeloHcltiporegactiv</returns>
        public static ModeloHcltiporegactiv fobRegistroHcltiporegactiv(String tcrCodigoRegistro)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from hcltiporegactiv in _context.Hcltiporegactiv
                                  join hclformatvistma in _context.Hclformatvistma on hcltiporegactiv.hcl_codreg_hcra equals hclformatvistma.hcl_codreg_hcra into tmhclformatvistma
                                  join grpmaeplantilla in _context.Grpmaeplantilla on hcltiporegactiv.grp_idepla_grpl equals grpmaeplantilla.grp_idepla_grpl into tmgrpmaeplantilla
                                  join sysadmstipomens in _context.Sysadmstipomens on hcltiporegactiv.sys_codtip_sytm equals sysadmstipomens.sys_codtip_sytm into tmsysadmstipomens
                                  from hcra in tmhclformatvistma.DefaultIfEmpty()
                                  from grpl in tmgrpmaeplantilla.DefaultIfEmpty()
                                  from sytm in tmsysadmstipomens.DefaultIfEmpty()
                                  where hcltiporegactiv.hcl_codreg_hcra == tcrCodigoRegistro
                                  select new ModeloHcltiporegactiv
                                  {
                                      Hcl_secreg_hcca = hcltiporegactiv.hcl_secreg_hcca,
                                      Hcl_codreg_hcra = hcltiporegactiv.hcl_codreg_hcra,
                                      Hcl_codreg_hcca = hcltiporegactiv.hcl_codreg_hcca,
                                      Hcl_desreg_hcca = hcltiporegactiv.hcl_desreg_hcca,
                                      Grp_idepla_grpl = hcltiporegactiv.grp_idepla_grpl,
                                      Sys_codtip_sytm = hcltiporegactiv.sys_codtip_sytm,
                                      Hcl_imagen_hcca = hcltiporegactiv.hcl_imagen_hcca,
                                      Hcl_icolor_hcca = hcltiporegactiv.hcl_icolor_hcca,
                                      Hcl_rutarc_hcca = hcltiporegactiv.hcl_rutarc_hcca,
                                      Hcl_ordvis_hcca = (int)hcltiporegactiv.hcl_ordvis_hcca,
                                      Hcl_psubgr_hcca = hcltiporegactiv.hcl_psubgr_hcca,
                                      Hcl_mededi_hcca = hcltiporegactiv.hcl_mededi_hcca,
                                      Hcl_edaini_hcca = (int)hcltiporegactiv.hcl_edaini_hcca,
                                      Hcl_mededf_hcca = hcltiporegactiv.hcl_mededf_hcca,
                                      Hcl_edafin_hcca = (int)hcltiporegactiv.hcl_edafin_hcca,
                                      Hcl_sexapl_hcca = hcltiporegactiv.hcl_sexapl_hcca,
                                      Hcl_mededl_hcca = hcltiporegactiv.hcl_mededl_hcca,
                                      Hcl_listar_hcca = hcltiporegactiv.hcl_listar_hcca,
                                      Hcl_estreg_hcca = hcltiporegactiv.hcl_estreg_hcca,
                                      Hcl_desgru_hcra = hcra.hcl_desgru_hcra,
                                      Grp_despla_grpl = grpl.grp_despla_grpl,
                                      Sys_desmsj_sytm = sytm.sys_desmsj_sytm,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList().FirstOrDefault();
            }
        }
        #endregion
        #region flsVistaMenuGrupoActivMedicasPerfil: Lista Grupos Actividades medicas por perfil uasuario
        /// <summary>
        /// Lista detalles Actividades medicas por perfil, usuario activo para vista del menu Historias clinicas
        /// </summary>
        /// <param name="tcrCodigoPerfil">Codigo del perfil usuario</param>
        /// <returns>Retorna lista detalles grupos actividades permitidas perfil</returns>
        public static List<ModeloHcltiporegactiv> flsVistaMenuDetallesActivMedicasPerfil(String tcrCodigoPerfil)
        {
            bool llgDatos = false;
            var tmpLista = new List<ModeloHcltiporegactiv>();
            //ModeloHcltiporegactiv lobRegNew = null;

            using (_context = new DbAplicacion())
            {
                llgDatos = true;
                tmpLista = (from hcltiporegactiv in _context.Hcltiporegactiv
                            join hclformatperfil in _context.Hclformatperfil on hcltiporegactiv.hcl_codreg_hcca equals hclformatperfil.hcl_codreg_hcca into tmhclformatperfil
                            join hclformatvistma in _context.Hclformatvistma on hcltiporegactiv.hcl_codreg_hcra equals hclformatvistma.hcl_codreg_hcra into tmhclformatvistma
                            from hcca in tmhclformatperfil.DefaultIfEmpty()
                            from hccm in tmhclformatvistma.DefaultIfEmpty()
                            where hcltiporegactiv.hcl_estreg_hcca == "1" &&
                                  hcca.sys_codper_perf == tcrCodigoPerfil &&
                                  hcca.hcl_accedt_hcpr == "1" &&
                                  hcca.hcl_estfor_hcpr == "1" &&
                                  hccm.hcl_estreg_hcra == "1"
                            orderby hcltiporegactiv.hcl_codreg_hcra, hcltiporegactiv.hcl_ordvis_hcca
                            select new ModeloHcltiporegactiv
                               {
                                   #region Datos
                                   Hcl_secreg_hcca = hcltiporegactiv.hcl_secreg_hcca,
                                   Hcl_codreg_hcra = hcltiporegactiv.hcl_codreg_hcra,
                                   Hcl_codreg_hcca = hcltiporegactiv.hcl_codreg_hcca,
                                   Hcl_desreg_hcca = hcltiporegactiv.hcl_desreg_hcca,
                                   Grp_idepla_grpl = hcltiporegactiv.grp_idepla_grpl,
                                   Sys_codtip_sytm = hcltiporegactiv.sys_codtip_sytm,
                                   Hcl_imagen_hcca = hcltiporegactiv.hcl_imagen_hcca,
                                   Hcl_icolor_hcca = hcltiporegactiv.hcl_icolor_hcca,
                                   Hcl_rutarc_hcca = hcltiporegactiv.hcl_rutarc_hcca,
                                   Hcl_ordvis_hcca = (int)hcltiporegactiv.hcl_ordvis_hcca,
                                   Hcl_psubgr_hcca = hcltiporegactiv.hcl_psubgr_hcca,
                                   Hcl_mededi_hcca = hcltiporegactiv.hcl_mededi_hcca,
                                   Hcl_edaini_hcca = (int)hcltiporegactiv.hcl_edaini_hcca,
                                   Hcl_mededf_hcca = hcltiporegactiv.hcl_mededf_hcca,
                                   Hcl_edafin_hcca = (int)hcltiporegactiv.hcl_edafin_hcca,
                                   Hcl_sexapl_hcca = hcltiporegactiv.hcl_sexapl_hcca,
                                   Hcl_mededl_hcca = hcltiporegactiv.hcl_mededl_hcca,
                                   Hcl_listar_hcca = hcltiporegactiv.hcl_listar_hcca,
                                   Hcl_estreg_hcca = hcltiporegactiv.hcl_estreg_hcca,
                                   #endregion
                               }).ToList();
            }


            // Realizar consulta nativa SQL inculye una Subconsulta
            /*
            var lcrLineaSqlSelct = "SELECT hcltiporegactiv.*" +
            		             "       FROM hcltiporegactiv" +
                                 " INNER JOIN hclformatperfil ON (hcltiporegactiv.hcl_codreg_hcca = hclformatperfil.hcl_codreg_hcca)" +
                                 " INNER JOIN hclformatvistma ON (hcltiporegactiv.hcl_codreg_hcra = hclformatvistma.hcl_codreg_hcra)" +
               	                 "      WHERE hcltiporegactiv.hcl_estreg_hcca = '1' AND" +
            			         "            hclformatperfil.sys_codper_perf = '" + tcrCodigoPerfil + "' AND" +
            			         "            hclformatperfil.hcl_accedt_hcpr = '1' AND" +
            			         "            hclformatperfil.hcl_estfor_hcpr = '1' AND" +
            			         "            hclformatvistma.hcl_estreg_hcra = '1'" +
            	                 "   ORDER BY hcltiporegactiv.hcl_codreg_hcra,hcltiporegactiv.hcl_ordvis_hcca";
            var tmpGrupo = Funciones.fobConsultaSqlDataAdapter(lcrLineaSqlSelct);

            // Cargar los datos
            foreach (DataRow lobReg in tmpGrupo.Rows)
            {
                llgDatos = true;
                lobRegNew = new ModeloHcltiporegactiv
                {
                    #region Datos
                    Hcl_secreg_hcca = lobReg["Hcl_secreg_hcca"].ToString(),
                    Hcl_codreg_hcra = lobReg["Hcl_codreg_hcra"].ToString(),
                    Hcl_codreg_hcca = lobReg["Hcl_codreg_hcca"].ToString(),
                    Hcl_desreg_hcca = lobReg["Hcl_desreg_hcca"].ToString(),
                    Grp_idepla_grpl = lobReg["Grp_idepla_grpl"].ToString(),
                    Sys_codtip_sytm = lobReg["Sys_codtip_sytm"].ToString(),
                    Hcl_imagen_hcca = lobReg["Hcl_imagen_hcca"].ToString(),
                    Hcl_icolor_hcca = lobReg["Hcl_icolor_hcca"].ToString(),
                    Hcl_rutarc_hcca = lobReg["Hcl_rutarc_hcca"].ToString(),
                    Hcl_ordvis_hcca = (int)lobReg["Hcl_ordvis_hcca"],
                    Hcl_psubgr_hcca = lobReg["Hcl_psubgr_hcca"].ToString(),
                    Hcl_mededi_hcca = lobReg["Hcl_mededi_hcca"].ToString(),
                    Hcl_edaini_hcca = (int)lobReg["Hcl_edaini_hcca"],
                    Hcl_mededf_hcca = lobReg["Hcl_mededf_hcca"].ToString(),
                    Hcl_edafin_hcca = (int)lobReg["Hcl_edafin_hcca"],
                    Hcl_sexapl_hcca = lobReg["Hcl_sexapl_hcca"].ToString(),
                    Hcl_mededl_hcca = lobReg["Hcl_mededl_hcca"].ToString(),
                    Hcl_listar_hcca = lobReg["Hcl_listar_hcca"].ToString(),
                    Hcl_estreg_hcca = lobReg["Hcl_estreg_hcca"].ToString(),
                    #endregion
                };
                tmpLista.Add(lobRegNew);
            }

            */
            if (llgDatos == false) { tmpLista = null; }

            return tmpLista;
        }
        #endregion
        #endregion
    }

}
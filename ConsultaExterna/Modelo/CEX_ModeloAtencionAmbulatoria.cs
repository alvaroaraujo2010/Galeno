//- MARMOTA-GENCODE: VERSION 2.0 - 03/12/2013 06:38:38 AM
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

namespace ConsultaExterna.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: admregadmision
    /// </summary>
    public class ModeloAtencionAmbulatoria : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
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
        private String _sia_idesec_usua;
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
        private String _sia_tipide_tide;
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
        private String _sia_nroide_usua;
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
        private String _hcl_nrohis_hicl;
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
        private String _cit_codasi_mcit;
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
        private DateTime _adm_fecadm_rgad;
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
        #region Adm_pacemb_rgad: Embarazada SI/NO
        private String _adm_pacemb_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Embarazada SI/NO</para>
        /// <para>NOMBRE: adm_pacemb_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///La paciente esta embarazada : 1=SI 2=NO
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
        private String _adm_reingr_rgad;
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
        private String _adm_codoad_toad;
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
        #region Sia_codare_aser: Código Área de servicios
        private String _sia_codare_aser;
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
        private String _desia_areing_aser;
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
        private String _sia_areing_aser;
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
        #region Adm_codtat_tatn: Tipo ambito de atención
        private String _adm_codtat_tatn;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo ambito de atención</para>
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
        private String _hos_codcam_caho;
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
        private String _hos_codsec_hsec;
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
        private String _sia_dixing_tdia;
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
        private String _adm_caucon_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Causa de Consulta</para>
        /// <para>NOMBRE: adm_caucon_rgad (char:240)</para>
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
        private DateTime _adm_fechos_rgad;
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
        private Decimal _adm_horhos_rgad;
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
        #region Cto_nrocon_cont: Número Contrato
        private String _cto_nrocon_cont;
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
        private String _sia_codeps_teps;
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
        #region Sia_edapac_usua: Edad Paciente
        private int _sia_edapac_usua;
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
        private String _sia_codmed_tmed;
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
        private int _sia_edaano_usua;
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
        private int _sia_edames_usua;
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
        private int _sia_edadia_usua;
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
        private String _sia_edaymd_usua;
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
        private String _sia_codpfa_prof;
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
        private String _adm_nroaut_rgad;
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
        #region Adm_coddsa_tdsa: Destino al salir
        private String _adm_dessal_regr;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admdestinosalir</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: adm_coddsa_tdsa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Código destino al salir del servicio:1= Alta (salida),2=Remisión
        /// a otro nivel,3=Hospitalización
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
        #region Sia_tipusu_regi: Régimen salud usuario
        private String _sia_tipusu_regi;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen salud usuario</para>
        /// <para>NOMBRE: sia_tipusu_regi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Tipo Usuario según régimen:1=CONTRIBUTIVO,2=SUBSIDIADO,3=VINCULADO,4=PART
        /// ICULAR,5=OTRO (Resolucion: 3374 RIPS)
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
        private String _sia_tipafi_tafi;
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
        private String _sia_nivsbn_nsbn;
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
        private String _sia_tippob_tpob;
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
        #region Sia_nivcon_ncon: Nivel Contributivo
        private String _sia_nivcon_ncon;
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
        private String _adm_nomaco_rgad;
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
        private String _adm_diraco_rgad;
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
        private String _adm_telaco_rgad;
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
        private String _adm_nrorem_rgad;
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
        private String _sis_idemun_muni;
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
        private String _sia_codips_tips;
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
        private DateTime _adm_fecrem_rgad;
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
        private int _adm_secite_rgad;
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
        private String _sia_regate_rgat;
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
        private String _adm_estfac_rgad;
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
        private String _adm_estrad_rgad;
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
        private String _adm_liqest_rgad;
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
        private String _adm_ctarip_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Marca Rips Completado</para>
        /// <para>NOMBRE: adm_ctarip_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Marca de Rips Completado: 1=No Completado 2=Rips Completado 3=No Requiere Completado
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
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
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
        private String _sys_codusu_usux;
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
        private int _adm_conest_rgad;
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
        private DateTime _adm_fecedt_rgad;
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
        private String _sis_estpro_espr;
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
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
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
        #region Sia_deside_tide: Descripción Tipo Usuario
        private String _sia_deside_tide;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
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
        #region Hos_descam_caho: Descripcion cama
        private String _hos_descam_caho;
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
        #region Sia_desdia_tdia: Descripcion diagnostico
        private String _sia_desdia_tdia;
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
        #region Cto_descon_cont: Descripción contrato
        private String _cto_descon_cont;
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
        private String _sia_deseps_teps;
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
        #region Sia_desmed_tmed: Descripción medida edad
        private String _sia_desmed_tmed;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Descripción medida edad</para>
        /// <para>NOMBRE: sia_desmed_tmed (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción textual  Mediada edad del Usuario/Paciente
        /// </para>
        /// </summary>
        public String Sia_desmed_tmed
        {
            get { return _sia_desmed_tmed; }
            set
            {
                if (_sia_desmed_tmed == value) return;
                _sia_desmed_tmed = value;
                OnPropertyChanged("Sia_desmed_tmed");
            }
        }
        #endregion
        #region Sia_nompro_prof: Nombre del Profesional
        private String _sia_nompro_prof;
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
        #region Sia_destip_regi: Régimen Salud
        private String _sia_destip_regi;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen Salud</para>
        /// <para>NOMBRE: sia_destip_regi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción régimen de salud Contributivo, Subsidiado y otros(Resol:
        /// 3374 RIPS)
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
        #region Sia_destaf_tafi: Descripción tipo afiliado
        private String _sia_destaf_tafi;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Descripción tipo afiliado</para>
        /// <para>NOMBRE: sia_destaf_tafi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo afiliado contributivo
        /// </para>
        /// </summary>
        public String Sia_destaf_tafi
        {
            get { return _sia_destaf_tafi; }
            set
            {
                if (_sia_destaf_tafi == value) return;
                _sia_destaf_tafi = value;
                OnPropertyChanged("Sia_destaf_tafi");
            }
        }
        #endregion
        #region Sia_dessbn_nsbn: Descripción nivel sisben
        private String _sia_dessbn_nsbn;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Descripción nivel sisben</para>
        /// <para>NOMBRE: sia_dessbn_nsbn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción nivel sisben
        /// </para>
        /// </summary>
        public String Sia_dessbn_nsbn
        {
            get { return _sia_dessbn_nsbn; }
            set
            {
                if (_sia_dessbn_nsbn == value) return;
                _sia_dessbn_nsbn = value;
                OnPropertyChanged("Sia_dessbn_nsbn");
            }
        }
        #endregion
        #region Sia_despob_tpob: Descripción población especial
        private String _sia_despob_tpob;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sia_descon_ncon: Descripción nivel contributivo
        private String _sia_descon_ncon;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Descripción nivel contributivo</para>
        /// <para>NOMBRE: sia_descon_ncon (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción nivel contributivo
        /// </para>
        /// </summary>
        public String Sia_descon_ncon
        {
            get { return _sia_descon_ncon; }
            set
            {
                if (_sia_descon_ncon == value) return;
                _sia_descon_ncon = value;
                OnPropertyChanged("Sia_descon_ncon");
            }
        }
        #endregion
        #region Sis_nommun_muni: Nombre del Muncipio
        private String _sis_nommun_muni;
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
        #region Sis_desdep_dpto: Nombre del departamento segun DANE
        private String _sis_desdep_dpto;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Nombre Departamento segun DANE</para>
        /// <para>NOMBRE: sis_desdep_dpto (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre Departamento segun DANE
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
        #region Sia_desips_tips: Nombre IPS
        private String _sia_desips_tips;
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
        #region Sia_desreg_rgat: Registro de atención
        private String _sia_desreg_rgat;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de atención</para>
        /// <para>NOMBRE: sia_desreg_rgat (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion registro de atencion
        /// </para>
        /// </summary>
        public String Sia_desreg_rgat
        {
            get { return _sia_desreg_rgat; }
            set
            {
                if (_sia_desreg_rgat == value) return;
                _sia_desreg_rgat = value;
                OnPropertyChanged("Sia_desreg_rgat");
            }
        }
        #endregion
        #region Sia_descat_ceat: Descripción centro atención
        private String _sia_descat_ceat;
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
        private String _sys_nomusu_usux;
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
        private String _sis_despro_espr;
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
        #region Sia_fecnac_usua:
        private DateTime _sia_fecnac_usua;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        private String _sis_codsex_sexo;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sis_coddep_dpto:
        private String _sis_coddep_dpto;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        private String _sis_codmun_muni;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region Sis_zonres_tzon:
        private String _sis_zonres_tzon;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siszonaresidenc</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sis_zonres_tzon (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region Sia_tipcot_tcot:
        private String _sia_tipcot_tcot;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipocotizante</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: sia_tipcot_tcot (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public String Sia_tipcot_tcot
        {
            get { return _sia_tipcot_tcot; }
            set
            {
                if (_sia_tipcot_tcot == value) return;
                _sia_tipcot_tcot = value;
                OnPropertyChanged("Sia_tipcot_tcot");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloAtencionAmbulatoria tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("CEX-CONSULA-PACIENTES", "CEX", "Secuencial Unico Atencion consulta ambulatoria");
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
                        sia_codare_aser = tobjModelo.Sia_codare_aser,
                        sia_areing_aser = tobjModelo.Sia_areing_aser,
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
                        sia_edapac_usua = tobjModelo.Sia_edapac_usua,
                        sia_codmed_tmed = tobjModelo.Sia_codmed_tmed,
                        sia_edaano_usua = tobjModelo.Sia_edaano_usua,
                        sia_edames_usua = tobjModelo.Sia_edames_usua,
                        sia_edadia_usua = tobjModelo.Sia_edadia_usua,
                        sia_edaymd_usua = tobjModelo.Sia_edaymd_usua,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        adm_nroaut_rgad = tobjModelo.Adm_nroaut_rgad,
                        adm_dessal_regr = tobjModelo.Adm_dessal_regr,
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
                        sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                        sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                        adm_conest_rgad = tobjModelo.Adm_conest_rgad,
                        adm_fecedt_rgad = tobjModelo.Adm_fecedt_rgad,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.adm_secadm_rgad = lcrCodigoGen;
                    _context.AddToAdmregadmision(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'CEX-CONSULA-PACIENTES': Secuencial Unico Atencion consulta ambulatoria en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloAtencionAmbulatoria tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Admregadmision.FirstOrDefault(p => p.adm_secadm_rgad == tobjModelo.Adm_secadm_rgad);
                if (lobjRegistro != null)
                {
                    lobjRegistro.adm_pacemb_rgad = tobjModelo.Adm_pacemb_rgad;
                    lobjRegistro.adm_reingr_rgad = tobjModelo.Adm_reingr_rgad;
                    lobjRegistro.adm_codoad_toad = tobjModelo.Adm_codoad_toad;
                    lobjRegistro.sia_codare_aser = tobjModelo.Sia_codare_aser;
                    lobjRegistro.sia_areing_aser = tobjModelo.Sia_areing_aser;
                    lobjRegistro.adm_codcex_tcex = tobjModelo.Adm_codcex_tcex;
                    lobjRegistro.hos_codcam_caho = tobjModelo.Hos_codcam_caho;
                    lobjRegistro.hos_codsec_hsec = tobjModelo.Hos_codsec_hsec;
                    lobjRegistro.sia_dixing_tdia = tobjModelo.Sia_dixing_tdia;
                    lobjRegistro.adm_caucon_rgad = tobjModelo.Adm_caucon_rgad;
                    lobjRegistro.adm_dessal_regr = tobjModelo.Adm_dessal_regr;
                    lobjRegistro.adm_estfac_rgad = tobjModelo.Adm_estfac_rgad;
                    lobjRegistro.adm_estrad_rgad = tobjModelo.Adm_estrad_rgad;
                    lobjRegistro.adm_liqest_rgad = tobjModelo.Adm_liqest_rgad;
                    lobjRegistro.adm_ctarip_rgad = tobjModelo.Adm_ctarip_rgad;
                    lobjRegistro.adm_finate_rgad = tobjModelo.Adm_finate_rgad;
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                    lobjRegistro.adm_fecedt_rgad = (DateTime)tobjModelo.Adm_fecedt_rgad;
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
        #region Listar Registros
        public static List<ModeloAtencionAmbulatoria> flsListaAdmregadmision(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from admregadmision in _context.Admregadmision
                                      join siausuarioatend in _context.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatipideusario in _context.Siatipideusario on admregadmision.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                      join admtipoatencion in _context.Admtipoatencion on admregadmision.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                      join ctomaescontrato in _context.Ctomaescontrato on admregadmision.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                      join siatablaeps in _context.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      from tide in tmsiatipideusario.DefaultIfEmpty()
                                      from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from cont in tmctomaescontrato.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      select new ModeloAtencionAmbulatoria
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
                                          Sia_codare_aser = admregadmision.sia_codare_aser,
                                          Sia_areing_aser = admregadmision.sia_areing_aser,
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
                                          Sia_edapac_usua = (int)admregadmision.sia_edapac_usua,
                                          Sia_codmed_tmed = admregadmision.sia_codmed_tmed,
                                          Sia_edaano_usua = (int)admregadmision.sia_edaano_usua,
                                          Sia_edames_usua = (int)admregadmision.sia_edames_usua,
                                          Sia_edadia_usua = (int)admregadmision.sia_edadia_usua,
                                          Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                          Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                          Adm_nroaut_rgad = admregadmision.adm_nroaut_rgad,
                                          Adm_dessal_regr = admregadmision.adm_dessal_regr,
                                          Sia_tipusu_regi = admregadmision.sia_tipusu_regi,
                                          Sia_tipafi_tafi = admregadmision.sia_tipafi_tafi,
                                          Sia_nivsbn_nsbn = admregadmision.sia_nivsbn_nsbn,
                                          Sia_tippob_tpob = admregadmision.sia_tippob_tpob,
                                          Sia_nivcon_ncon = admregadmision.sia_nivcon_ncon,
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
                                          Sia_codcat_ceat = admregadmision.sia_codcat_ceat,
                                          Sys_codusu_usux = admregadmision.sys_codusu_usux,
                                          Adm_conest_rgad = (int)admregadmision.adm_conest_rgad,
                                          Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                          Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                          Sia_deside_tide = tide.sia_deside_tide,
                                          Adm_destat_tatn = tatn.adm_destat_tatn,
                                          Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                          Sis_codsex_sexo = usua.sis_codsex_sexo,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_tipcot_tcot = usua.sia_tipcot_tcot,
                                          Sis_codmun_muni = usua.sis_codmun_muni,
                                          Sis_coddep_dpto = usua.sis_coddep_dpto,
                                          Sis_nommun_muni = _context.Sistabmunicipio.FirstOrDefault(rxp => rxp.sis_idemun_muni == usua.sis_idemun_muni).sis_nommun_muni,
                                          Sis_desdep_dpto = _context.Sistabdepartame.FirstOrDefault(rxp => rxp.sis_coddep_dpto == usua.sis_coddep_dpto).sis_desdep_dpto,
                                          Sia_descat_ceat = _context.Siacentroaten.FirstOrDefault(rxp => rxp.sia_codcat_ceat == admregadmision.sia_codcat_ceat).sia_descat_ceat,
                                          Sia_descon_ncon = _context.Sianivcontribut.FirstOrDefault(rxp => rxp.sia_nivcon_ncon == admregadmision.sia_nivcon_ncon).sia_descon_ncon,
                                          Sia_dessbn_nsbn = _context.Sianivelsisben.FirstOrDefault(rxp => rxp.sia_nivsbn_nsbn == admregadmision.sia_nivsbn_nsbn).sia_dessbn_nsbn,
                                          Sia_destip_regi = _context.Siaregimensalud.FirstOrDefault(rxp => rxp.sia_tipusu_regi == admregadmision.sia_tipusu_regi).sia_destip_regi,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregadmision.sis_estpro_espr).sis_despro_espr,
                                          Sis_zonres_tzon = usua.sis_zonres_tzon,
                                          Cto_descon_cont = cont.cto_descon_cont,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from admregadmision in _context.Admregadmision
                                      join siausuarioatend in _context.Siausuarioatend on admregadmision.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatipideusario in _context.Siatipideusario on admregadmision.sia_tipide_tide equals siatipideusario.sia_tipide_tide into tmsiatipideusario
                                      join admtipoatencion in _context.Admtipoatencion on admregadmision.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                      join ctomaescontrato in _context.Ctomaescontrato on admregadmision.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                      join siatablaeps in _context.Siatablaeps on admregadmision.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      from tide in tmsiatipideusario.DefaultIfEmpty()
                                      from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from cont in tmctomaescontrato.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      where admregadmision.adm_secadm_rgad == tcrBuscar
                                      select new ModeloAtencionAmbulatoria
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
                                          Sia_codare_aser = admregadmision.sia_codare_aser,
                                          Sia_areing_aser = admregadmision.sia_areing_aser,
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
                                          Sia_edapac_usua = (int)admregadmision.sia_edapac_usua,
                                          Sia_codmed_tmed = admregadmision.sia_codmed_tmed,
                                          Sia_edaano_usua = (int)admregadmision.sia_edaano_usua,
                                          Sia_edames_usua = (int)admregadmision.sia_edames_usua,
                                          Sia_edadia_usua = (int)admregadmision.sia_edadia_usua,
                                          Sia_edaymd_usua = admregadmision.sia_edaymd_usua,
                                          Sia_codpfa_prof = admregadmision.sia_codpfa_prof,
                                          Adm_nroaut_rgad = admregadmision.adm_nroaut_rgad,
                                          Adm_dessal_regr = admregadmision.adm_dessal_regr,
                                          Sia_tipusu_regi = admregadmision.sia_tipusu_regi,
                                          Sia_tipafi_tafi = admregadmision.sia_tipafi_tafi,
                                          Sia_nivsbn_nsbn = admregadmision.sia_nivsbn_nsbn,
                                          Sia_tippob_tpob = admregadmision.sia_tippob_tpob,
                                          Sia_nivcon_ncon = admregadmision.sia_nivcon_ncon,
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
                                          Sia_codcat_ceat = admregadmision.sia_codcat_ceat,
                                          Sys_codusu_usux = admregadmision.sys_codusu_usux,
                                          Adm_conest_rgad = (int)admregadmision.adm_conest_rgad,
                                          Adm_fecedt_rgad = (DateTime)admregadmision.adm_fecedt_rgad,
                                          Sis_estpro_espr = admregadmision.sis_estpro_espr,
                                          Sia_deside_tide = tide.sia_deside_tide,
                                          Adm_destat_tatn = tatn.adm_destat_tatn,
                                          Sia_fecnac_usua = (DateTime)usua.sia_fecnac_usua,
                                          Sis_codsex_sexo = usua.sis_codsex_sexo,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_tipcot_tcot = usua.sia_tipcot_tcot,
                                          Sis_codmun_muni = usua.sis_codmun_muni,
                                          Sis_coddep_dpto = usua.sis_coddep_dpto,
                                          Sis_nommun_muni = _context.Sistabmunicipio.FirstOrDefault(rxp => rxp.sis_idemun_muni == usua.sis_idemun_muni).sis_nommun_muni,
                                          Sis_desdep_dpto = _context.Sistabdepartame.FirstOrDefault(rxp => rxp.sis_coddep_dpto == usua.sis_coddep_dpto).sis_desdep_dpto,
                                          Sia_descat_ceat = _context.Siacentroaten.FirstOrDefault(rxp => rxp.sia_codcat_ceat == admregadmision.sia_codcat_ceat).sia_descat_ceat,
                                          Sia_descon_ncon = _context.Sianivcontribut.FirstOrDefault(rxp => rxp.sia_nivcon_ncon == admregadmision.sia_nivcon_ncon).sia_descon_ncon,
                                          Sia_dessbn_nsbn = _context.Sianivelsisben.FirstOrDefault(rxp => rxp.sia_nivsbn_nsbn == admregadmision.sia_nivsbn_nsbn).sia_dessbn_nsbn,
                                          Sia_destip_regi = _context.Siaregimensalud.FirstOrDefault(rxp => rxp.sia_tipusu_regi == admregadmision.sia_tipusu_regi).sia_destip_regi,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == admregadmision.sis_estpro_espr).sis_despro_espr,
                                          Sis_zonres_tzon = usua.sis_zonres_tzon,
                                          Cto_descon_cont = cont.cto_descon_cont,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
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
    /// Descripcion para la Vista de  la tabla: fcmmaedetallfac
    /// </summary>
    public class ModeloDetServicios : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Fcm_secreg_dfac: Código Único registro
        private String _fcm_secreg_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Código Único registro</para>
        /// <para>NOMBRE: fcm_secreg_dfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico del registro o servicio facturado , generado
        /// por el sistema
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
        #region Adm_secadm_rgad: Código Admisión
        private String _adm_secadm_rgad;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión o del registro de atencion ambulatoria
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de d atos ejm: CC= Cedula, RC= Rgistro
        /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin idetificacion
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
        #region Sia_nroide_usua: Numero de Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Secuencial Unico de Contrato
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo de Eps o Asegurador según codigos asignados por la supersalud
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
        #region Con_idesec_mter: Código tercero (contable)
        private String _con_idesec_mter;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: con_idesec_mter (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Código de Empresa cliente y/o tercero EPS o asegurador según
        /// módulos administrativos
        /// </para>
        /// </summary>
        public String Con_idesec_mter
        {
            get { return _con_idesec_mter; }
            set
            {
                if (_con_idesec_mter == value) return;
                _con_idesec_mter = value;
                OnPropertyChanged("Con_idesec_mter");
            }
        }
        #endregion
        #region Fcm_secreg_mfac: Código orden medica
        private String _fcm_secreg_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Código orden medica</para>
        /// <para>NOMBRE: fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la orden medica facturada (generado por
        /// el sistema)
        /// </para>
        /// </summary>
        public String Fcm_secreg_mfac
        {
            get { return _fcm_secreg_mfac; }
            set
            {
                if (_fcm_secreg_mfac == value) return;
                _fcm_secreg_mfac = value;
                OnPropertyChanged("Fcm_secreg_mfac");
            }
        }
        #endregion
        #region Fcm_numfac_mfac: Numero Factura
        private String _fcm_numfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Numero de la factura generada en el cierre de facturación
        /// </para>
        /// </summary>
        public String Fcm_numfac_mfac
        {
            get { return _fcm_numfac_mfac; }
            set
            {
                if (_fcm_numfac_mfac == value) return;
                _fcm_numfac_mfac = value;
                OnPropertyChanged("Fcm_numfac_mfac");
            }
        }
        #endregion
        #region Fcm_fecfac_mfac: Fecha factura
        private DateTime _fcm_fecfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Fecha de la factura (fecha en que fue cerrada y generado el
        /// secuencial de factrua)
        /// </para>
        /// </summary>
        public DateTime Fcm_fecfac_mfac
        {
            get { return _fcm_fecfac_mfac; }
            set
            {
                if (_fcm_fecfac_mfac == value) return;
                _fcm_fecfac_mfac = value;
                OnPropertyChanged("Fcm_fecfac_mfac");
            }
        }
        #endregion
        #region Fcm_estfac_mfac: Estado Factura
        private String _fcm_estfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Estado Factura</para>
        /// <para>NOMBRE: fcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado de la factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public String Fcm_estfac_mfac
        {
            get { return _fcm_estfac_mfac; }
            set
            {
                if (_fcm_estfac_mfac == value) return;
                _fcm_estfac_mfac = value;
                OnPropertyChanged("Fcm_estfac_mfac");
            }
        }
        #endregion
        #region Adm_nroaut_rgad: Numero Autorización
        private String _adm_nroaut_rgad;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Autorización</para>
        /// <para>NOMBRE: adm_nroaut_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Numero Autorizacion solicitada a la EPS o Asegurador para adimision
        /// o servicio que requiera autorizacion
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
        #region Sia_codrip_trip: Tipo servicio RIPS
        private String _sia_codrip_trip;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Tipo servicio RIPS</para>
        /// <para>NOMBRE: sia_codrip_trip (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion  servicio según Resolucion 3374 RIPS:
        /// 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public String Sia_codrip_trip
        {
            get { return _sia_codrip_trip; }
            set
            {
                if (_sia_codrip_trip == value) return;
                _sia_codrip_trip = value;
                OnPropertyChanged("Sia_codrip_trip");
            }
        }
        #endregion
        #region Inv_secart_mart: Código único suministro
        private String _inv_secart_mart;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código único suministro</para>
        /// <para>NOMBRE: inv_secart_mart (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del articulo relacionado con el inventario generado
        /// por el sistema
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
        #region Inv_codart_mart: Código suministro Invent
        private String _inv_codart_mart;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código suministro Invent</para>
        /// <para>NOMBRE: inv_codart_mart (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Codigo del articulo relacionado con el inventario para realizar
        /// descargas cuando se suminstra medicamentos o materiales a pacientes
        /// </para>
        /// </summary>
        public String Inv_codart_mart
        {
            get { return _inv_codart_mart; }
            set
            {
                if (_inv_codart_mart == value) return;
                _inv_codart_mart = value;
                OnPropertyChanged("Inv_codart_mart");
            }
        }
        #endregion
        #region Fcm_idesec_sips: Código servicio IPS
        private String _fcm_idesec_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS habilitado para referencia
        /// y validacion de pertinencia
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
        #region Fcm_codbar_sips: Código de Barras
        private String _fcm_codbar_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código de Barras</para>
        /// <para>NOMBRE: fcm_codbar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Codigo de Barras del Servicio suministro o medicamento (opcional)
        /// </para>
        /// </summary>
        public String Fcm_codbar_sips
        {
            get { return _fcm_codbar_sips; }
            set
            {
                if (_fcm_codbar_sips == value) return;
                _fcm_codbar_sips = value;
                OnPropertyChanged("Fcm_codbar_sips");
            }
        }
        #endregion
        #region Fcm_idesec_mant: Codigo unico tarifario
        private String _fcm_idesec_mant;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Codigo unico tarifario</para>
        /// <para>NOMBRE: fcm_idesec_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del servicio para venta con manual tarifario (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Fcm_idesec_mant
        {
            get { return _fcm_idesec_mant; }
            set
            {
                if (_fcm_idesec_mant == value) return;
                _fcm_idesec_mant = value;
                OnPropertyChanged("Fcm_idesec_mant");
            }
        }
        #endregion
        #region Fcm_codser_mant: Código servicio en tarifario
        private String _fcm_codser_mant;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo en tarifario del servicio para venta y RIPS, pude ser
        /// codigo SOAT ISS o CUPS
        /// </para>
        /// </summary>
        public String Fcm_codser_mant
        {
            get { return _fcm_codser_mant; }
            set
            {
                if (_fcm_codser_mant == value) return;
                _fcm_codser_mant = value;
                OnPropertyChanged("Fcm_codser_mant");
            }
        }
        #endregion
        #region Fcm_coddig_mant: Código digitación servicio
        private String _fcm_coddig_mant;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (puede ser el codigo en el tarifario) es un codigo auxiliar
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
        #region Con_codsco_ccos: Código centro de costo
        private String _con_codsco_ccos;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Para identificar Servicios por centro de costos (desde contabilidad)
        /// </para>
        /// </summary>
        public String Con_codsco_ccos
        {
            get { return _con_codsco_ccos; }
            set
            {
                if (_con_codsco_ccos == value) return;
                _con_codsco_ccos = value;
                OnPropertyChanged("Con_codsco_ccos");
            }
        }
        #endregion
        #region Fcm_codcpr_cpro: Código centro producción
        private String _fcm_codcpr_cpro;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
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
        #region Fcm_desser_dfac: Nombre servicio
        private String _fcm_desser_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_dfac (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public String Fcm_desser_dfac
        {
            get { return _fcm_desser_dfac; }
            set
            {
                if (_fcm_desser_dfac == value) return;
                _fcm_desser_dfac = value;
                OnPropertyChanged("Fcm_desser_dfac");
            }
        }
        #endregion
        #region Fcm_codman_mans: Código manual tarifario
        private String _fcm_codman_mans;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Fcm_fecser_dfac: Fecha servicio
        private DateTime _fcm_fecser_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: fcm_fecser_dfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Fecha de prestacion del servicio
        /// </para>
        /// </summary>
        public DateTime Fcm_fecser_dfac
        {
            get { return _fcm_fecser_dfac; }
            set
            {
                if (_fcm_fecser_dfac == value) return;
                _fcm_fecser_dfac = value;
                OnPropertyChanged("Fcm_fecser_dfac");
            }
        }
        #endregion
        #region Fcm_horser_dfac: Hora Digitación
        private Decimal _fcm_horser_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Hora Digitación</para>
        /// <para>NOMBRE: fcm_horser_dfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Hora  digitacion del servicio en facturacion en formato militar
        /// </para>
        /// </summary>
        public Decimal Fcm_horser_dfac
        {
            get { return _fcm_horser_dfac; }
            set
            {
                if (_fcm_horser_dfac == value) return;
                _fcm_horser_dfac = value;
                OnPropertyChanged("Fcm_horser_dfac");
            }
        }
        #endregion
        #region Fcm_perman_sips: Código Pertenece al manual
        private String _fcm_perman_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código Pertenece al manual</para>
        /// <para>NOMBRE: fcm_perman_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Identificador  para saber si el código del servicio es Realmente
        /// del manual asignado (soat,iss,cups) o fue creado al azar (para
        /// tener presente en planos RIPS): 1=Pertenece al manual 2=Creado
        /// al azar o pertenece a otro manual
        /// </para>
        /// </summary>
        public String Fcm_perman_sips
        {
            get { return _fcm_perman_sips; }
            set
            {
                if (_fcm_perman_sips == value) return;
                _fcm_perman_sips = value;
                OnPropertyChanged("Fcm_perman_sips");
            }
        }
        #endregion
        #region Fcm_forfar_sips: Forma farmacéutica
        private String _fcm_forfar_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Forma farmacéutica</para>
        /// <para>NOMBRE: fcm_forfar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Forma farmaceutica del medicamento (cuando el servicio sea
        /// un medicamento)
        /// </para>
        /// </summary>
        public String Fcm_forfar_sips
        {
            get { return _fcm_forfar_sips; }
            set
            {
                if (_fcm_forfar_sips == value) return;
                _fcm_forfar_sips = value;
                OnPropertyChanged("Fcm_forfar_sips");
            }
        }
        #endregion
        #region Fcm_conmed_sips: Concentración
        private String _fcm_conmed_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Concentración</para>
        /// <para>NOMBRE: fcm_conmed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Concentración del medicamento (cuando el servicio sea un medicamento)
        /// </para>
        /// </summary>
        public String Fcm_conmed_sips
        {
            get { return _fcm_conmed_sips; }
            set
            {
                if (_fcm_conmed_sips == value) return;
                _fcm_conmed_sips = value;
                OnPropertyChanged("Fcm_conmed_sips");
            }
        }
        #endregion
        #region Fcm_unimed_sips: Unidad de medida
        private String _fcm_unimed_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Unidad de medida</para>
        /// <para>NOMBRE: fcm_unimed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Unidad medica del medicamento (cuando el servicio sea un medicamento)
        /// </para>
        /// </summary>
        public String Fcm_unimed_sips
        {
            get { return _fcm_unimed_sips; }
            set
            {
                if (_fcm_unimed_sips == value) return;
                _fcm_unimed_sips = value;
                OnPropertyChanged("Fcm_unimed_sips");
            }
        }
        #endregion
        #region Fcm_autdes_ades: Autorización descuento
        private String _fcm_autdes_ades;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: fcm_autdes_ades (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion  del descuento aprobado para el momento
        /// del pago (generado por el sistema)
        /// </para>
        /// </summary>
        public String Fcm_autdes_ades
        {
            get { return _fcm_autdes_ades; }
            set
            {
                if (_fcm_autdes_ades == value) return;
                _fcm_autdes_ades = value;
                OnPropertyChanged("Fcm_autdes_ades");
            }
        }
        #endregion
        #region Fcm_valser_mant: Valor de servicio
        private float _fcm_valser_mant;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: fcm_valser_mant (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta según manual tarifario
        /// </para>
        /// </summary>
        public float Fcm_valser_mant
        {
            get { return _fcm_valser_mant; }
            set
            {
                if (_fcm_valser_mant == value) return;
                _fcm_valser_mant = value;
                OnPropertyChanged("Fcm_valser_mant");
            }
        }
        #endregion
        #region Fcm_totuni_dfac: Total unidades
        private int _fcm_totuni_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: fcm_totuni_dfac (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Total de unidades facturadas del servicio
        /// </para>
        /// </summary>
        public int Fcm_totuni_dfac
        {
            get { return _fcm_totuni_dfac; }
            set
            {
                if (_fcm_totuni_dfac == value) return;
                _fcm_totuni_dfac = value;
                OnPropertyChanged("Fcm_totuni_dfac");
            }
        }
        #endregion
        #region Fcm_valbru_dfac: Valor bruto factura
        private float _fcm_valbru_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: fcm_valbru_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public float Fcm_valbru_dfac
        {
            get { return _fcm_valbru_dfac; }
            set
            {
                if (_fcm_valbru_dfac == value) return;
                _fcm_valbru_dfac = value;
                OnPropertyChanged("Fcm_valbru_dfac");
            }
        }
        #endregion
        #region Fcm_pordes_dfac: Porcentaje del descuento
        private float _fcm_pordes_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: fcm_pordes_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float Fcm_pordes_dfac
        {
            get { return _fcm_pordes_dfac; }
            set
            {
                if (_fcm_pordes_dfac == value) return;
                _fcm_pordes_dfac = value;
                OnPropertyChanged("Fcm_pordes_dfac");
            }
        }
        #endregion
        #region Fcm_valdes_dfac: Valor del descuento
        private float _fcm_valdes_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: fcm_valdes_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float Fcm_valdes_dfac
        {
            get { return _fcm_valdes_dfac; }
            set
            {
                if (_fcm_valdes_dfac == value) return;
                _fcm_valdes_dfac = value;
                OnPropertyChanged("Fcm_valdes_dfac");
            }
        }
        #endregion
        #region Fcm_poriva_dfac: Porcentaje del IVA
        private float _fcm_poriva_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: fcm_poriva_dfac (float:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Porcentaje del IVA aplicado al servicio
        /// </para>
        /// </summary>
        public float Fcm_poriva_dfac
        {
            get { return _fcm_poriva_dfac; }
            set
            {
                if (_fcm_poriva_dfac == value) return;
                _fcm_poriva_dfac = value;
                OnPropertyChanged("Fcm_poriva_dfac");
            }
        }
        #endregion
        #region Fcm_valiva_dfac: Valor IVA
        private float _fcm_valiva_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: fcm_valiva_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA recuadado en la factura
        /// </para>
        /// </summary>
        public float Fcm_valiva_dfac
        {
            get { return _fcm_valiva_dfac; }
            set
            {
                if (_fcm_valiva_dfac == value) return;
                _fcm_valiva_dfac = value;
                OnPropertyChanged("Fcm_valiva_dfac");
            }
        }
        #endregion
        #region Fcm_valcpa_dfac: Valor copago
        private float _fcm_valcpa_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: fcm_valcpa_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public float Fcm_valcpa_dfac
        {
            get { return _fcm_valcpa_dfac; }
            set
            {
                if (_fcm_valcpa_dfac == value) return;
                _fcm_valcpa_dfac = value;
                OnPropertyChanged("Fcm_valcpa_dfac");
            }
        }
        #endregion
        #region Fcm_valcmo_dfac: Valor cuota moderadora
        private float _fcm_valcmo_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: fcm_valcmo_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public float Fcm_valcmo_dfac
        {
            get { return _fcm_valcmo_dfac; }
            set
            {
                if (_fcm_valcmo_dfac == value) return;
                _fcm_valcmo_dfac = value;
                OnPropertyChanged("Fcm_valcmo_dfac");
            }
        }
        #endregion
        #region Fcm_valusu_dfac: Valor cargo al usuario
        private float _fcm_valusu_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: fcm_valusu_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public float Fcm_valusu_dfac
        {
            get { return _fcm_valusu_dfac; }
            set
            {
                if (_fcm_valusu_dfac == value) return;
                _fcm_valusu_dfac = value;
                OnPropertyChanged("Fcm_valusu_dfac");
            }
        }
        #endregion
        #region Fcm_valcom_dfac: Valor comisión
        private float _fcm_valcom_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor comisión</para>
        /// <para>NOMBRE: fcm_valcom_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Valor comision
        /// </para>
        /// </summary>
        public float Fcm_valcom_dfac
        {
            get { return _fcm_valcom_dfac; }
            set
            {
                if (_fcm_valcom_dfac == value) return;
                _fcm_valcom_dfac = value;
                OnPropertyChanged("Fcm_valcom_dfac");
            }
        }
        #endregion
        #region Fcm_valsub_dfac: Valor subtotal servicio
        private float _fcm_valsub_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: fcm_valsub_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VA
        /// LDES_DFAC)
        /// </para>
        /// </summary>
        public float Fcm_valsub_dfac
        {
            get { return _fcm_valsub_dfac; }
            set
            {
                if (_fcm_valsub_dfac == value) return;
                _fcm_valsub_dfac = value;
                OnPropertyChanged("Fcm_valsub_dfac");
            }
        }
        #endregion
        #region Fcm_valfac_dfac: Valor total facturado
        private float _fcm_valfac_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: fcm_valfac_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public float Fcm_valfac_dfac
        {
            get { return _fcm_valfac_dfac; }
            set
            {
                if (_fcm_valfac_dfac == value) return;
                _fcm_valfac_dfac = value;
                OnPropertyChanged("Fcm_valfac_dfac");
            }
        }
        #endregion
        #region Fcm_valref_dfac: Valor en efectivo
        private float _fcm_valref_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: fcm_valref_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo (solo valor cobrado en efectivo)
        /// por cobros de copagos o valor total del servicio (no siempre
        /// representa el valor total del servicio)
        /// </para>
        /// </summary>
        public float Fcm_valref_dfac
        {
            get { return _fcm_valref_dfac; }
            set
            {
                if (_fcm_valref_dfac == value) return;
                _fcm_valref_dfac = value;
                OnPropertyChanged("Fcm_valref_dfac");
            }
        }
        #endregion
        #region Fcm_valefe_dfac: Valor efectivo final
        private float _fcm_valefe_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor efectivo final</para>
        /// <para>NOMBRE: fcm_valefe_dfac (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Valor final recuadado en efectivo con el descuento realizado
        /// </para>
        /// </summary>
        public float Fcm_valefe_dfac
        {
            get { return _fcm_valefe_dfac; }
            set
            {
                if (_fcm_valefe_dfac == value) return;
                _fcm_valefe_dfac = value;
                OnPropertyChanged("Fcm_valefe_dfac");
            }
        }
        #endregion
        #region Fcm_codtse_sips: Tipo procedimientos o servicios
        private String _fcm_codtse_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo procedimientos o servicios</para>
        /// <para>NOMBRE: fcm_codtse_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Código tipo procedimiento o servicio:  1=Procedimiento  No
        /// Quirúrgico 2= Procedimiento  Quirúrgico 3=Paquete de servicios
        /// 4=No procedimientos
        /// </para>
        /// </summary>
        public String Fcm_codtse_sips
        {
            get { return _fcm_codtse_sips; }
            set
            {
                if (_fcm_codtse_sips == value) return;
                _fcm_codtse_sips = value;
                OnPropertyChanged("Fcm_codtse_sips");
            }
        }
        #endregion
        #region Fcm_codaqx_aqir: Tipo Acto Quirúrgico
        private String _fcm_codaqx_aqir;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmactquirurgic</para>
        /// <para>CAMPO: Tipo Acto Quirúrgico</para>
        /// <para>NOMBRE: fcm_codaqx_aqir (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Codigo forma de realizacion del acto quirurgico (cuando aplique)
        /// ejm: 1=Unico 2=Bilateral misma via y otros
        /// </para>
        /// </summary>
        public String Fcm_codaqx_aqir
        {
            get { return _fcm_codaqx_aqir; }
            set
            {
                if (_fcm_codaqx_aqir == value) return;
                _fcm_codaqx_aqir = value;
                OnPropertyChanged("Fcm_codaqx_aqir");
            }
        }
        #endregion
        #region Sia_tipact_tsac: Tipo servicio o activiad
        private String _sia_tipact_tsac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo servicio o activiad</para>
        /// <para>NOMBRE: sia_tipact_tsac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial
        /// 2=Promocion y Prevencion 3=Salud Publica 4=Todas
        /// </para>
        /// </summary>
        public String Sia_tipact_tsac
        {
            get { return _sia_tipact_tsac; }
            set
            {
                if (_sia_tipact_tsac == value) return;
                _sia_tipact_tsac = value;
                OnPropertyChanged("Sia_tipact_tsac");
            }
        }
        #endregion
        #region Adm_codtat_tatn: Tipo ambito atención
        private String _adm_codtat_tatn;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo ambito atención</para>
        /// <para>NOMBRE: adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Atencion o ambito del servicio:1=Ambulatoria
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
        #region Sia_codfpr_fpor: Finalidad Procedimiento
        private String _sia_codfpr_fpor;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Finalidad Procedimiento</para>
        /// <para>NOMBRE: sia_codfpr_fpor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public String Sia_codfpr_fpor
        {
            get { return _sia_codfpr_fpor; }
            set
            {
                if (_sia_codfpr_fpor == value) return;
                _sia_codfpr_fpor = value;
                OnPropertyChanged("Sia_codfpr_fpor");
            }
        }
        #endregion
        #region Sia_codfco_fcon: Finalidad consulta
        private String _sia_codfco_fcon;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Finalidad consulta</para>
        /// <para>NOMBRE: sia_codfco_fcon (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Finalidad de la consulta:01=Atención del Parto 02=Atencion
        /// del Recien Nacido y demas  según Resolucion 3374 RIPS
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
        #region Adm_codcex_tcex: Causa Externa
        private String _adm_codcex_tcex;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atencion según Resolución:
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
        #region Sia_coddia_tdia: Diagnostico Principal
        private String _sia_coddia_tdia;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico Principal</para>
        /// <para>NOMBRE: sia_coddia_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Codigo del diagnostico principal (para Rips AP o AC cuando
        /// sea requerido)  según la CIE 10, desde la tabla maestra de
        /// diagnosticos
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
        #region Sia_tipdxp_tdix: Tipo de diagnostico
        private String _sia_tipdxp_tdix;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo de diagnostico</para>
        /// <para>NOMBRE: sia_tipdxp_tdix (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// Tipo de diagnostico según CIE 10: 1=impresion diagnostica 2=Confirmado
        /// nuevo y otros
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
        #region Desia_coddx1_tdia: Descripcion diagnostico
        private String _desia_coddx1_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_coddx1_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddx1_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_coddx1_tdia
        {
            get { return _desia_coddx1_tdia; }
            set
            {
                if (_desia_coddx1_tdia == value) return;
                _desia_coddx1_tdia = value;
                OnPropertyChanged("Desia_coddx1_tdia");
            }
        }
        #endregion
        #region Sia_coddx1_tdia: Diagnostico relacionado 1
        private String _sia_coddx1_tdia;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 1</para>
        /// <para>NOMBRE: sia_coddx1_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 1 desde tabla CIE 10
        /// </para>
        /// </summary>
        public String Sia_coddx1_tdia
        {
            get { return _sia_coddx1_tdia; }
            set
            {
                if (_sia_coddx1_tdia == value) return;
                _sia_coddx1_tdia = value;
                OnPropertyChanged("Sia_coddx1_tdia");
            }
        }
        #endregion
        #region Desia_coddx2_tdia: Descripcion diagnostico
        private String _desia_coddx2_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_coddx2_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddx2_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_coddx2_tdia
        {
            get { return _desia_coddx2_tdia; }
            set
            {
                if (_desia_coddx2_tdia == value) return;
                _desia_coddx2_tdia = value;
                OnPropertyChanged("Desia_coddx2_tdia");
            }
        }
        #endregion
        #region Sia_coddx2_tdia: Diagnostico relacionado 2
        private String _sia_coddx2_tdia;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 2</para>
        /// <para>NOMBRE: sia_coddx2_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 2 desde tabla CIE 10
        /// </para>
        /// </summary>
        public String Sia_coddx2_tdia
        {
            get { return _sia_coddx2_tdia; }
            set
            {
                if (_sia_coddx2_tdia == value) return;
                _sia_coddx2_tdia = value;
                OnPropertyChanged("Sia_coddx2_tdia");
            }
        }
        #endregion
        #region Desia_coddx3_tdia: Descripcion diagnostico
        private String _desia_coddx3_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_coddx3_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddx3_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_coddx3_tdia
        {
            get { return _desia_coddx3_tdia; }
            set
            {
                if (_desia_coddx3_tdia == value) return;
                _desia_coddx3_tdia = value;
                OnPropertyChanged("Desia_coddx3_tdia");
            }
        }
        #endregion
        #region Sia_coddx3_tdia: Diagnostico relacionado 3
        private String _sia_coddx3_tdia;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 3</para>
        /// <para>NOMBRE: sia_coddx3_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 3 desde tabla CIE 10
        /// </para>
        /// </summary>
        public String Sia_coddx3_tdia
        {
            get { return _sia_coddx3_tdia; }
            set
            {
                if (_sia_coddx3_tdia == value) return;
                _sia_coddx3_tdia = value;
                OnPropertyChanged("Sia_coddx3_tdia");
            }
        }
        #endregion
        #region Desia_coddxc_tdia: Descripcion diagnostico
        private String _desia_coddxc_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: desia_coddxc_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddxc_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public String Desia_coddxc_tdia
        {
            get { return _desia_coddxc_tdia; }
            set
            {
                if (_desia_coddxc_tdia == value) return;
                _desia_coddxc_tdia = value;
                OnPropertyChanged("Desia_coddxc_tdia");
            }
        }
        #endregion
        #region Sia_coddxc_tdia: Diagnostico complicación
        private String _sia_coddxc_tdia;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico complicación</para>
        /// <para>NOMBRE: sia_coddxc_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de la complizacion según tabla CIE10
        /// </para>
        /// </summary>
        public String Sia_coddxc_tdia
        {
            get { return _sia_coddxc_tdia; }
            set
            {
                if (_sia_coddxc_tdia == value) return;
                _sia_coddxc_tdia = value;
                OnPropertyChanged("Sia_coddxc_tdia");
            }
        }
        #endregion
        #region Sia_codgac_gpyp: Grupo Actividades PyP
        private String _sia_codgac_gpyp;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siagrupoactipyp</para>
        /// <para>CAMPO: Grupo Actividades PyP</para>
        /// <para>NOMBRE: sia_codgac_gpyp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// Grupo de actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public String Sia_codgac_gpyp
        {
            get { return _sia_codgac_gpyp; }
            set
            {
                if (_sia_codgac_gpyp == value) return;
                _sia_codgac_gpyp = value;
                OnPropertyChanged("Sia_codgac_gpyp");
            }
        }
        #endregion
        #region Sia_codact_apyp: Actividades PyP
        private String _sia_codact_apyp;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaactividadpyp</para>
        /// <para>CAMPO: Actividades PyP</para>
        /// <para>NOMBRE: sia_codact_apyp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public String Sia_codact_apyp
        {
            get { return _sia_codact_apyp; }
            set
            {
                if (_sia_codact_apyp == value) return;
                _sia_codact_apyp = value;
                OnPropertyChanged("Sia_codact_apyp");
            }
        }
        #endregion
        #region Fcm_serpos_sips: Servicio POS/NO POS
        private String _fcm_serpos_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio POS/NO POS</para>
        /// <para>NOMBRE: fcm_serpos_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        ///Saber si el servicio esta dentro del POS: 1=SI 2=NO
        /// </para>
        /// </summary>
        public String Fcm_serpos_sips
        {
            get { return _fcm_serpos_sips; }
            set
            {
                if (_fcm_serpos_sips == value) return;
                _fcm_serpos_sips = value;
                OnPropertyChanged("Fcm_serpos_sips");
            }
        }
        #endregion
        #region Cto_tipact_cont: Actividad que cubre Contrato
        private String _cto_tipact_cont;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Actividad que cubre Contrato</para>
        /// <para>NOMBRE: cto_tipact_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// Tipo de actividades o servicios que cubre el contrato: 1=Asistenciales
        /// 2= Promoción y Prevención 3=Salud Publica 4 =Todas
        /// </para>
        /// </summary>
        public String Cto_tipact_cont
        {
            get { return _cto_tipact_cont; }
            set
            {
                if (_cto_tipact_cont == value) return;
                _cto_tipact_cont = value;
                OnPropertyChanged("Cto_tipact_cont");
            }
        }
        #endregion
        #region Sia_codpat_tpat: Tipo de profesional
        private String _sia_codpat_tpat;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de profesional</para>
        /// <para>NOMBRE: sia_codpat_tpat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// Tipo de profesional que atiende el servicio según resolucion
        /// 3374 RIPS: 1=Medico  2= Enfermera y otros
        /// </para>
        /// </summary>
        public String Sia_codpat_tpat
        {
            get { return _sia_codpat_tpat; }
            set
            {
                if (_sia_codpat_tpat == value) return;
                _sia_codpat_tpat = value;
                OnPropertyChanged("Sia_codpat_tpat");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código profesional atiende
        private String _sia_codpfa_prof;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código profesional atiende</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        ///Codigo del Profesional que presta servicio medico
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
        #region Fac_horprs_dfac: Hora servicio
        private Decimal _fac_horprs_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: fac_horprs_dfac (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Hora en que recibe la prestacion del servicio (lo atiende el
        /// profesional) en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public Decimal Fac_horprs_dfac
        {
            get { return _fac_horprs_dfac; }
            set
            {
                if (_fac_horprs_dfac == value) return;
                _fac_horprs_dfac = value;
                OnPropertyChanged("Fac_horprs_dfac");
            }
        }
        #endregion
        #region Fcm_atepro_dfac: Servicio atendido SI/NO
        private String _fcm_atepro_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Servicio atendido SI/NO</para>
        /// <para>NOMBRE: fcm_atepro_dfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// Para confirmar si el servicio ya fue antendido por el profesional
        /// o esta pendiente para ser realizado 1= Servicio pendiente para
        /// profesional 2= Servicio atendido por profesional
        /// </para>
        /// </summary>
        public String Fcm_atepro_dfac
        {
            get { return _fcm_atepro_dfac; }
            set
            {
                if (_fcm_atepro_dfac == value) return;
                _fcm_atepro_dfac = value;
                OnPropertyChanged("Fcm_atepro_dfac");
            }
        }
        #endregion
        #region Sia_codare_aser: Código área servicio
        private String _sia_codare_aser;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área servicio</para>
        /// <para>NOMBRE: sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
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
        #region Desia_aresol_aser: Nombre área de servicios
        private String _desia_aresol_aser;
        /// <summary>
        /// <para>TABLA: siaareapreservi</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: desia_aresol_aser (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_aresol_aser: Descripción área de prestación
        /// servicios médicos
        /// </para>
        /// </summary>
        public String Desia_aresol_aser
        {
            get { return _desia_aresol_aser; }
            set
            {
                if (_desia_aresol_aser == value) return;
                _desia_aresol_aser = value;
                OnPropertyChanged("Desia_aresol_aser");
            }
        }
        #endregion
        #region Sia_aresol_aser: Código área solicita
        private String _sia_aresol_aser;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área solicita</para>
        /// <para>NOMBRE: sia_aresol_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        ///Codigo area que solicita el servicio
        /// </para>
        /// </summary>
        public String Sia_aresol_aser
        {
            get { return _sia_aresol_aser; }
            set
            {
                if (_sia_aresol_aser == value) return;
                _sia_aresol_aser = value;
                OnPropertyChanged("Sia_aresol_aser");
            }
        }
        #endregion
        #region Fcm_tipser_sips: Servicio o Suministro
        private String _fcm_tipser_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio o Suministro</para>
        /// <para>NOMBRE: fcm_tipser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Para diferencia servicios de  medicamentos  y materiales:
        /// 1=Servicio 2=Suministro
        /// </para>
        /// </summary>
        public String Fcm_tipser_sips
        {
            get { return _fcm_tipser_sips; }
            set
            {
                if (_fcm_tipser_sips == value) return;
                _fcm_tipser_sips = value;
                OnPropertyChanged("Fcm_tipser_sips");
            }
        }
        #endregion
        #region Fcm_fecedt_dfac: Fecha ultima modificación
        private DateTime _fcm_fecedt_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Fecha ultima modificación</para>
        /// <para>NOMBRE: fcm_fecedt_dfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// Fecha ultima modificacion realizada por un usario o facturador
        /// </para>
        /// </summary>
        public DateTime Fcm_fecedt_dfac
        {
            get { return _fcm_fecedt_dfac; }
            set
            {
                if (_fcm_fecedt_dfac == value) return;
                _fcm_fecedt_dfac = value;
                OnPropertyChanged("Fcm_fecedt_dfac");
            }
        }
        #endregion
        #region Sys_codusu_usux: Código Digitador
        private String _sys_codusu_usux;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// Código del factuador  usuario del sistema que que realiza la
        /// ultima modificacion
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
        #region Fcm_otserv_sips: Tipo Rips otros servicios
        private String _fcm_otserv_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo Rips otros servicios</para>
        /// <para>NOMBRE: fcm_otserv_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// Tipo rips otros servicios: 1= Materiales e Insumos 2= Traslados
        /// 3= Estancia 4 = Honorarios
        /// </para>
        /// </summary>
        public String Fcm_otserv_sips
        {
            get { return _fcm_otserv_sips; }
            set
            {
                if (_fcm_otserv_sips == value) return;
                _fcm_otserv_sips = value;
                OnPropertyChanged("Fcm_otserv_sips");
            }
        }
        #endregion
        #region Sia_regate_rgat: Registro de Atención
        private String _sia_regate_rgat;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de Atención</para>
        /// <para>NOMBRE: sia_regate_rgat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Tipo Registro  de Atencion: 1 = Admitidos 2=Ambulatoria 3=PyP-Hospitalari
        /// o 4=PyP-Extramural
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
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        ///Centro de Atencion  cuando hay varias sedes
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
        #region Fcm_ripsco_dfac: Rips completados SI/NO
        private String _fcm_ripsco_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Rips completados SI/NO</para>
        /// <para>NOMBRE: fcm_ripsco_dfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si los datos del RIPS fueron completados por
        /// el profesional en la atencion medica: 1=Sin completar 2= Rips
        /// completados
        /// </para>
        /// </summary>
        public String Fcm_ripsco_dfac
        {
            get { return _fcm_ripsco_dfac; }
            set
            {
                if (_fcm_ripsco_dfac == value) return;
                _fcm_ripsco_dfac = value;
                OnPropertyChanged("Fcm_ripsco_dfac");
            }
        }
        #endregion
        #region Inv_codalm_malm: Código almacén
        private String _inv_codalm_malm;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código almacén</para>
        /// <para>NOMBRE: inv_codalm_malm (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Codigo del almacen (desde inventario) desde el cual se descargan
        /// los suministros facturados (cuando aplique según tipo servicio
        /// y el contrato)
        /// </para>
        /// </summary>
        public String Inv_codalm_malm
        {
            get { return _inv_codalm_malm; }
            set
            {
                if (_inv_codalm_malm == value) return;
                _inv_codalm_malm = value;
                OnPropertyChanged("Inv_codalm_malm");
            }
        }
        #endregion
        #region Inv_codgme_mgme: Patrón unidad medida
        private String _inv_codgme_mgme;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Patrón unidad medida</para>
        /// <para>NOMBRE: inv_codgme_mgme (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// Patrón Unidad de Medida (Masa, Volumen, etc) Viene del  almacén
        /// de donde se tome, desde el maestro grupos de medidas
        /// </para>
        /// </summary>
        public String Inv_codgme_mgme
        {
            get { return _inv_codgme_mgme; }
            set
            {
                if (_inv_codgme_mgme == value) return;
                _inv_codgme_mgme = value;
                OnPropertyChanged("Inv_codgme_mgme");
            }
        }
        #endregion
        #region Inv_coduma_muma: Unidad medida descarga
        private String _inv_coduma_muma;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Unidad medida descarga</para>
        /// <para>NOMBRE: inv_coduma_muma (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Unidad de medida para descargar desde  almacén (litros, gramos,
        /// centilitros) Viene del Almacén de donde se tome
        /// </para>
        /// </summary>
        public String Inv_coduma_muma
        {
            get { return _inv_coduma_muma; }
            set
            {
                if (_inv_coduma_muma == value) return;
                _inv_coduma_muma = value;
                OnPropertyChanged("Inv_coduma_muma");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado Registro
        private String _sis_estpro_espr;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Estado del registro según estado de la admision: 1=Abierto
        /// 2=Cerrado 3=Anulado
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
        #region Sia_desrip_trip: Nombre laboratorio
        private String _sia_desrip_trip;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Nombre laboratorio</para>
        /// <para>NOMBRE: sia_desrip_trip (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del  laboratorio que fabrica el medicamento
        /// </para>
        /// </summary>
        public String Sia_desrip_trip
        {
            get { return _sia_desrip_trip; }
            set
            {
                if (_sia_desrip_trip == value) return;
                _sia_desrip_trip = value;
                OnPropertyChanged("Sia_desrip_trip");
            }
        }
        #endregion
        #region Fcm_desaqx_aqir: Descripcion realizacion
        private String _fcm_desaqx_aqir;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmactquirurgic</para>
        /// <para>CAMPO: Descripcion realizacion</para>
        /// <para>NOMBRE: fcm_desaqx_aqir (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Dscripción forma de realizacion del acto quirúrgico
        /// </para>
        /// </summary>
        public String Fcm_desaqx_aqir
        {
            get { return _fcm_desaqx_aqir; }
            set
            {
                if (_fcm_desaqx_aqir == value) return;
                _fcm_desaqx_aqir = value;
                OnPropertyChanged("Fcm_desaqx_aqir");
            }
        }
        #endregion
        #region Sia_desact_tsac: Tipo servicio o actividad
        private String _sia_desact_tsac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo servicio o actividad</para>
        /// <para>NOMBRE: sia_desact_tsac (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción Tipo servico o actividad de salud
        /// </para>
        /// </summary>
        public String Sia_desact_tsac
        {
            get { return _sia_desact_tsac; }
            set
            {
                if (_sia_desact_tsac == value) return;
                _sia_desact_tsac = value;
                OnPropertyChanged("Sia_desact_tsac");
            }
        }
        #endregion
        #region Adm_destat_tatn: Descripción tipo atención
        private String _adm_destat_tatn;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Sia_desdia_tdia: Descripcion diagnostico
        private String _sia_desdia_tdia;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Sia_desare_aser: Nombre área de servicios
        private String _sia_desare_aser;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region Fcm_desest_rips: Descripción estado del Rips
        private String _fcm_desest_rips;
        /// <summary>
        /// <para>TABLA: temporal fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ninguna </para>
        /// <para>CAMPO: Descripción estado del Rips</para>
        /// <para>NOMBRE: fcm_desest_rips (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion estado del Rips: 1=PENDIENTE 2=COMPLETO,
        /// para saber si el registro Rips fue completado al momento de la atención
        /// </para>
        /// </summary>
        public String Fcm_desest_rips
        {
            get { return _fcm_desest_rips; }
            set
            {
                if (_fcm_desest_rips == value) return;
                _fcm_desest_rips = value;
                OnPropertyChanged("Fcm_desest_rips");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloDetServicios tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFfcmmaedetallfac();
                    //-----------------------
                    lobEFReg = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tobTempReg.Fcm_secreg_dfac);
                    #region cargar Registro
                    if (lobEFReg != null)
                    {
                        lobEFReg.fcm_forfar_sips = tobTempReg.Fcm_forfar_sips;
                        lobEFReg.fcm_conmed_sips = tobTempReg.Fcm_conmed_sips;
                        lobEFReg.fcm_unimed_sips = tobTempReg.Fcm_unimed_sips;
                        lobEFReg.fcm_codaqx_aqir = tobTempReg.Fcm_codaqx_aqir;
                        lobEFReg.adm_codtat_tatn = tobTempReg.Adm_codtat_tatn;
                        lobEFReg.sia_codfpr_fpor = tobTempReg.Sia_codfpr_fpor;
                        lobEFReg.sia_codfco_fcon = tobTempReg.Sia_codfco_fcon;
                        lobEFReg.adm_codcex_tcex = tobTempReg.Adm_codcex_tcex;
                        lobEFReg.sia_coddia_tdia = tobTempReg.Sia_coddia_tdia;
                        lobEFReg.sia_tipdxp_tdix = tobTempReg.Sia_tipdxp_tdix;
                        lobEFReg.sia_coddx1_tdia = tobTempReg.Sia_coddx1_tdia;
                        lobEFReg.sia_coddx2_tdia = tobTempReg.Sia_coddx2_tdia;
                        lobEFReg.sia_coddx3_tdia = tobTempReg.Sia_coddx3_tdia;
                        lobEFReg.sia_coddxc_tdia = tobTempReg.Sia_coddxc_tdia;
                        lobEFReg.sia_codpat_tpat = tobTempReg.Sia_codpat_tpat;
                        lobEFReg.sia_codpfa_prof = tobTempReg.Sia_codpfa_prof;
                        lobEFReg.fcm_atepro_dfac = tobTempReg.Fcm_atepro_dfac;
                        lobEFReg.sia_codare_aser = tobTempReg.Sia_codare_aser;
                        lobEFReg.sia_aresol_aser = tobTempReg.Sia_aresol_aser;
                        lobEFReg.fcm_fecedt_dfac = (DateTime)tobTempReg.Fcm_fecedt_dfac;
                        lobEFReg.sys_codusu_usux = tobTempReg.Sys_codusu_usux;
                        lobEFReg.fcm_ripsco_dfac = tobTempReg.Fcm_ripsco_dfac;
                        lobEFReg.sis_estpro_espr = tobTempReg.Sis_estpro_espr;
                    }
                    #endregion
                    //---------------------------
                    // Guardar cambios o eliminar
                    //---------------------------
                    if (lobEFReg != null)
                    {
                        // Modificar el registro
                        _context.SaveChanges();
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
        #region Buscar FCMMAEDETALLFAC: Logica
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TITULO: Detalles servicios medicos prestados</para>
        /// <para>MODULO: FCM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para guardar servicios medicos prestados a pacientes
        /// (detalles de facturacion), cerradas y con numero de factura
        /// asignado a la cual pertenecen
        /// </para>
        /// </summary>
        public static bool flgBuscarFcmmaedetallfac(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Fcmmaedetallfac.FirstOrDefault(p => p.fcm_secreg_dfac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloDetServicios> flsListaFcmmaedetallfac(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from fcmmaedetallfac in _context.Fcmmaedetallfac
                                  join siatablatprips in _context.Siatablatprips on fcmmaedetallfac.sia_codrip_trip equals siatablatprips.sia_codrip_trip into tmsiatablatprips
                                  join fcmactquirurgic in _context.Fcmactquirurgic on fcmmaedetallfac.fcm_codaqx_aqir equals fcmactquirurgic.fcm_codaqx_aqir into tmfcmactquirurgic
                                  join siatipactividad in _context.Siatipactividad on fcmmaedetallfac.sia_tipact_tsac equals siatipactividad.sia_tipact_tsac into tmsiatipactividad
                                  join admtipoatencion in _context.Admtipoatencion on fcmmaedetallfac.adm_codtat_tatn equals admtipoatencion.adm_codtat_tatn into tmadmtipoatencion
                                  join siadiagnosticos in _context.Siadiagnosticos on fcmmaedetallfac.sia_coddia_tdia equals siadiagnosticos.sia_coddia_tdia into tmsiadiagnosticos
                                  from tatn in tmadmtipoatencion.DefaultIfEmpty()
                                  from trip in tmsiatablatprips.DefaultIfEmpty()
                                  from aqir in tmfcmactquirurgic.DefaultIfEmpty()
                                  from tsac in tmsiatipactividad.DefaultIfEmpty()
                                  from tdia in tmsiadiagnosticos.DefaultIfEmpty()
                                  where fcmmaedetallfac.adm_secadm_rgad == tcrBuscar
                                  select new ModeloDetServicios
                                  {
                                      Fcm_secreg_dfac = fcmmaedetallfac.fcm_secreg_dfac,
                                      Adm_secadm_rgad = fcmmaedetallfac.adm_secadm_rgad,
                                      Sia_idesec_usua = fcmmaedetallfac.sia_idesec_usua,
                                      Sia_tipide_tide = fcmmaedetallfac.sia_tipide_tide,
                                      Sia_nroide_usua = fcmmaedetallfac.sia_nroide_usua,
                                      Cto_seccon_cont = fcmmaedetallfac.cto_seccon_cont,
                                      Cto_nrocon_cont = fcmmaedetallfac.cto_nrocon_cont,
                                      Sia_codeps_teps = fcmmaedetallfac.sia_codeps_teps,
                                      Con_idesec_mter = fcmmaedetallfac.sis_idterc_sitr,
                                      Fcm_secreg_mfac = fcmmaedetallfac.fcm_secreg_mfac,
                                      Fcm_numfac_mfac = fcmmaedetallfac.fcm_numfac_mfac,
                                      Fcm_fecfac_mfac = (DateTime)fcmmaedetallfac.fcm_fecfac_mfac,
                                      Fcm_estfac_mfac = fcmmaedetallfac.fcm_estfac_mfac,
                                      Adm_nroaut_rgad = fcmmaedetallfac.adm_nroaut_rgad,
                                      Sia_codrip_trip = fcmmaedetallfac.sia_codrip_trip,
                                      Fcm_idesec_sips = fcmmaedetallfac.fcm_idesec_sips,
                                      Fcm_codbar_sips = fcmmaedetallfac.fcm_codbar_sips,
                                      Fcm_idesec_mant = fcmmaedetallfac.fcm_idesec_mant,
                                      Fcm_codser_mant = fcmmaedetallfac.fcm_codser_mant,
                                      Fcm_coddig_mant = fcmmaedetallfac.fcm_coddig_mant,
                                      Con_codsco_ccos = fcmmaedetallfac.con_codsco_ccos,
                                      Fcm_codcpr_cpro = fcmmaedetallfac.fcm_codcpr_cpro,
                                      Fcm_desser_dfac = fcmmaedetallfac.fcm_desser_dfac,
                                      Fcm_codman_mans = fcmmaedetallfac.fcm_codman_mans,
                                      Fcm_fecser_dfac = (DateTime)fcmmaedetallfac.fcm_fecser_dfac,
                                      Fcm_horser_dfac = (Decimal)fcmmaedetallfac.fcm_horser_dfac,
                                      Fcm_perman_sips = fcmmaedetallfac.fcm_perman_sips,
                                      Fcm_forfar_sips = fcmmaedetallfac.fcm_forfar_sips,
                                      Fcm_conmed_sips = fcmmaedetallfac.fcm_conmed_sips,
                                      Fcm_unimed_sips = fcmmaedetallfac.fcm_unimed_sips,
                                      Fcm_autdes_ades = fcmmaedetallfac.fcm_autdes_ades,
                                      Fcm_valser_mant = (float)fcmmaedetallfac.fcm_valser_mant,
                                      Fcm_totuni_dfac = (int)fcmmaedetallfac.fcm_totuni_dfac,
                                      Fcm_valbru_dfac = (float)fcmmaedetallfac.fcm_valbru_dfac,
                                      Fcm_pordes_dfac = (float)fcmmaedetallfac.fcm_pordes_dfac,
                                      Fcm_valdes_dfac = (float)fcmmaedetallfac.fcm_valdes_dfac,
                                      Fcm_poriva_dfac = (float)fcmmaedetallfac.fcm_poriva_dfac,
                                      Fcm_valiva_dfac = (float)fcmmaedetallfac.fcm_valiva_dfac,
                                      Fcm_valcpa_dfac = (float)fcmmaedetallfac.fcm_valcpa_dfac,
                                      Fcm_valcmo_dfac = (float)fcmmaedetallfac.fcm_valcmo_dfac,
                                      Fcm_valusu_dfac = (float)fcmmaedetallfac.fcm_valusu_dfac,
                                      Fcm_valcom_dfac = (float)fcmmaedetallfac.fcm_valcom_dfac,
                                      Fcm_valsub_dfac = (float)fcmmaedetallfac.fcm_valsub_dfac,
                                      Fcm_valfac_dfac = (float)fcmmaedetallfac.fcm_valfac_dfac,
                                      Fcm_valref_dfac = (float)fcmmaedetallfac.fcm_valref_dfac,
                                      Fcm_valefe_dfac = (float)fcmmaedetallfac.fcm_valefe_dfac,
                                      Fcm_codtse_sips = fcmmaedetallfac.fcm_codtse_sips,
                                      Fcm_codaqx_aqir = fcmmaedetallfac.fcm_codaqx_aqir,
                                      Sia_tipact_tsac = fcmmaedetallfac.sia_tipact_tsac,
                                      Adm_codtat_tatn = fcmmaedetallfac.adm_codtat_tatn,
                                      Sia_codfpr_fpor = fcmmaedetallfac.sia_codfpr_fpor,
                                      Sia_codfco_fcon = fcmmaedetallfac.sia_codfco_fcon,
                                      Adm_codcex_tcex = fcmmaedetallfac.adm_codcex_tcex,
                                      Sia_coddia_tdia = fcmmaedetallfac.sia_coddia_tdia,
                                      Sia_tipdxp_tdix = fcmmaedetallfac.sia_tipdxp_tdix,
                                      Sia_coddx1_tdia = fcmmaedetallfac.sia_coddx1_tdia,
                                      Desia_coddx1_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == fcmmaedetallfac.sia_coddx1_tdia).sia_desdia_tdia,
                                      Sia_coddx2_tdia = fcmmaedetallfac.sia_coddx2_tdia,
                                      Desia_coddx2_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == fcmmaedetallfac.sia_coddx2_tdia).sia_desdia_tdia,
                                      Sia_coddx3_tdia = fcmmaedetallfac.sia_coddx3_tdia,
                                      Desia_coddx3_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == fcmmaedetallfac.sia_coddx3_tdia).sia_desdia_tdia,
                                      Sia_coddxc_tdia = fcmmaedetallfac.sia_coddxc_tdia,
                                      Desia_coddxc_tdia = _context.Siadiagnosticos.FirstOrDefault(rxp => rxp.sia_coddia_tdia == fcmmaedetallfac.sia_coddxc_tdia).sia_desdia_tdia,
                                      Sia_codgac_gpyp = fcmmaedetallfac.sia_codgac_gpyp,
                                      Sia_codact_apyp = fcmmaedetallfac.sia_codact_apyp,
                                      Fcm_serpos_sips = fcmmaedetallfac.fcm_serpos_sips,
                                      Cto_tipact_cont = fcmmaedetallfac.cto_tipact_cont,
                                      Sia_codpat_tpat = fcmmaedetallfac.sia_codpat_tpat,
                                      Sia_codpfa_prof = fcmmaedetallfac.sia_codpfa_prof,
                                      Fac_horprs_dfac = (Decimal)fcmmaedetallfac.fac_horprs_dfac,
                                      Fcm_atepro_dfac = fcmmaedetallfac.fcm_atepro_dfac,
                                      Sia_codare_aser = fcmmaedetallfac.sia_codare_aser,
                                      Sia_aresol_aser = fcmmaedetallfac.sia_aresol_aser,
                                      Desia_aresol_aser = _context.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == fcmmaedetallfac.sia_aresol_aser).sia_desare_aser,
                                      Fcm_tipser_sips = fcmmaedetallfac.fcm_tipser_sips,
                                      Fcm_fecedt_dfac = (DateTime)fcmmaedetallfac.fcm_fecedt_dfac,
                                      Sys_codusu_usux = fcmmaedetallfac.sys_codusu_usux,
                                      Fcm_otserv_sips = fcmmaedetallfac.fcm_otserv_sips,
                                      Sia_regate_rgat = fcmmaedetallfac.sia_regate_rgat,
                                      Sia_codcat_ceat = fcmmaedetallfac.sia_codcat_ceat,
                                      Fcm_ripsco_dfac = fcmmaedetallfac.fcm_ripsco_dfac,
                                      Inv_codgme_mgme = fcmmaedetallfac.inv_codgme_mgme,
                                      Inv_coduma_muma = fcmmaedetallfac.inv_coduma_muma,
                                      Sis_estpro_espr = fcmmaedetallfac.sis_estpro_espr,
                                      Adm_destat_tatn = tatn.adm_destat_tatn,
                                      Sia_desrip_trip = trip.sia_desrip_trip,
                                      Sia_desdia_tdia = tdia.sia_desdia_tdia,
                                      Sia_desdxp_tdix = _context.Siatipodiagprin.FirstOrDefault(rxp => rxp.sia_tipdxp_tdix == fcmmaedetallfac.sia_tipdxp_tdix).sia_desdxp_tdix,
                                      Sia_desare_aser = _context.Siaareapreservi.FirstOrDefault(rxp => rxp.sia_codare_aser == fcmmaedetallfac.sia_codare_aser).sia_desare_aser,
                                      Fcm_desaqx_aqir = aqir.fcm_desaqx_aqir,
                                      Sia_desact_tsac = tsac.sia_desact_tsac,
                                      Fcm_desest_rips = fcmmaedetallfac.fcm_ripsco_dfac=="2" ? "COMPLETO": "PENDIENTE",
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// Tabla : cita atendida por el profesional 
    /// </summary>
    public class ModeloCitaAtendida : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modificar Registro
        /// <summary>
        /// Actaulizar como estado 4=Atendido en registro maestro de citas 
        /// </summary>
        /// <param name="tcrCodigoCita">Codigo registro cita en maestro citas</param>
        /// <param name="tcrEstado">Estado para actualziar en registro maestro citas</param>
        public static void fcrActualizar(String tcrCodigoCita, String tcrEstado)
        {
            using (_context = new DbAplicacion())
            {
                if (!String.IsNullOrWhiteSpace(tcrCodigoCita))
                {
                    var lobjRegistro = _context.Citmaesasigcita.FirstOrDefault(p => p.cit_codasi_mcit == tcrCodigoCita);
                    if (lobjRegistro != null)
                    {
                        lobjRegistro.cit_estcit_easi = tcrEstado;
                        _context.SaveChanges();
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}
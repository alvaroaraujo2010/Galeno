//- MARMOTA-GENCODE: VERSION 2.0 - 16/04/2014 07:22:51 AM
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

namespace ConfigAsistencial.Modelo
{
    /*
    /// <summary>
    /// Descripcion para la Vista de  la tabla: siausuarioatend
    /// </summary>
    public class ModeloSiaUsuariosAtendidos : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de paciente en el sistema, se genera al momento
        /// de crear el registro o cuando la base de datos es cargada en
        /// el sistema
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
        #region Hcl_nrohis_hicl: Historia Clínica
        private String _hcl_nrohis_hicl;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Historia Clínica</para>
        /// <para>NOMBRE: hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        #region Sia_codeps_teps: Código Eps/Asegurador
        private String _sia_codeps_teps;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código Eps/Asegurador</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según Listado EPS Ministerio Protección
        /// social
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
        #region Sia_tipide_tide: Tipo Identificación
        private String _sia_tipide_tide;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_fecnac_usua: Fecha nacimiento
        private DateTime _sia_fecnac_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_tipusu_regi: Régimen salud
        private String _sia_tipusu_regi;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen salud</para>
        /// <para>NOMBRE: sia_tipusu_regi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        #region Sia_tipcot_tcot: Tipo cotizante
        private String _sia_tipcot_tcot;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipocotizante</para>
        /// <para>CAMPO: Tipo cotizante</para>
        /// <para>NOMBRE: sia_tipcot_tcot (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Tipo Afiliado cotizante para el contributivo según Resolución:
        /// 1344 de 2012 BDUA
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
        #region Sia_tipafi_tafi: Tipo Afiliado Contributivo
        private String _sia_tipafi_tafi;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Tipo Afiliado Contributivo</para>
        /// <para>NOMBRE: sia_tipafi_tafi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Tipo Afiliado contributivo: C=Cotizante B=Beneficiario A=Adicional
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
        #region Sia_tippob_tpob: Tipo población especial
        private String _sia_tippob_tpob;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatippoblacion</para>
        /// <para>CAMPO: Tipo población especial</para>
        /// <para>NOMBRE: sia_tippob_tpob (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Código del tipo poblacional especial para subsidiado, según
        /// normas de base de datos Resol: 1344 de 2012  BDUA: 1= Habitante
        /// de la calle 2= Población Infantil y mas
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
        #region Sia_nivsbn_nsbn: Nivel Sisben
        private String _sia_nivsbn_nsbn;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Nivel Sisben</para>
        /// <para>NOMBRE: sia_nivsbn_nsbn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Sisben para cobro de copagos  según Resolución:
        /// 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N
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
        #region Sia_nivcon_ncon: Nivel Contributivo
        private String _sia_nivcon_ncon;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Nivel Contributivo</para>
        /// <para>NOMBRE: sia_nivcon_ncon (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras
        /// y copagos según Acuerdo 260 de 2004
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
        #region Sis_idemun_muni: Id Único Municipio
        private String _sis_idemun_muni;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Id Único Municipio</para>
        /// <para>NOMBRE: sis_idemun_muni (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Código Municipio</para>
        /// <para>NOMBRE: sis_codmun_muni (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Código Departamento</para>
        /// <para>NOMBRE: sis_coddep_dpto (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
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
        #region Sia_feceps_usua: Fecha afiliación EPS
        private DateTime _sia_feceps_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha afiliación EPS</para>
        /// <para>NOMBRE: sia_feceps_usua (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Fecha afiliación a EPS o asegurador
        /// </para>
        /// </summary>
        public DateTime Sia_feceps_usua
        {
            get { return _sia_feceps_usua; }
            set
            {
                if (_sia_feceps_usua == value) return;
                _sia_feceps_usua = value;
                OnPropertyChanged("Sia_feceps_usua");
            }
        }
        #endregion
        #region Cto_seccon_cont: Secuencial de Contrato
        private String _cto_seccon_cont;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
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
        #region Desia_tpidap_tide: Descripción Tipo Usuario
        private String _desia_tpidap_tide;
        /// <summary>
        /// <para>TABLA: siatipideusario</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Descripción Tipo Usuario</para>
        /// <para>NOMBRE: desia_tpidap_tide (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_tpidap_tide: Descripción textual del Tipo
        /// de identificación para el usuario o paciente
        /// </para>
        /// </summary>
        public String Desia_tpidap_tide
        {
            get { return _desia_tpidap_tide; }
            set
            {
                if (_desia_tpidap_tide == value) return;
                _desia_tpidap_tide = value;
                OnPropertyChanged("Desia_tpidap_tide");
            }
        }
        #endregion
        #region Sia_tpidap_tide: Tipo id aportante
        private String _sia_tpidap_tide;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo id aportante</para>
        /// <para>NOMBRE: sia_tpidap_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Tipo identificación del aportante para contributivo
        /// </para>
        /// </summary>
        public String Sia_tpidap_tide
        {
            get { return _sia_tpidap_tide; }
            set
            {
                if (_sia_tpidap_tide == value) return;
                _sia_tpidap_tide = value;
                OnPropertyChanged("Sia_tpidap_tide");
            }
        }
        #endregion
        #region Sia_ideapo_usua: Identificación aportante
        private String _sia_ideapo_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación aportante</para>
        /// <para>NOMBRE: sia_ideapo_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Numero identificación del aportante
        /// </para>
        /// </summary>
        public String Sia_ideapo_usua
        {
            get { return _sia_ideapo_usua; }
            set
            {
                if (_sia_ideapo_usua == value) return;
                _sia_ideapo_usua = value;
                OnPropertyChanged("Sia_ideapo_usua");
            }
        }
        #endregion
        #region Sia_modsub_usua: Modalidad subsidio
        private String _sia_modsub_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Modalidad subsidio</para>
        /// <para>NOMBRE: sia_modsub_usua (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Modalidad del subsidio para el régimen subsidiado: ST =Subsidio
        /// total
        /// </para>
        /// </summary>
        public String Sia_modsub_usua
        {
            get { return _sia_modsub_usua; }
            set
            {
                if (_sia_modsub_usua == value) return;
                _sia_modsub_usua = value;
                OnPropertyChanged("Sia_modsub_usua");
            }
        }
        #endregion
        #region Sia_discap_usua: Discapacidad SI/NO
        private String _sia_discap_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Discapacidad SI/NO</para>
        /// <para>NOMBRE: sia_discap_usua (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        ///Alguna discapacidad SI/NO
        /// </para>
        /// </summary>
        public String Sia_discap_usua
        {
            get { return _sia_discap_usua; }
            set
            {
                if (_sia_discap_usua == value) return;
                _sia_discap_usua = value;
                OnPropertyChanged("Sia_discap_usua");
            }
        }
        #endregion
        #region Sia_tipdis_tdis: Tipo discapacidad
        private String _sia_tipdis_tdis;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_edapac_usua: Edad Paciente
        private int _sia_edapac_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad Paciente</para>
        /// <para>NOMBRE: sia_edapac_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Medida Edad</para>
        /// <para>NOMBRE: sia_codmed_tmed (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en años</para>
        /// <para>NOMBRE: sia_edaano_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en meses</para>
        /// <para>NOMBRE: sia_edames_usua (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en días</para>
        /// <para>NOMBRE: sia_edadia_usua (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad formato largo</para>
        /// <para>NOMBRE: sia_edaymd_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Edad en formato largo ejemplo: (20 años 8 meses 16 dias)
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
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Centro de Atención  (cuando hay varias sedes) donde el usuario
        /// debe recibir la atención
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
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
        #region Sia_fecedt_usua: Fecha ultima edición
        private DateTime _sia_fecedt_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha ultima edición</para>
        /// <para>NOMBRE: sia_fecedt_usua (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Fecha ultima edición
        /// </para>
        /// </summary>
        public DateTime Sia_fecedt_usua
        {
            get { return _sia_fecedt_usua; }
            set
            {
                if (_sia_fecedt_usua == value) return;
                _sia_fecedt_usua = value;
                OnPropertyChanged("Sia_fecedt_usua");
            }
        }
        #endregion
        #region Sia_llaveb_usua: llave búsqueda
        private String _sia_llaveb_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: llave búsqueda</para>
        /// <para>NOMBRE: sia_llaveb_usua (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// llave de búsqueda avanzada concatena:tipo ide+ identificacion+apellidos+n
        /// ombres+fecha nacimiento+eps
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
        #region Sis_estreg_esrg: Código Estado Registro
        private String _sis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
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
        #region Sia_deseps_teps: Nombre EPS
        private String _sia_deseps_teps;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_deside_tide: Descripción Tipo Usuario
        private String _sia_deside_tide;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sis_dessex_sexo: Sexo
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
        #region Sia_destip_regi: Régimen Salud
        private String _sia_destip_regi;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_descot_tcot: Descripción tipo cotizante
        private String _sia_descot_tcot;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipocotizante</para>
        /// <para>CAMPO: Descripción tipo cotizante</para>
        /// <para>NOMBRE: sia_descot_tcot (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo cotizante
        /// </para>
        /// </summary>
        public String Sia_descot_tcot
        {
            get { return _sia_descot_tcot; }
            set
            {
                if (_sia_descot_tcot == value) return;
                _sia_descot_tcot = value;
                OnPropertyChanged("Sia_descot_tcot");
            }
        }
        #endregion
        #region Sia_destaf_tafi: Descripción tipo afiliado
        private String _sia_destaf_tafi;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_despob_tpob: Descripción población especial
        private String _sia_despob_tpob;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_dessbn_nsbn: Descripción nivel sisben
        private String _sia_dessbn_nsbn;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_descon_ncon: Descripción nivel contributivo
        private String _sia_descon_ncon;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sis_deszon_tzon: Zona de residencia
        private String _sis_deszon_tzon;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siszonaresidenc</para>
        /// <para>CAMPO: Zona de residencia</para>
        /// <para>NOMBRE: sis_deszon_tzon (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion zona  recidencia
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
        #region Sis_desocu_ocup: Descripción ocupacion
        private String _sis_desocu_ocup;
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
        public String Sis_desocu_ocup
        {
            get { return _sis_desocu_ocup; }
            set
            {
                if (_sis_desocu_ocup == value) return;
                _sis_desocu_ocup = value;
                OnPropertyChanged("Sis_desocu_ocup");
            }
        }
        #endregion
        #region Cto_descon_cont: Descripción contrato
        private String _cto_descon_cont;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_desdis_tdis: Descripción discapacidad
        private String _sia_desdis_tdis;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_desmed_tmed: Descripción medida edad
        private String _sia_desmed_tmed;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sia_descat_ceat: Descripción centro atención
        private String _sia_descat_ceat;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        #region Sis_desest_esrg: Decripción estado registro
        private String _sis_desest_esrg;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        public static string flgAddRegistro(ModeloSiaUsuariosAtendidos tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("SIA-MAE-USUARIOS-ATENDIDOS", "SIA", "Maestro de usuarios atendidos");
            if (!flgBuscarSiausuarioatend(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFsiausuarioatend
                    {
                        #region cargar Registro
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl,
                        sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                        sia_tipide_tide = tobjModelo.Sia_tipide_tide,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        sia_priape_usua = tobjModelo.Sia_priape_usua,
                        sia_segape_usua = tobjModelo.Sia_segape_usua,
                        sia_prinom_usua = tobjModelo.Sia_prinom_usua,
                        sia_segnom_usua = tobjModelo.Sia_segnom_usua,
                        sia_fecnac_usua = tobjModelo.Sia_fecnac_usua,
                        sis_codsex_sexo = tobjModelo.Sis_codsex_sexo,
                        sia_nomusu_usua = tobjModelo.Sia_nomusu_usua,
                        sia_tipusu_regi = tobjModelo.Sia_tipusu_regi,
                        sia_tipcot_tcot = tobjModelo.Sia_tipcot_tcot,
                        sia_tipafi_tafi = tobjModelo.Sia_tipafi_tafi,
                        sia_tippob_tpob = tobjModelo.Sia_tippob_tpob,
                        sia_nivsbn_nsbn = tobjModelo.Sia_nivsbn_nsbn,
                        sia_nivcon_ncon = tobjModelo.Sia_nivcon_ncon,
                        sis_idemun_muni = tobjModelo.Sis_idemun_muni,
                        sis_codmun_muni = tobjModelo.Sis_codmun_muni,
                        sis_coddep_dpto = tobjModelo.Sis_coddep_dpto,
                        sis_zonres_tzon = tobjModelo.Sis_zonres_tzon,
                        sia_telres_usua = tobjModelo.Sia_telres_usua,
                        sia_dirres_usua = tobjModelo.Sia_dirres_usua,
                        sia_correo_usua = tobjModelo.Sia_correo_usua,
                        sis_codocu_ocup = tobjModelo.Sis_codocu_ocup,
                        sia_feceps_usua = tobjModelo.Sia_feceps_usua,
                        cto_seccon_cont = tobjModelo.Cto_seccon_cont,
                        cto_nrocon_cont = tobjModelo.Cto_nrocon_cont,
                        sia_tpidap_tide = tobjModelo.Sia_tpidap_tide,
                        sia_ideapo_usua = tobjModelo.Sia_ideapo_usua,
                        sia_modsub_usua = tobjModelo.Sia_modsub_usua,
                        sia_discap_usua = tobjModelo.Sia_discap_usua,
                        sia_tipdis_tdis = tobjModelo.Sia_tipdis_tdis,
                        sia_edapac_usua = tobjModelo.Sia_edapac_usua,
                        sia_codmed_tmed = tobjModelo.Sia_codmed_tmed,
                        sia_edaano_usua = tobjModelo.Sia_edaano_usua,
                        sia_edames_usua = tobjModelo.Sia_edames_usua,
                        sia_edadia_usua = tobjModelo.Sia_edadia_usua,
                        sia_edaymd_usua = tobjModelo.Sia_edaymd_usua,
                        sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                        sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                        sia_fecedt_usua = tobjModelo.Sia_fecedt_usua,
                        sia_llaveb_usua = tobjModelo.Sia_llaveb_usua,
                        sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                        #endregion
                    };
                    lobjRegistro.sia_idesec_usua = lcrCodigoGen;
                    _context.AddToSiausuarioatend(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'SIA-MAE-USUARIOS-ATENDIDOS': Maestro de usuarios atendidos en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSiaUsuariosAtendidos tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siausuarioatend.FirstOrDefault(p => p.sia_idesec_usua == tobjModelo.Sia_idesec_usua);
                if (lobjRegistro != null)
                {
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.hcl_nrohis_hicl = tobjModelo.Hcl_nrohis_hicl;
                    lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                    lobjRegistro.sia_tipide_tide = tobjModelo.Sia_tipide_tide;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.sia_priape_usua = tobjModelo.Sia_priape_usua;
                    lobjRegistro.sia_segape_usua = tobjModelo.Sia_segape_usua;
                    lobjRegistro.sia_prinom_usua = tobjModelo.Sia_prinom_usua;
                    lobjRegistro.sia_segnom_usua = tobjModelo.Sia_segnom_usua;
                    lobjRegistro.sia_fecnac_usua = (DateTime)tobjModelo.Sia_fecnac_usua;
                    lobjRegistro.sis_codsex_sexo = tobjModelo.Sis_codsex_sexo;
                    lobjRegistro.sia_nomusu_usua = tobjModelo.Sia_nomusu_usua;
                    lobjRegistro.sia_tipusu_regi = tobjModelo.Sia_tipusu_regi;
                    lobjRegistro.sia_tipcot_tcot = tobjModelo.Sia_tipcot_tcot;
                    lobjRegistro.sia_tipafi_tafi = tobjModelo.Sia_tipafi_tafi;
                    lobjRegistro.sia_tippob_tpob = tobjModelo.Sia_tippob_tpob;
                    lobjRegistro.sia_nivsbn_nsbn = tobjModelo.Sia_nivsbn_nsbn;
                    lobjRegistro.sia_nivcon_ncon = tobjModelo.Sia_nivcon_ncon;
                    lobjRegistro.sis_idemun_muni = tobjModelo.Sis_idemun_muni;
                    lobjRegistro.sis_codmun_muni = tobjModelo.Sis_codmun_muni;
                    lobjRegistro.sis_coddep_dpto = tobjModelo.Sis_coddep_dpto;
                    lobjRegistro.sis_zonres_tzon = tobjModelo.Sis_zonres_tzon;
                    lobjRegistro.sia_telres_usua = tobjModelo.Sia_telres_usua;
                    lobjRegistro.sia_dirres_usua = tobjModelo.Sia_dirres_usua;
                    lobjRegistro.sia_correo_usua = tobjModelo.Sia_correo_usua;
                    lobjRegistro.sis_codocu_ocup = tobjModelo.Sis_codocu_ocup;
                    lobjRegistro.sia_feceps_usua = (DateTime)tobjModelo.Sia_feceps_usua;
                    lobjRegistro.cto_seccon_cont = tobjModelo.Cto_seccon_cont;
                    lobjRegistro.cto_nrocon_cont = tobjModelo.Cto_nrocon_cont;
                    lobjRegistro.sia_tpidap_tide = tobjModelo.Sia_tpidap_tide;
                    lobjRegistro.sia_ideapo_usua = tobjModelo.Sia_ideapo_usua;
                    lobjRegistro.sia_modsub_usua = tobjModelo.Sia_modsub_usua;
                    lobjRegistro.sia_discap_usua = tobjModelo.Sia_discap_usua;
                    lobjRegistro.sia_tipdis_tdis = tobjModelo.Sia_tipdis_tdis;
                    lobjRegistro.sia_edapac_usua = (int)tobjModelo.Sia_edapac_usua;
                    lobjRegistro.sia_codmed_tmed = tobjModelo.Sia_codmed_tmed;
                    lobjRegistro.sia_edaano_usua = (int)tobjModelo.Sia_edaano_usua;
                    lobjRegistro.sia_edames_usua = (int)tobjModelo.Sia_edames_usua;
                    lobjRegistro.sia_edadia_usua = (int)tobjModelo.Sia_edadia_usua;
                    lobjRegistro.sia_edaymd_usua = tobjModelo.Sia_edaymd_usua;
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                    lobjRegistro.sia_fecedt_usua = (DateTime)tobjModelo.Sia_fecedt_usua;
                    lobjRegistro.sia_llaveb_usua = tobjModelo.Sia_llaveb_usua;
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
                var lobjRegistro = _context.Siausuarioatend.FirstOrDefault(p => p.sia_idesec_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SIAUSUARIOATEND: Logica
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TITULO: Maestro de Pacientes atendidos</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios/Pacientes que en algun momento recibieron
        /// servicios medicos en la institucion, contiene todos los datos
        /// personales de los pacientes, datos de demograficios, sisben,
        /// afiliacion, nivel contributivo, gurpo poblacional
        /// </para>
        /// </summary>
        public static bool flgBuscarSiausuarioatend(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siausuarioatend.FirstOrDefault(p => p.sia_idesec_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSiaUsuariosAtendidos> flsListaSiausuarioatend(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    #region Consulta
                    var lobConsulta = from siausuarioatend in _context.Siausuarioatend
                                      join siatablaeps in _context.Siatablaeps on siausuarioatend.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join sistabmunicipio in _context.Sistabmunicipio on siausuarioatend.sis_idemun_muni equals sistabmunicipio.sis_idemun_muni into tmsistabmunicipio
                                      join sistabdepartame in _context.Sistabdepartame on siausuarioatend.sis_coddep_dpto equals sistabdepartame.sis_coddep_dpto into tmsistabdepartame
                                      join sisocupaciones in _context.Sisocupaciones on siausuarioatend.sis_codocu_ocup equals sisocupaciones.sis_codocu_ocup into tmsisocupaciones
                                      join ctomaescontrato in _context.Ctomaescontrato on siausuarioatend.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                      join sysusuarios in _context.Sysusuarios on siausuarioatend.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from muni in tmsistabmunicipio.DefaultIfEmpty()
                                      from dpto in tmsistabdepartame.DefaultIfEmpty()
                                      from ocup in tmsisocupaciones.DefaultIfEmpty()
                                      from cont in tmctomaescontrato.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      select new ModeloSiaUsuariosAtendidos
                                      {
                                          #region Datos
                                          Sia_idesec_usua = siausuarioatend.sia_idesec_usua,
                                          Hcl_nrohis_hicl = siausuarioatend.hcl_nrohis_hicl,
                                          Sia_codeps_teps = siausuarioatend.sia_codeps_teps,
                                          Sia_tipide_tide = siausuarioatend.sia_tipide_tide,
                                          Sia_nroide_usua = siausuarioatend.sia_nroide_usua,
                                          Sia_priape_usua = siausuarioatend.sia_priape_usua,
                                          Sia_segape_usua = siausuarioatend.sia_segape_usua,
                                          Sia_prinom_usua = siausuarioatend.sia_prinom_usua,
                                          Sia_segnom_usua = siausuarioatend.sia_segnom_usua,
                                          Sia_fecnac_usua = (DateTime)siausuarioatend.sia_fecnac_usua,
                                          Sis_codsex_sexo = siausuarioatend.sis_codsex_sexo,
                                          Sia_nomusu_usua = siausuarioatend.sia_nomusu_usua,
                                          Sia_tipusu_regi = siausuarioatend.sia_tipusu_regi,
                                          Sia_tipcot_tcot = siausuarioatend.sia_tipcot_tcot,
                                          Sia_tipafi_tafi = siausuarioatend.sia_tipafi_tafi,
                                          Sia_tippob_tpob = siausuarioatend.sia_tippob_tpob,
                                          Sia_nivsbn_nsbn = siausuarioatend.sia_nivsbn_nsbn,
                                          Sia_nivcon_ncon = siausuarioatend.sia_nivcon_ncon,
                                          Sis_idemun_muni = siausuarioatend.sis_idemun_muni,
                                          Sis_codmun_muni = siausuarioatend.sis_codmun_muni,
                                          Sis_coddep_dpto = siausuarioatend.sis_coddep_dpto,
                                          Sis_zonres_tzon = siausuarioatend.sis_zonres_tzon,
                                          Sia_telres_usua = siausuarioatend.sia_telres_usua,
                                          Sia_dirres_usua = siausuarioatend.sia_dirres_usua,
                                          Sia_correo_usua = siausuarioatend.sia_correo_usua,
                                          Sis_codocu_ocup = siausuarioatend.sis_codocu_ocup,
                                          Sia_feceps_usua = (DateTime)siausuarioatend.sia_feceps_usua,
                                          Cto_seccon_cont = siausuarioatend.cto_seccon_cont,
                                          Cto_nrocon_cont = siausuarioatend.cto_nrocon_cont,
                                          Sia_tpidap_tide = siausuarioatend.sia_tpidap_tide,
                                          Desia_tpidap_tide = _context.Siatipideusario.FirstOrDefault(rxp => rxp.sia_tipide_tide == siausuarioatend.sia_tpidap_tide).sia_deside_tide,
                                          Sia_ideapo_usua = siausuarioatend.sia_ideapo_usua,
                                          Sia_modsub_usua = siausuarioatend.sia_modsub_usua,
                                          Sia_discap_usua = siausuarioatend.sia_discap_usua,
                                          Sia_tipdis_tdis = siausuarioatend.sia_tipdis_tdis,
                                          Sia_edapac_usua = (int)siausuarioatend.sia_edapac_usua,
                                          Sia_codmed_tmed = siausuarioatend.sia_codmed_tmed,
                                          Sia_edaano_usua = (int)siausuarioatend.sia_edaano_usua,
                                          Sia_edames_usua = (int)siausuarioatend.sia_edames_usua,
                                          Sia_edadia_usua = (int)siausuarioatend.sia_edadia_usua,
                                          Sia_edaymd_usua = siausuarioatend.sia_edaymd_usua,
                                          Sia_codcat_ceat = siausuarioatend.sia_codcat_ceat,
                                          Sys_codusu_usux = siausuarioatend.sys_codusu_usux,
                                          Sia_fecedt_usua = (DateTime)siausuarioatend.sia_fecedt_usua,
                                          Sia_llaveb_usua = siausuarioatend.sia_llaveb_usua,
                                          Sis_estreg_esrg = siausuarioatend.sis_estreg_esrg,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Sis_nommun_muni = muni.sis_nommun_muni,
                                          Sis_desdep_dpto = dpto.sis_desdep_dpto,
                                          Sis_desocu_ocup = ocup.sis_desocu_ocup,
                                          Cto_descon_cont = cont.cto_descon_cont,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                          Sia_deside_tide = _context.Siatipideusario.FirstOrDefault(rxp => rxp.sia_tipide_tide == siausuarioatend.sia_tipide_tide).sia_deside_tide,
                                          Sis_dessex_sexo = _context.Sistablasexos.FirstOrDefault(rxp => rxp.sis_codsex_sexo == siausuarioatend.sis_codsex_sexo).sis_dessex_sexo,
                                          Sia_destip_regi = _context.Siaregimensalud.FirstOrDefault(rxp => rxp.sia_tipusu_regi == siausuarioatend.sia_tipusu_regi).sia_destip_regi,
                                          Sia_descot_tcot = _context.Siatipocotizante.FirstOrDefault(rxp => rxp.sia_tipcot_tcot == siausuarioatend.sia_tipcot_tcot).sia_descot_tcot,
                                          Sia_destaf_tafi = _context.Siatipaficontri.FirstOrDefault(rxp => rxp.sia_tipafi_tafi == siausuarioatend.sia_tipafi_tafi).sia_destaf_tafi,
                                          Sia_despob_tpob = _context.Siatippoblacion.FirstOrDefault(rxp => rxp.sia_tippob_tpob == siausuarioatend.sia_tippob_tpob).sia_despob_tpob,
                                          Sia_dessbn_nsbn = _context.Sianivelsisben.FirstOrDefault(rxp => rxp.sia_nivsbn_nsbn == siausuarioatend.sia_nivsbn_nsbn).sia_dessbn_nsbn,
                                          Sia_descon_ncon = _context.Sianivcontribut.FirstOrDefault(rxp => rxp.sia_nivcon_ncon == siausuarioatend.sia_nivcon_ncon).sia_descon_ncon,
                                          Sis_deszon_tzon = _context.Siszonaresidenc.FirstOrDefault(rxp => rxp.sis_zonres_tzon == siausuarioatend.sis_zonres_tzon).sis_deszon_tzon,
                                          Sia_desdis_tdis = _context.Siatipdiscapaci.FirstOrDefault(rxp => rxp.sia_tipdis_tdis == siausuarioatend.sia_tipdis_tdis).sia_desdis_tdis,
                                          Sia_desmed_tmed = _context.Siamedidaedad.FirstOrDefault(rxp => rxp.sia_codmed_tmed == siausuarioatend.sia_codmed_tmed).sia_desmed_tmed,
                                          Sia_descat_ceat = _context.Siacentroaten.FirstOrDefault(rxp => rxp.sia_codcat_ceat == siausuarioatend.sia_codcat_ceat).sia_descat_ceat,
                                          Sis_desest_esrg = _context.Sisestadoregist.FirstOrDefault(rxp => rxp.sis_estreg_esrg == siausuarioatend.sis_estreg_esrg).sis_desest_esrg,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                    #endregion
                }
                else
                {
                    var lobConsulta = from siausuarioatend in _context.Siausuarioatend
                                      join siatablaeps in _context.Siatablaeps on siausuarioatend.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join sistabmunicipio in _context.Sistabmunicipio on siausuarioatend.sis_idemun_muni equals sistabmunicipio.sis_idemun_muni into tmsistabmunicipio
                                      join sistabdepartame in _context.Sistabdepartame on siausuarioatend.sis_coddep_dpto equals sistabdepartame.sis_coddep_dpto into tmsistabdepartame
                                      join sisocupaciones in _context.Sisocupaciones on siausuarioatend.sis_codocu_ocup equals sisocupaciones.sis_codocu_ocup into tmsisocupaciones
                                      join ctomaescontrato in _context.Ctomaescontrato on siausuarioatend.cto_seccon_cont equals ctomaescontrato.cto_seccon_cont into tmctomaescontrato
                                      join sysusuarios in _context.Sysusuarios on siausuarioatend.sys_codusu_usux equals sysusuarios.sys_codusu_usux into tmsysusuarios
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from muni in tmsistabmunicipio.DefaultIfEmpty()
                                      from dpto in tmsistabdepartame.DefaultIfEmpty()
                                      from ocup in tmsisocupaciones.DefaultIfEmpty()
                                      from cont in tmctomaescontrato.DefaultIfEmpty()
                                      from usux in tmsysusuarios.DefaultIfEmpty()
                                      where siausuarioatend.sia_idesec_usua == tcrBuscar
                                      select new ModeloSiaUsuariosAtendidos
                                      {
                                          #region Datos
                                          Sia_idesec_usua = siausuarioatend.sia_idesec_usua,
                                          Hcl_nrohis_hicl = siausuarioatend.hcl_nrohis_hicl,
                                          Sia_codeps_teps = siausuarioatend.sia_codeps_teps,
                                          Sia_tipide_tide = siausuarioatend.sia_tipide_tide,
                                          Sia_nroide_usua = siausuarioatend.sia_nroide_usua,
                                          Sia_priape_usua = siausuarioatend.sia_priape_usua,
                                          Sia_segape_usua = siausuarioatend.sia_segape_usua,
                                          Sia_prinom_usua = siausuarioatend.sia_prinom_usua,
                                          Sia_segnom_usua = siausuarioatend.sia_segnom_usua,
                                          Sia_fecnac_usua = (DateTime)siausuarioatend.sia_fecnac_usua,
                                          Sis_codsex_sexo = siausuarioatend.sis_codsex_sexo,
                                          Sia_nomusu_usua = siausuarioatend.sia_nomusu_usua,
                                          Sia_tipusu_regi = siausuarioatend.sia_tipusu_regi,
                                          Sia_tipcot_tcot = siausuarioatend.sia_tipcot_tcot,
                                          Sia_tipafi_tafi = siausuarioatend.sia_tipafi_tafi,
                                          Sia_tippob_tpob = siausuarioatend.sia_tippob_tpob,
                                          Sia_nivsbn_nsbn = siausuarioatend.sia_nivsbn_nsbn,
                                          Sia_nivcon_ncon = siausuarioatend.sia_nivcon_ncon,
                                          Sis_idemun_muni = siausuarioatend.sis_idemun_muni,
                                          Sis_codmun_muni = siausuarioatend.sis_codmun_muni,
                                          Sis_coddep_dpto = siausuarioatend.sis_coddep_dpto,
                                          Sis_zonres_tzon = siausuarioatend.sis_zonres_tzon,
                                          Sia_telres_usua = siausuarioatend.sia_telres_usua,
                                          Sia_dirres_usua = siausuarioatend.sia_dirres_usua,
                                          Sia_correo_usua = siausuarioatend.sia_correo_usua,
                                          Sis_codocu_ocup = siausuarioatend.sis_codocu_ocup,
                                          Sia_feceps_usua = (DateTime)siausuarioatend.sia_feceps_usua,
                                          Cto_seccon_cont = siausuarioatend.cto_seccon_cont,
                                          Cto_nrocon_cont = siausuarioatend.cto_nrocon_cont,
                                          Sia_tpidap_tide = siausuarioatend.sia_tpidap_tide,
                                          Desia_tpidap_tide = _context.Siatipideusario.FirstOrDefault(rxp => rxp.sia_tipide_tide == siausuarioatend.sia_tpidap_tide).sia_deside_tide,
                                          Sia_ideapo_usua = siausuarioatend.sia_ideapo_usua,
                                          Sia_modsub_usua = siausuarioatend.sia_modsub_usua,
                                          Sia_discap_usua = siausuarioatend.sia_discap_usua,
                                          Sia_tipdis_tdis = siausuarioatend.sia_tipdis_tdis,
                                          Sia_edapac_usua = (int)siausuarioatend.sia_edapac_usua,
                                          Sia_codmed_tmed = siausuarioatend.sia_codmed_tmed,
                                          Sia_edaano_usua = (int)siausuarioatend.sia_edaano_usua,
                                          Sia_edames_usua = (int)siausuarioatend.sia_edames_usua,
                                          Sia_edadia_usua = (int)siausuarioatend.sia_edadia_usua,
                                          Sia_edaymd_usua = siausuarioatend.sia_edaymd_usua,
                                          Sia_codcat_ceat = siausuarioatend.sia_codcat_ceat,
                                          Sys_codusu_usux = siausuarioatend.sys_codusu_usux,
                                          Sia_fecedt_usua = (DateTime)siausuarioatend.sia_fecedt_usua,
                                          Sia_llaveb_usua = siausuarioatend.sia_llaveb_usua,
                                          Sis_estreg_esrg = siausuarioatend.sis_estreg_esrg,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Sis_nommun_muni = muni.sis_nommun_muni,
                                          Sis_desdep_dpto = dpto.sis_desdep_dpto,
                                          Sis_desocu_ocup = ocup.sis_desocu_ocup,
                                          Cto_descon_cont = cont.cto_descon_cont,
                                          Sys_nomusu_usux = usux.sys_nomusu_usux,
                                          Sia_deside_tide = _context.Siatipideusario.FirstOrDefault(rxp => rxp.sia_tipide_tide == siausuarioatend.sia_tipide_tide).sia_deside_tide,
                                          Sis_dessex_sexo = _context.Sistablasexos.FirstOrDefault(rxp => rxp.sis_codsex_sexo == siausuarioatend.sis_codsex_sexo).sis_dessex_sexo,
                                          Sia_destip_regi = _context.Siaregimensalud.FirstOrDefault(rxp => rxp.sia_tipusu_regi == siausuarioatend.sia_tipusu_regi).sia_destip_regi,
                                          Sia_descot_tcot = _context.Siatipocotizante.FirstOrDefault(rxp => rxp.sia_tipcot_tcot == siausuarioatend.sia_tipcot_tcot).sia_descot_tcot,
                                          Sia_destaf_tafi = _context.Siatipaficontri.FirstOrDefault(rxp => rxp.sia_tipafi_tafi == siausuarioatend.sia_tipafi_tafi).sia_destaf_tafi,
                                          Sia_despob_tpob = _context.Siatippoblacion.FirstOrDefault(rxp => rxp.sia_tippob_tpob == siausuarioatend.sia_tippob_tpob).sia_despob_tpob,
                                          Sia_dessbn_nsbn = _context.Sianivelsisben.FirstOrDefault(rxp => rxp.sia_nivsbn_nsbn == siausuarioatend.sia_nivsbn_nsbn).sia_dessbn_nsbn,
                                          Sia_descon_ncon = _context.Sianivcontribut.FirstOrDefault(rxp => rxp.sia_nivcon_ncon == siausuarioatend.sia_nivcon_ncon).sia_descon_ncon,
                                          Sis_deszon_tzon = _context.Siszonaresidenc.FirstOrDefault(rxp => rxp.sis_zonres_tzon == siausuarioatend.sis_zonres_tzon).sis_deszon_tzon,
                                          Sia_desdis_tdis = _context.Siatipdiscapaci.FirstOrDefault(rxp => rxp.sia_tipdis_tdis == siausuarioatend.sia_tipdis_tdis).sia_desdis_tdis,
                                          Sia_desmed_tmed = _context.Siamedidaedad.FirstOrDefault(rxp => rxp.sia_codmed_tmed == siausuarioatend.sia_codmed_tmed).sia_desmed_tmed,
                                          Sia_descat_ceat = _context.Siacentroaten.FirstOrDefault(rxp => rxp.sia_codcat_ceat == siausuarioatend.sia_codcat_ceat).sia_descat_ceat,
                                          Sis_desest_esrg = _context.Sisestadoregist.FirstOrDefault(rxp => rxp.sis_estreg_esrg == siausuarioatend.sis_estreg_esrg).sis_desest_esrg,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    */
}
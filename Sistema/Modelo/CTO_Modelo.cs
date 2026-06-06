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
using Sistema.Modelo;

namespace Sistema.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: ctomaeafiliados
    /// </summary>
    public class ModeloCtomaestroafiliados : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Cto_idesec_ctou: Código único afiliado
        private String _cto_idesec_ctou;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: ctomaeafiliados</para>
        /// <para>CAMPO: Código único afiliado</para>
        /// <para>NOMBRE: cto_idesec_ctou (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único del registro de afiliado se genera al cargar
        /// la base de datos en el sistema
        /// </para>
        /// </summary>
        public String Cto_idesec_ctou
        {
            get { return _cto_idesec_ctou; }
            set
            {
                if (_cto_idesec_ctou == value) return;
                _cto_idesec_ctou = value;
                OnPropertyChanged("Cto_idesec_ctou");
            }
        }
        #endregion
        #region Hcl_nrohis_hicl: Historia Clínica
        private String _hcl_nrohis_hicl;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        #region Sia_valibc_usua: Ingreso Base de cotizacion
        private int _sia_valibc_usua;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Pertenencia etnica</para>
        /// <para>NOMBRE: sia_valibc_usua (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///Ingreso base de cotizacion para usuarios contributivos
        /// </para>
        /// </summary>
        public int Sia_valibc_usua
        {
            get { return _sia_valibc_usua; }
            set
            {
                if (_sia_valibc_usua == value) return;
                _sia_valibc_usua = value;
                OnPropertyChanged("Sia_valibc_usua");
            }
        }
        #endregion
        #region Sia_tippob_tpob: Tipo población especial
        private String _sia_tippob_tpob;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
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
        #region Sia_codper_pret: Pertenencia etnica
        private String _sia_codper_pret;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Pertenencia etnica</para>
        /// <para>NOMBRE: sia_codper_pret (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Código pertenencia etnica
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
        #region Sia_nivsbn_nsbn: Nivel Sisben
        private String _sia_nivsbn_nsbn;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha ultima edición</para>
        /// <para>NOMBRE: sia_fecedt_usua (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: llave búsqueda</para>
        /// <para>NOMBRE: sia_llaveb_usua (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        public static string flgAddRegistro(ModeloCtomaestroafiliados tobjModelo)
        {
            // Se usa la misma llave de la tabla usuarios atendidos
            var lcrCodigoGen = tobjModelo.Cto_idesec_ctou;
            if (String.IsNullOrWhiteSpace(tobjModelo.Cto_idesec_ctou))
            {
                lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("SIA-MAE-USUARIOS-ATENDIDOS", "SIA", "Maestro de usuarios atendidos");
            }
            tobjModelo.Cto_idesec_ctou = lcrCodigoGen;

            if (!flgBuscarCtomaeafiliados(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFctomaeafiliados
                    {
                        #region cargar Registro
                        cto_idesec_ctou = tobjModelo.Cto_idesec_ctou,
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
                        sia_valibc_usua = tobjModelo.Sia_valibc_usua,
                        sia_tippob_tpob = tobjModelo.Sia_tippob_tpob,
                        sia_codper_pret = tobjModelo.Sia_codper_pret,
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
                        sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                        sys_codusu_usux = tobjModelo.Sys_codusu_usux,
                        sia_fecedt_usua = tobjModelo.Sia_fecedt_usua,
                        sia_llaveb_usua = tobjModelo.Sia_llaveb_usua,
                        sis_estreg_esrg = tobjModelo.Sis_estreg_esrg,
                        #endregion
                    };
                    lobjRegistro.cto_idesec_ctou = lcrCodigoGen;
                    _context.AddToCtomaeafiliados(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'SIA-MAE-USUARIOS-ATENDIDOS': Maestro de usuarios atendidos.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloCtomaestroafiliados tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaeafiliados.FirstOrDefault(p => p.cto_idesec_ctou == tobjModelo.Cto_idesec_ctou);
                if (lobjRegistro != null)
                {
                    #region datos
                    lobjRegistro.cto_idesec_ctou = tobjModelo.Cto_idesec_ctou;
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
                    lobjRegistro.sia_valibc_usua = (int)tobjModelo.Sia_valibc_usua;
                    lobjRegistro.sia_tippob_tpob = tobjModelo.Sia_tippob_tpob;
                    lobjRegistro.sia_codper_pret = tobjModelo.Sia_codper_pret;
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
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                    lobjRegistro.sia_fecedt_usua = (DateTime)tobjModelo.Sia_fecedt_usua;
                    lobjRegistro.sia_llaveb_usua = tobjModelo.Sia_llaveb_usua;
                    lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
                    _context.SaveChanges();
                    #endregion
                }
            }
        }
        #endregion
        #region fcvActualizarUsAtendidos: Generar registro de usuarios atendidos
        /// <summary>
        /// Crear o actualizar los datos del usuario en maestro afiliados del contrato
        /// </summary>
        public static void fcvActualizarUsAtendidos(SIAModeloUsuariosAtendidos tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = new EFctomaeafiliados();
                var lobjRegAux = (from tmp in _context.Ctomaeafiliados where 
                                                tmp.sia_nroide_usua == tobjModelo.Sia_nroide_usua ||  
                                                tmp.cto_idesec_ctou == tobjModelo.Sia_idesec_usua 
                                                select tmp);
                if (lobjRegAux != null)
                {
                    foreach (var lobReg in lobjRegAux)
                    {
                        _context.DeleteObject(lobReg);
                    }
                }
                #region datos
                lobjRegistro.cto_idesec_ctou = tobjModelo.Sia_idesec_usua;
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
                lobjRegistro.sia_valibc_usua = (int)tobjModelo.Sia_valibc_usua;
                lobjRegistro.sia_tippob_tpob = tobjModelo.Sia_tippob_tpob;
                lobjRegistro.sia_codper_pret = tobjModelo.Sia_codper_pret;
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
                lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                lobjRegistro.sys_codusu_usux = tobjModelo.Sys_codusu_usux;
                lobjRegistro.sia_fecedt_usua = (DateTime)tobjModelo.Sia_fecedt_usua;
                lobjRegistro.sia_llaveb_usua = tobjModelo.Sia_llaveb_usua;
                lobjRegistro.sis_estreg_esrg = tobjModelo.Sis_estreg_esrg;
                #endregion
                _context.AddToCtomaeafiliados(lobjRegistro);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaeafiliados.FirstOrDefault(p => p.cto_idesec_ctou == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar CTOMAEAFILIADOS: Logica
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TITULO: Maestro de afiliados en contrato</para>
        /// <para>MODULO: CTO</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios afiliados correspondientes a un contrato
        /// contiene datos personales de afiliacion a EPS o algun seguro
        /// </para>
        /// </summary>
        public static bool flgBuscarCtomaeafiliados(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Ctomaeafiliados.FirstOrDefault(p => p.cto_idesec_ctou == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloCtomaestroafiliados> flsListaCtomaeafiliados(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from ctomaeafiliados in _context.Ctomaeafiliados
                                      join siatablaeps in _context.Siatablaeps on ctomaeafiliados.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join sistabmunicipio in _context.Sistabmunicipio on ctomaeafiliados.sis_idemun_muni equals sistabmunicipio.sis_idemun_muni into tmsistabmunicipio
                                      join sistabdepartame in _context.Sistabdepartame on ctomaeafiliados.sis_coddep_dpto equals sistabdepartame.sis_coddep_dpto into tmsistabdepartame
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from muni in tmsistabmunicipio.DefaultIfEmpty()
                                      from dpto in tmsistabdepartame.DefaultIfEmpty()
                                      select new ModeloCtomaestroafiliados
                                      {
                                          #region Datos
                                          Cto_idesec_ctou = ctomaeafiliados.cto_idesec_ctou,
                                          Hcl_nrohis_hicl = ctomaeafiliados.hcl_nrohis_hicl,
                                          Sia_codeps_teps = ctomaeafiliados.sia_codeps_teps,
                                          Sia_tipide_tide = ctomaeafiliados.sia_tipide_tide,
                                          Sia_nroide_usua = ctomaeafiliados.sia_nroide_usua,
                                          Sia_priape_usua = ctomaeafiliados.sia_priape_usua,
                                          Sia_segape_usua = ctomaeafiliados.sia_segape_usua,
                                          Sia_prinom_usua = ctomaeafiliados.sia_prinom_usua,
                                          Sia_segnom_usua = ctomaeafiliados.sia_segnom_usua,
                                          Sia_fecnac_usua = (DateTime)ctomaeafiliados.sia_fecnac_usua,
                                          Sis_codsex_sexo = ctomaeafiliados.sis_codsex_sexo,
                                          Sia_nomusu_usua = ctomaeafiliados.sia_nomusu_usua,
                                          Sia_tipusu_regi = ctomaeafiliados.sia_tipusu_regi,
                                          Sia_tipcot_tcot = ctomaeafiliados.sia_tipcot_tcot,
                                          Sia_tipafi_tafi = ctomaeafiliados.sia_tipafi_tafi,
                                          Sia_valibc_usua = (int)ctomaeafiliados.sia_valibc_usua,
                                          Sia_tippob_tpob = ctomaeafiliados.sia_tippob_tpob,
                                          Sia_codper_pret = ctomaeafiliados.sia_codper_pret,
                                          Sia_nivsbn_nsbn = ctomaeafiliados.sia_nivsbn_nsbn,
                                          Sia_nivcon_ncon = ctomaeafiliados.sia_nivcon_ncon,
                                          Sis_idemun_muni = ctomaeafiliados.sis_idemun_muni,
                                          Sis_codmun_muni = ctomaeafiliados.sis_codmun_muni,
                                          Sis_coddep_dpto = ctomaeafiliados.sis_coddep_dpto,
                                          Sis_zonres_tzon = ctomaeafiliados.sis_zonres_tzon,
                                          Sia_telres_usua = ctomaeafiliados.sia_telres_usua,
                                          Sia_dirres_usua = ctomaeafiliados.sia_dirres_usua,
                                          Sia_correo_usua = ctomaeafiliados.sia_correo_usua,
                                          Sis_codocu_ocup = ctomaeafiliados.sis_codocu_ocup,
                                          Sia_feceps_usua = (DateTime)ctomaeafiliados.sia_feceps_usua,
                                          Cto_seccon_cont = ctomaeafiliados.cto_seccon_cont,
                                          Cto_nrocon_cont = ctomaeafiliados.cto_nrocon_cont,
                                          Sia_tpidap_tide = ctomaeafiliados.sia_tpidap_tide,
                                          Sia_ideapo_usua = ctomaeafiliados.sia_ideapo_usua,
                                          Sia_modsub_usua = ctomaeafiliados.sia_modsub_usua,
                                          Sia_discap_usua = ctomaeafiliados.sia_discap_usua,
                                          Sia_tipdis_tdis = ctomaeafiliados.sia_tipdis_tdis,
                                          Sia_edapac_usua = (int)ctomaeafiliados.sia_edapac_usua,
                                          Sia_codmed_tmed = ctomaeafiliados.sia_codmed_tmed,
                                          Sia_edaano_usua = (int)ctomaeafiliados.sia_edaano_usua,
                                          Sia_edames_usua = (int)ctomaeafiliados.sia_edames_usua,
                                          Sia_edadia_usua = (int)ctomaeafiliados.sia_edadia_usua,
                                          Sia_codcat_ceat = ctomaeafiliados.sia_codcat_ceat,
                                          Sys_codusu_usux = ctomaeafiliados.sys_codusu_usux,
                                          Sia_fecedt_usua = (DateTime)ctomaeafiliados.sia_fecedt_usua,
                                          Sia_llaveb_usua = ctomaeafiliados.sia_llaveb_usua,
                                          Sis_estreg_esrg = ctomaeafiliados.sis_estreg_esrg,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Sis_nommun_muni = muni.sis_nommun_muni,
                                          Sis_desdep_dpto = dpto.sis_desdep_dpto,
                                          #endregion
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from ctomaeafiliados in _context.Ctomaeafiliados
                                      join siatablaeps in _context.Siatablaeps on ctomaeafiliados.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join sistabmunicipio in _context.Sistabmunicipio on ctomaeafiliados.sis_idemun_muni equals sistabmunicipio.sis_idemun_muni into tmsistabmunicipio
                                      join sistabdepartame in _context.Sistabdepartame on ctomaeafiliados.sis_coddep_dpto equals sistabdepartame.sis_coddep_dpto into tmsistabdepartame
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from muni in tmsistabmunicipio.DefaultIfEmpty()
                                      from dpto in tmsistabdepartame.DefaultIfEmpty()
                                      where ctomaeafiliados.cto_idesec_ctou == tcrBuscar
                                      select new ModeloCtomaestroafiliados
                                      {
                                          #region Datos
                                          Cto_idesec_ctou = ctomaeafiliados.cto_idesec_ctou,
                                          Hcl_nrohis_hicl = ctomaeafiliados.hcl_nrohis_hicl,
                                          Sia_codeps_teps = ctomaeafiliados.sia_codeps_teps,
                                          Sia_tipide_tide = ctomaeafiliados.sia_tipide_tide,
                                          Sia_nroide_usua = ctomaeafiliados.sia_nroide_usua,
                                          Sia_priape_usua = ctomaeafiliados.sia_priape_usua,
                                          Sia_segape_usua = ctomaeafiliados.sia_segape_usua,
                                          Sia_prinom_usua = ctomaeafiliados.sia_prinom_usua,
                                          Sia_segnom_usua = ctomaeafiliados.sia_segnom_usua,
                                          Sia_fecnac_usua = (DateTime)ctomaeafiliados.sia_fecnac_usua,
                                          Sis_codsex_sexo = ctomaeafiliados.sis_codsex_sexo,
                                          Sia_nomusu_usua = ctomaeafiliados.sia_nomusu_usua,
                                          Sia_tipusu_regi = ctomaeafiliados.sia_tipusu_regi,
                                          Sia_tipcot_tcot = ctomaeafiliados.sia_tipcot_tcot,
                                          Sia_tipafi_tafi = ctomaeafiliados.sia_tipafi_tafi,
                                          Sia_valibc_usua = (int)ctomaeafiliados.sia_valibc_usua,
                                          Sia_tippob_tpob = ctomaeafiliados.sia_tippob_tpob,
                                          Sia_codper_pret = ctomaeafiliados.sia_codper_pret,
                                          Sia_nivsbn_nsbn = ctomaeafiliados.sia_nivsbn_nsbn,
                                          Sia_nivcon_ncon = ctomaeafiliados.sia_nivcon_ncon,
                                          Sis_idemun_muni = ctomaeafiliados.sis_idemun_muni,
                                          Sis_codmun_muni = ctomaeafiliados.sis_codmun_muni,
                                          Sis_coddep_dpto = ctomaeafiliados.sis_coddep_dpto,
                                          Sis_zonres_tzon = ctomaeafiliados.sis_zonres_tzon,
                                          Sia_telres_usua = ctomaeafiliados.sia_telres_usua,
                                          Sia_dirres_usua = ctomaeafiliados.sia_dirres_usua,
                                          Sia_correo_usua = ctomaeafiliados.sia_correo_usua,
                                          Sis_codocu_ocup = ctomaeafiliados.sis_codocu_ocup,
                                          Sia_feceps_usua = (DateTime)ctomaeafiliados.sia_feceps_usua,
                                          Cto_seccon_cont = ctomaeafiliados.cto_seccon_cont,
                                          Cto_nrocon_cont = ctomaeafiliados.cto_nrocon_cont,
                                          Sia_tpidap_tide = ctomaeafiliados.sia_tpidap_tide,
                                          Sia_ideapo_usua = ctomaeafiliados.sia_ideapo_usua,
                                          Sia_modsub_usua = ctomaeafiliados.sia_modsub_usua,
                                          Sia_discap_usua = ctomaeafiliados.sia_discap_usua,
                                          Sia_tipdis_tdis = ctomaeafiliados.sia_tipdis_tdis,
                                          Sia_edapac_usua = (int)ctomaeafiliados.sia_edapac_usua,
                                          Sia_codmed_tmed = ctomaeafiliados.sia_codmed_tmed,
                                          Sia_edaano_usua = (int)ctomaeafiliados.sia_edaano_usua,
                                          Sia_edames_usua = (int)ctomaeafiliados.sia_edames_usua,
                                          Sia_edadia_usua = (int)ctomaeafiliados.sia_edadia_usua,
                                          Sia_codcat_ceat = ctomaeafiliados.sia_codcat_ceat,
                                          Sys_codusu_usux = ctomaeafiliados.sys_codusu_usux,
                                          Sia_fecedt_usua = (DateTime)ctomaeafiliados.sia_fecedt_usua,
                                          Sia_llaveb_usua = ctomaeafiliados.sia_llaveb_usua,
                                          Sis_estreg_esrg = ctomaeafiliados.sis_estreg_esrg,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Sis_nommun_muni = muni.sis_nommun_muni,
                                          Sis_desdep_dpto = dpto.sis_desdep_dpto,
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
    /// Descripcion para la Vista de  la tabla: ctomaeafiliados en formato texto
    /// </summary>
    public class ModeloCtomaestroafiliadosEx : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Cto_idesec_ctou: Código único afiliado
        private String _cto_idesec_ctou;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: ctomaeafiliados</para>
        /// <para>CAMPO: Código único afiliado</para>
        /// <para>NOMBRE: cto_idesec_ctou (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único del registro de afiliado se genera al cargar
        /// la base de datos en el sistema
        /// </para>
        /// </summary>
        public String Cto_idesec_ctou
        {
            get { return _cto_idesec_ctou; }
            set
            {
                if (_cto_idesec_ctou == value) return;
                _cto_idesec_ctou = value;
                OnPropertyChanged("Cto_idesec_ctou");
            }
        }
        #endregion
        #region Hcl_nrohis_hicl: Historia Clínica
        private String _hcl_nrohis_hicl;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        #region Sia_tpicot_tide: Tipo id cotizante principal
        private String _sia_tpicot_tide;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Tipo id cotizante principal</para>
        /// <para>NOMBRE: sia_tpicot_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Tipo identificación cotizante principal (aplica para contributivo contributivo)
        /// </para>
        /// </summary>
        public String Sia_tpicot_tide
        {
            get { return _sia_tpicot_tide; }
            set
            {
                if (_sia_tpicot_tide == value) return;
                _sia_tpicot_tide = value;
                OnPropertyChanged("Sia_tpicot_tide");
            }
        }
        #endregion
        #region Sia_idecot_usua: Identificación aportante
        private String _sia_idecot_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Identificación cotizante principal</para>
        /// <para>NOMBRE: sia_idecot_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Numero identificación del cotizante principal (aplica para contributivo contributivo)
        /// </para>
        /// </summary>
        public String Sia_idecot_usua
        {
            get { return _sia_idecot_usua; }
            set
            {
                if (_sia_idecot_usua == value) return;
                _sia_idecot_usua = value;
                OnPropertyChanged("Sia_idecot_usua");
            }
        }
        #endregion
        #region Sia_tipide_tide: Tipo Identificación
        private String _sia_tipide_tide;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        private String _sia_fecnac_usua;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha nacimiento</para>
        /// <para>NOMBRE: sia_fecnac_usua (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Fecha nacimiento del usuario o paciente
        /// </para>
        /// </summary>
        public String Sia_fecnac_usua
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siatipocotizante</para>
        /// <para>CAMPO: Tipo cotizante</para>
        /// <para>NOMBRE: sia_tipcot_tcot (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION: Tipo Afiliado cotizante para el contributivo según Resolución: 2629de 2014 BDUA</para>
        /// <para>Valores: 1,2,4,10,11,12,15,16,17,18,19,20,21,44,45,47,48,49,50</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        #region Sia_valibc_usua: Ingreso Base de cotizacion
        private String _sia_valibc_usua;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Pertenencia etnica</para>
        /// <para>NOMBRE: sia_valibc_usua (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///Ingreso base de cotizacion para usuarios contributivos (en formato texto)
        /// </para>
        /// </summary>
        public String Sia_valibc_usua
        {
            get { return _sia_valibc_usua; }
            set
            {
                if (_sia_valibc_usua == value) return;
                _sia_valibc_usua = value;
                OnPropertyChanged("Sia_valibc_usua");
            }
        }
        #endregion
        #region Sia_parent_tafi: Parentesco con el cotizante
        private String _sia_parent_tafi;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Parentesco con el cotizante principal</para>
        /// <para>NOMBRE: sia_parent_tafi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Parentesco con el cotizante: 1,2,3,4,5,6,7
        /// </para>
        /// </summary>
        public String Sia_parent_tafi
        {
            get { return _sia_parent_tafi; }
            set
            {
                if (_sia_parent_tafi == value) return;
                _sia_parent_tafi = value;
                OnPropertyChanged("Sia_parent_tafi");
            }
        }
        #endregion
        #region Sia_tippob_tpob: Tipo población especial
        private String _sia_tippob_tpob;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
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
        #region Sia_codper_pret: Pertenencia etnica
        private String _sia_codper_pret;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Pertenencia etnica</para>
        /// <para>NOMBRE: sia_codper_pret (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Código pertenencia etnica
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
        #region Sia_nivsbn_nsbn: Nivel Sisben
        private String _sia_nivsbn_nsbn;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: sisocupaciones</para>
        /// <para>CAMPO: Codigo ocupación</para>
        /// <para>NOMBRE: sis_codocu_ocup (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Código ocupación o profesion usuario atendido segun Tabla CIIU revisión 4 DANE
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
        #region Sia_conben_usua: Condicion del Beneficiario mayor de 18
        private String _sia_conben_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal </para>
        /// <para>CAMPO: Condicion beneficiario mayor de 18 años</para>
        /// <para>NOMBRE: sia_conben_usua (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Condicion del Beneficiario mayor de 18 años
        /// </para>
        /// </summary>
        public String Sia_conben_usua
        {
            get { return _sia_conben_usua; }
            set
            {
                if (_sia_conben_usua == value) return;
                _sia_conben_usua = value;
                OnPropertyChanged("Sia_conben_usua");
            }
        }
        #endregion
        #region Sia_fecsss_usua: Fecha afiliación a SGSSS
        private String _sia_fecsss_usua;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Fecha afiliación SGSSS</para>
        /// <para>NOMBRE: sia_fecsss_usua (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Fecha afiliación al sistema de seguridad social (SGSSS) compatible 812
        /// </para>
        /// </summary>
        public String Sia_fecsss_usua
        {
            get { return _sia_fecsss_usua; }
            set
            {
                if (_sia_fecsss_usua == value) return;
                _sia_fecsss_usua = value;
                OnPropertyChanged("Sia_fecsss_usua");
            }
        }
        #endregion
        #region Sia_feceps_usua: Fecha afiliación EPS
        private String _sia_feceps_usua;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha afiliación EPS</para>
        /// <para>NOMBRE: sia_feceps_usua (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Fecha afiliación a EPS o asegurador
        /// </para>
        /// </summary>
        public String Sia_feceps_usua
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo id aportante</para>
        /// <para>NOMBRE: sia_tpidap_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Tipo identificación del aportante para contributivo, empresa donde trabaja el usuario
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación aportante</para>
        /// <para>NOMBRE: sia_ideapo_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Numero identificación del aportante Empresa que afilia
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        #region Sia_codcat_ceat: Código centro atención
        private String _sia_codcat_ceat;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha ultima edición</para>
        /// <para>NOMBRE: sia_fecedt_usua (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: llave búsqueda</para>
        /// <para>NOMBRE: sia_llaveb_usua (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        /// <para>TABLA: ctomaeafiliados</para>
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
        #region LlaveBusqueda: Llave de busquedad en vista
        private String _llaveBusqueda;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: llave de busqueda concatena IdRegistro IdUsuario apellidos y nombres</para>
        /// <para>NOMBRE: LlaveBusqueda (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION: Llave de busquedad en vista</para>
        /// </summary>
        public String LlaveBusqueda
        {
            get { return _llaveBusqueda; }
            set
            {
                if (_llaveBusqueda == value) return;
                _llaveBusqueda = value;
                OnPropertyChanged("LlaveBusqueda");
            }
        }
        #endregion
        #region Ssp_ideaux_ctou: Id único del registro 
        private int _ssp_ideaux_ctou;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Id único del registro para orden vista en temporal</para>
        /// <para>NOMBRE: Ssp_ideaux_ctou (int:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Id Único del registro afiliado en vista temporal (dato de tipo int)
        /// </para>
        /// </summary>
        public int Ssp_ideaux_ctou
        {
            get { return _ssp_ideaux_ctou; }
            set
            {
                if (_ssp_ideaux_ctou == value) return;
                _ssp_ideaux_ctou = value;
                OnPropertyChanged("Ssp_ideaux_ctou");
            }
        }
        #endregion
        #region NotaRegistro: Estado del registro para edicion
        private string _notaRegistro;
        /// <summary>
        /// <para>CAMPO: Nota del Registro para alguan gestion</para>
        /// <para>NOMBRE: Estado (char:20)</para>
        /// <para>DESCRIPCION:
        /// Nota del registro para procesos </para>
        /// </summary>
        public String NotaRegistro
        {
            get { return _notaRegistro; }
            set
            {
                if (_notaRegistro == value) return;
                _notaRegistro = value;
                OnPropertyChanged("NotaRegistro");
            }
        }
        #endregion
        #region Estado: Estado del registro para edicion
        private string _sis_Estado;
        /// <summary>
        /// <para>CAMPO: Estado del Registro para alguan gestion</para>
        /// <para>NOMBRE: Estado (char:20)</para>
        /// <para>DESCRIPCION:
        /// Estado del registro para procesos 
        /// ERRADO/MODIFICADO/ACTUALIZADO/ Y OTROS </para>
        /// </summary>
        public String Estado
        {
            get { return _sis_Estado; }
            set
            {
                if (_sis_Estado == value) return;
                _sis_Estado = value;
                OnPropertyChanged("Estado");
            }
        }
        #endregion
        #region BoolEstado: Estado del registro para edicion para Bindig en chkbox
        private bool _sis_BoolEstado = true;
        /// <summary>
        /// <para>CAMPO: Estado del Registro Para Edicion</para>
        /// <para>NOMBRE: Estado (BoolEstado: true/false)</para>
        /// <para>DESCRIPCION:
        /// Estado del registro para proceso de edicion
        /// INCLUIDO o EXCLUIDO </para>
        /// </summary>
        public bool BoolEstado
        {
            get { return _sis_BoolEstado; }
            set
            {
                if (_sis_BoolEstado == value) return;
                _sis_BoolEstado = value;
                OnPropertyChanged("Estado");
            }
        }
        #endregion
        #region Ssp_toterr_ctou: Total errores del registro
        private int _ssp_toterr_ctou;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Total erroes en validacion</para>
        /// <para>NOMBRE: Ssp_toterr_ctou (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Total erroes en validacion
        /// </para>
        /// </summary>
        public int Ssp_toterr_ctou
        {
            get { return _ssp_toterr_ctou; }
            set
            {
                if (_ssp_toterr_ctou == value) return;
                _ssp_toterr_ctou = value;
                OnPropertyChanged("Ssp_toterr_ctou");
            }
        }
        #endregion
        #region Ssp_niverr_ctou: Nivel errores del registro
        private String _ssp_niverr_ctou;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: nivel erroes en validacion</para>
        /// <para>NOMBRE: Ssp_niverr_ctou (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Nivel erroes en validacion ALTO/MEDIO/BAJO
        /// </para>
        /// </summary>
        public String Ssp_niverr_ctou
        {
            get { return _ssp_niverr_ctou; }
            set
            {
                if (_ssp_niverr_ctou == value) return;
                _ssp_niverr_ctou = value;
                OnPropertyChanged("Ssp_niverr_ctou");
            }
        }
        #endregion
        #region Sia_edaymd_usua: Edad formato largo
        private String _sia_edaymd_usua;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
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
        #endregion
        #endregion
        #region Listar Registros
        public static List<ModeloCtomaestroafiliadosEx> CtomaestroafiliadosContrato(String tcrIdContrato)
        {
            using (_context = new DbAplicacion())
            {
                List<ModeloCtomaestroafiliadosEx> tmpDatos = null;
                List<EFctomaeafiliados> lobConsulta = null;

                lobConsulta = (from tmp in _context.Ctomaeafiliados
                               where tmp.cto_seccon_cont == tcrIdContrato
                               select tmp).ToList();

                // cuando no hay datos retornar nulo
                if (lobConsulta == null) { return tmpDatos; }

                tmpDatos = new List<ModeloCtomaestroafiliadosEx>();
                String lcrCampo = String.Empty;
                String lcrllave1 = String.Empty;
                String lcrllave2 = String.Empty;
                String lcrllave3 = String.Empty;
                String lcrllave4 = String.Empty;
                String lcrllave5 = String.Empty;
                String lcrllave6 = String.Empty;

                // Cargar en el temporal
                var lnuContador = 0;
                foreach (var loReg in lobConsulta)
                {
                    var lobRegNew = new ModeloCtomaestroafiliadosEx();
                    #region Datos
                    lnuContador++;
                    lobRegNew.Ssp_ideaux_ctou = lnuContador;

                    lobRegNew.Cto_idesec_ctou = loReg.cto_idesec_ctou;
                    lobRegNew.Hcl_nrohis_hicl = loReg.hcl_nrohis_hicl;
                    lobRegNew.Sia_codeps_teps = loReg.sia_codeps_teps;
                    lobRegNew.Sia_tipide_tide = loReg.sia_tipide_tide;
                    lobRegNew.Sia_nroide_usua = loReg.sia_nroide_usua;
                    lobRegNew.Sia_priape_usua = loReg.sia_priape_usua;
                    lobRegNew.Sia_segape_usua = loReg.sia_segape_usua;
                    lobRegNew.Sia_prinom_usua = loReg.sia_prinom_usua;
                    lobRegNew.Sia_segnom_usua = loReg.sia_segnom_usua;
                    lobRegNew.Sia_fecnac_usua = Funciones.fcrConvertFecha((DateTime)loReg.sia_fecnac_usua);
                    lobRegNew.Sis_codsex_sexo = loReg.sis_codsex_sexo;
                    lobRegNew.Sia_nomusu_usua = loReg.sia_nomusu_usua;
                    lobRegNew.Sia_tipusu_regi = loReg.sia_tipusu_regi;
                    lobRegNew.Sia_tipcot_tcot = loReg.sia_tipcot_tcot;
                    lobRegNew.Sia_tipafi_tafi = loReg.sia_tipafi_tafi;
                    lobRegNew.Sia_valibc_usua = loReg.sia_valibc_usua.ToString();
                    lobRegNew.Sia_tippob_tpob = loReg.sia_tippob_tpob;
                    lobRegNew.Sia_codper_pret = loReg.sia_codper_pret;
                    lobRegNew.Sia_nivsbn_nsbn = loReg.sia_nivsbn_nsbn;
                    lobRegNew.Sia_nivcon_ncon = loReg.sia_nivcon_ncon;
                    lobRegNew.Sis_idemun_muni = loReg.sis_idemun_muni;
                    lobRegNew.Sis_codmun_muni = loReg.sis_codmun_muni;
                    lobRegNew.Sis_coddep_dpto = loReg.sis_coddep_dpto;
                    lobRegNew.Sis_zonres_tzon = loReg.sis_zonres_tzon;
                    lobRegNew.Sia_telres_usua = loReg.sia_telres_usua;
                    lobRegNew.Sia_dirres_usua = loReg.sia_dirres_usua;
                    lobRegNew.Sia_correo_usua = loReg.sia_correo_usua;
                    lobRegNew.Sis_codocu_ocup = loReg.sis_codocu_ocup;
                    lobRegNew.Sia_feceps_usua = Funciones.fcrConvertFecha((DateTime)loReg.sia_feceps_usua);
                    lobRegNew.Cto_seccon_cont = loReg.cto_seccon_cont;
                    lobRegNew.Cto_nrocon_cont = loReg.cto_nrocon_cont;
                    lobRegNew.Sia_tpidap_tide = loReg.sia_tpidap_tide;
                    lobRegNew.Sia_ideapo_usua = loReg.sia_ideapo_usua;
                    lobRegNew.Sia_modsub_usua = loReg.sia_modsub_usua;
                    lobRegNew.Sia_discap_usua = loReg.sia_discap_usua;
                    lobRegNew.Sia_tipdis_tdis = loReg.sia_tipdis_tdis;
                    lobRegNew.Sia_codmed_tmed = loReg.sia_codmed_tmed;
                    lobRegNew.Sia_codcat_ceat = loReg.sia_codcat_ceat;
                    lobRegNew.Sys_codusu_usux = loReg.sys_codusu_usux;
                    lobRegNew.Sia_fecedt_usua = (DateTime)loReg.sia_fecedt_usua;
                    lobRegNew.Sia_llaveb_usua = loReg.sia_llaveb_usua;
                    lobRegNew.Sis_estreg_esrg = loReg.sis_estreg_esrg;
                    lobRegNew.Sis_estado_imaen = "I";
                    #endregion
                    #region  Revisar Datos
                    lobRegNew.Sia_codeps_teps = lobRegNew.Sia_codeps_teps == null ? String.Empty : lobRegNew.Sia_codeps_teps;
                    lobRegNew.Sia_tipide_tide = lobRegNew.Sia_tipide_tide == null ? String.Empty : lobRegNew.Sia_tipide_tide;
                    lobRegNew.Sia_nroide_usua = lobRegNew.Sia_nroide_usua == null ? String.Empty : lobRegNew.Sia_nroide_usua;
                    lobRegNew.Sia_priape_usua = lobRegNew.Sia_priape_usua == null ? String.Empty : lobRegNew.Sia_priape_usua;
                    lobRegNew.Sia_segape_usua = lobRegNew.Sia_segape_usua == null ? String.Empty : lobRegNew.Sia_segape_usua;
                    lobRegNew.Sia_prinom_usua = lobRegNew.Sia_prinom_usua == null ? String.Empty : lobRegNew.Sia_prinom_usua;
                    lobRegNew.Sia_segnom_usua = lobRegNew.Sia_segnom_usua == null ? String.Empty : lobRegNew.Sia_segnom_usua;
                    lobRegNew.Sia_fecnac_usua = lobRegNew.Sia_fecnac_usua == null ? String.Empty : lobRegNew.Sia_fecnac_usua;
                    lobRegNew.Sis_codsex_sexo = lobRegNew.Sis_codsex_sexo == null ? String.Empty : lobRegNew.Sis_codsex_sexo;
                    lobRegNew.Sia_tippob_tpob = lobRegNew.Sia_tippob_tpob == null ? String.Empty : lobRegNew.Sia_tippob_tpob;
                    lobRegNew.Sia_codper_pret = lobRegNew.Sia_codper_pret == null ? String.Empty : lobRegNew.Sia_codper_pret;
                    lobRegNew.Sia_nivsbn_nsbn = lobRegNew.Sia_nivsbn_nsbn == null ? String.Empty : lobRegNew.Sia_nivsbn_nsbn;
                    lobRegNew.Sis_coddep_dpto = lobRegNew.Sis_coddep_dpto == null ? String.Empty : lobRegNew.Sis_coddep_dpto;
                    lobRegNew.Sis_codmun_muni = lobRegNew.Sis_codmun_muni == null ? String.Empty : lobRegNew.Sis_codmun_muni;
                    lobRegNew.Sis_zonres_tzon = lobRegNew.Sis_zonres_tzon == null ? String.Empty : lobRegNew.Sis_zonres_tzon;
                    lobRegNew.Sia_feceps_usua = lobRegNew.Sia_feceps_usua == null ? String.Empty : lobRegNew.Sia_feceps_usua;
                    lobRegNew.Sia_modsub_usua = lobRegNew.Sia_modsub_usua == null ? String.Empty : lobRegNew.Sia_modsub_usua;
                    lobRegNew.Sia_valibc_usua = lobRegNew.Sia_valibc_usua == null ? "0" : lobRegNew.Sia_valibc_usua;
                    #endregion
                    lcrllave1 = lobRegNew.Ssp_ideaux_ctou.ToString().Trim() + " ";
                    lcrllave2 = lobRegNew.Sia_nroide_usua != null ? lobRegNew.Sia_nroide_usua.ToUpper() + " " : String.Empty;
                    lcrllave3 = lobRegNew.Sia_priape_usua != null ? lobRegNew.Sia_priape_usua.ToUpper() + " " : String.Empty;
                    lcrllave4 = lobRegNew.Sia_segape_usua != null ? lobRegNew.Sia_segape_usua.ToUpper() + " " : String.Empty;
                    lcrllave5 = lobRegNew.Sia_prinom_usua != null ? lobRegNew.Sia_prinom_usua.ToUpper() + " " : String.Empty;
                    lcrllave6 = lobRegNew.Sia_segnom_usua != null ? lobRegNew.Sia_segnom_usua.ToUpper() : String.Empty;

                    lobRegNew.Ssp_niverr_ctou = String.Empty;
                    lobRegNew.Estado = "NO-VALIDADO";
                    lobRegNew.NotaRegistro = String.Empty;

                    lobRegNew.LlaveBusqueda = lcrllave1 + lcrllave2 + lcrllave3 + lcrllave4 + lcrllave5 + lcrllave6;

                    tmpDatos.Add(lobRegNew);
                }
                return tmpDatos;
            }
        }
        #endregion

    }

}

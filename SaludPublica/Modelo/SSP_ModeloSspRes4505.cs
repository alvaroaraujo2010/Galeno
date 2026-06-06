//- MARMOTA-GENCODE: VERSION 2.0 - 06/05/2014 08:31:52 PM
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

namespace SaludPublica.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sptablmsres4505
    /// </summary>
    public class ModeloSspRes4505x : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
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
        #region Sia_nroide_usua: Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        #region Sia_codeps_teps: Código Eps/Asegurador
        private String _sia_codeps_teps;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
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
        #region Ssp_cam000_ms45: 0.Tipo De Registro
        private String _ssp_cam000_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 0.Tipo De Registro</para>
        /// <para>NOMBRE: ssp_cam000_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Tipo De Registro
        /// </para>
        /// </summary>
        public String Ssp_cam000_ms45
        {
            get { return _ssp_cam000_ms45; }
            set
            {
                if (_ssp_cam000_ms45 == value) return;
                _ssp_cam000_ms45 = value;
                OnPropertyChanged("Ssp_cam000_ms45");
            }
        }
        #endregion
        #region Ssp_cam001_ms45: 1.Consecutivo de Registro
        private String _ssp_cam001_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 1.Consecutivo de Registro</para>
        /// <para>NOMBRE: ssp_cam001_ms45 (char:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Número consecutivo de registros de detalle dentro del archivo.
        /// Inicia en 1 para el primer registro de detalle y va incrementando
        /// de 1 en 1, hasta el final del archivo.
        /// </para>
        /// </summary>
        public String Ssp_cam001_ms45
        {
            get { return _ssp_cam001_ms45; }
            set
            {
                if (_ssp_cam001_ms45 == value) return;
                _ssp_cam001_ms45 = value;
                OnPropertyChanged("Ssp_cam001_ms45");
            }
        }
        #endregion
        #region Ssp_cam002_ms45: 2.Código de Habilitación IPS primaria
        private String _ssp_cam002_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 2.Código de Habilitación IPS primaria</para>
        /// <para>NOMBRE: ssp_cam002_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud) Si es desconocido registrar 999
        /// </para>
        /// </summary>
        public String Ssp_cam002_ms45
        {
            get { return _ssp_cam002_ms45; }
            set
            {
                if (_ssp_cam002_ms45 == value) return;
                _ssp_cam002_ms45 = value;
                OnPropertyChanged("Ssp_cam002_ms45");
            }
        }
        #endregion
        #region Ssp_cam003_ms45: 3.Tipo de identificación del usuario
        private String _ssp_cam003_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 3.Tipo de identificación del usuario</para>
        /// <para>NOMBRE: ssp_cam003_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo
        /// para menores con 2 meses o menos de nacidos calculando entre
        /// la fecha de nacimiento y la fecha de corte del reporte.
        /// </para>
        /// </summary>
        public String Ssp_cam003_ms45
        {
            get { return _ssp_cam003_ms45; }
            set
            {
                if (_ssp_cam003_ms45 == value) return;
                _ssp_cam003_ms45 = value;
                OnPropertyChanged("Ssp_cam003_ms45");
            }
        }
        #endregion
        #region Ssp_cam004_ms45: 4.Numero de identificación del usuario
        private String _ssp_cam004_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 4.Numero de identificación del usuario</para>
        /// <para>NOMBRE: ssp_cam004_ms45 (char:18)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Número del documento de identificación, de acuerdo con el tipo
        /// de identificación del campo anterior.
        /// </para>
        /// </summary>
        public String Ssp_cam004_ms45
        {
            get { return _ssp_cam004_ms45; }
            set
            {
                if (_ssp_cam004_ms45 == value) return;
                _ssp_cam004_ms45 = value;
                OnPropertyChanged("Ssp_cam004_ms45");
            }
        }
        #endregion
        #region Ssp_cam005_ms45: 5.Primer apellido del usuario
        private String _ssp_cam005_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 5.Primer apellido del usuario</para>
        /// <para>NOMBRE: ssp_cam005_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public String Ssp_cam005_ms45
        {
            get { return _ssp_cam005_ms45; }
            set
            {
                if (_ssp_cam005_ms45 == value) return;
                _ssp_cam005_ms45 = value;
                OnPropertyChanged("Ssp_cam005_ms45");
            }
        }
        #endregion
        #region Ssp_cam006_ms45: 6.Segundo apellido del usuario
        private String _ssp_cam006_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 6.Segundo apellido del usuario</para>
        /// <para>NOMBRE: ssp_cam006_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tenga en cuenta el numeral 1. En caso que el usuario no tenga
        /// segundo apellido o no se tenga este dato Registre NONE, en
        /// mayúscula sostenida.
        /// </para>
        /// </summary>
        public String Ssp_cam006_ms45
        {
            get { return _ssp_cam006_ms45; }
            set
            {
                if (_ssp_cam006_ms45 == value) return;
                _ssp_cam006_ms45 = value;
                OnPropertyChanged("Ssp_cam006_ms45");
            }
        }
        #endregion
        #region Ssp_cam007_ms45: 7.Primer nombre del usuario
        private String _ssp_cam007_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 7.Primer nombre del usuario</para>
        /// <para>NOMBRE: ssp_cam007_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public String Ssp_cam007_ms45
        {
            get { return _ssp_cam007_ms45; }
            set
            {
                if (_ssp_cam007_ms45 == value) return;
                _ssp_cam007_ms45 = value;
                OnPropertyChanged("Ssp_cam007_ms45");
            }
        }
        #endregion
        #region Ssp_cam008_ms45: 8.Segundo nombre del usuario
        private String _ssp_cam008_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 8.Segundo nombre del usuario</para>
        /// <para>NOMBRE: ssp_cam008_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Segundo nombre del usuario. Tenga en cuenta el numeral 1. En
        /// caso que el usuario no tenga segundo apellido o no se tenga
        /// este dato Registre NONE, en mayúscula sostenida.
        /// </para>
        /// </summary>
        public String Ssp_cam008_ms45
        {
            get { return _ssp_cam008_ms45; }
            set
            {
                if (_ssp_cam008_ms45 == value) return;
                _ssp_cam008_ms45 = value;
                OnPropertyChanged("Ssp_cam008_ms45");
            }
        }
        #endregion
        #region Ssp_cam009_ms45: 9.Fecha de Nacimiento
        private DateTime _ssp_cam009_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 9.Fecha de Nacimiento</para>
        /// <para>NOMBRE: ssp_cam009_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Fecha de Nacimiento. AAAA-MM-DD
        /// </para>
        /// </summary>
        public DateTime Ssp_cam009_ms45
        {
            get { return _ssp_cam009_ms45; }
            set
            {
                if (_ssp_cam009_ms45 == value) return;
                _ssp_cam009_ms45 = value;
                OnPropertyChanged("Ssp_cam009_ms45");
            }
        }
        #endregion
        #region Ssp_cam010_ms45: 10.Sexo
        private String _ssp_cam010_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 10.Sexo</para>
        /// <para>NOMBRE: ssp_cam010_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Sexo. M - Masculino F - Femenino
        /// </para>
        /// </summary>
        public String Ssp_cam010_ms45
        {
            get { return _ssp_cam010_ms45; }
            set
            {
                if (_ssp_cam010_ms45 == value) return;
                _ssp_cam010_ms45 = value;
                OnPropertyChanged("Ssp_cam010_ms45");
            }
        }
        #endregion
        #region Ssp_cam011_ms45: 11.Codigo pertenencia étnica
        private String _ssp_cam011_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 11.Codigo pertenencia étnica</para>
        /// <para>NOMBRE: ssp_cam011_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo pertenencia etnica. Registre según lo reporte el usuario:
        /// 1-Indígena 2-ROM (gitano)3-Raizal etc
        /// </para>
        /// </summary>
        public String Ssp_cam011_ms45
        {
            get { return _ssp_cam011_ms45; }
            set
            {
                if (_ssp_cam011_ms45 == value) return;
                _ssp_cam011_ms45 = value;
                OnPropertyChanged("Ssp_cam011_ms45");
            }
        }
        #endregion
        #region Ssp_codocu_ciuo: 12.Codigo de ocupación
        private String _ssp_codocu_ciuo;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: spocupacionciuo</para>
        /// <para>CAMPO: 12.Codigo de ocupación</para>
        /// <para>NOMBRE: ssp_codocu_ciuo (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Código de acuerdo a la Clasificación Internacional Uniforme
        /// de Ocupaciones (CIUO). En los casos en que no se tiene esta
        /// información registrar (9999). En el caso que no aplique registrar
        /// (9998).
        /// </para>
        /// </summary>
        public String Ssp_codocu_ciuo
        {
            get { return _ssp_codocu_ciuo; }
            set
            {
                if (_ssp_codocu_ciuo == value) return;
                _ssp_codocu_ciuo = value;
                OnPropertyChanged("Ssp_codocu_ciuo");
            }
        }
        #endregion
        #region Ssp_cam013_ms45: 13.Codigo de nivel educativo
        private String _ssp_cam013_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 13.Codigo de nivel educativo</para>
        /// <para>NOMBRE: ssp_cam013_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Registre según lo reporte el usuario:Preescolar,Básica Primaria,Básica
        /// Secundaria,Media Académica o Clásica,Media Técnica (Bachillerato
        /// Técnico),Normalista,Técnica Profesional etc.
        /// </para>
        /// </summary>
        public String Ssp_cam013_ms45
        {
            get { return _ssp_cam013_ms45; }
            set
            {
                if (_ssp_cam013_ms45 == value) return;
                _ssp_cam013_ms45 = value;
                OnPropertyChanged("Ssp_cam013_ms45");
            }
        }
        #endregion
        #region Ssp_cam014_ms45: 14.Gestacion
        private String _ssp_cam014_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 14.Gestacion</para>
        /// <para>NOMBRE: ssp_cam014_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///No aplica,Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam014_ms45
        {
            get { return _ssp_cam014_ms45; }
            set
            {
                if (_ssp_cam014_ms45 == value) return;
                _ssp_cam014_ms45 = value;
                OnPropertyChanged("Ssp_cam014_ms45");
            }
        }
        #endregion
        #region Ssp_cam015_ms45: 15.Sifilis Gestacional o congénita
        private String _ssp_cam015_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 15.Sifilis Gestacional o congénita</para>
        /// <para>NOMBRE: ssp_cam015_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// No aplica,Si es mujer con sífilis gestacional,Si es recién
        /// nacido con sífilis congénita,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam015_ms45
        {
            get { return _ssp_cam015_ms45; }
            set
            {
                if (_ssp_cam015_ms45 == value) return;
                _ssp_cam015_ms45 = value;
                OnPropertyChanged("Ssp_cam015_ms45");
            }
        }
        #endregion
        #region Ssp_cam016_ms45: 16.Hipertension Inducida por la Gestació
        private String _ssp_cam016_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 16.Hipertension Inducida por la Gestació</para>
        /// <para>NOMBRE: ssp_cam016_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///No aplica,Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam016_ms45
        {
            get { return _ssp_cam016_ms45; }
            set
            {
                if (_ssp_cam016_ms45 == value) return;
                _ssp_cam016_ms45 = value;
                OnPropertyChanged("Ssp_cam016_ms45");
            }
        }
        #endregion
        #region Ssp_cam017_ms45: 17.Hipotiroidismo Congénito
        private String _ssp_cam017_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 17.Hipotiroidismo Congénito</para>
        /// <para>NOMBRE: ssp_cam017_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///No aplica,Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam017_ms45
        {
            get { return _ssp_cam017_ms45; }
            set
            {
                if (_ssp_cam017_ms45 == value) return;
                _ssp_cam017_ms45 = value;
                OnPropertyChanged("Ssp_cam017_ms45");
            }
        }
        #endregion
        #region Ssp_cam018_ms45: 18.Sintomatico Respiratorio
        private String _ssp_cam018_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 18.Sintomatico Respiratorio</para>
        /// <para>NOMBRE: ssp_cam018_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam018_ms45
        {
            get { return _ssp_cam018_ms45; }
            set
            {
                if (_ssp_cam018_ms45 == value) return;
                _ssp_cam018_ms45 = value;
                OnPropertyChanged("Ssp_cam018_ms45");
            }
        }
        #endregion
        #region Ssp_cam019_ms45: 19.Tuberculosis Multidrogoresistente
        private String _ssp_cam019_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 19.Tuberculosis Multidrogoresistente</para>
        /// <para>NOMBRE: ssp_cam019_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///No aplica,Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam019_ms45
        {
            get { return _ssp_cam019_ms45; }
            set
            {
                if (_ssp_cam019_ms45 == value) return;
                _ssp_cam019_ms45 = value;
                OnPropertyChanged("Ssp_cam019_ms45");
            }
        }
        #endregion
        #region Ssp_cam020_ms45: 20.Lepra
        private String _ssp_cam020_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 20.Lepra</para>
        /// <para>NOMBRE: ssp_cam020_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Pausibacilar,Multibacilar,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam020_ms45
        {
            get { return _ssp_cam020_ms45; }
            set
            {
                if (_ssp_cam020_ms45 == value) return;
                _ssp_cam020_ms45 = value;
                OnPropertyChanged("Ssp_cam020_ms45");
            }
        }
        #endregion
        #region Ssp_cam021_ms45: 21.Obesidad o Desnutrición Proteico Caló
        private String _ssp_cam021_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 21.Obesidad o Desnutrición Proteico Caló</para>
        /// <para>NOMBRE: ssp_cam021_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Si es Obesidad,Si es Desnutrición Proteico Calórica,No,Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam021_ms45
        {
            get { return _ssp_cam021_ms45; }
            set
            {
                if (_ssp_cam021_ms45 == value) return;
                _ssp_cam021_ms45 = value;
                OnPropertyChanged("Ssp_cam021_ms45");
            }
        }
        #endregion
        #region Ssp_cam022_ms45: 22.Mujer Victima de Maltrato
        private String _ssp_cam022_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 22.Mujer Victima de Maltrato</para>
        /// <para>NOMBRE: ssp_cam022_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// No aplica,Si es Mujer víctima del maltrato,Si es Menor víctima
        /// del maltrato,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam022_ms45
        {
            get { return _ssp_cam022_ms45; }
            set
            {
                if (_ssp_cam022_ms45 == value) return;
                _ssp_cam022_ms45 = value;
                OnPropertyChanged("Ssp_cam022_ms45");
            }
        }
        #endregion
        #region Ssp_cam023_ms45: 23.Victima de Violencia Sexual
        private String _ssp_cam023_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 23.Victima de Violencia Sexual</para>
        /// <para>NOMBRE: ssp_cam023_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Victima de Violencia Sexual Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam023_ms45
        {
            get { return _ssp_cam023_ms45; }
            set
            {
                if (_ssp_cam023_ms45 == value) return;
                _ssp_cam023_ms45 = value;
                OnPropertyChanged("Ssp_cam023_ms45");
            }
        }
        #endregion
        #region Ssp_cam024_ms45: 24.Infecciones de Trasmisión Sexual
        private String _ssp_cam024_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 24.Infecciones de Trasmisión Sexual</para>
        /// <para>NOMBRE: ssp_cam024_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Infecciones de Trasmision Sexual 0- No Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam024_ms45
        {
            get { return _ssp_cam024_ms45; }
            set
            {
                if (_ssp_cam024_ms45 == value) return;
                _ssp_cam024_ms45 = value;
                OnPropertyChanged("Ssp_cam024_ms45");
            }
        }
        #endregion
        #region Ssp_cam025_ms45: 25.Enfermedad Mental
        private String _ssp_cam025_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 25.Enfermedad Mental</para>
        /// <para>NOMBRE: ssp_cam025_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Enfermedad Mental Si el diagnóstico es Ansiedad,Si el diagnóstico
        /// es Depresión,Si el diagnóstico es esquizofrenia,Si el diagnóstico
        /// es Déficit de atención por Hiperactividad ETC
        /// </para>
        /// </summary>
        public String Ssp_cam025_ms45
        {
            get { return _ssp_cam025_ms45; }
            set
            {
                if (_ssp_cam025_ms45 == value) return;
                _ssp_cam025_ms45 = value;
                OnPropertyChanged("Ssp_cam025_ms45");
            }
        }
        #endregion
        #region Ssp_cam026_ms45: 26.Cancer de Cérvix
        private String _ssp_cam026_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 26.Cancer de Cérvix</para>
        /// <para>NOMBRE: ssp_cam026_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Cancer de Cervix No aplica,Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam026_ms45
        {
            get { return _ssp_cam026_ms45; }
            set
            {
                if (_ssp_cam026_ms45 == value) return;
                _ssp_cam026_ms45 = value;
                OnPropertyChanged("Ssp_cam026_ms45");
            }
        }
        #endregion
        #region Ssp_cam027_ms45: 27.Cancer de Seno
        private String _ssp_cam027_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 27.Cancer de Seno</para>
        /// <para>NOMBRE: ssp_cam027_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Cancer de Seno Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam027_ms45
        {
            get { return _ssp_cam027_ms45; }
            set
            {
                if (_ssp_cam027_ms45 == value) return;
                _ssp_cam027_ms45 = value;
                OnPropertyChanged("Ssp_cam027_ms45");
            }
        }
        #endregion
        #region Ssp_cam028_ms45: 28.Fluorosis Dental
        private String _ssp_cam028_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 28.Fluorosis Dental</para>
        /// <para>NOMBRE: ssp_cam028_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///Fluorosis Dental Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam028_ms45
        {
            get { return _ssp_cam028_ms45; }
            set
            {
                if (_ssp_cam028_ms45 == value) return;
                _ssp_cam028_ms45 = value;
                OnPropertyChanged("Ssp_cam028_ms45");
            }
        }
        #endregion
        #region Ssp_cam029_ms45: 29.Fecha del Peso
        private DateTime _ssp_cam029_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 29.Fecha del Peso</para>
        /// <para>NOMBRE: ssp_cam029_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam029_ms45
        {
            get { return _ssp_cam029_ms45; }
            set
            {
                if (_ssp_cam029_ms45 == value) return;
                _ssp_cam029_ms45 = value;
                OnPropertyChanged("Ssp_cam029_ms45");
            }
        }
        #endregion
        #region Ssp_cam030_ms45: 30.Peso en Kilogramos
        private float _ssp_cam030_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 30.Peso en Kilogramos</para>
        /// <para>NOMBRE: ssp_cam030_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Peso en Kilogramos Se registra el dato obtenido de la medición.
        /// Si no se toma registrar 999
        /// </para>
        /// </summary>
        public float Ssp_cam030_ms45
        {
            get { return _ssp_cam030_ms45; }
            set
            {
                if (_ssp_cam030_ms45 == value) return;
                _ssp_cam030_ms45 = value;
                OnPropertyChanged("Ssp_cam030_ms45");
            }
        }
        #endregion
        #region Ssp_cam031_ms45: 31.Fecha de la Talla
        private DateTime _ssp_cam031_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 31.Fecha de la Talla</para>
        /// <para>NOMBRE: ssp_cam031_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam031_ms45
        {
            get { return _ssp_cam031_ms45; }
            set
            {
                if (_ssp_cam031_ms45 == value) return;
                _ssp_cam031_ms45 = value;
                OnPropertyChanged("Ssp_cam031_ms45");
            }
        }
        #endregion
        #region Ssp_cam032_ms45: 32.Talla en Centímetros
        private int _ssp_cam032_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 32.Talla en Centímetros</para>
        /// <para>NOMBRE: ssp_cam032_ms45 (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato obtenido de la medición. Si no se toma
        /// registrar 999
        /// </para>
        /// </summary>
        public int Ssp_cam032_ms45
        {
            get { return _ssp_cam032_ms45; }
            set
            {
                if (_ssp_cam032_ms45 == value) return;
                _ssp_cam032_ms45 = value;
                OnPropertyChanged("Ssp_cam032_ms45");
            }
        }
        #endregion
        #region Ssp_cam033_ms45: 33.Fecha Probable de Parto
        private DateTime _ssp_cam033_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 33.Fecha Probable de Parto</para>
        /// <para>NOMBRE: ssp_cam033_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam033_ms45
        {
            get { return _ssp_cam033_ms45; }
            set
            {
                if (_ssp_cam033_ms45 == value) return;
                _ssp_cam033_ms45 = value;
                OnPropertyChanged("Ssp_cam033_ms45");
            }
        }
        #endregion
        #region Ssp_cam034_ms45: 34.Edad Gestacional al Nacer
        private int _ssp_cam034_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 34.Edad Gestacional al Nacer</para>
        /// <para>NOMBRE: ssp_cam034_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato de la edad gestacional en semanas. Si no
        /// tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public int Ssp_cam034_ms45
        {
            get { return _ssp_cam034_ms45; }
            set
            {
                if (_ssp_cam034_ms45 == value) return;
                _ssp_cam034_ms45 = value;
                OnPropertyChanged("Ssp_cam034_ms45");
            }
        }
        #endregion
        #region Ssp_cam035_ms45: 35.BCG
        private String _ssp_cam035_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 35.BCG</para>
        /// <para>NOMBRE: ssp_cam035_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// BCG Registre el dato de la última dosis aplicada así:No aplica,Una
        /// dosis,No se administra por una Tradición,No se administra por
        /// una Condición de Salud ETC
        /// </para>
        /// </summary>
        public String Ssp_cam035_ms45
        {
            get { return _ssp_cam035_ms45; }
            set
            {
                if (_ssp_cam035_ms45 == value) return;
                _ssp_cam035_ms45 = value;
                OnPropertyChanged("Ssp_cam035_ms45");
            }
        }
        #endregion
        #region Ssp_cam036_ms45: 36.Hepatitis B menores de 1 año
        private String _ssp_cam036_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 36.Hepatitis B menores de 1 año</para>
        /// <para>NOMBRE: ssp_cam036_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Hepatitis B menores de 1 año Registre el dato de la última
        /// dosis aplicada así: No aplica,Una dosis,No se administra por
        /// una Tradición,No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public String Ssp_cam036_ms45
        {
            get { return _ssp_cam036_ms45; }
            set
            {
                if (_ssp_cam036_ms45 == value) return;
                _ssp_cam036_ms45 = value;
                OnPropertyChanged("Ssp_cam036_ms45");
            }
        }
        #endregion
        #region Ssp_cam037_ms45: 37.Pentavalente
        private String _ssp_cam037_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 37.Pentavalente</para>
        /// <para>NOMBRE: ssp_cam037_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Pentavalente Registre el dato de la última dosis aplicada así:
        /// No aplica,Una Dosis,Dos Dosis,Tres Dosis,No se administra por
        /// una Tradición ETC
        /// </para>
        /// </summary>
        public String Ssp_cam037_ms45
        {
            get { return _ssp_cam037_ms45; }
            set
            {
                if (_ssp_cam037_ms45 == value) return;
                _ssp_cam037_ms45 = value;
                OnPropertyChanged("Ssp_cam037_ms45");
            }
        }
        #endregion
        #region Ssp_cam038_ms45: 38.Polio
        private String _ssp_cam038_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 38.Polio</para>
        /// <para>NOMBRE: ssp_cam038_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Polio Registre el dato de la última dosis aplicada así: No
        /// aplica,Una Dosis,Dos Dosis,Tres Dosis,Cuatro Dosis, Cinco Dosis,No
        /// se administra por una Tradición ETC
        /// </para>
        /// </summary>
        public String Ssp_cam038_ms45
        {
            get { return _ssp_cam038_ms45; }
            set
            {
                if (_ssp_cam038_ms45 == value) return;
                _ssp_cam038_ms45 = value;
                OnPropertyChanged("Ssp_cam038_ms45");
            }
        }
        #endregion
        #region Ssp_cam039_ms45: 39.DPT menores de 5 años
        private String _ssp_cam039_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 39.DPT menores de 5 años</para>
        /// <para>NOMBRE: ssp_cam039_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// DPT menores de 5 años Registre el dato de la última dosis aplicada
        /// así: No aplica,Cuatro Dosis, Cinco Dosis,No se administra por
        /// una Tradición ETC
        /// </para>
        /// </summary>
        public String Ssp_cam039_ms45
        {
            get { return _ssp_cam039_ms45; }
            set
            {
                if (_ssp_cam039_ms45 == value) return;
                _ssp_cam039_ms45 = value;
                OnPropertyChanged("Ssp_cam039_ms45");
            }
        }
        #endregion
        #region Ssp_cam040_ms45: 40.Rotavirus
        private String _ssp_cam040_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 40.Rotavirus</para>
        /// <para>NOMBRE: ssp_cam040_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Rotavirus Registre el dato de la última dosis aplicada así:
        /// No aplica,Una Dosis,Dos Dosis,No se administra por una Tradición
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam040_ms45
        {
            get { return _ssp_cam040_ms45; }
            set
            {
                if (_ssp_cam040_ms45 == value) return;
                _ssp_cam040_ms45 = value;
                OnPropertyChanged("Ssp_cam040_ms45");
            }
        }
        #endregion
        #region Ssp_cam041_ms45: 41.Neumococo
        private String _ssp_cam041_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 41.Neumococo</para>
        /// <para>NOMBRE: ssp_cam041_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Neumococo Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin
        /// dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam041_ms45
        {
            get { return _ssp_cam041_ms45; }
            set
            {
                if (_ssp_cam041_ms45 == value) return;
                _ssp_cam041_ms45 = value;
                OnPropertyChanged("Ssp_cam041_ms45");
            }
        }
        #endregion
        #region Ssp_cam042_ms45: 42.Influenza Niños
        private String _ssp_cam042_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 42.Influenza Niños</para>
        /// <para>NOMBRE: ssp_cam042_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Influenza Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC
        /// </para>
        /// </summary>
        public String Ssp_cam042_ms45
        {
            get { return _ssp_cam042_ms45; }
            set
            {
                if (_ssp_cam042_ms45 == value) return;
                _ssp_cam042_ms45 = value;
                OnPropertyChanged("Ssp_cam042_ms45");
            }
        }
        #endregion
        #region Ssp_cam043_ms45: 43.Fiebre Amarilla niños de 1 año
        private String _ssp_cam043_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 43.Fiebre Amarilla niños de 1 año</para>
        /// <para>NOMBRE: ssp_cam043_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Fiebre Amarilla niños de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra
        /// por una Tradición ETC
        /// </para>
        /// </summary>
        public String Ssp_cam043_ms45
        {
            get { return _ssp_cam043_ms45; }
            set
            {
                if (_ssp_cam043_ms45 == value) return;
                _ssp_cam043_ms45 = value;
                OnPropertyChanged("Ssp_cam043_ms45");
            }
        }
        #endregion
        #region Ssp_cam044_ms45: 44.Hepatitis A
        private String _ssp_cam044_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 44.Hepatitis A</para>
        /// <para>NOMBRE: ssp_cam044_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Hepatitis A Registre el dato de la última dosis aplicada así:
        /// 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición
        /// 3- No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public String Ssp_cam044_ms45
        {
            get { return _ssp_cam044_ms45; }
            set
            {
                if (_ssp_cam044_ms45 == value) return;
                _ssp_cam044_ms45 = value;
                OnPropertyChanged("Ssp_cam044_ms45");
            }
        }
        #endregion
        #region Ssp_cam045_ms45: 45.Triple Viral Niños
        private String _ssp_cam045_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 45.Triple Viral Niños</para>
        /// <para>NOMBRE: ssp_cam045_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Triple Viral Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No
        /// se administra por una Tradición 4- No se administra por una
        /// Condición de Salud ETC
        /// </para>
        /// </summary>
        public String Ssp_cam045_ms45
        {
            get { return _ssp_cam045_ms45; }
            set
            {
                if (_ssp_cam045_ms45 == value) return;
                _ssp_cam045_ms45 = value;
                OnPropertyChanged("Ssp_cam045_ms45");
            }
        }
        #endregion
        #region Ssp_cam046_ms45: 46.Virus del Papiloma Humano (VPH)
        private String _ssp_cam046_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 46.Virus del Papiloma Humano (VPH)</para>
        /// <para>NOMBRE: ssp_cam046_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Virus del Papiloma Humano (VPH) Registre el dato de la última
        /// dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera
        /// Dosis 3- Sin dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam046_ms45
        {
            get { return _ssp_cam046_ms45; }
            set
            {
                if (_ssp_cam046_ms45 == value) return;
                _ssp_cam046_ms45 = value;
                OnPropertyChanged("Ssp_cam046_ms45");
            }
        }
        #endregion
        #region Ssp_cam047_ms45: 47.TD o TT Mujeres en Edad Fértil 15 a 4
        private String _ssp_cam047_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 47.TD o TT Mujeres en Edad Fértil 15 a 4</para>
        /// <para>NOMBRE: ssp_cam047_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato
        /// de la última dosis aplicada así: 0- Primera Dosis 1- Segunda
        /// Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC
        /// </para>
        /// </summary>
        public String Ssp_cam047_ms45
        {
            get { return _ssp_cam047_ms45; }
            set
            {
                if (_ssp_cam047_ms45 == value) return;
                _ssp_cam047_ms45 = value;
                OnPropertyChanged("Ssp_cam047_ms45");
            }
        }
        #endregion
        #region Ssp_cam048_ms45: 48.Control de Placa Bacteriana
        private String _ssp_cam048_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 48.Control de Placa Bacteriana</para>
        /// <para>NOMBRE: ssp_cam048_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Control de Placa Bacteriana 0- No se realiza por una Tradición
        /// 1- No se realiza por una Condición de Salud 2- No se realiza
        /// por Negación del usuario
        /// </para>
        /// </summary>
        public String Ssp_cam048_ms45
        {
            get { return _ssp_cam048_ms45; }
            set
            {
                if (_ssp_cam048_ms45 == value) return;
                _ssp_cam048_ms45 = value;
                OnPropertyChanged("Ssp_cam048_ms45");
            }
        }
        #endregion
        #region Ssp_cam049_ms45: 49.Fecha atención parto o cesárea
        private DateTime _ssp_cam049_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 49.Fecha atención parto o cesárea</para>
        /// <para>NOMBRE: ssp_cam049_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam049_ms45
        {
            get { return _ssp_cam049_ms45; }
            set
            {
                if (_ssp_cam049_ms45 == value) return;
                _ssp_cam049_ms45 = value;
                OnPropertyChanged("Ssp_cam049_ms45");
            }
        }
        #endregion
        #region Ssp_cam050_ms45: 50.Fecha salida de la atención del parto
        private DateTime _ssp_cam050_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 50.Fecha salida de la atención del parto</para>
        /// <para>NOMBRE: ssp_cam050_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Fecha salida de la atencion del parto o cesarea AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam050_ms45
        {
            get { return _ssp_cam050_ms45; }
            set
            {
                if (_ssp_cam050_ms45 == value) return;
                _ssp_cam050_ms45 = value;
                OnPropertyChanged("Ssp_cam050_ms45");
            }
        }
        #endregion
        #region Ssp_cam051_ms45: 51.Fecha de consejería en Lactancia Mate
        private DateTime _ssp_cam051_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 51.Fecha de consejería en Lactancia Mate</para>
        /// <para>NOMBRE: ssp_cam051_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no se realiza por una
        /// Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam051_ms45
        {
            get { return _ssp_cam051_ms45; }
            set
            {
                if (_ssp_cam051_ms45 == value) return;
                _ssp_cam051_ms45 = value;
                OnPropertyChanged("Ssp_cam051_ms45");
            }
        }
        #endregion
        #region Ssp_cam052_ms45: 52.Control Recién Nacido
        private DateTime _ssp_cam052_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 52.Control Recién Nacido</para>
        /// <para>NOMBRE: ssp_cam052_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam052_ms45
        {
            get { return _ssp_cam052_ms45; }
            set
            {
                if (_ssp_cam052_ms45 == value) return;
                _ssp_cam052_ms45 = value;
                OnPropertyChanged("Ssp_cam052_ms45");
            }
        }
        #endregion
        #region Ssp_cam053_ms45: 53.Planificacion Familiar Primera vez
        private DateTime _ssp_cam053_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 53.Planificacion Familiar Primera vez</para>
        /// <para>NOMBRE: ssp_cam053_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam053_ms45
        {
            get { return _ssp_cam053_ms45; }
            set
            {
                if (_ssp_cam053_ms45 == value) return;
                _ssp_cam053_ms45 = value;
                OnPropertyChanged("Ssp_cam053_ms45");
            }
        }
        #endregion
        #region Ssp_cam054_ms45: 54.Suministro de Método Anticonceptivo
        private String _ssp_cam054_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 54.Suministro de Método Anticonceptivo</para>
        /// <para>NOMBRE: ssp_cam054_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino
        /// 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico
        /// 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam054_ms45
        {
            get { return _ssp_cam054_ms45; }
            set
            {
                if (_ssp_cam054_ms45 == value) return;
                _ssp_cam054_ms45 = value;
                OnPropertyChanged("Ssp_cam054_ms45");
            }
        }
        #endregion
        #region Ssp_cam055_ms45: 55.Fecha Suministro de Método Anticoncep
        private DateTime _ssp_cam055_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 55.Fecha Suministro de Método Anticoncep</para>
        /// <para>NOMBRE: ssp_cam055_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam055_ms45
        {
            get { return _ssp_cam055_ms45; }
            set
            {
                if (_ssp_cam055_ms45 == value) return;
                _ssp_cam055_ms45 = value;
                OnPropertyChanged("Ssp_cam055_ms45");
            }
        }
        #endregion
        #region Ssp_cam056_ms45: 56.Control Prenatal de Primera vez
        private DateTime _ssp_cam056_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 56.Control Prenatal de Primera vez</para>
        /// <para>NOMBRE: ssp_cam056_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam056_ms45
        {
            get { return _ssp_cam056_ms45; }
            set
            {
                if (_ssp_cam056_ms45 == value) return;
                _ssp_cam056_ms45 = value;
                OnPropertyChanged("Ssp_cam056_ms45");
            }
        }
        #endregion
        #region Ssp_cam057_ms45: 57.Control Prenatal
        private int _ssp_cam057_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 57.Control Prenatal</para>
        /// <para>NOMBRE: ssp_cam057_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal Registre el número de controles que ha tenido
        /// en el último período de reporte durante la gestación actual,
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int Ssp_cam057_ms45
        {
            get { return _ssp_cam057_ms45; }
            set
            {
                if (_ssp_cam057_ms45 == value) return;
                _ssp_cam057_ms45 = value;
                OnPropertyChanged("Ssp_cam057_ms45");
            }
        }
        #endregion
        #region Ssp_cam058_ms45: 58.ultimo Control Prenatal
        private DateTime _ssp_cam058_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 58.ultimo Control Prenatal</para>
        /// <para>NOMBRE: ssp_cam058_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam058_ms45
        {
            get { return _ssp_cam058_ms45; }
            set
            {
                if (_ssp_cam058_ms45 == value) return;
                _ssp_cam058_ms45 = value;
                OnPropertyChanged("Ssp_cam058_ms45");
            }
        }
        #endregion
        #region Ssp_cam059_ms45: 59.Suministro de acido Fólico en el ulti
        private String _ssp_cam059_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 59.Suministro de acido Fólico en el ulti</para>
        /// <para>NOMBRE: ssp_cam059_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación de
        /// la usuaria 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam059_ms45
        {
            get { return _ssp_cam059_ms45; }
            set
            {
                if (_ssp_cam059_ms45 == value) return;
                _ssp_cam059_ms45 = value;
                OnPropertyChanged("Ssp_cam059_ms45");
            }
        }
        #endregion
        #region Ssp_cam060_ms45: 60.Suministro de Sulfato Ferroso en el u
        private String _ssp_cam060_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 60.Suministro de Sulfato Ferroso en el u</para>
        /// <para>NOMBRE: ssp_cam060_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam060_ms45
        {
            get { return _ssp_cam060_ms45; }
            set
            {
                if (_ssp_cam060_ms45 == value) return;
                _ssp_cam060_ms45 = value;
                OnPropertyChanged("Ssp_cam060_ms45");
            }
        }
        #endregion
        #region Ssp_cam061_ms45: 61.Suministro de Carbonato de Calcio en
        private String _ssp_cam061_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 61.Suministro de Carbonato de Calcio en</para>
        /// <para>NOMBRE: ssp_cam061_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam061_ms45
        {
            get { return _ssp_cam061_ms45; }
            set
            {
                if (_ssp_cam061_ms45 == value) return;
                _ssp_cam061_ms45 = value;
                OnPropertyChanged("Ssp_cam061_ms45");
            }
        }
        #endregion
        #region Ssp_cam062_ms45: 62.Valoracion de la Agudeza Visual
        private DateTime _ssp_cam062_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 62.Valoracion de la Agudeza Visual</para>
        /// <para>NOMBRE: ssp_cam062_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no
        /// se realiza por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam062_ms45
        {
            get { return _ssp_cam062_ms45; }
            set
            {
                if (_ssp_cam062_ms45 == value) return;
                _ssp_cam062_ms45 = value;
                OnPropertyChanged("Ssp_cam062_ms45");
            }
        }
        #endregion
        #region Ssp_cam063_ms45: 63.Consulta por Oftalmología
        private DateTime _ssp_cam063_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 63.Consulta por Oftalmología</para>
        /// <para>NOMBRE: ssp_cam063_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        /// Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam063_ms45
        {
            get { return _ssp_cam063_ms45; }
            set
            {
                if (_ssp_cam063_ms45 == value) return;
                _ssp_cam063_ms45 = value;
                OnPropertyChanged("Ssp_cam063_ms45");
            }
        }
        #endregion
        #region Ssp_cam064_ms45: 64.Fecha Diagnostico Desnutrición Protei
        private DateTime _ssp_cam064_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 64.Fecha Diagnostico Desnutrición Protei</para>
        /// <para>NOMBRE: ssp_cam064_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam064_ms45
        {
            get { return _ssp_cam064_ms45; }
            set
            {
                if (_ssp_cam064_ms45 == value) return;
                _ssp_cam064_ms45 = value;
                OnPropertyChanged("Ssp_cam064_ms45");
            }
        }
        #endregion
        #region Ssp_cam065_ms45: 65.Consulta Mujer o Menor Victima del Ma
        private DateTime _ssp_cam065_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 65.Consulta Mujer o Menor Victima del Ma</para>
        /// <para>NOMBRE: ssp_cam065_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam065_ms45
        {
            get { return _ssp_cam065_ms45; }
            set
            {
                if (_ssp_cam065_ms45 == value) return;
                _ssp_cam065_ms45 = value;
                OnPropertyChanged("Ssp_cam065_ms45");
            }
        }
        #endregion
        #region Ssp_cam066_ms45: 66.Consulta Victimas de Violencia Sexual
        private DateTime _ssp_cam066_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 66.Consulta Victimas de Violencia Sexual</para>
        /// <para>NOMBRE: ssp_cam066_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam066_ms45
        {
            get { return _ssp_cam066_ms45; }
            set
            {
                if (_ssp_cam066_ms45 == value) return;
                _ssp_cam066_ms45 = value;
                OnPropertyChanged("Ssp_cam066_ms45");
            }
        }
        #endregion
        #region Ssp_cam067_ms45: 67.Consulta Nutrición
        private DateTime _ssp_cam067_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 67.Consulta Nutrición</para>
        /// <para>NOMBRE: ssp_cam067_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam067_ms45
        {
            get { return _ssp_cam067_ms45; }
            set
            {
                if (_ssp_cam067_ms45 == value) return;
                _ssp_cam067_ms45 = value;
                OnPropertyChanged("Ssp_cam067_ms45");
            }
        }
        #endregion
        #region Ssp_cam068_ms45: 68.Consulta de Psicología
        private DateTime _ssp_cam068_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 68.Consulta de Psicología</para>
        /// <para>NOMBRE: ssp_cam068_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam068_ms45
        {
            get { return _ssp_cam068_ms45; }
            set
            {
                if (_ssp_cam068_ms45 == value) return;
                _ssp_cam068_ms45 = value;
                OnPropertyChanged("Ssp_cam068_ms45");
            }
        }
        #endregion
        #region Ssp_cam069_ms45: 69.Consulta de Crecimiento y Desarrollo
        private DateTime _ssp_cam069_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 69.Consulta de Crecimiento y Desarrollo</para>
        /// <para>NOMBRE: ssp_cam069_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam069_ms45
        {
            get { return _ssp_cam069_ms45; }
            set
            {
                if (_ssp_cam069_ms45 == value) return;
                _ssp_cam069_ms45 = value;
                OnPropertyChanged("Ssp_cam069_ms45");
            }
        }
        #endregion
        #region Ssp_cam070_ms45: 70.Suministro de Sulfato Ferroso en la u
        private String _ssp_cam070_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 70.Suministro de Sulfato Ferroso en la u</para>
        /// <para>NOMBRE: ssp_cam070_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam070_ms45
        {
            get { return _ssp_cam070_ms45; }
            set
            {
                if (_ssp_cam070_ms45 == value) return;
                _ssp_cam070_ms45 = value;
                OnPropertyChanged("Ssp_cam070_ms45");
            }
        }
        #endregion
        #region Ssp_cam071_ms45: 71.Suministro de Vitamina A en la ultima
        private String _ssp_cam071_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 71.Suministro de Vitamina A en la ultima</para>
        /// <para>NOMBRE: ssp_cam071_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam071_ms45
        {
            get { return _ssp_cam071_ms45; }
            set
            {
                if (_ssp_cam071_ms45 == value) return;
                _ssp_cam071_ms45 = value;
                OnPropertyChanged("Ssp_cam071_ms45");
            }
        }
        #endregion
        #region Ssp_cam072_ms45: 72.Consulta de Joven Primera vez
        private DateTime _ssp_cam072_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 72.Consulta de Joven Primera vez</para>
        /// <para>NOMBRE: ssp_cam072_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam072_ms45
        {
            get { return _ssp_cam072_ms45; }
            set
            {
                if (_ssp_cam072_ms45 == value) return;
                _ssp_cam072_ms45 = value;
                OnPropertyChanged("Ssp_cam072_ms45");
            }
        }
        #endregion
        #region Ssp_cam073_ms45: 73.Consulta de Adulto Primera vez
        private DateTime _ssp_cam073_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 73.Consulta de Adulto Primera vez</para>
        /// <para>NOMBRE: ssp_cam073_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam073_ms45
        {
            get { return _ssp_cam073_ms45; }
            set
            {
                if (_ssp_cam073_ms45 == value) return;
                _ssp_cam073_ms45 = value;
                OnPropertyChanged("Ssp_cam073_ms45");
            }
        }
        #endregion
        #region Ssp_cam074_ms45: 74.Preservativos entregados a pacientes
        private int _ssp_cam074_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 74.Preservativos entregados a pacientes</para>
        /// <para>NOMBRE: ssp_cam074_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Preservativos entregados a pacientes con ITS Registre el número
        /// de Preservativos entregados durante el período de reporte.
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// ETC
        /// </para>
        /// </summary>
        public int Ssp_cam074_ms45
        {
            get { return _ssp_cam074_ms45; }
            set
            {
                if (_ssp_cam074_ms45 == value) return;
                _ssp_cam074_ms45 = value;
                OnPropertyChanged("Ssp_cam074_ms45");
            }
        }
        #endregion
        #region Ssp_cam075_ms45: 75.Asesoria Pre test Elisa para VIH
        private DateTime _ssp_cam075_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 75.Asesoria Pre test Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam075_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam075_ms45
        {
            get { return _ssp_cam075_ms45; }
            set
            {
                if (_ssp_cam075_ms45 == value) return;
                _ssp_cam075_ms45 = value;
                OnPropertyChanged("Ssp_cam075_ms45");
            }
        }
        #endregion
        #region Ssp_cam076_ms45: 76.Asesoria Pos test Elisa para VIH
        private DateTime _ssp_cam076_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 76.Asesoria Pos test Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam076_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam076_ms45
        {
            get { return _ssp_cam076_ms45; }
            set
            {
                if (_ssp_cam076_ms45 == value) return;
                _ssp_cam076_ms45 = value;
                OnPropertyChanged("Ssp_cam076_ms45");
            }
        }
        #endregion
        #region Ssp_cam077_ms45: 77.Paciente con Diagnostico de: Ansiedad
        private String _ssp_cam077_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 77.Paciente con Diagnostico de: Ansiedad</para>
        /// <para>NOMBRE: ssp_cam077_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// 0- No recibió atención por tener una tradición que se lo impide
        /// 1- No recibió atención por una condición de salud 2- No recibió
        /// atención por negación del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam077_ms45
        {
            get { return _ssp_cam077_ms45; }
            set
            {
                if (_ssp_cam077_ms45 == value) return;
                _ssp_cam077_ms45 = value;
                OnPropertyChanged("Ssp_cam077_ms45");
            }
        }
        #endregion
        #region Ssp_cam078_ms45: 78.Fecha Antígeno de Superficie Hepatiti
        private DateTime _ssp_cam078_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 78.Fecha Antígeno de Superficie Hepatiti</para>
        /// <para>NOMBRE: ssp_cam078_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam078_ms45
        {
            get { return _ssp_cam078_ms45; }
            set
            {
                if (_ssp_cam078_ms45 == value) return;
                _ssp_cam078_ms45 = value;
                OnPropertyChanged("Ssp_cam078_ms45");
            }
        }
        #endregion
        #region Ssp_cam079_ms45: 79.Resultado Antígeno de Superficie Hepa
        private String _ssp_cam079_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 79.Resultado Antígeno de Superficie Hepa</para>
        /// <para>NOMBRE: ssp_cam079_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Resultado Antigeno de Superficie Hepatitis B en Gestantes 0-
        /// Negativo 1- Positivo 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam079_ms45
        {
            get { return _ssp_cam079_ms45; }
            set
            {
                if (_ssp_cam079_ms45 == value) return;
                _ssp_cam079_ms45 = value;
                OnPropertyChanged("Ssp_cam079_ms45");
            }
        }
        #endregion
        #region Ssp_cam080_ms45: 80.Fecha Serología para Sífilis
        private DateTime _ssp_cam080_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 80.Fecha Serología para Sífilis</para>
        /// <para>NOMBRE: ssp_cam080_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 84</para>
        /// <para>DESCRIPCION:
        /// Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam080_ms45
        {
            get { return _ssp_cam080_ms45; }
            set
            {
                if (_ssp_cam080_ms45 == value) return;
                _ssp_cam080_ms45 = value;
                OnPropertyChanged("Ssp_cam080_ms45");
            }
        }
        #endregion
        #region Ssp_cam081_ms45: 81.Resultado Serología para Sífilis
        private String _ssp_cam081_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 81.Resultado Serología para Sífilis</para>
        /// <para>NOMBRE: ssp_cam081_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 85</para>
        /// <para>DESCRIPCION:
        /// Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva
        /// 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam081_ms45
        {
            get { return _ssp_cam081_ms45; }
            set
            {
                if (_ssp_cam081_ms45 == value) return;
                _ssp_cam081_ms45 = value;
                OnPropertyChanged("Ssp_cam081_ms45");
            }
        }
        #endregion
        #region Ssp_cam082_ms45: 82.Fecha de Toma de Elisa para VIH
        private DateTime _ssp_cam082_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 82.Fecha de Toma de Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam082_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 86</para>
        /// <para>DESCRIPCION:
        /// Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam082_ms45
        {
            get { return _ssp_cam082_ms45; }
            set
            {
                if (_ssp_cam082_ms45 == value) return;
                _ssp_cam082_ms45 = value;
                OnPropertyChanged("Ssp_cam082_ms45");
            }
        }
        #endregion
        #region Ssp_cam083_ms45: 83.Resultado Elisa para VIH
        private String _ssp_cam083_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 83.Resultado Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam083_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 87</para>
        /// <para>DESCRIPCION:
        /// Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado
        /// 3- Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam083_ms45
        {
            get { return _ssp_cam083_ms45; }
            set
            {
                if (_ssp_cam083_ms45 == value) return;
                _ssp_cam083_ms45 = value;
                OnPropertyChanged("Ssp_cam083_ms45");
            }
        }
        #endregion
        #region Ssp_cam084_ms45: 84.Fecha TSH Neonatal
        private DateTime _ssp_cam084_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 84.Fecha TSH Neonatal</para>
        /// <para>NOMBRE: ssp_cam084_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 88</para>
        /// <para>DESCRIPCION:
        /// Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam084_ms45
        {
            get { return _ssp_cam084_ms45; }
            set
            {
                if (_ssp_cam084_ms45 == value) return;
                _ssp_cam084_ms45 = value;
                OnPropertyChanged("Ssp_cam084_ms45");
            }
        }
        #endregion
        #region Ssp_cam085_ms45: 85.Resultado de TSH Neonatal
        private String _ssp_cam085_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 85.Resultado de TSH Neonatal</para>
        /// <para>NOMBRE: ssp_cam085_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 89</para>
        /// <para>DESCRIPCION:
        /// Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato
        /// 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam085_ms45
        {
            get { return _ssp_cam085_ms45; }
            set
            {
                if (_ssp_cam085_ms45 == value) return;
                _ssp_cam085_ms45 = value;
                OnPropertyChanged("Ssp_cam085_ms45");
            }
        }
        #endregion
        #region Ssp_cam086_ms45: 86.Tamizaje Cáncer de Cuello Uterino
        private String _ssp_cam086_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 86.Tamizaje Cáncer de Cuello Uterino</para>
        /// <para>NOMBRE: ssp_cam086_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 90</para>
        /// <para>DESCRIPCION:
        /// Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public String Ssp_cam086_ms45
        {
            get { return _ssp_cam086_ms45; }
            set
            {
                if (_ssp_cam086_ms45 == value) return;
                _ssp_cam086_ms45 = value;
                OnPropertyChanged("Ssp_cam086_ms45");
            }
        }
        #endregion
        #region Ssp_cam087_ms45: 87.Citologia Cervico uterina
        private DateTime _ssp_cam087_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 87.Citologia Cervico uterina</para>
        /// <para>NOMBRE: ssp_cam087_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 91</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam087_ms45
        {
            get { return _ssp_cam087_ms45; }
            set
            {
                if (_ssp_cam087_ms45 == value) return;
                _ssp_cam087_ms45 = value;
                OnPropertyChanged("Ssp_cam087_ms45");
            }
        }
        #endregion
        #region Ssp_cam088_ms45: 88.Citologia Cervico uterina Resultados
        private String _ssp_cam088_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 88.Citologia Cervico uterina Resultados</para>
        /// <para>NOMBRE: ssp_cam088_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 92</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US
        /// (células escamosas atípicas de significado indeterminado) 2-
        /// ASC-H (células escamosas atípicas, que no puede descartar alto
        /// grado) 3- Lesión intraepitelial escamosa de bajo grado ETC
        /// </para>
        /// </summary>
        public String Ssp_cam088_ms45
        {
            get { return _ssp_cam088_ms45; }
            set
            {
                if (_ssp_cam088_ms45 == value) return;
                _ssp_cam088_ms45 = value;
                OnPropertyChanged("Ssp_cam088_ms45");
            }
        }
        #endregion
        #region Ssp_cam089_ms45: 89.Calidad en la Muestra de Citología Ce
        private String _ssp_cam089_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 89.Calidad en la Muestra de Citología Ce</para>
        /// <para>NOMBRE: ssp_cam089_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 93</para>
        /// <para>DESCRIPCION:
        /// Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria
        /// Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación
        /// Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato
        /// registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam089_ms45
        {
            get { return _ssp_cam089_ms45; }
            set
            {
                if (_ssp_cam089_ms45 == value) return;
                _ssp_cam089_ms45 = value;
                OnPropertyChanged("Ssp_cam089_ms45");
            }
        }
        #endregion
        #region Ssp_cam090_ms45: 90.Codigo de habilitación IPS donde se t
        private String _ssp_cam090_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 90.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam090_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 94</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Citologia Cervicouterina
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 999 Si no aplica registrar
        /// 0
        /// </para>
        /// </summary>
        public String Ssp_cam090_ms45
        {
            get { return _ssp_cam090_ms45; }
            set
            {
                if (_ssp_cam090_ms45 == value) return;
                _ssp_cam090_ms45 = value;
                OnPropertyChanged("Ssp_cam090_ms45");
            }
        }
        #endregion
        #region Ssp_cam091_ms45: 91.Fecha Colposcopia
        private DateTime _ssp_cam091_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 91.Fecha Colposcopia</para>
        /// <para>NOMBRE: ssp_cam091_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 95</para>
        /// <para>DESCRIPCION:
        /// Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam091_ms45
        {
            get { return _ssp_cam091_ms45; }
            set
            {
                if (_ssp_cam091_ms45 == value) return;
                _ssp_cam091_ms45 = value;
                OnPropertyChanged("Ssp_cam091_ms45");
            }
        }
        #endregion
        #region Ssp_cam092_ms45: 92.Codigo de habilitación IPS donde se t
        private String _ssp_cam092_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 92.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam092_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 96</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Colposcopia Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 999 Si no aplica registrar 0
        /// </para>
        /// </summary>
        public String Ssp_cam092_ms45
        {
            get { return _ssp_cam092_ms45; }
            set
            {
                if (_ssp_cam092_ms45 == value) return;
                _ssp_cam092_ms45 = value;
                OnPropertyChanged("Ssp_cam092_ms45");
            }
        }
        #endregion
        #region Ssp_cam093_ms45: 93.Fecha Biopsia Cervical
        private DateTime _ssp_cam093_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 93.Fecha Biopsia Cervical</para>
        /// <para>NOMBRE: ssp_cam093_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 97</para>
        /// <para>DESCRIPCION:
        /// Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam093_ms45
        {
            get { return _ssp_cam093_ms45; }
            set
            {
                if (_ssp_cam093_ms45 == value) return;
                _ssp_cam093_ms45 = value;
                OnPropertyChanged("Ssp_cam093_ms45");
            }
        }
        #endregion
        #region Ssp_cam094_ms45: 94.Resultado de Biopsia Cervical
        private String _ssp_cam094_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 94.Resultado de Biopsia Cervical</para>
        /// <para>NOMBRE: ssp_cam094_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 98</para>
        /// <para>DESCRIPCION:
        /// Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1-
        /// Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto
        /// Grado: NIC II - NIC III ETC
        /// </para>
        /// </summary>
        public String Ssp_cam094_ms45
        {
            get { return _ssp_cam094_ms45; }
            set
            {
                if (_ssp_cam094_ms45 == value) return;
                _ssp_cam094_ms45 = value;
                OnPropertyChanged("Ssp_cam094_ms45");
            }
        }
        #endregion
        #region Ssp_cam095_ms45: 95.Codigo de habilitación IPS donde se t
        private String _ssp_cam095_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 95.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam095_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 99</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam095_ms45
        {
            get { return _ssp_cam095_ms45; }
            set
            {
                if (_ssp_cam095_ms45 == value) return;
                _ssp_cam095_ms45 = value;
                OnPropertyChanged("Ssp_cam095_ms45");
            }
        }
        #endregion
        #region Ssp_cam096_ms45: 96.Fecha Mamografía
        private DateTime _ssp_cam096_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 96.Fecha Mamografía</para>
        /// <para>NOMBRE: ssp_cam096_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 100</para>
        /// <para>DESCRIPCION:
        /// Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam096_ms45
        {
            get { return _ssp_cam096_ms45; }
            set
            {
                if (_ssp_cam096_ms45 == value) return;
                _ssp_cam096_ms45 = value;
                OnPropertyChanged("Ssp_cam096_ms45");
            }
        }
        #endregion
        #region Ssp_cam097_ms45: 97.Resultado Mamografía
        private String _ssp_cam097_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 97.Resultado Mamografía</para>
        /// <para>NOMBRE: ssp_cam097_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 101</para>
        /// <para>DESCRIPCION:
        /// Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico
        /// o Mamograma previo para evaluación 1- Negativo 2- Hallazgos
        /// Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam097_ms45
        {
            get { return _ssp_cam097_ms45; }
            set
            {
                if (_ssp_cam097_ms45 == value) return;
                _ssp_cam097_ms45 = value;
                OnPropertyChanged("Ssp_cam097_ms45");
            }
        }
        #endregion
        #region Ssp_cam098_ms45: 98.Codigo de habilitación IPS donde se t
        private String _ssp_cam098_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 98.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam098_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 102</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS
        /// (Registro Especial de Prestadores de Servicios de Salud). Si
        /// no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam098_ms45
        {
            get { return _ssp_cam098_ms45; }
            set
            {
                if (_ssp_cam098_ms45 == value) return;
                _ssp_cam098_ms45 = value;
                OnPropertyChanged("Ssp_cam098_ms45");
            }
        }
        #endregion
        #region Ssp_cam099_ms45: 99.Fecha Toma Biopsia Seno por BACAF
        private DateTime _ssp_cam099_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 99.Fecha Toma Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: ssp_cam099_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 103</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam099_ms45
        {
            get { return _ssp_cam099_ms45; }
            set
            {
                if (_ssp_cam099_ms45 == value) return;
                _ssp_cam099_ms45 = value;
                OnPropertyChanged("Ssp_cam099_ms45");
            }
        }
        #endregion
        #region Ssp_cam100_ms45: 100.Fecha Resultado Biopsia Seno por BAC
        private DateTime _ssp_cam100_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 100.Fecha Resultado Biopsia Seno por BAC</para>
        /// <para>NOMBRE: ssp_cam100_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 104</para>
        /// <para>DESCRIPCION:
        /// Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam100_ms45
        {
            get { return _ssp_cam100_ms45; }
            set
            {
                if (_ssp_cam100_ms45 == value) return;
                _ssp_cam100_ms45 = value;
                OnPropertyChanged("Ssp_cam100_ms45");
            }
        }
        #endregion
        #region Ssp_cam101_ms45: 101.Biopsia Seno por BACAF
        private String _ssp_cam101_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 101.Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: ssp_cam101_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 105</para>
        /// <para>DESCRIPCION:
        /// Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada)
        /// 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam101_ms45
        {
            get { return _ssp_cam101_ms45; }
            set
            {
                if (_ssp_cam101_ms45 == value) return;
                _ssp_cam101_ms45 = value;
                OnPropertyChanged("Ssp_cam101_ms45");
            }
        }
        #endregion
        #region Ssp_cam102_ms45: 102.Codigo de habilitación IPS donde se
        private String _ssp_cam102_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 102.Codigo de habilitación IPS donde se</para>
        /// <para>NOMBRE: ssp_cam102_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 106</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public String Ssp_cam102_ms45
        {
            get { return _ssp_cam102_ms45; }
            set
            {
                if (_ssp_cam102_ms45 == value) return;
                _ssp_cam102_ms45 = value;
                OnPropertyChanged("Ssp_cam102_ms45");
            }
        }
        #endregion
        #region Ssp_cam103_ms45: 103.Fecha Toma de Hemoglobina
        private DateTime _ssp_cam103_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 103.Fecha Toma de Hemoglobina</para>
        /// <para>NOMBRE: ssp_cam103_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 107</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam103_ms45
        {
            get { return _ssp_cam103_ms45; }
            set
            {
                if (_ssp_cam103_ms45 == value) return;
                _ssp_cam103_ms45 = value;
                OnPropertyChanged("Ssp_cam103_ms45");
            }
        }
        #endregion
        #region Ssp_cam104_ms45: 104.Hemoglobina
        private float _ssp_cam104_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 104.Hemoglobina</para>
        /// <para>NOMBRE: ssp_cam104_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 108</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Registre el dato reportado por el laboratorio.
        /// Si no aplica registre 9998
        /// </para>
        /// </summary>
        public float Ssp_cam104_ms45
        {
            get { return _ssp_cam104_ms45; }
            set
            {
                if (_ssp_cam104_ms45 == value) return;
                _ssp_cam104_ms45 = value;
                OnPropertyChanged("Ssp_cam104_ms45");
            }
        }
        #endregion
        #region Ssp_cam105_ms45: 105.Fecha de la Toma de Glicemia Basal
        private DateTime _ssp_cam105_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 105.Fecha de la Toma de Glicemia Basal</para>
        /// <para>NOMBRE: ssp_cam105_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 109</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam105_ms45
        {
            get { return _ssp_cam105_ms45; }
            set
            {
                if (_ssp_cam105_ms45 == value) return;
                _ssp_cam105_ms45 = value;
                OnPropertyChanged("Ssp_cam105_ms45");
            }
        }
        #endregion
        #region Ssp_cam106_ms45: 106.Fecha Creatinina
        private DateTime _ssp_cam106_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 106.Fecha Creatinina</para>
        /// <para>NOMBRE: ssp_cam106_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 110</para>
        /// <para>DESCRIPCION:
        /// Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam106_ms45
        {
            get { return _ssp_cam106_ms45; }
            set
            {
                if (_ssp_cam106_ms45 == value) return;
                _ssp_cam106_ms45 = value;
                OnPropertyChanged("Ssp_cam106_ms45");
            }
        }
        #endregion
        #region Ssp_cam107_ms45: 107.Creatinina
        private float _ssp_cam107_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 107.Creatinina</para>
        /// <para>NOMBRE: ssp_cam107_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 111</para>
        /// <para>DESCRIPCION:
        /// Creatinina Registre el dato reportado por el laboratorio. Si
        /// no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public float Ssp_cam107_ms45
        {
            get { return _ssp_cam107_ms45; }
            set
            {
                if (_ssp_cam107_ms45 == value) return;
                _ssp_cam107_ms45 = value;
                OnPropertyChanged("Ssp_cam107_ms45");
            }
        }
        #endregion
        #region Ssp_cam108_ms45: 108.Fecha Hemoglobina Glicosilada
        private DateTime _ssp_cam108_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 108.Fecha Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: ssp_cam108_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 112</para>
        /// <para>DESCRIPCION:
        /// Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam108_ms45
        {
            get { return _ssp_cam108_ms45; }
            set
            {
                if (_ssp_cam108_ms45 == value) return;
                _ssp_cam108_ms45 = value;
                OnPropertyChanged("Ssp_cam108_ms45");
            }
        }
        #endregion
        #region Ssp_cam109_ms45: 109.Hemoglobina Glicosilada
        private float _ssp_cam109_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 109.Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: ssp_cam109_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 113</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Glicosilada Registre el dato reportado por el laboratorio
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public float Ssp_cam109_ms45
        {
            get { return _ssp_cam109_ms45; }
            set
            {
                if (_ssp_cam109_ms45 == value) return;
                _ssp_cam109_ms45 = value;
                OnPropertyChanged("Ssp_cam109_ms45");
            }
        }
        #endregion
        #region Ssp_cam110_ms45: 110.Fecha Toma de Microalbuminuria
        private DateTime _ssp_cam110_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 110.Fecha Toma de Microalbuminuria</para>
        /// <para>NOMBRE: ssp_cam110_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 114</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam110_ms45
        {
            get { return _ssp_cam110_ms45; }
            set
            {
                if (_ssp_cam110_ms45 == value) return;
                _ssp_cam110_ms45 = value;
                OnPropertyChanged("Ssp_cam110_ms45");
            }
        }
        #endregion
        #region Ssp_cam111_ms45: 111.Fecha Toma de HDL
        private DateTime _ssp_cam111_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 111.Fecha Toma de HDL</para>
        /// <para>NOMBRE: ssp_cam111_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 115</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam111_ms45
        {
            get { return _ssp_cam111_ms45; }
            set
            {
                if (_ssp_cam111_ms45 == value) return;
                _ssp_cam111_ms45 = value;
                OnPropertyChanged("Ssp_cam111_ms45");
            }
        }
        #endregion
        #region Ssp_cam112_ms45: 112.Fecha Toma de Baciloscopia de Diagno
        private DateTime _ssp_cam112_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 112.Fecha Toma de Baciloscopia de Diagno</para>
        /// <para>NOMBRE: ssp_cam112_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 116</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam112_ms45
        {
            get { return _ssp_cam112_ms45; }
            set
            {
                if (_ssp_cam112_ms45 == value) return;
                _ssp_cam112_ms45 = value;
                OnPropertyChanged("Ssp_cam112_ms45");
            }
        }
        #endregion
        #region Ssp_cam113_ms45: 113.Baciloscopia de Diagnostico
        private String _ssp_cam113_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 113.Baciloscopia de Diagnostico</para>
        /// <para>NOMBRE: ssp_cam113_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 117</para>
        /// <para>DESCRIPCION:
        /// Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3-
        /// Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam113_ms45
        {
            get { return _ssp_cam113_ms45; }
            set
            {
                if (_ssp_cam113_ms45 == value) return;
                _ssp_cam113_ms45 = value;
                OnPropertyChanged("Ssp_cam113_ms45");
            }
        }
        #endregion
        #region Ssp_cam114_ms45: 114.Tratamiento para Hipotiroidismo Cong
        private String _ssp_cam114_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 114.Tratamiento para Hipotiroidismo Cong</para>
        /// <para>NOMBRE: ssp_cam114_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 118</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud que se lo impide ETC
        /// </para>
        /// </summary>
        public String Ssp_cam114_ms45
        {
            get { return _ssp_cam114_ms45; }
            set
            {
                if (_ssp_cam114_ms45 == value) return;
                _ssp_cam114_ms45 = value;
                OnPropertyChanged("Ssp_cam114_ms45");
            }
        }
        #endregion
        #region Ssp_cam115_ms45: 115.Tratamiento para Sífilis gestacional
        private String _ssp_cam115_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 115.Tratamiento para Sífilis gestacional</para>
        /// <para>NOMBRE: ssp_cam115_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 119</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis gestacional 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam115_ms45
        {
            get { return _ssp_cam115_ms45; }
            set
            {
                if (_ssp_cam115_ms45 == value) return;
                _ssp_cam115_ms45 = value;
                OnPropertyChanged("Ssp_cam115_ms45");
            }
        }
        #endregion
        #region Ssp_cam116_ms45: 116.Tratamiento para Sífilis Congénita
        private String _ssp_cam116_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 116.Tratamiento para Sífilis Congénita</para>
        /// <para>NOMBRE: ssp_cam116_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 120</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis Congenita 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam116_ms45
        {
            get { return _ssp_cam116_ms45; }
            set
            {
                if (_ssp_cam116_ms45 == value) return;
                _ssp_cam116_ms45 = value;
                OnPropertyChanged("Ssp_cam116_ms45");
            }
        }
        #endregion
        #region Ssp_cam117_ms45: 117.Tratamiento para Lepra
        private String _ssp_cam117_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 117.Tratamiento para Lepra</para>
        /// <para>NOMBRE: ssp_cam117_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 121</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Lepra 0- No recibió tratamiento por tener
        /// una tradición que se lo impide 1- No recibió tratamiento por
        /// una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam117_ms45
        {
            get { return _ssp_cam117_ms45; }
            set
            {
                if (_ssp_cam117_ms45 == value) return;
                _ssp_cam117_ms45 = value;
                OnPropertyChanged("Ssp_cam117_ms45");
            }
        }
        #endregion
        #region Ssp_cam118_ms45: 118.Fecha de Terminación Tratamiento par
        private DateTime _ssp_cam118_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 118.Fecha de Terminación Tratamiento par</para>
        /// <para>NOMBRE: ssp_cam118_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 122</para>
        /// <para>DESCRIPCION:
        /// Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 Si no se realiza por
        /// una Condición de Salud registrar 1810-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam118_ms45
        {
            get { return _ssp_cam118_ms45; }
            set
            {
                if (_ssp_cam118_ms45 == value) return;
                _ssp_cam118_ms45 = value;
                OnPropertyChanged("Ssp_cam118_ms45");
            }
        }
        #endregion
        #region Ssp_consec_ms45: Contador
        private int _ssp_consec_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: Contador</para>
        /// <para>NOMBRE: ssp_consec_ms45 (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 123</para>
        /// <para>DESCRIPCION:
        ///Contador para generar secuencial de novedades
        /// </para>
        /// </summary>
        public int Ssp_consec_ms45
        {
            get { return _ssp_consec_ms45; }
            set
            {
                if (_ssp_consec_ms45 == value) return;
                _ssp_consec_ms45 = value;
                OnPropertyChanged("Ssp_consec_ms45");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        private String _sia_nomusu_usua;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
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
        #region Sia_deseps_teps: Nombre EPS
        private String _sia_deseps_teps;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
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
        #region Ssp_desocu_ciuo: Ocupación
        private String _ssp_desocu_ciuo;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: spocupacionciuo</para>
        /// <para>CAMPO: Ocupación</para>
        /// <para>NOMBRE: ssp_desocu_ciuo (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Tipo de identificacion
        /// </para>
        /// </summary>
        public String Ssp_desocu_ciuo
        {
            get { return _ssp_desocu_ciuo; }
            set
            {
                if (_ssp_desocu_ciuo == value) return;
                _ssp_desocu_ciuo = value;
                OnPropertyChanged("Ssp_desocu_ciuo");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloSspRes4505 tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("SSP-MAE-RES4505", "SSP", "Maestro de RES4505");
            if (!flgBuscarSptablmsres4505(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFsptablmsres4505
                    {
                        #region cargar Registro
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                        ssp_cam000_ms45 = tobjModelo.Ssp_cam000_ms45,
                        ssp_cam001_ms45 = tobjModelo.Ssp_cam001_ms45,
                        ssp_cam002_ms45 = tobjModelo.Ssp_cam002_ms45,
                        ssp_cam003_ms45 = tobjModelo.Ssp_cam003_ms45,
                        ssp_cam004_ms45 = tobjModelo.Ssp_cam004_ms45,
                        ssp_cam005_ms45 = tobjModelo.Ssp_cam005_ms45,
                        ssp_cam006_ms45 = tobjModelo.Ssp_cam006_ms45,
                        ssp_cam007_ms45 = tobjModelo.Ssp_cam007_ms45,
                        ssp_cam008_ms45 = tobjModelo.Ssp_cam008_ms45,
                        ssp_cam009_ms45 = tobjModelo.Ssp_cam009_ms45,
                        ssp_cam010_ms45 = tobjModelo.Ssp_cam010_ms45,
                        ssp_cam011_ms45 = tobjModelo.Ssp_cam011_ms45,
                        ssp_codocu_ciuo = tobjModelo.Ssp_codocu_ciuo,
                        ssp_cam013_ms45 = tobjModelo.Ssp_cam013_ms45,
                        ssp_cam014_ms45 = tobjModelo.Ssp_cam014_ms45,
                        ssp_cam015_ms45 = tobjModelo.Ssp_cam015_ms45,
                        ssp_cam016_ms45 = tobjModelo.Ssp_cam016_ms45,
                        ssp_cam017_ms45 = tobjModelo.Ssp_cam017_ms45,
                        ssp_cam018_ms45 = tobjModelo.Ssp_cam018_ms45,
                        ssp_cam019_ms45 = tobjModelo.Ssp_cam019_ms45,
                        ssp_cam020_ms45 = tobjModelo.Ssp_cam020_ms45,
                        ssp_cam021_ms45 = tobjModelo.Ssp_cam021_ms45,
                        ssp_cam022_ms45 = tobjModelo.Ssp_cam022_ms45,
                        ssp_cam023_ms45 = tobjModelo.Ssp_cam023_ms45,
                        ssp_cam024_ms45 = tobjModelo.Ssp_cam024_ms45,
                        ssp_cam025_ms45 = tobjModelo.Ssp_cam025_ms45,
                        ssp_cam026_ms45 = tobjModelo.Ssp_cam026_ms45,
                        ssp_cam027_ms45 = tobjModelo.Ssp_cam027_ms45,
                        ssp_cam028_ms45 = tobjModelo.Ssp_cam028_ms45,
                        ssp_cam029_ms45 = tobjModelo.Ssp_cam029_ms45,
                        ssp_cam030_ms45 = tobjModelo.Ssp_cam030_ms45,
                        ssp_cam031_ms45 = tobjModelo.Ssp_cam031_ms45,
                        ssp_cam032_ms45 = tobjModelo.Ssp_cam032_ms45,
                        ssp_cam033_ms45 = tobjModelo.Ssp_cam033_ms45,
                        ssp_cam034_ms45 = tobjModelo.Ssp_cam034_ms45,
                        ssp_cam035_ms45 = tobjModelo.Ssp_cam035_ms45,
                        ssp_cam036_ms45 = tobjModelo.Ssp_cam036_ms45,
                        ssp_cam037_ms45 = tobjModelo.Ssp_cam037_ms45,
                        ssp_cam038_ms45 = tobjModelo.Ssp_cam038_ms45,
                        ssp_cam039_ms45 = tobjModelo.Ssp_cam039_ms45,
                        ssp_cam040_ms45 = tobjModelo.Ssp_cam040_ms45,
                        ssp_cam041_ms45 = tobjModelo.Ssp_cam041_ms45,
                        ssp_cam042_ms45 = tobjModelo.Ssp_cam042_ms45,
                        ssp_cam043_ms45 = tobjModelo.Ssp_cam043_ms45,
                        ssp_cam044_ms45 = tobjModelo.Ssp_cam044_ms45,
                        ssp_cam045_ms45 = tobjModelo.Ssp_cam045_ms45,
                        ssp_cam046_ms45 = tobjModelo.Ssp_cam046_ms45,
                        ssp_cam047_ms45 = tobjModelo.Ssp_cam047_ms45,
                        ssp_cam048_ms45 = tobjModelo.Ssp_cam048_ms45,
                        ssp_cam049_ms45 = tobjModelo.Ssp_cam049_ms45,
                        ssp_cam050_ms45 = tobjModelo.Ssp_cam050_ms45,
                        ssp_cam051_ms45 = tobjModelo.Ssp_cam051_ms45,
                        ssp_cam052_ms45 = tobjModelo.Ssp_cam052_ms45,
                        ssp_cam053_ms45 = tobjModelo.Ssp_cam053_ms45,
                        ssp_cam054_ms45 = tobjModelo.Ssp_cam054_ms45,
                        ssp_cam055_ms45 = tobjModelo.Ssp_cam055_ms45,
                        ssp_cam056_ms45 = tobjModelo.Ssp_cam056_ms45,
                        ssp_cam057_ms45 = tobjModelo.Ssp_cam057_ms45,
                        ssp_cam058_ms45 = tobjModelo.Ssp_cam058_ms45,
                        ssp_cam059_ms45 = tobjModelo.Ssp_cam059_ms45,
                        ssp_cam060_ms45 = tobjModelo.Ssp_cam060_ms45,
                        ssp_cam061_ms45 = tobjModelo.Ssp_cam061_ms45,
                        ssp_cam062_ms45 = tobjModelo.Ssp_cam062_ms45,
                        ssp_cam063_ms45 = tobjModelo.Ssp_cam063_ms45,
                        ssp_cam064_ms45 = tobjModelo.Ssp_cam064_ms45,
                        ssp_cam065_ms45 = tobjModelo.Ssp_cam065_ms45,
                        ssp_cam066_ms45 = tobjModelo.Ssp_cam066_ms45,
                        ssp_cam067_ms45 = tobjModelo.Ssp_cam067_ms45,
                        ssp_cam068_ms45 = tobjModelo.Ssp_cam068_ms45,
                        ssp_cam069_ms45 = tobjModelo.Ssp_cam069_ms45,
                        ssp_cam070_ms45 = tobjModelo.Ssp_cam070_ms45,
                        ssp_cam071_ms45 = tobjModelo.Ssp_cam071_ms45,
                        ssp_cam072_ms45 = tobjModelo.Ssp_cam072_ms45,
                        ssp_cam073_ms45 = tobjModelo.Ssp_cam073_ms45,
                        ssp_cam074_ms45 = tobjModelo.Ssp_cam074_ms45,
                        ssp_cam075_ms45 = tobjModelo.Ssp_cam075_ms45,
                        ssp_cam076_ms45 = tobjModelo.Ssp_cam076_ms45,
                        ssp_cam077_ms45 = tobjModelo.Ssp_cam077_ms45,
                        ssp_cam078_ms45 = tobjModelo.Ssp_cam078_ms45,
                        ssp_cam079_ms45 = tobjModelo.Ssp_cam079_ms45,
                        ssp_cam080_ms45 = tobjModelo.Ssp_cam080_ms45,
                        ssp_cam081_ms45 = tobjModelo.Ssp_cam081_ms45,
                        ssp_cam082_ms45 = tobjModelo.Ssp_cam082_ms45,
                        ssp_cam083_ms45 = tobjModelo.Ssp_cam083_ms45,
                        ssp_cam084_ms45 = tobjModelo.Ssp_cam084_ms45,
                        ssp_cam085_ms45 = tobjModelo.Ssp_cam085_ms45,
                        ssp_cam086_ms45 = tobjModelo.Ssp_cam086_ms45,
                        ssp_cam087_ms45 = tobjModelo.Ssp_cam087_ms45,
                        ssp_cam088_ms45 = tobjModelo.Ssp_cam088_ms45,
                        ssp_cam089_ms45 = tobjModelo.Ssp_cam089_ms45,
                        ssp_cam090_ms45 = tobjModelo.Ssp_cam090_ms45,
                        ssp_cam091_ms45 = tobjModelo.Ssp_cam091_ms45,
                        ssp_cam092_ms45 = tobjModelo.Ssp_cam092_ms45,
                        ssp_cam093_ms45 = tobjModelo.Ssp_cam093_ms45,
                        ssp_cam094_ms45 = tobjModelo.Ssp_cam094_ms45,
                        ssp_cam095_ms45 = tobjModelo.Ssp_cam095_ms45,
                        ssp_cam096_ms45 = tobjModelo.Ssp_cam096_ms45,
                        ssp_cam097_ms45 = tobjModelo.Ssp_cam097_ms45,
                        ssp_cam098_ms45 = tobjModelo.Ssp_cam098_ms45,
                        ssp_cam099_ms45 = tobjModelo.Ssp_cam099_ms45,
                        ssp_cam100_ms45 = tobjModelo.Ssp_cam100_ms45,
                        ssp_cam101_ms45 = tobjModelo.Ssp_cam101_ms45,
                        ssp_cam102_ms45 = tobjModelo.Ssp_cam102_ms45,
                        ssp_cam103_ms45 = tobjModelo.Ssp_cam103_ms45,
                        ssp_cam104_ms45 = tobjModelo.Ssp_cam104_ms45,
                        ssp_cam105_ms45 = tobjModelo.Ssp_cam105_ms45,
                        ssp_cam106_ms45 = tobjModelo.Ssp_cam106_ms45,
                        ssp_cam107_ms45 = tobjModelo.Ssp_cam107_ms45,
                        ssp_cam108_ms45 = tobjModelo.Ssp_cam108_ms45,
                        ssp_cam109_ms45 = tobjModelo.Ssp_cam109_ms45,
                        ssp_cam110_ms45 = tobjModelo.Ssp_cam110_ms45,
                        ssp_cam111_ms45 = tobjModelo.Ssp_cam111_ms45,
                        ssp_cam112_ms45 = tobjModelo.Ssp_cam112_ms45,
                        ssp_cam113_ms45 = tobjModelo.Ssp_cam113_ms45,
                        ssp_cam114_ms45 = tobjModelo.Ssp_cam114_ms45,
                        ssp_cam115_ms45 = tobjModelo.Ssp_cam115_ms45,
                        ssp_cam116_ms45 = tobjModelo.Ssp_cam116_ms45,
                        ssp_cam117_ms45 = tobjModelo.Ssp_cam117_ms45,
                        ssp_cam118_ms45 = tobjModelo.Ssp_cam118_ms45,
                        ssp_consec_ms45 = tobjModelo.Ssp_consec_ms45,
                        #endregion
                    };
                    lobjRegistro.ssp_cam001_ms45 = lcrCodigoGen;
                    _context.AddToSptablmsres4505(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'SSP-MAE-RES4505': Maestro de RES4505 en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSspRes4505 tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablmsres4505.FirstOrDefault(p => p.ssp_cam001_ms45 == tobjModelo.Ssp_cam001_ms45);
                if (lobjRegistro != null)
                {
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                    lobjRegistro.ssp_cam000_ms45 = tobjModelo.Ssp_cam000_ms45;
                    lobjRegistro.ssp_cam001_ms45 = tobjModelo.Ssp_cam001_ms45;
                    lobjRegistro.ssp_cam002_ms45 = tobjModelo.Ssp_cam002_ms45;
                    lobjRegistro.ssp_cam003_ms45 = tobjModelo.Ssp_cam003_ms45;
                    lobjRegistro.ssp_cam004_ms45 = tobjModelo.Ssp_cam004_ms45;
                    lobjRegistro.ssp_cam005_ms45 = tobjModelo.Ssp_cam005_ms45;
                    lobjRegistro.ssp_cam006_ms45 = tobjModelo.Ssp_cam006_ms45;
                    lobjRegistro.ssp_cam007_ms45 = tobjModelo.Ssp_cam007_ms45;
                    lobjRegistro.ssp_cam008_ms45 = tobjModelo.Ssp_cam008_ms45;
                    lobjRegistro.ssp_cam009_ms45 = (DateTime)tobjModelo.Ssp_cam009_ms45;
                    lobjRegistro.ssp_cam010_ms45 = tobjModelo.Ssp_cam010_ms45;
                    lobjRegistro.ssp_cam011_ms45 = tobjModelo.Ssp_cam011_ms45;
                    lobjRegistro.ssp_codocu_ciuo = tobjModelo.Ssp_codocu_ciuo;
                    lobjRegistro.ssp_cam013_ms45 = tobjModelo.Ssp_cam013_ms45;
                    lobjRegistro.ssp_cam014_ms45 = tobjModelo.Ssp_cam014_ms45;
                    lobjRegistro.ssp_cam015_ms45 = tobjModelo.Ssp_cam015_ms45;
                    lobjRegistro.ssp_cam016_ms45 = tobjModelo.Ssp_cam016_ms45;
                    lobjRegistro.ssp_cam017_ms45 = tobjModelo.Ssp_cam017_ms45;
                    lobjRegistro.ssp_cam018_ms45 = tobjModelo.Ssp_cam018_ms45;
                    lobjRegistro.ssp_cam019_ms45 = tobjModelo.Ssp_cam019_ms45;
                    lobjRegistro.ssp_cam020_ms45 = tobjModelo.Ssp_cam020_ms45;
                    lobjRegistro.ssp_cam021_ms45 = tobjModelo.Ssp_cam021_ms45;
                    lobjRegistro.ssp_cam022_ms45 = tobjModelo.Ssp_cam022_ms45;
                    lobjRegistro.ssp_cam023_ms45 = tobjModelo.Ssp_cam023_ms45;
                    lobjRegistro.ssp_cam024_ms45 = tobjModelo.Ssp_cam024_ms45;
                    lobjRegistro.ssp_cam025_ms45 = tobjModelo.Ssp_cam025_ms45;
                    lobjRegistro.ssp_cam026_ms45 = tobjModelo.Ssp_cam026_ms45;
                    lobjRegistro.ssp_cam027_ms45 = tobjModelo.Ssp_cam027_ms45;
                    lobjRegistro.ssp_cam028_ms45 = tobjModelo.Ssp_cam028_ms45;
                    lobjRegistro.ssp_cam029_ms45 = (DateTime)tobjModelo.Ssp_cam029_ms45;
                    lobjRegistro.ssp_cam030_ms45 = (int)tobjModelo.Ssp_cam030_ms45;
                    lobjRegistro.ssp_cam031_ms45 = (DateTime)tobjModelo.Ssp_cam031_ms45;
                    lobjRegistro.ssp_cam032_ms45 = (int)tobjModelo.Ssp_cam032_ms45;
                    lobjRegistro.ssp_cam033_ms45 = (DateTime)tobjModelo.Ssp_cam033_ms45;
                    lobjRegistro.ssp_cam034_ms45 = (int)tobjModelo.Ssp_cam034_ms45;
                    lobjRegistro.ssp_cam035_ms45 = tobjModelo.Ssp_cam035_ms45;
                    lobjRegistro.ssp_cam036_ms45 = tobjModelo.Ssp_cam036_ms45;
                    lobjRegistro.ssp_cam037_ms45 = tobjModelo.Ssp_cam037_ms45;
                    lobjRegistro.ssp_cam038_ms45 = tobjModelo.Ssp_cam038_ms45;
                    lobjRegistro.ssp_cam039_ms45 = tobjModelo.Ssp_cam039_ms45;
                    lobjRegistro.ssp_cam040_ms45 = tobjModelo.Ssp_cam040_ms45;
                    lobjRegistro.ssp_cam041_ms45 = tobjModelo.Ssp_cam041_ms45;
                    lobjRegistro.ssp_cam042_ms45 = tobjModelo.Ssp_cam042_ms45;
                    lobjRegistro.ssp_cam043_ms45 = tobjModelo.Ssp_cam043_ms45;
                    lobjRegistro.ssp_cam044_ms45 = tobjModelo.Ssp_cam044_ms45;
                    lobjRegistro.ssp_cam045_ms45 = tobjModelo.Ssp_cam045_ms45;
                    lobjRegistro.ssp_cam046_ms45 = tobjModelo.Ssp_cam046_ms45;
                    lobjRegistro.ssp_cam047_ms45 = tobjModelo.Ssp_cam047_ms45;
                    lobjRegistro.ssp_cam048_ms45 = tobjModelo.Ssp_cam048_ms45;
                    lobjRegistro.ssp_cam049_ms45 = (DateTime)tobjModelo.Ssp_cam049_ms45;
                    lobjRegistro.ssp_cam050_ms45 = (DateTime)tobjModelo.Ssp_cam050_ms45;
                    lobjRegistro.ssp_cam051_ms45 = (DateTime)tobjModelo.Ssp_cam051_ms45;
                    lobjRegistro.ssp_cam052_ms45 = (DateTime)tobjModelo.Ssp_cam052_ms45;
                    lobjRegistro.ssp_cam053_ms45 = (DateTime)tobjModelo.Ssp_cam053_ms45;
                    lobjRegistro.ssp_cam054_ms45 = tobjModelo.Ssp_cam054_ms45;
                    lobjRegistro.ssp_cam055_ms45 = (DateTime)tobjModelo.Ssp_cam055_ms45;
                    lobjRegistro.ssp_cam056_ms45 = (DateTime)tobjModelo.Ssp_cam056_ms45;
                    lobjRegistro.ssp_cam057_ms45 = (int)tobjModelo.Ssp_cam057_ms45;
                    lobjRegistro.ssp_cam058_ms45 = (DateTime)tobjModelo.Ssp_cam058_ms45;
                    lobjRegistro.ssp_cam059_ms45 = tobjModelo.Ssp_cam059_ms45;
                    lobjRegistro.ssp_cam060_ms45 = tobjModelo.Ssp_cam060_ms45;
                    lobjRegistro.ssp_cam061_ms45 = tobjModelo.Ssp_cam061_ms45;
                    lobjRegistro.ssp_cam062_ms45 = (DateTime)tobjModelo.Ssp_cam062_ms45;
                    lobjRegistro.ssp_cam063_ms45 = (DateTime)tobjModelo.Ssp_cam063_ms45;
                    lobjRegistro.ssp_cam064_ms45 = (DateTime)tobjModelo.Ssp_cam064_ms45;
                    lobjRegistro.ssp_cam065_ms45 = (DateTime)tobjModelo.Ssp_cam065_ms45;
                    lobjRegistro.ssp_cam066_ms45 = (DateTime)tobjModelo.Ssp_cam066_ms45;
                    lobjRegistro.ssp_cam067_ms45 = (DateTime)tobjModelo.Ssp_cam067_ms45;
                    lobjRegistro.ssp_cam068_ms45 = (DateTime)tobjModelo.Ssp_cam068_ms45;
                    lobjRegistro.ssp_cam069_ms45 = (DateTime)tobjModelo.Ssp_cam069_ms45;
                    lobjRegistro.ssp_cam070_ms45 = tobjModelo.Ssp_cam070_ms45;
                    lobjRegistro.ssp_cam071_ms45 = tobjModelo.Ssp_cam071_ms45;
                    lobjRegistro.ssp_cam072_ms45 = (DateTime)tobjModelo.Ssp_cam072_ms45;
                    lobjRegistro.ssp_cam073_ms45 = (DateTime)tobjModelo.Ssp_cam073_ms45;
                    lobjRegistro.ssp_cam074_ms45 = (int)tobjModelo.Ssp_cam074_ms45;
                    lobjRegistro.ssp_cam075_ms45 = (DateTime)tobjModelo.Ssp_cam075_ms45;
                    lobjRegistro.ssp_cam076_ms45 = (DateTime)tobjModelo.Ssp_cam076_ms45;
                    lobjRegistro.ssp_cam077_ms45 = tobjModelo.Ssp_cam077_ms45;
                    lobjRegistro.ssp_cam078_ms45 = (DateTime)tobjModelo.Ssp_cam078_ms45;
                    lobjRegistro.ssp_cam079_ms45 = tobjModelo.Ssp_cam079_ms45;
                    lobjRegistro.ssp_cam080_ms45 = (DateTime)tobjModelo.Ssp_cam080_ms45;
                    lobjRegistro.ssp_cam081_ms45 = tobjModelo.Ssp_cam081_ms45;
                    lobjRegistro.ssp_cam082_ms45 = (DateTime)tobjModelo.Ssp_cam082_ms45;
                    lobjRegistro.ssp_cam083_ms45 = tobjModelo.Ssp_cam083_ms45;
                    lobjRegistro.ssp_cam084_ms45 = (DateTime)tobjModelo.Ssp_cam084_ms45;
                    lobjRegistro.ssp_cam085_ms45 = tobjModelo.Ssp_cam085_ms45;
                    lobjRegistro.ssp_cam086_ms45 = tobjModelo.Ssp_cam086_ms45;
                    lobjRegistro.ssp_cam087_ms45 = (DateTime)tobjModelo.Ssp_cam087_ms45;
                    lobjRegistro.ssp_cam088_ms45 = tobjModelo.Ssp_cam088_ms45;
                    lobjRegistro.ssp_cam089_ms45 = tobjModelo.Ssp_cam089_ms45;
                    lobjRegistro.ssp_cam090_ms45 = tobjModelo.Ssp_cam090_ms45;
                    lobjRegistro.ssp_cam091_ms45 = (DateTime)tobjModelo.Ssp_cam091_ms45;
                    lobjRegistro.ssp_cam092_ms45 = tobjModelo.Ssp_cam092_ms45;
                    lobjRegistro.ssp_cam093_ms45 = (DateTime)tobjModelo.Ssp_cam093_ms45;
                    lobjRegistro.ssp_cam094_ms45 = tobjModelo.Ssp_cam094_ms45;
                    lobjRegistro.ssp_cam095_ms45 = tobjModelo.Ssp_cam095_ms45;
                    lobjRegistro.ssp_cam096_ms45 = (DateTime)tobjModelo.Ssp_cam096_ms45;
                    lobjRegistro.ssp_cam097_ms45 = tobjModelo.Ssp_cam097_ms45;
                    lobjRegistro.ssp_cam098_ms45 = tobjModelo.Ssp_cam098_ms45;
                    lobjRegistro.ssp_cam099_ms45 = (DateTime)tobjModelo.Ssp_cam099_ms45;
                    lobjRegistro.ssp_cam100_ms45 = (DateTime)tobjModelo.Ssp_cam100_ms45;
                    lobjRegistro.ssp_cam101_ms45 = tobjModelo.Ssp_cam101_ms45;
                    lobjRegistro.ssp_cam102_ms45 = tobjModelo.Ssp_cam102_ms45;
                    lobjRegistro.ssp_cam103_ms45 = (DateTime)tobjModelo.Ssp_cam103_ms45;
                    lobjRegistro.ssp_cam104_ms45 = (int)tobjModelo.Ssp_cam104_ms45;
                    lobjRegistro.ssp_cam105_ms45 = (DateTime)tobjModelo.Ssp_cam105_ms45;
                    lobjRegistro.ssp_cam106_ms45 = (DateTime)tobjModelo.Ssp_cam106_ms45;
                    lobjRegistro.ssp_cam107_ms45 = (int)tobjModelo.Ssp_cam107_ms45;
                    lobjRegistro.ssp_cam108_ms45 = (DateTime)tobjModelo.Ssp_cam108_ms45;
                    lobjRegistro.ssp_cam109_ms45 = (int)tobjModelo.Ssp_cam109_ms45;
                    lobjRegistro.ssp_cam110_ms45 = (DateTime)tobjModelo.Ssp_cam110_ms45;
                    lobjRegistro.ssp_cam111_ms45 = (DateTime)tobjModelo.Ssp_cam111_ms45;
                    lobjRegistro.ssp_cam112_ms45 = (DateTime)tobjModelo.Ssp_cam112_ms45;
                    lobjRegistro.ssp_cam113_ms45 = tobjModelo.Ssp_cam113_ms45;
                    lobjRegistro.ssp_cam114_ms45 = tobjModelo.Ssp_cam114_ms45;
                    lobjRegistro.ssp_cam115_ms45 = tobjModelo.Ssp_cam115_ms45;
                    lobjRegistro.ssp_cam116_ms45 = tobjModelo.Ssp_cam116_ms45;
                    lobjRegistro.ssp_cam117_ms45 = tobjModelo.Ssp_cam117_ms45;
                    lobjRegistro.ssp_cam118_ms45 = (DateTime)tobjModelo.Ssp_cam118_ms45;
                    lobjRegistro.ssp_consec_ms45 = (int)tobjModelo.Ssp_consec_ms45;
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
                var lobjRegistro = _context.Sptablmsres4505.FirstOrDefault(p => p.ssp_cam001_ms45 == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SPTABLMSRES4505: Logica
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TITULO: Tabla maestra de digitacion RES4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla maestra de digitacion RES4505
        /// </para>
        /// </summary>
        public static bool flgBuscarSptablmsres4505(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablmsres4505.FirstOrDefault(p => p.ssp_cam001_ms45 == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSspRes4505> flsListaSptablmsres4505(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from sptablmsres4505 in _context.Sptablmsres4505
                                      join siausuarioatend in _context.Siausuarioatend on sptablmsres4505.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatablaeps in _context.Siatablaeps on sptablmsres4505.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join spocupacionciuo in _context.Spocupacionciuo on sptablmsres4505.ssp_codocu_ciuo equals spocupacionciuo.ssp_codocu_ciuo into tmspocupacionciuo
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from ciuo in tmspocupacionciuo.DefaultIfEmpty()
                                      select new ModeloSspRes4505
                                      {
                                          Sia_idesec_usua = sptablmsres4505.sia_idesec_usua,
                                          Sia_nroide_usua = sptablmsres4505.sia_nroide_usua,
                                          Sia_codeps_teps = sptablmsres4505.sia_codeps_teps,
                                          Ssp_cam000_ms45 = sptablmsres4505.ssp_cam000_ms45,
                                          Ssp_cam001_ms45 = sptablmsres4505.ssp_cam001_ms45,
                                          Ssp_cam002_ms45 = sptablmsres4505.ssp_cam002_ms45,
                                          Ssp_cam003_ms45 = sptablmsres4505.ssp_cam003_ms45,
                                          Ssp_cam004_ms45 = sptablmsres4505.ssp_cam004_ms45,
                                          Ssp_cam005_ms45 = sptablmsres4505.ssp_cam005_ms45,
                                          Ssp_cam006_ms45 = sptablmsres4505.ssp_cam006_ms45,
                                          Ssp_cam007_ms45 = sptablmsres4505.ssp_cam007_ms45,
                                          Ssp_cam008_ms45 = sptablmsres4505.ssp_cam008_ms45,
                                          Ssp_cam009_ms45 = (DateTime)sptablmsres4505.ssp_cam009_ms45,
                                          Ssp_cam010_ms45 = sptablmsres4505.ssp_cam010_ms45,
                                          Ssp_cam011_ms45 = sptablmsres4505.ssp_cam011_ms45,
                                          Ssp_codocu_ciuo = sptablmsres4505.ssp_codocu_ciuo,
                                          Ssp_cam013_ms45 = sptablmsres4505.ssp_cam013_ms45,
                                          Ssp_cam014_ms45 = sptablmsres4505.ssp_cam014_ms45,
                                          Ssp_cam015_ms45 = sptablmsres4505.ssp_cam015_ms45,
                                          Ssp_cam016_ms45 = sptablmsres4505.ssp_cam016_ms45,
                                          Ssp_cam017_ms45 = sptablmsres4505.ssp_cam017_ms45,
                                          Ssp_cam018_ms45 = sptablmsres4505.ssp_cam018_ms45,
                                          Ssp_cam019_ms45 = sptablmsres4505.ssp_cam019_ms45,
                                          Ssp_cam020_ms45 = sptablmsres4505.ssp_cam020_ms45,
                                          Ssp_cam021_ms45 = sptablmsres4505.ssp_cam021_ms45,
                                          Ssp_cam022_ms45 = sptablmsres4505.ssp_cam022_ms45,
                                          Ssp_cam023_ms45 = sptablmsres4505.ssp_cam023_ms45,
                                          Ssp_cam024_ms45 = sptablmsres4505.ssp_cam024_ms45,
                                          Ssp_cam025_ms45 = sptablmsres4505.ssp_cam025_ms45,
                                          Ssp_cam026_ms45 = sptablmsres4505.ssp_cam026_ms45,
                                          Ssp_cam027_ms45 = sptablmsres4505.ssp_cam027_ms45,
                                          Ssp_cam028_ms45 = sptablmsres4505.ssp_cam028_ms45,
                                          Ssp_cam029_ms45 = (DateTime)sptablmsres4505.ssp_cam029_ms45,
                                          Ssp_cam030_ms45 = (int)sptablmsres4505.ssp_cam030_ms45,
                                          Ssp_cam031_ms45 = (DateTime)sptablmsres4505.ssp_cam031_ms45,
                                          Ssp_cam032_ms45 = (int)sptablmsres4505.ssp_cam032_ms45,
                                          Ssp_cam033_ms45 = (DateTime)sptablmsres4505.ssp_cam033_ms45,
                                          Ssp_cam034_ms45 = (int)sptablmsres4505.ssp_cam034_ms45,
                                          Ssp_cam035_ms45 = sptablmsres4505.ssp_cam035_ms45,
                                          Ssp_cam036_ms45 = sptablmsres4505.ssp_cam036_ms45,
                                          Ssp_cam037_ms45 = sptablmsres4505.ssp_cam037_ms45,
                                          Ssp_cam038_ms45 = sptablmsres4505.ssp_cam038_ms45,
                                          Ssp_cam039_ms45 = sptablmsres4505.ssp_cam039_ms45,
                                          Ssp_cam040_ms45 = sptablmsres4505.ssp_cam040_ms45,
                                          Ssp_cam041_ms45 = sptablmsres4505.ssp_cam041_ms45,
                                          Ssp_cam042_ms45 = sptablmsres4505.ssp_cam042_ms45,
                                          Ssp_cam043_ms45 = sptablmsres4505.ssp_cam043_ms45,
                                          Ssp_cam044_ms45 = sptablmsres4505.ssp_cam044_ms45,
                                          Ssp_cam045_ms45 = sptablmsres4505.ssp_cam045_ms45,
                                          Ssp_cam046_ms45 = sptablmsres4505.ssp_cam046_ms45,
                                          Ssp_cam047_ms45 = sptablmsres4505.ssp_cam047_ms45,
                                          Ssp_cam048_ms45 = sptablmsres4505.ssp_cam048_ms45,
                                          Ssp_cam049_ms45 = (DateTime)sptablmsres4505.ssp_cam049_ms45,
                                          Ssp_cam050_ms45 = (DateTime)sptablmsres4505.ssp_cam050_ms45,
                                          Ssp_cam051_ms45 = (DateTime)sptablmsres4505.ssp_cam051_ms45,
                                          Ssp_cam052_ms45 = (DateTime)sptablmsres4505.ssp_cam052_ms45,
                                          Ssp_cam053_ms45 = (DateTime)sptablmsres4505.ssp_cam053_ms45,
                                          Ssp_cam054_ms45 = sptablmsres4505.ssp_cam054_ms45,
                                          Ssp_cam055_ms45 = (DateTime)sptablmsres4505.ssp_cam055_ms45,
                                          Ssp_cam056_ms45 = (DateTime)sptablmsres4505.ssp_cam056_ms45,
                                          Ssp_cam057_ms45 = (int)sptablmsres4505.ssp_cam057_ms45,
                                          Ssp_cam058_ms45 = (DateTime)sptablmsres4505.ssp_cam058_ms45,
                                          Ssp_cam059_ms45 = sptablmsres4505.ssp_cam059_ms45,
                                          Ssp_cam060_ms45 = sptablmsres4505.ssp_cam060_ms45,
                                          Ssp_cam061_ms45 = sptablmsres4505.ssp_cam061_ms45,
                                          Ssp_cam062_ms45 = (DateTime)sptablmsres4505.ssp_cam062_ms45,
                                          Ssp_cam063_ms45 = (DateTime)sptablmsres4505.ssp_cam063_ms45,
                                          Ssp_cam064_ms45 = (DateTime)sptablmsres4505.ssp_cam064_ms45,
                                          Ssp_cam065_ms45 = (DateTime)sptablmsres4505.ssp_cam065_ms45,
                                          Ssp_cam066_ms45 = (DateTime)sptablmsres4505.ssp_cam066_ms45,
                                          Ssp_cam067_ms45 = (DateTime)sptablmsres4505.ssp_cam067_ms45,
                                          Ssp_cam068_ms45 = (DateTime)sptablmsres4505.ssp_cam068_ms45,
                                          Ssp_cam069_ms45 = (DateTime)sptablmsres4505.ssp_cam069_ms45,
                                          Ssp_cam070_ms45 = sptablmsres4505.ssp_cam070_ms45,
                                          Ssp_cam071_ms45 = sptablmsres4505.ssp_cam071_ms45,
                                          Ssp_cam072_ms45 = (DateTime)sptablmsres4505.ssp_cam072_ms45,
                                          Ssp_cam073_ms45 = (DateTime)sptablmsres4505.ssp_cam073_ms45,
                                          Ssp_cam074_ms45 = (int)sptablmsres4505.ssp_cam074_ms45,
                                          Ssp_cam075_ms45 = (DateTime)sptablmsres4505.ssp_cam075_ms45,
                                          Ssp_cam076_ms45 = (DateTime)sptablmsres4505.ssp_cam076_ms45,
                                          Ssp_cam077_ms45 = sptablmsres4505.ssp_cam077_ms45,
                                          Ssp_cam078_ms45 = (DateTime)sptablmsres4505.ssp_cam078_ms45,
                                          Ssp_cam079_ms45 = sptablmsres4505.ssp_cam079_ms45,
                                          Ssp_cam080_ms45 = (DateTime)sptablmsres4505.ssp_cam080_ms45,
                                          Ssp_cam081_ms45 = sptablmsres4505.ssp_cam081_ms45,
                                          Ssp_cam082_ms45 = (DateTime)sptablmsres4505.ssp_cam082_ms45,
                                          Ssp_cam083_ms45 = sptablmsres4505.ssp_cam083_ms45,
                                          Ssp_cam084_ms45 = (DateTime)sptablmsres4505.ssp_cam084_ms45,
                                          Ssp_cam085_ms45 = sptablmsres4505.ssp_cam085_ms45,
                                          Ssp_cam086_ms45 = sptablmsres4505.ssp_cam086_ms45,
                                          Ssp_cam087_ms45 = (DateTime)sptablmsres4505.ssp_cam087_ms45,
                                          Ssp_cam088_ms45 = sptablmsres4505.ssp_cam088_ms45,
                                          Ssp_cam089_ms45 = sptablmsres4505.ssp_cam089_ms45,
                                          Ssp_cam090_ms45 = sptablmsres4505.ssp_cam090_ms45,
                                          Ssp_cam091_ms45 = (DateTime)sptablmsres4505.ssp_cam091_ms45,
                                          Ssp_cam092_ms45 = sptablmsres4505.ssp_cam092_ms45,
                                          Ssp_cam093_ms45 = (DateTime)sptablmsres4505.ssp_cam093_ms45,
                                          Ssp_cam094_ms45 = sptablmsres4505.ssp_cam094_ms45,
                                          Ssp_cam095_ms45 = sptablmsres4505.ssp_cam095_ms45,
                                          Ssp_cam096_ms45 = (DateTime)sptablmsres4505.ssp_cam096_ms45,
                                          Ssp_cam097_ms45 = sptablmsres4505.ssp_cam097_ms45,
                                          Ssp_cam098_ms45 = sptablmsres4505.ssp_cam098_ms45,
                                          Ssp_cam099_ms45 = (DateTime)sptablmsres4505.ssp_cam099_ms45,
                                          Ssp_cam100_ms45 = (DateTime)sptablmsres4505.ssp_cam100_ms45,
                                          Ssp_cam101_ms45 = sptablmsres4505.ssp_cam101_ms45,
                                          Ssp_cam102_ms45 = sptablmsres4505.ssp_cam102_ms45,
                                          Ssp_cam103_ms45 = (DateTime)sptablmsres4505.ssp_cam103_ms45,
                                          Ssp_cam104_ms45 = (float)sptablmsres4505.ssp_cam104_ms45,
                                          Ssp_cam105_ms45 = (DateTime)sptablmsres4505.ssp_cam105_ms45,
                                          Ssp_cam106_ms45 = (DateTime)sptablmsres4505.ssp_cam106_ms45,
                                          Ssp_cam107_ms45 = (float)sptablmsres4505.ssp_cam107_ms45,
                                          Ssp_cam108_ms45 = (DateTime)sptablmsres4505.ssp_cam108_ms45,
                                          Ssp_cam109_ms45 = (float)sptablmsres4505.ssp_cam109_ms45,
                                          Ssp_cam110_ms45 = (DateTime)sptablmsres4505.ssp_cam110_ms45,
                                          Ssp_cam111_ms45 = (DateTime)sptablmsres4505.ssp_cam111_ms45,
                                          Ssp_cam112_ms45 = (DateTime)sptablmsres4505.ssp_cam112_ms45,
                                          Ssp_cam113_ms45 = sptablmsres4505.ssp_cam113_ms45,
                                          Ssp_cam114_ms45 = sptablmsres4505.ssp_cam114_ms45,
                                          Ssp_cam115_ms45 = sptablmsres4505.ssp_cam115_ms45,
                                          Ssp_cam116_ms45 = sptablmsres4505.ssp_cam116_ms45,
                                          Ssp_cam117_ms45 = sptablmsres4505.ssp_cam117_ms45,
                                          Ssp_cam118_ms45 = (DateTime)sptablmsres4505.ssp_cam118_ms45,
                                          Ssp_consec_ms45 = (int)sptablmsres4505.ssp_consec_ms45,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Ssp_desocu_ciuo = ciuo.ssp_desocu_ciuo,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sptablmsres4505 in _context.Sptablmsres4505
                                      join siausuarioatend in _context.Siausuarioatend on sptablmsres4505.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatablaeps in _context.Siatablaeps on sptablmsres4505.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join spocupacionciuo in _context.Spocupacionciuo on sptablmsres4505.ssp_codocu_ciuo equals spocupacionciuo.ssp_codocu_ciuo into tmspocupacionciuo
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from ciuo in tmspocupacionciuo.DefaultIfEmpty()
                                      where sptablmsres4505.sia_idesec_usua == tcrBuscar
                                      //where sptablmsres4505.ssp_cam001_ms45 == tcrBuscar
                                      select new ModeloSspRes4505
                                      {
                                          Sia_idesec_usua = sptablmsres4505.sia_idesec_usua,
                                          Sia_nroide_usua = sptablmsres4505.sia_nroide_usua,
                                          Sia_codeps_teps = sptablmsres4505.sia_codeps_teps,
                                          Ssp_cam000_ms45 = sptablmsres4505.ssp_cam000_ms45,
                                          Ssp_cam001_ms45 = sptablmsres4505.ssp_cam001_ms45,
                                          Ssp_cam002_ms45 = sptablmsres4505.ssp_cam002_ms45,
                                          Ssp_cam003_ms45 = sptablmsres4505.ssp_cam003_ms45,
                                          Ssp_cam004_ms45 = sptablmsres4505.ssp_cam004_ms45,
                                          Ssp_cam005_ms45 = sptablmsres4505.ssp_cam005_ms45,
                                          Ssp_cam006_ms45 = sptablmsres4505.ssp_cam006_ms45,
                                          Ssp_cam007_ms45 = sptablmsres4505.ssp_cam007_ms45,
                                          Ssp_cam008_ms45 = sptablmsres4505.ssp_cam008_ms45,
                                          Ssp_cam009_ms45 = (DateTime)sptablmsres4505.ssp_cam009_ms45,
                                          Ssp_cam010_ms45 = sptablmsres4505.ssp_cam010_ms45,
                                          Ssp_cam011_ms45 = sptablmsres4505.ssp_cam011_ms45,
                                          Ssp_codocu_ciuo = sptablmsres4505.ssp_codocu_ciuo,
                                          Ssp_cam013_ms45 = sptablmsres4505.ssp_cam013_ms45,
                                          Ssp_cam014_ms45 = sptablmsres4505.ssp_cam014_ms45,
                                          Ssp_cam015_ms45 = sptablmsres4505.ssp_cam015_ms45,
                                          Ssp_cam016_ms45 = sptablmsres4505.ssp_cam016_ms45,
                                          Ssp_cam017_ms45 = sptablmsres4505.ssp_cam017_ms45,
                                          Ssp_cam018_ms45 = sptablmsres4505.ssp_cam018_ms45,
                                          Ssp_cam019_ms45 = sptablmsres4505.ssp_cam019_ms45,
                                          Ssp_cam020_ms45 = sptablmsres4505.ssp_cam020_ms45,
                                          Ssp_cam021_ms45 = sptablmsres4505.ssp_cam021_ms45,
                                          Ssp_cam022_ms45 = sptablmsres4505.ssp_cam022_ms45,
                                          Ssp_cam023_ms45 = sptablmsres4505.ssp_cam023_ms45,
                                          Ssp_cam024_ms45 = sptablmsres4505.ssp_cam024_ms45,
                                          Ssp_cam025_ms45 = sptablmsres4505.ssp_cam025_ms45,
                                          Ssp_cam026_ms45 = sptablmsres4505.ssp_cam026_ms45,
                                          Ssp_cam027_ms45 = sptablmsres4505.ssp_cam027_ms45,
                                          Ssp_cam028_ms45 = sptablmsres4505.ssp_cam028_ms45,
                                          Ssp_cam029_ms45 = (DateTime)sptablmsres4505.ssp_cam029_ms45,
                                          Ssp_cam030_ms45 = (int)sptablmsres4505.ssp_cam030_ms45,
                                          Ssp_cam031_ms45 = (DateTime)sptablmsres4505.ssp_cam031_ms45,
                                          Ssp_cam032_ms45 = (int)sptablmsres4505.ssp_cam032_ms45,
                                          Ssp_cam033_ms45 = (DateTime)sptablmsres4505.ssp_cam033_ms45,
                                          Ssp_cam034_ms45 = (int)sptablmsres4505.ssp_cam034_ms45,
                                          Ssp_cam035_ms45 = sptablmsres4505.ssp_cam035_ms45,
                                          Ssp_cam036_ms45 = sptablmsres4505.ssp_cam036_ms45,
                                          Ssp_cam037_ms45 = sptablmsres4505.ssp_cam037_ms45,
                                          Ssp_cam038_ms45 = sptablmsres4505.ssp_cam038_ms45,
                                          Ssp_cam039_ms45 = sptablmsres4505.ssp_cam039_ms45,
                                          Ssp_cam040_ms45 = sptablmsres4505.ssp_cam040_ms45,
                                          Ssp_cam041_ms45 = sptablmsres4505.ssp_cam041_ms45,
                                          Ssp_cam042_ms45 = sptablmsres4505.ssp_cam042_ms45,
                                          Ssp_cam043_ms45 = sptablmsres4505.ssp_cam043_ms45,
                                          Ssp_cam044_ms45 = sptablmsres4505.ssp_cam044_ms45,
                                          Ssp_cam045_ms45 = sptablmsres4505.ssp_cam045_ms45,
                                          Ssp_cam046_ms45 = sptablmsres4505.ssp_cam046_ms45,
                                          Ssp_cam047_ms45 = sptablmsres4505.ssp_cam047_ms45,
                                          Ssp_cam048_ms45 = sptablmsres4505.ssp_cam048_ms45,
                                          Ssp_cam049_ms45 = (DateTime)sptablmsres4505.ssp_cam049_ms45,
                                          Ssp_cam050_ms45 = (DateTime)sptablmsres4505.ssp_cam050_ms45,
                                          Ssp_cam051_ms45 = (DateTime)sptablmsres4505.ssp_cam051_ms45,
                                          Ssp_cam052_ms45 = (DateTime)sptablmsres4505.ssp_cam052_ms45,
                                          Ssp_cam053_ms45 = (DateTime)sptablmsres4505.ssp_cam053_ms45,
                                          Ssp_cam054_ms45 = sptablmsres4505.ssp_cam054_ms45,
                                          Ssp_cam055_ms45 = (DateTime)sptablmsres4505.ssp_cam055_ms45,
                                          Ssp_cam056_ms45 = (DateTime)sptablmsres4505.ssp_cam056_ms45,
                                          Ssp_cam057_ms45 = (int)sptablmsres4505.ssp_cam057_ms45,
                                          Ssp_cam058_ms45 = (DateTime)sptablmsres4505.ssp_cam058_ms45,
                                          Ssp_cam059_ms45 = sptablmsres4505.ssp_cam059_ms45,
                                          Ssp_cam060_ms45 = sptablmsres4505.ssp_cam060_ms45,
                                          Ssp_cam061_ms45 = sptablmsres4505.ssp_cam061_ms45,
                                          Ssp_cam062_ms45 = (DateTime)sptablmsres4505.ssp_cam062_ms45,
                                          Ssp_cam063_ms45 = (DateTime)sptablmsres4505.ssp_cam063_ms45,
                                          Ssp_cam064_ms45 = (DateTime)sptablmsres4505.ssp_cam064_ms45,
                                          Ssp_cam065_ms45 = (DateTime)sptablmsres4505.ssp_cam065_ms45,
                                          Ssp_cam066_ms45 = (DateTime)sptablmsres4505.ssp_cam066_ms45,
                                          Ssp_cam067_ms45 = (DateTime)sptablmsres4505.ssp_cam067_ms45,
                                          Ssp_cam068_ms45 = (DateTime)sptablmsres4505.ssp_cam068_ms45,
                                          Ssp_cam069_ms45 = (DateTime)sptablmsres4505.ssp_cam069_ms45,
                                          Ssp_cam070_ms45 = sptablmsres4505.ssp_cam070_ms45,
                                          Ssp_cam071_ms45 = sptablmsres4505.ssp_cam071_ms45,
                                          Ssp_cam072_ms45 = (DateTime)sptablmsres4505.ssp_cam072_ms45,
                                          Ssp_cam073_ms45 = (DateTime)sptablmsres4505.ssp_cam073_ms45,
                                          Ssp_cam074_ms45 = (int)sptablmsres4505.ssp_cam074_ms45,
                                          Ssp_cam075_ms45 = (DateTime)sptablmsres4505.ssp_cam075_ms45,
                                          Ssp_cam076_ms45 = (DateTime)sptablmsres4505.ssp_cam076_ms45,
                                          Ssp_cam077_ms45 = sptablmsres4505.ssp_cam077_ms45,
                                          Ssp_cam078_ms45 = (DateTime)sptablmsres4505.ssp_cam078_ms45,
                                          Ssp_cam079_ms45 = sptablmsres4505.ssp_cam079_ms45,
                                          Ssp_cam080_ms45 = (DateTime)sptablmsres4505.ssp_cam080_ms45,
                                          Ssp_cam081_ms45 = sptablmsres4505.ssp_cam081_ms45,
                                          Ssp_cam082_ms45 = (DateTime)sptablmsres4505.ssp_cam082_ms45,
                                          Ssp_cam083_ms45 = sptablmsres4505.ssp_cam083_ms45,
                                          Ssp_cam084_ms45 = (DateTime)sptablmsres4505.ssp_cam084_ms45,
                                          Ssp_cam085_ms45 = sptablmsres4505.ssp_cam085_ms45,
                                          Ssp_cam086_ms45 = sptablmsres4505.ssp_cam086_ms45,
                                          Ssp_cam087_ms45 = (DateTime)sptablmsres4505.ssp_cam087_ms45,
                                          Ssp_cam088_ms45 = sptablmsres4505.ssp_cam088_ms45,
                                          Ssp_cam089_ms45 = sptablmsres4505.ssp_cam089_ms45,
                                          Ssp_cam090_ms45 = sptablmsres4505.ssp_cam090_ms45,
                                          Ssp_cam091_ms45 = (DateTime)sptablmsres4505.ssp_cam091_ms45,
                                          Ssp_cam092_ms45 = sptablmsres4505.ssp_cam092_ms45,
                                          Ssp_cam093_ms45 = (DateTime)sptablmsres4505.ssp_cam093_ms45,
                                          Ssp_cam094_ms45 = sptablmsres4505.ssp_cam094_ms45,
                                          Ssp_cam095_ms45 = sptablmsres4505.ssp_cam095_ms45,
                                          Ssp_cam096_ms45 = (DateTime)sptablmsres4505.ssp_cam096_ms45,
                                          Ssp_cam097_ms45 = sptablmsres4505.ssp_cam097_ms45,
                                          Ssp_cam098_ms45 = sptablmsres4505.ssp_cam098_ms45,
                                          Ssp_cam099_ms45 = (DateTime)sptablmsres4505.ssp_cam099_ms45,
                                          Ssp_cam100_ms45 = (DateTime)sptablmsres4505.ssp_cam100_ms45,
                                          Ssp_cam101_ms45 = sptablmsres4505.ssp_cam101_ms45,
                                          Ssp_cam102_ms45 = sptablmsres4505.ssp_cam102_ms45,
                                          Ssp_cam103_ms45 = (DateTime)sptablmsres4505.ssp_cam103_ms45,
                                          Ssp_cam104_ms45 = (int)sptablmsres4505.ssp_cam104_ms45,
                                          Ssp_cam105_ms45 = (DateTime)sptablmsres4505.ssp_cam105_ms45,
                                          Ssp_cam106_ms45 = (DateTime)sptablmsres4505.ssp_cam106_ms45,
                                          Ssp_cam107_ms45 = (int)sptablmsres4505.ssp_cam107_ms45,
                                          Ssp_cam108_ms45 = (DateTime)sptablmsres4505.ssp_cam108_ms45,
                                          Ssp_cam109_ms45 = (int)sptablmsres4505.ssp_cam109_ms45,
                                          Ssp_cam110_ms45 = (DateTime)sptablmsres4505.ssp_cam110_ms45,
                                          Ssp_cam111_ms45 = (DateTime)sptablmsres4505.ssp_cam111_ms45,
                                          Ssp_cam112_ms45 = (DateTime)sptablmsres4505.ssp_cam112_ms45,
                                          Ssp_cam113_ms45 = sptablmsres4505.ssp_cam113_ms45,
                                          Ssp_cam114_ms45 = sptablmsres4505.ssp_cam114_ms45,
                                          Ssp_cam115_ms45 = sptablmsres4505.ssp_cam115_ms45,
                                          Ssp_cam116_ms45 = sptablmsres4505.ssp_cam116_ms45,
                                          Ssp_cam117_ms45 = sptablmsres4505.ssp_cam117_ms45,
                                          Ssp_cam118_ms45 = (DateTime)sptablmsres4505.ssp_cam118_ms45,
                                          Ssp_consec_ms45 = (int)sptablmsres4505.ssp_consec_ms45,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Ssp_desocu_ciuo = ciuo.ssp_desocu_ciuo,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: sptablnsres4505
    /// </summary>
    public class ModeloSspNsRes4505x : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades Notificacion
        #region Ssp_idesec_ns45: Id único del registro
        private String _ssp_idesec_ns45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablnsres4505</para>
        /// <para>CAMPO: Id único del registro</para>
        /// <para>NOMBRE: ssp_idesec_ns45 (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Id Único del registro novedad
        /// </para>
        /// </summary>
        public String Ssp_idesec_ns45
        {
            get { return _ssp_idesec_ns45; }
            set
            {
                if (_ssp_idesec_ns45 == value) return;
                _ssp_idesec_ns45 = value;
                OnPropertyChanged("Ssp_idesec_ns45");
            }
        }
        #endregion
        #region Ssp_codper_peri: Código del periodo
        private String _ssp_codper_peri;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Código del periodo</para>
        /// <para>NOMBRE: ssp_codper_peri (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codigo del periodo
        /// </para>
        /// </summary>
        public String Ssp_codper_peri
        {
            get { return _ssp_codper_peri; }
            set
            {
                if (_ssp_codper_peri == value) return;
                _ssp_codper_peri = value;
                OnPropertyChanged("Ssp_codper_peri");
            }
        }
        #endregion
        #region Ssp_mesper_peri: Mes periodo
        private String _ssp_mesper_peri;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Mes periodo</para>
        /// <para>NOMBRE: ssp_mesper_peri (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Mes periodo
        /// </para>
        /// </summary>
        public String Ssp_mesper_peri
        {
            get { return _ssp_mesper_peri; }
            set
            {
                if (_ssp_mesper_peri == value) return;
                _ssp_mesper_peri = value;
                OnPropertyChanged("Ssp_mesper_peri");
            }
        }
        #endregion
        #region Ssp_anoper_peri: Año del periodo
        private String _ssp_anoper_peri;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Año del periodo</para>
        /// <para>NOMBRE: ssp_anoper_peri (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Año del periodo
        /// </para>
        /// </summary>
        public String Ssp_anoper_peri
        {
            get { return _ssp_anoper_peri; }
            set
            {
                if (_ssp_anoper_peri == value) return;
                _ssp_anoper_peri = value;
                OnPropertyChanged("Ssp_anoper_peri");
            }
        }
        #endregion
        #region Ssp_llaper_ns45: Llave del periodo (año+mes)
        private String _ssp_llaper_ns45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablnsres4505</para>
        /// <para>CAMPO: Llave del periodo (año+mes)</para>
        /// <para>NOMBRE: ssp_llaper_ns45 (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Llave del periodo (año+mes)
        /// </para>
        /// </summary>
        public String Ssp_llaper_ns45
        {
            get { return _ssp_llaper_ns45; }
            set
            {
                if (_ssp_llaper_ns45 == value) return;
                _ssp_llaper_ns45 = value;
                OnPropertyChanged("Ssp_llaper_ns45");
            }
        }
        #endregion
        #region Ssp_llaloc_ns45: Llave del periodo (año+mes)
        private String _ssp_llaloc_ns45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablnsres4505</para>
        /// <para>CAMPO: Llave del periodo (año+mes)</para>
        /// <para>NOMBRE: ssp_llaloc_ns45 (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Llave para localizacion del registro  (SIA_IDESEC_USUA+SSP_LLAPER_NS45)
        /// </para>
        /// </summary>
        public String Ssp_llaloc_ns45
        {
            get { return _ssp_llaloc_ns45; }
            set
            {
                if (_ssp_llaloc_ns45 == value) return;
                _ssp_llaloc_ns45 = value;
                OnPropertyChanged("Ssp_llaloc_ns45");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        private String _sia_idesec_usua;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region Sia_nroide_usua: Identificación
        private String _sia_nroide_usua;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación</para>
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
        #region Sia_codeps_teps: Código Eps/Asegurador
        private String _sia_codeps_teps;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código Eps/Asegurador</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region Ssp_cam000_ms45: 0.Tipo De Registro
        private String _ssp_cam000_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 0.Tipo De Registro</para>
        /// <para>NOMBRE: ssp_cam000_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Tipo De Registro
        /// </para>
        /// </summary>
        public String Ssp_cam000_ms45
        {
            get { return _ssp_cam000_ms45; }
            set
            {
                if (_ssp_cam000_ms45 == value) return;
                _ssp_cam000_ms45 = value;
                OnPropertyChanged("Ssp_cam000_ms45");
            }
        }
        #endregion
        #region Ssp_cam001_ms45: 1.Consecutivo de Registro
        private String _ssp_cam001_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 1.Consecutivo de Registro</para>
        /// <para>NOMBRE: ssp_cam001_ms45 (char:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Número consecutivo de registros de detalle dentro del archivo.
        /// Inicia en 1 para el primer registro de detalle y va incrementando
        /// de 1 en 1, hasta el final del archivo.
        /// </para>
        /// </summary>
        public String Ssp_cam001_ms45
        {
            get { return _ssp_cam001_ms45; }
            set
            {
                if (_ssp_cam001_ms45 == value) return;
                _ssp_cam001_ms45 = value;
                OnPropertyChanged("Ssp_cam001_ms45");
            }
        }
        #endregion
        #region Ssp_cam002_ms45: 2.Código de Habilitación IPS primaria
        private String _ssp_cam002_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 2.Código de Habilitación IPS primaria</para>
        /// <para>NOMBRE: ssp_cam002_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud) Si es desconocido registrar 99
        /// </para>
        /// </summary>
        public String Ssp_cam002_ms45
        {
            get { return _ssp_cam002_ms45; }
            set
            {
                if (_ssp_cam002_ms45 == value) return;
                _ssp_cam002_ms45 = value;
                OnPropertyChanged("Ssp_cam002_ms45");
            }
        }
        #endregion
        #region Ssp_cam003_ms45: 3.Tipo de identificación del usuario
        private String _ssp_cam003_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 3.Tipo de identificación del usuario</para>
        /// <para>NOMBRE: ssp_cam003_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo
        /// para menores con 2 meses o menos de nacidos calculando entre
        /// la fecha de nacimiento y la fecha de corte del reporte.
        /// </para>
        /// </summary>
        public String Ssp_cam003_ms45
        {
            get { return _ssp_cam003_ms45; }
            set
            {
                if (_ssp_cam003_ms45 == value) return;
                _ssp_cam003_ms45 = value;
                OnPropertyChanged("Ssp_cam003_ms45");
            }
        }
        #endregion
        #region Ssp_cam004_ms45: 4.Numero de identificación del usuario
        private String _ssp_cam004_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 4.Numero de identificación del usuario</para>
        /// <para>NOMBRE: ssp_cam004_ms45 (char:18)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Número del documento de identificación, de acuerdo con el tipo
        /// de identificación del campo anterior.
        /// </para>
        /// </summary>
        public String Ssp_cam004_ms45
        {
            get { return _ssp_cam004_ms45; }
            set
            {
                if (_ssp_cam004_ms45 == value) return;
                _ssp_cam004_ms45 = value;
                OnPropertyChanged("Ssp_cam004_ms45");
            }
        }
        #endregion
        #region Ssp_cam005_ms45: 5.Primer apellido del usuario
        private String _ssp_cam005_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 5.Primer apellido del usuario</para>
        /// <para>NOMBRE: ssp_cam005_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public String Ssp_cam005_ms45
        {
            get { return _ssp_cam005_ms45; }
            set
            {
                if (_ssp_cam005_ms45 == value) return;
                _ssp_cam005_ms45 = value;
                OnPropertyChanged("Ssp_cam005_ms45");
            }
        }
        #endregion
        #region Ssp_cam006_ms45: 6.Segundo apellido del usuario
        private String _ssp_cam006_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 6.Segundo apellido del usuario</para>
        /// <para>NOMBRE: ssp_cam006_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Tenga en cuenta el numeral 1. En caso que el usuario no tenga
        /// segundo apellido o no se tenga este dato Registre NONE, en
        /// mayúscula sostenida.
        /// </para>
        /// </summary>
        public String Ssp_cam006_ms45
        {
            get { return _ssp_cam006_ms45; }
            set
            {
                if (_ssp_cam006_ms45 == value) return;
                _ssp_cam006_ms45 = value;
                OnPropertyChanged("Ssp_cam006_ms45");
            }
        }
        #endregion
        #region Ssp_cam007_ms45: 7.Primer nombre del usuario
        private String _ssp_cam007_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 7.Primer nombre del usuario</para>
        /// <para>NOMBRE: ssp_cam007_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public String Ssp_cam007_ms45
        {
            get { return _ssp_cam007_ms45; }
            set
            {
                if (_ssp_cam007_ms45 == value) return;
                _ssp_cam007_ms45 = value;
                OnPropertyChanged("Ssp_cam007_ms45");
            }
        }
        #endregion
        #region Ssp_cam008_ms45: 8.Segundo nombre del usuario
        private String _ssp_cam008_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 8.Segundo nombre del usuario</para>
        /// <para>NOMBRE: ssp_cam008_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Segundo nombre del usuario. Tenga en cuenta el numeral 1. En
        /// caso que el usuario no tenga segundo apellido o no se tenga
        /// este dato Registre NONE, en mayúscula sostenida.
        /// </para>
        /// </summary>
        public String Ssp_cam008_ms45
        {
            get { return _ssp_cam008_ms45; }
            set
            {
                if (_ssp_cam008_ms45 == value) return;
                _ssp_cam008_ms45 = value;
                OnPropertyChanged("Ssp_cam008_ms45");
            }
        }
        #endregion
        #region Ssp_cam009_ms45: 9.Fecha de Nacimiento
        private DateTime _ssp_cam009_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 9.Fecha de Nacimiento</para>
        /// <para>NOMBRE: ssp_cam009_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Fecha de Nacimiento. AAAA-MM-DD
        /// </para>
        /// </summary>
        public DateTime Ssp_cam009_ms45
        {
            get { return _ssp_cam009_ms45; }
            set
            {
                if (_ssp_cam009_ms45 == value) return;
                _ssp_cam009_ms45 = value;
                OnPropertyChanged("Ssp_cam009_ms45");
            }
        }
        #endregion
        #region Ssp_cam010_ms45: 10.Sexo
        private String _ssp_cam010_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 10.Sexo</para>
        /// <para>NOMBRE: ssp_cam010_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Sexo. M - Masculino F - Femenino
        /// </para>
        /// </summary>
        public String Ssp_cam010_ms45
        {
            get { return _ssp_cam010_ms45; }
            set
            {
                if (_ssp_cam010_ms45 == value) return;
                _ssp_cam010_ms45 = value;
                OnPropertyChanged("Ssp_cam010_ms45");
            }
        }
        #endregion
        #region Ssp_cam011_ms45: 11.Codigo pertenencia étnica
        private String _ssp_cam011_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 11.Codigo pertenencia étnica</para>
        /// <para>NOMBRE: ssp_cam011_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo pertenencia etnica. Registre según lo reporte el usuario:
        /// 1-Indígena 2-ROM (gitano)3-Raizal etc
        /// </para>
        /// </summary>
        public String Ssp_cam011_ms45
        {
            get { return _ssp_cam011_ms45; }
            set
            {
                if (_ssp_cam011_ms45 == value) return;
                _ssp_cam011_ms45 = value;
                OnPropertyChanged("Ssp_cam011_ms45");
            }
        }
        #endregion
        #region Ssp_codocu_ciuo: 12.Codigo de ocupación
        private String _ssp_codocu_ciuo;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: spocupacionciuo</para>
        /// <para>CAMPO: 12.Codigo de ocupación</para>
        /// <para>NOMBRE: ssp_codocu_ciuo (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Código de acuerdo a la Clasificación Internacional Uniforme
        /// de Ocupaciones (CIUO). En los casos en que no se tiene esta
        /// información registrar (9999). En el caso que no aplique registrar
        /// (9998).
        /// </para>
        /// </summary>
        public String Ssp_codocu_ciuo
        {
            get { return _ssp_codocu_ciuo; }
            set
            {
                if (_ssp_codocu_ciuo == value) return;
                _ssp_codocu_ciuo = value;
                OnPropertyChanged("Ssp_codocu_ciuo");
            }
        }
        #endregion
        #region Ssp_cam013_ms45: 13.Codigo de nivel educativo
        private String _ssp_cam013_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 13.Codigo de nivel educativo</para>
        /// <para>NOMBRE: ssp_cam013_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Registre según lo reporte el usuario: 1- No Definido 2- Preescolar
        /// 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc
        /// </para>
        /// </summary>
        public String Ssp_cam013_ms45
        {
            get { return _ssp_cam013_ms45; }
            set
            {
                if (_ssp_cam013_ms45 == value) return;
                _ssp_cam013_ms45 = value;
                OnPropertyChanged("Ssp_cam013_ms45");
            }
        }
        #endregion
        #region Ssp_cam014_ms45: 14.Gestacion
        private String _ssp_cam014_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 14.Gestacion</para>
        /// <para>NOMBRE: ssp_cam014_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam014_ms45
        {
            get { return _ssp_cam014_ms45; }
            set
            {
                if (_ssp_cam014_ms45 == value) return;
                _ssp_cam014_ms45 = value;
                OnPropertyChanged("Ssp_cam014_ms45");
            }
        }
        #endregion
        #region Ssp_cam015_ms45: 15.Sifilis Gestacional o congénita
        private String _ssp_cam015_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 15.Sifilis Gestacional o congénita</para>
        /// <para>NOMBRE: ssp_cam015_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// 0- No 1- Si es mujer con sífilis gestacional 2- Si es recién
        /// nacido con sífilis congénita 3- No aplica 4- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam015_ms45
        {
            get { return _ssp_cam015_ms45; }
            set
            {
                if (_ssp_cam015_ms45 == value) return;
                _ssp_cam015_ms45 = value;
                OnPropertyChanged("Ssp_cam015_ms45");
            }
        }
        #endregion
        #region Ssp_cam016_ms45: 16.Hipertension Inducida por la Gestació
        private String _ssp_cam016_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 16.Hipertension Inducida por la Gestació</para>
        /// <para>NOMBRE: ssp_cam016_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Hipertension Inducida por la Gestacion 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam016_ms45
        {
            get { return _ssp_cam016_ms45; }
            set
            {
                if (_ssp_cam016_ms45 == value) return;
                _ssp_cam016_ms45 = value;
                OnPropertyChanged("Ssp_cam016_ms45");
            }
        }
        #endregion
        #region Ssp_cam017_ms45: 17.Hipotiroidismo Congénito
        private String _ssp_cam017_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 17.Hipotiroidismo Congénito</para>
        /// <para>NOMBRE: ssp_cam017_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Hipotiroidismo Congenito 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam017_ms45
        {
            get { return _ssp_cam017_ms45; }
            set
            {
                if (_ssp_cam017_ms45 == value) return;
                _ssp_cam017_ms45 = value;
                OnPropertyChanged("Ssp_cam017_ms45");
            }
        }
        #endregion
        #region Ssp_cam018_ms45: 18.Sintomatico Respiratorio
        private String _ssp_cam018_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 18.Sintomatico Respiratorio</para>
        /// <para>NOMBRE: ssp_cam018_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Sintomatico Respiratorio 0- No 1- Si 2- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam018_ms45
        {
            get { return _ssp_cam018_ms45; }
            set
            {
                if (_ssp_cam018_ms45 == value) return;
                _ssp_cam018_ms45 = value;
                OnPropertyChanged("Ssp_cam018_ms45");
            }
        }
        #endregion
        #region Ssp_cam019_ms45: 19.Tuberculosis Multidrogoresistente
        private String _ssp_cam019_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 19.Tuberculosis Multidrogoresistente</para>
        /// <para>NOMBRE: ssp_cam019_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Tuberculosis Multidrogoresistente 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam019_ms45
        {
            get { return _ssp_cam019_ms45; }
            set
            {
                if (_ssp_cam019_ms45 == value) return;
                _ssp_cam019_ms45 = value;
                OnPropertyChanged("Ssp_cam019_ms45");
            }
        }
        #endregion
        #region Ssp_cam020_ms45: 20.Lepra
        private String _ssp_cam020_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 20.Lepra</para>
        /// <para>NOMBRE: ssp_cam020_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Lepra 0- No 1- Pausibacilar 2- Multibacilar 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam020_ms45
        {
            get { return _ssp_cam020_ms45; }
            set
            {
                if (_ssp_cam020_ms45 == value) return;
                _ssp_cam020_ms45 = value;
                OnPropertyChanged("Ssp_cam020_ms45");
            }
        }
        #endregion
        #region Ssp_cam021_ms45: 21.Obesidad o Desnutrición Proteico Caló
        private String _ssp_cam021_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 21.Obesidad o Desnutrición Proteico Caló</para>
        /// <para>NOMBRE: ssp_cam021_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Obesidad o Desnutricion Proteico Calorica 0- No 1- Si es Obesidad
        /// 2- Si es Desnutrición Proteico Calórica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam021_ms45
        {
            get { return _ssp_cam021_ms45; }
            set
            {
                if (_ssp_cam021_ms45 == value) return;
                _ssp_cam021_ms45 = value;
                OnPropertyChanged("Ssp_cam021_ms45");
            }
        }
        #endregion
        #region Ssp_cam022_ms45: 22.Mujer Victima de Maltrato
        private String _ssp_cam022_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 22.Mujer Victima de Maltrato</para>
        /// <para>NOMBRE: ssp_cam022_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Mujer Victima de Maltrato 0- No 1- Si es Mujer víctima del
        /// maltrato 2- Si es Menor víctima del maltrato 3- No aplica 4-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam022_ms45
        {
            get { return _ssp_cam022_ms45; }
            set
            {
                if (_ssp_cam022_ms45 == value) return;
                _ssp_cam022_ms45 = value;
                OnPropertyChanged("Ssp_cam022_ms45");
            }
        }
        #endregion
        #region Ssp_cam023_ms45: 23.Victima de Violencia Sexual
        private String _ssp_cam023_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 23.Victima de Violencia Sexual</para>
        /// <para>NOMBRE: ssp_cam023_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Victima de Violencia Sexual 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam023_ms45
        {
            get { return _ssp_cam023_ms45; }
            set
            {
                if (_ssp_cam023_ms45 == value) return;
                _ssp_cam023_ms45 = value;
                OnPropertyChanged("Ssp_cam023_ms45");
            }
        }
        #endregion
        #region Ssp_cam024_ms45: 24.Infecciones de Trasmisión Sexual
        private String _ssp_cam024_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 24.Infecciones de Trasmisión Sexual</para>
        /// <para>NOMBRE: ssp_cam024_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Infecciones de Trasmision Sexual 0- No 1- Si 2- No aplica 3-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam024_ms45
        {
            get { return _ssp_cam024_ms45; }
            set
            {
                if (_ssp_cam024_ms45 == value) return;
                _ssp_cam024_ms45 = value;
                OnPropertyChanged("Ssp_cam024_ms45");
            }
        }
        #endregion
        #region Ssp_cam025_ms45: 25.Enfermedad Mental
        private String _ssp_cam025_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 25.Enfermedad Mental</para>
        /// <para>NOMBRE: ssp_cam025_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Enfermedad Mental 0- No 1- Si el diagnóstico es Ansiedad 2-
        /// Si el diagnóstico es Depresión 3- Si el diagnóstico es esquizofrenia
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam025_ms45
        {
            get { return _ssp_cam025_ms45; }
            set
            {
                if (_ssp_cam025_ms45 == value) return;
                _ssp_cam025_ms45 = value;
                OnPropertyChanged("Ssp_cam025_ms45");
            }
        }
        #endregion
        #region Ssp_cam026_ms45: 26.Cancer de Cérvix
        private String _ssp_cam026_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 26.Cancer de Cérvix</para>
        /// <para>NOMBRE: ssp_cam026_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Cancer de Cervix 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam026_ms45
        {
            get { return _ssp_cam026_ms45; }
            set
            {
                if (_ssp_cam026_ms45 == value) return;
                _ssp_cam026_ms45 = value;
                OnPropertyChanged("Ssp_cam026_ms45");
            }
        }
        #endregion
        #region Ssp_cam027_ms45: 27.Cancer de Seno
        private String _ssp_cam027_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 27.Cancer de Seno</para>
        /// <para>NOMBRE: ssp_cam027_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Cancer de Seno 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam027_ms45
        {
            get { return _ssp_cam027_ms45; }
            set
            {
                if (_ssp_cam027_ms45 == value) return;
                _ssp_cam027_ms45 = value;
                OnPropertyChanged("Ssp_cam027_ms45");
            }
        }
        #endregion
        #region Ssp_cam028_ms45: 28.Fluorosis Dental
        private String _ssp_cam028_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 28.Fluorosis Dental</para>
        /// <para>NOMBRE: ssp_cam028_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Fluorosis Dental 0- No 1- Si 2- No aplica 3- Riego no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam028_ms45
        {
            get { return _ssp_cam028_ms45; }
            set
            {
                if (_ssp_cam028_ms45 == value) return;
                _ssp_cam028_ms45 = value;
                OnPropertyChanged("Ssp_cam028_ms45");
            }
        }
        #endregion
        #region Ssp_cam029_ms45: 29.Fecha del Peso
        private DateTime _ssp_cam029_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 29.Fecha del Peso</para>
        /// <para>NOMBRE: ssp_cam029_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam029_ms45
        {
            get { return _ssp_cam029_ms45; }
            set
            {
                if (_ssp_cam029_ms45 == value) return;
                _ssp_cam029_ms45 = value;
                OnPropertyChanged("Ssp_cam029_ms45");
            }
        }
        #endregion
        #region Ssp_cam030_ms45: 30.Peso en Kilogramos
        private float _ssp_cam030_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 30.Peso en Kilogramos</para>
        /// <para>NOMBRE: ssp_cam030_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Peso en Kilogramos Se registra el dato obtenido de la medición.
        /// Si no se toma registrar 999
        /// </para>
        /// </summary>
        public float Ssp_cam030_ms45
        {
            get { return _ssp_cam030_ms45; }
            set
            {
                if (_ssp_cam030_ms45 == value) return;
                _ssp_cam030_ms45 = value;
                OnPropertyChanged("Ssp_cam030_ms45");
            }
        }
        #endregion
        #region Ssp_cam031_ms45: 31.Fecha de la Talla
        private DateTime _ssp_cam031_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 31.Fecha de la Talla</para>
        /// <para>NOMBRE: ssp_cam031_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam031_ms45
        {
            get { return _ssp_cam031_ms45; }
            set
            {
                if (_ssp_cam031_ms45 == value) return;
                _ssp_cam031_ms45 = value;
                OnPropertyChanged("Ssp_cam031_ms45");
            }
        }
        #endregion
        #region Ssp_cam032_ms45: 32.Talla en Centímetros
        private int _ssp_cam032_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 32.Talla en Centímetros</para>
        /// <para>NOMBRE: ssp_cam032_ms45 (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato obtenido de la medición. Si no se toma
        /// registrar 999
        /// </para>
        /// </summary>
        public int Ssp_cam032_ms45
        {
            get { return _ssp_cam032_ms45; }
            set
            {
                if (_ssp_cam032_ms45 == value) return;
                _ssp_cam032_ms45 = value;
                OnPropertyChanged("Ssp_cam032_ms45");
            }
        }
        #endregion
        #region Ssp_cam033_ms45: 33.Fecha Probable de Parto
        private DateTime _ssp_cam033_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 33.Fecha Probable de Parto</para>
        /// <para>NOMBRE: ssp_cam033_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam033_ms45
        {
            get { return _ssp_cam033_ms45; }
            set
            {
                if (_ssp_cam033_ms45 == value) return;
                _ssp_cam033_ms45 = value;
                OnPropertyChanged("Ssp_cam033_ms45");
            }
        }
        #endregion
        #region Ssp_cam034_ms45: 34.Edad Gestacional al Nacer
        private int _ssp_cam034_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 34.Edad Gestacional al Nacer</para>
        /// <para>NOMBRE: ssp_cam034_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato de la edad gestacional en semanas. Si no
        /// tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public int Ssp_cam034_ms45
        {
            get { return _ssp_cam034_ms45; }
            set
            {
                if (_ssp_cam034_ms45 == value) return;
                _ssp_cam034_ms45 = value;
                OnPropertyChanged("Ssp_cam034_ms45");
            }
        }
        #endregion
        #region Ssp_cam035_ms45: 35.BCG
        private String _ssp_cam035_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 35.BCG</para>
        /// <para>NOMBRE: ssp_cam035_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// BCG Registre el dato de la última dosis aplicada así: 0- RN
        /// 1- Otra Dosis 2- Sin dato 3- No se administra por una Tradición
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam035_ms45
        {
            get { return _ssp_cam035_ms45; }
            set
            {
                if (_ssp_cam035_ms45 == value) return;
                _ssp_cam035_ms45 = value;
                OnPropertyChanged("Ssp_cam035_ms45");
            }
        }
        #endregion
        #region Ssp_cam036_ms45: 36.Hepatitis B menores de 1 año
        private String _ssp_cam036_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 36.Hepatitis B menores de 1 año</para>
        /// <para>NOMBRE: ssp_cam036_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Hepatitis B menores de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- RN 1- Primera Dosis 2- Segunda Dosis
        /// 3- Tercera Dosis ETC
        /// </para>
        /// </summary>
        public String Ssp_cam036_ms45
        {
            get { return _ssp_cam036_ms45; }
            set
            {
                if (_ssp_cam036_ms45 == value) return;
                _ssp_cam036_ms45 = value;
                OnPropertyChanged("Ssp_cam036_ms45");
            }
        }
        #endregion
        #region Ssp_cam037_ms45: 37.Pentavalente
        private String _ssp_cam037_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 37.Pentavalente</para>
        /// <para>NOMBRE: ssp_cam037_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Pentavalente Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Sin dato
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam037_ms45
        {
            get { return _ssp_cam037_ms45; }
            set
            {
                if (_ssp_cam037_ms45 == value) return;
                _ssp_cam037_ms45 = value;
                OnPropertyChanged("Ssp_cam037_ms45");
            }
        }
        #endregion
        #region Ssp_cam038_ms45: 38.Polio
        private String _ssp_cam038_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 38.Polio</para>
        /// <para>NOMBRE: ssp_cam038_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Polio Registre el dato de la última dosis aplicada así: 0-
        /// Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Primer Refuerzo
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam038_ms45
        {
            get { return _ssp_cam038_ms45; }
            set
            {
                if (_ssp_cam038_ms45 == value) return;
                _ssp_cam038_ms45 = value;
                OnPropertyChanged("Ssp_cam038_ms45");
            }
        }
        #endregion
        #region Ssp_cam039_ms45: 39.DPT menores de 5 años
        private String _ssp_cam039_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 39.DPT menores de 5 años</para>
        /// <para>NOMBRE: ssp_cam039_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// DPT menores de 5 años Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3-
        /// Primer Refuerzo ETC
        /// </para>
        /// </summary>
        public String Ssp_cam039_ms45
        {
            get { return _ssp_cam039_ms45; }
            set
            {
                if (_ssp_cam039_ms45 == value) return;
                _ssp_cam039_ms45 = value;
                OnPropertyChanged("Ssp_cam039_ms45");
            }
        }
        #endregion
        #region Ssp_cam040_ms45: 40.Rotavirus
        private String _ssp_cam040_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 40.Rotavirus</para>
        /// <para>NOMBRE: ssp_cam040_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Rotavirus Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Sin dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam040_ms45
        {
            get { return _ssp_cam040_ms45; }
            set
            {
                if (_ssp_cam040_ms45 == value) return;
                _ssp_cam040_ms45 = value;
                OnPropertyChanged("Ssp_cam040_ms45");
            }
        }
        #endregion
        #region Ssp_cam041_ms45: 41.Neumococo
        private String _ssp_cam041_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 41.Neumococo</para>
        /// <para>NOMBRE: ssp_cam041_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Neumococo Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin
        /// dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam041_ms45
        {
            get { return _ssp_cam041_ms45; }
            set
            {
                if (_ssp_cam041_ms45 == value) return;
                _ssp_cam041_ms45 = value;
                OnPropertyChanged("Ssp_cam041_ms45");
            }
        }
        #endregion
        #region Ssp_cam042_ms45: 42.Influenza Niños
        private String _ssp_cam042_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 42.Influenza Niños</para>
        /// <para>NOMBRE: ssp_cam042_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Influenza Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC
        /// </para>
        /// </summary>
        public String Ssp_cam042_ms45
        {
            get { return _ssp_cam042_ms45; }
            set
            {
                if (_ssp_cam042_ms45 == value) return;
                _ssp_cam042_ms45 = value;
                OnPropertyChanged("Ssp_cam042_ms45");
            }
        }
        #endregion
        #region Ssp_cam043_ms45: 43.Fiebre Amarilla niños de 1 año
        private String _ssp_cam043_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 43.Fiebre Amarilla niños de 1 año</para>
        /// <para>NOMBRE: ssp_cam043_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fiebre Amarilla niños de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra
        /// por una Tradición ETC
        /// </para>
        /// </summary>
        public String Ssp_cam043_ms45
        {
            get { return _ssp_cam043_ms45; }
            set
            {
                if (_ssp_cam043_ms45 == value) return;
                _ssp_cam043_ms45 = value;
                OnPropertyChanged("Ssp_cam043_ms45");
            }
        }
        #endregion
        #region Ssp_cam044_ms45: 44.Hepatitis A
        private String _ssp_cam044_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 44.Hepatitis A</para>
        /// <para>NOMBRE: ssp_cam044_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Hepatitis A Registre el dato de la última dosis aplicada así:
        /// 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición
        /// 3- No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public String Ssp_cam044_ms45
        {
            get { return _ssp_cam044_ms45; }
            set
            {
                if (_ssp_cam044_ms45 == value) return;
                _ssp_cam044_ms45 = value;
                OnPropertyChanged("Ssp_cam044_ms45");
            }
        }
        #endregion
        #region Ssp_cam045_ms45: 45.Triple Viral Niños
        private String _ssp_cam045_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 45.Triple Viral Niños</para>
        /// <para>NOMBRE: ssp_cam045_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Triple Viral Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No
        /// se administra por una Tradición 4- No se administra por una
        /// Condición de Salud ETC
        /// </para>
        /// </summary>
        public String Ssp_cam045_ms45
        {
            get { return _ssp_cam045_ms45; }
            set
            {
                if (_ssp_cam045_ms45 == value) return;
                _ssp_cam045_ms45 = value;
                OnPropertyChanged("Ssp_cam045_ms45");
            }
        }
        #endregion
        #region Ssp_cam046_ms45: 46.Virus del Papiloma Humano (VPH)
        private String _ssp_cam046_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 46.Virus del Papiloma Humano (VPH)</para>
        /// <para>NOMBRE: ssp_cam046_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Virus del Papiloma Humano (VPH) Registre el dato de la última
        /// dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera
        /// Dosis 3- Sin dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam046_ms45
        {
            get { return _ssp_cam046_ms45; }
            set
            {
                if (_ssp_cam046_ms45 == value) return;
                _ssp_cam046_ms45 = value;
                OnPropertyChanged("Ssp_cam046_ms45");
            }
        }
        #endregion
        #region Ssp_cam047_ms45: 47.TD o TT Mujeres en Edad Fértil 15 a 4
        private String _ssp_cam047_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 47.TD o TT Mujeres en Edad Fértil 15 a 4</para>
        /// <para>NOMBRE: ssp_cam047_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato
        /// de la última dosis aplicada así: 0- Primera Dosis 1- Segunda
        /// Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC
        /// </para>
        /// </summary>
        public String Ssp_cam047_ms45
        {
            get { return _ssp_cam047_ms45; }
            set
            {
                if (_ssp_cam047_ms45 == value) return;
                _ssp_cam047_ms45 = value;
                OnPropertyChanged("Ssp_cam047_ms45");
            }
        }
        #endregion
        #region Ssp_cam048_ms45: 48.Control de Placa Bacteriana
        private String _ssp_cam048_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 48.Control de Placa Bacteriana</para>
        /// <para>NOMBRE: ssp_cam048_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Control de Placa Bacteriana 0- No se realiza por una Tradición
        /// 1- No se realiza por una Condición de Salud 2- No se realiza
        /// por Negación del usuario
        /// </para>
        /// </summary>
        public String Ssp_cam048_ms45
        {
            get { return _ssp_cam048_ms45; }
            set
            {
                if (_ssp_cam048_ms45 == value) return;
                _ssp_cam048_ms45 = value;
                OnPropertyChanged("Ssp_cam048_ms45");
            }
        }
        #endregion
        #region Ssp_cam049_ms45: 49.Fecha atención parto o cesárea
        private DateTime _ssp_cam049_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 49.Fecha atención parto o cesárea</para>
        /// <para>NOMBRE: ssp_cam049_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam049_ms45
        {
            get { return _ssp_cam049_ms45; }
            set
            {
                if (_ssp_cam049_ms45 == value) return;
                _ssp_cam049_ms45 = value;
                OnPropertyChanged("Ssp_cam049_ms45");
            }
        }
        #endregion
        #region Ssp_cam050_ms45: 50.Fecha salida de la atención del parto
        private DateTime _ssp_cam050_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 50.Fecha salida de la atención del parto</para>
        /// <para>NOMBRE: ssp_cam050_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Fecha salida de la atencion del parto o cesarea AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam050_ms45
        {
            get { return _ssp_cam050_ms45; }
            set
            {
                if (_ssp_cam050_ms45 == value) return;
                _ssp_cam050_ms45 = value;
                OnPropertyChanged("Ssp_cam050_ms45");
            }
        }
        #endregion
        #region Ssp_cam051_ms45: 51.Fecha de consejería en Lactancia Mate
        private DateTime _ssp_cam051_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 51.Fecha de consejería en Lactancia Mate</para>
        /// <para>NOMBRE: ssp_cam051_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no se realiza por una
        /// Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam051_ms45
        {
            get { return _ssp_cam051_ms45; }
            set
            {
                if (_ssp_cam051_ms45 == value) return;
                _ssp_cam051_ms45 = value;
                OnPropertyChanged("Ssp_cam051_ms45");
            }
        }
        #endregion
        #region Ssp_cam052_ms45: 52.Control Recién Nacido
        private DateTime _ssp_cam052_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 52.Control Recién Nacido</para>
        /// <para>NOMBRE: ssp_cam052_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam052_ms45
        {
            get { return _ssp_cam052_ms45; }
            set
            {
                if (_ssp_cam052_ms45 == value) return;
                _ssp_cam052_ms45 = value;
                OnPropertyChanged("Ssp_cam052_ms45");
            }
        }
        #endregion
        #region Ssp_cam053_ms45: 53.Planificacion Familiar Primera vez
        private DateTime _ssp_cam053_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 53.Planificacion Familiar Primera vez</para>
        /// <para>NOMBRE: ssp_cam053_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam053_ms45
        {
            get { return _ssp_cam053_ms45; }
            set
            {
                if (_ssp_cam053_ms45 == value) return;
                _ssp_cam053_ms45 = value;
                OnPropertyChanged("Ssp_cam053_ms45");
            }
        }
        #endregion
        #region Ssp_cam054_ms45: 54.Suministro de Método Anticonceptivo
        private String _ssp_cam054_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 54.Suministro de Método Anticonceptivo</para>
        /// <para>NOMBRE: ssp_cam054_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino
        /// 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico
        /// 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam054_ms45
        {
            get { return _ssp_cam054_ms45; }
            set
            {
                if (_ssp_cam054_ms45 == value) return;
                _ssp_cam054_ms45 = value;
                OnPropertyChanged("Ssp_cam054_ms45");
            }
        }
        #endregion
        #region Ssp_cam055_ms45: 55.Fecha Suministro de Método Anticoncep
        private DateTime _ssp_cam055_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 55.Fecha Suministro de Método Anticoncep</para>
        /// <para>NOMBRE: ssp_cam055_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam055_ms45
        {
            get { return _ssp_cam055_ms45; }
            set
            {
                if (_ssp_cam055_ms45 == value) return;
                _ssp_cam055_ms45 = value;
                OnPropertyChanged("Ssp_cam055_ms45");
            }
        }
        #endregion
        #region Ssp_cam056_ms45: 56.Control Prenatal de Primera vez
        private DateTime _ssp_cam056_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 56.Control Prenatal de Primera vez</para>
        /// <para>NOMBRE: ssp_cam056_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam056_ms45
        {
            get { return _ssp_cam056_ms45; }
            set
            {
                if (_ssp_cam056_ms45 == value) return;
                _ssp_cam056_ms45 = value;
                OnPropertyChanged("Ssp_cam056_ms45");
            }
        }
        #endregion
        #region Ssp_cam057_ms45: 57.Control Prenatal
        private int _ssp_cam057_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 57.Control Prenatal</para>
        /// <para>NOMBRE: ssp_cam057_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal Registre el número de controles que ha tenido
        /// en el último período de reporte durante la gestación actual,
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int Ssp_cam057_ms45
        {
            get { return _ssp_cam057_ms45; }
            set
            {
                if (_ssp_cam057_ms45 == value) return;
                _ssp_cam057_ms45 = value;
                OnPropertyChanged("Ssp_cam057_ms45");
            }
        }
        #endregion
        #region Ssp_cam058_ms45: 58.ultimo Control Prenatal
        private DateTime _ssp_cam058_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 58.ultimo Control Prenatal</para>
        /// <para>NOMBRE: ssp_cam058_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam058_ms45
        {
            get { return _ssp_cam058_ms45; }
            set
            {
                if (_ssp_cam058_ms45 == value) return;
                _ssp_cam058_ms45 = value;
                OnPropertyChanged("Ssp_cam058_ms45");
            }
        }
        #endregion
        #region Ssp_cam059_ms45: 59.Suministro de acido Fólico en el ulti
        private String _ssp_cam059_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 59.Suministro de acido Fólico en el ulti</para>
        /// <para>NOMBRE: ssp_cam059_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación de
        /// la usuaria 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam059_ms45
        {
            get { return _ssp_cam059_ms45; }
            set
            {
                if (_ssp_cam059_ms45 == value) return;
                _ssp_cam059_ms45 = value;
                OnPropertyChanged("Ssp_cam059_ms45");
            }
        }
        #endregion
        #region Ssp_cam060_ms45: 60.Suministro de Sulfato Ferroso en el u
        private String _ssp_cam060_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 60.Suministro de Sulfato Ferroso en el u</para>
        /// <para>NOMBRE: ssp_cam060_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam060_ms45
        {
            get { return _ssp_cam060_ms45; }
            set
            {
                if (_ssp_cam060_ms45 == value) return;
                _ssp_cam060_ms45 = value;
                OnPropertyChanged("Ssp_cam060_ms45");
            }
        }
        #endregion
        #region Ssp_cam061_ms45: 61.Suministro de Carbonato de Calcio en
        private String _ssp_cam061_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 61.Suministro de Carbonato de Calcio en</para>
        /// <para>NOMBRE: ssp_cam061_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam061_ms45
        {
            get { return _ssp_cam061_ms45; }
            set
            {
                if (_ssp_cam061_ms45 == value) return;
                _ssp_cam061_ms45 = value;
                OnPropertyChanged("Ssp_cam061_ms45");
            }
        }
        #endregion
        #region Ssp_cam062_ms45: 62.Valoracion de la Agudeza Visual
        private DateTime _ssp_cam062_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 62.Valoracion de la Agudeza Visual</para>
        /// <para>NOMBRE: ssp_cam062_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no
        /// se realiza por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam062_ms45
        {
            get { return _ssp_cam062_ms45; }
            set
            {
                if (_ssp_cam062_ms45 == value) return;
                _ssp_cam062_ms45 = value;
                OnPropertyChanged("Ssp_cam062_ms45");
            }
        }
        #endregion
        #region Ssp_cam063_ms45: 63.Consulta por Oftalmología
        private DateTime _ssp_cam063_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 63.Consulta por Oftalmología</para>
        /// <para>NOMBRE: ssp_cam063_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam063_ms45
        {
            get { return _ssp_cam063_ms45; }
            set
            {
                if (_ssp_cam063_ms45 == value) return;
                _ssp_cam063_ms45 = value;
                OnPropertyChanged("Ssp_cam063_ms45");
            }
        }
        #endregion
        #region Ssp_cam064_ms45: 64.Fecha Diagnostico Desnutrición Protei
        private DateTime _ssp_cam064_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 64.Fecha Diagnostico Desnutrición Protei</para>
        /// <para>NOMBRE: ssp_cam064_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam064_ms45
        {
            get { return _ssp_cam064_ms45; }
            set
            {
                if (_ssp_cam064_ms45 == value) return;
                _ssp_cam064_ms45 = value;
                OnPropertyChanged("Ssp_cam064_ms45");
            }
        }
        #endregion
        #region Ssp_cam065_ms45: 65.Consulta Mujer o Menor Victima del Ma
        private DateTime _ssp_cam065_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 65.Consulta Mujer o Menor Victima del Ma</para>
        /// <para>NOMBRE: ssp_cam065_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam065_ms45
        {
            get { return _ssp_cam065_ms45; }
            set
            {
                if (_ssp_cam065_ms45 == value) return;
                _ssp_cam065_ms45 = value;
                OnPropertyChanged("Ssp_cam065_ms45");
            }
        }
        #endregion
        #region Ssp_cam066_ms45: 66.Consulta Victimas de Violencia Sexual
        private DateTime _ssp_cam066_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 66.Consulta Victimas de Violencia Sexual</para>
        /// <para>NOMBRE: ssp_cam066_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam066_ms45
        {
            get { return _ssp_cam066_ms45; }
            set
            {
                if (_ssp_cam066_ms45 == value) return;
                _ssp_cam066_ms45 = value;
                OnPropertyChanged("Ssp_cam066_ms45");
            }
        }
        #endregion
        #region Ssp_cam067_ms45: 67.Consulta Nutrición
        private DateTime _ssp_cam067_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 67.Consulta Nutrición</para>
        /// <para>NOMBRE: ssp_cam067_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam067_ms45
        {
            get { return _ssp_cam067_ms45; }
            set
            {
                if (_ssp_cam067_ms45 == value) return;
                _ssp_cam067_ms45 = value;
                OnPropertyChanged("Ssp_cam067_ms45");
            }
        }
        #endregion
        #region Ssp_cam068_ms45: 68.Consulta de Psicología
        private DateTime _ssp_cam068_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 68.Consulta de Psicología</para>
        /// <para>NOMBRE: ssp_cam068_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam068_ms45
        {
            get { return _ssp_cam068_ms45; }
            set
            {
                if (_ssp_cam068_ms45 == value) return;
                _ssp_cam068_ms45 = value;
                OnPropertyChanged("Ssp_cam068_ms45");
            }
        }
        #endregion
        #region Ssp_cam069_ms45: 69.Consulta de Crecimiento y Desarrollo
        private DateTime _ssp_cam069_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 69.Consulta de Crecimiento y Desarrollo</para>
        /// <para>NOMBRE: ssp_cam069_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam069_ms45
        {
            get { return _ssp_cam069_ms45; }
            set
            {
                if (_ssp_cam069_ms45 == value) return;
                _ssp_cam069_ms45 = value;
                OnPropertyChanged("Ssp_cam069_ms45");
            }
        }
        #endregion
        #region Ssp_cam070_ms45: 70.Suministro de Sulfato Ferroso en la u
        private String _ssp_cam070_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 70.Suministro de Sulfato Ferroso en la u</para>
        /// <para>NOMBRE: ssp_cam070_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam070_ms45
        {
            get { return _ssp_cam070_ms45; }
            set
            {
                if (_ssp_cam070_ms45 == value) return;
                _ssp_cam070_ms45 = value;
                OnPropertyChanged("Ssp_cam070_ms45");
            }
        }
        #endregion
        #region Ssp_cam071_ms45: 71.Suministro de Vitamina A en la ultima
        private String _ssp_cam071_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 71.Suministro de Vitamina A en la ultima</para>
        /// <para>NOMBRE: ssp_cam071_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam071_ms45
        {
            get { return _ssp_cam071_ms45; }
            set
            {
                if (_ssp_cam071_ms45 == value) return;
                _ssp_cam071_ms45 = value;
                OnPropertyChanged("Ssp_cam071_ms45");
            }
        }
        #endregion
        #region Ssp_cam072_ms45: 72.Consulta de Joven Primera vez
        private DateTime _ssp_cam072_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 72.Consulta de Joven Primera vez</para>
        /// <para>NOMBRE: ssp_cam072_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam072_ms45
        {
            get { return _ssp_cam072_ms45; }
            set
            {
                if (_ssp_cam072_ms45 == value) return;
                _ssp_cam072_ms45 = value;
                OnPropertyChanged("Ssp_cam072_ms45");
            }
        }
        #endregion
        #region Ssp_cam073_ms45: 73.Consulta de Adulto Primera vez
        private DateTime _ssp_cam073_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 73.Consulta de Adulto Primera vez</para>
        /// <para>NOMBRE: ssp_cam073_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam073_ms45
        {
            get { return _ssp_cam073_ms45; }
            set
            {
                if (_ssp_cam073_ms45 == value) return;
                _ssp_cam073_ms45 = value;
                OnPropertyChanged("Ssp_cam073_ms45");
            }
        }
        #endregion
        #region Ssp_cam074_ms45: 74.Preservativos entregados a pacientes
        private int _ssp_cam074_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 74.Preservativos entregados a pacientes</para>
        /// <para>NOMBRE: ssp_cam074_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 84</para>
        /// <para>DESCRIPCION:
        /// Preservativos entregados a pacientes con ITS Registre el número
        /// de Preservativos entregados durante el período de reporte.
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// ETC
        /// </para>
        /// </summary>
        public int Ssp_cam074_ms45
        {
            get { return _ssp_cam074_ms45; }
            set
            {
                if (_ssp_cam074_ms45 == value) return;
                _ssp_cam074_ms45 = value;
                OnPropertyChanged("Ssp_cam074_ms45");
            }
        }
        #endregion
        #region Ssp_cam075_ms45: 75.Asesoria Pre test Elisa para VIH
        private DateTime _ssp_cam075_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 75.Asesoria Pre test Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam075_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 85</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam075_ms45
        {
            get { return _ssp_cam075_ms45; }
            set
            {
                if (_ssp_cam075_ms45 == value) return;
                _ssp_cam075_ms45 = value;
                OnPropertyChanged("Ssp_cam075_ms45");
            }
        }
        #endregion
        #region Ssp_cam076_ms45: 76.Asesoria Pos test Elisa para VIH
        private DateTime _ssp_cam076_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 76.Asesoria Pos test Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam076_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 86</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam076_ms45
        {
            get { return _ssp_cam076_ms45; }
            set
            {
                if (_ssp_cam076_ms45 == value) return;
                _ssp_cam076_ms45 = value;
                OnPropertyChanged("Ssp_cam076_ms45");
            }
        }
        #endregion
        #region Ssp_cam077_ms45: 77.Paciente con Diagnostico de: Ansiedad
        private String _ssp_cam077_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 77.Paciente con Diagnostico de: Ansiedad</para>
        /// <para>NOMBRE: ssp_cam077_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 87</para>
        /// <para>DESCRIPCION:
        /// 0- No recibió atención por tener una tradición que se lo impide
        /// 1- No recibió atención por una condición de salud 2- No recibió
        /// atención por negación del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam077_ms45
        {
            get { return _ssp_cam077_ms45; }
            set
            {
                if (_ssp_cam077_ms45 == value) return;
                _ssp_cam077_ms45 = value;
                OnPropertyChanged("Ssp_cam077_ms45");
            }
        }
        #endregion
        #region Ssp_cam078_ms45: 78.Fecha Antígeno de Superficie Hepatiti
        private DateTime _ssp_cam078_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 78.Fecha Antígeno de Superficie Hepatiti</para>
        /// <para>NOMBRE: ssp_cam078_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 88</para>
        /// <para>DESCRIPCION:
        /// Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam078_ms45
        {
            get { return _ssp_cam078_ms45; }
            set
            {
                if (_ssp_cam078_ms45 == value) return;
                _ssp_cam078_ms45 = value;
                OnPropertyChanged("Ssp_cam078_ms45");
            }
        }
        #endregion
        #region Ssp_cam079_ms45: 79.Resultado Antígeno de Superficie Hepa
        private String _ssp_cam079_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 79.Resultado Antígeno de Superficie Hepa</para>
        /// <para>NOMBRE: ssp_cam079_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 89</para>
        /// <para>DESCRIPCION:
        /// Resultado Antigeno de Superficie Hepatitis B en Gestantes 0-
        /// Negativo 1- Positivo 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam079_ms45
        {
            get { return _ssp_cam079_ms45; }
            set
            {
                if (_ssp_cam079_ms45 == value) return;
                _ssp_cam079_ms45 = value;
                OnPropertyChanged("Ssp_cam079_ms45");
            }
        }
        #endregion
        #region Ssp_cam080_ms45: 80.Fecha Serología para Sífilis
        private DateTime _ssp_cam080_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 80.Fecha Serología para Sífilis</para>
        /// <para>NOMBRE: ssp_cam080_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 90</para>
        /// <para>DESCRIPCION:
        /// Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam080_ms45
        {
            get { return _ssp_cam080_ms45; }
            set
            {
                if (_ssp_cam080_ms45 == value) return;
                _ssp_cam080_ms45 = value;
                OnPropertyChanged("Ssp_cam080_ms45");
            }
        }
        #endregion
        #region Ssp_cam081_ms45: 81.Resultado Serología para Sífilis
        private String _ssp_cam081_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 81.Resultado Serología para Sífilis</para>
        /// <para>NOMBRE: ssp_cam081_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 91</para>
        /// <para>DESCRIPCION:
        /// Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva
        /// 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam081_ms45
        {
            get { return _ssp_cam081_ms45; }
            set
            {
                if (_ssp_cam081_ms45 == value) return;
                _ssp_cam081_ms45 = value;
                OnPropertyChanged("Ssp_cam081_ms45");
            }
        }
        #endregion
        #region Ssp_cam082_ms45: 82.Fecha de Toma de Elisa para VIH
        private DateTime _ssp_cam082_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 82.Fecha de Toma de Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam082_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 92</para>
        /// <para>DESCRIPCION:
        /// Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam082_ms45
        {
            get { return _ssp_cam082_ms45; }
            set
            {
                if (_ssp_cam082_ms45 == value) return;
                _ssp_cam082_ms45 = value;
                OnPropertyChanged("Ssp_cam082_ms45");
            }
        }
        #endregion
        #region Ssp_cam083_ms45: 83.Resultado Elisa para VIH
        private String _ssp_cam083_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 83.Resultado Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam083_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 93</para>
        /// <para>DESCRIPCION:
        /// Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado
        /// 3- Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam083_ms45
        {
            get { return _ssp_cam083_ms45; }
            set
            {
                if (_ssp_cam083_ms45 == value) return;
                _ssp_cam083_ms45 = value;
                OnPropertyChanged("Ssp_cam083_ms45");
            }
        }
        #endregion
        #region Ssp_cam084_ms45: 84.Fecha TSH Neonatal
        private DateTime _ssp_cam084_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 84.Fecha TSH Neonatal</para>
        /// <para>NOMBRE: ssp_cam084_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 94</para>
        /// <para>DESCRIPCION:
        /// Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam084_ms45
        {
            get { return _ssp_cam084_ms45; }
            set
            {
                if (_ssp_cam084_ms45 == value) return;
                _ssp_cam084_ms45 = value;
                OnPropertyChanged("Ssp_cam084_ms45");
            }
        }
        #endregion
        #region Ssp_cam085_ms45: 85.Resultado de TSH Neonatal
        private String _ssp_cam085_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 85.Resultado de TSH Neonatal</para>
        /// <para>NOMBRE: ssp_cam085_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 95</para>
        /// <para>DESCRIPCION:
        /// Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato
        /// 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam085_ms45
        {
            get { return _ssp_cam085_ms45; }
            set
            {
                if (_ssp_cam085_ms45 == value) return;
                _ssp_cam085_ms45 = value;
                OnPropertyChanged("Ssp_cam085_ms45");
            }
        }
        #endregion
        #region Ssp_cam086_ms45: 86.Tamizaje Cáncer de Cuello Uterino
        private String _ssp_cam086_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 86.Tamizaje Cáncer de Cuello Uterino</para>
        /// <para>NOMBRE: ssp_cam086_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 96</para>
        /// <para>DESCRIPCION:
        /// Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public String Ssp_cam086_ms45
        {
            get { return _ssp_cam086_ms45; }
            set
            {
                if (_ssp_cam086_ms45 == value) return;
                _ssp_cam086_ms45 = value;
                OnPropertyChanged("Ssp_cam086_ms45");
            }
        }
        #endregion
        #region Ssp_cam087_ms45: 87.Citologia Cervico uterina
        private DateTime _ssp_cam087_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 87.Citologia Cervico uterina</para>
        /// <para>NOMBRE: ssp_cam087_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 97</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam087_ms45
        {
            get { return _ssp_cam087_ms45; }
            set
            {
                if (_ssp_cam087_ms45 == value) return;
                _ssp_cam087_ms45 = value;
                OnPropertyChanged("Ssp_cam087_ms45");
            }
        }
        #endregion
        #region Ssp_cam088_ms45: 88.Citologia Cervico uterina Resultados
        private String _ssp_cam088_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 88.Citologia Cervico uterina Resultados</para>
        /// <para>NOMBRE: ssp_cam088_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 98</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US
        /// (células escamosas atípicas de significado indeterminado) 2-
        /// ASC-H (células escamosas atípicas, que no puede descartar alto
        /// grado) 3- Lesión intraepitelial escamosa de bajo grado ETC
        /// </para>
        /// </summary>
        public String Ssp_cam088_ms45
        {
            get { return _ssp_cam088_ms45; }
            set
            {
                if (_ssp_cam088_ms45 == value) return;
                _ssp_cam088_ms45 = value;
                OnPropertyChanged("Ssp_cam088_ms45");
            }
        }
        #endregion
        #region Ssp_cam089_ms45: 89.Calidad en la Muestra de Citología Ce
        private String _ssp_cam089_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 89.Calidad en la Muestra de Citología Ce</para>
        /// <para>NOMBRE: ssp_cam089_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 99</para>
        /// <para>DESCRIPCION:
        /// Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria
        /// Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación
        /// Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato
        /// registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam089_ms45
        {
            get { return _ssp_cam089_ms45; }
            set
            {
                if (_ssp_cam089_ms45 == value) return;
                _ssp_cam089_ms45 = value;
                OnPropertyChanged("Ssp_cam089_ms45");
            }
        }
        #endregion
        #region Ssp_cam090_ms45: 90.Codigo de habilitación IPS donde se t
        private String _ssp_cam090_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 90.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam090_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 100</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Citologia Cervicouterina
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public String Ssp_cam090_ms45
        {
            get { return _ssp_cam090_ms45; }
            set
            {
                if (_ssp_cam090_ms45 == value) return;
                _ssp_cam090_ms45 = value;
                OnPropertyChanged("Ssp_cam090_ms45");
            }
        }
        #endregion
        #region Ssp_cam091_ms45: 91.Fecha Colposcopia
        private DateTime _ssp_cam091_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 91.Fecha Colposcopia</para>
        /// <para>NOMBRE: ssp_cam091_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 101</para>
        /// <para>DESCRIPCION:
        /// Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam091_ms45
        {
            get { return _ssp_cam091_ms45; }
            set
            {
                if (_ssp_cam091_ms45 == value) return;
                _ssp_cam091_ms45 = value;
                OnPropertyChanged("Ssp_cam091_ms45");
            }
        }
        #endregion
        #region Ssp_cam092_ms45: 92.Codigo de habilitación IPS donde se t
        private String _ssp_cam092_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 92.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam092_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 102</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Colposcopia Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam092_ms45
        {
            get { return _ssp_cam092_ms45; }
            set
            {
                if (_ssp_cam092_ms45 == value) return;
                _ssp_cam092_ms45 = value;
                OnPropertyChanged("Ssp_cam092_ms45");
            }
        }
        #endregion
        #region Ssp_cam093_ms45: 93.Fecha Biopsia Cervical
        private DateTime _ssp_cam093_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 93.Fecha Biopsia Cervical</para>
        /// <para>NOMBRE: ssp_cam093_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 103</para>
        /// <para>DESCRIPCION:
        /// Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam093_ms45
        {
            get { return _ssp_cam093_ms45; }
            set
            {
                if (_ssp_cam093_ms45 == value) return;
                _ssp_cam093_ms45 = value;
                OnPropertyChanged("Ssp_cam093_ms45");
            }
        }
        #endregion
        #region Ssp_cam094_ms45: 94.Resultado de Biopsia Cervical
        private String _ssp_cam094_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 94.Resultado de Biopsia Cervical</para>
        /// <para>NOMBRE: ssp_cam094_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 104</para>
        /// <para>DESCRIPCION:
        /// Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1-
        /// Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto
        /// Grado: NIC II - NIC III ETC
        /// </para>
        /// </summary>
        public String Ssp_cam094_ms45
        {
            get { return _ssp_cam094_ms45; }
            set
            {
                if (_ssp_cam094_ms45 == value) return;
                _ssp_cam094_ms45 = value;
                OnPropertyChanged("Ssp_cam094_ms45");
            }
        }
        #endregion
        #region Ssp_cam095_ms45: 95.Codigo de habilitación IPS donde se t
        private String _ssp_cam095_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 95.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam095_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 105</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam095_ms45
        {
            get { return _ssp_cam095_ms45; }
            set
            {
                if (_ssp_cam095_ms45 == value) return;
                _ssp_cam095_ms45 = value;
                OnPropertyChanged("Ssp_cam095_ms45");
            }
        }
        #endregion
        #region Ssp_cam096_ms45: 96.Fecha Mamografía
        private DateTime _ssp_cam096_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 96.Fecha Mamografía</para>
        /// <para>NOMBRE: ssp_cam096_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 106</para>
        /// <para>DESCRIPCION:
        /// Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam096_ms45
        {
            get { return _ssp_cam096_ms45; }
            set
            {
                if (_ssp_cam096_ms45 == value) return;
                _ssp_cam096_ms45 = value;
                OnPropertyChanged("Ssp_cam096_ms45");
            }
        }
        #endregion
        #region Ssp_cam097_ms45: 97.Resultado Mamografía
        private String _ssp_cam097_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 97.Resultado Mamografía</para>
        /// <para>NOMBRE: ssp_cam097_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 107</para>
        /// <para>DESCRIPCION:
        /// Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico
        /// o Mamograma previo para evaluación 1- Negativo 2- Hallazgos
        /// Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam097_ms45
        {
            get { return _ssp_cam097_ms45; }
            set
            {
                if (_ssp_cam097_ms45 == value) return;
                _ssp_cam097_ms45 = value;
                OnPropertyChanged("Ssp_cam097_ms45");
            }
        }
        #endregion
        #region Ssp_cam098_ms45: 98.Codigo de habilitación IPS donde se t
        private String _ssp_cam098_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 98.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam098_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 108</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS
        /// (Registro Especial de Prestadores de Servicios de Salud). Si
        /// no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam098_ms45
        {
            get { return _ssp_cam098_ms45; }
            set
            {
                if (_ssp_cam098_ms45 == value) return;
                _ssp_cam098_ms45 = value;
                OnPropertyChanged("Ssp_cam098_ms45");
            }
        }
        #endregion
        #region Ssp_cam099_ms45: 99.Fecha Toma Biopsia Seno por BACAF
        private DateTime _ssp_cam099_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 99.Fecha Toma Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: ssp_cam099_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 109</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam099_ms45
        {
            get { return _ssp_cam099_ms45; }
            set
            {
                if (_ssp_cam099_ms45 == value) return;
                _ssp_cam099_ms45 = value;
                OnPropertyChanged("Ssp_cam099_ms45");
            }
        }
        #endregion
        #region Ssp_cam100_ms45: 100.Fecha Resultado Biopsia Seno por BAC
        private DateTime _ssp_cam100_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 100.Fecha Resultado Biopsia Seno por BAC</para>
        /// <para>NOMBRE: ssp_cam100_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 110</para>
        /// <para>DESCRIPCION:
        /// Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam100_ms45
        {
            get { return _ssp_cam100_ms45; }
            set
            {
                if (_ssp_cam100_ms45 == value) return;
                _ssp_cam100_ms45 = value;
                OnPropertyChanged("Ssp_cam100_ms45");
            }
        }
        #endregion
        #region Ssp_cam101_ms45: 101.Biopsia Seno por BACAF
        private String _ssp_cam101_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 101.Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: ssp_cam101_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 111</para>
        /// <para>DESCRIPCION:
        /// Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada)
        /// 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam101_ms45
        {
            get { return _ssp_cam101_ms45; }
            set
            {
                if (_ssp_cam101_ms45 == value) return;
                _ssp_cam101_ms45 = value;
                OnPropertyChanged("Ssp_cam101_ms45");
            }
        }
        #endregion
        #region Ssp_cam102_ms45: 102.Codigo de habilitación IPS donde se
        private String _ssp_cam102_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 102.Codigo de habilitación IPS donde se</para>
        /// <para>NOMBRE: ssp_cam102_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 112</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public String Ssp_cam102_ms45
        {
            get { return _ssp_cam102_ms45; }
            set
            {
                if (_ssp_cam102_ms45 == value) return;
                _ssp_cam102_ms45 = value;
                OnPropertyChanged("Ssp_cam102_ms45");
            }
        }
        #endregion
        #region Ssp_cam103_ms45: 103.Fecha Toma de Hemoglobina
        private DateTime _ssp_cam103_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 103.Fecha Toma de Hemoglobina</para>
        /// <para>NOMBRE: ssp_cam103_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 113</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam103_ms45
        {
            get { return _ssp_cam103_ms45; }
            set
            {
                if (_ssp_cam103_ms45 == value) return;
                _ssp_cam103_ms45 = value;
                OnPropertyChanged("Ssp_cam103_ms45");
            }
        }
        #endregion
        #region Ssp_cam104_ms45: 104.Hemoglobina
        private float _ssp_cam104_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 104.Hemoglobina</para>
        /// <para>NOMBRE: ssp_cam104_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 114</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Registre el dato reportado por el laboratorio.
        /// Si no aplica registre 0
        /// </para>
        /// </summary>
        public float Ssp_cam104_ms45
        {
            get { return _ssp_cam104_ms45; }
            set
            {
                if (_ssp_cam104_ms45 == value) return;
                _ssp_cam104_ms45 = value;
                OnPropertyChanged("Ssp_cam104_ms45");
            }
        }
        #endregion
        #region Ssp_cam105_ms45: 105.Fecha de la Toma de Glicemia Basal
        private DateTime _ssp_cam105_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 105.Fecha de la Toma de Glicemia Basal</para>
        /// <para>NOMBRE: ssp_cam105_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 115</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam105_ms45
        {
            get { return _ssp_cam105_ms45; }
            set
            {
                if (_ssp_cam105_ms45 == value) return;
                _ssp_cam105_ms45 = value;
                OnPropertyChanged("Ssp_cam105_ms45");
            }
        }
        #endregion
        #region Ssp_cam106_ms45: 106.Fecha Creatinina
        private DateTime _ssp_cam106_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 106.Fecha Creatinina</para>
        /// <para>NOMBRE: ssp_cam106_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 116</para>
        /// <para>DESCRIPCION:
        /// Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam106_ms45
        {
            get { return _ssp_cam106_ms45; }
            set
            {
                if (_ssp_cam106_ms45 == value) return;
                _ssp_cam106_ms45 = value;
                OnPropertyChanged("Ssp_cam106_ms45");
            }
        }
        #endregion
        #region Ssp_cam107_ms45: 107.Creatinina
        private float _ssp_cam107_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 107.Creatinina</para>
        /// <para>NOMBRE: ssp_cam107_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 117</para>
        /// <para>DESCRIPCION:
        /// Creatinina Registre el dato reportado por el laboratorio. Si
        /// no tiene el dato registrar 999 Si no aplica registrar 0
        /// </para>
        /// </summary>
        public float Ssp_cam107_ms45
        {
            get { return _ssp_cam107_ms45; }
            set
            {
                if (_ssp_cam107_ms45 == value) return;
                _ssp_cam107_ms45 = value;
                OnPropertyChanged("Ssp_cam107_ms45");
            }
        }
        #endregion
        #region Ssp_cam108_ms45: 108.Fecha Hemoglobina Glicosilada
        private DateTime _ssp_cam108_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 108.Fecha Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: ssp_cam108_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 118</para>
        /// <para>DESCRIPCION:
        /// Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam108_ms45
        {
            get { return _ssp_cam108_ms45; }
            set
            {
                if (_ssp_cam108_ms45 == value) return;
                _ssp_cam108_ms45 = value;
                OnPropertyChanged("Ssp_cam108_ms45");
            }
        }
        #endregion
        #region Ssp_cam109_ms45: 109.Hemoglobina Glicosilada
        private float _ssp_cam109_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 109.Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: ssp_cam109_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 119</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Glicosilada Registre el dato reportado por el laboratorio
        /// Si no tiene el dato registrar 999 Si no aplica registrar 0
        /// </para>
        /// </summary>
        public float Ssp_cam109_ms45
        {
            get { return _ssp_cam109_ms45; }
            set
            {
                if (_ssp_cam109_ms45 == value) return;
                _ssp_cam109_ms45 = value;
                OnPropertyChanged("Ssp_cam109_ms45");
            }
        }
        #endregion
        #region Ssp_cam110_ms45: 110.Fecha Toma de Microalbuminuria
        private DateTime _ssp_cam110_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 110.Fecha Toma de Microalbuminuria</para>
        /// <para>NOMBRE: ssp_cam110_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 120</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam110_ms45
        {
            get { return _ssp_cam110_ms45; }
            set
            {
                if (_ssp_cam110_ms45 == value) return;
                _ssp_cam110_ms45 = value;
                OnPropertyChanged("Ssp_cam110_ms45");
            }
        }
        #endregion
        #region Ssp_cam111_ms45: 111.Fecha Toma de HDL
        private DateTime _ssp_cam111_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 111.Fecha Toma de HDL</para>
        /// <para>NOMBRE: ssp_cam111_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 121</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam111_ms45
        {
            get { return _ssp_cam111_ms45; }
            set
            {
                if (_ssp_cam111_ms45 == value) return;
                _ssp_cam111_ms45 = value;
                OnPropertyChanged("Ssp_cam111_ms45");
            }
        }
        #endregion
        #region Ssp_cam112_ms45: 112.Fecha Toma de Baciloscopia de Diagno
        private DateTime _ssp_cam112_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 112.Fecha Toma de Baciloscopia de Diagno</para>
        /// <para>NOMBRE: ssp_cam112_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 122</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam112_ms45
        {
            get { return _ssp_cam112_ms45; }
            set
            {
                if (_ssp_cam112_ms45 == value) return;
                _ssp_cam112_ms45 = value;
                OnPropertyChanged("Ssp_cam112_ms45");
            }
        }
        #endregion
        #region Ssp_cam113_ms45: 113.Baciloscopia de Diagnostico
        private String _ssp_cam113_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 113.Baciloscopia de Diagnostico</para>
        /// <para>NOMBRE: ssp_cam113_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 123</para>
        /// <para>DESCRIPCION:
        /// Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3-
        /// Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam113_ms45
        {
            get { return _ssp_cam113_ms45; }
            set
            {
                if (_ssp_cam113_ms45 == value) return;
                _ssp_cam113_ms45 = value;
                OnPropertyChanged("Ssp_cam113_ms45");
            }
        }
        #endregion
        #region Ssp_cam114_ms45: 114.Tratamiento para Hipotiroidismo Cong
        private String _ssp_cam114_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 114.Tratamiento para Hipotiroidismo Cong</para>
        /// <para>NOMBRE: ssp_cam114_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 124</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud que se lo impide ETC
        /// </para>
        /// </summary>
        public String Ssp_cam114_ms45
        {
            get { return _ssp_cam114_ms45; }
            set
            {
                if (_ssp_cam114_ms45 == value) return;
                _ssp_cam114_ms45 = value;
                OnPropertyChanged("Ssp_cam114_ms45");
            }
        }
        #endregion
        #region Ssp_cam115_ms45: 115.Tratamiento para Sífilis gestacional
        private String _ssp_cam115_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 115.Tratamiento para Sífilis gestacional</para>
        /// <para>NOMBRE: ssp_cam115_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 125</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis gestacional 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam115_ms45
        {
            get { return _ssp_cam115_ms45; }
            set
            {
                if (_ssp_cam115_ms45 == value) return;
                _ssp_cam115_ms45 = value;
                OnPropertyChanged("Ssp_cam115_ms45");
            }
        }
        #endregion
        #region Ssp_cam116_ms45: 116.Tratamiento para Sífilis Congénita
        private String _ssp_cam116_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 116.Tratamiento para Sífilis Congénita</para>
        /// <para>NOMBRE: ssp_cam116_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 126</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis Congenita 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam116_ms45
        {
            get { return _ssp_cam116_ms45; }
            set
            {
                if (_ssp_cam116_ms45 == value) return;
                _ssp_cam116_ms45 = value;
                OnPropertyChanged("Ssp_cam116_ms45");
            }
        }
        #endregion
        #region Ssp_cam117_ms45: 117.Tratamiento para Lepra
        private String _ssp_cam117_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 117.Tratamiento para Lepra</para>
        /// <para>NOMBRE: ssp_cam117_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 127</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Lepra 0- No recibió tratamiento por tener
        /// una tradición que se lo impide 1- No recibió tratamiento por
        /// una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam117_ms45
        {
            get { return _ssp_cam117_ms45; }
            set
            {
                if (_ssp_cam117_ms45 == value) return;
                _ssp_cam117_ms45 = value;
                OnPropertyChanged("Ssp_cam117_ms45");
            }
        }
        #endregion
        #region Ssp_cam118_ms45: 118.Fecha de Terminación Tratamiento par
        private DateTime _ssp_cam118_ms45;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 118.Fecha de Terminación Tratamiento par</para>
        /// <para>NOMBRE: ssp_cam118_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 128</para>
        /// <para>DESCRIPCION:
        /// Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 Si no se realiza por
        /// una Condición de Salud registrar 1810-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam118_ms45
        {
            get { return _ssp_cam118_ms45; }
            set
            {
                if (_ssp_cam118_ms45 == value) return;
                _ssp_cam118_ms45 = value;
                OnPropertyChanged("Ssp_cam118_ms45");
            }
        }
        #endregion
        #region Ssp_desper_peri: Descripción periodo
        private String _ssp_desper_peri;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Descripción periodo</para>
        /// <para>NOMBRE: ssp_desper_peri (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción periodo
        /// </para>
        /// </summary>
        public String Ssp_desper_peri
        {
            get { return _ssp_desper_peri; }
            set
            {
                if (_ssp_desper_peri == value) return;
                _ssp_desper_peri = value;
                OnPropertyChanged("Ssp_desper_peri");
            }
        }
        #endregion
        #region Ssp_desocu_ciuo: Ocupación
        private String _ssp_desocu_ciuo;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: spocupacionciuo</para>
        /// <para>CAMPO: Ocupación</para>
        /// <para>NOMBRE: ssp_desocu_ciuo (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Tipo de identificacion
        /// </para>
        /// </summary>
        public String Ssp_desocu_ciuo
        {
            get { return _ssp_desocu_ciuo; }
            set
            {
                if (_ssp_desocu_ciuo == value) return;
                _ssp_desocu_ciuo = value;
                OnPropertyChanged("Ssp_desocu_ciuo");
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
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloSspNsRes4505 tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFsptablnsres4505();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Sptablnsres4505.FirstOrDefault(p => p.ssp_idesec_ns45 == tobTempReg.Ssp_idesec_ns45);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.ssp_idesec_ns45 = tobTempReg.Ssp_idesec_ns45;
                            lobEFReg.ssp_codper_peri = tobTempReg.Ssp_codper_peri;
                            lobEFReg.ssp_mesper_peri = tobTempReg.Ssp_mesper_peri;
                            lobEFReg.ssp_anoper_peri = tobTempReg.Ssp_anoper_peri;
                            lobEFReg.ssp_llaper_ns45 = tobTempReg.Ssp_llaper_ns45;
                            lobEFReg.ssp_llaloc_ns45 = tobTempReg.Ssp_llaloc_ns45;
                            lobEFReg.sia_idesec_usua = tobTempReg.Sia_idesec_usua;
                            lobEFReg.sia_nroide_usua = tobTempReg.Sia_nroide_usua;
                            lobEFReg.sia_codeps_teps = tobTempReg.Sia_codeps_teps;
                            lobEFReg.ssp_cam000_ms45 = tobTempReg.Ssp_cam000_ms45;
                            lobEFReg.ssp_cam001_ms45 = tobTempReg.Ssp_cam001_ms45;
                            lobEFReg.ssp_cam002_ms45 = tobTempReg.Ssp_cam002_ms45;
                            lobEFReg.ssp_cam003_ms45 = tobTempReg.Ssp_cam003_ms45;
                            lobEFReg.ssp_cam004_ms45 = tobTempReg.Ssp_cam004_ms45;
                            lobEFReg.ssp_cam005_ms45 = tobTempReg.Ssp_cam005_ms45;
                            lobEFReg.ssp_cam006_ms45 = tobTempReg.Ssp_cam006_ms45;
                            lobEFReg.ssp_cam007_ms45 = tobTempReg.Ssp_cam007_ms45;
                            lobEFReg.ssp_cam008_ms45 = tobTempReg.Ssp_cam008_ms45;
                            lobEFReg.ssp_cam009_ms45 = (DateTime)tobTempReg.Ssp_cam009_ms45;
                            lobEFReg.ssp_cam010_ms45 = tobTempReg.Ssp_cam010_ms45;
                            lobEFReg.ssp_cam011_ms45 = tobTempReg.Ssp_cam011_ms45;
                            lobEFReg.ssp_codocu_ciuo = tobTempReg.Ssp_codocu_ciuo;
                            lobEFReg.ssp_cam013_ms45 = tobTempReg.Ssp_cam013_ms45;
                            lobEFReg.ssp_cam014_ms45 = tobTempReg.Ssp_cam014_ms45;
                            lobEFReg.ssp_cam015_ms45 = tobTempReg.Ssp_cam015_ms45;
                            lobEFReg.ssp_cam016_ms45 = tobTempReg.Ssp_cam016_ms45;
                            lobEFReg.ssp_cam017_ms45 = tobTempReg.Ssp_cam017_ms45;
                            lobEFReg.ssp_cam018_ms45 = tobTempReg.Ssp_cam018_ms45;
                            lobEFReg.ssp_cam019_ms45 = tobTempReg.Ssp_cam019_ms45;
                            lobEFReg.ssp_cam020_ms45 = tobTempReg.Ssp_cam020_ms45;
                            lobEFReg.ssp_cam021_ms45 = tobTempReg.Ssp_cam021_ms45;
                            lobEFReg.ssp_cam022_ms45 = tobTempReg.Ssp_cam022_ms45;
                            lobEFReg.ssp_cam023_ms45 = tobTempReg.Ssp_cam023_ms45;
                            lobEFReg.ssp_cam024_ms45 = tobTempReg.Ssp_cam024_ms45;
                            lobEFReg.ssp_cam025_ms45 = tobTempReg.Ssp_cam025_ms45;
                            lobEFReg.ssp_cam026_ms45 = tobTempReg.Ssp_cam026_ms45;
                            lobEFReg.ssp_cam027_ms45 = tobTempReg.Ssp_cam027_ms45;
                            lobEFReg.ssp_cam028_ms45 = tobTempReg.Ssp_cam028_ms45;
                            lobEFReg.ssp_cam029_ms45 = (DateTime)tobTempReg.Ssp_cam029_ms45;
                            lobEFReg.ssp_cam030_ms45 = (int)tobTempReg.Ssp_cam030_ms45;
                            lobEFReg.ssp_cam031_ms45 = (DateTime)tobTempReg.Ssp_cam031_ms45;
                            lobEFReg.ssp_cam032_ms45 = (int)tobTempReg.Ssp_cam032_ms45;
                            lobEFReg.ssp_cam033_ms45 = (DateTime)tobTempReg.Ssp_cam033_ms45;
                            lobEFReg.ssp_cam034_ms45 = (int)tobTempReg.Ssp_cam034_ms45;
                            lobEFReg.ssp_cam035_ms45 = tobTempReg.Ssp_cam035_ms45;
                            lobEFReg.ssp_cam036_ms45 = tobTempReg.Ssp_cam036_ms45;
                            lobEFReg.ssp_cam037_ms45 = tobTempReg.Ssp_cam037_ms45;
                            lobEFReg.ssp_cam038_ms45 = tobTempReg.Ssp_cam038_ms45;
                            lobEFReg.ssp_cam039_ms45 = tobTempReg.Ssp_cam039_ms45;
                            lobEFReg.ssp_cam040_ms45 = tobTempReg.Ssp_cam040_ms45;
                            lobEFReg.ssp_cam041_ms45 = tobTempReg.Ssp_cam041_ms45;
                            lobEFReg.ssp_cam042_ms45 = tobTempReg.Ssp_cam042_ms45;
                            lobEFReg.ssp_cam043_ms45 = tobTempReg.Ssp_cam043_ms45;
                            lobEFReg.ssp_cam044_ms45 = tobTempReg.Ssp_cam044_ms45;
                            lobEFReg.ssp_cam045_ms45 = tobTempReg.Ssp_cam045_ms45;
                            lobEFReg.ssp_cam046_ms45 = tobTempReg.Ssp_cam046_ms45;
                            lobEFReg.ssp_cam047_ms45 = tobTempReg.Ssp_cam047_ms45;
                            lobEFReg.ssp_cam048_ms45 = tobTempReg.Ssp_cam048_ms45;
                            lobEFReg.ssp_cam049_ms45 = (DateTime)tobTempReg.Ssp_cam049_ms45;
                            lobEFReg.ssp_cam050_ms45 = (DateTime)tobTempReg.Ssp_cam050_ms45;
                            lobEFReg.ssp_cam051_ms45 = (DateTime)tobTempReg.Ssp_cam051_ms45;
                            lobEFReg.ssp_cam052_ms45 = (DateTime)tobTempReg.Ssp_cam052_ms45;
                            lobEFReg.ssp_cam053_ms45 = (DateTime)tobTempReg.Ssp_cam053_ms45;
                            lobEFReg.ssp_cam054_ms45 = tobTempReg.Ssp_cam054_ms45;
                            lobEFReg.ssp_cam055_ms45 = (DateTime)tobTempReg.Ssp_cam055_ms45;
                            lobEFReg.ssp_cam056_ms45 = (DateTime)tobTempReg.Ssp_cam056_ms45;
                            lobEFReg.ssp_cam057_ms45 = (int)tobTempReg.Ssp_cam057_ms45;
                            lobEFReg.ssp_cam058_ms45 = (DateTime)tobTempReg.Ssp_cam058_ms45;
                            lobEFReg.ssp_cam059_ms45 = tobTempReg.Ssp_cam059_ms45;
                            lobEFReg.ssp_cam060_ms45 = tobTempReg.Ssp_cam060_ms45;
                            lobEFReg.ssp_cam061_ms45 = tobTempReg.Ssp_cam061_ms45;
                            lobEFReg.ssp_cam062_ms45 = (DateTime)tobTempReg.Ssp_cam062_ms45;
                            lobEFReg.ssp_cam063_ms45 = (DateTime)tobTempReg.Ssp_cam063_ms45;
                            lobEFReg.ssp_cam064_ms45 = (DateTime)tobTempReg.Ssp_cam064_ms45;
                            lobEFReg.ssp_cam065_ms45 = (DateTime)tobTempReg.Ssp_cam065_ms45;
                            lobEFReg.ssp_cam066_ms45 = (DateTime)tobTempReg.Ssp_cam066_ms45;
                            lobEFReg.ssp_cam067_ms45 = (DateTime)tobTempReg.Ssp_cam067_ms45;
                            lobEFReg.ssp_cam068_ms45 = (DateTime)tobTempReg.Ssp_cam068_ms45;
                            lobEFReg.ssp_cam069_ms45 = (DateTime)tobTempReg.Ssp_cam069_ms45;
                            lobEFReg.ssp_cam070_ms45 = tobTempReg.Ssp_cam070_ms45;
                            lobEFReg.ssp_cam071_ms45 = tobTempReg.Ssp_cam071_ms45;
                            lobEFReg.ssp_cam072_ms45 = (DateTime)tobTempReg.Ssp_cam072_ms45;
                            lobEFReg.ssp_cam073_ms45 = (DateTime)tobTempReg.Ssp_cam073_ms45;
                            lobEFReg.ssp_cam074_ms45 = (int)tobTempReg.Ssp_cam074_ms45;
                            lobEFReg.ssp_cam075_ms45 = (DateTime)tobTempReg.Ssp_cam075_ms45;
                            lobEFReg.ssp_cam076_ms45 = (DateTime)tobTempReg.Ssp_cam076_ms45;
                            lobEFReg.ssp_cam077_ms45 = tobTempReg.Ssp_cam077_ms45;
                            lobEFReg.ssp_cam078_ms45 = (DateTime)tobTempReg.Ssp_cam078_ms45;
                            lobEFReg.ssp_cam079_ms45 = tobTempReg.Ssp_cam079_ms45;
                            lobEFReg.ssp_cam080_ms45 = (DateTime)tobTempReg.Ssp_cam080_ms45;
                            lobEFReg.ssp_cam081_ms45 = tobTempReg.Ssp_cam081_ms45;
                            lobEFReg.ssp_cam082_ms45 = (DateTime)tobTempReg.Ssp_cam082_ms45;
                            lobEFReg.ssp_cam083_ms45 = tobTempReg.Ssp_cam083_ms45;
                            lobEFReg.ssp_cam084_ms45 = (DateTime)tobTempReg.Ssp_cam084_ms45;
                            lobEFReg.ssp_cam085_ms45 = tobTempReg.Ssp_cam085_ms45;
                            lobEFReg.ssp_cam086_ms45 = tobTempReg.Ssp_cam086_ms45;
                            lobEFReg.ssp_cam087_ms45 = (DateTime)tobTempReg.Ssp_cam087_ms45;
                            lobEFReg.ssp_cam088_ms45 = tobTempReg.Ssp_cam088_ms45;
                            lobEFReg.ssp_cam089_ms45 = tobTempReg.Ssp_cam089_ms45;
                            lobEFReg.ssp_cam090_ms45 = tobTempReg.Ssp_cam090_ms45;
                            lobEFReg.ssp_cam091_ms45 = (DateTime)tobTempReg.Ssp_cam091_ms45;
                            lobEFReg.ssp_cam092_ms45 = tobTempReg.Ssp_cam092_ms45;
                            lobEFReg.ssp_cam093_ms45 = (DateTime)tobTempReg.Ssp_cam093_ms45;
                            lobEFReg.ssp_cam094_ms45 = tobTempReg.Ssp_cam094_ms45;
                            lobEFReg.ssp_cam095_ms45 = tobTempReg.Ssp_cam095_ms45;
                            lobEFReg.ssp_cam096_ms45 = (DateTime)tobTempReg.Ssp_cam096_ms45;
                            lobEFReg.ssp_cam097_ms45 = tobTempReg.Ssp_cam097_ms45;
                            lobEFReg.ssp_cam098_ms45 = tobTempReg.Ssp_cam098_ms45;
                            lobEFReg.ssp_cam099_ms45 = (DateTime)tobTempReg.Ssp_cam099_ms45;
                            lobEFReg.ssp_cam100_ms45 = (DateTime)tobTempReg.Ssp_cam100_ms45;
                            lobEFReg.ssp_cam101_ms45 = tobTempReg.Ssp_cam101_ms45;
                            lobEFReg.ssp_cam102_ms45 = tobTempReg.Ssp_cam102_ms45;
                            lobEFReg.ssp_cam103_ms45 = (DateTime)tobTempReg.Ssp_cam103_ms45;
                            lobEFReg.ssp_cam104_ms45 = (int)tobTempReg.Ssp_cam104_ms45;
                            lobEFReg.ssp_cam105_ms45 = (DateTime)tobTempReg.Ssp_cam105_ms45;
                            lobEFReg.ssp_cam106_ms45 = (DateTime)tobTempReg.Ssp_cam106_ms45;
                            lobEFReg.ssp_cam107_ms45 = (int)tobTempReg.Ssp_cam107_ms45;
                            lobEFReg.ssp_cam108_ms45 = (DateTime)tobTempReg.Ssp_cam108_ms45;
                            lobEFReg.ssp_cam109_ms45 = (int)tobTempReg.Ssp_cam109_ms45;
                            lobEFReg.ssp_cam110_ms45 = (DateTime)tobTempReg.Ssp_cam110_ms45;
                            lobEFReg.ssp_cam111_ms45 = (DateTime)tobTempReg.Ssp_cam111_ms45;
                            lobEFReg.ssp_cam112_ms45 = (DateTime)tobTempReg.Ssp_cam112_ms45;
                            lobEFReg.ssp_cam113_ms45 = tobTempReg.Ssp_cam113_ms45;
                            lobEFReg.ssp_cam114_ms45 = tobTempReg.Ssp_cam114_ms45;
                            lobEFReg.ssp_cam115_ms45 = tobTempReg.Ssp_cam115_ms45;
                            lobEFReg.ssp_cam116_ms45 = tobTempReg.Ssp_cam116_ms45;
                            lobEFReg.ssp_cam117_ms45 = tobTempReg.Ssp_cam117_ms45;
                            lobEFReg.ssp_cam118_ms45 = (DateTime)tobTempReg.Ssp_cam118_ms45;
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
                                lobEFReg.ssp_idesec_ns45 = tcrCodigoR1 + lobEFReg.ssp_idesec_ns45; // concatenar
                                _context.AddToSptablnsres4505(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Sptablnsres4505.FirstOrDefault(p => p.ssp_idesec_ns45 == tobTempReg.Ssp_idesec_ns45);
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
        #region Buscar SPTABLNSRES4505: Logica
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TITULO: Novedades mensuales RES4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que almacena las novedades realizadas en un periodo para
        /// el RES4505
        /// </para>
        /// </summary>
        public static bool flgBuscarSptablnsres4505(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablnsres4505.FirstOrDefault(p => p.ssp_idesec_ns45 == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSspNsRes4505> flsListaSptablnsres4505(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from sptablnsres4505 in _context.Sptablnsres4505
                                  join sptablaperiodos in _context.Sptablaperiodos on sptablnsres4505.ssp_codper_peri equals sptablaperiodos.ssp_codper_peri into tmsptablaperiodos
                                  join spocupacionciuo in _context.Spocupacionciuo on sptablnsres4505.ssp_codocu_ciuo equals spocupacionciuo.ssp_codocu_ciuo into tmspocupacionciuo
                                  from peri in tmsptablaperiodos.DefaultIfEmpty()
                                  from ciuo in tmspocupacionciuo.DefaultIfEmpty()
                                  where sptablnsres4505.ssp_cam001_ms45 == tcrBuscar
                                  select new ModeloSspNsRes4505
                                  {
                                      Ssp_idesec_ns45 = sptablnsres4505.ssp_idesec_ns45,
                                      Ssp_codper_peri = sptablnsres4505.ssp_codper_peri,
                                      Ssp_mesper_peri = sptablnsres4505.ssp_mesper_peri,
                                      Ssp_anoper_peri = sptablnsres4505.ssp_anoper_peri,
                                      Ssp_llaper_ns45 = sptablnsres4505.ssp_llaper_ns45,
                                      Ssp_llaloc_ns45 = sptablnsres4505.ssp_llaloc_ns45,
                                      Sia_idesec_usua = sptablnsres4505.sia_idesec_usua,
                                      Sia_nroide_usua = sptablnsres4505.sia_nroide_usua,
                                      Sia_codeps_teps = sptablnsres4505.sia_codeps_teps,
                                      Ssp_cam000_ms45 = sptablnsres4505.ssp_cam000_ms45,
                                      Ssp_cam001_ms45 = sptablnsres4505.ssp_cam001_ms45,
                                      Ssp_cam002_ms45 = sptablnsres4505.ssp_cam002_ms45,
                                      Ssp_cam003_ms45 = sptablnsres4505.ssp_cam003_ms45,
                                      Ssp_cam004_ms45 = sptablnsres4505.ssp_cam004_ms45,
                                      Ssp_cam005_ms45 = sptablnsres4505.ssp_cam005_ms45,
                                      Ssp_cam006_ms45 = sptablnsres4505.ssp_cam006_ms45,
                                      Ssp_cam007_ms45 = sptablnsres4505.ssp_cam007_ms45,
                                      Ssp_cam008_ms45 = sptablnsres4505.ssp_cam008_ms45,
                                      Ssp_cam009_ms45 = (DateTime)sptablnsres4505.ssp_cam009_ms45,
                                      Ssp_cam010_ms45 = sptablnsres4505.ssp_cam010_ms45,
                                      Ssp_cam011_ms45 = sptablnsres4505.ssp_cam011_ms45,
                                      Ssp_codocu_ciuo = sptablnsres4505.ssp_codocu_ciuo,
                                      Ssp_cam013_ms45 = sptablnsres4505.ssp_cam013_ms45,
                                      Ssp_cam014_ms45 = sptablnsres4505.ssp_cam014_ms45,
                                      Ssp_cam015_ms45 = sptablnsres4505.ssp_cam015_ms45,
                                      Ssp_cam016_ms45 = sptablnsres4505.ssp_cam016_ms45,
                                      Ssp_cam017_ms45 = sptablnsres4505.ssp_cam017_ms45,
                                      Ssp_cam018_ms45 = sptablnsres4505.ssp_cam018_ms45,
                                      Ssp_cam019_ms45 = sptablnsres4505.ssp_cam019_ms45,
                                      Ssp_cam020_ms45 = sptablnsres4505.ssp_cam020_ms45,
                                      Ssp_cam021_ms45 = sptablnsres4505.ssp_cam021_ms45,
                                      Ssp_cam022_ms45 = sptablnsres4505.ssp_cam022_ms45,
                                      Ssp_cam023_ms45 = sptablnsres4505.ssp_cam023_ms45,
                                      Ssp_cam024_ms45 = sptablnsres4505.ssp_cam024_ms45,
                                      Ssp_cam025_ms45 = sptablnsres4505.ssp_cam025_ms45,
                                      Ssp_cam026_ms45 = sptablnsres4505.ssp_cam026_ms45,
                                      Ssp_cam027_ms45 = sptablnsres4505.ssp_cam027_ms45,
                                      Ssp_cam028_ms45 = sptablnsres4505.ssp_cam028_ms45,
                                      Ssp_cam029_ms45 = (DateTime)sptablnsres4505.ssp_cam029_ms45,
                                      Ssp_cam030_ms45 = (int)sptablnsres4505.ssp_cam030_ms45,
                                      Ssp_cam031_ms45 = (DateTime)sptablnsres4505.ssp_cam031_ms45,
                                      Ssp_cam032_ms45 = (int)sptablnsres4505.ssp_cam032_ms45,
                                      Ssp_cam033_ms45 = (DateTime)sptablnsres4505.ssp_cam033_ms45,
                                      Ssp_cam034_ms45 = (int)sptablnsres4505.ssp_cam034_ms45,
                                      Ssp_cam035_ms45 = sptablnsres4505.ssp_cam035_ms45,
                                      Ssp_cam036_ms45 = sptablnsres4505.ssp_cam036_ms45,
                                      Ssp_cam037_ms45 = sptablnsres4505.ssp_cam037_ms45,
                                      Ssp_cam038_ms45 = sptablnsres4505.ssp_cam038_ms45,
                                      Ssp_cam039_ms45 = sptablnsres4505.ssp_cam039_ms45,
                                      Ssp_cam040_ms45 = sptablnsres4505.ssp_cam040_ms45,
                                      Ssp_cam041_ms45 = sptablnsres4505.ssp_cam041_ms45,
                                      Ssp_cam042_ms45 = sptablnsres4505.ssp_cam042_ms45,
                                      Ssp_cam043_ms45 = sptablnsres4505.ssp_cam043_ms45,
                                      Ssp_cam044_ms45 = sptablnsres4505.ssp_cam044_ms45,
                                      Ssp_cam045_ms45 = sptablnsres4505.ssp_cam045_ms45,
                                      Ssp_cam046_ms45 = sptablnsres4505.ssp_cam046_ms45,
                                      Ssp_cam047_ms45 = sptablnsres4505.ssp_cam047_ms45,
                                      Ssp_cam048_ms45 = sptablnsres4505.ssp_cam048_ms45,
                                      Ssp_cam049_ms45 = (DateTime)sptablnsres4505.ssp_cam049_ms45,
                                      Ssp_cam050_ms45 = (DateTime)sptablnsres4505.ssp_cam050_ms45,
                                      Ssp_cam051_ms45 = (DateTime)sptablnsres4505.ssp_cam051_ms45,
                                      Ssp_cam052_ms45 = (DateTime)sptablnsres4505.ssp_cam052_ms45,
                                      Ssp_cam053_ms45 = (DateTime)sptablnsres4505.ssp_cam053_ms45,
                                      Ssp_cam054_ms45 = sptablnsres4505.ssp_cam054_ms45,
                                      Ssp_cam055_ms45 = (DateTime)sptablnsres4505.ssp_cam055_ms45,
                                      Ssp_cam056_ms45 = (DateTime)sptablnsres4505.ssp_cam056_ms45,
                                      Ssp_cam057_ms45 = (int)sptablnsres4505.ssp_cam057_ms45,
                                      Ssp_cam058_ms45 = (DateTime)sptablnsres4505.ssp_cam058_ms45,
                                      Ssp_cam059_ms45 = sptablnsres4505.ssp_cam059_ms45,
                                      Ssp_cam060_ms45 = sptablnsres4505.ssp_cam060_ms45,
                                      Ssp_cam061_ms45 = sptablnsres4505.ssp_cam061_ms45,
                                      Ssp_cam062_ms45 = (DateTime)sptablnsres4505.ssp_cam062_ms45,
                                      Ssp_cam063_ms45 = (DateTime)sptablnsres4505.ssp_cam063_ms45,
                                      Ssp_cam064_ms45 = (DateTime)sptablnsres4505.ssp_cam064_ms45,
                                      Ssp_cam065_ms45 = (DateTime)sptablnsres4505.ssp_cam065_ms45,
                                      Ssp_cam066_ms45 = (DateTime)sptablnsres4505.ssp_cam066_ms45,
                                      Ssp_cam067_ms45 = (DateTime)sptablnsres4505.ssp_cam067_ms45,
                                      Ssp_cam068_ms45 = (DateTime)sptablnsres4505.ssp_cam068_ms45,
                                      Ssp_cam069_ms45 = (DateTime)sptablnsres4505.ssp_cam069_ms45,
                                      Ssp_cam070_ms45 = sptablnsres4505.ssp_cam070_ms45,
                                      Ssp_cam071_ms45 = sptablnsres4505.ssp_cam071_ms45,
                                      Ssp_cam072_ms45 = (DateTime)sptablnsres4505.ssp_cam072_ms45,
                                      Ssp_cam073_ms45 = (DateTime)sptablnsres4505.ssp_cam073_ms45,
                                      Ssp_cam074_ms45 = (int)sptablnsres4505.ssp_cam074_ms45,
                                      Ssp_cam075_ms45 = (DateTime)sptablnsres4505.ssp_cam075_ms45,
                                      Ssp_cam076_ms45 = (DateTime)sptablnsres4505.ssp_cam076_ms45,
                                      Ssp_cam077_ms45 = sptablnsres4505.ssp_cam077_ms45,
                                      Ssp_cam078_ms45 = (DateTime)sptablnsres4505.ssp_cam078_ms45,
                                      Ssp_cam079_ms45 = sptablnsres4505.ssp_cam079_ms45,
                                      Ssp_cam080_ms45 = (DateTime)sptablnsres4505.ssp_cam080_ms45,
                                      Ssp_cam081_ms45 = sptablnsres4505.ssp_cam081_ms45,
                                      Ssp_cam082_ms45 = (DateTime)sptablnsres4505.ssp_cam082_ms45,
                                      Ssp_cam083_ms45 = sptablnsres4505.ssp_cam083_ms45,
                                      Ssp_cam084_ms45 = (DateTime)sptablnsres4505.ssp_cam084_ms45,
                                      Ssp_cam085_ms45 = sptablnsres4505.ssp_cam085_ms45,
                                      Ssp_cam086_ms45 = sptablnsres4505.ssp_cam086_ms45,
                                      Ssp_cam087_ms45 = (DateTime)sptablnsres4505.ssp_cam087_ms45,
                                      Ssp_cam088_ms45 = sptablnsres4505.ssp_cam088_ms45,
                                      Ssp_cam089_ms45 = sptablnsres4505.ssp_cam089_ms45,
                                      Ssp_cam090_ms45 = sptablnsres4505.ssp_cam090_ms45,
                                      Ssp_cam091_ms45 = (DateTime)sptablnsres4505.ssp_cam091_ms45,
                                      Ssp_cam092_ms45 = sptablnsres4505.ssp_cam092_ms45,
                                      Ssp_cam093_ms45 = (DateTime)sptablnsres4505.ssp_cam093_ms45,
                                      Ssp_cam094_ms45 = sptablnsres4505.ssp_cam094_ms45,
                                      Ssp_cam095_ms45 = sptablnsres4505.ssp_cam095_ms45,
                                      Ssp_cam096_ms45 = (DateTime)sptablnsres4505.ssp_cam096_ms45,
                                      Ssp_cam097_ms45 = sptablnsres4505.ssp_cam097_ms45,
                                      Ssp_cam098_ms45 = sptablnsres4505.ssp_cam098_ms45,
                                      Ssp_cam099_ms45 = (DateTime)sptablnsres4505.ssp_cam099_ms45,
                                      Ssp_cam100_ms45 = (DateTime)sptablnsres4505.ssp_cam100_ms45,
                                      Ssp_cam101_ms45 = sptablnsres4505.ssp_cam101_ms45,
                                      Ssp_cam102_ms45 = sptablnsres4505.ssp_cam102_ms45,
                                      Ssp_cam103_ms45 = (DateTime)sptablnsres4505.ssp_cam103_ms45,
                                      Ssp_cam104_ms45 = (int)sptablnsres4505.ssp_cam104_ms45,
                                      Ssp_cam105_ms45 = (DateTime)sptablnsres4505.ssp_cam105_ms45,
                                      Ssp_cam106_ms45 = (DateTime)sptablnsres4505.ssp_cam106_ms45,
                                      Ssp_cam107_ms45 = (int)sptablnsres4505.ssp_cam107_ms45,
                                      Ssp_cam108_ms45 = (DateTime)sptablnsres4505.ssp_cam108_ms45,
                                      Ssp_cam109_ms45 = (int)sptablnsres4505.ssp_cam109_ms45,
                                      Ssp_cam110_ms45 = (DateTime)sptablnsres4505.ssp_cam110_ms45,
                                      Ssp_cam111_ms45 = (DateTime)sptablnsres4505.ssp_cam111_ms45,
                                      Ssp_cam112_ms45 = (DateTime)sptablnsres4505.ssp_cam112_ms45,
                                      Ssp_cam113_ms45 = sptablnsres4505.ssp_cam113_ms45,
                                      Ssp_cam114_ms45 = sptablnsres4505.ssp_cam114_ms45,
                                      Ssp_cam115_ms45 = sptablnsres4505.ssp_cam115_ms45,
                                      Ssp_cam116_ms45 = sptablnsres4505.ssp_cam116_ms45,
                                      Ssp_cam117_ms45 = sptablnsres4505.ssp_cam117_ms45,
                                      Ssp_cam118_ms45 = (DateTime)sptablnsres4505.ssp_cam118_ms45,
                                      Ssp_desper_peri = peri.ssp_desper_peri,
                                      Ssp_desocu_ciuo = ciuo.ssp_desocu_ciuo,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
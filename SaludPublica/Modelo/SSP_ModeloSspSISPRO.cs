//- MARMOTA-GENCODE: VERSION 2.0 - 02/07/2013 09:45:42 PM
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
    /// Descripcion para la Vista de  la tabla: sptablamssispro
    /// </summary>
    public class ModeloSspSISPRO : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _sia_idesec_usua;
        private String _sia_nroide_usua;
        private String _sia_codeps_teps;
        private String _ssp_cam000_spro;
        private String _ssp_cam001_spro;
        private String _ssp_cam002_spro;
        private String _ssp_cam003_spro;
        private String _ssp_cam004_spro;
        private String _ssp_cam005_spro;
        private String _ssp_cam006_spro;
        private String _ssp_cam007_spro;
        private String _ssp_cam008_spro;
        private DateTime _ssp_cam009_spro;
        private String _ssp_cam010_spro;
        private String _ssp_cam011_spro;
        private String _ssp_codocu_ciuo;
        private String _ssp_cam013_spro;
        private String _ssp_cam014_spro;
        private String _ssp_cam015_spro;
        private String _ssp_cam016_spro;
        private String _ssp_cam017_spro;
        private String _ssp_cam018_spro;
        private String _ssp_cam019_spro;
        private String _ssp_cam020_spro;
        private String _ssp_cam021_spro;
        private String _ssp_cam022_spro;
        private String _ssp_cam023_spro;
        private String _ssp_cam024_spro;
        private String _ssp_cam025_spro;
        private String _ssp_cam026_spro;
        private String _ssp_cam027_spro;
        private String _ssp_cam028_spro;
        private DateTime _ssp_cam029_spro;
        private int _ssp_cam030_spro;
        private DateTime _ssp_cam031_spro;
        private int _ssp_cam032_spro;
        private DateTime _ssp_cam033_spro;
        private int _ssp_cam034_spro;
        private String _ssp_cam035_spro;
        private String _ssp_cam036_spro;
        private String _ssp_cam037_spro;
        private String _ssp_cam038_spro;
        private String _ssp_cam039_spro;
        private String _ssp_cam040_spro;
        private String _ssp_cam041_spro;
        private String _ssp_cam042_spro;
        private String _ssp_cam043_spro;
        private String _ssp_cam044_spro;
        private String _ssp_cam045_spro;
        private String _ssp_cam046_spro;
        private String _ssp_cam047_spro;
        private String _ssp_cam048_spro;
        private DateTime _ssp_cam049_spro;
        private DateTime _ssp_cam050_spro;
        private DateTime _ssp_cam051_spro;
        private DateTime _ssp_cam052_spro;
        private DateTime _ssp_cam053_spro;
        private String _ssp_cam054_spro;
        private DateTime _ssp_cam055_spro;
        private DateTime _ssp_cam056_spro;
        private int _ssp_cam057_spro;
        private DateTime _ssp_cam058_spro;
        private String _ssp_cam059_spro;
        private String _ssp_cam060_spro;
        private String _ssp_cam061_spro;
        private DateTime _ssp_cam062_spro;
        private DateTime _ssp_cam063_spro;
        private DateTime _ssp_cam064_spro;
        private DateTime _ssp_cam065_spro;
        private DateTime _ssp_cam066_spro;
        private DateTime _ssp_cam067_spro;
        private DateTime _ssp_cam068_spro;
        private DateTime _ssp_cam069_spro;
        private String _ssp_cam070_spro;
        private String _ssp_cam071_spro;
        private DateTime _ssp_cam072_spro;
        private DateTime _ssp_cam073_spro;
        private int _ssp_cam074_spro;
        private DateTime _ssp_cam075_spro;
        private DateTime _ssp_cam076_spro;
        private String _ssp_cam077_spro;
        private DateTime _ssp_cam078_spro;
        private String _ssp_cam079_spro;
        private DateTime _ssp_cam080_spro;
        private String _ssp_cam081_spro;
        private DateTime _ssp_cam082_spro;
        private String _ssp_cam083_spro;
        private DateTime _ssp_cam084_spro;
        private String _ssp_cam085_spro;
        private String _ssp_cam086_spro;
        private DateTime _ssp_cam087_spro;
        private String _ssp_cam088_spro;
        private String _ssp_cam089_spro;
        private String _ssp_cam090_spro;
        private DateTime _ssp_cam091_spro;
        private String _ssp_cam092_spro;
        private DateTime _ssp_cam093_spro;
        private String _ssp_cam094_spro;
        private String _ssp_cam095_spro;
        private DateTime _ssp_cam096_spro;
        private String _ssp_cam097_spro;
        private String _ssp_cam098_spro;
        private DateTime _ssp_cam099_spro;
        private DateTime _ssp_cam100_spro;
        private String _ssp_cam101_spro;
        private String _ssp_cam102_spro;
        private DateTime _ssp_cam103_spro;
        private int _ssp_cam104_spro;
        private DateTime _ssp_cam105_spro;
        private DateTime _ssp_cam106_spro;
        private int _ssp_cam107_spro;
        private DateTime _ssp_cam108_spro;
        private int _ssp_cam109_spro;
        private DateTime _ssp_cam110_spro;
        private DateTime _ssp_cam111_spro;
        private DateTime _ssp_cam112_spro;
        private String _ssp_cam113_spro;
        private String _ssp_cam114_spro;
        private String _ssp_cam115_spro;
        private String _ssp_cam116_spro;
        private String _ssp_cam117_spro;
        private DateTime _ssp_cam118_spro;
        private int _ssp_consec_spro;
        private String _sia_nomusu_usua;
        private String _sia_deseps_teps;
        private String _ssp_desocu_ciuo;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Sia_idesec_usua: Código único del paciente
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
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
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
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
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
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
        #region Ssp_cam000_spro: 0.Tipo De Registro
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 0.Tipo De Registro</para>
        /// <para>NOMBRE: ssp_cam000_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Tipo De Registro
        /// </para>
        /// </summary>
        public String Ssp_cam000_spro
        {
            get { return _ssp_cam000_spro; }
            set
            {
                if (_ssp_cam000_spro == value) return;
                _ssp_cam000_spro = value;
                OnPropertyChanged("Ssp_cam000_spro");
            }
        }
        #endregion
        #region Ssp_cam001_spro: 1.Consecutivo de Registro
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 1.Consecutivo de Registro</para>
        /// <para>NOMBRE: ssp_cam001_spro (char:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Número consecutivo de registros de detalle dentro del archivo.
        /// Inicia en 1 para el primer registro de detalle y va incrementando
        /// de 1 en 1, hasta el final del archivo.
        /// </para>
        /// </summary>
        public String Ssp_cam001_spro
        {
            get { return _ssp_cam001_spro; }
            set
            {
                if (_ssp_cam001_spro == value) return;
                _ssp_cam001_spro = value;
                OnPropertyChanged("Ssp_cam001_spro");
            }
        }
        #endregion
        #region Ssp_cam002_spro: 2.Código de Habilitación IPS primaria
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 2.Código de Habilitación IPS primaria</para>
        /// <para>NOMBRE: ssp_cam002_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud) Si es desconocido registrar 99
        /// </para>
        /// </summary>
        public String Ssp_cam002_spro
        {
            get { return _ssp_cam002_spro; }
            set
            {
                if (_ssp_cam002_spro == value) return;
                _ssp_cam002_spro = value;
                OnPropertyChanged("Ssp_cam002_spro");
            }
        }
        #endregion
        #region Ssp_cam003_spro: 3.Tipo de identificación del usuario
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 3.Tipo de identificación del usuario</para>
        /// <para>NOMBRE: ssp_cam003_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo
        /// para menores con 2 meses o menos de nacidos calculando entre
        /// la fecha de nacimiento y la fecha de corte del reporte.
        /// </para>
        /// </summary>
        public String Ssp_cam003_spro
        {
            get { return _ssp_cam003_spro; }
            set
            {
                if (_ssp_cam003_spro == value) return;
                _ssp_cam003_spro = value;
                OnPropertyChanged("Ssp_cam003_spro");
            }
        }
        #endregion
        #region Ssp_cam004_spro: 4.Numero de identificación del usuario
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 4.Numero de identificación del usuario</para>
        /// <para>NOMBRE: ssp_cam004_spro (char:18)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Número del documento de identificación, de acuerdo con el tipo
        /// de identificación del campo anterior.
        /// </para>
        /// </summary>
        public String Ssp_cam004_spro
        {
            get { return _ssp_cam004_spro; }
            set
            {
                if (_ssp_cam004_spro == value) return;
                _ssp_cam004_spro = value;
                OnPropertyChanged("Ssp_cam004_spro");
            }
        }
        #endregion
        #region Ssp_cam005_spro: 5.Primer apellido del usuario
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 5.Primer apellido del usuario</para>
        /// <para>NOMBRE: ssp_cam005_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public String Ssp_cam005_spro
        {
            get { return _ssp_cam005_spro; }
            set
            {
                if (_ssp_cam005_spro == value) return;
                _ssp_cam005_spro = value;
                OnPropertyChanged("Ssp_cam005_spro");
            }
        }
        #endregion
        #region Ssp_cam006_spro: 6.Segundo apellido del usuario
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 6.Segundo apellido del usuario</para>
        /// <para>NOMBRE: ssp_cam006_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tenga en cuenta el numeral 1. En caso que el usuario no tenga
        /// segundo apellido o no se tenga este dato Registre NONE, en
        /// mayúscula sostenida.
        /// </para>
        /// </summary>
        public String Ssp_cam006_spro
        {
            get { return _ssp_cam006_spro; }
            set
            {
                if (_ssp_cam006_spro == value) return;
                _ssp_cam006_spro = value;
                OnPropertyChanged("Ssp_cam006_spro");
            }
        }
        #endregion
        #region Ssp_cam007_spro: 7.Primer nombre del usuario
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 7.Primer nombre del usuario</para>
        /// <para>NOMBRE: ssp_cam007_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public String Ssp_cam007_spro
        {
            get { return _ssp_cam007_spro; }
            set
            {
                if (_ssp_cam007_spro == value) return;
                _ssp_cam007_spro = value;
                OnPropertyChanged("Ssp_cam007_spro");
            }
        }
        #endregion
        #region Ssp_cam008_spro: 8.Segundo nombre del usuario
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 8.Segundo nombre del usuario</para>
        /// <para>NOMBRE: ssp_cam008_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Segundo nombre del usuario. Tenga en cuenta el numeral 1. En
        /// caso que el usuario no tenga segundo apellido o no se tenga
        /// este dato Registre NONE, en mayúscula sostenida.
        /// </para>
        /// </summary>
        public String Ssp_cam008_spro
        {
            get { return _ssp_cam008_spro; }
            set
            {
                if (_ssp_cam008_spro == value) return;
                _ssp_cam008_spro = value;
                OnPropertyChanged("Ssp_cam008_spro");
            }
        }
        #endregion
        #region Ssp_cam009_spro: 9.Fecha de Nacimiento
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 9.Fecha de Nacimiento</para>
        /// <para>NOMBRE: ssp_cam009_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Fecha de Nacimiento. AAAA-MM-DD
        /// </para>
        /// </summary>
        public DateTime Ssp_cam009_spro
        {
            get { return _ssp_cam009_spro; }
            set
            {
                if (_ssp_cam009_spro == value) return;
                _ssp_cam009_spro = value;
                OnPropertyChanged("Ssp_cam009_spro");
            }
        }
        #endregion
        #region Ssp_cam010_spro: 10.Sexo
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 10.Sexo</para>
        /// <para>NOMBRE: ssp_cam010_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Sexo. M - Masculino F - Femenino
        /// </para>
        /// </summary>
        public String Ssp_cam010_spro
        {
            get { return _ssp_cam010_spro; }
            set
            {
                if (_ssp_cam010_spro == value) return;
                _ssp_cam010_spro = value;
                OnPropertyChanged("Ssp_cam010_spro");
            }
        }
        #endregion
        #region Ssp_cam011_spro: 11.Codigo pertenencia étnica
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 11.Codigo pertenencia étnica</para>
        /// <para>NOMBRE: ssp_cam011_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo pertenencia etnica. Registre según lo reporte el usuario:
        /// 1-Indígena 2-ROM (gitano)3-Raizal etc
        /// </para>
        /// </summary>
        public String Ssp_cam011_spro
        {
            get { return _ssp_cam011_spro; }
            set
            {
                if (_ssp_cam011_spro == value) return;
                _ssp_cam011_spro = value;
                OnPropertyChanged("Ssp_cam011_spro");
            }
        }
        #endregion
        #region Ssp_codocu_ciuo: 12.Codigo de ocupación
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
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
        #region Ssp_cam013_spro: 13.Codigo de nivel educativo
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 13.Codigo de nivel educativo</para>
        /// <para>NOMBRE: ssp_cam013_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Registre según lo reporte el usuario: 1- No Definido 2- Preescolar
        /// 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc
        /// </para>
        /// </summary>
        public String Ssp_cam013_spro
        {
            get { return _ssp_cam013_spro; }
            set
            {
                if (_ssp_cam013_spro == value) return;
                _ssp_cam013_spro = value;
                OnPropertyChanged("Ssp_cam013_spro");
            }
        }
        #endregion
        #region Ssp_cam014_spro: 14.Gestacion
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 14.Gestacion</para>
        /// <para>NOMBRE: ssp_cam014_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam014_spro
        {
            get { return _ssp_cam014_spro; }
            set
            {
                if (_ssp_cam014_spro == value) return;
                _ssp_cam014_spro = value;
                OnPropertyChanged("Ssp_cam014_spro");
            }
        }
        #endregion
        #region Ssp_cam015_spro: 15.Sifilis Gestacional o congénita
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 15.Sifilis Gestacional o congénita</para>
        /// <para>NOMBRE: ssp_cam015_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// 0- No 1- Si es mujer con sífilis gestacional 2- Si es recién
        /// nacido con sífilis congénita 3- No aplica 4- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam015_spro
        {
            get { return _ssp_cam015_spro; }
            set
            {
                if (_ssp_cam015_spro == value) return;
                _ssp_cam015_spro = value;
                OnPropertyChanged("Ssp_cam015_spro");
            }
        }
        #endregion
        #region Ssp_cam016_spro: 16.Hipertension Inducida por la Gestació
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 16.Hipertension Inducida por la Gestació</para>
        /// <para>NOMBRE: ssp_cam016_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Hipertension Inducida por la Gestacion 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam016_spro
        {
            get { return _ssp_cam016_spro; }
            set
            {
                if (_ssp_cam016_spro == value) return;
                _ssp_cam016_spro = value;
                OnPropertyChanged("Ssp_cam016_spro");
            }
        }
        #endregion
        #region Ssp_cam017_spro: 17.Hipotiroidismo Congénito
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 17.Hipotiroidismo Congénito</para>
        /// <para>NOMBRE: ssp_cam017_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Hipotiroidismo Congenito 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam017_spro
        {
            get { return _ssp_cam017_spro; }
            set
            {
                if (_ssp_cam017_spro == value) return;
                _ssp_cam017_spro = value;
                OnPropertyChanged("Ssp_cam017_spro");
            }
        }
        #endregion
        #region Ssp_cam018_spro: 18.Sintomatico Respiratorio
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 18.Sintomatico Respiratorio</para>
        /// <para>NOMBRE: ssp_cam018_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Sintomatico Respiratorio 0- No 1- Si 2- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam018_spro
        {
            get { return _ssp_cam018_spro; }
            set
            {
                if (_ssp_cam018_spro == value) return;
                _ssp_cam018_spro = value;
                OnPropertyChanged("Ssp_cam018_spro");
            }
        }
        #endregion
        #region Ssp_cam019_spro: 19.Tuberculosis Multidrogoresistente
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 19.Tuberculosis Multidrogoresistente</para>
        /// <para>NOMBRE: ssp_cam019_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Tuberculosis Multidrogoresistente 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam019_spro
        {
            get { return _ssp_cam019_spro; }
            set
            {
                if (_ssp_cam019_spro == value) return;
                _ssp_cam019_spro = value;
                OnPropertyChanged("Ssp_cam019_spro");
            }
        }
        #endregion
        #region Ssp_cam020_spro: 20.Lepra
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 20.Lepra</para>
        /// <para>NOMBRE: ssp_cam020_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Lepra 0- No 1- Pausibacilar 2- Multibacilar 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam020_spro
        {
            get { return _ssp_cam020_spro; }
            set
            {
                if (_ssp_cam020_spro == value) return;
                _ssp_cam020_spro = value;
                OnPropertyChanged("Ssp_cam020_spro");
            }
        }
        #endregion
        #region Ssp_cam021_spro: 21.Obesidad o Desnutrición Proteico Caló
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 21.Obesidad o Desnutrición Proteico Caló</para>
        /// <para>NOMBRE: ssp_cam021_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Obesidad o Desnutricion Proteico Calorica 0- No 1- Si es Obesidad
        /// 2- Si es Desnutrición Proteico Calórica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam021_spro
        {
            get { return _ssp_cam021_spro; }
            set
            {
                if (_ssp_cam021_spro == value) return;
                _ssp_cam021_spro = value;
                OnPropertyChanged("Ssp_cam021_spro");
            }
        }
        #endregion
        #region Ssp_cam022_spro: 22.Mujer Victima de Maltrato
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 22.Mujer Victima de Maltrato</para>
        /// <para>NOMBRE: ssp_cam022_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Mujer Victima de Maltrato 0- No 1- Si es Mujer víctima del
        /// maltrato 2- Si es Menor víctima del maltrato 3- No aplica 4-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam022_spro
        {
            get { return _ssp_cam022_spro; }
            set
            {
                if (_ssp_cam022_spro == value) return;
                _ssp_cam022_spro = value;
                OnPropertyChanged("Ssp_cam022_spro");
            }
        }
        #endregion
        #region Ssp_cam023_spro: 23.Victima de Violencia Sexual
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 23.Victima de Violencia Sexual</para>
        /// <para>NOMBRE: ssp_cam023_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Victima de Violencia Sexual 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam023_spro
        {
            get { return _ssp_cam023_spro; }
            set
            {
                if (_ssp_cam023_spro == value) return;
                _ssp_cam023_spro = value;
                OnPropertyChanged("Ssp_cam023_spro");
            }
        }
        #endregion
        #region Ssp_cam024_spro: 24.Infecciones de Trasmisión Sexual
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 24.Infecciones de Trasmisión Sexual</para>
        /// <para>NOMBRE: ssp_cam024_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Infecciones de Trasmision Sexual 0- No 1- Si 2- No aplica 3-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam024_spro
        {
            get { return _ssp_cam024_spro; }
            set
            {
                if (_ssp_cam024_spro == value) return;
                _ssp_cam024_spro = value;
                OnPropertyChanged("Ssp_cam024_spro");
            }
        }
        #endregion
        #region Ssp_cam025_spro: 25.Enfermedad Mental
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 25.Enfermedad Mental</para>
        /// <para>NOMBRE: ssp_cam025_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Enfermedad Mental 0- No 1- Si el diagnóstico es Ansiedad 2-
        /// Si el diagnóstico es Depresión 3- Si el diagnóstico es esquizofrenia
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam025_spro
        {
            get { return _ssp_cam025_spro; }
            set
            {
                if (_ssp_cam025_spro == value) return;
                _ssp_cam025_spro = value;
                OnPropertyChanged("Ssp_cam025_spro");
            }
        }
        #endregion
        #region Ssp_cam026_spro: 26.Cancer de Cérvix
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 26.Cancer de Cérvix</para>
        /// <para>NOMBRE: ssp_cam026_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Cancer de Cervix 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam026_spro
        {
            get { return _ssp_cam026_spro; }
            set
            {
                if (_ssp_cam026_spro == value) return;
                _ssp_cam026_spro = value;
                OnPropertyChanged("Ssp_cam026_spro");
            }
        }
        #endregion
        #region Ssp_cam027_spro: 27.Cancer de Seno
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 27.Cancer de Seno</para>
        /// <para>NOMBRE: ssp_cam027_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Cancer de Seno 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam027_spro
        {
            get { return _ssp_cam027_spro; }
            set
            {
                if (_ssp_cam027_spro == value) return;
                _ssp_cam027_spro = value;
                OnPropertyChanged("Ssp_cam027_spro");
            }
        }
        #endregion
        #region Ssp_cam028_spro: 28.Fluorosis Dental
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 28.Fluorosis Dental</para>
        /// <para>NOMBRE: ssp_cam028_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Fluorosis Dental 0- No 1- Si 2- No aplica 3- Riego no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam028_spro
        {
            get { return _ssp_cam028_spro; }
            set
            {
                if (_ssp_cam028_spro == value) return;
                _ssp_cam028_spro = value;
                OnPropertyChanged("Ssp_cam028_spro");
            }
        }
        #endregion
        #region Ssp_cam029_spro: 29.Fecha del Peso
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 29.Fecha del Peso</para>
        /// <para>NOMBRE: ssp_cam029_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam029_spro
        {
            get { return _ssp_cam029_spro; }
            set
            {
                if (_ssp_cam029_spro == value) return;
                _ssp_cam029_spro = value;
                OnPropertyChanged("Ssp_cam029_spro");
            }
        }
        #endregion
        #region Ssp_cam030_spro: 30.Peso en Kilogramos
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 30.Peso en Kilogramos</para>
        /// <para>NOMBRE: ssp_cam030_spro (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Peso en Kilogramos Se registra el dato obtenido de la medición.
        /// Si no se toma registrar 999
        /// </para>
        /// </summary>
        public int Ssp_cam030_spro
        {
            get { return _ssp_cam030_spro; }
            set
            {
                if (_ssp_cam030_spro == value) return;
                _ssp_cam030_spro = value;
                OnPropertyChanged("Ssp_cam030_spro");
            }
        }
        #endregion
        #region Ssp_cam031_spro: 31.Fecha de la Talla
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 31.Fecha de la Talla</para>
        /// <para>NOMBRE: ssp_cam031_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam031_spro
        {
            get { return _ssp_cam031_spro; }
            set
            {
                if (_ssp_cam031_spro == value) return;
                _ssp_cam031_spro = value;
                OnPropertyChanged("Ssp_cam031_spro");
            }
        }
        #endregion
        #region Ssp_cam032_spro: 32.Talla en Centímetros
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 32.Talla en Centímetros</para>
        /// <para>NOMBRE: ssp_cam032_spro (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato obtenido de la medición. Si no se toma
        /// registrar 999
        /// </para>
        /// </summary>
        public int Ssp_cam032_spro
        {
            get { return _ssp_cam032_spro; }
            set
            {
                if (_ssp_cam032_spro == value) return;
                _ssp_cam032_spro = value;
                OnPropertyChanged("Ssp_cam032_spro");
            }
        }
        #endregion
        #region Ssp_cam033_spro: 33.Fecha Probable de Parto
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 33.Fecha Probable de Parto</para>
        /// <para>NOMBRE: ssp_cam033_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam033_spro
        {
            get { return _ssp_cam033_spro; }
            set
            {
                if (_ssp_cam033_spro == value) return;
                _ssp_cam033_spro = value;
                OnPropertyChanged("Ssp_cam033_spro");
            }
        }
        #endregion
        #region Ssp_cam034_spro: 34.Edad Gestacional al Nacer
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 34.Edad Gestacional al Nacer</para>
        /// <para>NOMBRE: ssp_cam034_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato de la edad gestacional en semanas. Si no
        /// tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public int Ssp_cam034_spro
        {
            get { return _ssp_cam034_spro; }
            set
            {
                if (_ssp_cam034_spro == value) return;
                _ssp_cam034_spro = value;
                OnPropertyChanged("Ssp_cam034_spro");
            }
        }
        #endregion
        #region Ssp_cam035_spro: 35.BCG
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 35.BCG</para>
        /// <para>NOMBRE: ssp_cam035_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// BCG Registre el dato de la última dosis aplicada así: 0- RN
        /// 1- Otra Dosis 2- Sin dato 3- No se administra por una Tradición
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam035_spro
        {
            get { return _ssp_cam035_spro; }
            set
            {
                if (_ssp_cam035_spro == value) return;
                _ssp_cam035_spro = value;
                OnPropertyChanged("Ssp_cam035_spro");
            }
        }
        #endregion
        #region Ssp_cam036_spro: 36.Hepatitis B menores de 1 año
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 36.Hepatitis B menores de 1 año</para>
        /// <para>NOMBRE: ssp_cam036_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Hepatitis B menores de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- RN 1- Primera Dosis 2- Segunda Dosis
        /// 3- Tercera Dosis ETC
        /// </para>
        /// </summary>
        public String Ssp_cam036_spro
        {
            get { return _ssp_cam036_spro; }
            set
            {
                if (_ssp_cam036_spro == value) return;
                _ssp_cam036_spro = value;
                OnPropertyChanged("Ssp_cam036_spro");
            }
        }
        #endregion
        #region Ssp_cam037_spro: 37.Pentavalente
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 37.Pentavalente</para>
        /// <para>NOMBRE: ssp_cam037_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Pentavalente Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Sin dato
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam037_spro
        {
            get { return _ssp_cam037_spro; }
            set
            {
                if (_ssp_cam037_spro == value) return;
                _ssp_cam037_spro = value;
                OnPropertyChanged("Ssp_cam037_spro");
            }
        }
        #endregion
        #region Ssp_cam038_spro: 38.Polio
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 38.Polio</para>
        /// <para>NOMBRE: ssp_cam038_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Polio Registre el dato de la última dosis aplicada así: 0-
        /// Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Primer Refuerzo
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam038_spro
        {
            get { return _ssp_cam038_spro; }
            set
            {
                if (_ssp_cam038_spro == value) return;
                _ssp_cam038_spro = value;
                OnPropertyChanged("Ssp_cam038_spro");
            }
        }
        #endregion
        #region Ssp_cam039_spro: 39.DPT menores de 5 años
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 39.DPT menores de 5 años</para>
        /// <para>NOMBRE: ssp_cam039_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// DPT menores de 5 años Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3-
        /// Primer Refuerzo ETC
        /// </para>
        /// </summary>
        public String Ssp_cam039_spro
        {
            get { return _ssp_cam039_spro; }
            set
            {
                if (_ssp_cam039_spro == value) return;
                _ssp_cam039_spro = value;
                OnPropertyChanged("Ssp_cam039_spro");
            }
        }
        #endregion
        #region Ssp_cam040_spro: 40.Rotavirus
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 40.Rotavirus</para>
        /// <para>NOMBRE: ssp_cam040_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Rotavirus Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Sin dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam040_spro
        {
            get { return _ssp_cam040_spro; }
            set
            {
                if (_ssp_cam040_spro == value) return;
                _ssp_cam040_spro = value;
                OnPropertyChanged("Ssp_cam040_spro");
            }
        }
        #endregion
        #region Ssp_cam041_spro: 41.Neumococo
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 41.Neumococo</para>
        /// <para>NOMBRE: ssp_cam041_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Neumococo Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin
        /// dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam041_spro
        {
            get { return _ssp_cam041_spro; }
            set
            {
                if (_ssp_cam041_spro == value) return;
                _ssp_cam041_spro = value;
                OnPropertyChanged("Ssp_cam041_spro");
            }
        }
        #endregion
        #region Ssp_cam042_spro: 42.Influenza Niños
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 42.Influenza Niños</para>
        /// <para>NOMBRE: ssp_cam042_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Influenza Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC
        /// </para>
        /// </summary>
        public String Ssp_cam042_spro
        {
            get { return _ssp_cam042_spro; }
            set
            {
                if (_ssp_cam042_spro == value) return;
                _ssp_cam042_spro = value;
                OnPropertyChanged("Ssp_cam042_spro");
            }
        }
        #endregion
        #region Ssp_cam043_spro: 43.Fiebre Amarilla niños de 1 año
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 43.Fiebre Amarilla niños de 1 año</para>
        /// <para>NOMBRE: ssp_cam043_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Fiebre Amarilla niños de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra
        /// por una Tradición ETC
        /// </para>
        /// </summary>
        public String Ssp_cam043_spro
        {
            get { return _ssp_cam043_spro; }
            set
            {
                if (_ssp_cam043_spro == value) return;
                _ssp_cam043_spro = value;
                OnPropertyChanged("Ssp_cam043_spro");
            }
        }
        #endregion
        #region Ssp_cam044_spro: 44.Hepatitis A
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 44.Hepatitis A</para>
        /// <para>NOMBRE: ssp_cam044_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Hepatitis A Registre el dato de la última dosis aplicada así:
        /// 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición
        /// 3- No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public String Ssp_cam044_spro
        {
            get { return _ssp_cam044_spro; }
            set
            {
                if (_ssp_cam044_spro == value) return;
                _ssp_cam044_spro = value;
                OnPropertyChanged("Ssp_cam044_spro");
            }
        }
        #endregion
        #region Ssp_cam045_spro: 45.Triple Viral Niños
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 45.Triple Viral Niños</para>
        /// <para>NOMBRE: ssp_cam045_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Triple Viral Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No
        /// se administra por una Tradición 4- No se administra por una
        /// Condición de Salud ETC
        /// </para>
        /// </summary>
        public String Ssp_cam045_spro
        {
            get { return _ssp_cam045_spro; }
            set
            {
                if (_ssp_cam045_spro == value) return;
                _ssp_cam045_spro = value;
                OnPropertyChanged("Ssp_cam045_spro");
            }
        }
        #endregion
        #region Ssp_cam046_spro: 46.Virus del Papiloma Humano (VPH)
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 46.Virus del Papiloma Humano (VPH)</para>
        /// <para>NOMBRE: ssp_cam046_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Virus del Papiloma Humano (VPH) Registre el dato de la última
        /// dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera
        /// Dosis 3- Sin dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam046_spro
        {
            get { return _ssp_cam046_spro; }
            set
            {
                if (_ssp_cam046_spro == value) return;
                _ssp_cam046_spro = value;
                OnPropertyChanged("Ssp_cam046_spro");
            }
        }
        #endregion
        #region Ssp_cam047_spro: 47.TD o TT Mujeres en Edad Fértil 15 a 4
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 47.TD o TT Mujeres en Edad Fértil 15 a 4</para>
        /// <para>NOMBRE: ssp_cam047_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato
        /// de la última dosis aplicada así: 0- Primera Dosis 1- Segunda
        /// Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC
        /// </para>
        /// </summary>
        public String Ssp_cam047_spro
        {
            get { return _ssp_cam047_spro; }
            set
            {
                if (_ssp_cam047_spro == value) return;
                _ssp_cam047_spro = value;
                OnPropertyChanged("Ssp_cam047_spro");
            }
        }
        #endregion
        #region Ssp_cam048_spro: 48.Control de Placa Bacteriana
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 48.Control de Placa Bacteriana</para>
        /// <para>NOMBRE: ssp_cam048_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Control de Placa Bacteriana 0- No se realiza por una Tradición
        /// 1- No se realiza por una Condición de Salud 2- No se realiza
        /// por Negación del usuario
        /// </para>
        /// </summary>
        public String Ssp_cam048_spro
        {
            get { return _ssp_cam048_spro; }
            set
            {
                if (_ssp_cam048_spro == value) return;
                _ssp_cam048_spro = value;
                OnPropertyChanged("Ssp_cam048_spro");
            }
        }
        #endregion
        #region Ssp_cam049_spro: 49.Fecha atención parto o cesárea
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 49.Fecha atención parto o cesárea</para>
        /// <para>NOMBRE: ssp_cam049_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam049_spro
        {
            get { return _ssp_cam049_spro; }
            set
            {
                if (_ssp_cam049_spro == value) return;
                _ssp_cam049_spro = value;
                OnPropertyChanged("Ssp_cam049_spro");
            }
        }
        #endregion
        #region Ssp_cam050_spro: 50.Fecha salida de la atención del parto
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 50.Fecha salida de la atención del parto</para>
        /// <para>NOMBRE: ssp_cam050_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Fecha salida de la atencion del parto o cesarea AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam050_spro
        {
            get { return _ssp_cam050_spro; }
            set
            {
                if (_ssp_cam050_spro == value) return;
                _ssp_cam050_spro = value;
                OnPropertyChanged("Ssp_cam050_spro");
            }
        }
        #endregion
        #region Ssp_cam051_spro: 51.Fecha de consejería en Lactancia Mate
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 51.Fecha de consejería en Lactancia Mate</para>
        /// <para>NOMBRE: ssp_cam051_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no se realiza por una
        /// Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam051_spro
        {
            get { return _ssp_cam051_spro; }
            set
            {
                if (_ssp_cam051_spro == value) return;
                _ssp_cam051_spro = value;
                OnPropertyChanged("Ssp_cam051_spro");
            }
        }
        #endregion
        #region Ssp_cam052_spro: 52.Control Recién Nacido
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 52.Control Recién Nacido</para>
        /// <para>NOMBRE: ssp_cam052_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam052_spro
        {
            get { return _ssp_cam052_spro; }
            set
            {
                if (_ssp_cam052_spro == value) return;
                _ssp_cam052_spro = value;
                OnPropertyChanged("Ssp_cam052_spro");
            }
        }
        #endregion
        #region Ssp_cam053_spro: 53.Planificacion Familiar Primera vez
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 53.Planificacion Familiar Primera vez</para>
        /// <para>NOMBRE: ssp_cam053_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam053_spro
        {
            get { return _ssp_cam053_spro; }
            set
            {
                if (_ssp_cam053_spro == value) return;
                _ssp_cam053_spro = value;
                OnPropertyChanged("Ssp_cam053_spro");
            }
        }
        #endregion
        #region Ssp_cam054_spro: 54.Suministro de Método Anticonceptivo
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 54.Suministro de Método Anticonceptivo</para>
        /// <para>NOMBRE: ssp_cam054_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino
        /// 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico
        /// 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam054_spro
        {
            get { return _ssp_cam054_spro; }
            set
            {
                if (_ssp_cam054_spro == value) return;
                _ssp_cam054_spro = value;
                OnPropertyChanged("Ssp_cam054_spro");
            }
        }
        #endregion
        #region Ssp_cam055_spro: 55.Fecha Suministro de Método Anticoncep
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 55.Fecha Suministro de Método Anticoncep</para>
        /// <para>NOMBRE: ssp_cam055_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam055_spro
        {
            get { return _ssp_cam055_spro; }
            set
            {
                if (_ssp_cam055_spro == value) return;
                _ssp_cam055_spro = value;
                OnPropertyChanged("Ssp_cam055_spro");
            }
        }
        #endregion
        #region Ssp_cam056_spro: 56.Control Prenatal de Primera vez
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 56.Control Prenatal de Primera vez</para>
        /// <para>NOMBRE: ssp_cam056_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam056_spro
        {
            get { return _ssp_cam056_spro; }
            set
            {
                if (_ssp_cam056_spro == value) return;
                _ssp_cam056_spro = value;
                OnPropertyChanged("Ssp_cam056_spro");
            }
        }
        #endregion
        #region Ssp_cam057_spro: 57.Control Prenatal
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 57.Control Prenatal</para>
        /// <para>NOMBRE: ssp_cam057_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal Registre el número de controles que ha tenido
        /// en el último período de reporte durante la gestación actual,
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int Ssp_cam057_spro
        {
            get { return _ssp_cam057_spro; }
            set
            {
                if (_ssp_cam057_spro == value) return;
                _ssp_cam057_spro = value;
                OnPropertyChanged("Ssp_cam057_spro");
            }
        }
        #endregion
        #region Ssp_cam058_spro: 58.ultimo Control Prenatal
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 58.ultimo Control Prenatal</para>
        /// <para>NOMBRE: ssp_cam058_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam058_spro
        {
            get { return _ssp_cam058_spro; }
            set
            {
                if (_ssp_cam058_spro == value) return;
                _ssp_cam058_spro = value;
                OnPropertyChanged("Ssp_cam058_spro");
            }
        }
        #endregion
        #region Ssp_cam059_spro: 59.Suministro de acido Fólico en el ulti
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 59.Suministro de acido Fólico en el ulti</para>
        /// <para>NOMBRE: ssp_cam059_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación de
        /// la usuaria 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam059_spro
        {
            get { return _ssp_cam059_spro; }
            set
            {
                if (_ssp_cam059_spro == value) return;
                _ssp_cam059_spro = value;
                OnPropertyChanged("Ssp_cam059_spro");
            }
        }
        #endregion
        #region Ssp_cam060_spro: 60.Suministro de Sulfato Ferroso en el u
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 60.Suministro de Sulfato Ferroso en el u</para>
        /// <para>NOMBRE: ssp_cam060_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam060_spro
        {
            get { return _ssp_cam060_spro; }
            set
            {
                if (_ssp_cam060_spro == value) return;
                _ssp_cam060_spro = value;
                OnPropertyChanged("Ssp_cam060_spro");
            }
        }
        #endregion
        #region Ssp_cam061_spro: 61.Suministro de Carbonato de Calcio en
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 61.Suministro de Carbonato de Calcio en</para>
        /// <para>NOMBRE: ssp_cam061_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam061_spro
        {
            get { return _ssp_cam061_spro; }
            set
            {
                if (_ssp_cam061_spro == value) return;
                _ssp_cam061_spro = value;
                OnPropertyChanged("Ssp_cam061_spro");
            }
        }
        #endregion
        #region Ssp_cam062_spro: 62.Valoracion de la Agudeza Visual
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 62.Valoracion de la Agudeza Visual</para>
        /// <para>NOMBRE: ssp_cam062_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no
        /// se realiza por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam062_spro
        {
            get { return _ssp_cam062_spro; }
            set
            {
                if (_ssp_cam062_spro == value) return;
                _ssp_cam062_spro = value;
                OnPropertyChanged("Ssp_cam062_spro");
            }
        }
        #endregion
        #region Ssp_cam063_spro: 63.Consulta por Oftalmología
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 63.Consulta por Oftalmología</para>
        /// <para>NOMBRE: ssp_cam063_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        /// Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam063_spro
        {
            get { return _ssp_cam063_spro; }
            set
            {
                if (_ssp_cam063_spro == value) return;
                _ssp_cam063_spro = value;
                OnPropertyChanged("Ssp_cam063_spro");
            }
        }
        #endregion
        #region Ssp_cam064_spro: 64.Fecha Diagnostico Desnutrición Protei
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 64.Fecha Diagnostico Desnutrición Protei</para>
        /// <para>NOMBRE: ssp_cam064_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam064_spro
        {
            get { return _ssp_cam064_spro; }
            set
            {
                if (_ssp_cam064_spro == value) return;
                _ssp_cam064_spro = value;
                OnPropertyChanged("Ssp_cam064_spro");
            }
        }
        #endregion
        #region Ssp_cam065_spro: 65.Consulta Mujer o Menor Victima del Ma
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 65.Consulta Mujer o Menor Victima del Ma</para>
        /// <para>NOMBRE: ssp_cam065_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam065_spro
        {
            get { return _ssp_cam065_spro; }
            set
            {
                if (_ssp_cam065_spro == value) return;
                _ssp_cam065_spro = value;
                OnPropertyChanged("Ssp_cam065_spro");
            }
        }
        #endregion
        #region Ssp_cam066_spro: 66.Consulta Victimas de Violencia Sexual
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 66.Consulta Victimas de Violencia Sexual</para>
        /// <para>NOMBRE: ssp_cam066_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam066_spro
        {
            get { return _ssp_cam066_spro; }
            set
            {
                if (_ssp_cam066_spro == value) return;
                _ssp_cam066_spro = value;
                OnPropertyChanged("Ssp_cam066_spro");
            }
        }
        #endregion
        #region Ssp_cam067_spro: 67.Consulta Nutrición
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 67.Consulta Nutrición</para>
        /// <para>NOMBRE: ssp_cam067_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam067_spro
        {
            get { return _ssp_cam067_spro; }
            set
            {
                if (_ssp_cam067_spro == value) return;
                _ssp_cam067_spro = value;
                OnPropertyChanged("Ssp_cam067_spro");
            }
        }
        #endregion
        #region Ssp_cam068_spro: 68.Consulta de Psicología
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 68.Consulta de Psicología</para>
        /// <para>NOMBRE: ssp_cam068_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam068_spro
        {
            get { return _ssp_cam068_spro; }
            set
            {
                if (_ssp_cam068_spro == value) return;
                _ssp_cam068_spro = value;
                OnPropertyChanged("Ssp_cam068_spro");
            }
        }
        #endregion
        #region Ssp_cam069_spro: 69.Consulta de Crecimiento y Desarrollo
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 69.Consulta de Crecimiento y Desarrollo</para>
        /// <para>NOMBRE: ssp_cam069_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam069_spro
        {
            get { return _ssp_cam069_spro; }
            set
            {
                if (_ssp_cam069_spro == value) return;
                _ssp_cam069_spro = value;
                OnPropertyChanged("Ssp_cam069_spro");
            }
        }
        #endregion
        #region Ssp_cam070_spro: 70.Suministro de Sulfato Ferroso en la u
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 70.Suministro de Sulfato Ferroso en la u</para>
        /// <para>NOMBRE: ssp_cam070_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam070_spro
        {
            get { return _ssp_cam070_spro; }
            set
            {
                if (_ssp_cam070_spro == value) return;
                _ssp_cam070_spro = value;
                OnPropertyChanged("Ssp_cam070_spro");
            }
        }
        #endregion
        #region Ssp_cam071_spro: 71.Suministro de Vitamina A en la ultima
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 71.Suministro de Vitamina A en la ultima</para>
        /// <para>NOMBRE: ssp_cam071_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam071_spro
        {
            get { return _ssp_cam071_spro; }
            set
            {
                if (_ssp_cam071_spro == value) return;
                _ssp_cam071_spro = value;
                OnPropertyChanged("Ssp_cam071_spro");
            }
        }
        #endregion
        #region Ssp_cam072_spro: 72.Consulta de Joven Primera vez
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 72.Consulta de Joven Primera vez</para>
        /// <para>NOMBRE: ssp_cam072_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam072_spro
        {
            get { return _ssp_cam072_spro; }
            set
            {
                if (_ssp_cam072_spro == value) return;
                _ssp_cam072_spro = value;
                OnPropertyChanged("Ssp_cam072_spro");
            }
        }
        #endregion
        #region Ssp_cam073_spro: 73.Consulta de Adulto Primera vez
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 73.Consulta de Adulto Primera vez</para>
        /// <para>NOMBRE: ssp_cam073_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam073_spro
        {
            get { return _ssp_cam073_spro; }
            set
            {
                if (_ssp_cam073_spro == value) return;
                _ssp_cam073_spro = value;
                OnPropertyChanged("Ssp_cam073_spro");
            }
        }
        #endregion
        #region Ssp_cam074_spro: 74.Preservativos entregados a pacientes
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 74.Preservativos entregados a pacientes</para>
        /// <para>NOMBRE: ssp_cam074_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Preservativos entregados a pacientes con ITS Registre el número
        /// de Preservativos entregados durante el período de reporte.
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// ETC
        /// </para>
        /// </summary>
        public int Ssp_cam074_spro
        {
            get { return _ssp_cam074_spro; }
            set
            {
                if (_ssp_cam074_spro == value) return;
                _ssp_cam074_spro = value;
                OnPropertyChanged("Ssp_cam074_spro");
            }
        }
        #endregion
        #region Ssp_cam075_spro: 75.Asesoria Pre test Elisa para VIH
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 75.Asesoria Pre test Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam075_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam075_spro
        {
            get { return _ssp_cam075_spro; }
            set
            {
                if (_ssp_cam075_spro == value) return;
                _ssp_cam075_spro = value;
                OnPropertyChanged("Ssp_cam075_spro");
            }
        }
        #endregion
        #region Ssp_cam076_spro: 76.Asesoria Pos test Elisa para VIH
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 76.Asesoria Pos test Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam076_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam076_spro
        {
            get { return _ssp_cam076_spro; }
            set
            {
                if (_ssp_cam076_spro == value) return;
                _ssp_cam076_spro = value;
                OnPropertyChanged("Ssp_cam076_spro");
            }
        }
        #endregion
        #region Ssp_cam077_spro: 77.Paciente con Diagnostico de: Ansiedad
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 77.Paciente con Diagnostico de: Ansiedad</para>
        /// <para>NOMBRE: ssp_cam077_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// 0- No recibió atención por tener una tradición que se lo impide
        /// 1- No recibió atención por una condición de salud 2- No recibió
        /// atención por negación del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam077_spro
        {
            get { return _ssp_cam077_spro; }
            set
            {
                if (_ssp_cam077_spro == value) return;
                _ssp_cam077_spro = value;
                OnPropertyChanged("Ssp_cam077_spro");
            }
        }
        #endregion
        #region Ssp_cam078_spro: 78.Fecha Antígeno de Superficie Hepatiti
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 78.Fecha Antígeno de Superficie Hepatiti</para>
        /// <para>NOMBRE: ssp_cam078_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam078_spro
        {
            get { return _ssp_cam078_spro; }
            set
            {
                if (_ssp_cam078_spro == value) return;
                _ssp_cam078_spro = value;
                OnPropertyChanged("Ssp_cam078_spro");
            }
        }
        #endregion
        #region Ssp_cam079_spro: 79.Resultado Antígeno de Superficie Hepa
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 79.Resultado Antígeno de Superficie Hepa</para>
        /// <para>NOMBRE: ssp_cam079_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Resultado Antigeno de Superficie Hepatitis B en Gestantes 0-
        /// Negativo 1- Positivo 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam079_spro
        {
            get { return _ssp_cam079_spro; }
            set
            {
                if (_ssp_cam079_spro == value) return;
                _ssp_cam079_spro = value;
                OnPropertyChanged("Ssp_cam079_spro");
            }
        }
        #endregion
        #region Ssp_cam080_spro: 80.Fecha Serología para Sífilis
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 80.Fecha Serología para Sífilis</para>
        /// <para>NOMBRE: ssp_cam080_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 84</para>
        /// <para>DESCRIPCION:
        /// Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam080_spro
        {
            get { return _ssp_cam080_spro; }
            set
            {
                if (_ssp_cam080_spro == value) return;
                _ssp_cam080_spro = value;
                OnPropertyChanged("Ssp_cam080_spro");
            }
        }
        #endregion
        #region Ssp_cam081_spro: 81.Resultado Serología para Sífilis
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 81.Resultado Serología para Sífilis</para>
        /// <para>NOMBRE: ssp_cam081_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 85</para>
        /// <para>DESCRIPCION:
        /// Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva
        /// 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam081_spro
        {
            get { return _ssp_cam081_spro; }
            set
            {
                if (_ssp_cam081_spro == value) return;
                _ssp_cam081_spro = value;
                OnPropertyChanged("Ssp_cam081_spro");
            }
        }
        #endregion
        #region Ssp_cam082_spro: 82.Fecha de Toma de Elisa para VIH
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 82.Fecha de Toma de Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam082_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 86</para>
        /// <para>DESCRIPCION:
        /// Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam082_spro
        {
            get { return _ssp_cam082_spro; }
            set
            {
                if (_ssp_cam082_spro == value) return;
                _ssp_cam082_spro = value;
                OnPropertyChanged("Ssp_cam082_spro");
            }
        }
        #endregion
        #region Ssp_cam083_spro: 83.Resultado Elisa para VIH
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 83.Resultado Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam083_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 87</para>
        /// <para>DESCRIPCION:
        /// Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado
        /// 3- Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam083_spro
        {
            get { return _ssp_cam083_spro; }
            set
            {
                if (_ssp_cam083_spro == value) return;
                _ssp_cam083_spro = value;
                OnPropertyChanged("Ssp_cam083_spro");
            }
        }
        #endregion
        #region Ssp_cam084_spro: 84.Fecha TSH Neonatal
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 84.Fecha TSH Neonatal</para>
        /// <para>NOMBRE: ssp_cam084_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 88</para>
        /// <para>DESCRIPCION:
        /// Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam084_spro
        {
            get { return _ssp_cam084_spro; }
            set
            {
                if (_ssp_cam084_spro == value) return;
                _ssp_cam084_spro = value;
                OnPropertyChanged("Ssp_cam084_spro");
            }
        }
        #endregion
        #region Ssp_cam085_spro: 85.Resultado de TSH Neonatal
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 85.Resultado de TSH Neonatal</para>
        /// <para>NOMBRE: ssp_cam085_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 89</para>
        /// <para>DESCRIPCION:
        /// Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato
        /// 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam085_spro
        {
            get { return _ssp_cam085_spro; }
            set
            {
                if (_ssp_cam085_spro == value) return;
                _ssp_cam085_spro = value;
                OnPropertyChanged("Ssp_cam085_spro");
            }
        }
        #endregion
        #region Ssp_cam086_spro: 86.Tamizaje Cáncer de Cuello Uterino
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 86.Tamizaje Cáncer de Cuello Uterino</para>
        /// <para>NOMBRE: ssp_cam086_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 90</para>
        /// <para>DESCRIPCION:
        /// Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public String Ssp_cam086_spro
        {
            get { return _ssp_cam086_spro; }
            set
            {
                if (_ssp_cam086_spro == value) return;
                _ssp_cam086_spro = value;
                OnPropertyChanged("Ssp_cam086_spro");
            }
        }
        #endregion
        #region Ssp_cam087_spro: 87.Citologia Cervico uterina
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 87.Citologia Cervico uterina</para>
        /// <para>NOMBRE: ssp_cam087_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 91</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam087_spro
        {
            get { return _ssp_cam087_spro; }
            set
            {
                if (_ssp_cam087_spro == value) return;
                _ssp_cam087_spro = value;
                OnPropertyChanged("Ssp_cam087_spro");
            }
        }
        #endregion
        #region Ssp_cam088_spro: 88.Citologia Cervico uterina Resultados
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 88.Citologia Cervico uterina Resultados</para>
        /// <para>NOMBRE: ssp_cam088_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 92</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US
        /// (células escamosas atípicas de significado indeterminado) 2-
        /// ASC-H (células escamosas atípicas, que no puede descartar alto
        /// grado) 3- Lesión intraepitelial escamosa de bajo grado ETC
        /// </para>
        /// </summary>
        public String Ssp_cam088_spro
        {
            get { return _ssp_cam088_spro; }
            set
            {
                if (_ssp_cam088_spro == value) return;
                _ssp_cam088_spro = value;
                OnPropertyChanged("Ssp_cam088_spro");
            }
        }
        #endregion
        #region Ssp_cam089_spro: 89.Calidad en la Muestra de Citología Ce
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 89.Calidad en la Muestra de Citología Ce</para>
        /// <para>NOMBRE: ssp_cam089_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 93</para>
        /// <para>DESCRIPCION:
        /// Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria
        /// Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación
        /// Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato
        /// registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam089_spro
        {
            get { return _ssp_cam089_spro; }
            set
            {
                if (_ssp_cam089_spro == value) return;
                _ssp_cam089_spro = value;
                OnPropertyChanged("Ssp_cam089_spro");
            }
        }
        #endregion
        #region Ssp_cam090_spro: 90.Codigo de habilitación IPS donde se t
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 90.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam090_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 94</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Citologia Cervicouterina
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public String Ssp_cam090_spro
        {
            get { return _ssp_cam090_spro; }
            set
            {
                if (_ssp_cam090_spro == value) return;
                _ssp_cam090_spro = value;
                OnPropertyChanged("Ssp_cam090_spro");
            }
        }
        #endregion
        #region Ssp_cam091_spro: 91.Fecha Colposcopia
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 91.Fecha Colposcopia</para>
        /// <para>NOMBRE: ssp_cam091_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 95</para>
        /// <para>DESCRIPCION:
        /// Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam091_spro
        {
            get { return _ssp_cam091_spro; }
            set
            {
                if (_ssp_cam091_spro == value) return;
                _ssp_cam091_spro = value;
                OnPropertyChanged("Ssp_cam091_spro");
            }
        }
        #endregion
        #region Ssp_cam092_spro: 92.Codigo de habilitación IPS donde se t
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 92.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam092_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 96</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Colposcopia Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam092_spro
        {
            get { return _ssp_cam092_spro; }
            set
            {
                if (_ssp_cam092_spro == value) return;
                _ssp_cam092_spro = value;
                OnPropertyChanged("Ssp_cam092_spro");
            }
        }
        #endregion
        #region Ssp_cam093_spro: 93.Fecha Biopsia Cervical
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 93.Fecha Biopsia Cervical</para>
        /// <para>NOMBRE: ssp_cam093_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 97</para>
        /// <para>DESCRIPCION:
        /// Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam093_spro
        {
            get { return _ssp_cam093_spro; }
            set
            {
                if (_ssp_cam093_spro == value) return;
                _ssp_cam093_spro = value;
                OnPropertyChanged("Ssp_cam093_spro");
            }
        }
        #endregion
        #region Ssp_cam094_spro: 94.Resultado de Biopsia Cervical
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 94.Resultado de Biopsia Cervical</para>
        /// <para>NOMBRE: ssp_cam094_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 98</para>
        /// <para>DESCRIPCION:
        /// Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1-
        /// Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto
        /// Grado: NIC II - NIC III ETC
        /// </para>
        /// </summary>
        public String Ssp_cam094_spro
        {
            get { return _ssp_cam094_spro; }
            set
            {
                if (_ssp_cam094_spro == value) return;
                _ssp_cam094_spro = value;
                OnPropertyChanged("Ssp_cam094_spro");
            }
        }
        #endregion
        #region Ssp_cam095_spro: 95.Codigo de habilitación IPS donde se t
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 95.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam095_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 99</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam095_spro
        {
            get { return _ssp_cam095_spro; }
            set
            {
                if (_ssp_cam095_spro == value) return;
                _ssp_cam095_spro = value;
                OnPropertyChanged("Ssp_cam095_spro");
            }
        }
        #endregion
        #region Ssp_cam096_spro: 96.Fecha Mamografía
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 96.Fecha Mamografía</para>
        /// <para>NOMBRE: ssp_cam096_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 100</para>
        /// <para>DESCRIPCION:
        /// Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam096_spro
        {
            get { return _ssp_cam096_spro; }
            set
            {
                if (_ssp_cam096_spro == value) return;
                _ssp_cam096_spro = value;
                OnPropertyChanged("Ssp_cam096_spro");
            }
        }
        #endregion
        #region Ssp_cam097_spro: 97.Resultado Mamografía
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 97.Resultado Mamografía</para>
        /// <para>NOMBRE: ssp_cam097_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 101</para>
        /// <para>DESCRIPCION:
        /// Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico
        /// o Mamograma previo para evaluación 1- Negativo 2- Hallazgos
        /// Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam097_spro
        {
            get { return _ssp_cam097_spro; }
            set
            {
                if (_ssp_cam097_spro == value) return;
                _ssp_cam097_spro = value;
                OnPropertyChanged("Ssp_cam097_spro");
            }
        }
        #endregion
        #region Ssp_cam098_spro: 98.Codigo de habilitación IPS donde se t
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 98.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam098_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 102</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS
        /// (Registro Especial de Prestadores de Servicios de Salud). Si
        /// no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam098_spro
        {
            get { return _ssp_cam098_spro; }
            set
            {
                if (_ssp_cam098_spro == value) return;
                _ssp_cam098_spro = value;
                OnPropertyChanged("Ssp_cam098_spro");
            }
        }
        #endregion
        #region Ssp_cam099_spro: 99.Fecha Toma Biopsia Seno por BACAF
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 99.Fecha Toma Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: ssp_cam099_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 103</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam099_spro
        {
            get { return _ssp_cam099_spro; }
            set
            {
                if (_ssp_cam099_spro == value) return;
                _ssp_cam099_spro = value;
                OnPropertyChanged("Ssp_cam099_spro");
            }
        }
        #endregion
        #region Ssp_cam100_spro: 100.Fecha Resultado Biopsia Seno por BAC
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 100.Fecha Resultado Biopsia Seno por BAC</para>
        /// <para>NOMBRE: ssp_cam100_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 104</para>
        /// <para>DESCRIPCION:
        /// Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam100_spro
        {
            get { return _ssp_cam100_spro; }
            set
            {
                if (_ssp_cam100_spro == value) return;
                _ssp_cam100_spro = value;
                OnPropertyChanged("Ssp_cam100_spro");
            }
        }
        #endregion
        #region Ssp_cam101_spro: 101.Biopsia Seno por BACAF
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 101.Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: ssp_cam101_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 105</para>
        /// <para>DESCRIPCION:
        /// Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada)
        /// 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam101_spro
        {
            get { return _ssp_cam101_spro; }
            set
            {
                if (_ssp_cam101_spro == value) return;
                _ssp_cam101_spro = value;
                OnPropertyChanged("Ssp_cam101_spro");
            }
        }
        #endregion
        #region Ssp_cam102_spro: 102.Codigo de habilitación IPS donde se
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 102.Codigo de habilitación IPS donde se</para>
        /// <para>NOMBRE: ssp_cam102_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 106</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public String Ssp_cam102_spro
        {
            get { return _ssp_cam102_spro; }
            set
            {
                if (_ssp_cam102_spro == value) return;
                _ssp_cam102_spro = value;
                OnPropertyChanged("Ssp_cam102_spro");
            }
        }
        #endregion
        #region Ssp_cam103_spro: 103.Fecha Toma de Hemoglobina
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 103.Fecha Toma de Hemoglobina</para>
        /// <para>NOMBRE: ssp_cam103_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 107</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam103_spro
        {
            get { return _ssp_cam103_spro; }
            set
            {
                if (_ssp_cam103_spro == value) return;
                _ssp_cam103_spro = value;
                OnPropertyChanged("Ssp_cam103_spro");
            }
        }
        #endregion
        #region Ssp_cam104_spro: 104.Hemoglobina
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 104.Hemoglobina</para>
        /// <para>NOMBRE: ssp_cam104_spro (int:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 108</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Registre el dato reportado por el laboratorio.
        /// Si no aplica registre 9998
        /// </para>
        /// </summary>
        public int Ssp_cam104_spro
        {
            get { return _ssp_cam104_spro; }
            set
            {
                if (_ssp_cam104_spro == value) return;
                _ssp_cam104_spro = value;
                OnPropertyChanged("Ssp_cam104_spro");
            }
        }
        #endregion
        #region Ssp_cam105_spro: 105.Fecha de la Toma de Glicemia Basal
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 105.Fecha de la Toma de Glicemia Basal</para>
        /// <para>NOMBRE: ssp_cam105_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 109</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam105_spro
        {
            get { return _ssp_cam105_spro; }
            set
            {
                if (_ssp_cam105_spro == value) return;
                _ssp_cam105_spro = value;
                OnPropertyChanged("Ssp_cam105_spro");
            }
        }
        #endregion
        #region Ssp_cam106_spro: 106.Fecha Creatinina
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 106.Fecha Creatinina</para>
        /// <para>NOMBRE: ssp_cam106_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 110</para>
        /// <para>DESCRIPCION:
        /// Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam106_spro
        {
            get { return _ssp_cam106_spro; }
            set
            {
                if (_ssp_cam106_spro == value) return;
                _ssp_cam106_spro = value;
                OnPropertyChanged("Ssp_cam106_spro");
            }
        }
        #endregion
        #region Ssp_cam107_spro: 107.Creatinina
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 107.Creatinina</para>
        /// <para>NOMBRE: ssp_cam107_spro (int:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 111</para>
        /// <para>DESCRIPCION:
        /// Creatinina Registre el dato reportado por el laboratorio. Si
        /// no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int Ssp_cam107_spro
        {
            get { return _ssp_cam107_spro; }
            set
            {
                if (_ssp_cam107_spro == value) return;
                _ssp_cam107_spro = value;
                OnPropertyChanged("Ssp_cam107_spro");
            }
        }
        #endregion
        #region Ssp_cam108_spro: 108.Fecha Hemoglobina Glicosilada
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 108.Fecha Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: ssp_cam108_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 112</para>
        /// <para>DESCRIPCION:
        /// Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam108_spro
        {
            get { return _ssp_cam108_spro; }
            set
            {
                if (_ssp_cam108_spro == value) return;
                _ssp_cam108_spro = value;
                OnPropertyChanged("Ssp_cam108_spro");
            }
        }
        #endregion
        #region Ssp_cam109_spro: 109.Hemoglobina Glicosilada
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 109.Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: ssp_cam109_spro (int:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 113</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Glicosilada Registre el dato reportado por el laboratorio
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int Ssp_cam109_spro
        {
            get { return _ssp_cam109_spro; }
            set
            {
                if (_ssp_cam109_spro == value) return;
                _ssp_cam109_spro = value;
                OnPropertyChanged("Ssp_cam109_spro");
            }
        }
        #endregion
        #region Ssp_cam110_spro: 110.Fecha Toma de Microalbuminuria
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 110.Fecha Toma de Microalbuminuria</para>
        /// <para>NOMBRE: ssp_cam110_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 114</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam110_spro
        {
            get { return _ssp_cam110_spro; }
            set
            {
                if (_ssp_cam110_spro == value) return;
                _ssp_cam110_spro = value;
                OnPropertyChanged("Ssp_cam110_spro");
            }
        }
        #endregion
        #region Ssp_cam111_spro: 111.Fecha Toma de HDL
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 111.Fecha Toma de HDL</para>
        /// <para>NOMBRE: ssp_cam111_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 115</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam111_spro
        {
            get { return _ssp_cam111_spro; }
            set
            {
                if (_ssp_cam111_spro == value) return;
                _ssp_cam111_spro = value;
                OnPropertyChanged("Ssp_cam111_spro");
            }
        }
        #endregion
        #region Ssp_cam112_spro: 112.Fecha Toma de Baciloscopia de Diagno
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 112.Fecha Toma de Baciloscopia de Diagno</para>
        /// <para>NOMBRE: ssp_cam112_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 116</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam112_spro
        {
            get { return _ssp_cam112_spro; }
            set
            {
                if (_ssp_cam112_spro == value) return;
                _ssp_cam112_spro = value;
                OnPropertyChanged("Ssp_cam112_spro");
            }
        }
        #endregion
        #region Ssp_cam113_spro: 113.Baciloscopia de Diagnostico
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 113.Baciloscopia de Diagnostico</para>
        /// <para>NOMBRE: ssp_cam113_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 117</para>
        /// <para>DESCRIPCION:
        /// Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3-
        /// Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam113_spro
        {
            get { return _ssp_cam113_spro; }
            set
            {
                if (_ssp_cam113_spro == value) return;
                _ssp_cam113_spro = value;
                OnPropertyChanged("Ssp_cam113_spro");
            }
        }
        #endregion
        #region Ssp_cam114_spro: 114.Tratamiento para Hipotiroidismo Cong
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 114.Tratamiento para Hipotiroidismo Cong</para>
        /// <para>NOMBRE: ssp_cam114_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 118</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud que se lo impide ETC
        /// </para>
        /// </summary>
        public String Ssp_cam114_spro
        {
            get { return _ssp_cam114_spro; }
            set
            {
                if (_ssp_cam114_spro == value) return;
                _ssp_cam114_spro = value;
                OnPropertyChanged("Ssp_cam114_spro");
            }
        }
        #endregion
        #region Ssp_cam115_spro: 115.Tratamiento para Sífilis gestacional
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 115.Tratamiento para Sífilis gestacional</para>
        /// <para>NOMBRE: ssp_cam115_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 119</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis gestacional 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam115_spro
        {
            get { return _ssp_cam115_spro; }
            set
            {
                if (_ssp_cam115_spro == value) return;
                _ssp_cam115_spro = value;
                OnPropertyChanged("Ssp_cam115_spro");
            }
        }
        #endregion
        #region Ssp_cam116_spro: 116.Tratamiento para Sífilis Congénita
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 116.Tratamiento para Sífilis Congénita</para>
        /// <para>NOMBRE: ssp_cam116_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 120</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis Congenita 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam116_spro
        {
            get { return _ssp_cam116_spro; }
            set
            {
                if (_ssp_cam116_spro == value) return;
                _ssp_cam116_spro = value;
                OnPropertyChanged("Ssp_cam116_spro");
            }
        }
        #endregion
        #region Ssp_cam117_spro: 117.Tratamiento para Lepra
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 117.Tratamiento para Lepra</para>
        /// <para>NOMBRE: ssp_cam117_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 121</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Lepra 0- No recibió tratamiento por tener
        /// una tradición que se lo impide 1- No recibió tratamiento por
        /// una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam117_spro
        {
            get { return _ssp_cam117_spro; }
            set
            {
                if (_ssp_cam117_spro == value) return;
                _ssp_cam117_spro = value;
                OnPropertyChanged("Ssp_cam117_spro");
            }
        }
        #endregion
        #region Ssp_cam118_spro: 118.Fecha de Terminación Tratamiento par
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 118.Fecha de Terminación Tratamiento par</para>
        /// <para>NOMBRE: ssp_cam118_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 122</para>
        /// <para>DESCRIPCION:
        /// Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 Si no se realiza por
        /// una Condición de Salud registrar 1810-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam118_spro
        {
            get { return _ssp_cam118_spro; }
            set
            {
                if (_ssp_cam118_spro == value) return;
                _ssp_cam118_spro = value;
                OnPropertyChanged("Ssp_cam118_spro");
            }
        }
        #endregion
        #region Ssp_consec_spro: Contador
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: Contador</para>
        /// <para>NOMBRE: ssp_consec_spro (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 123</para>
        /// <para>DESCRIPCION:
        ///Contador para generar secuencial de novedades
        /// </para>
        /// </summary>
        public int Ssp_consec_spro
        {
            get { return _ssp_consec_spro; }
            set
            {
                if (_ssp_consec_spro == value) return;
                _ssp_consec_spro = value;
                OnPropertyChanged("Ssp_consec_spro");
            }
        }
        #endregion
        #region Sia_nomusu_usua: Nombre paciente
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
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
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
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
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
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
        public static string flgAddRegistro(ModeloSspSISPRO tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("SSP-MAE-SISPRO", "SSP", "Maestro de SISPRO");
            if (!flgBuscarSptablamssispro(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFsptablamssispro
                    {
                        #region cargar Registro
                        sia_idesec_usua = tobjModelo.Sia_idesec_usua,
                        sia_nroide_usua = tobjModelo.Sia_nroide_usua,
                        sia_codeps_teps = tobjModelo.Sia_codeps_teps,
                        ssp_cam000_spro = tobjModelo.Ssp_cam000_spro,
                        ssp_cam001_spro = tobjModelo.Ssp_cam001_spro,
                        ssp_cam002_spro = tobjModelo.Ssp_cam002_spro,
                        ssp_cam003_spro = tobjModelo.Ssp_cam003_spro,
                        ssp_cam004_spro = tobjModelo.Ssp_cam004_spro,
                        ssp_cam005_spro = tobjModelo.Ssp_cam005_spro,
                        ssp_cam006_spro = tobjModelo.Ssp_cam006_spro,
                        ssp_cam007_spro = tobjModelo.Ssp_cam007_spro,
                        ssp_cam008_spro = tobjModelo.Ssp_cam008_spro,
                        ssp_cam009_spro = tobjModelo.Ssp_cam009_spro,
                        ssp_cam010_spro = tobjModelo.Ssp_cam010_spro,
                        ssp_cam011_spro = tobjModelo.Ssp_cam011_spro,
                        ssp_codocu_ciuo = tobjModelo.Ssp_codocu_ciuo,
                        ssp_cam013_spro = tobjModelo.Ssp_cam013_spro,
                        ssp_cam014_spro = tobjModelo.Ssp_cam014_spro,
                        ssp_cam015_spro = tobjModelo.Ssp_cam015_spro,
                        ssp_cam016_spro = tobjModelo.Ssp_cam016_spro,
                        ssp_cam017_spro = tobjModelo.Ssp_cam017_spro,
                        ssp_cam018_spro = tobjModelo.Ssp_cam018_spro,
                        ssp_cam019_spro = tobjModelo.Ssp_cam019_spro,
                        ssp_cam020_spro = tobjModelo.Ssp_cam020_spro,
                        ssp_cam021_spro = tobjModelo.Ssp_cam021_spro,
                        ssp_cam022_spro = tobjModelo.Ssp_cam022_spro,
                        ssp_cam023_spro = tobjModelo.Ssp_cam023_spro,
                        ssp_cam024_spro = tobjModelo.Ssp_cam024_spro,
                        ssp_cam025_spro = tobjModelo.Ssp_cam025_spro,
                        ssp_cam026_spro = tobjModelo.Ssp_cam026_spro,
                        ssp_cam027_spro = tobjModelo.Ssp_cam027_spro,
                        ssp_cam028_spro = tobjModelo.Ssp_cam028_spro,
                        ssp_cam029_spro = tobjModelo.Ssp_cam029_spro,
                        ssp_cam030_spro = tobjModelo.Ssp_cam030_spro,
                        ssp_cam031_spro = tobjModelo.Ssp_cam031_spro,
                        ssp_cam032_spro = tobjModelo.Ssp_cam032_spro,
                        ssp_cam033_spro = tobjModelo.Ssp_cam033_spro,
                        ssp_cam034_spro = tobjModelo.Ssp_cam034_spro,
                        ssp_cam035_spro = tobjModelo.Ssp_cam035_spro,
                        ssp_cam036_spro = tobjModelo.Ssp_cam036_spro,
                        ssp_cam037_spro = tobjModelo.Ssp_cam037_spro,
                        ssp_cam038_spro = tobjModelo.Ssp_cam038_spro,
                        ssp_cam039_spro = tobjModelo.Ssp_cam039_spro,
                        ssp_cam040_spro = tobjModelo.Ssp_cam040_spro,
                        ssp_cam041_spro = tobjModelo.Ssp_cam041_spro,
                        ssp_cam042_spro = tobjModelo.Ssp_cam042_spro,
                        ssp_cam043_spro = tobjModelo.Ssp_cam043_spro,
                        ssp_cam044_spro = tobjModelo.Ssp_cam044_spro,
                        ssp_cam045_spro = tobjModelo.Ssp_cam045_spro,
                        ssp_cam046_spro = tobjModelo.Ssp_cam046_spro,
                        ssp_cam047_spro = tobjModelo.Ssp_cam047_spro,
                        ssp_cam048_spro = tobjModelo.Ssp_cam048_spro,
                        ssp_cam049_spro = tobjModelo.Ssp_cam049_spro,
                        ssp_cam050_spro = tobjModelo.Ssp_cam050_spro,
                        ssp_cam051_spro = tobjModelo.Ssp_cam051_spro,
                        ssp_cam052_spro = tobjModelo.Ssp_cam052_spro,
                        ssp_cam053_spro = tobjModelo.Ssp_cam053_spro,
                        ssp_cam054_spro = tobjModelo.Ssp_cam054_spro,
                        ssp_cam055_spro = tobjModelo.Ssp_cam055_spro,
                        ssp_cam056_spro = tobjModelo.Ssp_cam056_spro,
                        ssp_cam057_spro = tobjModelo.Ssp_cam057_spro,
                        ssp_cam058_spro = tobjModelo.Ssp_cam058_spro,
                        ssp_cam059_spro = tobjModelo.Ssp_cam059_spro,
                        ssp_cam060_spro = tobjModelo.Ssp_cam060_spro,
                        ssp_cam061_spro = tobjModelo.Ssp_cam061_spro,
                        ssp_cam062_spro = tobjModelo.Ssp_cam062_spro,
                        ssp_cam063_spro = tobjModelo.Ssp_cam063_spro,
                        ssp_cam064_spro = tobjModelo.Ssp_cam064_spro,
                        ssp_cam065_spro = tobjModelo.Ssp_cam065_spro,
                        ssp_cam066_spro = tobjModelo.Ssp_cam066_spro,
                        ssp_cam067_spro = tobjModelo.Ssp_cam067_spro,
                        ssp_cam068_spro = tobjModelo.Ssp_cam068_spro,
                        ssp_cam069_spro = tobjModelo.Ssp_cam069_spro,
                        ssp_cam070_spro = tobjModelo.Ssp_cam070_spro,
                        ssp_cam071_spro = tobjModelo.Ssp_cam071_spro,
                        ssp_cam072_spro = tobjModelo.Ssp_cam072_spro,
                        ssp_cam073_spro = tobjModelo.Ssp_cam073_spro,
                        ssp_cam074_spro = tobjModelo.Ssp_cam074_spro,
                        ssp_cam075_spro = tobjModelo.Ssp_cam075_spro,
                        ssp_cam076_spro = tobjModelo.Ssp_cam076_spro,
                        ssp_cam077_spro = tobjModelo.Ssp_cam077_spro,
                        ssp_cam078_spro = tobjModelo.Ssp_cam078_spro,
                        ssp_cam079_spro = tobjModelo.Ssp_cam079_spro,
                        ssp_cam080_spro = tobjModelo.Ssp_cam080_spro,
                        ssp_cam081_spro = tobjModelo.Ssp_cam081_spro,
                        ssp_cam082_spro = tobjModelo.Ssp_cam082_spro,
                        ssp_cam083_spro = tobjModelo.Ssp_cam083_spro,
                        ssp_cam084_spro = tobjModelo.Ssp_cam084_spro,
                        ssp_cam085_spro = tobjModelo.Ssp_cam085_spro,
                        ssp_cam086_spro = tobjModelo.Ssp_cam086_spro,
                        ssp_cam087_spro = tobjModelo.Ssp_cam087_spro,
                        ssp_cam088_spro = tobjModelo.Ssp_cam088_spro,
                        ssp_cam089_spro = tobjModelo.Ssp_cam089_spro,
                        ssp_cam090_spro = tobjModelo.Ssp_cam090_spro,
                        ssp_cam091_spro = tobjModelo.Ssp_cam091_spro,
                        ssp_cam092_spro = tobjModelo.Ssp_cam092_spro,
                        ssp_cam093_spro = tobjModelo.Ssp_cam093_spro,
                        ssp_cam094_spro = tobjModelo.Ssp_cam094_spro,
                        ssp_cam095_spro = tobjModelo.Ssp_cam095_spro,
                        ssp_cam096_spro = tobjModelo.Ssp_cam096_spro,
                        ssp_cam097_spro = tobjModelo.Ssp_cam097_spro,
                        ssp_cam098_spro = tobjModelo.Ssp_cam098_spro,
                        ssp_cam099_spro = tobjModelo.Ssp_cam099_spro,
                        ssp_cam100_spro = tobjModelo.Ssp_cam100_spro,
                        ssp_cam101_spro = tobjModelo.Ssp_cam101_spro,
                        ssp_cam102_spro = tobjModelo.Ssp_cam102_spro,
                        ssp_cam103_spro = tobjModelo.Ssp_cam103_spro,
                        ssp_cam104_spro = tobjModelo.Ssp_cam104_spro,
                        ssp_cam105_spro = tobjModelo.Ssp_cam105_spro,
                        ssp_cam106_spro = tobjModelo.Ssp_cam106_spro,
                        ssp_cam107_spro = tobjModelo.Ssp_cam107_spro,
                        ssp_cam108_spro = tobjModelo.Ssp_cam108_spro,
                        ssp_cam109_spro = tobjModelo.Ssp_cam109_spro,
                        ssp_cam110_spro = tobjModelo.Ssp_cam110_spro,
                        ssp_cam111_spro = tobjModelo.Ssp_cam111_spro,
                        ssp_cam112_spro = tobjModelo.Ssp_cam112_spro,
                        ssp_cam113_spro = tobjModelo.Ssp_cam113_spro,
                        ssp_cam114_spro = tobjModelo.Ssp_cam114_spro,
                        ssp_cam115_spro = tobjModelo.Ssp_cam115_spro,
                        ssp_cam116_spro = tobjModelo.Ssp_cam116_spro,
                        ssp_cam117_spro = tobjModelo.Ssp_cam117_spro,
                        ssp_cam118_spro = tobjModelo.Ssp_cam118_spro,
                        ssp_consec_spro = tobjModelo.Ssp_consec_spro,
                        #endregion
                    };
                    lobjRegistro.ssp_cam001_spro = lcrCodigoGen;
                    lobjRegistro.ssp_cam000_spro = "2";
                    _context.AddToSptablamssispro(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'SSP-MAE-SISPRO': Maestro de SISPRO en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloSspSISPRO tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablamssispro.FirstOrDefault(p => p.ssp_cam001_spro == tobjModelo.Ssp_cam001_spro);
                if (lobjRegistro != null)
                {
                    lobjRegistro.sia_idesec_usua = tobjModelo.Sia_idesec_usua;
                    lobjRegistro.sia_nroide_usua = tobjModelo.Sia_nroide_usua;
                    lobjRegistro.sia_codeps_teps = tobjModelo.Sia_codeps_teps;
                    lobjRegistro.ssp_cam000_spro = tobjModelo.Ssp_cam000_spro;
                    lobjRegistro.ssp_cam001_spro = tobjModelo.Ssp_cam001_spro;
                    lobjRegistro.ssp_cam002_spro = tobjModelo.Ssp_cam002_spro;
                    lobjRegistro.ssp_cam003_spro = tobjModelo.Ssp_cam003_spro;
                    lobjRegistro.ssp_cam004_spro = tobjModelo.Ssp_cam004_spro;
                    lobjRegistro.ssp_cam005_spro = tobjModelo.Ssp_cam005_spro;
                    lobjRegistro.ssp_cam006_spro = tobjModelo.Ssp_cam006_spro;
                    lobjRegistro.ssp_cam007_spro = tobjModelo.Ssp_cam007_spro;
                    lobjRegistro.ssp_cam008_spro = tobjModelo.Ssp_cam008_spro;
                    lobjRegistro.ssp_cam009_spro = (DateTime)tobjModelo.Ssp_cam009_spro;
                    lobjRegistro.ssp_cam010_spro = tobjModelo.Ssp_cam010_spro;
                    lobjRegistro.ssp_cam011_spro = tobjModelo.Ssp_cam011_spro;
                    lobjRegistro.ssp_codocu_ciuo = tobjModelo.Ssp_codocu_ciuo;
                    lobjRegistro.ssp_cam013_spro = tobjModelo.Ssp_cam013_spro;
                    lobjRegistro.ssp_cam014_spro = tobjModelo.Ssp_cam014_spro;
                    lobjRegistro.ssp_cam015_spro = tobjModelo.Ssp_cam015_spro;
                    lobjRegistro.ssp_cam016_spro = tobjModelo.Ssp_cam016_spro;
                    lobjRegistro.ssp_cam017_spro = tobjModelo.Ssp_cam017_spro;
                    lobjRegistro.ssp_cam018_spro = tobjModelo.Ssp_cam018_spro;
                    lobjRegistro.ssp_cam019_spro = tobjModelo.Ssp_cam019_spro;
                    lobjRegistro.ssp_cam020_spro = tobjModelo.Ssp_cam020_spro;
                    lobjRegistro.ssp_cam021_spro = tobjModelo.Ssp_cam021_spro;
                    lobjRegistro.ssp_cam022_spro = tobjModelo.Ssp_cam022_spro;
                    lobjRegistro.ssp_cam023_spro = tobjModelo.Ssp_cam023_spro;
                    lobjRegistro.ssp_cam024_spro = tobjModelo.Ssp_cam024_spro;
                    lobjRegistro.ssp_cam025_spro = tobjModelo.Ssp_cam025_spro;
                    lobjRegistro.ssp_cam026_spro = tobjModelo.Ssp_cam026_spro;
                    lobjRegistro.ssp_cam027_spro = tobjModelo.Ssp_cam027_spro;
                    lobjRegistro.ssp_cam028_spro = tobjModelo.Ssp_cam028_spro;
                    lobjRegistro.ssp_cam029_spro = (DateTime)tobjModelo.Ssp_cam029_spro;
                    lobjRegistro.ssp_cam030_spro = (int)tobjModelo.Ssp_cam030_spro;
                    lobjRegistro.ssp_cam031_spro = (DateTime)tobjModelo.Ssp_cam031_spro;
                    lobjRegistro.ssp_cam032_spro = (int)tobjModelo.Ssp_cam032_spro;
                    lobjRegistro.ssp_cam033_spro = (DateTime)tobjModelo.Ssp_cam033_spro;
                    lobjRegistro.ssp_cam034_spro = (int)tobjModelo.Ssp_cam034_spro;
                    lobjRegistro.ssp_cam035_spro = tobjModelo.Ssp_cam035_spro;
                    lobjRegistro.ssp_cam036_spro = tobjModelo.Ssp_cam036_spro;
                    lobjRegistro.ssp_cam037_spro = tobjModelo.Ssp_cam037_spro;
                    lobjRegistro.ssp_cam038_spro = tobjModelo.Ssp_cam038_spro;
                    lobjRegistro.ssp_cam039_spro = tobjModelo.Ssp_cam039_spro;
                    lobjRegistro.ssp_cam040_spro = tobjModelo.Ssp_cam040_spro;
                    lobjRegistro.ssp_cam041_spro = tobjModelo.Ssp_cam041_spro;
                    lobjRegistro.ssp_cam042_spro = tobjModelo.Ssp_cam042_spro;
                    lobjRegistro.ssp_cam043_spro = tobjModelo.Ssp_cam043_spro;
                    lobjRegistro.ssp_cam044_spro = tobjModelo.Ssp_cam044_spro;
                    lobjRegistro.ssp_cam045_spro = tobjModelo.Ssp_cam045_spro;
                    lobjRegistro.ssp_cam046_spro = tobjModelo.Ssp_cam046_spro;
                    lobjRegistro.ssp_cam047_spro = tobjModelo.Ssp_cam047_spro;
                    lobjRegistro.ssp_cam048_spro = tobjModelo.Ssp_cam048_spro;
                    lobjRegistro.ssp_cam049_spro = (DateTime)tobjModelo.Ssp_cam049_spro;
                    lobjRegistro.ssp_cam050_spro = (DateTime)tobjModelo.Ssp_cam050_spro;
                    lobjRegistro.ssp_cam051_spro = (DateTime)tobjModelo.Ssp_cam051_spro;
                    lobjRegistro.ssp_cam052_spro = (DateTime)tobjModelo.Ssp_cam052_spro;
                    lobjRegistro.ssp_cam053_spro = (DateTime)tobjModelo.Ssp_cam053_spro;
                    lobjRegistro.ssp_cam054_spro = tobjModelo.Ssp_cam054_spro;
                    lobjRegistro.ssp_cam055_spro = (DateTime)tobjModelo.Ssp_cam055_spro;
                    lobjRegistro.ssp_cam056_spro = (DateTime)tobjModelo.Ssp_cam056_spro;
                    lobjRegistro.ssp_cam057_spro = (int)tobjModelo.Ssp_cam057_spro;
                    lobjRegistro.ssp_cam058_spro = (DateTime)tobjModelo.Ssp_cam058_spro;
                    lobjRegistro.ssp_cam059_spro = tobjModelo.Ssp_cam059_spro;
                    lobjRegistro.ssp_cam060_spro = tobjModelo.Ssp_cam060_spro;
                    lobjRegistro.ssp_cam061_spro = tobjModelo.Ssp_cam061_spro;
                    lobjRegistro.ssp_cam062_spro = (DateTime)tobjModelo.Ssp_cam062_spro;
                    lobjRegistro.ssp_cam063_spro = (DateTime)tobjModelo.Ssp_cam063_spro;
                    lobjRegistro.ssp_cam064_spro = (DateTime)tobjModelo.Ssp_cam064_spro;
                    lobjRegistro.ssp_cam065_spro = (DateTime)tobjModelo.Ssp_cam065_spro;
                    lobjRegistro.ssp_cam066_spro = (DateTime)tobjModelo.Ssp_cam066_spro;
                    lobjRegistro.ssp_cam067_spro = (DateTime)tobjModelo.Ssp_cam067_spro;
                    lobjRegistro.ssp_cam068_spro = (DateTime)tobjModelo.Ssp_cam068_spro;
                    lobjRegistro.ssp_cam069_spro = (DateTime)tobjModelo.Ssp_cam069_spro;
                    lobjRegistro.ssp_cam070_spro = tobjModelo.Ssp_cam070_spro;
                    lobjRegistro.ssp_cam071_spro = tobjModelo.Ssp_cam071_spro;
                    lobjRegistro.ssp_cam072_spro = (DateTime)tobjModelo.Ssp_cam072_spro;
                    lobjRegistro.ssp_cam073_spro = (DateTime)tobjModelo.Ssp_cam073_spro;
                    lobjRegistro.ssp_cam074_spro = (int)tobjModelo.Ssp_cam074_spro;
                    lobjRegistro.ssp_cam075_spro = (DateTime)tobjModelo.Ssp_cam075_spro;
                    lobjRegistro.ssp_cam076_spro = (DateTime)tobjModelo.Ssp_cam076_spro;
                    lobjRegistro.ssp_cam077_spro = tobjModelo.Ssp_cam077_spro;
                    lobjRegistro.ssp_cam078_spro = (DateTime)tobjModelo.Ssp_cam078_spro;
                    lobjRegistro.ssp_cam079_spro = tobjModelo.Ssp_cam079_spro;
                    lobjRegistro.ssp_cam080_spro = (DateTime)tobjModelo.Ssp_cam080_spro;
                    lobjRegistro.ssp_cam081_spro = tobjModelo.Ssp_cam081_spro;
                    lobjRegistro.ssp_cam082_spro = (DateTime)tobjModelo.Ssp_cam082_spro;
                    lobjRegistro.ssp_cam083_spro = tobjModelo.Ssp_cam083_spro;
                    lobjRegistro.ssp_cam084_spro = (DateTime)tobjModelo.Ssp_cam084_spro;
                    lobjRegistro.ssp_cam085_spro = tobjModelo.Ssp_cam085_spro;
                    lobjRegistro.ssp_cam086_spro = tobjModelo.Ssp_cam086_spro;
                    lobjRegistro.ssp_cam087_spro = (DateTime)tobjModelo.Ssp_cam087_spro;
                    lobjRegistro.ssp_cam088_spro = tobjModelo.Ssp_cam088_spro;
                    lobjRegistro.ssp_cam089_spro = tobjModelo.Ssp_cam089_spro;
                    lobjRegistro.ssp_cam090_spro = tobjModelo.Ssp_cam090_spro;
                    lobjRegistro.ssp_cam091_spro = (DateTime)tobjModelo.Ssp_cam091_spro;
                    lobjRegistro.ssp_cam092_spro = tobjModelo.Ssp_cam092_spro;
                    lobjRegistro.ssp_cam093_spro = (DateTime)tobjModelo.Ssp_cam093_spro;
                    lobjRegistro.ssp_cam094_spro = tobjModelo.Ssp_cam094_spro;
                    lobjRegistro.ssp_cam095_spro = tobjModelo.Ssp_cam095_spro;
                    lobjRegistro.ssp_cam096_spro = (DateTime)tobjModelo.Ssp_cam096_spro;
                    lobjRegistro.ssp_cam097_spro = tobjModelo.Ssp_cam097_spro;
                    lobjRegistro.ssp_cam098_spro = tobjModelo.Ssp_cam098_spro;
                    lobjRegistro.ssp_cam099_spro = (DateTime)tobjModelo.Ssp_cam099_spro;
                    lobjRegistro.ssp_cam100_spro = (DateTime)tobjModelo.Ssp_cam100_spro;
                    lobjRegistro.ssp_cam101_spro = tobjModelo.Ssp_cam101_spro;
                    lobjRegistro.ssp_cam102_spro = tobjModelo.Ssp_cam102_spro;
                    lobjRegistro.ssp_cam103_spro = (DateTime)tobjModelo.Ssp_cam103_spro;
                    lobjRegistro.ssp_cam104_spro = (int)tobjModelo.Ssp_cam104_spro;
                    lobjRegistro.ssp_cam105_spro = (DateTime)tobjModelo.Ssp_cam105_spro;
                    lobjRegistro.ssp_cam106_spro = (DateTime)tobjModelo.Ssp_cam106_spro;
                    lobjRegistro.ssp_cam107_spro = (int)tobjModelo.Ssp_cam107_spro;
                    lobjRegistro.ssp_cam108_spro = (DateTime)tobjModelo.Ssp_cam108_spro;
                    lobjRegistro.ssp_cam109_spro = (int)tobjModelo.Ssp_cam109_spro;
                    lobjRegistro.ssp_cam110_spro = (DateTime)tobjModelo.Ssp_cam110_spro;
                    lobjRegistro.ssp_cam111_spro = (DateTime)tobjModelo.Ssp_cam111_spro;
                    lobjRegistro.ssp_cam112_spro = (DateTime)tobjModelo.Ssp_cam112_spro;
                    lobjRegistro.ssp_cam113_spro = tobjModelo.Ssp_cam113_spro;
                    lobjRegistro.ssp_cam114_spro = tobjModelo.Ssp_cam114_spro;
                    lobjRegistro.ssp_cam115_spro = tobjModelo.Ssp_cam115_spro;
                    lobjRegistro.ssp_cam116_spro = tobjModelo.Ssp_cam116_spro;
                    lobjRegistro.ssp_cam117_spro = tobjModelo.Ssp_cam117_spro;
                    lobjRegistro.ssp_cam118_spro = (DateTime)tobjModelo.Ssp_cam118_spro;
                    lobjRegistro.ssp_consec_spro = (int)tobjModelo.Ssp_consec_spro;
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
                var lobjRegistro = _context.Sptablamssispro.FirstOrDefault(p => p.ssp_cam001_spro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar SPTABLAMSSISPRO: Logica
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TITULO: Tabla maestra de digitacion SISPRO</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla maestra de digitacion SISPRO
        /// </para>
        /// </summary>
        public static bool flgBuscarSptablamssispro(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablamssispro.FirstOrDefault(p => p.ssp_cam001_spro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSspSISPRO> flsListaSptablamssispro(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    var lobConsulta = from sptablamssispro in _context.Sptablamssispro
                                      join siausuarioatend in _context.Siausuarioatend on sptablamssispro.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatablaeps in _context.Siatablaeps on sptablamssispro.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join spocupacionciuo in _context.Spocupacionciuo on sptablamssispro.ssp_codocu_ciuo equals spocupacionciuo.ssp_codocu_ciuo into tmspocupacionciuo
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from ciuo in tmspocupacionciuo.DefaultIfEmpty()
                                      select new ModeloSspSISPRO
                                      {
                                          Sia_idesec_usua = sptablamssispro.sia_idesec_usua,
                                          Sia_nroide_usua = sptablamssispro.sia_nroide_usua,
                                          Sia_codeps_teps = sptablamssispro.sia_codeps_teps,
                                          Ssp_cam000_spro = sptablamssispro.ssp_cam000_spro,
                                          Ssp_cam001_spro = sptablamssispro.ssp_cam001_spro,
                                          Ssp_cam002_spro = sptablamssispro.ssp_cam002_spro,
                                          Ssp_cam003_spro = sptablamssispro.ssp_cam003_spro,
                                          Ssp_cam004_spro = sptablamssispro.ssp_cam004_spro,
                                          Ssp_cam005_spro = sptablamssispro.ssp_cam005_spro,
                                          Ssp_cam006_spro = sptablamssispro.ssp_cam006_spro,
                                          Ssp_cam007_spro = sptablamssispro.ssp_cam007_spro,
                                          Ssp_cam008_spro = sptablamssispro.ssp_cam008_spro,
                                          Ssp_cam009_spro = (DateTime)sptablamssispro.ssp_cam009_spro,
                                          Ssp_cam010_spro = sptablamssispro.ssp_cam010_spro,
                                          Ssp_cam011_spro = sptablamssispro.ssp_cam011_spro,
                                          Ssp_codocu_ciuo = sptablamssispro.ssp_codocu_ciuo,
                                          Ssp_cam013_spro = sptablamssispro.ssp_cam013_spro,
                                          Ssp_cam014_spro = sptablamssispro.ssp_cam014_spro,
                                          Ssp_cam015_spro = sptablamssispro.ssp_cam015_spro,
                                          Ssp_cam016_spro = sptablamssispro.ssp_cam016_spro,
                                          Ssp_cam017_spro = sptablamssispro.ssp_cam017_spro,
                                          Ssp_cam018_spro = sptablamssispro.ssp_cam018_spro,
                                          Ssp_cam019_spro = sptablamssispro.ssp_cam019_spro,
                                          Ssp_cam020_spro = sptablamssispro.ssp_cam020_spro,
                                          Ssp_cam021_spro = sptablamssispro.ssp_cam021_spro,
                                          Ssp_cam022_spro = sptablamssispro.ssp_cam022_spro,
                                          Ssp_cam023_spro = sptablamssispro.ssp_cam023_spro,
                                          Ssp_cam024_spro = sptablamssispro.ssp_cam024_spro,
                                          Ssp_cam025_spro = sptablamssispro.ssp_cam025_spro,
                                          Ssp_cam026_spro = sptablamssispro.ssp_cam026_spro,
                                          Ssp_cam027_spro = sptablamssispro.ssp_cam027_spro,
                                          Ssp_cam028_spro = sptablamssispro.ssp_cam028_spro,
                                          Ssp_cam029_spro = (DateTime)sptablamssispro.ssp_cam029_spro,
                                          Ssp_cam030_spro = (int)sptablamssispro.ssp_cam030_spro,
                                          Ssp_cam031_spro = (DateTime)sptablamssispro.ssp_cam031_spro,
                                          Ssp_cam032_spro = (int)sptablamssispro.ssp_cam032_spro,
                                          Ssp_cam033_spro = (DateTime)sptablamssispro.ssp_cam033_spro,
                                          Ssp_cam034_spro = (int)sptablamssispro.ssp_cam034_spro,
                                          Ssp_cam035_spro = sptablamssispro.ssp_cam035_spro,
                                          Ssp_cam036_spro = sptablamssispro.ssp_cam036_spro,
                                          Ssp_cam037_spro = sptablamssispro.ssp_cam037_spro,
                                          Ssp_cam038_spro = sptablamssispro.ssp_cam038_spro,
                                          Ssp_cam039_spro = sptablamssispro.ssp_cam039_spro,
                                          Ssp_cam040_spro = sptablamssispro.ssp_cam040_spro,
                                          Ssp_cam041_spro = sptablamssispro.ssp_cam041_spro,
                                          Ssp_cam042_spro = sptablamssispro.ssp_cam042_spro,
                                          Ssp_cam043_spro = sptablamssispro.ssp_cam043_spro,
                                          Ssp_cam044_spro = sptablamssispro.ssp_cam044_spro,
                                          Ssp_cam045_spro = sptablamssispro.ssp_cam045_spro,
                                          Ssp_cam046_spro = sptablamssispro.ssp_cam046_spro,
                                          Ssp_cam047_spro = sptablamssispro.ssp_cam047_spro,
                                          Ssp_cam048_spro = sptablamssispro.ssp_cam048_spro,
                                          Ssp_cam049_spro = (DateTime)sptablamssispro.ssp_cam049_spro,
                                          Ssp_cam050_spro = (DateTime)sptablamssispro.ssp_cam050_spro,
                                          Ssp_cam051_spro = (DateTime)sptablamssispro.ssp_cam051_spro,
                                          Ssp_cam052_spro = (DateTime)sptablamssispro.ssp_cam052_spro,
                                          Ssp_cam053_spro = (DateTime)sptablamssispro.ssp_cam053_spro,
                                          Ssp_cam054_spro = sptablamssispro.ssp_cam054_spro,
                                          Ssp_cam055_spro = (DateTime)sptablamssispro.ssp_cam055_spro,
                                          Ssp_cam056_spro = (DateTime)sptablamssispro.ssp_cam056_spro,
                                          Ssp_cam057_spro = (int)sptablamssispro.ssp_cam057_spro,
                                          Ssp_cam058_spro = (DateTime)sptablamssispro.ssp_cam058_spro,
                                          Ssp_cam059_spro = sptablamssispro.ssp_cam059_spro,
                                          Ssp_cam060_spro = sptablamssispro.ssp_cam060_spro,
                                          Ssp_cam061_spro = sptablamssispro.ssp_cam061_spro,
                                          Ssp_cam062_spro = (DateTime)sptablamssispro.ssp_cam062_spro,
                                          Ssp_cam063_spro = (DateTime)sptablamssispro.ssp_cam063_spro,
                                          Ssp_cam064_spro = (DateTime)sptablamssispro.ssp_cam064_spro,
                                          Ssp_cam065_spro = (DateTime)sptablamssispro.ssp_cam065_spro,
                                          Ssp_cam066_spro = (DateTime)sptablamssispro.ssp_cam066_spro,
                                          Ssp_cam067_spro = (DateTime)sptablamssispro.ssp_cam067_spro,
                                          Ssp_cam068_spro = (DateTime)sptablamssispro.ssp_cam068_spro,
                                          Ssp_cam069_spro = (DateTime)sptablamssispro.ssp_cam069_spro,
                                          Ssp_cam070_spro = sptablamssispro.ssp_cam070_spro,
                                          Ssp_cam071_spro = sptablamssispro.ssp_cam071_spro,
                                          Ssp_cam072_spro = (DateTime)sptablamssispro.ssp_cam072_spro,
                                          Ssp_cam073_spro = (DateTime)sptablamssispro.ssp_cam073_spro,
                                          Ssp_cam074_spro = (int)sptablamssispro.ssp_cam074_spro,
                                          Ssp_cam075_spro = (DateTime)sptablamssispro.ssp_cam075_spro,
                                          Ssp_cam076_spro = (DateTime)sptablamssispro.ssp_cam076_spro,
                                          Ssp_cam077_spro = sptablamssispro.ssp_cam077_spro,
                                          Ssp_cam078_spro = (DateTime)sptablamssispro.ssp_cam078_spro,
                                          Ssp_cam079_spro = sptablamssispro.ssp_cam079_spro,
                                          Ssp_cam080_spro = (DateTime)sptablamssispro.ssp_cam080_spro,
                                          Ssp_cam081_spro = sptablamssispro.ssp_cam081_spro,
                                          Ssp_cam082_spro = (DateTime)sptablamssispro.ssp_cam082_spro,
                                          Ssp_cam083_spro = sptablamssispro.ssp_cam083_spro,
                                          Ssp_cam084_spro = (DateTime)sptablamssispro.ssp_cam084_spro,
                                          Ssp_cam085_spro = sptablamssispro.ssp_cam085_spro,
                                          Ssp_cam086_spro = sptablamssispro.ssp_cam086_spro,
                                          Ssp_cam087_spro = (DateTime)sptablamssispro.ssp_cam087_spro,
                                          Ssp_cam088_spro = sptablamssispro.ssp_cam088_spro,
                                          Ssp_cam089_spro = sptablamssispro.ssp_cam089_spro,
                                          Ssp_cam090_spro = sptablamssispro.ssp_cam090_spro,
                                          Ssp_cam091_spro = (DateTime)sptablamssispro.ssp_cam091_spro,
                                          Ssp_cam092_spro = sptablamssispro.ssp_cam092_spro,
                                          Ssp_cam093_spro = (DateTime)sptablamssispro.ssp_cam093_spro,
                                          Ssp_cam094_spro = sptablamssispro.ssp_cam094_spro,
                                          Ssp_cam095_spro = sptablamssispro.ssp_cam095_spro,
                                          Ssp_cam096_spro = (DateTime)sptablamssispro.ssp_cam096_spro,
                                          Ssp_cam097_spro = sptablamssispro.ssp_cam097_spro,
                                          Ssp_cam098_spro = sptablamssispro.ssp_cam098_spro,
                                          Ssp_cam099_spro = (DateTime)sptablamssispro.ssp_cam099_spro,
                                          Ssp_cam100_spro = (DateTime)sptablamssispro.ssp_cam100_spro,
                                          Ssp_cam101_spro = sptablamssispro.ssp_cam101_spro,
                                          Ssp_cam102_spro = sptablamssispro.ssp_cam102_spro,
                                          Ssp_cam103_spro = (DateTime)sptablamssispro.ssp_cam103_spro,
                                          Ssp_cam104_spro = (int)sptablamssispro.ssp_cam104_spro,
                                          Ssp_cam105_spro = (DateTime)sptablamssispro.ssp_cam105_spro,
                                          Ssp_cam106_spro = (DateTime)sptablamssispro.ssp_cam106_spro,
                                          Ssp_cam107_spro = (int)sptablamssispro.ssp_cam107_spro,
                                          Ssp_cam108_spro = (DateTime)sptablamssispro.ssp_cam108_spro,
                                          Ssp_cam109_spro = (int)sptablamssispro.ssp_cam109_spro,
                                          Ssp_cam110_spro = (DateTime)sptablamssispro.ssp_cam110_spro,
                                          Ssp_cam111_spro = (DateTime)sptablamssispro.ssp_cam111_spro,
                                          Ssp_cam112_spro = (DateTime)sptablamssispro.ssp_cam112_spro,
                                          Ssp_cam113_spro = sptablamssispro.ssp_cam113_spro,
                                          Ssp_cam114_spro = sptablamssispro.ssp_cam114_spro,
                                          Ssp_cam115_spro = sptablamssispro.ssp_cam115_spro,
                                          Ssp_cam116_spro = sptablamssispro.ssp_cam116_spro,
                                          Ssp_cam117_spro = sptablamssispro.ssp_cam117_spro,
                                          Ssp_cam118_spro = (DateTime)sptablamssispro.ssp_cam118_spro,
                                          Ssp_consec_spro = (int)sptablamssispro.ssp_consec_spro,
                                          Sia_nomusu_usua = usua.sia_nomusu_usua,
                                          Sia_deseps_teps = teps.sia_deseps_teps,
                                          Ssp_desocu_ciuo = ciuo.ssp_desocu_ciuo,
                                      };
                    return lobConsulta.ToList();
                }
                else
                {
                    var lobConsulta = from sptablamssispro in _context.Sptablamssispro
                                      join siausuarioatend in _context.Siausuarioatend on sptablamssispro.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                      join siatablaeps in _context.Siatablaeps on sptablamssispro.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                      join spocupacionciuo in _context.Spocupacionciuo on sptablamssispro.ssp_codocu_ciuo equals spocupacionciuo.ssp_codocu_ciuo into tmspocupacionciuo
                                      from usua in tmsiausuarioatend.DefaultIfEmpty()
                                      from teps in tmsiatablaeps.DefaultIfEmpty()
                                      from ciuo in tmspocupacionciuo.DefaultIfEmpty()
                                      where sptablamssispro.ssp_cam001_spro == tcrBuscar
                                      select new ModeloSspSISPRO
                                      {
                                          Sia_idesec_usua = sptablamssispro.sia_idesec_usua,
                                          Sia_nroide_usua = sptablamssispro.sia_nroide_usua,
                                          Sia_codeps_teps = sptablamssispro.sia_codeps_teps,
                                          Ssp_cam000_spro = sptablamssispro.ssp_cam000_spro,
                                          Ssp_cam001_spro = sptablamssispro.ssp_cam001_spro,
                                          Ssp_cam002_spro = sptablamssispro.ssp_cam002_spro,
                                          Ssp_cam003_spro = sptablamssispro.ssp_cam003_spro,
                                          Ssp_cam004_spro = sptablamssispro.ssp_cam004_spro,
                                          Ssp_cam005_spro = sptablamssispro.ssp_cam005_spro,
                                          Ssp_cam006_spro = sptablamssispro.ssp_cam006_spro,
                                          Ssp_cam007_spro = sptablamssispro.ssp_cam007_spro,
                                          Ssp_cam008_spro = sptablamssispro.ssp_cam008_spro,
                                          Ssp_cam009_spro = (DateTime)sptablamssispro.ssp_cam009_spro,
                                          Ssp_cam010_spro = sptablamssispro.ssp_cam010_spro,
                                          Ssp_cam011_spro = sptablamssispro.ssp_cam011_spro,
                                          Ssp_codocu_ciuo = sptablamssispro.ssp_codocu_ciuo,
                                          Ssp_cam013_spro = sptablamssispro.ssp_cam013_spro,
                                          Ssp_cam014_spro = sptablamssispro.ssp_cam014_spro,
                                          Ssp_cam015_spro = sptablamssispro.ssp_cam015_spro,
                                          Ssp_cam016_spro = sptablamssispro.ssp_cam016_spro,
                                          Ssp_cam017_spro = sptablamssispro.ssp_cam017_spro,
                                          Ssp_cam018_spro = sptablamssispro.ssp_cam018_spro,
                                          Ssp_cam019_spro = sptablamssispro.ssp_cam019_spro,
                                          Ssp_cam020_spro = sptablamssispro.ssp_cam020_spro,
                                          Ssp_cam021_spro = sptablamssispro.ssp_cam021_spro,
                                          Ssp_cam022_spro = sptablamssispro.ssp_cam022_spro,
                                          Ssp_cam023_spro = sptablamssispro.ssp_cam023_spro,
                                          Ssp_cam024_spro = sptablamssispro.ssp_cam024_spro,
                                          Ssp_cam025_spro = sptablamssispro.ssp_cam025_spro,
                                          Ssp_cam026_spro = sptablamssispro.ssp_cam026_spro,
                                          Ssp_cam027_spro = sptablamssispro.ssp_cam027_spro,
                                          Ssp_cam028_spro = sptablamssispro.ssp_cam028_spro,
                                          Ssp_cam029_spro = (DateTime)sptablamssispro.ssp_cam029_spro,
                                          Ssp_cam030_spro = (int)sptablamssispro.ssp_cam030_spro,
                                          Ssp_cam031_spro = (DateTime)sptablamssispro.ssp_cam031_spro,
                                          Ssp_cam032_spro = (int)sptablamssispro.ssp_cam032_spro,
                                          Ssp_cam033_spro = (DateTime)sptablamssispro.ssp_cam033_spro,
                                          Ssp_cam034_spro = (int)sptablamssispro.ssp_cam034_spro,
                                          Ssp_cam035_spro = sptablamssispro.ssp_cam035_spro,
                                          Ssp_cam036_spro = sptablamssispro.ssp_cam036_spro,
                                          Ssp_cam037_spro = sptablamssispro.ssp_cam037_spro,
                                          Ssp_cam038_spro = sptablamssispro.ssp_cam038_spro,
                                          Ssp_cam039_spro = sptablamssispro.ssp_cam039_spro,
                                          Ssp_cam040_spro = sptablamssispro.ssp_cam040_spro,
                                          Ssp_cam041_spro = sptablamssispro.ssp_cam041_spro,
                                          Ssp_cam042_spro = sptablamssispro.ssp_cam042_spro,
                                          Ssp_cam043_spro = sptablamssispro.ssp_cam043_spro,
                                          Ssp_cam044_spro = sptablamssispro.ssp_cam044_spro,
                                          Ssp_cam045_spro = sptablamssispro.ssp_cam045_spro,
                                          Ssp_cam046_spro = sptablamssispro.ssp_cam046_spro,
                                          Ssp_cam047_spro = sptablamssispro.ssp_cam047_spro,
                                          Ssp_cam048_spro = sptablamssispro.ssp_cam048_spro,
                                          Ssp_cam049_spro = (DateTime)sptablamssispro.ssp_cam049_spro,
                                          Ssp_cam050_spro = (DateTime)sptablamssispro.ssp_cam050_spro,
                                          Ssp_cam051_spro = (DateTime)sptablamssispro.ssp_cam051_spro,
                                          Ssp_cam052_spro = (DateTime)sptablamssispro.ssp_cam052_spro,
                                          Ssp_cam053_spro = (DateTime)sptablamssispro.ssp_cam053_spro,
                                          Ssp_cam054_spro = sptablamssispro.ssp_cam054_spro,
                                          Ssp_cam055_spro = (DateTime)sptablamssispro.ssp_cam055_spro,
                                          Ssp_cam056_spro = (DateTime)sptablamssispro.ssp_cam056_spro,
                                          Ssp_cam057_spro = (int)sptablamssispro.ssp_cam057_spro,
                                          Ssp_cam058_spro = (DateTime)sptablamssispro.ssp_cam058_spro,
                                          Ssp_cam059_spro = sptablamssispro.ssp_cam059_spro,
                                          Ssp_cam060_spro = sptablamssispro.ssp_cam060_spro,
                                          Ssp_cam061_spro = sptablamssispro.ssp_cam061_spro,
                                          Ssp_cam062_spro = (DateTime)sptablamssispro.ssp_cam062_spro,
                                          Ssp_cam063_spro = (DateTime)sptablamssispro.ssp_cam063_spro,
                                          Ssp_cam064_spro = (DateTime)sptablamssispro.ssp_cam064_spro,
                                          Ssp_cam065_spro = (DateTime)sptablamssispro.ssp_cam065_spro,
                                          Ssp_cam066_spro = (DateTime)sptablamssispro.ssp_cam066_spro,
                                          Ssp_cam067_spro = (DateTime)sptablamssispro.ssp_cam067_spro,
                                          Ssp_cam068_spro = (DateTime)sptablamssispro.ssp_cam068_spro,
                                          Ssp_cam069_spro = (DateTime)sptablamssispro.ssp_cam069_spro,
                                          Ssp_cam070_spro = sptablamssispro.ssp_cam070_spro,
                                          Ssp_cam071_spro = sptablamssispro.ssp_cam071_spro,
                                          Ssp_cam072_spro = (DateTime)sptablamssispro.ssp_cam072_spro,
                                          Ssp_cam073_spro = (DateTime)sptablamssispro.ssp_cam073_spro,
                                          Ssp_cam074_spro = (int)sptablamssispro.ssp_cam074_spro,
                                          Ssp_cam075_spro = (DateTime)sptablamssispro.ssp_cam075_spro,
                                          Ssp_cam076_spro = (DateTime)sptablamssispro.ssp_cam076_spro,
                                          Ssp_cam077_spro = sptablamssispro.ssp_cam077_spro,
                                          Ssp_cam078_spro = (DateTime)sptablamssispro.ssp_cam078_spro,
                                          Ssp_cam079_spro = sptablamssispro.ssp_cam079_spro,
                                          Ssp_cam080_spro = (DateTime)sptablamssispro.ssp_cam080_spro,
                                          Ssp_cam081_spro = sptablamssispro.ssp_cam081_spro,
                                          Ssp_cam082_spro = (DateTime)sptablamssispro.ssp_cam082_spro,
                                          Ssp_cam083_spro = sptablamssispro.ssp_cam083_spro,
                                          Ssp_cam084_spro = (DateTime)sptablamssispro.ssp_cam084_spro,
                                          Ssp_cam085_spro = sptablamssispro.ssp_cam085_spro,
                                          Ssp_cam086_spro = sptablamssispro.ssp_cam086_spro,
                                          Ssp_cam087_spro = (DateTime)sptablamssispro.ssp_cam087_spro,
                                          Ssp_cam088_spro = sptablamssispro.ssp_cam088_spro,
                                          Ssp_cam089_spro = sptablamssispro.ssp_cam089_spro,
                                          Ssp_cam090_spro = sptablamssispro.ssp_cam090_spro,
                                          Ssp_cam091_spro = (DateTime)sptablamssispro.ssp_cam091_spro,
                                          Ssp_cam092_spro = sptablamssispro.ssp_cam092_spro,
                                          Ssp_cam093_spro = (DateTime)sptablamssispro.ssp_cam093_spro,
                                          Ssp_cam094_spro = sptablamssispro.ssp_cam094_spro,
                                          Ssp_cam095_spro = sptablamssispro.ssp_cam095_spro,
                                          Ssp_cam096_spro = (DateTime)sptablamssispro.ssp_cam096_spro,
                                          Ssp_cam097_spro = sptablamssispro.ssp_cam097_spro,
                                          Ssp_cam098_spro = sptablamssispro.ssp_cam098_spro,
                                          Ssp_cam099_spro = (DateTime)sptablamssispro.ssp_cam099_spro,
                                          Ssp_cam100_spro = (DateTime)sptablamssispro.ssp_cam100_spro,
                                          Ssp_cam101_spro = sptablamssispro.ssp_cam101_spro,
                                          Ssp_cam102_spro = sptablamssispro.ssp_cam102_spro,
                                          Ssp_cam103_spro = (DateTime)sptablamssispro.ssp_cam103_spro,
                                          Ssp_cam104_spro = (int)sptablamssispro.ssp_cam104_spro,
                                          Ssp_cam105_spro = (DateTime)sptablamssispro.ssp_cam105_spro,
                                          Ssp_cam106_spro = (DateTime)sptablamssispro.ssp_cam106_spro,
                                          Ssp_cam107_spro = (int)sptablamssispro.ssp_cam107_spro,
                                          Ssp_cam108_spro = (DateTime)sptablamssispro.ssp_cam108_spro,
                                          Ssp_cam109_spro = (int)sptablamssispro.ssp_cam109_spro,
                                          Ssp_cam110_spro = (DateTime)sptablamssispro.ssp_cam110_spro,
                                          Ssp_cam111_spro = (DateTime)sptablamssispro.ssp_cam111_spro,
                                          Ssp_cam112_spro = (DateTime)sptablamssispro.ssp_cam112_spro,
                                          Ssp_cam113_spro = sptablamssispro.ssp_cam113_spro,
                                          Ssp_cam114_spro = sptablamssispro.ssp_cam114_spro,
                                          Ssp_cam115_spro = sptablamssispro.ssp_cam115_spro,
                                          Ssp_cam116_spro = sptablamssispro.ssp_cam116_spro,
                                          Ssp_cam117_spro = sptablamssispro.ssp_cam117_spro,
                                          Ssp_cam118_spro = (DateTime)sptablamssispro.ssp_cam118_spro,
                                          Ssp_consec_spro = (int)sptablamssispro.ssp_consec_spro,
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
    /// Descripcion para la Vista de  la tabla: sptablanssispro
    /// </summary>
    public class ModeloSspNsSISPRO : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _ssp_idesec_sprn;
        private String _ssp_codper_peri;
        private String _ssp_mesper_peri;
        private String _ssp_anoper_peri;
        private String _ssp_llaper_sprn;
        private String _ssp_llaloc_sprn;
        private String _sia_idesec_usua;
        private String _sia_nroide_usua;
        private String _sia_codeps_teps;
        private String _ssp_cam000_spro;
        private String _ssp_cam001_spro;
        private String _ssp_cam002_spro;
        private String _ssp_cam003_spro;
        private String _ssp_cam004_spro;
        private String _ssp_cam005_spro;
        private String _ssp_cam006_spro;
        private String _ssp_cam007_spro;
        private String _ssp_cam008_spro;
        private DateTime _ssp_cam009_spro;
        private String _ssp_cam010_spro;
        private String _ssp_cam011_spro;
        private String _ssp_codocu_ciuo;
        private String _ssp_cam013_spro;
        private String _ssp_cam014_spro;
        private String _ssp_cam015_spro;
        private String _ssp_cam016_spro;
        private String _ssp_cam017_spro;
        private String _ssp_cam018_spro;
        private String _ssp_cam019_spro;
        private String _ssp_cam020_spro;
        private String _ssp_cam021_spro;
        private String _ssp_cam022_spro;
        private String _ssp_cam023_spro;
        private String _ssp_cam024_spro;
        private String _ssp_cam025_spro;
        private String _ssp_cam026_spro;
        private String _ssp_cam027_spro;
        private String _ssp_cam028_spro;
        private DateTime _ssp_cam029_spro;
        private int _ssp_cam030_spro;
        private DateTime _ssp_cam031_spro;
        private int _ssp_cam032_spro;
        private DateTime _ssp_cam033_spro;
        private int _ssp_cam034_spro;
        private String _ssp_cam035_spro;
        private String _ssp_cam036_spro;
        private String _ssp_cam037_spro;
        private String _ssp_cam038_spro;
        private String _ssp_cam039_spro;
        private String _ssp_cam040_spro;
        private String _ssp_cam041_spro;
        private String _ssp_cam042_spro;
        private String _ssp_cam043_spro;
        private String _ssp_cam044_spro;
        private String _ssp_cam045_spro;
        private String _ssp_cam046_spro;
        private String _ssp_cam047_spro;
        private String _ssp_cam048_spro;
        private DateTime _ssp_cam049_spro;
        private DateTime _ssp_cam050_spro;
        private DateTime _ssp_cam051_spro;
        private DateTime _ssp_cam052_spro;
        private DateTime _ssp_cam053_spro;
        private String _ssp_cam054_spro;
        private DateTime _ssp_cam055_spro;
        private DateTime _ssp_cam056_spro;
        private int _ssp_cam057_spro;
        private DateTime _ssp_cam058_spro;
        private String _ssp_cam059_spro;
        private String _ssp_cam060_spro;
        private String _ssp_cam061_spro;
        private DateTime _ssp_cam062_spro;
        private DateTime _ssp_cam063_spro;
        private DateTime _ssp_cam064_spro;
        private DateTime _ssp_cam065_spro;
        private DateTime _ssp_cam066_spro;
        private DateTime _ssp_cam067_spro;
        private DateTime _ssp_cam068_spro;
        private DateTime _ssp_cam069_spro;
        private String _ssp_cam070_spro;
        private String _ssp_cam071_spro;
        private DateTime _ssp_cam072_spro;
        private DateTime _ssp_cam073_spro;
        private int _ssp_cam074_spro;
        private DateTime _ssp_cam075_spro;
        private DateTime _ssp_cam076_spro;
        private String _ssp_cam077_spro;
        private DateTime _ssp_cam078_spro;
        private String _ssp_cam079_spro;
        private DateTime _ssp_cam080_spro;
        private String _ssp_cam081_spro;
        private DateTime _ssp_cam082_spro;
        private String _ssp_cam083_spro;
        private DateTime _ssp_cam084_spro;
        private String _ssp_cam085_spro;
        private String _ssp_cam086_spro;
        private DateTime _ssp_cam087_spro;
        private String _ssp_cam088_spro;
        private String _ssp_cam089_spro;
        private String _ssp_cam090_spro;
        private DateTime _ssp_cam091_spro;
        private String _ssp_cam092_spro;
        private DateTime _ssp_cam093_spro;
        private String _ssp_cam094_spro;
        private String _ssp_cam095_spro;
        private DateTime _ssp_cam096_spro;
        private String _ssp_cam097_spro;
        private String _ssp_cam098_spro;
        private DateTime _ssp_cam099_spro;
        private DateTime _ssp_cam100_spro;
        private String _ssp_cam101_spro;
        private String _ssp_cam102_spro;
        private DateTime _ssp_cam103_spro;
        private int _ssp_cam104_spro;
        private DateTime _ssp_cam105_spro;
        private DateTime _ssp_cam106_spro;
        private int _ssp_cam107_spro;
        private DateTime _ssp_cam108_spro;
        private int _ssp_cam109_spro;
        private DateTime _ssp_cam110_spro;
        private DateTime _ssp_cam111_spro;
        private DateTime _ssp_cam112_spro;
        private String _ssp_cam113_spro;
        private String _ssp_cam114_spro;
        private String _ssp_cam115_spro;
        private String _ssp_cam116_spro;
        private String _ssp_cam117_spro;
        private DateTime _ssp_cam118_spro;
        private String _ssp_desper_peri;
        private String _ssp_desocu_ciuo;
        private string _sis_estado_imaen;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Ssp_idesec_sprn: Id único del registro
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablanssispro</para>
        /// <para>CAMPO: Id único del registro</para>
        /// <para>NOMBRE: ssp_idesec_sprn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Id Único del registro novedad
        /// </para>
        /// </summary>
        public String Ssp_idesec_sprn
        {
            get { return _ssp_idesec_sprn; }
            set
            {
                if (_ssp_idesec_sprn == value) return;
                _ssp_idesec_sprn = value;
                OnPropertyChanged("Ssp_idesec_sprn");
            }
        }
        #endregion
        #region Ssp_codper_peri: Código del periodo
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
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
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
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
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
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
        #region Ssp_llaper_sprn: Llave del periodo (año+mes)
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablanssispro</para>
        /// <para>CAMPO: Llave del periodo (año+mes)</para>
        /// <para>NOMBRE: ssp_llaper_sprn (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Llave del periodo (año+mes)
        /// </para>
        /// </summary>
        public String Ssp_llaper_sprn
        {
            get { return _ssp_llaper_sprn; }
            set
            {
                if (_ssp_llaper_sprn == value) return;
                _ssp_llaper_sprn = value;
                OnPropertyChanged("Ssp_llaper_sprn");
            }
        }
        #endregion
        #region Ssp_llaloc_sprn: Llave del periodo (año+mes)
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablanssispro</para>
        /// <para>CAMPO: Llave del periodo (año+mes)</para>
        /// <para>NOMBRE: ssp_llaloc_sprn (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Llave para localizacion del registro  (SIA_IDESEC_USUA+SSP_LLAPER_SPRN)
        /// </para>
        /// </summary>
        public String Ssp_llaloc_sprn
        {
            get { return _ssp_llaloc_sprn; }
            set
            {
                if (_ssp_llaloc_sprn == value) return;
                _ssp_llaloc_sprn = value;
                OnPropertyChanged("Ssp_llaloc_sprn");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
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
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
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
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
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
        #region Ssp_cam000_spro: 0.Tipo De Registro
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 0.Tipo De Registro</para>
        /// <para>NOMBRE: ssp_cam000_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Tipo De Registro
        /// </para>
        /// </summary>
        public String Ssp_cam000_spro
        {
            get { return _ssp_cam000_spro; }
            set
            {
                if (_ssp_cam000_spro == value) return;
                _ssp_cam000_spro = value;
                OnPropertyChanged("Ssp_cam000_spro");
            }
        }
        #endregion
        #region Ssp_cam001_spro: 1.Consecutivo de Registro
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 1.Consecutivo de Registro</para>
        /// <para>NOMBRE: ssp_cam001_spro (char:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Número consecutivo de registros de detalle dentro del archivo.
        /// Inicia en 1 para el primer registro de detalle y va incrementando
        /// de 1 en 1, hasta el final del archivo.
        /// </para>
        /// </summary>
        public String Ssp_cam001_spro
        {
            get { return _ssp_cam001_spro; }
            set
            {
                if (_ssp_cam001_spro == value) return;
                _ssp_cam001_spro = value;
                OnPropertyChanged("Ssp_cam001_spro");
            }
        }
        #endregion
        #region Ssp_cam002_spro: 2.Código de Habilitación IPS primaria
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 2.Código de Habilitación IPS primaria</para>
        /// <para>NOMBRE: ssp_cam002_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud) Si es desconocido registrar 99
        /// </para>
        /// </summary>
        public String Ssp_cam002_spro
        {
            get { return _ssp_cam002_spro; }
            set
            {
                if (_ssp_cam002_spro == value) return;
                _ssp_cam002_spro = value;
                OnPropertyChanged("Ssp_cam002_spro");
            }
        }
        #endregion
        #region Ssp_cam003_spro: 3.Tipo de identificación del usuario
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 3.Tipo de identificación del usuario</para>
        /// <para>NOMBRE: ssp_cam003_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo
        /// para menores con 2 meses o menos de nacidos calculando entre
        /// la fecha de nacimiento y la fecha de corte del reporte.
        /// </para>
        /// </summary>
        public String Ssp_cam003_spro
        {
            get { return _ssp_cam003_spro; }
            set
            {
                if (_ssp_cam003_spro == value) return;
                _ssp_cam003_spro = value;
                OnPropertyChanged("Ssp_cam003_spro");
            }
        }
        #endregion
        #region Ssp_cam004_spro: 4.Numero de identificación del usuario
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 4.Numero de identificación del usuario</para>
        /// <para>NOMBRE: ssp_cam004_spro (char:18)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Número del documento de identificación, de acuerdo con el tipo
        /// de identificación del campo anterior.
        /// </para>
        /// </summary>
        public String Ssp_cam004_spro
        {
            get { return _ssp_cam004_spro; }
            set
            {
                if (_ssp_cam004_spro == value) return;
                _ssp_cam004_spro = value;
                OnPropertyChanged("Ssp_cam004_spro");
            }
        }
        #endregion
        #region Ssp_cam005_spro: 5.Primer apellido del usuario
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 5.Primer apellido del usuario</para>
        /// <para>NOMBRE: ssp_cam005_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public String Ssp_cam005_spro
        {
            get { return _ssp_cam005_spro; }
            set
            {
                if (_ssp_cam005_spro == value) return;
                _ssp_cam005_spro = value;
                OnPropertyChanged("Ssp_cam005_spro");
            }
        }
        #endregion
        #region Ssp_cam006_spro: 6.Segundo apellido del usuario
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 6.Segundo apellido del usuario</para>
        /// <para>NOMBRE: ssp_cam006_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Tenga en cuenta el numeral 1. En caso que el usuario no tenga
        /// segundo apellido o no se tenga este dato Registre NONE, en
        /// mayúscula sostenida.
        /// </para>
        /// </summary>
        public String Ssp_cam006_spro
        {
            get { return _ssp_cam006_spro; }
            set
            {
                if (_ssp_cam006_spro == value) return;
                _ssp_cam006_spro = value;
                OnPropertyChanged("Ssp_cam006_spro");
            }
        }
        #endregion
        #region Ssp_cam007_spro: 7.Primer nombre del usuario
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 7.Primer nombre del usuario</para>
        /// <para>NOMBRE: ssp_cam007_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public String Ssp_cam007_spro
        {
            get { return _ssp_cam007_spro; }
            set
            {
                if (_ssp_cam007_spro == value) return;
                _ssp_cam007_spro = value;
                OnPropertyChanged("Ssp_cam007_spro");
            }
        }
        #endregion
        #region Ssp_cam008_spro: 8.Segundo nombre del usuario
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 8.Segundo nombre del usuario</para>
        /// <para>NOMBRE: ssp_cam008_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Segundo nombre del usuario. Tenga en cuenta el numeral 1. En
        /// caso que el usuario no tenga segundo apellido o no se tenga
        /// este dato Registre NONE, en mayúscula sostenida.
        /// </para>
        /// </summary>
        public String Ssp_cam008_spro
        {
            get { return _ssp_cam008_spro; }
            set
            {
                if (_ssp_cam008_spro == value) return;
                _ssp_cam008_spro = value;
                OnPropertyChanged("Ssp_cam008_spro");
            }
        }
        #endregion
        #region Ssp_cam009_spro: 9.Fecha de Nacimiento
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 9.Fecha de Nacimiento</para>
        /// <para>NOMBRE: ssp_cam009_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Fecha de Nacimiento. AAAA-MM-DD
        /// </para>
        /// </summary>
        public DateTime Ssp_cam009_spro
        {
            get { return _ssp_cam009_spro; }
            set
            {
                if (_ssp_cam009_spro == value) return;
                _ssp_cam009_spro = value;
                OnPropertyChanged("Ssp_cam009_spro");
            }
        }
        #endregion
        #region Ssp_cam010_spro: 10.Sexo
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 10.Sexo</para>
        /// <para>NOMBRE: ssp_cam010_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Sexo. M - Masculino F - Femenino
        /// </para>
        /// </summary>
        public String Ssp_cam010_spro
        {
            get { return _ssp_cam010_spro; }
            set
            {
                if (_ssp_cam010_spro == value) return;
                _ssp_cam010_spro = value;
                OnPropertyChanged("Ssp_cam010_spro");
            }
        }
        #endregion
        #region Ssp_cam011_spro: 11.Codigo pertenencia étnica
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 11.Codigo pertenencia étnica</para>
        /// <para>NOMBRE: ssp_cam011_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo pertenencia etnica. Registre según lo reporte el usuario:
        /// 1-Indígena 2-ROM (gitano)3-Raizal etc
        /// </para>
        /// </summary>
        public String Ssp_cam011_spro
        {
            get { return _ssp_cam011_spro; }
            set
            {
                if (_ssp_cam011_spro == value) return;
                _ssp_cam011_spro = value;
                OnPropertyChanged("Ssp_cam011_spro");
            }
        }
        #endregion
        #region Ssp_codocu_ciuo: 12.Codigo de ocupación
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
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
        #region Ssp_cam013_spro: 13.Codigo de nivel educativo
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 13.Codigo de nivel educativo</para>
        /// <para>NOMBRE: ssp_cam013_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Registre según lo reporte el usuario: 1- No Definido 2- Preescolar
        /// 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc
        /// </para>
        /// </summary>
        public String Ssp_cam013_spro
        {
            get { return _ssp_cam013_spro; }
            set
            {
                if (_ssp_cam013_spro == value) return;
                _ssp_cam013_spro = value;
                OnPropertyChanged("Ssp_cam013_spro");
            }
        }
        #endregion
        #region Ssp_cam014_spro: 14.Gestacion
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 14.Gestacion</para>
        /// <para>NOMBRE: ssp_cam014_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam014_spro
        {
            get { return _ssp_cam014_spro; }
            set
            {
                if (_ssp_cam014_spro == value) return;
                _ssp_cam014_spro = value;
                OnPropertyChanged("Ssp_cam014_spro");
            }
        }
        #endregion
        #region Ssp_cam015_spro: 15.Sifilis Gestacional o congénita
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 15.Sifilis Gestacional o congénita</para>
        /// <para>NOMBRE: ssp_cam015_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// 0- No 1- Si es mujer con sífilis gestacional 2- Si es recién
        /// nacido con sífilis congénita 3- No aplica 4- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam015_spro
        {
            get { return _ssp_cam015_spro; }
            set
            {
                if (_ssp_cam015_spro == value) return;
                _ssp_cam015_spro = value;
                OnPropertyChanged("Ssp_cam015_spro");
            }
        }
        #endregion
        #region Ssp_cam016_spro: 16.Hipertension Inducida por la Gestació
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 16.Hipertension Inducida por la Gestació</para>
        /// <para>NOMBRE: ssp_cam016_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Hipertension Inducida por la Gestacion 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam016_spro
        {
            get { return _ssp_cam016_spro; }
            set
            {
                if (_ssp_cam016_spro == value) return;
                _ssp_cam016_spro = value;
                OnPropertyChanged("Ssp_cam016_spro");
            }
        }
        #endregion
        #region Ssp_cam017_spro: 17.Hipotiroidismo Congénito
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 17.Hipotiroidismo Congénito</para>
        /// <para>NOMBRE: ssp_cam017_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Hipotiroidismo Congenito 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam017_spro
        {
            get { return _ssp_cam017_spro; }
            set
            {
                if (_ssp_cam017_spro == value) return;
                _ssp_cam017_spro = value;
                OnPropertyChanged("Ssp_cam017_spro");
            }
        }
        #endregion
        #region Ssp_cam018_spro: 18.Sintomatico Respiratorio
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 18.Sintomatico Respiratorio</para>
        /// <para>NOMBRE: ssp_cam018_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Sintomatico Respiratorio 0- No 1- Si 2- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam018_spro
        {
            get { return _ssp_cam018_spro; }
            set
            {
                if (_ssp_cam018_spro == value) return;
                _ssp_cam018_spro = value;
                OnPropertyChanged("Ssp_cam018_spro");
            }
        }
        #endregion
        #region Ssp_cam019_spro: 19.Tuberculosis Multidrogoresistente
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 19.Tuberculosis Multidrogoresistente</para>
        /// <para>NOMBRE: ssp_cam019_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Tuberculosis Multidrogoresistente 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam019_spro
        {
            get { return _ssp_cam019_spro; }
            set
            {
                if (_ssp_cam019_spro == value) return;
                _ssp_cam019_spro = value;
                OnPropertyChanged("Ssp_cam019_spro");
            }
        }
        #endregion
        #region Ssp_cam020_spro: 20.Lepra
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 20.Lepra</para>
        /// <para>NOMBRE: ssp_cam020_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Lepra 0- No 1- Pausibacilar 2- Multibacilar 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam020_spro
        {
            get { return _ssp_cam020_spro; }
            set
            {
                if (_ssp_cam020_spro == value) return;
                _ssp_cam020_spro = value;
                OnPropertyChanged("Ssp_cam020_spro");
            }
        }
        #endregion
        #region Ssp_cam021_spro: 21.Obesidad o Desnutrición Proteico Caló
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 21.Obesidad o Desnutrición Proteico Caló</para>
        /// <para>NOMBRE: ssp_cam021_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Obesidad o Desnutricion Proteico Calorica 0- No 1- Si es Obesidad
        /// 2- Si es Desnutrición Proteico Calórica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam021_spro
        {
            get { return _ssp_cam021_spro; }
            set
            {
                if (_ssp_cam021_spro == value) return;
                _ssp_cam021_spro = value;
                OnPropertyChanged("Ssp_cam021_spro");
            }
        }
        #endregion
        #region Ssp_cam022_spro: 22.Mujer Victima de Maltrato
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 22.Mujer Victima de Maltrato</para>
        /// <para>NOMBRE: ssp_cam022_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Mujer Victima de Maltrato 0- No 1- Si es Mujer víctima del
        /// maltrato 2- Si es Menor víctima del maltrato 3- No aplica 4-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam022_spro
        {
            get { return _ssp_cam022_spro; }
            set
            {
                if (_ssp_cam022_spro == value) return;
                _ssp_cam022_spro = value;
                OnPropertyChanged("Ssp_cam022_spro");
            }
        }
        #endregion
        #region Ssp_cam023_spro: 23.Victima de Violencia Sexual
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 23.Victima de Violencia Sexual</para>
        /// <para>NOMBRE: ssp_cam023_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Victima de Violencia Sexual 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam023_spro
        {
            get { return _ssp_cam023_spro; }
            set
            {
                if (_ssp_cam023_spro == value) return;
                _ssp_cam023_spro = value;
                OnPropertyChanged("Ssp_cam023_spro");
            }
        }
        #endregion
        #region Ssp_cam024_spro: 24.Infecciones de Trasmisión Sexual
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 24.Infecciones de Trasmisión Sexual</para>
        /// <para>NOMBRE: ssp_cam024_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Infecciones de Trasmision Sexual 0- No 1- Si 2- No aplica 3-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam024_spro
        {
            get { return _ssp_cam024_spro; }
            set
            {
                if (_ssp_cam024_spro == value) return;
                _ssp_cam024_spro = value;
                OnPropertyChanged("Ssp_cam024_spro");
            }
        }
        #endregion
        #region Ssp_cam025_spro: 25.Enfermedad Mental
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 25.Enfermedad Mental</para>
        /// <para>NOMBRE: ssp_cam025_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Enfermedad Mental 0- No 1- Si el diagnóstico es Ansiedad 2-
        /// Si el diagnóstico es Depresión 3- Si el diagnóstico es esquizofrenia
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam025_spro
        {
            get { return _ssp_cam025_spro; }
            set
            {
                if (_ssp_cam025_spro == value) return;
                _ssp_cam025_spro = value;
                OnPropertyChanged("Ssp_cam025_spro");
            }
        }
        #endregion
        #region Ssp_cam026_spro: 26.Cancer de Cérvix
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 26.Cancer de Cérvix</para>
        /// <para>NOMBRE: ssp_cam026_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Cancer de Cervix 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam026_spro
        {
            get { return _ssp_cam026_spro; }
            set
            {
                if (_ssp_cam026_spro == value) return;
                _ssp_cam026_spro = value;
                OnPropertyChanged("Ssp_cam026_spro");
            }
        }
        #endregion
        #region Ssp_cam027_spro: 27.Cancer de Seno
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 27.Cancer de Seno</para>
        /// <para>NOMBRE: ssp_cam027_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Cancer de Seno 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam027_spro
        {
            get { return _ssp_cam027_spro; }
            set
            {
                if (_ssp_cam027_spro == value) return;
                _ssp_cam027_spro = value;
                OnPropertyChanged("Ssp_cam027_spro");
            }
        }
        #endregion
        #region Ssp_cam028_spro: 28.Fluorosis Dental
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 28.Fluorosis Dental</para>
        /// <para>NOMBRE: ssp_cam028_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Fluorosis Dental 0- No 1- Si 2- No aplica 3- Riego no evaluado
        /// </para>
        /// </summary>
        public String Ssp_cam028_spro
        {
            get { return _ssp_cam028_spro; }
            set
            {
                if (_ssp_cam028_spro == value) return;
                _ssp_cam028_spro = value;
                OnPropertyChanged("Ssp_cam028_spro");
            }
        }
        #endregion
        #region Ssp_cam029_spro: 29.Fecha del Peso
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 29.Fecha del Peso</para>
        /// <para>NOMBRE: ssp_cam029_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam029_spro
        {
            get { return _ssp_cam029_spro; }
            set
            {
                if (_ssp_cam029_spro == value) return;
                _ssp_cam029_spro = value;
                OnPropertyChanged("Ssp_cam029_spro");
            }
        }
        #endregion
        #region Ssp_cam030_spro: 30.Peso en Kilogramos
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 30.Peso en Kilogramos</para>
        /// <para>NOMBRE: ssp_cam030_spro (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Peso en Kilogramos Se registra el dato obtenido de la medición.
        /// Si no se toma registrar 999
        /// </para>
        /// </summary>
        public int Ssp_cam030_spro
        {
            get { return _ssp_cam030_spro; }
            set
            {
                if (_ssp_cam030_spro == value) return;
                _ssp_cam030_spro = value;
                OnPropertyChanged("Ssp_cam030_spro");
            }
        }
        #endregion
        #region Ssp_cam031_spro: 31.Fecha de la Talla
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 31.Fecha de la Talla</para>
        /// <para>NOMBRE: ssp_cam031_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam031_spro
        {
            get { return _ssp_cam031_spro; }
            set
            {
                if (_ssp_cam031_spro == value) return;
                _ssp_cam031_spro = value;
                OnPropertyChanged("Ssp_cam031_spro");
            }
        }
        #endregion
        #region Ssp_cam032_spro: 32.Talla en Centímetros
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 32.Talla en Centímetros</para>
        /// <para>NOMBRE: ssp_cam032_spro (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato obtenido de la medición. Si no se toma
        /// registrar 999
        /// </para>
        /// </summary>
        public int Ssp_cam032_spro
        {
            get { return _ssp_cam032_spro; }
            set
            {
                if (_ssp_cam032_spro == value) return;
                _ssp_cam032_spro = value;
                OnPropertyChanged("Ssp_cam032_spro");
            }
        }
        #endregion
        #region Ssp_cam033_spro: 33.Fecha Probable de Parto
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 33.Fecha Probable de Parto</para>
        /// <para>NOMBRE: ssp_cam033_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam033_spro
        {
            get { return _ssp_cam033_spro; }
            set
            {
                if (_ssp_cam033_spro == value) return;
                _ssp_cam033_spro = value;
                OnPropertyChanged("Ssp_cam033_spro");
            }
        }
        #endregion
        #region Ssp_cam034_spro: 34.Edad Gestacional al Nacer
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 34.Edad Gestacional al Nacer</para>
        /// <para>NOMBRE: ssp_cam034_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato de la edad gestacional en semanas. Si no
        /// tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public int Ssp_cam034_spro
        {
            get { return _ssp_cam034_spro; }
            set
            {
                if (_ssp_cam034_spro == value) return;
                _ssp_cam034_spro = value;
                OnPropertyChanged("Ssp_cam034_spro");
            }
        }
        #endregion
        #region Ssp_cam035_spro: 35.BCG
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 35.BCG</para>
        /// <para>NOMBRE: ssp_cam035_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// BCG Registre el dato de la última dosis aplicada así: 0- RN
        /// 1- Otra Dosis 2- Sin dato 3- No se administra por una Tradición
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam035_spro
        {
            get { return _ssp_cam035_spro; }
            set
            {
                if (_ssp_cam035_spro == value) return;
                _ssp_cam035_spro = value;
                OnPropertyChanged("Ssp_cam035_spro");
            }
        }
        #endregion
        #region Ssp_cam036_spro: 36.Hepatitis B menores de 1 año
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 36.Hepatitis B menores de 1 año</para>
        /// <para>NOMBRE: ssp_cam036_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Hepatitis B menores de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- RN 1- Primera Dosis 2- Segunda Dosis
        /// 3- Tercera Dosis ETC
        /// </para>
        /// </summary>
        public String Ssp_cam036_spro
        {
            get { return _ssp_cam036_spro; }
            set
            {
                if (_ssp_cam036_spro == value) return;
                _ssp_cam036_spro = value;
                OnPropertyChanged("Ssp_cam036_spro");
            }
        }
        #endregion
        #region Ssp_cam037_spro: 37.Pentavalente
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 37.Pentavalente</para>
        /// <para>NOMBRE: ssp_cam037_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Pentavalente Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Sin dato
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam037_spro
        {
            get { return _ssp_cam037_spro; }
            set
            {
                if (_ssp_cam037_spro == value) return;
                _ssp_cam037_spro = value;
                OnPropertyChanged("Ssp_cam037_spro");
            }
        }
        #endregion
        #region Ssp_cam038_spro: 38.Polio
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 38.Polio</para>
        /// <para>NOMBRE: ssp_cam038_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Polio Registre el dato de la última dosis aplicada así: 0-
        /// Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Primer Refuerzo
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam038_spro
        {
            get { return _ssp_cam038_spro; }
            set
            {
                if (_ssp_cam038_spro == value) return;
                _ssp_cam038_spro = value;
                OnPropertyChanged("Ssp_cam038_spro");
            }
        }
        #endregion
        #region Ssp_cam039_spro: 39.DPT menores de 5 años
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 39.DPT menores de 5 años</para>
        /// <para>NOMBRE: ssp_cam039_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// DPT menores de 5 años Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3-
        /// Primer Refuerzo ETC
        /// </para>
        /// </summary>
        public String Ssp_cam039_spro
        {
            get { return _ssp_cam039_spro; }
            set
            {
                if (_ssp_cam039_spro == value) return;
                _ssp_cam039_spro = value;
                OnPropertyChanged("Ssp_cam039_spro");
            }
        }
        #endregion
        #region Ssp_cam040_spro: 40.Rotavirus
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 40.Rotavirus</para>
        /// <para>NOMBRE: ssp_cam040_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Rotavirus Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Sin dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam040_spro
        {
            get { return _ssp_cam040_spro; }
            set
            {
                if (_ssp_cam040_spro == value) return;
                _ssp_cam040_spro = value;
                OnPropertyChanged("Ssp_cam040_spro");
            }
        }
        #endregion
        #region Ssp_cam041_spro: 41.Neumococo
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 41.Neumococo</para>
        /// <para>NOMBRE: ssp_cam041_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Neumococo Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin
        /// dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam041_spro
        {
            get { return _ssp_cam041_spro; }
            set
            {
                if (_ssp_cam041_spro == value) return;
                _ssp_cam041_spro = value;
                OnPropertyChanged("Ssp_cam041_spro");
            }
        }
        #endregion
        #region Ssp_cam042_spro: 42.Influenza Niños
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 42.Influenza Niños</para>
        /// <para>NOMBRE: ssp_cam042_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Influenza Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC
        /// </para>
        /// </summary>
        public String Ssp_cam042_spro
        {
            get { return _ssp_cam042_spro; }
            set
            {
                if (_ssp_cam042_spro == value) return;
                _ssp_cam042_spro = value;
                OnPropertyChanged("Ssp_cam042_spro");
            }
        }
        #endregion
        #region Ssp_cam043_spro: 43.Fiebre Amarilla niños de 1 año
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 43.Fiebre Amarilla niños de 1 año</para>
        /// <para>NOMBRE: ssp_cam043_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fiebre Amarilla niños de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra
        /// por una Tradición ETC
        /// </para>
        /// </summary>
        public String Ssp_cam043_spro
        {
            get { return _ssp_cam043_spro; }
            set
            {
                if (_ssp_cam043_spro == value) return;
                _ssp_cam043_spro = value;
                OnPropertyChanged("Ssp_cam043_spro");
            }
        }
        #endregion
        #region Ssp_cam044_spro: 44.Hepatitis A
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 44.Hepatitis A</para>
        /// <para>NOMBRE: ssp_cam044_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Hepatitis A Registre el dato de la última dosis aplicada así:
        /// 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición
        /// 3- No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public String Ssp_cam044_spro
        {
            get { return _ssp_cam044_spro; }
            set
            {
                if (_ssp_cam044_spro == value) return;
                _ssp_cam044_spro = value;
                OnPropertyChanged("Ssp_cam044_spro");
            }
        }
        #endregion
        #region Ssp_cam045_spro: 45.Triple Viral Niños
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 45.Triple Viral Niños</para>
        /// <para>NOMBRE: ssp_cam045_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Triple Viral Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No
        /// se administra por una Tradición 4- No se administra por una
        /// Condición de Salud ETC
        /// </para>
        /// </summary>
        public String Ssp_cam045_spro
        {
            get { return _ssp_cam045_spro; }
            set
            {
                if (_ssp_cam045_spro == value) return;
                _ssp_cam045_spro = value;
                OnPropertyChanged("Ssp_cam045_spro");
            }
        }
        #endregion
        #region Ssp_cam046_spro: 46.Virus del Papiloma Humano (VPH)
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 46.Virus del Papiloma Humano (VPH)</para>
        /// <para>NOMBRE: ssp_cam046_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Virus del Papiloma Humano (VPH) Registre el dato de la última
        /// dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera
        /// Dosis 3- Sin dato ETC
        /// </para>
        /// </summary>
        public String Ssp_cam046_spro
        {
            get { return _ssp_cam046_spro; }
            set
            {
                if (_ssp_cam046_spro == value) return;
                _ssp_cam046_spro = value;
                OnPropertyChanged("Ssp_cam046_spro");
            }
        }
        #endregion
        #region Ssp_cam047_spro: 47.TD o TT Mujeres en Edad Fértil 15 a 4
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 47.TD o TT Mujeres en Edad Fértil 15 a 4</para>
        /// <para>NOMBRE: ssp_cam047_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato
        /// de la última dosis aplicada así: 0- Primera Dosis 1- Segunda
        /// Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC
        /// </para>
        /// </summary>
        public String Ssp_cam047_spro
        {
            get { return _ssp_cam047_spro; }
            set
            {
                if (_ssp_cam047_spro == value) return;
                _ssp_cam047_spro = value;
                OnPropertyChanged("Ssp_cam047_spro");
            }
        }
        #endregion
        #region Ssp_cam048_spro: 48.Control de Placa Bacteriana
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 48.Control de Placa Bacteriana</para>
        /// <para>NOMBRE: ssp_cam048_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Control de Placa Bacteriana 0- No se realiza por una Tradición
        /// 1- No se realiza por una Condición de Salud 2- No se realiza
        /// por Negación del usuario
        /// </para>
        /// </summary>
        public String Ssp_cam048_spro
        {
            get { return _ssp_cam048_spro; }
            set
            {
                if (_ssp_cam048_spro == value) return;
                _ssp_cam048_spro = value;
                OnPropertyChanged("Ssp_cam048_spro");
            }
        }
        #endregion
        #region Ssp_cam049_spro: 49.Fecha atención parto o cesárea
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 49.Fecha atención parto o cesárea</para>
        /// <para>NOMBRE: ssp_cam049_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam049_spro
        {
            get { return _ssp_cam049_spro; }
            set
            {
                if (_ssp_cam049_spro == value) return;
                _ssp_cam049_spro = value;
                OnPropertyChanged("Ssp_cam049_spro");
            }
        }
        #endregion
        #region Ssp_cam050_spro: 50.Fecha salida de la atención del parto
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 50.Fecha salida de la atención del parto</para>
        /// <para>NOMBRE: ssp_cam050_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Fecha salida de la atencion del parto o cesarea AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam050_spro
        {
            get { return _ssp_cam050_spro; }
            set
            {
                if (_ssp_cam050_spro == value) return;
                _ssp_cam050_spro = value;
                OnPropertyChanged("Ssp_cam050_spro");
            }
        }
        #endregion
        #region Ssp_cam051_spro: 51.Fecha de consejería en Lactancia Mate
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 51.Fecha de consejería en Lactancia Mate</para>
        /// <para>NOMBRE: ssp_cam051_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no se realiza por una
        /// Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam051_spro
        {
            get { return _ssp_cam051_spro; }
            set
            {
                if (_ssp_cam051_spro == value) return;
                _ssp_cam051_spro = value;
                OnPropertyChanged("Ssp_cam051_spro");
            }
        }
        #endregion
        #region Ssp_cam052_spro: 52.Control Recién Nacido
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 52.Control Recién Nacido</para>
        /// <para>NOMBRE: ssp_cam052_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam052_spro
        {
            get { return _ssp_cam052_spro; }
            set
            {
                if (_ssp_cam052_spro == value) return;
                _ssp_cam052_spro = value;
                OnPropertyChanged("Ssp_cam052_spro");
            }
        }
        #endregion
        #region Ssp_cam053_spro: 53.Planificacion Familiar Primera vez
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 53.Planificacion Familiar Primera vez</para>
        /// <para>NOMBRE: ssp_cam053_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam053_spro
        {
            get { return _ssp_cam053_spro; }
            set
            {
                if (_ssp_cam053_spro == value) return;
                _ssp_cam053_spro = value;
                OnPropertyChanged("Ssp_cam053_spro");
            }
        }
        #endregion
        #region Ssp_cam054_spro: 54.Suministro de Método Anticonceptivo
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 54.Suministro de Método Anticonceptivo</para>
        /// <para>NOMBRE: ssp_cam054_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino
        /// 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico
        /// 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam054_spro
        {
            get { return _ssp_cam054_spro; }
            set
            {
                if (_ssp_cam054_spro == value) return;
                _ssp_cam054_spro = value;
                OnPropertyChanged("Ssp_cam054_spro");
            }
        }
        #endregion
        #region Ssp_cam055_spro: 55.Fecha Suministro de Método Anticoncep
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 55.Fecha Suministro de Método Anticoncep</para>
        /// <para>NOMBRE: ssp_cam055_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam055_spro
        {
            get { return _ssp_cam055_spro; }
            set
            {
                if (_ssp_cam055_spro == value) return;
                _ssp_cam055_spro = value;
                OnPropertyChanged("Ssp_cam055_spro");
            }
        }
        #endregion
        #region Ssp_cam056_spro: 56.Control Prenatal de Primera vez
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 56.Control Prenatal de Primera vez</para>
        /// <para>NOMBRE: ssp_cam056_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam056_spro
        {
            get { return _ssp_cam056_spro; }
            set
            {
                if (_ssp_cam056_spro == value) return;
                _ssp_cam056_spro = value;
                OnPropertyChanged("Ssp_cam056_spro");
            }
        }
        #endregion
        #region Ssp_cam057_spro: 57.Control Prenatal
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 57.Control Prenatal</para>
        /// <para>NOMBRE: ssp_cam057_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal Registre el número de controles que ha tenido
        /// en el último período de reporte durante la gestación actual,
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int Ssp_cam057_spro
        {
            get { return _ssp_cam057_spro; }
            set
            {
                if (_ssp_cam057_spro == value) return;
                _ssp_cam057_spro = value;
                OnPropertyChanged("Ssp_cam057_spro");
            }
        }
        #endregion
        #region Ssp_cam058_spro: 58.ultimo Control Prenatal
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 58.ultimo Control Prenatal</para>
        /// <para>NOMBRE: ssp_cam058_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam058_spro
        {
            get { return _ssp_cam058_spro; }
            set
            {
                if (_ssp_cam058_spro == value) return;
                _ssp_cam058_spro = value;
                OnPropertyChanged("Ssp_cam058_spro");
            }
        }
        #endregion
        #region Ssp_cam059_spro: 59.Suministro de acido Fólico en el ulti
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 59.Suministro de acido Fólico en el ulti</para>
        /// <para>NOMBRE: ssp_cam059_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación de
        /// la usuaria 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam059_spro
        {
            get { return _ssp_cam059_spro; }
            set
            {
                if (_ssp_cam059_spro == value) return;
                _ssp_cam059_spro = value;
                OnPropertyChanged("Ssp_cam059_spro");
            }
        }
        #endregion
        #region Ssp_cam060_spro: 60.Suministro de Sulfato Ferroso en el u
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 60.Suministro de Sulfato Ferroso en el u</para>
        /// <para>NOMBRE: ssp_cam060_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam060_spro
        {
            get { return _ssp_cam060_spro; }
            set
            {
                if (_ssp_cam060_spro == value) return;
                _ssp_cam060_spro = value;
                OnPropertyChanged("Ssp_cam060_spro");
            }
        }
        #endregion
        #region Ssp_cam061_spro: 61.Suministro de Carbonato de Calcio en
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 61.Suministro de Carbonato de Calcio en</para>
        /// <para>NOMBRE: ssp_cam061_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam061_spro
        {
            get { return _ssp_cam061_spro; }
            set
            {
                if (_ssp_cam061_spro == value) return;
                _ssp_cam061_spro = value;
                OnPropertyChanged("Ssp_cam061_spro");
            }
        }
        #endregion
        #region Ssp_cam062_spro: 62.Valoracion de la Agudeza Visual
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 62.Valoracion de la Agudeza Visual</para>
        /// <para>NOMBRE: ssp_cam062_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no
        /// se realiza por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam062_spro
        {
            get { return _ssp_cam062_spro; }
            set
            {
                if (_ssp_cam062_spro == value) return;
                _ssp_cam062_spro = value;
                OnPropertyChanged("Ssp_cam062_spro");
            }
        }
        #endregion
        #region Ssp_cam063_spro: 63.Consulta por Oftalmología
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 63.Consulta por Oftalmología</para>
        /// <para>NOMBRE: ssp_cam063_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam063_spro
        {
            get { return _ssp_cam063_spro; }
            set
            {
                if (_ssp_cam063_spro == value) return;
                _ssp_cam063_spro = value;
                OnPropertyChanged("Ssp_cam063_spro");
            }
        }
        #endregion
        #region Ssp_cam064_spro: 64.Fecha Diagnostico Desnutrición Protei
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 64.Fecha Diagnostico Desnutrición Protei</para>
        /// <para>NOMBRE: ssp_cam064_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam064_spro
        {
            get { return _ssp_cam064_spro; }
            set
            {
                if (_ssp_cam064_spro == value) return;
                _ssp_cam064_spro = value;
                OnPropertyChanged("Ssp_cam064_spro");
            }
        }
        #endregion
        #region Ssp_cam065_spro: 65.Consulta Mujer o Menor Victima del Ma
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 65.Consulta Mujer o Menor Victima del Ma</para>
        /// <para>NOMBRE: ssp_cam065_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam065_spro
        {
            get { return _ssp_cam065_spro; }
            set
            {
                if (_ssp_cam065_spro == value) return;
                _ssp_cam065_spro = value;
                OnPropertyChanged("Ssp_cam065_spro");
            }
        }
        #endregion
        #region Ssp_cam066_spro: 66.Consulta Victimas de Violencia Sexual
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 66.Consulta Victimas de Violencia Sexual</para>
        /// <para>NOMBRE: ssp_cam066_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam066_spro
        {
            get { return _ssp_cam066_spro; }
            set
            {
                if (_ssp_cam066_spro == value) return;
                _ssp_cam066_spro = value;
                OnPropertyChanged("Ssp_cam066_spro");
            }
        }
        #endregion
        #region Ssp_cam067_spro: 67.Consulta Nutrición
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 67.Consulta Nutrición</para>
        /// <para>NOMBRE: ssp_cam067_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam067_spro
        {
            get { return _ssp_cam067_spro; }
            set
            {
                if (_ssp_cam067_spro == value) return;
                _ssp_cam067_spro = value;
                OnPropertyChanged("Ssp_cam067_spro");
            }
        }
        #endregion
        #region Ssp_cam068_spro: 68.Consulta de Psicología
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 68.Consulta de Psicología</para>
        /// <para>NOMBRE: ssp_cam068_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam068_spro
        {
            get { return _ssp_cam068_spro; }
            set
            {
                if (_ssp_cam068_spro == value) return;
                _ssp_cam068_spro = value;
                OnPropertyChanged("Ssp_cam068_spro");
            }
        }
        #endregion
        #region Ssp_cam069_spro: 69.Consulta de Crecimiento y Desarrollo
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 69.Consulta de Crecimiento y Desarrollo</para>
        /// <para>NOMBRE: ssp_cam069_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam069_spro
        {
            get { return _ssp_cam069_spro; }
            set
            {
                if (_ssp_cam069_spro == value) return;
                _ssp_cam069_spro = value;
                OnPropertyChanged("Ssp_cam069_spro");
            }
        }
        #endregion
        #region Ssp_cam070_spro: 70.Suministro de Sulfato Ferroso en la u
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 70.Suministro de Sulfato Ferroso en la u</para>
        /// <para>NOMBRE: ssp_cam070_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam070_spro
        {
            get { return _ssp_cam070_spro; }
            set
            {
                if (_ssp_cam070_spro == value) return;
                _ssp_cam070_spro = value;
                OnPropertyChanged("Ssp_cam070_spro");
            }
        }
        #endregion
        #region Ssp_cam071_spro: 71.Suministro de Vitamina A en la ultima
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 71.Suministro de Vitamina A en la ultima</para>
        /// <para>NOMBRE: ssp_cam071_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam071_spro
        {
            get { return _ssp_cam071_spro; }
            set
            {
                if (_ssp_cam071_spro == value) return;
                _ssp_cam071_spro = value;
                OnPropertyChanged("Ssp_cam071_spro");
            }
        }
        #endregion
        #region Ssp_cam072_spro: 72.Consulta de Joven Primera vez
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 72.Consulta de Joven Primera vez</para>
        /// <para>NOMBRE: ssp_cam072_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam072_spro
        {
            get { return _ssp_cam072_spro; }
            set
            {
                if (_ssp_cam072_spro == value) return;
                _ssp_cam072_spro = value;
                OnPropertyChanged("Ssp_cam072_spro");
            }
        }
        #endregion
        #region Ssp_cam073_spro: 73.Consulta de Adulto Primera vez
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 73.Consulta de Adulto Primera vez</para>
        /// <para>NOMBRE: ssp_cam073_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam073_spro
        {
            get { return _ssp_cam073_spro; }
            set
            {
                if (_ssp_cam073_spro == value) return;
                _ssp_cam073_spro = value;
                OnPropertyChanged("Ssp_cam073_spro");
            }
        }
        #endregion
        #region Ssp_cam074_spro: 74.Preservativos entregados a pacientes
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 74.Preservativos entregados a pacientes</para>
        /// <para>NOMBRE: ssp_cam074_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 84</para>
        /// <para>DESCRIPCION:
        /// Preservativos entregados a pacientes con ITS Registre el número
        /// de Preservativos entregados durante el período de reporte.
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// ETC
        /// </para>
        /// </summary>
        public int Ssp_cam074_spro
        {
            get { return _ssp_cam074_spro; }
            set
            {
                if (_ssp_cam074_spro == value) return;
                _ssp_cam074_spro = value;
                OnPropertyChanged("Ssp_cam074_spro");
            }
        }
        #endregion
        #region Ssp_cam075_spro: 75.Asesoria Pre test Elisa para VIH
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 75.Asesoria Pre test Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam075_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 85</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam075_spro
        {
            get { return _ssp_cam075_spro; }
            set
            {
                if (_ssp_cam075_spro == value) return;
                _ssp_cam075_spro = value;
                OnPropertyChanged("Ssp_cam075_spro");
            }
        }
        #endregion
        #region Ssp_cam076_spro: 76.Asesoria Pos test Elisa para VIH
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 76.Asesoria Pos test Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam076_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 86</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam076_spro
        {
            get { return _ssp_cam076_spro; }
            set
            {
                if (_ssp_cam076_spro == value) return;
                _ssp_cam076_spro = value;
                OnPropertyChanged("Ssp_cam076_spro");
            }
        }
        #endregion
        #region Ssp_cam077_spro: 77.Paciente con Diagnostico de: Ansiedad
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 77.Paciente con Diagnostico de: Ansiedad</para>
        /// <para>NOMBRE: ssp_cam077_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 87</para>
        /// <para>DESCRIPCION:
        /// 0- No recibió atención por tener una tradición que se lo impide
        /// 1- No recibió atención por una condición de salud 2- No recibió
        /// atención por negación del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam077_spro
        {
            get { return _ssp_cam077_spro; }
            set
            {
                if (_ssp_cam077_spro == value) return;
                _ssp_cam077_spro = value;
                OnPropertyChanged("Ssp_cam077_spro");
            }
        }
        #endregion
        #region Ssp_cam078_spro: 78.Fecha Antígeno de Superficie Hepatiti
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 78.Fecha Antígeno de Superficie Hepatiti</para>
        /// <para>NOMBRE: ssp_cam078_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 88</para>
        /// <para>DESCRIPCION:
        /// Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam078_spro
        {
            get { return _ssp_cam078_spro; }
            set
            {
                if (_ssp_cam078_spro == value) return;
                _ssp_cam078_spro = value;
                OnPropertyChanged("Ssp_cam078_spro");
            }
        }
        #endregion
        #region Ssp_cam079_spro: 79.Resultado Antígeno de Superficie Hepa
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 79.Resultado Antígeno de Superficie Hepa</para>
        /// <para>NOMBRE: ssp_cam079_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 89</para>
        /// <para>DESCRIPCION:
        /// Resultado Antigeno de Superficie Hepatitis B en Gestantes 0-
        /// Negativo 1- Positivo 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam079_spro
        {
            get { return _ssp_cam079_spro; }
            set
            {
                if (_ssp_cam079_spro == value) return;
                _ssp_cam079_spro = value;
                OnPropertyChanged("Ssp_cam079_spro");
            }
        }
        #endregion
        #region Ssp_cam080_spro: 80.Fecha Serología para Sífilis
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 80.Fecha Serología para Sífilis</para>
        /// <para>NOMBRE: ssp_cam080_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 90</para>
        /// <para>DESCRIPCION:
        /// Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam080_spro
        {
            get { return _ssp_cam080_spro; }
            set
            {
                if (_ssp_cam080_spro == value) return;
                _ssp_cam080_spro = value;
                OnPropertyChanged("Ssp_cam080_spro");
            }
        }
        #endregion
        #region Ssp_cam081_spro: 81.Resultado Serología para Sífilis
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 81.Resultado Serología para Sífilis</para>
        /// <para>NOMBRE: ssp_cam081_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 91</para>
        /// <para>DESCRIPCION:
        /// Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva
        /// 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam081_spro
        {
            get { return _ssp_cam081_spro; }
            set
            {
                if (_ssp_cam081_spro == value) return;
                _ssp_cam081_spro = value;
                OnPropertyChanged("Ssp_cam081_spro");
            }
        }
        #endregion
        #region Ssp_cam082_spro: 82.Fecha de Toma de Elisa para VIH
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 82.Fecha de Toma de Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam082_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 92</para>
        /// <para>DESCRIPCION:
        /// Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam082_spro
        {
            get { return _ssp_cam082_spro; }
            set
            {
                if (_ssp_cam082_spro == value) return;
                _ssp_cam082_spro = value;
                OnPropertyChanged("Ssp_cam082_spro");
            }
        }
        #endregion
        #region Ssp_cam083_spro: 83.Resultado Elisa para VIH
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 83.Resultado Elisa para VIH</para>
        /// <para>NOMBRE: ssp_cam083_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 93</para>
        /// <para>DESCRIPCION:
        /// Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado
        /// 3- Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam083_spro
        {
            get { return _ssp_cam083_spro; }
            set
            {
                if (_ssp_cam083_spro == value) return;
                _ssp_cam083_spro = value;
                OnPropertyChanged("Ssp_cam083_spro");
            }
        }
        #endregion
        #region Ssp_cam084_spro: 84.Fecha TSH Neonatal
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 84.Fecha TSH Neonatal</para>
        /// <para>NOMBRE: ssp_cam084_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 94</para>
        /// <para>DESCRIPCION:
        /// Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam084_spro
        {
            get { return _ssp_cam084_spro; }
            set
            {
                if (_ssp_cam084_spro == value) return;
                _ssp_cam084_spro = value;
                OnPropertyChanged("Ssp_cam084_spro");
            }
        }
        #endregion
        #region Ssp_cam085_spro: 85.Resultado de TSH Neonatal
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 85.Resultado de TSH Neonatal</para>
        /// <para>NOMBRE: ssp_cam085_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 95</para>
        /// <para>DESCRIPCION:
        /// Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato
        /// 3- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam085_spro
        {
            get { return _ssp_cam085_spro; }
            set
            {
                if (_ssp_cam085_spro == value) return;
                _ssp_cam085_spro = value;
                OnPropertyChanged("Ssp_cam085_spro");
            }
        }
        #endregion
        #region Ssp_cam086_spro: 86.Tamizaje Cáncer de Cuello Uterino
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 86.Tamizaje Cáncer de Cuello Uterino</para>
        /// <para>NOMBRE: ssp_cam086_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 96</para>
        /// <para>DESCRIPCION:
        /// Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public String Ssp_cam086_spro
        {
            get { return _ssp_cam086_spro; }
            set
            {
                if (_ssp_cam086_spro == value) return;
                _ssp_cam086_spro = value;
                OnPropertyChanged("Ssp_cam086_spro");
            }
        }
        #endregion
        #region Ssp_cam087_spro: 87.Citologia Cervico uterina
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 87.Citologia Cervico uterina</para>
        /// <para>NOMBRE: ssp_cam087_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 97</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam087_spro
        {
            get { return _ssp_cam087_spro; }
            set
            {
                if (_ssp_cam087_spro == value) return;
                _ssp_cam087_spro = value;
                OnPropertyChanged("Ssp_cam087_spro");
            }
        }
        #endregion
        #region Ssp_cam088_spro: 88.Citologia Cervico uterina Resultados
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 88.Citologia Cervico uterina Resultados</para>
        /// <para>NOMBRE: ssp_cam088_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 98</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US
        /// (células escamosas atípicas de significado indeterminado) 2-
        /// ASC-H (células escamosas atípicas, que no puede descartar alto
        /// grado) 3- Lesión intraepitelial escamosa de bajo grado ETC
        /// </para>
        /// </summary>
        public String Ssp_cam088_spro
        {
            get { return _ssp_cam088_spro; }
            set
            {
                if (_ssp_cam088_spro == value) return;
                _ssp_cam088_spro = value;
                OnPropertyChanged("Ssp_cam088_spro");
            }
        }
        #endregion
        #region Ssp_cam089_spro: 89.Calidad en la Muestra de Citología Ce
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 89.Calidad en la Muestra de Citología Ce</para>
        /// <para>NOMBRE: ssp_cam089_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 99</para>
        /// <para>DESCRIPCION:
        /// Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria
        /// Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación
        /// Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato
        /// registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam089_spro
        {
            get { return _ssp_cam089_spro; }
            set
            {
                if (_ssp_cam089_spro == value) return;
                _ssp_cam089_spro = value;
                OnPropertyChanged("Ssp_cam089_spro");
            }
        }
        #endregion
        #region Ssp_cam090_spro: 90.Codigo de habilitación IPS donde se t
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 90.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam090_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 100</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Citologia Cervicouterina
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public String Ssp_cam090_spro
        {
            get { return _ssp_cam090_spro; }
            set
            {
                if (_ssp_cam090_spro == value) return;
                _ssp_cam090_spro = value;
                OnPropertyChanged("Ssp_cam090_spro");
            }
        }
        #endregion
        #region Ssp_cam091_spro: 91.Fecha Colposcopia
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 91.Fecha Colposcopia</para>
        /// <para>NOMBRE: ssp_cam091_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 101</para>
        /// <para>DESCRIPCION:
        /// Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam091_spro
        {
            get { return _ssp_cam091_spro; }
            set
            {
                if (_ssp_cam091_spro == value) return;
                _ssp_cam091_spro = value;
                OnPropertyChanged("Ssp_cam091_spro");
            }
        }
        #endregion
        #region Ssp_cam092_spro: 92.Codigo de habilitación IPS donde se t
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 92.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam092_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 102</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Colposcopia Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam092_spro
        {
            get { return _ssp_cam092_spro; }
            set
            {
                if (_ssp_cam092_spro == value) return;
                _ssp_cam092_spro = value;
                OnPropertyChanged("Ssp_cam092_spro");
            }
        }
        #endregion
        #region Ssp_cam093_spro: 93.Fecha Biopsia Cervical
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 93.Fecha Biopsia Cervical</para>
        /// <para>NOMBRE: ssp_cam093_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 103</para>
        /// <para>DESCRIPCION:
        /// Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam093_spro
        {
            get { return _ssp_cam093_spro; }
            set
            {
                if (_ssp_cam093_spro == value) return;
                _ssp_cam093_spro = value;
                OnPropertyChanged("Ssp_cam093_spro");
            }
        }
        #endregion
        #region Ssp_cam094_spro: 94.Resultado de Biopsia Cervical
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 94.Resultado de Biopsia Cervical</para>
        /// <para>NOMBRE: ssp_cam094_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 104</para>
        /// <para>DESCRIPCION:
        /// Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1-
        /// Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto
        /// Grado: NIC II - NIC III ETC
        /// </para>
        /// </summary>
        public String Ssp_cam094_spro
        {
            get { return _ssp_cam094_spro; }
            set
            {
                if (_ssp_cam094_spro == value) return;
                _ssp_cam094_spro = value;
                OnPropertyChanged("Ssp_cam094_spro");
            }
        }
        #endregion
        #region Ssp_cam095_spro: 95.Codigo de habilitación IPS donde se t
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 95.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam095_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 105</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam095_spro
        {
            get { return _ssp_cam095_spro; }
            set
            {
                if (_ssp_cam095_spro == value) return;
                _ssp_cam095_spro = value;
                OnPropertyChanged("Ssp_cam095_spro");
            }
        }
        #endregion
        #region Ssp_cam096_spro: 96.Fecha Mamografía
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 96.Fecha Mamografía</para>
        /// <para>NOMBRE: ssp_cam096_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 106</para>
        /// <para>DESCRIPCION:
        /// Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam096_spro
        {
            get { return _ssp_cam096_spro; }
            set
            {
                if (_ssp_cam096_spro == value) return;
                _ssp_cam096_spro = value;
                OnPropertyChanged("Ssp_cam096_spro");
            }
        }
        #endregion
        #region Ssp_cam097_spro: 97.Resultado Mamografía
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 97.Resultado Mamografía</para>
        /// <para>NOMBRE: ssp_cam097_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 107</para>
        /// <para>DESCRIPCION:
        /// Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico
        /// o Mamograma previo para evaluación 1- Negativo 2- Hallazgos
        /// Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa
        /// ETC
        /// </para>
        /// </summary>
        public String Ssp_cam097_spro
        {
            get { return _ssp_cam097_spro; }
            set
            {
                if (_ssp_cam097_spro == value) return;
                _ssp_cam097_spro = value;
                OnPropertyChanged("Ssp_cam097_spro");
            }
        }
        #endregion
        #region Ssp_cam098_spro: 98.Codigo de habilitación IPS donde se t
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 98.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: ssp_cam098_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 108</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS
        /// (Registro Especial de Prestadores de Servicios de Salud). Si
        /// no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam098_spro
        {
            get { return _ssp_cam098_spro; }
            set
            {
                if (_ssp_cam098_spro == value) return;
                _ssp_cam098_spro = value;
                OnPropertyChanged("Ssp_cam098_spro");
            }
        }
        #endregion
        #region Ssp_cam099_spro: 99.Fecha Toma Biopsia Seno por BACAF
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 99.Fecha Toma Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: ssp_cam099_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 109</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam099_spro
        {
            get { return _ssp_cam099_spro; }
            set
            {
                if (_ssp_cam099_spro == value) return;
                _ssp_cam099_spro = value;
                OnPropertyChanged("Ssp_cam099_spro");
            }
        }
        #endregion
        #region Ssp_cam100_spro: 100.Fecha Resultado Biopsia Seno por BAC
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 100.Fecha Resultado Biopsia Seno por BAC</para>
        /// <para>NOMBRE: ssp_cam100_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 110</para>
        /// <para>DESCRIPCION:
        /// Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam100_spro
        {
            get { return _ssp_cam100_spro; }
            set
            {
                if (_ssp_cam100_spro == value) return;
                _ssp_cam100_spro = value;
                OnPropertyChanged("Ssp_cam100_spro");
            }
        }
        #endregion
        #region Ssp_cam101_spro: 101.Biopsia Seno por BACAF
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 101.Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: ssp_cam101_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 111</para>
        /// <para>DESCRIPCION:
        /// Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada)
        /// 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public String Ssp_cam101_spro
        {
            get { return _ssp_cam101_spro; }
            set
            {
                if (_ssp_cam101_spro == value) return;
                _ssp_cam101_spro = value;
                OnPropertyChanged("Ssp_cam101_spro");
            }
        }
        #endregion
        #region Ssp_cam102_spro: 102.Codigo de habilitación IPS donde se
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 102.Codigo de habilitación IPS donde se</para>
        /// <para>NOMBRE: ssp_cam102_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 112</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public String Ssp_cam102_spro
        {
            get { return _ssp_cam102_spro; }
            set
            {
                if (_ssp_cam102_spro == value) return;
                _ssp_cam102_spro = value;
                OnPropertyChanged("Ssp_cam102_spro");
            }
        }
        #endregion
        #region Ssp_cam103_spro: 103.Fecha Toma de Hemoglobina
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 103.Fecha Toma de Hemoglobina</para>
        /// <para>NOMBRE: ssp_cam103_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 113</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam103_spro
        {
            get { return _ssp_cam103_spro; }
            set
            {
                if (_ssp_cam103_spro == value) return;
                _ssp_cam103_spro = value;
                OnPropertyChanged("Ssp_cam103_spro");
            }
        }
        #endregion
        #region Ssp_cam104_spro: 104.Hemoglobina
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 104.Hemoglobina</para>
        /// <para>NOMBRE: ssp_cam104_spro (int:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 114</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Registre el dato reportado por el laboratorio.
        /// Si no aplica registre 9998
        /// </para>
        /// </summary>
        public int Ssp_cam104_spro
        {
            get { return _ssp_cam104_spro; }
            set
            {
                if (_ssp_cam104_spro == value) return;
                _ssp_cam104_spro = value;
                OnPropertyChanged("Ssp_cam104_spro");
            }
        }
        #endregion
        #region Ssp_cam105_spro: 105.Fecha de la Toma de Glicemia Basal
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 105.Fecha de la Toma de Glicemia Basal</para>
        /// <para>NOMBRE: ssp_cam105_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 115</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam105_spro
        {
            get { return _ssp_cam105_spro; }
            set
            {
                if (_ssp_cam105_spro == value) return;
                _ssp_cam105_spro = value;
                OnPropertyChanged("Ssp_cam105_spro");
            }
        }
        #endregion
        #region Ssp_cam106_spro: 106.Fecha Creatinina
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 106.Fecha Creatinina</para>
        /// <para>NOMBRE: ssp_cam106_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 116</para>
        /// <para>DESCRIPCION:
        /// Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam106_spro
        {
            get { return _ssp_cam106_spro; }
            set
            {
                if (_ssp_cam106_spro == value) return;
                _ssp_cam106_spro = value;
                OnPropertyChanged("Ssp_cam106_spro");
            }
        }
        #endregion
        #region Ssp_cam107_spro: 107.Creatinina
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 107.Creatinina</para>
        /// <para>NOMBRE: ssp_cam107_spro (int:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 117</para>
        /// <para>DESCRIPCION:
        /// Creatinina Registre el dato reportado por el laboratorio. Si
        /// no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int Ssp_cam107_spro
        {
            get { return _ssp_cam107_spro; }
            set
            {
                if (_ssp_cam107_spro == value) return;
                _ssp_cam107_spro = value;
                OnPropertyChanged("Ssp_cam107_spro");
            }
        }
        #endregion
        #region Ssp_cam108_spro: 108.Fecha Hemoglobina Glicosilada
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 108.Fecha Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: ssp_cam108_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 118</para>
        /// <para>DESCRIPCION:
        /// Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam108_spro
        {
            get { return _ssp_cam108_spro; }
            set
            {
                if (_ssp_cam108_spro == value) return;
                _ssp_cam108_spro = value;
                OnPropertyChanged("Ssp_cam108_spro");
            }
        }
        #endregion
        #region Ssp_cam109_spro: 109.Hemoglobina Glicosilada
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 109.Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: ssp_cam109_spro (int:62)</para>
        /// <para>ORDEN VISTA EN TABLA: 119</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Glicosilada Registre el dato reportado por el laboratorio
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int Ssp_cam109_spro
        {
            get { return _ssp_cam109_spro; }
            set
            {
                if (_ssp_cam109_spro == value) return;
                _ssp_cam109_spro = value;
                OnPropertyChanged("Ssp_cam109_spro");
            }
        }
        #endregion
        #region Ssp_cam110_spro: 110.Fecha Toma de Microalbuminuria
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 110.Fecha Toma de Microalbuminuria</para>
        /// <para>NOMBRE: ssp_cam110_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 120</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam110_spro
        {
            get { return _ssp_cam110_spro; }
            set
            {
                if (_ssp_cam110_spro == value) return;
                _ssp_cam110_spro = value;
                OnPropertyChanged("Ssp_cam110_spro");
            }
        }
        #endregion
        #region Ssp_cam111_spro: 111.Fecha Toma de HDL
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 111.Fecha Toma de HDL</para>
        /// <para>NOMBRE: ssp_cam111_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 121</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam111_spro
        {
            get { return _ssp_cam111_spro; }
            set
            {
                if (_ssp_cam111_spro == value) return;
                _ssp_cam111_spro = value;
                OnPropertyChanged("Ssp_cam111_spro");
            }
        }
        #endregion
        #region Ssp_cam112_spro: 112.Fecha Toma de Baciloscopia de Diagno
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 112.Fecha Toma de Baciloscopia de Diagno</para>
        /// <para>NOMBRE: ssp_cam112_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 122</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public DateTime Ssp_cam112_spro
        {
            get { return _ssp_cam112_spro; }
            set
            {
                if (_ssp_cam112_spro == value) return;
                _ssp_cam112_spro = value;
                OnPropertyChanged("Ssp_cam112_spro");
            }
        }
        #endregion
        #region Ssp_cam113_spro: 113.Baciloscopia de Diagnostico
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 113.Baciloscopia de Diagnostico</para>
        /// <para>NOMBRE: ssp_cam113_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 123</para>
        /// <para>DESCRIPCION:
        /// Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3-
        /// Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public String Ssp_cam113_spro
        {
            get { return _ssp_cam113_spro; }
            set
            {
                if (_ssp_cam113_spro == value) return;
                _ssp_cam113_spro = value;
                OnPropertyChanged("Ssp_cam113_spro");
            }
        }
        #endregion
        #region Ssp_cam114_spro: 114.Tratamiento para Hipotiroidismo Cong
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 114.Tratamiento para Hipotiroidismo Cong</para>
        /// <para>NOMBRE: ssp_cam114_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 124</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud que se lo impide ETC
        /// </para>
        /// </summary>
        public String Ssp_cam114_spro
        {
            get { return _ssp_cam114_spro; }
            set
            {
                if (_ssp_cam114_spro == value) return;
                _ssp_cam114_spro = value;
                OnPropertyChanged("Ssp_cam114_spro");
            }
        }
        #endregion
        #region Ssp_cam115_spro: 115.Tratamiento para Sífilis gestacional
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 115.Tratamiento para Sífilis gestacional</para>
        /// <para>NOMBRE: ssp_cam115_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 125</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis gestacional 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam115_spro
        {
            get { return _ssp_cam115_spro; }
            set
            {
                if (_ssp_cam115_spro == value) return;
                _ssp_cam115_spro = value;
                OnPropertyChanged("Ssp_cam115_spro");
            }
        }
        #endregion
        #region Ssp_cam116_spro: 116.Tratamiento para Sífilis Congénita
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 116.Tratamiento para Sífilis Congénita</para>
        /// <para>NOMBRE: ssp_cam116_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 126</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis Congenita 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam116_spro
        {
            get { return _ssp_cam116_spro; }
            set
            {
                if (_ssp_cam116_spro == value) return;
                _ssp_cam116_spro = value;
                OnPropertyChanged("Ssp_cam116_spro");
            }
        }
        #endregion
        #region Ssp_cam117_spro: 117.Tratamiento para Lepra
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 117.Tratamiento para Lepra</para>
        /// <para>NOMBRE: ssp_cam117_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 127</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Lepra 0- No recibió tratamiento por tener
        /// una tradición que se lo impide 1- No recibió tratamiento por
        /// una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public String Ssp_cam117_spro
        {
            get { return _ssp_cam117_spro; }
            set
            {
                if (_ssp_cam117_spro == value) return;
                _ssp_cam117_spro = value;
                OnPropertyChanged("Ssp_cam117_spro");
            }
        }
        #endregion
        #region Ssp_cam118_spro: 118.Fecha de Terminación Tratamiento par
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 118.Fecha de Terminación Tratamiento par</para>
        /// <para>NOMBRE: ssp_cam118_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 128</para>
        /// <para>DESCRIPCION:
        /// Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 Si no se realiza por
        /// una Condición de Salud registrar 1810-01-01
        /// </para>
        /// </summary>
        public DateTime Ssp_cam118_spro
        {
            get { return _ssp_cam118_spro; }
            set
            {
                if (_ssp_cam118_spro == value) return;
                _ssp_cam118_spro = value;
                OnPropertyChanged("Ssp_cam118_spro");
            }
        }
        #endregion
        #region Ssp_desper_peri: Descripción periodo
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
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
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
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
        public static bool flgAddRegistro(ModeloSspNsSISPRO tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFsptablanssispro();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Sptablanssispro.FirstOrDefault(p => p.ssp_idesec_sprn == tobTempReg.Ssp_idesec_sprn);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.ssp_idesec_sprn = tobTempReg.Ssp_idesec_sprn;
                            lobEFReg.ssp_codper_peri = tobTempReg.Ssp_codper_peri;
                            lobEFReg.ssp_mesper_peri = tobTempReg.Ssp_mesper_peri;
                            lobEFReg.ssp_anoper_peri = tobTempReg.Ssp_anoper_peri;
                            lobEFReg.ssp_llaper_sprn = tobTempReg.Ssp_llaper_sprn;
                            lobEFReg.ssp_llaloc_sprn = tobTempReg.Ssp_llaloc_sprn;
                            lobEFReg.sia_idesec_usua = tobTempReg.Sia_idesec_usua;
                            lobEFReg.sia_nroide_usua = tobTempReg.Sia_nroide_usua;
                            lobEFReg.sia_codeps_teps = tobTempReg.Sia_codeps_teps;
                            lobEFReg.ssp_cam000_spro = tobTempReg.Ssp_cam000_spro;
                            lobEFReg.ssp_cam001_spro = tobTempReg.Ssp_cam001_spro;
                            lobEFReg.ssp_cam002_spro = tobTempReg.Ssp_cam002_spro;
                            lobEFReg.ssp_cam003_spro = tobTempReg.Ssp_cam003_spro;
                            lobEFReg.ssp_cam004_spro = tobTempReg.Ssp_cam004_spro;
                            lobEFReg.ssp_cam005_spro = tobTempReg.Ssp_cam005_spro;
                            lobEFReg.ssp_cam006_spro = tobTempReg.Ssp_cam006_spro;
                            lobEFReg.ssp_cam007_spro = tobTempReg.Ssp_cam007_spro;
                            lobEFReg.ssp_cam008_spro = tobTempReg.Ssp_cam008_spro;
                            lobEFReg.ssp_cam009_spro = (DateTime)tobTempReg.Ssp_cam009_spro;
                            lobEFReg.ssp_cam010_spro = tobTempReg.Ssp_cam010_spro;
                            lobEFReg.ssp_cam011_spro = tobTempReg.Ssp_cam011_spro;
                            lobEFReg.ssp_codocu_ciuo = tobTempReg.Ssp_codocu_ciuo;
                            lobEFReg.ssp_cam013_spro = tobTempReg.Ssp_cam013_spro;
                            lobEFReg.ssp_cam014_spro = tobTempReg.Ssp_cam014_spro;
                            lobEFReg.ssp_cam015_spro = tobTempReg.Ssp_cam015_spro;
                            lobEFReg.ssp_cam016_spro = tobTempReg.Ssp_cam016_spro;
                            lobEFReg.ssp_cam017_spro = tobTempReg.Ssp_cam017_spro;
                            lobEFReg.ssp_cam018_spro = tobTempReg.Ssp_cam018_spro;
                            lobEFReg.ssp_cam019_spro = tobTempReg.Ssp_cam019_spro;
                            lobEFReg.ssp_cam020_spro = tobTempReg.Ssp_cam020_spro;
                            lobEFReg.ssp_cam021_spro = tobTempReg.Ssp_cam021_spro;
                            lobEFReg.ssp_cam022_spro = tobTempReg.Ssp_cam022_spro;
                            lobEFReg.ssp_cam023_spro = tobTempReg.Ssp_cam023_spro;
                            lobEFReg.ssp_cam024_spro = tobTempReg.Ssp_cam024_spro;
                            lobEFReg.ssp_cam025_spro = tobTempReg.Ssp_cam025_spro;
                            lobEFReg.ssp_cam026_spro = tobTempReg.Ssp_cam026_spro;
                            lobEFReg.ssp_cam027_spro = tobTempReg.Ssp_cam027_spro;
                            lobEFReg.ssp_cam028_spro = tobTempReg.Ssp_cam028_spro;
                            lobEFReg.ssp_cam029_spro = (DateTime)tobTempReg.Ssp_cam029_spro;
                            lobEFReg.ssp_cam030_spro = (int)tobTempReg.Ssp_cam030_spro;
                            lobEFReg.ssp_cam031_spro = (DateTime)tobTempReg.Ssp_cam031_spro;
                            lobEFReg.ssp_cam032_spro = (int)tobTempReg.Ssp_cam032_spro;
                            lobEFReg.ssp_cam033_spro = (DateTime)tobTempReg.Ssp_cam033_spro;
                            lobEFReg.ssp_cam034_spro = (int)tobTempReg.Ssp_cam034_spro;
                            lobEFReg.ssp_cam035_spro = tobTempReg.Ssp_cam035_spro;
                            lobEFReg.ssp_cam036_spro = tobTempReg.Ssp_cam036_spro;
                            lobEFReg.ssp_cam037_spro = tobTempReg.Ssp_cam037_spro;
                            lobEFReg.ssp_cam038_spro = tobTempReg.Ssp_cam038_spro;
                            lobEFReg.ssp_cam039_spro = tobTempReg.Ssp_cam039_spro;
                            lobEFReg.ssp_cam040_spro = tobTempReg.Ssp_cam040_spro;
                            lobEFReg.ssp_cam041_spro = tobTempReg.Ssp_cam041_spro;
                            lobEFReg.ssp_cam042_spro = tobTempReg.Ssp_cam042_spro;
                            lobEFReg.ssp_cam043_spro = tobTempReg.Ssp_cam043_spro;
                            lobEFReg.ssp_cam044_spro = tobTempReg.Ssp_cam044_spro;
                            lobEFReg.ssp_cam045_spro = tobTempReg.Ssp_cam045_spro;
                            lobEFReg.ssp_cam046_spro = tobTempReg.Ssp_cam046_spro;
                            lobEFReg.ssp_cam047_spro = tobTempReg.Ssp_cam047_spro;
                            lobEFReg.ssp_cam048_spro = tobTempReg.Ssp_cam048_spro;
                            lobEFReg.ssp_cam049_spro = (DateTime)tobTempReg.Ssp_cam049_spro;
                            lobEFReg.ssp_cam050_spro = (DateTime)tobTempReg.Ssp_cam050_spro;
                            lobEFReg.ssp_cam051_spro = (DateTime)tobTempReg.Ssp_cam051_spro;
                            lobEFReg.ssp_cam052_spro = (DateTime)tobTempReg.Ssp_cam052_spro;
                            lobEFReg.ssp_cam053_spro = (DateTime)tobTempReg.Ssp_cam053_spro;
                            lobEFReg.ssp_cam054_spro = tobTempReg.Ssp_cam054_spro;
                            lobEFReg.ssp_cam055_spro = (DateTime)tobTempReg.Ssp_cam055_spro;
                            lobEFReg.ssp_cam056_spro = (DateTime)tobTempReg.Ssp_cam056_spro;
                            lobEFReg.ssp_cam057_spro = (int)tobTempReg.Ssp_cam057_spro;
                            lobEFReg.ssp_cam058_spro = (DateTime)tobTempReg.Ssp_cam058_spro;
                            lobEFReg.ssp_cam059_spro = tobTempReg.Ssp_cam059_spro;
                            lobEFReg.ssp_cam060_spro = tobTempReg.Ssp_cam060_spro;
                            lobEFReg.ssp_cam061_spro = tobTempReg.Ssp_cam061_spro;
                            lobEFReg.ssp_cam062_spro = (DateTime)tobTempReg.Ssp_cam062_spro;
                            lobEFReg.ssp_cam063_spro = (DateTime)tobTempReg.Ssp_cam063_spro;
                            lobEFReg.ssp_cam064_spro = (DateTime)tobTempReg.Ssp_cam064_spro;
                            lobEFReg.ssp_cam065_spro = (DateTime)tobTempReg.Ssp_cam065_spro;
                            lobEFReg.ssp_cam066_spro = (DateTime)tobTempReg.Ssp_cam066_spro;
                            lobEFReg.ssp_cam067_spro = (DateTime)tobTempReg.Ssp_cam067_spro;
                            lobEFReg.ssp_cam068_spro = (DateTime)tobTempReg.Ssp_cam068_spro;
                            lobEFReg.ssp_cam069_spro = (DateTime)tobTempReg.Ssp_cam069_spro;
                            lobEFReg.ssp_cam070_spro = tobTempReg.Ssp_cam070_spro;
                            lobEFReg.ssp_cam071_spro = tobTempReg.Ssp_cam071_spro;
                            lobEFReg.ssp_cam072_spro = (DateTime)tobTempReg.Ssp_cam072_spro;
                            lobEFReg.ssp_cam073_spro = (DateTime)tobTempReg.Ssp_cam073_spro;
                            lobEFReg.ssp_cam074_spro = (int)tobTempReg.Ssp_cam074_spro;
                            lobEFReg.ssp_cam075_spro = (DateTime)tobTempReg.Ssp_cam075_spro;
                            lobEFReg.ssp_cam076_spro = (DateTime)tobTempReg.Ssp_cam076_spro;
                            lobEFReg.ssp_cam077_spro = tobTempReg.Ssp_cam077_spro;
                            lobEFReg.ssp_cam078_spro = (DateTime)tobTempReg.Ssp_cam078_spro;
                            lobEFReg.ssp_cam079_spro = tobTempReg.Ssp_cam079_spro;
                            lobEFReg.ssp_cam080_spro = (DateTime)tobTempReg.Ssp_cam080_spro;
                            lobEFReg.ssp_cam081_spro = tobTempReg.Ssp_cam081_spro;
                            lobEFReg.ssp_cam082_spro = (DateTime)tobTempReg.Ssp_cam082_spro;
                            lobEFReg.ssp_cam083_spro = tobTempReg.Ssp_cam083_spro;
                            lobEFReg.ssp_cam084_spro = (DateTime)tobTempReg.Ssp_cam084_spro;
                            lobEFReg.ssp_cam085_spro = tobTempReg.Ssp_cam085_spro;
                            lobEFReg.ssp_cam086_spro = tobTempReg.Ssp_cam086_spro;
                            lobEFReg.ssp_cam087_spro = (DateTime)tobTempReg.Ssp_cam087_spro;
                            lobEFReg.ssp_cam088_spro = tobTempReg.Ssp_cam088_spro;
                            lobEFReg.ssp_cam089_spro = tobTempReg.Ssp_cam089_spro;
                            lobEFReg.ssp_cam090_spro = tobTempReg.Ssp_cam090_spro;
                            lobEFReg.ssp_cam091_spro = (DateTime)tobTempReg.Ssp_cam091_spro;
                            lobEFReg.ssp_cam092_spro = tobTempReg.Ssp_cam092_spro;
                            lobEFReg.ssp_cam093_spro = (DateTime)tobTempReg.Ssp_cam093_spro;
                            lobEFReg.ssp_cam094_spro = tobTempReg.Ssp_cam094_spro;
                            lobEFReg.ssp_cam095_spro = tobTempReg.Ssp_cam095_spro;
                            lobEFReg.ssp_cam096_spro = (DateTime)tobTempReg.Ssp_cam096_spro;
                            lobEFReg.ssp_cam097_spro = tobTempReg.Ssp_cam097_spro;
                            lobEFReg.ssp_cam098_spro = tobTempReg.Ssp_cam098_spro;
                            lobEFReg.ssp_cam099_spro = (DateTime)tobTempReg.Ssp_cam099_spro;
                            lobEFReg.ssp_cam100_spro = (DateTime)tobTempReg.Ssp_cam100_spro;
                            lobEFReg.ssp_cam101_spro = tobTempReg.Ssp_cam101_spro;
                            lobEFReg.ssp_cam102_spro = tobTempReg.Ssp_cam102_spro;
                            lobEFReg.ssp_cam103_spro = (DateTime)tobTempReg.Ssp_cam103_spro;
                            lobEFReg.ssp_cam104_spro = (int)tobTempReg.Ssp_cam104_spro;
                            lobEFReg.ssp_cam105_spro = (DateTime)tobTempReg.Ssp_cam105_spro;
                            lobEFReg.ssp_cam106_spro = (DateTime)tobTempReg.Ssp_cam106_spro;
                            lobEFReg.ssp_cam107_spro = (int)tobTempReg.Ssp_cam107_spro;
                            lobEFReg.ssp_cam108_spro = (DateTime)tobTempReg.Ssp_cam108_spro;
                            lobEFReg.ssp_cam109_spro = (int)tobTempReg.Ssp_cam109_spro;
                            lobEFReg.ssp_cam110_spro = (DateTime)tobTempReg.Ssp_cam110_spro;
                            lobEFReg.ssp_cam111_spro = (DateTime)tobTempReg.Ssp_cam111_spro;
                            lobEFReg.ssp_cam112_spro = (DateTime)tobTempReg.Ssp_cam112_spro;
                            lobEFReg.ssp_cam113_spro = tobTempReg.Ssp_cam113_spro;
                            lobEFReg.ssp_cam114_spro = tobTempReg.Ssp_cam114_spro;
                            lobEFReg.ssp_cam115_spro = tobTempReg.Ssp_cam115_spro;
                            lobEFReg.ssp_cam116_spro = tobTempReg.Ssp_cam116_spro;
                            lobEFReg.ssp_cam117_spro = tobTempReg.Ssp_cam117_spro;
                            lobEFReg.ssp_cam118_spro = (DateTime)tobTempReg.Ssp_cam118_spro;
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
                                lobEFReg.ssp_idesec_sprn = tcrCodigoR1 + lobEFReg.ssp_idesec_sprn; // concatenar
                                _context.AddToSptablanssispro(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Sptablanssispro.FirstOrDefault(p => p.ssp_idesec_sprn == tobTempReg.Ssp_idesec_sprn);
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
        #region Buscar SPTABLANSSISPRO: Logica
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TITULO: Novedades mensuales SISPRO</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que almacena las novedades realizadas en un periodo para
        /// el SISPRO
        /// </para>
        /// </summary>
        public static bool flgBuscarSptablanssispro(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablanssispro.FirstOrDefault(p => p.ssp_idesec_sprn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloSspNsSISPRO> flsListaSptablanssispro(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from sptablanssispro in _context.Sptablanssispro
                                  join sptablaperiodos in _context.Sptablaperiodos on sptablanssispro.ssp_codper_peri equals sptablaperiodos.ssp_codper_peri into tmsptablaperiodos
                                  join spocupacionciuo in _context.Spocupacionciuo on sptablanssispro.ssp_codocu_ciuo equals spocupacionciuo.ssp_codocu_ciuo into tmspocupacionciuo
                                  from peri in tmsptablaperiodos.DefaultIfEmpty()
                                  from ciuo in tmspocupacionciuo.DefaultIfEmpty()
                                  where sptablanssispro.ssp_cam001_spro == tcrBuscar
                                  select new ModeloSspNsSISPRO
                                  {
                                      Ssp_idesec_sprn = sptablanssispro.ssp_idesec_sprn,
                                      Ssp_codper_peri = sptablanssispro.ssp_codper_peri,
                                      Ssp_mesper_peri = sptablanssispro.ssp_mesper_peri,
                                      Ssp_anoper_peri = sptablanssispro.ssp_anoper_peri,
                                      Ssp_llaper_sprn = sptablanssispro.ssp_llaper_sprn,
                                      Ssp_llaloc_sprn = sptablanssispro.ssp_llaloc_sprn,
                                      Sia_idesec_usua = sptablanssispro.sia_idesec_usua,
                                      Sia_nroide_usua = sptablanssispro.sia_nroide_usua,
                                      Sia_codeps_teps = sptablanssispro.sia_codeps_teps,
                                      Ssp_cam000_spro = sptablanssispro.ssp_cam000_spro,
                                      Ssp_cam001_spro = sptablanssispro.ssp_cam001_spro,
                                      Ssp_cam002_spro = sptablanssispro.ssp_cam002_spro,
                                      Ssp_cam003_spro = sptablanssispro.ssp_cam003_spro,
                                      Ssp_cam004_spro = sptablanssispro.ssp_cam004_spro,
                                      Ssp_cam005_spro = sptablanssispro.ssp_cam005_spro,
                                      Ssp_cam006_spro = sptablanssispro.ssp_cam006_spro,
                                      Ssp_cam007_spro = sptablanssispro.ssp_cam007_spro,
                                      Ssp_cam008_spro = sptablanssispro.ssp_cam008_spro,
                                      Ssp_cam009_spro = (DateTime)sptablanssispro.ssp_cam009_spro,
                                      Ssp_cam010_spro = sptablanssispro.ssp_cam010_spro,
                                      Ssp_cam011_spro = sptablanssispro.ssp_cam011_spro,
                                      Ssp_codocu_ciuo = sptablanssispro.ssp_codocu_ciuo,
                                      Ssp_cam013_spro = sptablanssispro.ssp_cam013_spro,
                                      Ssp_cam014_spro = sptablanssispro.ssp_cam014_spro,
                                      Ssp_cam015_spro = sptablanssispro.ssp_cam015_spro,
                                      Ssp_cam016_spro = sptablanssispro.ssp_cam016_spro,
                                      Ssp_cam017_spro = sptablanssispro.ssp_cam017_spro,
                                      Ssp_cam018_spro = sptablanssispro.ssp_cam018_spro,
                                      Ssp_cam019_spro = sptablanssispro.ssp_cam019_spro,
                                      Ssp_cam020_spro = sptablanssispro.ssp_cam020_spro,
                                      Ssp_cam021_spro = sptablanssispro.ssp_cam021_spro,
                                      Ssp_cam022_spro = sptablanssispro.ssp_cam022_spro,
                                      Ssp_cam023_spro = sptablanssispro.ssp_cam023_spro,
                                      Ssp_cam024_spro = sptablanssispro.ssp_cam024_spro,
                                      Ssp_cam025_spro = sptablanssispro.ssp_cam025_spro,
                                      Ssp_cam026_spro = sptablanssispro.ssp_cam026_spro,
                                      Ssp_cam027_spro = sptablanssispro.ssp_cam027_spro,
                                      Ssp_cam028_spro = sptablanssispro.ssp_cam028_spro,
                                      Ssp_cam029_spro = (DateTime)sptablanssispro.ssp_cam029_spro,
                                      Ssp_cam030_spro = (int)sptablanssispro.ssp_cam030_spro,
                                      Ssp_cam031_spro = (DateTime)sptablanssispro.ssp_cam031_spro,
                                      Ssp_cam032_spro = (int)sptablanssispro.ssp_cam032_spro,
                                      Ssp_cam033_spro = (DateTime)sptablanssispro.ssp_cam033_spro,
                                      Ssp_cam034_spro = (int)sptablanssispro.ssp_cam034_spro,
                                      Ssp_cam035_spro = sptablanssispro.ssp_cam035_spro,
                                      Ssp_cam036_spro = sptablanssispro.ssp_cam036_spro,
                                      Ssp_cam037_spro = sptablanssispro.ssp_cam037_spro,
                                      Ssp_cam038_spro = sptablanssispro.ssp_cam038_spro,
                                      Ssp_cam039_spro = sptablanssispro.ssp_cam039_spro,
                                      Ssp_cam040_spro = sptablanssispro.ssp_cam040_spro,
                                      Ssp_cam041_spro = sptablanssispro.ssp_cam041_spro,
                                      Ssp_cam042_spro = sptablanssispro.ssp_cam042_spro,
                                      Ssp_cam043_spro = sptablanssispro.ssp_cam043_spro,
                                      Ssp_cam044_spro = sptablanssispro.ssp_cam044_spro,
                                      Ssp_cam045_spro = sptablanssispro.ssp_cam045_spro,
                                      Ssp_cam046_spro = sptablanssispro.ssp_cam046_spro,
                                      Ssp_cam047_spro = sptablanssispro.ssp_cam047_spro,
                                      Ssp_cam048_spro = sptablanssispro.ssp_cam048_spro,
                                      Ssp_cam049_spro = (DateTime)sptablanssispro.ssp_cam049_spro,
                                      Ssp_cam050_spro = (DateTime)sptablanssispro.ssp_cam050_spro,
                                      Ssp_cam051_spro = (DateTime)sptablanssispro.ssp_cam051_spro,
                                      Ssp_cam052_spro = (DateTime)sptablanssispro.ssp_cam052_spro,
                                      Ssp_cam053_spro = (DateTime)sptablanssispro.ssp_cam053_spro,
                                      Ssp_cam054_spro = sptablanssispro.ssp_cam054_spro,
                                      Ssp_cam055_spro = (DateTime)sptablanssispro.ssp_cam055_spro,
                                      Ssp_cam056_spro = (DateTime)sptablanssispro.ssp_cam056_spro,
                                      Ssp_cam057_spro = (int)sptablanssispro.ssp_cam057_spro,
                                      Ssp_cam058_spro = (DateTime)sptablanssispro.ssp_cam058_spro,
                                      Ssp_cam059_spro = sptablanssispro.ssp_cam059_spro,
                                      Ssp_cam060_spro = sptablanssispro.ssp_cam060_spro,
                                      Ssp_cam061_spro = sptablanssispro.ssp_cam061_spro,
                                      Ssp_cam062_spro = (DateTime)sptablanssispro.ssp_cam062_spro,
                                      Ssp_cam063_spro = (DateTime)sptablanssispro.ssp_cam063_spro,
                                      Ssp_cam064_spro = (DateTime)sptablanssispro.ssp_cam064_spro,
                                      Ssp_cam065_spro = (DateTime)sptablanssispro.ssp_cam065_spro,
                                      Ssp_cam066_spro = (DateTime)sptablanssispro.ssp_cam066_spro,
                                      Ssp_cam067_spro = (DateTime)sptablanssispro.ssp_cam067_spro,
                                      Ssp_cam068_spro = (DateTime)sptablanssispro.ssp_cam068_spro,
                                      Ssp_cam069_spro = (DateTime)sptablanssispro.ssp_cam069_spro,
                                      Ssp_cam070_spro = sptablanssispro.ssp_cam070_spro,
                                      Ssp_cam071_spro = sptablanssispro.ssp_cam071_spro,
                                      Ssp_cam072_spro = (DateTime)sptablanssispro.ssp_cam072_spro,
                                      Ssp_cam073_spro = (DateTime)sptablanssispro.ssp_cam073_spro,
                                      Ssp_cam074_spro = (int)sptablanssispro.ssp_cam074_spro,
                                      Ssp_cam075_spro = (DateTime)sptablanssispro.ssp_cam075_spro,
                                      Ssp_cam076_spro = (DateTime)sptablanssispro.ssp_cam076_spro,
                                      Ssp_cam077_spro = sptablanssispro.ssp_cam077_spro,
                                      Ssp_cam078_spro = (DateTime)sptablanssispro.ssp_cam078_spro,
                                      Ssp_cam079_spro = sptablanssispro.ssp_cam079_spro,
                                      Ssp_cam080_spro = (DateTime)sptablanssispro.ssp_cam080_spro,
                                      Ssp_cam081_spro = sptablanssispro.ssp_cam081_spro,
                                      Ssp_cam082_spro = (DateTime)sptablanssispro.ssp_cam082_spro,
                                      Ssp_cam083_spro = sptablanssispro.ssp_cam083_spro,
                                      Ssp_cam084_spro = (DateTime)sptablanssispro.ssp_cam084_spro,
                                      Ssp_cam085_spro = sptablanssispro.ssp_cam085_spro,
                                      Ssp_cam086_spro = sptablanssispro.ssp_cam086_spro,
                                      Ssp_cam087_spro = (DateTime)sptablanssispro.ssp_cam087_spro,
                                      Ssp_cam088_spro = sptablanssispro.ssp_cam088_spro,
                                      Ssp_cam089_spro = sptablanssispro.ssp_cam089_spro,
                                      Ssp_cam090_spro = sptablanssispro.ssp_cam090_spro,
                                      Ssp_cam091_spro = (DateTime)sptablanssispro.ssp_cam091_spro,
                                      Ssp_cam092_spro = sptablanssispro.ssp_cam092_spro,
                                      Ssp_cam093_spro = (DateTime)sptablanssispro.ssp_cam093_spro,
                                      Ssp_cam094_spro = sptablanssispro.ssp_cam094_spro,
                                      Ssp_cam095_spro = sptablanssispro.ssp_cam095_spro,
                                      Ssp_cam096_spro = (DateTime)sptablanssispro.ssp_cam096_spro,
                                      Ssp_cam097_spro = sptablanssispro.ssp_cam097_spro,
                                      Ssp_cam098_spro = sptablanssispro.ssp_cam098_spro,
                                      Ssp_cam099_spro = (DateTime)sptablanssispro.ssp_cam099_spro,
                                      Ssp_cam100_spro = (DateTime)sptablanssispro.ssp_cam100_spro,
                                      Ssp_cam101_spro = sptablanssispro.ssp_cam101_spro,
                                      Ssp_cam102_spro = sptablanssispro.ssp_cam102_spro,
                                      Ssp_cam103_spro = (DateTime)sptablanssispro.ssp_cam103_spro,
                                      Ssp_cam104_spro = (int)sptablanssispro.ssp_cam104_spro,
                                      Ssp_cam105_spro = (DateTime)sptablanssispro.ssp_cam105_spro,
                                      Ssp_cam106_spro = (DateTime)sptablanssispro.ssp_cam106_spro,
                                      Ssp_cam107_spro = (int)sptablanssispro.ssp_cam107_spro,
                                      Ssp_cam108_spro = (DateTime)sptablanssispro.ssp_cam108_spro,
                                      Ssp_cam109_spro = (int)sptablanssispro.ssp_cam109_spro,
                                      Ssp_cam110_spro = (DateTime)sptablanssispro.ssp_cam110_spro,
                                      Ssp_cam111_spro = (DateTime)sptablanssispro.ssp_cam111_spro,
                                      Ssp_cam112_spro = (DateTime)sptablanssispro.ssp_cam112_spro,
                                      Ssp_cam113_spro = sptablanssispro.ssp_cam113_spro,
                                      Ssp_cam114_spro = sptablanssispro.ssp_cam114_spro,
                                      Ssp_cam115_spro = sptablanssispro.ssp_cam115_spro,
                                      Ssp_cam116_spro = sptablanssispro.ssp_cam116_spro,
                                      Ssp_cam117_spro = sptablanssispro.ssp_cam117_spro,
                                      Ssp_cam118_spro = (DateTime)sptablanssispro.ssp_cam118_spro,
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